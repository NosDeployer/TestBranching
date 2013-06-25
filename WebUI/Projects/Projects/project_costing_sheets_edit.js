// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function OnKeyDown(e) {
    if (window.event) {
        if (window.event.keyCode == 13) {
            event.returnValue = false;
            event.cancel = true;
        }
    }
    else {
        if (e.which == 13) {
            e.cancelBubble = true;
            e.preventDefault();
            e.stopPropagation();
            return false;
        }
    }
}







// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
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