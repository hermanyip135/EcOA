<%@ Page ValidateRequest="false" Title="��ҵ���н���Ŀ��������� - ������ԭ��������ϵͳ" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_NewUndertakeProj_Detail.aspx.cs" Inherits="Apply_NewUndertakeProj_Apply_UndertakeProj_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
	    var i1 = 1, i2 = 1, i3 = 1, cou = 0*1;

	    $(function () {
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
	        $("#<%=txtAreaPromiseBackDate.ClientID%>").datepicker();
	        $("#<%=txtNHTime.ClientID%>").datepicker();
	        $("#<%=txtLastBeginDate.ClientID%>").datepicker();
	        $("#<%=txtLastEndDate.ClientID%>").datepicker();
	        $("#<%=txtCumulativeBeginDate.ClientID%>").datepicker();
	        $("#<%=txtCumulativeEndDate.ClientID%>").datepicker();
	        $("#<%=txtAgencyBeginDate1.ClientID%>").datepicker();
	        $("#<%=txtAgencyBeginDate2.ClientID%>").datepicker();
	        $("#<%=txtAgencyEndDate1.ClientID%>").datepicker();
	        $("#<%=txtAgencyEndDate2.ClientID%>").datepicker();
	        $("#<%=txtReturnBackDate.ClientID%>").datepicker();

	        if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
	            AutoC();
	        else {
	            AutoAdd();
	            $("#WZJ").hide();
	        }

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











	        $("#<%=txtPCDeveloper.ClientID%>").blur(function () {//*9

	                if (!isNaN($("#txtOwnerCommFloatScale1").val()) && ($("#<%=txtOwnerCommFixScale.ClientID%>").val() == "" || isNaN($("#<%=txtOwnerCommFixScale.ClientID%>").val()))) {
	                    var a = $("#txtOwnerCommFloatScale1").val() * 1.0 / 100 * (1 - ($("#<%=txtPCDeveloper.ClientID%>").val() * 1.0 / 100));
	                    $("#<%=txtPCDeduct.ClientID%>").val(a * 100);
	                    $("#<%=HdP.ClientID%>").val(a * 100);
	                }
	                else if (($("#<%=txtOwnerCommFixScale.ClientID%>").val() == "" || isNaN($("#<%=txtOwnerCommFixScale.ClientID%>").val())) && $("#txtOwnerCommFloatScale1").val() != "") {
	                    $("#<%=txtPCDeduct.ClientID%>").val($("#txtOwnerCommFloatScale1").val());
	                    $("#<%=HdP.ClientID%>").val($("#txtOwnerCommFloatScale1").val());
	                }
	                if (!isNaN($("#<%=txtOwnerCommFixScale.ClientID%>").val()) && ($("#txtOwnerCommFloatScale1").val() == "" || isNaN($("#txtOwnerCommFloatScale1").val()))) {
	                    var a = $("#<%=txtOwnerCommFixScale.ClientID%>").val() * 1.0 / 100 * (1 - ($("#<%=txtPCDeveloper.ClientID%>").val() * 1.0 / 100));
	                    $("#<%=txtPCDeduct.ClientID%>").val(a * 100);
	                    $("#<%=HdP.ClientID%>").val(a * 100);
	                }
	                else if ($("#txtOwnerCommFloatScale1").val() == "" || isNaN($("#txtOwnerCommFloatScale1").val())) {
	                    $("#<%=txtPCDeduct.ClientID%>").val($("#<%=txtOwnerCommFixScale.ClientID%>").val());
	                    $("#<%=HdP.ClientID%>").val($("#<%=txtOwnerCommFixScale.ClientID%>").val());
	                }

	                if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked") && !isNaN($("#<%=txtPCDeduct.ClientID%>").val()) && !isNaN($("#<%=txtEBDeduct.ClientID%>").val()) && $("#<%=HidAutoN.ClientID%>").val() * 1 < 3) {
	                    $("#SingleRewardC1").hide();
	                    $("#SingleRewardC2").show();
	                    $("#SingleRewardC3").show();
	                    $("#<%=rdbHaveSingleReward2.ClientID%>").click();
	                }
	                else if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	                    $("#SingleRewardC1").show();
	                    $("#SingleRewardC2").show();
	                    $("#SingleRewardC3").show();
	                    $("#SingleRewardC4").show();
	                }
	            
	            AutoC();
	            if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked") && $("#<%=HidAutoN.ClientID%>").val() * 1 >= 3) {
	                $("#SingleRewardC1").show();
	            }
	            else if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	                $("#SingleRewardC1").hide();
	            }
	        });
	        $("#<%=txtEBDeveloper.ClientID%>").blur(function () {
	            if (!isNaN($("#txtEBCommFloatScale1").val()) && ($("#<%=txtEBComm.ClientID%>").val() == "" || isNaN($("#<%=txtEBComm.ClientID%>").val()))) {
	                var a = $("#txtEBCommFloatScale1").val() * 1.0 / 100 * (1 - ($("#<%=txtEBDeveloper.ClientID%>").val() * 1.0 / 100));
	                $("#<%=txtEBDeduct.ClientID%>").val(a * 100);
	                $("#<%=HdE.ClientID%>").val(a * 100);
                	            }
                	            else if (($("#<%=txtEBComm.ClientID%>").val() == "" || isNaN($("#<%=txtEBComm.ClientID%>").val())) && $("#txtEBCommFloatScale1").val() != "") {
                	                $("#<%=txtEBDeduct.ClientID%>").val($("#txtEBCommFloatScale1").val());
                	                $("#<%=HdE.ClientID%>").val($("#txtEBCommFloatScale1").val());
	            }
	            if (!isNaN($("#<%=txtEBComm.ClientID%>").val()) && ($("#txtEBCommFloatScale1").val() == "" || isNaN($("#txtEBCommFloatScale1").val()))) {
	                var a = $("#<%=txtEBComm.ClientID%>").val() * 1.0 / 100 * (1 - ($("#<%=txtEBDeveloper.ClientID%>").val() * 1.0 / 100));
	                $("#<%=txtEBDeduct.ClientID%>").val(a * 100);
	                $("#<%=HdE.ClientID%>").val(a * 100);
	            }
	            else if ($("#txtEBCommFloatScale1").val() == "" || isNaN($("#txtEBCommFloatScale1").val())) {
	                $("#<%=txtEBDeduct.ClientID%>").val($("#<%=txtEBComm.ClientID%>").val());
	                $("#<%=HdE.ClientID%>").val($("#<%=txtEBComm.ClientID%>").val());
                }

	            if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked") && !isNaN($("#<%=txtPCDeduct.ClientID%>").val()) && !isNaN($("#<%=txtEBDeduct.ClientID%>").val()) && $("#<%=HidAutoN.ClientID%>").val() * 1 < 3) {
	                $("#SingleRewardC1").hide();
	                //$("#SingleRewardC4").hide();
	                $("#SingleRewardC2").show();
	                $("#SingleRewardC3").show();
	                $("#<%=rdbHaveSingleReward2.ClientID%>").click();
                	                //$("#AnotherRewardC").hide();
                }
                else if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
                	                $("#SingleRewardC1").show();
                	                $("#SingleRewardC2").show();
                	                $("#SingleRewardC3").show();
                	                $("#SingleRewardC4").show();
                	            }
	            AutoC();
	            if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked") && $("#<%=HidAutoN.ClientID%>").val() * 1 >= 3) {
	                $("#SingleRewardC1").show();
	            }
	            else if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	                $("#SingleRewardC1").hide();
	            }
	        });













	        $("#<%=rdbProjectCost2.ClientID%>").click(function () {
	            $("#WZJ").show();
	            $("#SdAc").show();
	            if (!isNaN($("#<%=txtPCDeduct.ClientID%>").val()) && !isNaN($("#<%=txtEBDeduct.ClientID%>").val()) && $("#<%=HidAutoN.ClientID%>").val() * 1 < 3) {
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
	        });
	        $("#<%=rdbProjectCost1.ClientID%>").click(function () {
	            $("#WZJ").hide();
	            $("#SdAc").hide();
	            AutoAdd();
	        });

	        $("#<%=txtPCDeduct.ClientID%>").blur(function () {
	            if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")&&!isNaN($("#<%=txtPCDeduct.ClientID%>").val()) && !isNaN($("#<%=txtEBDeduct.ClientID%>").val()) && $("#<%=HidAutoN.ClientID%>").val() * 1 < 3) {
	                $("#SingleRewardC1").hide();
	                //$("#SingleRewardC4").hide();
	                $("#SingleRewardC2").show();
	                $("#SingleRewardC3").show();
	                $("#<%=rdbHaveSingleReward2.ClientID%>").click();
	                //$("#AnotherRewardC").hide();
	            }
	            else if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	                $("#SingleRewardC1").show();
	                $("#SingleRewardC2").show();
	                $("#SingleRewardC3").show();
	                $("#SingleRewardC4").show();
	            }
	            AutoC();
	            if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked") && $("#<%=HidAutoN.ClientID%>").val() * 1 >= 3) {
	                $("#SingleRewardC1").show();
	            }
	            else if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	                $("#SingleRewardC1").hide();
	            }
	        });
	        $("#<%=txtEBDeduct.ClientID%>").blur(function () {
	            if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")&&!isNaN($("#<%=txtPCDeduct.ClientID%>").val()) && !isNaN($("#<%=txtEBDeduct.ClientID%>").val()) && $("#<%=HidAutoN.ClientID%>").val() * 1 < 3) {
	                $("#SingleRewardC1").hide();
	                //$("#SingleRewardC4").hide();
	                $("#SingleRewardC2").show();
	                $("#SingleRewardC3").show();
	                $("#<%=rdbHaveSingleReward2.ClientID%>").click();
	                //$("#AnotherRewardC").hide();
	            }
	            else if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	                $("#SingleRewardC1").show();
	                $("#SingleRewardC2").show();
	                $("#SingleRewardC3").show();
	                $("#SingleRewardC4").show();
	            }
	            AutoC();
	            if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked") && $("#<%=HidAutoN.ClientID%>").val() * 1 >= 3) {
	                $("#SingleRewardC1").show();
	            }
	            else if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	                $("#SingleRewardC1").hide();
	            }
	        });


	        $("#<%=txtOwnerCommFixScale.ClientID%>").blur(function () {
	            if (!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
	                AutoAdd();
	        });
	        $("#<%=txtClientCommFixScale.ClientID%>").blur(function () {
	            if (!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
	                AutoAdd();
	        });
	        $("#<%=txtEBComm.ClientID%>").blur(function () {
	            if (!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
	                AutoAdd();
	        });
	        for (var io = 1; io <= $("[id^=txtOwnerCommFloatScale]").size(); io++) {
	            $("#txtOwnerCommFloatScale" + io).blur(function () {
	                if(!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
	                    AutoAdd();
	            });
	        }
	        for (var io = 1; io <= $("[id^=txtClientCommFloatScale]").size() ; io++) {
	            $("#txtClientCommFloatScale" + io).blur(function () {
	                if (!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
	                    AutoAdd();
	            });
	        }
	        for (var io = 1; io <= $("[id^=txtEBCommFloatScale]").size() ; io++) {
	            $("#txtEBCommFloatScale" + io).blur(function () {
	                if (!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
	                    AutoAdd();
	            });
	        }





	        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
	        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx210"));
	        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx211"));
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
        function AutoC() {
            var dd = $("#<%=txtPCDeduct.ClientID%>").val()*1 + $("#<%=txtEBDeduct.ClientID%>").val()*1;
            //dd = Math.abs(dd * 100).toFixed(2);
            if ($("#<%=txtPCDeduct.ClientID%>").val() * 1 > 100 || $("#<%=txtEBDeduct.ClientID%>").val() * 1 > 100 || dd*1 > 100) {
                $("#lbAutoCoculate").html("����ֵΪ��" + dd + "%���ѳ���100%���������ֽ𽱼��㣩");
                $("#<%=HidAutoN.ClientID%>").val(0);
            }
            else if (!isNaN(dd) && dd != "Infinity" && dd != "NaN") {
                $("#<%=HidAutoN.ClientID%>").val(dd);
                $("#lbAutoCoculate").html(dd + "%");
            }
            else {
                $("#lbAutoCoculate").html("���۳���ı�ֵ���˷����֣��������ֽ𽱼��㣩");
                $("#<%=HidAutoN.ClientID%>").val(0);
            }
        }

        function check() {
            if ($("#<%=cbBaseAgent2.ClientID%>").prop("checked") || $("#<%=cbBaseAgent3.ClientID%>").prop("checked")) { //M_0001��20151016
                alert("���ڴ���ѡ�˺ϸ��Իͻ��������޷����棡");
                $("#<%=cbBaseAgent2.ClientID%>").focus();
                return false;
            }
            if (!isNaN($("#txtOwnerCommFloatScale1").val()) && ($("#<%=txtOwnerCommFixScale.ClientID%>").val() == "" || isNaN($("#<%=txtOwnerCommFixScale.ClientID%>").val()))) {
                var a = $("#txtOwnerCommFloatScale1").val() * 1.0 / 100 * (1 - ($("#txtOwnerCommFloatScale1").val() * 1.0 / 100 * ($("#<%=txtPCDeveloper.ClientID%>").val() * 1.0 / 100)));
            	                $("#<%=txtPCDeduct.ClientID%>").val(a * 100);
            	                $("#<%=HdP.ClientID%>").val(a * 100);
            	            }
            	            else if (($("#<%=txtOwnerCommFixScale.ClientID%>").val() == "" || isNaN($("#<%=txtOwnerCommFixScale.ClientID%>").val())) && $("#txtOwnerCommFloatScale1").val() != "") {
            	                $("#<%=txtPCDeduct.ClientID%>").val($("#txtOwnerCommFloatScale1").val());
	                $("#<%=HdP.ClientID%>").val($("#txtOwnerCommFloatScale1").val());
	            }
            if (!isNaN($("#<%=txtOwnerCommFixScale.ClientID%>").val()) && ($("#txtOwnerCommFloatScale1").val() == "" || isNaN($("#txtOwnerCommFloatScale1").val()))) {
                var a = $("#<%=txtOwnerCommFixScale.ClientID%>").val() * 1.0 / 100 * (1 - ($("#<%=txtOwnerCommFixScale.ClientID%>").val() * 1.0 / 100 * ($("#<%=txtPCDeveloper.ClientID%>").val() * 1.0 / 100)));
	                $("#<%=txtPCDeduct.ClientID%>").val(a * 100);
	                $("#<%=HdP.ClientID%>").val(a * 100);
	            }
	            else if ($("#txtOwnerCommFloatScale1").val() == "" || isNaN($("#txtOwnerCommFloatScale1").val())) {
	                $("#<%=txtPCDeduct.ClientID%>").val($("#<%=txtOwnerCommFixScale.ClientID%>").val());
                    $("#<%=HdP.ClientID%>").val($("#<%=txtOwnerCommFixScale.ClientID%>").val());
	            }
            if (!isNaN($("#txtEBCommFloatScale1").val()) && ($("#<%=txtEBComm.ClientID%>").val() == "" || isNaN($("#<%=txtEBComm.ClientID%>").val()))) {
                var a = $("#txtEBCommFloatScale1").val() * 1.0 / 100 * (1 - ($("#txtEBCommFloatScale1").val() * 1.0 / 100 * ($("#<%=txtEBDeveloper.ClientID%>").val() * 1.0 / 100)));
            	                $("#<%=txtEBDeduct.ClientID%>").val(a * 100);
            	                $("#<%=HdE.ClientID%>").val(a * 100);
            	            }
            	            else if (($("#<%=txtEBComm.ClientID%>").val() == "" || isNaN($("#<%=txtEBComm.ClientID%>").val())) && $("#txtEBCommFloatScale1").val() != "") {
            	                $("#<%=txtEBDeduct.ClientID%>").val($("#txtEBCommFloatScale1").val());
                	                $("#<%=HdE.ClientID%>").val($("#txtEBCommFloatScale1").val());
                	            }
                            if (!isNaN($("#<%=txtEBComm.ClientID%>").val()) && ($("#txtEBCommFloatScale1").val() == "" || isNaN($("#txtEBCommFloatScale1").val()))) {
                var a = $("#<%=txtEBComm.ClientID%>").val() * 1.0 / 100 * (1 - ($("#<%=txtEBComm.ClientID%>").val() * 1.0 / 100 * ($("#<%=txtEBDeveloper.ClientID%>").val() * 1.0 / 100)));
	                $("#<%=txtEBDeduct.ClientID%>").val(a * 100);
	                $("#<%=HdE.ClientID%>").val(a * 100);
	            }
	            else if ($("#txtEBCommFloatScale1").val() == "" || isNaN($("#txtEBCommFloatScale1").val())) {
	                $("#<%=txtEBDeduct.ClientID%>").val($("#<%=txtEBComm.ClientID%>").val());
	                $("#<%=HdE.ClientID%>").val($("#<%=txtEBComm.ClientID%>").val());
	            }





	        if ($.trim($("#<%=txtApplyForID.ClientID%>").val()) == "") {alert("�����˹��Ų���Ϊ�գ�");$("#<%=txtApplyForID.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtApplyFor.ClientID%>").val()) == "") {alert("����ȷ��д�����˹��ţ�");$("#<%=txtApplyForID.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=ddlDepartmentType.ClientID%>").val()) == "") {alert("��ѡ����������");$("#<%=ddlDepartmentType.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtProject.ClientID%>").val()) == "") {alert("��Ŀ���Ʋ���Ϊ�գ�");$("#<%=txtProject.ClientID%>").focus();return false;}
	        if ($.trim($("#<%=txtDeveloper.ClientID %>").val()) == "") { alert("��Ŀ��չ��(Сҵ��)����Ϊ�գ�"); $("#<%=txtDeveloper.ClientID %>").focus(); return false; }
	        //if ($.trim($("#<%=txtGroupName.ClientID%>").val()) == "") { alert("�����������Ʋ���Ϊ�գ�"); $("#<%=txtGroupName.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=ddlProjectProperty.ClientID%>").val()) == "") {alert("��ѡ����Ŀ���ʣ�");$("#<%=ddlProjectProperty.ClientID%>").focus();return false;}
            if ($.trim($("#<%=ddlDealType.ClientID%>").val()) == "") {alert("��ѡ��������ͣ�");$("#<%=ddlDealType.ClientID%>").focus();return false;}
            if ($.trim($("#<%=ddlAgentProperty.ClientID%>").val()) == "") {alert("��ѡ��������ʣ�");$("#<%=ddlAgentProperty.ClientID%>").focus();return false;}
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
            if ($("[id*=cblDealOfficeType_3]").prop("checked")) {
                if (!$("#<%=rdbIsMallSplit.ClientID%>").prop("checked") && !$("#<%=rdbIsNotMallSplit.ClientID%>").prop("checked")) {
                    alert("��ѡ����������");
                    $("#<%=rdbIsMallSplit.ClientID%>").focus();
                    return false;
                }

                if (!$("#<%=rdbIsUploadPlan1.ClientID%>").prop("checked") && !$("#<%=rdbIsUploadPlan2.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ����ϴ��ֳ���Ƭ��ƽ��ͼ");
                    $("#<%=rdbIsUploadPlan1.ClientID%>").focus();
                    return false;
                }

                if (!$("#<%=rdbIsMallOpen.ClientID%>").prop("checked") && !$("#<%=rdbIsNotMallOpen.ClientID%>").prop("checked")) {
                    alert("��ѡ���̳��Ƿ����ھ�Ӫ");
                    return false;
                }
            }

	        if ($.trim($("#<%=txtProjectArea.ClientID%>").val()) == "") { alert("��ϸ��ַ����Ϊ�գ�"); $("#<%=txtProjectArea.ClientID%>").focus(); return false; }
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
	        //if ($.trim($("#<%=txtClientGuardStartDate.ClientID%>").val()) == "") { alert("�ͻ������ڿ�ʼ���ڲ���Ϊ�գ�"); $("#<%=txtClientGuardStartDate.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtClientGuardEndDate.ClientID%>").val()) == "") { alert("�ͻ������ڽ������ڲ���Ϊ�գ�"); $("#<%=txtClientGuardEndDate.ClientID%>").focus(); return false; }

	        if ($.trim($("#<%=txtTermsOfContract.ClientID%>").val()) == "") { alert("��ͬԼ���Ľ�Ӷ�����Ϊ�գ�"); $("#<%=txtTermsOfContract.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtTermsOfMajorIssues.ClientID%>").val()) == "") { alert("�ش�����ĺ�ͬ�����Ϊ�գ�"); $("#<%=txtTermsOfMajorIssues.ClientID%>").focus(); return false; }

	        if ($.trim($("#<%=txtPreCompleteNumber.ClientID%>").val()) == "") { alert("Ԥ������������ɻ�����������Ϊ�գ�"); $("#<%=txtPreCompleteNumber.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtPreCompleteMoney.ClientID%>").val()) == "") { alert("Ԥ������������ɻ�������Ϊ�գ�"); $("#<%=txtPreCompleteMoney.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtPreCompleteComm.ClientID%>").val()) == "") { alert("Ԥ������������ɻ���Ӷ�����벻��Ϊ�գ�"); $("#<%=txtPreCompleteComm.ClientID%>").focus(); return false; }
	        if ($.trim($("#<%=txtReportAddress.ClientID%>").val()) == "") { alert("������ַ����Ϊ�գ�"); $("#<%=txtReportAddress.ClientID%>").focus(); return false; }

	        //if ($.trim($("#<%=txtLastBeginDate.ClientID%>").val()) == "") { alert("��һ����ʼ�ڲ���Ϊ�գ�"); $("#<%=txtLastBeginDate.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtLastEndDate.ClientID%>").val()) == "") { alert("��һ��������ڲ���Ϊ�գ�"); $("#<%=txtLastEndDate.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtLastSumNum.ClientID%>").val()) == "") { alert("��һ�����Ч��������Ϊ�գ�"); $("#<%=txtLastSumNum.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtLastResults.ClientID%>").val()) == "") { alert("��һ����ɽ�ҵ������Ϊ�գ�"); $("#<%=txtLastResults.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtCumulativeBeginDate.ClientID%>").val()) == "") { alert("�ۼƳɽ���ʼ�ղ���Ϊ�գ�"); $("#<%=txtCumulativeBeginDate.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtCumulativeEndDate.ClientID%>").val()) == "") { alert("�ۼƳɽ������ղ���Ϊ�գ�"); $("#<%=txtCumulativeEndDate.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtCumulativeNum.ClientID%>").val()) == "") { alert("�ۼƳɽ���������Ϊ�գ�"); $("#<%=txtCumulativeNum.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtCumulativeResults.ClientID%>").val()) == "") { alert("�ۼƳɽ�ҵ������Ϊ�գ�"); $("#<%=txtCumulativeResults.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtTurnover.ClientID%>").val()) == "") { alert("�ɽ����Ϊ�գ�"); $("#<%=txtTurnover.ClientID%>").focus(); return false; }
	        //if ($.trim($("#<%=txtSumTurnover.ClientID%>").val()) == "") { alert("�ܳɽ����Ϊ�գ�"); $("#<%=txtSumTurnover.ClientID%>").focus(); return false; }

	        

	        

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
	        if ($("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtPCDeveloper.ClientID%>").val()) == "") { alert("��չ����Ŀ���ò���Ϊ�գ�"); $("#<%=txtPCDeveloper.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtEBDeveloper.ClientID%>").val()) == "") { alert("������Ŀ���ò���Ϊ�գ�"); $("#<%=txtEBDeveloper.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtPCDeduct.ClientID%>").val()) == "") { alert("�۳������Ѻ�ʵ�շ�չ��Ӷ�㲻��Ϊ�գ�"); $("#<%=txtPCDeduct.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtEBDeduct.ClientID%>").val()) == "") { alert("�۳������Ѻ�ʵ�յ���Ӷ�㲻��Ϊ�գ�"); $("#<%=txtEBDeduct.ClientID%>").focus(); return false; }
	            if (!$("#<%=rdbCooperationWay1.ClientID%>").prop("checked") && !$("#<%=rdbCooperationWay2.ClientID%>").prop("checked") && !$("#<%=rdbCooperationWay3.ClientID%>").prop("checked")) {
	                alert("��ѡ������ѳе���ʽ");
	                return false;
	            }
	            //if (isNaN($("#<%=txtPCDeduct.ClientID%>").val())) {
	            //    alert("�۳������Ѻ�ʵ�շ�չ��Ӷ��������봿����");
	            //    $("#<%=txtPCDeduct.ClientID%>").focus();
	            //    return false;
	            //}
	            //if (isNaN($("#<%=txtEBDeduct.ClientID%>").val())) {
	            //    alert("�۳������Ѻ�ʵ�յ���Ӷ��������봿����");
	            //    $("#<%=txtEBDeduct.ClientID%>").focus();
	            //    return false;
                //}
	        }

	        if (!$("#<%=rdbJOrT1.ClientID%>").prop("checked") && !$("#<%=rdbJOrT2.ClientID%>").prop("checked") && !$("#<%=rdbJOrT3.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ����м����ϴ������������");
	            $("#<%=rdbJOrT1.ClientID%>").focus();
	            return false;
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
	        if ($("#<%=rdbJOrT2.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtTurnsAgentXX1.ClientID%>").val()) == "") { alert("����������м�����1����Ϊ�գ�"); $("#<%=txtTurnsAgentXX1.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtTurnsAgentXX2.ClientID%>").val()) == "") { alert("����������м�����2����Ϊ�գ�"); $("#<%=txtTurnsAgentXX2.ClientID%>").focus(); return false; }

	            if ($.trim($("#<%=txtAgencyFee3.ClientID%>").val()) == "") { alert("���������мҴ����1����Ϊ�գ�"); $("#<%=txtAgencyFee3.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtAgencyFee4.ClientID%>").val()) == "") { alert("���������мҴ����2����Ϊ�գ�"); $("#<%=txtAgencyFee4.ClientID%>").focus(); return false; }
	            if ($("#<%=rdbIsCashPrize31.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtCashPrize3.ClientID%>").val()) == "") { alert("���������м��ֽ�1����Ϊ�գ�"); $("#<%=txtCashPrize3.ClientID%>").focus(); return false; }
	            }
                if ($("#<%=rdbIsCashPrize41.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtCashPrize4.ClientID%>").val()) == "") { alert("���������м��ֽ�2����Ϊ�գ�"); $("#<%=txtCashPrize4.ClientID%>").focus(); return false; }
                }
	            if (!$("#<%=rdbIsCashPrize31.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize32.ClientID%>").prop("checked")) {
	                alert("��ѡ���Ƿ������������м��ֽ�1");
	                $("#<%=rdbIsCashPrize31.ClientID%>").focus();
	                return false;
	            }
	            if (!$("#<%=rdbIsCashPrize41.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize42.ClientID%>").prop("checked")) {
	                alert("��ѡ���Ƿ������������м��ֽ�2");
	                $("#<%=rdbIsCashPrize41.ClientID%>").focus();
	                return false;
	            }

	            if ($("#<%=rdbIsPFear31.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtPFear3.ClientID%>").val()) == "") { alert("���������м���Ŀ����3����Ϊ�գ�"); $("#<%=txtPFear3.ClientID%>").focus(); return false; }
                }
                if ($("#<%=rdbIsPFear41.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtPFear4.ClientID%>").val()) == "") { alert("���������м���Ŀ����4����Ϊ�գ�"); $("#<%=txtPFear4.ClientID%>").focus(); return false; }
                }
                if (!$("#<%=rdbIsPFear31.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear32.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ������������м���Ŀ����3");
	                $("#<%=rdbIsPFear31.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsPFear41.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear42.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ������������м���Ŀ����4");
	                $("#<%=rdbIsPFear41.ClientID%>").focus();
                    return false;
                }
	            if ($.trim($("#<%=txtAgencyBeginDate1.ClientID%>").val()) == "") { alert("���������мҴ���ʼ��1����Ϊ�գ�"); $("#<%=txtAgencyBeginDate1.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtAgencyBeginDate2.ClientID%>").val()) == "") { alert("���������мҴ���ʼ��2����Ϊ�գ�"); $("#<%=txtAgencyBeginDate2.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtAgencyEndDate1.ClientID%>").val()) == "") { alert("���������мҴ��������1����Ϊ�գ�"); $("#<%=txtAgencyFee3.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtAgencyEndDate2.ClientID%>").val()) == "") { alert("���������мҴ��������2����Ϊ�գ�"); $("#<%=txtAgencyFee4.ClientID%>").focus(); return false; }
	        }

	        if (!$("#<%=rdbProjectCost1.ClientID%>").prop("checked") && !$("#<%=rdbProjectCost2.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ�����Ŀ���ã������ѣ�");
	            return false;
	        }
	        
	        if (!$("#<%=rdbIsProjEarlyCommBack.ClientID%>").prop("checked") && !$("#<%=rdbIsProjEarlyCommBack2.ClientID%>").prop("checked") && !$("#<%=rdbIsProjEarlyCommNotBack.ClientID%>").prop("checked") && !$("#<%=rdbIsProjEarlyCommhavent.ClientID%>").prop("checked")) {
	            alert("��ѡ����Ŀǰ��Ӷ���Ƿ����ջ�");
	            return false;
	        }
	        else if ($("#<%=rdbIsProjEarlyCommBack.ClientID%>").prop("checked")) {
	            if ($("#<%=txtOweCommSum.ClientID%>").val() == "") {
	                alert("������ѡ������Ŀǰ��Ӷ�����ջأ�����дǷӶ��");
	                $("#<%=txtOweCommSum.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtAreaPromiseBackDate.ClientID%>").val() == "") {
	                alert("������ѡ������Ŀǰ��Ӷ�����ջأ�����д�����ŵ�ջ�ʱ�䡣");
	                $("#<%=txtAreaPromiseBackDate.ClientID%>").focus();
	                return false;
	            }
	        }
	        else if ($("#<%=rdbIsProjEarlyCommBack2.ClientID%>").prop("checked")) {
	            if ($("#<%=txtNHComm.ClientID%>").val() == "") {
	                alert("������ѡ���˷Ǳ���ǷӶ������дǷӶ��");
                    $("#<%=txtNHComm.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=txtNHName.ClientID%>").val() == "") {
                    alert("������ѡ���˷Ǳ���ǷӶ������д�����������");
                    $("#<%=txtNHName.ClientID%>").focus();
	                return false;
                }
	            if ($("#<%=txtNHTime.ClientID%>").val() == "") {
	                alert("������ѡ���˷Ǳ���ǷӶ������д������ų�ŵ�ջ�ʱ�䡣");
	                $("#<%=txtNHTime.ClientID%>").focus();
                    return false;
                }
	        }
	        else if ($("#<%=rdbIsProjEarlyCommNotBack.ClientID%>").prop("checked")) {
	            if ($("#<%=txtHere.ClientID%>").val() == "") {
                    alert("������ѡ����û��ǷӶ������д����Ӷ��Ĳ��š�");
                    $("#<%=txtHere.ClientID%>").focus();
	                return false;
                }
            }

	        if (!$("#<%=rdbOwnerCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbOwnerCommJump2.ClientID%>").prop("checked")) {
	            alert("��ѡ��ҵӶ��BAR��ʽ");
	            $("#<%=rdbOwnerCommJump1.ClientID%>").focus();
	            return false;
	        }
	        if (!$("#<%=rdbClientCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbClientCommJump2.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ӷ��BAR��ʽ");
	            $("#<%=rdbClientCommJump1.ClientID%>").focus();
	            return false;
	        }
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
	        if ($("#<%=rdbHaveSingleReward2.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtRewardSignHavent.ClientID%>").val()) == "") {
	                alert("С��3%�ĵ����ֽ𽱲���Ϊ�գ�");
                    $("#<%=txtRewardSignHavent.ClientID%>").focus();
	                return false;
                }
                if (isNaN($("#<%=txtRewardSignHavent.ClientID%>").val())) {
                    alert("С��3%�ĵ����ֽ𽱱������봿����");
                    $("#<%=txtRewardSignHavent.ClientID%>").focus();
	                return false;
                }
	        }

            if ($("#<%=rdbIsCoopWithECommerce.ClientID%>").prop("checked")) {
                if ($.trim($("#<%=txtECommerceName.ClientID%>").val()) == "") {
                    alert("����д���̹�˾���ƣ�");
                    $("#<%=txtECommerceName.ClientID%>").focus();
	                return false;
                }
            }
            if ($("#<%=rdbIsNoCoopWithECommerce.ClientID%>").prop("checked")) {
                if ($.trim($("#<%=txtECommerceName2.ClientID%>").val()) == "") {
                    alert("����д���̹�˾���ƣ�");
                    $("#<%=txtECommerceName2.ClientID%>").focus();
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
	            if ($.trim($("#<%=txtReceiveRewardName.ClientID%>").val()) == "") { alert("�ֽ𽱽�������������Ϊ�գ�"); $("#<%=txtReceiveRewardName.ClientID%>").focus(); return false; }
	            if ($.trim($("#<%=txtReceiveRewardNo.ClientID%>").val()) == "") { alert("�ֽ𽱽������˺Ų���Ϊ�գ�"); $("#<%=txtReceiveRewardNo.ClientID%>").focus(); return false; }
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

	        if (!$("#<%=rdbIsExistMortgage.ClientID%>").prop("checked") && !$("#<%=rdbIsNotExistMortgage.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ���ڵ�Ѻ");
	            return false;
	        }

	        if (!$("#<%=rdbIsExistLeasebackRules.ClientID%>").prop("checked") && !$("#<%=rdbIsNotExistLeasebackRules.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ���ڷ�������");
	            return false;
	        }

	        if (!$("#<%=rdbHavePreSaleLicenses.ClientID%>").prop("checked") && !$("#<%=rdbNoPreSaleLicenses.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ���Ԥ�����֤�򷿲�֤");
	            return false;
	        }

	        if (!$("#<%=rdbIsWithPropertyOwnerSignContract.ClientID%>").prop("checked") && !$("#<%=rdbIsNotWithPropertyOwnerSignContract.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ����Ȩ��ǩ���ͬ");
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
	            if ($("#<%=AreaScale1.ClientID%>").val() == "") {
	                alert("������ѡ���˶������̣�����дͳ�������ơ�");
	                $("#<%=AreaScale1.ClientID%>").focus();
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
	            if ($("#<%=AreaScale.ClientID%>").val() == "") {
	                alert("������ѡ���˺������̣�����дͳ�������ơ�");
	                $("#<%=AreaScale.ClientID%>").focus();
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

	        
	        if ($.trim($("#<%=ddlAgentProperty.ClientID%>").find("option:selected").text()) == "��Լ")
	        {
	            if ($("#<%=txtLastBeginDate.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д��һ����ʼ�ڣ�");
	                $("#<%=txtLastBeginDate.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtLastEndDate.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д��һ��������ڣ�");
	                $("#<%=txtLastEndDate.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtLastSumNum.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д��һ�����Ч������");
	                $("#<%=txtLastSumNum.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtLastResults.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д��һ����ɽ�ҵ����");
	                $("#<%=txtLastResults.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtCumulativeBeginDate.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д�ۼƳɽ���ʼ�գ�");
	                $("#<%=txtCumulativeBeginDate.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtCumulativeEndDate.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д�ۼƳɽ������գ�");
	                $("#<%=txtCumulativeEndDate.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtCumulativeNum.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д�ۼƳɽ�������");
	                $("#<%=txtCumulativeNum.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtCumulativeResults.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д�ۼƳɽ�ҵ����");
	                $("#<%=txtCumulativeResults.ClientID%>").focus();
	                return false;
	            }

	            if ($("#<%=txtTurnover.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д�ɽ��");
	                $("#<%=txtTurnover.ClientID%>").focus();
	                return false;
	            }
	            if ($("#<%=txtSumTurnover.ClientID%>").val() == "") {
	                alert("���ڴ�����������Լ������д�ܳɽ��");
	                $("#<%=txtSumTurnover.ClientID%>").focus();
	                return false;
                }
            }
	        
	        

	        if (!$("#<%=rdbIsNeedExtension.ClientID%>").prop("checked") && !$("#<%=rdbIsNotNeedExtension.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ���Ҫ�ƹ���Ŀ��Ϣ������");
	            return false;
	        }

	        if (!$("#<%=rdbIsNeedBroadcast.ClientID%>").prop("checked") && !$("#<%=rdbIsNotNeedBroadcast.ClientID%>").prop("checked")) {
	            alert("��ѡ���Ƿ���Ҫ��˾����������Ŀ��Ϣ");
	            return false;
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
	            data += $.trim($("#txtEBCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtEBCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtEBCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtEBCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtEBCommFloatScale" + n).val()) + "&&" + $.trim($("#txtEBCommPublishedScale" + n).val()) + "||";
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
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID%>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID%>', "dialogHeight=165px");
		    if(sReturnValue=='success')
		        window.location = 'Apply_NewUndertakeProj_Detail.aspx?MainID=<%=MainID%>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_UndertakeProj_Flow.aspx?MainID=<%=MainID%>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location = "Apply_NewUndertakeProj_Detail.aspx?MainID=<%=MainID%>";
        }

        function CancelSign(idc) {
            if (confirm("����������֮��������������ڶ���������ȷ��Ҫ���������"))  //20141202��CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }

	    function sign(idx) {
	        //if (idx != '4'&&idx != '5'&&idx != '6') {
	        //    if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbNoIDx" + idx).prop("checked")) {
	        //        alert("��ȷ���Ƿ�ͬ�⣡");
	        //        return;
	        //    }
	        //}
	        //else {
	        //    if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbNoIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
	        //        alert("��ȷ���Ƿ�ͬ�⣡");
	        //        return;
	        //    }
	        //}

	        if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbNoIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
	            alert("��ȷ���Ƿ�ͬ�⣡");
	            return;
	        }

	        if ($("#rdbNoIDx" + idx).prop("checked") && $.trim($("#txtIDx" + idx).val()) == "") {
	            alert("��������ͬ������룬������д��ͬ���ԭ��");
	            return;
	        }
	        if ($("#rdbOtherIDx" + idx).prop("checked") && $.trim($("#txtIDx" + idx).val()) == "") {
	            alert("������ѡ���������������д�����");
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
            $("#txtOwnerCommFloatScale" + i1).blur(function () {
                if (!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
                    AutoAdd();
            });
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
            $("#txtClientCommFloatScale" + i2).blur(function () {
                if (!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
                    AutoAdd();
            });
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
				+ '     <td style="border:none;"><input type="text" id="txtEBCommFloatSetNumberStart' + i3 + '" style="width:50px"/>��<input type="text" id="txtEBCommFloatSetNumberEnd' + i3 + '" style="width:50px"/>��/<input type="text" id="txtEBCommFloatMoneyStart' + i3 + '" style="width:50px"/>��<input type="text" id="txtEBCommFloatMoneyEnd' + i2 + '" style="width:50px"/>Ԫ���۶��ͬ�����<input type="text" id="txtEBCommFloatScale' + i3 + '" style="width:50px"/>%�����������<input type="text" id="txtEBCommPublishedScale' + i3 + '" style="width:50px"/>%</td>'
				+ '</tr>';

            $("#tEB").append(html);
            $("#txtEBCommFloatScale" + i3).blur(function () {
                if (!$("#<%=rdbProjectCost2.ClientID%>").prop("checked"))
                    AutoAdd();
            });
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
			<h1>��ҵ���н���Ŀ���������</h1>
            <input type="button" id="btnADelete" value="�Ƿ�ͬ��ɾ����" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:720px;margin:0 auto;"><span style="float:right;" class="file_number">�ĵ�����(�Զ�����)��<%=SerialNumber%></span></div>
			<%--style="border-style:double; border-color:Black; border-width:5px; margin: 0 auto; background-color: #fff; border-collapse: collapse;" --%>
            <table id="tbAround" width='720px'>
				<tr>
					<td style="width:20%">���벿��</td>
					<td class="tl PL10"><input id="txtDepartment" type="text" runat="server" readonly="readonly" style="background-color:Silver; "/><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td style="width:20%">������</td>
					<td class="auto-style1">���ţ�<asp:TextBox ID="txtApplyForID" runat="server" Width="40px" onblur="getEmployee(this);"></asp:TextBox><span id="spanApplyFor" style="display:none;">&nbsp;&nbsp;&nbsp;&nbsp;������<input id="txtApplyFor" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span></td>
				</tr>
                <tr>
					<td>��������</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlDepartmentType" runat="server"></asp:DropDownList></td>
                    <td>��������</td>
					<td class="auto-style1"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
					<td>��д��</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td>�ظ��绰</td>
					<td class="auto-style1"><asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <th colspan="4" style="line-height:25px;" >��������</th>
				</tr>
                <tr>
					<td>��Ŀ����</td>
					<td class="tl PL10"><asp:TextBox ID="txtProject" runat="server"></asp:TextBox></td>
                    <td>��Ŀ��չ��<br />(Сҵ��)</td>
					<td class="auto-style1"><asp:TextBox ID="txtDeveloper" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>������������</td>
					<td class="tl PL10"><asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox></td>
                    <td>���ڴ���</td>
                    <td class="auto-style1">
                        <asp:CheckBox ID="cbBaseAgent1" runat="server" Text="��ԭ��Ŀ��" />
                        <asp:CheckBox ID="cbBaseAgent2" runat="server" Text="�ϸ��Ի�" />
                        <asp:CheckBox ID="cbBaseAgent3" runat="server" Text="����" /><br />
                        <asp:CheckBox ID="cbBaseAgent4" runat="server" Text="����" />
                        <asp:TextBox ID="txtBaseAgentOther" runat="server" Width="145px"></asp:TextBox>
                    </td>
				</tr>
                
                <tr>
					<td>��Ŀ����</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlProjectProperty" runat="server"></asp:DropDownList></td>
                    <td>��������</td>
					<td class="auto-style1"><asp:DropDownList ID="ddlDealType" runat="server"></asp:DropDownList></td>
				</tr>
                <tr>
					<td>��������</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlAgentProperty" runat="server"></asp:DropDownList></td>
				    <td>��Ŀ��������</td>
					<td class="auto-style1"><asp:TextBox ID="txtProjectArea" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <td colspan="4" style="text-align: left; line-height: 20px; padding-left: 5px;">
                        ����Ŀ����Լ������Ϊ�����<br />
                        ��һ�����ڣ���<asp:TextBox ID="txtLastBeginDate" runat="server" Width="75px"></asp:TextBox>����<asp:TextBox ID="txtLastEndDate" runat="server" Width="75px"></asp:TextBox>�գ�
                        �ɽ�����<asp:TextBox ID="txtLastSumNum" runat="server" Width="75px"></asp:TextBox>
                        �ɽ���<asp:TextBox ID="txtTurnover" runat="server" Width="75px"></asp:TextBox>
                        �ɽ�ҵ��<asp:TextBox ID="txtLastResults" runat="server" Width="75px"></asp:TextBox><br />    
                        �ۼ��ܳɽ�����<asp:TextBox ID="txtCumulativeBeginDate" runat="server" Width="75px"></asp:TextBox>����<asp:TextBox ID="txtCumulativeEndDate" runat="server" Width="75px"></asp:TextBox>�գ�
                        �ܳɽ�����<asp:TextBox ID="txtCumulativeNum" runat="server" Width="60px"></asp:TextBox>
                        �ܳɽ���<asp:TextBox ID="txtSumTurnover" runat="server" Width="60px"></asp:TextBox>
                        �ܳɽ�ҵ��<asp:TextBox ID="txtCumulativeResults" runat="server" Width="68px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
					<td>��ҵ����</td>
					<td class="tl PL10" colspan="3">
                        <asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="cblDealOfficeType_SelectedIndexChanged"></asp:CheckBoxList>
                        <asp:HiddenField ID="hdDealOfficeType" runat="server" />
					</td>
				</tr>
                <tr>
                    <td>��ϸ��ַ</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtProjectAddress" runat="server" Width="90%"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>������ַ</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtReportAddress" runat="server" Width="90%"></asp:TextBox></td>
				</tr>
                <tr>
					<td>��չ��<br />��ϵ��</td>
					<td colspan="3" class="tl PL10">����<asp:TextBox ID="txtDeveloperContacter" runat="server" Width="100px"></asp:TextBox>ְλ<asp:TextBox ID="txtDeveloperContacterPosition" runat="server" Width="100px"></asp:TextBox>��ϵ�绰<asp:TextBox ID="txtDeveloperContacterPhone" runat="server" Width="100px"></asp:TextBox></td>
				</tr>
                <tr>
					<td>�������<br />��ϵ��</td>
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
					<td colspan="3" class="tl PL10"><asp:RadioButton ID="rdbIsCoopWithECommerce" runat="server" Text="�ǣ����̹�˾����" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName" runat="server" Width="300px"></asp:TextBox><br />
                        <asp:RadioButton ID="rdbIsNoCoopWithECommerce" runat="server" Text="�񣬵��ͻ���Ҫ�ڵ��̹�˾ˢ���Ի�ȡ���Żݣ����̹�˾����" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName2" runat="server" Width="415px"></asp:TextBox><br />
                        <asp:RadioButton ID="rdbIsNo2CoopWithECommerce" runat="server" Text="��������Ŀû���κε��̲���" GroupName="CoopWithECommerce" />
					</td>
				</tr>
                <tr>
					<td>��������</td>
					<td colspan="3" class="tl PL10">(1)ҵӶ������Ҫ���㵥���ֽ𽱣���ͬ����ѱ�����д������ʾ�ٷֱȵĴ����֣�
                        <br />�̶���Ӷ����ͬ�����<asp:TextBox ID="txtOwnerCommFixScale" runat="server" Width="80px"></asp:TextBox>%����������ѣ��۳������Ѻ�ʵ�գ���<asp:TextBox ID="txtOwnerCommAgent" runat="server" Width="80px"></asp:TextBox>%<br />
				        �䶯��Ӷ������<br />
                        <table id="tOwner" class='sample tc' width='100%' style="border:none;">
							<tr id="trOwner1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtOwnerCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtOwnerCommFloatSetNumberEnd1" style="width:50px"/>��/<input type="text" id="txtOwnerCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtOwnerCommFloatMoneyEnd1" style="width:50px"/>Ԫ���۶<input type="text" id="txtOwnerCommFloatKind1" style="width:80px"/>����дסլ/��Ԣ/�����Ȳ�ͬ���ͣ���ͬ�����<input type="text" id="txtOwnerCommFloatScale1" style="width:50px"/>%�����������<input type="text" id="txtOwnerCommPublishedScale1" style="width:50px"/>%</td>
				            </tr>
                            <%=SbHtml1.ToString()%>
                        </table>
                        Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbOwnerCommJump1" runat="server" Text="ȫ��BAR" GroupName="OwnerCommJump" />
                        <asp:RadioButton ID="rdbOwnerCommJump2" runat="server" Text="�ּ���BAR" GroupName="OwnerCommJump" /><br />
                        <asp:HiddenField ID="hdOwner" runat="server" />
                        <input type="button" id="btnAddRow1" value="�������" onclick="addRow1();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow1" value="ɾ��һ��" onclick="deleteRow1();" style=" float:left; display:none"/><br /><br />
                        
                        (2)��Ӷ������Ҫ���㵥���ֽ𽱣���ͬ����ѱ�����д������ʾ�ٷֱȵĴ����֣�
                        <br />�̶���Ӷ����ͬ�����<asp:TextBox ID="txtClientCommFixScale" runat="server" Width="80px"></asp:TextBox>%����������ѣ��۳������Ѻ�ʵ�գ���<asp:TextBox ID="txtClientCommAgent" runat="server" Width="80px"></asp:TextBox>%<br />
                        �䶯��Ӷ������<br />
					    <table id="tClient" class='sample tc' width='100%' style="border:none;">
                            <tr id="trClient1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtClientCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtClientCommFloatSetNumberEnd1" style="width:50px"/>��/<input type="text" id="txtClientCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtClientCommFloatMoneyEnd1" style="width:50px"/>Ԫ���۶��ͬ�����<input type="text" id="txtClientCommFloatScale1" style="width:50px"/>%�����������<input type="text" id="txtClientCommPublishedScale1" style="width:50px"/>%</td>
			                </tr>
							<%=SbHtml2.ToString()%>
					    </table>
                        Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbClientCommJump1" runat="server" Text="ȫ��BAR" GroupName="ClientCommJump" />
                        <asp:RadioButton ID="rdbClientCommJump2" runat="server" Text="�ּ���BAR" GroupName="ClientCommJump" /><br />
                        <asp:HiddenField ID="hdClient" runat="server" />
                        <input type="button" id="btnAddRow2" value="�������" onclick="addRow2();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow2" value="ɾ��һ��" onclick="deleteRow2();" style=" float:left;display:none"/><br /><br />
                        
                        (3)����Ӷ������Ҫ���㵥���ֽ𽱣���ͬ����ѱ�����д������ʾ�ٷֱȵĴ����֣�
                        <br />�̶���Ӷ����ͬ�����<asp:TextBox ID="txtEBComm" runat="server" Width="70px"></asp:TextBox>%����������ѣ��۳����̷��ü������Ѻ�ʵ�գ���<asp:TextBox ID="txtEBCommAgent" runat="server" Width="70px"></asp:TextBox>%<br />
                        �䶯��Ӷ������<br />
					    <table id="tEB" class='sample tc' width='100%' style="border:none;">
                            <tr id="trEB1"  style="border:none;">
				                <td style="border:none;"><input type="text" id="txtEBCommFloatSetNumberStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtEBCommFloatSetNumberEnd1" style="width:50px"/>��/<input type="text" id="txtEBCommFloatMoneyStart1" style="width:50px" readonly="readonly" value="0"/>��<input type="text" id="txtEBCommFloatMoneyEnd1" style="width:50px"/>Ԫ���۶��ͬ�����<input type="text" id="txtEBCommFloatScale1" style="width:50px"/>%�����������<input type="text" id="txtEBCommPublishedScale1" style="width:50px"/>%</td>
			                </tr>
							<%=SbHtml3.ToString()%>
					    </table>
                        Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbEBCommJump1" runat="server" Text="ȫ��BAR" GroupName="EBCommJump" />
                        <asp:RadioButton ID="rdbEBCommJump2" runat="server" Text="�ּ���BAR" GroupName="EBCommJump" /><br />
                        <asp:HiddenField ID="hdEB" runat="server" /><br />
                        ������������<br />
                        <asp:textbox id="txtRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:textbox>
                        <input type="button" id="btnAddRow3" value="�������" onclick="addRow3();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow3" value="ɾ��һ��" onclick="deleteRow3();" style=" float:left;display:none"/><br /><br />
                        
                        ��Ŀ���ã������ѣ���<asp:RadioButton ID="rdbProjectCost1" runat="server" Text="��" GroupName="ProjectCost" /><asp:RadioButton ID="rdbProjectCost2" runat="server" Text="��" GroupName="ProjectCost" />
                        ����Ŀ���ñ��������������ύ��������ͬ�ⷽ����Ч��<br />
                        <div id="WZJ">
                        ���У���չ��Ӷ�����Ѽ��᣺<asp:TextBox ID="txtPCDeveloper" runat="server"></asp:TextBox><br />     
                            �������۳������Ѻ�ʵ�շ�չ��Ӷ�㣺��ϵͳ���ù�ʽ���㣬ʵ�շ�չ��Ӷ��=ҵӶ��ͬ�����*��1����չ��Ӷ�����ѱ�����<asp:TextBox ID="txtPCDeduct" runat="server"></asp:TextBox>%<br />                                                                                                      
                        ����������Ӷ�����Ѽ��᣺<asp:TextBox ID="txtEBDeveloper" runat="server" Width="150px"></asp:TextBox><br />   
                            �������۳������Ѻ�ʵ�յ���Ӷ�㣺��ϵͳ���ù�ʽ���㣬ʵ�յ���Ӷ��=���̺�ͬ�����*��1������Ӷ�����ѱ�����<asp:TextBox ID="txtEBDeduct" runat="server"></asp:TextBox>%<br />                                                 
                        ����������ע: ����Ŀͬʱ�е��̷��ü������ѣ���ֱ���ʾ���̷��õı����������ѵı�����<br /> 
                        �����������ѳе���ʽ��<asp:RadioButton ID="rdbCooperationWay1" runat="server" Text="��������е�" GroupName="CooperationWay" />
                        <asp:RadioButton ID="rdbCooperationWay2" runat="server" Text="�ɽ�����е�" GroupName="CooperationWay" />
                        <asp:RadioButton ID="rdbCooperationWay3" runat="server" Text="���԰������е�" GroupName="CooperationWay" /> 
                        <br /><br />
                        <div id ="SdAc">�۳������Ѻ�ķ�չ��Ӷ��+����Ӷ��<span id="lbAutoCoculate">��</span></div>
                        </div>
                        <br />
                        �����ֽ𽱣�<br /><div id="SingleRewardC1">����������<asp:RadioButton ID="rdbHaveSingleReward1" runat="server" Text="�У�����Ŀʵ��Ӷ�������3%" GroupName="HaveSingleReward" />
                        ���ֽ�<asp:TextBox ID="txtRewardSignHave" runat="server" Width="90px"></asp:TextBox>Ԫ/�ף�
                        �ֽ𽱵Ŀɷ��Ž��=ÿ�׾�Ӷ��*15%������Ӷ��������Ķ��������չ��Ӷ�𼰵���Ӷ���Է�չ�̽���Ϊ���ޣ����ɷ��Ž��������Ϊ��ӪҵԱ44%������15%������8%�����ܼ�/�ܼࣨO/R��3%����˾30%������ÿ�׾�Ӷ���15%���ּ���˾30%����ȫ���Ͻɹ�˾���ɼ���Ա��ҵ������������Ա��Ӷ��</div>
                        <div id="SingleRewardC2">����������<asp:RadioButton ID="rdbHaveSingleReward2" runat="server" Text="�У�����Ŀʵ��Ӷ�����<3%" GroupName="HaveSingleReward" />���ֽ�<asp:TextBox ID="txtRewardSignHavent" runat="server" Width="90px"></asp:TextBox>Ԫ/�ף��ֽ�ȫ���Ͻɹ�˾���ɼ���Ա��ҵ������������Ա��Ӷ��</div> ����������
                        <div id="SingleRewardC3">����������<asp:RadioButton ID="rdbHaveSingleReward3" runat="server" Text="�ޣ�����Ŀ�����ֽ𽱡�" GroupName="HaveSingleReward" /></div>����������
                        <div id="SingleRewardC4">����������<asp:RadioButton ID="rdbHaveSingleReward4" runat="server" Text="�������" GroupName="HaveSingleReward" /></div>
                        <div id="AnotherRewardC" style="display: none"><asp:TextBox ID="txtAnotherRewardC" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox></div><br />
                        �ֽ𽱵Ĳ�����<br />
                        ��1����չ��֧���ֽ𽱵�������<br />
                        <asp:TextBox ID="txtDeveloperConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
                        ��2�������ɷ��ֽ𽱸�ͬ�µ�������<br />
                        <asp:TextBox ID="txtAreaConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
	                    <span style="color: #FF0000;">��������뱣֤�ֽ��������˻ظ���չ�̵�������ٷ��Ÿ�ͬ�£�</span><br /><br />
                        <div>�ֽ𽱵ķ��ŷ�ʽ��</div>
                        <asp:RadioButton ID="rdbPayRewardWay1" runat="server" Text="�����ɷ�չ�̻��빫˾�ʻ�����нӶ���š�" GroupName="PayRewardWay" /><br />
                        <asp:RadioButton ID="rdbPayRewardWay2" runat="server" Text="�����ɷ�չ��ֱ��֧���ֽ�" GroupName="PayRewardWay" /><br />
                        �ֽ𽱽����˱������������ˣ������ʻ�������
                        <asp:TextBox ID="txtReceiveRewardName" runat="server" Width="85px"></asp:TextBox> �ʺţ�
                        <asp:TextBox ID="txtReceiveRewardNo" runat="server"></asp:TextBox><br />
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
                        �����ͬԼ���Ľ�Ӷ����<br />
                        <asp:TextBox ID="txtTermsOfContract" runat="server"  TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;"></asp:TextBox>
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
					<td>Ԥ��������<br />�����</td>
					<td colspan="3" class="tl PL10">����<asp:TextBox ID="txtPreCompleteNumber" runat="server" Width="50px"></asp:TextBox>��,�������<asp:TextBox ID="txtPreCompleteMoney" runat="server" Width="50px"></asp:TextBox>Ԫ,Ӷ������<asp:TextBox ID="txtPreCompleteComm" runat="server" Width="50px"></asp:TextBox>Ԫ</td>
				</tr>
                <tr id ="EarnMoney" style="display: none">
                    <td>Ӧ������</td>
                    <td colspan="3" class="tl PL10" style="font-size: large">
                        ��Ŀ��Ӧ����Ӷ��<asp:Label ID="lbN1" runat="server"></asp:Label>Ԫ<br />
                        δ����Ӷ�𣨺��ɽ����������ڵ�Ӷ��<asp:Label ID="lbN2" runat="server"></asp:Label>Ԫ<br />
                        ��Ŀ���Զ����˵�Ӧ����Ӷ��<asp:Label ID="lbC1" runat="server"></asp:Label>Ԫ
                    </td>
                </tr>
                <tr id ="CouldFlange" style="display: none">
                    <td>��������̴���Ŀ��<br />��������</td>
                    <td colspan="3" class="tl PL10" style="font-size: large"><asp:Label ID="lbFlange" runat="server"></asp:Label></td>
                </tr>
                <tr>
					<td>��Ŀ�Ƿ���ǷӶ</td>
					<td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbIsProjEarlyCommBack" runat="server" Text="��" GroupName="ProjEarlyComm" /><label for="r2d2b2">������ǷӶ���<asp:TextBox ID="txtOweCommSum" runat="server" Width="80px"></asp:TextBox>Ԫ�������ŵ<asp:TextBox ID="txtAreaPromiseBackDate" runat="server" Width="80px"></asp:TextBox>�ջ�</label><br />
                        <asp:RadioButton ID="rdbIsProjEarlyCommBack2" runat="server" Text="��" /><label for="r2d2b2">���Ǳ���ǷӶ���<asp:TextBox ID="txtNHComm" runat="server" Width="80px"></asp:TextBox>Ԫ��<asp:TextBox ID="txtNHName" runat="server"></asp:TextBox>��/���ų�ŵ<br />����<asp:TextBox ID="txtNHTime" runat="server"></asp:TextBox>�ջ�</label><br />
                        <asp:RadioButton ID="rdbIsProjEarlyCommNotBack" runat="server" Text="��" GroupName="ProjEarlyComm" /><label for="r2d2b2">������ǷӶ��<asp:TextBox ID="txtHere" runat="server"></asp:TextBox>��/����ǷӶ��ȫ���ջ�</label><br />
                        <asp:RadioButton ID="rdbIsProjEarlyCommhavent" runat="server" Text="��ĿΪ��ԭ�״γнӣ��������κ���/����ǷӶ" GroupName="ProjEarlyComm" />
					</td>
				</tr>
<%--                <tr>
					<td>�����ֽ�</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbHaveSingleReward" runat="server" Text="��" GroupName="SingleReward" /><asp:RadioButton ID="rdbNoSingleReward" runat="server" Text="��"  GroupName="SingleReward" /></td>
				    <td>Ӷ��</td>
					<td class="auto-style1"><asp:RadioButton ID="rdbAllJumpBar" runat="server" Text="ȫ��bar" GroupName="JumpBar" /><asp:RadioButton ID="rdbRateJumpBar" runat="server" Text="�ּ���bar"  GroupName="JumpBar"  /></td>
				</tr>

                <tr id="IsOrNotSubmitReward" style="display: none">
					<td>�Ƿ���ͬʱ�ύ���𱨱�</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbSubmitReward1" runat="server" Text="��" GroupName="SubmitReward" /><asp:RadioButton ID="rdbSubmitReward2" runat="server" Text="��"  GroupName="SubmitReward" /></td>
                    <td colspan="2"></td>
				</tr>--%>

                <tr>
					<td>��������</td>
					<td class="tl PL10">
                        <asp:RadioButton ID="rdbIsNotMallSplit" runat="server" Text="�ٽ�����" GroupName="MallSplit"/>
                        <asp:RadioButton ID="rdbIsMallSplit" runat="server" Text="�̳���" GroupName="MallSplit"/>
					</td>
                    <td>�Ƿ����ϴ�<br />�ֳ���Ƭ��ƽ��ͼ</td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbIsUploadPlan1" runat="server" Text="��" GroupName="IsUploadPlan"/>
                        <asp:RadioButton ID="rdbIsUploadPlan2" runat="server" Text="��" GroupName="IsUploadPlan"/>
                    </td>
				</tr>
                <tr>
                    <td>�̳��Ƿ�<br />���ھ�Ӫ</td>
					<td  class="tl PL10"><asp:RadioButton ID="rdbIsMallOpen" runat="server" Text="��" GroupName="MallOpen" /><asp:RadioButton ID="rdbIsNotMallOpen" runat="server" Text="��" GroupName="MallOpen" />
					</td>
					<td>�Ƿ���ڵ�Ѻ</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbIsExistMortgage" runat="server" Text="��" GroupName="ExistMortgage" /><asp:RadioButton ID="rdbIsNotExistMortgage" runat="server" Text="��" GroupName="ExistMortgage"/>
					</td>
				</tr>
                <tr>
                    <td>�Ƿ����<br />��������</td>
					<td  class="tl PL10"><asp:RadioButton ID="rdbIsExistLeasebackRules" runat="server" Text="��" GroupName="ExistLeasebackRules" /><asp:RadioButton ID="rdbIsNotExistLeasebackRules" runat="server" Text="��" GroupName="ExistLeasebackRules" />
					</td>
					<td>�Ƿ���Ԥ����<br />��֤�򷿲�֤</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbHavePreSaleLicenses" runat="server" Text="��" GroupName="PreSaleLicenses" /><asp:RadioButton ID="rdbNoPreSaleLicenses" runat="server" Text="��" GroupName="PreSaleLicenses" />
					</td>
				</tr>
                <tr>
                    <td>�Ƿ����Ȩ��<br />ǩ���ͬ</td>
					<td class="tl PL10"><asp:RadioButton ID="rdbIsWithPropertyOwnerSignContract" runat="server" Text="��" GroupName="WithPropertyOwnerSignContract" /><asp:RadioButton ID="rdbIsNotWithPropertyOwnerSignContract" runat="server" Text="��" GroupName="WithPropertyOwnerSignContract" /><br />(��ѡ���������ṩҵ������Ȩ��)
					</td>
                    <td></td>
                    <td></td>
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
                    <td>ͬ��������м�</td>
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
                    <td>����������м�</td>
                    <td colspan="3"class="tl PL10">
                        ��<div>������Ŀ���м�ͬ�����ϴ������������������Ϊ����������������˽������Ϣ�޷���д������ע�����������˽������Ϣ����</div><br />
                        1.���ƣ�<asp:TextBox ID="txtTurnsAgentXX1" runat="server" Width="200px"></asp:TextBox>
                        �������ڣ�<asp:TextBox ID="txtAgencyBeginDate1" runat="server" Width="90px"></asp:TextBox>��<asp:TextBox ID="txtAgencyEndDate1" runat="server" Width="90px"></asp:TextBox><br />
                        ������ѣ�<asp:TextBox ID="txtAgencyFee3" runat="server" Width="140px"></asp:TextBox>
                        ���ֽ𽱣�<asp:RadioButton ID="rdbIsCashPrize31" runat="server" Text="�У�" GroupName="CashPrize3" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize3" runat="server" Width="140px"></asp:TextBox>Ԫ/��</label><asp:RadioButton ID="rdbIsCashPrize32" runat="server" Text="��" GroupName="CashPrize3" /><br />
                        ����Ŀ���ã�<asp:RadioButton ID="rdbIsPFear31" runat="server" Text="�У�����" GroupName="IsPFear3" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear3" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear32" runat="server" Text="��" GroupName="IsPFear3" /><br />
                        2.���ƣ�<asp:TextBox ID="txtTurnsAgentXX2" runat="server" Width="200px"></asp:TextBox>
                        �������ڣ�<asp:TextBox ID="txtAgencyBeginDate2" runat="server" Width="90px"></asp:TextBox>��<asp:TextBox ID="txtAgencyEndDate2" runat="server" Width="90px"></asp:TextBox><br />
                        ������ѣ�<asp:TextBox ID="txtAgencyFee4" runat="server" Width="140px"></asp:TextBox><label for="r2d2b2"></label>
                        ���ֽ𽱣�<asp:RadioButton ID="rdbIsCashPrize41" runat="server" Text="�У�" GroupName="CashPrize4" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize4" runat="server" Width="140px"></asp:TextBox>Ԫ/��</label><asp:RadioButton ID="rdbIsCashPrize42" runat="server" Text="��" GroupName="CashPrize4" /><br />
                        ����Ŀ���ã�<asp:RadioButton ID="rdbIsPFear41" runat="server" Text="�У�����" GroupName="IsPFear4" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear4" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear42" runat="server" Text="��" GroupName="IsPFear4" /><br />
                    </td>
                </tr>
                <tr>
					<td>����ģʽ</td>
					<td colspan="3" class="tl PL10"><asp:RadioButton ID="rdbSaleMode1" runat="server" Text="�������̣�" GroupName="SaleMode" /><label for="r2d2b2">ͳ����<asp:TextBox ID="AreaScale1" runat="server" Width="110px"></asp:TextBox>��ֳɽ���<asp:TextBox ID="txtMainAreaScale" runat="server" Width="50px"></asp:TextBox>%�� �ɽ���ռ<asp:TextBox ID="txtDealAreaScale" runat="server" Width="50px"></asp:TextBox>%</label>
                        <br />
                        <div style="margin-top: 10px; margin-bottom: 10px;">
                            <asp:RadioButton ID="rdbSaleMode2" runat="server" Text="�������̣�ͳ����" GroupName="SaleMode" Height="30px" />
                            <label for="r2d2b2"><asp:TextBox ID="AreaScale" runat="server" Width="70%" Height="40px" TextMode="MultiLine"></asp:TextBox>��
                            <br />�������������̵�ÿ������ֱ�����
                            ͳ�����ϼƲ�ֳɽ���<asp:TextBox ID="txtMainAreaScale2" runat="server" Width="50px"></asp:TextBox>%���ɽ�����ֳɽ���<asp:TextBox ID="txtDealAreaScale2" runat="server" Width="50px"></asp:TextBox>%</label>
					    </div>
                        <asp:CheckBox ID="cbn1" runat="server" Text="�������ֹ�˾" />
                        <asp:TextBox ID="txtAnotherCompany" runat="server"></asp:TextBox>�������ɽ��ԭ/��ɽ��ԭ��������˫����ǩ��ת�����
                        ��ת����ϴ���Ϊ�����븽��
                        <asp:RadioButton ID="rdbHasAtt1" runat="server" GroupName="HasAtt" Text="��" />
                        <asp:RadioButton ID="rdbHasAtt2" runat="server" GroupName="HasAtt" Text="��" />
                        <asp:TextBox ID="txtReferral" runat="server"></asp:TextBox>���������ɽ��ԭ/��ɽ��ԭ��
                        <asp:TextBox ID="txtWillBreakUp" runat="server" TextMode="MultiLine"></asp:TextBox>����
                        <asp:TextBox ID="txtBreakUp" runat="server" TextMode="MultiLine"></asp:TextBox>��ת��������ԭ��Ӷ��Ϊ
                        <asp:TextBox ID="txtNCommissions" runat="server"></asp:TextBox>��</td>
				</tr>
                <tr>
					<td colspan="2">�Ƿ���Ҫ�ƹ���Ŀ��Ϣ������<br />����ԭƽ̨ͨ��/������Ŀ�����ʼ�/���̶��ŵȣ�</td>
					<td colspan="2" class="tl PL10"><asp:RadioButton ID="rdbIsNeedExtension" runat="server" Text="��" GroupName="NeedExtension" /><asp:RadioButton ID="rdbIsNotNeedExtension" runat="server" Text="��" GroupName="NeedExtension" /></td>
				</tr>
                <tr>
					<td colspan="2">�Ƿ���Ҫ��˾����������Ŀ��Ϣ<br />���ٷ�΢��/�����ȣ�</td>
					<td colspan="2" class="tl PL10"><asp:RadioButton ID="rdbIsNeedBroadcast" runat="server" Text="��" GroupName="NeedBroadcast" /><asp:RadioButton ID="rdbIsNotNeedBroadcast" runat="server" Text="��" GroupName="NeedBroadcast" /></td>
				</tr>
				<tr>
                    <th colspan="4" style="line-height:25px;" >��������</th>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <%--style="border: 1px solid #000000;"--%>
					<td >������</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">ͬ��</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">��ͬ��</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="ǩ��" onclick="sign('1')" style="display: none;" />
                        <div class="signdate"><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx1">_________</span></span></div>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <td >���벿�Ÿ�����</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">ͬ��</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">��ͬ��</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="ǩ��" onclick="sign('2')" style="display: none;" />
                        <div class="signdate"><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx2">_________</span></span></div>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <td >�����г�������<br />����Ŀ����<br />��<br />�����г�������<br />����ҵ����</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">ͬ��</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">��ͬ��</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="ǩ��" onclick="sign('3')" style="display: none;" />
                        <div class="signdate"><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx3">_________</span></span></div>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
					<td rowspan="2" >���ɲ����</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">ͬ��</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">��ͬ��</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">�������</label><br />
						<textarea id="txtIDx4" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="ǩ�����" onclick="sign('4')" style="display: none;" />
                        <div class="signdate"><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx4">_________</span></span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/><label for="rdbYesIDx5">ͬ��</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">��ͬ��</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">�������</label><br />
						<textarea id="txtIDx5" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="ǩ�����" onclick="sign('5')" style="display: none;" />
                        <div class="signdate"><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx5">_________</span></span></div>
					</td>
				</tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td >�����ܾ���<br />����</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">ͬ��</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">��ͬ��</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">�������</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="ǩ�����" onclick="sign('6')" style="display: none;" />
                        <div class="signdate"><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx6">_________</span></span></div>
					</td>
				</tr>


                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td >����ظ��������<br />����ѡ�</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx200">_________</span>
                        </span>
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
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx210">_________</span>
                        </span>
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
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx211">_________</span>
                        </span>
					</td>
                </tr>
                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td >�����ܾ�����</td>
					<td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="ͬ��" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="��ͬ��" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="�������" GroupName="220a" ForeColor="#008162" />
						<textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            ���ڣ�<span id="spanDateIDx220">_________</span>
                        </span>
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
		<hr />
        <asp:button runat="server" id="btnReWrite" text="���µ���" OnClick="btnReWrite_Click" Visible="False"/>
		<asp:button runat="server" id="btnSave" text="����" onclick="btnSave_Click" onclientclick="return check();" Visible="False" />
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
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
        </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
	<%=SbJs.ToString()%>
    <script type="text/javascript">
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx210"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx211"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //ʹ�Ի�������Ӧ
    </script>
</asp:Content>