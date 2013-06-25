var argsDlmtr = "#";
var idDlmtr = "~";

var columnSizingEdge = 5;
var draggingHeaderElement = null;
var draggingMarkArrowUp = null;
var draggingMarkArrowDown = null;
var columnResizeMark = null;

function clearColumnSizingState(){
	curGridName = "";
	curSizing = false;
	curSzLn = null;
	curX = 0;
	curRszHdr = null;
	curColInd = -1;
	curDragAct = 0;		
}

function clearResizingCursor(){
	curRszCrsrHdr = null;
	curRszCrsr = "";
}

function clearDragState(){
	curGridName = "";	
	curDragEl = null;
	curColInd = -1;
	curDragAct = 0;
	curX = 0;
	curY = 0;		
	curTargetHdr = null;
	curArrUp = null;
	curArrDown = null; 
	curArrUpX = -1;
	curArrUpY = -1;
	curArrDownX = -1;
	curArrDownY = -1;
}

function initializeEnableFlags(){
	curEnblHdrClick = false;
	curEnblHdrDrag = false;
	curEnblGroup = false;
	curLastUngrCol = false;
	curEnblClmnMove = false;
	curEnblClmnSize = false;
	curShowArr = false;
}

function getElementMark(mark){
	return idDlmtr + mark + idDlmtr;
}

function getColumnHeaderMark(){
	return getElementMark("CH");
}

function getGroupedHeaderMark(){
	return getElementMark("GH");
}

function getDraggingHeaderMark(){
	return getElementMark("DH");
}

function getGroupButtonMark(){
	return getElementMark("GB");
}

function getUngroupButtonMark(){
	return getElementMark("UB");
}

function getDataRowMark(){
	return getElementMark("DR");
}

function getExpandedRowMark(){
	return getElementMark("ER");
}

function getCollapsedRowMark(){
	return getElementMark("CR");
}

function getExpandButtonMark(){
	return getElementMark("EB");
}

function getSearchButtonMark(){
	return getElementMark("SB");
}

function getSearchEditorMark(){
	return getElementMark("SE");
}

function getPreviewRowMark(){
	return idDlmtr + "preview";
}

function getSpaceRowMark(){
	return idDlmtr + "space";
}

function getDraggingHeaderElement(){
	if(draggingHeaderElement == null){
		draggingHeaderElement = document.createElement("DIV");
		document.body.appendChild(draggingHeaderElement);
	}
	return draggingHeaderElement;
}

function getDraggingMarkArrowUp(gridName){
	if(draggingMarkArrowUp == null){
		draggingMarkArrowUp = _getElementById(gridName + "arrowup");		
		document.body.appendChild(draggingMarkArrowUp);
	}
	return draggingMarkArrowUp;
}

function getDraggingMarkArrowDown(gridName){
	if(draggingMarkArrowDown == null){
		draggingMarkArrowDown = _getElementById(gridName + "arrowdown");		
		document.body.appendChild(draggingMarkArrowDown);
	}
	return draggingMarkArrowDown;
}

function getColumnResizeMark(gridName){
	if(columnResizeMark == null){
		columnResizeMark = _getElementById(gridName + "sizerline");		
		document.body.appendChild(columnResizeMark);
	}
	return columnResizeMark;
}

function getDragHeaderLeft(header, gridName, isGrouped, borderCollapse){
	var absX = _absoluteX(header, gridName, false, false, false, true);
	if(!ie) return absX + (mozilla ? (isGrouped || borderCollapse ? 0 : 1) : 0);
	else return absX + (isGrouped && borderCollapse ? 0 : 0);
}

function getDragHeaderTop(header, gridName, isGrouped, borderCollapse){
	var absY = _absoluteY(header, gridName, false, false, false, true);
	if(!ie) return absY + (mozilla ? (isGrouped || borderCollapse ? 0 : 1) : 0);
	else return absY + (isGrouped && borderCollapse ? 0 : 0);
}

function getDragHeaderWidth(header, isGrouped, borderCollapse){
	if(!ie) return _getElementWidth(header) - (mozilla ? (isGrouped ? 1 : (borderCollapse ? 1 : 2)) : 2);
	else return _getElementWidth(header) - (isGrouped ? 0 : (borderCollapse ? 1 : 2));
}

