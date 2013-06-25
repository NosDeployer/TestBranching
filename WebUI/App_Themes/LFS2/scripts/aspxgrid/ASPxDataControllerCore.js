

function ASPxClientDataControllerCore(name){	
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	
	
	this.ApplyCallBackHtml = function(html){
		var element = _getElementById(this.name);
		var CBContainer = _getParentByCssClass(element, "CBContainer");
		CBContainer.innerHTML = html;
	}
}