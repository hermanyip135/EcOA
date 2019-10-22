<%@ Page ValidateRequest="false" Title="变更资料申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ChangeData_Detail.aspx.cs" Inherits="Apply_ChangeData_Apply_ChangeData_Detail" %>
<%@ Register src="../../Common/FlowShow.ascx" tagname="FlowShow" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

		$(function() {      
		    $("[id*=btnSign1Bad]").css({
		        "background-image": "url(/Images/btnSignBadA1.png)",
		        "height": "36px", 
		        "width": "130px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnSign1Bad]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSignBadA2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSignBadA1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSignBadA1.png)"); });

			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});

		    i = $("#tbDetail tr").length - 1;
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}

		    $("#<%=txtReasonDay.ClientID%>").datepicker();

		    for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		        $("#txtCountOffTime" + x).datepicker();
		    }
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

	    function check() {
	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("发文编号不可为空！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("发文部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }
			
	        if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {
	            alert("回复电话不可为空！");
	            $("#<%=txtReplyPhone.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBuilding.ClientID %>").val())=="") {
	            alert("楼盘单位不可为空！");
	            $("#<%=txtBuilding.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
	            alert("变更资料原因不可为空！");
	            $("#<%=txtReason.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtReasonDay.ClientID %>").val())=="") {
	            alert("变更资料日期不可为空！");
	            $("#<%=txtReasonDay.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtReportNo.ClientID %>").val())=="") {
	            alert("成交报告编号不可为空！");
	            $("#<%=txtReportNo.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtDataAddress.ClientID %>").val())=="") {
	            alert("物业地址不可为空！");
	            $("#<%=txtDataAddress.ClientID %>").focus();
	            return false;
            }

	        var data = "";
	        //如果详细只有一行，且该行个人资料为空
	        //if($("#tbDetail tr").size() == 2 && $.trim($("#txtCountOffTime1").val()) == "" && $.trim($("#txtDealNo1").val()) == "" && $.trim($("#txtOtherDataAddress1").val()) == "" && $.trim($("#txtChangeSituation1").val()) == "" && $.trim($("#txtChangeReason1").val()) == "")
	        //    data="||";
	        $("#tbDetail tr").each(function(n) {
	            if (n != 0 && n != $("#tbDetail tr").size()) {
	                data += $.trim($("#txtDetail_pNo" + n).html()) 
                        + "&&" + $.trim($("#txtCountOffTime" + n).val()) 
                        + "&&" + $.trim($("#txtDealNo" + n).val()) 
                        + "&&" + $.trim($("#txtOtherDataAddress" + n).val()) 
                        + "&&" + $.trim($("#txtChangeSituation" + n).val()) 
                        + "&&" + $.trim($("#txtChangeReason" + n).val()) 
                        + "&&" + $.trim($("#txtProjectName" + n).val()) 
                        + "&&" + $.trim($("#txtCname" + n).val()) 
                        + "&&" + $.trim($("#txtType" + n).val()) 
                        + "&&" + $.trim($("#txtChangeCname" + n).val()) 
                        + "||";
	            }
	        });
	        data = data.substr(0, data.length - 2);
	        $("#<%=hdDetail.ClientID %>").val(data);
	        //if(data!="")
	        //    return false;
	        //else 
	        //    return true;
			  

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
				window.location='Apply_ChangeData_Detail.aspx?MainID=<%=MainID %>';
		}

	    function uploadDetailed() {
	        var sReturnValue = window.showModalDialog("/Apply/Apply_zDetailed_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
        	        $("#<%=hdFilePath.ClientID%>").val(sReturnValue);
        	        return true;
        	    }

		function editflow(){
			var win=window.showModalDialog("Apply_ChangeData_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_ChangeData_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx!='10'&&idx!='11'&&idx!='12'&&idx!='13'){
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
                //+ '         <td class=\"tl PL10\" style="line-height: 30px">'
				//+ '             报数时间<input type="text" id="txtCountOffTime' + i + '" style="width:200px"/>'
				//+ '             成交编号<input type="text" id="txtDealNo' + i + '" style="width:245px"/><br />'
                //+ '             物业地址<input type="text" id="txtOtherDataAddress' + i + '" style="width:500px;"/><br />'
                //+ '             <span style="vertical-align: top;margin-top: 10px;">变更情况</span><textarea id="txtChangeSituation' + i + '" rows="3" style="width: 500px; overflow: auto;"></textarea><br />'
                //+ '             <span style="vertical-align: top;margin-top: 10px;">变更事由</span><textarea id="txtChangeReason' + i + '" rows="3" style="width: 500px;margin-top: 8px; overflow: auto;"></textarea><br />'
                //+ '         </td>'
                + '         <td><span id="txtDetail_pNo' + i + '">'+i+'</span></td>'
                + '         <td><textarea id="txtProjectName' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtCname' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><input type="text" id="txtCountOffTime' + i + '" style="width:90%"></td>'
                + '         <td><textarea id="txtDealNo' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtOtherDataAddress' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtChangeSituation' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtChangeCname' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                +  '         <td><textarea id="txtType' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtChangeReason' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'

				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
		    $("#trFlag").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
		    
		    $("#txtCountOffTime"+ i).datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });
		    i++;
		}//*-

		function deleteRow() {
		    if (i > 2) {
			    i--;
			    $("#tbDetail tr:eq(" + i + ")").remove();
			} else
		    	alert("不可删除第一行。");
		    //$("#tbDetail tr:eq(0)").remove();
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
        .auto-style1 {
            width: 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>变更资料申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td class="auto-style1">收文部门</td>
					<td class="tl PL10">财务部</td>
					<td class="tl PL10" style="width: 20%; ">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td class="auto-style1">发文部门</td>
					<td class="tl PL10"><asp:textbox id="txtDepartment" runat="server"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td class="tl PL10">发文人员</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td class="auto-style1">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                    <td class="tl PL10">回复电话</td>
					<td class="tl PL10">020-<asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
                    
				</tr>
				<tr>
					<td class="auto-style1">致：财务部 <br />部门：项目部销售组 <br />楼　盘</td>
					<td colspan="3" class="tl PL10" style="vertical-align: bottom"><asp:textbox id="txtBuilding" runat="server" Width="455px"></asp:textbox></td>
				</tr>
				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 30px">
                        <span style="font-weight: bolder">变更资料：</span><br />
						由于<asp:textbox id="txtReason" runat="server" Width="545px"></asp:textbox>原因，我部于<asp:textbox id="txtReasonDay" runat="server"></asp:textbox>
					    日对已报数成交报告编号<asp:textbox id="txtReportNo" runat="server" Width="230px"></asp:textbox><br />
                        物业地址：<asp:textbox id="txtDataAddress" runat="server" Width="545px"></asp:textbox>
                        <br />现作出以下调整：<br />
                        1.	原成交物业地址改为：<asp:textbox id="txtNewDataAddress" runat="server" Width="406px"></asp:textbox><br />
                        2.	客户更名或增减名：原客户姓名<asp:textbox id="txtOldCustomerName" runat="server" Width="165px"></asp:textbox>改为<asp:textbox id="txtNewCustomerName" runat="server" Width="165px"></asp:textbox><br />
                        3.	成交分行转换：原成交分行<asp:textbox id="txtOldBranch" runat="server" Width="176px"></asp:textbox>改为<asp:textbox id="txtNewBranch" runat="server" Width="176px"></asp:textbox><br />
                        <span style="vertical-align: top">4.	其它：</span><asp:textbox id="txtOthers" runat="server" Width="490px" Height="40px" TextMode="MultiLine"></asp:textbox><br />
                        注：1、上述项相应资料只需填写更改部份，不需更改部份可留空不填写<br />
                        　　2、如多个物业的，上述原因、编号、物业地址等请填写“详见附表”

                    </td>
				</tr>
				<tr>
					<td class="tl PL10 PR10" colspan="4">
						<span style="font-weight: bolder">变更资料明细表</span><br />
						<table id="tbDetail" class='sample tc' width='100%'>

                            <thead>                                
                                <tr>
                                    <td>序号</td>
                                    <td>项目名称</td>
                                    <td>客户姓名</td>
                                    <td>报数时间</td>
                                    <td>成交编号</td>
                                    <td>物业地址</td>
                                    <td>(变更后)</br>物业地址</td>
                                    <td>(变更后)</br>客户姓名</td>
                                     <td>成交类型</br>(独立/联动）</td>
                                    <td>变更事由</td>
                                </tr>
							</thead>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag"><td colspan="5"></td></tr>


						</table>
                        <div id="divUploadDetailed" style="display:none;">若明细表涉及的内容超过3项，请按此格式（<a href="../../资料/变更资料格式.xls">EXCEL版空白详细表</a>)下载，编辑后<asp:button id="btnUploadDetailed" runat="server" text="上传" onclick="btnUploadDetailed_Click" onclientclick="return uploadDetailed();" style="margin-left: 5px;"/>为附件，将自动导入<input type="hidden" id="hdFilePath" runat="server" /> </div>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
						<div style="clear:both;">备注：如只有一个单位的，只填写“变更资料”，不用重复填写明细表内容。</div>
					</td>
				</tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style1">营销总监1</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style1">营销总监2</td>
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
					<td class="auto-style1">事业部负责人</td>
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
					<td class="auto-style1">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
					</td>
				</tr>

                <tr id="trManager5" class="noborder" style="height: 85px;">
					<td class="auto-style1">销售中心负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签名" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
					</td>
				</tr>

                <tr id="trManager6" class="noborder" style="height: 85px;">
					<td class="auto-style1">二级市场总经理</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx6" value="签名" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
					</td>
				</tr>

<%--                <tr id="trManager7" class="noborder" style="height: 85px;">
					<td class="auto-style1">二级市场总经理</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label><br />
						<textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签名" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
					</td>
				</tr>--%>


				<tr class="noborder" style="height: 85px; display: none;">
					<td rowspan="2"  class="auto-style1">法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" />
                        <label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" />
                        <label for="rdbNoIDx8">不同意</label><br />
						<textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9"/>
                        <label for="rdbYesIDx9">同意</label>
                        <input id="rdbNoIDx9" type="radio" name="agree9" />
                        <label for="rdbNoIDx9">不同意</label><br />
						<textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
                        </span>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px; display: none;">
					<td rowspan="3"  class="auto-style1">财务部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" />
                        <label for="rdbYesIDx10">同意</label>
                        <input id="rdbNoIDx10" type="radio" name="agree10" />
                        <label for="rdbNoIDx10">不同意</label>
                        <input id="rdbOtherIDx10" type="radio" name="agree10" />
                        <label for="rdbOtherIDx10">其他意见</label>
                        <asp:CheckBox ID="ckbAddIDx10" runat="server" Text="增加审批环节"  Visible="false"/><br />
						<textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx10">_________</span>
                        </span>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx11" type="radio" name="agree11" />
                        <label for="rdbYesIDx11">同意</label>
                        <input id="rdbNoIDx11" type="radio" name="agree11" />
                        <label for="rdbNoIDx11">不同意</label>
                        <input id="rdbOtherIDx11" type="radio" name="agree11" />
                        <label for="rdbOtherIDx11">其他意见</label><br />
						<textarea id="txtIDx11" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx11">_________</span>
                        </span>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx12" type="radio" name="agree12" />
                        <label for="rdbYesIDx12">同意</label>
                        <input id="rdbNoIDx12" type="radio" name="agree12" />
                        <label for="rdbNoIDx12">不同意</label>
                        <input id="rdbOtherIDx12" type="radio" name="agree12" />
                        <label for="rdbOtherIDx12">其他意见</label><br />
						<textarea id="txtIDx12" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx12">_________</span>
                        </span>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;display: none;">
                    <td class="auto-style1">跟进人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx13" type="radio" name="agree13" />
                        <label for="rdbYesIDx13">同意</label>
                        <input id="rdbNoIDx13" type="radio" name="agree13" />
                        <label for="rdbNoIDx13">不同意</label>
                        <input id="rdbOtherIDx13" type="radio" name="agree13" />
                        <label for="rdbOtherIDx13">其他意见</label><br />
						<textarea id="txtIDx13" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx13" value="签署意见" onclick="sign('13')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx13">_________</span>
                        </span>
					</td>
				</tr>
<%--                <tr id="trLogistics1" class="noborder" style="height: 85px;display: none;">
					<td rowspan="2" style="border: 1px solid #000000;">后勤事务部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">确认</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">退回申请</label><br />
						<textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
					</td>
				</tr>
				<tr id="trLogistics2" class="noborder" style="height: 85px;display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><br />
						<textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
					</td>
				</tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; display: none;">
					<td style="border: 1px solid #000000;">董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label><br />
						<textarea id="txtIDx11" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx11">_________</span></div>
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
		<asp:button runat="server" id="btnSign1Bad" text="标注已更改" onclick="btnSignBad_Click" visible="false" />
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

