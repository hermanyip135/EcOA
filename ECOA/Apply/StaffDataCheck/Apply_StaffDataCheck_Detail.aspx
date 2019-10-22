<%@ Page Title="六级及以上营业人员入职资料核查表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_StaffDataCheck_Detail.aspx.cs" Inherits="Apply_StaffDataCheck_Apply_StaffDataCheck_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../../Script/common.js"></script>
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;//当前行数
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
        $(function() {      
            $("#<%=txtDepartment.ClientID %>").autocomplete({ source: jJSON});
            $("#<%=txtOldDepartment.ClientID %>").autocomplete({ source: jJSON});
            $("#<%=txtApplyName.ClientID %>").autocomplete({ source: jJSONF});
            $("#<%=txtDirectors.ClientID %>").autocomplete({ source: jJSONF});
            $("#<%=txtOldDirectors.ClientID %>").autocomplete({ source: jJSONF});

            $("#<%=txtEntryDate.ClientID%>").datepicker();
            $("#<%=txtDataTurnDate.ClientID%>").datepicker();  
            $("#<%=txtOldEntryDate.ClientID%>").datepicker();
            $("#<%=txtOldLeaveDate.ClientID%>").datepicker();

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
            $("#<%=rdbAgain1.ClientID%>").click(function(){
                $(".zyhistory").show();
            });
            $("#<%=rdbAgain2.ClientID%>").click(function(){
                $(".zyhistory").hide();
                showORHide("2");
                $("#<%=txtOldDepartment.ClientID%>").val("");
                $("#<%=txtOldPosition.ClientID%>").val("");
                $("#<%=txtOldDirectors.ClientID%>").val("");
                $("#<%=txtOldEntryDate.ClientID%>").val("");
                $("#<%=txtOldLeaveDate.ClientID%>").val("");
                $("#<%=txtLeaveType.ClientID%>").val("");
                $("#<%=txtEntryInfo.ClientID%>").val("");
                $("#<%=txtEliteSituation.ClientID%>").val("");
                $("#<%=txtRulesSituation.ClientID%>").val("");
                $("#rdbFour1").removeAttr("checked");
                $("#rdbFour2").removeAttr("checked");
            });

            $("#<%=txtAchievement1.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
            $("#<%=txtAchievement2.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
            $("#<%=txtAchievement3.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
            $("#<%=txtAchievement4.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
            $("#<%=txtAchievement5.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
            $("#<%=txtAchievement6.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});


            $("#<%=txtResultAchievement1.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
            $("#<%=txtResultAchievement2.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
            $("#<%=txtResultAchievement3.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
            $("#<%=txtResultAchievement4.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
            $("#<%=txtResultAchievement5.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
            $("#<%=txtResultAchievement6.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
           
        });

        //自动合计
        function Caculate1()
        {
            var sum=0;
            $("#tbAround input[id*='txtAchievement']").each(function(){
                if(this.value != "" && $(this).attr('id')!='<%=txtAchievementSum.ClientID%>')
                {
                    sum += this.value*1;
                }
            });
            $("#<%=txtAchievementSum.ClientID%>").val(sum.toFixed(2));
        }
        function Caculate2()
        {
            var sum=0;
            $("#tbAround input[id*='txtResultAchievement']").each(function(){
                if(this.value != "" && $(this).attr('id')!='<%=txtResultAchievementSum.ClientID%>')
                {
                    sum += this.value*1;
                }
            });
            $("#<%=txtResultAchievementSum.ClientID%>").val(sum.toFixed(2));
        }
       
        function check()
        {
            if($.trim($("#<%=txtApplyName.ClientID %>").val())=="") {alert("申请人姓名不可为空！");$("#<%=txtApplyName.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {alert("拟入职部门不可为空！");$("#<%=txtDepartment.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtPosition.ClientID %>").val())=="") {alert("拟入职申请职位不可为空！");$("#<%=txtPosition.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtEntryDate.ClientID %>").val())=="") {alert("拟入职日期不可为空！");$("#<%=txtEntryDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtDataTurnDate.ClientID %>").val())=="") {alert("资料递交日期不可为空！");$("#<%=txtDataTurnDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtPay.ClientID %>").val())=="") {alert("薪酬不可为空！");$("#<%=txtPay.ClientID %>").focus();return false;}
            if (!$("#<%=rdbAgain1.ClientID %>").prop("checked") && !$("#<%=rdbAgain2.ClientID %>").prop("checked")) {alert("请选择是否再次入职");$("#<%=rdbAgain1.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtDirectors.ClientID %>").val())=="") {alert("上级主管不可为空！");$("#<%=txtDirectors.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtInfoSource.ClientID %>").val())=="") {alert("招聘来源不可为空！");$("#<%=txtInfoSource.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtTeam.ClientID %>").val())=="") {alert("入职后带领团队不可为空！");$("#<%=txtTeam.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtExpertNum.ClientID %>").val())=="") {alert("行家过档人数不可为空！");$("#<%=txtExpertNum.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtExpertFourNum.ClientID %>").val())=="") {alert("过档人员中4级及以上人数不可为空！");$("#<%=txtExpertFourNum.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtInfoProvider.ClientID %>").val())=="") {alert("信息提供人不可为空！");$("#<%=txtInfoProvider.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtOtherRemark.ClientID %>").val())=="") {alert("其他情况备注不可为空！");$("#<%=txtOtherRemark.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtBrokerCertificate.ClientID %>").val())=="") {alert("经纪证号码不可为空！");$("#<%=txtBrokerCertificate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtEmployer.ClientID %>").val())=="") {alert("经纪证挂靠单位不可为空！");$("#<%=txtEmployer.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {alert("联系电话不可为空！");$("#<%=txtPhone.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtUrgentPhone.ClientID %>").val())=="") {alert("紧急联系人/电话不可为空！");$("#<%=txtUrgentPhone.ClientID %>").focus();return false;}
            var data;
            array = new Array();
            $("[id*=company]").each(function(){
                var DepartmentResult = ($(this).find("[id*=rdbDepartment1]").prop('checked')?"1":$(this).find("[id*=rdbDepartment2]").prop('checked')?"2":$(this).find("[id*=rdbDepartment3]").prop('checked')?"3":"0");
                var PositionResult = ($(this).find("[id*=rdbPosition1]").prop('checked')?"1":$(this).find("[id*=rdbPosition2]").prop('checked')?"2":$(this).find("[id*=rdbPosition3]").prop('checked')?"3":"0");
                var PositionDateResult = ($(this).find("[id*=rdbPositionDate1]").prop('checked')?"1":$(this).find("[id*=rdbPositionDate2]").prop('checked')?"2":$(this).find("[id*=rdbPositionDate3]").prop('checked')?"3":"0");
                var LeaveReasonResult = ($(this).find("[id*=rdbLeaveReason1]").prop('checked')?"1":$(this).find("[id*=rdbLeaveReason2]").prop('checked')?"2":$(this).find("[id*=rdbLeaveReason3]").prop('checked')?"3":"0");
                var Misdeeds = ($(this).find("[id*=rdbMisdeeds1]").prop('checked')?"1":$(this).find("[id*=rdbMisdeeds2]").prop('checked')?"2":"0");
                //var Ability="0";
                //if($(this).find("[id*=rdbAbility1]").prop('checked')||$(this).find("[id*=rdbAbility2]").prop('checked')||$(this).find("[id*=rdbAbility3]").prop('checked'))
                //{
                //    Ability = ($(this).find("[id*=rdbAbility1]").prop('checked')?"1":$(this).find("[id*=rdbAbility2]").prop('checked')?"2":"3");
                //}else if($(this).find("[id*=rdbAbility4]").prop('checked')||$(this).find("[id*=rdbAbility5]").prop('checked'))
                //{
                //    Ability = ($(this).find("[id*=rdbAbility4]").prop('checked')?"4":"5");
                //}
                data = {OfficeAutomation_Document_StaffDataCheck_Detail_Company: $(this).find("[id*=txtCompany]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_ProviderPosition:$(this).find("[id*=txtProviderPosition]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_Provider:$(this).find("[id*=txtProvider1]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_Phone:$(this).find("[id*=txtDetailPhone]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_Department:$(this).find("[id*=txtDetailDepartment1]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentResult:DepartmentResult,
                    OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentRemark:$(this).find("[id*=txtDepartmentRemark]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_Position:$(this).find("[id*=txtDetailPosition]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_PositionResult:PositionResult,
                    OfficeAutomation_Document_StaffDataCheck_Detail_PositionRemark:$(this).find("[id*=txtPositionRemark]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_PositionDate:$(this).find("[id*=txtPositionDate1]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateResult:PositionDateResult,
                    OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateRemark:$(this).find("[id*=txtPositionDateRemark]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReason:$(this).find("[id*=txtLeaveReason1]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonResult:LeaveReasonResult,
                    OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonRemark:$(this).find("[id*=txtLeaveReasonRemark]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_Misdeeds:Misdeeds,
                    OfficeAutomation_Document_StaffDataCheck_Detail_MisdeedsRemark:$(this).find("[id*=txtMisdeedsRemark]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_Performance:$(this).find("[id*=txtPerformance]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_PerformanceRemark:$(this).find("[id*=txtPerformanceRemark]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDate:$(this).find("[id*=txtTeamNumAndDate1]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDateRemark:$(this).find("[id*=txtTeamNumAndDateRemark]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_Ability:$(this).find("[id*=txtAbility]").val(),
                    OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDateRemark:$(this).find("[id*=txtAbilityRemark]").val()
                };
                array.push(data)
            });
            $("#<%=this.hidDetail.ClientID%>").val(Obj2str(array));     //common.js 方法
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
                window.location='Apply_StaffDataCheck_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_StaffDataCheck_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
            if(win=='success')
                window.location="Apply_StaffDataCheck_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }
		
                function sign(idx) {
            
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
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    async: false,
                    cache: false,
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+10,
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
        }//987
        function DeleteT() { //20141231：M_DeleteC
            $("#btnADelete").hide();
            var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
            if(sReturnValue=='deleted')
                window.location='/Apply/Apply_Search.aspx';
            else
                window.location.href=window.location.href;
        }
        //添加公司
        function addCompany(id)
        {
            //$("#tbAround4").append($("#company").clone());
            i=$("#tbAround4 tbody").length;
            var html ='<tbody id="company'+ i +'">'                          
                    + '      <tr>'
                    +'            <td class="auto-style4">公司名称'+i+'</td>'
                    +'            <td class="tl PL10" colspan="5"><input id="txtCompany'+i+'" type="text" style="width:200px" /></td>'
                    +'        </tr>'
                    +'         <tr>'

                    +'            <td class="auto-style4">信息提供人</td>'
                    +'            <td class="tl PL10"><input id="txtProvider1'+i+'" type="text" style="width:100px" /></td>'
                    +'            <td class="auto-style4" style="width:88px;">信息提供人职位</td>'
                    +'            <td class="tl PL10" ><input id="txtProviderPosition'+i+'" type="text" style="width:100px" /></td>'
                  
                    +'            <td class="auto-style4">联系电话</td>'
                    +'            <td class="tl PL10"><input id="txtDetailPhone'+i+'" type="text" style="width:100px" /></td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'            <td class="auto-style4" colspan="6">调查内容</td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'            <td class="auto-style4"  colspan="4">候选人提供信息</td>'
                    +'            <td class="auto-style4"  colspan="2">核查结果</td>'
                    +'        </tr>'
					+'		<tr>'
                    +'            <td class="auto-style4">就职部门</td>'
                    +'            <td class="tl PL10" colspan="3"><input id="txtDetailDepartment1'+i+'" type="text" style="width:200px" /></td>'
                    +'            <td class="tl PL10" colspan="2">'
                    +'                <label><input id="rdbDepartment1'+i+'" name="rdbDepartment'+i+'" type="radio" value="1" />无差异 </label> '
                    +'                <label><input id="rdbDepartment2'+i+'" name="rdbDepartment'+i+'" type="radio" value="2" />有差异 </label>'
                    +'                <label style="display:none;"><input id="rdbDepartment3'+i+'" name="rdbDepartment'+i+'" type="radio" value="3" />其它</label>'
                    +'                <input id="txtDepartmentRemark'+i+'" type="text" style="width:130px" />'
                    +'            </td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'            <td class="auto-style4">职位</td>'
                    +'            <td class="tl PL10" colspan="3"><input id="txtDetailPosition'+i+'" type="text" style="width:200px" /></td>'
                    +'            <td class="tl PL10" colspan="2">'
                    +'                <label><input id="rdbPosition1'+i+'" name="rdbPosition'+i+'" type="radio" value="1" />无差异</label>'
                    +'                <label><input id="rdbPosition2'+i+'" name="rdbPosition'+i+'" type="radio" value="2" />有差异 </label>'
                    +'                <label style="display:none;"><input id="rdbPosition3'+i+'" name="rdbPosition'+i+'" type="radio" value="3" />其它</label>'
                    +'                <input id="txtPositionRemark'+i+'" type="text" style="width:130px" />'
                    +'            </td>'
                    +'        </tr>'                           
                    +'        <tr>'
                    +'            <td class="auto-style4" >任职时间</td>'
                    +'            <td class="tl PL10" colspan="3"><input id="txtPositionDate1'+i+'" type="text" style="width:200px" /></td>'
                    +'            <td class="tl PL10" colspan="2">'
                    +'                <label><input id="rdbPositionDate1'+i+'" name="rdbPositionDate'+i+'" type="radio" value="1" />无差异 </label>'
                    +'                <label><input id="rdbPositionDate2'+i+'" name="rdbPositionDate'+i+'" type="radio" value="2" />有差异 </label>'
                    +'                <label style="display:none;"><input id="rdbPositionDate3'+i+'" name="rdbPositionDate'+i+'" type="radio" value="3" />其它</label>'
                    +'                <input id="txtPositionDateRemark'+i+'" type="text" style="width:130px" />'
                    +'            </td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'            <td class="auto-style4">离职原因</td>'
                    +'            <td class="tl PL10" colspan="3"><input id="txtLeaveReason1'+i+'" type="text" style="width:200px" /></td>'
                    +'            <td class="tl PL10" colspan="2">'
                    +'                <label><input id="rdbLeaveReason1'+i+'" name="rdbLeaveReason'+i+'" type="radio" value="1" />无差异 </label>'
                    +'                <label><input id="rdbLeaveReason2'+i+'" name="rdbLeaveReason'+i+'" type="radio" value="2" />有差异 </label>'
                    +'                <label style="display:none;"><input id="rdbLeaveReason3'+i+'" name="rdbLeaveReason'+i+'" type="radio" value="3" />其它</label>'
                    +'                <input id="txtLeaveReasonRemark'+i+'" type="text" style="width:130px" />'
                    +'            </td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'           <td class="auto-style4" colspan="4"><b>信息提供人对候选人评价</b></td>'
                    +'           <td class="auto-style4" colspan="2"><b>人力资源部补充意见</b></td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'            <td class="auto-style4">是否有违规行为</td>'                    
                    +'            <td class="tl PL10" colspan="3">'
                    +'                <label><input id="rdbMisdeeds1'+i+'" name="rdbMisdeeds'+i+'" type="radio" value="1" />是 </label>'
                    +'                <label><input id="rdbMisdeeds2'+i+'" name="rdbMisdeeds'+i+'" type="radio" value="2" />否 </label>'
                    +'            </td>'
                    +'            <td class="tl PL10" colspan="2"><input id="txtMisdeedsRemark'+i+'" type="text" style="width:260px" /></td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'            <td class="auto-style4">业绩情况</td>'                    
                    +'            <td class="tl PL10" colspan="3">'
                    +'                  <input id="txtPerformance' + i + '" type="text" style="width:260px" />'
                    +'            </td>'
                    +'            <td class="tl PL10" colspan="2"><input id="txtPerformanceRemark'+i+'" type="text" style="width:260px" /></td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'            <td class="auto-style4" style="width:100px;">带团队规模及时间</td>'                    
                    +'            <td class="tl PL10" colspan="3">'
                    +'               <input id="txtTeamNumAndDate1'+i+'" type="text" style="width:260px" />'
                    +'            </td>'
                    +'            <td class="tl PL10" colspan="2"><input id="txtTeamNumAndDateRemark'+i+'" type="text" style="width:260px" /></td>'
                    +'        </tr>'
                    +'        <tr>'
                    +'            <td class="auto-style4">团队管理能力</td>'                    
                    +'            <td class="tl PL10" colspan="3">'
                    +'                <input id="txtAbility' + i + '" type="text" style="width:260px" />'
                    +'            </td>'
                    +'            <td class="tl PL10" colspan="2"><input id="txtAbilityRemark'+i+'" type="text" style="width:260px" /></td>'
                    +'        </tr>'
                    +'        </tbody>'
            $("#tbAround4").append(html);
        }
        //删除公司
        function delCompany(id)
        {
            $tbody = $("#" + id + " tbody");
            if ($tbody.length == 2) {
                alert("已经最后一栏,不能再删了");
                return;
            }
            $tbody.last().remove();
        }

        //显示隐藏四级及以上营业人员业绩
        function showORHide(values)
        {
            if(values=="1")
            {
                $(".Achievement").show();
            }else if(values=="2")
            {
                $(".Achievement").hide();
                $("#<%=txtAcountProfit.ClientID%>").val("");
                $("#<%=txtMonth1.ClientID%>").val("");
                $("#<%=txtAchievement1.ClientID%>").val("");
                $("#<%=txtResultAchievement1.ClientID%>").val("");
                $("#<%=txtMonth2.ClientID%>").val("");
                $("#<%=txtAchievement2.ClientID%>").val("");
                $("#<%=txtResultAchievement2.ClientID%>").val("");
                $("#<%=txtMonth3.ClientID%>").val("");
                $("#<%=txtAchievement3.ClientID%>").val("");
                $("#<%=txtResultAchievement3.ClientID%>").val("");
                $("#<%=txtMonth4.ClientID%>").val("");
                $("#<%=txtAchievement4.ClientID%>").val("");
                $("#<%=txtResultAchievement4.ClientID%>").val("");
                $("#<%=txtMonth5.ClientID%>").val("");
                $("#<%=txtAchievement5.ClientID%>").val("");
                $("#<%=txtResultAchievement5.ClientID%>").val("");
                $("#<%=txtMonth6.ClientID%>").val("");
                $("#<%=txtAchievement6.ClientID%>").val("");
                $("#<%=txtResultAchievement6.ClientID%>").val("");
                $("#<%=txtAchievementSum.ClientID%>").val("");
                $("#<%=txtResultAchievementSum.ClientID%>").val("");
            }
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
            <h1>六级及以上营业人员入职资料核查表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 800px; margin: 0 auto;"></div>
            <div id="Div1" style="width:800px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='800px'>
                 <!--员工申请信息表end-->
                <tr>
                    <td colspan="6" class="auto-style4"  style="font-size:16px"><b>员工申请信息</b></td>
                </tr>
                <tr>
                    <td class="auto-style4">申请人姓名</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtApplyName" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td class="auto-style4">拟入职部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="100"></asp:TextBox>
                    </td>
                    <td class="auto-style4">拟入职申请职位</td>
                    <td class="tl PL10">
                         <asp:TextBox ID="txtPosition" runat="server" Width="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">拟入职日期</td>
                    <td class="tl PL10">
                         <asp:TextBox ID="txtEntryDate" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td class="auto-style4">资料递交日期</td>
                    <td class="tl PL10">
                         <asp:TextBox ID="txtDataTurnDate" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4">薪酬</td>
                    <td class="tl PL10">
                         <asp:TextBox ID="txtPay" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">是否再次入职</td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbAgain1" runat="server" Text="是" GroupName="rdbAgain"  />
                        <asp:RadioButton ID="rdbAgain2" runat="server" Text="否" GroupName="rdbAgain" />
                    </td>
                    <td class="auto-style4">上级主管</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDirectors" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4">招聘来源</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtInfoSource" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <!--员工申请信息表end-->

                <!--人员架构规模-->
                <tr>
                    <td class="auto-style4" colspan="6" style="font-size: 16px"><b>人员架构规模</b></td>
                </tr>
                <tr>
                    <td class="auto-style4">入职后带领团队</td>
                    <td class="tl PL10" colspan="5">
                         <asp:TextBox ID="txtTeam" runat="server" Width="550"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td class="auto-style4">团队人数</td>
                    <td class="tl PL10" colspan="5">
                         <asp:TextBox ID="txtTeamNum" runat="server" Width="150"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">行家过档人数</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtExpertNum" runat="server" Width="150"></asp:TextBox></td>
                    <td class="auto-style4">过档人员中4级及以上人数</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtExpertFourNum" runat="server" Width="210"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">信息提供人</td>
                    <td class="tl PL10" colspan="5">
                        <asp:TextBox ID="txtInfoProvider" runat="server" Width="150"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">其他情况备注</td>
                    <td class="tl PL10" colspan="5">
                        <asp:TextBox ID="txtOtherRemark" runat="server" Width="550"></asp:TextBox></td>
                </tr>
                 <!--人员架构规模end-->

                 <!--员工基本信息-->
                <tr>
                    <td class="auto-style4" colspan="6" style="font-size: 16px"><b>员工基本信息</b></td>
                </tr>
                <tr>
                    <td class="auto-style4">经纪证号码</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtBrokerCertificate" runat="server" Width="150"></asp:TextBox></td>
                    <td class="auto-style4">经纪证挂靠单位</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtEmployer" runat="server" Width="210"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">联系电话</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtPhone" runat="server" Width="150"></asp:TextBox></td>
                    <td class="auto-style4">紧急联系人/电话</td>
                    <td class="tl PL10" colspan="3">
                       <asp:TextBox ID="txtUrgentPhone" runat="server" Width="210"></asp:TextBox></td>
                </tr>
                <!--员工基本信息end-->

                 <!--背景调查问题-->
                <tr>
                    <td colspan="6">
                         <table id="tbAround4" width='700px'>
                            <tr>
                                <td class="auto-style4" colspan="6" style="font-size:16px"><b>背景调查问题</b></td>
                            </tr>
                            <%=SbDetailHtml.ToString() %>
                           </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: left">
                        <input class="btnaddRow" type="button" value="添加公司" onclick="addCompany('company'); return false;" />
                        <input class="btnaddRow" type="button" value="删除公司" onclick="delCompany('tbAround4'); return false;" />
                        <asp:HiddenField ID="hidDetail" runat="server" />
                    </td>
                </tr>               
                 <!--背景调查问题end-->

                <!--中原任职历史信息（再次入职者情况核查）-->
                <tr class="zyhistory">
                    <td class="auto-style4" colspan="6" style="font-size: 16px;"><b>中原任职历史信息（再次入职者情况核查）</b></td>
                </tr>
                <tr class="zyhistory">
                    <td class="auto-style4">原任职部门</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtOldDepartment" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4">原任职职位</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtOldPosition" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4">原直属主管</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtOldDirectors" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="zyhistory">
                    <td class="auto-style4">原入职日期</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtOldEntryDate" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4">原离职日期</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtOldLeaveDate" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4">离职性质</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtLeaveType" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="zyhistory">
                    <td class="auto-style4" rowspan="3">任职历史</td>
                    <td class="tl PL10" rowspan="3" colspan="3">
                        <asp:textbox id="txtEntryInfo" runat="server" Width="90%" Height="50px" TextMode="MultiLine"></asp:textbox></td>
                </tr>
                <tr class="zyhistory">
                    <td class="auto-style4">精英会情况</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtEliteSituation" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="zyhistory">
                    <td class="auto-style4">违规情况</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtRulesSituation" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="zyhistory">
                    <td class="auto-style4" colspan="2">是否为4级及以上营业员</td>
                    <td class="tl PL10" colspan="4">
                        <label><input id="rdbFour1" type="radio" name="rdbFour" value="1" onclick="showORHide('1')"/>是</label>
                        <label><input id="rdbFour2" type="radio" name="rdbFour" value="2" onclick="showORHide('2')"/>否</label>
                    </td>
                </tr>
                <tr class="Achievement">
                    <td class="auto-style4" colspan="4"><b>4级及以上营业员离职前6个月业绩情况</b></td>
                    <td class="auto-style4">管理帐利润</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtAcountProfit" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="Achievement">
                    <td class="auto-style4" colspan="2">月份</td>
                    <td class="auto-style4" colspan="2">应收业绩</td>
                    <td class="auto-style4" colspan="2">实收业绩</td>
                </tr>
                <tr class="Achievement">
                    <td class="auto-style4" colspan="2">
                       <asp:TextBox ID="txtMonth1" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtAchievement1" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtResultAchievement1" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="Achievement">
                   <td class="auto-style4" colspan="2">
                       <asp:TextBox ID="txtMonth2" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtAchievement2" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtResultAchievement2" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="Achievement">
                  <td class="auto-style4" colspan="2">
                       <asp:TextBox ID="txtMonth3" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtAchievement3" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtResultAchievement3" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="Achievement">
                    <td class="auto-style4" colspan="2">
                       <asp:TextBox ID="txtMonth4" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtAchievement4" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtResultAchievement4" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="Achievement">
                   <td class="auto-style4" colspan="2">
                       <asp:TextBox ID="txtMonth5" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtAchievement5" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtResultAchievement5" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="Achievement">
                   <td class="auto-style4" colspan="2">
                       <asp:TextBox ID="txtMonth6" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtAchievement6" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="txtResultAchievement6" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <tr class="Achievement">
                    <td class="auto-style4" colspan="2" style="font-size: 16px">合计</td>
                    <td class="auto-style4">应收业绩合计</td>
                    <td>
                         <asp:TextBox ID="txtAchievementSum" runat="server" Width="100"></asp:TextBox></td>
                    <td class="auto-style4">实收业绩合计</td>
                    <td>
                         <asp:TextBox ID="txtResultAchievementSum" runat="server" Width="100"></asp:TextBox></td>
                </tr>
                <!--中原任职历史信息（再次入职者情况核查）end-->
                
                  <!--其他差异情况补充-->
                <tr>
                    <td class="auto-style4" colspan="6" style="font-size: 16px"><b>备注</b></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="6" style="font-size: 16px">
                        <asp:textbox id="txtDifferenceSituation" runat="server" Width="90%" Height="50px" TextMode="MultiLine"></asp:textbox>
                    </td>
                </tr>
                  <!--其他差异情况补充end-->

                <tr><th colspan="6" style="line-height:25px;">审批流程</th></tr>
                <tr id="trManager1" class="noborder" style="height: 85px;">
                    <td >资料核查人</td>
                    <td colspan="5" class="tl PL10" style=" ">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
               <%-- <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td >资料复核人</td>
                    <td colspan="5" class="tl PL10" style=" ">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>--%>
                 <tr id="trShowFlow6" class="noborder" style="height: 85px;"> 
                    <td>人力资源部</td>                                                                                                           
                    <td colspan="5" class="tl PL10" style=" ">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><br />
                        <textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow7" class="noborder" style="height: 85px;">
                    <td>区域负责人</td>    
                    <td colspan="5" class="tl PL10" style=" ">
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><br />
                        <textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
                    </td>
                </tr>
                <%=SbHtmlLogisticsFlow.ToString()%>
                <tr id="trShowFlow10" class="noborder" style="height: 85px;"> 
                    <td>后勤事务部<br />
                        <%--<asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />--%>
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>                                                                                                           
                    <td colspan="5" class="tl PL10" style=" ">
                        <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx7">不同意</label><br />
<%--                        <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">确认</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">退回申请</label><br />--%>
                        <textarea id="txtIDx10" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx10">_________</span>
                        </span>
                    </td>
                </tr>
                <tr><td style="line-height: 0px"></td><td colspan="6" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="6" id="trtpdf" style="line-height: 0px"></td></tr>
                <tr id="trGeneralManager" class="noborder" style="height: 85px; ">
                    <td >董事总经理<br />审批</td>
                    <td colspan="5" class="tl PL10" style=" ">
                        <input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label><input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label>
                        <input id="rdbOtherIDx12" type="radio" name="agree12" /><label for="rdbOtherIDx12">其他意见</label><br />
                        <textarea id="txtIDx12" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx12">_________</span>
                        </span>
                    </td>
                </tr>
            </table>
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
        <span>六级及以上背景调查电子表20161019版</span><br/><br/>
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>
        <asp:button runat="server" id="btnSave" text="保存" OnClick="btnSave_Click"  onclientclick="return check();" visible="false" />
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
            <input type="hidden" id="hdLogisticsFlow" runat="server" />
            <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <%=SbHtml.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>
