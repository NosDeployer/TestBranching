function CreateLFLabel(parentElement, registerId, lookAndFeel, renderAsTable, useEditorStyle, text, textPadding, width, height){
	var labelElement = null;
	var element = null;
	var style = null;
	if(useEditorStyle)
		style = GetLookAndFeelStyleCollection().GetEditorStyle(registerId + "S", lookAndFeel);	
	else
		style = GetLookAndFeelStyleCollection().GetLabelStyle(registerId + "S", lookAndFeel);	
	var fixedWidth = ((style != null) ? style.fixedWidth : false) && !width.IsEmpty();
	var fixedHeight = ((style != null) ? style.fixedHeight : false) && !height.IsEmpty();
	
	if(renderAsTable) {
		element = document.createElement("TABLE");
		if(parentElement)
			parentElement.appendChild(element);
		element.border = 0;
		element.cellSpacing = 0;
		element.cellPadding = 0;
		if(labelElement == null){
			labelElement = element;
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
	}
	element = document.createElement("TD");
	if(parentElement != null)
		parentElement.appendChild(element);
	if(labelElement == null){
		labelElement = element;
		if(style != null)
			style.ApplyStyleAttributes(element, true);
	}
	if(style != null && !fixedWidth && !fixedHeight)
		style.ApplyTableItemAttributes(element, false);
	parentElement = element;
	if(labelElement != null)
		CreateLFLabelProperties(labelElement, width, height);
	CreateLFLabelContent(parentElement, style, text, textPadding, width, height, fixedWidth, fixedHeight);
	return labelElement;
}

function CreateLFLabelProperties(labelElement, width, height){
	labelElement.style.width = width.ToString();
	labelElement.style.height = height.ToString();
}

function CreateLFLabelContent(parentElement, style, text, textPadding, width, height, fixedWidth, fixedHeight){
	if(fixedWidth || fixedHeight){
		var clientWidth = (style != null) ? style.GetClientWidth(width) : width;
		var clientHeight = (style != null) ? style.GetClientHeight(height) : height;

		element = document.createElement("DIV");
		parentElement.appendChild(element);
		if(ie){
			if(fixedWidth)
				element.style.overflowX = "hidden";
			if(fixedHeight)
				element.style.overflowY = "hidden";
		}
		else
			element.style.overflow = "hidden";		
		if(clientWidth != null)
			element.style.width = fixedWidth ? clientWidth.ToString() : "100%";
		if(clientHeight != null)
			element.style.height = fixedHeight ? clientHeight.ToString() : "100%";
		parentElement = element;
		
		element = document.createElement("TABLE");
		parentElement.appendChild(element);
		element.border = 0;
		element.cellSpacing = 0;
		element.cellPadding = 0;
		element.width = "100%";
		element.height = "100%";
		if(style != null){
			style.ApplyFontAttributes(element, false);
			style.ApplyClassAttributesToInnerElement(element, false);
		}
		parentElement = element;
		element = document.createElement("TBODY");
		parentElement.appendChild(element);
		parentElement = element;
		element = document.createElement("TR");		
		parentElement.appendChild(element);		
		parentElement = element;
		element = document.createElement("TD");		
		parentElement.appendChild(element);	
		if(style != null){
			style.ApplyTableItemAttributes(element, false);
		}
		parentElement = element;
	}
	var endEllipsis = ((style != null) ? style.endEllipsis : false) && fixedWidth;
	if(text != "" && endEllipsis){
		var clientWidth = (style != null) ? style.GetClientWidth(width) : width;
		element = document.createElement("SPAN");
		parentElement.appendChild(element);
		if(clientWidth != null)
			element.style.width = clientWidth.ToString();
		element.style.overflow = "hidden";		
		element.style.textOverflow = "ellipsis";		
		parentElement = element;
	}
	if(text != ""){
		if(textPadding > 0){
			parentElement.style.paddingLeft = textPadding;
			parentElement.style.paddingRight = textPadding;
		}
		element = document.createTextNode(text);
		parentElement.appendChild(element);
	}
}

function InitializeLFLabelSize(parentElement, width, height){
	var labelElement = _getFirstChild(parentElement);
	var divElement = _getChildByTagName(parentElement, "DIV", 0);
	var spanElement = _getChildByTagName(parentElement, "SPAN", 0);
	if(width != null && width.type == "px"){
		width = width.value;
		var oldWidth = _getElementWidth(labelElement);
		if(divElement != null && divElement.style.width != "100%"){
			var oldWidth = _getElementWidth(labelElement);
			var borderWidth = oldWidth - _getElementWidth(divElement);
			_setElementWidth(divElement, width - borderWidth);
			if(spanElement != null)
				_setElementWidth(spanElement, width - borderWidth);
		}
		_setElementWidth(labelElement, width);
	}
	if(height != null && height.type == "px"){
		height = height.value;
		var oldHeight = _getElementHeight(labelElement);
		if(divElement != null && divElement.style.height != "100%"){
			var oldHeight = _getElementHeight(labelElement);
			var borderWidth = oldHeight - _getElementHeight(divElement);
			_setElementHeight(divElement, height - borderWidth);
			if(spanElement != null)
				_setElementHeight(spanElement, height - borderWidth);
		}
		_setElementHeight(labelElement, height);
	}
}

function IncrementLFLabelSize(parentElement, deltaWidth, deltaHeight){
	var labelElement = _getFirstChild(parentElement);
	
	var oldWidth = _getElementWidth(labelElement);
	var oldHeight = _getElementHeight(labelElement);
	var width = new ASPxClientUnit(oldWidth + deltaWidth, "px");
	var height = new ASPxClientUnit(oldHeight + deltaHeight, "px");
	InitializeLFLabelSize(parentElement, width, height);
}