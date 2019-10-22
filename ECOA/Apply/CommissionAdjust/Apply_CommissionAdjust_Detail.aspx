<%@ Page ValidateRequest="false" Title="应收佣金调整报告 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_CommissionAdjust_Detail.aspx.cs" Inherits="Apply_CommissionAdjust_Apply_CommissionAdjust_Detail" %>

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
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}

		    $("#<%=txtBadCommDate.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    $("#<%=txtPropertyDate.ClientID%>").datepicker({
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
	        if($("#<%=ddlSign.ClientID%>").val() == "请选择")
	        {
	            alert("请选择签约前或者签约后！");
	            $("#<%=ddlSign.ClientID %>").focus();
	          return false;
	        }

	        if($.trim($("#<%=txtBuilding.ClientID %>").val())=="") {
	            alert("楼盘单位不可为空！");
	            $("#<%=txtBuilding.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
	            alert("调整原因不可为空！");
	            $("#<%=txtReason.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBadCommDate.ClientID %>").val())=="") {
	            alert("调整日期不可为空！");
	            $("#<%=txtBadCommDate.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtProperty.ClientID %>").val())=="") {
	            alert("物业不可为空！");
	            $("#<%=txtProperty.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtControler.ClientID %>").val())=="") {
	            alert("经办人不可为空！");
	            $("#<%=txtControler.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtPropertyID.ClientID %>").val())=="") {
	            alert("物业成交编号不可为空！");
	            $("#<%=txtPropertyID.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtPropertyDate.ClientID %>").val())=="") {
	            alert("物业成交日期不可为空！");
	            $("#<%=txtPropertyDate.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtOldDeal.ClientID %>").val())=="") {
	            alert("原成交价不可为空！");
	            $("#<%=txtOldDeal.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtNewDeal.ClientID %>").val())=="") {
	            alert("现成交价不可为空！");
	            $("#<%=txtNewDeal.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtAjustDeal.ClientID %>").val())=="") {
	            alert("成交价调整额不可为空！");
	            $("#<%=txtAjustDeal.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtShouldComm.ClientID %>").val())=="") {
	            alert("应收佣金不可为空！");
	            $("#<%=txtShouldComm.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtActualComm.ClientID %>").val())=="") {
	            alert("实收佣金不可为空！");
	            $("#<%=txtActualComm.ClientID %>").focus();
	            return false;
	        }

	        //if($.trim($("#<%=txtSumShouldComm.ClientID %>").val())=="") {
	        //    alert("应收佣金总额不可为空！");
	        //    $("#<%=txtSumShouldComm.ClientID %>").focus();
	        //    return false;
	        //}

	        if($.trim($("#<%=txtActualComm.ClientID %>").val())=="") {
	            alert("实收佣金不可为空！");
	            $("#<%=txtActualComm.ClientID %>").focus();
	            return false;
            }

	        if($.trim($("#<%=txtAjustComm.ClientID %>").val())=="") {
	            alert("调整佣金不可为空！");
	            $("#<%=txtAjustComm.ClientID %>").focus();
	            return false;
	        }

	        //if (!$("#<%=rdbLeadReason1.ClientID %>").prop("checked") && !$("#<%=rdbLeadReason2.ClientID %>").prop("checked")) {
	        //    alert("请选择导致资料变更的原因");
	        //    return false;
	        //}

	        if (!$("#<%=rdbIsLawE1.ClientID %>").prop("checked") && !$("#<%=rdbIsLawE2.ClientID %>").prop("checked")) {
	            alert("请选择是否需要法律部审批");
	            return false;
	        }

	        //if (!$("#<%=rdbCommitment1.ClientID %>").prop("checked") && !$("#<%=rdbCommitment2.ClientID %>").prop("checked")&& !$("#<%=rdbCommitment3.ClientID %>").prop("checked")) {
	        //    alert("请选择现承诺文件");
	        //    return false;
	        //}


	        var data = "";
	        //如果详细只有一行，且该行个人资料为空
	        //if($("#tbDetail tr").size() == 2 && $.trim($("#txtCountOffTime1").val()) == "" && $.trim($("#txtDealNo1").val()) == "" && $.trim($("#txtOtherDataAddress1").val()) == "" && $.trim($("#txtChangeSituation1").val()) == "" && $.trim($("#txtChangeReason1").val()) == "")
	        //    data="||";
	        $("#tbDetail tr").each(function(n) {
	            if (n != 0 && n != $("#tbDetail tr").size()) {
	                data += $.trim($("#txtDetail_pNo" + n).html())
                        + "&&" + $.trim($("#txtProperty" + n).val()) 
                        + "&&" + $.trim($("#txtControler" + n).val()) 
                        + "&&" + $.trim($("#txtPropertyID" + n).val()) 
                        + "&&" + $.trim($("#txtPropertyDate" + n).val()) 
                        + "&&" + $.trim($("#txtOldDeal" + n).val()) 
                        + "&&" + $.trim($("#txtNewDeal" + n).val()) 
                        + "&&" + $.trim($("#txtAjustDeal" + n).val()) 
                        + "&&" + $.trim($("#txtShouldComm" + n).val()) 
                        + "&&" + $.trim($("#txtActualComm" + n).val()) 
                        + "&&" + $.trim($("#txtAjustComm" + n).val()) 
                        //+ "&&" + ($("#rdoApplyType" + n + "1").prop('checked')?"1":"0")
                        + "&&" + $.trim($("#txtCname" + n).val())
                        + "&&" + $.trim($("#txtCommitment" + n).val())
                        + "&&" + $.trim($("#txtChangeReason" + n).val()) 
                        + "&&" + $.trim($("#txtDealType" + n).val())
                        + "&&" + $.trim($("#txtChangeType" + n).val())+ "||";
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
				window.location='Apply_CommissionAdjust_Detail.aspx?MainID=<%=MainID %>';
		}

        function uploadDetailed() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_zDetailed_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
        	        $("#<%=hdFilePath.ClientID%>").val(sReturnValue);
        	        return true;
        	    }

		function editflow(){
			var win=window.showModalDialog("Apply_CommissionAdjust_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_CommissionAdjust_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='6'){
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
                //+ '         <td class=\"tl PL10\" style="line-height: 30px" colspan="3">'
		        //+ '             物业：<input type="text" id="txtProperty' + i + '" style="width:250px">　经办人：<input type="text" id="txtControler' + i + '" style="width:250px"><br />'
                //+ '             物业成交编号：<input type="text" id="txtPropertyID' + i + '" style="width:201px">　物业成交日期：<input type="text" id="txtPropertyDate' + i + '" style="width:215px"><br />'
                //+ '             ①原成交价：人民币<input type="text" id="txtOldDeal' + i + '" style="width:177px">②现成交价：人民币<input type="text" id="txtNewDeal' + i + '" style="width:202px"><br />'
                //+ '             ③成交价调整：人民币<input type="text" id="txtAjustDeal' + i + '" style="width:164px">　客户名称：<input type="text" id="txtCname' + i + '" style="width:240px"/><br />客户联系电话：<input type="text" id="txtCommitment' + i + '" style="width:200px"/><br />'
                //+ '             ④应收佣金：人民币<input type="text" id="txtShouldComm' + i + '" style="width:176px">⑤实收佣金：人民币<input type="text" id="txtActualComm' + i + '" style="width:202px"><br />'
                //+ '             ⑥调整佣金：港币/人民币<input type="text" id="txtAjustComm' + i + '" style="width:148px">'
                //+'              是否特殊调整：<input type="radio" id="rdoApplyType' + i + '1" name="rdoApplyType' + i + '" /><label for="rdoApplyType' + i + '1">是</label><input type="radio" id="rdoApplyType' + i + '0" name="rdoApplyType' + i + '" /><label for="rdoApplyType' + i + '0">否</label>'
                //+ '             <br />'
                //+ '             <span style="vertical-align: top;margin-top: 10px;">坏帐原因</span><textarea id="txtChangeReason' + i + '" rows="9" style="width: 540px;margin-top: 8px; overflow: auto;"></textarea><br /><br />'
                //+ '         </td>'

                + '         <td><span id="txtDetail_pNo' + i + '">'+i+'</span></td>'
                + '         <td><input type="text" id="txtPropertyDate' + i + '" style="width:90%"/></td>'
                + '         <td><textarea id="txtPropertyID' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtDealType' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtProperty' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtOldDeal' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtNewDeal' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtAjustDeal' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtShouldComm' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtActualComm' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtAjustComm' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtControler' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtChangeReason' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtChangeType' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                //+ '         <td><input type="radio" id="rdoApplyType' + i + '1" name="rdoApplyType' + i + '" /><label for="rdoApplyType' + i + '1">是</label><input type="radio" id="rdoApplyType' + i + '0" name="rdoApplyType' + i + '" /><label for="rdoApplyType' + i + '0">否</label></td>'
                + '         <td><textarea id="txtCname' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'
                + '         <td><textarea id="txtCommitment' + i + '" style="width:90%; overflow: auto;" rows="2"></textarea></td>'

				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
		    $("#trFlag").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
		    
		    $("#txtPropertyDate"+ i).datepicker({
			    showButtonPanel: true,
			    showOtherMonths: true,
			    selectOtherMonths: true,
			    changeMonth: true,
			    changeYear: true
		    });
		    i++;
		}//*-

		function deleteRow() {
		    if (i > 1) {
			    i--;
			    $("#tbDetail tr:eq(" + i + ")").remove();
		    } 
		    else
		    	alert("已经没有行了。");
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
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 900px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>应收佣金调整报告</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:900px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='900px'>
				<tr>
					<td>收文部门</td>
					<td class="tl PL10" >财务部</td>
					<td style="width: 20%; ">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
				</tr>
				<tr>
                    <td>是否需要法律部审批</td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbIsLawE1" runat="server" Text="是　　" GroupName="3" />
                        <asp:RadioButton ID="rdbIsLawE2" runat="server" Text="否" GroupName="3" />
                    </td>
                    <td>发文人员</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
				</tr>
				<tr>
                    <td >发文部门</td>
					<td class="tl PL10"><asp:textbox id="txtDepartment" runat="server"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td >发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
                    <td>抄送部门</td>
                    <td class="tl PL10" >法律部/财务部</td>
                    <td>回复电话</td>
					<td class="tl PL10">020-<asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>应收佣金签约</td>
                    <td class="tl PL10" colspan="3"><asp:DropDownList ID="ddlSign" runat="server" Width="140px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>签约前</asp:ListItem>
                            <asp:ListItem>签约后</asp:ListItem>
                        </asp:DropDownList></td>
                   
                </tr>
				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 30px;">
                        <div style="width: 640px; text-align: left; margin:0 auto;">
                        <span style="font-weight: bolder">坏帐的原因</span><br />
                        致： 财务部　　　　　　　　　　　　　　　　　　　　楼　盘：<asp:textbox id="txtBuilding" runat="server" Width="250px"></asp:textbox><br />
                        部门：项目部   销售组　　　　　　　　　　　　　　　　日　期：<asp:textbox id="txtBadCommDate" runat="server" Width="250px"></asp:textbox><br />
                        物业：<asp:textbox id="txtProperty" runat="server" Width="250px"></asp:textbox>　经办人：<asp:textbox id="txtControler" runat="server" Width="250px"></asp:textbox><br />
                        物业成交编号：<asp:textbox id="txtPropertyID" runat="server" Width="201px"></asp:textbox>　物业成交日期：<asp:textbox id="txtPropertyDate" runat="server" Width="215px"></asp:textbox><br />
                        ①原成交价：人民币<asp:textbox id="txtOldDeal" runat="server" Width="177px"></asp:textbox>  ②现成交价：人民币<asp:textbox id="txtNewDeal" runat="server" Width="201px"></asp:textbox><br />
                        ③成交价调整：人民币<asp:textbox id="txtAjustDeal" runat="server" Width="164px"></asp:textbox><br />
                        ④应收佣金：人民币<asp:textbox id="txtShouldComm" runat="server" Width="176px"></asp:textbox>  ⑤实收佣金：人民币<asp:textbox id="txtActualComm" runat="server" Width="202px"></asp:textbox><br />
                        ⑥调整佣金：人民币<asp:textbox id="txtAjustComm" runat="server" Width="176px"></asp:textbox>　导致原因：<asp:RadioButton ID="rdbLeadReason1" runat="server" Text="发展商" GroupName="1" />
                        <asp:RadioButton ID="rdbLeadReason2" runat="server" Text="买家" GroupName="1" />
                        <br />
                        注：③=①-②<br />
                        　　⑥=④-⑤<br />
                        承诺文件：<asp:RadioButton ID="rdbCommitment1" runat="server" GroupName="2" Text="认购书 " />
                        <asp:RadioButton ID="rdbCommitment2" runat="server" GroupName="2" Text="商品房买卖合同" />
                        <asp:RadioButton ID="rdbCommitment3" runat="server" GroupName="2" Text="策划代理合约" />
                        <br />
                         <span style="vertical-align: top">原因：</span><asp:textbox id="txtReason" runat="server" Width="540px" Height="120px" TextMode="MultiLine"></asp:textbox>
                        </div>
                    </td>
				</tr>

				<tr>
					<td class="tl PL10 PR10" colspan="4">
						<span style="font-weight: bolder">坏帐明细表</span><br /><br />
						<table id="tbDetail" class='sample tc' width='100%'>

                            <thead>                                
                                <tr>
                                    <td>序号</td>
                                    <td>认购日期</td>
                                    <td>成交编号</td>
                                    <td>成交类型</td>
                                    <td>楼房单元</td>
                                    <td>原成交价</td>
                                    <td>现成交价</td>
                                    <td>调整成交价</td>
                                    <td>报数佣金</td>
                                    <td>应收佣金</td>
                                    <td>调整金额(元)</td>
                                    <td>经办人</td>
                                    <td>坏帐原因</td>
                                    <td>财务坏账类型</td>
                                  <%--  <td style="width: 70px">特殊调整</td>--%>
                                    <td>客户名称</td>
                                    <td>客户电话</td>
                                </tr>
							</thead>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag">
                                <td colspan="5">合计</td>
                                <td><asp:TextBox ID="txtSumOldDeal" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumNewDeal" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumAjustDeal" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumShouldComm" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumActualComm" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumAjustComm" runat="server" Width="90%"></asp:TextBox></td>
                                <td colspan="5"></td>
                            </tr>


						</table>
                        <br />
                        <div id="divUploadDetailed" style="display:none;">若明细表涉及的内容超过3项，请按此格式（<a href="../../资料/坏帐明细表格式.xls">EXCEL版空白详细表</a>)下载，编辑后<asp:button id="btnUploadDetailed" runat="server" text="上传" onclick="btnUploadDetailed_Click" onclientclick="return uploadDetailed();" style="margin-left: 5px;"/>为附件，将自动导入<input type="hidden" id="hdFilePath" runat="server" /> </div>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
						<div style="clear:both;">备注：特殊调整范围：<br />
                                                    1、	一手成交客户换单位，更换后单位比之前成交单位楼价低<br />
                                                    2、	实际购买价格低于认购书价格<br />
                                                    3、	重复报数成交<br />
                                                    4、	在签署正式合同之前退房<br />
						</div>
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
					<td class="auto-style1"><label runat="server" id="laIdx5">交易管理部负责人</label>  </td>
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

                <tr id="trManager7" class="noborder" style="height: 85px; display:none;">
					<td class="auto-style1">物业部区域负责人</td>
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
				</tr>

				<tr class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style1">法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" />
                        <label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" />
                        <label for="rdbNoIDx8">不同意</label>
                        <input id="rdbOtherIDx8" type="radio" name="agree8" />
                        <label for="rdbOtherIDx8">其他意见</label><br />
						<textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9"/>
                        <label for="rdbYesIDx9">同意</label>
                        <input id="rdbNoIDx9" type="radio" name="agree9" />
                        <label for="rdbNoIDx9">不同意</label>
                        <input id="rdbOtherIDx9" type="radio" name="agree9" />
                        <label for="rdbOtherIDx9">其他意见</label><br />
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

			</table>
			<!--打印正文结束-->
		</div>
        <div class="noprint">
		<asp:gridview id="gvAttach" CssClass="gvAttach" runat="server" backcolor="White" style="clear: both; margin-top: 3px;"
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

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" Visible="False" />
            <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
		<asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
        <asp:button runat="server" id="btnSignBad" text="标注已坏账" onclick="btnSignBad_Click" visible="false" />
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

