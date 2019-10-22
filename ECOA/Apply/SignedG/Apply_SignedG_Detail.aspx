<%@ Page ValidateRequest="false" Title="关于签署两方版本担保协议书的申请 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_SignedG_Detail.aspx.cs" Inherits="Apply_SignedG_Apply_SignedG_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        $(function() {      
            $("#<%=txtCCDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {}
            });
            $("#<%=txtReceiveDP.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {}
            });
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
       

        function check() {
            if (isNaN($("#<%=txtLmoney.ClientID%>").val())) {
                alert("贷款金额必须输入纯数字");
                $("#<%=txtLmoney.ClientID%>").val('');
                $("#<%=txtLmoney.ClientID%>").focus();
                return false;
            }

            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
                alert("发文编号不可为空！");
                $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=ddlDepartment.ClientID %>").val())=="请选择") {
                alert("请选择发文部门！");
                $("#<%=ddlDepartment.ClientID %>").focus();
	            return false;
            }

            //if($.trim($("#<%=txtReceiveDP.ClientID %>").val())=="") {
            //    alert("收文部门不可为空！");
            //    $("#<%=txtReceiveDP.ClientID %>").focus();
	        //    return false;
            //}
            
            if($.trim($("#<%=txtTelephone.ClientID %>").val())=="") {
                alert("回复电话不可为空！");
                $("#<%=txtTelephone.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtFax.ClientID %>").val())=="") {
                alert("回复传真不可为空！");
                $("#<%=txtFax.ClientID %>").focus();
	            return false;
            }
            
            if($.trim($("#<%=txtSubject.ClientID %>").val())=="") {
                alert("文件主题不可为空！");
                $("#<%=txtSubject.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtCaseNo.ClientID %>").val())=="") {
                alert("汇瀚案号不可为空！");
                $("#<%=txtCaseNo.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtDealer.ClientID %>").val())=="") {
                alert("经办不可为空！");
                $("#<%=txtDealer.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtAddress.ClientID %>").val())=="") {
                alert("物业地址不可为空！");
                $("#<%=txtAddress.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtOwner.ClientID %>").val())=="") {
                alert("业主不可为空！");
                $("#<%=txtOwner.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtBuyer.ClientID %>").val())=="") {
                alert("买家不可为空！");
                $("#<%=txtBuyer.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtLoanBank.ClientID %>").val())=="") {
                alert("贷款银行不可为空！");
                $("#<%=txtLoanBank.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtCmoney.ClientID %>").val())=="") {
                alert("担保金额不可为空！");
                $("#<%=txtCmoney.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtLmoney.ClientID %>").val())=="") {
                alert("贷款金额不可为空！");
                $("#<%=txtLmoney.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtDmoney.ClientID %>").val())=="") {
                alert("成交金额不可为空！");
                $("#<%=txtDmoney.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
                alert("原因不可为空！");
                $("#<%=txtReason.ClientID %>").focus();
                return false;
            }

            return true;
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
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile20M.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue=='success')
		        window.location='Apply_SignedG_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_SignedG_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_SignedG_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }
		
                function sign(idx) {
                    //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'){
                    //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
                    //        alert("请确定是否同意！");
                    //        return;
                    //    }
                    //}
                    //else{
                    //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                    //        alert("请确定是否同意！");
                    //        return;
                    //    }
                    //}
			
                    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                        alert("请确定是否同意！");
                        return;
                    }
			
                    if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
                        alert("由于您不同意该申请，必须填写不同意的原因。");
                        return;
                    }
                    if($("#rdbOtherIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
                        alert("由于您选其他意见，必须填写意见。");
                        return;
                    }
				
                    if(confirm("是否确认审核？"))
                    {
                        if($("#rdbYesIDx"+idx).prop("checked"))
                            $("#<%=hdIsAgree.ClientID %>").val("1");
                else if($("#rdbNoIDx"+idx).prop("checked"))
                    $("#<%=hdIsAgree.ClientID %>").val("0");
				else if($("#rdbOtherIDx"+idx).prop("checked"))
				    $("#<%=hdIsAgree.ClientID %>").val("2");
					   
        getSuggestion(idx);
        document.getElementById("<%=btnSign.ClientID %>").click();
    }
}  

