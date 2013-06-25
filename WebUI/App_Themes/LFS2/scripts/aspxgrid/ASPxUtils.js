
function ASPxClientUtils(){
}

var callBackIDParamName = "__ASPxCallBackID";
var callBackActionParamName = "__ASPxCallBackAction";

var callBackResultListenerMark = "$Ls$";
var callBackResultListenerBlockMark = "$Lb$";
var callBackSuccessIdent = "$!$";

var kbShift = 16;
var kbCtrl = 17;
var kbAlt = 18;
var kbBackSpace = 8;
var kbTab = 9;
var kbEnter = 13;
var kbEsc = 27;
var kbSpace = 32;
var kbPgUp = 33;
var kbPgDown = 34;
var kbEnd = 35;
var kbHome = 36;
var kbLeft = 37;
var kbUp = 38;
var kbRight = 39;
var kbDown = 40;
var kbInsert = 45;
var kbDelete = 46;
var kbPlus = 107;
var kbMinus = 109;
var kbF1 = 112;
var kbF2 = 113;
var kbF3 = 114;
var kbF4 = 115;
var kbF5 = 116;
var kbF6 = 117;
var kbF7 = 118;
var kbF8 = 119;
var kbF9 = 120;
var kbF10 = 121;
var kbF11 = 122;
var kbF12 = 123;

var krHandled = 0;
var krUnhandled = 1;
var krSystem = 2;

var hotTrackEnabled = true;
var pressedEnabled = true;

var mouseButton = 0;
var leftBtnPressed = 1;
var rightBtnPressed = 2;
var mouseWheelShift = 3;

var horzTextPadding = 4;
var indicatorImgZIndex = 9000;
var popupZIndex = 10000;
var dragHdrZIndex = 100000;

var agent = navigator.userAgent.toLowerCase();
var opera = (agent.indexOf("opera") > -1);
var safari = agent.indexOf("safari") > -1;
var ie6 = ((agent.indexOf("msie 5.5") > -1 || agent.indexOf("msie 6") > -1) && !opera);
var ie4 = ((agent.indexOf("msie") > -1 && document.all && !ie6) && !opera);
var ie = ie4 || ie6;
var ns4 = (agent.indexOf("mozilla/4") >-1 && agent.indexOf("msie") == -1) && !safari;
var ns6 = (agent.indexOf("mozilla/5") >-1 && agent.indexOf("netscape6") > -1) && !safari;
var ns7 = (agent.indexOf("mozilla/5") >-1 && agent.indexOf("netscape/7") > -1) && !safari;
var mozilla = (agent.indexOf("mozilla/5") >-1 && agent.indexOf("netscape6") == -1 && agent.indexOf("netscape/7") == -1 && agent.indexOf("firefox") == -1) && !safari;
var mozillaVersion = 0;
if(mozilla){
	var str = agent;
	var index = agent.indexOf("rv:");
	if(index > -1){
		str = str.substring(index + 3, str.length);
		mozillaVersion = Number(str.substr(0, 1)) * 100 + Number(str.substr(2, 1)) * 10;
		var separator = str.substr(3, 1);
		if(separator == ".")
			mozillaVersion += Number(str.substr(4, 1));
	}
}
var mozillaCorrectScrollBarVersion = 175;
var firefox = agent.indexOf("firefox") > -1;
var nsUpLevel = ns6 || ns7 || mozilla || firefox;

function insp(obj) {
	alert(getObjInfo(obj));
}
function getObjInfo(obj) {
	var array = new Array();
	for(var key in obj) {
	    if(key.indexOf("on") != 0 && key.indexOf("outer") != 0 && key.indexOf("inner") != 0) {
			var value = eval("obj." + key).toString();
			if(value.indexOf("function") < 0)
				array.push(" " + key + " = " + value);
		}
	}
	array.sort();
	return array.join("\t");
}

function _isExistsType(type){
	return (type != "undefined");
}

function _isFunctionType(type){
	return (type == "function");
}

function _isStringType(type){
	return (type == "string");
}

function _isExists(obj){
	return (typeof(obj) != "undefined") && (obj != null);
}

function _isFunction(obj){
	return typeof(obj) == "function";
}

function _isString(obj){
	return typeof(obj) == "string";
}

function _isBoolean(obj){
	return typeof(obj) == "boolean";
}

function _isNumber(obj){
	return typeof(obj) == "number" && !isNaN(obj);
}

function _isDate(obj){
	return (typeof(obj) == "object") && (obj != null) && _isFunction(obj.getDate);
}

function _getElementById(id){
	return document.getElementById(id);
}
ASPxClientUtils.GetElementById = function(id){
	return _getElementById(id);
}

