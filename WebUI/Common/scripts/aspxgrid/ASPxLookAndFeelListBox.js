var itemLast = 0;
var itemFirst = 1;
var itemNext = 2;
var itemPrev = 3;
var fakeItemId = "FakeItem";

function ASPxLookAndFeelListBox(name){
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	

	this.inputId = "";
	this.textId = "";
	this.imageId = "";
	this.dropDown = false;
	this.dropedDown = false;	
	this.readOnly = false;
	
	this.lockCount = 0;
	this.selectedIndex = -1;
	this.hotTrackedIndex = -1;
	
	this.highlightColor = "highlight";
	this.highlightTextColor = "highlighttext";
	
	this.hasItemImages = false;
	this.itemImageHeight = null;
	this.itemImageWidth = null;
	
	this.rootElement = null;
	this.topElement = null;
	this.lfPopupContainerElement = null;
	this.lfPopup = null;
	this.lfListBoxElement = null;
	this.lfScrollBar = null;
	this.lfScrollBarElement = null;
	this.inputImageElement = null;
	this.inputTextElement = null;
	this.inputValueElement = null;
	
	this.GetRootElement = function(){
		if(this.rootElement == null)
			this.rootElement = _getElementById(this.name);
		return this.rootElement;
	}
	this.SetRootElement = function(element){
		this.rootElement = element;
		this.topElement = null;
		this.lfPopupContainerElement = null;
		this.lfPopup = null;
		this.lfListBoxElement = null;
		this.lfScrollBar = null;
		this.lfScrollBarElement = null;
		this.inputImageElement = null;
		this.inputTextElement = null;
		this.inputValueElement = null;
		
		var LFScrollBar = this.GetLFScrollBar();
		if(LFScrollBar != null) 
			LFScrollBar.SetRootElement(this.GetLFScrollBarElement());
	}
	this.GetTopElement = function(){
		if(this.topElement == null && this.GetRootElement() != null)
			this.topElement = _getParentNode(this.GetRootElement());
		return this.topElement;
	}
	this.GetLFPopupContainerElement = function(){
		if(this.dropDown && this.lfPopupContainerElement == null && this.GetTopElement() != null)
			this.lfPopupContainerElement = _getParentNode(_getParentNode(this.GetTopElement()));
		return this.lfPopupContainerElement;
	}
	this.GetLFPopup = function(){
		if(this.dropDown && this.lfPopup == null){
			var popupContainerElement = this.GetLFPopupContainerElement();
			this.lfPopup = (popupContainerElement != null) ? popupContainerElement.LFPopup : null;
		}
		return this.lfPopup;
	}
	this.GetLFListBoxElement = function(){
		if(this.lfListBoxElement == null && this.GetRootElement() != null){
			var listBoxCell = this.GetRootElement().rows[0].cells[0];
			this.lfListBoxElement = _getChildByCssClass(listBoxCell, "LFListBox");
		}
		return this.lfListBoxElement;
	}
	this.GetLFListBoxItemsContainerElement = function(){
		var lfListBoxElement = this.GetLFListBoxElement();
		return (lfListBoxElement != null) ? _getFirstChild(lfListBoxElement) : null;
	}
	this.GetFakeItemElement = function(){
		return this.IsFakeItem(0) ? this.GetItems()[0] : null;
	}
	this.GetLFScrollBar = function(){
		if(this.lfScrollBar == null){
			var scrollBarElement = this.GetLFScrollBarElement();
			this.lfScrollBar = (scrollBarElement != null) ? GetLookAndFeelScrollBarCollection().Get(scrollBarElement.id) : null;
		}
		return this.lfScrollBar;
	}
	this.GetLFScrollBarElement = function(){
		if(this.lfScrollBarElement == null && this.GetRootElement() != null){
			var scrollBarCell = this.GetRootElement().rows[0].cells[1];
			this.lfScrollBarElement = _getChildByCssClass(scrollBarCell, "LFScrollBar");
		}
		return this.lfScrollBarElement;
	}
	this.GetInputTextElement = function(){
		if(this.dropDown && this.inputTextElement == null){
			var LFPopup = this.GetLFPopup();
			this.inputTextElement = (LFPopup != null) ? _getChildById(LFPopup.GetRootElement(), this.textId) : null;
		}
		return this.inputTextElement;
	}
	this.GetInputImageElement = function(){
		if(this.dropDown && this.inputImageElement == null){
			var LFPopup = this.GetLFPopup();
			this.inputImageElement = (LFPopup != null) ? _getChildById(LFPopup.GetRootElement(), this.imageId) : null;
		}
		return this.inputImageElement;
	}
	this.GetInputValueElement = function(){
		if(this.inputValueElement == null){
			if(this.dropDown){
				var LFPopup = this.GetLFPopup();
				this.inputValueElement = (LFPopup != null && LFPopup.GetRootElement() != null) ? _getChildById(LFPopup.GetRootElement(), this.inputId) : null;
			}
			else
				this.inputValueElement =  (this.GetRootElement() != null) ? _getChildById(this.GetRootElement(), this.inputId) : null;
		}
		return this.inputValueElement;
	}
	this.GetFocusedTextElement = function(){
		var inputTextElement = this.GetInputTextElement();
		return (inputTextElement != null) ? _getParentByTagName(inputTextElement, "TR") : null;
	}
	this.GetItemElement = function(index){
		if(this.IsFakeItem(index))
			return null;
		else if(0 <= index && index < this.GetItemCount() && !this.IsFakeItem(index))
			return this.GetItems()[index];
		else if(this.GetItemCount() > 0 && this.GetItems()[this.GetItemCount() - 1].id == index.toString())
			return this.GetItems()[this.GetItemCount() - 1];
		return null;
	}
	this.GetItemElementImageUrl = function(itemElement){
		var imageTdElement = (itemElement != null) ? _getChildById(itemElement, "Image") : null;
		var imageElement = (imageTdElement != null) ? _getFirstChild(imageTdElement) : null;
		return (imageElement != null) ? imageElement.src : "";
	}
	this.GetItemElementText = function(itemElement){
		var textElement = (itemElement != null) ? _getChildById(itemElement, "Text") : null;
		var text = (textElement != null) ? _getElementInnerText(textElement) : "";
		return (text != " " ) ? text : "";
	}
	this.GetItemElementValue = function(itemElement){
		return (itemElement != null) ? itemElement.id : -1;
	}
	
	this.GetEnabled = function(){
		var topElement = this.GetTopElement();
		return (topElement != null) ? !topElement.disabled : false;
	}
	
	this.DoItemClick = function(itemElement){
		if(this.GetEnabled() && itemElement.id != this.selectedIndex.toString() && !this.readOnly){
			this.SetSelectedItem(itemElement, true);
			this.OnChange();
		}
		this.HidePopup();	
	}
	this.DoItemMouseOver = function(itemElement){
		if(this.GetEnabled() && itemElement != null){
			this.UpdateSelection(itemElement);
			this.hotTrackedIndex = _parseInt(itemElement.id);
		}
	}

	this.SelectItem = function(itemElement){
		this.ClearSelection();
		if(itemElement != null){
			this.SetSelection(itemElement);
			this.selectedIndex = _parseInt(itemElement.id);
		}
		else
			this.selectedIndex = -1;
		
		this.UpdateScrollBarPosition(itemElement);
	}
	this.Focus = function(){
		var topElement = this.GetTopElement();
		if(topElement != null) _focusElement(topElement)
	}
	this.IsDisplayed = function(){
		return  (this.GetRootElement() != null) ? _isElementDisplayed(this.GetRootElement()) : true;
	}
	this.SetReadOnly = function(value){
		this.readOnly = value;
	}
	this.SetEnabled = function(enabled){
		var inputElement = this.GetInputTextElement();
		if(inputElement != null) inputElement.disabled  = !enabled;
		var LFScrollBar = this.GetLFScrollBar();
		if(LFScrollBar != null) LFScrollBar.SetEnabled(enabled);
	}
	this.HidePopup = function(){
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) LFPopup.HidePopup();
	}
	this.ShowPopup = function(){
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) LFPopup.ShowPopup();
	}
	this.SetSelection = function(element){
		element.style.backgroundColor = this.highlightColor;
		element.style.color = this.highlightTextColor;
	}
	this.ResetSelection = function(element){
		element.style.backgroundColor = ""; 
		element.style.color = ""; 
	}
	this.ClearSelection = function(){
		var hotItemElementIndex = (this.hotTrackedIndex > -1) ? this.hotTrackedIndex : this.selectedIndex;
		var hotItemElement = this.GetItemElement(hotItemElementIndex);
		if(hotItemElement != null) this.ResetSelection(hotItemElement);
		this.hotTrackedIndex = -1;
	}
	this.UpdateSelection = function(itemElement){
		this.ClearSelection();
		if(itemElement != null)
			this.SetSelection(itemElement);
	}
	
	this.DoMouseWheel = function(e){
		var evt = _getEvent(e);
		if(this.dropDown && !this.dropedDown){
			if(evt.wheelDelta > 0)
				this.ChangeSelectedItem(itemPrev);
			else
				this.ChangeSelectedItem(itemNext);
		}
		else{
			var LFScrollBar = this.GetLFScrollBar();
			if(LFScrollBar != null) LFScrollBar.DoMouseWheel(e);
		}
	}
	this.DoKeyDown = function(e, editable){
		var evt = _getEvent(e);
		switch(evt.keyCode){
			case kbUp: 
				this.ChangeSelectedItem(itemPrev);
				return krHandled;
			case kbDown:
				this.ChangeSelectedItem(itemNext);
				return krHandled;
			case kbPgUp: 
				this.ChangeSelectedItem(itemFirst);
				return krHandled;
			case kbPgDown: 
				this.ChangeSelectedItem(itemLast);
				return krHandled;
			case kbHome:
				if(!editable){
					this.ChangeSelectedItem(itemFirst);
					return krHandled;
				}
			case kbEnd:
				if(!editable){
					this.ChangeSelectedItem(itemLast);
					return krHandled;
				}
		}
		return krUnhandled;
	}
	this.DoDropDown = function(){
		this.dropedDown = true;
		this.hotTrackedIndex = -1;
		
		var selectedElement = this.GetItemElement(this.selectedIndex);
		this.UpdateSelection(selectedElement);
		this.UpdateScrollBarPosition(selectedElement);
	}
	this.DoCloseUp = function(){
		this.dropedDown = false;
		var selectedElement = this.GetItemElement(this.selectedIndex);
		this.UpdateSelection(selectedElement);
		this.UpdateScrollBarPosition(selectedElement);
	}
	
	this.BeginUpdate = function(){
		this.lockCount ++;
	}
	this.Update = function(){
		if(this.lockCount > 0) return;
		
		this.RemoveFakeItem();
		this.UpdateItemsId();
		this.UpdateScrollBar();
		this.UpdateListHeight();
		if(this.GetItemCount() == 0)
			this.AddFakeItem();
	}
	this.EndUpdate = function(){
		this.lockCount --;
		if(this.lockCount == 0)
			this.Update();
	}
	this.AddItem = function(value, text, imageUrl){
		var itemsContainerElement = this.GetLFListBoxItemsContainerElement();
		if(itemsContainerElement != null){
			var tr = document.createElement("TR");
			tr.id = value;
			itemsContainerElement.appendChild(tr);
			if(this.hasItemImages){
				var imgTd = document.createElement("TD");
				tr.appendChild(imgTd);
				imgTd.id = "Image";
				imgTd.style.paddingTop = 1;
				imgTd.style.paddingBottom = 1;				
				imgTd.style.paddingLeft = 2;
				imgTd.style.paddingRight = 2;
				var img = document.createElement("IMG");
				imgTd.appendChild(img);
				img.align = "absmiddle";
				img.src = imageUrl;
				if(this.itemImageHeight != null)
					img.height = this.itemImageHeight.ToString();
				if(this.itemImageWidth != null)
					img.width = this.itemImageWidth.ToString();
			}
			var textTd = document.createElement("TD");
			tr.appendChild(textTd);
			textTd.id = "Text";
			textTd.style.paddingLeft = 2;
			textTd.style.paddingRight = 2;
			textTd.style.width = "100%";
			textTd.noWrap = true;
			textTd.innerHTML = _checkSpaces(text) ? "&nbsp;" : text;
		}
		
		this.Update();
	}
	this.RemoveItem = function(value, keepText){
		if(this.selectedIndex == value)
			this.SetSelectedItem(null, !keepText);
		var itemElement = this.GetItemElement(value);
		if(itemElement != null)
			_removeElement(itemElement);

		this.Update();
	}
	this.AddFakeItem = function(){
		var itemsContainerElement = this.GetLFListBoxItemsContainerElement();
		if(itemsContainerElement != null){
			var tr = document.createElement("TR");
			itemsContainerElement.appendChild(tr);
			tr.id = fakeItemId;
			var td = document.createElement("TD");
			tr.appendChild(td);
			td.width = 3000;
		}
	}
	this.RemoveFakeItem = function(){
		var itemElement = this.GetFakeItemElement();
		if(itemElement != null) _removeElement(itemElement);
	}
	this.IsFakeItem = function(index){
		if(this.GetItems() == null)
			return false;
		if(0 <= index && index < this.GetItems().length)
			return this.GetItems()[index].id == fakeItemId;
		return false;
	}
	this.GetItemCount = function(){
		if(this.GetItems() == null) return 0;
		var count = this.GetItems().length;
		return (count == 1 && this.IsFakeItem(0)) ? 0 : count;
	}
	this.GetItems = function(){
		var itemsContainerElement = this.GetLFListBoxItemsContainerElement();
		if(_isExists(itemsContainerElement))
			return itemsContainerElement.rows;
		return null;
	}
	this.GetItemText = function(index){
		if(0 <= index && index < this.GetItemCount() && !this.IsFakeItem(index))
			return this.GetItemElementText(this.GetItems()[index]);
		return "";
	}
	this.GetImageUrl = function(index){
		if(0 <= index && index < this.GetItemCount() && !this.IsFakeItem(index))
			return this.GetItemElementImageUrl(this.GetItems()[index]);
		return "";
	}
	
	this.InitializeControl = function(){
		if(this.dropDown)
			this.CheckPopupsInitialized();
		var inputValueElement = this.GetInputValueElement();
		if(inputValueElement != null) 
			this.SetSelectedIndex(Number(inputValueElement.value));
	}
	this.InitializeControlRender = function(){
		this.InitializeScrolling();
		this.UpdateListHeight();
	}
	this.InitializeScrolling = function(){
		var itemElement = this.GetItemElement(this.selectedIndex);
		if(itemElement != null)
			this.UpdateScrollBarPosition(itemElement);	
	}
	
	this.UpdateItemsId = function(){
		var itemsCount = this.GetItemCount();
		var items = this.GetItems();
		for(var i = 0; i < itemsCount; i ++)
			if(!this.IsFakeItem(i) && items[i].id != "-1")
				items[i].id = i;
	}
	this.UpdateListHeight = function(){
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null){
			var listBoxElement = this.GetLFListBoxElement();
			if(listBoxElement != null) 
				LFPopup.CorrectPopupContainerHeight(_getElementHeight(listBoxElement));
		}
	}
	this.UpdateScrollBar = function(){
		var LFScrollBar = this.GetLFScrollBar();
		if(LFScrollBar != null) LFScrollBar.Calculate(true);
	}
	this.UpdateEditorWidth = function(){
		if(!this.dropDown) return;
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null)
			CorrectLFEditorSize(LFPopup.GetRootElement());
	}
	this.UpdateScrollBarPosition = function(itemElement){
		var LFScrollBar = this.GetLFScrollBar();
		if(LFScrollBar != null && itemElement != null){
			LFScrollBar.CheckInitialized();
			LFScrollBar.CheckRenderInitialized();
			var itemTop = _getElementTop(itemElement);
			var itemBottom = itemTop + _getElementHeight(itemElement);
			if(itemTop < LFScrollBar.GetVisibleTop())
				LFScrollBar.SetPosition(itemTop);
			else if(itemBottom > LFScrollBar.GetVisibleBottom())
				LFScrollBar.SetPosition(itemBottom - (LFScrollBar.GetVisibleBottom() - LFScrollBar.GetVisibleTop()));
		}
	}
	this.UpdateImageUrl = function(imageUrl){
		var inputImageElement = this.GetInputImageElement();
		if(inputImageElement != null) inputImageElement.src = imageUrl;
	}
	this.UpdateText = function(text){
		var inputTextElement = this.GetInputTextElement();
		if(inputTextElement != null) inputTextElement.value = text;
	}
	this.UpdateValue = function(value){
		var inputValueElement = this.GetInputValueElement();
		if(inputValueElement != null) inputValueElement.value = value;
	}
	this.OnResize = function(){
		this.CheckRenderInitialized();
	}
	
	this.ChangeSelectedItem = function(itemCode){
		var LFListBox = this.GetLFListBoxElement();
		if(LFListBox != null){
			if(!this.readOnly){
				var itemCollectionElement = _getFirstChild(LFListBox);
				if(itemCollectionElement != null){
					var index = (this.hotTrackedIndex > -1) ? this.hotTrackedIndex : this.selectedIndex;
					var selectedElement = null;
					switch(itemCode){
						case itemPrev:
							selectedElement = this.GetItemElement(index - 1);
							break;
						case itemNext:
							selectedElement = this.GetItemElement(index + 1);
							break;
						case itemFirst:
							selectedElement = this.GetItemElement(0);
							break;
						case itemLast:
							selectedElement = this.GetItemElement(this.GetItemCount() - 1);
							break;
					}
					if(selectedElement != null){
						this.ClearSelection();
						this.SetSelectedItem(selectedElement, true);
						this.OnChange();
					}
				}
			}
		}
	}
	this.GetSelectedIndex = function(){
		var inputElement = this.GetInputValueElement();
		var value = (inputElement != null) ? _parseInt(inputElement.value) : -1;
	}
	this.SetSelectedIndex = function(index){
		var itemElement = this.GetItemElement(index);
		if(itemElement == null) 
			itemElement = this.GetItemElement(-1);
		if(itemElement != null)
			this.SetSelectedItem(itemElement, true);
	}
	this.SetSelectedIndexByText = function(index){
		var itemElement = this.GetItemElement(index);
		if(itemElement == null) 
			itemElement = this.GetItemElement(-1);
		if(itemElement != null)
			this.SetSelectedItem(itemElement, false);
	}
	this.SetSelectedItem = function(itemElement, changeText){
		this.SelectItem(itemElement);
		
		var itemValue = this.GetItemElementValue(itemElement);
		this.UpdateValue(itemValue);
		var itemImageUrl = this.GetItemElementImageUrl(itemElement);
		this.UpdateImageUrl(itemImageUrl);
		if(changeText){
			var itemText = this.GetItemElementText(itemElement);
			this.UpdateText(itemText);
		}
	}
	this.SetSelectedText = function(text, imageUrl){
		this.SelectItem(null);
		
		this.UpdateImageUrl(imageUrl);
		this.UpdateText(text != null ? text : "");
		this.UpdateValue(-1);
	}
	
	this.Change = new ASPxClientEvent();
	this.OnChange = function(){
		this.UpdateEditorWidth();
		var args = new ASPxClientEventArgs();
		this.Change.FireEvent(this, args);
	}
	
	GeLookAndFeeltListBoxCollection().Add(this);
}

