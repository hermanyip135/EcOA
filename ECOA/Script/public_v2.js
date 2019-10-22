////////////////////////////////////////////////////////
///
///  Copyright (c) 2000-2001 Kingdee international software group co, Ltd. 
///  All rights reserved.
///  
///  Author: 温绍锦///
///  Last update date: 2002年5月16日///
///  Description : 此文件为KDHRMS系统的公用JavaScript函数库，对此文件的中
///                任何函数进行修改都必须做修改纪录。///  
///  更新纪录：///			1、2002年5月16日，温绍锦更新函数命名。将f_前缀去掉。///			2、2002年5月24日，温绍锦更新makeSelectedRowIdString方法，///							  支持不传入getItemIdMethod参数。///            
////////////////////////////////////////////////////////

//弹出对话框,返回值由rtnValue组成。 

function showDialogBox(dialogboxUrl, url, title, feature, argument)
{
	var arg;
	var argObject = new Object();
	if(dialogboxUrl == null)
	{
		alert("Argument dialogboxUrl is null. ");
	}
	
	if(url == null)
	{
		alert("Argument url is null. ");
	}
	
	url = encodeURIComponent(url);

	dialogboxUrl = dialogboxUrl + "?DialogURL=" + url;
	
	argObject.title = title;
	argObject.argument = argument;
	
	if(feature == null)
	{
		feature = "scroll: no; status: no; unadorned : no; help : no;";
	}
	
	var rtnValue = window.showModalDialog(dialogboxUrl, argObject, feature);	
	return rtnValue;
}

//弹出对话框,返回值是argument。 by yuemx

function showDialogBoxReturnArg(dialogboxUrl, url, title, feature, argument)
{
	var arg;
	var argObject = new Object();
	if(dialogboxUrl == null)
	{
		alert("Argument dialogboxUrl is null. ");
	}
	
	if(url == null)
	{
		alert("Argument url is null. ");
	}
	
	url = encodeURIComponent(url);

	dialogboxUrl = dialogboxUrl + "?DialogURL=" + url;
	
	argObject.title = title;
	argObject.argument = argument;
	
	if(feature == null)
	{
		feature = "scroll: no; status: no; unadorned : no; help : no;";
	}
	
	var rtnArg ;
	window.showModalDialog(dialogboxUrl, argObject, feature);
	rtnArg = argObject.argument;
	return rtnArg;
}


//弹出Modeless对话框
function showModelessDialogBox(dialogboxUrl, url, title, feature)
{
	var arg;
	if(dialogboxUrl == null)
	{
		alert("Argument dialogboxUrl is null. ");
	}
	
	if(url == null)
	{
		alert("Argument url is null. ");
	}
	
	url = encodeURIComponent(url);
	//title = encodeURIComponent(title);
	
	dialogboxUrl = dialogboxUrl + "?DialogURL=" + url;
	
	if(arg == null)
	{
		arg = "";
	}
	
	if(feature == null)
	{
		feature = "scroll: no; status: no; unadorned : no; help : no;";
	}
	
	return window.showModelessDialog(dialogboxUrl, arg, feature);
}

//弹出Modeless对话框,返回值是argument两部分组成。 by yuemx

function showModelessDialogBoxReturnArg(dialogboxUrl, url, title, feature, argument)
{
	var arg = new Object();
	arg.argument = argument;
	if(dialogboxUrl == null)
	{
		alert("Argument dialogboxUrl is null. ");
	}
	
	if(url == null)
	{
		alert("Argument url is null. ");
	}
	
	url = encodeURIComponent(url);
	//title = encodeURIComponent(title);
	
	dialogboxUrl = dialogboxUrl + "?DialogURL=" + url;
	
	if(arg == null)
	{
		arg = "";
	}
	
	if(feature == null)
	{
		feature = "scroll: no; status: no; unadorned : no; help : no;";
	}
		
	var dialogReturnValue;
	window.showModelessDialog(dialogboxUrl, arg, feature);
	dialogReturnValue = arg.argument;
	return dialogReturnValue;
}

