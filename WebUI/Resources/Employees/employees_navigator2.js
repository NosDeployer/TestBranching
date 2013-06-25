// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick() {
    return false;
}



function cbxSelectedClick(spanChk) {
    var j = -1;
    var id = "";
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
    xState = theBox.checked;

    elm = theBox.form.elements;
    for (i = 0; i < elm.length; i++) {
        id = elm[i].id;
        j = id.indexOf("cbxSelected");

        if (elm[i].type == "checkbox" && elm[i].id != theBox.id && j > 0) {
            elm[i].checked = false;
        }
    } 
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