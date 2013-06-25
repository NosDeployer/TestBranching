// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//
function cbxSelectedClick(spanChk)
{
    var j = -1;
    var k = -1;
    var id = "";
    var allSelect = true;
    var oItem = spanChk.children;
    var theBox = (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
    elm = theBox.form.elements;
    for(i=0;i<elm.length;i++)
    {
        id = elm[i].id;
        j = id.indexOf("cbxSelected");
        k = id.indexOf("cbxCheckAll");
        if (k>0)
        {
            cbxCheckAllIndex = i;       
        }        
        if (elm[i].type=="checkbox" && j>0)
        {
            if(elm[i].checked!=true)
                allSelect = false;
        }
    }
    if (allSelect == true)
    {
        elm[cbxCheckAllIndex].checked = true;
    }
    else
    {
        elm[cbxCheckAllIndex].checked = false;
    }   
}