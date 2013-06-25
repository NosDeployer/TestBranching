function CreateLFButton(parentElement, id, registerId, lookAndFeel, renderAsTable, templateContainer, controls, imgUrl, imgHotUrl, imgPressUrl, text, enabled, tooltip, onClick, width, height){
	var buttonElement = null;
	var element = null;
	var style = GetLookAndFeelStyleCollection().GetButtonStyle(GetStyleName(registerId), lookAndFeel);
	var fixedWidth = ((style != null) ? style.fixedWidth : false) && !width.IsEmpty();
	var fixedHeight = ((style != null) ? style.fixedHeight : false) && !height.IsEmpty();

	if(renderAsTable) {
		element = document.createElement("TABLE");
		if(parentElement != null)
			parentElement.appendChild(element);
		element.border = 0;
		element.cellSpacing = 0;
		element.cellPadding = 0;
		if(buttonElement == null){
			buttonElement = element;
			if(style != null)
				style.ApplyStyleAttributes(element, true);
		}
		parentElement = element;
		element = document.createElement("TBODY");
		parentElement.appendChild(element);
		element.className = "LFBtn";
		parentElement = element;
		element = document.createElement("TR");		
		parentElement.appendChild(element);		
		parentElement = element;
	}
	if(templateContainer != null) 
		element = templateContainer;
	else
		element = document.createElement("TD");
	if(parentElement != null)
		parentElement.appendChild(element);
	if(buttonElement == null){
		buttonElement = element;
		if(style != null)
			style.ApplyStyleAttributes(element, templateContainer == null);
	}
	if(style != null && !fixedWidth && !fixedHeight)
		style.ApplyTableItemAttributes(element, false);
	parentElement = element;
	if(buttonElement != null)
		CreateLFButtonProperties(buttonElement, id, registerId, lookAndFeel, style, imgUrl, imgHotUrl, imgPressUrl, enabled, tooltip, onClick, width, height);
	if(templateContainer == null)
		CreateLFButtonContent(parentElement, style, controls, imgUrl, text, width, height, fixedWidth, fixedHeight);
	return buttonElement;
}

function CreateLFButtonProperties(buttonElement, id, registerId, lookAndFeel, style, imgUrl, imgHotUrl, imgPressUrl, enabled, tooltip, onClick, width, height){
	buttonElement.id = id;
	buttonElement.disabled = !enabled;
	buttonElement.title = tooltip;
	buttonElement.style.width = width.ToString();
	buttonElement.style.height = height.ToString();
	buttonElement.style.cursor = "default";
	if(lookAndFeel != null && style != null){
		var useHotTrackStyle = style.useHotTrackStyle;
		if(useHotTrackStyle == null) useHotTrackStyle = lookAndFeel.UseHotTrackStyle;
		var usePressedStyle = style.usePressedStyle;
		if(usePressedStyle == null) usePressedStyle = lookAndFeel.UsePressedStyle;

		var lfCode = GetCodeByLookAndFeel(lookAndFeel);		
		if(useHotTrackStyle || usePressedStyle){
			var styleRegisterId = useHotTrackStyle ? registerId : "";
			buttonElement.onmouseover = new Function("OnLFBMouseOver(this, " + lfCode + ", " + GetBooleanExString(style.useHotTrackStyle) + ", \"" + styleRegisterId + "\", \"" + imgHotUrl + "\");");
			buttonElement.onmouseout = new Function("OnLFBMouseOut(this);");	
		}
		if(usePressedStyle)
			buttonElement.onmousedown = new Function("OnLFBMouseDown(this, " + lfCode + ", " + GetBooleanExString(style.usePressedStyle) + ", \"" + registerId + "\", \"" + imgPressUrl + "\", 0);");
	}
	buttonElement.onclick = onClick;
}

