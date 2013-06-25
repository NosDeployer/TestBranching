// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function lkbtnOpenServiceClick(url)
{ 
    window.opener.location.href = url;
    window.close();
}



function lkbtnEditServiceClick(url)
{
    window.opener.location.href = url;
    window.close();
}



function lkbtnReturnDashboardClick(url)
{
    window.opener.location.href = url;
    window.close();
}



function lkbtnCloseClick()
{
    window.close();
}






// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

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
        j = id.indexOf("cbxSelected");
        
        if(elm[i].type=="checkbox" && elm[i].id!=theBox.id && j>0)
        {    
            elm[i].checked = false;       
        }
    }
}



function MakeCompleteWorkMileageSameStartWorkMileage() 
{
    var tbxStartWorkMileage = document.getElementById(tbxStartWorkStartMileageId);
    var tbxCompleteWorkCompleteMileage = document.getElementById(tbxCompleteWorkCompleteMileageId);
    
    // Update complete work mileage
    tbxCompleteWorkCompleteMileage.value = tbxStartWorkMileage.value;
}



function btnAssociateClick() {
    var hdfServiceId = document.getElementById(hdfSelectedSRIdId);
    window.open("./services_associate_to_category_manager_tool.aspx?service_id=" + hdfServiceId.value, "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=470, height=630");

    return true;
}



function btnUnassociateClick() {
    if (confirm("Are you sure you want to unassociate this category?") == true) {
        return true;
    }
    else {
        return false;
    }
}