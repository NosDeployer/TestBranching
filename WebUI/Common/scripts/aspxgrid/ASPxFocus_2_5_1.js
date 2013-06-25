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

var focusedControl = null;
var savedFocusedControl = null;
var canChangeFocusedControl = true;

function __getFocusedControl(){
	return focusedControl;
}

function __setFocusedControl(control){
	if(!canChangeFocusedControl) return;
	if(control != focusedControl){
 		focusedControl = control;
 		__updateFocusedControl();
	}
}

function __updateFocusedControl(){
	var focusedInput = _getHiddenInput("__focusedControl");
	if(focusedInput != null)
		focusedInput.value = (focusedControl != null) ? focusedControl.name : "";
}

function FocusDocumentOnMouseWheel(e){
	if(focusedControl != null && focusedControl.IsMouseInControl(e))
		return !focusedControl.OnMouseWheelCore(e);
	if(_isExists(savedFocusDocumentOnMouseWheel))
		return savedFocusDocumentOnMouseWheel(e);
	return true;
}

function FocusDocumentOnKeyDown(e){
	var ret = krUnhandled;
	var isDefaultButtonActionAllowed = true;
	if(focusedControl != null && focusedControl.enableKeyboardProcessing){
		savedFocusedControl = focusedControl;
		isDefaultButtonActionAllowed = focusedControl.IsDefaultButtonActionAllowed();
		ret = focusedControl.OnKeyDownCore(e);
	}
	if(isDefaultButtonActionAllowed && _isFunctionType(typeof(GetButtonCollection))){
		var buttonRet = GetButtonCollection().OnKeyDown(e);
		if(buttonRet == krHandled) return false;
	}
	if(ret == krHandled) 
		return false;
	if(_isExists(savedFocusDocumentOnKeyDown))
		return savedFocusDocumentOnKeyDown(e);
	return true;
}

function FocusDocumentOnKeyUp(e){
	var ret = krUnhandled;
	var isDefaultButtonActionAllowed = true;
	if(savedFocusedControl != null && savedFocusedControl.enableKeyboardProcessing){
		isDefaultButtonActionAllowed = savedFocusedControl.IsDefaultButtonActionAllowed();
		ret = savedFocusedControl.OnKeyUpCore(e);
		savedFocusedControl = null;
	}
	if(isDefaultButtonActionAllowed && _isFunctionType(typeof(GetButtonCollection))){
		var buttonRet = GetButtonCollection().OnKeyUp(e);
		if(buttonRet == krHandled) return false;
	}
	if(ret == krHandled) 
		return false;
	if(_isExists(savedFocusDocumentOnKeyUp))
		return savedFocusDocumentOnKeyUp(e);
	return true;
}

function FocusDocumentOnMouseDown(e){
	if(focusedControl != null && !focusedControl.IsMouseInControl(e))
		__setFocusedControl(null);
	if(_isExists(savedFocusDocumentOnMouseDown)) 
		return savedFocusDocumentOnMouseDown(e);
	return true;
}

function FocusFormOnReset(e){
	return false; 
}

function FocusWindowOnUnload(e){
	canChangeFocusedControl = false;
	if(_isExists(savedFocusWindowOnUnload))
		return savedFocusWindowOnUnload(e);
	return true;
}

var FocusFirstLoad;
if(typeof(savedFocusWindowOnLoad) == "undefined"){
	var savedFocusWindowOnLoad = window.onload;
	var savedFocusDocumentOnMouseWheel = null;
	var savedFocusDocumentOnKeyDown = null;
	var savedFocusDocumentOnKeyUp = null;
	var savedFocusDocumentOnMouseDown = null;
	var savedFocusFormOnReset = null;
	var savedFocusFormOnUnload = null;
	FocusFirstLoad = true;
}

window.onload = function(e){
	if(FocusFirstLoad){
		savedFocusDocumentOnMouseWheel = window.document.onmousewheel;
		window.document.onmousewheel = FocusDocumentOnMouseWheel;
		savedFocusDocumentOnKeyDown = window.document.onkeydown;
		window.document.onkeydown = FocusDocumentOnKeyDown;
		savedFocusDocumentOnKeyUp = window.document.onkeyup;
		window.document.onkeyup = FocusDocumentOnKeyUp;
		savedFocusDocumentOnMouseDown = window.document.onmousedown;
		window.document.onmousedown = FocusDocumentOnMouseDown;
		if(_getServerForm() != null){
			savedFocusFormOnReset = _getServerForm().onreset;
			_getServerForm().onreset = FocusFormOnReset;
		}
		savedFocusWindowOnUnload = window.onunload;
		window.onunload = FocusWindowOnUnload;
		FocusFirstLoad = false;
	}
	__updateFocusedControl();

	if(_isExists(savedFocusWindowOnLoad)) 
		return savedFocusWindowOnLoad(e);
	return true;
}