var savedPSEditNav = null;
var savedPSEditNavIndex = null;
var savedPSEditNavPageSize = 0;
function ASPxClientDataNavigatorCore(name, dataControllerName, navigatableName){
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	

	this.dataControllerName = dataControllerName;
	this.navigatableName = navigatableName;
	this.dataController = null;
	this.navigatable = null;

	this.enabled = true;	
	this.enableKeyboardProcessing = true;
	this.postBackOnEnteringEditMode = false;
	this.postBackOnPostingDataChanges = false;
	this.enableCallBacks = false;
	this.processOnServer = true;
	this.barItemCount = 0;
	this.clientSideMode = false;
	this.confirmDelete = true;
	this.confirmDeleteMessage = "Delete record?";
	this.standAlone = true;
	this.incrementalSearch = false;
	
	this.focused = false;
	this.focusedEditorIndex = -1;
	this.focusedEditorKind = "";
	
	this.controlElement = null;
	this.controlBtnsElement = null;
	this.GotFocus = new ASPxClientEvent();
	this.LostFocus = new ASPxClientEvent();
	this.KeyDown = new ASPxClientEvent();
	this.KeyUp = new ASPxClientEvent();
	
	this.GetDataController = function (){
		if(_isFunctionType(typeof(GetDataControllerCollection)))
			return GetDataControllerCollection().Get(this.dataControllerName);
		return null;
	}
	this.GetNavigatable = function(){
		return GetNavigatableCollection().Get(this.navigatableName);
	}
	this.GetEventSender = function(){
		if(this.navigatable != null && !this.standAlone)
			return this.navigatable;
		return this;
	}
	this.GetServerValidationPassed = function(){
		return true;
	}

	this.GetControlElement = function(){
		if(!_isExists(this.controlElement))
			this.controlElement = _getElementById(this.name);
		return this.controlElement;
	}
	this.GetControlBtnsElement = function(){
		if(!_isExists(this.controlBtnsElement))
			this.controlBtnsElement = _getElementById(this.name + "Btns");
		return this.controlBtnsElement;
	}
	this.GetButtonElement = function(partId, index){
		return _getChildById(this.GetControlBtnsElement(), this.name + partId + index);
	}
	this.GetButtonDropDownElement = function(partId, index){
		return _getChildById(this.GetControlBtnsElement(), this.name + partId + index + "DropDown");
	}
	this.GetButtonPopupElement = function(partId, index){
		return _getChildById(this.GetControlBtnsElement(), this.name + partId + index + "Popup");
	}
	this.GetButtonListElement = function(partId, index){
		return _getElementById(this.name + partId + index + "List");
	}
	this.GetButtonEditorElement = function(partId, index){
		return _getChildById(this.GetControlBtnsElement(), this.name + partId + index + "Edt");
	}
	this.GetButtonEditorApplyBtnElement = function(partId, index){
		return _getChildById(this.GetControlBtnsElement(), this.name + partId + index + "ApplyBtn");
	}
	this.GetButtonIndexBtnElement = function(partId, index, buttonIndex){
		return _getChildById(this.GetControlBtnsElement(), this.name + partId + index + "B" + buttonIndex);
	}
	this.GetSectionElement = function(partId, index){
		return _getChildById(this.GetControlBtnsElement(), this.name + partId + index);
	}
	this.GetStatusSectionElement = function(){
		if(!_isExists(this.statusSection)){
			for(var i = 0; i < this.GetBarItemCount(); i ++){
				this.statusSection = this.GetSectionElement("SS", i);
				if(_isExists(this.statusSection))
					break;
			}
		}
		return this.statusSection;
	}
	this.GetPageSizeEditorElement = function(index){
		return this.GetButtonEditorElement("NCPSB", index);
	}
	this.GetPageSizeButtonElement = function(index){
		return this.GetButtonElement("NCPSB", index);
	}
	this.GetPageSizeApplyButtonElement = function(index){
		return this.GetButtonEditorApplyBtnElement("NCPSB", index);
	}
	this.GetPageSize = function(index){
		var pageSizeElement = this.GetPageSizeEditorElement(index);
		if(pageSizeElement != null){
			var reg = /^[0-9]+$/;
			if(reg.test(pageSizeElement.value) && _parseInt(pageSizeElement.value) < Math.pow(2, 32) - 1)
				return _parseInt(pageSizeElement.value);
			else
				alert("The size of page must be a valid integer number");
		}
		return NaN;
	}
	this.GetPageIndexStartBtnElement = function(index){
		return _getChildById(this.GetControlBtnsElement(), this.name + "NPIB" + index);
	}
	this.GetPageIndexBtnElement = function(index, pageIndex){
		return this.GetButtonIndexBtnElement("NPIB", index, pageIndex);
	}
	this.GetGoToPageEditorElement = function(index){
		return this.GetButtonEditorElement("NGTPB", index);
	}
	this.GetGoToPage = function(index){
		var gotoPageElement = this.GetGoToPageEditorElement(index);
		if(gotoPageElement != null){
			var reg = /^[0-9]+$/;
			if(reg.test(gotoPageElement.value) && _parseInt(gotoPageElement.value) < Math.pow(2, 32) - 1)
				return _parseInt(gotoPageElement.value) - 1;
			else
				alert("The number of page must be a valid integer number");
		}
		return NaN;
	}
	this.GetSelectPageDropDownElement = function(index){
		return this.GetButtonDropDownElement("NSPB", index);
	}
	this.GetSelectPageValueElement = function(index){
		return this.GetButtonListElement("NSPB", index);
	}
	this.GetSelectPage = function(index){
		var selectElement = this.GetSelectPageValueElement(index);
		if(selectElement != null)
			return _parseInt(selectElement.value);
		return 0;
	}
	this.GetSelectPageLFPopup = function(index){
		var LFPopupElement = this.GetSelectPageLFPopupElement(index);
		return (LFPopupElement != null) ? GetLookAndFeelPopupCollection().Get(LFPopupElement.id) : null;
	}
	this.GetSelectPageLFPopupElement = function(index){
		return this.GetButtonPopupElement("NSPB", index);
	}
	this.GetSelectPageLFPopupContainerElement = function(index){
		var LFPopup = this.GetSelectPageLFPopup(index);
		return (LFPopup != null) ? LFPopup.GetContainerElement() : null;
	}
	this.GetSelectPageLFListBox = function(index){
		var LFListBoxElement = this.GetSelectPageLFListBoxElement(index);
		return (LFListBoxElement != null) ? GeLookAndFeeltListBoxCollection().Get(LFListBoxElement.id) : null;
	}
	this.GetSelectPageLFListBoxElement = function(index){
		var LFPopupContainerElement = this.GetSelectPageLFPopupContainerElement(index);
		return (LFPopupContainerElement != null) ? _getChildByCssClass(LFPopupContainerElement, "LFScrollBox") : null;
	}
	this.GetSearchColumnIndexDropDownElement = function(index){
		return this.GetButtonDropDownElement("NSRB", index);
	}
	this.GetSearchColumnIndexValueElement = function(index){
		return this.GetButtonListElement("NSRB", index);
	}
	this.GetSearchColumnIndex = function(index){
		var searchColumnElement = this.GetSearchColumnIndexValueElement(index);
		if(searchColumnElement != null)
			return _parseInt(searchColumnElement.value);
		return 0;
	}
	this.GetSearchColumnIndexLFPopup = function(index){
		var LFPopupElement = this.GetSearchColumnIndexLFPopupElement(index);
		return (LFPopupElement != null) ? GetLookAndFeelPopupCollection().Get(LFPopupElement.id) : null;
	}
	this.GetSearchColumnIndexLFPopupElement = function(index){
		return this.GetButtonPopupElement("NSRB", index);
	}
	this.GetSearchColumnIndexLFPopupContainerElement = function(index){
		var LFPopup = this.GetSearchColumnIndexLFPopup(index);
		return (LFPopup != null) ? LFPopup.GetContainerElement() : null;
	}
	this.GetSearchColumnIndexLFListBox = function(index){
		var LFListBoxElement = this.GetSearchColumnIndexLFListBoxElement(index);
		return (LFListBoxElement != null) ? GeLookAndFeeltListBoxCollection().Get(LFListBoxElement.id) : null;
	}
	this.GetSearchColumnIndexLFListBoxElement = function(index){
		var LFPopupContainerElement = this.GetSearchColumnIndexLFPopupContainerElement(index);
		return (LFPopupContainerElement != null) ? _getChildByCssClass(LFPopupContainerElement, "LFScrollBox") : null;
	}
	this.GetSearchedStringEditorElement = function(index){
		return this.GetButtonEditorElement("NSRB", index);
	}
	this.GetSearchedString = function(index){
		var searchElement = this.GetSearchedStringEditorElement(index);
		if(searchElement != null)
			return searchElement.value;
		return "";
	}
	this.GetBarItemCount = function(){
		return this.barItemCount;
	}
	this.ShowLoadingText = function(text){
		var statusSectionElement = this.GetStatusSectionElement();
		if(statusSectionElement != null){
			var dataElement = _getChildById(statusSectionElement, "Data");
			if(dataElement != null){
				 _setElementInnerText(dataElement, text);
				 return true;
			}
		}
		return false;
	}
	
	this.BtnClick = function(e, index, action){
		if(this.navigatable != null && !this.standAlone)
			this.navigatable.Navigatable_ButtonClick(e, this.name, index, action);
		else {
			var processOnServer = (this.postBackOnPostingDataChanges && action == "Post") || 
				(this.postBackOnEnteringEditMode && (action == "EditRow" || action == "AppendRow" || action == "InsertRow"));
			var processingMode = this.clientSideMode ? this.OnButtonClick(this.barItems[index], processOnServer) : "Server";
			if(processingMode != "Handled"){
				this.InitPostBack(e, "CLICK#" + index);
				if(processingMode == "Client" && this.navigatable != null){
					switch(action){
						case "MoveFirst":
							this.navigatable.MoveFirst();
							break;
						case "MovePrevPage":	
							this.navigatable.MovePrevPage();
							break;
						case "MovePrev":
							this.navigatable.MovePrev();
							break;
						case "MoveNext":
							this.navigatable.MoveNext();
							break;	
						case "MoveNextPage":
							this.navigatable.MoveNextPage();
							break;		
						case "MoveLast":
							this.navigatable.MoveLast();
							break;	
						case "AppendRow":
							this.navigatable.New(true);
							break;	
						case "InsertRow":
							this.navigatable.New(false);
							break;		
						case "EditRow":
							this.navigatable.Edit();
							break;	
						case "Post":
							this.navigatable.Post();
							break;				
						case "Cancel":
							this.navigatable.Cancel();
							break;	
						case "Refresh":	
							this.SendPostBack(false);
							break;	
						case "Custom":	
							break;		
					}
				}
				else{
					this.SendPostBack(false);
				}
			}		
		}		
	}
	
	 
	this.ChangePageSizeBtnClick = function(e, index, action){
		if(!this.IsEditPageSize(index))
			this.EditPageSize(e, index);
		else {
			var processingMode = this.standAlone ? (this.clientSideMode ? this.OnButtonClick(this.barItems[index], this.processOnServer) : "Server") : "";
			this.InitPostBack(e, "CLICK#" + index);
			this.SetPageSize(e, index, processingMode);
		}
	}
	this.GoToPageIndexBtnClick = function(e, index, pageIndex, action){	
		if(this.navigatable != null && !this.standAlone)
			this.navigatable.Navigatable_SetCurrentPageIndex(e, this.name, index, true, pageIndex);
		else {
			var processingMode = this.clientSideMode ? this.OnButtonClick(this.barItems[index], this.processOnServer) : "Server";
			if(processingMode != "Handled"){
				this.InitPostBack(e, "CLICK#" + index + "#" + pageIndex);
				if(processingMode == "Client" && this.navigatable != null)
					this.navigatable.SetCurrentPageIndex(pageIndex);
				else
					this.SendPostBack(false);
			}
		}	
	}
	this.GoToPageBtnClick = function(e, index, action){
		var processingMode = this.standAlone ? (this.clientSideMode ? this.OnButtonClick(this.barItems[index], this.processOnServer) : "Server") : "";
		this.InitPostBack(e, "CLICK#" + index);
		this.GoToPage(e, index, processingMode);
	}
	this.SelectPageBtnClick = function(e, index, action){
		var pageIndex = this.GetSelectPage(index);
		if(this.navigatable != null && !this.standAlone)
			this.navigatable.Navigatable_SetCurrentPageIndex(_getEvent(e), this.name, index, false, pageIndex);
		else {
			var processingMode = this.clientSideMode ? this.OnButtonClick(this.barItems[index], this.processOnServer) : "Server";
			if(processingMode != "Handled"){
				this.InitPostBack(e, "CLICK#" + index);
				if(processingMode == "Client" && this.navigatable != null)
					this.navigatable.SetCurrentPageIndex(pageIndex);
				else
					this.SendPostBack(false);
			}					
		}
	}
	this.DeleteBtnClick = function(e, index, action){	
		if(this.navigatable != null && !this.standAlone)
			this.navigatable.Navigatable_ButtonClick(e, this.name, index, action);
		else {
			var processingMode = this.clientSideMode ? this.OnButtonClick(this.barItems[index], this.postBackOnPostingDataChanges) : "Server";
			if(processingMode != "Handled" && (!this.confirmDelete || confirm(this.confirmDeleteMessage))){
				this.InitPostBack(e, "CLICK#" + index);				
				if(processingMode == "Client" && this.navigatable != null)
					this.navigatable.Delete();
				else
					this.SendPostBack(false);
			}
		}
	}		
	this.SearchBtnClick = function(e, index, action){
		var processingMode = this.standAlone ? (this.clientSideMode ? this.OnButtonClick(this.barItems[index], false) : "Server") : "";
		this.InitPostBack(e, "CLICK#" + index);
		this.Search(e, index, processingMode);
	}	

	this.SetPageSizeEditorEnabled = function(inputElement, enabled){
		inputElement.disabled = !enabled;
		var containerElement = _getParentByTagName(inputElement, "TABLE");
		if(containerElement != null) containerElement.disabled = !enabled;
	}
	this.CancelPageSize = function(e, index){
		if(!this.IsEditPageSize(index)) return;

		this.EditorBlur(index, "NCPSBEdt", false);
		var pageSizeEditorElement = this.GetPageSizeEditorElement(index);
		if(pageSizeEditorElement != null) {
			pageSizeEditorElement.value = savedPSEditNavPageSize;
			this.SetPageSizeEditorEnabled(pageSizeEditorElement, false);
		}
		var pageSizeButtonElement = this.GetPageSizeButtonElement(index);
		if(pageSizeButtonElement != null) 
			this.SetButtonDisplay(pageSizeButtonElement, true);
		var pageSizeApplyButtonElement = this.GetPageSizeApplyButtonElement(index);
		if(pageSizeApplyButtonElement != null)
			this.SetButtonDisplay(pageSizeApplyButtonElement, false);

		savedPSEditNav = null;
		savedPSEditNavIndex = null;
	}
	this.EditPageSize = function(e, index){
		if(this.IsEditPageSize(index)) return;
		
		savedPSEditNav = this;
		savedPSEditNavIndex = index;
		var pageSizeEditorElement = this.GetPageSizeEditorElement(index);
		if(pageSizeEditorElement != null) {
			savedPSEditNavPageSize = _parseInt(pageSizeEditorElement.value);
			this.SetPageSizeEditorEnabled(pageSizeEditorElement, true);
			_focusElement(pageSizeEditorElement);
			_selectElement(pageSizeEditorElement);
		}
		var pageSizeButtonElement = this.GetPageSizeButtonElement(index);
		if(pageSizeButtonElement != null) 
			this.SetButtonDisplay(pageSizeButtonElement, false);
		var pageSizeApplyButtonElement = this.GetPageSizeApplyButtonElement(index);
		if(pageSizeApplyButtonElement != null)
			this.SetButtonDisplay(pageSizeApplyButtonElement, true);
	}
	this.IsEditPageSize = function(index){
		return (this == savedPSEditNav && index == savedPSEditNavIndex);
	}
	this.SetPageSize = function(e, index, processingMode){
		if(!this.IsEditPageSize(index)) return;
		
		this.EditorBlur(index, "NCPSBEdt", false);
		var pageSize = this.GetPageSize(index);	
		if(!isNaN(pageSize)){
			savedPSEditNavPageSize = pageSize;
			if(this.navigatable != null && !this.standAlone){
				this.navigatable.Navigatable_SetPageSize(e, this.name, index, pageSize);
				this.CancelPageSize(e, index);
			}
			else if(processingMode != "Handled"){
				if(processingMode == "Client" && this.navigatable != null){
					this.navigatable.SetPageSize(pageSize);
					this.CancelPageSize(e, index);
				}
				else
					this.SendPostBack(false);
			}
		}
	}
	this.GoToPage = function(e, index, processingMode){
		var pageIndex = this.GetGoToPage(index);
		if(!isNaN(pageIndex)){
			if(this.navigatable != null && !this.standAlone)
				this.navigatable.Navigatable_SetCurrentPageIndex(e, this.name, index, false, pageIndex);
			else if(processingMode != "Handled"){
				if(processingMode == "Client" && this.navigatable != null)
					this.navigatable.SetCurrentPageIndex(pageIndex);
				else
					this.SendPostBack(false);
			}						
		}
	}
	this.Search = function(e, index, processingMode){
		var searchColumnIndex = this.GetSearchColumnIndex(index);
		var searchedString = this.GetSearchedString(index);
		if(this.navigatable != null && !this.standAlone)
			this.navigatable.Navigatable_SearchRow(e, this.name, index, searchColumnIndex, searchedString);
		else if(processingMode != "Handled"){
			if(processingMode == "Client" && this.navigatable != null)
				this.navigatable.DoSearchRow(searchColumnIndex, searchedString);
			else
				this.SendPostBack(false);	
		}
	}

	this.SetButtonDisplay = function(btnElement, display){
		if(!_checkTagName(btnElement, "TD"))
			btnElement = _getParentNode(btnElement);
		if(_checkTagName(btnElement, "TD"))
			_setElementDisplay(btnElement, display);
	}
	this.Focus = function(){
		if(this.enabled){
			if(_isExists(document.activeElement))
				document.activeElement.blur();
			this.FocusControl();
		}
	}
	this.FocusControl = function(){
		this.OnGetFocus();
	}
	this.FocusControlEditor = function(){
		if(this.focusedEditorIndex == -1) return;
		
		switch(this.focusedEditorKind){
			case "NCPSBEdt":{
				var element = this.GetPageSizeEditorElement(this.focusedEditorIndex);
				if(element != null) _focusElement(element);
				break;
			}
			case "NGTPBEdt":{
				var element = this.GetGoToPageEditorElement(this.focusedEditorIndex);
				if(element != null){
					_focusElement(element);
					_selectElement(element);
				}
				break;
			}
			case "NSRBEdt":{
				var element = this.GetSearchedStringEditorElement(this.focusedEditorIndex);
				if(element != null){
					_focusElement(element);
					_selectElement(element);
				}
				break;
			}
			case "NSRBDdl":{
				var LFPopup = this.GetSearchColumnIndexLFPopup(this.focusedEditorIndex);
				if(LFPopup != null) 
					LFPopup.Focus();
				else{
					var element = this.GetSearchColumnIndexValueElement(this.focusedEditorIndex);
					if(element != null) _focusElement(element);
				}
				break;
			}
			case "NSPBDdl":{
				var LFPopup = this.GetSelectPageLFPopup(this.focusedEditorIndex);
				if(LFPopup != null) 
					LFPopup.Focus();
				else{
					var element = this.GetSelectPageValueElement(this.focusedEditorIndex);
					if(element != null) _focusElement(element);
				}
				break;
			}
		}
	}
	this.SetFocusedEditor = function(){
		_getHiddenInput(this.name + "FocusedEditorIndex").value = this.focusedEditorIndex;
		_getHiddenInput(this.name + "FocusedEditorKind").value = this.focusedEditorKind;
	}
	
	this.OnMouseUp = function(){
		if(this.enabled && this.focusedEditorIndex == -1) 
			this.FocusControl();
	}
	this.OnGetFocus = function(){
		if(this.standAlone)
			__setFocusedControl(this);
		else if(this.navigatable != null){
			__setFocusedControl(this.navigatable);
			this.navigatable.Navigatable_SetFocusedControl(this);
		}
		if(!this.GotFocus.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.GotFocus.FireEvent(this, args);
		}
	}
	this.OnLostFocus = function(){
		if(this.standAlone && __getFocusedControl() == this)
			__setFocusedControl(null);
		if(!this.LostFocus.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.LostFocus.FireEvent(this, args);
		}
	}
	this.EditorFocus = function(index, kind, canControlFocus){
		if(canControlFocus)
			this.OnGetFocus();
		this.focusedEditorIndex = index;
		this.focusedEditorKind = kind;	
	}
	this.EditorBlur = function(index, kind, canControlBlur){
		if(canControlBlur)
			this.OnLostFocus();
		this.focusedEditorIndex = -1;
		this.focusedEditorKind = "";
	}
	this.EditorMouseUp = function(index, kind){
		this.focusedEditorIndex = index;
		switch(kind){
			case "NSRBDdl":{
				var LFPopup = this.GetSearchColumnIndexLFPopup(this.focusedEditorIndex);
				if(LFPopup != null) LFPopup.Focus();
				break;
			}
			case "NSPBDdl":{
				var LFPopup = this.GetSelectPageLFPopup(this.focusedEditorIndex);
				if(LFPopup != null) LFPopup.Focus();
				break;
			}
		}
	}
	
	this.OnEditorMouseWheelCore = function(e){
		if(this.focusedEditorIndex == -1) return false;
		
		var evt = _getEvent(e);	
		switch(this.focusedEditorKind){
			case "NSRBDdl":{
				var LFListBox = this.GetSearchColumnIndexLFListBox(this.focusedEditorIndex);
				if(LFListBox != null){
					LFListBox.DoMouseWheel(evt);
					return true;
				}
				break;
			}
			case "NSPBDdl":{
				var LFListBox = this.GetSelectPageLFListBox(this.focusedEditorIndex);
				if(LFListBox != null){
					LFListBox.DoMouseWheel(evt);
					return true;
				}
				break;
			}
		}
		return false;
	}
	this.OnMouseWheelCore = function(e){
		return this.OnEditorMouseWheelCore(e);
	}
	this.OnEditorKeyDown = function(e, processingMode){
		var evt = _getEvent(e);	
		switch(this.focusedEditorKind){
			case "NCPSBEdt":{
				if(evt.keyCode == kbEnter){
					if(this.standAlone)
						this.InitPostBack(e, "KEYPRESS#ChangePageSize#" + evt.keyCode + "#" + this.focusedEditorIndex);
					this.SetPageSize(evt, this.focusedEditorIndex, processingMode);
					return krHandled;
				}
				else if(evt.keyCode == kbEsc){
					this.CancelPageSize(evt, this.focusedEditorIndex);
					return krHandled;
				}
				break;
			}
			case "NGTPBEdt":{
				if(evt.keyCode == kbEnter){
					if(this.standAlone)
						this.InitPostBack(e, "KEYPRESS#GoToPage#" + evt.keyCode + "#" + this.focusedEditorIndex);
					this.GoToPage(e, this.focusedEditorIndex, processingMode);
					var element = this.GetGoToPageEditorElement(this.focusedEditorIndex);
					if(element != null) _selectElement(element);
					return krHandled;
				}
				break;
			}
			case "NSRBEdt":{
				if(evt.keyCode == kbEnter){
					if(this.standAlone)
						this.InitPostBack(e, "KEYPRESS#Search#" + evt.keyCode + "#" + this.focusedEditorIndex);
					this.Search(e, this.focusedEditorIndex, processingMode);
					var element = this.GetSearchedStringEditorElement(this.focusedEditorIndex);
					if(element != null) _selectElement(element);
					return krHandled;
				}
				break;
			}
			case "NSRBDdl":{
				var LFPopup = this.GetSearchColumnIndexLFPopup(this.focusedEditorIndex);
				if(LFPopup != null){
					var popupRet = LFPopup.DoKeyDown(evt);
					if(popupRet == krHandled) return krHandled;
				}
				var LFListBox = this.GetSearchColumnIndexLFListBox(this.focusedEditorIndex);
				if(LFListBox != null){
					var listBoxRet = LFListBox.DoKeyDown(evt, false);
					if(listBoxRet == krHandled) return krHandled;
				}
				if(evt.keyCode == kbEnter){
					if(this.standAlone)
						this.InitPostBack(e, "KEYPRESS#Search#" + evt.keyCode + "#" + this.focusedEditorIndex);
					this.Search(e, this.focusedEditorIndex, processingMode);
					return krHandled;
				}
				break;
			}
			case "NSPBDdl":{
				var LFPopup = this.GetSelectPageLFPopup(this.focusedEditorIndex);
				if(LFPopup != null){
					var popupRet = LFPopup.DoKeyDown(evt);
					if(popupRet == krHandled) return krHandled;
				}
				var LFListBox = this.GetSelectPageLFListBox(this.focusedEditorIndex);
				if(LFListBox != null){
					var listBoxRet = LFListBox.DoKeyDown(evt, false);
					if(listBoxRet == krHandled) return krHandled;
				}
				break;
			}
		}
		switch(evt.keyCode){
			case kbEnter: case kbEsc:
			case kbDelete: case kbInsert:
			case kbHome: case kbEnd:
			case kbUp: case kbDown:
			case kbLeft: case kbRight:
			case kbPgUp: case kbPgDown:
				return krSystem;
		}
		return krUnhandled;
	}
	this.OnKeyDownCore = function(e){
		var evt = _getEvent(e);	
		var processingMode = this.OnKeyDown(evt);
		if(processingMode == "Handled")
			return krHandled;
		else{
			var ret = krUnhandled;
			if(!this.clientSideMode)
				processingMode = "Server";
			if(this.focusedEditorIndex > -1) 
				ret = this.OnEditorKeyDown(evt, processingMode);		
			if(ret == krUnhandled && this.standAlone){
				var action = "";
				switch(evt.keyCode){
					case kbPgUp:
						action = "MovePrevPage";
						break;
					case kbPgDown:
						action = "MoveNextPage";
						break;
					case kbEnd:
						if(_getCtrlKey(evt))
							action = "MoveLast";
						break;
					case kbHome:
						if(_getCtrlKey(evt))
							action = "MoveFirst";
						break;
					case kbUp:
						action = "MovePrev";
						break;
					case kbDown:
						action = "MoveNext";
						break;
					case kbEsc:
						action = "Cancel";
						break;
					case kbEnter:
						action = "Post";
						break;
					case kbInsert:
						action = "InsertRow";
						break;
					case kbDelete:
						if(!this.confirmDelete || confirm(this.confirmDeleteMessage))
							action = "DeleteRow";
						break;
					case kbF2:
						action = "EditRow";
						break;
				}
				if(action != ""){
					this.InitPostBack(e, "KEYPRESS#" + action + "#" + evt.keyCode);
					if(processingMode == "Client" && this.navigatable != null){
						switch(action){
							case "MovePrevPage":
								this.navigatable.MovePrevPage();
								return krHandled;
							case "MoveNextPage":
								this.navigatable.MoveNextPage();
								return krHandled;
							case "MoveLast":
								this.navigatable.MoveLast();
								return krHandled;
							case "MoveFirst":
								this.navigatable.MoveFirst();
								return krHandled;
							case "MovePrev":
								this.navigatable.MovePrev();
								return krHandled;
							case "MoveNext":
								this.navigatable.MoveNext();
								return krHandled;
							case "Cancel":
								this.navigatable.Cancel();
								return krHandled;
							case "Post":
								this.navigatable.Post();
								return krHandled;
							case "InsertRow":
								this.navigatable.New(false);
								return krHandled;
							case "DeleteRow":
								this.navigatable.Delete();
								return krHandled;
							case "EditRow":
								this.navigatable.Edit();
								return krHandled;
						}
					}
					else
						this.SendPostBack(false);
				}
				else if(processingMode != "Client")
					this.SendPostBack(false);
			}
			return ret;
		}
	}
	this.OnEditorKeyUp = function(e, processingMode){
		var evt = _getEvent(e);	
		switch(this.focusedEditorKind){
			case "NSRBEdt":{
				if(this.incrementalSearch && _isTextChangingKey(evt.keyCode)){
					if(this.standAlone)
						this.InitPostBack(e, "KEYPRESS#Search#" + evt.keyCode + "#" + this.focusedEditorIndex);
					this.Search(e, this.focusedEditorIndex, processingMode);
					return krHandled;
				}
				break;
			}
		}
		return krUnhandled;
	}
	this.OnKeyUpCore = function(e){
		var evt = _getEvent(e);
		var processingMode = this.OnKeyUp(evt);
		if(processingMode == "Handled")
			return krHandled;
		else{
			var ret = krUnhandled;
			if(!this.clientSideMode)
				processingMode = "Server";
			if(this.focusedEditorIndex > -1) 
				ret = this.OnEditorKeyUp(evt, processingMode);
		}
		return ret;
	}
	this.IsMouseInControl = function(evt){
		var ret = _getParentById(_getEventSource(evt), this.name);
		if(!ret && this.focusedEditorIndex > -1){
			switch(this.focusedEditorKind){
				case "NSRBDdl":{
					var LFPopupContainerElement = this.GetSearchColumnIndexLFPopupContainerElement(this.focusedEditorIndex);
					if(LFPopupContainerElement != null) 
						ret = _getIsParent(LFPopupContainerElement, _getEventSource(evt));
					break;
				}
				case "NSPBDdl":{
					var LFPopupContainerElement = this.GetSelectPageLFPopupContainerElement(this.focusedEditorIndex);
					if(LFPopupContainerElement != null) 
						ret = _getIsParent(LFPopupContainerElement, _getEventSource(evt));
					break;
				}
			}
		}
		return ret;
	}
	this.IsDefaultButtonActionAllowed = function(){
		return false;
	}
	this.CanFocusedControl = function(){
		return this.standAlone;
	}
	
	this.OnCustomRenderPageIndexButton = function(htmlElement, buttonIndex, pageIndex, text, tooltip, beforeDefaultRender){
		return false;
	}
	this.OnCustomRenderStatusSection = function(htmlElement, index, type, text, beforeDefaultRender){
		return false;
	}
	this.OnKeyDown = function(evt){	
		if(!this.KeyDown.IsEmpty()){
			var args = new ASPxClientProcessingModeKeyEventArgs(evt.keyCode, _getAltKey(evt), _getCtrlKey(evt), _getShiftKey(evt), !this.clientSideMode);
			this.KeyDown.FireEvent(this.GetEventSender(), args);
			return args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client");
		}
		return "Client";
	}
	this.OnKeyUp = function(evt){	
		if(!this.KeyUp.IsEmpty()){
			var args = new ASPxClientKeyEventArgs(evt.keyCode, _getAltKey(evt), _getCtrlKey(evt), _getShiftKey(evt));
			this.KeyUp.FireEvent(this.GetEventSender(), args);
			return args.handled ? "Handled" : "Client";
		}
		return "Client";
	}
	
	this.InitializeControl = function(){
		this.CheckPopupsInitialized();
		this.dataController = this.GetDataController();
		if(this.dataController != null){
			this.dataController.AddDataControl(this);
			this.dataController.CheckInitialized();
		}
		this.navigatable = this.GetNavigatable();
		if(this.navigatable != null){
			if(_isFunction(this.navigatable.AddNavigator))
				this.navigatable.AddNavigator(this);
			this.navigatable.CheckInitialized();
		}
		if(this.focused){
			this.FocusControl();
			this.FocusControlEditor();
		}
	}
	
	this.ApplyCallBackHtml = function(html){
		var element = _getElementById(this.name);
		var CBContainer = _getParentByCssClass(element, "CBContainer");
		CBContainer.innerHTML = html;
	}
	
	this.InitPostBack = function(evt, eventArgument){
		this.SetFocusedEditor();
		__initASPxPostBack(evt, this.name, eventArgument, this, this.enableCallBacks, false);
	}	

	GetDataNavigatorCollection().Add(this);
}

