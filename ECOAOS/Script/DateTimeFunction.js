/*----------------------------------------------
// 控件使用方法：
// 在所需的要页面的<head></head>区块中加入：<script src="DateTimeList/DateTimeList.js" language="javascript"></script>
// 主调函数：ShowDateTime( this,'DateTime' )或ShowDateTime( this,'Date' )或ShowDateTime( this,'Time' )
// 例如：
// 一、<input type="text" id="txtTime" name="txtTime" onclick="ShowDateTime( this,'DateTime' );"/>
// 二、<input type="button" onclick="ShowDateTime( this,'time' );" />
-----------------------------------------------*/
	function minute(name,fName)
	{
		this.name = name;
		this.fName = fName || "m_input";
		this.timer = null;
		this.fObj = null;
		
		this.toString = function()
		{
			var objDate = new Date();
			var sMinute_Common = "class=\"m_input\" maxlength=\"2\" name=\""+this.fName+"\" onfocus=\""+this.name+".setFocusObj(this)\" onblur=\""+this.name+".setTime(this)\" onkeyup=\""+this.name+".prevent(this)\" onkeypress=\"if (!/[0-9]/.test(String.fromCharCode(event.keyCode)))event.keyCode=0\" onpaste=\"return false\" ondragenter=\"return false\"";
			var sButton_Common = "class=\"m_arrow\" onfocus=\"this.blur()\" onmouseup=\""+this.name+".controlTime()\" disabled"
			var str = "";
			str += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\">"
			str += "<tr>"
			str += "<td>"
			str += "<div class=\"m_frameborder\">"
			str += "<input radix=\"24\" value=\""+this.formatTime(objDate.getHours())+"\" "+sMinute_Common+">:"
			str += "<input radix=\"60\" value=\""+this.formatTime(objDate.getMinutes())+"\" "+sMinute_Common+">:"
			str += "<input radix=\"60\" value=\""+this.formatTime(objDate.getSeconds())+"\" "+sMinute_Common+">"
			str += "</div>"
			str += "</td>"
			str += "<td>"
			str += "<table border=\"0\" cellspacing=\"2\" cellpadding=\"0\">"
			str += "<tr><td><button id=\""+this.fName+"_up\" "+sButton_Common+">5</button></td></tr>"
			str += "<tr><td><button id=\""+this.fName+"_down\" "+sButton_Common+">6</button></td></tr>"
			str += "</table>"
			str += "</td>"
			str += "</tr>"
			str += "</table>"
			return str;
		}
		this.play = function()
		{
			this.timer = setInterval(this.name+".playback()",1000);
		}
		this.formatTime = function(sTime)
		{
			sTime = ("0"+sTime);
			return sTime.substr(sTime.length-2);
		}
		this.playback = function()
		{
			var objDate = new Date();
			var arrDate = [objDate.getHours(),objDate.getMinutes(),objDate.getSeconds()];
			var objMinute = document.getElementsByName(this.fName);
			for (var i=0;i<objMinute.length;i++)
			{
				objMinute[i].value = this.formatTime(arrDate[i])
			}
		}
		this.prevent = function(obj)
		{
			clearInterval(this.timer);
			this.setFocusObj(obj);
			var value = parseInt(obj.value,10);
			var radix = parseInt(obj.radix,10)-1;
			if (obj.value>radix||obj.value<0)
			{
				obj.value = obj.value.substr(0,1);
			}
		}
		this.controlTime = function(cmd)
		{
			event.cancelBubble = true;
			if (!this.fObj) return;
			clearInterval(this.timer);
			var cmd = event.srcElement.innerText=="5"?true:false;
			var i = parseInt(this.fObj.value,10);
			var radix = parseInt(this.fObj.radix,10)-1;
			if (i==radix&&cmd)
			{
				i = 0;
			}
			else if (i==0&&!cmd)
			{
				i = radix;
			}
			else
			{
				cmd?i++:i--;
			}
			this.fObj.value = this.formatTime(i);
			this.fObj.select();
		}
		this.setTime = function(obj)
		{
			obj.value = this.formatTime(obj.value);
		}
		this.setFocusObj = function(obj)
		{
			eval(this.fName+"_up").disabled = eval(this.fName+"_down").disabled = false;
			this.fObj = obj;
		}
		this.getTime = function()
		{
			var arrTime = new Array(2);
			for (var i=0;i<document.getElementsByName(this.fName).length;i++)
			{
				arrTime[i] = document.getElementsByName(this.fName)[i].value;
			}
			return arrTime.join(":");
		}
	}
	
	function calendar(name,fName)
	{
		this.name = name;
		this.fName = fName || "calendar";
		this.year = new Date().getFullYear();
		this.month = new Date().getMonth();
		this.date = new Date().getDate();
		//private
		this.toString = function()
		{
			var str = "";
			str += "<table border=\"0\" cellspacing=\"3\" cellpadding=\"0\" onselectstart=\"return false\">";
			str += "<tr>";
			str += "<td>";
			str += this.drawMonth();
			str += "</td>";
			str += "<td align=\"right\">";
			str += this.drawYear();
			str += "</td>";
			str += "</tr>";
			str += "<tr>";
			str += "<td colspan=\"2\">";
			str += "<div class=\"c_frameborder\">";
			str += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"c_dateHead\">";
			str += "<tr>";
			str += "<td>日</td><td>一</td><td>二</td><td>三</td><td>四</td><td>五</td><td>六</td>";
			str += "</tr>";
			str += "</table>";
			str += this.drawDate();
			str += "</div>";
			str += "</td>";
			str += "</tr>";
			str += "</table>";
			return str;
		}
		//private
		this.drawYear = function()
		{
			var str = "";
			str += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
			str += "<tr>";
			str += "<td>";
			str += "<input class=\"c_year\" maxlength=\"4\" value=\""+this.year+"\" name=\""+this.fName+"\" id=\""+this.fName+"_year\" readonly>";
			//DateField
			str += "<input type=\"hidden\" name=\""+this.fName+"\" value=\""+this.date+"\" id=\""+this.fName+"_date\">";
			str += "</td>";
			str += "<td>";
			str += "<table cellspacing=\"2\" cellpadding=\"0\" border=\"0\">";
			str += "<tr>";
			str += "<td><button class=\"c_arrow\" onfocus=\"this.blur()\" onclick=\"event.cancelBubble=true;document.getElementById('"+this.fName+"_year').value++;"+this.name+".redrawDate()\">5</button></td>";
			str += "</tr>";
			str += "<tr>";
			str += "<td><button class=\"c_arrow\" onfocus=\"this.blur()\" onclick=\"event.cancelBubble=true;document.getElementById('"+this.fName+"_year').value--;"+this.name+".redrawDate()\">6</button></td>";
			str += "</tr>";
			str += "</table>";
			str += "</td>";
			str += "</tr>";
			str += "</table>";
			return str;
		}
		//priavate
		this.drawMonth = function()
		{
			var aMonthName = ["一","二","三","四","五","六","七","八","九","十","十一","十二"];
			var str = "";
			str += "<select class=\"c_month\" name=\""+this.fName+"\" id=\""+this.fName+"_month\" onchange=\""+this.name+".redrawDate()\">";
			for (var i=0;i<aMonthName.length;i++) {
				str += "<option value=\""+(i+1)+"\" "+(i==this.month?"selected":"")+">"+aMonthName[i]+"月</option>";
			}
			str += "</select>";
			return str;
		}
		//private
		this.drawDate = function()
		{
			var str = "";
			var fDay = new Date(this.year,this.month,1).getDay();
			var fDate = 1-fDay;
			var lDay = new Date(this.year,this.month+1,0).getDay();
			var lDate = new Date(this.year,this.month+1,0).getDate();
			str += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" id=\""+this.fName+"_dateTable"+"\">";
			for (var i=1,j=fDate;i<7;i++)
			{
				str += "<tr>";
				for (var k=0;k<7;k++)
				{
					str += "<td style=\"border:#ffffff 1px solid\" onmouseover=\"this.style.border='#cccccc 1px solid'\" onmouseout=\"this.style.border='#ffffff 1px solid'\" onclick=\""+this.name+".redrawDate(this.innerText);dc.DateSelected(c.getDate('-'));\" style=\""+(j==this.date?"BACKGROUND-COLOR:navy;COLOR: white;CURSOR: hand;":"CURSOR: hand")+"\">"+(isDate(j++))+"</td>";
				}
				str += "</tr>";
			}
			str += "</table>";
			return str;

			function isDate(n)
			{
				return (n>=1&&n<=lDate)?n:"";
			}
		}
		//public
		this.redrawDate = function(d)
		{
			this.year = document.getElementById(this.fName+"_year").value;
			this.month = document.getElementById(this.fName+"_month").value-1;
			this.date = d || this.date;
			document.getElementById(this.fName+"_year").value = this.year;
			document.getElementById(this.fName+"_month").selectedIndex = this.month;
			document.getElementById(this.fName+"_date").value = this.date;
			if (this.date>new Date(this.year,this.month+1,0).getDate()) this.date = new Date(this.year,this.month+1,0).getDate();
			document.getElementById(this.fName+"_dateTable").outerHTML = this.drawDate();
		}
		//public
		this.getDate = function(delimiter)
		{
			if (!delimiter) delimiter = "-";
			var aValue = [this.year,(this.month+1),this.date];
			return aValue.join(delimiter);
		}
	}
	
	var c = new calendar("c");
	var m = new minute("m");
	var divT = document.getElementById( "divTime" );
	var d = document.getElementById( "divDate" );
	var dc = new DateControls();
	var obj,dtf;
	
	function DateControls()
	{
		d.innerHTML =c;
		m.play();
		divT.innerHTML = m;
		
		this.NowTime = function()
		{
			c = new calendar("c");
			d.innerHTML =c;
			m = new minute("m");
			m.play();
			divT.innerHTML = m;
			this.DateSelected( c.getDate() );
		}
		
		this.DateSelected = function( selectedDate )
		{
			var arrDate = selectedDate.split("-");
			var arrTime = m.getTime().split(":");
			var dt = new Date( arrDate[0],parseInt( arrDate[1] )-1,arrDate[2],arrTime[0],arrTime[1],arrTime[2] );
			
			document.getElementById( "divYear" ).innerHTML = "<font style=\"font-size:40px;font-family:Arial Black;color:Blue\">"+dt.getDate()+"</font>";
			document.getElementById( "divNow" ).innerHTML = "<font style=\"font-size:12px;\">"+dt.toLocaleDateString()+dt.toLocaleTimeString()+"</font>";
			var controls = document.getElementById( "divControls" );
			controls.innerHTML = "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\"><tr align=\"center\"><td width=\"33%\">";
			controls.innerHTML += "<input type=\"button\" onmouseover=\"this.style.backgroundColor='White'\" onmouseout=\"this.style.backgroundColor='ButtonFace'\" value=\"现在\" style=\"width:40px;BORDER: Gray 1px solid;CURSOR: hand;\" onclick=\"dc.NowTime();\"/></td>";
			controls.innerHTML += "<td width=\"33%\">&nbsp;<input type=\"button\" style=\"width:40px;BORDER: Gray 1px solid;CURSOR: hand;\" value=\"清空\" onmouseover=\"this.style.backgroundColor='White'\" onmouseout=\"this.style.backgroundColor='ButtonFace'\" onclick=\"window.returnValue='';window.close();\"/></td>";
			controls.innerHTML += "<td width=\"34%\">&nbsp;<input type=\"button\" style=\"width:60px;BORDER: Gray 1px solid;CURSOR: hand;\" value=\"确定\" onmouseover=\"this.style.backgroundColor='White'\" onmouseout=\"this.style.backgroundColor='ButtonFace'\" onclick=\"dc.ReturnTime()\"/></td></tr></table>";
		}
		
		this.ReturnTime = function( selectedDate )
		{
			window.returnValue = c.getDate() + " " + m.getTime();
			window.close();
		}
		this.DateSelected( c.getDate() );
	}