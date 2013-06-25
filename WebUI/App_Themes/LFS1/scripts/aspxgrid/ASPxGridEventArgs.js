
function ASPxClientGridCmdEventArgs(row){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.row = row;
}
function ASPxClientBeforeGridCmdEventArgs(row, processOnServer){
	this.inherit = ASPxClientCancelProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.row = row;
}
function ASPxClientBeforeGridNewRowCmdEventArgs(row, append, processOnServer){
	this.inherit = ASPxClientBeforeGridCmdEventArgs;
	this.inherit(row, processOnServer);
	this.append = append;
}
function ASPxClientValidateColumnValueEventArgs(row, column, value){
	this.inherit = ASPxClientValidateEventArgs;
	this.inherit(value);
	this.row = row;
	this.column = column;
}
function ASPxClientColumnEventArgs(column){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.column = column;
}
function ASPxClientColumnCancelEventArgs(column, processOnServer){
	this.inherit = ASPxClientCancelProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.column = column;
}
function ASPxClientGroupIndexEventArgs(column, groupIndex, processOnServer){
	this.inherit = ASPxClientColumnCancelEventArgs;
	this.inherit(column, processOnServer);
	this.groupIndex = groupIndex;
}
function ASPxClientColumnSortingEventArgs(column, sortingOrder, sortingIndex, processOnServer){
	this.inherit = ASPxClientColumnCancelEventArgs;
	this.inherit(column, processOnServer);	
	this.sortingOrder = sortingOrder;
	this.sortingIndex = sortingIndex;
}
function ASPxClientColumnMovingEventArgs(column, visibleIndex, processOnServer){
	this.inherit = ASPxClientColumnCancelEventArgs;
	this.inherit(column, processOnServer);
	this.visibleIndex = visibleIndex;
}
function ASPxClientColumnWidthChangingEventArgs(column, width, processOnServer){
	this.inherit = ASPxClientColumnCancelEventArgs;
	this.inherit(column, processOnServer);
	this.width = width;
}
function ASPxClientPageSizeEventArgs(pageSize, processOnServer){
	this.inherit = ASPxClientCancelProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.pageSize = pageSize;
}
function ASPxClientRowCancelEventArgs(row, processOnServer){
	this.inherit = ASPxClientCancelProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.row = row;
}
function ASPxClientRowEventArgs(row){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.row = row;
}
function ASPxClientGridControlElementEventArgs(processOnServer){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.handled = false;
	this.processOnServer = processOnServer;	
}
function ASPxClientGridHeaderClickEventArgs(column, processOnServer){
	this.inherit = ASPxClientGridControlElementEventArgs;
	this.inherit(processOnServer);
	this.column = column;
}
function ASPxClientGridHeaderDragEndEventArgs(column, newVisibleIndex, newGroupIndex, processOnServer){
	this.inherit = ASPxClientGridHeaderClickEventArgs;
	this.inherit(column, processOnServer);	
	this.newVisibleIndex = newVisibleIndex;
	this.newGroupIndex = newGroupIndex;
}
function ASPxClientGridGroupingButtonClickEventArgs(column, newGroupIndex, processOnServer){
	this.inherit = ASPxClientGridHeaderClickEventArgs;
	this.inherit(column, processOnServer);	
	this.newGroupIndex = newGroupIndex;
}
function ASPxClientGridRowClickEventArgs(row, processOnServer){
	this.inherit = ASPxClientGridControlElementEventArgs;
	this.inherit(processOnServer);
	this.row = row;
}
function ASPxClientGridCellClickEventArgs(row, column, processOnServer){
	this.inherit = ASPxClientGridRowClickEventArgs;
	this.inherit(row, processOnServer);
	this.column = column;
}
function ASPxClientGridBarButtonClickEventArgs(barButton, processOnServer){
	this.inherit = ASPxClientGridControlElementEventArgs;
	this.inherit(processOnServer);
	this.barButton = barButton;
}
function ASPxClientGridPageIndexButtonClickEventArgs(barButton, pageIndex, processOnServer){
	this.inherit = ASPxClientGridBarButtonClickEventArgs;
	this.inherit(barButton, processOnServer);
	this.pageIndex = pageIndex;
}
function ASPxClientGridRowButtonClickEventArgs(row, rowButton, processOnServer){
	this.inherit = ASPxClientGridRowClickEventArgs;
	this.inherit(row, processOnServer);
	this.rowButton = rowButton;
}
function ASPxClientGridSearchButtonClickEventArgs(column, searchString, processOnServer){
	this.inherit = ASPxClientGridControlElementEventArgs;
	this.inherit(processOnServer);
	this.column = column;
	this.searchString = searchString;
}
function ASPxClientGridCustomRenderFooterEventArgs(htmlElement, column, width, height, text, beforeDefaultRender){
	this.inherit = ASPxClientGridCustomRenderCellEventArgs;
	this.inherit(htmlElement, column, width, height, beforeDefaultRender);
	this.text = text;
}
function ASPxClientGridCustomRenderHeaderEventArgs(htmlElement, column, inGroupPanel, width, height, text, sortingOrder, beforeDefaultRender){
	this.inherit = ASPxClientGridCustomRenderFooterEventArgs;
	this.inherit(htmlElement, column, width, height, text, beforeDefaultRender);
	this.inGroupPanel = inGroupPanel;
	this.sortingOrder = sortingOrder;
}
function ASPxClientGridCustomRenderTextElementEventArgs(htmlElement, width, height, text, beforeDefaultRender){
	this.inherit = ASPxClientGridCustomRenderEventArgs;
	this.inherit(htmlElement, width, height, beforeDefaultRender);
	this.text = text;
}
function ASPxClientGridBindEventArgs(htmlElement, row, value){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.htmlElement = htmlElement;
	this.row = row;
	this.value = value;
	this.handled = false;
}
function ASPxClientGridBindCellEventArgs(htmlElement, column, row, value){
	this.inherit = ASPxClientGridBindEventArgs;
	this.inherit(htmlElement, row, value);
	this.column = column;	
}
function ASPxClientGridGetCellValueBaseEventArgs(column, row){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.column = column;
	this.row = row;
	this.value = null;
	this.handled = false;
}
function ASPxClientGridGetCellValueEventArgs(column, row, value){
	this.inherit = ASPxClientGridGetCellValueBaseEventArgs;
	this.inherit(column, row);
	
	this.value = value;
}
function ASPxClientGridGetEditValueEventArgs(htmlElement, column, row){
	this.inherit = ASPxClientGridGetCellValueBaseEventArgs;
	this.inherit(column, row);
	this.htmlElement = htmlElement;
}
function ASPxClientGridGetGroupingTextEventArgs(row, column, groupingValue, groupingText){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.row = row;
	this.column = column;
	this.groupingValue = groupingValue;
	this.groupingText = groupingText;
}
function ASPxClientGridFocusEditorEventArgs(htmlElement, column){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.htmlElement = htmlElement;
	this.column = column;
	this.handled = false;
}
function ASPxClientGridBeforeSearchEventArgs(searchColumn, searchString, processOnServer){
	this.inherit = ASPxClientCancelProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.searchColumn = searchColumn;
	this.searchString = searchString;
}
function ASPxClientGridAfterSearchEventArgs(searchColumn, searchString, row){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.searchColumn = searchColumn;
	this.searchString = searchString;
	this.foundRow = row;
}
function ASPxClientGridCustomSummaryEventArgs(summaryItem, row, summaryOwner, totalValue, fieldValue){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.summaryItem = summaryItem;
	this.row = row;
	this.summaryOwner = summaryOwner;
	this.totalValue = totalValue;
	this.fieldValue = fieldValue;
}
function ASPxClientGridCompleteSummaryEventArgs(summaryItem, summaryOwner, summaryValue, summaryCount){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.summaryItem = summaryItem;
	this.summaryOwner = summaryOwner;
	this.summaryValue = summaryValue;
	this.summaryCount = summaryCount;
}
function ASPxClientGridItemEventArgs(htmlElement, itemType, row){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.itemType = itemType;
	this.htmlElement = htmlElement;
	this.row = row;
}