function getSuggestion(idx)
{
    $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
        }
		
        function myPrint(start, end, extend) {    
            //start = "<!--" + start + "-->";    
            //end = "<!--" + end + "-->";    
            //if (typeof (extend) == 'undefined') {        
            //    var temp = window.document.body.innerHTML;        
            //    var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
            //    window.document.body.innerHTML = printhtml;        
            //    window.print();        
            //    window.document.body.innerHTML = temp;    
            //}    
            //else { window.print(); }
            cMyPrint();
        }
        function DeleteT() { //20141231：M_DeleteC
            $("#btnADelete").hide();
            var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
		    var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
            if(sReturnValue=='deleted')
                window.location='/Apply/Apply_Search.aspx';
            else
                window.location.href=window.location.href;
		}
    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td {
            border: 0;
        }

        .auto-style4 {
            width: 279px;
        }
        .auto-style5 {
            width: 100px;
        }
        .auto-style6 {
            width: 240px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>关于签署两方版本担保协议书的申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround"  width='640px'>
				<tr>
					<td class="auto-style5">收文部门</td>
					<td class="tl PL10">法律部—陈洁丽<asp:TextBox ID="txtReceiveDP" runat="server" Width="200px" Visible="False"></asp:TextBox></td>
					<td class="auto-style5" >发文编号</td>
					<td class="tl PL10"><asp:TextBox ID="txtApplyID" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style5" >发文部门</td>
					<td class="tl PL10">
                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="155px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem Value="业务一部">业务一部：叶英健</asp:ListItem>
                            <asp:ListItem Value="业务二部">业务二部：麦淑姗</asp:ListItem>
                            <asp:ListItem Value="业务三部">业务三部：黄瑞雯</asp:ListItem>
                            <asp:ListItem Value="业务四部">业务四部：吴紫霞</asp:ListItem>
                            <asp:ListItem Value="业务五部">业务五部：吴远斌</asp:ListItem>
                            <asp:ListItem Value="番禺业务部">番禺业务部：刘婉敏</asp:ListItem>
                            <asp:ListItem Value="业务六部">业务六部：李军</asp:ListItem>
                             <asp:ListItem Value="业务八部">业务八部：黄兆辉</asp:ListItem>
                            <asp:ListItem Value="业务九部">业务九部：梁海源</asp:ListItem>
                             <asp:ListItem Value="业务十部">业务十部：吴宏斌</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblApply" runat="server" Visible="False"></asp:Label>
					</td>
                    <td class="auto-style5">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
					<td class="auto-style5">回复电话</td>
					<td class="tl PL10">
                        <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtCCDepartment" runat="server" Width="200px" Visible="False"></asp:TextBox>
					</td>
                    <td class="auto-style5">回复传真</td>
					<td class="tl PL10"><asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style5">文件主题</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtSubject" runat="server" Width="97%"></asp:TextBox></td>
				</tr>

                <tr>
					<td colspan="4" style="text-align: center">
                        <div style="border-color: #000000; border-bottom-style: groove; border-top-style: groove; border-top-width: 1px; border-bottom-width: 2px; height: 2px; width: 620px;margin:0 auto;"></div>
                        <div style="padding-left: 20px; text-align: left; margin-bottom: 15px; margin-top: 10px; line-height: 25px;">
                            兹有以下案件：<br />
                            汇瀚案号：<asp:TextBox ID="txtCaseNo" runat="server" Width="242px"></asp:TextBox>经办：<asp:TextBox ID="txtDealer" runat="server" Width="253px"></asp:TextBox><br />
                            物业地址：<asp:TextBox ID="txtAddress" runat="server" Width="535px"></asp:TextBox><br />
                            业主：<asp:TextBox ID="txtOwner" runat="server" Width="100px"></asp:TextBox>
                            买家：<asp:TextBox ID="txtBuyer" runat="server" Width="100px"></asp:TextBox>
                            贷款银行：<asp:TextBox ID="txtLoanBank" runat="server" Width="250px"></asp:TextBox><br />
                            贷款金额：<asp:TextBox ID="txtLmoney" runat="server" Width="110px"></asp:TextBox>万，
                            成交金额：<asp:TextBox ID="txtDmoney" runat="server" Width="110px"></asp:TextBox>万，
                            担保费：￥<asp:TextBox ID="txtCmoney" runat="server" Width="110px"></asp:TextBox>元<br />
                            <div style="margin-top: 10px">
                                <span style="vertical-align: top">原因：</span>
                                <asp:textbox id="txtReason" runat="server" TextMode="MultiLine" Width="90%" Height="100px"></asp:textbox>
                            </div>
                            由于以上原因，故需签署两方版本的《个人房产业务委托担保协议书》。<br />
                            以上申请妥否，盼复！<br />
                            附件：1、担保申请表及《个人房产业务担保协议书》；2、买卖双方身份证、户口薄、婚姻状况证明；<br />
                      　　　3、房产证；4、买卖合同；5、查册表；6、同贷书；7、委托书 
                        </div> 
					</td>
				</tr>
<%--                <tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style4">申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>--%>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style4">部门主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
				<tr id="trmq">
					<td class="auto-style4">部门隶属主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style4">部门负责人意见</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>

                <tr class="noborder" style="height: 85px;">
					<td class="auto-style4">首席运营官</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>

				<tr class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style4">法律部门<br />主管意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7"/>
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
					</td>
				</tr>
            </table>
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

            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
            <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
            <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
            <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
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
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

