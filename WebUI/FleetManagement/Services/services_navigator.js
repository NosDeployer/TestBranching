// ////////////////////////////////////////////////////////////////////////
//  EVENTS
//

function btnViewAddClick()
{
    var hdfFmType = document.getElementById(hdfFmTypeId);
    
    if (hdfFmType.value != "")
    {    
        var url = "./../Common/view_add.aspx?source_page=services_navigator.aspx&fm_type=" + hdfFmType.value;
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
        var url = "./../Common/view_edit.aspx?source_page=services_navigator.aspx&fm_type=" + hdfFmType.value+"&view_id="+ ddlView.value;
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
        case "mAddServiceRequest":
            window.open("./../Services/services_add_request.aspx?source_page=services_navigator.aspx&dashboard=False&unit_id=none", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
            eventArgs.set_cancel(true);
            break;

        case "mSRManager":
            window.open("./../Services/services_manager_tool.aspx?&source_page=lm&dashboard=False", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
            eventArgs.set_cancel(true);
            break;

        case "mMyCurrentSR":
            window.open("./services_myCurrentSR_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mSRUnassigned":
            window.open("./services_SRUnassigned_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mSRRejected":
            window.open("./services_SRRejected_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mSRAboutToExpire":
            window.open("./services_SRAboutToExpire_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mSRExpired":
            window.open("./services_SRexpired_report.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}