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

RecordDelimiter = ";;";
FieldDelimiter = "~#";
FieldNameDelimiter = ":#";
function ASPxClientDataController(name){	
	this.inherit = ASPxClientDataControllerCore;
	this.inherit(name);	

	this.dataControls = new Array();
	this.navigators = new Array();
	this.rows = new Array();
	
	this.processOnServer = false;
	
	this.sortedRows = null;
	this.sortingIndexes = new Array();
	this.sortingOrders = new Array();
	this.keyFieldIndex = -1;	
	
	this.allowInsert = true;
	this.allowAppend = true;
	this.allowEdit = true;
	this.allowDelete = true;	
	this.autoEdit = true;
	this.cancelChanges = false;
	this.caseSensitiveSorting = true;
	this.confirmUnsavedChanges = false;
	this.confirmUnsavedChangesMessage = "The page contains unsaved data changes.";
	this.htmlTagsInValuesEnabled = false;
	this.readOnly = false;
	this.synchronizeDataChanges = true;
	this.serverValidationPassed = true;
	
	this.startFromFirst = true;
	this.searchForward = true;		
	this.keepSearching = true;
	this.cycleSearching = true;		
	this.ignoreCase = true;		
	this.partialSearch = "BeginsWith";		
	
	this.postBackOnEnteringEditMode = false;
	this.postBackOnPostingDataChanges = false;
	
	this.editedRows = new Array();
	this.insertedRows = new Array();
	this.deletedRows = new Array();

	this.columns = new Array();	
	
	this.focusedIndex = -1;
	this.firstRowIndex = 0;
	this.rowCount = 0;
	this.dataMode = "Browse";
	this.prevFocusedIndex = -1;
	this.editedRowValues = null;
	this.searchColumnIndex = -1;
	this.searchString = "";
	
	this.statusText = "Ok";
	
	this._lockDataChangesSync = 0;
	this._lockValueChanged = false;
	this._lockSearchState = false;
	this._lockDataMode = false;
	this.BeforeNewRow = new ASPxClientEvent();
	this.AfterNewRow = new ASPxClientEvent();
	this.BeforeStartEdit = new ASPxClientEvent();
	this.AfterStartEdit = new ASPxClientEvent();
	this.BeforeUpdate = new ASPxClientEvent();
	this.AfterUpdate = new ASPxClientEvent();
	this.BeforeCancel = new ASPxClientEvent();
	this.AfterCancel = new ASPxClientEvent();
	this.BeforeDelete = new ASPxClientEvent();
	this.AfterDelete = new ASPxClientEvent();
	this.ValidateValue = new ASPxClientEvent();
	this.FocusedChanging = new ASPxClientEvent();
	this.FocusedChanged = new ASPxClientEvent();
	this.BeforeSearch = new ASPxClientEvent();
	this.AfterSearch = new ASPxClientEvent();

	this.AddDataControl = function(dataControl){
		if(array_indexOf(this.dataControls, dataControl) == -1)
			this.dataControls.push(dataControl);
	}
	this.AddNavigator = function(navigator){
		if(array_indexOf(this.navigators, navigator) == -1)
			this.navigators.push(navigator);
	}

	this.AddColumn = function(name, type){
		var column = new ASPxClientDataControllerColumn(this, name, type);
		this.columns.push(column);
		return column;
	}
	this.AddNullColumn = function(){
		this.columns.push(null);
	}
	this.GetColumnCount = function (){
		return this.columns.length;
	}
	this.GetColumn = function (index){
		if(index >= 0 && index < this.columns.length)
			return this.columns[index];
		return null;
	}
	this.GetColumnIndex = function (column){
		return array_indexOf(this.columns, column);
	}
	this.GetColumnByName = function (name){
		for(var i = 0; i < this.columns.length; i ++){
			if(this.columns[i].name.toUpperCase() == name.toUpperCase())
				return this.columns[i];
		}
		return null;
	}
	this.GetColumnByFieldName = function (fieldName){
		return this.GetColumnByName(fieldName);
	}

	this.GetColumnIndexByName = function (name){
		for(var i = 0; i < this.columns.length; i ++){
			if(this.columns[i].name.toUpperCase() == name.toUpperCase())
				return i;
		}
		return -1;
	}
	
	this.GetRowIndex = function(row){
		return this.sortedRows != null ? array_indexOf(this.sortedRows, row.index) : row.index;
	}
	this.GetRow = function (index){
		index -= this.firstRowIndex;
		if(this.sortedRows != null){
			if(index >= 0 && index < this.sortedRows.length)
				return this.rows[this.sortedRows[index]];
		}
		else{
			if(index >= 0 && index < this.rows.length)
				return this.rows[index];
		}
		return null;
	}
	this.GetRowByKeyValue = function (keyValue){
		for(var i = 0; i < this.rows.length; i ++){
			if(_equal(this.rows[i].GetKeyValue(), keyValue))
				return this.rows[i];
		}
		return null;
	}
	this.AddRecords = function(records){
		for(var i = 0; i < records.length; i ++)
			this.AddRecord(records[i]);
	}
	this.AddRecord = function(values){
		this.InsRecord(0, values);
	}
	this.InsRecord = function(indexOffset, values){
		var rowCount = this.rows.length;    
		var newRow = new ASPxClientDataControllerRow(this, indexOffset, values, rowCount + this.firstRowIndex);
		newRow.SetKeyValue(this.keyFieldIndex >= 0 ? values[this.keyFieldIndex] : (rowCount + this.firstRowIndex));
		this.rows[rowCount] = newRow;
	}
	this.RefreshRowIndex = function (){	
		for(var i = 0, rowIndex = 0; i < this.rows.length; i++){
			var row = this.rows[i];
			rowIndex += row.GetIndexOffset();
			row.SetIndex(rowIndex);
			rowIndex ++;
		}
	}
	this.GetMaxPageSize = function(){
		var maxPageSize = 0;
		for(var i = 0; i < this.dataControls.length; i ++){
			if(_isFunction(this.dataControls[i].GetDataPageSize))
				if(maxPageSize < this.dataControls[i].GetDataPageSize())
					maxPageSize = this.dataControls[i].GetDataPageSize();
		}
		return maxPageSize;
	}
	this.GetRowCount = function (){
		return !this.processOnServer ? this.rows.length : this.rowCount;
	}
	this.GetDataMode = function (){
		return this.dataMode;
	}
	this.GetFocusedRow = function(){	
		return this.GetRow(this.focusedIndex);
	}
	this.SetFocusedRow = function(focusedRow){		
		this.SetFocusedIndex(focusedRow != null && focusedRow.owner == this ? focusedRow.GetIndex() : -1);
	}
	this.GetStatusText = function(){
		return this.statusText;
	}
	this.SetStatusText = function(statusText){
		this.statusText = statusText;
		this.StatusTextChanged();
	}

	this.SetPrevFocusedInternal = function (prevFocusedIndex){
		this.prevFocusedIndex = prevFocusedIndex;
		if(this._lockDataChangesSync == 0){
			var row = (0 <= prevFocusedIndex && prevFocusedIndex < this.GetRowCount()) ? this.GetRow(prevFocusedIndex) : null;
			_getHiddenInput(this.name + "PrevFocsdRow").value = (row != null) ? row.GetKeyValue() : null;
		}
	}

	this.SetFocusedIndexInternal = function (newFocusedIndex){
		this.focusedIndex = newFocusedIndex;
		if(this._lockDataChangesSync == 0){
			var row = (0 <= newFocusedIndex && newFocusedIndex < this.GetRowCount()) ? this.GetRow(newFocusedIndex) : null;
			_getHiddenInput(this.name + "FocusedRow").value = (row != null) ? row.GetKeyValue() : null;
		}
	}

	this.SetFocusedIndex = function (newFocusedIndex){
		var focusedChanged = this.focusedIndex != newFocusedIndex;
		var newFocusedRow = this.GetRow(newFocusedIndex);
		var processingMode = focusedChanged ? this.OnFocusedChanging(newFocusedRow, this.processOnServer && newFocusedRow == null) : "Client";
		switch(processingMode){
			case "Client":
				this.SetFocusedIndexInternal(newFocusedIndex);
				if(focusedChanged)
					this.OnFocusedChanged(newFocusedRow);
				break;
			case "Server":
				this.SendPostBack(true);
				break;
		}
	}

	this.SetDataModeInternal = function (newDataMode){	
		this.dataMode = newDataMode;
		if(this._lockDataChangesSync == 0)
			_getHiddenInput(this.name + "DataMode").value = newDataMode;
	}

	this.SetDataMode = function (newDataMode){	
		if(newDataMode != this.dataMode){
			var oldDataMode = this.dataMode;
			this.SetDataModeInternal(newDataMode);
			this.DataModeChanged(oldDataMode);
		}
	}

	this.GetRecordCount = function(){
		return this.GetRowCount();
	}
	
	this.GetFirstVisibleIndex = function(){
		return this.focusedIndex;
	}

	this.GetLastVisibleIndex = function(){
		return this.focusedIndex;
	}

	this.GetCurrentSearchColumnIndex = function(){
		return this.searchColumnIndex;
	}
	this.GetCurrentSearchString = function(){
		return this.searchString;
	}

	this.InitializeControl = function(){
		if(this.GetDataMode() == "Edit")
			this.SaveEditRowValues();
	}
		
	this.QuickSort = function (rowComparer, A, iLo, iHi){
		if(A.length > 0){
			var Lo, Hi;
			var Mid, T;

			Lo = iLo;
			Hi = iHi;
			var midIndex;
			if((Lo + Hi) % 2 == 1)
				midIndex = (Lo + Hi - 1) / 2;
			else
				midIndex = (Lo + Hi) / 2;
			Mid = this.rows[A[midIndex]];    
			do{
				while(this.CompareRows(rowComparer, this.rows[A[Lo]], Mid) < 0){
					Lo ++;
				}
				while(this.CompareRows(rowComparer, this.rows[A[Hi]], Mid) > 0){
					Hi --;
				}
				if(Lo <= Hi){
					T = A[Lo];
					A[Lo] = A[Hi];
					A[Hi] = T;
					Lo ++;
					Hi --;
				}
			}while(Lo <= Hi);
			if(Hi > iLo){
				this.QuickSort(rowComparer, A, iLo, Hi);
			}
			if(Lo < iHi){
				this.QuickSort(rowComparer, A, Lo, iHi);
			}
		}
	}

	this.CompareRows = function (rowComparer, row1, row2){
		for(var i = 0; i < this.sortingIndexes.length; i ++){
			var sortingIndex = this.sortingIndexes[i];
			var column = this.columns[sortingIndex];
			var fieldName = column.GetName();
			var value1 = rowComparer.GetCompareValue(row1.values[sortingIndex], fieldName);
			var value2 = rowComparer.GetCompareValue(row2.values[sortingIndex], fieldName);
			var eventHandled = false;
			var eventResult = 0;
			if(rowComparer != null){
				var e = new ASPxClientCompareRowsEventArgs(column, row1, row2, value1, value2, "Sorting");
				rowComparer.DoCompareRows(e);
				eventResult = e.result;
				eventHandled = e.handled;
			}
			var ret = true;
			if(eventHandled)
				ret = eventResult;
			else if(_isString(value1) && _isString(value2) && !this.caseSensitiveSorting)
				ret = _compare(value1.toLocaleLowerCase(), value2.toLocaleLowerCase());
			else
				ret = _compare(value1, value2);
			if(ret == 0)
				continue;
			if(this.sortingOrders[i] == "Descending")
				ret *= -1;
			return ret;
		}
		return 0;
	}

	this.ClearSorting = function (){
		array_clear(this.sortingIndexes);
		array_clear(this.sortingOrders);
		if(this.sortedRows != null){
			delete this.sortedRows;
			this.sortedRows = null;
		}
	}
	this.AddSortingCriteria = function (index, order){
		this.sortingIndexes.push(index);
		if(order == "None")
			order = "Ascending";
		this.sortingOrders.push(order);
	}
	this.Sort = function (){	
		var focusedRow = this.GetFocusedRow();
		if(this.keyFieldIndex >= 0 && array_indexOf(this.sortingIndexes, this.keyFieldIndex) == -1)
			this.AddSortingCriteria(this.keyFieldIndex, "Ascending");

		if(this.sortedRows != null)
			delete this.sortedRows;
		this.sortedRows = new Array();
		
		for(var i = 0; i < this.rows.length; i ++){
			this.sortedRows[i] = i;
		}	

		var rowComparer = this.FindRowComparer();
		this.QuickSort(rowComparer, this.sortedRows, 0, this.sortedRows.length - 1);
		if(focusedRow != null)
			this.SetFocusedIndexInternal(focusedRow.GetIndex());
	}
	this.FindRowComparer = function(){
		for(var i = 0; i < this.dataControls.length; i ++){
			if(_isFunction(this.dataControls[i].CanCompareRows) && _isFunction(this.dataControls[i].DoCompareRows) &&
				this.dataControls[i].CanCompareRows())
				return this.dataControls[i];
		}
		return null;
	}
	
	this.SetConvertedRowValue = function (row, columnIndex, value){
		var column = this.columns[columnIndex];
		if(!this.IsColumnReadOnly(column)){
			value = GetConvertedValue(value, column.GetType());
			if(typeof(value)  != "undefined"){
				row.SetValueInternal(columnIndex, value);
				return true;
			}
			return false;
		}
		return true;
	}

	this.RaiseOnBeforeNewRow = function (row, append, processOnServer){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrRaiseBeforeNewRow)){
					var processingMode = this.dataControls[i].DataCtrlrRaiseBeforeNewRow(row, append, processOnServer);
					if(processingMode != "Client")
						return processingMode;
				}
			}
			if(!this.BeforeNewRow.IsEmpty()){
				var args = new ASPxClientBeforeDataControllerNewRowCommandEventArgs(row, append, processOnServer);
				this.BeforeNewRow.FireEvent(this, args);
				return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"))
			}
		}
		return (processOnServer ? "Server" : "Client");
	}
	this.OnBeforeNewRow = function(row){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrBeforeNewRow))
					this.dataControls[i].DataCtrlrBeforeNewRow(row);
			}
		}
	}
	this.OnDoNewRow = function(row){	
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrDoNewRow))
					this.dataControls[i].DataCtrlrDoNewRow(row);
			}
			for(var i = 0; i < this.navigators.length; i ++){
				if(_isFunction(this.navigators[i].NavigatableRecordCountChanged))
					this.navigators[i].NavigatableRecordCountChanged();
			}
		}
	}
	this.RaiseOnAfterNewRow = function(row){	
		if(this._lockDataChangesSync == 0){	
			if(!this.AfterNewRow.IsEmpty()){
				var args = new ASPxClientDataControllerCommandEventArgs(row);
				this.AfterNewRow.FireEvent(this, args);	
			}
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrRaiseAfterNewRow))
					this.dataControls[i].DataCtrlrRaiseAfterNewRow(row);
			}
		}
	}
	this.OnAfterNewRow = function(row){	
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrAfterNewRow))
					this.dataControls[i].DataCtrlrAfterNewRow(row);
			}
		}
	}

	this.RaiseOnBeforeStartEdit = function(row, processOnServer){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrRaiseBeforeStartEdit)){
					var processingMode = this.dataControls[i].DataCtrlrRaiseBeforeStartEdit(row, processOnServer);
					if(processingMode != "Client")
						return processingMode;
				}
			}
			if(!this.BeforeStartEdit.IsEmpty()){
				var args = new ASPxClientBeforeDataControllerCommandEventArgs(row, processOnServer);
				this.BeforeStartEdit.FireEvent(this, args);
				return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"))
			}
		}
		return (processOnServer ? "Server" : "Client");
	}
	this.OnBeforeStartEdit = function(row){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrBeforeStartEdit))
					this.dataControls[i].DataCtrlrBeforeStartEdit(row);
			}
		}
	}
	this.OnDoStartEdit = function(row){		
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrDoStartEdit))
					this.dataControls[i].DataCtrlrDoStartEdit(row);
			}
		}
	}
	this.RaiseOnAfterStartEdit = function(row){		
		if(this._lockDataChangesSync == 0){	
			if(!this.AfterStartEdit.IsEmpty()){
				var args = new ASPxClientDataControllerCommandEventArgs(row);
				this.AfterStartEdit.FireEvent(this, args);	
			}
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrRaiseAfterStartEdit))
					this.dataControls[i].DataCtrlrRaiseAfterStartEdit(row);
			}
		}
	}
	this.OnAfterStartEdit = function(row){		
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrAfterStartEdit))
					this.dataControls[i].DataCtrlrAfterStartEdit(row);
			}
		}
	}

	this.RaiseOnBeforeUpdate = function(row, processOnServer){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrRaiseBeforeUpdate)){
					var processingMode = this.dataControls[i].DataCtrlrRaiseBeforeUpdate(row, processOnServer);
					if(processingMode != "Client")
						return processingMode;
				}
			}
			if(!this.BeforeUpdate.IsEmpty()){
				var args = new ASPxClientBeforeDataControllerCommandEventArgs(row, processOnServer);
				this.BeforeUpdate.FireEvent(this, args);
				return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"))
			}
		}
		return (processOnServer ? "Server" : "Client");
	}
	this.OnBeforeUpdate = function(row){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrBeforeUpdate))
					this.dataControls[i].DataCtrlrBeforeUpdate(row);
			}
		}
	}
	this.OnDoUpdate = function(row){		
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrDoUpdate))
					this.dataControls[i].DataCtrlrDoUpdate(row);
			}
		}
	}
	this.RaiseOnAfterUpdate = function(row){		
		if(this._lockDataChangesSync == 0){	
			if(!this.AfterUpdate.IsEmpty()){
				var args = new ASPxClientDataControllerCommandEventArgs(row);
				this.AfterUpdate.FireEvent(this, args);	
			}
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrRaiseAfterUpdate))
					this.dataControls[i].DataCtrlrRaiseAfterUpdate(row);
			}
		}
	}
	this.OnAfterUpdate = function(row){		
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrAfterUpdate))
					this.dataControls[i].DataCtrlrAfterUpdate(row);
			}
		}
	}

	this.RaiseOnBeforeCancel = function(row, processOnServer){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrRaiseBeforeCancel)){
					var processingMode = this.dataControls[i].DataCtrlrRaiseBeforeCancel(row, processOnServer);
					if(processingMode != "Client")
						return processingMode;
				}
			}
			if(!this.BeforeCancel.IsEmpty()){
				var args = new ASPxClientBeforeDataControllerCommandEventArgs(row, processOnServer);
				this.BeforeCancel.FireEvent(this, args);
				return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"))
			}
		}
		return (processOnServer ? "Server" : "Client");
	}
	this.OnBeforeCancel = function(row){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrBeforeCancel))
					 this.dataControls[i].DataCtrlrBeforeCancel(row);
			}
		}
	}
	this.OnDoCancel = function(row){		
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrDoCancel))
					this.dataControls[i].DataCtrlrDoCancel(row);
			}
			for(var i = 0; i < this.navigators.length; i ++){
				if(_isFunction(this.navigators[i].NavigatableRecordCountChanged))
					this.navigators[i].NavigatableRecordCountChanged();
			}
		}
	}
	this.RaiseOnAfterCancel = function(row){	
		if(this._lockDataChangesSync == 0){		
			if(!this.AfterCancel.IsEmpty()){
				var args = new ASPxClientDataControllerCommandEventArgs(row);
				this.AfterCancel.FireEvent(this, args);	
			}
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrRaiseAfterCancel))
					this.dataControls[i].DataCtrlrRaiseAfterCancel(row);
			}
		}
	}
	this.OnAfterCancel = function(row){	
		if(this._lockDataChangesSync == 0){		
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrAfterCancel))
					this.dataControls[i].DataCtrlrAfterCancel(row);
			}
		}
	}

	this.RaiseOnBeforeDelete = function(row, processOnServer){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].DataCtrlrRaiseBeforeDelete)){
					var processingMode = this.dataControls[i].DataCtrlrRaiseBeforeDelete(row, processOnServer);
					if(processingMode != "Client")
						return processingMode;
				}
			}
			if(!this.BeforeDelete.IsEmpty()){
				var args = new ASPxClientBeforeDataControllerCommandEventArgs(row, processOnServer);
				this.BeforeDelete.FireEvent(this, args);
				return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"))
			}
		}
		return (processOnServer ? "Server" : "Client");
	}
	this.OnBeforeDelete = function(row){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].DataCtrlrBeforeDelete))
					this.dataControls[i].DataCtrlrBeforeDelete(row);
			}
		}
	}
	this.OnDoDelete = function(row){		
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].DataCtrlrRowDeleted))
					this.dataControls[i].DataCtrlrRowDeleted(row);
			}
			for(var i = 0; i < this.navigators.length; i ++){
				if(_isFunction(this.navigators[i].NavigatableRecordCountChanged))
					this.navigators[i].NavigatableRecordCountChanged();
			}
		}
	}
	this.RaiseOnAfterDelete = function(row){		
		if(this._lockDataChangesSync == 0){	
			if(!this.AfterDelete.IsEmpty()){
				var args = new ASPxClientDataControllerCommandEventArgs(row);
				this.AfterDelete.FireEvent(this, args);	
			}
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].DataCtrlrRaiseAfterDelete))
					this.dataControls[i].DataCtrlrRaiseAfterDelete(row);
			}
		}
	}
	this.OnAfterDelete = function(row){		
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].DataCtrlrAfterDelete))
					this.dataControls[i].DataCtrlrAfterDelete(row);
			}
		}
	}
	
	this.OnFocusedChanging = function (row, processOnServer){
		if(this._lockDataChangesSync == 0){
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].DataCtrlrFocusedChanging)){
					var processingMode = this.dataControls[i].DataCtrlrFocusedChanging(row, processOnServer);
					if(processingMode != "Client")
						return processingMode;
				}
			}
			if(!this.FocusedChanging.IsEmpty()){
				var args = new ASPxClientBeforeDataControllerCommandEventArgs(row, processOnServer);
				this.FocusedChanging.FireEvent(this, args);
				return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"))
			}
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnFocusedChanged = function (row){
		if(this._lockDataChangesSync == 0){
			if(!this.FocusedChanged.IsEmpty()){
				var args = new ASPxClientDataControllerCommandEventArgs(row);
				this.FocusedChanged.FireEvent(this, args);
			}
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].DataCtrlrFocusedChanged))
					this.dataControls[i].DataCtrlrFocusedChanged(row);
			}
			for(var i = 0; i < this.navigators.length; i ++){
				if(_isFunction(this.navigators[i].NavigatableFocusedChanged))
					this.navigators[i].NavigatableFocusedChanged();
			}
		}
	}

	this.ValueChanged = function (fieldIndex, value){
		if(this._lockDataChangesSync == 0){
			if(!this._lockValueChanged){
				for(var i = 0; i < this.dataControls.length; i ++){
					if(_isFunction(this.dataControls[i].DataCtrlrValueChanged))
						this.dataControls[i].DataCtrlrValueChanged(fieldIndex, value);
				}		
			}
		}
	}

	this.DataModeChanged = function (oldDataMode){
		if(this._lockDataChangesSync == 0){
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrDataModeChanged))
					this.dataControls[i].DataCtrlrDataModeChanged(oldDataMode);
			}
			for(var i = 0; i < this.navigators.length; i ++){
				if(_isFunction(this.navigators[i].NavigatableDataModeChanged))
					this.navigators[i].NavigatableDataModeChanged();
			}
		}
	}
	
	this.OnEndDataBatchUpdate = function (){
		if(this._lockDataChangesSync == 0){
			for(var i = 0; i < this.dataControls.length; i ++){
				if(!this.dataControls[i].readOnly && _isFunction(this.dataControls[i].DataCtrlrEndDataBatchUpdate))
					this.dataControls[i].DataCtrlrEndDataBatchUpdate();
			}
			for(var i = 0; i < this.navigators.length; i ++){
				if(_isFunction(this.navigators[i].NavigatableEndDataBatchUpdate))
					this.navigators[i].NavigatableEndDataBatchUpdate();
			}
		}
	}

	this.StatusTextChanged = function (oldDataMode){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableStatusTextChanged))
				this.navigators[i].NavigatableStatusTextChanged();
		}
	}

	this.SearchStateChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableSearchStateChanged))
				this.navigators[i].NavigatableSearchStateChanged();
		}
	}
	
	this.IsNavigatableEx = function (){
		return false;
	}

	this.MoveTo = function (newFocusedRow){	
		if(this.GetFocusedRow() != newFocusedRow && this.ClearCurrentState())
			this.SetFocusedRow(newFocusedRow);
	}
	this.MoveNext = function (){		
		if(this.ClearCurrentState() && this.focusedIndex < this.GetRowCount() - 1)
			this.SetFocusedIndex(this.focusedIndex + 1);	
	}
	this.MovePrev = function (){
		if(this.ClearCurrentState() && this.focusedIndex > 0)
			this.SetFocusedIndex(this.focusedIndex - 1);	
	}
	this.MoveFirst = function (){
		if(this.ClearCurrentState() && this.GetRowCount() > 0 && this.focusedIndex > 0)
			this.SetFocusedIndex(0);	
	}
	this.MoveLast = function (){
		if(this.ClearCurrentState() && this.GetRowCount() > 0 && this.focusedIndex < this.GetRowCount() - 1)
			this.SetFocusedIndex(this.GetRowCount() - 1);	
	}

	this.ClearSearchState = function(){
		if(this.searchString != "" && !this._lockSearchState){
			this.searchColumnIndex = -1;
			this.searchString = "";
			this.SearchStateChanged();
		}
	}

	this.GetNextSearchRow = function(currentRow, startRow, searchForward, cycle){
		var increment = searchForward ? 1 : -1;
		var lastIndex = searchForward ? this.GetRowCount() - 1 : 0;
		var restartIndex = searchForward ? 0 : this.GetRowCount() - 1;
		var nextRow = null;
		if(currentRow != null){
			if(currentRow.GetIndex() * increment < lastIndex){
				nextRow = this.GetRow(currentRow.GetIndex() + increment);
			}
			else{					
				if(cycle){
					nextRow = this.GetRow(restartIndex);
				}
			}
		}
		if(nextRow != startRow)
			return nextRow;
		return null;
	}

	this.CompareStrings = function(str1, str2, partialSearch, ignoreCase){
		if(ignoreCase){
			str1 = str1.toUpperCase();
			str2 = str2.toUpperCase();
		}
		if(str1 != null && str2 != null){
			if(partialSearch == "BeginsWith")
				return str1.indexOf(str2) == 0;
			else if(partialSearch == "Contains")
				return str1.indexOf(str2) > -1;
		}
		return str1 == str2;
	}

	this.CheckSearchRowValue = function(val1, val2, convertToString, partialSearch, ignoreCase, formatString, dataType){
		if(_isString(val1) && _isString(val2)){
			return this.CompareStrings(val1, val2, partialSearch, ignoreCase);
		}
		else{
			if(convertToString){				
				return this.CompareStrings(FormatValue(val1, formatString, dataType), val2, partialSearch, ignoreCase);
			}
		}
		return _equal(val1, val2);
	}

	this.SearchRowInternal = function(column, val, startRow, convertToString, partialSearch, ignoreCase, searchForward, findNext, cycle, formatString){
		if(convertToString && typeof(val) != "string"){
			alert("A string value should be passed to the SearchRow method if the convertToString parameter is set to True.");
		}
		else{
			if(this.GetRowCount() > 0 && column != null){
				if(startRow == null && this.GetRowCount() > 0)
					startRow = this.GetRow(0);
				if(startRow != null){
					var currentRow = startRow;
					if(findNext)
						currentRow = this.GetNextSearchRow(currentRow, startRow, searchForward, cycle);
					var columnIndex = this.GetColumnIndex(column);
					var columnFieldName = column.GetName();
					var rowComparer = this.FindRowComparer();
					while(currentRow != null){
						var serachValue = rowComparer != null ? rowComparer.GetCompareValue(currentRow.GetValue(columnIndex), columnFieldName) : currentRow.GetValue(columnIndex);
						if(this.CheckSearchRowValue(serachValue, val, convertToString, partialSearch, ignoreCase, formatString, column.GetType()))
							return currentRow;
						currentRow = this.GetNextSearchRow(currentRow, startRow, searchForward, cycle);
					}
				}				
			}
		}
		return null;
	}
	this.SearchRow = function(column, val, startRow, convertToString, partialSearch, ignoreCase, searchForward, findNext, cycle){		
		return this.SearchRowInternal(column, val, startRow, convertToString, partialSearch, ignoreCase, searchForward, findNext, cycle, "");
	}
	this.DoSearchRow = function(columnIndex, searchString){	
		var searchColumn = this.columns[columnIndex];
		var processingMode = this.OnBeforeSearch(searchColumn, searchString, this.processOnServer);
		switch(processingMode){
			case "Client":
				this._lockSearchState = true;
				var findNext = this.keepSearching && this.searchColumnIndex != -1 && this.searchString != "" && this.searchColumnIndex == Number(columnIndex) && searchString.indexOf(this.searchString) == 0;
				var startRow = this.startFromFirst && !findNext ? (this.GetRowCount() > 0 ? this.GetRow(0) : null) : this.GetFocusedRow();
				var foundRow = this.SearchRow(searchColumn, searchString, startRow, true, this.partialSearch, this.ignoreCase, this.searchForward, findNext, this.cycleSearching);
				this.searchColumnIndex = Number(columnIndex);
				this.searchString = searchString;
				this.SearchStateChanged();
				this._lockSearchState = false;
				this.OnAfterSearch(searchColumn, searchString, foundRow);
				if(foundRow != null)
					this.SetFocusedRow(foundRow);
				break;
			case "Server":
				this.SendPostBack(true);
				break;				
		}
	}
	this.OnBeforeSearch = function(searchColumn, searchString, processOnServer){
		if(!this.BeforeSearch.IsEmpty()){
			var args = new ASPxClientDataControllerBeforeSearchEventArgs(searchColumn, searchString, processOnServer);
			this.BeforeSearch.FireEvent(this, args);
			return args.cancel ? "Handled" : (args.processOnServer ? "Server" : "Client");
		}
		return "Client";
	}
	this.OnAfterSearch = function(searchColumn, searchString, row){
		if(!this.AfterSearch.IsEmpty()){
			var eventArgs = new ASPxClientDataControllerAfterSearchEventArgs(searchColumn, searchString, row);
			this.AfterSearch.FireEvent(this, eventArgs);
		}
	}
	
	this.IsColumnReadOnly = function(column){
		if(column != null)
			return column.readOnly || column.autoInc;
		return true;
	}
	this.IsColumnAllowNull = function(column){
		if(column != null)
			return column.allowNull && this.keyFieldIndex != column.GetIndex();
		return true;
	}

	this.IsEditMode = function(){
		return this.GetDataMode() == "Edit" || this.GetDataMode() == "Insert" || this.GetDataMode() == "Append";
	}
	this.IsInsertMode = function(){
		return this.GetDataMode() == "Insert" || this.GetDataMode() == "Append";
	}
	this.ClearCurrentState = function (){
		this.ClearSearchState();
		return this.CheckBrowseMode();
	}
	this.CheckBrowseMode = function (){
		if(!this._lockDataMode && this.IsEditMode()){
			if(this.cancelChanges)
				this.Cancel();
			else
				this.Post();
		}
		return this.GetDataMode() == "Browse";
	}

	this.CheckKeyField = function (){
		if(this.keyFieldIndex == -1){
			alert("The DataKeyField property should be specified to enable data changing.");
			return false;
		}
		return true;
	}
	this.CheckFocusedRow = function(row){
		if(row != this.GetFocusedRow())
			this.SetFocusedRow(row);
		return row == this.GetFocusedRow();
	}

	this.InsertRowInternal = function(row, index){	
		if(this.processOnServer && index < this.rows.length){
			var correctionRow = this.rows[index];
			row.SetIndexOffset(correctionRow.GetIndexOffset());
			correctionRow.SetIndexOffset(0);
		} 
		array_insert(this.rows, row, index);		
		this.rowCount ++;
		this.RefreshRowIndex();
		if(this.sortedRows != null){
			var sortedIndex = array_indexOf(this.sortedRows, index);
			if(sortedIndex < 0)
				sortedIndex = this.sortedRows.length;
			for(var i = 0; i < this.sortedRows.length; i ++){
				if(this.sortedRows[i] >= index)
					this.sortedRows[i] ++;
			}
			array_insert(this.sortedRows, index, sortedIndex);	
		}
		this.SetFocusedIndexInternal(-1);
	}
	this.NewRow = function (beforeRow, append){
		if(append)
			beforeRow = this.GetRowCount() > 0 ? this.GetRow(this.GetRowCount() - 1) : null;
		else{
			if(beforeRow == null)
				beforeRow = this.GetFocusedRow();
		}
		if(!this.readOnly && (this.allowInsert && !append || this.allowAppend && append) && this.CheckKeyField() && this.ClearCurrentState()){
			var processingMode = this.RaiseOnBeforeNewRow(beforeRow, append, false);
			switch(processingMode){
				case "Client":
					this.OnBeforeNewRow(beforeRow);
					var emptyRow = new ASPxClientDataControllerRow(this, 0, null, -1);
					var insertIndex = beforeRow != null ? beforeRow.GetIndex() : -1;
					this.SetPrevFocusedInternal(insertIndex);
					this.InsertRowInternal(emptyRow, !append && insertIndex != -1 ? insertIndex : this.GetRowCount());
					this.SetFocusedRow(emptyRow);
					this.SetDataMode(!append ? "Insert" : "Append");
					this.OnDoNewRow(emptyRow);
					this.OnAfterNewRow(emptyRow);
					this.RaiseOnAfterNewRow(emptyRow);
					break;
				case "Server":
					this.SendPostBack(true);
					break;				
			}
		}
	}
	this.New = function (append){
		this.NewRow(this.GetFocusedRow(), append);
	}

	this.SaveEditRowValues = function(){
		this.editedRowValues = new Array();
		for(var i = 0; i < this.columns.length; i ++){
			this.editedRowValues.push(this.GetFocusedRow().GetValue(i));
		}
	}
	this.EditRow = function (row){
		if(row == null)
			row = this.GetFocusedRow();
		if(this.CheckKeyField() && this.GetDataMode() == "Browse" && row != null && !this.readOnly && this.allowEdit){
			var processingMode = this.RaiseOnBeforeStartEdit(row, false);
			switch(processingMode){
				case "Client":
					if(this.CheckFocusedRow(row)){
						this.OnBeforeStartEdit(row);
						this.SaveEditRowValues();
						this.SetDataMode("Edit");
						this.OnDoStartEdit(row);
						this.OnAfterStartEdit(row);
					}
					this.RaiseOnAfterStartEdit(row);
					break;
				case "Server":
					this.SendPostBack(true);
					break;
			}
		}
	}
	this.Edit = function (){
		this.EditRow(this.GetFocusedRow());
	}

	this.ConvertRowValues = function (row){
		var valid = true;
		for(var i = 0; i < this.columns.length; i ++){
			if(!this.SetConvertedRowValue(row, i, row.GetValue(i))){
				alert("The value '" + row.GetValue(i) + "' can not be assigned to the '" + this.columns[i].name + "' field of type " + this.columns[i].GetType());
				valid = false;				
			}
		}
		return valid;
	}

	this.StoreEditValues = function(){
		if(this._lockDataChangesSync == 0){	
			this._lockValueChanged = true;
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].StoreEditValue) && !this.dataControls[i].readOnly)
					this.dataControls[i].StoreEditValue();
			}
			this._lockValueChanged = false;
		}
	}

	this.ListenersValidateEditValues = function(){
		if(this._lockDataChangesSync == 0){	
			for(var i = 0; i < this.dataControls.length; i ++){
				if(_isFunction(this.dataControls[i].ValidateEditValue) && !this.dataControls[i].readOnly)
					if(!this.dataControls[i].ValidateEditValue())
						return false;
			}
		}
		return true;
	}

	this.GetAutoIncrementValueMask = function(column){
		switch(column.type){
			case "Guid":
				return "{0:00000000-0000-0000-0000-000000000000}";
			case "String":
				var mask = "{0:";
				for(var i = 0; i < column.maxLength; i ++)
					mask += "0";
				mask += "}";
				return mask;
		}
	}

	this.GenerateAutoIncValue = function(column){
		var autoIncCurrent = column.autoIncCurrent;	
		if(column.type == "String" || column.type == "Guid"){
			var formatStirng = this.GetAutoIncrementValueMask(column);
			autoIncCurrent ++;
			while(this.CheckColumnValueExists(column, null, FormatValue(autoIncCurrent, formatStirng, ""))){
				autoIncCurrent ++;
			}
			column.autoIncCurrent = autoIncCurrent;
			return FormatValue(autoIncCurrent, formatStirng, "");
		}
		if(autoIncCurrent == 0){
			var columnIndex = this.GetColumnIndex(column);
			for(var i = 0; i < this.rows.length; i ++){
				var rowValue = this.rows[i].GetValue(columnIndex);
				if(autoIncCurrent < rowValue)
					autoIncCurrent = rowValue;
			}
		}
		autoIncCurrent ++;
		while(this.CheckColumnValueExists(column, null, autoIncCurrent)){
			autoIncCurrent ++;
		}
		column.autoIncCurrent = autoIncCurrent;
		return autoIncCurrent;		
	}

	this.CheckColumnValueExists = function(column, row, value){
		var columnIndex = this.GetColumnIndex(column);
		for(var i = 0; i < this.rows.length; i ++){
			var curRow = this.rows[i];
			if(curRow != row && _equal(curRow.GetValue(columnIndex), value))
				return true;
		}
		return false;
	}

	this.ValidateValues = function(row, isNewRow){
		for(var i = 0; i < this.columns.length; i ++){
			var column = this.columns[i];
			if(column.autoInc && isNewRow && row.GetValue(i) == null)
				row.SetValueInternal(i, this.GenerateAutoIncValue(column));
			if(!this.IsColumnReadOnly(column)){
				var value = row.GetValue(i);		
				var cancel = false;
				if(!this.ValidateValue.IsEmpty()){
					var args = new ASPxClientDataControllerValidateEventArgs(row, column, value);
					this.ValidateValue.FireEvent(this, args);
					row.SetValueInternal(i, args.value);
					cancel = args.value;
				}
				if(cancel){
					if(args.message != "")
						alert(args.message);
					return false;
				}			
			}
		}
		return true;
	}

	this.CheckConstraints = function(row){
		for(var i = 0; i < this.columns.length; i ++){
			var column = this.columns[i];
			if(!this.IsColumnReadOnly(column)){
				var value = row.GetValue(i);		
				if(!this.IsColumnAllowNull(column) && (value == null)){
					alert("The column '" + column.name + "' cannot contain null values.");
					return false;
				}
				if(column.unique && this.CheckColumnValueExists(column, row, value)){
					alert("The data controller '" + this.name + "' already contains the '" + FormatValue(value, "", "") + "' value in the '" + column.name + "' column.");
					return false;
				}			
			}
		}
		return true;
	}
	this.Post = function(){
		if(!this.postBackOnPostingDataChanges){
		    this._lockDataMode = true;
			var focusedRow = this.GetFocusedRow();
			if(focusedRow != null && this.ListenersValidateEditValues()){
				this.StoreEditValues();	
				if(this.ValidateValues(focusedRow, this.IsInsertMode())){			
					if(this.ConvertRowValues(focusedRow)){
						var processingMode = this.RaiseOnBeforeUpdate(focusedRow, false);
						switch(processingMode){
							case "Client":
								if(this.CheckConstraints(focusedRow)){
									this.OnBeforeUpdate(focusedRow);
									if(!this.IsInsertMode() && focusedRow.originalKeyValue == null)
										focusedRow.FillOriginalKeyValue();	
									focusedRow.SetKeyValue(focusedRow.GetValue(this.keyFieldIndex));
									focusedRow.isNewRow = false;
									if(this.synchronizeDataChanges){
										if(this.IsInsertMode()){								
											this.insertedRows.push(focusedRow);
											this.SynchronizeRows(focusedRow, this.insertedRows, "InsertedRows");
										}
										else{
											if(array_indexOf(this.insertedRows, focusedRow) == -1){
												if(array_indexOf(this.editedRows, focusedRow) == -1)
													this.editedRows.push(focusedRow);
												this.SynchronizeRows(null, this.editedRows, "EditedRows");
											}
											else{
												this.SynchronizeRows(null, this.insertedRows, "InsertedRows");
											}
										}
									}										
									this.SetFocusedRow(focusedRow);	//	in order to refresh the "FocusedRow" hidden input
									this.OnDoUpdate(this.GetFocusedRow());
									this.editedRowValues = null;
									this.SetDataMode("Browse");
									this._lockDataMode = false;
									this.OnAfterUpdate(this.GetFocusedRow());
								}
								this.RaiseOnAfterUpdate(this.GetFocusedRow());
								break;
							case "Server":
								this.SendPostBack(true);
								break;
						}
					}
				}
			}
			this._lockDataMode = false;
		}
	}
	
	this.GetOriginalValueByName = function(columnName){
		return this.GetOriginalValue(this.GetColumnIndexByName(columnName));
	}
	this.GetOriginalValue = function(columnIndex){
		return this.editedRowValues != null && columnIndex > 0 && columnIndex < this.columns.length ? this.editedRowValues[columnIndex] : null;
	}
	this.Cancel = function (){
		var isInsertMode = this.IsInsertMode();	
		var processingMode = this.RaiseOnBeforeCancel(this.GetFocusedRow(), this.processOnServer && isInsertMode && this.GetMaxPageSize() > this.rows.length - 1);
		switch(processingMode){
			case "Client":
				this.OnBeforeCancel(this.GetFocusedRow());
				var newFocusedIndex = -1;
				if(!isInsertMode){
					if(this.editedRowValues != null){
						for(var i = 0; i < this.columns.length; i ++){
							if(!this.IsColumnReadOnly(this.columns[i]))
								this.GetFocusedRow().SetValueInternal(i, this.editedRowValues[i]);
						}
						this.editedRowValues = null;
						this.GetFocusedRow().ClearValuesChanged();
					}
				}
				else{
					newFocusedIndex = this.FindNextFocusedIndex();
					this.RemoveRowInternal(this.GetFocusedRow());
				}
				var row = !isInsertMode ? this.GetFocusedRow() : null;
				this.OnDoCancel(row);
				if(isInsertMode){									
					this.SetFocusedIndex(newFocusedIndex);
					this.SetPrevFocusedInternal(-1);
				}
				this.SetDataMode("Browse");
				this.OnAfterCancel(row);
				this.RaiseOnAfterCancel(row);
				break;
			case "Server":
				this.SendPostBack(true);
				break;
		}
	}

	this.FindNextFocusedIndex = function(){
		var newFocusedIndex = this.focusedIndex;		
		if(newFocusedIndex >= this.rows.length - 1)
			newFocusedIndex --;
		return newFocusedIndex; 
	}

	this.RemoveRowInternal = function(row){
		if(row == this.GetFocusedRow())
			this.SetFocusedIndexInternal(-1);		
		
		var index = row.index;
		array_removeAt(this.rows, index);		
		this.rowCount --;
		if(this.processOnServer && index < this.rows.length){
			var correctionRow = this.rows[index];
			correctionRow.SetIndexOffset(row.GetIndexOffset() + correctionRow.GetIndexOffset());	
		}
		this.RefreshRowIndex();
		if(this.sortedRows != null){
			array_remove(this.sortedRows, index);
			for(var i = 0; i < this.sortedRows.length; i ++){
				if(this.sortedRows[i] > index)
					this.sortedRows[i] --;
			}
		}		
	}

	/*publc*/
	this.DeleteRow = function(row){		
		if(!this.postBackOnPostingDataChanges && !this.readOnly && this.allowDelete){
			if(this.IsInsertMode() && row == this.GetFocusedRow()){
				this.Cancel();
			}
			else{
				if(this.CheckKeyField() && this.ClearCurrentState()){
					var processingMode = this.RaiseOnBeforeDelete(row, this.processOnServer && this.GetMaxPageSize() > this.rows.length - 1);
					switch(processingMode){
						case "Client":
							this.OnBeforeDelete(row);
							var updateFocusedRow = row == this.GetFocusedRow();
							var newFocusedIndex = updateFocusedRow ? this.FindNextFocusedIndex() : null;
							if(array_indexOf(this.rows, row) >= 0){
								this.RemoveRowInternal(row);
								if(this.synchronizeDataChanges){
									if(array_indexOf(this.editedRows, row) >= 0){
										array_remove(this.editedRows, row);
										this.SynchronizeRows(null, this.editedRows, "EditedRows");		
									}
									if(array_indexOf(this.insertedRows, row) >= 0){
										array_remove(this.insertedRows, row);
										this.SynchronizeRows(null, this.insertedRows, "InsertedRows");		
									}
									else{
										this.deletedRows.push(row);
										this.SynchronizeRows(row, this.deletedRows, "DeletedRows");		
									}
								}
							}
							this.OnDoDelete(row);
							if(updateFocusedRow)
								this.SetFocusedIndex(newFocusedIndex);
							this.OnAfterDelete(row);
							this.RaiseOnAfterDelete(row);
							break;
						case "Server":
							this.SendPostBack(true);
							break;
					}
				}
			}
		}
	}

	/*publc*/
	this.Delete = function(){		
		this.DeleteRow(this.GetFocusedRow());
	}
	this.DeleteAllRows = function(){
		if(!this.postBackOnPostingDataChanges && !this.readOnly && this.allowDelete && this.CheckKeyField() && this.ClearCurrentState()){
			this.BeginDataBatchUpdate();
			if(this.synchronizeDataChanges){
				for(var i = 0; i < this.rows.length; i ++){
					var row = this.rows[i];
					if(array_indexOf(this.insertedRows, row) < 0)
						this.deletedRows.push(row);
				}
			}
			this.editedRows = new Array();
			this.insertedRows = new Array();

			this.rows = new Array();
			this.sortedRows = null;
			
			this.SetFocusedRow(null);		
			this.EndDataBatchUpdate();
		}
	}

	this.RowValueChanged = function(row, index) {
		return row.GetValuesChangedInternal() != null && row.GetValuesChangedInternal()[index];
	}
	this.AddSynchronizedRow = function(input, dataRow, rowChangesType){
		if(input.value != "")
			input.value += RecordDelimiter;
		input.value += rowChangesType == "EditedRows" ? dataRow.originalKeyValue : dataRow.GetKeyValue();
		if(rowChangesType != "DeletedRows"){
			for(var i = 0; i < this.columns.length; i ++){
				if(this.RowValueChanged(dataRow, i)) {
					var type = this.columns[i].GetType();
					var format = (type == "DateTime" ? "{0:MM/dd/yyyy HH:mm:ss fff}" : "");
					input.value += FieldDelimiter + this.columns[i].name + FieldNameDelimiter + FormatValue(dataRow.GetValue(i), format, type);
				}
			}
		}	
	}

	this.SynchronizeRows = function(dataRow, sinchronizationRowList, rowChangesType){
		if(this._lockDataChangesSync == 0){
			var input = _getHiddenInput(this.name + rowChangesType);
			if(input != null){
				if(dataRow != null){
					this.AddSynchronizedRow(input, dataRow, rowChangesType);
				}
				else{
					input.value = "";
					for(var i = 0; i < sinchronizationRowList.length; i ++){
						this.AddSynchronizedRow(input, sinchronizationRowList[i], rowChangesType);
					}
				}	
			}
		}
	}

	this.CheckHiddenInputEmpty = function(rowChangesType){
		var input = _getHiddenInput(this.name + rowChangesType);
		if(input != null)
			return input.value == null || input.value.length == 0;
		return true;
	}
	
	this.HasDataChanges = function(){
		return !this.CheckHiddenInputEmpty("InsertedRows") || !this.CheckHiddenInputEmpty("EditedRows") || !this.CheckHiddenInputEmpty("DeletedRows");
	}
	
	this.GetConfirmUnsavedChanges = function(){
		return this.confirmUnsavedChanges && this.HasDataChanges();
	}
	this.GetConfirmUnsavedChangesMessage = function(){
		return this.confirmUnsavedChangesMessage;
	}
	this.BeginDataBatchUpdate = function(){
		this._lockDataChangesSync ++;
	}
	this.EndDataBatchUpdate = function(){
		this._lockDataChangesSync --;
		if(this._lockDataChangesSync == 0){
			this.SynchronizeRows(null, this.insertedRows, "InsertedRows");		
			this.SynchronizeRows(null, this.editedRows, "EditedRows");		
			this.SynchronizeRows(null, this.deletedRows, "DeletedRows");		
			
			this.SetPrevFocusedInternal(this.prevFocusedIndex);
			this.SetFocusedIndexInternal(this.focusedIndex);
			this.SetDataModeInternal(this.dataMode);	
			
			this.OnEndDataBatchUpdate();
			this.OnFocusedChanged(this.GetFocusedRow());
		}
	}

	this.Navigatable_MoveFirst = function(evt, barName, btnIndex){
		this.MoveFirst();		
	}
	this.Navigatable_MovePrev = function(evt, barName, btnIndex){
		this.MovePrev();
	}
	this.Navigatable_MoveNext = function(evt, barName, btnIndex){
		this.MoveNext();
	}
	this.Navigatable_MoveLast = function(evt, barName, btnIndex){
		this.MoveLast();
	}
	this.Navigatable_NewRow = function(evt, barName, btnIndex, append){
		this.New(append);
	}
	this.Navigatable_StartEdit = function(evt, barName, btnIndex){
		this.Edit();
	}
	this.Navigatable_DeleteRow = function(evt, barName, btnIndex){
		this.Delete();
	}
	this.Navigatable_PostChanges = function(evt, barName, btnIndex){
		this.Post();
	}
	this.Navigatable_CancelEdit = function(evt, barName, btnIndex){
		this.Cancel();
	}
	this.Navigatable_SearchRow = function(evt, barName, btnIndex, searchColumnIndex, searchString){
		this.DoSearchRow(searchColumnIndex, searchString);
	}

	this.SendPostBack = function(omitEvent){
		for(var i = 0; i < this.dataControls.length; i ++){
			if(_isFunction(this.dataControls[i].BeforePostBack))
				this.dataControls[i].BeforePostBack();
		}
		__sendASPxPostBack(omitEvent);
	}

	GetDataControllerCollection().Add(this);
	if(_isFunctionType(typeof(GetNavigatableCollection)))
		GetNavigatableCollection().Add(this);
}
ASPxClientDataController.GetDataControllerCollection = function(){
	return GetDataControllerCollection();
}
function ASPxClientDataControllerRow(owner, indexOffset, values, index){
	this.owner = owner;
	this.indexOffset = indexOffset;
	this.values;	
	
	if(values != null){
		this.values = values;
	}
	else{
		this.values = new Array();
		for(var i = 0; i < this.owner.columns.length; i++){
			this.values.push(null);
		}
	}
	
	this.keyValue = null;
	this.originalKeyValue = null;
	this.isNewRow = false;
	this.index = index;
	this.valuesChanged = null;
	this.GetIndex = ASPxClientDataControllerRow.GetIndex;	
	this.SetIndex = ASPxClientDataControllerRow.SetIndex;
	this.GetIndexOffset = ASPxClientDataControllerRow.GetIndexOffset;
	this.SetIndexOffset = ASPxClientDataControllerRow.SetIndexOffset;
	this.FillOriginalKeyValue = ASPxClientDataControllerRow.FillOriginalKeyValue;
	this.GetValue = ASPxClientDataControllerRow.GetValue;
	this.GetValueByColumnName = ASPxClientDataControllerRow.GetValueByColumnName;
	this.GetValueByFieldName = ASPxClientDataControllerRow.GetValueByFieldName;
	this.SetValueInternal = ASPxClientDataControllerRow.SetValueInternal;
	this.SetValue = ASPxClientDataControllerRow.SetValue;
	this.SetValueByColumnName = ASPxClientDataControllerRow.SetValueByColumnName;
	this.SetValueByFieldName = ASPxClientDataControllerRow.SetValueByFieldName;
	this.GetKeyValue = ASPxClientDataControllerRow.GetKeyValue;
	this.SetKeyValue = ASPxClientDataControllerRow.SetKeyValue;
	this.GetValuesChanged = ASPxClientDataControllerRow.GetValuesChanged;
	this.GetValuesChangedInternal = ASPxClientDataControllerRow.GetValuesChangedInternal;
	this.ClearValuesChanged = ASPxClientDataControllerRow.ClearValuesChanged;

}

