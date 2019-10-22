
activeMenuRootID = null;

menuBoxDivPrefix = "tmbx_";
menuItemPrefix = "tmitem_";
menuArrowPrefix = "tmraimg_";
menuPopBoxDivPrefix = "tppbx_";
menuPopItemPrefix = "tppitem_";
menuPopArrowPrefix = "tppraimg_";

cancelHideMenu = false;
timeoutHideMenu = false;
timeoutHidePopMenu = false;
cancelHidePopMenu = false;
menuActive = false;
activePopMenu = false;
mnWrapping = false;
menuRoots = false;

function MenuNode(id,pid,str,url,img,dis,opt,tgt)
{
	this.id = id;
	this.pid = pid;
	this.str = str;
	this.url = url;
	this.img = img;
	this.disabled = dis;
	this.option = opt;
	this.target = tgt;
	this.parent = false;
	this.firstChild = false;
	this.nextSibling = false;

	this.boxobj = false;
	this.arrowobj = false;
	this.itemobj = false;
	this.popobj = false;
	this.GetBoxObj  = TMN_GetBoxObj;
	this.GetArrowObj  = TMN_GetArrowObj;
	this.GetItemObj  = TMN_GetItemObj;
	this.GetPopupBoxObj  = TMN_GetPopupBoxObj;
	this.ClearObj = TMN_ClearObj;
	return this;
}

function TMN_ClearObj()
{
	this.boxobj = false;
	this.itemobj = false;
	this.arrowobj = false;
	this.popobj = false;
}

function TMN_GetBoxObj(doc)
{
	if (!this.boxobj)
		this.boxobj = doc.all[menuBoxDivPrefix+this.id];
	return this.boxobj;
}

function TMN_GetArrowObj(doc)
{
	if (!this.arrowobj)
		this.arrowobj = doc.all[menuArrowPrefix+this.id];
	return this.arrowobj;
}

function TMN_GetItemObj(doc)
{
	if (!this.itemobj)
		this.itemobj = doc.all[menuItemPrefix+this.id];
	return this.itemobj;
}

function TMN_GetPopupBoxObj(doc)
{
	if (!this.popobj)
		this.popobj = doc.all[menuPopBoxDivPrefix+this.id];
	return this.popobj;
}

function FindMenuNodeByID(roots,id)
{
	var i;
	var node;

	for (i=0;i<roots.length;i++){
		node = FindMenuNodeInRoot(roots[i],id);
		if (node)
			return node;
	}
	return false;
}

function FindMenuNodeInRoot(root,id)
{
	var node;
	var tmp;

	if (root.id==id){
		return root;
	}

	for (node=root.firstChild;node;node=node.nextSibling){
		tmp = FindMenuNodeInRoot(node,id);
		if (tmp)
			return tmp;
	}
	return false;
}

function InsertMenuNodeByID(roots,node)
{
	var root;
	var i;
	
	for (i=0;i<roots.length;i++){
		if (InsertMenuNodeInRoot(roots[i],node))
			return;
	}
	roots[roots.length] = node;
}

function InsertMenuNodeInRoot(root,node)
{
	var pnode = FindMenuNodeInRoot(root,node.pid);
	if (!pnode)
		return false;

	node.parent = pnode;
	if (!pnode.firstChild){
		pnode.firstChild = node;
		return true;
	}
	var tmp;
	for (tmp=pnode.firstChild;tmp.nextSibling;tmp=tmp.nextSibling);
	tmp.nextSibling = node;
	return true;
}

