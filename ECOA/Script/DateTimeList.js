/*----------------------------------------------
// �ؼ�ʹ�÷�����
// �������Ҫҳ���<head></head>�����м��룺<script src="DateTimeList/DateTimeList.js" language="javascript"></script>
// ����������ShowDateTime( this,'DateTime' )��ShowDateTime( this,'Date' )��ShowDateTime( this,'Time' )
// ���磺
// һ��<input type="text" id="txtTime" name="txtTime" onclick="ShowDateTime( this,'DateTime' );"/>
// ����<input type="button" onclick="ShowDateTime( this,'time' );" />
-----------------------------------------------*/
function ShowDateTime( Object , DateTimeFormat )
{
	var x=event.x;
	var y=event.y;
	x=event.screenX;//event.x+event.offsetX
	y=event.screenY;
	var returnTime = window.showModalDialog( "../script/DateTimeControl.htm",window,"dialogTop:"+y+"px;dialogLeft:"+x+"px;dialogWidth:400px;dialogHeight:220px;help:no;status:no;scroll:no;resizable:no" );
	var arrDateTime;
	if ( returnTime == null )
	{
		return;
	}
	if ( returnTime == "" )
	{
		Object.innerText = "";
		return;
	}
	arrDateTime = returnTime.split( " " );
	if ( DateTimeFormat.toLowerCase() == "date" )
	{
		var arrDate = arrDateTime[0].split( "-" );
		var year = arrDate[0];
		var month = parseInt( arrDate[1] )<10 ? "0"+arrDate[1] : arrDate[1];
		var day = parseInt( arrDate[2] )<10 ? "0"+arrDate[2] : arrDate[2];
		returnTime = year + "-" + month + "-" + day;
	}
	else if ( DateTimeFormat.toLowerCase() == "time" )
	{
		var arrTime = arrDateTime[1].split( ":" );
		var hour = arrTime[0];
		var minute = arrTime[1];
		var second = arrTime[2];
		returnTime = hour + ":" + minute + ":" + second;
	}
	else if ( DateTimeFormat.toLowerCase() == "datetime" )
	{
		var arrDate = arrDateTime[0].split( "-" );
		var year = arrDate[0];
		var month = parseInt( arrDate[1] )<10 ? "0"+arrDate[1] : arrDate[1];
		var day = parseInt( arrDate[2] )<10 ? "0"+arrDate[2] : arrDate[2];
		var arrTime = arrDateTime[1].split( ":" );
		var hour = arrTime[0];
		var minute = arrTime[1];
		var second = arrTime[2];
		returnTime = year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
	}
	Object.innerText = returnTime;
}