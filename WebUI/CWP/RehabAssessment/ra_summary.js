// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function OnKeyDown(e) 
{    
    if (window.event)
    {
        if (window.event.keyCode == 13) 
        {
            event.returnValue=false; 
            event.cancel = true;
        }
    }
    else
    {
        if (e.which == 13) 
        {
            e.cancelBubble = true;
            e.preventDefault();
            e.stopPropagation();
            return false;            
        }
    }
}



function cbxClick()
{
     return false;
}



function tpGeneralDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "0";
}



function tpPrepDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "1";
}



function tpM1DataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "2";
}



function tpCommentDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "3";
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();
    var hdfCurrentClientId = document.getElementById(hdfCurrentClientIdId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);

    switch (item) {
        case "mAddSection":
            window.open("./../Common/project_add_sections.aspx?source_page=ra_summary.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=Rehab Assessment", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
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



function tkrmTopItemClicking(sender, args) 
{
    var itemValue = args.get_item().get_value();

    switch (itemValue) 
    {
        case "mLateralLocationSheet":
            var hdfCurrentClientId = document.getElementById(hdfCurrentClientIdId);
            var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);
            var hdfAssetId = document.getElementById(hdfAssetIdId);
            var hdfWorkId = document.getElementById(hdfWorkIdId);
            var hdfWorkIdFll = document.getElementById(hdfWorkIdFllId);
            var hdfMeasuredFrom = document.getElementById(hdfMeasuredFromId);

            window.open("./../../CWP/Common/lateral_location_sheet_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_id=" + hdfWorkIdFll.value + "&measured_from=" + hdfMeasuredFrom.value + "&asset_id=" + hdfAssetId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            args.set_cancel(true);
            break;

        case "mViewWorks":
            args.set_cancel(true);
            break;
    }
}