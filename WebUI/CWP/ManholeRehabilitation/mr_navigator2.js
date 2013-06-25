// ////////////////////////////////////////////////////////////////////////
//  EVENTS
//

function btnViewAddClick()
{
    var hdfWorkType = document.getElementById(hdfWorkTypeId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);
    
    if (hdfWorkType.value != "")
    {    
        var url = "./../Common/view_add.aspx?source_page=mr_navigator2.aspx&work_type=" + hdfWorkType.value+"&project_id="+ hdfCurrentProjectId.value;
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
        var url = "./../Common/view_edit.aspx?source_page=mr_navigator.aspx&work_type=" + hdfWorkType.value+"&view_id="+ ddlView.value+"&project_id="+ hdfCurrentProjectId.value;
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
        if (elm[i].type == "checkbox" && elm[i].id != theBox.id && elm[i].id.indexOf('grdMRNavigator') !== -1)
        {    
            elm[i].checked = false;       
        }
    }   
}



function cbxClick()
{
     return false;
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();
    var hdfCurrentClientId = document.getElementById(hdfCurrentClientIdId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);
    var hdfWorkType = document.getElementById(hdfWorkTypeId);

    switch (item) {

        case "mAddSection":
            window.open("./../Common/project_add_sections.aspx?source_page=mr_navigator.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=Manhole Rehabilitation", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;

        case "mAddManhole":
            window.open("./../Common/add_manhole.aspx?source_page=mr_navigator.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=Manhole Rehab", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
            eventArgs.set_cancel(true);
            break;

        case "mAddBatch":
            window.open("./../ManholeRehabilitation/mr_batch_add.aspx?source_page=mr_navigator2.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=540");
            eventArgs.set_cancel(true);
            break;

        case "mSummaryReport":
            window.open("./mr_summary_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=" + hdfWorkType.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}