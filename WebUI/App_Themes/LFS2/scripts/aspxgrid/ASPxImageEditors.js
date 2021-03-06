
function ASPxClientImageBase(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientEditorBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.GetImageElement = function(element){
		return !_checkTagName(element, "IMG") ? _getChildByTagName(element, "IMG", 0) : element;
	}
	
	this.CanEditValue = function(){
		return false;
	}
}
function ASPxClientImage(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientImageBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.BindValue = function(element, value, editMode, renderValueDirectly){
		var imgElement = this.GetImageElement(element);
		if(imgElement != null) imgElement.src = this.GetDisplayTextByValue(value);
	}
	this.GetViewerValue = function(element){
		var imgElement = this.GetImageElement(element);
		return (imgElement != null) ? imgElement.src : "";
	}
	this.GetUrl = function(){
		var value = this.GetEditValue();
		return (value != null) ? value.toString() : "";
	}
	this.SetUrl = function(url){
		this.SetEditValue(url);
	}
}
function ASPxClientBinaryImage(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientImageBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.BindValue = function(element, value, editMode, renderValueDirectly){
		var imgElement = this.GetImageElement(element);
		if(imgElement != null)
			imgElement.src = _getDocumentUrlWithQuery(this.name + "=" + value);
	}
	this.GetDisplayTextByValue = function(value){
		return "(IMAGE)";
	}
	this.GetViewerValue = function(element){
		return "";
	}
}