<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_UploadFile20M.aspx.cs" Inherits="Apply_Apply_UploadFile20M" Title="上传附件 - 广州中原电子审批系统" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>上传附件</title>
    <link rel="Stylesheet" href="/Style/style.css" />
    <script type="text/javascript" src="../Script/jquery-1.7.min.js"></script>
    <base target="_self">
    <style>
        .button {
	        display: block;
	        width: 175px;
	        min-width: 175px;
	        height: 41px;
	        line-height: 38px;
	        font-family: BryantRegular;
	        font-size: 18px;
	        -webkit-border-radius: 0px;
	        -moz-border-radius: 0px;
	        margin: 0 auto;
	        -moz-box-shadow: none;
	        -webkit-box-shadow: none;
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
        })
        
        $(window).unload(function() {
            //window.returnValue = $("#hFilePath").val();
        });

        function check() {
            if ($.trim($("#txtFilePath").val()) == '') {
                alert("请选择附件!");
                $("#txtFilePath").focus();
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main" >
            <div>
                <div>
                    <input id="txtFilePath" runat="server" name="UploadFile" style="font-size: 14px; width: 470px; height:30px; margin:10px 0 10px 10px" type="file" />
                </div>
                <div style="clear:both; margin-bottom:10px;">
                    <asp:Button ID="btnUpload" runat="server" Text="上传附件" OnClick="btnUpload_Click" class="btn button" style="margin-left:10px;" OnClientClick="return check();" />
                    <input type="button" value="关闭" onclick="window.close();" class="btn button" />
                    <input type="hidden" id="hFilePath" runat="server" /> 
                </div>
            </div>
        </div>
    </form>
</body>
</html>
