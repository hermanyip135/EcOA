<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_HoldCoisn_Detail.aspx.cs" Inherits="Apply_HoldCoisn_20160712_Apply_HoldCoisn_Detail" %>

<%@ Register Src="../../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
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
            cCancelSign(idc, "<%=this.hdCancelSign.ClientID%>", "<%=this.btnCancelSign.ClientID%>");   //common_new.js
        }
        //签名事件
        function sign(e) {
            cSign(e, "<%=hdIsAgree.ClientID %>", "<%=hdSuggestion.ClientID %>", "<%=this.btnSign.ClientID %>");   //common_new.js
        }

        //签名内容绑定
        function FlowSignInit() {
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.Apply.ClientID%>").html(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
        }

        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>", "<%=ApplyN %>");
        }
    </script>
    <script type="text/javascript">
        function PageInit()
        {
            //初始化
            CommonPageInit();

            //签名数据绑定
            FlowSignInit();

            //部门绑定
            var jJSON = <%=SbJson.ToString() %>;
            $("#<%=this.Department.ClientID %>").autocomplete({ source: jJSON });

            //原因绑定
            var ReasonType = $("#<%=this.ReasonType.ClientID%>").val();
            if(typeof(ReasonType) != "undefined" && ReasonType != "")
            {
                
                var t = ReasonType.split('|');
                for(var i=0;i< t.length;i++)
                {
                    var $c = $("input[name='ReasonType'][value='" + t[i] + "']");
                    if(typeof($c)!= "undefined")
                    {
                        $c.get(0).checked = true;
                    }
                }
            }
            fcchange($("#c1").get(0));
            tcchange($("#c3").get(0));

            if($("#c1").prop("checked"))
            {
                var Condition = $("#<%=this.Condition.ClientID%>").val();
                if(typeof(Condition) != "undefined" && Condition != "")
                {
                    $("input[name='Condition'][value=" + Condition + "]").get(0).checked = true;
                }
            }
        }

        function check()
        {
            var flag = true;
            flag = REQUIRED_Check();
            if(!flag)
            {
                return false;
            }
            

            if(!$("#c1").get(0).checked && !$("#c2").get(0).checked && !$("#c3").get(0).checked)
            {
                alert("请选择原因");
                $("#c1").focus();
                return false;
            }

            if($("#c1").get(0).checked)
            {
                if(!$("#r1").get(0).checked && !$("#r2").get(0).checked)
                {
                    alert("请选择是否承办");
                    $("#r1").focus();
                    return false;
                }
            }

            var val = "";
            $("input[name=ReasonType]").each(function(){
                if(this.checked)
                {
                    val += this.value + "|";
                }
            });
            if(val != "")
            {
                val = val.substr(0,val.length-1);
                $("#<%=this.ReasonType.ClientID%>").val(val);
            }

            val
            $("input[name=Condition]").each(function(){
                if(this.checked)
                {
                    val += this.value + "|";
                }
            });
            if(val != "")
            {
                val = val.substr(0,val.length-1);
            }

            $("#<%=this.Condition.ClientID%>").val($("[name=Condition]:checked").val());

            return true;
        }

        //checkbox选择事件
        function fcchange(e)
        {
            $radios = $(".radiop").find("input[type='radio']");
            if(e.checked)
            {
                $radios.each(function(){
                    $(this).removeAttr("disabled");
                });
            }
            else
            {
                $radios.each(function(){
                    this.disabled = true;
                });
            }
        }
        //checkbox选择事件
        function tcchange(e)
        {
            if(e.checked)
            {
                $("#<%=this.OtherReason.ClientID%>").removeAttr("readonly").removeClass("readonly");
            }
            else
            {
                $("#<%=this.OtherReason.ClientID%>").attr("readonly","readonly").addClass("readonly").val("");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1><%=ApplyName %></h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td colspan="4" style="padding: 5px; text-align: left; line-height: 35px;">
                        <span style="font-weight: bold">广州市汇瀚顾问有限公司：</span><br />
                        <asp:TextBox ID="Area" runat="server" requiredmes="请填写区"></asp:TextBox>区
                        <asp:TextBox ID="Department" runat="server" Width="30%" requiredmes="请填写分行（组别）"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />分行（组别）
                        <asp:TextBox ID="Clerk" runat="server" Width="23%" requiredmes="请填写营业员"></asp:TextBox>营业员
                        <br />
                        于<asp:TextBox ID="DealDate" runat="server" dateplugin='datepicker' requiredmes="请选择物业成交时间"></asp:TextBox>成交物业（成交编号：
                        <asp:TextBox ID="ApplyID" runat="server" Width="48%" requiredmes="请填写成交编号"></asp:TextBox>），
                        <br />
                        地址：<asp:TextBox ID="Address" runat="server" Width="88%" requiredmes="请填写地址"></asp:TextBox>
                        <div style="margin: 0px">因以下原因（多选）：<span style="color: red">请于佣金系统查核被hold佣原因，并落实已满足所有解hold条件。</span></div>
                        <div style="margin: 0px">
                            <p style="margin: 0px; padding-left: 20px">
                                <input type="checkbox" id="c1" onclick="fcchange(this);" value="1" name="ReasonType" /><label for="c1">1、超3天后转介，系统自动hold佣；超3天后没有转介，人工手动hold佣。</label></p>
                            <p class="radiop" style="margin: 0px; padding-left: 40px">
                                <input type="radio" id="r1" name="Condition" value="1" /><label for="r1">承办（在我司办理按揭）→解hold条件：已签按揭文件，已收费。</label><br />
                                <input type="radio" id="r2" name="Condition" value="0" /><label for="r2">不承办（不在我司办理按揭）→解hold条件：汇瀚经办已在按揭系统完成不承办流程并生效，附上已有业客、分行及汇瀚各层级签名的《按揭不承办知会函》。</label>
                            </p>
                            <p style="margin: 0px; padding-left: 20px">
                                <input type="checkbox" id="c2" value="2" name="ReasonType" /><label for="c2">2、汇瀚经办没有见证不承办。</label></p>
                            <p style="margin: 0px; padding-left: 40px">
                                汇瀚经办已在按揭系统完成不承办流程并生效，附上已有业客、分行及汇瀚各层级签名的《按揭不承办知会函》；分行提供交易过户后有抵押情况的新房产证或新查册表。
                            </p>
                            <p style="margin: 0px; padding-left: 20px">
                                <input type="checkbox" id="c3" onclick="tcchange(this)" value="3" name="ReasonType" /><label for="c3">3、其他hold佣原因。</label></p>
                            <p style="margin: 0px; padding-left: 40px">
                                <asp:TextBox ID="OtherReason" runat="server" Width="30%" CssClass="readonly" Style="width: 99%" requiredmes="请填写其他hold佣原因"></asp:TextBox>
                            </p>
                        </div>
                        <div style="margin: 0px">造成被汇瀚hold佣，请汇瀚查明原因，给予解hold。</div>
                        <div>
                            申请录入人：<asp:Label ID="Apply" runat="server"></asp:Label>
                        </div>
                        <asp:HiddenField ID="ReasonType" runat="server" />
                        <asp:HiddenField ID="Condition" runat="server" />
                    </td>
                </tr>
                <tr style="display:none">
                    <td class="tl PL10" colspan="4">
                        
                        <asp:Label ID="ApplyDate" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0">
                <tr class="noborder" style="height: 85px;" idx="1">
                    <td class="auto-style2">分行主管</td>
                    <td colspan="3" class="tl PL10" style="">
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
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="2">
                    <td class="auto-style2">高级经理</td>
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
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="3">
                    <td class="auto-style2">区域经理</td>
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
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="4">
                    <td class="auto-style2">区域总监/区域副总监</td>
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
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;" idx="5">
                    <td class="auto-style2">区域负责人</td>
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
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;" idx="7">
                    <td class="auto-style2">汇瀚跟进人</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" /><label class="l signother">其他意见</label>
                            <asp:LinkButton ID="lbtnAddMH" runat="server" Visible="False" OnClick="lbtnAddMH_Click">添加汇瀚总监审批</asp:LinkButton><br />
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

                <tr class="noborder" style="height:85px;display:none" idx="9">
                    <td class="auto-style2">汇瀚营运总监</td>
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
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
            <!--打印正文结束-->
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
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />
                <input type="hidden" id="hdDetail" runat="server" />
                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        PageInit()
    </script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>
