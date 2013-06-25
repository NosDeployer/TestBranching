
var nullValueKey = "@$null$@";
function ASPxClientGrid(name, dataControllerName){
	this.inherit = ASPxClientGridCore;
	this.inherit(name);
	
	this.dataControllerName = dataControllerName;
	this.dataController = null;			
	this.clientSideMode = true;
	this.processOnServer = false;
	
	this.navigators = new Array();
	
	this.sortColumns = new Array();
	this.visibleColumns = new Array();
	this.rows = new Array();
	this.rowsCache = new Array();
	this.visibleRows = new Array();
	this.rowsIndex = new Array();
	this.hideSelectionNeeded = false;
	this.rootRows = null;
	this.serverCreatedRows = null;
	
	this.firstVisibleRowId = "";	//	for initialization purposes only
	this.focusedRowId = "";	//	for initialization purposes only
	this.sampleRowId = "";	//	for initialization purposes only
	this.sampleRow = null;
	this.savedDeletedRow = null;
	
	this.groupSummary = new Array();
	this.totalSummary = new Array();
	this.summaryValues = null;
	this.summaryCount = 0;
	
	this.firstVisibleIndex = -1;
	this.focusedIndex = -1;
	this.focusedPos = 0;
	this.prevFocusedPos = 0;
	this.activateEditing = false;
	this.buttonBars = new Array();
	this.statusBars = new Array();
	this.searchColumnIndex = -1;
	this.searchString = "";
	this.focusedColumn = null;
	this.focusedColumnVisibleIndex = -1;	
	this.widthChanged = false;	
	this.groupingChanged = false;
	
	this.rowCount = 0;
	this.visibleRowCount = 0;
	this.firstDataRowIndex = 0;
	this.firstVisibleRowOffset = 0;
		
	this.statusText = "Ok";
	this.pageIndexButtonCount = 10;
	
	this.previewFieldIndex = -1;
		
	this.cancelChanges = false;
	this.autoExpand = false;
	this.autoCollapse = false;
	this.enableGroupingButtons = false;
	this.keepEditing = false;
	this.useExtendedGroupRowKeys = false;
	this.fixedPageNavigation = false;	
	this.multiSorting = true;
	this.hideGroupedColumns = true;
	this.keepWidth = false;
		
	this.showIndicator = true;	

	this.postBackOnSortingAndGrouping = false;
	this.postBackOnPageSizeChanging = false;
	this.postBackOnEnteringEditMode = false;
	this.postBackOnPostingDataChanges = false;
	
	this.startFromFirst = true;
	this.searchForward = true;		
	this.keepSearching = true;
	this.cycleSearching = true;		
	this.ignoreCase = true;		
	this.partialSearch = "BeginsWith";	
	this.incrementalSearch = false;				
	
	this.itemTemplate = null;
	this.editItemTemplate = null;
	this.headerTemplate = null;
	this.footerTemplate = null;
	this.groupItemTemplate = null;
	this.rowBtnTemplate = null;
	this.barBtnTemplate = null;
	this.expandBtnTemplate = null;
	this.statusBarSectionTemplate = null;
	this.titleTemplate = null;
	this.groupPanelTemplate = null;	
	this.previewTemplate = null;	

	this.resolvedItemStyle = null;
	this.resolvedAltItemStyle = null;
	this.resolvedPreviewStyle = null;
	this.resolvedGroupItemStyle = null;
	
	this._lockFcsdChng = false;
	this._lockRenderCount = 0;		
	this._lockSearchState = false;
	this._lockWidthSynchronization = false;
	this._savedInserMode = false;
	
	this.rowListRecreated = false;
	this.invalidateColumns = false;		
	this.invalidateButtons = false;		
	this.invalidateHeaders = false;				
	this.invalidateRows = false;
	this.resetVertScrollBar = true;
	this.invalidateRowShift = 0;		
	this.invalidateFocusedRow = false;
	this.invalidateSearchItem = false;	
	this.invalidateFooter = false;		
	this.invalidateRowArray = new Array();
	this.invalidateExpandedRowArray = new Array();
	this.invalidateColumnArray = new Array();
	this.invalidateSelection = true;	
	this.fitScrollerWidth = false;		
	this.updateScrollBars = false;	
	this.groupingCorrection = 0;
	
	this.htmlRender = new ASPxGridRender(this);
	
	this.lookAndFeel = null;
	this.headerStyle = ASPxStyle.CreateStyle();
	this.headerHotTrackStyle = ASPxStyle.CreateStyle();
	this.headerPressedStyle = ASPxStyle.CreateStyle();
	this.groupedHeaderStyle = ASPxStyle.CreateStyle();
	this.groupedHeaderHotTrackStyle = ASPxStyle.CreateStyle();
	this.groupedHeaderPressedStyle = ASPxStyle.CreateStyle();
	this.expandBtnStyle = ASPxStyle.CreateStyle();
	this.expandBtnHotTrackStyle = ASPxStyle.CreateStyle();
	this.expandBtnPressedStyle = ASPxStyle.CreateStyle();
	this.rowBtnStyle = ASPxStyle.CreateStyle();
	this.rowBtnHotTrackStyle = ASPxStyle.CreateStyle();
	this.rowBtnPressedStyle = ASPxStyle.CreateStyle();
	this.barBtnStyle = ASPxStyle.CreateStyle();
	this.barBtnHotTrackStyle = ASPxStyle.CreateStyle();
	this.barBtnPressedStyle = ASPxStyle.CreateStyle();
	this.searchBtnStyle = ASPxStyle.CreateStyle();
	this.searchBtnHotTrackStyle = ASPxStyle.CreateStyle();
	this.searchBtnPressedStyle = ASPxStyle.CreateStyle();
	this.searchEditorStyle = ASPxStyle.CreateStyle();
	this.altItemStyle = ASPxStyle.CreateStyle();
	this.groupIndentStyle = ASPxStyle.CreateStyle();
	this.editItemStyle = ASPxStyle.CreateStyle();
	this.footerItemStyle = ASPxStyle.CreateStyle();
	this.searchItemStyle = ASPxStyle.CreateStyle();
	this.statusBarStyle = ASPxStyle.CreateStyle();
	this.Init = new ASPxClientEvent();
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
	this.ValidateColumnValue = new ASPxClientEvent();
	this.FocusedRowChanging = new ASPxClientEvent();
	this.FocusedRowChanged = new ASPxClientEvent();
	this.FocusedColumnChanging = new ASPxClientEvent();
	this.FocusedColumnChanged = new ASPxClientEvent();
	this.FirstVisibleRowChanging = new ASPxClientEvent();
	this.FirstVisibleRowChanged = new ASPxClientEvent();
	this.CompareRows = new ASPxClientEvent();
	this.HeaderClick = new ASPxClientEvent();
	this.HeaderDragEnd = new ASPxClientEvent();
	this.GroupingButtonClick = new ASPxClientEvent();
	this.RowClick = new ASPxClientEvent();
	this.RowDblClick = new ASPxClientEvent();
	this.FocusedRowClick = new ASPxClientEvent();
	this.BarButtonClick = new ASPxClientEvent();
	this.CustomRenderBarBtn = new ASPxClientEvent();
	this.CustomRenderPageIndexBtn = new ASPxClientEvent();
	this.CustomRenderStatusBarSection = new ASPxClientEvent();
	this.BindStatusBarSection = new ASPxClientEvent();
	this.RowButtonClick = new ASPxClientEvent();
	this.ExpandButtonClick = new ASPxClientEvent();
	this.SearchButtonClick = new ASPxClientEvent();
	this.ColumnSorting = new ASPxClientEvent();
	this.ColumnSorted = new ASPxClientEvent();
	this.GroupIndexChanging = new ASPxClientEvent();
	this.GroupIndexChanged = new ASPxClientEvent();
	this.ColumnMoving = new ASPxClientEvent();
	this.ColumnMoved = new ASPxClientEvent();
	this.ColumnWidthChanging = new ASPxClientEvent();
	this.ColumnWidthChanged = new ASPxClientEvent();
	this.PageSizeChanging = new ASPxClientEvent();
	this.PageSizeChanged = new ASPxClientEvent();
	this.RowExpanding = new ASPxClientEvent();
	this.RowExpanded = new ASPxClientEvent();
	this.RowSelectedChanging = new ASPxClientEvent();
	this.RowSelectedChanged = new ASPxClientEvent();
	this.CustomSummary = new ASPxClientEvent();
	this.CompleteSummary = new ASPxClientEvent();
	this.BeforeSearch = new ASPxClientEvent();
	this.AfterSearch = new ASPxClientEvent();
	this.CustomRenderCell = new ASPxClientEvent();
	this.CustomRenderEditCell = new ASPxClientEvent();
	this.CustomRenderHeader = new ASPxClientEvent();
	this.CustomRenderFooter = new ASPxClientEvent();
	this.CustomRenderGroupItem = new ASPxClientEvent();
	this.CustomRenderRowBtn = new ASPxClientEvent();
	this.CustomRenderExpandBtn = new ASPxClientEvent();
	this.CustomRenderTitle = new ASPxClientEvent();
	this.CustomRenderGroupPanel = new ASPxClientEvent();
	this.CustomRenderPreview = new ASPxClientEvent();
	this.BindCell = new ASPxClientEvent();
	this.BindEditCell = new ASPxClientEvent();
	this.BindGroupingCell = new ASPxClientEvent();
	this.BindPreview = new ASPxClientEvent();
	this.GetCellValue = new ASPxClientEvent();
	this.GetEditValue = new ASPxClientEvent();
	this.GetGroupingText = new ASPxClientEvent();
	this.ItemRendered = new ASPxClientEvent();	
	this.GetDataController = function (){
		if(_isFunctionType(typeof(GetDataControllerCollection)))
			return GetDataControllerCollection().Get(this.dataControllerName);
		return null;
	}

	this.AddColumn = function(index, type, fieldIndex, visibleIndex, isInternal){
		var column = new ASPxClientGridColumn(this, index, type, fieldIndex, visibleIndex);
		this.columns[index] = column;
		return column;
	}
	this.GetColumnCount = function (){
		return this.columns.length;
	}
	this.GetColumn = function (index){
		if(index >= 0 && index < this.columns.length)
			return this.columns[index];
		return null;
	}	
	this.GetVisibleColumn = function (index){
		if(index >= 0 && index < this.visibleColumns.length)
			return this.visibleColumns[index];
		return null;
	}
	this.GetVisibleColumnCount = function (){
		return this.visibleColumns.length;
	}	
	this.GetColumnByFieldName = function (fieldName){
		for(var i = 0, columnCount = this.columns.length; i < columnCount; i ++){
			var dataControllerColumn = this.columns[i].GetDataControllerColumn();
			if(dataControllerColumn != null && dataControllerColumn.name == fieldName)
				return this.columns[i];
		}	
		return null;
	}
	this.GetGroupCount = function (){
		return this.groupColumns.length;
	}	
	this.GetGroupColumn = function (index){
		if(index >= 0 && index < this.groupColumns.length)
			return this.groupColumns[index];
		return null;
	}
	this.GetSortedCount = function (){
		return this.sortColumns.length;
	}	
	this.GetSortedColumn = function (index){
		if(index >= 0 && index < this.sortColumns.length)
			return this.sortColumns[index];
		return null;
	}
	this.GetGroupSummaryCount = function(){
		return this.groupSummary.length;
	}	
	this.GetGroupSummaryItem = function(index){
		if(index >= 0 && index < this.groupSummary.length)
			return this.groupSummary[index];
		return null;
	}
	this.GetRowCount = function (){
		return !this.processOnServer ? this.GetRowCountInternal() : this.rowCount;
	}
	this.GetRowCountInternal = function (){
		return this.rows.length;
	}	
	this.GetRow = function (index){
		if(!this.processOnServer){
			return this.GetRowInternal(index);
		}
		else{
			for(var i = 0, rowCount = this.rows.length; i < rowCount; i ++){
				if(this.rows[i].GetIndex() == index)
					return this.rows[i];
			}
		}
		return null;
	}
	
	this.GetRowInternal = function (index){
		if(index >= 0 && index < this.rows.length)
			return this.rows[index];
		return null;
	}
	
	this.IncRowCount = function(increment){
		this.rowCount += increment;
		this.visibleRowCount += increment;
	}
	this.GetSelectedRowCount = function (){
		if(this.multiSelection)
			return this.selectedRows.length;
		return this.GetFocusedRow() != null ? 1 : 0;
	}	
	this.GetSelectedRow = function (index){
		if(this.multiSelection){
			if(index >= 0 && index < this.selectedRows.length)
				return this.selectedRows[index];
		}
		if(index == 0)
			return this.GetFocusedRow();
		return null;
	}

	this.GetRootRowArray = function (){
		if(this.rootRows == null){
			this.rootRows = new Array();
			for(var i = 0, rowCount = this.rows.length; i < rowCount; i ++){
				if(this.rows[i].GetLevel() == 0)
					this.rootRows.push(this.rows[i]);
			}
		}
		return this.rootRows;
	}
	this.GetRootRowCount = function (){
		return this.GetRootRowArray().length;
	}	
	this.GetRootRow = function (index){
		if(index >= 0 && index < this.GetRootRowCount())
			return this.GetRootRowArray()[index];
		return null;
	}	
	this.GetFocusedRow = function (){
		if(this.focusedIndex >= 0)
			return this.rows[this.focusedIndex];
		return null;
	}	
	this.SetFocusedRow = function (row){
		if(this.CheckBrowseMode()){
			this.BeginUpdateInternal(false);
			this.SetFocusedIndex(row != null ? row.internalIndex : -1);
			this.EndUpdate();
		}
	}

	this.GetVisibleRowCount = function (){
		return !this.processOnServer ? this.GetVisibleRowCountInternal() : this.visibleRowCount;
	}
	this.GetVisibleRowCountInternal = function (){
		return this.visibleRows.length;
	}
	this.GetVisibleRow = function (index){
		if(!this.clientSideExpanding){
			if(index >= 0 && index < this.visibleRows.length)
				return this.rows[this.visibleRows[index]];
		}
		else{
			return this.GetRow(index);
		}
		return null;		
	}
	this.GetFirstVisibleRow = function (){	
		if(this.firstVisibleIndex >= 0)
			return this.GetRow(this.visibleRows[this.firstVisibleIndex]);
		return null;
	}
	this.SetFirstVisibleRow = function (row){	
		var rowIndex = row.GetIndex();
		if(rowIndex >= 0 && rowIndex != this.firstVisibleIndex && (this.pageSize > 0 || rowIndex == 0) && this.CheckBrowseMode()){
			this.BeginUpdateInternal(false);
			this.SetFirstVisibleRowInternal(row);
			row = this.GetFirstVisibleRow();
			this.ExpandRowParents(row);
			if(this.focusedIndex >= 0){
				if(this.focusedPos >= this.GetCurVisibleRowCount())
					this.SetFocusedIndex(this.visibleRows[this.GetVisibleRowCount() - 1]);			
				else
					this.SetFocusedIndex(this.visibleRows[row.GetVisibleIndex() + this.focusedPos]);
			}
			this.EndUpdate();
		}
	}

	this.GetFirstVisibleIndex = function (){
		return this.GetFirstVisibleIndexInternal() + this.firstVisibleRowOffset;
	}
	this.GetFirstVisibleIndexInternal = function (){
		return this.firstVisibleIndex;
	}
	this.GetPageSize = function (){
		return this.pageSize;
	}
	this.SetPageSize = function (pageSize){		
		pageSize = Number(pageSize);
		if(this.pageSize != pageSize){
			var processingMode = this.OnPageSizeChanging(pageSize, this.processOnServer);
			switch(processingMode){
				case "Client":
					this.BeginUpdateInternal(false);			
					var pageModeChanged = this.pageSize == 0 || pageSize == 0;
					this.pageSize = pageSize;		
					_getElementById(this.name + "PageSize").value = pageSize;
					this.CorrectFirstVisible();
					this.SynchronizeFocusedPos();	
					this.NavigatorsPageSizeChanged();
					this.PageSizeChangedInternal();
					this.EndUpdate();
					if(pageModeChanged && this.NeedToCorrectWidth())
						this.SynchronizeTotalWidth();
					this.OnPageSizeChanged();
					break;
				case "Server":
					this.SendPostBack(true);
			}
		}
	}
	this.GetDataMode = function (){
		if(this.dataController != null && !this.readOnly)
			return this.dataController.dataMode;
		return "Browse";
	}

	this.FocusColumn = function(columnIndex){
		this.SetFocusedColumn(this.columns[columnIndex]);
	}
	this.GetFocusedColumn = function (){
		if(this.focusedColumnIndex >= 0)
			return this.columns[this.focusedColumnIndex];
		return null;
	}
	this.SetFocusedColumn = function (focusedColumn){
		this.BeginUpdateInternal(false);
		var focusedColumnIndex = array_indexOf(this.columns, focusedColumn);
		this.SetFocusedColumnIndex(focusedColumnIndex);
		this.EndUpdate();
	}
	this.GetStatusText = function (){
		return this.statusText;
	}
	this.SetStatusText = function (statusText){
		this.statusText = statusText;
		this.NavigatorsStatusTextChanged();
	}

	this.GetRecordCount = function (){
		return this.dataController.GetRowCount();
	}
	this.GetPageCount = function (){
		if(this.pageSize == 0)
			return 1;
		return Math.ceil(this.GetVisibleRowCount() / this.pageSize);
	}
	this.GetCurrentPageIndex = function (){
		if(this.pageSize == 0)
			return 0;
		var currentPageIndex = Math.ceil(this.GetFirstVisibleIndex() / this.pageSize);
		return currentPageIndex < this.GetPageCount() ? currentPageIndex : this.GetPageCount() - 1;
	}
	this.SetCurrentPageIndex = function (currentPageIndex){
		var newFirstVisibleIndex = currentPageIndex * this.GetPageSize();
		if(newFirstVisibleIndex + this.GetPageSize() > this.GetVisibleRowCount() && !this.fixedPageNavigation) 
			newFirstVisibleIndex = this.GetVisibleRowCount() - this.GetPageSize();
		var newFirstVisibleRow = this.GetVisibleRow(newFirstVisibleIndex);
		if(newFirstVisibleRow != null)
			this.SetFirstVisibleRow(newFirstVisibleRow);
	}

	this.GetCurrentSearchColumnIndex = function(){
		return this.searchColumnIndex;
	}
	this.GetCurrentSearchString = function(){
		return this.searchString;
	}
	this.CanIncrementalSearch = function(){
		return this.incrementalSearch;
	}
	this.GetRowIdPrefix = function(row){
		return row == null || row.GetLevel() >= this.groupColumns.length ? getDataRowMark() : (row.GetExpanded() ? getExpandedRowMark() : getCollapsedRowMark());
	}	
	this.GetWidth = function (){	
		return this.width;
	}
	this.WidthChanged = function (){
		if(!this.keepWidth)
			this.widthChanged = true;
	}
	this.GetButtonBarCount = function (){
		return this.buttonBars.length;
	}	
	this.GetButtonBar = function (index){
		if(index >= 0 && index < this.buttonBars.length)
			return GetDataNavigatorCollection().Get(this.buttonBars[index]);
		return null;
	}
	this.GetStatusBarCount = function (){
		return this.statusBars.length;
	}	
	this.GetStatusBar = function (index){
		if(index >= 0 && index < this.statusBars.length)
			return GetDataNavigatorCollection().Get(this.statusBars[index]);
		return null;
	}	
	
	this.GetResolvedItemStyle = function(){
		if(this.resolvedItemStyle == null){
			this.resolvedItemStyle = ASPxStyle.CreateStyle();
			this.resolvedItemStyle.MergeStyle(GetLookAndFeelStyleCollection().GetDataItemStyle(GetStyleName(this.name + "DataItem"), this.lookAndFeel));
		}
		return this.resolvedItemStyle;
	}
	this.GetResolvedAltItemStyle = function(){
		if(this.resolvedAltItemStyle == null){
			this.resolvedAltItemStyle = ASPxStyle.CreateStyle();
			this.resolvedAltItemStyle.MergeStyle(this.GetResolvedItemStyle());
			this.resolvedAltItemStyle.MergeStyle(this.altItemStyle);		
		}
		return this.resolvedAltItemStyle;
	}
	this.GetResolvedPreviewStyle = function(){
		if(this.resolvedPreviewStyle == null){
			this.resolvedPreviewStyle = ASPxStyle.CreateStyle();
			this.resolvedPreviewStyle.MergeStyle(GetLookAndFeelStyleCollection().GetPreviewStyle(GetStyleName(this.name + "Preview"), this.lookAndFeel));
		}
		return this.resolvedPreviewStyle;
	}
	this.GetResolvedGroupItemStyle = function(){
		if(this.resolvedGroupItemStyle == null){
			this.resolvedGroupItemStyle = ASPxStyle.CreateStyle();
			this.resolvedGroupItemStyle.MergeStyle(GetLookAndFeelStyleCollection().GetGroupItemStyle(GetStyleName(this.name + "GroupItem"), this.lookAndFeel));
		}
		return this.resolvedGroupItemStyle;
	}

	this.CorrectVisibleIndexes = function(){
		for(var i = 0, visibleColumnCount = this.visibleColumns.length; i < visibleColumnCount; i ++){
			this.visibleColumns[i].SetVisibleIndexInternal(i);
		}
	}
	
	this.CorrectSortingIndexes = function(){
		for(var i = 0, sortColumnCount = this.sortColumns.length; i < sortColumnCount; i ++){
			this.sortColumns[i].SetSortingIndexInternal(i);
		}
	}
	
	this.CorrectGroupIndexes = function(){
		for(var i = 0, groupColumnCount = this.groupColumns.length; i < groupColumnCount; i ++){
			this.groupColumns[i].SetGroupIndexInternal(i);
		}
	}

	this.CorrectEmptySpace = function(){
		var firstVisibleIndex = this.GetFirstVisibleIndex();
		var newFirstVisibleIndex = 0;
		if(this.GetPageSize() > 0){
			var newFirstVisibleIndex = firstVisibleIndex;
			while(this.GetVisibleRowCount() < this.GetPageSize() + newFirstVisibleIndex && newFirstVisibleIndex > 0)
				newFirstVisibleIndex--;
		}
		if(firstVisibleIndex != newFirstVisibleIndex)
			this.SetFirstVisibleIndex(newFirstVisibleIndex);
	}

	this.AddButtonBar = function (name){		
		this.buttonBars.push(name);
	}
	
	this.AddStatusBar = function (name){		
		this.statusBars.push(name);
	} 	
				
	this.AddSummaryItem = function (summaryType, fieldIndex, showInColumnIndex, displayFormat, isTotal){	
		if(isTotal){
			this.totalSummary.push(new ASPxClientGridSummaryItem(this, summaryType, fieldIndex, showInColumnIndex, displayFormat));
			this.columns[showInColumnIndex].summaryItem = array_lastElement(this.totalSummary);
		}
		else{
			this.groupSummary.push(new ASPxClientGridSummaryItem(this, summaryType, fieldIndex, 0, displayFormat));
		}
	}
	
	this.AddNavigator = function(navigator){
		if(array_indexOf(this.navigators, navigator) == -1)
			this.navigators.push(navigator);
	}	
	this.Initialize = function(){
		this.InitializeInternal(true, false);
	}
	this.OnInit = function(){
		if(!this.Init.IsEmpty()){
			var eventArgs = new ASPxClientEventArgs();
			this.Init.FireEvent(this, eventArgs);		
		}
	}
	
	this.baseInitializeInternal = this.InitializeInternal;
	this.InitializeInternal = function(checkInitialized, internalCall){
		if(!internalCall || this.initializationMode == "Startup" || (this.initializationMode == "Automatic" && this.IsDisplayed()))
			this.baseInitializeInternal(checkInitialized, internalCall);
	}
	this.baseInitializeControl = this.InitializeControl;
	this.InitializeControl = function(){
		this.baseInitializeControl();
		
		this.BeginUpdateInternal(false);
		this.dataController = this.GetDataController();
		if(this.dataController != null){
			this.dataController.AddDataControl(this);
			this.dataController.CheckInitialized();
		}
			
		this.RefreshLists();		
		this.InitializeTemplates();
		this.CreateInternalColumns();
		
		if(!this.IsServerSideRender())
			this.CreateRowList(true, 0, 0);
		else
			this.ProcessServerCreatedRows();	
		
		if(this.firstVisibleRowId != ""){
			var firstVisibleRow = this.GetRowById(this.firstVisibleRowId);
			if(firstVisibleRow != null)
				this.SetFirstVisibleIndex(firstVisibleRow.GetVisibleIndex());
		}
		this.CorrectFirstVisible();
		if(this.IsInsertMode()){
			var sampleRow = this.sampleRowId != "" ? this.GetRowById(this.sampleRowId) : null;
			this.SetSampleRow(sampleRow);
			if(!this.IsServerSideRender())
				this.InsertNewRowToList(this.dataController.GetFocusedRow(), this.GetDataMode() == "Append");
		}
		if(!this.IsInsertMode() || this.IsServerSideRender()){
			if(this.focusedRowId != ""){
				var focusedRow = this.GetRowById(this.focusedRowId);
				if(focusedRow != null)
					this.SetFocusedIndex(focusedRow.GetInternalIndex());
			}
		}
		
		if(this.IsServerSideRender()){			
			this.ClearInvalidationFlags();
			this.invalidateSelection = true;
		}		
	}
	this.InitializeControlRender = function(){
		this.htmlRender.Initialize();		
		this.EndUpdate();		
		this.SynchronizeInitialColumnsWidth();
		if(this.width.type == "%")
			this.SynchronizeTotalWidth();
	}
	
	this.InitializeExpandRows = function (){
		var expandRows = _getElementById(this.name + "ExpandedRows").value;	
		while(expandRows.length > 0){
			var _indexOf = expandRows.indexOf(";");
			if(_indexOf == -1)
				_indexOf = expandRows.length;
			var rowId = expandRows.substr(0, _indexOf);
			var row = this.GetRowById(rowId);
			if(row != null){
				row.SetExpandedInternal(true);
				this.SetRowVisible(row.index, true);
			}
			expandRows = _indexOf < expandRows.length ? expandRows.substr(_indexOf + 1, expandRows.length) : "";
		}
		this.RefreshVisibleList();
	}
	
	this.InitializeSelectedRows = function (){
		for(var i = 0, selectedRowCount = this.selectedRows.length; i < selectedRowCount; i ++){
			this.GetRowById(this.selectedRows[i]).SetSelectedInternal(true);
		}
	}
	
	this.CreateInternalColumns = function (){
		array_clear(this.internalColumns);
		if(this.showIndicator)
			this.internalColumns.push(new ASPxClientGridColumn(this, -1,"IndicatorColumn", -1));
		var rowBtnColCount = 0;
		while(rowBtnColCount < this.visibleColumns.length && this.visibleColumns[rowBtnColCount].type == "RowBtnColumn"){
			this.internalColumns.push(this.visibleColumns[rowBtnColCount]);
			rowBtnColCount ++;
		}
		for(var i = 0; i < this.groupColumns.length; i ++)
			this.internalColumns.push(new ASPxClientGridColumn(this, -1, "GroupingIndentColumn", -1));
		for(var i = rowBtnColCount, visibleColumnCount = this.visibleColumns.length; i < visibleColumnCount; i ++)
			this.internalColumns.push(this.visibleColumns[i]);
		this.InternalColumnsChanged();
	}

	this.RefreshLists = function (){
		for(var i = 0, columnCount = this.columns.length; i < columnCount; i ++){
			if(this.columns[i].visibleIndex >= 0){
				this.visibleColumns[this.columns[i].visibleIndex] = this.columns[i];
			}
			if(this.columns[i].groupIndex >= 0){
				this.groupColumns[this.columns[i].groupIndex] = this.columns[i];
			}
			if(this.columns[i].sortingIndex >= 0){
				this.sortColumns[this.columns[i].sortingIndex] = this.columns[i];
			}		
		}
	}
	
	this.InitializeTemplates = function (){
		if(this.useItemTemplate)
			this.itemTemplate = _getElementById(this.name + "ItemTemplatePattern");
		if(this.useEditItemTemplate)
			this.editItemTemplate = _getElementById(this.name + "EditItemTemplatePattern");
		if(this.useHeaderTemplate)
			this.headerTemplate = _getElementById(this.name + "HeaderTemplatePattern");
		if(this.useFooterTemplate)
			this.footerTemplate = _getElementById(this.name + "FooterTemplatePattern");
		if(this.useGroupItemTemplate)
			this.groupItemTemplate = _getElementById(this.name + "GroupItemTemplatePattern");
		if(this.useRowBtnTemplate)
			this.rowBtnTemplate = _getElementById(this.name + "RowBtnTemplatePattern");
		if(this.useBarBtnTemplate)
			this.barBtnTemplate = _getElementById(this.name + "BarBtnTemplatePattern");
		if(this.useExpandBtnTemplate)
			this.expandBtnTemplate = _getElementById(this.name + "ExpandBtnTemplatePattern");
		if(this.useStatusBarSectionTemplate)
			this.statusBarSectionTemplate = _getElementById(this.name + "StatusBarSectionTemplatePattern");
		if(this.useTitleTemplate)
			this.titleTemplate = _getElementById(this.name + "TitleTemplatePattern");
		if(this.useGroupPanelTemplate)
			this.groupPanelTemplate = _getElementById(this.name + "GroupPanelTemplatePattern");		
		if(this.usePreviewTemplate)
			this.previewTemplate = _getElementById(this.name + "PreviewTemplatePattern");
		
		for(var i = 0, columnCount = this.columns.length; i < columnCount; i ++){
			this.columns[i].InitializeTemplates();
		}
	}
	
	this.GetLastVisibleIndex = function (){	
		if(this.pageSize > 0 && this.firstVisibleIndex + this.pageSize <= this.GetVisibleRowCountInternal())
			return this.firstVisibleIndex + this.firstVisibleRowOffset + this.pageSize - 1;
		else
			return this.GetVisibleRowCount() - 1;
	}
	
	this.GetLastVisibleIndexInternal = function (){	
		if(this.pageSize > 0 && this.firstVisibleIndex + this.pageSize <= this.GetVisibleRowCountInternal())
			return this.firstVisibleIndex + this.pageSize - 1;
		else
			return this.GetVisibleRowCountInternal() - 1;
	}
	
	this.GetRowById = function (rowID){
		var rowIndex = array_indexOf(this.rowsIndex, rowID);
		if(rowIndex >= 0)
			return this.rows[rowIndex];
		return null;
	}
	
	this.GetCurVisibleRowCount = function(){
		var visibleCount = this.GetVisibleRowCountInternal();
		if(visibleCount > 0 && this.GetFirstVisibleIndexInternal() > -1)
			visibleCount -= this.GetFirstVisibleIndexInternal();
		if(this.pageSize > 0 && visibleCount > this.pageSize)
			visibleCount = this.pageSize;
		return visibleCount;
	}
	
	this.GetTRCount = function(){
		return this.clientSideExpanding ? this.GetRowCount() : this.GetCurVisibleRowCount();
	}
	
	this.GetRowPos = function(row){
		if(row.GetVisibleIndex() >= this.firstVisibleIndex && row.GetVisibleIndex() <= this.GetLastVisibleIndexInternal())
			return row.GetVisibleIndex() - this.firstVisibleIndex;
		return -1;
	}
	
	this.GetRowByDataRow = function(dataRow){
		var rowIndex = this.GetRowIndexByDataRow(dataRow);
		if(rowIndex >= 0)
			return this.GetRowInternal(rowIndex);
		return null;
	}
	
	this.GetRowIndexByDataRow = function(dataRow){
		if(dataRow != null){
			for(var i = 0, rowCount = this.GetRowCountInternal(), groupCount = this.groupColumns.length; i < rowCount; i ++){
				var row = this.GetRowInternal(i);
				if(row.GetDataControllerRow() == dataRow && row.GetLevel() == groupCount)
					return i;
			}
		}
		return -1;	
	}
	
	 this.GetVisibleIndexByRowIndex = function(rowIndex){
		if(rowIndex >= 0)
			return this.rows[rowIndex].GetVisibleIndex();
		return -1;
	}
	
	this.GetFocusedRowVisibleIndex = function(){
		if(this.focusedIndex >= 0)
			return this.GetFocusedRowVisibleIndexInternal() + this.firstVisibleRowOffset;
		return -1;
	}
	
	this.GetFocusedRowVisibleIndexInternal = function(){
		if(this.focusedIndex >= 0)
			return this.rows[this.focusedIndex].GetVisibleIndex();
		return -1;
	}

	this.RefreshRowIndex = function (){	
		array_clear(this.rowsIndex);
		array_clear(this.visibleRows);	
		for(var i = 0, rowIndex = 0, rowCount = this.GetRowCountInternal(), dataRowCount = this.firstDataRowIndex, groupingCount = this.groupColumns.length; i < rowCount; i++){
			var row = this.GetRowInternal(i);
			rowIndex += row.GetIndexOffset();
			row.SetInternalIndex(i);
			row.SetIndex(rowIndex);
			row.SetEvenOdd((dataRowCount % 2 == 0) ? "Even" : "Odd");
			this.rowsIndex.push(row.GetRowID());
			if(row.GetVisible()){
				row.SetVisibleIndex(this.GetVisibleRowCountInternal());
				this.visibleRows.push(i);
			}		
			if(row.GetLevel() == groupingCount)
				dataRowCount ++;
			rowIndex ++;	
		}
	}

	this.RefreshVisibleList = function (){	
		array_clear(this.visibleRows);
		for(var i = 0, rowCount = this.GetRowCountInternal(); i < rowCount; i++){
			if(this.GetRowInternal(i).GetVisible()){
				this.GetRowInternal(i).SetVisibleIndex(this.GetVisibleRowCountInternal());
				this.visibleRows.push(i);			
			}
		}
	}	
	this.GetRowByKeyValue = function (level, keyValue){
		for(var i = 0, rowCount = this.rows.length; i < rowCount; i ++){
			var row = this.rows[i];
			if(row.GetLevel() == level && _equal(row.GetKeyValue(), keyValue))
				return row;
		}
		return null;
	}	

	this.SetFocusedColumnIndex = function (focusedColumnIndex){
		if(this.focusedColumnIndex != focusedColumnIndex){
			var column = this.columns[focusedColumnIndex];
			var processingMode = this.OnFocusedColumnChanging(column, false);
			switch(processingMode){
				case "Client":
					var canSet = true;
					if(this.IsEditMode() && this.GetFocusedColumn() != null){
						var focusedColumn = this.GetFocusedColumn();
						if(focusedColumn != null && !this.IsColumnReadOnly(focusedColumn))
							canSet = focusedColumn.StoreEditValue();
					}
					if(canSet){
						this.focusedColumnIndex = focusedColumnIndex;
						_getHiddenInput(this.name + "FocusedColumn").value = focusedColumnIndex;
						this.FocusedColumnChangedInternal();		
						this.OnFocusedColumnChanged(column);
					}
					break;
				case "Server":
					this.SendPostBack(true);
					break;
			}
		}
	}
	
	this.SetFocusedIndexInternal = function (newFocusedIndex){	
		this.focusedIndex = newFocusedIndex;
		var focusedRow = this.GetFocusedRow();
		var focusedRowId = focusedRow != null ? focusedRow.GetRowID() : "-1" + idDlmtr + "-1";
		_getHiddenInput(this.name + "FocusedRow").value = this.name + this.GetRowIdPrefix(focusedRow) + focusedRowId;	
	}

	this.SetFocusedIndex = function (newFocusedIndex){	
		var focusedChanged = this.focusedIndex != newFocusedIndex;
		var processingMode = "Client";
		if(focusedChanged && !this._lockFcsdChng)
			processingMode = this.OnBeforeCommand(this.FocusedRowChanging, this.GetRow(newFocusedIndex), false);
		switch(processingMode){
			case "Client":
				var prevFocused = this.GetFocusedRow();
				if(!this.multiSelection && prevFocused != null)
					prevFocused.SetSelectedInternal(false);
				this.SetFocusedIndexInternal(newFocusedIndex);
				var focusedRow = this.GetFocusedRow();
				if(!this.multiSelection && focusedRow != null)
					focusedRow.SetSelectedInternal(true);
				this.MakeRowVisible(focusedRow);
				if(!this._lockFcsdChng){
					var savedLockFcsdChng = this._lockFcsdChng;
					this._lockFcsdChng = true;
					this.dataController.MoveTo(focusedRow != null ? this.GetFocusedRow().GetDataControllerRow() : null);
					this._lockFcsdChng = savedLockFcsdChng;
				}
				if(focusedChanged){
					this.OnAfterCommand(this.FocusedRowChanged, focusedRow);
					this.SelectedRowsChanged();		
					this.NavigatorsFocusedChanged();
					if(this.activateEditing && focusedRow != null){
						this.activateEditing = false;
						this.Edit();
					}
				}
				return true;
			case "Server":
				this.SendPostBack(true);
				return true;
			case "Cancel":
				this.RefreshFocusedPos(this.GetFocusedRow());
				return false;
		}
	}

	this.SetFirstVisibleRowInternal = function (row){	
		if(this.fixedPageNavigation){
			var pageIndex = (row != null) ? Math.floor(this.GetVisibleIndexByRowIndex(row.index) / this.pageSize) : 0;
			if(pageIndex >= 0)
				row = this.GetVisibleRow(pageIndex * this.pageSize);
		}
		if(this.GetFirstVisibleRow() != row){
			var processingMode = this.OnBeforeCommand(this.FirstVisibleRowChanging, row, this.processOnServer && (this.GetFirstVisibleRow() != null));
			switch(processingMode){
				case "Client":
					this.SetFirstVisibleIndex(row.GetVisibleIndex());
					this.OnAfterCommand(this.FirstVisibleRowChanged, row);
					break;
				case "Server":
					this.SendPostBack(true);
					break;
			}
		}
	}
	
	this.SetFirstVisibleIndex = function (newFirstVisible){	
		var visibleIndexShifted = 0;
		if(newFirstVisible >= 0 && newFirstVisible < this.visibleRows.length){
			if(this.firstVisibleIndex != -1){
				visibleIndexShifted = newFirstVisible - this.firstVisibleIndex;
				if(this.keepEditing || Math.abs(visibleIndexShifted) > 1 || this.GetVisibleRowCount() - newFirstVisible <= this.pageSize)
					visibleIndexShifted = 0;
			}
			this.firstVisibleIndex = newFirstVisible;	
			_getHiddenInput(this.name + "FirstVisibleRow").value = this.name + getDataRowMark() + this.GetRowInternal(this.visibleRows[this.firstVisibleIndex]).GetRowID();
		}
		else{
			this.firstVisibleIndex = -1;
			_getHiddenInput(this.name + "FirstVisibleRow").value = "";	
		}
		this.NavigatorsFirstVisibleIndexChanged();
		if(visibleIndexShifted != 0)
			this.VisibleRowsShifted(visibleIndexShifted);
		else
			this.VisibleRowsChanged();		
		
	}
	
	this.SetSampleRow = function (sampleRow){	
		this.sampleRow = sampleRow;		
		_getHiddenInput(this.name + "SampleRow").value = sampleRow != null ? sampleRow.GetRowID() : "";
	}
	
	this.ClearCurrentState = function (){
		this.ClearSearchState();
		return this.CheckBrowseMode();
	}
	
	this.OnBeforeVisibleColumnCountChanged = function(){
		this.focusedColumn = this.GetFocusedColumn();
		if(this.focusedColumn != null)
			this.focusedColumnVisibleIndex = this.focusedColumn.VisibleIndex;
	}
	
	this.OnAfterVisibleColumnCountChanged = function(){
		if(this.focusedColumn != null){
			if(this.focusedColumn.visibleIndex < 0){
				if(this.focusedColumnVisibleIndex >= 0 && this.focusedColumnVisibleIndex < this.visibleColumns.length && this.CanColumnHaveFocus(this.visibleColumns[this.focusedColumnVisibleIndex])){
					this.focusedColumnIndex = this.visibleColumns[focusedColumnVisibleIndex].index;
				}
				else{
					if(this.visibleColumns.length > 0){
						for(var i = this.visibleColumns.length - 1; i >= 0; i --){
							var column = this.visibleColumns[i];
							if(this.CanColumnHaveFocus(column)){
								this.focusedColumnIndex = column.index;
								break;
							}							
						}
					}
					else{
						this.focusedColumnIndex = -1;
					}
				}
			}
		}
	}
	
	this.CanColumnHaveFocus = function(column){
		return column.type == "BoundColumn" || column.type == "TemplateColumn";
	}

	this.IsServerSideRender = function(){
		return this.postBackOnSortingAndGrouping || this.processOnServer;
	}
	this.IsHtmlTagsInValuesEnabled = function(){
		return (this.dataController != null) ? this.dataController.htmlTagsInValuesEnabled : false;
	}	
	this.GetColumnCell = function(tr, column){		
		return this.htmlRender.GetColumnCell(tr, column);
	}

	this.SetFocusAndSelection = function(newFocusedIndex, isInternalCall, shiftState, ctrlState){
		var oldFocusedRow = this.GetFocusedRow();
		if(this.SetFocusedIndex(newFocusedIndex))
			this.ProcessSelection(oldFocusedRow, this.GetFocusedRow(), isInternalCall, shiftState, ctrlState);
	}	
	this.MoveNext = function (){	
		this.MoveNextInternal(false, this.focusedColumnIndex, false, false, false);
	}
	this.MoveNextInternal = function (isInternalCall, focusedColumnIndex, shiftState, ctrlState, shiftFirstVisible){	
		if(this.focusedIndex >= 0){
			if(this.GetFocusedRowVisibleIndex() < this.GetVisibleRowCount() - 1){
				if(this.ClearCurrentState()){
					if(this.processOnServer && this.focusedPos == this.pageSize - 1){
						this.SendPostBack(true);
					}
					else{
						this.BeginUpdateInternal(false);
						var newFocusedIndex = !shiftFirstVisible || this.firstVisibleIndex + this.pageSize < this.visibleRows.length ? this.visibleRows[this.GetFocusedRowVisibleIndexInternal() + 1] : -1; 
						if(this.pageSize > 0 && this.focusedPos >= this.pageSize - 1 || shiftFirstVisible && this.firstVisibleIndex + this.pageSize < this.visibleRows.length)
							this.SetFirstVisibleRowInternal(this.GetVisibleRow(!this.fixedPageNavigation ? this.firstVisibleIndex + 1 : (this.GetCurrentPageIndex() + 1) * this.pageSize));	
						var oldFocusedRow = this.GetFocusedRow();
						if(newFocusedIndex >= 0 && this.SetFocusedIndex(newFocusedIndex)){
							this.ProcessSelection(oldFocusedRow, this.GetFocusedRow(), isInternalCall, shiftState, ctrlState);						
							this.SetFocusedColumnIndex(focusedColumnIndex);
						}
						this.EndUpdate();
					}
				}
			}
		}
		else{
			var newFirstVisibleIndex = this.firstVisibleIndex + 1;
			if(newFirstVisibleIndex + this.pageSize <= this.GetVisibleRowCount()){
				if(this.ClearCurrentState()){
					if(this.processOnServer)
						this.SendPostBack(true);
					else{
						this.BeginUpdateInternal(false);
						this.SetFirstVisibleRowInternal(this.GetVisibleRow(newFirstVisibleIndex));
						this.EndUpdate();
					}
				}
			}
		}
	}	
	this.MoveNextByUI = function(focusedColumnIndex, shiftState, ctrlState, shiftFirstVisible){	
		this.MoveNextInternal(true, focusedColumnIndex, shiftState, ctrlState, shiftFirstVisible);
	}	
	this.MoveNextPage = function (){
		this.MoveNextPageInternal(this.pageSize, false, false, false, false, false, true);
	}
	this.MoveNextPageInternal = function (shiftRowCount, isInternalCall, shiftState, ctrlState, goToEndOfPage, keepLastRecord, goToLastRecord){
		if(this.GetLastVisibleIndex() < this.GetVisibleRowCount() - 1){		
			if(this.ClearCurrentState()){
				if(goToEndOfPage && this.GetVisibleRowCount() > this.pageSize && this.GetFocusedRowVisibleIndex() < this.GetFirstVisibleIndex() + this.pageSize - 1) {
					this.BeginUpdateInternal(false);
					this.SetFocusAndSelection(this.firstVisibleIndex + this.pageSize - 1, isInternalCall, shiftState, ctrlState);
					this.EndUpdate();
				}
				else{
					if(this.processOnServer){
						this.SendPostBack(true);
					}
					else{
						this.BeginUpdateInternal(false);
						var newFirstVisibleIndex = this.firstVisibleIndex + shiftRowCount - (keepLastRecord ? 1 : 0);
						if(newFirstVisibleIndex + this.pageSize > this.GetVisibleRowCount() && !this.fixedPageNavigation)
							newFirstVisibleIndex = this.GetVisibleRowCount() - this.pageSize;
						shiftRowCount = newFirstVisibleIndex - this.firstVisibleIndex;
						this.SetFirstVisibleRowInternal(this.GetVisibleRow(newFirstVisibleIndex));
						if(this.focusedIndex >= 0){
							var newFocusedIndex;
							if(this.focusedPos >= this.GetCurVisibleRowCount()){
								newFocusedIndex = this.visibleRows[this.GetVisibleRowCount() - 1];			
							}
							else {
								var focusedVisibleIndex = this.GetFocusedRowVisibleIndex() + shiftRowCount;
								if(focusedVisibleIndex >= this.visibleRows.length)
									focusedVisibleIndex = this.GetVisibleRowCount() - 1;
								newFocusedIndex = this.visibleRows[focusedVisibleIndex];
							}
							this.SetFocusAndSelection(newFocusedIndex, isInternalCall, shiftState, ctrlState);
						}
						this.EndUpdate();
					}	
				}
			}
		}
		else{
			if(goToLastRecord)
				this.MoveLastInternal(isInternalCall, shiftState, ctrlState);
		}
	}	
	this.MoveNextPageByUI = function(shiftState, ctrlState, goToEndOfPage, keepLastRecord){	
		this.MoveNextPageInternal(this.pageSize, true, shiftState, ctrlState, goToEndOfPage, keepLastRecord, true);
	}
	
	this.ShiftRowsDownByMouseWheel = function(){	
		this.MoveNextPageInternal(mouseWheelShift, true, false, true, false, false, false);
	}	
	this.MovePrev = function (){
		this.MovePrevInternal(false, this.focusedColumnIndex, false, false, false);
	}
	this.MovePrevInternal = function (isInternalCall, focusedColumnIndex, shiftState, ctrlState, shiftFirstVisible){
		if(this.focusedIndex >= 0){
			if(this.GetFocusedRowVisibleIndex() > 0){
				if(this.ClearCurrentState()){
					if(this.processOnServer && this.focusedPos == 0){
						this.SendPostBack(true);
					}
					else{
						this.BeginUpdateInternal(false);
						var newFocusedIndex = !shiftFirstVisible || this.firstVisibleIndex > 0 ? this.visibleRows[this.GetFocusedRowVisibleIndexInternal() - 1] : -1; 
						if(this.focusedPos <= 0 || shiftFirstVisible && this.firstVisibleIndex > 0)
							this.SetFirstVisibleRow(this.GetVisibleRow(!this.fixedPageNavigation ? this.firstVisibleIndex - 1 : (this.GetCurrentPageIndex() - 1) * this.pageSize));		
						var oldFocusedRow = this.GetFocusedRow();
						if(newFocusedIndex >= 0 && this.SetFocusedIndex(newFocusedIndex)){
							this.ProcessSelection(oldFocusedRow, this.GetFocusedRow(), isInternalCall, shiftState, ctrlState);
							this.SetFocusedColumnIndex(focusedColumnIndex);
						}
						this.EndUpdate();
					}
				}
			}
		}
		else{
			var newFirstVisibleIndex = this.firstVisibleIndex - 1;
			if(newFirstVisibleIndex >= 0){
				if(this.ClearCurrentState()){
					if(this.processOnServer)
						this.SendPostBack(true);
					else{
						this.BeginUpdateInternal(false);
						this.SetFirstVisibleRowInternal(this.GetVisibleRow(newFirstVisibleIndex));
						this.EndUpdate();
					}
				}
			}
		}
	}
	this.MovePrevByUI = function(focusedColumnIndex, shiftState, ctrlState, shiftFirstVisible){	
		this.MovePrevInternal(true, focusedColumnIndex, shiftState, ctrlState, shiftFirstVisible);
	}	
	this.MovePrevPage = function (){
		this.MovePrevPageInternal(this.pageSize, false, false, false, false, false, true);
	}
	this.MovePrevPageInternal = function (shiftRowCount, isInternalCall, shiftState, ctrlState, goToBeginigOfPage, keepFirstRecord, goToFirstRecord){
		if(this.GetFirstVisibleIndex() > 0){
			if(this.ClearCurrentState()){	
				if(goToBeginigOfPage && this.GetFirstVisibleIndex() != this.GetFocusedRowVisibleIndex()) {
					this.BeginUpdateInternal(false);
					this.SetFocusAndSelection(this.firstVisibleIndex, isInternalCall, shiftState, ctrlState);
					this.EndUpdate();
				}
				else{ 				
					if(this.processOnServer){
						this.SendPostBack(true);
					}
					else{
						this.BeginUpdateInternal(false);
						var correction = (keepFirstRecord ? 1 : 0);
						var newFirstVisibleIndex = this.firstVisibleIndex - shiftRowCount + correction;
						var newFocusedIndex; 
						if(newFirstVisibleIndex < 0){
							newFirstVisibleIndex = 0;
							newFocusedIndex = this.visibleRows[this.GetFocusedRowVisibleIndex() - this.firstVisibleIndex];						
						}			
						else{
							newFocusedIndex = this.visibleRows[this.GetFocusedRowVisibleIndex() - shiftRowCount + correction];
						}
						this.SetFirstVisibleRowInternal(this.GetVisibleRow(newFirstVisibleIndex));			
						if(this.focusedIndex >= 0)
							this.SetFocusAndSelection(newFocusedIndex, isInternalCall, shiftState, ctrlState);
						this.EndUpdate();						
					}
				}
			}
		}
		else{
			if(goToFirstRecord)
				this.MoveFirstInternal(isInternalCall, shiftState, ctrlState);
		}
	}
	this.MovePrevPageByUI = function(shiftState, ctrlState, goToBeginigOfPage, keepFirstRecord){	
		this.MovePrevPageInternal(this.pageSize, true, shiftState, ctrlState, goToBeginigOfPage, keepFirstRecord, true);
	}
	
	this.ShiftRowsUpByMouseWheel = function(){	
		this.MovePrevPageInternal(mouseWheelShift, true, false, true, false, false, false);
	}

	this.MoveTo = function (row){	
		if(row != null && this.ClearCurrentState())
			this.SetFocusedRow(row);
	}
	this.MoveToByUI = function (rowID, focusedColumnIndex, shiftState, ctrlState){	
		var row = this.GetRowById(rowID);
		if(row == this.GetFocusedRow() || this.ClearCurrentState()){		
			this.BeginUpdateInternal(false);
			var oldFocusedRow = this.GetFocusedRow();
			if(this.SetFocusedIndex(row.GetInternalIndex())){
				if(this.multiSelection)
					this.ProcessSelectionInternal(oldFocusedRow, this.GetFocusedRow(), !shiftState, !shiftState && !ctrlState, shiftState);				
				if(row.GetLevel() == this.groupColumns.length && focusedColumnIndex >= 0)
					this.SetFocusedColumnIndex(focusedColumnIndex);
				this.SelectedRowsChanged();		
			}
			this.EndUpdate();
		}
	}
	this.MoveFirst = function (){
		this.MoveFirstInternal(false, false, false);
	}	
	this.MoveFirstInternal = function (isInternalCall, shiftState, ctrlState){
		if((this.GetFocusedRowVisibleIndex() != 0) && this.ClearCurrentState()){	
			var changeFirstVisible = this.GetFirstVisibleIndex() > 0;
			if(this.processOnServer && changeFirstVisible){
				this.SendPostBack(true);
			}
			else{
				this.BeginUpdateInternal(false);
				var newFocusedIndex = this.visibleRows[0];
				if(changeFirstVisible)
					this.SetFirstVisibleRowInternal(this.GetVisibleRow(0));
				this.SetFocusAndSelection(newFocusedIndex, isInternalCall, shiftState, ctrlState);
				this.EndUpdate();
			}
		}
	}
	this.MoveFirstByUI = function(shiftState, ctrlState){	
		this.MoveFirstInternal(true, shiftState, ctrlState);
	}
	this.MoveLast = function (){
		this.MoveLastInternal(false, false, false);
	}
	this.MoveLastInternal = function (isInternalCall, shiftState, ctrlState){
		if(this.GetFocusedRowVisibleIndex() < this.GetVisibleRowCount() - 1 && this.ClearCurrentState()){
			var changeFirstVisible = this.GetLastVisibleIndex() < this.GetVisibleRowCount() - 1;
			if(this.processOnServer && changeFirstVisible){
				this.SendPostBack(true);
			}
			else{
				this.BeginUpdateInternal(false);
				var newFocusedIndex = array_lastElement(this.visibleRows);
				if(changeFirstVisible)
					this.SetFirstVisibleRowInternal(this.GetVisibleRow(!this.fixedPageNavigation ? this.GetVisibleRowCount() - this.pageSize : (this.GetPageCount() - 1) * this.pageSize));
				this.SetFocusAndSelection(newFocusedIndex, isInternalCall, shiftState, ctrlState);				
				this.EndUpdate();
			}
		}
	}
	this.MoveLastByUI = function(shiftState, ctrlState){	
		this.MoveLastInternal(true, shiftState, ctrlState);
	}
	
	this.MoveToPageByUI = function(pageIndex){
		this.SetCurrentPageIndex(pageIndex);
	}

	this.MoveColumnByUI = function(columnIndex, visibleIndex){
		this.columns[columnIndex].SetVisibleIndex(visibleIndex);
	}

	this.ChangePageSizeByUI = function(value){
		this.SetPageSize(value);
	}
	this.Refresh = function(){
		this.RefreshCore(null, "", "0");
	}
	
	this.ProcessSelectionInternal = function (oldFocusedRow, newFocusedRow, changeSelection, clearPrevSelection, selectRange){	
		if(this.multiSelection){
			if(clearPrevSelection)
				this.ClearSelectionInternal();
			if(selectRange){
				if(oldFocusedRow != null && newFocusedRow != null){
					var firstIndex = oldFocusedRow.GetVisibleIndex() < newFocusedRow.GetVisibleIndex() ? oldFocusedRow.GetVisibleIndex() : newFocusedRow.GetVisibleIndex();
					var lastIndex = oldFocusedRow.GetVisibleIndex() < newFocusedRow.GetVisibleIndex() ? newFocusedRow.GetVisibleIndex() : oldFocusedRow.GetVisibleIndex();
					for(var i = firstIndex; i <= lastIndex; i ++)
						this.GetVisibleRow(i).SetSelected(true);
				}
			}
			if(changeSelection && !selectRange){
				if(newFocusedRow != null)
					newFocusedRow.SetSelected(!newFocusedRow.GetSelected());
			}
			this.SynchronizeRows();
		}
	}

	this.ProcessSelection = function (oldFocusedRow, newFocusedRow, isInternalCall, shiftState, ctrlState){	
		var clearSelection = !isInternalCall || !shiftState && !ctrlState;
		this.ProcessSelectionInternal(oldFocusedRow, newFocusedRow, clearSelection, clearSelection, isInternalCall && shiftState);
	}
	
	this.SetRowSelected = function (row, selected){
		var processingMode = this.OnRowSelectedChanging(row, false);
		switch(processingMode){
			case "Client":
				this.BeginUpdateInternal(false);
				row.SetSelectedInternal(selected);
				this.SynchronizeRows();
				this.SelectedRowsChanged();
				this.EndUpdate();
				this.OnRowSelectedChanged(row);
				break;
			case "Server":
				this.SendPostBack(true);
				break;
		}
	}

	this.ClearSelectionInternal = function (){
		for(var i = 0, rowCount = this.GetRowCountInternal(); i < rowCount; i ++)
			this.GetRowInternal(i).SetSelectedInternal(false);
	}
	this.ClearSelection = function (){
		if(this.ClearCurrentState()){
			this.BeginUpdateInternal(false);
			this.ClearSelectionInternal();
			this.SynchronizeRows();
			this.SelectedRowsChanged();
			this.EndUpdate();
		}
	}

	this.ClearSearchState = function(){
		if(this.searchString != "" && !this._lockSearchState){
			this.searchColumnIndex = -1;
			this.searchString = "";
			this.SearchStateChanged(false);
		}
	}
	this.SearchRow = function (column, val, startRow, convertToString, partialSearch, ignoreCase, searchForward, findNext, cycle){
		if(column != null && this.ClearCurrentState()){
			if(startRow == null && this.GetRowCount() > 0)
				startRow = this.GetRow(0);
			var editor = column.GetEditor();
			var dataFormatString = (editor != null) ? editor.dataFormatString : "";
			var row = this.dataController.SearchRowInternal(column.GetDataControllerColumn(), val, startRow != null ? startRow.GetDataControllerRow() : null, convertToString, partialSearch, ignoreCase, searchForward, findNext, cycle, dataFormatString);
			if(row != null)
				return this.GetRowByDataRow(row);
		}
		return null;
	}

	this.DoSearchRow = function (columnIndex, searchString){
		this.DoSearchRowInternal(columnIndex, searchString, false, false);
	}
	this.DoSearchRowInternal = function (columnIndex, searchString, fromSearchItem, incrementalSearch){
		var searchColumn = this.columns[columnIndex];
		var processingMode = this.OnBeforeSearch(searchColumn, searchString, this.processOnServer);
		switch(processingMode){
			case "Client":
				this._lockSearchState = true;
				var findNext = this.keepSearching && !incrementalSearch && this.searchColumnIndex != -1 && this.searchString != "" && this.searchColumnIndex == Number(columnIndex) && searchString.indexOf(this.searchString) == 0;
				var startRow = this.startFromFirst && !findNext ? (this.GetRowCount() > 0 ? this.GetRow(0) : null) : this.GetFocusedRow();
				var row = this.SearchRow(searchColumn, searchString, startRow, true, this.partialSearch, this.ignoreCase, this.searchForward, findNext, this.cycleSearching);
				this.searchColumnIndex = Number(columnIndex);
				this.searchString = searchString;
				this.SearchStateChanged(fromSearchItem);
				this._lockSearchState = false;
				this.OnAfterSearch(searchColumn, searchString, row);
				if(row != null)
					this.SetFocusedRow(row);
				break;
			case "Server":
				this.SendPostBack(false);
				break;
		}
	}
	this.SearchRowByUI = function (columnIndex, searchString, fromSearchItem, incrementalSearch){
		this.DoSearchRowInternal(columnIndex, searchString, fromSearchItem, incrementalSearch);
	}
	this.OnBeforeSearch = function(searchColumn, searchString, processOnServer){
		if(!this.BeforeSearch.IsEmpty()){
			var args = new ASPxClientGridBeforeSearchEventArgs(searchColumn, searchString, processOnServer);
			this.BeforeSearch.FireEvent(this, args);
			return args.cancel ? "Handled" : (args.processOnServer ? "Server" : "Client");
		}
		return "Client";
	}
	this.OnAfterSearch = function(searchColumn, searchString, row){
		if(!this.AfterSearch.IsEmpty()){
			var args = new ASPxClientGridAfterSearchEventArgs(searchColumn, searchString, row);
			this.AfterSearch.FireEvent(this, args);		
		}
	}

	this.GetServerValidationPassed = function(){
		return this.dataController.serverValidationPassed;
	}
	this.IsColumnReadOnly = function(column){
		if(column != null)
			return this.readOnly || column.readOnly || this.dataController.IsColumnReadOnly(column.GetDataControllerColumn());
		return true;
	}
	this.Edit = function (){
		this.EditRowInternal(this.GetFocusedRow(), this.focusedColumnIndex);
	}
	this.EditRowByUI = function (rowId, columnIndex){
		var row = this.GetRowById(rowId);	
		if(row == null)
			row = this.GetFocusedRow();
		this.EditRowInternal(row, columnIndex);
	}
	
	this.DataCtrlrRaiseBeforeStartEdit = function(dataRow, processOnServer){	
		return this.OnBeforeCommand(this.BeforeStartEdit, this.GetRowByDataRow(dataRow), processOnServer);
	}
	this.DataCtrlrBeforeStartEdit = function(dataRow){	
		this.BeginUpdateInternal(false);
	}
	this.DataCtrlrDoStartEdit = function(dataRow){
		this.DataModeChanged(true, false);
	}
	this.DataCtrlrRaiseAfterStartEdit = function(dataRow){
		this.OnAfterCommand(this.AfterStartEdit, this.GetRowByDataRow(dataRow));
	}
	this.DataCtrlrAfterStartEdit = function(dataRow){
		this.EndUpdate();	
	}
	this.EditRow = function (row){
		this.EditRowInternal(row, this.focusedColumnIndex);
	}	
	
	this.EditRowInternal = function (row, columnIndex){
		if(this.GetDataMode() == "Browse" && !this.readOnly && this.allowEdit && row != null && row.GetLevel() == this.groupColumns.length){
			if(columnIndex >= 0)
				this.SetFocusedColumnIndex(columnIndex);
			if(row == this.GetFocusedRow() || this.SetFocusedIndex(row.GetInternalIndex()))				
				this.dataController.EditRow(row.GetDataControllerRow());			
		}		
	}
	
	this.InsertNewRowToList = function(newDataControllerRow, append){
		this.ClearSelectionInternal();
		var parent = null;
		var sampleRowIndex;
		if(this.sampleRow != null){
			sampleRowIndex = this.sampleRow.GetInternalIndex() + (append ? 1 : 0);
			parent = this.sampleRow.GetParent();
		}
		else{
			sampleRowIndex = (append && this.GetRowCountInternal() > 0 ? this.GetRowCountInternal() - 1 : 0);
		}
		var newRow = this.GetBlankRow(this, parent, newDataControllerRow, this.groupColumns.length, null, null, "Undefined", 0);
		if(this.sampleRow != null){
			for(var i = 0; i < this.groupColumns.length; i ++){
				var dataControllerColumn = this.groupColumns[i].GetDataControllerColumn();
				if(dataControllerColumn != null && !dataControllerColumn.IsReadOnly())
					newRow.GetDataControllerRow().SetValue(this.groupColumns[i].fieldIndex, this.sampleRow.GetDataControllerRow().GetValue(this.groupColumns[i].fieldIndex));
			}
		}	
		array_insert(this.rows, newRow, sampleRowIndex);	
		array_insert(this.rowsIndex, newRow.GetRowID(), sampleRowIndex);
		newRow.SetVisible(true);
		newRow.SetSelected(true);
		if(this.focusedIndex >= sampleRowIndex)
			this.focusedIndex ++;
		this.IncRowCount(1);
		this.RefreshRowIndex();
		this.SetFocusedIndex(sampleRowIndex);		
	}

	this.DataCtrlrRaiseBeforeNewRow = function(dataRow, append, processOnServer){
		var sampleRow = this.GetRowByDataRow(dataRow);
		return this.OnBeforeNewRow(sampleRow, append, processOnServer || this.processOnServer && dataRow != null && sampleRow == null);
	}
	this.DataCtrlrBeforeNewRow = function(dataRow){
		var sampleRow = this.GetRowByDataRow(dataRow);
		this.BeginUpdateInternal(false);
		this.SetSampleRow(sampleRow);
	}
	this.DataCtrlrDoNewRow = function(dataRow){	
		var append = this.GetDataMode() == "Append";
		if(this.sampleRow != null)
			this.MakeRowVisible(this.sampleRow);
		this.InsertNewRowToList(dataRow, append);		
		this.NavigatorsRecordCountChanged();	
		this.DataModeChanged(true, true);
	}
	this.DataCtrlrRaiseAfterNewRow = function(dataRow){	
		this.OnAfterCommand(this.AfterNewRow, this.GetRowByDataRow(dataRow));
	}
	this.DataCtrlrAfterNewRow = function(dataRow){	
		this.EndUpdate();
	}

	this.NewRowByUI = function (rowId, append){	
		var row = null;
		row = this.GetRowById(rowId);	
		if(row == null)
			row = this.GetFocusedRow();
		this.NewRow(row, append);
	}	
	this.New = function (append){	
		this.NewRow(this.GetFocusedRow(), append);
	}	
	this.NewRow = function (beforeRow, append){	
		if(!this.readOnly && (!append && this.allowInsert || append && this.allowAppend) && this.ClearCurrentState()){
			if(append)
				beforeRow = this.GetRowCount() > 0 ? this.GetRow(this.GetRowCount() - 1) : null;
			else{
				if(beforeRow == null)
					beforeRow = this.GetFocusedRow();
			}
			this.dataController.NewRow(beforeRow != null ? beforeRow.GetDataControllerRow() : null, append);
		}
	}
	
	this.DataCtrlrRaiseBeforeCancel = function(dataRow, processOnServer){	
		return this.OnBeforeCommand(this.BeforeCancel, this.GetFocusedRow(), processOnServer);
	}
	this.DataCtrlrBeforeCancel = function(dataRow){	
		this._savedInserMode = this.IsInsertMode();
		this.BeginUpdateInternal(false);
	}
	this.DataCtrlrDoCancel = function(dataRow){		
		this.CancelInternal(this._savedInserMode);
	}
	this.DataCtrlrRaiseAfterCancel = function(dataRow){		
		this.OnAfterCommand(this.AfterCancel, this.GetRowByDataRow(dataRow));
	}
	this.DataCtrlrAfterCancel = function(dataRow){		
		if(this._savedInserMode)
			this.NavigatorsRecordCountChanged();
		this.DataModeChanged(false, this._savedInserMode);
		this.EndUpdate();
	}
	this.Cancel = function(){
		this.dataController.Cancel();
	}
	this.CancelByUI = function(){
		this.Cancel();
	}
	this.CancelInternal = function (isInsertMode){	
		var newFocusedIndex;
		if(isInsertMode){	
			array_removeAt(this.rows, this.focusedIndex);
			this.IncRowCount(-1);
			this.RefreshRowIndex();
			this.focusedIndex = -1;
			newFocusedIndex = (this.sampleRow != null) ? this.sampleRow.GetInternalIndex() : -1;
		}
		else{
			newFocusedIndex = this.focusedIndex;
		}
		this.SetFocusedIndex(newFocusedIndex);	//	in order to refresh the "FocusedRow" hidden input
		if(this.multiSelection && this.GetFocusedRow() != null)
			this.GetFocusedRow().SetSelected(true);
	}
	
	this.CheckBrowseMode = function (){
		if(this.IsEditMode()){
			if(this.keepEditing)
				this.activateEditing = true;
			if(this.cancelChanges)
				this.Cancel();
			else
				this.Post();
		}
		return this.GetDataMode() == "Browse";
	}
	
	this.DataCtrlrRaiseBeforeUpdate = function (dataRow, processOnServer){
		return this.OnBeforeCommand(this.BeforeUpdate, this.GetFocusedRow(), false, processOnServer);
	}
	this.DataCtrlrBeforeUpdate = function (dataRow){
		this.BeginUpdateInternal(false);
	}
	this.DataCtrlrDoUpdate = function(dataRow){		
		var row = this.GetFocusedRow();
		row.RefreshId();
		
		var savedLockFcsdChng = this._lockFcsdChng;
		this._lockFcsdChng = true;
		this.SetFocusedIndex(this.focusedIndex);	//	in order to refresh the "FocusedRow" hidden input
		this._lockFcsdChng = savedLockFcsdChng;		
		
		var needRecreateList = false;
		if(this.groupColumns.length > 0){
			var parent = row.GetParent();
			if(!_isExists(parent))
				needRecreateList = true;
			while(!needRecreateList && _isExists(parent)){
				if(!_equal(parent.GetGroupValue(), row.GetDataControllerRow().GetValue(this.groupColumns[parent.GetLevel()].fieldIndex)))
					needRecreateList = true;
				parent = parent.GetParent();
			}
		}
		if(this.sortColumns.length > 0){
			var sortedColumnIndex = 0;
			while(!needRecreateList && sortedColumnIndex < this.sortColumns.length){
				var fieldIndex = this.sortColumns[sortedColumnIndex].fieldIndex;
				if(!_equal(this.dataController.GetOriginalValue(fieldIndex), row.GetDataControllerRow().GetValue(fieldIndex)))
					needRecreateList = true;
				sortedColumnIndex ++;
			}
		}
		if(needRecreateList && !this.processOnServer)
			this.CreateRowList(false, 0, 0);
		else
			this.RecalculateSummary();			
		
	}
	this.DataCtrlrRaiseAfterUpdate = function(dataRow){		
		this.OnAfterCommand(this.AfterUpdate, this.GetRowByDataRow(dataRow));
	}
	this.DataCtrlrAfterUpdate = function(dataRow){		
		this.DataModeChanged(false, false);
		this.EndUpdate();
	}
	this.Post = function (){	
		if(!this.postBackOnPostingDataChanges && !this.dataController.postBackOnPostingDataChanges)
			this.dataController.Post();
	}
	this.PostByUI = function (){	
		this.Post();
	}
	
	this.StoreEditValue = function(){
		if(this.htmlRender.initialized)
			this.htmlRender.StoreEditValues();
	}
	this.ValidateEditValue = function(){
		if(this.htmlRender.initialized)
			return this.htmlRender.ValidateEditValues();
		return true;
	}

	this.FindNextFocusedRow = function(currentFocusedRow){
		var newFocusedIndex = currentFocusedRow.GetIndex() + 1;	
		while(newFocusedIndex < this.GetRowCount() && !this.GetRow(newFocusedIndex).GetVisible()){
			newFocusedIndex ++;
		}
		if(newFocusedIndex >= this.GetRowCount()){
			newFocusedIndex = currentFocusedRow.GetIndex() - 1;
			while(newFocusedIndex >= 0 && !this.GetRow(newFocusedIndex).GetVisible()){
				newFocusedIndex --;
			}
		}
		if(newFocusedIndex >= 0 && newFocusedIndex < this.GetRowCount())
			return this.GetRow(newFocusedIndex);
		return null;
	}

	this.RemoveRowRecursive = function(row, currentFocusedRow){
		var parentRow = row.GetParent();
		var newFocusedRow = currentFocusedRow;
		if(newFocusedRow == row)
			newFocusedRow = this.FindNextFocusedRow(newFocusedRow);	
		array_remove(this.rows, row);
		this.IncRowCount(-1);
		if(_isExists(parentRow)&& ((parentRow.GetIndex() == this.GetRowCount() - 1) || (this.GetRow(parentRow.GetIndex() + 1).GetLevel() <= parentRow.GetLevel())))
			newFocusedRow = this.RemoveRowRecursive(parentRow, newFocusedRow);
		return newFocusedRow;
	}

	this.DataCtrlrRaiseBeforeDelete = function(dataRow, processOnServer){
		return this.OnBeforeCommand(this.BeforeDelete, this.GetRowByDataRow(dataRow), processOnServer);
	}
	this.DataCtrlrBeforeDelete = function(dataRow){
		this.BeginUpdateInternal(false);
	}
	this.DataCtrlrRowDeleted = function(dataRow){
		var row = this.GetRowByDataRow(dataRow);
		this.savedDeletedRow = row;
		var newFocusedRow = this.RemoveRowRecursive(row, this.GetFocusedRow());
		this.RefreshRowIndex();
		this.SetFocusedRow(newFocusedRow);	
		this.NavigatorsVisibleRowCountChanged();
		this.NavigatorsRecordCountChanged();
		this.VisibleRowsChanged();	
		this.RecalculateSummary();
	}
	this.DataCtrlrRaiseAfterDelete = function(dataRow){
		this.OnAfterCommand(this.AfterDelete, this.savedDeletedRow);
		this.savedDeletedRow = null;
	}
	this.DataCtrlrAfterDelete = function(dataRow){
		this.EndUpdate();
	}
	this.DeleteRow = function (row){
		if(row != null && this.allowDelete && !this.htmlRender.IsGroupRow(row)){
			if(this.IsInsertMode() && row == this.GetFocusedRow()){
				this.Cancel();
			}
			else{
				if(this.ClearCurrentState())
					this.dataController.DeleteRow(row.GetDataControllerRow());
			}
		}
	}
	this.Delete = function (){
		this.DeleteRow(this.GetFocusedRow());
	}

	this.DeleteRowByUI = function (rowId){
		var row = this.GetRowById(rowId);	
		if(row == null)
			row = this.GetFocusedRow();
		this.DeleteRow(row);
	}
	
	this.DataCtrlrEndDataBatchUpdate = function (){
		this.BeginUpdateInternal(false);
		this.SetFocusedIndexInternal(-1);
		var savedLockFcsdChng = this._lockFcsdChng;
		this._lockFcsdChng = true;
		this.CreateRowList(false, 0, 0);
		this._lockFcsdChng = savedLockFcsdChng;
		this.RowListChanged();		
		this.NavigatorsEndDataBatchUpdate();
		this.EndUpdate();
	}
	
	this.ClearSortedColumns = function (column){	
		for(var i = 0; i < this.sortColumns.length; i ++){		
			if(this.sortColumns[i] != column){
				this.sortColumns[i].SetSortingOrderInternal("None");
				this.sortColumns[i].SetSortingIndexInternal(-1);
			}
		}		
		array_clear(this.sortColumns);
		if(column != null)
			this.sortColumns.push(column);
	}
	
	this.ApplySorting = function (){
		this.dataController.ClearSorting();	
		if(this.groupColumns.length > 0 || this.sortColumns.length > 0){
			for(var i = 0; i < this.groupColumns.length; i ++){
				this.dataController.AddSortingCriteria(this.groupColumns[i].fieldIndex, this.groupColumns[i].sortingOrder);
			}
			for(var i = 0; i < this.sortColumns.length; i ++){
				if(array_indexOf(this.groupColumns, this.sortColumns[i]) == -1){
					this.dataController.AddSortingCriteria(this.sortColumns[i].fieldIndex, this.sortColumns[i].sortingOrder);
				}
			}		
			this.dataController.Sort();
		}
	}
	this.ClearSorting = function(){
		if(this.sortColumns.length > 0 && this.ClearCurrentState()){
			this.BeginUpdateInternal(true);
			this.ClearSortedColumns(null);
			this.CreateRowList(false, 0, 0);
			this.CorrectEmptySpace();
			this.SortingChanged();		
			this.EndUpdate();
		}
	}
	
	this.SortByUI = function (columnIndex, keepSorting, cancelSorting){		
		var column = this.columns[columnIndex];
		if(column != null){		
			if(!this.multiSorting || !keepSorting && !cancelSorting)
				this.ClearSortedColumns(column);		
			if(this.multiSorting && cancelSorting)
				column.SetSortingOrder("None");
			else
				column.ChangeSortingOrder();	
		}
	}
	
	this.GetBlankRow = function(owner, parent, dataRow, level, keyValue, groupValue, evenOdd, summaryItemCount){
		var row;
		if(this.rowsCache.length > 0)
			row = this.rowsCache.pop();
			
		else
			row = new ASPxClientGridRow();
		row.Initialize(owner, parent, dataRow, level, keyValue, groupValue, evenOdd, summaryItemCount);
		return row;
	}
	
	this.MoveOldRowsToCache = function(){
		while(this.rows.length > 0){
			this.rowsCache.push(this.rows[this.rows.length - 1]);
			this.rows.pop();
		}
	}
	
	this.CorrectRowLevel = function(rowLevel, level1, level2) {
		if(!(level1 == -1 && level2 == -1)){
			if(level1 != level2){
				if(level1 == -1) {
					if(rowLevel >= level2)
						return rowLevel + 1;
				}
				else{
					if(level2 == -1) {
						if(rowLevel >= level1 && rowLevel > 0)
							return rowLevel - 1;
					}
					else {
						if(rowLevel == level1){
							return level2;
						}
						else{
							if(level1 > level2) {
								if(rowLevel >= level2 && rowLevel < level1)
									return rowLevel + 1;
							}
							else{
								if(rowLevel > level1 && rowLevel <= level2)
									return rowLevel - 1;					
							}
						}
					}
				}
			}
		}
		else{
			rowLevel = 0;
		}
		return rowLevel;
	}
	
	this.CreateExtendedGroupRowKeyValue = function(groupValuesList, currentLevel, currentGroupValue){
		var keyValue = "";
		for(var i = 0; i < currentLevel; i++){
			keyValue = keyValue + this.GetKeyValueByGroupValue(groupValuesList);
		}
		keyValue = keyValue + this.GetKeyValueByGroupValue(currentGroupValue);
		return keyValue;
	}
	
	this.GetKeyValueByGroupValue = function(groupValue){
		return groupValue != null ? FormatValue(groupValue, "", "") : nullValueKey;
	}
	
	this.CanCompareRows = function(){
		return true;
	}
	this.GetCompareValue = function(value, fieldName) {
		var column = this.GetColumnByFieldName(fieldName);
		if(column != null){
			var editor = column.GetEditor();
			if(editor != null)
				return editor.GetCompareValue(value);
		}
		return value;
	}
	this.DoCompareRows = function(args){
		if(!this.CompareRows.IsEmpty())
			this.CompareRows.FireEvent(this, args);
	}
		
	this.CheckSavedRows = function(savedRowArray, row){
		for(var i = 0, rowCount = savedRowArray.length; i < rowCount; i ++){
			if(row.GetLevel() == savedRowArray[i][0] && _equal(row.GetKeyValue(), savedRowArray[i][1])){
				array_removeAt(savedRowArray, i);
				return true;
			}
		}
		return false;
	}
	this.IsCaseSensitiveSorting = function(){
		return this.dataController.caseSensitiveSorting;
	}
	
	this.CreateRowList = function (initialize, correctLevel1, correctLevel2){		
		var savedFocusedLevel = -1;
		var savedFocusedKeyValue = null;	
		var savedFirstVisibleLevel = -1;
		var savedFirstVisibleKeyValue = null;	
		
		if(this.focusedIndex >= 0 && this.GetFocusedRow() != null){
			savedFocusedLevel = this.CorrectRowLevel(this.GetFocusedRow().GetLevel(), correctLevel1, correctLevel2);
			savedFocusedKeyValue = this.GetFocusedRow().GetKeyValue();
		}
		if(this.firstVisibleIndex >= 0 && this.GetFirstVisibleRow() != null){
			savedFirstVisibleLevel = this.CorrectRowLevel(this.GetFirstVisibleRow().GetLevel(), correctLevel1, correctLevel2);
			savedFirstVisibleKeyValue = this.GetFirstVisibleRow().GetKeyValue();
		}
		var savedSelectedRows = null;
		if(this.multiSelection && correctLevel1 == correctLevel2 && correctLevel1 != -1 && !initialize){
			savedSelectedRows = new Array();
			for(var i = 0, selectedRowCount = this.selectedRows.length; i < selectedRowCount; i ++){
				var savedRow = new Array();
				savedRow[0] = this.selectedRows[i].GetLevel();
				savedRow[1] = this.selectedRows[i].GetKeyValue();
				savedSelectedRows.push(savedRow);
			}
		}
		var savedExpandedRows = null;
		if(this.groupColumns.length > 0 && correctLevel1 == correctLevel2 && correctLevel1 != -1 && !initialize){
			savedExpandedRows = new Array();
			for(var i = 0, rowCount = this.GetRowCount(); i < rowCount; i ++){
				var row = this.GetRow(i);
				if(row.GetExpanded()){
					var savedRow = new Array();
					savedRow[0] = row.GetLevel();
					savedRow[1] = row.GetKeyValue();
					savedExpandedRows.push(savedRow);
				}
			}
		}
		
		this.MoveOldRowsToCache();

		array_clear(this.visibleRows);
		array_clear(this.rowsIndex);
				
		this.rootRows = null;
		
		this.ApplySorting();
		this.InitializeSummary();
		
		var valuesList = new Array();					
		var dataControllerRowsList = new Array();					
		var parentsList = new Array();
		var rowCount = this.dataController.GetRowCount();
		var groupColumnCount = this.groupColumns.length;
		var groupValuesCount = 0;
		var canRowCompare = this.CanCompareRows();
		
		for(var i = 0; i < rowCount; i++){						
			var dataRow = this.dataController.GetRow(i);			
			if(!dataRow.isNewRow){
				for(var j = 0; j < groupColumnCount; j ++){			
					var groupingColumn = this.groupColumns[j];
					var groupingValue = dataRow.GetValue(groupingColumn.fieldIndex);
					var createGroupRow = false;
					if(groupValuesCount <= j){				
						valuesList[j] = groupingValue;
						dataControllerRowsList[j] = dataRow;
						parentsList[j] = null;
						createGroupRow = true;
						groupValuesCount ++;
					}
					else{				
						var eventHandled = false;
						var eventCompareResult = 0;
						if(canRowCompare){
							var e = new ASPxClientCompareRowsEventArgs(groupingColumn.GetDataControllerColumn(), dataRow, dataControllerRowsList[j], groupingValue, valuesList[j], "Grouping");
							this.DoCompareRows(e);
							eventCompareResult = e.result;
							eventHandled = e.handled;
						}
						var equal = true;
						if(eventHandled)
							equal = (eventCompareResult == 0);
						else if(_isString(valuesList[j]) && _isString(groupingValue) && !this.IsCaseSensitiveSorting()) 
							equal = _equal(valuesList[j].toLowerCase(), groupingValue.toLowerCase());
						else
							equal = _equal(valuesList[j], groupingValue);
						if(!equal){
							for(var k = valuesList.length - 1; k >= j; k --){						
								this.CompleteGroupRowSummary(parentsList[k]);
								if(k > j)
									groupValuesCount --;
							}
							createGroupRow = true;
						}				
					}							
					if(createGroupRow){
						var parent = null;
						if(j > 0)
							parent = parentsList[j - 1];				
						
						var row = this.GetBlankRow(this, parent, dataRow, j, !this.useExtendedGroupRowKeys ? dataRow.GetKeyValue() : this.CreateExtendedGroupRowKeyValue(valuesList, j, groupingValue), groupingValue, "Undefined", this.groupSummary.length);
						this.rows.push(row);
						this.rowsIndex.push(row.GetRowID());
						if(j == 0 || parent.GetVisible() && parent.GetExpanded()){
							row.SetVisible(true);
							this.visibleRows.push(this.GetRowCount() - 1);
							row.SetVisibleIndex(this.visibleRows.length - 1);
						}															
						if(savedFirstVisibleLevel == j && _equal(savedFirstVisibleKeyValue, row.GetKeyValue())){
							var visibleRow = row;
							while(!visibleRow.GetVisible()){
								visibleRow = visibleRow.GetParent();
							}
							this.SetFirstVisibleIndex(visibleRow.GetVisibleIndex());
							savedFirstVisibleLevel = -1;
						}
						if(savedFocusedLevel == j && _equal(savedFocusedKeyValue, row.GetDataControllerRow().GetKeyValue())){
							this.SetFocusedIndexInternal(this.GetRowCountInternal() - 1);
							savedFocusedLevel = -1;
						}
						if(savedExpandedRows != null){
							if(this.CheckSavedRows(savedExpandedRows, row))
								row.SetExpandedInternal(true);
						}
						if(savedSelectedRows != null){
							if(this.CheckSavedRows(savedSelectedRows, row))
								row.SetSelectedInternal(true);
						}
						valuesList[j] = groupingValue;
						dataControllerRowsList[j] = row.GetDataControllerRow();
						parentsList[j] = row;				
					}	
				}
				var parent = parentsList[groupColumnCount - 1];
				var row = this.GetBlankRow(this, parent, dataRow,  groupColumnCount, dataRow.GetKeyValue(), null, (i % 2 == 0) ? "Even" : "Odd", 0);
				this.rows.push(row);		
				this.rowsIndex.push(row.id);
				this.CalcRowSummary(row);
				if(groupColumnCount == 0 || parent.GetVisible() && parent.GetExpanded()){
					row.SetVisible(true);
					this.visibleRows.push(this.GetRowCount() - 1);
					row.SetVisibleIndex(this.visibleRows.length - 1);
				}
				if(savedFirstVisibleLevel == groupColumnCount && _equal(savedFirstVisibleKeyValue, row.GetKeyValue())){
					var visibleRow = row;
					while(!visibleRow.GetVisible()){
						visibleRow = visibleRow.GetParent();
					}
					this.SetFirstVisibleIndex(visibleRow.GetVisibleIndex());
					savedFirstVisibleLevel = -1;
				}
				if(savedFocusedLevel == groupColumnCount && _equal(savedFocusedKeyValue, row.GetKeyValue())){
					this.SetFocusedIndexInternal(this.GetRowCountInternal() - 1);		
					savedFocusedLevel = -1;
				}
				if(savedSelectedRows != null){
					if(this.CheckSavedRows(savedSelectedRows, row))
						row.SetSelectedInternal(true);
				}
			}		
		}
		
		for(var k = groupValuesCount - 1; k >= 0; k --){
			this.CompleteGroupRowSummary(parentsList[k]);
		}
		this.CompleteTotalSummary();

		if(!initialize){
			if(this.groupingChanged && this.autoCollapse)
				this.CollapseAllRowsInternal();
			if(this.groupingChanged && this.autoExpand)
				this.ExpandAllRowsInternal();
			this.groupingChanged = false;
				
			this.SetFocusedIndex(this.focusedIndex);			
		}
		else{
			this.InitializeExpandRows();
			if(this.multiSelection)
				this.InitializeSelectedRows();
		}

		this.RowListChanged();
		this.SynchronizeColumns();
		this.SynchronizeRows();		
	}
	
	this.AddServerCreatedRow = function(serverCreatedRow){
		this.serverCreatedRows.push(serverCreatedRow);
	}
	
	this.ProcessServerCreatedRows = function(){
		if(!this.processOnServer)
			this.ApplySorting();
		
		for(var i = 0, rowIndex = 0, rowCount = this.serverCreatedRows.length; i < rowCount; i ++){
			var serverCreatedRow = this.serverCreatedRows[i];
			var row = this.GetBlankRow(this, serverCreatedRow.parentRowIndex >= 0 ? this.GetRow(serverCreatedRow.parentRowIndex) : null, this.dataController.GetRow(serverCreatedRow.dataRowIndex), serverCreatedRow.level, serverCreatedRow.keyValue, serverCreatedRow.groupValue, serverCreatedRow.evenOdd, serverCreatedRow.level < this.groupColumns.length ? this.groupSummary.length : 0);
			this.rows.push(row);		
			this.rowsIndex.push(row.id);
			row.SetIndexOffset(serverCreatedRow.indexOffset);
			rowIndex += serverCreatedRow.indexOffset;
			row.SetIndex(rowIndex);
			if(serverCreatedRow.visible){
				row.SetVisible(true);
				this.visibleRows.push(this.GetRowCount() - 1);
				row.SetVisibleIndex(this.visibleRows.length - 1);
			}
			if(serverCreatedRow.summaryValues != null){
				for(var i = 0, summaryCount = this.groupSummary.length; i < summaryCount; i ++){							
					row.SetSummaryValueByIndex(i, serverCreatedRow.summaryValues[i]);
				}
				row.SetSummaryCount(serverCreatedRow.summaryCount);
			}
			if(serverCreatedRow.focused)
				this.SetFocusedIndexInternal(this.GetRowCountInternal() - 1);
			delete serverCreatedRow;
			rowIndex ++;
		}
		delete this.serverCreatedRows;
		this.InitializeExpandRows();
		if(this.multiSelection)
			this.InitializeSelectedRows();
		this.SynchronizeRows();
	}
	
	this.ExpandRowParents = function (row){	
		if(!row.GetVisible()){		
			var parent = row.GetParent();
			var oldParent = null;
			while(_isExists(parent)){
				parent.SetExpandedInternal(true);
				oldParent = parent;
				parent = parent.GetParent();
			}
			if(oldParent != null){		
				this.SetRowVisible(oldParent.GetIndex(), true);
				this.RefreshVisibleList();
			}
			return true;
		}
		return false;
	}

	this.CorrectVisibleInterval = function (row){	
		var rowVisibleIndex = row != null ? row.GetVisibleIndex() : -1;
		if(rowVisibleIndex >= 0){
			if(rowVisibleIndex < this.firstVisibleIndex || this.firstVisibleIndex < 0){
				this.SetFirstVisibleRowInternal(row);			
				return true;
			}
			else{
				var lastVisibleIndex = Number(this.GetLastVisibleIndexInternal());
				if(rowVisibleIndex > lastVisibleIndex){			
					this.SetFirstVisibleRowInternal(this.GetVisibleRow(this.firstVisibleIndex + rowVisibleIndex - lastVisibleIndex));
					return true;
				}
			}
		}
		return false;	
	}

	this.RefreshFocusedPos = function (){	
		if(this.focusedIndex >= 0){
			if(this.clientSideExpanding){
				this.focusedPos = this.focusedIndex;
			}
			else{
				var focusedRowVisibleIndex = this.GetFocusedRowVisibleIndexInternal();
				this.focusedPos = focusedRowVisibleIndex >= 0 && this.firstVisibleIndex >= 0 ? focusedRowVisibleIndex - this.firstVisibleIndex : 0;
			}
		}
		else{
			this.focusedPos = -1;
		}
	}

	this.MakeRowVisible = function (row){	
		if(row != null){
			var visibleRowsChanged = this.ExpandRowParents(row);
			visibleRowsChanged = this.CorrectVisibleInterval(row) || visibleRowsChanged;			
			if(visibleRowsChanged){			
				this.NavigatorsVisibleRowCountChanged();
				this.VisibleRowsChanged();
			}
		}
		this.RefreshFocusedPos(row);
	}

	this.CorrectFirstVisible = function(){
		if(this.pageSize == 0 || (this.GetVisibleRowCount() <= this.pageSize))
			this.SetFirstVisibleRowInternal(this.rows.length > 0 ? this.rows[0] : null);
	}

	this.SynchronizeFocusedPos = function (){
		var row = this.GetFocusedRow();
		if(row != null){
			while(!row.GetVisible()){
				row = row.GetParent();
			}
			if(row.GetVisibleIndex() < this.firstVisibleIndex){
				this.SetFocusedIndex(this.visibleRows[this.firstVisibleIndex]);
			}
			else{
				if(row.GetVisibleIndex() > this.GetLastVisibleIndexInternal())
					this.SetFocusedIndex(this.visibleRows[this.GetLastVisibleIndexInternal()]);
				else
					this.SetFocusedIndex(row.GetInternalIndex());
			}
		}
	}

	this.SetRowVisible = function (rowIndex, visible){
		var row = this.GetRow(rowIndex);
		if(row.GetVisible() != visible)
			row.SetVisible(visible);
		var i = rowIndex + 1;
		var childRow = this.GetRow(i);			
		while(_isExists(childRow) && childRow.GetLevel() > row.GetLevel()){
			i = this.SetRowVisible(i, row.GetVisible() && row.GetExpanded());
			childRow = this.GetRow(i);	
		}
		return i;
	}	

	this.SetRowExpanded = function (row, expanded){	
		if(this.ClearCurrentState()){
			var processingMode = this.OnRowExpanding(row, this.processOnServer);
			switch(processingMode){
				case "Client":
					this.BeginUpdateInternal(false);
					row.SetExpandedInternal(expanded);
					this.SetRowVisible(row.GetIndex(), row.GetParent() == null || row.GetParent().GetVisible() && row.GetParent().GetExpanded());
					this.RefreshVisibleList();			
					this.CorrectFirstVisible();
					this.SynchronizeFocusedPos();
					this.SynchronizeRows();
					this.NavigatorsVisibleRowCountChanged();
					if(this.clientSideExpanding)
						this.RowExpandedChanged(row);		
					else
						this.VisibleRowsChanged();		
					this.EndUpdate();
					if(this.NeedToCorrectWidth())
						this.SynchronizeTotalWidth();
					this.OnRowExpanded(row);
					break;
				case "Server":
					this.SendPostBack(true);
					break;
			}
		}
	}

	this.ExpandRowByUI = function (rowId){		
		var row = this.GetRowById(rowId);		
		this.SetRowExpanded(row, !row.GetExpanded());
	}

	this.GroupByUI = function (columnIndex, groupIndex){		
		var column = this.columns[columnIndex];	
		if(groupIndex < 0 || groupIndex > this.groupColumns.length)
			groupIndex = this.groupColumns.length;
		if(column != null && column.groupIndex != groupIndex)
			column.SetGroupIndex(groupIndex);		
	}

	this.UngroupByUI = function (columnIndex, visibleIndex){	
		var column = this.columns[columnIndex];
		if(column != null && column.groupIndex != -1){
			if(this.hideGroupedColumns && visibleIndex > column.savedVisibleIndex)
				visibleIndex ++;
			this.BeginUpdateInternal(false);
			column.SetGroupIndex(-1);		
			if(visibleIndex >= 0)
				column.SetVisibleIndex(visibleIndex);
			this.EndUpdate();
		}
	}

	this.ExpandAllRowsInternal = function(){
		if(this.ClearCurrentState()){
			var dataRowLevel = this.groupColumns.length;
			for(var i = 0, rowCount = this.GetRowCount(); i < rowCount; i ++){
				var row = this.GetRow(i);
				if(row.GetLevel() < dataRowLevel)
					row.SetExpandedInternal(true);
				row.SetVisible(true);
			}
			this.RefreshVisibleList();
			this.MakeRowVisible(this.GetFocusedRow());
			this.SynchronizeRows();		
			this.NavigatorsVisibleRowCountChanged();
			this.VisibleRowsChanged();
		}
	}
	this.ExpandAllRows = function(){
		if(this.processOnServer) return;
		this.BeginUpdateInternal(false);
		this.ExpandAllRowsInternal();
		this.EndUpdate();
	}

	this.CollapseAllRowsInternal = function(){
		if(this.ClearCurrentState()){
			var newFocusedRow = this.GetFocusedRow();
			while(!_isExists(newFocusedRow) && newFocusedRow.GetLevel() > 0){
				newFocusedRow = newFocusedRow.GetParent();
			}
			if(newFocusedRow != this.GetFocusedRow())
				this.SetFocusedRow(newFocusedRow);
			var dataRowLevel = this.groupColumns.length;
			for(var i = 0, rowCount = this.GetRowCount(); i < rowCount; i ++){
				var row = this.GetRow(i);
				if(_isExists(row)){
					if(row.GetLevel() > 0)
						row.SetVisible(false);
					row.SetExpandedInternal(false);
				}
			}
			this.RefreshVisibleList();
			this.MakeRowVisible(this.GetFocusedRow());
			this.SynchronizeRows();		
			this.NavigatorsVisibleRowCountChanged();
			this.VisibleRowsChanged();
		}
	}
	this.CollapseAllRows = function(){
		if(this.processOnServer) return;
		this.BeginUpdateInternal(false);
		this.CollapseAllRowsInternal();
		this.EndUpdate();
	}
	this.ClearGrouping = function(){
		var groupColumnCount = this.groupColumns.length;
		if(groupColumnCount > 0 && this.ClearCurrentState()){
			this.BeginUpdateInternal(true);
			for(var i = 0; i < groupColumnCount; i ++)	{		
				this.groupColumns[i].SetGroupIndexInternal(-1);
			}
			array_clear(this.groupColumns);
			this.CreateInternalColumns();
			this.CreateRowList(false, -1, -1); 
			this.GroupingChanged();
			this.EndUpdate();
		}
	}
	
	this.IncGroupingCorrection = function(){
		this.groupingCorrection ++;
	}

	this.DecGroupingCorrection = function(){
		this.groupingCorrection --;
	}
	
	this.GroupingChanged = function(){
		this.groupingChanged = true;
	}
	
	this.IsLastUngroupedColumn = function(column){
		for(var i = 0, columnCount = this.columns.length; i < columnCount; i ++){
			if(this.columns[i].groupIndex == -1 && this.columns[i].visibleIndex >= 0 && this.columns[i] != column && this.columns[i].type != "RowBtnColumn")
				return false;
		}
		return true;
	}

	this.InitializeSummary = function(){
		this.summaryValues = new Array();
		for(var i = 0, summaryCount = this.totalSummary.length; i < summaryCount; i++){
			this.summaryValues.push(null);
		}
		this.summaryCount = 0;
	}

	this.CalcRowSummary = function(row){		
		if(this.groupSummary.length > 0){
			var parentRow = row;
			for(var j = 0; j < this.groupColumns.length; j ++){
				var parentRow = parentRow.GetParent();						
				if(parentRow != null){
					for(var i = 0; i < this.groupSummary.length; i ++){
						var summaryItem = this.groupSummary[i];
						var summaryValue = row.GetDataControllerRow().GetValue(summaryItem.GetFieldIndex());
						var totalValue = parentRow.GetSummaryValueByIndex(i);
						if(summaryItem.GetSummaryType() == "Custom"){
							if(!this.CustomSummary.IsEmpty()){
								var args = new ASPxClientGridCustomSummaryEventArgs(summaryItem, row, parentRow, totalValue, summaryValue);
								this.CustomSummary.FireEvent(this, args);
								totalValue = args.totalValue;
							}
							parentRow.SetSummaryValueByIndex(i, totalValue);
						}
						else{
							parentRow.SetSummaryValueByIndex(i, summaryItem.ProcessValue(totalValue, summaryValue));
						}
					}
					parentRow.IncSummaryCount();
				}
			}
		}
		if(this.totalSummary.length > 0){
			for(var i = 0; i < this.totalSummary.length; i ++){
				var summaryItem = this.totalSummary[i];
				var summaryValue = row.GetDataControllerRow().GetValue(summaryItem.GetFieldIndex());
				var totalValue = this.summaryValues[i];
				if(summaryItem.GetSummaryType() == "Custom"){
					if(!this.CustomSummary.IsEmpty()){
						var args = new ASPxClientGridCustomSummaryEventArgs(summaryItem, row, this, totalValue, summaryValue);
						this.CustomSummary.FireEvent(this, args);
						this.summaryValues[i] = args.totalValue;
					}
				}
				else{
					this.summaryValues[i] = summaryItem.ProcessValue(totalValue, summaryValue);
				}
			}
			this.summaryCount ++;		
		}
	}

	this.CompleteGroupRowSummary = function(row){	
		if(row != null){
			for(var i = 0; i < this.groupSummary.length; i ++){			
				var summaryItem = this.groupSummary[i];
				var summaryCount = row.GetSummaryCount();
				var summaryValue = summaryItem.CompleteSummary(row.GetSummaryValueByIndex(i), summaryCount);
				if(!this.CompleteSummary.IsEmpty()){
					var args = new ASPxClientGridCompleteSummaryEventArgs(summaryItem, row, summaryValue, summaryCount);
					this.CompleteSummary.FireEvent(this, args);
					summaryValue = args.summaryValue;
				}
				row.SetSummaryValueByIndex(i, summaryValue);
			}
		}
	}

	this.CompleteTotalSummary = function (){	
		for(var i = 0; i < this.totalSummary.length; i ++){
			var summaryItem = this.totalSummary[i];
			var summaryValue = summaryItem.CompleteSummary(this.summaryValues[i], this.summaryCount);
			if(!this.CompleteSummary.IsEmpty()){
				var args = new ASPxClientGridCompleteSummaryEventArgs(summaryItem, this, summaryValue, this.summaryCount);
				this.CompleteSummary.FireEvent(this, args);
				summaryValue = args.summaryValue;
			}
			this.summaryValues[i] = summaryValue;
		}	
	}

	this.RecalculateSummary = function(){
		this.InitializeSummary();
		var groupCount = this.groupColumns.length;
		for(var i = 0, rowCount = this.rows.length; i < rowCount; i ++){
			var row = this.rows[i];
			if(row.GetLevel() < groupCount)
				row.InitializeSummary();
			else
				this.CalcRowSummary(row);
		}
		if(this.groupSummary.length > 0 && groupCount > 0){
			for(var i = 0, rowCount = this.rows.length; i < rowCount; i ++){
				var row = this.rows[i];
				if(row.GetLevel() < groupCount)
					this.CompleteGroupRowSummary(row);
			}
		}
		this.CompleteTotalSummary();
		this.SummaryChanged();
	}
	this.GetSummaryValue = function (summaryItem){	
		if(summaryItem != null){
			var summaryItemIndex = array_indexOf(this.totalSummary, summaryItem);
			if(summaryItemIndex >= 0)
				return this.summaryValues[summaryItemIndex];
		}
		return null;
	}
	
	this.DataCtrlrFocusedChanging = function(dataRow, processOnServer){
		var row = this.GetRowByDataRow(dataRow);
		if(!this._lockFcsdChng && row != this.GetFocusedRow())
			return this.OnBeforeCommand(this.FocusedRowChanging, row, processOnServer);
		return "Client";
	}

	this.DataCtrlrFocusedChanged = function(dataRow){
		var row = this.GetRowByDataRow(dataRow);
		if(!this._lockFcsdChng && row != this.GetFocusedRow()){
			var savedLockFcsdChng = this._lockFcsdChng;
			this._lockFcsdChng = true;
			this.SetFocusedRow(this.GetRowByDataRow(dataRow));
			this._lockFcsdChng = savedLockFcsdChng;				
		}
	}

	this.SetColumnWidthByUI = function(column, newWidth){
		if(newWidth < column.minWidth)
			newWidth = column.minWidth;
		var processingMode = this.OnColumnWidthChanging(this, newWidth, false);
		switch(processingMode){
			case "Client":
				column.SetWidth(new ASPxClientUnit(newWidth, "px"));
				this.OnColumnWidthChanged(column);
				break;
			case "Server":
				this.SendPostBack(false);
				break;
		}
	}
	
	this.ApplyColumnPixelCompensation = function(column, compensation){
		var widthValue = column.GetWidth().value;
		var minWidth = column.minWidth;
		var newWidth = Math.round(widthValue + compensation > minWidth ? widthValue + compensation : minWidth);
		column.SetWidth(new ASPxClientUnit(newWidth, "px"));
		return newWidth - widthValue;
	}
	
	this.CorrectColumnWidthChanging = function(changedColumn, delta, resizeRightColumns){
		if(!this._lockWidthSynchronization){
			this._lockWidthSynchronization = true;
			var changedColumnIndex = this.GetColumnInternalIndex(changedColumn);
			var lastColumn = this.GetLastCorrectionColumn(changedColumn);			
			if(lastColumn != null){
				var startIndex = !resizeRightColumns || changedColumn == null || changedColumnIndex > this.GetColumnInternalIndex(lastColumn) ? 0 : changedColumnIndex + 1;
				var totalWidth = this.GetActualGridWidth();
				var endIndex = this.GetColumnInternalIndex(lastColumn);				
				var pixelWidth = this.GetColumnsWidth(startIndex, endIndex, true);
				for(var i = startIndex, columnCount = this.internalColumns.length; i < columnCount; i ++){
					var column = this.internalColumns[i];
					if(!column.fixedWidth && column != changedColumn && column != lastColumn){						
						var widthValue = column.GetWidth().value;
						delta -= this.ApplyColumnPixelCompensation(column, delta/pixelWidth*widthValue);
						pixelWidth -= widthValue;
					}		
				}	
				delta -= this.ApplyColumnPixelCompensation(lastColumn, delta);
			}
			this._lockWidthSynchronization = false;
			return delta;
		}
	}
	
	this.CorrectLastColumnWidth = function(delta){
		this._lockWidthSynchronization = true;
		var column = this.internalColumns[this.internalColumns.length - 1];
		if(!column.fixedWidth)
			column.SetWidth(new ASPxClientUnit(Math.round(column.GetWidth().ConvertToPx().value + delta), "px"));
		this._lockWidthSynchronization = false;
		return column;
	}
	
	this.SynchronizeInitialColumnsWidth = function(){
		if(!this._lockWidthSynchronization){
			this._lockWidthSynchronization = true;	
			this.BeginUpdateInternal(false);
			var totalWidth = this.GetActualGridWidth() - this.GetFixedWidth(true, true);			
			for(var i = 0, columnCount = this.internalColumns.length; i < columnCount; i ++){
				var column = this.internalColumns[i];
				if(!column.fixedWidth){
					var actualColumnWidth = this.GetActualColumnWidth(i);
					if(column.GetWidth().ConvertToPx().value + this.htmlRender.GetColumnWidthCorrection(column) != actualColumnWidth)
						column.SetWidth(new ASPxClientUnit(actualColumnWidth, "px"));
				}
			}
			this.EndUpdate();
			this._lockWidthSynchronization = false;
		}
	}
	
	this.NeedToCorrectWidth = function(){
		return this.HasEmptyWidthColumns() || this.width.type == "%";
	}
	this.SynchronizeTotalWidth = function(){	
		if(!this._lockWidthSynchronization){
			this._lockWidthSynchronization = true;				
			if(this.htmlRender.IsHorzScrollBarShown()){
				this.BeginUpdateInternal(false);				
				this.fitScrollerWidth = true;
				this.updateScrollBars = true;
				this.EndUpdate();
			}
			else{
				if(this.internalColumns.length > 0){
					this.BeginUpdateInternal(false);
					var fixedWidth = this.GetFixedWidth(true, true);
					var minWidth = fixedWidth + this.GetColumnsMinWidth();
					this.FillOriginalColumnWidths();
					for(var i = 0, columnCount = this.internalColumns.length; i < columnCount; i ++){
						if(!this.internalColumns[i].fixedWidth)
							this.internalColumns[i].SetWidth(new ASPxClientUnit(10, "px"));
					}
					this.EndUpdate();
					this.BeginUpdateInternal(false);
					this.FillNewColumnWidths();
					for(var i = 0, columnCount = this.internalColumns.length; i < columnCount; i ++){
						var column = this.internalColumns[i];
						if(!this.internalColumns[i].fixedWidth)
							this.internalColumns[i].SetWidth(new ASPxClientUnit(this.newColumnWidths[i], "px"));
					}
					this.EndUpdate();
				}
			}
			this._lockWidthSynchronization = false;
		}		
	}	
	
	this.GetColumnsMinWidth = function(){
		var minWidth = 0;		
		for(var i = 0, columnCount = this.internalColumns.length; i < columnCount; i ++){
			var column = this.internalColumns[i];
			if(!column.fixedWidth && !column.GetWidth().IsEmpty()){
				minWidth += column.minWidth;
			}
		}		
		return minWidth;
	}
	
	this.GetTotalColumnsWidth = function (includeSpecColumns){
		var columnsWidth = this.GetColumnsWidth(0, this.internalColumns.length - 1, includeSpecColumns) + this.GetFixedWidth(includeSpecColumns, false);
		return new ASPxClientUnit(columnsWidth, "px");
	}
	
	this.WidthUnitsValid = function(){
		for(var i = 0, columnCount = this.internalColumns.length; i < columnCount; i ++){
			if(this.internalColumns[i].GetWidth().IsEmpty())
				return false;
		}
		if(this.htmlRender.IsVertScrollBarShown() && !this.htmlRender.nativeScrolling && !this.htmlRender.vertScrollBarEmpty && this.htmlRender.GetScrollBarSize().IsEmpty())
			return false;
		return true;
	}

	this.GetTotalWidth = function (recalcWidth){
		if(!recalcWidth && !this.width.IsEmpty() && (!this.widthChanged && (!this.htmlRender.vertScrollBarEmpty || !this.htmlRender.IsVertScrollBarShown()) || this.width.type == "%"))
			return this.width;
		if(!this.htmlRender.IsHorzScrollBarShown() && this.WidthUnitsValid()){
			var ret = this.GetTotalColumnsWidth(true);
			if(this.htmlRender.IsVertScrollBarShown() && !this.htmlRender.nativeScrolling && !this.htmlRender.vertScrollBarEmpty)
				ret = ret.Add(this.htmlRender.GetScrollBarSize().ConvertToPx());
			if(!ret.IsEmpty())
				ret = ret.Inc(this.cellPadding + this.cellSpacing);
			return ret;
		}
		return new ASPxClientUnit(this.GetActualGridWidth(), "px");
	}
	
	this.GetPreviewSectionWidth = function(){
		return this.GetTotalColumnsWidth(false).ConvertToPx().Inc(-1 - (!ie ? 2 * horzTextPadding : 0));
	}
	this.GetGroupItemTextSectionWidth = function(groupLevel){
		return this.GetTotalColumnsWidth(false).ConvertToPx().Add(this.groupRowIndent.ConvertToPx().Mul(this.groupColumns.length - groupLevel - 1)).Inc(-1 - (!ie ? 2 * horzTextPadding : 0));
	}

	this.OnBeforeCommand = function(evt, row, processOnServer){	
		if(!evt.IsEmpty()){
			var args = new ASPxClientBeforeGridCmdEventArgs(row, processOnServer);
			evt.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));	
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnAfterCommand = function(evt, row){	
		if(!evt.IsEmpty()){
			var args = new ASPxClientGridCmdEventArgs(row);
			evt.FireEvent(this, args);
		}
	}

	this.OnBeforeNewRow = function(row, append, processOnServer){	
		if(!this.BeforeNewRow.IsEmpty()){
			var args = new ASPxClientBeforeGridNewRowCmdEventArgs(row, append, processOnServer);
			this.BeforeNewRow.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));	
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnFocusedColumnChanging = function(column, processOnServer){
		if(!this.FocusedColumnChanging.IsEmpty()){
			var args = new ASPxClientColumnCancelEventArgs(column, processOnServer);
			this.FocusedColumnChanging.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnFocusedColumnChanged = function(column){
		if(!this.FocusedColumnChanged.IsEmpty()){
			var args = new ASPxClientColumnEventArgs(column);
			this.FocusedColumnChanged.FireEvent(this, args);
		}
	}

	this.OnGroupIndexChanging = function(column, groupIndex, processOnServer){	
		if(!this.GroupIndexChanging.IsEmpty()){
			var args = new ASPxClientGroupIndexEventArgs(column, groupIndex, processOnServer);
			this.GroupIndexChanging.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnGroupIndexChanged = function(column){	
		if(!this.GroupIndexChanged.IsEmpty()){
			var args = new ASPxClientColumnEventArgs(column);
			this.GroupIndexChanged.FireEvent(this, args);
		}
	}

	this.OnColumnSorting = function(column, sortingOrder, sortingIndex, processOnServer){		
		if(!this.ColumnSorting.IsEmpty()){
			var args = new ASPxClientColumnSortingEventArgs(column, sortingOrder, sortingIndex, processOnServer);
			this.ColumnSorting.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnColumnSorted = function(column){	
		if(!this.ColumnSorted.IsEmpty()){
			var args = new ASPxClientColumnEventArgs(column);
			this.ColumnSorted.FireEvent(this, args);
		}
	}

	this.OnColumnMoving = function(column, visibleIndex, processOnServer){	
		if(!this.ColumnMoving.IsEmpty()){
			var args = new ASPxClientColumnMovingEventArgs(column, visibleIndex, processOnServer);
			this.ColumnMoving.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");;
	}

	this.OnColumnMoved = function(column){	
		if(!this.ColumnMoved.IsEmpty()){
			var args = new ASPxClientColumnEventArgs(column);
			this.ColumnMoved.FireEvent(this, args);
		}
	}

	this.OnColumnWidthChanging = function(column, width, processOnServer){	
		if(!this.ColumnWidthChanging.IsEmpty()){
			var args = new ASPxClientColumnWidthChangingEventArgs(column, width, processOnServer);
			this.ColumnWidthChanging.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");;
	}

	this.OnColumnWidthChanged = function(column){	
		if(!this.ColumnWidthChanged.IsEmpty()){
			var args = new ASPxClientColumnEventArgs(column);
			this.ColumnWidthChanged.FireEvent(this, args);
		}
	}

	this.OnPageSizeChanging = function(pageSize, processOnServer){	
		if(!this.PageSizeChanging.IsEmpty()){
			var args = new ASPxClientPageSizeEventArgs(pageSize, processOnServer);
			this.PageSizeChanging.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnPageSizeChanged = function(){	
		if(!this.PageSizeChanged.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.PageSizeChanged.FireEvent(this, args);
		}
	}

	this.OnRowSelectedChanging = function(row, processOnServer){	
		if(!this.RowSelectedChanging.IsEmpty()){
			var args = new ASPxClientRowCancelEventArgs(row, processOnServer);
			this.RowSelectedChanging.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnRowSelectedChanged = function(row){	
		if(!this.RowSelectedChanged.IsEmpty()){
			var args = new ASPxClientRowEventArgs(row);
			this.RowSelectedChanged.FireEvent(this, args);
		}
	}

	this.OnRowExpanding = function(row, processOnServer){	
		if(!this.RowExpanding.IsEmpty()){
			var args = new ASPxClientRowCancelEventArgs(row, processOnServer);
			this.RowExpanding.FireEvent(this, args);
			return (args.cancel ? "Cancel" : (args.processOnServer || processOnServer ? "Server" : "Client"));	
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnRowExpanded = function(row){	
		if(!this.RowExpanded.IsEmpty()){
			var args = new ASPxClientRowEventArgs(row);
			this.RowExpanded.FireEvent(this, args);
		}
	}

	this.OnHeaderClick = function(column, processOnServer){	
		if(!this.HeaderClick.IsEmpty()){
			var args = new ASPxClientGridHeaderClickEventArgs(column, processOnServer);
			this.HeaderClick.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));	
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnHeaderDragEnd = function(column, newVisibleIndex, newGroupIndex, processOnServer){
		if(!this.HeaderDragEnd.IsEmpty()){
			var args = new ASPxClientGridHeaderDragEndEventArgs(column, newVisibleIndex, newGroupIndex, processOnServer);
			this.HeaderDragEnd.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnGroupingButtonClick = function(column, newGroupIndex, processOnServer){	
		if(!this.GroupingButtonClick.IsEmpty()){
			var args = new ASPxClientGridGroupingButtonClickEventArgs(column, newGroupIndex, processOnServer);
			this.GroupingButtonClick.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnRowClick = function(evt, row, column, processOnServer){	
		if(!evt.IsEmpty()){
			var args = new ASPxClientGridCellClickEventArgs(row, column, processOnServer);
			evt.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnBarButtonClick = function(barButton, processOnServer){	
		if(!this.BarButtonClick.IsEmpty()){
			var args = new ASPxClientGridBarButtonClickEventArgs(barButton, processOnServer);
			this.BarButtonClick.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnPageIndexButtonClick = function(barButton, pageIndex, processOnServer){	
		if(!this.BarButtonClick.IsEmpty()){
			var args = new ASPxClientGridPageIndexButtonClickEventArgs(barButton, pageIndex, processOnServer);
			this.BarButtonClick.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnRowButtonClick = function(row, rowButton, processOnServer){	
		if(!this.RowButtonClick.IsEmpty()){
			var args = new ASPxClientGridRowButtonClickEventArgs(row, rowButton, processOnServer);
			this.RowButtonClick.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnExpandButtonClick = function(row, processOnServer){	
		if(!this.ExpandButtonClick.IsEmpty()){
			var args = new ASPxClientGridRowClickEventArgs(row, processOnServer);
			this.ExpandButtonClick.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));	
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnSearchButtonClick = function(column, searchString, processOnServer){	
		if(!this.SearchButtonClick.IsEmpty()){
			var args = new ASPxClientGridSearchButtonClickEventArgs(column, searchString, processOnServer);
			this.SearchButtonClick.FireEvent(this, args);
			return (args.handled ? "Handled" : (args.processOnServer ? "Server" : "Client"));
		}
		return (processOnServer ? "Server" : "Client");
	}

	this.OnCustomRenderBarBtn = function(htmlElement, barItem, width, height, beforeDefaultRender){
		if(!this.CustomRenderBarBtn.IsEmpty()){
			var args = new ASPxClientBarCustomRenderEventArgs(htmlElement, barItem, width, height, beforeDefaultRender);
			this.CustomRenderBarBtn.FireEvent(this, args);
			return args.handled;
		}
		return false;
	}
	this.OnCustomRenderPageIndexBtn = function(htmlElement, barItem, width, height, pageIndex, text, tooltip, beforeDefaultRender){
		if(!this.CustomRenderPageIndexBtn.IsEmpty()){
			var args = new ASPxClientBarCustomRenderPageIndexButtonEventArgs(htmlElement, barItem, width, height, pageIndex, text, tooltip, beforeDefaultRender);
			this.CustomRenderPageIndexBtn.FireEvent(this, args);
			return args.handled;
		}
		return false;
	}
	this.OnCustomRenderStatusBarSection = function(htmlElement, barItem, width, height, beforeDefaultRender){
		if(!this.CustomRenderStatusBarSection.IsEmpty()){
			var args = new ASPxClientBarCustomRenderEventArgs(htmlElement, barItem, width, height, beforeDefaultRender);
			this.CustomRenderStatusBarSection.FireEvent(this, args);
			return args.handled;
		}
		return false;
	}
	this.OnBindStatusBarSection = function(htmlElement, barItem, text){
		if(!this.BindStatusBarSection.IsEmpty()){
			var args = new ASPxClientBarBindStatusSectionEventArgs(htmlElement, barItem, text);
			this.BindStatusBarSection.FireEvent(this, args);
			return args.handled;
		}
		return false;
	}

	this.ParseBarBtnId = function(barBtnId){			
		var barIndex = barBtnId.substring(barBtnId.indexOf("ButtonBar") + ("ButtonBar").length, barBtnId.indexOf(idDlmtr));
		var barItemIndex = barBtnId.substring(barBtnId.indexOf(idDlmtr) + idDlmtr.length, barBtnId.length);
		return this.GetButtonBar(Number(barIndex)).GetBarItem(Number(barItemIndex));
	}

	this.NavigatorsEndDataBatchUpdate = function (){		
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableEndDataBatchUpdate))
				this.navigators[i].NavigatableEndDataBatchUpdate();
		}		
	}
	this.NavigatorsFocusedChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableFocusedChanged))
				this.navigators[i].NavigatableFocusedChanged();
		}
	}	
	this.NavigatorsDataModeChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableDataModeChanged))
				this.navigators[i].NavigatableDataModeChanged();
		}
	}	
	this.NavigatorsRecordCountChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableRecordCountChanged))
				this.navigators[i].NavigatableRecordCountChanged();
		}
		this.NavigatorsRowCountChanged();
		this.NavigatorsVisibleRowCountChanged();
	}	
	this.NavigatorsFirstVisibleIndexChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableFirstVisibleIndexChanged))
				this.navigators[i].NavigatableFirstVisibleIndexChanged();
		}
	}	
	this.NavigatorsPageSizeChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatablePageSizeChanged))
				this.navigators[i].NavigatablePageSizeChanged();
		}
	}	
	this.NavigatorsRowCountChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableRowCountChanged))
				this.navigators[i].NavigatableRowCountChanged();
		}
	}	
	this.NavigatorsVisibleRowCountChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableVisibleRowCountChanged))
				this.navigators[i].NavigatableVisibleRowCountChanged();
		}
	}	
	this.NavigatorsStatusTextChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableStatusTextChanged))
				this.navigators[i].NavigatableStatusTextChanged();
		}
	}	
	this.NavigatorsSearchStateChanged = function (){
		for(var i = 0; i < this.navigators.length; i ++){
			if(_isFunction(this.navigators[i].NavigatableSearchStateChanged))
				this.navigators[i].NavigatableSearchStateChanged();
		}
	}	
	this.IsNavigatableEx = function (){
		return true;
	}

	this.SelectedRowsChanged = function(){	
		this.invalidateSelection = true;		
	}
	this.FocusedColumnChangedInternal = function(){	
		this.invalidateSelection = true;	
		if(this.IsEditMode() && this.cellSelection){
			this.DeactivateEditors();
			this.invalidateRowArray.push(this.GetFocusedRow());
			this.updateScrollBars = true;
		}
	}
	this.VisibleRowsShifted = function(shift){
		this.invalidateRowShift = shift;
		this.invalidateSelection = true;
		this.updateScrollBars = true;
	}
	this.VisibleRowsChanged = function(){
		this.invalidateRows = true;
		this.invalidateSelection = true;
		this.updateScrollBars = true;
	}
	this.RowExpandedChanged = function(row){
		this.invalidateExpandedRowArray.push(row); 
	}
	this.PageSizeChangedInternal = function(){
		this.invalidateRows = true;
		this.resetVertScrollBar = true;
		this.invalidateSelection = true;
		this.updateScrollBars = true;
	}
	this.InternalColumnsChanged = function(){	
		this.invalidateColumns = true;
		this.invalidateHeaders = true;
		this.invalidateSearchItem = true;
		this.invalidateFooter = true;
		this.invalidateRows = true;
		this.invalidateSelection = true;
		this.updateScrollBars = true;
	}
	this.ColumnWidthChangedInternal = function(column){
		if(array_indexOf(this.invalidateColumnArray, column) == -1){
			this.invalidateColumnArray.push(column);
			this.updateScrollBars = true;
		}
	}
	this.RowListChanged = function(){
		this.rowListRecreated = true;
		this.invalidateRows = true;
		this.invalidateSelection = true;
		this.updateScrollBars = true;
		this.NavigatorsRowCountChanged();
		this.NavigatorsVisibleRowCountChanged();
	}
	this.GroupingChanged = function(){
		this.invalidateHeaders = true;	
		this.updateScrollBars = true;
	}
	this.SortingChanged = function(){
		this.invalidateHeaders = true;			
	}
	this.DeactivateEditors = function(){
		for(var i = 0, columnCount = this.internalColumns.length; i < columnCount; i ++){
			var column = this.internalColumns[i];
			var editor = column.GetEditor();
			if(column.type == "BoundColumn" && editor != null)
				editor.DeactivateEditor();
		}
	}
	this.DataModeChanged = function(isEditMode, isInsertMode){
		if(!isEditMode)
			this.DeactivateEditors();

		this.invalidateButtons = true;
		if(isInsertMode){
			this.invalidateRows = true;
			this.invalidateFocusedRow = true;
			this.rowListRecreated = true;
		}
		else{
			this.invalidateRowArray.push(this.GetFocusedRow());
		}
		this.invalidateSelection = true;
		this.updateScrollBars = true;
		this.NavigatorsDataModeChanged();
	}
	this.SearchStateChanged = function(fromSearchItem){
		if(!fromSearchItem){
			this.invalidateSearchItem = true;
			this.focusedSearchEditorIndex = -1;
		}
		this.NavigatorsSearchStateChanged();
	}
	this.SummaryChanged = function (){
		if(this.groupSummary.length > 0){
			var parentRow = this.GetFocusedRow().GetParent();
			while(_isExists(parentRow)){
				this.invalidateRowArray.push(parentRow);
				parentRow = parentRow.GetParent();
			}
			this.updateScrollBars = true;
		}

		if(this.totalSummary.length > 0)
			this.invalidateFooter = true;
	}
	
	this.BeginUpdateInternal = function(preRender){		
		if(preRender)
			this.PreRender();
		this._lockRenderCount ++;
		if(!this.processOnServer){
			for(var i = 0; i < this.statusBars.length; i ++){
				this.GetStatusBar(i).BeginUpdate();
			}
			for(var i = 0; i < this.buttonBars.length; i ++){
				this.GetButtonBar(i).BeginUpdate();
			}
		}	
	}	
	this.BeginUpdate = function(){		
		this.BeginUpdateInternal(true);
	}	
	this.EndUpdate = function(){
		this._lockRenderCount --;
		if(this._lockRenderCount == 0){
			this.Render();
		}
		if(!this.processOnServer){
			for(var i = 0; i < this.statusBars.length; i ++){
				this.GetStatusBar(i).EndUpdate();
			}
			for(var i = 0; i < this.buttonBars.length; i ++){
				this.GetButtonBar(i).EndUpdate();
			}
		}
	}

	this.LockRender = function(){
		this._lockRenderCount ++;		
	}
	this.UnlockRender = function(){
		this._lockRenderCount --;
	}
	this.PreRender = function(){	
		if(this.hideSelectionNeeded){
			this.htmlRender.HideSelection();
			this.hideSelectionNeeded = false;
			this.invalidateSelection = true;
		}
	}
	this.Render = function(){		
		if(this._lockRenderCount == 0){
			this.LockRender();
			
			if(this.invalidateColumns)
				this.htmlRender.ColumnsRecreated();	
				
			if(this.invalidateFooter)
				this.htmlRender.RecreateFooter();			
			
			if(this.invalidateSearchItem)
				this.htmlRender.RecreateSearchItem();		

			if(this.invalidateButtons && !this.invalidateHeaders)
				this.htmlRender.InvalidateHeaderButtons();		
		
			if(this.invalidateHeaders){
				this.htmlRender.InvalidateTitle();
				this.htmlRender.InvalidateGroupPanel();
				for(var i = 0, columnCount = this.internalColumns.length; i < columnCount; i ++){
					if(this.internalColumns[i].type == "BoundColumn" || this.internalColumns[i].type == "TemplateColumn" )
						this.htmlRender.InvalidateHeader(this.internalColumns[i], false);
				}
			}		

			if(this.invalidateExpandedRowArray.length > 0){
				for(var i = 0; i < this.invalidateExpandedRowArray.length; i ++){
					this.htmlRender.InvalidateExpandedRow(this.invalidateExpandedRowArray[i]);
				}
			}
		
			if(this.invalidateRows || this.invalidateRowArray.length > 0){
				var recreate = false;
				if(this.rowListRecreated || this.invalidateColumns || this.groupColumns.length > 0 || this.invalidateRowArray.length > 0)
					recreate = true;
				if(this.invalidateRows && recreate){
					this.hideSelectionNeeded = false;
					array_clear(this.invalidateRowArray);
				}			
				while(this.invalidateRowArray.length > 0){
					this.htmlRender.InvalidateRow(this.invalidateRowArray[0], true);
					array_removeAt(this.invalidateRowArray, 0);
				}
				if(this.invalidateRows)
					this.htmlRender.InvalidateRows(this.invalidateColumns ? "All" : (this.invalidateFocusedRow || recreate ? "Focused" : "None"));
			}
			
			if(this.invalidateRowShift != 0 && !this.invalidateRows)
				this.htmlRender.InvalidateShiftedRows(this.invalidateRowShift > 0);
			
			if(this.invalidateColumnArray.length > 0){
				for(var i = 0; i < this.invalidateColumnArray.length; i++){
					if(this.invalidateColumnArray[i].visibleIndex < 0)
						array_removeAt(this.invalidateColumnArray, i);
				}
			}
			
			if(this.invalidateColumnArray.length > 0)
				this.htmlRender.InvalidateResizedColumns(this.invalidateColumnArray);
			
			if(this.fitScrollerWidth)
				this.htmlRender.FitScrollerWidth();
			
			if(this.updateScrollBars){
				var horzCompensation = this.htmlRender.UpdateScrollBars(this.resetVertScrollBar);
				if(this.keepWidth && horzCompensation != 0){
					var column = this.CorrectLastColumnWidth(horzCompensation);
					array_clear(this.invalidateColumnArray);
					this.invalidateColumnArray.push(column);
					this.htmlRender.InvalidateResizedColumns(this.invalidateColumnArray);
				}
			}
				
			if(this.invalidateColumns || this.invalidateColumnArray.length > 0 || this.updateScrollBars)
				this.htmlRender.UpdateTotalWidth();
			
			if(this.invalidateSelection){
				if(this.hideSelectionNeeded && this.prevFocusedPos < this.GetTRCount())
					this.htmlRender.HideSelection();
				if(this.focusedIndex >= 0){
					this.hideSelectionNeeded = true;		
					this.htmlRender.ShowSelection();	
				}
				this.prevFocusedPos = this.focusedPos;			
			}			

			this.ClearInvalidationFlags();
			this.UnlockRender();		
		}
	}
	this.ClearInvalidationFlags = function(){
		this.invalidateColumns = false;		
		array_clear(this.invalidateColumnArray);
		this.invalidateSearchItem = false;
		this.invalidateFooter = false;		
		this.invalidateButtons = false;
		this.invalidateHeaders = false;
		this.rowListRecreated = false;
		this.invalidateRows = false;
		array_clear(this.invalidateRowArray);
		array_clear(this.invalidateExpandedRowArray);
		this.resetVertScrollBar = false;
		this.invalidateRowShift = 0;
		this.invalidateFocusedRow = false;
		this.invalidateSelection = false;
		this.fitScrollerWidth = false;
		this.updateScrollBars = false;
		this.groupingCorrection = 0;
	}	
	this.Invalidate = function(){
		this.BeginUpdate();
		this.invalidateColumns = true;
		this.invalidateFooter = true;
		this.invalidateSearchItem = true;
		this.invalidateButtons = true;
		this.invalidateHeaders = true;
		this.invalidateRows = true;
		this.updateScrollBars = true;
		this.invalidateSelection = true;
		this.EndUpdate();
	}
	
	this.baseSynchronizeColumnProperties = this.SynchronizeColumnProperties;
	this.SynchronizeColumnProperties = function (column){
		return this.baseSynchronizeColumnProperties(column) + "~VisibleIndexInternal:" + column.visibleIndex + "~SortingOrderInternal:" + column.sortingOrder + "~SortingIndexInternal:" + column.sortingIndex + "~GroupIndexInternal:" + column.groupIndex + "~SavedVisibleIndex:" + column.savedVisibleIndex;
	}

	this.SynchronizeRows = function (){
		var expandedRowsStr = "", selectedRowsStr = "";
		if(this.multiSelection)
			array_clear(this.selectedRows);
		if(this.multiSelection || this.groupColumns.length){
			for(var i = 0, rowCount = this.GetRowCountInternal(); i < rowCount; i ++){
				var row = this.GetRowInternal(i);
				if(row.GetExpanded())
					expandedRowsStr = expandedRowsStr + row.GetRowID() + ";";
				if(this.multiSelection && row.GetSelected()){
					selectedRowsStr = selectedRowsStr + row.GetRowID() + ";";
					this.selectedRows.push(row);
				}
			}
		}
		_getHiddenInput(this.name + "ExpandedRows").value = expandedRowsStr;	
		if(this.multiSelection)
			_getHiddenInput(this.name + "SelectedRows").value = selectedRowsStr;	
	}	
	this.AfterPostBack = function(){
		this.GetDataController().AfterPostBack();
	}
}
ASPxClientGrid.GetGridCollection = function(){
	return GetGridCollection();
}
function ASPxClientGridRow(){
	
	this.Initialize = ASPxClientGridRow.Initialize;
	this.CreateId = ASPxClientGridRow.CreateId;
	this.RefreshId = ASPxClientGridRow.RefreshId;
	this.InitializeSummary = ASPxClientGridRow.InitializeSummary;	
	this.GetDataControllerRow = ASPxClientGridRow.GetDataControllerRow;	
	this.GetLevel = ASPxClientGridRow.GetLevel;	
	this.GetKeyValue = ASPxClientGridRow.GetKeyValue;	
	this.GetGroupValue = ASPxClientGridRow.GetGroupValue;
	this.GetEvenOdd = ASPxClientGridRow.GetEvenOdd;
	this.SetEvenOdd = ASPxClientGridRow.SetEvenOdd;
	this.GetIndex = ASPxClientGridRow.GetIndex;
	this.SetIndex = ASPxClientGridRow.SetIndex;
	
	this.GetInternalIndex = ASPxClientGridRow.GetInternalIndex;
	this.SetInternalIndex = ASPxClientGridRow.SetInternalIndex;
	this.GetIndexOffset = ASPxClientGridRow.GetIndexOffset;
	this.SetIndexOffset = ASPxClientGridRow.SetIndexOffset;
	this.GetParent = ASPxClientGridRow.GetParent;
	this.GetRowID = ASPxClientGridRow.GetRowID;
	this.GetExpanded = ASPxClientGridRow.GetExpanded;
	this.SetExpanded = ASPxClientGridRow.SetExpanded;
	
	this.SetExpandedInternal = ASPxClientGridRow.SetExpandedInternal;
	this.GetVisible = ASPxClientGridRow.GetVisible;
	this.SetVisible = ASPxClientGridRow.SetVisible;
	this.GetSelected = ASPxClientGridRow.GetSelected;
	this.SetSelected = ASPxClientGridRow.SetSelected;
	
	this.SetSelectedInternal = ASPxClientGridRow.SetSelectedInternal;
	this.GetVisibleIndex = ASPxClientGridRow.GetVisibleIndex;
	this.SetVisibleIndex = ASPxClientGridRow.SetVisibleIndex;
	
	this.GetSummaryCount = ASPxClientGridRow.GetSummaryCount;
	this.IncSummaryCount = ASPxClientGridRow.IncSummaryCount;
	this.SetSummaryCount = ASPxClientGridRow.SetSummaryCount;
	this.GetSummaryValueByIndex = ASPxClientGridRow.GetSummaryValueByIndex;
	this.SetSummaryValueByIndex = ASPxClientGridRow.SetSummaryValueByIndex;	
	this.Expand = ASPxClientGridRow.Expand;	
	this.Collapse = ASPxClientGridRow.Collapse;	
	this.GetSummaryValue = ASPxClientGridRow.GetSummaryValue;
}

