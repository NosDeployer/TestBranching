// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick()
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



function tpRepairsDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "1";
}



function tpCommentsDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "2";
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

    switch (item)
    {
        case "mAddSection":
            window.open("./../Common/project_add_sections.aspx?source_page=pr_edit.aspx&project_id="+ hdfCurrentProjectId.value+"&client_id=" + hdfCurrentClientId.value + "&work_type=" + hdfWorkType.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;
            
        case "mOverviewReport":
            window.open("./pr_overview_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value+"&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}