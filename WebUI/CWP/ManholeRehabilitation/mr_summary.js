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



function tpMrRehabilitationDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "0";
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();
    var hdfCurrentClientId = document.getElementById(hdfCurrentClientIdId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);
    var hdfWorkType = document.getElementById(hdfWorkTypeId);

    switch (item) {

        case "mAddSection":
            window.open("./../Common/project_add_sections.aspx?source_page=mr_navigator.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=Manhole Rehabilitation", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;

        case "mAddManhole":
            window.open("./../Common/add_manhole.aspx?source_page=mr_navigator.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=Manhole Rehab", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;

        case "mAddBatch":
            window.open("./../ManholeRehabilitation/mr_batch_add.aspx?source_page=mr_navigator.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=540");
            eventArgs.set_cancel(true);
            break;

        case "mSummaryReport":
            window.open("./mr_summary_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=" + hdfWorkType.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}