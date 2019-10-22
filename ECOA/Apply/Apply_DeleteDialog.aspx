<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_DeleteDialog.aspx.cs" Inherits="Apply_DeleteDialog" Title="删　除 - 广州中原电子审批系统" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>删　除</title>
    <link rel="Stylesheet" href="/Style/style.css" />
    <script type="text/javascript" src="../../Script/jquery-1.7.min.js"></script>
    <base target="_self" />
    <style type="text/css">
        .button {
	        display: block;
	        width: 175px;
	        min-width: 175px;
	        height: 41px;
	        line-height: 38px;
	        font-family: BryantRegular;
	        font-size: 18px;
	        margin: 0 auto;
	        cursor:pointer;
        }
        .btn 
        {
            min-width:100px;
	        width:auto;
	        padding: 0px 10px 0px 10px;
	        float:left;
	        margin-left:5px;
        }
    </style>
    <script type="text/javascript">
        var id;
        $(function() {
            id = window.dialogArguments;
            var text = document.getElementById("txtDeleteMessage");
            autoTextarea(text); //使对话框自适应   
            //$("[id*=btnAgreeD]").css({
            //    "background-image": "url(/Images/btnAgreeD1.png)",
            //    "height": "25px",
            //    "border-style": "none",
            //    "border-color": "inherit",
            //    "width": "44px",
            //    "cursor":"pointer"
            //});
            //$("[id*=btnAgreeD]").mousedown(function () { $(this).css("background-image", "url(/Images/btnAgreeD2.png)"); })
            //    .mouseup(function () { $(this).css("background-image", "url(/Images/btnAgreeD1.png)"); })
            //    .mouseleave(function () { $(this).css("background-image", "url(/Images/btnAgreeD1.png)"); });

            //$("[id*=btnSendDeleteMessage]").css({
            //    "background-image": "url(/Images/btnSendDeleteMessage1.png)",
            //    "height": "25px",
            //    "border-style": "none",
            //    "border-color": "inherit",
            //    "width": "47px",
            //    "cursor":"pointer"
            //});
            //$("[id*=btnSendDeleteMessage]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSendDeleteMessage2.png)"); })
            //    .mouseup(function () { $(this).css("background-image", "url(/Images/btnSendDeleteMessage1.png)"); })
            //    .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSendDeleteMessage1.png)"); });

            //$("[id*=btnNotAgreeD]").css({
            //    "background-image": "url(/Images/btnNotAgreeD1.png)",
            //    "height": "25px",
            //    "border-style": "none",
            //    "border-color": "inherit",
            //    "width": "58px",
            //    "cursor":"pointer"
            //});
            //$("[id*=btnNotAgreeD]").mousedown(function () { $(this).css("background-image", "url(/Images/btnNotAgreeD2.png)"); })
            //    .mouseup(function () { $(this).css("background-image", "url(/Images/btnNotAgreeD1.png)"); })
            //    .mouseleave(function () { $(this).css("background-image", "url(/Images/btnNotAgreeD1.png)"); });
        })
        
        $(window).unload(function() {
            //window.returnValue = $("#hFilePath").val();
        });

        function check() {
            //if ($.trim($("#txtFilePath").val()) == '') {
            //    alert("请选择附件!");
            //    $("#txtFilePath").focus();
            //    return false;
            //}

            return true;
        }

        var autoTextarea = function (elem, extra, maxHeight) { //对话框自适应
            extra = extra || 0;
            var isFirefox = !!document.getBoxObjectFor || 'mozInnerScreenX' in window,
            isOpera = !!window.opera && !!window.opera.toString().indexOf('Opera'),
                    addEvent = function (type, callback) {
                        elem.addEventListener ?
                                elem.addEventListener(type, callback, false) :
                                elem.attachEvent('on' + type, callback);
                    },
                    getStyle = elem.currentStyle ? function (name) {
                        var val = elem.currentStyle[name];

                        if (name === 'height' && val.search(/px/i) !== 1) {
                            var rect = elem.getBoundingClientRect();
                            return rect.bottom - rect.top -
                                    parseFloat(getStyle('paddingTop')) -
                                    parseFloat(getStyle('paddingBottom')) + 'px';
                        };

                        return val;
                    } : function (name) {
                        return getComputedStyle(elem, null)[name];
                    },
                    minHeight = parseFloat(getStyle('height'));

            elem.style.resize = 'none';

            var change = function () {
                var scrollTop, height,
                        padding = 0,
                        style = elem.style;

                if (elem._length === elem.value.length) return;
                elem._length = elem.value.length;

                if (!isFirefox && !isOpera) {
                    padding = parseInt(getStyle('paddingTop')) + parseInt(getStyle('paddingBottom'));
                };
                scrollTop = document.body.scrollTop || document.documentElement.scrollTop;

                elem.style.height = minHeight + 'px';
                if (elem.scrollHeight > minHeight) {
                    if (maxHeight && elem.scrollHeight > maxHeight) {
                        height = maxHeight - padding;
                        style.overflowY = 'auto';
                    } else {
                        height = elem.scrollHeight - padding;
                        style.overflowY = 'hidden';
                    };
                    style.height = height + extra + 'px';
                    scrollTop += parseInt(style.height) - elem.currHeight;
                    document.body.scrollTop = scrollTop;
                    document.documentElement.scrollTop = scrollTop;
                    elem.currHeight = parseInt(style.height);
                };
            };

            addEvent('propertychange', change);
            addEvent('input', change);
            addEvent('focus', change);
            change();
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div>
                <div style="padding-top: 10px; padding-left: 10px">
                    <asp:Label ID="lbA7" runat="server" Text="请填写删除原因："></asp:Label><br />
                    <asp:TextBox ID="txtDeleteMessage" runat="server" Height="150px" TextMode="MultiLine" Width="630px"></asp:TextBox>
                </div>
                <div style="margin-bottom:10px; margin-top: 10px; text-align: center; width: 630px;">
                    <asp:Button ID="btnAgreeD" runat="server" Text="同意" OnClick="btnAgreeD_Click" />&nbsp;
                    <asp:Button ID="btnSendDeleteMessage" runat="server" Text="发送" OnClick="btnSendDeleteMessage_Click" />&nbsp;
                    <asp:Button ID="btnNotAgreeD" runat="server" Text="不同意" OnClick="btnNotAgreeD_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
