<%@ Page Title="软件系统测试需求申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  ValidateRequest="false" CodeFile="Apply_ITTest.aspx.cs" Inherits="Apply_ITTest_Apply_ITTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var jJSON = <%=sbJSON.ToString() %>;
        $(function() {
        $("#<%=txtDispatchDepartment.ClientID %>").autocomplete({
            source: jJSON,
            select: function (event, ui) {
                $("#<%=hdDispatchDepartmentID.ClientID %>").val(ui.item.id);
                }
        });
        $("#<%=txtApplyDate.ClientID %>").datepicker({
            showButtonPanel: true,
            showOtherMonths: true,
            selectOtherMonths: true,
            changeMonth: true,
            changeYear: true
        });

        $("#<%=txtHopeDate.ClientID %>").datepicker({
            showButtonPanel: true,
            showOtherMonths: true,
            selectOtherMonths: true,
            changeMonth: true,
            changeYear: true
        });
        });

        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
                  if(sReturnValue=='success')
                      window.location='Apply_ITTest.aspx?MainID=<%=MainID %>';
        }

        function check() {
        
        
        }
        
    </script>

     <script type="text/javascript" charset="utf-8" src="/editor/kindeditor.js"></script>
<script type="text/javascript" charset="utf-8" src="/editor/lang/zh_CN.js"></script>
<script  type="text/javascript">
    KindEditor.ready(function(K) {
        editor = K.create('#<%=txtContent.ClientID %>', {
            items : [
            'fullscreen', '|',
            'formatblock', 'fontname','fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
            'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', 'table','|', 'undo', 'redo', '|', 'cut', 'copy', 'paste',
            'plainpaste', 'wordpaste', '|', 'source'
            ]
 
        });

    
        KindEditor.options.filterMode = false;

    });

    KindEditor.ready(function(K) {
        editor = K.create('#<%=txtReply.ClientID %>', {
                items : [
                'fullscreen', '|',
                'formatblock', 'fontname','fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', 'table','|', 'undo', 'redo', '|', 'cut', 'copy', 'paste',
                'plainpaste', 'wordpaste', '|', 'source'
                ]
 
            });

    
            KindEditor.options.filterMode = false;

        });
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style='text-align:center; width:640px; margin:0px auto;'>

            <!--打印正文开始-->
        <div style='text-align:center'>            
            <h1>广东中原地产代理有限公司</h1>
            <h1>软件系统测试需求申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td style="width:25%;">收文部门</td>
                    <td >资讯科技部</td>
                       <td style="width:25%;">收文人员</td>
                    <td ><asp:TextBox ID="txtReceive"  runat="server" Width="150px" Text="彭嘉敏A"  Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>发文部门</td>
                    <td style="width:25%;" class="tl PL5 PR5"><asp:TextBox ID="txtDispatchDepartment" runat="server" Width="184px"></asp:TextBox><asp:HiddenField ID="hdDispatchDepartmentID" runat="server" /></td>
                    <td style="width:30%;*width:12%;">申请时间</td>
                    <td style="width:25%;*width:18%;" class="tl PL5 PR5"><asp:TextBox ID="txtApplyDate" runat="server" Width="150px"></asp:TextBox></td>
                </tr>	
                <tr>
                    <td>系统名称</td>
                    <td class="tl PL5">
                        <asp:DropDownList ID="ddlSystemName" runat="server" Width="190px"></asp:DropDownList>
                    </td>
                    <td>期望完成日期</td>
                    <td class="tl PL5 PR5"><asp:TextBox ID="txtHopeDate" runat="server" Width="150px"></asp:TextBox></td>
                </tr>	
              <tr>
                    <td>申请人</td>
                    <td><asp:TextBox ID="txtApplicant" runat="server" Width="96%"></asp:TextBox></td>
                  
                </tr>	
                <tr style="height:200px; ">
                    <td colspan="4">
                        <div style="float:left; margin-left:11px;">需求内容：</div>

                          <div style="text-align: left; width: 98%">
                              <br />
                               <%--<a id="ibta" href="javascript:void(0)" onclick="toggleArea1();" style="margin-bottom: 5px; margin-left: 5px;">切换高级模式</a><br />--%>
                               <%-- <asp:TextBox ID="txtDescribe" runat="server" Style="height: 0px;width: 640px;" TextMode="MultiLine" Visible="False"></asp:TextBox>--%>
                                <asp:Panel ID="pnDescribe" runat="server" Style="width: 635px;" ScrollBars="Horizontal" Visible="False" CssClass="pdl2">
                                    <asp:Label ID="lbDescribe" runat="server" CssClass="pdl2"></asp:Label>
                                </asp:Panel>
                            </div>
                        <asp:TextBox ID="txtContent" runat="server" Width="98%" Height="98%" Rows="15" TextMode="MultiLine" style="overflow:auto;"></asp:TextBox>

                    </td>
                </tr>

                
                <tr>
                    <td>文档编码(自动生成)</td>
                    <td colspan="3"><%=SerialNumber %></td>
                </tr>	
                <tr style="height:30px; ">
                    <td>测试反馈</td>
                    <td colspan="3" class="tl PL10">
                          <asp:Panel ID="pRepl" runat="server" Style="width: 98%" ScrollBars="Horizontal" Visible="False" CssClass="pdl2">
                                    <asp:Label ID="lRepl" runat="server" CssClass="pdl2"></asp:Label>
                                </asp:Panel>
                          <asp:TextBox ID="txtReply" runat="server" Width="98%" Height="200px" Rows="15" TextMode="MultiLine" style="overflow:auto;"></asp:TextBox>
                       
                      <div style="margin-top:5px;height:20px" > <asp:Button runat="server" ID="btnSavaReply" Text="保存意见"  OnClick="btnSavaReply_Click"  Visible="false" />
                            &nbsp  &nbsp   
                          <asp:Button runat="server" ID="btnEnd" Text="测试完毕"  OnClick="btnEnd_Click"  Visible="false" />
                      </div>  
                    </td>       
                 </tr>	
              
            </table>
            <!--打印正文结束-->
        </div>

        <div class="noprint">
        <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" BackColor="White" style="clear:both; margin-top:3px;"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="false"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="gvAttach_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />                            
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:ImageButton ID="iBtnDelete" runat="server"  ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID") %>' OnClientClick="return confirm('确认删除？');" />
                        <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <a id="link" href='<%=ConfigurationManager.AppSettings["EcoaFileURL"]%><%#Eval("OfficeAutomation_Attach_Path")%>' target="_blank"><%#Eval("OfficeAutomation_Attach_Name")%></a>
                        <asp:HiddenField ID="hfPath" runat="server" Value='<%#Eval("OfficeAutomation_Attach_Path") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <%--<HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />--%>
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <div id="PageBottom">
        <hr />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
        <%--<asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />--%>
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left:5px; display:none;" />
        <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" onclick="btnDownload_Click" OnClientClick="return checkChecked();" style="margin-left:5px;" Visible="false" />
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display:none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <%--<input type="button" id="btnGoBack" value="返回" onclick="window.history.go(-1);" />--%>
        <%--<input type="button" id="btnGoBack" value="返回" onclick="window.location='/Apply/Apply_Search.aspx';" />--%>
        <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click"/>
  
        <asp:HiddenField ID="hdIsAgree" runat="server" />
        <asp:HiddenField ID="hdSuggestion" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
   
            </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=sbJS.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtContent])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        //$.each($("textarea:not([id*=txtReply])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应

        
    </script>
</asp:Content>
