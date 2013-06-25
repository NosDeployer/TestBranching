// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) 
{
    var item = eventArgs.get_item().get_value();

    switch (item) 
    {
        case "mModuleAssociation":
            window.open("./unitsOfMeasurement_module_association.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=400, height=500");
            eventArgs.set_cancel(true);
            break;
    }
} 