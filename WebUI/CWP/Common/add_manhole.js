// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
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



function cbxClick()
{
     return false;
}