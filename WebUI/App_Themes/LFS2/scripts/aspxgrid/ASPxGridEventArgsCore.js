
function ASPxClientGridCustomRenderEventArgs(htmlElement, width, height, beforeDefaultRender){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.htmlElement = htmlElement;
	this.width = width;
	this.height = height;
	this.beforeDefaultRender = beforeDefaultRender;
	this.handled = false;
}
function ASPxClientGridCustomRenderCellEventArgs(htmlElement, column, width, height, beforeDefaultRender){
	this.inherit = ASPxClientGridCustomRenderEventArgs;
	this.inherit(htmlElement, width, height, beforeDefaultRender);
	this.column = column;
}
function ASPxClientGridCustomRenderExpandBtnEventArgs(htmlElement, rowExpanded, width, height, beforeDefaultRender){
	this.inherit = ASPxClientGridCustomRenderEventArgs;
	this.inherit(htmlElement, width, height);
	this.rowExpanded = rowExpanded;
}
function ASPxClientGridCustomRenderRowBtnEventArgs(htmlElement, column, rowButton, inHeaderPanel, width, height, imageUrl, beforeDefaultRender){
	this.inherit = ASPxClientGridCustomRenderCellEventArgs;
	this.inherit(htmlElement, column, width, height, beforeDefaultRender);
	this.rowButton = rowButton;
	this.inHeaderPanel = inHeaderPanel;
	this.imageUrl = imageUrl;
}
function ASPxClientGridCustomRenderSelectionEventArgs(htmlElement, column, isGroupRow, selected){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.htmlElement = htmlElement;
	this.column = column;
	this.isGroupRow = isGroupRow;
	this.selected = selected;
	this.handled = false;
}