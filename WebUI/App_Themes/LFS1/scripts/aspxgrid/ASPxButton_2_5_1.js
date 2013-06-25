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
function ASPxClientButton(name){
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	

	this.autoPostBack = true;
	this.causesValidation = false;
	this.isDefault = false;
	this.enabled = true;
	this.enableKeyboardProcessing = true;
	this.focused = false;
	
	this.rootElement = null;
	this.buttonElement = null;
	this.focusedElement = null;

	this.GetRoolElement = function(){
		if(!_isExists(this.rootElement))
			this.rootElement = _getElementById(this.name);
		return this.rootElement;
	}
	this.GetButtonElement = function(){
		if(!_isExists(this.buttonElement)){
			var element = this.GetRoolElement();
			if(element != null)
				this.buttonElement = this.IsNative() ? element : _getChildByTagName(element, "TABLE", 0);
		}
		return this.buttonElement;
	}
	this.GetFocusedElement = function(){
		if(!_isExists(this.focusedElement)){
			var element = this.GetRoolElement();
			if(element != null)
				this.focusedElement = this.IsNative() ? element : _getChildByTagName(element, "TD", 0);
		}
		return this.focusedElement;
	}

	this.InitializeControl = function(){
		if(this.focused) 
			this.FocusControl();
		if(this.isDefault) 
			GetButtonCollection().defaultButton = this;
	}
	
	this.OnLostFocus = function(){	
		if(__getFocusedControl() == this)
			__setFocusedControl(null);
		if(!this.isDefault || !GetButtonCollection().CanDefaultButtonAction())
			this.ClearFocusRect();
		if(!this.LostFocus.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.LostFocus.FireEvent(this, args);
		}
	}
	this.OnGetFocus = function(){
		__setFocusedControl(this);
		this.DrawFocusRect();
		if(!this.GotFocus.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.GotFocus.FireEvent(this, args);
		}
	}
	this.OnMouseUp = function(){
		this.FocusControl();
	}
	
	this.IsNative = function(){
		var element = this.GetRoolElement();
		return (element != null && element.tagName == "INPUT")
	}
	
	this.ClearFocusRect = function(){
		if(this.IsNative()) return;
		var element = this.GetRoolElement();
		if(element != null)
			element.style.backgroundColor = "transparent";
	}
	this.DrawFocusRect = function(){
		if(this.IsNative()) return;
		var element = this.GetRoolElement();
		if(element != null)
			element.style.backgroundColor = "windowframe";
	}
	
	this.FocusControl = function(){
		if(this.enabled){
			var element = this.GetFocusedElement();
			if(element != null) _focusElement(element);
		}
	}
	this.Activate = function(){
		this.DrawFocusRect();
	}
	this.Deactivate = function(){
		this.ClearFocusRect();
	}
	this.OnClickCore = function(){
		if(this.causesValidation && _isFunctionType(typeof(Page_ClientValidate))) 
			Page_ClientValidate();
		
		this.InitPostBack(null, "CLICK");
		var processingMode = this.OnClick();
		if(processingMode == "Server")
			this.SendPostBack(false);
	}

	this.OnMouseWheelCore = function(e){
		return false;
	}
	this.OnKeyDownCore = function(e){
		var evt = _getEvent(e);	
		if(this.OnKeyDown(evt))
			return krHandled;
		if(this.IsNative())
			return krSystem;
		if(evt.keyCode == kbSpace || (evt.keyCode == kbEnter && this.isDefault)){
			var element = this.GetButtonElement();
			if(element != null){
				if(element.onmousedown != null)
					element.onmousedown();
			}
			return krHandled;
		}
		return krUnhandled;
	}
	this.OnKeyUpCore = function(e){
		var evt = _getEvent(e);	
		if(this.OnKeyUp(evt))
			return krHandled;
		if(this.IsNative())
			return krSystem;
		if(evt.keyCode == kbSpace || (evt.keyCode == kbEnter && this.isDefault)){
			var element = this.GetButtonElement();
			if(element != null){
				if(element.onmouseup != null)
					element.onmouseup();
				if(element.onclick != null)
					element.onclick();
				if(_isFunctionType(typeof(OnLFBMouseUp)))
					OnLFBMouseUp(null);
			}
			return krHandled;
		}
		return krUnhandled;
	}
	this.IsMouseInControl = function(evt){
		return _getParentById(_getEventSource(evt), this.name);
	}
	this.IsDefaultButtonActionAllowed = function(){
		return true;
	}
	this.CanFocusedControl = function(){
		return true;
	}
	this.Focus = function(){
		this.FocusControl();
	}
	this.GetEnabled = function(){
		return this.enabled;
	}
	this.SetEnabled = function(enabled){
		this.enabled = enabled;
		var element = this.GetButtonElement();
		if(element != null) 
			element.disabled  = !this.enabled;
		if(this.isDefault)
			GetButtonCollection().RefreshDefaultButton();
	}
	this.Init = new ASPxClientEvent();
	this.Click = new ASPxClientEvent();
	this.KeyDown = new ASPxClientEvent();
	this.KeyUp = new ASPxClientEvent();
	this.GotFocus = new ASPxClientEvent();
	this.LostFocus = new ASPxClientEvent();

	this.OnInit = function(){
		if(!this.Init.IsEmpty()){
			var eventArgs = new ASPxClientEventArgs();
			this.Init.FireEvent(this, eventArgs);		
		}
	}
	this.OnClick = function(){
		if(!this.Click.IsEmpty()){
			var args = new ASPxClientProcessingModeEventArgs(this.autoPostBack);
			this.Click.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return this.autoPostBack ? "Server" : "Client";
	}
	this.OnKeyDown = function(evt){	
		if(!this.KeyDown.IsEmpty()){
			var args = new ASPxClientKeyEventArgs(evt.keyCode, _getAltKey(evt), _getCtrlKey(evt), _getShiftKey(evt));
			this.KeyDown.FireEvent(this, args);
			return args.handled;	
		}
		return false;
	}
	this.OnKeyUp = function(evt){	
		if(!this.KeyUp.IsEmpty()){
			var args = new ASPxClientKeyEventArgs(evt.keyCode, _getAltKey(evt), _getCtrlKey(evt), _getShiftKey(evt));
			this.KeyUp.FireEvent(this, args);
			return args.handled;	
		}
		return false;
	}

	GetButtonCollection().Add(this);
}
ASPxClientButton.GetButtonCollection = function(){
	return GetButtonCollection();
}

function ASPxButtonCollection(){
	this.inherit = ASPxClientCollection;
	this.inherit();
	
	this.formActive = false;
	this.defaultButton = null;
	
	this.CanDefaultButtonAction = function(){
		var ret = (this.formActive && this.defaultButton != null && this.defaultButton.enabled);
		var inputTypes = ["submit", "button", "reset"];
		ret = ret && (document.activeElement != null) && (document.activeElement.tagName != "BUTTON") &&
			(document.activeElement.tagName != "INPUT" || array_indexOf(inputTypes, document.activeElement.type) == -1);
		ret = ret && (document.activeElement != null) && ((_getParentByCssClass(document.activeElement, "LFSBtn") == null) ||
			(_getParentById(document.activeElement, this.defaultButton.name) != null));
		return ret;
	}
	this.ActivateDefaultButton = function(){
		this.CheckInitialized();
		this.formActive = true;
		this.RefreshDefaultButton();
	}
	this.RefreshDefaultButton = function(){
		if(this.defaultButton != null){
			if(this.CanDefaultButtonAction())
				this.defaultButton.Activate();
			else
				this.defaultButton.Deactivate();
		}
	}
	this.OnKeyDown = function(e){
		var evt = _getEvent(e);	
		if(evt.keyCode == kbEnter && this.defaultButton != null && this.CanDefaultButtonAction())
			return this.defaultButton.OnKeyDownCore(e);
		return krUnhandled;
	}
	this.OnKeyUp = function(e){
		var evt = _getEvent(e);	
		if(evt.keyCode == kbEnter && this.defaultButton != null && this.CanDefaultButtonAction())
			return this.defaultButton.OnKeyUpCore(e);
		return krUnhandled;
	}
	this.OnFormActivate = function(e){
		this.formActive = true;
		if(this.defaultButton != null && this.CanDefaultButtonAction())
			this.defaultButton.Activate();
	}
	this.OnFormDeactivate = function(e){
		this.formActive = false;
		if(this.defaultButton != null)
			this.defaultButton.Deactivate();
	}
}

function GetButtonCollection(){
	if(__ASPxClientButtonCollection == null){
		__ASPxClientButtonCollection = new ASPxButtonCollection();
	}
	return __ASPxClientButtonCollection;
}

function ButtonClick(name){
	var button = GetButtonCollection().Get(name);
	if(button != null) button.OnClickCore();
}

function OnBMouseUp(name){	
	var button = GetButtonCollection().Get(name);
	if(button != null) button.OnMouseUp();
}

function OnBGetFocus(name){	
	var button = GetButtonCollection().Get(name);
	if(button != null) button.OnGetFocus();	
}

var inBLostFocus = false;
function OnBLostFocus(name){
	if(inBLostFocus) return;

	inBLostFocus = true;
	var button = GetButtonCollection().Get(name);
	if(button != null) button.OnLostFocus();	
	inBLostFocus = false;
}

var savedButtonFormOnActivate = null;
function ButtonFormOnActivate(e){
	GetButtonCollection().OnFormActivate();
	if(_isExists(savedButtonFormOnActivate)) 
		return savedButtonFormOnActivate(e);
	return true;
}

var savedButtonFormOnDeactivate = null;
function ButtonFormOnDeactivate(e){
	GetButtonCollection().OnFormDeactivate();
	if(_isExists(savedButtonFormOnDeactivate)) 
		return savedButtonFormOnDeactivate(e);
	return true;
}

var ButtonFirstLoad;
if(typeof(savedButtonWindowOnLoad) == "undefined"){
	var __ASPxClientButtonCollection = null;
	var savedButtonWindowOnLoad = window.onload;
	ButtonFirstLoad = true;
}

window.onload = function(e){
	if(ButtonFirstLoad){
		if(_getServerForm() != null){
			savedButtonFormOnActivate = _getServerForm().onactivate;
			_getServerForm().onactivate = ButtonFormOnActivate;
			savedButtonFormOnDeactivate = _getServerForm().ondeactivate;
			_getServerForm().ondeactivate = ButtonFormOnDeactivate;
		}
		GetButtonCollection().Initialize(true);
		ButtonFirstLoad = false;
	}
	else
		window.setTimeout("GetButtonCollection().Initialize(false)", 0);
	
	if(_isExists(savedButtonWindowOnLoad)) 
		return savedButtonWindowOnLoad();
	return true;
}