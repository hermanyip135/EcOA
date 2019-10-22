/*Selected Row*/
function pointTo() 
{ 
	var src = event.srcElement.parentElement; 
	if (src && src.tagName =='TR') 
		{ 
			ClearSel(); 
			src.className="SelectedColor";
		} 
} 

/*Clear Row BackGroundColor*/					
function ClearSel() 
{
	var objTr=document.all.tags('Tr'); 
	for (var i=1;i<objTr.length;i++) 
	{ 
		if (objTr[i].id != "")
		{
			if ( i%2!=0 ) 
			{ 
				//objTr[i].className="unselectedColor"; 
				objTr[i].className="altercolor";
			} 
			else 
			{
				//objTr[i].className="altercolor";
				objTr[i].className="unselectedColor"; 
			}
		}
	} 
} 

/*Data Pickup Window*/
function DataSelectWindow(url)
{
		var sFeature="dialogWidth:300px;dialogHeight:320px;center:yes;help:no;resizable:yes;status:no;";
		var sItemID="";
		var sUrl=url;

		var retObj=window.showModalDialog(sUrl,"",sFeature);
		if (retObj!=null && retObj.id!="*")
		{
			//get your data here,such as 
			//element.itemid=retObj.id;
		}
}	

/*Tree Select Window*/
function TreeSelectWindowForMultTree(url)
{
	var vv=new Object();
	title=encodeURI('查找');
	window_style="dialogWidth:280px;dialogHeight:400px;status:no;resizable: yes;scroll:no";
	vv=window.showModalDialog(url,'',window_style);		
	if(vv!=null)
	return vv;

	//get your data here;		
	
}

/*Tree Select Window*/
function TreeSelectWindow(url)
{
	var vv=new Object();
	window_style="dialogWidth:274px;dialogHeight:385px;status:no;resizable:no;scroll:no";
	vv=window.showModalDialog(url,"",window_style);		
	if(vv != null)
	return vv;	
}

/*Tree Select Window*/
function TreeSelectPromptWindow(url)
{
	var result = new Object();
	var window_style="dialogWidth:258px;dialogHeight:385px;status:no;resizable:yes;scroll:no";
	result = window.showModalDialog(url,"",window_style);		
	if( result == null)
		return null;
	else
		return result;	
}



/*Switch Bar Control*/
function switchSysBar(stype)
{
	if (stype==7){
		document.all("frmTitle").style.display="none";
		document.all("switchPoint").style.visibility="";
		document.all("open_btn").style.width=18;		
	}
	else{
		document.all("frmTitle").style.display="";
		document.all("switchPoint").style.visibility="hidden";
		document.all("open_btn").style.width=6;
	}
}

/*Switch Bar Control*/
function switchSysBarInContainer(stype)
{
	if (stype==7){
		document.all("frmTitle").style.display="none";
		document.all("frminterval").style.display="";		
		document.all("switchPoint").style.visibility="";
		document.all("open_btn").style.width=18;		
		
		var workLeftTd = document.all("workLeft");
		workLeftTd.style.width = "18px";
		workLeftTd.children[0].style.width="18px";
	}
	else{
		document.all("frmTitle").style.display="";
		document.all("frminterval").style.display="none";
		document.all("switchPoint").style.visibility="hidden";
		document.all("open_btn").style.width=6;
		
		var workLeftTd = document.all("workLeft");
		workLeftTd.style.width = "160px";
		workLeftTd.children[0].style.width="160px";
	}
}

/*Item Select Init*/
function initIt()
{
        divColl = document.all.tags("DIV");
        for (i=0; i<divColl.length; i++) {
            whichEl = divColl(i);
            if (whichEl.className == "child") whichEl.style.display = "none";
        }
}

/*Item Expand*/
function expandIt(el,picname) 
{
        whichEl = eval(el + "Child");
        img=eval(picname);
        if (whichEl.style.display == "none") {
            whichEl.style.display = "block";
            img.src="images/TRUE.GIF" 
        }
        else {
            whichEl.style.display = "none";
            img.src="images/FALSE.GIF"
        }
}

/*Message Window*/
function MsgWindow(url,title)
{
	//var sFeature="dialogWidth:410px;dialogHeight:106px;center:yes;help:no;resizable:yes;status:no;scroll:no";
	var sFeature="dialogWidth:425px;dialogHeight:106px;center:yes;help:no;resizable:yes;status:no;scroll:no"; //baty changed
	var sItemID="";
	var sUrl=url;

	var retObj=window.showModalDialog(sUrl,title,sFeature);
	return(retObj);
}	