function GeLookAndFeeltListBoxCollection(){
	if(__ASPxLookAndFeelListBoxCollection == null){
		__ASPxLookAndFeelListBoxCollection = new ASPxClientWebCollection();
	}
	return __ASPxLookAndFeelListBoxCollection;
}

function GetLFLBTr(element){
	while(element.tagName != "TR")
		element = _getParentNode(element);
	return element;
}
function OnLFLBResize(name){
	var LFListBox = GeLookAndFeeltListBoxCollection().Get(name);
	if(LFListBox != null) LFListBox.OnResize();
}

function OnLFLBMUp(evt, name){
	var LFListBox = GeLookAndFeeltListBoxCollection().Get(name);
	if(LFListBox != null) {
		var element = GetLFLBTr(_getEventSource(evt));
		LFListBox.DoItemClick(element);
	}
}

function OnLFLBMOver(evt, name){
	var LFListBox = GeLookAndFeeltListBoxCollection().Get(name);
	if(LFListBox != null) {
		var element = GetLFLBTr(_getEventSource(evt));		
		LFListBox.DoItemMouseOver(element);
	}
}

function OnLFLBDropDown(name){
	var LFListBox = GeLookAndFeeltListBoxCollection().Get(name);
	if(LFListBox != null) LFListBox.DoDropDown();
}

