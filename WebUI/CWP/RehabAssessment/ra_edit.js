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



function tpCommentDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    
    // Store Active Tab Index    
    hdfActiveTab.value = "3";
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) 
{
    var item = eventArgs.get_item().get_value();
    var hdfCurrentClientId = document.getElementById(hdfCurrentClientIdId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);

    switch (item)
    {
        case "mAddSection":
            window.open("./../Common/project_add_sections.aspx?source_page=ra_edit.aspx&project_id="+ hdfCurrentProjectId.value+"&client_id=" + hdfCurrentClientId.value + "&work_type=Rehab Assessment", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;
            
        case "mBulkUpload":
		    window.open("./../Common/bulk_upload.aspx?source_page=lm&project_id="+ hdfCurrentProjectId.value+"&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=540");
		    eventArgs.set_cancel(true);
		    break;

		case "mWincapBulkUpload":
		    window.open("./../Common/wincan_bulk_upload.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=540");
		    eventArgs.set_cancel(true);
		    break;

        case "mM1M2ReportByClient":
            window.open("./../FullLengthLining/fl_m12_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&work_type=Rehab Assessment&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mOpenedAndBrushed":
            window.open("./../FullLengthLining/fl_opened_brushed_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}