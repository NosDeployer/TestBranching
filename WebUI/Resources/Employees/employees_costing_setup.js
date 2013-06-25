// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function OnUnload() {
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);

    // Update
    if (hdfUpdate.value == "yes") {
        window.opener.location.href = window.opener.location;
    }
}