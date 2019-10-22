<%@ Page ValidateRequest="false" Title="社保公积金特殊缴纳申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_SocialSecurity_Detail.aspx.cs" Inherits="Apply_SocialSecurity_Apply_SocialSecurity_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        var isUploaded = false;
        var delF = ('<%=delF%>'=='True');

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

		$(function() {      
		    $("[id*=btnLoadPath]").css({
		        "background-image": "url(/Images/btnLoadPath1.png)",
		        "height": "25px", 
		        "width": "43px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnLoadPath]").mousedown(function () { $(this).css("background-image", "url(/Images/btnLoadPath2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnLoadPath1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnLoadPath1.png)"); });
            
		    $("[id*=btnSureS]").css({
		        "background-image": "url(/Images/btnSureS1.png)",
		        "height": "25px", 
		        "width": "43px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnSureS]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); });

			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});
		    $("#<%=txtSureTime.ClientID%>").datepicker();
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});
       

        function check() {
            //if(!isUploaded&&isNewApply)
            //{
            //    alert("须上传手写申请！");
            //    return false;
            //}
            if(!delF&&isNewApply){
                alert("请上传手写申请。");
                $("#<%=btnLoadPath.ClientID %>").focus();
                return false;
            }
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
			
	        if($.trim($("#<%=txtName.ClientID %>").val())=="") {
	            alert("姓名不可为空！");
	            $("#<%=txtName.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtCode.ClientID %>").val())=="") {
	            alert("工号不可为空！");
	            $("#<%=txtCode.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtEnterDate.ClientID %>").val())=="") {
	            alert("入职日期不可为空！");
	            $("#<%=txtEnterDate.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtPosition.ClientID %>").val())=="") {
	            alert("现职位不可为空！");
	            $("#<%=txtPosition.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("现任职部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtRank.ClientID %>").val())=="") {
                alert("现职级不可为空！");
                $("#<%=txtRank.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtDescribe.ClientID %>").val())=="") {
                alert("申请内容不可为空！");
                $("#<%=txtDescribe.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=ddlResults.ClientID%>").val())=="请选择") {
                alert("请选择申请类型！");
                $("#<%=ddlResults.ClientID %>").focus();
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
		    if(sReturnValue!=null){
		        if(isNewApply){
		            $("#spm").show();
		            $("#spm").append(sReturnValue + "；");
		            isUploaded = true;
		        }
		        else
		            window.location='Apply_SocialSecurity_Detail.aspx?MainID=<%=MainID %>';
		    }
		}

		function editflow(){
			var win=window.showModalDialog("Apply_SocialSecurity_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_SocialSecurity_Detail.aspx?MainID=<%=MainID %>";
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
	            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
	        //}
			
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
		function DeleteT() { //20141231：M_DeleteC
		    $("#btnADelete").hide();
		    var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
		    if(sReturnValue=='deleted')
		        window.location='/Apply/Apply_Search.aspx';
		    else
		        window.location.href=window.location.href;
		}
        function checkLoad() {
            if ($.trim($("#txtFilePath").val()) == '') {
                alert("请选择附件!");
                $("#txtFilePath").focus();
                return false;
            }
            return true;
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

		                $("#<%=txtEnterDate.ClientID%>").val(infos[6]);
		                $("#<%=txtPosition.ClientID%>").val(infos[4]);
		                $("#<%=txtRank.ClientID%>").val(infos[5]);
		            }
		            else {
		                $("#<%=txtDepartment.ClientID%>").val("");
		                $("#<%=hdDepartmentID.ClientID%>").val("");

		                $("#<%=txtName.ClientID%>").val("");
		                $("#<%=txtEnterDate.ClientID%>").val("");
		                $("#<%=txtPosition.ClientID%>").val("");
		                $("#<%=txtRank.ClientID%>").val("");
		            }
		        }
		    })
        }
	</script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
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
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>社保公积金特殊缴纳申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
			<table id="tbAround"  width='640px'>
                <tr>
                    <td>* 姓名</td>
                    <td class="tl PL10"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
					<td class="auto-style2">* 工号</td>
					<td class="tl PL10"><asp:textbox id="txtCode" runat="server" onblur="getEmployee(this);"></asp:textbox></td>
				</tr>
                <tr>
                    <td>* 入职日期</td>
					<td class="tl PL10"><asp:textbox id="txtEnterDate" runat="server"></asp:textbox></td>
                    <td>* 现任职部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
				</tr>
				<tr>
                    <td>* 现职位</td>
                    <td class="tl PL10"><asp:TextBox ID="txtPosition" runat="server"></asp:TextBox></td>
					<td>* 现职级</td>
					<td class="tl PL10"><asp:textbox id="txtRank" runat="server"></asp:textbox></td>
				</tr>
				<tr>
                    <td>* 发文编号</td>
                    <td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
                    <td>文档编码</td>
                    <td class="tl PL10"><span class="file_number"><%=SerialNumber %></span></td>
				</tr>
                <tr>
                    <td>温馨提醒</td>
                    <td class="tl PL10" colspan="3" style="line-height: 20px">
                        1、不存在劳动关系的月份不予缴纳社保及公积金；<br />
                        2、如需申请特殊补缴社保及公积金，请根据实际情况斟酌慎重提交申请；<br />
                        3、为了不影响公司社保公积金的工作进度，如需申请，请于每月10号前提交当月社保申请，每月30号前提交当月公积金申请；<br />
                        4、如对社保公积金事宜有任何疑问，请咨询人力资源部薪酬福利组。
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">申请类型</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:DropDownList ID="ddlResults" runat="server" Width="200px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>社保缴纳申请</asp:ListItem>
                            <asp:ListItem>公积金缴纳申请</asp:ListItem>
                            <asp:ListItem>公积金免缴申请</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="UploatPath">
                    <td class="tl PL10">* 附件</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        　　申请人手写申请情况说明并签名确认（申请人需承诺在申请审批通过后三个工作日内将全额费用以现金形式交到财务部）。<br />
                        <div style="margin-top: 10px; margin-bottom: 5px">
                            <asp:FileUpload ID="txtFilePath" runat="server" Width="275px" />　
                            <asp:Button ID="btnLoadPath" runat="server" Text="上 传" class="btn button" OnClick="btnLoadPath_Click" />
                            <%--<input type="button" id="btnLoadPath" value="上传" onclick="upload();" style="margin-left: 5px;" />--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; vertical-align: top" >* 申请内容</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:textbox id="txtDescribe" runat="server" TextMode="MultiLine" Width="98%" Height="200px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>填写人：</td>
                    <td><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td>填写日期：</td>
                    <td><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style2">隶属主管</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style2">部门主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
				<tr id="trmq">
					<td class="auto-style2">区域办公室</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style2">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>

				<tr class="noborder" style="height: 85px;">
					<td rowspan="3"  class="auto-style2">人力资源部</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label>　
                        全额费用为<asp:TextBox ID="txtMoney" runat="server"></asp:TextBox><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6"/>
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7"name="agree7" type="radio" value="1" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" name="agree7" type="radio" value="2" />
                        <label for="rdbNoIDx7">不同意</label><br />
                        <textarea id="txtIDx7" cols="20" name="S1" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" onclick="sign('7')" style="display: none;" type="button" value="签署意见" />
                        <div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
					</td>
				</tr>
                <tr id="trCcess" class="noborder" style="height: 30px;display:none">
					<td class="auto-style2">费用缴交确认</td>
					<td colspan="3" class="tl PL10">
                        <span id="trFinancial">
                            已于<asp:TextBox ID="txtSureTime" runat="server"></asp:TextBox>
                            将全额费用以现金形式上交给财务部。
                            <asp:Button ID="btnSureS" runat="server" Text="确认" OnClick="btnSureS_Click" />　
                        </span>　
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
            <span id ="spm" style="display: none">您已上传了：</span><br />
		<hr />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		
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
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

