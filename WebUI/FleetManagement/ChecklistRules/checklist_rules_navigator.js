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
        
        if (elm[i].type=="checkbox" && j>0 && elm[i].id!=theBox.id)
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