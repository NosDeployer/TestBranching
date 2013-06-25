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



function tpCostDataClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "0";
}



function tpVacationsDataClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "1";
}



function tpNotesDataClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "2";
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();

    switch (item) {
        case "mAddTeamMember":
            window.open("./employees_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=400, height=500");
            eventArgs.set_cancel(true);
            break;

        case "mVacationsSetup":
            window.open("./../../LabourHours/Vacations/vacations_setup.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=550, height=520");
            eventArgs.set_cancel(true);
            break;

        case "mCostingSetup":
            window.open("./employees_costing_setup.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=550, height=520");
            eventArgs.set_cancel(true);
            break;

        case "mPersonalAgencies":
            window.open("./employees_personal_agency.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=470, height=540");
            eventArgs.set_cancel(true);
            break;
    }
}