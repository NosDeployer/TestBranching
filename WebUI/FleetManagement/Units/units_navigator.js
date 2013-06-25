// ////////////////////////////////////////////////////////////////////////
//  EVENTS
//

function btnViewAddClick()
{
    var hdfFmType = document.getElementById(hdfFmTypeId);
    
    if (hdfFmType.value != "")
    {    
        var url = "./../Common/view_add.aspx?source_page=units_navigator.aspx&fm_type=" + hdfFmType.value;
        var remote = window.open( url ,"_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=638, height=450");
        if (remote.opener == null)
        {
            remote.opener = window;
        }
        return false;
    }
    return false;
}



function btnViewEditClick()
{
    var ddlView = document.getElementById(ddlViewId);
    var hdfFmType = document.getElementById(hdfFmTypeId);

    // Validation of comments at view ddl
    if((ddlView.value != "-1") && (ddlView.value != "-2"))
    {
        var url = "./../Common/view_edit.aspx?source_page=units_navigator.aspx&fm_type=" + hdfFmType.value+"&view_id="+ ddlView.value;
        var remote = window.open( url ,"_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=638, height=450");
        if (remote.opener == null)
        {
            remote.opener = window;
        }
        return false;
    }
    return false;
}



function btnViewDeleteClick()
{
    var ddlView = document.getElementById(ddlViewId);
    
    // Validation of comments at view ddl
    if((ddlView.value != "-1") && (ddlView.value != "-2"))
    {
        if (confirm("Are you sure you want to delete this view?"))
        {
            return true;
        }  
        else
        {
            return false;
        }                
    }
    else
    {
        return false;
    }
}



function btnGoClick()
{
    var ddlView = document.getElementById(ddlViewId);
    
    // Validation of comments at view ddl
    if((ddlView.value != "-1") && (ddlView.value != "-2"))
    {
       return true;
    }
     return false;
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();

    switch (item) {
        case "mAddUnit":
            window.open("./units_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=565");
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

        case "mUnitsInformationReport":
            window.open("./units_information_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mUnitsChecklistReport":
            window.open("./units_checklists_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mUnitsWithAlarmsReport":
            window.open("./units_with_alarms_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}