function getDragHeaderHeight(header, isGrouped, borderCollapse){
	if(!ie) return _getElementHeight(header) - (mozilla ? (isGrouped ? 1 : (borderCollapse ? 1 : 2)) : 2);
	else return _getElementHeight(header) - (isGrouped ? 0 : (borderCollapse ? 1 : 2));
}


function showDragHeader(header, drgHdr, isGrouped, gridName, borderCollapse){
	_setElementVisibility(drgHdr, true);
	_setElementLeft(drgHdr, getDragHeaderLeft(header, gridName, isGrouped, borderCollapse));
	_setElementTop(drgHdr, getDragHeaderTop(header, gridName, isGrouped, borderCollapse));
	var align = header.align;
	_setElementWidth(drgHdr, getDragHeaderWidth(header, isGrouped, borderCollapse)); 
	_setElementHeight(drgHdr, getDragHeaderHeight(header, isGrouped, borderCollapse)); 
}

function getHeaderDraggedStyle(gridObj, columnIndex, isGrouped){
	var registerId = gridObj.name + "DH" + columnIndex;
	var headerDraggedStyle = GetLookAndFeelStyleCollection().Get(GetStyleName(registerId));
	if(headerDraggedStyle == null){
		var btnStyle = ASPxStyle.CreateStyle();
		btnStyle.MergeStyle(gridObj.headerStyle);
		if(isGrouped)
			btnStyle.MergeStyle(gridObj.groupedHeaderStyle);
		btnStyle.MergeStyle(gridObj.columns[columnIndex].headerStyle);
		if(isGrouped)
			btnStyle.MergeStyle(gridObj.columns[columnIndex].groupedHeaderStyle);
		btnStyle.MergeStyle(gridObj.headerDraggedStyle);
		headerDraggedStyle = new ASPxLookAndFeelStyle(GetStyleName(registerId));	
		headerDraggedStyle.MergeStyle(GetLookAndFeelStyleCollection().GetDraggedElementStyle("", gridObj.lookAndFeel));
		headerDraggedStyle.MergeStyle(GetLookAndFeelStyleCollection().GetButtonStyle(GetStyleName(gridObj.name + "Btn"), gridObj.lookAndFeel));		
		headerDraggedStyle.MergeStyle(btnStyle);		
		ASPxStyle.RemoveStyle(btnStyle);
	}
	return headerDraggedStyle;
}

function startDragHeader(evt, gridName, header, hdrInd, isGrouped, borderCollapse){
	while(header != null && (header.tagName != "TD" || header.id == "")){
		header = _getParentNode(header);
	}		
	if(header != null){
		var drgHdr = getDraggingHeaderElement();			
		drgHdr.style.position = "absolute";
		drgHdr.style.zIndex = dragHdrZIndex;
		drgHdr.onselectstart = new Function("event", "return OnSS(event);");
		drgHdr.onmouseout = OnDHMOut;
		_setElementVisibility(drgHdr, false);
		var gridObj = GetGridCollection().Get(gridName);
		var headerDraggedStyle = getHeaderDraggedStyle(gridObj, hdrInd, isGrouped);
		if(_getChildNodes(header).length == 1 && _strIndexOf(_getFirstChild(header).id, "LFBtn") >= 0){
			var childNode = _getFirstChild(header).cloneNode(true);
			childNode.onmouseover = null;
			childNode.onmouseout = null;
			childNode.onmousedown = null;
			if(headerDraggedStyle != null){
				headerDraggedStyle.ApplyStyle(childNode, false);				
				headerDraggedStyle.ApplyFontAttributesToTables(childNode, false, false);
				childNode.className = headerDraggedStyle.cssClass;
			}
			drgHdr.appendChild(childNode);		
		}
		else{		
			headerDraggedStyle.ApplyStyle(drgHdr, false);
			for(var i = 0; i < _getChildNodes(header).length; i ++){
				var childNode = _getChildNode(header, i).cloneNode(true);
				if(childNode.style != null && headerDraggedStyle != null)
					headerDraggedStyle.ApplyFontAttributes(childNode, false);
				drgHdr.appendChild(childNode);		
			}
		}
		showDragHeader(getHeaderElement(header), drgHdr, isGrouped, gridName, borderCollapse);	
		curGridName = gridName;
		curColInd = hdrInd;
		curX = _getEventAbsoluteX(evt);
		curY = _getEventAbsoluteY(evt);
		curDragEl = drgHdr;
		curDragAct = isGrouped ? 10001 : 10000;				
		curArrUp = getDraggingMarkArrowUp(gridName);
		curArrDown = getDraggingMarkArrowDown(gridName);
	}		
}

