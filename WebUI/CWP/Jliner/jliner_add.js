// /////////////////////////////////////////////////////////////////////////////////////////////////////
// STEP2 - SECTION2
//
        
// ////////////////////////////////////////////////////////////////////////
// STEP2 - AUXILIAR EVENTS
//

function cbxSelectedClick(spanChk)
{
    var oItem = spanChk.children;
    var theBox=(spanChk.type=="checkbox")?spanChk:spanChk.children.item[0];
    xState=theBox.checked;
    
    elm=theBox.form.elements;
    for(i=0;i<elm.length;i++)
    {
        if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
        {    
            elm[i].checked = false;       
        }
    }
}



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


