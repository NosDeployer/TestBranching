// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

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
    var ddlClientPrimaryContactId = document.getElementById(ddlClientPrimaryContactIdId);    
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId); 
    
    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup";
    
    if (ddlClientPrimaryContactId.value != "-1")
    {
        window.open("./../../RAF/contact.aspx?contact_id=" + ddlClientPrimaryContactId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=630");
    }
    
    return false;
}



function btnEngineerIdClick()
{
    var ddlEngineerId = document.getElementById(ddlEngineerIdId);    
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId); 

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup"; 
    
    if (ddlEngineerId.value != "")
    {
        window.open("./../../RAF/contact.aspx?contact_id=" + ddlEngineerId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=630");
    }
    
    return false;
}



// Sale/Billing/Pricing events
function grdServicesAfterNewRow(source, e)
{    
    var hdfProjectId = document.getElementById(hdfProjectIdId);
    var hdfCompanyId = document.getElementById(hdfCompanyIdId);
    e.row.GetDataControllerRow().SetValueByFieldName("ProjectID", hdfProjectId.value);
    e.row.GetDataControllerRow().SetValueByFieldName("Quantity", 1);
    e.row.GetDataControllerRow().SetValueByFieldName("Deleted", false);
    e.row.GetDataControllerRow().SetValueByFieldName("Total", 0);
    e.row.GetDataControllerRow().SetValueByFieldName("COMPANY_ID", hdfCompanyId.value);
}



function grdServicesBeforeUpdate(source, e)
{
    if (e.row.GetDataControllerRow().GetValueByFieldName("AveragePrice") != null)
    {
        e.row.GetDataControllerRow().SetValueByFieldName("Total", e.row.GetDataControllerRow().GetValueByFieldName("AveragePrice") * e.row.GetDataControllerRow().GetValueByFieldName("Quantity"));
    }
}



function grdServicesValidateColumnValue(source, e)
{
    switch (e.column.GetIndex())
    {
        case 3:
            if (e.value == null)
            {
                e.cancel = true;
                e.message = "Please provide a Quantity";
            }
            break;
    }
}



// Engineer/Subcontractors events
function btnClientSecondaryContactClick()
{
    var ddlClientSecondaryContactId = document.getElementById(ddlClientSecondaryContactIdId);    
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId); 

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup";
    
    if (ddlClientSecondaryContactId.value != "-1")
    {
        window.open("./../../RAF/contact.aspx?contact_id=" + ddlClientSecondaryContactId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=630");
    }
    
    return false;
}



function btnDeleteSubcontractorClick()
{
    if (confirm('Are you sure you want to delete this sub-contractor?'))
    {
        return true;
    }
    else
    {
        return false;
    }
}



// Notes events
function btnAssociateClick()
{
    var hdfProjectId = document.getElementById(hdfProjectIdId);   
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId); 

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup";
    window.open("./project_associate_to_category.aspx?source_page=project_notes.aspx&project_id=" + hdfProjectId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=470, height=630");     
    
    return false;
}



function btnUnassociateClick()
{
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId); 

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup";
    
    if (confirm("Are you sure you want to unassociate this category?")==true)
    {
        return true;
    }
    else
    {
        return false;
    }
}



function btnDeleteClick()
{
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId); 

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup";
    
    if (confirm("Are you sure you want to delete this attachment?") == true)
    {
        return true;
    }
    else
    {
        return false;
    }
}



function btnDownloadClick()
{
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId); 

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup";
    
    return true;
}



function btnAddClick()
{
    var hdfBeforeUnloadOrigen = document.getElementById(hdfBeforeUnloadOrigenId); 

    // Establishing the menu type 
    hdfBeforeUnloadOrigen.value = "Popup";
    
    return true;
}



function cbxClick() {
    return false;
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



//function tpNotesClientClick(sender, e) {
//    var hdfActiveTab = document.getElementById(hdfActiveTabId);
//    hdfActiveTab.value = "7";
//}