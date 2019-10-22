<%@ Page ValidateRequest="false" Title="撤铺/转铺申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_WithdrawShop_Detail.aspx.cs" Inherits="Apply_WithdrawShop_Apply_WithdrawShop_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
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

	        $("#<%=txtA3.ClientID %>").blur(function () {
	            if (isNaN($(this).val())) {
	                alert("租金押金损失金额必须输入纯数字！");
	                $(this).val('');
	                $(this).focus();
	            }
	            else
	                CaculateMThree();
	        });
	        $("#<%=txtB3.ClientID %>").blur(function () {
	            if (isNaN($(this).val())) {
	                alert("管理费押金损失金额必须输入纯数字！");
	                $(this).val('');
	                $(this).focus();
	            }
	            else
	                CaculateMThree();
	        });
	        $("#<%=txtC3.ClientID %>").blur(function () {
	            if (isNaN($(this).val())) {
	                alert("水电押金损失金额必须输入纯数字！");
	                $(this).val('');
	                $(this).focus();
	            }
	            else
	                CaculateMThree();
	        });
	        $("#<%=txtD1.ClientID %>").blur(function () {
	            if (isNaN($(this).val())) {
	                alert("违约金损失金额必须输入纯数字！");
	                $(this).val('');
	                $(this).focus();
	            }
	            else
	                CaculateMThree();
	        });
	        $("#<%=txtE2.ClientID %>").blur(function () {
	            if (isNaN($(this).val())) {
	                alert("税费必须输入纯数字！");
	                $(this).val('');
	                $(this).focus();
	            }
	            else
	                CaculateMThree();
	        });

	        $.each($("[id*=txtIDx]"),function(idx,item){autoTextarea(this);}); //使对话框自适应
	        $("#<%=txtDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {}
	        }); 
	        $("#<%=txtStartDate.ClientID%>").datepicker();
	        $("#<%=txtExpireDate.ClientID%>").datepicker();
	        $("#<%=txtPlanDate.ClientID%>").datepicker();//*-
	        $("#<%=txtPaymentAmortizeEndDate.ClientID%>").datepicker();
	       <%-- $("#<%=txtComputerAmortizeEndDate.ClientID%>").datepicker();--%>

	        $("#<%=txtAreaThisYStartDate.ClientID%>").datepicker();
	        $("#<%=txtAreaThisYEndDate.ClientID%>").datepicker();
	        $("#<%=txtBranchThisYStartDate.ClientID%>").datepicker();
	        $("#<%=txtBranchThisYEndDate.ClientID%>").datepicker();

	        //var text = document.getElementById("txtIDx14");
	        //autoTextarea(text); //使对话框自适应
	        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
	        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));
	        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
	    }); 

        function CaculateMThree(){
            var a;
            a = $("#<%=txtA3.ClientID%>").val()*1 
                + $("#<%=txtB3.ClientID%>").val()*1 
                + $("#<%=txtC3.ClientID%>").val()*1 
                + $("#<%=txtD1.ClientID%>").val()*1 
                + $("#<%=txtE2.ClientID%>").val()*1
            $("#<%=txtE3.ClientID%>").val(a);
        }

		function check() {
		    if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("申请部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {
	            alert("回复电话不可为空！");
	            $("#<%=txtReplyPhone.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtReplyFax.ClientID %>").val())=="") {
	            alert("回复传真不可为空！");
	            $("#<%=txtReplyFax.ClientID %>").focus();
	            return false;
            }

		    if (!$("#<%=rdbApplyType1.ClientID %>").prop("checked") && !$("#<%=rdbApplyType2.ClientID %>").prop("checked")) {
		        alert("请选择申请类型");
		        return false;
		    }
		    
		    if ($.trim($("#<%=ddlDepartmentType.ClientID %>").val()) == "") { alert("请选择区域！"); $("#<%=ddlDepartmentType.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=ddlMajordomo.ClientID %>").val()) == "") { alert("请选择总监！"); $("#<%=ddlMajordomo.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtDepartmentName.ClientID %>").val()) == "") { alert("分行名称不可为空！"); $("#<%=txtDepartmentName.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtDepartmentAddress.ClientID %>").val()) == "") { alert("分行地址不可为空！"); $("#<%=txtDepartmentAddress.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtStartDate.ClientID %>").val()) == "") { alert("租约开始日期不可为空！"); $("#<%=txtStartDate.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtExpireDate.ClientID %>").val()) == "") { alert("租约届满日期不可为空！"); $("#<%=txtExpireDate.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtPlanDate.ClientID %>").val()) == "") { alert("计划撤铺/转铺日期不可为空！"); $("#<%=txtPlanDate.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtReason.ClientID %>").val()) == "") { alert("撤铺/转铺原因不可为空！"); $("#<%=txtReason.ClientID %>").focus(); return false; }

		    if (!$("#<%=cbxAssetHandle1.ClientID %>").prop("checked") && !$("#<%=cbxAssetHandle2.ClientID %>").prop("checked")&& !$("#<%=cbxAssetHandle3.ClientID %>").prop("checked")) {
		        alert("请选择资产处理方式");
		        return false;
		    }
		    else if ($("#<%=cbxAssetHandle3.ClientID %>").prop("checked")) {
		        if ($("#<%=txtAssetHandleOther.ClientID %>").val() == "") {
		            alert("由于您选择了其他处理方式，请填写具体内容。");
		            $("#<%=txtAssetHandleOther.ClientID %>").focus();
		            return false;
                }
		    }     
            
		    if (!$("#<%=rdbPhoneHandle1.ClientID %>").prop("checked") && !$("#<%=rdbPhoneHandle2.ClientID %>").prop("checked")) {
		        alert("请选择电话处理方式");
		        return false;
		    }

		    if ($("#<%=rdbIsFlyLine.ClientID %>").prop("checked")) {
		        if ($("#<%=txtFlyLineFrom.ClientID %>").val() == "") {
                    alert("由于您选择了需要飞线，请填写飞线分行。");
                    $("#<%=txtFlyLineFrom.ClientID %>").focus();
		            return false;
		        }
		        if ($("#<%=txtFlyLineTo.ClientID %>").val() == "") {
		            alert("由于您选择了需要飞线，请填写被飞线分行。");
		            $("#<%=txtFlyLineTo.ClientID %>").focus();
                    return false;
                }
		    }    

		    if (!$("#<%=rdbCanBackDeposit.ClientID %>").prop("checked") && !$("#<%=rdbCannotBackDeposit.ClientID %>").prop("checked")) {
		        alert("请选择是否能够收回押金按金");
		        return false;
		    }

		    if ($.trim($("#<%=txtBackDeposit.ClientID %>").val()) == "") { alert("收回押金按金金额不可为空，没有则填0！"); $("#<%=txtBackDeposit.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtDeposit.ClientID %>").val()) == "") { alert("押金金额不可为空！"); $("#<%=txtDeposit.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtNoBackDeposit.ClientID %>").val()) == "") { alert("不能收回的押金按金金额不可为空，没有则填0！"); $("#<%=txtNoBackDeposit.ClientID %>").focus(); return false; }

		    if (!$("#<%=rdbWillNotLiquidatedDamages.ClientID %>").prop("checked") && !$("#<%=rdbWillLiquidatedDamages.ClientID %>").prop("checked")) {
		        alert("请选择会否产生违约金");
		        return false;
		    }
		    else if ($("#<%=rdbWillLiquidatedDamages.ClientID %>").prop("checked")) {
		        if ($("#<%=txtLiquidatedDamages.ClientID %>").val() == "") {
		            alert("由于您选择了会产生违约金 ，请填写产生违约金的金额。");
		            $("#<%=txtLiquidatedDamages.ClientID %>").focus();
		            return false;
                }
            }     
		    
		    if ($.trim($("#<%=txtPaymentAmortizeEndDate.ClientID %>").val()) == "") { alert("工程款摊销截止日期不可为空！"); $("#<%=txtPaymentAmortizeEndDate.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtPaymentAmortizeRemaining.ClientID %>").val()) == "") { alert("工程款摊销余额不可为空！"); $("#<%=txtPaymentAmortizeRemaining.ClientID %>").focus(); return false; }
		     
		   <%-- if ($.trim($("#<%=txtComputerAmortizeEndDate.ClientID %>").val()) == "") { alert("电脑和空调等固定资产摊销截止日期不可为空！"); $("#<%=txtComputerAmortizeEndDate.ClientID %>").focus(); return false; }--%>
		    if ($.trim($("#<%=txtComputerAmortizedRemaining.ClientID %>").val()) == "") { alert("电脑和空调等固定资产摊销余额不可为空！"); $("#<%=txtComputerAmortizedRemaining.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtTotalAmortizedBalance.ClientID %>").val()) == "") { alert("总启费用金额不可为空！"); $("#<%=txtTotalAmortizedBalance.ClientID %>").focus(); return false; }
		     
		    if ($.trim($("#<%=txtAreaLastYear.ClientID %>").val()) == "") { alert("区域上一年度时间不可为空！"); $("#<%=txtAreaLastYear.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtAreaLastYearResults.ClientID %>").val()) == "") { alert("区域上一年度累计业绩不可为空！"); $("#<%=txtAreaLastYearResults.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtAreaLastYearProfit.ClientID %>").val()) == "") { alert("区域上一年度累计利润不可为空！"); $("#<%=txtAreaLastYearProfit.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtAreaThisYResults.ClientID %>").val()) == "") { alert("区域本年度累计业绩不可为空！"); $("#<%=txtAreaThisYResults.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtAreaThisYProfit.ClientID %>").val()) == "") { alert("区域本年度累计利润不可为空！"); $("#<%=txtAreaThisYProfit.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtBranchLastYear.ClientID %>").val()) == "") { alert("分行上一年度时间不可为空！"); $("#<%=txtBranchLastYear.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtBranchLastYResults.ClientID %>").val()) == "") { alert("分行上一年度累计业绩不可为空！"); $("#<%=txtBranchLastYResults.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtBranchLastYProfit.ClientID %>").val()) == "") { alert("分行上一年度累计利润不可为空！"); $("#<%=txtBranchLastYProfit.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtBranchThisYResults.ClientID %>").val()) == "") { alert("分行本年度累计业绩不可为空！"); $("#<%=txtBranchThisYResults.ClientID %>").focus(); return false; }
		    if ($.trim($("#<%=txtBranchThisYProfit.ClientID %>").val()) == "") { alert("分行本年度累计利润不可为空不可为空！"); $("#<%=txtBranchThisYProfit.ClientID %>").focus(); return false; }

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
		        window.location='Apply_WithdrawShop_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_WithdrawShop_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
		    if(win=='success')
		        window.location="Apply_WithdrawShop_Detail.aspx?MainID=<%=MainID %>";
                }
		        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
                function sign(idx) {
                    //if(idx!='11'&&idx!='12'&&idx!='15'&&idx!='14'&&idx!='130'&&idx!='131'){
                    //if(idx=='1'||idx=='2'||idx=='3'||idx=='6'||idx=='7'||idx=='8'||idx=='9'||idx=='10'||idx=='13'){//789
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
		            data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+14,
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

        //var autoTextarea = function (elem, extra, maxHeight) { //对话框自适应
        //    extra = extra || 0;
        //    var isFirefox = !!document.getBoxObjectFor || 'mozInnerScreenX' in window,
        //    isOpera = !!window.opera && !!window.opera.toString().indexOf('Opera'),
        //            addEvent = function (type, callback) {
        //                elem.addEventListener ?
        //                        elem.addEventListener(type, callback, false) :
        //                        elem.attachEvent('on' + type, callback);
        //            },
        //            getStyle = elem.currentStyle ? function (name) {
        //                var val = elem.currentStyle[name];
 
        //                if (name === 'height' && val.search(/px/i) !== 1) {
        //                    var rect = elem.getBoundingClientRect();
        //                    return rect.bottom - rect.top -
        //                            parseFloat(getStyle('paddingTop')) -
        //                            parseFloat(getStyle('paddingBottom')) + 'px';        
        //                };
 
        //                return val;
        //            } : function (name) {
        //                return getComputedStyle(elem, null)[name];
        //            },
        //            minHeight = parseFloat(getStyle('height'));
 
        //    elem.style.resize = 'none';
 
        //    var change = function () {
        //        var scrollTop, height,
        //                padding = 0,
        //                style = elem.style;
 
        //        if (elem._length === elem.value.length) return;
        //        elem._length = elem.value.length;
 
        //        if (!isFirefox && !isOpera) {
        //            padding = parseInt(getStyle('paddingTop')) + parseInt(getStyle('paddingBottom'));
        //        };
        //        scrollTop = document.body.scrollTop || document.documentElement.scrollTop;
 
        //        elem.style.height = minHeight + 'px';
        //        if (elem.scrollHeight > minHeight) {
        //            if (maxHeight && elem.scrollHeight > maxHeight) {
        //                height = maxHeight - padding;
        //                style.overflowY = 'auto';
        //            } else {
        //                height = elem.scrollHeight - padding;
        //                style.overflowY = 'hidden';
        //            };
        //            style.height = height + extra + 'px';
        //            scrollTop += parseInt(style.height) - elem.currHeight;
        //            document.body.scrollTop = scrollTop;
        //            document.documentElement.scrollTop = scrollTop;
        //            elem.currHeight = parseInt(style.height);
        //        };
        //    };
 
        //    addEvent('propertychange', change);
        //    addEvent('input', change);
        //    addEvent('focus', change);
        //    change();
        //};

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
			<h1>撤铺/转铺申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
			<div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td style="width:150px;">申请部门</td>
					<td style="width:200px;" class="tl PL10"><input id="txtDepartment" type="text" runat="server" style="width:150px;"/></td>
					<td style="width: 150px; ">发文编号</td>
					<td class="tl PL10"><asp:Label ID="lblApplyID" runat="server"></asp:Label></td>
				</tr>
                <tr>
                    <td>填写人</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td>发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
					<td>回复电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtReplyPhone" runat="server" Width="100"></asp:TextBox></td>
                    <td>回复传真</td>
					<td class="tl PL10"><asp:TextBox ID="txtReplyFax" runat="server" Width="100"></asp:TextBox></td>
				</tr>
                <tr>
                    <th colspan="4" style="line-height:25px;" >申请正文</th>
				</tr>
                <tr>
					<td>申请类别</td>
					<td class="tl PL10" colspan="3"><asp:RadioButton ID="rdbApplyType1" runat="server" Text="撤铺" GroupName="ApplyType"/>&nbsp;&nbsp;<asp:RadioButton ID="rdbApplyType2" runat="server" Text="转铺" GroupName="ApplyType" /></td>
				</tr>
                <tr>
					<td>区域</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlDepartmentType" runat="server"></asp:DropDownList></td>
                    <td>区域负责人</td>
					<td class="tl PL10"><asp:DropDownList ID="ddlMajordomo" runat="server"></asp:DropDownList></td>
				</tr>
                <tr>
					<td>分行名称</td>
					<td class="tl PL10"><asp:TextBox ID="txtDepartmentName" runat="server"></asp:TextBox></td>
                    <td>分行地址</td>
					<td class="tl PL10"><asp:TextBox ID="txtDepartmentAddress" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
					<td>租约开始日期</td>
					<td class="tl PL10"><asp:TextBox ID="txtStartDate" runat="server" Width="100px"></asp:TextBox></td>
                    <td>租约届满日期</td>
					<td class="tl PL10"><asp:TextBox ID="txtExpireDate" runat="server" Width="100px"></asp:TextBox></td>
				</tr>

                <tr>
                    <td>计划撤铺/转铺日期</td>
					<td class="tl PL10" colspan="3"><asp:TextBox ID="txtPlanDate" runat="server" Width="100px"></asp:TextBox></td>
				</tr>

                <tr>
                    <td>撤铺/转铺原因</td>
					<td class="tl PL10" colspan="3">
						<asp:textbox id="txtReason" runat="server" TextMode="MultiLine" Width="98%" Rows="10" style="overflow: auto;" Height="228px"></asp:textbox><br /><br />
                        <span style="color:red;">区域须上传撤铺解释函，及该铺新开分行时递交的可行性报告担保函（如有）</span>
					</td>
				</tr>
                <tr class="noborder">
					<td class="tl PL10" colspan="4">
						1）资产处理：（上资产调动或报废表）
					</td>
				</tr>
                <tr class="noborder">
					<td class="tl PL10" colspan="4">
						<asp:CheckBox ID="cbxAssetHandle1" runat="server" Text="调回公司仓库" GroupName="AssetHandle"/>&nbsp;&nbsp;<asp:CheckBox ID="cbxAssetHandle2" runat="server" Text="区域调用" GroupName="AssetHandle" />
					</td>
				</tr>
                <tr class="noborder">
					<td class="tl PL10" colspan="4">
						<asp:CheckBox ID="cbxAssetHandle3" runat="server" Text="其他" GroupName="AssetHandle"/><asp:textbox id="txtAssetHandleOther" runat="server" TextMode="MultiLine" Width="98%" Rows="2" style="overflow: auto; "></asp:textbox>
					</td>
				</tr>
                
                <tr class="noborder">
					<td class="tl PL10" colspan="4">
						2）分行摊销费用：
					</td>
				</tr>
                 <tr class="noborder">
					<td class="tl PL10" colspan="4">
						总启费用金额<asp:TextBox ID="txtTotalAmortizedBalance" runat="server" Width="90px"></asp:TextBox>元
					</td>
				</tr>
                 <tr class="noborder">
					<td class="tl PL10" colspan="4">
						分行截至申请月的工程款摊销余额为<asp:TextBox ID="txtPaymentAmortizeRemaining" runat="server" Width="90"></asp:TextBox>元 ，摊销到期日为<asp:TextBox ID="txtPaymentAmortizeEndDate" runat="server" Width="100"></asp:TextBox><br /><br />
                        电脑和空调等固定资产净值为<asp:TextBox ID="txtComputerAmortizedRemaining" runat="server" Width="90px"></asp:TextBox>元<%--，<span>摊销到期日为</span><asp:TextBox ID="txtComputerAmortizeEndDate" runat="server" Width="100px"></asp:TextBox><br />--%><br />
                        备注：摊销数据可向财务部同事源浩灵查核,总启费用可向行政部咨询
					</td>
				</tr>
                


                <tr class="noborder">
					<td class="tl PL10" colspan="4">
						3）电话处理：
					</td>
				</tr>
                <tr class="noborder">
					<td class="tl PL10" colspan="4">
						<asp:RadioButton ID="rdbPhoneHandle1" runat="server" Text="全部撤销" GroupName="PhoneHandle"/>&nbsp;&nbsp;<asp:RadioButton ID="rdbPhoneHandle2" runat="server" Text="停机留号（直线5元 / 月 / 条，中继线15元 / 月 / 条）" GroupName="PhoneHandle" />
					</td>
				</tr>
                <tr class="noborder">
					<td class="tl PL10" colspan="4">
                        <asp:RadioButton ID="rdbIsFlyLine" runat="server" Text="飞线（被飞入分行每条中继线 / 直线月租多35元）" /><asp:TextBox ID="txtFlyLineFrom" runat="server" Width="90px"></asp:TextBox>飞至<asp:TextBox ID="txtFlyLineTo" runat="server" Width="90px"></asp:TextBox>
					</td>
				</tr>          
                <tr class="noborder" style="display:none;">
					<td class="tl PL10" colspan="4">
						3) 能否回收按金 / 押金
					</td>
				</tr>
                <tr class="noborder" style="display:none;">
					<td class="tl PL10" colspan="4">
                        押金<asp:TextBox ID="txtDeposit" runat="server">0</asp:TextBox> 是否能回收押金
						<asp:RadioButton ID="rdbCanBackDeposit" runat="server" Text="能" GroupName="BackDeposit" Checked="True"/>&nbsp;<asp:RadioButton ID="rdbCannotBackDeposit" runat="server" Text="不能" GroupName="BackDeposit" />
                        <br />
                        能收回部分<asp:TextBox ID="txtBackDeposit" runat="server" Width="125px">0</asp:TextBox>（具体填写金额）
                        不能收回部分<asp:TextBox ID="txtNoBackDeposit" runat="server" Width="125px">0</asp:TextBox>（具体填写金额）
					</td>
				</tr>

                <tr class="noborder">
                    <td class="tl PL10" colspan="4">4）撤铺损失费用</td>
                </tr>
                <tr>
                    <td colspan="4" style="padding: 5px; text-align: left; line-height: 20px;">
                        <table style="border-collapse: collapse; line-height: 20px; text-align: center;" align="center" width="70%">
                            <tr>
                                <td>项目</td>
                                <td>实际支出金额</td>
                                <td>能收回金额</td>
                                <td>损失金额</td>
                            </tr>
                            <tr>
                                <td>1. 租金押金</td>
                                <td><asp:TextBox ID="txtA1" runat="server" Width="100px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtA2" runat="server" Width="100px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtA3" runat="server" Width="100px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>2. 管理费押金</td>
                                <td><asp:TextBox ID="txtB1" runat="server" Width="100px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtB2" runat="server" Width="100px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtB3" runat="server" Width="100px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>3. 水电押金</td>
                                <td><asp:TextBox ID="txtC1" runat="server" Width="100px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtC2" runat="server" Width="100px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtC3" runat="server" Width="100px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>4. 违约金</td>
                                <td>-</td>
                                <td>-</td>
                                <td><asp:TextBox ID="txtD1" runat="server" Width="100px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>税率</td>
                                <td colspan="3"><asp:TextBox ID="txtE1" runat="server" Width="96%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>税费</td>
                                <td colspan="3"><asp:TextBox ID="txtE2" runat="server" Width="96%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>合计</td>
                                <td colspan="3"><asp:TextBox ID="txtE3" runat="server" Width="96%"></asp:TextBox></td>
                            </tr>
                        </table>
                        备注：由于损失费用需要开具发票对冲，“税率”为开发票税率，“税费”为发票税费，“合计”为损失金额及发票税费的总和。
                    </td>
                </tr>

                <tr class="noborder">
                    <td class="tl PL10" colspan="4">5）管理帐的累计业绩及累计利润</td>
                </tr>

                <tr class="noborder">
                    <td class="tl PL10" colspan="4">
                      <span style="font-weight: bolder">
                           1、区域上一年度（即<asp:textbox id="txtAreaLastYear" runat="server" Font-Bold="False" Width="100px"></asp:textbox>年）管理帐的累计业绩￥<asp:textbox id="txtAreaLastYearResults" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元，及累计利润￥<asp:textbox id="txtAreaLastYearProfit" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元。
                       </span><br /><br />
                        <span style="font-weight: bolder">
                           2、区域本年度截至申请日（即<asp:textbox id="txtAreaThisYStartDate" runat="server" Font-Bold="False" Width="100px"></asp:textbox>至<asp:textbox id="txtAreaThisYEndDate" runat="server" Font-Bold="False" Width="100px"></asp:textbox>）管理帐的累计业绩￥<asp:textbox id="txtAreaThisYResults" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元，及累计利润￥<asp:textbox id="txtAreaThisYProfit" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元。
                       </span><br /><br />
                        <span style="font-weight: bolder">
                           3、分行上一年度（即<asp:textbox id="txtBranchLastYear" runat="server" Font-Bold="False" Width="100px"></asp:textbox>年）管理帐的累计业绩￥<asp:textbox id="txtBranchLastYResults" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元，及累计利润￥<asp:textbox id="txtBranchLastYProfit" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元。
                       </span><br /><br />
                        <span style="font-weight: bolder">
                           4、分行本年度截至申请日（即<asp:textbox id="txtBranchThisYStartDate" runat="server" Font-Bold="False" Width="100px"></asp:textbox>至<asp:textbox id="txtBranchThisYEndDate" runat="server" Font-Bold="False" Width="100px"></asp:textbox>）管理帐的累计业绩￥<asp:textbox id="txtBranchThisYResults" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元，及累计利润￥<asp:textbox id="txtBranchThisYProfit" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元。
                       </span><br /><br />
                    </td>
                </tr>

                <tr class="noborder" style="display:none;">
					<td class="tl PL10" colspan="4">
						4) 会否产生违约金
					</td>
				</tr>
                <tr class="noborder" style="display:none;">
					<td class="tl PL10" colspan="4">
						<asp:RadioButton ID="rdbWillNotLiquidatedDamages" runat="server" Text="否" GroupName="LiquidatedDamages" Checked="True"/>&nbsp;&nbsp;<asp:RadioButton ID="rdbWillLiquidatedDamages" runat="server" Text="是" GroupName="LiquidatedDamages" /><asp:TextBox ID="txtLiquidatedDamages" runat="server">0</asp:TextBox>（填写具体金额）
					</td>
				</tr>
               
				<tr>
                    <th colspan="4" style="line-height:25px;" >审批流程</th>
				</tr>
                <tr id="trManager1" class="noborder" style="height: 85px; border-top:1px solid #000000;">
					<td>部门主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td>隶属主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td>部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow4" class="noborder" style="height: 85px;"> 
					<td rowspan="2" >行政部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">确认</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">退回申请</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow5" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
                	<tr id="trCoo" class="noborder" style="height: 85px; ">
					<td >首席运营官</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label>
                        <input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label>
                        <input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
						<textarea id="txtIDx10" style="width: 98%; overflow: auto; height: 84px;"></textarea>
                        <input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow6" class="noborder" style="height: 85px;"> 
					<td rowspan="2" >外联部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx16" type="radio" name="agree16" /><label for="rdbYesIDx16">确认</label>
                        <input id="rdbNoIDx16" type="radio" name="agree16" /><label for="rdbNoIDx16">退回申请</label><br />
						<textarea id="txtIDx16" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx16" value="签署意见" onclick="sign('16')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx16">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow7" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx17" type="radio" name="agree17" /><label for="rdbYesIDx17">同意</label>
                        <input id="rdbNoIDx17" type="radio" name="agree17" /><label for="rdbNoIDx17">不同意</label><br />
						<textarea id="txtIDx17" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx17" value="签署意见" onclick="sign('17')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx17">_________</span></div>
					</td>
				</tr>
                <tr id="trShowFlow8" class="noborder" style="height: 85px;"> 
					<td rowspan="2" >法律部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx18" type="radio" name="agree18" /><label for="rdbYesIDx18">同意</label>
                        <input id="rdbNoIDx18" type="radio" name="agree18" /><label for="rdbNoIDx18">不同意</label><br />
						<textarea id="txtIDx18" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx18" value="签署意见" onclick="sign('18')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx18">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow19" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx19" type="radio" name="agree19" /><label for="rdbYesIDx19">同意</label>
                        <input id="rdbNoIDx19" type="radio" name="agree19" /><label for="rdbNoIDx19">不同意</label><br />
						<textarea id="txtIDx19" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx19" value="签署意见" onclick="sign('19')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx19">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow10" class="noborder" style="height: 85px;"> 
					<td rowspan="3" >财务部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx20" type="radio" name="agree20" /><label for="rdbYesIDx20">确认</label>
                        <input id="rdbNoIDx20" type="radio" name="agree20" /><label for="rdbNoIDx20">退回申请</label><br />
						<textarea id="txtIDx20" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx20" value="签署意见" onclick="sign('20')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx20">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow11" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx21" type="radio" name="agree21" /><label for="rdbYesIDx21">同意</label>
                        <input id="rdbNoIDx21" type="radio" name="agree21" /><label for="rdbNoIDx21">不同意</label>
                        <input id="rdbOtherIDx21" type="radio" name="agree21" /><label for="rdbOtherIDx21">其他意见</label>
                        　<asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton>
                        <br />
						<textarea id="txtIDx21" style="width: 98%; overflow: auto; height: 86px;"></textarea>
                        <input type="button" id="btnSignIDx21" value="签署意见" onclick="sign('21')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx21">_________</span></div>
					</td>
				</tr>
                <tr id="trShowFlow12" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx22" type="radio" name="agree22" /><label for="rdbYesIDx22">同意</label>
                        <input id="rdbNoIDx22" type="radio" name="agree22" /><label for="rdbNoIDx22">不同意</label>
                        <input id="rdbOtherIDx22" type="radio" name="agree22" /><label for="rdbOtherIDx22">其他意见</label><br />
						<textarea id="txtIDx22" style="width: 98%; overflow: auto; height: 84px;"></textarea>
                        <input type="button" id="btnSignIDx22" value="签署意见" onclick="sign('22')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx22">_________</span></div>
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
                <%--<tr id="trShowFlow23" class="noborder" style="height: 85px;"> 
					<td rowspan="4" >后勤事务部<br />意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" />
					</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx23" type="radio" name="agree23" /><label for="rdbYesIDx23">确认</label>
                        <input id="rdbNoIDx23" type="radio" name="agree23" /><label for="rdbNoIDx23">退回申请</label><br />
						<textarea id="txtIDx23" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx23" value="签署意见" onclick="sign('23')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx23">_________</span></div>
                    </td>
				</tr>--%>
				<tr id="trLogistics2" class="noborder" style="height: 85px;">
                    <td rowspan="3" >后勤事务部意见<br />
                        
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" />
                    </td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx24" type="radio" name="agree24" /><label for="rdbYesIDx24">同意</label>
                        <input id="rdbNoIDx24" type="radio" name="agree24" /><label for="rdbNoIDx24">不同意</label>
                        <input id="rdbOtherIDx24" type="radio" name="agree24" value="1" /><label for="rdbOtherIDx24">其他意见</label>
                        <a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                        <a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
						<textarea id="txtIDx24" style="width: 98%; overflow: auto;" rows="9"></textarea>
                        <input type="button" id="btnSignIDx24" value="签署意见" onclick="sign('24')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx24">_________</span></div>
                    </td>
				</tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130"  value="1" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>
                
				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx25" type="radio" name="agree25" /><label for="rdbYesIDx25">同意</label>
                        <input id="rdbNoIDx25" type="radio" name="agree25" /><label for="rdbNoIDx25">不同意</label>
                        <input id="rdbOtherIDx25" type="radio" name="agree25" /><label for="rdbOtherIDx25">其他意见</label><br />
						<textarea id="txtIDx25" style="width: 98%; overflow: auto; height: 84px;"></textarea>
                        <input type="button" id="btnSignIDx25" value="签署意见" onclick="sign('25')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx25">_________</span></div>
					</td>
				</tr>
                
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
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
            <div style="clear:both;"></div>
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
        <asp:button runat="server" id="btnTemp" text="暂时保存" onclick="btnTempSave_Click" CssClass="commonbtn" />
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
    <script type="text/javascript">
        AddOtherAgree();
    </script>
	<%=SbJs.ToString() %>
    <script type="text/javascript">
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
        autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
</asp:Content>
