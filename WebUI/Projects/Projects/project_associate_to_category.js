// ////////////////////////////////////////////////////////////////////////
// EVENTS
//

function OnUnload()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
    
    // Update
    if (hdfUpdate.value == "yes")
    {
        window.opener.location.href = window.opener.location;
    }     
}



function btnAssociateClick()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
    
    // Update
    hdfUpdate.value = "yes"
    
    return true;
      
}



function OnLoad()
{
    try 
    {   
        var tvCategoriesRoot = document.getElementById('tvCategoriesRootId');
        var pnlCategories = document.getElementById('pnlCategoriesId');
        
        var selectedNode = tvCategoriesRoot.SelectedNodeID.value;
        var selectedNodeName = document.getElementById(selectedNode);   
        
        if(selectedNode != null )   
        {     
            if(selectedNodeName != null)     
            { 
                selectedNode.scrollIntoView(true);      
                selectedNodeName.scrollIntoView(true);       
                pnlCategories.scrollLeft = 0;     
            }   
        } 
    } 
    catch(oException) 
    {}
}



function btnCloseClick()
{
    // Definition of ids
    var hdfUpdate = document.getElementById(hdfUpdateId);
        
    // Update
    hdfUpdate.value = "no";
    window.close();
}
