<%@ Page ValidateRequest="false" Title="项目报数申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ProjRepoData_Detail.aspx.cs" Inherits="Apply_ProjRepoData_Apply_ProjRepoData_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
      <link href="../../Style/AddGroups.css" rel="stylesheet" />
    <script type="text/javascript">

        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }
        ///增加集团审批
        function AddGroups(idx)
        {
            if(confirm("确定要集团审核？"))
            {
                
                $.ajax({
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=SaveGroups&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&idx=' + idx,
		            success: function(info) {
		                if (info == "success") {
		                    alert('已增加集团审批');
		                    location=location ;
		                }
		                else if (info == "NoPower")
		                    alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                        
                        }
                        else if("Existed" == info)
                        {
                            alert("已增加集团审批");
                        }
                        else
                            alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
		        })
              
}
           
}
function CancelGroups()
{
    if(confirm("确定要取消集团审核？"))
    {
        $.ajax({
            url: "/Ajax/Flow_Handler.ashx",
            type: "post",
            dataType: "text",
            data: 'action=CancelGroups&mainid=<%=MainID %>',
                    success: function(info) {
                        if (info == "success") {
                            alert('已取消集团审批');
                            location=location ;
                        }
                        else if (info == "NoPower")
                            alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                        
                        }
                        else if("Existed" == info)
                        {
                            alert("已取消集团审批");
                        }
                        else
                            alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
                })
}
}
        var jJSON = <%=SbJson.ToString() %>;
        $(function() {      
            $("#<%=txtDepartment.ClientID %>").autocomplete({ source: jJSON});

            $("#<%=txtAgentStartDate.ClientID%>").datepicker();
            $("#<%=txtAgentEndDate.ClientID%>").datepicker();  
            $("#<%=txtContractPreSignBackDate.ClientID%>").datepicker();
            $("#<%=txtDealHistoryStartDate.ClientID%>").datepicker();
            $("#<%=txtDealHistoryEndDate.ClientID%>").datepicker();
            $("#<%=txtTotalProfitStartDate.ClientID%>").datepicker();
            $("#<%=txtTotalProfitEndDate.ClientID%>").datepicker();

            $("#<%=txtAgencyBeginDate1.ClientID%>").datepicker();
            $("#<%=txtAgencyBeginDate2.ClientID%>").datepicker();
            $("#<%=txtAgencyEndDate1.ClientID%>").datepicker();
            $("#<%=txtAgencyEndDate2.ClientID%>").datepicker();
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
        });
        function check() {
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {alert("发文部门不可为空！");$("#<%=txtDepartment.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {alert("回复电话不可为空！");$("#<%=txtReplyPhone.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {alert("发文编号不可为空！");$("#<%=txtApplyID.ClientID %>").focus();return false;}
            if (!$("#<%=rdbApplyType1.ClientID %>").prop("checked") && !$("#<%=rdbApplyType2.ClientID %>").prop("checked") && !$("#<%=rdbApplyType3.ClientID %>").prop("checked") && !$("#<%=rdbApplyType4.ClientID %>").prop("checked")) {alert("请选择申请类型");$("#<%=rdbApplyType1.ClientID %>").focus();return false;}
            else if($("#<%=rdbApplyType3.ClientID %>").prop("checked") && $.trim($("#<%=txtApplyTypeRate.ClientID %>").val())==""){alert("由于您选择了按比例报数申请，请填写比例");$("#<%=txtApplyTypeRate.ClientID %>").focus();return false;}
            else if($("#<%=rdbApplyType4.ClientID %>").prop("checked") && $.trim($("#<%=txtApplyTypeOther.ClientID %>").val())==""){alert("由于您选择了其他申请类型，请填写确切情况");$("#<%=txtApplyTypeOther.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtProjName.ClientID %>").val())=="") {alert("项目名称不可为空！");$("#<%=txtProjName.ClientID %>").focus();return false;}
            if (!$("#<%=rdbHavePreSaleID.ClientID %>").prop("checked") && !$("#<%=rdbNoPreSaleID.ClientID %>").prop("checked")) {alert("请选择是否有预售证");$("#<%=rdbHavePreSaleID.ClientID %>").focus();return false;}
            else if($("#<%=rdbHavePreSaleID.ClientID %>").prop("checked") && $.trim($("#<%=txtPreSaleID.ClientID %>").val())==""){alert("由于您选择了有预售证，请填写预售证号");$("#<%=txtPreSaleID.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtProjAddress.ClientID %>").val())=="") {alert("项目地址不可为空！");$("#<%=txtProjAddress.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtDeveloperName.ClientID %>").val())=="") {alert("发展商名称不可为空！");$("#<%=txtDeveloperName.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtGroupName.ClientID %>").val())=="") {alert("所属集团名称不可为空！");$("#<%=txtGroupName.ClientID %>").focus();return false;}
            var cblItemLength = $("#<%=cblDealOfficeType.ClientID %> input").length;
            var flag = false;
            var typeValues = "";
            for (var i = 0; i < cblItemLength; i++) {
                if ($("#<%=cblDealOfficeType.ClientID %> input")[i].checked) {
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
            if($.trim($("#<%=txtAgentStartDate.ClientID %>").val())=="") {alert("项目代理起始日期不可为空！");$("#<%=txtAgentStartDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtAgentEndDate.ClientID %>").val())=="") {alert("项目代理结束日期不可为空！");$("#<%=txtAgentEndDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtPreComm.ClientID %>").val())=="") {alert("预计创佣不可为空！");$("#<%=txtPreComm.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtGoodsQuantity.ClientID %>").val())=="") {alert("代理期内可售货量不可为空！");$("#<%=txtGoodsQuantity.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtGoodsValue.ClientID %>").val())=="") {alert("代理期内可售货值不可为空！");$("#<%=txtGoodsValue.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtCommPoint.ClientID %>").val())=="") {alert("申请报数点数不可为空！");$("#<%=txtCommPoint.ClientID %>").focus();return false;}
            if (!$("#<%=rdbAgentModel1.ClientID %>").prop("checked") && !$("#<%=rdbAgentModel2.ClientID %>").prop("checked")) { alert("请选择代理模式"); return false; }
            if (!$("#<%=rdbContractType1.ClientID %>").prop("checked") && !$("#<%=rdbContractType2.ClientID %>").prop("checked") && !$("#<%=rdbContractType3.ClientID %>").prop("checked")) { alert("请选择项合作类型"); return false; }
            if (!$("#<%=rdbHaveCoopCost.ClientID %>").prop("checked") && !$("#<%=rdbNoCoopCost.ClientID %>").prop("checked")) { alert("请选择是否有合作费"); return false; }
            if (!$("#<%=rdbHaveCoopConf.ClientID %>").prop("checked") && !$("#<%=rdbNoCoopConf.ClientID %>").prop("checked")) { alert("请选择是否有合作确认函"); return false; }
            if (!$("#<%=rdbIsSignBack.ClientID %>").prop("checked") && !$("#<%=rdbIsNotSignBack.ClientID %>").prop("checked")) { alert("请选择合同是否签回"); return false; }
            else if($("#<%=rdbIsNotSignBack.ClientID %>").prop("checked") && $.trim($("#<%=txtContractPreSignBackDate.ClientID %>").val())==""){alert("由于您选择了未签回，请填写预计签回时间");$("#<%=txtContractPreSignBackDate.ClientID %>").focus();return false;}
            if (!$("#<%=rdbAgentModel1.ClientID %>").prop("checked") && !$("#<%=rdbAgentModel2.ClientID %>").prop("checked")) { alert("请选择代理模式"); return false; }
            if (!$("#<%=rdbNewProj.ClientID %>").prop("checked") && !$("#<%=rdbOldProj.ClientID %>").prop("checked")) { alert("请选择项目类型"); return false; }
            else if($("#<%=rdbOldProj.ClientID %>").prop("checked") ){
                if($.trim($("#<%=txtDealHistoryStartDate.ClientID %>").val())=="") {alert("历史成交起始日期不可为空！");$("#<%=txtDealHistoryStartDate.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtDealHistoryEndDate.ClientID %>").val())=="") {alert("历史成交结束日期不可为空！");$("#<%=txtDealHistoryEndDate.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtTotalProfitStartDate.ClientID %>").val())=="") {alert("累计利润起始日期不可为空！");$("#<%=txtTotalProfitStartDate.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtTotalProfitEndDate.ClientID %>").val())=="") {alert("累计利润结束日期不可为空！");$("#<%=txtTotalProfitEndDate.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtIndepCount.ClientID %>").val())=="") {alert("独立成交宗数不可为空！");$("#<%=txtIndepCount.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtIndepPerformance.ClientID %>").val())=="") {alert("独立成交业绩不可为空！");$("#<%=txtIndepPerformance.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtLinkCount.ClientID %>").val())=="") {alert("联动成交宗数不可为空！");$("#<%=txtLinkCount.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtLinkPerformance.ClientID %>").val())=="") {alert("联动成交业绩不可为空！");$("#<%=txtLinkPerformance.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtTotalProfit.ClientID %>").val())=="") {alert("期间累计税前利润不可为空！");$("#<%=txtTotalProfit.ClientID %>").focus();return false;}
            }

            //20141027+
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
            if ($("#<%=rdbJOrT2.ClientID%>").prop("checked")) {
                if ($.trim($("#<%=txtTurnsAgentXX1.ClientID%>").val()) == "") { alert("轮流代理的行家名称1不可为空！"); $("#<%=txtTurnsAgentXX1.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtTurnsAgentXX2.ClientID%>").val()) == "") { alert("轮流代理的行家名称2不可为空！"); $("#<%=txtTurnsAgentXX2.ClientID%>").focus(); return false; }

                if ($.trim($("#<%=txtAgencyFee3.ClientID%>").val()) == "") { alert("轮流代理行家代理费1不可为空！"); $("#<%=txtAgencyFee3.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyFee4.ClientID%>").val()) == "") { alert("轮流代理行家代理费2不可为空！"); $("#<%=txtAgencyFee4.ClientID%>").focus(); return false; }
                if ($("#<%=rdbIsCashPrize31.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtCashPrize3.ClientID%>").val()) == "") { alert("轮流代理行家现金奖1不可为空！"); $("#<%=txtCashPrize3.ClientID%>").focus(); return false; }
	            }
                if ($("#<%=rdbIsCashPrize41.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtCashPrize4.ClientID%>").val()) == "") { alert("轮流代理行家现金奖2不可为空！"); $("#<%=txtCashPrize4.ClientID%>").focus(); return false; }
                }
                if (!$("#<%=rdbIsCashPrize31.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize32.ClientID%>").prop("checked")) {
                    alert("请选择是否有轮流代理行家现金奖1");
                    $("#<%=rdbIsCashPrize31.ClientID%>").focus();
	                return false;
                }
                if (!$("#<%=rdbIsCashPrize41.ClientID%>").prop("checked") && !$("#<%=rdbIsCashPrize42.ClientID%>").prop("checked")) {
                    alert("请选择是否有轮流代理行家现金奖2");
                    $("#<%=rdbIsCashPrize41.ClientID%>").focus();
	                return false;
                }

                if ($("#<%=rdbIsPFear31.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtPFear3.ClientID%>").val()) == "") { alert("轮流代理行家项目费用3不可为空！"); $("#<%=txtPFear3.ClientID%>").focus(); return false; }
                }
                if ($("#<%=rdbIsPFear41.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtPFear4.ClientID%>").val()) == "") { alert("轮流代理行家项目费用4不可为空！"); $("#<%=txtPFear4.ClientID%>").focus(); return false; }
                }
                if (!$("#<%=rdbIsPFear31.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear32.ClientID%>").prop("checked")) {
                    alert("请选择是否有轮流代理行家项目费用3");
                    $("#<%=rdbIsPFear31.ClientID%>").focus();
	                return false;
                }
                if (!$("#<%=rdbIsPFear41.ClientID%>").prop("checked") && !$("#<%=rdbIsPFear42.ClientID%>").prop("checked")) {
                    alert("请选择是否有轮流代理行家项目费用4");
                    $("#<%=rdbIsPFear41.ClientID%>").focus();
	                return false;
                }
                if ($.trim($("#<%=txtAgencyBeginDate1.ClientID%>").val()) == "") { alert("轮流代理行家代理开始期1不可为空！"); $("#<%=txtAgencyBeginDate1.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyBeginDate2.ClientID%>").val()) == "") { alert("轮流代理行家代理开始期2不可为空！"); $("#<%=txtAgencyBeginDate2.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyEndDate1.ClientID%>").val()) == "") { alert("轮流代理行家代理结束期1不可为空！"); $("#<%=txtAgencyFee3.ClientID%>").focus(); return false; }
                if ($.trim($("#<%=txtAgencyEndDate2.ClientID%>").val()) == "") { alert("轮流代理行家代理结束期2不可为空！"); $("#<%=txtAgencyFee4.ClientID%>").focus(); return false; }
            }
            //20141027+

            return true;
        }

        //暂时保存 2016/8/23 52100
        function tempsavecheck(){
            var cblItemLength = $("#<%=cblDealOfficeType.ClientID %> input").length;
            var flag = false;
            var typeValues = "";
            for (var i = 0; i < cblItemLength; i++) {
                if ($("#<%=cblDealOfficeType.ClientID %> input")[i].checked) {
                    flag = true;
                    typeValues += $("#<%=cblDealOfficeType.ClientID%> span")[i].tag + "|";
                }
            }
            if (flag) {
                $("#<%=hdDealOfficeType.ClientID%>").val(typeValues.substr(0, typeValues.length - 1));
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
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_ProjRepoData_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_ProjRepoData_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
                    if(win=='success')
                        window.location="Apply_ProjRepoData_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(idx!='3'&&idx!='5'&&idx!='6'&&idx!='7'&&idx!='8'&&idx!='11'&&idx!='10'&&idx!='130'&&idx!='131'){
            //if(idx=='1'||idx=='2'||idx=='4'||idx=='10'){//789
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
           <%-- <h1>项目报数申请表</h1>--%>
             <span style="font-size:20px; font-weight:bold">项目报数申请表</span><label id="laIsGroups" runat="server" style="color:red; font-size:15px;"></label>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <%--<div style="width:640px;margin:0 auto;"><span style="float:right;">文档编码(自动生成)：<a%=SerialNumber %></span></div>--%>
            <table id="tbAround" width='640px'>
                <tr>
                    <td style="width: 20%; ">发文部门</td>
                    <td class="tl PL10"><asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
                    <td style="width: 20%; ">发文日期</td>
                    <td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>跟进人</td>
                    <td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td>跟进人电话</td>
                    <td class="tl PL10"><asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>发文编号</td>
                    <td class="tl PL10"><asp:TextBox ID="txtApplyID" runat="server"></asp:TextBox></td>
                    <td>文档编码</td>
                    <td class="tl PL10"><%=SerialNumber %></td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">项目信息</th></tr>
                <tr>
                    <td>申请类型</td>
                    <td class="tl PL10" colspan="3"><asp:RadioButton ID="rdbApplyType1" runat="server" Text="未有合同先行报数申请" GroupName="ApplyType" />
                        <asp:RadioButton ID="rdbApplyType2" runat="server" Text="未有预售证先行报数申请" GroupName="ApplyType" />
                        <asp:RadioButton ID="rdbApplyType3" runat="server" Text="按" GroupName="ApplyType" /><asp:TextBox ID="txtApplyTypeRate" runat="server" Width="30"></asp:TextBox><label for="<%=rdbApplyType3.ClientID %>"">%报数申请</label>
                        <br /><asp:RadioButton ID="rdbApplyType4" runat="server" Text="其他" GroupName="ApplyType" /><asp:TextBox ID="txtApplyTypeOther" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%; ">项目名称</td>
                    <td class="tl PL10"><asp:TextBox ID="txtProjName" runat="server"></asp:TextBox></td>
                    <td style="width: 20%; ">是否有预售证</td>
                    <td class="tl PL10"><asp:RadioButton ID="rdbHavePreSaleID" runat="server" Text="是" GroupName="PreSaleID" />(编号<asp:TextBox ID="txtPreSaleID" runat="server" Width="100"></asp:TextBox>)
                        <br /><asp:RadioButton ID="rdbNoPreSaleID" runat="server" Text="否" GroupName="PreSaleID" /></td>
                </tr>
                <tr>
                    <td>项目地址</td>
                    <td class="tl PL10" colspan="3"><asp:TextBox ID="txtProjAddress" runat="server" Width="95%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>开发商名称</td>
                    <td class="tl PL10"><asp:TextBox ID="txtDeveloperName" runat="server"></asp:TextBox></td>
                    <td>所属集团名称</td>
                    <td class="tl PL10"><asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>物业性质</td>
                    <td class="tl PL10" colspan="3"><asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList><asp:TextBox ID="txtDealOfficeOther" runat="server"></asp:TextBox><asp:HiddenField ID="hdDealOfficeType" runat="server" /></td>
                </tr>
                <tr>
                    <td>项目代理期</td>
                    <td class="tl PL10"><asp:TextBox ID="txtAgentStartDate" runat="server" Width="80"></asp:TextBox>至<asp:TextBox ID="txtAgentEndDate" runat="server" Width="80"></asp:TextBox></td>
                    <td>预计创佣</td>
                    <td class="tl PL10"><asp:TextBox ID="txtPreComm" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 20%; ">代理期内<br />可售货量</td>
                    <td class="tl PL10"><asp:TextBox ID="txtGoodsQuantity" runat="server"></asp:TextBox></td>
                    <td style="width: 20%; ">代理期内<br />可售货值</td>
                    <td class="tl PL10"><asp:TextBox ID="txtGoodsValue" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>申请报数点数</td>
                    <td class="tl PL10"><asp:TextBox ID="txtCommPoint" runat="server"></asp:TextBox></td>
                    <td>代理模式</td>
                    <td class="tl PL10"><asp:RadioButton ID="rdbAgentModel1" runat="server" Text="联合代理" GroupName="AgentModel" /><asp:RadioButton ID="rdbAgentModel2" runat="server" Text="独家代理" GroupName="AgentModel" /></td>
                </tr>
                <tr>
                    <td>合同类型</td>
                    <td class="tl PL10" colspan="3"><asp:RadioButton ID="rdbContractType1" runat="server" Text="销售代理合同" GroupName="ContractType" /><asp:RadioButton ID="rdbContractType2" runat="server" Text="招商代理合同" GroupName="ContractType" /><asp:RadioButton ID="rdbContractType3" runat="server" Text="其他" GroupName="ContractType" /><asp:TextBox ID="txtContractTypeOther" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>是否有<br />合作费</td>
                    <td class="tl PL10"><asp:RadioButton ID="rdbHaveCoopCost" runat="server" Text="是" GroupName="CoopCost" /><asp:RadioButton ID="rdbNoCoopCost" runat="server" Text="否" GroupName="CoopCost" /></td>
                    <td>是否有<br />合作确认函</td>
                    <td class="tl PL10"><asp:RadioButton ID="rdbHaveCoopConf" runat="server" Text="是" GroupName="CoopConf" /><asp:RadioButton ID="rdbNoCoopConf" runat="server" Text="否" GroupName="CoopConf" /></td>
                </tr>
                <tr>
                    <td>合同是否签回</td>
                    <td class="tl PL10" colspan="3"><asp:RadioButton ID="rdbIsSignBack" runat="server" Text="是" GroupName="SignBack" /><asp:RadioButton ID="rdbIsNotSignBack" runat="server" Text="否" GroupName="SignBack" />（预计签回时间<asp:TextBox ID="txtContractPreSignBackDate" runat="server" Width="80"></asp:TextBox>）</td>
                </tr>
                <tr>
                    <td>是否与行家联合代理或轮流代理</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbJOrT1" runat="server" GroupName="JOrT" Text="与行家同场联合代理" /><br />
                        <asp:RadioButton ID="rdbJOrT2" runat="server" GroupName="JOrT" Text="与行家轮流代理，即代理期内中原独家代理，代理期之外由行家轮流代理" /><br />
                        <asp:RadioButton ID="rdbJOrT3" runat="server" GroupName="JOrT" Text="整个项目由中原独家代理，发展商没有委托除中原以外的任何代理行" />
                    </td>
                </tr>
                <tr>
                    <td>同场代理的行家</td>
                    <td colspan="3"class="tl PL10">
                        <div>　若项目与行家同场联合代理或与轮流代理，以下为必填项，若因无渠道了解相关信息无法填写，敬请注明“无渠道了解相关信息”。</div><br />
                        1.名称：<asp:TextBox ID="txtSamePlaceXX1" runat="server" Width="180px"></asp:TextBox>
                        　代理费：<asp:TextBox ID="txtAgencyFee1" runat="server" Width="180px"></asp:TextBox><br />
                        　现金奖：<asp:RadioButton ID="rdbIsCashPrize11" runat="server" Text="有，" GroupName="CashPrize1" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize1" runat="server" Width="200px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize12" runat="server" Text="无" GroupName="CashPrize1" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear11" runat="server" Text="有，比例" GroupName="IsPFear1" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear1" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear12" runat="server" Text="无" GroupName="IsPFear1" /><br />
                        2.名称：<asp:TextBox ID="txtSamePlaceXX2" runat="server" Width="180px"></asp:TextBox>
                        　代理费：<asp:TextBox ID="txtAgencyFee2" runat="server" Width="180px"></asp:TextBox><br />　现金奖：<asp:RadioButton ID="rdbIsCashPrize21" runat="server" Text="有，" GroupName="CashPrize2" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize2" runat="server" Width="200px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize22" runat="server" Text="无" GroupName="CashPrize2" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear21" runat="server" Text="有，比例" GroupName="IsPFear2" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear2" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear22" runat="server" Text="无" GroupName="IsPFear2" /><br />
                    </td>
                </tr>
                <tr>
                    <td>轮流代理的行家</td>
                    <td colspan="3"class="tl PL10">
                        　<div>　若项目与行家同场联合代理或与轮流代理，以下为必填项，若因无渠道了解相关信息无法填写，敬请注明“无渠道了解相关信息”。</div><br />
                        1.名称：<asp:TextBox ID="txtTurnsAgentXX1" runat="server" Width="180px"></asp:TextBox>
                        　代理期：<asp:TextBox ID="txtAgencyBeginDate1" runat="server" Width="90px"></asp:TextBox>～<asp:TextBox ID="txtAgencyEndDate1" runat="server" Width="90px"></asp:TextBox><br />
                        　代理费：<asp:TextBox ID="txtAgencyFee3" runat="server" Width="120px"></asp:TextBox>
                        　现金奖：<asp:RadioButton ID="rdbIsCashPrize31" runat="server" Text="有，" GroupName="CashPrize3" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize3" runat="server" Width="140px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize32" runat="server" Text="无" GroupName="CashPrize3" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear31" runat="server" Text="有，比例" GroupName="IsPFear3" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear3" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear32" runat="server" Text="无" GroupName="IsPFear3" /><br />
                        2.名称：<asp:TextBox ID="txtTurnsAgentXX2" runat="server" Width="180px"></asp:TextBox>
                        　代理期：<asp:TextBox ID="txtAgencyBeginDate2" runat="server" Width="90px"></asp:TextBox>～<asp:TextBox ID="txtAgencyEndDate2" runat="server" Width="90px"></asp:TextBox><br />
                        　代理费：<asp:TextBox ID="txtAgencyFee4" runat="server" Width="120px"></asp:TextBox>　现金奖：<asp:RadioButton ID="rdbIsCashPrize41" runat="server" Text="有，" GroupName="CashPrize4" /><label for="r2d2b2"><asp:TextBox ID="txtCashPrize4" runat="server" Width="140px"></asp:TextBox>元/套</label><asp:RadioButton ID="rdbIsCashPrize42" runat="server" Text="无" GroupName="CashPrize4" /><br />
                        　项目费用：<asp:RadioButton ID="rdbIsPFear41" runat="server" Text="有，比例" GroupName="IsPFear4" />
                          <label for="r2d2b2"><asp:TextBox ID="txtPFear4" runat="server" Width="200px"></asp:TextBox></label>
                          <asp:RadioButton ID="rdbIsPFear42" runat="server" Text="无" GroupName="IsPFear4" /><br />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td class="tl PL10" colspan="3">
                        <asp:textbox id="txtRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="2" style="overflow: auto;"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>项目类型</td>
                    <td class="tl PL10" colspan="3">
                        <asp:RadioButton ID="rdbNewProj" runat="server" Text="新项目" GroupName="ProjType" /><asp:RadioButton ID="rdbOldProj" runat="server" Text="旧项目" GroupName="ProjType" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>			
                                <td>成交类型</td>
                                <td>成交宗数</td>
                                <td>成交业绩</td>
                                <td>期间累计税前利润</td>
                            </tr>
                            <tr>			
                                <td>时间</td>
                                <td colspan="2"><asp:TextBox ID="txtDealHistoryStartDate" runat="server" Width="80"></asp:TextBox>到<asp:TextBox ID="txtDealHistoryEndDate" runat="server" Width="80"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalProfitStartDate" runat="server" Width="80"></asp:TextBox>到<asp:TextBox ID="txtTotalProfitEndDate" runat="server" Width="80"></asp:TextBox></td>
                            </tr>
                            <tr>			
                                <td>独立成交</td>
                                <td><asp:TextBox ID="txtIndepCount" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtIndepPerformance" runat="server"></asp:TextBox></td>
                                <td rowspan="2"><asp:TextBox ID="txtTotalProfit" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>			
                                <td>联动成交</td>
                                <td><asp:TextBox ID="txtLinkCount" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtLinkPerformance" runat="server"></asp:TextBox>
                                     <asp:HiddenField id="hdGroupName" runat="server"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">审批流程</th></tr>
                <tr id="trManager1" class="noborder" style="height: 85px;">
                    <td >申请人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td >申请部门<br />负责人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow3" class="noborder" style="height: 85px;">
                    <td rowspan="2" >二级市场<br />负责人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx3" type="radio" name="agree3"/><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                        <input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label><br />
                        <textarea id="txtIDx3" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow4" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
                        <textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow5" class="noborder" style="height: 85px;"> 
                    <td rowspan="2" >法律部意见</td>                                                                                                           
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow6" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow7" class="noborder" style="height: 85px;"> 
                    <td rowspan="3" >财务部意见</td>                                                                                                           
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label>
                        <asp:CheckBox ID="ckbAddIDx" runat="server" Text="增加审批环节"  Visible="false"/><br />
                        <textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow8" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        <textarea id="txtIDx8" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow9">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx9" type="radio" name="agree9" value="1" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" value="2" /><label for="rdbNoIDx9">不同意</label><input id="rdbOtherIDx9" type="radio" name="agree9" value="3" /><label for="rdbOtherIDx9">其他意见</label><br />
                        <textarea id="txtIDx9" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S4"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
                        </span>
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
              <%--  <tr id="trShowFlow10" class="noborder" style="height: 85px;"> 
                    <td rowspan="4" >后勤事务部<br />意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>                                                                                                           
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">确认</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">退回申请</label><br />
                        <textarea id="txtIDx10" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx10">_________</span>
                        </span>
                    </td>
                </tr>--%>
                <tr id="trLogistics2" class="noborder" style="height: 85px;">
                    <td rowspan="3" >后勤事务部<br />意见<br />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>    

                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label><input id="rdbOtherIDx11" type="radio" name="agree11" value="1" /><label for="rdbOtherIDx11">其他意见</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx11" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx11">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" value="1" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx130">_________</span>
                        </span>
					</td>
				</tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>
                <tr id="trGeneralManager" class="noborder" style="height: 85px; ">
                    <td >董事总经理<br />审批</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label><input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label>
                        <input id="rdbOtherIDx12" type="radio" name="agree12" /><label for="rdbOtherIDx12">其他意见</label><br />
                        <textarea id="txtIDx12" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx12">_________</span>
                        </span>
                    </td>
                </tr>
                 
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label>
                        <input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx131">_________</span>
                        </span>
					</td>
				</tr>
                  <tr id="trGeneralGroups" class="noborder" style="height: 85px; display:none">
					        <td >集团意见</td>
					        <td colspan="3" class="tl PL10" style=" ">
						        <input id="rdbYesIDx1000" type="radio" name="agree1000" /><label for="rdbYesIDx1000">同意</label><input id="rdbNoIDx1000"  type="radio" name="agree1000" /><label for="rdbNoIDx1000">不同意</label>
                                <input id="rdbOtherIDx1000" type="radio" name="agree1000" /><label for="rdbOtherIDx1000">其他意见</label><br />
						        <textarea id="txtIDx1000" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1000" value="签署意见" onclick="sign('1000')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                                    日期：<span id="spanDateIDx1000">_________</span>
                                </span>
					        </td>
				        </tr>
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx200">_________</span>
                        </span>
					</td>
				</tr>

                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理复审</td>
					<td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#008162" />
						<textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx220">_________</span>
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
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>
        <asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnTemp" text="暂时保存" onclick="btnTempSave_Click" CssClass="commonbtn" onclientclick="return tempsavecheck();" />
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
    </div></div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        window.onload= function(){
       
            $("input[id*=btnSignID]").each(function () {
                var IsSigndisplay = $(this).css("display");
                if(IsSigndisplay != "undefined" && IsSigndisplay !='none')
                {
                    var content =''
                    if($(this).parent().prev().text() == "集团意见")
                    {
                        content =' <input name="btnCancelGroups" type="button" class="cssCancelGroups"    onclick="CancelGroups()" />';
                    }
                    else
                    {
                        content =' <input name="btnAddGroups" type="button" class="cssAddGroups"    onclick="AddGroups(2)" />';
                    }
                    $(this).prev().prev().prev().append(content);
                }
            })
            $("input[id*=btnSignID]").each(function () {
                if($(this).parent().prev().text() == "集团意见")
                {
                    var GroupName = $("#<%=hdGroupName.ClientID%>").val();
                    content =' <label style="color:black">'+GroupName+'</label>';
                    $(this).prev().prev().prev().append(content);
                }
                      })
        }
        </script>
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <%--<script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>--%>
</asp:Content>

