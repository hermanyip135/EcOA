<%@ Page ValidateRequest="false" Title="超成数备案 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_NetSign_Detail.aspx.cs" Inherits="Apply_NetSign_Apply_NetSign_Detail" %>

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
		  
		    $("#<%=txtPrice.ClientID%>").blur(function () {
		        AutoC();
		    });
		    $("#<%=txtDealPrice.ClientID%>").blur(function () {
		        AutoC();
		    });
		    if($("#<%=txtPrice.ClientID%>").val()!="" && $("#<%=txtDealPrice.ClientID%>").val()!=""){
		        AutoC();
		    }
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

        function AutoC(){
            var dd = ($("#<%=txtPrice.ClientID%>").val()-$("#<%=txtDealPrice.ClientID%>").val()) / $("#<%=txtDealPrice.ClientID%>").val();
            if($("#<%=txtPrice.ClientID%>").val()!=""&&$("#<%=txtDealPrice.ClientID%>").val()!=""&&dd<0) 
            {
                alert("网签价格低于双方约价格，非超成数，请检查！")
            }
            dd = (dd * 100).toFixed(2);
            if(!isNaN(dd) && dd != "Infinity" &&dd != "-Infinity" && dd != "NaN"){
                $("#<%=HidAutoN.ClientID%>").val(dd);
                $("#lbAutoCoculate").html(dd + "%");
            }
            else{
                $("#lbAutoCoculate").html(0);
                $("#<%=HidAutoN.ClientID%>").val(0);
            }
            $("#<%=HidAutoC.ClientID%>").val($("#lbAutoCoculate").html());
            //return dd;
        }

        function check() {
	        if($.trim($("#<%=txtHHManage.ClientID %>").val())=="") {
	            alert("汇瀚业务经办不可为空！");
	            $("#<%=txtHHManage.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtBudingAddress.ClientID %>").val())=="") {
	            alert("物业地址不可为空！");
	            $("#<%=txtBudingAddress.ClientID %>").focus();
	            return false;
	        }
			
	        if($.trim($("#<%=txtTakeBranch.ClientID %>").val())=="") {
	            alert("承接分行不可为空！");
	            $("#<%=txtTakeBranch.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtZYFollows.ClientID %>").val())=="") {
	            alert("中原跟进营业员不可为空！");
	            $("#<%=txtZYFollows.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtSendBank.ClientID %>").val())=="") {
	            alert("送审银行不可为空！");
	            $("#<%=txtSendBank.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBorrower.ClientID %>").val())=="") {
	            alert("借款人姓名不可为空！");
	            $("#<%=txtBorrower.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtPrice.ClientID %>").val())=="") {
	            alert("网签价格不可为空！");
	            $("#<%=txtPrice.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtDealPrice.ClientID %>").val())=="") {
                alert("分行成交双方约价格不可为空！");
	            $("#<%=txtDealPrice.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtSpace.ClientID %>").val())=="") {
                alert("房屋面积不可为空！");
                $("#<%=txtSpace.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtLoan.ClientID %>").val())=="") {
                alert("贷款额不可为空！");
                $("#<%=txtLoan.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtCompany1.ClientID %>").val())=="") {
                alert("评估公司1不可为空！");
                $("#<%=txtCompany1.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtAssessment1.ClientID %>").val())=="") {
                alert("评估价1不可为空！");
                $("#<%=txtAssessment1.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtCompany2.ClientID %>").val())=="") {
                alert("评估公司2不可为空！");
                $("#<%=txtCompany2.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtAssessment2.ClientID %>").val())=="") {
                alert("评估价2不可为空！");
                $("#<%=txtAssessment2.ClientID %>").focus();
                return false;
            }

            ///2016/9/23-52100
            
            //if($.trim($("#<%=txtCompany3.ClientID %>").val())=="") {
            //    alert("评估公司3不可为空！");
            //    $("#<%=txtCompany3.ClientID %>").focus();
           //     return false;
           // }

          //  if($.trim($("#<%=txtAssessment3.ClientID %>").val())=="") {
          //      alert("评估价3不可为空！");
          //      $("#<%=txtAssessment3.ClientID %>").focus();
          //      return false;
         //   }
            ///end
            if($.trim($("#<%=txtDescribe.ClientID %>").val())=="") {
                alert("申请说明原因不可为空！");
                $("#<%=txtDescribe.ClientID %>").focus();
                return false;
            }
            if (isNaN($("#<%=txtPrice.ClientID%>").val())) {
                alert("网签价格必须输入纯数字");
                $("#<%=txtPrice.ClientID%>").focus();
                    return false;
            }
            if (isNaN($("#<%=txtDealPrice.ClientID%>").val())) {
                alert("分行成交双方约价格必须输入纯数字");
                $("#<%=txtDealPrice.ClientID%>").focus();
                    return false;
            }
            if($("#<%=txtPrice.ClientID%>").val()!=""&&$("#<%=txtDealPrice.ClientID%>").val()!=""&&($("#<%=txtPrice.ClientID%>").val() - $("#<%=txtDealPrice.ClientID%>").val())<0) 
            {
                alert("网签价格低于双方约价格，非超成数，请检查！");
                $("#<%=txtPrice.ClientID%>").focus();
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
		            window.location='Apply_NetSign_Detail.aspx?MainID=<%=MainID %>';
		    }
		}

		function editflow(){
			var win=window.showModalDialog("Apply_NetSign_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_NetSign_Detail.aspx?MainID=<%=MainID %>";
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
        <%--<asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />--%>
		</div>
        <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>超成数备案</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
                <tr id="HeadA" style="display:none;">
                    <td colspan="4" class="tl PL10">
                        <a id="AUpload" href="javascript:void(0)" onclick="upload();" style="margin-bottom: 5px; margin-left: 5px;">附加文件</a>
                      　<a id="ACheck" href="javascript:void(0)" onclick="if(check()){alert('填写没有错误'); return true;}" style="margin-bottom: 5px; margin-left: 5px;">拼写检查...</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="tl PL10">申请类型<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:DropDownList ID="ddlKindOfApply" runat="server">
                            <asp:ListItem Value="超成数10%（含）以下备案">超成数10%（含）以下备案</asp:ListItem>
                            <asp:ListItem Value="超成数10%（不含）以上备案">超成数10%（不含）以上备案</asp:ListItem>
                        </asp:DropDownList>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">案号</td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtApplyID" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">分部名<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:DropDownList ID="ddlDepartment" runat="server">
                            <asp:ListItem Value="业务一分部">业务一分部</asp:ListItem>
                            <asp:ListItem Value="业务二分部">业务二分部</asp:ListItem>
                            <asp:ListItem Value="业务三分部">业务三分部</asp:ListItem>
                            <asp:ListItem Value="业务四分部">业务四分部</asp:ListItem>
                            <asp:ListItem Value="业务五分部">业务五分部</asp:ListItem>
                            <asp:ListItem Value="番禺分部">番禺分部</asp:ListItem>
                            <asp:ListItem Value="业务六分部">业务六分部</asp:ListItem>
                            <asp:ListItem Value="业务八部">业务八部</asp:ListItem>
                            <asp:ListItem Value="业务九部">业务九部</asp:ListItem>
                            <asp:ListItem Value="业务十部">业务十部</asp:ListItem>
                        </asp:DropDownList>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">汇瀚业务经办<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtHHManage" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">物业地址<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtBudingAddress" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">承接分行<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtTakeBranch" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">中原跟进营业员<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtZYFollows" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">送审银行<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtSendBank" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">借款人姓名<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtBorrower" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">网签价格<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtPrice" runat="server" Width="30%"></asp:textbox>（必须填写纯数字）
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">分行成交双方约价格<span style="color: #FF0000">*</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtDealPrice" runat="server" Width="30%"></asp:textbox>（必须填写纯数字）
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">房屋面积<span style="color: #FF0000">*</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtSpace" runat="server" Width="30%"></asp:textbox>（必须填写纯数字）
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">自动计算超出比例</td>
                    <td colspan="2" class="tl PL10">
                        <div id="lbAutoCoculate"></div>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">贷款额<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtLoan" runat="server" Width="30%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">评估公司1<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtCompany1" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">评估价1<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtAssessment1" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">评估公司2<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtCompany2" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10">评估价2<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtAssessment2" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr style="display:none">
                    <td colspan="2" class="tl PL10">评估公司3<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtCompany3" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr style="display:none">
                    <td colspan="2" class="tl PL10">评估价3<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtAssessment3" runat="server" Width="95%"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="2" class="tl PL10" style="vertical-align: top; padding-top: 10px;">申请说明原因<span style="color: #FF0000">&nbsp;*&nbsp;</span></td>
                    <td colspan="2" class="tl PL10">
                        <asp:textbox id="txtDescribe" runat="server" Width="95%" TextMode="MultiLine" Height="100px"></asp:textbox>
                    </td>
				</tr>
                <tr>
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 350px;">填写日期：<asp:Label ID="lblApplyDate" runat="server"></asp:Label></span>
                    </td>
                </tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style2">客户经理</td>
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
					<td class="auto-style2">业务经理</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px; display:none">
					<td class="auto-style2">营运总经理</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
					</td>
				</tr>
                <tr id="trManager20" class="noborder" style="height: 85px; display:none">
					<td class="auto-style2">首席运营官</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx20" type="radio" name="agree20" /><label for="rdbYesIDx20">同意</label><input id="rdbNoIDx20" type="radio" name="agree20" /><label for="rdbNoIDx20">不同意</label><br />
						<textarea id="txtIDx20" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx20" value="签名" onclick="sign('20')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx20">_________</span>
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
		<hr />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
<%--		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />--%>
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
            <asp:hiddenfield id="HidAutoC" runat="server" />
            <asp:hiddenfield id="HidAutoN" runat="server" />
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

