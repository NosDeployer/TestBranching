

function CalendarDay(aDate, aDay, aIsOtherMonth, aSelected){
  this.date = aDate;
  this.day = aDay;
  this.isOtherMonth = aIsOtherMonth;
  this.selected = aSelected;
}
function ASPxClientDateEditBase(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientEditorBase;
	this.inherit(name, dataControllerName, fieldIndex);	

	this.dateFormatInfo = new DateTimeFormatInfo();
	this.showYear = true;
	this.days = new Array();
	this.dateOnError = "Undo";
	this.textModeInput = true;
	this.allowNull = true;
	this.firstDayOfWeek = 0;
	this.selectedDayId = -1;
	this.selectedDate = new Date();
	this.visibleDate = new Date();	
	this.originalDate = new Date();
	
	this.visibleDateChanged = false;
	this.selectedDateChanged = false;
	
	this.dayStyle = ASPxStyle.CreateStyle();
	this.otherMonthDayStyle = ASPxStyle.CreateStyle();
	this.selectedStyle = ASPxStyle.CreateStyle();
	this.dayStylesCache = new Object();

	this.calendarElement = null;
	this.monthElement = null;
	this.weeksElement = null;
	this.inputElement = null;
	this.visibleDateElement = null;
	this.daysElements = new Array();
	this.weeksElements = new Array();
	
	this.GetCalendarElement = function(){
		if(!_isExists(this.calendarElement)){
			if(this.activeElement != null) {
				var LFPopupContainerElement = this.GetLFPopupContainerElement();
				if(LFPopupContainerElement != null) 
					this.calendarElement = LFPopupContainerElement;
				else this.calendarElement = this.activeElement;
			}
		}
		return this.calendarElement;
	}
	this.GetInputElement = function(){
		if(!_isExists(this.inputElement))
			this.inputElement = (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "Input") : null;
		return this.inputElement;
	}
	this.GetVisibleDateElement = function(){
		if(!_isExists(this.visibleDateElement))
			this.visibleDateElement = (this.activeElement != null) ? _getChildById(this.activeElement, this.name + "VisibleDate") : null;
		return this.visibleDateElement;
	}
	this.GetMonthElement = function(){
		if(!_isExists(this.monthElement)){
			var calendarElement = this.GetCalendarElement();
			if(calendarElement != null) 
				this.monthElement = _getChildById(calendarElement, this.name + "Month");
		}
		return this.monthElement;
	}
	this.GetWeeksElement = function(){
		if(!_isExists(this.weeksElement)){
			var calendarElement = this.GetCalendarElement();
			if(calendarElement != null)
				this.weeksElement = _getChildById(calendarElement, this.name + "Weeks");
		}
		return this.weeksElement;
	}
	this.GetWeekElement = function(index){
		if(!_isExists(this.weeksElements[index])){
			var calendarElement = this.GetCalendarElement();
			if(calendarElement != null)
				this.weeksElements[index] = _getChildById(calendarElement, this.name + "Week" + index);
		}
		return this.weeksElements[index];
	}
	this.GetDayElement = function(index){
		if(!_isExists(this.daysElements[index])){
			var calendarElement = this.GetCalendarElement();
			if(calendarElement != null)
				this.daysElements[index] = _getChildById(calendarElement, this.name + "Day" + index);
		}
		return this.daysElements[index];
	}
	this.GetClearButtonElement = function(){
		var calendarElement = this.GetCalendarElement();
		return (calendarElement != null) ? _getChildById(calendarElement, this.name + "Clear") : null;
	}
	this.GetTodayButtonElement = function(){
		var calendarElement = this.GetCalendarElement();
		return (calendarElement != null) ? _getChildById(calendarElement, this.name + "Today") : null;
	}
	
	this.GetLFPopup = function(){
		return null;
	}
	this.GetLFPopupElement = function(){
		return null;
	}
	this.GetLFPopupContainerElement = function(){
		return null;
	}
	this.HidePopup = function(){
	}
	this.ShowPopup = function(){
	}
	
	this.InitSelectedDate = function(){
		if(this.selectedDate == null)
			this.selectedDate = new Date();
	}
	this.StoreOriginalTime = function(date){
		this.originalDate = (date != null) ? new Date(date) : null;
	}
	this.RestoreOriginalTime = function(){
		if(this.selectedDate != null && this.originalDate != null){
			this.selectedDate.setHours(this.originalDate.getHours());
			this.selectedDate.setMinutes(this.originalDate.getMinutes());
			this.selectedDate.setSeconds(this.originalDate.getSeconds());
			this.selectedDate.setMilliseconds(this.originalDate.getMilliseconds());
		}
	}
	this.SetSelectedDateInternal = function(date){
		if(date != null){
			this.InitSelectedDate();
			this.selectedDate.setTime(date);
			this.RestoreOriginalTime();
		}
		else{
			this.selectedDayId = -1;
			this.selectedDate = null;
		}
		this.SetInputElementValue();
	}
	this.SetVisibleDateInternal = function(date){
		var oldVisisbleDate = new Date(this.visibleDate);
		if(date != null)
			this.visibleDate.setTime(date);
		else
			this.visibleDate.setTime(new Date());
		this.SetVisibleDateElementValue();	
	}
	this.SetDateInternal = function(date, changeVisibleDate){
		this.SetSelectedDateInternal(date);
		if(changeVisibleDate)
			this.SetVisibleDateInternal(date);
		this.RedrawCalendar();
		this.CorrectPopupSize();
	}
	this.SelectDay = function(id){
		if(this.enabled && this.editable){
			if(!this.days[id].isOtherMonth)	{
					this.RemoveSelect();
					this.selectedDayId = id;
					this.SetSelectedDateInternal(this.days[id].date);
					this.SetSelect();
					this.selectedDateChanged = true;
			}
			else {
				this.SetDateInternal(this.days[id].date, true);
				this.selectedDateChanged = true;
				this.visibleDateChanged = true;
			}
			this.baseOnChange();
		}
		this.FocusInputElement();
		this.HidePopup();
	}
	this.SelectToday = function(){
		if(this.enabled && this.editable){
			var newDate = new Date();
			if(!this.CompareDates(this.selectedDate, newDate)){
				var oldVisibleDate = new Date(this.visibleDate);
				this.SetDateInternal(newDate, true);
				this.selectedDateChanged = true;
				this.visibleDateChanged = this.IsVisibleDateChanged(oldVisibleDate);
				this.baseOnChange();
			}
		}
		this.FocusInputElement();
		this.HidePopup();
	}
	this.SelectClear = function(){
		if(this.enabled && this.editable){
			this.SetDateInternal(null, false);
			this.selectedDateChanged = true;
			this.baseOnChange();
		}
		this.FocusInputElement();
		this.HidePopup();
	}
	this.ShiftDate = function(offset){
		if(this.enabled && this.editable){
			var date = this.GetDateOfMonth(this.selectedDate, offset);
			this.SetDateInternal(date, true);
			this.selectedDateChanged = true;
			this.visibleDateChanged = true;
			this.baseOnChange();
		}
		this.FocusInputElement();
	}
	this.ShiftDay = function(offset){
		if(this.enabled && this.editable){
			var id = (this.selectedDayId > -1) ? this.selectedDayId + offset : -1;
			if(0 <= id && id < this.days.length){
				if(!this.days[id].isOtherMonth)	{
					this.RemoveSelect();
					this.selectedDayId = id;
					this.SetSelectedDateInternal(this.days[id].date);
					this.SetSelect();
					this.selectedDateChanged = true;
				}
				else {
					this.SetDateInternal(this.days[id].date, true);
					this.selectedDateChanged = true;
					this.visibleDateChanged = true;
				}
			}
			else{
				var newDate = this.selectedDate;
				if(newDate != null)
					newDate.setDate(newDate.getDate() + offset);
				else 
					newDate = new Date();
				this.SetDateInternal(newDate, true);
				this.selectedDateChanged = true;
				this.visibleDateChanged = true;
			}
			this.baseOnChange();
		}
		this.FocusInputElement();
	}
	this.ShiftMonth = function(offset){
		if(this.enabled){
			var newVisibleDate = this.GetDateOfMonth(this.visibleDate, offset);
			this.SetVisibleDateInternal(newVisibleDate);
			this.RedrawCalendar();
			this.CorrectPopupSize();
			this.visibleDateChanged = true;
			this.baseOnChange();
		}
		this.FocusInputElement();
	}
	this.ShiftYear = function(offset){
		if(this.enabled){
			var newVisibleDate = new Date(this.visibleDate);
			newVisibleDate.setFullYear(newVisibleDate.getFullYear() + offset);
			this.SetVisibleDateInternal(newVisibleDate);
			this.RedrawCalendar();
			this.CorrectPopupSize();
			this.visibleDateChanged = true;
			this.baseOnChange();
		}
		this.FocusInputElement();
	}

	this.CorrectPopupSize = function(){
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null)
			LFPopup.CorrectFakePopupContainerSize();
	}
	this.RedrawCalendar = function(){ 
		this.UpdateDays();
		this.RenderMonth();
		this.RenderDays();	
		this.SetSelect();
	}
	this.UpdateDays = function() { 
		var firstDate = this.GetFirstDateOfMonth(this.visibleDate);
		var lastDate = this.GetLastDateOfMonth(this.visibleDate);
		var firstDayOfWeek = this.firstDayOfWeek;
		var lastDayOfWeek = this.firstDayOfWeek - 1;
		if(lastDayOfWeek < 0) lastDayOfWeek = 6;
		var firstDayOffset = firstDate.getDay();
		if(firstDayOffset < 0) firstDayOffset = 6;
		var lastDayOffset = lastDate.getDay();
		if(lastDayOffset < 0) lastDayOffset = 6;
		var prevDate = new Date(this.visibleDate);
		var prevMonthDayCount = this.GetLastDateOfMonth(prevDate.setMonth(prevDate.getMonth() - 1)).getDate();

		this.days = [];
		var i, ADateItem, AIsSelected, currentDate;
		this.selectedDayId = -1;

		if(firstDayOffset != firstDayOfWeek) {
			for(var i = 6; i >= 0; i --) {
				if(firstDayOffset == firstDayOfWeek)  {
					currentDate = new Date(firstDate);
								currentDate.setDate(currentDate.getDate() - i - 1);
					AIsSelected = this.CompareDates(this.selectedDate, currentDate, false);
					if(AIsSelected) this.selectedDayId = this.days.length;
					ADateItem = new CalendarDay(currentDate, (prevMonthDayCount - i), true, AIsSelected);
					this.days[this.days.length] = ADateItem;
				}
				else firstDayOffset ++;
				if(firstDayOffset > 6) firstDayOffset = 0;
			}
		}

		for(var i = 1; i <= lastDate.getDate(); i ++) {
				currentDate = new Date(this.visibleDate.getFullYear(), this.visibleDate.getMonth(), i);
				AIsSelected = this.CompareDates(this.selectedDate, currentDate, false);
				if(AIsSelected) this.selectedDayId = this.days.length;
				ADateItem = new CalendarDay(currentDate, i, false, AIsSelected);
				this.days[this.days.length] = ADateItem;
		}


		if(lastDayOffset != lastDayOfWeek) {
				for(var i = 1; i < 7; i ++) {
						currentDate = new Date(lastDate);
						currentDate.setDate(currentDate.getDate() + i);
						AIsSelected = this.CompareDates(this.selectedDate, currentDate, false);
						if(AIsSelected) this.selectedDayId = this.days.length;
						ADateItem = new CalendarDay(currentDate, i, true, AIsSelected);
						this.days[this.days.length] = ADateItem;

						lastDayOffset ++;
						if(lastDayOffset > 6) lastDayOffset = 0;
						if(lastDayOffset == lastDayOfWeek) break;
				}
		}
	}
	this.GetMonthes = function(index){
		return this.dateFormatInfo.MonthNames[index];
	}
	this.GetDayStyleId = function(selected, otherMonth){
		if(selected)
			return otherMonth ? "SO" : "S";
		else
			return otherMonth ? "O" : "N";
	}
	this.GetDayStyle = function(selected, otherMonth){
		var styleId = this.GetDayStyleId(selected, otherMonth);
		if(!_isExists(this.dayStylesCache[styleId])){
			this.dayStylesCache[styleId] = ASPxStyle.CreateStyle();
			this.dayStylesCache[styleId].MergeStyle(this.dayStyle);
			if(otherMonth)
				this.dayStylesCache[styleId].MergeStyle(this.otherMonthDayStyle);
			if(selected)			
				this.dayStylesCache[styleId].MergeStyle(this.selectedStyle);
		}
		return this.dayStylesCache[styleId];
	}
	this.GetDateOfMonth = function(date, monthOffset){
		var newDate = new Date(date);
		var day = newDate.getDate();
		newDate.setDate(1);
		newDate.setMonth(newDate.getMonth() + monthOffset);
		var tmpDate = new Date(newDate);
		var lastDate = this.GetLastDateOfMonth(tmpDate);
		newDate.setDate(day);
		return (newDate > lastDate) ? lastDate : newDate;
	}
	this.GetFirstDateOfMonth = function(date) {
		var tempDate = new Date(date);
		while(tempDate.getDate() > 1) 
			tempDate.setDate(tempDate.getDate() - 1);
		return tempDate;
	}
	this.GetLastDateOfMonth = function(date) {
		var tempDate = new Date(date);
		do 
			tempDate.setDate(tempDate.getDate() + 1);
		while(tempDate.getDate() != 1);
		tempDate.setDate(tempDate.getDate() - 1);
		return tempDate;
	}
	this.CompareDates = function (date1, date2, compareTime) {
		if(date1 == null || date2 == null) return false;
		var ret = (date1.getFullYear() == date2.getFullYear()) && (date1.getMonth() == date2.getMonth()) && (date1.getDate() == date2.getDate());
		ret = compareTime ? (ret && (date1.getHours() == date2.getHours()) && (date1.getMinutes() == date2.getMinutes()) && (date1.getSeconds() == date2.getSeconds()) && (date1.getMilliseconds() == date2.getMilliseconds())) : ret;
		return ret;
	}
	this.IsVisibleDateChanged = function(oldVisisbleDate){
		return (this.visibleDate.getMonth() !=  oldVisisbleDate.getMonth() || this.visibleDate.getFullYear() !=  oldVisisbleDate.getFullYear());
	}
	
	this.ParseValue = function(value){
		if(value == null || value.toString() == "")
			return null;
		if(typeof(value) == "object")
			return new Date(value);
		return new Date(ParseValue(value.toString(), this.editFormatString, "DateTime"));
	}
	this.GetInputElementValue = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) {
			var valueString = inputElement.value;
			var args = this.OnParseDate(valueString);
			var newDate = (args.handled) ? args.date : ((valueString != "") ? this.ParseValue(valueString) : null);
			if(newDate != null){
				if(!isNaN(newDate)){
					if(!this.CompareDates(newDate, this.selectedDate, true)){
						this.StoreOriginalTime(new Date(newDate));
						this.SetDateInternal(new Date(newDate), true);
					}
				}
				else{
					var message = "The entered value '" + valueString + "' cannot be converted to DateTime type.";
					this.ProcessInvalidDate(message);
				}
			}
			else if(this.selectedDate != null){
				if(this.allowNull){
					this.StoreOriginalTime(null);
					this.SetDateInternal(null, false);
				}
				else
					this.ProcessInvalidDate("The entered value cannot be Null.");
			}
		}
	}
	this.SetInputElementValue = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) {
			inputElement.value = (this.selectedDate != null) ? FormatEditValue(this.selectedDate, this.editFormatString, "") : "";	
		}
	}
	this.SetVisibleDateElementValue = function(){
		var visibleDateElement = this.GetVisibleDateElement();
		if(visibleDateElement != null) {
			visibleDateElement.value = FormatEditValue(this.visibleDate, this.editFormatString, "");	
		}
	}
	this.ProcessInvalidDate = function(message){
		alert(message);
		switch(this.dateOnError){
			case "Today":
				this.SetDateInternal(new Date(), true);
				break;
			case "Null":
				if(this.allowNull)
					this.SetDateInternal(null, false);
				else
					this.SetInputElementValue();
				break;
			case "Undo":
				this.SetInputElementValue();
				break;
		}
		this.needFocus = true;
	}
	
	this.RenderMonth = function() {
		var monthElement = this.GetMonthElement();
		if(monthElement != null) {
			var monthString = this.GetMonthes(this.visibleDate.getMonth());
			if(this.showYear)
				monthString += " " + this.visibleDate.getFullYear();
			_setElementInnerText(monthElement, monthString);
		}
	}
	this.RenderDays = function() {
		var weeksElement = this.GetWeeksElement();
		if(weeksElement != null){
			for(var i = 0; i < 6; i ++) {
				var weekElement = this.GetWeekElement(i);
				if(_isExists(weekElement)){
					if(i * 7 < this.days.length){
						_setElementDisplay(weekElement, true);
						for(var j = 0; j < 7; j ++){
							var dayNumber = i * 7 + j;
							var dayElement = this.GetDayElement(dayNumber);
							if(_isExists(dayElement)){
								_setElementInnerText(dayElement, this.days[dayNumber].day);
								var style = this.GetDayStyle(this.days[dayNumber].selected, this.days[dayNumber].isOtherMonth);
								style.ApplyStyle(dayElement, true);
							}
						}
					}
					else
						_setElementDisplay(weekElement, false);
				}
			}
			this.SetSelect();
		}
	}
	this.RemoveSelect = function() {
		if(this.selectedDayId > -1) {
			var dayElement = this.GetDayElement(this.selectedDayId);
			if(_isExists(dayElement)){
				var style = this.GetDayStyle(false, this.days[this.selectedDayId].isOtherMonth);
				style.ApplyStyle(dayElement, true);
			}
		}
	}
	this.SetSelect = function() {
		if(this.selectedDayId > -1) {
			var dayElement = this.GetDayElement(this.selectedDayId);
			if(_isExists(dayElement)){
				var style = this.GetDayStyle(true, this.days[this.selectedDayId].isOtherMonth);
				style.ApplyStyle(dayElement, true);
			}
		}
	}

	this.SetActiveElement = function(element){
		this.activeElement = element;
		
		this.calendarElement = null;
		this.monthElement = null;
		this.weeksElement = null;
		this.inputElement = null;
		this.visibleDateElement = null;
		array_clear(this.daysElements);
		array_clear(this.weeksElements);
		
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) 
			LFPopup.SetRootElement(this.GetLFPopupElement());
	}
	this.SetEditorInputName = function(){
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.name = this.name;
		var visibleDateElement = this.GetVisibleDateElement();
		if(visibleDateElement != null) visibleDateElement.name = this.name + "VisibleDate";
	}
	
	this.baseDeactivateEditor = this.DeactivateEditor;		
	this.DeactivateEditor = function(){
		if(this.activeElement == null) return;
		this.HidePopup();
		this.baseDeactivateEditor();
	}
	this.EnableCustomEditValue = function(){
		return false;
	}
	this.BindEditValue = function(value, renderValueDirectly){
		if(value == null){
			this.StoreOriginalTime(null);
			this.SetDateInternal(null, true);
		}
		else{
			var newDate = this.ParseValue(value);
			if(isNaN(newDate)) newDate = null;
			this.StoreOriginalTime(new Date(newDate));
			this.SetDateInternal(newDate, true);
		}
	}
	this.FormatViewValue = function(value){
		var date = this.ParseValue(value);
		if(!isNaN(date))
			return FormatValue(date, this.dataFormatString, "");
		return FormatValue(value, this.dataFormatString, this.GetDataType());
	}
	this.GetEditorValue = function(){
		this.GetInputElementValue();
		return (this.selectedDate != null) ? new Date(this.selectedDate) : null;
	}
	this.baseSetEditorReadOnly = this.SetEditorReadOnly;
	this.SetEditorReadOnly = function(value){
		this.baseSetEditorReadOnly(value);
		if(this.textModeInput){
			var inputElement = this.GetInputElement();
			if(inputElement != null) inputElement.readOnly = value;
		}
	}
	this.baseSetEnabled = this.SetEnabled;
	this.SetEnabled = function(enabled){
		this.baseSetEnabled(enabled);
		var inputElement = this.GetInputElement();
		if(inputElement != null) inputElement.disabled  = !enabled;
		var clearButtonElement = this.GetClearButtonElement();
		if(clearButtonElement != null) clearButtonElement.disabled  = !enabled;
		var todayButtonElement = this.GetTodayButtonElement();
		if(todayButtonElement != null) todayButtonElement.disabled  = !enabled;
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) LFPopup.SetEnabled(enabled);
	}
	
	this.baseInitializeControl = this.InitializeControl;
	this.InitializeControl = function(){
		this.CheckPopupsInitialized();
		this.baseInitializeControl();
		this.StoreOriginalTime(this.selectedDate);
		this.GetInputElementValue();
		this.UpdateDays();
	}
	this.baseOnChange = this.OnChange;
	this.OnChange = function(){
		var oldVisibleDate = new Date(this.visibleDate);
		this.GetInputElementValue();
		this.selectedDateChanged = true;
		this.visibleDateChanged = this.IsVisibleDateChanged(oldVisibleDate);
		this.baseOnChange();
	}
	this.RaiseValueChangedEvent = function(){
		var processingMode = "Client";
		if(processingMode == "Client" && this.selectedDateChanged)
			processingMode = this.OnSelectedDateChanged();
		if(processingMode == "Client" && this.visibleDateChanged)
			processingMode = this.OnVisibleMonthChanged();
		this.selectedDateChanged = false;
		this.visibleDateChanged = false;
		return processingMode;
	}
		
	this.baseOnEditorKeyDown = this.OnEditorKeyDown;
	this.OnEditorKeyDown = function(e){
		var evt = _getEvent(e);
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null){
			var ret = LFPopup.DoKeyDown(e);
			if(ret != krUnhandled) return ret;
		}
		if(!this.IsTextEditor()){
			switch(evt.keyCode){
				case kbPgUp:
					this.ShiftDate(-1);
					return krHandled;
				case kbPgDown:
					this.ShiftDate(1);
					return krHandled;
				case kbUp:
					this.ShiftDay(-7);
					return krHandled;
				case kbDown:
					this.ShiftDay(7);
					return krHandled;
				case kbLeft:
					this.ShiftDay(-1);
					return krHandled;
				case kbRight:
					this.ShiftDay(1);
					return krHandled;
				case kbEsc:
					this.SetInputElementValue();
					return krUnhandled;
				case kbTab:
					return krUnhandled;
				default:
					if(!this.IsTextEditor())
						return krHandled;
			}		
		}
		return this.baseOnEditorKeyDown(e);
	}
	this.IsMouseInControl = function(evt){
		var ret = _getIsParent(this.activeElement, _getEventSource(evt));
		if(!ret){
			var LFPopupContainerElement = this.GetLFPopupContainerElement();
			if(LFPopupContainerElement != null)
				ret = _getIsParent(LFPopupContainerElement, _getEventSource(evt));
		}
		return ret;
	}
	this.GetDate = function(){
		var editValue = this.GetEditValue();
		return (editValue != null) ? new Date(editValue) : null;
	}
	this.SetDate = function(date){
		this.SetEditValue(new Date(date));
	}		
	this.SelectedDateChanged = new ASPxClientEvent();		
	this.VisibleMonthChanged = new ASPxClientEvent();
	
	this.OnParseDate = function(dateString){
		return new ASPxClientParseDateEventArgs(dateString);
	}
	this.OnSelectedDateChanged = function(){
		if(!this.SelectedDateChanged.IsEmpty()){
			var args = new ASPxClientSelectedDateChangedEventArgs(this.selectedDate, this.autoPostBack);
			this.SelectedDateChanged.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return this.autoPostBack ? "Server" : "Client";
	}
	this.OnVisibleMonthChanged = function(){
		if(!this.VisibleMonthChanged.IsEmpty()){
			var args = new ASPxClientVisibleMonthChangedEventArgs(this.visibleDate, false);
			this.VisibleMonthChanged.FireEvent(this, args);
			return args.processOnServer ? "Server" : "Client";
		}
		return "Client";
	}
}
function ASPxClientSelectedDateChangedEventArgs(date, processOnServer){
	this.inherit = ASPxClientProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.selectedDate = date;
}
function ASPxClientVisibleMonthChangedEventArgs(date, processOnServer){
	this.inherit = ASPxClientProcessingModeEventArgs;
	this.inherit(processOnServer);
	this.visibleDate = date;
}
function ASPxClientCalendar(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientDateEditBase;
	this.inherit(name, dataControllerName, fieldIndex);	
	
	this.FocusInputElement = function(){
	}
}
function ASPxClientDateEdit(name, dataControllerName, fieldIndex){
	this.inherit = ASPxClientDateEditBase;
	this.inherit(name, dataControllerName, fieldIndex);	

	this.dropedDown = false;
	
	this.FocusControl = function(){
		this.FocusInputElement();
	}
	
	this.DoCloseUp = function(){
		if(this.activeElement == null || !this.dropedDown) return;
		
		this.dropedDown = false;
		this.OnCloseUp();
	}
	this.DoDropDown = function(){
		if(this.activeElement == null || this.dropedDown) return; 
		
		this.dropedDown = true;
		this.FocusInputElement();
		this.OnDropDown();
	}

	this.IsTextEditor = function(){
		return !this.dropedDown;
	}
	this.NeedCorrectEditorSize = function(){
		return true;
	}

	this.GetLFPopup = function(){
		var popupElement = this.GetLFPopupElement();
		return (popupElement != null) ? GetLookAndFeelPopupCollection().Get(popupElement.id) : null;
	}
	this.GetLFPopupElement = function(){
		return (this.activeElement != null) ? _getChildByCssClass(this.activeElement, "LFPopup") : null;
	}
	this.GetLFPopupContainerElement = function(){
		var LFPopup = this.GetLFPopup();
		return (LFPopup != null) ? LFPopup.GetContainerElement() : null;
	}
	this.HidePopup = function(){
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) LFPopup.HidePopup();
	}
	this.ShowPopup = function(){
		var LFPopup = this.GetLFPopup();
		if(LFPopup != null) LFPopup.ShowPopup();
	}		
	this.ParseDate = new ASPxClientEvent();		
	this.CloseUp = new ASPxClientEvent();		
	this.DropDown = new ASPxClientEvent();
	
	this.OnParseDate = function (dateString){
		var args = new ASPxClientParseDateEventArgs(dateString);
		if(!this.ParseDate.IsEmpty())
			this.ParseDate.FireEvent(this, args);
		return args;
	}
	this.OnCloseUp = function(){
		if(!this.CloseUp.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.CloseUp.FireEvent(this, args);
		}
	}
	this.OnDropDown = function(){
		if(!this.DropDown.IsEmpty()){
			var args = new ASPxClientEventArgs();
			this.DropDown.FireEvent(this, args);
		}
	}
}
function ASPxClientParseDateEventArgs(dateString){
	this.inherit = ASPxClientHandledEventArgs;
	this.inherit();
	this.dateString = dateString;
	this.date = null;
}

function OnDEDropDown(name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.DoDropDown();	
}

function OnDECloseUp(name){	
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.DoCloseUp();	
}

function OnDEDayClick(name, id) {
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.SelectDay(id);
}

function OnDEShiftMonth(name, offset) {
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.ShiftMonth(offset);
}

function OnDEShiftYear(name, offset) {
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.ShiftYear(offset);
}

function OnDETodayClick(name) {
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.SelectToday();
}

function OnDEClearClick(name) {
	var editor = GetEditorCollection().Get(name);
	if(editor != null) editor.SelectClear();
}