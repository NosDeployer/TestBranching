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

function ASPxLookAndFeel(lfKind, lfUseHotTrackStyle, lfUsePressedStyle){
	this.Kind = lfKind;
	this.UseHotTrackStyle = lfUseHotTrackStyle;
	this.UsePressedStyle = lfUsePressedStyle;
	
	this.UseDefaultLookAndFeel = function(){
		return (this.Kind == 0);
	}
}

function GetLookAndFeelByCode(lfCode){
	if(lfCode == -1) return null;
	
	var lfUsePressedStyle = lfCode >= 100;
	lfCode = lfCode % 100;
	var lfUseHotTrackStyle = lfCode >= 10;
	lfCode = lfCode % 10;
	var lfKind = lfCode;
	return new ASPxLookAndFeel(lfKind, lfUseHotTrackStyle, lfUsePressedStyle);
}

function GetCodeByLookAndFeel(lookAndFeel){
	if(lookAndFeel == null) return -1;
	
	var code = lookAndFeel.Kind;
	if(lookAndFeel.UseHotTrackStyle) code += 10;
	if(lookAndFeel.UsePressedStyle) code += 100;
	return code;
}

function GetBooleanExString(value){
	if(value == true)
		return "true";
	else if(value == false)
		return "false";
	return "null";
}

function GetStyleName(registerID){
	return registerID + "S";
}
function GetHotTrackedStyleName(registerID){
	return registerID + "HS";
}
function GetPressedStyleName(registerID){
	return registerID + "PS";
}

function ASPxLookAndFeelStyle(name){
	this.inherit = ASPxStyle;
	this.inherit();	
	this.name = name;
	
	this.Initialize();
	GetLookAndFeelStyleCollection().Add(this);
}