function _getChildById(element, id){
	if(ie){
		return element.all[id];
	}
	else{
		var nodes = _getChildNodes(element);
		for(var i = 0; i < nodes.length; i ++){
			if(nodes[i].id == id) return nodes[i];
		}	
		for(var i = 0; i < nodes.length; i ++){
			var ret = _getChildById(nodes[i], id);
			if(ret != null) return ret;
		}	
		return null;
	}
}
ASPxClientUtils.GetChildById = function(element, id){
	return _getChildById(element, id);
}

function _getIsParent(parentElement, element){
	while(element != null){
		if(_checkTagName(element, "BODY")) return false;
		if(element == parentElement) return true;
		element = _getParentNode(element);
	}
	return false;
}
ASPxClientUtils.IsParent = function(parentElement, element){
	return _getIsParent(parentElement, element);
}

function _getParentById(element, id){
	element = _getParentNode(element);
	while(element != null){
		if(element.id == id) return element;
		element = _getParentNode(element);
	}
	return null;
}
ASPxClientUtils.GetParentById = function(element, id){
	return _getParentById(element, id);
}

function _checkTagName(element, tagName){
	return _checkTagNames(element, [tagName]);
}

function _checkTagNames(element, tagNames){
	if(element != null && _isExists(element.tagName)){
		var elementTagName = element.tagName.toUpperCase();
		for(var i = 0; i < tagNames.length; i ++){
			if(tagNames[i].toUpperCase() == elementTagName)
				return true;
		}
	}
	return false;
}

function _getChildByTagName(element, tagName, index){
	if(element != null){		
		tagName = tagName.toUpperCase();
		var collection = ie ? element.all.tags(tagName) : element.getElementsByTagName(tagName);
		if(collection != null){
			if(index < collection.length)
				return collection[index];
		}
	}
	return null;
}
ASPxClientUtils.GetChildByTagName = function(element, tagName, index){
	return _getChildByTagName(element, tagName, index);
}

function _getChildByTagNameEx(element, tagName, index, recursive){
	if(element != null){		
		tagName = tagName.toUpperCase();
		var childNodes = _getChildNodes(element);
		for(var i = 0, curIndex = -1; i < childNodes.length; i ++){
			var nodeTagName = childNodes[i].tagName;
			if(nodeTagName != undefined && nodeTagName.toUpperCase() == tagName)
				curIndex ++;
			if(curIndex == index)
				return childNodes[i];
		}
		if(recursive){
			for(var i = 0; i < childNodes.length; i ++){
				var foundNode = _getChildByTagNameEx(childNodes[i], tagName, index, recursive);
				if(foundNode != null)
					return foundNode;
			}
		}
	}
	return null;
}
ASPxClientUtils.GetChildByTagNameEx = function(element, tagName, index, recursive){
	return _getChildByTagNameEx(element, tagName, index, recursive);
}

function _getParentByTagName(element, tagName){
	element = _getParentNode(element);
	tagName = tagName.toUpperCase();
	while(element != null){
		if(element.tagName.toUpperCase() == tagName) return element;
		element = _getParentNode(element);
	}
	return null;
}
ASPxClientUtils.GetParentByTagName = function(element, tagName){
	return _getParentByTagName(element, tagName);
}

function _getChildByCssClass(element, cssClass){
	var nodes = _getChildNodes(element);
	for(var i = 0; i < nodes.length; i ++){
		if(nodes[i].className == cssClass) return nodes[i];
	}	
	for(var i = 0; i < nodes.length; i ++){
		var ret = _getChildByCssClass(nodes[i], cssClass);
		if(ret != null) return ret;
	}	
	return null;
}

function _getParentByCssClass(element, cssClass){
	element = _getParentNode(element);
	while(element != null){
		if(element.className == cssClass) return element;
		element = _getParentNode(element);
	}
	return null;
}

function _getParentNode(element){
	return element.parentNode;
}
ASPxClientUtils.GetParentNode = function(element){
	return _getParentNode(element);
}

function _getChildNodes(element){
	return element.childNodes;
}
ASPxClientUtils.GetChildNodes = function(element){
	return _getChildNodes(element);
}

function _getChildNode(element, childNodeIndex){
	return element.childNodes[childNodeIndex];
}
ASPxClientUtils.GetChildNode = function(element, childNodeIndex){
	return _getChildNode(element, childNodeIndex);
}

function _getParentNodes(element){
	return element.parentNode.childNodes;
}

function _getFirstChild(element){
	var firstChild = element.firstChild;
	while(firstChild != null && firstChild.tagName == undefined){
		firstChild = firstChild.nextSibling;
	}
	return firstChild;
}
ASPxClientUtils.GetFirstChild = function(element){
	return _getFirstChild(element);
}

function _getLastChild(element){
	var lastChild = element.lastChild;
	while(lastChild != null && lastChild.tagName == undefined){
		lastChild = lastChild.previousSibling;
	}
	return lastChild;
}
ASPxClientUtils.GetLastChild = function(element){
	return _getLastChild(element);
}

function _getPreviousSibling(element){
	return element.previousSibling;
}
ASPxClientUtils.GetPreviousSibling = function(element){
	return _getPreviousSibling(element);
}

