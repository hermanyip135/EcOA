<%@ Page ValidateRequest="false" Title="分行续约申请报告 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_BranchContract_Detail.aspx.cs" Inherits="Apply_BranchContract_Apply_BranchContract_Detail" %>

<%@ Register src="../../Common/FlowShow.ascx" tagname="FlowShow" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1, i2 = 1;
		var jJSON = <%=SbJson.ToString() %>;

        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }

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
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});
		    $("#<%=txtBranch.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {
		            $("#<% =txtBranch.ClientID%>").val(ui.item.id);
		        }
            });

		    i = $("#tbDetail tr").length - 4;
		    i2 = $("#tbDetail2 tr").length - 3;
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}

		    $("#<%=txtContractEndDate.ClientID%>").datepicker();
		    $("#<%=txtRecentlyBeginData.ClientID%>").datepicker();
		    $("#<%=txtRecentlyEndData.ClientID%>").datepicker();
		    $("#<%=txtThisYearAsOfData.ClientID%>").datepicker();
		    $("#<%=txtThisYearAsOfEndData.ClientID%>").datepicker();
		    $("#<%=txtAmortizationBeginData.ClientID%>").datepicker();
		    $("#<%=txtAmortizationEndData.ClientID%>").datepicker();
		    $("#<%=txtStatisticalBeginData.ClientID%>").datepicker();
		    $("#<%=txtStatisticalEndData.ClientID%>").datepicker();

		    for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		        $("#ros1").attr("rowspan", i);
		        $("#ros2").attr("rowspan", i);
		        $("#txtBeginData" + x).datepicker();
		        $("#txtEndData" + x).datepicker();
		    }
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

	    function check() {
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
			
	        if($.trim($("#<%=txtTelephone.ClientID %>").val())=="") {
	            alert("分行电话不可为空！");
	            $("#<%=txtTelephone.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtName.ClientID %>").val())=="") {
	            alert("文件主题不可为空！");
	            $("#<%=txtName.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtApplyPhone.ClientID %>").val())=="") {
	            alert("跟进人联系手机不可为空！");
	            $("#<%=txtApplyPhone.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBranch.ClientID %>").val())=="") {
	            alert("分行名不可为空！");
	            $("#<%=txtBranch.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtContractEndDate.ClientID %>").val())=="") {
	            alert("租约到期日不可为空！");
	            $("#<%=txtContractEndDate.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtLastMonthRent.ClientID %>").val())=="") {
	            alert("最后一个月含税租金不可为空！");
	            $("#<%=txtLastMonthRent.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtFirstYearRent.ClientID %>").val())=="") {
	            alert("续租首年含税月租金不可为空！");
	            $("#<%=txtFirstYearRent.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtRentAmplitude.ClientID %>").val())=="") {
	            alert("租金增加或减少幅度不可为空！");
	            $("#<%=txtRentAmplitude.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtContractPeriod.ClientID %>").val())=="") {
	            alert("计划续约期限不可为空！");
	            $("#<%=txtContractPeriod.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBranchSuqare.ClientID %>").val())=="") {
	            alert("分行面积不可为空！");
	            $("#<%=txtBranchSuqare.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBranchAddress.ClientID %>").val())=="") {
	            alert("分行地址不可为空！");
	            $("#<%=txtBranchAddress.ClientID %>").focus();
	            return false;
            }

	        if($.trim($("#<%=txtStampDuty.ClientID %>").val())=="") {
	            alert("租赁登记印花税不可为空！");
	            $("#<%=txtStampDuty.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtLeaseDeposit.ClientID %>").val())=="") {
	            alert("租赁按金不可为空！");
	            $("#<%=txtLeaseDeposit.ClientID %>").focus();
	            return false;
	        }



	        if($.trim($("#<%=txtResponsibleName.ClientID %>").val())=="") {
	            alert("责任人姓名不可为空！");
	            $("#<%=txtResponsibleName.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtResponsibleCall.ClientID %>").val())=="") {
	            alert("责任人电话不可为空！");
	            $("#<%=txtResponsibleCall.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtRecentlyBeginData.ClientID %>").val())=="") {
	            alert("最近12个月的起始日期不可为空！");
	            $("#<%=txtRecentlyBeginData.ClientID %>").focus();
	            return false;
	        }
            
	        if($.trim($("#<%=txtRecentlyEndData.ClientID %>").val())=="") {
	            alert("最近12个月的结束日期不可为空！");
	            $("#<%=txtRecentlyEndData.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtCumulativePerformance.ClientID %>").val())=="") {
                alert("累计业绩不可为空！");
	            $("#<%=txtCumulativePerformance.ClientID %>").focus();
	            return false;
            }
            
	        if($.trim($("#<%=txtCumulativeProfits.ClientID %>").val())=="") {
	            alert("累计利润不可为空！");
	            $("#<%=txtCumulativeProfits.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtLastYear.ClientID %>").val())=="") {
                alert("上一年度时间不可为空！");
	            $("#<%=txtLastYear.ClientID %>").focus();
	            return false;
            }
            
	        if($.trim($("#<%=txtLastYearResults.ClientID %>").val())=="") {
	            alert("上一年度累计业绩不可为空！");
	            $("#<%=txtLastYearResults.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtLastYearProfit.ClientID %>").val())=="") {
                alert("上一年度累计盈利不可为空！");
	            $("#<%=txtLastYearProfit.ClientID %>").focus();
	            return false;
            }
            
	        if($.trim($("#<%=txtThisYearAsOfData.ClientID %>").val())=="") {
	            alert("分行本年度申请开始日期不可为空！");
	            $("#<%=txtThisYearAsOfData.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtThisYearAsOfEndData.ClientID %>").val())=="") {
                alert("分行本年度申请截至日期不可为空！");
	            $("#<%=txtThisYearAsOfEndData.ClientID %>").focus();
	            return false;
            }
            
	        if($.trim($("#<%=txtThisYearCP.ClientID %>").val())=="") {
	            alert("分行本年度累计业绩不可为空！");
	            $("#<%=txtThisYearCP.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtThisYearPS2.ClientID %>").val())=="") {
                alert("分行本年度累计利润不可为空！");
	            $("#<%=txtThisYearPS2.ClientID %>").focus();
	            return false;
            }
                        
	        if($.trim($("#<%=txtAmortizationBeginData.ClientID %>").val())=="") {
	            alert("分行摊销余额截至日期不可为空！");
	            $("#<%=txtAmortizationBeginData.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtAmortizationMoney.ClientID %>").val())=="") {
                alert("分行摊销金额不可为空！");
	            $("#<%=txtAmortizationMoney.ClientID %>").focus();
	            return false;
            }
            
            if($.trim($("#<%=txtAmortizationEndData.ClientID %>").val())=="") {
                alert("分行摊销余额结束日期不可为空！");
	            $("#<%=txtAmortizationEndData.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtStatisticalBeginData.ClientID %>").val())=="") {
                alert("主打盘占率统计起始日不可为空！");
	            $("#<%=txtStatisticalBeginData.ClientID %>").focus();
	            return false;
            }
                        
	        if($.trim($("#<%=txtStatisticalEndData.ClientID %>").val())=="") {
	            alert("主打盘占率统计结束日不可为空！");
	            $("#<%=txtStatisticalEndData.ClientID %>").focus();
	            return false;
	        }

	        if (!$("#<%=rdbRentDP1.ClientID %>").prop("checked") && !$("#<%=rdbRentDP2.ClientID %>").prop("checked")) {
	            alert("请选择租金发票提供方");
	            $("#<%=rdbRentDP1.ClientID%>").focus();
	            return false;
	        }

	        if (!$("#<%=rdbManagementDP1.ClientID %>").prop("checked") && !$("#<%=rdbManagementDP2.ClientID %>").prop("checked")) {
	            alert("请选择管理费发票提供方");
	            $("#<%=rdbManagementDP1.ClientID%>").focus();
	            return false;
	        }

	        if($.trim($("#<%=this.kcdesiption.ClientID%>").val()) != "")
	        {
	            var check = false;
	            $("input[name='rdPS']").each(function(){
	                if(this.checked)
	                {
	                    check = true;
	                    return;
	                }
	            });
	            if(!check)
	            {
	                alert("请选择是否实行PS制度");
	                $("input[name='rdPS']").focus();
	                return false;
	            }

	            check = false;
	            $("input[name='rdAward']").each(function(){
	                if(this.checked)
	                {
	                        check = true;
	                        return;
	                }
	            });
	            if(!check)
	            {
	                alert("请选择是否参与123奖励计划");
	                $("input[name='rdAward']").focus();
	                return false;
	            }

	            if($.trim($("#<%=this.txtLose.ClientID%>").val())=="")
	            {
	                alert("请填写承担公司损失");
	                $("#<%=this.txtLose.ClientID%>").focus();
	                return false;
                }
                if($.trim($("#<%=this.txtLoseCharge.ClientID%>").val())=="")
                {
                    alert("请填写承担公司损失");
                    $("#<%=this.txtLoseCharge.ClientID%>").focus();
                    return false;
                }
            }

            if ($("#<%=rdbManagementDP2.ClientID%>").prop("checked")) {
                if ($.trim($("#<%=txtManagementDPAnother.ClientID%>").val()) == "") { alert("由于您选了管理费发票提供方为“其它”，所以必须写上提供方名称！"); $("#<%=txtManagementDPAnother.ClientID%>").focus(); return false; }
	        }

	        var data = "", data2 = "";
	        var flag = true,flag2 = true;
	        $("#tbDetail tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail tr").size() - 3) {
	                if ($.trim($("#txtBeginData" + n).val()) == "") {
	                    alert("第" + n + "行的租期起租日必须填写。");
	                    $("#txtBeginData" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtEndData" + n).val()) == "") {
	                    alert("第" + n + "行的租期截止日必须填写。");
	                    $("#txtEndData" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtTaxRent" + n).val()) == "") {
	                    alert("第" + n + "行的不含税租金必须填写。");
	                    $("#txtTaxRent" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtRent" + n).val()) == "") {
	                    alert("第" + n + "行的含税租金必须填写。");
	                    $("#txtRent" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data += $.trim($("#txtBeginData" + n).val()) + "&&" + $.trim($("#txtEndData" + n).val()) + "&&" + $.trim($("#txtTaxRent" + n).val()) + "&&" + $.trim($("#txtRent" + n).val()) + "||";
	            }
	        });

	        $("#tbDetail2 tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail2 tr").size() - 2) {
	                if ($.trim($("#txtBname" + n).val()) == "") {
	                    alert("第" + n + "行的楼盘名必须填写。");
	                    $("#txtBname" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtSum" + n).val()) == "") {
	                    alert("第" + n + "行的合计必须填写。");
	                    $("#txtSum" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtGzspsNum" + n).val()) == "") {
	                    alert("第" + n + "行的中原宗数必须填写。");
	                    $("#txtGzspsNum" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtGzspsRate" + n).val()) == "") {
	                    alert("第" + n + "行的中原市占率必须填写。");
	                    $("#txtGzspsRate" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtEveryNum" + n).val()) == "") {
	                    alert("第" + n + "行的满堂红宗数必须填写。");
	                    $("#txtEveryNum" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtEveryRate" + n).val()) == "") {
	                    alert("第" + n + "行的满堂红市占率必须填写。");
	                    $("#txtEveryRate" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtRichNum" + n).val()) == "") {
	                    alert("第" + n + "行的合富宗数必须填写。");
	                    $("#txtRichNum" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtRichRate" + n).val()) == "") {
	                    alert("第" + n + "行的合富市占率必须填写。");
	                    $("#txtRichRate" + n).focus();
	                    flag = false;
	                    return;
	                }

	                else if ($.trim($("#txtQFangNum" + n).val()) == "") {
	                    alert("第" + n + "行的搜房交易宗数必须填写。");
	                    $("#txtQFangNum" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtQFangrRate" + n).val()) == "") {
	                    alert("第" + n + "行的搜房交易市占率必须填写。");
	                    $("#txtQFangrRate" + n).focus();
	                    flag = false;
	                    return;
	                }

	                else if ($.trim($("#txtYuFengNum" + n).val()) == "") {
	                    alert("第" + n + "行的裕丰宗数必须填写。");
	                    $("#txtYuFengNum" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtYuFengRate" + n).val()) == "") {
	                    alert("第" + n + "行的裕丰市占率必须填写。");
	                    $("#txtYuFengRate" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtFreeNum" + n).val()) == "") {
	                    alert("第" + n + "行的自行交易宗数必须填写。");
	                    $("#txtFreeNum" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtFreeRate" + n).val()) == "") {
	                    alert("第" + n + "行的自行交易市占率必须填写。");
	                    $("#txtFreeRate" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtOtherNum" + n).val()) == "") {
	                    alert("第" + n + "行的其它交易宗数必须填写。");
	                    $("#txtOtherNum" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtOtherRate" + n).val()) == "") {
	                    alert("第" + n + "行的其它交易市占率必须填写。");
	                    $("#txtOtherRate" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data2 += $.trim($("#txtBname" + n).val()) 
                            + "&&" + $.trim($("#txtSum" + n).val()) 
                            + "&&" + $.trim($("#txtGzspsNum" + n).val()) 
                            + "&&" + $.trim($("#txtGzspsRate" + n).val()) 
                            + "&&" + $.trim($("#txtEveryNum" + n).val()) 
                            + "&&" + $.trim($("#txtEveryRate" + n).val()) 
                            + "&&" + $.trim($("#txtRichNum" + n).val()) 
                            + "&&" + $.trim($("#txtRichRate" + n).val()) 
                            + "&&" + $.trim($("#txtYuFengNum" + n).val()) 
                            + "&&" + $.trim($("#txtYuFengRate" + n).val()) 
                            + "&&" + $.trim($("#txtFreeNum" + n).val()) 
                            + "&&" + $.trim($("#txtFreeRate" + n).val()) 
                            + "&&" + $.trim($("#txtOtherNum" + n).val()) 
                            + "&&" + $.trim($("#txtOtherRate" + n).val()) 
                            + "&&" + $.trim($("#txtQFangNum" + n).val()) 
                            + "&&" + $.trim($("#txtQFangrRate" + n).val()) 
                            + "||";
	            }
	        });

	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdDetail.ClientID %>").val(data);
            }
            else
	            return false;

	        if (flag2) {
	            data2 = data2.substr(0, data2.length - 2);
	            $("#<%=hdDetail2.ClientID %>").val(data2);
            }
            else
                return false;
			  

	    }
        //暂时保存
        function tempsavecheck()
        {
            var data = "", data2 = "";
            $("#tbDetail tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail tr").size() - 3) {
                    data += $.trim($("#txtBeginData" + n).val()) + "&&" + $.trim($("#txtEndData" + n).val()) + "&&" + $.trim($("#txtTaxRent" + n).val()) + "&&" + $.trim($("#txtRent" + n).val()) + "||";
                }
            });

            $("#tbDetail2 tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail2 tr").size() - 2) {
                    data2 += $.trim($("#txtBname" + n).val()) 
                            + "&&" + $.trim($("#txtSum" + n).val()) 
                            + "&&" + $.trim($("#txtGzspsNum" + n).val()) 
                            + "&&" + $.trim($("#txtGzspsRate" + n).val()) 
                            + "&&" + $.trim($("#txtEveryNum" + n).val()) 
                            + "&&" + $.trim($("#txtEveryRate" + n).val()) 
                            + "&&" + $.trim($("#txtRichNum" + n).val()) 
                            + "&&" + $.trim($("#txtRichRate" + n).val()) 
                            + "&&" + $.trim($("#txtYuFengNum" + n).val()) 
                            + "&&" + $.trim($("#txtYuFengRate" + n).val()) 
                            + "&&" + $.trim($("#txtFreeNum" + n).val()) 
                            + "&&" + $.trim($("#txtFreeRate" + n).val()) 
                            + "&&" + $.trim($("#txtOtherNum" + n).val()) 
                            + "&&" + $.trim($("#txtOtherRate" + n).val()) 
                            + "&&" + $.trim($("#txtQFangNum" + n).val()) 
                            + "&&" + $.trim($("#txtQFangrRate" + n).val()) 
                            + "||";
                }
            });

            if (data!="") {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
            }
            if (data2!="") {
                data2 = data2.substr(0, data2.length - 2);
                $("#<%=hdDetail2.ClientID %>").val(data2);
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
				window.location='Apply_BranchContract_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
			var win=window.showModalDialog("Apply_BranchContract_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_BranchContract_Detail.aspx?MainID=<%=MainID %>";
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
	        //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='9'){//789
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
				+ '         <td><input type="text" id="txtBeginData' + i + '" style="width:100px"/></td>'
                + '         <td><input type="text" id="txtEndData' + i + '" style="width:100px"/></td>'
                + '         <td><input type="text" id="txtTaxRent' + i + '" style="width:100px"/></td>'
                + '         <td><input type="text" id="txtRent' + i + '" style="width:100px"/></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
		    $("#trFlag").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
		    $("#ros1").attr("rowspan", i);
		    $("#ros2").attr("rowspan", i);
		    $("#txtBeginData"+ i).datepicker();
		    $("#txtEndData"+ i).datepicker();
		}

		function addRow2() {
		    i2++;
		    var html = '<tr id="trDetail2' + i2 + '">'
				+ '         <td><input type="text" id="txtBname' + i2 + '" style="width:100px"/></td>'
                + '         <td><input type="text" id="txtSum' + i2 + '" style="width:50px" class="RowSum"/></td>'
                + '         <td><input type="text" id="txtGzspsNum' + i2 + '" style="width:40px" class="GzspsNum" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtGzspsRate' + i2 + '" style="width:40px" class="GzspsRate" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtEveryNum' + i2 + '" style="width:40px" class="EveryNum" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtEveryRate' + i2 + '" style="width:40px" class="EveryRate" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtRichNum' + i2 + '" style="width:40px" class="RichNum" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtRichRate' + i2 + '" style="width:40px" class="RichRate" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtQFangNum' + i2 + '" style="width:40px" class="QFangNum" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtQFangrRate' + i2 + '" style="width:40px" class="QFangRate" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtYuFengNum' + i2 + '" style="width:40px" class="YuFengNum" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtYuFengRate' + i2 + '" style="width:40px" class="YuFengRate" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtFreeNum' + i2 + '" style="width:40px" class="FreeNum" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtFreeRate' + i2 + '" style="width:40px" class="FreeRate" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtOtherNum' + i2 + '" style="width:40px" class="OtherNum" onblur="Sum(this)"/></td>'
                + '         <td><input type="text" id="txtOtherRate' + i2 + '" style="width:40px" class="OtherRate" onblur="Sum(this)"/></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i2 + '"><table><tr><td>这是'+ i2 +'个</td></tr></table></tr>'
		    $("#trFlag2").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i2 +"个</td></tr>");
		}

		function deleteRow() {
		    if (i > 1) {
			    i --;
			    $("#tbDetail tr:eq(" + (i + 2) + ")").remove();
			} else
		        alert("不可删除第一行。");
		    $("#ros1").attr("rowspan", i);
		    $("#ros2").attr("rowspan", i);
		}

		function deleteRow2() {
		    if (i2 > 1) {
		        i2--;
		        $("#tbDetail2 tr:eq(" + (i2 + 2) + ")").remove();
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
        .auto-style2 {
            width: 320px;
        }
        .auto-style3 {
            width: 130px;
        }
        .formtb h4{margin:0;padding:0;font-size:12px}
        .formtbbody{padding-left:24px}
        .formtbbody p{padding:0;margin:0}
        .input{width:80px;border-bottom:1px solid #022241}
        [id*="btnAddRow"]{background: rgba(0, 0, 0, 0) url("../../Images/bsm_add1_33.png") repeat-x scroll 0 0;}
        [id*="btnDeleteRow"]{background: rgba(0, 0, 0, 0) url("../../Images/bsm_add1_33.png") repeat-x scroll 0 0;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 950px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <uc1:FlowShow ID="FlowShow1" runat="server" ShowEditBtn="false" />
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>分行续约申请报告</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:950px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='950px'>
				<tr>
					<td class="auto-style1">收文部门</td>
					<td  class="tl PL10">外联部</td>
					<td class="auto-style3">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td class="auto-style1">发文部门</td>
					<td class="tl PL10"><asp:textbox id="txtDepartment" runat="server" Width="200px"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
                    <td class="auto-style3">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td class="auto-style1">抄送部门</td>
					<td class="auto-style2" style="text-align: left; padding-left: 10px;">财务部</td>
                    <td class="auto-style3">分行电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox></td>
                    
				</tr>
				<tr>
					<td class="auto-style1" rowspan="2">文件主题</td>
					<td class="auto-style2" rowspan="2" class="auto-style2">关于<asp:textbox id="txtName" runat="server" Width="175px"></asp:textbox>分行续租的费用申请</td>
                    <td class="auto-style3">申请跟进人</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
				</tr>
                <tr>
                    <td class="auto-style3">跟进人联系手机</td>
					<td class="tl PL10"><asp:textbox id="txtApplyPhone" runat="server"></asp:textbox></td>
                </tr>
				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 30px">
                        <span style="font-weight: bolder">分行情况：</span><br />
                        <table style="border-collapse:collapse" align="center">
                            <tr style="text-align: center"  >
                                <td >分　行</td>
                                <td >租约到期日</td>
                                <td >最后一个月<br />含税租金</td>
                                <td >续租首年<br />含税月租金</td>
                                <td >租金增加或<br />减少幅度%</td>
                                <td >计划续约<br />期限（年）</td>
                                <td >分行面积</td>
                                <td >分行地址</td>
                            </tr>
                            <tr>
                                <td style="padding-right: 3px; padding-left: 3px"><asp:textbox id="txtBranch" runat="server" Width="110px"></asp:textbox></td>
                                <td style="padding-right: 3px; padding-left: 3px"><asp:textbox id="txtContractEndDate" runat="server" Width="75px"></asp:textbox></td>
                                <td style="padding-right: 3px; padding-left: 3px"><asp:textbox id="txtLastMonthRent" runat="server" Width="60px"></asp:textbox></td>
                                <td style="padding-right: 3px; padding-left: 3px"><asp:textbox id="txtFirstYearRent" runat="server" Width="60px"></asp:textbox></td>
                                <td style="padding-right: 3px; padding-left: 3px"><asp:textbox id="txtRentAmplitude" runat="server" Width="50px"></asp:textbox></td>
                                <td style="padding-right: 3px; padding-left: 3px"><asp:textbox id="txtContractPeriod" runat="server" Width="75px"></asp:textbox></td>
                                <td style="padding-right: 3px; padding-left: 3px"><asp:textbox id="txtBranchSuqare" runat="server" Width="50px"></asp:textbox></td>
                                <td style="padding-right: 3px; padding-left: 3px"><asp:textbox id="txtBranchAddress" runat="server" Width="150px"></asp:textbox></td>
                            </tr>
                        </table>

						<span style="font-weight: bolder">1、续租的租赁期及租金</span><br />
						<table id="tbDetail" width='85%' class='sample tc' align="center">
                            <thead>
                                <tr>
                                    <td colspan="2">租　　期</td>
                                    <td rowspan="2">不含税租金(元/月)</td>
                                    <td rowspan="2">含税租金（元/月）</td>
                                    <td rowspan="2">租赁登记印花税</td>
                                    <td rowspan="2">租金发票提供方</td>
                                </tr>
                                <tr>
                                    <td>起租日</td>
                                    <td>截止日</td>
                                </tr>
                            </thead>
                            <tr>
                                <td>
                                    <input type="text" id="txtBeginData1" style="width:100px"/>
                                </td>
                                <td>
                                    <input type="text" id="txtEndData1" style="width:100px"/>
                                </td>
                                <td>
                                    <input type="text" id="txtTaxRent1" style="width:100px"/>
                                </td>
                                <td>
                                    <input type="text" id="txtRent1" style="width:100px"/>
                                </td>
                                <td id="ros1">
                                    <asp:textbox id="txtStampDuty" runat="server" Font-Bold="False" Width="100px"></asp:textbox>
                                </td>
                                <td id="ros2" style="text-align:left;padding-left:5px;">
                                    <asp:RadioButton ID="rdbRentDP1" runat="server" Text="甲方" GroupName="1" />
                                    <asp:RadioButton ID="rdbRentDP2" runat="server" Text="乙方" GroupName="1" /><br />
                                </td>
                            </tr>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag">
                                <td colspan="5" rowspan="2"  style="text-align:left;padding-left:5px;">
                                    备注：1、在分行续租合同上必须填写含税租金。<br />
                                    　　　2、计算方法：业主和租客各交总租金乘以千分之一。如印花税由我们公司全包，<br />
                                    　　　　　请将业主部分金额计入首月的实收租金中，以便开具租金发票对冲。
                                </td>
                                <td>管理费发票提供方</td>
                            </tr>
                            <tr>
                                <td style="text-align:left;padding-left:5px;">
                                    <asp:RadioButton ID="rdbManagementDP1" runat="server" Text="管理处" GroupName="2" /><br />
                                    <asp:RadioButton ID="rdbManagementDP2" runat="server" Text="其　它" GroupName="2" /><br />
                                    <asp:textbox id="txtManagementDPAnother" runat="server" Font-Bold="False" Width="100px"></asp:textbox>
                                </td>
                            </tr>
						</table>
						<input type="button" id="btnAddRow" class="btnaddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none; margin-left: 50px;"/>
						<input type="button" id="btnDeleteRow" class="btnaddRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
                        <br />

                        <span style="font-weight: bolder">
                            2、需增加（或减少）租赁按金：￥<asp:textbox id="txtLeaseDeposit" runat="server" Font-Bold="False"></asp:textbox>元。
                        </span><br />
                        <span style="font-weight: bolder">
                            3、需增加的其他费用<asp:textbox id="txtOtherFees" runat="server" Font-Bold="False"></asp:textbox>(如有，并具体说明)
                        <br />
                            <asp:textbox id="txtOtherSummy" runat="server" Font-Bold="False" Height="70px" TextMode="MultiLine" Width="98%"></asp:textbox>
                        </span><br />
                        <span style="font-weight: bolder">
                            4、本次续约的分行主要跟进责任人：（必须是分行营业经理级别以上人员，姓名和联络电话）<br />
                        　　姓名：<asp:textbox id="txtResponsibleName" runat="server" Font-Bold="False"></asp:textbox>电话：<asp:textbox id="txtResponsibleCall" runat="server" Font-Bold="False"></asp:textbox>
                        </span><br />
                        <span style="font-weight: bolder">
                            5、分行最近12个月，即<asp:textbox id="txtRecentlyBeginData" runat="server" Font-Bold="False" Width="100px"></asp:textbox>至<asp:textbox id="txtRecentlyEndData" runat="server" Font-Bold="False" Width="100px"></asp:textbox>
                        　累计业绩￥<asp:textbox id="txtCumulativePerformance" runat="server" Font-Bold="False"></asp:textbox>元，累计利润￥<asp:textbox id="txtCumulativeProfits" runat="server" Font-Bold="False"></asp:textbox>元。
                        </span><br />
                        <span style="font-weight: bolder">
                           6、上一年度，即<asp:textbox id="txtLastYear" runat="server" Font-Bold="False"></asp:textbox>年，财务管理帐的累计业绩￥<asp:textbox id="txtLastYearResults" runat="server" Font-Bold="False"></asp:textbox>元，累计盈利￥<asp:textbox id="txtLastYearProfit" runat="server" Font-Bold="False"></asp:textbox>元。
                        </span><br />
                        <span style="font-weight: bolder">
                           7、分行本年度截至申请日（即<asp:textbox id="txtThisYearAsOfData" runat="server" Font-Bold="False" Width="100px"></asp:textbox>至<asp:textbox id="txtThisYearAsOfEndData" runat="server" Font-Bold="False" Width="100px"></asp:textbox>）财务管理帐的累计业绩￥<asp:textbox id="txtThisYearCP" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元，及累计利润￥<asp:textbox id="txtThisYearPS2" runat="server" Font-Bold="False" Width="100px"></asp:textbox>元。
                        </span><br />
                        <span style="font-weight: bolder">
                           8、分行的装修费摊销余额截至<asp:textbox id="txtAmortizationBeginData" runat="server" Font-Bold="False"></asp:textbox>￥<asp:textbox id="txtAmortizationMoney" runat="server" Font-Bold="False"></asp:textbox>元，摊销期至<asp:textbox id="txtAmortizationEndData" runat="server" Font-Bold="False"></asp:textbox>止。
                        </span>（由区域填）<br />
                        <span style="font-weight: bolder">
                            9、分行主打盘近一年度市占率统计情况：
                        </span><br />
                        <div style="font-weight: bolder; text-align: center;">
                            <asp:textbox id="txtStatisticalBeginData" runat="server" Font-Bold="False"></asp:textbox>至<asp:textbox id="txtStatisticalEndData" runat="server" Font-Bold="False"></asp:textbox>主打盘市占率统计表</div>

                            <table id="tbDetail2" class='sample tc' width='98%' align="center">
                                <thead>
                                    <tr>
                                        <td rowspan="2">楼盘名</td>
                                        <td rowspan="2">合计</td>
                                        <td colspan="2">中原</td>
                                        <td colspan="2">链家</td>
                                        <td colspan="2">合富</td>
                                        <td colspan="2">搜房</td>
                                        <td colspan="2">裕丰</td>
                                        <td colspan="2">自行交易</td>
                                        <td colspan="2">其他</td>
                                    </tr>
                                    <tr>
                                        <td>宗数</td>
                                        <td>市占率</td>
                                        <td>宗数</td>
                                        <td>市占率</td>
                                        <td>宗数</td>
                                        <td>市占率</td>
                                        <td>宗数</td>
                                        <td>市占率</td>
                                        <td>宗数</td>
                                        <td>市占率</td>
                                        <td>宗数</td>
                                        <td>市占率</td>
                                        <td>宗数</td>
                                        <td>市占率</td>
                                    </tr>
                                </thead>
                                <%=SbHtml2.ToString()%>
                                    <tr id="trFlag2">
                                        <td style="font-weight: bold">
                                            总计
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumCount" runat="server" Width="50px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumGzspsNum" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumGzspsRate" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumEveryNum" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumEveryRate" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumRichNum" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumRichRate" runat="server" Width="40px"></asp:textbox>
                                        </td>

                                        <td>
                                            <asp:textbox id="txtSumQFangNum" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumQFangRate" runat="server" Width="40px"></asp:textbox>
                                        </td>

                                        <td>
                                            <asp:textbox id="txtSumYuFengNum" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumYuFengRate" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumFreeNum" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumFreeRate" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumOtherNum" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtSumOtherRate" runat="server" Width="40px"></asp:textbox>
                                        </td>
                                    </tr>
                                </table>
						    <input type="button" class="btnaddRow" id="btnAddRow2" value="添加新行" onclick="addRow2();" style=" float:left; display:none"/>
						    <input type="button" class="btnaddRow" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style=" float:left; display:none"/>
                            <br />
                        <span style="font-weight: bolder">
                            10、分行所属片区（<asp:textbox id="txtAreaPart" runat="server"></asp:textbox>片区）的楼盘架工作完成情况：<br />
                            楼盘数：<asp:textbox id="txtAreaSumOfBuild" runat="server"></asp:textbox>　
                            完成数量：<asp:textbox id="txtAreaCNo" runat="server"></asp:textbox>　
                            完成率：<asp:textbox id="txtAreaCRate" runat="server"></asp:textbox>
                        </span><br />
                        <span style="font-weight: bolder">
                            11、分行所属区经对三级市场系统的有效使用率：（指标待定）<br />
                            <asp:textbox id="txtReason" runat="server" Font-Bold="False" Height="130px" TextMode="MultiLine" Width="98%"></asp:textbox>
                        </span>
                        <div class="formtb">
                            <h4>12、如因分行近一年度管理帐累计利润出现亏损，请在下框内说明：申请续租的理由及承诺达到的目标，确保在多久期限内扭亏为盈和分行主打盘市占赢行家，<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;怎样保证网签量提升？需要写清楚不能履行承诺时怎样处罚。<span style="color:red">（*若在承诺期限内分行主打盘市占赢行家，则可豁免以上处罚。）</span></h4>
                            <div id="ksdiv" class="formtbbody">
                                
                                <p><asp:TextBox ID="kcdesiption" runat="server" TextMode="MultiLine" style="display:block;width:98%;height:134px"></asp:TextBox></p>
                                <p>区域负责人是否实行PS制度：<input id="psyes" name="rdPS" type="radio" value="1" disabled="disabled" /><label for="psyes">是</label>&nbsp;&nbsp;&nbsp;&nbsp;<input id="psno" name="rdPS" type="radio" value="0" disabled="disabled" /><label for="psno">否</label></p>
                                <p>区域负责人是否参与123奖励计划：<input id="awardyes" name="rdAward" type="radio" value="1" disabled="disabled" /><label for="awardyes">是</label>&nbsp;&nbsp;&nbsp;&nbsp;<input id="awardno" name="rdAward" type="radio" value="0" disabled="disabled" /><label for="awardno">否</label></p>
                                <p>若造成公司损失，区域负责人愿意承担公司损失的<asp:TextBox ID="txtLose" runat="server" disabled="disabled" CssClass="input" onkeyup="value=value.replace(/[^\d]/g,'')" ></asp:TextBox>%，即约为<asp:TextBox ID="txtLoseCharge" runat="server" disabled="disabled" CssClass="input" onkeyup="value=value.replace(/[^\d]/g,'')" ></asp:TextBox>元。</p>
                            </div>
                        </div>
                        <div style="font-weight: bolder; text-align: left;margin-top:20px;overflow:hidden">
                            　　因此续租申请为提前申请，具体的租金费用会控制在费用申请的幅度以内。申请妥否？请公司批复！
                        </div>
                        <span>
                            附件：<br />
                            　　1、旧《租赁合同》和《补充协议》。<br />
                            　　2、新《租赁合同》和《补充协议》。（草拟版）<br />
                            　　3、分行产权文件：房产证（或《商品房买卖合同》、《规划验收合格证》、购房发票、门牌呈批表），《临商证明》，查册，<br />
                            　　　　银行出具的《同意出租证明》等）。<br />
                            　　4、业主身份证明文件（身份证）<br />
                            　　5、属地证明（即营业执照使用的名称没有在产权证明的地址上，必须提交属地证明，如XX花园分公司，<br />
                            　　　　属地证明可以在管理处或者街道办理）。
                        </span>

                        <div style="font-weight: bolder; text-align: right; padding-right: 15px;">
                            全卷完。
                        </div>

                    </td>
				</tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style1">申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">退回申请</label><br />
						<textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style1">申请部门负责人意见</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">退回申请</label><br />
						<textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>--%>
					</td>
				</tr>


                <tr id="trShowFlow3" class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style1">外联部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx3" type="radio" name="agree3" />
                        <label for="rdbYesIDx3">同意</label>
                        <input id="rdbNoIDx3" type="radio" name="agree3" disabled="disabled" />
                        <label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" />
                        <%--<div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>--%>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trShowFlow4" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4"/>
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" disabled="disabled" />
                        <label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>--%>
					</td>
				</tr>

				<tr id="trShowFlow5" class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style1">法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" disabled="disabled" />
                        <label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" />
                        <label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trShowFlow6" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6"/>
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" />
                        <label for="rdbOtherIDx6">其他意见</label><br />
						<textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trShowFlow7" class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style1">财务部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" />
                        <label for="rdbOtherIDx7">其他意见</label>
                        　<asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton><br />
						<textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <%--<div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>--%>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trShowFlow8" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" />
                        <label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" />
                        <label for="rdbNoIDx8">不同意</label>
                        <input id="rdbOtherIDx8" type="radio" name="agree8" />
                        <label for="rdbOtherIDx8">其他意见</label><br />
						<textarea id="txtIDx8" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <%--<div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>--%>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
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
                <%--<tr id="trLogistics1" class="noborder" style="height: 85px;">
					<td rowspan="4" >后勤事务部意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">确认</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">退回申请</label><br />
						<textarea id="txtIDx9" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
                        </span>--%>
                        <%--<div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>--%>
					<%--</td>
				</tr>--%>

                <tr>
                     <td rowspan="4" >后勤事务部意见<br />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
                </tr>
                <tr id="trLogistics2" class="noborder" style="height: 85px;">
                   

					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label>
					　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx10" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx10">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>--%>
					</td>
				</tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx130">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>--%>
					</td>
				</tr>
                <tr><td style="line-height: 0px"></td><td colspan="2" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="2" id="trtpdf" style="line-height: 0px"></td></tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label>
                        <input id="rdbOtherIDx11" type="radio" name="agree11" /><label for="rdbOtherIDx11">其他意见</label><br />
						<textarea id="txtIDx11" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx11">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx11">_________</span></div>--%>
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
                        <%--<div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>--%>
					</td>
				</tr>
                                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3" >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx200">_________</span>
                        </span>
                        <%--<div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx200">_________</span></div>--%>
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
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx220">_________</span>
                        </span>
                        <%--<div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx220">_________</span></div>--%>
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

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" Visible="False" />
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
    <script type="text/javascript">
        //20160323 SYSREQ201603221550595155701 新增
        $("#<%=this.kcdesiption.ClientID%>").blur(function(){
            NO12Init(this);
        });
        function NO12Init(obj)
        {
            if($.trim($(obj).val()) == "")
            {
                //alert("无野");
                $("#ksdiv input[type='radio']").each(function(){
                    this.checked= false;
                    $(this).attr("disabled","disabled");
                });
                $("#ksdiv input[type=text]").each(function(){
                    $(this).attr("disabled","disabled").val("");
                });
            }
            else if($.trim($(obj).val()) != "")
            {
                //alert("有野");
                $("#ksdiv input").each(function(){
                    $(this).removeAttr("disabled");
                });
            }
        }
        NO12Init($("#<%=this.kcdesiption.ClientID%>"));

        //20160503 SYSREQ201604221652234542437 需求
        //市占率数据自动统计
        function Sum(obj)
        {
            var hsum = 0;
            var GzspsSum = 0,EverySum=0,RichSum=0,QFangSum=0,YuFengSum=0,FreeSum=0,OtherSum=0;
            $("#tbDetail2 tr").each(function(){
                //中原
                var GzspsNum = $(this).find(".GzspsNum").val();
                GzspsNum = $.trim(GzspsNum) == "" ? "0" : GzspsNum;
                GzspsSum += parseInt(GzspsNum);
                //链家
                var EveryNum = $(this).find(".EveryNum").val();
                EveryNum = $.trim(EveryNum) == "" ? "0" : EveryNum;
                EverySum += parseInt(EveryNum);
                //合富
                var RichNum = $(this).find(".RichNum").val();
                RichNum = $.trim(RichNum) == "" ? "0" : RichNum;
                RichSum += parseInt(RichNum);
                //搜房
                var QFangNum = $(this).find(".QFangNum").val();
                QFangNum = $.trim(QFangNum) == "" ? "0" : QFangNum;
                QFangSum += parseInt(QFangNum);
                //裕丰
                var YuFengNum = $(this).find(".YuFengNum").val();
                YuFengNum = $.trim(YuFengNum) == "" ? "0" : YuFengNum;
                YuFengSum += parseInt(YuFengNum);
                //自行交易
                var FreeNum = $(this).find(".FreeNum").val();
                FreeNum = $.trim(FreeNum) == "" ? "0" : FreeNum;
                FreeSum += parseInt(FreeNum);
                //其他
                var OtherNum = $(this).find(".OtherNum").val();
                OtherNum = $.trim(OtherNum) == "" ? "0" :OtherNum;
                OtherSum += parseInt(OtherNum);

                //行合计
                var rowSum = parseInt(GzspsNum) + parseInt(EveryNum) + parseInt(RichNum) + parseInt(QFangNum) + parseInt(YuFengNum) + parseInt(FreeNum) + parseInt(OtherNum);
                $(this).find(".RowSum").val(rowSum);

                //行比率
                //中原
                var r = Rate(GzspsNum,rowSum).toFixed(0);
                $(this).find(".GzspsRate").val(r + "%");
                //链家
                r = Rate(EveryNum,rowSum).toFixed(0);
                $(this).find(".EveryRate").val(r + "%");
                //合富
                r = Rate(RichNum,rowSum).toFixed(0);
                $(this).find(".RichRate").val(r + "%");
                //搜房
                r = Rate(QFangNum,rowSum).toFixed(0);
                $(this).find(".QFangRate").val(r + "%");
                //裕丰
                r = Rate(YuFengNum,rowSum).toFixed(0);
                $(this).find(".YuFengRate").val(r + "%");
                //自行交易
                r = Rate(FreeNum,rowSum).toFixed(0);
                $(this).find(".FreeRate").val(r + "%");
                //其他
                r = Rate(OtherNum,rowSum).toFixed(0);
                $(this).find(".OtherRate").val(r + "%");
            });

            //合计
            var total = GzspsSum + EverySum + RichSum + QFangSum + YuFengSum + FreeSum + OtherSum;
            $("#<%=this.txtSumCount.ClientID%>").val(total);
            //中原
            var coRate = Rate(GzspsSum,total).toFixed(0);
            $("#<%=this.txtSumGzspsNum.ClientID%>").val(GzspsSum);
            $("#<%=this.txtSumGzspsRate.ClientID%>").val(coRate + "%");
            //链家
            coRate = Rate(EverySum,total).toFixed(0);
            $("#<%=this.txtSumEveryNum.ClientID%>").val(EverySum);
            $("#<%=this.txtSumEveryRate.ClientID%>").val(coRate + "%");
            //合富
            coRate = Rate(RichSum,total).toFixed(0);
            $("#<%=this.txtSumRichNum.ClientID%>").val(RichSum);
            $("#<%=this.txtSumRichRate.ClientID%>").val(coRate + "%");
            //搜房
            coRate = Rate(QFangSum,total).toFixed(0);
            $("#<%=this.txtSumQFangNum.ClientID%>").val(QFangSum);
            $("#<%=this.txtSumQFangRate.ClientID%>").val(coRate + "%");
            //裕丰
            coRate = Rate(YuFengSum,total).toFixed(0);
            $("#<%=this.txtSumYuFengNum.ClientID%>").val(YuFengSum);
            $("#<%=this.txtSumYuFengRate.ClientID%>").val(coRate + "%");
            //自行交易
            coRate = Rate(FreeSum,total).toFixed(0);
            $("#<%=this.txtSumFreeNum.ClientID%>").val(FreeSum);
            $("#<%=this.txtSumFreeRate.ClientID%>").val(coRate + "%");
            //其他
            coRate = Rate(OtherSum,total).toFixed(0);
            $("#<%=this.txtSumOtherNum.ClientID%>").val(OtherSum);
            $("#<%=this.txtSumOtherRate.ClientID%>").val(coRate + "%");
        }
        function Rate(i,sum)
        {
            try
            {
                var a = parseFloat(i);
                var b = parseFloat(sum);
                if(b == 0)
                {
                    return 0;
                }
                return a / b * 100;
            }
            catch(e)
            {
                return 0;
            }
        }
    </script>
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
</asp:Content>

