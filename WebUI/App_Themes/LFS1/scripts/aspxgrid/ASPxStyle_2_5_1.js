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

borderColorAttribute = "borderColor";
borderSideColorAttributes = new Object();
borderSideColorAttributes["borderLeftColor"] = true;
borderSideColorAttributes["borderTopColor"] = true;
borderSideColorAttributes["borderRightColor"] = true;
borderSideColorAttributes["borderBottomColor"] = true;
borderStyleAttribute = "borderStyle";
borderSideStyleAttributes = new Object();
borderSideStyleAttributes["borderLeftStyle"] = true;
borderSideStyleAttributes["borderTopStyle"] = true;
borderSideStyleAttributes["borderRightStyle"] = true;
borderSideStyleAttributes["borderBottomStyle"] = true;
borderWidthAttribute = "borderWidth";
borderSideWidthAttributes = new Object();
borderSideWidthAttributes["borderLeftWidth"] = true;
borderSideWidthAttributes["borderTopWidth"] = true;
borderSideWidthAttributes["borderRightWidth"] = true;
borderSideWidthAttributes["borderBottomWidth"] = true;

filterAttribute = "filter";

fontAttributes = new Object();
fontAttributes["color"] = true;
fontAttributes["fontFamily"] = true;
fontAttributes["fontWeight"] = true;
fontAttributes["fontStyle"] = true;
fontAttributes["fontSize"] = true;
fontAttributes["textDecoration"] = true;

tableItemAttributes = new Object();
tableItemAttributes["textAlign"] = true;
tableItemAttributes["verticalAlign"] = true;
tableItemAttributes["whiteSpace"] = true;

function ASPxStyle(){
	this.styleConditions = new Object();
	this.styleConditions["all"] = ASPxStyle.IsAttribute;
	this.styleConditions["style"] = ASPxStyle.IsStyleAttribute;
	this.styleConditions["font"] = ASPxStyle.IsFontAttribute;
	this.styleConditions["table"] = ASPxStyle.IsTableItemAttribute;
	this.styleConditions["filter"] = ASPxStyle.IsFilterAttribute;
	
	this.Initialize = ASPxStyle.Initialize;
	this.Finalize = ASPxStyle.Finalize;
	this.ApplyStyleInternal = ASPxStyle.ApplyStyleInternal;
	this.ApplyCachedStyle = ASPxStyle.ApplyCachedStyle;	
	this.ApplyStyle = ASPxStyle.ApplyStyle;
	this.ApplyStyleAttributes = ASPxStyle.ApplyStyleAttributes;
	this.ApplyFilterAttributes = ASPxStyle.ApplyFilterAttributes;	
	this.ApplyFontAttributes = ASPxStyle.ApplyFontAttributes;
	this.ApplyFontAttributesToTables = ASPxStyle.ApplyFontAttributesToTables;
	this.ApplyTableItemAttributes = ASPxStyle.ApplyTableItemAttributes;
	this.ApplyStyleAspButtonState = ASPxStyle.ApplyStyleAspButtonState;
	this.ApplyClassAttributesToInnerElement = ASPxStyle.ApplyClassAttributesToInnerElement;
	
	this.MergeTo = this.ApplyStyle;
	this.MergeStyle = ASPxStyle.MergeStyle;
	this.MergeStyleProperties = ASPxStyle.MergeStyleProperties;
	this.MergeStyleFilterAttributes = ASPxStyle.MergeStyleFilterAttributes;
	
	this.AddAttribute = ASPxStyle.AddAttribute;
	this.AddAttributes = ASPxStyle.AddAttributes;
	this.RemoveAttribute = ASPxStyle.RemoveAttribute;
	this.RemoveBorderSideColorAttributes = ASPxStyle.RemoveBorderSideColorAttributes;
	this.RemoveBorderSideStyleAttributes = ASPxStyle.RemoveBorderSideStyleAttributes;
	this.RemoveBorderSideWidthAttributes = ASPxStyle.RemoveBorderSideWidthAttributes;
	
	this.ClearCache = ASPxStyle.ClearCache;
	this.ClearStyle = ASPxStyle.ClearStyle;
	this.ClearStyleFilter = ASPxStyle.ClearStyleFilter;
	
	this.GetBorderLessStyle = ASPxStyle.GetBorderLessStyle;
	this.GetBorderLeftWidth = ASPxStyle.GetBorderLeftWidth;	
	this.GetBorderRightWidth = ASPxStyle.GetBorderRightWidth;
	this.GetBorderTopWidth = ASPxStyle.GetBorderTopWidth;
	this.GetBorderBottomWidth = ASPxStyle.GetBorderBottomWidth;
	this.GetHorizontalAlign = ASPxStyle.GetHorizontalAlign;
	this.GetClientWidth = ASPxStyle.GetClientWidth;
	this.GetClientHeight = ASPxStyle.GetClientHeight;
}

