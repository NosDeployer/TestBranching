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

var draggableLFScrollBar = null;
var draggableLFScrollBarPosition = 0;
var draggableLFScrollBarX = 0;
var draggableLFScrollBarY = 0;

function ASPxLookAndFeelScrollBar(name){
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	

	this.mouseWheelInc = 50;
	this.scrollInc = 10; 
	this.scrollLargeInc = 25;
	this.horizontal = false;
	this.margin = 0;
	this.nativeRender = false;
	this.scrollableID = "";
	this.storePosition = true;
	this.storedPosition = 0;

	this.elementClientSize = 0;
	this.elementScrollSize = 0;
	this.scrollBarSize = 0;
	this.scrollBarClientSize = 0;
	this.scrollBarButtonSize = 0;

	this.scrollableSizeLimit = 0;
	this.scrollableSize = 0;
	this.scrollableRatio = 0;
	this.thumbMinSize = 8;
	this.position = 0;
	this.enabled = true;
	this.visible = false;

	this.timer = -1;
	this.timerRecalculate = false;
		
	this.getClientSize = null;
	this.getScroll = null;
	this.getScrollSize = null;
	this.getSize = null;
	this.getUnitSize = null;
	this.setScroll = null;
	this.setSize = null;
	
	this.rootElement = null;
	this.scrollableElement = null;
	this.scrollBarElement = null;
	this.scrollBarMainElement = null;
	this.downButton = null;
	this.downPageButton = null;
	this.upButton = null;
	this.upPageButton = null;
	this.thumbButton = null;
	this.nativeScroller = null;
	this.nativeScrollable = null;

	this.GetRootElement = function(){
		if(this.rootElement == null)
			this.rootElement = _getElementById(this.name);
		return this.rootElement;
	}
	this.SetRootElement = function(element){
		this.rootElement = element;
		this.scrollableElement = null;
		this.scrollBarElement = null;
		this.scrollBarMainElement = null;
		this.downButton = null;
		this.downPageButton = null;
		this.upButton = null;
		this.upPageButton = null;
		this.thumbButton = null;
		this.nativeScroller = null;
		this.nativeScrollable = null;
		this.InitializeSizes();
	}
	this.GetScrollableElement = function(){
		if(this.scrollableElement == null){
			if(!this.nativeRender){
				var scrollBoxRootElement = (this.GetRootElement() != null) ? _getParentByCssClass(this.GetRootElement(), "LFScrollBox") : null;
				if(scrollBoxRootElement != null)
					this.scrollableElement = _getChildById(scrollBoxRootElement, this.scrollableID);
			}
			if(this.scrollableElement == null)
				this.scrollableElement = _getElementById(this.scrollableID);
		}
		return this.scrollableElement;
	}
	this.GetScrollBarElement = function(){
		if(this.scrollBarElement == null && this.GetRootElement() != null)
			this.scrollBarElement = _getParentNode(this.GetRootElement());
		return this.scrollBarElement;
	}	
	this.GetScrollBarMainElement = function(){
		if(this.scrollBarMainElement == null){
			var element = this.GetScrollBarElement();
			this.scrollBarMainElement = (element != null) ? _getParentByCssClass(element, "LFScrollBarContainer") : null;
		}
		return this.scrollBarMainElement;
	}	
	this.GetDownButton = function(){
		if(this.downButton == null && this.GetRootElement() != null)
			this.downButton = _getChildById(this.GetRootElement(), this.name + "DownBtn");
		return this.downButton;
	}
	this.GetDownPageButton = function(){
		if(this.downPageButton == null && this.GetRootElement() != null)
			this.downPageButton = _getChildById(this.GetRootElement(), this.name + "DownPageBtn");
		return this.downPageButton;
	}
	this.GetUpButton = function(){
		if(this.upButton == null && this.GetRootElement() != null)
			this.upButton = _getChildById(this.GetRootElement(), this.name + "UpBtn");
		return this.upButton;
	}
	this.GetUpPageButton = function(){
		if(this.upPageButton == null && this.GetRootElement() != null)
			this.upPageButton = _getChildById(this.GetRootElement(), this.name + "UpPageBtn");
		return this.upPageButton;
	}
	this.GetThumbButton = function(){
		if(this.thumbButton == null && this.GetRootElement() != null)
			this.thumbButton = _getChildById(this.GetRootElement(), this.name + "ThumbBtn");
		return this.thumbButton;
	}
	this.GetNativeScroller = function(){
		if(this.nativeScroller == null && this.GetRootElement() != null)
			this.nativeScroller = _getChildById(this.GetRootElement(), this.name + "NativeScroller");
		return this.nativeScroller;
	}
	this.GetNativeScrollable = function(){
		if(this.nativeScrollable == null && this.GetRootElement() != null)
			this.nativeScrollable = _getChildById(this.GetRootElement(), this.name + "NativeScrollable");
		return this.nativeScrollable;
	}
	
	this.InitializeControl = function(){
		if(!this.enabled) return;
		
		this.InitializeMethods();
		if(!this.IsDisplayed())
			this.SetVisible(true);
	}
	this.InitializeControlRender = function(){
		if(!this.enabled) return;
		
		this.InitializeSizes();
		this.RestorePosition();
		this.Calculate(true);
	}
	this.InitializeMethods = function(){
		if(this.getClientSize == null)
			this.getClientSize = this.horizontal ? _getElementClientWidth : _getElementClientHeight; 
		if(this.getScroll == null)
			this.getScroll = this.horizontal ? _getScrollLeft : _getScrollTop; 
		if(this.getScrollSize == null)
			this.getScrollSize = this.horizontal ? _getElementScrollWidth : _getElementScrollHeight; 
		if(this.getSize == null)
			this.getSize = this.horizontal ? _getElementWidth : _getElementHeight;
		if(this.setScroll == null)
			this.setScroll = this.horizontal ? _setScrollLeft : _setScrollTop; 
		if(this.setSize == null)
			this.setSize = this.horizontal ? _setElementWidth : _setElementHeight;
		if(this.setUnitSize == null)
			this.setUnitSize = this.horizontal ? _setUnitElementWidth : _setUnitElementHeight;
	}
	this.InitializeSizes = function(){
		var scrollBarElement = this.GetScrollBarElement();
		if(scrollBarElement != null){
			var width = _getElementWidth(scrollBarElement);
			var height = _getElementHeight(scrollBarElement);
			this.scrollBarSize = this.horizontal ? width : height;
			this.scrollBarButtonSize = this.horizontal ? height : width;
			this.scrollBarClientSize = this.scrollBarSize - 2 * this.scrollBarButtonSize;
			
			this.scrollLargeInc = this.scrollBarSize - 20; 
			this.mouseWheelInc = this.scrollBarSize - 20; 
		}
	}
	
	this.SetScrollableID = function(scrollableID){
		this.scrollableID = scrollableID;
		this.scrollableElement = null;
	}
	this.GetVisibleTop = function(){
		return this.GetPosition();
	}
	this.GetVisibleBottom = function(){
		return this.GetVisibleTop() + this.elementClientSize;
	}
	this.DoScrollBottom = function(){
		this.ChangePosition(100000);
	}
	this.DoScrollTop = function(){
		this.ChangePosition(0);
	}
	this.DoNativeIncButtonClick = function(position){
		if(this.OnIncButtonClick())
			this.ChangePosition(position);
	}
	this.DoNativeDecButtonClick = function(position){
		if(this.OnDecButtonClick())
			this.ChangePosition(position);
	}
	this.DoNativeLargeIncButtonClick = function(position){
		if(this.OnLargeIncButtonClick())
			this.ChangePosition(position);
	}
	this.DoNativeLargeDecButtonClick = function(position){
		if(this.OnLargeDecButtonClick())
			this.ChangePosition(position);
	}
	this.DoNativeThumbMove = function(position){
		this.ChangePosition(position);
		this.OnThumbMove();
	}
	this.DoIncButtonClick = function(){
		if(this.OnIncButtonClick())
			this.ChangePositionBy(this.scrollInc);
	}
	this.DoDecButtonClick = function(){
		if(this.OnDecButtonClick())
			this.ChangePositionBy(-this.scrollInc);
	}
	this.DoLargeIncButtonClick = function(){
		if(this.OnLargeIncButtonClick())
			this.ChangePositionBy(this.scrollLargeInc);
	}
	this.DoLargeDecButtonClick = function(){
		if(this.OnLargeDecButtonClick())
			this.ChangePositionBy(-this.scrollLargeInc);
	}
	this.DoThumbMove = function(position){
		this.ChangePosition(position);
		this.OnThumbMove();
	}
	this.ChangePositionBy = function(delta){
		this.SetPosition(this.position + delta);
		this.OnScroll();
	}
	this.ChangePosition = function(position){
		this.SetPosition(position);
		this.OnScroll();
	}
	this.DoKeyDown = function(e){
		var evt = _getEvent(e);
		switch(evt.keyCode){
			case kbPgUp: case kbHome:
				this.DoScrollTop();
				this.Update(true);
				return krSystem;
			case kbPgDown: case kbEnd:
				this.DoScrollBottom();
				this.Update(true);
				return krSystem;
		}
		return krUnhandled;
	}
	this.DoMouseWheel = function(e){
		var evt = _getEvent(e);
		var inc = (evt.wheelDelta > 0) ? -this.mouseWheelInc : this.mouseWheelInc;
		if(!this.OnMouseWheel())
			this.ChangePositionBy(inc);
	}
	this.GetThumbSize = function(){
		var thumbSize = Math.floor(this.elementClientSize * this.scrollBarClientSize / this.elementScrollSize);
		return (thumbSize > this.thumbMinSize) ? thumbSize : this.thumbMinSize;
	}
	this.GetUpPageBtnSize = function(){
		var thumbSize = this.GetThumbSize();
		return Math.floor(this.position * (this.scrollBarClientSize - thumbSize) / (this.elementScrollSize - this.elementClientSize));
	}
	this.GetDownPageBtnSize = function(){
		var thumbSize = this.GetThumbSize();
		var upPageBtnSize = this.GetUpPageBtnSize();
		return this.scrollBarClientSize - (upPageBtnSize + thumbSize);
	}
	this.GetUpBtnSize = function(upBtn){
		return this.scrollBarButtonSize - (this.getSize(upBtn) - this.getClientSize(upBtn));
	}
	this.GetDownBtnSize = function(downBtn){
		return this.scrollBarButtonSize - (this.getSize(downBtn) - this.getClientSize(downBtn));
	}
	this.SetPageBtnSize = function(element, value) {
		this.setSize(element, value);
		var btnElement = this.horizontal ? element : element.parentElement;
		_setElementDisplay(btnElement, value > 1);
	}
	this.CalculateScrollableElementSizes = function(scrollableElement){
		this.elementScrollSize = this.getScrollSize(scrollableElement);
		this.elementClientSize = this.getClientSize(scrollableElement);
		if(this.elementClientSize == 0)
			this.elementClientSize = this.getSize(scrollableElement);
	}
	this.CalculateBtnSizes = function(){
		var upPageBtn = this.GetUpPageButton();		
		if(upPageBtn != null) this.SetPageBtnSize(upPageBtn, this.GetUpPageBtnSize());	
		var downPageBtn = this.GetDownPageButton();
		if(downPageBtn != null) this.SetPageBtnSize(downPageBtn, this.GetDownPageBtnSize());		
		var thumb = this.GetThumbButton();
		if(thumb != null) this.setSize(thumb, this.GetThumbSize());
		var upBtn = this.GetUpButton();		
		if(upBtn != null) this.setSize(upBtn, this.GetUpBtnSize(upBtn));
		var downBtn = this.GetDownButton();
		if(downBtn != null)	this.setSize(downBtn, this.GetDownBtnSize(downBtn));

		if(this.getSize(thumb) != this.scrollBarSize - (this.getSize(upBtn) + this.getSize(upPageBtn) + this.getSize(downBtn) + this.getSize(downPageBtn)))
			this.setSize(thumb, this.scrollBarSize - (this.getSize(upBtn) + this.getSize(upPageBtn) + this.getSize(downBtn) + this.getSize(downPageBtn)));
	}
	this.MinimizeBtnSizes = function(){
		var upPageBtn = this.GetUpPageButton();		
		if(upPageBtn != null)
			this.setSize(upPageBtn, 0);	
		var downPageBtn = this.GetDownPageButton();
		if(downPageBtn != null)
			this.setSize(downPageBtn, 0);		
		var thumb = this.GetThumbButton();
		if(thumb != null) 
			this.setSize(thumb, 0);
	}
	this.GetVisible = function(){
		var element = this.GetScrollBarElement();
		return (element != null) ? _getElementDisplay(element) : false;
	}
	this.SetVisible = function(visible){
		var element = this.GetScrollBarElement();
		if(element != null) _setElementDisplay(element, visible);
		var mainElement = this.GetScrollBarMainElement();
		if(mainElement != null) _setElementDisplay(mainElement, visible);
	}
	this.IsDisplayed = function(){
		if(this.enabled){
			var element = this.GetScrollBarMainElement();
			if(element != null)
				return _isElementDisplayed(_getParentNode(element));
			var element = this.GetScrollBarElement();
			if(element != null)
				return _isElementDisplayed(_getParentNode(element));
		}
		return false;
	}
	this.SetEnabled = function(enabled){
		var upBtn = this.GetUpButton();		
		if(upBtn != null) upBtn.disabled = !enabled;
		var downBtn = this.GetDownButton();
		if(downBtn != null)	downBtn.disabled = !enabled;
		var upPageBtn = this.GetUpPageButton();		
		if(upPageBtn != null) upPageBtn.disabled = !enabled;
		var downPageBtn = this.GetDownPageButton();
		if(downPageBtn != null) downPageBtn.disabled = !enabled;
		var thumb = this.GetThumbButton();
		if(thumb != null) thumb.disabled = !enabled;
	}
	
	this.GetPosition = function(){
		return this.position;
	}
	this.SetPosition = function(position){
		if(!this.enabled) return;
		this.CheckInitialized();
		if(!this.visible) return;
	
		var scrollableElement = this.GetScrollableElement();	
		if(scrollableElement != null){
			if(!this.nativeRender){
				if(position > this.scrollableSize - this.scrollableSizeLimit) 
					position = this.scrollableSize - this.scrollableSizeLimit;	
				if(position < 0) 
					position = 0;
			}
			if(this.position != position){
				this.position = position;
				if(!this.nativeRender){
					this.setScroll(scrollableElement, this.position);
					this.CalculateBtnSizes();
				}
				else{
					this.setScroll(scrollableElement, this.position);
					var nativeScroller = this.GetNativeScroller();
					if(nativeScroller != null) 
						this.setScroll(nativeScroller, this.position);
				}
				this.StorePosition();
			}
		}
	}
	this.SetSize = function(size){
		if(!this.enabled) return;
		this.CheckInitialized();
	
		var scrollBarElement = this.GetScrollBarElement();
		if(scrollBarElement != null){
			if(!this.nativeRender){
				this.MinimizeBtnSizes();
				if(!size.IsEmpty() && size.type == "px")
					size = size.Inc(- 2 * this.margin);
				this.setUnitSize(scrollBarElement, size);
			}
			else{
				var nativeScroller = this.GetNativeScroller();
				if(nativeScroller != null) 
					this.setUnitSize(nativeScroller, size);
			}
			this.InitializeSizes();
			this.Calculate(true);
		}
	}
	this.Calculate = function(recalculate){
		if(!this.enabled) return;
		this.CheckInitialized();
		
		if(this.scrollBarSize == 0)
			this.InitializeSizes();
			
		var scrollableElement = this.GetScrollableElement();
		if(scrollableElement != null){
			this.CalculateScrollableElementSizes(scrollableElement);

			this.scrollableSize = this.elementScrollSize - this.elementClientSize;	
			this.scrollableSize = this.scrollableSize > 0 ? this.scrollableSize : 0;
			this.visible = this.scrollableSize > this.scrollableSizeLimit;
			
			var scrollBarElement = this.GetScrollBarElement();
			if(scrollBarElement != null){
				this.scrollableRatio = this.elementScrollSize / this.scrollBarClientSize;
				if(this.visible){
					var needRecalculate = !this.GetVisible() || recalculate;
					this.SetVisible(true);
					if(!this.nativeRender){
						this.CalculateBtnSizes();
						this.SetPosition(this.getScroll(scrollableElement));	
					}
					else{
						var nativeScrollable = this.GetNativeScrollable();
						if(nativeScrollable != null){
							this.setSize(nativeScrollable, this.elementScrollSize + (this.scrollBarSize - this.elementClientSize));
							this.SetPosition(this.getScroll(scrollableElement));	
						}
					}
					if(needRecalculate) 
						this.Calculate(false);
				}
				else
					this.SetVisible(false);
			}
		}
		if(this.timer > 0){
			window.clearTimeout(this.timer);
			this.timer = -1;
		}
	}
	this.Update = function(recalculate){
		this.timerRecalculate = recalculate;
		this.timer = window.setTimeout("OnLFSBTimer('" + this.name + "');", 1);
	}

	this.RestorePosition = function(){
		if(this.storePosition){
	 		var element = this.GetScrollableElement(null);	
			if(element != null) this.setScroll(element, this.storedPosition);
		}
	}
	this.StorePosition = function(){
		if(this.storePosition){
			var element = _getElementById(this.name + "Pos");
			if(element != null) element.value = Math.round(this.position);
		}
	}

	this.DecButtonClick = new ASPxClientEvent();
	this.IncButtonClick = new ASPxClientEvent();
	this.LargeDecButtonClick = new ASPxClientEvent();
	this.LargeIncButtonClick = new ASPxClientEvent();
	this.ThumbMove = new ASPxClientEvent();
	this.MouseWheel = new ASPxClientEvent();
	this.Scroll = new ASPxClientEvent();

	this.OnDecButtonClick = function(){
		if(!this.DecButtonClick.IsEmpty()){
			var args = new ASPxClientHandledEventArgs();
			this.DecButtonClick.FireEvent(this, args);
			return !args.handled;
		}
		return true;
	}
	this.OnIncButtonClick = function(){
		if(!this.IncButtonClick.IsEmpty()){
			var args = new ASPxClientHandledEventArgs();
			this.IncButtonClick.FireEvent(this, args);
			return !args.handled;
		}
		return true;
	}
	this.OnLargeDecButtonClick = function(){
		if(!this.LargeDecButtonClick.IsEmpty()){
			var args = new ASPxClientHandledEventArgs();
			this.LargeDecButtonClick.FireEvent(this, args);
			return !args.handled;
		}
		return true;
	}
	this.OnLargeIncButtonClick = function(){
		if(!this.LargeIncButtonClick.IsEmpty()){
			var args = new ASPxClientHandledEventArgs();
			this.LargeIncButtonClick.FireEvent(this, args);
			return !args.handled;
		}
		return true;
	}
	this.OnThumbMove = function(){
		if(!this.ThumbMove.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.ThumbMove.FireEvent(this, args);
		}
	}
	this.OnMouseWheel = function(){
		if(!this.MouseWheel.IsEmpty()){
			var args = new ASPxClientHandledEventArgs();
			this.MouseWheel.FireEvent(this, args);
			return !args.handled;
		}
		return false;
	}
	this.OnScroll = function(){
		var args = new ASPxClientEventArgs();
		this.Scroll.FireEvent(this, args);
	}
	this.OnResize = function(){
		this.CheckRenderInitialized();
	}
		
	GetLookAndFeelScrollBarCollection().Add(this);
}