function endColumnDragging(){
	if(curShowArr)
		hideArrows();
	_setElementVisibility(curDragEl, false);
	_setElementLeft(curDragEl, 0);
	_setElementTop(curDragEl, 0);
	_clearElementChildren(curDragEl);
	clearDragState();
}

function isRtl(){
	return document.body.dir != null && document.body.dir.toLowerCase() == "rtl";
}

function getResizingCursorPosition(evt){
	return _getEventAbsoluteX(evt) - (ie && isRtl() ? _getScrollBarWidth() + document.body.scrollWidth - document.body.clientWidth : 0);
}

function startColumnSizing(evt, gridName, gridObj, header){
	curSzLn = getColumnResizeMark(gridName);
	if(curSzLn != null){
		curGridName = gridName;		
		curDragAct = 10000;		
		curX = getResizingCursorPosition(evt) - _absoluteX(curSzLn.offsetParent, gridName, false, false, false, true);
		_setCursor(curSzLn, "e-resize");
		_setElementVisibility(curSzLn, true);
		_setElementLeft(curSzLn, curX);
		_setElementTop(curSzLn, _absoluteY(header, gridName, false, false, false, true));
		_setElementWidth(curSzLn, 1); 
		var scroller = gridObj.htmlRender.GetHtmlScroller();
		if(scroller != null)
			_setElementHeight(curSzLn, _getElementHeight(scroller)); 
		else
			_setElementHeight(curSzLn, gridObj.htmlRender.GetItemsHeight(_getParentNode(_getParentNode(header)))); 
		hotTrackEnabled = false;
	}
}

function endColumnSizing(){
	_setCursor(curSzLn, "default");
	_setElementVisibility(curSzLn, false);
	_setElementLeft(curSzLn, 0);
	_setElementTop(curSzLn, 0);
	clearColumnSizingState();
	hotTrackEnabled = true;
}

function showResizingCursor(hdr){
	if(curRszCrsrHdr == null || curRszCrsrHdr != hdr){
		if(curRszCrsrHdr != null)
			hideResizingCursor();
		curRszCrsrHdr = hdr;
		curRszCrsr = _getCursor(hdr);
		_setCursor(hdr, "e-resize");
	}
}

function hideResizingCursor(){
	if(curRszCrsrHdr != null){
		_setCursor(curRszCrsrHdr, curRszCrsr);
	}
	clearResizingCursor();
}

function getCell(evt){
	var td = _getEventSource(evt);
	var tr = _getParentNode(td);
	while(td != null && tr != null && 
		_strIndexOf(tr.id, getDataRowMark()) == -1 &&
		_strIndexOf(tr.id, getExpandedRowMark()) == -1 && 
		_strIndexOf(tr.id, getCollapsedRowMark()) == -1){
		td = tr;
		tr = _getParentNode(td);
	}
	return td;
}

function getHeader(evt){
	var header = _getEventSource(evt);
	while(header != null && (header.tagName != "TD" || header.id == "")){
		header = _getParentNode(header);
	}
	return header;
}

function isGroupHeader(header){
	return header.id.indexOf(getGroupedHeaderMark()) >= 0;
}

function updateArrowsPos(arrowImgWidth){
	if(curTargetHdr != null){
        curArrUpX = curTargetHdr.x - arrowImgWidth / 2;        
        curArrUpY = curTargetHdr.y + curTargetHdr.height;
        curArrDownX = curTargetHdr.x - arrowImgWidth / 2;
        curArrDownY = curTargetHdr.y - arrowImgWidth;
	}
}

function showArrows(){
    _setElementLeft(curArrUp, curArrUpX);    
    _setElementTop(curArrUp, curArrUpY);
    _setElementLeft(curArrDown, curArrDownX);
    _setElementTop(curArrDown, curArrDownY);

    _setElementVisibility(curArrUp, true);
    _setElementVisibility(curArrDown, true);
}