ASPxClientDataControllerRow.GetIndex = function(){
	return this.owner.GetRowIndex(this);
}

ASPxClientDataControllerRow.SetIndex = function(index){
	this.index = index;
}

ASPxClientDataControllerRow.GetIndexOffset = function(){
	return this.indexOffset;
}

ASPxClientDataControllerRow.SetIndexOffset = function(indexOffset){
	this.indexOffset = indexOffset;
}

ASPxClientDataControllerRow.FillOriginalKeyValue = function(){
	if(this.originalKeyValue == null)
		this.originalKeyValue = this.keyValue;
}

ASPxClientDataControllerRow.GetValue = function(index){
	if(index >= 0 && index < this.values.length)
		return this.values[index];
	return null;
}

ASPxClientDataControllerRow.GetValueByColumnName = function(columnName){
	columnIndex = this.owner.GetColumnIndexByName(columnName);
	if(columnIndex >= 0)
		return this.values[columnIndex];
	return null;
}

ASPxClientDataControllerRow.GetValueByFieldName = function(fieldName){
	return this.GetValueByColumnName(fieldName);
}

ASPxClientDataControllerRow.SetValueInternal = function(index, value){
	if(index >= 0 && index < this.values.length){
		var column = this.owner.columns[index];
		if(value != null && column.maxLength > 0)
			value = value.substr(0, column.maxLength);
		if(!_equal(this.values[index], value)){	
			this.values[index] = value;
			this.GetValuesChanged()[index] = true;
			this.owner.ValueChanged(index, value);
		}
	}
}

