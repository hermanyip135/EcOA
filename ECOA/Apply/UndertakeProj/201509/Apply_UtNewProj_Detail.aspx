<%@ Page ValidateRequest="false" Title="物业部承接新项目申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_UtNewProj_Detail.aspx.cs" Inherits="Apply_UtNewProj_Apply_UtNewProj_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
	    var i1 = 1, i2 = 1, i3 = 1, cou = 0*1;
	    var jJSON = <%=SbJson.ToString() %>;
        var isUploaded = 0;
        var isNewApply=('<%=IsNewApply%>'=='True');
        var jsccesp = <%=SbCcesp.ToString() %>;

        $(function () {
            if(!$("[id*=cblDealOfficeType_3]").prop("checked"))
                $("#Ct4").hide();
            else
                $("#Ct4").show();
            $("[id*=cblDealOfficeType_3]").click(function(){
                if(!$("[id*=cblDealOfficeType_3]").prop("checked"))
                    $("#Ct4").hide();
                else
                    $("#Ct4").show();
            });


            $("#<%=cbBaseAgent2.ClientID%>").click(function () { //M_0001：20151016
                if ($("#<%=cbBaseAgent2.ClientID%>").prop("checked")) {
                    alert("注意：公司不建议承接行家做内场刀手的项目，选了该项则无法保存！");
                }
            });
            $("#<%=cbBaseAgent3.ClientID%>").click(function () {
                if ($("#<%=cbBaseAgent3.ClientID%>").prop("checked")) {
	                alert("注意：公司不建议承接行家做内场刀手的项目，选了该项则无法保存！");
	            }
	        });
            $("[for^=rdbOtherIDx]").css("color","#186ebe");

            $("#<%=rdbProjFear1.ClientID %>").attr("disabled","disabled");
            $("#<%=rdbProjFear2.ClientID %>").attr("disabled","disabled");

            if ($("#<%=rdbJOrT3.ClientID%>").prop("checked")){
                $("#<%=rdbProjFear1.ClientID %>").removeAttr("disabled");
                $("#<%=rdbProjFear2.ClientID %>").removeAttr("disabled");
            }
                
            $("#<%=rdbJOrT3.ClientID%>").click(function () {
                $("#<%=rdbProjFear1.ClientID %>").removeAttr("disabled");
                $("#<%=rdbProjFear2.ClientID %>").removeAttr("disabled");
            });
            $("#<%=rdbJOrT1.ClientID%>").click(function () {
                $("#<%=rdbProjFear2.ClientID %>").attr("checked",false);
                $("#<%=rdbProjFear1.ClientID %>").attr("checked","checked");
                $("#<%=rdbProjFear1.ClientID %>").attr("disabled","disabled");
                $("#<%=rdbProjFear2.ClientID %>").attr("disabled","disabled");
            });
            $("#<%=rdbJOrT2.ClientID%>").click(function () {
                $("#<%=rdbProjFear2.ClientID %>").attr("checked",false);
                $("#<%=rdbProjFear1.ClientID %>").attr("checked","checked");
                $("#<%=rdbProjFear1.ClientID %>").attr("disabled","disabled");
                $("#<%=rdbProjFear2.ClientID %>").attr("disabled","disabled");
            });

	        $("#<%=txtDepartment.ClientID %>").autocomplete({ 
	            source: jJSON
	        });

            $("#<%=txtProject.ClientID %>").autocomplete({ 
                source: jsccesp,
                select: function(event,ui) {
                    $("#<% =hfKey1.ClientID%>").val(ui.item.id);
                    $("#<%=txtDepartment.ClientID %>").focus();
                }
            });
            //$("#<%=txtProject.ClientID%>").blur(function(){
            //    if($("#<% =hfKey1.ClientID%>").val() == "")
            //        $("#<%=txtProject.ClientID%>").val("");
            //});
            //$("#<%=txtProject.ClientID%>").click(function(){
            //    $("#<%=txtProject.ClientID%>").val("");
            //});

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

	        $("#tOwner").find("td").css("border", "none");
	        $("#tClient").find("td").css("border", "none");
	        $("#tEB").find("td").css("border", "none");
	        $("#<%=txtAgentStartDate.ClientID%>").datepicker();
	        $("#<%=txtAgentEndDate.ClientID%>").datepicker();
	        $("#<%=txtClientGuardStartDate.ClientID%>").datepicker();
	        $("#<%=txtClientGuardEndDate.ClientID%>").datepicker();
	        $("#<%=txtReturnBackDate.ClientID%>").datepicker();
	        $("#<%=txtReturnBackDate.ClientID%>").datepicker();

	        i1 = $("#tOwner tr").length;
	        i2 = $("#tClient tr").length;

	        if ($("#<%=rdbIsMyPay3.ClientID%>").prop("checked"))
	            $("#COtherCondtion").show();
	        $("#<%=rdbIsMyPay3.ClientID%>").click(function () {
	            $("#COtherCondtion").show();
	        });
	        $("#<%=rdbIsMyPay2.ClientID%>").click(function () {
	            $("#COtherCondtion").hide();
	        });
	        $("#<%=rdbIsMyPay1.ClientID%>").click(function () {
	            $("#COtherCondtion").hide();
	        });
	        if ($("#<%=rdbHaveSingleReward4.ClientID%>").prop("checked"))
	            $("#AnotherRewardC").show();
	        $("#<%=rdbHaveSingleReward4.ClientID%>").click(function () {
	            $("#AnotherRewardC").show();
	        });
	        $("#<%=rdbHaveSingleReward1.ClientID%>").click(function () {
	            $("#AnotherRewardC").hide();
	        });
	        $("#<%=rdbHaveSingleReward2.ClientID%>").click(function () {
	            $("#AnotherRewardC").hide();
	        });
	        $("#<%=rdbHaveSingleReward3.ClientID%>").click(function () {
	            $("#AnotherRewardC").hide();
	        });

	        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
	        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx210"));
	        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));

	        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
	    });
        function AutoAdd() {
            if (!isNaN($("#<%=txtOwnerCommFixScale.ClientID%>").val()) && $("#<%=txtOwnerCommFixScale.ClientID%>").val() * 1 <= 100)
                cou += $("#<%=txtOwnerCommFixScale.ClientID%>").val() * 1;
            if (!isNaN($("#<%=txtClientCommFixScale.ClientID%>").val()) && $("#<%=txtClientCommFixScale.ClientID%>").val() * 1 <= 100)
                cou += $("#<%=txtClientCommFixScale.ClientID%>").val() * 1
            if (!isNaN($("#<%=txtEBComm.ClientID%>").val()) && $("#<%=txtEBComm.ClientID%>").val() * 1 <= 100)
                cou += $("#<%=txtEBComm.ClientID%>").val() * 1;

            for (var ih = 1; ih <= $("[id^=txtOwnerCommFloatScale]").size(); ih++) {
                if (!isNaN($("#txtOwnerCommFloatScale" + ih).val()) && $("#txtOwnerCommFloatScale" + ih).val() * 1 <= 100)
                    cou += $("#txtOwnerCommFloatScale" + ih).val() * 1;
            }
            for (var ih = 1; ih <= $("[id^=txtClientCommFloatScale]").size() ; ih++) {
                if (!isNaN($("#txtClientCommFloatScale" + ih).val()) && $("#txtClientCommFloatScale" + ih).val() * 1 <= 100)
                    cou += $("#txtClientCommFloatScale" + ih).val() * 1;
            }
            for (var ih = 1; ih <= $("[id^=txtEBCommFloatScale]").size() ; ih++) {
                if (!isNaN($("#txtEBCommFloatScale" + ih).val()) && $("#txtEBCommFloatScale" + ih).val() * 1 <= 100)
                    cou += $("#txtEBCommFloatScale" + ih).val() * 1;
            }
            if (cou * 1 < 3) {
                $("#SingleRewardC1").hide();
                //$("#SingleRewardC4").hide();
                $("#SingleRewardC2").show();
                $("#SingleRewardC3").show();
                //$("#<%=rdbHaveSingleReward2.ClientID%>").click();
                //$("#AnotherRewardC").hide();
            }
            else {
                $("#SingleRewardC1").show();
                $("#SingleRewardC2").show();
                $("#SingleRewardC3").show();
                $("#SingleRewardC4").show();
            }
            $("#<%=HdAutoAdd.ClientID%>").val(cou);
            cou = 0;
        }

        function check() {
            if(isUploaded < 1 
                && isNewApply
                && !$("#<%=cbLack1.ClientID%>").prop("checked")
                && !$("#<%=cbLack2.ClientID%>").prop("checked")
                && !$("#<%=cbLack3.ClientID%>").prop("checked")
                && !$("#<%=cbLack4.ClientID%>").prop("checked")
                && !$("#<%=cbLack5.ClientID%>").prop("checked")
                && !$("#<%=cbLack6.ClientID%>").prop("checked")
                )
            {
                alert("请上传相关的附件，如果没有，则勾选相关的欠交资料！");
                $("#<%=cbLack1.ClientID%>").focus();
                return false;
            }
            if ($("#<%=cbBaseAgent2.ClientID%>").prop("checked") || $("#<%=cbBaseAgent3.ClientID%>").prop("checked")) { //M_0001：20151016
                alert("场内代理选了合富辉煌或世联则无法保存！");
                $("#<%=cbBaseAgent2.ClientID%>").focus();
                return false;
            }
            if ($.trim($("#<%=txtDepartment.ClientID%>").val()) == "") {alert("申请部门不可为空！");$("#<%=txtDepartment.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtProject.ClientID%>").val()) == "") {alert("项目名称不可为空！");$("#<%=txtProject.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtDeveloper.ClientID %>").val()) == "") { alert("项目发展商(小业主)不可为空！"); $("#<%=txtDeveloper.ClientID %>").focus(); return false; }
            if ($.trim($("#<%=ddlDealType.ClientID%>").val()) == "") {alert("请选择代理类型！");$("#<%=ddlDealType.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtProjectArea.ClientID%>").val()) == "") {alert("项目所在区域不可为空！");$("#<%=txtProjectArea.ClientID%>").focus();return false;}

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
            if ($.trim($("#<%=txtTermsOfContract.ClientID%>").val()) == "") { alert("代理合同约定的佣金支付条件不可为空！"); $("#<%=txtTermsOfContract.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtTermsOfMajorIssues.ClientID%>").val()) == "") { alert("重大问题的合同条款不可为空！"); $("#<%=txtTermsOfMajorIssues.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtReportAddress.ClientID%>").val()) == "") { alert("报数地址不可为空！"); $("#<%=txtReportAddress.ClientID%>").focus(); return false; }

            if ($("#<%=txtTermsOfContract.ClientID%>").val().length > 123) {
                alert("代理合同约定的佣金支付条件不要超过123个字（3行）。");
                $("#<%=txtTermsOfContract.ClientID%>").focus();
                return false;
            }

            if (
                    !$("#<%=cbBaseAgent1.ClientID %>").prop("checked")
                    && !$("#<%=cbBaseAgent2.ClientID %>").prop("checked")
                    && !$("#<%=cbBaseAgent3.ClientID %>").prop("checked")
                    && !$("#<%=cbBaseAgent4.ClientID %>").prop("checked")
               ) {
                alert("请选择场内代理");
                $("#<%=cbBaseAgent1.ClientID%>").focus();
                return false;
            }
            if ($("#<%=cbBaseAgent4.ClientID %>").prop("checked") && $.trim($("#<%=txtBaseAgentOther.ClientID%>").val()) == "") {
                alert("请填写其它的场内代理");
                $("#<%=txtBaseAgentOther.ClientID%>").focus();
                return false;
            }

	        if (!$("#<%=rdbJOrT1.ClientID%>").prop("checked") && !$("#<%=rdbJOrT2.ClientID%>").prop("checked") && !$("#<%=rdbJOrT3.ClientID%>").prop("checked")) {
	            alert("请选择是否与行家联合代理或轮流代理");
	            $("#<%=rdbJOrT1.ClientID%>").focus();
	            return false;
	        }

            if ($("[id*=cblDealOfficeType_3]").prop("checked")) {
                if (!$("#<%=rdbIsStree1.ClientID%>").prop("checked") && !$("#<%=rdbIsStree2.ClientID%>").prop("checked")) {
                    alert("请选择是否临街商铺");
                    $("#<%=rdbIsStree1.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsMarking1.ClientID%>").prop("checked") && !$("#<%=rdbIsMarking2.ClientID%>").prop("checked")) {
                    alert("请选择是否商场拆细");
                    $("#<%=rdbIsMarking1.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsBusiness1.ClientID%>").prop("checked") && !$("#<%=rdbIsBusiness2.ClientID%>").prop("checked")) {
                    alert("请选择商场是否已在经营");
                    $("#<%=rdbIsBusiness1.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsBackRent1.ClientID%>").prop("checked") && !$("#<%=rdbIsBackRent2.ClientID%>").prop("checked")) {
                    alert("请选择是否存在返租条款");
                    $("#<%=rdbIsBackRent1.ClientID%>").focus();
                    return false;
                }
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

	        if (!$("#<%=rdbOwnerCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbOwnerCommJump2.ClientID%>").prop("checked")) {
	            alert("请选择业佣跳BAR方式");
	            $("#<%=rdbOwnerCommJump1.ClientID%>").focus();
	            return false;
	        }
	        //if (!$("#<%=rdbClientCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbClientCommJump2.ClientID%>").prop("checked")) {
	        //    alert("请选择客佣跳BAR方式");
	        //    $("#<%=rdbClientCommJump1.ClientID%>").focus();
	       //     return false;
	        //}
	        if (!$("#<%=rdbEBCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbEBCommJump2.ClientID%>").prop("checked")) {
	            alert("请选择电商佣跳BAR方式");
	            $("#<%=rdbEBCommJump1.ClientID%>").focus();
	            return false;
	        }
	        if (!$("#<%=rdbHaveSingleReward1.ClientID%>").prop("checked") && $("#<%=rdbHaveSingleReward1.ClientID%>").parent().css("display") != "none" && !$("#<%=rdbHaveSingleReward2.ClientID%>").prop("checked") && !$("#<%=rdbHaveSingleReward3.ClientID%>").prop("checked") && !$("#<%=rdbHaveSingleReward4.ClientID%>").prop("checked")) {
	            alert("请选择是否有单套现金奖");
	            $("#<%=rdbHaveSingleReward1.ClientID%>").focus();
	            return false;
	        }
	        else if ($("#<%=rdbHaveSingleReward1.ClientID%>").parent().css("display") == "none" && !$("#<%=rdbHaveSingleReward2.ClientID%>").prop("checked") && !$("#<%=rdbHaveSingleReward3.ClientID%>").prop("checked") && !$("#<%=rdbHaveSingleReward4.ClientID%>").prop("checked")) {
	            alert("请选择是否有单套现金奖");
	            $("#<%=rdbHaveSingleReward2.ClientID%>").focus();
	            return false;
            }
	        if ($("#<%=rdbHaveSingleReward1.ClientID%>").prop("checked")){
	            if ($.trim($("#<%=txtRewardSignHave.ClientID%>").val()) == "") {
	                alert("大于3%的单套现金奖不可为空！");
	                $("#<%=txtRewardSignHave.ClientID%>").focus();
	                return false;
	            }
	            if (isNaN($("#<%=txtRewardSignHave.ClientID%>").val())) {
	                alert("大于3%的单套现金奖必须输入纯数字");
	                $("#<%=txtRewardSignHave.ClientID%>").focus();
	                return false;
	            }
	        }

	        if (!$("#<%=rdbHaveSingleReward3.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtDeveloperConditions.ClientID%>").val()) == "") { alert("发展商支付现金奖条件不可为空！"); $("#<%=txtDeveloperConditions.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtAreaConditions.ClientID%>").val()) == "") { alert("区域派发现金奖条件不可为空！"); $("#<%=txtAreaConditions.ClientID%>").focus(); return false; }
	            if (!$("#<%=rdbPayRewardWay1.ClientID%>").prop("checked") && !$("#<%=rdbPayRewardWay2.ClientID%>").prop("checked")) {
	                alert("请选择现金奖的发放方式");
	                $("#<%=rdbPayRewardWay1.ClientID%>").focus();
	                return false;
	            }
	            if (!$("#<%=rdbIsMyPay1.ClientID%>").prop("checked") && !$("#<%=rdbIsMyPay2.ClientID%>").prop("checked") && !$("#<%=rdbIsMyPay3.ClientID%>").prop("checked")) {
	                alert("请选择现金奖是否需开具发票并由我司支付税费");
	                $("#<%=rdbIsMyPay1.ClientID%>").focus();
	                return false;
	            }
	            if (!$("#<%=rdbAreaComfirn1.ClientID%>").prop("checked") && !$("#<%=rdbAreaComfirn2.ClientID%>").prop("checked")) {
	                alert("请选择区域是否已提交发展商奖金确认书");
	                $("#<%=rdbAreaComfirn1.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=rdbAreaComfirn2.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtReturnBackDate.ClientID%>").val()) == "") {
	                    alert("区域承诺交回公司时间不可为空！");
	                    $("#<%=txtReturnBackDate.ClientID%>").focus();
	                    return false;
	                }
	            }
	        }
	        if ($("#COtherCondtion").css("display")!="none"&&$.trim($("#<%=txtOtherCondtion.ClientID%>").val()) == "") {
	            alert("由于您选了其它情况，请填写现金奖发放方式的其它情况");
	            $("#<%=txtOtherCondtion.ClientID%>").focus();
	            return false;
	        }

	        if ($("#AnotherRewardC").css("display") != "none" && $.trim($("#<%=txtAnotherRewardC.ClientID%>").val()) == "") {
	            alert("由于您选了其它情况，请填写单套现金奖的其它情况");
	            $("#<%=txtAnotherRewardC.ClientID%>").focus();
	            return false;
            }

	        if (!$("#<%=rdbSaleMode1.ClientID%>").prop("checked") && !$("#<%=rdbSaleMode2.ClientID%>").prop("checked")) {
	            alert("请选择销售模式");
	            return false;
	        }
	        else if ($("#<%=rdbSaleMode1.ClientID%>").prop("checked")) {
	            if ($("#<%=txtMainAreaScale.ClientID%>").val() == "") {
	                alert("由于您选择了独立接盘，请填写统筹区拆分成交占比。");
                        $("#<%=txtMainAreaScale.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=txtDealAreaScale.ClientID%>").val() == "") {
                    alert("由于您选择了独立接盘，请填写成交区域占比。");
                        $("#<%=txtDealAreaScale.ClientID%>").focus();
	                return false;
                }
	            if ($("#<%=txtAreaScale1.ClientID%>").val() == "") {
	                alert("由于您选择了独立接盘，请填写统筹区名称。");
	                $("#<%=txtAreaScale1.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtMainAreaScale.ClientID%>").val() > 15) {
	                alert("统筹区合计拆分成交设只能小于或等于15%！");
	                $("#<%=txtMainAreaScale.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=txtDealAreaScale.ClientID%>").val() < 85) {
	                alert("成交区拆分设置只能大于或等于85%！");
	                $("#<%=txtDealAreaScale.ClientID%>").focus();
	                return false;
                }
            }
	        else if ($("#<%=rdbSaleMode2.ClientID%>").prop("checked")) {
	            if ($("#<%=txtMainAreaScale2.ClientID%>").val() == "") {
	                alert("由于您选择了合作接盘，请填写统筹区合计拆分成交占比。");
	                    $("#<%=txtMainAreaScale2.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtDealAreaScale2.ClientID%>").val() == "") {
	                alert("由于您选择了合作接盘，请填写成交区域占比。");
	                    $("#<%=txtDealAreaScale2.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtMainAreaScale2.ClientID%>").val() > 15) {
	                alert("统筹区合计拆分成交设只能小于或等于15%！");
	                $("#<%=txtMainAreaScale2.ClientID%>").focus();
	            return false;
                }
                if ($("#<%=txtDealAreaScale2.ClientID%>").val() < 85) {
                    alert("成交区拆分设置只能大于或等于85%！");
	                $("#<%=txtDealAreaScale2.ClientID%>").focus();
	            return false;
                }
	            
	        }

	        var data = "";
	        var flag = true;
	        $("#tOwner tr").each(function (i) {
	            var n = i + 1;
	            //if (isNaN($("#txtOwnerCommFloatScale" + n).val())) {
	            //    alert("业佣的合同代理费必须输入纯数字");
	            //    $("#txtOwnerCommFloatScale" + n).focus();
	            //    flag = false;
	            //}
	            //else
	                data += $.trim($("#txtOwnerCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatKind" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatScale" + n).val()) + "&&" + $.trim($("#txtOwnerCommPublishedScale" + n).val()) + "||";
	        });
	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdOwner.ClientID%>").val(data);
	        }

	        data = "";

	        $("#tClient tr").each(function (i) {
	            var n = i + 1;
	            data += $.trim($("#txtClientCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtClientCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtClientCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtClientCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtClientCommFloatScale" + n).val()) + "&&" + $.trim($("#txtClientCommPublishedScale" + n).val()) + "||";
	        });
	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdClient.ClientID%>").val(data);
	        }
	        data = "";

	        $("#tEB tr").each(function (i) {
	            var n = i + 1;
	            data += $.trim($("#txtEBCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtEBCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtEBCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtEBCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtEBCommFloatKind" + n).val()) + "&&" + $.trim($("#txtEBCommFloatScale" + n).val()) + "&&" + $.trim($("#txtEBCommPublishedScale" + n).val()) + "||";
	        });
	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdEB.ClientID%>").val(data);
	        }
	        if (flag)
	            return true;
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
            var sReturnValue = window.showModalDialog("/Apply/Tourism/Apply_UploadFile.aspx?MainID=<%=MainID%>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID%>', "dialogHeight=165px");
		    //if(sReturnValue=='success')
            //    window.location = 'Apply_UtNewProj_Detail.aspx?MainID=<%=MainID%>';
            if(sReturnValue!=null)
            {
                if(isNewApply)
                {
                    isUploaded += 1;
                    if($("#spm").html() == "")
                        $("#spm").html("<br />您已上传了：<br />" + sReturnValue);
                    else
                        $("#spm").append("<br />" + sReturnValue);
                }
                else
                    window.location='Apply_UtNewProj_Detail.aspx?MainID=<%=MainID %>';
            }
        }

        function editflow(){
            var win=window.showModalDialog("Apply_UtProj_Flow.aspx?MainID=<%=MainID%>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location = "Apply_UtNewProj_Detail.aspx?MainID=<%=MainID%>";
        }

        function CancelSign(idc) {
            if (confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }

	    function sign(idx) {
	        if (idx == '1'||idx == '2') {
	            if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
	                alert("请确定同意或其它同意！");
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

        function addRow1() {//*-
            i1++;
            var html = '<tr id="trOwner' + i1 + '"  style="border:none;">'
				+ '     <td style="border:none;"><input type="text" id="txtOwnerCommFloatSetNumberStart' + i1 + '" style="width:50px"/>至<input type="text" id="txtOwnerCommFloatSetNumberEnd' + i1 + '" style="width:50px"/>套/<input type="text" id="txtOwnerCommFloatMoneyStart' + i1 + '" style="width:50px"/>至<input type="text" id="txtOwnerCommFloatMoneyEnd' + i1 + '" style="width:50px"/>元销售额，<input type="text" id="txtOwnerCommFloatKind' + i1 + '" style="width:80px"/>（填写住宅/公寓/别墅等不同类型）合同代理费<input type="text" id="txtOwnerCommFloatScale' + i1 + '" style="width:50px"/>%，公布代理费<input type="text" id="txtOwnerCommPublishedScale' + i1 + '" style="width:50px"/>%</td>'
				+ '</tr>';
            $("#tOwner").append(html);
        }

        function deleteRow1() {
            if (i1 > 2) {
                i1--;
                $("#tOwner tr:eq(" + i1 + ")").remove();
                AutoAdd();
            } 
            else
                alert("不可再删除。");
        }

        function addRow2() {
            i2++;
            var html = '<tr id="trClient' + i2 + '"  style="border:none;">'
				+ '     <td style="border:none;"><input type="text" id="txtClientCommFloatSetNumberStart' + i2 + '" style="width:50px"/>至<input type="text" id="txtClientCommFloatSetNumberEnd' + i2 + '" style="width:50px"/>套/<input type="text" id="txtClientCommFloatMoneyStart' + i2 + '" style="width:50px"/>至<input type="text" id="txtClientCommFloatMoneyEnd' + i2 + '" style="width:50px"/>元销售额，合同代理费<input type="text" id="txtClientCommFloatScale' + i2 + '" style="width:50px"/>%，公布代理费<input type="text" id="txtClientCommPublishedScale' + i2 + '" style="width:50px"/>%</td>'
				+ '</tr>';

            $("#tClient").append(html);
        }

        function deleteRow2() {
            if (i2 > 2) {
                i2--;
                $("#tClient tr:eq(" + i2 + ")").remove();
                AutoAdd();
            }
            else
                alert("不可再删除。");
        }

        function addRow3() {
            i3++;
            var html = '<tr id="trEB' + i3 + '"  style="border:none;">'
				+ '     <td style="border:none;"><input type="text" id="txtEBCommFloatSetNumberStart' + i3 + '" style="width:50px"/>至<input type="text" id="txtEBCommFloatSetNumberEnd' + i3 + '" style="width:50px"/>套/<input type="text" id="txtEBCommFloatMoneyStart' + i3 + '" style="width:50px"/>至<input type="text" id="txtEBCommFloatMoneyEnd' + i2 + '" style="width:50px"/>元销售额，<input type="text" id="txtEBCommFloatKind' + i1 + '" style="width:80px"/>（填写住宅/公寓/别墅等不同类型）合同代理费<input type="text" id="txtEBCommFloatScale' + i3 + '" style="width:50px"/>%，公布代理费<input type="text" id="txtEBCommPublishedScale' + i3 + '" style="width:50px"/>%</td>'
				+ '</tr>';

            $("#tEB").append(html);
        }

        function deleteRow3() {
            if (i3 > 2) {
                i3--;
                $("#tEB tr:eq(" + i3 + ")").remove();
                AutoAdd();
            }
            else
                alert("不可再删除。");
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
    <style type="text/css">
        .auto-style1 {
            width: 204px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
		<%=SbFlow.ToString()%>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>物业部承接新项目申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:720px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber%></span></div>
			<%--style="border-style:double; border-color:Black; border-width:5px; margin: 0 auto; background-color: #fff; border-collapse: collapse;" --%>
            <table id="tbAround" width='720px'>
                <tr>
                    <td>项目名称</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtProject" runat="server" Width="92%"></asp:TextBox></td>
                </tr>
				<tr>
					<td style="width:20%">申请部门</td>
					<td class="tl PL10"><asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
					<td style="width:20%">申请人</td>
                    <td class="tl PL10"><asp:TextBox ID="txtApply" runat="server" Width="70px"></asp:TextBox>　- <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
                    <td>项目发展商<br />(小业主)</td>
					<td class="tl PL10"><asp:TextBox ID="txtDeveloper" runat="server"></asp:TextBox></td>
                    <td>所属集团名称</td>
					<td class="tl PL10"><asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>场内代理</td>
                    <td class="tl PL10" colspan="3">
                        <asp:CheckBox ID="cbBaseAgent1" runat="server" Text="中原项目部" />
                        <asp:CheckBox ID="cbBaseAgent2" runat="server" Text="合富辉煌" />
                        <asp:CheckBox ID="cbBaseAgent3" runat="server" Text="世联" />
                        <asp:CheckBox ID="cbBaseAgent4" runat="server" Text="其它" />
                        <asp:TextBox ID="txtBaseAgentOther" runat="server" Width="270px"></asp:TextBox>
                    </td>
				</tr>
                <tr>
					<td>代理类型</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlDealType" runat="server" Width="100px"></asp:DropDownList></td>
				    <td>项目所在区域</td>
					<td class="tl PL10"><asp:TextBox ID="txtProjectArea" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td>物业性质</td>
					<td class="tl PL10" colspan="3">
                        <asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="cblDealOfficeType_SelectedIndexChanged"></asp:CheckBoxList>
                        <asp:HiddenField ID="hdDealOfficeType" runat="server" />
					</td>
				</tr>
                <tr id="Ct4">
                    <td class="tl PL10" colspan="4">
                       <%--（只要勾选了“商铺”就必须上传现场照片及平面图并必须勾选以下四项，申请表附上传资料清单，若没有勾选商铺，则无需显示以下四项）<br />--%>
                        是否临街商铺：<asp:RadioButton ID="rdbIsStree1" runat="server" GroupName="rdbIsStree" Text="是" /><asp:RadioButton ID="rdbIsStree2" runat="server" GroupName="rdbIsStree" Text="否" />（须报集团审批）　　　　　　　　　　
                        是否商场拆细：<asp:RadioButton ID="rdbIsMarking1" runat="server" GroupName="rdbIsMarking" Text="是" />（须报集团审批）<asp:RadioButton ID="rdbIsMarking2" runat="server" GroupName="rdbIsMarking" Text="否" /><br />
                        商场是否已在经营：<asp:RadioButton ID="rdbIsBusiness1" runat="server" GroupName="rdbIsBusiness" Text="是" /><asp:RadioButton ID="rdbIsBusiness2" runat="server" GroupName="rdbIsBusiness" Text="否" />　　　　　　　　　　　　　　　　
                        是否存在返租条款：<asp:RadioButton ID="rdbIsBackRent1" runat="server" GroupName="rdbIsBackRent" Text="是" /><asp:RadioButton ID="rdbIsBackRent2" runat="server" GroupName="rdbIsBackRent" Text="否" /><br />
                    </td>
                </tr>
                <tr>
                    <td>项目地址</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtProjectAddress" runat="server" Width="92%"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>报数地址</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtReportAddress" runat="server" Width="92%"></asp:TextBox></td>
				</tr>
                <tr>
					<td>发展商<br />联系人</td>
					<td colspan="3" class="tl PL10">姓名<asp:TextBox ID="txtDeveloperContacter" runat="server" Width="100px"></asp:TextBox>职位<asp:TextBox ID="txtDeveloperContacterPosition" runat="server" Width="100px"></asp:TextBox>联系电话<asp:TextBox ID="txtDeveloperContacterPhone" runat="server" Width="100px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>区域统筹人</td>
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
					<td>我司是否与电商签约</td>
					<td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbIsCoopWithECommerce1" runat="server" Text="是，与房友圈签约，客户现场支付" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtCoopWithE1" runat="server" Width="70px"></asp:TextBox>元团购费（A）抵楼价
                        <asp:TextBox ID="txtCoopWithE2" runat="server" Width="70px"></asp:TextBox>，协议约定房友圈支付我司电商佣
                        <asp:TextBox ID="txtCoopWithE3" runat="server" Width="70px"></asp:TextBox>元（B），扣除10%营运费用后我司实得
                        <asp:TextBox ID="txtCoopWithE4" runat="server" Width="70px"></asp:TextBox>元，电商佣比例（C）（系统设公式C=B/A）
                        <asp:TextBox ID="txtCoopWithE5" runat="server" Width="70px"></asp:TextBox>%；若C<90%必须上传发展商或电商的盖章文件说明原因。<br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce2" runat="server" Text="是，与其他电商签约，电商公司名称" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName" runat="server" Width="300px"></asp:TextBox><br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce3" runat="server" Text="否，不需与电商签约，但客户需要在电商公司刷卡以获取买房优惠，电商公司名称" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName2" runat="server" Width="415px"></asp:TextBox><br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce4" runat="server" Text="否，整个项目没有任何电商参与" GroupName="CoopWithECommerce" />
					</td>
				</tr>
                <tr>
                    <td>是否与行家联合代理<br />或轮流代理</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbJOrT1" runat="server" GroupName="JOrT" Text="与行家同场联合代理" /><br />
                        <asp:RadioButton ID="rdbJOrT2" runat="server" GroupName="JOrT" Text="与行家轮流代理，即代理期内中原独家代理，代理期之外由行家轮流代理" /><br />
                        <asp:RadioButton ID="rdbJOrT3" runat="server" GroupName="JOrT" Text="整个项目由中原独家代理，发展商没有委托除中原以外的任何代理行" /><br />
                    </td>
                </tr>
                <tr>
                    <td>项目费用（合作费）</td>
                    <td class="tl PL10" colspan="3">
                        <asp:RadioButton ID="rdbProjFear1" runat="server" GroupName="rdbProjFear" Text="无" />
                        <asp:RadioButton ID="rdbProjFear2" runat="server" GroupName="rdbProjFear" Text="有" />（项目费用必须另上文申请提交黄生审批同意方可生效）<br />
                        当项目费用勾选“无”时，以下的合作费计提、合作费承担方式内容全部不显示，只需直接写代理费<br />
                        发展商佣合作费计提：<asp:TextBox ID="txtProjSum1" runat="server"></asp:TextBox><br />
                        电商佣合作费计提：<asp:TextBox ID="txtProjSum2" runat="server"></asp:TextBox><br />
                        （备注: 如项目同时有电商费用及合作费，需分别显示电商费用的比例及合作费的比例）<br />
                        扣除合作费后的发展商佣金+电商佣金：<asp:TextBox ID="txtProjSum3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
					<td>代理费</td>
					<td colspan="3" class="tl PL10">(1)发展商佣：（若要计算单套现金奖，合同代理费必须填写用来表示百分比的纯数字）
                        <br />固定收佣，合同代理费<asp:TextBox ID="txtOwnerCommFixScale" runat="server" Width="80px"></asp:TextBox>%，公布代理费（扣除合作费后实收）：<asp:TextBox ID="txtOwnerCommAgent" runat="server" Width="80px"></asp:TextBox>%<br />
				        变动收佣，其中<br />
                        <table id="tOwner" class='sample tc' width='100%' style="border:none;">
							<tr id="trOwner1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtOwnerCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtOwnerCommFloatSetNumberEnd1" style="width:50px"/>套/<input type="text" id="txtOwnerCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtOwnerCommFloatMoneyEnd1" style="width:50px"/>元销售额（套数及销售额二选一），<input type="text" id="txtOwnerCommFloatKind1" style="width:80px"/>（填写住宅/公寓/别墅等不同类型）合同代理费<input type="text" id="txtOwnerCommFloatScale1" style="width:50px"/>%，公布代理费<input type="text" id="txtOwnerCommPublishedScale1" style="width:50px"/>%</td>
				            </tr>
                            <%=SbHtml1.ToString()%>
                        </table>
                        佣金跳BAR方式：<asp:RadioButton ID="rdbOwnerCommJump1" runat="server" Text="全跳BAR" GroupName="OwnerCommJump" />
                        <asp:RadioButton ID="rdbOwnerCommJump2" runat="server" Text="分级跳BAR" GroupName="OwnerCommJump" /><br />
                        <asp:HiddenField ID="hdOwner" runat="server" />
                        <input type="button" id="btnAddRow1" value="添加新行" onclick="addRow1();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow1" value="删除一行" onclick="deleteRow1();" style=" float:left; display:none"/><br /><br />
                        
                        (2)客佣（如有）：<br />
                        <asp:TextBox ID="txtClientCommFixScale" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>

                        <div style="display:none;">
                            (2)客佣（如有）：（若要计算单套现金奖，合同代理费必须填写用来表示百分比的纯数字）
                            <br />固定收佣，合同代理费__________________%，公布代理费（扣除合作费后实收）：<asp:TextBox ID="txtClientCommAgent" runat="server" Width="80px">1</asp:TextBox>%<br />
                            变动收佣，其中<br />
					        <table id="tClient" class='sample tc' width='100%' style="border:none;">
                                <tr id="trClient1"  style="border:none;">
				                    <td style="border:none;"><input type="text" id="txtClientCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtClientCommFloatSetNumberEnd1" style="width:50px" value="1"/>套/<input type="text" id="txtClientCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtClientCommFloatMoneyEnd1" style="width:50px" value="1"/>元销售额，合同代理费<input type="text" id="txtClientCommFloatScale1" style="width:50px" value="1"/>%，公布代理费<input type="text" id="txtClientCommPublishedScale1" style="width:50px" value="1"/>%</td>
			                    </tr>
							    <%=SbHtml2.ToString()%>
					        </table>
                            佣金跳BAR方式：<asp:RadioButton ID="rdbClientCommJump1" runat="server" Text="全跳BAR" GroupName="ClientCommJump" Checked="True" />
                            <asp:RadioButton ID="rdbClientCommJump2" runat="server" Text="分级跳BAR" GroupName="ClientCommJump" /><br />
                            <asp:HiddenField ID="hdClient" runat="server" />
                            <input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style=" float:left; display:none"/>
						    <input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style=" float:left;display:none"/>
                        </div>
                        <br /><br />
                        
                        (3)电商佣：（若要计算单套现金奖，合同代理费必须填写用来表示百分比的纯数字）
                        <br />固定收佣，合同代理费<asp:TextBox ID="txtEBComm" runat="server" Width="70px"></asp:TextBox>%，公布代理费（扣除电商费用及合作费后实收）：<asp:TextBox ID="txtEBCommAgent" runat="server" Width="70px"></asp:TextBox>%<br />
                        变动收佣，其中<br />
					    <table id="tEB" class='sample tc' width='100%' style="border:none;">
                            <tr id="trEB1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtEBCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtEBCommFloatSetNumberEnd1" style="width:50px"/>套/<input type="text" id="txtEBCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>至<input type="text" id="txtEBCommFloatMoneyEnd1" style="width:50px"/>元销售额（套数及销售额二选一），<input type="text" id="txtEBCommFloatKind1" style="width:80px"/>（填写住宅/公寓/别墅等不同类型）合同代理费<input type="text" id="txtEBCommFloatScale1" style="width:50px"/>%，公布代理费<input type="text" id="txtEBCommPublishedScale1" style="width:50px"/>%</td>
			                </tr>
							<%=SbHtml3.ToString()%>
					    </table>
                        佣金跳BAR方式：<asp:RadioButton ID="rdbEBCommJump1" runat="server" Text="全跳BAR" GroupName="EBCommJump" />
                        <asp:RadioButton ID="rdbEBCommJump2" runat="server" Text="分级跳BAR" GroupName="EBCommJump" /><br />
                        <asp:HiddenField ID="hdEB" runat="server" />
                        <input type="button" id="btnAddRow3" value="添加新行" onclick="addRow3();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow3" value="删除一行" onclick="deleteRow3();" style=" float:left;display:none"/><br /><br />
                        代理费其他情况<br />
                        <asp:textbox id="txtRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:textbox>
                        <br />

                        单套现金奖：<br /><div id="SingleRewardC1">　　　　　<asp:RadioButton ID="rdbHaveSingleReward1" runat="server" Text="有，此项目实收佣金比例≥3%" GroupName="HaveSingleReward" />
                        ，现金奖<asp:TextBox ID="txtRewardSignHave" runat="server" Width="90px"></asp:TextBox>元/套，
                        现金奖的可发放金额=每套净佣金*15%（以发展商奖金为上限），可发放金额分配比例为：营业员44%，主管15%，区经8%，副总监/总监（O/R）3%，公司30%；超过每套净佣金的15%部分及公司30%部分全数上缴公司，可计入员工业绩，但不计算员工佣金</div>
                        <div id="SingleRewardC2">　　　　　<asp:RadioButton ID="rdbHaveSingleReward2" runat="server" Text="有，此项目实收佣金比例<3%" GroupName="HaveSingleReward" />，现金奖全数上缴公司，可计入员工业绩，但不计算员工佣金；</div> 　　　　　
                        <div id="SingleRewardC3">　　　　　<asp:RadioButton ID="rdbHaveSingleReward3" runat="server" Text="无，此项目不设现金奖。" GroupName="HaveSingleReward" /></div>　　　　　
                        <div id="SingleRewardC4">　　　　　<asp:RadioButton ID="rdbHaveSingleReward4" runat="server" Text="其他情况" GroupName="HaveSingleReward" /></div>
                        <div id="AnotherRewardC" style="display: none"><asp:TextBox ID="txtAnotherRewardC" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox></div><br />
                        现金奖的操作：<br />
                        （1）发展商支付现金奖的条件：<br />
                        <asp:TextBox ID="txtDeveloperConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
                        （2）区域派发现金奖给同事的条件：<br />
                        <asp:TextBox ID="txtAreaConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
	                    <span style="color: #FF0000;">（区域必须保证现金奖在无需退回给发展商的情况下再发放给同事，否则造成公司损失将由相关人员承担赔偿责任）</span><br /><br />
                        <div>现金奖的发放方式：</div>
                        <asp:RadioButton ID="rdbPayRewardWay1" runat="server" Text="奖金由发展商划入公司帐户，随薪佣发放。" GroupName="PayRewardWay" /><br />
                        <asp:RadioButton ID="rdbPayRewardWay2" runat="server" Text="奖金由发展商直接支付现金，接收人必须是申请部门负责人。" GroupName="PayRewardWay" /><br />
                        现金奖是否需开具发票并由我司支付税费？
                        <asp:RadioButton ID="rdbIsMyPay1" runat="server" Text="是" GroupName="IsMyPay" />
                        <asp:RadioButton ID="rdbIsMyPay2" runat="server" Text="否" GroupName="IsMyPay" />
                        <asp:RadioButton ID="rdbIsMyPay3" runat="server" Text="其他情况" GroupName="IsMyPay" Visible="False" />
                        <div id="COtherCondtion" style="display: none"><asp:TextBox ID="txtOtherCondtion" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox></div><br />
                        区域是否已提交发展商奖金确认书？
                        <asp:RadioButton ID="rdbAreaComfirn1" runat="server" Text="是" GroupName="AreaComfirn" />
                        <asp:RadioButton ID="rdbAreaComfirn2" runat="server" Text="否" GroupName="AreaComfirn" />，
                        区域承诺在<asp:TextBox ID="txtReturnBackDate" runat="server"></asp:TextBox>前交回公司

                        <br /><br />
                        代理合同约定的佣金支付条件<br />
                        <asp:TextBox ID="txtTermsOfContract" runat="server"  TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;" MaxLength="123"></asp:TextBox>
                        <br />
                        重大问题的合同条款（如违约赔偿条款、接盘区域限制等）<br />
                        <asp:TextBox ID="txtTermsOfMajorIssues" runat="server"  TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:TextBox>
					</td>
				</tr>
                <tr>
					<td>代理期</td>
					<td class="tl PL10"><asp:TextBox ID="txtAgentStartDate" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox ID="txtAgentEndDate" runat="server" Width="80px"></asp:TextBox></td>
                    <td>客户保护期（非必填项）</td>
					<td class="auto-style1"><asp:TextBox ID="txtClientGuardStartDate" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox ID="txtClientGuardEndDate" runat="server" Width="80px"></asp:TextBox></td>
				</tr>

                
                <tr>
                    <td>行家代理信息</td>
                    <td colspan="3"class="tl PL10">
                        <div>　若项目与行家同场联合代理或与轮流代理，以下为必填项，若因无渠道了解相关信息无法填写，敬请注明“无渠道了解相关信息”。</div><br />
                        1.名称：<asp:TextBox ID="txtSamePlaceXX1" runat="server" Width="200px"></asp:TextBox>
                        　代理费：<asp:TextBox ID="txtAgencyFee1" runat="server" Width="200px"></asp:TextBox><br />
                        　现金奖：<asp:RadioButton ID="rdbIsCashPrize11" runat="server" Text="有，" GroupName="CashPrize1" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize1" runat="server" Width="200px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize12" runat="server" Text="无" GroupName="CashPrize1" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear11" runat="server" Text="有，比例" GroupName="IsPFear1" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear1" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear12" runat="server" Text="无" GroupName="IsPFear1" /><br />
                        2.名称：<asp:TextBox ID="txtSamePlaceXX2" runat="server" Width="200px"></asp:TextBox>
                        　代理费：<asp:TextBox ID="txtAgencyFee2" runat="server" Width="200px"></asp:TextBox><br /><label for="r2d2b2"></label>
                        　现金奖：<asp:RadioButton ID="rdbIsCashPrize21" runat="server" Text="有，" GroupName="CashPrize2" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize2" runat="server" Width="200px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize22" runat="server" Text="无" GroupName="CashPrize2" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear21" runat="server" Text="有，比例" GroupName="IsPFear2" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear2" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear22" runat="server" Text="无" GroupName="IsPFear2" /><br />
                    </td>
                </tr>
                
                <tr>
					<td>申请部门接盘模式</td>
					<td colspan="3" class="tl PL10"><asp:RadioButton ID="rdbSaleMode1" runat="server" Text="独立接盘，" GroupName="SaleMode" /><label for="r2d2b2">统筹区<asp:TextBox ID="txtAreaScale1" runat="server" Width="110px"></asp:TextBox>拆分成交的<asp:TextBox ID="txtMainAreaScale" runat="server" Width="50px"></asp:TextBox>%， 成交区占<asp:TextBox ID="txtDealAreaScale" runat="server" Width="50px"></asp:TextBox>%</label>
                        <br />
                        <div style="margin-top: 10px; margin-bottom: 10px;">
                            <asp:RadioButton ID="rdbSaleMode2" runat="server" Text="合作接盘，统筹区" GroupName="SaleMode" Height="30px" />
                            <label for="r2d2b2"><asp:TextBox ID="txtAreaScale" runat="server" Width="70%" Height="40px" TextMode="MultiLine"></asp:TextBox>，
                            <br />（列明合作接盘的每个区拆分比例）
                            统筹区合计拆分成交的<asp:TextBox ID="txtMainAreaScale2" runat="server" Width="50px"></asp:TextBox>%，成交区拆分成交的<asp:TextBox ID="txtDealAreaScale2" runat="server" Width="50px"></asp:TextBox>%</label>
					    </div>
                    </td>
                </tr>
                <tr>
                    <td>广州中原<br />与其他分公司合作</td>
                    <td colspan="3" class="tl PL10">
                        1、合作公司：
                        <asp:CheckBox ID="cbNre1" runat="server" Text="佛山中原" />
                        <asp:CheckBox ID="cbNre2" runat="server" Text="中山中原" />
                        <asp:CheckBox ID="cbNre3" runat="server" Text="其他分公司" />
                        <asp:TextBox ID="txtAnotherCompany" runat="server" Width="240px"></asp:TextBox><br />
                        2、合作必须上传双方签署的《转介表》确认佣金拆分，
                        <asp:CheckBox ID="cbRce1" runat="server" Text="佛山中原" />
                        <asp:CheckBox ID="cbRce2" runat="server" Text="中山中原" />
                        <asp:CheckBox ID="cbRce3" runat="server" Text="其他分公司" />
                        <asp:TextBox ID="txtWillBreakUp" runat="server" TextMode="MultiLine"></asp:TextBox>需拆分
                        <asp:TextBox ID="txtBreakUp" runat="server" TextMode="MultiLine"></asp:TextBox>，转介后广州中原净佣金为
                        <asp:TextBox ID="txtNcommissions" runat="server"></asp:TextBox>。<br />
                        3、广州中原是否直接与发展商签代理合同/联动协议： 
                        <asp:RadioButton ID="rdbDealS1" runat="server" GroupName="rdbDealS" Text="是" />
                        <asp:RadioButton ID="rdbDealS2" runat="server" GroupName="rdbDealS" Text="否" />（附上传资料清单）
				    </td>
                </tr>
				<tr>
                    <th colspan="4" style="line-height:25px;" >审批流程</th>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <%--style="border: 1px solid #000000;"--%>
					<td >申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">其他意见</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <td >物业部区域负责人意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px; display: none;">
                    <td >二级市场负责人<br />（项目部）<br />或<br />三级市场负责人<br />（物业部）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
					<td rowspan="2" >法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/><label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
					</td>
				</tr>


                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td >区域回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx200">_________</span></div>
					</td>
				</tr>
                <tr id="trAddAnoF2" class="noborder" style="height: 85px; display: none;">
					<td rowspan="2">
                        法律部复审<br />
                        <asp:Button ID="btnShouldJumpIDx" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
					</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb210a1" runat="server" Text="同意" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a2" runat="server" Text="不同意" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a3" runat="server" Text="其它意见" GroupName="210a" ForeColor="#008162" />
						<textarea id="txtIDx210" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx210" runat="server" OnClick="btnSignIDx210_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx210">_________</span></div>
					</td>
				</tr>
                <tr id="trAddAnoF4" class="noborder" style="height: 85px; display: none;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb211a1" runat="server" Text="同意" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a2" runat="server" Text="不同意" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a3" runat="server" Text="其它意见" GroupName="211a" ForeColor="#008162" />
						<textarea id="txtIDx211" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx211" runat="server" OnClick="btnSignIDx211_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx211">_________</span></div>
					</td>
                </tr>
                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理复审</td>
					<td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#186ebe" />
						<textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx220">_________</span></div>
					</td>
				</tr>
			</table>
            <table id="tbAround2" width='720px'">
                <thead><tr><td style="font-weight: bold; text-align: left; padding-left: 10px;" colspan="2">欠交资料如下：</td></tr></thead>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack1" runat="server" Text="代理合同/联动协议" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack2" runat="server" Text="商铺现场照片" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack3" runat="server" Text="商铺平面图" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack4" runat="server" Text="《转介表》" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack5" runat="server" Text="房友圈电商佣不足90%的原因说明" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack6" runat="server" Text="其他资料" />
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
        <span id ="spm"></span><br />
		<hr />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>
		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" Visible="False"/>
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
            <asp:hiddenfield id="HidAutoN" runat="server" />
            <asp:hiddenfield id="HdAutoAdd" runat="server" />
            <asp:hiddenfield id="HdP" runat="server" />
            <asp:hiddenfield id="HdE" runat="server" />
            <asp:hiddenfield id="hfKey1" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
        </div>
            </div>
	</div>
	<%=SbJs.ToString()%>
    <script type="text/javascript">
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx210"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx211"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>