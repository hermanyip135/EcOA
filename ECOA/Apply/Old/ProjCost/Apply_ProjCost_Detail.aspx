<%@ Page ValidateRequest="false" Title="项目费用申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ProjCost_Detail.aspx.cs" Inherits="Apply_ProjCost_Apply_ProjCost_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;
	    var isUploaded = false;
	    var isNewApply=('<%=IsNewApply%>'=='True');

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

		$(function() {      
		    autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
		    autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));
		    $("[id*=btnsSignIDx]").css({
		        "background-image": "url(/Images/btnSureS1.png)",
		        "height": "25px", 
		        "width": "43px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnsSignIDx]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); });

			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});

		    $("#<%=txtAgencyBeginDate1.ClientID%>").datepicker();
		    $("#<%=txtAgencyBeginDate2.ClientID%>").datepicker();
		    $("#<%=txtAgencyEndDate1.ClientID%>").datepicker();
		    $("#<%=txtAgencyEndDate2.ClientID%>").datepicker();
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

	    function check() {
	        if(!isUploaded&&isNewApply)
	        {
	            alert("请先上传居间人身份证/名片作为附件，之后才可提交申请！");
                 return false;
	        }

	        if($("#<%=txtApplyForID.ClientID %>").val())
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

            if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {
	            alert("回复电话不可为空！");
	            $("#<%=txtReplyPhone.ClientID %>").focus();
	            return false;
            }
	                 
	        if($.trim($("#<%=txtProject.ClientID %>").val())=="") {
	            alert("项目名称不可为空！");
	            $("#<%=txtProject.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtDeveloper.ClientID %>").val())=="") {
	            alert("发展商不可为空！");
	            $("#<%=txtDeveloper.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtProjLeader.ClientID %>").val())=="") {
	            alert("项目负责人不可为空！");
	            $("#<%=txtProjLeader.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtProjBusiLeader.ClientID %>").val())=="") {
	            alert("项目拓展负责人不可为空！");
	            $("#<%=txtProjBusiLeader.ClientID %>").focus();
	            return false;
	        }

	        //20141027+
	        if (!$("#<%=rdbJOrT1.ClientID%>").prop("checked") && !$("#<%=rdbJOrT2.ClientID%>").prop("checked") && !$("#<%=rdbJOrT3.ClientID%>").prop("checked")) {
	            alert("请选择是否与行家联合代理或轮流代理");
	            $("#<%=rdbJOrT1.ClientID%>").focus();
                return false;
            }
            if ($("#<%=rdbJOrT1.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtSamePlaceXX1.ClientID%>").val()) == "") { alert("同场代理的行家名称1不可为空！"); $("#<%=txtSamePlaceXX1.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtSamePlaceXX2.ClientID%>").val()) == "") { alert("同场代理的行家名称2不可为空！"); $("#<%=txtSamePlaceXX2.ClientID%>").focus(); return false; }

                if ($.trim($("#<%=txtAgencyFee1.ClientID%>").val()) == "") { alert("同场代理行家代理费1不可为空！"); $("#<%=txtAgencyFee1.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyFee2.ClientID%>").val()) == "") { alert("同场代理行家代理费2不可为空！"); $("#<%=txtAgencyFee2.ClientID%>").focus(); return false; }
                if ($("#<%=rdbIsCashPrize11.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtCashPrize1.ClientID%>").val()) == "") { alert("同场代理行家现金奖1不可为空！"); $("#<%=txtCashPrize1.ClientID%>").focus(); return false; }
	            }
                if ($("#<%=rdbIsCashPrize21.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtCashPrize2.ClientID%>").val()) == "") { alert("同场代理行家现金奖2不可为空！"); $("#<%=txtCashPrize2.ClientID%>").focus(); return false; }
                }
                if (!$("#<%=rdbIsCashPrize11.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize12.ClientID%>").prop("checked")) {
                    alert("请选择是否有同场代理行家现金奖1");
                    $("#<%=rdbIsCashPrize11.ClientID%>").focus();
	                return false;
                }
                if (!$("#<%=rdbIsCashPrize21.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize22.ClientID%>").prop("checked")) {
                    alert("请选择是否有同场代理行家现金奖2");
                    $("#<%=rdbIsCashPrize21.ClientID%>").focus();
	                return false;
                }

                if ($("#<%=rdbIsPFear11.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtPFear1.ClientID%>").val()) == "") { alert("同场代理行家项目费用1不可为空！"); $("#<%=txtPFear1.ClientID%>").focus(); return false; }
                }
                if ($("#<%=rdbIsPFear21.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtPFear2.ClientID%>").val()) == "") { alert("同场代理行家项目费用2不可为空！"); $("#<%=txtPFear2.ClientID%>").focus(); return false; }
                }
                if (!$("#<%=rdbIsPFear11.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear12.ClientID%>").prop("checked")) {
                    alert("请选择是否有同场代理行家项目费用1");
                    $("#<%=rdbIsCashPrize11.ClientID%>").focus();
	                return false;
                }
                if (!$("#<%=rdbIsPFear21.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear22.ClientID%>").prop("checked")) {
                    alert("请选择是否有同场代理行家项目费用2");
                    $("#<%=rdbIsCashPrize21.ClientID%>").focus();
	                return false;
                }
            }
            if ($("#<%=rdbJOrT2.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtTurnsAgentXX1.ClientID%>").val()) == "") { alert("轮流代理的行家名称1不可为空！"); $("#<%=txtTurnsAgentXX1.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtTurnsAgentXX2.ClientID%>").val()) == "") { alert("轮流代理的行家名称2不可为空！"); $("#<%=txtTurnsAgentXX2.ClientID%>").focus(); return false; }

                if ($.trim($("#<%=txtAgencyFee3.ClientID%>").val()) == "") { alert("轮流代理行家代理费1不可为空！"); $("#<%=txtAgencyFee3.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyFee4.ClientID%>").val()) == "") { alert("轮流代理行家代理费2不可为空！"); $("#<%=txtAgencyFee4.ClientID%>").focus(); return false; }
                if ($("#<%=rdbIsCashPrize31.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtCashPrize3.ClientID%>").val()) == "") { alert("轮流代理行家现金奖1不可为空！"); $("#<%=txtCashPrize3.ClientID%>").focus(); return false; }
	            }
                if ($("#<%=rdbIsCashPrize41.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtCashPrize4.ClientID%>").val()) == "") { alert("轮流代理行家现金奖2不可为空！"); $("#<%=txtCashPrize4.ClientID%>").focus(); return false; }
                }
                if (!$("#<%=rdbIsCashPrize31.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize32.ClientID%>").prop("checked")) {
                    alert("请选择是否有轮流代理行家现金奖1");
                    $("#<%=rdbIsCashPrize31.ClientID%>").focus();
	                return false;
                }
                if (!$("#<%=rdbIsCashPrize41.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize42.ClientID%>").prop("checked")) {
                    alert("请选择是否有轮流代理行家现金奖2");
                    $("#<%=rdbIsCashPrize41.ClientID%>").focus();
	                return false;
                }

                if ($("#<%=rdbIsPFear31.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtPFear3.ClientID%>").val()) == "") { alert("轮流代理行家项目费用3不可为空！"); $("#<%=txtPFear3.ClientID%>").focus(); return false; }
                }
                if ($("#<%=rdbIsPFear41.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtPFear4.ClientID%>").val()) == "") { alert("轮流代理行家项目费用4不可为空！"); $("#<%=txtPFear4.ClientID%>").focus(); return false; }
                }
                if (!$("#<%=rdbIsPFear31.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear32.ClientID%>").prop("checked")) {
                    alert("请选择是否有轮流代理行家项目费用3");
                    $("#<%=rdbIsPFear31.ClientID%>").focus();
	                return false;
                }
                if (!$("#<%=rdbIsPFear41.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear42.ClientID%>").prop("checked")) {
                    alert("请选择是否有轮流代理行家项目费用4");
                    $("#<%=rdbIsPFear41.ClientID%>").focus();
	                return false;
                }
                if ($.trim($("#<%=txtAgencyBeginDate1.ClientID%>").val()) == "") { alert("轮流代理行家代理开始期1不可为空！"); $("#<%=txtAgencyBeginDate1.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyBeginDate2.ClientID%>").val()) == "") { alert("轮流代理行家代理开始期2不可为空！"); $("#<%=txtAgencyBeginDate2.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyEndDate1.ClientID%>").val()) == "") { alert("轮流代理行家代理结束期1不可为空！"); $("#<%=txtAgencyFee3.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyEndDate2.ClientID%>").val()) == "") { alert("轮流代理行家代理结束期2不可为空！"); $("#<%=txtAgencyFee4.ClientID%>").focus(); return false; }
            }
	        //20141027+

	        var cblItemLength=$("#<%=cblDealOfficeType.ClientID %> input").length;
	        var flag=false;
	        var typeValues="";
	        for(var i=0;i<cblItemLength;i++)
	        {
	            if($("#<%=cblDealOfficeType.ClientID %> input")[i].checked)
	            {
	                flag=true;
	                typeValues+=$("#<%=cblDealOfficeType.ClientID%> span")[i].tag+"|";
	            }
	        }

	        if(!flag)
	        {
	            alert("请选择物业性质！");
	            return false;
	        }
	        else
	            $("#<%=hdDealOfficeType.ClientID%>").val(typeValues.substr(0,typeValues.length-1));
	       
	        if($.trim($("#<%=txtSquare.ClientID %>").val())=="") {
	            alert("可售面积不可为空！");
	            $("#<%=txtSquare.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtPreProjAgenceFee.ClientID %>").val())=="") {
	            alert("预计项目代理费计提不可为空！");
	            $("#<%=txtPreProjAgenceFee.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBrokerCostApply.ClientID %>").val())=="") {
	            alert("居间费用计提申请不可为空！");
	            $("#<%=txtBrokerCostApply.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBrokerName.ClientID %>").val())=="") {
	            alert("居间人姓名不可为空！");
	            $("#<%=txtBrokerName.ClientID %>").focus();
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
		            window.location='Apply_ProjCost_Detail.aspx?MainID=<%=MainID %>';
		    }
		}

		function editflow(){
		    var win=window.showModalDialog("Apply_ProjCost_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
					if(win=='success')
					    window.location="Apply_ProjCost_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        if(idx!='2'){
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
			start = "<!--" + start + "-->";    
			end = "<!--" + end + "-->";    
			if (typeof (extend) == 'undefined') {        
				var temp = window.document.body.innerHTML;        
				var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
				window.document.body.innerHTML = printhtml;        
				window.print();        
				window.document.body.innerHTML = temp;    
			}    
			else { window.print(); }
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
		<%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		<!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>项目费用申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td style="width:20%">申请部门</td>
					<td class="tl PL10"><input id="txtDepartment" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:90%;"/><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td>申请人</td>
					<td class="tl PL10">工号：<asp:TextBox ID="txtApplyForID" runat="server" Width="40px" onblur="getEmployee(this);"></asp:TextBox><span id="spanApplyFor" style="display:none;">&nbsp;&nbsp;&nbsp;&nbsp;姓名：<input id="txtApplyFor" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span></td>
				</tr>
                <tr>
					<td>回复电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
                    <td>发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
					<td>填写人</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
					<td style="width: 20%; ">文档编码</td>
					<td class="tl PL10"><%=SerialNumber %></td>
				</tr>
                <tr>
                    <th colspan="4" style="line-height:25px;" >申请正文</th>
				</tr>
                <tr>
					<td>项目名称</td>
					<td class="tl PL10"><asp:TextBox ID="txtProject" runat="server"></asp:TextBox></td>
					<td>发展商</td>
					<td class="tl PL10"><asp:TextBox ID="txtDeveloper" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td>项目负责人</td>
					<td class="tl PL10"><asp:TextBox ID="txtProjLeader" runat="server"></asp:TextBox></td>
					<td>项目拓展负责人</td>
					<td class="tl PL10"><asp:TextBox ID="txtProjBusiLeader" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td>物业性质</td>
					<td class="tl PL10" colspan="3">
                        <asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                        <asp:HiddenField ID="hdDealOfficeType" runat="server" />
					</td>
				</tr>
                <tr>
					<td>可售面积</td>
					<td class="tl PL10"><asp:TextBox ID="txtSquare" runat="server"></asp:TextBox></td>
                    <td>收款人姓名</td>
					<td class="tl PL10"><asp:TextBox ID="txtReceiver" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>是否与行家联合<br />代理或轮流代理</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbJOrT1" runat="server" GroupName="JOrT" Text="与行家同场联合代理" /><br />
                        <asp:RadioButton ID="rdbJOrT2" runat="server" GroupName="JOrT" Text="与行家轮流代理，即代理期内中原独家代理，代理期之外由行家轮流代理" /><br />
                        <asp:RadioButton ID="rdbJOrT3" runat="server" GroupName="JOrT" Text="整个项目由中原独家代理，发展商没有委托除中原以外的任何代理行" /><br />
                    </td>
                </tr>
                <tr>
                    <td>同场代理的行家</td>
                    <td colspan="3"class="tl PL10">
                        <div>　若项目与行家同场联合代理或与轮流代理，以下为必填项，若因无渠道了解相关信息无法填写，敬请注明“无渠道了解相关信息”。</div><br />
                        1.名称：<asp:TextBox ID="txtSamePlaceXX1" runat="server" Width="180px"></asp:TextBox>
                        　代理费：<asp:TextBox ID="txtAgencyFee1" runat="server" Width="180px"></asp:TextBox><br />
                        　现金奖：<asp:RadioButton ID="rdbIsCashPrize11" runat="server" Text="有，" GroupName="CashPrize1" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize1" runat="server" Width="200px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize12" runat="server" Text="无" GroupName="CashPrize1" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear11" runat="server" Text="有，比例" GroupName="IsPFear1" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear1" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear12" runat="server" Text="无" GroupName="IsPFear1" /><br />
                        2.名称：<asp:TextBox ID="txtSamePlaceXX2" runat="server" Width="180px"></asp:TextBox>
                        　代理费：<asp:TextBox ID="txtAgencyFee2" runat="server" Width="180px"></asp:TextBox><br />　现金奖：<asp:RadioButton ID="rdbIsCashPrize21" runat="server" Text="有，" GroupName="CashPrize2" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize2" runat="server" Width="200px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize22" runat="server" Text="无" GroupName="CashPrize2" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear21" runat="server" Text="有，比例" GroupName="IsPFear2" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear2" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear22" runat="server" Text="无" GroupName="IsPFear2" /><br />
                    </td>
                </tr>
                <tr>
                    <td>轮流代理的行家</td>
                    <td colspan="3"class="tl PL10">
                        　<div>　若项目与行家同场联合代理或与轮流代理，以下为必填项，若因无渠道了解相关信息无法填写，敬请注明“无渠道了解相关信息”。</div><br />
                        1.名称：<asp:TextBox ID="txtTurnsAgentXX1" runat="server" Width="180px"></asp:TextBox>
                        　代理期：<asp:TextBox ID="txtAgencyBeginDate1" runat="server" Width="90px"></asp:TextBox>～<asp:TextBox ID="txtAgencyEndDate1" runat="server" Width="90px"></asp:TextBox><br />
                        　代理费：<asp:TextBox ID="txtAgencyFee3" runat="server" Width="120px"></asp:TextBox>
                        　现金奖：<asp:RadioButton ID="rdbIsCashPrize31" runat="server" Text="有，" GroupName="CashPrize3" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize3" runat="server" Width="140px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize32" runat="server" Text="无" GroupName="CashPrize3" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear31" runat="server" Text="有，比例" GroupName="IsPFear3" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear3" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear32" runat="server" Text="无" GroupName="IsPFear3" /><br />
                        2.名称：<asp:TextBox ID="txtTurnsAgentXX2" runat="server" Width="180px"></asp:TextBox>
                        　代理期：<asp:TextBox ID="txtAgencyBeginDate2" runat="server" Width="90px"></asp:TextBox>～<asp:TextBox ID="txtAgencyEndDate2" runat="server" Width="90px"></asp:TextBox><br />
                        　代理费：<asp:TextBox ID="txtAgencyFee4" runat="server" Width="120px"></asp:TextBox>　现金奖：<asp:RadioButton ID="rdbIsCashPrize41" runat="server" Text="有，" GroupName="CashPrize4" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize4" runat="server" Width="140px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize42" runat="server" Text="无" GroupName="CashPrize4" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear41" runat="server" Text="有，比例" GroupName="IsPFear4" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear4" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear42" runat="server" Text="无" GroupName="IsPFear4" /><br />
                    </td>
                </tr>
                <tr>
					<td>预计项目<br/>代理费计提</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtPreProjAgenceFee" TextMode="MultiLine" Rows="3" runat="server" style="width:98%;overflow:auto;"></asp:TextBox></td>
				</tr>
                <tr>
					<td>居间费用<br/>计提申请</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtBrokerCostApply" TextMode="MultiLine" Rows="3" runat="server" style="width:98%;overflow:auto;"></asp:TextBox></td>
				</tr>
                <tr id="trBrokerCostReason">
					<td>居间费用<br/>计提原因</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtBrokerCostReason" TextMode="MultiLine" Rows="3" runat="server" style="width:98%;overflow:auto;"></asp:TextBox></td>
				</tr>
                <tr id="trBrokerName">
					<td>居间人姓名</td>
					<td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtBrokerName" runat="server"></asp:TextBox><br/>
                        <span style="color:red;">居间人身份证/名片复印件必须以附件形式提交，无附件不能提交申请</span>
					</td>
				</tr>
				<tr>
                    <th colspan="4" style="line-height:25px;" >审批流程</th>
				</tr>
                <tr id="trManager1" class="noborder" style="height: 85px;">
					<td >部门负责人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx200">_________</span></div>
					</td>
				</tr>

                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理复审</td>
					<td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#008162" />
						<textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx220">_________</span></div>
					</td>
				</tr>

			</table>
			<!--打印正文结束-->
		</div>
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
        <asp:Button ID="btnReWrite" runat="server" OnClick="btnReWrite_Click" text="重新导入" Visible="False" />
		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
            <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px;"/>
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
	<%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

