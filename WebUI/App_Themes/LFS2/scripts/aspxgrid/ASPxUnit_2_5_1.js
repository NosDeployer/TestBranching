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
function ASPxClientUnit(value, type){	
	this.value = (type == "px" || type == "%" || type == "pt" ? Math.round(value) : value);
	
	if(this.value < 0)
		this.value = 0;
	this.type = type;
	
	if(this.type == "")
		this.value = "";
	else
		this.value = value;
	this.Add = ASPxClientUnit.Add;
	this.Inc = ASPxClientUnit.Inc;
	this.Sub = ASPxClientUnit.Sub;
	this.Mul = ASPxClientUnit.Mul;
	this.IsEmpty = ASPxClientUnit.IsEmpty;
	this.Equals = ASPxClientUnit.Equals;
	this.ToString = ASPxClientUnit.ToString;
	this.ConvertToPx = ASPxClientUnit.ConvertToPx;
}

ASPxClientUnit.Add = function(unit){
	if(this.type == unit.type && this.type != "")
		return new ASPxClientUnit(this.value + unit.value, this.type);
	return this;
}
ASPxClientUnit.Inc = function(value){
	if(!this.IsEmpty()){
		value += this.value;
		if(value < 0)
			value = 0;
		return new ASPxClientUnit(value, this.type);	
	}
	return this;
}
ASPxClientUnit.Sub = function(unit){
	if(this.type == unit.type && this.type != ""){
		var newValue = this.value - unit.value;
		if(newValue < 1)
			newValue = 1;
		return new ASPxClientUnit(newValue, this.type);
	}
	return this;
}
ASPxClientUnit.Mul = function(value){
	if(!this.IsEmpty())
		return new ASPxClientUnit(this.value * value, this.type);
	return this;
}
ASPxClientUnit.IsEmpty = function(){
	return this.type == "";
}
ASPxClientUnit.Equals = function(unit){
	return this.type == unit.type && this.value == unit.value;
}
ASPxClientUnit.ToString = function(){
	return this.value + this.type;
}
ASPxClientUnit.Parse = function(str){
	if(_isString(str) && str != ""){
		var val = "";
		var cur = str.substr(0, 1);
		var type = str.substr(1, str.length - 1);
		while(cur >= "0" && cur <= "9"){
			val = val + cur;
			var cur = type.substr(0, 1);
			var type = type.substr(1, type.length - 1);
		}
		type = cur + type;
		if(val != "")
			return new ASPxClientUnit(Number(val), type);
	}
	return null;
}

ASPxClientUnit.ConvertToPx = function(){
	if(this.type == "px" || this.IsEmpty())
		return this;
	if(this.type == "%")
		return new ASPxClientUnit(0, "px");
	var unitConverter = _getUnitConverter();
	unitConverter.style.width = this.ToString();
	return new ASPxClientUnit(unitConverter.offsetWidth, "px");
}

var hundredPercentUnit = new ASPxClientUnit(100, "%");

ASPxClientUnit.GetHundredPercentUnit = function(){
	return hundredPercentUnit;
}