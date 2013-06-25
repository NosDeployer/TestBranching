// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function LkbtnAddSupportTicketClick(url) {
    window.open("./../SupportTicket/supportTicket_add.aspx?source_page=supportTicket_navigator.aspx&dashboard=True&supportTicket_id=none", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650");
}






// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxSelectedClick(spanChk) {
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];

    xState = theBox.checked;
    elm = theBox.form.elements;

    for (i = 0; i < elm.length; i++) {
        if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
            elm[i].checked = false;
        }
    }
}