<%@ Page ValidateRequest="false" Title="营运部门自组织外出活动申请 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Tourism_Detail.aspx.cs" Inherits="Apply_Tourism_Apply_Tourism_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;
        var isUploaded = 0;
        var isNewApply=('<%=IsNewApply%>'=='True');

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
		function split( val ) {
		    return val.split( /,\s*/ );
		}
		function extractLast( term ) {
		    return split( term ).pop();
		}
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
		    $("#<%=txtActivityData.ClientID%>").datepicker();
		    $("#<%=txtActivityEndData.ClientID%>").datepicker();
		    $("#<%=txtHeaderIDx3.ClientID %>").autocomplete({ 
		        //source: jManagerJSON,
		        //select: function( event, ui ) {}
		        minLength: 0,
		        source: function( request, response ) {
		            $.ajax({
		                url: "/Ajax/AutoCompLete.ashx",
		                dataType: "json",
		                data: {
		                    EmpName:$("#<%=txtHeaderIDx3.ClientID %>").val()
                        },
                        success: function(data) {
                            response(data);
                        }
                    });

                },
		         focus: function() {
		             // prevent value inserted on focus
		             return false;
		         },
		         select: function( event, ui ) {
		             var terms = split( this.value );
		             // remove the current input
		             terms.pop();
		             // add the selected item
		             terms.push( ui.item.value );
		             // add placeholder to get the comma-and-space at the end
		             terms.push( "" );
		             this.value = terms.join( "," );
		             return false;
		         }
		     });
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});
       

        function check() {
            if(isUploaded < 3 && isNewApply)
            {
                alert("请先上传行程安排,人身旅游意外险以及外出人员为附件，才可以提交申请！");
                return false;
            }

            if($.trim($("#<%=ddlArea.ClientID %>").val())=="请选择") {
                alert("请选择活动地点！");
                $("#<%=ddlArea.ClientID %>").focus();
                return false;
            }

	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("资格证号码不可为空！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }

            if($.trim($("#<%=txtOrganizer.ClientID %>").val())=="") {
                alert("活动组织者不可为空！");
                $("#<%=txtOrganizer.ClientID %>").focus();
	            return false;
            }
	        
            if($("#<%=ddlDepartment.ClientID%>").val() == "") {
                alert("部门必须选择。");
                $("#<%=ddlDepartment.ClientID%>").focus();
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
	            alert("自组织外出活动原因不可为空！");
	            $("#<%=txtReason.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtActivityData.ClientID %>").val())=="") {
	            alert("活动开始时间不可为空！");
	            $("#<%=txtActivityData.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtActivityEndData.ClientID %>").val())=="") {
	            alert("活动结束时间不可为空！");
	            $("#<%=txtActivityEndData.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtActivityPlace.ClientID %>").val())=="") {
                alert("具体地点不可为空！");
	            $("#<%=txtActivityPlace.ClientID %>").focus();
	            return false;
            }



	        if (!$("#<%=rdbOperating1.ClientID %>").prop("checked") && !$("#<%=rdbOperating2.ClientID %>").prop("checked")) {
	            alert("请选择外出当天分行是否运营");
	            $("#<%=rdbOperating1.ClientID%>").focus();
	            return false;
	        }

	        if ($("#<%=rdbOperating1.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtOperatingArrange.ClientID%>").val()) == "") { 
	                alert("由于您选了外出当天分行是在运营，请填写运营安排。"); 
	                $("#<%=txtOperatingArrange.ClientID%>").focus(); 
	                return false; 
                }
	        }

	        if (!$("#<%=rdbAttendance1.ClientID %>").prop("checked") && !$("#<%=rdbAttendance2.ClientID %>").prop("checked") && !$("#<%=rdbAttendance3.ClientID %>").prop("checked")) {
	            alert("请选择考勤处理方式");
	            $("#<%=rdbAttendance1.ClientID%>").focus();
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
		    var sReturnValue = window.showModalDialog("Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue!=null)
		    {
		        if(isNewApply)
		        {
		            isUploaded += 1;

		            if(isUploaded == 1)
		            {
		                $("#spm").html("您已上传了：<br />" + sReturnValue + "<br />");
		            }
		            else if(isUploaded == 2)
		            {
		                $("#spm").append(sReturnValue + "<br />现在可以保存了。");
		            }
		        }
		        else
		            window.location='Apply_Tourism_Detail.aspx?MainID=<%=MainID %>';
		    }
		}

		function editflow(){
			var win=window.showModalDialog("Apply_Tourism_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_Tourism_Detail.aspx?MainID=<%=MainID %>";
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
	            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
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
		function DeleteT() { //20141231：M_DeleteC
		    $("#btnADelete").hide();
		    var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
		    if(sReturnValue=='deleted')
		        window.location='/Apply/Apply_Search.aspx';
		    else
		        window.location.href=window.location.href;
		}

        function ActivityDataOnblur(){
            alert(1)
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
			<h1>营运部门自组织外出活动申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
                <tr>
                    <td>发文部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" Visible="false" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />

                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="150px"></asp:DropDownList>
                    </td>
					<td class="auto-style2">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
				</tr>
				<tr>
                    <td>发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                    <td>回复电话</td>
					<td class="tl PL10"><asp:textbox id="txtReplyPhone" runat="server"></asp:textbox></td>
				</tr>
                  <tr>
                    <td>活动组织者</td>
                    <td colspan="3" class="tl PL10"><asp:textbox id="txtOrganizer" runat="server" Width="150px"></asp:textbox></td>
				</tr>
				<tr>
                    <td>文件主题</td>
                    <td colspan="3" class="tl PL10"><asp:textbox id="txtSubject" runat="server" Width="460px"></asp:textbox></td>
				</tr>
        
				<tr>
                    <td style="vertical-align: top; padding-top: 15px;">申请内容</td>
                    <td colspan="3" style="padding: 5px; text-align: left; line-height: 30px;">
                        自组织外出活动原因<br />
                        <asp:textbox id="txtReason" runat="server" Width="515px" Height="68px" TextMode="MultiLine"></asp:textbox><br />
                        活动时间：<asp:textbox id="txtActivityData"      runat="server"></asp:textbox>至<asp:textbox id="txtActivityEndData" runat="server"></asp:textbox>
                         &nbsp &nbsp  共  <asp:Label runat="server" id="txtday"> </asp:Label> 天
                        <br />  
                       
                        活动地点：<asp:DropDownList ID="ddlArea" runat="server" Width="100px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>天河区</asp:ListItem>
                            <asp:ListItem>海珠区</asp:ListItem>
                            <asp:ListItem>荔湾区</asp:ListItem>
                            <asp:ListItem>越秀区</asp:ListItem>
                            <asp:ListItem>白云区</asp:ListItem>
                            <asp:ListItem>黄埔区</asp:ListItem>
                            <asp:ListItem>番禺区</asp:ListItem>
                            <asp:ListItem>花都区</asp:ListItem>
                            <asp:ListItem>从化区</asp:ListItem>
                            <asp:ListItem>增城区</asp:ListItem>
                            <asp:ListItem>广州市外</asp:ListItem>
                        </asp:DropDownList>　具体地点：<br />
                        <asp:textbox id="txtActivityPlace" runat="server" Width="98%" TextMode="MultiLine" Height="50px"></asp:textbox><br />
                        行程安排：（请直接上传附件）<br />
                        外出人员：（请直接上传附件）<br />
                        人身旅游意外险:（请直接上传附件）<br />
                        <span style="font-weight: bold">注：外出人员名单请包含：分行/组别、姓名、工号、联系电话。</span><br />
                        <div id="oldview" runat="server" style="display:none">
                        是否购买人身旅游意外保险：<br />
                        <asp:RadioButton ID="rdbInsurance1" runat="server" GroupName="Insurance" Text="是" />
                        （外出必须购买保险，并上传单据作附件）<br />
                        <asp:RadioButton ID="rdbInsurance2" runat="server" GroupName="Insurance" Text="否" />
                        （请于下列方框中注明原因以及发生问题的责任承担及处理方法）<br />
                        <asp:textbox id="txtNoInsurance" runat="server" Width="510px"></asp:textbox><br />
                        </div>
                        外出当天分行是否运营：<br />
                        <asp:RadioButton ID="rdbOperating1" runat="server" GroupName="Operating" Text="是" />
                        （请于下列方框中注明外出期间分行的运营安排）<br />
                        <asp:textbox id="txtOperatingArrange" runat="server" Width="510px"></asp:textbox><br />
                        <asp:RadioButton ID="rdbOperating2" runat="server" GroupName="Operating" Text="否" /><br />
                        参与活动人员外出活动期间考勤作以下哪种方式处理：<br />
                        <asp:RadioButton ID="rdbAttendance1" runat="server" GroupName="Attendance" Text="年休假" />
                        <asp:RadioButton ID="rdbAttendance2" runat="server" GroupName="Attendance" Text="事假" />
                        <asp:RadioButton ID="rdbAttendance3" runat="server" GroupName="Attendance" Text="调休" /><br />
                        <span style="font-weight: bold">注：员工本人或部门/分行秘书需于外出前在考勤系统内登记假期情况，否则本次外出一律作违规处理。</span>
                    </td>
				</tr>
                <tr>
                    <td>其他情况说明</td>
                    <td colspan="3" class="tl PL10"><asp:textbox id="txtOtherMemo" TextMode="MultiLine" runat="server" Width="460px"  Height="40px" ></asp:textbox></td>
				</tr>
                <tr>
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 390px;">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style2">部门主管</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">其他意见</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style2">隶属主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style2">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label>
                        <input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                        <input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>

				<tr class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style2">人力资源部</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx4">_________</span>  &nbsp
                         
                          
                        </div>
                       <span id="addSpan"  style="display:none"> 添加<asp:TextBox ID="txtHeaderIDx3" runat="server" Width="200px"></asp:TextBox>审批</span>
                        <asp:Button  Text="确认" runat="server"   Visible="false" ID="addhq" OnClick="addhq_Click"/>
                         <%--<asp:Button  Text="增加董事总经理审核" runat="server"   Visible="true" ID="addhq" OnClick="addhq_Click"/>--%>
					</td>
				</tr>
				<%--<tr class="noborder" style="height: 85px;display:none">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/>
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>--%>

			    <tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S1"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>
                	<tr id="trOrder" class="noborder" style="height: 85px;display:none">
					<td class="auto-style2">其他部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label>
                        <input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label>
                        <input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
						<textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx10" value="签名" onclick="sign('10')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
					</td>
				</tr>
                <tr id="trl1" class="noborder" style="height:85px;display:none"> 
					<td rowspan="2" class="auto-style5" >后勤事务部</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx50" type="radio" name="agree50" /><label for="rdbYesIDx50">确认</label><input id="rdbNoIDx50" type="radio" name="agree50" /><label for="rdbNoIDx50">不同意</label>
                        　<input id="rdbOtherIDx50" type="radio" name="agree50" /><label for="rdbOtherIDx50">其他意见</label><br />
						<textarea id="txtIDx50" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx50" value="签署意见" onclick="sign('50')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx50">_________</span></div>
					</td>
				</tr>
				<tr id="trl2" class="noborder" style="height:85px;display:none">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx52" type="radio" name="agree52" /><label for="rdbYesIDx52">同意</label><input id="rdbNoIDx52" type="radio" name="agree52" /><label for="rdbNoIDx52">不同意</label>
                        <input id="rdbOtherIDx52" type="radio" name="agree52" /><label for="rdbOtherIDx52">其他意见</label><br />
						<textarea id="txtIDx52" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx52" value="签署意见" onclick="sign('52')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx52">_________</span></div>
					</td>
				</tr>

            <tr id="trGeneralManager" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style7" >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx100" type="radio" name="agree100" /><label for="rdbYesIDx100">同意</label><input id="rdbNoIDx100" type="radio" name="agree100" /><label for="rdbNoIDx100">不同意</label><input id="rdbOtherIDx100" type="radio" name="agree100" /><label for="rdbOtherIDx100">其他意见</label><br />
						<textarea id="txtIDx100" style="width: 98%; overflow: auto; height: 87px;"></textarea><input type="button" id="btnSignIDx100" value="签署意见" onclick="sign('100')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx100">_________</span></div>
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
        <span id ="spm"></span><br />

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

