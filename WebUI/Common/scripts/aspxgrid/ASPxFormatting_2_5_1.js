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
function ASPxClientFormatting(){
}

TypeNameString = "String";
TypeNameFloat = "Float";
TypeNameInt = "Int";
TypeNameDateTime = "DateTime";
TypeNameBool = "Boolean";
TypeNameUnknown = "Unknown";

var Formatting_NumIntTypes = ["Byte", "Int16", "Int32", "Int64", "SByte", "UInt16", "UInt32", "UInt64"];
var Formatting_NumFloatTypes = ["Currency", "Decimal", "Double", "Single"];
var Formatting_Formatters = new Object();

function IsIntType(typeName) {
	return array_indexOf(Formatting_NumIntTypes, typeName) != -1;
}
function IsFloatType(typeName) {
	return array_indexOf(Formatting_NumFloatTypes, typeName) != -1;
}
function IsIntegerValue(value){
	var expr = /^[-\+]?\d+$/;
	return expr.test(value.toString());
}
function IsFloatValue(value){
	var expr = /^[-\+]?\d+(\.?\d+)?$/;
	return expr.test(value.toString());
}
function IsGuidValue(value){
	var expr = /^[\da-fA-F]{8}-([\da-fA-F]{4}-){3}[\da-fA-F]{12}$/;
	return expr.test(value.toString()); 
}
function GetJSTypeByValue(value){
	if(_isNumber(value)){
		if(IsIntegerValue(value)) 
			return TypeNameInt;
		if(IsFloatValue(value)) 
			return TypeNameFloat;
	}
	else if(_isDate(value))
		return TypeNameDateTime;
	else if(_isBoolean(value))
		return TypeNameBool;
	else if(_isString(value))
		return TypeNameString;
	else
		return TypeNameUnknown; 
}
function GetJSTypeByServerType(type) {
	type = IsIntType(type) ? TypeNameInt : IsFloatType(type) ? TypeNameFloat : type;
	switch(type) {
		case TypeNameString : break;
		case TypeNameInt : break;
		case TypeNameFloat : break;
		case TypeNameDateTime : break;
		case TypeNameBool : break;
		default : type = TypeNameString;
	}
	return type;
}
function GetConvertedValue(value, serverType){
	if(IsFloatType(serverType)){
		if(value == null || (_isString(value) && value == ""))
			return null;
		if(IsFloatValue(value)){
			value = parseFloat(value);
			if(!isNaN(value))
				return value;
		}
	}    
	else if(IsIntType(serverType)){
		if(value == null || (_isString(value) && value == ""))
			return null;
		if(IsIntegerValue(value)){
			value = parseInt(value);
			if(!isNaN(value))
				return value;
		}
	}
	else switch(serverType){
		case "String":
			if(value != null && !_isString(value))
				return value.toString();
			return value;
		case "Guid":
			if(value == null || value == "")
				return null;
			else if(_isString(value)){
				if(IsGuidValue(value)) 
					return value;
			}
			break;
		case "Boolean":
			if(value == null || (_isString(value) && value == ""))
				return null;
			else if(_isBoolean(value))
				return value;
			else if(_isString(value)){
				if(value.toUpperCase() == "TRUE" || value.toUpperCase() == "FALSE")
					return value;
			}
			break;
		case "DateTime":
			if(value == null || (_isString(value) && value == ""))
				return null;
			else if(_isDate(value))
				return value;
			if(_isString(value)){
				value = Date.parse(value);
				if(!isNaN(value))
					return value;
			}
			break;
		default:
			if(value == null || (_isString(value) && value == ""))
				return null;
			return value;
	}
}
function GetFormatter(value, type){
	var jsType = type ? GetJSTypeByServerType(type) : GetJSTypeByValue(value);
	if(!_isExists(Formatting_Formatters[jsType])){
		switch(jsType) {
			case TypeNameInt : 
			case TypeNameFloat : 
				Formatting_Formatters[jsType] = new NumericFormatter();
				break;
			case TypeNameDateTime : 
				Formatting_Formatters[jsType] = new DateFormatter(); 
				break;
			case TypeNameBool : 
				Formatting_Formatters[jsType] = new BoolFormatter(); 
				break;
		}
	}
	return Formatting_Formatters[jsType];
}

