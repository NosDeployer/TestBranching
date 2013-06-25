// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function lkbtnOpenServiceClick(url) {
    window.opener.location.href = url;
    window.close();
}



function lkbtnEditServiceClick(url) {
    window.opener.location.href = url;
    window.close();
}



function lkbtnCloseClick() 
{
    window.opener.location.href = window.opener.location;
    window.close();
}