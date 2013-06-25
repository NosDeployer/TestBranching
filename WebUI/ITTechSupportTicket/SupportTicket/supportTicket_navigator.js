// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();
    switch (item) {

        case "mAddTicket":
            window.open("./supportTicket_add.aspx?dashboard=False&source_page=supportTicket_navigator.aspx", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
            eventArgs.set_cancel(true);
            break;

        case "mCategoriesSetup":
            window.open("./supportTicket_categories.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=650, height=620");
            eventArgs.set_cancel(true);
            break;

    }
}