function FormatValueInternal(value, format, type, isEditFormat) {
	var formatter = GetFormatter(value, type);
	if(_isExists(formatter))
		return formatter.toString(value, format, isEditFormat);
	else 
		return (value != null) ? value.toString() : "";
}

function FormatValue(value, format, type) {
	var res = "";
	if(!_isExists(value)) return "";
	if(format)
		res = FormatString([value], format, type);
	else {
		res = FormatValueInternal(value, format, type);
	}
	return res;
}
ASPxClientFormatting.FormatValue = function(value, format){
	return FormatValue(value, format, "");
}

function FormatEditValue(value, format, type) {
	return FormatValueInternal(value, format, type, true);
}

function StringBuilder(str) {
	this.str = str;
	this.r = new RegExp("\\{(\\d+):*([^}]*)\\}", "g");
	this.lastIndex = 0;
	this.lengthMatch = 0;
	this.paramIndex = -1;
	this.Mask = "";
		
	this.findNext = function() {
		var ar = this.r.exec(this.str);
		if(ar) {
			this.lastIndex = this.r.lastIndex;
			this.lengthMatch = ar[0].length;
			this.paramIndex = parseInt(ar[1]);
			this.Mask = ar[2];
		}
		return ar;
	}
}

function FormatString(data, format, type) {
	var c = 0;
	var res = "";
	var sb = new StringBuilder(format);
	
	while(sb.findNext()) {
		res += format.substring(c, sb.lastIndex - sb.lengthMatch);
		c = sb.lastIndex;
		if(data[sb.paramIndex] != null && data[sb.paramIndex].toString() != "")
			res += FormatValueInternal(data[sb.paramIndex], sb.Mask, type);
		else
			if(data != null && data.toString() != "")
				res += sb.Mask;
	}
	res += format.substring(c, format.length);
	return res ? res : format.split(":").length > 1 ? res : data[0] != null ? data[0] : "";
}

function ParseValue(str, format, type) {
	if(!_isString(str))
		return str;
	var formatter = GetFormatter(str, type);
	return _isExists(formatter) ? formatter.fromString(str, format, type) : str;
}

function NumericFormatter() {
	this.replacement = null;
	
	this.GetReplacement = function(){
		if(this.replacement == null)
			this.replacement = new NumericReplacement();
		return this.replacement;
	}
	this.GetRegularExpression = function(type){
		return this.IsIntegerType(type) ? /^[-\+]?\d+$/ : /^[-\+]?\d+(\.?\d+)?$/;
	}
	this.fromString = function(str, format, type) {
		if(str == null || str == "")
			return null;
		var replacement = this.GetReplacement();
		return replacement.Parse(str, type);
	}
	this.toString = function(numeric, format, isEditFormat) {
		if(numeric == null || numeric.toString() == "")
			return "";
		var replacement = this.GetReplacement();
		return replacement.toString(numeric, format, isEditFormat);
	}
}
function DateFormatter() {
	this.replacement = null;
	
	this.GetReplacement = function(){
		if(this.replacement == null)
			this.replacement = new DateReplacement();
		return this.replacement;
	}
	this.fromString = function(str, format, type){
		var replacement = this.GetReplacement();
		return replacement.parse(str, format);
	}
	this.toString = function(date, format) {
		if(date == null || date.toString() == "")
			return "";
		var replacement = this.GetReplacement();
		return replacement.toString(date, format);
	}
	
}
function BoolFormatter() {
	this.fromString = function(str, format, type){
		if(str == null || str == "")
			return false;
		else if(str.toString().toUpperCase() == "TRUE")
			return true;
		else if(str.toString().toUpperCase() == "FALSE")
			return false;
		return NaN;
	}
	this.toString = function(value, format) {
		return value ? "True" : "False";
	}
}

function AddLeadZeros(str, n) {
	while(str.length < n)
		str = "0" + str;
	return str;
}
function AddExtZeros(str, n) {
	while(str.length < n)
		str += "0";
	return str;
}