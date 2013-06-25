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

function ASPxClientDataControllerCore(name){	
	this.inherit = ASPxClientWebControl;
	this.inherit(name);	
	
	this.ApplyCallBackHtml = function(html){
		var element = _getElementById(this.name);
		var CBContainer = _getParentByCssClass(element, "CBContainer");
		CBContainer.innerHTML = html;
	}
}