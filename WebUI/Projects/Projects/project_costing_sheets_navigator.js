// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick() {
    return false;
}



function cbxSelectedClick(spanChk) {
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
    xState = theBox.checked;

    elm = theBox.form.elements;
    for (i = 0; i < elm.length; i++) {
        if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
            elm[i].checked = false;
        }
    }
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function btnDeleteClick() {
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId);

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup";

    if (confirm("Are you sure you want to delete this costing sheet?") == true)
        return true;
    else
        return false;
}



function tkrmTopItemClicking(sender, args) 
{
    var itemValue = args.get_item().get_value();
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId);

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "LeftMenu";

    switch (itemValue) 
    {
        case "mAddCostingSheet":
            var hdfProjectId = document.getElementById(hdfProjectIdId);
            window.open("./project_costing_sheets_add.aspx?source_page=project_costing_sheets_navigator.aspx&project_id=" + hdfProjectId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=1024, height=630");
            args.set_cancel(true);
            break;

        case "mAddCombinedCostingSheet":
            var hdfProjectId = document.getElementById(hdfProjectIdId);
            var hdfClientId = document.getElementById(hdfClientIdId);
            window.open("./project_combined_costing_sheets_add.aspx?source_page=project_costing_sheets_navigator.aspx&client_id=" + hdfClientId.value + "&project_id=" + hdfProjectId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=1024, height=830");
            args.set_cancel(true);
            break;
    }
}



function tkrpbLeftMenuItemClick(sender, eventArgs)
 {
    var item = eventArgs.get_item().get_value();
    var hdfProjectId = document.getElementById(hdfProjectIdId);
    var hdfClientId = document.getElementById(hdfClientIdId);
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId);

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "LeftMenu";
    switch (item) {
        case "mProjectSynopsis":
            window.open("./project_synopsis_report.aspx?source_page=lm&project_id=" + hdfProjectId.value, "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mAddProject":
            window.open("./project_add.aspx?type=project", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=540, height=400");
            eventArgs.set_cancel(true);
            break;

        case "mDuplicateProposal":
            window.open("./project_duplicate.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=686, height=600");
            eventArgs.set_cancel(true);
            break;

        case "mBallparkSummaryReport":
            window.open("./ballpark_summary_report.aspx", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mTotalValueOfProposalsReport":
            window.open("./total_value_work_ahead_report.aspx?source_page=lm", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mCurrentActiveWorkOnHandReport":
            window.open("./detailed_work_on_hand_report.aspx?source_page=lm", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mProjectsSummaryReport":
            window.open("./projects_summary_report.aspx?source_page=lm", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mDetailedCostingSheetReport":
            window.open("./costing_sheet_report.aspx?source_page=lm&type=detailed", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mCombinedDetailedCostingSheetReport":
            window.open("./combined_costing_sheet_report.aspx?source_page=lm&type=detailed", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mConsolidatedCostingSheetReport":
            window.open("./costing_sheet_report_consolidated.aspx?source_page=lm&type=consolidated&project_id=" + hdfProjectId.value + "&client_id=" + hdfClientId.value, "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mAddSections":
            window.open("./../../CWP/Common/project_add_sections.aspx?source_page=project_sections_navigator2.aspx&project_id=" + hdfProjectId.value + "&client_id=" + hdfClientId.value + "&work_type=All", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;

        case "mProductionReport":
            window.open("./production_report.aspx?source_page=lm&project_id=" + hdfProjectId.value + "&client_id=" + hdfClientId.value, "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "mVideoCompleteReport":
            window.open("./video_complete_report.aspx?source_page=lm", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}