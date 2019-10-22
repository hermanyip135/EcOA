<%@ Page ValidateRequest="false" Title="减让佣/现金奖申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_NewReduceComm_Detail.aspx.cs" Inherits="Apply_ReduceComm_Apply_ReduceComm_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=SbJson.ToString() %>;

        $(function() {      
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
		        }
            });


            i = <%=DetailCount.ToString() %>;
            for (var x = 1; x <= i; x++) {
                $("#txtDealDate"+x).datepicker();
            }
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


            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应

            $("#ckbAddIDx").click(function () {
                //debugger;
                var ckb = $(this);
                if (ckb.prop("checked")) {
                    $("#hidAddIDxIsChecked").val("true");
                }
                else {
                    $("#hidAddIDxIsChecked").val("false");
                }
            });
        });

        function check() {
            if($.trim($("#<%=txtApplyForID.ClientID %>").val())=="") {alert("申请人工号不可为空！");$("#<%=txtApplyForID.ClientID %>").focus();return false;}
		    if($.trim($("#<%=txtApplyFor.ClientID %>").val())=="") {alert("请正确填写申请人工号！");$("#<%=txtApplyForID.ClientID %>").focus();return false;}
		    if($.trim($("#<%=ddlDepartmentType.ClientID %>").val())=="") {alert("请选择所属区域！");$("#<%=ddlDepartmentType.ClientID %>").focus();return false;}
		    if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {alert("回复电话不可为空！");$("#<%=txtReplyPhone.ClientID %>").focus();return false;}
		    if($.trim($("#<%=txtSubject.ClientID %>").val())=="") {alert("文件主题不可为空！");$("#<%=txtSubject.ClientID %>").focus();return false;}
		    if($.trim($("#<%=txtReason.ClientID %>").val())=="") {alert("让佣原因说明不可为空！");$("#<%=txtReason.ClientID %>").focus();return false;}
		    if($.trim($("#<%=ReduceCommType.ClientID%>").val())==""){alert("请选择减让佣/现金奖类型！");$("#<%=ReduceCommType.ClientID%>").focus();return false;}

		    if (!$("#<%=rdbReduceWay1.ClientID%>").prop("checked") && !$("#<%=rdbReduceWay2.ClientID%>").prop("checked") && !$("#<%=rdbReduceWay3.ClientID%>").prop("checked") && !$("#<%=rdbReduceWay4.ClientID%>").prop("checked")) {
		        alert("请选择减佣/让佣方式");
		        $("#<%=rdbReduceWay1.ClientID%>").focus();
                return false;
            }

            var data = "";
            var flag = true;
		    //debugger;
		    //如果详细只有一行，且该行未填任何资料
            if(i == 1 && $.trim($("#txtDealDate1").val()) == "" && $.trim($("#txtDealAddress1").val()) == "" 
                && $.trim($("#txtOriginalDealPrice1").val()) == "" && $.trim($("#txttxtFinalDealPrice1").val()) == "" && $.trim($("#txtCommPoint1").val()) == ""
                && $.trim($("#txtOriginalComm1").val()) == "" && $.trim($("#txtReduceCashBonus1").val()) == "" && $.trim($("#txtReduceComm1").val()) == ""
                && $.trim($("#txtBudingName1").val()) == "" && $.trim($("#txtTotalReduce1").val()) == "" && $.trim($("#txtActualReportMoney1").val()) == "") {
                alert("请填写成交资料及各项金额！");
                $("#txtDealDate1").focus();
                return false;
            }      
            else{

                for(var n=1;n<=i;n++){
                    if ($.trim($("#txtDealDate" + n).val()) == "") {alert("第" + n + "行的成交日期必须填写。");$("#txtDealDate" + n).focus();flag = false;}
                    else if ($.trim($("#txtDealAddress" + n).val()) == "") {alert("第" + n + "行的成交单位必须填写。");$("#txtDealAddress" + n).focus();flag = false;}
                    else if ($.trim($("#txtOriginalDealPrice" + n).val()) == "") {alert("第" + n + "行的原成交价必须填写。");$("#txtOriginalDealPrice" + n).focus();flag = false;}
                    else if ($.trim($("#txtFinalDealPrice" + n).val()) == "") {alert("第" + n + "行的客户最终成交价必须填写。");$("#txtFinalDealPrice" + n).focus();flag = false;}
                    else if ($.trim($("#txtCommPoint" + n).val()) == "") {alert("第" + n + "行的代理费点数必须填写。");$("#txtCommPoint" + n).focus();flag = false;}
                    else if ($.trim($("#txtOriginalComm" + n).val()) == "") {alert("第" + n + "行的原佣金必须填写。");$("#txtOriginalComm" + n).focus();flag = false;}
                    else if ($.trim($("#txtReduceCashBonus" + n).val()) == "") {alert("第" + n + "行的让现金奖金额必须填写。");$("#txtReduceCashBonus" + n).focus();flag = false;}
                    else if ($.trim($("#txtReduceComm" + n).val()) == "") {alert("第" + n + "行的让佣金额必须填写。");$("#txtReduceComm" + n).focus();flag = false;}
	                
                    else if ($.trim($("#txtBudingName" + n).val()) == "") {alert("第" + n + "行的让佣金额必须填写。");$("#txtBudingName" + n).focus();flag = false;}
                    else if ($.trim($("#txtEBCommPoint" + n).val()) == "") {alert("第" + n + "行的电商代理费点数必须填写。");$("#txtEBCommPoint" + n).focus();flag = false;}
                    else if ($.trim($("#txtCaCommPoint" + n).val()) == "") {alert("第" + n + "行的现金奖点数必须填写。");$("#txtCaCommPoint" + n).focus();flag = false;}
                    else if ($.trim($("#txtEBOriginalComm" + n).val()) == "") {alert("第" + n + "行的电商佣金额必须填写。");$("#txtEBOriginalComm" + n).focus();flag = false;}
                    else if ($.trim($("#txtCaOriginalComm" + n).val()) == "") {alert("第" + n + "行的现金奖金额必须填写。");$("#txtCaOriginalComm" + n).focus();flag = false;}
                    else if ($.trim($("#txtEBReduceCashBonus" + n).val()) == "") {alert("第" + n + "行的让电商佣金额必须填写。");$("#txtEBReduceCashBonus" + n).focus();flag = false;}
                    else if ($.trim($("#txtCaReduceCashBonus" + n).val()) == "") {alert("第" + n + "行的让现金奖金额必须填写。");$("#txtCaReduceCashBonus" + n).focus();flag = false;}
                    else if ($.trim($("#txtEBReduceComm" + n).val()) == "") {alert("第" + n + "行的折让后电商佣金额必须填写。");$("#txtEBReduceComm" + n).focus();flag = false;}
                    else if ($.trim($("#txtCaReduceComm" + n).val()) == "") {alert("第" + n + "行的折让后现金奖金额必须填写。");$("#txtCaReduceComm" + n).focus();flag = false;}
	                
                    else if ($.trim($("#txtTotalReduce" + n).val()) == "") {alert("第" + n + "行的总让佣金额必须填写。");$("#txtTotalReduce" + n).focus();flag = false;}
                    else if ($.trim($("#txtActualReportMoney" + n).val()) == "") {alert("第" + n + "行的实际上数金额必须填写。");$("#txtActualReportMoney" + n).focus();flag = false;}
                    else data += $.trim($("#txtDealDate" + n).val()) + "&&" + $.trim($("#txtDealAddress" + n).val()) + "&&" + $.trim($("#txtOriginalDealPrice" + n).val()) 
                        + "&&" + $.trim($("#txtFinalDealPrice" + n).val())



                        + "&&" + $.trim($("#txtCaCommPoint" + n).val()) 
                        + "&&" + $.trim($("#txtEBCommPoint" + n).val())
                        + "&&" + $.trim($("#txtCommPoint" + n).val())

                        + "&&" + $.trim($("#txtCaOriginalComm" + n).val()) 
                        + "&&" + $.trim($("#txtEBOriginalComm" + n).val()) 
                        + "&&" + $.trim($("#txtOriginalComm" + n).val()) 

                        + "&&" + $.trim($("#txtCaReduceCashBonus" + n).val()) 
                        + "&&" + $.trim($("#txtEBReduceCashBonus" + n).val()) 
                        + "&&" + $.trim($("#txtReduceCashBonus" + n).val())

                        + "&&" + $.trim($("#txtCaReduceComm" + n).val()) 
                        + "&&" + $.trim($("#txtEBReduceComm" + n).val()) 
                        + "&&" + $.trim($("#txtReduceComm" + n).val()) 


                        + "&&" + $.trim($("#txtBudingName" + n).val()) 
                        + "&&" + $.trim($("#txtTotalReduce" + n).val()) 
                        + "&&" + $.trim($("#txtKSa" + n).val()) 
                        + "&&" + $.trim($("#txtKSb" + n).val()) 
                        + "&&" + $.trim($("#txtKSc" + n).val())
                        + "&&" + $.trim($("#txtKSd" + n).val())

                        + "&&" + $.trim($("#txtActualReportMoney" + n).val())
                        + "||";
                }
            }

            if (flag) {data = data.substr(0, data.length - 2);$("#<%=hdDetail.ClientID %>").val(data);}
            else return false;

            if ($.trim($("#<%=txtDealDepartment.ClientID %>").val()) == "") {alert("总成交套数必须填写。");$("#<%=txtDealDepartment.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtOriginalDealPrice.ClientID %>").val()) == "") {alert("总原成交价必须填写。");$("#<%=txtOriginalDealPrice.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtFinalDealPrice.ClientID %>").val()) == "") {alert("总客户最终成交价必须填写。");$("#<%=txtFinalDealPrice.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtCommPoint.ClientID %>").val()) == "") {alert("总代理费点数必须填写。");$("#<%=txtCommPoint.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtOriginalComm.ClientID %>").val()) == "") {alert("总原佣金必须填写。");$("#<%=txtOriginalComm.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtReduceCashBonus.ClientID %>").val()) == "") {alert("总让现金奖金额必须填写。");$("#<%=txtReduceCashBonus.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtReduceComm.ClientID %>").val()) == "") {alert("总让佣金额必须填写。");$("#<%=txtReduceComm.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtTotalReduce.ClientID %>").val()) == "") {alert("总总让佣金额必须填写。");$("#<%=txtTotalReduce.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtActualReportMoney.ClientID %>").val()) == "") {alert("总实际上数金额必须填写。");$("#<%=txtActualReportMoney.ClientID %>").focus();return false;}

		    if ($.trim($("#<%=txtEBCommPoint.ClientID %>").val()) == "") {alert("电商代理费总数必须填写。");$("#<%=txtEBCommPoint.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtCaCommPoint.ClientID %>").val()) == "") {alert("发展商代理费总数必须填写。");$("#<%=txtCaCommPoint.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtEBOriginalComm.ClientID %>").val()) == "") {alert("电商佣总额必须填写。");$("#<%=txtEBOriginalComm.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtCaOriginalComm.ClientID %>").val()) == "") {alert("发展商佣总额必须填写。");$("#<%=txtCaOriginalComm.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtEBReduceCashBonus.ClientID %>").val()) == "") {alert("让电商佣总额必须填写。");$("#<%=txtEBReduceCashBonus.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtCaReduceCashBonus.ClientID %>").val()) == "") {alert("让发展商佣总额必须填写。");$("#<%=txtCaReduceCashBonus.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtEBReduceComm.ClientID %>").val()) == "") {alert("折让后电商佣总额必须填写。");$("#<%=txtEBReduceComm.ClientID %>").focus();return false;}
		    if ($.trim($("#<%=txtCaReduceComm.ClientID %>").val()) == "") {alert("折让后发展商佣总额必须填写。");$("#<%=txtCaReduceComm.ClientID %>").focus();return false;}

		    return true;
		}

		//暂时保存
		function tempsavecheck(){
		    var data="";
		    for(var n=1;n<=i;n++){	               
		        data += $.trim($("#txtDealDate" + n).val()) + "&&" + $.trim($("#txtDealAddress" + n).val()) + "&&" + $.trim($("#txtOriginalDealPrice" + n).val()) 
                     + "&&" + $.trim($("#txtFinalDealPrice" + n).val())

                     + "&&" + $.trim($("#txtCaCommPoint" + n).val()) 
                     + "&&" + $.trim($("#txtEBCommPoint" + n).val())
                     + "&&" + $.trim($("#txtCommPoint" + n).val())

                     + "&&" + $.trim($("#txtCaOriginalComm" + n).val()) 
                     + "&&" + $.trim($("#txtEBOriginalComm" + n).val()) 
                     + "&&" + $.trim($("#txtOriginalComm" + n).val()) 

                     + "&&" + $.trim($("#txtCaReduceCashBonus" + n).val()) 
                     + "&&" + $.trim($("#txtEBReduceCashBonus" + n).val()) 
                     + "&&" + $.trim($("#txtReduceCashBonus" + n).val())

                     + "&&" + $.trim($("#txtCaReduceComm" + n).val()) 
                     + "&&" + $.trim($("#txtEBReduceComm" + n).val()) 
                     + "&&" + $.trim($("#txtReduceComm" + n).val()) 


                     + "&&" + $.trim($("#txtBudingName" + n).val()) 
                     + "&&" + $.trim($("#txtTotalReduce" + n).val()) 
                     + "&&" + $.trim($("#txtKSa" + n).val()) 
                     + "&&" + $.trim($("#txtKSb" + n).val()) 
                     + "&&" + $.trim($("#txtKSc" + n).val())
                     + "&&" + $.trim($("#txtKSd" + n).val())

                     + "&&" + $.trim($("#txtActualReportMoney" + n).val())
                     + "||";
		    }

		    data = data.substr(0, data.length - 2);
		    $("#<%=hdDetail.ClientID %>").val(data);
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
                window.location='Apply_NewReduceComm_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_ReduceComm_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
            if(win=='success')
                window.location="Apply_NewReduceComm_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
        function sign(idx) {
            //if(idx!='4'&&idx!='5'&&idx!='6'&&idx!='7'&&idx!='8'&&idx!='9'){
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

function addRow() {
    i++;
    var html = '<tr>'
        + '     <td><input type="text" id="txtDealDate' + i + '" style="width:90%"/></td>'
        + '     <td><textarea id="txtBudingName' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtDealAddress' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtOriginalDealPrice' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtFinalDealPrice' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'

        + '     <td><textarea id="txtCaCommPoint' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtKSa' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtEBCommPoint' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtCommPoint' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
                

        + '     <td><textarea id="txtCaOriginalComm' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtKSb' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtEBOriginalComm' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtOriginalComm' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'

        + '     <td><textarea id="txtCaReduceCashBonus' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtKSc' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtEBReduceCashBonus' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtReduceCashBonus' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'

                
        + '     <td><textarea id="txtCaReduceComm' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtKSd' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtEBReduceComm' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtReduceComm' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'

        + '     <td><textarea id="txtTotalReduce' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '     <td><textarea id="txtActualReportMoney' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
        + '</tr>';

    $("#trTotal").before(html);
    $("#txtDealDate"+i).datepicker();
    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); });
}

