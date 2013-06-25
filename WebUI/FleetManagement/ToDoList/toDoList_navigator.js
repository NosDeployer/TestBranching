// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();
    switch (item) {
        case "mAddToDoList":
            if (confirm("Not to be used for Fleet issues. Do you wish to proceed?. Do you wish to proceed?")) {
                window.open("./../ToDoList/toDoList_add.aspx?dashboard=False&source_page=toDoList_navigator.aspx", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
                eventArgs.set_cancel(true);
            }
            break;

        case "mToDoListMyToDoReport":
            window.open("./toDoList_MyToDo_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mToDoListMyAssignedToDoReport":
            window.open("./toDoList_AssignedToMe_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}