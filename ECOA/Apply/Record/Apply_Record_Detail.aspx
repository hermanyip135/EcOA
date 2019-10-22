<%@ Page ValidateRequest="false" Title="备案必须的内容 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Record_Detail.aspx.cs" Inherits="Apply_Record_Apply_Record_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        $(function() {      
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
		        }
            });
            //for (var x = 1; x < i; x++) {
            //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
            //}
		     
            //i = $("#tbDetail tr").length - 1;
            $("#<%=txtTurnDate.ClientID%>").datepicker();
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
       

        function check() {
            if($.trim($("#<%=ddlBusiness.ClientID%>").val())=="0") {
                alert("请选择转介汇瀚部门！");
                $("#<%=ddlBusiness.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
                alert("成交编号不可为空！");
		        $("#<%=txtApplyID.ClientID %>").focus();
                return false;
            }
	        
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("分行名称不可为空！");
		        $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
			
            if($.trim($("#<%=txtApplyDate.ClientID %>").val())=="") {
                alert("成交日期不可为空！");
		        $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtAddress.ClientID %>").val())=="") {
                alert("成交查册地址不可为空！");
		        $("#<%=txtAddress.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtAName.ClientID %>").val())=="") {
                alert("业主姓名不可为空！");
		        $("#<%=txtAName.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtAPhone.ClientID %>").val())=="") {
                alert("业主电话不可为空！");
		        $("#<%=txtAPhone.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtBname.ClientID %>").val())=="") {
                alert("买家姓名不可为空！");
		        $("#<%=txtBname.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtClerk.ClientID %>").val())=="") {
                alert("营业员姓名不可为空！");
		        $("#<%=txtClerk.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtMaster.ClientID %>").val())=="") {
                alert("分行主管姓名不可为空！");
                $("#<%=txtMaster.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtTurnDate.ClientID %>").val())=="") {
                alert("预计审核转介时间不可为空！");
                $("#<%=txtTurnDate.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
                alert("备案原因不可为空！");
                $("#<%=txtReason.ClientID %>").focus();
                return false;
            }
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
		        window.location='Apply_Record_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_Record_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_Record_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }
		
                function sign(idx) {
                    //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'){
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

        .auto-style1 {
            width: 20%;
            text-align:center;
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
            <h1>备案必须的内容</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td class="auto-style1">成交编号</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtApplyID" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">成交日期</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtApplyDate" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">成交查册地址</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAddress" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">分行名称</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="98%"></asp:TextBox>
                        <input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">业主姓名</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAName" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">业主电话</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAPhone" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">买家姓名</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtBname" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">买家电话</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtBphone" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">营业员姓名</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtClerk" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">分行主管姓名</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtMaster" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">预计审核转介时间</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTurnDate" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">备案原因</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Width="98%" Height="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">转介汇瀚部门</td>
                    <td colspan="3" style="text-align: left; padding-left: 3px;">
                        <asp:DropDownList ID="ddlBusiness" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlBusiness_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="业务一部">业务一部</asp:ListItem>
                            <asp:ListItem Value="业务二部">业务二部</asp:ListItem>
                            <asp:ListItem Value="业务三部">业务三部</asp:ListItem>
                            <asp:ListItem Value="业务四部">业务四部</asp:ListItem>
                            <asp:ListItem Value="业务五部">业务五部</asp:ListItem>
                            <asp:ListItem Value="业务六部">业务六部</asp:ListItem>
                            <asp:ListItem Value="番禺业务部">番禺业务部</asp:ListItem>
                            <asp:ListItem Value="业务八部">业务八部</asp:ListItem>
                            <asp:ListItem Value="业务九部">业务九部</asp:ListItem>
                            <asp:ListItem Value="业务十部">业务十部</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">转介汇瀚人员</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTname" runat="server" Width="98%" BackColor="#DEDFDE" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>

                <tr style="display: none">
                    <td class="tl PL10" colspan="4">
                        <asp:Label ID="lblApply" runat="server"></asp:Label>　
                    </td>
                </tr>

                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 10px; line-height: 30px;">
                        <div style="color: #FF0000; font-size: large; font-weight: bold;">
                            注： <br />
                            &gt; 请准确、详细填写备案的成交资料，以免HOLD错佣。 <br />
                            &gt; 在成交三天内申请，经汇瀚查核原因后可作备案，逾期提交不作备案处理。 <br />
                            &gt; 如发现备案内容有错漏（如成交编号与地址不符、成交日期/分行名/客户名不对…等）将不作备案处理。
                        </div>
                    </td>
                </tr>
                
<%--                <tr id="trManager1" class="noborder" style="height: 85px;">
                    <td class="auto-style4">分行主管</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td class="auto-style4">高级经理</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trManager3" class="noborder" style="height: 85px;">
                    <td class="auto-style4">区域经理</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trManager4" class="noborder" style="height: 85px;">
                    <td class="auto-style4">区域总监/区域副总监</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
                        <textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trManager5" class="noborder" style="height: 85px;">
                    <td class="auto-style4">区域负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签名" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td class="auto-style4">汇瀚跟进人</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label>　
                        <asp:LinkButton ID="lbtnAddMH" runat="server" Visible="False" OnClick="lbtnAddMH_Click">添加汇瀚总监审批</asp:LinkButton><br />
                        <textarea id="txtIDx7" rows="9" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trMH" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">汇瀚营运总监</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx9" type="radio" name="agree9" />
                        <label for="rdbYesIDx9">同意</label>
                        <input id="rdbNoIDx9" type="radio" name="agree9" />
                        <label for="rdbNoIDx9">不同意</label>
                        <input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label><br />
                        <textarea id="txtIDx9" rows="9" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
                        </span>
                    </td>
                </tr>--%>

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

            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
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
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

