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
function ASPxClientBarItem(owner, index, type, name, partId, visible){
	this.owner = owner;
	this.type = type;
	this.name = name;
	this.index = index;
	this.partId = partId;
	this.visible = visible;
	this.GetOwner = function(){
		return this.owner;
	}
	this.GetType = function(){
		return this.type;
	}
	this.GetName = function(){
		return this.name;
	}
	this.GetIndex = function(){
		return this.index;
	}
	this.GetVisible = function(){
		return this.visible;
	}
	this.SetVisible = function(visible){
		this.SetDisplay(visible);
		this.visible = visible;
		if(owner != null){
			owner.ReInitializeWidth();
			owner.SynchronizeItemsVisibility();
		}
	}
	
	this.GetElement = function(){
		return (owner != null) ? owner.GetButtonElement(this.partId, this.GetIndex()) : null;
	}
	this.GetCellElement = function(){
		if(owner != null){
			var btnsElement = owner.GetControlBtnsElement();
			return (btnsElement != null) ? btnsElement.cells[this.index] : null;
		}
		return null;
	}
	this.SetDisplay = function(display){
		var element = this.GetCellElement();
		if(element != null)
			_setElementDisplay(element, display);
	}
}
function ASPxClientBarStatusSection(owner, index, type, name, partId, visible, fixedWidth){
	this.inherit = ASPxClientBarItem;
	this.inherit(owner, index, type, name, partId, visible);
	this.fixedWidth = fixedWidth;
	this.GetText = function(){
		var sectionElement = this.GetElement();
		if(sectionElement != null){
			var sectionDataElement = _getChildById(sectionElement, "Text");
			if(sectionDataElement == null) 
				sectionDataElement = _getChildById(sectionElement, "Data");
			if(sectionDataElement != null) 
				return _getElementInnerText(sectionDataElement);
		}
		return "";
	}
	this.SetText = function(text){
		var sectionElement = this.GetElement();
		if(sectionElement != null && owner != null){
			if(!owner.OnBindStatusSection(sectionElement, this, text)){
				var sectionDataElement = _getChildById(sectionElement, "Text");
				if(sectionDataElement != null){
					if(text == ""){
						sectionDataElement.id = "Data";
						this.owner.UpdateStatusSections([this.partId]);
					}
					else
						_setElementInnerText(sectionDataElement, text);
				}
				else {
					sectionDataElement = _getChildById(sectionElement, "Data");
					if(sectionDataElement != null){
						if(text != ""){
							sectionDataElement.id = "Text";
							_setElementInnerText(sectionDataElement, text);
						}
					}
				}
			}
		}
	}
	
	this.GetElement = function(){
		return (owner != null) ? owner.GetSectionElement(this.partId, this.GetIndex()) : null;
	}
}
function ASPxClientDataNavigator(name, dataControllerName, navigatableName){
	this.inherit = ASPxClientDataNavigatorCore;
	this.inherit(name, dataControllerName, navigatableName);	

	this.barItems = new Array();
	this.barItemPartIdsIndexes = new Array();
	this.statusSectionsPartIds = ["SS", "CPS", "PCS", "VOPS", "TVS", "TRS", "RCS", "CS"];
			
	this.clientSideMode = true;
	this.processOnServer = false;
	this.textFormatStrings = [];
	this.tooltipFormatStrings = [];
	this.totalWidth = null;
	this.fixedWidth = null;
	this.newWidth = null;
	this.widthInitialized = false;

	this.pageIndexButtonCount = 0;
	this.pageIndexButtonsStartIndex = 0;
	this.pageIndexButtonsEndIndex = 0;
	this.pageIndexButtonsPrevStartIndex = 0;
	this.pageIndexButtonsPrevEndIndex = 0;
	
	this._lockUpdates = 0;
	this._endDataBatchUpdate = false;
	this._statusTextChanged = false;
	this._focusedChanged = false;
	this._recordCountChanged = false;
	this._dataModeChanged = false;
	this._firstVisibleIndexChanged = false;
	this._pageSizeChanged = false;
	this._rowCountChanged = false;
	this._visibleRowCountChanged = false;
	this._searchStateChanged = false;
	
	this.BeginUpdate = function(){
		this._lockUpdates ++;
	}
	
	this.EndUpdate = function(){
		this._lockUpdates --;
		if(this._lockUpdates == 0){
			if(this._endDataBatchUpdate)
				this.NavigatableEndDataBatchUpdate();
			if(this._statusTextChanged)
				this.NavigatableStatusTextChanged();
			if(this._focusedChanged)				
				this.NavigatableFocusedChanged();
			if(this._recordCountChanged)
				this.NavigatableRecordCountChanged();
			if(this._dataModeChanged)				
				this.NavigatableDataModeChanged();
			if(this._firstVisibleIndexChanged)	
				this.NavigatableFirstVisibleIndexChanged();
			if(this._pageSizeChanged)	
				this.NavigatablePageSizeChanged();
			if(this._rowCountChanged)
				this.NavigatableRowCountChanged();
			if(this._visibleRowCountChanged)	
				this.NavigatableVisibleRowCountChanged();
			if(this._searchStateChanged)
				this.NavigatableSearchStateChanged();
			this.ClearUpdateFlags();
		}
	}
	
	this.ClearUpdateFlags = function(){
		this._endDataBatchUpdate = false;
		this._statusTextChanged = false;
		this._focusedChanged = false;
		this._recordCountChanged = false;
		this._dataModeChanged = false;
		this._firstVisibleIndexChanged = false;
		this._pageSizeChanged = false;
		this._rowCountChanged = false;
		this._visibleRowCountChanged = false;
		this._searchStateChanged = false;
	}
	
	this.AddItems = function(items){
		for(var i = 0; i < items.length; i++){
			if(!_isExists(items[i].length)) continue;
			switch(items[i].length){
				case 5:
					this.AddBarItem(items[i][0], items[i][1], items[i][2], items[i][3], items[i][4]);
					break;
				case 6:
					this.AddBarStatusSection(items[i][0], items[i][1], items[i][2], items[i][3], items[i][4], items[i][5]);
					break;
			}
		}
	}
	this.AddBarItem = function(type, name, index, partId, visible){
		var barItem = new ASPxClientBarItem(this, index, type, name, partId, visible);
		this.barItems[index] = barItem;
		return barItem;
	}
	this.AddBarStatusSection = function(type, name, index, partId, visible, fixedWidth){
		var barItem = new ASPxClientBarStatusSection(this, index, type, name, partId, visible, fixedWidth);
		this.barItems[index] = barItem;
		return barItem;
	}
	this.GetBarItemCount = function (){
		return this.barItems.length;
	}
	this.GetBarItem = function (index){
		if(0 <= index && index < this.barItems.length)
			return this.barItems[index];
		return null;
	}
	this.GetBarItemByName = function (itemName){
		for(var i = 0; i < this.barItems.length; i ++) {
			var barItem = this.barItems[i];
			if(barItem != null && barItem.name == itemName)
				return barItem;
		}
		return null;
	}

	this.GetServerValidationPassed = function(){
		return this.dataController.serverValidationPassed;
	}
	this.GetDataPageSize = function(){
		return 1;
	}
	this.NavigatableEndDataBatchUpdate = function(){
		if(this._lockUpdates == 0){
			this.NavigatableStatusTextChanged();
			this.NavigatableFocusedChanged();
			this.NavigatableRecordCountChanged();
			this.NavigatableDataModeChanged();
			this.NavigatableFirstVisibleIndexChanged();
			this.NavigatableRowCountChanged();
			this.NavigatableVisibleRowCountChanged();
			
			this._statusTextChanged = false;
			this._focusedChanged = false;
			this._recordCountChanged = false;
			this._dataModeChanged = false;
			this._firstVisibleIndexChanged = false;
			this._rowCountChanged = false;
			this._vsibleRowCountChanged = false;
		}
		else{
			this._endDataBatchUpdate = true;
		}
	}	
	this.NavigatableStatusTextChanged = function(){
		if(this._lockUpdates == 0)
			this.UpdateStatusSections(["SS"]);
		else
			this._statusTextChanged = true;
	}
	this.NavigatableFocusedChanged = function(){
		if(this._lockUpdates == 0){
			if(this.navigatable != null && !this.navigatable.IsNavigatableEx())
				this.UpdateStatusSections(["CPS", "VOPS"]);
		}
		else{
			this._focusedChanged = true;
		}
	}
	this.NavigatableRecordCountChanged = function(){
		if(this._lockUpdates == 0)
			this.UpdateStatusSections(["RCS"]);
		else
			this._recordCountChanged = true;
	}
	this.NavigatableClientSideModeChanged = function(){
	}
	this.NavigatableDataModeChanged = function(){
		if(this._lockUpdates == 0)
			this.UpdateEditModeBtnsVisibility();
		else
			this._dataModeChanged = true;
	}
	this.NavigatableFirstVisibleIndexChanged = function(){
		if(this._lockUpdates == 0){
			this.UpdateStatusSections(["CPS", "VOPS"]);
			this.UpdateGoToPageEditors();
			this.UpdateSelectPageEditors();
			if(this.pageIndexButtonCount > 0)
				this.UpdatePageIndexButtons(false);
		}
		else{
			this._firstVisibleIndexChanged = true;
		}
	}
	this.NavigatablePageSizeChanged = function(){
		if(this._lockUpdates == 0){
			this.UpdateStatusSections(["CPS", "PCS", "VOPS"]);
			this.UpdatePageSizeEditors();
			this.UpdateGoToPageEditors();
			this.UpdatePageIndexButtons(false);
			this.UpdateSelectPageEditorsItems();
			this.UpdateSelectPageEditors();
		}
		else{
			this._pageSizeChanged = true;
		}
	}
	this.NavigatableRowCountChanged = function(){
		if(this._lockUpdates == 0)
			this.UpdateStatusSections(["PCS", "TRS"]);
		else
			this._rowCountChanged = true;
	}
	this.NavigatableVisibleRowCountChanged = function(){
		if(this._lockUpdates == 0){
			this.UpdateStatusSections(["CPS", "PCS", "TVS"]);
			this.UpdatePageIndexButtons(false);
			this.UpdateGoToPageEditors();
			this.UpdateSelectPageEditorsItems();
			this.UpdateSelectPageEditors();
		}
		else{
			this._visibleRowCountChanged = true;
		}
	}
	this.NavigatableSearchStateChanged = function(){
		if(this._lockUpdates == 0){
			this.UpdateSearchStringEditors();
			this.UpdateSearchColumnIndexEditor();
		}
		else{
			this._searchStateChanged = true;
		}
	}
	
	this.GetBarItemIndexCollection = function(partId){
		if(!_isExists(this.barItemPartIdsIndexes[partId]))
			this.CreateBarItemIndexCollection(partId);
		return this.barItemPartIdsIndexes[partId];
	}
	this.CreateBarItemIndexCollection = function(partId){
		this.barItemPartIdsIndexes[partId] = new Array();
		for(var i = 0; i < this.GetBarItemCount(); i ++){
			if(_isExists(this.GetBarItem(i)) && this.GetBarItem(i).partId == partId)
				this.barItemPartIdsIndexes[partId].push(i);
		}
	}
	this.UpdateEditModeBtnVisibility = function(partId, visible){
		var collection = this.GetBarItemIndexCollection(partId);
		for(var i = 0; i < collection.length; i ++){
			var index = collection[i];
			var btnElement = this.GetButtonElement(partId, index);
			if(btnElement != null)
				this.SetButtonDisplay(btnElement, visible);
		}
	}
	this.UpdateEditModeBtnsVisibility = function(){
		if(this.navigatable == null) return;
		
		var dataMode = this.navigatable.GetDataMode();
		var visible = dataMode == "Edit" || dataMode == "Insert" || dataMode == "Append";
		this.UpdateEditModeBtnVisibility("NPCB", visible);
		this.UpdateEditModeBtnVisibility("NCEB", visible);
	}
	this.UpdatePageSizeEditors = function(){
		if(this.navigatable == null) return;
		
		var collection = this.GetBarItemIndexCollection("NCPSB");
		for(var i = 0; i < collection.length; i ++){
			var index = collection[i];
			var editorElement = this.GetPageSizeEditorElement(index);
			if(editorElement != null)
				editorElement.value = this.navigatable.GetPageSize();
		}
	}
	this.CreatePageIndexButtons = function(index, startBtnElement){
		if(this.navigatable == null) return;
		
		var btnsContainer = _getParentByTagName(startBtnElement, "TR");
		var btnsCellCollection = _getChildNodes(btnsContainer);
		var startBtnElementCell = _getParentNode(startBtnElement);
		var startBtnElementIndex = array_indexOf(btnsCellCollection, startBtnElementCell);
		var btnCount = 0;
		for(var j = this.pageIndexButtonsStartIndex; j <= this.pageIndexButtonsEndIndex; j ++){
			var button = startBtnElementCell.cloneNode(true);
			if(button != null){
				var buttonTable = _getChildById(button, this.name + "NPIB" + index);
				if(buttonTable != null){
					buttonTable.id = this.name + "NPIB" + index + "B" + j;
					buttonTable.onclick = new Function("OnDNGoToPageIndCl(null, \"" + this.name + "\", " + index + ", " + j + ");");
					this.SetButtonDisplay(buttonTable, true);
					var buttonTd = _getFirstChild(_getFirstChild(_getFirstChild(buttonTable)));
					if(buttonTd != null){
						var textFormat = _isExists(this.textFormatStrings[index]) ? this.textFormatStrings[index] : "{0}";
						var text = FormatValue((j + 1), textFormat, "Int16");
						var tooltipFormat = _isExists(this.tooltipFormatStrings[index]) ? this.tooltipFormatStrings[index] : "Page {0}";
						var tooltip = FormatValue((j + 1), tooltipFormat, "Int16");
						var width = new ASPxClientUnit(_getElementWidth(button), "px");
						var height = new ASPxClientUnit(_getElementHeight(button), "px");
						if(!this.OnCustomRenderPageIndexButton(_getParentNode(buttonTable), this.barItems[index], width, height, btnCount, text, tooltip, false)){
							buttonTable.title = tooltip;
							_setElementInnerText(buttonTd, text);								
						}
					}
				}
				var btnCell = btnsCellCollection[startBtnElementIndex + btnCount + 1];
				if(btnCell != null)
					btnsContainer.insertBefore(button, btnCell);
				else
					btnsContainer.appendChild(button);
			}
			btnCount ++;
		}
	}
	this.DestroyPageIndexButtons = function(index, initialize){
		if(this.navigatable == null) return;
		
		var startIndex = initialize ? 0 : ((this.pageIndexButtonsPrevStartIndex != 0) ? this.pageIndexButtonsPrevStartIndex : 0);
		var endIndex = initialize ? this.navigatable.GetRowCount() : ((this.pageIndexButtonsPrevEndIndex != 0) ? this.pageIndexButtonsPrevEndIndex : this.navigatable.GetPageCount() - 1);
		for(var j = startIndex; j <= endIndex; j ++){
			var btnElement = this.GetPageIndexBtnElement(index, j);
			if(btnElement != null){
				btnElement = _getParentNode(btnElement);
				if(btnElement != null) _removeElement(btnElement);
			}
		}
	}
	this.UpdatePageIndexButtonsIndexes = function(){
		if(this.navigatable == null) return;
		
		if(this.pageIndexButtonCount > 0){
			var halfCount = Math.floor(this.pageIndexButtonCount / 2);
			var odd = this.pageIndexButtonCount % 2 > 0;
			this.pageIndexButtonsStartIndex = odd ? this.navigatable.GetCurrentPageIndex() - halfCount : this.navigatable.GetCurrentPageIndex() - halfCount + 1;
			this.pageIndexButtonsEndIndex = this.navigatable.GetCurrentPageIndex() + halfCount;
			if(this.pageIndexButtonsStartIndex < 0){
				var delta = -this.pageIndexButtonsStartIndex;
				this.pageIndexButtonsStartIndex += delta;
				this.pageIndexButtonsEndIndex += delta;
			}
			if(this.pageIndexButtonsEndIndex > this.navigatable.GetPageCount() - 1){
				var delta = this.pageIndexButtonsEndIndex - (this.navigatable.GetPageCount() - 1);
				this.pageIndexButtonsStartIndex -= delta;
				this.pageIndexButtonsEndIndex -= delta;
			}
		}
		else{
			this.pageIndexButtonsStartIndex = 0;
			this.pageIndexButtonsEndIndex = this.navigatable.GetPageCount() - 1;
		}
		if(this.pageIndexButtonsStartIndex < 0)
			this.pageIndexButtonsStartIndex = 0;
		if(this.pageIndexButtonsEndIndex < 0)
			this.pageIndexButtonsEndIndex = 0;
		
	}
	this.UpdatePageIndexButtons = function(initialize){
		if(this.navigatable == null || !this.navigatable.IsNavigatableEx()) return;
		
		this.UpdatePageIndexButtonsIndexes();
		if(this.pageIndexButtonsPrevStartIndex != this.pageIndexButtonsStartIndex ||
			this.pageIndexButtonsPrevEndIndex != this.pageIndexButtonsEndIndex || initialize){
			var collection = this.GetBarItemIndexCollection("NPIB");
			for(var i = 0; i < collection.length; i ++){
				var index = collection[i];
				var startBtnElement = this.GetPageIndexStartBtnElement(index);
				if(startBtnElement != null){
					this.DestroyPageIndexButtons(index, initialize);
					this.CreatePageIndexButtons(index, startBtnElement);
				}
				var lastBtnElement = this.GetButtonIndexBtnElement("NPIB", index, this.pageIndexButtonsEndIndex);
				if(lastBtnElement != null) _getParentNode(lastBtnElement).style.paddingRight = 0;
			}
			this.pageIndexButtonsPrevStartIndex = this.pageIndexButtonsStartIndex;
			this.pageIndexButtonsPrevEndIndex = this.pageIndexButtonsEndIndex;
		}
	}
	this.UpdateSelectPageEditors = function(){
		if(this.navigatable == null) return;
		
		var collection = this.GetBarItemIndexCollection("NSPB");
		for(var i = 0; i < collection.length; i ++){
			var index = collection[i];
			var LFListBox = this.GetSelectPageLFListBox(index);
			if(LFListBox != null)
				LFListBox.SetSelectedIndex(this.navigatable.GetCurrentPageIndex());
			else{
				editorElement = this.GetSelectPageValueElement(index);
				if(editorElement != null) 
					editorElement.selectedIndex = this.navigatable.GetCurrentPageIndex();
			}
		}
	}
	this.UpdateSelectPageEditorsItems = function(){
		if(this.navigatable == null) return;
		
		var collection = this.GetBarItemIndexCollection("NSPB");
		for(var i = 0; i < collection.length; i ++){
			var index = collection[i];
			var LFListBox = this.GetSelectPageLFListBox(index);
			if(LFListBox != null){ 
				LFListBox.BeginUpdate();
				while(LFListBox.GetItemCount() > this.navigatable.GetPageCount())
					LFListBox.RemoveItem(LFListBox.GetItemCount() - 1, false);
				while(LFListBox.GetItemCount() < this.navigatable.GetPageCount()){
					var itemFormat = _isExists(this.textFormatStrings[index]) ? this.textFormatStrings[index] : "Page {0}";
					var itemText = FormatValue(LFListBox.GetItemCount() + 1, itemFormat, "Int16");
					LFListBox.AddItem(LFListBox.GetItemCount(), itemText, "");
				}
				LFListBox.EndUpdate();
			}
			else{
				editorElement = this.GetSelectPageValueElement(index);
				if(editorElement != null){
					var optionCollecion = _getChildNodes(editorElement);
					while(optionCollecion.length > 0)
						_removeElement(optionCollecion[optionCollecion.length - 1]);
					while(optionCollecion.length < this.navigatable.GetPageCount()){
						var itemFormat = _isExists(this.textFormatStrings[index]) ? this.textFormatStrings[index] : "Page {0}";
						var itemText = FormatValue(optionCollecion.length + 1, itemFormat, "Int16");
						var option = document.createElement("OPTION");
						option.value = optionCollecion.length;
						_setElementInnerText(option, itemText);
						if(optionCollecion.length == this.navigatable.GetCurrentPageIndex())
							option.selected = true;
						editorElement.appendChild(option);
					}
				}
			}
		}
	}
	this.UpdateGoToPageEditors = function(){
		if(this.navigatable == null) return;
		
		var collection = this.GetBarItemIndexCollection("NGTPB");
		for(var i = 0; i < collection.length; i ++){
			var index = collection[i];
			var editorElement = this.GetGoToPageEditorElement(index);
			if(editorElement != null)
				editorElement.value = this.navigatable.GetCurrentPageIndex() + 1;
		}
	}
	this.CustomRenderButtons = function(partIds){
		if(!this.CustomRenderButton.IsEmpty()){
			for(var j = 0; j < partIds.length; j ++){
				var partId = partIds[j];
				var collection = this.GetBarItemIndexCollection(partId);
				for(var i = 0; i < collection.length; i ++){
					var index = collection[i];
					var buttonElement = this.GetButtonElement(partId, index);
					if(buttonElement != null){
						var width = new ASPxClientUnit(_getElementWidth(buttonElement), "px");
						var height = new ASPxClientUnit(_getElementHeight(buttonElement), "px");
						this.OnCustomRenderButton(_getParentNode(buttonElement), this.barItems[index], width, height, false);
					}
				}
			}
		}
	}
	this.CustomRenderStatusSections = function(partIds){
		if(!this.CustomRenderStatusSection.IsEmpty()){
			for(var j = 0; j < partIds.length; j ++){
				var partId = partIds[j];
				var collection = this.GetBarItemIndexCollection(partId);
				for(var i = 0; i < collection.length; i ++){
					var index = collection[i];
					var sectionElement = this.GetSectionElement(partId, index);
					if(sectionElement != null){
						var width = new ASPxClientUnit(_getElementWidth(sectionElement), "px");
						var height = new ASPxClientUnit(_getElementHeight(sectionElement), "px");
						this.OnCustomRenderStatusSection(sectionElement, this.barItems[index], width, height, false);
					}
				}
			}
		}
	}
	this.GetStatusSectionText = function(partId){
		switch(partId){
			case "SS": return (this.navigatable != null) ? this.navigatable.GetStatusText() : "Ok"; 
			case "CPS": return (this.navigatable != null) ? this.navigatable.GetCurrentPageIndex() + 1 : "1"; 
			case "PCS": return (this.navigatable != null) ? this.navigatable.GetPageCount() : "1"; 
			case "VOPS": return (this.navigatable != null) ? (this.navigatable.GetFirstVisibleIndex() + 1) + " - " + (this.navigatable.GetLastVisibleIndex() + 1) : "1 - 1"; 
			case "TVS": return (this.navigatable != null) ? this.navigatable.GetVisibleRowCount() : "1"; 
			case "TRS": return (this.navigatable != null) ? this.navigatable.GetRowCount() : "1"; 
			case "RCS": return (this.navigatable != null) ? this.navigatable.GetRecordCount() : "1"; 
			default: return "";
		}
	}							
	this.UpdateStatusSections = function(partIds){
		for(var j = 0; j < partIds.length; j ++){
			var partId = partIds[j];
			var collection = this.GetBarItemIndexCollection(partId);
			for(var i = 0; i < collection.length; i ++){
				var index = collection[i];
				var sectionElement = this.GetSectionElement(partId, index);
				var text = this.GetStatusSectionText(partId);
				if(!this.OnBindStatusSection(sectionElement, this.barItems[index], text)){
					var sectionDataElement = _getChildById(sectionElement, "Data");
					if(sectionDataElement != null) _setElementInnerText(sectionDataElement, text);
				}
			}
		}
	}
	this.UpdateSearchStringEditors = function(){
		if(this.navigatable == null) return;
		
		var collection = this.GetBarItemIndexCollection("NSRB");
		for(var i = 0; i < collection.length; i ++){
			var index = collection[i];
			var editorElement = this.GetSearchedStringEditorElement(index);
			if(editorElement != null)
				editorElement.value = this.navigatable.GetCurrentSearchString();
		}
	}
	this.UpdateSearchColumnIndexEditor = function(){
		if(this.navigatable == null) return;
		
		var collection = this.GetBarItemIndexCollection("NSRB");
		for(var i = 0; i < collection.length; i ++){
			var index = collection[i];
			var editorElement = this.GetSearchColumnIndexValueElement(index);
			if(editorElement != null && editorElement.tagName == "SELECT"){
				var itemIndex = this.navigatable.GetCurrentSearchColumnIndex();
				if(itemIndex >= 0)
					editorElement.value = itemIndex;
				else
					editorElement.selectedIndex = 0;
			}
			else{
				var LFListBox = this.GetSearchColumnIndexLFListBox(index);
				if(LFListBox != null){
					var itemIndex = this.navigatable.GetCurrentSearchColumnIndex();
					if(itemIndex < 0) itemIndex = 0;
					LFListBox.SetSelectedIndex(itemIndex);
				}
			}
		}
	}
	this.GetFixedWidth = function(){
		var widthValue = 0;
		for(var i = 0; i < this.GetBarItemCount(); i ++){
			var barItem = this.GetBarItem(i);
			if(!barItem.visible) continue;
			if(barItem.fixedWidth == null) continue;
			widthValue += barItem.fixedWidth.value;
		}
		return new ASPxClientUnit(widthValue, this.fixedWidth.type);
	}
	this.CanUpdateWidth = function(width){
		return (this.totalWidth != null && this.fixedWidth != null && this.totalWidth.type == width.type);
	}
	this.UpdateWidth = function(width){
		this.CheckInitialized();
		if(!this.CanUpdateWidth(width)) return;
		
		var partIds = ["SS", "CPS", "PCS", "VOPS", "TVS", "TRS", "RCS", "CS"];
		var fixedWidth = this.GetFixedWidth();
		var widthRatio = (width.value - (this.totalWidth.value - this.fixedWidth.value)) / fixedWidth.value;
		for(var j = 0; j < partIds.length; j ++){
			var partId = partIds[j];
			var collection = this.GetBarItemIndexCollection(partId);
			for(var i = 0; i < collection.length; i ++){
				var index = collection[i];
				var barItem = this.GetBarItem(index);
				if(_isExists(barItem) && barItem.visible){
					var sectionElement = this.GetSectionElement(partId, index);
					if(sectionElement != null){
						if(barItem.fixedWidth == null) continue;
						
						var sectionWidthValue = Math.floor(barItem.fixedWidth.value * widthRatio);
						if(sectionWidthValue < 0) sectionWidthValue = 0;
						var sectionWidth = new ASPxClientUnit(sectionWidthValue, barItem.fixedWidth.type);
						sectionElement.style.width = sectionWidth.ToString();
						var sectionStyle = ASPxStyle.GetStyleByElement(sectionElement);
						var sectionElementWidth = (sectionStyle != null) ? sectionStyle.GetClientWidth(sectionWidth) : sectionWidth;
						var sectionElementDiv = _getChildByTagName(sectionElement, "DIV", 0);
						if(sectionElementDiv != null)
							sectionElementDiv.style.width = sectionElementWidth.ToString();
						var sectionElementSpan = _getChildByTagName(sectionElement, "SPAN", 0);
						if(sectionElementSpan != null)
							sectionElementSpan.style.width = sectionElementWidth.ToString();
					}
				}
			}
		}	
		var controlElement = this.GetControlElement();
		if(controlElement != null)
			_setElementWidth(controlElement, width.ToString());
		this.newWidth = width;
	}
	this.InitializeWidth = function(){
		if(!this.widthInitialized){
			this.widthInitialized = true;
			this.newWidth = this.totalWidth;
			this.ReInitializeWidth();
		}
	}
	this.ReInitializeWidth = function(){
		this.UpdateWidth(this.newWidth);
	}
	this.SynchronizeItemsVisibility = function(){
		var input = _getHiddenInput(this.name + "ItemsVisibility");
		if(input != null){
			var stateStr = "";
			for(var i = 0; i < this.GetBarItemCount(); i ++){
				if(!this.GetBarItem(i).GetVisible())
					stateStr += "0";
				if(i < this.GetBarItemCount() - 1)
					stateStr += ";";
			}
			input.value = stateStr;
		}
	}
	this.Init = new ASPxClientEvent();	
	this.ButtonClick = new ASPxClientEvent();
	this.CustomRenderButton = new ASPxClientEvent();
	this.CustomRenderPageIndexButton = new ASPxClientEvent();
	this.CustomRenderStatusSection = new ASPxClientEvent();
	this.BindStatusSection = new ASPxClientEvent();

	this.OnButtonClick = function(barItem, processOnServer){
		if(!this.ButtonClick.IsEmpty()){
			var args = new ASPxClientBarItemEventArgs(barItem, processOnServer);
			this.ButtonClick.FireEvent(this.GetEventSender(), args);
			return args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client");
		}
		return processOnServer ? "Server" : "Client";
	}
	this.OnCustomRenderButton = function(htmlElement, barItem, width, height, beforeDefaultRender){
		if(this.navigatable != null && !this.standAlone)
			return this.navigatable.Navigatable_CustomRenderBarBtn(htmlElement, barItem, width, height, beforeDefaultRender);
		else if(!this.CustomRenderButton.IsEmpty()){
			var args = new ASPxClientBarCustomRenderEventArgs(htmlElement, barItem, width, height, beforeDefaultRender);
			this.CustomRenderButton.FireEvent(this.GetEventSender(), args);
			return args.handled;
		}
		return false;
	}
	this.OnCustomRenderPageIndexButton = function(htmlElement, barItem, width, height, pageIndex, text, tooltip, beforeDefaultRender){
		if(this.navigatable != null && !this.standAlone)
			return this.navigatable.Navigatable_CustomRenderPageIndexBtn(htmlElement, barItem, width, height, pageIndex, text, tooltip, beforeDefaultRender);
		else if(!this.CustomRenderPageIndexButton.IsEmpty()){
			var args = new ASPxClientBarCustomRenderPageIndexButtonEventArgs(htmlElement, barItem, width, height, pageIndex, text, tooltip, beforeDefaultRender);
			this.CustomRenderPageIndexButton.FireEvent(this.GetEventSender(), args);
			return args.handled;
		}
		return false;
	}
	this.OnCustomRenderStatusSection = function(htmlElement, barItem, width, height, beforeDefaultRender){
		if(this.navigatable != null && !this.standAlone)
			return this.navigatable.Navigatable_CustomRenderStatusBarSection(htmlElement, barItem, width, height, beforeDefaultRender);
		else if(!this.CustomRenderStatusSection.IsEmpty()){
			var args = new ASPxClientBarCustomRenderEventArgs(htmlElement, barItem, width, height, beforeDefaultRender);
			this.CustomRenderStatusSection.FireEvent(this.GetEventSender(), args);
			return args.handled;
		}
		return false;
	}
	this.OnBindStatusSection = function(htmlElement, barItem, text){
		if(this.navigatable != null && !this.standAlone)
			return this.navigatable.Navigatable_BindStatusBarSection(htmlElement, barItem, text);
		else if(!this.BindStatusSection.IsEmpty()){
			var args = new ASPxClientBarBindStatusSectionEventArgs(htmlElement, barItem, text);
			this.BindStatusSection.FireEvent(this.GetEventSender(), args);
			return args.handled;
		}
		return false;
	}
	
	this.baseInitializeControl = this.InitializeControl;
	this.InitializeControl = function (){
		this.InitializeWidth();		
		this.baseInitializeControl();
		this.CustomRenderStatusSections(["SS", "CPS", "PCS", "VOPS", "TVS", "TRS", "RCS", "CS"]);
		this.CustomRenderButtons(["NFB", "NPPB", "NPB", "NCPSB", "NNB", "NNPB", "NLB", "NGTPB", "NSPB", "NIB", "NAB", "NEB", "NDB", "NRB", "NPCB", "NCEB", "NSRB", "NCB"]);
		if(!this.processOnServer){
			this.UpdateStatusSections(["SS", "CPS", "PCS", "VOPS", "TVS", "TRS", "RCS"]);
			this.UpdatePageIndexButtons(true);
		}
	}
	this.OnInit = function(){
		if(!this.Init.IsEmpty()){
			var eventArgs = new ASPxClientEventArgs();
			this.Init.FireEvent(this.GetEventSender(), eventArgs);		
		}
	}
}
ASPxClientDataNavigator.GetDataNavigatorCollection = function(){
	return GetDataNavigatorCollection();
}
function ASPxClientBarItemEventArgs(barItem, processOnServer){
	this.inherit = ASPxClientHandledEventArgs;
	this.inherit();
	this.barItem = barItem;
	this.processOnServer = processOnServer;
}
function ASPxClientBarCustomRenderEventArgs(htmlElement, barItem, width, height, beforeDefaultRender){
	this.inherit = ASPxClientHandledEventArgs;
	this.inherit();
	this.htmlElement = htmlElement;
	this.barItem = barItem;
	this.width = width;
	this.height = height;
	this.beforeDefaultRender = beforeDefaultRender;	
}
function ASPxClientBarCustomRenderPageIndexButtonEventArgs(htmlElement, barItem, width, height, pageIndex, text, toolTip, beforeDefaultRender){
	this.inherit = ASPxClientBarCustomRenderEventArgs;
	this.inherit(htmlElement, barItem, width, height, beforeDefaultRender);
	this.pageIndex = pageIndex;
	this.text = text;
	this.toolTip = toolTip;
}
function ASPxClientBarBindStatusSectionEventArgs(htmlElement, barItem, text){
	this.inherit = ASPxClientHandledEventArgs;
	this.inherit();
	this.htmlElement = htmlElement;
	this.barItem = barItem;
	this.text = text;	
}