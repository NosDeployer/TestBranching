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
        case "mAddActualCosts":
            window.open("./../../LabourHours/ActualCosts/actual_costs_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=1024, height=630");
            eventArgs.set_cancel(true);
            break;

        case "mAddCategoryItems":
            window.open("./../../LabourHours/Common/category_items_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=400, height=500");
            eventArgs.set_cancel(true);
            break;

        case "mActualCostsReport":
            window.open("./../../LabourHours/ActualCosts/actual_costs_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=490, height=490");
            eventArgs.set_cancel(true);
            break;
    }
}