// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick()
{
     return false;
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrmTopItemClicking(sender, args) 
{
    var hdfCurrentClient = document.getElementById(hdfCurrentClientId);

    if (args.get_item().get_value() == 'mAddJunctionLiners') 
    {
        window.open("./jliner_add.aspx?source_page=jliner_navigator.aspx&client=" + hdfCurrentClient.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=650, height=570");
        args.set_cancel(true);        
    }
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