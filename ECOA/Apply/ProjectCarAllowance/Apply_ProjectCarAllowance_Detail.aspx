<%@ Page ValidateRequest="false" Title="小汽车津贴申请表（项目部） - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ProjectCarAllowance_Detail.aspx.cs" Inherits="Apply_ProjectCarAllowance_Apply_ProjectCarAllowance_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=SbJson.ToString() %>;
        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        $(function() {      
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

            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function() {}
            });

            $("#<%=txtEntryDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });

            $("#<%=txtEffectiveDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true,hideIfNoPrevNext: true,
                minDate:0,
                onSelect:function()
                {
                    $(this).val($(this).val().replace(/-\d\d$/,"-01"));
                }
            });

            $("#<%=rdbIsPositive2.ClientID%>").on("click",function(){
                alert("资格不符，请转正后再根据实际情况申请。");
            });

            $("#rdbYesIDx16").on("click",function(){
                $("#divAgreeMoneyGrade").show();
            });

            $("#rdbNoIDx16").on("click",function(){
                $("#divAgreeMoneyGrade").hide();
                $("#<%=rblAgreeMoneyGrade.ClientID%> :radio").removeAttr("checked");
            });

            $("#<%=rblAgreeMoneyGrade.ClientID%> :radio").on("click",function(){
                if($(this).prop("checked"))
                {
                    $("#<%=hdAgreeMoneyGradeID.ClientID%>").val($(this).val());
                }
            });

            if($("#rdbYesIDx16").prop("checked")){
                $("#divAgreeMoneyGrade").show();
            }
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function check() {
            if($("#<%=rdbIsPositive2.ClientID %>").prop("checked")) {
                alert("资格不符，请转正后再根据实际情况申请。");
                $("#<%=rdbIsPositive2.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtName.ClientID %>").val())=="") {
                alert("姓名不可为空。");
                $("#<%=txtName.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtCode.ClientID %>").val())=="") {
                alert("工号不可为空。");
                $("#<%=txtCode.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtEntryDate.ClientID %>").val())=="") {
                alert("入职日期不可为空。");
                $("#<%=txtEntryDate.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("现任职部门不可为空。");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtPosition.ClientID %>").val())=="") {
                alert("现职位不可为空。");
                $("#<%=txtPosition.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtGrade.ClientID %>").val())=="") {
                alert("现职级不可为空。");
                $("#<%=txtGrade.ClientID %>").focus();
                return false;
            }
            
            if(!$("#<%=rdbIsPositive1.ClientID %>").prop("checked")&&!$("#<%=rdbIsPositive2.ClientID %>").prop("checked")) {
                alert("请选择是否通过试用期。");
                $("#<%=rdbIsPositive1.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=this.rdbApplyType1.ClientID %>").prop("checked")&&!$("#<%=this.rdbApplyType2.ClientID %>").prop("checked")) {
                alert("请选择申请类别。");
                $("#<%=rdbApplyType1.ClientID %>").focus();
                return false;
            }

            $("#<%=rblMoneyGrade.ClientID%> :radio").each(function(){
                if($(this).prop("checked"))
                {
                    $("#<%=hdMoneyGradeID.ClientID%>").val($(this).val());
                }
            });

            if($("#<%=hdMoneyGradeID.ClientID%>").val()=="")
            { 
                alert("请选择申请金额档次。");
                $("#<%=rblMoneyGrade.ClientID%> :radio")[0].focus();
                return false;
            }

            var $eDate=$("#<%=txtEffectiveDate.ClientID %>");
            if($.trim($eDate.val())=="") {
                alert("生效日期不可为空。");
                $eDate.focus();
                return false;
            }
            else{
                $eDate.val($eDate.val().replace(/-\d\d$/,"-01"));
            }

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
                window.location='Apply_ProjectCarAllowance_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_ProjectCarAllowance_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
                    if(win=='success')
                        window.location="Apply_ProjectCarAllowance_Detail.aspx?MainID=<%=MainID %>";
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
                
            if($("#rdbYesIDx16").prop("checked")&&$.trim($("#<%=hdAgreeMoneyGradeID.ClientID%>").val())=="") {   
                alert("请选择同意报销金额。");
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

        function getSuggestion(idx) {
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

        function getEmployee(n) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtCode.ClientID%>").val(infos[0]);
                        $("#<%=txtName.ClientID%>").val(infos[1]);
                        $("#<%=txtDepartment.ClientID%>").val(infos[2]);
                        $("#<%=txtEntryDate.ClientID%>").val(infos[6]);
                        $("#<%=txtPosition.ClientID%>").val(infos[4]);
                        $("#<%=txtGrade.ClientID%>").val(infos[5]);
                    }
                    else{
                        $("#<%=txtName.ClientID%>").val("");
                        $("#<%=txtDepartment.ClientID%>").val("");
                        $("#<%=txtEntryDate.ClientID%>").val("");
                        $("#<%=txtPosition.ClientID%>").val("");
                        $("#<%=txtGrade.ClientID%>").val("");
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
            <h1>小汽车津贴申请表（项目部）</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td class="tl PL10" style="width: 350px; *width: 20%; ">﹡姓名</td>
                    <td class="tl PL10">
                        <input id="txtName" type="text" runat="server" readonly="readonly" style=" background-color:Silver;"/>
                    </td>
                    <td class="tl PL10" style="width: 150px; *width: 20%; ">﹡工号</td>
                    <td class="tl PL10">
                        <asp:textbox id="txtCode" runat="server" onblur="getEmployee(this);"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡入职日期</td>
                    <td class="tl PL10">
                        <input id="txtEntryDate" type="text" runat="server" readonly="readonly" style=" background-color:Silver;"/>
                    </td>
                    <td class="tl PL10">﹡现任职部门</td>
                    <td class="tl PL10">
                        <input id="txtDepartment" type="text" runat="server" readonly="readonly" style=" background-color:Silver;"/>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡现职位</td>
                    <td class="tl PL10">
                        <input id="txtPosition" type="text" runat="server" readonly="readonly" style=" background-color:Silver;"/>
                    </td>
                    <td class="tl PL10">﹡现职级</td>
                    <td class="tl PL10">
                        <input id="txtGrade" type="text" runat="server" readonly="readonly" style=" background-color:Silver;"/>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡通过试用期</td>
                    <td class="tl PL10">
                        <asp:radiobutton id="rdbIsPositive1" runat="server" groupname="IsPositive" text="是" value="1" />
                        <asp:radiobutton id="rdbIsPositive2" runat="server" groupname="IsPositive" text="否" value="0" />
                    </td>
                    <td class="tl PL10">﹡申请类别</td>
                    <td class="tl PL10">
                        <asp:radiobutton id="rdbApplyType1" runat="server" groupname="ApplyType" text="新增" value="1" />
                        <asp:radiobutton id="rdbApplyType2" runat="server" groupname="ApplyType" text="调整" value="0" />
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡申请金额档次</td>
                    <td class="tl PL10" colspan="3">
                        <asp:radiobuttonlist id="rblMoneyGrade" runat="server" repeatdirection="Horizontal" repeatlayout="Flow"></asp:radiobuttonlist>
                        <asp:hiddenfield id="hdMoneyGradeID" runat="server" value="" />
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡生效日期</td>
                    <td class="tl PL10" colspan="3">
                        <asp:textbox id="txtEffectiveDate" runat="server"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡附件</td>
                    <td class="tl PL10" colspan="3">随申请附汽车行驶证及驾驶证复印件存档。<br />
                        如果行驶证上登记的车主为员工配偶的，需另外上传：申请人结婚证。</td>
                </tr>
                <tr>
                    <td class="tl PL10">填写人</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApply" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="tl PL10">填写日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApplyDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <%--<tr id="trManager1" class="noborder" style="height: 30px;">
                    <td>部门主管</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 30px;">
                    <td>隶属主管</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager3" class="noborder" style="height: 30px;">
                    <td>部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>--%>
                <tr id="trManager1" class="noborder" style="height: 30px;">
                    <td>申请人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 30px;">
                    <td>行政秘书</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
                    </td>
                </tr>

                <tr id="trManager5" class="noborder" style="height: 30px;">
                    <td>部门主管</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签名" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager6" class="noborder" style="height: 30px;">
                    <td>隶属主管</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><br />
                        <textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签名" onclick="sign('6')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager7" class="noborder" style="height: 30px;">
                    <td>部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><br />
                        <textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签名" onclick="sign('7')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
                    </td>
                </tr>

                 <tr class="noborder" style="height: 30px;">
                    <td rowspan="2" >二级市场</td>
                    <td colspan="3" class="tl PL10" style=" ">
                       <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree7" /><label for="rdbNoIDx10">不同意</label><br />
                        <textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签名" onclick="sign('10')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td colspan="3" class="tl PL10" style=" ">
                          <input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree7" /><label for="rdbNoIDx11">不同意</label><br />
                        <textarea id="txtIDx11" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx11" value="签名" onclick="sign('11')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx11">_________</span></div>
                    </td>
                </tr>
             

                <tr class="noborder" style="height: 30px;">
                    <td rowspan="2" >人力资源部意见</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx14" type="radio" name="agree14" /><label for="rdbYesIDx14">确认</label><input id="rdbNoIDx14" type="radio" name="agree14" /><label for="rdbNoIDx14">退回申请</label>
                        <input id="rdbOtherIDx14" type="radio" name="agree14" /><label for="rdbOtherIDx14">其他意见</label><br />
                        <textarea id="txtIDx14" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx14" value="签署意见" onclick="sign('14')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx14">_________</span></div>
                    </td>
                </tr>
                <%--<tr class="noborder" style="height: 30px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">确认</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">退回申请</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>--%>
                <tr class="noborder" style="height: 30px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx16" type="radio" name="agree16" /><label for="rdbYesIDx16">同意</label><span id="divAgreeMoneyGrade" style="display:none;"> 
                            同意报销金额：<asp:radiobuttonlist id="rblAgreeMoneyGrade" repeatdirection="Horizontal" repeatlayout="Flow" runat="server"></asp:radiobuttonlist>
                            <asp:hiddenfield id="hdAgreeMoneyGradeID" runat="server" value="" /></span><input id="rdbNoIDx16" type="radio" name="agree16" />
                        <label for="rdbNoIDx16">不同意</label>
                        <input id="rdbOtherIDx16" type="radio" name="agree16" /><label for="rdbOtherIDx16">其他意见</label><br />
                        <textarea id="txtIDx16" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx16" value="签署意见" onclick="sign('16')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx16">_________</span></div>
                    </td>
                </tr>
                <tr id="trGeneralManager" class="noborder" style="height: 30px; display: none; display: none;">
                    <td >董事总经理审批</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx17" type="radio" name="agree17" /><label for="rdbYesIDx17">同意</label><input id="rdbNoIDx17" type="radio" name="agree17" /><label for="rdbNoIDx17">不同意</label>
                        <input id="rdbOtherIDx17" type="radio" name="agree17" /><label for="rdbOtherIDx17">其他意见</label><br />
                        <textarea id="txtIDx17" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx17" value="签署意见" onclick="sign('17')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx17">_________</span></div>
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
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

