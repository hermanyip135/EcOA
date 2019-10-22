function checknumber(data,lbl){
	var tmp ;
	if (data == "") return true;

	var re = /^[\-\+]?([0-9]+)(\.\d+)?$/;

	if (re.test(data)){
		gar = data + '.';
		tmp = gar.split('.');
		if (tmp[0].length > 12) {
			
			alert(lbl);
			return false;
		}
		return true;
	}
	
	alert(lbl);
	return false;
}

function checknumber_below(data,max,lbl)
{
	if (data>max){
		
			alert(lbl);
	
		return false;
	}

	return true;
}

function checkint_below(data,max,lbl)
{
	if (data<max){
		
			alert(lbl);
	
		return false;
	}

	return true;
}

function checknumber_null(data,lbl){
	if (trim(data)==""){
		
			alert(lbl);
		return false;
	}
	return true;
}

function checkint_null(data,lbl){
	if (trim(data)==""){
		alert(lbl);
	return false;
	}
	return true;
}

function checkstring_null(data,lbl)
{
	alert(lbl);
	return false;
	if (trim(data)==""){
		alert(lbl);
		return false;
	}
	return true;
}

function checkdate_null(y,m,d,lbl)
{
	var msg;
	if (msgLang==2)
		msg = lbl+":"+ERR_STRING_NULL2;
	else
		msg = lbl+":"+ERR_STRING_NULL;

	if (trim(y+"")=="" || trim(m+"")=="" || trim(d+"")==""){
		alert(msg);
		return false;
	}
	if (y+""=="0" || m+""=="0" || d+""=="0"){
		alert(msg);
		return false;
	}
	return true;
}

function checkint(data)
{
	var re = /^[\-\+]?([1-9]\d*|0|[1-9]\d{0,2}(,\d{3})*)$/;
	if (re.test(data)) 
		return true;
	
	return false;
}

function checkstring(str,maxlen,lbl)
{
	if (str.length > maxlen){
		if (msgLang==2)
			alert(lbl);
		else
			alert(lbl);
		return false;
	}
	return true;
}

function checkinputlen(elem,maxlen,lbl)
{
	if (checkstring(elem.value,maxlen,lbl))
		return true;
	elem.focus();
	var txtrange = elem.createTextRange();
	txtrange.collapse();
	txtrange.moveEnd("character",maxlen-10);
	txtrange.select();
	return -1;
}

function checkyear(year,lbl)
{
	if (year.length == 0) return true;

	if (!checkint(year)){
		errorYear(lbl);
		return false;
	}

	var temp = parseInt(year);
	if (!isNaN(temp)){
		if (year == 0) return true;
		low = 1900;
		high = 2037;
		if ((year >= low) && (year <=high)) return true;
	}

	errorYear(lbl);
	return false;
}

function checkmonth(month,low,high,lbl)
{
	if (!checkint(month)){
		errorMonth(lbl);
		return false;
	}

	var temp = parseInt(month);
	if (!isNaN(temp)){
		temp = parseInt(low);
		if (isNaN(temp)) low = 1;
		temp = parseInt(high);
		if (isNaN(temp)) high = 12;
		if ((month >= low) && (month <=high)) return true;
	}
	errorMonth(lbl);
	return false;
}

function errorYear(lbl)
{
	if (msgLang==2)
		alert(lbl+":"+ERR_YEAR2);
	else
		alert(lbl+":"+ERR_YEAR);
}
function errorMonth(lbl)
{
	if (msgLang==2)
		alert(lbl+":"+ERR_MONTH2);
	else
		alert(lbl+":"+ERR_MONTH);
}
function errorDay(lbl)
{
	if (msgLang==2)
		alert(lbl+":"+ERR_DAY2);
	else
		alert(lbl+":"+ERR_DAY);
}

function checkday(day,year,month,lbl)
{
	err = false;

	if (!(year,lbl)) {
		return false;
	}
	if (!checkmonth(month,"","",lbl)){
		return false;
	}
	if (!checkint(day) || (day < 1) || (day > 31)){
		errorDay(lbl);
		return false;
	}
	
	switch (parseInt(month)){
		case 2:
			high =28;
			if ((year % 4 == 0) && (year % 100 != 0))
				{high =29;}
			else if (year % 400 == 0) {high=29;}
			break;
		case 1:
		case 3:
		case 5:
		case 7:
		case 8:
		case 10:
		case 12:
			high =31;
			break;
		default:
			high =30;
	}
	if ((day < 1) || (day > high)){
		errorDay(lbl);
		return false;
	}
	return true;
}

function checkemail(umail,lbl)
{
	umail=trim(umail);
	if (umail.length == 0) return true;
	var re=/^[\-!#\$%&'\*\+\\\.\/0-9=\?A-Z\^_`a-z{|}~]+@[\-!#\$%&'\*\+\\\.\/0-9=\?A-Z\^_`a-z{|}~]+(\.[\-!#\$%&'\*\+\\\.\/0-9=\?A-Z\^_`a-z{|}~]+)+$/;
	if (re.test(umail))
		return true;
	
		alert(lbl);
	return false;
}

function checktime(ctime,lbl)
{
	if (ctime.length == 0) return true;

	var re=/^(([0-9]|[01][0-9]|2[0-3])(:([0-9]|[0-5][0-9])){0,2}|(0?[0-9]|1[0-1])(:([0-9]|[0-5][0-9])){0,2}\s?[aApP][mM])?$/;
	return re.test(ctime);
}
function checkdate(bdate){

	if (bdate.length == 0) return true;
	var re = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})(?:\s+(\d{1,2}):(\d{1,2})(?::(\d{1,2}))*)*$/g;
	return re.test(bdate);
}
function checkRatio(data,lbl){
	if (data.toString.length == 0) false;
	var tmp ;
	var re = /^[\+]?([0-9]\d*|0|[1-9]\d{0,2}(,\d{3})*)(\.\d+)?$/;
	if (re.test(data)){
		gar = data + '.';
		tmp = gar.split('.');
		if (tmp[0].length > 12) {
			alert(lbl);
			
			return false;
		}
		return true;
	}
	
	alert(lbl);
	return false;
}

function checkcode(data,min,max,lbl){
	if (!checkstring(data,max,lbl))
		return false;
	if (data.length<min){
		if (msgLang==2)
			alert(lbl+":"+ERR_STRING_NULL2);
		else
			alert(lbl+":"+ERR_STRING_NULL);
		return false;
	}
	var re = /^[a-zA-Z0-9_]*$/;
	if (!re.test(data)){
		if (msgLang==2)
			alert(lbl+":"+ERR_ALPHA_DIGIT2);
		else
			alert(lbl+":"+ERR_ALPHA_DIGIT);
		return false;
	}
	return true;
}

function getLastDayInMonth(month,year){

	switch (parseInt(month)){
		case 2:
			high =28;
			if (year + '' != 'undefined'){
				if ((year % 4 == 0) && (year % 100 != 0))
					{high =29;}
				else if (year % 400 == 0) {high=29;}
			} else {
				high = 29;
			}
			break;
		case 1:
		case 3:
		case 5:
		case 7:
		case 8:
		case 10:
		case 12:
			high =31;
			break;
		default:
			high =30;
	}
	return high;
}

function checknumber(data){
	
	var re = /^[\-\+]?([0-9]+)(\.\d+)?$/;
	if (re.test(data)) 
		return true;
	
	return false;
}
