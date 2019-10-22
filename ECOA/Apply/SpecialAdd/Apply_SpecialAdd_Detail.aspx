<%@ Page ValidateRequest="false" Title="特殊增编申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_SpecialAdd_Detail.aspx.cs" Inherits="Apply_SpecialAdd_Apply_SpecialAdd_Detail" %>

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
		    $("#<%=txtReceiveD.ClientID %>").autocomplete({ source: jJSON });
		    $("#<%=txtCCDpm.ClientID %>").autocomplete({ source: jJSON });
		    $("#<%=txtGroup.ClientID %>").autocomplete({ source: jJSON });
		    $("#<%=txtGPlace.ClientID %>").autocomplete({ source: jJSON });

		    i = $("#tbDetail tr").length - 4;
		    i2 = $("#tbDetail2 tr").length - 3;
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}

		    //for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		    //    $("#ros1").attr("rowspan", i);
		    //    $("#ros2").attr("rowspan", i);
		    //    $("#txtBeginData" + x).datepicker();
		    //    $("#txtEndData" + x).datepicker();
		    //}
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

        function CaculateMThree(){
            var SumCount = 0
                ,SumGzspsNum = 0
                ,SumGzspsRate = 0
                ,SumEveryNum = 0
                ,SumEveryRate = 0
                ,SumRichNum = 0
                ,SumRichRate = 0
                ,SumYuFengNum = 0
                ,SumYuFengRate = 0
                ,SumFreeNum = 0
                ,SumFreeRate = 0
                ,SumOtherNum = 0
                ,SumOtherRate = 0
                ,SumQFangNum = 0
                ,SumQFangRate = 0;
            for(var x = 1;x <= i2; x ++){
                SumCount += $("#txtSum"+ x).val()*1;

                SumGzspsNum += $("#txtGzspsNum"+ x).val()*1;
                SumGzspsRate += $("#txtGzspsRate"+ x).val()*1;
                SumEveryNum += $("#txtEveryNum"+ x).val()*1;
                SumEveryRate += $("#txtEveryRate"+ x).val()*1;
                SumRichNum += $("#txtRichNum"+ x).val()*1;
                SumRichRate += $("#txtRichRate"+ x).val()*1;
                SumYuFengNum += $("#txtYuFengNum"+ x).val()*1;
                SumYuFengRate += $("#txtYuFengRate"+ x).val()*1;
                SumFreeNum += $("#txtFreeNum"+ x).val()*1;
                SumFreeRate += $("#txtFreeRate"+ x).val()*1;
                SumOtherNum += $("#txtOtherNum"+ x).val()*1;
                SumOtherRate += $("#txtOtherRate"+ x).val()*1;
                SumQFangNum += $("#txtQFangNum"+ x).val()*1;
                SumQFangRate += $("#txtQFangrRate"+ x).val()*1;
            }
            $("#<%=txtSumCount.ClientID %>").val(SumCount);

            $("#<%=txtSumGzspsNum.ClientID %>").val(SumGzspsNum);//*-
            $("#<%=txtSumGzspsRate.ClientID %>").val((SumGzspsNum / SumCount * 100).toFixed(2));
            $("#<%=txtSumEveryNum.ClientID %>").val(SumEveryNum);
            $("#<%=txtSumEveryRate.ClientID %>").val((SumEveryNum / SumCount * 100).toFixed(2));
            $("#<%=txtSumRichNum.ClientID %>").val(SumRichNum);
            $("#<%=txtSumRichRate.ClientID %>").val((SumRichNum / SumCount * 100).toFixed(2));
            $("#<%=txtSumYuFengNum.ClientID %>").val(SumYuFengNum);
            $("#<%=txtSumYuFengRate.ClientID %>").val((SumYuFengNum / SumCount * 100).toFixed(2));
            $("#<%=txtSumFreeNum.ClientID %>").val(SumFreeNum);
            $("#<%=txtSumFreeRate.ClientID %>").val((SumFreeNum / SumCount * 100).toFixed(2));
            $("#<%=txtSumOtherNum.ClientID %>").val(SumOtherNum);
            $("#<%=txtSumOtherRate.ClientID %>").val((SumOtherNum / SumCount * 100).toFixed(2));
            $("#<%=txtSumQFangNum.ClientID %>").val(SumQFangNum);
            $("#<%=txtSumQFangRate.ClientID %>").val((SumQFangNum / SumCount * 100).toFixed(2));

            $("#<%=Hiddenfielda1.ClientID %>").val(SumCount);
            $("#<%=Hiddenfielda2.ClientID %>").val(SumGzspsNum);
            $("#<%=Hiddenfielda3.ClientID %>").val((SumGzspsNum / SumCount * 100).toFixed(2));
            $("#<%=Hiddenfielda4.ClientID %>").val(SumEveryNum);
            $("#<%=Hiddenfielda5.ClientID %>").val((SumEveryNum / SumCount * 100).toFixed(2));
            $("#<%=Hiddenfielda6.ClientID %>").val(SumRichNum);
            $("#<%=Hiddenfielda7.ClientID %>").val((SumRichNum / SumCount * 100).toFixed(2));
            $("#<%=Hiddenfielda8.ClientID %>").val(SumYuFengNum);
            $("#<%=Hiddenfielda9.ClientID %>").val((SumYuFengNum / SumCount * 100).toFixed(2));
            $("#<%=Hiddenfielda10.ClientID %>").val(SumFreeNum);
            $("#<%=Hiddenfielda11.ClientID %>").val((SumFreeNum / SumCount * 100).toFixed(2));
            $("#<%=Hiddenfielda12.ClientID %>").val(SumOtherNum);
            $("#<%=Hiddenfielda13.ClientID %>").val((SumOtherNum / SumCount * 100).toFixed(2));
            $("#<%=Hiddenfielda14.ClientID %>").val(SumQFangNum);
            $("#<%=Hiddenfielda15.ClientID %>").val((SumQFangNum / SumCount * 100).toFixed(2));
        }

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

	        if($.trim($("#<%=ddlAddOne.ClientID %>").val())=="请选择") {
	            alert("请选择增编人数！");
	            $("#<%=ddlAddOne.ClientID %>").focus();
	            return false;
            }
			
	        var data2 = "";
	        var flag2 = true;
	        
	        $("#tbDetail2 tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail2 tr").size() - 2) {
	                if ($.trim($("#txtBname" + n).val()) == "") {
	                    alert("第" + n + "行的楼盘名必须填写。");
	                    $("#txtBname" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtSum" + n).val()) == "") {
	                    alert("第" + n + "行的合计必须填写。");
	                    $("#txtSum" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtGzspsNum" + n).val()) == "") {
	                    alert("第" + n + "行的中原宗数必须填写。");
	                    $("#txtGzspsNum" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtGzspsRate" + n).val()) == "") {
	                    alert("第" + n + "行的中原市占率必须填写。");
	                    $("#txtGzspsRate" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtEveryNum" + n).val()) == "") {
	                    alert("第" + n + "行的满堂红宗数必须填写。");
	                    $("#txtEveryNum" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtEveryRate" + n).val()) == "") {
	                    alert("第" + n + "行的满堂红市占率必须填写。");
	                    $("#txtEveryRate" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtRichNum" + n).val()) == "") {
	                    alert("第" + n + "行的合富宗数必须填写。");
	                    $("#txtRichNum" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtRichRate" + n).val()) == "") {
	                    alert("第" + n + "行的合富市占率必须填写。");
	                    $("#txtRichRate" + n).focus();
	                    flag2 = false;
	                    return;
	                }

	                else if ($.trim($("#txtQFangNum" + n).val()) == "") {
	                    alert("第" + n + "行的搜房交易宗数必须填写。");
	                    $("#txtQFangNum" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtQFangrRate" + n).val()) == "") {
	                    alert("第" + n + "行的搜房交易市占率必须填写。");
	                    $("#txtQFangrRate" + n).focus();
	                    flag2 = false;
	                    return;
	                }

	                else if ($.trim($("#txtYuFengNum" + n).val()) == "") {
	                    alert("第" + n + "行的裕丰宗数必须填写。");
	                    $("#txtYuFengNum" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtYuFengRate" + n).val()) == "") {
	                    alert("第" + n + "行的裕丰市占率必须填写。");
	                    $("#txtYuFengRate" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtFreeNum" + n).val()) == "") {
	                    alert("第" + n + "行的自行交易宗数必须填写。");
	                    $("#txtFreeNum" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtFreeRate" + n).val()) == "") {
	                    alert("第" + n + "行的自行交易市占率必须填写。");
	                    $("#txtFreeRate" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtOtherNum" + n).val()) == "") {
	                    alert("第" + n + "行的其它交易宗数必须填写。");
	                    $("#txtOtherNum" + n).focus();
	                    flag2 = false;
	                    return;
	                }
	                else if ($.trim($("#txtOtherRate" + n).val()) == "") {
	                    alert("第" + n + "行的其它交易市占率必须填写。");
	                    $("#txtOtherRate" + n).focus();
	                    flag2 = false;
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

	        if (flag2) {
	            data2 = data2.substr(0, data2.length - 2);
	            $("#<%=hdDetail2.ClientID %>").val(data2);
	            return flag2;
            }
            else
                return false;
			  

	    }

        function tempsavecheck()
        {
            var data2 = "";
            var flag2 = true;
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

            if (flag2) {
                data2 = data2.substr(0, data2.length - 2);
                $("#<%=hdDetail2.ClientID %>").val(data2);
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
				window.location='Apply_SpecialAdd_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
			var win=window.showModalDialog("Apply_SpecialAdd_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_SpecialAdd_Detail.aspx?MainID=<%=MainID %>";
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
	        //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'){//789
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
				+ '         <td><input type="text" id="txtBname' + i2 + '" style="width:80px"/></td>'
                + '         <td><input type="text" id="txtSum' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree();"/></td>'
                + '         <td><input type="text" id="txtGzspsNum' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtGzspsRate' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtEveryNum' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtEveryRate' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtRichNum' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtRichRate' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtQFangNum' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtQFangrRate' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtYuFengNum' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtYuFengRate' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtFreeNum' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtFreeRate' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtOtherNum' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtOtherRate' + i2 + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
				+ '     </tr>';
		    $("#trFlag2").before(html);
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

        function ddlAddOneChange(obj)
        {
            var val = $(obj).val();
            //alert(val);
            switch(val)
            {
                case "请选择" : $("#Panel1").hide();$("#Panel2").hide();break;
                case "增编至12人" : $("#Panel1").show();$("#Panel2").hide();break;
                case "增编至15人" : $("#Panel1").hide();$("#Panel2").show();break;
                default : $("#Panel1").hide();$("#Panel2").hide();break;
            };
        }
        function ShowDetail()
        {
            var detaildata = $("#<%=this.hdDetail2.ClientID%>").val();
            if($.trim(detaildata) == "" || detaildata == "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&")
            {
                //无detail数据
                var html = '<tr id="trDetail21">'
				+ '         <td><input type="text" id="txtBname1" style="width:80px"/></td>'
                + '         <td><input type="text" id="txtSum1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree();"/></td>'
                + '         <td><input type="text" id="txtGzspsNum1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtGzspsRate1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtEveryNum1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtEveryRate1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtRichNum1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtRichRate1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtQFangNum1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtQFangrRate1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtYuFengNum1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtYuFengRate1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtFreeNum1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtFreeRate1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                + '         <td><input type="text" id="txtOtherNum1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                + '         <td><input type="text" id="txtOtherRate1" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
				+ '     </tr>';
                $("#trFlag2").before(html);
                //return;
            }
            else
            {
                //有数据
                var details = detaildata.split("||");
                var ii = 1;
                var Bname,Sum,GzspsNum,GzspsRate,EveryNum,EveryRate,RichNum,RichRate,YuFengNum,YuFengRate,FreeNum,FreeRate,OtherNum,OtherRate,QFangNum,QFangrRate
                var html = "";
                i2 = details.length;
                for(var i=0; i < details.length; i++)
                {
                    var val = details[i].split('&&');
                    Bname = val[0]; Sum = val[1]; GzspsNum = val[2];GzspsRate = val[3];EveryNum = val[4];EveryRate = val[5];RichNum = val[6];RichRate = val[7];YuFengNum = val[8];
                    YuFengRate = val[9];FreeNum=val[10];FreeRate=val[11];OtherNum=val[12];OtherRate=val[13];QFangNum=val[14];QFangrRate=val[15]

                    html += '<tr id="trDetail2' + ii + '">'
                        + '         <td><input type="text" id="txtBname' + ii + '" value="' + Bname + '" style="width:80px" /></td>'
                        + '         <td><input type="text" id="txtSum' + ii + '" value="' + Sum + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree();"/></td>'
                        + '         <td><input type="text" id="txtGzspsNum' + ii + '" value="' + GzspsNum + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                        + '         <td><input type="text" id="txtGzspsRate' + ii + '" value="' + GzspsRate + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                        + '         <td><input type="text" id="txtEveryNum' + ii + '" value="' + EveryNum + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                        + '         <td><input type="text" id="txtEveryRate' + ii + '" value="' + EveryRate + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                        + '         <td><input type="text" id="txtRichNum' + ii + '" value="' + RichNum + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                        + '         <td><input type="text" id="txtRichRate' + ii + '" value="' + RichRate + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                        + '         <td><input type="text" id="txtQFangNum' + ii + '" value="' + QFangNum + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                        + '         <td><input type="text" id="txtQFangrRate' + ii + '" value="' + QFangrRate + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                        + '         <td><input type="text" id="txtYuFengNum' + ii + '" value="' + YuFengNum + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                        + '         <td><input type="text" id="txtYuFengRate' + ii + '" value="' + YuFengRate + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                        + '         <td><input type="text" id="txtFreeNum' + ii + '" value="' + FreeNum + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                        + '         <td><input type="text" id="txtFreeRate' + ii + '" value="' + FreeRate + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                        + '         <td><input type="text" id="txtOtherNum' + ii + '" value="' + OtherNum + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/></td>'
                        + '         <td><input type="text" id="txtOtherRate' + ii + '" value="' + OtherRate + '" style="width:40px" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()"/>%</td>'
                        + '     </tr>';
                    ii++;
                    //var html = '<tr id="trDetail' + i2 + '"><table><tr><td>这是'+ i2 +'个</td></tr></table></tr>'
                
                }
                $("#trFlag2").before(html);
                CaculateMThree();
            }
        }
        function Init()
        {
            ddlAddOneChange(document.getElementById("<%=ddlAddOne.ClientID%>"));
            ShowDetail();
        }
        
	</script>
    <style type="text/css">
        .auto-style1 {
            width: 15%;
        }
        .auto-style3 {
            width: 130px;
        }
        .auto-style4 {
            width: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width:840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>特殊增编申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:840px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td class="tl PL10">收文部门</td>
					<td class="tl PL10"><asp:textbox id="txtReceiveD" runat="server" Width="200px"></asp:textbox></td>
					<td class="tl PL10">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server" Width="200px"></asp:textbox></td>
				</tr>
				<tr>
					<td class="tl PL10">发文部门</td>
					<td class="tl PL10"><asp:textbox id="txtDepartment" runat="server" Width="200px"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
                    <td class="tl PL10">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label><asp:Label ID="lblApply" runat="server" Visible="False"></asp:Label></td>
				</tr>
				<tr>
					<td class="tl PL10">抄送部门</td>
					<td class="tl PL10"><asp:textbox id="txtCCDpm" runat="server" Width="200px"></asp:textbox></td>
                    <td class="tl PL10">回复电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox></td>
                    
				</tr>
				<tr>
					<td class="tl PL10">文件主题</td>
					<td class="tl PL10"><asp:textbox id="txtSubject" runat="server" Width="92%"></asp:textbox></td>
                    <td class="tl PL10">回复传真</td>
					<td class="tl PL10"><asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 30px; text-align: center;">
                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                            <%--<ContentTemplate>--%>
                                <div class="tl PL10">
                                    增编人数
                                    <asp:DropDownList ID="ddlAddOne" runat="server" Width="200px" onchange="ddlAddOneChange(this)" >
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>增编至12人</asp:ListItem>
                                    <asp:ListItem>增编至15人</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="Panel1" class="tl PL10" style="font-size:18px;font-weight:700;display:none">根据公司现时实施的《关于物业部和工商铺部组别营业员编制管理的规定》，物业部和工商铺部各组别编制增加到12人需达到以下条件：1、连续3个月业绩均达到12万以上；2、申请增编时组别累计利润为盈利状态；3、组别营业员持证率达到60%。</div>
                                <div id="Panel2" class="tl PL10" style="font-size:18px;font-weight:700;display:none">根据公司现时实施的《关于物业部和工商铺部组别营业员编制管理的规定》，物业部和工商铺部各组别编制增加到15人需达到以下条件：1、连续3个月业绩均达到15万以上；2、申请增编时组别累计利润为盈利状态；3、组别营业员持证率达到60%。</div>
                                <%--<asp:Panel ID="Panel1" runat="server" CssClass="tl PL10" Font-Bold="True" Font-Size="Large" Visible="False">
                                　　根据公司现时实施的《关于物业部和工商铺部组别营业员编制管理的规定》，物业部和工商铺部各组别编制增加到12人需达到以下条件：1、连续3个月业绩均达到12万以上；2、申请增编时组别累计利润为盈利状态；3、组别营业员持证率达到60%。
                                </asp:Panel>--%>
                                <%--<asp:Panel ID="Panel2" runat="server" CssClass="tl PL10" Font-Bold="True" Font-Size="Large" Visible="False">
                                　　根据公司现时实施的《关于物业部和工商铺部组别营业员编制管理的规定》，物业部和工商铺部各组别编制增加到15人需达到以下条件：1、连续3个月业绩均达到15万以上；2、申请增编时组别累计利润为盈利状态；3、组别营业员持证率达到60%。
                                </asp:Panel>--%>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                        <div style="text-align: left; width: 85%; margin:0 auto;">
                        一、现<asp:TextBox ID="txtGroup" runat="server" Width="200px"></asp:TextBox>组别近5个月业绩、利润及执业证持证率情况如下：
                        </div>
                        <table id="Table1" class='sample tc' width='90%' align="center">
                            <tr>
                                <td style="width: 100px"  >年/月份</td>
                                <td><asp:TextBox ID="txtYear1" runat="server" Width="40px"></asp:TextBox>年<asp:TextBox ID="txtMonth1" runat="server" Width="40px"></asp:TextBox>月</td>
                                <td><asp:TextBox ID="txtYear2" runat="server" Width="40px"></asp:TextBox>年<asp:TextBox ID="txtMonth2" runat="server" Width="40px"></asp:TextBox>月</td>
                                <td><asp:TextBox ID="txtYear3" runat="server" Width="40px"></asp:TextBox>年<asp:TextBox ID="txtMonth3" runat="server" Width="40px"></asp:TextBox>月</td>
                                <td><asp:TextBox ID="txtYear4" runat="server" Width="40px"></asp:TextBox>年<asp:TextBox ID="txtMonth4" runat="server" Width="40px"></asp:TextBox>月</td>
                                <td><asp:TextBox ID="txtYear5" runat="server" Width="40px"></asp:TextBox>年<asp:TextBox ID="txtMonth5" runat="server" Width="40px"></asp:TextBox>月</td>
                            </tr>
                            <tr>
                                <td>业绩情况</td>
                                <td><asp:TextBox ID="txtResults1" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtResults2" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtResults3" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtResults4" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtResults5" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>利润情况</td>
                                <td><asp:TextBox ID="txtProfits1" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtProfits2" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtProfits3" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtProfits4" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtProfits5" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>累计利润</td>
                                <td><asp:TextBox ID="txtSumFear1" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumFear2" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumFear3" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumFear4" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumFear5" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>坏账净损失</td>
                                <td><asp:TextBox ID="txtBDLost1" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtBDLost2" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtBDLost3" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtBDLost4" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtBDLost5" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>二手住宅买卖成交宗数(含住宅和别墅)</td>
                                <td><asp:TextBox ID="txtSecHand1" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSecHand2" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSecHand3" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSecHand4" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSecHand5" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>组别是否二手特攻队</td>
                                <td><asp:DropDownList ID="ddlIsTG1" runat="server"><asp:ListItem>请选择</asp:ListItem><asp:ListItem>是</asp:ListItem><asp:ListItem>否</asp:ListItem></asp:DropDownList></td>
                                <td><asp:DropDownList ID="ddlIsTG2" runat="server"><asp:ListItem>请选择</asp:ListItem><asp:ListItem>是</asp:ListItem><asp:ListItem>否</asp:ListItem></asp:DropDownList></td>
                                <td><asp:DropDownList ID="ddlIsTG3" runat="server"><asp:ListItem>请选择</asp:ListItem><asp:ListItem>是</asp:ListItem><asp:ListItem>否</asp:ListItem></asp:DropDownList></td>
                                <td><asp:DropDownList ID="ddlIsTG4" runat="server"><asp:ListItem>请选择</asp:ListItem><asp:ListItem>是</asp:ListItem><asp:ListItem>否</asp:ListItem></asp:DropDownList></td>
                                <td><asp:DropDownList ID="ddlIsTG5" runat="server"><asp:ListItem>请选择</asp:ListItem><asp:ListItem>是</asp:ListItem><asp:ListItem>否</asp:ListItem></asp:DropDownList></td>
                            </tr>


                            <tr>
                                <td>组别营业员持证率</td>
                                <td colspan="5"><asp:TextBox ID="txtHoldRat" runat="server" Width="98%"></asp:TextBox></td>
                            </tr>
                        </table>
                        <div id="lbh1" style="text-align: left; width: 80%; margin:0 auto; display: none;">
                            注：以上数据由财务部每月组别利润表查询
                        </div>
                        <br />
                        <div style="text-align: left; width: 85%; margin:0 auto;">
                            二、组别所属片区（<asp:TextBox ID="txtGPlace" runat="server" Width="200px"></asp:TextBox>片区）楼盘架完成情况：<br />
                            总楼盘数：<asp:TextBox ID="txtSumBuild" runat="server" Width="150px"></asp:TextBox>　　　
                            完成数量：<asp:TextBox ID="txtCountComplete" runat="server" Width="150px"></asp:TextBox>　　　
                            完成率：<asp:TextBox ID="txtCompleteRat" runat="server" Width="150px"></asp:TextBox>
                            <div id="lbh2" style="display: none;">注：以上数据由资讯科技部楼盘框架数据提供</div>
                        </div>
                        <br />
                        <div style="text-align: left; width: 85%; margin:0 auto;">
                            三、组别近6个月（<asp:TextBox ID="txtRentYearStart" runat="server" Width="40px"></asp:TextBox>年
                            <asp:TextBox ID="txtRentMonthStart" runat="server" Width="40px"></asp:TextBox>月&nbsp;---&nbsp;
                            <asp:TextBox ID="txtRentYearEnd" runat="server" Width="40px"></asp:TextBox>年
                            <asp:TextBox ID="txtRentMonthEnd" runat="server" Width="40px"></asp:TextBox>月）主打盘市占率：
                        </div>
                        <table id="tbDetail2" class='sample tc' width='98%' align="center">
                            <thead>
                                <tr>
                                    <td rowspan="2">楼盘名</td>
                                    <td rowspan="2">合计</td>
                                    <td colspan="2">中原</td>
                                    <td colspan="2">链家满堂红</td>
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
                                    <asp:textbox id="txtSumCount" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtSumGzspsNum" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtSumGzspsRate" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>%
                                </td>
                                <td>
                                    <asp:textbox id="txtSumEveryNum" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtSumEveryRate" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>%
                                </td>
                                <td>
                                    <asp:textbox id="txtSumRichNum" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtSumRichRate" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>%
                                </td>

                                <td>
                                    <asp:textbox id="txtSumQFangNum" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtSumQFangRate" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>%
                                </td>

                                <td>
                                    <asp:textbox id="txtSumYuFengNum" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtSumYuFengRate" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>%
                                </td>
                                <td>
                                    <asp:textbox id="txtSumFreeNum" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtSumFreeRate" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>%
                                </td>
                                <td>
                                    <asp:textbox id="txtSumOtherNum" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtSumOtherRate" runat="server" Width="40px" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');" ReadOnly="True" BackColor="#E3E3E3"></asp:textbox>%
                                </td>
                            </tr>
                        </table>
						<input type="button" id="btnAddRow2" class="buttonimg" value="添加新行" onclick="addRow2();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow2" class="buttonimg" value="删除一行" onclick="deleteRow2();" style=" float:left; display:none"/>
                        <br />
                        <div style="text-align: left; width: 85%; margin:0 auto;">
                            四、组别所属分行收匙量：<asp:textbox id="txtKeyCount" runat="server" Width="100px"></asp:textbox>
                        </div>         
                        <div style="text-align: left; width: 85%; margin:0 auto;">
                            五、组别所属区经对三级市场系统的有效使用率：（指标待定）
                        </div>
                        <asp:textbox id="txtUseRat" runat="server" Width="90%" Height="50px" TextMode="MultiLine"></asp:textbox>
                        <br /><br />
                        <div style="text-align: left; width: 85%; margin:0 auto;">
                            六、请陈述进行特殊增编申请的原因、增编后如何部署及增编后组别承诺达到的目标
                        </div>
                        <asp:textbox id="txtReason" runat="server" Width="90%" Height="100px" TextMode="MultiLine"></asp:textbox>
                        <div id="lbh3" style="text-align: left; width: 90%; margin:0 auto; display: none;">注：请把组别营业员业绩情况的EXCEL数据表格上传电子申请中作为附件</div>

                    </td>
				</tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style1">申请人</td>
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
					<td class="auto-style1">申请部门主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
					</td>
				</tr>


                <tr id="trShowFlow3" class="noborder" style="height: 85px;">
					<td class="auto-style1">隶属主管</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx3" type="radio" name="agree3" />
                        <label for="rdbYesIDx3">同意</label>
                        <input id="rdbNoIDx3" type="radio" name="agree3" />
                        <label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trShowFlow4" class="noborder" style="height: 85px;">
                    <td class="auto-style1">部门负责人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4"/>
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
					</td>
				</tr>

				<tr  id="trShowFlow7" class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style1">人力资源部</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" />
                        <label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
					</td>
				</tr>
				<tr  id="trShowFlow8" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" />
                        <label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" />
                        <label for="rdbNoIDx8">不同意</label>
                        <input id="rdbOtherIDx8" type="radio" name="agree8" />
                        <label for="rdbOtherIDx8">其他意见</label><br />
						<textarea id="txtIDx8" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
					</td>
				</tr>
                	<tr id="trShowFlow12" class="noborder" style="height: 85px;">
					<td >营运支持总监</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label>
                        <input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label>
                        <input id="rdbOtherIDx12" type="radio" name="agree12" /><label for="rdbOtherIDx12">其他意见</label><br />
						<textarea id="txtIDx12" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx12">_________</span>
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
						<input id="rdbYesIDx19" type="radio" name="agree19" /><label for="rdbYesIDx19">确认</label>
                        <input id="rdbNoIDx19" type="radio" name="agree19" /><label for="rdbNoIDx19">退回申请</label><br />
						<textarea id="txtIDx19" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx19" value="签署意见" onclick="sign('19')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx19">_________</span>
                        </span>
					</td>
				</tr>--%>
                <tr id="trLogistics2" class="noborder" style="height: 85px;">
                    <td rowspan="4" >后勤事务部意见<br />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>

					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx20" type="radio" name="agree20" /><label for="rdbYesIDx20">同意</label>
                        <input id="rdbNoIDx20" type="radio" name="agree20" /><label for="rdbNoIDx20">不同意</label>
                        <input id="rdbOtherIDx20" type="radio" name="agree20" /><label for="rdbOtherIDx20">其他意见</label>
					　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx20" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx20" value="签署意见" onclick="sign('20')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx20">_________</span>
                        </span>
					</td>
				</tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label>
                        <input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label>
                        <input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2">
						</textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx130">_________</span>
                        </span>
					</td>
				</tr>
                <tr><td style="line-height: 0px" class="auto-style4"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx21" type="radio" name="agree21" /><label for="rdbYesIDx21">同意</label>
                        <input id="rdbNoIDx21" type="radio" name="agree21" /><label for="rdbNoIDx21">不同意</label>
                        <input id="rdbOtherIDx21" type="radio" name="agree21" /><label for="rdbOtherIDx21">其他意见</label><br />
						<textarea id="txtIDx21" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx21" value="签署意见" onclick="sign('21')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx21">_________</span>
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
                                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3" >申请人回复审批意见<br />（可选项）</td>
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
					<td class="auto-style3" >董事总经理复审</td>
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
        <input type="hidden" id="hdDetail2" runat="server" />
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />

        <asp:hiddenfield id="Hiddenfielda1" runat="server" />
        <asp:hiddenfield id="Hiddenfielda2" runat="server" />
        <asp:hiddenfield id="Hiddenfielda3" runat="server" />
        <asp:hiddenfield id="Hiddenfielda4" runat="server" />
        <asp:hiddenfield id="Hiddenfielda5" runat="server" />
        <asp:hiddenfield id="Hiddenfielda6" runat="server" />
        <asp:hiddenfield id="Hiddenfielda7" runat="server" />
        <asp:hiddenfield id="Hiddenfielda8" runat="server" />
        <asp:hiddenfield id="Hiddenfielda9" runat="server" />
        <asp:hiddenfield id="Hiddenfielda10" runat="server" />
        <asp:hiddenfield id="Hiddenfielda11" runat="server" />
        <asp:hiddenfield id="Hiddenfielda12" runat="server" />
        <asp:hiddenfield id="Hiddenfielda13" runat="server" />
        <asp:hiddenfield id="Hiddenfielda14" runat="server" />
        <asp:hiddenfield id="Hiddenfielda15" runat="server" />
        <asp:HiddenField ID="DetailJson" runat="server" />
            </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        Init();
    </script>
     <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/10--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
</asp:Content>

