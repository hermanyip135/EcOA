<%@ Page ValidateRequest="false" Title="发展商额外奖金新增申请及调整申请 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_EBAdjuct_Detail.aspx.cs" Inherits="Apply_EBAdjuct_Apply_EBAdjuct_Detail" %>
<%@ Register Src="~/Common/User_AutoComplete.ascx" TagName="User_AutoComplete" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--    <link rel="stylesheet" type="text/css" href="~/Script/jquery.autocomplete.css" />
    <script type="text/javascript" src="~/Script/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="~/Script/jquery.autocomplete.min.js"></script>--%>
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1, i2 = 1, i3 = 1;
        var jJSON = <%=SbJson.ToString() %>;
        var jsad = "";

        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        var jsccesp = <%=SbCcesp.ToString() %>;
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

		$(function() {      

		    //$("#<%=txtApplyID.ClientID %>").autocomplete2({
		    //    url: 'http://<%=Request.Url.Authority %>/Common/User_AutoComplete.ashx?t=GetEstate',
		    //    values: true,
		    //    writable: false,
		    //    onSelect: function() {
		    //        $("#<%=hfKey.ClientID %>").val(this.pairs[this.ac.val()]);
		    //        var funName = "('" + this.ac.val() + "','" + this.pairs[this.ac.val()] + "')";
		    //        if (funName != "") {
		    //            eval(funName);
		    //        }
		    //    },
		    //    type: 'json',
		    //    onKeyPress: function() {
		    //        $("#<%=hfKey.ClientID %>").val("");
		    //    },
		    //    width: '200'
		    //});

		    //$("#<%=txtApplyID.ClientID %>").focus().autocomplete({ 
		    //    url: '~/Common/User_AutoComplete.ashx?t=GetEstate',
		    //    delay: 10,
		    //    minChars: 1,
		    //    autoFill: true,
		    //    max: 10000,
		    //    formatResult: function(row) {
		    //        return row[0].split(",")[0];
		    //    },
		    //    autoFill: false
		    //});

		    //$.ajax({
		    //    url: "User_AutoComplete.ashx?t=GetEstate&mask=5",
		    //    type: "post",
		    //    dataType: "text",
		    //    //data: "t=GetEstate&mask=5",
		    //    success: function(info) {
		    //        if (info != "") {
		    //            jsad= info;
		    //        }
		    //        else
		    //            alert("错误代码："+ info);
		    //    },
		    //    error: function(er){
		    //        alert(er.responseText);
		    //    }
		    //})
		    $("#<%=txtApplyID.ClientID %>").autocomplete({ 
		        source: jsccesp,
		        select: function(event,ui) {
		            $("#<% =hfKey.ClientID%>").val(ui.item.id);
                }
		    });


		    //$("#<%=txtApplyID.ClientID %>").blur(function(){
		    //    AutoAjax();
		    //})


			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});

		    i = $("#tbDetail tr").length - 1;
		    i2 = $("#tbDetail2 tr").length - 1;
		    i3 = $("#tbDetail3 tr").length - 1;
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}

		    $("#<%=txtValidityBeginDate.ClientID%>").datepicker();
		    $("#<%=txtValidityEndDate.ClientID%>").datepicker();
		    $("#<%=txtSubmitDate.ClientID%>").datepicker();

		    $("#<%=txtBonusMoney.ClientID%>").blur(function () {
		        if(isNaN($("#<%=txtBonusMoney.ClientID%>").val())){
		            alert("新增/调整现金奖必须输入纯数字！");
		            $("#<%=txtBonusMoney.ClientID%>").val('');
		            $("#<%=txtBonusMoney.ClientID%>").focus();
		        }
                else
		            $("#<%=txtBonusMoney2.ClientID%>").val($("#<%=txtBonusMoney.ClientID%>").val());
		    });

		    //for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		    //    $("#ros1").attr("rowspan", i);
		    //    $("#ros2").attr("rowspan", i);
		    //    $("#txtBeginData" + x).datepicker();
		    //    $("#txtEndData" + x).datepicker();
		    //}
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

	    function check() {
	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("项目名称不可为空！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("申请部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }
			
	        if($.trim($("#<%=txtApply.ClientID %>").val())=="") {
	            alert("申请人不可为空！");
	            $("#<%=txtApply.ClientID %>").focus();
	            return false;
	        }

	        if(!$("#<%=rdbBonusC11.ClientID %>").prop("checked") && !$("#<%=rdbBonusC12.ClientID%>").prop("checked")){
	            alert("请选择现金奖情况！");
	            $("#<%=rdbBonusC11.ClientID %>").focus();
                return false;
	        }

	        if($.trim($("#<%=txtProjectPCMomey.ClientID %>").val())=="") {
	            alert("项目的发展商佣金不可为空！");
	            $("#<%=txtProjectPCMomey.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtProjectEBMomey.ClientID %>").val())=="") {
	            alert("项目的电商佣金不可为空！");
	            $("#<%=txtProjectEBMomey.ClientID %>").focus();
	            return false;
	        }

	        if(!$("#<%=rdbBonus41.ClientID %>").prop("checked") && !$("#<%=rdbBonus42.ClientID%>").prop("checked")){
	            alert("请选择第4项的现金奖情况！");
	            $("#<%=rdbBonus41.ClientID %>").focus();
	            return false;
            }

	        if($.trim($("#<%=txtValidityBeginDate.ClientID %>").val())=="") {
	            alert("有效期开始期不可为空！");
	            $("#<%=txtValidityBeginDate.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtValidityEndDate.ClientID %>").val())=="") {
	            alert("有效期结束期不可为空！");
	            $("#<%=txtValidityEndDate.ClientID %>").focus();
	            return false;
	        }

	        if(!$("#<%=rdbBonus51.ClientID %>").prop("checked") && !$("#<%=rdbBonus52.ClientID%>").prop("checked")){
	            alert("请选择第5项的现金奖情况！");
	            $("#<%=rdbBonus51.ClientID %>").focus();
	            return false;
	        }

	        if(!$("#<%=rdbBonusSituation1.ClientID %>").prop("checked") && !$("#<%=rdbBonusSituation2.ClientID%>").prop("checked")&& !$("#<%=rdbBonusSituation3.ClientID%>").prop("checked")){
	            alert("请选择现金奖的发放方式！");
	            $("#<%=rdbBonusSituation1.ClientID %>").focus();
	            return false;
            }

	        if($("#<%=rdbBonusSituation2.ClientID%>").prop("checked")){
	            if($.trim($("#<%=txtWholeName.ClientID %>").val())=="") {
	                alert("统筹人员姓名不可为空！");
	                $("#<%=txtWholeName.ClientID %>").focus();
	                return false;
	            }

	            if($.trim($("#<%=txtPosition.ClientID %>").val())=="") {
	                alert("职务不可为空！");
	                $("#<%=txtPosition.ClientID %>").focus();
	                return false;
	            }

	            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
	                alert("联系电话不可为空！");
	                $("#<%=txtPhone.ClientID %>").focus();
	                return false;
	            }

	            if($.trim($("#<%=txtAccountName.ClientID %>").val())=="") {
	                alert("帐户姓名不可为空！");
	                $("#<%=txtAccountName.ClientID %>").focus();
	                return false;
	            }

	            if($.trim($("#<%=txtNo.ClientID %>").val())=="") {
	                alert("账号不可为空！");
	                $("#<%=txtNo.ClientID %>").focus();
	                return false;
	            }
	        }
	        if($("#<%=rdbBonusSituation3.ClientID%>").prop("checked")){
	            if($.trim($("#<%=txtBonusSituationValue.ClientID %>").val())=="") {
	                alert("原奖金价值不可为空！");
	                $("#<%=txtBonusSituationValue.ClientID %>").focus();
	                return false;
	            }
	            if($.trim($("#<%=txtDiscountValue.ClientID %>").val())=="") {
	                alert("折现后价值不可为空！");
	                $("#<%=txtDiscountValue.ClientID %>").focus();
	                return false;
	            }
	            if($.trim($("#<%=txtCashPrize.ClientID %>").val())=="") {
	                alert("现金奖按照不可为空！");
	                $("#<%=txtCashPrize.ClientID %>").focus();
	                return false;
	            }
	            if($.trim($("#<%=txtCalculationMethod.ClientID %>").val())=="") {
	                alert("发放方式不可为空！");
	                $("#<%=txtCalculationMethod.ClientID %>").focus();
	                return false;
                }
	        }
	        if(!$("#<%=rdbIsTax1.ClientID %>").prop("checked") && !$("#<%=rdbIsTax2.ClientID%>").prop("checked")){
	            alert("请选择需开具发票并由我司支付税费！");
	            $("#<%=rdbIsTax1.ClientID %>").focus();
	            return false;
            }

	        if($.trim($("#<%=txtBonusMoney.ClientID %>").val())=="" || $.trim($("#<%=txtBonusMoney.ClientID %>").val())=="0") {
	            alert("现金奖不可为空，且不能为0！");
	            $("#<%=txtBonusMoney.ClientID %>").focus();
	            return false;
	        }

	        if(!$("#<%=rdbIsConfirm1.ClientID %>").prop("checked") && !$("#<%=rdbIsConfirm2.ClientID%>").prop("checked")){
	            alert("请选择是否提交确认书！");
	            $("#<%=rdbIsConfirm1.ClientID %>").focus();
	            return false;
            }

	        if($.trim($("#<%=txtSubmitDate.ClientID %>").val())=="") {
	            alert("提交公司日期不可为空！");
	            $("#<%=txtSubmitDate.ClientID %>").focus();
	            return false;
	        }

	        var data = "", data2 = "", data3 = "";
	        var flag = true;
	        $("#tbDetail tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail tr").size()) {
	                if ($.trim($("#txtDetail_Money" + n).val()) == "") {
	                    alert("第" + n + "行的金额必须填写。");
	                    $("#txtDetail_Money" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtDetail_Condition" + n).val()) == "") {
	                    alert("第" + n + "行的发放条件必须填写。");
	                    $("#txtDetail_Condition" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data += $.trim($("#txtDetail_Money" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Condition" + n).val()) 
                            + "||";
	            }
	        });

	        $("#tbDetail2 tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail2 tr").size()) {
	                if ($.trim($("#txtLeaseTerm_Money" + n).val()) == "") {
	                    alert("第" + n + "行的金额必须填写。");
	                    $("#txtLeaseTerm_Money" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtLeaseTerm_Reason" + n).val()) == "") {
	                    alert("第" + n + "行的原因必须填写。");
	                    $("#txtLeaseTerm_Reason" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtLeaseTerm_Condition" + n).val()) == "") {
	                    alert("第" + n + "行的发放条件必须填写。");
	                    $("#txtLeaseTerm_Condition" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data2 += $.trim($("#txtLeaseTerm_Money" + n).val()) 
                            + "&&" + $.trim($("#txtLeaseTerm_Reason" + n).val()) 
                            + "&&" + $.trim($("#txtLeaseTerm_Condition" + n).val()) 
                            + "||";
	            }
	        });

	        $("#tbDetail3 tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail3 tr").size()) {
	                if (!$("#rdoStatistical_Adjuct" + n + "1").prop('checked') && !$("#rdoStatistical_Adjuct" + n + "0").prop('checked')) {
	                    alert("请选择第" + n + "行的调整情况。");
	                    $("#rdoStatistical_Adjuct" + n + "1").focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtStatistical_Money" + n).val()) == "") {
	                    alert("第" + n + "行的金额必须填写。");
	                    $("#txtStatistical_Money" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_Reason" + n).val()) == "") {
	                    alert("第" + n + "行的原因必须填写。");
	                    $("#txtStatistical_Reason" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_Condition" + n).val()) == "") {
	                    alert("第" + n + "行的发放条件必须填写。");
	                    $("#txtStatistical_Condition" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data3 += ($("#rdoStatistical_Adjuct" + n + "1").prop('checked')?"1":"0")
                            + "&&" + $.trim($("#txtStatistical_Money" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_Reason" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_Condition" + n).val()) 
                            + "||";
	            }
	        });

	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdDetail.ClientID %>").val(data);

	            data2 = data2.substr(0, data2.length - 2);
	            $("#<%=hdDetail1.ClientID %>").val(data2);

	            data3 = data3.substr(0, data3.length - 2);
	            $("#<%=hdDetail2.ClientID %>").val(data3);
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
		    var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
			if(sReturnValue=='success')
				window.location='Apply_EBAdjuct_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
			var win=window.showModalDialog("Apply_EBAdjuct_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_EBAdjuct_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx!='7'&&idx!='8'10||idx=='130'){
	        //if(idx=='1'||idx=='2'||idx=='3'||idx=='8'){//789
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
		    i ++;
		    var html = '<tr id="trDetail' + i + '">'
				+ '         <td style="text-align: left; padding-left: 10px"><input type="text" id="txtDetail_Money' + i + '" style="width:80px"/>元/套，发放条件是'
                + '         <input type="text" id="txtDetail_Condition' + i + '" style="width:400px"/></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
		    $("#trFlag").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
		}

		function addRow2() {
		    i2++;
		    var html = '<tr id="trDetail2' + i2 + '">'
				+ '         <td style="text-align: left; padding-left: 10px">新增<input type="text" id="txtLeaseTerm_Money' + i2 + '" style="width:80px"/>元/套，原因：'
                + '         <input type="text" id="txtLeaseTerm_Reason' + i2 + '" style="width:165px"/>发放条件是'
                + '         <input type="text" id="txtLeaseTerm_Condition' + i2 + '" style="width:165px"/></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i2 + '"><table><tr><td>这是'+ i2 +'个</td></tr></table></tr>'
		    $("#trFlag2").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i2 +"个</td></tr>");
		}

		function addRow3() {
		    i3++;
		    var html = '<tr id="trDetail3' + i3 + '">'
                + '         <td style="text-align: left; padding-left: 10px"><input type="radio" id="rdoStatistical_Adjuct' + i3 + '1" name="Statistical_Adjuct' + i3 + '" /><label for="rdoStatistical_Adjuct' + i3 + '1">增加</label><input type="radio" id="rdoStatistical_Adjuct' + i3 + '0" name="Statistical_Adjuct' + i3 + '" /><label for="rdoStatistical_Adjuct' + i3 + '0">减少</label>'
				+ '         <input type="text" id="txtStatistical_Money' + i3 + '" style="width:80px"/>元/套，原因：'
                + '         <input type="text" id="txtStatistical_Reason' + i3 + '" style="width:130px"/>发放条件是'
                + '         <input type="text" id="txtStatistical_Condition' + i3 + '" style="width:130px"/></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i2 + '"><table><tr><td>这是'+ i2 +'个</td></tr></table></tr>'
		    $("#trFlag3").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i2 +"个</td></tr>");
		}

		function deleteRow() {
		    if (i > 1) {
			    i --;
			    $("#tbDetail tr:eq(" + i + ")").remove();
			} else
		        alert("不可删除第一行。");
		}

		function deleteRow2() {
		    if (i2 > 1) {
		        i2--;
		        $("#tbDetail2 tr:eq(" + i2 + ")").remove();
		    } else
		        alert("不可删除第一行。");
		    //$("#tbDetail tr:eq(0)").remove();
		}

		function deleteRow3() {
		    if (i3 > 1) {
		        i3--;
		        $("#tbDetail3 tr:eq(" + i3 + ")").remove();
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
        function AutoAjax(){
            $.ajax({
                url: "User_AutoComplete.ashx?t=GetEstate&mask=5",
                type: "post",
                dataType: "text",
                //data: "t=GetEstate&mask=5",
                success: function(info) {
                    if (info != "") {
                        alert("*"+info+"*");
                    }
                    else
                        alert("错误代码："+ info);
                },
                error: function(er){
                    alert(er.responseText);
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
    <style type="text/css">
        .auto-style1 {
            width: 15%;
        }
        .auto-style3 {
            width: 175px;
        }
        .auto-style4 {
            width: 180px;
        }
        .auto-style5 {
            width: 165px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>发展商额外奖金新增申请及调整申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <%--<div id="snum" style="width:640px;margin:0 auto;"></div>--%>
			<table id="tbAround"  width='640px'>
				<tr>
					<td class="auto-style1">申请部门</td>
					<td  class="auto-style5">
<%--                        <script type="text/javascript" src="/Script/jquery-ui-1.10.1.custom.min.js"></script>
                        <script type="text/javascript" src="/Script/jquery.ui.datepicker-zh-CN.js"></script>--%>
                        <script type="text/javascript" language="javascript">
                            //$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
                            //$(function() {
                            //    $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                            //        source: jJSON,
                            //        select: function(event,ui) {
                            //            $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                            //        }
                            //    });
                            //});
                        </script>
                        <asp:textbox id="txtDepartment" runat="server"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" />
					</td>
					<td class="auto-style3">申请人</td>
					<td class="tl PL10"><asp:textbox id="txtApply" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td class="auto-style1">申请日期</td>
					<td class="auto-style5"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                    <td class="auto-style3">文档编码(自动生成)</td>
					<td class="tl PL10"><span><%=SerialNumber %></span></td>
				</tr>
				<tr>
					<td class="tl PL10" colspan="4">
                        <asp:RadioButton ID="rdbBonusC11" runat="server" GroupName="BonusC1" Text="新增现金奖（适用于项目报备未提及有现金奖，后来补充的情况）" /><br />
                        <asp:RadioButton ID="rdbBonusC12" runat="server" GroupName="BonusC1" Text="调整现金奖（适用于项目报备已说明有现金奖，后来调整的情况）" />
					</td>
				</tr>

				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 30px">
                        一、项目名称：<asp:textbox id="txtApplyID" runat="server" Width="465px"></asp:textbox><br />
                        <%--<uc3:User_AutoComplete ID="uacEstateCCES" runat="server"  Mode="GetEstate" Width="300" />--%>
                        
                        二、项目的发展商佣金：<asp:textbox id="txtProjectPCMomey" runat="server"></asp:textbox>　
                        项目的电商佣金：<asp:textbox id="txtProjectEBMomey" runat="server"></asp:textbox><br />
                        三、项目原有现金奖的金额及发放条件：<br />
						<table id="tbDetail" width='98%' class='sample tc'>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag">
                                <td></td>
                            </tr>
						</table>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none;"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
                        <br />
                        四、<asp:RadioButton ID="rdbBonus41" runat="server" GroupName="Bonus4" Text="新增现金奖" />
                        <asp:RadioButton ID="rdbBonus42" runat="server" GroupName="Bonus4" Text="调整现金奖" />
                        的有效期：<asp:textbox id="txtValidityBeginDate" runat="server"></asp:textbox>至
                        <asp:textbox id="txtValidityEndDate" runat="server"></asp:textbox><br />
                        五、新增/调整的现金奖金额及发放条件：<br />
                        <asp:RadioButton ID="rdbBonus51" runat="server" GroupName="Bonus5" Text="1. 新增现金奖（适用于项目报备未提及有现金奖，后来补充的情况）" /><br />
                        <table id="tbDetail2" class='sample tc' width='98%'>
                            <%=SbHtml2.ToString()%>
                                <tr id="trFlag2">
                                    <td></td>
                                </tr>
                            </table>
						<input type="button" id="btnAddRow1" value="添加新行" onclick="addRow2();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow1" value="删除一行" onclick="deleteRow2();" style=" float:left; display:none"/>
                        <br />
                        <asp:RadioButton ID="rdbBonus52" runat="server" GroupName="Bonus5" Text="2. 调整现金奖（适用于项目报备已说明有现金奖，后来调整的情况）" /><br />
                        <table id="tbDetail3" class='sample tc' width='98%'>
                            <%=SbHtml3.ToString()%>
                                <tr id="trFlag3">
                                    <td></td>
                                </tr>
                            </table>
						<input type="button" id="btnAddRow2" value="添加新行" onclick="addRow3();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow3();" style=" float:left; display:none"/>
                        <br />
                        六、现金奖的发放方式及操作（以下情况选一，请打勾）：<br />
                        <asp:RadioButton ID="rdbBonusSituation1" runat="server" GroupName="BonusSituation" Text="增加的奖金由发展商划入公司帐户，随薪佣发放。" /><br />
                        <asp:RadioButton ID="rdbBonusSituation2" runat="server" GroupName="BonusSituation" Text="增加的奖金由发展商直接支付现金。" /><br />
               
                        现金奖发放统筹人员姓名：<asp:textbox id="txtWholeName" runat="server" Width="80px"></asp:textbox>
                        ，职务<asp:textbox id="txtPosition" runat="server" Width="120px"></asp:textbox>
                        ，联系电话<asp:textbox id="txtPhone" runat="server"></asp:textbox><br />
                        接收现金奖银行帐号：帐户姓名：<asp:textbox id="txtAccountName" runat="server"></asp:textbox>
                        帐号：<asp:textbox id="txtNo" runat="server"></asp:textbox>（此项是奖金如存在有条件发放或有滞留发放的可能时才需填写，接收人须是区域负责人）<br />

                          <asp:RadioButton ID="rdbBonusSituation3" runat="server" GroupName="BonusSituation" Text="增加的奖金是实物。" /><br />原奖金价值：<asp:TextBox ID="txtBonusSituationValue" runat="server" Width="70px"></asp:TextBox>折现后价值：<asp:TextBox ID="txtDiscountValue" runat="server" Width="70px"></asp:TextBox>
                        ，现金奖按照<asp:TextBox ID="txtCashPrize" runat="server" Width="80px"></asp:TextBox>计算。发放方式：<asp:TextBox ID="txtCalculationMethod" runat="server" Width="70px"></asp:TextBox><br />备注：<textarea id="tatBonusSituationRemarks" runat="server" style="width:570px"></textarea><br />
                      
                          增加的现金奖是否需开具发票并由我司支付税费？
                        <asp:RadioButton ID="rdbIsTax1" runat="server" GroupName="IsTax" Text="是" />
                        <asp:RadioButton ID="rdbIsTax2" runat="server" GroupName="IsTax" Text="否" /><br />
                        七、物业部项目奖金分配方案（以佣金系统的现金奖模块计算为准）：<br />
                        现金奖总额=原有现金奖+新增/调整现金奖=<asp:textbox id="txtBonusMoney" runat="server"></asp:textbox>元/套。<br />
                        现金奖的可发放金额=每套净佣金*15%，（“净佣金比例”的定义包含发展商佣金及电商佣金），可发放金额分配比例为：营业员44%，主管15%，区经8%，副总监/总监（O/R）3%，公司30%；新增/调整现金奖链接到佣金系统里面对应项目报备的成交报告原有现金奖模块进行自动计算，超过每套净佣金的15%部分及公司30%部分全数上缴公司，可计入员工业绩，但不计算员工佣金；若项目实收佣金比例<3%，现金奖全数上缴公司，可计入员工业绩，但不计算员工佣金。
                        <br />
                        <table style="width: 97%; text-align: center; border-collapse: collapse; display: none;">
                            <tr>
                                <td rowspan="2" class="auto-style4">层级</td>
                                <td colspan="2">
                                    现金奖总额=原有现金奖+新增/调整现金奖=<asp:textbox id="txtBonusMoney2" runat="server" BackColor="#E3E3E3" ReadOnly="True"></asp:textbox>元/套。
                                </td>
                            </tr>
                            <tr>
                                <td>固定比例</td>
                                <td>金额</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">SALES</td>
                                <td>44%</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style4">主管</td>
                                <td>15%</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style4">区经</td>
                                <td>8%</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style4">副总监/总监（O/R）</td>
                                <td>3%</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style4">公司</td>
                                <td>30%</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style4">合    计</td>
                                <td>100%</td>
                                <td></td>
                            </tr>
                        </table>
                        八、其他情况补充： <br />
                        （1）	区域保证现金奖须在客户支付首期款并签订买卖合同后再发放。<br />
                        （2）	区域是否已提交发展商调整奖金确认书？
                        <asp:RadioButton ID="rdbIsConfirm1" runat="server" GroupName="IsConfirm" Text="是" />
                        <asp:RadioButton ID="rdbIsConfirm2" runat="server" GroupName="IsConfirm" Text="否" />， 区域承诺在
                        <asp:textbox id="txtSubmitDate" runat="server"></asp:textbox>
                        前交回公司（发展商奖金确认书的奖金调整方案必须与本申请内容一致，否则须重上申请）<br />
                    </td>
				</tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style1">申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">退回申请</label><br />
						<textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style1">申请部门负责人意见</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">退回申请</label><br />
						<textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>

				<tr id="trShowFlow4" class="noborder" style="height: 85px; display: none;">
					<td rowspan="2"  class="auto-style1">法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="4" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow5" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/>
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label><br />
						<textarea id="txtIDx5" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow6" class="noborder" style="height: 85px; display: none;">
					<td rowspan="2"  class="auto-style1">财务部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" />
                        <label for="rdbOtherIDx6">其他意见</label>
                        　<asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton><br />
						<textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow7" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" />
                        <label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
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
                <tr id="trLogistics1" class="noborder" style="height: 85px; display: none;">
					<td rowspan="2" >后勤事务部意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">确认</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">退回申请</label><br />
						<textarea id="txtIDx8" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
					</td>
				</tr>
                <tr id="trLogistics2" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label><input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label>
					　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx9" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
					</td>
				</tr>
<%--                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>--%>
<%--                <tr><td style="line-height: 0px" class="auto-style5"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>--%>
<%--				<tr id="trGeneralManager" class="noborder" style="height: 85px;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label><br />
						<textarea id="txtIDx11" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx11">_________</span></div>
					</td>
				</tr>
                
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><br />
						<textarea id="txtIDx131" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
					</td>
				</tr>--%>
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

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" Visible="False" />
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
            <asp:HiddenField ID="hfKey" runat="server" Value="" />
		<input type="hidden" id="hdDetail" runat="server" />
            <input type="hidden" id="hdDetail1" runat="server" />
        <input type="hidden" id="hdDetail2" runat="server" />
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
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

