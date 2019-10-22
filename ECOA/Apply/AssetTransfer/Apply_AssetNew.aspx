<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_AssetNew.aspx.cs" Inherits="Apply_AssetTransfer_Apply_AssetNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查找资产</title>
    <link rel="Stylesheet" href="/Style/style.css" />
    <link rel="Stylesheet" href="/Style/DotLuv/jquery-ui-1.10.1.custom.css" />
    <link id="Link1" rel="Stylesheet" href="/Style/style.css" media="screen" type="text/css" runat="server" />
    <link href="/Style/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/Style/dropdown/themes/lwis.celebrity/default.advanced.css" media="screen" rel="stylesheet" type="text/css" />
    <base target="_self" />
    <link rel="stylesheet" type="text/css" href="../../Style/css.css" />
    <style>
        .confrimTB{display:none}
        .tb{background:#333333;width:90%;margin:0 auto;text-align:center}
        .tb td{background:#fff;border:0;padding:5px;height:24px}
        .tb th{background:#507cd1;color:#fff;font-weight:700;padding:5px}
        .RecordedTime{padding:0 5px}
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

        <table style="width: 90%; margin: 0 auto">
            <tr class="noborder">
                <td>资产名称：<asp:TextBox ID="txtClassesId" runat="server"></asp:TextBox>
                    财务编号：<asp:TextBox ID="txtAssetNo" runat="server"></asp:TextBox>
                    入账时间：<asp:TextBox ID="txtBeginTime" runat="server"></asp:TextBox>～<asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>
                    <asp:Button ID="btnsSearch" runat="server" OnClick="btnSearch_Click" Style="margin-left: 10px; margin-bottom: 10px;" Text="查询" CssClass="astyle" />
                </td>
            </tr>
        </table>

        <asp:GridView ID="gvData" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false"
            OnPageIndexChanging="gvData_PageIndexChanging" GridLines="None" Width="90%" AllowPaging="true" PageSize="20" DataKeyNames="Asset_id" BorderWidth="0px" BorderStyle="None" HorizontalAlign="Center" OnRowDataBound="gvData_RowDataBound">
            <Columns>
                <%--<asp:BoundField DataField="Asset_id" HeaderText="ID" Visible="False" ></asp:BoundField>--%>
                <asp:TemplateField HeaderText="选择全部" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelected" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="调出部门" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <label><%#Request.QueryString["Asset_Dpm"] %></label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="接收部门" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <label>
                            <input name="ImportDepartment" type="text" class="ui-autocomplete-input" /></label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="接收地点" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <label>
                            <input name="ImportPlace" type="text" /></label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderText="财务编号" DataField="Asset_AssetNo" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="AssetNo"></asp:BoundField>
                <asp:BoundField HeaderText="资产名称" DataField="txtClasses" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="Classes"></asp:BoundField>
                <asp:BoundField HeaderText="规格型号" DataField="txtTS" ItemStyle-Width="20%" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="TS"></asp:BoundField>
                <%--<asp:BoundField HeaderText="入账时间" DataField="Asset_RecordedTime" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="RecordedTime"></asp:BoundField>--%>
                <asp:TemplateField HeaderText="入账时间" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <label class="RecordedTime"><%# Convert.ToDateTime(Eval("Asset_RecordedTime")).ToString("yyyy-MM-dd") %></label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <%--<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />--%>
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
                <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page" Font-Bold="true"
                    Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" Font-Bold="true"
                    CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true"
                    Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                    Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                转到第
                <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="$('#hdPagerNum').val($('#gvData_ctl23_txtNewPageIndex').val())"
                    CommandName="Page" Text="GO" />
            </PagerTemplate>
        </asp:GridView>
        <div id="confrimTB" class="confrimTB" >
            <table id="tb" class="tb" cellspacing="1" cellpadding="0">
                <tr>
                    <th style="width:4%">序号</th><th style="width:15%">调出部门</th><th style="width:15%">接收部门</th><th style="width:15%">接收地点</th><th style="width:15%">财务编号</th><th style="width:15%">资产名称</th><th style="width:15%">规格型号</th><th>入账时间</th>
                </tr>
                <tbody id="tbody">
                    <tr><td colspan="8">没有选择任何资产</td></tr>
                </tbody>
                
            </table>
        </div>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
        <div style="width: 90%; margin: 0 auto; text-align: center; padding-top: 15px;">
            <asp:Button ID="btnSure" runat="server" Style="margin-left: 10px; margin-bottom:10px;display:none" Text="确认" OnClick="btnSure_Click" CssClass="commonbtn"  />
            <input type="button" class="commonbtn" id="confirmzcbtn" name="confirm" onclick="confirmzc();return false;" value="确认资产" />
            <input type="button" class="commonbtn" id="savecontentbtn" name="savecontent" onclick="save();return false;" value="保存选择"  />
            <input type="button" class="commonbtn" id="backtbbtn" name="backTB" onclick="back();return false;" value="返回" style="display:none" />
            <input type="button" class="commonbtn" id="btnWinBack" onclick="window.returnValue='';window.close();" value="返回"/>
            <%--<asp:Button ID="btnWinBack" runat="server" Text="返回" OnClick="btnBack_Click" CssClass="commonbtn" />--%>
        </div>
        <br />
        <br />
        <input type="hidden" id="hdPagerNum" runat="server" value="1" />
        <asp:HiddenField ID="hidContent" runat="server" />
    </form>
    <script type="text/javascript" src="/Script/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Script/jquery-ui-1.10.1.custom.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui.datepicker-zh-CN.js"></script>
    <script type="text/javascript" src="../../Script/common.js"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            //autocomplete
            var jJSON = <%=sbJSON.ToString() %>;
            $("input[name='ImportDepartment']").each(function () {
                $(this).autocomplete({
                    source: jJSON,
                    select: function( event, ui ) {
                        //SetOldF();
                    }
                });
            });

            //全选、取消全选
            var selectall = $("#gvData tr").eq(0).find("th").eq(0);
            selectall.css({"cursor":"pointer"});
            selectall.click(function(){
                var text = $(this).html();
                text = text == "选择全部"? "取消全选" : "选择全部";
                $(this).html(text);

                //全选或者取消
                $("#gvData td input[type='checkbox']").each(function(){
                    if(text == "取消全选"){
                        this.checked = true;
                    }
                    else{
                        this.checked = false;                           
                        var AssetNo = $(this).parent().parent().find("td.AssetNo").html();//财务编码
                        del(AssetNo);   //删除$("#hidContent")中的对应json
                    }
                });
            });

            //checkbox取消时删除实体
            $("#gvData td input[type='checkbox']").each(function(){
                $(this).click(function(){
                    if(this.checked == false)
                    {
                        var AssetNo = $(this).parent().parent().find("td.AssetNo").html();//财务编码
                        del(AssetNo);   //删除$("#hidContent")中的对应json
                    }
                });
            });
        })

        //gv初始化
        var l = $("#hidContent").val()=="" ? [] : $("#hidContent").val().evalJSON();//string.evalJSON(); common.js 方法
        if(l.length > 0)
        {
            $("#gvData tr").each(function(){
                var AssetNo = $(this).find("td.AssetNo").html();
                for(var i=0; i< l.length;i++){
                    if(AssetNo == l[i].AssetNo)
                    {
                        $(this).find("input[type='checkbox']")[0].checked = true;
                        $(this).find("input[name='ImportDepartment']").val(l[i].ImportDepartment);
                        $(this).find("input[name='ImportPlace']").val(l[i].ImportPlace);
                    }
                }
            });
        }

        //保存选择的内容保存到hidContent中
        function save()
        {
            $("#gvData td input[type='checkbox']").each(function(){
                var array = new Array();
                if(this.checked)
                {
                    var tr = $(this).parent().parent();
                    var inputImportDepartment = tr.find("input[name='ImportDepartment']");       //接收部门
                    var inputImportPlace = tr.find("input[name='ImportPlace']");                 //接收地点
                    var tdAssetNo = tr.find("td.AssetNo");                                       //财务编码
                    var tdClasses = tr.find("td.Classes");                                      //资产名称
                    var tdTS = tr.find("td.TS");                                                //规格型号
                    var tdRecordedTime = tr.find("label.RecordedTime");                         //入账时间
                    //生成json
                    var data = {"AssetNo":tdAssetNo.html(),"ImportDepartment":inputImportDepartment.val(),"ImportPlace":inputImportPlace.val(),"Classes":tdClasses.html(),"TS":tdTS.html(),"RecordedTime":tdRecordedTime.html()};
                    array.push(data);//插入
                }
                if(array.length > 0)
                {
                    var list = $("#hidContent").val()=="" ? [] : $("#hidContent").val().evalJSON();//string.evalJSON(); common.js 方法
                    var newlist = list;
                    if(list.length > 0)
                    {
                        //已保存选择
                        for(var i=0;i < array.length; i++)
                        {
                            for(var j=0; j < list.length; j++)
                            {
                                if(array[i].AssetNo == list[j].AssetNo)
                                {
                                    //财务编码相同，修改原有实体
                                    newlist[j] = array[i];
                                    break;
                                }
                                if(j == list.length-1)
                                {
                                    //执行到最后一轮都不执行break（实体添加到array）
                                    newlist.push(array[i]);
                                }
                            }
                        }
                        $("#hidContent").val(Obj2str(newlist)); //common.js 方法
                    }
                    else
                    {
                        //没保存任何选择
                        $("#hidContent").val(Obj2str(array)); //common.js 方法
                    }
                }
                
            });
            alert("保存成功");
            return;
        }
        //删除实体
        function del(AssetNo)
        {
            var list = $("#hidContent").val()=="" ? [] : $("#hidContent").val().evalJSON();//string.evalJSON(); common.js 方法
            if(list.length == 0)
            {
                return;
            }
            for(var i=0;i <list.length;i++)
            {
                if(list[i].AssetNo == AssetNo)
                {
                    list.remove(i);   //Array.remove删除(common.js 方法)
                    break;
                }
            }
            $("#hidContent").val(Obj2str(list));    //Obj2str(value) common.js 方法
        }

        //确认
        function confirmzc()
        {
            var content = $.trim($("#hidContent").val());
            if(content == "" || content=="[]")
            {
                alert("请选择资产");
                return;
            }
            $("#confrimTB").show();                     //显示确认tb
            $("#gvData").hide();                        //隐藏gv
            $("#backtbbtn").show();                        //返回按钮
            $("#<%=this.btnSure.ClientID%>").show();    //显示提交按钮
            $("#confirmzcbtn").hide()                   //隐藏确认按钮
            $("#savecontentbtn").hide();                //隐藏保存按钮
            $("#btnWinBack").hide();    

            var zc = content.evalJSON();
            var html = "";
            for(var i = 0; i < zc.length; i++)
            {
                html += "<tr>";
                html += "<td>" + (i+1) + "</td>";  //序号
                html += "<td>" + '<%=Request.QueryString["Asset_Dpm"]%>' + "</td>";    //调出部门
                html += "<td>" + zc[i].ImportDepartment + "</td>";                   //接收部门
                html += "<td>" + zc[i].ImportPlace + "</td>";                        //接收地点
                html += "<td>" + zc[i].AssetNo + "</td>";                            //财务编号
                html += "<td>" + zc[i].Classes + "</td>";                            //资产名称
                html += "<td>" + zc[i].TS + "</td>";                                 //规格型号
                html += "<td>" + zc[i].RecordedTime + "</td>";                       //入账时间
                //zc[i];
                html += "</tr>"
            }
            $("#tbody").html(html);
        }
        //返回选择资产
        function back()
        {
            $("#confrimTB").hide();                     //隐藏确认tb
            $("#gvData").show();                        //显示gv
            $("#backtbbtn").hide();                     //隐藏按钮
            $("#<%=this.btnSure.ClientID%>").hide();    //隐藏提交按钮
            $("#confirmzcbtn").show()                   //显示确认按钮
            $("#savecontentbtn").show();                //显示保存按钮
            $("#btnWinBack").show();
        }
    </script>
</body>
    
</html>
