// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function OnKeyDown(e) {
    var menu = $find(tkrmTopId);
    var itemApply = menu.findItemByValue("mApply");

    if (window.event) {
        if (window.event.keyCode == 13) {
            itemApply.click();
            event.returnValue = false;
            event.cancel = true;
        }
    }
    else {
        if (e.which == 13) {
            itemApply.click();
            e.cancelBubble = true;
            e.preventDefault();
            e.stopPropagation();
            return false;
        }
    }
}



function cbxTreeViewClick(e)
{
    if (window.event) e = window.event; 
    var src = e.srcElement? e.srcElement : e.target; 
    var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
    if(isChkBoxClick)
    {
        return false;
    }
    else
    {
        return true;
    }     
}



//************************** Treeview Parent-Child check behaviour ****************************//  
function OnTreeClick(evt) 
{
    var src = window.event != window.undefined ? window.event.srcElement : evt.target;
    var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
    if (isChkBoxClick) {
        var parentTable = GetParentByTagName("table", src);
        var nxtSibling = parentTable.nextSibling;
        if (nxtSibling && nxtSibling.nodeType == 1)//check if nxt sibling is not null & is an element node
        {
            if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
            {
                //check or uncheck children at all levels
                CheckUncheckChildren(parentTable.nextSibling, src.checked);
            }
        }
        //check or uncheck parents at all levels
        CheckUncheckParents(src, src.checked);
    }

    // Reload page
    var src1 = window.event != window.undefined ? window.event.srcElement : evt.target;
    if (src1.tagName == "INPUT" && src1.type == "checkbox") {
        __doPostBack("", "");
    } 
}
    
    
    
function CheckUncheckChildren(childContainer, check) 
{
    var childChkBoxes = childContainer.getElementsByTagName("input");
    var childChkBoxCount = childChkBoxes.length;
    for (var i = 0; i < childChkBoxCount; i++) {
        childChkBoxes[i].checked = check;
    }
}
    
    
    
function CheckUncheckParents(srcChild, check) 
{
    var parentDiv = GetParentByTagName("div", srcChild);
    var parentNodeTable = parentDiv.previousSibling;

    if (parentNodeTable) {
        var checkUncheckSwitch;

        if (check) //checkbox checked
        {
            var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
            if (isAllSiblingsChecked)
                checkUncheckSwitch = true;
            else
                return; //do not need to check parent if any(one or more) child not checked
        }
        else //checkbox unchecked
        {
            checkUncheckSwitch = false;
        }

        var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
        if (inpElemsInParentTable.length > 0) {
            var parentNodeChkBox = inpElemsInParentTable[0];
            parentNodeChkBox.checked = checkUncheckSwitch;
            //do the same recursively
            CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
        }
    }
}
   
    
    
function AreAllSiblingsChecked(chkBox) 
{
    var parentDiv = GetParentByTagName("div", chkBox);
    var childCount = parentDiv.childNodes.length;
    for (var i = 0; i < childCount; i++) {
        if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
        {
            if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                //if any of sibling nodes are not checked, return false
                if (!prevChkBox.checked) {
                    return false;
                }
            }
        }
    }
    return true;
}
    
    
    
//utility function to get the container of an element by tagname
function GetParentByTagName(parentTagName, childElementObj) 
{
    var parent = childElementObj.parentNode;
    while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
        parent = parent.parentNode;
    }
    return parent;
}



function cbxClick(evt)
{
    var src = window.event != window.undefined ? window.event.srcElement : evt.target;
    
    if(!src.checked)
    {
        return false;
    }
    else
    {
        return true;
    }
}






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

function tkrpbLeftMenuItemClick(sender, eventArgs) {
    var item = eventArgs.get_item().get_value();

    switch (item) {
        case "mAddChecklistRule":
            window.open("./checklist_rules_add.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=530");
            eventArgs.set_cancel(true);
            break;

        case "mCategories":
            window.open("./../Categories/categories_edit.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=550");
            eventArgs.set_cancel(true);
            break;

        case "mCompanyLevels":
            window.open("./../CompanyLevels/company_levels_edit.aspx?source_page=lm", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=590, height=550");
            eventArgs.set_cancel(true);
            break;
    }
}