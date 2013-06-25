var pressedLFScrollBoxRootElement = null;
var pressedLFScrollBoxRootCanScroll = false;
var pressedLFScrollBoxTimerID = -1;
var pressedLFScrollBoxScrollingDelta = 0;

function InitializeLFScrollBoxSize(element, width, height){
	var LFScrollBarElement = _getChildByCssClass(element, "LFScrollBar");
	if(LFScrollBarElement != null && height != null){
		var style = ASPxStyle.GetStyleByElement(element);
		var clientHeight = style.GetClientHeight(height);
		_setElementHeight(_getParentNode(LFScrollBarElement), clientHeight.ToString());
	}
}

function SetLFScrollBoxTimer(){
	pressedLFScrollBoxTimerID = window.setTimeout(OnLFSBxTimer, 1);
}

function ClearLFScrollBoxTimer(){
	window.clearTimeout(pressedLFScrollBoxTimerID);
	pressedLFScrollBoxTimerID = -1;
}

function OnLFSBxTimer(){
	if(pressedLFScrollBoxRootElement != null && pressedLFScrollBoxScrollingDelta != null){
		if(!_isExists(pressedLFScrollBoxRootElement.scrollBarElement))
			pressedLFScrollBoxRootElement.scrollBarElement = _getChildByCssClass(pressedLFScrollBoxRootElement.rows[0].cells[1], "LFScrollBar");
		if(_isExists(pressedLFScrollBoxRootElement.scrollBarElement)){
			var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(pressedLFScrollBoxRootElement.scrollBarElement.id);
			if(LFScrollBar != null){
				LFScrollBar.ChangePositionBy(pressedLFScrollBoxScrollingDelta / 2);
				SetLFScrollBoxTimer();
			}
		}
	}
}

function OnLFSBxMouseDown(e){
	var element = _getEventSource(e);
	pressedLFScrollBoxRootElement = _getParentByCssClass(element, "LFScrollBox");
	if(pressedLFScrollBoxRootElement == null){
		var LFPopupElement = _getParentByCssClass(element, "LFPopup");
		if(LFPopupElement != null){
			var LFPopup = GetLookAndFeelPopupCollection().Get(LFPopupElement.id);
			var popupContainerElement = (LFPopup != null) ? LFPopup.GetContainerElement() : null;
			if(popupContainerElement != null)
				pressedLFScrollBoxRootElement = _getChildByCssClass(popupContainerElement, "LFScrollBox");
		}
	}
}

function OnLFSBxMouseUp(e){
	if(pressedLFScrollBoxRootElement != null){
		pressedLFScrollBoxRootElement = null;
		pressedLFScrollBoxScrollingDelta = 0;
		ClearLFScrollBoxTimer();
		pressedLFScrollBoxRootCanScroll = false;
	}
}

function OnLFSBxMouseMove(e){
	if(e.button == 0)
		OnLFSBxMouseUp(e);
	else if(pressedLFScrollBoxRootElement != null){
		if(!pressedLFScrollBoxRootCanScroll)
			pressedLFScrollBoxRootCanScroll = _getIsParent(pressedLFScrollBoxRootElement, _getEventSource(e));
		if(pressedLFScrollBoxRootCanScroll){
			ClearLFScrollBoxTimer();
			var topBorder = _absoluteY(pressedLFScrollBoxRootElement, "", false, false, true, true) - _getDocumentScrollTop() + 5;
			var bottomBorder = topBorder + _getElementHeight(pressedLFScrollBoxRootElement) - 5;
			if(e.y < topBorder)
				pressedLFScrollBoxScrollingDelta = e.y - topBorder;
			else if(e.y > bottomBorder)
				pressedLFScrollBoxScrollingDelta = e.y - bottomBorder;
			else
				pressedLFScrollBoxScrollingDelta = 0;
			if(pressedLFScrollBoxScrollingDelta != 0)
				SetLFScrollBoxTimer();
		}
	}
}

function LFSBxDocumentOnMouseDown(e){
	OnLFSBxMouseDown(e);
	if(_isExists(savedLFSBxDocumentOnMouseDown)) 
		return savedLFSBxDocumentOnMouseDown(e);
	return true;
}

function LFSBxDocumentOnMouseMove(e){
	if(pressedLFScrollBoxRootElement != null)
		OnLFSBxMouseMove(_getEvent(e));
	if(_isExists(savedLFSBxDocumentOnMouseMove)) 
		return savedLFSBxDocumentOnMouseMove(e);
	return true;
}

function LFSBxDocumentOnMouseUp(e){
	OnLFSBxMouseUp(e);
	if(_isExists(savedLFSBxDocumentOnMouseUp)) 
		return savedLFSBxDocumentOnMouseUp(e);
	return true;
}

var LFSBxFirstLoad;
if(typeof(savedLFSBxWindowOnLoad) == "undefined"){
	var savedLFSBxWindowOnLoad = window.onload;
	var savedLFSBxDocumentOnMouseDown = null;
	var savedLFSBxDocumentOnMouseUp = null;
	var savedLFSBxDocumentOnMouseMove = null;
	LFSBxFirstLoad = true;
}

window.onload = function(){
	if(LFSBxFirstLoad){
		savedLFSBxDocumentOnMouseDown = window.document.onmousedown;
		window.document.onmousedown = LFSBxDocumentOnMouseDown;
		savedLFSBxDocumentOnMouseUp = window.document.onmouseup;
		window.document.onmouseup = LFSBxDocumentOnMouseUp;
		savedLFSBxDocumentOnMouseMove = window.document.onmousemove;
		window.document.onmousemove = LFSBxDocumentOnMouseMove;
		LFSBxFirstLoad = false;
	}

	if(_isExists(savedLFSBxWindowOnLoad)) 
		return savedLFSBxWindowOnLoad();
	return true;
}