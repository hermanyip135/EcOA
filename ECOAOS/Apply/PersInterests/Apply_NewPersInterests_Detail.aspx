<%@ Page ValidateRequest="false" Title="员工个人利益申报表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_NewPersInterests_Detail.aspx.cs" Inherits="Apply_NewPersInterests_Apply_NewPersInterests_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        /*.trgray1 {
            background-color:Silver;
        }
        .trgray2 {
            background-color:Silver;
        }
        .trgray3 {
            background-color:Silver;
        }
        .trgray4 {
            background-color:Silver;
        }
        .trgray5 {
            background-color:Silver;
        }*/
        
        /*#tbDetail tr td{
            background-color:Silver;
        }*/
       
        
    </style>


    <script type="text/javascript" src="../../Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;

        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }
        
        var jJSON = <%=SbJson.ToString() %>;
        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
        
        $(function() {      
            $("[id*=btnsSignIDx]").css({
                "background-image": "url(../../Images/btnSureS1.png)",
                "height": "25px", 
                "width": "43px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnsSignIDx]").mousedown(function () { $(this).css("background-image", "url(../../Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(../../Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(../../Images/btnSureS1.png)"); });

            i = $("#tbDetail tr").length - 1;
            $("#<%=txtTfid2.ClientID %>").autocomplete({source: jJSON});
            $("#<%=txtFollowerDepartment.ClientID %>").autocomplete({source: jJSON});

            $("#<%=txtApplyForDate.ClientID %>").datepicker();

            for (var x = 1; x < i; x++) {
                $("#txtDetail_InDepartment"+ x).autocomplete({source: jJSON});
            }

            //for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
            //    $("#txtCountOffTime" + x).datepicker();
            //}
            $("label[for*=rdbFollowWay1]").css("color", "#0d9405");
            $("label[for*=rdbPayWay1]").css("color", "#0d9405");
            $("#<%=txtApplyForID.ClientID %>").blur();
            $("#<%=txtFollowerNo.ClientID %>").blur();
            $("#<%=txtEntrustNo.ClientID %>").blur();
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应

            if($("#<%=cbApplyContent1.ClientID%>").prop('checked'))
            {
                changeselect(1);
            }
            if($("#<%=cbApplyContent2.ClientID%>").prop('checked'))
            {
                changeselect(2);
            }
            if($("#<%=cbApplyContent3.ClientID%>").prop('checked'))
            {
                changeselect(3);
            }
            if($("#<%=cbApplyContent4.ClientID%>").prop('checked'))
            {
                changeselect(4);
            }
            if($("#<%=cbApplyContent5.ClientID%>").prop('checked'))
            {
                changeselect(5);
            }

            //$(".trgray1 input").attr("disabled","disabled");
            //$(".trgray2 input").attr("disabled","disabled");
            //$(".trgray3 input").attr("disabled","disabled");
            //$(".trgray4 input").attr("disabled","disabled");
            //$(".trgray5 input").attr("disabled","disabled");

            $("#<%=cbApplyContent1.ClientID%>").click(function(){
                $("#<%=cbApplyContent2.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent3.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent4.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent5.ClientID%>").removeAttr("checked");
                changeselect(1);
                select($(this),1);
                
            });

            $("#<%=cbApplyContent2.ClientID%>").click(function(){
                $("#<%=cbApplyContent1.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent3.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent4.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent5.ClientID%>").removeAttr("checked");
                changeselect(2);
                select($(this),2);
            });

            $("#<%=cbApplyContent3.ClientID%>").click(function(){
                $("#<%=cbApplyContent1.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent2.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent4.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent5.ClientID%>").removeAttr("checked");
                changeselect(3)
                select($(this),3);
            });

            $("#<%=cbApplyContent4.ClientID%>").click(function(){
                $("#<%=cbApplyContent1.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent2.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent3.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent5.ClientID%>").removeAttr("checked");
                changeselect(4)
                select($(this),4);
            });

            $("#<%=cbApplyContent5.ClientID%>").click(function(){
                $("#<%=cbApplyContent1.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent2.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent3.ClientID%>").removeAttr("checked");
                $("#<%=cbApplyContent4.ClientID%>").removeAttr("checked");
                changeselect(5);
                select($(this),5);
            });
        });

        

        function select(t,v)
        {

            if(t.is(":checked")==true)
            {
                if(v==2)
                {
                    $("#tbDetail tr td").css("background","");
                }
                $(".trgray"+v).css("background","");
                $(".trgray"+v+" input").removeAttr("disabled");
            }else
            {
                if(v==2)
                {
                    $("#tbDetail tr td").css("background","Silver");
                }
                $(".trgray"+v).css("background","Silver");
                $(".trgray"+v+" input").attr("disabled","disabled");
                $(".trgray"+v+" input[type=text]").val("");
                $(".trgray"+v+" input").attr("checked",false);
            }
        }

        function changeselect(v)
        {
            if(v==2)
            {
                $("#tbDetail tr td").css("background","");
            }
            else
            {
                $("#tbDetail tr td").css("background","Silver");
            }

            for(var i=1;i<=5;i++)
            {
                if(v==i)
                {
                    $(".trgray"+i).css("background","");
                    $(".trgray"+i+" input").removeAttr("disabled");
                    
                }else
                {
                    $(".trgray"+i).css("background","Silver");
                    $(".trgray"+i+" input").attr("disabled","disabled");
                    $(".trgray"+i+" input[type=text]").val("");
                    //$(".trgray"+i+" input").attr("checked",false);
                    $(".trgray"+i+" input").get(0).checked = false;
                }
            }
        }




        function check() {
            if($("#<%=ddlDepartmentType.ClientID%>").val() == "") {
                alert("部门性质必须选择。");
                $("#<%=ddlDepartmentType.ClientID%>").focus();
                return false;
            }
            else
                $("#<%=hdDepartmentType.ClientID%>").val($("#<%=ddlDepartmentType.ClientID%>").val());
            
            if($.trim($("#<%=txtTfid2.ClientID %>").val())=="") {
                alert("部门名称（分行/组别）不可为空。");
                $("#<%=txtTfid2.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApplyFor.ClientID %>").val())=="") {
                alert("请填写正确的申请人工号。");
                $("#<%=txtApplyForID.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
                alert("联系电话不可为空。");
                $("#<%=txtPhone.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtApplyForDate.ClientID %>").val())=="") {
                alert("申请日期不可为空。");
                $("#<%=txtApplyForDate.ClientID %>").focus();
                return false;
            }

            if($("#<%=ddlInterestsType.ClientID%>").val() == "") {
                alert("利益申报类别必须选择。");
                $("#<%=ddlInterestsType.ClientID%>").focus();
                return false;
            }
            else {
                $("#<%=hdInterestsType.ClientID%>").val($("#<%=ddlInterestsType.ClientID%>").val());
                if($("#<%=ddlInterestsType.ClientID%>").val() == "7")
                {
                    if($("#<%=rdbDealProperty2.ClientID%>").prop("checked")){
                        if($("#<%=txtApplyForID.ClientID%>").val()==$("#<%=txtFollowerNo.ClientID%>").val()){
                            alert("1-3级营业人员作为交易客户的情况下，交易不能由个人作为跟进的营业员促成交易，即申请人与跟进人不能为同一人，请作调整。");
                            $("#<%=txtFollowerNo.ClientID%>").focus();
                            return false;
                        }
                }
              }
            }
                



            if (
                   !$("#<%=cbApplyContent1.ClientID %>").prop("checked") 
                    && !$("#<%=cbApplyContent2.ClientID %>").prop("checked") 
                    && !$("#<%=cbApplyContent3.ClientID %>").prop("checked")
                    && !$("#<%=cbApplyContent4.ClientID %>").prop("checked")
                    && !$("#<%=cbApplyContent5.ClientID %>").prop("checked")
               ) 
             {
                 alert("必须勾选一种类别！");
                 $("#<%=cbApplyContent1.ClientID%>").focus();
                return false;
            }





            if($("#<%=cbApplyContent1.ClientID%>").prop("checked") || $("#<%=ddlInterestsType.ClientID%>").val() == "1") {
                if($.trim($("#<%=txtFollower.ClientID %>").val())=="") {
                    alert("请填写正确的跟进人工号。");
                    $("#<%=txtFollowerNo.ClientID %>").focus();
                    return false;
                }
                //if(!$("#<%=rdbDealKind1.ClientID%>").prop("checked") && !$("#<%=rdbDealKind2.ClientID%>").prop("checked") && !$("<%=rdbDealKind3.ClientID%>").prop("checked") && !$("<%=rdbDealKind4.ClientID%>").prop("checked")){
                if(!$("#<%=rdbDealKind1.ClientID%>").get(0).checked && !$("#<%=rdbDealKind2.ClientID%>").get(0).checked && !$("<%=rdbDealKind3.ClientID%>").get(0).checked && !$("<%=rdbDealKind4.ClientID%>").get(0).checked){
                    alert("请选择交易类型。");
                    $("#<%=rdbDealKind1.ClientID %>").focus();
                    return false;
                }
                if(!$("#<%=rdbDealProperty1.ClientID%>").prop("checked") && !$("#<%=rdbDealProperty2.ClientID%>").prop("checked")){
                    alert("请选择交易物业。");
                    $("#<%=rdbDealProperty1.ClientID %>").focus();
                    return false;
                }
                if(!$("#<%=rdbPropertyHander1.ClientID%>").prop("checked") && !$("#<%=rdbPropertyHander2.ClientID%>").prop("checked") && !$("#<%=rdbPropertyHander3.ClientID%>").prop("checked")){
                    alert("请选择业权人。");
                    $("#<%=rdbPropertyHander1.ClientID %>").focus();
                    return false;
                }
                if($("#<%=rdbPropertyHander2.ClientID%>").prop("checked")){
                    if($.trim($("#<%=txtMeAndHim.ClientID %>").val())=="") {
                        alert("本人及联名人不可为空。");
                        $("#<%=txtMeAndHim.ClientID %>").focus();
                    return false;
                    }
                }
                if($("#<%=rdbPropertyHander3.ClientID%>").prop("checked")){
                    if($.trim($("#<%=txtRelationship.ClientID %>").val())=="") {
                        alert("直系亲属关系不可为空。");
                        $("#<%=txtRelationship.ClientID %>").focus();
                        return false;
                    }
                    if($.trim($("#<%=txtRelationName.ClientID %>").val())=="") {
                        alert("直系亲属姓名不可为空。");
                        $("#<%=txtRelationName.ClientID %>").focus();
                        return false;
                    }
                }
                if($.trim($("#<%=txtBuilding.ClientID %>").val())=="") {
                    alert("物业地址不可为空。");
                    $("#<%=txtBuilding.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtSquare.ClientID %>").val())=="") {
                    alert("面积不可为空。");
                    $("#<%=txtSquare.ClientID %>").focus();
                    return false;
                }
                <%--20170531注释，朱晓晴提的需求，这几项为非必填项--%>
               <%-- if($.trim($("#<%=txtPriceScope.ClientID %>").val())=="") {
                    alert("价格范围不可为空。");
                    $("#<%=txtPriceScope.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtLeaseTerm.ClientID %>").val())=="") {
                    alert("租赁期限不可为空。");
                    $("#<%=txtLeaseTerm.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtRequirements.ClientID %>").val())=="") {
                    alert("其它特别要求不可为空。");
                    $("#<%=txtRequirements.ClientID %>").focus();
                    return false;
                }
                if(!$("#<%=rdbPayWay1.ClientID%>").prop("checked") && !$("#<%=rdbPayWay2.ClientID%>").prop("checked")){
                    alert("请选择付款方式。");
                    $("#<%=rdbPayWay1.ClientID %>").focus();
                    return false;
                }
                if(!$("#<%=rdbFollowWay1.ClientID%>").prop("checked") && !$("#<%=rdbFollowWay2.ClientID%>").prop("checked")){
                    alert("请选择跟进方式。");
                    $("#<%=rdbFollowWay1.ClientID %>").focus();
                    return false;
                }--%>
            }
            if($("#<%=cbApplyContent3.ClientID%>").prop("checked")) {
                if(!$("#<%=rdbApplySomething1.ClientID%>").prop("checked") && !$("#<%=rdbApplySomething2.ClientID%>").prop("checked") && !$("#<%=rdbApplySomething3.ClientID%>").prop("checked")){
                    alert("请选择申请事项。");
                    $("#<%=rdbApplySomething1.ClientID %>").focus();
                    return false;
                }
                if($("#<%=rdbApplySomething1.ClientID%>").prop("checked")){
                    if($.trim($("#<%=txtGiftName.ClientID %>").val())=="") {
                        alert("礼物/赠品名称不可为空。");
                        $("#<%=txtGiftName.ClientID %>").focus();
                        return false;
                    }
                    if($.trim($("#<%=txtGiftPrice.ClientID %>").val())=="") {
                        alert("礼物/赠品价值不可为空。");
                        $("#<%=txtGiftPrice.ClientID %>").focus();
                        return false;
                    }
                }
                if($("#<%=rdbApplySomething2.ClientID%>").prop("checked")){
                    if($.trim($("#<%=txtCrashOrCard.ClientID %>").val())=="") {
                        alert("现金/购物卡不可为空。");
                        $("#<%=txtCrashOrCard.ClientID %>").focus();
                        return false;
                    }
                }
                if($("#<%=rdbApplySomething3.ClientID%>").prop("checked")){
                    if($.trim($("#<%=txtAnotherName.ClientID %>").val())=="") {
                        alert("其他名称不可为空。");
                        $("#<%=txtAnotherName.ClientID %>").focus();
                        return false;
                    }
                    if($.trim($("#<%=txtAnotherPrice.ClientID %>").val())=="") {
                        alert("其他价值不可为空。");
                        $("#<%=txtAnotherPrice.ClientID %>").focus();
                        return false;
                    }
                }
                if($.trim($("#<%=txtGiverOrCompany.ClientID %>").val())=="") {
                    alert("赠送人/单位不可为空。");
                    $("#<%=txtGiverOrCompany.ClientID %>").focus();
                    return false;
                }
            }
            if($("#<%=cbApplyContent4.ClientID%>").prop("checked")) {
                if(!$("#<%=rdbEntrust1.ClientID%>").prop("checked") && !$("#<%=rdbEntrust2.ClientID%>").prop("checked")){
                    alert("请选择委托公司代理中介服务。");
                    $("#<%=rdbEntrust1.ClientID %>").focus();
                    return false;
                }
                if(!$("#<%=rdbBuildingKind1.ClientID%>").prop("checked") && !$("#<%=rdbBuildingKind2.ClientID%>").prop("checked") && !$("#<%=rdbBuildingKind3.ClientID%>").prop("checked")){
                    alert("请选择物业类型。");
                    $("#<%=rdbBuildingKind1.ClientID %>").focus();
                    return false;
                }
                if($("#<%=rdbBuildingKind3.ClientID%>").prop("checked")){
                    if($.trim($("#<%=txtAnotherBuilding.ClientID %>").val())=="") {
                        alert("其他物业类型不可为空。");
                        $("#<%=txtAnotherBuilding.ClientID %>").focus();
                        return false;
                    }
                }
                if($.trim($("#<%=txtEntrustNo1.ClientID %>").val())=="") {
                    alert("请填写正确的委托公司跟进人工号。");
                    $("#<%=txtEntrustNo.ClientID %>").focus();
                    return false;
                }
            }
            if($("#<%=cbApplyContent5.ClientID%>").prop("checked")) {
                if(!$("#<%=rdbAnotherActivity1.ClientID%>").prop("checked") && !$("#<%=rdbAnotherActivity2.ClientID%>").prop("checked")){
                    alert("请选择其他商业活动申请事项。");
                    $("#<%=rdbAnotherActivity1.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtInvestment.ClientID %>").val())=="") {
                    alert("投资或兼职公司名称不可为空。");
                    $("#<%=txtInvestment.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtIpossition.ClientID %>").val())=="") {
                    alert("投资或兼职职位不可为空。");
                    $("#<%=txtIpossition.ClientID %>").focus();
                    return false;
                }
            }
            if($("#<%=cbApplyContent6.ClientID%>").prop("checked")) {
                if($.trim($("#<%=txtAnotherSummary.ClientID %>").val())=="") {
                    alert("其他情况申报不可为空。");
                    $("#<%=txtAnotherSummary.ClientID %>").focus();
                    return false;
                }
            }
            var data = "";
            var flag = true,fl = true;
            $("#tbDetail tr").each(function(n) {
                
                if(!$("#<%=cbApplyContent2.ClientID%>").prop("checked")) {
                    fl = false;
                }
                if (n != 0 && n != $("#tbDetail tr").size()-1 && $("#<%=cbApplyContent2.ClientID%>").prop("checked")) {
                    if ($.trim($("#txtDetail_RelativesName" + n).val()) == "") {
                        alert("第" + n + "行的亲属姓名必须填写。");
                        $("#txtDetail_RelativesName" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtDetail_InDepartment" + n).val()) == "") {
                        alert("第" + n + "行的所在部门必须填写。");
                        $("#txtDetail_InDepartment" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtDetail_Position" + n).val()) == "") {
                        alert("第" + n + "行的担任职位必须填写。");
                        $("#txtDetail_Position" + n).focus();
                        flag = false;
                    }
                    else if (($.trim($("#txtDetail_Relationship" + n).val()) == ""&&$("#relationshipTwo" + n).val()=="其他")||$("#relationshipOne" + n).val()=="") {
                        alert("第" + n + "行的亲属关系必须填写。");
                        $("#txtDetail_Relationship" + n).focus();
                        flag = false;
                    } 
                    else if(fl)
                        data += $.trim($("#txtDetail_RelativesName" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_InDepartment" + n).val())
                            + "&&" + $.trim($("#txtDetail_Position" + n).val()) 
                            + "&&" + $.trim($("#relationshipTwo" + n).val()=="其他"?$("#txtDetail_Relationship" + n).val():$("#relationshipTwo" + n).val()) 
                            + "||";
                    else
                        data += " && && && ||";
                }
            });
            if (flag) {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
                if(data!="" || !$("#<%=cbApplyContent2.ClientID%>").prop("checked"))
	                return true;
	            else 
	                return false;
            }
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
            var sReturnValue = window.showModalDialog("../Apply_UploadFile.aspx?mainid=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_NewPersInterests_Detail.aspx?mainid=<%=MainID %>';
        }

        function editflow(){
                    var win=window.showModalDialog("Apply_PersInterests_Flow.aspx?mainid=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_NewPersInterests_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
        function sign(idx) {
            //if(idx=='1'||idx=='2'||idx=='3'){//789
            //    //if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
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

        function saveRemark() {
            $.ajax({
                url: "../../Ajax/Apply_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=savepersinterestsremark&id=<%=ID %>",
                success: function(info) {
                    if(info=='success')
                        alert('标记成功');
                    else
                        alert('标记失败');
                }
            })
        }

        function getEmployee(n) {
            $.ajax({
                url: "../../Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtApplyFor.ClientID%>").val(infos[1]);
                        $("#<%=hdApply.ClientID%>").val(infos[1]);
                        $("#<%=txtTfid1.ClientID%>").val(infos[8]);
                        $("#<%=txtTfid2.ClientID%>").val(infos[2]);
                        $("#<%=txtTfid3.ClientID%>").val(infos[4]);
                        $("#<%=txtTfid4.ClientID%>").val(infos[6]);
                        $("#<%=txtTfid5.ClientID%>").val(infos[7]);
                        $("#spanApplyFor").show();
                    }
                    else{
                        $("#<%=txtApplyFor.ClientID%>").val("");
                        $("#<%=hdApply.ClientID%>").val("");
                        $("#<%=txtTfid1.ClientID%>").val("");
                        $("#<%=txtTfid2.ClientID%>").val("");
                        $("#<%=txtTfid3.ClientID%>").val("");
                        $("#<%=txtTfid4.ClientID%>").val("");
                        $("#<%=txtTfid5.ClientID%>").val("");
                        $("#spanApplyFor").hide();
                    }
                }
            })
        }

        function getEmployee2(n) {
            $.ajax({
                url: "../../Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtFollower.ClientID%>").val(infos[1]);
                        $("#<%=txtFollowerDepartment.ClientID%>").val(infos[2]);
                        $("#<%=txtPositionName.ClientID%>").val(infos[4]);
                        $("#spanFollower").show();
                    }
                    else{
                        $("#<%=txtFollower.ClientID%>").val("");
                        $("#<%=txtFollowerDepartment.ClientID%>").val("");
                        $("#<%=txtPositionName.ClientID%>").val("");
                        $("#spanFollower").hide();
                    }
                }
            })
        }

        function getEmployee3(n) {
            $.ajax({
                url: "../../Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtEntrustNo1.ClientID%>").val(infos[1]);
                        $("#<%=txtEntrustNo2.ClientID%>").val(infos[2]);
                        $("#spEntrust").show();
                    }
                    else{
                        $("#<%=txtEntrustNo1.ClientID%>").val("");
                        $("#<%=txtEntrustNo2.ClientID%>").val("");
                        $("#spEntrust").hide();
                    }
                }
            })
        }

        function addRow() {
		    
            var html = '<tr id="trDetail' + i + '">'
				+ '             <td class=\"tl PL10\" style="line-height: 30px">亲属姓名：<input type="text" id="txtDetail_RelativesName' + i + '" style="width:150px;"/>'
				+               '　所在部门：<input type="text" id="txtDetail_InDepartment' + i + '" style="width:200px;"/><br />'
                +               '担任职位：<input type="text" id="txtDetail_Position' + i + '" style="width:200px;"/><br/>'
                +               '亲属关系：<select id="relationshipOne'+i+'" onchange="relationshipOneOnchange(this)"><option value =""></option><option value ="直系亲属">直系亲属</option><option value ="次直系亲属">次直系亲属</option><option value="其他">其他</option></select>'
                 +               '<select id="relationshipTwo'+i+'" onchange="relationshipTwoOnchange(this)"><option value =""></option><option value ="亲兄弟">亲兄弟</option><option value ="亲兄妹">亲兄妹</option><option value ="亲姐妹">亲姐妹</option><option value ="亲姐弟">亲姐弟</option><option value ="夫妻">夫妻</option><option value ="父女">父女</option><option value ="父子">父子</option><option value ="母女">母女</option><option value ="母子">母子</option></select>'
                +               '<input type="text" id="txtDetail_Relationship' + i + '" style="width:150px;display:none"/></td>'//*-
				+ '     </tr>';
            //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
            //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
            $("#trFlag").before(html);

            $("#txtDetail_InDepartment"+ i).autocomplete({source: jJSON});
            i++;
        }

        function deleteRow() {
            if (i > 2) {
                i--;
                $("#tbDetail tr:eq(" + i + ")").remove();
            } else
                alert("不可删除第一行。");
            //$("#tbDetail tr:eq(0)").remove();
        }

        function showOrHideIDx(x) {//789
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }
        function addFlow() {
            var html = '<tr id="trAddFlow' + jaf + '" class="noborder" style="height: 85px;">'
				+   '<td style="text-align: left; padding-left: 10px;" colspan="4">'
				+   '<div class="flow">'
                +   '部门名称：<input type="text" id="txtDpm' + jaf + '" style="margin-bottom: 10px;width:250px;border: 1px solid #98b8b5;" /><br/>'
				+   '<div id="divIDx' + (3*jaf+1) + '" class="item2">环节1</div>'
				+   '<div id="divTxtIDx' + (3*jaf+1) + '" class="item2">'
				+   '   <input type="text" id="txtIDxa' + (3*jaf+1) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+1) + '" type="hidden" />'
				+   '   <input type="radio" id="rdoIsCmodel' + jaf + '11" checked="checked" name="IsCmodel' + jaf + '1" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '11">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '10" name="IsCmodel' + jaf + '1" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '10">单人审批</label>'
				+   '</div>'
				+   '<img src="/Images/forward.png" class="forward"/>'
				+   '<div id="divIDx' + (3*jaf+2) + '" class="item2"><input id="btnIDx' + jaf + '2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*jaf+2) + ');" />'
				+   '   <label id="lblIDx' + jaf + '2" for="btnIDx' + jaf + '2">环节2</label>'
				+   '</div>'
				+   '<div id="divTxtIDx' + (3*jaf+2) + '" class="item2" style="display:none;">'
				+   '   <br/>&nbsp;环节2&nbsp;<input type="text" id="txtIDxa' + (3*jaf+2) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+2) + '" type="hidden" />'
				+   '   <input type="radio" id="rdoIsCmodel' + jaf + '21" checked="checked" name="IsCmodel' + jaf + '2" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '21">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '20" name="IsCmodel' + jaf + '2" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '20">单人审批</label>'
				+   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*jaf+2) + ')">取消</a>'
				+   '</div>'
				+   '<img src="/Images/forward.png" class="forward"/>'
				+   '<div id="divIDx' + (3*jaf+3) + '" class="item2"><input id="btnIDx' + jaf + '3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*jaf+3) + ');" />'
				+   '   <label id="lblIDx' + jaf + '3" for="btnIDx' + jaf + '3">环节3</label>'
				+   '</div>'
				+   '<div id="divTxtIDx' + (3*jaf+3) + '" class="item2" style="display:none;">'
				+   '   <br/>&nbsp;环节3&nbsp;<input type="text" id="txtIDxa' + (3*jaf+3) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+3) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + jaf + '31" checked="checked" name="IsCmodel' + jaf + '3" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '31">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '30" name="IsCmodel' + jaf + '3" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '30">单人审批</label>'
				+   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*jaf+3) + ')">取消</a>'
				+   '</div></div>'
				+   '</td>'
				+ '</tr>'
            //var html = '<tr id="trAddFlow' + jaf + '"><table><tr><td>这是'+ jaf +'个</td></tr></table></tr>'
            $("#trAddFlowBefore").before(html);
            $("#txtDpm"+ jaf).autocomplete({source: jJSON});
            for(var il =1;il<=3;il++)
            {
                $("#txtIDxa" + (3*jaf + il))
                    .bind( "keydown", function( event ) {
                        if ( event.keyCode === $.ui.keyCode.TAB && $( this ).data( "ui-autocomplete" ).menu.active ) {
                            event.preventDefault();
                        }
                    })
                    .autocomplete({
                        minLength: 0,
                        source: function( request, response ) {
                            // delegate back to autocomplete, but extract the last term
                            response( $.ui.autocomplete.filter(jJSONF, extractLast( request.term ) ) );
                        },
                        focus: function() {
                            // prevent value inserted on focus
                            return false;
                        },
                        select: function( event, ui ) {
                            var terms = split( this.value );
                            // remove the current input
                            terms.pop();
                            // add the selected item
                            terms.push( ui.item.value );
                            // add placeholder to get the comma-and-space at the end
                            terms.push( "" );
                            this.value = terms.join( "," );
                            return false;
                        }
                    });
            }
            jaf++; 
        }
        function deleteFlow() {
            if (jaf > 20) {
                jaf--;
                $("#tbAddFlows tr:eq(" + (jaf - 20) + ")").remove();
                //$("#tbAround tr[id*=trDetail]").remove();
            } else{
                $('#add1F').hide();
                alert("不可再删除了。");
            }
        }
        function SaveFlow() {
            var data = "";
            var flag = true, flag2 = true;
            var content = "";
            for(var k = 20; k < $("#tbAddFlows tr").length + 20 - 1; k++)
            {
                if ($.trim($("#txtDpm" + k).val()) == "") {
                    alert("您所添加的部门名称不可为空。");
                    $("#txtDpm" + k).focus();
                    return false;
                }
            }
            for(var y = 3*20 + 1; y <= $("[id^=txtIDxa]").size() + 3*20; y++)
            {
                if($("#txtIDxa" + y).parent().css("display")!="none") 
                {
                    if($.trim($("#txtIDxa" + y).val())=="")
                    {
                        alert("您所添加的审批环节不可为空！");
                        $("#txtIDxa" + y).focus();
                        return false;
                    }
                    content+=y+":"+$("#txtIDxa" + y).val()+";";
                }
            }
            $("#tbAddFlows tr").each(function(n) {
                if (n != 0 && n != $("#tbAddFlows tr").size()) {
                    data += $.trim($("#txtDpm" + (n+20-1)).val()) 
                        + "&&" + (3*20+(3*n-2)).toString()
                        + "&&1"
                        + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "11").prop('checked')?"1":"0")
                        + "&&1||"
                        + $.trim($("#txtDpm" + (n+20-1)).val()) 
                        + "&&" + (3*20+(3*n-2)+1).toString()
                        + "&&2"
                        + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "21").prop('checked')?"1":"0")
	                    + "&&" + ($("#txtIDxa" + (3*20+(3*n-2) + 1)).parent().css("display")!="none"?"1":"0") + "||"
                        + $.trim($("#txtDpm" + (n+20-1)).val()) 
                        + "&&" + (3*20+(3*n-2)+2).toString()
                        + "&&3"
                        + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "31").prop('checked')?"1":"0")
                        + "&&" + ($("#txtIDxa" + (3*20+(3*n-2) + 2)).parent().css("display")!="none"?"1":"0") + "||";
                }
            });
            if(flag)
            {
                content = content.substr(0,content.length-1);
                $.ajax({
                    url: "../../Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    async: false,
                    cache: false,
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+7,
                    success: function(info) {
                        if (info == "success") {
                            flag2 = true;
                            data = data.substr(0, data.length - 2);
                            $("#<%=hdLogisticsFlow.ClientID %>").val(data);
		                    return true;
                        }
                        else if (info == "NoPower")
                            flag2 = false;
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                            flag2 = false;
                        }
                        else
                        {
                            alert("保存失败，审批流程中有部分人名不存在或不具备审批资格，\\n请修改，如依然失败，请联系资讯科技部！\n错误代码："+ info);
                            flag2 = false;
                        }
		            }
                })
                if (flag2) {
                    return true;
                }
                else
                    return false;
            }
            //if (flag && flag2) {
            //    data = data.substr(0, data.length - 2);
            //$("#<%=hdLogisticsFlow.ClientID %>").val(data);
            //    return true;
            //}
            //else
            //    return false;
        }//987
        function DeleteT() { //20141231：M_DeleteC
            $("#btnADelete").hide();
            var url = "../Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
            if(sReturnValue=='deleted')
                window.location='/Apply/Apply_Search.aspx';
            else
                window.location.href=window.location.href;
        }
        var OneTypes=new Array("亲兄弟","亲兄妹","亲姐妹","亲姐弟","夫妻","父女","父子","母女","母子")
        var OneTwos=new Array("堂兄弟","堂兄妹","堂姐弟","堂姐妹","表兄弟","表兄妹","表姐弟","表姐妹","其他")

        function relationshipOneOnchange(item){
            
            var val=  $("#"+item.id).val();
            var n=item.id.replace("relationshipOne","");
         
            $("#relationshipTwo"+n).empty();
            if(val=="直系亲属") {
                for(var i=0;i<OneTypes.length;i++){
                    $("<option value='"+OneTypes[i]+"'>"+OneTypes[i]+"</option>").appendTo("#relationshipTwo"+n)   
                }
                $("#txtDetail_Relationship"+n).css('display','none'); 
            }
            else if(val=="次直系亲属")
            {

                for(var i=0;i<OneTwos.length;i++){
                    $("<option value='"+OneTwos[i]+"'>"+OneTwos[i]+"</option>").appendTo("#relationshipTwo"+n)   
                }
                $("#txtDetail_Relationship"+n).css('display','none'); 
            }
            else if(val==""){
                //for(var i=0;i<OneTypes.length;i++){
                //    $("<option value='"+OneTypes[i]+"'>"+OneTypes[i]+"</option>").appendTo("#relationshipTwo"+n)   
                //}
                $("#txtDetail_Relationship"+n).css('display','none'); 
            
            }
            
            else
            {
                $("#txtDetail_Relationship"+n).css('display',''); 
                $("#txtDetail_Relationship"+n).val("");
                $("<option value='其他'>其他</option>").appendTo("#relationshipTwo"+n)   
            }
        }
        function relationshipTwoOnchange(item){

            var n=item.id.replace("relationshipTwo","");
           
            var val=  $("#"+item.id).val();
            if(val=="其他"){
                //$("#txtDetail_Relationship"+n).attr("readonly","readonly"); 
                
                $("#txtDetail_Relationship"+n).css('display',''); 
                $("#txtDetail_Relationship"+n).val("");
            }else{
                $("#txtDetail_Relationship"+n).css('display','none'); 
                //$("#txtDetail_Relationship"+n).removeAttr("readonly");
            }
        }
	</script>
    <style type="text/css">
        .auto-style2 {
            width: 150px;
        }
        .auto-style4 {
            width: 120px;
        }
        .auto-style5 {
            width: 200px;
        }
    </style>
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
			<h1>员工个人利益申报表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
                <tr>
                    <td class="auto-style2">﹡部门性质</td>
                    <td class="tl PL10"><asp:DropDownList ID="ddlDepartmentType" runat="server" Width="150px"></asp:DropDownList></td>
                    <td class="auto-style4">﹡利益申报类别</td>
                    <td class="tl PL10"><asp:DropDownList ID="ddlInterestsType" runat="server" Width="200px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="auto-style2">﹡申请人</td>
                    <td class="tl PL10">工号：<asp:TextBox ID="txtApplyForID" runat="server" Width="50px" onblur="getEmployee(this);"></asp:TextBox><span id="spanApplyFor" style="display:none;">姓名：<input id="txtApplyFor" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span></td>
                    <td class="auto-style4">﹡申请日期</td>
                    <td class="tl PL10"><asp:TextBox ID="txtApplyForDate" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">﹡身份证号</td>
                    <td class="tl PL10"><asp:TextBox ID="txtTfid1" runat="server"></asp:TextBox></td>
                    <td class="auto-style4">﹡联系电话</td>
                    <td class="tl PL10"><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">﹡部门分行</td>
                    <td class="tl PL10"><asp:TextBox ID="txtTfid2" runat="server"></asp:TextBox></td>
                    <td class="auto-style4">﹡职位</td>
                    <td class="tl PL10"><asp:TextBox ID="txtTfid3" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">﹡入职日期</td>
                    <td class="tl PL10"><asp:TextBox ID="txtTfid4" runat="server"></asp:TextBox></td>
                    <td class="auto-style4">﹡通过试用期日期</td>
                    <td class="tl PL10"><asp:TextBox ID="txtTfid5" runat="server"></asp:TextBox></td>
                </tr>


                <tr>
                    <td class="tl PL10" colspan="4" style="text-align: left; padding-left: 5px">
                        <asp:CheckBox ID="cbApplyContent1" runat="server" Text="　通过公司购买/租赁房屋" />
                    </td>
                </tr>
                <tr class="trgray1">
                    <td class="auto-style2">交易类型：</td>
                    <td class="auto-style5">
                        <asp:RadioButton ID="rdbDealKind3" runat="server" Text="买" GroupName="DealKind" />　
                            <asp:RadioButton ID="rdbDealKind4" runat="server" Text="卖" GroupName="DealKind" />　
                        <asp:RadioButton ID="rdbDealKind1" runat="server" Text="买卖" Visible="false" GroupName="DealKind" />　
                        <asp:RadioButton ID="rdbDealKind2" runat="server" Text="租赁" GroupName="DealKind" />
                    </td>
                    <td class="auto-style4">交易物业：</td>
                    <td>
                        <asp:RadioButton ID="rdbDealProperty1" GroupName="DealProperty" runat="server" Text="一手代理项目" />
                        <asp:RadioButton ID="rdbDealProperty2" GroupName="DealProperty" runat="server" Text="二手物业" />
                    </td>
                </tr>
                <tr class="trgray1">
                    <td class="auto-style2">交易跟进情况：</td>
                    <td colspan="3" class="tl PL10" style=" line-height: 30px;">
                        跟&nbsp;&nbsp;进&nbsp;&nbsp;人：工号：<asp:TextBox ID="txtFollowerNo" runat="server" Width="60px" onblur="getEmployee2(this);"></asp:TextBox><span id="spanFollower" style="display:none;">&nbsp;&nbsp;&nbsp;&nbsp;姓名：<input id="txtFollower" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span>（促成房产交易的同事姓名）&nbsp;&nbsp;
                        <br /> 职位：<input id="txtPositionName" readonly="readonly" type="text" runat="server" style="background-color:Silver; width:80px;"/><br />
                        跟进分行：<input id="txtFollowerDepartment" readonly="readonly" type="text" runat="server" style="background-color:Silver;"/>（促成房产交易的同事所在分行）<br />
                    </td>
                </tr>
                <tr class="trgray1">
                    <td class="auto-style2">交易房屋情况</td>
                    <td colspan="3" style="padding: 5px; text-align: left; line-height: 30px;">
                        业权人：<asp:RadioButton ID="rdbPropertyHander1" GroupName="PropertyHander" runat="server" Text="本人" />
                        <asp:RadioButton ID="rdbPropertyHander2" GroupName="PropertyHander" runat="server" Text="本人及联名人" />
                        （<asp:TextBox ID="txtMeAndHim" runat="server" Width="195px"></asp:TextBox>）
                        <br />　　　　
                        <asp:RadioButton ID="rdbPropertyHander3" GroupName="PropertyHander" runat="server" Text="直系亲属" />
                        （关系<asp:TextBox ID="txtRelationship" runat="server" Width="100px" ></asp:TextBox>
                        姓名<asp:TextBox ID="txtRelationName" runat="server" Width="100px" ></asp:TextBox>）
                        <br />
                        物业地址：<asp:TextBox ID="txtBuilding" runat="server" Width="275px" ></asp:TextBox>　
                        面积：<asp:TextBox ID="txtSquare" runat="server" Width="70px" ></asp:TextBox>平方米
                        <br />
                        <table id="tbAround2" style="border-collapse: collapse" width="510px">
                            <tr>
                                <td class="tl PL10">价格范围</td>
                                <td class="tl PL10"><asp:TextBox ID="txtPriceScope" runat="server"></asp:TextBox></td>
                                <td class="tl PL10">租赁期限</td>
                                <td class="tl PL10"><asp:TextBox ID="txtLeaseTerm" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="tl PL10">付款方式</td>
                                <td class="tl PL10">
                                    <asp:RadioButton ID="rdbPayWay1" GroupName="PayWay" runat="server" Text="楼宇按揭贷款" />
                                    <asp:RadioButton ID="rdbPayWay2" GroupName="PayWay" runat="server" Text="一次性付款"/>
                                </td>
                                <td class="tl PL10">其它特别要求</td>
                                <td class="tl PL10"><asp:TextBox ID="txtRequirements" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="tl PL10">跟进方式</td>
                                <td class="tl PL10" colspan="3">
                                    <asp:RadioButton ID="rdbFollowWay1" GroupName="FollowWay" runat="server" Text="自行联系它行跟进" />
                                    <asp:RadioButton ID="rdbFollowWay2" GroupName="FollowWay" runat="server" Text="人力资源部推荐分行跟进" />
                                </td>
                            </tr>
                        </table>
                        （备注：如需申请购房免佣的，请参照《员工购/租楼宇申报规定》进行相应福利申请及登记）
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 5px">
                        <asp:CheckBox ID="cbApplyContent2" runat="server" Text="　亲属关系申报" />
                    </td>
                </tr>
                <tr class="trgray2">
					<td class="tl PL10 PR10" colspan="4">
						<span>亲属关系　请填写</span><br />
						<table id="tbDetail" class='sample tc' width='100%'>

                            <thead><tr><td></td></tr></thead>
                            <%=SbHtml.ToString()%> 
                             
                            <tr id="trFlag"><td></td></tr>

						</table>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
						<div style="clear:both;">
                            注：根据公司规定直系亲属不能入职同一组别。
						</div>
					</td>
				</tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 5px">
                        <asp:CheckBox ID="cbApplyContent3" runat="server" Text="　接受礼物、现金、赠品的申报" />
                    </td>
                </tr>
                <tr class="trgray3">
                    <td class="auto-style2">申请事项</td>
                    <td class="tl PL10" colspan="3">
                        <asp:RadioButton ID="rdbApplySomething1" GroupName="ApplySomething" runat="server" Text="礼物/赠品" />
                        （名称：<asp:TextBox ID="txtGiftName" runat="server" Width="200px"></asp:TextBox>
                        价值：￥<asp:TextBox ID="txtGiftPrice" runat="server" Width="60px"></asp:TextBox>元）<br />
                        <asp:RadioButton ID="rdbApplySomething2" GroupName="ApplySomething" runat="server" Text="现金/购物卡" />
                        ￥<asp:TextBox ID="txtCrashOrCard" runat="server" Width="100px"></asp:TextBox>元<br />
                        <asp:RadioButton ID="rdbApplySomething3" GroupName="ApplySomething" runat="server" Text="其他" />
                        （名称：<asp:TextBox ID="txtAnotherName" runat="server" Width="230px"></asp:TextBox>
                        价值：￥<asp:TextBox ID="txtAnotherPrice" runat="server" Width="60px"></asp:TextBox>元）
                    </td>
                </tr>
                <tr class="trgray3">
                    <td class="auto-style2">赠送人/单位</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtGiverOrCompany" runat="server" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 5px">
                        <asp:CheckBox ID="cbApplyContent4" runat="server" Text="　从事公司利益有关商业活动的申报" />
                    </td>
                </tr>
                <tr class="trgray4">
                    <td class="tl PL10" colspan="2">
                        委托公司代理中介服务：
                        <asp:RadioButton ID="rdbEntrust1" GroupName="Entrust" runat="server" Text="是" />　
                        <asp:RadioButton ID="rdbEntrust2" GroupName="Entrust" runat="server" Text="否" />
                    </td>
                    <td class="tl PL10" colspan="2">
                        物业类型：
                        <asp:RadioButton ID="rdbBuildingKind1" GroupName="BuildingKind" runat="server" Text="住宅" />
                        <asp:RadioButton ID="rdbBuildingKind2" GroupName="BuildingKind" runat="server" Text="商铺" />
                        <asp:RadioButton ID="rdbBuildingKind3" GroupName="BuildingKind" runat="server" Text="其他" />
                        （<asp:TextBox ID="txtAnotherBuilding" runat="server" Width="70px"></asp:TextBox>）
                    </td>
                </tr>
                <tr class="trgray4">
                    <td colspan="2" class="tl PL10">
                        跟进人工号：<asp:TextBox ID="txtEntrustNo" runat="server" Width="60px" onblur="getEmployee3(this);"></asp:TextBox>
                        <span id="spEntrust" style="display:none;">　跟进人：<input id="txtEntrustNo1" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span><br />
                    </td>
                    <td colspan="2" class="tl PL10">
                        跟进分行：<input id="txtEntrustNo2" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 5px">
                        <asp:CheckBox ID="cbApplyContent5" runat="server" Text="　从事其他商业活动或外部兼职工作的申报" />
                    </td>
                </tr>
                <tr class="trgray5">
                    <td class="auto-style2">申请事项</td>
                    <td colspan="3" class="tl PL10">
                        <asp:RadioButton ID="rdbAnotherActivity1" GroupName="AnotherActivity" runat="server" Text="投资非上市公司并作为该公司股东" />　
                        <asp:RadioButton ID="rdbAnotherActivity2" GroupName="AnotherActivity" runat="server" Text="外部兼职" />
                    </td>
                </tr>
                <tr class="trgray5">
                    <td class="auto-style2">投资或兼职公司名称</td>
                    <td colspan="3" class="tl PL10">
                        <asp:TextBox ID="txtInvestment" runat="server" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr class="trgray5">
                    <td class="auto-style2">投资或兼职职位</td>
                    <td colspan="3" class="tl PL10">
                        <asp:TextBox ID="txtIpossition" runat="server" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 5px">
                        <asp:CheckBox ID="cbApplyContent6" runat="server" Text="　其他情况申报（具体内容请详细说明）" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="txtAnotherSummary" runat="server" Width="97%" Height="130px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td class="auto-style2" >填表人</td>
					<td class="auto-style5"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td class="auto-style4">填表日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
				

                <tr  id="trManager1" class="noborder" style="height:30px;">
                    <td class="auto-style2">部门主管</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div></td>
                </tr>
                <tr  id="trManager2" class="noborder" style="height:30px;">
                    <td class="auto-style2">隶属主管</td>
                    <td colspan="3" class="tl PL10" >
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div></td>
                </tr>
                <tr  id="trManager3" class="noborder" style="height:30px;">
                    <td class="auto-style2">部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height:30px;">
                    <td rowspan="2" class="auto-style2" >人力资源部意见</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
                        <textarea id="txtIDx4" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
                    </td>                            
                </tr>
                <%--<tr class="noborder" style="height:30px">
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>       
                </tr>--%>
                <tr class="noborder" style="height:30px; ">
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="3" style="width:98%; overflow:auto;" cols="20" name="S1"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
                    </td>       
                </tr>
                <tr id="add1F" style="display: none">
                    <td colspan="4">
                        <table id="tbAddFlows" class='sample tc' width='100%'>
                            <tr id="trAddFlowBefore">
                                
                                <td>
                                    <asp:Button ID="btnSaveLogisticsFlow" runat="server" Text="" OnClientClick="return SaveFlow();" OnClick="btnSaveLogisticsFlow_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%=SbHtmlLogisticsFlow.ToString()%>
                <tr id="trLogistics" class="noborder" style="height:30px; display:none; ">
                    <td class="auto-style2" >后勤事务部意见<br /><asp:Button ID="btnWillEnd2" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx7" type="radio" name="agree72" /><label for="rdbOtherIDx7">其他意见</label><br />
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx7" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
                    </td>       
                </tr>	
                <tr id="trGeneralManager" class="noborder" style="height:30px; display:none; ">
                    <td class="auto-style2" >董事总经理审批</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        <textarea id="txtIDx8" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
                    </td>       
                </tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style2" >后勤事务部意见<br />
                        <%--<asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />--%>
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style2" >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
					</td>
				</tr>
                                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3" >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx200">_________</span></div>
					</td>
				</tr>

                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3" >董事总经理复审</td>
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

        <div class="noprint">
        <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" BackColor="White" style="clear:both; margin-top:3px;"
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
                <asp:TemplateField HeaderText="删除" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:ImageButton ID="iBtnDelete" runat="server"  ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID") %>' OnClientClick="return confirm('确认删除？');" />
                        <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
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
        </asp:GridView>
        <div id="PageBottom">
        <hr />
        <asp:Button ID="btnReWrite" runat="server" OnClick="btnReWrite_Click" text="重新导入" Visible="False" />
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left:5px; display:none;" />
        <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" onclick="btnDownload_Click" OnClientClick="return checkChecked();" style="margin-left:5px;" Visible="false" />
        <input type="button" id="btnSignSave" value="标注已留档" onclick="saveRemark();" style="display:none;" />
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display:none;" />
        <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click"/>
        <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" style="display:none;" />
        <asp:HiddenField ID="hdIsAgree" runat="server" />
        <asp:HiddenField ID="hdSuggestion" runat="server" />
        <input type="hidden" id="hdDetail" runat="server" />
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
            <asp:HiddenField ID="hdApply" runat="server" />
            <asp:HiddenField ID="hdDepartmentType" runat="server" />
            <asp:HiddenField ID="hdInterestsType" runat="server" />
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

