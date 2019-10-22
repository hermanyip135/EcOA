<%@ Page ValidateRequest="false" Title="网络端口考核数据确认表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_PortAssessment_Detail.aspx.cs" Inherits="Apply_PortAssessment_Apply_PortAssessment_Detail" %>

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

		    i = $("#tbMenber tr").length - 2;
		    for (var x = 1; x <= i; x++) {
		        $("#txtMenber_GridGx"+ x).autocomplete({source: jJSON});
		    }

		    for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		        $("#txtMenber_GridKx" + x).datepicker();
		    }
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

	    function check() {
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("发文部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }

	        var data = "";
	        var flag = true;
	        var DATE_FORMAT = new RegExp("^(?:(?:([0-9]{4}(-|\/)(?:(?:0?[1,3-9]|1[0-2])(-|\/)(?:29|30)|((?:0?[13578]|1[02])(-|\/)31)))|([0-9]{4}(-|\/)(?:0?[1-9]|1[0-2])(-|\/)(?:0?[1-9]|1\\d|2[0-8]))|(((?:(\\d\\d(?:0[48]|[2468][048]|[13579][26]))|(?:0[48]00|[2468][048]00|[13579][26]00))(-|\/)0?2(-|\/)29))))$"); 
	        $("#tbMenber tr").each(function(n) {
	            if (n != 0 && n != $("#tbMenber tr").size()-1) {
	                if ($.trim($("#txtMenber_GridAx" + n).val()) == "") {
	                    alert("第" + n + "行的区域必须填写。");
	                    $("#txtMenber_GridAx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridBx" + n).val()) == "") {
	                    alert("第" + n + "行的所属总监必须填写。");
	                    $("#txtMenber_GridBx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridCx" + n).val()) == "") {
	                    alert("第" + n + "行的所属区经必须填写。");
	                    $("#txtMenber_GridCx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridDx" + n).val()) == "") {
	                    alert("第" + n + "行的姓名必须填写。");
	                    $("#txtMenber_GridDx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridEx" + n).val()) == "") {
	                    alert("第" + n + "行的工号必须填写。");
	                    $("#txtMenber_GridEx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridFx" + n).val()) == "") {
	                    alert("第" + n + "行的手机号必须填写。");
	                    $("#txtMenber_GridFx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridGx" + n).val()) == "") {
	                    alert("第" + n + "行的门店名称(组别）必须填写。");
	                    $("#txtMenber_GridGx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridHx" + n).val()) == "") {
	                    alert("第" + n + "行的发布优质房源数量必须填写。");
	                    $("#txtMenber_GridHx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridIx" + n).val()) == "") {
	                    alert("第" + n + "行的新增优质房源数量必须填写。");
	                    $("#txtMenber_GridIx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridJx" + n).val()) == "") {
	                    alert("第" + n + "行的房源点击量必须填写。");
	                    $("#txtMenber_GridJx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridKx" + n).val()) == "") {
	                    alert("第" + n + "行的首次开通日期必须填写。");
	                    $("#txtMenber_GridKx" + n).focus();
	                    flag = false;
	                }
	                else if (!DATE_FORMAT.test($("#txtMenber_GridKx" + n).val())) {
	                    alert("第" + n + "行的首次开通日期必须填写正确。");
	                    $("#txtMenber_GridKx" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtMenber_GridLx" + n).val()) == "") {
	                    alert("第" + n + "行的套餐类型必须填写。");
	                    $("#txtMenber_GridLx" + n).focus();
	                    flag = false;
	                }
	                //else if ($.trim($("#txtMenber_GridMx" + n).val()) == "") {
	                //    alert("第" + n + "行的安居客使用考核必须填写。");
	                //    $("#txtMenber_GridMx" + n).focus();
	                //    flag = false;
	                //}
	                else
	                    data += $.trim($("#txtMenber_GridAx" + n).val()) 
                            + "&&" + $.trim($("#txtMenber_GridBx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridCx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridDx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridEx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridFx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridGx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridHx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridIx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridJx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridKx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridLx" + n).val())
                            + "&&" + $.trim($("#txtMenber_GridMx" + n).val())
                            + "||";
	            }
	        });
	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdDetail.ClientID %>").val(data);
	            if(data!="" || $("#tbMenber tr").size() == 2)
                    return true;
                else 
	                return false;
            }
            else
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
		    var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
			if(sReturnValue=='success')
				window.location='Apply_PortAssessment_Detail.aspx?MainID=<%=MainID %>';
		}

        function uploadMenber() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_zDetailed_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
            $("#<%=hdFilePathMenber.ClientID%>").val(sReturnValue);
            return true;
        }

		function editflow(){
			var win=window.showModalDialog("Apply_PortAssessment_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_PortAssessment_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        if(idx=='1'||idx=='2'||idx=='3'||idx=='4'){
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
		    var html = '<tr id="trMenber' + i + '">'
				+ '         <td><input type="text" id="txtMenber_GridAx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridBx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridCx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridDx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridEx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridFx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridGx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridHx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridIx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridJx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridKx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridLx' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtMenber_GridMx' + i + '" style="width:50px"/></td>'
				+ '     </tr>';
		    //var html = '<tr id="trMenber' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
		    $("#trFlagMenber").before(html);
		    //$("#trFlagMenber").before("<tr><td>这是"+ i +"个</td></tr>");
		    $("#txtMenber_GridGx"+ i).autocomplete({source: jJSON});
		    $("#txtMenber_GridKx"+ i).datepicker();
		}//*-

		function deleteRow() {
		    if (i > 1) {
		        $("#tbMenber tr:eq(" + i + ")").remove();
		        i--;
			} else
		    	alert("不可删除第一行。");
		    //$("#tbMenber tr:eq(0)").remove();
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
	<div style='text-align: center; width: 1000px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>网络端口考核数据确认表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:1000px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='1000px'>
				<tr style="display: none">
					<td class="auto-style1">发文部门</td>
					<td colspan="3" class="tl PL10"><asp:textbox id="txtDepartment" runat="server" Width="490px"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
                </tr>
				<tr>
					<td class="tl PL10 PR10" colspan="4">
						<span style="font-weight: bolder">安居客考核数据表：</span><br />
						<table id="tbMenber" class='sample tc' width='100%'>

                            <thead>
                                <tr>
                                    <td>区域</td>
                                    <td>所属总监</td>
                                    <td>所属区经</td>
                                    <td>姓名</td>
                                    <td>工号</td>
                                    <td>手机号</td>
                                    <td>门店名称(组别）</td>
                                    <td>发布优质房源数量</td>
                                    <td>新增优质房源数量</td>
                                    <td>房源点击量</td>
                                    <td>首次开通日期</td>
                                    <td>套餐类型</td>
                                    <td>安居客使用考核</td>
                                </tr>
                            </thead>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlagMenber"><td></td></tr>

						</table>
                        <div id="divUploadMenber" style="display:none;">若明细表涉及的内容超过3项，请按此格式（<a href="../../资料/安居客考核数据表.xls">EXCEL版空白详细表</a>)下载，编辑后<asp:button id="btnUploadDetailed1" runat="server" text="上传" onclick="btnUploadMenber_Click" onclientclick="return uploadMenber();" style="margin-left: 5px;"/>为附件，将自动导入<input type="hidden" id="hdFilePathMenber" runat="server" /> </div>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
					</td>
				</tr>
                <tr style="display: none">
                    <td class="tl PL10">发文人员</td>
					<td><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td class="auto-style1">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr id="trManager7" class="noborder" style="height: 85px;">
					<td class="auto-style1">网络营销部</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签名" onclick="sign('7')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
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
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

