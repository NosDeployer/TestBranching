// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick()
{
     return false;
}



function cbxSelectedClick(spanChk)
{
    var j = -1;
    var id = "";
    var oItem = spanChk.children;
    var theBox=(spanChk.type=="checkbox")?spanChk:spanChk.children.item[0];
    xState=theBox.checked;
    
    elm=theBox.form.elements;
    for(i=0;i<elm.length;i++)
    {
        id = elm[i].id;
        j = id.indexOf("cbxSelected");
        
        if(elm[i].type=="checkbox" && elm[i].id!=theBox.id && j>0)
        {    
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
        case "mAddToDoList":
            if (confirm("Not to be used for Fleet issues. Do you wish to proceed?")) {
                window.open("./../ToDoList/toDoList_add.aspx?dashboard=False&source_page=toDoList_navigator2.aspx", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
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