function _setUnitElementWidth(element, value){
	element.style.width = value.ToString();
}

function _setUnitElementHeight(element, value){
	element.style.height = value.ToString();
}

function _getElementClientWidth(element){
	return element.clientWidth;
}

function _getElementClientHeight(element){
	return element.clientHeight;
}

function _getElementScrollWidth(element){
	return element.scrollWidth;
}

function _getElementScrollHeight(element){
	return element.scrollHeight;
}

function GetLookAndFeelScrollBarCollection(){
	if(__ASPxLookAndFeelScrollBarCollection == null){
		__ASPxLookAndFeelScrollBarCollection = new ASPxClientCollection();
	}
	return __ASPxLookAndFeelScrollBarCollection;
}

function OnLFScrollBarResize(name){
	var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(name);
	if(LFScrollBar != null) LFScrollBar.OnResize();
}

function OnLFSBTimer(name){
	var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(name);
	if(LFScrollBar != null) LFScrollBar.Calculate(LFScrollBar.timerRecalculate);
}

function OnLFSBNativeScroll(name, element){
	var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(name);
	if(LFScrollBar != null){
		var pos = LFScrollBar.getScroll(element);
		if(pos != LFScrollBar.position){
			var evt = _getEvent(null);
			var component = element.componentFromPoint(evt.clientX, evt.clientY);
			switch(component){
				case "scrollbarDown":
				case "scrollbarRight":
					LFScrollBar.DoNativeIncButtonClick(pos);
					break;
				case "scrollbarLeft":
				case "scrollbarUp":
					LFScrollBar.DoNativeDecButtonClick(pos);
					break;
				case "scrollbarPageDown":
				case "scrollbarPageRight":
					LFScrollBar.DoNativeLargeIncButtonClick(pos);
					break;
				case "scrollbarPageUp":
				case "scrollbarPageLeft":
					LFScrollBar.DoNativeLargeDecButtonClick(pos);
					break;
				case "scrollbarHThumb":
				case "scrollbarVThumb":
					LFScrollBar.DoNativeThumbMove(pos);
					break;
				default:
					LFScrollBar.ChangePosition(pos);
					break;
			}
		}
	}
}