function _getNextSibling(element){
	return element.nextSibling;
}
ASPxClientUtils.GetNextSibling = function(element){
	return _getNextSibling(element);
}

function _getSibling(element, siblingIndex){
	return element.parentNode.childNodes[siblingIndex];
}
ASPxClientUtils.GetSibling = function(element, siblingIndex){
	return _getSibling(element, siblingIndex);
}

function _getElementIndex(element){
	return array_indexOf(element.parentNode.childNodes, element);
}
ASPxClientUtils.GetElementIndex = function(element){
	return _getElementIndex(element);
}

function _removeElement(element){
	var parentElement = _getParentNode(element);
	if(parentElement != null) parentElement.removeChild(element);
}
ASPxClientUtils.RemoveElement = function(element){
	_removeElement(element);
}

function _clearElementChildren(element){
	if(element != null){
		while(element.firstChild != null){
			element.removeChild(element.firstChild);
		}
	}
}
ASPxClientUtils.ClearElementChildren = function(element){
	return _clearElementChildren(element);
}

function _isElementDisplayed(element){
	while(_isExists(element)){
		if(_isExists(element.style) && !_getElementDisplay(element))
			return false;
		element = _getParentNode(element);
	}
	return true;
}

function _isElementVisible(element){
	while(_isExists(element)){
		if(_isExists(element.style) && !_getElementVisibility(element))
			return false;
		element = _getParentNode(element);
	}
	return true;
}

function _isElementEnabled(element){
	while(_isExists(element)){
		if(_isExists(element.disabled) && element.disabled)
			return false;
		element = _getParentNode(element);
	}
	return true;
}

function _focusElement(element){
	if(_isExists(element.focus) && _isElementDisplayed(element) && _isElementVisible(element) && _isElementEnabled(element))
		element.focus();
}

function _selectElement(element){
	if(_isExists(element.select) && _isElementDisplayed(element) && _isElementVisible(element) && _isElementEnabled(element))
		element.select();
}

function _checkElementOverflow(curEl, overflow){
	return curEl.style.overflow == overflow || curEl.style.overflowX == overflow || curEl.style.overflowY == overflow || ie && (curEl.currentStyle.overflow == overflow || curEl.currentStyle.overflowX == overflow || curEl.currentStyle.overflowY == overflow);
}

function _isScrollableElement(curEl){
	return _checkElementOverflow(curEl, "scroll") || _checkElementOverflow(curEl, "auto");
}

function _isStaticElement(curEl){
	return !(curEl.style.position == "absolute" || curEl.style.position == "relative" || ie && (curEl.currentStyle.position == "absolute" || curEl.currentStyle.position == "relative") || _isScrollableElement(curEl));
}

function _isTerminalElement(curEl){
	return _isScrollableElement(curEl) && (curEl.style.width != "" || curEl.style.height != "" || ie && (curEl.currentStyle.width != "" || curEl.currentStyle.height != ""));
}

function _absoluteX(curEl, ownerElementId, correctPos, correctionNeeded, checkTermEl, addElOffset){
    var posX = 0;
    if(curEl != null){
		if(curEl.offsetParent != null){		
			var nestedCorrectPos = ie ? (correctionNeeded && (correctPos || curEl.id == ownerElementId)) : (correctPos && curEl.id == ownerElementId);
			addElOffset = addElOffset && (!correctPos || !_isTerminalElement(curEl) || !checkTermEl);
			posX = _absoluteX(curEl.offsetParent, ownerElementId, nestedCorrectPos, correctionNeeded, checkTermEl, addElOffset);
			if(addElOffset && ((curEl.clientWidth != 0 || !ie) && (!correctPos || _isStaticElement(curEl))))
				posX += curEl.offsetLeft + (ie && curEl.tagName.toLowerCase() != "table" ? curEl.clientLeft : 0);
			if((!correctPos || !checkTermEl))
				posX -= curEl.scrollLeft;
		}
		else{
			posX = curEl.offsetLeft;
		}
	}
    return posX;
}

function _absoluteY(curEl, ownerElementId, correctPos, correctionNeeded, checkTermEl, addElOffset){
    var posY = 0;    
    if(curEl.offsetParent != null){
		var nestedCorrectPos = ie ? (correctionNeeded && (correctPos || curEl.id == ownerElementId)) : (correctPos && curEl.id == ownerElementId);
		addElOffset = addElOffset && (!correctPos || !_isTerminalElement(curEl) || !checkTermEl);
		posY = _absoluteY(curEl.offsetParent, ownerElementId, nestedCorrectPos, correctionNeeded, checkTermEl, addElOffset);
		if(addElOffset && ((curEl.clientHeight != 0 || !ie) && (!correctPos || _isStaticElement(curEl))))
			posY += curEl.offsetTop + (ie && curEl.tagName.toLowerCase() != "table" ? curEl.clientTop : 0);
		if((!correctPos || !checkTermEl))
			posY -= curEl.scrollTop;
    }
    else{
        posY = curEl.offsetTop;
    }
    return posY;
}

