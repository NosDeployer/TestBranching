
function ASPxClientCheckBox(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientEditorBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.valueChecked = true;
	this.valueUnchecked = false;
	this.checkedIfUndefined = false;
	this.savedChecked = false;
	
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
			if(editMode)
				this.savedChecked = inputElement.checked;
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
			if(value){
			    if(opera || safari)
					inputElement.onclick = new Function("OnECancelChanges('" + this.name + "')");
				else
					inputElement.onclick = new Function("return false");
			}
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
	this.OnCancelChanges = function(element){
		if(!this.editable || this.activeElement == null){
			if(_checkTagName(element, "INPUT"))
				element.checked = this.savedChecked;
		}
	}
	this.OnMouseDown = function(element){
		if(element != null && this.activeElement != element){
			if(_checkTagName(element, "INPUT"))
				this.savedChecked = element.checked;
		}
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