function hideArrows(){
	if(curArrUp != null)
		_setElementVisibility(curArrUp, false);
	if(curArrDown)
		_setElementVisibility(curArrDown, false);
}

function getButton(evt){
	var button = _getEventSource(evt);
	while(button != null && _getParentNode(button) != null && (button.tagName != "TD" || _getParentNode(button).id == ""))
		button = _getParentNode(button);
	return button;
}

function getSrchButton(evt){
	var button = _getEventSource(evt);
	while(button != null && (button.tagName != "TD" || button.id == ""))
		button = _getParentNode(button);
	return button;
}

function getBtnGridName(button){
	var _indexOf = button.id.indexOf(idDlmtr);
	if(_indexOf != -1)
		return button.id.substr(0, _indexOf);			
	return "";
}

function getBtnGridObject(button){
	if(button != null)
		return GetGridCollection().Get(getBtnGridName(button));
	return null;
}

function getElementRowId(element){
	var str = element.id.substr(element.id.indexOf(idDlmtr) + idDlmtr.length, element.id.length);
	if(str.indexOf(idDlmtr) >= 0)
		return str.substr(str.indexOf(idDlmtr) + idDlmtr.length, str.length);
	else
		return "-1" + idDlmtr + "-1";
}

function getRowBtnRowId(element){
	if(element.id.index)
	return element.id.substr(element.id.indexOf(idDlmtr) + getDataRowMark().length, element.id.length);
}

function moveSizerLine(curSzLn, distanceX){
	if(!ie)
		curSzLn.style.left = _getElementLeft(curSzLn) + distanceX;
	else
		curSzLn.style.pixelLeft += distanceX;
}

function getHeaderElement(header){
	return (_getChildNodes(header).length == 1) && (_strIndexOf(_getFirstChild(header).id, "LFBtn") >= 0) ? _getFirstChild(header) : header;
}

function OnHMMove(evt){	
	evt = _getEvent(evt);
	if(curSzLn == null && curDragEl == null){
		var header = _getEventSource(evt);
		while(_isExists(header) && (header.tagName != "TD" || header.id == "" || header.id.indexOf(getColumnHeaderMark()) == -1 && !isGroupHeader(header) && header.id.indexOf(getDraggingHeaderMark()) == -1)){
			header = _getParentNode(header);
		}			
		if(_isExists(header)){
			var _indexOf = header.id.indexOf(idDlmtr);
			if(_indexOf != -1){
				var gridName = header.id.substr(0, _indexOf);		
				var gridObj = GetGridCollection().Get(gridName);
				if(gridObj != null){					
					var hdrInd = header.id.substr(_indexOf + (getColumnHeaderMark()).length, header.id.length);
					if(!isGroupHeader(header)){						
						var xPos = getResizingCursorPosition(evt);
						curRszHdr = gridObj.htmlRender.GetResizingHeaderInfo(header, hdrInd, xPos);
						if(curRszHdr != null){
							showResizingCursor(_getEventSource(evt));
							curSizing = true;
						}
						else{
							hideResizingCursor();
							curSizing = false;
						}
					}
				}
			}			
		}
	}
}

function OnGBCl(evt){			
	evt = _getEvent(evt);
	var header = getHeader(evt);
	if(header != null){
		var _indexOf = header.id.indexOf(idDlmtr);
		if(_indexOf != -1){
			var gridName = header.id.substr(0, _indexOf);		
			var hdrInd = header.id.substr(_indexOf + (getGroupButtonMark()).length, header.id.length);
			var gridObj = GetGridCollection().Get(gridName);
			if(gridObj != null){				
				gridObj.OnGroupingButtonClickCore(evt, header.id.indexOf(getGroupButtonMark()) != -1 ? "Group" : "Ungroup", hdrInd);
			}
		}
	}
}

