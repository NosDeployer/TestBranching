/* 
   ASPxDataControls Library by Developer Express

   Copyright (c) 2000-2005 Developer Express Inc  
   ALL RIGHTS RESERVED

   The entire contents of this file is protected by U.S. and   
   International Copyright Laws. Unauthorized reproduction,     
   reverse-engineering, and distribution of all or any portion of   
   the code contained in this file is strictly prohibited and may  
   result in severe civil and criminal penalties and will be        
   prosecuted to the maximum extent possible under the law.
*/

function ASPxLookAndFeelPopup(name){
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	
	
	this.containerElement = null;
	this.rootElement = null;
	this.focusElement = null;
	this.fakeContainerElement = null;
	
	this.popupContainerWidth = null;
	this.popupContainerHeight = null;

	this.CheckRootElement = function(element){
		if(element != null){
			var rootElement = _getParentById(element, this.name);
			if(rootElement != null && rootElement != this.rootElement){
				this.SetRootElement(rootElement);
				return true;
			}
		}
		return false;
	}
	this.GetRootElement = function(){
		if(this.rootElement == null)
			this.rootElement = _getElementById(this.name);
		return this.rootElement;
	}
	this.SetRootElement = function(element){
		this.rootElement = element;
		this.focusElement = null;
	}
	this.GetFocusElement = function(){
		if(this.focusElement == null && this.GetRootElement() != null){
			this.focusElement = _getChildByTagName(this.GetRootElement(), "INPUT", 0);
			if(this.focusElement != null && this.focusElement.tabIndex == -1)
				this.focusElement = _getParentNode(this.focusElement);
		}
		return this.focusElement;
	}
	this.GetContainerElement = function(){
		if(this.containerElement == null)
			this.containerElement = _getElementById(this.name + "Container");
		return this.containerElement;
	}
	this.GetFakeContainerElement = function(){
		if(this.fakeContainerElement == null){ 
			this.fakeContainerElement = document.createElement("IFRAME");
			this.fakeContainerElement.style.position = "absolute";
			this.fakeContainerElement.style.left = 0;
			this.fakeContainerElement.style.top = 0;
			this.fakeContainerElement.style.visibility = "hidden";
			this.fakeContainerElement.scrolling = "no";
			this.fakeContainerElement.frameBorder = "no";
			this.fakeContainerElement.src = "null";
		}
		return this.fakeContainerElement;
	}
	this.GetButtonElement = function(){
		return (this.GetRootElement() != null) ? _getChildById(this.GetRootElement(), this.name + "Btn") : null;
	}
	this.InitializeControl = function(){
		var containerElement = this.GetContainerElement();
		var fakeContainerElement = this.GetFakeContainerElement();
		if(containerElement != null){
			containerElement.LFPopup = this;
			var td = _getParentNode(containerElement);
			var tr = _getParentNode(td);
			_removeElement(containerElement);
			var hostElement = _getServerForm();
			if(hostElement == null) 
				hostElement = document.body;
			if(hostElement != null){
				if(ie && fakeContainerElement != null)
					hostElement.appendChild(fakeContainerElement);
				hostElement.appendChild(containerElement);
				containerElement.style.left = 0;
				containerElement.style.top = 0;
				if(containerElement.style.width == ""){
					var popupWidth = _getElementWidth(td);
					_setElementWidth(containerElement, popupWidth);
				}
				_removeElement(tr);
			}
		}
	}
	this.Finalize = function(){
		if(this.containerElement != null)
			_removeElement(this.containerElement);
		if(this.fakeContainerElement != null)
			_removeElement(this.fakeContainerElement);
	}

	this.CorrectPopupContainerHeight = function(height){
		var containerElement = this.GetContainerElement();
		if(this.popupContainerHeight != null && this.popupContainerHeight.type == "px"){
			var popupContainerStyle = ASPxStyle.GetStyleByElement(containerElement);
			if(this.popupContainerHeight.value > height){
				_setElementHeight(containerElement, height);
				_setElementHeight(_getFirstChild(containerElement), height);
				_setElementHeight(_getFirstChild(_getFirstChild(containerElement)), height);
			}
			else{
				_setElementHeight(containerElement, this.popupContainerHeight.ToString());
				var innerHeight = popupContainerStyle.GetClientHeight(this.popupContainerHeight);
				_setElementHeight(_getFirstChild(containerElement), innerHeight.ToString());
				_setElementHeight(_getFirstChild(_getFirstChild(containerElement)), innerHeight.ToString());
			}
			this.CorrectFakePopupContainerSize();
		}
	}
	this.CorrectFakePopupContainerSize = function(){
		var containerElement = this.GetContainerElement();
		if(ie && containerElement != null){
			var fakeContainerElement = this.GetFakeContainerElement();
			if(fakeContainerElement != null){
				_setElementWidth(fakeContainerElement, _getElementWidth(containerElement));
				_setElementHeight(fakeContainerElement, _getElementHeight(containerElement));
			}
		}
	}
	this.IsDropedDown = function(){
		return _getElementVisibility(this.GetContainerElement());
	}
	this.HidePopup = function(){
		this.CheckInitialized();
		var containerElement = this.GetContainerElement();
		if(containerElement != null){
			if(ie){
				var fakeContainerElement = this.GetFakeContainerElement();
				if(fakeContainerElement != null)
					_setElementVisibility(fakeContainerElement, false);
			}
			_setElementVisibility(containerElement, false);
			this.OnCloseUp();
		}
	}
	this.ShowPopup = function(){
		this.CheckInitialized();
		var containerElement = this.GetContainerElement();
		var rootElement =  this.GetRootElement();
		if(containerElement != null && rootElement != null){
			var editorElement = _getParentNode(rootElement);
			var xPos = _absoluteX(editorElement, "", false, false, true, true);
			var yPos = _absoluteY(editorElement, "", false, false, true, true) + _getElementHeight(editorElement);
			if(yPos + _getElementHeight(containerElement) > document.body.scrollTop + document.body.clientHeight)
				if(yPos - _getElementHeight(containerElement) - _getElementHeight(editorElement) > document.body.scrollTop)
					yPos = yPos - _getElementHeight(containerElement) - _getElementHeight(editorElement);
			_setElementLeft(containerElement, xPos);
			_setElementTop(containerElement, yPos);
			if(this.popupContainerWidth == null)
				_setElementWidth(containerElement, _getElementWidth(rootElement));
			if(ie){
				var fakeContainerElement = this.GetFakeContainerElement();
				if(fakeContainerElement != null){
					fakeContainerElement.style.zIndex = containerElement.style.zIndex - 1;
					_setElementLeft(fakeContainerElement, xPos);
					_setElementTop(fakeContainerElement, yPos);
					this.CorrectFakePopupContainerSize();
					_setElementVisibility(fakeContainerElement, true);
				}
			}
			_setElementVisibility(containerElement, true);
			this.OnDropDown();
		}
	}
	this.TogglePopup = function(element){
		if(this.CheckRootElement(element))
			this.ShowPopup();
		else if(this.IsDropedDown())
			this.HidePopup();
		else
			this.ShowPopup();
	}
	this.Focus = function(){
		var focusElement = this.GetFocusElement();
		if(focusElement != null){
			_focusElement(focusElement);
			_selectElement(focusElement);
		}
	}
	this.SetEnabled = function(enabled){
		var buttonElement = this.GetButtonElement();		
		if(buttonElement != null) buttonElement.disabled = !enabled;
	}
	this.DoKeyDown = function(e){
		var evt = _getEvent(e);
		switch(evt.keyCode){
			case kbDown:
			case kbUp:{
				if(_getAltKey(evt)){
					this.TogglePopup();
					return krHandled;
				}
				break;
			}
			case kbTab:{
				this.HidePopup();
				return krUnhandled;
			}
			case kbEnter:
			case kbEsc:{
				if(this.IsDropedDown()){
					this.HidePopup();
					return krHandled;
				}
			}
		}		
		return krUnhandled;
	}
	
	this.CloseUp = new ASPxClientEvent();
	this.DropDown = new ASPxClientEvent();
	
	this.OnCloseUp = function(){
		var args = new ASPxClientEventArgs();
		this.CloseUp.FireEvent(this, args);
	}
	this.OnDropDown = function(){
		var args = new ASPxClientEventArgs();
		this.DropDown.FireEvent(this, args);
	}
	
	GetLookAndFeelPopupCollection().Add(this);
}