ASPxStyle.Initialize = function(){
	this.attributes = new Object();
	
	this.cssClass = "";
	this.endEllipsis = true;
	this.fixedWidth = false;
	this.fixedHeight = false;

	this.useHotTrackStyle = null;
	this.usePressedStyle = null;
	
	this.cachedElements = null;
	this.cachedCssTexts = null;
}
ASPxStyle.Finalize = function(){
}

ASPxStyle.ApplyStyleInternal = function(key, element, clearOldAttributes, returnOldStyle, useCache){
	var style = null;
	var condition = this.styleConditions[key];
	if(returnOldStyle){
		style = ASPxStyle.CreateStyle();
		for(i in this.attributes)
			if(condition(i))
				style.attributes[i] = element.style[i];
		if(condition("cssClass"))
			style.cssClass = element.className;
	}
	
	if(useCache && clearOldAttributes)
		this.ApplyCachedStyle(key, element);
	else {
		if(clearOldAttributes)
			element.style.cssText = "";
		for(i in this.attributes)
			if(condition(i))
				element.style[i] = this.attributes[i];
	}
	if(this.cssClass != "" && condition("cssClass"))
		element.className = this.cssClass;
	
	return style;	
}
ASPxStyle.ApplyCachedStyle = function(key, element){
	if(!_isExists(this.cachedElements))
		this.cachedElements = new Object();
	if(!_isExists(this.cachedCssTexts))
		this.cachedCssTexts = new Object();

	if(!_isExists(this.cachedElements[key])){
		this.cachedElements[key] = document.createElement("SPAN");
		this.ApplyStyleInternal(key, this.cachedElements[key], false, false, false);
		this.cachedCssTexts[key] = this.cachedElements[key].style.cssText;
	}
	if(_isExists(element))
		element.style.cssText = this.cachedCssTexts[key];
}

ASPxStyle.ApplyStyle = function(element, useCache){
	return this.ApplyStyleInternal("all", element, useCache, false, useCache);
}
ASPxStyle.ApplyStyleAttributes = function(element, useCache){
	return this.ApplyStyleInternal("style", element, useCache, false, useCache);
}
ASPxStyle.ApplyFilterAttributes = function(element, useCache){
	return this.ApplyStyleInternal("filter", element, useCache, false, useCache);
}
ASPxStyle.ApplyFontAttributes = function(element, useCache){
	return this.ApplyStyleInternal("font", element, useCache, false, useCache);
}
ASPxStyle.ApplyTableItemAttributes = function(element, useCache){
	return this.ApplyStyleInternal("table", element, useCache, false, useCache);
}
ASPxStyle.ApplyFontAttributesToTables = function(element, useCache, applyToRootElement){
	if(applyToRootElement && _isExists(element.tagName) && element.tagName.toUpperCase() == "TABLE"){
		this.ApplyFontAttributes(element, useCache);
		if(this.cssClass != "")
			element.className = this.cssClass;
	}
	for(var i = 0; i < _getChildNodes(element).length; i ++){
		this.ApplyFontAttributesToTables(_getChildNode(element, i), useCache, true);
	}
}
ASPxStyle.ApplyStyleAspButtonState = function(element){
	return this.ApplyStyleInternal("style", element, false, true, false);
}
ASPxStyle.ApplyClassAttributesToInnerElement = function(element, useCache){
	if(this.cssClass != ""){
		element.className = this.cssClass;
		element.style.borderStyle = "none";
		element.style.filter = "";
	}

}
ASPxStyle.MergeStyleProperties = function(style){
	if(style.cssClass != "")
		this.cssClass = style.cssClass;
	if(style.fixedWidth)
		this.fixedWidth = style.fixedWidth;
	if(style.fixedHeight)
		this.fixedHeight = style.fixedHeight;
	if(style.useHotTrackStyle != null)
		this.useHotTrackStyle = style.useHotTrackStyle;
	if(style.usePressedStyle != null)
		this.usePressedStyle = style.usePressedStyle;
}

