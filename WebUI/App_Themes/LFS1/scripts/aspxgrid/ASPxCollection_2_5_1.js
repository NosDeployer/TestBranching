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
function ASPxClientCollection(){
	this.elements = new Array();
	
	this.CheckInitialized = function(){
		for(var i = 0; i < this.elements.length; i++){		
			if(_isFunction(this.elements[i].Initialize)) 
				this.elements[i].CheckInitialized();
		}
	}
	this.Initialize = function(checkInitialized){
		for(var i = 0; i < this.elements.length; i++){		
			if(_isFunction(this.elements[i].Initialize)) 
				this.elements[i].InitializeInternal(checkInitialized, true);
		}
	}
	this.Add = function (element){
		var oldElement = this.Get(element.name);
		if(oldElement != null){ 
			if(__getFocusedControl() == oldElement)
				__setFocusedControl(element);
			oldElement.Finalize();
			array_remove(this.elements, oldElement);
		}
		this.elements[this.elements.length] = element;
	}
	this.Clear = function (){
		array_clear(this.elements);
	}
	this.Get = function (name){
		for(var i = 0; i < this.elements.length; i++){
			if(this.elements[i].name == name) return this.elements[i];
		}
		return null;
	}
	this.GetItemCount = function(){
		return this.elements.length;
	}
	this.GetItem = function(index){
		return this.elements[index];
	}
}