function ASPxPopupCollection(){
	this.inherit = ASPxClientCollection;
	this.inherit();
	
	this.HideAll = function(srcElement){
		for(var i = 0; i < this.elements.length; i++){
			if(srcElement == null)
				this.elements[i].HidePopup();
			else if(_getParentById(srcElement, this.elements[i].name) == null && 
				_getParentById(srcElement, this.elements[i].name + "Btn") == null && 
				_getParentById(srcElement, this.elements[i].name + "Container") == null)
				this.elements[i].HidePopup();
		}
	}

}

function GetLookAndFeelPopupCollection(){
	if(__ASPxLookAndFeelPopupCollection == null){
		__ASPxLookAndFeelPopupCollection = new ASPxPopupCollection();
	}
	return __ASPxLookAndFeelPopupCollection;
}

function OnLFPToggle(element, name){
	var LFPopup = GetLookAndFeelPopupCollection().Get(name);
	if(LFPopup != null) LFPopup.TogglePopup(element);
}

function OnLFPHide(name){
	var LFPopup = GetLookAndFeelPopupCollection().Get(name);
	if(LFPopup != null) LFPopup.HidePopup();
}

function LFPDocumentOnMouseDown(e){
	GetLookAndFeelPopupCollection().HideAll(_getEventSource(e));
	if(_isExists(savedLFPDocumentOnMouseDown)) 
		return savedLFPDocumentOnMouseDown(e);
	return true;
}

