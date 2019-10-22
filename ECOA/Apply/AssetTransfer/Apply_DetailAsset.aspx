﻿<%@ Page Title="查找资产 - 广州中原电子审批系统" Language="C#" AutoEventWireup="true" CodeFile="Apply_DetailAsset.aspx.cs" Inherits="Apply_Apply_DetailAsset" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查找资产</title>
    <link rel="Stylesheet" href="/Style/style.css" />
    <script type="text/javascript" src="/Script/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Script/jquery-ui-1.10.1.custom.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui.datepicker-zh-CN.js"></script>
    <link rel="Stylesheet" href="/Style/DotLuv/jquery-ui-1.10.1.custom.css" />
    <link id="Link1" rel="Stylesheet" href="/Style/style.css" media="screen" type="text/css" runat="server" />
    <link href="/Style/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/Style/dropdown/themes/lwis.celebrity/default.advanced.css" media="screen" rel="stylesheet" type="text/css" />
    <base target="_self" />
    <script type="text/javascript">
        //var jJSON = <%=sbJSON.ToString() %>;
        $(function() {
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
            $.datepicker.setDefaults({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
                
            });

            $(":button").css("border", "none");
            $(":submit").css("border", "none");

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(check);
            check();
            function check() {
                $("[id*=btnsSearch]").mousedown(function () { $(this).css("background-image", "url(/Images/small_search2.png)"); })
                    .mouseup(function () { $(this).css("background-image", "url(/Images/small_search1.png)"); })
                    .mouseleave(function () { $(this).css("background-image", "url(/Images/small_search1.png)"); });
            }

            $('[id*=btnsSearch]').change(check); 

            $("[id*=btnSure]").css({
                "background-image": "url(/Images/btnSureS1.png)",
                "height": "25px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "43px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnSure]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); });

            $("[id*=btnBack]").css({
                "background-image": "url(/Images/btn25back1.png)",
                "height": "25px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "43px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnBack]").mousedown(function () { $(this).css("background-image", "url(/Images/btn25back2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn25back1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn25back1.png)"); });
        });
        function CNull(){
            //if($.trim($('#gvData_ctl08_txtNewPageIndex').val()) == ""){
            //    alert('!!!!!!!!!!!!!!!!!!!!!!!!');
            //    return false;
            //}
        }
    </script>
    <style type="text/css">
        .astyle {
            width: 85px;
            background-image: url(/Images/small_search1.png);
            height: 24px;
            border-style: none;
            border-color: inherit;
            width: 43px;
            font-size: 0px;
            cursor:pointer;
            color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <table style="width:95%;margin:0 auto">
        <tr class="noborder">
            <td>
                <asp:Panel ID="plSearch" runat="server">
                资产名称：<asp:TextBox ID="txtClassesId" runat="server"></asp:TextBox>　
                财务编号：<asp:TextBox ID="txtAssetNo" runat="server"></asp:TextBox>　
                规格型号：<asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
                <asp:Button ID="btnsSearch" runat="server" OnClick="btnSearch_Click" style="margin-left:10px;" Text="" CssClass="astyle" />
                </asp:Panel>
            </td>
            <td>
                <div style="width:90%;margin:0 auto; text-align: right; padding-top: 15px; color: #003300; font-size: x-large;">
                    共<asp:Label ID="lbSum" runat="server"></asp:Label>件资产
                </div>
            </td>
        </tr>
    </table>

        <asp:GridView ID="gvData" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="False"
    OnPageIndexChanging="gvData_PageIndexChanging" GridLines="None" Width="90%" AllowPaging="True" PageSize="20" DataKeyNames="OfficeAutomation_Document_AssetTransfer_Detail_AssetTag" HorizontalAlign="Center" OnRowDataBound="gvData_RowDataBound" EnableModelValidation="True" EmptyDataText="没有找到相关的资产，请检查输入的资料有没有正确" OnRowCommand="gvData_RowCommand" OnRowCreated="gvData_RowCreated">
            <%--<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />--%>
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:TemplateField HeaderText="删除" ItemStyle-Width="4%">
                <ItemTemplate>
                    <asp:ImageButton ID="iBtnDelete" runat="server"  ImageUrl="~/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Document_AssetTransfer_Detail_ID") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" />
            </asp:TemplateField>
                <asp:BoundField HeaderText="调出部门" DataField="OfficeAutomation_Document_AssetTransfer_Detail_DpmExp" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle">
                <ItemStyle VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="接收部门" DataField="OfficeAutomation_Document_AssetTransfer_Detail_DpmRec" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle">
                <ItemStyle VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="接收地点" DataField="OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle">
                <ItemStyle VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>

                <asp:BoundField HeaderText="财务编号" DataField="OfficeAutomation_Document_AssetTransfer_Detail_AssetTag" ItemStyle-Width="20%" ItemStyle-VerticalAlign="Middle">
                <ItemStyle VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="资产名称" DataField="OfficeAutomation_Document_AssetTransfer_Detail_AssetName" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle">
                <ItemStyle VerticalAlign="Middle" Width="13%" />
                </asp:BoundField>
                
                <asp:BoundField HeaderText="归　属" DataField="OfficeAutomation_Document_AssetTransfer_Detail_Number" ItemStyle-Width="10%" ItemStyle-VerticalAlign="Middle">
                <ItemStyle VerticalAlign="Middle" Width="10%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="规格型号" DataField="OfficeAutomation_Document_AssetTransfer_Detail_Model" ItemStyle-Width="20%" ItemStyle-VerticalAlign="Middle">
                <ItemStyle VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle HorizontalAlign="Center"/>
            <PagerTemplate>
                当前第:
                <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                页/共:
                <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                页
                <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page" Font-Bold="true" 
                    OnClientClick="CNull();" Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" Font-Bold="true"
                    OnClientClick="CNull();" CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true"
                    OnClientClick="CNull();" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                    OnClientClick="CNull();" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                转到第
                <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="CNull();$('#hdPagerNum').val($('#gvData_ctl05_txtNewPageIndex').val())"
                    CommandName="Page" Text="GO" />
            </PagerTemplate>
            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
        <div style="width:90%;margin:0 auto; text-align: center; padding-top: 15px;">
            <asp:Button ID="btnSure" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="确认" OnClick="btnSure_Click" Visible="False" />
            <asp:Button ID="btnBack" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="返回" OnClick="btnBack_Click" />
        </div>
    <br /><br />
    <input type="hidden" id="hdPagerNum" runat="server" value="1" />
</form>
</body>
</html>