function ASPxLookAndFeelStyleCollection(){
	this.inherit = ASPxClientCollection;
	this.inherit();
	
	this.stdStyle3DKindStyles = new ASPxLookAndFeelStyle3DKindStdStyles();
	this.stdFlatKindStyles = new ASPxLookAndFeelFlatKindStdStyles();
	this.stdHotFlatKindStyles = new ASPxLookAndFeelHotFlatKindStdStyles();
	this.stdUltraFlatKindStyles = new ASPxLookAndFeelUltraFlatKindStdStyles();
	this.stdOffice11KindStyles = new ASPxLookAndFeelOffice11KindStdStyles();
	this.stdCustomKindStyles = new ASPxLookAndFeelKindStdStyles();
	
	this.defaultKind = 0;
	this.defaultButtonStyle = ASPxStyle.CreateStyle();
	this.defaultButtonHotTrackStyle = ASPxStyle.CreateStyle();
	this.defaultButtonPressedStyle = ASPxStyle.CreateStyle();
	this.defaultEditorStyle = ASPxStyle.CreateStyle();
	this.defaultLabelStyle = ASPxStyle.CreateStyle();
	this.defaultPopupStyle = ASPxStyle.CreateStyle();
	this.defaultScrollBarButtonStyle = ASPxStyle.CreateStyle();
	this.defaultScrollBarButtonHotTrackStyle = ASPxStyle.CreateStyle();
	this.defaultScrollBarButtonPressedStyle = ASPxStyle.CreateStyle();
	
	this.GetStdStyles = function(lookAndFeel){
		var kind = (lookAndFeel.Kind > 0) ? lookAndFeel.Kind : this.defaultKind;
		switch(kind){
			case 0: 
				return this.stdFlatKindStyles;
			case 1: 
				return this.stdStyle3DKindStyles;
			case 2: 
				return this.stdFlatKindStyles;
			case 3: 
				return this.stdHotFlatKindStyles;
			case 4: 
				return this.stdUltraFlatKindStyles;
			case 5: 
				return this.stdOffice11KindStyles;
			default: 
				return this.stdCustomKindStyles;
		}
	}
	this.MergeCustomStyle = function(style, name){
		var customStyle = this.Get(name);
		if(customStyle != null)
			style.MergeStyle(customStyle);
	}

	this.GetButtonStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetButtonStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultButtonStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetButtonHotTrackStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetButtonHotTrackStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultButtonHotTrackStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetButtonPressedStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetButtonPressedStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultButtonPressedStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetEditorStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetEditorStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultEditorStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetLabelStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetLabelStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultLabelStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetScrollBarButtonStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetButtonStyle());
			if(lookAndFeel.UseDefaultLookAndFeel()){
				style.MergeStyle(this.defaultButtonStyle);
				style.MergeStyle(this.defaultScrollBarButtonStyle);
			}
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetScrollBarButtonHotTrackStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetButtonHotTrackStyle());
			if(lookAndFeel.UseDefaultLookAndFeel()){
				style.MergeStyle(this.defaultButtonHotTrackStyle);
				style.MergeStyle(this.defaultScrollBarButtonHotTrackStyle);
			}
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetScrollBarButtonPressedStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetButtonPressedStyle());
			if(lookAndFeel.UseDefaultLookAndFeel()){
				style.MergeStyle(this.defaultButtonPressedStyle);
				style.MergeStyle(this.defaultScrollBarButtonPressedStyle);
			}
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetStandaloneButtonStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetStandaloneButtonStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultButtonStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetStandaloneButtonHotTrackStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetStandaloneButtonHotTrackStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultButtonHotTrackStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetStandaloneButtonPressedStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetStandaloneButtonPressedStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultButtonPressedStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetDraggedElementStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetDraggedElementStyle());
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetDataItemStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetLabelStyle());
			style.MergeStyle(stdStyles.GetDataItemStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultLabelStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style.GetBorderLessStyle();
	}
	this.GetDataCellStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetDataCellStyle());
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style.GetBorderLessStyle();
	}
	this.GetGroupItemStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetLabelStyle());
			style.MergeStyle(stdStyles.GetGroupItemStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultLabelStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style.GetBorderLessStyle();
	}
	this.GetPreviewStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetLabelStyle());
			style.MergeStyle(stdStyles.GetPreviewStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultLabelStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style.GetBorderLessStyle();
	}
	this.GetFooterStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetFooterStyle());
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetFooterCellStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetEditorStyle());
			style.MergeStyle(stdStyles.GetFooterCellStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultEditorStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetSearchItemStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetSearchItemStyle());
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
	this.GetSearchEditorStyle = function(name, lookAndFeel){
		if(lookAndFeel == null) return null;
		
		var style = this.Get(name + "Complete");
		if(style == null){
			style = new ASPxLookAndFeelStyle(name + "Complete");
			var stdStyles = this.GetStdStyles(lookAndFeel);
			style.MergeStyle(stdStyles.GetEditorStyle());
			style.MergeStyle(stdStyles.GetSearchEditorStyle());
			if(lookAndFeel.UseDefaultLookAndFeel())
				style.MergeStyle(this.defaultEditorStyle);
			this.MergeCustomStyle(style, name);
			this.Add(style);
		}
		return style;
	}
}

