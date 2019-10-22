<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Apply_SYSPWDTransfer_Detail.aspx.cs" Inherits="Apply_SYSPWDTransfer_Apply_SYSPWDTransfer_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
      <script  type="text/javascript" src="../../Script/jquery.PrintArea.min.js"></script>
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        $(function() {      
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });
            FlowSignInit();
		
        })
        function check() {
           
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {alert("部门不可为空！");$("#<%=txtDepartment.ClientID %>").focus();return false;}
        };
        //编辑流程
        function editflow() {
            cEditflow("<%=MainID %>");   //common_new.js
            }
            //取消签名
            function CancelSign(idc) {
                cCancelSign(idc, "<%=this.hdCancelSign.ClientID%>", "<%=this.btnCancelSign.ClientID%>");   //common_new.js
            }
            //签名事件
            function sign(e) {
                cSign(e, "<%=hdIsAgree.ClientID %>", "<%=hdSuggestion.ClientID %>", "<%=this.btnSign.ClientID %>");   //common_new.js
        }

        //签名内容绑定
        function FlowSignInit() {
            
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.lblApply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
        }
    
        function getSuggestion(idx)
        {
            $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
        }
        function checkChecked() {
            var gv = document.getElementById('<%=gvAttach.ClientID%>'); 
             var input = gv.getElementsByTagName("input"); 
             var flagCheck = false;

             for (var i = 0; i < input.length; i++) {
                 if (input[i].type == 'checkbox' && !input[i].disabled && input[i].checked){
                     flagCheck = true;
                     break;
                 }
             }
			
             if(!flagCheck)
                 alert("请勾选文件再下载！");
				
             return flagCheck;
         }

         function upload() {
             var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_SYSPWDTransfer_Detail.aspx?MainID=<%=MainID %>';
         }
        //通用方法
        //打印
        function myPrint(start, end, extend) {
            //window.print();
            cMyPrint();
        }
        </script>
  <style type="text/css">
    
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width:640px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center' id="body1">
            <h1>广东中原地产代理有限公司</h1>
            <h1>系统及密码交接表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 700px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>

            <table id ="tbAround" width="700" >
                <tr>
                    <td colspan="4" style="font-weight: bold;text-align:left;width:100%;font-size:15px" class="auto-style4">
                        <span style="color: red">*</span> 分行：<asp:TextBox ID="txtDepartment" runat="server" Width="120"  style="font-weight:500;"></asp:TextBox> &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        移交人：<asp:Label ID="lblApply" runat="server"   style="font-weight:500;padding-right:100px;"></asp:Label>
                        申请日期：<asp:Label ID="lbApplyDate" runat="server"  style="font-weight:500;padding-right:30px;"></asp:Label>
                    </td>
                </tr>
             <tr>
                 <td colspan="4">
                     <table style="width: 99%">
                         <tr>
                             <td rowspan="16" style="font-weight:bold; font-size:20px;">相<br/>关<br/>密<br/>码<br/>部<br/>分</td>
                             <td colspan="4"><h1>交接内容</h1></td>
                         </tr>
                         <tr>
                             <td>开机用户名</td>
                             <td><asp:TextBox runat="server" ID="BootUser"></asp:TextBox></td>
                             <td>开机密码</td>
                             <td><asp:TextBox runat="server" ID="BootPwd"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>登录用户名</td>
                             <td><asp:TextBox runat="server" ID="LoginUser"></asp:TextBox></td>
                             <td>登录密码</td>
                             <td><asp:TextBox runat="server" ID="LoginPwd"></asp:TextBox></td>
                         </tr>
                          <tr>
                             <td>代收款系统用户名</td>
                             <td><asp:TextBox runat="server" ID="ReceivablesSysUser"></asp:TextBox></td>
                             <td>代收款系统密码</td>
                             <td><asp:TextBox runat="server" ID="ReceivablesSysPwd"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>发票系统用户名</td>
                             <td><asp:TextBox runat="server" ID="InvoiceSysUser"></asp:TextBox></td>
                             <td>发票系统密码</td>
                             <td><asp:TextBox runat="server" ID="InvoiceSysPwd"></asp:TextBox></td>
                         </tr>
                          <tr>
                             <td>内部网系统用户名</td>
                             <td><asp:TextBox runat="server" ID="IntranetSysUser"></asp:TextBox></td>
                             <td>内部网系统密码</td>
                             <td><asp:TextBox runat="server" ID="IntranetSysPwd"></asp:TextBox></td>
                         </tr>
                          <tr>
                             <td>考勤系统用户名</td>
                             <td><asp:TextBox runat="server" ID="TimeSysUser"></asp:TextBox></td>
                             <td>考勤系统密码</td>
                             <td><asp:TextBox runat="server" ID="TimeSysPwd"></asp:TextBox></td>
                         </tr>
                           <tr>
                             <td>中原门户系统用户名</td>
                             <td><asp:TextBox runat="server" ID="GatewaySysUser"></asp:TextBox></td>
                             <td>中原门户系统密码</td>
                             <td><asp:TextBox runat="server" ID="GatewaySysPwd"></asp:TextBox></td>
                         </tr>
                          <tr>
                             <td>I－words传真系统用户名</td>
                             <td><asp:TextBox runat="server" ID="IWordsSysUser"></asp:TextBox></td>
                             <td>I－words传真系统密码</td>
                             <td><asp:TextBox runat="server" ID="IWordsSysPwd"></asp:TextBox></td>
                         </tr>
                          <tr>
                             <td>三级市场锁匙管理帐户</td>
                             <td><asp:TextBox runat="server" ID="MarketKeyUser"></asp:TextBox></td>
                             <td>三级市场锁匙管理密码</td>
                             <td><asp:TextBox runat="server" ID="MarketKeyPwd"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>POS机系统用户名</td>
                             <td><asp:TextBox runat="server" ID="PostMachineUser"></asp:TextBox></td>
                             <td>POS机系统密码</td>
                             <td><asp:TextBox runat="server" ID="PostMachinePwd"></asp:TextBox></td>
                         </tr>
                          <tr>
                             <td>租赁报送系统用户名</td>
                             <td><asp:TextBox runat="server" ID="LeaseDeliverySysUser"></asp:TextBox></td>
                             <td>租赁报送系统密码</td>
                             <td><asp:TextBox runat="server" ID="LeaseDeliverySysPwd"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>短信平台用户名</td>
                             <td><asp:TextBox runat="server" ID="MessageUser"></asp:TextBox></td>
                             <td>短信平台密码</td>
                             <td><asp:TextBox runat="server" ID="MessagePwd"></asp:TextBox></td>
                         </tr>
                           <tr>
                             <td>保险箱密码</td>
                             <td><asp:TextBox runat="server" ID="SafeDepositBoxPwd"></asp:TextBox></td>
                             <td>分行WIFI密码</td>
                             <td><asp:TextBox runat="server" ID="WIFIPwd"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>代收款备用金存折开户名</td>
                             <td><asp:TextBox runat="server" ID="ReceivablesSpareGoldUser"></asp:TextBox></td>
                             <td>代收款备用金存折密码</td>
                             <td><asp:TextBox runat="server" ID="ReceivablesSpareGoldPwd"></asp:TextBox></td>
                         </tr>
                           <tr>
                             <td>往来款备用金存折开户名</td>
                             <td><asp:TextBox runat="server" ID="IntercourseSpareGoldUser"></asp:TextBox></td>
                             <td>往来款备用金存折密码</td>
                             <td><asp:TextBox runat="server" ID="IntercourseSpareGoldPwd"></asp:TextBox></td>
                         </tr>
                     </table>
                 </td>
             </tr>
            
                </table>
                   <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0" style="width:700px">
                  <tr class="noborder" style="height: 85px;" idx="1">
                    <td style="width:130px">移交人</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree1"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree1"/><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree1"/><label class="l signyes">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                 <tr class="noborder" style="height: 85px;" idx="2">
                    <td class="auto-style2">接收人：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree2"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree2"/><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree2"/><label class="l signyes">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                 <tr class="noborder" style="height: 85px;" idx="3">
                    <td class="auto-style2">秘书主管：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree3"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree3" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree3" /><label class="l signyes">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                        
               <%-- <tr style="display:none;">
                    <td colspan="4" style="text-align: left" class="auto-style5">
                        <span style="margin-left: 20px; text-align: left;font-size:12px">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 340px;font-size:12px">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>--%>

               
                
            </table>
               <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
            <br />
             <%--   </td></tr>
                </table>--%>
            <!--打印正文结束-->
                <script>
                    $("#tbAround2 input").css({ "border": "1px solid #98b8b5" });
                </script>
        </div>
    <div class="noprint">
        <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" BackColor="White" Style="clear: both; margin-top: 3px;"
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
                <asp:TemplateField HeaderText="删除" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID") %>' OnClientClick="return confirm('确认删除？');" />
                        <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
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
           
            <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
         
            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
       <%-- <input type="button" id="btnPrint" value="打印" onclick="myPrint();" style="display: none;" />--%>
             <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
            <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
          
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
            <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
            <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
            <asp:HiddenField ID="hdIsAgree" runat="server" />
            <asp:HiddenField ID="hdSuggestion" runat="server" />
            <input type="hidden" id="hdDetail" runat="server" />
            <input type="hidden" id="hdDepartmentID" runat="server" />
            <input type="hidden" id="hdDepartmentID2" runat="server" />
            <asp:HiddenField ID="hdCancelSign" runat="server" />
            <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
        </div>
        </div>
    </div>
        <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

