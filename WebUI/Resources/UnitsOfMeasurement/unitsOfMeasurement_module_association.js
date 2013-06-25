// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxSelectedClick(spanChk) 
{
    var j = -1;
    var id = "";
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
    xState = theBox.checked;

    elm = theBox.form.elements;
    for (i = 0; i < elm.length; i++) {
        id = elm[i].id;
        j = id.indexOf("cbxByDefault");

        if (elm[i].type == "checkbox" && elm[i].id != theBox.id && j > 0) {
            elm[i].checked = false;
        }
    }
}