function deleteRow() {
    if (i > 1) {
        $("#tbDetail tr:eq(" + i + ")").remove();
        i--;
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
    <input type="hidden" id="hidPageType" runat="server" clientidmode="Static" />
    <input type="hidden" id="hidAddIDxVisible" runat="server" clientidmode="Static" />
    <input type="hidden" id="hidAddIDxIsChecked" runat="server" clientidmode="Static" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1 id="h1DocumentTitle" runat="server" clientidmode="Static">减让佣/现金奖申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 800px; margin: 0 auto;"></div>
            <table id="tbAround" width='800px'>
                <tr>
                    <td class="tl PL10" style="width: 20%;">收文部门</td>
                    <td class="tl PL10">法律部、财务部</td>
                    <td class="tl PL10" style="width: 20%;">文档编码</td>
                    <td class="tl PL10"><%=SerialNumber %></td>
                </tr>
                <tr>
                    <td class="tl PL10">申请部门</td>
                    <td class="tl PL10">
                        <input id="txtDepartment" type="text" runat="server" readonly="readonly" style="background-color: Silver; width: 90%;" /><input type="hidden" id="hdDepartmentID" runat="server" /></td>
                    <td class="tl PL10">申请人</td>
                    <td class="tl PL10">工号：<asp:TextBox ID="txtApplyForID" runat="server" Width="40px" onblur="getEmployee(this);"></asp:TextBox><span id="spanApplyFor" style="display: none;">&nbsp;&nbsp;&nbsp;&nbsp;姓名：<input id="txtApplyFor" type="text" runat="server" readonly="readonly" style="background-color: Silver; width: 50px;" /></span></td>
                </tr>
                <tr>
                    <td class="tl PL10">所属区域</td>
                    <td class="tl PL10">
                        <asp:DropDownList ID="ddlDepartmentType" runat="server"></asp:DropDownList></td>
                    <td class="tl PL10">发文日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="tl PL10">抄送部门</td>
                    <td class="tl PL10">总办</td>
                    <td class="tl PL10">回复电话</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">文件主题</td>
                    <td class="tl PL10">关于<asp:TextBox ID="txtSubject" runat="server" Width="100px"></asp:TextBox>减让佣/现金奖申请</td>
                    <td class="tl PL10">填写人</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApply" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="tl PL10">减让佣/现金奖类型</td>
                    <td class="tl PL10">
                        <select runat="server" id="ReduceCommType">
                            <option value="">请选择</option>
                            <option value="只折让现金奖">只折让现金奖</option>
                            <option value="折让佣金（项目无现金奖）">折让佣金（项目无现金奖）</option>
                            <option value="让现金奖及佣金">让现金奖及佣金</option>
                        </select>

                    </td>

                </tr>
                <tr>
                    <td class="tl PL10 PR10" colspan="4">
                        <table id="tbDetail" class='sample tc' width='100%'>
                            <thead>
                                <tr>
                                    <td style="width: 75px" rowspan="2"></td>
                                    <td style="width: 75px" rowspan="2"></td>
                                    <td style="width: 90px" rowspan="2"></td>
                                    <td style="width: 50px" rowspan="2">A</td>
                                    <td style="width: 50px" rowspan="2">B</td>
                                    <td style="width: 50px" rowspan="2">C</td>
                                    <td style="width: 50px" rowspan="2">-</td>
                                    <td style="width: 50px" rowspan="2">D</td>
                                    <td style="width: 50px" rowspan="2">E</td>
                                    <td style="width: 50px">F</td>
                                    <td style="width: 50px">-</td>
                                    <td style="width: 50px">G</td>
                                    <td style="width: 50px">H</td>
                                    <td style="width: 50px" rowspan="2">I</td>
                                    <td style="width: 50px" rowspan="2">-</td>
                                    <td style="width: 50px" rowspan="2">J</td>
                                    <td style="width: 50px" rowspan="2">K</td>
                                    <td style="width: 50px">L</td>
                                    <td style="width: 50px">-</td>
                                    <td style="width: 50px">M</td>
                                    <td style="width: 50px">N</td>
                                    <td style="width: 50px">O</td>
                                    <td style="width: 50px">P</td>
                                </tr>
                                <tr>
                                    <td>F=A*C</td>
                                    <td>-</td>
                                    <td>G=A*D</td>
                                    <td>H=A*E</td>
                                    <td>L=F-I</td>
                                    <td>-</td>
                                    <td>M=G-J</td>
                                    <td>N=H-K</td>
                                    <td>O=I+J+K</td>
                                    <td>P=L+M</td>
                                </tr>
                                <tr>
                                    <td rowspan="2">成交日期</td>
                                    <td rowspan="2">楼盘名</td>
                                    <td rowspan="2">成交单位</td>
                                    <td rowspan="2">发展商的成交楼价</td>
                                    <td rowspan="2">客户申请的成交楼价</td>
                                    <td colspan="4">合同约定</td>
                                    <td colspan="4">折让前</td>
                                    <td colspan="4">申请折让</td>
                                    <td colspan="4">折让后</td>
                                    <td rowspan="2">总折让金额</td>
                                    <td rowspan="2">折让后总应收佣金</td>
                                </tr>
                                <tr>
                                    <td>发展商代理费点数</td>
                                    <td>客佣</td>
                                    <td>电商代理费点数</td>
                                    <td>现金奖点数</td>
                                    <td>发展商佣金额</td>
                                    <td>客佣</td>
                                    <td>电商佣金额</td>
                                    <td>现金奖金额</td>
                                    <td>发展商佣金额</td>
                                    <td>客佣</td>
                                    <td>电商佣金额</td>
                                    <td>现金奖金额</td>
                                    <td>发展商佣金额</td>
                                    <td>客佣</td>
                                    <td>电商佣金额</td>
                                    <td>现金奖金额</td>
                                </tr>
                            </thead>
                            <%=SbHtml.ToString()%>
                            <tr id="trTotal">
                                <td colspan="2">以上总计</td>
                                <td>
                                    <asp:TextBox ID="txtDealDepartment" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtOriginalDealPrice" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtFinalDealPrice" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>

                                <td>
                                    <asp:TextBox ID="txtCaCommPoint" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtKSa" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtEBCommPoint" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtCommPoint" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>

                                <td>
                                    <asp:TextBox ID="txtCaOriginalComm" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtKSb" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtEBOriginalComm" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtOriginalComm" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>

                                <td>
                                    <asp:TextBox ID="txtCaReduceCashBonus" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtKSc" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtEBReduceCashBonus" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtReduceCashBonus" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>

                                <td>
                                    <asp:TextBox ID="txtCaReduceComm" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtKSd" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtEBReduceComm" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtReduceComm" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>

                                <td>
                                    <asp:TextBox ID="txtTotalReduce" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtActualReportMoney" runat="server" TextMode="MultiLine" Rows="2" Style="width: 90%; overflow: hidden;"></asp:TextBox></td>
                            </tr>
                        </table>
                        <input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style="float: left; display: none" />
                        <input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style="float: left; display: none" />
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">以上减佣/让佣
                    </td>
                    <td class="tl PL10" colspan="3">
                        <asp:CheckBox ID="rdbReduceWay1" runat="server" Text="从发展商佣金中扣除" />
                        <asp:CheckBox ID="rdbReduceWay4" runat="server" Text="从客佣中扣除" />
                        <asp:CheckBox ID="rdbReduceWay2" runat="server" Text="从电商佣金中扣除" />
                        <asp:CheckBox ID="rdbReduceWay3" runat="server" Text="折让现金给客户" />
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10" colspan="4">备注：若发展商代理费、电商代理费、现金奖为固定XXX元/套而非点数，请直接填写在F-G列“折让前的发展商佣金额”“折让前的电商佣金额”“折让前的现金奖金额”
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10" colspan="4">折让佣金/现金奖原因说明：<br />
                        <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Width="98%" Rows="10" Style="overflow: auto;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>申请人</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td>申请部门负责人</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td>二级市场负责人<br />
                        （项目部）<br />
                        或<br />
                        三级市场负责人<br />
                        （物业部）</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>
                <%=SbFYQ.ToString() %>

                <%--<tr id="trShowFlow4" class="noborder" style="height: 85px;">
                    <td rowspan="2">法律部意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
                        <textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx4">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow5" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx5">_________</span>
                        </span>
                    </td>
                </tr>--%>

                <%--<tr id="trShowFlow6" class="noborder" style="height: 85px;">
                    <td rowspan="3">财务部意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label>
                        <asp:CheckBox ID="ckbAddIDx" runat="server" Text="增加审批环节" Visible="false" /><br />
                        <textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx6">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow7" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
                        <textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx7">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow8">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        <textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx8">_________</span>
                        </span>
                    </td>
                </tr>--%>

                <%--<tr id="trShowFlow9" class="noborder" style="height: 85px;">
                                <td rowspan="2">房友圈意见</td>
                                <td colspan="3" class="tl PL10" style="">
                                    <input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label><input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label><br />
                                    <textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                                    <br />
                                    <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="span1">_________</span>
                                    </span>
                                </td>
                            </tr>
                            <tr id="trShowFlow10" class="noborder" style="height: 85px;">
                                <td colspan="3" class="tl PL10" style="">
                                    <input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><input id="Radio1" type="radio" name="agree10" /><label for="rdbOtherIDx5">其他意见</label><br />
                                    <textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                                    <br />
                                    <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="span2">_________</span>
                                    </span>
                                </td>
                            </tr>--%>


                <%--<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label>
                        <input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label><br />
						<textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
                        </span>
					</td>
				</tr>--%>
                <%--<tr id="trGeneralManager" class="noborder" style="height: 85px;">
                    <td>董事总经理<br />
                        审批</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx13" type="radio" name="agree13" /><label for="rdbYesIDx13">同意</label><input id="rdbNoIDx13" type="radio" name="agree13" /><label for="rdbNoIDx9">不同意</label>
                        <input id="rdbOtherIDx13" type="radio" name="agree13" /><label for="rdbOtherIDx13">其他意见</label><br />
                        <textarea id="txtIDx13" rows="3" cols="20" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx13" value="签署意见" onclick="sign('13')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx9">_________</span>
                        </span>
                    </td>
                </tr>--%>
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
                    <td>申请人回复审批意见<br />
                        （可选项）</td>
                    <td colspan="3" class="tl PL10" style="">
                        <%--<input id="rdbYesIDx200" type="radio" name="agree200" /><label for="rdbYesIDx200">同意</label><input id="rdbNoIDx200" type="radio" name="agree200" /><label for="rdbNoIDx200">不同意</label><br />--%>
                        <textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea><%--<input type="button" id="btnSignIDx200" value="签署意见" onclick="sign('200')" style="display: none;" />--%><asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx200">_________</span>
                        </span>
                    </td>
                </tr>

                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
                    <td>董事总经理复审</td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#008162" />
                        <textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx220">_________</span>
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
                <hr />
                <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnTemp" Text="暂时保存" OnClick="btnTempSave_Click" CssClass="commonbtn" OnClientClick="return tempsavecheck();" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
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
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
    <script type="text/javascript">
        //财务部boss要看到所有前级的意见
        financeShow(8);
        function financeShow(idx)
        {
            var flows = $("[bossidx='" + idx + "']");

            var bosschecked = flows.eq(2).find("img");
            if(typeof(bosschecked) == "undefined" || bosschecked.length == 0)
            {
                if(flows.eq(0).find("td").length <2)
                {
                    flows.eq(0).find("td").before('<td rowspan="3" style="border: 1px solid rgb(152, 184, 181); color: rgb(2, 34, 65);">财务部意见</td>');
                    flows.eq(0).show();
                }
                if(flows.eq(1).find("td").length > 1)
                {
                    flows.eq(1).find("td").first().remove();
                    flows.eq(1).show();
                }
            }
        }
    </script>
</asp:Content>

