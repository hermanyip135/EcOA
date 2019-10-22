<%@ Page ValidateRequest="false" Title="减佣/让佣申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ReduceComm_Detail.aspx.cs" Inherits="Apply_ReduceComm_Apply_ReduceComm_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;

		$(function() {      
			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});


		    i = <%=DetailCount.ToString() %>;
		    for (var x = 1; x <= i; x++) {
		        $("#txtDealDate"+x).datepicker();
		    }
		});

	    function check() {
	        if($.trim($("#<%=txtApplyForID.ClientID %>").val())=="") {alert("申请人工号不可为空！");$("#<%=txtApplyForID.ClientID %>").focus();return false;}
	        if($.trim($("#<%=txtApplyFor.ClientID %>").val())=="") {alert("请正确填写申请人工号！");$("#<%=txtApplyForID.ClientID %>").focus();return false;}
	        if($.trim($("#<%=ddlDepartmentType.ClientID %>").val())=="") {alert("请选择所属区域！");$("#<%=ddlDepartmentType.ClientID %>").focus();return false;}
	        if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {alert("回复电话不可为空！");$("#<%=txtReplyPhone.ClientID %>").focus();return false;}
	        if($.trim($("#<%=txtSubject.ClientID %>").val())=="") {alert("文件主题不可为空！");$("#<%=txtSubject.ClientID %>").focus();return false;}
	        if($.trim($("#<%=txtReason.ClientID %>").val())=="") {alert("让佣原因说明不可为空！");$("#<%=txtReason.ClientID %>").focus();return false;}

	        if (!$("#<%=rdbReduceWay1.ClientID%>").prop("checked") && !$("#<%=rdbReduceWay2.ClientID%>").prop("checked") && !$("#<%=rdbReduceWay3.ClientID%>").prop("checked")) {
	            alert("请选择减佣/让佣方式");
	            $("#<%=rdbReduceWay1.ClientID%>").focus();
	            return false;
            }

	        var data = "";
	        var flag = true;

	        //如果详细只有一行，且该行未填任何资料
	        if(i == 1 && $.trim($("#txtDealDate1").val()) == "" && $.trim($("#txtDealAddress1").val()) == "" 
                && $.trim($("#txtOriginalDealPrice1").val()) == "" && $.trim($("#txttxtFinalDealPrice1").val()) == "" && $.trim($("#txtCommPoint1").val()) == ""
                && $.trim($("#txtOriginalComm1").val()) == "" && $.trim($("#txtReduceCashBonus1").val()) == "" && $.trim($("#txtReduceComm1").val()) == ""
                && $.trim($("#txtTotalReduce1").val()) == "" && $.trim($("#txtActualReportMoney1").val()) == "") {
	            alert("请填写成交资料及各项金额！");
	            $("#txtDealDate1").focus();
	            return false;
	        }      
	        else{
	            for(var n=1;n<=i;n++){
	                if ($.trim($("#txtDealDate" + n).val()) == "") {alert("第" + n + "行的成交日期必须填写。");$("#txtDealDate" + n).focus();flag = false;}
	                else if ($.trim($("#txtDealAddress" + n).val()) == "") {alert("第" + n + "行的成交单位必须填写。");$("#txtDealAddress" + n).focus();flag = false;}
	                else if ($.trim($("#txtOriginalDealPrice" + n).val()) == "") {alert("第" + n + "行的原成交价必须填写。");$("#txtOriginalDealPrice" + n).focus();flag = false;}
	                else if ($.trim($("#txtFinalDealPrice" + n).val()) == "") {alert("第" + n + "行的客户最终成交价必须填写。");$("#txtFinalDealPrice" + n).focus();flag = false;}
	                else if ($.trim($("#txtCommPoint" + n).val()) == "") {alert("第" + n + "行的代理费点数必须填写。");$("#txtCommPoint" + n).focus();flag = false;}
	                else if ($.trim($("#txtOriginalComm" + n).val()) == "") {alert("第" + n + "行的原佣金必须填写。");$("#txtOriginalComm" + n).focus();flag = false;}
	                else if ($.trim($("#txtReduceCashBonus" + n).val()) == "") {alert("第" + n + "行的让现金奖金额必须填写。");$("#txtReduceCashBonus" + n).focus();flag = false;}
	                else if ($.trim($("#txtReduceComm" + n).val()) == "") {alert("第" + n + "行的让佣金额必须填写。");$("#txtReduceComm" + n).focus();flag = false;}
	                else if ($.trim($("#txtTotalReduce" + n).val()) == "") {alert("第" + n + "行的总让佣金额必须填写。");$("#txtTotalReduce" + n).focus();flag = false;}
	                else if ($.trim($("#txtActualReportMoney" + n).val()) == "") {alert("第" + n + "行的实际上数金额必须填写。");$("#txtActualReportMoney" + n).focus();flag = false;}
	                else data += $.trim($("#txtDealDate" + n).val()) + "&&" + $.trim($("#txtDealAddress" + n).val()) + "&&" + $.trim($("#txtOriginalDealPrice" + n).val()) 
                        + "&&" + $.trim($("#txtFinalDealPrice" + n).val()) + "&&" + $.trim($("#txtCommPoint" + n).val()) + "&&" + $.trim($("#txtOriginalComm" + n).val()) 
                        + "&&" + $.trim($("#txtReduceCashBonus" + n).val()) + "&&" + $.trim($("#txtReduceComm" + n).val()) + "&&" + $.trim($("#txtTotalReduce" + n).val()) 
                        + "&&" + $.trim($("#txtActualReportMoney" + n).val())+ "||";
	            }
	        }

	        if (flag) {data = data.substr(0, data.length - 2);$("#<%=hdDetail.ClientID %>").val(data);}
	        else return false;

	        if ($.trim($("#<%=txtDealDepartment.ClientID %>").val()) == "") {alert("总成交套数必须填写。");$("#<%=txtDealDepartment.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtOriginalDealPrice.ClientID %>").val()) == "") {alert("总原成交价必须填写。");$("#<%=txtOriginalDealPrice.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtFinalDealPrice.ClientID %>").val()) == "") {alert("总客户最终成交价必须填写。");$("#<%=txtFinalDealPrice.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtCommPoint.ClientID %>").val()) == "") {alert("总代理费点数必须填写。");$("#<%=txtCommPoint.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtOriginalComm.ClientID %>").val()) == "") {alert("总原佣金必须填写。");$("#<%=txtOriginalComm.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtReduceCashBonus.ClientID %>").val()) == "") {alert("总让现金奖金额必须填写。");$("#<%=txtReduceCashBonus.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtReduceComm.ClientID %>").val()) == "") {alert("总让佣金额必须填写。");$("#<%=txtReduceComm.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtTotalReduce.ClientID %>").val()) == "") {alert("总总让佣金额必须填写。");$("#<%=txtTotalReduce.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtActualReportMoney.ClientID %>").val()) == "") {alert("总实际上数金额必须填写。");$("#<%=txtActualReportMoney.ClientID %>").focus();return false;}

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
				window.location='Apply_ReduceComm_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
		    var win=window.showModalDialog("Apply_ReduceComm_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
					if(win=='success')
					    window.location="Apply_ReduceComm_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        if(idx!='2'&&idx!='3'&&idx!='4'&&idx!='5'&&idx!='6'&&idx!='7'){
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
		    i++;
		    var html = '<tr>'
                + '     <td><input type="text" id="txtDealDate' + i + '" style="width:90%"/></td>'
				+ '     <td><textarea id="txtDealAddress' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '     <td><textarea id="txtOriginalDealPrice' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '     <td><textarea id="txtFinalDealPrice' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '     <td><textarea id="txtCommPoint' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '     <td><textarea id="txtOriginalComm' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '     <td><textarea id="txtReduceCashBonus' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '     <td><textarea id="txtReduceComm' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '     <td><textarea id="txtTotalReduce' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '     <td><textarea id="txtActualReportMoney' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '</tr>';

			$("#trTotal").before(html);
			$("#txtDealDate"+i).datepicker();
		}

		function deleteRow() {
			if (i > 1) {
			    $("#tbDetail tr:eq(" + i + ")").remove();
			    i--;
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
			<h1>减佣/让佣申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
			<table id="tbAround"  width='640px'>
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
									<td style="width: 70px;">让现金奖+让佣的总金额</td>
									<td style="width: 70px;">实际上数<br />金额</td>
								</tr>
							</thead>
							<%=SbHtml.ToString()%>
                            <tr id="trTotal">
								<td style="width: 90px;">以上总计</td>
								<td style="width: 180px;"><asp:TextBox ID="txtDealDepartment" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
								<td style="width: 70px;"><asp:TextBox ID="txtOriginalDealPrice" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
								<td style="width: 70px;"><asp:TextBox ID="txtFinalDealPrice" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
								<td style="width: 45px;"><asp:TextBox ID="txtCommPoint" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
								<td style="width: 70px;"><asp:TextBox ID="txtOriginalComm" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
								<td style="width: 60px;"><asp:TextBox ID="txtReduceCashBonus" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
								<td style="width: 60px;"><asp:TextBox ID="txtReduceComm" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
								<td style="width: 70px;"><asp:TextBox ID="txtTotalReduce" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
								<td style="width: 70px;"><asp:TextBox ID="txtActualReportMoney" runat="server" TextMode="MultiLine" Rows="2" style="width: 90%; overflow: hidden;"></asp:TextBox></td>
							</tr>
						</table>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
					</td>
				</tr>
                <tr>
                    <td class="tl PL10">
						以上减佣/让佣
					</td>
					<td class="tl PL10" colspan="3">
                        <asp:RadioButton ID="rdbReduceWay1" runat="server" Text="从发展商佣金中扣除" GroupName="ReduceWay" />
                        <asp:RadioButton ID="rdbReduceWay2" runat="server" Text="从电商佣金中扣除" GroupName="ReduceWay" />
                        <asp:RadioButton ID="rdbReduceWay3" runat="server" Text="折让现金给客户" GroupName="ReduceWay" />
					</td>
				</tr>
                <tr>
					<td class="tl PL10" colspan="4">
						让佣原因说明：<br/>
						<asp:textbox id="txtReason" runat="server" TextMode="MultiLine" Width="98%" Rows="10" style="overflow: auto;"></asp:textbox>
					</td>
				</tr>
				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td >部门负责人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td rowspan="2" >法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx3" type="radio" name="agree3"/><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;"> 
					<td rowspan="3" >财务部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label>
                        <asp:CheckBox ID="ckbAddIDx" runat="server" Text="增加审批环节"  Visible="false"/><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
				<tr>
					<td colspan="3" class="tl PL10" style=" ">
					    <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
                    </td>
				</tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
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
	<%=SbJs.ToString() %>
</asp:Content>

