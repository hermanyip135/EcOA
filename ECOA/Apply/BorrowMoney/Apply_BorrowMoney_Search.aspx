<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"  CodeFile="Apply_BorrowMoney_Search.aspx.cs" Inherits="Apply_BorrowMoney_Apply_BorrowMoney_Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .hrLine {
        vertical-align:middle; display:inline-block;
        }
    </style>
    <script type="text/javascript">
        var jJSON = <%=sbJSON.ToString() %>;
        $(function() {
            $("#<%=txtBeginDate.ClientID %>").datepicker();
            $("#<%=txtEndDate.ClientID %>").datepicker();
            $("#<%=txtBeginDate1.ClientID %>").datepicker();
            $("#<%=txtEndDate1.ClientID %>").datepicker();
            $("#<%=txtApplicationDepartment.ClientID %>").autocomplete({
                source: jJSON,
                select: function (event, ui) {
                    $("#<%=hdApplicationDepartmentID.ClientID %>").val(ui.item.id);
                }
            });
            $("#<%=txtApplicationDepartment1.ClientID %>").autocomplete({
                source: jJSON,
                select: function (event, ui) {
                    $("#<%=hdApplicationDepartmentID.ClientID %>").val(ui.item.id);
                }
              });
        })
    </script>
          
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <h1 style="text-align:center">临时借用资金查询</h1>
    <div style="width:100%; text-align:left; margin-left:15px; margin-right:15px;font-weight:bold; font-size:15px">
        <hr class="hrLine" style="width:50px;" />查询余额汇总 <hr  class="hrLine" style="width:80%"/>
    </div>
     <table style="width:100%">
        <tr class="noborder">
            <td ><label class="">申请部门:</label><input class="txt_of_search" id="txtApplicationDepartment" type="text" runat="server" /><input type="hidden" id="hdApplicationDepartmentID" runat="server" /></td>
            <td><label class="">申请人:</label><input class="txt_of_search" id="txtApplicant" type="text" runat="server" /></td>
           
             <td ><label class="" >流水号:</label><input class="txt_of_search" id="txtApplyID" type="text" runat="server" /> </td>
            
        </tr>
         <tr  class="noborder">
            <td ><label class="">借额日期:</label><input class="txt_of_search" id="txtBeginDate" type="text" runat="server" style="width:100px;"  />至<input class="txt_of_search" id="txtEndDate" type="text" runat="server" style="width:100px;padding-left:2px;" /></td>
             <td> <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" style="margin-left:10px;margin-bottom: 10px;" Text="查询" />  
                  <asp:Button ID="btExcel" runat="server" Text="导出数据" OnClick="btExcel_Click"  style="margin-left:10px;margin-bottom: 10px;" />
             </td>
         </tr>
    </table>

       <div>
       <label runat="server" id="gvDatarows"  style="color:red; font-weight:bold; font-size:16px;"></label> <label runat="server" id="gvDataSumMoney"  style="color:red; font-weight:bold; font-size:16px;"></label>
    </div>
    <asp:GridView ID="gvData" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="false"  GridLines="None" Width="100%" AllowPaging="true" PageSize="15"  BorderWidth="0px" BorderStyle="None"
        OnPageIndexChanging="gvData_PageIndexChanging">
        <Columns>

            <%--<asp:BoundField DataField="MainID" HeaderText="ID" Visible="False" />--%>
            <%--<asp:TemplateField HeaderText="选择" ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >--%>
           <%-- <asp:TemplateField ItemStyle-Width="1%">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkSelected"  runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>--%>
           
            <asp:BoundField HeaderText="流水号" DataField="ApplyID" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="分行名称" DataField="Department" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="借支余额" DataField="BalanceMoney" ItemStyle-Width="9%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="借额日期" DataField="ImportDate" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="9%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
           
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
                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' OnClientClick="ceshi(0)">上一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true" OnClientClick="ceshi(0)"
                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
            转到第
            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="$('#ctl00_ContentPlaceHolder1_hdPagerNum').val($('#ctl00_ContentPlaceHolder1_gvData_ctl05_txtNewPageIndex').val())"
                CommandName="Page" Text="GO" />
        </PagerTemplate>
    </asp:GridView>
  
    <div style="width:100%; text-align:left; margin-left:15px; margin-right:15px; font-weight:bold; font-size:15px">
        <hr class="hrLine" style="width:50px;" />查询申请事项明细 <hr  class="hrLine" style="width:80%"/>
    </div>
     <table style="width:100%">
        <tr class="noborder">
            <td ><label class="">申请部门:</label><input class="txt_of_search" id="txtApplicationDepartment1" type="text" runat="server" /></td>
            <td><label class="">申请人:</label><input class="txt_of_search" id="txtApplicant1" type="text" runat="server" /></td>
           
             <td ><label class="" >流水号:</label><input class="txt_of_search" id="txtApplyID1" type="text" runat="server" /> </td>
            
        </tr>
         <tr class="noborder">
             <td>  日期类型:<asp:DropDownList ID="ddlDateType" runat="server" Width="153px">
                <asp:ListItem Value="借">借</asp:ListItem>
                <asp:ListItem Value="冲">冲</asp:ListItem>
                <asp:ListItem Value="申请">申请</asp:ListItem>
                </asp:DropDownList>
              </td>
              <td><label class="">查询日期:</label><input class="txt_of_search" id="txtBeginDate1" type="text" runat="server" style="width:100px;" />至<input class="txt_of_search" id="txtEndDate1" type="text" runat="server" style="width:100px;padding-left:2px;" /></td>
         <td>
              <asp:Button ID="btnSearch1" runat="server" OnClick="btnSearch1_Click"  style="margin-left:10px;margin-bottom: 10px;" Text="查询" />
                <asp:Button ID="btExcel1" runat="server" Text="导出数据" OnClick="btExcel1_Click"  style="margin-left:10px;margin-bottom: 10px;" />
         </td>
         </tr>
    </table>
    <div>
       <label runat="server" id="gvData1rows"  style="color:red; font-weight:bold; font-size:16px;"></label>
    </div>
  <%--  <div style="overflow-y: scroll; height: 200px">--%>
    <asp:GridView ID="gvData1" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="false"  GridLines="None" Width="100%" AllowPaging="true"   PageSize="15"  BorderWidth="0px" BorderStyle="None"
        
         OnPageIndexChanging="gvData1_PageIndexChanging">
        <Columns>
           
            <asp:BoundField HeaderText="流水号" DataField="ApplyID" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="分行名称" DataField="Department" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="租金" DataField="Rent" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="租金税费" DataField="RentTax" DataFormatString="{0:F}" ItemStyle-Width="9%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
           <asp:BoundField HeaderText="管理费" DataField="ManaExpense" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
              <asp:BoundField HeaderText="电费" DataField="ElectricityFees" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="水费" DataField="water" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="其他" DataField="Other" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
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
                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' OnClientClick="ceshi(0)">上一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true" OnClientClick="ceshi(0)"
                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
            转到第
            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="$('#ctl00_ContentPlaceHolder1_hdPagerNum').val($('#ctl00_ContentPlaceHolder1_gvData_ctl05_txtNewPageIndex').val())"
                CommandName="Page" Text="GO" />
        </PagerTemplate>
    </asp:GridView>
     <input type="hidden" id="hdPagerNum1" runat="server" value="1" />
       <div style="width:100%; text-align:left; margin-left:15px; margin-right:15px; font-weight:bold; font-size:15px">
        <hr class="hrLine" style="width:50px;" />已收单未付款明细 <hr  class="hrLine" style="width:80%"/>
    </div>
      <table style="width:100%">
      
         <tr class="noborder">
            <td>
              <asp:Button ID="btnSearch2" runat="server" OnClick="btnSearch2_Click"  style="margin-left:10px;margin-bottom: 10px;" Text="查询" />
                <asp:Button ID="btExcel2" runat="server" Text="导出数据" OnClick="btExcel2_Click"  style="margin-left:10px;margin-bottom: 10px;" />
         </td>
         </tr>
    </table>
    <div>
       <label runat="server" id="gvData2rows"  style="color:red; font-weight:bold; font-size:16px;"></label>
    </div>
  <%--  <div style="overflow-y: scroll; height: 200px">--%>
    <asp:GridView ID="gvData2" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="false"  GridLines="None" Width="100%" AllowPaging="true"   PageSize="15"  BorderWidth="0px" BorderStyle="None"
        OnPageIndexChanging="gvData2_PageIndexChanging">
        <Columns>
           
            <asp:BoundField HeaderText="流水号" DataField="ApplyID" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="分行名称" DataField="Department" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="摘要(汇总)" DataField="abstract" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="借支金额合计" DataField="PriceSum" DataFormatString="{0:F}" ItemStyle-Width="9%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
           <asp:BoundField HeaderText="审核状态" DataField="BorrowMoneyState" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
              <asp:BoundField HeaderText="收单时间" DataField="AuditorDate" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="部门负责人" DataField="Person" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
             <asp:BoundField HeaderText="申请人" DataField="ApplyPoper" ItemStyle-Width="9%" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
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
                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' OnClientClick="ceshi(0)">上一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true" OnClientClick="ceshi(0)"
                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
            转到第
            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="$('#ctl00_ContentPlaceHolder1_hdPagerNum').val($('#ctl00_ContentPlaceHolder1_gvData_ctl05_txtNewPageIndex').val())"
                CommandName="Page" Text="GO" />
        </PagerTemplate>
    </asp:GridView>
       <%-- </div>--%>
</asp:Content>