ASPxStyle.MergeStyle = function(style){
	this.ClearCache();
	this.MergeStyleProperties(style);
	this.MergeStyleFilterAttributes(style);
	for(i in style.attributes)
		if(!ASPxStyle.IsFilterAttribute(i)){
			this.attributes[i] = style.attributes[i];
			if(ASPxStyle.IsBorderColorAttribute(i))
				this.RemoveBorderSideColorAttributes();
			if(ASPxStyle.IsBorderStyleAttribute(i))
				this.RemoveBorderSideStyleAttributes();
			if(ASPxStyle.IsBorderWidthAttribute(i))
				this.RemoveBorderSideWidthAttributes();
		}
}
ASPxStyle.MergeStyleFilterAttributes = function(style){
	this.ClearCache();
	for(i in style.attributes)
		if(ASPxStyle.IsFilterAttribute(i)){
			var oldFilterAttribute = (this.attributes[i] != null) ? this.attributes[i] : "";
			if(oldFilterAttribute != "" && style.attributes[i] != "") 
				this.attributes[i] = oldFilterAttribute + " " + style.attributes[i];
			else if(style.attributes[i] != "")
				this.attributes[i] = style.attributes[i];
		}
}
ASPxStyle.AddAttributes = function(attributes){
	this.ClearCache();
	for(var i = 0; i < attributes.length; i ++)
		if(_isExists(attributes[i][0]) && _isExists(attributes[i][1]))
			this.attributes[attributes[i][0]] = attributes[i][1];
}
ASPxStyle.AddAttribute = function(attribute, value){
	this.ClearCache();
	this.attributes[attribute] = value;
}
ASPxStyle.RemoveAttribute = function(attribute){
	this.ClearCache();
	oldAttributes = this.attributes;
	this.attributes = new Object();
	for(i in oldAttributes){
		if(i != attribute)
			this.attributes[i] = oldAttributes[i];
	}
}
ASPxStyle.RemoveBorderSideColorAttributes = function(){
	this.ClearCache();
	oldAttributes = this.attributes;
	this.attributes = new Object();
	for(i in oldAttributes){
		if(!ASPxStyle.IsBorderSideColorAttribute(i))
			this.attributes[i] = oldAttributes[i];
	}
}
ASPxStyle.RemoveBorderSideStyleAttributes = function(){
	this.ClearCache();
	oldAttributes = this.attributes;
	this.attributes = new Object();
	for(i in oldAttributes){
		if(!ASPxStyle.IsBorderSideStyleAttribute(i))
			this.attributes[i] = oldAttributes[i];
	}
}
ASPxStyle.RemoveBorderSideWidthAttributes = function(){
	this.ClearCache();
	oldAttributes = this.attributes;
	this.attributes = new Object();
	for(i in oldAttributes){
		if(!ASPxStyle.IsBorderSideWidthAttribute(i))
			this.attributes[i] = oldAttributes[i];
	}
}
ASPxStyle.ClearStyle = function(){
	this.cssClass = "";
	this.fixedWidth = false;
	this.fixedHeight = false;
	this.useHotTrackStyle = null;
	this.usePressedStyle = null;
	for(i in this.attributes)
		this.attributes[i] = null;
}
ASPxStyle.ClearCache = function(){
	this.cachedElements = null;
	this.cachedCssTexts = null;
}
ASPxStyle.ClearStyleFilter = function(){
	this.attributes["filter"] = null;
}

ASPxStyle.IsAttribute = function(attribute){
	return true;
}
ASPxStyle.IsStyleAttribute = function(attribute){
	return !_isExists(tableItemAttributes[attribute]);
}
ASPxStyle.IsFontAttribute = function(attribute){
	return _isExists(fontAttributes[attribute])
}
ASPxStyle.IsTableItemAttribute = function(attribute){
	return _isExists(tableItemAttributes[attribute])
}
ASPxStyle.IsFilterAttribute = function(attribute){
	return (attribute == filterAttribute);
}
ASPxStyle.IsBorderColorAttribute = function(attribute){
	return (attribute == borderColorAttribute);
}
ASPxStyle.IsBorderStyleAttribute = function(attribute){
	return (attribute == borderStyleAttribute);
}
ASPxStyle.IsBorderWidthAttribute = function(attribute){
	return (attribute == borderWidthAttribute);
}
ASPxStyle.IsBorderSideColorAttribute = function(attribute){
	return _isExists(borderSideColorAttributes[attribute])
}
ASPxStyle.IsBorderSideStyleAttribute = function(attribute){
	return _isExists(borderSideStyleAttributes[attribute])
}
ASPxStyle.IsBorderSideWidthAttribute = function(attribute){
	return _isExists(borderSideWidthAttributes[attribute])
}