function OnHMDown(evt){
	evt = _getEvent(evt);
	if(_isLeftMouseButtonPressed(evt)){
		var header = getHeader(evt);
		if(header != null && (header.id.indexOf(getColumnHeaderMark()) != -1 || isGroupHeader(header))){
			var _indexOf = header.id.indexOf(idDlmtr);
			if(_indexOf != -1){
				var gridName = header.id.substr(0, _indexOf);		
				var hdrInd = header.id.substr(_indexOf + (getColumnHeaderMark()).length, header.id.length);
				var gridObj = GetGridCollection().Get(gridName);
				if(gridObj != null){
					if(curSizing && !isGroupHeader(header)){
						startColumnSizing(evt, gridName, gridObj, header);
						return false;
					}
					else{					
						initializeEnableFlags();										
						var column = gridObj.columns[hdrInd];
						if(column != null){
							curEnblHdrClick = column.enableHeaderClick;
							curEnblHdrDrag = column.enableHeaderDragging;
							curEnblGroup = column.enableGrouping;
							curLastUngrCol = column.IsLastUngroupedColumn();
							curEnblClmnMove = column.enableColumnMoving;							
							curEnblClmnSize = column.enableColumnSizing;
						}
						curShowArr = gridObj.showArrowsOnDragging;
						if(curEnblHdrClick || curEnblHdrDrag){
							startDragHeader(evt, gridName, header, hdrInd, isGroupHeader(header), gridObj.htmlRender.borderCollapse);
							evt.cancelBubble = true;						
							return false;
						}
					}	
				}		
			}
		}
	}
}

function isGroupButton(element){
	var parentNode = _getParentNode(element);
	return element != null && element.id != null && (element.id.indexOf(getGroupButtonMark()) >= 0 || element.id.indexOf(getUngroupButtonMark()) >= 0) || parentNode != null && parentNode.id != null && (parentNode.id.indexOf(getGroupButtonMark()) >= 0 || parentNode.id.indexOf(getUngroupButtonMark()) >= 0);
}

function OnDHMOut(evt){	
	evt = _getEvent(evt);
	if(curDragEl != null && !curEnblHdrDrag)
		endColumnDragging();
}

function moveHeaderElement(headerElement, distanceX, distanceY){
	if(!ie){
		headerElement.style.left = _getElementLeft(headerElement) + distanceX;
		headerElement.style.top = _getElementTop(headerElement) + distanceY;    			
	}
	else{
		headerElement.style.pixelLeft += distanceX;
		headerElement.style.pixelTop += distanceY;    		
	}
}

function OnDMMove(evt){			
	evt = _getEvent(evt);	
	if(curDragEl != null){	
		if(_isLeftMouseButtonPressed(evt)){
			var header = curDragEl;				
			var newX = _getEventAbsoluteX(evt);
			var newY = _getEventAbsoluteY(evt);
			var distX = newX - curX;
			var distY = newY - curY;
			var threshold = (curDragAct == 2 || curDragAct == 3 ? 0 : 4);
			
			if(Math.abs(distX) > threshold || Math.abs(distY) > threshold){
				if(curEnblHdrDrag){
					if(curDragAct == 10000)
						curDragAct = 2;
					if(curDragAct == 10001)
						curDragAct = 3;
					newX = _getEventAbsoluteX(evt);
					newY = _getEventAbsoluteY(evt);
					moveHeaderElement(header, distX, distY);
					curX = newX;
					curY = newY;
					var gridObj = __ASPxGridCollection.Get(curGridName);
					curTargetHdr = null;
					if(gridObj != null && curDragAct == 2 && curEnblClmnMove || curDragAct == 3 && curEnblGroup)
						curTargetHdr = gridObj.htmlRender.GetTargetHeaderInfo(newX, newY, curColInd);
					if(curTargetHdr == null && curEnblGroup && !curLastUngrCol && gridObj != null)
						curTargetHdr = gridObj.htmlRender.GetTargetGroupedHeaderInfo(newX, newY, curColInd);
					if(curShowArr){				
						updateArrowsPos(gridObj.arrowImgWidth);				
						if(curTargetHdr == null)
							hideArrows();
						else
							showArrows();				
					}
				}
				else{
					endColumnDragging();
				}		
			}			
		}
		else{
			endColumnDragging();
		}
		evt.cancelBubble = true;
		return false;
	}
	else if(curSzLn != null){
		if(_isLeftMouseButtonPressed(evt)){
			newX = getResizingCursorPosition(evt) - _absoluteX(curSzLn.offsetParent, curGridName, false, false, false, true) - (!safari ? 2 : -6);
			if(newX < curRszHdr.x + curRszHdr.minWidth)
				newX = curRszHdr.x + curRszHdr.minWidth;
			distanceX = (newX - curX);
			if(distanceX != 0){				
				curX = newX;
				moveSizerLine(curSzLn, distanceX);
				curDragAct = 4;
			}
		}
		else{
			endColumnSizing();
		}
		evt.cancelBubble = true;
		return false;
	}
	else{
		if(_isExists(savedGridDocumentMouseMove))
			return savedGridDocumentMouseMove(evt);
	}
	return true;
}