function GetMenuNodeByID(id)
{
	return FindMenuNodeByID(menuRoots,id);
}
function GetElementX(obj)
{
	var x = 0;
	while (obj!=document.body){
		x += obj.offsetLeft;
		obj=obj.parentElement;
	}
	return x;
}
function GetElementY(obj)
{
	var y = 0;
	while (obj!=document.body){
		y += obj.offsetTop;
		obj=obj.parentElement;
	}
	return y;
}
function GenMenuBoxDiv(id,node)
{
	var divobj = node.GetBoxObj(document);
	if (divobj+''!='undefined')
		return divobj;
	var divName = menuBoxDivPrefix+id;
	var div = document.createElement("DIV");
	div.style.visibility = "hidden";
	div.setAttribute("id",divName);
	div.className = "menuBox";
	div.onselectstart = function(){return false};
	var i;
	var str = "<TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0>";
	var tmp;

	for (tmp=node.firstChild;tmp;tmp=tmp.nextSibling){
		str += GenMenuBoxItem(tmp);
	}
	str += "</TABLE>";
	div.innerHTML = str;
	document.body.appendChild(div);
	return div;
}
mnSavedOnScroll=null;
function GenMenu()
{
	if (window.top.MenuFrame+''=='undefined')
		return;
	if (window.top.MenuFrame.document.frmStatus+''=='undefined' ||
		window.top.MenuFrame.document.frmStatus.finished.value+''=='0'){
		setTimeout("GenMenu();",50);
		return;
	}

	window.top.MenuFrame.ResetMenu();
	menuRoots = window.top.MenuFrame.GetMenuRootArray();
	var tbl = document.all["menuBar"];
	var row = tbl.rows(0);
	tbl.onselectstart = function(){return false;};
	var i;
	var cell;
	for (i=0;i<menuRoots.length;i++){
		cell = row.insertCell(i+1);
		cell.className = "menuItem1";
		cell.noWrap = true;
		cell.innerHTML = GenMenuBarItem(menuRoots[i]);
	}

}
function AnchorMenuBar()
{
	var obj = document.all["menuBar"].style;
	obj.pixelTop = document.body.scrollTop;
	if (mnSavedOnScroll!=null)
		mnSavedOnScroll();
}

function GenMenuBarItem(node)
{
	var id = node.id;
	var txt = node.str;
	var divName = menuItemPrefix+id;
	var str = "<DIV ID=\""+divName+"\" CLASS=\"menuRoot\" ONMOUSEOVER=\"PullDownMenu(this,"+id+");\" ONMOUSEOUT=\"LeaveMenuRoot(this);\" ONCLICK=\"menuActive=true;PullDownMenu(this,"+id+");\">";
	str += txt;
	str += "</DIV>";
	return str;
}

function GenMenuBoxItem(node)
{
	var id = node.id;
	var txt = node.str;
	var url = node.url;
	var img = node.img;
	var dis = node.disabled;
	var opt = node.option;
	var tgt = node.target;
	var divName = menuItemPrefix+id;
	var imgName = menuArrowPrefix+id;
	var cls;
	var clk;
	if (dis)
		cls = "menuItemDis";
	else
		cls = "menuItem";
	var str;
	if (txt=="----"){
		str = "<TR ID=\""+divName+"\" CLASS=\""+cls+"\" ONMOUSEOVER=\"CancelHideMenu();\" ONMOUSEOUT=\"LeaveMenu();\">";
		str += "<TD COLSPAN=3><HR SIZE=0></TD>";
		str += "</TR>";
	}
	else{
		if (!dis){
			if (opt!="")
				clk = opt;
			else if (tgt!="" && url!="")
				clk = "ONCLICK=\"window.open('"+url+"','"+tgt+"');\"";
			else if (url!="")
				clk = "ONCLICK=\"window.location='"+url+"';\"";
			else
				clk = '';
		}
		else
			clk = '';
		if (img!="")
			img = "<IMG BORDER=0 STYLE=\"margin-left:3px;\" SRC=\""+img+"\">";
		else
			img = "&nbsp;";
		str = "<TR ID=\""+divName+"\" CLASS=\""+cls+"\" ONMOUSEOVER=\"HighlightMenuItem(this,"+id+");\" ONMOUSEOUT=\"LeaveMenu();\" "+clk+">";
		str += "<TD NOWRAP WIDTH=16>"+img+"</TD><TD NOWRAP>"+txt+"</TD><TD NOWRAP ALIGN=RIGHT>&nbsp;&nbsp;";
		if (node.firstChild)
			str += "<IMG NAME=\""+imgName+"\" SRC=\"../Images/right_arrow_black.gif\" BORDER=0>&nbsp;";
		str += "</TD>";
		str += "</TR>";
	}

	return str;
}