function _setElementLeft(element, value){
	if(value < 0) value = 0;
	element.style.left = value;
}
ASPxClientUtils.SetElementLeft = function(element, value){
	return _setElementLeft(element, value);
}

function _setElementTop(element, value){
	if(value < 0) value = 0;
	element.style.top = value;
}
ASPxClientUtils.SetElementTop = function(element, value){
	return _setElementTop(element, value);
}

function _setElementWidth(element, value){
	if(value < 0) value = 0;
	element.style.width = value;
}
ASPxClientUtils.SetElementWidth = function(element, value){
	return _setElementWidth(element, value);
}

function _setElementHeight(element, value){
	if(value < 0) value = 0;
	element.style.height = value;
}
ASPxClientUtils.SetElementHeight = function(element, value){
	return _setElementHeight(element, value);
}

function _getElementLeft(element){
	return element.offsetLeft;
}
ASPxClientUtils.GetElementLeft = function(element){
	return _getElementLeft(element);
}

function _getElementTop(element){
	return element.offsetTop;
}
ASPxClientUtils.GetElementTop = function(element){
	return _getElementTop(element);
}

function _getElementWidth(element){
	if((safari || opera) && element.offsetWidth == 0 && _checkTagNames(element, ["TR", "TBODY"])){
		var tableElement = _getParentByTagName(element, "TABLE");
		if(tableElement != null)
			return tableElement.offsetWidth;
	}
	return element.offsetWidth;
}
ASPxClientUtils.GetElementWidth = function(element){
	return _getElementWidth(element);
}

function _getElementHeight(element){
	if((safari || opera) && element.offsetWidth == 0 && _checkTagNames(element, ["TR", "TBODY"])){
		var tableElement = _getParentByTagName(element, "TABLE");
		if(tableElement != null && (tableElement.rows.length == 1 || _checkTagName(element, "TBODY")))
			return tableElement.offsetHeight;
		else{
			var cellElement = _getChildByTagName(element, "TD", 0);
			if(cellElement != null)
				return cellElement.offsetHeight;
		}
	}
	return element.offsetHeight;
}
ASPxClientUtils.GetElementHeight = function(element){
	return _getElementHeight(element);
}

function _getElementRight(element){
	return _getElementLeft(element) + _getElementWidth(element);
}
ASPxClientUtils.GetElementRight = function(element){
	return _getElementRight(element);
}

function _getElementBottom(element){
	return _getElementTop(element) + _getElementHeight(element);
}
ASPxClientUtils.GetElementBottom = function(element){
	return _getElementBottom(element);
}

function _getElementDisplay(element){
	return element.style.display != "none";
}
ASPxClientUtils.GetElementDisplay = function(element){
	return _getElementDisplay(element);
}

function _setElementDisplay(element, value){
	element.style.display = value ? "" : "none";
}
ASPxClientUtils.SetElementVisibility = function(element, value){
	return _setElementDisplay(element, value);
}

function _getElementVisibility(element){
	return (element.style.visibility != "hidden");
}
ASPxClientUtils.SetElementVisibility = function(element){
	return _getElementVisibility(element);
}

function _setElementVisibility(element, value){
	element.style.visibility = value ? "visible" : "hidden";
}
ASPxClientUtils.SetElementVisibility = function(element, value){
	return _setElementVisibility(element, value);
}

function _getScrollLeft(element){
	return element.scrollLeft;
}
ASPxClientUtils.GetScrollLeft = function(element){
	return _getScrollLeft(element);
}

function _getScrollTop(element){
	return element.scrollTop;
}
ASPxClientUtils.GetScrollTop = function(element){
	return _getScrollTop(element);
}

function _setScrollLeft(element, value){
	element.scrollLeft = value;
}
ASPxClientUtils.SetScrollLeft = function(element, value){
	return _setScrollLeft(element, value);
}

function _setScrollTop(element, value){
	element.scrollTop = value;
}
ASPxClientUtils.SetScrollTop = function(element, value){
	return _setScrollTop(element, value);
}

function _getDocumentScrollLeft(){
	return _getScrollLeft(document.body);
}
ASPxClientUtils.GetDocumentScrollLeft = function(){
	return _getDocumentScrollLeft();
}

function _getDocumentScrollTop(){
	return _getScrollTop(document.body);
}
ASPxClientUtils.GetDocumentScrollTop = function(){
	return _getDocumentScrollTop();
}

function _getDocumentUrl(){
	return window.location.href;
}

function _getDocumentUrlWithQuery(query){
	var querySeparator = (_getDocumentUrl().indexOf("?") > -1) ? "&" : "?";
	return _getDocumentUrl() + querySeparator + query;
}