function GetNavigatableCollection(){
	if(__ASPxNavigatableCollection == null){
		__ASPxNavigatableCollection = new ASPxClientWebCollection();
	}
	return __ASPxNavigatableCollection;
}

function GetDataNavigatorCollection(){
	if(__ASPxDataNavigatorrCollection == null){
		__ASPxDataNavigatorrCollection = new ASPxClientWebCollection();
	}
	return __ASPxDataNavigatorrCollection;
}

function OnDNBtnCl(e, name, index, action){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.BtnClick(e, index, action);
}

function OnDNChPSCl(e, name, index, action){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.ChangePageSizeBtnClick(e, index, action);
}

function OnDNGoToPageIndCl(e, name, index, pageIndex, action){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.GoToPageIndexBtnClick(e, index, pageIndex, action);
}

function OnDNGoToPageCl(e, name, index, action){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.GoToPageBtnClick(e, index, action);
}

function OnDNSelPgCh(e, name, index, action){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.SelectPageBtnClick(e, index, action);
}

function OnDNDelCl(e, name, index, action){	
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.DeleteBtnClick(e, index, action);
}

function OnDNSrchCl(e, name, index, action){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.SearchBtnClick(e, index, action);
}

function OnDNEdtFocus(e, name, index, kind){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.EditorFocus(index, kind, true);
}

