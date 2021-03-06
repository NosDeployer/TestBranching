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

function array_remove(array, element){
	for(var i = 0; i < array.length; i++){
		if(_equal(array[i], element)){
			array_removeAt(array, i);
			return;
		}
	}
}

function array_removeAt(array, index){
	if(index >= 0  && index < array.length){
		for(var i = index; i < array.length - 1; i++){
			array[i] = array[i + 1];
		}
		array.pop();
	}
}

function array_clear(array){
	while(array.length > 0){
		array.pop();
	}
}

function array_indexOf(array, element){
	for(var i = 0; i < array.length; i++){
		if(_equal(array[i], element))
			return i;
	}
	return -1;
}

function array_insert(array, element, position){
	if(0 <= position && position < array.length){
		for(var i = array.length; i > position; i --){
			array[i] = array[i - 1];
		}
		array[position] = element;
	}
	else{
		array.push(element);
	}
}

function array_insertArray(array, elements, position){
	if(0 <= position && position < array.length){
		var range = elements.length;
		for(var i = array.length - 1; i > position - range; i --){
			array[i] = array[i - range];
		}
		for(i = 0; i < range; i ++){
			array[position + i] = elements[i];
		}
	}
	else{		
		array.concat(elements);
	}
}

function array_firstElement(array){
	return (array.length > 0) ? array[0] : null;
}

function array_lastElement(array){
	return (array.length > 0) ? array[array.length - 1] : null;
}