function _getCursor(element){
	if(!opera)
		return element.style.cursor;
	return "";
}

function _setCursor(element, cursor){
	if(!opera)
		element.style.cursor = cursor;
}

function _encodeParam(parameter) {
    return _isExists(encodeURIComponent) ? encodeURIComponent(parameter) : escape(parameter);
}

function _encodeColor(color){
	if(safari){
		switch(color){
			case "activeborder": 
				return "#D4D0C8";
			case "activecaption": 
				return "#0A246A";
			case "captiontext": 
				return "#FFFFFF";
			case "appworkspace": 
				return "#808080";
			case "buttonface": 
				return "#D4D0C8";
			case "buttonshadow": 
				return "#808080";
			case "threeddarkshadow": 
				return "#404040";
			case "buttonhighlight": 
				return "#FFFFFF";
			case "buttontext": 
				return "#000000";
			case "background": 
				return "#3A6EA5";
			case "graytext": 
				return "#808080";
			case "highlight": 
				return "#0A246A";
			case "highlighttext": 
				return "#FFFFFF";
			case "inactiveborder": 
				return "#D4D0C8";
			case "inactivecaption": 
				return "#808080";
			case "inactivecaptiontext": 
				return "#D4D0C8";
			case "infobackground": 
				return "#FFFFE1";
			case "infotext": 
				return "#000000";
			case "menu": 
				return "#D4D0C8";
			case "menutext": 
				return "#000000";
			case "scrollbar": 
				return "#D4D0C8";
			case "window": 
				return "#FFFFFF";
			case "windowframe": 
				return "#000000";
			case "windowtext": 
				return "#000000";
		}
	}
	return color;
}

function _getEvent(evt){
	if(ie) return event;
	else return evt;
}
ASPxClientUtils.GetEvent = function(evt){
	return _getEvent(evt);
}

function _getEventSource(evt){
	if(ie) return event.srcElement;
	else return evt.target;
}
ASPxClientUtils.GetEventSource = function(evt){
	return _getEventSource(evt);
}

function _getEventX(evt){
	return _getEvent(evt).clientX;
}

function _getEventY(evt){
	return _getEvent(evt).clientY;
}

function _getEventAbsoluteX(evt){
	return _getEventX(evt) + (!safari ? _getDocumentScrollLeft() : 0);
}

function _getEventAbsoluteY(evt){
	return _getEventY(evt) + (!safari ? _getDocumentScrollTop() : 0);
}

function _getMouseButton(evt){
	if(nsUpLevel) 
		return _getEvent(evt).which;
	else 
		return _getEvent(evt).button;
}

function _isLeftMouseButtonPressed(evt){
	if(opera)
		return true;
	else if(!ie) 
		return (_getMouseButton(evt) == leftBtnPressed || evt.type != "mousedown" && evt.type != "mouseup");
	else
		return ((_getMouseButton(evt) & leftBtnPressed) != 0);
}

function _isRightMouseButtonPressed(evt){
	if(opera)
		return false;
	else if(!ie) 
		return (_getMouseButton(evt) == rightBtnPressed);
	else
		return ((_getMouseButton(evt) & rightBtnPressed) != 0);
}

var hiddenInputCache = new Array();

function _getHiddenInput(inputName){
	var input = hiddenInputCache[inputName];
	if(!_isExists(input)){
		input = document.getElementById(inputName);
		hiddenInputCache[inputName] = input;
	}
	if(!_isExists(input)){
		input = document.createElement("INPUT");
		input.type = "hidden";
		input.id = inputName;
		input.name = inputName;
		var hostElement = _getServerForm();
		if(hostElement == null) 
			hostElement = document.body;
		hostElement.appendChild(input);
		hiddenInputCache[inputName] = input;
	}
	return input;
}

function _clearHiddenInputCache(){
	hiddenInputCache = new Array();
}

function _getValidInnerHTML(text){
	if(!ie){
		if(text == null || (_isString(text) && text == ""))
			text = "&nbsp;";
	}
	return text; 
}

function _getElementInnerText(element){
	if(!ie){
		if(element.innerHTML == "&nbsp;")
			return "";
		return element.innerHTML;
	}
	return element.innerText;
}

function _getTextNode(element){
	return element.firstChild;
}

function _setElementInnerHTML(element, text){
	element.innerHTML = _getValidInnerHTML(text);
}

function _setElementInnerText(element, text){
	if(!ie)
		element.innerHTML = _getValidInnerHTML(_replaceHTMLSpecSymbols(text));
	else {
		var textNode = _getTextNode(element);
		if(textNode != null)
			textNode.nodeValue = text;
		else
			element.appendChild(document.createTextNode(text));
	}
}

function _getAltKey(evt) { 
	if(ie) return (event != null) ? event.altKey : false;
	else return (evt != null) ? evt.altKey : false;
}

function _getCtrlKey(evt) { 
	if(ie) return (event != null) ? event.ctrlKey : false;
	else return (evt != null) ? evt.ctrlKey : false;
}