function OnLFSBUpdate(name){
	var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(name);
	if(LFScrollBar != null) LFScrollBar.Update(false);
}

function OnLFSBIncButtonClick(name){
	var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(name);
	if(LFScrollBar != null) LFScrollBar.DoIncButtonClick();
}

function OnLFSBDecButtonClick(name){
	var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(name);
	if(LFScrollBar != null) LFScrollBar.DoDecButtonClick();
}

function OnLFSBLIncButtonClick(name){
	var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(name);
	if(LFScrollBar != null) LFScrollBar.DoLargeIncButtonClick();
}

function OnLFSBLDecButtonClick(name){
	var LFScrollBar = GetLookAndFeelScrollBarCollection().Get(name);
	if(LFScrollBar != null) LFScrollBar.DoLargeDecButtonClick();
}

function OnLFSBStartDragging(e, scrollBar){
	draggableLFScrollBar = scrollBar;
	draggableLFScrollBarPosition = scrollBar.position;
	draggableLFScrollBarX = _getEvent(e).clientX;
	draggableLFScrollBarY = _getEvent(e).clientY;
}

function OnLFSBDragging(e, scrollBar){
	var pos = scrollBar.horizontal ? _getEvent(e).clientX : _getEvent(e).clientY;
	var oldPos = scrollBar.horizontal ? draggableLFScrollBarX : draggableLFScrollBarY;
	var newPosition = draggableLFScrollBarPosition + (pos - oldPos) * scrollBar.scrollableRatio;
	scrollBar.DoThumbMove(newPosition);
}

