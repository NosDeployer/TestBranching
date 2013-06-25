// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function btnAddClick()
{
    var hdfUpdate = document.getElementById(hdfUpdateId);
    
    hdfUpdate.value = "yes";
}



function btnCancelClick()
{
    var hdfUpdate = document.getElementById(hdfUpdateId);
    
    hdfUpdate.value = "no";
    
    window.close();
}



function OnUnload()
{
    var hdfUpdate = document.getElementById(hdfUpdateId);
    
    if (hdfUpdate.value == "yes")
    {
        window.opener.location.href = window.opener.location;
    }
}