ASPxClientGridRow.Initialize = function (owner, parent, dataRow, level, keyValue, groupValue, evenOdd, summaryItemCount){
	this.owner = owner;
	this.parent = parent;
	this.dataRow = dataRow;
	this.level = level;
	this.keyValue = keyValue;
	this.id = "";
	this.groupValue = groupValue;
	this.evenOdd = evenOdd;
	this.visible = false;
	this.expanded = false;	
	this.selected = false;	
	this.visibleIndex = 0;		
	this.indexOffset = 0;
	this.internalIndex = (owner != null) ? this.owner.GetRowCountInternal() : -1;
	this.index = this.internalIndex;
	
	this.summaryItemCount = summaryItemCount;
	this.summaryCount = 0;
	this.summaryValues = null;	
	
	this.id = this.CreateId();
	this.InitializeSummary();	
}

ASPxClientGridRow.CreateId = function (){
	return this.level + idDlmtr + (this.keyValue != null ? this.keyValue : "");
}

ASPxClientGridRow.RefreshId = function (){
	this.keyValue = this.dataRow.GetKeyValue();	
	this.id = this.CreateId();
	this.owner.rowsIndex[this.internalIndex] = this.id;
}

ASPxClientGridRow.InitializeSummary = function (){
	if(this.level < this.owner.groupColumns.length){
		this.summaryCount = 0;
		if(this.summaryItemCount > 0){
			this.summaryValues = new Array();
			for(var i = 0; i < this.summaryItemCount; i++){
				this.summaryValues.push(null);
			}		
		}
	}
}

