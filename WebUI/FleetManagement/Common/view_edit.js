// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function OnUnload()
{
//    // Definition of ids
//    var hdfUpdate = document.getElementById(hdfUpdateId);
//    var hdfStep = document.getElementById(hdfStepId);    
//    
//    // Update
//    if ((hdfUpdate.value == "yes") && (hdfStep.value == 'StepSummary'))
//    {
//        window.opener.location.href = window.opener.location;
//    }
}



function btnCloseClick()
{
//    // Definition of ids
//    var hdfUpdate = document.getElementById(hdfUpdateId);
//        
//    // Update
//    hdfUpdate.value = "no";
//    window.close();
}



function btnFinishPreviousButtonClick()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
  
    // Tag Page
    hdfUpdate.value = "no";
    return true;
}



function btnCancelButtonClick()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
  
    // Tag Page
    hdfUpdate.value = "no";
    return true;
}