/*KeyWord search*/
function KeyWordSearch()
{	
	var DialogStyle = "dialogWidth:300px;dialogHeight:50px;status:no;resizable:no";
			
	var result = window.showModalDialog("../HumanManage/SimpleSelectPrompt.htm","关键字查询",DialogStyle);
	if(result!="" && result!=null)
	{
		return result;		
	}
	else
	{	return "";	
	}
}
/*Generel search add by mmf */
/***********************************************
function	:	GeneralSearch
purpose		:	调用F7页面
parameters	:	type:	            四种类型:"employee","orgunit","position","search"
				allowmultiselect:   是否允许多选 "false","true"
				CustomRootItemData: 权限字符串			
				displayType:        "search" 搜索, "select" 选择
				inParam:  传入参数	
				
return value:	两种：单选时：对象，ret.id, ret.name
					  多选时：数组对象 ret[i].id, ret[i].name
************************************************/
function GeneralSearch(type,allowmultiselect,showlevel,CustomRootItemData,inParam,displayType)
{	
	var DialogStyle = "dialogWidth:700px;dialogHeight:500px;status:no;resizable:yes";
	var sUrl="../Public/Dialog.aspx?type="+type;
	var ssUrl= encodeURI("F7Select.aspx?SelectType="+type + "&AllowMultiSelect=" + allowmultiselect 
	                                      +"&CustomRootItemData=" + CustomRootItemData
					      +"&InParam=" + inParam
	                                      +"&DisplayType=" + displayType);
	var ret = showModalDialog(sUrl,ssUrl, DialogStyle);
	
	return ret;		
}
/*面试安排*/
function ConfirmWindow(url,title)
{
	var sFeature="dialogWidth:350px;dialogHeight:330px;center:yes;help:no;resizable:no;status:no;";
	var sItemID="";
	var sUrl=url;

	var retObj=window.showModalDialog(sUrl,title,sFeature);
	return(retObj);
}

/*招聘信息确认窗口*/
function ConfirmWindow2(url,title)
{
	var sFeature="dialogWidth:300px;dialogHeight:185px;center:yes;help:no;resizable:no;status:no;";
	var sItemID="";
	var sUrl=url;

	var retObj=window.showModalDialog(sUrl,title,sFeature);
	return(retObj);
}

/*去除字符串两边的空格*/
function Jtrim(str){
        var i = 0;
        var len = str.length;
        if ( str == "" ) return( str );
        j = len -1;
        flagbegin = true;
        flagend = true;
        while ( flagbegin == true && i< len){
           if ( str.charAt(i) == " " ){
                  i=i+1;
                  flagbegin=true;
           }
           else{
                  flagbegin=false;
           }
        }
        while  (flagend== true && j>=0){
            if (str.charAt(j)==" "){
                  j=j-1;
                  flagend=true;
            }
            else{
                  flagend=false;
            }
        }
        if ( i > j ) return ("")
        trimstr = str.substring(i,j+1);
        return trimstr;
}

//清除toolbar元素 

function ClearToolbar(toolbar)
{ 
	toolbar.clear(); 
} 

//创建按钮 itemid按钮ID, itemtitle按钮名称, itemimageurl按钮使用的图片, textstatus文本所处的位置：right,none,bottom

function CreateButton(toolbar,itemid,itemtitle,itemimageurl,textstatus) 
{ 
	var num; 
	num = toolbar.numItems; 
	if(textstatus == null)
	{
		toolbar.createButtonAt(num,"<TBNS:ToolbarButton ID=\"" + itemid + "\" title=\"" + itemtitle + "\" imageUrl=\"" + itemimageurl + "\">" + itemtitle + "</TBNS:ToolbarButton>");
	}
	else
	{
		if(textstatus.toLowerCase() == "bottom")
		{
			toolbar.createButtonAt(num,"<TBNS:ToolbarButton ID=\"" + itemid + "\" title=\"" + itemtitle + "\" text=\"<br>" + itemtitle + "\" imageUrl=\"" + itemimageurl + "\" defaultstyle=\"text-align:center\"></TBNS:ToolbarButton>");
		}
	}
} 

//创建最左边的LABEL 
function CreateLabelLeft(toolbar) 
{ 
	var num; 
	num = toolbar.numItems; 
	toolbar.createLabelAt(num,"<TBNS:ToolbarLabel imageUrl=\"../images/Toolbar_left_1.gif\"></TBNS:ToolbarLabel>");
} 

//创建分割按钮的LABEL 
function CreateLabelGroup(toolbar) 
{ 
	var num; 
	num = toolbar.numItems; 
	toolbar.createLabelAt(num,"<TBNS:ToolbarLabel imageUrl=\"../images/Toolbar_group_1.gif\"></TBNS:ToolbarLabel>");
} 

//修改按钮状态――使按钮处于有效或者无效状态//num，按钮按照从左到右所处位置的索引，从0开始//value ＝ true，则按钮处于无效状态//value ＝ false，则按钮处于有效状态

