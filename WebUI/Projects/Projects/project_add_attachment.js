// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function OnUnload()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
    
    // Update
    if (hdfUpdate.value == "yes")
    {
        window.opener.location.href = window.opener.location;
    }     
}



function btnCloseClick()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
        
    // Update
    hdfUpdate.value = "no";
    window.close();
}



function closeDialog()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
        
    // Update
    hdfUpdate.value = "yes";
    window.close();
}