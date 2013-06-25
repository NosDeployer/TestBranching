// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick() {
    return false;
}



function OnKeyDown(e) {
    var menu = $find(tkrmTopId);
    var itemApply = menu.findItemByValue("mApply");

    if (window.event) {
        if (window.event.keyCode == 13) {
            itemApply.click();
            event.returnValue = false;
            event.cancel = true;
        }
    }
    else {
        if (e.which == 13) {
            itemApply.click();
            e.cancelBubble = true;
            e.preventDefault();
            e.stopPropagation();
            return false;
        }
    }
}



function SetValueInThickness() {
    var tbxConfirmedSize = document.getElementById(tbxConfirmedSizeId);
    var ddlThickness = document.getElementById(ddlThicknessId);

    // Update thickness
    if (tbxConfirmedSize.value == "200mm") {
        ddlThickness.options.selectedIndex = 4; ;
    }

    if (tbxConfirmedSize.value == "250mm") {
        ddlThickness.options.selectedIndex = 4; ;
    }

    if (tbxConfirmedSize.value == "300mm") {
        ddlThickness.options.selectedIndex = 5; ;
    }

    if (tbxConfirmedSize.value == "375mm") {
        ddlThickness.options.selectedIndex = 7; ;
    }

    if (tbxConfirmedSize.value == "450mm") {
        ddlThickness.options.selectedIndex = 12; ;
    }

    if (tbxConfirmedSize.value == '8"') {
        ddlThickness.options.selectedIndex = 4; ;
    }

    if (tbxConfirmedSize.value == '10"') {
        ddlThickness.options.selectedIndex = 4; ;
    }

    if (tbxConfirmedSize.value == '12"') {
        ddlThickness.options.selectedIndex = 5; ;
    }

    if (tbxConfirmedSize.value == '15"') {
        ddlThickness.options.selectedIndex = 7; ;
    }

    if (tbxConfirmedSize.value == '18"') {
        ddlThickness.options.selectedIndex = 12; ;
    }

    if (tbxConfirmedSize.value == '20"') {
        ddlThickness.options.selectedIndex = 12; ;
    }

    if (tbxConfirmedSize.value == '21"') {
        ddlThickness.options.selectedIndex = 12; ;
    }

    if (tbxConfirmedSize.value == '24"') {
        ddlThickness.options.selectedIndex = 12; ;
    }

    if (tbxConfirmedSize.value == '8') {
        ddlThickness.options.selectedIndex = 4; ;
    }

    if (tbxConfirmedSize.value == '10') {
        ddlThickness.options.selectedIndex = 4; ;
    }

    if (tbxConfirmedSize.value == '12') {
        ddlThickness.options.selectedIndex = 5; ;
    }

    if (tbxConfirmedSize.value == '15') {
        ddlThickness.options.selectedIndex = 7; ;
    }

    if (tbxConfirmedSize.value == '18') {
        ddlThickness.options.selectedIndex = 12; ;
    }

    if (tbxConfirmedSize.value == '20') {
        ddlThickness.options.selectedIndex = 12; ;
    }

    if (tbxConfirmedSize.value == '21') {
        ddlThickness.options.selectedIndex = 12; ;
    }

    if (tbxConfirmedSize.value == '24') {
        ddlThickness.options.selectedIndex = 12; ;
    }
}



function MakeLengthSame()
{
    var tbxLength = document.getElementById(tbxLengthId);    
    var tbxM1DataSteelTapeThroughSewer = document.getElementById(tbxM1DataSteelTapeThroughSewerId);    

    // Update length
    tbxLength.value = tbxM1DataSteelTapeThroughSewer.value;   
}



function MakeM1LengthSame()
{
     var tbxLength = document.getElementById(tbxLengthId);    
     var tbxM1DataSteelTapeThroughSewer = document.getElementById(tbxM1DataSteelTapeThroughSewerId);    

     tbxM1DataSteelTapeThroughSewer.value = tbxLength.value;
}



function tpGeneralDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);

    // Store Active Tab Index
    hdfActiveTab.value = "0";
}



function tpPrepDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);    
        
    // Store Active Tab Index    
    hdfActiveTab.value = "1";
}



function tpM1DataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    
    // Store Active Tab Index    
    hdfActiveTab.value = "2";
}



function tpM2DataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    
    // Store Active Tab Index
    hdfActiveTab.value = "3";
}



function tpWetOutClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "4";
}



function tpInversionCureClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "5";
}



function tpInstallDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    
    // Store Active Tab Index
    hdfActiveTab.value = "6";
}



function tpCommentDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    
    // Store Active Tab Index    
    hdfActiveTab.value = "7";
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) 
{
    var item = eventArgs.get_item().get_value();
    var hdfCurrentClientId = document.getElementById(hdfCurrentClientIdId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);
    var hdfWorkType = document.getElementById(hdfWorkTypeId);

    switch (item) {

        case "mAddSection":
            window.open("./../Common/project_add_sections.aspx?source_page=fl_edit.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=" + hdfWorkType.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;

        case "mCXIRemovedReport":
            window.open("./fl_cxi_removed_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mReadyForLining":
            window.open("./fl_ready_for_lining_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mToBePrepped":
            window.open("./fl_to_be_prepped_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mToBeLined":
            window.open("./fl_to_be_measured_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mLiningCompleted":
            window.open("./fl_lining_completed_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mOverviewReport":
            window.open("./fl_overview_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mAllOutstandingIssues":
            window.open("./fl_all_outstanding_issues_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mOutstandingClientIssues":
            window.open("./fl_outstanding_client_issues_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mOutstandingLFSIssues":
            window.open("./fl_outstanding_LFS_issues_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mOutstandingInvestigationIssues":
            window.open("./fl_outstanding_investigation_issues_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mOutstandingSalesIssues":
            window.open("./fl_outstanding_sales_issues_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mClientInvestigationIssuesCityCopy":
            window.open("./fl_outstanding_client_investigation_issues_city_copy_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mM1M2ReportByClient":
            window.open("./fl_m12_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&work_type=Full Length Lining&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mWorkAhead":
            window.open("./fl_work_ahead_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mReinstate":
            window.open("./fl_reinstate_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mWetOut":
            window.open("./fl_wetout_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&work_type=Full Length Lining&client_id=" + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mInversion":
            window.open("./fl_inversion_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&work_type=Full Length Lining&client_id=" + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mBulkUpload":
            window.open("./../Common/bulk_upload.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=540");
            eventArgs.set_cancel(true);
            break;

        case "mWincapBulkUpload":
            window.open("./../Common/wincan_bulk_upload.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=540");
            eventArgs.set_cancel(true);
            break;

        case "mResinsSetup":
            window.open("./fl_resins_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=800, height=540");
            eventArgs.set_cancel(true);
            break;

        case "mCatalystSetup":
            window.open("./fl_catalyst_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=450, height=540");
            eventArgs.set_cancel(true);
            break;

        case "mOpenedAndBrushed":
            window.open("./fl_opened_brushed_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}