function DisableToolbar(toolbar,num,value) 
{
	var toolItem = toolbar.getItem(num); 
	toolItem.setAttribute("disabled", value); 
}

//修改按钮状态――使按钮处于有效或者无效状态(批量修改)
//startnum，按钮按照从左到右所处位置的索引
//length，批量修改按钮的数量
//value ＝ true，则按钮处于无效状态//value ＝ false，则按钮处于有效状态

function DisableToolbarGroup(toolbar,startnum,length,value) 
{
	for(var i=startnum; i< startnum + length; i++)
	{
		var toolItem = toolbar.getItem(i); 
		if(toolItem == null)
		{
			continue;
		}
		toolItem.setAttribute("disabled", value); 
	}
}

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

//弹出对话框,返回值是argument。 

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

//弹出Modeless对话框,返回值是argument两部分组成。 

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

/***********显示QuickTree（组织单元、职位、员工树）*********************/
//selectType，选择类型，分为三类：OrgUnit、Position、Employee
//showType，显示类型，分为五类：OrgUnit、 OrgUnit,Position、OrgUnit,Employee、OrgUnit,Position,Employee、OrgUnit1,OrgUnit2
//allowMultiSelect，是否允许多选//CustomRootItemData，权限字符串
//ShowLevel,显示的层数,默认3
/***********************************************************************/

function showQuickTree(selectType,showType,allowMultiSelect,CustomRootItemData,showLevel)
{
	var dialogboxUrl,url, title, feature,rtnValue;

	//检查参数的准确性	
	if(selectType.toLowerCase() != "orgunit" 
		&& selectType.toLowerCase() != "position" 
		&& selectType.toLowerCase() != "employee"
		&& selectType.toLowerCase() != "orgunit4")
	{
		alert("第一个参数selectType不正确，应该为下面三种之一：OrgUnit、OrgUnit4、Position、Employee");
		return null;
	}	

	switch(showType.toLowerCase())
	{
	case "orgunit" :
		showType = "OrgUnit";
		title = "组织单元树";
		break;
	case "orgunit,position":
		showType = "OrgUnit,Position";
		title = "职位树";
		break;
	case "orgunit,employee":
		showType = "OrgUnit,Employee";
		title = "员工树";
		break;
	case "orgunit,position,employee":
		showType = "OrgUnit,Employee,Position";
		title = "组织单元、职位、员工树";
		break;
	case "orgunit1,orgunit2":
		showType = "OrgUnit1,OrgUnit2";
		title = "集团、公司树";
		break;
	default:
		alert("第二个参数showType不正确，应该为下面四种之一：OrgUnit、 OrgUnit,Position、OrgUnit,Employee、OrgUnit,Position,Employee");
		return null;
		break;
	}
	
	dialogboxUrl = "../DialogBox.aspx";	
	
	feature = "dialogWidth:300px;dialogHeight:385px;center:yes;help:no;resizable:yes;status:no;scroll:no";
	
	var tempShowLevel = 3; //默认3层	
	if(showLevel != null)
	{
		tempShowLevel = showLevel;
	}	
	
	url = "Trees/QuickTree.aspx?SelectType="+selectType+"&ShowType="+showType+"&ShowLevel="+tempShowLevel+"&FrameworkId=efd9de08-df92-48c9-9ad4-adfdbf66af2b&CustomRootItem=true&CustomRootItemDataType=Code&CustomRootItemData="+CustomRootItemData;
	
	if(allowMultiSelect == true)
	{
		url += "&AllowMultiSelect=true";
		var argument = null;
		rtnValue = showDialogBoxReturnArg(dialogboxUrl, url, title, feature, argument);
	}
	else
	{
		rtnValue = showDialogBox(dialogboxUrl, url, title, feature);
	}
	
	return rtnValue;
}

/**********************************************
//弹出条件过滤页面的对话框
//dialogboxUrl
//title,弹出页面的名称//xmlpath,条件过滤对应的xml文档路径
//type,条件过滤对应的类型名称//showtabs,（却省）默认显示1,2,3,4页签，用户可以从五个页签中任意组合，中间以逗号分隔，如显示条件和排序页签：1,2
//advance，（却省） 作为动态变化的参数传往高级过滤页面
//argument，系统返回的参数。*************************************************/

