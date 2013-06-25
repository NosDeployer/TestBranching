// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick()
{
     return false;
}






// ////////////////////////////////////////////////////////////////////////
//  EVENTS
//

function btnViewAddClick()
{
    var hdfWorkType = document.getElementById(hdfWorkTypeId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);
    
    if (hdfWorkType.value != "")
    {    
        var url = "./../Common/view_add.aspx?source_page=jl_navigator.aspx&work_type=" + hdfWorkType.value+"&project_id="+ hdfCurrentProjectId.value;
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
    var hdfWorkType = document.getElementById(hdfWorkTypeId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);

    // Validation of comments at view ddl
    if((ddlView.value != "-1") && (ddlView.value != "-2"))
    {
        var url = "./../Common/view_edit.aspx?source_page=jl_navigator.aspx&work_type=" + hdfWorkType.value+"&view_id="+ ddlView.value+"&project_id="+ hdfCurrentProjectId.value;
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
    var hdfCurrentClientId = document.getElementById(hdfCurrentClientIdId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);

    switch (item) {
        case "mAddSection":
            window.open("./../Common/project_add_sections.aspx?source_page=ra_navigator.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=Junction Lining", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;

        case "mLinersToBuildReport":
            window.open("./jl_tobuild_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mLateralsOverviewReport":
            window.open("./jl_overview_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mBulkUpload":
            window.open("./../Common/bulk_upload.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=540");
            eventArgs.set_cancel(true);
            break;

        case "mWincapBulkUpload":
            window.open("./../Common/wincan_bulk_upload.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=540");
            eventArgs.set_cancel(true);
            break;

        case "mM1M2ReportByClient":
            window.open("./../FullLengthLining/fl_m12_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&work_type=Rehab Assessment&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mOpenedAndBrushed":
            window.open("./../FullLengthLining/fl_opened_brushed_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}