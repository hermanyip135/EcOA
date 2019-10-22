<%@ Page ValidateRequest="false" Title="物业部承接项目报备申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_UndertakeProj_Detail.aspx.cs" Inherits="Apply_UndertakeProj_Apply_UndertakeProj_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
	    var i1 = 1,i2=1;

	    $(function () {
	        $("#<%=txtAgentStartDate.ClientID%>").datepicker();
	        $("#<%=txtAgentEndDate.ClientID%>").datepicker();
	        $("#<%=txtClientGuardStartDate.ClientID%>").datepicker();
	        $("#<%=txtClientGuardEndDate.ClientID%>").datepicker();
	        $("#<%=txtAreaPromiseBackDate.ClientID%>").datepicker();

	        i1 = $("#tOwner tr").length;
	        i2 = $("#tClient tr").length;
	        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
	    });

	    function check() {
	        if ($.trim($("#<%=txtApplyForID.ClientID%>").val()) == "") {alert("申请人工号不可为空！");$("#<%=txtApplyForID.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtApplyFor.ClientID%>").val()) == "") {alert("请正确填写申请人工号！");$("#<%=txtApplyForID.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=ddlDepartmentType.ClientID%>").val()) == "") {alert("请选择所属区域！");$("#<%=ddlDepartmentType.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtProject.ClientID%>").val()) == "") {alert("项目名称不可为空！");$("#<%=txtProject.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtDeveloper.ClientID %>").val()) == "") { alert("项目发展商(小业主)不可为空！"); $("#<%=txtDeveloper.ClientID %>").focus(); return false; }
	        //if ($.trim($("#<%=txtGroupName.ClientID%>").val()) == "") { alert("所属集团名称不可为空！"); $("#<%=txtGroupName.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=ddlProjectProperty.ClientID%>").val()) == "") {alert("请选择项目性质！");$("#<%=ddlProjectProperty.ClientID%>").focus();return false;}
            if ($.trim($("#<%=ddlDealType.ClientID%>").val()) == "") {alert("请选择代理类型！");$("#<%=ddlDealType.ClientID%>").focus();return false;}
            if ($.trim($("#<%=ddlAgentProperty.ClientID%>").val()) == "") {alert("请选择代理性质！");$("#<%=ddlAgentProperty.ClientID%>").focus();return false;}
	        //if ($.trim($("#<%=txtProjectArea.ClientID%>").val()) == "") {alert("项目所在区域不可为空！");$("#<%=txtProjectArea.ClientID%>").focus();return false;}

	        var cblItemLength = $("#<%=cblDealOfficeType.ClientID%> input").length;
	        var flag = false;
	        var typeValues = "";
	        for (var i = 0; i < cblItemLength; i++) {
	            if ($("#<%=cblDealOfficeType.ClientID%> input")[i].checked) {
	                flag = true;
	                typeValues += $("#<%=cblDealOfficeType.ClientID%> span")[i].tag + "|";
	            }
	        }

	        if (!flag) {
	            alert("请选择物业性质！");
	            return false;
	        }
	        else
	            $("#<%=hdDealOfficeType.ClientID%>").val(typeValues.substr(0, typeValues.length - 1));

	        if ($.trim($("#<%=txtProjectArea.ClientID%>").val()) == "") { alert("详细地址不可为空！"); $("#<%=txtProjectArea.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtDeveloperContacter.ClientID%>").val()) == "") { alert("开发商联系人姓名不可为空！"); $("#<%=txtDeveloperContacter.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtDeveloperContacterPosition.ClientID%>").val()) == "") { alert("开发商联系人职位不可为空！"); $("#<%=txtDeveloperContacterPosition.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtDeveloperContacterPhone.ClientID%>").val()) == "") { alert("开发商联系人电话不可为空！"); $("#<%=txtDeveloperContacterPhone.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaFollowerContacter.ClientID%>").val()) == "") { alert("区域跟进人姓名不可为空！"); $("#<%=txtAreaFollowerContacter.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaFollowerContacterPosition.ClientID%>").val()) == "") { alert("区域跟进人职位不可为空！"); $("#<%=txtAreaFollowerContacterPosition.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaFollowerContacterPhone.ClientID%>").val()) == "") { alert("区域跟进人电话不可为空！"); $("#<%=txtAreaFollowerContacterPhone.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaCheckDataer.ClientID%>").val()) == "") { alert("区域对数人姓名不可为空！"); $("#<%=txtAreaCheckDataer.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaCheckDataerCode.ClientID%>").val()) == "") { alert("区域对数人工号不可为空！"); $("#<%=txtAreaCheckDataerCode.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaCheckDataerPhone.ClientID%>").val()) == "") { alert("区域对数人电话不可为空！"); $("#<%=txtAreaCheckDataerPhone.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtSquare.ClientID%>").val()) == "") { alert("项目承接货量平方数不可为空！"); $("#<%=txtSquare.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtSetNumber.ClientID%>").val()) == "") { alert("项目承接货量套数不可为空！"); $("#<%=txtSetNumber.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtUnitPrice.ClientID%>").val()) == "") { alert("项目预计单价不可为空！"); $("#<%=txtUnitPrice.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtTotalPrice.ClientID%>").val()) == "") { alert("项目货量总金额不可为空！"); $("#<%=txtTotalPrice.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAgentStartDate.ClientID%>").val()) == "") { alert("代理期开始日期不可为空！"); $("#<%=txtAgentStartDate.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAgentEndDate.ClientID%>").val()) == "") { alert("代理期结束日期不可为空！"); $("#<%=txtAgentEndDate.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtClientGuardStartDate.ClientID%>").val()) == "") { alert("客户保护期开始日期不可为空！"); $("#<%=txtClientGuardStartDate.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtClientGuardEndDate.ClientID%>").val()) == "") { alert("客户保护期结束日期不可为空！"); $("#<%=txtClientGuardEndDate.ClientID%>").focus(); return false; }

	        if ($.trim($("#<%=txtTermsOfContract.ClientID%>").val()) == "") { alert("合同约定的结佣条款不可为空！"); $("#<%=txtTermsOfContract.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtTermsOfMajorIssues.ClientID%>").val()) == "") { alert("重大问题的合同条款不可为空！"); $("#<%=txtTermsOfMajorIssues.ClientID%>").focus(); return false; }

	        if ($.trim($("#<%=txtPreCompleteNumber.ClientID%>").val()) == "") { alert("预估代理期内完成货量套数不可为空！"); $("#<%=txtPreCompleteNumber.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtPreCompleteMoney.ClientID%>").val()) == "") { alert("预估代理期内完成货量金额不可为空！"); $("#<%=txtPreCompleteMoney.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtPreCompleteComm.ClientID%>").val()) == "") { alert("预估代理期内完成货量佣金收入不可为空！"); $("#<%=txtPreCompleteComm.ClientID%>").focus(); return false; }
	        if (!$("#<%=rdbIsProjEarlyCommBack.ClientID%>").prop("checked") && !$("#<%=rdbIsProjEarlyCommNotBack.ClientID%>").prop("checked") && !$("#<%=rdbIsProjEarlyCommhavent.ClientID%>").prop("checked")) {
	            alert("请选择项目前期佣金是否已收回");
	            return false;
	        }
	        else if ($("#<%=rdbIsProjEarlyCommBack.ClientID%>").prop("checked")) {
	            if ($("#<%=txtOweCommSum.ClientID%>").val() == "") {
	                alert("由于您选择了项目前期佣金已收回，请填写欠佣金额。");
	                $("#<%=txtOweCommSum.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtAreaPromiseBackDate.ClientID%>").val() == "") {
	                alert("由于您选择了项目前期佣金已收回，请填写区域承诺收回时间。");
	                $("#<%=txtAreaPromiseBackDate.ClientID%>").focus();
	                return false;
	            }
	        }

	        if (!$("#<%=rdbHaveSingleReward.ClientID%>").prop("checked") && !$("#<%=rdbNoSingleReward.ClientID%>").prop("checked")) {
	            alert("请选择项是否有单套现金奖");
	            return false;
	        }

	        if (!$("#<%=rdbAllJumpBar.ClientID%>").prop("checked") && !$("#<%=rdbRateJumpBar.ClientID%>").prop("checked")) {
	            alert("请选择佣金计算类型");
	            return false;
	        }

	        if (!$("#<%=rdbIsMallSplit.ClientID%>").prop("checked") && !$("#<%=rdbIsNotMallSplit.ClientID%>").prop("checked")) {
	            alert("请选择是否属于商场拆细散卖");
	            return false;
	        }

	        if (!$("#<%=rdbIsMallOpen.ClientID%>").prop("checked") && !$("#<%=rdbIsNotMallOpen.ClientID%>").prop("checked")) {
	            alert("请选择商场是否已在经营");
	            return false;
	        }

	        if (!$("#<%=rdbIsExistMortgage.ClientID%>").prop("checked") && !$("#<%=rdbIsNotExistMortgage.ClientID%>").prop("checked")) {
	            alert("请选择是否存在抵押");
	            return false;
	        }

	        if (!$("#<%=rdbIsExistLeasebackRules.ClientID%>").prop("checked") && !$("#<%=rdbIsNotExistLeasebackRules.ClientID%>").prop("checked")) {
	            alert("请选择是否存在返租条款");
	            return false;
	        }

	        if (!$("#<%=rdbHavePreSaleLicenses.ClientID%>").prop("checked") && !$("#<%=rdbNoPreSaleLicenses.ClientID%>").prop("checked")) {
	            alert("请选择是否有预售许可证或房产证");
	            return false;
	        }

	        if (!$("#<%=rdbIsUniteAgent.ClientID%>").prop("checked") && !$("#<%=rdbIsNotUniteAgent.ClientID%>").prop("checked")) {
	            alert("请选择是否与行家联合代理");
	            return false;
	        }

	        if (!$("#<%=rdbIsWithPropertyOwnerSignContract.ClientID%>").prop("checked") && !$("#<%=rdbIsNotWithPropertyOwnerSignContract.ClientID%>").prop("checked")) {
	            alert("请选择是否与产权人签署合同");
	            return false;
	        }

	        if (!$("#<%=rdbSaleMode1.ClientID%>").prop("checked") && !$("#<%=rdbSaleMode2.ClientID%>").prop("checked")) {
	            alert("请选择销售模式");
	            return false;
	        }
	        else if ($("#<%=rdbSaleMode2.ClientID%>").prop("checked")) {
	            if ($("#<%=txtMainAreaScale.ClientID%>").val() == "") {
	                alert("由于您选择了联同各区共同销售，请填写主区拆分成交占比。");
	                $("#<%=txtMainAreaScale.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtDealAreaScale.ClientID%>").val() == "") {
	                alert("由于您选择了联同各区共同销售，请填写成交区域占比。");
	                $("#<%=txtDealAreaScale.ClientID%>").focus();
	                return false;
	            }
	        }

	        if (!$("#<%=rdbIsNeedExtension.ClientID%>").prop("checked") && !$("#<%=rdbIsNotNeedExtension.ClientID%>").prop("checked")) {
	            alert("请选择是否需要推广项目信息至外区");
	            return false;
	        }

	        if (!$("#<%=rdbIsNeedBroadcast.ClientID%>").prop("checked") && !$("#<%=rdbIsNotNeedBroadcast.ClientID%>").prop("checked")) {
	            alert("请选择是否需要公司对外宣传项目信息");
	            return false;
	        }

	        var data = "";

	        $("#tOwner tr").each(function (i) {
	            var n = i + 1;
	            data += $.trim($("#txtOwnerCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatScale" + n).val()) + "||";
	        });

	        data = data.substr(0, data.length - 2);
	        $("#<%=hdOwner.ClientID%>").val(data);

	        data = "";

	        $("#tClient tr").each(function (i) {
	            var n = i + 1;
	            data += $.trim($("#txtClientCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtClientCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtClientCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtClientCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtClientCommFloatScale" + n).val()) + "||";
	        });

	        data = data.substr(0, data.length - 2);
	        $("#<%=hdClient.ClientID%>").val(data);
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
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID%>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID%>', "dialogHeight=165px");
		    if(sReturnValue=='success')
		        window.location = 'Apply_UndertakeProj_Detail.aspx?MainID=<%=MainID%>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_UndertakeProj_Flow.aspx?MainID=<%=MainID%>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location = "Apply_UndertakeProj_Detail.aspx?MainID=<%=MainID%>";
        }
		
	    function sign(idx) {
	        if (idx != '4'&&idx != '5'&&idx != '6') {
	            if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbNoIDx" + idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
	        }
	        else {
	            if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbNoIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
	        }

	        if ($("#rdbNoIDx" + idx).prop("checked") && $.trim($("#txtIDx" + idx).val()) == "") {
	            alert("由于您不同意该申请，必须填写不同意的原因。");
	            return;
	        }

	        if (confirm("是否确认审核？")) {
	            if ($("#rdbYesIDx" + idx).prop("checked"))
	                $("#<%=hdIsAgree.ClientID%>").val("1");
	            else if ($("#rdbNoIDx" + idx).prop("checked"))
	                $("#<%=hdIsAgree.ClientID%>").val("0");
	            else if ($("#rdbOtherIDx" + idx).prop("checked"))
	                $("#<%=hdIsAgree.ClientID%>").val("2");

	            getSuggestion(idx);
	            document.getElementById("<%=btnSign.ClientID%>").click();
	        }
	    }

	    function getSuggestion(idx) {
	        $("#<%=hdSuggestion.ClientID%>").val($("#txtIDx" + idx).val());
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

        function addRow1() {
            i1++;
            var html = '<tr id="trOwner' + i1 + '"  style="border:none;">'
				+ '     <td style="border:none;"><input type="text" id="txtOwnerCommFloatSetNumberStart' + i1 + '" style="width:50px"/>至<input type="text" id="txtOwnerCommFloatSetNumberEnd' + i1 + '" style="width:50px"/>套/<input type="text" id="txtOwnerCommFloatMoneyStart' + i1 + '" style="width:50px"/>至<input type="text" id="txtOwnerCommFloatMoneyEnd' + i1 + '" style="width:50px"/>元销售额，收佣比例<input type="text" id="txtOwnerCommFloatScale' + i1 + '" style="width:50px"/>%</td>'
				+ '</tr>';
            
            $("#tOwner").append(html);
        }

        function deleteRow1() {
            if (i1 > 2) {
                i1--;
                $("#tOwner tr:eq(" + i1 + ")").remove();
            } 
            else
                alert("不可再删除。");
        }

        function addRow2() {
            i2++;
            var html = '<tr id="trClient' + i2 + '"  style="border:none;">'
				+ '     <td style="border:none;"><input type="text" id="txtClientCommFloatSetNumberStart' + i2 + '" style="width:50px"/>至<input type="text" id="txtClientCommFloatSetNumberEnd' + i2 + '" style="width:50px"/>套/<input type="text" id="txtClientCommFloatMoneyStart' + i2 + '" style="width:50px"/>至<input type="text" id="txtClientCommFloatMoneyEnd' + i2 + '" style="width:50px"/>元销售额，收佣比例<input type="text" id="txtClientCommFloatScale' + i2 + '" style="width:50px"/>%</td>'
				+ '</tr>';

            $("#tClient").append(html);
        }

        function deleteRow2() {
            if (i2 > 2) {
                i2--;
                $("#tClient tr:eq(" + i2 + ")").remove();
            }
            else
                alert("不可再删除。");
        }

        function getEmployee(n) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function (info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtApplyForID.ClientID%>").val(infos[0]);
                        $("#<%=txtApplyFor.ClientID%>").val(infos[1]);
                        $("#<%=txtDepartment.ClientID%>").val(infos[2]);
                        $("#<%=hdDepartmentID.ClientID%>").val(infos[3]);
                        $("#spanApplyFor").show();
                    }
                    else {
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
            var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") + "&href=" + window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
                    if (sReturnValue == 'success')
                        window.location.href = window.location.href;
                    else if (sReturnValue == 'deleted')
                        window.location = '/Apply/Apply_Search.aspx';
                }
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
		<%=SbFlow.ToString()%>
            </div>
		<!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>物业部承接项目报备申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber%></span></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td style="width:20%">申请部门</td>
					<td class="tl PL10"><input id="txtDepartment" type="text" runat="server" readonly="readonly" style="background-color:Silver; "/><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td style="width:20%">申请人</td>
					<td class="tl PL10">工号：<asp:TextBox ID="txtApplyForID" runat="server" Width="40px" onblur="getEmployee(this);"></asp:TextBox><span id="spanApplyFor" style="display:none;">&nbsp;&nbsp;&nbsp;&nbsp;姓名：<input id="txtApplyFor" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span></td>
				</tr>
                <tr>
					<td>申请区域</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlDepartmentType" runat="server"></asp:DropDownList></td>
                    <td>申请日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
					<td>填写人</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td>回复电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <th colspan="4" style="line-height:25px;" >申请正文</th>
				</tr>
                <tr>
					<td>项目名称</td>
					<td class="tl PL10"><asp:TextBox ID="txtProject" runat="server"></asp:TextBox></td>
                    <td>项目发展商<br />(小业主)</td>
					<td class="tl PL10"><asp:TextBox ID="txtDeveloper" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>所属集团名称</td>
					<td colspan="3" class="tl PL10"><asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td>是否与<br />电商合作</td>
					<td colspan="3" class="tl PL10"><asp:RadioButton ID="rdbIsCoopWithECommerce" runat="server" Text="是，电商公司名称" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName" runat="server" Width="300px"></asp:TextBox><br />
                        <asp:RadioButton ID="rdbIsNoCoopWithECommerce" runat="server" Text="否，但客户需要在电商公司刷卡以获取买房优惠" GroupName="CoopWithECommerce" /><br />
                        <asp:RadioButton ID="rdbIsNo2CoopWithECommerce" runat="server" Text="否，整个项目没有任何电商参与" GroupName="CoopWithECommerce" />
					</td>
				</tr>
                <tr>
					<td>项目性质</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlProjectProperty" runat="server"></asp:DropDownList></td>
                    <td>代理类型</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlDealType" runat="server"></asp:DropDownList></td>
				</tr>
                <tr>
					<td>代理性质</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlAgentProperty" runat="server"></asp:DropDownList></td>
				    <td>项目所在区域</td>
					<td class="tl PL10"><asp:TextBox ID="txtProjectArea" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td>物业性质</td>
					<td class="tl PL10" colspan="3">
                        <asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                        <asp:HiddenField ID="hdDealOfficeType" runat="server" />
					</td>
				</tr>
                <tr>
                    <td>详细地址</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtProjectAddress" runat="server" Width="90%"></asp:TextBox></td>
				</tr>
                <tr>
					<td>发展商<br />联系人</td>
					<td colspan="3" class="tl PL10">姓名<asp:TextBox ID="txtDeveloperContacter" runat="server" Width="100px"></asp:TextBox>职位<asp:TextBox ID="txtDeveloperContacterPosition" runat="server" Width="100px"></asp:TextBox>联系电话<asp:TextBox ID="txtDeveloperContacterPhone" runat="server" Width="100px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>区域跟进<br />联系人</td>
					<td colspan="3" class="tl PL10">姓名<asp:TextBox ID="txtAreaFollowerContacter" runat="server" Width="100px"></asp:TextBox>职位<asp:TextBox ID="txtAreaFollowerContacterPosition" runat="server" Width="100px"></asp:TextBox>联系电话<asp:TextBox ID="txtAreaFollowerContacterPhone" runat="server" Width="100px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>区域对数人</td>
					<td colspan="3" class="tl PL10">姓名<asp:TextBox ID="txtAreaCheckDataer" runat="server" Width="100px"></asp:TextBox>工号<asp:TextBox ID="txtAreaCheckDataerCode" runat="server" Width="100px"></asp:TextBox>联系电话<asp:TextBox ID="txtAreaCheckDataerPhone" runat="server" Width="100px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>项目情况</td>
					<td colspan="3" class="tl PL10">承接货量<asp:TextBox ID="txtSquare" runat="server" Width="150px"></asp:TextBox>平方米,共<asp:TextBox ID="txtSetNumber" runat="server" Width="150px"></asp:TextBox>套;
                        <br />预计单价<asp:TextBox ID="txtUnitPrice" runat="server" Width="150px"></asp:TextBox>元/平方米;货量总金额<asp:TextBox ID="txtTotalPrice" runat="server" Width="150px"></asp:TextBox>元
					</td>
				</tr>
                <tr>
					<td>代理费</td>
					<td colspan="3" class="tl PL10">(1)业佣：<br />固定收佣比例<asp:TextBox ID="txtOwnerCommFixScale" runat="server" Width="50px"></asp:TextBox>%<br />
				        变动收佣，其中<br />
                        <table id="tOwner" class='sample tc' width='100%' style="border:none;">
							<tr id="trOwner1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtOwnerCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtOwnerCommFloatSetNumberEnd1" style="width:50px"/>套/<input type="text" id="txtOwnerCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtOwnerCommFloatMoneyEnd1" style="width:50px"/>元销售额，收佣比例<input type="text" id="txtOwnerCommFloatScale1" style="width:50px"/>%</td>
				            </tr>
                            <%=SbHtml1.ToString()%>
                        </table>
                        <asp:HiddenField ID="hdOwner" runat="server" />
                        <input type="button" id="btnAddRow1" value="添加新行" onclick="addRow1();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow1" value="删除一行" onclick="deleteRow1();" style=" float:left; display:none"/>
                        <div style="clear:both;"></div>
                        (2)客佣：<br />固定收佣比例<asp:TextBox ID="txtClientCommFixScale" runat="server" Width="50px"></asp:TextBox>%<%--，预计佣金收入总额<asp:TextBox ID="txtPreCommTotal" runat="server" Width="50px"></asp:TextBox>元--%><br />
                        变动收佣，其中<br />
					    <table id="tClient" class='sample tc' width='100%' style="border:none;">
                            <tr id="trClient1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtClientCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtClientCommFloatSetNumberEnd1" style="width:50px"/>套/<input type="text" id="txtClientCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtClientCommFloatMoneyEnd1" style="width:50px"/>元销售额，收佣比例<input type="text" id="txtClientCommFloatScale1" style="width:50px"/>%</td>
			                </tr>
							<%=SbHtml2.ToString()%>
					    </table>
                        <asp:HiddenField ID="hdClient" runat="server" />
                        <input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style=" float:left;display:none"/><br /><br />
                        合同约定的结佣条款<br />
                        <asp:TextBox ID="txtTermsOfContract" runat="server"  TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:TextBox>
                        <br />
                        重大问题的合同条款（如违约赔偿条款、接盘区域限制等）<br />
                        <asp:TextBox ID="txtTermsOfMajorIssues" runat="server"  TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:TextBox>
					</td>
				</tr>
                <tr>
					<td>备注</td>
					<td class="tl PL10" colspan="3"><asp:textbox id="txtRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:textbox></td>
				</tr>
                <tr>
					<td>代理期</td>
					<td class="tl PL10"><asp:TextBox ID="txtAgentStartDate" runat="server" Width="90px"></asp:TextBox>~<asp:TextBox ID="txtAgentEndDate" runat="server" Width="90px"></asp:TextBox></td>
                    <td>客户保护期</td>
					<td class="tl PL10"><asp:TextBox ID="txtClientGuardStartDate" runat="server" Width="90px"></asp:TextBox>~<asp:TextBox ID="txtClientGuardEndDate" runat="server" Width="90px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>预估代理期<br />内完成</td>
					<td colspan="3" class="tl PL10">货量<asp:TextBox ID="txtPreCompleteNumber" runat="server" Width="50px"></asp:TextBox>套,货量金额<asp:TextBox ID="txtPreCompleteMoney" runat="server" Width="50px"></asp:TextBox>元,佣金收入<asp:TextBox ID="txtPreCompleteComm" runat="server" Width="50px"></asp:TextBox>元</td>
				</tr>
                <tr>
					<td>项目前期佣金<br />是否已收回</td>
					<td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbIsProjEarlyCommBack" runat="server" Text="是" GroupName="ProjEarlyComm" />，欠佣金额<asp:TextBox ID="txtOweCommSum" runat="server" Width="50px"></asp:TextBox>元，区域承诺<asp:TextBox ID="txtAreaPromiseBackDate" runat="server" Width="80px"></asp:TextBox>收回<br />
                        <asp:RadioButton ID="rdbIsProjEarlyCommNotBack" runat="server" Text="否" GroupName="ProjEarlyComm" />，前期佣金已全部收回<br />
                        <asp:RadioButton ID="rdbIsProjEarlyCommhavent" runat="server" Text="不存在欠佣，项目为首次承接" GroupName="ProjEarlyComm" />
					</td>
				</tr>
                <tr>
					<td>单套现金奖</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbHaveSingleReward" runat="server" Text="有" GroupName="SingleReward" /><asp:RadioButton ID="rdbNoSingleReward" runat="server" Text="无"  GroupName="SingleReward" /></td>
				    <td>佣金</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbAllJumpBar" runat="server" Text="全跳bar" GroupName="JumpBar" /><asp:RadioButton ID="rdbRateJumpBar" runat="server" Text="分级跳bar"  GroupName="JumpBar"  /></td>
				</tr>
                <tr>
					<td>是否属于<br />商场拆细散卖</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbIsMallSplit" runat="server" Text="是" GroupName="MallSplit"/><asp:RadioButton ID="rdbIsNotMallSplit" runat="server" Text="否" GroupName="MallSplit"/></td>
				    <td>商场是否<br />已在经营</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbIsMallOpen" runat="server" Text="是" GroupName="MallOpen" /><asp:RadioButton ID="rdbIsNotMallOpen" runat="server" Text="否" GroupName="MallOpen" /></td>
				</tr>
                <tr>
					<td>是否存在抵押</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbIsExistMortgage" runat="server" Text="是" GroupName="ExistMortgage" /><asp:RadioButton ID="rdbIsNotExistMortgage" runat="server" Text="否" GroupName="ExistMortgage"/></td>
				    <td>是否存在<br />返租条款</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbIsExistLeasebackRules" runat="server" Text="是" GroupName="ExistLeasebackRules" /><asp:RadioButton ID="rdbIsNotExistLeasebackRules" runat="server" Text="否" GroupName="ExistLeasebackRules" /></td>
				</tr>
                <tr>
					<td>是否有预售许<br />可证或房产证</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbHavePreSaleLicenses" runat="server" Text="是" GroupName="PreSaleLicenses" /><asp:RadioButton ID="rdbNoPreSaleLicenses" runat="server" Text="否" GroupName="PreSaleLicenses" /></td>
				    <td>是否与行家<br />联合代理</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbIsUniteAgent" runat="server" Text="是" GroupName="UniteAgent" /><asp:RadioButton ID="rdbIsNotUniteAgent" runat="server" Text="否" GroupName="UniteAgent" /></td>
				</tr>
                <tr>
					<td>是否与产权人<br />签署合同</td>
					<td colspan="3" class="tl PL10"><asp:RadioButton ID="rdbIsWithPropertyOwnerSignContract" runat="server" Text="是" GroupName="WithPropertyOwnerSignContract" /><asp:RadioButton ID="rdbIsNotWithPropertyOwnerSignContract" runat="server" Text="否" GroupName="WithPropertyOwnerSignContract" />（如选否，区域须提供业主的授权书）</td>
				</tr>
                <tr>
					<td>销售模式</td>
					<td colspan="3" class="tl PL10"><asp:RadioButton ID="rdbSaleMode1" runat="server" Text="区域自行销售" GroupName="SaleMode" /><asp:RadioButton ID="rdbSaleMode2" runat="server" Text="联同各区共同销售" GroupName="SaleMode" />，主区拆分成交的<asp:TextBox ID="txtMainAreaScale" runat="server" Width="50px"></asp:TextBox>%，成交区域占<asp:TextBox ID="txtDealAreaScale" runat="server" Width="50px"></asp:TextBox>%</td>
				</tr>
                <tr>
					<td colspan="2">是否需要推广项目信息至外区<br />（中原平台通告/联动项目汇总邮件/推盘短信等）</td>
					<td colspan="2" class="tl PL10"><asp:RadioButton ID="rdbIsNeedExtension" runat="server" Text="是" GroupName="NeedExtension" /><asp:RadioButton ID="rdbIsNotNeedExtension" runat="server" Text="否" GroupName="NeedExtension" /></td>
				</tr>
                <tr>
					<td colspan="2">是否需要公司对外宣传项目信息<br />（官方微博/外网等）</td>
					<td colspan="2" class="tl PL10"><asp:RadioButton ID="rdbIsNeedBroadcast" runat="server" Text="是" GroupName="NeedBroadcast" /><asp:RadioButton ID="rdbIsNotNeedBroadcast" runat="server" Text="否" GroupName="NeedBroadcast" /></td>
				</tr>
				<tr>
                    <th colspan="4" style="line-height:25px;" >审批流程</th>
				</tr>
                <tr id="trManager1" class="noborder" style="height: 85px;">
					<td >申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
                <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td >申请部门负责人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <td >二级市场负责人<br />（项目部）<br />或<br />三级市场负责人<br />（物业部）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
					<td rowspan="2" >法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>
			</table>
            <div style="width:640px;margin:0 auto;"><span class="tl" style="float:left;">备注：1物业部承接一手项目/一手货尾盘，需上此报备申请表。<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2物业部承接二手物业达20套或以上的属批量项目，需上此报备申请表。</span></div>
			<!--打印正文结束-->
		</div>
        <div style="clear:both;"></div>

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
						<asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID")%>' OnClientClick="return confirm('确认删除？');" />
						<asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID")%>' />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
					<ItemTemplate>
						<a id="link" href='<%=ConfigurationManager.AppSettings["EcoaFileURL"]%><%#Eval("OfficeAutomation_Attach_Path")%>' target="_blank"><%#Eval("OfficeAutomation_Attach_Name")%></a>
						<asp:HiddenField ID="hfPath" runat="server" Value='<%#Eval("OfficeAutomation_Attach_Path")%>' />
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
        <%--<asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>--%>
		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" style="height: 21px" />
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
            </div>
            </div>
	</div>
	<%=SbJs.ToString()%>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>