function _getShiftKey(evt) { 
	if(ie) return (event != null) ? event.shiftKey : false;
	else return (evt != null) ? evt.shiftKey : false;
}

function _getKeyCode(evt) { 
	if(ie) return event.keyCode;
	else return 0;
}

function _isTextChangingKey(key){
	switch(key){
		case kbShift: case kbCtrl: case kbAlt: case kbTab:
		case kbLeft: case kbRight: case kbUp: case kbDown:
		case kbPgUp: case kbPgDown:	case kbEnd: case kbHome:
		case kbEsc: case kbEnter:
		case kbF1: case kbF2: case kbF3: case kbF4: 
		case kbF5: case kbF6: case kbF7: case kbF8: 
		case kbF9: case kbF10: case kbF11: case kbF12:
			return false;
	}
	return true;
}

function _replace(str, exp, newExp){
	if(_isString(str) && str != "")
		str = str.replace(exp, newExp);
	return str;
}

function _replaceDblColon(str){
	return _replace(str, "::", ":");
}

function _replaceSpaces(str){
	return _replace(str, " ", "&nbsp;");
}

function _getPasswordText(text){
	var ret = "";
	if(text != null)
		for(var i = 0; i < text.length; i ++)
			ret += "*";
	return ret;
}

function _checkSpaces(str){
	for(var i = 0; i < str.length; i ++){
		if(str.charAt(i) != " ") return false;
	}
	return true;
}

function _replaceHTMLSpecSymbols(str){
	if(_isString(str) && str != ""){
		str = str.replace("&", "&amp;");
		str = str.replace("<", "&lt;");
		str = str.replace(">", "&gt;");
	}
	return str;
}

function _equal(value1, value2){
	if(_isDate(value1) && _isDate(value2)){
		value1 = value1.valueOf();
		value2 = value2.valueOf();
	}
	return value1 == value2;
}

function _compare(value1, value2){
	if(value1 == value2)
		return 0;
	if(value1 == null)
		return -1;
	if(value2 == null)
		return 1;

	if(_isDate(value1) && _isDate(value2)){
		value1 = value1.valueOf();
		value2 = value2.valueOf();
	}
	if(value1 < value2)
		return -1;
	return 1;
}

function _strIndexOf(str, subStr){
	if(_isString(str))
		return str.indexOf(subStr);
	return -1;
}

function _parseInt(value){
	return parseInt(value, 10);
}

var scrollBarWidth = -1;
function _getScrollBarWidth(){
	if(scrollBarWidth == -1){
		var div = document.createElement("div");
		div.style.overflow = "auto";
		div.style.height = 100;
		div.style.width = 100;
		div.style.visibility = "hidden";
		div.innerHTML = "<div style=\"height:400;width:400\"></div>";
		document.body.appendChild(div);
		scrollBarWidth = div.offsetWidth - div.clientWidth;
		if(mozilla && mozillaVersion < mozillaCorrectScrollBarVersion)
			scrollBarWidth += 15;
		document.body.removeChild(div);
	}
	return scrollBarWidth;
}

function ASPxUtilsMDown(evt){
	mouseButton = 1;
	if(_isExists(savedUtilsDocumentMouseDown))
		return savedUtilsDocumentMouseDown(evt);
	return true;
}

function ASPxUtilsMUp(evt){
	mouseButton = 0;
	if(_isExists(savedUtilsDocumentMouseUp))
		return savedUtilsDocumentMouseUp(evt);
	return true;
}

function OnDS(element){
	element.releaseCapture();
	return false;
}

function OnSS(e){
	var evt = _getEvent(e);
	evt.cancelBubble = true;
	return false;
}

var UtilsFirstLoad;
if(typeof(savedUtilsWindowOnLoad) == "undefined"){
	var scriptsLoaded = false;
	var savedUtilsWindowOnLoad = window.onload;
	UtilsFirstLoad = true;
}

