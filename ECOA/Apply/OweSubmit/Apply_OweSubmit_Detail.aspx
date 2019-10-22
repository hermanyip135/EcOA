<%@ Page ValidateRequest="false" Title="延缓提交入职资料申请 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_OweSubmit_Detail.aspx.cs" Inherits="Apply_OweSubmit_Apply_OweSubmit_Detail" %>

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
            $("#<%=txtInductionDate.ClientID%>").datepicker();
            $("#<%=txtSupplementaryDate.ClientID%>").datepicker();
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
       

        function check() {
            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
		        alert("发文编号不可为空！");
		        $("#<%=txtApplyID.ClientID %>").focus();
                return false;
            }
	        
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
		        alert("部门/分行不可为空！");
		        $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
			
            if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {
		        alert("回复电话不可为空！");
		        $("#<%=txtReplyPhone.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtSubject.ClientID %>").val())=="") {
		        alert("文件主题不可为空！");
		        $("#<%=txtSubject.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtName.ClientID %>").val())=="") {
		        alert("员工姓名不可为空！");
		        $("#<%=txtName.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtBranch.ClientID %>").val())=="") {
		        alert("分行/组别不可为空！");
		        $("#<%=txtBranch.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtPosition.ClientID %>").val())=="") {
		        alert("担任职位不可为空！");
		        $("#<%=txtPosition.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtInductionDate.ClientID %>").val())=="") {
		        alert("入职日期不可为空！");
		        $("#<%=txtInductionDate.ClientID %>").focus();
                return false;
            }



            if($.trim($("#<%=txtWhy.ClientID %>").val())=="") {
		        alert("资料欠交原因不可为空！");
		        $("#<%=txtWhy.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtSupplementaryDate.ClientID %>").val())=="") {
		        alert("资料补交日期不可为空！");
		        $("#<%=txtSupplementaryDate.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtOpinion.ClientID %>").val())=="") {
		        alert("处理意见不可为空！");
		        $("#<%=txtOpinion.ClientID %>").focus();
                return false;
            }

            if (
                    !$("#<%=cbDetail1.ClientID %>").prop("checked") 
                    && !$("#<%=cbDetail2.ClientID %>").prop("checked") 
                    && !$("#<%=cbDetail3.ClientID %>").prop("checked")
                    && !$("#<%=cbDetail4.ClientID %>").prop("checked")
                    && !$("#<%=cbDetail5.ClientID %>").prop("checked")
                    && !$("#<%=cbDetail6.ClientID %>").prop("checked")
                    && !$("#<%=cbDetail7.ClientID %>").prop("checked")
                    && !$("#<%=cbDetail8.ClientID %>").prop("checked")
                    && !$("#<%=cbDetail9.ClientID %>").prop("checked")
               ) 
            {
                alert("请选择欠交资料");
                $("#<%=cbDetail1.ClientID%>").focus();
                return false;
            }

            if($("#<%=cbDetail8.ClientID %>").prop("checked"))
		    {
		        if($.trim($("#<%=txtCertificate.ClientID %>").val())=="") {
                    alert("由于你选择了房地产经纪人执业证，请填写有效的证件资料！");
                    $("#<%=txtCertificate.ClientID %>").focus();
                    return false;
                }

                if($.trim($("#<%=txtAffiliated.ClientID %>").val())=="") {
                    alert("由于你选择了房地产经纪人执业证，请填写挂靠单位！");
                    $("#<%=txtAffiliated.ClientID %>").focus();
                    return false;
                }
            }

            if($("#<%=cbDetail5.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txthukouxz.ClientID %>").val())=="") {
                     alert("由于你选择了户口薄，请填写户口性质！");
                     $("#<%=txthukouxz.ClientID %>").focus();
                    return false;
                }

                if($.trim($("#<%=txthujidz.ClientID %>").val())=="") {
                     alert("由于你选择了户口簿，请填写户籍地址！");
                     $("#<%=txthujidz.ClientID %>").focus();
                    return false;
                }

                if($.trim($("#<%=txthouseholdername.ClientID %>").val())=="") {
                    alert("由于你选择了户口簿，请填写户主姓名！");
                    $("#<%=txthouseholdername.ClientID %>").focus();
                     return false;
                 }
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
		        window.location='Apply_OweSubmit_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_OweSubmit_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_OweSubmit_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }
		
                function sign(idx) {
                    //if(idx=='1'||idx=='2'||idx=='3'){
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

        .auto-style2 {
            width: 85px;
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
            <h1>延缓提交入职资料申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td>发文部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
                    <td class="auto-style2">发文编号</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApplyID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>发文日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                    <td>回复电话</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>文件主题</td>
                    <td colspan="3" class="tl PL10">
                        <asp:TextBox ID="txtSubject" runat="server" Width="460px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td rowspan="3" style="vertical-align: top; padding-top: 15px;">申请内容</td>
                    <td colspan="3" style="padding: 5px; text-align: left; line-height: 30px;">
                        <span style="font-weight: bold">新入职员工基本信息：</span><br />
                        员工姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        分行/组别：<asp:TextBox ID="txtBranch" runat="server"></asp:TextBox><br />
                        担任职位：<asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
                        入职日期：
                        <asp:TextBox ID="txtInductionDate" runat="server"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="padding: 5px; text-align: left; line-height: 30px;">
                        <span style="font-weight: bold">欠交资料明细： </span>
                        <br />

                        <asp:CheckBox ID="cbDetail1" runat="server" Text="广东省就业失业手册原件/办理回执" />
                        <asp:CheckBox ID="cbDetail2" runat="server" Text="解除劳动关系证明/离职证明" /><br />
                        <asp:CheckBox ID="cbDetail3" runat="server" Text="身份证原件/临时身份证/办理回执" />
                        <asp:CheckBox ID="cbDetail4" runat="server" Text="居住证复印件/办理回执 "  Visible="false"/><br />
                        <asp:CheckBox ID="cbDetail5" runat="server" Text="户口簿" />
                        <span>户口性质：<asp:TextBox ID="txthukouxz" runat="server" Width="300px"></asp:TextBox></span><br />
                        <span style="margin-left:60px;">户籍地址：<asp:TextBox ID="txthujidz" runat="server" Width="300px"></asp:TextBox></span><br />
                        <span style="margin-left:60px;"> 户主姓名：<asp:TextBox ID="txthouseholdername" runat="server" Width="300px"></asp:TextBox></span><br />
                        <asp:CheckBox ID="cbDetail6" runat="server" Text="学历证/在校证明" />
                        <asp:CheckBox ID="cbDetail9" runat="server" Text="体检报告" /><br />
                        <asp:CheckBox ID="cbDetail7" runat="server" Text="房地产经纪人资格证" Visible="false" />
                        <asp:CheckBox ID="cbDetail8" runat="server" Text="房地产经纪人职业水平证书(原执业证书)" /><br />

                        证书号码：<asp:TextBox ID="txtCertificate" runat="server" Width="405px"></asp:TextBox><br />
                        挂靠单位：<asp:TextBox ID="txtAffiliated" runat="server" Width="405px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="padding: 5px; text-align: left; line-height: 30px;">
                        <span style="font-weight: bold">资料欠交原因：（请于下列方框上注明）</span><br />
                        <asp:TextBox ID="txtWhy" runat="server" Height="100px" TextMode="MultiLine" Width="520px"></asp:TextBox><br />
                        资料补交日期：<asp:TextBox ID="txtSupplementaryDate" runat="server"></asp:TextBox>（申请补交日期不得超过2个月）<br />
                        未能于上述补交日期前交回所欠资料，区域的处理意见是：<br />
                        <asp:TextBox ID="txtOpinion" runat="server" Height="100px" TextMode="MultiLine" Width="520px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 390px;">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>

                <tr id="trManager1" class="noborder" style="height: 85px;">
                    <td class="auto-style2">部门主管</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx1">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td class="auto-style2">隶属主管</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx2">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager3" class="noborder" style="height: 85px;">
                    <td class="auto-style2">部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td rowspan="3" class="auto-style2">人力资源部</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
                        <textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </div>
                    </td>
                </tr>
                <tr class="noborder" style="height:85px">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S1"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx6">_________</span></div>
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
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

