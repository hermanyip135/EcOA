<%@ Page ValidateRequest="false" Title="项目发展商额外奖金报备 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ExtraBonus_Detail.aspx.cs" Inherits="Apply_ExtraBonus_Apply_ExtraBonus_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
	    var i1 = 1,i2=1,i3=1;
	    var jJSON = <%=SbJson.ToString() %>;
	    var isNewApply=('<%=IsNewApply%>'=='True');

	    $(function() {      
	        i1 = $("#tbAgentRule tr").length - 2;
	        i2 = $("#tbRewardRule tr").length;
	        i3 = $("#tbPayCond tr").length - 2;

		    $("#<%=txtAgentStartDate.ClientID%>").datepicker();
	        $("#<%=txtAgentEndDate.ClientID%>").datepicker();
	        $("#<%=txtClientGuardStartDate.ClientID%>").datepicker();
	        $("#<%=txtClientGuardEndDate.ClientID%>").datepicker();
	        $("#<%=txtApplyCashRewardValidityDurationStartDate.ClientID%>").datepicker();
	        $("#<%=txtApplyCashRewardValidityDurationEndDate.ClientID%>").datepicker();
	        $("#<%=txtAreaPromiseSubmitDate.ClientID%>").datepicker();

	        $("#<%=txtAgencyBeginDate1.ClientID%>").datepicker();
	        $("#<%=txtAgencyBeginDate2.ClientID%>").datepicker();
	        $("#<%=txtAgencyEndDate1.ClientID%>").datepicker();
	        $("#<%=txtAgencyEndDate2.ClientID%>").datepicker();
	        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
	    });

	    function check() {	        
	        if ($.trim($("#<%=txtApplyForID.ClientID %>").val()) == "") {alert("申请人工号不可为空！");$("#<%=txtApplyForID.ClientID %>").focus();return false;}
            if ($.trim($("#<%=txtApplyFor.ClientID %>").val()) == "") {alert("请正确填写申请人工号！");$("#<%=txtApplyForID.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtProject.ClientID %>").val()) == "") {alert("项目名称不可为空！");$("#<%=txtProject.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtAgentStartDate.ClientID %>").val()) == "") {alert("项目代理期开始日期不可为空！");$("#<%=txtAgentStartDate.ClientID %>").focus();return false;}
            if ($.trim($("#<%=txtAgentEndDate.ClientID %>").val()) == "") {alert("项目代理期结束日期不可为空！");$("#<%=txtAgentEndDate.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtClientGuardStartDate.ClientID %>").val()) == "") {alert("客户保护期开始日期不可为空！");$("#<%=txtClientGuardStartDate.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtClientGuardEndDate.ClientID %>").val()) == "") {alert("客户保护期结束日期不可为空！");$("#<%=txtClientGuardEndDate.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtApplyCashRewardValidityDurationStartDate.ClientID %>").val()) == "") {alert("申请现金奖有效期开始日期不可为空！");$("#<%=txtApplyCashRewardValidityDurationStartDate.ClientID %>").focus();return false;}
	        if ($.trim($("#<%=txtApplyCashRewardValidityDurationEndDate.ClientID %>").val()) == "") {alert("申请现金奖有效期结束日期不可为空！");$("#<%=txtApplyCashRewardValidityDurationEndDate.ClientID %>").focus();return false;}
	        if (!$("#<%=rdbFullPay.ClientID %>").prop("checked") && !$("#<%=rdbRatePay.ClientID %>").prop("checked")) {
	            alert("请选择现金奖的标准");
	            return false;
	        }          
	        if (!$("#<%=rdbRewardPayType1.ClientID %>").prop("checked") && !$("#<%=rdbRewardPayType2.ClientID %>").prop("checked")&& !$("#<%=rdbRewardPayType3.ClientID %>").prop("checked")) {
	            alert("请选择现金奖的发放方式");
	            return false;
	        }
	        else if ($("#<%=rdbRewardPayType2.ClientID %>").prop("checked")) {
	            if ($("#<%=txtPayerName.ClientID %>").val() == "") {alert("由于您选择了奖金由发展商直接支付现金，请填写现金奖发放统筹人员姓名。");$("#<%=txtPayerName.ClientID %>").focus();return false;}
	            if ($("#<%=txtPayerPosition.ClientID %>").val() == "") {alert("由于您选择了奖金由发展商直接支付现金，请填写现金奖发放统筹人员职务。");$("#<%=txtPayerPosition.ClientID %>").focus();return false;}
	            if ($("#<%=txtPayerPhone.ClientID %>").val() == "") {alert("由于您选择了奖金由发展商直接支付现金，请填写现金奖发放统筹人员联系电话。");$("#<%=txtPayerPhone.ClientID %>").focus();return false;}
	            if ($("#<%=txtRecevieCashRewardAccountName.ClientID %>").val() == "") {alert("由于您选择了奖金由发展商直接支付现金，请填写接收现金奖银行帐号的帐户姓名。");$("#<%=txtRecevieCashRewardAccountName.ClientID %>").focus();return false;}
	            if ($("#<%=txtRecevieCashRewardAccounts.ClientID %>").val() == "") {alert("由于您选择了奖金由发展商直接支付现金，请填写接收现金奖银行帐号。");$("#<%=txtRecevieCashRewardAccounts.ClientID %>").focus();return false;}
	            if (!$("#<%=rdbIsNeedPayFee.ClientID %>").prop("checked") && !$("#<%=rdbIsNotNeedPayFee.ClientID %>").prop("checked")) {
	                alert("请选择现金奖是否需开具发票并由我司支付税费");
	                return false;
	            }
	        }
	        else if ($("#<%=rdbRewardPayType3.ClientID %>").prop("checked")) {
	            if ($("#<%=txtRewardPayTypeOtherCase.ClientID %>").val() == "") {alert("由于您选择了其他情况，请填写其他情况。");$("#<%=txtRewardPayTypeOtherCase.ClientID %>").focus();return false;}
	        }

	        if (!$("#<%=rdbIsSubmitConfirmation.ClientID %>").prop("checked") && !$("#<%=rdbIsNotSubmitConfirmation.ClientID %>").prop("checked")) {
	            alert("请选择区域是否已提交发展商奖金确认书");
	            return false;
	        }
	        else if ($("#<%=rdbIsNotSubmitConfirmation.ClientID %>").prop("checked")) {
	            if ($.trim($("#<%=txtAreaPromiseSubmitDate.ClientID %>").val()) == "") { alert("由于您选择了区域未提交发展商奖金确认书，请填写承诺提交日期。"); $("#<%=txtAreaPromiseSubmitDate.ClientID %>").focus(); return false; }
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
            
	        var data = "";
	        var flag = true;
	         
	        $("#tbAgentRule tr").each(function (i) {
	            if(i>1){
	                var n = i -1;
	                if ($.trim($("#txtAgentRuleSetNumber" + n).val()) == "") {
	                    alert("第" + n + "行的销售套数必须填写。");
	                    $("#txtAgentRuleSetNumber" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtAgentRuleMoney" + n).val()) == "") {
	                    alert("第" + n + "行的销售金额必须填写。");
	                    $("#txtAgentRuleMoney" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtAgentRuleAgentPoint" + n).val()) == "") {
	                    alert("第" + n + "行的代理点数必须填写。");
	                    $("#txtAgentRuleAgentPoint" + n).focus();
	                    flag = false;
	                }
	                else
	                    data += $.trim($("#txtAgentRuleSetNumber" + n).val()) + "&&" + $.trim($("#txtAgentRuleMoney" + n).val()) + "&&" + $.trim($("#txtAgentRuleAgentPoint" + n).val()) + "||";
	            }
	        });

	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdAgentRule.ClientID %>").val(data);
	        }
	        else 
	            return false;

	        data = "";
	        flag = true;
	        
	        $("#tbRewardRule tr").each(function (i) {
	            var n = i + 1;
	            if ($.trim($("#txtRewardRuleMoneyPerSet" + n).val()) == "") {
	                alert("第" + n + "行的套数必须填写。");
	                $("#txtRewardRuleMoneyPerSet" + n).focus();
	                flag = false;
	            }
	            else if ($.trim($("#txtRewardRuleCondition" + n).val()) == "") {
	                alert("第" + n + "行的发放条件必须填写。");
	                $("#txtRewardRuleCondition" + n).focus();
	                flag = false;
	            }
	            else
	                data += $.trim($("#txtRewardRuleMoneyPerSet" + n).val()) + "&&" + $.trim($("#txtRewardRuleCondition" + n).val()) + "||";
	        });

	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdRewardRule.ClientID %>").val(data);
	        }
	        else 
	            return false;

	        data = "";
	        flag = true;

	        $("#tbPayCond tr").each(function (i) {
	            if(i>1){
	                var n = i -1;
	                if ($.trim($("#txtPayCondSetNumber" + n).val()) == "") {
	                    alert("第" + n + "行的货量（套）必须填写。");
	                    $("#txtPayCondSetNumber" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtPayCondPriceRange" + n).val()) == "") {
	                    alert("第" + n + "行的价格区间（万元）必须填写。");
	                    $("#txtPayCondPriceRange" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtPayCondUnitPrice" + n).val()) == "") {
	                    alert("第" + n + "行的单套均价（万元）必须填写。");
	                    $("#txtPayCondUnitPrice" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtPayCondActualComm" + n).val()) == "") {
	                    alert("第" + n + "行的公司实收佣（元）必须填写。");
	                    $("#txtPayCondActualComm" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtPayCondRewardScale" + n).val()) == "") {
	                    alert("第" + n + "行的奖金比例（%）必须填写。");
	                    $("#txtPayCondRewardScale" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtPayCondPayPerSet" + n).val()) == "") {
	                    alert("第" + n + "行的可发放奖金金额（元/套）必须填写。");
	                    $("#txtPayCondPayPerSet" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtPayCondPayActualScale" + n).val()) == "") {
	                    alert("第" + n + "行的奖金实际发放比例必须填写。");
	                    $("#txtPayCondPayActualScale" + n).focus();
	                    flag = false;
	                }
	                else
	                    data += $.trim($("#txtPayCondSetNumber" + n).val()) + "&&" + $.trim($("#txtPayCondPriceRange" + n).val()) + "&&" + $.trim($("#txtPayCondUnitPrice" + n).val()) + "&&" + $.trim($("#txtPayCondActualComm" + n).val()) + "&&" + $.trim($("#txtPayCondRewardScale" + n).val())+ "&&" + $.trim($("#txtPayCondPayPerSet" + n).val())+ "&&" + $.trim($("#txtPayCondPayActualScale" + n).val()) + "||";
	            }
	        });

	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdPayCond.ClientID %>").val(data);
                return true;
            }

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
            {   
                if(isNewApply)
                    isUploaded = true;
                else
                    window.location='Apply_ExtraBonus_Detail.aspx?MainID=<%=MainID %>';
            }
		        //window.location='Apply_ExtraBonus_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_ExtraBonus_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_ExtraBonus_Detail.aspx?MainID=<%=MainID %>";
        }

	    function CancelSign(idc) {
	        if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
	        {
	            $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
	    }
		
	    function sign(idx) {
	        if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
	            alert("请确定是否同意！");
	            return;
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
            var html = '<tr id="trAgentRule' + i1 + '">'
				+ '     <td><input type="text" id="txtAgentRuleSetNumber' + i1 + '" style="width:90px"/></td>'
				+ '     <td><input type="text" id="txtAgentRuleMoney' + i1 + '" style="width:90px"/></td>'
				+ '     <td><input type="text" id="txtAgentRuleAgentPoint' + i1 + '" style="width:90%"/></td>'
				+ '</tr>';
            
            $("#tbAgentRule").append(html);
        }
        
        function deleteRow1() {
            if (i1 > 1) {
                i1--;
                $("#tbAgentRule tr:eq(" + (i1+2) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow2() {
            i2++;
            var html = '<tr id="trRewardRule' + i2 + '" style="border:none;"><td style="border:none;"><input type="text" id="txtRewardRuleMoneyPerSet' + i2 + '" style="width:90px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');"/>元/套，发放条件是<input type="text" id="txtRewardRuleCondition' + i2 + '" style="width:290px"/></td></tr>';
            $("#tbRewardRule").append(html);
        }

        function deleteRow2() {
            if (i2 > 1) {
                i2--;
                $("#tbRewardRule tr:eq(" + i2 + ")").remove();
            } else
                alert("不可删除第一行。");
        }
        
        function addRow3() {
            i3++;
            var html = '<tr id="trPayCond' + i3 + '">'
				+ '     <td><input type="text" id="txtPayCondSetNumber' + i3 + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtPayCondPriceRange' + i3 + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtPayCondUnitPrice' + i3 + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtPayCondActualComm' + i3 + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtPayCondRewardScale' + i3 + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtPayCondPayPerSet' + i3 + '" style="width:90%"/></td>'
				+ '     <td><input type="text" id="txtPayCondPayActualScale' + i3 + '" style="width:90%"/></td>'
				+ '</tr>';
            
            $("#tbPayCond").append(html);
        }

        function deleteRow3() {
            if (i3 > 1) {
                i3--;
                $("#tbPayCond tr:eq(" + (i3+2) + ")").remove();
            } else
                alert("不可删除第一行。");
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
        <div class="noprint">
		<%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>项目发展商额外奖金报备</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td style="width:20%;">申请部门</td>
					<td class="tl PL10"><input id="txtDepartment" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:150px;"/><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td>申请人</td>
					<td class="tl PL10">工号：<asp:TextBox ID="txtApplyForID" runat="server" Width="40px" onblur="getEmployee(this);"></asp:TextBox><span id="spanApplyFor" style="display:none;">&nbsp;&nbsp;&nbsp;&nbsp;姓名：<input id="txtApplyFor" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span></td>
				</tr>
                <tr>
					<td>回复电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtReplyPhone" runat="server" Width="100"></asp:TextBox></td>
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
                    <th colspan="4" style="line-height:25px;" >项目基本情况</th>
				</tr>
                <tr>
					<td>项目名称</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtProject" runat="server" Width="300"></asp:TextBox></td>
				</tr>
                <tr>
					<td>项目代理期</td>
					<td class="tl PL10"><asp:TextBox ID="txtAgentStartDate" runat="server" Width="70"></asp:TextBox>~<asp:TextBox ID="txtAgentEndDate" runat="server" Width="70"></asp:TextBox></td>
                    <td>客户保护期</td>
					<td class="tl PL10"><asp:TextBox ID="txtClientGuardStartDate" runat="server" Width="70"></asp:TextBox>~<asp:TextBox ID="txtClientGuardEndDate" runat="server" Width="70"></asp:TextBox></td>
				</tr>
                <tr>
					<td colspan="4">项目代理标准
                        <table id="tbAgentRule" class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>
                                <td colspan="2">销售量</td>
                                <td rowspan="2">代理点数</td>
                            </tr>
                            <tr>
                                <td>套数</td>
                                <td>金额</td>
                            </tr>
                            <%=SbHtml1.ToString()%>
						</table>
                        <asp:HiddenField ID="hdAgentRule" runat="server" />
                        <input type="button" id="btnAddRow1" value="添加新行" onclick="addRow1();" style=" float:left; margin-left:5px; display:none;"/>
						<input type="button" id="btnDeleteRow1" value="删除一行" onclick="deleteRow1();" style=" float:left; display:none;"/>
					</td>
				</tr>
                <tr>
					<td>申请现金奖<br />有效期</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtApplyCashRewardValidityDurationStartDate" runat="server" Width="90px"></asp:TextBox>~<asp:TextBox ID="txtApplyCashRewardValidityDurationEndDate" runat="server" Width="90px"></asp:TextBox>（客户保护期内成交的单套发展商额外奖金按本申请执行）</td>
                    </tr>
                <tr>
					<td colspan="4" class="tl PL10">现金奖的标准及发放条件：<br />（公司只以第一层代理点数计算可得奖金，若因跳BAR存有差额不再补发，均按补报数处理，具体以财务操作为准）
                        <br /><asp:RadioButton ID="rdbFullPay" GroupName="cash" runat="server" Text="公司实收佣金比例≥3%，单套奖金金额≤公司实收佣金的15%，现金奖全额发放" />
                        <br /><asp:RadioButton ID="rdbRatePay" GroupName="cash" runat="server" Text="公司实收佣金比例≥3%，单套奖金金额超过公司实收佣金的15%，按公司实收佣的15%发放现金奖" /> 
                        <table id="tbRewardRule" class='sample tc' width='98%' style="border:none;">
							<%=SbHtml2.ToString()%>
                        </table>
                        <asp:HiddenField ID="hdRewardRule" runat="server" />
                        <input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style=" float:left; display:none;"/>
						<input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style=" float:left; display:none;"/>
                        <table id="tbPayCond" class='sample tc' width='98%'>
                            <tr>
                                <td rowspan="2">货量（套）</td>
                                <td rowspan="2">价格区间<br />（万元）</td>
                                <td rowspan="2">单套均价<br />（万元）</td>
                                <td rowspan="2">公司实收佣<br />（元）</td>
                                <td rowspan="2">奖金比例<br />（%）</td>
                                <td colspan="2">可发放奖金</td>
                            </tr>
                            <tr>
                                <td>金额（元/套）</td>
                                <td>奖金实际<br />发放比例</td>
                            </tr>
                            <%=SbHtml3.ToString()%>
                        </table>
                        <asp:HiddenField ID="hdPayCond" runat="server" />
                        <input type="button" id="btnAddRow3" value="添加新行" onclick="addRow3();" style=" float:left; display:none;"/>
						<input type="button" id="btnDeleteRow3" value="删除一行" onclick="deleteRow3();" style=" float:left; display:none;"/>

                        <br /><br />备注：
                        <br />①公司实收佣金比例≥3%的项目及单套奖金金额≤公司实收佣金的15%的情况下，才具备申请并获批发展商发放额外奖金予成交同事的资格。
                        <br />②奖金发放符合①要求时，可发放的比例为100%，若不符合①要求，则最多只能按公司实收佣的15%来计算可发放的金额，其余则上缴公司。（上述方法比例均含公司30%部份）
                        <br />③上缴公司部分，按正常计算业绩但不再计提佣金。
                        <br />④奖金实际发放比例=可发放奖金/发展商奖金。
					</td>
				</tr>
                <tr>
                    <td>是否与行家联合代理或轮流代理</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbJOrT1" runat="server" GroupName="JOrT" Text="与行家同场联合代理" /><br />
                        <asp:RadioButton ID="rdbJOrT2" runat="server" GroupName="JOrT" Text="与行家轮流代理，即代理期内中原独家代理，代理期之外由行家轮流代理" /><br />
                        <asp:RadioButton ID="rdbJOrT3" runat="server" GroupName="JOrT" Text="整个项目由中原独家代理，发展商没有委托除中原以外的任何代理行" />
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
                    <th colspan="4" style="line-height:25px;" >现金奖的发放方式及操作</th>
				</tr>
                <tr>
					<td colspan="4" class="tl PL10">
                        <asp:RadioButton ID="rdbRewardPayType1" GroupName="type" runat="server" Text="奖金由发展商划入公司帐户，随薪佣发放。" />
                        <br /><asp:RadioButton ID="rdbRewardPayType2" GroupName="type" runat="server" Text="奖金由发展商直接支付现金。" /> 
                        <br />现金奖发放统筹人员姓名：<asp:TextBox ID="txtPayerName" runat="server" Width="90"></asp:TextBox>，职务<asp:TextBox ID="txtPayerPosition" runat="server" Width="90"></asp:TextBox>，联系电话<asp:TextBox ID="txtPayerPhone" runat="server" Width="90"></asp:TextBox>                 
                        <br />接收现金奖银行帐号：帐户姓名：<asp:TextBox ID="txtRecevieCashRewardAccountName" runat="server" Width="90"></asp:TextBox>帐号：<asp:TextBox ID="txtRecevieCashRewardAccounts" runat="server" Width="200"></asp:TextBox><br />(此项是奖金如存在有条件发放或有滞留发放的可能时才需填写，接收人须是区域负责人)
                        <br />现金奖是否需开具发票并由我司支付税费？ <asp:RadioButton ID="rdbIsNeedPayFee" GroupName="fee" runat="server" Text="是" /> <asp:RadioButton ID="rdbIsNotNeedPayFee" GroupName="fee" runat="server" Text="否" /> 
                        <br /><asp:RadioButton ID="rdbRewardPayType3" GroupName="type" runat="server" Text="其他情况" /> <%--<asp:TextBox ID="txtRewardPayTypeOtherCase" runat="server" Width="400"></asp:TextBox>--%>
                        <textarea id="txtRewardPayTypeOtherCase" runat="server" style="width:400px;"></textarea>
					</td>
				</tr>
                <%=SbHtml4.ToString() %>
                <tr>
                    <th colspan="4" style="line-height:25px;" >其他情况补充</th>
				</tr>
                <tr>
					<td colspan="4" class="tl PL10">(1)区域保证现金奖须在客户支付首期款并签订买卖合同后再发放。
                        <br />(2)区域是否已提交发展商奖金确认书？<asp:RadioButton ID="rdbIsSubmitConfirmation" GroupName="book" runat="server" Text="是" /><label for="r2d2b2"></label><asp:RadioButton ID="rdbIsNotSubmitConfirmation" GroupName="book" runat="server" Text="否" />，区域承诺在<asp:TextBox ID="txtAreaPromiseSubmitDate" runat="server" Width="90"></asp:TextBox>前交回公司（发展商奖金确认书的发放方案必须与本报备内容一致，否则须重上报备）</td>
				</tr>
				<tr>
                    <th colspan="4" style="line-height:25px;" >审批流程</th>
				</tr>
                <tr id="trManager1" class="noborder" style="height: 85px;">
					<td style=" ">申请人</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
                <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td style=" ">申请部门负责人</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <td style=" ">二级市场负责人<br />（项目部）<br />或<br />三级市场负责人<br />（物业部）</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
			</table>
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