window.onload = function(e){
	scriptsLoaded = true;
	if(UtilsFirstLoad){
		if(!ie){
			savedUtilsDocumentMouseUp = document.onmouseup;
			document.onmouseup = ASPxUtilsMUp;
			savedUtilsDocumentMouseDown = document.onmousedown;
			document.onmousedown = ASPxUtilsMDown;
		}
		UtilsFirstLoad = false;
	}
	ASPxClientUtils.kbShift = kbShift;
	ASPxClientUtils.kbCtrl = kbCtrl;
	ASPxClientUtils.kbAlt = kbAlt;
	ASPxClientUtils.kbBackSpace = kbBackSpace;
	ASPxClientUtils.kbTab = kbTab;
	ASPxClientUtils.kbEnter = kbEnter;
	ASPxClientUtils.kbEsc = kbEsc;
	ASPxClientUtils.kbSpace = kbSpace;
	ASPxClientUtils.kbPgUp = kbPgUp;
	ASPxClientUtils.kbPgDown = kbPgDown;
	ASPxClientUtils.kbEnd = kbEnd;
	ASPxClientUtils.kbHome = kbHome;
	ASPxClientUtils.kbLeft = kbLeft;
	ASPxClientUtils.kbUp = kbUp;
	ASPxClientUtils.kbRight = kbRight;
	ASPxClientUtils.kbDown = kbDown;
	ASPxClientUtils.kbInsert = kbInsert;
	ASPxClientUtils.kbDelete = kbDelete;
	ASPxClientUtils.kbPlus = kbPlus;
	ASPxClientUtils.kbMinus = kbMinus;
	ASPxClientUtils.kbF1 = kbF1;
	ASPxClientUtils.kbF2 = kbF2;
	ASPxClientUtils.kbF3 = kbF3;
	ASPxClientUtils.kbF4 = kbF4;
	ASPxClientUtils.kbF5 = kbF5;
	ASPxClientUtils.kbF6 = kbF6;
	ASPxClientUtils.kbF7 = kbF7;
	ASPxClientUtils.kbF8 = kbF8;
	ASPxClientUtils.kbF9 = kbF9;
	ASPxClientUtils.kbF10 = kbF10;
	ASPxClientUtils.kbF11 = kbF11;
	ASPxClientUtils.kbF12 = kbF12;

	if(_isExists(savedUtilsWindowOnLoad)) 
		savedUtilsWindowOnLoad(e);

}

function ASPxPostBack(){
	this.eventTarget = ""; 
	this.eventArgument = "";
	this.sender = null;
	this.isCallBack = false;
	this.xmlRequest = null;
	
	this.omitEvent = false;
	this.shiftPressed = false; 
	this.ctrlPressed = false; 
	this.altPressed = false; 
	
	this.initialized = false;
	this.preventReinitialize = false;
	this.sent = false;
	
	this.Initialize = function(evt, eventTarget, eventArgument, sender, isCallBack, preventReinitialize){
		if(this.preventReinitialize && this.initialized) return;
		
		this.shiftPressed = _getShiftKey(evt); 
		this.ctrlPressed = _getCtrlKey(evt); 
		this.altPressed = _getAltKey(evt); 
		
		this.eventTarget = eventTarget; 
		this.eventArgument = eventArgument;
		this.sender = sender;
		this.isCallBack = isCallBack;
		this.initialized = true;
		this.preventReinitialize = preventReinitialize;
	}
	this.Clear = function(){
		this.eventTarget = ""; 
		this.eventArgument = "";
		this.sender = null;
		this.initialized = false;
		this.preventReinitialize = false;
		
		this.omitEvent = false;
		this.shiftPressed = false; 
		this.ctrlPressed = false; 
		this.altPressed = false; 
	}

	this.GetCallBackData = function(){
		var ret = "";
		for (var i = 0; i < _getServerForm().elements.length; i++) {
			var element = _getServerForm().elements[i];
			switch(element.tagName.toUpperCase()){
				case "INPUT": {
					var type = element.type;
					if (type == "text" || type == "hidden" || type == "password")
						ret += element.name + "=" + _encodeParam(element.value) + "&";
					if((type == "checkbox" || type == "radio") && element.checked)
						ret += element.name + "=" + _encodeParam(element.value) + "&";
					break;
				}
				case "SELECT": {
					ret += element.name + "=" + _encodeParam(element.value) + "&";
					break;
				}
				case "TEXTAREA":{
					ret += element.name + "=" + _encodeParam(element.value) + "&";
					break;
				}
			}
		}
		ret += callBackIDParamName + "=" + _encodeParam(this.eventTarget) + "&";
		ret += callBackActionParamName + "=" + _encodeParam(this.eventArgument) + "&";
		return ret;
	}
	this.FillKeyState = function(){
		_getHiddenInput("__shiftPressed").value = this.shiftPressed;
		_getHiddenInput("__ctrlPressed").value = this.ctrlPressed;
		_getHiddenInput("__altPressed").value = this.altPressed;
	}
	this.FillOmitEvent = function(){
		if(this.omitEvent)
			_getHiddenInput("__omitEvent").value = this.omitEvent ? true : null;
	}
	this.FillFocusedControl = function(){
		if(this.sender != null && this.sender.CanFocusedControl())
			__setFocusedControl(this.sender);
	}
	
	this.Send = function(){
		if(this.sent || !this.initialized) return;
		
		this.FillKeyState();
		this.FillOmitEvent();
		this.FillFocusedControl();
		
		this.sent = true;
		if(this.isCallBack){
			this.xmlRequest = ie ? new ActiveXObject("Microsoft.XMLHTTP") : new XMLHttpRequest();
			var callBackData = this.GetCallBackData();
			var usePost = _getDocumentUrl().length + callBackData.length > 2048;
			if (usePost) {
				this.xmlRequest.open("POST", _getDocumentUrl(), false);
				this.xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
				this.xmlRequest.send(callBackData);
			}
			else {
				this.xmlRequest.open("GET", _getDocumentUrlWithQuery(callBackData), false);
				this.xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
				this.xmlRequest.send();
			}
			var callBackResponse = this.xmlRequest.responseText;
			if (callBackResponse.indexOf(callBackSuccessIdent) == 0)
				this.sender.OnCallBack(callBackResponse.substring(callBackSuccessIdent.length, callBackResponse.length));
			else 
				alert("A server error has occurred while a callBack has being processed on the server.");
			this.sent = false;
			this.xmlRequest = null;
			this.Clear();
		}
		else{
			if(_isFunction(__doPostBack))
				__doPostBack(this.eventTarget, this.eventArgument);
			this.Clear();
		}
	}
}

