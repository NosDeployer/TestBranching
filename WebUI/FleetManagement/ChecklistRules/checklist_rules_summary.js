// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function OnKeyDown(e) 
{    
    if (window.event)
    {
        if (window.event.keyCode == 13) 
        {
            event.returnValue=false; 
            event.cancel = true;
        }
    }
    else
    {
        if (e.which == 13) 
        {
            e.cancelBubble = true;
            e.preventDefault();
            e.stopPropagation();
            return false;            
        }
    }
}



function cbxClick()
{
    return false;
}



function cbxTreeViewClick(e)
{
    if (window.event) e = window.event; 
    var src = e.srcElement? e.srcElement : e.target; 
    var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
    if(isChkBoxClick)
    {
        return false;
    }
    else
    {
        return true;
    }     
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();

    switch (item) {
        case "mAddChecklistRule":
            window.open("./checklist_rules_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=530");
            eventArgs.set_cancel(true);
            break;

        case "mCategories":
            window.open("./../Categories/categories_edit.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=550");
            eventArgs.set_cancel(true);
            break;

        case "mCompanyLevels":
            window.open("./../CompanyLevels/company_levels_edit.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=550");
            eventArgs.set_cancel(true);
            break;
    }
}