//模拟Server端的Request.QueryString.getItem
function getQueryStringItemValue(key, pageUrl)
{
	var queryStringArray;
	
	queryStringArray = f_getQueryStringArray(pageUrl);
	
	
	for(var i=0; i<queryStringArray.length; i++)
	{
		if(queryStringArray[i].key == key)
		{
			return queryStringArray[i].value;
		}
	}
	
	return null;
}

//模拟Server端的Request.QueryString
function getQueryStringArray(pageUrl)
{
	var pram;
	var queryStringArray, pramsArray;
	
	queryStringArray = new Array();
	
	if(pageUrl == null)
	{
		pageUrl = self.location.toString();
	}
	
	if(pageUrl.split("?").length == 2)
	{
		pramsArray = pageUrl.split("?")[1].split("&");
		
		for(var i=0; i<pramsArray.length; i++)
		{
			pram = new Object();
			pram.key = decodeURIComponent(pramsArray[i].split("=")[0]);
			
			if(pramsArray[i].split("=").length == 2)
			{
				pram.value = decodeURIComponent(pramsArray[i].split("=")[1]);
			}
			
			queryStringArray.push(pram);
		}
	}
	
	return queryStringArray;
}

//模拟Server端的Request.QueryString.setItem
function setQueryStringItemValue(queryStringArray, key, value)
{
	var flag = false;
	
	for(var i=0; i<queryStringArray.length; i++)
	{
		if(queryStringArray[i].key == key)
		{
			if(value != null)
			{
				queryStringArray[i].value = value;
			}
			else
			{
				//alert("");
				queryStringArray[i].value = "";
			}
			flag = true;
			break;
		}
	}
	
	if(!flag && value != null)
	{
		var pram = new Object();
		
		pram.key = key;
		pram.value = value;
		
		queryStringArray.push(pram);
	}
}

//产生Url
function makeUrl(url, queryStringArray)
{
	for(var i=0; i<queryStringArray.length; i++)
	{
		if(i == 0)
		{
			url += "?";
		}
		else
		{
			url += "&";
		}
		
		url += encodeURIComponent(queryStringArray[i].key);
		url += "=";
		url += encodeURIComponent(queryStringArray[i].value);
	}
	
	return url;
}

//将节点getAttribute("NodeData")加起来，用","隔开。
function generateNodeIdString(nodeArray)
{
	var rtnValue;
	for(var i = 0; i<nodeArray.length; i++)
	{
		if(i == 0)
		{
			rtnValue = nodeArray[i].getAttribute("NodeData");
		}
		else
		{
			rtnValue += ",";
			rtnValue += nodeArray[i].getAttribute("NodeData");
		}
	}
	
	return rtnValue;
}

//产生选择的行的组合的id字符串列表 
//rowArray参数是选择行数组，
//getItemIdMethod参数是一个获取row的Id的函数，
//相当于C#中delegate，C和C++中的函数指针。
function makeSelectedRowIdString(rowArray, getItemIdMethod)
{
	var idString;
	
	idString = "";
	
	for(var i=0; i<rowArray.length; i++)
	{
		if(idString != 0)
		{
			idString += ",";
		}
		
		if(getItemIdMethod != null)
		{
			idString += getItemIdMethod(rowArray[i]);
		}
		else
		{
			idString += rowArray[i].itemid;
		}
	}
	
	return idString;
}

function array_contains(array, value, ignore_case)
{
	if(ignore_case == null)
	{
		ignore_case = false;
	}
	
	if(ignore_case)
	{
		value = value.toLowerCase();
	}
	
	for(var i=0; i<array.length; i++)
	{
		if(ignore_case)
		{
			if(array[i].toLowerCase() == value)
			{
				return i;
			}
		}
		else
		{
			if(array[i] == value)
			{
				return i;
			}
		}
	}
	
	return -1;
}

function array_removeAt(array, index)
{
	if(index < 0 || index >= array.length)
	{
		return;
	}
	
	var tempArray = new Array();
	
	var array_length = array.length;
	for(var i=0; i<array_length - index - 1; i++)
	{
		tempArray.push(array.pop());
	}
	
	array.pop();
	
	while(tempArray.length > 0)
	{
		array.push(tempArray.pop());
	}
}