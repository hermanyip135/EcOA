<%@ Control Language="C#" AutoEventWireup="true" CodeFile="User_AutoComplete.ascx.cs" Inherits="Common_User_AutoComplete" %>
<link rel="stylesheet" type="text/css" href="<%=RootPath%>Script/autocomplete2.css" />
<script type="text/javascript" src="<%=RootPath%>Script/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="<%=RootPath%>Script/jquery.autocomplete2.js"></script>
<script type="text/javascript" language="javascript">
    jQuery().ready(function($) {
        $("#<%=txtData.ClientID %>").autocomplete2({
            url: '<%=RootPath%>Common/User_AutoComplete.ashx?t=<%=Mode%>',
            values: true,
            writable: false,
            onSelect: function() {
                $("#<%=hfKey.ClientID %>").val(this.pairs[this.ac.val()]);
                var funName = "<%=OnSelected%>" + "('" + this.ac.val() + "','" + this.pairs[this.ac.val()] + "')";
                if (funName != "") {
                    eval(funName);
                }
            },
            type: 'json',
            onKeyPress: function() {
                $("#<%=hfKey.ClientID %>").val("");
            },
            width: '<%=Width%>'
        });
    });
    function SetDataValue(ctrlID,dv)
    {
        $("#"+ctrlID+"_txtData").attr("argData",dv);
    }
</script>

<asp:TextBox ID="txtData" runat="server"></asp:TextBox>
<asp:HiddenField ID="hfKey" runat="server" Value="" />