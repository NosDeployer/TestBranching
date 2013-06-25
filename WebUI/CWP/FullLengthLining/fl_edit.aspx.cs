using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_edit
    /// </summary>
    public partial class fl_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FullLengthLiningTDS fullLengthLiningTDS;
        protected FullLengthLiningTDS.LateralDetailsDataTable flAddLateralsNewDetails;
        protected FullLengthLiningTDS.WetOutCatalystsDetailsDataTable wetOutCatalystsDetails;
        protected FlatSectionJlTDS flatSectionJlTDSForFLL;
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
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_edit.aspx");
                    }

                    // Tag Page
                    TagPage();

                    // Prepare initial data
                    Session.Remove("flAddLateralsNewDummy");
                    Session.Remove("wetOutCatalystsDetailsDummy");
                    Session.Remove("materialInformationTDS");

                    materialInformationTDS = new MaterialInformationTDS();

                    // ... for wet out section list
                    AssetSewerSectionList assetSewerSectionList = new AssetSewerSectionList();
                    assetSewerSectionList.LoadAndAddItem(Int32.Parse(hdfCurrentProjectId.Value), hdfWorkType.Value, "-1", "(All)", Int32.Parse(hdfCompanyId.Value));
                    cbxlSectionId.DataSource = assetSewerSectionList.Table;
                    cbxlSectionId.DataValueField = "SectionID";
                    cbxlSectionId.DataTextField = "FlowOrderID";
                    cbxlSectionId.DataBind();  
                    
                    cbxlInversionDataSectionId.DataSource = assetSewerSectionList.Table;
                    cbxlInversionDataSectionId.DataValueField = "SectionID";
                    cbxlInversionDataSectionId.DataTextField = "FlowOrderID";
                    cbxlInversionDataSectionId.DataBind();  
                   
                    // If coming from 
                    int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                    int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                    int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                    int workId = Int32.Parse(hdfWorkId.Value.Trim());
                    string workType = hdfWorkType.Value;

                    // ... fl_navigator2.aspx
                    if (Request.QueryString["source_page"] == "fl_navigator2.aspx")
                    {
                        StoreNavigatorState();
                        ViewState["update"] = "no";

                        // ... Set initial tab
                        if ((string)Session["dialogOpenedFll"] != "1")
                        {
                            hdfActiveTab.Value = Request.QueryString["active_tab"];

                            fullLengthLiningTDS = new FullLengthLiningTDS();
                            
                            FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
                            fullLengthLiningSectionDetails.LoadByWorkId(workId, companyId);

                            FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                            fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                            FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                            fullLengthLiningLateralDetails.LoadForEdit(workId, assetId, companyId, currentProjectId);

                            FullLengthLiningWetOutCatalystsDetails fullLengthLiningWetOutCatalystsDetails = new FullLengthLiningWetOutCatalystsDetails(fullLengthLiningTDS);
                            fullLengthLiningWetOutCatalystsDetails.LoadAll(workId, companyId);
                        }
                        else
                        {
                            hdfActiveTab.Value = (string)Session["activeTabFll"];

                            // Restore datasets
                            fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];
                        }

                        // ... Store dataset
                        Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                    }

                    // ... fl_summary.aspx or fl_edit.aspx
                    if ((Request.QueryString["source_page"] == "fl_summary.aspx") || (Request.QueryString["source_page"] == "fl_edit.aspx"))
                    {
                        StoreNavigatorState();
                        ViewState["update"] = Request.QueryString["update"];

                        // ... Restore dataset
                        fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];

                        // ... Set initial tab
                        if ((string)Session["dialogOpenedFll"] != "1")
                        {
                            hdfActiveTab.Value = Request.QueryString["active_tab"];
                        }
                        else
                        {
                            hdfActiveTab.Value = (string)Session["activeTabFll"];
                        }

                        if (ViewState["update"].ToString().Trim() == "yes")
                        {
                            FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
                            fullLengthLiningSectionDetails.LoadByWorkId(workId, companyId);

                            FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                            fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                            FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                            fullLengthLiningLateralDetails.LoadForEdit(workId, assetId, companyId, currentProjectId);

                            FullLengthLiningWetOutCatalystsDetails fullLengthLiningWetOutCatalystsDetails = new FullLengthLiningWetOutCatalystsDetails(fullLengthLiningTDS);
                            fullLengthLiningWetOutCatalystsDetails.LoadAll(workId, companyId);

                            // ... Store dataset
                            Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                        }
                    }

                    // Prepare initial data
                    lblMissingData.Visible = false;

                    // Set initial tab
                    int activeTab = Int32.Parse(hdfActiveTab.Value);
                    tcFlDetails.ActiveTabIndex = activeTab;

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

                    // ... Data for current full length lining work                
                    LoadFullLengthLiningData(currentProjectId, assetId, companyId);

                    // Databind
                    Page.DataBind();

                    // Especial load for Run details
                    string runDetails = hdfRunDetails.Value;
                    WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGateway = new WorkFullLengthLiningWetOutGateway();
                    workFullLengthLiningWetOutGateway.LoadByWorkId(workId, companyId);                              

                    // ... Verify if work has cipp information to load run details
                    if (workFullLengthLiningWetOutGateway.Table.Rows.Count > 0)
                    {                        
                        string[] runDetailsList = runDetails.Split('>');
                        for (int i = 0; i < runDetailsList.Length; i++)
                        {
                            cbxlSectionId.Items.FindByValue(runDetailsList[i]).Selected = true;
                            cbxlInversionDataSectionId.Items.FindByValue(runDetailsList[i]).Selected = true;
                        }
                    }
                    else
                    {
                        if (cbxlSectionId.Items.Count > 1)
                        {
                            cbxlSectionId.Items.FindByValue(runDetails).Selected = true;
                        }
                    }

                    // SelectIndex for grids
                    ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewMaterial")).SelectedIndex = 0;
                    ((DropDownList)grdCatalysts.FooterRow.FindControl("ddlNameFooter")).SelectedIndex = 0;

                    // For usmh, dsmh autocomplete
                    string provinceId_ = "0"; if (hdfProvinceId.Value != "") provinceId_ = hdfProvinceId.Value;
                    string countyId_ = "0"; if (hdfCountyId.Value != "") countyId_ = hdfCountyId.Value;
                    string cityId_ = "0"; if (hdfCityId.Value != "") cityId_ = hdfCityId.Value;

                    aceUsmh.ContextKey = hdfCountryId.Value + "," + provinceId_ + "," + countyId_ + "," + cityId_ + "," + hdfCompanyId.Value;
                    aceDsmh.ContextKey = hdfCountryId.Value + "," + provinceId_ + "," + countyId_ + "," + cityId_ + "," + hdfCompanyId.Value;

                    // Make Wetout tab visible
                    if (ckbxWetOutDataIncludeWetOutInformation.Checked)
                    {
                        pnlVisibleInformation.Visible = true;                        
                        upnlVisibleInformation.Update();                        
                    }
                    else
                    {
                        pnlVisibleInformation.Visible = false;                        
                        upnlVisibleInformation.Update();                        
                    }

                    // Make inversion tab visible
                    lblInversionDataInversionMissingData.Visible = false;
                    uplInversionDataInversionMissingData.Update();
                    if (ckbxInversionDataIncludeInversionInformation.Checked)
                    {                       
                        // ... ... visible only if wet out information is provided.
                        if (!ckbxWetOutDataIncludeWetOutInformation.Checked)
                        {                            
                            pnlInversionVisibleInformation.Visible = false;
                            upnlInversionVisibleInformation.Update();
                        }
                        else
                        {
                            
                            pnlInversionVisibleInformation.Visible = true;
                            upnlInversionVisibleInformation.Update();
                        }
                    }
                    else
                    {                        
                        pnlInversionVisibleInformation.Visible = false;                     
                        upnlInversionVisibleInformation.Update();
                    }

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
                fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];
                flatSectionJlTDSForFLL = (FlatSectionJlTDS)Session["flatSectionJlTDSForFLL"];
                materialInformationTDS = (MaterialInformationTDS)Session["materialInformationTDS"];
                materialInformation = materialInformationTDS.MaterialInformation;

                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcFlDetails.ActiveTabIndex = activeTab;                
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
                    GrdFLAddLateralsNewAdd();
                    break;

                case "MaterialUpdate":
                    // Store active tab for postback
                    Session["activeTabFll"] = "2";
                    Session["dialogOpenedFll"] = "1";
                    Save2();

                    // Open Dialog
                    int index = Convert.ToInt32(e.CommandArgument);
                    Session["rowFocus"] = index;
                    GridViewRow gridRow = grdLaterals.Rows[index];
                    int lateral = int.Parse(((Label)gridRow.FindControl("lblLateral")).Text);

                    string script = "<script language='javascript'>";
                    string url = "./../Assets/asset_sewer_material.aspx?source_page=fl_edit.aspx&asset_id=" + lateral + "&work_id=" + hdfWorkId.Value;
                    script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=490, height=540')", url);
                    script = script + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MaterialUpdate", script, false);
                    break;
            }
        }



        protected void grdCatalysts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Catalysts Gridview, if the gridview is edition mode
                    if (grdCatalysts.EditIndex >= 0)
                    {
                        grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
                    }

                    // Add New Catalysts
                    GrdCatalystsAdd();
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
            FullLengthLiningLateralDetails model = new FullLengthLiningLateralDetails(fullLengthLiningTDS);

            // Delete lateral
            model.Delete(lateral);

            tbxLaterals.Text = model.GetTotalLaterals().ToString();
            tbxLiveLaterals.Text = model.GetLiveLaterals().ToString();

            // Store dataset
            Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
        }



        protected void grdCatalysts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Catalysts Gridview, if the gridview is edition mode
            if (grdCatalysts.EditIndex >= 0)
            {
                grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
            }

            //Delete catalysts
            int workId = (int)e.Keys["WorkID"];
            int refId = (int)e.Keys["RefID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete catalysts
            FullLengthLiningWetOutCatalystsDetails model = new FullLengthLiningWetOutCatalystsDetails(fullLengthLiningTDS);
            model.Delete(workId, refId, companyId);

            // Store dataset
            Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

            grdCatalysts.DataBind();
        }



        protected void grdLaterals_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("AddLateralsEdit");
            if (Page.IsValid)
            {
                if (((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlLiveEdit")).Visible == true)
                {
                    Page.Validate("AddLateralsEditSpecial");
                }

                if (Page.IsValid)
                {
                    int lateral = int.Parse(((Label)grdLaterals.Rows[e.RowIndex].Cells[1].FindControl("lblLateral")).Text.Trim());
                    string lateralId = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxLateralIdEdit")).Text.Trim();
                    string clientLateralId = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxClientLateralIdEdit")).Text.Trim();
                    string size = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxSizeEdit")).Text.Trim();

                    // Load material 
                    string material = "";
                    material = ((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlMaterialEdit")).SelectedValue;
                        
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
                    bool inProject = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[3].FindControl("cbxInProject")).Checked;
                    string connectionType = ""; connectionType = ((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlConnectionTypeEdit")).SelectedValue;
                    string mn = ""; mn = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxMnEdit")).Text.Trim();
                    string clientInspectionNo = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxclientInspectionNoEdit")).Text.Trim();
                    bool requiredRoboticPrep = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ckbxRequiresRoboticPrepEdit")).Checked;

                    DateTime? requiredRoboticPrepDate = null;
                    if (((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpRequiresRoboticPrepDateEdit")).SelectedDate.HasValue)
                    {
                        requiredRoboticPrepDate = ((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpRequiresRoboticPrepDateEdit")).SelectedDate.Value;
                    }

                    bool holdClientIssue = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ckbxHoldClientIssueEdit")).Checked;
                    bool holdLFSIssue = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ckbxHoldLFSIssueEdit")).Checked;
                    string flange = ((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlFlangeEdit")).SelectedValue;
                    bool lineLateral = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("cbxJlEdit")).Checked; ;
                    bool dyeTestReq = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ckbxDyeTestReqEdit")).Checked;
                    
                    DateTime? dyeTestComplete = null;
                    if (((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpDyeTestCompleteEdit")).SelectedDate.HasValue)
                    {
                        dyeTestComplete = ((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpDyeTestCompleteEdit")).SelectedDate.Value;
                    }

                    // Update
                    FullLengthLiningLateralDetails lateralModel = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                    lateralModel.Update(lateral, lateralId, size, material, live, videoDistance, clockPosition, distanceToCentre, timeOpened, reverseSetup, reinstate, comments, inProject, clientLateralId, connectionType, mn, clientInspectionNo, requiredRoboticPrep, requiredRoboticPrepDate, holdClientIssue, holdLFSIssue, lineLateral, flange, lineLateral, dyeTestReq, dyeTestComplete);

                    tbxLaterals.Text = lateralModel.GetTotalLaterals().ToString();
                    tbxLiveLaterals.Text = lateralModel.GetLiveLaterals().ToString();

                    // Store dataset
                    Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

                    // Update JL lateral issues
                    FLLateralsSave(lateralId, requiredRoboticPrep, requiredRoboticPrepDate, holdClientIssue, holdLFSIssue, dyeTestReq, dyeTestComplete);
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



        protected void grdCatalysts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("catalystDataEdit");
            if (Page.IsValid)
            {
                int workId = (int)e.Keys["WorkID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                decimal percentageByWeight = -1;
                if (((TextBox)grdCatalysts.Rows[e.RowIndex].Cells[3].FindControl("tbxPercentageByWeightEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdCatalysts.Rows[e.RowIndex].Cells[3].FindControl("tbxPercentageByWeightEdit")).Text.Trim())))
                    {
                        percentageByWeight = decimal.Round(decimal.Parse(((TextBox)grdCatalysts.Rows[e.RowIndex].Cells[3].FindControl("tbxPercentageByWeightEdit")).Text.Trim()), 2);
                    }
                }

                decimal lbsForMixQuantity = -1;
                if (((Label)grdCatalysts.Rows[e.RowIndex].Cells[4].FindControl("lblLbsForMixQuantityEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((Label)grdCatalysts.Rows[e.RowIndex].Cells[4].FindControl("lblLbsForMixQuantityEdit")).Text.Trim())))
                    {
                        lbsForMixQuantity = decimal.Round(decimal.Parse(((Label)grdCatalysts.Rows[e.RowIndex].Cells[4].FindControl("lblLbsForMixQuantityEdit")).Text.Trim()), 2);
                    }
                }

                string lbsForDrum = ((Label)grdCatalysts.Rows[e.RowIndex].Cells[5].FindControl("lblLbsForDrumEdit")).Text.Trim(); ;
                   
                FullLengthLiningWetOutCatalystsDetails model = new FullLengthLiningWetOutCatalystsDetails(fullLengthLiningTDS);
                model.Update(workId, refId, percentageByWeight, lbsForMixQuantity, lbsForDrum, companyId);

                // Store dataset
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                Session["wetOutCatalystsDetails"] = fullLengthLiningTDS.WetOutCatalystsDetails;
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
            if ((tbxWetOutDataHoistHeight.Text == "OK")|| (tbxWetOutDataHoistHeight.Text == ""))
            {
                lblWetOutDataWarning.Visible = false;
            }
            else
            {
                lblWetOutDataWarning.Visible = true;
            }

            // For Video Done From MH and Measured From MH
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            // set visible VideoDoneFromMh and Measured From and To
            FullLengthLiningWorkDetailsGateway flWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
            flWorkDetailsGateway.LoadByWorkIdAssetId(workId, assetId, companyId);

            FullLengthLiningLateralDetails flLateralDetails = new FullLengthLiningLateralDetails();
            flLateralDetails.LoadForEdit(workId, assetId, companyId, currentProjectId);

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

            // For materials (m1)
            MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway();
            materialInformationGateway.LoadLastMaterialByAssetId(assetId, companyId);

            if (materialInformationGateway.Table.Rows.Count > 0)
            {
                ddlM1DataMaterial.SelectedValue = materialInformationGateway.GetLastMaterialType(assetId);
            }            

            // For PreFlush Date and PreVideo Date
            int projectId = Int32.Parse(hdfCurrentProjectId.Value);
            FullLengthLiningWorkDetailsGateway  fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
            fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workId, assetId, companyId);

            int? raProjectId = fullLengthLiningWorkDetailsGateway.GetRaProjectId(workId);
            if ((raProjectId.HasValue) && (raProjectId == projectId))
            {
                // ... if ra data is from the same project
                tkrdpGeneralPreFlushDate.Visible = true;
                tkrdpGeneralPreVideoDate.Visible = true;
                tkrdpGeneralPreFlushDateReadOnly.Visible = false;
                tkrdpGeneralPreVideoDateReadOnly.Visible = false;
            }
            else
            {
                tkrdpGeneralPreFlushDate.Visible = false;
                tkrdpGeneralPreVideoDate.Visible = false;
                tkrdpGeneralPreFlushDateReadOnly.Visible = true;
                tkrdpGeneralPreVideoDateReadOnly.Visible = true;
            }
            // ... if there is no data
            if (tkrdpGeneralPreFlushDate.SelectedDate.HasValue)
            {
                tkrdpGeneralPreFlushDate.Calendar.Enabled = false;
                tkrdpGeneralPreFlushDate.DateInput.ReadOnly = true;
            }
            else
            {
                tkrdpGeneralPreFlushDate.Calendar.Enabled = true;
                tkrdpGeneralPreFlushDate.DateInput.ReadOnly = false;
            }

            if (tkrdpGeneralPreVideoDate.SelectedDate.HasValue)
            {
                tkrdpGeneralPreVideoDate.Calendar.Enabled = false;
                tkrdpGeneralPreVideoDate.DateInput.ReadOnly = true;
            }
            else 
            {
                tkrdpGeneralPreVideoDate.Calendar.Enabled = true;
                tkrdpGeneralPreVideoDate.DateInput.ReadOnly = false;
            }

            // Hide or show the Old CWP ID field
            if (tbxOldCwpId.Text == "")
            {
                lblOldCwpId.Visible = false;
                tbxOldCwpId.Visible = false;
            }

            if (tbxFlowSectionId.Text == "")
            {
                LoadFullLengthLiningData(currentProjectId, assetId, companyId);
            }

            // Validate tools
            if (Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADMIN"]))
            {
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = true; // Resins option
                tkrpbLeftMenuTools.Items[0].Items[2].Visible = true; // Catalyst option

                tkrdpInstallDataInstallDate.Enabled = true;
                tkrdpInstallDataFinalVideoDate.Enabled = true;
            }
            else
            {
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; // Resins option
                tkrpbLeftMenuTools.Items[0].Items[2].Visible = false; // Catalyst option

                tkrdpInstallDataInstallDate.Enabled = false;
                tkrdpInstallDataFinalVideoDate.Enabled = false;
            }
            
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void btnCommentsOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabFll"] = "7";
            Session["dialogOpenedFll"] = "1";
            Save2();

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

            string script = "<script language='javascript'>";
            string url = "./fl_comments.aspx?source_page=fl_edit.aspx&asset_id=" + hdfAssetId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_id=" + hdfWorkId.Value + "&project_id=" + hdfCurrentProjectId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }



        protected void btnWetOutDataNotesOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabFll"] = "4";
            Session["dialogOpenedFll"] = "1";
            Save2();

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

            string newRunDetails = "";
            foreach (ListItem lst in cbxlSectionId.Items)
            {
                if (lst.Selected)
                {
                    newRunDetails = newRunDetails + lst.Value + ">";
                }
            }
            newRunDetails = newRunDetails.Substring(0, newRunDetails.Length - 1);

            string script = "<script language='javascript'>";
            string url = "./fl_comments_cipp.aspx?source_page=fl_edit.aspx&asset_id=" + hdfAssetId.Value + "&work_id=" + hdfWorkId.Value + "&run_details=" + newRunDetails + "&project_id=" + currentProjectId.ToString();
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }


        
        protected void btnAddFieldCureRecordsOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabFll"] = "5";
            Session["dialogOpenedFll"] = "1";
            Save2();

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

            string newRunDetails = "";
            foreach (ListItem lst in cbxlSectionId.Items)
            {
                if (lst.Selected)
                {
                    newRunDetails = newRunDetails + lst.Value + ">";
                }
            }
            newRunDetails = newRunDetails.Substring(0, newRunDetails.Length - 1);

            string script = "<script language='javascript'>";
            string url = "./fl_field_cure_records.aspx?source_page=fl_edit.aspx&work_id=" + hdfWorkId.Value + "&run_details=" + newRunDetails + "&project_id=" + currentProjectId.ToString();
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=1024, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FieldCureRecords", script, false);
        }



        protected void btnWetOutPrintCurrentOnClick(object sender, EventArgs e)
        {
            if (tbxWetOutDataTotalTube.Text != "")
            {
                // Store active tab for postback
                Session["activeTabFll"] = "5";
                Session["dialogOpenedFll"] = "1";
                Save2();

                // Open Dialog
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value);

                string script = "<script language='javascript'>";
                string url = "./fl_wetout_report.aspx?source_page=fl_edit.aspx&project_id=" + currentProjectId.ToString() + "&work_type=Full Length Lining&client_id=" + currentClientId.ToString() + "&section_id=" + hdfSectionId.Value;
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WetOutData", script, false);
            }
        }



        protected void btnInversionPrintCurrentOnClick(object sender, EventArgs e)
        {
            if (tbxInversionDataWaterChangesPerHour.Text != "")
            {
                // Store active tab for postback
                Session["activeTabFll"] = "5";
                Session["dialogOpenedFll"] = "1";
                Save2();

                // Open Dialog
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value);

                string script = "<script language='javascript'>";
                string url = "./fl_inversion_report.aspx?source_page=fl_edit.aspx&project_id=" + currentProjectId.ToString() + "&work_type=Full Length Lining&client_id=" + currentClientId.ToString() + "&section_id=" + hdfSectionId.Value;
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WetOutData", script, false);
            }
        }



        protected void btnWetOutCalculateOnClick(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            double pi = double.Parse(Decimal.Round(decimal.Parse(Math.PI.ToString()),4).ToString());
            double breakSize = 10; // in
            double factor1 = 0.99;
            double factor2 = 0.01;

            // ...Section values                       
            // ... ... tube size = confirmed Size
            Distance confirmedSizeDistance = new Distance(tbxConfirmedSize.Text);
            double confirmedSize = 0;
            string[] confirmedSizeString = confirmedSizeDistance.ToStringInEng1().Split('\"');

            if (!confirmedSizeDistance.ToStringInEng1().Contains("'"))
            {
                if (Validator.IsValidDouble(tbxConfirmedSize.Text))
                {
                    confirmedSize = double.Parse(tbxConfirmedSize.Text);
                }
                else
                {
                    confirmedSize = double.Parse(confirmedSizeString[0]);
                }
            }
            else
            {
                confirmedSize = Math.Ceiling(confirmedSizeDistance.ToDoubleInEng3() * 12);
            }

            // ... For Calculations                       
            // ... ... Validate setup data
            if ((ddlWetOutDataLinerTube.SelectedValue != "") && (ddlWetOutDataResins.SelectedValue != "-1") && (tbxWetOutDataExcessResin.Text != "") && (ddlWetOutDataPoundsDrums.SelectedValue != "(Select)") && (tbxWetOutDataDrumDiameter.Text != "") && (tbxWetOutDataHoistMaximumHeight.Text != "") && (tbxWetOutDataHoistMinimumHeight.Text != "") && (tbxWetOutDataDownDropTubeLength.Text != "") && (tbxWetOutDataPumpHeightAboveGround.Text != "") && (tbxWetOutDataTubeResinToFeltFactor.Text != ""))
            {
                // ... ... validate wet out data
                if ((ddlThickness.SelectedValue != "") && (tbxWetOutDataPlusExtra.Text != "") && (tbxWetOutDataForTurnOffset.Text != "") && (tbxWetOutDataExtraResinForMix.Text != "") && (ddlWetOutDataInversionType.SelectedValue != "(Select)") && (tbxWetOutDataDepthOfInversionMH.Text != "") && (tbxWetOutDataTubeForColumn.Text != "") && (tbxWetOutDataTubeForStartDry.Text != "") && (tbxWetOutDataRollerGap.Text != ""))
                {
                    // Lenght to line of all sections (sume of lenght of asset table)
                    string newRunDetails = "";
                    foreach (ListItem lst in cbxlSectionId.Items)
                    {
                        if (lst.Selected)
                        {
                            newRunDetails = newRunDetails + lst.Value + ">";
                        }
                    }
                    newRunDetails = newRunDetails.Substring(0, newRunDetails.Length - 1);
                    string[] runDetailsList = newRunDetails.Split('>');

                    double lengthToLine = 0d;
                    for (int i = 0; i < runDetailsList.Length; i++)
                    {
                        AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                        string sectionId = runDetailsList[i].ToString();
                        if (sectionId != "-1")
                        {
                            assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                            int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                            Distance lengthDistance = new Distance(assetSewerSectionGateway.GetLength(assetId));
                            lengthToLine = lengthToLine + lengthDistance.ToDoubleInEng3();
                        }
                    }
                    tbxWetOutDataLengthToLine.Text = decimal.Round(decimal.Parse(lengthToLine.ToString()), 1).ToString();
                    tbxInversionDataRunLength.Text = decimal.Round(decimal.Parse(lengthToLine.ToString()), 1).ToString(); 

                    // ... Inversion run details
                    for (int i = 0; i < runDetailsList.Length; i++)
                    {
                        cbxlInversionDataSectionId.Items.FindByValue(runDetailsList[i]).Selected = true;
                    }                  

                    // .. Resin Information
                    int resinId = Int32.Parse(ddlWetOutDataResins.SelectedValue);
                    WorkFullLengthLiningResinsGateway workFullLengthLiningResinsGateway = new WorkFullLengthLiningResinsGateway();
                    workFullLengthLiningResinsGateway.LoadByResinId(resinId, companyId);

                    string resinMake = workFullLengthLiningResinsGateway.GetResinMake(resinId);
                    string resinType = workFullLengthLiningResinsGateway.GetResinType(resinId);
                    string resinNumber = workFullLengthLiningResinsGateway.GetResinNumber(resinId);
                    double lbUsg = double.Parse(workFullLengthLiningResinsGateway.GetLbUsg(resinId).ToString());
                    int lbDrums = Int32.Parse(workFullLengthLiningResinsGateway.GetLbDrums(resinId).ToString());
                    double activeResin = double.Parse(workFullLengthLiningResinsGateway.GetActiveResin(resinId).ToString());
                    string applyCatalystTo = workFullLengthLiningResinsGateway.GetApplyCatalystTo(resinId);
                    double filter = double.Parse(workFullLengthLiningResinsGateway.GetFilter(resinId).ToString());

                    // ... Calculations                     
                    // ... ... LengthtToWetOut 
                    Double plusExtra = double.Parse(tbxWetOutDataPlusExtra.Text);
                    Double forTurnOffset = double.Parse(tbxWetOutDataForTurnOffset.Text);

                    Double lengthtToWetOut = lengthToLine + plusExtra + forTurnOffset;
                    tbxWetOutDataLengthtToWetOut.Text = decimal.Round(decimal.Parse(lengthtToWetOut.ToString()), 1).ToString();
                    tbxInversionDataWetOutLenght.Text = decimal.Round(decimal.Parse(lengthtToWetOut.ToString()), 1).ToString();

                    // ... ... Resin label
                    lblWetOutDataResinGray.Text = "RESIN: " + resinMake + resinType + resinNumber + ", " + lbUsg + "lbs/usg, " + activeResin.ToString() + " % Active Resin ";

                    // ... ... Lb drum label
                    lblWetOutDataLbDrumsGrey.Text = "For " + lbDrums.ToString() + " lb drums";

                    // ... ... Drum contains label  
                    // ... ... Drum Fill Height Information
                    double usgDrum = lbDrums / lbUsg;
                    double lbsPerUsg = lbUsg;
                    double lbsPerDrum = lbDrums;
                    double usgalsPerDrum = lbsPerDrum / lbsPerUsg;
                    double drumInsideDiameter = Double.Parse(tbxWetOutDataDrumDiameter.Text);
                    double drumInsideDiameterPow = Math.Pow(drumInsideDiameter, 2);
                    double usgalsPerDrumInch = (1 * (pi * drumInsideDiameterPow) / 4) * 0.004329;
                    double lbsPerDrumInch = usgalsPerDrumInch * lbsPerUsg;
                    double drumFillHeightShouldBeApprox = lbsPerDrum / lbsPerDrumInch;

                    if (ddlWetOutDataPoundsDrums.SelectedValue == "Pounds & Drums")  // OP 1
                    {
                        lblWetOutDataDrumContainsGray.Text = "Drum contains: " + lbDrums.ToString() + "lbs / " + Decimal.Round(decimal.Parse(usgDrum.ToString()), 1).ToString() + "usg.  Full drum level: Approx " + Decimal.Round(Decimal.Parse(drumFillHeightShouldBeApprox.ToString()), 1).ToString() + "ins.";
                    }
                    else
                    {
                        lblWetOutDataDrumContainsGray.Text = "-";
                    }

                    // ... ... Liner Tube
                    string linerTube = ddlWetOutDataLinerTube.SelectedValue;
                    double tubeThickness = Double.Parse(ddlThickness.SelectedValue);
                    lblWetOutDataLinerTubeGray.Text = "LINER TUBE: " + linerTube.ToString() + ", Inversion. Tube Size: " + confirmedSize.ToString() + " ins x " + tubeThickness.ToString() + " mm.";
                    tbxInversionDataLinerSize.Text = confirmedSize + " ins x " + tubeThickness + " mm";
                    lblInversionDataSubtitle.Text = ddlWetOutDataLinerTube.SelectedValue;

                    double maxCold = -1;
                    double maxColdExact = -1;
                    double maxColdRounded = -1;

                    double maxHot = -1;
                    double maxHotExact = -1;
                    double maxHotRounded = -1;

                    double idealHead = -1;
                    double idealHeadExact = -1;
                    double idealHeadRounded = -1;

                    switch (linerTube)
                    {
                        case "Applied Felts":
                            double sizeAppliedFelts = confirmedSize * 25.4;

                            // ...  ... For max cold                            
                            maxColdExact = (tubeThickness / sizeAppliedFelts) * 308 * 3.2808;
                            maxColdRounded = Double.Parse(Decimal.Round(Decimal.Parse(maxColdExact.ToString()), 1).ToString());
                            maxCold = maxColdRounded;

                            // ... ... For max hot                             
                            maxHotExact = (tubeThickness / sizeAppliedFelts) * 269 * 3.2808;
                            maxHotRounded = Double.Parse(Decimal.Round(Decimal.Parse(maxHotExact.ToString()), 1).ToString());
                            maxHot = maxHotRounded;

                            // ... ... For Idead head
                            double sizeToUseAppliedFelts = 0d;
                            if (confirmedSize > breakSize)
                            {
                                sizeToUseAppliedFelts = sizeAppliedFelts;
                            }
                            else
                            {
                                sizeToUseAppliedFelts = sizeAppliedFelts - 25;
                            }
                            idealHeadExact = (tubeThickness / sizeToUseAppliedFelts) * 201 * 3.2808;
                            idealHeadRounded = Double.Parse(Decimal.Round(Decimal.Parse(idealHeadExact.ToString()), 1).ToString());
                            idealHead = idealHeadRounded;
                            break;

                        case "Novapipe":
                            // ...  ... For max cold
                            maxColdExact = (39 * tubeThickness) / confirmedSize;
                            maxColdRounded = double.Parse(Decimal.Round(Decimal.Parse(maxColdExact.ToString()), 1).ToString());
                            maxCold = maxColdRounded;

                            // ... ... For max hot 
                            maxHotExact = (33.1 * tubeThickness) / confirmedSize;
                            maxHotRounded = Double.Parse(Decimal.Round(Decimal.Parse(maxHotExact.ToString()), 1).ToString());
                            maxHot = maxHotRounded;

                            // ... ... For Idead head
                            idealHeadExact = (25.76 * tubeThickness) / confirmedSize;
                            idealHeadRounded = Double.Parse(Decimal.Round(Decimal.Parse(idealHeadExact.ToString()), 1).ToString());
                            idealHead = idealHeadRounded;
                            break;

                        case "Liner Products":
                            // ...  ... For max cold
                            maxColdExact = (tubeThickness / confirmedSize) * 34.057;
                            maxColdRounded = double.Parse(Decimal.Round(Decimal.Parse(maxColdExact.ToString()), 1).ToString());
                            maxCold = maxColdRounded;

                            // ... ... For max hot 
                            maxHotExact = (tubeThickness / confirmedSize) * 28.381;
                            maxHotRounded = Double.Parse(Decimal.Round(Decimal.Parse(maxHotExact.ToString()), 1).ToString());
                            maxHot = maxHotRounded;

                            // ... ... For Idead head
                            idealHeadExact = (tubeThickness / confirmedSize) * 20.888;
                            idealHeadRounded = Double.Parse(Decimal.Round(Decimal.Parse(idealHeadExact.ToString()), 1).ToString());
                            idealHead = idealHeadRounded;
                            break;

                        case "Generic":
                            double sizeGeneric = confirmedSize * 25.4;

                            // ...  ... For max cold                            
                            maxColdExact = (tubeThickness / sizeGeneric) * 308 * 3.2808;
                            maxColdRounded = Double.Parse(Decimal.Round(Decimal.Parse(maxColdExact.ToString()), 1).ToString());
                            maxCold = maxColdRounded;

                            // ... ... For max hot                             
                            maxHotExact = (tubeThickness / sizeGeneric) * 269 * 3.2808;
                            maxHotRounded = Double.Parse(Decimal.Round(Decimal.Parse(maxHotExact.ToString()), 1).ToString());
                            maxHot = maxHotRounded;

                            // ... ... For Idead head
                            double sizeToUseGeneric = 0d;

                            if (confirmedSize > breakSize)
                            {
                                sizeToUseGeneric = sizeGeneric;
                            }
                            else
                            {
                                sizeToUseGeneric = sizeGeneric - 25;
                            }
                            idealHeadExact = (tubeThickness / sizeToUseGeneric) * 201 * 3.2808;
                            idealHeadRounded = Double.Parse(Decimal.Round(Decimal.Parse(idealHeadExact.ToString()), 1).ToString());
                            idealHead = idealHeadRounded;
                            break;

                        case "Tube 5 No Data":
                            // ...  ... For max cold
                            maxCold = -1;

                            // ... ... For max hot
                            maxHot = -1;

                            // ... ... For Idead head
                            idealHead = -1;
                            break;

                        case "Tube 6 No Data":
                            // ...  ... For max cold
                            maxCold = -1;

                            // ... ... For max hot
                            maxHot = -1;

                            // ... ... For Idead head
                            idealHead = -1;
                            break;
                    }

                    // ... ... .... Tube Max Cold Head, Tube Max Cold head PSI
                    if (maxCold != -1)
                    {
                        tbxWetOutDataTubeMaxColdHead.Text = maxCold.ToString();
                        double maxColdPsi = 0.434 * maxCold;
                        tbxWetOutDataTubeMaxColdHeadPSI.Text = decimal.Round(decimal.Parse(maxColdPsi.ToString()), 1).ToString();
                    }
                    else
                    {
                        tbxWetOutDataTubeMaxColdHead.Text = "NA";
                        tbxWetOutDataTubeMaxColdHeadPSI.Text = "NA";
                    }

                    // ... ... .... Tube Max Hot Head, Tube Max Hot Head PSI
                    if (maxHot != -1)
                    {
                        tbxWetOutDataTubeMaxHotHead.Text = maxHot.ToString();
                        double maxHotPsi = 0.434 * maxHot;
                        tbxWetOutDataTubeMaxHotHeadPSI.Text = decimal.Round(decimal.Parse(maxHotPsi.ToString()), 1).ToString();
                    }
                    else
                    {
                        tbxWetOutDataTubeMaxHotHead.Text = "NA";
                        tbxWetOutDataTubeMaxHotHeadPSI.Text = "NA";
                    }

                    // ... ... .... Tube Ideal Head, Tube Ideal Head PSI
                    if (idealHead != -1)
                    {
                        tbxWetOutDataTubeIdealHead.Text = idealHead.ToString();
                        double idealHeadPsi = 0.434 * idealHead;
                        tbxWetOutDataTubeIdealHeadPSI.Text = Decimal.Round(Decimal.Parse(idealHeadPsi.ToString()), 1).ToString();
                    }
                    else
                    {
                        tbxWetOutDataTubeIdealHead.Text = "NA";
                        tbxWetOutDataTubeIdealHeadPSI.Text = "NA";
                    }

                    // ... ... Net Resins
                    // ... ... ... For net resin for tube lbs ft(lbs/ft)
                    double lbsFt = 0d;
                    double usgFt = 0d;
                    double excessResin = Double.Parse(tbxWetOutDataExcessResin.Text)/100;
                    double tubeResinToFeltFactor = Double.Parse(tbxWetOutDataTubeResinToFeltFactor.Text);

                    switch (linerTube)
                    {
                        case "Applied Felts":
                            // ... ... .... For lbsFt
                            double fromSetUp = tubeResinToFeltFactor / 100;
                            double t = tubeThickness / 25.4;
                            double id = confirmedSize - 2 * t;
                            double area = pi * (Math.Pow(confirmedSize, 2) - Math.Pow(id, 2)) / 4;
                            double v1 = 12 * area * 0.004329;
                            double v2 = v1 * fromSetUp;
                            double v3 = v2 * excessResin;
                            double v4 = v3 + v2;
                            lbsFt = v4 * lbUsg;

                            // ... ... .... For usgFt
                            usgFt = v4;
                            break;

                        case "Novapipe":
                            // ... ... .... For lbsFt
                            double fromSetUpNovapipe = tubeResinToFeltFactor / 100;
                            double tNovapipe = tubeThickness / 25.4;
                            double idNovapipe = confirmedSize - 2 * tNovapipe;
                            double areaNovapipe = pi * (Math.Pow(confirmedSize, 2) - Math.Pow(idNovapipe, 2)) / 4;
                            double v1Novapipe = 12 * areaNovapipe * 0.004329;
                            double v2Novapipe = v1Novapipe * fromSetUpNovapipe;
                            double v3Novapipe = v2Novapipe * excessResin;
                            double v4Novapipe = v3Novapipe + v2Novapipe;
                            lbsFt = v4Novapipe * lbUsg;

                            // ... ... .... For usgFt
                            usgFt = v4Novapipe;
                            break;

                        case "Liner Products":
                            // ... ... .... For lbsFt
                            double lbft3 = lbUsg / 0.1337;
                            double specificGravity = double.Parse(decimal.Round(decimal.Parse((lbft3 / 62.4).ToString()), 3).ToString());
                            
                            double midCalc = 0d;
                            if (confirmedSize > 8)
                            {
                                midCalc = 261.5184;
                            }
                            else
                            {
                                midCalc = 217.932;
                            }

                            Decimal confirmedSizeDecimal = Decimal.Parse(confirmedSize.ToString());
                            Decimal firstDivision = confirmedSizeDecimal / 24;
                            Double firstDivisionDouble = Double.Parse(firstDivision.ToString());
                            double midCalc2 = RoundUp(firstDivisionDouble, 0);

                            Decimal secondDivision = confirmedSizeDecimal / 30;
                            double secondDivisionDouble = double.Parse(secondDivision.ToString());
                            double midCalc3 = RoundUp(secondDivisionDouble, 0);
                            double estimatedResinMultiplier = (((545.2 * (tubeThickness / 25.4) * ((((confirmedSize - 2 * (tubeThickness / 25.4)) * pi * 0.92) / pi) + (tubeThickness / 25.4)) + (midCalc * midCalc3 * ((tubeThickness - 3) / 25.4)) + (55.98 * midCalc2)) * specificGravity) / 453.59) * 0.92;                            

                            double excessResinAdded = excessResin * estimatedResinMultiplier;
                            lbsFt = excessResinAdded + estimatedResinMultiplier;

                            // ... ... .... For usgFt
                            double totalResin = excessResinAdded + estimatedResinMultiplier;
                            usgFt = totalResin / lbUsg;
                            break;

                        case "Generic":
                            // ... ... .... For lbsFt
                            double fromSetUpGeneric = tubeResinToFeltFactor / 100;
                            double tGeneric = tubeThickness / 25.4;
                            double idGeneric = confirmedSize - 2 * tGeneric;
                            double areaGeneric = pi * (Math.Pow(confirmedSize, 2) - Math.Pow(idGeneric, 2)) / 4;
                            double v1Generic = 12 * areaGeneric * 0.004329;
                            double v2Generic = v1Generic * fromSetUpGeneric;
                            double v3Generic = v2Generic * excessResin;
                            double v4Generic = v3Generic + v2Generic;
                            lbsFt = v4Generic * lbUsg;

                            // ... ... .... For usgFt
                            usgFt = v4Generic;
                            break;

                        case "Tube 5 No Data":
                            // ... ... .... For lbsFt
                            lbsFt = -1;

                            // ... ... .... For usgFt
                            usgFt = -1;
                            break;

                        case "Tube 6 No Data":
                            // ... ... .... For lbsFt
                            lbsFt = -1;

                            // ... ... .... For usgFt
                            usgFt = -1;
                            break;
                    }

                    double netResinForTubeLbsFt = Double.Parse(Decimal.Round(Decimal.Parse(lbsFt.ToString()), 2).ToString());
                    tbxWetOutDataNetResinForTubeLbsFt.Text = netResinForTubeLbsFt.ToString();

                    // ... ... ... For net resin for tube (lbs)
                    double netResinForTube = lengthtToWetOut * netResinForTubeLbsFt;
                    tbxWetOutDataNetResinForTube.Text = Decimal.Round(decimal.Parse(netResinForTube.ToString()), 0).ToString();

                    // ... ... ... For net resin for tube usg/ft (usg/ft)
                    double netResinForTubeUsgFt = Double.Parse(Decimal.Round(Decimal.Parse(usgFt.ToString()), 3).ToString());
                    tbxWetOutDataNetResinForTubeUsgFt.Text = netResinForTubeUsgFt.ToString();

                    // ... ... ... For net resin for tube (usgals)
                    double netResinForTubeUsgals = lengthtToWetOut * netResinForTubeUsgFt;
                    tbxWetOutDataNetResinForTubeUsgals.Text = Decimal.Round(decimal.Parse(netResinForTubeUsgals.ToString()), 1).ToString();

                    // ... ... ... For net resin for tube drums Ins
                    // ... ... ... .... Drum Fill Height Information   
                    double exactDrumsRequired = netResinForTube / lbDrums;
                    double rounddownToWholeDrums = RoundDown(exactDrumsRequired, 0);
                    double remainingPartDrum = exactDrumsRequired - rounddownToWholeDrums;
                    double fillHeight = drumFillHeightShouldBeApprox;
                    double remainingPartDrumInInches = fillHeight * remainingPartDrum;
                    double drumFillHeight = fillHeight;
                    double difference = drumFillHeight - remainingPartDrumInInches;

                    double drumsToUseInString = 0d;
                    if (remainingPartDrum > factor1)
                    {
                        drumsToUseInString = rounddownToWholeDrums + 1;
                    }
                    else
                    {
                        if (remainingPartDrum < factor2)
                        {
                            drumsToUseInString = rounddownToWholeDrums;
                        }
                        else
                        {
                            drumsToUseInString = rounddownToWholeDrums;
                        }
                    }

                    double inchesToUseInString = 0;
                    if (remainingPartDrum > factor1)
                    {
                        inchesToUseInString = 0;
                    }
                    else
                    {
                        if (remainingPartDrum < factor2)
                        {
                            inchesToUseInString = 0;
                        }
                        else
                        {
                            inchesToUseInString = remainingPartDrumInInches;
                        }
                    }

                    string stringForDrumInches = "= " + drumsToUseInString + " Drum + " + Decimal.Round(Decimal.Parse(inchesToUseInString.ToString()), 1).ToString() + " ins";
                    string stringForDrumsInches = "= " + drumsToUseInString + " Drums + " + Decimal.Round(Decimal.Parse(inchesToUseInString.ToString()), 1).ToString() + " ins";

                    string stringToCarry = "";
                    if (drumsToUseInString == 1)
                    {
                        stringToCarry = stringForDrumInches;
                    }
                    else
                    {
                        stringToCarry = stringForDrumsInches;
                    }
                    tbxWetOutDataNetResinForTubeDrumsIns.Text = stringToCarry.ToString();

                    // ... ... Newt resin label
                    lblWetOutDataNetResinGrey.Text = "Net resin is amount required in the tube after wet out complete and tube ready for installation. Includes excess at " + excessResin * 100 + "%";

                    // ... ... Extra lbs for Mix
                    double extraResinForMix = Double.Parse(tbxWetOutDataExtraResinForMix.Text);
                    double extraLbsForMix = netResinForTube * extraResinForMix/100;
                    tbxWetOutDataExtraLbsForMix.Text = Decimal.Round(decimal.Parse(extraLbsForMix.ToString()), 0).ToString();

                    // ... ... Total Mix Quantity
                    double totalMixQuantity = (1 + extraResinForMix / 100) * netResinForTube;
                    tbxWetOutDataTotalMixQuantity.Text = Decimal.Round(decimal.Parse(totalMixQuantity.ToString()), 0).ToString();

                    // .... ... Total Mix Quantity usgals
                    double totalMixQuantityUsgals = (1 + extraResinForMix / 100) * netResinForTubeUsgals;
                    tbxWetOutDataTotalMixQuantityUsgals.Text = Decimal.Round(decimal.Parse(totalMixQuantityUsgals.ToString()), 1).ToString(); ;

                    // ... ... Total Mix Quantity Drums Ins                    
                    if (ddlWetOutDataPoundsDrums.SelectedValue == "Pounds & Drums")  // OP 1
                    {
                        tbxWetOutDataTotalMixQuantityDrumsIns.Text = stringToCarry;
                    }
                    else
                    {
                        tbxWetOutDataTotalMixQuantityDrumsIns.Text = "-";
                    }

                    // ... ... Catalyst label
                    string catalystLabel = "";

                    if (applyCatalystTo == "Active Resin")
                    {
                        double activeResinVal = totalMixQuantity * activeResin/100;
                        double activeResinInDrum = lbsPerDrum * activeResin/100;
                        if (ddlWetOutDataPoundsDrums.SelectedValue == "Pounds & Drums")  // OP 1
                        {
                            catalystLabel = "Catalyst % applied to weight of Active Resin = " + decimal.Round(decimal.Parse(activeResinVal.ToString()), 0) + " lbs  (" + decimal.Round(decimal.Parse(activeResinInDrum.ToString()), 1).ToString() + " lbs per drum )";
                        }
                        else
                        {
                            catalystLabel = "Catalyst % applied to weight of Active Resin = " + decimal.Round(decimal.Parse(activeResinVal.ToString()), 0) + " lbs";
                        }
                    }
                    else
                    {
                        if (applyCatalystTo == "Active Resin & Filter")
                        {
                            if (ddlWetOutDataPoundsDrums.SelectedValue == "Pounds & Drums")  // OP 1
                            {
                                catalystLabel = "Catalyst % applied to weight of Active Resin and Filler = " + decimal.Round(decimal.Parse(totalMixQuantity.ToString()), 0).ToString() + " lbs (" + decimal.Round(decimal.Parse(lbsPerDrum.ToString()), 1).ToString() + " lbs per drum )";
                            }
                            else
                            {
                                catalystLabel = "Catalyst % applied to weight of Active Resin and Filler = " + decimal.Round(decimal.Parse(totalMixQuantity.ToString()), 0).ToString() + " lbs";
                            }
                        }
                        else
                        {
                            catalystLabel = "ERROR IN RESIN LIST ENTRY(S). CATALYST QTYS ARE INCORRECT!";
                        }
                    }

                    lblWetOutDataCatalystGrey.Text = catalystLabel;

                    // ... ... Total Tube
                    double tubeForColumn = Double.Parse(tbxWetOutDataTubeForColumn.Text);
                    double tubeForStartDry = Double.Parse(tbxWetOutDataTubeForStartDry.Text);
                    double totalTube = tubeForColumn + tubeForStartDry + lengthtToWetOut; ;
                    tbxWetOutDataTotalTube.Text = Decimal.Round(decimal.Parse(totalTube.ToString()), 1).ToString();

                    // ... ... Drop Tube Connects
                    string inversionType = ddlWetOutDataInversionType.SelectedValue;
                    double depthOfInversionMH = Double.Parse(tbxWetOutDataDepthOfInversionMH.Text);

                    if (inversionType == "Bottom")
                    {
                        if (depthOfInversionMH == tubeForColumn)
                        {
                            tbxWetOutDataDropTubeConnects.Text = "At MH lid";
                        }
                        else
                        {
                            if (depthOfInversionMH > tubeForColumn)
                            {
                                tbxWetOutDataDropTubeConnects.Text = "Below MH lid";
                            }
                            else
                            {
                                tbxWetOutDataDropTubeConnects.Text = "Above MH lid";
                            }
                        }
                    }
                    else
                    {
                        tbxWetOutDataDropTubeConnects.Text = "-";
                    }

                    // ... ... Allows Head To
                    double allowsToHeadTo = 0d;
                    double downDropTubeLength = Double.Parse(tbxWetOutDataDownDropTubeLength.Text);
                    if (inversionType == "Top")
                    {
                        allowsToHeadTo = tubeForColumn;
                        tbxWetOutDataAllowsHeadTo.Text = allowsToHeadTo.ToString();
                    }
                    else
                    {
                        if (inversionType == "Bottom")
                        {
                            allowsToHeadTo = tubeForColumn + downDropTubeLength;
                            tbxWetOutDataAllowsHeadTo.Text = allowsToHeadTo.ToString();
                        }
                        else
                        {
                            tbxWetOutDataAllowsHeadTo.Text = "NA";
                        }
                    }

                    // ... ... Height Needed
                    double heightNeeded = 0;
                    if (tbxWetOutDataAllowsHeadTo.Text != "NA")
                    {
                        heightNeeded = allowsToHeadTo - depthOfInversionMH;
                        tbxWetOutDataHeightNeeded.Text = heightNeeded.ToString();
                    }

                    // ... ... Available
                    double hoistMinimumHeight = Double.Parse(tbxWetOutDataHoistMinimumHeight.Text);
                    double hoistMaximunHeight = Double.Parse(tbxWetOutDataHoistMaximumHeight.Text);
                    tbxWetOutDataAvailable.Text = hoistMinimumHeight.ToString() + " ft to " + hoistMaximunHeight.ToString() + " ft";

                    // ... ... Hoist Height?
                    if (heightNeeded > hoistMaximunHeight)
                    {
                        tbxWetOutDataHoistHeight.Text = "Too High";
                    }
                    else
                    {
                        if (heightNeeded < hoistMinimumHeight)
                        {
                            tbxWetOutDataHoistHeight.Text = "Too Low";
                        }
                        else
                        {
                            tbxWetOutDataHoistHeight.Text = "OK";
                        }
                    }

                    // ... ... Warning
                    if ((tbxWetOutDataHoistHeight.Text == "OK") || (tbxWetOutDataHoistHeight.Text == ""))
                    {
                        lblWetOutDataWarning.Visible = false;
                    }
                    else
                    {
                        lblWetOutDataWarning.Visible = true;
                    }

                    // ... ... graphic labels
                    lblWetOutDataDimensionLabel.Text = confirmedSize + " ins x " + tubeThickness + " mm Tube";
                    lblWetOutDataTotalTubeLengthlabel.Text = "Total Tube Length " + tbxWetOutDataTotalTube.Text + " ft";
                    lblWetOutDataForColumnLabel.Text = tbxWetOutDataTubeForColumn.Text + " ft  for Column";
                    lblWetOutDataDryFtLabel.Text = "Dry " + tbxWetOutDataTubeForStartDry.Text + " ft";
                    lblWetOutDataWetOutLengthlabel.Text = "Wet-Out Length " + tbxWetOutDataLengthtToWetOut.Text + " ft";
                    lblWetOutDataDryFtEndLabel.Text = "Dry " + tbxWetOutDataTubeForColumn.Text + " ft";
                    lblWetOutDataTailEndlabel.Text = "Tail End";
                    lblWetOutDataColumnEndlabel.Text = "Column End";
                    lblWetOutDataRollerGapLabel.Text = "Roller Gap " + tbxWetOutDataRollerGap.Text + " mm";

                    // ... ... Inversion Liner Size
                    tbxInversionDataLinerSize.Text = confirmedSize + " ins x " + tubeThickness + " mm";
                                       
                    // ... ... Inversion Gray texts
                    lblInversionDataSubtitle.Text = "For: " + ddlWetOutDataLinerTube.SelectedValue;
                    lblInversionDataLinerInfoGrey.Text = linerTube + " tube with " + resinMake + " " + resinType + " " + resinNumber + " resin";
                    lblInversionDataHeadsGrey.Text = "Heads Ideal: " + tbxWetOutDataTubeIdealHead.Text + " ft (" + tbxWetOutDataTubeIdealHeadPSI.Text + ");  Max Hot: " + tbxWetOutDataTubeMaxHotHead.Text + " ft (" + tbxWetOutDataTubeMaxHotHeadPSI.Text + "psi);  Max Cold: " + tbxWetOutDataTubeMaxColdHead.Text + " ft (" + tbxWetOutDataTubeMaxColdHeadPSI.Text + ")";

                    // ... ... .... Validate data for calcs
                    if ((ddlInversionDataInversionPipeType.SelectedValue != "(Select)") && (ddlInversionDataPipeCondition.SelectedValue != "(Select)") && (ddlInversionDataGroundMoisture.SelectedValue != "(Select)") && (tbxInversionDataBoilerSize.Text != "") && (tbxInversionDataPumpsTotalCapacity.Text != "") && (tbxInversionDataLayflatSize.Text != "") && (tbxInversionDataLayflatQuantityTotal.Text != ""))
                    {
                        if ((tbxInversionDataWaterStartTempTs.Text != "") && (tbxInversionDataTempT1.Text != "") && (tbxInversionDataHoldAtT1For.Text != "") && (tbxInversionDataTempT2.Text != "") && (tbxInversionDataCookAtT2For.Text != "") && (tbxInversionDataCoolDownFor.Text != "") && (tbxInversionDataCoolToTemp.Text != "") && (tbxInversionDataDropInPipeRun.Text != ""))
                        {
                            // ... ... Inversion Pipe Slope Of
                            Decimal dropInPipeRun = Decimal.Parse(tbxInversionDataDropInPipeRun.Text);
                            Decimal pipeSlopeOf = Decimal.Round(dropInPipeRun, 1) / Decimal.Parse(lengthToLine.ToString())*100;
                            tbxInversionDataPipeSlopeOf.Text = Decimal.Round(decimal.Parse(pipeSlopeOf.ToString()), 2).ToString();

                            // ... ... Inversion 45F120F
                            double odsIns = confirmedSize;
                            double tIns = (tubeThickness / 25.4);
                            double inversionId = (odsIns - 2 * tIns);
                            lblInversionData45F120F.Text = tbxInversionDataWaterStartTempTs.Text + "°F-" + tbxInversionDataTempT1.Text + "°F (hr)";
                            
                            // ... ... Inversion Hold
                            tbxInversionDataHold.Text = Decimal.Round(decimal.Parse(tbxInversionDataHoldAtT1For.Text), 1).ToString();

                            // ... ... Inversion 120F185F
                            lblInversionData120F185F.Text = tbxInversionDataTempT1.Text + "°F-" + tbxInversionDataTempT2.Text + "°F (hr)"; 
                            double pipeTypeFactor = 0d;
                            string pipeType = ddlInversionDataInversionPipeType.SelectedValue;
                            if (pipeType == "Clay") pipeTypeFactor = 0.90;
                            if (pipeType == "Concrete") pipeTypeFactor = 0.80;
                            if (pipeType == "Brick") pipeTypeFactor = 1.00;

                            double pipeConditionFactor = 0d;
                            string pipeCondition = ddlInversionDataPipeCondition.SelectedValue;
                            if (pipeCondition == "Good") pipeConditionFactor = 1.00;
                            if (pipeCondition == "Fair") pipeConditionFactor = 0.90;
                            if (pipeCondition == "Poor") pipeConditionFactor = 0.80;
                            if (pipeCondition == "Badly Broken") pipeConditionFactor = 0.60;

                            double groundMoistureFactor = 0d;
                            string groundMoisture = ddlInversionDataGroundMoisture.SelectedValue;
                            if (groundMoisture == "Dry") groundMoistureFactor = 1.00;
                            if (groundMoisture == "Typical") groundMoistureFactor = 0.80;
                            if (groundMoisture == "Wet") groundMoistureFactor = 0.60;

                            double boilerSize = double.Parse(tbxInversionDataBoilerSize.Text);
                            double matFactorF1 = pipeTypeFactor;
                            double conditionFactorF2 = pipeConditionFactor;
                            double groundMoistureFactorF3 = groundMoistureFactor;
                            double overallFactorF3 = matFactorF1 * conditionFactorF2 * groundMoistureFactorF3;
                            double ianCorrectionFactor = 0.85;
                            double tubeMaxColdHead = double.Parse(tbxWetOutDataTubeMaxColdHead.Text);
                            double totalTubee = tubeMaxColdHead + lengthToLine;
                            double idForLinerFt = inversionId / 12;
                            double particalCalc = Math.Pow(idForLinerFt, 2);
                            double areaFt2 = (pi * particalCalc) / 4;
                            double ft3PerFt = areaFt2 * 1;
                            double usgPerFt = 7.481 * ft3PerFt;
                            double totalUsg = totalTubee * usgPerFt;
                            double cubFt = totalUsg / 7.481;
                            double punds = cubFt * 62.4;
                            double temp1 = double.Parse(tbxInversionDataTempT1.Text);
                            double temp2 = double.Parse(tbxInversionDataTempT2.Text);
                            double ts = double.Parse(tbxInversionDataWaterStartTempTs.Text);
                            double t1t2Btus = ((temp2 - temp1) * punds);
                            double netBtu = (ianCorrectionFactor * overallFactorF3 * boilerSize);
                            double timeHrs = (t1t2Btus / netBtu);
                            tbxInversionData120F185F.Text = Decimal.Round(decimal.Parse(timeHrs.ToString()), 1).ToString();

                            double tsT1Btus = (temp1 - ts) * punds;
                            double timeHrs1 = tsT1Btus / netBtu;
                            tbxInversionData45F120F.Text = Decimal.Round(decimal.Parse(timeHrs1.ToString()), 1).ToString();

                            // ... ... Inversion Cook Time                            
                            tbxInversionDataCookTime.Text = Decimal.Round(decimal.Parse(tbxInversionDataCookAtT2For.Text), 1).ToString(); ;

                            // ... ... Inversion Cool Time                            
                            tbxInversionDataCoolTime.Text = Decimal.Round(decimal.Parse(tbxInversionDataCoolDownFor.Text), 1).ToString();

                            // ... ... Inversion Aprox Total
                            double f45f120 = timeHrs1;
                            double hold = Double.Parse(tbxInversionDataHold.Text);
                            double f120f185 = timeHrs;
                            double cookTime = Double.Parse(tbxInversionDataCookTime.Text);
                            double coolTime = Double.Parse(tbxInversionDataCoolTime.Text);
                            tbxInversionDataAproxTotal.Text = Decimal.Round(decimal.Parse((f45f120 + hold + f120f185 + cookTime + coolTime).ToString()), 1).ToString();

                            // ... ... Inversion pumping circulation subtitle
                            double pumpsTotalCapacity = double.Parse(tbxInversionDataPumpsTotalCapacity.Text);
                            lblInversionDataPumpingCirculationSubtitle.Text = "Pumping and Circulation Parameters at " + tbxInversionDataPumpsTotalCapacity.Text + "usgpm (= " + (pumpsTotalCapacity * 60).ToString() + " usgph)";

                            // ... ... Inversion water changes per hour
                            double totalLinerInWaterCol = totalUsg;
                            double pumpsTotalCapacity60 = pumpsTotalCapacity * 60;
                            double changesPerHour = pumpsTotalCapacity60 / totalLinerInWaterCol;
                            decimal waterChangesPerHour = Decimal.Round(decimal.Parse(changesPerHour.ToString()), 2);
                            tbxInversionDataWaterChangesPerHour.Text = Decimal.Round(decimal.Parse(waterChangesPerHour.ToString()), 2).ToString();

                            // ... ... Inversion return water velocity
                            double layFlatQuantity = double.Parse(tbxInversionDataLayflatQuantityTotal.Text);
                            double layFlatSize = double.Parse(tbxInversionDataLayflatSize.Text);
                            double middleCalcEach = Math.Pow(layFlatSize, 2);
                            double areaLayFlatft2Each = ((pi * (middleCalcEach)) / 4) / 144;
                            double areaLayflatft2 = areaLayFlatft2Each * layFlatQuantity;
                            double qInCfs = pumpsTotalCapacity / 448.8;
                            double netQAreaFt2 = areaFt2 - areaLayflatft2;
                            double returnFlowArea = netQAreaFt2;
                            double returnsWaterVelocity = qInCfs / returnFlowArea;
                            tbxInversionDataReturnWaterVelocity.Text = Decimal.Round(decimal.Parse(returnsWaterVelocity.ToString()), 2).ToString();

                            // ... ... Inversion layflat back pressure
                            double c = 130;
                            double dFt = layFlatSize / 12;
                            double flowPerLayFlat = pumpsTotalCapacity / layFlatQuantity;
                            double qCfm = flowPerLayFlat * 0.1336;
                            double qCfs = qCfm / 60;
                            double middleCalcAreaIns2 = Math.Pow(layFlatSize, 2);
                            double areaIns2 = (pi * middleCalcAreaIns2) / 4;
                            double areaft2 = areaIns2 / 144;
                            double vFtS = qCfs / areaft2;
                            double wetOutLenght = double.Parse(tbxInversionDataWetOutLenght.Text);
                            double totalLfLength = tubeMaxColdHead + wetOutLenght;
                            double hfFtL = (Math.Pow((1.816 / c), 1.852) * ((totalLfLength / (Math.Pow(dFt, 1.167))) * Math.Pow(vFtS, 1.852)));
                            double hfPsiL = hfFtL * 0.4335;
                            double layFlatBackPressure = hfPsiL;
                            tbxInversionDataLayflatBackPressure.Text = Decimal.Round(decimal.Parse(layFlatBackPressure.ToString()), 1).ToString();

                            // ... ... Inversion pump lift at ideal head
                            double pumpHeightAboveGround = double.Parse(tbxWetOutDataPumpHeightAboveGround.Text);
                            double pumpFromInvert = pumpHeightAboveGround + depthOfInversionMH;
                            double lift = pumpFromInvert - idealHead;
                            double pumpLiftAtIdealHead = lift;
                            tbxInversionDataPumpLiftAtIdealHead.Text = Decimal.Round(decimal.Parse(pumpLiftAtIdealHead.ToString()), 1).ToString();

                            // ... ... Inversion water to fil liner column
                            double waterToFillLinerColumn = totalUsg;
                            tbxInversionDataWaterToFillLinerColumn.Text = Decimal.Round(decimal.Parse(waterToFillLinerColumn.ToString()), 0).ToString();

                            // ... ... Inversion water per ft
                            double waterPerFt = usgPerFt;
                            tbxInversionDataWaterPerFit.Text = Decimal.Round(decimal.Parse(waterPerFt.ToString()), 2).ToString();

                            // ... ... graphic labels
                            lblInversionDataMaxColdForTubeLabel.Text = tbxWetOutDataTubeMaxColdHead.Text + " ft = Max Cold for tube";
                            lblInversionDataMaxHotForTubeLabel.Text = tbxWetOutDataTubeMaxHotHead.Text + " ft = Max Hot for tube";
                            lblInversionDataIdelForTubeLabel.Text = tbxWetOutDataTubeIdealHead.Text + " ft = Ideal for tube";

                            double maxColdForTubeEnd = double.Parse(tbxWetOutDataTubeMaxColdHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                            lblInversionDataMaxColdForTubeEndLabel.Text = decimal.Round(decimal.Parse(maxColdForTubeEnd.ToString()), 1).ToString() + " ft";

                            double maxHotForTubeEnd = double.Parse(tbxWetOutDataTubeMaxHotHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                            lblInversionDataMaxHotForTubeEndLabel.Text = decimal.Round(decimal.Parse(maxHotForTubeEnd.ToString()), 1).ToString() + " ft";

                            double idealForTubeEnd = double.Parse(tbxWetOutDataTubeIdealHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                            lblInversionDataIdelForTubeEndLabel.Text = decimal.Round(decimal.Parse(idealForTubeEnd.ToString()), 1).ToString() + " ft";

                            lblInversionDataPumpHeightLabel.Text = "   " + tbxWetOutDataPumpHeightAboveGround.Text + " ft";
                            lblInversionDataLinerSizeLabel.Text = confirmedSize.ToString() + " ins x" + tubeThickness.ToString() + " Liner";

                            lblInversionDataRunLengthLabel.Text = "Run Length: " + tbxInversionDataRunLength.Text + " ft; Fall: " + tbxInversionDataDropInPipeRun.Text + " ft";
                            lblInversionDataDepthOfInversionMHLabel.Text = "   " + tbxWetOutDataDepthOfInversionMH.Text + " ft";
                            lblInversionDataEndLabel.Text = "End";
                        }
                    }
                }
            }
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
            Session["activeTabFll"] = "2";
            Session["dialogOpenedFll"] = "1";
            Save2();

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            string script = "<script language='javascript'>";
            string url = "./../Assets/asset_sewer_material.aspx?source_page=fl_edit.aspx&asset_id=" + hdfAssetId.Value + "&work_id=" + hdfWorkId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=490, height=540')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MaterialUpdate", script, false);
        }



        protected void grdLaterals_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            //{
            //    // For material
            //    Button btnMaterial = (Button)e.Row.FindControl("btnMaterial");
            //    btnMaterial.CommandName = "MaterialUpdate";
            //    btnMaterial.CommandArgument = e.Row.RowIndex.ToString();
            //}            
        }



        protected void grdLaterals_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Laterals Gridview, if the gridview is edition mode
            if (grdLaterals.EditIndex >= 0)
            {
                grdLaterals.UpdateRow(grdLaterals.EditIndex, true);
            }
        }



        protected void grdCatalysts_DataBound(object sender, EventArgs e)
        {
            AddCatalystsNewEmptyFix(grdCatalysts);
        }



        protected void grdCatalysts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Catalysts Gridview, if the gridview is edition mode
            if (grdCatalysts.EditIndex >= 0)
            {
                grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
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



        protected void cvPercentageByWeightFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int caTalystId = Int32.Parse(((DropDownList)grdCatalysts.FooterRow.FindControl("ddlNameFooter")).SelectedValue);

            if (caTalystId != -1)
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
            FullLengthLiningLateralDetails model = new FullLengthLiningLateralDetails(fullLengthLiningTDS);

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
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            FullLengthLiningLateralDetails flLateralDetails = new FullLengthLiningLateralDetails();
            flLateralDetails.LoadForEdit(workId, assetId, companyId, currentProjectId);
            
            if (flLateralDetails.Table.Rows.Count > 0)
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
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            string measuredFromMh = "";

            FullLengthLiningLateralDetails flLateralDetails = new FullLengthLiningLateralDetails();
            flLateralDetails.LoadForEdit(workId, assetId, companyId, currentProjectId);

            if (flLateralDetails.Table.Rows.Count > 0)
            {               
                measuredFromMh = "USMH";
            }
            else
            {
                measuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
            }

            // Generate increment
            FullLengthLiningLateralDetails fullLengthLiningLateraldetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);

            if (measuredFromMh == "USMH" || measuredFromMh == "")
            {
                if (fullLengthLiningLateraldetails.GetMaxLateralId2() == "A[") args.IsValid = false; else args.IsValid = true;

            }
            else
            {
                if (measuredFromMh == "DSMH")
                {
                    if (fullLengthLiningLateraldetails.GetMinLateralId2() == "@") args.IsValid = false; else args.IsValid = true;
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



        protected void cvSurfaceGrade_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (tkrdpM2DataM2Date.SelectedDate.HasValue)
            {
                if (ddlM2DataSurfaceGrade.SelectedValue == "(Select)")
                {
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Surface Grade (M2)";
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
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Requires Robotic Prep Date  (Prep Data)";
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



        protected void grdLaterals_DataBound(object sender, EventArgs e)
        {
            FlAddLateralsNewEmptyFix(grdLaterals);
        }



        protected void grdLaterals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int lateral = int.Parse(((Label)e.Row.FindControl("lblLateral")).Text);

                if (lateral > 0)
                {
                    FullLengthLiningLateralDetailsGateway gateway = new FullLengthLiningLateralDetailsGateway(fullLengthLiningTDS);
                    ((TextBox)e.Row.FindControl("tbxMaterial")).Text = gateway.GetMaterialType(lateral);
                }
            }
            
            // Control value for footer material
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
                    FullLengthLiningLateralDetailsGateway gateway = new FullLengthLiningLateralDetailsGateway(fullLengthLiningTDS);

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

            // Update distance from dsmh and reverse setup
            FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
            fullLengthLiningLateralDetails.UpdateLengthReverseSetup(workId, assetId, videoLength);

            // Store dataset
            Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

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

                    reverseSetup = GetDistance(reverseSetup);

                    ((TextBox)grdLaterals.Rows[i].Cells[2].FindControl("tbxReverseSetup")).Text = reverseSetup;
                }
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



        protected void ddlWetOutDataMadeBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWetOutDataMadeBy.SelectedValue != "(Select)")
            {
                int employeeId = Int32.Parse(ddlWetOutDataMadeBy.SelectedValue);
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId(employeeId);
                tbxInversionDataMadeBy.Text = employeeGateway.GetLastName(employeeId) + " " + employeeGateway.GetFirstName(employeeId);
            }
        }



        protected void ddlWetOutDataRunDetails2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxInversionDataRunDetails2.Text = "";
            if (ddlWetOutDataRunDetails2.SelectedValue != "(Select)")
            {
                tbxInversionDataRunDetails2.Text = ddlWetOutDataRunDetails2.SelectedValue;                
            }
        }



        protected void ddlThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxWetOutDataTubeThickness.Text = "";
            if (ddlThickness.SelectedValue != "")
            {
                tbxWetOutDataTubeThickness.Text = ddlThickness.SelectedValue;
            }
        }



        protected void ddlWetOutDataInversionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxWetOutDataDepthOfInversionMH.Text = "0";
            if (tbxM1DataUsmhDepth.Text != "")
            {
                if (ddlWetOutDataInversionType.SelectedValue == "Top")
                {                    
                    Distance usmhDepthDistance = new Distance(tbxM1DataUsmhDepth.Text);
                    tbxWetOutDataDepthOfInversionMH.Text = decimal.Round(decimal.Parse(usmhDepthDistance.ToStringInEng3()),1).ToString();                                    
                }
                else
                {
                    if (ddlWetOutDataInversionType.SelectedValue == "Bottom")
                    {
                        Distance dsmhDepthDistance = new Distance(tbxM1DataDsmhDepth.Text);
                        tbxWetOutDataDepthOfInversionMH.Text = decimal.Round(decimal.Parse(dsmhDepthDistance.ToStringInEng3()), 1).ToString();                                                                
                    }                
                }
            }
        }



        protected void tkrdpInstallDataInstallDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (tkrdpInstallDataInstallDate.SelectedDate.ToString() != "")
            {
                // Update wetout data
                DateTime? inversionDataInstalledOn = tkrdpInstallDataInstallDate.SelectedDate;
                DateTime installedOnDateTime = (DateTime)inversionDataInstalledOn;

                tbxWetOutDataInstallDate.Text = installedOnDateTime.Month.ToString() + "/" + installedOnDateTime.Day.ToString() + "/" + installedOnDateTime.Year.ToString();
                tbxInversionDataInstalledOn.Text = installedOnDateTime.Month.ToString() + "/" + installedOnDateTime.Day.ToString() + "/" + installedOnDateTime.Year.ToString();

                // Update generalTab
                tkrdpGeneralInstallDate.SelectedDate = tkrdpInstallDataInstallDate.SelectedDate;
            }
        }



        protected void tkrdptkrdpGeneralInstallDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update installTab
            tkrdpInstallDataInstallDate.SelectedDate = tkrdpGeneralInstallDate.SelectedDate;

            // Update wetout data
            DateTime? inversionDataInstalledOn = tkrdpInstallDataInstallDate.SelectedDate;
            DateTime installedOnDateTime = (DateTime)inversionDataInstalledOn;

            tbxWetOutDataInstallDate.Text = installedOnDateTime.Month.ToString() + "/" + installedOnDateTime.Day.ToString() + "/" + installedOnDateTime.Year.ToString();
            tbxInversionDataInstalledOn.Text = installedOnDateTime.Month.ToString() + "/" + installedOnDateTime.Day.ToString() + "/" + installedOnDateTime.Year.ToString();
        }



        protected void tkrdpGeneralP1Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update prep data tab
            tkrdpPrepDataP1Date.SelectedDate = tkrdpGeneralP1Date.SelectedDate;
        }



        protected void tkrdpGeneralM1Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update m1 tab
            tkrdpM1DataM1Date.SelectedDate = tkrdpGeneralM1Date.SelectedDate;
        }



        protected void tkrdpGeneralFinalVideo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update install tab
            tkrdpInstallDataFinalVideoDate.SelectedDate = tkrdpGeneralFinalVideo.SelectedDate;
        }



        protected void tkrdpGeneralM2Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update m2 tab
            tkrdpM2DataM2Date.SelectedDate = tkrdpGeneralM2Date.SelectedDate;
        }



        protected void tkrdpPrepDataP1Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update general tab
            tkrdpGeneralP1Date.SelectedDate = tkrdpPrepDataP1Date.SelectedDate;
        }



        protected void tkrdpM1DataM1Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update general tab
            tkrdpGeneralM1Date.SelectedDate = tkrdpM1DataM1Date.SelectedDate;
        }
        


        protected void tkrdpM2DataM2Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update general tab
            tkrdpGeneralM2Date.SelectedDate = tkrdpM2DataM2Date.SelectedDate;
        }



        protected void tkrdpInstallDataFinalVideoDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // Update install tab
            tkrdpGeneralFinalVideo.SelectedDate = tkrdpInstallDataFinalVideoDate.SelectedDate ;
        }
       


        protected void WetOutDataInversionVisibleInformation_OnCheckedChanged(object sender, EventArgs e)
        {
            if (ckbxWetOutDataIncludeWetOutInformation.Checked)
            {
                pnlVisibleInformation.Visible = true;
                upnlVisibleInformation.Update();

                // ... Tube Thickness
                tbxWetOutDataTubeThickness.Text = "";
                if (ddlThickness.SelectedValue != "")
                {
                    tbxWetOutDataTubeThickness.Text = ddlThickness.SelectedValue;
                }

                // ... verify inversion tab
                if (ckbxInversionDataIncludeInversionInformation.Checked)
                {
                    lblInversionDataInversionMissingData.Visible = false;
                    uplInversionDataInversionMissingData.Update();
                    pnlInversionVisibleInformation.Visible = true;
                    upnlInversionVisibleInformation.Update();
                }
            }
            else
            {
                pnlVisibleInformation.Visible = false;                
                upnlVisibleInformation.Update();  
              
                // ... verify inversion tab
                if (ckbxInversionDataIncludeInversionInformation.Checked)
                {
                    lblInversionDataInversionMissingData.Visible = true;
                    uplInversionDataInversionMissingData.Update();
                    pnlInversionVisibleInformation.Visible = false;
                    upnlInversionVisibleInformation.Update();
                }
            }
        }



        protected void InversionDataInversionVisibleInformation_OnCheckedChanged(object sender, EventArgs e)
        {
            if (ckbxWetOutDataIncludeWetOutInformation.Checked)
            {                
                if (ckbxInversionDataIncludeInversionInformation.Checked)
                {
                    lblInversionDataInversionMissingData.Visible = false;
                    uplInversionDataInversionMissingData.Update();
                    pnlInversionVisibleInformation.Visible = true;
                    upnlInversionVisibleInformation.Update();
                }
                else
                {
                    lblInversionDataInversionMissingData.Visible = false;
                    uplInversionDataInversionMissingData.Update();
                    pnlInversionVisibleInformation.Visible = false;
                    upnlInversionVisibleInformation.Update();
                }
            }
            else
            {
                if (ckbxInversionDataIncludeInversionInformation.Checked)
                {
                    lblInversionDataInversionMissingData.Visible = true;
                    uplInversionDataInversionMissingData.Update();
                    pnlInversionVisibleInformation.Visible = false;
                    upnlInversionVisibleInformation.Update();
                }
                else
                {
                    lblInversionDataInversionMissingData.Visible = false;
                    uplInversionDataInversionMissingData.Update();
                    pnlInversionVisibleInformation.Visible = false;
                    upnlInversionVisibleInformation.Update();
                }
            }
        }

        
        
        protected void tbxPercentageByWeightEdit_TextChanged(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int catalystId = Int32.Parse(((Label)grdCatalysts.Rows[grdCatalysts.EditIndex].Cells[2].FindControl("lblCatalystIdEdit")).Text);
            double percentageByWeight = Double.Parse(((TextBox)grdCatalysts.Rows[grdCatalysts.EditIndex].Cells[3].FindControl("tbxPercentageByWeightEdit")).Text);                   

            if (catalystId != -1)
            {
                // .. Resin Information
                if ((ddlWetOutDataResins.SelectedValue != "-1") && (ddlWetOutDataPoundsDrums.SelectedValue != "(Select)"))
                {
                    int resinId = Int32.Parse(ddlWetOutDataResins.SelectedValue);
                    WorkFullLengthLiningResinsGateway workFullLengthLiningResinsGateway = new WorkFullLengthLiningResinsGateway();
                    workFullLengthLiningResinsGateway.LoadByResinId(resinId, companyId);

                    int lbDrums = Int32.Parse(workFullLengthLiningResinsGateway.GetLbDrums(resinId).ToString());
                    double activeResin = double.Parse(workFullLengthLiningResinsGateway.GetActiveResin(resinId).ToString()) / 100;
                    string applyCatalystTo = workFullLengthLiningResinsGateway.GetApplyCatalystTo(resinId);
                    
                    // Calc  the other columms
                    // ... ... For Mix Quantity
                    string forMixQuantity = "";
                    if (percentageByWeight.ToString() == "-1")
                    {
                        forMixQuantity = "-";
                    }
                    else
                    {
                        double totalMixQuantity = double.Parse(tbxWetOutDataTotalMixQuantity.Text);
                        double catalyse = 0d;
                        if (applyCatalystTo == "(Select)")
                        {
                            catalyse = -1;
                        }
                        else
                        {
                            if (applyCatalystTo == "Active Resin & Filter")
                            {
                                catalyse = 1;
                            }
                            else
                            {
                                catalyse = activeResin;
                            }
                        }

                        if (catalyse != -1)
                        {
                            double pureResin = totalMixQuantity * catalyse;
                            forMixQuantity = (pureResin * totalMixQuantity / 100).ToString();
                            ((Label)grdCatalysts.Rows[grdCatalysts.EditIndex].Cells[4].FindControl("lblLbsForMixQuantityEdit")).Text = forMixQuantity; ;                             
                        }
                        else
                        {
                            ((Label)grdCatalysts.Rows[grdCatalysts.EditIndex].Cells[4].FindControl("lblLbsForMixQuantityEdit")).Text = "ERROR";
                        }
                    }
                    
                    // ... ... For Lbs For Drums
                    string firstPart = "";
                    double percentageToCatalyse = -1;
                    if (ddlWetOutDataPoundsDrums.SelectedValue == "Pounds & Drums")  // OP 1
                    {
                        if (percentageByWeight == -1)
                        {
                            firstPart = "-";
                        }
                        else
                        {
                            if (applyCatalystTo == "(Select)")
                            {
                                percentageToCatalyse = -1;
                            }
                            else
                            {
                                if (applyCatalystTo == "Active Resin & Filter")
                                {
                                    percentageToCatalyse = 1;
                                }
                                else
                                {
                                    percentageToCatalyse = activeResin;
                                }
                            }

                            if (percentageToCatalyse != -1)
                            {
                                double drumRes = lbDrums * percentageToCatalyse;
                                double catalystPerDrum = drumRes * percentageByWeight / 100;
                                firstPart = catalystPerDrum.ToString();
                            }
                            else
                            {
                                firstPart = "ERROR";
                            }

                        }
                    }
                    else
                    {
                        firstPart = "-";
                    }

                    string secondPart = "";
                    if (ddlWetOutDataPoundsDrums.SelectedValue == "Pounds & Drums")  // OP 1
                    {
                        if (percentageByWeight == -1)
                        {
                            secondPart = "-";
                        }
                        else
                        {
                            double drumRes = lbDrums * percentageToCatalyse;
                            double catalystPerDrum = drumRes * percentageByWeight / 100;
                            double roundUp = RoundUp(catalystPerDrum, 0);
                            string upDown = "";
                            if ((roundUp - catalystPerDrum) > 0.05)
                            {
                                upDown = "Down";
                            }
                            else
                            {
                                upDown = "Up";
                            }

                            double fulllbs = 0d;
                            if (upDown == "Up")
                            {
                                fulllbs = roundUp;
                            }
                            else
                            {
                                double roundDown = RoundDown(catalystPerDrum, 0);
                                fulllbs = roundDown;
                            }

                            double partLbs = 0d;
                            if (upDown == "Up")
                            {
                                partLbs = 0;
                            }
                            else
                            {
                                partLbs = catalystPerDrum - fulllbs;
                            }
                            double ozes = double.Parse(decimal.Round(decimal.Parse(partLbs.ToString()) * 16, 0).ToString());
                            string lbOzes = " = (" + fulllbs.ToString() + " lbs + " + ozes.ToString() + " oz) per drum";
                            secondPart = lbOzes;
                        }
                    }
                    else
                    {
                        secondPart = "-";
                    }

                    ((Label)grdCatalysts.Rows[grdCatalysts.EditIndex].Cells[4].FindControl("lblLbsForDrumEdit")).Text = firstPart + "lb/Drum " + secondPart;
                }
            }
        }



        protected void ddlNameFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int catalystId = Int32.Parse(((DropDownList)grdCatalysts.FooterRow.FindControl("ddlNameFooter")).SelectedValue);

            if (catalystId != -1)
            {
                // Load catalyst data
                WorkFullLengthLiningCatalystsGateway workFullLengthLiningCatalystsGateway = new WorkFullLengthLiningCatalystsGateway();
                workFullLengthLiningCatalystsGateway.LoadByCatalystId(catalystId, companyId);

                double defaultPercentageByWeight = double.Parse(decimal.Round(decimal.Parse(workFullLengthLiningCatalystsGateway.GetDefaultPercentageByWeight(catalystId).ToString()), 2).ToString());

                // .. Resin Information
                if ((ddlWetOutDataResins.SelectedValue != "-1") && (ddlWetOutDataPoundsDrums.SelectedValue != "(Select)") && (tbxWetOutDataTotalMixQuantity.Text != ""))
                {
                    int resinId = Int32.Parse(ddlWetOutDataResins.SelectedValue);
                    WorkFullLengthLiningResinsGateway workFullLengthLiningResinsGateway = new WorkFullLengthLiningResinsGateway();
                    workFullLengthLiningResinsGateway.LoadByResinId(resinId, companyId);

                    int lbDrums = Int32.Parse(workFullLengthLiningResinsGateway.GetLbDrums(resinId).ToString());
                    double activeResin = double.Parse(workFullLengthLiningResinsGateway.GetActiveResin(resinId).ToString()) / 100;
                    string applyCatalystTo = workFullLengthLiningResinsGateway.GetApplyCatalystTo(resinId);
                    
                    // Set data to grid
                    ((TextBox)grdCatalysts.FooterRow.FindControl("tbxPercentageByWeightFooter")).Text = defaultPercentageByWeight.ToString();

                    // Calc  the other columms
                    // ... ... For Mix Quantity
                    string forMixQuantity = "";
                    if (defaultPercentageByWeight.ToString() == "-1")
                    {
                        forMixQuantity = "-";
                    }
                    else
                    {
                        double totalMixQuantity = double.Parse(tbxWetOutDataTotalMixQuantity.Text);
                        double catalyse = 0d;
                        if (applyCatalystTo == "(Select)")
                        {
                            catalyse = -1;
                        }
                        else
                        {
                            if (applyCatalystTo == "Active Resin & Filter")
                            {
                                catalyse = 1;
                            }
                            else
                            {
                                catalyse = activeResin;
                            }
                        }

                        if (catalyse != -1)
                        {
                            double pureResin = totalMixQuantity * catalyse;
                            decimal forMixQuantityDecimal = decimal.Parse((pureResin * (defaultPercentageByWeight) / 100).ToString());
                            forMixQuantity = decimal.Round(forMixQuantityDecimal,2).ToString();
                            ((Label)grdCatalysts.FooterRow.FindControl("lblLbsForMixQuantityFooter")).Text = forMixQuantity;
                        }
                        else
                        {
                            ((Label)grdCatalysts.FooterRow.FindControl("lblLbsForMixQuantityFooter")).Text = "ERROR";
                        }
                    }

                    // ... ... For Lbs For Drums
                    string firstPart = "";
                    double percentageToCatalyse = -1;
                    if (ddlWetOutDataPoundsDrums.SelectedValue == "Pounds & Drums")  // OP 1
                    {
                        if (defaultPercentageByWeight == -1)
                        {
                            firstPart = "-";
                        }
                        else
                        {
                            if (applyCatalystTo == "(Select)")
                            {
                                percentageToCatalyse = -1;
                            }
                            else
                            {
                                if (applyCatalystTo == "Active Resin & Filter")
                                {
                                    percentageToCatalyse = 1;
                                }
                                else
                                {
                                    percentageToCatalyse = activeResin;
                                }
                            }

                            if (percentageToCatalyse != -1)
                            {
                                double drumRes = lbDrums * percentageToCatalyse;
                                double catalystPerDrum = drumRes * defaultPercentageByWeight / 100;
                                decimal catalystPerDrumDecimal = Decimal.Parse(catalystPerDrum.ToString());

                                catalystPerDrumDecimal = decimal.Round(catalystPerDrumDecimal,2);
                                firstPart = catalystPerDrumDecimal.ToString();
                            }
                            else
                            {
                                firstPart = "ERROR";
                            }
                        }
                    }
                    else
                    {
                        firstPart = "-";
                    }

                    string secondPart = "";
                    if (ddlWetOutDataPoundsDrums.SelectedValue == "Pounds & Drums")  // OP 1
                    {
                        if (defaultPercentageByWeight == -1)
                        {
                            secondPart = "-";
                        }
                        else
                        {
                            double drumRes = lbDrums * percentageToCatalyse;
                            double catalystPerDrum = drumRes * defaultPercentageByWeight / 100;
                            double roundUp = RoundUp(catalystPerDrum, 0);
                            string upDown = "";
                            if ((roundUp - catalystPerDrum) > 0.05)
                            {
                                upDown = "Down";
                            }
                            else
                            {
                                upDown = "Up";
                            }

                            double fulllbs = 0d;
                            if (upDown == "Up")
                            {
                                fulllbs = roundUp;
                            }
                            else
                            {
                                double roundDown = RoundDown(catalystPerDrum, 0);
                                fulllbs = roundDown;
                            }

                            double partLbs = 0d;
                            if (upDown == "Up")
                            {
                                partLbs = 0;
                            }
                            else
                            {
                                partLbs = catalystPerDrum - fulllbs;
                            }
                            double ozes = double.Parse(decimal.Round(decimal.Parse(partLbs.ToString()) * 16, 0).ToString());
                            string lbOzes = " = (" + fulllbs.ToString() + " lbs + " + ozes.ToString() + " oz) per drum";
                            secondPart = lbOzes;
                        }
                    }
                    else
                    {
                        secondPart = "-";
                    }

                    ((Label)grdCatalysts.FooterRow.FindControl("lblLbsForDrumFooter")).Text = firstPart + "lb/Drum " + secondPart;

                    // Addition is available
                    ((ImageButton)grdCatalysts.FooterRow.FindControl("ibtnAdd")).Visible = true;
                }
                else
                {
                    // Addition is not available
                    ((ImageButton)grdCatalysts.FooterRow.FindControl("ibtnAdd")).Visible = false;
                }
            }
        }

        
        

         
                       
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=fl_edit.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabFll"] = "0";
            Session["dialogOpenedFll"] = "0";

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
                    fullLengthLiningTDS.RejectChanges();
                    Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                    if (Request.QueryString["source_page"] == "fl_navigator2.aspx")
                    {
                        url = "./fl_navigator2.aspx?source_page=fl_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                    }

                    if (Request.QueryString["source_page"] == "fl_summary.aspx")
                    {
                        url = "./fl_summary.aspx?source_page=fl_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes" + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab;
                    }
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = FlNavigator.GetPreviousId((FlNavigatorTDS)Session["flNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (previousId != Int32.Parse(hdfAssetId.Value))
                    {
                        if (this.Apply())
                        {
                            // Redirect
                            url = "./fl_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                        }
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = FlNavigator.GetNextId((FlNavigatorTDS)Session["flNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (nextId != Int32.Parse(hdfAssetId.Value))
                    {
                        if (this.Apply())
                        {
                            // Redirect
                            url = "./fl_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
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
            Session["activeTabFll"] = "0";
            Session["dialogOpenedFll"] = "0";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./fl_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public FullLengthLiningTDS.LateralDetailsDataTable GetLateralDetails()
        {
            flAddLateralsNewDetails = (FullLengthLiningTDS.LateralDetailsDataTable)Session["flAddLateralsNewDummy"];
            if (flAddLateralsNewDetails == null)
            {
                flAddLateralsNewDetails = ((FullLengthLiningTDS)Session["fullLengthLiningTDS"]).LateralDetails;
            }

            return flAddLateralsNewDetails;
        }



        public void DummyFlAddLateralsNew(int Lateral, int original_Lateral)
        {
        }



        public void DummyFlAddLateralsNew(int original_Lateral)
        {
        }



        public FullLengthLiningTDS.WetOutCatalystsDetailsDataTable GetCatalystsNew()
        {
            wetOutCatalystsDetails = (FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)Session["wetOutCatalystsDetailsDummy"];
            if (wetOutCatalystsDetails == null)
            {
                wetOutCatalystsDetails = ((FullLengthLiningTDS)Session["fullLengthLiningTDS"]).WetOutCatalystsDetails;
            }

            return wetOutCatalystsDetails;
        }



        public void DummyCatalystsNew(int WorkID, int RefID)
        {
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var tbxLengthId = '" + tbxSteelTapeLength.ClientID + "';";
            contentVariables += "var tbxM1DataSteelTapeThroughSewerId = '" + tbxM1DataSteelTapeThroughSewer.ClientID + "';";
            contentVariables += "var tkrdpGeneralP1DateId = '" + tkrdpGeneralP1Date.ClientID + "';";
            contentVariables += "var tkrdpPrepDataP1DateId = '" + tkrdpPrepDataP1Date.ClientID + "';";
            contentVariables += "var tkrdpGeneralM1DateId = '" + tkrdpGeneralM1Date.ClientID + "';";
            contentVariables += "var tkrdpM1DataM1DateId = '" + tkrdpM1DataM1Date.ClientID + "';";
            contentVariables += "var tkrdpGeneralM2DateId = '" + tkrdpGeneralM2Date.ClientID + "';";
            contentVariables += "var tkrdpM2DataM2DateId = '" + tkrdpM2DataM2Date.ClientID + "';";
            contentVariables += "var tkrdpGeneralInstallDateId = '" + tkrdpGeneralInstallDate.ClientID + "';";
            contentVariables += "var tkrdpInstallDataInstallDateId = '" + tkrdpInstallDataInstallDate.ClientID + "';";
            contentVariables += "var tkrdpGeneralFinalVideoId = '" + tkrdpGeneralFinalVideo.ClientID + "';";
            contentVariables += "var tkrdpInstallDataFinalVideoDateId = '" + tkrdpInstallDataFinalVideoDate.ClientID + "';";
            contentVariables += "var hdfAssetIdId = '" + hdfAssetId.ClientID + "';";
            contentVariables += "var hdfWorkIdId = '" + hdfWorkId.ClientID + "';";
            contentVariables += "var hdfWorkTypeId = '" + hdfWorkType.ClientID + "';";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var grdLateralsId = '" + grdLaterals.ClientID + "';";
            contentVariables += "var tbxConfirmedSizeId = '" + tbxConfirmedSize.ClientID + "';";
            contentVariables += "var ddlThicknessId = '" + ddlThickness.ClientID + "';";
            contentVariables += "var ckbxWetOutDataIncludeWetOutInformationId = '" + ckbxWetOutDataIncludeWetOutInformation.ClientID + "';";
            contentVariables += "var ckbxInversionDataIncludeInversionInformationId = '" + ckbxInversionDataIncludeInversionInformation.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';";  
                                    
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./fl_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_sub_area=" + Request.QueryString["search_sub_area"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        protected void FlAddLateralsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                FullLengthLiningTDS.LateralDetailsDataTable dt = new FullLengthLiningTDS.LateralDetailsDataTable();
                int companyId = Int32.Parse(hdfCompanyId.Value);
                dt.AddLateralDetailsRow(-1, "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", false, companyId, false, false, false, false, false, "", false, "", "", "", "", DateTime.Now, false, DateTime.Now, false, false, false, "", false, DateTime.Now, "");
                Session["flAddLateralsNewDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                FullLengthLiningTDS.LateralDetailsDataTable dt = (FullLengthLiningTDS.LateralDetailsDataTable)Session["flAddLateralsNewDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCatalystsNewEmptyFix(GridView grdCatalysts)
        {
            if (grdCatalysts.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                FullLengthLiningTDS.WetOutCatalystsDetailsDataTable dt = new FullLengthLiningTDS.WetOutCatalystsDetailsDataTable();
                dt.AddWetOutCatalystsDetailsRow(-1, -1, -1, "", -1, -1, "", false, companyId, false);
                Session["wetOutCatalystsDetailsDummy"] = dt;

                grdCatalysts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCatalysts.Rows.Count == 1)
            {
                FullLengthLiningTDS.WetOutCatalystsDetailsDataTable dt = (FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)Session["wetOutCatalystsDetailsDummy"];
                if (dt != null)
                {
                    grdCatalysts.Rows[0].Visible = false;
                    grdCatalysts.Rows[0].Controls.Clear();
                }
            }
        }



        protected string GetDistance(object distance)
        {
            if (distance != DBNull.Value)
            {
                Distance distanceInch = new Distance(distance.ToString());
                return distanceInch.ToStringInEng1();                    
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



        private void GrdFLAddLateralsNewAdd()
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

                    bool inProject = ((CheckBox)grdLaterals.FooterRow.FindControl("cbxInProject")).Checked;
                    int workId = Int32.Parse(hdfWorkId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string lateralId = GetLateralIdIncrement();
                    string clientLateralId = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewClientLateralId")).Text.Trim();
                    string connectionType = ""; connectionType = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewConnectionType")).SelectedValue;
                    string mn = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewMn")).Text.Trim();
                    string clientInspectionNo = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewClientInspectionNo")).Text.Trim();
                    DateTime? v1Inspection = null;
                    bool requiresRoboticPrep = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxRequiresRoboticPrepNew")).Checked;
                    DateTime? requiresRoboticPrepDate = null;
                    if (((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpRequiresRoboticPrepDateNew")).SelectedDate.HasValue)
                    {
                        requiresRoboticPrepDate = ((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpRequiresRoboticPrepDateNew")).SelectedDate.Value;
                    }

                    bool holdClientIssue = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxHoldClientIssueNew")).Checked;
                    bool holdLFSIssue = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxHoldLFSIssueNew")).Checked;
                    bool lineLateral = ((CheckBox)grdLaterals.FooterRow.FindControl("cbxNewJl")).Checked;
                    string flange = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlFlangeNew")).SelectedValue;
                    bool dyeTestReq = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxDyeTestReqNew")).Checked;
                    DateTime? dyeTestComplete = null; if (((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpDyeTestCompleteNew")).SelectedDate.HasValue) dyeTestComplete = ((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpDyeTestCompleteNew")).SelectedDate.Value;

                    // Insert
                    FullLengthLiningLateralDetails model = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                    model.Insert(videoDistance, clockPosition, distanceToCentre, timeOpened, reverseSetup, reinstate, comments, lateralId, size, material, false, companyId, inProject, live, clientLateralId, connectionType, mn, clientInspectionNo, v1Inspection, requiresRoboticPrep, requiresRoboticPrepDate, holdClientIssue, holdLFSIssue, lineLateral, flange, lineLateral, dyeTestReq, dyeTestComplete);

                    // Store datasets
                    Session.Remove("flAddLateralsNewDummy");
                    Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                    grdLaterals.DataBind();
                    grdLaterals.PageIndex = grdLaterals.PageCount - 1;

                    tbxLaterals.Text = model.GetTotalLaterals().ToString();
                    tbxLiveLaterals.Text = model.GetLiveLaterals().ToString();
                }
            }
        }



        private void GrdCatalystsAdd()
        {
            if (ValidateCatalystsFooter())
            {
                Page.Validate("catalystDataFooter");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    bool inDatabase = false;
                    bool deleted = false;
                    int workId = Int32.Parse(hdfWorkId.Value);
                    
                    int catalystId = Int32.Parse(((DropDownList)grdCatalysts.FooterRow.FindControl("ddlNameFooter")).SelectedValue);
                    
                    decimal percentageByWeight = -1;
                    if (((TextBox)grdCatalysts.FooterRow.FindControl("tbxPercentageByWeightFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdCatalysts.FooterRow.FindControl("tbxPercentageByWeightFooter")).Text.Trim())))
                        {
                            percentageByWeight = decimal.Round(decimal.Parse(((TextBox)grdCatalysts.FooterRow.FindControl("tbxPercentageByWeightFooter")).Text.Trim()), 2);
                        }
                    }
                    
                    decimal lbsForMixQuantity = -1;
                    if (((Label)grdCatalysts.FooterRow.FindControl("lblLbsForMixQuantityFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((Label)grdCatalysts.FooterRow.FindControl("lblLbsForMixQuantityFooter")).Text.Trim())))
                        {
                            lbsForMixQuantity = decimal.Round(decimal.Parse(((Label)grdCatalysts.FooterRow.FindControl("lblLbsForMixQuantityFooter")).Text.Trim()), 2);
                        }
                    }

                    string lbsForDrum = ((Label)grdCatalysts.FooterRow.FindControl("lblLbsForDrumFooter")).Text.Trim(); ;

                    WorkFullLengthLiningCatalystsGateway workFullLengthLiningCatalystsGateway = new WorkFullLengthLiningCatalystsGateway();
                    workFullLengthLiningCatalystsGateway.LoadByCatalystId(catalystId, companyId);
                    string name = workFullLengthLiningCatalystsGateway.GetName(catalystId);

                    FullLengthLiningWetOutCatalystsDetails model = new FullLengthLiningWetOutCatalystsDetails(fullLengthLiningTDS);
                    model.Insert(workId, catalystId, name, percentageByWeight, lbsForMixQuantity, lbsForDrum, deleted, companyId, inDatabase);

                    Session.Remove("wetOutCatalystsDetailsDummy");
                    Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                    Session["wetOutCatalystsDetails"] = fullLengthLiningTDS.WetOutCatalystsDetails;

                    grdCatalysts.DataBind();
                    grdCatalysts.PageIndex = grdCatalysts.PageCount - 1;
                }
            }
        }



        private string GetLateralIdIncrement()
        {
            // Get Measured From Mh value
            int assetId = Int32.Parse(hdfAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            string measuredFromMh = "";

            FullLengthLiningLateralDetails flLateralDetails = new FullLengthLiningLateralDetails();
            flLateralDetails.LoadForEdit(workId, assetId, companyId, currentProjectId);

            if (flLateralDetails.Table.Rows.Count > 0)
            {               
                measuredFromMh = "USMH";
            }
            else
            {
                measuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
            }

            // Generate increment
            string lateralIdIncrement = "";
            FullLengthLiningLateralDetails fullLengthLiningLateraldetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);

            if (measuredFromMh == "USMH" || measuredFromMh == "")
            {
                lateralIdIncrement = fullLengthLiningLateraldetails.GetMaxLateralId2();

            }
            else
            {
                if (measuredFromMh == "DSMH")
                {
                    lateralIdIncrement = fullLengthLiningLateraldetails.GetMinLateralId2();
                }
            }

            return "FL-"+lateralIdIncrement;
        }



        #region TagPage and Load Functions

        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
            hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
            hdfWorkType.Value = "Full Length Lining";
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
            hdfWorkIdJl.Value = GetWorkId(projectId, assetId, "Junction Lining Section", companyId).ToString();
        }



        private void LoadFullLengthLiningData(int projectId, int assetId, int companyId)
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
            FullLengthLiningSectionDetailsGateway fullLengthLiningSectionDetailsGateway = new FullLengthLiningSectionDetailsGateway(fullLengthLiningTDS);
            if (fullLengthLiningSectionDetailsGateway.Table.Rows.Count > 0)
            {
                // Load Section Details
                tbxFlowSectionId.Text = fullLengthLiningSectionDetailsGateway.GetFlowOrderId(workId);                
                hdfFlowOrderId.Value = fullLengthLiningSectionDetailsGateway.GetFlowOrderId(workId);
                hdfSectionId.Value = fullLengthLiningSectionDetailsGateway.GetSectionId(workId);
                tbxOldCwpId.Text = fullLengthLiningSectionDetailsGateway.GetOriginalSectionId(workId);
                tbxStreet.Text = fullLengthLiningSectionDetailsGateway.GetStreet(workId);
                tbxUSMH.Text = fullLengthLiningSectionDetailsGateway.GetUsmhDescription(workId);
                tbxDSMH.Text = fullLengthLiningSectionDetailsGateway.GetDsmhDescription(workId);
                tbxMapSize.Text = fullLengthLiningSectionDetailsGateway.GetMapSize(workId);
                tbxConfirmedSize.Text = fullLengthLiningSectionDetailsGateway.GetSize_(workId);
                ddlThickness.SelectedValue = fullLengthLiningSectionDetailsGateway.GetThickness(workId);
                tbxMapLength.Text = fullLengthLiningSectionDetailsGateway.GetMapLength(workId);
                tbxSteelTapeLength.Text = fullLengthLiningSectionDetailsGateway.GetLength(workId);
                tbxLaterals.Text = "0"; if (fullLengthLiningSectionDetailsGateway.GetLaterals(workId).HasValue) tbxLaterals.Text = fullLengthLiningSectionDetailsGateway.GetLaterals(workId).ToString().Trim();
                tbxLiveLaterals.Text = "0"; if (fullLengthLiningSectionDetailsGateway.GetLiveLaterals(workId).HasValue) tbxLiveLaterals.Text = fullLengthLiningSectionDetailsGateway.GetLiveLaterals(workId).ToString().Trim();

                // For m1 data
                // ... for depths
                tbxM1DataUsmhDepth.Text = fullLengthLiningSectionDetailsGateway.GetUsmhDepth(workId);
                tbxM1DataDsmhDepth.Text = fullLengthLiningSectionDetailsGateway.GetDsmhDepth(workId);

                // ... for address
                tbxM1DataUsmhAddress.Text = fullLengthLiningSectionDetailsGateway.GetUsmhAddress(workId);
                tbxM1DataDsmhAddress.Text = fullLengthLiningSectionDetailsGateway.GetDsmhAddress(workId);

                // ... Get lfs asset sewer data
                tbxM1DataSteelTapeThroughSewer.Text = fullLengthLiningSectionDetailsGateway.GetSteelTapeThroughSewer(workId);
                tbxM1DataUsmhMouth12.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth12(workId);
                tbxM1DataUsmhMouth1.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth1(workId);
                tbxM1DataUsmhMouth2.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth2(workId);
                tbxM1DataUsmhMouth3.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth3(workId);
                tbxM1DataUsmhMouth4.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth4(workId);
                tbxM1DataUsmhMouth5.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth5(workId);
                tbxM1DataDsmhMouth12.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth12(workId);
                tbxM1DataDsmhMouth1.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth1(workId);
                tbxM1DataDsmhMouth2.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth2(workId);
                tbxM1DataDsmhMouth3.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth3(workId);
                tbxM1DataDsmhMouth4.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth4(workId);
                tbxM1DataDsmhMouth5.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth5(workId);
                tbxGeneralSubArea.Text = fullLengthLiningSectionDetailsGateway.GetSubArea(workId);                
            }
        }



        private void LoadWorkData(int workId, int assetId)
        {
            FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway(fullLengthLiningTDS);

            if (fullLengthLiningWorkDetailsGateway.Table.Rows.Count > 0)
            {
                // For Header
                tbxVideoLength.Text = fullLengthLiningWorkDetailsGateway.GetVideoLength(workId);

                // Load full length lining general data
                tbxGeneralClientId.Text = fullLengthLiningWorkDetailsGateway.GetClientId(workId);
                ckbxGeneralIssueIdentified.Checked = fullLengthLiningWorkDetailsGateway.GetIssueIdentified(workId);
                ckbxGeneralLfsIssue.Checked = fullLengthLiningWorkDetailsGateway.GetIssueLFS(workId);
                ckbxGeneralClientIssue.Checked = fullLengthLiningWorkDetailsGateway.GetIssueClient(workId);
                ckbxGeneralSalesIssue.Checked = fullLengthLiningWorkDetailsGateway.GetIssueSales(workId);
                ckbxGeneralIssueGivenToClient.Checked = fullLengthLiningWorkDetailsGateway.GetIssueGivenToClient(workId);
                ckbxGeneralIssueResolved.Checked = fullLengthLiningWorkDetailsGateway.GetIssueResolved(workId);
                ckbxGeneralIssueInvestigation.Checked = fullLengthLiningWorkDetailsGateway.GetIssueInvestigation(workId);

                // ... Load Dates
                if (fullLengthLiningWorkDetailsGateway.GetProposedLiningDate(workId).HasValue)
                {
                    tkrdpGeneralProposedLiningDate.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetProposedLiningDate(workId);
                }

                if (fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDate(workId).HasValue)
                {
                    tkrdpGeneralDeadlineLiningDate.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDate(workId);
                }

                if (fullLengthLiningWorkDetailsGateway.GetP1Date(workId).HasValue)
                {
                    tkrdpPrepDataP1Date.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetP1Date(workId);
                    tkrdpGeneralP1Date.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetP1Date(workId);
                }

                if (fullLengthLiningWorkDetailsGateway.GetM1Date(workId).HasValue)
                {
                    tkrdpM1DataM1Date.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetM1Date(workId);
                    tkrdpGeneralM1Date.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetM1Date(workId);
                }

                if (fullLengthLiningWorkDetailsGateway.GetM2Date(workId).HasValue)
                {
                    tkrdpGeneralM2Date.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetM2Date(workId);
                    tkrdpM2DataM2Date.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetM2Date(workId);
                }

                if (fullLengthLiningWorkDetailsGateway.GetInstallDate(workId).HasValue)
                {
                    tkrdpGeneralInstallDate.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetInstallDate(workId);
                    tkrdpInstallDataInstallDate.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetInstallDate(workId);
                }

                if (fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workId).HasValue)
                {
                    tkrdpGeneralFinalVideo.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workId);
                    tkrdpInstallDataFinalVideoDate.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workId);
                }

                // ... for RA data
                if (fullLengthLiningWorkDetailsGateway.GetPreFlushDate(workId).HasValue)
                {
                    tkrdpGeneralPreFlushDate.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetPreFlushDate(workId);
                    tkrdpGeneralPreFlushDateReadOnly.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetPreFlushDate(workId);
                }

                if (fullLengthLiningWorkDetailsGateway.GetPreVideoDate(workId).HasValue)
                {
                    tkrdpGeneralPreVideoDate.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetPreVideoDate(workId);
                    tkrdpGeneralPreVideoDateReadOnly.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetPreVideoDate(workId);
                }

                // For FullLengthLiningP1 data
                tbxPrepDataCXIsRemoved.Text = ""; if (fullLengthLiningWorkDetailsGateway.GetCxisRemoved(workId).HasValue) tbxPrepDataCXIsRemoved.Text = fullLengthLiningWorkDetailsGateway.GetCxisRemoved(workId).ToString();
                ckbxPrepDataRoboticPrepCompleted.Checked = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompleted(workId);
                if (fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workId).HasValue)
                {
                    tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workId);
                }
                ckbxPrepDataP1Completed.Checked = fullLengthLiningWorkDetailsGateway.GetP1Completed(workId);

                // For FullLengthLiningM1 data
                // ... for material
                ddlM1DataMaterial.SelectedValue = fullLengthLiningWorkDetailsGateway.GetMaterial(workId);

                // ... form m1 data                
                tbxM1DataMeasurementsTakenBy.Text = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenBy(workId);
                ddlM1DataTrafficControl.SelectedValue = fullLengthLiningWorkDetailsGateway.GetTrafficControl(workId);
                if(fullLengthLiningWorkDetailsGateway.GetSiteDetails(workId) == "") ddlM1DataSiteDetails.SelectedIndex = 0; else ddlM1DataSiteDetails.SelectedValue = fullLengthLiningWorkDetailsGateway.GetSiteDetails(workId);
                if (fullLengthLiningWorkDetailsGateway.GetAccessType(workId) == "") ddlM1DataAccessType.SelectedIndex = 0; else ddlM1DataAccessType.SelectedValue = fullLengthLiningWorkDetailsGateway.GetAccessType(workId);
                ckbxM1DataPipeSizeChange.Checked = fullLengthLiningWorkDetailsGateway.GetPipeSizeChange(workId);
                ckbxM1DataStandardBypass.Checked = fullLengthLiningWorkDetailsGateway.GetStandardBypass(workId);
                tbxM1DataStandardBypassComments.Text = fullLengthLiningWorkDetailsGateway.GetStandardBypassComments(workId);
                tbxM1DataTrafficControlDetails.Text = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetails(workId);
                ddlM1DataMeasurementType.SelectedValue = fullLengthLiningWorkDetailsGateway.GetMeasurementType(workId);
                ddlM1DataMeasuredFromMh.SelectedValue = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId);
                tbxM1DataMeasuredFromMh.Text = ""; fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId);
                ddlM1DataVideoDoneFromMh.SelectedValue = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMh(workId);
                tbxM1DataVideoDoneFromMh.Text = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMh(workId);                
                ddlM1DataVideoDoneToMh.SelectedValue = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMh(workId);
                tbxM1DataVideoDoneToMh.Text = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMh(workId);

                // For FullLengthLiningM2 data
                tbxM2DataMeasurementsTakenBy.Text = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2(workId);
                ckbxM2DataDropPipe.Checked = fullLengthLiningWorkDetailsGateway.GetDropPipe(workId);
                tbxM2DataDropPipeInvertdepth.Text = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepth(workId);
                tbxM2DataCappedLaterals.Text = ""; if (fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workId).HasValue) tbxM2DataCappedLaterals.Text = fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workId).ToString();
                tbxM2DataLineWidthId.Text = fullLengthLiningWorkDetailsGateway.GetLineWithId(workId);
                tbxM2DataHydrantAddress.Text = fullLengthLiningWorkDetailsGateway.GetHydrantAddress(workId);
                ddlM2DataHydroWireWithin10FtOfInversionMh.SelectedValue = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMH(workId);
                tbxM2DataDistanceToInversionMH.Text = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMh(workId);
                if (fullLengthLiningWorkDetailsGateway.GetSurfaceGrade(workId) == "") ddlM2DataSurfaceGrade.SelectedIndex = 0; else ddlM2DataSurfaceGrade.SelectedValue = fullLengthLiningWorkDetailsGateway.GetSurfaceGrade(workId);
                cbxM2DataHydroPulley.Checked = fullLengthLiningWorkDetailsGateway.GetHydroPulley(workId);
                cbxM2DataFridgeCart.Checked = fullLengthLiningWorkDetailsGateway.GetFridgeCart(workId);
                cbxM2DataTwoPump.Checked = fullLengthLiningWorkDetailsGateway.GetTwoPump(workId);
                cbxM2DataSixBypass.Checked = fullLengthLiningWorkDetailsGateway.GetSixBypass(workId);
                cbxM2DataScaffolding.Checked = fullLengthLiningWorkDetailsGateway.GetScaffolding(workId);
                cbxM2DataWinchExtension.Checked = fullLengthLiningWorkDetailsGateway.GetWinchExtension(workId);
                cbxM2DataExtraGenerator.Checked = fullLengthLiningWorkDetailsGateway.GetExtraGenerator(workId);
                cbxM2DataGreyCableExtension.Checked = fullLengthLiningWorkDetailsGateway.GetGreyCableExtension(workId);
                cbxM2DataEasementMats.Checked = fullLengthLiningWorkDetailsGateway.GetEasementMats(workId);
                cbxM2DataRampsRequired.Checked = fullLengthLiningWorkDetailsGateway.GetRampRequired(workId);
                cbxM2DataCameraSkid.Checked = fullLengthLiningWorkDetailsGateway.GetCameraSkid(workId);

                // For FullLengthLiningWetOut data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                
                // ... ... tube size = confirmed Size
                Distance confirmedSizeDistance = new Distance(tbxConfirmedSize.Text);
                double confirmedSize = 0;
                string[] confirmedSizeString = confirmedSizeDistance.ToStringInEng1().Split('\"');

                if (!confirmedSizeDistance.ToStringInEng1().Contains("'"))
                {
                    if (Validator.IsValidDouble(tbxConfirmedSize.Text))
                    {
                        confirmedSize = double.Parse(tbxConfirmedSize.Text);
                    }
                    else
                    {
                        confirmedSize = double.Parse(confirmedSizeString[0]);
                    }
                }
                else
                {
                    confirmedSize = Math.Ceiling(confirmedSizeDistance.ToDoubleInEng3()*12);
                    tbxConfirmedSize.Text = confirmedSize.ToString();
                }

                // ... Verify if work has wet out information
                WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGateway = new WorkFullLengthLiningWetOutGateway();
                workFullLengthLiningWetOutGateway.LoadByWorkId(workId, companyId);                              
                               
                if (workFullLengthLiningWetOutGateway.Table.Rows.Count > 0)
                {                    
                    // ... setup data
                    ddlWetOutDataLinerTube.SelectedValue = fullLengthLiningWorkDetailsGateway.GetLinerTube(workId);
                    if (ddlWetOutDataLinerTube.SelectedValue != "(Select)")
                    {
                        ckbxWetOutDataIncludeWetOutInformation.Checked = true;
                    }
                    else
                    {
                        ckbxWetOutDataIncludeWetOutInformation.Checked = false;
                    }

                    ddlWetOutDataResins.SelectedValue = fullLengthLiningWorkDetailsGateway.GetResinId(workId).ToString(); 
                    tbxWetOutDataExcessResin.Text = fullLengthLiningWorkDetailsGateway.GetExcessResin(workId).ToString();
                    ddlWetOutDataPoundsDrums.SelectedValue = fullLengthLiningWorkDetailsGateway.GetPoundsDrums(workId);
                    tbxWetOutDataDrumDiameter.Text = fullLengthLiningWorkDetailsGateway.GetDrumDiameter(workId).ToString();
                    tbxWetOutDataHoistMaximumHeight.Text = fullLengthLiningWorkDetailsGateway.GetHoistMaximumHeight(workId).ToString();
                    tbxWetOutDataHoistMinimumHeight.Text = fullLengthLiningWorkDetailsGateway.GetHoistMinimumHeight(workId).ToString();
                    tbxWetOutDataDownDropTubeLength.Text = fullLengthLiningWorkDetailsGateway.GetDownDropTubeLenght(workId).ToString();
                    tbxWetOutDataPumpHeightAboveGround.Text = fullLengthLiningWorkDetailsGateway.GetPumpHeightAboveGround(workId).ToString();
                    tbxWetOutDataTubeResinToFeltFactor.Text = fullLengthLiningWorkDetailsGateway.GetTubeResinToFeltFactor(workId).ToString();

                    // ... wet out sheet
                    DateTime wetOutDataDateOfSheet = fullLengthLiningWorkDetailsGateway.GetDateOfSheet(workId);
                    tbxWetOutDataDateOfSheet.Text = wetOutDataDateOfSheet.Month.ToString() + "/" + wetOutDataDateOfSheet.Day.ToString() + "/" + wetOutDataDateOfSheet.Year.ToString();
                    ddlWetOutDataMadeBy.SelectedValue = fullLengthLiningWorkDetailsGateway.GetEmployeeId(workId).ToString();
                    hdfRunDetails.Value = fullLengthLiningWorkDetailsGateway.GetRunDetails(workId);                    
                    ddlWetOutDataRunDetails2.SelectedValue = fullLengthLiningWorkDetailsGateway.GetRunDetails2(workId);
                    tkrdpWetOutDataWetOutDate.SelectedDate = fullLengthLiningWorkDetailsGateway.GetWetOutDate(workId);

                    tbxWetOutDataInstallDate.Text = "";
                    if (fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId).HasValue)
                    {
                        DateTime? wetOutDataInstallDate = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId);
                        DateTime wetOutDataInstallDateDateTime = (DateTime)wetOutDataInstallDate;
                        tbxWetOutDataInstallDate.Text = wetOutDataInstallDateDateTime.Month.ToString() + "/" + wetOutDataInstallDateDateTime.Day.ToString() + "/" + wetOutDataInstallDateDateTime.Year.ToString();
                    }                    

                    tbxWetOutDataTubeThickness.Text = fullLengthLiningWorkDetailsGateway.GetInversionThickness(workId);
                    tbxWetOutDataLengthToLine.Text = decimal.Round(decimal.Parse(fullLengthLiningWorkDetailsGateway.GetLengthToLine(workId).ToString()), 1).ToString(); 
                    tbxWetOutDataPlusExtra.Text = fullLengthLiningWorkDetailsGateway.GetPlusExtra(workId).ToString();
                    tbxWetOutDataForTurnOffset.Text = fullLengthLiningWorkDetailsGateway.GetForTurnOffset(workId).ToString();
                    tbxWetOutDataLengthtToWetOut.Text = fullLengthLiningWorkDetailsGateway.GetLengthToWetOut(workId).ToString();

                    tbxWetOutDataTubeMaxColdHead.Text = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHead(workId).ToString();
                    tbxWetOutDataTubeMaxColdHeadPSI.Text = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHeadPsi(workId).ToString();
                    tbxWetOutDataTubeMaxHotHead.Text = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHead(workId).ToString();
                    tbxWetOutDataTubeMaxHotHeadPSI.Text = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHeadPsi(workId).ToString();
                    tbxWetOutDataTubeIdealHead.Text = fullLengthLiningWorkDetailsGateway.GetTubeIdealHead(workId).ToString();
                    tbxWetOutDataTubeIdealHeadPSI.Text = fullLengthLiningWorkDetailsGateway.GetTubeIdealHeadPsi(workId).ToString();

                    tbxWetOutDataNetResinForTube.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTube(workId).ToString();
                    tbxWetOutDataNetResinForTubeUsgals.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgals(workId).ToString();
                    tbxWetOutDataNetResinForTubeDrumsIns.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeDrumsIns(workId);
                    tbxWetOutDataNetResinForTubeLbsFt.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeLbsFt(workId).ToString();
                    tbxWetOutDataNetResinForTubeUsgFt.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgFt(workId).ToString();

                    tbxWetOutDataExtraResinForMix.Text = fullLengthLiningWorkDetailsGateway.GetExtraResinForMix(workId).ToString();
                    tbxWetOutDataExtraLbsForMix.Text = fullLengthLiningWorkDetailsGateway.GetExtraLbsForMix(workId).ToString();
                    tbxWetOutDataTotalMixQuantity.Text = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantity(workId).ToString();
                    tbxWetOutDataTotalMixQuantityUsgals.Text = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityUsgals(workId).ToString();
                    tbxWetOutDataTotalMixQuantityDrumsIns.Text = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityDrumsIns(workId);

                    ddlWetOutDataInversionType.SelectedValue = fullLengthLiningWorkDetailsGateway.GetInversionType(workId);
                    tbxWetOutDataDepthOfInversionMH.Text = fullLengthLiningWorkDetailsGateway.GetDepthOfInversionMH(workId).ToString();
                    tbxWetOutDataTubeForColumn.Text = fullLengthLiningWorkDetailsGateway.GetTubeForColumn(workId).ToString();
                    tbxWetOutDataTubeForStartDry.Text = fullLengthLiningWorkDetailsGateway.GetTubeForStartDry(workId).ToString();
                    tbxWetOutDataTotalTube.Text = fullLengthLiningWorkDetailsGateway.GetTotalTube(workId).ToString();
                    tbxWetOutDataDropTubeConnects.Text = fullLengthLiningWorkDetailsGateway.GetDropTubeConnects(workId);
                    tbxWetOutDataAllowsHeadTo.Text = fullLengthLiningWorkDetailsGateway.GetAllowsHeadTo(workId).ToString();
                    tbxWetOutDataRollerGap.Text = fullLengthLiningWorkDetailsGateway.GetRollerGap(workId).ToString();

                    tbxWetOutDataHeightNeeded.Text = fullLengthLiningWorkDetailsGateway.GetHeightNeeded(workId).ToString();
                    tbxWetOutDataAvailable.Text = fullLengthLiningWorkDetailsGateway.GetAvailable(workId);
                    tbxWetOutDataHoistHeight.Text = fullLengthLiningWorkDetailsGateway.GetHoistHeight(workId);
                    hdfResinId.Value = fullLengthLiningWorkDetailsGateway.GetResinId(workId).ToString();
                    hdfMadeBy.Value = fullLengthLiningWorkDetailsGateway.GetEmployeeId(workId).ToString();
                    tbxWetOutDataNotes.Text = fullLengthLiningWorkDetailsGateway.GetCommentsCipp(workId);

                    lblWetOutDataResinGray.Text = fullLengthLiningWorkDetailsGateway.GetResinsLabel(workId);
                    lblWetOutDataDrumContainsGray.Text = fullLengthLiningWorkDetailsGateway.GetDrumContainsLabel(workId);
                    lblWetOutDataLinerTubeGray.Text = fullLengthLiningWorkDetailsGateway.GetLinerTubeLabel(workId);
                    lblWetOutDataLbDrumsGrey.Text = fullLengthLiningWorkDetailsGateway.GetForLbDrumsLabel(workId);
                    lblWetOutDataNetResinGrey.Text = fullLengthLiningWorkDetailsGateway.GetNetResinLabel(workId);
                    lblWetOutDataCatalystGrey.Text = fullLengthLiningWorkDetailsGateway.GetCatalystLabel(workId);

                    // ... ... graphic labels
                    lblWetOutDataDimensionLabel.Text = confirmedSize + " ins x " + ddlThickness.SelectedValue + " mm Tube";
                    lblWetOutDataTotalTubeLengthlabel.Text = "Total Tube Length " + tbxWetOutDataTotalTube.Text + " ft";
                    lblWetOutDataForColumnLabel.Text = tbxWetOutDataTubeForColumn.Text + " ft  for Column";
                    lblWetOutDataDryFtLabel.Text = "Dry " + tbxWetOutDataTubeForStartDry.Text + " ft";
                    lblWetOutDataWetOutLengthlabel.Text = "Wet-Out Length " + tbxWetOutDataLengthtToWetOut.Text + " ft";
                    lblWetOutDataDryFtEndLabel.Text = "Dry " + tbxWetOutDataTubeForColumn.Text + " ft";
                    lblWetOutDataTailEndlabel.Text = "Tail End";
                    lblWetOutDataColumnEndlabel.Text = "Column End";
                    lblWetOutDataRollerGapLabel.Text = "Roller Gap " + tbxWetOutDataRollerGap.Text + " mm";
                }
                else
                {
                    //  Wet Out Data
                    // ... Show current day for new sheets
                    DateTime sheetDate = DateTime.Now;
                    tbxWetOutDataDateOfSheet.Text = sheetDate.Month.ToString() + "/" + sheetDate.Day.ToString() + "/" + sheetDate.Year.ToString();

                    // Set default values.
                    tbxWetOutDataExcessResin.Text = "0.0";
                    ddlWetOutDataPoundsDrums.SelectedIndex = 1;
                    tbxWetOutDataDrumDiameter.Text = "22.5";
                    tbxWetOutDataHoistMaximumHeight.Text = "24";
                    tbxWetOutDataHoistMinimumHeight.Text = "5";
                    tbxWetOutDataDownDropTubeLength.Text = "19";
                    tbxWetOutDataPumpHeightAboveGround.Text = "6";
                    tbxWetOutDataTubeResinToFeltFactor.Text = "87";

                    tbxWetOutDataPlusExtra.Text = "3";
                    tbxWetOutDataForTurnOffset.Text = "0";                   
                    
                    tbxWetOutDataExtraResinForMix.Text = "0";                    
                    tbxWetOutDataTubeForColumn.Text = "16";
                    tbxWetOutDataTubeForStartDry.Text = "3";
                    if (ddlWetOutDataInversionType.SelectedValue == "Top")
                    {
                        Distance usmhDepthDistance = new Distance(tbxM1DataUsmhDepth.Text);
                        tbxWetOutDataDepthOfInversionMH.Text = decimal.Round(decimal.Parse(usmhDepthDistance.ToStringInEng3()), 1).ToString();                              
                    }
                    else
                    {
                        if (ddlWetOutDataInversionType.SelectedValue == "Bottom")
                        {
                            Distance dsmhDepthDistance = new Distance(tbxM1DataDsmhDepth.Text);
                            tbxWetOutDataDepthOfInversionMH.Text = decimal.Round(decimal.Parse(dsmhDepthDistance.ToStringInEng3()), 1).ToString();                                  
                        }
                        else
                        {
                            tbxWetOutDataDepthOfInversionMH.Text = "0";
                        }
                    }

                    tbxWetOutDataRollerGap.Text = "13";
                    tbxWetOutDataNotes.Text = fullLengthLiningWorkDetailsGateway.GetCommentsCipp(workId);

                    // ...Section values
                    // ... ... Length To Line = Steel Tape Length, the first section to consider is the work one in Xft Yin
                    Distance steelTapeLength = new Distance(tbxSteelTapeLength.Text);
                    tbxWetOutDataLengthToLine.Text = decimal.Round(decimal.Parse(steelTapeLength.ToStringInEng3()), 1).ToString();
                    tbxInversionDataRunLength.Text = decimal.Round(decimal.Parse(steelTapeLength.ToStringInEng3()),1).ToString();
                    double lengthToLine = double.Parse(steelTapeLength.ToStringInEng3());

                    // ... Run details
                    if (cbxlSectionId.Items.Count > 1)
                    {
                        hdfRunDetails.Value = hdfSectionId.Value;
                    }

                    // .... Install Date
                    tbxWetOutDataInstallDate.Text = "";
                    if (tkrdpInstallDataInstallDate.SelectedDate.ToString() != "")
                    {
                        DateTime? inversionDataInstalledOn = tkrdpInstallDataInstallDate.SelectedDate;
                        DateTime installedOnDateTime = (DateTime)inversionDataInstalledOn;

                        tbxWetOutDataInstallDate.Text = installedOnDateTime.Month.ToString() + "/" + installedOnDateTime.Day.ToString() + "/" + installedOnDateTime.Year.ToString();
                    }
                }


                // ... Verify if work has inversion information
                WorkFullLengthLiningInversionGateway workFullLengthLiningInversionGateway = new WorkFullLengthLiningInversionGateway();
                workFullLengthLiningInversionGateway.LoadByWorkId(workId, companyId);

                // ... Verify if work has inversion information
                if (workFullLengthLiningInversionGateway.Table.Rows.Count > 0)
                {                    
                    // ... Inversion data
                    lblInversionDataSubtitle.Text = fullLengthLiningWorkDetailsGateway.GetLinerTube(workId);

                    DateTime inversionDataDateOfSheet = fullLengthLiningWorkDetailsGateway.GetDateOfSheet(workId);
                    tbxInversionDataDateOfSheet.Text = inversionDataDateOfSheet.Month.ToString() + "/" + inversionDataDateOfSheet.Day.ToString() + "/" + inversionDataDateOfSheet.Year.ToString();

                    int employeeId = fullLengthLiningWorkDetailsGateway.GetEmployeeId(workId);
                    EmployeeGateway employeeGateway = new EmployeeGateway();
                    employeeGateway.LoadByEmployeeId(employeeId);
                    tbxInversionDataMadeBy.Text = employeeGateway.GetLastName(employeeId) + " " + employeeGateway.GetFirstName(employeeId);

                    tbxInversionDataInstalledOn.Text = "";
                    if (fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId).HasValue)
                    {
                        DateTime? inversionDataInstalledOn = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId);
                        DateTime inversionDataInstalledOnDateTime = (DateTime)inversionDataInstalledOn;
                        tbxInversionDataInstalledOn.Text = inversionDataInstalledOnDateTime.Month.ToString() + "/" + inversionDataInstalledOnDateTime.Day.ToString() + "/" + inversionDataInstalledOnDateTime.Year.ToString();
                    }

                    tbxInversionDataRunDetails2.Text = fullLengthLiningWorkDetailsGateway.GetRunDetails2(workId);
                    tbxInversionDataCommentsEdit.Text = fullLengthLiningWorkDetailsGateway.GetInversionComment(workId);                    
                    tbxInversionDataLinerSize.Text = confirmedSizeString + " ins x" + fullLengthLiningWorkDetailsGateway.GetInversionThickness(workId);
                    tbxInversionDataRunLength.Text = decimal.Round(decimal.Parse(fullLengthLiningWorkDetailsGateway.GetLengthToLine(workId).ToString()), 1).ToString();
                    tbxInversionDataWetOutLenght.Text = fullLengthLiningWorkDetailsGateway.GetLengthToWetOut(workId).ToString();

                    ddlInversionDataInversionPipeType.SelectedValue = fullLengthLiningWorkDetailsGateway.GetPipeType(workId);
                    if (ddlInversionDataInversionPipeType.SelectedValue != "(Select)")
                    {
                        ckbxInversionDataIncludeInversionInformation.Checked = true;
                    }
                    else
                    {
                        ckbxInversionDataIncludeInversionInformation.Checked = false;
                    }

                    ddlInversionDataPipeCondition.SelectedValue = fullLengthLiningWorkDetailsGateway.GetPipeCondition(workId);
                    ddlInversionDataGroundMoisture.SelectedValue = fullLengthLiningWorkDetailsGateway.GetGroundMoisture(workId);
                    tbxInversionDataBoilerSize.Text = fullLengthLiningWorkDetailsGateway.GetBoilerSize(workId).ToString();
                    tbxInversionDataPumpsTotalCapacity.Text = fullLengthLiningWorkDetailsGateway.GetPumpTotalCapacity(workId).ToString();
                    tbxInversionDataLayflatSize.Text = fullLengthLiningWorkDetailsGateway.GetLayFlatSize(workId).ToString();
                    tbxInversionDataLayflatQuantityTotal.Text = fullLengthLiningWorkDetailsGateway.GetLayFlatQuantityTotal(workId).ToString();

                    tbxInversionDataWaterStartTempTs.Text = fullLengthLiningWorkDetailsGateway.GetWaterStartTemp(workId).ToString();
                    tbxInversionDataTempT1.Text = fullLengthLiningWorkDetailsGateway.GetTemp1(workId).ToString();
                    tbxInversionDataHoldAtT1For.Text = fullLengthLiningWorkDetailsGateway.GetHoldAtT1(workId).ToString();
                    tbxInversionDataTempT2.Text = fullLengthLiningWorkDetailsGateway.GetTempT2(workId).ToString();
                    tbxInversionDataCookAtT2For.Text = fullLengthLiningWorkDetailsGateway.GetCookAtT2(workId).ToString();
                    tbxInversionDataCoolDownFor.Text = fullLengthLiningWorkDetailsGateway.GetCoolDownFor(workId).ToString();

                    tbxInversionDataCoolToTemp.Text = fullLengthLiningWorkDetailsGateway.GetCoolToTemp(workId).ToString();
                    tbxInversionDataDropInPipeRun.Text = fullLengthLiningWorkDetailsGateway.GetDropInPipeRun(workId).ToString();
                    tbxInversionDataPipeSlopeOf.Text = fullLengthLiningWorkDetailsGateway.GetPipeSlopOf(workId).ToString();

                    lblInversionData45F120F.Text = tbxInversionDataWaterStartTempTs.Text + "°F-" + tbxInversionDataTempT1.Text + "°F (hr)";
                    tbxInversionData45F120F.Text = fullLengthLiningWorkDetailsGateway.GetF45F120(workId).ToString();
                    tbxInversionDataHold.Text = fullLengthLiningWorkDetailsGateway.GetHold(workId).ToString();
                    lblInversionData120F185F.Text = tbxInversionDataTempT1.Text + "°F-" + tbxInversionDataTempT2.Text + "°F (hr)"; 
                    tbxInversionData120F185F.Text = fullLengthLiningWorkDetailsGateway.GetF120F185(workId).ToString();
                    tbxInversionDataCookTime.Text = fullLengthLiningWorkDetailsGateway.GetCookTime(workId).ToString();
                    tbxInversionDataCoolTime.Text = fullLengthLiningWorkDetailsGateway.GetCoolTime(workId).ToString();
                    tbxInversionDataAproxTotal.Text = fullLengthLiningWorkDetailsGateway.GetAproxTotal(workId).ToString();

                    tbxInversionDataWaterChangesPerHour.Text = fullLengthLiningWorkDetailsGateway.GetWaterChangesPerHour(workId).ToString();
                    tbxInversionDataReturnWaterVelocity.Text = fullLengthLiningWorkDetailsGateway.GetReturnWaterVelocity(workId).ToString();
                    tbxInversionDataLayflatBackPressure.Text = fullLengthLiningWorkDetailsGateway.GetLayflatBackPressure(workId).ToString();
                    tbxInversionDataPumpLiftAtIdealHead.Text = fullLengthLiningWorkDetailsGateway.GetPumpLiftAtIdealHead(workId).ToString();
                    tbxInversionDataWaterToFillLinerColumn.Text = fullLengthLiningWorkDetailsGateway.GetWaterToFillLinerColumn(workId).ToString();
                    tbxInversionDataWaterPerFit.Text = fullLengthLiningWorkDetailsGateway.GetWaterPerFit(workId).ToString();

                    tbxInversionDataNotesAndInstallationResults.Text = fullLengthLiningWorkDetailsGateway.GetInstallationResults(workId);

                    lblInversionDataLinerInfoGrey.Text = fullLengthLiningWorkDetailsGateway.GetInversionLinerTubeLabel(workId);
                    lblInversionDataHeadsGrey.Text = fullLengthLiningWorkDetailsGateway.GetHeadsIdealLabel(workId);
                    lblInversionDataPumpingCirculationSubtitle.Text = fullLengthLiningWorkDetailsGateway.GetPumpingAndCirculationLabel(workId);

                    // ... ... graphic labels
                    lblInversionDataMaxColdForTubeLabel.Text = tbxWetOutDataTubeMaxColdHead.Text + " ft = Max Cold for tube";
                    lblInversionDataMaxHotForTubeLabel.Text = tbxWetOutDataTubeMaxHotHead.Text + " ft = Max Hot for tube";
                    lblInversionDataIdelForTubeLabel.Text = tbxWetOutDataTubeIdealHead.Text + " ft = Ideal for tube";

                    double maxColdForTubeEnd = double.Parse(tbxWetOutDataTubeMaxColdHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                    lblInversionDataMaxColdForTubeEndLabel.Text = decimal.Round(decimal.Parse(maxColdForTubeEnd.ToString()), 1).ToString() + " ft";

                    double maxHotForTubeEnd = double.Parse(tbxWetOutDataTubeMaxHotHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                    lblInversionDataMaxHotForTubeEndLabel.Text = decimal.Round(decimal.Parse(maxHotForTubeEnd.ToString()), 1).ToString() + " ft";

                    double idealForTubeEnd = double.Parse(tbxWetOutDataTubeIdealHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                    lblInversionDataIdelForTubeEndLabel.Text = decimal.Round(decimal.Parse(idealForTubeEnd.ToString()), 1).ToString() + " ft";

                    lblInversionDataPumpHeightLabel.Text = "   " + tbxWetOutDataPumpHeightAboveGround.Text + " ft";
                    lblInversionDataLinerSizeLabel.Text = confirmedSize.ToString() + " ins x" + fullLengthLiningWorkDetailsGateway.GetInversionThickness(workId) + " Liner";

                    lblInversionDataRunLengthLabel.Text = "Run Length: " + tbxInversionDataRunLength.Text + " ft; Fall: " + tbxInversionDataDropInPipeRun.Text + " ft";
                    lblInversionDataDepthOfInversionMHLabel.Text = "   " + tbxWetOutDataDepthOfInversionMH.Text + " ft";
                    lblInversionDataEndLabel.Text = "End";
                }
                else
                {
                    //  Wet Out Data
                    // ... Show current day for new sheets
                    DateTime sheetDate = DateTime.Now;
                    tbxInversionDataDateOfSheet.Text = sheetDate.Month.ToString() + "/" + sheetDate.Day.ToString() + "/" + sheetDate.Year.ToString();
                    
                    // Set default values.
                    lblInversionData45F120F.Text = "";
                    lblInversionData120F185F.Text = "";
                    tbxInversionDataBoilerSize.Text = "7000000";
                    tbxInversionDataPumpsTotalCapacity.Text = "300";
                    tbxInversionDataLayflatSize.Text = "4";
                    tbxInversionDataLayflatQuantityTotal.Text = "1";

                    tbxInversionDataWaterStartTempTs.Text = "45";
                    tbxInversionDataTempT1.Text = "120";
                    tbxInversionDataHoldAtT1For.Text = "0.5";
                    tbxInversionDataTempT2.Text = "185";
                    tbxInversionDataCookAtT2For.Text = "2";
                    tbxInversionDataCoolDownFor.Text = "1";
                    tbxInversionDataCoolToTemp.Text = "85";
                  
                    // ...Section values
                    // ... ... Length To Line = Steel Tape Length, the first section to consider is the work one in Xft Yin
                    Distance steelTapeLength = new Distance(tbxSteelTapeLength.Text);
                    tbxInversionDataRunLength.Text = decimal.Round(decimal.Parse(steelTapeLength.ToStringInEng3()), 1).ToString();
                    double lengthToLine = double.Parse(steelTapeLength.ToStringInEng3());

                    // ... Run details
                    if (cbxlSectionId.Items.Count > 1)
                    {
                        hdfRunDetails.Value = hdfSectionId.Value;
                    }                                        

                    // .... Install Date
                    tbxInversionDataInstalledOn.Text = "";
                    if (tkrdpInstallDataInstallDate.SelectedDate.ToString() != "")
                    {
                        DateTime? inversionDataInstalledOn = tkrdpInstallDataInstallDate.SelectedDate;
                        DateTime installedOnDateTime = (DateTime)inversionDataInstalledOn;

                        tbxInversionDataInstalledOn.Text = installedOnDateTime.Month.ToString() + "/" + installedOnDateTime.Day.ToString() + "/" + installedOnDateTime.Year.ToString();
                    }
                 }   

                // ... Show FLL Comments + RA Comments                          
                int flWorkId = workId;

                // ... ... Get raWorkId
                int raWorkId = 0;
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Rehab Assessment", companyId);
                if (workGateway.Table.Rows.Count > 0)
                {
                    raWorkId = workGateway.GetWorkId(assetId, "Rehab Assessment", projectId);
                }

                // ... ... Get comments
                FullLengthLiningAllComments fullLengthLiningAllComments = new FullLengthLiningAllComments(fullLengthLiningTDS);
                fullLengthLiningAllComments.LoadAllByFlWorkIdRaWorkId(flWorkId, raWorkId, companyId);
                
                // ... ... Store datasets
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

                // ... ... Show comments
                tbxCommentsDataComments.Text = fullLengthLiningAllComments.GetFLOrRAComments(companyId, fullLengthLiningAllComments.Table.Rows.Count, "\n");               
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
                // Laterals Gridview
                // ... If the gridview is edition mode
                if (grdLaterals.EditIndex >= 0)
                {
                    grdLaterals.UpdateRow(grdLaterals.EditIndex, true);
                }

                // Save Lateral data
                GrdFLAddLateralsNewAdd();

                // Catalysts Gridview
                if (ckbxWetOutDataIncludeWetOutInformation.Checked)
                {
                    // ... If the gridview is edition mode
                    if (grdCatalysts.EditIndex >= 0)
                    {
                        grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
                    }

                    // Save Lateral data
                    GrdCatalystsAdd();
                }

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

                // Get Section Details
                // ... FullLengthLiningSectionDetails data
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

                // ... assetSewerMH data
                string newUsmhAddress = ""; if (tbxM1DataUsmhAddress.Text != "") newUsmhAddress = tbxM1DataUsmhAddress.Text.Trim();
                string newDsmhAddress = ""; if (tbxM1DataDsmhAddress.Text != "") newDsmhAddress = tbxM1DataDsmhAddress.Text.Trim();

                // Update section details
                FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
                fullLengthLiningSectionDetails.Update(workId, assetId, newStreet, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newUsmh, newDsmh, newUsmhAddress, newDsmhAddress, newGeneralSubArea, newThickness);

                // Get generalData
                // ... Ra new data
                DateTime? newPreFlushDate = null;
                if (tkrdpGeneralPreFlushDate.Visible == true)
                {
                    if (tkrdpGeneralPreFlushDate.SelectedDate.HasValue)
                    {
                        newPreFlushDate = tkrdpGeneralPreFlushDate.SelectedDate.Value;
                    }
                }
                else
                {
                    if (tkrdpGeneralPreFlushDateReadOnly.SelectedDate.HasValue)
                    {
                        newPreFlushDate = tkrdpGeneralPreFlushDateReadOnly.SelectedDate.Value;
                    }
                }

                DateTime? newPreVideoDate = null;
                if (tkrdpGeneralPreVideoDate.Visible == true)
                {
                    if (tkrdpGeneralPreVideoDate.SelectedDate.HasValue)
                    {
                        newPreVideoDate = tkrdpGeneralPreVideoDate.SelectedDate.Value;
                    }
                }
                else
                {
                    if (tkrdpGeneralPreVideoDateReadOnly.SelectedDate.HasValue)
                    {
                        newPreVideoDate = tkrdpGeneralPreVideoDateReadOnly.SelectedDate.Value; ;
                    }
                }

                // ... FullLengthLining data
                string newGeneralClientId = ""; if (tbxGeneralClientId.Text != "") newGeneralClientId = tbxGeneralClientId.Text.Trim();
                DateTime? newGeneralProposedLiningDate = null; if (tkrdpGeneralProposedLiningDate.SelectedDate.HasValue) newGeneralProposedLiningDate = tkrdpGeneralProposedLiningDate.SelectedDate.Value;
                DateTime? newGeneralDeadlineLiningDate = null; if (tkrdpGeneralDeadlineLiningDate.SelectedDate.HasValue) newGeneralDeadlineLiningDate = tkrdpGeneralDeadlineLiningDate.SelectedDate.Value;
                DateTime? newGeneralP1Date = null; if (tkrdpPrepDataP1Date.SelectedDate.HasValue) newGeneralP1Date = tkrdpPrepDataP1Date.SelectedDate.Value;
                DateTime? newGeneralM1Date = null; if (tkrdpM1DataM1Date.SelectedDate.HasValue) newGeneralM1Date = tkrdpM1DataM1Date.SelectedDate.Value;
                DateTime? newGeneralM2Date = null; if (tkrdpM2DataM2Date.SelectedDate.HasValue) newGeneralM2Date = tkrdpM2DataM2Date.SelectedDate.Value;
                DateTime? newGeneralInstallDate = null; if (tkrdpInstallDataInstallDate.SelectedDate.HasValue) newGeneralInstallDate = tkrdpInstallDataInstallDate.SelectedDate.Value;
                DateTime? newGeneralFinalVideo = null; if (tkrdpInstallDataFinalVideoDate.SelectedDate.HasValue) newGeneralFinalVideo = tkrdpInstallDataFinalVideoDate.SelectedDate.Value;
                bool newGeneralIssueIdentified = ckbxGeneralIssueIdentified.Checked;
                bool newGeneralLfsIssue = ckbxGeneralLfsIssue.Checked;
                bool newGeneralClientIssue = ckbxGeneralClientIssue.Checked;
                bool newGeneralSalesIssue = ckbxGeneralSalesIssue.Checked;
                bool newGeneralIssueGivenToClient = ckbxGeneralIssueGivenToClient.Checked;
                bool newGeneralIssueResolved = ckbxGeneralIssueResolved.Checked;
                bool newGeneralIssueInvestigation = ckbxGeneralIssueInvestigation.Checked;
                int? newPrepDataCXIsRemoved = null; if (tbxPrepDataCXIsRemoved.Text != "") newPrepDataCXIsRemoved = Int32.Parse(tbxPrepDataCXIsRemoved.Text.Trim());
                bool newRoboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;  
                DateTime? newRoboticPrepCompletedDate = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) newRoboticPrepCompletedDate = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;
                bool newP1Completed = ckbxPrepDataP1Completed.Checked;
                    
                // ... WorkFullLengthLiningM1 data                    
                string newMeasurementsTakenBy = ""; if (tbxM1DataMeasurementsTakenBy.Text != "") newMeasurementsTakenBy = tbxM1DataMeasurementsTakenBy.Text.Trim();

                string newMaterial = ddlM1DataMaterial.SelectedValue;
                string newTrafficControl = ddlM1DataTrafficControl.SelectedValue;
                string newSiteDetails = ""; if (ddlM1DataSiteDetails.SelectedValue != "(Select)") newSiteDetails = ddlM1DataSiteDetails.SelectedValue;
                bool newPipeSizeChange = ckbxM1DataPipeSizeChange.Checked;
                bool newStandardByPass = ckbxM1DataStandardBypass.Checked;                
                string newStandardBypassComments = ""; if (tbxM1DataStandardBypassComments.Text != "") newStandardBypassComments = tbxM1DataStandardBypassComments.Text.Trim();
                string newTrafficControlDetails = ""; if (tbxM1DataTrafficControlDetails.Text != "") newTrafficControlDetails = tbxM1DataTrafficControlDetails.Text.Trim();
                string newMeasurementType = ddlM1DataMeasurementType.SelectedValue;
                string newMeasuredFromMh = "";    if (tbxM1DataMeasuredFromMh.Visible) newMeasuredFromMh = tbxM1DataMeasuredFromMh.Text; else newMeasuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
                string newVideoDoneFromMh = "";    if (tbxM1DataVideoDoneFromMh.Visible) newVideoDoneFromMh = tbxM1DataVideoDoneFromMh.Text; else newVideoDoneFromMh = ddlM1DataVideoDoneFromMh.SelectedValue;
                string newVideoDoneToMh = ""; if (tbxM1DataVideoDoneToMh.Visible) newVideoDoneToMh = tbxM1DataVideoDoneToMh.Text; else newVideoDoneToMh = ddlM1DataVideoDoneToMh.SelectedValue;
                string newAccessType = ""; if (ddlM1DataAccessType.SelectedValue != "(Select)") newAccessType = ddlM1DataAccessType.SelectedValue;
                
                // ... ... For header values
                string newVideoLength = tbxVideoLength.Text.Trim();
                                
                // ... WorkFullLengthLiningM2 data
                string newMeasurementTakenByM2 = tbxM2DataMeasurementsTakenBy.Text.Trim();
                bool newDropPipe = ckbxM2DataDropPipe.Checked;
                string newDropPipeInvertDepth = tbxM2DataDropPipeInvertdepth.Text.Trim();
                int? newCappedLaterals = null; if (tbxM2DataCappedLaterals.Text != "") newCappedLaterals = Int32.Parse(tbxM2DataCappedLaterals.Text.Trim());
                string newLineWidthId = ""; if (tbxM2DataLineWidthId.Text != "") newLineWidthId = tbxM2DataLineWidthId.Text.Trim();
                string newHydrantAddress = ""; if (tbxM2DataHydrantAddress.Text != "") newHydrantAddress = tbxM2DataHydrantAddress.Text.Trim();
                string newHydroWireWithin10FtOfInversionMH = ddlM2DataHydroWireWithin10FtOfInversionMh.SelectedValue.Trim();
                string newDistanceToInversionMH = ""; if (tbxM2DataDistanceToInversionMH.Text != "") newDistanceToInversionMH = tbxM2DataDistanceToInversionMH.Text.Trim();
                string newSurfaceGrade = ""; if (ddlM2DataSurfaceGrade.SelectedValue != "(Select)") newSurfaceGrade = ddlM2DataSurfaceGrade.SelectedValue;
                bool newHydroPulley = cbxM2DataHydroPulley.Checked;
                bool newFridgeCart = cbxM2DataFridgeCart.Checked;
                bool newTwoPump = cbxM2DataTwoPump.Checked;
                bool newSixBypass = cbxM2DataSixBypass.Checked;
                bool newScaffolding = cbxM2DataScaffolding.Checked;
                bool newWinchExtension = cbxM2DataWinchExtension.Checked;
                bool newExtraGenerator = cbxM2DataExtraGenerator.Checked;
                bool newGreyCableExtension = cbxM2DataGreyCableExtension.Checked;
                bool newEasementMats = cbxM2DataEasementMats.Checked;
                bool newRampsRequired = cbxM2DataRampsRequired.Checked;
                bool newCameraSkid = cbxM2DataCameraSkid.Checked;
                               
                // ... Update work details
                FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);

                // ... ... If it doen's have wet out information
                if (!ckbxWetOutDataIncludeWetOutInformation.Checked)
                {
                    fullLengthLiningWorkDetails.Update(workId, newGeneralClientId, newGeneralProposedLiningDate, newGeneralDeadlineLiningDate, newGeneralP1Date, newGeneralM1Date, newGeneralM2Date, newGeneralInstallDate, newGeneralFinalVideo, newGeneralIssueIdentified, newGeneralLfsIssue, newGeneralClientIssue, newGeneralSalesIssue, newGeneralIssueGivenToClient, newGeneralIssueResolved, newGeneralIssueInvestigation, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWidthId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMH, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampsRequired, newVideoLength, newPreFlushDate, newPreVideoDate, newCameraSkid, newAccessType, newP1Completed);
                }
                else
                {
                    // Wet out data
                    string newLinerTuber = "";
                    int newResinId = 0;
                    decimal newExcessResin = 0;
                    string newPoundsDrums = "";
                    decimal newDrumDiameter = 0;
                    decimal newHoistMaximumHeight = 0;
                    decimal newHoistMinimumHeight = 0;
                    decimal newDownDropTubeLenght = 0;
                    decimal newPumpHeightAboveGround = 0;
                    int newTubeResinToFeltFactor = 0;
                    DateTime newDateOfSheet = DateTime.Now;
                    int newEmployeeID = 0;
                    string newRunDetails = "";
                    string newRunDetails2 = "";
                    DateTime newWetOutDate = DateTime.Now;
                    DateTime? newInstallDate = null;
                    string newInversionThickness = "";
                    Distance lengthToLine = new Distance("0");
                    decimal newLengthToLine = 0;
                    decimal newPlusExtra = 0;
                    decimal newForTurnOffset = 0;
                    decimal newLengthToWetOut = 0;

                    decimal newTubeMaxColdHead = 0;
                    decimal newTubeMaxColdHeadPsi = 0;
                    decimal newTubeMaxHotHead = 0;
                    decimal newTubeMaxHotHeadPsi = 0;
                    decimal newTubeIdealHead = 0;
                    decimal newTubeIdealHeadPsi = 0;

                    decimal newNetResinForTube = 0;
                    decimal newNetResinForTubeUsgals = 0;
                    string newNetResinForTubeDrumsIns = "";
                    decimal newNetResinForTubeLbsFt = 0;
                    decimal newNetResinForTubeUsgFt = 0;

                    int newExtraResinForMix = 0;
                    decimal newExtraLbsForMix = 0;
                    decimal newTotalMixQuantity = 0;
                    decimal newTotalMixQuantityUsgals = 0;
                    string newTotalMixQuantityDrumsIns = "";

                    string newInversionType = "";
                    decimal newDepthOfInversionMH = 0;
                    decimal newTubeForColumn = 0;
                    decimal newTubeForStartDry = 0;
                    decimal newTotalTube = 0;
                    string newDropTubeConnects = "";
                    decimal newAllowsHeadTo = 0;
                    decimal newRollerGap = 0;

                    decimal newHeightNeeded = 0;
                    string newAvailable = "";
                    string newHoistHeight = "";
                    string newCommentsCipp = "";

                    string newResinLabel = "";
                    string newDrumContainsLabel = "";
                    string newLinerTubeLabel = "";
                    string newForLbDrumsLabel = "";
                    string newNetResinLabel = "";
                    string newCatalystLabel = "";

                    if (ckbxWetOutDataIncludeWetOutInformation.Checked)
                    {
                        // .... ... Wet Out Sheet
                        newLinerTuber = ddlWetOutDataLinerTube.SelectedValue;
                        newResinId = Int32.Parse(ddlWetOutDataResins.SelectedValue);
                        newExcessResin = decimal.Round(decimal.Parse(tbxWetOutDataExcessResin.Text), 1);
                        newPoundsDrums = ddlWetOutDataPoundsDrums.SelectedValue;
                        newDrumDiameter = decimal.Round(decimal.Parse(tbxWetOutDataDrumDiameter.Text), 1);
                        newHoistMaximumHeight = decimal.Round(decimal.Parse(tbxWetOutDataHoistMaximumHeight.Text), 0);
                        newHoistMinimumHeight = decimal.Round(decimal.Parse(tbxWetOutDataHoistMinimumHeight.Text), 0);
                        newDownDropTubeLenght = decimal.Round(decimal.Parse(tbxWetOutDataDownDropTubeLength.Text), 0);
                        newPumpHeightAboveGround = decimal.Round(decimal.Parse(tbxWetOutDataPumpHeightAboveGround.Text), 2);
                        newTubeResinToFeltFactor = Int32.Parse(tbxWetOutDataTubeResinToFeltFactor.Text);

                        newDateOfSheet = DateTime.Parse(tbxWetOutDataDateOfSheet.Text);
                        newEmployeeID = Int32.Parse(ddlWetOutDataMadeBy.SelectedValue);

                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                newRunDetails = newRunDetails + lst.Value + ">";
                            }
                        }
                        newRunDetails = newRunDetails.Substring(0, newRunDetails.Length - 1);

                        newRunDetails2 = ddlWetOutDataRunDetails2.SelectedValue;
                        newWetOutDate = (DateTime)tkrdpWetOutDataWetOutDate.SelectedDate;

                        if (tkrdpInstallDataInstallDate.SelectedDate.ToString() != "")
                        {
                            newInstallDate = (DateTime)tkrdpInstallDataInstallDate.SelectedDate;
                        }

                        newInversionThickness = ddlThickness.SelectedValue;
                        lengthToLine = new Distance(tbxWetOutDataLengthToLine.Text);
                        newLengthToLine = decimal.Round(decimal.Parse(lengthToLine.ToStringInEng3()), 1);
                        newPlusExtra = decimal.Round(decimal.Parse(tbxWetOutDataPlusExtra.Text), 0);
                        newForTurnOffset = decimal.Round(decimal.Parse(tbxWetOutDataForTurnOffset.Text), 0);
                        newLengthToWetOut = decimal.Round(decimal.Parse(tbxWetOutDataLengthtToWetOut.Text), 1);

                        newTubeMaxColdHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxColdHead.Text), 1);
                        newTubeMaxColdHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxColdHeadPSI.Text), 1);
                        newTubeMaxHotHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxHotHead.Text), 1);
                        newTubeMaxHotHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxHotHeadPSI.Text), 1);
                        newTubeIdealHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeIdealHead.Text), 1);
                        newTubeIdealHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeIdealHeadPSI.Text), 1);

                        newNetResinForTube = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTube.Text), 0);
                        newNetResinForTubeUsgals = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeUsgals.Text), 1);
                        newNetResinForTubeDrumsIns = tbxWetOutDataNetResinForTubeDrumsIns.Text;
                        newNetResinForTubeLbsFt = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeLbsFt.Text), 2);
                        newNetResinForTubeUsgFt = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeUsgFt.Text), 3);

                        newExtraResinForMix = Int32.Parse(tbxWetOutDataExtraResinForMix.Text);
                        newExtraLbsForMix = decimal.Round(decimal.Parse(tbxWetOutDataExtraLbsForMix.Text), 2);
                        newTotalMixQuantity = decimal.Round(decimal.Parse(tbxWetOutDataTotalMixQuantity.Text), 0);
                        newTotalMixQuantityUsgals = decimal.Round(decimal.Parse(tbxWetOutDataTotalMixQuantityUsgals.Text), 1);
                        newTotalMixQuantityDrumsIns = tbxWetOutDataTotalMixQuantityDrumsIns.Text;

                        newInversionType = ddlWetOutDataInversionType.SelectedValue;
                        newDepthOfInversionMH = decimal.Round(decimal.Parse(tbxWetOutDataDepthOfInversionMH.Text), 0);
                        newTubeForColumn = decimal.Round(decimal.Parse(tbxWetOutDataTubeForColumn.Text), 0);
                        newTubeForStartDry = decimal.Round(decimal.Parse(tbxWetOutDataTubeForStartDry.Text), 0);
                        newTotalTube = decimal.Round(decimal.Parse(tbxWetOutDataTotalTube.Text), 1);
                        newDropTubeConnects = tbxWetOutDataDropTubeConnects.Text;
                        newAllowsHeadTo = decimal.Round(decimal.Parse(tbxWetOutDataAllowsHeadTo.Text), 0);
                        newRollerGap = decimal.Round(decimal.Parse(tbxWetOutDataRollerGap.Text), 0);

                        newHeightNeeded = decimal.Round(decimal.Parse(tbxWetOutDataHeightNeeded.Text), 0);
                        newAvailable = tbxWetOutDataAvailable.Text;
                        newHoistHeight = tbxWetOutDataHoistHeight.Text;
                        newCommentsCipp = tbxWetOutDataNotes.Text;

                        newResinLabel = lblWetOutDataResinGray.Text;
                        newDrumContainsLabel = lblWetOutDataDrumContainsGray.Text;
                        newLinerTubeLabel = lblWetOutDataLinerTubeGray.Text;
                        newForLbDrumsLabel = lblWetOutDataLbDrumsGrey.Text;
                        newNetResinLabel = lblWetOutDataNetResinGrey.Text;
                        newCatalystLabel = lblWetOutDataCatalystGrey.Text;
                    }

                    // Inversion data
                    string newInversionComment = "";
                    string newPipeType = "";
                    string newPipeCondition = "";
                    string newGroundMoisture = "";
                    decimal newBoilerSize = 0;
                    decimal newPumpTotalCapacity = 0;
                    decimal newLayFlatSize = 0;
                    decimal newLayFlatQuantityTotal = 0;

                    decimal newWaterStartTemp = 0;
                    decimal newTemp1 = 0;
                    decimal newHoldAtT1 = 0;
                    decimal newTempT2 = 0;
                    decimal newCookAtT2 = 0;
                    decimal newCoolDownFor = 0;
                    decimal newCoolToTemp = 0;
                    decimal newDropInPipeRun = 0;
                    decimal newPipeSlopOf = 0;

                    decimal newF45F120 = 0;
                    decimal newHold = 0;
                    decimal newF120F185 = 0;
                    decimal newCookTime = 0;
                    decimal newCoolTime = 0;
                    decimal newAproxTotal = 0;

                    decimal newWaterChangesPerHour = 0;
                    decimal newReturnWaterVelocity = 0;
                    decimal newLayflatBackPressure = 0;
                    decimal newPumpLiftAtIdealHead = 0;
                    decimal newWaterToFillLinerColumn = 0;
                    decimal newWaterPerFit = 0;
                    string newInstallationResults = "";
                    string newInversionLinerTubeLabel = "";
                    string newHeadsIdealLabel = "";
                    string newPumpingAndCirculationLabel = "";

                    if ((ckbxInversionDataIncludeInversionInformation.Checked) && (ckbxWetOutDataIncludeWetOutInformation.Checked))
                    {
                        // .... ... Inversion data
                        newInversionComment = tbxInversionDataCommentsEdit.Text;
                        newPipeType = ddlInversionDataInversionPipeType.SelectedValue;
                        newPipeCondition = ddlInversionDataPipeCondition.SelectedValue;
                        newGroundMoisture = ddlInversionDataGroundMoisture.SelectedValue;
                        newBoilerSize = decimal.Round(decimal.Parse(tbxInversionDataBoilerSize.Text), 0);
                        newPumpTotalCapacity = decimal.Round(decimal.Parse(tbxInversionDataPumpsTotalCapacity.Text), 0);
                        newLayFlatSize = decimal.Round(decimal.Parse(tbxInversionDataLayflatSize.Text), 0);
                        newLayFlatQuantityTotal = decimal.Round(decimal.Parse(tbxInversionDataLayflatQuantityTotal.Text), 0);

                        newWaterStartTemp = decimal.Round(decimal.Parse(tbxInversionDataWaterStartTempTs.Text), 0);
                        newTemp1 = decimal.Round(decimal.Parse(tbxInversionDataTempT1.Text), 0);
                        newHoldAtT1 = decimal.Round(decimal.Parse(tbxInversionDataHoldAtT1For.Text), 1);
                        newTempT2 = decimal.Round(decimal.Parse(tbxInversionDataTempT2.Text), 0);
                        newCookAtT2 = decimal.Round(decimal.Parse(tbxInversionDataCookAtT2For.Text), 0);
                        newCoolDownFor = decimal.Round(decimal.Parse(tbxInversionDataCoolDownFor.Text), 0);
                        newCoolToTemp = decimal.Round(decimal.Parse(tbxInversionDataCoolToTemp.Text), 0);
                        newDropInPipeRun = decimal.Round(decimal.Parse(tbxInversionDataDropInPipeRun.Text), 1);
                        newPipeSlopOf = decimal.Round(decimal.Parse(tbxInversionDataPipeSlopeOf.Text), 2);

                        newF45F120 = decimal.Round(decimal.Parse(tbxInversionData45F120F.Text), 1);
                        newHold = decimal.Round(decimal.Parse(tbxInversionDataHold.Text), 1);
                        newF120F185 = decimal.Round(decimal.Parse(tbxInversionData120F185F.Text), 1);
                        newCookTime = decimal.Round(decimal.Parse(tbxInversionDataCookTime.Text), 1);
                        newCoolTime = decimal.Round(decimal.Parse(tbxInversionDataCoolTime.Text), 1);
                        newAproxTotal = decimal.Round(decimal.Parse(tbxInversionDataAproxTotal.Text), 1);

                        newWaterChangesPerHour = decimal.Round(decimal.Parse(tbxInversionDataWaterChangesPerHour.Text), 2);
                        newReturnWaterVelocity = decimal.Round(decimal.Parse(tbxInversionDataReturnWaterVelocity.Text), 2);
                        newLayflatBackPressure = decimal.Round(decimal.Parse(tbxInversionDataLayflatBackPressure.Text), 1);
                        newPumpLiftAtIdealHead = decimal.Round(decimal.Parse(tbxInversionDataPumpLiftAtIdealHead.Text), 1);
                        newWaterToFillLinerColumn = decimal.Round(decimal.Parse(tbxInversionDataWaterToFillLinerColumn.Text), 0);
                        newWaterPerFit = decimal.Round(decimal.Parse(tbxInversionDataWaterPerFit.Text), 2);
                        newInstallationResults = tbxInversionDataNotesAndInstallationResults.Text;
                        newInversionLinerTubeLabel = lblInversionDataLinerInfoGrey.Text;
                        newHeadsIdealLabel = lblInversionDataHeadsGrey.Text;
                        newPumpingAndCirculationLabel = lblInversionDataPumpingCirculationSubtitle.Text;
                    }

                    // ... Update
                    fullLengthLiningWorkDetails.UpdateWithWetOutInformation(workId, newGeneralClientId, newGeneralProposedLiningDate, newGeneralDeadlineLiningDate, newGeneralP1Date, newGeneralM1Date, newGeneralM2Date, newGeneralInstallDate, newGeneralFinalVideo, newGeneralIssueIdentified, newGeneralLfsIssue, newGeneralClientIssue, newGeneralSalesIssue, newGeneralIssueGivenToClient, newGeneralIssueResolved, newGeneralIssueInvestigation, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWidthId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMH, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampsRequired, newVideoLength, newPreFlushDate, newPreVideoDate, newCameraSkid, newLinerTuber, newResinId, newExcessResin, newPoundsDrums, newDrumDiameter, newHoistMaximumHeight, newHoistMinimumHeight, newDownDropTubeLenght, newPumpHeightAboveGround, newTubeResinToFeltFactor, newDateOfSheet, newEmployeeID, newRunDetails, newRunDetails2, newWetOutDate, newInstallDate, newInversionThickness, newLengthToLine, newPlusExtra, newForTurnOffset, newLengthToWetOut, newTubeMaxColdHead, newTubeMaxColdHeadPsi, newTubeMaxHotHead, newTubeMaxHotHeadPsi, newTubeIdealHead, newTubeIdealHeadPsi, newNetResinForTube, newNetResinForTubeUsgals, newNetResinForTubeDrumsIns, newNetResinForTubeLbsFt, newNetResinForTubeUsgFt, newExtraResinForMix, newExtraLbsForMix, newTotalMixQuantity, newTotalMixQuantityUsgals, newTotalMixQuantityDrumsIns, newInversionType, newDepthOfInversionMH, newTubeForColumn, newTubeForStartDry, newTotalTube, newDropTubeConnects, newAllowsHeadTo, newRollerGap, newHeightNeeded, newAvailable, newHoistHeight, newCommentsCipp, newResinLabel, newDrumContainsLabel, newLinerTubeLabel, newForLbDrumsLabel, newNetResinLabel, newCatalystLabel, newInversionComment, newPipeType, newPipeCondition, newGroundMoisture, newBoilerSize, newPumpTotalCapacity, newLayFlatSize, newLayFlatQuantityTotal, newWaterStartTemp, newTemp1, newHoldAtT1, newTempT2, newCookAtT2, newCoolDownFor, newCoolToTemp, newDropInPipeRun, newPipeSlopOf, newF45F120, newHold, newF120F185, newCookTime, newCoolTime, newAproxTotal, newWaterChangesPerHour, newReturnWaterVelocity, newLayflatBackPressure, newPumpLiftAtIdealHead, newWaterToFillLinerColumn, newWaterPerFit, newInstallationResults, newInversionLinerTubeLabel, newHeadsIdealLabel, newPumpingAndCirculationLabel, newAccessType, newP1Completed);
                }

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
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                Session["materialInformationTDS"] = materialInformationTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "fl_navigator2.aspx")
                {
                    url = "./fl_navigator2.aspx?source_page=fl_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "fl_summary.aspx")
                {
                    string activeTab = hdfActiveTab.Value;
                    url = "./fl_summary.aspx?source_page=fl_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void Save2()
        {
            //Save changes without validate

            // Laterals Gridview
            // ... If the gridview is edition mode
            if (grdLaterals.EditIndex >= 0)
            {
                grdLaterals.UpdateRow(grdLaterals.EditIndex, true);
            }

            // Save Lateral data
            GrdFLAddLateralsNewAdd();

            // Catalysts Gridview
            if (ckbxWetOutDataIncludeWetOutInformation.Checked)
            {
                // ... If the gridview is edition mode
                if (grdCatalysts.EditIndex >= 0)
                {
                    grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
                }

                // Save Lateral data
                GrdCatalystsAdd();
            }

            // Save data
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            // Get Section Details
            // ... FullLengthLiningSectionDetails data
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

            // ... assetSewerMH data
            string newUsmhAddress = ""; if (tbxM1DataUsmhAddress.Text != "") newUsmhAddress = tbxM1DataUsmhAddress.Text.Trim();
            string newDsmhAddress = ""; if (tbxM1DataDsmhAddress.Text != "") newDsmhAddress = tbxM1DataDsmhAddress.Text.Trim();

            // Update section details
            FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
            fullLengthLiningSectionDetails.Update(workId, assetId, newStreet, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newUsmh, newDsmh, newUsmhAddress, newDsmhAddress, newGeneralSubArea, newThickness);

            // Get generalData
            // ... Ra new data
            DateTime? newPreFlushDate = null;
            if (tkrdpGeneralPreFlushDate.Visible == true)
            {
                if (tkrdpGeneralPreFlushDate.SelectedDate.HasValue)
                {
                    newPreFlushDate = tkrdpGeneralPreFlushDate.SelectedDate.Value;
                }
            }
            else
            {
                if (tkrdpGeneralPreFlushDateReadOnly.SelectedDate.HasValue)
                {
                    newPreFlushDate = tkrdpGeneralPreFlushDateReadOnly.SelectedDate.Value;
                }
            }

            DateTime? newPreVideoDate = null;
            if (tkrdpGeneralPreVideoDate.Visible == true)
            {
                if (tkrdpGeneralPreVideoDate.SelectedDate.HasValue)
                {
                    newPreVideoDate = tkrdpGeneralPreVideoDate.SelectedDate.Value;
                }
            }
            else
            {
                if (tkrdpGeneralPreVideoDateReadOnly.SelectedDate.HasValue)
                {
                    newPreVideoDate = tkrdpGeneralPreVideoDateReadOnly.SelectedDate.Value; ;
                }
            }

            // ... FullLengthLining data
            string newGeneralClientId = ""; if (tbxGeneralClientId.Text != "") newGeneralClientId = tbxGeneralClientId.Text.Trim();
            DateTime? newGeneralProposedLiningDate = null; if (tkrdpGeneralProposedLiningDate.SelectedDate.HasValue) newGeneralProposedLiningDate = tkrdpGeneralProposedLiningDate.SelectedDate.Value;
            DateTime? newGeneralDeadlineLiningDate = null; if (tkrdpGeneralDeadlineLiningDate.SelectedDate.HasValue) newGeneralDeadlineLiningDate = tkrdpGeneralDeadlineLiningDate.SelectedDate.Value;
            DateTime? newGeneralP1Date = null; if (tkrdpPrepDataP1Date.SelectedDate.HasValue) newGeneralP1Date = tkrdpPrepDataP1Date.SelectedDate.Value;
            DateTime? newGeneralM1Date = null; if (tkrdpM1DataM1Date.SelectedDate.HasValue) newGeneralM1Date = tkrdpM1DataM1Date.SelectedDate.Value;
            DateTime? newGeneralM2Date = null; if (tkrdpM2DataM2Date.SelectedDate.HasValue) newGeneralM2Date = tkrdpM2DataM2Date.SelectedDate.Value;
            DateTime? newGeneralInstallDate = null; if (tkrdpInstallDataInstallDate.SelectedDate.HasValue) newGeneralInstallDate = tkrdpInstallDataInstallDate.SelectedDate.Value;
            DateTime? newGeneralFinalVideo = null; if (tkrdpInstallDataFinalVideoDate.SelectedDate.HasValue) newGeneralFinalVideo = tkrdpInstallDataFinalVideoDate.SelectedDate.Value;
            bool newGeneralIssueIdentified = ckbxGeneralIssueIdentified.Checked;
            bool newGeneralLfsIssue = ckbxGeneralLfsIssue.Checked;
            bool newGeneralClientIssue = ckbxGeneralClientIssue.Checked;
            bool newGeneralSalesIssue = ckbxGeneralSalesIssue.Checked;
            bool newGeneralIssueGivenToClient = ckbxGeneralIssueGivenToClient.Checked;
            bool newGeneralIssueResolved = ckbxGeneralIssueResolved.Checked;
            bool newGeneralIssueInvestigation = ckbxGeneralIssueInvestigation.Checked;
            int? newPrepDataCXIsRemoved = null; if (tbxPrepDataCXIsRemoved.Text != "") newPrepDataCXIsRemoved = Int32.Parse(tbxPrepDataCXIsRemoved.Text.Trim());
            bool newRoboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;
            DateTime? newRoboticPrepCompletedDate = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) newRoboticPrepCompletedDate = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;
            bool newP1Completed = ckbxPrepDataP1Completed.Checked;

            // ... WorkFullLengthLiningM1 data                    
            string newMeasurementsTakenBy = ""; if (tbxM1DataMeasurementsTakenBy.Text != "") newMeasurementsTakenBy = tbxM1DataMeasurementsTakenBy.Text.Trim();
            string newMaterial = ddlM1DataMaterial.SelectedValue;
            string newTrafficControl = ddlM1DataTrafficControl.SelectedValue;
            string newSiteDetails = ""; if (ddlM1DataSiteDetails.SelectedValue != "(Select)") newSiteDetails = ddlM1DataSiteDetails.SelectedValue;
            bool newPipeSizeChange = ckbxM1DataPipeSizeChange.Checked;
            bool newStandardByPass = ckbxM1DataStandardBypass.Checked;
            string newStandardBypassComments = ""; if (tbxM1DataStandardBypassComments.Text != "") newStandardBypassComments = tbxM1DataStandardBypassComments.Text.Trim();
            string newTrafficControlDetails = ""; if (tbxM1DataTrafficControlDetails.Text != "") newTrafficControlDetails = tbxM1DataTrafficControlDetails.Text.Trim();
            string newMeasurementType = ddlM1DataMeasurementType.SelectedValue;
            string newMeasuredFromMh = null; if (tbxM1DataMeasuredFromMh.Visible) newMeasuredFromMh = tbxM1DataMeasuredFromMh.Text; else newMeasuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
            string newVideoDoneFromMh = ""; if (tbxM1DataVideoDoneFromMh.Visible) newVideoDoneFromMh = tbxM1DataVideoDoneFromMh.Text; else newVideoDoneFromMh = ddlM1DataVideoDoneFromMh.SelectedValue;
            string newVideoDoneToMh = ""; if (tbxM1DataVideoDoneToMh.Visible) newVideoDoneToMh = tbxM1DataVideoDoneToMh.Text; else newVideoDoneToMh = ddlM1DataVideoDoneToMh.SelectedValue;
            string newAccessType = ""; if (ddlM1DataAccessType.SelectedValue != "(Select)") newAccessType = ddlM1DataAccessType.SelectedValue;

            // ... ... For header values
            string newVideoLength = tbxVideoLength.Text.Trim();

            // ... WorkFullLengthLiningM2 data
            string newMeasurementTakenByM2 = tbxM2DataMeasurementsTakenBy.Text.Trim();
            bool newDropPipe = ckbxM2DataDropPipe.Checked;
            string newDropPipeInvertDepth = tbxM2DataDropPipeInvertdepth.Text.Trim();
            int? newCappedLaterals = null; if (tbxM2DataCappedLaterals.Text != "") newCappedLaterals = Int32.Parse(tbxM2DataCappedLaterals.Text.Trim());
            string newLineWidthId = ""; if (tbxM2DataLineWidthId.Text != "") newLineWidthId = tbxM2DataLineWidthId.Text.Trim();
            string newHydrantAddress = ""; if (tbxM2DataHydrantAddress.Text != "") newHydrantAddress = tbxM2DataHydrantAddress.Text.Trim();
            string newHydroWireWithin10FtOfInversionMH = ddlM2DataHydroWireWithin10FtOfInversionMh.SelectedValue.Trim();
            string newDistanceToInversionMH = ""; if (tbxM2DataDistanceToInversionMH.Text != "") newDistanceToInversionMH = tbxM2DataDistanceToInversionMH.Text.Trim();
            string newSurfaceGrade = ""; if (ddlM2DataSurfaceGrade.SelectedValue != "(Select)") newSurfaceGrade = ddlM2DataSurfaceGrade.SelectedValue;
            bool newHydroPulley = cbxM2DataHydroPulley.Checked;
            bool newFridgeCart = cbxM2DataFridgeCart.Checked;
            bool newTwoPump = cbxM2DataTwoPump.Checked;
            bool newSixBypass = cbxM2DataSixBypass.Checked;
            bool newScaffolding = cbxM2DataScaffolding.Checked;
            bool newWinchExtension = cbxM2DataWinchExtension.Checked;
            bool newExtraGenerator = cbxM2DataExtraGenerator.Checked;
            bool newGreyCableExtension = cbxM2DataGreyCableExtension.Checked;
            bool newEasementMats = cbxM2DataEasementMats.Checked;
            bool newRampsRequired = cbxM2DataRampsRequired.Checked;
            bool newCameraSkid = cbxM2DataCameraSkid.Checked;

            // ... Update work details
            FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);

            // ... ... If it doen's have wet out information and inversion information
            if ((!ckbxWetOutDataIncludeWetOutInformation.Checked) && (!ckbxInversionDataIncludeInversionInformation.Checked))
            {
                fullLengthLiningWorkDetails.Update(workId, newGeneralClientId, newGeneralProposedLiningDate, newGeneralDeadlineLiningDate, newGeneralP1Date, newGeneralM1Date, newGeneralM2Date, newGeneralInstallDate, newGeneralFinalVideo, newGeneralIssueIdentified, newGeneralLfsIssue, newGeneralClientIssue, newGeneralSalesIssue, newGeneralIssueGivenToClient, newGeneralIssueResolved, newGeneralIssueInvestigation, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWidthId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMH, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampsRequired, newVideoLength, newPreFlushDate, newPreVideoDate, newCameraSkid, newAccessType, newP1Completed);
            }
            else
            {
                // Wet out data
                string newLinerTuber = "";
                int newResinId = 0;
                decimal newExcessResin = 0;
                string newPoundsDrums = "";
                decimal newDrumDiameter = 0;
                decimal newHoistMaximumHeight = 0;
                decimal newHoistMinimumHeight = 0;
                decimal newDownDropTubeLenght = 0;
                decimal newPumpHeightAboveGround = 0;
                int newTubeResinToFeltFactor = 0;
                DateTime newDateOfSheet = DateTime.Now;
                int newEmployeeID = 0;
                string newRunDetails = "";
                string newRunDetails2 = "";
                DateTime newWetOutDate = DateTime.Now;
                DateTime? newInstallDate = null;
                string newInversionThickness = "";
                Distance lengthToLine = new Distance("0");
                decimal newLengthToLine = 0;
                decimal newPlusExtra = 0;
                decimal newForTurnOffset = 0;
                decimal newLengthToWetOut = 0;

                decimal newTubeMaxColdHead = 0;
                decimal newTubeMaxColdHeadPsi = 0;
                decimal newTubeMaxHotHead = 0;
                decimal newTubeMaxHotHeadPsi = 0;
                decimal newTubeIdealHead = 0;
                decimal newTubeIdealHeadPsi = 0;

                decimal newNetResinForTube = 0;
                decimal newNetResinForTubeUsgals = 0;
                string newNetResinForTubeDrumsIns = "";
                decimal newNetResinForTubeLbsFt = 0;
                decimal newNetResinForTubeUsgFt = 0;

                int newExtraResinForMix = 0;
                decimal newExtraLbsForMix = 0;
                decimal newTotalMixQuantity = 0;
                decimal newTotalMixQuantityUsgals = 0;
                string newTotalMixQuantityDrumsIns = "";

                string newInversionType = "";
                decimal newDepthOfInversionMH = 0;
                decimal newTubeForColumn = 0;
                decimal newTubeForStartDry = 0;
                decimal newTotalTube = 0;
                string newDropTubeConnects = "";
                decimal newAllowsHeadTo = 0;
                decimal newRollerGap = 0;

                decimal newHeightNeeded = 0;
                string newAvailable = "";
                string newHoistHeight = "";
                string newCommentsCipp = "";

                string newResinLabel = "";
                string newDrumContainsLabel = "";
                string newLinerTubeLabel = "";
                string newForLbDrumsLabel = "";
                string newNetResinLabel = "";
                string newCatalystLabel = "";

                if (ckbxWetOutDataIncludeWetOutInformation.Checked) 
                {
                    // .... ... Wet Out Sheet
                    newLinerTuber = ddlWetOutDataLinerTube.SelectedValue;
                    newResinId = Int32.Parse(ddlWetOutDataResins.SelectedValue);
                    newExcessResin = decimal.Round(decimal.Parse(tbxWetOutDataExcessResin.Text), 1);
                    newPoundsDrums = ddlWetOutDataPoundsDrums.SelectedValue;
                    newDrumDiameter = decimal.Round(decimal.Parse(tbxWetOutDataDrumDiameter.Text), 1);
                    newHoistMaximumHeight = decimal.Round(decimal.Parse(tbxWetOutDataHoistMaximumHeight.Text), 0);
                    newHoistMinimumHeight = decimal.Round(decimal.Parse(tbxWetOutDataHoistMinimumHeight.Text), 0);
                    newDownDropTubeLenght = decimal.Round(decimal.Parse(tbxWetOutDataDownDropTubeLength.Text), 0);
                    newPumpHeightAboveGround = decimal.Round(decimal.Parse(tbxWetOutDataPumpHeightAboveGround.Text), 2);
                    newTubeResinToFeltFactor = Int32.Parse(tbxWetOutDataTubeResinToFeltFactor.Text);

                    newDateOfSheet = DateTime.Parse(tbxWetOutDataDateOfSheet.Text);
                    newEmployeeID = Int32.Parse(ddlWetOutDataMadeBy.SelectedValue);                                       

                    foreach (ListItem lst in cbxlSectionId.Items)
                    {
                        if (lst.Selected)
                        {
                            newRunDetails = newRunDetails + lst.Value + ">";
                        }
                    }
                    newRunDetails = newRunDetails.Substring(0, newRunDetails.Length - 1);

                    newRunDetails2 = ddlWetOutDataRunDetails2.SelectedValue;
                    newWetOutDate = (DateTime)tkrdpWetOutDataWetOutDate.SelectedDate;
                                        
                    if (tkrdpInstallDataInstallDate.SelectedDate.ToString() != "")
                    {
                        newInstallDate = (DateTime)tkrdpInstallDataInstallDate.SelectedDate;
                    }

                    newInversionThickness = ddlThickness.SelectedValue;
                    lengthToLine = new Distance(tbxWetOutDataLengthToLine.Text);
                    newLengthToLine = decimal.Round(decimal.Parse(lengthToLine.ToStringInEng3()), 1);
                    newPlusExtra = decimal.Round(decimal.Parse(tbxWetOutDataPlusExtra.Text), 0);
                    newForTurnOffset = decimal.Round(decimal.Parse(tbxWetOutDataForTurnOffset.Text), 0);
                    newLengthToWetOut = decimal.Round(decimal.Parse(tbxWetOutDataLengthtToWetOut.Text), 1);

                    newTubeMaxColdHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxColdHead.Text), 1);
                    newTubeMaxColdHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxColdHeadPSI.Text), 1);
                    newTubeMaxHotHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxHotHead.Text), 1);
                    newTubeMaxHotHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxHotHeadPSI.Text), 1);
                    newTubeIdealHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeIdealHead.Text), 1);
                    newTubeIdealHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeIdealHeadPSI.Text), 1);

                    newNetResinForTube = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTube.Text), 0);
                    newNetResinForTubeUsgals = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeUsgals.Text), 1);
                    newNetResinForTubeDrumsIns = tbxWetOutDataNetResinForTubeDrumsIns.Text;
                    newNetResinForTubeLbsFt = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeLbsFt.Text), 2);
                    newNetResinForTubeUsgFt = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeUsgFt.Text), 3);

                    newExtraResinForMix = Int32.Parse(tbxWetOutDataExtraResinForMix.Text);
                    newExtraLbsForMix = decimal.Round(decimal.Parse(tbxWetOutDataExtraLbsForMix.Text), 2);
                    newTotalMixQuantity = decimal.Round(decimal.Parse(tbxWetOutDataTotalMixQuantity.Text), 0);
                    newTotalMixQuantityUsgals = decimal.Round(decimal.Parse(tbxWetOutDataTotalMixQuantityUsgals.Text), 1);
                    newTotalMixQuantityDrumsIns = tbxWetOutDataTotalMixQuantityDrumsIns.Text;

                    newInversionType = ddlWetOutDataInversionType.SelectedValue;
                    newDepthOfInversionMH = decimal.Round(decimal.Parse(tbxWetOutDataDepthOfInversionMH.Text), 0);
                    newTubeForColumn = decimal.Round(decimal.Parse(tbxWetOutDataTubeForColumn.Text), 0);
                    newTubeForStartDry = decimal.Round(decimal.Parse(tbxWetOutDataTubeForStartDry.Text), 0);
                    newTotalTube = decimal.Round(decimal.Parse(tbxWetOutDataTotalTube.Text), 1);
                    newDropTubeConnects = tbxWetOutDataDropTubeConnects.Text;
                    newAllowsHeadTo = decimal.Round(decimal.Parse(tbxWetOutDataAllowsHeadTo.Text), 0);
                    newRollerGap = decimal.Round(decimal.Parse(tbxWetOutDataRollerGap.Text), 0);

                    newHeightNeeded = decimal.Round(decimal.Parse(tbxWetOutDataHeightNeeded.Text), 0);
                    newAvailable = tbxWetOutDataAvailable.Text;
                    newHoistHeight = tbxWetOutDataHoistHeight.Text;
                    newCommentsCipp = tbxWetOutDataNotes.Text;
                    
                    newResinLabel = lblWetOutDataResinGray.Text;
                    newDrumContainsLabel = lblWetOutDataDrumContainsGray.Text;
                    newLinerTubeLabel = lblWetOutDataLinerTubeGray.Text;
                    newForLbDrumsLabel = lblWetOutDataLbDrumsGrey.Text;
                    newNetResinLabel = lblWetOutDataNetResinGrey.Text;
                    newCatalystLabel = lblWetOutDataCatalystGrey.Text;
                }

                // Inversion data
                string newInversionComment = "";
                string newPipeType = "";
                string newPipeCondition = "";
                string newGroundMoisture = "";
                decimal newBoilerSize = 0;
                decimal newPumpTotalCapacity = 0;
                decimal newLayFlatSize = 0;
                decimal newLayFlatQuantityTotal = 0;

                decimal newWaterStartTemp = 0;
                decimal newTemp1 = 0;
                decimal newHoldAtT1 = 0;
                decimal newTempT2 = 0;
                decimal newCookAtT2 = 0;
                decimal newCoolDownFor = 0;
                decimal newCoolToTemp = 0;
                decimal newDropInPipeRun = 0;
                decimal newPipeSlopOf = 0;

                decimal newF45F120 = 0;
                decimal newHold = 0;
                decimal newF120F185 = 0;
                decimal newCookTime = 0;
                decimal newCoolTime = 0;
                decimal newAproxTotal = 0;

                decimal newWaterChangesPerHour = 0;
                decimal newReturnWaterVelocity = 0;
                decimal newLayflatBackPressure = 0;
                decimal newPumpLiftAtIdealHead = 0;
                decimal newWaterToFillLinerColumn = 0;
                decimal newWaterPerFit = 0;
                string newInstallationResults = "";
                string newInversionLinerTubeLabel = "";
                string newHeadsIdealLabel = "";
                string newPumpingAndCirculationLabel = "";

                if ((ckbxInversionDataIncludeInversionInformation.Checked) && (ckbxWetOutDataIncludeWetOutInformation.Checked))
                {
                    // .... ... Inversion data
                    newInversionComment = tbxInversionDataCommentsEdit.Text;
                    newPipeType = ddlInversionDataInversionPipeType.SelectedValue;
                    newPipeCondition = ddlInversionDataPipeCondition.SelectedValue;
                    newGroundMoisture = ddlInversionDataGroundMoisture.SelectedValue;
                    newBoilerSize = decimal.Round(decimal.Parse(tbxInversionDataBoilerSize.Text), 0);
                    newPumpTotalCapacity = decimal.Round(decimal.Parse(tbxInversionDataPumpsTotalCapacity.Text), 0);
                    newLayFlatSize = decimal.Round(decimal.Parse(tbxInversionDataLayflatSize.Text), 0);
                    newLayFlatQuantityTotal = decimal.Round(decimal.Parse(tbxInversionDataLayflatQuantityTotal.Text), 0);
                    
                    newWaterStartTemp = decimal.Round(decimal.Parse(tbxInversionDataWaterStartTempTs.Text), 0);
                    newTemp1 = decimal.Round(decimal.Parse(tbxInversionDataTempT1.Text), 0);
                    newHoldAtT1 = decimal.Round(decimal.Parse(tbxInversionDataHoldAtT1For.Text), 1);
                    newTempT2 = decimal.Round(decimal.Parse(tbxInversionDataTempT2.Text), 0);
                    newCookAtT2 = decimal.Round(decimal.Parse(tbxInversionDataCookAtT2For.Text), 0);
                    newCoolDownFor = decimal.Round(decimal.Parse(tbxInversionDataCoolDownFor.Text), 0);
                    newCoolToTemp = decimal.Round(decimal.Parse(tbxInversionDataCoolToTemp.Text), 0);
                    newDropInPipeRun = decimal.Round(decimal.Parse(tbxInversionDataDropInPipeRun.Text), 1);
                    newPipeSlopOf = decimal.Round(decimal.Parse(tbxInversionDataPipeSlopeOf.Text), 2);

                    newF45F120 = decimal.Round(decimal.Parse(tbxInversionData45F120F.Text), 1);
                    newHold = decimal.Round(decimal.Parse(tbxInversionDataHold.Text), 1);
                    newF120F185 = decimal.Round(decimal.Parse(tbxInversionData120F185F.Text), 1);
                    newCookTime = decimal.Round(decimal.Parse(tbxInversionDataCookTime.Text), 1);
                    newCoolTime = decimal.Round(decimal.Parse(tbxInversionDataCoolTime.Text), 1);
                    newAproxTotal = decimal.Round(decimal.Parse(tbxInversionDataAproxTotal.Text), 1);

                    newWaterChangesPerHour = decimal.Round(decimal.Parse(tbxInversionDataWaterChangesPerHour.Text), 2);
                    newReturnWaterVelocity = decimal.Round(decimal.Parse(tbxInversionDataReturnWaterVelocity.Text), 2);
                    newLayflatBackPressure = decimal.Round(decimal.Parse(tbxInversionDataLayflatBackPressure.Text), 1);
                    newPumpLiftAtIdealHead = decimal.Round(decimal.Parse(tbxInversionDataPumpLiftAtIdealHead.Text), 1);
                    newWaterToFillLinerColumn = decimal.Round(decimal.Parse(tbxInversionDataWaterToFillLinerColumn.Text), 0);
                    newWaterPerFit = decimal.Round(decimal.Parse(tbxInversionDataWaterPerFit.Text), 2);
                    newInstallationResults = tbxInversionDataNotesAndInstallationResults.Text;
                    newInversionLinerTubeLabel = lblInversionDataLinerInfoGrey.Text;
                    newHeadsIdealLabel = lblInversionDataHeadsGrey.Text;
                    newPumpingAndCirculationLabel = lblInversionDataPumpingCirculationSubtitle.Text;
                }
                
                // ... Update
                fullLengthLiningWorkDetails.UpdateWithWetOutInformation(workId, newGeneralClientId, newGeneralProposedLiningDate, newGeneralDeadlineLiningDate, newGeneralP1Date, newGeneralM1Date, newGeneralM2Date, newGeneralInstallDate, newGeneralFinalVideo, newGeneralIssueIdentified, newGeneralLfsIssue, newGeneralClientIssue, newGeneralSalesIssue, newGeneralIssueGivenToClient, newGeneralIssueResolved, newGeneralIssueInvestigation, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWidthId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMH, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampsRequired, newVideoLength, newPreFlushDate, newPreVideoDate, newCameraSkid, newLinerTuber, newResinId, newExcessResin, newPoundsDrums, newDrumDiameter, newHoistMaximumHeight, newHoistMinimumHeight, newDownDropTubeLenght, newPumpHeightAboveGround, newTubeResinToFeltFactor, newDateOfSheet, newEmployeeID, newRunDetails, newRunDetails2, newWetOutDate, newInstallDate, newInversionThickness, newLengthToLine, newPlusExtra, newForTurnOffset, newLengthToWetOut, newTubeMaxColdHead, newTubeMaxColdHeadPsi, newTubeMaxHotHead, newTubeMaxHotHeadPsi, newTubeIdealHead, newTubeIdealHeadPsi, newNetResinForTube, newNetResinForTubeUsgals, newNetResinForTubeDrumsIns, newNetResinForTubeLbsFt, newNetResinForTubeUsgFt, newExtraResinForMix, newExtraLbsForMix, newTotalMixQuantity, newTotalMixQuantityUsgals, newTotalMixQuantityDrumsIns, newInversionType, newDepthOfInversionMH, newTubeForColumn, newTubeForStartDry, newTotalTube, newDropTubeConnects, newAllowsHeadTo, newRollerGap, newHeightNeeded, newAvailable, newHoistHeight, newCommentsCipp, newResinLabel, newDrumContainsLabel, newLinerTubeLabel, newForLbDrumsLabel, newNetResinLabel, newCatalystLabel, newInversionComment, newPipeType, newPipeCondition, newGroundMoisture, newBoilerSize, newPumpTotalCapacity, newLayFlatSize, newLayFlatQuantityTotal, newWaterStartTemp, newTemp1, newHoldAtT1, newTempT2, newCookAtT2, newCoolDownFor, newCoolToTemp, newDropInPipeRun, newPipeSlopOf, newF45F120, newHold, newF120F185, newCookTime, newCoolTime, newAproxTotal, newWaterChangesPerHour, newReturnWaterVelocity, newLayflatBackPressure, newPumpLiftAtIdealHead, newWaterToFillLinerColumn, newWaterPerFit, newInstallationResults, newInversionLinerTubeLabel, newHeadsIdealLabel, newPumpingAndCirculationLabel, newAccessType, newP1Completed);
            }

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
            Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
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
                // Laterals Gridview
                // ... If the gridview is edition mode
                if (grdLaterals.EditIndex >= 0)
                {
                    grdLaterals.UpdateRow(grdLaterals.EditIndex, true);
                }

                // Save Lateral data
                GrdFLAddLateralsNewAdd();

                // Catalysts Gridview
                if (ckbxWetOutDataIncludeWetOutInformation.Checked)
                {
                    // ... If the gridview is edition mode
                    if (grdCatalysts.EditIndex >= 0)
                    {
                        grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
                    }

                    // Save Lateral data
                    GrdCatalystsAdd();
                }

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

                // Get Section Details
                // ... FullLengthLiningSectionDetails data
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

                // ... assetSewerMH data
                string newUsmhAddress = ""; if (tbxM1DataUsmhAddress.Text != "") newUsmhAddress = tbxM1DataUsmhAddress.Text.Trim();
                string newDsmhAddress = ""; if (tbxM1DataDsmhAddress.Text != "") newDsmhAddress = tbxM1DataDsmhAddress.Text.Trim();

                // Update section details
                FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
                fullLengthLiningSectionDetails.Update(workId, assetId, newStreet, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newUsmh, newDsmh, newUsmhAddress, newDsmhAddress, newGeneralSubArea, newThickness);

                // Get generalData
                // ... Ra new data
                DateTime? newPreFlushDate = null;
                if (tkrdpGeneralPreFlushDate.Visible == true)
                {
                    if (tkrdpGeneralPreFlushDate.SelectedDate.HasValue)
                    {
                        newPreFlushDate = tkrdpGeneralPreFlushDate.SelectedDate.Value;
                    }
                }
                else
                {
                    if (tkrdpGeneralPreFlushDateReadOnly.SelectedDate.HasValue)
                    {
                        newPreFlushDate = tkrdpGeneralPreFlushDateReadOnly.SelectedDate.Value;
                    }
                }

                DateTime? newPreVideoDate = null;
                if (tkrdpGeneralPreVideoDate.Visible == true)
                {
                    if (tkrdpGeneralPreVideoDate.SelectedDate.HasValue)
                    {
                        newPreVideoDate = tkrdpGeneralPreVideoDate.SelectedDate.Value;
                    }
                }
                else
                {
                    if (tkrdpGeneralPreVideoDateReadOnly.SelectedDate.HasValue)
                    {
                        newPreVideoDate = tkrdpGeneralPreVideoDateReadOnly.SelectedDate.Value; ;
                    }
                }

                // ... FullLengthLining data
                string newGeneralClientId = ""; if (tbxGeneralClientId.Text != "") newGeneralClientId = tbxGeneralClientId.Text.Trim();
                DateTime? newGeneralProposedLiningDate = null; if (tkrdpGeneralProposedLiningDate.SelectedDate.HasValue) newGeneralProposedLiningDate = tkrdpGeneralProposedLiningDate.SelectedDate.Value;
                DateTime? newGeneralDeadlineLiningDate = null; if (tkrdpGeneralDeadlineLiningDate.SelectedDate.HasValue) newGeneralDeadlineLiningDate = tkrdpGeneralDeadlineLiningDate.SelectedDate.Value;
                DateTime? newGeneralP1Date = null; if (tkrdpPrepDataP1Date.SelectedDate.HasValue) newGeneralP1Date = tkrdpPrepDataP1Date.SelectedDate.Value;
                DateTime? newGeneralM1Date = null; if (tkrdpM1DataM1Date.SelectedDate.HasValue) newGeneralM1Date = tkrdpM1DataM1Date.SelectedDate.Value;
                DateTime? newGeneralM2Date = null; if (tkrdpM2DataM2Date.SelectedDate.HasValue) newGeneralM2Date = tkrdpM2DataM2Date.SelectedDate.Value;
                DateTime? newGeneralInstallDate = null; if (tkrdpInstallDataInstallDate.SelectedDate.HasValue) newGeneralInstallDate = tkrdpInstallDataInstallDate.SelectedDate.Value;
                DateTime? newGeneralFinalVideo = null; if (tkrdpInstallDataFinalVideoDate.SelectedDate.HasValue) newGeneralFinalVideo = tkrdpInstallDataFinalVideoDate.SelectedDate.Value;
                bool newGeneralIssueIdentified = ckbxGeneralIssueIdentified.Checked;
                bool newGeneralLfsIssue = ckbxGeneralLfsIssue.Checked;
                bool newGeneralClientIssue = ckbxGeneralClientIssue.Checked;
                bool newGeneralSalesIssue = ckbxGeneralSalesIssue.Checked;
                bool newGeneralIssueGivenToClient = ckbxGeneralIssueGivenToClient.Checked;
                bool newGeneralIssueResolved = ckbxGeneralIssueResolved.Checked;
                bool newGeneralIssueInvestigation = ckbxGeneralIssueInvestigation.Checked;
                int? newPrepDataCXIsRemoved = null; if (tbxPrepDataCXIsRemoved.Text != "") newPrepDataCXIsRemoved = Int32.Parse(tbxPrepDataCXIsRemoved.Text.Trim());
                bool newRoboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;
                DateTime? newRoboticPrepCompletedDate = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) newRoboticPrepCompletedDate = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;
                bool newP1Completed = ckbxPrepDataP1Completed.Checked;

                // ... WorkFullLengthLiningM1 data                    
                string newMeasurementsTakenBy = ""; if (tbxM1DataMeasurementsTakenBy.Text != "") newMeasurementsTakenBy = tbxM1DataMeasurementsTakenBy.Text.Trim();
                string newMaterial = ddlM1DataMaterial.SelectedValue;
                string newTrafficControl = ddlM1DataTrafficControl.SelectedValue;
                string newSiteDetails = ""; if (ddlM1DataSiteDetails.SelectedValue != "(Select)") newSiteDetails = ddlM1DataSiteDetails.SelectedValue;
                bool newPipeSizeChange = ckbxM1DataPipeSizeChange.Checked;
                bool newStandardByPass = ckbxM1DataStandardBypass.Checked;
                string newStandardBypassComments = ""; if (tbxM1DataStandardBypassComments.Text != "") newStandardBypassComments = tbxM1DataStandardBypassComments.Text.Trim();
                string newTrafficControlDetails = ""; if (tbxM1DataTrafficControlDetails.Text != "") newTrafficControlDetails = tbxM1DataTrafficControlDetails.Text.Trim();
                string newMeasurementType = ddlM1DataMeasurementType.SelectedValue;
                string newMeasuredFromMh = ""; if (tbxM1DataMeasuredFromMh.Visible) newMeasuredFromMh = tbxM1DataMeasuredFromMh.Text; else newMeasuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
                string newVideoDoneFromMh = ""; if (tbxM1DataVideoDoneFromMh.Visible) newVideoDoneFromMh = tbxM1DataVideoDoneFromMh.Text; else newVideoDoneFromMh = ddlM1DataVideoDoneFromMh.SelectedValue;
                string newVideoDoneToMh = ""; if (tbxM1DataVideoDoneToMh.Visible) newVideoDoneToMh = tbxM1DataVideoDoneToMh.Text; else newVideoDoneToMh = ddlM1DataVideoDoneToMh.SelectedValue;
                string newAccessType = ""; if (ddlM1DataAccessType.SelectedValue != "(Select)") newAccessType = ddlM1DataAccessType.SelectedValue;

                // ... ... For header values
                string newVideoLength = tbxVideoLength.Text.Trim();

                // ... WorkFullLengthLiningM2 data
                string newMeasurementTakenByM2 = tbxM2DataMeasurementsTakenBy.Text.Trim();
                bool newDropPipe = ckbxM2DataDropPipe.Checked;
                string newDropPipeInvertDepth = tbxM2DataDropPipeInvertdepth.Text.Trim();
                int? newCappedLaterals = null; if (tbxM2DataCappedLaterals.Text != "") newCappedLaterals = Int32.Parse(tbxM2DataCappedLaterals.Text.Trim());
                string newLineWidthId = ""; if (tbxM2DataLineWidthId.Text != "") newLineWidthId = tbxM2DataLineWidthId.Text.Trim();
                string newHydrantAddress = ""; if (tbxM2DataHydrantAddress.Text != "") newHydrantAddress = tbxM2DataHydrantAddress.Text.Trim();
                string newHydroWireWithin10FtOfInversionMH = ddlM2DataHydroWireWithin10FtOfInversionMh.SelectedValue.Trim();
                string newDistanceToInversionMH = ""; if (tbxM2DataDistanceToInversionMH.Text != "") newDistanceToInversionMH = tbxM2DataDistanceToInversionMH.Text.Trim();
                string newSurfaceGrade = ""; if (ddlM2DataSurfaceGrade.SelectedValue != "(Select)") newSurfaceGrade = ddlM2DataSurfaceGrade.SelectedValue;
                bool newHydroPulley = cbxM2DataHydroPulley.Checked;
                bool newFridgeCart = cbxM2DataFridgeCart.Checked;
                bool newTwoPump = cbxM2DataTwoPump.Checked;
                bool newSixBypass = cbxM2DataSixBypass.Checked;
                bool newScaffolding = cbxM2DataScaffolding.Checked;
                bool newWinchExtension = cbxM2DataWinchExtension.Checked;
                bool newExtraGenerator = cbxM2DataExtraGenerator.Checked;
                bool newGreyCableExtension = cbxM2DataGreyCableExtension.Checked;
                bool newEasementMats = cbxM2DataEasementMats.Checked;
                bool newRampsRequired = cbxM2DataRampsRequired.Checked;
                bool newCameraSkid = cbxM2DataCameraSkid.Checked;

                // ... Update work details
                FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);

                // ... ... If it doen's have wet out information
                if (!ckbxWetOutDataIncludeWetOutInformation.Checked)
                {
                    fullLengthLiningWorkDetails.Update(workId, newGeneralClientId, newGeneralProposedLiningDate, newGeneralDeadlineLiningDate, newGeneralP1Date, newGeneralM1Date, newGeneralM2Date, newGeneralInstallDate, newGeneralFinalVideo, newGeneralIssueIdentified, newGeneralLfsIssue, newGeneralClientIssue, newGeneralSalesIssue, newGeneralIssueGivenToClient, newGeneralIssueResolved, newGeneralIssueInvestigation, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWidthId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMH, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampsRequired, newVideoLength, newPreFlushDate, newPreVideoDate, newCameraSkid, newAccessType, newP1Completed);
                }
                else
                {
                    // Wet out data
                    string newLinerTuber = "";
                    int newResinId = 0;
                    decimal newExcessResin = 0;
                    string newPoundsDrums = "";
                    decimal newDrumDiameter = 0;
                    decimal newHoistMaximumHeight = 0;
                    decimal newHoistMinimumHeight = 0;
                    decimal newDownDropTubeLenght = 0;
                    decimal newPumpHeightAboveGround = 0;
                    int newTubeResinToFeltFactor = 0;
                    DateTime newDateOfSheet = DateTime.Now;
                    int newEmployeeID = 0;
                    string newRunDetails = "";
                    string newRunDetails2 = "";
                    DateTime newWetOutDate = DateTime.Now;
                    DateTime? newInstallDate = null;
                    string newInversionThickness = "";
                    Distance lengthToLine = new Distance("0");
                    decimal newLengthToLine = 0;
                    decimal newPlusExtra = 0;
                    decimal newForTurnOffset = 0;
                    decimal newLengthToWetOut = 0;

                    decimal newTubeMaxColdHead = 0;
                    decimal newTubeMaxColdHeadPsi = 0;
                    decimal newTubeMaxHotHead = 0;
                    decimal newTubeMaxHotHeadPsi = 0;
                    decimal newTubeIdealHead = 0;
                    decimal newTubeIdealHeadPsi = 0;

                    decimal newNetResinForTube = 0;
                    decimal newNetResinForTubeUsgals = 0;
                    string newNetResinForTubeDrumsIns = "";
                    decimal newNetResinForTubeLbsFt = 0;
                    decimal newNetResinForTubeUsgFt = 0;

                    int newExtraResinForMix = 0;
                    decimal newExtraLbsForMix = 0;
                    decimal newTotalMixQuantity = 0;
                    decimal newTotalMixQuantityUsgals = 0;
                    string newTotalMixQuantityDrumsIns = "";

                    string newInversionType = "";
                    decimal newDepthOfInversionMH = 0;
                    decimal newTubeForColumn = 0;
                    decimal newTubeForStartDry = 0;
                    decimal newTotalTube = 0;
                    string newDropTubeConnects = "";
                    decimal newAllowsHeadTo = 0;
                    decimal newRollerGap = 0;

                    decimal newHeightNeeded = 0;
                    string newAvailable = "";
                    string newHoistHeight = "";
                    string newCommentsCipp = "";

                    string newResinLabel = "";
                    string newDrumContainsLabel = "";
                    string newLinerTubeLabel = "";
                    string newForLbDrumsLabel = "";
                    string newNetResinLabel = "";
                    string newCatalystLabel = "";

                    if (ckbxWetOutDataIncludeWetOutInformation.Checked)
                    {
                        // .... ... Wet Out Sheet
                        newLinerTuber = ddlWetOutDataLinerTube.SelectedValue;
                        newResinId = Int32.Parse(ddlWetOutDataResins.SelectedValue);
                        newExcessResin = decimal.Round(decimal.Parse(tbxWetOutDataExcessResin.Text), 1);
                        newPoundsDrums = ddlWetOutDataPoundsDrums.SelectedValue;
                        newDrumDiameter = decimal.Round(decimal.Parse(tbxWetOutDataDrumDiameter.Text), 1);
                        newHoistMaximumHeight = decimal.Round(decimal.Parse(tbxWetOutDataHoistMaximumHeight.Text), 0);
                        newHoistMinimumHeight = decimal.Round(decimal.Parse(tbxWetOutDataHoistMinimumHeight.Text), 0);
                        newDownDropTubeLenght = decimal.Round(decimal.Parse(tbxWetOutDataDownDropTubeLength.Text), 0);
                        newPumpHeightAboveGround = decimal.Round(decimal.Parse(tbxWetOutDataPumpHeightAboveGround.Text), 2);
                        newTubeResinToFeltFactor = Int32.Parse(tbxWetOutDataTubeResinToFeltFactor.Text);

                        newDateOfSheet = DateTime.Parse(tbxWetOutDataDateOfSheet.Text);
                        newEmployeeID = Int32.Parse(ddlWetOutDataMadeBy.SelectedValue);

                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                newRunDetails = newRunDetails + lst.Value + ">";
                            }
                        }
                        newRunDetails = newRunDetails.Substring(0, newRunDetails.Length - 1);

                        newRunDetails2 = ddlWetOutDataRunDetails2.SelectedValue;
                        newWetOutDate = (DateTime)tkrdpWetOutDataWetOutDate.SelectedDate;

                        if (tkrdpInstallDataInstallDate.SelectedDate.ToString() != "")
                        {
                            newInstallDate = (DateTime)tkrdpInstallDataInstallDate.SelectedDate;
                        }

                        newInversionThickness = ddlThickness.SelectedValue;
                        lengthToLine = new Distance(tbxWetOutDataLengthToLine.Text);
                        newLengthToLine = decimal.Round(decimal.Parse(lengthToLine.ToStringInEng3()), 1);
                        newPlusExtra = decimal.Round(decimal.Parse(tbxWetOutDataPlusExtra.Text), 0);
                        newForTurnOffset = decimal.Round(decimal.Parse(tbxWetOutDataForTurnOffset.Text), 0);
                        newLengthToWetOut = decimal.Round(decimal.Parse(tbxWetOutDataLengthtToWetOut.Text), 1);

                        newTubeMaxColdHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxColdHead.Text), 1);
                        newTubeMaxColdHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxColdHeadPSI.Text), 1);
                        newTubeMaxHotHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxHotHead.Text), 1);
                        newTubeMaxHotHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeMaxHotHeadPSI.Text), 1);
                        newTubeIdealHead = decimal.Round(decimal.Parse(tbxWetOutDataTubeIdealHead.Text), 1);
                        newTubeIdealHeadPsi = decimal.Round(decimal.Parse(tbxWetOutDataTubeIdealHeadPSI.Text), 1);

                        newNetResinForTube = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTube.Text), 0);
                        newNetResinForTubeUsgals = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeUsgals.Text), 1);
                        newNetResinForTubeDrumsIns = tbxWetOutDataNetResinForTubeDrumsIns.Text;
                        newNetResinForTubeLbsFt = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeLbsFt.Text), 2);
                        newNetResinForTubeUsgFt = decimal.Round(decimal.Parse(tbxWetOutDataNetResinForTubeUsgFt.Text), 3);

                        newExtraResinForMix = Int32.Parse(tbxWetOutDataExtraResinForMix.Text);
                        newExtraLbsForMix = decimal.Round(decimal.Parse(tbxWetOutDataExtraLbsForMix.Text), 2);
                        newTotalMixQuantity = decimal.Round(decimal.Parse(tbxWetOutDataTotalMixQuantity.Text), 0);
                        newTotalMixQuantityUsgals = decimal.Round(decimal.Parse(tbxWetOutDataTotalMixQuantityUsgals.Text), 1);
                        newTotalMixQuantityDrumsIns = tbxWetOutDataTotalMixQuantityDrumsIns.Text;

                        newInversionType = ddlWetOutDataInversionType.SelectedValue;
                        newDepthOfInversionMH = decimal.Round(decimal.Parse(tbxWetOutDataDepthOfInversionMH.Text), 0);
                        newTubeForColumn = decimal.Round(decimal.Parse(tbxWetOutDataTubeForColumn.Text), 0);
                        newTubeForStartDry = decimal.Round(decimal.Parse(tbxWetOutDataTubeForStartDry.Text), 0);
                        newTotalTube = decimal.Round(decimal.Parse(tbxWetOutDataTotalTube.Text), 1);
                        newDropTubeConnects = tbxWetOutDataDropTubeConnects.Text;
                        newAllowsHeadTo = decimal.Round(decimal.Parse(tbxWetOutDataAllowsHeadTo.Text), 0);
                        newRollerGap = decimal.Round(decimal.Parse(tbxWetOutDataRollerGap.Text), 0);

                        newHeightNeeded = decimal.Round(decimal.Parse(tbxWetOutDataHeightNeeded.Text), 0);
                        newAvailable = tbxWetOutDataAvailable.Text;
                        newHoistHeight = tbxWetOutDataHoistHeight.Text;
                        newCommentsCipp = tbxWetOutDataNotes.Text;

                        newResinLabel = lblWetOutDataResinGray.Text;
                        newDrumContainsLabel = lblWetOutDataDrumContainsGray.Text;
                        newLinerTubeLabel = lblWetOutDataLinerTubeGray.Text;
                        newForLbDrumsLabel = lblWetOutDataLbDrumsGrey.Text;
                        newNetResinLabel = lblWetOutDataNetResinGrey.Text;
                        newCatalystLabel = lblWetOutDataCatalystGrey.Text;
                    }

                    // Inversion data
                    string newInversionComment = "";
                    string newPipeType = "";
                    string newPipeCondition = "";
                    string newGroundMoisture = "";
                    decimal newBoilerSize = 0;
                    decimal newPumpTotalCapacity = 0;
                    decimal newLayFlatSize = 0;
                    decimal newLayFlatQuantityTotal = 0;

                    decimal newWaterStartTemp = 0;
                    decimal newTemp1 = 0;
                    decimal newHoldAtT1 = 0;
                    decimal newTempT2 = 0;
                    decimal newCookAtT2 = 0;
                    decimal newCoolDownFor = 0;
                    decimal newCoolToTemp = 0;
                    decimal newDropInPipeRun = 0;
                    decimal newPipeSlopOf = 0;

                    decimal newF45F120 = 0;
                    decimal newHold = 0;
                    decimal newF120F185 = 0;
                    decimal newCookTime = 0;
                    decimal newCoolTime = 0;
                    decimal newAproxTotal = 0;

                    decimal newWaterChangesPerHour = 0;
                    decimal newReturnWaterVelocity = 0;
                    decimal newLayflatBackPressure = 0;
                    decimal newPumpLiftAtIdealHead = 0;
                    decimal newWaterToFillLinerColumn = 0;
                    decimal newWaterPerFit = 0;
                    string newInstallationResults = "";
                    string newInversionLinerTubeLabel = "";
                    string newHeadsIdealLabel = "";
                    string newPumpingAndCirculationLabel = "";

                    if ((ckbxInversionDataIncludeInversionInformation.Checked) && (ckbxWetOutDataIncludeWetOutInformation.Checked))
                    {
                        // .... ... Inversion data
                        newInversionComment = tbxInversionDataCommentsEdit.Text;
                        newPipeType = ddlInversionDataInversionPipeType.SelectedValue;
                        newPipeCondition = ddlInversionDataPipeCondition.SelectedValue;
                        newGroundMoisture = ddlInversionDataGroundMoisture.SelectedValue;
                        newBoilerSize = decimal.Round(decimal.Parse(tbxInversionDataBoilerSize.Text), 0);
                        newPumpTotalCapacity = decimal.Round(decimal.Parse(tbxInversionDataPumpsTotalCapacity.Text), 0);
                        newLayFlatSize = decimal.Round(decimal.Parse(tbxInversionDataLayflatSize.Text), 0);
                        newLayFlatQuantityTotal = decimal.Round(decimal.Parse(tbxInversionDataLayflatQuantityTotal.Text), 0);

                        newWaterStartTemp = decimal.Round(decimal.Parse(tbxInversionDataWaterStartTempTs.Text), 0);
                        newTemp1 = decimal.Round(decimal.Parse(tbxInversionDataTempT1.Text), 0);
                        newHoldAtT1 = decimal.Round(decimal.Parse(tbxInversionDataHoldAtT1For.Text), 1);
                        newTempT2 = decimal.Round(decimal.Parse(tbxInversionDataTempT2.Text), 0);
                        newCookAtT2 = decimal.Round(decimal.Parse(tbxInversionDataCookAtT2For.Text), 0);
                        newCoolDownFor = decimal.Round(decimal.Parse(tbxInversionDataCoolDownFor.Text), 0);
                        newCoolToTemp = decimal.Round(decimal.Parse(tbxInversionDataCoolToTemp.Text), 0);
                        newDropInPipeRun = decimal.Round(decimal.Parse(tbxInversionDataDropInPipeRun.Text), 1);
                        newPipeSlopOf = decimal.Round(decimal.Parse(tbxInversionDataPipeSlopeOf.Text), 2);

                        newF45F120 = decimal.Round(decimal.Parse(tbxInversionData45F120F.Text), 1);
                        newHold = decimal.Round(decimal.Parse(tbxInversionDataHold.Text), 1);
                        newF120F185 = decimal.Round(decimal.Parse(tbxInversionData120F185F.Text), 1);
                        newCookTime = decimal.Round(decimal.Parse(tbxInversionDataCookTime.Text), 1);
                        newCoolTime = decimal.Round(decimal.Parse(tbxInversionDataCoolTime.Text), 1);
                        newAproxTotal = decimal.Round(decimal.Parse(tbxInversionDataAproxTotal.Text), 1);

                        newWaterChangesPerHour = decimal.Round(decimal.Parse(tbxInversionDataWaterChangesPerHour.Text), 2);
                        newReturnWaterVelocity = decimal.Round(decimal.Parse(tbxInversionDataReturnWaterVelocity.Text), 2);
                        newLayflatBackPressure = decimal.Round(decimal.Parse(tbxInversionDataLayflatBackPressure.Text), 1);
                        newPumpLiftAtIdealHead = decimal.Round(decimal.Parse(tbxInversionDataPumpLiftAtIdealHead.Text), 1);
                        newWaterToFillLinerColumn = decimal.Round(decimal.Parse(tbxInversionDataWaterToFillLinerColumn.Text), 0);
                        newWaterPerFit = decimal.Round(decimal.Parse(tbxInversionDataWaterPerFit.Text), 2);
                        newInstallationResults = tbxInversionDataNotesAndInstallationResults.Text;
                        newInversionLinerTubeLabel = lblInversionDataLinerInfoGrey.Text;
                        newHeadsIdealLabel = lblInversionDataHeadsGrey.Text;
                        newPumpingAndCirculationLabel = lblInversionDataPumpingCirculationSubtitle.Text;
                    }

                    // ... Update
                    fullLengthLiningWorkDetails.UpdateWithWetOutInformation(workId, newGeneralClientId, newGeneralProposedLiningDate, newGeneralDeadlineLiningDate, newGeneralP1Date, newGeneralM1Date, newGeneralM2Date, newGeneralInstallDate, newGeneralFinalVideo, newGeneralIssueIdentified, newGeneralLfsIssue, newGeneralClientIssue, newGeneralSalesIssue, newGeneralIssueGivenToClient, newGeneralIssueResolved, newGeneralIssueInvestigation, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWidthId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMH, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampsRequired, newVideoLength, newPreFlushDate, newPreVideoDate, newCameraSkid, newLinerTuber, newResinId, newExcessResin, newPoundsDrums, newDrumDiameter, newHoistMaximumHeight, newHoistMinimumHeight, newDownDropTubeLenght, newPumpHeightAboveGround, newTubeResinToFeltFactor, newDateOfSheet, newEmployeeID, newRunDetails, newRunDetails2, newWetOutDate, newInstallDate, newInversionThickness, newLengthToLine, newPlusExtra, newForTurnOffset, newLengthToWetOut, newTubeMaxColdHead, newTubeMaxColdHeadPsi, newTubeMaxHotHead, newTubeMaxHotHeadPsi, newTubeIdealHead, newTubeIdealHeadPsi, newNetResinForTube, newNetResinForTubeUsgals, newNetResinForTubeDrumsIns, newNetResinForTubeLbsFt, newNetResinForTubeUsgFt, newExtraResinForMix, newExtraLbsForMix, newTotalMixQuantity, newTotalMixQuantityUsgals, newTotalMixQuantityDrumsIns, newInversionType, newDepthOfInversionMH, newTubeForColumn, newTubeForStartDry, newTotalTube, newDropTubeConnects, newAllowsHeadTo, newRollerGap, newHeightNeeded, newAvailable, newHoistHeight, newCommentsCipp, newResinLabel, newDrumContainsLabel, newLinerTubeLabel, newForLbDrumsLabel, newNetResinLabel, newCatalystLabel, newInversionComment, newPipeType, newPipeCondition, newGroundMoisture, newBoilerSize, newPumpTotalCapacity, newLayFlatSize, newLayFlatQuantityTotal, newWaterStartTemp, newTemp1, newHoldAtT1, newTempT2, newCookAtT2, newCoolDownFor, newCoolToTemp, newDropInPipeRun, newPipeSlopOf, newF45F120, newHold, newF120F185, newCookTime, newCoolTime, newAproxTotal, newWaterChangesPerHour, newReturnWaterVelocity, newLayflatBackPressure, newPumpLiftAtIdealHead, newWaterToFillLinerColumn, newWaterPerFit, newInstallationResults, newInversionLinerTubeLabel, newHeadsIdealLabel, newPumpingAndCirculationLabel, newAccessType, newP1Completed);
                }

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
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                Session["materialInformationTDS"] = materialInformationTDS;

                // Update database
                UpdateDatabase();

                // Restore datasets
                fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];

                fullLengthLiningSectionDetails.LoadByWorkId(workId, companyId);
                fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);
                fullLengthLiningTDS.LateralDetails.Clear();
                FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                fullLengthLiningLateralDetails.LoadForEdit(workId, assetId, companyId, currentProjectId);
                grdLaterals.DataBind();

                fullLengthLiningTDS.WetOutCatalystsDetails.Clear();
                FullLengthLiningWetOutCatalystsDetails fullLengthLiningWetOutCatalystsDetails = new FullLengthLiningWetOutCatalystsDetails(fullLengthLiningTDS);
                fullLengthLiningWetOutCatalystsDetails.LoadAll(workId, companyId);
                grdCatalysts.DataBind();

                // ... Store dataset
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

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

            if ((size != "") || (material != "") || (mn != "") || (live != "(Select)") || (videoDistance != "") || (clockPosition != "") || (distanceToCentre != "") || (comments != "") || (connectionType != "") || (requiresRoboticPrep) || (requiresRoboticPrepDate.HasValue) || (holdClientIssue) || (holdLFSIssue) || (dyeTestReq) || (dyeTestComplete.HasValue))
            {
                return true;            
            }

            return false;
        }



        private bool ValidateCatalystsFooter()
        {
            int catalystIdFooter = Int32.Parse(((DropDownList)grdCatalysts.FooterRow.FindControl("ddlNameFooter")).SelectedValue);

            decimal defaultPercentageByWeightFooter = -1;
            if (((TextBox)grdCatalysts.FooterRow.FindControl("tbxPercentageByWeightFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdCatalysts.FooterRow.FindControl("tbxPercentageByWeightFooter")).Text.Trim())))
                {
                    defaultPercentageByWeightFooter = decimal.Parse(((TextBox)grdCatalysts.FooterRow.FindControl("tbxPercentageByWeightFooter")).Text.Trim());
                }
            }

            if ((catalystIdFooter != -1) || (defaultPercentageByWeightFooter != -1))
            {
                return true;
            }

            return false;
        }



        private bool ValidatePage()
        {
            bool validData = true;

            // Validate general data
            Page.Validate("flData");

            if (Page.IsValid)
            {
                // Validate m1 data
                Page.Validate("flM1Data");
                if (!Page.IsValid)
                {
                    validData = false;
                }

                // Validate m2 data
                Page.Validate("flM2Data");
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

                // Validate wet out data
                if (ckbxWetOutDataIncludeWetOutInformation.Checked)
                {
                    Page.Validate("flWetOutData");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    // Validate catalysts
                    if (ValidateCatalystsFooter())
                    {
                        Page.Validate("catalystDataFooter");
                        if (!Page.IsValid)
                        {
                            validData = false;
                        }
                    }
                }

                // validate inversion data
                if ((ckbxInversionDataIncludeInversionInformation.Checked) && (ckbxWetOutDataIncludeWetOutInformation.Checked))
                {
                    Page.Validate("flInversionData");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }                    
                }
            }
            else
            {
                // If it's not valid
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
                if (!rfvM1DataAccessType.IsValid)
                {
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Access Type (M1)";
                }

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
            int sectionAssetId = Int32.Parse(hdfAssetId.Value);
            bool isNewMeasuredFromDsmh = false;

            FullLengthLiningLateralDetails flLateralDetails = new FullLengthLiningLateralDetails();
            flLateralDetails.LoadForEdit(workId, sectionAssetId, companyId, projectId);

            if (flLateralDetails.Table.Rows.Count == 0)
            {
                if (ddlM1DataMeasuredFromMh.SelectedValue == "DSMH")
                {
                    isNewMeasuredFromDsmh = true;
                    FullLengthLiningLateralDetails fllLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                    fllLateralDetails.ModifyLateralId();
                }
            }

            DB.Open();
            DB.BeginTransaction();
            try
            {              
                // Save lateral details
                // Save lateral details
                bool roboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;
                DateTime? roboticPrepCompletedCompleted = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) roboticPrepCompletedCompleted = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;

                FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                fullLengthLiningLateralDetails.Save(workId, projectId, sectionAssetId, countryId, provinceId, countyId, cityId, tbxVideoLength.Text.Trim(), companyId, isNewMeasuredFromDsmh, roboticPrepCompleted, roboticPrepCompletedCompleted);

                // Save catalyst details
                string newRunDetails = "";
                foreach (ListItem lst in cbxlSectionId.Items)
                {
                    if (lst.Selected)
                    {
                        newRunDetails = newRunDetails + lst.Value + ">";
                    }
                }
                newRunDetails = newRunDetails.Substring(0, newRunDetails.Length - 1);
                FullLengthLiningWetOutCatalystsDetails fullLengthLiningWetOutCatalystsDetails = new FullLengthLiningWetOutCatalystsDetails(fullLengthLiningTDS);
                fullLengthLiningWetOutCatalystsDetails.Save(companyId, newRunDetails, projectId);

                // Save section details
                FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
                fullLengthLiningSectionDetails.Save(countryId, provinceId, countyId, cityId, projectId, companyId);

                // Save work details
                FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                fullLengthLiningWorkDetails.Save(countryId, provinceId, countyId, cityId, projectId, sectionAssetId, companyId, ckbxWetOutDataIncludeWetOutInformation.Checked, ckbxInversionDataIncludeInversionInformation.Checked);

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
                fullLengthLiningTDS.AcceptChanges();
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

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



        private void FLLateralsSave(string lateralId, bool requiresRoboticPrep, DateTime? equiresRoboticPrepIssueCompleted, bool holdClientIssue, bool holdLFSIssue, bool dyeTestReq, DateTime? dyeTestComplete)
        {
            int workIdJl = Int32.Parse(hdfWorkIdJl.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            flatSectionJlTDSForFLL = new FlatSectionJlTDS();

            FlatSectionJlGateway flatSectionJlGateway = new FlatSectionJlGateway(flatSectionJlTDSForFLL);
            flatSectionJlGateway.LoadAllByWorkId(workIdJl, companyId);

            string latId = lateralId.Substring(3, lateralId.Length - 3);

            if (flatSectionJlGateway.Table.Rows.Count > 0)
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDSForFLL);

                flatSectionJl.UpdateAllLateralsFromFLL(latId, requiresRoboticPrep, equiresRoboticPrepIssueCompleted, holdClientIssue, holdLFSIssue, dyeTestReq, dyeTestComplete);
            }

            Session["flatSectionJlTDSForFLL"] = flatSectionJlTDSForFLL;
            flatSectionJlTDSForFLL.AcceptChanges();
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



        double RoundUp(double number, int digits)
        {
            return Math.Ceiling(number * Math.Pow(10, digits)) / Math.Pow(10, digits); 
        }



        double RoundDown(double number, int digits)
        {
            return Math.Floor(number * Math.Pow(10, digits)) / Math.Pow(10, digits);
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
