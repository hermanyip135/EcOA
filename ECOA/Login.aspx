<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="广州中原电子审批系统" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>中原电子审批系统--登陆</title>
    <link rel="stylesheet" type="text/css" href="images/style.css" />
    <script type="text/javascript" src="Script/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="Script/cursorfocus.js"></script>
    <script type="text/javascript">
        function changePWD() {
            window.showModalDialog("SysSetting/Pwd_Change.aspx", "", "dialogHeight=185px");
        }
    </script>
    <style>
        body
        {
            background-image: url("/Images/bg.gif");
        }
    </style>
</head>
<body>
<form runat="server">
<div id="login_body">
	<div id="login_div_main">
		<div id="login_form_div">
				<table width="300">
				<tbody>
				    <tr>
					    <td width="173">
                    	    <label>工号<br />
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="login_input" TabIndex="1"></asp:TextBox>
                            </label>
                            <br />
                            <label>密码<%--<a href="javascript:;" onclick="changePWD();" style=" font-size:11px; margin-left:30px;" tabindex="3">修改密码</a>--%><br />
                                <asp:TextBox ID="txtUserPwd" runat="server" CssClass="login_input"  TextMode="Password" TabIndex="2"></asp:TextBox>
                            </label>
                            <br />
                        </td>
                        <td>
                            <asp:ImageButton runat="server" CssClass="login_btn" ImageUrl="~/Images/login_btn.gif" onclick="loginsubmit_Click" />
                        </td>
                    </tr>
				    <tr>
				        <td colspan="2" class="tipbox">
				            <span style="font-size:12px;">提示：<asp:Label ID="lbMsg" runat="server" Text="请使用佣金系统帐号密码"></asp:Label></span>
                        </td>
				    </tr>
				</tbody>
                </table>
		</div>
	</div>
	<div id="login_footer">中原电子审批系统</div>
</div>
</form>
</body>
</html>
