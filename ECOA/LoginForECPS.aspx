<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginForECPS.aspx.cs" Inherits="LoginForECPS" Title="广州中原电子审批系统" EnableViewStateMac="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>中原电子审批系统--登陆</title>
<%--    <link rel="stylesheet" type="text/css" href="images/style.css" />
    <script type="text/javascript" src="Script/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="Script/cursorfocus.js"></script>--%>
    <script type="text/javascript">
        function showWin(url) {
            window.open(url, "winECOA");
            window.opener = null;
            window.open('', '_self');
            window.close();
        }
        //function showWin(url) {
        //    aler('您好!!!' + url);
        //}
    </script>
</head>
<body>
    <form id="Form1" runat="server">
         
        <%--没有form，aspx页面不能执行ClientScript.RegisterStartupScript--%>
    </form>
</body>
</html>