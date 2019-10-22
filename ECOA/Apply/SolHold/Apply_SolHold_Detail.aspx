<%@ Page ValidateRequest="false" Title="物业部批量解hold申请 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_SolHold_Detail.aspx.cs" Inherits="Apply_SolHold_Apply_SolHold_Detail" %>

<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        //通用方法
        //打印
        function myPrint(start, end, extend) {
            //window.print();
            cMyPrint();
        }
        //上传
        function upload() {
            cUpload("<%=MainID %>", "<%=ApplyN %>"); //common_new.js
        }

        //选中下载的附件
        function checkChecked() {
            cCheckChecked("<%=gvAttach.ClientID%>"); //common_new.js
        }
        //返回
        function BackToSearch() {
            cBackToSearch("<%=Request.QueryString %>");  //common_new.js
        }

        //编辑流程
        function editflow() {
            cEditflow("<%=MainID %>");   //common_new.js
        }
        //取消签名
        function CancelSign(idc) {
            cCancelSign(idc, "<%=this.hdCancelSign.ClientID%>","<%=this.btnCancelSign.ClientID%>");   //common_new.js
        }
        //签名事件
        function sign(e) {
            cSign(e, "<%=hdIsAgree.ClientID %>", "<%=hdSuggestion.ClientID %>", "<%=this.btnSign.ClientID %>");   //common_new.js
        }

        //签名内容绑定
        //function FlowSignInit()
        //{
        //    cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>");   //common_new.js
        //}
        function FlowSignInit() {
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.Apply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
        }

        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>","<%=ApplyN %>");
        }
    </script>

    <script type="text/javascript">
        var isNewApply=('<%=IsNewApply%>'=='True');

        function check() {
            //在必填项后增加input class="REQUIRED" 项用以控制是否必填
            flag = REQUIRED_Check();    //common_new.js
            if (!flag) {
                return false;
            }
            return true;
        }

        function PageInit()
        {
            //签名方法事件初始化 common_new.js
            SignFunBind();

            //签名数据绑定
            FlowSignInit();

            //申请部门
            var jJSON = <%=SbJson.ToString() %>;
            $("#<%=Department.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });
        }

    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0}
        .auto-style4{width:100px}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>

        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>物业部批量解hold申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td class="auto-style4">申请分行/部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="Department" runat="server" requiredmes="请选择申请分行/部门"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
                    <td class="auto-style4">经办人</td>
                    <td class="tl PL10"><asp:TextBox ID="ApplyID" runat="server" requiredmes="请填写经办人"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">申请人</td>
                    <td class="tl PL10">
                        <asp:Label ID="Apply" runat="server"></asp:Label>
                        <asp:Label ID="ApplyDate" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">联络方式</td>
                    <td class="tl PL10"><asp:TextBox ID="Phone" runat="server" requiredmes="请填写联络方式" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">项目名称</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="Address" runat="server" requiredmes="请填写项目名称" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">解HOLD佣金金额</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="Money" runat="server" requiredmes="请填写解HOLD佣金金额" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">HOLD佣原因</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="Reason" runat="server" Width="98%" Height="100px" TextMode="MultiLine" requiredmes="请填写HOLD原因"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">解HOLD理由</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="Summary" runat="server" Width="98%" Height="100px" TextMode="MultiLine" requiredmes="请填写解HOLD理由"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;text-indent:15px" colspan="4">
                        <p>请根据<a href="temp/（项目）申请解HOLD明细模板.xlsx" target="_blank" style="color:blue">《（项目）申请解HOLD明细模板》</a>填写并上传为附件。</p>
                    </td>
                </tr>
            </table>
            <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0">
                <tr class="noborder" style="height: 85px;" idx="1">
                    <td class="auto-style2">申请人</td>
                    <td colspan="3" class="tl PL10" style="">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
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
                <tr class="noborder" style="height: 85px;" idx="2">
                    <td class="auto-style2">部门主管</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
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
                    <td class="auto-style2">负责人（总监）</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
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

                <tr class="noborder" style="height: 85px;" idx="5">
                    <td class="auto-style2">法律部</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" /><label class="l signother">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                        
                        <%--申请完成以后继续填写跟进的栏目--%>
                        <asp:Panel ID="FinText" runat="server">
                            <p>处理结果：</p>
                            <asp:TextBox ID="txtRemark" runat="server" ReadOnly="true" TextMode="MultiLine" Width="97%"></asp:TextBox><br />
                            <asp:Button ID="btnFin" runat="server" CssClass="signbtn" style="display:block" OnClick="btnFin_Click" Visible="false" />
                            <div class="fielddate">日期：<span id="txtRemarkDate" runat="server" style="margin:0;margin-right:20px">_________</span></div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
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
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" OnClientClick="BackToSearch();return false;" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />
                <input type="hidden" id="hdDetail" runat="server" />
                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
            </div>
        </div>
    </div>

    <%=SbJs.ToString() %>
    <script type="text/javascript">
        PageInit();
    </script>
</asp:Content>

