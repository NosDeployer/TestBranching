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

function tkrmTopItemClicking(sender, args) 
{
    var hdfCurrentClient = document.getElementById(hdfCurrentClientId);
    var itemValue = args.get_item().get_value();

    switch (itemValue) 
    {
        case "mAddJunctionLiners":
            window.open("./jliner_add.aspx?source_page=lm&client=" + hdfCurrentClient.value, "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=650, height=570");
            args.set_cancel(true);
            break;
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