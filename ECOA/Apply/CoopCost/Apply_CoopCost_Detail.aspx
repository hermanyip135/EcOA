<%@ Page ValidateRequest="false" Title="合作费申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_CoopCost_Detail.aspx.cs" Inherits="Apply_CoopCost_Apply_CoopCost_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
	    var i = 1;
	    var jJSON = <%=SbJson.ToString() %>;
		var isUploaded = false;
		var isNewApply=('<%=IsNewApply%>'=='True');

	    $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

	    $(function() {      
	        $("#<%=txtDepartment.ClientID %>").autocomplete({ 
	            source: jJSON,
	            select: function(event,ui) {
	                $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
		        }
            	        });

	        $("#<%=txtDealDate.ClientID%>").datepicker({
	            showButtonPanel: true,
	            showOtherMonths: true,
	            selectOtherMonths: true,
	            changeMonth: true,
	            changeYear: true
	        });
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



	        changeDealType();
	        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});
	   
	        
	    function check() {	  
	        if(!isUploaded&&isNewApply)
	        {
	            alert("请上传合作人身份证/名片复印件。");
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

	        if($.trim($("#<%=ddlDepartmentType.ClientID %>").val())=="") {
	            alert("请选择部门类别！");
	            $("#<%=ddlDepartmentType.ClientID %>").focus();
	            return false;
	        }
    
	        if($.trim($("#<%=txtDealDate.ClientID %>").val())=="") {
	            alert("成交日期不可为空！");
	            $("#<%=txtDealDate.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtPropertyName.ClientID %>").val())=="") {
	            alert("物业名称不可为空！");
	            $("#<%=txtPropertyName.ClientID %>").focus();
	            return false;
	        }
	        

	        if($.trim($("#<%=txtReportID.ClientID %>").val())=="") {
	            alert("成交报告编号不可为空！");
	            $("#<%=txtReportID.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txtAddressDetail.ClientID %>").val())=="") {
	            alert("物业详细地址及房号不可为空！");
	            $("#<%=txtAddressDetail.ClientID %>").focus();
	            return false;
            }
	        if($.trim($("#<%=ddlDealType.ClientID %>").val())=="") {
	            alert("交易性质不可为空！");
	            $("#<%=ddlDealType.ClientID %>").focus();
	            return false;
	        }
                       
	        if($.trim($("#<%=txtArea.ClientID %>").val())=="") {
	            alert("面积不可为空！");
	            $("#<%=txtArea.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtDealPrice.ClientID %>").val())=="") {
	            alert("成交价/月租金不可为空！");
	            $("#<%=txtDealPrice.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtOwnerComm.ClientID %>").val())=="") {
	            alert("业佣不可为空！");
	            $("#<%=txtOwnerComm.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtOwnerScale.ClientID %>").val())=="") {
	            alert("比例或相当于几个月租金不可为空！");
	            $("#<%=txtOwnerScale.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtClientComm.ClientID %>").val())=="") {
	            alert("客佣不可为空！");
	            $("#<%=txtClientComm.ClientID %>").focus();
	            return false;
	        }
                
	        if($.trim($("#<%=txtClientScale.ClientID %>").val())=="") {
	            alert("比例或相当于几个月租金不可为空！");
	            $("#<%=txtClientScale.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtTotalComm.ClientID %>").val())=="") {
	            alert("总佣金不可为空！");
	            $("#<%=txtTotalComm.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtTotalScale.ClientID %>").val())=="") {
	            alert("总比例或总相当于几个月租金不可为空！");
	            $("#<%=txtTotalScale.ClientID %>").focus();
	            return false;
	        }
	
	        if($("#<%=cbxIsOwner.ClientID %>").prop("checked"))
	        {
	            if(!$("#<%=rdbBill11.ClientID %>").prop("checked") && !$("#<%=rdbBill12.ClientID %>").prop("checked") )
	            {
	                alert("请选择发票类型! ");
	                $("#<%=rdbBill11.ClientID %>").focus();
	                return false;
                }

                if($("#<%=rdbBill12.ClientID %>").prop("checked") && $("#<%=txtOwnerName.ClientID %>").val()=="")
	            {
	                alert("由于您选择了合作方提供发票领款人，请填写领款人姓名。");
	                $("#<%=txtOwnerName.ClientID %>").focus();
	                return false;
                }
	                    
	            if($("#<%=txtOwnerCoopCondition.ClientID %>").val()==""){alert("请填写合作条件。");$("#<%=txtOwnerCoopCondition.ClientID %>").focus();return false;}
	            if($("#<%=txtOwnerReason.ClientID %>").val()==""){alert("请填写合作原因、合作方背景及所起作用。");$("#<%=txtOwnerReason.ClientID %>").focus();return false;}
	            if($("#<%=txtOwnerCoopMoney.ClientID %>").val()==""){alert("请填写合作金额。");$("#<%=txtOwnerCoopMoney.ClientID %>").focus();return false;}
	            if($("#<%=txtOwnerCoopScale.ClientID %>").val()==""){alert("请填写占业佣比例。");$("#<%=txtOwnerCoopScale.ClientID %>").focus();return false;}
	            if($("#<%=txtOwnerCoopTotalScale.ClientID %>").val()==""){alert("请填写占总佣比例。");$("#<%=txtOwnerCoopTotalScale.ClientID %>").focus();return false;}
	        }
	
	        if($("#<%=cbxIsClient.ClientID %>").prop("checked"))
	        {
	            if(!$("#<%=rdbBill21.ClientID %>").prop("checked") && !$("#<%=rdbBill22.ClientID %>").prop("checked") )
	            {
	                alert("请选择发票类型! ");
	                $("#<%=rdbBill21.ClientID %>").focus();
	                return false;
                }

                if($("#<%=rdbBill22.ClientID %>").prop("checked") && $("#<%=txtClientName.ClientID %>").val()=="")
	            {
	                alert("由于您选择了合作方提供发票领款人，请填写领款人姓名。");
	                $("#<%=txtClientName.ClientID %>").focus();
	                return false;
                }
	                    
	            if($("#<%=txtClientCoopCondition.ClientID %>").val()==""){alert("请填写合作条件。");$("#<%=txtClientCoopCondition.ClientID %>").focus();return false;}
	            if($("#<%=txtClientReason.ClientID %>").val()==""){alert("请填写合作原因、合作方背景及所起作用。");$("#<%=txtClientReason.ClientID %>").focus();return false;}
	            if($("#<%=txtClientCoopMoney.ClientID %>").val()==""){alert("请填写合作金额。");$("#<%=txtClientCoopMoney.ClientID %>").focus();return false;}
	            if($("#<%=txtClientCoopScale.ClientID %>").val()==""){alert("请填写占客佣比例。");$("#<%=txtClientCoopScale.ClientID %>").focus();return false;}
	            if($("#<%=txtClientCoopTotalScale.ClientID %>").val()==""){alert("请填写占总佣比例。");$("#<%=txtClientCoopTotalScale.ClientID %>").focus();return false;}
	        }

	        if($.trim($("#<%=txtCoopMoney.ClientID %>").val())=="") {
	            alert("1. 2.两项合计合作金额不可为空！");
	            $("#<%=txtCoopMoney.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtCoopTotalScale.ClientID %>").val())=="") {
	            alert("1. 2.两项合计占总佣比例不可为空！");
	            $("#<%=txtCoopTotalScale.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtActualComm.ClientID %>").val())=="") {
	            alert("扣除合作费后公司实收佣金金额不可为空！");
	            $("#<%=txtActualComm.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtActualCommScale.ClientID %>").val())=="") {
	            alert("扣除合作费后实际收佣比例不可为空！");
	            $("#<%=txtActualCommScale.ClientID %>").focus();
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
	                window.location='Apply_CoopCost_Detail.aspx?MainID=<%=MainID %>';
            }
		}

        function editflow(){
            var win=window.showModalDialog("Apply_CoopCost_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
		    if(win=='success')
		        window.location="Apply_CoopCost_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx=='1'){
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
		    //    var temp = window.document.body.innerHTML;        
		    //    var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
		    //    window.document.body.innerHTML = printhtml;        
		    //    window.print();        
		    //    window.document.body.innerHTML = temp;    
		    //}    
		    //else { window.print(); }
		    cMyPrint();
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
        
	    function changeDealType()
	    {
	        switch($("#<%=ddlDealType.ClientID%>").val())
	        {
	            case "":
	                $("#lblPriceName").text("成交价/月租金");
	                break;
                case "1":
                    $("#lblPriceName").text("成交价");
                    break;
                case "2":
                    $("#lblPriceName").text("月租金");
                    break;
	        }
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
			<h1>合作费申请表</h1>
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
					<td>部门类别</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlDepartmentType" runat="server"><asp:ListItem>工商铺</asp:ListItem><asp:ListItem>其他部门</asp:ListItem></asp:DropDownList></td>
                    <td>成交日期</td>
					<td class="tl PL10"><asp:TextBox ID="txtDealDate" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td>楼盘名</td>
					<td class="tl PL10"><asp:TextBox ID="txtPropertyName" runat="server"></asp:TextBox></td>
                    <td>成交报告编号</td>
					<td class="tl PL10"><asp:TextBox ID="txtReportID" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td class="tl PL10 PR10" colspan="4">
                        （注意：必须填写正确的楼盘名，否则审批流程会出错）<br />
                       物业详细地址及房号 <asp:TextBox ID="txtAddressDetail" runat="server" Width="80%"></asp:TextBox>
                        <br /><br />
                        交易性质：<asp:DropDownList ID="ddlDealType" runat="server" onclick="changeDealType();"></asp:DropDownList>
						<table class='sample tc' width='100%'>
							<thead>
                                <tr>
                                    <td style="width:12%;">面积</td>
                                    <td style="width:16%;"><label id="lblPriceName">成交价/月租金</label></td>
                                    <td style="width:14%;">业佣</td>
                                    <td style="width:10%;">比例</td>
                                    <td style="width:14%;">客佣</td>
                                    <td style="width:10%;">比例</td>
                                    <td style="width:14%;">总佣金</td>
                                    <td style="width:10%;">总比例</td>
                                </tr>
							</thead>
							<tr>
                                <td><asp:TextBox ID="txtArea" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDealPrice" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtOwnerComm" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtOwnerScale" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtClientComm" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtClientScale" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalComm" runat="server" Width="90%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalScale" runat="server" Width="90%"></asp:TextBox></td>
							</tr>
						</table>
					</td>
				</tr>
                <tr>
					<td class="tl PL10 PR10" colspan="4">
						<table class='sample tc' width='100%'>
                            <tr>
                                <td colspan="6" class="tl PL10" style="font-weight:bold;">
                                    1.<asp:RadioButton ID="rdbBill12" GroupName="Bill1" runat="server" Text="合作方提供发票领款人" value="2" />　
                                    <asp:RadioButton ID="rdbBill11" GroupName="Bill1" runat="server" Text="需我司代扣税费合作人" value="1" Visible="False" />
                                    姓名：<asp:TextBox ID="txtOwnerName" runat="server"></asp:TextBox> 
                                    <asp:CheckBox ID="cbxIsOwner" runat="server" Text="业主方" />
                                </td>
                            </tr>
                             <tr>
                                <td>合作原因、合作方背景及所起作用</td>
                                 <td colspan="5" class="tl PL10"><asp:TextBox ID="txtOwnerReason" runat="server" Width="1000%"></asp:TextBox></td>
                            </tr>
							<tr>
                                <td>合作条件</td>
                                <td colspan="5" class="tl PL10"><asp:TextBox ID="txtOwnerCoopCondition" runat="server" Width="90%"></asp:TextBox></td>
							</tr>
                            <tr>
                                <td>合作金额</td>
                                <td class="tl PL10"><asp:TextBox ID="txtOwnerCoopMoney" runat="server" Width="100px"></asp:TextBox>元</td>
                                <td>占业佣比例</td>
                                <td class="tl PL10"><asp:TextBox ID="txtOwnerCoopScale" runat="server" Width="100px"></asp:TextBox>%</td>
                                <td>占总佣比例</td>
                                <td class="tl PL10"><asp:TextBox ID="txtOwnerCoopTotalScale" runat="server" Width="100px"></asp:TextBox>%</td>
							</tr>
                           
						</table>
					</td>
				</tr>
                <tr>
					<td class="tl PL10 PR10" colspan="4">
						<table class='sample tc' width='100%'>
                            <tr>
                                <td colspan="6" class="tl PL10" style="font-weight:bold;">
                                    2.<asp:RadioButton ID="rdbBill22" GroupName="Bill2" runat="server" Text="合作方提供发票领款人" value="2" />　
                                    <asp:RadioButton ID="rdbBill21" GroupName="Bill2" runat="server" Text="需我司代扣税费合作人" value="1" Visible="False" />
                                    姓名：<asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>  
                                    <asp:CheckBox ID="cbxIsClient" runat="server" Text="买家/租客方" />
                                </td>
                            </tr>
                                  <tr>
                                <td>合作原因、合作方背景及所起作用</td>
                                 <td colspan="5" class="tl PL10"><asp:TextBox ID="txtClientReason" runat="server" Width="100%"></asp:TextBox></td>
                            </tr>
							<tr>
                                <td>合作条件</td>
                                <td colspan="5" class="tl PL10"><asp:TextBox ID="txtClientCoopCondition" runat="server" Width="90%"></asp:TextBox></td>
							</tr>
                            <tr>
                                <td>合作金额</td>
                                <td class="tl PL10"><asp:TextBox ID="txtClientCoopMoney" runat="server" Width="100px"></asp:TextBox>元</td>
                                <td>占客佣比例</td>
                                <td class="tl PL10"><asp:TextBox ID="txtClientCoopScale" runat="server" Width="100px"></asp:TextBox>%</td>
                                <td>占总佣比例</td>
                                <td class="tl PL10"><asp:TextBox ID="txtClientCoopTotalScale" runat="server" Width="100px"></asp:TextBox>%</td>
							</tr>
						</table>
					</td>
				</tr>
                <tr>
					<td class="tl PL10 PR10" colspan="4">
						<table class='sample tc' width='100%' style="font-weight:bold;">
                            <tr>
                                <td><span style="text-decoration:underline;">1. 2.两项合计</span>合作金额</td>
                                <td><asp:TextBox ID="txtCoopMoney" runat="server" Width="100px"  onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');"></asp:TextBox>元</td>
                                <td>占总佣比例</td>
                                <td><asp:TextBox ID="txtCoopTotalScale" runat="server" Width="100px"  onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');"></asp:TextBox>%</td>
							</tr>
                            <tr>
                                <td><span style="text-decoration:underline;">扣除合作费后</span>公司实收佣金金额</td>
                                <td><asp:TextBox ID="txtActualComm" runat="server" Width="100px"></asp:TextBox>元</td>
                                <td>实际收佣比例</td>
                                <td><asp:TextBox ID="txtActualCommScale" runat="server" Width="100px"></asp:TextBox>%</td>
							</tr>
						</table>
					</td>
				</tr>
                <tr>
                    <td colspan="4" style="font-size: 20px; padding-left: 10px; text-align: left;">
                        　　敬请三级市场各申请人/负责人注意，合作费申请及项目费申请在支付费用前，需将有效的<span style="color: #FF0000">证明文件及已完成审批的原申请交法律部审核，</span>审核通过后方可进行报销。此操作同时适用于已完成审批但尚未进行支付的所有合作费及项目费申请。
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

                <tr id="trGeneralManager2" class="noborder" style="height: 85px; display:none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label>
                        <input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>

                <tr id="trShowFlow4" class="noborder" style="height: 85px; display:none;">
					<td rowspan="2" >法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow5" class="noborder" style="height: 85px; display:none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>

				<tr id="trGeneralManager" class="noborder" style="height: 85px; display:none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label>
                        <input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
						<textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
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
            <div style="width:640px;margin:0 auto;"><span style="float:left;color:red;">*合作人身份证/名片复印件必须以附件形式提交，作为《合作费申请》的附件，无附件不能提交申请</span></div>
            <div style="clear:both;"></div>
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
        <asp:button runat="server" id="btnTemp" text="暂时保存" onclick="btnTempSave_Click" CssClass="commonbtn" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px;" />
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