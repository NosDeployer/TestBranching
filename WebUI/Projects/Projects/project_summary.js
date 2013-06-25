// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrmTopItemClicking(sender, args) 
{
    var itemValue = args.get_item().get_value();

    switch (itemValue) 
    {
        case "mAddSubcontractor":
            var hdfProjectId = document.getElementById(hdfProjectIdId);
            
            var remote = window.open("./project_subcontractor_add.aspx?source_page=project_engineer_subcontractors.aspx&project_id=" + hdfProjectId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=700, height=570");

            if (remote.opener == null) 
            {
                remote.opener = window;
            }

            args.set_cancel(true);
            break;

        case "mProject":
            args.set_cancel(true);
            break;

        case "mProposal":
            args.set_cancel(true);
            break;

        case "mInternalProject":
            args.set_cancel(true);
            break;

        case "mBallparkProject":
            args.set_cancel(true);
            break;

        case "mViewWorks":
            args.set_cancel(true);
            break;
    }
}



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
 
 
 
 
 
 
// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

// General Data events
function btnClientPrimaryContactClick()
{        
    var hdfClientPrimaryContactId = document.getElementById(hdfClientPrimaryContactIdId);
    
    if (hdfClientPrimaryContactId.value != "")
    {
        window.open("./../../RAF/contact.aspx?contact_id=" + hdfClientPrimaryContactId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=630");
    }
    
    return false;
}



function btnClientSecondaryContactClick()
{
    var hdfClientSecondaryContactId = document.getElementById(hdfClientSecondaryContactIdId);
    
    if (hdfClientSecondaryContactId.value != "")
    {
        window.open("./../../RAF/contact.aspx?contact_id=" + hdfClientSecondaryContactId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=630");
    }
    
    return false;
}



// Engineer/Subcontractors events
function btnEngineerIdClick()
{
    var hdfEngineerId = document.getElementById(hdfEngineerIdId);
    
    if (hdfEngineerId.value != "")
    {
        window.open("./../../RAF/contact.aspx?contact_id=" + hdfEngineerId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=630");
    }
    
    return false;
}





 
// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick()
{
    return false;
}


function rbtnClick()
{
    return false;
}



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
 
 




// ////////////////////////////////////////////////////////////////////////
// TAB EVENTS
//
function tpJobInfoClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "0";
}



function tpBudgetClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "1";
}



//function tpSaleBillingPricingClientClick(sender, e)
//{
//    var hdfActiveTab = document.getElementById(hdfActiveTabId);
//    hdfActiveTab.value = "0";
//}



//function tpCostingUpdatesClientClick(sender, e)
//{
//    var hdfActiveTab = document.getElementById(hdfActiveTabId);
//    hdfActiveTab.value = "1";
//}



//function tpTermsPoClientClick(sender, e)
//{
//    var hdfActiveTab = document.getElementById(hdfActiveTabId);
//    hdfActiveTab.value = "2";
//}



//function tpTechnicalClientClick(sender, e)
//{
//    var hdfActiveTab = document.getElementById(hdfActiveTabId);
//    hdfActiveTab.value = "3";
//}



//function tpEngineerSubcontractorsClientClick(sender, e)
//{
//    var hdfActiveTab = document.getElementById(hdfActiveTabId);
//    hdfActiveTab.value = "4";
//}



//function tpCostExceptionsClientClick(sender, e) {
//    var hdfActiveTab = document.getElementById(hdfActiveTabId);
//    hdfActiveTab.value = "5";
//}



//function tpNotesClientClick(sender, e)
//{
//    var hdfActiveTab = document.getElementById(hdfActiveTabId);    
//    hdfActiveTab.value = "7";
//}