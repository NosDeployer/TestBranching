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
function ASPxClientButtonEdit(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientTextBoxBase;
	this.inherit(name, dataControllerName, fieldIndex);	

	this.GetInputElement = function(){
		return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "Input") : null;
	}
	this.GetButtonElement = function(index){
		return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "Button" + index) : null;
	}

	this.SetEditorInputName = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.name = this.name;
	}
	this.FocusControl = function(){
		this.FocusInputElement();
	}
	this.BindEditValue = function(value, renderValueDirectly){
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.value = renderValueDirectly ? value.toString() : this.FormatEditValue(value);
	}
	this.GetEditorValue = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) 
			return ParseValue(inputElement.value, this.editFormatString, this.GetDataType());
		return null;
	}
	this.NeedCorrectEditorSize = function(){
		return true;
	}
	this.SetEditorReadOnly = function(value){
		this.baseSetEditorReadOnly(value);
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.readOnly = value;
	}
	this.baseSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.baseSetEnabled(enabled);
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.disabled  = !enabled;
		for(var i = 0;;i++){
			buttonElement = this.GetButtonElement(i);
			if(buttonElement != null)
				buttonElement.disabled = !enabled;
			else
				break;
		}
	}
	this.OnButtonClickCore = function(index){
		this.InitPostBack(null, "CLICK#" + index);
		var processingMode = this.OnButtonClick(index);
		if(processingMode == "Server")
			this.SendPostBack(false);
	}
	this.ButtonClick = new ASPxClientEvent();
	
	this.OnButtonClick = function(index){
		if(!this.ButtonClick.IsEmpty()){
			var args = new ASPxClientButtonEditClickEventArgs(index, this.autoPostBack);
			this.ButtonClick.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return this.autoPostBack ? "Server" : "Client";
	}
}
function ASPxClientButtonEditClickEventArgs(buttonIndex, processOnServer){
	this.inherit = ASPxClientProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.buttonIndex = buttonIndex;
}

function OnBEButtonClick(name, index){
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.OnButtonClickCore(index);
}