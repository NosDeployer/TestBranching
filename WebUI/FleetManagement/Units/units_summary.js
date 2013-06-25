// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function OnKeyDown(e) 
{    
    if (window.event)
    {
        if (window.event.keyCode == 13) 
        {
            event.returnValue=false; 
            event.cancel = true;
        }
    }
    else
    {
        if (e.which == 13) 
        {
            e.cancelBubble = true;
            e.preventDefault();
            e.stopPropagation();
            return false;            
        }
    }
}



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
        j = id.indexOf("cbxSelectedService");
        
        if(elm[i].type=="checkbox" && elm[i].id!=theBox.id && j>0)
        {    
            elm[i].checked = false;       
        }
    }
   
}



function cbxTreeViewClick(e)
{
    if (window.event) e = window.event; 
    var src = e.srcElement? e.srcElement : e.target; 
    var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
    if(isChkBoxClick)
    {
        return false;
    }
    else
    {
        return true;
    }     
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



function tkrmTopItemClicking(sender, args) 
{
    var itemValue = args.get_item().get_value();

    switch (itemValue) {
        case "mAddServiceRequest":
            var hdfUnitId = document.getElementById(hdfUnitIdId);
            window.open("./../Services/services_add_request.aspx?source_page=units_summary.aspx&dashboard=False&unit_id=" + hdfUnitId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
            args.set_cancel(true);
            break;
    }
}



function tpGeneralDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "0";
}



function tpPlateDataClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "1";
}



function tpTechnicalClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "2";
}



function tpOwnershipClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "3";
}



function tpChecklistClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "4";
}



function tpServiceClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "5";
}



function tpInspectionClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "6";
}



function tpCostsClientClick(sender, e)
{
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "7";
}



function tpNotesDataClientClick(sender, e) {
    var hdfActiveTab = document.getElementById(hdfActiveTabId);
    hdfActiveTab.value = "8";
}