<%@ Page ValidateRequest="false" Title="��ҵ���н�����Ŀ����� - ������ԭ��������ϵͳ" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_UtNewProj_Detail.aspx.cs" Inherits="Apply_UtNewProj_Apply_UtNewProj_Detail" %>

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


            $("#<%=cbBaseAgent2.ClientID%>").click(function () { //M_0001��20151016
                if ($("#<%=cbBaseAgent2.ClientID%>").prop("checked")) {
                    alert("ע�⣺��˾������н��м����ڳ����ֵ���Ŀ��ѡ�˸������޷����棡");
                }
            });
            $("#<%=cbBaseAgent3.ClientID%>").click(function () {
                if ($("#<%=cbBaseAgent3.ClientID%>").prop("checked")) {
	                alert("ע�⣺��˾������н��м����ڳ����ֵ���Ŀ��ѡ�˸������޷����棡");
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

	        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //ʹ�Ի�������Ӧ
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
                alert("���ϴ���صĸ��������û�У���ѡ��ص�Ƿ�����ϣ�");
                $("#<%=cbLack1.ClientID%>").focus();
                return false;
            }
            if ($("#<%=cbBaseAgent2.ClientID%>").prop("checked") || $("#<%=cbBaseAgent3.ClientID%>").prop("checked")) { //M_0001��20151016
                alert("���ڴ���ѡ�˺ϸ��Իͻ��������޷����棡");
                $("#<%=cbBaseAgent2.ClientID%>").focus();
                return false;
            }
            if ($.trim($("#<%=txtDepartment.ClientID%>").val()) == "") {alert("���벿�Ų���Ϊ�գ�");$("#<%=txtDepartment.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtProject.ClientID%>").val()) == "") {alert("��Ŀ���Ʋ���Ϊ�գ�");$("#<%=txtProject.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtDeveloper.ClientID %>").val()) == "") { alert("��Ŀ��չ��(Сҵ��)����Ϊ�գ�"); $("#<%=txtDeveloper.ClientID %>").focus(); return false; }
            if ($.trim($("#<%=ddlDealType.ClientID%>").val()) == "") {alert("��ѡ��������ͣ�");$("#<%=ddlDealType.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtProjectArea.ClientID%>").val()) == "") {alert("��Ŀ�������򲻿�Ϊ�գ�");$("#<%=txtProjectArea.ClientID%>").focus();return false;}

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
	            alert("��ѡ����ҵ���ʣ�");
	            return false;
	        }
	        else
	            $("#<%=hdDealOfficeType.ClientID%>").val(typeValues.substr(0, typeValues.length - 1));

	        if ($.trim($("#<%=txtDeveloperContacter.ClientID%>").val()) == "") { alert("��������ϵ����������Ϊ�գ�"); $("#<%=txtDeveloperContacter.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtDeveloperContacterPosition.ClientID%>").val()) == "") { alert("��������ϵ��ְλ����Ϊ�գ�"); $("#<%=txtDeveloperContacterPosition.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtDeveloperContacterPhone.ClientID%>").val()) == "") { alert("��������ϵ�˵绰����Ϊ�գ�"); $("#<%=txtDeveloperContacterPhone.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaFollowerContacter.ClientID%>").val()) == "") { alert("�����������������Ϊ�գ�"); $("#<%=txtAreaFollowerContacter.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaFollowerContacterPosition.ClientID%>").val()) == "") { alert("���������ְλ����Ϊ�գ�"); $("#<%=txtAreaFollowerContacterPosition.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaFollowerContacterPhone.ClientID%>").val()) == "") { alert("��������˵绰����Ϊ�գ�"); $("#<%=txtAreaFollowerContacterPhone.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaCheckDataer.ClientID%>").val()) == "") { alert("�����������������Ϊ�գ�"); $("#<%=txtAreaCheckDataer.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaCheckDataerCode.ClientID%>").val()) == "") { alert("��������˹��Ų���Ϊ�գ�"); $("#<%=txtAreaCheckDataerCode.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAreaCheckDataerPhone.ClientID%>").val()) == "") { alert("��������˵绰����Ϊ�գ�"); $("#<%=txtAreaCheckDataerPhone.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtSquare.ClientID%>").val()) == "") { alert("��Ŀ�нӻ���ƽ��������Ϊ�գ�"); $("#<%=txtSquare.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtSetNumber.ClientID%>").val()) == "") { alert("��Ŀ�нӻ�����������Ϊ�գ�"); $("#<%=txtSetNumber.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtUnitPrice.ClientID%>").val()) == "") { alert("��ĿԤ�Ƶ��۲���Ϊ�գ�"); $("#<%=txtUnitPrice.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtTotalPrice.ClientID%>").val()) == "") { alert("��Ŀ�����ܽ���Ϊ�գ�"); $("#<%=txtTotalPrice.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAgentStartDate.ClientID%>").val()) == "") { alert("�����ڿ�ʼ���ڲ���Ϊ�գ�"); $("#<%=txtAgentStartDate.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtAgentEndDate.ClientID%>").val()) == "") { alert("�����ڽ������ڲ���Ϊ�գ�"); $("#<%=txtAgentEndDate.ClientID%>").focus(); return false; }
            if ($.trim($("#<%=txtTermsOfContract.ClientID%>").val()) == "") { alert("�����ͬԼ����Ӷ��֧����������Ϊ�գ�"); $("#<%=txtTermsOfContract.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtTermsOfMajorIssues.ClientID%>").val()) == "") { alert("�ش�����ĺ�ͬ�����Ϊ�գ�"); $("#<%=txtTermsOfMajorIssues.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtReportAddress.ClientID%>").val()) == "") { alert("������ַ����Ϊ�գ�"); $("#<%=txtReportAddress.ClientID%>").focus(); return false; }

            if ($("#<%=txtTermsOfContract.ClientID%>").val().length > 123) {
                alert("�����ͬԼ����Ӷ��֧��������Ҫ����123���֣�3�У���");
                $("#<%=txtTermsOfContract.ClientID%>").focus();
                return false;
            }

            if (
                    !$("#<%=cbBaseAgent1.ClientID %>").prop("checked")
                    && !$("#<%=cbBaseAgent2.ClientID %>").prop("checked")
                    && !$("#<%=cbBaseAgent3.ClientID %>").prop("checked")
                    && !$("#<%=cbBaseAgent4.ClientID %>").prop("checked")
               ) {
                alert("��ѡ���ڴ���");
                $("#<%=cbBaseAgent1.ClientID%>").focus();
                return false;
            }
            if ($("#<%=cbBaseAgent4.ClientID %>").prop("checked") && $.trim($("#<%=txtBaseAgentOther.ClientID%>").val()) == "") {
                alert("����д�����ĳ��ڴ���");
                $("#<%=txtBaseAgentOther.ClientID%>").focus();
                return false;
            }

	        if (!$("#<%=rdbJOrT1.ClientID%>").prop("checked") && !$("#<%=rdbJOrT2.ClientID%>").prop("checked") && !$("#<%=rdbJOrT3.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ����м����ϴ������������");
	            $("#<%=rdbJOrT1.ClientID%>").focus();
	            return false;
	        }

            if ($("[id*=cblDealOfficeType_3]").prop("checked")) {
                if (!$("#<%=rdbIsStree1.ClientID%>").prop("checked") && !$("#<%=rdbIsStree2.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ��ٽ�����");
                    $("#<%=rdbIsStree1.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsMarking1.ClientID%>").prop("checked") && !$("#<%=rdbIsMarking2.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ��̳���ϸ");
                    $("#<%=rdbIsMarking1.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsBusiness1.ClientID%>").prop("checked") && !$("#<%=rdbIsBusiness2.ClientID%>").prop("checked")) {
                    alert("��ѡ���̳��Ƿ����ھ�Ӫ");
                    $("#<%=rdbIsBusiness1.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsBackRent1.ClientID%>").prop("checked") && !$("#<%=rdbIsBackRent2.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ���ڷ�������");
                    $("#<%=rdbIsBackRent1.ClientID%>").focus();
                    return false;
                }
            }

	        if ($("#<%=rdbJOrT1.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtSamePlaceXX1.ClientID%>").val()) == "") { alert("ͬ��������м�����1����Ϊ�գ�"); $("#<%=txtSamePlaceXX1.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtSamePlaceXX2.ClientID%>").val()) == "") { alert("ͬ��������м�����2����Ϊ�գ�"); $("#<%=txtSamePlaceXX2.ClientID%>").focus(); return false; }

	            if ($.trim($("#<%=txtAgencyFee1.ClientID%>").val()) == "") { alert("ͬ�������мҴ����1����Ϊ�գ�"); $("#<%=txtAgencyFee1.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtAgencyFee2.ClientID%>").val()) == "") { alert("ͬ�������мҴ����2����Ϊ�գ�"); $("#<%=txtAgencyFee2.ClientID%>").focus(); return false; }
	            if ($("#<%=rdbIsCashPrize11.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtCashPrize1.ClientID%>").val()) == "") { alert("ͬ�������м��ֽ�1����Ϊ�գ�"); $("#<%=txtCashPrize1.ClientID%>").focus(); return false; }
	            }
	            if ($("#<%=rdbIsCashPrize21.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtCashPrize2.ClientID%>").val()) == "") { alert("ͬ�������м��ֽ�2����Ϊ�գ�"); $("#<%=txtCashPrize2.ClientID%>").focus(); return false; }
	            }
	            if (!$("#<%=rdbIsCashPrize11.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize12.ClientID%>").prop("checked")) {
	                alert("��ѡ���Ƿ���ͬ�������м��ֽ�1");
	                $("#<%=rdbIsCashPrize11.ClientID%>").focus();
	                return false;
	            }
	            if (!$("#<%=rdbIsCashPrize21.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize22.ClientID%>").prop("checked")) {
	                alert("��ѡ���Ƿ���ͬ�������м��ֽ�2");
	                $("#<%=rdbIsCashPrize21.ClientID%>").focus();
	                return false;
	            }

	            if ($("#<%=rdbIsPFear11.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtPFear1.ClientID%>").val()) == "") { alert("ͬ�������м���Ŀ����1����Ϊ�գ�"); $("#<%=txtPFear1.ClientID%>").focus(); return false; }
                }
                if ($("#<%=rdbIsPFear21.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtPFear2.ClientID%>").val()) == "") { alert("ͬ�������м���Ŀ����2����Ϊ�գ�"); $("#<%=txtPFear2.ClientID%>").focus(); return false; }
	            }
                if (!$("#<%=rdbIsPFear11.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear12.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ���ͬ�������м���Ŀ����1");
	                $("#<%=rdbIsCashPrize11.ClientID%>").focus();
	                return false;
                }
                if (!$("#<%=rdbIsPFear21.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear22.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ���ͬ�������м���Ŀ����2");
	                $("#<%=rdbIsCashPrize21.ClientID%>").focus();
	                return false;
                }
	        }

	        if (!$("#<%=rdbOwnerCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbOwnerCommJump2.ClientID%>").prop("checked")) {
	            alert("��ѡ��ҵӶ��BAR��ʽ");
	            $("#<%=rdbOwnerCommJump1.ClientID%>").focus();
	            return false;
	        }
	        //if (!$("#<%=rdbClientCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbClientCommJump2.ClientID%>").prop("checked")) {
	        //    alert("��ѡ���Ӷ��BAR��ʽ");
	        //    $("#<%=rdbClientCommJump1.ClientID%>").focus();
	       //     return false;
	        //}
	        if (!$("#<%=rdbEBCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbEBCommJump2.ClientID%>").prop("checked")) {
	            alert("��ѡ�����Ӷ��BAR��ʽ");
	            $("#<%=rdbEBCommJump1.ClientID%>").focus();
	            return false;
	        }
	        if (!$("#<%=rdbHaveSingleReward1.ClientID%>").prop("checked") && $("#<%=rdbHaveSingleReward1.ClientID%>").parent().css("display") != "none" && !$("#<%=rdbHaveSingleReward2.ClientID%>").prop("checked") && !$("#<%=rdbHaveSingleReward3.ClientID%>").prop("checked") && !$("#<%=rdbHaveSingleReward4.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ��е����ֽ�");
	            $("#<%=rdbHaveSingleReward1.ClientID%>").focus();
	            return false;
	        }
	        else if ($("#<%=rdbHaveSingleReward1.ClientID%>").parent().css("display") == "none" && !$("#<%=rdbHaveSingleReward2.ClientID%>").prop("checked") && !$("#<%=rdbHaveSingleReward3.ClientID%>").prop("checked") && !$("#<%=rdbHaveSingleReward4.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ��е����ֽ�");
	            $("#<%=rdbHaveSingleReward2.ClientID%>").focus();
	            return false;
            }
	        if ($("#<%=rdbHaveSingleReward1.ClientID%>").prop("checked")){
	            if ($.trim($("#<%=txtRewardSignHave.ClientID%>").val()) == "") {
	                alert("����3%�ĵ����ֽ𽱲���Ϊ�գ�");
	                $("#<%=txtRewardSignHave.ClientID%>").focus();
	                return false;
	            }
	            if (isNaN($("#<%=txtRewardSignHave.ClientID%>").val())) {
	                alert("����3%�ĵ����ֽ𽱱������봿����");
	                $("#<%=txtRewardSignHave.ClientID%>").focus();
	                return false;
	            }
	        }

	        if (!$("#<%=rdbHaveSingleReward3.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtDeveloperConditions.ClientID%>").val()) == "") { alert("��չ��֧���ֽ���������Ϊ�գ�"); $("#<%=txtDeveloperConditions.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtAreaConditions.ClientID%>").val()) == "") { alert("�����ɷ��ֽ���������Ϊ�գ�"); $("#<%=txtAreaConditions.ClientID%>").focus(); return false; }
	            if (!$("#<%=rdbPayRewardWay1.ClientID%>").prop("checked") && !$("#<%=rdbPayRewardWay2.ClientID%>").prop("checked")) {
	                alert("��ѡ���ֽ𽱵ķ��ŷ�ʽ");
	                $("#<%=rdbPayRewardWay1.ClientID%>").focus();
	                return false;
	            }
	            if (!$("#<%=rdbIsMyPay1.ClientID%>").prop("checked") && !$("#<%=rdbIsMyPay2.ClientID%>").prop("checked") && !$("#<%=rdbIsMyPay3.ClientID%>").prop("checked")) {
	                alert("��ѡ���ֽ��Ƿ��迪�߷�Ʊ������˾֧��˰��");
	                $("#<%=rdbIsMyPay1.ClientID%>").focus();
	                return false;
	            }
	            if (!$("#<%=rdbAreaComfirn1.ClientID%>").prop("checked") && !$("#<%=rdbAreaComfirn2.ClientID%>").prop("checked")) {
	                alert("��ѡ�������Ƿ����ύ��չ�̽���ȷ����");
	                $("#<%=rdbAreaComfirn1.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=rdbAreaComfirn2.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtReturnBackDate.ClientID%>").val()) == "") {
	                    alert("�����ŵ���ع�˾ʱ�䲻��Ϊ�գ�");
	                    $("#<%=txtReturnBackDate.ClientID%>").focus();
	                    return false;
	                }
	            }
	        }
	        if ($("#COtherCondtion").css("display")!="none"&&$.trim($("#<%=txtOtherCondtion.ClientID%>").val()) == "") {
	            alert("������ѡ���������������д�ֽ𽱷��ŷ�ʽ���������");
	            $("#<%=txtOtherCondtion.ClientID%>").focus();
	            return false;
	        }

	        if ($("#AnotherRewardC").css("display") != "none" && $.trim($("#<%=txtAnotherRewardC.ClientID%>").val()) == "") {
	            alert("������ѡ���������������д�����ֽ𽱵��������");
	            $("#<%=txtAnotherRewardC.ClientID%>").focus();
	            return false;
            }

	        if (!$("#<%=rdbSaleMode1.ClientID%>").prop("checked") && !$("#<%=rdbSaleMode2.ClientID%>").prop("checked")) {
	            alert("��ѡ������ģʽ");
	            return false;
	        }
	        else if ($("#<%=rdbSaleMode1.ClientID%>").prop("checked")) {
	            if ($("#<%=txtMainAreaScale.ClientID%>").val() == "") {
	                alert("������ѡ���˶������̣�����дͳ������ֳɽ�ռ�ȡ�");
                        $("#<%=txtMainAreaScale.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=txtDealAreaScale.ClientID%>").val() == "") {
                    alert("������ѡ���˶������̣�����д�ɽ�����ռ�ȡ�");
                        $("#<%=txtDealAreaScale.ClientID%>").focus();
	                return false;
                }
	            if ($("#<%=txtAreaScale1.ClientID%>").val() == "") {
	                alert("������ѡ���˶������̣�����дͳ�������ơ�");
	                $("#<%=txtAreaScale1.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtMainAreaScale.ClientID%>").val() > 15) {
	                alert("ͳ�����ϼƲ�ֳɽ���ֻ��С�ڻ����15%��");
	                $("#<%=txtMainAreaScale.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=txtDealAreaScale.ClientID%>").val() < 85) {
	                alert("�ɽ����������ֻ�ܴ��ڻ����85%��");
	                $("#<%=txtDealAreaScale.ClientID%>").focus();
	                return false;
                }
            }
	        else if ($("#<%=rdbSaleMode2.ClientID%>").prop("checked")) {
	            if ($("#<%=txtMainAreaScale2.ClientID%>").val() == "") {
	                alert("������ѡ���˺������̣�����дͳ�����ϼƲ�ֳɽ�ռ�ȡ�");
	                    $("#<%=txtMainAreaScale2.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtDealAreaScale2.ClientID%>").val() == "") {
	                alert("������ѡ���˺������̣�����д�ɽ�����ռ�ȡ�");
	                    $("#<%=txtDealAreaScale2.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtMainAreaScale2.ClientID%>").val() > 15) {
	                alert("ͳ�����ϼƲ�ֳɽ���ֻ��С�ڻ����15%��");
	                $("#<%=txtMainAreaScale2.ClientID%>").focus();
	            return false;
                }
                if ($("#<%=txtDealAreaScale2.ClientID%>").val() < 85) {
                    alert("�ɽ����������ֻ�ܴ��ڻ����85%��");
	                $("#<%=txtDealAreaScale2.ClientID%>").focus();
	            return false;
                }
	            
	        }

	        var data = "";
	        var flag = true;
	        $("#tOwner tr").each(function (i) {
	            var n = i + 1;
	            //if (isNaN($("#txtOwnerCommFloatScale" + n).val())) {
	            //    alert("ҵӶ�ĺ�ͬ����ѱ������봿����");
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
                alert("�빴ѡ�ļ������أ�");
				
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
                        $("#spm").html("<br />�����ϴ��ˣ�<br />" + sReturnValue);
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
            if (confirm("����������֮��������������ڶ���������ȷ��Ҫ���������"))  //20141202��CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }

	    function sign(idx) {
	        if (idx == '1'||idx == '2') {
	            if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
	                alert("��ȷ��ͬ�������ͬ�⣡");
	                return;
	            }
	        }
	        else {
	            if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbNoIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
	                alert("��ȷ���Ƿ�ͬ�⣡");
	                return;
	            }
	        }

	        if ($("#rdbNoIDx" + idx).prop("checked") && $.trim($("#txtIDx" + idx).val()) == "") {
	            alert("��������ͬ������룬������д��ͬ���ԭ��");
	            return;
	        }

	        if (confirm("�Ƿ�ȷ����ˣ�")) {
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
				+ '     <td style="border:none;"><input type="text" id="txtOwnerCommFloatSetNumberStart' + i1 + '" style="width:50px"/>��<input type="text" id="txtOwnerCommFloatSetNumberEnd' + i1 + '" style="width:50px"/>��/<input type="text" id="txtOwnerCommFloatMoneyStart' + i1 + '" style="width:50px"/>��<input type="text" id="txtOwnerCommFloatMoneyEnd' + i1 + '" style="width:50px"/>Ԫ���۶<input type="text" id="txtOwnerCommFloatKind' + i1 + '" style="width:80px"/>����дסլ/��Ԣ/�����Ȳ�ͬ���ͣ���ͬ�����<input type="text" id="txtOwnerCommFloatScale' + i1 + '" style="width:50px"/>%�����������<input type="text" id="txtOwnerCommPublishedScale' + i1 + '" style="width:50px"/>%</td>'
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
                alert("������ɾ����");
        }

        function addRow2() {
            i2++;
            var html = '<tr id="trClient' + i2 + '"  style="border:none;">'
				+ '     <td style="border:none;"><input type="text" id="txtClientCommFloatSetNumberStart' + i2 + '" style="width:50px"/>��<input type="text" id="txtClientCommFloatSetNumberEnd' + i2 + '" style="width:50px"/>��/<input type="text" id="txtClientCommFloatMoneyStart' + i2 + '" style="width:50px"/>��<input type="text" id="txtClientCommFloatMoneyEnd' + i2 + '" style="width:50px"/>Ԫ���۶��ͬ�����<input type="text" id="txtClientCommFloatScale' + i2 + '" style="width:50px"/>%�����������<input type="text" id="txtClientCommPublishedScale' + i2 + '" style="width:50px"/>%</td>'
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
                alert("������ɾ����");
        }

        function addRow3() {
            i3++;
            var html = '<tr id="trEB' + i3 + '"  style="border:none;">'
				+ '     <td style="border:none;"><input type="text" id="txtEBCommFloatSetNumberStart' + i3 + '" style="width:50px"/>��<input type="text" id="txtEBCommFloatSetNumberEnd' + i3 + '" style="width:50px"/>��/<input type="text" id="txtEBCommFloatMoneyStart' + i3 + '" style="width:50px"/>��<input type="text" id="txtEBCommFloatMoneyEnd' + i2 + '" style="width:50px"/>Ԫ���۶<input type="text" id="txtEBCommFloatKind' + i1 + '" style="width:80px"/>����дסլ/��Ԣ/�����Ȳ�ͬ���ͣ���ͬ�����<input type="text" id="txtEBCommFloatScale' + i3 + '" style="width:50px"/>%�����������<input type="text" id="txtEBCommPublishedScale' + i3 + '" style="width:50px"/>%</td>'
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
                alert("������ɾ����");
        }

        function DeleteT() { //20141231��M_DeleteC
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
        <asp:button runat="server" id="btnEditFlow2" text="�༭����" onclientclick="if(confirm('�޸ĺ����޸Ļ��ڵĺ������̶���������ȷ��Ҫ�޸���'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--��ӡ���Ŀ�ʼ-->
		<div style='text-align: center'>
			<h1>�㶫��ԭ�ز��������޹�˾</h1>
			<h1>��ҵ���н�����Ŀ�����</h1>
            <input type="button" id="btnADelete" value="�Ƿ�ͬ��ɾ����" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:720px;margin:0 auto;"><span style="float:right;" class="file_number">�ĵ�����(�Զ�����)��<%=SerialNumber%></span></div>
			<%--style="border-style:double; border-color:Black; border-width:5px; margin: 0 auto; background-color: #fff; border-collapse: collapse;" --%>
            <table id="tbAround" width='720px'>
                <tr>
                    <td>��Ŀ����</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtProject" runat="server" Width="92%"></asp:TextBox></td>
                </tr>
				<tr>
					<td style="width:20%">���벿��</td>
					<td class="tl PL10"><asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
					<td style="width:20%">������</td>
                    <td class="tl PL10"><asp:TextBox ID="txtApply" runat="server" Width="70px"></asp:TextBox>��- <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
                    <td>��Ŀ��չ��<br />(Сҵ��)</td>
					<td class="tl PL10"><asp:TextBox ID="txtDeveloper" runat="server"></asp:TextBox></td>
                    <td>������������</td>
					<td class="tl PL10"><asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>���ڴ���</td>
                    <td class="tl PL10" colspan="3">
                        <asp:CheckBox ID="cbBaseAgent1" runat="server" Text="��ԭ��Ŀ��" />
                        <asp:CheckBox ID="cbBaseAgent2" runat="server" Text="�ϸ��Ի�" />
                        <asp:CheckBox ID="cbBaseAgent3" runat="server" Text="����" />
                        <asp:CheckBox ID="cbBaseAgent4" runat="server" Text="����" />
                        <asp:TextBox ID="txtBaseAgentOther" runat="server" Width="270px"></asp:TextBox>
                    </td>
				</tr>
                <tr>
					<td>��������</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlDealType" runat="server" Width="100px"></asp:DropDownList></td>
				    <td>��Ŀ��������</td>
					<td class="tl PL10"><asp:TextBox ID="txtProjectArea" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td>��ҵ����</td>
					<td class="tl PL10" colspan="3">
                        <asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="cblDealOfficeType_SelectedIndexChanged"></asp:CheckBoxList>
                        <asp:HiddenField ID="hdDealOfficeType" runat="server" />
					</td>
				</tr>
                <tr id="Ct4">
                    <td class="tl PL10" colspan="4">
                       <%--��ֻҪ��ѡ�ˡ����̡��ͱ����ϴ��ֳ���Ƭ��ƽ��ͼ�����빴ѡ�������������ϴ������嵥����û�й�ѡ���̣���������ʾ�������<br />--%>
                        �Ƿ��ٽ����̣�<asp:RadioButton ID="rdbIsStree1" runat="server" GroupName="rdbIsStree" Text="��" /><asp:RadioButton ID="rdbIsStree2" runat="server" GroupName="rdbIsStree" Text="��" />���뱨������������������������������
                        �Ƿ��̳���ϸ��<asp:RadioButton ID="rdbIsMarking1" runat="server" GroupName="rdbIsMarking" Text="��" />���뱨����������<asp:RadioButton ID="rdbIsMarking2" runat="server" GroupName="rdbIsMarking" Text="��" /><br />
                        �̳��Ƿ����ھ�Ӫ��<asp:RadioButton ID="rdbIsBusiness1" runat="server" GroupName="rdbIsBusiness" Text="��" /><asp:RadioButton ID="rdbIsBusiness2" runat="server" GroupName="rdbIsBusiness" Text="��" />��������������������������������
                        �Ƿ���ڷ������<asp:RadioButton ID="rdbIsBackRent1" runat="server" GroupName="rdbIsBackRent" Text="��" /><asp:RadioButton ID="rdbIsBackRent2" runat="server" GroupName="rdbIsBackRent" Text="��" /><br />
                    </td>
                </tr>
                <tr>
                    <td>��Ŀ��ַ</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtProjectAddress" runat="server" Width="92%"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>������ַ</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtReportAddress" runat="server" Width="92%"></asp:TextBox></td>
				</tr>
                <tr>
					<td>��չ��<br />��ϵ��</td>
					<td colspan="3" class="tl PL10">����<asp:TextBox ID="txtDeveloperContacter" runat="server" Width="100px"></asp:TextBox>ְλ<asp:TextBox ID="txtDeveloperContacterPosition" runat="server" Width="100px"></asp:TextBox>��ϵ�绰<asp:TextBox ID="txtDeveloperContacterPhone" runat="server" Width="100px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>����ͳ����</td>
					<td colspan="3" class="tl PL10">����<asp:TextBox ID="txtAreaFollowerContacter" runat="server" Width="100px"></asp:TextBox>ְλ<asp:TextBox ID="txtAreaFollowerContacterPosition" runat="server" Width="100px"></asp:TextBox>��ϵ�绰<asp:TextBox ID="txtAreaFollowerContacterPhone" runat="server" Width="100px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>���������</td>
					<td colspan="3" class="tl PL10">����<asp:TextBox ID="txtAreaCheckDataer" runat="server" Width="100px"></asp:TextBox>����<asp:TextBox ID="txtAreaCheckDataerCode" runat="server" Width="100px"></asp:TextBox>��ϵ�绰<asp:TextBox ID="txtAreaCheckDataerPhone" runat="server" Width="100px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>��Ŀ���</td>
					<td colspan="3" class="tl PL10">�нӻ���<asp:TextBox ID="txtSquare" runat="server" Width="150px"></asp:TextBox>ƽ����,��<asp:TextBox ID="txtSetNumber" runat="server" Width="150px"></asp:TextBox>��;
                        <br />Ԥ�Ƶ���<asp:TextBox ID="txtUnitPrice" runat="server" Width="150px"></asp:TextBox>Ԫ/ƽ����;�����ܽ��<asp:TextBox ID="txtTotalPrice" runat="server" Width="150px"></asp:TextBox>Ԫ
					</td>
				</tr>
                <tr>
					<td>��˾�Ƿ������ǩԼ</td>
					<td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbIsCoopWithECommerce1" runat="server" Text="�ǣ��뷿��ȦǩԼ���ͻ��ֳ�֧��" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtCoopWithE1" runat="server" Width="70px"></asp:TextBox>Ԫ�Ź��ѣ�A����¥��
                        <asp:TextBox ID="txtCoopWithE2" runat="server" Width="70px"></asp:TextBox>��Э��Լ������Ȧ֧����˾����Ӷ
                        <asp:TextBox ID="txtCoopWithE3" runat="server" Width="70px"></asp:TextBox>Ԫ��B�����۳�10%Ӫ�˷��ú���˾ʵ��
                        <asp:TextBox ID="txtCoopWithE4" runat="server" Width="70px"></asp:TextBox>Ԫ������Ӷ������C����ϵͳ�蹫ʽC=B/A��
                        <asp:TextBox ID="txtCoopWithE5" runat="server" Width="70px"></asp:TextBox>%����C<90%�����ϴ���չ�̻���̵ĸ����ļ�˵��ԭ��<br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce2" runat="server" Text="�ǣ�����������ǩԼ�����̹�˾����" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName" runat="server" Width="300px"></asp:TextBox><br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce3" runat="server" Text="�񣬲��������ǩԼ�����ͻ���Ҫ�ڵ��̹�˾ˢ���Ի�ȡ���Żݣ����̹�˾����" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName2" runat="server" Width="415px"></asp:TextBox><br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce4" runat="server" Text="��������Ŀû���κε��̲���" GroupName="CoopWithECommerce" />
					</td>
				</tr>
                <tr>
                    <td>�Ƿ����м����ϴ���<br />����������</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbJOrT1" runat="server" GroupName="JOrT" Text="���м�ͬ�����ϴ���" /><br />
                        <asp:RadioButton ID="rdbJOrT2" runat="server" GroupName="JOrT" Text="���м���������������������ԭ���Ҵ���������֮�����м���������" /><br />
                        <asp:RadioButton ID="rdbJOrT3" runat="server" GroupName="JOrT" Text="������Ŀ����ԭ���Ҵ�����չ��û��ί�г���ԭ������κδ�����" /><br />
                    </td>
                </tr>
                <tr>
                    <td>��Ŀ���ã������ѣ�</td>
                    <td class="tl PL10" colspan="3">
                        <asp:RadioButton ID="rdbProjFear1" runat="server" GroupName="rdbProjFear" Text="��" />
                        <asp:RadioButton ID="rdbProjFear2" runat="server" GroupName="rdbProjFear" Text="��" />����Ŀ���ñ��������������ύ��������ͬ�ⷽ����Ч��<br />
                        ����Ŀ���ù�ѡ���ޡ�ʱ�����µĺ����Ѽ��ᡢ�����ѳе���ʽ����ȫ������ʾ��ֻ��ֱ��д�����<br />
                        ��չ��Ӷ�����Ѽ��᣺<asp:TextBox ID="txtProjSum1" runat="server"></asp:TextBox><br />
                        ����Ӷ�����Ѽ��᣺<asp:TextBox ID="txtProjSum2" runat="server"></asp:TextBox><br />
                        ����ע: ����Ŀͬʱ�е��̷��ü������ѣ���ֱ���ʾ���̷��õı����������ѵı�����<br />
                        �۳������Ѻ�ķ�չ��Ӷ��+����Ӷ��<asp:TextBox ID="txtProjSum3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
					<td>�����</td>
					<td colspan="3" class="tl PL10">(1)��չ��Ӷ������Ҫ���㵥���ֽ𽱣���ͬ����ѱ�����д������ʾ�ٷֱȵĴ����֣�
                        <br />�̶���Ӷ����ͬ�����<asp:TextBox ID="txtOwnerCommFixScale" runat="server" Width="80px"></asp:TextBox>%����������ѣ��۳������Ѻ�ʵ�գ���<asp:TextBox ID="txtOwnerCommAgent" runat="server" Width="80px"></asp:TextBox>%<br />
				        �䶯��Ӷ������<br />
                        <table id="tOwner" class='sample tc' width='100%' style="border:none;">
							<tr id="trOwner1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtOwnerCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtOwnerCommFloatSetNumberEnd1" style="width:50px"/>��/<input type="text" id="txtOwnerCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtOwnerCommFloatMoneyEnd1" style="width:50px"/>Ԫ���۶���������۶��ѡһ����<input type="text" id="txtOwnerCommFloatKind1" style="width:80px"/>����дסլ/��Ԣ/�����Ȳ�ͬ���ͣ���ͬ�����<input type="text" id="txtOwnerCommFloatScale1" style="width:50px"/>%�����������<input type="text" id="txtOwnerCommPublishedScale1" style="width:50px"/>%</td>
				            </tr>
                            <%=SbHtml1.ToString()%>
                        </table>
                        Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbOwnerCommJump1" runat="server" Text="ȫ��BAR" GroupName="OwnerCommJump" />
                        <asp:RadioButton ID="rdbOwnerCommJump2" runat="server" Text="�ּ���BAR" GroupName="OwnerCommJump" /><br />
                        <asp:HiddenField ID="hdOwner" runat="server" />
                        <input type="button" id="btnAddRow1" value="�������" onclick="addRow1();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow1" value="ɾ��һ��" onclick="deleteRow1();" style=" float:left; display:none"/><br /><br />
                        
                        (2)��Ӷ�����У���<br />
                        <asp:TextBox ID="txtClientCommFixScale" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>

                        <div style="display:none;">
                            (2)��Ӷ�����У�������Ҫ���㵥���ֽ𽱣���ͬ����ѱ�����д������ʾ�ٷֱȵĴ����֣�
                            <br />�̶���Ӷ����ͬ�����__________________%����������ѣ��۳������Ѻ�ʵ�գ���<asp:TextBox ID="txtClientCommAgent" runat="server" Width="80px">1</asp:TextBox>%<br />
                            �䶯��Ӷ������<br />
					        <table id="tClient" class='sample tc' width='100%' style="border:none;">
                                <tr id="trClient1"  style="border:none;">
				                    <td style="border:none;"><input type="text" id="txtClientCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtClientCommFloatSetNumberEnd1" style="width:50px" value="1"/>��/<input type="text" id="txtClientCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtClientCommFloatMoneyEnd1" style="width:50px" value="1"/>Ԫ���۶��ͬ�����<input type="text" id="txtClientCommFloatScale1" style="width:50px" value="1"/>%�����������<input type="text" id="txtClientCommPublishedScale1" style="width:50px" value="1"/>%</td>
			                    </tr>
							    <%=SbHtml2.ToString()%>
					        </table>
                            Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbClientCommJump1" runat="server" Text="ȫ��BAR" GroupName="ClientCommJump" Checked="True" />
                            <asp:RadioButton ID="rdbClientCommJump2" runat="server" Text="�ּ���BAR" GroupName="ClientCommJump" /><br />
                            <asp:HiddenField ID="hdClient" runat="server" />
                            <input type="button" id="btnAddRow2" value="�������" onclick="addRow2();" style=" float:left; display:none"/>
						    <input type="button" id="btnDeleteRow2" value="ɾ��һ��" onclick="deleteRow2();" style=" float:left;display:none"/>
                        </div>
                        <br /><br />
                        
                        (3)����Ӷ������Ҫ���㵥���ֽ𽱣���ͬ����ѱ�����д������ʾ�ٷֱȵĴ����֣�
                        <br />�̶���Ӷ����ͬ�����<asp:TextBox ID="txtEBComm" runat="server" Width="70px"></asp:TextBox>%����������ѣ��۳����̷��ü������Ѻ�ʵ�գ���<asp:TextBox ID="txtEBCommAgent" runat="server" Width="70px"></asp:TextBox>%<br />
                        �䶯��Ӷ������<br />
					    <table id="tEB" class='sample tc' width='100%' style="border:none;">
                            <tr id="trEB1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtEBCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtEBCommFloatSetNumberEnd1" style="width:50px"/>��/<input type="text" id="txtEBCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtEBCommFloatMoneyEnd1" style="width:50px"/>Ԫ���۶���������۶��ѡһ����<input type="text" id="txtEBCommFloatKind1" style="width:80px"/>����дסլ/��Ԣ/�����Ȳ�ͬ���ͣ���ͬ�����<input type="text" id="txtEBCommFloatScale1" style="width:50px"/>%�����������<input type="text" id="txtEBCommPublishedScale1" style="width:50px"/>%</td>
			                </tr>
							<%=SbHtml3.ToString()%>
					    </table>
                        Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbEBCommJump1" runat="server" Text="ȫ��BAR" GroupName="EBCommJump" />
                        <asp:RadioButton ID="rdbEBCommJump2" runat="server" Text="�ּ���BAR" GroupName="EBCommJump" /><br />
                        <asp:HiddenField ID="hdEB" runat="server" />
                        <input type="button" id="btnAddRow3" value="�������" onclick="addRow3();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow3" value="ɾ��һ��" onclick="deleteRow3();" style=" float:left;display:none"/><br /><br />
                        ������������<br />
                        <asp:textbox id="txtRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:textbox>
                        <br />

                        �����ֽ𽱣�<br /><div id="SingleRewardC1">����������<asp:RadioButton ID="rdbHaveSingleReward1" runat="server" Text="�У�����Ŀʵ��Ӷ�������3%" GroupName="HaveSingleReward" />
                        ���ֽ�<asp:TextBox ID="txtRewardSignHave" runat="server" Width="90px"></asp:TextBox>Ԫ/�ף�
                        �ֽ𽱵Ŀɷ��Ž��=ÿ�׾�Ӷ��*15%���Է�չ�̽���Ϊ���ޣ����ɷ��Ž��������Ϊ��ӪҵԱ44%������15%������8%�����ܼ�/�ܼࣨO/R��3%����˾30%������ÿ�׾�Ӷ���15%���ּ���˾30%����ȫ���Ͻɹ�˾���ɼ���Ա��ҵ������������Ա��Ӷ��</div>
                        <div id="SingleRewardC2">����������<asp:RadioButton ID="rdbHaveSingleReward2" runat="server" Text="�У�����Ŀʵ��Ӷ�����<3%" GroupName="HaveSingleReward" />���ֽ�ȫ���Ͻɹ�˾���ɼ���Ա��ҵ������������Ա��Ӷ��</div> ����������
                        <div id="SingleRewardC3">����������<asp:RadioButton ID="rdbHaveSingleReward3" runat="server" Text="�ޣ�����Ŀ�����ֽ𽱡�" GroupName="HaveSingleReward" /></div>����������
                        <div id="SingleRewardC4">����������<asp:RadioButton ID="rdbHaveSingleReward4" runat="server" Text="�������" GroupName="HaveSingleReward" /></div>
                        <div id="AnotherRewardC" style="display: none"><asp:TextBox ID="txtAnotherRewardC" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox></div><br />
                        �ֽ𽱵Ĳ�����<br />
                        ��1����չ��֧���ֽ𽱵�������<br />
                        <asp:TextBox ID="txtDeveloperConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
                        ��2�������ɷ��ֽ𽱸�ͬ�µ�������<br />
                        <asp:TextBox ID="txtAreaConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
	                    <span style="color: #FF0000;">��������뱣֤�ֽ��������˻ظ���չ�̵�������ٷ��Ÿ�ͬ�£�������ɹ�˾��ʧ���������Ա�е��⳥���Σ�</span><br /><br />
                        <div>�ֽ𽱵ķ��ŷ�ʽ��</div>
                        <asp:RadioButton ID="rdbPayRewardWay1" runat="server" Text="�����ɷ�չ�̻��빫˾�ʻ�����нӶ���š�" GroupName="PayRewardWay" /><br />
                        <asp:RadioButton ID="rdbPayRewardWay2" runat="server" Text="�����ɷ�չ��ֱ��֧���ֽ𣬽����˱��������벿�Ÿ����ˡ�" GroupName="PayRewardWay" /><br />
                        �ֽ��Ƿ��迪�߷�Ʊ������˾֧��˰�ѣ�
                        <asp:RadioButton ID="rdbIsMyPay1" runat="server" Text="��" GroupName="IsMyPay" />
                        <asp:RadioButton ID="rdbIsMyPay2" runat="server" Text="��" GroupName="IsMyPay" />
                        <asp:RadioButton ID="rdbIsMyPay3" runat="server" Text="�������" GroupName="IsMyPay" Visible="False" />
                        <div id="COtherCondtion" style="display: none"><asp:TextBox ID="txtOtherCondtion" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox></div><br />
                        �����Ƿ����ύ��չ�̽���ȷ���飿
                        <asp:RadioButton ID="rdbAreaComfirn1" runat="server" Text="��" GroupName="AreaComfirn" />
                        <asp:RadioButton ID="rdbAreaComfirn2" runat="server" Text="��" GroupName="AreaComfirn" />��
                        �����ŵ��<asp:TextBox ID="txtReturnBackDate" runat="server"></asp:TextBox>ǰ���ع�˾

                        <br /><br />
                        �����ͬԼ����Ӷ��֧������<br />
                        <asp:TextBox ID="txtTermsOfContract" runat="server"  TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;" MaxLength="123"></asp:TextBox>
                        <br />
                        �ش�����ĺ�ͬ�����ΥԼ�⳥��������������Ƶȣ�<br />
                        <asp:TextBox ID="txtTermsOfMajorIssues" runat="server"  TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:TextBox>
					</td>
				</tr>
                <tr>
					<td>������</td>
					<td class="tl PL10"><asp:TextBox ID="txtAgentStartDate" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox ID="txtAgentEndDate" runat="server" Width="80px"></asp:TextBox></td>
                    <td>�ͻ������ڣ��Ǳ����</td>
					<td class="auto-style1"><asp:TextBox ID="txtClientGuardStartDate" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox ID="txtClientGuardEndDate" runat="server" Width="80px"></asp:TextBox></td>
				</tr>

                
                <tr>
                    <td>�мҴ�����Ϣ</td>
                    <td colspan="3"class="tl PL10">
                        <div>������Ŀ���м�ͬ�����ϴ������������������Ϊ����������������˽������Ϣ�޷���д������ע�����������˽������Ϣ����</div><br />
                        1.���ƣ�<asp:TextBox ID="txtSamePlaceXX1" runat="server" Width="200px"></asp:TextBox>
                        ������ѣ�<asp:TextBox ID="txtAgencyFee1" runat="server" Width="200px"></asp:TextBox><br />
                        ���ֽ𽱣�<asp:RadioButton ID="rdbIsCashPrize11" runat="server" Text="�У�" GroupName="CashPrize1" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize1" runat="server" Width="200px"></asp:TextBox>Ԫ/��</label><asp:RadioButton ID="rdbIsCashPrize12" runat="server" Text="��" GroupName="CashPrize1" /><br />
                        ����Ŀ���ã�<asp:RadioButton ID="rdbIsPFear11" runat="server" Text="�У�����" GroupName="IsPFear1" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear1" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear12" runat="server" Text="��" GroupName="IsPFear1" /><br />
                        2.���ƣ�<asp:TextBox ID="txtSamePlaceXX2" runat="server" Width="200px"></asp:TextBox>
                        ������ѣ�<asp:TextBox ID="txtAgencyFee2" runat="server" Width="200px"></asp:TextBox><br /><label for="r2d2b2"></label>
                        ���ֽ𽱣�<asp:RadioButton ID="rdbIsCashPrize21" runat="server" Text="�У�" GroupName="CashPrize2" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize2" runat="server" Width="200px"></asp:TextBox>Ԫ/��</label><asp:RadioButton ID="rdbIsCashPrize22" runat="server" Text="��" GroupName="CashPrize2" /><br />
                        ����Ŀ���ã�<asp:RadioButton ID="rdbIsPFear21" runat="server" Text="�У�����" GroupName="IsPFear2" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear2" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear22" runat="server" Text="��" GroupName="IsPFear2" /><br />
                    </td>
                </tr>
                
                <tr>
					<td>���벿�Ž���ģʽ</td>
					<td colspan="3" class="tl PL10"><asp:RadioButton ID="rdbSaleMode1" runat="server" Text="�������̣�" GroupName="SaleMode" /><label for="r2d2b2">ͳ����<asp:TextBox ID="txtAreaScale1" runat="server" Width="110px"></asp:TextBox>��ֳɽ���<asp:TextBox ID="txtMainAreaScale" runat="server" Width="50px"></asp:TextBox>%�� �ɽ���ռ<asp:TextBox ID="txtDealAreaScale" runat="server" Width="50px"></asp:TextBox>%</label>
                        <br />
                        <div style="margin-top: 10px; margin-bottom: 10px;">
                            <asp:RadioButton ID="rdbSaleMode2" runat="server" Text="�������̣�ͳ����" GroupName="SaleMode" Height="30px" />
                            <label for="r2d2b2"><asp:TextBox ID="txtAreaScale" runat="server" Width="70%" Height="40px" TextMode="MultiLine"></asp:TextBox>��
                            <br />�������������̵�ÿ������ֱ�����
                            ͳ�����ϼƲ�ֳɽ���<asp:TextBox ID="txtMainAreaScale2" runat="server" Width="50px"></asp:TextBox>%���ɽ�����ֳɽ���<asp:TextBox ID="txtDealAreaScale2" runat="server" Width="50px"></asp:TextBox>%</label>
					    </div>
                    </td>
                </tr>
                <tr>
                    <td>������ԭ<br />�������ֹ�˾����</td>
                    <td colspan="3" class="tl PL10">
                        1��������˾��
                        <asp:CheckBox ID="cbNre1" runat="server" Text="��ɽ��ԭ" />
                        <asp:CheckBox ID="cbNre2" runat="server" Text="��ɽ��ԭ" />
                        <asp:CheckBox ID="cbNre3" runat="server" Text="�����ֹ�˾" />
                        <asp:TextBox ID="txtAnotherCompany" runat="server" Width="240px"></asp:TextBox><br />
                        2�����������ϴ�˫��ǩ��ġ�ת���ȷ��Ӷ���֣�
                        <asp:CheckBox ID="cbRce1" runat="server" Text="��ɽ��ԭ" />
                        <asp:CheckBox ID="cbRce2" runat="server" Text="��ɽ��ԭ" />
                        <asp:CheckBox ID="cbRce3" runat="server" Text="�����ֹ�˾" />
                        <asp:TextBox ID="txtWillBreakUp" runat="server" TextMode="MultiLine"></asp:TextBox>����
                        <asp:TextBox ID="txtBreakUp" runat="server" TextMode="MultiLine"></asp:TextBox>��ת��������ԭ��Ӷ��Ϊ
                        <asp:TextBox ID="txtNcommissions" runat="server"></asp:TextBox>��<br />
                        3��������ԭ�Ƿ�ֱ���뷢չ��ǩ�����ͬ/����Э�飺 
                        <asp:RadioButton ID="rdbDealS1" runat="server" GroupName="rdbDealS" Text="��" />
                        <asp:RadioButton ID="rdbDealS2" runat="server" GroupName="rdbDealS" Text="��" />�����ϴ������嵥��
				    </td>
                </tr>
				<tr>
                    <th colspan="4" style="line-height:25px;" >��������</th>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <%--style="border: 1px solid #000000;"--%>
					<td >������</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">ͬ��</label><input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">�������</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="ǩ��" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx1">_________</span>
                        </span>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <td >��ҵ�������������</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">ͬ��</label><input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">�������</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="ǩ��" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx2">_________</span>
                        </span>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px; display: none;">
                    <td >�����г�������<br />����Ŀ����<br />��<br />�����г�������<br />����ҵ����</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">ͬ��</label><input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">�������</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="ǩ��" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx3">_________</span>
                        </span>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
					<td rowspan="2" >���ɲ����</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">ͬ��</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">��ͬ��</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">�������</label><br />
						<textarea id="txtIDx4" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="ǩ�����" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx4">_________</span>
                        </span>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/><label for="rdbYesIDx5">ͬ��</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">��ͬ��</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">�������</label><br />
						<textarea id="txtIDx5" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="ǩ�����" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx5">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td >�����ܾ���<br />����</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">ͬ��</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">��ͬ��</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">�������</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="ǩ�����" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx6">_________</span>
                        </span>
					</td>
				</tr>


                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td >����ظ��������<br />����ѡ�</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">���ڣ�<span id="spanDateIDx200">_________</span></div>
					</td>
				</tr>
                <tr id="trAddAnoF2" class="noborder" style="height: 85px; display: none;">
					<td rowspan="2">
                        ���ɲ�����<br />
                        <asp:Button ID="btnShouldJumpIDx" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
					</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb210a1" runat="server" Text="ͬ��" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a2" runat="server" Text="��ͬ��" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a3" runat="server" Text="�������" GroupName="210a" ForeColor="#008162" />
						<textarea id="txtIDx210" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx210" runat="server" OnClick="btnSignIDx210_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">���ڣ�<span id="spanDateIDx210">_________</span></div>
					</td>
				</tr>
                <tr id="trAddAnoF4" class="noborder" style="height: 85px; display: none;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb211a1" runat="server" Text="ͬ��" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a2" runat="server" Text="��ͬ��" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a3" runat="server" Text="�������" GroupName="211a" ForeColor="#008162" />
						<textarea id="txtIDx211" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx211" runat="server" OnClick="btnSignIDx211_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">���ڣ�<span id="spanDateIDx211">_________</span></div>
					</td>
                </tr>
                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td >�����ܾ�����</td>
					<td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="ͬ��" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="��ͬ��" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="�������" GroupName="220a" ForeColor="#186ebe" />
						<textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">���ڣ�<span id="spanDateIDx220">_________</span></div>
					</td>
				</tr>
			</table>
            <table id="tbAround2" width='720px'">
                <thead><tr><td style="font-weight: bold; text-align: left; padding-left: 10px;" colspan="2">Ƿ���������£�</td></tr></thead>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack1" runat="server" Text="�����ͬ/����Э��" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack2" runat="server" Text="�����ֳ���Ƭ" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack3" runat="server" Text="����ƽ��ͼ" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack4" runat="server" Text="��ת���" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack5" runat="server" Text="����Ȧ����Ӷ����90%��ԭ��˵��" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack6" runat="server" Text="��������" />
                    </td>
                </tr>
            </table>
            <div style="width:640px;margin:0 auto;"><span class="tl" style="float:left;">��ע��1��ҵ���н�һ����Ŀ/һ�ֻ�β�̣����ϴ˱��������<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2��ҵ���нӶ�����ҵ��20�׻����ϵ���������Ŀ�����ϴ˱��������</span></div>
			<!--��ӡ���Ľ���-->
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
				<asp:TemplateField HeaderText="ɾ��" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
					<ItemTemplate>
						<asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID")%>' OnClientClick="return confirm('ȷ��ɾ����');" />
						<asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID")%>' />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="����" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
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
        <asp:button runat="server" id="btnReWrite" text="���µ���" OnClick="btnReWrite_Click" Visible="False"/>
		<asp:button runat="server" id="btnSave" text="����" onclick="btnSave_Click" onclientclick="return check();" Visible="False"/>
            <asp:button runat="server" id="btnSAlterC" text="�޸�" visible="false" onclientclick="if(confirm('�޸ĺ������������Ļ��ڶ���������ȷ��Ҫ�޸���'))return check();else return false;" OnClick="btnSAlterC_Click" />
		<input type="button" id="btnUpload" value="�ϴ�����..." onclick="upload();" style="margin-left: 5px;" />
		<asp:button id="btnDownload" runat="server" text="����ѡ�и���" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
		<asp:button runat="server" id="btnSignSave" text="��ע������" onclick="btnSignSave_Click" visible="false" />
		<input type="button" id="btnPrint" value="��ӡ" onclick="myPrint('��ӡ���Ŀ�ʼ','��ӡ���Ľ���');" style="display: none;" />
		<asp:Button ID="btnSPDF" runat="server" Text="���ΪPDF" OnClick="btnSPDF_Click" />
        <asp:button runat="server" id="btnBack" text="����" onclick="btnBack_Click" />
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
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //ʹ�Ի�������Ӧ
    </script>
</asp:Content>