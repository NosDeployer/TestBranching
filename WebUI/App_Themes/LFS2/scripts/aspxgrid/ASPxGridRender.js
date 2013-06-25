function ASPxGridRender(grid){
	this.ASPxGridRenderCore = ASPxGridRenderCore;
	this.ASPxGridRenderCore(grid);
	this.initialized = false;
	
	this.rowBtnImages = new RowBtnImages();	
	this.sortingImages = new SortingImages();	
	this.groupingImages = new GroupingImages();	
	this.expandImages = new ExpandImages();
	this.imgBtnSearch = _getDefaultImagePath() + "sbSearch.gif";	
	this.rowBtnToolTips = new RowBtnToolTips();
	this.groupPanelText = "Drag a column header here to group by that column";
	this.titleText = "";
	
	this.editRowHeight = new ASPxClientUnit(0, "");
	this.headerHeight = new ASPxClientUnit(0, "");
	this.groupHeaderWidth = new ASPxClientUnit(0, "");
	this.footerHeight = new ASPxClientUnit(0, "");
	this.searchItemHeight = new ASPxClientUnit(0, "");	
	this.titleHeight = new ASPxClientUnit(20, "px");
	this.groupPanelHeight = new ASPxClientUnit(40, "px");			
	this.groupedHeaderIndent = new ASPxClientUnit(5, "px");	
	this.rowBtnWidth = new ASPxClientUnit(20, "px");
	this.indicatorWidth = new ASPxClientUnit(15, "px");
	this.expandBtnWidth = new ASPxClientUnit(15, "px");
	this.expandBtnHeight = new ASPxClientUnit(15, "px");
	this.sortingImageWidth = new ASPxClientUnit(18, "px");
	this.groupingImageWidth = new ASPxClientUnit(15, "px");
	this.groupedHeaderIndent = new ASPxClientUnit(5, "px");
	this.searchBtnWidth = new ASPxClientUnit(20, "px");		
	this.groupIndentBorderColor = "buttonshadow";	
	this.groupPanelBordersWidth = new ASPxClientUnit(0, "");
	this.titleBordersWidth = new ASPxClientUnit(0, "");
	this.footerMode = "Auto";				
	this.previewMaxLength = 0;
	this.focusedTR = null;
	this.selectedTRs = new Array();	
		
	this.showEmptyRows = true;
	this.showEmptyPreview = false;
	this.disableSelection = true;
	this.fixGroupPanelWidth = true;	
	this.correctGroupItemBorders = true;
	this.fireCustomRenderEvents = "BeforeDefaultRender";
	this.applyGroupIndentStyleDirectly = false;
	
	this.htmlStatusBars = new Array();	
	this.htmlButtonBar = null;
	this.htmlVertScrollArea = null;

	this.GetHtmlStatusBar = function (index){
		if(this.htmlStatusBars.length <= index || this.htmlStatusBars[index] == null)
			this.htmlStatusBars[index] = _getElementById(this.grid.name + "~statusbar" + index);
		return this.htmlStatusBars[index];
	}

	this.GetHtmlHeader = function (internalColumnIndex){	
		var headerPanel = this.GetHtmlHeaderPanel();
		if(headerPanel != null){
			if(internalColumnIndex >= this.grid.GetLeftRowBtnColumnsOffset() + this.grid.groupColumns.length)
				internalColumnIndex -= this.grid.groupColumns.length;
			return _getChildByTagNameEx(headerPanel, "TD", internalColumnIndex, false);
		}
		return null;
	}
	
	this.GetHtmlSynchHeader = function (internalColumnIndex){	
		var synchHeaderPanel = this.GetHtmlSynchHeaderPanel();
		if(synchHeaderPanel != null){
			if(internalColumnIndex >= this.grid.GetLeftRowBtnColumnsOffset() + this.grid.groupColumns.length)
				internalColumnIndex -= this.grid.groupColumns.length;
			return _getChildByTagNameEx(synchHeaderPanel, "TD", internalColumnIndex, false);
		}
		return null;
	}

	this.GetHtmlGroupHeader = function (index){	
		var groupPanel = this.GetHtmlGroupPanel();
		if(groupPanel != null){
			var table1 = _getChildByTagNameEx(groupPanel, "TABLE", 0, true);
			var td1 = _getChildByTagNameEx(table1, "TD", 1, true);
			var table2 = _getChildByTagNameEx(td1, "TABLE", 0, true);
			return _getChildByTagNameEx(table2, "TD", index, true);
		}
		return null;
	}

	this.GetHtmlButtonBar = function (){	
		if(this.htmlButtonBar == null)
			this.htmlButtonBar = _getElementById(this.grid.name + "buttonbar");
		return this.htmlButtonBar;
	}		

	this.GetHtmlFooterCell = function (internalColumnIndex){	
		var footer = this.GetHtmlFooter();
		if(footer != null){
			if(internalColumnIndex >= this.grid.GetLeftRowBtnColumnsOffset() + this.grid.groupColumns.length)
				internalColumnIndex -= this.grid.groupColumns.length;
			return footer.cells[internalColumnIndex];
		}
		return null;
	}
	
	this.GetHtmlVertScrollArea = function(){
		if(this.htmlVertScrollArea == null)
			this.htmlVertScrollArea = _getElementById(this.grid.name + "vertscrollarea");
		return this.htmlVertScrollArea;
	}

	this.Initialize = function(){
		this.htmlFrameTable = null;
		this.htmlGridTable = null;
		this.htmlRows = null;
		this.htmlItems = null;
		this.htmlHeaderPanel = null;
		this.htmlTitle = null;
		this.htmlGroupPanel = null;
		this.htmlSearchItem = null;
		this.htmlFooter = null;
		this.htmlEmptySpace = null;
		this.htmlSynchSpace = null;
		this.htmlScroller = null;
		this.htmlVertScroller = null;
		this.htmlSynchHeaderPanel = null;
		this.htmlSynchSearchItem = null;
		this.htmlSynchFooter = null;
		this.htmlStatusBars = new Array();	
		this.htmlButtonBar = null;
		this.htmlVertScrollArea = null;

		if(this.IsVertScrollBarShown() && !this.grid.processOnServer){
			this.InitializeScroller();
		}
		if(this.grid.IsServerSideRender()){
			var items = this.GetHtmlRows();		
			if(items != null){		
				var firstTROffset = this.GetFirstTROffset();
				var processedTRCount = 0;
				for(var i = 0; i < this.grid.GetTRCount(); i ++){				
					var row = this.grid.GetVisibleRow(this.GetFirstVisibleIndex() + i);
					var showPreviewRow = this.RowHasPreview(row);
					var tr = items.rows[firstTROffset + processedTRCount];				
					this.InitializeTrInfo(tr, row, false);
					processedTRCount ++;
					if(showPreviewRow){
						tr = items.rows[firstTROffset + processedTRCount];			
						this.InitializeTrInfo(tr, row, true);
						processedTRCount ++;
					}
				}
			}
		}
		this.initialized = true;
	}
	this.InitializeScroller = function() {
		if(this.nativeScrolling){			
			var scroller = this.GetHtmlVertScroller();
			if(scroller != null)
				scroller.style.width = _getScrollBarWidth() + 1;
		}
		else{
			if(this.grid.GetPageSize() > 0 && !opera){
				var scroller = this.GetVertScrollBar();						
				if(scroller != null){
					scroller.ThumbMove.AddHandler(new Function("OnScroll(\"" + this.grid.GetName() + "\")"));
					scroller.IncButtonClick.AddHandler(OnScrlrIncBtnCl);
					scroller.DecButtonClick.AddHandler(OnScrlrDecBtnCl);						
					scroller.LargeIncButtonClick.AddHandler(OnScrlrLargeIncBtnCl);
					scroller.LargeDecButtonClick.AddHandler(OnScrlrLargeDecBtnCl);
					scroller.CheckInitialized();
					scroller.CheckRenderInitialized();
				}
			}
			else {
				var scroller = this.GetVertScrollBar();						
				if(scroller != null){
					scroller.ThumbMove.ClearHandlers();
					scroller.IncButtonClick.ClearHandlers();
					scroller.DecButtonClick.ClearHandlers();
					scroller.LargeIncButtonClick.ClearHandlers();
					scroller.LargeDecButtonClick.ClearHandlers();
				}
			}
		}
	}

	this.GetEditRowHeight = function(){
		return !this.editRowHeight.IsEmpty() ? this.editRowHeight : this.grid.GetItemHeight();
	}
	this.GetHeaderHeight = function(){
		return !this.headerHeight.IsEmpty() ? this.headerHeight : this.grid.GetItemHeight();
	}
	this.GetFooterHeight = function(){
		return !this.footerHeight.IsEmpty() ? this.footerHeight : (!this.grid.GetItemHeight().IsEmpty() && this.grid.GetItemHeight().type != "%" ? this.grid.GetItemHeight().ConvertToPx().Inc(4) : this.grid.GetItemHeight());
	}
	this.GetSearchItemHeight = function(){
		return !this.searchItemHeight.IsEmpty() ? this.searchItemHeight : (!this.grid.GetItemHeight().IsEmpty() && this.grid.GetItemHeight().type != "%" ? this.grid.GetItemHeight().ConvertToPx().Inc(3) : this.grid.GetItemHeight());
	}

	this.IsFocusedRow = function(row){
		return row == this.grid.GetFocusedRow();
	}
	this.IsEditRow = function(row){
		return this.grid.IsEditMode() && this.IsFocusedRow(row);
	}
	this.GetFirstVisibleIndex = function(){
		return (this.grid.GetFirstVisibleIndexInternal() > -1) ? this.grid.GetFirstVisibleIndexInternal() : 0;
	}
	this.GetLastVisibleIndex = function(){
		return this.grid.GetLastVisibleIndexInternal();
	}
	
	this.GetClassName = function(className){
		return this.grid.scriptName + className;
	}
	
	this.FireCustomRenderBeforeDefaultRender = function(){
		return this.fireCustomRenderEvents == "BeforeStandardRender" || this.fireCustomRenderEvents == "Both";
	}
	this.FireCustomRenderAfterDefaultRender = function(){
		return this.fireCustomRenderEvents == "BeforeDefaultRender" || this.fireCustomRenderEvents == "Both";
	}	

	this.InstantiateTemplate = function(td, template){
		var templateTD = _getChildByTagName(template, "TD", 0);
		for(var i = 0; i < templateTD.childNodes.length; i ++){
			var templateControl = templateTD.childNodes[i].cloneNode(true);
			td.appendChild(templateControl);
		}
	}

	this.CustomRenderCell = function(td, column, width, height, beforeDefaultRender){
		if(!column.CustomRenderCell.IsEmpty() || !this.grid.CustomRenderCell.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderCellEventArgs(td, column, width, height, beforeDefaultRender);
			column.CustomRenderCell.FireEvent(column, eventArgs);			
			if(!eventArgs.handled)
				this.grid.CustomRenderCell.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.CreateDataTDContent = function(td, column, isOdd){		
		var width = column.GetWidth();
		var height = this.grid.GetItemHeight();
		var itemTemplate = column.itemTemplate;
		if(itemTemplate != null)
			this.InstantiateTemplate(td, itemTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
			handled = this.CustomRenderCell(td, column, width, height, true);				
		var editor = column.GetEditor();
		if(!handled && itemTemplate == null && editor != null){
			if(!this.grid.directRender){
				width = column.GetCellWidth();
				if(height.type == "%")
					height = ASPxClientUnit.GetHundredPercentUnit();
				editor.ShowEditor(td, false, isOdd, width, height);
			}			
		}
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderCell(td, column, width, height, false);
	}

	this.CustomRenderEditCell = function(td, column, width, height, beforeDefaultRender){
		if(!column.CustomRenderEditCell.IsEmpty() || !this.grid.CustomRenderEditCell.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderCellEventArgs(td, column, width, height, beforeDefaultRender);
			column.CustomRenderEditCell.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.CustomRenderEditCell.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.CreateEditTDContent = function(td, column, isOdd){
		var width = column.GetWidth();
		var height = this.GetEditRowHeight();
		var editItemTemplate = column.editItemTemplate;
		if(editItemTemplate != null)
			this.InstantiateTemplate(td, editItemTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
			handled = CustomRenderEditCell(td, column, width, height, true);
		var editor = column.GetEditor();
		if(!handled && editItemTemplate == null && editor != null){
			width = column.GetCellWidth();
			if(height.type == "%")
				height = ASPxClientUnit.GetHundredPercentUnit();
			editor.ShowEditor(td, !this.grid.IsColumnReadOnly(column), isOdd, width, height);
		}
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderEditCell(td, column, width, height, false);
	}
	
	this.CustomRenderPreview = function(td, width, height, beforeDefaultRender){
		if(!this.grid.CustomRenderPreview.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderEventArgs(td, width, height, beforeDefaultRender);
			this.grid.CustomRenderPreview.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.CreatePreviewTDContent = function(td, width, height){
		var previewTemplate = this.grid.previewTemplate;
		if(previewTemplate != null)
			this.InstantiateTemplate(td, previewTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
			handled = this.CustomRenderPreview(td, width, height, true);
		if(!handled && previewTemplate == null){
			if(!this.grid.directRender){
				var div = document.createElement("DIV");
				td.appendChild(div);
				div.style.overflow = "hidden";
				if(!height.IsEmpty() && height.type == "px")
					div.style.height = height.ToString();
				div.style.width = width.ToString();
				div.style.paddingLeft = horzTextPadding;
				div.style.paddingRight = horzTextPadding;
				_setCursor(div, "default");
			}
		}
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderPreview(td, width, height, false);
	}
	
	this.CustomRenderRowBtn = function(td, column, rowButton, inHeaderPanel, width, height, imageUrl, beforeDefaultRender){
		if(column.type != "IndicatorColumn" && !column.CustomRenderRowBtn.IsEmpty() || !this.grid.CustomRenderRowBtn.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderRowBtnEventArgs(td, column, rowButton, inHeaderPanel, width, height, imageUrl, beforeDefaultRender);
			if(column.type != "IndicatorColumn")
				column.CustomRenderRowBtn.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.CustomRenderRowBtn.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.ApplyRowBtnCustomRender = function(td, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled){	
		var rowBtnTemplate = column.type != "IndicatorColumn" ? column.rowBtnTemplate : this.grid.rowBtnTemplate;
		if(rowBtnTemplate != null)
			this.InstantiateTemplate(td, rowBtnTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
			handled = this.CustomRenderRowBtn(td, column, rowButton, inHeaderPanel, width, height, imageUrl, true);		
		return handled || rowBtnTemplate != null;
	}
	
	this.CustomBindRowBtn = function(td, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled){	
		var rowBtnTemplate = column.type != "IndicatorColumn" ? column.rowBtnTemplate : this.grid.rowBtnTemplate;
		var handled = false;
		if(column.type != "IndicatorColumn" && !column.BindRowBtn.IsEmpty() || !this.grid.BindRowBtn.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderRowBtnEventArgs(td, column, rowButton, inHeaderPanel, width, height, imageUrl);
			if(column.type != "IndicatorColumn")
				column.BindRowBtn.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.BindRowBtn.FireEvent(this.grid, eventArgs);
			handled = eventArgs.handled;
		}
		return handled || rowBtnTemplate != null;
	}

	this.CreateRowBtnTDContent = function(td, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled, toolTip){	
		var registerId = this.grid.name + (column.type == "IndicatorColumn" ? (inHeaderPanel ? "RIHD" : "RI") : ((inHeaderPanel ? "RBH" : "RB") + column.index));
		if(GetLookAndFeelStyleCollection().Get(GetStyleName(registerId)) == null){		
			var btnStyle = inHeaderPanel ? column.GetResolvedHeaderStyle() : column.GetResolvedItemStyle();
			this.CreateBtnStyles(registerId, btnStyle, this.grid.rowBtnHotTrackStyle, this.grid.rowBtnPressedStyle);
		}
		var templateContainer = null;
		if(this.instantiateTemplatesInButtons || !this.ApplyRowBtnCustomRender(td, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled)){			
			var customRender = false;
			if(this.instantiateTemplatesInButtons){
				templateContainer = document.createElement("TD");
				customRender = this.ApplyRowBtnCustomRender(templateContainer, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled);			
			}				
			if(customRender)
				CreateLFButton(td, "", registerId, this.grid.lookAndFeel, true, templateContainer, null, "", "", "", "", enabled, toolTip, null, ASPxClientUnit.GetHundredPercentUnit(), ASPxClientUnit.GetHundredPercentUnit());
			else
				CreateLFButton(td, "", registerId, this.grid.lookAndFeel, true, null, null, imageUrl, "", "", "", enabled, toolTip, null, ASPxClientUnit.GetHundredPercentUnit(), ASPxClientUnit.GetHundredPercentUnit());
		}
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderRowBtn(this.instantiateTemplatesInButtons ? templateContainer : td, column, rowButton, inHeaderPanel, width, height, imageUrl, false);	
	}
	
	this.InitializeRowBtnTDContent = function(td, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled, toolTip, initializeDefault){	
		var registerId = this.grid.name + (column.type == "IndicatorColumn" ? (inHeaderPanel ? "RIHD" : "RI") : ((inHeaderPanel ? "RBH" : "RB") + column.index));
		if(this.instantiateTemplatesInButtons || !this.CustomBindRowBtn(td, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled)){
			var templateContainer = null;
			var customBind = false;
			if(this.instantiateTemplatesInButtons){
				templateContainer = document.createElement("TD");
				customBind = this.CustomBindRowBtn(templateContainer, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled);			
			}				
			if(!customBind && initializeDefault)
				InitializeLFButton(td, "", registerId, this.grid.lookAndFeel, true, null, null, imageUrl, "", "", "", enabled, toolTip, null, ASPxClientUnit.GetHundredPercentUnit(), !ie ? height : ASPxClientUnit.GetHundredPercentUnit());
		}
	}

	this.CustomRenderExpandBtn = function(td, rowExpanded, width, height, beforeDefaultRender){
		if(!this.grid.CustomRenderExpandBtn.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderExpandBtnEventArgs(td, rowExpanded, width, height, beforeDefaultRender);
			this.grid.CustomRenderExpandBtn.FireEvent(this.grid, eventArgs);
			handled = eventArgs.handled;
		}
	}

	this.ApplyExpandBtnCustomRender = function(td, rowExpanded, width, height){
		var expandBtnTemplate = this.grid.expandBtnTemplate;
		if(expandBtnTemplate != null)
			this.InstantiateTemplate(td, expandBtnTemplate);
		var handled = false;
 		if(this.FireCustomRenderBeforeDefaultRender())
 			handled = this.CustomRenderExpandBtn(td, rowExpanded, width, height, true);
		return handled || expandBtnTemplate != null;
	}
	
	this.CustomBindExpandBtn = function(td, rowExpanded, width, height){
		var expandBtnTemplate = this.grid.expandBtnTemplate;
		var handled = false;
		if(!this.grid.BindExpandBtn.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderExpandBtnEventArgs(td, rowExpanded, width, height);
			this.grid.BindExpandBtn.FireEvent(this.grid, eventArgs);
			handled = eventArgs.handled;
		}
		return handled || expandBtnTemplate != null;
	}

	this.CreateExpandBtnTDContent = function(td, rowExpanded, width, height){
		var registerId = this.grid.name + "EB";
		if(GetLookAndFeelStyleCollection().Get(GetStyleName(registerId)) == null)
			this.CreateBtnStyles(registerId, this.grid.expandBtnStyle, this.grid.expandBtnHotTrackStyle, this.grid.expandBtnPressedStyle);
		var templateContainer = null;
		if(this.instantiateTemplatesInButtons || !this.ApplyExpandBtnCustomRender(td, rowExpanded, width, height)){			
			var customRender = false;
			if(this.instantiateTemplatesInButtons){
				templateContainer = document.createElement("TD");
				customRender = this.ApplyExpandBtnCustomRender(templateContainer, rowExpanded, width, height);			
			}		
			if(customRender)
				CreateLFButton(td, "", registerId, this.grid.lookAndFeel, true, templateContainer, null, "", "", "", "", this.grid.enabled, "", null, width, height);
			else
				CreateLFButton(td, "", registerId, this.grid.lookAndFeel, true, null, null, rowExpanded ? this.expandImages.GetImage("Collapse") : this.expandImages.GetImage("Expand"), "", "", "", this.grid.enabled, "", null, width, height);
		}
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderExpandBtn(this.instantiateTemplatesInButtons ? templateContainer : td, rowExpanded, width, height, false);	
	}
	
	this.InitializeExpandBtnTDContent = function(td, rowExpanded, width, height, initializeDefault){
		var registerId = this.grid.name + "EB";
		if(GetLookAndFeelStyleCollection().Get(GetStyleName(registerId)) == null)
			this.CreateBtnStyles(registerId, this.grid.expandBtnStyle, this.grid.expandBtnHotTrackStyle, this.grid.expandBtnPressedStyle);
		if(this.instantiateTemplatesInButtons || !this.CustomBindExpandBtn(td, rowExpanded, width, height)){
			var templateContainer = null;
			var customBind = false;
			if(this.instantiateTemplatesInButtons){
				templateContainer = document.createElement("TD");
				customBind = this.CustomBindExpandBtn(templateContainer, rowExpanded, width, height);			
			}		
			if(!customBind && initializeDefault)
				InitializeLFButton(td, "", registerId, this.grid.lookAndFeel, true, null, null, rowExpanded ? this.expandImages.GetImage("Collapse") : this.expandImages.GetImage("Expand"), "", "", "", true, "", null, width, height);
		}
	}
	
	this.CustomRenderGroupItem = function(td, column, width, height, beforeDefaultRender){
		if(!column.CustomRenderGroupItem.IsEmpty() || !this.grid.CustomRenderGroupItem.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderCellEventArgs(td, column, width, height, beforeDefaultRender);
			column.CustomRenderGroupItem.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.CustomRenderGroupItem.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.CreateGroupingTDContent = function(td, column, width, height){	
		var groupItemTemplate = column.groupItemTemplate;
		if(groupItemTemplate != null)
			this.InstantiateTemplate(td, groupItemTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
 			handled = this.CustomRenderGroupItem(td, column, width, height, true);
		if(!handled && groupItemTemplate == null){
			if(!this.grid.directRender){
				var div = document.createElement("DIV");
				td.appendChild(div);
				div.className = this.GetClassName("C" + column.index + "GIV");
				div.style.width = this.grid.GetGroupItemTextSectionWidth(column.groupIndex).ToString();
				_setCursor(div, "default");	
			}
		}
		if(this.FireCustomRenderAfterDefaultRender())
 			this.CustomRenderGroupItem(td, column, width, height, false);
	}
	
	this.CustomRenderFooter = function(td, column, width, height, text, beforeDefaultRender){
		if(!column.CustomRenderFooter.IsEmpty() || !this.grid.CustomRenderFooter.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderFooterEventArgs(td, column, width, height, text, beforeDefaultRender);
			column.CustomRenderFooter.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.CustomRenderFooter.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.CreateFooterTDContent = function(td, column, width, height, text){	
		var footerTemplate = column.footerTemplate;
		if(footerTemplate != null)
			this.InstantiateTemplate(td, footerTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
			handled = this.CustomRenderFooter(td, column, width, height, text, true);
		if(!handled && footerTemplate == null){
			var registerId = this.grid.name + "CF" + column.index;
			var style = GetLookAndFeelStyleCollection().Get(GetStyleName(registerId));
			if(style == null){
				var compositeStyle = column.footerStyle;
				style = this.CreateFooterStyle(registerId, compositeStyle);
			}
			if(this.borderCollapse){
				td.style.paddingLeft = 1;
			}
			else{
				if(width.type == "%" || !style.fixedWidth)
					td.style.paddingRight = 1;
			}
			CreateLFLabel(td, registerId, this.grid.lookAndFeel, true, true, text, 4, style.fixedWidth && width.type != "%" ? width : ASPxClientUnit.GetHundredPercentUnit(), height);
		}
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderFooter(td, column, width, height, text, false);
	}

	this.CreateSearchItemTDContent = function(td, column, width, height, synchronizationSample){	
		var btnRegisterId = this.grid.name + "SB";
		if(GetLookAndFeelStyleCollection().Get(GetStyleName(btnRegisterId)) == null)
			this.CreateBtnStyles(btnRegisterId, this.grid.searchBtnStyle, this.grid.searchBtnHotTrackStyle, this.grid.searchBtnPressedStyle);
		var button = CreateLFButton(null, this.grid.name + getSearchButtonMark() + column.index, btnRegisterId, this.grid.lookAndFeel, false, null, null, this.imgBtnSearch, "", "", "", this.grid.enabled, "", OnSBCl, this.searchBtnWidth, height);
		var editorRegisterId = this.grid.name + "SE";
		if(GetLookAndFeelStyleCollection().Get(GetStyleName(editorRegisterId)) == null)
			this.CreateEditorStyles(editorRegisterId, this.grid.searchEditorStyle);
		var value = "";
		var currentSearchColumnIndex = this.grid.searchColumnIndex;
		if(currentSearchColumnIndex >= 0 && column == this.grid.columns[currentSearchColumnIndex])
			value = this.grid.searchString;
		CreateLFEditor(td, editorRegisterId, this.grid.lookAndFeel, true, button, 
			(!synchronizationSample ? this.grid.name + getSearchEditorMark() + column.index : ""), "", value, "OnSEFocus(event)", "OnSEBlur(event)", null, 
			false, true, "", ASPxClientUnit.GetHundredPercentUnit(), ASPxClientUnit.GetHundredPercentUnit());		
	}

	this.GetRowBtnOnClick = function(rowBtnType){
		return new Function("event", "OnRBCl(event, \"" + rowBtnType + "\")");
	}

	this.NeedShowRowPreview = function(row){
		return this.showEmptyPreview || this.GetPreviewText(row) != "";
	}

	this.RowHasPreview = function(row){
		return this.grid.showPreview && !this.IsGroupRow(row);
	}

	this.InitializeRowBtnTD = function (td, column, rowButton, inHeaderPanel, onclick, width, height, showPreview, imageUrl, enabled, toolTip, create, initializeDefault){
		td.onclick = (this.grid.enabled && onclick != null) ? onclick : null;
		td.style.height = height.ToString();			
		td.style.width = width.ToString();
		td.rowSpan = showPreview ? 2 : 1;
		if(create){
			this.CreateRowBtnTDContent(td, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled, toolTip);
			if(!this.showGridLinesBetweenButtons)
				td.style.borderStyle = "none";
		}
		this.InitializeRowBtnTDContent(td, column, rowButton, inHeaderPanel, width, height, imageUrl, enabled, toolTip, initializeDefault && !create);
	}
	
	this.GetItemHeight = function(showPreview){
		return showPreview ? this.grid.GetItemHeight().Add(this.grid.GetPreviewHeight()) : this.grid.GetItemHeight();
	}
	
	this.CreateTRRowBtns = function (tr, row){
		var isEditRow = this.IsEditRow(row);
		var rowBtnColumnsBeginPos = this.grid.GetLeftRowBtnColumnsOffset();
		var rowBtnColumnsEndPos = this.grid.GetRightRowBtnColumnsOffset();

		var isGroupRow = this.IsGroupRow(row);
		var showPreview = this.RowHasPreview(row) && this.NeedShowRowPreview(row);
		var rowHeight = isEditRow ? this.GetEditRowHeight() : this.grid.GetItemHeight();
		var rowBtnHeight = this.GetItemHeight(showPreview);
		for(var i = 0; i < rowBtnColumnsBeginPos; i ++){
			var td = document.createElement("TD");	
			var column = this.grid.internalColumns[i];
			switch(column.type){
			case "IndicatorColumn":
				this.InitializeRowBtnTD(td, column, this.IsFocusedRow(row) ? "Indicator" : "Empty", false, OnRBMoveToCl, column.GetWidth(), rowBtnHeight, showPreview, this.img1x1, this.grid.enabled, "", true, false);
				break;
			case "RowBtnColumn":			
				column.itemStyle.ApplyStyle(td, true);
				var btnType = isGroupRow ? "Empty" : (isEditRow ? column.editRowButton : column.rowButton);
				this.InitializeRowBtnTD(td, column, btnType, false, this.GetRowBtnOnClick(btnType), column.GetWidth(), rowBtnHeight, showPreview, this.rowBtnImages.GetImage(btnType), btnType != "Empty", this.rowBtnToolTips.GetToolTip(btnType), true, false);
				break;
			}
			tr.appendChild(td);
		}
		
		for(var i = rowBtnColumnsEndPos + 1; i < this.grid.internalColumns.length; i ++){
			var td = document.createElement("TD");		
			var column = this.grid.internalColumns[i];
			switch(column.type){
			case "RowBtnColumn":	
				column.itemStyle.ApplyStyle(td, true);
				var btnType = isGroupRow ? "Empty" : (isEditRow ? column.editRowButton : column.rowButton);
				this.InitializeRowBtnTD(td, column, btnType, false, this.GetRowBtnOnClick(btnType), column.GetWidth(), rowBtnHeight, showPreview, this.rowBtnImages.GetImage(btnType), btnType != "Empty", this.rowBtnToolTips.GetToolTip(btnType), true, false);
				break;
			}
			tr.appendChild(td);
		}
	}

	this.InsertTRCell = function(tr, td, offset){
		if(offset > 0)
			tr.insertBefore(td, tr.cells[tr.cells.length - offset]);
		else
			tr.appendChild(td);
			
	}

	this.CreatePreviewTRContent = function (tr, row, rowBtnColumnsBeginPos, rowBtnColumnsEndPos){
		var td = document.createElement("TD");	
		var internalColumnCount = this.grid.internalColumns.length;
		var rowBtnColumnCount = rowBtnColumnsBeginPos + (internalColumnCount - rowBtnColumnsEndPos - 1);
		td.colSpan = internalColumnCount - rowBtnColumnCount - this.grid.groupColumns.length;
		this.grid.GetResolvedPreviewStyle().ApplyFilterAttributes(td, true);
		this.CreatePreviewTDContent(td, this.grid.GetPreviewSectionWidth(), this.grid.GetPreviewHeight());
		tr.appendChild(td);			
	}
	
	this.CreateGroupingTRContent = function (tr, row, expandBtnTd, rowBtnColumnsBeginPos, rowBtnColumnsEndPos, insertCellOffset){
		expandBtnTd.id = this.grid.name + getExpandButtonMark() + row.id;
		if(this.grid.enabled)
			expandBtnTd.onclick = OnEBCl;			
		if(!ie)
			expandBtnTd.align="center";
		this.CreateExpandBtnTDContent(expandBtnTd, row.GetExpanded(), this.expandBtnWidth, this.expandBtnHeight);
		
		var td = document.createElement("TD");		
		this.InsertTRCell(tr, td, insertCellOffset);
		var groupingColumn = this.grid.groupColumns[row.GetLevel()];
		td.className = this.GetClassName("C" + groupingColumn.index + "GI");
		td.colSpan = rowBtnColumnsEndPos - rowBtnColumnsBeginPos - row.GetLevel();						
		this.CreateGroupingTDContent(td, groupingColumn, new ASPxClientUnit(0, ""), this.grid.GetItemHeight());
	}

	this.CreateDataTRContent = function (tr, row, isEditRow, lastUtilColumnIndex, rowBtnColumnsEndPos, insertCellOffset){		
		for(var i = lastUtilColumnIndex; i <= rowBtnColumnsEndPos; i++){
			var column = this.grid.internalColumns[i];
			var td = document.createElement("TD");		
			this.InsertTRCell(tr, td, insertCellOffset);
			td.id = i;						
			switch(column.type){				
			case "BoundColumn":
			case "TemplateColumn":
				if(this.IsEditCell(column, isEditRow))
					this.CreateEditTDContent(td, column, row.GetEvenOdd() == "Odd");
				else
					this.CreateDataTDContent(td, column, row.GetEvenOdd() == "Odd");
				break;				
			}	
			if(i == lastUtilColumnIndex)
				td.style.borderLeftColor = this.groupIndentBorderColor;
		}
	}
	
	this.IsLastRowInGroup = function(row, groupLevel, preview){
		var visibleIndex = row.GetVisibleIndex();
		if(visibleIndex < this.grid.GetVisibleRowCount() - 1 && this.grid.GetVisibleRow(visibleIndex + 1) != null)
			return this.grid.GetVisibleRow(visibleIndex + 1).GetLevel() <= groupLevel && (!this.NeedShowRowPreview(row) || preview);
		else
			return !this.NeedShowRowPreview(row) || preview;		
	}

	this.CreateEmptyImg = function(td){
		var img = document.createElement("IMG");
		img.src = this.img1x1;
		td.appendChild(img);
	}

	this.GetItemType = function(row, preview){
		if(preview)
			return "Preivew";
		if(this.IsGroupRow(row))
			return "GroupItem";
		if(this.IsEditRow(row))
			return "EditItem";
		return row.GetEvenOdd() == "Even" ? "Item" : "AlternatingItem";
	}
	
	this.IsGroupRow = function(row){
		return row.GetLevel() < this.grid.groupColumns.length;
	}

	this.CreateTRContent = function (tr, row, preview, createRowButtons){		
		var isEditRow = this.IsEditRow(row);
		if(this.disableSelection && (!isEditRow || preview))
			tr.onselectstart = new Function("event", "return OnTRSS(event);");
		else
			tr.onselectstart = null;			
		if(createRowButtons)
			this.CreateTRRowBtns(tr, row);
		var rowBtnColumnsBeginPos = this.grid.GetLeftRowBtnColumnsOffset();
		var rowBtnColumnsEndPos = this.grid.GetRightRowBtnColumnsOffset();	
		var insertCellOffset = !preview ? this.grid.internalColumns.length - rowBtnColumnsEndPos - 1 : 0;
		var isGroupRow = this.IsGroupRow(row);
		var lastUtilColumnIndex = !preview ? rowBtnColumnsBeginPos + row.GetLevel() + (isGroupRow ? 1 : 0) : this.grid.groupColumns.length;
		var firstIndentColumnIndex = !preview ? rowBtnColumnsBeginPos : 0;
		for(var i = firstIndentColumnIndex; i < lastUtilColumnIndex; i ++){
			var td = document.createElement("TD");	
			if(i == firstIndentColumnIndex && !(opera && this.showGridLinesBetweenButtons))
				td.style.borderLeftStyle = "none";
			this.InsertTRCell(tr, td, insertCellOffset);
			if(i < lastUtilColumnIndex - 1 || !isGroupRow)
				this.CreateEmptyImg(td);
		}		
		if(!preview){									
			if(isGroupRow)				
				this.CreateGroupingTRContent(tr, row, td, rowBtnColumnsBeginPos, rowBtnColumnsEndPos, insertCellOffset);		
			else
				this.CreateDataTRContent(tr, row, isEditRow, lastUtilColumnIndex, rowBtnColumnsEndPos, insertCellOffset);
		}
		else{
			this.CreatePreviewTRContent(tr, row, rowBtnColumnsBeginPos, rowBtnColumnsEndPos);
		}
	}

	this.ClearTR = function (tr, firstColumnIndex, lastColumnOffset, clearRowButtons){
		if(clearRowButtons){
			firstColumnIndex = 0;
			lastColumnOffset = 1;
		}
		if(lastColumnOffset >= 1){
			for(var i = tr.cells.length - lastColumnOffset; i >= firstColumnIndex; i --){
				tr.removeChild(tr.cells[i]);
			}
		}
	}
	
	this.CreateTR = function (items, row, position){
		var tr = document.createElement("TR");	
		if(position < items.rows.length)
			items.insertBefore(tr, items.rows[position]);
		else
			items.appendChild(tr);
					
		if(this.grid.enabled){
			tr.onclick = OnTRCl;
			tr.ondblclick = OnTRDblCl;
		}
	
		tr.initialized = false;
		
		return tr;
	}

	this.InitializeTrInfo = function(tr, row, preview){
		tr.rowVisibleIndex = row.GetVisibleIndex();
		tr.level = row.GetLevel();
		tr.expanded = row.GetExpanded();
		tr.preview = preview;
		tr.initialized = true;
	}

	this.CorrectTDBorders = function(td, topOffset, bottomOffset){
		if(this.showRowsTable || this.showItemsTable){			
			var tr = _getParentNode(td);
			var table = _getParentNode(_getParentNode(tr));
			if(tr.rowIndex == topOffset){
				td.savedBorderTopWidth = td.style.borderTopWidth;
				td.style.borderTopWidth = 0;
			}				
			else{
				if(typeof(td.savedBorderTopWidth) != "undefined" && td.savedBorderTopWidth != "restored"){
					td.style.borderTopWidth = td.savedBorderTopWidth;
					td.savedBorderTopWidth = "restored";
				}
			}
			
			if(tr.rowIndex == table.rows.length - bottomOffset){
				td.savedBorderBottomWidth = td.style.borderBottomWidth;
				td.style.borderBottomWidth = 0;
			}				
			else{
				if(typeof(td.savedBorderBottomWidth) != "undefined" && td.savedBorderBottomWidth != "restored"){
					td.style.borderBottomWidth = td.savedBorderBottomWidth;
					td.savedBorderBottomWidth = "restored";
				}
			}			
		}
	}
	
	this.CorrectTRBorders = function(tr, row, topOffset, bottomOffset){
		if(this.showRowsTable || this.showItemsTable){						
			var table = _getParentNode(_getParentNode(tr));		
			var isFirstTR = tr.rowIndex == topOffset;
			var isLastTR = tr.rowIndex == table.rows.length - bottomOffset - 1;
			for(var i = 0; i < tr.cells.length; i ++){
				if(isFirstTR){
					if(typeof(tr.cells[i].savedBorderTopWidth) == "undefined" || tr.cells[i].savedBorderTopWidth == "restored"){
						tr.cells[i].savedBorderTopWidth = tr.cells[i].style.borderTopWidth;
						tr.cells[i].style.borderTopWidth = 0;
					}
				}				
				else{
					if(typeof(tr.cells[i].savedBorderTopWidth) != "undefined" && tr.cells[i].savedBorderTopWidth != "restored"){
						tr.cells[i].style.borderTopWidth = tr.cells[i].savedBorderTopWidth;
						tr.cells[i].savedBorderTopWidth = "restored";
					}
				}				
			}			
		}
		if(row != null && this.IsGroupRow(row)){
			this.CorrectGroupTRBorders(this.GetGroupingTD(tr, row.GetLevel()), row, isLastTR, false);
			this.CorrectGroupTRBorders(this.GetExpandBtnTD(tr, row), row, isLastTR, true);
		}
	}

	this.InternalInvalidateRow = function (tr, row, preview, recreate, isLastTR){			
		var firstColumnOffset = this.grid.GetLeftRowBtnColumnsOffset();
		var lastColumnIndex = this.grid.GetRightRowBtnColumnsOffset();
		var lastColumnOffset = this.grid.internalColumns.length - lastColumnIndex;
	
		var recreateRow = recreate || !tr.initialized || tr.level != (row.GetLevel() + this.grid.groupingCorrection) || tr.preview != preview;
		var recreateRowBtns = recreateRow && !preview && (!tr.initialized || tr.preview);
		var initializeExpandBtn = !recreateRow && (tr.expanded != row.GetExpanded());
		if(recreateRow){			
			if(tr.initialized)
				this.ClearTR(tr, tr.preview ? 0 : firstColumnOffset, tr.preview ? 1 : lastColumnOffset, preview && !tr.preview);
			this.CreateTRContent(tr, row, preview, recreateRowBtns);						
			if(this.grid.internalColumns[0].type == "IndicatorColumn")
				this.SetIndicatorUnfocused(tr.cells[0], preview);
		}
		else{
			var selectedTRIndex = array_indexOf(this.selectedTRs, tr);
			if(selectedTRIndex >= 0){
				this.UnselectTR(tr);
				array_removeAt(this.selectedTRs, selectedTRIndex);
		}
		if(this.focusedTR == tr)
			this.HideFocus();
		}
		this.InitializeTrInfo(tr, row, preview);		
		
		var isGroupRow = this.IsGroupRow(row);
		if(this.grid.groupColumns.length > 0){
			var lastGroupingIndentIndex = row.GetLevel() + (isGroupRow ? 1 : 0);
			for(var i = 0; i < lastGroupingIndentIndex; i ++){
				var td = tr.cells[i + (!preview ? firstColumnOffset : 0)];
				var className = this.GetClassName((isGroupRow && i == row.GetLevel() ? (row.GetExpanded() ? "EE" : "EC") : (this.IsLastRowInGroup(row, i, preview) ? "GL" : "GI")));
				if(!this.applyGroupIndentStyleDirectly){
					td.className = className;
				}
				else{
					var registerId = className;
					if(GetLookAndFeelStyleCollection().Get(GetStyleName(registerId)) == null)
						this.CreateGroupIndentStyles();
					GetLookAndFeelStyleCollection().Get(GetStyleName(registerId)).ApplyStyle(td);
				}
			}
		}
		if(!preview){							
			var isEditRow = this.IsEditRow(row);
			var showPreview = this.RowHasPreview(row) && this.NeedShowRowPreview(row);
			var rowBtnHeight = this.GetItemHeight(showPreview);
			for(var i = 0; i < firstColumnOffset; i ++){
				var td = tr.cells[i];
				var column = this.grid.internalColumns[i];
				switch(column.type){
				case "IndicatorColumn":
					if(this.grid.BindRowBtn.IsEmpty()){						
						td.rowSpan = showPreview ? 2 : 1;
						td.style.height = rowBtnHeight.ToString();
					}
					else{
						this.InitializeRowBtnTD(td, column, this.IsFocusedRow(row) ? "Indicator" : "Empty", false, OnRBMoveToCl, column.GetWidth(), this.grid.GetItemHeight(), showPreview, this.imgIndicator, this.grid.enabled, "", false, !recreateRowBtns);
					}
					break;
				case "RowBtnColumn":
					var btnType = isGroupRow ? "Empty" : (isEditRow ? column.editRowButton : column.rowButton);
					this.InitializeRowBtnTD(td, column, btnType, false, this.GetRowBtnOnClick(btnType), column.GetWidth(), this.grid.GetItemHeight(), showPreview, this.rowBtnImages.GetImage(btnType), btnType != "Empty", this.rowBtnToolTips.GetToolTip(btnType), false, !recreateRowBtns);
					break;
				}				
			}						
			for(var i = 1; i < lastColumnOffset; i ++){
				var td = tr.cells[tr.cells.length - i];
				var column = this.grid.internalColumns[this.grid.internalColumns.length - i];
				var btnType = isGroupRow ? "Empty" : (isEditRow ? column.editRowButton : column.rowButton);
				this.InitializeRowBtnTD(td, column, btnType, false, this.GetRowBtnOnClick(btnType), column.GetWidth(), this.grid.GetItemHeight(), showPreview, this.rowBtnImages.GetImage(btnType), btnType != "Empty", this.rowBtnToolTips.GetToolTip(btnType), false, !recreateRowBtns);
			}
			if(isGroupRow){
				tr.id = this.grid.name + this.grid.GetRowIdPrefix(row) + row.id;	
				var style = this.grid.GetResolvedGroupItemStyle();
				style.ApplyStyle(tr, true);
				this.FillGroupingRow(tr, row, initializeExpandBtn, isLastTR);
			}
			else{				
				tr.id = this.grid.name + getDataRowMark() + row.id;		
				var style = row.GetEvenOdd() == "Even" ? this.grid.GetResolvedItemStyle() : this.grid.GetResolvedAltItemStyle();
				style.ApplyStyle(tr, true);
				this.FillDataRow(tr, row, this.IsEditRow(row));
			}	
			tr.style.height = this.grid.GetItemHeight().ToString();
		}
		else{			
			if(this.NeedShowRowPreview(row)){
				tr.id = this.grid.name + getDataRowMark() + row.id + getPreviewRowMark();		
				this.grid.GetResolvedPreviewStyle().ApplyStyle(tr, true);
				tr.style.height = this.grid.GetPreviewHeight().ToString();
				this.FillPreviewRow(tr, row);
			}
			else{
				tr.style.display = "none";
			}
		}
		
		if(!row.GetVisible())
			tr.style.display = "none";
			
		if(!this.grid.ItemRendered.IsEmpty()){
			var eventArgs = new ASPxClientGridItemEventArgs(tr, this.GetItemType(row), row);
			this.grid.ItemRendered.FireEvent(this.grid, eventArgs);
		}	
	}

	this.FillPreviewTD = function(td, row, value){
		var handled = false;
		if(!this.grid.BindPreview.IsEmpty()){
			var eventArgs = new ASPxClientGridBindEventArgs(td, row, value);
			this.grid.BindPreview.FireEvent(this.grid, eventArgs);
			handled = eventArgs.handled;
		}
		if(!handled && this.grid.previewTemplate == null){
			var element = !this.grid.directRender ? td.firstChild : td;
			if(this.grid.IsHtmlTagsInValuesEnabled())
				_setElementInnerHTML(element, value);
			else
				_setElementInnerText(element, value);
		}
	}

	this.GetPreviewText = function(row){
		return FormatValue(row.GetDataControllerRow().GetValue(this.grid.previewFieldIndex), "", "");
	}

	this.GetPreviewValue = function(row){
		var value = this.GetPreviewText(row);
		if(this.previewMaxLength > 0 && value.length > this.previewMaxLength)
			value = value.substr(0, this.previewMaxLength);
		return value;
	}

	this.FillPreviewRow = function (tr, row){	
		var td = _getLastChild(tr);
		this.FillPreviewTD(td, row, this.GetPreviewValue(row));
		if(!this.borderCollapse){
			if(this.grid.groupColumns.length == 0)	
				td.style.borderLeftStyle = "none";	
			td.style.borderTopStyle = "none";	
		}
	}

	this.FillGroupingTD = function (td, column, row, text){	
		var handled = false;
		if(!column.BindGroupingCell.IsEmpty() || !this.grid.BindGroupingCell.IsEmpty()){
			var eventArgs = new ASPxClientGridBindCellEventArgs(td, column, row, text);
			column.BindGroupingCell.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.BindGroupingCell.FireEvent(this.grid, eventArgs);
			handled = eventArgs.handled;
		}
		if(!handled && column.groupItemTemplate == null){
			var element = !this.grid.directRender ? td.firstChild : td;
			if(this.grid.IsHtmlTagsInValuesEnabled())
				_setElementInnerHTML(element, text);
			else
				_setElementInnerText(element, text);
		}
	}

	this.GetGroupingText = function(row, groupingColumn){
		var groupingValue = row.GetDataControllerRow().GetValue(groupingColumn.fieldIndex);
		var headerText = groupingColumn.headerText;
		var editor = groupingColumn.GetEditor();
		var valueText = (editor != null) ? editor.GetDisplayTextByValue(groupingValue) : FormatValue(groupingValue, "", groupingColumn.GetDataType());
		var summaryText = "";
		for(var i = 0; i < this.grid.groupSummary.length; i ++){
			if(i > 0)
				summaryText += ",";						
			summaryText += " " + this.grid.groupSummary[i].GetDisplayText(row.GetSummaryValueByIndex(i), true);
		}
		text = FormatString([headerText, valueText, summaryText], groupingColumn.groupFormatString, "");
		if(!this.grid.GetGroupingText.IsEmpty()){
			var e = new ASPxClientGridGetGroupingTextEventArgs(row, groupingColumn, groupingValue, text);
			this.grid.GetGroupingText.FireEvent(this.grid, e);
			text = e.groupingText;
		}
		return text;
	}

	this.GetExpandBtnTD = function(tr, row){
		return tr.cells[this.grid.GetLeftRowBtnColumnsOffset() + row.GetLevel()];
	}

	this.IsFollowedByDataRow = function(row){
		var visibleIndex = row.GetVisibleIndex();
		if(visibleIndex < this.grid.GetVisibleRowCount() - 1)
			return !this.IsGroupRow(this.grid.GetVisibleRow(visibleIndex + 1));
		else
			return false;		
	}
	
	this.NeedCorrectGroupTRBottonBorder = function(row){
		var rowIndex = row.GetVisibleIndex();
		var nextRowIndex = (rowIndex < this.grid.visibleRows.length - 1) ? this.grid.visibleRows[rowIndex + 1] : -1;
		var nextRow = (0 <= nextRowIndex && nextRowIndex < this.grid.rows.length) ? this.grid.rows[nextRowIndex] : null;
		return (nextRow != null) && row.GetLevel() > nextRow.GetLevel();
	}
	
	this.CorrectGroupTRBorders = function(groupingTd, row, isLastTR, isExpandBtnCell){
		if(this.correctGroupItemBorders){
			if(isExpandBtnCell){
				if(this.borderCollapse && ie && this.NeedCorrectGroupTRBottonBorder(row))
					groupingTd.style.borderBottomStyle = "solid";
			}
			else{
				groupingTd.style.borderLeftStyle = "none";	
				if(this.borderCollapse){
					if(ie){
						if(!isLastTR)
							groupingTd.style.borderBottomStyle = "none";	
						else
							groupingTd.style.borderBottomStyle = "solid";	
						if(this.NeedCorrectGroupTRBottonBorder(row))
							groupingTd.style.borderBottomStyle = "solid";	
					}
					if(ie)
						groupingTd.style.borderTopStyle = "solid";	
					else
						groupingTd.style.borderTopStyle = "none";	
				}
				else{
					if(ie){
						groupingTd.style.borderTopStyle = "none";					
						if(this.showGridLinesBetweenButtons && this.IsFollowedByDataRow(row))
							groupingTd.style.borderBottomStyle = "none";
					}
				}
			}
		}
	}

	this.FillGroupingRow = function (tr, row, initializeExpandButton, isLastTR){	
		var expandBtnTd = this.GetExpandBtnTD(tr, row);
		expandBtnTd.id = this.grid.name + getExpandButtonMark() + row.id;
		this.InitializeExpandBtnTDContent(expandBtnTd, row.GetExpanded(), this.expandBtnWidth, this.expandBtnHeight, initializeExpandButton);
	
		var groupingColumn = this.grid.groupColumns[row.GetLevel()];
		var groupingTd = this.GetGroupingTD(tr, row.GetLevel());
		this.FillGroupingTD(groupingTd, groupingColumn, row, this.GetGroupingText(row, groupingColumn));
	}

	this.FillDataRowTD = function(td, column, row, cellValue){
		var handled = false;
		if(!column.BindCell.IsEmpty() || !this.grid.BindCell.IsEmpty()){
			var eventArgs = new ASPxClientGridBindCellEventArgs(td, column, row, cellValue.value);
			column.BindCell.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.BindCell.FireEvent(this.grid, eventArgs);
			handled = eventArgs.handled;
		}
		var editor = column.GetEditor();
		if(!handled && column.itemTemplate == null && editor != null){
			if(!this.grid.directRender)
				editor.BindEditor(td.firstChild, row.GetDataControllerRow(), cellValue.value, false, cellValue.renderValueDirectly);
			else
				_setElementInnerText(td, cellValue.renderValueDirectly ? cellValue.value.toString() : editor.GetDisplayTextByValue(cellValue.value));
		}
	}

	this.FillEditRowTD = function(td, column, row, cellValue){
		var handled = false;
		if(!column.BindEditCell.IsEmpty() || !this.grid.BindEditCell.IsEmpty()){
			var eventArgs = new ASPxClientGridBindCellEventArgs(td, column, row, cellValue.value);
			column.BindEditCell.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.BindEditCell.FireEvent(this.grid, eventArgs);
			handled = eventArgs.handled;
		}
		var editor = column.GetEditor();
		if(!handled && column.editItemTemplate == null && editor != null)
			editor.BindEditor(td.firstChild, row.dataRow, cellValue.value, !this.grid.IsColumnReadOnly(column), cellValue.renderValueDirectly);
	}
	
	this.GetFirstDataColumnIndex = function(){
		return this.grid.groupColumns.length > 0 ? this.grid.GetLeftRowBtnColumnsOffset() + this.grid.groupColumns.length : -1;
	}

	this.GetColumnValue = function(column, row, isEditCell){
		var value = row.GetDataControllerRow().GetValue(column.fieldIndex);
		var handled = false;
		if((!column.GetCellValue.IsEmpty() || !this.grid.GetCellValue.IsEmpty())){
			var editor = column.GetEditor();
			if(editor != null && (!isEditCell && editor.EnableCustomViewValue() || isEditCell && editor.EnableCustomEditValue()) || this.grid.directRender && !isEditCell){
				var eventArgs = new ASPxClientGridGetCellValueEventArgs(column, row, value);
				column.GetCellValue.FireEvent(column, eventArgs);
				if(!eventArgs.handled)
					this.grid.GetCellValue.FireEvent(this.grid, eventArgs);
				handled = eventArgs.handled;
				if(handled)
					value = eventArgs.value;
			}
		}
		return new CellValue(value, handled);
	}

	this.IsEditCell = function(column, isEditRow){
		return isEditRow && (!this.grid.cellSelection || this.grid.postBackOnPostingDataChanges || this.grid.GetFocusedColumn() == column);
	}

	this.FillDataRow = function (tr, row, isEditRow){	
		var firstColumnOffset = this.grid.GetLeftRowBtnColumnsOffset();
		var lastColumnOffset = this.grid.GetRightRowBtnColumnsOffset();
		var firstDataColumnIndex = this.GetFirstDataColumnIndex();
		for(var i = firstColumnOffset; i <= lastColumnOffset; i ++){		
			var column = this.grid.internalColumns[i];		
			var td = tr.cells[i];
			switch(column.type){
				case "BoundColumn":
				case "TemplateColumn":	
					column.GetProperItemStyle(isEditRow, row.GetEvenOdd() == "Odd").ApplyStyle(td, true);
					var isEditCell = this.IsEditCell(column, isEditRow);
					var cellValue = this.GetColumnValue(column, row, isEditCell);
					if(isEditCell){
						this.FillEditRowTD(td, column, row, cellValue);
					}
					else{
						var editor = column.GetEditor();
						if(editor != null && !editor.AllowContentsCaching()){
							_clearElementChildren(td);
							this.CreateDataTDContent(td, column, row.GetEvenOdd() == "Odd");
						}
						this.FillDataRowTD(td, column, row, cellValue);				
					}
					break;
			}
			if(!this.showGridLinesBetweenButtons){								
				if(column.type != "GroupingIndentColumn"){
					if(i != firstDataColumnIndex)
						td.style.borderLeftStyle = "none";
				}
				td.style.borderTopStyle = "none";
			}
		}		
	}

	this.GetCustomEditValue = function(td, column, row){
		if(!column.GetEditValue.IsEmpty() || !this.grid.GetEditValue.IsEmpty()){
			var eventArgs = new ASPxClientGridGetEditValueEventArgs(td, column, row);
			column.GetEditValue.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.GetEditValue.FireEvent(this.grid, eventArgs);
			if(eventArgs.handled)
				return eventArgs.value;
		}
	}
	this.StoreColumnEditValue = function(column){
		if((column.type == "BoundColumn" || column.type == "TemplateColumn") && !column.readOnly){
			var row = this.grid.GetFocusedRow();
			var tr = this.GetTRByPos(this.GetHtmlRows(), this.grid.focusedPos);
			if(row != null && tr != null){
				var td = tr.cells[this.grid.GetColumnInternalIndex(column)];
				var editValue = this.GetCustomEditValue(td, column, row);
				if(typeof(editValue) != "undefined" && column.fieldIndex >= 0)
					row.GetDataControllerRow().SetValue(column.fieldIndex, ParseValue(editValue, column.editFormatString, column.GetDataType()));
				else {
					var editor = column.GetEditor();
					if(editor != null)
						return editor.InterimStoreEditValue();
				}
			}
		}
		return false;
	}
	this.ValidateColumnEditValue = function(column){
		if((column.type == "BoundColumn" || column.type == "TemplateColumn") && !column.readOnly){
			var row = this.grid.GetFocusedRow();
			var tr = this.GetTRByPos(this.GetHtmlRows(), this.grid.focusedPos);
			if(row != null && tr != null){
				var td = tr.cells[this.grid.GetColumnInternalIndex(column)];
				var editor = column.GetEditor();
				var editValue = this.GetCustomEditValue(td, column, row);
				if(typeof(editValue) == "undefined" && editor != null && editor.IsValueChanged())
					editValue = editor.GetEditValue();
				if(typeof(editValue) != "undefined"){
					var cancel = false;
					if(!this.grid.ValidateColumnValue.IsEmpty()){
						var args = new ASPxClientValidateColumnValueEventArgs(row, column, editValue);
						this.grid.ValidateColumnValue.FireEvent(this.grid, args);
						if(editor != null)
							editor.SetEditValue(args.value);
						cancel = args.cancel;
					}
					if(cancel){
						if(args.message != "")
							alert(args.message);
						if(editor != null)
							editor.FocusEditor();
						return false;
					}
				}
			}
		}
		return true;
	}

	this.StoreEditValues = function (){	
		var firstColumnOffset = this.grid.GetLeftRowBtnColumnsOffset();
		var lastColumnOffset = this.grid.GetRightRowBtnColumnsOffset();
		for(var i = firstColumnOffset; i <= lastColumnOffset; i ++)
			this.StoreColumnEditValue(this.grid.internalColumns[i]);
	}
	this.ValidateEditValues = function(){
		var firstColumnOffset = this.grid.GetLeftRowBtnColumnsOffset();
		var lastColumnOffset = this.grid.GetRightRowBtnColumnsOffset();
		for(var i = firstColumnOffset; i <= lastColumnOffset; i ++){
			if(!this.ValidateColumnEditValue(this.grid.internalColumns[i]))
				return false;
		}
		return true;
	}

	this.UpdateTotalWidth = function(){
		var width = this.grid.GetTotalWidth(false);
		for(var i = 0; i < this.grid.statusBars.length; i ++){
			this.grid.GetStatusBar(i).UpdateWidth(width);
		}		
		this.UpdateGroupPanelWidth(width);
		this.UpdateTitleWidth(width);
		if(!ie && this.IsScrollBarShown() && !this.IsHorzScrollBarShown() && width.type != "%")
			this.UpdateScrollerWidth(width);
	}	
	
	this.UpdateScrollerWidth = function(width){
		var scroller = this.GetHtmlScroller();
		
		if(scroller != null){
			if(!ie && (opera || this.grid.GetPageSize() == 0) && !this.IsHorzScrollBarShown())
				width = width.Add(this.GetScrollBarSize());
			scroller.style.width = width.ToString();
		}
	}
	
	this.InvalidateRows = function (recreate){		
		var items = this.GetHtmlRows();		
		if(items != null){		
			var firstTROffset = this.GetFirstTROffset(), lastTROffset = this.GetLastTROffset();		
			var totalTRCount = items.rows.length - firstTROffset - lastTROffset;
			var processedTRCount = 0;
			var focusedRow = this.grid.GetFocusedRow();
			var rowCount = this.grid.GetTRCount();
			for(var i = 0; i < rowCount; i ++){
				var row = this.grid.clientSideExpanding ? this.grid.GetRow(i) : this.grid.GetVisibleRow(this.GetFirstVisibleIndex() + i);
				var showPreviewRow = this.RowHasPreview(row);
				var missedTRCount = processedTRCount + (showPreviewRow ? 2 : 1) - totalTRCount;
				while(missedTRCount > 0){
					this.CreateTR(items, row, items.rows.length - lastTROffset);
					totalTRCount ++;
					missedTRCount --;
				}
				var tr = items.rows[firstTROffset + processedTRCount];								
				this.InternalInvalidateRow(tr, row, false, recreate == "All" || recreate == "Focused" && (row == focusedRow || tr == this.focusedTR), i == rowCount - 1 && !showPreviewRow);
				this.CorrectTRBorders(tr, row, firstTROffset, lastTROffset);
				processedTRCount ++;
				if(showPreviewRow){
					tr = items.rows[firstTROffset + processedTRCount];								
					this.InternalInvalidateRow(tr, row, true, recreate == "All", i == rowCount - 1);
					this.CorrectTRBorders(tr, row, firstTROffset, lastTROffset);
					processedTRCount ++;
				}
			}
			var extraTRCount = totalTRCount - processedTRCount;
			while(extraTRCount > 0){
				items.removeChild(items.rows[items.rows.length - lastTROffset - 1]);
				extraTRCount --;			
			}
		}	
		this.InvalidateEmptySpace();	
	}
	
	this.GetRowByTRIndex = function(trIndex){
		var groupCount = this.grid.groupColumns.length;
		if(!this.grid.showPreview || groupCount == 0)
			return this.grid.GetVisibleRow(this.GetFirstVisibleIndex() + trIndex / (this.grid.showPreview ? 2 : 1));
		var previewCount = 0;		
		var visibleRowCount = this.grid.GetVisibleRowCount(); 
		var rowIndex = this.GetFirstVisibleIndex();
		while(trIndex > 0){
			var row = this.grid.GetVisibleRow(rowIndex);	
			trIndex -= this.RowHasPreview(row) ? 2 : 1;
			if(trIndex >= 0)
				rowIndex ++;
		}
		return this.grid.GetVisibleRow(rowIndex);
	}
	
	this.InvalidateShiftedRows = function(direction){
		var items = this.GetHtmlRows();		
		if(items != null){					
			var firstTROffset = this.GetFirstTROffset(), lastTROffset = this.GetLastTROffset();		
			var totalTRCount = items.rows.length - firstTROffset - lastTROffset;
			if(this.grid.multiSelection){
				var selectedTRCount = this.selectedTRs.length;
				for(var i = 0, selectedTRIndex = direction ? 0 : selectedTRCount - 1; i < selectedTRCount; i ++){
					var tr = this.selectedTRs[selectedTRIndex];
					var index = tr.rowIndex - firstTROffset;
					if(direction ? index > 0 : index < totalTRCount - 1){
						this.savedSelectedColors[index + (direction ? -1 : 1)] = this.savedSelectedColors[index];
					}
					else{
						array_remove(this.selectedTRs, tr);
						if(direction)
							selectedTRIndex --;
					}
					this.savedSelectedColors[index] = null;
					selectedTRIndex += (direction ? 1 : -1);
				}
			}	
			for(var i = 0; i < this.selectedTRs.length; i ++){
				var tr = this.selectedTRs[i];
				var index = tr.rowIndex - firstTROffset;
				if(direction ? index == 0 : index == totalTRCount - 1)
					array_remove(this.selectedTRs, tr);
			}
			if(this.focusedTR != null){
				var index = this.focusedTR.rowIndex - firstTROffset;
				if(direction ? index == 0 : index == totalTRCount - 1)
					this.focusedTR = null;
			}			
			var removeIndex = direction ? 0 : totalTRCount - 1;			
			if(totalTRCount > 0){
				var tr = items.rows[firstTROffset + removeIndex];
				if(direction || totalTRCount > 1 && tr.preview){
					items.removeChild(tr);
					if(!direction)
						removeIndex --;
				}
				tr = items.rows[firstTROffset + removeIndex];
				if(!direction || totalTRCount > 1 && tr.preview)
					items.removeChild(tr);
			}			
			var insertIndex = direction ? items.rows.length - firstTROffset - lastTROffset : 0;
			var row = this.grid.GetVisibleRow(direction ? this.GetLastVisibleIndex() : this.GetFirstVisibleIndex());
			var tr = this.CreateTR(items, row, firstTROffset + insertIndex);
			var showPreviewRow = this.RowHasPreview(row);
			this.InternalInvalidateRow(tr, row, false, true, direction && !showPreviewRow);			
			if(showPreviewRow){
				insertIndex ++;
				tr = this.CreateTR(items, row, firstTROffset + insertIndex);
				this.InternalInvalidateRow(tr, row, true, true, direction);
			}
			this.CorrectTRBorders(tr, row, firstTROffset, lastTROffset);
			var correctionTRIndex = direction ? firstTROffset : items.rows.length - lastTROffset - 1;
			if(0 <= correctionTRIndex && correctionTRIndex < items.rows.length)
				this.CorrectTRBorders(items.rows[correctionTRIndex], this.GetRowByTRIndex(correctionTRIndex - firstTROffset), firstTROffset, lastTROffset);
			correctionTRIndex = !direction ? firstTROffset + (!showPreviewRow ? 1 : 2) : items.rows.length - lastTROffset - (!showPreviewRow ? 1 : 2) - 1;
			if(0 <= correctionTRIndex && correctionTRIndex < items.rows.length)
				this.CorrectTRBorders(items.rows[correctionTRIndex], this.GetRowByTRIndex(correctionTRIndex - firstTROffset), firstTROffset, lastTROffset);
		}					
	}

	this.InvalidateRow = function (row, recreate){
		var items = this.GetHtmlRows();	
		if(items != null){		
			var tr = this.GetTRByPos(items, this.grid.GetRowPos(row));
			if(tr != null){
				var isLastTR = tr.rowIndex == items.rows.length - 1 - this.GetLastTROffset();
				this.InternalInvalidateRow(tr, row, false, recreate, isLastTR);
				this.CorrectTRBorders(tr, row, this.GetFirstTROffset(), this.GetLastTROffset());
			}
		}
	}

	this.InvalidateEmptySpace = function (){	
		var htmlEmptySpace = this.GetHtmlEmptySpace();
		if(htmlEmptySpace != null){
			var pageSize = this.grid.GetPageSize();
			var emptyRowCount = (pageSize > 0 ? pageSize - (this.grid.GetVisibleRowCountInternal() - this.GetFirstVisibleIndex()) : 0);
			var emptySpaceHeight = 0;
			if(this.showEmptyRows && emptyRowCount > 0)
				emptySpaceHeight = this.grid.GetItemHeight().Mul(emptyRowCount).ToString();
			for(var i = 0; i < htmlEmptySpace.cells.length; i ++)
				_getFirstChild(htmlEmptySpace.cells[i]).style.height = emptySpaceHeight;
		}
	}

	this.GetGroupColumnHeaderWidth = function(column){
		if(!this.groupHeaderWidth.IsEmpty())
			return this.groupHeaderWidth;
		return column.GetWidth();
	}
	this.GetColumnHeaderWidth = function(column){
		var width = column.GetCellWidth();
		var groupingCount = this.grid.groupColumns.length;
		if(this.grid.GetColumnInternalIndex(column) == (this.grid.GetLeftRowBtnColumnsOffset() + groupingCount) && groupingCount > 0){
			width = width.ConvertToPx().Add(this.grid.groupRowIndent.ConvertToPx().Mul(groupingCount));
			if(!this.borderCollapse)
				width = width.Inc(1);
		}
		if(this.showGridLinesBetweenButtons && !this.BorderCollapse)
			width = width.Inc(-1);
		return width;
	}

	this.RecreateHeaders = function(headerPanel){			
		if(headerPanel != null){
			_clearElementChildren(headerPanel);
			for(var i = 0; i < this.grid.internalColumns.length; i ++){
				var column = this.grid.internalColumns[i];
				if(column.type != "GroupingIndentColumn"){
					var td = document.createElement("TD");
					td.style.width = this.GetColumnHeaderWidth(column).ToString();
					headerPanel.appendChild(td);
					switch(column.type){
						case "IndicatorColumn":
							this.InitializeRowBtnTD(td, column, "Empty", true, null, column.GetWidth(), this.GetHeaderHeight(), false, "", false, "", true, false);
							break;
						case "RowBtnColumn":						
							column.headerStyle.ApplyStyle(td, true);
							td.style.height = this.GetHeaderHeight().ToString();
							td.style.width = column.GetWidth().ToString();
							break;
						case "BoundColumn":
							td.id = this.grid.name + getColumnHeaderMark() + column.index;
							if(this.grid.enabled){
								td.onmousedown = OnHMDown;
								td.onmousemove = OnHMMove;
							}
							column.headerStyle.ApplyStyle(td, true);
							break;
					}
				}
			}
			this.CorrectTRBorders(headerPanel, null, 0, 1);
			this.InvalidateHeaderButtons();
		}
	}	

	this.RecreateSpace = function(space){
		var firstDataColumnIndex = this.GetFirstDataColumnIndex();
		var lastDataColumnIndex = this.grid.GetRightRowBtnColumnsOffset();
		_clearElementChildren(space);
		for(var i = 0; i < this.grid.internalColumns.length; i ++){
			var td = document.createElement("TD");
			var column = this.grid.internalColumns[i];
			var width = this.GetSpaceCellWidth(column.GetWidth(), i, firstDataColumnIndex, lastDataColumnIndex);
			td.style.width = width.ToString();
			td.style.borderWidth = 0;
			this.CreateEmptyImg(td);
			td.firstChild.style.width = width.type != "%" ? width.ToString() : "100%";
			td.firstChild.style.height = 0;
			space.appendChild(td);			
		}
	}

	this.GetRenderFooterText = function(column){
		var footerText = column.footerText;
		if(footerText != "")
			return footerText;
		if(column.summaryItem != null){
			var summaryValue = this.grid.GetSummaryValue(column.summaryItem);
			if(summaryValue != null)
				footerText = column.summaryItem.GetDisplayText(summaryValue, false);
			else
				footerText = "";
			return footerText;
		}
		return null;
	}
	
	this.InvalidateFooter = function(td, column, width, height){
		var footerText = this.GetRenderFooterText(column);
		if(footerText != null || this.footerMode == "All"){
			_clearElementChildren(td);
			var footerHeight = this.GetFooterHeight();			
			this.CreateFooterTDContent(td, column, width, height.type != "%" ? height.ConvertToPx().Inc(-4) : height, FormatValue(footerText, "", ""));
		}
	}

	this.RecreateFooterInternal = function(footer){
		if(footer != null){
			_clearElementChildren(footer);
			var footerHeight = this.GetFooterHeight();
			var footerLabelHeight = footerHeight.type != "%" ? footerHeight.ConvertToPx().Inc(-4) : footerHeight;
			for(var i = 0; i < this.grid.internalColumns.length; i ++){
				var column = this.grid.internalColumns[i];
				var td = document.createElement("TD");
				td.style.height = footerHeight.ToString();
				td.className = this.GetClassName("FC");
				this.grid.footerItemStyle.ApplyFilterAttributes(td, true);				
				footer.appendChild(td);
				switch(column.type){
					case "BoundColumn":
						this.InvalidateFooter(td, column, column.GetCellWidth(), footerHeight);
						break;
				}
			}
			this.CorrectTRBorders(footer, null, 0, 1);
		}
	}
	
	this.RecreateFooter = function(footer){
		this.RecreateFooterInternal(this.GetHtmlFooter());
	}

	this.InvalidateSearchItem = function(td, column, width, height, synchronizationSample){
		_clearElementChildren(td);
		this.CreateSearchItemTDContent(td, column, width, height.type != "%" ? height.ConvertToPx().Inc(-3) : height, synchronizationSample);
	}

	this.RecreateSearchItemInternal = function(searchItem, synchronizationSample){
		if(searchItem != null){
			_clearElementChildren(searchItem);
			var searchItemHeight = this.GetSearchItemHeight();
			for(var i = 0; i < this.grid.internalColumns.length; i ++){
				var column = this.grid.internalColumns[i];
				var td = document.createElement("TD");
				if(column.type == "BoundColumn" || column.type == "TemplateColumn")
					td.className = this.GetClassName("SI");
				searchItem.appendChild(td);
				switch(column.type){
					case "IndicatorColumn":
						this.InitializeRowBtnTD(td, column, "Empty", false, null, column.GetWidth(), searchItemHeight, false, this.img1x1, false, "", true, false);
						break;
					case "RowBtnColumn":	
						column.itemStyle.ApplyStyle(td, true);
						this.InitializeRowBtnTD(td, column, "Empty", false, null, column.GetWidth(), searchItemHeight, false, this.img1x1, false, "", true, false);
						break;
					case "GroupingIndentColumn":				
						td.className = this.GetClassName("GI");
						break;
					case "BoundColumn":
						if(column.enableSearchControl)
							this.InvalidateSearchItem(td, column, column.GetCellWidth(), searchItemHeight, synchronizationSample);
						else
							this.CreateEmptyImg(td);
						break;
				}
				if(!this.showGridLinesBetweenButtons)
					td.style.borderTopStyle = "none";
			}
			this.CorrectTRBorders(searchItem, null, 0, 1);
		}
	}
	
	this.RecreateSearchItem = function(){
		if(this.showSearchItem)
			this.RecreateSearchItemInternal(this.GetHtmlSearchItem(), false);
	}

	this.ColumnsRecreated = function(){
		var space = this.GetHtmlEmptySpace();
		if(space != null)
			this.RecreateSpace(space);
		var synchSpace = this.GetHtmlSynchSpace();
		if(synchSpace != null)
			this.RecreateSpace(synchSpace);
		if(this.showHeaders)
			this.RecreateHeaders(this.GetHtmlHeaderPanel());

		if(this.IsVertScrollBarShown() && !this.nativeScrolling){
			var vertScrollArea = this.GetHtmlVertScrollArea();
			if(vertScrollArea != null)
				_getParentNode(vertScrollArea).colSpan = this.grid.internalColumns.length;
		}
		if(!this.IsScrollBarShown()){
			if(this.showGroupPanel){
				var groupPanel = this.GetHtmlGroupPanel();
				if(groupPanel != null)
					groupPanel.firstChild.colSpan = this.grid.internalColumns.length;
			}
			if(this.showTitle){
				var title = this.GetHtmlTitle();
				if(title != null)
					title.firstChild.colSpan = this.grid.internalColumns.length;
			}
			for(var i = 0; i < this.grid.statusBars.length; i ++){
				var statusBar = this.GetHtmlStatusBar(i);
				if(statusBar != null)
					statusBar.firstChild.colSpan = this.grid.internalColumns.length;		
			}
		}
	}

	this.CustomRenderTitle = function(td, width, height, text, beforeDefaultRender){
		if(!this.grid.CustomRenderTitle.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderTextElementEventArgs(td, width, height, text, beforeDefaultRender);
			this.grid.CustomRenderTitle.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.CreateTitleTDContent = function (td, width, height, text){		
		var titleTemplate = this.grid.titleTemplate;
		if(titleTemplate != null)
			this.InstantiateTemplate(td, titleTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
			handled = this.CustomRenderTitle(td, width, height, text, true);
		if(!handled && titleTemplate == null)
			this.CreatePanelContents(td, text, width, height, this.titleBordersWidth);
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderTitle(td, width, height, text, false);
	}
	
	this.InvalidateTitle = function (){
		var title = this.GetHtmlTitle();	
		if(title != null){		
			var titleFirstChild = _getFirstChild(title);
			while(titleFirstChild.childNodes.length > 0){
				titleFirstChild.removeChild(titleFirstChild.lastChild);
			}		
			this.CreateTitleTDContent(titleFirstChild, this.grid.GetTotalWidth(false), this.titleHeight, this.titleText);
		}
	}
	
	this.CreatePanelContents = function(td, text, width, height, bordersWidth){
		_setCursor(td, "default");
		if(!ie)
			td.style.height = (height.type != "%") ? height.ToString() : "100%";
		var div = document.createElement("DIV");
		if(this.fixGroupPanelWidth && !width.IsEmpty() && width.type != "%"){
			if(!bordersWidth.IsEmpty())
				width = width.ConvertToPx().Sub(bordersWidth.ConvertToPx());
		}
		else{
			width = ASPxClientUnit.GetHundredPercentUnit();
		}
		div.style.width = width.ToString();
		div.style.overflow = "hidden";
		if(text != ""){
			div.nowrap = "";
			div.innerHTML = "&nbsp;" + _replaceSpaces(text) + "&nbsp;";
		}
		td.appendChild(div);
	}

	this.CustomRenderGroupPanel = function(td, width, height, text, beforeDefaultRender){
		if(!this.grid.CustomRenderGroupPanel.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderTextElementEventArgs(td, width, height, text, beforeDefaultRender);
			this.grid.CustomRenderGroupPanel.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.CreateGroupPanelTDContent = function (td, width, height, text){		
		var groupPanelTemplate = this.grid.groupPanelTemplate;
		if(groupPanelTemplate != null)
			this.InstantiateTemplate(td, groupPanelTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
			handled = this.CustomRenderGroupPanel(td, width, height, text, true);
		if(!handled && groupPanelTemplate == null)
			this.CreatePanelContents(td, text, width, height, this.groupPanelBordersWidth);
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderGroupPanel(td, width, height, text, false);
	}

	this.InvalidateGroupPanel = function (){		
		var firstColumnOffset = this.grid.GetLeftRowBtnColumnsOffset();
		var header = this.GetHtmlHeader(firstColumnOffset);
		if(header != null){
			header.colSpan = this.grid.groupColumns.length + 1;
		}

		var groupPanel = this.GetHtmlGroupPanel();	
		var headerPanel = this.GetHtmlHeaderPanel();		
		if(groupPanel != null){		
			var groupPanelFirstChild = _getFirstChild(groupPanel);
			while(groupPanelFirstChild.childNodes.length > 0){
				groupPanelFirstChild.removeChild(groupPanelFirstChild.lastChild);
			}		
			if(this.grid.groupColumns.length > 0){	
				this.CreatePanelContents(groupPanelFirstChild, "", this.grid.GetTotalWidth(true), this.groupPanelHeight, this.groupPanelBordersWidth);
				var table = this.CreateTable();
				_getFirstChild(groupPanelFirstChild).appendChild(table);
				table.appendChild(document.createElement("TBODY"));
				var indentTR = document.createElement("TR");
				table.firstChild.appendChild(indentTR);
				var td = document.createElement("TD");
				td.style.width = this.groupedHeaderIndent.ToString();
				indentTR.appendChild(td);
				td = document.createElement("TD");
				indentTR.appendChild(td);
				var groupHeadersTable = this.CreateTable();			
				td.appendChild(groupHeadersTable);
				groupHeadersTable.cellSpacing = 1;
				groupHeadersTable.appendChild(document.createElement("TBODY"));
				var groupHeadersTR = document.createElement("TR");
				groupHeadersTable.firstChild.appendChild(groupHeadersTR);
				groupHeadersTR.height = this.GetHeaderHeight().ToString();
				if(headerPanel != null)
					groupHeadersTR.align = headerPanel.align;
				for(var i = 0; i < this.grid.groupColumns.length; i ++){
					var groupColumn = this.grid.groupColumns[i];
					var groupHeaderTD = document.createElement("TD");
					groupHeadersTR.appendChild(groupHeaderTD);				
					groupHeaderTD.id = this.grid.name + getGroupedHeaderMark() + groupColumn.index;
					groupHeaderTD.width = this.GetGroupColumnHeaderWidth(groupColumn).ToString();
					groupHeaderTD.onmousedown = OnHMDown;	
					groupColumn.groupedHeaderStyle.ApplyStyle(groupHeaderTD, true);
					this.InvalidateHeader(groupColumn, true);
				}						
				td = document.createElement("TD");
				indentTR.appendChild(td);
			}
			else{		
				this.CreateGroupPanelTDContent(groupPanelFirstChild, this.grid.GetTotalWidth(true), this.groupPanelHeight, this.groupPanelText);
			}
		}
	}

	this.CreateTable = function(){
		var table = document.createElement("TABLE");
		table.cellPadding = 0;
		table.cellSpacing = 0;
		table.border = 0;	
		return table;
	}

	this.CreateHeaderImage = function(imageUrl, imgWidth){
		var imgtd = document.createElement("TD");
		imgtd.width = imgWidth.ToString();
		imgtd.align = "center";
		imgtd.appendChild(document.createElement("IMG"));
		imgtd.firstChild.src = imageUrl;
		return imgtd;
	}

	this.CustomRenderHeader = function(td, column, inGroupPanel, width, height, text, sortingOrder, beforeDefaultRender){
		if(!column.CustomRenderHeader.IsEmpty() || !this.grid.CustomRenderHeader.IsEmpty()){
			var eventArgs = new ASPxClientGridCustomRenderHeaderEventArgs(td, column, inGroupPanel, width, height, text, sortingOrder, beforeDefaultRender);
			column.CustomRenderHeader.FireEvent(column, eventArgs);
			if(!eventArgs.handled)
				this.grid.CustomRenderHeader.FireEvent(this.grid, eventArgs);
			return eventArgs.handled;
		}
		return false;
	}

	this.ApplyHeaderCustomRender = function(td, column, inGroupPanel, width, height, text, sortingOrder){
		var headerTemplate = column.headerTemplate;
		if(headerTemplate != null)
			this.InstantiateTemplate(td, headerTemplate);
		var handled = false;
		if(this.FireCustomRenderBeforeDefaultRender())
			handled = this.CustomRenderHeader(td, column, inGroupPanel, width, height, text, sortingOrder, true);
		return handled || headerTemplate != null;
	}


	this.CreateFooterStyle = function(registerId, style){
		var lookAndFeelStyle = new ASPxLookAndFeelStyle(GetStyleName(registerId));	
		lookAndFeelStyle.MergeStyle(GetLookAndFeelStyleCollection().GetFooterCellStyle(GetStyleName(this.grid.name + "Footer"), this.grid.lookAndFeel));
		lookAndFeelStyle.MergeStyle(style);
		return lookAndFeelStyle; 
	}

	this.CreateGroupIndentStyle = function(registerId, style, showLeftBorder, showRightBorder, showTopBorder, showBottomBorder){
		var lookAndFeelStyle = new ASPxLookAndFeelStyle(GetStyleName(registerId));	
		lookAndFeelStyle.MergeStyle(GetLookAndFeelStyleCollection().GetGroupItemStyle(GetStyleName(this.grid.name + "GroupItem"), this.grid.lookAndFeel));
		if(ie)
			lookAndFeelStyle.MergeStyle(style);
		lookAndFeelStyle.AddAttribute("textAlign", "center");
		if(this.correctGroupItemBorders){
			var backColor = lookAndFeelStyle.attributes["backgroundColor"];
			if(showLeftBorder != "Show"){
				if(showLeftBorder == "Remove")
					lookAndFeelStyle.AddAttribute("borderLeftStyle", "none");
				else
					lookAndFeelStyle.AddAttribute("borderLeftColor", backColor);
			}
			if(showRightBorder != "Show"){
				if(showRightBorder == "Remove")
					lookAndFeelStyle.AddAttribute("borderRightStyle", "none");				
				else				
					lookAndFeelStyle.AddAttribute("borderRightColor", backColor);
			}
			if(showTopBorder != "Show"){
				if(showTopBorder == "Remove")
					lookAndFeelStyle.AddAttribute("borderTopStyle", "none");				
				else
					lookAndFeelStyle.AddAttribute("borderTopColor", backColor);
			}
			if(showBottomBorder != "Show"){
				if(showBottomBorder == "Remove")
					lookAndFeelStyle.AddAttribute("borderBottomStyle", "none");				
				else
					lookAndFeelStyle.AddAttribute("borderBottomColor", backColor);
			}
		}
	}
	
	this.CreateGroupIndentStyles = function(){
		var groupIndentStyle = this.grid.groupIndentStyle;
		this.CreateGroupIndentStyle(this.grid.name + "GI", groupIndentStyle, !this.borderCollapse ? "Show" : "Hide", this.borderCollapse ? "Show" : "Remove", "Remove", !this.borderCollapse ? "Remove" : "Hide");
		this.CreateGroupIndentStyle(this.grid.name + "GL", groupIndentStyle, !this.borderCollapse ? "Show" : "Hide", this.borderCollapse ? "Show" : "Remove", "Remove", "Show");
		this.CreateGroupIndentStyle(this.grid.name + "EE", groupIndentStyle, !this.borderCollapse ? "Show" : "Hide", this.borderCollapse && this.showGridLinesBetweenButtons() ? "Hide" : "Remove", !this.borderCollapse ? "Remove" : "Show", !this.borderCollapse ? "Remove" : "Hide");
		this.CreateGroupIndentStyle(this.grid.name + "EC", groupIndentStyle, !this.borderCollapse ? "Show" : "Hide", !this.borderCollapse ? "Remove" : "Hide", !this.borderCollapse ? "Remove" : "Show", !this.borderCollapse ? "Show" : "Remove");
	}
	
	this.CreateEditorStyles = function(registerId, style){
		var lookAndFeelStyle = new ASPxLookAndFeelStyle(GetStyleName(registerId));	
		lookAndFeelStyle.MergeStyle(GetLookAndFeelStyleCollection().GetEditorStyle(GetStyleName(this.grid.name + "Editor"), this.grid.lookAndFeel));
		lookAndFeelStyle.MergeStyle(style);
	}

	this.CreateBtnStyles = function(registerId, style, hotTrackStyle, pressedStyle){
		var lookAndFeelStyle = new ASPxLookAndFeelStyle(GetStyleName(registerId));	
		lookAndFeelStyle.MergeStyle(GetLookAndFeelStyleCollection().GetButtonStyle(GetStyleName(this.grid.name + "Btn"), this.grid.lookAndFeel));
		lookAndFeelStyle.MergeStyle(style);
		lookAndFeelStyle = new ASPxLookAndFeelStyle(GetHotTrackedStyleName(registerId));
		lookAndFeelStyle.MergeStyle(GetLookAndFeelStyleCollection().GetButtonHotTrackStyle(GetHotTrackedStyleName(this.grid.name + "Btn"), this.grid.lookAndFeel));
		lookAndFeelStyle.MergeStyle(hotTrackStyle);
		lookAndFeelStyle = new ASPxLookAndFeelStyle(GetPressedStyleName(registerId));
		lookAndFeelStyle.MergeStyle(GetLookAndFeelStyleCollection().GetButtonPressedStyle(GetPressedStyleName(this.grid.name + "Btn"), this.grid.lookAndFeel));
		lookAndFeelStyle.MergeStyle(pressedStyle);
	}

	this.IsFirstVisibleColumn = function(column){
		return this.grid.GetColumnInternalIndex(column) == this.grid.GetLeftRowBtnColumnsOffset() + this.grid.groupColumns.length;
	}

	this.CreateHeaderTDContent = function(td, column, inGroupPanel, width, height, text, sortingOrder){
		var columnIndex = column.index;
		var registerId = this.grid.name + (inGroupPanel ? "GH" : "CH") + columnIndex;
		if(GetLookAndFeelStyleCollection().Get(GetStyleName(registerId)) == null){
			var btnStyle = inGroupPanel ? column.GetResolvedGroupedHeaderStyle() : column.GetResolvedHeaderStyle();
			this.CreateBtnStyles(registerId, btnStyle, inGroupPanel ? this.grid.groupedHeaderHotTrackStyle : this.grid.headerHotTrackStyle, inGroupPanel ? this.grid.groupedHeaderPressedStyle : this.grid.headerPressedStyle);
		}
		var style = GetLookAndFeelStyleCollection().Get(GetStyleName(registerId));
		var templateContainer = null;
		if(this.instantiateTemplatesInButtons || !this.ApplyHeaderCustomRender(td, column, inGroupPanel, width, height, text, sortingOrder)){
			var enableGroupingButtons = column.GetEnableGroupingButton();			
			var customRender = false;
			if(this.instantiateTemplatesInButtons){
				templateContainer = document.createElement("TD");
				customRender = this.ApplyHeaderCustomRender(templateContainer, column, inGroupPanel, width, height, text, sortingOrder);
			}	
			var headerHeight = style.fixedHeight && height.type != "%" ? height : ASPxClientUnit.GetHundredPercentUnit();
			var headerWidth = width.type != "%" ? width : ASPxClientUnit.GetHundredPercentUnit();
			headerWidth = headerWidth.Inc(1);	
			if(customRender){
				CreateLFButton(td, "LFBtn" + columnIndex, registerId, this.grid.lookAndFeel, true, templateContainer, null, "", "", "", "", this.grid.enabled, "", null, headerWidth, headerHeight);
			}
			else{
				if(sortingOrder == "None" && !enableGroupingButtons || customRender){
					CreateLFButton(td, "LFBtn" + columnIndex, registerId, this.grid.lookAndFeel, true, null, null, "", "", "", text, this.grid.enabled, "", null, headerWidth, headerHeight);
				}
				else{
					var table = this.CreateTable();
					style.ApplyFontAttributesToTables(table, true, true);
					table.appendChild(document.createElement("TBODY"));
					table.style.borderWidth = 0;
					table.style.borderStyle = "none";
					table.firstChild.appendChild(document.createElement("TR"));
					var subtd;
					if(enableGroupingButtons){
						subtd = this.CreateHeaderImage(!inGroupPanel ? this.groupingImages.GetImage("Group") : this.groupingImages.GetImage("Ungroup"), this.groupingImageWidth);
						table.firstChild.firstChild.appendChild(subtd);
						if(this.grid.enabled)
							subtd.onclick = OnGBCl;
						subtd.id = this.grid.name + (!inGroupPanel ? getGroupButtonMark() : getUngroupButtonMark()) + column.index;
					}
					subtd = document.createElement("TD");
					style.ApplyTableItemAttributes(subtd, true);			
					
					var innerWidth = width;
					var borderLeftWidth = ASPxClientUnit.Parse(style.GetBorderLeftWidth());
					var borderRightWidth = ASPxClientUnit.Parse(style.GetBorderRightWidth());
					if(innerWidth.type == "px" && (borderLeftWidth == null || borderLeftWidth.IsEmpty() || borderLeftWidth.type == "px") && (borderRightWidth == null || borderRightWidth.IsEmpty() || borderRightWidth.type == "px") && (this.grid.groupColumns.length || !this.IsFirstVisibleColumn(column) || this.grid.groupRowIndent == null || this.grid.groupRowIndent.IsEmpty() || this.grid.groupRowIndent.type == "px")){
						if(enableGroupingButtons)
							innerWidth = innerWidth.Sub(this.groupingImageWidth);
						if(sortingOrder != "None")
							innerWidth = innerWidth.Sub(this.sortingImageWidth);
						if(borderLeftWidth != null && !borderLeftWidth.IsEmpty())
							innerWidth = innerWidth.Sub(borderLeftWidth);
						if(borderRightWidth != null && !borderRightWidth.IsEmpty())
							innerWidth = innerWidth.Sub(borderRightWidth);					
					}
					else{
						innerWidth = ASPxClientUnit.GetHundredPercentUnit();
					}
					subtd.width = innerWidth.ToString();	
					
					var div = document.createElement("DIV");
					subtd.appendChild(div);
					div.id = "Cptn";
					_setElementInnerText(div, text);
					var align = style.GetHorizontalAlign();
					if(align == null || align == "")
						align = "center";
					div.style.textAlign = align;
					if(style.attributes["whiteSpace"] != null)
						div.style.whiteSpace = style.attributes["whiteSpace"];
					if(style.fixedWidth && innerWidth.type != "%" || style.fixedHeight && height.type != "%"){
						div.style.overflow = "hidden";
						div.style.textOverflow = "ellipsis";
					}
					if(style.fixedWidth || innerWidth.type == "%")	
						div.style.width = innerWidth.ToString();
					table.firstChild.firstChild.appendChild(subtd);
					if(sortingOrder != "None"){
						subtd = this.CreateHeaderImage(this.sortingImages.GetImage(sortingOrder), this.sortingImageWidth);
						table.firstChild.firstChild.appendChild(subtd);
					}
					CreateLFButton(td, "LFBtn" + columnIndex, registerId, this.grid.lookAndFeel, true, null, table, "", "", "", "", this.grid.enabled, "", null, headerWidth, headerHeight);
				}
			}
		}
		if(this.FireCustomRenderAfterDefaultRender())
			this.CustomRenderHeader(this.instantiateTemplatesInButtons ? templateContainer : td, column, inGroupPanel, width, height, text, sortingOrder, false);
	}

	this.InvalidateHeaderInternal = function(htmlHeader, column, inGroupPanel, idPrefix, width, sortingOrder){
		if(htmlHeader != null && column != null){		
			if(idPrefix != "")
				htmlHeader.id = this.grid.name + idPrefix + column.index;
			while(htmlHeader.childNodes.length > 0)
				htmlHeader.removeChild(htmlHeader.lastChild);
			this.CreateHeaderTDContent(htmlHeader, column, inGroupPanel, width, this.GetHeaderHeight(), column.headerText, sortingOrder);
			if(!inGroupPanel && !this.showGridLinesBetweenButtons)
				htmlHeader.style.borderStyle = "none";
			if(!inGroupPanel)
				this.CorrectTDBorders(htmlHeader, 0, 1);
		}
	}

	this.InvalidateHeader = function(column, inGroupPanel){		
		if(column != null){		
			var sortingOrder = column.sortingOrder;		
			if(sortingOrder == "None" && column.groupIndex >= 0)
				sortingOrder = "Ascending";		
			if(!inGroupPanel)
				this.InvalidateHeaderInternal(this.GetHtmlHeader(this.grid.GetColumnInternalIndex(column)), column, inGroupPanel, getColumnHeaderMark(), this.GetColumnHeaderWidth(column), sortingOrder);
			else
				this.InvalidateHeaderInternal(this.GetHtmlGroupHeader(column.groupIndex), column, true, getGroupedHeaderMark(), this.GetGroupColumnHeaderWidth(column), sortingOrder);
		}
	}

	this.InvalidateHeaderButtons = function(){
		var headerPanel = this.GetHtmlHeaderPanel();
		if(headerPanel != null){
			var headerIndex = 0;
			for(var i = 0; i < this.grid.internalColumns.length; i ++){
				var column = this.grid.internalColumns[i];
				if(column.type == "RowBtnColumn"){		
					td = headerPanel.cells[headerIndex];
					while(_isExists(td.firstChild)){
						td.removeChild(td.firstChild);
					}
					var btnType = this.grid.IsEditMode() ? column.editHeaderPanelButton : column.headerPanelButton;
					this.InitializeRowBtnTD(td, column, btnType, true, this.GetRowBtnOnClick(btnType), column.GetWidth(), this.GetHeaderHeight(), false, this.rowBtnImages.GetImage(btnType), btnType != "Empty", this.rowBtnToolTips.GetToolTip(btnType), true, false);
					if(!this.showGridLinesBetweenButtons)
						td.style.borderStyle = "none";
				}
				if(column.type != "GroupingIndentColumn")
					headerIndex ++;
			}
		}
	}
	
	this.UpdateSpaceCell = function(td, width){
		td.style.width = width.ToString();
		td.firstChild.style.width = width.type != "%" ? width.ToString() : "100%";
	}
	
	this.UpdateGroupPanelWidth = function(totalWidth){
		if(this.showGroupPanel){
			var groupPanel = this.GetHtmlGroupPanel();
			if(groupPanel != null){
				var td = _getFirstChild(groupPanel);				
				if(this.grid.groupPanelTemplate == null && this.grid.CustomRenderGroupPanel.IsEmpty())	
					_getFirstChild(td).style.width = this.fixGroupPanelWidth && !totalWidth.IsEmpty() && totalWidth.type != "%" ? totalWidth.ToString() : "100%";
				else
					this.InvalidateGroupPanel();
			}
		}
	}
	
	this.UpdateTitleWidth = function(totalWidth){
		if(this.showTitle){
			var title = this.GetHtmlTitle();
			if(title != null){
				var td = _getFirstChild(title);
				if(this.grid.titleTemplate == null && this.grid.CustomRenderTitle.IsEmpty())					
					_getFirstChild(td).style.width = this.fixGroupPanelWidth && !totalWidth.IsEmpty() && totalWidth.type != "%" ? totalWidth.ToString() : "100%";
				else
					this.IvalidateTitle();
			}
		}
	}
	
	this.GetSpaceCellWidth = function(width, cellIndex, firstDataColumnIndex, lastDataColumnIndex){
		return !this.borderCollapse && cellIndex == firstDataColumnIndex || this.borderCollapse && cellIndex == lastDataColumnIndex ? width.Inc(1) : width;
	}
	
	this.InvalidateResizedColumns = function(resizedColumns){
		var cellIndexes = new Array();
		var columnCellWidths = new Array();
		var columnWidths = new Array();
		var editors = new Array();
		var defaultDataCellProcessing = new Array();
		for(var i = 0; i < resizedColumns.length; i ++){
			var column = resizedColumns[i];			
			cellIndexes[i] = this.grid.GetColumnInternalIndex(column);
			columnCellWidths[i] = column.GetCellWidth();
			columnWidths[i] = column.GetWidth();
			editors[i] = column.GetEditor();
			defaultDataCellProcessing[i] = editors[i] != null && column.itemTemplate == null && column.CustomRenderCell.IsEmpty() && this.grid.CustomRenderCell.IsEmpty() && column.BindCell.IsEmpty() && this.grid.BindCell.IsEmpty();
		}
		var defaultPreviewCellProcessing = this.grid.previewTemplate == null && this.grid.CustomRenderPreview.IsEmpty() && this.grid.BindPreview.IsEmpty();
		
		var firstDataColumnIndex = this.GetFirstDataColumnIndex();
		var lastDataColumnIndex = this.grid.GetRightRowBtnColumnsOffset();
		var space = this.GetHtmlEmptySpace();
		if(space != null){
			for(var i = 0; i < resizedColumns.length; i ++){
				this.UpdateSpaceCell(space.cells[cellIndexes[i]], this.GetSpaceCellWidth(columnWidths[i], cellIndexes[i], firstDataColumnIndex, lastDataColumnIndex));
			}
		}
		var synchSpace = this.GetHtmlSynchSpace();
		if(synchSpace != null){
			for(var i = 0; i < resizedColumns.length; i ++){
				this.UpdateSpaceCell(synchSpace.cells[cellIndexes[i]], this.GetSpaceCellWidth(columnWidths[i], cellIndexes[i], firstDataColumnIndex, lastDataColumnIndex));
			}
		}
		
		var items = this.GetHtmlRows();		
		if(items != null){			
			var firstTROffset = this.GetFirstTROffset(), lastTROffset = this.GetLastTROffset();		
			for(var i = firstTROffset, rowIndex = 0; i < items.rows.length - lastTROffset; i++){
				var tr = items.rows[i];
				if(tr.level == this.grid.groupColumns.length){
					if(!tr.preview){
						var row = this.grid.GetVisibleRow(this.GetFirstVisibleIndex() + rowIndex);
						for(var j = 0; j < resizedColumns.length; j ++){
							var column = resizedColumns[j];
							var td = tr.cells[cellIndexes[j]];
							var isEditRow = this.grid.IsEditMode() && tr == this.focusedTR;
							var rowHeight = isEditRow ? this.GetEditRowHeight() : this.grid.GetItemHeight();
							if(defaultDataCellProcessing[j]){					
								if(column.type == "BoundColumn" && (!this.grid.directRender || isEditRow))
									editors[j].SetEditorSize(td.firstChild, isEditRow, columnCellWidths[j], rowHeight.type != "%" ? rowHeight : ASPxClientUnit.GetHundredPercentUnit());
							}
							else{
								_clearElementChildren(td);
								var isEditCell = this.IsEditCell(column, isEditRow);
								var cellValue = this.GetColumnValue(column, row, isEditCell);
								if(isEditCell){
									this.CreateEditTDContent(td, column, row.GetEvenOdd() == "Odd");
									this.FillEditRowTD(td, column, row, cellValue);
								}
								else{
									this.CreateDataTDContent(td, column, row.GetEvenOdd() == "Odd");
									this.FillDataRowTD(td, column, row, cellValue);									
								}
							}							
						}
						rowIndex ++;
					}
					else{
						var row = this.grid.GetVisibleRow(this.GetFirstVisibleIndex() + rowIndex - 1);
						var totalWidth = this.grid.GetPreviewSectionWidth();					
						var td = _getLastChild(tr);
						if(td != null){						
							if(defaultPreviewCellProcessing){
								if(!this.grid.directRender)
									td.firstChild.style.width = totalWidth.ToString();
							}
							else{
								_clearElementChildren(td);
								this.CreatePreviewTDContent(td, this.grid.GetPreviewSectionWidth(), this.grid.GetPreviewHeight());
								this.FillPreviewTD(td, row, this.GetPreviewValue(row));
							}
						}
					}					
				}
				else{
					var row = this.grid.GetVisibleRow(this.GetFirstVisibleIndex() + rowIndex);
					var groupingColumn = this.grid.groupColumns[row.GetLevel()];
					var defaultGroupingCellProcessing = groupingColumn.groupItemTemplate == null && groupingColumn.CustomRenderGroupItem.IsEmpty() && this.grid.CustomRenderGroupItem.IsEmpty() && groupingColumn.BindGroupingCell.IsEmpty() && this.grid.BindGroupingCell.IsEmpty();
					var td = tr.cells[this.grid.GetLeftRowBtnColumnsOffset() + row.GetLevel() + 1];
					if(defaultGroupingCellProcessing){
						if(!this.grid.directRender)
							td.firstChild.style.width = this.grid.GetGroupItemTextSectionWidth(row.GetLevel()).ToString();
					}
					else{
						_clearElementChildren(td);
						this.CreateGroupingTDContent(td, groupingColumn, new ASPxClientUnit(0, ""), this.grid.GetItemHeight());
						this.FillGroupingTD(td, groupingColumn, row, this.GetGroupingText(row, groupingColumn));
					}
					rowIndex ++;
				}
			}
		}
		if(this.showHeaders){
			for(var i = 0; i < resizedColumns.length; i ++){
				var column = resizedColumns[i];
				if(column.type == "BoundColumn" || column.type == "TemplateColumn")
					this.InvalidateHeader(column, false);
			}
		}
		
		if(this.showSearchItem && column){
			var searchItem = this.GetHtmlSearchItem();
			if(searchItem != null){
				for(var i = 0; i < resizedColumns.length; i ++){
					var column = resizedColumns[i];
					if(column.type == "BoundColumn" && column.enableSearchControl)
						this.InvalidateSearchItem(searchItem.cells[cellIndexes[i]], column, columnCellWidths[i], this.GetSearchItemHeight(), false);
				}
			}
		}		
		if(this.showFooter){
			var footer = this.GetHtmlFooter();
			if(footer != null){				
				for(var i = 0; i < resizedColumns.length; i ++){
					var column = resizedColumns[i];
					if(column.type == "BoundColumn")
						this.InvalidateFooter(footer.cells[cellIndexes[i]], column, columnCellWidths[i], this.GetFooterHeight());
				}
			}
		}				
	}
	
	this.SetChildrenVisible = function(row){
		var childrenDisplay = row.GetExpanded() && row.GetVisible() ? "" : "none";
		var rowLevel = row.GetLevel();
		var childRow = this.grid.GetRow(row.GetIndex() + 1);
		var childRowLevel = childRow.GetLevel();
		while(childRowLevel > rowLevel){
			if(childRowLevel == rowLevel + 1){
				var childTr = this.GetTRByPos(this.GetHtmlRows(), childRow.GetIndex());
				childTr.style.display = childrenDisplay;
				if(childRowLevel < this.grid.groupColumns.length)
					this.SetChildrenVisible(childRow);
			}	
			childRow = this.grid.GetRow(childRow.GetIndex() + 1);
			childRowLevel = childRow != null ? childRow.GetLevel() : -1;
		}
	}
	
	this.InvalidateExpandedRow = function(row){				
		var tr = this.GetTRByPos(this.GetHtmlRows(), row.GetIndex());
		var expandBtnTD = this.GetExpandBtnTD(tr, row);
		if(row.GetExpanded())
			this.SetButtonExpanded(expandBtnTD);
		else
			this.SetButtonCollapsed(expandBtnTD);			
		this.SetChildrenVisible(row);
	}
	
	this.GetColumnCell = function(tr, column){
		var items = this.GetHtmlRows();
		if(items != null && array_indexOf(items.rows, tr) >= 0 && this.grid.GetColumnInternalIndex(column) >= 0)
			return tr.cells[this.grid.GetColumnInternalIndex(column)];
		return null;
	}

	this.GetTRByPos = function (items, trPos){	
		if(trPos >= 0){
			if(!grid.showPreview){
				return items.rows[trPos + this.GetFirstTROffset()];
			}
			else{
				var firstVisibleIndex = this.GetFirstVisibleIndex();
				for(var i = 0, actualPos = 0; i < trPos; i ++){
					actualPos += (!this.IsGroupRow(this.grid.GetVisibleRow(firstVisibleIndex + i)) ? 2 : 1);
				}
				return items.rows[actualPos + this.GetFirstTROffset()];
			}
		}
		return null;
	}

	this.UnselectTR = function(tr){
		this.baseHideSelection(tr, tr.rowIndex - this.GetFirstTROffset());
	}
	
	this.baseHideFocus = this.HideFocus;
	this.HideFocus = function(){
		if(this.focusedTR != null){
			this.baseHideFocus(this.focusedTR);
			this.focusedTR = null;
		}
	}

	this.baseHideSelection = this.HideSelection;
	this.HideSelection = function (){		
		var items = this.GetHtmlRows();
		if(items != null){		
			for(var i = 0; i < this.selectedTRs.length; i ++){
				this.UnselectTR(this.selectedTRs[i]);
			}
			array_clear(this.selectedTRs);
			this.HideFocus();
		}
	}

	this.baseShowSelection = this.ShowSelection;
	this.ShowSelection = function (){	
		var items = this.GetHtmlRows();	
		if(items != null){			
			array_clear(this.selectedTRs);	
			for(var i = this.GetFirstVisibleIndex(); i <= this.GetLastVisibleIndex(); i ++){
				var row = this.grid.GetVisibleRow(i);
				if(row.GetSelected()){
					var rowPos = this.grid.clientSideExpanding ? row.GetIndex() : i - this.GetFirstVisibleIndex();
					var tr = this.GetTRByPos(items, rowPos);
					this.selectedTRs.push(tr);
					this.baseShowSelection(tr, rowPos);
				}
			}
			this.focusedTR = this.GetTRByPos(items, this.grid.focusedPos);
			if(this.focusedTR != null){
				this.ShowFocus(this.focusedTR);
			
				if(this.grid.IsEditMode() && this.grid.GetFocusedColumn() != null){
					var focusedColumn = this.grid.GetFocusedColumn();
					var handled = false;
					if(!focusedColumn.FocusEditor.IsEmpty()){
						var eventArgs = new ASPxClientGridFocusEditorEventArgs(this.focusedTR.cells[this.grid.GetColumnInternalIndex(focusedColumn)], focusedColumn);
						focusedColumn.FocusEditor.FireEvent(focusedColumn, eventArgs);
						handled = eventArgs.handled;
					}
					var editor = focusedColumn.GetEditor();
					if(!handled && editor != null && __getFocusedControl() == this.grid)
						editor.FocusEditor();		
				}
			}
		}	
	}
	
	this.GetTotalRowsHeight = function(){
		var groupCount = this.grid.groupColumns.length;
		if(!this.grid.showPreview || groupCount == 0 && this.showEmptyPreview)
			return this.GetItemHeight(this.grid.showPreview).Mul(this.grid.GetVisibleRowCount());
		var previewCount = 0;		
		var visibleRowCount = this.grid.GetVisibleRowCount(); 
		for(var i = 0; i < visibleRowCount; i ++){
			var row = this.grid.GetVisibleRow(i);			
			if(this.RowHasPreview(row) && this.NeedShowRowPreview(row))
				previewCount ++;
		}
		return this.grid.GetItemHeight().Mul(visibleRowCount).Add(this.grid.GetPreviewHeight().Mul(previewCount));
	}
	
	this.ResetRegularVertScrollBar = function(){
		var scrollBar = this.GetVertScrollBar();	
		if(scrollBar != null)
			scrollBar.SetScrollableID(this.grid.name + (this.grid.GetPageSize() > 0 && !opera ? "vertscroller" : "vertscrollarea"));
	}
	
	this.ResetNativeVertScrollBar = function(){
		if(!ie){
			var scroller = this.GetHtmlScroller();
			if(scroller != null)
				scroller.style.overflow = this.grid.GetPageSize() == 0 || opera || this.IsHorzScrollBarShown() ? "auto" : "visible";
		}
		var vertScroller = this.GetHtmlVertScroller();
		if(vertScroller != null)
			vertScroller.style.width = (this.grid.GetPageSize() > 0 && !opera && (ie || !this.IsHorzScrollBarShown()) ? (_getScrollBarWidth() + 1) : 0);
	}
	
	this.GetScrollerCorrection = function(vertScroller){
		if(_getElementHeight(_getFirstChild(vertScroller)) == 0){
			_getFirstChild(vertScroller).style.height = _getElementScrollHeight(vertScroller);
		}
		return _getElementHeight(_getFirstChild(vertScroller)) - _getElementScrollHeight(vertScroller);
	}
	
	this.UpdateRegularVertScrollBar = function(){		
		if(this.grid.GetPageSize() > 0 && !opera){
			var vertScrollArea = this.GetHtmlVertScrollArea();
			if(vertScrollArea != null)
				vertScrollArea.style.height = _getElementHeight(_getFirstChild(vertScrollArea));
			var vertScroller = this.GetHtmlVertScroller();
			if(vertScroller != null){
				vertScroller.style.height = new ASPxClientUnit(_getElementHeight(_getFirstChild(vertScrollArea)), "px").ToString();
				var correction = this.GetScrollerCorrection(vertScroller);
				_getFirstChild(vertScroller).style.height = this.GetTotalRowsHeight().Inc(correction).ToString();
			}				
			var scrollBar = this.GetVertScrollBar();	
			if(scrollBar != null){
				scrollBar.SetSize(new ASPxClientUnit(_getElementHeight(this.GetHtmlScroller()), "px"));
				var rowCount = this.grid.GetVisibleRowCount() - this.grid.pageSize;
				scrollBar.SetPosition(rowCount > 0 ? this.GetFirstVisibleIndex() * (scrollBar.scrollableSize - (this.IsHorzScrollBarShown() ? this.GetHorzScrollBar().scrollBarButtonSize : 0)) / rowCount : 0);
			}			
		}
		else{
			var vertScrollArea = this.GetHtmlVertScrollArea();
			if(vertScrollArea != null)
				vertScrollArea.style.height = this.GetVertScrollHeight().ToString();
			var vertScroller = this.GetHtmlVertScroller();
			if(vertScroller != null){
				vertScroller.style.height = 0;
				_getFirstChild(vertScroller).style.height = 0;
			}
			var scrollBar = this.GetVertScrollBar();	
			if(scrollBar != null)
				scrollBar.SetSize(new ASPxClientUnit(_getElementHeight(this.GetHtmlScroller()), "px"));
				scrollBar.SetPosition(1);
		}
	}
	
	this.UpdateNativeVertScrollBar = function(){
		if(this.grid.GetPageSize() > 0 && !opera){
			var scroller = this.GetHtmlScroller();	
			if(scroller != null)
				scroller.style.height = _getElementHeight(_getFirstChild(scroller)) + (this.IsHorzScrollBarShown() && !this.horzScrollBarEmpty ? _getScrollBarWidth() : 0);
			var vertScroller = this.GetHtmlVertScroller();
			if(vertScroller != null){
				vertScroller.style.height = _getElementHeight(_getFirstChild(scroller));
				_getFirstChild(vertScroller).style.height = this.GetTotalRowsHeight().ToString();
				vertScroller.scrollTop = this.GetFirstVisibleIndex() * (vertScroller.scrollHeight - vertScroller.offsetHeight) / (this.grid.GetVisibleRowCount() - this.grid.GetPageSize());
			}
		}
		else if(!this.scrollHeight.IsEmpty()){
			var scroller = this.GetHtmlScroller();	
			if(scroller != null){
				scroller.style.height = this.scrollHeight.ToString();
				scroller.style.overflowY = "auto";
			}
			var vertScroller = this.GetHtmlVertScroller();
			if(vertScroller != null)
				vertScroller.style.height = this.scrollHeight.ToString();
		}
	}	
	
	this.FitScrollerWidth = function(totalColumnsWidth){	
		var totalColumnsWidth = this.grid.GetTotalColumnsWidth(true).value;
		this.UpdateGroupPanelWidth(new ASPxClientUnit(1, "px"));		
		var scroller = this.GetHtmlScroller();
		scroller.style.width = 1;		
		var actualGridWidth = this.GetActualGridWidth();
		scroller.style.width = (totalColumnsWidth > actualGridWidth) ? actualGridWidth - (this.IsVertScrollBarShown() ? this.GetScrollBarSize().ConvertToPx().value : 0) : totalColumnsWidth + 1;
		if(this.IsVertScrollBarShown()){
			if(!this.nativeScrolling)
				_getParentNode(this.GetVertScrollBar().GetScrollBarElement()).style.width = totalColumnsWidth > actualGridWidth ? this.GetScrollBarSize().ToString() : actualGridWidth - totalColumnsWidth; 
			else
				_getParentNode(this.GetHtmlVertScroller()).style.width = totalColumnsWidth > actualGridWidth ? this.GetScrollBarSize().ToString() : actualGridWidth - totalColumnsWidth;
		}
		else{
			if(this.nativeScrolling)
				scroller.style.height = _getElementHeight(_getFirstChild(scroller)) + (totalColumnsWidth > actualGridWidth ? this.GetScrollBarSize().ToString() : 0);
		}
		this.UpdateGroupPanelWidth(new ASPxClientUnit(this.GetActualGridWidth(), "px"));
	}
}

function ImageSet(){
	this.images = new Array();
	this.GetImage = function(key){
		return this.images[key];
	}
}

function SortingImages(){
	this.inherit = ImageSet;
	this.inherit();
	
	this.images["Ascending"] = _getDefaultImagePath() + "hbSortUp.gif";
	this.images["Descending"] = _getDefaultImagePath() + "hbSortDown.gif";
}

function GroupingImages(){
	this.inherit = ImageSet;
	this.inherit();
	
	this.images["Group"] = _getDefaultImagePath() + "hbGroup.gif";
	this.images["Ungroup"] = _getDefaultImagePath() + "hbUngroup.gif";
}

function ExpandImages(){
	this.inherit = ImageSet;
	this.inherit();
	
	this.images["Expand"] = _getDefaultImagePath() + "ebExpand.gif";
	this.images["Collapse"] = _getDefaultImagePath() + "ebCollapse.gif";
}

function RowBtnImages(){
	this.inherit = ImageSet;
	this.inherit();
	
	this.images["Empty"] = _getDefaultImagePath() + "1x1.gif";
	this.images["Insert"] = _getDefaultImagePath() + "rbIns.gif";
	this.images["Append"] = _getDefaultImagePath() + "rbAppend.gif";
	this.images["Edit"] = _getDefaultImagePath() + "rbEdit.gif";
	this.images["Delete"] = _getDefaultImagePath() + "rbDel.gif";
	this.images["Post"] = _getDefaultImagePath() + "rbPost.gif";
	this.images["Cancel"] = _getDefaultImagePath() + "rbCancel.gif";
}

function ToolTipSet(){
	this.toolTips = new Array();
	this.GetToolTip = function(key){
		return this.toolTips[key];
	}
}

function RowBtnToolTips(){
	this.inherit = ToolTipSet;
	this.inherit();
	
	this.toolTips["Empty"] = "";
	this.toolTips["Insert"] = "Insert row";
	this.toolTips["Append"] = "Append row";
	this.toolTips["Edit"] = "Edit row";
	this.toolTips["Delete"] = "Delete row";
	this.toolTips["Post"] = "Save changes";
	this.toolTips["Cancel"] = "Cancel changes";
}

function CellValue(value, renderValueDirectly){
	this.value = value;
	this.renderValueDirectly = renderValueDirectly;
}