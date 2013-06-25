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
function ASPxClientListEditBase(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientEditorBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.values = new Array();
	this.displayTexts = new Array();
	this.imageUrls = new Array();
	this.showNotExistingValueItem = true;
	this.actualValue = null;
	this.defaultImageUrl = _getDefaultImagePath() + "1x1.gif";
	this.savedSelectedIndex = -1;

	this.AddItem = function(value, displayText, imageUrl){
		this.values.push(value);
		this.displayTexts.push(displayText);
		this.imageUrls.push(imageUrl);
	}
	this.AddItems = function(items){
		for(var i = 0; i < items.length; i ++){
			var value = _isExists(items[i][0]) ? items[i][0] : null;
			var displayText = _isExists(items[i][1]) ? items[i][1] : null;
			var imageUrl = _isExists(items[i][2]) ? items[i][2] : null;
			this.AddItem(value, displayText, imageUrl);
		}
	}
	
	this.GetDisplayTextByValue = function(value){
		var valueIndex = this.IndexOfValue(value);
		return (valueIndex >= 0) ? this.GetDisplayText(valueIndex) : this.FormatViewValue(value);
	}
	this.GetDisplayImageUrlByValue = function(value){
		var valueIndex = this.IndexOfValue(value);
		var imageUrl = (valueIndex >= 0) ? this.GetImageUrl(valueIndex) : "";
		return (imageUrl != "") ? imageUrl : this.defaultImageUrl;
	}
	this.BindViewValue = function(element, value, renderValueDirectly){
		var text = renderValueDirectly ? value.toString() : this.GetDisplayTextByValue(value);
		var textElement = _getChildByTagName(element, "SPAN", 0);
		if(textElement != null) _setElementInnerText(textElement, text);
		var imageUrl = this.GetDisplayImageUrlByValue(value);
		var imageElement = _getChildByTagName(element, "IMG", 0);
		if(imageElement != null) imageElement.src = imageUrl;
	}
	this.BindEditValue = function(value, renderValueDirectly){
		this.savedSelectedIndex = this.IndexOfValue(value);
		this.SetSelectedValue(value);
	}	
	this.GetEditorValue = function(){
		return this.GetSelectedValue();
	}
	this.GetViewerValue = function(element){
		var textElement = _getChildByTagName(element, "SPAN", 0);
		return (textElement != null) ? _getElementInnerText(textElement) : "";
	}
	this.GetSelectedValue = function(){
		return null;
	}
	this.SetSelectedValue = function(value){
	}
	this.GetSelectedValueIndex = function(){
		return -1;
	}
	this.SetSelectedValueIndex = function(valueIndex){
	}
	this.GetCompareValue = function(value) {
		return this.GetDisplayTextByValue(value);
	}
	this.RaiseValueChangedEvent = function(){
		return this.OnSelectedIndexChanged();
	}
	this.OnSelectedIndexChanged = function(){
		if(!this.SelectedIndexChanged.IsEmpty()){
			var args = new ASPxClientProcessingModeEventArgs(this.autoPostBack);
			this.SelectedIndexChanged.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return this.autoPostBack ? "Server" : "Client";
	}
	this.GetItemCount = function(){
		return this.values.length;
	}
	this.GetValue = function(index){
		return this.values[index];
	}
	this.GetDisplayText = function(index){
		var displayText = this.displayTexts[index];
		return (_isExists(displayText)) ? displayText : this.GetValue(index);
	}
	this.GetImageUrl = function(index){
		var imageUrl = this.imageUrls[index];
		return (_isExists(imageUrl)) ? imageUrl : "";
	}
	this.IndexOfValue = function(value){
		return array_indexOf(this.values, value)
	}
	this.GetSelectedIndex = function(){
		return this.IndexOfValue(this.GetEditValue());
	}
	this.SetSelectedIndex = function(index){
		if(0 <= index && index < this.GetItemCount())
			this.SetEditValue(this.GetValue(index));
		else
			this.SetEditValue(null);
	}
	this.SelectedIndexChanged = new ASPxClientEvent();
}
function ASPxClientListBox(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientListEditBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.dropDown = false;
	this.caseSensitiveSearch = false;
	this.typedText = "";
	
	this.insertedItems = new Array();
	this.deletedItems = new Array();
	
	this.GetInputElement = function(){
		if(!this.IsNative())
			return (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "Input") : null;
		else
			return this.activeElement;
	}
	this.GetTextInputElement = function(){
		return null;
	}
	this.GetLFListBox = function(){
		var listBoxElement = this.GetLFListBoxElement();
		return (listBoxElement != null) ? GeLookAndFeeltListBoxCollection().Get(listBoxElement.id) : null;
	}
	this.GetLFListBoxElement = function(){
		return (this.activeElement != null) ? _getChildByCssClass(this.activeElement, "LFScrollBox") : null;
	}
	this.IsNative = function() {
		return (this.activeElement != null && this.activeElement.tagName == "SELECT");
	}
	
	this.SetActiveElement = function(element){
		this.activeElement = element;
		
		var LFListBox = this.GetLFListBox();
		if(LFListBox != null) 
			LFListBox.SetRootElement(this.GetLFListBoxElement());
	}
	this.SetEditorInputName = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.name = this.name;
	}
	this.FocusControl = function(){
		if(!this.IsNative()){
			var LFListBox = this.GetLFListBox();
			if(LFListBox != null) LFListBox.Focus();
		}
		else 
			this.FocusElement(this.activeElement);
	}
	this.baseSetEditorSize = this.SetEditorSize;
	this.SetEditorSize = function(element, editMode, width, height){
		this.baseSetEditorSize(element, editMode, width, height);
		if(editMode && !this.IsNative() && !this.dropDown)
			InitializeLFScrollBoxSize(element, width, height);
	}
	this.baseSetEditorReadOnly = this.SetEditorReadOnly;
	this.SetEditorReadOnly = function(value){
		this.baseSetEditorReadOnly(value);
		if(!this.IsNative()){
			var LFListBox = this.GetLFListBox();
			if(LFListBox != null) LFListBox.SetReadOnly(value);
		}
		else{
			if(value)
				this.activeElement.onchange = new Function("OnECancelChanges('" + this.name + "')");
			else
				this.activeElement.onchange = new Function("OnEChange('" + this.name + "')");
		}
	}
	this.baseSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.baseSetEnabled(enabled);
		var LFListBox = this.GetLFListBox();
		if(LFListBox != null) LFListBox.SetEnabled(enabled);
	}

	this.OnCancelChanges = function(){
		if(!this.editable && this.IsNative())
			this.activeElement.selectedIndex = this.savedSelectedIndex;
	}
	
	this.OnMouseWheelCore = function(e){
		if(!this.IsNative()){
			var LFListBox = this.GetLFListBox();
			if(LFListBox != null){
				LFListBox.DoMouseWheel(e);
				return true;
			}
		}
		return false;
	}
	this.baseOnEditorKeyDown = this.OnEditorKeyDown;
	this.OnEditorKeyDown = function(e){
		var evt = _getEvent(e);
		var LFListBox = this.GetLFListBox();
		if(LFListBox != null){
			var ret = LFListBox.DoKeyDown(evt, this.IsTextEditor());
			if(ret != krUnhandled) return ret;
		}
		else
			switch(evt.keyCode){
				case kbHome: case kbEnd:
				case kbUp: case kbDown:
				case kbPgUp: case kbPgDown:
					return krSystem;
			}

		return this.baseOnEditorKeyDown(e);
	}
	this.baseOnEditorKeyUp = this.OnEditorKeyUp;
	this.OnEditorKeyUp = function(e){
		var evt = _getEvent(e);
		var keyCode = evt.keyCode;
		if(this.IsTextChangingKey(keyCode)){
			var charText = String.fromCharCode(keyCode);
			var textElement = this.GetTextInputElement();
			if(textElement != null && this.IsTextEditor()){
				var text = textElement.value;
				var pos = text.length;
				if(keyCode == kbBackSpace && pos <= 1){
					text = "";
					textElement.value = "";
				}
				var itemIndex = this.GetItemIndexByText(text, this.caseSensitiveSearch);
				if(itemIndex != -1 && text != ""){
					var displayText = this.GetDisplayText(itemIndex);
					if(keyCode == kbBackSpace) 
						pos--;
					textElement.value = displayText;
					var range = textElement.createTextRange();
					range.moveStart("character", pos);
					range.select();
					range.move("character", pos);
					this.SetSelectedValueInternal(this.GetValue(itemIndex), false);
					this.OnChange();
				}
				else
					this.SetSelectedValueInternal(text, false);
			}
			else{
				var itemIndex = this.GetItemIndexByChar(charText, this.caseSensitiveSearch);
				if(itemIndex != -1){
					this.SetSelectedValueInternal(this.GetValue(itemIndex), true);
					this.OnChange();
				}
			}
		}
		return this.baseOnEditorKeyUp(e);
	}
	this.GetItemIndexByText = function(text, caseSensitiveSearch){
		text = caseSensitiveSearch ? text : text.toLowerCase();
		for(var i = 0; i < this.GetItemCount(); i ++){
			var itemText = caseSensitiveSearch ? this.GetDisplayText(i) : this.GetDisplayText(i).toLowerCase();
			if(itemText.indexOf(text) == 0) return i;
		}
		return -1;
	}
	this.GetItemIndexByChar = function(charText, caseSensitiveSearch){
		var text = caseSensitiveSearch ? charText : charText.toLowerCase();
		var selectedIndex = this.GetSelectedIndex();
		for(var i = selectedIndex + 1; i < this.GetItemCount(); i ++){
			var itemText = caseSensitiveSearch ? this.GetDisplayText(i) : this.GetDisplayText(i).toLowerCase();
			if(itemText.indexOf(text) == 0) return i;
		}
		for(var i = 0; i < selectedIndex; i ++){
			var itemText = caseSensitiveSearch ? this.GetDisplayText(i) : this.GetDisplayText(i).toLowerCase();
			if(itemText.indexOf(text) == 0) return i;
		}
		return -1;
	}
	
	this.AddItemHTML = function(valueIndex, displayText, imageUrl){
		if(this.IsNative()){
			var newOption = document.createElement("OPTION");
			this.activeElement.appendChild(newOption);
			newOption.value = valueIndex;
			newOption.selected = true;
			_setElementInnerText(newOption, displayText);		
		}
		else{
			var LFListBox = this.GetLFListBox();
			if(LFListBox != null){
				imageUrl = (imageUrl != "") ? imageUrl : this.defaultImageUrl;
				LFListBox.AddItem(valueIndex, displayText, imageUrl);
			}
		}
	}
	this.RemoveByIndex = function(valueIndex, keepText){
		if(this.IsNative()) {
			var options = this.activeElement.options;
			for(var i = 0; i < options.length; i ++){
				if(options[i].value == valueIndex.toString()){
					_removeElement(options[i]);
					break;
				}
			}
		}
		else {
			var LFListBox = this.GetLFListBox();
			if(LFListBox != null) 
				LFListBox.RemoveItem(valueIndex, keepText);
		}
	}
	this.GetSelectedValue = function(){
		var valueIndex = this.GetSelectedValueIndex();
		if(this.actualValue != null && valueIndex < 0)
			return this.actualValue;
		else if(valueIndex > -1) 
			return this.GetValue(valueIndex);
		var textElement = this.GetTextInputElement();
		if(textElement != null) 
			return textElement.value;
		return null;
	}
	this.SetSelectedValue = function(value){
		this.SetSelectedValueInternal(value, true);
	}
	this.SetSelectedValueInternal = function(value, changeText){
		if(this.showNotExistingValueItem)
			this.RemoveByIndex(-1, true);
		this.actualValue = null;
		var valueIndex = this.IndexOfValue(value);
		if(valueIndex < 0){
			if(this.showNotExistingValueItem){
				this.AddItemHTML(-1, this.FormatEditValue(value), "");
				this.SetSelectedValueIndexInternal(-1, changeText);
			}
			else if(this.IsNative())
				this.SetSelectedValueIndexInternal(-1, changeText);


			else{
				var LFListBox = this.GetLFListBox();
				if(LFListBox != null) 
					LFListBox.SetSelectedText(value, this.defaultImageUrl);
			}
			this.actualValue = value;
		}
		else 
			this.SetSelectedValueIndexInternal(valueIndex, changeText);
	}
	this.GetSelectedValueIndex = function(){
		var inputElement = this.GetInputElement();
		var valueIndex = Number((inputElement != null) ? inputElement.value : "-1");
		return !isNaN(valueIndex) ? valueIndex : -1;
	}
	this.SetSelectedValueIndex = function(valueIndex){
		this.SetSelectedValueIndexInternal(valueIndex, true);
	}
	this.SetSelectedValueIndexInternal = function(valueIndex, changeText){
		if(this.IsNative()){
			if(this.showNotExistingValueItem){
				var options = this.activeElement.options;
				for(var i = 0; i < this.activeElement.options.length; i ++){
					if(options[i].value == valueIndex.toString()){
						if(!options[i].selected)
							options[i].selected = true;
						break;
					}
				}
			}
			else
				this.activeElement.selectedIndex = valueIndex;
		}
		else {
			var LFListBox = this.GetLFListBox();
			if(LFListBox != null){
				if(changeText)
					LFListBox.SetSelectedIndex(valueIndex);
				else
					LFListBox.SetSelectedIndexByText(valueIndex);
			}
		}
	}
	this.baseInitializeControl = this.InitializeControl;
	this.InitializeControl = function(){
		this.baseInitializeControl();
		if(!this.showNotExistingValueItem && this.savedSelectedIndex == -1 && this.IsNative())
			if(this.activeElement != null)
				this.activeElement.selectedIndex = -1;
	}

	this.GetDisplayText = function(index){
		var displayText = this.displayTexts[index];
		if(_isExists(displayText)) 
			return displayText;
		else if(this.standAlone){
			if(this.IsNative()){
				if(this.activeElement != null)
					return _getElementInnerText(this.activeElement.options[index]);
			}
			else{
				var LFListBox = this.GetLFListBox();
				if(LFListBox != null) 
					return LFListBox.GetItemText(index);
			}
		}
		return this.GetValue(index);
	}
	this.GetImageUrl = function(index){
		var imageUrl = this.imageUrls[index];
		if(_isExists(imageUrl))
			return imageUrl;
		else if(this.standAlone){
			if(this.IsNative()){
				return "";
			}
			else{
				var LFListBox = this.GetLFListBox();
				if(LFListBox != null) 
					return LFListBox.GetImageUrl(index);
			}
		}
		return "";
	}
	this.BeginUpdate = function(){
		var LFListBox = this.GetLFListBox();
		if(LFListBox != null) LFListBox.BeginUpdate();
	}
	this.EndUpdate = function(){
		var LFListBox = this.GetLFListBox();
		if(LFListBox != null) LFListBox.EndUpdate();
	}
	this.Add = function(value, displayText, imageUrl){
		var valueIndex = this.IndexOfValue(value);
		if(valueIndex == -1){
			this.AddItemHTML(this.GetItemCount(), displayText, imageUrl);
			this.AddItem(value, displayText, imageUrl);

			this.insertedItems.push(value);
			this.SynchronizeItems(this.insertedItems, "InsertedItems");
		}
	}
	this.Clear = function(){
		this.BeginUpdate();
		while(this.GetItemCount() > 0)
			this.Remove(this.GetValue(this.GetItemCount() - 1));
		this.EndUpdate();
	}
	this.Remove = function(value){
		var valueIndex = this.IndexOfValue(value);
		if(valueIndex > -1){
			this.RemoveByIndex(valueIndex, false);
			array_removeAt(this.values, valueIndex);
			array_removeAt(this.displayTexts, valueIndex);
			array_removeAt(this.imageUrls, valueIndex);
			
			if(array_indexOf(this.insertedItems, value) > -1)
				array_remove(this.insertedItems, value);
			else{
				this.deletedItems.push(value);
				this.SynchronizeItems(this.deletedItems, "DeletedItems");
			}
		}
	}
	
	this.SynchronizeItems = function(itemsList, itemsType){
		var inputElement = _getHiddenInput(this.name + itemsType);
		if(inputElement != null){
			inputElement.value = "";
			for(var i = 0; i < itemsList.length; i ++){
				this.AddSynchronizedItem(inputElement, itemsList[i], itemsType);
				if(i < itemsList.length - 1) inputElement.value += ";;";
			}
			
		}
	}
	this.AddSynchronizedItem = function(inputElement, itemValue, itemsType){
		var format = _isDate(itemValue) ? "{0:MM/dd/yyyy HH:mm:ss fff}" : "";
		inputElement.value += FormatValue(itemValue, format, "");
		
		var valueIndex = this.IndexOfValue(itemValue);
		if(valueIndex > -1 && itemsType != "DeletedItems"){
			inputElement.value += "::" + this.GetDisplayText(valueIndex);
			inputElement.value += "::" + this.GetImageUrl(valueIndex);
		}	
	}	
}
function ASPxClientDropDownList(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientListBox;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.dropDown = true;
	this.dropedDown = false;
	this.dropDownEditable = false;
	
	this.GetTextInputElement = function(){
		return (this.activeElement != null) ? _getChildByTagName(this.activeElement, "INPUT", 0) : null;
	}
	this.GetLFListBox = function(){
		var LFListBoxElement = this.GetLFListBoxElement();
		return (LFListBoxElement != null) ? GeLookAndFeeltListBoxCollection().Get(LFListBoxElement.id) : null;
	}
	this.GetLFListBoxElement = function(){
		var LFPopupContainerElement = this.GetLFPopupContainerElement();
		return (LFPopupContainerElement != null) ? _getChildByCssClass(LFPopupContainerElement, "LFScrollBox") : null;
	}
	this.GetLFPopup = function(){
		var popupElement = this.GetLFPopupElement();
		return (popupElement != null) ? GetLookAndFeelPopupCollection().Get(popupElement.id) : null;
	}
	this.GetLFPopupElement = function(){
		if(!this.IsNative() && this.activeElement != null)
			return _getChildByCssClass(this.activeElement, "LFPopup");
		return null;
	}
	this.GetLFPopupContainerElement = function(){
		var LFPopup = this.GetLFPopup();
		return (LFPopup != null) ? LFPopup.GetContainerElement() : null;
	}
	this.GetTextInputElement = function(){
		if(!this.IsNative() && this.activeElement != null)
			return _getChildByTagName(this.activeElement, "INPUT", 0);
		return null;	
	}

	this.listBindEditValue = this.BindEditValue;
	this.BindEditValue = function(value, renderValueDirectly){
		this.listBindEditValue(value, renderValueDirectly);
		this.CorrectEditorSize();
	}	
	this.SetActiveElement = function(element){
		this.activeElement = element;
		
		var LFListBox = this.GetLFListBox();
		if(LFListBox != null) 
			LFListBox.SetRootElement(this.GetLFListBoxElement());

		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) 
			LFPopup.SetRootElement(this.GetLFPopupElement());
	}
	this.FocusControl = function(){
		if(!this.IsNative()){
			var LFPopup = this.GetLFPopup();
			if(LFPopup != null) LFPopup.Focus();
		}
		else 
			this.FocusElement(this.activeElement);
	}
	this.baseDeactivateEditor = this.DeactivateEditor;		
	this.DeactivateEditor = function(){
		if(this.activeElement == null) return;
		
		this.HidePopup();
		this.baseDeactivateEditor();	
	}

	this.listSetEditorReadOnly = this.SetEditorReadOnly;
	this.SetEditorReadOnly = function(value){
		this.listSetEditorReadOnly(value);
		if(this.dropDownEditable && !this.IsNative()){
			var textElement = this.GetTextInputElement();
			if(textElement != null) textElement.readOnly = value;
		}
	}
	this.listSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.listSetEnabled(enabled);
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) LFPopup.SetEnabled(enabled);
	}
	
	this.NeedCorrectEditorSize = function(){
		return !this.IsNative();
	}
	this.IsTextEditor = function(){
		return this.dropDownEditable;
	}
	
	this.baseListInitializeControl = this.InitializeControl;
	this.InitializeControl = function(){
		this.CheckPopupsInitialized();
		this.baseListInitializeControl();
	}
		
	this.listOnEditorKeyDown = this.OnEditorKeyDown;
	this.OnEditorKeyDown = function(e){
		var evt = _getEvent(e);
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null){
			var ret = LFPopup.DoKeyDown(e);
			if(ret != krUnhandled) return ret;
		}
		else {
			switch(evt.keyCode){
				case kbUp: case kbDown: 
					return krSystem;
			}
		}
		return this.listOnEditorKeyDown(e);
	}
	this.IsMouseInControl = function(evt){
		var ret = _getIsParent(this.activeElement, _getEventSource(evt));
		if(!ret){
			var LFPopupContainerElement = this.GetLFPopupContainerElement();
			if(LFPopupContainerElement != null)
				ret = _getIsParent(LFPopupContainerElement, _getEventSource(evt));
		}
		return ret;
	}
	this.DoCloseUp = function(){
		this.dropedDown = false;
		this.OnCloseUp();
	}
	this.DoDropDown = function(){
		this.dropedDown = true;
		this.OnDropDown();
	}
	this.HidePopup = function(){
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) LFPopup.HidePopup();
	}
	this.ShowPopup = function(){
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) LFPopup.ShowPopup();
	}		
	this.CloseUp = new ASPxClientEvent();		
	this.DropDown = new ASPxClientEvent();
	
	this.OnCloseUp = function(){
		if(!this.CloseUp.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.CloseUp.FireEvent(this, args);
		}
	}
	this.OnDropDown = function(){
		if(!this.DropDown.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.DropDown.FireEvent(this, args);
		}
	}
}
function ASPxClientLookup(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientDropDownList;
	this.inherit(name, dataControllerName, fieldIndex);	
}
function ASPxClientRadioButtonList(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientListEditBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	this.isHorizontalLayout = false;
	
	this.GetItemElement = function(index){
		return (this.activeElement != null) ? _getChildById(this.activeElement, (this.name + index).toString()) : null;
	}
	this.GetDefaultItemElement = function(){
		return this.GetItemElement(-1);
	}
	this.SetEditorInputName = function(){
		for(var i = 0; i < this.GetItemCount(); i ++){
			var radioElement = this.GetItemElement(i);
			if(radioElement != null) radioElement.name = this.name;
		}
		var radioElement = this.GetDefaultItemElement();
		if(radioElement != null) radioElement.name = this.name;
	}
	this.FocusControl = function(){
		var radioElement = this.GetItemElement(0);
		if(radioElement != null) this.FocusElement(radioElement);
	}
	this.SetEditorItemReadOnly = function(value, itemIndex){
		var radioElement = this.GetItemElement(itemIndex);
		if(radioElement != null){
			if(value)
				radioElement.onclick = new Function("OnECancelChanges('" + this.name + "')");
			else
				radioElement.onclick = new Function("OnEChange('" + this.name + "')");
		}
	}
	this.baseSetEditorReadOnly = this.SetEditorReadOnly;
	this.SetEditorReadOnly = function(value){
		this.baseSetEditorReadOnly(value);
		for(var i = 0; i < this.GetItemCount(); i ++)
			this.SetEditorItemReadOnly(value, i);
		this.SetEditorItemReadOnly(value, -1);
	}
	this.SetItemEnabled = function(enabled, itemIndex){
		var radioElement = this.GetItemElement(itemIndex);
		if(radioElement != null)
			radioElement.disabled  = !enabled;	
	}
	this.baseSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.baseSetEnabled(enabled);
		if(this.activeElement != null){
			for(var i = 0; i < this.GetItemCount(); i ++)
				this.SetItemEnabled(enabled, i);
			this.SetItemEnabled(enabled, -1);
		}
	}
	
	this.GetSelectedValue = function(){
		var valueIndex = this.GetSelectedValueIndex();
		if(this.actualValue != null && valueIndex < 0)
			return this.actualValue;
		else if(valueIndex > -1) 
			return this.GetValue(valueIndex);
		return null;
	}
	this.SetSelectedValue = function(value){
		if(this.showNotExistingValueItem)
			this.DestroyActualValueElement(this.activeElement);
		this.actualValue = null;
		var valueIndex = this.IndexOfValue(value);
		if(valueIndex < 0 ){
			if(this.showNotExistingValueItem){
				this.CreateActualValueElement(this.activeElement, value);
				this.SetSelectedValueIndex(-1);
			}
			else 
				this.SetSelectedValueIndex(-1);
			this.actualValue = value;
		}
		else
			this.SetSelectedValueIndex(valueIndex);
	}
	this.GetSelectedValueIndex = function(){
		for(var i = 0; i < this.GetItemCount(); i ++){
			var radioElement = this.GetItemElement(i);
			if(radioElement != null){
				if(radioElement.checked)
					return Number(radioElement.value);
			}
		}
		return -1;
	}
	this.SetSelectedValueIndex = function(valueIndex){
		var radioElement = this.GetItemElement(valueIndex);
		if(radioElement != null) radioElement.checked = true;
	}
	
	this.CreateActualValueInputElement = function(element, value){
		var newRadioItemName = this.name + (this.standAlone ? "" : "Fake");
		var newRadioItem = document.createElement("<INPUT name='" + newRadioItemName + "'/>");
		newRadioItem.type = "radio";
		element.appendChild(newRadioItem);
		newRadioItem.id = this.name + "-1";
		newRadioItem.name = this.name;
		newRadioItem.value = -1;
		newRadioItem.onclick = new Function("OnEChange('" + this.name + "')");
		newRadioItem.onblur = new Function("OnELostFocus('" + this.name + "')");
		newRadioItem.onfocus = new Function("OnEGetFocus('" + this.name + "')");
		var newRadioItemLabel = document.createElement("LABEL");
		element.appendChild(newRadioItemLabel);
		newRadioItemLabel.htmlFor = this.name + "-1";
		_setElementInnerText(newRadioItemLabel, this.FormatEditValue(value));
	}
	this.CreateActualValueElement = function(element, value){
		var defaultCell = _getChildById(element, this.name + "DefaultCell");
		if(defaultCell != null)
			this.CreateActualValueInputElement(defaultCell, value);
		else if(!this.isHorizontalLayout){
			var newTr = document.createElement("TR");
			_getFirstChild(element).appendChild(newTr);
			var newTd = document.createElement("TD");
			newTr.appendChild(newTd);
			newTd.id = this.name + "DefaultCell";
			this.CreateActualValueInputElement(newTd, value);
		}
		else {
			var newTd = document.createElement("TD");
			_getFirstChild(_getFirstChild(element)).appendChild(newTd);
			newTd.id = this.name + "DefaultCell";
			this.CreateActualValueInputElement(newTd, value);
		}
	}
	this.DestroyActualValueElement = function(element){
		var defaultElement = this.GetDefaultItemElement();
		if(defaultElement != null) {
			var defaultCell = _getChildById(element, this.name + "DefaultCell");
			if(defaultCell != null)
				while(defaultCell.hasChildNodes())
					_removeElement(_getFirstChild(defaultCell));
			else if(this.isHorizontalLayout)
				_removeElement(_getLastChild(_getFirstChild(element)));
			else 
				_removeElement(_getLastChild(_getFirstChild(_getFirstChild(element))));
		}
	}
	
	this.OnCancelChanges = ChangeCancel = function(){
		if(!this.editable){
			var radioElement = this.GetItemElement(this.savedSelectedIndex);
				if(radioElement != null)
					radioElement.checked = true;
		}
	}
	this.baseOnEditorKeyDown = this.OnEditorKeyDown;
	this.OnEditorKeyDown = function(e){
		var evt = _getEvent(e);
		switch(evt.keyCode){
			case kbUp: case kbDown:
				return krSystem;
		}
		return this.baseOnEditorKeyDown(e);
	}
	
	this.GetDisplayText = function(index){
		var displayText = this.displayTexts[index];
		if(_isExists(displayText)) 
			return displayText;
		else if(this.standAlone){
			var itemElement = this.GetItemElement(index);
			if(itemElement != null){
				var textElement = _getChildByTagName(_getParentNode(itemElement), "LABEL", 0);
				return (textElement != null) ? _getElementInnerText(textElement) : "";
			}
		}
		return this.GetValue(index);
	}
	this.GetImageUrl = function(index){
		var imageUrl = this.imageUrls[index];
		if(_isExists(imageUrl))
			return imageUrl;
		else if(this.standAlone){
			var itemElement = this.GetItemElement(index);
			if(itemElement != null){
				var imageElement = _getChildByTagName(_getParentNode(itemElement), "LABEL", 0);
				return (imageElement != null) ? imageElement.src : "";
			}
		}
		return "";
	}
	
}

function OnDDLDropDown(name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.DoDropDown();	
}

function OnDDLCloseUp(name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.DoCloseUp();	
}