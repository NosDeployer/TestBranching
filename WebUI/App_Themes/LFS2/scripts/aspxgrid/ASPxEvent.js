
function ASPxClientEvent() {
	this.handlerList = [];
	this.AddHandler = function (handler) {
		this.handlerList.push(handler);
	}
	this.RemoveHandler = function (handler) {
		array_remove(this.handlerList, handler);
	}
	this.ClearHandlers = function () {
		array_clear(this.handlerList);
	}
	this.FireEvent = function (obj, args) {
		for(var i = 0; i < this.handlerList.length; i++) {
			this.handlerList[i](obj, args);
		}
	}
	
	this.IsEmpty = function (){
		return this.handlerList.length == 0;
	}
}
function ASPxClientEventArgs(){
}
function ASPxClientCancelEventArgs(){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.cancel = false;
}
function ASPxClientHandledEventArgs(){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.handled = false;
}
function ASPxClientValidateEventArgs(value){
	this.inherit = ASPxClientCancelEventArgs;
	this.inherit();
	this.value = value;
	this.message = "";
}
function ASPxClientProcessingModeEventArgs(processOnServer){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.processOnServer = processOnServer;
}
function ASPxClientCancelProcessingModeEventArgs(processOnServer){
	this.inherit = ASPxClientCancelEventArgs;
	this.inherit();
	this.processOnServer = processOnServer;
}
function ASPxClientDataControllerValidateEventArgs(row, column, value){
	this.inherit = ASPxClientValidateEventArgs;
	this.inherit(value);
	this.row = row;
	this.column = column;
}
function ASPxClientDataControllerCommandEventArgs(row){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.row = row;
}
function ASPxClientBeforeDataControllerCommandEventArgs(row, processOnServer){
	this.inherit = ASPxClientCancelProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.row = row;
}
function ASPxClientBeforeDataControllerNewRowCommandEventArgs(row, append, processOnServer){
	this.inherit = ASPxClientBeforeDataControllerCommandEventArgs;
	this.inherit(row, processOnServer);
	this.append = append;
}
function ASPxClientDataControllerBeforeSearchEventArgs(searchColumn, searchString, processOnServer){
	this.inherit = ASPxClientCancelProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.searchColumn = searchColumn;
	this.searchString = searchString;
}
function ASPxClientDataControllerAfterSearchEventArgs(searchColumn, searchString, foundRow){
	this.inherit = ASPxClientEventArgs;
	this.inherit();
	this.searchColumn = searchColumn;
	this.searchString = searchString;
	this.foundRow = foundRow;
}
function ASPxClientCompareRowsEventArgs(column, row1, row2, value1, value2, action){
	this.inherit = ASPxClientHandledEventArgs;
	this.inherit();
	this.column = column;
	this.row1 = row1;
	this.row2 = row2;
	this.value1 = value1;
	this.value2 = value2;
	this.action = action;
	this.result = 0;
}
function ASPxClientKeyEventArgs(keyCode, alt, control, shift){
	this.inherit = ASPxClientHandledEventArgs;
	this.inherit();
	this.keyCode = keyCode;
	this.alt = alt;
	this.control = control;
	this.shift = shift;
}
function ASPxClientProcessingModeKeyEventArgs(keyCode, alt, control, shift, processOnServer){
	this.inherit = ASPxClientKeyEventArgs;
	this.inherit(keyCode, alt, control, shift);
	this.processOnServer = processOnServer;	
}