<%@ Page ValidateRequest="false" Title="资产借调申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Secondment_Detail.aspx.cs" Inherits="Apply_Secondment_Apply_Secondment_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

		$(function() {      
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}
		    $("#<%=txtDepartment.ClientID %>").autocomplete({source: jJSON});
		    $("#<%=txtBorrowDepartment.ClientID %>").autocomplete({source: jJSON});
		    $("#<%=txtInDptm.ClientID %>").autocomplete({source: jJSON});
		    $("#<%=txtBorrowDate.ClientID%>").datepicker();
		    $("#<%=txtExpectReturnDate.ClientID%>").datepicker();
		    $("#<%=txtSalesDate.ClientID%>").datepicker();
		    $("#<%=txtReturnDate.ClientID%>").datepicker();
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

        function check() {
	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("请选择借调资产名称！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("发文部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }

            //if($.trim($("#<%=txtBorrowDepartment.ClientID %>").val())=="") {
            //    alert("借出部门不可为空！");
            //    $("#<%=txtBorrowDepartment.ClientID %>").focus();
	        //    return false;
            //}
			
	        if($.trim($("#<%=txtInDptm.ClientID %>").val())=="") {
	            alert("借入部门不可为空！");
	            $("#<%=txtInDptm.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtInDptmContact.ClientID %>").val())=="") {
	            alert("借入部门联系人不可为空！");
	            $("#<%=txtInDptmContact.ClientID %>").focus();
	            return false;
	        }

	        //if($.trim($("#<%=txtTheMessage.ClientID %>").val())=="") {
	        //    alert("借调资产规格、型号不可为空！");
	        //    $("#<%=txtTheMessage.ClientID %>").focus();
	        //    return false;
	        //}

	        if($.trim($("#<%=txtNumber.ClientID %>").val())=="") {
	            alert("数量不可为空！");
	            $("#<%=txtNumber.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBorrowDate.ClientID %>").val())=="") {
	            alert("借调日期不可为空！");
	            $("#<%=txtBorrowDate.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtExpectReturnDate.ClientID %>").val())=="") {
                alert("归还日期（预计）不可为空！");
	            $("#<%=txtExpectReturnDate.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
                alert("借调原因不可为空！");
                $("#<%=txtReason.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=ddlAssetsName.ClientID %>").val())=="") {
                alert("请选择借调资产名称！");
                $("#<%=ddlAssetsName.ClientID %>").focus();
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
		    var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue=='success')
		    {
		        if(isNewApply)
		            isUploaded = true;
		        else
		            window.location='Apply_Secondment_Detail.aspx?MainID=<%=MainID %>';
		    }
		}

		function editflow(){
			var win=window.showModalDialog("Apply_Secondment_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_Secondment_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx!='6'&&idx!='7'&&idx!='8'&&idx!='11'){
	        //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
	        //        alert("请确定是否同意！");
	        //        return;
	        //    }
	        //}
	        //else{
	        if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
	        //}
			
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
			//	var temp = window.document.body.innerHTML;        
			//	var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
			//	window.document.body.innerHTML = printhtml;        
			//	window.print();        
			//	window.document.body.innerHTML = temp;    
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
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
        .auto-style3 {
            width: 140px;
        }
        .auto-style4 {
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>资产借调申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
                <tr  style="display: none;">
                    <td colspan="4" style="text-align: left; display: none;">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 350px;">填写日期：<asp:Label ID="lblApplyDate" runat="server"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" class="auto-style3">申请部门：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="95%"></asp:TextBox>
                    </td>
				</tr>
                <tr>
                    <td colspan="1" class="auto-style3">借出部门：</td>
                    <td colspan="3" class="tl PL10">总部仓库
                        <asp:TextBox ID="txtBorrowDepartment" runat="server" Width="10%" Visible="False"></asp:TextBox>
                    </td>
				</tr>
                <tr>
                    <td colspan="1" class="auto-style3">借入部门：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:textbox id="txtInDptm" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="1" class="auto-style3">借入部门联系人：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:textbox id="txtInDptmContact" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>

                <tr>
                    <td colspan="1" class="auto-style3">借调资产名称：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlAssetsName" runat="server" AutoPostBack="True" Width="30%" OnSelectedIndexChanged="ddlAssetsName_SelectedIndexChanged">
                        </asp:DropDownList>
                      　<asp:Label ID="lbAssetsName" runat="server" Text=""></asp:Label>　
                        <asp:Label ID="lbSummary" runat="server" Text=""></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
				</tr>
                <tr>
                    <td colspan="1" class="auto-style3">资产编号：</td>
                    <td colspan="3" class="tl PL10">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:textbox id="txtApplyID" runat="server" Width="95%" Enabled="False"></asp:textbox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
				</tr>
                
                <tr>
                    <td colspan="1" style="padding-top: 10px; vertical-align: top" class="auto-style3">借调原因：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:textbox id="txtReason" runat="server" Width="95%" TextMode="MultiLine" Height="100px"></asp:textbox>
                    </td>
				</tr>
                <tr style="display: none">
                    <td colspan="1" class="auto-style3">借调资产规格、型号：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:textbox id="txtTheMessage" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="1" class="auto-style3">数量：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:textbox id="txtNumber" runat="server" Width="30%" ReadOnly="True" Enabled="False">1</asp:textbox>个
                    </td>
				</tr>
                <tr>
                    <td colspan="1" class="auto-style3">借调日期：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:textbox id="txtBorrowDate" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="1" class="auto-style3">归还日期（预计）：</td>
                    <td colspan="3" class="tl PL10">
                        <asp:textbox id="txtExpectReturnDate" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>



				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style3">部门主管</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label>
                        <input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 95%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
					</td>
				</tr>
				<tr>
					<td class="auto-style3">隶属主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                        <input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 95%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
					</td>
				</tr>
                <tr>
                    <td class="auto-style3">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx4" type="radio" name="agree4" value="1" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" value="2" /><label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 95%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
					</td>
				</tr>
                <tr id="trManager2" class="noborder" style="height: 85px; ">
					<td rowspan="2" class="auto-style3">资讯科技部确认</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx5" type="radio" name="agree5" value="1" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" value="2" /><label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" value="3" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 95%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx5" value="签名" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
					</td>
				</tr>
                <tr id="trManager22" class="noborder" style="height: 85px; ">
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx6" type="radio" name="agree6" value="11" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" value="21" /><label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" value="22" /><label for="rdbOtherIDx6">其他意见</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 95%; overflow: auto;" cols="20" name="S4"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td rowspan="2" class="auto-style3">行政部确认</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label>
						<input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">其他意见</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 95%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
					</td>
				</tr>
                <tr id="trManager33" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx7" type="radio" name="agree7" value="1" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" value="2" /><label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="3" style="width: 95%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
					</td>
				</tr>
                <tr>
                    <td class="auto-style3" >出仓日期：</td>
                    <td class="tl PL10">
                        <asp:textbox id="txtSalesDate" runat="server"></asp:textbox>
                    </td>
                    <td class="auto-style4" >出仓人：</td>
                    <td class="tl PL10">
                        <asp:textbox id="txtSales" runat="server" ></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td class="auto-style3" >归还日期：</td>
                    <td class="tl PL10">
                        <asp:textbox id="txtReturnDate" runat="server"></asp:textbox>
                    </td>
                    <td class="auto-style4" >归还人：</td>
                    <td class="tl PL10">
                        <asp:textbox id="txtReturner" runat="server"></asp:textbox>
                    </td>
				</tr>
			</table>
			<!--打印正文结束-->
		</div>

        <div class="noprint">
		<asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" backcolor="White" style="clear: both; margin-top: 3px;"
			bordercolor="#DEDFDE" borderstyle="None" borderwidth="1px" cellpadding="4" autogeneratecolumns="false"
			forecolor="Black" gridlines="Vertical" onrowcommand="gvAttach_RowCommand">
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
		</asp:gridview>
        <div id="PageBottom">
		<hr />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
		<asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
		<asp:button runat="server" id="btnSignSave" text="标注已留档" onclick="btnSignSave_Click" visible="false" />
		<input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
		<asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
		<asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
		<asp:hiddenfield id="hdIsAgree" runat="server" />
		<asp:hiddenfield id="hdSuggestion" runat="server" />
		<input type="hidden" id="hdDetail" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