function OnLFLBCloseUp(name){
	var LFListBox = GeLookAndFeeltListBoxCollection().Get(name);
	if(LFListBox != null) LFListBox.DoCloseUp();
}

function LFLBDocumentOnSelectStart(e){
	var element = _getEventSource(e);
	if(_getParentByCssClass(element, "LFScrollBox") != null && !_checkTagName(element, "TEXTAREA")) 
		return false;
	else if(_getParentByCssClass(element, "LFListBox") != null) 
		return false;
	else if(_isExists(savedLFLBDocumentOnSelectStart)) 
		return savedLFLBDocumentOnSelectStart(e);
	return true;
}

var LFLBFirstLoad;
if(typeof(savedLFLBWindowOnLoad) == "undefined"){
	var __ASPxLookAndFeelListBoxCollection = null;
	var savedLFLBWindowOnLoad = window.onload;
	var savedLFLBDocumentOnSelectStart = null;
	LFLBFirstLoad = true;	
}

window.onload = function(){
	if(LFLBFirstLoad){
		savedLFLBDocumentOnSelectStart = window.document.onselectstart;
		window.document.onselectstart = LFLBDocumentOnSelectStart;
		GeLookAndFeeltListBoxCollection().Initialize(true);
		LFLBFirstLoad = false;
	}
	else
		window.setTimeout("GeLookAndFeeltListBoxCollection().Initialize(false)", 0);

	if(_isExists(savedLFLBWindowOnLoad)) 
		return savedLFLBWindowOnLoad();
	return true;
}