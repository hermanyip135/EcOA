<%@ Page ValidateRequest="false" Title="��ҵ����Ŀ��Լ����� - ������ԭ��������ϵͳ" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_UtContract_Detail.aspx.cs" Inherits="Apply_UtContract_Apply_UtContract_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        //debugger;
        var i1 = 1, i2 = 1, i3 = 1, cou = 0*1;
        var jJSON = <%=SbJson.ToString() %>;
        var jsccesp =  <%=SbCcesp.ToString() %>;
        var isUploaded = 0;
        var isNewApply=('<%=IsNewApply%>'=='True');
        var sor = <%=SbJsonSOR.ToString() %>;
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }
        function isjson(obj){
            var isjson = typeof(obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length; 
            return isjson;
        }
        function IsDirectContractBind()
        {
            var vDirectContract = $("#<%=this.hiDirectContract.ClientID%>").val();
            isDirectContract(vDirectContract);
            if (vDirectContract == "") {
               
            }
            else {
                $(".isDirectContractCss input[type=radio][value=" + vDirectContract + "]").get(0).checked = true;
               
            }
        }
        $(function () {
            //��ʼ��ʱ��ؼ�
            $("[dateplugin='datepicker']").each(function(){
                $(this).datepicker();
            });
            if($("#btnSignIDx15").is(':visible')){
                
                $("#sp005").show();
            }else{
                $("#sp005").hide();
            }
            if($("#btnSignIDx1").is(':visible')){
                // console.log('1');
                $("#sp001").show();
            }else{
                $("#sp001").hide();
            }
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
            IsDirectContractBind();
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




            $("#<%=txtName1.ClientID %>").autocomplete({ 
                source: jsccesp,
                select: function(event,ui) {
                    $("#<% =hfKey1.ClientID%>").val(ui.item.id);
                    //$("#<%=txtName2.ClientID %>").css("background-color","#e3e3e3").attr("readonly","readonly");
                    $("#<%=txtName2.ClientID %>").val("");
                    $("#<% =hfKey2.ClientID%>").val("");
                    $("#<%=txtDepartment.ClientID %>").focus();
                    $.ajax({
                        url: "/Ajax/Apply_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=UtControl&i=1&n=' + ui.item.value,
                        success: function(info) {
                            var v = info.split("|");
                            $("#<% =hdProjectArea.ClientID%>").val(v[0]);$("#<% =txtProjectArea.ClientID%>").val(v[0]);
                            $("#<% =hdProjectAddress.ClientID%>").val(v[1]);$("#<% =txtProjectAddress.ClientID%>").val(v[1]);
                            $("#<% =hdReportAddress.ClientID%>").val(v[2]);$("#<% =txtReportAddress.ClientID%>").val(v[2]);
                            $("#<% =hdTermsOfMajorIssues.ClientID%>").val(v[3]);$("#<% =txtTermsOfMajorIssues.ClientID%>").val(v[3]);
                            $("#<% =hdEmpID.ClientID%>").val(v[4]);
                            $("#<% =hdEmpName.ClientID%>").val(v[5]);
                        }
                    });
                }
            });
            $("#<%=txtName2.ClientID %>").autocomplete({ 
                source: sor,
                select: function(event,ui) {
                    $("#<% =hfKey2.ClientID%>").val(ui.item.id);
                    //$("#<%=txtName1.ClientID %>").css("background-color","#e3e3e3").attr("readonly","readonly");
                    $("#<%=txtName1.ClientID %>").val("");
                    $("#<% =hfKey1.ClientID%>").val("");
                    $("#<%=txtDepartment.ClientID %>").focus();
                    $.ajax({
                        url: "/Ajax/Apply_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=UtControl&i=2&n=' + ui.item.value,
                        success: function(info) {
                            var v = info.split("|");
                            $("#<% =hdProjectArea.ClientID%>").val(v[0]);$("#<% =txtProjectArea.ClientID%>").val(v[0]);
                            $("#<% =hdProjectAddress.ClientID%>").val(v[1]);$("#<% =txtProjectAddress.ClientID%>").val(v[1]);
                            $("#<% =hdReportAddress.ClientID%>").val(v[2]);$("#<% =txtReportAddress.ClientID%>").val(v[2]);
                            $("#<% =hdTermsOfMajorIssues.ClientID%>").val(v[3]);$("#<% =txtTermsOfMajorIssues.ClientID%>").val(v[3]);
                            $("#<% =hdEmpID.ClientID%>").val(v[4]);
                            $("#<% =hdEmpName.ClientID%>").val(v[5]);
                        }
                    });
                },
                appendTo: "menuWrapper" 
            });

            $("#<%=txtName1.ClientID%>").blur(function(){
                if($("#<% =hfKey1.ClientID%>").val() == "")
                    $("#<%=txtName1.ClientID%>").val("");
            });
            $("#<%=txtName2.ClientID%>").blur(function(){
                if($("#<% =hfKey2.ClientID%>").val() == "")
                    $("#<%=txtName2.ClientID%>").val("");
            });
            $("#<%=txtName1.ClientID%>").click(function(){
                $("#<%=txtName1.ClientID%>").val("");
            });
            $("#<%=txtName2.ClientID%>").click(function(){
                $("#<%=txtName2.ClientID%>").val("");
            });

            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON
            });

            $("#rdbOtherIDx15").click(function(){//*-
                if($("#rdbOtherIDx15").prop("checked")){
                    $("#btnSignIDx15").css({
                        "background-image": "url(/Images/btnUCSign41.png)",
                        "height": "29px", 
                        "width": "97px",
                        "font-size": "0px",
                        "cursor":"pointer",
                        "color": "#FFFFFF"
                    });
                    $("#btnSignIDx15").mousedown(function () { $(this).css("background-image", "url(/Images/btnUCSign42.png)"); })
                        .mouseup(function () { $(this).css("background-image", "url(/Images/btnUCSign41.png)"); })
                        .mouseleave(function () { $(this).css("background-image", "url(/Images/btnUCSign41.png)"); });
                }
            });
            $("#rdbOtherIDx16").click(function(){
                if($("#rdbOtherIDx16").prop("checked")){
                    $("#btnSignIDx16").css({
                        "background-image": "url(/Images/btnUCSign51.png)",
                        "height": "29px", 
                        "width": "85px",
                        "font-size": "0px",
                        "cursor":"pointer",
                        "color": "#FFFFFF"
                    });
                    $("#btnSignIDx16").mousedown(function () { $(this).css("background-image", "url(/Images/btnUCSign52.png)"); })
                        .mouseup(function () { $(this).css("background-image", "url(/Images/btnUCSign51.png)"); })
                        .mouseleave(function () { $(this).css("background-image", "url(/Images/btnUCSign51.png)"); });
                }
            });

            $("#rdbYesIDx15").click(function(){
                TurnBackTheSign();
            });
            $("#rdbNoIDx15").click(function(){
                TurnBackTheSign();
            });
            $("#rdbYesIDx16").click(function(){
                TurnBackTheSign();
            });
            $("#rdbNoIDx16").click(function(){
                TurnBackTheSign();
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
            $("#<%=txtLastBeginDate.ClientID%>").datepicker();
            $("#<%=txtLastEndDate.ClientID%>").datepicker();
            $("#<%=txtCumulativeBeginDate.ClientID%>").datepicker();
            $("#<%=txtCumulativeEndDate.ClientID%>").datepicker();
            $("#<%=txtReturnBackDate.ClientID%>").datepicker();
            $("#<%=txtGuaranTime.ClientID%>").datepicker();

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
            //autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx205"));
            autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx210"));
            autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx211"));
            autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));
	      

            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //ʹ�Ի�������Ӧ
            //2019-08-08 ���ӵ�ѡ���¼�
            $("#<%=rdbIsCoopWithECommerce1.ClientID%>").click(function(){
                //debugger;
                ECommerceRbtnClickFun("1");
            });

            //2019-08-08 CREATE BY HERMAN�����ӿؼ��ĵ���¼�
            $("#<%=rdbIsCoopWithECommerce2.ClientID%>").click(function(){
                //debugger;
                ECommerceRbtnClickFun("2");
            });

            $("#<%=rdbIsCoopWithECommerce3.ClientID%>").click(function(){
                //debugger;
                ECommerceRbtnClickFun("3");
            });

            $("#<%=rdbIsCoopWithECommerce4.ClientID%>").click(function(){
                //debugger;
                ECommerceRbtnClickFun("4");
            });

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

        function TurnBackTheSign(){
            $("[id^=btnSignIDx]").css({
                "background-image": "url(/Images/btn_sign1.png)",
                "height": "25px", 
                "width": "45px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("#btnSignIDx5").mousedown(function () { $(this).css("background-image", "url(/Images/btn_sign2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_sign1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_sign1.png)"); });
            $("#btnSignIDx6").mousedown(function () { $(this).css("background-image", "url(/Images/btn_sign2.png)"); })
                        .mouseup(function () { $(this).css("background-image", "url(/Images/btn_sign1.png)"); })
                        .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_sign1.png)"); });
        }

        function check() {
            
            if(isUploaded < 1 && isNewApply){
                alert("���ϴ���ص����ϣ�");
                return false;
            }

            if(isUploaded > 0
                && isNewApply
                && !$("#<%=cbLack1.ClientID%>").prop("checked")
                && !$("#<%=cbLack2.ClientID%>").prop("checked")
                && !$("#<%=cbLack3.ClientID%>").prop("checked")
                && !$("#<%=cbLack4.ClientID%>").prop("checked")
                && !$("#<%=cbLack5.ClientID%>").prop("checked")
                && !$("#<%=cbLack6.ClientID%>").prop("checked")
                && !$("#<%=cbLack7.ClientID%>").prop("checked")
                )
            {
                alert("�빴ѡ���ϴ����������ƣ�");
                $("#<%=cbLack1.ClientID%>").focus();
                return false;
            }
            if($("#<%=cbLack6.ClientID%>").prop("checked")){
                if($.trim($("#<%=txtLack6.ClientID%>").val()) == ""){
                    alert("������ѡ���������ϣ�������Ӧ���������ƣ�");
                    $("#<%=txtLack6.ClientID%>").focus();
                    return false;
                }
            }

            if ($("#<%=cbBaseAgent2.ClientID%>").prop("checked") || $("#<%=cbBaseAgent3.ClientID%>").prop("checked")) { //M_0001��20151016
                alert("���ڴ���ѡ�˺ϸ��Իͻ��������޷����棡");
                $("#<%=cbBaseAgent2.ClientID%>").focus();
                return false;
            }
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

            if(!$("#<%=rbtIsPreSale1.ClientID%>").prop("checked") && !$("#<%=rbtIsPreSale2.ClientID%>").prop("checked")){
                alert("��ѡ���Ƿ�����Ԥ��֤��");
                $("#<%=rbtIsPreSale1.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=rbtIslimitBuy1.ClientID%>").prop("checked") && !$("#<%=rbtIslimitBuy2.ClientID%>").prop("checked")){
                alert("��ѡ���Ƿ��޹���");
                $("#<%=rbtIslimitBuy1.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=rbtIslimitSign1.ClientID%>").prop("checked") && !$("#<%=rbtIslimitSign2.ClientID%>").prop("checked")){
                alert("��ѡ���Ƿ���ǩ��");
                $("#<%=rbtIslimitSign1.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=rdbOneOrTwo1.ClientID%>").prop("checked") && !$("#<%=rdbOneOrTwo2.ClientID%>").prop("checked")){
                alert("��ѡ����Ŀ���ʣ�");
                $("#<%=rdbOneOrTwo1.ClientID %>").focus();
                return false;
            }
            var flag = false;
            var valDirectContract = "";
            $(".isDirectContractCss input[name='DirectContract']").each(function () {
                if (this.checked) {
                    flag = true;
                    valDirectContract = this.value;
                }
            });
            if (!flag) {
                alert("��ѡ���Ƿ���÷�չ��ֱ��ǩԼ��");
                $("#radDirectContract1").focus();
                return false;
            }
            $("#<%=this.hiDirectContract.ClientID%>").val(valDirectContract);
            if('2' == valDirectContract)
            {
                if("" == $.trim($("#<%=txtCorporateName.ClientID%>").val()))
                {
                    alert("����дǩԼ��˾����");
                    $("#<%=txtCorporateName.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=ddlCorporateType.ClientID%>").val()) == "")
                {
                    alert("��ѡ��ǩԼ��˾����");
                    $("#<%=ddlCorporateType.ClientID%>").focus();
                    return false;
                }
            }
            //if ($.trim($("#<%=txtProjectArea.ClientID%>").val()) == "") { alert("��Ŀ�������򲻿�Ϊ�գ�"); $("#<%=txtProjectArea.ClientID%>").focus(); return false; }
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

            if ($("#<%=txtTermsOfContract.ClientID%>").val().length > 123) {
                alert("�����ͬԼ����Ӷ��֧��������Ҫ����123���֣�3�У���");
                $("#<%=txtTermsOfContract.ClientID%>").focus();
                return false;
            }

            //��Ŀ�Ƿ���ǷӶ
            if(!$("#<%=this.rdbIsProjEarlyCommBack1.ClientID%>").prop("checked") && !$("#<%=this.rdbIsProjEarlyCommBack2.ClientID%>").prop("checked"))
            {
                alert("�빴ѡ��Ŀ�Ƿ���ǷӶ");
                $("#<%=this.rdbIsProjEarlyCommBack1.ClientID%>").focus();
                return false;
            }
            if($("#<%=this.rdbIsProjEarlyCommBack1.ClientID%>").prop("checked"))
            {
                if($.trim($("#<%=this.txtOweCommSum.ClientID%>").val()) == "")
                {
                    alert("����д��ĿǷӶ���");
                    $("#<%=this.txtOweCommSum.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=this.txtAreaReason.ClientID%>").val()) == "")
                {
                    alert("����дǷӶԭ��");
                    $("#<%=this.txtAreaReason.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=this.txtGuaranTime.ClientID%>").val()) == "")
                {
                    alert("����д����ʱ��");
                    $("#<%=this.txtGuaranTime.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=this.txtOrdMoney.ClientID%>").val()) == "")
                {
                    alert("����дԭ���̲���ǷӶ���");
                    $("#<%=this.txtOrdMoney.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=this.txtOrdTaker.ClientID%>").val()) == "")
                {
                    alert("����д˭����׷��");
                    $("#<%=this.txtOrdTaker.ClientID%>").focus();
                    return false;
                }
            }

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
            if ($("#<%=txtACName.ClientID%>").val() == "") {
                alert("���ڴ�����������Լ������д�����ͬ���ƣ�");
                $("#<%=txtACName.ClientID%>").focus();
                return false;
            }
            //}

            if ($("#<%=txtName1.ClientID%>").val() == "" && $("#<%=txtName2.ClientID%>").val() == "") {
                alert("����д��Ӧ����Ŀ���ƣ�");
                $("#<%=txtName1.ClientID%>").focus();
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

            if($("#<%=rdbIsCoopWithECommerce1.ClientID %>").prop("checked")){
                if (!$("#<%=rdbFtoZ1.ClientID %>").prop("checked") && !$("#<%=rdbFtoZ2.ClientID%>").prop("checked")) {
                    alert("��ѡ�����뷽ʽ");
                    $("#<%=rdbFtoZ1.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsUploadF1.ClientID %>").prop("checked") && !$("#<%=rdbIsUploadF2.ClientID%>").prop("checked")) {
                    alert("��ѡ���Ƿ����ϴ�����Ȧ");
                    $("#<%=rdbIsUploadF1.ClientID%>").focus();
                    return false;
                }
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
	        

            if (!$("#<%=rdbOwnerCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbOwnerCommJump2.ClientID%>").prop("checked")) {
                alert("��ѡ��ҵӶ��BAR��ʽ");
                $("#<%=rdbOwnerCommJump1.ClientID%>").focus();
                return false;
            }
            //if (!$("#<%=rdbClientCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbClientCommJump2.ClientID%>").prop("checked")) {
            //    alert("��ѡ���Ӷ��BAR��ʽ");
            //    $("#<%=rdbClientCommJump1.ClientID%>").focus();
            //    return false;
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
                if (($("#<%=txtMainAreaScale2.ClientID%>").val()*1 + $("#<%=txtMS2.ClientID%>").val()*1) > 15) {
                    alert("ͳ����+�����������Ӳ��ó���15%��");
                    $("#<%=txtMainAreaScale2.ClientID%>").focus();
                    return false;
                }
                if ($("#<%=txtDealAreaScale2.ClientID%>").val() < 85) {
                    alert("�ɽ�����ֲ�����85%��");
                    $("#<%=txtDealAreaScale2.ClientID%>").focus();
                    return false;
                }
	            
            }


            //2016/8/24 52100 ��Ŀ���ڵ�
    if ($.trim($("#<%=ddlProjectAddress.ClientID%>").val()) == ""||$.trim($("#<%=ddlProjectAddress.ClientID%>").val())=="0") {
                alert("��Ŀ���ڵر���ѡ��");
                $("#<%=ddlProjectAddress.ClientID%>").focus();
                return false;
            }
            if ($.trim($("#<%=ddlDiskSource.ClientID%>").val()) == ""||$.trim($("#<%=ddlDiskSource.ClientID%>").val())=="0") {
                alert("��Ŀ������Դ����ѡ��");
                $("#<%=ddlDiskSource.ClientID%>").focus();
                return false;
            }
            //
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

            //2019-08-15 ���ӷǿ���֤
            if ($("#<%=rdbIsCoopWithECommerce2.ClientID %>").prop("checked")) {

                if ($.trim($("#<%=txtECommerceReason.ClientID%>").val()) == "") {
                    alert("ѡ��˵��̵����ɲ���Ϊ�գ�");
                    $("#<%=txtECommerceReason.ClientID%>").focus();
                    return false;
                }

            }

            if ($("#<%=rdbIsCoopWithECommerce3.ClientID %>").prop("checked")) {
                var discountMoney = $("#<%=txtDiscountMoney.ClientID%>").val();
                if ($.trim(discountMoney) == "") {
                    alert("ˢ���ŻݵĽ���Ϊ�գ�");
                    $("#<%=txtDiscountMoney.ClientID%>").focus();
                    return false;
                }
                else {
                    /**
                    * У��ֻҪ�����֣���������������0�Լ��������������ͷ���true
                    **/
                    var regPos = new RegExp("/^\d+(\.\d+)?$/"); //�Ǹ�������
                    var regNeg = new RegExp("/^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/"); //��������
                    if (regPos.test(discountMoney) || !regNeg.test(discountMoney)) {
                        return true;
                    }
                    else {
                        alert("����д��ȷ��ʽ�����֣���ʽ�磺0.00��");
                        $("#<%=txtDiscountMoney.ClientID%>").focus();
                        return false;
                    }

                }

            }
	        
        }

        //��ʱ����
        function tempsavecheck()
        {
            //��ҵ����
            var cblItemLength = $("#<%=cblDealOfficeType.ClientID%> input").length;
            var typeValues = "";
            for (var i = 0; i < cblItemLength; i++) {
                if ($("#<%=cblDealOfficeType.ClientID%> input")[i].checked) {
                    typeValues += $("#<%=cblDealOfficeType.ClientID%> span")[i].tag + "|";
                }
            }
            if (typeValues!="") {
                $("#<%=hdDealOfficeType.ClientID%>").val(typeValues.substr(0, typeValues.length - 1));
            }
            //��չ��Ӷ
            var data = "";
            $("#tOwner tr").each(function (i) {
                var n = i + 1;
                data += $.trim($("#txtOwnerCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatKind" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatScale" + n).val()) + "&&" + $.trim($("#txtOwnerCommPublishedScale" + n).val()) + "||";
            });
            if (data!="") {
                data = data.substr(0, data.length - 2);
                $("#<%=hdOwner.ClientID%>").val(data);
            }
            //��Ӷ
            data = "";
            $("#tClient tr").each(function (i) {
                var n = i + 1;
                data += $.trim($("#txtClientCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtClientCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtClientCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtClientCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtClientCommFloatScale" + n).val()) + "&&" + $.trim($("#txtClientCommPublishedScale" + n).val()) + "||";
            });
            if (data!="") {
                data = data.substr(0, data.length - 2);
                $("#<%=hdClient.ClientID%>").val(data);
            }
            //����Ӷ
            data = "";
            $("#tEB tr").each(function (i) {
                var n = i + 1;
                data += $.trim($("#txtEBCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtEBCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtEBCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtEBCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtEBCommFloatKind" + n).val()) + "&&" + $.trim($("#txtEBCommFloatScale" + n).val()) + "&&" + $.trim($("#txtEBCommPublishedScale" + n).val()) + "||";
            });
            if (data!="") {
                data = data.substr(0, data.length - 2);
                $("#<%=hdEB.ClientID%>").val(data);
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
                alert("�빴ѡ�ļ������أ�");
				
            return flagCheck;
        }

        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Tourism/Apply_UploadFile.aspx?MainID=<%=MainID%>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID%>', "dialogHeight=165px");
            //if(sReturnValue=='success')
            //    window.location = 'Apply_UtContract_Detail.aspx?MainID=<%=MainID%>';
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
                    window.location='Apply_UtContract_Detail.aspx?MainID=<%=MainID %>';
            }
        }

        function editflow(){
            var win=window.showModalDialog("Apply_UtProj_Flow.aspx?MainID=<%=MainID%>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location = "Apply_UtContract_Detail.aspx?MainID=<%=MainID%>";
        }

        function CancelSign(idc) {
            if (confirm("����������֮��������������ڶ���������ȷ��Ҫ���������"))  //20141202��CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }

        function sign(idx) {
            //if (idx == '1'||idx == '2') {
            //    if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
            //        alert("��ȷ��ͬ�������ͬ�⣡");
            //        return;
            //    }
            //}
            //else {
            //    if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbNoIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
            //        alert("��ȷ���Ƿ�ͬ�⣡");
            //        return;
            //    }
            //}

            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                alert("��ȷ���Ƿ�ͬ�⣡");
                return;
            }
			
            if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
                alert("��������ͬ������룬������д��ͬ���ԭ��");
                return;
            }
            if($("#rdbOtherIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
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
}

        function addRow1() {
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
      
        //����һ��
        function addrow(e,idname,obj) {
            var copytr = $("#" + idname + " tr").first().clone();
            if(obj != null && obj != undefined && isjson(obj))
            {
                for(var k in obj) {
                    $(copytr).find("input[name=" + k + "]").val(obj[k]);
                    //��������k��Ϊkey��obj[k]Ϊ��ǰk��Ӧ��ֵ
                    //   console.log(k);
                }
                         
            }
            else
            {
                $(copytr).find("input[type=text]").val("");
                      
                $(copytr).find("input[name=EmployeeID]").removeAttr("readonly")
                $(copytr).find("input[name=EmployeeID]").css("background-color","");
                $(copytr).find("input[name=BeginDate]").val($("#<%=txtAgentStartDate.ClientID%>").val());
                $(copytr).find("input[type=hidden]").val("��ѡ��");
            }
            $(copytr).find("[dateplugin='datepicker']").each(function(){
                $(this).removeAttr("id").removeAttr("class");
                $(this).datepicker();
            });
            $("#" + idname).append(copytr);
            return;
        }
        //ɾ����
        function delrow(e,idname) {
    var l = $("#" + idname + " tr").length;
          
    if(l == 1)
    {
        alert("���һ�в�����ɾ");
        return;
    }
    if( $("#" + idname + " tr").last().find("input[name=EmployeeID]").attr("readonly"))
    {
        alert("�ѱ������ݲ�����ɾ");
        return;
    }
    else
    {
        $("#" + idname + " tr").last().remove();
    }
            
}
        function getEmployee(n) {
    //   alert( $(n).val());
    // alert( $(n).parent().parent().find("input[name=BeginDate]").val());
    var StartDate =  $(n).parent().parent().find("input[name=BeginDate]").val()
           
    if(StartDate == "")
    {
        $(n).parent().parent().find("input[name=BeginDate]").focus();
        alert('����д��ʼʱ��')
        return;
    }
    $.ajax({
        url: "/Ajax/HR_Handler.ashx",
        type: "post",
        dataType: "text",
        data: "action=getEmployeeByCodeDate&code=" + n.value+"&ExDate="+StartDate,
        success: function(info) {
            // console.log(info);
            if (info != "fail") {
                var infos = info.split("|");
                var  Modetype ="";
                var TextBoxNo = 0;//��0��ʼ �ڵڼ���inpu
                $("#jzqk tr").find("input").each(function () {
                    if (TextBoxNo == 6) {
                        TextBoxNo =0;
                        Modetype="";
                    }
                    if(TextBoxNo==2)
                    {
                        Modetype = $(this).val();
                              
                    }
                          
                    if(Modetype==n.value){
                        if(TextBoxNo ==3){
                            $(this).val(infos[1]);
                        }
                        if(TextBoxNo ==4){
                            $(this).val(infos[2]);
                        }
                        //if(TextBoxNo ==5){
                        //    $(this).val(infos[9]);
                        //}
                    }
                    TextBoxNo++
                })
            }
                
            else{
                // console.log(infos)
            }
        }
    })
}
    
        function Obj2str(o) {
    if (o == undefined) {
        return "";
    }
    var r = [];
    if (typeof o == "string") return "\"" + o.replace(/([\"\\])/g, "\\$1").replace(/(\n)/g, "\\n").replace(/(\r)/g, "\\r").replace(/(\t)/g, "\\t") + "\"";
    if (typeof o == "object") {
        if (!o.sort) {
            for (var i in o)
                r.push("\"" + i + "\":" + Obj2str(o[i]));
            if (!!document.all && !/^\n?function\s*toString\(\)\s*\{\n?\s*\[native code\]\n?\s*\}\n?\s*$/.test(o.toString)) {
                r.push("toString:" + o.toString.toString());
            }
            r = "{" + r.join() + "}"
        } else {
            for (var i = 0; i < o.length; i++)
                r.push(Obj2str(o[i]))
            r = "[" + r.join() + "]";
        }
        return r;
    }
    return o.toString().replace(/\"\:/g, '":""');
}
        //������ϸ idname =hidDetail(���ص�json) Idtbody=�����Ǹ�id
        function LoadDetail(idname,Idtbody) {
           
    var detail = $("#" + idname).val();
    // console.log(detail);
    var list = detail == "" ? [] : $.parseJSON(detail);
    for(var i = 0 ; i < list.length;i++)
    {
        if(i == 0)
        {
            var copytr = $("#"+Idtbody+" tr").first();
            if(list[i] != null && list[i] != undefined && isjson(list[i]))
            {
                var obj = list[i];
                for(var k in obj) {
                    if(k == "EmployeeID")
                    {
                        $(copytr).find("input[name=" + k + "]").attr("readonly","readonly")
                        $(copytr).find("input[name=" + k + "]").css("background-color","#E0E0E0")
                    }
                           
                    $(copytr).find("input[name=" + k + "]").val(obj[k]);
                    //��������k��Ϊkey��obj[k]Ϊ��ǰk��Ӧ��ֵ
                    //console.log(k);
                }
            }
            else
            {
                $(copytr).find("input[type=text]").val("");
            }
        }
        else
        {
            addrow(null,Idtbody,list[i]);
        }
    }
}
        //ͳ��������
        function checkScale(e)
{
    var regex = /^\d+$/;  
    if(regex.test(e.value)){  
        if(e.value<100 && e.value>0){  
                   
        }else{  
            alert("������С��100������")
            e.value='';
            e.focus();
            return false;
        }  
    }else{  
        alert("������");
        e.value='';
        e.focus();
        return false;
    } 
}
        function checkBeginDate(e) {
                    
            var StartDate = $("#<%=txtAgentStartDate.ClientID%>").val();
            var BeginDate =  e.value;
            if(BeginDate<StartDate)
            {
                e.value="";
                e.focus();
                alert('��ѡ�������ڴ�������');
            }
        }
        //�Ƿ���÷�չ��ֱ��ǩԼ
        function isDirectContract(e) {
            if("2" == e)
            {
                $("#NoDirectContract").show();
                //  $("#lNoDirectContract").attr("style","color:red;");
                $("#lNoDirectContract").attr("style","font-weight:bold;color:red;");
            }
            else
            {
                $("#NoDirectContract").hide();
                $("#lNoDirectContract").attr("style","color:block;");
            }
           
        }

        //��˾�Ƿ������ǩԼ��ѡ��ťѡ���¼�
        function ECommerceRbtnClickFun(rbtnValue) {
            //debugger;
            if  (rbtnValue == "1" || rbtnValue == "4"){
                $("#<%=txtECommerceName.ClientID%>").val("");
                $("#<%=txtECommerceReason.ClientID%>").val("");

                $("#<%=txtECommerceName2.ClientID%>").val("");
                $("#<%=txtDiscountMoney.ClientID%>").val("");
            }

            if  (rbtnValue == "2"){
                $("#<%=txtECommerceName2.ClientID%>").val("");
                $("#<%=txtDiscountMoney.ClientID%>").val("");
            }

             if  (rbtnValue == "3"){
                $("#<%=txtECommerceName.ClientID%>").val("");
                $("#<%=txtECommerceReason.ClientID%>").val("");
            }

        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 204px;
        }

        .auto-style2 {
            width: 59px;
        }

        .finSignBtn {
            background: url(../../../images/btnSureS1.png) no-repeat;
            text-indent: 39px;
            width: 43px;
            height: 25px;
            overflow: hidden;
            cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString()%>
            <asp:Button runat="server" ID="btnEditFlow2" Text="�༭����" OnClientClick="if(confirm('�޸ĺ����޸Ļ��ڵĺ������̶���������ȷ��Ҫ�޸���'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--��ӡ���Ŀ�ʼ-->
        <div style='text-align: center'>
            <h1>�㶫��ԭ�ز��������޹�˾</h1>
            <h1>��ҵ����Ŀ��Լ�����</h1>
            <input type="button" id="btnADelete" value="�Ƿ�ͬ��ɾ����" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 720px; margin: 0 auto;"><span style="float: right;" class="file_number">�ĵ�����(�Զ�����)��<%=SerialNumber%></span></div>
            <%--style="border-style:double; border-color:Black; border-width:5px; margin: 0 auto; background-color: #fff; border-collapse: collapse;" --%>
            <table id="tbAround" width='720px'>
                <tr>
                    <td style="width: 20%">��ҵ�������̵���Ŀ����</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtName1" runat="server" Width="95%"></asp:TextBox><br />
                        <asp:LinkButton ID="lbNewProj1" runat="server" OnClick="lbNewProj1_Click">����Ŀ��������</asp:LinkButton>
                    </td>
                    <td style="width: 20%">��Ŀ�������̵���Ŀ����</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtName2" runat="server" Width="95%"></asp:TextBox><br />
                        <asp:LinkButton ID="lbNewProj2" runat="server" OnClick="lbNewProj1_Click">����Ŀ��������</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">���벿��</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
                    <td style="width: 20%">������</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApply" runat="server" Width="70px"></asp:TextBox>
                        -
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>��Ŀ��չ��<br />
                        (Сҵ��)</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDeveloper" runat="server"></asp:TextBox></td>
                    <td>������������</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>�Ƿ���÷�չ��ֱ��ǩԼ</td>
                    <td class="tl PL10" colspan="3">
                        <span class="isDirectContractCss">
                            <input type="radio" id="radDirectContract1" name="DirectContract" value="1" onclick="isDirectContract(1)" /><label for="radDirectContract1" id="lYesDirectContract">��</label>
                            <input type="radio" id="radDirectContract2" name="DirectContract" value="2" onclick="isDirectContract(2)" /><label for="radDirectContract2" id="lNoDirectContract">��</label>
                            <asp:HiddenField ID="hiDirectContract" runat="server" />
                        </span>
                        <span style="float: right" id="NoDirectContract">ǩԼ��˾���ƣ�<asp:TextBox ID="txtCorporateName" runat="server"></asp:TextBox>
                            �ù�˾���ͣ�
                        <asp:DropDownList ID="ddlCorporateType" runat="server" Width="100px"></asp:DropDownList>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>���ڴ���</td>
                    <td class="tl PL10" colspan="3">
                        <asp:CheckBox ID="cbBaseAgent1" runat="server" Text="��ԭ��Ŀ��" />
                        <asp:CheckBox ID="cbBaseAgent2" runat="server" Text="�ϸ��Ի�" /><asp:CheckBox ID="cbBaseAgent3" runat="server" Text="����" /><asp:CheckBox ID="cbBaseAgent4" runat="server" Text="����" />
                        <asp:TextBox ID="txtBaseAgentOther" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>��������</td>
                    <td class="tl PL10">
                        <asp:DropDownList ID="ddlDealType" runat="server" Width="100px"></asp:DropDownList></td>
                    <td>�Ƿ�����Ԥ��֤
                    </td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rbtIsPreSale1" runat="server" GroupName="IsPreSale" Text="��" />
                        <asp:RadioButton ID="rbtIsPreSale2" runat="server" GroupName="IsPreSale" Text="��" />
                    </td>
                    <td style="display: none">
                        <span style="display: none">��Ŀ��������
                        </span>
                    </td>
                    <td class="tl PL10" style="display: none"><span style="display: none">
                        <asp:TextBox ID="txtProjectArea" runat="server"></asp:TextBox>
                    </span></td>

                </tr>
                <tr>
                    <td>�Ƿ��޹�
                    </td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rbtIslimitBuy1" runat="server" GroupName="IslimitBuy" Text="��" />
                        <asp:RadioButton ID="rbtIslimitBuy2" runat="server" GroupName="IslimitBuy" Text="��" />
                    </td>
                    <td>�Ƿ���ǩ
                    </td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rbtIslimitSign1" runat="server" GroupName="IslimitSign" Text="��" />
                        <asp:RadioButton ID="rbtIslimitSign2" runat="server" GroupName="IslimitSign" Text="��" />
                    </td>
                </tr>
                <%-- <tr>
                   <td>
                       ͳ���Ӷ����
                   </td>
                    <td>
                        <asp:TextBox ID="txtOverallScale" runat="server" onchange="OverallScaleChange()"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="4" style="text-align: left; line-height: 20px; padding-left: 5px;">��һ�����ڣ���<asp:TextBox ID="txtLastBeginDate" runat="server" Width="75px"></asp:TextBox>����<asp:TextBox ID="txtLastEndDate" runat="server" Width="75px"></asp:TextBox>�գ�
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
                <tr id="Ct4">
                    <td class="tl PL10" colspan="4">
                        <%--��ֻҪ��ѡ�ˡ����̡��ͱ����ϴ��ֳ���Ƭ��ƽ��ͼ�����빴ѡ�������������ϴ������嵥����û�й�ѡ���̣���������ʾ�������<br />--%>
                        �Ƿ��ٽ����̣�<asp:RadioButton ID="rdbIsStree1" runat="server" GroupName="rdbIsStree" Text="��" /><asp:RadioButton ID="rdbIsStree2" runat="server" GroupName="rdbIsStree" Text="��" />���뱨����������  ��������������������
                        �Ƿ��̳���ϸ��<asp:RadioButton ID="rdbIsMarking1" runat="server" GroupName="rdbIsMarking" Text="��" />���뱨����������<asp:RadioButton ID="rdbIsMarking2" runat="server" GroupName="rdbIsMarking" Text="��" /><br />
                        �̳��Ƿ����ھ�Ӫ��<asp:RadioButton ID="rdbIsBusiness1" runat="server" GroupName="rdbIsBusiness" Text="��" /><asp:RadioButton ID="rdbIsBusiness2" runat="server" GroupName="rdbIsBusiness" Text="��" />
                        �Ƿ���ڷ������<asp:RadioButton ID="rdbIsBackRent1" runat="server" GroupName="rdbIsBackRent" Text="��" /><asp:RadioButton ID="rdbIsBackRent2" runat="server" GroupName="rdbIsBackRent" Text="��" /><br />
                    </td>
                </tr>
                <tr>
                    <td>��Ŀ����</td>
                    <td class="tl PL10" colspan="1">
                        <asp:RadioButton ID="rdbOneOrTwo1" runat="server" GroupName="OneOrTwo" Text="һ����Ŀ" />
                        <asp:RadioButton ID="rdbOneOrTwo2" runat="server" GroupName="OneOrTwo" Text="��������" />
                    </td>
                    <td class="tl PL10" colspan="2">
                        <asp:DropDownList ID="ddlDiskSource" runat="server" Width="150px">
                            <asp:ListItem Value="">��ѡ��</asp:ListItem>
                            <asp:ListItem Value="1">����A��</asp:ListItem>
                            <asp:ListItem Value="2">����B��</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>��Ŀ���ڵ�</td>
                    <td class="tl PL10" colspan="3">
                        <asp:DropDownList ID="ddlProjectAddress" runat="server" Width="150px"></asp:DropDownList><span style="color: red">����Ŀ���ڵأ�����˾���ֵĵ��̱�׼ѡ��</span></td>
                </tr>
                <tr>
                    <td>��Ŀ��ַ</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtProjectAddress" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>������ַ</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtReportAddress" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>��չ��<br />
                        ��ϵ��</td>
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
                        <br />
                        Ԥ�Ƶ���<asp:TextBox ID="txtUnitPrice" runat="server" Width="150px"></asp:TextBox>Ԫ/ƽ����;�����ܽ��<asp:TextBox ID="txtTotalPrice" runat="server" Width="150px"></asp:TextBox>Ԫ
                    </td>
                </tr>
                <tr>
                    <td>��˾�Ƿ������ǩԼ</td>
                    <td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbIsCoopWithECommerce1" runat="server" Text="1���ǣ��뷿��ȦǩԼ���ͻ��ֳ�֧��" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtCoopWithE1" runat="server" Width="70px"></asp:TextBox>Ԫ�Ź��ѣ�A����¥��
                        <asp:TextBox ID="txtCoopWithE2" runat="server" Width="70px"></asp:TextBox>��Э��Լ������Ȧ֧����˾����Ӷ
                        <asp:TextBox ID="txtCoopWithE3" runat="server" Width="70px"></asp:TextBox>Ԫ��B�����۳�10%Ӫ�˷��ú���˾ʵ��
                        <asp:TextBox ID="txtCoopWithE4" runat="server" Width="70px"></asp:TextBox>Ԫ������Ӷ������C����ϵͳ�蹫ʽC=B/A��
                        <asp:TextBox ID="txtCoopWithE5" runat="server" Width="70px"></asp:TextBox>%����C<90%�����ϴ���չ�̻���̵ĸ����ļ�˵��ԭ��<br />
                        ����Ŀ
                        <asp:RadioButton ID="rdbFtoZ1" runat="server" GroupName="FtoZ" Text="�ɷ���Ȧ��չ��������ԭ" />
                        <asp:RadioButton ID="rdbFtoZ2" runat="server" GroupName="FtoZ" Text="����ԭ��չ�����뷿��Ȧ" />��<br />
                        �������Ƿ����ϴ�����Ȧ����Ŀ��ͬ��������
                        <asp:RadioButton ID="rdbIsUploadF1" runat="server" GroupName="IsUploadF" Text="��" />
                        <asp:RadioButton ID="rdbIsUploadF2" runat="server" GroupName="IsUploadF" Text="��" />
                        �����ϴ������嵥��
                        
                        <br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce2" runat="server" Text="2���ǣ�����������ǩԼ�����̹�˾����" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName" runat="server" Width="300px"></asp:TextBox>
                        <br />
                        <div id="dvECommerceReason" style="padding-top: 2px; width: 100%;">
                            <span>ѡ��˵��̵����ɣ�</span>
                            <br />
                            <asp:TextBox ID="txtECommerceReason" runat="server" Width="300px" Height="60px" TextMode="MultiLine" Style="margin-top: 2px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce3" runat="server" Text="3���񣬲��������ǩԼ�����ͻ���Ҫ�ڵ��̹�˾ˢ���Ի�ȡ���Żݣ����̹�˾����" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName2" runat="server" Width="300px"></asp:TextBox>
                        ˢ���Ż�<asp:TextBox ID="txtDiscountMoney" runat="server" Width="50px" Style="margin-top: 2px;"></asp:TextBox>Ԫ
                        <%--<br />--%>
                        <br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce4" runat="server" Text="4����������Ŀû���κε��̲���" GroupName="CoopWithECommerce" /><br />
                    </td>
                </tr>

                <tr>
                    <td>�Ƿ����м����ϴ���<br />
                        ����������</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbJOrT1" runat="server" GroupName="JOrT" Text="���м�ͬ�����ϴ���" /><br />
                        <asp:RadioButton ID="rdbJOrT2" runat="server" GroupName="JOrT" Text="���м���������������������ԭ���Ҵ���������֮�����м���������" /><br />
                        <asp:RadioButton ID="rdbJOrT3" runat="server" GroupName="JOrT" Text="������Ŀ����ԭ���Ҵ�����չ��û��ί�г���ԭ������κδ�����" OnCheckedChanged="rdbJOrT3_CheckedChanged" /><br />
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
                        <br />
                        �̶���Ӷ����ͬ�����<asp:TextBox ID="txtOwnerCommFixScale" runat="server" Width="80px"></asp:TextBox>%����������ѣ��۳������Ѻ�ʵ�գ���<asp:TextBox ID="txtOwnerCommAgent" runat="server" Width="80px"></asp:TextBox>%<br />
                        �䶯��Ӷ������<br />
                        <table id="tOwner" class='sample tc' width='100%' style="border: none;">
                            <tr id="trOwner1" style="border: none;">
                                <td style="border: none;">
                                    <input type="text" id="txtOwnerCommFloatSetNumberStart1" style="width: 50px" readonly="readonly" value="0" />��<input type="text" id="txtOwnerCommFloatSetNumberEnd1" style="width: 50px" />��/<input type="text" id="txtOwnerCommFloatMoneyStart1" style="width: 50px" readonly="readonly" value="0" />��<input type="text" id="txtOwnerCommFloatMoneyEnd1" style="width: 50px" />Ԫ���۶���������۶��ѡһ����<input type="text" id="txtOwnerCommFloatKind1" style="width: 80px" />����дסլ/��Ԣ/�����Ȳ�ͬ���ͣ���ͬ�����<input type="text" id="txtOwnerCommFloatScale1" style="width: 50px" />%�����������<input type="text" id="txtOwnerCommPublishedScale1" style="width: 50px" />%</td>
                            </tr>
                            <%=SbHtml1.ToString()%>
                        </table>
                        Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbOwnerCommJump1" runat="server" Text="ȫ��BAR" GroupName="OwnerCommJump" />
                        <asp:RadioButton ID="rdbOwnerCommJump2" runat="server" Text="�ּ���BAR" GroupName="OwnerCommJump" /><br />
                        <asp:HiddenField ID="hdOwner" runat="server" />
                        <input type="button" id="btnAddRow1" value="�������" onclick="addRow1();" style="float: left; display: none" />
                        <input type="button" id="btnDeleteRow1" value="ɾ��һ��" onclick="deleteRow1();" style="float: left; display: none" /><br />
                        <br />

                        (2)��Ӷ�����У���<br />
                        <asp:TextBox ID="txtClientCommFixScale" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>

                        <div style="display: none;">
                            (2)��Ӷ�����У�������Ҫ���㵥���ֽ𽱣���ͬ����ѱ�����д������ʾ�ٷֱȵĴ����֣�
                            <br />
                            �̶���Ӷ����ͬ�����%����������ѣ��۳������Ѻ�ʵ�գ���<asp:TextBox ID="txtClientCommAgent" runat="server" Width="80px"></asp:TextBox>%<br />
                            �䶯��Ӷ������<br />
                            <table id="tClient" class='sample tc' width='100%' style="border: none;">
                                <tr id="trClient1" style="border: none;">
                                    <td style="border: none;">
                                        <input type="text" id="txtClientCommFloatSetNumberStart1" style="width: 50px" readonly="readonly" value="0" />��<input type="text" id="txtClientCommFloatSetNumberEnd1" style="width: 50px" />��/<input type="text" id="txtClientCommFloatMoneyStart1" style="width: 50px" readonly="readonly" value="0" />��<input type="text" id="txtClientCommFloatMoneyEnd1" style="width: 50px" />Ԫ���۶��ͬ�����<input type="text" id="txtClientCommFloatScale1" style="width: 50px" />%�����������<input type="text" id="txtClientCommPublishedScale1" style="width: 50px" />%</td>
                                </tr>
                                <%=SbHtml2.ToString()%>
                            </table>
                            Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbClientCommJump1" runat="server" Text="ȫ��BAR" GroupName="ClientCommJump" Checked="True" />
                            <asp:RadioButton ID="rdbClientCommJump2" runat="server" Text="�ּ���BAR" GroupName="ClientCommJump" /><br />
                            <asp:HiddenField ID="hdClient" runat="server" />
                            <input type="button" id="btnAddRow2" value="�������" onclick="addRow2();" style="float: left; display: none" />
                            <input type="button" id="btnDeleteRow2" value="ɾ��һ��" onclick="deleteRow2();" style="float: left; display: none" />
                        </div>
                        <br />
                        <br />

                        (3)����Ӷ������Ҫ���㵥���ֽ𽱣���ͬ����ѱ�����д������ʾ�ٷֱȵĴ����֣�
                        <br />
                        �̶���Ӷ����ͬ�����<asp:TextBox ID="txtEBComm" runat="server" Width="70px"></asp:TextBox>%����������ѣ��۳����̷��ü������Ѻ�ʵ�գ���<asp:TextBox ID="txtEBCommAgent" runat="server" Width="70px"></asp:TextBox>%<br />
                        �䶯��Ӷ������<br />
                        <table id="tEB" class='sample tc' width='100%' style="border: none;">
                            <tr id="trEB1" style="border: none;">
                                <td style="border: none;">
                                    <input type="text" id="txtEBCommFloatSetNumberStart1" style="width: 50px" readonly="readonly" value="0" />��<input type="text" id="txtEBCommFloatSetNumberEnd1" style="width: 50px" />��/<input type="text" id="txtEBCommFloatMoneyStart1" style="width: 50px" readonly="readonly" value="0" />��<input type="text" id="txtEBCommFloatMoneyEnd1" style="width: 50px" />Ԫ���۶���������۶��ѡһ������ͬ�����<input type="text" id="txtEBCommFloatScale1" style="width: 50px" />%�����������<input type="text" id="txtEBCommPublishedScale1" style="width: 50px" />%</td>
                            </tr>
                            <%=SbHtml3.ToString()%>
                        </table>
                        Ӷ����BAR��ʽ��<asp:RadioButton ID="rdbEBCommJump1" runat="server" Text="ȫ��BAR" GroupName="EBCommJump" />
                        <asp:RadioButton ID="rdbEBCommJump2" runat="server" Text="�ּ���BAR" GroupName="EBCommJump" /><br />
                        <asp:HiddenField ID="hdEB" runat="server" />
                        <input type="button" id="btnAddRow3" value="�������" onclick="addRow3();" style="float: left; display: none" />
                        <input type="button" id="btnDeleteRow3" value="ɾ��һ��" onclick="deleteRow3();" style="float: left; display: none" /><br />
                        <br />
                        ������������<br />
                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" Style="overflow: auto;"></asp:TextBox>
                        <br />


                        �����ֽ𽱣�<br />
                        <div id="SingleRewardC1">
                            <asp:RadioButton ID="rdbHaveSingleReward1" runat="server" Text="�У�����Ŀʵ��Ӷ�������3%" GroupName="HaveSingleReward" />
                            ���ֽ�<asp:TextBox ID="txtRewardSignHave" runat="server" Width="90px"></asp:TextBox>Ԫ/�ף�
                        �ֽ𽱵Ŀɷ��Ž��=ÿ�׾�Ӷ��*15%���Է�չ�̽���Ϊ���ޣ����ɷ��Ž��������Ϊ��ӪҵԱ44%������15%������8%�����ܼ�/�ܼࣨO/R��3%����˾30%������ÿ�׾�Ӷ���15%���ּ���˾30%����ȫ���Ͻɹ�˾���ɼ���Ա��ҵ������������Ա��Ӷ��
                        </div>
                        <div id="SingleRewardC2">
                            <asp:RadioButton ID="rdbHaveSingleReward2" runat="server" Text="�У�����Ŀʵ��Ӷ�����<2%" GroupName="HaveSingleReward" />���ֽ�ȫ���Ͻɹ�˾���ɼ���Ա��ҵ������������Ա��Ӷ��
                        </div>
                        <div id="SingleRewardC3">
                            <asp:RadioButton ID="rdbHaveSingleReward3" runat="server" Text="�ޣ�����Ŀ�����ֽ𽱡�" GroupName="HaveSingleReward" />
                        </div>
                        <div id="SingleRewardC4">
                            <asp:RadioButton ID="rdbHaveSingleReward4" runat="server" Text="�������" GroupName="HaveSingleReward" />
                        </div>
                        <div id="AnotherRewardC" style="display: none">
                            <asp:TextBox ID="txtAnotherRewardC" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                        </div>
                        <br />
                        �ֽ𽱵Ĳ�����<br />
                        ��1����չ��֧���ֽ𽱵�������<br />
                        <asp:TextBox ID="txtDeveloperConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
                        ��2�������ɷ��ֽ𽱸�ͬ�µ�������<br />
                        <asp:TextBox ID="txtAreaConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
                        <span style="color: #FF0000;">��������뱣֤�ֽ��������˻ظ���չ�̵�������ٷ��Ÿ�ͬ�£�������ɹ�˾��ʧ���������Ա�е��⳥���Σ�</span><br />
                        <br />
                        <div>�ֽ𽱵ķ��ŷ�ʽ��</div>
                        <asp:RadioButton ID="rdbPayRewardWay1" runat="server" Text="�����ɷ�չ�̻��빫˾�ʻ�����нӶ���š�" GroupName="PayRewardWay" /><br />
                        <asp:RadioButton ID="rdbPayRewardWay2" runat="server" Text="�����ɷ�չ��ֱ��֧���ֽ𣬽����˱��������벿�Ÿ����ˡ�" GroupName="PayRewardWay" /><br />
                        �ֽ��Ƿ��迪�߷�Ʊ������˾֧��˰�ѣ�
                        <asp:RadioButton ID="rdbIsMyPay1" runat="server" Text="��" GroupName="IsMyPay" />
                        <asp:RadioButton ID="rdbIsMyPay2" runat="server" Text="��" GroupName="IsMyPay" />
                        <asp:RadioButton ID="rdbIsMyPay3" runat="server" Text="�������" GroupName="IsMyPay" Visible="False" />
                        <div id="COtherCondtion" style="display: none">
                            <asp:TextBox ID="txtOtherCondtion" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                        </div>
                        <br />
                        �����Ƿ����ύ��չ�̽���ȷ���飿
                        <asp:RadioButton ID="rdbAreaComfirn1" runat="server" Text="��" GroupName="AreaComfirn" />
                        <asp:RadioButton ID="rdbAreaComfirn2" runat="server" Text="��" GroupName="AreaComfirn" />��
                        �����ŵ��<asp:TextBox ID="txtReturnBackDate" runat="server"></asp:TextBox>ǰ���ع�˾

                        <br />
                        <br />
                        �����ͬԼ����Ӷ��֧������<br />
                        <asp:TextBox ID="txtTermsOfContract" runat="server" TextMode="MultiLine" Width="98%" Rows="3" Style="overflow: auto;" MaxLength="123"></asp:TextBox>
                        <br />
                        �ش�����ĺ�ͬ�����ΥԼ�⳥��������������Ƶȣ�<br />
                        <asp:TextBox ID="txtTermsOfMajorIssues" runat="server" TextMode="MultiLine" Width="98%" Rows="3" Style="overflow: auto;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>������</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtAgentStartDate" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox ID="txtAgentEndDate" runat="server" Width="80px"></asp:TextBox></td>
                    <td>�ͻ������ڣ��Ǳ����</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtClientGuardStartDate" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox ID="txtClientGuardEndDate" runat="server" Width="80px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>�����ͬ���ƣ�</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtACName" runat="server" Width="300px"></asp:TextBox></td>
                </tr>
                <tr style="display: none">
                    <td colspan="4" class="tl PL10">
                        <table style="width: 95%; margin: 10px auto;">
                            <tr>
                                <th colspan="7" style="line-height: 25px;">��Ӷ����</th>
                            </tr>
                            <tr>
                                <td colspan="3" style="font-weight: bold;">ǩ�Ϲ���</td>
                                <td>��Ӷ������</td>
                                <td>
                                    <asp:TextBox ID="txtQRCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td>������ޣ�</td>
                                <td>
                                    <asp:TextBox ID="txtQRDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td colspan="7" style="font-weight: bold;">ǩ������ͬ</td>
                            </tr>
                            <tr>
                                <td colspan="3" style="font-weight: bold;">һ�θ���</td>
                                <td>��Ӷ������</td>
                                <td>
                                    <asp:TextBox ID="txtYCCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td>������ޣ�</td>
                                <td>
                                    <asp:TextBox ID="txtYCDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" style="font-weight: bold;">���ڸ���</td>
                            </tr>
                            <tr>
                                <td class="tl PL10">
                                    <asp:DropDownList ID="dllHirePurchase" runat="server" Width="130px" Height="20px">
                                        <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                                        <asp:ListItem Value="1">��������</asp:ListItem>
                                        <asp:ListItem Value="2">��ʵ��֧������</asp:ListItem>
                                        <asp:ListItem Value="3">��Լ��֧������</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td colspan="2">֧��������<asp:TextBox ID="txtZFRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtFQCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtFQDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td colspan="3">��֧��������ܷ���<asp:TextBox ID="txtHousingFund" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">ʱ���㣺<asp:TextBox ID="txtHour" Width="70" runat="server"></asp:TextBox>%Ӷ��</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtHousDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" style="font-weight: bold;">���Ҹ���</td>
                            </tr>
                            <tr>
                                <td colspan="2">���ڿ�
                                    <asp:DropDownList ID="ddlDownpayment" runat="server" Width="130px" Height="20px">
                                        <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                                        <asp:ListItem Value="1">���ڸ���</asp:ListItem>
                                        <asp:ListItem Value="2">��ʵ��֧������</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>�׸�������<asp:TextBox ID="txtSFRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtSFCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtSFDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td colspan="2">��  ��
                                    <asp:DropDownList ID="ddlLoan" runat="server" Width="130px" Height="20px">
                                        <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                                        <asp:ListItem Value="1">����ȫ��</asp:ListItem>
                                        <asp:ListItem Value="2">��ʵ�ʷſ����</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>�ſ������<asp:TextBox ID="txtLoanRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtFKCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtFKDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr class="AJ1">
                                <td colspan="3">���������ύ</td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtAJ1CommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtAJ1Deadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr class="AJ2">
                                <td colspan="3">������������</td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtAJ2CommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtAJ2Deadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr class="AJ3">
                                <td colspan="3">���Һ�ͬǩ��</td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtAJ3CommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtAJ3Deadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr class="BA">
                                <td colspan="3">���ϱ���</td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtBACommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtBADeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr class="YH">
                                <td colspan="3">���г�ͬ����</td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtYHCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtYHDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td>���</td>
                                <td colspan="3">��Ӷ������<asp:TextBox ID="txtRHCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="3">������ޣ�<asp:TextBox ID="txtRHDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td>����</td>
                                <td colspan="3">��Ӷ������<asp:TextBox ID="txtSXCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="3">������ޣ�<asp:TextBox ID="txtSXDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td>�������</td>
                                <td colspan="3">��Ӷ������<asp:TextBox ID="txtDLCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="3">������ޣ�<asp:TextBox ID="txtDLDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td colspan="7" style="color: red; font-weight: bold;">����˵��</td>
                            </tr>
                            <tr>
                                <td colspan="3">��֤���Ӷ���ݣ�<asp:DropDownList ID="ddlEvidence" runat="server" Width="130px" Height="20px">
                                    <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                                    <asp:ListItem Value="1">�ſ�</asp:ListItem>
                                    <asp:ListItem Value="2">ȫ��</asp:ListItem>
                                    <asp:ListItem Value="3">���ڿ�</asp:ListItem>
                                    <asp:ListItem Value="4">ǩ��������ͬ</asp:ListItem>
                                    <asp:ListItem Value="5">���</asp:ListItem>
                                    <asp:ListItem Value="6">����</asp:ListItem>
                                    <asp:ListItem Value="7">�������</asp:ListItem>
                                </asp:DropDownList></td>
                                <td colspan="2">��Ӷ������<asp:TextBox ID="txtYJCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">������ޣ�<asp:TextBox ID="txtYJDeadlines" Width="70" runat="server"></asp:TextBox>��</td>
                            </tr>
                            <tr>
                                <td colspan="7">Ԥ����ʽ��
                                    <asp:DropDownList ID="ddlReserve" runat="server" Width="100px" Height="20px">
                                        <asp:ListItem Value="1">���Ԥ��</asp:ListItem>
                                        <asp:ListItem Value="2">ÿ��Ԥ��</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>Ԥ��������<br />
                        �����</td>
                    <td colspan="3" class="tl PL10">����<asp:TextBox ID="txtPreCompleteNumber" runat="server" Width="50px"></asp:TextBox>�ף��������<asp:TextBox ID="txtPreCompleteMoney" runat="server" Width="100px"></asp:TextBox>Ԫ��Ӷ������<asp:TextBox ID="txtPreCompleteComm" runat="server" Width="100px"></asp:TextBox>Ԫ</td>
                </tr>
                <tr id="EarnMoney" style="display: none">
                    <td>Ӧ������</td>
                    <td colspan="3" class="tl PL10" style="font-size: large">��ҵ����Ӧ����Ӷ��<asp:Label ID="lbN1" runat="server"></asp:Label>Ԫ����Ŀ����Ӧ����Ӷ��<asp:Label ID="lbW1" runat="server"></asp:Label>Ԫ<br />
                        ǷӶ�ڣ����ɽ��£�3�����ڵ�Ӷ����ҵ��<asp:Label ID="lbN2" runat="server"></asp:Label>Ԫ����Ŀ��<asp:Label ID="lbW2" runat="server"></asp:Label>Ԫ��
                        ��ֹ���ڣ�<asp:Label ID="lbEndDate1" runat="server"></asp:Label><br />
                        ���Զ����˵�ǷӶ��һ�����ϵ�Ӷ����ҵ��<asp:Label ID="lbC1" runat="server"></asp:Label>Ԫ����Ŀ��<asp:Label ID="lbW3" runat="server"></asp:Label>Ԫ��
                        ��ֹ���ڣ�<asp:Label ID="lbEndDate2" runat="server"></asp:Label><br />
                        ��ҵ��Ƿ��Ҫ���ļ����˵�Ӧ����Ӷ��<asp:Label ID="lbD1" runat="server"></asp:Label>Ԫ����Ŀ��Ƿ��Ҫ���ļ����˵�Ӧ����Ӷ��<asp:Label ID="lbD2" runat="server"></asp:Label>Ԫ��
                        ��ֹ���ڣ�<asp:Label ID="lbEndDate3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="CouldFlange" style="display: none">
                    <td>��������̴���Ŀ��<br />
                        ��������</td>
                    <td colspan="3" class="tl PL10" style="font-size: large">
                        <asp:Label ID="lbFlange" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>��Ŀ�Ƿ���ǷӶ</td>
                    <td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbIsProjEarlyCommBack1" runat="server" Text="��" GroupName="ProjEarlyComm" /><label for="r2d2b2">����ĿǷӶ���<asp:TextBox ID="txtOweCommSum" runat="server" Width="80px"></asp:TextBox>
                            Ԫ��ǷӶԭ��<br />
                            <asp:TextBox ID="txtAreaReason" runat="server" Width="96%" TextMode="MultiLine"></asp:TextBox>��<br />
                            ��ŵ�ջ�ǷӶʱ��<asp:TextBox ID="txtGuaranTime" runat="server"></asp:TextBox>
                            ԭ���̲���ǷӶ���<asp:TextBox ID="txtOrdMoney" runat="server" Width="100px"></asp:TextBox>Ԫ����ԭ���̲���
                        <asp:TextBox ID="txtOrdTaker" runat="server" Width="160px"></asp:TextBox>�����˸���׷�� 
                        </label>
                        <br />

                        <asp:RadioButton ID="rdbIsProjEarlyCommBack2" runat="server" Text="��ǷӶ��ȫ���ջ�" GroupName="ProjEarlyComm" /><br />
                    </td>
                </tr>


                <tr>
                    <td>�мҴ�����Ϣ</td>
                    <td colspan="3" class="tl PL10">
                        <div>����Ŀ���м�ͬ�����ϴ������������������Ϊ����������������˽������Ϣ�޷���д������ע�����������˽������Ϣ����</div>
                        <br />
                        1.���ƣ�<asp:TextBox ID="txtSamePlaceXX1" runat="server" Width="200px"></asp:TextBox>
                        ����ѣ�<asp:TextBox ID="txtAgencyFee1" runat="server" Width="200px"></asp:TextBox><br />
                        �ֽ𽱣�<asp:RadioButton ID="rdbIsCashPrize11" runat="server" Text="�У�" GroupName="CashPrize1" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize1" runat="server" Width="200px"></asp:TextBox>Ԫ/��</label><asp:RadioButton ID="rdbIsCashPrize12" runat="server" Text="��" GroupName="CashPrize1" /><br />
                        ��Ŀ���ã�<asp:RadioButton ID="rdbIsPFear11" runat="server" Text="�У�����" GroupName="IsPFear1" />
                        <label for="r2d2b2">
                            <asp:TextBox ID="txtPFear1" runat="server" Width="200px"></asp:TextBox></label>
                        <asp:RadioButton ID="rdbIsPFear12" runat="server" Text="��" GroupName="IsPFear1" /><br />
                        2.���ƣ�<asp:TextBox ID="txtSamePlaceXX2" runat="server" Width="200px"></asp:TextBox>
                        ����ѣ�<asp:TextBox ID="txtAgencyFee2" runat="server" Width="200px"></asp:TextBox><br />
                        <label for="r2d2b2"></label>
                        �ֽ𽱣�<asp:RadioButton ID="rdbIsCashPrize21" runat="server" Text="�У�" GroupName="CashPrize2" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize2" runat="server" Width="200px"></asp:TextBox>Ԫ/��</label><asp:RadioButton ID="rdbIsCashPrize22" runat="server" Text="��" GroupName="CashPrize2" /><br />
                        ��Ŀ���ã�<asp:RadioButton ID="rdbIsPFear21" runat="server" Text="�У�����" GroupName="IsPFear2" />
                        <label for="r2d2b2">
                            <asp:TextBox ID="txtPFear2" runat="server" Width="200px"></asp:TextBox></label>
                        <asp:RadioButton ID="rdbIsPFear22" runat="server" Text="��" GroupName="IsPFear2" /><br />
                    </td>
                </tr>

                <tr>
                    <td>���벿�Ž���ģʽ</td>
                    <td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbSaleMode1" runat="server" Text="�������̣�" GroupName="SaleMode" Checked="true" /><label for="r2d2b2">ͳ����<asp:TextBox ID="txtAreaScale1" runat="server" Width="110px" Enabled="true"></asp:TextBox>��ֳɽ���<asp:TextBox ID="txtMainAreaScale" runat="server" Width="50px"></asp:TextBox>%�� �ɽ���ռ<asp:TextBox ID="txtDealAreaScale" runat="server" Width="50px"></asp:TextBox>%</label>
                        <br />
                        ���ɽ�����ֲ�������85%��
                        <div id="divSaleMode2" style="margin-top: 10px; margin-bottom: 10px;">
                            <asp:RadioButton ID="rdbSaleMode2" runat="server" Text="�����������̣�ͳ����" GroupName="SaleMode" Height="30px" />
                            <label for="r2d2b2">
                                <asp:TextBox ID="txtAreaScale" runat="server" Width="60%" Height="40px" Enabled="false" TextMode="MultiLine"></asp:TextBox>��
                                ��ֳɽ���<asp:TextBox ID="txtMainAreaScale2" runat="server" Width="50px"></asp:TextBox>
                                %��������<asp:TextBox ID="txtAS2" runat="server" Width="60%" Height="40px" TextMode="MultiLine"></asp:TextBox>��
                                ��ֳɽ���<asp:TextBox ID="txtMS2" runat="server" Width="50px"></asp:TextBox>
                                %��ͳ����+�����������Ӳ��ó���15%�����ɽ�����ֳɽ���
                                <asp:TextBox ID="txtDealAreaScale2" runat="server" Width="50px"></asp:TextBox>%���ɽ�����ֲ�������85%��
                            </label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>������ԭ<br />
                        �������ֹ�˾����</td>
                    <td colspan="3" class="tl PL10">1��������˾��
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
                <%--           <tr>
                    <th colspan="4" style="line-height:25px;" >ͳ���Ӷ����</th>
				</tr>
             <tr>
                    <td colspan="4">
                          <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                            <td>��ʼʱ��</td>
                                            <td>����ʱ��</td>
                                              <td>����</td>
                                            <td>����</td>
                                            <td>���</td>
                                            <td>����</td>
                                           
                                          
                                        </tr>
                                        <tbody id="jzqk">
                                            <tr>
                                                 <td><input type="text" style="width:69px" name="BeginDate" emptymes="����д��ʼʱ��" dateplugin="datepicker"onchange="checkBeginDate(this)" /></td>
                                                <td><input type="text" style="width:69px" name="EndDate" emptymes="����д����ʱ��" dateplugin="datepicker" /></td>
                                              
                                                <td><input type="text" style="width:80px" name="EmployeeID" emptymes="����д����" onblur="getEmployee(this)"/></td>
                                                <td><input type="text" style="width:100px; background-color:#E0E0E0" name="EmployeeName" readonly="readonly" emptymes="��������"/></td>
                                                <td><input type="text" style="width:80px; background-color:#E0E0E0" name="UnitName"  readonly="readonly" emptymes="����д���"/></td>
                                                 <td><input type="text" style="width:90px" name="Scale" emptymes="����д����(%)" onchange="checkScale(this)"/></td>
                                                
                                            </tr>
                                        </tbody>
                                       
                                        <tr>
                                            <td style="text-align:left" colspan="7"><input class="btnaddRowN" type="button" value="�������" onclick="addrow(this, 'jzqk', null)" /><input class="btnaddRowN" type="button" onclick="delrow(this, 'jzqk')" value="ɾ��һ��" />

                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidDetail" runat="server" />
                           <asp:button runat="server" id="btnSave1" text="����"  OnClick="btnSave1_Click" Visible="false"   OnClientClick=" return check1()"/>
                    </td>
                 
                </tr>--%>
                <tr>
                    <th colspan="4" style="line-height: 25px;">��������</th>
                </tr>
                <tr class="noborder" style="height: 85px;" runat="server" id="trYesIDx1">
                    <%--style="border: 1px solid #000000;"--%>
                    <td>������</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">ͬ��</label><input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">�������</label>
                        <span id="sp001" style="display: none;">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbFYQ_Click" OnClientClick="return confirm('ȷ��Ҫ��ӻ�ޥ��������')">��ӻ�ޥ������</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lbCancelFYQ_Click" OnClientClick="return confirm('ȷ��Ҫȡ����ޥ��������')">ȡ����ޥ������</asp:LinkButton>
                        </span>
                        <br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="ǩ��" onclick="sign('1')" style="display: none;" />

                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td>��ҵ�������������</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">ͬ��</label><input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">�������</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="ǩ��" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="OrdinaryC" class="noborder" style="height: 85px; display: none;">
                    <td>ԭ���̲��Ÿ��������</td>
                    <td colspan="3" class="tl PL10" style="">
                        <div style="display: none">
                            <input id="rdbYesIDx3" type="radio" name="agree3" checked="checked" /><label for="rdbYesIDx3">ͬ��</label>
                        </div>
                        <textarea id="txtIDx3" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="ǩ��" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td>Ӧ�տ���������</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">ͬ��</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">��ͬ��</label>
                        <input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">�������</label><br />
                        ��Ӷ������<br />
                        <div style="float: right">һ���Ը��ǰӶ<input id="txtOneFront" runat="server" type="text" style="width: 217px" />��Ӷ<input id="txtOneAfter" type="text" runat="server" style="width: 217px" /></div>
                        <div style="float: right">���ң�ǰӶ<input id="txtTurnFront" runat="server" type="text" style="width: 217px" />��Ӷ<input id="txtTurnAfter" type="text" runat="server" style="width: 217px" /></div>
                        <br />
                        <asp:Button runat="server" CssClass="finSignBtn" ID="bFinSige" OnClick="btnComm_Click" Text="ȷ��" OnClientClick="return checkAduit()" Visible="false" />
                        <textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="ǩ��" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx8">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px; display: none;" id="tr14">
                    <td>����Ȧ���</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx14" type="radio" name="agree14" /><label for="rdbYesIDx14">ͬ��</label>
                        <input id="rdbNoIDx14" type="radio" name="agree14" /><label for="rdbNoIDx14">��ͬ��</label>
                        <input id="rdbOtherIDx14" type="radio" name="agree14" /><label for="rdbOtherIDx14">�������</label><br />
                        <textarea id="txtIDx14" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx14" value="ǩ��" onclick="sign('14')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx14">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td id="tdLaw4">���ɲ����</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx15" type="radio" name="agree15" /><label for="rdbYesIDx15">ͬ��</label>
                        <input id="rdbNoIDx15" type="radio" name="agree15" /><label for="rdbNoIDx15">��ͬ��</label>
                        <input id="rdbOtherIDx15" type="radio" name="agree15" /><label for="rdbOtherIDx15">�������</label>
                        <span id="sp005" style="display: none;">
                            <asp:LinkButton ID="lbFYQ" runat="server" OnClick="lbFYQ_Click" OnClientClick="return confirm('ȷ��Ҫ��ӻ�ޥ��������')">��ӻ�ޥ������</asp:LinkButton>
                            <asp:LinkButton ID="lbCancelFYQ" runat="server" OnClick="lbCancelFYQ_Click" OnClientClick="return confirm('ȷ��Ҫȡ����ޥ������')">ȡ����ޥ������</asp:LinkButton>
                            <%--<asp:LinkButton ID="lbOCDeptm" runat="server" OnClick="lbOCDeptm_Click">��ӳ½�������</asp:LinkButton>--%>
                        </span>
                        <br />
                        <textarea id="txtIDx15" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx15" value="ǩ�����" onclick="sign('15')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx15">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trLaw5" class="noborder" style="height: 85px; display: none;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx16" type="radio" name="agree16" /><label for="rdbYesIDx16">ͬ��</label>
                        <input id="rdbNoIDx16" type="radio" name="agree16" /><label for="rdbNoIDx16">��ͬ��</label>
                        <input id="rdbOtherIDx16" type="radio" name="agree16" /><label for="rdbOtherIDx16">�������</label>
                        <span id="sp006" style="display: none;">
                            <%--<asp:LinkButton ID="lbtnAddMaster" runat="server" OnClick="lbtnAddMaster_Click">��ӻ�������</asp:LinkButton>--%>
                        </span>
                        <br />
                        <textarea id="txtIDx16" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx16" value="ǩ�����" onclick="sign('16')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx16">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trGeneralManager" class="noborder" style="height: 85px; display: none;">
                    <td>�����ܾ���<br />
                        ����</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx17" type="radio" name="agree17" /><label for="rdbYesIDx17">ͬ��</label>
                        <input id="rdbNoIDx17" type="radio" name="agree17" /><label for="rdbNoIDx17">��ͬ��</label>
                        <input id="rdbOtherIDx17" type="radio" name="agree17" /><label for="rdbOtherIDx17">�������</label><br />
                        <textarea id="txtIDx17" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx17" value="ǩ�����" onclick="sign('17')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx17">_________</span>
                        </span>
                    </td>
                </tr>


                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
                    <td>����ظ��������<br />
                        ����ѡ�</td>
                    <td colspan="3" class="tl PL10" style="">
                        <textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx200">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF4" class="noborder" style="height: 85px; display: none;">
                    <td>ԭ���̲��Ÿ�����<br />
                        �ظ��������ѡ�</td>
                    <td colspan="3" class="tl PL10" style="">
                        <textarea id="txtIDx205" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx205" runat="server" OnClick="btnSignIDx205_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">���ڣ�<span id="spanDateIDx205">_________</span></div>
                    </td>
                </tr>
                <tr id="trAddAnoF2" class="noborder" style="height: 85px; display: none;">
                    <td rowspan="2">���ɲ�����<br />
                        <asp:Button ID="btnShouldJumpIDx" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
                    </td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb210a1" runat="server" Text="ͬ��" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a2" runat="server" Text="��ͬ��" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a3" runat="server" Text="�������" GroupName="210a" ForeColor="#008162" />
                        <textarea id="txtIDx210" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx210" runat="server" OnClick="btnSignIDx210_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx210">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF5" class="noborder" style="height: 85px; display: none;">
                    <%-- <td id="trf5" style="display:none;">
                        ���ɲ�����<br />
                        <asp:Button ID="Button1" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
					</td>--%>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:Button ID="Button2" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
                        <asp:RadioButton ID="rdb211a1" runat="server" Text="ͬ��" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a2" runat="server" Text="��ͬ��" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a3" runat="server" Text="�������" GroupName="211a" ForeColor="#008162" />
                        <textarea id="txtIDx211" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx211" runat="server" OnClick="btnSignIDx211_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx211">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
                    <td>�����ܾ�����</td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="ͬ��" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="��ͬ��" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="�������" GroupName="220a" ForeColor="#186ebe" />
                        <textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="ȷ��" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">���ڣ�<span id="spanDateIDx220">_________</span>
                        </span>
                    </td>
                </tr>

            </table>
            <table id="tbAround2" width="720px">
                <thead>
                    <tr>
                        <td style="font-weight: bold; text-align: left; padding-left: 10px;" colspan="2">���ϴ����ϣ�</td>
                    </tr>
                </thead>
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
                        <asp:CheckBox ID="cbLack7" runat="server" Text="����Ȧ����Ŀ��ͬ������" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;" colspan="2">
                        <asp:CheckBox ID="cbLack6" runat="server" Text="��������" /><br />
                        <asp:TextBox ID="txtLack6" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="width: 640px; margin: 0 auto;">
                <span class="tl" style="float: left;">��ע��1��ҵ���н�һ����Ŀ/һ�ֻ�β�̣����ϴ˱��������<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2��ҵ���нӶ�����ҵ��20�׻����ϵ���������Ŀ�����ϴ˱��������</span>
            </div>
            <!--��ӡ���Ľ���-->
        </div>
        <div style="clear: both;"></div>

        <div class="noprint">
            <asp:GridView ID="gvAttach" CssClass="gvAttach" runat="server" BackColor="White" Style="clear: both; margin-top: 3px;"
                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="false"
                ForeColor="Black" GridLines="Vertical" OnRowCommand="gvAttach_RowCommand">
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
            </asp:GridView>
            <div id="PageBottom">
                <span id="spm"></span>
                <br />
                <hr />

                <asp:Button runat="server" ID="btnReWrite" Text="���µ���" OnClick="btnReWrite_Click" Visible="False" />
                <asp:Button runat="server" ID="btnSave" Text="����" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnTemp" Text="��ʱ����" OnClick="btnTempSave_Click" CssClass="commonbtn" OnClientClick="return tempsavecheck();" />
                <asp:Button runat="server" ID="btnSAlterC" Text="�޸�" Visible="false" OnClientClick="if(confirm('�޸ĺ������������Ļ��ڶ���������ȷ��Ҫ�޸���'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="�ϴ�����..." onclick="upload();" style="margin-left: 5px;" />
                <asp:Button ID="btnDownload" runat="server" Text="����ѡ�и���" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <asp:Button runat="server" ID="btnSignSave" Text="��ע������" OnClick="btnSignSave_Click" Visible="false" />
                <input type="button" id="btnPrint" value="��ӡ" onclick="myPrint('��ӡ���Ŀ�ʼ','��ӡ���Ľ���');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="���ΪPDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="����" OnClick="btnBack_Click" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />
                <input type="hidden" id="hdDetail" runat="server" />
                <asp:HiddenField ID="hfKey1" runat="server" Value="" />
                <asp:HiddenField ID="hfKey2" runat="server" Value="" />

                <asp:HiddenField ID="hdProjectArea" runat="server" Value="" />
                <asp:HiddenField ID="hdProjectAddress" runat="server" Value="" />
                <asp:HiddenField ID="hdReportAddress" runat="server" Value="" />
                <asp:HiddenField ID="hdTermsOfMajorIssues" runat="server" Value="" />
                <asp:HiddenField ID="hdEmpID" runat="server" Value="" />
                <asp:HiddenField ID="hdEmpName" runat="server" Value="" />

                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:HiddenField ID="HidAutoN" runat="server" />
                <asp:HiddenField ID="HdAutoAdd" runat="server" />
                <asp:HiddenField ID="HdP" runat="server" />
                <asp:HiddenField ID="HdE" runat="server" />
                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        AddOtherAgree();
    </script>
    <%=SbJs.ToString()%>
    <script type="text/javascript">
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx210"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx211"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //ʹ�Ի�������Ӧ
        $("#<%=rdbSaleMode2.ClientID %>").attr("disabled","disabled")
        $("#<%=txtAreaScale.ClientID %>").attr("disabled","disabled")
        $("#<%=txtMainAreaScale2.ClientID %>").attr("disabled","disabled")
        $("#<%=txtAS2.ClientID %>").attr("disabled","disabled")
        $("#<%=txtMS2.ClientID %>").attr("disabled","disabled")
        $("#<%=txtDealAreaScale2.ClientID %>").attr("disabled","disabled")
        //debugger;
        //���ܰ�Ҫ���������벿�Ž��̣�����ǰ��¼�������еڶ�����
        //if ($("#<%=lblApplyDate.ClientID %>").html().trim() < '2018-05-13') 
        //������ie�У�.trim()�����ᱨ ����֧�֡�trim�����Ի򷽷� ��������������jquery�Դ��ķ��� $.trim() ȥ�滻
        var applyDate = $("#<%=lblApplyDate.ClientID %>").html();
        if ($.trim(applyDate) < '2018-05-13')
        {
            $("#divSaleMode2").show();
        }
        else { $("#divSaleMode2").hide() }
    </script>
    <%-- �������������룺ͬ����������ֻ��ʾ��߼��������(2016/10/8--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
</asp:Content>
