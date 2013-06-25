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



function lkbtnCloseClick()
{
    window.close();
}






// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function MakeCompleteWorkMileageSameStartWorkMileage() {
    var tbxStartWorkMileage = document.getElementById(tbxStartWorkStartMileageId);
    var tbxCompleteWorkCompleteMileage = document.getElementById(tbxCompleteWorkCompleteMileageId);

    // Update complete work mileage
    tbxCompleteWorkCompleteMileage.value = tbxStartWorkMileage.value;
}