function OnLFSBEndDragging(e, scrollBar){
	draggableLFScrollBar = null;
	draggableLFScrollBarPosition = null;
	draggableLFScrollBarX = 0;
	draggableLFScrollBarY = 0;
}

function LFSBDocumentOnMouseDown(e){
	var evt = _getEvent(e);
	if(!_isLeftMouseButtonPressed(evt)) return;
	var srcElement = _getEventSource(e);
	var scrollBarElement = _getParentByCssClass(srcElement, "LFScrollBar");
	if(scrollBarElement != null){
		var scrollBar = GetLookAndFeelScrollBarCollection().Get(scrollBarElement.id);
		if(scrollBar != null && srcElement == scrollBar.GetThumbButton() && !srcElement.disabled)
			OnLFSBStartDragging(e, scrollBar);
	}
	if(_isExists(savedLFSBDocumentOnMouseDown)) 
		return savedLFSBDocumentOnMouseDown(e);
	return true;
}

function LFSBDocumentOnMouseMove(e){
	if(draggableLFScrollBar != null){
		var evt = _getEvent(e);
		if(!_isLeftMouseButtonPressed(evt))
			OnLFSBEndDragging(e, draggableLFScrollBar);
		else
			OnLFSBDragging(e, draggableLFScrollBar);
	}
	else if(_isExists(savedLFSBDocumentOnMouseMove)) 
		return savedLFSBDocumentOnMouseMove(e);
	return true;
}

