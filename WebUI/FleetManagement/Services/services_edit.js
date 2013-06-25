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



function tpGeneralDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "0";
}



function tpAssignmentDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "1";
}



function tpStartWorkDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "2";
}



function tpCompleteWorkDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "3";
}



function tpNotesDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "4";
}



function btnAssociateClick() {
    var hdfServiceId = document.getElementById(hdfServiceIdId);
    window.open("./services_associate_to_category.aspx?source_page=services_edit.aspx&service_id=" + hdfServiceId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=470, height=630");

    return true;
}



function btnUnassociateClick() {
    if (confirm("Are you sure you want to unassociate this category?") == true) {
        return true;
    }
    else {
        return false;
    }
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) 
{
    var item = eventArgs.get_item().get_value();

    switch (item)
    {
        case "mAddServiceRequest":
            var hdfDashboard = document.getElementById(hdfDashboardId);
            window.open("./../Services/services_add_request.aspx?source_page=services_navigator.aspx&dashboard=" + hdfDashboard.value + "&unit_id=none", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
            eventArgs.set_cancel(true);
            break;
            
        case "mSRManager":
            window.open("./../Services/services_manager_tool.aspx?&source_page=lm&dashboard=False", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
            eventArgs.set_cancel(true);
            break;
            
        case "mMyCurrentSR":        
            window.open("./services_myCurrentSR_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "mSRUnassigned":        
            window.open("./services_SRUnassigned_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "mSRRejected":        
            window.open("./services_SRRejected_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "mSRAboutToExpire":        
            window.open("./services_SRAboutToExpire_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "mSRExpired":        
            window.open("./services_SRexpired_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break; 
    }
}