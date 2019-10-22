<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeOut.aspx.cs" Inherits="TimeOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript">
        alert("登录超时，请重新登录！");
        window.location = '/Login.aspx?backurl=<%=GetQueryString("backurl") %>';
    </script>
    </div>
    </form>
</body>
</html>