ASPxClientGridRow.GetDataControllerRow = function (){
	return this.dataRow;
}
ASPxClientGridRow.GetLevel = function (){
	return this.level;
}
ASPxClientGridRow.GetKeyValue = function (){
	return this.keyValue;
}
ASPxClientGridRow.GetGroupValue = function (){
	return this.groupValue;
}
ASPxClientGridRow.GetEvenOdd = function (){
	return this.evenOdd;
}
ASPxClientGridRow.SetEvenOdd = function (evenOdd){
	this.evenOdd = evenOdd;
}
ASPxClientGridRow.GetInternalIndex = function (){
	return this.internalIndex;
}
ASPxClientGridRow.SetInternalIndex = function (value){
	return this.internalIndex = value;
}
ASPxClientGridRow.GetIndex = function (){
	return this.index;
}
ASPxClientGridRow.SetIndex = function (value){
	return this.index = value;
}
ASPxClientGridRow.GetIndexOffset = function (){
	return this.indexOffset;
}
ASPxClientGridRow.SetIndexOffset = function (value){
	return this.indexOffset = value;
}
ASPxClientGridRow.GetParent = function (){
	return this.parent;
}
ASPxClientGridRow.GetRowID = function (){
	return this.id;
}
ASPxClientGridRow.GetExpanded = function (){
	return this.expanded;
}
ASPxClientGridRow.SetExpanded = function (expanded){
	if(this.expanded != expanded)
		return this.owner.SetRowExpanded(this, expanded);
}
ASPxClientGridRow.SetExpandedInternal = function (value){
	this.expanded = value;
}
ASPxClientGridRow.GetVisible = function (){
	return this.visible;
}
ASPxClientGridRow.SetVisible = function (value){
	this.visible = value;
}
ASPxClientGridRow.GetSelected = function (){
	return this.selected;
}
ASPxClientGridRow.SetSelected = function (selected){
	if(this.selected != selected)
		return this.owner.SetRowSelected(this, selected);
}
ASPxClientGridRow.SetSelectedInternal = function (value){
	this.selected = value;
}
ASPxClientGridRow.GetVisibleIndex = function (){
	return this.visibleIndex;
}
ASPxClientGridRow.SetVisibleIndex = function (value){
	this.visibleIndex = value;
}
ASPxClientGridRow.GetSummaryCount = function (){
	return this.summaryCount;
}
ASPxClientGridRow.IncSummaryCount = function (){
	this.summaryCount ++;
}
ASPxClientGridRow.SetSummaryCount = function (value){
	this.summaryCount = value;
}
ASPxClientGridRow.GetSummaryValueByIndex = function (index){
	return this.summaryValues[index];
}
ASPxClientGridRow.SetSummaryValueByIndex = function (index, value){
	this.summaryValues[index] = value;
}
ASPxClientGridRow.Expand = function (){
	this.SetExpanded(true);
}
ASPxClientGridRow.Collapse = function (){
	this.SetExpanded(false);
}
ASPxClientGridRow.GetSummaryValue = function (summaryItem){
	if(this.level < this.owner.groupColumns.length && summaryItem != null){
		var index = array_indexOf(this.owner.groupSummary, summaryItem);
		if(index >= 0)
			return this.summaryValues[index];
	}
	return null;
}
function ASPxClientGridColumn(owner, index, type, fieldIndex, visibleIndex){
	this.inherit = ASPxClientGridColumnCore;
	this.inherit(owner, index, type, fieldIndex, visibleIndex);	
	
	this.headerText = "";
	this.footerText = "";	
	this.groupFormatString = "{0} : {1}{2}";
	this.editFormatString = "";	
	this.editorWidth = new ASPxClientUnit(0, "");
	this.cellWidth = new ASPxClientUnit(0, "");
	
	this.enableGroupingButton = true;	
	
	this.useItemTemplate = false;
	this.useEditItemTemplate = false;
	this.useHeaderTemplate = false;
	this.useFooterTemplate = false;
	this.useGroupItemTemplate = false;
	this.useRowBtnTemplate = false;
	
	this.itemTemplate = null;
	this.editItemTemplate = null;
	this.headerTemplate = null;
	this.footerTemplate = null;
	this.groupItemTemplate = null;
	this.rowBtnTemplate = null;
	
	this.itemStyle = ASPxStyle.CreateStyle();
	this.altItemStyle = ASPxStyle.CreateStyle();
	this.editItemStyle = ASPxStyle.CreateStyle();
	this.footerStyle = ASPxStyle.CreateStyle();

	this.resolvedHeaderStyle = null;
	this.resolvedGroupedHeaderStyle = null;
	this.resolvedItemStyle = null;
	this.resolvedAltItemStyle = null;
	this.resolvedEditItemStyle = null;
	this.resolvedAltEditItemStyle = null;
	
	this.summaryItem = null;
	this.CustomRenderCell = new ASPxClientEvent();
	this.CustomRenderEditCell = new ASPxClientEvent();
	this.CustomRenderHeader = new ASPxClientEvent();
	this.CustomRenderFooter = new ASPxClientEvent();
	this.CustomRenderGroupItem = new ASPxClientEvent();
	this.CustomRenderRowBtn = new ASPxClientEvent();
	this.CustomRenderSelection = new ASPxClientEvent();
	this.BindCell = new ASPxClientEvent();
	this.BindEditCell = new ASPxClientEvent();
	this.BindGroupingCell = new ASPxClientEvent();
	this.BindRowBtn = new ASPxClientEvent();
	this.GetCellValue = new ASPxClientEvent();
	this.GetEditValue = new ASPxClientEvent();
	this.FocusEditor = new ASPxClientEvent();	
	
	this.InitializeTemplates = function (){
		this.itemTemplate = this.useItemTemplate ? _getElementById(this.owner.name + "Column" + this.index + "ItemTemplatePattern") : this.owner.itemTemplate;
		this.editItemTemplate = this.useEditItemTemplate ? _getElementById(this.owner.name + "Column" + this.index + "EditItemTemplatePattern") : this.owner.editItemTemplate;
		this.headerTemplate = this.useHeaderTemplate ? _getElementById(this.owner.name + "Column" + this.index + "HeaderTemplatePattern") : this.owner.headerTemplate;
		this.footerTemplate = this.useFooterTemplate ? _getElementById(this.owner.name + "Column" + this.index + "FooterTemplatePattern") : this.owner.footerTemplate;
		this.groupItemTemplate = this.useGroupItemTemplate ? _getElementById(this.owner.name + "Column" + this.index + "GroupItemTemplatePattern") : this.owner.groupItemTemplate;
		this.rowBtnTemplate = this.useRowBtnTemplate ? _getElementById(this.owner.name + "Column" + this.index + "RowBtnTemplatePattern") : this.owner.rowBtnTemplate;
	}
	
	this.GetResolvedHeaderStyle = function(){
		if(this.resolvedHeaderStyle == null){
			this.resolvedHeaderStyle = ASPxStyle.CreateStyle();
			if(this.type == "IndicatorColumn" || this.type == "RowBtnColumn")
				this.resolvedHeaderStyle.MergeStyle(this.owner.rowBtnStyle);
			this.resolvedHeaderStyle.MergeStyle(this.owner.headerStyle);
			if(this.type != "IndicatorColumn")
				this.resolvedHeaderStyle.MergeStyle(this.headerStyle);
		}
		return this.resolvedHeaderStyle;
	}
	this.GetResolvedGroupedHeaderStyle = function(){
		if(this.resolvedGroupedHeaderStyle == null){
			this.resolvedGroupedHeaderStyle = ASPxStyle.CreateStyle();
			this.resolvedGroupedHeaderStyle.MergeStyle(this.GetResolvedHeaderStyle());			
			this.resolvedGroupedHeaderStyle.MergeStyle(this.owner.groupedHeaderStyle);
			this.resolvedGroupedHeaderStyle.MergeStyle(this.groupedHeaderStyle);
		}
		return this.resolvedGroupedHeaderStyle;
	}
	this.GetResolvedItemStyle = function(){
		if(this.resolvedItemStyle == null){
			this.resolvedItemStyle = ASPxStyle.CreateStyle();
			if(this.type == "IndicatorColumn" || this.type == "RowBtnColumn")
				this.resolvedItemStyle.MergeStyle(this.owner.rowBtnStyle);
			else
				this.resolvedItemStyle.MergeStyleFilterAttributes(this.owner.GetResolvedItemStyle());
			if(this.type != "IndicatorColumn")
				this.resolvedItemStyle.MergeStyle(this.itemStyle);
		}
		return this.resolvedItemStyle;
	}	
	this.GetResolvedAltItemStyle = function(){
		if(this.resolvedAltItemStyle == null){
			this.resolvedAltItemStyle = ASPxStyle.CreateStyle();
			this.resolvedAltItemStyle.MergeStyleFilterAttributes(this.owner.GetResolvedItemStyle());
			this.resolvedAltItemStyle.MergeStyleFilterAttributes(this.owner.altItemStyle);
			
			this.resolvedAltItemStyle.MergeStyle(this.itemStyle);
			this.resolvedAltItemStyle.MergeStyle(this.altItemStyle);
		}
		return this.resolvedAltItemStyle;
	}	
	this.GetResolvedEditItemStyle = function(){
		if(this.resolvedEditItemStyle == null){
			this.resolvedEditItemStyle = ASPxStyle.CreateStyle();
			this.resolvedEditItemStyle.MergeStyleFilterAttributes(this.owner.GetResolvedItemStyle());
			this.resolvedEditItemStyle.MergeStyleFilterAttributes(this.owner.editItemStyle);
			this.resolvedEditItemStyle.MergeStyle(this.itemStyle);
			this.resolvedEditItemStyle.MergeStyle(this.editItemStyle);
		}
		return this.resolvedEditItemStyle;
	}	
	this.GetResolvedAltEditItemStyle = function(){
		if(this.resolvedAltEditItemStyle == null){
			this.resolvedAltEditItemStyle = ASPxStyle.CreateStyle();
			this.resolvedAltEditItemStyle.MergeStyleFilterAttributes(this.owner.GetResolvedItemStyle());
			this.resolvedAltEditItemStyle.MergeStyleFilterAttributes(this.owner.altItemStyle);
			this.resolvedAltEditItemStyle.MergeStyleFilterAttributes(this.owner.editItemStyle);
			this.resolvedAltEditItemStyle.MergeStyle(this.itemStyle);
			this.resolvedAltEditItemStyle.MergeStyle(this.altItemStyle);
			this.resolvedAltEditItemStyle.MergeStyle(this.editItemStyle);
		}
		return this.resolvedAltEditItemStyle;
	}
	
	this.GetProperItemStyle = function(editItem, altItem){
		return !editItem ? (!altItem ? this.GetResolvedItemStyle() : this.GetResolvedAltItemStyle()) : (!altItem ? this.GetResolvedEditItemStyle() : this.GetResolvedAltEditItemStyle());
	}	

	this.GetEnableGroupingButton = function (){
		return this.owner.enableGroupingButtons && this.enableGroupingButton;
	}
	
	this.GetWidthPxValue = function(width){
		return width.type != "%" ? width.ConvertToPx().value : this.owner.GetActualGridWidth() / 100 * width.value;
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
	this.SetWidth = function (newWidth){
		if(!newWidth.Equals(this.width)){			
			this.owner.BeginUpdateInternal(false);
			if(!this.owner.htmlRender.IsHorzScrollBarShown() && (this.owner.keepWidth || this.owner.GetWidth().type == "%") && !this.owner._lockWidthSynchronization){
				if(newWidth.type == "%")
					newWidth = new ASPxClientUnit(this.GetWidthPxValue(newWidth), "px");
				var uncopensatedDelta = this.owner.CorrectColumnWidthChanging(this, Math.round(this.GetWidthPxValue(this.width) - this.GetWidthPxValue(newWidth)), true);
				if(uncopensatedDelta != null)
					newWidth = new ASPxClientUnit(newWidth.ConvertToPx().value + uncopensatedDelta, "px");				
			}
			
			this.width = newWidth;
			this.cellWidth = new ASPxClientUnit(0, "");
			this.editorWidth = new ASPxClientUnit(0, "");
			if(this.owner.IsEditMode() && this.owner.GetFocusedColumn() == this)
				this.StoreEditValue();
			this.owner.WidthChanged();			
			this.owner.ColumnWidthChangedInternal(this);
			if(!this.owner._lockWidthSynchronization)
				this.owner.SynchronizeColumns();
			this.owner.EndUpdate();
		}
	}
	
	this.GetEditorWidth = function (){
		if(this.editorWidth.IsEmpty()){			
			if(this.GetWidth().type == "%")
				this.editorWidth = ASPxClientUnit.GetHundredPercentUnit();
			else
				this.editorWidth = this.GetWidth().ConvertToPx().Inc(-1 * (this.owner.GetInnerBorderWidth() * 2 + this.owner.GetCellPadding() * 2 + this.owner.GetCellSpacing() *2));
		}
		return this.editorWidth;
	}
	
	this.GetCellWidth = function (){
		if(this.cellWidth.IsEmpty()){			
			if(this.GetWidth().type == "%")
				this.cellWidth = ASPxClientUnit.GetHundredPercentUnit();
			else
				this.cellWidth = this.GetWidth().ConvertToPx().Inc(-1 * (this.owner.GetInnerBorderWidth() + this.owner.GetCellPadding() * 2 + this.owner.GetCellSpacing() *2));
		}
		return this.cellWidth;
	}
	this.GetVisibleIndex = function (){	
		return this.visibleIndex;
	}
	this.SetVisibleIndex = function (visibleIndex){	
		this.owner.OnBeforeVisibleColumnCountChanged();
		if(visibleIndex < -1)
			visibleIndex = -1;
		if(this.visibleIndex == -1 && visibleIndex >= this.owner.visibleColumns.length)
			visibleIndex = this.owner.visibleColumns.length;
		if(this.visibleIndex != -1 && visibleIndex >= this.owner.visibleColumns.length)
			visibleIndex = this.owner.visibleColumns.length - 1;
		if(visibleIndex != this.visibleIndex && (!this.IsLastUngroupedColumn() || visibleIndex >= 0)){
			var processingMode = this.owner.OnColumnMoving(this, visibleIndex, false);
			switch(processingMode){
				case "Client":
					this.owner.BeginUpdateInternal(false);
					if(visibleIndex == -1 || this.visibleIndex == -1){			
						this.owner.WidthChanged();
						if(!this.owner.htmlRender.IsHorzScrollBarShown() && this.owner.keepWidth && !this.owner._lockWidthSynchronization)
							this.owner.CorrectColumnWidthChanging(this, this.GetWidthPxValue(this.width) * (visibleIndex == -1 ? 1 : -1), false);
					}
					if(this.visibleIndex >= 0)	
						array_remove(this.owner.visibleColumns, this);
					this.visibleIndex = visibleIndex;
					if(visibleIndex >= 0)
						array_insert(this.owner.visibleColumns, this, visibleIndex);				
					this.owner.CorrectVisibleIndexes();
					this.owner.CreateInternalColumns();			
					this.owner.SynchronizeColumns();
					this.owner.OnAfterVisibleColumnCountChanged();	
					this.owner.EndUpdate();
					if(this.owner.NeedToCorrectWidth())
						this.owner.SynchronizeTotalWidth();
					this.owner.OnColumnMoved(this);
					break;
				case "Server":
					this.owner.SendPostBack(false);
					break;
			}
		}
	}

	this.SetVisibleIndexInternal = function (visibleIndex){	
		this.visibleIndex = visibleIndex;
	}
	this.GetSortingOrder = function (){	
		return this.sortingOrder;
	}
	this.SetSortingOrder = function (sortingOrder){		
		if(sortingOrder != this.sortingOrder && this.owner.ClearCurrentState()){
			var processingMode = this.owner.OnColumnSorting(this, sortingOrder, sortingOrder == "None" ? -1 : (this.sortingOrder == "None" ? this.owner.sortColumns.length : this.sortingIndex), this.owner.processOnServer);
			switch(processingMode){
				case "Client":
					this.owner.BeginUpdateInternal(true);
					if(sortingOrder == "None")
						array_remove(this.owner.sortColumns, this);
					if(this.sortingOrder == "None")
						this.owner.sortColumns.push(this);
					this.sortingOrder = sortingOrder;				
					this.owner.CorrectSortingIndexes();
					this.owner.CreateRowList(false, 0, 0);
					this.owner.CorrectEmptySpace();
					this.owner.OnColumnSorted(this);
					this.owner.SortingChanged();		
					this.owner.EndUpdate();
					break;
				case "Server":
					this.owner.SendPostBack(false);
					break;
			}
		}
	}

	this.ChangeSortingOrder = function (){
		if(this.sortingOrder == "Ascending" || (this.groupIndex >= 0 && this.sortingOrder == "None"))
			this.SetSortingOrder("Descending");
		else
			this.SetSortingOrder("Ascending");
	}

	this.SetSortingOrderInternal = function (sortingOrder){
		this.sortingOrder = sortingOrder;
	}
	this.GetSortingIndex = function (){	
		return this.sortingIndex;
	}
	this.SetSortingIndex = function (sortingIndex){		
		if(sortingIndex < -1)
			sortingIndex = -1;
		if(this.sortingIndex != -1 && sortingIndex >= this.owner.sortColumns.length)
			sortingIndex = this.owner.sortColumns.length - 1;
		if(this.sortingIndex == -1 && sortingIndex > this.owner.sortColumns.length)
			sortingIndex = this.owner.sortColumns.length;
		if(sortingIndex != this.sortingIndex && this.owner.ClearCurrentState()){
			var processingMode = this.owner.OnColumnSorting(this, sortingIndex < 0 ? "None" : (this.sortingIndex < 0 ? "Ascending" : this.sortingOrder), sortingIndex, this.owner.processOnServer);
			switch(processingMode){
				case "Client":
					this.owner.BeginUpdateInternal(true);
					if(sortingIndex < 0){
						array_removeAt(this.owner.sortColumns, this.sortingIndex);
						this.sortingOrder = "None";
					}
					if(this.sortingIndex < 0){
						array_insert(this.owner.sortColumns, this, sortingIndex);
						this.sortingOrder = "Ascending";
					}
					this.owner.CorrectSortingIndexes();
					this.owner.CreateRowList(false, 0, 0);
					this.owner.CorrectEmptySpace();
					this.owner.OnColumnSorted(this);
					this.owner.SortingChanged();		
					this.owner.EndUpdate();
					break;
				case "Server":
					this.owner.SendPostBack(false);
					break;
			}	
		}
	}

	this.SetSortingIndexInternal = function (sortingIndex){		
		this.sortingIndex = sortingIndex;
	}
	this.GetGroupIndex = function (){	
		return this.groupIndex;
	}
	this.SetGroupIndex = function (groupIndex){	
		if(groupIndex < -1)
			groupIndex = -1;
		if(this.groupIndex != -1 && groupIndex >= this.owner.groupColumns.length)
			groupIndex = this.owner.groupColumns.length - 1;
		if(this.groupIndex == -1 && groupIndex > this.owner.groupColumns.length)
			groupIndex = this.owner.groupColumns.length;
		if(groupIndex != this.groupIndex && !this.IsLastUngroupedColumn() && this.owner.ClearCurrentState()){
			var processingMode = this.owner.OnGroupIndexChanging(column, groupIndex, this.owner.processOnServer);
			switch(processingMode){
				case "Client":
					this.owner.BeginUpdateInternal(true);
					var oldGroupIndex = this.groupIndex;
					this.groupIndex = groupIndex;
					if(oldGroupIndex >= 0){
						array_removeAt(this.owner.groupColumns, oldGroupIndex);
						this.owner.DecGroupingCorrection();
					}
					if(groupIndex >= 0){
						array_insert(this.owner.groupColumns, this, groupIndex);			
						this.owner.IncGroupingCorrection();
					}
					this.owner.CorrectGroupIndexes();
					this.owner.GroupingChanged();
					if(this.owner.hideGroupedColumns){
						if(groupIndex >= 0 && oldGroupIndex < 0){
							this.savedVisibleIndex = this.visibleIndex;
							this.SetVisibleIndex(-1);
							if(!this.owner.htmlRender.IsHorzScrollBarShown() && this.owner.keepWidth && !this.owner._lockWidthSynchronization)
								this.owner.CorrectColumnWidthChanging(null, -1 * this.GetWidthPxValue(this.owner.groupRowIndent), false);
						}
						if(oldGroupIndex >= 0 && groupIndex < 0){
							this.SetVisibleIndex(this.savedVisibleIndex);
							if(!this.owner.htmlRender.IsHorzScrollBarShown() && this.owner.keepWidth && !this.owner._lockWidthSynchronization)
								this.owner.CorrectColumnWidthChanging(null, this.GetWidthPxValue(this.owner.groupRowIndent), false);
						}
					}
					this.owner.WidthChanged();
					this.owner.CreateInternalColumns();
					this.owner.CreateRowList(false, oldGroupIndex, groupIndex); 
					this.owner.CorrectEmptySpace();
					this.owner.OnGroupIndexChanged(this);
					this.owner.GroupingChanged();
					this.owner.EndUpdate();
					if(this.owner.NeedToCorrectWidth())
						this.owner.SynchronizeTotalWidth();
					break;
				case "Server":
					this.owner.SendPostBack(false);
					break;
			}
		}
	}
	
	this.IsLastUngroupedColumn = function(){
		return this.owner.IsLastUngroupedColumn(this);
	}

	this.SetGroupIndexInternal = function (groupIndex){	
		this.groupIndex = groupIndex;
	}	
	
	this.SetSavedVisibleIndex = function (savedVisibleIndex){	
		this.savedVisibleIndex = savedVisibleIndex;
	}

	this.GetDataType = function (){	
		var dataControllerColumn = this.GetDataControllerColumn();
		if(dataControllerColumn != null)
			return dataControllerColumn.GetType();
		return "";
	}
	
	this.StoreEditValue = function(){
		if(this.owner.htmlRender.initialized){
			if(this.owner.htmlRender.ValidateColumnEditValue(this))
				return this.owner.htmlRender.StoreColumnEditValue(this);
		}
		return false;
	}
	this.GetDataControllerColumn = function (){	
		if(this.fieldIndex != -1)
			return this.owner.dataController.columns[this.fieldIndex];
		return null;
	}
	this.GetEditor = function (){	
		if(this.editor == null && _isFunctionType(typeof(GetEditorCollection)))
			this.editor = GetEditorCollection().Get(this.owner.name + "Column" + this.index + "Editor");
		return this.editor;
	}
	this.GetSummaryItem = function (){	
		return this.summaryItem;
	}
	this.GetSummaryValue = function (){	
		return this.owner.GetSummaryValue(this.summaryItem);
	}	
}
function ASPxClientGridSummaryItem(owner, summaryType, fieldIndex, showInColumnIndex, displayFormat){
	this.owner = owner;
	this.summaryType = summaryType;
	this.fieldIndex = fieldIndex;
	this.showInColumnIndex = showInColumnIndex;	
	this.displayFormat = displayFormat;
	this.GetSummaryType = function(){
		return this.summaryType;
	}
	this.GetSummaryField = function(){
		var fieldIndex = this.GetFieldIndex();
		if(fieldIndex >= 0)
			return this.owner.dataController.columns[fieldIndex];
		return "";
	}

	this.GetFieldIndex = function(){
		if(this.fieldIndex >= 0){
			return this.fieldIndex;
		}
		else{
			if(this.showInColumnIndex >= 0){
				return this.owner.columns[this.showInColumnIndex].fieldIndex;
			}
			return -1;
		}
	}

	this.ProcessValue = function(summaryValue, rowValue){		
		switch(this.summaryType) {
			case "Average": 
			case "Sum": 
				if(summaryValue == null)
					return rowValue;
				else if(rowValue == null)
					return summaryValue;
				else
					return summaryValue + rowValue;
			case "Count": 			
				return null;
			case "Min": 
				if(summaryValue == null)
					return rowValue;
				else if(rowValue == null)
					return summaryValue;
				else
					return (rowValue < summaryValue) ? rowValue : summaryValue;
			case "Max": 
				if(summaryValue == null)
					return rowValue;
				else if(rowValue == null)
					return summaryValue;
				else
					return (rowValue > summaryValue) ? rowValue : summaryValue;
			case "Custom":
				return summaryValue;
		}
		return null;
	}

	this.CompleteSummary = function(summaryValue, summaryCount){	
		switch(this.summaryType){
			case "Average": 
				if(summaryValue != null)
					return summaryValue / summaryCount;
				break;
			case "Count": 
				return summaryCount;
		}
		return summaryValue;
	}

	this.GetDisplayText = function(value, fullForm){
		var formatString = this.displayFormat;
		if(formatString == "")
			formatString = this.GetDisplayFormatByType(fullForm);
		return FormatValue(value, formatString, "");
	}

	this.GetDisplayFormatByType = function(fullForm){	
		if(fullForm){
			switch(this.summaryType){
				case "Average": 
					return "(AVG={0})";
				case "Sum": 
					return "(SUM={0})";			
				case "Count": 
					return "(Count={0})";
				case "Min": 
					return "(MIN={0})";
				case "Max": 
					return "(MAX={0})";
				case "Custom":
					return "(Custom={0})";
			}
		}	
		return "{0}";
	}
}

ASPxGridServerCreatedRow = function(indexOffset, parentRowIndex, dataRowIndex, level, keyValue, groupValue, evenOdd, visible, focused, summaryValues, summaryCount){
	this.indexOffset = indexOffset;
	this.parentRowIndex = parentRowIndex;
	this.dataRowIndex = dataRowIndex;
	this.level = level;
	this.keyValue = keyValue;
	this.groupValue = groupValue;
	this.evenOdd = evenOdd;
	this.visible = visible;
	this.focused = focused;
	this.summaryValues = summaryValues;
	this.summaryCount = summaryCount;
}