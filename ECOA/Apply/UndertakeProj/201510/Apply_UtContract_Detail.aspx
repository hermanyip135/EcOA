<%@ Page ValidateRequest="false" Title="物业部项目续约申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_UtContract_Detail.aspx.cs" Inherits="Apply_UtContract_Apply_UtContract_Detail" %>

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
            //初始化时间控件
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
	      

            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
            //2019-08-08 增加单选框事件
            $("#<%=rdbIsCoopWithECommerce1.ClientID%>").click(function(){
                //debugger;
                ECommerceRbtnClickFun("1");
            });

            //2019-08-08 CREATE BY HERMAN：增加控件的点击事件
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
                alert("请上传相关的资料！");
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
                alert("请勾选已上传的资料名称！");
                $("#<%=cbLack1.ClientID%>").focus();
                return false;
            }
            if($("#<%=cbLack6.ClientID%>").prop("checked")){
                if($.trim($("#<%=txtLack6.ClientID%>").val()) == ""){
                    alert("由于您选了其它资料，请填相应的资料名称！");
                    $("#<%=txtLack6.ClientID%>").focus();
                    return false;
                }
            }

            if ($("#<%=cbBaseAgent2.ClientID%>").prop("checked") || $("#<%=cbBaseAgent3.ClientID%>").prop("checked")) { //M_0001：20151016
                alert("场内代理选了合富辉煌或世联则无法保存！");
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
                alert("请选择物业性质！");
                return false;
            }
            else
                $("#<%=hdDealOfficeType.ClientID%>").val(typeValues.substr(0, typeValues.length - 1));

            if(!$("#<%=rbtIsPreSale1.ClientID%>").prop("checked") && !$("#<%=rbtIsPreSale2.ClientID%>").prop("checked")){
                alert("请选择是否已有预售证！");
                $("#<%=rbtIsPreSale1.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=rbtIslimitBuy1.ClientID%>").prop("checked") && !$("#<%=rbtIslimitBuy2.ClientID%>").prop("checked")){
                alert("请选择是否限购！");
                $("#<%=rbtIslimitBuy1.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=rbtIslimitSign1.ClientID%>").prop("checked") && !$("#<%=rbtIslimitSign2.ClientID%>").prop("checked")){
                alert("请选择是否限签！");
                $("#<%=rbtIslimitSign1.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=rdbOneOrTwo1.ClientID%>").prop("checked") && !$("#<%=rdbOneOrTwo2.ClientID%>").prop("checked")){
                alert("请选择项目性质！");
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
                alert("请选择是否与该发展商直接签约？");
                $("#radDirectContract1").focus();
                return false;
            }
            $("#<%=this.hiDirectContract.ClientID%>").val(valDirectContract);
            if('2' == valDirectContract)
            {
                if("" == $.trim($("#<%=txtCorporateName.ClientID%>").val()))
                {
                    alert("请填写签约公司名称");
                    $("#<%=txtCorporateName.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=ddlCorporateType.ClientID%>").val()) == "")
                {
                    alert("请选择签约公司类型");
                    $("#<%=ddlCorporateType.ClientID%>").focus();
                    return false;
                }
            }
            //if ($.trim($("#<%=txtProjectArea.ClientID%>").val()) == "") { alert("项目所在区域不可为空！"); $("#<%=txtProjectArea.ClientID%>").focus(); return false; }
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

            if ($("#<%=txtTermsOfContract.ClientID%>").val().length > 123) {
                alert("代理合同约定的佣金支付条件不要超过123个字（3行）。");
                $("#<%=txtTermsOfContract.ClientID%>").focus();
                return false;
            }

            //项目是否有欠佣
            if(!$("#<%=this.rdbIsProjEarlyCommBack1.ClientID%>").prop("checked") && !$("#<%=this.rdbIsProjEarlyCommBack2.ClientID%>").prop("checked"))
            {
                alert("请勾选项目是否有欠佣");
                $("#<%=this.rdbIsProjEarlyCommBack1.ClientID%>").focus();
                return false;
            }
            if($("#<%=this.rdbIsProjEarlyCommBack1.ClientID%>").prop("checked"))
            {
                if($.trim($("#<%=this.txtOweCommSum.ClientID%>").val()) == "")
                {
                    alert("请填写项目欠佣金额");
                    $("#<%=this.txtOweCommSum.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=this.txtAreaReason.ClientID%>").val()) == "")
                {
                    alert("请填写欠佣原因");
                    $("#<%=this.txtAreaReason.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=this.txtGuaranTime.ClientID%>").val()) == "")
                {
                    alert("请填写回收时间");
                    $("#<%=this.txtGuaranTime.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=this.txtOrdMoney.ClientID%>").val()) == "")
                {
                    alert("请填写原接盘部门欠佣金额");
                    $("#<%=this.txtOrdMoney.ClientID%>").focus();
                    return false;
                }
                if($.trim($("#<%=this.txtOrdTaker.ClientID%>").val()) == "")
                {
                    alert("请填写谁负责追收");
                    $("#<%=this.txtOrdTaker.ClientID%>").focus();
                    return false;
                }
            }

            if ($("#<%=txtLastBeginDate.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写上一代理开始期！");
                $("#<%=txtLastBeginDate.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtLastEndDate.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写上一代理结束期！");
                $("#<%=txtLastEndDate.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtLastSumNum.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写上一代理成效宗数！");
                $("#<%=txtLastSumNum.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtLastResults.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写上一代理成交业绩！");
                $("#<%=txtLastResults.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtCumulativeBeginDate.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写累计成交开始日！");
                $("#<%=txtCumulativeBeginDate.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtCumulativeEndDate.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写累计成交结束日！");
                $("#<%=txtCumulativeEndDate.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtCumulativeNum.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写累计成交宗数！");
                $("#<%=txtCumulativeNum.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtCumulativeResults.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写累计成交业绩！");
                $("#<%=txtCumulativeResults.ClientID%>").focus();
                return false;
            }

            if ($("#<%=txtTurnover.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写成交额！");
                $("#<%=txtTurnover.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtSumTurnover.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写总成交额！");
                $("#<%=txtSumTurnover.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtACName.ClientID%>").val() == "") {
                alert("由于代理性质是续约，请填写代理合同名称！");
                $("#<%=txtACName.ClientID%>").focus();
                return false;
            }
            //}

            if ($("#<%=txtName1.ClientID%>").val() == "" && $("#<%=txtName2.ClientID%>").val() == "") {
                alert("请填写相应的项目名称！");
                $("#<%=txtName1.ClientID%>").focus();
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

            if($("#<%=rdbIsCoopWithECommerce1.ClientID %>").prop("checked")){
                if (!$("#<%=rdbFtoZ1.ClientID %>").prop("checked") && !$("#<%=rdbFtoZ2.ClientID%>").prop("checked")) {
                    alert("请选择引入方式");
                    $("#<%=rdbFtoZ1.ClientID%>").focus();
                    return false;
                }
                if (!$("#<%=rdbIsUploadF1.ClientID %>").prop("checked") && !$("#<%=rdbIsUploadF2.ClientID%>").prop("checked")) {
                    alert("请选择是否已上传房友圈");
                    $("#<%=rdbIsUploadF1.ClientID%>").focus();
                    return false;
                }
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
	        

            if (!$("#<%=rdbOwnerCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbOwnerCommJump2.ClientID%>").prop("checked")) {
                alert("请选择业佣跳BAR方式");
                $("#<%=rdbOwnerCommJump1.ClientID%>").focus();
                return false;
            }
            //if (!$("#<%=rdbClientCommJump1.ClientID%>").prop("checked") && !$("#<%=rdbClientCommJump2.ClientID%>").prop("checked")) {
            //    alert("请选择客佣跳BAR方式");
            //    $("#<%=rdbClientCommJump1.ClientID%>").focus();
            //    return false;
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
                if (($("#<%=txtMainAreaScale2.ClientID%>").val()*1 + $("#<%=txtMS2.ClientID%>").val()*1) > 15) {
                    alert("统筹区+合作区拆分相加不得超过15%！");
                    $("#<%=txtMainAreaScale2.ClientID%>").focus();
                    return false;
                }
                if ($("#<%=txtDealAreaScale2.ClientID%>").val() < 85) {
                    alert("成交区拆分不低于85%！");
                    $("#<%=txtDealAreaScale2.ClientID%>").focus();
                    return false;
                }
	            
            }


            //2016/8/24 52100 项目所在地
    if ($.trim($("#<%=ddlProjectAddress.ClientID%>").val()) == ""||$.trim($("#<%=ddlProjectAddress.ClientID%>").val())=="0") {
                alert("项目所在地必须选择。");
                $("#<%=ddlProjectAddress.ClientID%>").focus();
                return false;
            }
            if ($.trim($("#<%=ddlDiskSource.ClientID%>").val()) == ""||$.trim($("#<%=ddlDiskSource.ClientID%>").val())=="0") {
                alert("项目所在盘源必须选择。");
                $("#<%=ddlDiskSource.ClientID%>").focus();
                return false;
            }
            //
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

            //2019-08-15 增加非空验证
            if ($("#<%=rdbIsCoopWithECommerce2.ClientID %>").prop("checked")) {

                if ($.trim($("#<%=txtECommerceReason.ClientID%>").val()) == "") {
                    alert("选择此电商的理由不可为空！");
                    $("#<%=txtECommerceReason.ClientID%>").focus();
                    return false;
                }

            }

            if ($("#<%=rdbIsCoopWithECommerce3.ClientID %>").prop("checked")) {
                var discountMoney = $("#<%=txtDiscountMoney.ClientID%>").val();
                if ($.trim(discountMoney) == "") {
                    alert("刷卡优惠的金额不能为空！");
                    $("#<%=txtDiscountMoney.ClientID%>").focus();
                    return false;
                }
                else {
                    /**
                    * 校验只要是数字（包含正负整数，0以及正负浮点数）就返回true
                    **/
                    var regPos = new RegExp("/^\d+(\.\d+)?$/"); //非负浮点数
                    var regNeg = new RegExp("/^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/"); //负浮点数
                    if (regPos.test(discountMoney) || !regNeg.test(discountMoney)) {
                        return true;
                    }
                    else {
                        alert("请填写正确格式的数字，格式如：0.00！");
                        $("#<%=txtDiscountMoney.ClientID%>").focus();
                        return false;
                    }

                }

            }
	        
        }

        //暂时保存
        function tempsavecheck()
        {
            //物业性质
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
            //发展商佣
            var data = "";
            $("#tOwner tr").each(function (i) {
                var n = i + 1;
                data += $.trim($("#txtOwnerCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatKind" + n).val()) + "&&" + $.trim($("#txtOwnerCommFloatScale" + n).val()) + "&&" + $.trim($("#txtOwnerCommPublishedScale" + n).val()) + "||";
            });
            if (data!="") {
                data = data.substr(0, data.length - 2);
                $("#<%=hdOwner.ClientID%>").val(data);
            }
            //客佣
            data = "";
            $("#tClient tr").each(function (i) {
                var n = i + 1;
                data += $.trim($("#txtClientCommFloatSetNumberStart" + n).val()) + "&&" + $.trim($("#txtClientCommFloatSetNumberEnd" + n).val()) + "&&" + $.trim($("#txtClientCommFloatMoneyStart" + n).val()) + "&&" + $.trim($("#txtClientCommFloatMoneyEnd" + n).val()) + "&&" + $.trim($("#txtClientCommFloatScale" + n).val()) + "&&" + $.trim($("#txtClientCommPublishedScale" + n).val()) + "||";
            });
            if (data!="") {
                data = data.substr(0, data.length - 2);
                $("#<%=hdClient.ClientID%>").val(data);
            }
            //电商佣
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
                alert("请勾选文件再下载！");
				
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
                        $("#spm").html("<br />您已上传了：<br />" + sReturnValue);
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
            if (confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }

        function sign(idx) {
            //if (idx == '1'||idx == '2') {
            //    if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
            //        alert("请确定同意或其它同意！");
            //        return;
            //    }
            //}
            //else {
            //    if (!$("#rdbYesIDx" + idx).prop("checked") && !$("#rdbNoIDx" + idx).prop("checked") && !$("#rdbOtherIDx" + idx).prop("checked")) {
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
}

        function addRow1() {
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
      
        //增加一行
        function addrow(e,idname,obj) {
            var copytr = $("#" + idname + " tr").first().clone();
            if(obj != null && obj != undefined && isjson(obj))
            {
                for(var k in obj) {
                    $(copytr).find("input[name=" + k + "]").val(obj[k]);
                    //遍历对象，k即为key，obj[k]为当前k对应的值
                    //   console.log(k);
                }
                         
            }
            else
            {
                $(copytr).find("input[type=text]").val("");
                      
                $(copytr).find("input[name=EmployeeID]").removeAttr("readonly")
                $(copytr).find("input[name=EmployeeID]").css("background-color","");
                $(copytr).find("input[name=BeginDate]").val($("#<%=txtAgentStartDate.ClientID%>").val());
                $(copytr).find("input[type=hidden]").val("请选择");
            }
            $(copytr).find("[dateplugin='datepicker']").each(function(){
                $(this).removeAttr("id").removeAttr("class");
                $(this).datepicker();
            });
            $("#" + idname).append(copytr);
            return;
        }
        //删除行
        function delrow(e,idname) {
    var l = $("#" + idname + " tr").length;
          
    if(l == 1)
    {
        alert("最后一行不能再删");
        return;
    }
    if( $("#" + idname + " tr").last().find("input[name=EmployeeID]").attr("readonly"))
    {
        alert("已保存数据不能再删");
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
        alert('请填写开始时间')
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
                var TextBoxNo = 0;//从0开始 内第几个inpu
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
        //加载明细 idname =hidDetail(隐藏的json) Idtbody=绑在那个id
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
                    //遍历对象，k即为key，obj[k]为当前k对应的值
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
        //统筹比例检查
        function checkScale(e)
{
    var regex = /^\d+$/;  
    if(regex.test(e.value)){  
        if(e.value<100 && e.value>0){  
                   
        }else{  
            alert("请输入小于100正整数")
            e.value='';
            e.focus();
            return false;
        }  
    }else{  
        alert("非整数");
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
                alert('请选择日期在代理期内');
            }
        }
        //是否与该发展商直接签约
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

        //我司是否与电商签约单选按钮选择事件
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
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>物业部项目续约申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 720px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber%></span></div>
            <%--style="border-style:double; border-color:Black; border-width:5px; margin: 0 auto; background-color: #fff; border-collapse: collapse;" --%>
            <table id="tbAround" width='720px'>
                <tr>
                    <td style="width: 20%">物业部曾接盘的项目名称</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtName1" runat="server" Width="95%"></asp:TextBox><br />
                        <asp:LinkButton ID="lbNewProj1" runat="server" OnClick="lbNewProj1_Click">新项目申请链接</asp:LinkButton>
                    </td>
                    <td style="width: 20%">项目部曾接盘的项目名称</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtName2" runat="server" Width="95%"></asp:TextBox><br />
                        <asp:LinkButton ID="lbNewProj2" runat="server" OnClick="lbNewProj1_Click">新项目申请链接</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">申请部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
                    <td style="width: 20%">申请人</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApply" runat="server" Width="70px"></asp:TextBox>
                        -
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>项目发展商<br />
                        (小业主)</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDeveloper" runat="server"></asp:TextBox></td>
                    <td>所属集团名称</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>是否与该发展商直接签约</td>
                    <td class="tl PL10" colspan="3">
                        <span class="isDirectContractCss">
                            <input type="radio" id="radDirectContract1" name="DirectContract" value="1" onclick="isDirectContract(1)" /><label for="radDirectContract1" id="lYesDirectContract">是</label>
                            <input type="radio" id="radDirectContract2" name="DirectContract" value="2" onclick="isDirectContract(2)" /><label for="radDirectContract2" id="lNoDirectContract">否</label>
                            <asp:HiddenField ID="hiDirectContract" runat="server" />
                        </span>
                        <span style="float: right" id="NoDirectContract">签约公司名称：<asp:TextBox ID="txtCorporateName" runat="server"></asp:TextBox>
                            该公司类型：
                        <asp:DropDownList ID="ddlCorporateType" runat="server" Width="100px"></asp:DropDownList>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>场内代理</td>
                    <td class="tl PL10" colspan="3">
                        <asp:CheckBox ID="cbBaseAgent1" runat="server" Text="中原项目部" />
                        <asp:CheckBox ID="cbBaseAgent2" runat="server" Text="合富辉煌" /><asp:CheckBox ID="cbBaseAgent3" runat="server" Text="世联" /><asp:CheckBox ID="cbBaseAgent4" runat="server" Text="其它" />
                        <asp:TextBox ID="txtBaseAgentOther" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>代理类型</td>
                    <td class="tl PL10">
                        <asp:DropDownList ID="ddlDealType" runat="server" Width="100px"></asp:DropDownList></td>
                    <td>是否已有预售证
                    </td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rbtIsPreSale1" runat="server" GroupName="IsPreSale" Text="是" />
                        <asp:RadioButton ID="rbtIsPreSale2" runat="server" GroupName="IsPreSale" Text="否" />
                    </td>
                    <td style="display: none">
                        <span style="display: none">项目所在区域
                        </span>
                    </td>
                    <td class="tl PL10" style="display: none"><span style="display: none">
                        <asp:TextBox ID="txtProjectArea" runat="server"></asp:TextBox>
                    </span></td>

                </tr>
                <tr>
                    <td>是否限购
                    </td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rbtIslimitBuy1" runat="server" GroupName="IslimitBuy" Text="是" />
                        <asp:RadioButton ID="rbtIslimitBuy2" runat="server" GroupName="IslimitBuy" Text="否" />
                    </td>
                    <td>是否限签
                    </td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rbtIslimitSign1" runat="server" GroupName="IslimitSign" Text="是" />
                        <asp:RadioButton ID="rbtIslimitSign2" runat="server" GroupName="IslimitSign" Text="否" />
                    </td>
                </tr>
                <%-- <tr>
                   <td>
                       统筹分佣比例
                   </td>
                    <td>
                        <asp:TextBox ID="txtOverallScale" runat="server" onchange="OverallScaleChange()"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="4" style="text-align: left; line-height: 20px; padding-left: 5px;">上一代理期：从<asp:TextBox ID="txtLastBeginDate" runat="server" Width="75px"></asp:TextBox>日至<asp:TextBox ID="txtLastEndDate" runat="server" Width="75px"></asp:TextBox>日，
                        成交宗数<asp:TextBox ID="txtLastSumNum" runat="server" Width="75px"></asp:TextBox>
                        成交额<asp:TextBox ID="txtTurnover" runat="server" Width="75px"></asp:TextBox>
                        成交业绩<asp:TextBox ID="txtLastResults" runat="server" Width="75px"></asp:TextBox><br />
                        累计总成交：从<asp:TextBox ID="txtCumulativeBeginDate" runat="server" Width="75px"></asp:TextBox>日至<asp:TextBox ID="txtCumulativeEndDate" runat="server" Width="75px"></asp:TextBox>日，
                        总成交宗数<asp:TextBox ID="txtCumulativeNum" runat="server" Width="60px"></asp:TextBox>
                        总成交额<asp:TextBox ID="txtSumTurnover" runat="server" Width="60px"></asp:TextBox>
                        总成交业绩<asp:TextBox ID="txtCumulativeResults" runat="server" Width="68px"></asp:TextBox>

                    </td>
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
                    <td>项目性质</td>
                    <td class="tl PL10" colspan="1">
                        <asp:RadioButton ID="rdbOneOrTwo1" runat="server" GroupName="OneOrTwo" Text="一手项目" />
                        <asp:RadioButton ID="rdbOneOrTwo2" runat="server" GroupName="OneOrTwo" Text="二手批量" />
                    </td>
                    <td class="tl PL10" colspan="2">
                        <asp:DropDownList ID="ddlDiskSource" runat="server" Width="150px">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="1">市内A盘</asp:ListItem>
                            <asp:ListItem Value="2">市外B盘</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>项目所在地</td>
                    <td class="tl PL10" colspan="3">
                        <asp:DropDownList ID="ddlProjectAddress" runat="server" Width="150px"></asp:DropDownList><span style="color: red">（项目所在地：按公司划分的地盘标准选择）</span></td>
                </tr>
                <tr>
                    <td>项目地址</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtProjectAddress" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>报数地址</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtReportAddress" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>发展商<br />
                        联系人</td>
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
                        <br />
                        预计单价<asp:TextBox ID="txtUnitPrice" runat="server" Width="150px"></asp:TextBox>元/平方米;货量总金额<asp:TextBox ID="txtTotalPrice" runat="server" Width="150px"></asp:TextBox>元
                    </td>
                </tr>
                <tr>
                    <td>我司是否与电商签约</td>
                    <td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbIsCoopWithECommerce1" runat="server" Text="1、是，与房友圈签约，客户现场支付" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtCoopWithE1" runat="server" Width="70px"></asp:TextBox>元团购费（A）抵楼价
                        <asp:TextBox ID="txtCoopWithE2" runat="server" Width="70px"></asp:TextBox>，协议约定房友圈支付我司电商佣
                        <asp:TextBox ID="txtCoopWithE3" runat="server" Width="70px"></asp:TextBox>元（B），扣除10%营运费用后我司实得
                        <asp:TextBox ID="txtCoopWithE4" runat="server" Width="70px"></asp:TextBox>元，电商佣比例（C）（系统设公式C=B/A）
                        <asp:TextBox ID="txtCoopWithE5" runat="server" Width="70px"></asp:TextBox>%；若C<90%必须上传发展商或电商的盖章文件说明原因。<br />
                        该项目
                        <asp:RadioButton ID="rdbFtoZ1" runat="server" GroupName="FtoZ" Text="由房友圈向发展商引入中原" />
                        <asp:RadioButton ID="rdbFtoZ2" runat="server" GroupName="FtoZ" Text="由中原向发展商引入房友圈" />；<br />
                        本申请是否已上传房友圈《项目合同审批表》：
                        <asp:RadioButton ID="rdbIsUploadF1" runat="server" GroupName="IsUploadF" Text="是" />
                        <asp:RadioButton ID="rdbIsUploadF2" runat="server" GroupName="IsUploadF" Text="否" />
                        （附上传资料清单）
                        
                        <br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce2" runat="server" Text="2、是，与其他电商签约，电商公司名称" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName" runat="server" Width="300px"></asp:TextBox>
                        <br />
                        <div id="dvECommerceReason" style="padding-top: 2px; width: 100%;">
                            <span>选择此电商的理由：</span>
                            <br />
                            <asp:TextBox ID="txtECommerceReason" runat="server" Width="300px" Height="60px" TextMode="MultiLine" Style="margin-top: 2px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce3" runat="server" Text="3、否，不需与电商签约，但客户需要在电商公司刷卡以获取买房优惠，电商公司名称" GroupName="CoopWithECommerce" />
                        <asp:TextBox ID="txtECommerceName2" runat="server" Width="300px"></asp:TextBox>
                        刷卡优惠<asp:TextBox ID="txtDiscountMoney" runat="server" Width="50px" Style="margin-top: 2px;"></asp:TextBox>元
                        <%--<br />--%>
                        <br />
                        <asp:RadioButton ID="rdbIsCoopWithECommerce4" runat="server" Text="4、否，整个项目没有任何电商参与" GroupName="CoopWithECommerce" /><br />
                    </td>
                </tr>

                <tr>
                    <td>是否与行家联合代理<br />
                        或轮流代理</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbJOrT1" runat="server" GroupName="JOrT" Text="与行家同场联合代理" /><br />
                        <asp:RadioButton ID="rdbJOrT2" runat="server" GroupName="JOrT" Text="与行家轮流代理，即代理期内中原独家代理，代理期之外由行家轮流代理" /><br />
                        <asp:RadioButton ID="rdbJOrT3" runat="server" GroupName="JOrT" Text="整个项目由中原独家代理，发展商没有委托除中原以外的任何代理行" OnCheckedChanged="rdbJOrT3_CheckedChanged" /><br />
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
                        <br />
                        固定收佣，合同代理费<asp:TextBox ID="txtOwnerCommFixScale" runat="server" Width="80px"></asp:TextBox>%，公布代理费（扣除合作费后实收）：<asp:TextBox ID="txtOwnerCommAgent" runat="server" Width="80px"></asp:TextBox>%<br />
                        变动收佣，其中<br />
                        <table id="tOwner" class='sample tc' width='100%' style="border: none;">
                            <tr id="trOwner1" style="border: none;">
                                <td style="border: none;">
                                    <input type="text" id="txtOwnerCommFloatSetNumberStart1" style="width: 50px" readonly="readonly" value="0" />至<input type="text" id="txtOwnerCommFloatSetNumberEnd1" style="width: 50px" />套/<input type="text" id="txtOwnerCommFloatMoneyStart1" style="width: 50px" readonly="readonly" value="0" />至<input type="text" id="txtOwnerCommFloatMoneyEnd1" style="width: 50px" />元销售额（套数及销售额二选一），<input type="text" id="txtOwnerCommFloatKind1" style="width: 80px" />（填写住宅/公寓/别墅等不同类型）合同代理费<input type="text" id="txtOwnerCommFloatScale1" style="width: 50px" />%，公布代理费<input type="text" id="txtOwnerCommPublishedScale1" style="width: 50px" />%</td>
                            </tr>
                            <%=SbHtml1.ToString()%>
                        </table>
                        佣金跳BAR方式：<asp:RadioButton ID="rdbOwnerCommJump1" runat="server" Text="全跳BAR" GroupName="OwnerCommJump" />
                        <asp:RadioButton ID="rdbOwnerCommJump2" runat="server" Text="分级跳BAR" GroupName="OwnerCommJump" /><br />
                        <asp:HiddenField ID="hdOwner" runat="server" />
                        <input type="button" id="btnAddRow1" value="添加新行" onclick="addRow1();" style="float: left; display: none" />
                        <input type="button" id="btnDeleteRow1" value="删除一行" onclick="deleteRow1();" style="float: left; display: none" /><br />
                        <br />

                        (2)客佣（如有）：<br />
                        <asp:TextBox ID="txtClientCommFixScale" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>

                        <div style="display: none;">
                            (2)客佣（如有）：（若要计算单套现金奖，合同代理费必须填写用来表示百分比的纯数字）
                            <br />
                            固定收佣，合同代理费%，公布代理费（扣除合作费后实收）：<asp:TextBox ID="txtClientCommAgent" runat="server" Width="80px"></asp:TextBox>%<br />
                            变动收佣，其中<br />
                            <table id="tClient" class='sample tc' width='100%' style="border: none;">
                                <tr id="trClient1" style="border: none;">
                                    <td style="border: none;">
                                        <input type="text" id="txtClientCommFloatSetNumberStart1" style="width: 50px" readonly="readonly" value="0" />至<input type="text" id="txtClientCommFloatSetNumberEnd1" style="width: 50px" />套/<input type="text" id="txtClientCommFloatMoneyStart1" style="width: 50px" readonly="readonly" value="0" />至<input type="text" id="txtClientCommFloatMoneyEnd1" style="width: 50px" />元销售额，合同代理费<input type="text" id="txtClientCommFloatScale1" style="width: 50px" />%，公布代理费<input type="text" id="txtClientCommPublishedScale1" style="width: 50px" />%</td>
                                </tr>
                                <%=SbHtml2.ToString()%>
                            </table>
                            佣金跳BAR方式：<asp:RadioButton ID="rdbClientCommJump1" runat="server" Text="全跳BAR" GroupName="ClientCommJump" Checked="True" />
                            <asp:RadioButton ID="rdbClientCommJump2" runat="server" Text="分级跳BAR" GroupName="ClientCommJump" /><br />
                            <asp:HiddenField ID="hdClient" runat="server" />
                            <input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style="float: left; display: none" />
                            <input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style="float: left; display: none" />
                        </div>
                        <br />
                        <br />

                        (3)电商佣：（若要计算单套现金奖，合同代理费必须填写用来表示百分比的纯数字）
                        <br />
                        固定收佣，合同代理费<asp:TextBox ID="txtEBComm" runat="server" Width="70px"></asp:TextBox>%，公布代理费（扣除电商费用及合作费后实收）：<asp:TextBox ID="txtEBCommAgent" runat="server" Width="70px"></asp:TextBox>%<br />
                        变动收佣，其中<br />
                        <table id="tEB" class='sample tc' width='100%' style="border: none;">
                            <tr id="trEB1" style="border: none;">
                                <td style="border: none;">
                                    <input type="text" id="txtEBCommFloatSetNumberStart1" style="width: 50px" readonly="readonly" value="0" />至<input type="text" id="txtEBCommFloatSetNumberEnd1" style="width: 50px" />套/<input type="text" id="txtEBCommFloatMoneyStart1" style="width: 50px" readonly="readonly" value="0" />至<input type="text" id="txtEBCommFloatMoneyEnd1" style="width: 50px" />元销售额（套数及销售额二选一），合同代理费<input type="text" id="txtEBCommFloatScale1" style="width: 50px" />%，公布代理费<input type="text" id="txtEBCommPublishedScale1" style="width: 50px" />%</td>
                            </tr>
                            <%=SbHtml3.ToString()%>
                        </table>
                        佣金跳BAR方式：<asp:RadioButton ID="rdbEBCommJump1" runat="server" Text="全跳BAR" GroupName="EBCommJump" />
                        <asp:RadioButton ID="rdbEBCommJump2" runat="server" Text="分级跳BAR" GroupName="EBCommJump" /><br />
                        <asp:HiddenField ID="hdEB" runat="server" />
                        <input type="button" id="btnAddRow3" value="添加新行" onclick="addRow3();" style="float: left; display: none" />
                        <input type="button" id="btnDeleteRow3" value="删除一行" onclick="deleteRow3();" style="float: left; display: none" /><br />
                        <br />
                        代理费其他情况<br />
                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" Style="overflow: auto;"></asp:TextBox>
                        <br />


                        单套现金奖：<br />
                        <div id="SingleRewardC1">
                            <asp:RadioButton ID="rdbHaveSingleReward1" runat="server" Text="有，此项目实收佣金比例≥3%" GroupName="HaveSingleReward" />
                            ，现金奖<asp:TextBox ID="txtRewardSignHave" runat="server" Width="90px"></asp:TextBox>元/套，
                        现金奖的可发放金额=每套净佣金*15%（以发展商奖金为上限），可发放金额分配比例为：营业员44%，主管15%，区经8%，副总监/总监（O/R）3%，公司30%；超过每套净佣金的15%部分及公司30%部分全数上缴公司，可计入员工业绩，但不计算员工佣金
                        </div>
                        <div id="SingleRewardC2">
                            <asp:RadioButton ID="rdbHaveSingleReward2" runat="server" Text="有，此项目实收佣金比例<2%" GroupName="HaveSingleReward" />，现金奖全数上缴公司，可计入员工业绩，但不计算员工佣金；
                        </div>
                        <div id="SingleRewardC3">
                            <asp:RadioButton ID="rdbHaveSingleReward3" runat="server" Text="无，此项目不设现金奖。" GroupName="HaveSingleReward" />
                        </div>
                        <div id="SingleRewardC4">
                            <asp:RadioButton ID="rdbHaveSingleReward4" runat="server" Text="其他情况" GroupName="HaveSingleReward" />
                        </div>
                        <div id="AnotherRewardC" style="display: none">
                            <asp:TextBox ID="txtAnotherRewardC" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                        </div>
                        <br />
                        现金奖的操作：<br />
                        （1）发展商支付现金奖的条件：<br />
                        <asp:TextBox ID="txtDeveloperConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
                        （2）区域派发现金奖给同事的条件：<br />
                        <asp:TextBox ID="txtAreaConditions" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
                        <span style="color: #FF0000;">（区域必须保证现金奖在无需退回给发展商的情况下再发放给同事，否则造成公司损失将由相关人员承担赔偿责任）</span><br />
                        <br />
                        <div>现金奖的发放方式：</div>
                        <asp:RadioButton ID="rdbPayRewardWay1" runat="server" Text="奖金由发展商划入公司帐户，随薪佣发放。" GroupName="PayRewardWay" /><br />
                        <asp:RadioButton ID="rdbPayRewardWay2" runat="server" Text="奖金由发展商直接支付现金，接收人必须是申请部门负责人。" GroupName="PayRewardWay" /><br />
                        现金奖是否需开具发票并由我司支付税费？
                        <asp:RadioButton ID="rdbIsMyPay1" runat="server" Text="是" GroupName="IsMyPay" />
                        <asp:RadioButton ID="rdbIsMyPay2" runat="server" Text="否" GroupName="IsMyPay" />
                        <asp:RadioButton ID="rdbIsMyPay3" runat="server" Text="其他情况" GroupName="IsMyPay" Visible="False" />
                        <div id="COtherCondtion" style="display: none">
                            <asp:TextBox ID="txtOtherCondtion" runat="server" Height="80px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                        </div>
                        <br />
                        区域是否已提交发展商奖金确认书？
                        <asp:RadioButton ID="rdbAreaComfirn1" runat="server" Text="是" GroupName="AreaComfirn" />
                        <asp:RadioButton ID="rdbAreaComfirn2" runat="server" Text="否" GroupName="AreaComfirn" />，
                        区域承诺在<asp:TextBox ID="txtReturnBackDate" runat="server"></asp:TextBox>前交回公司

                        <br />
                        <br />
                        代理合同约定的佣金支付条件<br />
                        <asp:TextBox ID="txtTermsOfContract" runat="server" TextMode="MultiLine" Width="98%" Rows="3" Style="overflow: auto;" MaxLength="123"></asp:TextBox>
                        <br />
                        重大问题的合同条款（如违约赔偿条款、接盘区域限制等）<br />
                        <asp:TextBox ID="txtTermsOfMajorIssues" runat="server" TextMode="MultiLine" Width="98%" Rows="3" Style="overflow: auto;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>代理期</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtAgentStartDate" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox ID="txtAgentEndDate" runat="server" Width="80px"></asp:TextBox></td>
                    <td>客户保护期（非必填项）</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtClientGuardStartDate" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox ID="txtClientGuardEndDate" runat="server" Width="80px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>代理合同名称：</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtACName" runat="server" Width="300px"></asp:TextBox></td>
                </tr>
                <tr style="display: none">
                    <td colspan="4" class="tl PL10">
                        <table style="width: 95%; margin: 10px auto;">
                            <tr>
                                <th colspan="7" style="line-height: 25px;">结佣条件</th>
                            </tr>
                            <tr>
                                <td colspan="3" style="font-weight: bold;">签认购书</td>
                                <td>结佣比例：</td>
                                <td>
                                    <asp:TextBox ID="txtQRCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td>最后期限：</td>
                                <td>
                                    <asp:TextBox ID="txtQRDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td colspan="7" style="font-weight: bold;">签买卖合同</td>
                            </tr>
                            <tr>
                                <td colspan="3" style="font-weight: bold;">一次付款</td>
                                <td>结佣比例：</td>
                                <td>
                                    <asp:TextBox ID="txtYCCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td>最后期限：</td>
                                <td>
                                    <asp:TextBox ID="txtYCDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" style="font-weight: bold;">分期付款</td>
                            </tr>
                            <tr>
                                <td class="tl PL10">
                                    <asp:DropDownList ID="dllHirePurchase" runat="server" Width="130px" Height="20px">
                                        <asp:ListItem Value="0">请选择</asp:ListItem>
                                        <asp:ListItem Value="1">付清首期</asp:ListItem>
                                        <asp:ListItem Value="2">按实际支付比例</asp:ListItem>
                                        <asp:ListItem Value="3">按约定支付比例</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td colspan="2">支付比例：<asp:TextBox ID="txtZFRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtFQCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtFQDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td colspan="3">当支付房款达总房款<asp:TextBox ID="txtHousingFund" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">时结算：<asp:TextBox ID="txtHour" Width="70" runat="server"></asp:TextBox>%佣金</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtHousDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" style="font-weight: bold;">按揭付款</td>
                            </tr>
                            <tr>
                                <td colspan="2">首期款
                                    <asp:DropDownList ID="ddlDownpayment" runat="server" Width="130px" Height="20px">
                                        <asp:ListItem Value="0">请选择</asp:ListItem>
                                        <asp:ListItem Value="1">首期付清</asp:ListItem>
                                        <asp:ListItem Value="2">按实际支付比例</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>首付比例：<asp:TextBox ID="txtSFRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtSFCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtSFDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td colspan="2">放  款
                                    <asp:DropDownList ID="ddlLoan" runat="server" Width="130px" Height="20px">
                                        <asp:ListItem Value="0">请选择</asp:ListItem>
                                        <asp:ListItem Value="1">放完全款</asp:ListItem>
                                        <asp:ListItem Value="2">按实际放款比例</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>放款比例：<asp:TextBox ID="txtLoanRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtFKCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtFKDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr class="AJ1">
                                <td colspan="3">按揭资料提交</td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtAJ1CommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtAJ1Deadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr class="AJ2">
                                <td colspan="3">按揭资料审批</td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtAJ2CommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtAJ2Deadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr class="AJ3">
                                <td colspan="3">按揭合同签订</td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtAJ3CommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtAJ3Deadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr class="BA">
                                <td colspan="3">网上备案</td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtBACommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtBADeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr class="YH">
                                <td colspan="3">银行出同贷书</td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtYHCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtYHDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td>入伙</td>
                                <td colspan="3">结佣比例：<asp:TextBox ID="txtRHCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="3">最后期限：<asp:TextBox ID="txtRHDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td>售罄</td>
                                <td colspan="3">结佣比例：<asp:TextBox ID="txtSXCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="3">最后期限：<asp:TextBox ID="txtSXDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td>代理结束</td>
                                <td colspan="3">结佣比例：<asp:TextBox ID="txtDLCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="3">最后期限：<asp:TextBox ID="txtDLDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td colspan="7" style="color: red; font-weight: bold;">附加说明</td>
                            </tr>
                            <tr>
                                <td colspan="3">保证金结佣依据：<asp:DropDownList ID="ddlEvidence" runat="server" Width="130px" Height="20px">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">放款</asp:ListItem>
                                    <asp:ListItem Value="2">全款</asp:ListItem>
                                    <asp:ListItem Value="3">分期款</asp:ListItem>
                                    <asp:ListItem Value="4">签订买卖合同</asp:ListItem>
                                    <asp:ListItem Value="5">入伙</asp:ListItem>
                                    <asp:ListItem Value="6">售罄</asp:ListItem>
                                    <asp:ListItem Value="7">代理结束</asp:ListItem>
                                </asp:DropDownList></td>
                                <td colspan="2">结佣比例：<asp:TextBox ID="txtYJCommissionRatio" Width="70" runat="server"></asp:TextBox>%</td>
                                <td colspan="2">最后期限：<asp:TextBox ID="txtYJDeadlines" Width="70" runat="server"></asp:TextBox>天</td>
                            </tr>
                            <tr>
                                <td colspan="7">预留方式：
                                    <asp:DropDownList ID="ddlReserve" runat="server" Width="100px" Height="20px">
                                        <asp:ListItem Value="1">最后预留</asp:ListItem>
                                        <asp:ListItem Value="2">每笔预留</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>预估代理期<br />
                        内完成</td>
                    <td colspan="3" class="tl PL10">货量<asp:TextBox ID="txtPreCompleteNumber" runat="server" Width="50px"></asp:TextBox>套，货量金额<asp:TextBox ID="txtPreCompleteMoney" runat="server" Width="100px"></asp:TextBox>元，佣金收入<asp:TextBox ID="txtPreCompleteComm" runat="server" Width="100px"></asp:TextBox>元</td>
                </tr>
                <tr id="EarnMoney" style="display: none">
                    <td>应收账龄</td>
                    <td colspan="3" class="tl PL10" style="font-size: large">物业部的应收总佣金<asp:Label ID="lbN1" runat="server"></asp:Label>元，项目部的应收总佣金<asp:Label ID="lbW1" runat="server"></asp:Label>元<br />
                        欠佣期（含成交月）3个月内的佣金：物业部<asp:Label ID="lbN2" runat="server"></asp:Label>元，项目部<asp:Label ID="lbW2" runat="server"></asp:Label>元。
                        截止日期：<asp:Label ID="lbEndDate1" runat="server"></asp:Label><br />
                        已自动坏账的欠佣期一年以上的佣金：物业部<asp:Label ID="lbC1" runat="server"></asp:Label>元，项目部<asp:Label ID="lbW3" runat="server"></asp:Label>元。
                        截止日期：<asp:Label ID="lbEndDate2" runat="server"></asp:Label><br />
                        物业部欠必要性文件坏账的应收总佣金<asp:Label ID="lbD1" runat="server"></asp:Label>元，项目部欠必要性文件坏账的应收总佣金<asp:Label ID="lbD2" runat="server"></asp:Label>元。
                        截止日期：<asp:Label ID="lbEndDate3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="CouldFlange" style="display: none">
                    <td>曾申请接盘此项目的<br />
                        其它部门</td>
                    <td colspan="3" class="tl PL10" style="font-size: large">
                        <asp:Label ID="lbFlange" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>项目是否有欠佣</td>
                    <td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbIsProjEarlyCommBack1" runat="server" Text="是" GroupName="ProjEarlyComm" /><label for="r2d2b2">，项目欠佣金额<asp:TextBox ID="txtOweCommSum" runat="server" Width="80px"></asp:TextBox>
                            元，欠佣原因：<br />
                            <asp:TextBox ID="txtAreaReason" runat="server" Width="96%" TextMode="MultiLine"></asp:TextBox>，<br />
                            承诺收回欠佣时间<asp:TextBox ID="txtGuaranTime" runat="server"></asp:TextBox>
                            原接盘部门欠佣金额<asp:TextBox ID="txtOrdMoney" runat="server" Width="100px"></asp:TextBox>元，由原接盘部门
                        <asp:TextBox ID="txtOrdTaker" runat="server" Width="160px"></asp:TextBox>负责人负责追收 
                        </label>
                        <br />

                        <asp:RadioButton ID="rdbIsProjEarlyCommBack2" runat="server" Text="否，欠佣已全部收回" GroupName="ProjEarlyComm" /><br />
                    </td>
                </tr>


                <tr>
                    <td>行家代理信息</td>
                    <td colspan="3" class="tl PL10">
                        <div>若项目与行家同场联合代理或与轮流代理，以下为必填项，若因无渠道了解相关信息无法填写，敬请注明“无渠道了解相关信息”。</div>
                        <br />
                        1.名称：<asp:TextBox ID="txtSamePlaceXX1" runat="server" Width="200px"></asp:TextBox>
                        代理费：<asp:TextBox ID="txtAgencyFee1" runat="server" Width="200px"></asp:TextBox><br />
                        现金奖：<asp:RadioButton ID="rdbIsCashPrize11" runat="server" Text="有，" GroupName="CashPrize1" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize1" runat="server" Width="200px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize12" runat="server" Text="无" GroupName="CashPrize1" /><br />
                        项目费用：<asp:RadioButton ID="rdbIsPFear11" runat="server" Text="有，比例" GroupName="IsPFear1" />
                        <label for="r2d2b2">
                            <asp:TextBox ID="txtPFear1" runat="server" Width="200px"></asp:TextBox></label>
                        <asp:RadioButton ID="rdbIsPFear12" runat="server" Text="无" GroupName="IsPFear1" /><br />
                        2.名称：<asp:TextBox ID="txtSamePlaceXX2" runat="server" Width="200px"></asp:TextBox>
                        代理费：<asp:TextBox ID="txtAgencyFee2" runat="server" Width="200px"></asp:TextBox><br />
                        <label for="r2d2b2"></label>
                        现金奖：<asp:RadioButton ID="rdbIsCashPrize21" runat="server" Text="有，" GroupName="CashPrize2" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize2" runat="server" Width="200px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize22" runat="server" Text="无" GroupName="CashPrize2" /><br />
                        项目费用：<asp:RadioButton ID="rdbIsPFear21" runat="server" Text="有，比例" GroupName="IsPFear2" />
                        <label for="r2d2b2">
                            <asp:TextBox ID="txtPFear2" runat="server" Width="200px"></asp:TextBox></label>
                        <asp:RadioButton ID="rdbIsPFear22" runat="server" Text="无" GroupName="IsPFear2" /><br />
                    </td>
                </tr>

                <tr>
                    <td>申请部门接盘模式</td>
                    <td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbSaleMode1" runat="server" Text="独立接盘，" GroupName="SaleMode" Checked="true" /><label for="r2d2b2">统筹区<asp:TextBox ID="txtAreaScale1" runat="server" Width="110px" Enabled="true"></asp:TextBox>拆分成交的<asp:TextBox ID="txtMainAreaScale" runat="server" Width="50px"></asp:TextBox>%， 成交区占<asp:TextBox ID="txtDealAreaScale" runat="server" Width="50px"></asp:TextBox>%</label>
                        <br />
                        （成交区拆分不得少于85%）
                        <div id="divSaleMode2" style="margin-top: 10px; margin-bottom: 10px;">
                            <asp:RadioButton ID="rdbSaleMode2" runat="server" Text="两区合作接盘，统筹区" GroupName="SaleMode" Height="30px" />
                            <label for="r2d2b2">
                                <asp:TextBox ID="txtAreaScale" runat="server" Width="60%" Height="40px" Enabled="false" TextMode="MultiLine"></asp:TextBox>，
                                拆分成交的<asp:TextBox ID="txtMainAreaScale2" runat="server" Width="50px"></asp:TextBox>
                                %，合作区<asp:TextBox ID="txtAS2" runat="server" Width="60%" Height="40px" TextMode="MultiLine"></asp:TextBox>，
                                拆分成交的<asp:TextBox ID="txtMS2" runat="server" Width="50px"></asp:TextBox>
                                %（统筹区+合作区拆分相加不得超过15%），成交区拆分成交的
                                <asp:TextBox ID="txtDealAreaScale2" runat="server" Width="50px"></asp:TextBox>%（成交区拆分不得少于85%）
                            </label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>广州中原<br />
                        与其他分公司合作</td>
                    <td colspan="3" class="tl PL10">1、合作公司：
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
                <%--           <tr>
                    <th colspan="4" style="line-height:25px;" >统筹分佣比例</th>
				</tr>
             <tr>
                    <td colspan="4">
                          <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                            <td>开始时间</td>
                                            <td>结束时间</td>
                                              <td>工号</td>
                                            <td>姓名</td>
                                            <td>组别</td>
                                            <td>比例</td>
                                           
                                          
                                        </tr>
                                        <tbody id="jzqk">
                                            <tr>
                                                 <td><input type="text" style="width:69px" name="BeginDate" emptymes="请填写开始时间" dateplugin="datepicker"onchange="checkBeginDate(this)" /></td>
                                                <td><input type="text" style="width:69px" name="EndDate" emptymes="请填写结束时间" dateplugin="datepicker" /></td>
                                              
                                                <td><input type="text" style="width:80px" name="EmployeeID" emptymes="请填写工号" onblur="getEmployee(this)"/></td>
                                                <td><input type="text" style="width:100px; background-color:#E0E0E0" name="EmployeeName" readonly="readonly" emptymes="请填姓名"/></td>
                                                <td><input type="text" style="width:80px; background-color:#E0E0E0" name="UnitName"  readonly="readonly" emptymes="请填写组别"/></td>
                                                 <td><input type="text" style="width:90px" name="Scale" emptymes="请填写比例(%)" onchange="checkScale(this)"/></td>
                                                
                                            </tr>
                                        </tbody>
                                       
                                        <tr>
                                            <td style="text-align:left" colspan="7"><input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk', null)" /><input class="btnaddRowN" type="button" onclick="delrow(this, 'jzqk')" value="删除一行" />

                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidDetail" runat="server" />
                           <asp:button runat="server" id="btnSave1" text="保存"  OnClick="btnSave1_Click" Visible="false"   OnClientClick=" return check1()"/>
                    </td>
                 
                </tr>--%>
                <tr>
                    <th colspan="4" style="line-height: 25px;">审批流程</th>
                </tr>
                <tr class="noborder" style="height: 85px;" runat="server" id="trYesIDx1">
                    <%--style="border: 1px solid #000000;"--%>
                    <td>申请人</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">其他意见</label>
                        <span id="sp001" style="display: none;">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbFYQ_Click" OnClientClick="return confirm('确定要添加黄蕙晶审批？')">添加黄蕙晶审批</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lbCancelFYQ_Click" OnClientClick="return confirm('确定要取消黄蕙晶审批？')">取消黄蕙晶审批</asp:LinkButton>
                        </span>
                        <br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />

                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td>物业部区域负责人意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="OrdinaryC" class="noborder" style="height: 85px; display: none;">
                    <td>原接盘部门负责人意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <div style="display: none">
                            <input id="rdbYesIDx3" type="radio" name="agree3" checked="checked" /><label for="rdbYesIDx3">同意</label>
                        </div>
                        <textarea id="txtIDx3" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td>应收款管理组意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label>
                        <input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        结佣条件：<br />
                        <div style="float: right">一次性付款：前佣<input id="txtOneFront" runat="server" type="text" style="width: 217px" />后佣<input id="txtOneAfter" type="text" runat="server" style="width: 217px" /></div>
                        <div style="float: right">按揭：前佣<input id="txtTurnFront" runat="server" type="text" style="width: 217px" />后佣<input id="txtTurnAfter" type="text" runat="server" style="width: 217px" /></div>
                        <br />
                        <asp:Button runat="server" CssClass="finSignBtn" ID="bFinSige" OnClick="btnComm_Click" Text="确认" OnClientClick="return checkAduit()" Visible="false" />
                        <textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签名" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx8">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px; display: none;" id="tr14">
                    <td>房友圈意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx14" type="radio" name="agree14" /><label for="rdbYesIDx14">同意</label>
                        <input id="rdbNoIDx14" type="radio" name="agree14" /><label for="rdbNoIDx14">不同意</label>
                        <input id="rdbOtherIDx14" type="radio" name="agree14" /><label for="rdbOtherIDx14">其他意见</label><br />
                        <textarea id="txtIDx14" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx14" value="签名" onclick="sign('14')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx14">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td id="tdLaw4">法律部意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx15" type="radio" name="agree15" /><label for="rdbYesIDx15">同意</label>
                        <input id="rdbNoIDx15" type="radio" name="agree15" /><label for="rdbNoIDx15">不同意</label>
                        <input id="rdbOtherIDx15" type="radio" name="agree15" /><label for="rdbOtherIDx15">其他意见</label>
                        <span id="sp005" style="display: none;">
                            <asp:LinkButton ID="lbFYQ" runat="server" OnClick="lbFYQ_Click" OnClientClick="return confirm('确定要添加黄蕙晶审批？')">添加黄蕙晶审批</asp:LinkButton>
                            <asp:LinkButton ID="lbCancelFYQ" runat="server" OnClick="lbCancelFYQ_Click" OnClientClick="return confirm('确定要取消黄蕙晶批？')">取消黄蕙晶审批</asp:LinkButton>
                            <%--<asp:LinkButton ID="lbOCDeptm" runat="server" OnClick="lbOCDeptm_Click">添加陈洁丽审批</asp:LinkButton>--%>
                        </span>
                        <br />
                        <textarea id="txtIDx15" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx15" value="签署意见" onclick="sign('15')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx15">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trLaw5" class="noborder" style="height: 85px; display: none;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx16" type="radio" name="agree16" /><label for="rdbYesIDx16">同意</label>
                        <input id="rdbNoIDx16" type="radio" name="agree16" /><label for="rdbNoIDx16">不同意</label>
                        <input id="rdbOtherIDx16" type="radio" name="agree16" /><label for="rdbOtherIDx16">其他意见</label>
                        <span id="sp006" style="display: none;">
                            <%--<asp:LinkButton ID="lbtnAddMaster" runat="server" OnClick="lbtnAddMaster_Click">添加黄生审批</asp:LinkButton>--%>
                        </span>
                        <br />
                        <textarea id="txtIDx16" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx16" value="签署意见" onclick="sign('16')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx16">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trGeneralManager" class="noborder" style="height: 85px; display: none;">
                    <td>董事总经理<br />
                        审批</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx17" type="radio" name="agree17" /><label for="rdbYesIDx17">同意</label>
                        <input id="rdbNoIDx17" type="radio" name="agree17" /><label for="rdbNoIDx17">不同意</label>
                        <input id="rdbOtherIDx17" type="radio" name="agree17" /><label for="rdbOtherIDx17">其他意见</label><br />
                        <textarea id="txtIDx17" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx17" value="签署意见" onclick="sign('17')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx17">_________</span>
                        </span>
                    </td>
                </tr>


                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
                    <td>区域回复审批意见<br />
                        （可选项）</td>
                    <td colspan="3" class="tl PL10" style="">
                        <textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx200">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF4" class="noborder" style="height: 85px; display: none;">
                    <td>原接盘部门负责人<br />
                        回复意见（可选项）</td>
                    <td colspan="3" class="tl PL10" style="">
                        <textarea id="txtIDx205" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx205" runat="server" OnClick="btnSignIDx205_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx205">_________</span></div>
                    </td>
                </tr>
                <tr id="trAddAnoF2" class="noborder" style="height: 85px; display: none;">
                    <td rowspan="2">法律部复审<br />
                        <asp:Button ID="btnShouldJumpIDx" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
                    </td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb210a1" runat="server" Text="同意" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a2" runat="server" Text="不同意" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a3" runat="server" Text="其它意见" GroupName="210a" ForeColor="#008162" />
                        <textarea id="txtIDx210" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx210" runat="server" OnClick="btnSignIDx210_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx210">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF5" class="noborder" style="height: 85px; display: none;">
                    <%-- <td id="trf5" style="display:none;">
                        法律部复审<br />
                        <asp:Button ID="Button1" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
					</td>--%>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:Button ID="Button2" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
                        <asp:RadioButton ID="rdb211a1" runat="server" Text="同意" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a2" runat="server" Text="不同意" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a3" runat="server" Text="其它意见" GroupName="211a" ForeColor="#008162" />
                        <textarea id="txtIDx211" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx211" runat="server" OnClick="btnSignIDx211_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx211">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
                    <td>董事总经理复审</td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#186ebe" />
                        <textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx220">_________</span>
                        </span>
                    </td>
                </tr>

            </table>
            <table id="tbAround2" width="720px">
                <thead>
                    <tr>
                        <td style="font-weight: bold; text-align: left; padding-left: 10px;" colspan="2">已上传资料：</td>
                    </tr>
                </thead>
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
                        <asp:CheckBox ID="cbLack7" runat="server" Text="房友圈《项目合同审批表》" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;" colspan="2">
                        <asp:CheckBox ID="cbLack6" runat="server" Text="其他资料" /><br />
                        <asp:TextBox ID="txtLack6" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="width: 640px; margin: 0 auto;">
                <span class="tl" style="float: left;">备注：1物业部承接一手项目/一手货尾盘，需上此报备申请表。<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2物业部承接二手物业达20套或以上的属批量项目，需上此报备申请表。</span>
            </div>
            <!--打印正文结束-->
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
            </asp:GridView>
            <div id="PageBottom">
                <span id="spm"></span>
                <br />
                <hr />

                <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnTemp" Text="暂时保存" OnClick="btnTempSave_Click" CssClass="commonbtn" OnClientClick="return tempsavecheck();" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
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
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        $("#<%=rdbSaleMode2.ClientID %>").attr("disabled","disabled")
        $("#<%=txtAreaScale.ClientID %>").attr("disabled","disabled")
        $("#<%=txtMainAreaScale2.ClientID %>").attr("disabled","disabled")
        $("#<%=txtAS2.ClientID %>").attr("disabled","disabled")
        $("#<%=txtMS2.ClientID %>").attr("disabled","disabled")
        $("#<%=txtDealAreaScale2.ClientID %>").attr("disabled","disabled")
        //debugger;
        //因总办要求隐藏申请部门接盘，而以前记录上申请有第二个点
        //if ($("#<%=lblApplyDate.ClientID %>").html().trim() < '2018-05-13') 
        //由于在ie中，.trim()方法会报 对象不支持“trim”属性或方法 错误，所以现在用jquery自带的方法 $.trim() 去替换
        var applyDate = $("#<%=lblApplyDate.ClientID %>").html();
        if ($.trim(applyDate) < '2018-05-13')
        {
            $("#divSaleMode2").show();
        }
        else { $("#divSaleMode2").hide() }
    </script>
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
</asp:Content>
