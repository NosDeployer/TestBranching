
function ASPxClientSpinEdit(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientEditorBase;
	this.inherit(name, dataControllerName, fieldIndex);	

	this.number = 0;
	this.inc = 1;
	this.largeInc = 10;
	this.minValue = 0;
	this.maxValue = 0;
	this.isFloatValue = true;
	this.allowNull = true;
	this.numberOnError = "Undo";
	this.textModeInput = true;
	
	this.GetInputElement = function(){
		return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "Input") : null;
	}
	this.GetIncButtonElement = function(){
		return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "IncBtn") : null;
	}
	this.GetDecButtonElement = function(){
		return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "DecBtn") : null;
	}
	this.GetFastIncButtonElement = function(){
		return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "LIncBtn") : null;
	}
	this.GetFastDecButtonElement = function(){
		return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "LDecBtn") : null;
	}

	this.DoIncButtonClick = function(){
		this.DoButtonClick(this.inc);
	}
	this.DoDecButtonClick = function(){
		this.DoButtonClick(-this.inc);
	}
	this.DoFastIncButtonClick = function(){
		this.DoButtonClick(this.largeInc);
	}
	this.DoFastDecButtonClick = function(){
		this.DoButtonClick(-this.largeInc);
	}
	this.DoButtonClick = function(offset){
		if(this.editable){
			this.InitPostBack(null, "CLICK#" + offset);
			var processingMode = this.OnButtonClick(offset);
			if(processingMode == "Server")
				this.SendPostBack(false);
			else
				this.ChangeNumber(offset);
		}
	}
	this.ChangeNumber = function(offset){
		if(this.editable && this.enabled){
			this.Changing();
			var newNumber = this.GetValidNumber(ParseValue((this.number + offset).toPrecision(10), this.editFormatString, "Decimal"));
			if(newNumber != this.number){
				this.number = newNumber;
				this.SetInputElementValue();
			}
			this.baseOnChange();
		}
		this.FocusInputElement();
	}
	this.GetValidNumber = function(number){
		var validNumber = 0;
		if(this.UseRestrictions() && number < this.minValue && number > this.number)
			validNumber = this.minValue;
		else if(this.UseRestrictions() && number > this.maxValue && number < this.number)
			validNumber = this.maxValue;
		else if((!this.UseRestrictions() || number <= this.maxValue) && 
			(!this.UseRestrictions() || number >= this.minValue))
			validNumber = number;
		else
			validNumber = this.number;
		if(!this.isFloatValue)
			validNumber = Math.round(validNumber);
		return validNumber;
	}
	this.SetNumberInternal = function(value){
		this.number = value;
		this.SetInputElementValue();
	}
	this.UseRestrictions = function(){
		return (this.maxValue != 0 || this.minValue != 0);
	}
		
	this.GetValueType = function(){
		return this.isFloatValue ? "Decimal" : "Int"; 
	}
	this.ParseValue = function(value){
		if(value == null || value.toString() == "")
			return null;
		if(typeof(value) == "number")
			return value;
		return ParseValue(value.toString(), this.editFormatString, this.GetValueType());
	}
	this.GetInputElementValue = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) {
			var valueString = inputElement.value;
			var args = this.OnParseNumber(valueString);
			var newNumber = (args.handled) ? args.number : ((valueString != "") ? this.ParseValue(valueString) : null);
			if(newNumber != null){
				if(!isNaN(newNumber)){
					if(newNumber != this.number){
						if(this.UseRestrictions() && newNumber > this.maxValue)
							newNumber = this.maxValue;
						if(this.UseRestrictions() && newNumber < this.minValue)
							newNumber = this.minValue;
						this.SetNumberInternal(newNumber);
					}
				}
				else {
					var message = "The entered value '" + valueString + "' cannot be converted to " + this.GetValueType() + " type.";
					this.ProcessInvalidNumber(message);
				}
			}
			else if(this.number != null){
				if(this.allowNull){
					this.SetNumberInternal(null);
				}
				else
					this.ProcessInvalidNumber("The entered value cannot be Null.");
			}
		}	
	}
	this.SetInputElementValue = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) {
			inputElement.value = (this.number != null) ? FormatEditValue(this.number, "", "") : "";	
		}	
	}
	this.ProcessInvalidNumber = function(message){
		alert(message);
		switch(this.numberOnError){
			case "Zero":
				this.SetNumberInternal(0);
				break;
			case "Null":
				if(this.allowNull)
					this.SetNumberInternal(null);
				else
					this.SetInputElementValue();
				break;
			case "Undo":
				this.SetInputElementValue();
				break;
		}
		this.needFocus = true;
	}

	this.SetEditorInputName = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.name = this.name;
	}
	this.FocusControl = function(){
		this.FocusInputElement();
	}
	this.FormatViewValue = function(value){
		var number = this.ParseValue(value);
		if(!isNaN(number))
			return FormatValue(number, this.dataFormatString, "");
		return FormatValue(value, this.dataFormatString, this.GetDataType());
	}
	this.EnableCustomEditValue = function(){
		return false;
	}
	this.BindEditValue = function(value, renderValueDirectly){
		if(value == null)
			this.SetNumberInternal(null);
		else{
			var number = this.ParseValue(value);
			if(isNaN(number)) number = null;
			this.SetNumberInternal(number);
		}
	}
	this.GetEditorValue = function(){
		this.GetInputElementValue();
		return this.number;
	}
	this.baseSetEditorReadOnly = this.SetEditorReadOnly;
	this.SetEditorReadOnly = function(value){
		this.baseSetEditorReadOnly(value);
		if(this.textModeInput){
			var inputElement = this.GetInputElement();
			if(inputElement != null) inputElement.readOnly = value;
		}
	}
	this.baseSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.baseSetEnabled(enabled);
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.disabled  = !enabled;
		var incButtonElement = this.GetIncButtonElement();
		if(incButtonElement != null) incButtonElement.disabled  = !enabled;
		var decButtonElement = this.GetDecButtonElement();
		if(decButtonElement != null) decButtonElement.disabled  = !enabled;
		var fastIncButtonElement = this.GetFastIncButtonElement();
		if(fastIncButtonElement != null) fastIncButtonElement.disabled  = !enabled;
		var fastDecButtonElement = this.GetFastDecButtonElement();
		if(fastDecButtonElement != null) fastDecButtonElement.disabled  = !enabled;
	}

	this.NeedCorrectEditorSize = function(){
		return true;
	}
	
	this.baseInitializeControl = this.InitializeControl;
	this.InitializeControl = function(){
		this.baseInitializeControl();
		this.GetInputElementValue();
	}
	this.baseOnChange = this.OnChange;
	this.OnChange = function(){
		this.GetInputElementValue();
		this.baseOnChange();
	}
	this.RaiseValueChangedEvent = function(){
		return this.OnNumberChanged();
	}

	this.IsTextEditor = function(){
		return true;
	}
	this.OnMouseWheelCore = function(e){
		var evt = _getEvent(e);
		if(evt.wheelDelta > 0)
			this.ChangeNumber(this.inc);
		else if(evt.wheelDelta < 0)
			this.ChangeNumber(-this.inc);
		return true;
	}
	this.baseOnEditorKeyDown = this.OnEditorKeyDown;
	this.OnEditorKeyDown = function(e){
		var evt = _getEvent(e);
		switch(evt.keyCode){
			case kbUp:
				this.ChangeNumber(this.inc);
				return krHandled;
			case kbDown:
				this.ChangeNumber(-this.inc);
				return krHandled;
			case kbPgUp:
				this.ChangeNumber(this.largeInc);
				return krHandled;
			case kbPgDown:
				this.ChangeNumber(-this.largeInc);
				return krHandled;
			case kbEsc:
				this.SetInputElementValue();
				return krUnhandled;
		}		
		return this.baseOnEditorKeyDown(e);
	}
	this.GetNumber = function(){
		return this.GetEditValue();
	}
	this.SetNumber = function(number){
		this.SetEditValue(number);
	}		
	this.ButtonClick = new ASPxClientEvent();
	this.NumberChanged = new ASPxClientEvent();
	this.ParseNumber = new ASPxClientEvent();
	
	this.OnButtonClick = function(offset){
		if(!this.ButtonClick.IsEmpty()){
			var args = new ASPxClientSpinEditButtonEventArgs(offset, this.autoPostBack);
			this.ButtonClick.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return this.autoPostBack ? "Server" : "Client";
	}
	this.OnNumberChanged = function(){
		if(!this.NumberChanged.IsEmpty()){
			var args = new ASPxClientProcessingModeEventArgs(this.autoPostBack);
			this.NumberChanged.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return this.autoPostBack ? "Server" : "Client";
	}
	this.OnParseNumber = function(numberString){
		var args = new ASPxClientParseNumberEventArgs(numberString);
		if(!this.ParseNumber.IsEmpty())
			this.ParseNumber.FireEvent(this, args);
		return args;
	}
}
function ASPxClientParseNumberEventArgs(numberString){
	this.inherit = ASPxClientHandledEventArgs;
	this.inherit();
	this.numberString = numberString;
	this.number = null;
}
function ASPxClientSpinEditButtonEventArgs(offset, processOnServer){
	this.inherit = ASPxClientProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.offset = offset;
}

function OnSEIncButtonClick(name){
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.DoIncButtonClick();
}

function OnSEDecButtonClick(name){
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.DoDecButtonClick();
}

function OnSEFIncButtonClick(name){
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.DoFastIncButtonClick();
}

function OnSEFDecButtonClick(name){
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.DoFastDecButtonClick();
}