function CreateLFButtonContent(parentElement, style, controls, imgUrl, text, width, height, fixedWidth, fixedHeight){
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
			element.style.width = clientWidth.ToString();
		if(clientHeight != null)
			element.style.height = clientHeight.ToString();
		parentElement = element;
		
		element = document.createElement("TABLE");
		parentElement.appendChild(element);
		element.border = 0;
		element.cellSpacing = 0;
		element.cellPadding = 0;
		element.style.width = "100%";
		element.style.height = "100%";
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
	if(controls != null){
		if(controls.length > 0){
			for(var i = 0; i < controls.length; i ++)
				parentElement.appendChild(controls[i]);		
		}
		else{
			parentElement.appendChild(controls);
		}			
	}
	else{
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
		if(imgUrl != ""){
			element = document.createElement("IMG");
			parentElement.appendChild(element);			
			element.align = "absmiddle";
			element.src = imgUrl;
			element.ondragstart = new Function("return OnDS(this)");
		}
		if(text != ""){
			element = document.createTextNode(text);
			parentElement.appendChild(element);
		}
	}
}

function InitializeLFButton(parentElement, id, registerId, lookAndFeel, renderAsTable, templateContainer, controls, imgUrl, imgHotUrl, imgPressUrl, text, enabled, tooltip, onClick, width, height){
	var buttonElement = _getFirstChild(parentElement);
	CreateLFButtonProperties(buttonElement, id, registerId, lookAndFeel, null, imgUrl, imgHotUrl, imgPressUrl, enabled, tooltip, onClick, width, height);
	if(imgUrl != ""){
		var img = _getChildByTagName(buttonElement, "IMG", 0);
		if(img != null)
			img.src = imgUrl;
	}
	if(text != ""){
		var style = GetLookAndFeelStyleCollection().GetButtonStyle(GetStyleName(registerId), lookAndFeel);
		var fixedWidth = ((style != null) ? style.fixedWidth : false) && !width.IsEmpty();
		var fixedHeight = ((style != null) ? style.fixedHeight : false) && !height.IsEmpty();			
		if(fixedWidth)
			buttonElement = _getChildByTagName(buttonElement, "SPAN", 0);
		else if(fixedHeight)
			buttonElement = _getChildByTagName(buttonElement, "TD", 0);
		var textNode = _getLastChild(buttonElement);
		if(textNode != null && textNode.tagName == "undefined")
			textNode.nodeValue = text;
	}
}

function InitializeLFButtonSize(parentElement, width, height){
	var buttonElement = _getFirstChild(parentElement);
	var divElement = _getChildByTagName(parentElement, "DIV", 0);
	var spanElement = _getChildByTagName(parentElement, "SPAN", 0);
	var buttonStyle = ASPxStyle.GetStyleByElement(buttonElement);
	
	if(width != null && width.type == "px"){
		_setElementWidth(buttonElement, width.value);
		if(divElement != null){
			var buttonClientWidth = (buttonStyle != null) ? buttonStyle.GetClientWidth(width) : width;
			_setElementWidth(divElement, buttonClientWidth.value);
			if(spanElement != null)
				_setElementWidth(spanElement, buttonClientWidth.value);
		}
	}
	if(height != null && height.type == "px"){
		_setElementHeight(buttonElement, height.value);
		if(divElement != null){
			var buttonClientHeight = (buttonStyle != null) ? buttonStyle.GetClientHeight(height) : height;
			_setElementHeight(divElement, buttonClientHeight.value);
		}
	}
}

function IncrementLFButtonSize(parentElement, deltaWidth, deltaHeight){
	var buttonElement = _getFirstChild(parentElement);
	
	var oldWidth = _getElementWidth(buttonElement);
	var oldHeight = _getElementHeight(buttonElement);
	var width = new ASPxClientUnit(oldWidth + deltaWidth, "px");
	var height = new ASPxClientUnit(oldHeight + deltaHeight, "px");
	InitializeLFButtonSize(parentElement, width, height);
}

