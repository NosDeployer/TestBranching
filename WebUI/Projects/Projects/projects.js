// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) 
{
    var item = eventArgs.get_item().get_value();
    
    switch (item)
    {
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
            window.open("./costing_sheet_report_consolidated.aspx?source_page=lm&type=consolidated", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mProductionReport":
            window.open("./production_report.aspx?source_page=lm", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mVideoCompleteReport":
            window.open("./video_complete_report.aspx?source_page=lm", "_blank", "toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
 }