function OnDMUp(evt){			
	evt = _getEvent(evt);	
	var evtSrc = _getEventSource(evt);		
	if(curDragEl != null){
		if(isGroupButton(evtSrc))
			OnGBCl(evt);
		else{				
			var gridObj = __ASPxGridCollection.Get(curGridName);
			if(curDragAct == 2 || curDragAct == 3){			
				if(curShowArr)
					hideArrows();		
				if(curTargetHdr != null){						
					gridObj.OnHeaderDragEndCore(evt, curTargetHdr.inGroupingPanel ? "Group" : (curDragAct == 3 ? "Ungroup" : "Move"), curColInd, curTargetHdr.targetIndex);
				}
			}
			else{
				if(curEnblHdrClick)
					gridObj.OnHeaderClickCore(evt, "Sort", curColInd);
			}		
			endColumnDragging();
		}
	}
	if(curSzLn != null){	
		if(curDragAct == 4){
			var curGridObject = GetGridCollection().Get(curGridName);
			if(curGridObject != null)
				curGridObject.ResizeColumnCore(evt, "HR", curRszHdr.columnIndex, (curX - curRszHdr.x));
		}
		endColumnSizing();
	}
	if(_isExists(savedGridDocumentMouseUp))
		return savedGridDocumentMouseUp(evt);
	return true;
}

function OnDMOver(evt){
	if(curSzLn != null)
		return false;
	if(_isExists(savedGridDocumentMouseOver))
		return savedGridDocumentMouseOver(evt);
	return true;
}


function OnEBCl(evt){
	evt = _getEvent(evt);
	evt.cancelBubble = true;	
	var button = getButton(evt);
	var gridObj = getBtnGridObject(button);
	if(gridObj != null)
		gridObj.OnExpandButtonClickCore(evt, "Expand", getElementRowId(button), button);
	return false;
}

function OnRBCl(evt, action){
	evt = _getEvent(evt);
	evt.cancelBubble = true;	
	var button = getButton(evt);
	var gridObj = getBtnGridObject(_getParentNode(button));
	if(gridObj != null)
		gridObj.OnRowButtonClickCore(evt, action, getElementRowId(_getParentNode(button)));
}

function OnRBMoveToCl(evt){
	evt = _getEvent(evt);		
	evt.cancelBubble = true;	
	var button = getButton(evt);	
	if(button != null){
		var gridName = getBtnGridName(_getParentNode(button));
		var gridObj = GetGridCollection().Get(gridName);
		if(gridObj != null){
			var rowId = getElementRowId(_getParentNode(button));
			var tr = gridObj.GetChildById(gridName + getDataRowMark() + rowId);						
			if(tr == null)
				tr = gridObj.GetChildById(gridName + getExpandedRowMark() + rowId);				
			if(tr == null)
				tr = gridObj.GetChildById(gridName + getCollapsedRowMark() + rowId);
			if(tr != null && !(gridObj.GetDataMode() != "Browse" && gridObj.IsFocusedRowCore(tr, rowId)))
				gridObj.MoveToCore(evt, "RB", tr, rowId, "-1");
		}
	}
}

function rowDblClick(evt, evtSrcType, gridObj, tr, td){
	var isGroupRow = tr.id.indexOf(getDataRowMark()) == -1;									
	gridObj.OnRowDblClickCore(evt, evtSrcType, isGroupRow ? "Expand" : "Edit", getElementRowId(tr), isGroupRow ? "-1" : td.id, isGroupRow ? tr.cells[gridObj.GetRowLevel(tr) + gridObj.firstGroupIndentOffset] : td);
}