function OnDNEdtBlur(e, name, index, kind){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.EditorBlur(index, kind, true);
}

function OnDNEdtMouseUp(e, name, index, kind){
	var dataNavigator = GetDataNavigatorCollection().Get(name);
	if(dataNavigator != null) dataNavigator.EditorMouseUp(index, kind);
}

function OnDNGetFocus(name){
	var dataNavigator = GetDataNavigatorCollection().Get(name);	
	if(dataNavigator != null) dataNavigator.OnGetFocus();
}

var inDNLostFocus = false;
function OnDNLostFocus(name){
	if(inDNLostFocus) return;
	
	inDNLostFocus = true;
	var dataNavigator = GetDataNavigatorCollection().Get(name);	
	if(dataNavigator != null) dataNavigator.OnLostFocus();
	inDNLostFocus = false;
}
		
function OnDNMouseUp(name){
	var dataNavigator = GetDataNavigatorCollection().Get(name);	
	if(dataNavigator != null) dataNavigator.OnMouseUp();
}

function CanCancelSavedPageSizeEdit(e){
	if(savedPSEditNav != null){
		var srcElement = _getEventSource(e);
		var pageSizeEditorElement = savedPSEditNav.GetPageSizeEditorElement(savedPSEditNavIndex);
		var pageSizeButtonElement = savedPSEditNav.GetPageSizeButtonElement(savedPSEditNavIndex);
		var pageSizeApplyButtonElement = savedPSEditNav.GetPageSizeApplyButtonElement(savedPSEditNavIndex);
		return (srcElement == null)	|| 
			(srcElement != pageSizeEditorElement && srcElement != pageSizeButtonElement && srcElement != pageSizeApplyButtonElement &&
			!_getIsParent(pageSizeEditorElement, srcElement) &&
			!_getIsParent(pageSizeButtonElement, srcElement) &&
			!_getIsParent(pageSizeApplyButtonElement, srcElement));
	}
	return false;

}