function WrapupMenu(id)
{
	mnWrapping = true;
	var pnode = GetMenuNodeByID(id);
	var node,mn,tid;
	for (node=pnode.firstChild;node;node=node.nextSibling){
		tid = node.id;
		mn = node.GetItemObj(document);
		if (mn.style.display=='none')
			continue;
		else{
			mn.style.display = 'none';
			setTimeout("WrapupMenu("+id+");",15);
			return;
		}
	}
	node = GetMenuNodeByID(id);
	var mbox = node.GetBoxObj(document);
	mbox.style.visibility = 'hidden';
	for (node=pnode.firstChild;node;node=node.nextSibling){
		tid = node.id;
		mn = node.GetItemObj(document);
		mn.style.display = 'block';
	}
	mnWrapping = false;
}
function HideAllMenus(immediate)
{
	var i;

	if (activeMenuRootID==null)
		return;
	var node = GetMenuNodeByID(activeMenuRootID);
	HideAllSubMenus(node);
	var mbox = node.GetBoxObj(document);
	if (mbox+''!='undefined'){
		if (immediate)
			mbox.style.visibility = "hidden";
		else
			WrapupMenu(activeMenuRootID);
	}
	node.GetItemObj(document).className = "menuRoot";
	activeMenuRoot = null;
}

function PullDownMenu(div,id)
{
	
	if (document.readyState!="complete"){
		return;
	}
	if (!menuActive){
		div.className = "menuRootHighlight";
		return;
	}
	HideAllMenus(true);
	div.className = "menuRootOn";
	activeMenuRootID = id;
	var node = GetMenuNodeByID(id);
	if (!node.firstChild)
		return;
	var mbox = GenMenuBoxDiv(id,node);
	CancelHideMenu();
	if (document.onclick!=null)
		document.onclick();
	mbox.style.visibility = "visible";
	mbox.style.pixelTop = div.offsetHeight+2;
	var x = GetElementX(div)-6;
	if (x+mbox.offsetWidth>document.body.clientWidth+document.body.scrollLeft)
		x = document.body.clientWidth+document.body.scrollLeft-mbox.offsetWidth;
	mbox.style.pixelLeft = x;
}
function HideAllSubMenus(pnode)
{
	var i,j;
	var id;
	var mbox;
	var cls;
	var node;
		
	for (node=pnode.firstChild;node;node=node.nextSibling){
		id = node.id;
		if (node.firstChild){
			mbox = node.GetBoxObj(document);
			if (mbox+''!='undefined' && mbox.style.visibility == "visible"){
				HideAllSubMenus(node);
				mbox.style.visibility = "hidden";
			}
			node.GetArrowObj(document).src = "../Images/right_arrow_black.gif";
		}
		if (node.disabled)
			cls = "menuItemDis";
		else
			cls = "menuItem";
		var mn = node.GetItemObj(document);
		if (mn.className!=cls)
			mn.className=cls;
	}
}

function HighlightMenuItem(div,id)
{
	if (mnWrapping)
		return;
	var node = GetMenuNodeByID(id);
	var pnode = node.parent;
	HideAllSubMenus(pnode);
	var cls,dis=false;
	if (node.disabled){
		cls = "menuItemDisOn";
		dis = true;
	}
	else
		cls = "menuItemOn";
	div.className = cls;

	var mbox;
	if (node.firstChild && !dis){
		node.GetArrowObj(document).src = "../Images/right_arrow_white.gif";
		mbox = GenMenuBoxDiv(id,node);
		mbox.style.pixelTop = GetElementY(div);
		var x = GetElementX(div)+div.offsetWidth-1;
		if (x+mbox.offsetWidth>document.body.clientWidth+document.body.scrollLeft)
			x = x-div.offsetWidth-mbox.offsetWidth+4;
		mbox.style.pixelLeft = x;
		mbox.style.visibility = "visible";
	}
	CancelHideMenu();
}
function Wake2HideMenu()
{
	if (cancelHideMenu)
		return;
	HideAllMenus(false);
	menuActive = false;
}
function CancelHideMenu()
{
	cancelHideMenu = true;
	if (timeoutHideMenu){
		clearTimeout(timeoutHideMenu);
		timeoutHideMenu = false;
	}
}

function LeaveMenuRoot(div)
{
	if (!menuActive){
		div.className = "menuRoot";
		return;
	}
	LeaveMenu();
}

function LeaveMenu()
{
	cancelHideMenu = false;
	if (timeoutHideMenu)
		clearTimeout(timeoutHideMenu);
	timeoutHideMenu = setTimeout("Wake2HideMenu();",600);
}