function OnTRCl(evt){
	evt = _getEvent(evt);
	var td = getCell(evt);
	var tr = _getParentNode(td);
	if(td != null && tr != null){
		var _indexOf = tr.id.indexOf(getPreviewRowMark());	
		var previewClicked = false; 
		if(_indexOf != -1){
			tr = _getElementById(tr.id.substr(0, _indexOf));		
			previewClicked = true;
		}
		_indexOf = tr.id.indexOf(idDlmtr);
		if(_indexOf != -1){
			var gridName = tr.id.substr(0, _indexOf);		
			var gridObj = GetGridCollection().Get(gridName);		
			if(gridObj != null){
				var rowId = getElementRowId(tr);
				var isFocusedRow = gridObj.IsFocusedRowCore(tr, rowId);
				var isSelectedRow = gridObj.IsSelectedRowCore(tr);
				var isFocusedColumn = td.id == array_indexOf(gridObj.internalColumns, gridObj.columns[gridObj.focusedColumnIndex]);
				if(gridObj.GetDataMode() == "Browse" || !isFocusedRow || !isFocusedColumn){
					var isDblClick = gridObj.enableFocusedRowClick && isFocusedRow && (!gridObj.multiSelection || !_getCtrlKey(evt) && isSelectedRow) && (!gridObj.cellSelection || gridObj.focusedColumnIndex == -1 || isFocusedColumn) && !previewClicked;
					if(gridObj.GetDataMode() != "Browse" || !isDblClick){
						gridObj.OnRowClickCore(evt, "Moveto", tr, rowId, td.id);
					}	
					else{
						rowDblClick(evt, "RF", gridObj, tr, td);
					}									
				}			
			}
		}
	}
}

function OnTRDblCl(evt){
	evt = _getEvent(evt);
	var td = getCell(evt);
	var tr = _getParentNode(td);
	if(td != null && tr != null){
		var _indexOf = tr.id.indexOf(getPreviewRowMark());	
		if(_indexOf == -1){
			_indexOf = tr.id.indexOf(idDlmtr);
			if(_indexOf != -1){
				var gridName = tr.id.substr(0, _indexOf);		
				var gridObj = GetGridCollection().Get(gridName);		
				if(gridObj != null && gridObj.enableRowDblClick){
					var rowId = getElementRowId(tr);
					var isFocusedRow = gridObj.IsFocusedRowCore(tr, rowId);
					var isFocusedColumn = td.id == array_indexOf(gridObj.internalColumns, gridObj.columns[gridObj.focusedColumnIndex]);
					if(gridObj.GetDataMode() == "Browse" || !isFocusedRow || !isFocusedColumn)
						rowDblClick(evt, "RD", gridObj, tr, td);
				}
			}
		}
	}
}

function OnTRSS(evt){
	return OnSS(evt);
}

function OnSBCl(evt){
	evt = _getEvent(evt);
	evt.cancelBubble = true;	
	var button = getSrchButton(evt);
	var gridName = getBtnGridName(button);
	var columnIndex = getElementRowId(button);
	var edit = _getElementById(gridName + getSearchEditorMark() + columnIndex);
	if(edit != null){
		var gridObj = GetGridCollection().Get(gridName);
		if(gridObj != null)
			if(!gridObj.OnSearchButtonClickCore(evt, "Search", columnIndex, edit.value))
				edit.focus();
	}
}

function OnSEFocus(evt){
	evt = _getEvent(evt);
	var edit = _getEventSource(evt);
	var gridName = getBtnGridName(edit);
	var columnIndex = getElementRowId(edit);
	var gridObj = GetGridCollection().Get(gridName);
	if(gridObj != null)
		gridObj.SearchEditorFocus(columnIndex);
}

function OnSEBlur(evt){
	evt = _getEvent(evt);
	var edit = _getEventSource(evt);
	var gridName = getBtnGridName(edit);
	var columnIndex = getElementRowId(edit);
	var gridObj = GetGridCollection().Get(gridName);
	if(gridObj != null)
		gridObj.SearchEditorBlur(columnIndex);
}

function AfterScroll(gridName){	
	var gridObj = GetGridCollection().Get(gridName);
	if(gridObj != null) gridObj.SynchronizeScrollerPos();
}

function OnScrollNative(gridName){	
	
}

function OnGFocus(gridName){	
	var gridObj = GetGridCollection().Get(gridName);
	if(gridObj != null) gridObj.OnGetFocus();
}

function OnGLostFocus(gridName){
	var gridObj = GetGridCollection().Get(gridName);
	if(gridObj != null) gridObj.OnLostFocus();
}