function CancelSavedPageSizeEdit(e){
	if(savedPSEditNav != null)
		savedPSEditNav.CancelPageSize(e, savedPSEditNavIndex);
}

function navDocumentOnMouseDown(e){
	if(savedPSEditNav != null){
		if(CanCancelSavedPageSizeEdit(e))
			CancelSavedPageSizeEdit(e);
	}
	if(_isExists(savedNavDocumentOnMouseDown)) 
		return savedNavDocumentOnMouseDown(e);
	return true;
}

function navDocumentOnMouseUp(e){
	if(savedPSEditNav != null){
		if(CanCancelSavedPageSizeEdit(e))
			CancelSavedPageSizeEdit(e);
	}
	if(_isExists(savedNavDocumentOnMouseUp)) 
		return savedNavDocumentOnMouseUp(e);
	return true;
}

navWindowOnResize = function(e){
	if(savedPSEditNav != null)
		CancelSavedPageSizeEdit(e);
	if(_isExists(savedNavWindowOnResize)) 
		return savedNavWindowOnResize(e);
	return true;
}

var NavFirstLoad;
if(typeof(savedNavWindowOnLoad) == "undefined"){
	var __ASPxNavigatableCollection = null;
	var __ASPxDataNavigatorrCollection = null;
	var savedNavWindowOnLoad = window.onload;
	var savedNavDocumentOnMouseDown = null;
	var savedNavDocumentOnMouseUp = null;
	var savedNavWindowOnResize = null;
	NavFirstLoad = true;
}

window.onload = function(e){
	if(NavFirstLoad){
		savedNavDocumentOnMouseDown = window.document.onmousedown;
		window.document.onmousedown = navDocumentOnMouseDown;
		savedNavDocumentOnMouseUp = window.document.onmouseup;
		window.document.onmouseup = navDocumentOnMouseUp;
		savedNavWindowOnResize = window.onresize;
		window.onresize = navWindowOnResize;
		GetDataNavigatorCollection().Initialize(true);
		NavFirstLoad = false;
	}
	else
		window.setTimeout("GetDataNavigatorCollection().Initialize(false)", 0);

	if(_isExists(savedNavWindowOnLoad)) 
		return savedNavWindowOnLoad(e);
	return true;
}