function LFButtonStateObject(){
	this.element = null;
	this.style = null;
	this.imageUrl = "";
	
	this.ApplyState = function(oldState){
		if(this.IsEmpty()) return;
		var oldStyle = null;
		if(this.style != null){
			oldStyle = this.style.ApplyStyleAspButtonState(this.element);
			this.style.ApplyFontAttributesToTables(this.element, false, false);
		}
		var oldImageUrl = "";
		var imgElement = this.GetImageElement();
		if(imgElement != null && this.imageUrl != ""){
			oldImageUrl = imgElement.src;
			imgElement.src = this.imageUrl;	
		}
		this.ApplyStatePaddings();
		if(_isExists(oldState))
			oldState.SetAttributes(this.element, oldStyle, oldImageUrl);
	}
	this.ApplyStatePaddings = function(){
		var textContainer = _getChildByCssClass(this.element, "LFBtnTextContainer");
		if(textContainer != null && textContainer.textShifted){
			var paddingLeft = ASPxClientUnit.Parse(textContainer.style.paddingLeft).Inc(-1);
			var paddingTop = ASPxClientUnit.Parse(textContainer.style.paddingTop).Inc(-1);
			var paddingRight = ASPxClientUnit.Parse(textContainer.style.paddingRight).Inc(1);
			var paddingBottom = ASPxClientUnit.Parse(textContainer.style.paddingBottom).Inc(1);
			textContainer.style.paddingLeft = paddingLeft.ToString();
			textContainer.style.paddingTop = paddingTop.ToString();
			textContainer.style.paddingRight = paddingRight.ToString();
			textContainer.style.paddingBottom = paddingBottom.ToString();
			textContainer.textShifted = false;
		}
	}
	this.GetImageElement = function(){
		return (this.element != null) ? _getChildByTagName(this.element, "IMG", 0) : null;
	}
	this.Clear = function(){
		if(this.style != null)
			ASPxStyle.RemoveStyle(this.style);
		this.element = null;
		this.style = null;
		this.imageUrl = "";
	}
	this.SetAttributes = function(element, style, imageUrl){
		this.element = element;
		this.style = style;
		this.imageUrl = imageUrl;
	}
	this.IsEmpty = function(){
		return this.element == null;
	}
}

var repeatingInterval = 60;
var startRepeatingInterval = 400;

function LFButtonPressedStateObject(){
	this.inherit = LFButtonStateObject;
	this.inherit();	
	
	this.timerID = -1;
	this.timerCount = 0;
	this.timerInterval = 0;

	this.ApplyStatePaddings = function(){
		var textContainer = _getChildByCssClass(this.element, "LFBtnTextContainer");
		if(textContainer != null){
			var paddingLeft = ASPxClientUnit.Parse(textContainer.style.paddingLeft).Inc(1);
			var paddingTop = ASPxClientUnit.Parse(textContainer.style.paddingTop).Inc(1);
			var paddingRight = ASPxClientUnit.Parse(textContainer.style.paddingRight).Inc(-1);
			var paddingBottom = ASPxClientUnit.Parse(textContainer.style.paddingBottom).Inc(-1);
			textContainer.style.paddingLeft = paddingLeft.ToString();
			textContainer.style.paddingTop = paddingTop.ToString();
			textContainer.style.paddingRight = paddingRight.ToString();
			textContainer.style.paddingBottom = paddingBottom.ToString();
			textContainer.textShifted = true;
		}
	}
	this.SetTimer = function(element){
		this.element = element;
		this.timerInterval = repeatingInterval;
		this.timerID = window.setTimeout(OnLFBTimer, startRepeatingInterval);
	}
	this.ClearTimer = function(){
		if(this.timerInterval > 0){
			this.DisableTimer();
			this.timerInterval = 0;
		}
	}
	this.EnableTimer = function(){
		if(this.element != null && this.timerInterval > 0)
			this.SetTimer(this.element, this.timerInterval);
			
	}
	this.DisableTimer = function(){
		if(this.timerInterval > 0){
			window.clearTimeout(this.timerID);
			this.timerID = -1;
		}
	}
	this.DoTimer = function(){
		if(this.timerInterval > 0){
			this.timerCount ++;
			this.element.onclick();
			this.timerID = window.setTimeout(OnLFBTimer, this.timerInterval);
		}
	}
}

var LFButtonStateObjects = new Array();
LFButtonStateObjects["normal"] = new LFButtonStateObject();
LFButtonStateObjects["hottracked"] = new LFButtonStateObject();
LFButtonStateObjects["pressed"] = new LFButtonPressedStateObject();

