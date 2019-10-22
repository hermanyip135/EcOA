<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_DetailAssetNew.aspx.cs" Inherits="Apply_Scrap_Apply_DetailAssetNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查找资产</title>
    <script type="text/javascript" src="/Script/jquery-1.9.1.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Style/css.css" />
    <style type="text/css">
        .astyle {
            width: 85px;
            background-image: url(/Images/small_search1.png);
            height: 24px;
            border-style: none;
            border-color: inherit;
            width: 43px;
            font-size: 0px;
            cursor: pointer;
            color: #FFFFFF;
        }

        .fltr {
            float: right;
            color: #003300;
            font-size: x-large;
        }

        .auto-style1 {
            width: 845px;
        }
        #gvData td,#gvData th{font-size:12px}
        .noborder{font-size:12px}
        .confrimTB{display:none}
        .tb{background:#333333;width:90%;margin:0 auto;text-align:center}
        .tb td{background:#fff;border:0;padding:5px;height:24px;font-size:12px}
        .tb th{background:#507cd1;color:#fff;font-weight:700;padding:5px;font-size:12px}
        input.commonbtn[type="button"]{background:url("../../images/btn_save1_03.png") repeat-x scroll 0 0;border:1px solid #4c68d5;*border:0;border-radius:5px;color:#fff;cursor:pointer;font-family:微软雅黑;font-weight:700;height:34px;overflow:hidden;padding:0 10px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>

                <table style="width: 90%; margin: 0 auto; margin-bottom: 5px;" class="sel">
                    <tr class="noborder">
                        <td>资产名称：<asp:TextBox ID="txtClassesId" runat="server"></asp:TextBox>
                            财务编号：<asp:TextBox ID="txtAssetNo" runat="server"></asp:TextBox>
                            入账时间：<asp:TextBox ID="txtBeginTime" runat="server"></asp:TextBox>～<asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>
                            <asp:Button ID="btnsSearch" runat="server" OnClick="btnSearch_Click" Style="margin-left: 10px;" Text="" CssClass="astyle" />
                        </td>
                    </tr>
                </table>

                <asp:GridView ID="gvData" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false" CssClass="sel"
                    OnPageIndexChanging="gvData_PageIndexChanging" GridLines="None" Width="90%" AllowPaging="true" PageSize="20" DataKeyNames="Asset_id" BorderWidth="0px" BorderStyle="None" HorizontalAlign="Center" OnRowDataBound="gvData_RowDataBound" EmptyDataText="没有找到相关的资产，请检查输入的资料有没有正确">
                    <Columns>
                        <asp:TemplateField HeaderText="选择" ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkSelected" runat="server" /><input type="hidden" class="AssetID" name="AssetID" value="<%#Eval("Asset_id") %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-CssClass="txtType" HeaderText="归　属" DataField="txtType" ItemStyle-Width="13%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                        <asp:BoundField ItemStyle-CssClass="txtClasses" HeaderText="资产名称" DataField="txtClasses" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                        <asp:BoundField ItemStyle-CssClass="AssetAssetNo" HeaderText="财务编号" DataField="Asset_AssetNo" ItemStyle-Width="17%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                        <asp:BoundField ItemStyle-CssClass="txtTS" HeaderText="规格型号" DataField="txtTS" ItemStyle-Width="17%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                        <asp:BoundField ItemStyle-CssClass="AssetRecordedTime" HeaderText="入账时间" DataField="Asset_RecordedTime" ItemStyle-Width="10%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <PagerStyle HorizontalAlign="Center" />
                    <PagerTemplate>
                        当前第:
                <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                        页/共:
                <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                        页
                <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page" Font-Bold="true" OnClientClick="CNull();" Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" Font-Bold="true"
                            OnClientClick="CNull();" CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true"
                            OnClientClick="CNull();" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                            OnClientClick="CNull();" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                        转到第
                <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="CNull();$('#hdPagerNum').val($('#gvData_ctl23_txtNewPageIndex').val())"
                    CommandName="Page" Text="GO" />
                    </PagerTemplate>
                </asp:GridView>

            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>

        <div id="confrimTB" class="confrimTB submit" >
            <table id="tb" class="tb" cellspacing="1" cellpadding="0">
                <thead id="thead"></thead>
                <tbody id="tbody">
                    <tr><td colspan="7">没有选择任何资产</td></tr>
                </tbody>
                
            </table>
        </div>

        <div style="width: 90%; margin: 0 auto; text-align: center; padding-top: 15px;">
            <asp:Button ID="btnSure" runat="server" Text="确认" OnClick="btnSure_Click" CssClass="commonbtn submit" style="display:none" />
            <asp:Button ID="btnConfrim" runat="server" Text="确认" CssClass="commonbtn sel" OnClientClick="confirmzc(true);return false;" />
            <input type="button" class="commonbtn sel" id="btnSaveContent" name="btnSaveContent" onclick="save();return false;" value="保存选择"  />
            <asp:Button ID="btnBackTB" runat="server" Text="返回选择资产" CssClass="commonbtn submit" style="display:none" OnClientClick="backsel();return false;"/>
            <asp:Button ID="btnBack" runat="server" Text="返回" OnClientClick="window.returnValue='';window.close();return false;" CssClass="commonbtn sel" />
            <%--保存被选中的资产json--%>
            <asp:HiddenField ID="hidContent" runat="server" />
        </div>
        <br />
        <br />
        <input type="hidden" id="hdPagerNum" runat="server" value="1" />
    </form>
</body>
    <script type="text/javascript" src="../../Script/common.js"></script>
    <script type="text/javascript">
        function PageInit()
        {
            //gv初始化
            var l = $("#hidContent").val() == "" ? [] : $("#hidContent").val().evalJSON();//string.evalJSON(); common.js 方法
            if (l.length > 0) {
                for (var j = 0; j < $("#gvData tr").length ; j++) {
                    var AssetID = $("#gvData tr").eq(j).find("input.AssetID").val();                             //ID;
                    var $checkbox = $("#gvData tr").eq(j).find("input[type='checkbox']");
                    var flag = false;
                    for (var i = 0; i < l.length; i++) {
                        if (AssetID != undefined && AssetID == l[i].AssetID) {
                            flag = true;
                        }
                    }
                    if ($checkbox.index() > -1) {
                        $checkbox.get(0).checked = flag;
                    }
                }
            }

            CanEdit("<%=flag%>");
        }

        //是否能编辑
        function CanEdit(flag)
        {
            if (flag != "CanEdit")
            {
                //只读模式
                //显示确认列表
                confirmzc(false);
                $("#btnSure").hide();
                $("#btnBackTB").hide();
                $("#btnBack").show();
            }
        }
        //确认
        function confirmzc(canedit) {
            var content = $.trim($("#hidContent").val());
            if (content == "" || content == "[]") {
                alert("请选择资产");
                return;
            }
            $(".submit").show();
            $(".sel").hide();
            var showdel = "style='width:4%'";
            if (!canedit)
            {
                showdel = "style=display:none";
            }
            var zc = content.evalJSON();

            var headhtml = '<tr><th style="width:4%">序  号</th><th ' + showdel + ' style="width:8%">操  作</th><th style="width:15%">归　属</th><th style="width:15%">资产名称</th><th style="width:15%">财务编号</th><th style="width:15%">规格型号</th><th style="width:15%">入账时间</th><th style="width:8%">数量</th><th style="width:15%">折旧摊分剩余费用</th></tr>';

            var html = "";
            for (var i = 0; i < zc.length; i++) {
                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";                                            //序号
                html += "<td " + showdel + "><a href='javascript:;' onclick='del(\"" + zc[i].AssetID + "\",this)'><img src='/Images/disable.gif' /></a></td>";
                html += "<td>" + zc[i].AssetType + "</td>";                          //归属
                html += "<td>" + zc[i].AssetClasses + "</td>";                       //资产名称
                html += "<td>" + zc[i].AssetAssetNo + "</td>";                       //财务编号
                html += "<td>" + zc[i].AssetTS + "</td>";                            //规格型号
                html += "<td>" + zc[i].AssetRecordedTime + "</td>";                  //入账时间
                html += "<td>" + zc[i].AssetNumber + "</td>";                        //数量
                html += "<td>" + zc[i].AssetSurplusValue + "</td>";                  //折旧摊分剩余费用
                //zc[i];
                html += "</tr>"
            }
            $("#tbody").html(html);
            $("#thead").html(headhtml);
        }

        function backsel()
        {
            $(".submit").hide();
            $(".sel").show();
        }

        //保存选择的内容保存到hidContent中
        function save() {
            var array = new Array();        //被选中的实体列表
            var delarray = new Array();     //没被选择中ID列表
            var data;                       //暂存实体

            $("#gvData td input[type='checkbox']").each(function () {
                var tr = $(this).parent().parent();
                var AssetID = tr.find("input.AssetID").val();                             //ID
                if (this.checked) {
                    var AssetType = tr.find("td.txtType").html();                           //归属
                    var AssetClasses = tr.find("td.txtClasses").html();                         //资产名称
                    var AssetAssetNo = tr.find("td.AssetAssetNo").html();                     //财务编码
                    var AssetTS = tr.find("td.txtTS").html();                                       //规格型号
                    var AssetRecordedTime = tr.find("td.AssetRecordedTime").html();           //入账时间
                    var AssetNumber = "1";
                    var AssetSurplusValue = "";
                    //生成json
                    data = { "AssetID": AssetID, "AssetType": AssetType, "AssetClasses": AssetClasses, "AssetAssetNo": AssetAssetNo, "AssetTS": AssetTS, "AssetRecordedTime": AssetRecordedTime, "AssetNumber": AssetNumber, "AssetSurplusValue": AssetSurplusValue };
                    array.push(data);//插入
                }
                else {
                    delarray.push(AssetID);
                }
            });

            //新增或者修改实体
            var json = new Array();
            var list = $("#hidContent").val() == "" ? [] : $("#hidContent").val().evalJSON();//string.evalJSON(); common.js 方法
            if (array.length > 0) {
                var newlist = list;
                if (list.length > 0) {
                    //已保存选择
                    for (var i = 0; i < array.length; i++) {
                        for (var j = 0; j < list.length; j++) {
                            if (array[i].AssetID == list[j].AssetID) {
                                //财务编码相同，修改原有实体
                                newlist[j] = array[i];
                                break;
                            }
                            if (j == list.length - 1) {
                                //执行到最后一轮都不执行break（实体添加到array）
                                newlist.push(array[i]);
                            }
                        }
                    }
                    json = newlist;
                }
                else {
                    //没保存任何选择
                    json = array;
                }
            }
            else {
                json = list;
            }

            //去掉没选中的
            var templist = json;
            if (delarray.length > 0 && templist.length > 0) {
                json = new Array();
                var flag = true;                    //是否插入队列
                for (var i = 0; i < templist.length; i++)
                {
                    flag = true;
                    for (var j = 0; j < delarray.length; j++)
                    {
                        if (templist[i].AssetID == delarray[j])
                        {
                            //删除队列中有的ID flag=false
                            flag = false;
                        }
                    }
                    if (flag) {
                        json.push(templist[i]);
                    }
                }
            }
            $("#hidContent").val(Obj2str(json)); //common.js 方法

            alert("保存成功");
            return;
        }

        //删除实体
        function del(AssetID,obj) {
            var list = $("#hidContent").val() == "" ? [] : $("#hidContent").val().evalJSON();//string.evalJSON(); common.js 方法
            if (list.length == 0) {
                return;
            }
            for (var i = 0; i < list.length; i++) {
                if (list[i].AssetID == AssetID) {
                    list.remove(i);   //Array.remove删除(common.js 方法)
                    break;
                }
            }
            $(obj).parent().parent().remove();
            $("#hidContent").val(Obj2str(list));    //Obj2str(value) common.js 方法
            PageInit();
        }

        PageInit();
    </script>
</html>