ASPxClientDataControllerRow.SetValue = function(index, value){
	if(index >= 0 && index < this.values.length){
		if(this.owner.IsColumnReadOnly(this.owner.columns[index])){
			alert("The value of the '" + this.owner.columns[index].name + "' column cannot be changed.");
			return;
		}
		this.SetValueInternal(index, value);
	}
}

ASPxClientDataControllerRow.SetValueByColumnName = function(columnName, value){
	columnIndex = this.owner.GetColumnIndexByName(columnName);
	if(columnIndex >= 0)
		this.SetValue(columnIndex, value);
}

ASPxClientDataControllerRow.SetValueByFieldName = function(fieldName, value){
	this.SetValueByColumnName(fieldName, value);
}

ASPxClientDataControllerRow.GetKeyValue = function(){
	return this.keyValue;
}

ASPxClientDataControllerRow.SetKeyValue = function(value){
	this.keyValue = value;
}
ASPxClientDataControllerRow.GetValuesChanged = function(){
	if(this.valuesChanged == null) {
		this.valuesChanged = new Array();
		for(var i = 0; i < this.owner.columns.length; i++) {
			this.valuesChanged.push(false);
		}
	}
	return this.valuesChanged;
}

ASPxClientDataControllerRow.GetValuesChangedInternal = function(){
	return this.valuesChanged;
}

