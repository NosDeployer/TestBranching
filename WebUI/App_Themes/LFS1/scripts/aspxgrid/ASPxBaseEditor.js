
function ASPxClientEditorBase(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	

	this.dataControllerName = dataControllerName;
	this.fieldIndex = fieldIndex;
	this.dataController = null;
	this.editable = true;
	this.enabled = true;
	this.enableKeyboardProcessing = true;
	this.readOnly = false;
	this.standAlone = true;
	this.viewerTooltipsEnabled = false;
	this.uniqueName = "";
	
	this.dataFormatString = "";
	this.editFormatString = "";

	this.patterns = new Array();
	this.viewerLeftPadding = 4;
	this.viewerRightPadding = 4;
	this.viewerTopPadding = 0;
	this.viewerBottomPadding = 0;
	
	this.autoPostBack = false;	
	this.focused = false;
	this.activeElement = null;
	this.isValueValid = true;
	this.isValueChanged = true;
	this.lockValueChange = false;
	this.needFocus = false;
	
	this.GetInputElement = function(){
		return null;
	}
	
	this.GetDataController = function(){
		if(_isFunctionType(typeof(GetDataControllerCollection)))
			return GetDataControllerCollection().Get(this.dataControllerName);
		return null;
	}
	this.GetRowValue = function(row){
		return row != null ? row.GetValue(this.fieldIndex) : null;
	}
	this.DataCtrlrFocusedChanged = function(row){
		if(this.standAlone && this.activeElement != null){
			this.BindEditor(this.activeElement, row, this.GetRowValue(row), true, false);
		}
	}
	this.DataCtrlrAfterDelete = function(dataRow){
		if(this.standAlone && this.activeElement != null){
			var focusedRow = this.dataController.GetFocusedRow();
			if(focusedRow == null)
				this.BindEditor(this.activeElement, focusedRow, this.GetRowValue(focusedRow), true, false);
		}
	}
	this.DataCtrlrValueChanged = function(fieldIndex, value){
		if(this.lockValueChange) return;
		if(this.activeElement != null){
			if(this.fieldIndex == fieldIndex)
				this.BindValue(this.activeElement, value, true, false);
		}
	}
	this.DataCtrlrValueChange = function(value){
		if(this.dataController != null){
			this.lockValueChange = true;	
			this.dataController.ValueChanged(this.fieldIndex, this.ConvertEditValue(value));
			this.lockValueChange = false;
		}
	}
	this.DataCtrlrDataModeChanged = function(oldDataMode){
		if(this.lockValueChange) return;
		if(this.standAlone && this.activeElement != null){
			var focusedRow = this.dataController.GetFocusedRow();
			this.BindEditor(this.activeElement, focusedRow, this.GetRowValue(focusedRow), true, false);
			if((!this.dataController.autoEdit || !this.dataController.allowEdit) && !this.readOnly)
				this.SetEditorReadOnly(!this.dataController.IsEditMode());
		}
	}
	this.GetDataPageSize = function(){
		return 1;
	}
	
	this.GetEditorPatternId = function(editMode, altMode){
		if(editMode)
			return this.name + "EditorPattern";
		else if(altMode)
			return this.name + "ViewerPatternA";
		else
			return this.name + "ViewerPattern";
	}
	this.GetEditorPattern = function(editMode, altMode){
		var patternId = this.GetEditorPatternId(editMode, altMode);
		if(!_isExists(this.patterns[patternId]))
			this.patterns[patternId] = _getElementById(patternId);	
		return this.patterns[patternId];
	}
	this.SetEditorInputName = function(){
	}
	this.ShowEditor = function(parentNode, editMode, altMode, width, height){
		this.CheckInitialized();
		var pattern = this.GetEditorPattern(editMode && this.CanEditValue(), altMode);	
		if(pattern != null){
			var childNode = _getFirstChild(pattern).cloneNode(true);
			parentNode.appendChild(childNode);
			if(editMode){
				this.SetActiveElement(childNode);
				this.SetEditorInputName();
			}
			this.SetEditorSize(childNode, editMode, width, height);
		}
	}
	this.AllowContentsCaching = function(){
		return true;
	}
	this.NeedCorrectEditorSize = function(){
		return false;
	}
	this.IsHtmlTagsInValuesEnabled = function(){
		return (this.dataController != null) ? this.dataController.htmlTagsInValuesEnabled : false;
	}

	this.CorrectEditorSize = function(){
		if(this.NeedCorrectEditorSize() && this.activeElement != null && _isFunctionType(typeof(CorrectLFEditorSize)))
			CorrectLFEditorSize(this.activeElement);
	}
	this.CanSetEditorWidth = function(element, editMode){
		return (editMode || element.style.width != "" || 
			(_isExists(element.currentStyle) && element.currentStyle.width != "" && element.currentStyle.width != "auto"));
	}
	this.CanSetEditorHeight = function(element, editMode){
		return (editMode || element.style.height != "" || 
			(_isExists(element.currentStyle) && element.currentStyle.height != "" && element.currentStyle.height != "auto"));
	}
	this.SetEditorSize = function(element, editMode, width, height){
		if(!ie && !editMode){
			if(width != null && width.type == "px")
				width = new ASPxClientUnit(width.value - this.viewerLeftPadding - this.viewerRightPadding, width.type);
			if(height != null && height.type == "px")
				height = new ASPxClientUnit(height.value - this.viewerTopPadding - this.viewerBottomPadding, height.type);
		}			
		if(width != null && this.CanSetEditorWidth(element, editMode)){
			if(width.value < 0) width.value = 0;
			element.style.width = width.ToString();
		}
		if(height != null && this.CanSetEditorHeight(element, editMode)){
			if(height.value < 0) height.value = 0;
			element.style.height = height.ToString();
		}
		this.ResetEditorTooltip(element, editMode);
		this.CorrectEditorSize();
	}
	this.ResetEditorTooltip = function(element, editMode){
		element.tooltipEnabled = false;
	}
	this.SetEditorTooltip = function(element, editMode){
		if(!editMode && this.viewerTooltipsEnabled && !element.tooltipEnabled){
			if(element.scrollWidth > element.offsetWidth)
				element.title = this.GetViewerValue(element);
			else
				element.title = "";
			element.tooltipEnabled = true;
		}
	}
	this.Focus = function(){
		if(this.enabled && this.activeElement != null)
			this.FocusControl();
	}
	this.FocusEditor = function(){
		if(this.activeElement != null)
			this.FocusControl();
	}
	this.FocusControl = function(){
		this.FocusElement(this.activeElement);
	}
	this.FocusElement = function(element){
		if(element != null){
			_focusElement(element);
			_selectElement(element);
		}
	}
	this.FocusInputElement = function(){
		if(this.enabled && this.activeElement != null)
			this.FocusElement(this.GetInputElement());
	}
	
	
	this.ConvertEditValue = function(editValue){
		if(this.GetDataType() == "String")
			return FormatValue(editValue, this.editFormatString, "");
		return editValue;
	}
	this.CanEditValue = function(){
		return true;
	}
	this.IsValueChanged = function(){
		return this.isValueChanged || (this.dataController != null && this.dataController.IsInsertMode());
	}
	this.ValidateEditValue = function(){
		if(this.IsValueChanged() && !this.isValueValid)
			this.OnValidate();
		if(this.needFocus)
			this.FocusEditor();
		return !this.IsValueChanged() || this.isValueValid;
	}
	this.StoreEditValue = function(){
		if(this.CanEditValue() && this.activeElement != null){
			var focusedRow = this.dataController.GetFocusedRow();
			var dataControllerColumn = this.dataController.columns[this.fieldIndex];
			if(focusedRow != null && dataControllerColumn != null && !dataControllerColumn.IsReadOnly())
				if(this.IsValueChanged() && this.isValueValid)
					focusedRow.SetValue(this.fieldIndex, this.ConvertEditValue(this.GetEditValue()));
		}
	}
	this.InterimStoreEditValue = function(){
		if(this.ValidateEditValue()){
			this.StoreEditValue();
			return true;
		}
		return false;
	}
	this.GetCompareValue = function(value) {
		return value;
	}
	this.GetDisplayTextByValue = function(value){
		return this.FormatViewValue(value);
	}
	this.EnableCustomViewValue = function(){
		return true;
	}
	this.EnableCustomEditValue = function(){
		return true;
	}
	this.FormatViewValue = function(value){
		return FormatValue(value, this.dataFormatString, this.GetDataType());
	}
	this.FormatEditValue = function(value){
		return FormatEditValue(value, this.editFormatString, this.GetDataType());
	}
	this.BindEditor = function(element, row, value, editMode, renderValueDirectly){
		this.CheckInitialized();
		if(element != null){
			this.BindValue(element, value, editMode, renderValueDirectly);
			this.ResetEditorTooltip(element, editMode);
		}
		this.isValueChanged = false;
	}
	this.BindValue = function(element, value, editMode, renderValueDirectly){
		if(!editMode || !this.CanEditValue())
			this.BindViewValue(element, value, renderValueDirectly);
		else if(this.activeElement != null)
			this.BindEditValue(value, renderValueDirectly);
	}
	this.BindViewValue = function(element, value, renderValueDirectly){
		this.BindElementInnerText(element, renderValueDirectly ? value.toString() : this.GetDisplayTextByValue(value));
	}
	this.BindElementInnerText = function(element, text){
		if(this.IsHtmlTagsInValuesEnabled())
			_setElementInnerHTML(element, text);
		else
			_setElementInnerText(element, text);
	}
	this.BindEditValue = function(value, renderValueDirectly){
	}
	this.GetDataType = function(){
		return (this.dataController != null && this.fieldIndex > -1) ? this.dataController.columns[this.fieldIndex].type : "";
	}
	this.GetViewerValue = function(element){
		return _getElementInnerText(element);
	}
	this.GetEditorValue = function(){
		return null;
	}
	this.DeactivateEditor = function(){
		this.SetActiveElement(null);
	}
	this.SetEditorReadOnly = function(value){
		this.editable = !value;
	}
	this.GetUniqueName = function(){
		return (this.uniqueName != "") ? this.uniqueName : this.name;
	}
	
	this.CheckActiveElement = function(element){
		if(this.standAlone && element != null){		
			var element = _getParentById(element, this.name);
			if(element != null && element != this.activeElement)
				this.SetActiveElement(element);
		}
	}
	
	this.ApplyCallBackHtml = function(html){
		var element = _getElementById(this.name);
		var CBContainer = _getParentByCssClass(element, "CBContainer");
		CBContainer.innerHTML = html;
	}
	this.GetActiveElement = function(){
		return this.activeElement;
	}
	this.SetActiveElement = function(element){
		this.activeElement = element;
	}
	this.GetEnabled = function(){
		return this.enabled;
	}
	this.SetEnabled = function(enabled){
		this.enabled = enabled;
		if(this.activeElement != null) this.activeElement.disabled  = !enabled;
	}
	this.GetEditValue = function(){
		this.CheckInitialized();
		if(this.activeElement != null)
			return this.CanEditValue() ? this.GetEditorValue() : this.GetViewerValue(this.activeElement);
		return null;
	}
	this.SetEditValue = function(value){
		this.CheckInitialized();
		if(this.activeElement != null)
			this.BindValue(this.activeElement, value, true, false);
	}

	this.InitializeControl = function (){
		this.SetActiveElement(_getElementById(this.name));
		this.dataController = this.GetDataController();
		if(this.dataController != null){
			this.dataController.AddDataControl(this);
			this.dataController.CheckInitialized();
			if(this.standAlone && this.activeElement != null){
				var row = this.dataController.GetFocusedRow();
				this.BindEditor(this.activeElement, row, this.GetRowValue(row), true, false);
			}
		}
		this.CorrectEditorSize();
		if(this.focused){
			this.FocusEditor();
			if(_isFunctionType(typeof(GetButtonCollection)))
				GetButtonCollection().ActivateDefaultButton();
		}
	}
	this.OnLostFocus = function(){	
		if(this.standAlone && __getFocusedControl() == this)
			__setFocusedControl(null);
		if(this.needFocus)
			this.FocusEditor();
		if(!this.LostFocus.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.LostFocus.FireEvent(this, args);
		}
	}
	this.OnGetFocus = function(element){
		this.CheckActiveElement(element);
		this.needFocus = false;
		if(this.standAlone)
			__setFocusedControl(this);
		if(!this.GotFocus.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.GotFocus.FireEvent(this, args);
		}
	}
	this.OnMouseOver = function(element){
		this.SetEditorTooltip(element, false);
	}		
	this.Changing = function(){
		if(!this.readOnly && this.dataController != null){
			this.lockValueChange = true;	
			if(this.dataController.GetDataMode() == "Browse" && this.dataController.autoEdit)
				this.dataController.Edit();
			this.lockValueChange = false;
			this.isValueValid = false;
			this.isValueChanged = true;
		}
	}
	this.OnChange = function(){
		this.Changing();
		this.InitPostBack(null, "");
		var processingMode = this.RaiseValueChangedEvent();
		if(processingMode == "Server")
			this.SendPostBack(false);
		else
			this.Changed();
	}
	this.RaiseValueChangedEvent = function(){
		return "Client";
	}
	this.OnCancelChanges = function(element){
	}
	this.Changed = function(){
		if(this.dataController != null && this.IsValueChanged()){
			this.OnValidate();
			if(this.isValueValid){
				var value = this.GetEditValue();
				this.DataCtrlrValueChange(value);
			}
		}
	}
	this.OnMouseDown = function(element){
		this.CheckActiveElement(element);
	}
	this.OnMouseUp = function(){
		this.FocusEditor();
	}
	
	this.IsTextEditor = function(){
		return false;
	}
	this.IsMultiLineTextEditor = function(){
		return false;
	}
	this.IsTextChangingKey = function(key){	
		return _isTextChangingKey(key);
	}
	this.OnMouseWheelCore = function(e){
		return false;
	}
	this.OnKeyDownCore = function(e){
		var evt = _getEvent(e);
		if(this.OnKeyDown(evt))
			return krHandled;
		return this.OnEditorKeyDown(evt);
	}
	this.OnEditorKeyDown = function(e){
		var evt = _getEvent(e);
		var keyCode = evt.keyCode;
		switch(keyCode){
			case kbEnd:
			case kbHome:
			case kbLeft:
			case kbRight: 
			case kbInsert:
			case kbDelete:
				return krSystem;
		}		
		return krUnhandled;
	}
	this.OnKeyUpCore = function(e){
		var evt = _getEvent(e);
		if(this.OnKeyUp(evt))
			return krHandled;
		return this.OnEditorKeyUp(evt);
	}
	this.OnEditorKeyUp = function(e){
		var evt = _getEvent(e);
		var keyCode = evt.keyCode;
		if(this.IsTextEditor()){
			if(this.IsTextChangingKey(keyCode))
				this.Changing();
			if(!this.IsMultiLineTextEditor() && keyCode == kbEnter){
				this.OnChange();
				this.FocusEditor();
			}
		}
		return krUnhandled;
	}
	this.IsMouseInControl = function(evt){
		return _getIsParent(this.activeElement, _getEventSource(evt));
	}
	this.IsDefaultButtonActionAllowed = function(){
		return !this.IsMultiLineTextEditor();
	}
	this.CanFocusedControl = function(){
		return this.standAlone;
	}
	
	this.InitPostBack = function(evt, eventArgument){
		__initASPxPostBack(evt, this.GetUniqueName(), eventArgument, this, false, false);
	}
	this.Init = new ASPxClientEvent();
	this.KeyDown = new ASPxClientEvent();
	this.KeyUp = new ASPxClientEvent();
	this.Validate = new ASPxClientEvent();
	this.GotFocus = new ASPxClientEvent();
	this.LostFocus = new ASPxClientEvent();
	
	this.OnInit = function(){
		if(!this.Init.IsEmpty()){
			var eventArgs = new ASPxClientEventArgs();
			this.Init.FireEvent(this, eventArgs);		
		}
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
	this.IsValidValueType = function(value){
		return (value == null || this.GetDataType() == "" || typeof(GetConvertedValue(value, this.GetDataType())) != "undefined");
	}	
	this.OnValidate = function(){
		if(this.isValueValid) return;
		var value = this.GetEditValue();
		var validatedValueChanged = false;
		if(!this.Validate.IsEmpty()){
			var args = new ASPxClientValidateEventArgs(value);
			this.Validate.FireEvent(this, args);
			if(args.cancel){
				alert(args.message);
				this.needFocus = true;
			}
			else {
				if(value != args.value){
					validatedValueChanged = true;
					value = args.value;
				}
				this.isValueValid = true;
			}
		}
		else
			this.isValueValid = true;
		if(this.isValueValid && !this.IsValidValueType(value)){
			this.isValueValid = false;
			alert("The entered value cannot be converted to the required data type: " + this.GetDataType() + ".");
			this.needFocus = true;
		}
		if(this.isValueValid && validatedValueChanged)
			this.BindEditValue(value, false);
	}
	
	GetEditorCollection().Add(this);
}
ASPxClientEditorBase.GetEditorCollection = function(){
	return GetEditorCollection();
}

function OnEMouseDown(element, name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.OnMouseDown(element);
}

function OnEMouseUp(name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.OnMouseUp();
}

function OnEChange(name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.OnChange();	
}

function OnECancelChanges(element, name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.OnCancelChanges(element);
}

function OnEMouseOver(name, element){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.OnMouseOver(element);	
}

function OnEGetFocus(element, name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.OnGetFocus(element);	
}

var inELostFocus = false;
function OnELostFocus(name){
	if(inELostFocus) return;

	inELostFocus = true;
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.OnLostFocus();	
	inELostFocus = false;
}
	
function GetEditorCollection(){
	if(__ASPxEditorCollection == null){
		__ASPxEditorCollection = new ASPxClientWebCollection();
	}
	return __ASPxEditorCollection;
}

var EditorFirstLoad;
if(typeof(savedEditorWindowOnLoad) == "undefined"){
	var __ASPxEditorCollection = null;
	var savedEditorWindowOnLoad = window.onload;
	EditorFirstLoad = true;
}
	
window.onload = function(e){
	if(EditorFirstLoad){
		GetEditorCollection().Initialize(true);
		EditorFirstLoad = false;
	}
	else
		window.setTimeout("GetEditorCollection().Initialize(false)", 0);
	
	if(_isExists(savedEditorWindowOnLoad)) 
		return savedEditorWindowOnLoad();
	return true;
}