var __ASPxPostBack = new ASPxPostBack();

function __initASPxPostBack(evt, eventTarget, eventArgument, sender, isCallBack, preventReinitialize){
	__ASPxPostBack.Initialize(evt, eventTarget, eventArgument, sender, isCallBack, preventReinitialize);
}
function __sendASPxPostBack(omitEvent){
	__ASPxPostBack.omitEvent = omitEvent;
	window.setTimeout(__sendASPxPostBackTimerProc, 1);
}
function __sendASPxPostBackTimerProc(){
	__ASPxPostBack.Send();
}
function ASPxClientWebControl(name){
	this.name = name;
	this.initialized = false;
	this.initialization = false;
	this.displayed = false;
	this.GetName = function(){
		return this.name;
	}
	
	this.CheckInitialized = function(){
		if(!this.initialized && !this.initialization) 
			this.InitializeInternal(true, true);
	}
	this.CheckRenderInitialized = function(){
		if(this.initialized && !this.displayed && this.IsDisplayed()){
			this.InitializeControlRender();
			this.displayed = true;
		}
	}
	this.Initialize = function(){
		this.InitializeInternal(true, false);
	}
	this.InitializeInternal = function(checkInitialized, internalCall){
		if(!this.initialization && (!checkInitialized || !this.initialized)){
			this.initialization = true;
			this.InitializeControl();
			if(this.IsDisplayed()){
				this.InitializeControlRender();
				this.displayed = true;
			}
			this.initialization = false;
			this.initialized = true;
			this.OnInit();
		}
	}
	this.InitializeControl = function(){
	}
	this.InitializeControlRender = function(){
	}
	this.Finalize = function(){
	}
	
	this.IsDisplayed = function(){
		return false;
	}
	this.CheckPopupsInitialized = function(){
		if(_isFunctionType(typeof(GetLookAndFeelPopupCollection)))
			GetLookAndFeelPopupCollection().CheckInitialized();
	}
	this.CheckScrollBarsInitialized = function(){
		if(_isFunctionType(typeof(GetLookAndFeelScrollBarCollection)))
			GetLookAndFeelScrollBarCollection().CheckInitialized();
	}
	this.OnInit = function(){
	}
	
	this.InitPostBack = function(evt, eventArgument){
		__initASPxPostBack(evt, this.name, eventArgument, this, false, false);
	}	
	this.AfterPostBack = function(){
	}
	this.BeforePostBack = function(){
	}
	this.SendPostBack = function(omitEvent){
		__sendASPxPostBack(omitEvent);
	}
	
	this.ApplyCallBackHtml = function(html){
	}
	
	this.OnCallBack = function(callBackResult){
		_clearHiddenInputCache();
		var listeners = callBackResult.split(callBackResultListenerMark);
		var createScriptBlock = "";
		for(var i = 0; i < listeners.length; i ++){
			var listenerBlocks = listeners[i].split(callBackResultListenerBlockMark);
			if(listenerBlocks.length == 3){
				var webControl = GetWebControlCollection().Get(listenerBlocks[0]);
				if(webControl != null){
					webControl.ApplyCallBackHtml(listenerBlocks[1]);
					webControl.AfterPostBack();
					createScriptBlock += listenerBlocks[2];
				}
			}
		}
		if(createScriptBlock != "")
			eval(createScriptBlock);
		GetWebControlCollection().CheckInitialized();
	}
	
	GetWebControlCollection().Add(this);
}
ASPxClientWebControl.GetWebControlCollection = function(){
	return GetWebControlCollection();
}

function GetWebControlCollection(){
	if(__ASPxWebControlCollection == null){
		__ASPxWebControlCollection = new ASPxClientWebCollection();
	}
	return __ASPxWebControlCollection;
}

if(typeof(savedWebControlWindowOnLoad) == "undefined"){
	var __ASPxWebControlCollection = null;
	var savedWebControlWindowOnLoad = window.onload;
}
	
window.onload = function(e){
	if(_isExists(savedWebControlWindowOnLoad)) 
		return savedWebControlWindowOnLoad();
	return true;
}