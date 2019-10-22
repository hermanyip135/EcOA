<%@ Page Title="代理人设置 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Agent_Setting.aspx.cs" Inherits="SysSetting_Agent_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function() {
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
            $("#<%=txtStart.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });

            $("#<%=txtEnd.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
        })

        function getEmployee(n) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployeeByCodes&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtAgentID.ClientID %>").val(infos[0]);
                        $("#<%=txtAgent.ClientID %>").val(infos[1]);
                    }
                    else {
                        $("#<%=txtAgent.ClientID %>").val("");
                    }
                }
            })
        }

        function check() {
            if ($.trim($("#<%=txtAgent.ClientID %>").val()) == "") {
                alert("请填写正确的代理人工号!");
                $("#<%=txtAgentID.ClientID %>").focus();
                return false;
            }

            if ($.trim($("#<%=txtStart.ClientID %>").val()) == "") {
                alert("请选择代理开始日期！");
                $("#<%=txtStart.ClientID %>").focus();
                return false;
            }

            if ($.trim($("#<%=txtEnd.ClientID %>").val()) == "") {
                alert("请选择代理结束日期！");
                $("#<%=txtEnd.ClientID %>").focus();
                return false;
            }

            if (!checkdate($("#<%=txtStart.ClientID %>").val())) {
                alert("代理开始日期格式错误，请按以下格式输入日期:\n2013-08-08");
                $("#<%=txtStart.ClientID %>").focus();
                return false;
            }

            if (!checkdate($("#<%=txtEnd.ClientID %>").val())) {
                alert("代理结束日期格式错误，请按以下格式输入日期:\n2013-08-08");
                $("#<%=txtEnd.ClientID %>").focus();
                return false;
            }

            return true;
        }

        function checkdate(val) {
            var datetype = /^[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}$/;
            return datetype.exec(val);
        }
    </script>
    
    <style type="text/css">
        .hide
        {
            display:none;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>设置代理人</h1>
    <table id="tbAround" style="width:100%;">
        <tr>
            <td><label class="">代理人工号:</label><input id="txtAgentID" type="text" runat="server" onkeyup="this.value=this.value.replace(/[^\d|//,|//，]/g,'');this.value=this.value.replace(/[，]/g,',');" onblur="getEmployee(this);" /></td>
            <td><label class="ML20">代理人姓名:</label><input id="txtAgent" type="text" runat="server" readonly="readonly" style=" background-color:Silver;"/></td>
            <td colspan="2"><label class="ML20">代理日期:</label><input id="txtStart" type="text" runat="server" style="width:100px;"  />至<input id="txtEnd" type="text" runat="server" style="width:100px;padding-left:2px;" /></td>
        </tr>
        <tr>
            <td><label class="">是否启用:</label><asp:RadioButton ID="rdbYES" runat="server" Checked="true" GroupName="able" /><label for="<% =rdbYES.ClientID%>">开启</label><asp:RadioButton ID="rdbNO" runat="server" GroupName="able" /><label for="<% =rdbNO.ClientID%>">关闭</label></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnNew" runat="server" Text="新建" OnClick="btnNew_Click" OnClientClick="return check();" /><asp:Button ID="btnSave" runat="server" Text="保存修改" Visible="false" OnClick="btnSave_Click" OnClientClick="return check();"/><input type="hidden" id="hdID" runat="server" /></td>
        </tr>
    </table>
    <asp:GridView ID="gvData" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="false" OnRowDataBound="gvData_RowDataBound" OnRowCommand="gvData_RowCommand"
        OnPageIndexChanging="gvData_PageIndexChanging" GridLines="None" Width="100%" AllowPaging="true" PageSize="20">
        <Columns>
            <asp:BoundField HeaderText="主键" DataField="OfficeAutomation_Agent_ID" ItemStyle-Width="1px"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" ControlStyle-CssClass="hide" FooterStyle-CssClass="hide" />
            <asp:BoundField HeaderText="代理人姓名" DataField="OfficeAutomation_Agent_Agent" ItemStyle-Width="100px"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="代理人工号" DataField="OfficeAutomation_Agent_AgentID" ItemStyle-Width="100px"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="代理开始日期" DataField="OfficeAutomation_Agent_Start" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="100px"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="代理结束日期" DataField="OfficeAutomation_Agent_End" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="70px"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="是否启用" DataField="OfficeAutomation_Agent_IsEnable" ItemStyle-Width="100px"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="创建时间" DataField="OfficeAutomaiton_Agent_CreateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ItemStyle-Width="70px"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:TemplateField HeaderText="操作" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:ImageButton ID="iBtnEdit" runat="server"  ImageUrl="../Images/edit.gif" CommandName="EditAgent" CommandArgument='<%#Eval("OfficeAutomation_Agent_ID") %>'/>
                    <%--<asp:ImageButton ID="iBtnDelete" runat="server"  ImageUrl="../Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Agent_ID") %>' OnClientClick="return confirm('确认删除？');" />--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#EFF3FB" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <%--<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />--%>
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
        <PagerStyle HorizontalAlign="Center"/>
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
            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="$('#ctl00_ContentPlaceHolder1_hdPagerNum').val($('#ctl00_ContentPlaceHolder1_gvData_ctl13_txtNewPageIndex').val())"
                CommandName="Page" Text="GO" />
        </PagerTemplate>
    </asp:GridView>
    <input type="hidden" id="hdPagerNum" runat="server" value="1" />
</asp:Content>

