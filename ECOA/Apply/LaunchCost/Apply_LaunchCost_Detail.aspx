<%@ Page ValidateRequest="false" Title="减佣/让佣申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_LaunchCost_Detail.aspx.cs" Inherits="Apply_ReduceComm_Apply_ReduceComm_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;
		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

		$(function() {      
			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});

		    i = $("#tbDetail tr").length;
		    for (var x = 1; x < i; x++) {
		        $("#txtDealDate"+x).datepicker({
		            showButtonPanel: true,
		            showOtherMonths: true,
		            selectOtherMonths: true,
		            changeMonth: true,
		            changeYear: true
		        });
		    }
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

	    function check() {
	        if($.trim($("#<%=txtApplyForID.ClientID %>").val())=="") {
	            alert("申请人工号不可为空！");
	            $("#<%=txtApplyForID.ClientID %>").focus();
	            return false;
	        }
			
	        if($.trim($("#<%=txtApplyFor.ClientID %>").val())=="") {
	            alert("请正确填写申请人工号！");
	            $("#<%=txtApplyForID.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=ddlDepartmentType.ClientID %>").val())=="") {
	            alert("请选择所属区域！");
	            $("#<%=ddlDepartmentType.ClientID %>").focus();
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

	        if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
	            alert("让佣原因说明不可为空！");
	            $("#<%=txtReason.ClientID %>").focus();
	            return false;
	        }

	        var data = "";
	        var flag = true;

	        //如果详细只有一行，且该行未填任何资料
	        if($("#tbDetail tr").size() == 2 && $.trim($("#txtDealDate1").val()) == "" && $.trim($("#txtDealAddress1").val()) == "" 
                && $.trim($("#txtOriginalDealPrice1").val()) == "" && $.trim($("#txttxtFinalDealPrice1").val()) == "" && $.trim($("#txtCommPoint1").val()) == ""
                && $.trim($("#txtOriginalComm1").val()) == "" && $.trim($("#txtReduceCashBonus1").val()) == "" && $.trim($("#txtReduceComm1").val()) == ""
                && $.trim($("#txtTotalReduce1").val()) == "" && $.trim($("#txtActualReportMoney1").val()) == "") {
	            alert("请填写成交资料及各项金额！");
	            $("#txtDealDate1").focus();
	            return false;
	        }      
	        else{
	            $("#tbDetail tr").each(function(n) {
	                if (n != 0) {
	                    //if (n != 0 && n != $("#tbDetail tr").size()-1) {
	                    if ($.trim($("#txtDealDate" + n).val()) == "") {
	                        alert("第" + n + "行的成交日期必须填写。");
	                        $("#txtDealDate" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtDealAddress" + n).val()) == "") {
	                        alert("第" + n + "行的成交单位必须填写。");
	                        $("#txtDealAddress" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtOriginalDealPrice" + n).val()) == "") {
	                        alert("第" + n + "行的原成交价必须填写。");
	                        $("#txtOriginalDealPrice" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtFinalDealPrice" + n).val()) == "") {
	                        alert("第" + n + "行的客户最终成交价必须填写。");
	                        $("#txtFinalDealPrice" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtCommPoint" + n).val()) == "") {
	                        alert("第" + n + "行的代理费点数必须填写。");
	                        $("#txtCommPoint" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtOriginalComm" + n).val()) == "") {
	                        alert("第" + n + "行的原佣金必须填写。");
	                        $("#txtOriginalComm" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtReduceCashBonus" + n).val()) == "") {
	                        alert("第" + n + "行的让现金奖金额必须填写。");
	                        $("#txtReduceCashBonus" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtReduceComm" + n).val()) == "") {
	                        alert("第" + n + "行的让佣金额必须填写。");
	                        $("#txtReduceComm" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtTotalReduce" + n).val()) == "") {
	                        alert("第" + n + "行的总让佣金额必须填写。");
	                        $("#txtTotalReduce" + n).focus();
	                        flag = false;
	                    }
	                    else if ($.trim($("#txtActualReportMoney" + n).val()) == "") {
	                        alert("第" + n + "行的实际上数金额必须填写。");
	                        $("#txtActualReportMoney" + n).focus();
	                        flag = false;
	                    }
	                    else
	                        data += $.trim($("#txtDealDate" + n).val()) + "&&" + $.trim($("#txtDealAddress" + n).val()) + "&&" + $.trim($("#txtOriginalDealPrice" + n).val()) +"&&" + $.trim($("#txtFinalDealPrice" + n).val()) + "&&" + $.trim($("#txtCommPoint" + n).val()) + "&&" + $.trim($("#txtOriginalComm" + n).val()) + "&&" + $.trim($("#txtReduceCashBonus" + n).val()) + "&&" + $.trim($("#txtReduceComm" + n).val()) + "&&" + $.trim($("#txtTotalReduce" + n).val()) + "&&" + $.trim($("#txtActualReportMoney" + n).val())+ "||";
	                }
	            });
	        }

	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdDetail.ClientID %>").val(data);
                return true;
            }
            return false;
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
		    var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%//=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
			if(sReturnValue=='success')
				window.location='Apply_ReduceComm_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
		    var win=window.showModalDialog("Apply_ReduceComm_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
					if(win=='success')
					    window.location="Apply_ReduceComm_Detail.aspx?MainID=<%=MainID %>";
		}
		
	    function sign(idx) {
	        if(idx!='4'&&idx!='5'){
	            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
	        }
	        else{
	            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
	        }
			
			if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
				alert("由于您不同意该申请，必须填写不同意的原因。");
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

		function addRow() {
			var html = '<tr id="trDetail' + i + '">'
				+ '     <td><input type="text" id="txtDealDate' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtDealAddress' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtOriginalDealPrice' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtFinalDealPrice' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtCommPoint' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtOriginalComm' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtReduceCashBonus' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtReduceComm' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtTotalReduce' + i + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtActualReportMoney' + i + '" style="width:90%"/></td>'
				+ '</tr>';

			$("#tbDetail").append(html);

			$("#txtDealDate"+i).datepicker({
			    showButtonPanel: true,
			    showOtherMonths: true,
			    selectOtherMonths: true,
			    changeMonth: true,
			    changeYear: true
			});

			i++;
		}

		function deleteRow() {
			if (i > 2) {
			    i--;
			    $("#tbDetail tr:eq(" + i + ")").remove();
			} else
				alert("不可删除第一行。");
		}
		
		function getEmployee(n) {
		    $.ajax({
		        url: "/Ajax/HR_Handler.ashx",
		        type: "post",
		        dataType: "text",
		        data: "action=getEmployee&code=" + n.value,
		        success: function(info) {
		            if (info != "fail") {
		                var infos = info.split("|");
		                $("#<%=txtApplyForID.ClientID%>").val(infos[0]);
                        $("#<%=txtApplyFor.ClientID%>").val(infos[1]);
		                $("#<%=txtDepartment.ClientID%>").val(infos[2]);
		                $("#<%=hdDepartmentID.ClientID%>").val(infos[3]);
                        $("#spanApplyFor").show();
                    }
                    else{
                        $("#<%=txtApplyFor.ClientID%>").val("");
                        $("#<%=txtDepartment.ClientID%>").val("");
		                $("#<%=hdDepartmentID.ClientID%>").val("");
		                $("#spanApplyFor").hide();
                    }
                }
            })
        }
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
		<%=SbFlow.ToString() %>
        </div>
		<!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>减佣/让佣申请表</h1>
			<table style="border-style: double; border-color: Black; border-width: 5px; margin: 0 auto; background-color: #fff; border-collapse: collapse;" width='640px'>
				<tr>
					<td class="tl PL10" style="width: 20%; ">收文部门</td>
					<td class="tl PL10">法律部、财务部</td>
					<td class="tl PL10" style="width: 20%; ">文档编码</td>
					<td class="tl PL10"><%=SerialNumber %></td>
				</tr>
				<tr>
					<td class="tl PL10">申请部门</td>
					<td class="tl PL10"><input id="txtDepartment" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:90%;"/><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td class="tl PL10">申请人</td>
					<td class="tl PL10">工号：<asp:TextBox ID="txtApplyForID" runat="server" Width="40px" onblur="getEmployee(this);"></asp:TextBox><span id="spanApplyFor" style="display:none;">&nbsp;&nbsp;&nbsp;&nbsp;姓名：<input id="txtApplyFor" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span></td>
				</tr>
                <tr>
					<td class="tl PL10">所属区域</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlDepartmentType" runat="server"></asp:DropDownList></td>
					<td class="tl PL10">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td class="tl PL10">抄送部门</td>
					<td class="tl PL10">总办</td>
					<td class="tl PL10">回复电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td class="tl PL10">文件主题</td>
					<td class="tl PL10">关于<asp:textbox id="txtSubject" runat="server" Width="100px"></asp:textbox>减佣/让佣申请</td>
					<td class="tl PL10">填写人</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td class="tl PL10 PR10" colspan="4">
						<table id="tbDetail" class='sample tc' width='100%'>
							<thead>
								<tr>
									<td style="width: 90px;">成交日期</td>
									<td style="width: 180px;">成交单位</td>
									<td style="width: 70px;">原成交价</td>
									<td style="width: 70px;">客户最终<br />成交价</td>
									<td style="width: 45px;">代理费<br />点数</td>
									<td style="width: 70px;">原佣金</td>
									<td style="width: 60px;">让现金<br />奖金额</td>
									<td style="width: 60px;">让佣金额</td>
									<td style="width: 70px;">总让<br />佣金额</td>
									<td style="width: 70px;">实际上数<br />金额</td>
								</tr>
							</thead>
							<%=SbHtml.ToString()%>
						</table>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
					</td>
				</tr>
                <tr>
					<td class="tl PL10" colspan="4">
						让佣原因说明：<br/>
						<asp:textbox id="txtReason" runat="server" TextMode="MultiLine" Width="98%" Rows="10" style="overflow: auto;"></asp:textbox>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td style="border: 1px solid #000000;">部门负责人</td>
					<td colspan="3" class="tl PL10" style="border-top: 1px solid #000000;">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td rowspan="2" style="border: 1px solid #000000;">法律部意见</td>
					<td colspan="3" class="tl PL10" style="border-top: 1px solid #000000;">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style="border-top: 1px solid #000000;">
						<input id="rdbYesIDx3" type="radio" name="agree3"/><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;"> 
					<td rowspan="2" style="border: 1px solid #000000;">财务部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style="border-top: 1px solid #000000;">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style="border-top: 1px solid #000000;">
						<input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
<%--				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td style="border: 1px solid #000000;">董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style="border-top: 1px solid #000000;">
						<input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>--%>
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
						<a id="link" onclick="window.open('file:<%=ConfigurationManager.AppSettings["UploadPath"] %><%#Eval("OfficeAutomation_Attach_Path") %>');" href='<%=ConfigurationManager.AppSettings["UploadPath"] %><%#Eval("OfficeAutomation_Attach_Path") %>' target="_blank"><%#Eval("OfficeAutomation_Attach_Name")%></a>
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
		<hr />
        <asp:Button ID="btnReWrite" runat="server" OnClick="btnReWrite_Click" text="重新导入" Visible="False" />
		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
		<asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
		<asp:button runat="server" id="btnSignSave" text="标注已留档" onclick="btnSignSave_Click" visible="false" />
		<input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
		<asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
		<asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
		<asp:hiddenfield id="hdIsAgree" runat="server" />
		<asp:hiddenfield id="hdSuggestion" runat="server" />
		<input type="hidden" id="hdDetail" runat="server" />
	</div>
        </div>
	<%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