function OnGMouseUp(evt, gridName){
	var gridObj = GetGridCollection().Get(gridName);
	if(gridObj != null) gridObj.OnMouseUp(evt);
}

function OnGFocusControl(gridName){
	var gridObj = GetGridCollection().Get(gridName);
	if(gridObj != null) gridObj.FocusControl();
}

function OnDSelectStart(evt){
	if(curDragEl != null || curSzLn != null)
		return false;
	if(_isExists(savedGridDocumentSelectStart))
		return savedGridDocumentSelectStart(evt);		
	return true;
}

function OnGResize(gridName){
	GetGridCollection().Get(gridName).OnResizeCore();
}

function DoResize(gridName){
	GetGridCollection().Get(gridName).DoResizeCore();
}

var scrollTimer = -1;

function ClearScrollTimer(){
	window.clearTimeout(scrollTimer);
	scrollTimer = -1;
}

function OnScroll(gridName){
	if(scrollTimer != -1)
		ClearScrollTimer();
	scrollTimer = window.setTimeout("DoScroll(\"" + gridName + "\");", 50);
}

function DoScroll(gridName){
	ClearScrollTimer();
	var grid = GetGridCollection().Get(gridName);
	grid.OnScrollCore();	
}

function OnScrlrIncBtnCl(s, e){
	OnScrlrBtnCl(s, e, true);
}

function OnScrlrDecBtnCl(s, e){
	OnScrlrBtnCl(s, e, false);
}

function OnScrlrBtnCl(s, e, direction){
	var gridName = s.name.substr(0, s.name.indexOf("VertScroll"));
	GetGridCollection().Get(gridName).MoveByCore(null, "SC", direction, "", "-1");
	e.handled = true;
}

function OnScrlrLargeIncBtnCl(s, e){
	var gridName = s.name.substr(0, s.name.indexOf("VertScroll"));
	GetGridCollection().Get(gridName).MoveNextPageCore(null, "SC", "");
	e.handled = true;
}

function OnScrlrLargeDecBtnCl(s, e){
	var gridName = s.name.substr(0, s.name.indexOf("VertScroll"));
	GetGridCollection().Get(gridName).MovePrevPageCore(null, "SC", "");
	e.handled = true;
}

var windowResizeTimer = -1;

function ClearWindowResizeTimer(){
	window.clearTimeout(windowResizeTimer);
	windowResizeTimer = -1;
}

function SetWindowResizeTimer(){
	if(windowResizeTimer != -1)
		ClearWindowResizeTimer();
	windowResizeTimer = window.setTimeout(DoWindowResize, 0);
}

function DoWindowResize(){
	ClearWindowResizeTimer();
	var gridCollection = GetGridCollection();
	for(var i = 0; i < gridCollection.GetItemCount(); i++){
		gridCollection.GetItem(i).OnWindowResizeCore();
	}
}

function ASPxGridWindowOnLoad(){
	savedGridDocumentMouseMove = document.onmousemove;
	document.onmousemove = OnDMMove;
	savedGridDocumentMouseUp = document.onmouseup;
	document.onmouseup = OnDMUp;
	savedGridDocumentMouseOver = document.onmouseover;
	document.onmouseover = OnDMOver;
	savedGridDocumentSelectStart = document.onselectstart;
	document.onselectstart = OnDSelectStart;
}

var GridScriptFirstLoad;
if(typeof(savedGridWindowLoad) == "undefined"){
	var savedGridWindowLoad = window.onload;
	var savedGridDocumentMouseMove = null;
	var savedGridDocumentMouseUp = null;
	var savedGridDocumentMouseOver = null;
	var savedGridDocumentSelectStart = null;
	var savedGridWindowResize = null;
	GridScriptFirstLoad = true;
}

window.onload = function(evt){
	if(GridScriptFirstLoad){
		ASPxGridWindowOnLoad();
		savedGridWindowResize = window.onresize;
		window.onresize = WindowOnResize;
		GridScriptFirstLoad = false;
	}
	
	if(_isExists(savedGridWindowLoad))
		return savedGridWindowLoad(evt);
	return true;
}

WindowOnResize = function(evt){
	SetWindowResizeTimer();
	if(_isExists(savedGridWindowResize))
		return savedGridWindowResize(evt);
}

clearDragState();
clearResizingCursor();
clearColumnSizingState();