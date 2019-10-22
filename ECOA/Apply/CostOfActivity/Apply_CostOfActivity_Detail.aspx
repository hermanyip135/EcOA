<%@ Page ValidateRequest="false" Title="三级市场活动费用申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_CostOfActivity_Detail.aspx.cs" Inherits="Apply_CostOfActivity_Apply_CostOfActivity_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=SbJson.ToString() %>;
		var isNewApply=('<%=IsNewApply%>'=='True');
        var isUploaded = false;
        var delF = ('<%=delF%>'=='True');
        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
        function onCycle(CycleType)
        {
		   
            if (CycleType == "" || CycleType == 'undefined' || CycleType == null) {
                $("#Cycle1").hide();
                $("#Cycle2").hide();
                CleanYear();
                CleanQuarter();
            }
            else {
                $(".isCaseCycle input[type=radio][value=" + CycleType + "]").get(0).checked = true;
                $("#<%=hiCycle.ClientID%>").val(CycleType)
		        if (CycleType == "1")
		        {
		            $("#Cycle1").show();
		            $("#Cycle2").hide();
		            CleanYear()
		        }
		        else if (CycleType == "2") {
		            $("#Cycle1").hide();
		            $("#Cycle2").show();
		            CleanQuarter();
		        }
		        else {
		            $("#Cycle1").hide();
		            $("#Cycle2").hide();
		            CleanYear();
		            CleanQuarter();
		        }
            }
        }
        function CleanQuarter()
        {
            $("#<%=cbQuarter1.ClientID %>").removeAttr("checked")
            $("#<%=cbQuarter2.ClientID %>").removeAttr("checked")
            $("#<%=cbQuarter3.ClientID %>").removeAttr("checked")
            $("#<%=cbQuarter4.ClientID %>").removeAttr("checked")

            $("#<%=txtMan1.ClientID%>").attr("disabled","disabled");
            $("#<%=txtFear1.ClientID%>").attr("disabled","disabled");
            $("#<%=txtMan1.ClientID%>").val("");
            $("#<%=txtFear1.ClientID%>").val("");

            $("#<%=txtMan2.ClientID%>").attr("disabled","disabled");
            $("#<%=txtFear2.ClientID%>").attr("disabled","disabled");
            $("#<%=txtMan2.ClientID%>").val("");
            $("#<%=txtFear2.ClientID%>").val("");
           
            $("#<%=txtMan3.ClientID%>").attr("disabled","disabled");
            $("#<%=txtFear3.ClientID%>").attr("disabled","disabled");
            $("#<%=txtMan3.ClientID%>").val("");
            $("#<%=txtFear3.ClientID%>").val("");

            $("#<%=txtMan4.ClientID%>").attr("disabled","disabled");
            $("#<%=txtFear4.ClientID%>").attr("disabled","disabled");
            $("#<%=txtMan4.ClientID%>").val("");
            $("#<%=txtFear4.ClientID%>").val("");
        }
        function CleanYear()
        {
            
            $("#<%=cbUpYear.ClientID %>").removeAttr("checked")
            $("#<%=cbLoYear.ClientID %>").removeAttr("checked")
            $("#<%=txtMan5.ClientID%>").attr("disabled","disabled");
            $("#<%=txtFear5.ClientID%>").attr("disabled","disabled");
            $("#<%=txtMan5.ClientID%>").val("");
            $("#<%=txtFear5.ClientID%>").val("");

            $("#<%=txtMan6.ClientID%>").attr("disabled","disabled");
            $("#<%=txtFear6.ClientID%>").attr("disabled","disabled");
            $("#<%=txtMan6.ClientID%>").val("");
            $("#<%=txtFear6.ClientID%>").val("");
        }
        //计算费用 人数 费用 季度1/半年度2
        function Calculation(people,Cost,Cycle)
        {
            if(parseInt(people)<=parseInt(200))
            {
                if("1"== Cycle)
                {
                    if(Cost>3000)
                    {
                        return false;
                    }
                }
                else if("2" == Cycle)
                {
                    if(Cost>6000)
                    {
                        return false;
                    }
                }
            }else if(parseInt(people)<=parseInt(400))
            {
                if("1"== Cycle)
                {
                    if(Cost>8000)
                    {
                        return false;
                    }
                }
                else if("2" == Cycle)
                {
                    if(Cost>16000)
                    {
                        return false;
                    }
                }
            }
            else  if(parseInt(people)<=parseInt(600))
            {
                    
                if("1"== Cycle)
                {
                    if(Cost>11000)
                    {
                        return false;
                    }
                }
                else if("2" == Cycle)
                {
                    if(Cost>22000)
                    {
                        return false;
                    }
                }
            }
            else  if(parseInt(people)<=parseInt(800))
            {
                if("1"== Cycle)
                {
                    if(Cost>15000)
                    {
                        return false;
                    }
                }
                else if("2" == Cycle)
                {
                    if(Cost>30000)
                    {
                        return false;
                    }
                }
            }
            else  if(parseInt(people)<=parseInt(1000))
            {
                if("1"== Cycle)
                {
                    if(Cost>16000)
                    {
                        return false;
                    }
                }
                else if("2" == Cycle)
                {
                    if(Cost>32000)
                    {
                        return false;
                    }
                }
            }
            else  if(parseInt(people)>parseInt(1000))
            {
                if("1"== Cycle)
                {
                    if(Cost>18000)
                    {
                        return false;
                    }
                }
                else if("2" == Cycle)
                {
                    if(Cost>36000)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        $(function() {      
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {
		            $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}
		     
		    //i = $("#tbDetail tr").length - 1;
		    $("#btnUpload").css({"background-image": "url(/Images/btn_Smallupload1.png)","width":"72px","height":"25px"});
		    $("[id=btnUpload]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_Smallupload2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_Smallupload1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_Smallupload1.png)"); });
		    $("#<%=txtFear1.ClientID%>").blur(function () {
		        AutoC();
		    });
		    $("#<%=txtFear2.ClientID%>").blur(function () {
		        AutoC();
		    });
		    $("#<%=txtFear3.ClientID%>").blur(function () {
		        AutoC();
		    });
		    $("#<%=txtFear4.ClientID%>").blur(function () {
		        AutoC();
		    });
		    $("#<%=txtFear5.ClientID%>").blur(function () {
		        AutoC2();
		    });
		    $("#<%=txtFear6.ClientID%>").blur(function () {
		        AutoC2();
		    });
		    //AutoC();
		    $("#<%=cbQuarter1.ClientID%>").click(function(){
		        if($("#<%=txtMan1.ClientID%>").attr("disabled") == "disabled"){
		            $("#<%=txtMan1.ClientID%>").removeAttr("disabled");
		            $("#<%=txtFear1.ClientID%>").removeAttr("disabled");
		        }
		        else{
		            $("#<%=txtMan1.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtFear1.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtMan1.ClientID%>").val("");
		            $("#<%=txtFear1.ClientID%>").val("");
		            AutoC();
		        }
		    });

		    $("#<%=cbQuarter2.ClientID%>").click(function(){
		        if($("#<%=txtMan2.ClientID%>").attr("disabled") == "disabled"){
		            $("#<%=txtMan2.ClientID%>").removeAttr("disabled");
		            $("#<%=txtFear2.ClientID%>").removeAttr("disabled");
		        }
		        else{
		            $("#<%=txtMan2.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtFear2.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtMan2.ClientID%>").val("");
		            $("#<%=txtFear2.ClientID%>").val("");
		            AutoC();
		        }
		    });
		    $("#<%=cbQuarter3.ClientID%>").click(function(){
		        if($("#<%=txtMan3.ClientID%>").attr("disabled") == "disabled"){
		            $("#<%=txtMan3.ClientID%>").removeAttr("disabled");
		            $("#<%=txtFear3.ClientID%>").removeAttr("disabled");
		        }
		        else{
		            $("#<%=txtMan3.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtFear3.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtMan3.ClientID%>").val("");
		            $("#<%=txtFear3.ClientID%>").val("");
		            AutoC();
		        }
		    });
		    $("#<%=cbQuarter4.ClientID%>").click(function(){
		        if($("#<%=txtMan4.ClientID%>").attr("disabled") == "disabled"){
		            $("#<%=txtMan4.ClientID%>").removeAttr("disabled");
		            $("#<%=txtFear4.ClientID%>").removeAttr("disabled");
		        }
		        else{
		            $("#<%=txtMan4.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtFear4.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtMan4.ClientID%>").val("");
		            $("#<%=txtFear4.ClientID%>").val("");
		            AutoC();
		        }
		    });
		    $("#<%=cbUpYear.ClientID%>").click(function(){
		        if($("#<%=txtMan5.ClientID%>").attr("disabled") == "disabled"){
		            $("#<%=txtMan5.ClientID%>").removeAttr("disabled");
		            $("#<%=txtFear5.ClientID%>").removeAttr("disabled");
		        }
		        else{
		            $("#<%=txtMan5.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtFear5.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtMan5.ClientID%>").val("");
		            $("#<%=txtFear5.ClientID%>").val("");
		            AutoC2();
		        }
		    });
		    $("#<%=cbLoYear.ClientID%>").click(function(){
		        if($("#<%=txtMan6.ClientID%>").attr("disabled") == "disabled"){
		            $("#<%=txtMan6.ClientID%>").removeAttr("disabled");
		            $("#<%=txtFear6.ClientID%>").removeAttr("disabled");
		        }
		        else{
		            $("#<%=txtMan6.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtFear6.ClientID%>").attr("disabled","disabled");
		            $("#<%=txtMan6.ClientID%>").val("");
		            $("#<%=txtFear6.ClientID%>").val("");
		            AutoC2();
		        }
		    });
		    onCycle($("#<%=hiCycle.ClientID%>").val());
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});
       
		function AutoC(){
		    var dd = $("#<%=txtFear1.ClientID%>").val()*1 + $("#<%=txtFear2.ClientID%>").val()*1 + $("#<%=txtFear3.ClientID%>").val()*1 + $("#<%=txtFear4.ClientID%>").val()*1;
            if(!isNaN(dd)){
                if(dd == 0)
                    $("#<%=lbAutoCoculate.ClientID%>").html(0);
                else
                    $("#<%=lbAutoCoculate.ClientID%>").html(dd);
            }
        }
        function AutoC2(){
            var dd = $("#<%=txtFear5.ClientID%>").val()*1 + $("#<%=txtFear6.ClientID%>").val()*1;
            if(!isNaN(dd)){
                if(dd == 0)
                    $("#<%=lbYearAutoCoculate.ClientID%>").html(0);
                 else
                     $("#<%=lbYearAutoCoculate.ClientID%>").html(dd);
             }
         }
         function check() {
             if(!isUploaded&&isNewApply)//*-
             {
                 alert("须上传季会议程方可提交申请！");
                 return false;
             }
             if(delF){
                 alert("须上传季会议程方可提交申请。");
                 return false;
             }
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

            if($.trim($("#<%=ddlArea.ClientID%>").val())=="0") {
                alert("请选择区域名！");
                $("#<%=ddlArea.ClientID %>").focus();
                return false;
            }
			
            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
                alert("回复电话不可为空！");
                $("#<%=txtPhone.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtSubject.ClientID %>").val())=="") {
                alert("文件主题不可为空！");
                $("#<%=txtSubject.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtInDepartment.ClientID %>").val())=="") {
                alert("所在部门不可为空！");
                $("#<%=txtInDepartment.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtYear.ClientID %>").val())=="") {
                alert("所属年份不可为空！");
                $("#<%=txtYear.ClientID %>").focus();
	            return false;
            }
            if($("#<%=hiCycle.ClientID%>").val()=="1")
            {
                if (
                        !$("#<%=cbQuarter1.ClientID %>").prop("checked") 
                    && !$("#<%=cbQuarter2.ClientID %>").prop("checked") 
                    && !$("#<%=cbQuarter3.ClientID %>").prop("checked")
                    && !$("#<%=cbQuarter4.ClientID %>").prop("checked")
               ) 
            {
                alert("请选择季度月末在职人数及费用");
                $("#<%=cbQuarter1.ClientID%>").focus();
                return false;
            }
        }
        else if($("#<%=hiCycle.ClientID%>").val()=="2")
            {
                if(!$("#<%=cbUpYear.ClientID %>").prop("checked") 
                    && !$("#<%=cbLoYear.ClientID %>").prop("checked") )
                {
                    alert("请选择半年度在职人数及费用");
                    $("#<%=cbUpYear.ClientID%>").focus();
                    return false;
                }
            }
            else
            {
                alert("请选择周期");
                $("#raCycle1").focus();
                return false;
            }

        if($("#<%=cbQuarter1.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtMan1.ClientID %>").val())=="") {
                    alert("请填写第一季度人数！");
                    $("#<%=txtMan1.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtFear1.ClientID %>").val())=="") {
                    alert("请填写第一季度费用！");
                    $("#<%=txtFear1.ClientID %>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtMan1.ClientID%>").val())) {
                    alert("第一季度人数必须输入纯数字");
                    $("#<%=txtMan1.ClientID%>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtFear1.ClientID%>").val())) {
                    alert("第一季度费用必须输入纯数字");
                    $("#<%=txtFear1.ClientID%>").focus();
                    return false;
                }
                if(!Calculation($("#<%=txtMan1.ClientID %>").val(),$("#<%=txtFear1.ClientID %>").val(),1))
                {
                    $("#<%=txtMan1.ClientID%>").focus();
                    alert("第一季度费用超出报销额度");
                    return false;
                }
            }

            if($("#<%=cbQuarter2.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtMan2.ClientID %>").val())=="") {
                    alert("请填写第二季度人数！");
                    $("#<%=txtMan2.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtFear2.ClientID %>").val())=="") {
                    alert("请填写第二季度费用！");
                    $("#<%=txtFear2.ClientID %>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtMan2.ClientID%>").val())) {
                    alert("第二季度人数必须输入纯数字");
                    $("#<%=txtMan2.ClientID%>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtFear2.ClientID%>").val())) {
                    alert("第二季度费用必须输入纯数字");
                    $("#<%=txtFear2.ClientID%>").focus();
                    return false;
                }
                if(!Calculation($("#<%=txtMan2.ClientID %>").val(),$("#<%=txtFear2.ClientID %>").val(),1))
                {
                    $("#<%=txtMan2.ClientID%>").focus();
                    alert("第二季度费用超出报销额度");
                    return false;
                }
            }

            if($("#<%=cbQuarter3.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtMan3.ClientID %>").val())=="") {
                    alert("请填写第三季度人数！");
                    $("#<%=txtMan3.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtFear3.ClientID %>").val())=="") {
                    alert("请填写第三季度费用！");
                    $("#<%=txtFear3.ClientID %>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtMan3.ClientID%>").val())) {
                    alert("第三季度人数必须输入纯数字");
                    $("#<%=txtMan3.ClientID%>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtFear3.ClientID%>").val())) {
                    alert("第三季度费用必须输入纯数字");
                    $("#<%=txtFear3.ClientID%>").focus();
                    return false;
                }
                if(!Calculation($("#<%=txtMan3.ClientID %>").val(),$("#<%=txtFear3.ClientID %>").val(),1))
                {
                    $("#<%=txtMan3.ClientID%>").focus();
                    alert("第三季度费用超出报销额度");
                    return false;
                }
            }

            if($("#<%=cbQuarter4.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtMan4.ClientID %>").val())=="") {
                    alert("请填写第四季度人数！");
                    $("#<%=txtMan4.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtFear4.ClientID %>").val())=="") {
                    alert("请填写第四季度费用！");
                    $("#<%=txtFear4.ClientID %>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtMan4.ClientID%>").val())) {
                    alert("第四季度人数必须输入纯数字");
                    $("#<%=txtMan4.ClientID%>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtFear4.ClientID%>").val())) {
                    alert("第四季度费用必须输入纯数字");
                    $("#<%=txtFear4.ClientID%>").focus();
                    return false;
                }
                if(!Calculation($("#<%=txtMan4.ClientID %>").val(),$("#<%=txtFear4.ClientID %>").val(),1))
                {
                    $("#<%=txtMan4.ClientID%>").focus();
                    alert("第四季度费用超出报销额度");
                    return false;
                }
            }
            if($("#<%=cbUpYear.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtMan5.ClientID %>").val())=="") {
                    alert("请填写上半年度人数！");
                    $("#<%=txtMan5.ClientID %>").focus();
                     return false;
                 }
                 if($.trim($("#<%=txtFear5.ClientID %>").val())=="") {
                    alert("请填写上半年费用！");
                    $("#<%=txtFear5.ClientID %>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtMan5.ClientID%>").val())) {
                    alert("上半年人数必须输入纯数字");
                    $("#<%=txtMan5.ClientID%>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtFear5.ClientID%>").val())) {
                    alert("上半年费用必须输入纯数字");
                    $("#<%=txtFear5.ClientID%>").focus();
                    return false;
                }
                if(!Calculation($("#<%=txtMan5.ClientID %>").val(),$("#<%=txtFear5.ClientID %>").val(),2))
                {
                    $("#<%=txtMan5.ClientID%>").focus();
                    alert("上半年费用超出报销额度");
                    return false;
                }
            }
            if($("#<%=cbLoYear.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtMan6.ClientID %>").val())=="") {
                    alert("请填写下半年度人数！");
                    $("#<%=txtMan6.ClientID %>").focus();
                     return false;
                 }
                 if($.trim($("#<%=txtFear6.ClientID %>").val())=="") {
                    alert("请填写下半年费用！");
                    $("#<%=txtFear6.ClientID %>").focus();
                     return false;
                 }
                 if (isNaN($("#<%=txtMan6.ClientID%>").val())) {
                    alert("下半年人数必须输入纯数字");
                    $("#<%=txtMan6.ClientID%>").focus();
                    return false;
                }
                if (isNaN($("#<%=txtFear6.ClientID%>").val())) {
                    alert("下半年费用必须输入纯数字");
                    $("#<%=txtFear6.ClientID%>").focus();
                    return false;
                }
                if(!Calculation($("#<%=txtMan6.ClientID %>").val(),$("#<%=txtFear6.ClientID %>").val(),2))
                {
                    $("#<%=txtMan6.ClientID%>").focus();
                    alert("下半年费用超出报销额度");
                    return false;
                }
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
		    var sReturnValue = window.showModalDialog("Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue!=null){
		        if(isNewApply){
		            $("#spm").show();
		            $("#spm").append(sReturnValue + "；");
		            isUploaded = true;
		        }
		        else
		            window.location='Apply_CostOfActivity_Detail.aspx?MainID=<%=MainID %>';
            }
        }

        function editflow(){
            var win=window.showModalDialog("Apply_CostOfActivity_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
		    if(win=='success')
		        window.location="Apply_CostOfActivity_Detail.aspx?MainID=<%=MainID %>";
                }
		
                function CancelSign(idc) {
                    if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
                    {
                        $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
        function sign(idx) {
            //if(idx=='1'||idx=='6'||idx=='7'){//789
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
        #ctl00_ContentPlaceHolder1_rdbIsLawE td {
            border: 0;
        }

        .auto-style2 {
            width: 85px;
        }

        .auto-style3 {
            width: 231px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>三级市场活动费用申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td>发文部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
                    <td class="auto-style2">发文编号</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApplyID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>发文日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                    <td>回复电话</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>文件主题</td>
                    <td colspan="3" class="tl PL10">
                        <asp:TextBox ID="txtSubject" runat="server" Width="465px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="vertical-align: central; padding-top: 15px;">申请内容</td>
                    <td colspan="3" style="padding: 5px; text-align: left; line-height: 30px;">所在部门：<asp:TextBox ID="txtInDepartment" runat="server"></asp:TextBox><br />
                        所属区域：<asp:DropDownList ID="ddlArea" runat="server" Width="150px">
                            <%--<asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">天河区</asp:ListItem>
                            <asp:ListItem Value="2">番禺区-叶</asp:ListItem>
                            <asp:ListItem Value="3">花都区</asp:ListItem>
                            <asp:ListItem Value="4">海珠区（含番禺-朱）</asp:ListItem>
                            <asp:ListItem Value="5">白云区（含芳村南海）</asp:ListItem>
                            <asp:ListItem Value="6">越秀区（含老荔湾战区）</asp:ListItem>
                            <asp:ListItem Value="7">工商铺（罗思源）</asp:ListItem>
                            <asp:ListItem Value="8">工商铺（直管）</asp:ListItem>
                            <asp:ListItem Value="9">工商铺（谢伟中）</asp:ListItem>--%>
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">大天河区</asp:ListItem>
                            <%--<asp:ListItem Value="2">番禺一部（禁用）</asp:ListItem>--%>
                            <asp:ListItem Value="2">大番禺区</asp:ListItem>
                            <asp:ListItem Value="3">花都区</asp:ListItem>
                            <%--<asp:ListItem Value="4">大海珠区（禁用）</asp:ListItem>--%>
                            <asp:ListItem Value="4">海珠东区</asp:ListItem>
                            <asp:ListItem Value="11">海珠西区</asp:ListItem>
                            <asp:ListItem Value="5">大白云区</asp:ListItem>
                            <asp:ListItem Value="6">大越秀区</asp:ListItem>
                            <asp:ListItem Value="7">工商铺一部</asp:ListItem>
                            <asp:ListItem Value="8">工商铺二部</asp:ListItem>
                            <%--<asp:ListItem Value="10">芳村南海区（禁用）</asp:ListItem>--%>
                            <%--<asp:ListItem Value="11">大番禺区</asp:ListItem>--%>
                            <%--<asp:ListItem Value="12">海珠东区</asp:ListItem>--%>
                            
                        </asp:DropDownList><br />
                        <span>申请内容</span><br />
                        所属年份：<asp:TextBox ID="txtYear" runat="server"></asp:TextBox><br />

                        周期选择： <span class="isCaseCycle">
                            <input type="radio" id="raCycle1" name="Cycle" value="1" onclick="onCycle(1)" /><label for="raCycle1"> 季度</label>
                            <input type="radio" id="raCycle2" name="Cycle" value="2" onclick="onCycle(2)" /><label for="raCycle2"> 半年度</label></span><br />
                        <input type="hidden" runat="server" id="hiCycle" />
                        <div id="Cycle1">
                            <asp:CheckBox ID="cbQuarter1" runat="server" Text="第一季度" OnCheckedChanged="cbQuarter1_CheckedChanged" />
                            月末在职人数<asp:TextBox ID="txtMan1" runat="server" Enabled="False"></asp:TextBox>人，费用<asp:TextBox ID="txtFear1" runat="server" Enabled="False" OnTextChanged="txtFear1_TextChanged"></asp:TextBox>元<br />
                            <asp:CheckBox ID="cbQuarter2" runat="server" Text="第二季度" OnCheckedChanged="cbQuarter2_CheckedChanged" />
                            月末在职人数<asp:TextBox ID="txtMan2" runat="server" Enabled="False"></asp:TextBox>人，费用<asp:TextBox ID="txtFear2" runat="server" Enabled="False" OnTextChanged="txtFear2_TextChanged"></asp:TextBox>元<br />
                            <asp:CheckBox ID="cbQuarter3" runat="server" Text="第三季度" OnCheckedChanged="cbQuarter3_CheckedChanged" />
                            月末在职人数<asp:TextBox ID="txtMan3" runat="server" Enabled="False"></asp:TextBox>人，费用<asp:TextBox ID="txtFear3" runat="server" Enabled="False" OnTextChanged="txtFear3_TextChanged"></asp:TextBox>元<br />
                            <asp:CheckBox ID="cbQuarter4" runat="server" Text="第四季度" OnCheckedChanged="cbQuarter4_CheckedChanged" />
                            月末在职人数<asp:TextBox ID="txtMan4" runat="server" Enabled="False"></asp:TextBox>人，费用<asp:TextBox ID="txtFear4" runat="server" Enabled="False" OnTextChanged="txtFear4_TextChanged"></asp:TextBox>元<br />
                            合计费用：
                            <asp:Label ID="lbAutoCoculate" runat="server">0</asp:Label>&nbsp;元<br />
                        </div>
                        <div id="Cycle2">
                            <asp:CheckBox ID="cbUpYear" runat="server" Text="上半年度" />
                            月末在职人数<asp:TextBox ID="txtMan5" runat="server" Enabled="False"></asp:TextBox>人，费用<asp:TextBox ID="txtFear5" runat="server" Enabled="False" OnTextChanged="txtFear1_TextChanged"></asp:TextBox>元<br />
                            <asp:CheckBox ID="cbLoYear" runat="server" Text="下半年度" />
                            月末在职人数<asp:TextBox ID="txtMan6" runat="server" Enabled="False"></asp:TextBox>人，费用<asp:TextBox ID="txtFear6" runat="server" Enabled="False" OnTextChanged="txtFear2_TextChanged"></asp:TextBox>元<br />
                            合计费用：
                            <asp:Label ID="lbYearAutoCoculate" runat="server">0</asp:Label>&nbsp;元<br />
                        </div>
                        <span style="vertical-align: top; margin-top: 10px;">其他情况说明
                        </span>
                        <asp:TextBox ID="txtSummary" runat="server" Height="150px" TextMode="MultiLine" Width="82%"></asp:TextBox>
                        <br />
                        <%--  费用报销标准：（GZ-HR-R1-1307-004）--%>

                        <%--    <table style="border-collapse: collapse; line-height: 20px; text-align: center;" align="center" width="500">
                            <tr>
                                <td>区域人数/人<br />（当季月末在职人数）</td>
                                <td>补贴限额/元</td>
                            </tr>
                            <tr>
                                <td>X≤200</td>
                                <td>5,000</td>
                            </tr>
                            <tr>
                                <td>200&lt;X≤400</td>
                                <td>8,000</td>
                            </tr>
                            <tr>
                                <td>400&lt;X≤600</td>
                                <td>11,000</td>
                            </tr>
                            <tr>
                                <td>600&lt;X≤800</td>
                                <td>15,000</td>
                            </tr>
                            <tr>
                                <td>800&lt;X≤1000</td>
                                <td>16,000</td>
                            </tr>
                            <tr>
                                <td>1000&lt;X</td>
                                <td>18,000</td>
                            </tr>
                        </table>--%>
                        <%--1）三级市场半年度费用标准--%>
                        1）大战区半年度费用标准
                        <table style="border-collapse: collapse; line-height: 20px; text-align: center;" align="center" width="500">
                            <tr>
                                <%--<td rowspan="2">区域人数/人<br />
                                    （当季月末在职人数）</td>--%>
                                <td rowspan="2">大战区人数<br />
                                    （周期末在职人数）</td>
                                <td colspan="2">场租上限</td>
                                <td colspan="2">奖项制作费用上限</td>
                                <td colspan="2">会后餐费津贴上限</td>
                                <td colspan="2">合计建议</td>
                            </tr>
                            <tr>
                                <td>季度</td>
                                <td>半年度</td>
                                <td>季度</td>
                                <td>半年度</td>
                                <td>季度</td>
                                <td>半年度</td>
                                <td>季度</td>
                                <td>半年度</td>
                            </tr>
                            <tr>
                                <td>X≤200</td>
                                <td colspan="2">—— </td>
                                <td rowspan="3">1,500</td>
                                <td rowspan="3">3,000</td>
                                <td>1,500</td>
                                <td>3,000</td>
                                <td>3,000</td>
                                <td>6,000</td>
                            </tr>
                            <tr>
                                <td>200&lt;X≤400</td>
                                <td>3,500</td>
                                <td>7,000</td>
                                <td>3,000</td>
                                <td>6,000</td>
                                <td>8,000</td>
                                <td>16,000</td>
                            </tr>
                            <tr>
                                <td>400&lt;X≤600</td>
                                <td>5,000</td>
                                <td>10,000</td>
                                <td>4,500</td>
                                <td>9,000</td>
                                <td>11,000</td>
                                <td>22,000</td>
                            </tr>
                            <tr>
                                <td>600&lt;X≤800</td>
                                <td>6,000</td>
                                <td>12,000</td>
                                <td rowspan="3">3,000</td>
                                <td rowspan="3">6,000</td>
                                <td rowspan="3">6,000</td>
                                <td rowspan="3">12,000</td>
                                <td>15,000</td>
                                <td>30,000</td>
                            </tr>
                            <tr>
                                <td>800&lt;X≤1000</td>
                                <td>7,000</td>
                                <td>14,000</td>
                                <td>16,000</td>
                                <td>32,000</td>
                            </tr>
                            <tr>
                                <td>X>1000</td>
                                <td>9,000</td>
                                <td>18,000</td>
                                <td>18,000</td>
                                <td>36,000</td>
                            </tr>
                            <tr>
                                <td colspan="9" style="text-align: left; padding-left: 10px">备注：<br />
                                    1、会议原则上按半年度周期进行，如区域会议按季度为周期举办的，则按季度合计标准进行报销，如按半年度为标准举办的，则按半年度标准进行报销。所有费用凭发票实报实销，报销金额不超过费用上限。<br />
                                    2、工商铺部以整体为单位举办会议，按本规则执行。
                                </td>
                            </tr>
                        </table>
                        <%--2）总监团队会议（季度）--%>
                         2）小战区/工商铺区域营业总监季度费用标准
                         <table style="border-collapse: collapse; line-height: 20px; text-align: center;" align="center" width="500">
                             <tr>
                                 <td>旗下团队人数<br />
                                     （入职人员+劳务人员）
                                 </td>
                                 <td>场租上限</td>
                                 <td>奖项制作费用上限</td>
                                 <td>合计建议</td>
                             </tr>
                             <%--<tr>
                                 <td>120≤X≤150</td>
                                 <td>—— </td>
                                 <td rowspan="3">1500</td>
                                 <td>1,500</td>
                             </tr>
                             <tr>
                                 <td>151≤X≤299</td>
                                 <td>3,500</td>
                                 <td>5,000</td>
                             </tr>
                             <tr>
                                 <td>300≤X≤500</td>
                                 <td>5,000</td>
                                 <td>6,500</td>
                             </tr>--%>
                             <tr>
                                 <td>100≤X≤150</td>
                                 <td>—— </td>
                                 <td rowspan="2">1500</td>
                                 <td>1,500</td>
                             </tr>
                             <tr>
                                 <td>151≤X≤299</td>
                                 <td>3,500</td>
                                 <td>5,000</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="text-align: left; padding-left: 10px">备注:<br />
                                     1、所有费用凭发票实报实销，报销金额不超过费用上限。
                                     <br />
                                     2、工商铺部以区域营业总监层级为单位举办会议的，按本规则执行。
                                 </td>
                             </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td>上传附件</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">1、季会议程（必须上传）；2、获奖名单；3、其他。
   　  　   　　　　　　<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 380px;">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>

                <tr id="trManager3" class="noborder" style="height: 85px;">
                    <td class="auto-style2">部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td rowspan="2" class="auto-style2">人力资源部</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" />
                        <label for="rdbYesIDx3">同意</label>
                        <input id="rdbNoIDx3" type="radio" name="agree3" />
                        <label for="rdbNoIDx3">不同意</label>
                        <input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>
                <%--<tr class="noborder" style="height:85px;display:none">
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx4" type="radio" name="agree4"/>
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
					</td>
				</tr>--%>
                <tr class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx5">_________</span>
                        </span>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td rowspan="2">财务部</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                        <asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton>
                        <asp:LinkButton ID="lbtnAddNManaging" runat="server" OnClick="lbtnAddNManaging_Click" Visible="False">添加董事总经理审批</asp:LinkButton>
                        <asp:LinkButton ID="lbtnCancelManaging" runat="server" OnClick="lbtnCancelManaging_Click" Visible="False">取消董事总经理审批</asp:LinkButton>
                        <br />
                        <textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx6">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><br />
                        <textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx7">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="tr1" class="noborder" style="height: 85px;">
                    <td class="auto-style2">董事总经理</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx20" type="radio" name="agree20" /><label for="rdbYesIDx20">同意</label><input id="rdbNoIDx20" type="radio" name="agree20" /><label for="rdbNoIDx20">不同意</label><br />
                        <textarea id="txtIDx20" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx20" value="签名" onclick="sign('20')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx20">_________</span>
                        </span>
                    </td>
                </tr>
            </table>
            <!--打印正文结束-->
        </div>

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
            </asp:GridView>
            <div id="PageBottom">
                <span id="spm" style="display: none">您已上传了：</span><br />
                <hr />
                <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />

                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />

                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />
                <input type="hidden" id="hdDetail" runat="server" />
                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
            </div>
        </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

