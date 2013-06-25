
function ASPxClientTextEditBase(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientEditorBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.isPassword = false;
	
	this.GetInputElement = function(){
		if(this.activeElement == null) 
			return null;
		else if(this.IsNative())
			return this.activeElement;
		else
			return _getChildById(this.activeElement, this.name + "Input");
	}
	this.IsNative = function() {
		return _checkTagName(this.activeElement, "INPUT");
	}

	this.SetEditorInputName = function(){
		if(this.CanEditValue()){
			var inputElement = this.GetInputElement();
			if(inputElement != null) inputElement.name = this.name;
		}
	}
	this.FocusControl = function(){
		if(this.CanEditValue())
			this.FocusInputElement();
	}
	this.GetDisplayTextByValue = function(value){
		var text = this.FormatViewValue(value);
		if(this.isPassword)
			return _getPasswordText(text);
		return text;
	}
	this.BindEditValue = function(value, renderValueDirectly){
		var inputElement = this.GetInputElement();
		if(inputElement != null) 
			inputElement.value = renderValueDirectly ? value.toString() : this.FormatEditValue(value);
	}
	this.GetEditorValue = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) 
			return ParseValue(inputElement.value, this.editFormatString, this.GetDataType());
		return null;
	}
	this.baseSetEditorReadOnly = this.SetEditorReadOnly;
	this.SetEditorReadOnly = function(value){
		this.baseSetEditorReadOnly(value);
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.readOnly = value;
	}
	this.CanEditValue = function(){
		return true;
	}
	
	this.NeedCorrectEditorSize = function(){
		return !this.IsNative();
	}
	this.IsTextEditor = function(){
		return true;
	}
	this.RaiseValueChangedEvent = function(){
		return this.OnTextChanged();
	}

	this.baseSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.baseSetEnabled(enabled);
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.disabled  = !enabled;
	}
	this.GetText = function(){
		var value = this.GetEditValue();
		return (value != null) ? value.toString() : "";
	}
	this.SetText = function(text){
		this.SetEditValue(text);
	}
	this.OnTextChanged = function(){
	}
}
function ASPxClientLabel(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientTextEditBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.CanEditValue = function(){
		return false;
	}
	this.GetEditorValue = function(){
		if(this.activeElement != null)
			return _getElementInnerText(this.activeElement);
		return "";
	}
}
function ASPxClientHyperLink(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientTextEditBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.navigateURLFieldIndex = -1;
	this.navigateURLFormatString = "";
	this.fixedNavigateURL = false;
	this.fixedText = false;
	
	this.tebaseDataCtrlrValueChanged = this.DataCtrlrValueChanged;
	this.DataCtrlrValueChanged = function(fieldIndex, value){
		if(this.valueChanging) return;
		this.tebaseDataCtrlrValueChanged(fieldIndex, value);
		if(this.activeElement != null){
			if(this.navigateURLFieldIndex == fieldIndex)
				this.BindNavigateUrl(this.activeElement, value);
		}
	}
	this.tebaseBindEditor = this.BindEditor;
	this.BindEditor = function(element, row, value, editMode, renderValueDirectly){
		this.tebaseBindEditor(element, row, value, editMode, renderValueDirectly);
		if(!editMode || !this.CanEditValue()){
			var navigateURLValue = null;
			if(this.navigateURLFieldIndex > -1)
				navigateURLValue = (row != null) ? row.GetValue(this.navigateURLFieldIndex) : "";
			else if(this.fieldIndex > -1)
				navigateURLValue = (row != null) ? row.GetValue(this.fieldIndex) : "";
			if(navigateURLValue != null)
				this.BindNavigateUrl(element, navigateURLValue);
		}
	}
	this.BindNavigateUrl = function(element, value){
		if(this.fixedNavigateURL) return;
		var linkElement = this.GetLinkElement(element);
		if(linkElement != null)
			linkElement.href = this.FormatNavigateURL(value);	
	}
	this.BindViewValue = function(element, value, renderValueDirectly){
		if(this.fixedText) return;
		var linkElement = this.GetLinkElement(element);
		if(linkElement != null){
			var imgElement = _getChildByTagName(linkElement, "IMG", 0);
			var text = renderValueDirectly ? value.toString() : this.GetDisplayTextByValue(value);
			if(imgElement == null)
				this.BindElementInnerText(linkElement, text);
			else
				imgElement.alt = text;
		}
	}
	this.tebaseGetEditorValue = this.GetEditorValue;
	this.GetEditorValue = function(){
		if(this.activeElement != null){
			if(this.standAlone){
				var element = this.GetLinkElement(element);
				if(element != null)
					return _getElementInnerText(element);
			}
			else 
				return this.tebaseGetEditorValue();
		}
		return "";
	}
	this.GetViewerValue = function(element){
		var linkElement = this.GetLinkElement(element);
		return (linkElement != null) ? _getElementInnerText(linkElement) : "";
	}
	this.SetEnabled = function(enabled){
		this.baseSetEnabled(enabled);
		if(this.activeElement != null){
			var element = this.GetLinkElement(this.activeElement);
			if(element != null) element.disabled  = !enabled;
		}
	}
	this.FormatNavigateURL = function(value){
		return FormatValue(value, this.navigateURLFormatString, "string");
	}
	this.CanEditValue = function(){
		return !this.standAlone;
	}
	this.GetLinkElement = function(element){
		var element = _getFirstChild(element);
		if(_checkTagName(element, "A"))
			return element;
		return null;
	}
	this.AllowContentsCaching = function(){
		return false;
	}
}
function ASPxClientTextBoxBase(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientTextEditBase;
	this.inherit(name, dataControllerName, fieldIndex);
	this.TextChanged = new ASPxClientEvent();

	this.OnTextChanged = function(){
		if(!this.TextChanged.IsEmpty()){
			var args = new ASPxClientProcessingModeEventArgs(this.autoPostBack);
			this.TextChanged.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return this.autoPostBack ? "Server" : "Client";
	}
}
function ASPxClientTextBox(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientTextBoxBase;
	this.inherit(name, dataControllerName, fieldIndex);	
}
function ASPxClientMemo(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientTextBoxBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.GetLFScrollBar = function(){
		var scrollBarElement = this.GetLFScrollBarElement();
		if(scrollBarElement != null)
			return GetLookAndFeelScrollBarCollection().Get(scrollBarElement.id);
		return null;
	}
	this.GetLFScrollBarElement = function(){
		return (this.activeElement != null) ? _getChildByCssClass(this.activeElement, "LFScrollBar") : null;
	}
	this.IsNative = function() {
		return _checkTagName(this.activeElement, "TEXTAREA");
	}
	this.UpdateScrollBar = function(){
		var LFScrollBar = this.GetLFScrollBar();
		if(LFScrollBar != null) LFScrollBar.Update(true);
	}
	
	this.SetActiveElement = function(element){
		this.activeElement = element;
		
		var LFScrollBar = this.GetLFScrollBar();
		if(LFScrollBar != null) 
			LFScrollBar.SetRootElement(this.GetLFScrollBarElement());
	}
	this.tbbaseEditorBindEditValue = this.BindEditValue;
	this.BindEditValue = function(value, renderValueDirectly){
		this.tbbaseEditorBindEditValue(value, renderValueDirectly);
		this.UpdateScrollBar();
	}
	this.tbbaseChanging = this.Changing;	
	this.Changing = function(){
		this.tbbaseChanging();
		this.UpdateScrollBar();
	}
	this.tbbaseSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.tbbaseSetEnabled(enabled);
		if(!this.IsNative()){
			var LFScrollBar = this.GetLFScrollBar();
			if(LFScrollBar != null) LFScrollBar.SetEnabled(enabled);
		}
	}
	this.tbbaseSetEditorSize = this.SetEditorSize;
	this.SetEditorSize = function(element, editMode, width, height){
		this.tbbaseSetEditorSize(element, editMode, width, height);
		if(editMode && !this.IsNative())
			InitializeLFScrollBoxSize(element, width, height);
	}
	
	this.OnMouseWheelCore = function(e){
		if(!this.IsNative()){
			var LFScrollBar = this.GetLFScrollBar();
			if(LFScrollBar != null){
				LFScrollBar.DoMouseWheel(e);
				return true;
			}
		}
		return false;
	}
	this.tbbaseOnEditorKeyDown = this.OnEditorKeyDown;
	this.OnEditorKeyDown = function(e){
		var ret = this.tbbaseOnEditorKeyDown(e);
		if(ret != krUnhandled) return ret;
		
		if(!this.IsNative()){
			var LFScrollBar = this.GetLFScrollBar();
			if(LFScrollBar != null){
				ret = LFScrollBar.DoKeyDown(e);
				if(ret != krUnhandled) return ret;
			}
		}

		var evt = _getEvent(e);
		var keyCode = evt.keyCode;
		switch(e.keyCode){
			case kbEnter:
			case kbLeft:
			case kbRight: 
			case kbUp:
			case kbDown: 
				return krSystem;
		}		
		return krUnhandled;
	}
	this.IsTextChangingKey = function(key){	
		return _isTextChangingKey(key) || (key == kbEnter);
	}
	this.IsMultiLineTextEditor = function(){
		return true;
	}
	this.NeedCorrectEditorSize = function(){
		return false;
	}
	this.GetScrollPosition = function(){
		var inputElement = this.GetInputElement();
		return (inputElement != null) ? inputElement.scrollTop : 0;
	}
	this.SetScrollPosition = function(position){
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.scrollTop  = position;
	}
}