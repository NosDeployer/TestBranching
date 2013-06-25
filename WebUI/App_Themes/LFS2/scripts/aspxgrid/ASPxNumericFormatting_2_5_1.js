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
function NumericReplacement() {
	this.formatInfo = new NumericFormatInfo();
	this.precision = -1;
	this.standardMaskMakers = [];
	
	this.standardMaskMakers["C"] = function(numericReplacement) {
		if(numericReplacement.precision == -1) 
			numericReplacement.precision = numericReplacement.formatInfo.CurrencyDecimalDigits;
		numericReplacement.numberDecimalSeparator = numericReplacement.formatInfo.CurrencyDecimalSeparator;
		var sDecimalDigits = ",0." + AddExtZeros("", numericReplacement.precision);
		var p = [
			numericReplacement.formatInfo.CurrencySymbol + sDecimalDigits, 
			sDecimalDigits + numericReplacement.formatInfo.CurrencySymbol,
			numericReplacement.formatInfo.CurrencySymbol + " " + sDecimalDigits, 
			sDecimalDigits + " " + numericReplacement.formatInfo.CurrencySymbol
		];
		return p[numericReplacement.formatInfo.CurrencyPositivePattern];
	}
	this.standardMaskMakers["c"] = this.standardMaskMakers["C"];
	this.standardMaskMakers["F"] = function(numericReplacement) {
		var res = "#.";
		if(numericReplacement.precision == -1) 
			numericReplacement.precision = numericReplacement.formatInfo.NumberDecimalDigits;
		res += AddExtZeros("", numericReplacement.precision);
		return res;
	}
	this.standardMaskMakers["f"] = this.standardMaskMakers["F"];
	this.standardMaskMakers["D"] = function(numericReplacement) {
		var res = "";
		if(numericReplacement.precision == -1) 
			numericReplacement.precision = 1;
		res = AddExtZeros("", numericReplacement.precision);
		return res;
	}
	this.standardMaskMakers["d"] = this.standardMaskMakers["D"];
	this.standardMaskMakers["N"] = function(numericReplacement) {
		var res = ",#.";
		if(numericReplacement.precision == -1) 
			numericReplacement.precision = numericReplacement.formatInfo.NumberDecimalDigits;
		res += AddExtZeros("", numericReplacement.precision);
		return res;
	}
	this.standardMaskMakers["n"] = this.standardMaskMakers["N"];
	this.standardMaskMakers["P"] = function(numericReplacement) {
		numericReplacement.num = numericReplacement.num * 100;
		var res = ",0.00%";
		return res;
	}
	this.standardMaskMakers["p"] = this.standardMaskMakers["P"];

	this.currentCurrencyGroupSize = 0;
	this.CurrencyGroupSize = function() {
		var i = this.currentCurrencyGroupSize < this.formatInfo.CurrencyGroupSizes.length ? this.currentCurrencyGroupSize : this.formatInfo.CurrencyGroupSizes.length - 1;
		return this.formatInfo.CurrencyGroupSizes[i];
	}

	this.toString = function(numeric, format, isEditFormat) {
		this.precision = -1;
		this.num = numeric;
		this.numberDecimalSeparator = this.formatInfo.NumberDecimalSeparator;
		format = this.normalFormat(format);
		this.GetFormatData(format);
		if(this.HasSections(format))
			format = this.GetSection(format);
		this.data = this.ApplyFormat(this.data, format);
		return this.data;
	}
	this.GetFormatData = function(format) {
		if(IsFloat(this.num))
			this.data = RoundFloat(this.num, this.getRoundPrecision(format)).toString(10);
		else
			this.data = this.num.toString();
	}
	this.HasSections = function(format) {
		return format.indexOf(";") != -1;
	}
	this.GetSection = function(format) {
		var sections = this.Split(format, ";");
		if(sections[1])
			this.data = this.RemoveSubString(this.data, "-");
		return this.num == 0 ? (sections[2] ? sections[2] : sections[0]) : this.num > 0 ? sections[0] : sections[1];
	}
	this.ApplyFormat = function(data, format) {
		var res = "";
		var dataLeft = data.split(".")[0];
		var dataRight = data.split(".")[1] ? data.split(".")[1] : "";
		var arFormatParts = this.Split(format, ".");
		var formatLeft = arFormatParts[0];
		var formatRight = format.substr(formatLeft.length + 1);
		
		var leftRes = this.formatLeft(dataLeft, formatLeft);
		var rightRes = this.formatRight(dataRight, formatRight);
		rightRes = this.normalRightPart(rightRes);
		res = leftRes + rightRes;
		return res;
	}
	this.normalRightPart = function(rightRes) {
		if(!rightRes)
			return "";
		if(!this.hasDigit(rightRes))
			return rightRes;
		var re = new RegExp("^(\\D)+", "g");
		var ar = re.exec(rightRes);
		var res = rightRes;
		if(ar)
			res = rightRes.substring(0, re.lastIndex) + this.numberDecimalSeparator + rightRes.substr(re.lastIndex);
		else
			res = this.numberDecimalSeparator + rightRes;
		return res;
	}
	this.formatLeft = function(data, format) {
		var res = "";
		var dataPointer = data.length - 1;
		this.isNeedThousandSeparator = format.indexOf(",") != -1;
		this.digitCount = 0;
		if(this.isNeedThousandSeparator) format = this.RemoveSubString(format, ",");
		var formatCh = "";
		var ThousandSeparator = "";
		for(var i = format.length - 1; i >=0; i--) {
			formatCh = format.charAt(i);
			if(format.charAt(i - 1) == "\\") {
				res = format.charAt(i) + res;
				i--;
				continue;
			}
			if(this.isReplacement(formatCh) && dataPointer >= 0) {
				if(this.isHasReplacement(format.substring(0, i))) {
					var lastData = data.charAt(dataPointer);
					if(!(lastData == "0" && !this.hasDigit(res) && formatCh == "#"))
						res = this.addDataWithThousandSeparator(data.charAt(dataPointer)) + res;
					else					
						if(this.isHasZeroReplacement(format.substring(0, i)))
							res = this.addDataWithThousandSeparator(data.charAt(dataPointer)) + res;
					dataPointer--;
				}
				else {
					var lastData = data.substring(0, dataPointer + 1);
					if(!(lastData == "0" && res == "" && formatCh == "#"))
						res = this.addDataWithThousandSeparator(lastData) + res;
					dataPointer = -1;
				}
			}
			else {
				if(this.isHasZeroReplacement(format.substring(0, i - 1)))
					res = formatCh == "#" ? "0" + res : formatCh + res;
				else
					res = formatCh == "#" ? res : formatCh + res;
			}
		}
		return res;
	}
	this.formatRight = function(data, format) {
		var res = "";
		var dataPointer = 0;
		var formatCh = "";
		for(var i = 0; i < format.length; i++) {
			formatCh = format.charAt(i);
			if(formatCh == "\\") {
				res += format.charAt(++i);
				continue;
			}
			if(this.isReplacement(formatCh)) {
				if(dataPointer < data.length) {
					res += data.charAt(dataPointer);
					dataPointer++;
				}
				else
					if(formatCh != "#")
						res += formatCh;
			}
			else {
				res += formatCh;
			}
		}
		return res;
	}
	this.getThousandSeparator = function() {
		if((this.digitCount == this.CurrencyGroupSize())) {
			this.currentCurrencyGroupSize++;
			this.digitCount = 0;
			return this.formatInfo.CurrencyGroupSeparator;
		}
		return "";		
	}
	this.isHasReplacement = function(str) {
		return (str.indexOf("#") != -1 ||
			this.isHasZeroReplacement(str))
	}
	this.isHasZeroReplacement = function(str) {
		return str.indexOf("0") != -1;
	}
	this.isReplacement = function(ch) {
		return (ch == "#" || ch == "0");
	}
	this.hasDigit = function(str) {
		var re = new RegExp("\\d+", "g");
		return re.test(str);
	}
	this.addDataWithThousandSeparator = function(data) {
		var res = "";
		var ThousandSeparator = "";
		for(var i = data.length - 1; i >= 0; i--) {
			res = data.charAt(i) + res;
			this.digitCount++;
			if(this.isNeedThousandSeparator) {
				ThousandSeparator = this.getThousandSeparator();
				if(ThousandSeparator && i != 0) {
					res = ThousandSeparator + res;
				}
			}
		}
		return res;
	}
	this.normalFormat = function(format) {
		var res = format == "" ? "0.###############" : format;
		var re = new RegExp("^([cCpPdDfFnN])(\\d*)$");
		var ar = re.exec(format);
		if(ar) {
			this.precision = ar[2] ? parseInt(ar[2]) : this.precision;
			res = this.standardMaskMakers[ar[1]](this);
		}
		return res;
	}
	this.getRoundPrecision = function(format) {
		if(format.indexOf(".") == -1) return 0;
		var s = format.split(".")[1];
		if(_isExists(s)) {
			var res = s.split("0").length - 1 + s.split("#").length - 1;
			return res;
		}
		return 0;
	}
	this.RemoveSubString = function(str, substr) {
		return str.split(substr).join("");
	}
	this.Split = function(str, div) {
		var res = [""];
		var curIndex = 0;
		for(var i = 0; i < str.length; i++) {
			var ch = str.charAt(i);
			if(ch == "\\") 
				if(i + 1 < str.length)
					if(str.charAt(i + 1) == div) i++;
			if(ch == div) {
				res[++curIndex] = "";
				continue;
			} 
			res[curIndex] += str.charAt(i);
		}
		return res;
	}
	this.Parse = function(str, type) {
		var normalStr = this.NormalStr(str);
		if(IsIntType(type) && IsIntegerValue(normalStr))
			return parseInt(normalStr);
		if(!IsIntType(type) && IsFloatValue(normalStr))
			return parseFloat(normalStr);
		return NaN;
	}
	this.NormalStr = function(str) {
		var normalStr = str;	
		if(normalStr.indexOf(this.formatInfo.NumberDecimalSeparator) != -1) {
			var r = new RegExp("\\" + this.formatInfo.NumberDecimalSeparator);
			normalStr = normalStr.replace(r, ".");
		}
		if(normalStr.indexOf(this.formatInfo.CurrencyDecimalSeparator) != -1) {
			var r = new RegExp("\\" + this.formatInfo.CurrencyDecimalSeparator);
			normalStr = normalStr.replace(r, ".");
		}
		return normalStr;
	}
}

function RoundFloat(num, prec) {
	var mul = Math.pow(10, prec);
	
	return Math.round(num * mul) / mul;
}
function IsFloat(value) {
	return isNaN(value) ? value.indexOf(".") : (value + "").indexOf(".") != -1;
}