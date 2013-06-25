/* 
   ASPxGrid and Editors Library by Developer Express

   Copyright (c) 2000-2005 Developer Express Inc  
   ALL RIGHTS RESERVED

   The entire contents of this file is protected by U.S. and   
   International Copyright Laws. Unauthorized reproduction,     
   reverse-engineering, and distribution of all or any portion of   
   the code contained in this file is strictly prohibited and may  
   result in severe civil and criminal penalties and will be        
   prosecuted to the maximum extent possible under the law.
*/
function ASPxGridRenderCore(grid){
	this.grid = grid;	
	
	this.showFocusedBorder = false;		
	this.focusedBorderStyle = "";
	this.focusedBorderColor = "";
	this.savedCellsColors = new Array();
	this.savedCellsTopBorders = new Array();
	this.savedCellsBottomBorders = new Array();	
	this.fakeImage = null;
	this.prevFocusedColumnIndex = -1;
	this.savedSelectedColors = new Array();
	this.borderCollapse = true;	
	this.showGridLinesBetweenButtons = true;	
	this.showVerticalGridLines = true;
	this.instantiateTemplatesInButtons = true;
	
	this.selectedBackColor = "highlight";
	this.selectedForeColor = "highlighttext";
	this.img1x1 = _getDefaultImagePath() + "1x1.gif";
	this.imgIndicator = _getDefaultImagePath() + "rbIndicator.gif";

	this.scrollBars = "None";
	this.scrollBarSize = new ASPxClientUnit(16, "px");
	this.nativeScrolling = false;
	this.nativeLookAndFeel = false;
	this.scrollWidth = new ASPxClientUnit(0, "");
	this.scrollHeight = new ASPxClientUnit(0, "");
	this.vertScrollHeight = new ASPxClientUnit(0, "");
	this.vertScrollBarEmpty = false;
	this.horzScrollBarEmpty = false;
	this.htmlScroller = null;
	this.htmlVertScroller = null;
	this.horzScrollBar = null;
	this.vertScrollBar = null;

	this.htmlFrameTable = null;	
	this.htmlGridTable = null;
	this.htmlRows = null;
	this.htmlItems = null;
	this.htmlTitle = null;
	this.htmlGroupPanel = null;
	this.htmlHeaderPanel = null;		
	this.htmlSearchItem = null;
	this.htmlFooter = null;
	this.htmlEmptySpace = null;
	this.htmlSynchSpace = null;
	this.htmlSynchHeaderPanel = null;
	this.htmlSynchSearchItem = null;
	this.htmlSynchFooter = null;
	
	this.showGridTable = true;
	this.showItemsTable = false;
	this.showRowsTable = false;

	this.showTitle = false;		
	this.showGroupPanel = true;		
	this.showHeaders = true;
	this.showFooter = false;
	this.showSearchItem = false;
	this.searchItemPosition = "Top";	
	this.statusBarCount = 0;
	this.firstTROffset = -1;
	this.lastTROffset = -1;
	
	this.GetHtmlFrameTable = function(){
		if(this.htmlFrameTable == null)
			this.htmlFrameTable = _getElementById(this.grid.name);
		return this.htmlFrameTable;
	}	
	
	this.GetHtmlGridTable = function (){
		if(this.htmlGridTable == null){
			if(this.showGridTable)
				this.htmlGridTable = _getFirstChild(_getElementById(this.grid.name + "Table"));
			else
				this.htmlGridTable = this.GetHtmlFrameTable();
		}
		return this.htmlGridTable;
	}
	
	this.GetHtmlRows = function (){
		if(this.htmlRows == null){
			if(this.showRowsTable)
				this.htmlRows = _getFirstChild(_getElementById(this.grid.name + "Rows"));
			else
				this.htmlRows = this.GetHtmlItems();		
		}
		return this.htmlRows;
	}

	this.GetHtmlItems = function (){
		if(this.htmlItems == null){
			if(this.showItemsTable)
				this.htmlItems = _getFirstChild(_getElementById(this.grid.name + "Items"));
			else
				this.htmlItems = this.GetHtmlGridTable();
		}
		return this.htmlItems;
	}
	
	this.GetHtmlHeaderPanel = function(){
		if(this.htmlHeaderPanel == null)
			this.htmlHeaderPanel = _getElementById(this.grid.name + "~headerpanel");
		return this.htmlHeaderPanel;
	}
	
	this.GetHtmlTitle = function(){
		if(this.htmlTitle == null)
			this.htmlTitle = _getElementById(this.grid.name + "~title");
		return this.htmlTitle;
	}
	
	this.GetHtmlGroupPanel = function(){
		if(this.htmlGroupPanel == null)
			this.htmlGroupPanel = _getElementById(this.grid.name + "~grouppanel");
		return this.htmlGroupPanel;
	}
	
	this.GetHtmlSearchItem = function (){	
		if(this.htmlSearchItem == null)
			this.htmlSearchItem = _getElementById(this.grid.name + "~search");
		return this.htmlSearchItem;
	}
	
	this.GetHtmlFooter = function (){	
		if(this.htmlFooter == null)
			this.htmlFooter = _getElementById(this.grid.name + "~footer");
		return this.htmlFooter;
	}
	
	this.GetHtmlEmptySpace = function (){
		if(this.htmlEmptySpace == null)
			this.htmlEmptySpace = _getElementById(this.grid.name + "~space");
		return this.htmlEmptySpace;
	}

	this.GetHtmlSynchSpace = function (){
		if(this.htmlSynchSpace == null)
			this.htmlSynchSpace = _getElementById(this.grid.name + "~synchspace");
		return this.htmlSynchSpace;
	}
	
	this.GetHtmlScroller = function (){	
		if(this.htmlScroller == null)
			this.htmlScroller = _getElementById(this.grid.name + "scroller");
		return this.htmlScroller;
	}

	this.GetHtmlVertScroller = function (){	
		if(this.htmlVertScroller == null)
			this.htmlVertScroller = _getElementById(this.grid.name + "vertscroller");
		return this.htmlVertScroller;
	}
	
	this.GetHtmlSynchHeaderPanel = function(){
		if(this.htmlSynchHeaderPanel == null)
			this.htmlSynchHeaderPanel = _getElementById(this.grid.name + "~synchheaderpanel");
		return this.htmlSynchHeaderPanel;
	}
	
	this.GetHtmlSynchSearchItem = function (){	
		if(this.htmlSynchSearchItem == null)
			this.htmlSynchSearchItem = _getElementById(this.grid.name + "~synchsearch");
		return this.htmlSynchSearchItem;
	}
	
	this.GetHtmlSynchFooter = function (){	
		if(this.htmlSynchFooter == null)
			this.htmlSynchFooter = _getElementById(this.grid.name + "~synchfooter");
		return this.htmlSynchFooter;
	}
	
	this.GetScrollBarSize = function(){
		return !this.nativeScrolling && !this.nativeLookAndFeel ? this.scrollBarSize : new ASPxClientUnit(_getScrollBarWidth() + 1, "px");
	}

	this.IsGridDisplayed = function(){
		return _isElementDisplayed(this.GetHtmlFrameTable());
	}
		
	this.GetFirstTROffset = function(){
		if(this.firstTROffset == -1){
			this.firstTROffset = 0;		
			if(!this.showRowsTable){
				if(!this.showItemsTable){
					if(this.showTitle)
						this.firstTROffset ++;
					if(this.showGroupPanel)
						this.firstTROffset ++;
				}
				if(this.showHeaders)
					this.firstTROffset ++;
				if(this.showSearchItem && this.searchItemPosition == "Top")
					this.firstTROffset ++;
			}
		}	
		return this.firstTROffset;
	}
	
	this.GetLastTROffset = function(){
		if(this.lastTROffset == -1){
			this.lastTROffset = 1;	//space
			if(!this.showRowsTable){
				if(this.showFooter)
					this.lastTROffset ++;
				if(this.showSearchItem && this.searchItemPosition == "Bottom")
					this.lastTROffset ++;
				if(!this.showItemsTable)
					this.lastTROffset += this.statusBarCount;
			}	
		}
		return this.lastTROffset;
	}
	
	this.GetFakeImage = function(){
		if(this.fakeImage == null){
			this.fakeImage = document.createElement("IMG");
			var hostElement = _getServerForm();
			if(hostElement == null) 
				hostElement = document.body;
			hostElement.appendChild(this.fakeImage);
			this.fakeImage.style.position = "absolute";
			this.fakeImage.src = this.img1x1;		
			this.fakeImage.style.zIndex = indicatorImgZIndex;
			_setElementTop(this.fakeImage, 0);		
		}
		return this.fakeImage;
	}

	this.ShowFakeImage = function(){
		var img = this.GetFakeImage();
		if(img != null){	
			_setElementLeft(img, 0);
			_setElementTop(img, _getElementTop(img) == 0 ? 1 : 0);		
			_setElementVisibility(img, "visible");
		}
	}

	this.SetIndicatorFocused = function(td, showPreview){
		var handled = (!this.grid.BindRowBtn.IsEmpty() ? this.grid.OnBindRowBtn(td, "Indicator", this.imgIndicator, showPreview) : false);
		if(!handled){
			var img = _getChildByTagName(td, "IMG", 0);
			if(img != null)
				img.src = this.imgIndicator;
		}
	}

	this.SetIndicatorUnfocused = function(td, showPreview){
		var handled = (!this.grid.BindRowBtn.IsEmpty() ? this.grid.OnBindRowBtn(td, "Empty", this.img1x1, showPreview) : false);
		if(!handled){
			var img = _getChildByTagName(td, "IMG", 0);
			if(img != null)
				img.src = this.img1x1;
		}
	}
	
	this.HideSelection = function(tr, rowIndex){
		var rowLevel = this.grid.GetRowLevel(tr);
		var restoringArray = this.grid.multiSelection ? tr.savingArray : this.savedCellsColors;
		if(tr.selectionMode == "GR"){
			var offset = 1;
			while(this.grid.internalColumns[this.grid.internalColumns.length - offset].type == "RowBtnColumn")
				offset ++;
			var cell = tr.cells[tr.cells.length - offset];
			if(!this.grid.OnCustomRenderSelection(td, this.grid.groupColumns[rowLevel], true, false)){
				cell.style.color = restoringArray[0].foreColor;
				cell.style.backgroundColor = restoringArray[0].backColor;		
			}
		}
		else{		
			var dataColumnIndex = 0;
			for(var i = 0; i < this.grid.internalColumns.length; i ++){
				if(this.NeedHideColumnSelection(this.grid.internalColumns[i])){
					if(i < tr.cells.length) {
						var td = tr.cells[i];
						if(!this.grid.OnCustomRenderSelection(td, this.grid.internalColumns[i], false, false)){
							td.style.color = restoringArray[dataColumnIndex].foreColor;
							td.style.backgroundColor = restoringArray[dataColumnIndex].backColor;
						}
					}
					dataColumnIndex ++;
				}
			}
		}
		array_clear(restoringArray);
	}

	this.ShowSelection = function(tr, rowIndex){	
		var rowLevel = this.grid.GetRowLevel(tr);	
		var savingArray;
		if(this.grid.multiSelection){
			if(typeof(tr.savingArray) == "undefined"){
				savingArray = new Array();
				tr.savingArray = savingArray;
			}
			else{
				savingArray = tr.savingArray;
			}
		}
		else{
			savingArray = this.savedCellsColors;
			array_clear(savingArray);
		}
		if(rowLevel < this.grid.groupColumns.length){
			var offset = 1;
			while(this.grid.internalColumns[this.grid.internalColumns.length - offset].type == "RowBtnColumn")
				offset ++;		
			var td = tr.cells[tr.cells.length - offset];
			savingArray.push(new CellColor(td.style.color, td.style.backgroundColor));
			if(!this.grid.OnCustomRenderSelection(td, this.grid.groupColumns[rowLevel], true, true)){
				td.style.color = this.selectedForeColor;
				td.style.backgroundColor = this.selectedBackColor;
			}
			tr.selectionMode = "GR";
		}
		else{					
			for(var i = 0; i < this.grid.internalColumns.length; i ++){
				if(this.NeedShowColumnSelection(this.grid.internalColumns[i])){
					var td = tr.cells[i];
					savingArray.push(new CellColor(td.style.color, td.style.backgroundColor));
					if(!this.grid.OnCustomRenderSelection(td, this.grid.internalColumns[i], false, true)){
						td.style.color = this.selectedForeColor;
						td.style.backgroundColor = this.selectedBackColor;
					}
				}	
			}
			this.prevFocusedColumnIndex = this.grid.focusedColumnIndex;
			tr.selectionMode = "DR";
		}
	}
	
	
	this.NeedChangeColumnSelection = function(column, sampleIndex){
		return (column.type == "BoundColumn" || column.type == "TemplateColumn") && (!this.grid.cellSelection || !this.grid.clientSideMode && this.grid.GetDataMode() != "Browse" || column.index == sampleIndex);
	}

	this.NeedHideColumnSelection = function(column){
		return this.NeedChangeColumnSelection(column, this.prevFocusedColumnIndex);
	}

	this.NeedShowColumnSelection = function(column){
		return this.NeedChangeColumnSelection(column, this.grid.focusedColumnIndex);
	}
	
	this.RestoreFocusedRowBorder = function(tr, rowLevel, topBorder, saveLeftRight, savingArray){	
		if(tr.focusedBorderMode == "GR"){
			var offset = 1;
			if(rowLevel != -1){
				while(this.grid.internalColumns[this.grid.internalColumns.length - offset].type == "RowBtnColumn")
					offset ++;
			}
			var savingArrayOffset = 0;
			var cell = tr.cells[tr.cells.length - offset];
			if(saveLeftRight){
				cell.style.borderLeftStyle = savingArray[savingArrayOffset].style;
				cell.style.borderLeftColor = savingArray[savingArrayOffset].color;		
				savingArrayOffset ++;
			}
			if(topBorder){
				cell.style.borderTopStyle = savingArray[savingArrayOffset].style;
				cell.style.borderTopColor = savingArray[savingArrayOffset].color;		
			}
			else{
				cell.style.borderBottomStyle = savingArray[savingArrayOffset].style;
				cell.style.borderBottomColor = savingArray[savingArrayOffset].color;		
			}
			if(saveLeftRight){
				savingArrayOffset ++;
				cell.style.borderRightStyle = savingArray[savingArrayOffset].style;
				cell.style.borderRightColor = savingArray[savingArrayOffset].color;					
			}
		}
		if(tr.focusedBorderMode == "DR"){
			var dataColInd = 0;
			var firstColumn = true;
			var savingArrayOffset = 0;
			var lastColInd = -1;
			var curColInd = 0;
			for(var i = 0; i < this.grid.internalColumns.length; i ++){
				if(this.NeedHideColumnSelection(this.grid.internalColumns[i])){
					var cell = tr.cells[curColInd];
					if(saveLeftRight && firstColumn){
						if(this.borderCollapse){
							if(this.grid.cellSelection && curColInd > 0){
								var leftBorderCell = tr.cells[curColInd - 1];
								leftBorderCell.style.borderRightStyle = savingArray[dataColInd + savingArrayOffset].style;
								leftBorderCell.style.borderRightColor = savingArray[dataColInd + savingArrayOffset].color;	
								savingArrayOffset ++;	
							}
						}
						else{
							cell.style.borderLeftStyle = savingArray[dataColInd + savingArrayOffset].style;
							cell.style.borderLeftColor = savingArray[dataColInd + savingArrayOffset].color;	
							savingArrayOffset ++;
						}
						firstColumn = false;					
					}
					if(topBorder){
						cell.style.borderTopStyle = savingArray[dataColInd + savingArrayOffset].style;
						cell.style.borderTopColor = savingArray[dataColInd + savingArrayOffset].color;					
					}
					else{
						cell.style.borderBottomStyle = savingArray[dataColInd + savingArrayOffset].style;
						cell.style.borderBottomColor = savingArray[dataColInd + savingArrayOffset].color;
					}
					dataColInd ++;
					lastColInd = curColInd;
				}
				if(rowLevel != -2 || this.grid.internalColumns[i].type != "GroupingIndentColumn")
					curColInd ++;
			}
			if(saveLeftRight && lastColInd >= 0){
				tr.cells[lastColInd].style.borderRightStyle = savingArray[dataColInd + savingArrayOffset].style;
				tr.cells[lastColInd].style.borderRightColor = savingArray[dataColInd + savingArrayOffset].color;
			}
		}
	}

	this.SetFocusedRowBorder = function(tr, rowLevel, topBorder, saveLeftRight, savingArray){	
		if(rowLevel < this.grid.groupColumns.length && rowLevel != -2){
			var offset = 1;
			if(rowLevel != -1){
				while(this.grid.internalColumns[this.grid.internalColumns.length - offset].type == "RowBtnColumn")
					offset ++;
			}	
			var cell = tr.cells[tr.cells.length - offset];
			if(saveLeftRight){
				savingArray.push(new CellBorder(cell.style.borderLeftStyle, cell.style.borderLeftColor));
				cell.style.borderLeftStyle = this.focusedBorderStyle;
				cell.style.borderLeftColor = this.focusedBorderColor;
			}
			if(topBorder){
				savingArray.push(new CellBorder(cell.style.borderTopStyle, cell.style.borderTopColor));
				cell.style.borderTopStyle = this.focusedBorderStyle;
				cell.style.borderTopColor = this.focusedBorderColor;
			}
			else{
				savingArray.push(new CellBorder(cell.style.borderBottomStyle, cell.style.borderBottomColor));
				cell.style.borderBottomStyle = this.focusedBorderStyle;
				cell.style.borderBottomColor = this.focusedBorderColor;
			}
			if(saveLeftRight){
				savingArray.push(new CellBorder(cell.style.borderRightStyle, cell.style.borderRightColor));
				cell.style.borderRightStyle = this.focusedBorderStyle;
				cell.style.borderRightColor = this.focusedBorderColor;
			}
			tr.focusedBorderMode = "GR";
		}
		else{
			var firstColumn = true;		
			var lastColInd = -1;			
			var curColInd = 0;
			for(var i = 0; i < this.grid.internalColumns.length; i ++){			
				if(this.NeedShowColumnSelection(this.grid.internalColumns[i])){
					var cell = tr.cells[curColInd];
					if(saveLeftRight && firstColumn){
						if(this.borderCollapse){
							if(this.grid.cellSelection && curColInd > 0){
								var leftBorderCell = tr.cells[curColInd - 1];
								savingArray.push(new CellBorder(leftBorderCell.style.borderRightStyle, leftBorderCell.style.borderRightColor));
								leftBorderCell.style.borderRightStyle = this.focusedBorderStyle;
								leftBorderCell.style.borderRightColor = this.focusedBorderColor;
							}
						}
						else{
							savingArray.push(new CellBorder(cell.style.borderLeftStyle, cell.style.borderLeftColor));
							cell.style.borderLeftStyle = this.focusedBorderStyle;
							cell.style.borderLeftColor = this.focusedBorderColor;
						}
						firstColumn = false;
					}
					if(topBorder){
						savingArray.push(new CellBorder(cell.style.borderTopStyle, cell.style.borderTopColor));
						cell.style.borderTopStyle = this.focusedBorderStyle;
						cell.style.borderTopColor = this.focusedBorderColor;
					}
					else{
						savingArray.push(new CellBorder(cell.style.borderBottomStyle, cell.style.borderBottomColor));
						cell.style.borderBottomStyle = this.focusedBorderStyle;
						cell.style.borderBottomColor = this.focusedBorderColor;
					}
					lastColInd = curColInd;
				}	
				if(rowLevel != -2 || this.grid.internalColumns[i].type != "GroupingIndentColumn")
					curColInd ++;				
				tr.focusedBorderMode = "DR";
			}
			if(saveLeftRight && lastColInd >= 0){
				savingArray.push(new CellBorder(tr.cells[lastColInd].style.borderRightStyle, tr.cells[lastColInd].style.borderRightColor));
				tr.cells[lastColInd].style.borderRightStyle = this.focusedBorderStyle;
				tr.cells[lastColInd].style.borderRightColor = this.focusedBorderColor;
			}
		}
	}
	
	this.GetTopBorderTR = function(tr){
		var topBorderTR = _getPreviousSibling(tr);
		return topBorderTR;
	}
	
	this.ShouldDrawTopBorderInDifferentTR = function(tr){
		return this.borderCollapse;
	}
	
	this.HideFocus = function(tr){		
		if(this.grid.internalColumns.length > 0){
			if(this.grid.internalColumns[0].type == "IndicatorColumn")			
				this.SetIndicatorUnfocused(tr.cells[0], this.TRHasPreview(tr));		
			
			if(this.showFocusedBorder){
				var rowLevel = this.grid.GetRowLevel(tr);
				this.RestoreFocusedRowBorder(tr, rowLevel, false, !this.borderCollapse, this.savedCellsBottomBorders);
				if(this.ShouldDrawTopBorderInDifferentTR(tr)){
					var topBorderTR = this.GetTopBorderTR(tr);
					if(topBorderTR != null && this.savedCellsTopBorders.length > 0)
						this.RestoreFocusedRowBorder(topBorderTR, this.GetTopRowLevel(topBorderTR), false, false, this.savedCellsTopBorders);
				}
				else{
					this.RestoreFocusedRowBorder(tr, rowLevel, true, false, this.savedCellsTopBorders);
				}
				
				array_clear(this.savedCellsTopBorders);
				array_clear(this.savedCellsBottomBorders);
			}
		}
	}
	
	this.ShowFocus = function(tr){	
		var rowLevel = this.grid.GetRowLevel(tr);	
		if(this.grid.internalColumns.length > 0){
			if(this.grid.internalColumns[0].type == "IndicatorColumn"){
				if(tr != null){
					this.SetIndicatorFocused(tr.cells[0], this.TRHasPreview(tr));
					this.ShowFakeImage();
				}
			}
			else{
				this.ShowFakeImage();
			}
			
			if(this.showFocusedBorder){
				this.SetFocusedRowBorder(tr, rowLevel, false, !this.borderCollapse, this.savedCellsBottomBorders);	
				if(this.ShouldDrawTopBorderInDifferentTR(tr)){
					var topBorderTR = this.GetTopBorderTR(tr);
					if(topBorderTR != null)		
						this.SetFocusedRowBorder(topBorderTR, this.GetTopRowLevel(topBorderTR), false, false, this.savedCellsTopBorders);
				}
				else{
					this.SetFocusedRowBorder(tr, rowLevel, true, false, this.savedCellsTopBorders);
				}
			}				
		}
		this.CorrectScrollersPos(tr);
	}
	
	this.GetVertScrollElement = function(){
		return this.IsClientSideScrollBars() ? this.GetHtmlVertScrollArea() : this.GetHtmlVertScroller();
	}
	this.CorrectScrollersPos = function(tr){
		if(this.IsScrollBarShown()){
			if(!this.nativeScrolling){
				if(this.IsVertScrollBarShown() && !(this.IsClientSideScrollBars() && this.grid.GetPageSize() > 0)){
					var scroller = this.GetVertScrollBar();	
					if(scroller != null){
						var scrollElement = this.GetVertScrollElement();
						if(_getElementBottom(tr) > scrollElement.scrollTop + scrollElement.clientHeight)
							scroller.SetPosition(_getElementBottom(tr) - scrollElement.clientHeight);		
						if(_getElementTop(tr) < scrollElement.scrollTop)
							scroller.SetPosition(_getElementTop(tr));				
					}
				}
				if(this.IsHorzScrollBarShown() && !this.grid.IsGroupRow(tr)){
					scroller = this.GetHorzScrollBar();	
					if(scroller != null && this.grid.focusedColumnIndex >= 0){
						var scrollElement = this.GetHtmlScroller();
						var td = tr.cells[array_indexOf(this.grid.internalColumns, this.grid.columns[this.grid.focusedColumnIndex])];
						if(_getElementRight(td) > scrollElement.scrollLeft + scrollElement.clientWidth)
							scroller.SetPosition(_getElementRight(td) - scrollElement.clientWidth);		
						if(_getElementLeft(td) < scrollElement.scrollLeft)
							scroller.SetPosition(_getElementLeft(td));				
					}
				}
			}
		}
	}
	
	this.TRHasPreview = function(tr){
		var nextSibling = _getNextSibling(tr);
		return nextSibling != null && _strIndexOf(nextSibling.id, getPreviewRowMark()) >= 0 && nextSibling.style.display != "none";
	}	
	
	this.GetTopRowLevel = function(topBorderTR){
		if(topBorderTR.rowIndex < this.grid.firstTRIndex)
			return -2;
		else if(topBorderTR.id.indexOf(getPreviewRowMark()) >= 0)
			return -1;
		else	
			return this.grid.GetRowLevel(topBorderTR);
	}	
	
	this.IsScrollBarShown = function(){
		return !(this.scrollBars == "None" || (this.scrollBars == "Auto" && !this.IsClientSideScrollBars()));
	}

	this.IsVertScrollBarShown = function(){
		return (this.scrollBars == "Vertical") || (this.scrollBars == "Both") ||
			(this.scrollBars == "Auto" && this.IsClientSideScrollBars()) || 
			(this.IsScrollBarShown() && nsUpLevel);
	}

	this.IsHorzScrollBarShown = function(){
		return (this.scrollBars == "Horizontal") || (this.scrollBars == "Both");
	}	
	
	this.GetHorzScrollBar = function (){	
		if(this.horzScrollBar == null && _isFunctionType(typeof(GetLookAndFeelScrollBarCollection))){
			this.grid.CheckScrollBarsInitialized();
			this.horzScrollBar = GetLookAndFeelScrollBarCollection().Get(this.grid.name + "HorzScroll");
		}
		return this.horzScrollBar;
	}
	
	this.GetVertScrollBar = function (){	
		if(this.vertScrollBar == null && _isFunctionType(typeof(GetLookAndFeelScrollBarCollection))){
			this.grid.CheckScrollBarsInitialized();
			this.vertScrollBar = GetLookAndFeelScrollBarCollection().Get(this.grid.name + "VertScroll");
		}
		return this.vertScrollBar;
	}
	
	this.GetScrollHeight = function(){
		return this.horzScrollBarEmpty ? this.scrollHeight : this.scrollHeight.Add(this.scrollBarSize);
	}
	
	this.GetVertScrollHeight = function(){
		return this.horzScrollBarEmpty ? this.vertScrollHeight : this.vertScrollHeight.Add(this.scrollBarSize);
	}
	
	this.CorrectEmptyRegularScrollBars = function(){
		var horzCompensation = 0;
		var vertScrollBar = this.IsVertScrollBarShown() ? this.GetVertScrollBar() : null;
		var horzScrollBar = this.IsHorzScrollBarShown() ? this.GetHorzScrollBar() : null;
		var scroller = this.GetHtmlScroller();
		if(horzScrollBar != null){
			horzScrollBar.Calculate(true);
			if(this.horzScrollBarEmpty == horzScrollBar.visible){
				this.horzScrollBarEmpty = !this.horzScrollBarEmpty;
				var height = this.GetScrollHeight();
				if(scroller != null)
					_getParentNode(_getParentNode(_getParentNode(scroller))).rows[1].style.height = !this.horzScrollBarEmpty ? this.scrollBarSize.ToString() : 0;
				if(this.IsVertScrollBarShown()){
					var vertScroller = this.GetHtmlVertScroller();
					if(vertScroller != null)
						vertScroller.style.height = (this.GetVertScrollHeight()).ToString();
				}
			}
		}
		if(vertScrollBar != null){
			vertScrollBar.Calculate(true);
			if(this.vertScrollBarEmpty == vertScrollBar.visible){
				this.vertScrollBarEmpty = !this.vertScrollBarEmpty;
				var width = this.vertScrollBarEmpty ? this.scrollWidth.Add(this.scrollBarSize) : this.scrollWidth;					
				if(scroller != null){
					scroller.style.width = width.ToString();
					var cellIndex = this.IsClientSideScrollBars() ? 2 : 1;
					_getParentNode(_getParentNode(scroller)).cells[cellIndex].style.width = !this.vertScrollBarEmpty ? this.scrollBarSize.ToString() : 0;						
				}
				if(horzScrollBar != null)
					horzScrollBar.SetSize(width);
				horzCompensation = this.scrollBarSize.ConvertToPx().value * (vertScrollBar.visible ? -1 : 1);
				if(this.vertScrollBarEmpty && !this.IsHorzScrollBarShown() && !this.IsClientSideScrollBars())
					this.IncLastColumnWidth(_getElementWidth(this.GetHtmlGridTable()) - _getElementWidth(this.GetHtmlRows()));
			}
		}	
		return horzCompensation;
	}
	
	this.CorrectEmptyNativeScrollBars = function(){
		if(this.IsClientSideScrollBars()){
			var horzScrollBar = this.IsHorzScrollBarShown() ? this.GetHtmlScroller() : null;			
			if(horzScrollBar != null)
				this.horzScrollBarEmpty = _getElementWidth(horzScrollBar) == horzScrollBar.scrollWidth;
		}
	}
	
	this.UpdateInnerTableBorders = function(table, bordersVisible){
		for(var i = 0; i < table.rows.length; i ++){
			var tr = table.rows[i];
			tr.cells[0].style.borderLeftWidth = 0;
			if(bordersVisible){
				if(typeof(tr.cells[tr.cells.length - 1].savedBorderRightWidth) != "undefined" && tr.cells[tr.cells.length - 1].savedBorderRightWidth != "restored"){
					tr.cells[tr.cells.length - 1].style.borderRightWidth = tr.cells[tr.cells.length - 1].savedBorderRightWidth;
					tr.cells[tr.cells.length - 1].savedBorderRightWidth = "restored";
				}
			}
			else{				
				if(tr.cells[tr.cells.length - 1].style.borderRightWidth != "0px"){
					tr.cells[tr.cells.length - 1].savedBorderRightWidth = tr.cells[tr.cells.length - 1].style.borderRightWidth;
					tr.cells[tr.cells.length - 1].style.borderRightWidth = 0;
				}
			}
		}
	}
	
	this.UpdateInnerTablesBorders = function(){
		if(this.IsVertScrollBarShown() || this.IsHorzScrollBarShown()){
			if(this.showItemsTable)
				this.UpdateInnerTableBorders(this.GetHtmlItems(), this.IsVertScrollBarShown() && !this.vertScrollBarEmpty && this.showGridLinesBetweenButtons);
			if(this.showRowsTable)
				this.UpdateInnerTableBorders(this.GetHtmlRows(), this.IsVertScrollBarShown() && !this.vertScrollBarEmpty && this.showGridLinesBetweenButtons);
		}
		else{
			if(!this.showGridLinesBetweenButtons)
				this.UpdateInnerTableBorders(this.GetHtmlGridTable(), false);
		}
	}
	
	this.IsClientSideScrollBars = function(){
		return this.grid.clientSideMode && !this.grid.processOnServer;
	}
	this.UpdateScrollBars = function(resetVertScrollBar){	
		var horzCompensation = 0;
		if(this.IsScrollBarShown() && !this.grid._lockScrollBars){
			this.grid._lockScrollBars = true;
			if(!this.nativeScrolling){
				if(resetVertScrollBar)
					this.ResetRegularVertScrollBar();								
				horzCompensation += this.CorrectEmptyRegularScrollBars();
				if(this.IsClientSideScrollBars() && this.IsVertScrollBarShown())
					this.UpdateRegularVertScrollBar();				
				horzCompensation += this.CorrectEmptyRegularScrollBars();
			}
			else{
				if(resetVertScrollBar)
					this.ResetNativeVertScrollBar();
				this.CorrectEmptyNativeScrollBars();
				if(this.IsClientSideScrollBars() && this.IsVertScrollBarShown())
					this.UpdateNativeVertScrollBar();
				this.CorrectEmptyNativeScrollBars();
			}
			this.grid._lockScrollBars = false;
		}
		this.UpdateInnerTablesBorders();
		return horzCompensation;
	}
	
	this.GetScrollPosRow = function(){
		if(this.nativeScrolling){
			var scroller = this.GetHtmlVertScroller();
			var scrollTop = scroller.scrollTop;
			var visibleRowCount = this.grid.GetVisibleRowCount();
			var pageSize = this.grid.GetPageSize();
			var heightGap = scroller.scrollHeight - scroller.offsetHeight;
			heightGap = heightGap == 0 ? 1 : heightGap;
			var rowIndex = Math.round( scrollTop * (visibleRowCount - pageSize) / (heightGap));
			return this.grid.GetVisibleRow(rowIndex);
		}
		else{
			var scroller = this.GetVertScrollBar();
			return this.grid.GetVisibleRow(Math.round( scroller.GetPosition() * (this.grid.GetVisibleRowCount() - this.grid.pageSize) / (scroller.scrollableSize - (this.IsHorzScrollBarShown() ? this.GetHorzScrollBar().scrollBarButtonSize : 0))));
		}
	}
	
	this.GetItemsHeight = function(table){
		var startIndex = 0;
		if(this.showTitle)
			startIndex ++;
		if(this.showGroupPanel)
			startIndex ++;
		var endIndex = table.rows.length;
		endIndex -= this.statusBarCount;
		var height = 0;
		if(table != null){		
			for(var i = startIndex; i < endIndex; i ++){
				height += _getElementHeight(table.rows[i]);
			}
		}	
		return height;
	}	

	this.GetTargetHeaderInfo = function(x, y, currentColIndex){
		var headerpanel = this.GetHtmlHeaderPanel();	
		if(headerpanel != null){
			var headerpanelX = _absoluteX(headerpanel, this.grid.name, false, false, false, true);
			var headerpanelY = _absoluteY(headerpanel, this.grid.name, false, false, false, true);
			if(x > headerpanelX && x < headerpanelX + _getElementWidth(headerpanel) && y > headerpanelY && y < headerpanelY + _getElementHeight(headerpanel)){
				var targetIndex = 0;			
				var headerIndex = 0;			
				for(var i = 0; i < this.grid.internalColumns.length; i ++){
					var column = this.grid.internalColumns[i];
					if(column.type != "" && column.type != "GroupingIndentColumn"){
						var header = headerpanel.cells[headerIndex];
						if(header != null){
							var headerX = _absoluteX(header, this.grid.name, false, false, false, true);
							var headerWidth = _getElementWidth(header);
							if(x > headerX && x < headerX + headerWidth){
								var before = x <= headerX + headerWidth / 2;
								var targetX = _getElementLeft(header) + (before ? 0 : _getElementWidth(header));
								var scroller = this.GetHtmlScroller();	
								if((column.type == "BoundColumn" || column.type == "TemplateColumn") && (scroller == null || scroller.scrollLeft == null || targetX >= scroller.scrollLeft && targetX <= scroller.scrollLeft + _getElementWidth(scroller))){
									var targetHeaderInfo = new Object();
									targetHeaderInfo.x = _absoluteX(header, this.grid.name, false, false, false, true) + (before ? 0 : headerWidth);
									targetHeaderInfo.y = _absoluteY(header, this.grid.name, false, false, false, true);
									targetHeaderInfo.height = _getElementHeight(header);
									targetHeaderInfo.columnIndex = column.index;						
									targetHeaderInfo.targetIndex = (before || column.index == currentColIndex) ? targetIndex : targetIndex + 1;
									targetHeaderInfo.inGroupingPanel = false;
									return targetHeaderInfo;
								}
								else
									return null;
							}
							else{
								if((column.type == "BoundColumn" || column.type == "TemplateColumn" || column.type == "RowBtnColumn") && column.index != currentColIndex)
									targetIndex++;							
							}
						}
						headerIndex ++;
					}
				}
			}
		}
		return null;
	}

	this.GetTargetGroupedHeaderInfo = function(x, y, currentColIndex){	
		var grouppanel = this.GetHtmlGroupPanel();	
		if(grouppanel != null){		
			var grouppanelX = _absoluteX(grouppanel, this.grid.name, false, false, false, true);
			var grouppanelY = _absoluteY(grouppanel, this.grid.name, false, false, false, true);
			if(x > grouppanelX && x < grouppanelX + _getElementWidth(grouppanel) && y > grouppanelY && y < grouppanelY + _getElementHeight(grouppanel)){
				if(this.grid.groupColumns.length == 0){
					var targetHeaderInfo = new Object();
					targetHeaderInfo.x = _absoluteX(grouppanel, this.grid.name, false, false, false, true);
					targetHeaderInfo.y = _absoluteY(grouppanel, this.grid.name, false, false, false, true);
					targetHeaderInfo.height = _getElementHeight(grouppanel);
					targetHeaderInfo.columnIndex = -1;
					targetHeaderInfo.targetIndex = 0;
					targetHeaderInfo.inGroupingPanel = true;
					return targetHeaderInfo;				
				}
				else{					
					var targetIndex = 0;
					var groupHeaders = _getFirstChild(_getFirstChild(_getFirstChild(grouppanel.cells[0])).rows[0].cells[1]).rows[0];
					for(var i = 0; i < groupHeaders.cells.length; i ++){
						var header = groupHeaders.cells[i];
						if(header != null){
							//var headerX = _absoluteX(header, this.grid.name, false, true, true, true);
							var headerX = _absoluteX(header, this.grid.name, false, false, false, true);
							var headerWidth = _getElementWidth(header);
							if((x > headerX && x < headerX + headerWidth) || (i == groupHeaders.cells.length - 1)){
								var before = x <= headerX + headerWidth / 2;
								var targetHeaderInfo = new Object();
								targetHeaderInfo.x = headerX + (before ? 0 : headerWidth);
								targetHeaderInfo.y = _absoluteY(header, this.grid.name, false, false, false, true);
								targetHeaderInfo.height = _getElementHeight(header);
								targetHeaderInfo.columnIndex = this.grid.groupColumns[i];
								targetHeaderInfo.targetIndex = before ? targetIndex : targetIndex + 1;
								targetHeaderInfo.inGroupingPanel = true;
								return targetHeaderInfo;
							}
							else{
								if(this.grid.groupColumns[i] != currentColIndex)
									targetIndex++;
							}
						}
					}				
				}
			}
		}
		return null;
	}
	
	this.GetResizingHeaderInfo = function(header, columnIndex, x){
		var headerAbsoluteX = _absoluteX(header, this.grid.name, false, false, true, true);	
		var leftEdge = headerAbsoluteX;
		var rightEdge = headerAbsoluteX + _getElementWidth(header);
		if((leftEdge < (x + columnSizingEdge) && leftEdge > (x - columnSizingEdge)) || (rightEdge < (x + columnSizingEdge) && rightEdge > (x - columnSizingEdge))){
			if(leftEdge > (x - columnSizingEdge)){
				columnIndex = -1;
				var headerIndex = header.cellIndex;
				var _isRtl = isRtl();				
				if(!_isRtl && headerIndex > 0 || _isRtl && headerIndex < _getParentNode(header).cells.length - 1){
					header = _getParentNode(header).cells[headerIndex + (_isRtl ? 1 : -1)];					
					var _indexOf = header.id.indexOf(idDlmtr);
					if(_indexOf != -1)					
						columnIndex = header.id.substr(_indexOf + (getColumnHeaderMark()).length, header.id.length);
				}
			}		
			if(columnIndex >= 0){
				var column = this.grid.columns[columnIndex];
				if(column != null && column.enableColumnSizing){
					var resizingHeader = header;
					var resizingHeaderInfo = new Object();
					resizingHeaderInfo.x = _absoluteX(resizingHeader, this.grid.name, false, false, false, true);
					resizingHeaderInfo.width = _getElementWidth(resizingHeader);
					resizingHeaderInfo.minWidth = column.minWidth;
					resizingHeaderInfo.columnIndex = column.index;
					return resizingHeaderInfo;
				}
			}
		}	
		return null;
	}
	
	this.SetButtonExpanded = function(td){		
		td.className = this.grid.name + "EE";
		var handled = (!this.grid.BindExpandBtn.IsEmpty() ? this.grid.OnBindExpandBtn(td, true) : false);
		if(!handled){
			var img = _getChildByTagName(td, "IMG", 0);
			if(img != null)
				img.src = this.imgEBCollapse;
		}
	}

	this.SetButtonCollapsed = function(td){
		td.className = this.grid.name + "EC";
		var handled = (!this.grid.BindExpandBtn.IsEmpty() ? this.grid.OnBindExpandBtn(td, false) : false);
		if(!handled){
			var img = _getChildByTagName(td, "IMG", 0);
			if(img != null)
				img.src = this.imgEBExpand;
		}
	}
	
	this.GetGroupingTD = function(tr, groupLevel){
		return tr.cells[this.grid.GetLeftRowBtnColumnsOffset() + groupLevel + 1];
	}
	
	this.GetActualGridWidth = function(){
		var gridTable = this.GetHtmlGridTable();
		if(gridTable != null)
			return _getElementWidth(gridTable);
		return 0;
	}	
	
	this.GetActualColumnWidth = function(internalColumnIndex){
		var space = this.GetHtmlEmptySpace();
		if(space != null)
			return _getElementWidth(space.cells[internalColumnIndex]);
		return 0;
	}

	this.GetResizedColumnWidth = function(columnIndex, correctBorderWidth){
		return new ASPxClientUnit(this.grid.newColumnWidths[columnIndex] - (correctBorderWidth ? (this.showGridLinesBetweenButtons && !this.borderCollapse ? 2 : 1) : 0), "px");
	}
	
	this.GetPreviewWidth = function(){
		return this.grid.previewWidth;
	}
	
	this.GetTotalWidth = function(){
		return this.grid.actualGridWidth;
	}
	
	this.GetGroupItemTextCellWidth = function(groupLevel){
		return this.grid.groupItemTextCellWidth + (this.grid.groupColumns.length - groupLevel - 1) * this.grid.groupRowIndent.ConvertToPx().value;
	}
	
	this.ResizeColumnHeader = function(td, column, headerWidth){
		var captionElement = _getChildById(td, "Cptn");
		var captionElementParent = _getParentNode(_getParentNode(captionElement));
		var pxWidth = headerWidth.ConvertToPx().value;
		if(column.enableGroupingButton)
			pxWidth -= _getElementWidth(captionElementParent.cells[0]); 
		if(column.drawSortingImage)
			pxWidth -= _getElementWidth(captionElementParent.cells[captionElementParent.cells.length - 1]); 
		if(pxWidth <= 0)
			pxWidth = 1;
		captionElement.style.width = pxWidth;
	}	
	
	this.SetGroupPanelWidth = function(width){
		if(this.showGroupPanel)
			_getFirstChild(_getFirstChild(this.GetHtmlGroupPanel())).style.width = width;
	}
	
	this.UseItemTemplate = function(column){
		return this.grid.useItemTemplate || column.useItemTemplate;
	}
	
	this.UseEditItemTemplate = function(column){
		return this.grid.useEditItemTemplate || column.useEditItemTemplate;
	}
	
	this.UseGroupItemTemplate = function(column){
		return this.grid.useGroupItemTemplate || column.useGroupItemTemplate;
	}
	
	this.UseHeaderTemplate = function(column){
		return this.grid.useHeaderTemplate || column.useHeaderTemplate;
	}
	
	this.UseFooterTemplate = function(column){
		return this.grid.useFooterTemplate || column.useFooterTemplate;
	}
	
	this.UseItemTemplateEx = function(column, editMode){
		return !editMode && this.UseItemTemplate(column) || editMode && this.UseEditItemTemplate(column);
	}
	
	this.SetCellsWidth = function(synchronizeColumnsWidth){
		var items = this.GetHtmlRows();
		var firstTROffset = this.GetFirstTROffset();
		var lastTROffset = this.GetLastTROffset();
		for(var i = firstTROffset; i <= items.rows.length - 1 - lastTROffset; i ++){
			var tr = items.rows[i];
			var rowLevel = this.grid.GetRowLevel(tr);
			if(rowLevel == this.grid.groupColumns.length){
				if(_strIndexOf(tr.id, getPreviewRowMark()) < 0){
					var editMode = this.grid.IsEditMode() && this.grid.focusedTR == tr;
					for(var j = 0; j < this.grid.internalColumns.length; j ++){
						var column = this.grid.internalColumns[j];
						if((column.type == "BoundColumn" || column.type == "TemplateColumn")){
							var td = tr.cells[j];
							var newWidth = this.GetResizedColumnWidth(j, true);
							if(!this.grid.directRender || editMode){
								var editor = column.GetEditor();
								if(!this.UseItemTemplateEx(column, editMode) && editor != null)
									editor.SetEditorSize(td.firstChild, editMode, newWidth, null);
								else
									td.style.width = newWidth.ToString();
							}
							else{
								td.style.width = newWidth.ToString();
							}
						}
					}
				}
				else{
					if(!this.grid.directRender && !this.grid.usePreviewTemplate)
						InitializeLFLabelSize(tr.cells[this.grid.groupColumns.length], new ASPxClientUnit(this.GetPreviewWidth(), "px"), null);
				}
			}
			else if(!this.grid.directRender){
				var td = this.GetGroupingTD(tr, rowLevel);
				var groupItemControl = _getFirstChild(td);
				if(groupItemControl != null && !this.UseGroupItemTemplate(this.grid.groupColumns[rowLevel]))
					groupItemControl.style.width = this.GetGroupItemTextCellWidth(rowLevel);
			}
		}
		var headers = this.GetHtmlHeaderPanel();
		var footer = this.GetHtmlFooter();
		var searchItem = this.GetHtmlSearchItem();
		var space = this.GetHtmlEmptySpace();
		var synchSpace = this.GetHtmlSynchSpace();
		for(var i = 0, headerIndex = 0; i < this.grid.internalColumns.length; i ++){
			var column = this.grid.internalColumns[i];
			var resizedColumnWidth = this.GetResizedColumnWidth(i, true);
			if(resizedColumnWidth.value < 0) resizedColumnWidth.value = 0;
			if(column.type == "BoundColumn" || column.type == "TemplateColumn"){				
				var useHeaderTemplate = this.UseHeaderTemplate(column);
				if(headers != null && (!useHeaderTemplate || this.instantiateTemplatesInButtons)){
					var headerWidth = !this.showGridLinesBetweenButtons ? resizedColumnWidth.Inc(1) : resizedColumnWidth;
					if(this.grid.groupColumns.length > 0 && i == (this.grid.groupColumns.length + this.grid.GetLeftRowBtnColumnsOffset())){
						for(var j = 1; j <= this.grid.groupColumns.length; j ++){
							headerWidth = headerWidth.Add(this.GetResizedColumnWidth(i - j, false));
						}
					}
					InitializeLFButtonSize(headers.cells[headerIndex], headerWidth, null);
					if(!useHeaderTemplate && (column.drawSortingImage || column.enableGroupingButton))
						this.ResizeColumnHeader(headers.cells[headerIndex], column, headerWidth);
				}
				if(footer != null && column.footerControlShown && !this.UseFooterTemplate(column))
					InitializeLFLabelSize(footer.cells[i], resizedColumnWidth, null);
				if(searchItem != null && column.enableSearchControl)
					InitializeLFEditorSize(searchItem.cells[i], resizedColumnWidth, null);				
			}
			if(column.type != "GroupingIndentColumn")
				headerIndex ++;
			if(space != null)
				_setElementWidth(_getFirstChild(space.cells[i]), resizedColumnWidth.ToString());
			if(synchSpace != null)
				_setElementWidth(_getFirstChild(synchSpace.cells[i]), resizedColumnWidth.ToString());
		}		
		this.SetGroupPanelWidth(this.GetTotalWidth());
		if(synchronizeColumnsWidth){
			for(var i = 0; i < this.grid.columns.length; i ++){
				var column = this.grid.columns[i];
				if(column.visibleIndex > 0)
					column.width = this.GetResizedColumnWidth(this.grid.GetColumnInternalIndex(column), false);
			}
			this.grid.SynchronizeColumns();
		}
	}	
	
	this.IncLastColumnWidth = function(delta){
		var internalColumnIndex = this.grid.GetRightRowBtnColumnsOffset();
		var column = this.grid.internalColumns[internalColumnIndex];
		var currentColumnWidth = this.GetActualColumnWidth(internalColumnIndex);
		var newColumnWidth = new ASPxClientUnit(currentColumnWidth + delta, "px");
		var items = this.GetHtmlRows();
		var firstTROffset = this.GetFirstTROffset();
		var lastTROffset = this.GetLastTROffset();
		var editor = column.GetEditor();
		for(var i = firstTROffset; i < items.rows.length - 1 - lastTROffset; i ++){
			var tr = items.rows[i];
			var rowLevel = this.grid.GetRowLevel(tr);
			if(rowLevel == this.grid.groupColumns.length){
				if(_strIndexOf(tr.id, getPreviewRowMark()) < 0){
					var editMode = this.grid.IsEditMode() && this.grid.focusedTR == tr;
					if((!this.grid.directRender || editMode) && !this.UseItemTemplateEx(column, editMode) && editor != null)
						editor.SetEditorSize(tr.cells[internalColumnIndex].firstChild, editMode, newColumnWidth, null);
				}
				else{
					if(!this.grid.directRender && !this.grid.usePreviewTemplate)
						IncrementLFLabelSize(tr.cells[this.grid.groupColumns.length], delta, 0);
				}
			}
			else if(!this.grid.directRender){
				var td = this.GetGroupingTD(tr, rowLevel);
				var groupItemControl = _getFirstChild(td);
				if(groupItemControl != null && !this.UseGroupItemTemplate(this.grid.groupColumns[rowLevel]))
					_setElementWidth(groupItemControl, _getElementWidth(groupItemControl) + delta);
			}
		}
		var headers = this.GetHtmlHeaderPanel();		
		if(headers != null && !this.UseHeaderTemplate(column))
			IncrementLFButtonSize(headers.cells[internalColumnIndex - this.grid.groupColumns.length], delta, 0);
		var footer = this.GetHtmlFooter();
		if(footer != null && _getFirstChild(footer.cells[internalColumnIndex]) != null && !this.UseFooterTemplate(column))
			IncrementLFLabelSize(footer.cells[internalColumnIndex], delta, 0);
		var searchItem = this.GetHtmlSearchItem();
		if(searchItem != null && _getFirstChild(searchItem.cells[internalColumnIndex]) != null)
			IncrementLFEditorSize(searchItem.cells[internalColumnIndex], delta, 0);
		column.width = newColumnWidth;
		this.grid.SynchronizeColumns();
	}	
	
	this.FitScrollerWidth = function(totalColumnsWidth){	
		this.SetGroupPanelWidth(1);
		var scroller = this.GetHtmlScroller();
		scroller.style.width = 1;
		var actualGridWidth = this.grid.GetActualGridWidth();
		scroller.style.width = (totalColumnsWidth > actualGridWidth) ? actualGridWidth : totalColumnsWidth + this.GetScrollBarSize().ConvertToPx().value;
		if(this.nativeScrolling)
			scroller.style.height = _getElementHeight(_getFirstChild(scroller)) + (totalColumnsWidth > actualGridWidth ? this.GetScrollBarSize().ToString() : 0);
		this.UpdateScrollBars(false);
		this.SetGroupPanelWidth(actualGridWidth);
	}
	
	this.GetColumnWidthCorrection = function(column){
		if(!this.showVerticalGridLines)
			return 2;
		else if(column.type == "IndicatorColumn" || column.type == "RowBtnColumn"){
			if(this.showGridLinesBetweenButtons){
				if(this.borderCollapse){
					if(this.grid.GetColumnInternalIndex(column) > 0)
						return 1;
				}
				else
					return 2;
			}
		}
		return 0;
	}
	
	this.GetLastTRInScrollArea = function(focusedTR){
		var lastRowIndex = this.GetHtmlRows().rows.length - this.GetLastTROffset() - 1;
		var scrollElement = this.GetVertScrollElement();
		var lastTR = focusedTR;
		var tr = _getNextSibling(focusedTR);
		while(_isExists(tr) && tr.rowIndex <= lastRowIndex && _getElementBottom(tr) <= scrollElement.scrollTop + scrollElement.clientHeight){
			lastTR = tr;
			tr = _getNextSibling(tr);
		}
		return lastTR;
	}
	
	this.GetPageDownTR = function(focusedTR){
		var lastRowIndex = this.GetHtmlRows().rows.length - this.GetLastTROffset() - 1;
		var scrollElement = this.GetVertScrollElement();
		var newFocusedTR = focusedTR;
		var tr = _getNextSibling(focusedTR);
		while(_isExists(tr) && tr.rowIndex <= lastRowIndex && _getElementBottom(tr) <= _getElementTop(focusedTR) + scrollElement.clientHeight){
			newFocusedTR = tr;
			tr = _getNextSibling(tr);
		}
		return newFocusedTR;
	}
	
	this.GetFirstTRInScrollArea = function(focusedTR){
		var firstTRIndex = this.GetFirstTROffset();
		var scrollElement = this.GetVertScrollElement();
		var firstTR = focusedTR;
		var tr = _getPreviousSibling(focusedTR);
		while(_isExists(tr) && tr.rowIndex >= firstTRIndex && _getElementTop(tr) >= scrollElement.scrollTop){
			firstTR = tr;
			tr = _getPreviousSibling(tr);
		}
		return firstTR;
	}
	
	this.GetPageUpTR = function(focusedTR){
		var firstTRIndex = this.GetFirstTROffset();
		var scrollElement = this.GetVertScrollElement();
		var newFocusedTR = focusedTR;
		var tr = _getPreviousSibling(focusedTR);
		while(_isExists(tr) && tr.rowIndex >= firstTRIndex && _getElementBottom(focusedTR) - _getElementTop(tr) <=  scrollElement.clientHeight){
			newFocusedTR = tr;
			tr = _getPreviousSibling(tr);
		}
		return newFocusedTR;
	}
	
	this.ApplyHtml = function(html){
		var CBContainer = _getParentByCssClass(this.GetHtmlFrameTable(), "CBContainer");
		CBContainer.innerHTML = html;
		this.ClearHtmlCachedElements();
	}
	
	this.ClearHtmlCachedElements = function(){
		this.htmlFrameTable = null;	
		this.htmlGridTable = null;
		this.htmlRows = null;
		this.htmlItems = null;
		this.htmlTitle = null;
		this.htmlGroupPanel = null;
		this.htmlHeaderPanel = null;		
		this.htmlSearchItem = null;
		this.htmlFooter = null;
		this.htmlEmptySpace = null;
		this.htmlSynchSpace = null;
		this.htmlSynchHeaderPanel = null;
		this.htmlSynchSearchItem = null;
		this.htmlSynchFooter = null;
	}
}

function CellColor(foreColor, backColor){
	this.foreColor = foreColor;
	this.backColor = backColor;
}

function CellBorder(style, color){
	this.style = style;
	this.color = color;
}