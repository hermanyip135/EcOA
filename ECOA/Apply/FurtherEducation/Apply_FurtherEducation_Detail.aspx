<%@ Page ValidateRequest="false" Title="进修津贴申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_FurtherEducation_Detail.aspx.cs" Inherits="Apply_FurtherEducation_Apply_FurtherEducation_Detail" %>

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

		     

		    i = $("#tbDetail tr").length - 1;
		    for (var x = 1; x < i; x++) {
		        $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    }

		    $("#<%=txtInData.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    $("#<%=txtOnData.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    $("#<%=txtIDData.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    $("#<%=txtBeginData.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    $("#<%=txtEndData.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    $("#<%=txtAllowData.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    for (var x = 1; x <= i; x++) {
		        $("#txtPropertyDate" + x).datepicker({ //使详情表的日期变得可选
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
	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("资格证号码不可为空！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("部门/分行不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }
			
	        if($.trim($("#<%=txtNo.ClientID %>").val())=="") {
	            alert("工号不可为空！");
	            $("#<%=txtNo.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtInData.ClientID %>").val())=="") {
	            alert("入职日期不可为空！");
	            $("#<%=txtInData.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtOnData.ClientID %>").val())=="") {
	            alert("通过试用日期不可为空！");
	            $("#<%=txtOnData.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtPosition.ClientID %>").val())=="") {
	            alert("职位不可为空！");
	            $("#<%=txtPosition.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtRank.ClientID %>").val())=="") {
	            alert("职级不可为空！");
	            $("#<%=txtRank.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtSrecord.ClientID %>").val())=="") {
	            alert("最高学历不可为空！");
	            $("#<%=txtSrecord.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtIDData.ClientID %>").val())=="") {
	            alert("出证日期不可为空！");
	            $("#<%=txtIDData.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtSchool.ClientID %>").val())=="") {
	            alert("学校名称不可为空！");
	            $("#<%=txtSchool.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtSubjects.ClientID %>").val())=="") {
	            alert("进修科目不可为空！");
	            $("#<%=txtSubjects.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBeginData.ClientID %>").val())=="") {
	            alert("开课日期不可为空！");
	            $("#<%=txtBeginData.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtDuring.ClientID %>").val())=="") {
	            alert("进修期限不可为空！");
	            $("#<%=txtDuring.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtEndData.ClientID %>").val())=="") {
	            alert("预计毕业日期不可为空！");
	            $("#<%=txtEndData.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtFees.ClientID %>").val())=="") {
	            alert("本年度培训费/学费不可为空！");
	            $("#<%=txtFees.ClientID %>").focus();
	            return false;
	        }

	        if (!$("#<%=rdbWelfare1.ClientID %>").prop("checked") && !$("#<%=rdbWelfare2.ClientID %>").prop("checked")) {
	            alert("请选择本年度是否曾使用该福利");
	            return false;
	        }





	        //var data = "";
	        ////如果详细只有一行，且该行个人资料为空
	        ////if($("#tbDetail tr").size() == 2 && $.trim($("#txtCountOffTime1").val()) == "" && $.trim($("#txtDealNo1").val()) == "" && $.trim($("#txtOtherDataAddress1").val()) == "" && $.trim($("#txtChangeSituation1").val()) == "" && $.trim($("#txtChangeReason1").val()) == "")
	        ////    data="||";
	        //$("#tbDetail tr").each(function(n) {
	        //    if (n != 0 && n != $("#tbDetail tr").size()) {
	        //        data += $.trim($("#txtProperty" + n).val()) + "&&" + $.trim($("#txtControler" + n).val()) + "&&" + $.trim($("#txtPropertyID" + n).val()) +"&&" + $.trim($("#txtPropertyDate" + n).val()) + "&&" + $.trim($("#txtOldDeal" + n).val()) + "&&" + $.trim($("#txtNewDeal" + n).val()) + "&&" + $.trim($("#txtAjustDeal" + n).val()) + "&&" + $.trim($("#txtShouldComm" + n).val()) + "&&" + $.trim($("#txtActualComm" + n).val()) + "&&" + $.trim($("#txtAjustComm" + n).val()) + "&&"+ ($("#rdoApplyType" + n + "1").prop('checked')?"1":"0") + "&&" + $.trim($("#txtCommitment" + n).val()) + "&&" + $.trim($("#txtChangeReason" + n).val()) + "||";
	        //    }
	        //});
	        //data = data.substr(0, data.length - 2);
	        //$("#<%=hdDetail.ClientID %>").val(data);
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
				window.location='Apply_FurtherEducation_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
			var win=window.showModalDialog("Apply_FurtherEducation_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_FurtherEducation_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx!='10'&&idx!='11'&&idx!='12'){
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

		function getEmployee(n) {//*-
		    $.ajax({
		        url: "/Ajax/HR_Handler.ashx",
		        type: "post",
		        dataType: "text",
		        data: "action=getEmployee&code=" + n.value,
		        success: function (info) {
		            if (info != "fail") {
		                var infos = info.split("|");
                        $("#<%=txtName.ClientID%>").val(infos[1]);
                        $("#<%=txtDepartment.ClientID%>").val(infos[2]);
		                $("#<%=hdDepartmentID.ClientID%>").val(infos[3]);

		                $("#<%=txtInData.ClientID%>").val(infos[6]);
		                $("#<%=txtOnData.ClientID%>").val(infos[7]);
		                $("#<%=txtPosition.ClientID%>").val(infos[4]);
		                $("#<%=txtRank.ClientID%>").val(infos[5]);
                    }
                    else {
                        $("#<%=txtDepartment.ClientID%>").val("");
		                $("#<%=hdDepartmentID.ClientID%>").val("");

		                $("#<%=txtName.ClientID%>").val("");
		                $("#<%=txtInData.ClientID%>").val("");
		                $("#<%=txtOnData.ClientID%>").val("");
		                $("#<%=txtPosition.ClientID%>").val("");
		                $("#<%=txtRank.ClientID%>").val("");
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
    <style type="text/css">
        @media   print   {   
            body   {   font-size:   12px}   
        }   
        .auto-style1 {
            width: 20%;
        }
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
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
			<h1>进修津贴申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
				<tr>
                    <td colspan="4" style="text-align: left; padding-left: 10px; font-weight: bold;">申请人资料（由申请人填写）<%--<asp:Label ID="lblApply" runat="server"></asp:Label>--%></td>
				</tr>
                <tr>
					<td>姓名</td>
					<td class="tl PL10" >
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
					<td style="width: 20%; ">工号</td>
					<td class="tl PL10"><asp:textbox id="txtNo" runat="server" onblur="getEmployee(this);"></asp:textbox></td>
				</tr>
				<tr>
                    <td>部门/分行</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
                    <td>发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
				<tr>
                    <td >入职日期</td>
					<td class="tl PL10"><asp:textbox id="txtInData" runat="server"></asp:textbox></td>
					<td >通过试用日期</td>
					<td class="tl PL10"><asp:textbox id="txtOnData" runat="server"></asp:textbox></td>
				</tr>
                <tr>
                    <td>职　　位</td>
                    <td class="tl PL10"><asp:textbox id="txtPosition" runat="server"></asp:textbox></td>
                    <td>职　　级</td>
					<td class="tl PL10"><asp:textbox id="txtRank" runat="server"></asp:textbox></td>
                </tr>
                <tr>
                    <td>目前最高学历</td>
                    <td class="tl PL10"><asp:textbox id="txtSrecord" runat="server"></asp:textbox></td>
                    <td>本年度是否曾使用该福利</td>
					<td class="tl PL10">
                        <asp:RadioButton ID="rdbWelfare1" runat="server" Text="是" GroupName="Welfare" Checked="True" />
                        <asp:RadioButton ID="rdbWelfare2" runat="server" Text="否" GroupName="Welfare"  />
					</td>
                </tr>
                <tr>
                    <td>资格证号码</td>
                    <td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
                    <td>出证日期</td>
					<td class="tl PL10"><asp:textbox id="txtIDData" runat="server"></asp:textbox></td>
                </tr>


                
				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 20px; text-align: left;">
                        <span style="font-weight: bolder">进修资料（由申请人填写）</span><br />
                        学校名称：<asp:textbox id="txtSchool" runat="server" Width="480px"></asp:textbox><br />
                        进修科目：<asp:textbox id="txtSubjects" runat="server" Width="335px"></asp:textbox>
                        开课日期：<asp:textbox id="txtBeginData" runat="server" Width="78px"></asp:textbox><br />
                        进修期限：<asp:textbox id="txtDuring" runat="server" Width="120px"></asp:textbox>
                        预计毕业日期：<asp:textbox id="txtEndData" runat="server" Width="70px"></asp:textbox>
                        本年度培训费/学费：<asp:textbox id="txtFees" runat="server" Width="81px"></asp:textbox>
                    </td>
				</tr>

				<tr id="trM1" class="noborder" style=" border: 1px solid #000000;">
					<td class="auto-style1" style="border-right-style: solid; border-right-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;"><span style="vertical-align: middle">部门/分行主管</span></td>
					<td class="tl PL10" style="vertical-align: top; border-right-style: solid; border-right-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;">
						意见：<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 90%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <div style="text-align: right; padding-right: 5px; vertical-align: bottom; border-bottom-width: 5px;">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
                    <td class="auto-style1" style="border-right-style: solid; border-right-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;"><span style="vertical-align: middle">部门负责人</span></td>
					<td class="tl PL10" style="vertical-align: top; border-right-style: solid; border-right-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;">
						意见：<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 90%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <div style="text-align: right;  padding-right: 5px; vertical-align: bottom; border-bottom-width: 5px;">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
                
                <tr class="noborder" >
                    <td colspan="4" style="font-weight: bold">本人同意在领取进修津贴当天起一 年内继续为公司服务，若在一年内离职或被公司辞退则按比例扣减。</td>
                </tr>

                <tr id="tr02" class="noborder">
					<td colspan="2"><asp:Label ID="lblApply" runat="server" Visible="false"></asp:Label></td>
                    <td colspan="2">申请日期：<asp:Label ID="lbADate" runat="server" Text="Label"></asp:Label></td>
				</tr>


                <tr>
					<td class="tl PL10" colspan="4" style="line-height: 20px; text-align: left;">
                        <span style="font-weight: bolder">企业培训部审批（由培训部填写）</span><br />
                        
                        本年度可享受津贴：<asp:textbox id="txtShouldAllowance" runat="server" Width="80px"></asp:textbox>　
                        申请津贴：<asp:textbox id="txtApplyAllowance" runat="server" Width="80px"></asp:textbox>　
                        实际享受津贴：<asp:textbox id="txtActualyAllowance" runat="server" Width="80px"></asp:textbox><br />
                        符合申请条件：<asp:RadioButton ID="rdbConditions1" runat="server" GroupName="Conditions" Text="是" />
                                      <asp:RadioButton ID="rdbConditions2" runat="server" GroupName="Conditions" Text="否" />
                        　　　　发放时间：<asp:textbox id="txtAllowData" runat="server" Width="85px"></asp:textbox><br />
                    </td>
                </tr>



                <tr id="trM2" class="noborder" style="height: 85px;">
					<td class="auto-style1" style="border-right-style: solid; border-right-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;">培训部审批人</td>
					<td class="tl PL10" style="vertical-align: top; border-right-style: solid; border-right-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;">意见：
						<input id="rdbYesIDx3" type="radio" name="agree3" />
                        <label for="rdbYesIDx3">同意</label>
                        <input id="rdbNoIDx3" type="radio" name="agree3" />
                        <label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 90%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <div style="text-align: right;  padding-right: 5px; vertical-align: bottom; border-bottom-width: 5px;">日期：<span id="spanDateIDx3">_________</span></div>
					</td>

                    <td class="auto-style1" style="border-right-style: solid; border-right-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;">培训部负责人</td>
					<td class="tl PL10" style="vertical-align: top; border-right-style: solid; border-right-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;">意见：
						<input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 90%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" />
                        <div style="text-align: right;  padding-right: 5px; vertical-align: bottom; border-bottom-width: 5px;">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>

                <tr>
                    <td colspan="4">
                        <span style="vertical-align: top">备注：</span>
                        <asp:textbox id="txtRemark" runat="server" Width="535px" Height="50px" TextMode="MultiLine"></asp:textbox>
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