ASPxStyle.IsBorderAttribute = function(attribute){
	return ASPxStyle.IsBorderSideColorAttribute(attribute) || 
		ASPxStyle.IsBorderSideStyleAttribute(attribute) ||
		ASPxStyle.IsBorderSideWidthAttribute(attribute) ||
		ASPxStyle.IsBorderColorAttribute(attribute) || 
		ASPxStyle.IsBorderStyleAttribute(attribute) ||
		ASPxStyle.IsBorderWidthAttribute(attribute);
}

ASPxStyle.GetBorderLessStyle = function(){
	var ret = ASPxStyle.CreateStyle();
	ret.MergeStyleProperties(this);
	for(i in this.attributes){
		if(!ASPxStyle.IsBorderAttribute(i))
			ret.attributes[i] = this.attributes[i];
	}
	return ret;
}
ASPxStyle.GetBorderLeftWidth = function(){
	if(_isExists(this.attributes["borderLeftWidth"]))
		return this.attributes["borderLeftWidth"];
	return this.attributes["borderWidth"];
}
ASPxStyle.GetBorderRightWidth = function(){
	if(_isExists(this.attributes["borderRightWidth"]))
		return this.attributes["borderRightWidth"];
	return this.attributes["borderWidth"];
}
ASPxStyle.GetBorderTopWidth = function(){
	if(_isExists(this.attributes["borderTopWidth"]))
		return this.attributes["borderTopWidth"];
	return this.attributes["borderWidth"];
}
ASPxStyle.GetBorderBottomWidth = function(){
	if(_isExists(this.attributes["borderBottomWidth"]))
		return this.attributes["borderBottomWidth"];
	return this.attributes["borderWidth"];
}
ASPxStyle.GetHorizontalAlign = function(){
	if(_isExists(this.attributes["textAlign"]))
		return this.attributes["textAlign"];
	return "";
}

ASPxStyle.GetClientWidth = function(width){
	var clientWidth = width;
	if(clientWidth != null){
		var borderLeftWidth = ASPxClientUnit.Parse(this.GetBorderLeftWidth());
		var borderRightWidth = ASPxClientUnit.Parse(this.GetBorderRightWidth());
		if(clientWidth.type == "px" && borderLeftWidth != null && borderLeftWidth.type == "px" && borderRightWidth != null && borderRightWidth.type == "px"){
			clientWidth = clientWidth.Sub(borderLeftWidth);
			clientWidth = clientWidth.Sub(borderRightWidth);
		}
	}
	return clientWidth;
}
ASPxStyle.GetClientHeight = function(height){
	var clientHeight = height;
	if(clientHeight != null){
		var borderTopWidth = ASPxClientUnit.Parse(this.GetBorderTopWidth());
		var borderBottomWidth = ASPxClientUnit.Parse(this.GetBorderBottomWidth());
		if(clientHeight.type == "px" && borderTopWidth != null && borderTopWidth.type == "px" && borderBottomWidth != null && borderBottomWidth.type == "px"){
			clientHeight = clientHeight.Sub(borderTopWidth);
			clientHeight = clientHeight.Sub(borderBottomWidth);
		}
	}
	return clientHeight;
}

ASPxStyle.GetStyleByElement = function(element){
	var style = ASPxStyle.CreateStyle();
	for(i in element.style)
		style.attributes[i] = element.style[i];
	style.cssClass = element.className;
	return style;	
}

var styleCache = new Array();

ASPxStyle.CreateStyle = function(){
	var style;
	if(styleCache.length > 0)
		style = styleCache.pop();
	else
		style = new ASPxStyle();
	style.Initialize();
	return style;
}

ASPxStyle.RemoveStyle = function(style){
	styleCache.push(style);
}