function LFPWindowOnResize(e){
	GetLookAndFeelPopupCollection().HideAll(null);
	if(_isExists(savedLFPWindowOnResize)) 
		return savedLFPWindowOnResize();
	return true;
}

function LFPDocumentOnSelectStart(e){
	var element = _getEventSource(e);
	if(_getParentByCssClass(element, "LFPopup") != null && element.tagName != "INPUT") 
		return false;
	else if(_getParentByCssClass(element, "LFPopupContainer") != null) 
		return false;
	else if(_isExists(savedLFPDocumentOnSelectStart)) 
		return savedLFPDocumentOnSelectStart(e);
	return true;
}

var LFPFirstLoad;
if(typeof(savedLFPWindowOnLoad) == "undefined"){
	var __ASPxLookAndFeelPopupCollection = null;
	var savedLFPWindowOnLoad = window.onload;
	var savedLFPDocumentOnMouseDown = null;
	var savedLFPWindowOnResize = null;
	var savedLFPDocumentOnSelectStart = null;
	LFPFirstLoad = true;
}

window.onload = function(){
	if(LFPFirstLoad){
		savedLFPDocumentOnMouseDown = window.document.onmousedown;
		window.document.onmousedown = LFPDocumentOnMouseDown;
		savedLFPWindowOnResize = window.onresize;
		window.onresize = LFPWindowOnResize;
		savedLFPDocumentOnSelectStart = window.document.onselectstart;
		window.document.onselectstart = LFPDocumentOnSelectStart;
		GetLookAndFeelPopupCollection().Initialize(true);
		LFPFirstLoad = false;
	}
	else
		window.setTimeout("GetLookAndFeelPopupCollection().Initialize(false)", 0);

	if(_isExists(savedLFPWindowOnLoad)) 
		return savedLFPWindowOnLoad();
	return true;
}