<%@ Page ValidateRequest="false" Title="特殊个案申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_SpecialCase_Detail.aspx.cs" Inherits="Apply_SpecialCase_Apply_SpecialCase_Detail" %>

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
        var isNewApply=('<%=IsNewApply%>'=='True');

        var flowsl = '<%=flowsl %>';

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

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
		    $("#<%=txtJieFeeDate.ClientID%>").datepicker();
		    $("#<%=txtBorrowDate.ClientID%>").datepicker();
		    $("#<%=txtReturnDate.ClientID%>").datepicker();
		 
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});
       

        function check() {
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

	        //if($.trim($("#<%=txtBranchNo.ClientID %>").val())=="") {
	        //    alert("运作中心/业务分部号不可为空！");
	        //    $("#<%=txtBranchNo.ClientID %>").focus();
	       //     return false;
	        //}

	        if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
	            alert("联系电话不可为空！");
	            $("#<%=txtPhone.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=ddlFollowDepartment.ClientID %>").val())=="请选择") {
	            alert("请选择汇瀚跟进部门！");
	            $("#<%=ddlFollowDepartment.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=ddlFollowSomebody.ClientID %>").val())=="") {
	            alert("请选择汇瀚跟进人！");
	            $("#<%=ddlFollowSomebody.ClientID %>").focus();
	            return false;
	        }

            if($.trim($("#<%=txtLocation.ClientID %>").val())=="") {
                alert("物业地址不可为空！");
	            $("#<%=txtLocation.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtMaster.ClientID %>").val())=="") {
                alert("业主不可为空！");
                $("#<%=txtMaster.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtBuyer.ClientID %>").val())=="") {
                alert("买家不可为空！");
                $("#<%=txtBuyer.ClientID %>").focus();
                return false;
            }

            if($("#<%=rdbPayWay2.ClientID %>").prop("checked")){
                if($("#<%=rdbQuickPut1.ClientID %>").prop("checked")) {
                    if($.trim($("#<%=txtGuaranteeCompany.ClientID %>").val())=="") {
                        alert("担保公司不可为空！");
                        $("#<%=txtGuaranteeCompany.ClientID %>").focus();
                        return false;
                    }
                }

                //if(!$("#<%=rdbQuickPut1.ClientID %>").prop("checked") && !$("#<%=rdbQuickPut2.ClientID %>").prop("checked")) {
                //    alert("请选择是否快放！");
                //    $("#<%=rdbQuickPut1.ClientID %>").focus();
                //    return false;
                //}

                if($.trim($("#<%=txtLoan.ClientID %>").val())=="") {
                    alert("贷款银行不可为空！");
                    $("#<%=txtLoan.ClientID %>").focus();
                    return false;
                }
            }

            if(!$("#<%=rdbPayWay1.ClientID %>").prop("checked") && !$("#<%=rdbPayWay2.ClientID %>").prop("checked") && !$("#<%=rdbPayWay3.ClientID %>").prop("checked")) {
                alert("请选择付款方式！");
                $("#<%=rdbPayWay1.ClientID %>").focus();
                return false;
            }


            if (
                !$("#<%=cbApplyNo1.ClientID %>").prop("checked") 
                && !$("#<%=cbApplyNo2.ClientID %>").prop("checked") 
                && !$("#<%=cbApplyNo3.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo4.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo5.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo6.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo7.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo8.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo9.ClientID %>").prop("checked")
              
                && !$("#<%=cbApplyNo11.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo12.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo13.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo14.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo15.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo16.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo17.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo18.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo19.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo20.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo21.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo22.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo23.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo24.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo25.ClientID %>").prop("checked")
                && !$("#<%=cbApplyNo26.ClientID %>").prop("checked")
               
               ) 
            {
                alert("请选择申请事项");
	            $("#<%=cbApplyNo1.ClientID%>").focus();
	            return false;
            }

            if($("#<%=cbApplyNo1.ClientID %>").prop("checked"))
            {
                if(!$("#<%=cbTimeoutApply1.ClientID %>").prop("checked") 
                    && !$("#<%=cbTimeoutApply2.ClientID %>").prop("checked") 
                    && !$("#<%=cbTimeoutApply3.ClientID %>").prop("checked")
                  ) {
                    alert("请选择超时申请办理方式！");
                    $("#<%=cbTimeoutApply1.ClientID %>").focus();
                    return false;
                }
                //if($.trim($("#<%=ddlForPeople.ClientID %>").val())=="请选择") {
                //    alert("请选择资料领取人！");
                //    $("#<%=ddlForPeople.ClientID %>").focus();
                //    return false;
               // }
            }

            if($("#<%=cbApplyNo6.ClientID %>").prop("checked") || $.trim($("#<%=ddlForPeople.ClientID %>").val())=="汇瀚同事" || $.trim($("#<%=ddlForPeople.ClientID %>").val())=="分行同事")
            {
                if($.trim($("#<%=txtBorrowDate.ClientID %>").val())=="") {//*-
                    alert("取原件时间不能为空！");
                    $("#<%=txtBorrowDate.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtBorrowS.ClientID %>").val())=="") {
                    alert("领取人不能为空！");
                    $("#<%=txtBorrowS.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtReturnDate.ClientID %>").val())=="") {
                    alert("归还时间不能为空！");
                    $("#<%=txtReturnDate.ClientID %>").focus();
                    return false;
                }
            }

            //if($("#<%=cbApplyNo2.ClientID %>").prop("checked"))
            //{
            //    if($.trim($("#<%=txtAutoHandle.ClientID %>").val())=="") {
            //        alert("自行办理业务不能为空！");
            //        $("#<%=txtAutoHandle.ClientID %>").focus();
            //        return false;
            //    }
            //    if(!$("#<%=cbCaseRemark1.ClientID %>").prop("checked") 
            //        && !$("#<%=cbCaseRemark2.ClientID %>").prop("checked") 
            //        && !$("#<%=cbCaseRemark3.ClientID %>").prop("checked")
            //        && !$("#<%=cbCaseRemark4.ClientID %>").prop("checked")
            //      ) {
            //        alert("请选择该案的标记！");
            //        $("#<%=cbCaseRemark1.ClientID %>").focus();
            //        return false;
            //    }
            //}

            if($("#<%=cbApplyNo3.ClientID %>").prop("checked"))
            {
                //if(!$("#<%=cbHousingTransactions1.ClientID %>").prop("checked") 
                //    && !$("#<%=cbHousingTransactions2.ClientID %>").prop("checked") 
                //  ) {
                //    alert("请选择房管交易的相关事宜！");
                //    $("#<%=cbHousingTransactions1.ClientID %>").focus();
                //    return false;
                //}
                if($.trim($("#<%=txtDealWithProgress.ClientID %>").val())=="") {
                    alert("案件最后办理进度不能为空！");
                    $("#<%=txtDealWithProgress.ClientID %>").focus();
                    return false;
                }
            }

            if($("#<%=cbApplyNo4.ClientID %>").prop("checked"))
            {
                if(!$("#<%=cbMidway1.ClientID %>").prop("checked") 
                    && !$("#<%=cbMidway2.ClientID %>").prop("checked") 
                    && !$("#<%=cbMidway3.ClientID %>").prop("checked")
                  ) {
                    alert("请选择中途办理的方式！");
                    $("#<%=cbMidway1.ClientID %>").focus();
                    return false;
                }
                if(!$("#<%=cbPutUp1.ClientID %>").prop("checked") 
                    && !$("#<%=cbPutUp2.ClientID %>").prop("checked") 
                    && !$("#<%=cbPutUp3.ClientID %>").prop("checked")
                    && !$("#<%=cbPutUp4.ClientID %>").prop("checked")
                  ) {
                    alert("请选择办理的提放业务！");
                    $("#<%=cbPutUp1.ClientID %>").focus();
                    return false;
                }
                if($("#<%=cbPutUp4.ClientID %>").prop("checked")) {
                    if($.trim($("#<%=txtAnotherPutUp.ClientID %>").val())=="") {
                        alert("其它提放业务不能为空！");
                        $("#<%=txtAnotherPutUp.ClientID %>").focus();
                        return false;
                    }
                }
                if($.trim($("#<%=txt4PointGuaranteeCompany.ClientID %>").val())=="") {
                    alert("第3点的担保公司不能为空！");
                    $("#<%=txt4PointGuaranteeCompany.ClientID %>").focus();
                    return false;
                }
                if(!$("#<%=rdbCompanyEarnings1.ClientID %>").prop("checked") 
                    && !$("#<%=rdbCompanyEarnings2.ClientID %>").prop("checked")
                  ) {
                    alert("请选择公司收益！");
                    $("#<%=rdbCompanyEarnings1.ClientID %>").focus();
                    return false;
                }
                if($("#<%=rdbCompanyEarnings2.ClientID %>").prop("checked")) {
                    if($.trim($("#<%=txtEarningsAmount.ClientID %>").val())=="") {
                        alert("公司收益金额不能为空！");
                        $("#<%=txtEarningsAmount.ClientID %>").focus();
                        return false;
                    }
                }
            }

            //if($("#<%=cbApplyNo5.ClientID %>").prop("checked"))
            //{
            //    if(!$("#<%=cbTheKindOfFormalities1.ClientID %>").prop("checked") 
            //        && !$("#<%=cbTheKindOfFormalities2.ClientID %>").prop("checked") 
            //      ) {
            //        alert("请选择转按办理房管交易手续类型！");
            //        $("#<%=cbTheKindOfFormalities1.ClientID %>").focus();
            //        return false;
            //    }
            //}

            if($("#<%=cbApplyNo6.ClientID %>").prop("checked"))
            {
                if(!$("#<%=cbCertificate1.ClientID %>").prop("checked") 
                    && !$("#<%=cbCertificate2.ClientID %>").prop("checked")
                    && !$("#<%=cbCertificate3.ClientID %>").prop("checked")
                    && !$("#<%=cbCertificate4.ClientID %>").prop("checked")
                    && !$("#<%=cbCertificate5.ClientID %>").prop("checked")
                  ) {
                    alert("请选择领取的证书！");
                    $("#<%=cbCertificate1.ClientID %>").focus();
                    return false;
                }
            }

            if($("#<%=cbApplyNo7.ClientID %>").prop("checked"))
            {
                if(!$("#<%=cbNotarialDeed2.ClientID %>").prop("checked"))
               {
                    alert("请选择《委托公证书》受委托人员名单！");
                    $("#<%=cbNotarialDeed2.ClientID %>").focus();
                    return false;
                }
            
               
            }

            if($("#<%=cbApplyNo8.ClientID %>").prop("checked"))
            {
                //if(!$("#<%=cbNotNeat1.ClientID %>").prop("checked") 
                //    && !$("#<%=cbNotNeat2.ClientID %>").prop("checked")
                //  ) {
                //    alert("请选择未齐费用的处理方式！");
                //    $("#<%=cbNotNeat1.ClientID %>").focus();
                //    return false;
                //}
                if($.trim($("#<%=txtJieFeeDate.ClientID %>").val())=="") {
                    alert("补齐按揭费时间不能为空！");
                    $("#<%=txtJieFeeDate.ClientID %>").focus();
                    return false;
                }
            }

            if($("#<%=cbApplyNo9.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtcredit.ClientID %>").val())=="") {
                    alert("未出同贷办理业务不能为空！");
                    $("#<%=txtcredit.ClientID %>").focus();
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
		    var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue=='success')
		            window.location='Apply_SpecialCase_Detail.aspx?MainID=<%=MainID %>';
		}

        function upload2() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
  
        }

        function editflow(){
            var win=window.showModalDialog("Apply_SpecialCase_Flow.aspx?MainID=<%=MainID %>&flowsadd="+flowsl+"","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_SpecialCase_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='6'||idx=='7'||idx=='8'||idx=='9'){ //789
	            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
	        }
	        else{
	            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
	        }
			
			if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
				alert("由于您不同意该申请，必须填写不同意的原因。");
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
		            data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+0,
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
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
        .auto-style2 {
            width: 85px;
        }
        .auto-style3 {
            width: 100px;
        }
        .PDL {
            padding-left:50px;
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
			<h1>特殊个案申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:660px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='660px'>
                <tr>
                    <td class="tl PL10" colspan="2">
                        致：运作中心<asp:TextBox ID="txtBranchNo" runat="server" Width="136px" Visible="False">0</asp:TextBox>
                    </td>
                    <td>汇瀚内部编号</asp:Label></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApplyID" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">申请部门<asp:Label ID="Lb4" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="200px"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
					<td class="auto-style2">申请人<asp:Label ID="Lb10" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
					<td class="tl PL10"><asp:textbox id="txtApply" runat="server" Width="200px"></asp:textbox></td>
				</tr>
				<tr>
                    <td class="auto-style3">汇瀚跟进部门<asp:Label ID="Lb12" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
					<td class="tl PL10">
                        <asp:DropDownList ID="ddlFollowDepartment" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlFollowDepartment_SelectedIndexChanged">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>业务一部</asp:ListItem>
                            <asp:ListItem>业务二部</asp:ListItem>
                            <asp:ListItem>业务三部</asp:ListItem>
                            <asp:ListItem>业务四部</asp:ListItem>
                            <asp:ListItem>业务五部</asp:ListItem>
                            <asp:ListItem>业务六部</asp:ListItem>
                            <asp:ListItem>番禺业务部</asp:ListItem>
                        </asp:DropDownList>
					</td>
                    <td>汇瀚跟进人<asp:Label ID="Lb11" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
					<td class="tl PL10">
                        <asp:DropDownList ID="ddlFollowSomebody" runat="server" Width="200px">
                            <asp:ListItem>请先选择汇瀚跟进部门</asp:ListItem>
                        </asp:DropDownList>
					</td>
				</tr>
				<tr>
                    <td class="auto-style3">物业地址<asp:Label ID="Lb13" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                    <td  class="tl PL10"><asp:textbox id="txtLocation" runat="server" Width="200px"></asp:textbox></td>
                    <td class="auto-style3">物业区域</td>
                    <td class="PL10">
                        <asp:TextBox runat="server" Width="200px"></asp:TextBox>
                    </td>
				</tr>
				<tr>
                    <td class="auto-style3">业主<asp:Label ID="Lb14" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtMaster" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>买家<asp:Label ID="Lb15" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtBuyer" runat="server" Width="200px"></asp:TextBox>
                    </td>
				</tr>
                <tr>
                                        <td class="auto-style3">付款方式<asp:Label ID="Lb8" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbPayWay1" runat="server" Text="一次性" GroupName="PayWay" AutoPostBack="True" OnCheckedChanged="rdbPayWay1_CheckedChanged" />
                        <asp:RadioButton ID="rdbPayWay2" runat="server" Text="按揭" GroupName="PayWay" AutoPostBack="True" OnCheckedChanged="rdbPayWay1_CheckedChanged" />
                        <asp:RadioButton ID="rdbPayWay3" runat="server" Text="代办" GroupName="PayWay" AutoPostBack="True" OnCheckedChanged="rdbPayWay1_CheckedChanged" />
                    </td>

                    <td>是否快放<asp:Label ID="Lb2" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label></td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbQuickPut1" runat="server" GroupName="QuickPut" Text="是" />
                        <asp:RadioButton ID="rdbQuickPut2" runat="server" GroupName="QuickPut" Text="否" />
                    </td>
                </tr>
                <tr>
                                        <td class="auto-style3">贷款银行<asp:Label ID="Lb1" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtLoan" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>担保公司<asp:Label ID="Lb3" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtGuaranteeCompany" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">发文日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label>
                    </td>
                    <td>联系电话<asp:Label ID="Lb16" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding: 10px; text-align: left; line-height: 25px;">
                        ※申请事项：<br />
                        <asp:CheckBox ID="cbApplyNo1" runat="server" Text="（1）超时申请办理" />
                        <asp:CheckBox ID="cbTimeoutApply1" runat="server" Text="递件" />
                        <asp:CheckBox ID="cbTimeoutApply2" runat="server" Text="交税" />
                        <asp:CheckBox ID="cbTimeoutApply3" runat="server" Text="入押" />
                        （房管）业务；资料领取人：
                        <asp:DropDownList ID="ddlForPeople" runat="server" Width="100px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>分行同事</asp:ListItem>
                            <asp:ListItem>汇瀚同事</asp:ListItem>
                        </asp:DropDownList><br />

                        <div id="DelCb1" style="display: none">
                            <asp:CheckBox ID="cbApplyNo2" runat="server" Text="（2）自行办理" />
                            <asp:TextBox ID="txtAutoHandle" runat="server" Width="195px"></asp:TextBox>
                            （房管）业务，须客服办理后续房管业务<br />
                　  　　    （请查核并标记：该案
                            <asp:CheckBox ID="cbCaseRemark1" runat="server" Text="已收齐按揭费" />
                            <asp:CheckBox ID="cbCaseRemark2" runat="server" Text="已交案" />
                            <asp:CheckBox ID="cbCaseRemark3" runat="server" Text="已出同贷" />
                            <asp:CheckBox ID="cbCaseRemark4" runat="server" Text="未出同贷" />）<br />
                        </div>

                        <asp:CheckBox ID="cbApplyNo3" runat="server" Text="（2）房管交易" />
                        （<asp:CheckBox ID="cbHousingTransactions1" runat="server" Text="中途退案" Visible="False" />
                        <asp:CheckBox ID="cbHousingTransactions2" runat="server" Text="暂停办理" Checked="True" Visible="False" />暂停办理）
                        手续：案件最后办理进度
                        <asp:TextBox ID="txtDealWithProgress" runat="server" Width="200px"></asp:TextBox><br />

                        <asp:CheckBox ID="cbApplyNo4" runat="server" Text="（3）中途" />
                        （<asp:CheckBox ID="cbMidway1" runat="server" Text="申请" />
                        <asp:CheckBox ID="cbMidway2" runat="server" Text="取消" />
                        <asp:CheckBox ID="cbMidway3" runat="server" Text="更改" />）
                        办理提放业务：
                        <asp:CheckBox ID="cbPutUp1" runat="server" Text="税单" />
                        <asp:CheckBox ID="cbPutUp2" runat="server" Text="新证" />
                        <asp:CheckBox ID="cbPutUp3" runat="server" Text="入押" />
                        <asp:CheckBox ID="cbPutUp4" runat="server" Text="其他" />
                        <asp:TextBox ID="txtAnotherPutUp" runat="server" Width="100px"></asp:TextBox><br />
                　　　　担保公司：<asp:TextBox ID="txt4PointGuaranteeCompany" runat="server" Width="200px"></asp:TextBox>，
                        公司收益：<asp:RadioButton ID="rdbCompanyEarnings1" runat="server" Text="无" GroupName="CompanyEarnings" />
                        <asp:RadioButton ID="rdbCompanyEarnings2" runat="server" Text="有" GroupName="CompanyEarnings" />,
                        人民币￥<asp:TextBox ID="txtEarningsAmount" runat="server" Width="85px"></asp:TextBox><br />

                        <div id="DelCb2" style="display: none">
                            <asp:CheckBox ID="cbApplyNo5" runat="server" Text="（5）转按办理房管交易手续类型" />
                            （<asp:CheckBox ID="cbTheKindOfFormalities1" runat="server" Text="“涂销+递件、入押”分开办理" />
                            <asp:CheckBox ID="cbTheKindOfFormalities2" runat="server" Text="“涂销+递件+入押”合并办理" />）<br />
                        </div>

                        <asp:CheckBox ID="cbApplyNo6" runat="server" Text="（4）领取：" />
                        <asp:CheckBox ID="cbCertificate1" runat="server" Text="《委托公证书》原件" />
                        <asp:CheckBox ID="cbCertificate2" runat="server" Text="《房地产权证》原件" />
                        <asp:CheckBox ID="cbCertificate3" runat="server" Text="税费发票、回执原件" /><br />
                　　　　<asp:CheckBox ID="cbCertificate4" runat="server" Text="贷款合同原件" />
                        <asp:CheckBox ID="cbCertificate5" runat="server" Text="网签合同原件" />      
                        资料领取人：
                        <asp:DropDownList ID="ddlForPeople1" runat="server" Width="100px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>分行同事</asp:ListItem>
                            <asp:ListItem>汇瀚同事</asp:ListItem>
                        </asp:DropDownList><br />
                        
                        <asp:CheckBox ID="cbApplyNo7" runat="server" Text="（5）增加《委托公证书》受委托人员名单：" />
                            <asp:CheckBox ID="cbNotarialDeed2" runat="server" Text="中原营业员" /><br />
                        <%--asp:CheckBox ID="cbApplyNo7" runat="server" Text="（5）《委托公证书》受委托人员名单" />
                        <asp:CheckBox ID="cbNotarialDeed1" runat="server" Text="增加人员" />
                        （<asp:CheckBox ID="cbNotarialDeed2" runat="server" Text="中原营业员" />
                        <asp:CheckBox ID="cbNotarialDeed3" runat="server" Text="担保公司" />
                        <asp:CheckBox ID="cbNotarialDeed4" runat="server" Text="其他" />）
                        <asp:TextBox ID="txtCommissionedPersonnel" runat="server" Width="100px"></asp:TextBox><br />
                　　　　<asp:CheckBox ID="cbNotarialDeed5" runat="server" Text="增减条款" />
                        <asp:TextBox ID="txtClause" runat="server" Width="490px"></asp:TextBox><br />--%>

                        <asp:CheckBox ID="cbApplyNo8" runat="server" Text="（6）未齐费用：" />
                        <asp:CheckBox ID="cbNotNeat1" runat="server" Text="未齐启动金送审" Visible="False" />
                        <asp:CheckBox ID="cbNotNeat2" runat="server" Text="未齐按揭费递件" Checked="True" Visible="False" />未齐按揭费递件，
                        补齐按揭费时间：<asp:TextBox ID="txtJieFeeDate" runat="server" Width="90px"></asp:TextBox><br />

                        <asp:CheckBox ID="cbApplyNo9" runat="server" Text="（7）未出同贷办理" />
                        <asp:TextBox ID="txtcredit" runat="server" Width="450px"></asp:TextBox>业务。<br />



                        
                  　   （8）
                        <div style="display: none">
                            <asp:CheckBox ID="cbApplyNo11" runat="server" Text="领取《委托书》（汇瀚员工）、《房产证》、《税单》、《货款合同》、《受理回执》<br />" />
                            <asp:CheckBox ID="cbApplyNo12" runat="server" Text="房管业务超时申请" CssClass="PDL" />
                            <asp:CheckBox ID="cbApplyNo13" runat="server" Text="中原领取递件资料递件" />
                            <asp:CheckBox ID="cbApplyNo14" runat="server" Text="委托公证受委托人增加中原分行营业员/汇瀚业务人员<br />" />
                            <asp:CheckBox ID="cbApplyNo15" runat="server" Text="中途提放/更改快贷类型申请" CssClass="PDL" />
                            <asp:CheckBox ID="cbApplyNo16" runat="server" Text="中途转快贷类型/中途转担保公司" />
                            <asp:CheckBox ID="cbApplyNo17" runat="server" Text="未通过银行审批，要求递件<br />" />
                            <asp:CheckBox ID="cbApplyNo18" runat="server" Text="未交按揭费或按揭费未交齐要求递件" CssClass="PDL" />
                            <asp:CheckBox ID="cbApplyNo21" runat="server" Text="暂停或暂缓房管交易办理业务<br />" />
                        </div>
                        <asp:CheckBox ID="cbApplyNo19" runat="server" Text="异常结算评估费" />
                        <asp:CheckBox ID="cbApplyNo20" runat="server" Text="不发送短信" />
                        <asp:CheckBox ID="cbApplyNo22" runat="server" Text="业主复印买家贷款合同"/>
                  <%--      <asp:CheckBox ID="cbApplyNo23" runat="server" Text="买家不做委托书（不含纯抵押个案）<br />" />--%>
                       <asp:CheckBox ID="cbApplyNo23" runat="server" Text="业主快放/担保案不做委托书<br />" />
                         <asp:CheckBox ID="cbApplyNo24" runat="server" Text="交案没有签齐资料需现场签署" CssClass="PDL" />
                        <asp:CheckBox ID="cbApplyNo25" runat="server" Text="街单不查册/街单不提供双方约" />
                        <asp:CheckBox ID="cbApplyNo26" runat="server" Text="交案所须资料不提交<br />" />
                        <%--<asp:CheckBox ID="cbApplyNo27" runat="server" Text="个案不符合递件要求，仍须安排递件" CssClass="PDL" />--%><br />



                       <%-- <asp:CheckBox ID="cbApplyNo10" runat="server" Text=" 其他 " />
                        <asp:TextBox ID="txtAnother" runat="server" Width="550px"></asp:TextBox><br />--%>

                        <div style="vertical-align: top; margin-top: 10px; margin-bottom: 10px;">
                            <span style="vertical-align: top">※情况说明：</span>
                            <asp:TextBox ID="txtSituation" runat="server" Width="525px" Height="120px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <span style="color: #FF0000; margin-top: 10px;">
                        ◆　　自行取网签合同原件办理房管局递件手续的，必须保证须在三天内归还有买卖双方签名的网签版《中介服务合同》及《存量房买卖合同》原件各壹份至事务部协调岗，否则愿意接受HOLD佣处理。如取走合同两个月内未归还，一律视为遗失合同，愿意接受公司作罚款人民币伍佰元及违规通告的处罚。（如领取人为分行同事，则分行相关主管须签署）
                        </span><br />

                        取原件时间
                        <asp:TextBox ID="txtBorrowDate" runat="server" Width="100px"></asp:TextBox>　
                        领取人
                        <asp:TextBox ID="txtBorrowS" runat="server" Width="185px"></asp:TextBox>　
                        归还时间
                        <asp:TextBox ID="txtReturnDate" runat="server" Width="100px"></asp:TextBox>

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
                <tr id="TSD1" style="display: none;">
                    <td colspan="4">
                        <a id="afa" href="javascript:void(0)" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" onclick="deleteFlow()">删除添加的审批环节</a><br />
                    </td>
                </tr>

				<tr id="trM1" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3">分行申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trM2" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3">分行部门主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
				<tr id="trM3" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3">所属区经</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>

				<tr id="trM4" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3">所属总监</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>
				<tr id="trM5" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style3">汇瀚申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/>
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>

			    <tr id="trM6" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style3">汇瀚业务部主管</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S1"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>

                <tr id="trM7" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style3">汇瀚业务部高经</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label><br />
						<textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
					</td>
				</tr>

                <tr id="trM8" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style3">汇瀚运作中心权证部副经理</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" />
                        <label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" />
                        <label for="rdbNoIDx8">不同意</label>
                        <span id="IsMasterE" style="display: none"><br />汇瀚运作中心权证部副经理？<asp:RadioButton ID="rdbMasterE1" runat="server" Text="是" Checked="True" GroupName="MasterE" /><asp:RadioButton ID="rdbMasterE2" runat="server" Text="否" GroupName="MasterE" /></span><br />
						<textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea>
                        <input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
					</td>
				</tr>

			    <tr id="trM9" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style3">汇瀚总监</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" />
                        <label for="rdbYesIDx9">同意</label>
                        <input id="rdbNoIDx9" type="radio" name="agree9" />
                        <label for="rdbNoIDx9">不同意</label><br />
						<textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S4"></textarea>
                        <input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
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
            <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

