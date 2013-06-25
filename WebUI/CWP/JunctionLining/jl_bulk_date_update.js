// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function OnUnload()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
    var hdfStep = document.getElementById(hdfStepId);    
    
    // Update
    if ((hdfUpdate.value == "yes") && (hdfStep.value == 'Finish'))
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






// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

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