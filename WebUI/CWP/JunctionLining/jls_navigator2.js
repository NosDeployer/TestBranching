// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

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