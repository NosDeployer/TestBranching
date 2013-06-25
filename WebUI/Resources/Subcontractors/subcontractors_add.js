// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function OnUnload() {
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
    var hdfStep = document.getElementById(hdfStepId);

    alert("Update: " + hdfUpdate.value);
    alert("Step" + hdfStep.value);

    // Update
    if ((hdfUpdate.value == "yes") && (hdfStep.value == 'StepSummary')) {
        window.opener.location.href = window.opener.location;
    }
}