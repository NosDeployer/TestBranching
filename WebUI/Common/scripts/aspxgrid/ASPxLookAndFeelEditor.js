function CreateLFEditor(parentElement, registerId, lookAndFeel, renderAsTable, controls, 
	inputID, inputName, inputText, onFocus, onBlur, onChange, readOnly, enabled, tooltip, width, height){
	var editorElement = null;
	var element = null;
	var rowElement = null;
	var style = GetLookAndFeelStyleCollection().GetEditorStyle(registerId + "S", lookAndFeel);	
	if(renderAsTable) {
		element = document.createElement("TABLE");
		if(parentElement != null)
			parentElement.appendChild(element);
		element.border = 0;
		element.cellSpacing = 0;
		element.cellPadding = 0;
		if(editorElement == null){
			editorElement = element;
			if(style != null)
				style.ApplyStyleAttributes(element, true);
		}
		parentElement = element;
		element = document.createElement("TBODY");
		parentElement.appendChild(element);
		parentElement = element;
		element = document.createElement("TR");		
		parentElement.appendChild(element);		
		parentElement = element;
		rowElement = element;
		element = document.createElement("TD");
		parentElement.appendChild(element);
		element.style.width = "100%";
		element.valign = "top";
		parentElement = element;
	}
	element = document.createElement("INPUT");
	element.type = "text";
	if(parentElement != null)
		parentElement.appendChild(element);
	if(editorElement == null){
		editorElement = element;
		if(style != null)
			style.ApplyStyleAttributes(element, true);
	}
	else{
		element.style.borderStyle = "none";
		element.style.borderWidth = "0px";
		element.style.width = "100%";
		element.style.height = "100%";		
		if(style != null){
			if(style.attributes["backgroundColor"] != null)
				element.style.backgroundColor = style.attributes["backgroundColor"];
			style.ApplyFontAttributes(element, false);
			style.ApplyFilterAttributes(element, false);
			style.ApplyClassAttributesToInnerElement(element, false);
		}
	}
	if(inputID != "")
		element.id = inputID;
	if(inputName != "")
		element.name = inputName;
	if(inputText != "")
		element.value = inputText;
	if(onFocus != "")
		element.onfocus = new Function(onFocus);
	if(onBlur != "")
		element.onblur = new Function(onBlur);
	if(onChange != "")
		element.onkeypress = new Function(onChange);
    if(readOnly)
		element.readOnly = true;
	if(!enabled)
		element.disabled = true;
	if(rowElement != null)
		CreateLFEditorContent(rowElement, controls);
	if(editorElement != null)
		CreateLFEditorProperties(editorElement, tooltip, width, height);
	return editorElement;
}

function CreateLFEditorProperties(editorElement, tooltip, width, height){
	if(tooltip != "")
		editorElement.title = tooltip;
	editorElement.style.width = width.ToString();
	editorElement.style.height = height.ToString();
}

function CreateLFEditorContent(parentElement, controls){
	if(controls != null){
		if(controls.length > 0){
			for(var i = 0; i < controls.length; i ++)
				parentElement.appendChild(controls[i]);		
		}
		else{
			parentElement.appendChild(controls);
		}			
	}
}

function InitializeLFEditorSize(parentElement, width, height){
	var editorElement = _getFirstChild(parentElement);
	if(width != null && width.type == "px"){
		width = width.value;
		_setElementWidth(editorElement, width);
	}
	if(height != null && height.type == "px"){
		height = height.value;
		_setElementHeight(editorElement, height);
	}
}

function IncrementLFEditorSize(parentElement, deltaWidth, deltaHeight){
	var editorElement = _getFirstChild(parentElement);
	
	var oldWidth = _getElementWidth(editorElement);
	var oldHeight = _getElementHeight(editorElement);
	var width = new ASPxClientUnit(oldWidth + deltaWidth, "px");
	var height = new ASPxClientUnit(oldHeight + deltaHeight, "px");
	InitializeLFEditorSize(parentElement, width, height);
}

function GetLFEditorRootElement(element){
	var rootElement = _getParentByTagName(element, "TABLE");
	if(rootElement != null){
		if(_getParentByCssClass(rootElement, "LFPopup") != null)
			rootElement = _getParentByTagName(rootElement, "TABLE");
	}
	return rootElement;
}

function OnLFEditorImageLoad(element){
	var rootElement = GetLFEditorRootElement(element);
	if(rootElement != null) CorrectLFEditorSize(rootElement);
}

function OnLFEditorResize(element){
	var rootElement = GetLFEditorRootElement(element);
	if(rootElement != null && !rootElement.displayed){
		CorrectLFEditorSize(rootElement);
		rootElement.displayed = true;
	}
}

function CanCorrectLFEditorSize(rootElement, width){
	return (width != null && ((!width.IsEmpty() && width.type != "%") || (rootElement.id == "")));
}

function CorrectLFEditorSize(rootElement){
	if(opera) return;
	
	var inputElement = _getChildByTagName(rootElement, "INPUT", 0);
	if(inputElement != null){
		var width = ASPxClientUnit.Parse(rootElement.style.width);
		if(CanCorrectLFEditorSize(rootElement, width)){
			_setElementWidth(inputElement, 0);
			_setElementWidth(inputElement, _getElementWidth(_getParentNode(inputElement)));
		}
	}
}