function GetLFBHotTrackStyle(element, lookAndFeel, registerId){
	var style = ASPxStyle.CreateStyle();
	if(_getChildByCssClass(element, "LFSBtn") != null){
		style.MergeStyle(GetLookAndFeelStyleCollection().GetStandaloneButtonStyle(GetStyleName(registerId), lookAndFeel));
		style.MergeStyle(GetLookAndFeelStyleCollection().GetStandaloneButtonHotTrackStyle(GetHotTrackedStyleName(registerId), lookAndFeel));
	}
	else if(_getChildByCssClass(element, "LFSBBtn") != null || _getParentByCssClass(element, "LFScrollBar") != null){
		style.MergeStyle(GetLookAndFeelStyleCollection().GetScrollBarButtonStyle(GetStyleName(registerId), lookAndFeel));
		style.MergeStyle(GetLookAndFeelStyleCollection().GetScrollBarButtonHotTrackStyle(GetHotTrackedStyleName(registerId), lookAndFeel));
	}
	else{
		style.MergeStyle(GetLookAndFeelStyleCollection().GetButtonStyle(GetStyleName(registerId), lookAndFeel));
		style.MergeStyle(GetLookAndFeelStyleCollection().GetButtonHotTrackStyle(GetHotTrackedStyleName(registerId), lookAndFeel));
	}
	return style;
}

function GetLFBPressedStyle(element, lookAndFeel, registerId){
	var style = ASPxStyle.CreateStyle();
	if(_getChildByCssClass(element, "LFSBtn") != null){
		style.MergeStyle(GetLookAndFeelStyleCollection().GetStandaloneButtonStyle(GetStyleName(registerId), lookAndFeel));
		style.MergeStyle(GetLookAndFeelStyleCollection().GetStandaloneButtonPressedStyle(GetPressedStyleName(registerId), lookAndFeel));
	}
	else if(_getChildByCssClass(element, "LFSBBtn") != null || _getParentByCssClass(element, "LFScrollBar") != null){
		style.MergeStyle(GetLookAndFeelStyleCollection().GetScrollBarButtonStyle(GetStyleName(registerId), lookAndFeel));
		style.MergeStyle(GetLookAndFeelStyleCollection().GetScrollBarButtonPressedStyle(GetPressedStyleName(registerId), lookAndFeel));
	}
	else{
		style.MergeStyle(GetLookAndFeelStyleCollection().GetButtonStyle(GetStyleName(registerId), lookAndFeel));
		style.MergeStyle(GetLookAndFeelStyleCollection().GetButtonPressedStyle(GetPressedStyleName(registerId), lookAndFeel));
	}
	return style;
}

function OnLFBMouseOver(element, lfCode, useHotTrackStyle, registerId, imgUrl){
	if(!scriptsLoaded || !hotTrackEnabled) return false;
	if(!LFButtonStateObjects["hottracked"].IsEmpty()) return false;
	if(ie && _getIsParent(element, event.fromElement)) return false;
	
	var lookAndFeel = GetLookAndFeelByCode(lfCode);
	if(lookAndFeel != null){
		var style = ASPxStyle.CreateStyle();
		if(useHotTrackStyle == null) 
			useHotTrackStyle = lookAndFeel.UseHotTrackStyle;
		if(useHotTrackStyle){
			style.MergeStyle(GetLFBHotTrackStyle(element, lookAndFeel, registerId));
			LFButtonStateObjects["hottracked"].SetAttributes(element, style, imgUrl);
		}
		if(LFButtonStateObjects["pressed"].IsEmpty()){
			var oldState = LFButtonStateObjects["normal"].IsEmpty() ? LFButtonStateObjects["normal"] : null;
			LFButtonStateObjects["hottracked"].ApplyState(oldState);
		}
		else if(!ie || _getIsParent(LFButtonStateObjects["pressed"].element, _getEventSource(event))){
			LFButtonStateObjects["pressed"].ApplyState(null);
			LFButtonStateObjects["pressed"].EnableTimer();
			
		}
	}
	return true;	
}

function OnLFBMouseOut(element){
	if(ie && _getIsParent(element, event.toElement)) return false;

	LFButtonStateObjects["normal"].ApplyState();
	if(LFButtonStateObjects["pressed"].IsEmpty())
		LFButtonStateObjects["normal"].Clear();
	else
		LFButtonStateObjects["pressed"].DisableTimer();
	LFButtonStateObjects["hottracked"].Clear();
	return true;
}