function ASPxLookAndFeelKindStdStyles(){
	this.stdButtonStyle = null;
	this.stdButtonHotTrackStyle = null;
	this.stdButtonPressedStyle = null;
	this.stdEditorStyle = null;
	this.stdLabelStyle = null;
	this.stdPopupStyle = null;
	this.stdStandaloneButtonStyle = null;
	this.stdStandaloneButtonHotTrackStyle = null;
	this.stdStandaloneButtonPressedStyle = null;
	this.stdDraggedElementStyle = null;
	this.stdDataItemStyle = null;
	this.stdDataCellStyle = null;
	this.stdGroupItemStyle = null;
	this.stdPreviewStyle = null;
	this.stdFooterStyle = null;
	this.stdFooterCellStyle = null;
	this.stdSearchItemStyle = null;
	this.stdSearchEditorStyle = null;

	this.GetButtonStyle = function(){
		if(this.stdButtonStyle == null)
			this.CreateStdButtonStyle();
		return this.stdButtonStyle;
	}
	this.GetButtonHotTrackStyle = function(){
		if(this.stdButtonHotTrackStyle == null)
			this.CreateStdButtonHotTrackStyle();
		return this.stdButtonHotTrackStyle;
	}
	this.GetButtonPressedStyle = function(){
		if(this.stdButtonPressedStyle == null)
			this.CreateStdButtonPressedStyle();
		return this.stdButtonPressedStyle;
	}
	this.GetEditorStyle = function(){
		if(this.stdEditorStyle == null)
			this.CreateStdEditorStyle();
		return this.stdEditorStyle;
	}
	this.GetLabelStyle = function(){
		if(this.stdLabelStyle == null)
			this.CreateStdLabelStyle();
		return this.stdLabelStyle;
	}
	this.GetStandaloneButtonStyle = function(){
		if(this.stdStandaloneButtonStyle == null)
			this.CreateStdStandaloneButtonStyle();
		return this.stdStandaloneButtonStyle;
	}
	this.GetStandaloneButtonHotTrackStyle = function(){
		if(this.stdStandaloneButtonHotTrackStyle == null)
			this.CreateStdStandaloneButtonHotTrackStyle();
		return this.stdStandaloneButtonHotTrackStyle;
	}
	this.GetStandaloneButtonPressedStyle = function(){
		if(this.stdStandaloneButtonPressedStyle == null)
			this.CreateStdStandaloneButtonPressedStyle();
		return this.stdStandaloneButtonPressedStyle;
	}
	this.GetDraggedElementStyle = function(){
		if(this.stdDraggedElementStyle == null)
			this.CreateStdDraggedElementStyle();
		return this.stdDraggedElementStyle;
	}
	this.GetDataItemStyle = function(){
		if(this.stdDataItemStyle == null)
			this.CreateStdDataItemStyle();
		return this.stdDataItemStyle;
	}
	this.GetDataCellStyle = function(){
		if(this.stdDataCellStyle == null)
			this.CreateStdDataCellStyle();
		return this.stdDataCellStyle;
	}
	this.GetGroupItemStyle = function(){
		if(this.stdGroupItemStyle == null)
			this.CreateStdGroupItemStyle();
		return this.stdGroupItemStyle;
	}
	this.GetPreviewStyle = function(){
		if(this.stdPreviewStyle == null)
			this.CreateStdPreviewStyle();
		return this.stdPreviewStyle;
	}
	this.GetFooterStyle = function(){
		if(this.stdFooterStyle == null)
			this.CreateStdFooterStyle();
		return this.stdFooterStyle;
	}
	this.GetFooterCellStyle = function(){
		if(this.stdFooterCellStyle == null)
			this.CreateStdFooterCellStyle();
		return this.stdFooterCellStyle;
	}
	this.GetSearchItemStyle = function(){
		if(this.stdSearchItemStyle == null)
			this.CreateStdSearchItemStyle();
		return this.stdSearchItemStyle;
	}
	this.GetSearchEditorStyle = function(){
		if(this.stdSearchEditorStyle == null)
			this.CreateStdSearchEditorStyle();
		return this.stdSearchEditorStyle;
	}
	
	this.CreateStdButtonStyle = function(){
		this.stdButtonStyle = ASPxStyle.CreateStyle();
		this.stdButtonStyle.attributes["textAlign"]="Center";
	}
	this.CreateStdButtonHotTrackStyle = function(){
		this.stdButtonHotTrackStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdButtonPressedStyle = function(){
		this.stdButtonPressedStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdEditorStyle = function(){
		this.stdEditorStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdLabelStyle = function(){
		this.stdLabelStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdStandaloneButtonStyle = function(){
		this.stdStandaloneButtonStyle = this.GetButtonStyle();
	}
	this.CreateStdStandaloneButtonHotTrackStyle = function(){
		this.stdStandaloneButtonHotTrackStyle = this.GetButtonHotTrackStyle();
	}
	this.CreateStdStandaloneButtonPressedStyle = function(){
		this.stdStandaloneButtonPressedStyle = this.GetButtonPressedStyle();
	}
	this.CreateStdDraggedElementStyle = function(){
		this.stdDraggedElementStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdDataItemStyle = function(){
		this.stdDataItemStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdDataCellStyle = function(){
		this.stdDataCellStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdGroupItemStyle = function(){
		this.stdGroupItemStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdPreviewStyle = function(){
		this.stdPreviewStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdFooterStyle = function(){
		this.stdFooterStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdFooterCellStyle = function(){
		this.stdFooterCellStyle = ASPxStyle.CreateStyle();
	}
	this.CreateStdSearchItemStyle = function(){
		this.stdSearchItemStyle = ASPxStyle.CreateStyle();
		this.stdSearchItemStyle.attributes["verticalAlign"]="center";
	}
	this.CreateStdSearchEditorStyle = function(){
		this.stdSearchEditorStyle = ASPxStyle.CreateStyle();
	}
}

function ASPxLookAndFeelStyle3DKindStdStyles(){
	this.inherit = ASPxLookAndFeelKindStdStyles;
	this.inherit();	

	this.CreateStdButtonStyle = function(){
		this.stdButtonStyle = ASPxStyle.CreateStyle();
		this.stdButtonStyle.attributes["backgroundColor"]="buttonface";
		this.stdButtonStyle.attributes["borderColor"]="buttonhighlight";
		this.stdButtonStyle.attributes["borderStyle"]="Outset";
		this.stdButtonStyle.attributes["borderWidth"]="2px";
		this.stdButtonStyle.attributes["textAlign"]="Center";
	}
	this.CreateStdButtonHotTrackStyle = function(){
		this.stdButtonHotTrackStyle = ASPxStyle.CreateStyle();
		this.stdButtonHotTrackStyle.attributes["borderStyle"]="Solid";
		this.stdButtonHotTrackStyle.attributes["borderLeftColor"]="buttonhighlight";
		this.stdButtonHotTrackStyle.attributes["borderTopColor"]="buttonhighlight";
		this.stdButtonHotTrackStyle.attributes["borderRightColor"]="threeddarkshadow";
		this.stdButtonHotTrackStyle.attributes["borderBottomColor"]="threeddarkshadow";
	}
	this.CreateStdButtonPressedStyle = function(){
		this.stdButtonPressedStyle = ASPxStyle.CreateStyle();
		this.stdButtonPressedStyle.attributes["borderColor"]="buttonhighlight";
		this.stdButtonPressedStyle.attributes["borderStyle"]="Inset";
		this.stdButtonPressedStyle.attributes["borderWidth"]="2px";
	}
	this.CreateStdEditorStyle = function(){
		this.stdEditorStyle = ASPxStyle.CreateStyle();
		this.stdEditorStyle.attributes["backgroundColor"]="window";
		this.stdButtonStyle.attributes["borderColor"]="buttonhighlight";
		this.stdEditorStyle.attributes["borderWidth"]="2px";
		this.stdEditorStyle.attributes["borderStyle"]="Inset";
	}
	this.CreateStdDraggedElementStyle = function(){
		this.stdDraggedElementStyle = ASPxStyle.CreateStyle();
		this.stdDraggedElementStyle.attributes["backgroundColor"]="buttonshadow";
		this.stdDraggedElementStyle.attributes["filter"]="progid:DXImageTransform.Microsoft.Alpha(Style=0, Opacity=60)"; 
	}
	this.CreateStdGroupItemStyle = function(){
		this.stdGroupItemStyle = ASPxStyle.CreateStyle();
		this.stdGroupItemStyle.attributes["backgroundColor"]="buttonface";
	}
	this.CreateStdPreviewStyle = function(){
		this.stdPreviewStyle = ASPxStyle.CreateStyle();
		this.stdPreviewStyle.attributes["color"]="blue";
	}
	this.CreateStdFooterStyle = function(){
		this.stdFooterStyle = ASPxStyle.CreateStyle();
		this.stdFooterStyle.attributes["backgroundColor"]="buttonface";
	}
	this.CreateStdFooterCellStyle = function(){
		this.stdFooterCellStyle = ASPxStyle.CreateStyle();
		this.stdFooterCellStyle.attributes["backgroundColor"]="buttonface";
	}
	this.CreateStdSearchItemStyle = function(){
		this.stdSearchItemStyle = ASPxStyle.CreateStyle();
		this.stdSearchItemStyle.attributes["backgroundColor"]="buttonface";
		this.stdSearchItemStyle.attributes["verticalAlign"]="center";
	}
}

function ASPxLookAndFeelFlatKindStdStyles(){
	this.inherit = ASPxLookAndFeelKindStdStyles;
	this.inherit();	

	this.CreateStdButtonStyle = function(){
		this.stdButtonStyle = ASPxStyle.CreateStyle();
		this.stdButtonStyle.attributes["backgroundColor"]="buttonface";
		this.stdButtonStyle.attributes["borderColor"]="buttonshadow";
		this.stdButtonStyle.attributes["borderStyle"]="Solid";
		this.stdButtonStyle.attributes["borderWidth"]="1px";
		this.stdButtonStyle.attributes["textAlign"]="Center";		
		this.stdButtonStyle.attributes["borderLeftColor"]="buttonhighlight";
		this.stdButtonStyle.attributes["borderTopColor"]="buttonhighlight";
		this.stdButtonStyle.attributes["borderRightColor"]="buttonshadow";
		this.stdButtonStyle.attributes["borderBottomColor"]="buttonshadow";
	}
	this.CreateStdButtonHotTrackStyle = function(){
		this.stdButtonHotTrackStyle = ASPxStyle.CreateStyle();
		this.stdButtonHotTrackStyle.attributes["borderStyle"]="Solid";
		this.stdButtonHotTrackStyle.attributes["borderWidth"]="1px";
		this.stdButtonHotTrackStyle.attributes["borderLeftColor"]="buttonhighlight";
		this.stdButtonHotTrackStyle.attributes["borderTopColor"]="buttonhighlight";
		this.stdButtonHotTrackStyle.attributes["borderRightColor"]="threeddarkshadow";
		this.stdButtonHotTrackStyle.attributes["borderBottomColor"]="threeddarkshadow";
	}
	this.CreateStdButtonPressedStyle = function(){
		this.stdButtonPressedStyle = ASPxStyle.CreateStyle();
		this.stdButtonPressedStyle.attributes["borderStyle"]="Solid";
		this.stdButtonPressedStyle.attributes["borderWidth"]="1px";
		this.stdButtonPressedStyle.attributes["borderLeftColor"]="threeddarkshadow";
		this.stdButtonPressedStyle.attributes["borderTopColor"]="threeddarkshadow";
		this.stdButtonPressedStyle.attributes["borderRightColor"]="buttonhighlight";
		this.stdButtonPressedStyle.attributes["borderBottomColor"]="buttonhighlight";
	}
	this.CreateStdEditorStyle = function(){
		this.stdEditorStyle = ASPxStyle.CreateStyle();
		this.stdEditorStyle.attributes["backgroundColor"]="window";
		this.stdEditorStyle.attributes["borderStyle"]="Solid";
		this.stdEditorStyle.attributes["borderWidth"]="1px";
		this.stdEditorStyle.attributes["borderLeftColor"]="buttonshadow";
		this.stdEditorStyle.attributes["borderTopColor"]="buttonshadow";
		this.stdEditorStyle.attributes["borderRightColor"]="buttonface";
		this.stdEditorStyle.attributes["borderBottomColor"]="buttonface";
	}
	this.CreateStdDraggedElementStyle = function(){
		this.stdDraggedElementStyle = ASPxStyle.CreateStyle();
		this.stdDraggedElementStyle.attributes["backgroundColor"]="buttonshadow";
		this.stdDraggedElementStyle.attributes["filter"]="progid:DXImageTransform.Microsoft.Alpha(Style=0, Opacity=60)"; 
	}
	this.CreateStdGroupItemStyle = function(){
		this.stdGroupItemStyle = ASPxStyle.CreateStyle();
		this.stdGroupItemStyle.attributes["backgroundColor"]="buttonface";
	}
	this.CreateStdPreviewStyle = function(){
		this.stdPreviewStyle = ASPxStyle.CreateStyle();
		this.stdPreviewStyle.attributes["color"]="blue";
	}
	this.CreateStdFooterStyle = function(){
		this.stdFooterStyle = ASPxStyle.CreateStyle();
		this.stdFooterStyle.attributes["backgroundColor"]="buttonface";
	}
	this.CreateStdFooterCellStyle = function(){
		this.stdFooterCellStyle = ASPxStyle.CreateStyle();
		this.stdFooterCellStyle.attributes["backgroundColor"]="buttonface";
		this.stdFooterCellStyle.attributes["borderLeftColor"]="buttonshadow";
		this.stdFooterCellStyle.attributes["borderTopColor"]="buttonshadow";
		this.stdFooterCellStyle.attributes["borderRightColor"]="buttonhighlight";
		this.stdFooterCellStyle.attributes["borderBottomColor"]="buttonhighlight";
	}
	this.CreateStdSearchItemStyle = function(){
		this.stdSearchItemStyle = ASPxStyle.CreateStyle();
		this.stdSearchItemStyle.attributes["backgroundColor"]="buttonface";
		this.stdSearchItemStyle.attributes["verticalAlign"]="center";
	}
	this.CreateStdSearchEditorStyle = function(){
		this.stdSearchEditorStyle = ASPxStyle.CreateStyle();
		this.stdSearchEditorStyle.attributes["borderLeftColor"]="buttonshadow";
		this.stdSearchEditorStyle.attributes["borderTopColor"]="buttonshadow";
		this.stdSearchEditorStyle.attributes["borderRightColor"]="buttonhighlight";
		this.stdSearchEditorStyle.attributes["borderBottomColor"]="buttonhighlight";
	}
}

function ASPxLookAndFeelHotFlatKindStdStyles(){
	this.inherit = ASPxLookAndFeelFlatKindStdStyles;
	this.inherit();	

	this.CreateStdButtonStyle = function(){
		this.stdButtonStyle = ASPxStyle.CreateStyle();
		this.stdButtonStyle.attributes["backgroundColor"]="buttonface";
		this.stdButtonStyle.attributes["borderColor"]="buttonshadow";
		this.stdButtonStyle.attributes["borderStyle"]="Solid";
		this.stdButtonStyle.attributes["borderWidth"]="1px";
		this.stdButtonStyle.attributes["textAlign"]="Center";		
		this.stdButtonStyle.attributes["borderColor"]="buttonshadow";
	}
	this.CreateStdButtonHotTrackStyle = function(){
		this.stdButtonHotTrackStyle = ASPxStyle.CreateStyle();
		this.stdButtonHotTrackStyle.attributes["borderStyle"]="Solid";
		this.stdButtonHotTrackStyle.attributes["borderWidth"]="1px";
		this.stdButtonHotTrackStyle.attributes["borderLeftColor"]="buttonhighlight";
		this.stdButtonHotTrackStyle.attributes["borderTopColor"]="buttonhighlight";
		this.stdButtonHotTrackStyle.attributes["borderRightColor"]="buttonshadow";
		this.stdButtonHotTrackStyle.attributes["borderBottomColor"]="buttonshadow";
	}
	this.CreateStdButtonPressedStyle = function(){
		this.stdButtonPressedStyle = ASPxStyle.CreateStyle();
		this.stdButtonPressedStyle.attributes["borderStyle"]="Solid";
		this.stdButtonPressedStyle.attributes["borderWidth"]="1px";
		this.stdButtonPressedStyle.attributes["borderLeftColor"]="buttonshadow";
		this.stdButtonPressedStyle.attributes["borderTopColor"]="buttonshadow";
		this.stdButtonPressedStyle.attributes["borderRightColor"]="buttonhighlight";
		this.stdButtonPressedStyle.attributes["borderBottomColor"]="buttonhighlight";
	}
}

function ASPxLookAndFeelUltraFlatKindStdStyles(){
	this.inherit = ASPxLookAndFeelKindStdStyles;
	this.inherit();	

	this.CreateStdButtonStyle = function(lookAndFeel){
		this.stdButtonStyle = ASPxStyle.CreateStyle();
		this.stdButtonStyle.attributes["backgroundColor"]="buttonface";
		this.stdButtonStyle.attributes["borderColor"]="window";
		this.stdButtonStyle.attributes["borderStyle"]="Solid";
		this.stdButtonStyle.attributes["borderWidth"]="1px";
		this.stdButtonStyle.attributes["textAlign"]="Center";		
		this.stdButtonStyle.attributes["color"]="black";
	}
	this.CreateStdButtonHotTrackStyle = function(){
		this.stdButtonHotTrackStyle = ASPxStyle.CreateStyle();
		this.stdButtonHotTrackStyle.attributes["backgroundColor"]="#B6BDD2";
		this.stdButtonHotTrackStyle.attributes["borderColor"]="#0A246A";
	}
	this.CreateStdButtonPressedStyle = function(){
		this.stdButtonPressedStyle = ASPxStyle.CreateStyle();
		this.stdButtonPressedStyle.attributes["backgroundColor"]="#8592B5";
		this.stdButtonPressedStyle.attributes["borderColor"]="#0A246A";
		this.stdButtonPressedStyle.attributes["color"]="white";
	}
	this.CreateStdEditorStyle = function(){
		this.stdEditorStyle = ASPxStyle.CreateStyle();
		this.stdEditorStyle.attributes["backgroundColor"]="window";
		this.stdEditorStyle.attributes["borderColor"]="buttonface";
		this.stdEditorStyle.attributes["borderWidth"]="1px";
		this.stdEditorStyle.attributes["borderStyle"]="Solid";
	}
	this.CreateStdStandaloneButtonStyle = function(){
		this.stdStandaloneButtonStyle = this.GetButtonStyle();
		this.stdStandaloneButtonStyle .attributes["borderColor"]="windowframe";
	}
	this.CreateStdDraggedElementStyle = function(){
		this.stdDraggedElementStyle = ASPxStyle.CreateStyle();
		this.stdDraggedElementStyle.attributes["backgroundColor"]="buttonshadow";
		this.stdDraggedElementStyle.attributes["filter"]="progid:DXImageTransform.Microsoft.Alpha(Style=0, Opacity=60)"; 
	}
	this.CreateStdGroupItemStyle = function(){
		this.stdGroupItemStyle = ASPxStyle.CreateStyle();
		this.stdGroupItemStyle.attributes["backgroundColor"]="buttonface";
	}
	this.CreateStdPreviewStyle = function(){
		this.stdPreviewStyle = ASPxStyle.CreateStyle();
		this.stdPreviewStyle.attributes["color"]="blue";
	}
	this.CreateStdFooterStyle = function(){
		this.stdFooterStyle = ASPxStyle.CreateStyle();
		this.stdFooterStyle.attributes["backgroundColor"]="buttonface";
	}
	this.CreateStdFooterCellStyle = function(){
		this.stdFooterCellStyle = ASPxStyle.CreateStyle();
		this.stdFooterCellStyle.attributes["backgroundColor"]="buttonface";
		this.stdFooterCellStyle.attributes["borderColor"]="buttonshadow";
		this.stdFooterCellStyle.attributes["borderStyle"]="Solid";
		this.stdFooterCellStyle.attributes["borderWidth"]="1px";
	}
	this.CreateStdSearchItemStyle = function(){
		this.stdSearchItemStyle = ASPxStyle.CreateStyle();
		this.stdSearchItemStyle.attributes["backgroundColor"]="buttonface";
		this.stdSearchItemStyle.attributes["verticalAlign"]="center";
	}
}

function ASPxLookAndFeelOffice11KindStdStyles(){
	this.inherit = ASPxLookAndFeelKindStdStyles;
	this.inherit();	

	this.CreateStdButtonStyle = function(){
		this.stdButtonStyle = ASPxStyle.CreateStyle();
		this.stdButtonStyle.attributes["backgroundColor"]="buttonface";
		this.stdButtonStyle.attributes["borderColor"]="window";
		this.stdButtonStyle.attributes["borderStyle"]="Solid";
		this.stdButtonStyle.attributes["borderWidth"]="1px";
		this.stdButtonStyle.attributes["textAlign"]="Center";		
		this.stdButtonStyle.attributes["filter"]="progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#D5E7FC', EndColorStr='#8DB1E6')";		
	}
	this.CreateStdButtonHotTrackStyle = function(){
		this.stdButtonHotTrackStyle = ASPxStyle.CreateStyle();
		this.stdButtonHotTrackStyle.attributes["borderColor"]="highlight";
		this.stdButtonHotTrackStyle.attributes["filter"]="progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#FFF3CA', EndColorStr='#FFD599')";		
	}
	this.CreateStdButtonPressedStyle = function(){
		this.stdButtonPressedStyle = ASPxStyle.CreateStyle();
		this.stdButtonPressedStyle.attributes["borderColor"]="highlight";
		this.stdButtonPressedStyle.attributes["filter"]="progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#FE9450', EndColorStr='#FFCA86')";		
	}
	this.CreateStdEditorStyle = function(){
		this.stdEditorStyle = ASPxStyle.CreateStyle();
		this.stdEditorStyle.attributes["backgroundColor"]="white";
		this.stdEditorStyle.attributes["borderColor"]="#7F9DB9";
		this.stdEditorStyle.attributes["borderWidth"]="1px";
		this.stdEditorStyle.attributes["borderStyle"]="Solid";
	}
	this.CreateStdStandaloneButtonStyle = function(){
		this.stdStandaloneButtonStyle = this.GetButtonStyle();
		this.stdStandaloneButtonStyle .attributes["borderColor"]="windowframe";
	}
	this.CreateStdDraggedElementStyle = function(){
		this.stdDraggedElementStyle = ASPxStyle.CreateStyle();
		this.stdDraggedElementStyle.attributes["backgroundColor"]="buttonshadow";
		this.stdDraggedElementStyle.attributes["filter"]="progid:DXImageTransform.Microsoft.Alpha(Style=0, Opacity=60)"; 
	}
	this.CreateStdDataItemStyle = function(){
		this.stdDataItemStyle = ASPxStyle.CreateStyle();
		this.stdDataItemStyle.attributes["backgroundColor"]="white";
	}
	this.CreateStdGroupItemStyle = function(){
		this.stdGroupItemStyle = ASPxStyle.CreateStyle();
		this.stdGroupItemStyle.attributes["backgroundColor"]="#BEDAFB";
	}
	this.CreateStdFooterStyle = function(){
		this.stdFooterStyle = ASPxStyle.CreateStyle();
		this.stdFooterStyle.attributes["backgroundColor"]="#AECAF0";
	}
	this.CreateStdFooterCellStyle = function(){
		this.stdFooterCellStyle = ASPxStyle.CreateStyle();
		this.stdFooterCellStyle.attributes["backgroundColor"]="#DDECFE";
	}
	this.CreateStdPreviewStyle = function(){
		this.stdPreviewStyle = ASPxStyle.CreateStyle();
		this.stdPreviewStyle.attributes["color"]="blue";
		this.stdPreviewStyle.attributes["backgroundColor"]="white";
	}
	this.CreateStdSearchItemStyle = function(){
		this.stdSearchItemStyle = ASPxStyle.CreateStyle();
		this.stdSearchItemStyle.attributes["backgroundColor"]="#AECAF0";
		this.stdSearchItemStyle.attributes["verticalAlign"]="center";
	}
}

var __ASPxLookAndFeelStyleCollection = null;
function GetLookAndFeelStyleCollection(){
	if(__ASPxLookAndFeelStyleCollection == null){
		__ASPxLookAndFeelStyleCollection = new ASPxLookAndFeelStyleCollection();
	}
	return __ASPxLookAndFeelStyleCollection;
}