function showFilterReturnArg(dialogboxUrl, xmlpath, title, xmltype, showtabs, argument, advance)
{
	var m_href = "Public/ReportFilter.aspx?Type=KHGCKZ&xmlpath=../XML/ProcessControlReport.xml&advance=menu";
	
	var arg;
	var argObject = new Object();
	if(dialogboxUrl == null)	
		alert("Argument dialogboxUrl is null. ");			
	
	if(xmltype == null)	
		alert("Argument xmltype is null. ");	
	
	if(advance == null)	
		advance = "";	
	
	if(showtabs == null)
		showtabs = "1,2,3,4";
		
	
	var url = "Public/ReportFilter.aspx?Type="+xmltype+"&xmlpath="+xmlpath+"&advance="+advance+"&DisplayType=dialogbox&ShowTabs=" + showtabs;

	dialogboxUrl = dialogboxUrl + "?DialogURL=" + encodeURIComponent(url);
	
	argObject.title = title;
	argObject.argument = argument;	
	
	var feature = "dialogWidth:630px;dialogHeight:460px;center:yes;scroll: no; status: no; unadorned : no; help : no;"
		
	var rtnArg ;
	window.showModalDialog(dialogboxUrl, argObject, feature);
	rtnArg = argObject.argument;
	
	return rtnArg;		
}

function utfurlcode(src)
{
	//编码
	var strRet, I, innerCode, H4, M6, L6;
	strRet = "";
	for(I = 0; I < src.length; I++)
	{
		innerCode = src.charCodeAt(I);
		if(innerCode < 0)
		{
			innerCode += 0x10000;
		}
		if(innerCode < 0xff)
		{
			strRet += src.charAt(I);
		}
		else
		{
			H4 = 0xe0 + ((innerCode & 0xf000) >> 12);
			M6 = 0x80 + ((innerCode & 0xfc0) >> 6);
			L6 = 0x80 + (innerCode & 0x3f);
			strRet += "%" + H4.toString(16) + "%" + M6.toString(16) + "%" + L6.toString(16);
		}
	}
	return strRet;
}
/***********************************************
function	:	KDMsgBox
purpose		:	显示不同类型的模式对话框
parameters	:	path:	窗体所在路径，如'../pub/'
				type:	"question","advance" 2种类型				info:	一个包含要显示信息的对象				info.msg:       
				info.advanced:  显示在高级中
				info.retvalue:  附带返回值				info.title:     对话框的标题，若只需显示默认的标题则传入 info.title = "";
return value:	ok!retvalue / cancel!retvalue 
                -1: 直接点击窗口关闭按钮
                
************************************************/

function KDMsgBox(path,type,info)
{
	var sUrl = utfurlcode(path+"DialogInfo.aspx?type="+type+"&title="+info.title);
	var sFeature="dialogWidth:488px;dialogHeight:80px;center:yes;help:no;resizable:no;status:no;scroll:no";
	info.type = type;
	var retObj=window.showModalDialog(sUrl,info,sFeature);
	
	return retObj;
}
/************************************************
function	:	PostDataXML(url,data)
purpose		:	与服务端进行数据交换
parameters	:	url	进行数据交换的服务端页面
			data	客户端传给服务端的数据return value:	服务端返回的Dom对象
*************************************************/

function PostDataXML(url, data)
{
	var xmlhttp = new ActiveXObject("Msxml2.XMLHTTP"); //创建XMLHTTP对象
	
	xmlhttp.Open("POST", url, false); 
	xmlhttp.Send(data); //发出指令
	
	return xmlhttp.responseXML;
}

/************************************************
function	:	PostDataText(url,data)
purpose		:	与服务端进行数据交换
parameters	:	url		进行数据交换的服务端页面
				data	客户端传给服务端的数据return value:	服务端返回的字串
*************************************************/

function PostDataText(url,data)
{

	var xmlhttp = new ActiveXObject("Msxml2.XMLHTTP"); //创建XMLHTTP对象

	xmlhttp.Open("POST",url, false); 
	xmlhttp.Send(data); //发出指令

	return xmlhttp.responseText;
}


/***********************************************
*	响应用户的按钮ESC键，然后关闭弹出窗口
************************************************/
function ESC_Onclick()
{
	if(event.keyCode == 27)
	{
		window.close();
	}
}

/**********************************************
* function:	Show The Selected List 
* authur:	Paul
* date:		2003-11-07
**********************************************/
function GetSelectedList(title,url,listType,argStr,MultiSel,reserve) 
{
	var ret;
	var DialogStyle = "dialogWidth:700px;dialogHeight:500px;status:no;resizable:yes";
	var obj = new Object();
	obj.title = title; 
	obj.listType = listType; 
	obj.argStr = argStr; 
	obj.multiSel = MultiSel;
	obj.reserve = reserve;
	
	var ret = showModalDialog(url,obj, DialogStyle);
	return ret;		
}

/**********************************************
* function:	响应点击多行表显示控件上的下载图标时的事件

* authur:	Arthur
* date:		2003-12-30
***********************************************/
function hrefclick(id)
{
	var a = window.open("../HumanManage/AsscessoryDownload.aspx?AccessoryID="+id);
}
