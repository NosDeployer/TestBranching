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
function ASPxClientCheckBox(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientEditorBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.valueChecked = true;
	this.valueUnchecked = false;
	this.checkedIfUndefined = false;
	
	this.GetInputElement = function(){
		return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "Input") : null;
	}
	this.SetEditorInputName = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.name = this.name;
	}
	this.FocusControl = function(){
		this.FocusInputElement();
	}
	this.BindValue = function(element, value, editMode, renderValueDirectly){
		var inputElement = editMode ? this.GetInputElement() : _getChildById(element, this.name + "Input");
		if(inputElement != null){
			if(value == this.valueChecked)
				inputElement.checked = true;
			else if (value == this.valueUnchecked)
				inputElement.checked = false;
			else
				inputElement.checked = this.checkedIfUndefined;
		}
	}
	this.GetDisplayTextByValue = function(value){
		return value.toString();
	}
	this.GetEditorValue = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null)	
			return inputElement.checked ? this.valueChecked : this.valueUnchecked;
		return null;
	}
	this.GetViewerValue = function(element){
		var inputElement = _getChildById(element, this.name + "Input");
		if(inputElement != null)	
			return inputElement.checked ? this.valueChecked : this.valueUnchecked;
		return "";
	}
	this.baseSetEditorReadOnly = this.SetEditorReadOnly;
	this.SetEditorReadOnly = function(value){
		this.baseSetEditorReadOnly(value);
		var inputElement = this.GetInputElement();
		if(inputElement != null){ 
			if(value)
				inputElement.onclick = new Function("return false");
			else
				inputElement.onclick = new Function("OnEChange('" + this.name + "')");
		}
	}
	this.baseSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.baseSetEnabled(enabled);
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.disabled  = !enabled;
	}
	
	this.RaiseValueChangedEvent = function(){
		return this.OnCheckedChanged();
	}
	this.OnCheckedChanged = function(){
		if(!this.CheckedChanged.IsEmpty()){
			var args = new ASPxClientProcessingModeEventArgs(this.autoPostBack);
			this.CheckedChanged.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return this.autoPostBack ? "Server" : "Client";
	}
	this.GetChecked = function(){
		return this.GetEditValue() == this.valueChecked;
	}
	this.SetChecked = function(isChecked){
		this.SetEditValue(isChecked ? this.valueChecked : this.valueUnchecked);
	}		
	this.CheckedChanged = new ASPxClientEvent();
}