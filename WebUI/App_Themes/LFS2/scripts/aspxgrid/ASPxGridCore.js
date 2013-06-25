
function ASPxClientGridCore(name){
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	

	this.scriptName = name;
	this.clientSideMode = false;
	this.processOnServer = true;
	this.enableCallBacks = false;
	this.initializationMode	= "Automatic";
	this.checkInitializationMode = true;
	this.enabled = true;
	this.enableKeyboardProcessing = true;
	this.focused = false;
	this.pageSize = 0;	
	this.rowCount = 0;		
	this.columns = new Array();
	this.internalColumns = new Array(); 
	this.groupColumns = new Array();	
	this.focusedTRIndex = 0;
	this.firstTRIndex = 0;
	this.focusedTR = null;
	this.childFocusedControl = null;			
	this.focusedColumnIndex = -1;
	this.focusedSearchEditorIndex = -1;
	this.rowsExpanded = null;
	this.rowsSelected = null;	
	this.selectedRows = null;
	this.addedSelectedRows = null;
	this.removedSelectedRows = null;
	this.selectionCleared = false;
	this.firstGroupIndentOffset = 0;
	this.controlMode = "Browse";
	this.multiSelection = false;
	this.cellSelection = false;		
	this.showPreview = false;
	this._lockScrollBars = false;
	this.resizeTimer = -1;	
	
	this.showArrowsOnDragging = true;
	this.postBackOnFocusedChanged = false;
	this.enableRowDblClick = true;
	this.enableFocusedRowClick = true;
	this.postBackOnKeyPress = false;
	
	this.readOnly = false;
	this.allowInsert = true;
	this.allowAppend = true;
	this.allowEdit = true;
	this.allowDelete = true;
	this.confirmDelete = true;
	this.confirmDeleteMessage = "Delete record?";
	this.postBackOnPostingDataChanges = true;
	this.clientSideExpanding = false;
	this.directRender = false;
	
	this.dataMode = "Browse";
	this.isChangingPageSize = false;	
	
	this.enableLoadingText = true;
	this.loadingText = "Loading...";
	
	this.arrowImgWidth = 11;			
	this.imgBBPost = _getDefaultImagePath() + "bbPost.gif";
	this.imgBBChangePageSize = _getDefaultImagePath() + "bbPgsize.gif";			
	this.headerStyle = ASPxStyle.CreateStyle();
	this.headerDraggedStyle = ASPxStyle.CreateStyle();
	this.groupedHeaderStyle = ASPxStyle.CreateStyle();
		
	this.cellPadding = 0;
	this.cellSpacing = 0;
	this.innerBorderWidth = 1;	
	this.width = new ASPxClientUnit(0, "");
	this.itemHeight = new ASPxClientUnit(20, "px");
	this.previewHeight = new ASPxClientUnit(40, "px");
	this.rowBtnWidth = new ASPxClientUnit(20, "px");
	this.indicatorWidth = new ASPxClientUnit(15, "px");
	this.expandBtnWidth = new ASPxClientUnit(15, "px");
	this.expandBtnHeight = new ASPxClientUnit(15, "px");
	this.groupRowIndent = new ASPxClientUnit(20, "px");	
	this.totalColumnsWidth = 0;
	
	this.originalColumnsWidth = 0;
	this.originalColumnWidths = null;
	this.newColumnWidths = null;
	this.previewWidth = 0;
	this.actualGridWidth = 0;
	this.groupItemTextCellWidth = 0;
	
	this.useItemTemplate = false;
	this.useEditItemTemplate = false;
	this.useHeaderTemplate = false;
	this.useFooterTemplate = false;
	this.useGroupItemTemplate = false;
	this.useRowBtnTemplate = false;
	this.useBarBtnTemplate = false;
	this.useExpandBtnTemplate = false;
	this.useStatusBarSectionTemplate = false;
	this.useTitleTemplate = false;
	this.useGroupPanelTemplate = false;	
	this.usePreviewTemplate = false;
	
	this.htmlRender = new ASPxGridRenderCore(this);
	this.GotFocus = new ASPxClientEvent();
	this.LostFocus = new ASPxClientEvent();
	this.KeyDown = new ASPxClientEvent();
	this.KeyUp = new ASPxClientEvent();
	this.BindRowBtn = new ASPxClientEvent();
	this.BindExpandBtn = new ASPxClientEvent();
	this.CustomRenderSelection = new ASPxClientEvent();		
	
	this.AddColumn = function(index, type, fieldIndex, visibleIndex, isInternal){
		var column = new ASPxClientGridColumnCore(this, index, type, fieldIndex, visibleIndex);
		if(index > -1)
			this.columns[index] = column;
		if(isInternal)
			this.internalColumns.push(column);
		return column;
	}
	
	this.OnGetFocus = function(){
		__setFocusedControl(this);
		if(!this.GotFocus.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.GotFocus.FireEvent(this, args);
		}
	}
	this.OnLostFocus = function(){
		if(__getFocusedControl() == this && !_getIsParent(this.htmlRender.GetHtmlFrameTable(), document.activeElement)){
			__setFocusedControl(null);
			this.SetChildFocusedControl(null);
			if(!this.LostFocus.IsEmpty()){
				var args = new ASPxClientEventArgs();
				this.LostFocus.FireEvent(this, args);
			}
		}
	}
	this.OnMouseUp = function(evt){
		if(this.enabled && (!this.IsEditMode() || __getFocusedControl() == null || !__getFocusedControl().IsMouseInControl(evt))){
			if(firefox)
				window.setTimeout("OnGFocusControl(\"" + this.name + "\")", 0);
			else
				this.FocusControl();
			if(this.childFocusedControl != null && !this.childFocusedControl.IsMouseInControl(evt))
				this.SetChildFocusedControl(null);
		}
	}
	this.Focus = function(){
		if(this.enabled){
			if(_isExists(document.activeElement))
				document.activeElement.blur();
			this.FocusControl();
		}
	}
	this.FocusColumn = function(columnIndex){
		this.FocusGrid();
		this.FocusEditor(columnIndex);
	}	
	this.FocusControl = function(){
		this.OnGetFocus();
	}
	this.DoServerCustomAction = function(parameters){
		this.CustomActionCore(null, "", parameters, "0", true);
	}
	
	this.CheckEditorsInitialized = function(){
		if(_isFunctionType(typeof(GetEditorCollection)))
			GetEditorCollection().CheckInitialized();
	}
	this.InitializeControl = function(){
		this.CheckEditorsInitialized();		
		for(var i = 0; i < this.columns.length; i ++){
			var column = this.columns[i];
			if(column.groupIndex > -1)
				this.groupColumns[column.groupIndex] = column;
		}
		if(this.focused)
			this.FocusControl();
		if(!this.clientSideMode){
			if(this.multiSelection)
				this.InitializeSelection();
			this.InitializeFocusing();
		}
	}	
	this.InitializeControlRender = function(){
		if(!this.clientSideMode && this.focusedTR != null)
			this.htmlRender.CorrectScrollersPos(this.focusedTR);
		if(this.htmlRender.IsScrollBarShown())
			this.htmlRender.UpdateScrollBars(false);
		if(this.width.type == "%")
			this.SynchronizeTotalWidth();
		else{
			if(this.HasEmptyWidthColumns() || !this.CheckActualColumnWidths())
				this.SynchronizeActualWidth();
		}
	}
	
	this.IsDisplayed = function(){
		return this.htmlRender.IsGridDisplayed();
	}
	
	this.GetCellPadding = function(){
		return this.cellPadding;
	}
	this.GetCellSpacing = function(){
		return this.cellSpacing;
	}
	
	this.GetInnerBorderWidth = function(){
		return this.innerBorderWidth;
	}
	this.GetItemHeight = function(){
		return this.itemHeight;
	}
	this.GetPreviewHeight = function(){
		return this.previewHeight;
	}
		
	this.GetLeftRowBtnColumnsOffset = function(){
		var columnCount = this.internalColumns.length;
		var rowBtnColumnsBeginPos = 0;
		while(rowBtnColumnsBeginPos < columnCount && (this.internalColumns[rowBtnColumnsBeginPos].type == "IndicatorColumn" || this.internalColumns[rowBtnColumnsBeginPos].type == "RowBtnColumn"))
			rowBtnColumnsBeginPos ++;
		return rowBtnColumnsBeginPos;
	}

	this.GetRightRowBtnColumnsOffset = function(){
		var rowBtnColumnsEndPos = this.internalColumns.length - 1;
		while(rowBtnColumnsEndPos > 0 && this.internalColumns[rowBtnColumnsEndPos].type == "RowBtnColumn")
			rowBtnColumnsEndPos --;	
		return rowBtnColumnsEndPos;
	}

	this.GetFocusedColumn = function (){
		if(this.focusedColumnIndex >= 0)
			return this.columns[this.focusedColumnIndex];
		return null;
	}

	this.GetServerValidationPassed = function(){
		return true;
	}
	this.GetDataMode = function(){
		return this.dataMode;
	}
	this.IsEditMode = function(){
		return this.GetDataMode() == "Edit" || this.GetDataMode() == "Insert" || this.GetDataMode() == "Append";
	}
	this.IsInsertMode = function(){
		return this.GetDataMode() == "Insert" || this.GetDataMode() == "Append";
	}

	this.CheckPostBackOnPostingDataChanges = function(){
		return (this.GetDataMode() != "Browse") && this.postBackOnPostingDataChanges;
	}
	
	this.GetColumnInternalIndex = function(column){
		return array_indexOf(this.internalColumns, column);
	}
	
	this.SynchronizeColumnProperties = function (column){
		var ret = "Width:" + column.width.ToString();
		if(this.enableCallBacks && !this.clientSideMode)
			ret += "~VisibleIndexInternal:" + column.visibleIndex + "~SortingOrderInternal:" + column.sortingOrder + "~SortingIndexInternal:" + column.sortingIndex + "~GroupIndexInternal:" + column.groupIndex + "~SavedVisibleIndex:" + column.savedVisibleIndex;
		return ret;
	}

	this.SynchronizeColumns = function (){
		var str = "";
		for(var i = 0; i < this.columns.length; i ++){
			str += this.SynchronizeColumnProperties(this.columns[i]) + ";";
		}
		_getHiddenInput(this.name + "Columns").value = str;
	}

	this.InitializeHScrollerPos = function(pos){	
		var scroller = this.htmlRender.GetHtmlScroller();
		if(scroller != null) scroller.scrollLeft = pos;
	}
	this.InitializeVScrollerPos = function(pos){	
		var scroller = this.htmlRender.GetHtmlScroller();
		if(scroller != null) scroller.scrollTop = pos;
	}
	this.SynchronizeScrollerPos = function(pos){	
		var scroller = this.htmlRender.GetHtmlScroller();
		if(scroller != null){
			var scrollLeftInput = _getHiddenInput(this.name + "ScrollLeft");
			if(scrollLeftInput != null)
				scrollLeftInput.value = scroller.scrollLeft;
			var scrollTopInput = _getHiddenInput(this.name + "ScrollTop");
			if(scrollTopInput != null)
				scrollTopInput.value = scroller.scrollTop;
		}
	}
	
	this.InitializeFocusing = function(){
		var focusedRowIndexElement = _getHiddenInput(this.name + "FocusedRow");
		var focusedRowIndex = (focusedRowIndexElement != null) ? focusedRowIndexElement.value : "";
		var tr = (focusedRowIndex != "") ? _getElementById(focusedRowIndex) : null;
		if(tr != null)
			this.MoveToTR(tr, this.focusedColumnIndex, false, false, false);
	}
	this.InitializeSelection = function(){	
		this.addedSelectedRows = new Array();
		this.removedSelectedRows = new Array();	
		for(var i = 0; i < this.selectedRows.length; i ++){
			var tr = this.GetChildById(this.selectedRows[i]);
			if(tr != null)
				this.InvertRowSelection(tr, false, false, false);
		}
		this.FillSelectedInput();
	}
	
	this.GetChildById = function(trId){
		var htmlFrameTable = this.htmlRender.GetHtmlFrameTable();
		if(htmlFrameTable != null)
			return _getChildById(htmlFrameTable, trId);
		return null;
	}
	
	this.OnBindRowBtn = function(td, rowBtn, img, showPreview){
		var eventArgs = new ASPxClientGridCustomRenderRowBtnEventArgs(td, this.internalColumns[0], rowBtn, false, this.indicatorWidth, !showPreview ? this.itemHeight : this.itemHeight.Add(this.previewHeight), img);
		this.BindRowBtn.FireEvent(this, eventArgs);
		return eventArgs.handled;
	}
	
		
	this.OnBindExpandBtn = function(td, rowExpanded){
		var eventArgs = new ASPxClientGridCustomRenderExpandBtnEventArgs(td, rowExpanded, this.expandBtnWidth, this.expandBtnHeight);
		this.BindExpandBtn.FireEvent(this, eventArgs);
		return eventArgs.handled;
	}
	
	this.OnCustomRenderSelection = function(td, column, isGroupRow, selected){
		var handled = false;
		if(!column.CustomRenderSelection.IsEmpty() || !this.CustomRenderSelection.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderSelectionEventArgs(td, column, isGroupRow, selected);
			column.CustomRenderSelection.FireEvent(column, eventArgs);			
			if(!eventArgs.handled)
				this.CustomRenderSelection.FireEvent(this, eventArgs);
			handled = eventArgs.handled;
		}
		return handled;
	}			

	this.InvertRowSelection = function(tr, value, applyValue, synchronize){
		var rowIndex = tr.rowIndex - this.firstTRIndex;	
		if(!applyValue || this.rowsSelected[rowIndex] != value){
			this.rowsSelected[rowIndex] = !this.rowsSelected[rowIndex];
			if(this.rowsSelected[rowIndex]){		
				if(synchronize){
					if(array_indexOf(this.selectedRows, tr.id) == -1)
						this.addedSelectedRows.push(tr.id);
					else if(this.selectionCleared && array_indexOf(this.addedSelectedRows, tr.id) == -1)
						this.addedSelectedRows.push(tr.id);
					array_remove(this.removedSelectedRows, tr.id);
				}
				this.htmlRender.ShowSelection(tr, rowIndex);		
			}
			else{
				if(synchronize){
					if(!this.selectionCleared && array_indexOf(this.selectedRows, tr.id) >= 0)
						this.removedSelectedRows.push(tr.id);
					array_remove(this.addedSelectedRows, tr.id);
				}
				this.htmlRender.HideSelection(tr, rowIndex);	
			}
			if(synchronize)
				this.FillSelectedInput();
		}
	}

	this.ClearSelection = function(rowsCollection){
		for(var i = 0; i < this.rowsSelected.length; i ++){
			if(this.rowsSelected[i]){
				this.InvertRowSelection(rowsCollection[i + this.firstTRIndex], false, false, false);
			}
		}
		array_clear(this.addedSelectedRows);
		array_clear(this.removedSelectedRows);
		this.selectionCleared = true;
		this.FillSelectedInput();
	}


	fillArrayInput = function (input, array){
		input.value = "";
		for(var i = 0; i < array.length; i ++){
			if(input.value != "")
				input.value = input.value + ";";
			input.value = input.value + array[i];	
		}	
	}

	this.FillSelectedInput = function(){	
		var srInput = _getHiddenInput(this.name + "SelectedRows");	
		if(srInput != null)
			fillArrayInput(srInput, this.addedSelectedRows);
		var usrInput = _getHiddenInput(this.name + "UnSelectedRows");	
		if(usrInput != null){
			if(this.selectionCleared)
				usrInput.value = "*";
			else
				fillArrayInput(usrInput, this.removedSelectedRows);
		}	
	}

	this.MoveToTR = function(tr, focusedColumnIndex, changeSelection, clearPrevSelection, selectRange){
		if(tr != this.focusedTR || this.cellSelection || this.multiSelection && !this.IsSelectedRowCore(tr)){
			if(!this.IsGroupRow(tr) && focusedColumnIndex >= 0)
				this.focusedColumnIndex = focusedColumnIndex;
			_getHiddenInput(this.name + "FocusedColumn").value = this.focusedColumnIndex;
			var rowsCollection = _getParentNodes(tr);
			if(this.focusedTR != null){
				this.htmlRender.HideFocus(this.focusedTR);			
				if(this.multiSelection){
					if(clearPrevSelection)
						this.ClearSelection(rowsCollection);
				}
				else{
					this.htmlRender.HideSelection(this.focusedTR, this.focusedTRIndex - this.firstTRIndex);
				}
			}
			var prevFocusedTRIndex = this.focusedTRIndex;		
			this.focusedTR = tr;	
			this.focusedTRIndex = tr.rowIndex;		
			if(this.multiSelection && selectRange && prevFocusedTRIndex >= 0 && this.focusedTRIndex >= 0){
				var firstIndex = prevFocusedTRIndex < this.focusedTRIndex ? prevFocusedTRIndex : this.focusedTRIndex;
				var lastIndex = prevFocusedTRIndex < this.focusedTRIndex ? this.focusedTRIndex : prevFocusedTRIndex;
				for(var i = firstIndex; i <= lastIndex; i ++){
					this.InvertRowSelection(rowsCollection[i], true, true, true);
				}
			}		
			if(this.focusedTR != null){
				if(this.multiSelection){
					if(changeSelection && !selectRange)
						this.InvertRowSelection(this.focusedTR, false, false, true);
				}
				else{
					this.htmlRender.ShowSelection(this.focusedTR, this.focusedTRIndex - this.firstTRIndex);	
				}			
				this.htmlRender.ShowFocus(this.focusedTR);		
				_getHiddenInput(this.name + "FocusedRow").value = this.focusedTR.id;
			}
			else
				_getHiddenInput(this.name + "FocusedRow").value = "";
		}		
		else{
			if(this.multiSelection && !clearPrevSelection && this.focusedTR != null){
				this.InvertRowSelection(this.focusedTR, false, false, true);
			}
		}		
	}	
	
	this.GetFocusedTR = function(){
		return this.GetChildById(_getHiddenInput(this.name + "FocusedRow").value);
	}

	this.IsGroupRow = function(tr){
		return this.GetRowLevel(tr) < this.groupColumns.length;
	}
	this.IsRowExpanded = function(tr){
		return tr.id.indexOf(getExpandedRowMark()) >= 0;
	}	

	this.GetNextFocusedTR = function(direction){
		var newtr = null;
		var oldFocused = this.GetFocusedTR();
		var maxIndex =  this.rowCount + this.firstTRIndex - 1  + (this.showPreview ? this.rowCount - 1 : 0);		
		if(direction && this.focusedTRIndex < maxIndex){
			newtr = oldFocused;
			do{				
				if(this.showPreview && !this.IsGroupRow(newtr))
					newtr = _getNextSibling(newtr);
				newtr = _getNextSibling(newtr);
			}while(newtr.style.display == "none" && newtr.rowIndex < maxIndex);
			if(newtr.style.display == "none")
				newtr = null;
		}
		if(!direction && this.focusedTRIndex > this.firstTRIndex){
			newtr = oldFocused;
			do{
				newtr = _getPreviousSibling(newtr);
				if(this.showPreview && !this.IsGroupRow(newtr))
					newtr = _getPreviousSibling(newtr);
			}while(newtr.style.display == "none" && newtr.rowIndex > this.firstTRIndex);
			if(newtr.style.display == "none")
				newtr = null;		
		}
		if(newtr != null){
			if(newtr.id != this.name + getSpaceRowMark())
				return newtr;
		}
		return null;
	}

	this.MoveBy = function(direction, focusedColumnIndex, ctrlKey, shiftKey){
		var newtr = null;
		if(this.focusedTRIndex >= 0){			
			newtr = this.GetNextFocusedTR(direction);
			if(newtr != null)
				this.MoveToTR(newtr, focusedColumnIndex >= 0 ? focusedColumnIndex : this.focusedColumnIndex, !ctrlKey, !ctrlKey && !shiftKey, shiftKey);
		}	
		return (newtr != null) ? newtr.id : "";
	}		

	this.GetRowLevel = function(tr){
		var indexOf = tr.id.indexOf(idDlmtr);
		var substr = tr.id.substr(indexOf + idDlmtr.length, tr.id.length);
		indexOf = substr.indexOf(idDlmtr);
		substr = substr.substr(indexOf + idDlmtr.length, tr.id.length);
		indexOf = substr.indexOf(idDlmtr);
		return Number(substr.substr(0, indexOf));	
	}

	this.SetChildrenVisible = function(tr){
		var childrenDisplay = (this.rowsExpanded[tr.rowIndex - this.firstTRIndex] && tr.style.display != "none") ? "" : "none";
		var rowLevel = this.GetRowLevel(tr);
		var childRow = _getNextSibling(tr);
		var childRowLevel = this.GetRowLevel(childRow);
		while(_isExists(childRow) && childRowLevel > rowLevel){
			if(childRowLevel == rowLevel + 1){
				childRow.style.display = childrenDisplay;			
				this.SetChildrenVisible(childRow);
				if(childRow == this.focusedTR && childrenDisplay == "none")
					this.MoveToTR(tr, this.focusedColumnIndex, false, false, false);
			}	
			childRow = _getNextSibling(childRow);
			childRowLevel = this.GetRowLevel(childRow);
		}
	}

	this.ProcessExpBtn = function(button){	
		var tr = _getParentNode(button);
		var rowIndex = tr.rowIndex - this.firstTRIndex;
		this.rowsExpanded[rowIndex] = !this.rowsExpanded[rowIndex];
		this.SetChildrenVisible(tr);	
		if(this.rowsExpanded[rowIndex])
			this.htmlRender.SetButtonExpanded(button);
		else
			this.htmlRender.SetButtonCollapsed(button);
		this.FillExpandedInput(_getParentNode(tr));
	}

	this.FillExpandedInput = function(rowsTable){	
		var input = _getHiddenInput(this.name + "ExpandedRows");	
		if(input != null && rowsTable != null){
			input.value = "";
			for(var i = 0; i < this.rowsExpanded.length; i ++){
				if(this.rowsExpanded[i]){				
					if(input.value != "")
						input.value = input.value + ";";
					input.value = input.value + rowsTable.rows[i + this.firstTRIndex].id;	
				}
			}
		}	
	}

	this.GetColumnIndexByTDId = function (tdId){
		var tdIndex = _parseInt(tdId);
		if(!isNaN(tdIndex))
			return (tdIndex >= 0) ? this.internalColumns[tdIndex].index : tdIndex;
		return -1;
	}			
	
	this.HasEmptyWidthColumns = function(){
		for(var i = 0; i < this.internalColumns.length; i ++){
			if(this.internalColumns[i].GetWidth().IsEmpty())
				return true;			
		}
		return false;
	}
	
	this.SynchronizeActualWidth = function(){	
		this.FillOriginalColumnWidths();
		this.FillActualColumnWidths();
		this.htmlRender.SetCellsWidth(true);
	}
	
	this.SynchronizeTotalWidth = function(){	
		if(this.htmlRender.IsHorzScrollBarShown()){
			if(this.totalColumnsWidth > 0)
				this.htmlRender.FitScrollerWidth(this.totalColumnsWidth);
		}
		else{
			this.ResizeGrid();
		}
	}	
	
	this.ResizeGrid = function(){
		this.FillEmptyColumnWidths();
		this.htmlRender.SetCellsWidth(false);
		this.FillOriginalColumnWidths();
		this.FillNewColumnWidths();
		this.htmlRender.SetCellsWidth(true);
	}
	
	this.GetColumnWidth = function(column){
		if(!column.GetWidth().IsEmpty()){
			if(column.GetWidth().type != "%")
				return column.GetWidth().ConvertToPx().value;
			else{
				var columnsWidth = this.GetActualGridWidth() - this.GetFixedWidth(true, true);
				return Math.round(columnsWidth * column.GetWidth().value / 100);
			}
		}
		else{
			return this.GetActualColumnWidth(this.GetColumnInternalIndex(column));
		}	
	}
	this.GetColumnsWidth = function(startIndex, endIndex, includeSpecColumns){
		var columnsWidth = 0;		
		for(var i = startIndex; i <= endIndex; i ++){
			var column = this.internalColumns[i];
			if((includeSpecColumns || column.type != "IndicatorColumn" && column.type != "RowBtnColumn" && column.type != "GroupingIndentColumn")){
				if(!column.fixedWidth)
					columnsWidth += this.GetColumnWidth(column);
			}
		}		
		return columnsWidth;
	}
	
	this.GetActualGridWidth = function(){
		return this.htmlRender.GetActualGridWidth();
	}
	
	this.GetActualColumnWidth = function(columnInternalIndex){
		return this.htmlRender.GetActualColumnWidth(columnInternalIndex);
	}
	
	this.GetLastCorrectionColumn = function(changedColumn){
		var lastColumn = null;
		for(var i = 0; i < this.internalColumns.length; i ++){
			var column = this.internalColumns[i];
			if(!column.fixedWidth && column != changedColumn)
				lastColumn = column;
		}
		return lastColumn;
	}
	
	this.GetFixedWidth = function(includeSpecColumns, includeScrollBar){
		var fixedWidth = 0;		
		for(var i = 0; i < this.internalColumns.length; i ++){
			var column = this.internalColumns[i];
			if((includeSpecColumns || column.type != "IndicatorColumn" && column.type != "RowBtnColumn" && column.type != "GroupingIndentColumn")){
				if(column.fixedWidth && !column.GetWidth().IsEmpty())
					fixedWidth += column.GetWidth().ConvertToPx().value;
			}
		}		
		if(includeScrollBar)
			fixedWidth += this.GetScrollBarWidth();	
		return fixedWidth;
	}
	
	this.GetScrollBarWidth = function(){
		if(this.htmlRender.IsVertScrollBarShown() && !this.htmlRender.vertScrollBarEmpty && this.htmlRender.GetScrollBarSize().type != "%")
			return this.htmlRender.GetScrollBarSize().ConvertToPx().value;
		return 0;
	}
	
	this.FillOriginalColumnWidths = function(){
		this.originalColumnsWidth = this.GetColumnsWidth(0, this.internalColumns.length - 1, true);
		this.originalColumnWidths = new Array();
		for(var i = 0; i < this.internalColumns.length; i ++){
			this.originalColumnWidths[i] = this.GetColumnWidth(this.internalColumns[i]);
		}
	}
	
	this.GetPreviewWidth = function(){
		var previewWidth = 0;
		for(var i = 0; i < this.internalColumns.length; i ++){
			var column = this.internalColumns[i];			
			if(column.type == "BoundColumn" || column.type == "TemplateColumn")
				previewWidth += this.newColumnWidths[i] - 1;
		}
		return previewWidth - 1 - (!ie ? 2 * horzTextPadding : 0);
	}
	
	this.GetGroupItemTextCellWidth = function(){
		var groupItemTextCellWidth = 0;
		for(var i = 0; i < this.internalColumns.length; i ++){
			var column = this.internalColumns[i];			
			if(column.type == "BoundColumn" || column.type == "TemplateColumn")
				groupItemTextCellWidth += this.newColumnWidths[i] - 1;
		}
		return groupItemTextCellWidth - 1 - (!ie ? 2 * horzTextPadding : 0);
	}
	
	this.FillNewColumnWidths = function(){		
		var columnsWidth = this.GetActualGridWidth() - this.GetFixedWidth(true, true);
		var lastColumn = this.GetLastCorrectionColumn(null);
		this.newColumnWidths = new Array();
		if(columnsWidth > 0){	
			for(var i = 0; i < this.internalColumns.length; i ++){
				var column = this.internalColumns[i];
				if(!column.fixedWidth){
					if(column != lastColumn){
						var newColumnWidth = Math.round(this.originalColumnWidths[i] * columnsWidth / this.originalColumnsWidth);
						if(newColumnWidth < column.minWidth)
							newColumnWidth = column.minWidth;
						this.originalColumnsWidth -= this.originalColumnWidths[i];
						columnsWidth -= newColumnWidth;
						this.newColumnWidths[i] = newColumnWidth;
					}
					else{
						this.newColumnWidths[this.GetColumnInternalIndex(lastColumn)] = columnsWidth >= lastColumn.minWidth ? columnsWidth : lastColumn.minWidth;
					}
				}
				else{
					this.newColumnWidths[i] = this.originalColumnWidths[i];
				}
			}			
		}
		if(this.showPreview)		
			this.previewWidth = this.GetPreviewWidth();
		this.actualGridWidth = this.GetActualGridWidth();
		this.groupItemTextCellWidth = this.GetGroupItemTextCellWidth();
	}
	
	this.FillEmptyColumnWidths = function(){
		this.newColumnWidths = new Array();
		for(var i = 0; i < this.internalColumns.length; i ++){			
			this.newColumnWidths[i] = 1;
		}
		if(this.showPreview)		
			this.previewWidth = 1;
		this.actualGridWidth = 1;
		this.groupItemTextCellWidth = 1;
	}
	
	this.FillActualColumnWidths = function(){
		this.newColumnWidths = new Array();
		for(var i = 0; i < this.internalColumns.length; i ++){			
			this.newColumnWidths[i] = this.GetActualColumnWidth(i);
		}
		if(this.showPreview)		
			this.previewWidth = this.GetPreviewWidth();
		this.actualGridWidth = this.GetActualGridWidth();			
		this.groupItemTextCellWidth = this.GetGroupItemTextCellWidth();
	}
	
	this.CheckActualColumnWidths = function(){
		for(var i = 0; i < this.internalColumns.length; i ++){			
			var column = this.internalColumns[i];
			if(column.width.ConvertToPx().value + this.htmlRender.GetColumnWidthCorrection(column) != this.GetActualColumnWidth(i))
				return false;
		}
		return true;
	}	

	this.GetDataPageSize = function(){
		return this.pageSize;
	}

	this.IsFocusedRowCore = function(tr, rowId){
		if(this.clientSideMode)
			return this.GetRowById(rowId) == this.GetFocusedRow();
		else
			return _getHiddenInput(this.name + "FocusedRow").value == tr.id;
	}
	this.IsSelectedRowCore = function(tr){
		if(this.multiSelection){
			if(this.clientSideMode){
				var rowId = getElementRowId(tr);
				var row = this.GetRowById(rowId);
				if(row != null)
					return row.GetSelected();
			}
			else{
				if(this.addedSelectedRows != null)
					if(array_indexOf(this.addedSelectedRows, tr.id) != -1)
						return true;
				if(!this.selectionCleared && array_indexOf(this.selectedRows, tr.id) != -1)
					if(this.removedSelectedRows != null)
						if(array_indexOf(this.removedSelectedRows, tr.id) == -1)
							return true;
					else
						return true;
			}
			return false;		
		}
		return false;
	} 
	
	this.NewRowCore = function(evt, evtSrcType, rowId, assistPar, processOnServer){
		if(!this.readOnly && this.allowInsert){
			this.InitPostBack(evt, "INSERT", evtSrcType, rowId, assistPar);
			if(!processOnServer && !this.postBackOnEnteringEditMode && !this.CheckPostBackOnPostingDataChanges())
				this.NewRowByUI(rowId, false);
			else
				this.SendPostBack(false);
			return true;
		}
		return false;
	}

	this.AppendRowCore = function(evt, evtSrcType, rowId, assistPar, processOnServer){
		if(!this.readOnly && this.allowAppend){
			this.InitPostBack(evt, "APPEND", evtSrcType, "-1", assistPar);
			if(!processOnServer && !this.postBackOnEnteringEditMode && !this.CheckPostBackOnPostingDataChanges())
				this.NewRowByUI(rowId, true);
			else
				this.SendPostBack(false);
			return true;
		}
		return false;
	}

	this.EditRowCore = function(evt, evtSrcType, rowId, tdId, assistPar, processOnServer){
		if(!this.readOnly && this.allowEdit){
			var focusedColumnIndex = this.GetColumnIndexByTDId(tdId);
			this.InitPostBack(evt, "STARTEDIT", evtSrcType, rowId + ";" + focusedColumnIndex, assistPar);
			if(!processOnServer && !this.postBackOnEnteringEditMode)					
				this.EditRowByUI(rowId, focusedColumnIndex);
			else
				this.SendPostBack(false);
			return true;
		}
		return false;
	}

	this.PostEditCore = function(evt, evtSrcType, rowId, assistPar, processOnServer){
		this.InitPostBack(evt, "POSTEDIT",  evtSrcType, rowId, assistPar);
		if(!processOnServer && !this.postBackOnPostingDataChanges)					
			this.PostByUI();
		else
			this.SendPostBack(false);
		return true;
	}

	this.CancelEditCore = function(evt, evtSrcType, rowId, assistPar, processOnServer){
		this.InitPostBack(evt, "CANCELEDIT",  evtSrcType, rowId, assistPar);
		if(!processOnServer)					
			this.CancelByUI();
		else
			this.SendPostBack(false);
		return true;
	}

	this.DeleteRowCore = function(evt, evtSrcType, rowId, assistPar, processOnServer){
		var tr = this.GetChildById(this.name + getDataRowMark() + rowId);
		if(tr == null)
			tr = this.GetFocusedTR();
		if(!this.readOnly && this.allowDelete && tr != null && !this.IsGroupRow(tr)){
			if(!this.confirmDelete || confirm(this.confirmDeleteMessage)){
				this.InitPostBack(evt, "DELETE", evtSrcType, rowId, assistPar);
				if(!processOnServer && !this.postBackOnPostingDataChanges)
					this.DeleteRowByUI(rowId);
				else
					this.SendPostBack(false);
			}
			return true;
		}
		return false;
	}

	this.MoveToPageCore = function(evt, evtSrcType, pageIndex, assistPar, processOnServer){
		this.InitPostBack(evt, "GOTOPAGE", evtSrcType, pageIndex, assistPar);
		if(!processOnServer && !this.processOnServer && !this.CheckPostBackOnPostingDataChanges())					
			this.MoveToPageByUI(pageIndex);
		else
			this.SendPostBack(false);
	}

	this.SearchRowCore = function(evt, evtSrcType, columnIndex, searchString, assistPar, incrementalSearch, processOnServer){
		this.InitPostBack(evt, "SEARCH", evtSrcType, columnIndex + idDlmtr + searchString, assistPar);
		if(!processOnServer && !this.CheckPostBackOnPostingDataChanges())
			this.SearchRowByUI(columnIndex, searchString, evtSrcType == "SB", incrementalSearch);
		else
			this.SendPostBack(false);
	}

	this.ExpandRowCore = function(evt, evtSrcType, rowId, button, assistPar, processOnServer){
		this.InitPostBack(evt, "EXPAND", evtSrcType, rowId, assistPar);
		if(!processOnServer && !this.CheckPostBackOnPostingDataChanges()){					
			this.ExpandRowByUI(rowId);
		}
		else{
			if(this.clientSideExpanding && this.controlMode == "Browse")
				this.ProcessExpBtn(button);	
			else
				this.SendPostBack(false);
		}
		return true;
	}

	this.MoveByCore = function(evt, evtSrcType, direction, assistPar, tdId, processOnServer){
		var focusedColumnIndex = tdId != "-1" ? this.GetColumnIndexByTDId(tdId) : this.focusedColumnIndex;	
		this.InitPostBack(evt, ((direction) ? "NEXT" : "PREV"), evtSrcType, focusedColumnIndex, assistPar);
		if(!processOnServer && !this.CheckPostBackOnPostingDataChanges()){
			if(direction) 
				this.MoveNextByUI(focusedColumnIndex, evt != null && _getShiftKey(evt) && (evtSrcType != "KB" || assistPar != kbTab) && evtSrcType != "SC", evt != null && _getCtrlKey(evt) || evtSrcType == "SC", evtSrcType == "SC");
			else 
				this.MovePrevByUI(focusedColumnIndex, evt != null && _getShiftKey(evt) && (evtSrcType != "KB" || assistPar != kbTab) && evtSrcType != "SC", evt != null && _getCtrlKey(evt) || evtSrcType == "SC", evtSrcType == "SC");
			return;
		}
		if(this.GetDataMode() == "Browse" && !this.postBackOnFocusedChanged){
			var newtrId = this.MoveBy(direction, focusedColumnIndex, _getCtrlKey(evt), _getShiftKey(evt));
			if(newtrId != "")
				return;
		}
		this.SendPostBack(false);
	}

	this.MoveFirstCore = function(evt, evtSrcType, assistPar, processOnServer){
		this.InitPostBack(evt, "FIRST", evtSrcType, "0", assistPar);
		if(!processOnServer && !this.CheckPostBackOnPostingDataChanges())
			this.MoveFirstByUI(_getShiftKey(evt), _getCtrlKey(evt) && evtSrcType != "KB");	
		else
			this.SendPostBack(false);
	}

	this.MovePrevPageCore = function(evt, evtSrcType, assistPar, processOnServer){		
		if(this.pageSize == 0 && this.htmlRender.IsVertScrollBarShown()){
			var focusedTR = this.GetFocusedTR();
			this.htmlRender.CorrectScrollersPos(focusedTR);
			firstTR = this.htmlRender.GetFirstTRInScrollArea(focusedTR);
			if(this.IsFocusedRowCore(firstTR, getElementRowId(firstTR)))
				firstTR = this.htmlRender.GetPageUpTR(focusedTR);
			this.MoveToCore(evt, evtSrcType, firstTR, getElementRowId(firstTR), this.GetColumnInternalIndex(this.columns[this.focusedColumnIndex]), assistPar, processOnServer);
		}
		else{
			this.InitPostBack(evt, "PREVPAGE", evtSrcType, "0", assistPar);
			if(!processOnServer && !this.CheckPostBackOnPostingDataChanges())
				this.MovePrevPageByUI(evt != null && _getShiftKey(evt) && evtSrcType != "SC", evt != null && _getCtrlKey(evt) || evtSrcType == "SC", evtSrcType == "KB", evtSrcType == "KB" || evtSrcType == "SC");	
			else
				this.SendPostBack(false);
		}
	}

	this.MoveNextPageCore = function(evt, evtSrcType, assistPar, processOnServer){
		if(this.pageSize == 0 && this.htmlRender.IsVertScrollBarShown()){
			var focusedTR = this.GetFocusedTR();
			this.htmlRender.CorrectScrollersPos(focusedTR);
			lastTR = this.htmlRender.GetLastTRInScrollArea(focusedTR);
			if(this.IsFocusedRowCore(lastTR, getElementRowId(lastTR)))
				lastTR = this.htmlRender.GetPageDownTR(focusedTR);
			this.MoveToCore(evt, evtSrcType, lastTR, getElementRowId(lastTR), this.GetColumnInternalIndex(this.columns[this.focusedColumnIndex]), assistPar, processOnServer);
		}
		else{
			this.InitPostBack(evt, "NEXTPAGE", evtSrcType, "0", assistPar);
			if(!processOnServer && !this.CheckPostBackOnPostingDataChanges())		
				this.MoveNextPageByUI(evt != null && _getShiftKey(evt) && evtSrcType != "SC", evt != null && _getCtrlKey(evt)|| evtSrcType == "SC", evtSrcType == "KB", evtSrcType == "KB" || evtSrcType == "SC");	
			else
				this.SendPostBack(false);
		}
	}

	this.MoveLastCore = function(evt, evtSrcType, assistPar, processOnServer){
		this.InitPostBack(evt, "LAST", evtSrcType, "0", assistPar);
		if(!processOnServer && !this.CheckPostBackOnPostingDataChanges())
			this.MoveLastByUI(_getShiftKey(evt), _getCtrlKey(evt) && evtSrcType != "KB");	
		else
			this.SendPostBack(false);
	}

	this.FocusEditor = function(focusedColumnIndex){
		this.focusedColumnIndex = focusedColumnIndex;
		if(!this.directRender && this.GetFocusedColumn() != null){
			var editor = this.GetFocusedColumn().GetEditor();
			if(editor != null)
				editor.FocusEditor();
		}
	}

	this.MoveToCore = function(evt, evtSrcType, tr, rowId, tdId, assistPar, processOnServer){
		var browseMode = this.GetDataMode() == "Browse";
		var focusedColumnIndex = this.GetColumnIndexByTDId(tdId);			
		this.InitPostBack(evt, "MOVETO", evtSrcType, rowId + ";" + focusedColumnIndex, assistPar);
		if(this.clientSideMode){		
			if(processOnServer || (this.CheckPostBackOnPostingDataChanges() && this.GetFocusedRow().GetRowID() != rowId))
				this.SendPostBack(false);
			else
				this.MoveToByUI(rowId, focusedColumnIndex, _getShiftKey(evt), _getCtrlKey(evt));	
		}
		else{
			if(this.IsEditMode() && tr == this.focusedTR){
				this.FocusEditor(focusedColumnIndex);
			}
			else{
				if(!processOnServer && !this.postBackOnFocusedChanged && browseMode)
					this.MoveToTR(tr, focusedColumnIndex, !_getShiftKey(evt), !_getShiftKey(evt) && !_getCtrlKey(evt), _getShiftKey(evt));
				else
					if(tr != this.focusedTR || (this.multiSelection && (_getShiftKey(evt) || _getCtrlKey(evt))))
						this.SendPostBack(false);
			}
		}
	}
	
	this.CanHaveFocus = function(column){
		return (column.type == "BoundColumn" || column.type == "TemplateColumn") && !column.readOnly;
	}

	this.GetFirstDataColumnOffset = function(){
		return this.GetLeftRowBtnColumnsOffset() + this.groupColumns.length;
	}
	
	this.GetFirstFocusedColumnOffset = function(){
		var firstFocusedColumnOffset = this.GetFirstDataColumnOffset();
		var rightRowBtnColumnsOffset = this.GetRightRowBtnColumnsOffset();
		while(firstFocusedColumnOffset < rightRowBtnColumnsOffset && !this.CanHaveFocus(this.internalColumns[firstFocusedColumnOffset])){
			firstFocusedColumnOffset ++;
		}
		return firstFocusedColumnOffset;
	}
	
	this.GetLastFocusedColumnOffset = function(){
		var lastFocusedColumnOffset = this.GetRightRowBtnColumnsOffset();
		var firstDataColumnOffset = this.GetFirstDataColumnOffset();
		while(lastFocusedColumnOffset > firstDataColumnOffset && !this.CanHaveFocus(this.internalColumns[lastFocusedColumnOffset])){
			lastFocusedColumnOffset --;
		}
		return lastFocusedColumnOffset;
	}

	this.GetNextColumnTDId = function(){
		var focusedColumnIndex = this.GetColumnInternalIndex(this.columns[this.focusedColumnIndex]);
		var cycleFocusedColumnIndex = focusedColumnIndex;
		if(this.GetLastFocusedColumnOffset() >= this.GetFirstFocusedColumnOffset()){
			do{
				focusedColumnIndex = focusedColumnIndex < this.GetLastFocusedColumnOffset() ? focusedColumnIndex + 1 : this.GetFirstFocusedColumnOffset();
				if(focusedColumnIndex == cycleFocusedColumnIndex) break;
			}
			while(focusedColumnIndex >= 0 && !this.CanHaveFocus(this.internalColumns[focusedColumnIndex]));
		}
		return focusedColumnIndex;
	}
	
	this.GetPrevColumnTDId = function(){
		var focusedColumnIndex = this.GetColumnInternalIndex(this.columns[this.focusedColumnIndex]);
		var cycleFocusedColumnIndex = focusedColumnIndex;
		if(this.GetLastFocusedColumnOffset() >= this.GetFirstFocusedColumnOffset()){
			do{
				focusedColumnIndex = focusedColumnIndex > this.GetFirstFocusedColumnOffset() ? focusedColumnIndex - 1 : this.GetLastFocusedColumnOffset();
				if(focusedColumnIndex == cycleFocusedColumnIndex) break;
			}
			while(focusedColumnIndex >= 0 && !this.CanHaveFocus(this.internalColumns[focusedColumnIndex]));
		}
		return focusedColumnIndex;
	}

	this.MoveNextColumnCore = function(evt, cycle, assistPar, processOnServer){
		if(this.cellSelection || this.IsEditMode()){
			var focusedTR = this.GetFocusedTR();
			if(focusedTR != null){
				var nextColumnTDId = this.GetNextColumnTDId();
				if(nextColumnTDId > this.GetFirstFocusedColumnOffset()){
					this.MoveToCore(evt, "KB", focusedTR, getElementRowId(focusedTR), nextColumnTDId, assistPar, processOnServer);
				}
				else {
					if(cycle)
						this.MoveByCore(evt, "KB", true, assistPar, nextColumnTDId, processOnServer);
				}
			}
		}
		return true;
	}	

	this.MovePrevColumnCore = function(evt, cycle, assistPar, processOnServer){
		if(this.cellSelection || this.IsEditMode()){
			var focusedTR = this.GetFocusedTR();
			if(focusedTR != null){
				var prevColumnTDId = this.GetPrevColumnTDId();
				if(prevColumnTDId < this.GetLastFocusedColumnOffset()){				
					this.MoveToCore(evt, "KB", focusedTR, getElementRowId(focusedTR), prevColumnTDId, assistPar, processOnServer);
				}
				else {
					if(cycle)
						this.MoveByCore(evt, "KB", false, assistPar, prevColumnTDId, processOnServer);
				}
			}
		}
		return true;
	}

	this.MoveFirstColumnCore = function(evt, assistPar, processOnServer){
		if((this.cellSelection || this.IsEditMode())){
			var focusedTR = this.GetFocusedTR();
			if(focusedTR != null)
				this.MoveToCore(evt, "KB", focusedTR, getElementRowId(focusedTR), this.GetFirstFocusedColumnOffset(), assistPar, processOnServer);
		}
	}

	this.MoveLastColumnCore = function(evt, assistPar, processOnServer){
		if((this.cellSelection || this.IsEditMode())){
			var focusedTR = this.GetFocusedTR();
			if(focusedTR != null)
				this.MoveToCore(evt, "KB", focusedTR, getElementRowId(focusedTR), this.GetRightRowBtnColumnsOffset(), assistPar, processOnServer);
		}
	}
	
	this.SortCore = function(evt, evtSrcType, colIndex, processOnServer){
		this.InitPostBack(evt, "SORT", evtSrcType, colIndex, "0");
		if(!processOnServer && !this.postBackOnSortingAndGrouping && !this.CheckPostBackOnPostingDataChanges())
			this.SortByUI(colIndex, _getShiftKey(evt), _getCtrlKey(evt));
		else
			this.SendPostBack(false);
	}

	this.GroupCore = function(evt, evtSrcType, colIndex, groupIndex, processOnServer){
		if(this.columns[colIndex].enableGrouping && (this.columns[colIndex].groupIndex != groupIndex || groupIndex == -1)){	
			this.InitPostBack(evt, "GROUP", evtSrcType, colIndex, groupIndex);
			if(!processOnServer && !this.postBackOnSortingAndGrouping && !this.CheckPostBackOnPostingDataChanges())
				this.GroupByUI(colIndex, groupIndex);	
			else
				this.SendPostBack(false);
		}		
	}

	this.UngroupCore = function(evt, evtSrcType, colIndex, visibleIndex, processOnServer){
		if(this.columns[colIndex].enableGrouping){
			this.InitPostBack(evt, "UNGROUP", evtSrcType, colIndex, visibleIndex);
			if(!processOnServer && !this.postBackOnSortingAndGrouping && !this.CheckPostBackOnPostingDataChanges())
				this.UngroupByUI(colIndex, visibleIndex);	
			else
				this.SendPostBack(false);
		}	
	}

	this.MoveColumnCore = function(evt, evtSrcType, colIndex, visibleIndex, processOnServer){
		this.InitPostBack(evt, "MOVECOLUMN", evtSrcType, colIndex, visibleIndex);
		if(!processOnServer)			
			this.MoveColumnByUI(colIndex, visibleIndex);
		else
			this.SendPostBack(false);
	}

	this.ResizeColumnCore = function(evt, evtSrcType, colIndex, newWidth){
		this.InitPostBack(evt, "RESIZECOLUMN", evtSrcType, colIndex, newWidth);
		if(this.GetColumnInternalIndex(this.columns[colIndex]) == (this.GetLeftRowBtnColumnsOffset() + this.groupColumns.length) && this.groupColumns.length > 0)
			newWidth -= this.groupRowIndent.ConvertToPx().value * this.groupColumns.length; 
		if(this.clientSideMode)
			this.SetColumnWidthByUI(this.columns[colIndex], newWidth);		
		else
			this.SendPostBack(false);
	}

	this.SetPageSizeCore = function(evt, evtSrcType, value, assistPar, processOnServer){
		this.InitPostBack(evt, "CHANGEPAGESIZE", evtSrcType, value, assistPar);
		if(!processOnServer && !this.postBackOnPageSizeChanging)
			this.ChangePageSizeByUI(value);	
		else
			this.SendPostBack(false);
	}

	this.RefreshCore = function(evt, evtSrcType, assistPar){
		this.InitPostBack(evt, "REFRESH", evtSrcType, "0", assistPar);
		this.SendPostBack(false);
	}	
	
	this.CustomActionCore = function(evt, evtSrcType, activeElement, assistPar, processOnServer){
		if(processOnServer){
			this.InitPostBack(evt, "CUSTOM", evtSrcType, activeElement, assistPar);
			this.SendPostBack(false);
		}
	}
	
	this.InitPostBack = function(evt, actionID, sourceType, activeElement, assistElement){
		this.SynchronizeColumns();
		__initASPxPostBack(evt, this.name, actionID + argsDlmtr + sourceType + argsDlmtr + activeElement + argsDlmtr + assistElement, this, this.enableCallBacks, false);
	}
	this.BeforePostBack = function(){
		if(this.enableLoadingText)
			this.ShowLoadingText();
	}
	this.SendPostBack = function(omitEvent){
		this.BeforePostBack();
		__sendASPxPostBack(omitEvent);
	}

	this.ShowLoadingText = function(){
		if(_isFunctionType(typeof(GetDataNavigatorCollection))){
			for(var i = 0; i < 10; i ++){
				var statusBar = GetDataNavigatorCollection().Get(this.name + "StatusBar" + i);
				if(statusBar != null){
					var success = statusBar.ShowLoadingText(this.loadingText);
					if(!success) continue;
				}
				break;
			}
		}	
	}
	
	this.GetBarBtnId = function(barName, btnIndex){
		return barName + idDlmtr + btnIndex;
	}
	this.GetBarIndex = function(barName){
		return Number(barName.substr(barName.indexOf("ButtonBar") + ("ButtonBar").length));
	}	
	this.Navigatable_ButtonClick = function(evt, barName, btnIndex, action){
		var processingMode = this.clientSideMode ? this.OnBarButtonClick(this.GetButtonBar(Number(this.GetBarIndex(barName))).GetBarItem(btnIndex), false) : "Server";
		if(processingMode != "Handled"){
			var barBtnId =  this.GetBarBtnId(barName, btnIndex);
			switch(action){
				case "MoveFirst":
					this.MoveFirstCore(evt, "BB",  barBtnId, processingMode == "Server");
					break;
				case "MovePrevPage":	
					this.MovePrevPageCore(evt, "BB",  barBtnId, processingMode == "Server");
					break;
				case "MovePrev":
					this.MoveByCore(evt, "BB", false, barBtnId, "-1", processingMode == "Server");
					break;
				case "MoveNext":
					this.MoveByCore(evt, "BB", true, barBtnId, "-1", processingMode == "Server");
					break;	
				case "MoveNextPage":
					this.MoveNextPageCore(evt, "BB",  barBtnId, processingMode == "Server");
					break;		
				case "MoveLast":
					this.MoveLastCore(evt, "BB",  barBtnId, processingMode == "Server");
					break;	
				case "AppendRow":
					this.AppendRowCore(evt, "BB",  "-1", barBtnId, processingMode == "Server");
					break;	
				case "InsertRow":
					this.NewRowCore(evt, "BB", "-1", barBtnId, processingMode == "Server");
					break;		
				case "EditRow":
					this.EditRowCore(evt, "BB", "-1", "-1", barBtnId, processingMode == "Server");
					break;	
				case "Post":
					this.PostEditCore(evt, "BB", "-1", barBtnId, processingMode == "Server");
					break;				
				case "Cancel":
					this.CancelEditCore(evt, "BB", "-1", barBtnId, processingMode == "Server");
					break;	
				case "DeleteRow":
					this.DeleteRowCore(evt, "BB", "-1", barBtnId, processingMode == "Server");
					break;							
				case "Refresh":	
					this.RefreshCore(evt, "BB", barBtnId);
					break;	
				case "Custom":	
					this.CustomActionCore(evt, "BB", "0", barBtnId, processingMode == "Server");
					break;		
			}
		}		
	}
	this.Navigatable_CustomRenderBarBtn = function(htmlElement, barItem, width, height, beforeDefaultRender){
		return this.OnCustomRenderBarBtn(htmlElement, barItem, width, height, beforeDefaultRender);
	}
	this.Navigatable_CustomRenderPageIndexBtn = function(htmlElement, barItem, width, height, pageIndex, text, tooltip, beforeDefaultRender){
		return this.OnCustomRenderPageIndexBtn(htmlElement, barItem, width, height, pageIndex, text, tooltip, beforeDefaultRender);
	}
	this.Navigatable_CustomRenderStatusBarSection = function(htmlElement, barItem, width, height, beforeDefaultRender){
		return this.OnCustomRenderStatusBarSection(htmlElement, barItem, width, height, beforeDefaultRender);
	}
	this.Navigatable_BindStatusBarSection = function(htmlElement, barItem, text){
		return this.OnBindStatusBarSection(htmlElement, barItem, text);
	}
	this.Navigatable_SetPageSize = function(evt, barName, btnIndex, pageSize){
		var processingMode = this.clientSideMode ? this.OnBarButtonClick(this.GetButtonBar(Number(this.GetBarIndex(barName))).GetBarItem(btnIndex), false) : "Server";
		if(processingMode != "Handled")
			this.SetPageSizeCore(evt, "BB", pageSize, this.GetBarBtnId(barName, btnIndex), processingMode == "Server");
			
	}
	this.Navigatable_SetCurrentPageIndex = function(evt, barName, btnIndex, isPageIndexBtn, pageIndex){
		var processingMode = this.clientSideMode ? this.OnBarButtonClick(this.GetButtonBar(Number(this.GetBarIndex(barName))).GetBarItem(btnIndex), false) : "Server";
		if(processingMode != "Handled")
			this.MoveToPageCore(evt, isPageIndexBtn ? "PI" : "BB", pageIndex, this.GetBarBtnId(barName, btnIndex), processingMode == "Server");
	}
	this.Navigatable_SearchRow = function(evt, barName, btnIndex, searchColumnIndex, searchString){
		var processingMode = this.clientSideMode ? this.OnBarButtonClick(this.GetButtonBar(Number(this.GetBarIndex(barName))).GetBarItem(btnIndex), false) : "Server";
		if(processingMode != "Handled")
			this.SearchRowCore(evt, "BB", searchColumnIndex, searchString, this.GetBarBtnId(barName, btnIndex), false, processingMode == "Server");
	}
	this.Navigatable_SetFocusedControl = function(control){
		this.SetChildFocusedControl(control);
	}
	
	this.OnCustomRenderBarBtn = function(htmlElement, barItem, width, height, beforeDefaultRender){
		return false;
	}
	this.OnCustomRenderPageIndexBtn = function(htmlElement, barItem, width, height, pageIndex, text, tooltip, beforeDefaultRender){
		return false;
	}
	this.OnCustomRenderStatusBarSection = function(htmlElement, barItem, width, height, beforeDefaultRender){
		return false;
	}
	this.OnBindStatusBarSection = function(htmlElement, barItem, text){
		return false;
	}
	

	this.OnMouseWheelCore = function(e){
		var evt = _getEvent(e);	
		var childHandler = this.GetChildFocusedControl();
		if(childHandler != null && childHandler.IsMouseInControl(evt)) {
			if(childHandler.OnMouseWheelCore(evt))
				return true;
		}
		if(_isFunctionType(typeof(GetLookAndFeelScrollBarCollection))){
			var scrollBar = GetLookAndFeelScrollBarCollection().Get(this.name + "VertScroll");
			if(scrollBar != null && scrollBar.visible){
				if(this.clientSideMode && this.pageSize > 0 ){
					if(evt.wheelDelta < 0)
						this.ShiftRowsDownByMouseWheel();
					else
						this.ShiftRowsUpByMouseWheel();
				}
				else{
					scrollBar.DoMouseWheel(e, null);
				}
				return true;
			}
			else{
				scrollBar = GetLookAndFeelScrollBarCollection().Get(this.name + "HorzScroll");
				if(scrollBar != null && scrollBar.visible){
					scrollBar.DoMouseWheel(e, null);
					return true;
				}
			}
		}
		return false;
	}	
	
	this.OnHeaderClickCore = function(evt, action, columnIndex){
		var column = this.columns[columnIndex];
		var processingMode = this.clientSideMode ? this.OnHeaderClick(column, false) : "Server";
		if(processingMode != "Handled"){
			if(column.enableSorting)
				this.SortCore(evt, "HC", columnIndex, processingMode == "Server");
			else
				this.CustomActionCore(evt, "HC", columnIndex, "0", processingMode == "Server");
		}
	}
	
	this.OnHeaderDragEndCore = function(evt, action, columnIndex, targetIndex){		
		var processingMode;
		if(this.clientSideMode){
			var column = this.columns[columnIndex];
			var groupIndex;
			var visibleIndex;
			switch(action){
				case "Group":
					groupIndex = targetIndex;
					visibleIndex = column.visibleIndex;
					break;
				case "Ungroup":
					groupIndex = -1;
					visibleIndex = targetIndex;
					break;
				case "Move":
					groupIndex = column.groupIndex;
					visibleIndex = targetIndex;
					break;
			}		
			processingMode = this.OnHeaderDragEnd(column, visibleIndex, groupIndex, false);
		}
		else{
			processingMode = "Server";
		}
		if(processingMode != "Handled"){
			switch(action){
				case "Group":
					this.GroupCore(evt, "HD", columnIndex, targetIndex, processingMode == "Server");
					break;
				case "Ungroup":
					this.UngroupCore(evt, "HD", columnIndex, targetIndex, processingMode == "Server");
					break;
				case "Move":
					this.MoveColumnCore(evt, "HD", columnIndex, targetIndex, processingMode == "Server");
					break;
			}	
		}
	}
	
	this.OnGroupingButtonClickCore = function(evt, action, columnIndex){
		var processingMode = this.clientSideMode ? this.OnGroupingButtonClick(this.columns[columnIndex], action == "Group" ? this.groupColumns.length : -1, false) : "Server";
		if(processingMode != "Handled"){
			switch(action){
				case "Group":
					this.GroupCore(evt, "GB", columnIndex, -1, processingMode == "Server");
					break;
				case "Ungroup":
					this.UngroupCore(evt, "GB", columnIndex, -1, processingMode == "Server");
					break;
			}
		}
	}
	
	this.OnRowClickCore = function(evt, action, tr, rowId, tdId){
		var processingMode = this.clientSideMode ? this.OnRowClick(this.RowClick, this.GetRowById(rowId), this.columns[this.GetColumnIndexByTDId(tdId)], false) : "Client";
		if(processingMode != "Handled")
			this.MoveToCore(evt, "RC", tr, rowId, tdId, "0", processingMode == "Server");
	}
	
	this.OnRowDblClickCore = function(evt, evtSrcType, action, rowId, tdId, td){
		var processingMode;
		if(this.clientSideMode){
			var row = this.GetRowById(rowId);
			var column = (tdId != "-1" ? this.columns[this.GetColumnIndexByTDId(tdId)] : null);
			var clientSideEvent;
			switch(evtSrcType){
				case "RF":
					clientSideEvent = this.FocusedRowClick; 
					break;
				case "RD":
					clientSideEvent = this.RowDblClick; 
					break;
			}
			processingMode = this.OnRowClick(clientSideEvent, row, column, false);
		}
		else{
			processingMode = "Server";
		}
		if(processingMode != "Handled"){
			switch(action){
				case "Expand":
					processingMode = this.ExpandRowCore(evt, evtSrcType, rowId, td, "0", processingMode == "Server") ? "Handled" : processingMode;
					break;
				case "Edit":
					processingMode = this.EditRowCore(evt, evtSrcType, rowId, tdId, "0", processingMode == "Server") ? "Handled" : processingMode;
					break;
			}
			if(processingMode != "Handled")
				this.CustomActionCore(evt, evtSrcType, rowId + (tdId != "-1" ? ";" +  this.GetColumnIndexByTDId(tdId) : ""), "0", processingMode == "Server");
		}
	}
	
	this.OnRowButtonClickCore = function(evt, action, rowId){
		var processingMode = this.clientSideMode ? this.OnRowButtonClick(this.GetRowById(rowId), action, false) : "Server";
		if(processingMode != "Handled"){
			var processOnServer = processingMode == "Server";
			switch(action){
				case "Append":
					processingMode = this.AppendRowCore(evt, "RB", rowId, "0", processOnServer) ? "Handled" : processingMode;
					break;
				case "Insert":
					processingMode = this.NewRowCore(evt, "RB", rowId, "0", processOnServer) ? "Handled" : processingMode;
					break;
				case "Edit":
					processingMode = this.EditRowCore(evt, "RB", rowId, "-1", "0", processOnServer) ? "Handled" : processingMode;
					break;
				case "Post":
					processingMode = this.PostEditCore(evt, "RB", rowId, "0", processOnServer) ? "Handled" : processingMode;
					break;
				case "Cancel":
					processingMode = this.CancelEditCore(evt, "RB", rowId, "0", processOnServer) ? "Handled" : processingMode;
					break;	
				case "Delete":
					processingMode = this.DeleteRowCore(evt, "RB", rowId, "0", processOnServer) ? "Handled" : processingMode;
					break;
			}
			if(processingMode != "Handled")
				this.CustomActionCore(evt, "RB", rowId, action, processOnServer);
		}		
	}
	
	this.OnExpandButtonClickCore = function(evt, action, rowId, button){
		var processingMode = this.clientSideMode ? this.OnExpandButtonClick(this.GetRowById(rowId), false) : "Server";
		if(processingMode != "Handled")
			this.ExpandRowCore(evt, "EB", rowId, button, "0", processingMode == "Server");
	}
	
	this.OnSearchButtonClickCore = function(evt, action, columnIndex, searchString){
		var processingMode = this.clientSideMode ? this.OnSearchButtonClick(this.columns[columnIndex], searchString, this.processOnServer) : "Server";
		var performSearch = processingMode != "Handled" && searchString != "" && searchString != null;
		if(performSearch)
			this.SearchRowCore(evt, "SB", columnIndex, searchString, "0", false, processingMode == "Server");
		return !performSearch;
	} 

	this.OnKeyDownCore = function(e){
		var evt = _getEvent(e);	
		var childHandler = this.GetChildFocusedControl();
		var ret = (childHandler != null) ? childHandler.OnKeyDownCore(evt) : krUnhandled;
		
		if(ret == krUnhandled){
			var processingMode = this.OnKeyDown(evt);
			if(processingMode == "Handled")
				return krHandled;
			else{
				var processOnServer = (processingMode == "Server") || !this.clientSideMode;
				switch(evt.keyCode){
					case kbPgUp:
						this.MovePrevPageCore(evt, "KB", evt.keyCode, processOnServer);
						ret = krHandled;
						break;
					case kbPgDown:
						this.MoveNextPageCore(evt, "KB", evt.keyCode, processOnServer);
						ret = krHandled;
						break;
					case kbEnd:
						if(this.focusedSearchEditorIndex == -1){
							if(_getCtrlKey(evt)){
								this.MoveLastCore(evt, "KB", evt.keyCode, processOnServer);
								ret = krHandled;				
							}
							else {
								this.MoveLastColumnCore(evt, evt.keyCode, processOnServer);
								ret = krHandled;
							}
						}
						break;
					case kbHome:
						if(this.focusedSearchEditorIndex == -1){
							if(_getCtrlKey(evt)){
								this.MoveFirstCore(evt, "KB", evt.keyCode, processOnServer);
								ret = krHandled;
							}
							else {
								this.MoveFirstColumnCore(evt, evt.keyCode, processOnServer);
								ret = krHandled;
							}
						}
						break;
					case kbLeft:
						if(this.focusedSearchEditorIndex == -1){
							var focusedTR = this.GetFocusedTR();
							if(_isExists(focusedTR)){
								if(this.IsGroupRow(focusedTR)){
									if(this.IsRowExpanded(focusedTR)){
										this.ExpandRowCore(evt, "KB", getElementRowId(this.GetFocusedTR()), "0", evt.keyCode, processOnServer);
										ret = krHandled;
									}
								}
								else {
									this.MovePrevColumnCore(evt, false, evt.keyCode, processOnServer);
									ret = krHandled;
								}
							}
						}
						break;
					case kbRight: 
						if(this.focusedSearchEditorIndex == -1){
							var focusedTR = this.GetFocusedTR();
							if(_isExists(focusedTR)){											
								if(this.IsGroupRow(focusedTR)){
									if(!this.IsRowExpanded(focusedTR)){
										this.ExpandRowCore(evt, "KB", getElementRowId(this.GetFocusedTR()), "0", evt.keyCode, processOnServer);
										ret = krHandled;
									}
								}
								else {
									this.MoveNextColumnCore(evt, false, evt.keyCode, processOnServer);
									ret = krHandled;
								}
							}
						}
						break;
					case kbUp:
					case kbDown:
						this.MoveByCore(evt, "KB", evt.keyCode == kbDown, evt.keyCode, "-1", processOnServer);
						ret = krHandled;
						break;
					case kbTab:
						if(!_getCtrlKey(evt) && this.IsEditMode()) {
							if(_getShiftKey(evt)) {
								if(this.IsGroupRow(this.GetFocusedTR()))
									this.MoveByCore(evt, "KB", false, evt.keyCode, "-1", processOnServer);
								else
									this.MovePrevColumnCore(evt, true, evt.keyCode, processOnServer) ? krHandled : krUnhandled;
							}
							else{
								if(this.IsGroupRow(this.GetFocusedTR()))
									this.MoveByCore(evt, "KB", true, evt.keyCode, "-1", processOnServer);
								else
									this.MoveNextColumnCore(evt, true, evt.keyCode, processOnServer) ? krHandled : krUnhandled;
							}
							ret = krHandled;
						}
						else{
							ret = krUnhandled;
						}
						break;
					case kbEsc:
						if(this.IsEditMode()){
							this.CancelEditCore(evt, "KB", "-1", evt.keyCode, processOnServer);
							ret = krHandled;
						}
						ret = krUnhandled;
						break;
					case kbEnter:
						if(this.focusedSearchEditorIndex == -1){
							if(this.IsGroupRow(this.GetFocusedTR())){
								this.ExpandRowCore(evt, "KB", getElementRowId(this.GetFocusedTR()), "0", evt.keyCode, processOnServer);
							}
							else{
								if(this.GetDataMode() == "Browse")
									this.EditRowCore(evt, "KB", "-1", "-1", evt.keyCode, processOnServer);
								else
									this.PostEditCore(evt, "KB", "-1", evt.keyCode, processOnServer);
							}
							ret = krHandled;
						}
						break;
					case kbInsert:
						if(this.focusedSearchEditorIndex == -1){
							this.NewRowCore(evt, "KB", "-1", evt.keyCode, processOnServer);
							ret = krHandled;
						}
						break;
					case kbDelete:
						if(this.focusedSearchEditorIndex == -1){
							this.DeleteRowCore(evt, "KB", "-1", evt.keyCode, processOnServer);
							ret = krHandled;
						}
						break;
					case kbPlus:
						if(this.focusedSearchEditorIndex == -1){
							var focusedTR = this.GetFocusedTR();
							if(this.IsGroupRow(focusedTR) && !this.IsRowExpanded(focusedTR)){
								this.ExpandRowCore(evt, "KB", getElementRowId(this.GetFocusedTR()), "0", evt.keyCode, processOnServer);
								ret = krHandled;
							}
							ret = krUnhandled;
						}
						break;
					case kbMinus:
						if(this.focusedSearchEditorIndex == -1){
							var focusedTR = this.GetFocusedTR();
							if(this.IsGroupRow(focusedTR) && this.IsRowExpanded(focusedTR)){
								this.ExpandRowCore(evt, "KB", getElementRowId(this.GetFocusedTR()), "0", evt.keyCode, processOnServer);
								ret = krHandled;
							}
							ret = krUnhandled;
						}
						break;
					case kbF2:
						if(!this.IsGroupRow(this.GetFocusedTR())){
							this.EditRowCore(evt, "KB", "-1", "-1", evt.keyCode, processOnServer);
							ret = krHandled;
						}
						ret = krUnhandled;
						break;
				}
			}
			if(ret == krUnhandled && this.focusedSearchEditorIndex != -1){
				evt = _getEvent(evt);
				if(evt.keyCode == kbEnter){
					var edit = _getElementById(this.name + getSearchEditorMark() + this.focusedSearchEditorIndex);
					if(edit.value != "")
						this.SearchRowCore(evt, "SB", this.focusedSearchEditorIndex, edit.value, "0", false, processOnServer);
					_selectElement(edit);
					ret = krHandled;
				}
			}
			else if(ret == krUnhandled && childHandler ==  null && evt.keyCode != kbAlt && evt.keyCode != kbCtrl && evt.keyCode != kbShift){
				this.CustomActionCore(evt, "KB", "0", evt.keyCode, this.postBackOnKeyPress);
			}	
		}		
		return ret;
	}

	this.OnKeyUpCore = function(e){
		var evt = _getEvent(e);	
		var childHandler = this.GetChildFocusedControl();
		var ret = (childHandler != null) ? childHandler.OnKeyUpCore(evt) : krUnhandled;

		if(ret == krUnhandled){
			var processingMode = this.OnKeyUp(evt);
			if(processingMode == "Handled")
				return krHandled;
			else{
				var processOnServer = (processingMode == "Server") || !this.clientSideMode;
				if(this.focusedSearchEditorIndex != -1){
					if(this.CanIncrementalSearch() && _isTextChangingKey(evt.keyCode)){
						var edit = _getElementById(this.name + getSearchEditorMark() + this.focusedSearchEditorIndex);
						if(edit.value != "")
							this.SearchRowCore(evt, "SB", this.focusedSearchEditorIndex, edit.value, "0", true, this.processOnServer);
						ret = krHandled;
					}
				}
			}
		}
		return ret;
	}

	this.OnKeyDown = function(evt){	
		if(!this.KeyDown.IsEmpty()){
			var args = new ASPxClientProcessingModeKeyEventArgs(evt.keyCode, _getAltKey(evt), _getCtrlKey(evt), _getShiftKey(evt), !this.clientSideMode);
			this.KeyDown.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));
		}
		return "Client";
	}
	this.OnKeyUp = function(evt){	
		if(!this.KeyUp.IsEmpty()){
			var args = new ASPxClientKeyEventArgs(evt.keyCode, _getAltKey(evt), _getCtrlKey(evt), _getShiftKey(evt));
			this.KeyUp.FireEvent(this, args);
			return (args.handled ? "Handled" : "Client");
		}
		return "Client";
	}

	this.IsMouseInControl = function(evt){
		var childChontrol = this.GetChildFocusedControl();
		return _getParentById(_getEventSource(evt), this.name) || (childChontrol != null && childChontrol.IsMouseInControl(evt));
	}
	this.IsDefaultButtonActionAllowed = function(){
		return false;
	}
	this.CanFocusedControl = function(){
		return true;
	}
	this.GetChildFocusedControl = function(){
		if(this.IsEditMode() && this.GetFocusedColumn() != null){
			var editor = this.GetFocusedColumn().GetEditor();
			if(editor != null) 
				return editor;
		}
		return this.childFocusedControl;
	}

	this.CanIncrementalSearch = function(){
		return false;
	}
	this.SearchEditorFocus = function(columnIndex){
		this.focusedSearchEditorIndex = columnIndex;
	}
	this.SearchEditorBlur = function(columnIndex){
		this.focusedSearchEditorIndex = -1;
	}

	this.SetChildFocusedControl = function(control){
		this.childFocusedControl = control;
	}
	
	this.OnScrollCore = function(){
		if(!this._lockScrollBars){
			if(this.pageSize > 0 && !opera)
				this.SetFirstVisibleRow(this.htmlRender.GetScrollPosRow());
		}
	}
	
	this.OnWindowResizeCore = function(){
		if(this.width.type == "%")
			this.SynchronizeTotalWidth();		
	}
	
	this.ClearResizeTimer = function(){
		window.clearTimeout(this.resizeTimer);
		this.resizeTimer = -1;
	}
	this.OnResizeCore = function(){
		if(this.resizeTimer > 0)
			this.ClearResizeTimer();
		this.resizeTimer = window.setTimeout("DoResize(\"" + this.name + "\");", 0);
	}
	this.DoResizeCore = function(){
		this.ClearResizeTimer();
		if(this.initializationMode != "Manual")
			this.CheckInitialized();
		this.CheckRenderInitialized();
	}
	
	this.ApplyCallBackHtml = function(html){
		this.htmlRender.ApplyHtml(html);
	}
	
	GetGridCollection().Add(this);
	if(_isFunctionType(typeof(GetNavigatableCollection)))
		GetNavigatableCollection().Add(this);
}
function ASPxClientGridColumnCore(owner, index, type, fieldIndex, visibleIndex){
	this.owner = owner;
	this.index = index;
	this.fieldIndex = fieldIndex;
	this.type = type;

	this.width = new ASPxClientUnit(100, "px");
	this.minWidth = 20;	
	this.fixedWidth = type == "IndicatorColumn" || type == "RowBtnColumn" || type == "GroupingIndentColumn";
	this.enableHeaderClick = true;
	this.enableHeaderDragging = true;
	this.enableSorting = true;
	this.enableGrouping = true;
	this.isLastUngroupedColumn = false;
	this.enableColumnMoving = true;		
	this.enableColumnSizing = true;
	this.visibleIndex = visibleIndex;
	this.readOnly = false;
	
	this.sortingOrder = "None";
	this.sortingIndex = -1;
	this.groupIndex = -1;	
	this.savedVisibleIndex = -1;	
	
	this.enableGroupingButton = false;
	this.enableSearchControl = true;
	this.drawSortingImage = false;
	this.footerControlShown = false;
	this.useHeaderTemplate = false;
	
	this.headerStyle = ASPxStyle.CreateStyle();
	this.groupedHeaderStyle = ASPxStyle.CreateStyle();
	this.editor = null;
	
	this.useItemTemplate = false;
	this.useEditItemTemplate = false;
	this.useHeaderTemplate = false;
	this.useFooterTemplate = false;
	this.useGroupItemTemplate = false;
	this.useRowBtnTemplate = false;
	
	this.CustomRenderSelection = new ASPxClientEvent();	
	
	this.GetEditor = function (){	
		if(this.editor == null && _isFunctionType(typeof(GetEditorCollection)))
			this.editor = GetEditorCollection().Get(this.owner.name + "Column" + this.index + "Editor");
		return this.editor;
	}
	
	this.IsLastUngroupedColumn = function(){
		return this.isLastUngroupedColumn;
	}
	
	this.GetWidth = function(){
		switch(this.type){
			case "IndicatorColumn":
				return this.owner.indicatorWidth;
			case "GroupingIndentColumn":
				return this.owner.groupRowIndent;
		}
		return this.width;
	}
	this.GetIndex = function(){
		return this.index;
	}
	this.GetType = function (){
		return this.type;
	}
}

function GetGridCollection(){
	if(__ASPxGridCollection == null){
		__ASPxGridCollection = new ASPxClientWebCollection();
	}
	return __ASPxGridCollection;
}

var GridFirstLoad;
if(typeof(savedGridWindowOnLoad) == "undefined"){
	var __ASPxGridCollection = null;
	var savedGridWindowOnLoad = window.onload;
	GridFirstLoad = true;
}

window.onload = function(evt){
	if(GridFirstLoad){
		GetGridCollection().Initialize(true);
		GridFirstLoad = false;
	}
	else
		window.setTimeout("GetGridCollection().Initialize(false)", 100);
		
	if(_isExists(savedGridWindowOnLoad)) 
		return savedGridWindowOnLoad(evt);
	return true;
}