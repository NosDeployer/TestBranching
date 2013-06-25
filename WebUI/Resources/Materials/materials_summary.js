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



function cbxClick() {
    return false;
}



function cbxSelectedClick(spanChk) {
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
    xState = theBox.checked;

    elm = theBox.form.elements;
    for (i = 0; i < elm.length; i++) {
        if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
            elm[i].checked = false;
        }
    }
    
    return true;
}



function tpCostDataClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "0";
}



function tpNotesDataClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "1";
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) 
{
    var item = eventArgs.get_item().get_value();

    switch (item) {
        case "mAddMaterials":
            window.open("./materials_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=400, height=500");
            eventArgs.set_cancel(true);
            break;

        case "mMaterialByProcessReport":
            window.open("./materials_by_process_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}