ASPxClientDataControllerRow.ClearValuesChanged = function(){
	this.valuesChanged = null;
}
function ASPxClientDataControllerColumn(owner, name, type){
	this.owner = owner;
	this.name = name;
	this.type = type;
	
	this.readOnly = false;
	this.autoInc = false;
	this.allowNull = true;
	this.unique = false;	
	this.maxLength = -1;
	
	this.autoIncCurrent = 0;
	this.GetName = function(){
		return this.name;
	}
	this.GetDataField = function(){
		return this.name;
	}
	this.GetType = function(){
		return this.type;
	}
	this.GetIndex = function(){
		return this.owner.GetColumnIndex(this);
	}
	this.IsReadOnly = function(){	
		return this.owner.IsColumnReadOnly(this);
	}
	this.GetReadOnly = function(){
		return this.readOnly;
	}
	this.GetAutoIncrement = function(){
		return this.autoInc;
	}
	this.GetAllowNull = function(){
		return this.allowNull;
	}
	this.GetUnique = function(){
		return this.unique;
	}
	this.GetMaxLength = function(){
		return this.maxLength;
	}
}

function GetDataControllerCollection(){
	if(__ASPxDataControllerCollection == null){
		__ASPxDataControllerCollection = new ASPxClientCollection();
	}
	return __ASPxDataControllerCollection;
}

var DataControllerFirstLoad;
if(typeof(ASPxDataControllerSavedWindowOnLoad) == "undefined"){
	var __ASPxDataControllerCollection = null;
	var ASPxDataControllerSavedWindowOnLoad = window.onload;
	DataControllerFirstLoad = true;
}
	
window.onload = function(){
	if(DataControllerFirstLoad){
		GetDataControllerCollection().Initialize(true);
		DataControllerFirstLoad = false;
	}
	else
		window.setTimeout("GetDataControllerCollection().Initialize(false)", 0);
		
	if(ASPxDataControllerSavedWindowOnLoad != null)
		return ASPxDataControllerSavedWindowOnLoad();
	return true;
}

var isSubmit = false;
var savedFormSubmits = new Array();

window.onbeforeunload = function(){
	if(!isSubmit){
		var dataControllerCollection = GetDataControllerCollection();
		for(var i = 0; i < dataControllerCollection.GetItemCount(); i ++){
			var dataController = dataControllerCollection.GetItem(i);
			if(dataController.GetConfirmUnsavedChanges()){
				return dataController.GetConfirmUnsavedChangesMessage();
			}
		}
	}
	isSubmit = false;
}