function LFSBDocumentOnMouseUp(e){
	if(draggableLFScrollBar != null)
		OnLFSBEndDragging(e, draggableLFScrollBar);
	if(_isExists(savedLFSBDocumentOnMouseUp)) 
		return savedLFSBDocumentOnMouseUp(e);
	return true;
}

function LFSBWindowOnResize(e){
	for(var i = 0; i < GetLookAndFeelScrollBarCollection().elements.length; i++)
		GetLookAndFeelScrollBarCollection().elements[i].Update(true);
	if(_isExists(savedLFSBWindowOnResize)) 
		return savedLFSBWindowOnResize();
	return true;
}

function LFSBDocumentOnSelectStart(e){
	var element = _getEventSource(e);
	if(_getParentByCssClass(element, "LFScrollBar") != null) 
		return false;
	else if(_isExists(savedLFSBDocumentOnSelectStart)) 
		return savedLFSBDocumentOnSelectStart(e);
	return true;
}

var LFSBFirstLoad;
if(typeof(savedLFSBWindowOnLoad) == "undefined"){
	var __ASPxLookAndFeelScrollBarCollection = null;
	var savedLFSBWindowOnLoad = window.onload;
	var savedLFSBDocumentOnMouseDown = null;
	var savedLFSBDocumentOnMouseMove = null;
	var savedLFSBDocumentOnMouseUp = null;
	var savedLFSBWindowOnResize = null;
	var savedLFSBDocumentOnSelectStart = null;
	LFSBFirstLoad = true;
}

window.onload = function(){
	if(LFSBFirstLoad){
		savedLFSBDocumentOnMouseDown = window.document.onmousedown;
		window.document.onmousedown = LFSBDocumentOnMouseDown;
		savedLFSBDocumentOnMouseMove = window.document.onmousemove;
		window.document.onmousemove = LFSBDocumentOnMouseMove;
		savedLFSBDocumentOnMouseUp = window.document.onmouseup;
		window.document.onmouseup = LFSBDocumentOnMouseUp;
		savedLFSBWindowOnResize = window.onresize;
		window.onresize = LFSBWindowOnResize;
		savedLFSBDocumentOnSelectStart = window.document.onselectstart;
		window.document.onselectstart = LFSBDocumentOnSelectStart;
		GetLookAndFeelScrollBarCollection().Initialize(true);
		LFSBFirstLoad = false;
	}
	else
		window.setTimeout("GetLookAndFeelScrollBarCollection().Initialize(false)", 0);
	
	if(_isExists(savedLFSBWindowOnLoad)) 
		return savedLFSBWindowOnLoad();
	return true;
}