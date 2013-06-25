// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick()
{
     return false;
}



function OnKeyDown(e) {
     if (window.event) {
         if (window.event.keyCode == 13) {
             event.returnValue = false;
             event.cancel = true;
         }
     }
     else {
         if (e.which == 13) {
             e.cancelBubble = true;
             e.preventDefault();
             e.stopPropagation();
             return false;
         }
     }
 }






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//
 
function btnCommentsClick(id, refId, companyId, rowFocus)
{ 
    var hdfCurrentClientId_ = document.getElementById(hdfCurrentClientId);   
    var url = "./jliner_comments.aspx?source_page=flat_section_jliner_summary.aspx&rowId=" + id + "&rowRefId=" + refId+ "&rowCompanyId=" + companyId + "&client=" + hdfCurrentClientId_.Value + "&rowFocus=" + rowFocus;
    var remote = window.open( url ,"_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640"); 
    if (remote.opener == null)
    {
        remote.opener = window;
    }
    return false;
}



function btnHistoryClick(id, refId, companyId, rowFocus)
{ 
    var hdfCurrentClientId_ = document.getElementById(hdfCurrentClientId);   
    var url = "./jliner_history.aspx?source_page=flat_section_jliner_summary.aspx&rowId=" + id + "&rowRefId=" + refId+ "&rowCompanyId=" + companyId + "&client=" + hdfCurrentClientId_.Value + "&rowFocus=" + rowFocus;
    var remote = window.open( url ,"_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640"); 
    if (remote.opener == null)
    {
        remote.opener = window;
    }
    return false;
}



function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();
    var hdfCurrentClient = document.getElementById(hdfCurrentClientId);

    switch (item) {
        case "mAdd":
            window.open("./jliner_add.aspx?source_page=lm&client=" + hdfCurrentClient.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=650, height=570");
            eventArgs.set_cancel(true);
            break;

        case "mLateralsOverviewReport":
            window.open("./jliner_overview_report.aspx?source_page=lm&client=" + hdfCurrentClient.value, "_blank", "toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "mLinersToBuildReport":
            window.open("./jliner_tobuild_report.aspx?source_page=lm&client=" + hdfCurrentClient.value, "_blank", "toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}