function OnLFBMouseDown(element, lfCode, usePressedStyle, registerId, imgUrl, repeating){
	if(!scriptsLoaded || !pressedEnabled) return false;
	if(ie && !_isLeftMouseButtonPressed(event)) return false;
	var lookAndFeel = GetLookAndFeelByCode(lfCode);
	if(lookAndFeel != null){
		var style = ASPxStyle.CreateStyle();
		if(usePressedStyle == null) 
			usePressedStyle = lookAndFeel.UsePressedStyle;
		if(usePressedStyle){
			style.MergeStyle(GetLFBPressedStyle(element, lookAndFeel, registerId));
			LFButtonStateObjects["pressed"].SetAttributes(element, style, imgUrl);
		}
		var oldState = LFButtonStateObjects["normal"].IsEmpty() ? LFButtonStateObjects["normal"] : null;
		LFButtonStateObjects["pressed"].ApplyState(oldState);
	}
	if(repeating)
		LFButtonStateObjects["pressed"].SetTimer(element);
	return true;	
}

function OnLFBMouseUp(e){
	if(LFButtonStateObjects["pressed"].IsEmpty()) return false;
	
	var inButton = _getIsParent(LFButtonStateObjects["pressed"].element, _getEventSource(e));
	LFButtonStateObjects["pressed"].ClearTimer();
	LFButtonStateObjects["pressed"].Clear();
	if(!LFButtonStateObjects["hottracked"].IsEmpty() && inButton) 
		LFButtonStateObjects["hottracked"].ApplyState();
	else{
		LFButtonStateObjects["hottracked"].Clear();
		LFButtonStateObjects["normal"].ApplyState();
		LFButtonStateObjects["normal"].Clear();
	}
}

function OnLFBTimer(){
	if(!LFButtonStateObjects["pressed"].IsEmpty())
		LFButtonStateObjects["pressed"].DoTimer();
}


function LFBDocumentOnMouseMove(e){
	var evt = _getEvent(e);
	if(!LFButtonStateObjects["pressed"].IsEmpty() && !_isLeftMouseButtonPressed(evt))	
		OnLFBMouseUp(e);
	if(!LFButtonStateObjects["hottracked"].IsEmpty() && LFButtonStateObjects["hottracked"].element.disabled)
		OnLFBMouseOut(LFButtonStateObjects["hottracked"].element);		
	if(_isExists(savedLFBDocumentOnMouseMove)) 
		return savedLFBDocumentOnMouseMove(e);
	return true;
}

function LFBDocumentOnMouseUp(e){
	OnLFBMouseUp(e);
	if(_isExists(savedLFBDocumentOnMouseUp)) 
		return savedLFBDocumentOnMouseUp(e);
	return true;
}

function LFBDocumentOnSelectStart(e){
	var element = _getEventSource(e);
	if(_getParentByCssClass(element, "LFSBtn") != null) 
		return false;
	if(_getParentByCssClass(element, "LFSBBtn") != null) 
		return false;
	if(_getParentByCssClass(element, "LFBtn") != null) 
		return false;
	else if(_isExists(savedLFBDocumentOnSelectStart)) 
		return savedLFBDocumentOnSelectStart(e);
	return true;
}

var LFBFirstLoad;
if(typeof(savedLFBWindowOnLoad) == "undefined"){
	var savedLFBWindowOnLoad = window.onload;	
	var savedLFBDocumentOnMouseMove = null;
	var savedLFBDocumentOnMouseUp = null;
	var savedLFBDocumentOnSelectStart = null;
	LFBFirstLoad = true;
}

window.onload = function(e){
	if(LFBFirstLoad){
		savedLFBDocumentOnMouseMove = window.document.onmousemove;
		window.document.onmousemove = LFBDocumentOnMouseMove;
		savedLFBDocumentOnMouseUp = window.document.onmouseup;
		window.document.onmouseup = LFBDocumentOnMouseUp;
		savedLFBDocumentOnSelectStart = window.document.onselectstart;
		window.document.onselectstart = LFBDocumentOnSelectStart;
		LFBFirstLoad = false;
	}
	
	if(_isExists(savedLFBWindowOnLoad)) 
		return savedLFBWindowOnLoad(e);
	return true;
}