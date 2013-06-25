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
function DateReplacement() {
	this.date = new Date();
	this.mask = "";
	this.pointer = 0;
	this.formatInfo = new DateTimeFormatInfo();
	this.numArray = [];
	this.arLexems = null;
	this.curNum = 0;
	this.isNeedParseLex = true;
	this.str = "";
		
	this.findNextLexem = function() {
		var s = this.mask.charAt(this.pointer);
		var res = "";
		
		this.pointer++;
		
		if(s == "'") {
			this.isNeedParseLex = false;
			while(true) {
				var ch = this.mask.charAt(this.pointer);
				if(ch == s || ch == "")
					break;
				res += ch;
				this.pointer++;
			}
			this.pointer++;
		}
		else {
			this.isNeedParseLex = true;
			if(s != "") {
				res = s;
				while(true) {
					var ch = this.mask.charAt(this.pointer);
					if(ch != s)
						break;
					res += ch;
					this.pointer++;
				}
			}
		}
		return res;
	}
	this.normalMask = function() {
		var preDefs = [];
		
		preDefs["d"] = this.formatInfo.ShortDatePattern;
		preDefs["D"] = this.formatInfo.LongDatePattern;
		preDefs["t"] = this.formatInfo.ShortTimePattern;
		preDefs["T"] = this.formatInfo.LongTimePattern;
		preDefs["f"] = this.formatInfo.LongDatePattern + " " + this.formatInfo.ShortTimePattern;
		preDefs["F"] = this.formatInfo.FullDateTimePattern;
		preDefs["g"] = this.formatInfo.ShortDatePattern + " " + this.formatInfo.ShortTimePattern;
		preDefs["G"] = this.formatInfo.ShortDatePattern + " " + this.formatInfo.LongTimePattern;
		preDefs["M"] = this.formatInfo.MonthDayPattern;
		preDefs["m"] = preDefs["M"];
		preDefs["R"] = this.formatInfo.RFC1123Pattern ;
		preDefs["r"] = preDefs["R"];
		this.mask = preDefs[this.mask];
	}
	this.toString = function(date, mask) {
		this.pointer = 0;
		this.numArray = [];
		this.curNum = 0;
		this.isNeedParseLex = true;
		this.str = "";

		this.date = date != null ? new Date(date.valueOf()) : this.date;
		if(isNaN(new Date(this.date))) return "";	
			
		this.mask = mask;
		if(this.mask != null && this.mask.length == 1)
			this.normalMask();
		if(!this.mask)
			this.mask = this.formatInfo.ShortDatePattern;
		var res = "";
		var lex = "";

		while(true){
			var lex = this.findNextLexem();
			if(lex == "")
				break;
			res += this.isNeedParseLex ? this.parseLexem(lex) : lex;
		}
		
		return res;
	}
	this.parseLexem = function(lex) {
			if(!_isExists(this.arLexems)) {
				this.arLexems = [];
				this.arLexems["d"] = this.dLex;
				this.arLexems["dd"] = this.ddLex;
				this.arLexems["MM"] = this.MMLex;
				this.arLexems["yyyy"] = this.yyyyLex;
				this.arLexems["ddd"] = this.dddLex;
				this.arLexems["dddd"] =  this.ddddLex;
				this.arLexems["M"] = this.MLex;
				this.arLexems["MMM"] =  this.MMMLex;
				this.arLexems["MMMM"] =  this.MMMMLex;
				this.arLexems["/"] =  this.slashLex;
				this.arLexems[":"] =  this.colonLex;
				this.arLexems["y"] = this.yLex;
				this.arLexems["yy"] = this.yyLex;
				this.arLexems["h"] = this.hLex;
				this.arLexems["hh"] = this.hhLex;
				this.arLexems["H"] =  this.HLex;
				this.arLexems["HH"] = this.HHLex;
				this.arLexems["m"] = this.mLex;
				this.arLexems["mm"] = this.mmLex;
				this.arLexems["s"] = this.sLex;
				this.arLexems["ss"] =  this.ssLex;
			
				this.arLexems["f"] =  this.fLex;
				this.arLexems["ff"] =  this.ffLex;
				this.arLexems["fff"] =  this.fffLex;
				this.arLexems["ffff"] =  this.ffffLex;
				this.arLexems["fffff"] =  this.fffffLex;
				this.arLexems["ffffff"] =  this.ffffffLex;
				this.arLexems["fffffff"] =  this.fffffffLex;
			
				this.arLexems["tt"] = this.ttLex;
				this.arLexems["t"] = this.tLex;
			
				this.arLexems["g"] = function() { return "A.D." }
				this.arLexems["zzz"] = function(date, formatInfo) { return formatInfo.TimeZoneOffset }
				this.arLexems["z"] = function(date, formatInfo) { return formatInfo.TimeZoneOffset.split(":")[0] }
				this.arLexems["zz"] =  function(date, formatInfo) { 
					return AddLeadZeros(formatInfo.TimeZoneOffset.split(":")[0], 2);
				}
		}
		var res = _isExists(this.arLexems[lex]) ? this.arLexems[lex](this) : lex;
		return res;
	}
	
	this.dLex = function(dateReplacement) {
		return dateReplacement.date.getDate();
	}
	
	this.ddLex = function(dateReplacement) {
		return dateReplacement.date.getDate() > 9 ? dateReplacement.date.getDate() : "0" + (dateReplacement.date.getDate());
	}
	
	this.MMLex = function(dateReplacement) {
		return AddLeadZeros((dateReplacement.date.getMonth() + 1).toString(), 2);
	}

	this.yLex = function(dateReplacement) {
		return dateReplacement.date.getFullYear().toString().substr(2, 4);
	}
	
	this.yyLex = function(dateReplacement) {
		return AddLeadZeros(dateReplacement.date.getFullYear().toString().substr(2, 4), 2);
	}
	
	this.yyyyLex = function(dateReplacement) {
		return AddLeadZeros(dateReplacement.date.getFullYear().toString(), 4);
	}
	
	this.dddLex = function(dateReplacement) {
		return dateReplacement.formatInfo.AbbreviatedDayNames[dateReplacement.date.getDay()];
	}

	this.ddddLex = function(dateReplacement) {
		return dateReplacement.formatInfo.DayNames[dateReplacement.date.getDay()];
	}

	this.MLex = function(dateReplacement) {
		return (dateReplacement.date.getMonth() + 1).toString();
	}

	this.MMMLex = function(dateReplacement) {
		return dateReplacement.formatInfo.AbbreviatedMonthNames[dateReplacement.date.getMonth()];
	}

	this.MMMMLex = function(dateReplacement) {
		return dateReplacement.formatInfo.MonthNames[dateReplacement.date.getMonth()];
	}

	this.slashLex = function(dateReplacement) {
		return dateReplacement.formatInfo.DateSeparator;
	}

	this.colonLex = function(dateReplacement) {
		return dateReplacement.formatInfo.TimeSeparator;
	}

	this.hLex = function(dateReplacement) {
		return (dateReplacement.date.getHours() > 12 ? dateReplacement.date.getHours() - 12 : dateReplacement.date.getHours()).toString();
	}

	this.hhLex = function(dateReplacement) {
		return AddLeadZeros((dateReplacement.date.getHours() > 12 ? dateReplacement.date.getHours() - 12 : dateReplacement.date.getHours()).toString(), 2);
	}

	this.HLex = function(dateReplacement) {
		return dateReplacement.date.getHours();
	}

	this.HHLex = function(dateReplacement) {
		return AddLeadZeros(dateReplacement.date.getHours().toString(), 2);
	}

	this.mLex = function(dateReplacement) {
		return dateReplacement.date.getMinutes().toString();
	}

	this.mmLex = function(dateReplacement) {
		return AddLeadZeros(dateReplacement.date.getMinutes().toString(), 2);
	}

	this.sLex = function(dateReplacement) {
		return dateReplacement.date.getSeconds().toString();
	}

	this.ssLex = function(dateReplacement) {
		return AddLeadZeros(dateReplacement.date.getSeconds().toString(), 2);
	}

	this.fLex = function(dateReplacement) {
		return dateReplacement.getMilliseconds(dateReplacement.date, 1);
	}

	this.ffLex = function(dateReplacement) {
		return dateReplacement.getMilliseconds(dateReplacement.date, 2);
	}

	this.fffLex = function(dateReplacement) {
		return dateReplacement.getMilliseconds(dateReplacement.date, 3);
	}
	
	this.ffffLex = function(dateReplacement) {
		return dateReplacement.getMilliseconds(dateReplacement.date, 4);
	}

	this.fffffLex = function(dateReplacement) {
		return dateReplacement.getMilliseconds(dateReplacement.date, 5);
	}

	this.ffffffLex = function(dateReplacement) {
		return dateReplacement.getMilliseconds(dateReplacement.date, 6);
	}

	this.fffffffLex = function(dateReplacement) {
		return dateReplacement.getMilliseconds(dateReplacement.date, 7);
	}
	this.getMilliseconds = function(date, precision) {
		var mSec = date.getMilliseconds().toString();
		if(precision > 3)
			return AddExtZeros(mSec, precision).substr(0, precision);
		else
			return AddLeadZeros(mSec, precision).substr(0, precision);
	}

	this.ttLex = function(dateReplacement) {
		return dateReplacement.date.getHours() <= 12 ? dateReplacement.formatInfo.AMDesignator : dateReplacement.formatInfo.PMDesignator;
	}

	this.tLex = function(dateReplacement) {
		return dateReplacement.ttLex(dateReplacement).substr(0, 1);
	}

	this.fillNumArray = function(str) {
		var r = /\d{1,4}/g;
		this.numArray = [];
		
		while(true) {
			var ar = r.exec(str);
			if(ar == null)
				break;
			this.numArray.push(ar[0]);
		}
	}
	this.parse = function(str, mask) {
		if(str == "")
			return null;
		this.str = str;
		this.mask = mask;
		this.pointer = 0;
		this.numArray = [];
		this.curNum = 0;
		this.isNeedParseLex = true;
		this.isNeedAssignNow = true;
		this.now = new Date();
		this.yr_num = this.now.getFullYear();
		this.mo_num = 0;
		this.day_num = 1;
		this.hr_num = 0;
		this.min_num = 0;
		this.sec_num = 0;
		this.msec_num = 0;
		
		this.fillNumArray(str);
		
		if(this.mask.length == 1)
			this.normalMask();
		if(!this.mask)
			this.mask = this.formatInfo.ShortDatePattern;
		this.curNum = 0;
		while(true) {
			var lex = this.findNextLexem();
			if(lex == "")
				break;
			this.compLex(lex);
		}
		var date = new Date(this.yr_num, this.mo_num, this.day_num, this.hr_num, this.min_num, this.sec_num);
		date.setMilliseconds(this.msec_num);
		return date;
	}
	
	this.getCurNumValue = function() {
		return this.numArray[this.curNum];
	}
	
	this.compLex = function(lex) {
		switch(lex) {
			case "M" : 
			case "MM" : {
				this.mo_num = this.getCurNumValue() - 1;
				break;
			}
			case "MMM" : {
				this.mo_num = this.findAbbrMonth();
				this.curNum--;
				break;
			}
			case "MMMM" : {
				this.mo_num = this.findMonth();
				this.curNum--;
				break;
			}
			case "d" :
			case "dd" : {
				this.day_num = this.getCurNumValue();
				this.isNeedAssignNow = false;
				break;
			}
			case "y" :
			case "yy" :
			case "yyyy" : {
				this.yr_num = this.GetNormalYear();
				break;
			}
			case "h":
			case "hh":
			case "H":
			case "HH": {
				this.hr_num = this.getCurNumValue();
				this.assignNow();
				break;
			}
			case "m": 	
			case "mm": {
				this.min_num = this.getCurNumValue();
				this.assignNow();
				break;
			}
			case "s": 
			case "ss": {
				this.sec_num = this.getCurNumValue();
				this.assignNow();
				break;
			}
			case "f":
			case "ff":
			case "fff":
			case "ffff":
			case "fffff":
			case "ffffff":
			case "fffffff": {
				this.msec_num = this.getCurNumValue();
				break;
			}
			case "t":
				this.justOneSimbolPMDesignator = true;
				this.fixTime();
				break;
			case "tt": {
				this.justOneSimbolPMDesignator = false;
				this.fixTime();
				break;
			}
			default : this.curNum--;
		}
		this.curNum++;
	}
	this.GetNormalYear = function() {
		var year = this.getCurNumValue();
		if(_isExists(year)){
			if(year.length == 1)
				year = "0" + year;
			if(year.length == 2) {
				for(var i = this.formatInfo.TwoDigitYearMax - 99; i <= this.formatInfo.TwoDigitYearMax; i++) {
					if(i.toString().indexOf(year) == 2)
						return i;
				}
			}
		}
		return year;
	}
	this.fixTime = function() {
		var hr_num = new Number(this.hr_num);
		this.hr_num = this.hasStrPMDesignator() ? 12 + hr_num : hr_num;
	}
	this.assignNow = function() {
		if(this.isNeedAssignNow) {
			this.mo_num = this.now.getMonth();
			this.day_num = this.now.getDate();
		}
	}
	this.hasStrPMDesignator = function() {
		if(this.formatInfo.PMDesignator == "")
			return false;
		var PMDesignatorSimbol = this.justOneSimbolPMDesignator ? this.formatInfo.PMDesignator.substr(0, 1) : this.formatInfo.PMDesignator;
		return this.str.indexOf(PMDesignatorSimbol) != -1;
	}
	this.findHelper = function(ar) {
		for(var i = 0; i < ar.length; i++) 
			if(this.str.indexOf(ar[i]) != -1)
				return i;
	}
	this.findAbbrMonth = function() {
		return this.findHelper(this.formatInfo.AbbreviatedMonthNames);
	}
	this.findMonth = function() {
		return this.findHelper(this.formatInfo.MonthNames);
	}
}