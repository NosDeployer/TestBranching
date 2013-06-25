// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function LkbtnAddServiceRequestClik(url)
{
    window.open("./../Services/services_add_request.aspx?source_page=services_navigator.aspx&dashboard=True&unit_id=none", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
    return false;
}



function LkbtnServiceRequestManagerClik(url)
{
    window.open("./../Services/services_manager_tool.aspx?source_page=services_navigator.aspx&dashboard=True&unit_id=none", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
    return false;
}



function LkbtnAddToDoClick(url) {
    if (confirm("Not to be used for Fleet issues. Do you wish to proceed?")) {
        window.open("./../ToDoList/toDoList_add.aspx?source_page=toDoList_navigator.aspx&dashboard=True&toDo_id=none", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
    }
    return false;
}






// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxSelectedClick(spanChk)
{
    var oItem = spanChk.children;
    var theBox=(spanChk.type=="checkbox")?spanChk:spanChk.children.item[0];
    
    xState=theBox.checked;    
    elm=theBox.form.elements;
    
    for(i=0;i<elm.length;i++)
    {
        if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
        {    
            elm[i].checked = false;       
        }
    }  
}