function GenPopMenuDiv(node,dynamic)
{
	var divName = menuPopBoxDivPrefix+node.id;
	var div = document.all[divName];
	if (div+''!='undefined' && dynamic==false)
		return div;
	var append = false;
	if (div+''=='undefined'){
		append = true;
		div = document.createElement("DIV");
		div.style.visibility = "hidden";
		div.setAttribute("id",divName);
		div.className = "menuBox";
		div.onselectstart = function(){return false};
	}
	var i;
	var str = "<TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0>";
	var tmp;

	for (tmp=node.firstChild;tmp;tmp=tmp.nextSibling){
		str += GenPopMenuItem(tmp);
	}
	str += "</TABLE>";
	div.innerHTML = str;
	if (append){
		document.body.appendChild(div);
	}
	return div;
}

function GenPopMenuItem(node)
{
	var id = node.id;
	var txt = node.str;
	var url = node.url;
	var img = node.img;
	var dis = node.disabled;
	var opt = node.option;
	var tgt = node.target;
	var divName = menuPopItemPrefix+id;
	var imgName = menuPopArrowPrefix+id;
	var cls;
	var clk;
	if (dis)
		cls = "menuItemDis";
	else
		cls = "menuItem";
	var str;
	if (txt=="----"){
		str = "<TR ID=\""+divName+"\" CLASS=\""+cls+"\" ONMOUSEOVER=\"CancelHidePopMenu();\" ONMOUSEOUT=\"LeavePopMenu();\">";
		str += "<TD COLSPAN=3><HR SIZE=0></TD>";
		str += "</TR>";
	}
	else{
		if (!dis){
			if (opt!="")
				clk = opt;
			else if (tgt!="" && url!="")
				clk = "ONCLICK=\"window.open('"+url+"','"+tgt+"');\"";
			else if (url!="")
				clk = "ONCLICK=\"window.location='"+url+"';\"";
			else
				clk = '';
		}
		else
			clk = '';
		if (img!="")
			img = "<IMG BORDER=0 STYLE=\"margin-left:3px;\" SRC=\""+img+"\">";
		else
			img = "&nbsp;";
		str = "<TR ID=\""+divName+"\" CLASS=\""+cls+"\" ONMOUSEOVER=\"HighlightPopMenuItem(this);\" ONMOUSEOUT=\"LeavePopMenuItem(this);\" "+clk+">";
		str += "<TD NOWRAP WIDTH=20>"+img+"</TD><TD NOWRAP>"+txt+"<TD NOWRAP ALIGN=RIGHT>&nbsp;&nbsp;";
		str += "&nbsp;</TD>";
		str += "</TR>";
	}

	return str;
}

function HighlightPopMenuItem(div)
{
	if (div.className=="menuItem"|| div.className=="menuItemOn")
		div.className = "menuItemOn";
	else
		div.className = "menuItemDisOn";
	CancelHidePopMenu();
}

function ShowPopMenu(node,dynamic)
{
	if (activePopMenu)
		HidePopMenu(activePopMenu);
	var div = GenPopMenuDiv(node,dynamic);
	if (document.onclick!=null)
		document.onclick();
	div.style.visibility = "visible";
	var y = event.clientY+document.body.scrollTop-4;
	if (y+div.offsetHeight>document.body.clientHeight+document.body.scrollTop)
		y = document.body.clientHeight+document.body.scrollTop-div.offsetHeight;
	div.style.pixelTop = y;
	div.style.pixelLeft = event.clientX+4;
	activePopMenu = node;
}
function HidePopMenu(node)
{
	var div = GenPopMenuDiv(node,false);
	div.style.visibility = "hidden";
	activePopMenu = false;
}

function LeavePopMenu()
{
	cancelHidePopMenu = false;
	setTimeout("Wake2HidePopMenu();",600);
}

function LeavePopMenuItem(div)
{
	if (div.className=="menuItem"|| div.className=="menuItemOn")
		div.className = "menuItem";
	else
		div.className = "menuItemDis";
	cancelHidePopMenu = false;
	setTimeout("Wake2HidePopMenu();",600);
}
function Wake2HidePopMenu()
{
	if (cancelHidePopMenu)
		return;
	HidePopMenu(activePopMenu);
}
function CancelHidePopMenu()
{
	cancelHidePopMenu = true;
	if (timeoutHidePopMenu){
		clearTimeout(timeoutHidePopMenu);
		timeoutHidePopMenu = false;
	}
}
