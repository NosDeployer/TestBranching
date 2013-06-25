// ////////////////////////////////////////////////////////////////////////
//  EVENTS
//

function btnViewAddClick()
{
    var hdfWorkType = document.getElementById(hdfWorkTypeId);
    var hdfCurrentProjectId = document.getElementById(hdfCurrentProjectIdId);
    
    if (hdfWorkType.value != "")
    {    
        var url = "./../Common/view_add.aspx?source_page=jl_navigator2.aspx&work_type=" + hdfWorkType.value+"&project_id="+ hdfCurrentProjectId.value;
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
        var url = "./../Common/view_edit.aspx?source_page=jl_navigator2.aspx&work_type=" + hdfWorkType.value+"&view_id="+ ddlView.value+"&project_id="+ hdfCurrentProjectId.value;
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

function cbxClick()
{
     return false;
}



function cbxCheckAllClick(spanChk)
{        
    var j = -1;
    var id = "";
    var oItem = spanChk.children;
    var theBox = (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
    xState = theBox.checked;
    elm = theBox.form.elements;
    for(i=0;i<elm.length;i++)
    {
        id = elm[i].id;
        j = id.indexOf("cbxSelected");
        
        if (elm[i].type=="checkbox" && j>0 && elm[i].id!=theBox.id)
        {            
            if(elm[i].checked!=xState)
                elm[i].checked=xState;
        }
    }
}



function cbxSelectedClick(spanChk)
{
    var j = -1;
    var k = -1;
    var id = "";
    var allSelect = true;
    var oItem = spanChk.children;
    var theBox = (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
    elm = theBox.form.elements;
    for(i=0;i<elm.length;i++)
    {
        id = elm[i].id;
        j = id.indexOf("cbxSelected");
        k = id.indexOf("cbxCheckAll");
        if (k>0)
        {
            cbxCheckAllIndex = i;       
        }        
        if (elm[i].type=="checkbox" && j>0)
        {
            if(elm[i].checked!=true)
                allSelect = false;
        }
    }
    if (allSelect == true)
    {
        elm[cbxCheckAllIndex].checked = true;
    }
    else
    {
        elm[cbxCheckAllIndex].checked = false;
    }
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
            window.open("./../Common/project_add_sections.aspx?source_page=jl_navigator2.aspx&project_id=" + hdfCurrentProjectId.value + "&client_id=" + hdfCurrentClientId.value + "&work_type=Junction Lining", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=830, height=715");
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