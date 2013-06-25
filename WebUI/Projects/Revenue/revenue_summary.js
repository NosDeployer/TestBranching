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






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();

    switch (item) {
        case "mAddRevenue":
            window.open("./revenue_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=900, height=600");
            eventArgs.set_cancel(true);
            break;
    }
}



function tkrmTopItemClicking(sender, args) 
{
    var itemValue = args.get_item().get_value();

    switch (itemValue) 
    {
        case "mRole":
            var hdfCurrentEmployeeId = document.getElementById(hdfCurrentEmployeeIdId);
            window.open("./employees_rol.aspx?source_page=employees_summary.aspx&employee_id=" + hdfCurrentEmployeeId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=600, height=400");
            args.set_cancel(true);
            break;
    }
}