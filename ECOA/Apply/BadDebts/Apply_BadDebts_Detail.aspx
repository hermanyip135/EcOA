﻿<%@ Page ValidateRequest="false" Title="坏账申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_BadDebts_Detail.aspx.cs" Inherits="Apply_BadDebts_Apply_BadDebts_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;

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

		var jJSON = <%=SbJson.ToString() %>;

        $(function() {      

            $("#<%=txtBuilding.ClientID %>").autocomplete({ 
                source: jsccesp,
                select: function(event,ui) {
                    $("#<% =hfKey1.ClientID%>").val(ui.item.id);
                    $("#<%=txtReplyPhone.ClientID %>").focus();
                }
            });
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                    var deptid = $("#<% =hdDepartmentID.ClientID%>").val();
                    if (deptid.toUpperCase() == "F89E8278-0631-40B8-8DCF-7D18D93A1965".toUpperCase()) {
                        $("#<%=lblReviceDept.ClientID%>").text("财务部");
                        $("#<%=lblCarbonCopy.ClientID%>").text("");
                    }
                    else {
                        $("#<%=lblReviceDept.ClientID%>").text("法律部");
                        $("#<%=lblCarbonCopy.ClientID%>").text("财务部");
                    }
                }
                
            });
            i = $("#tbDetail tr").length - 1;
            for (var x = 1; x < i; x++) {
                $("#txtDepartment"+ x).autocomplete({source: jJSON});
                $("#txtAutoBadDate"+ x).datepicker();
                $("#txtDealDate"+ x).datepicker();
                $("#txtBadDate"+ x).datepicker();
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

			

		    
		    //$.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
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
			
	        if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {
	            alert("回复电话不可为空！");
	            $("#<%=txtReplyPhone.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtBuilding.ClientID %>").val())=="") {
	            alert("文件主题中的楼盘单位不可为空！");
	            $("#<%=txtBuilding.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
	            alert("坏账原因不可为空！");
	            $("#<%=txtReason.ClientID %>").focus();
	            return false;
	        }

	        if(!$("#<%=rdbOneOrTwo1.ClientID%>").prop("checked") && !$("#<%=rdbOneOrTwo2.ClientID%>").prop("checked")){
	            alert("请选择是一手还是二手！");
	            $("#<%=rdbOneOrTwo1.ClientID %>").focus();
	            return false;
	        }

	        var data = "";
	        var flag = true;
	        ////rdoIsOnJob rdoIsPayComm
	        ////如果详细只有一行，且该行个人资料为空
	        //if($("#tbDetail tr").size() == 2 && $.trim($("#txtDepartment1").val()) == "" && $.trim($("#txtSales1").val()) == "" && $.trim($("#txtTeam1").val()) == "" && $.trim($("#txtBackMoney1").val()) == "")
	        //    data="||";
	        //else{
	        $("#tbDetail tr").each(function(n) {
	            if (n != 0 && n != $("#tbDetail tr").size()-1) {
	                if ($.trim($("#txtReportID" + n).val()) == "") {
	                    alert("第" + n + "行的成交报告编号必须填写。");
	                    $("#txtReportID" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtAddress" + n).val()) == "") {
	                    alert("第" + n + "行的成交地址必须填写。");
	                    $("#txtAddress" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtOwner" + n).val()) == "") {
	                    alert("第" + n + "行的应收业佣必须填写。");
	                    $("#txtOwner" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtClient" + n).val()) == "") {
	                    alert("第" + n + "行的应收客佣必须填写。");
	                    $("#txtClient" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtOwnerBadMoney" + n).val()) == "") {
	                    alert("第" + n + "行的业主坏账金额必须填写。");
	                    $("#txtOwnerBadMoney" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtClientBadMoney" + n).val()) == "") {
	                    alert("第" + n + "行的客户坏账金额必须填写。");
	                    $("#txtClientBadMoney" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtBadReason" + n).val()) == "") {
	                    alert("第" + n + "行的坏账原因必须填写。");
	                    $("#txtBadReason" + n).focus();
	                    flag = false;
	                }
	                else if (!$("#rdoIsSpecialAdjust" + n + "1").prop('checked') && !$("#rdoIsSpecialAdjust" + n + "0").prop('checked')) {
	                    alert("请选择第" + n + "行的是否特殊调整。");
	                    $("#rdoIsSpecialAdjust" + n + "1").focus();
	                    flag = false;
	                }
	                else if (!$("#rdoIsAutoBad" + n + "1").prop('checked') && !$("#rdoIsAutoBad" + n + "0").prop('checked')) {
	                    alert("请选择第" + n + "行的是否已自动坏账。");
	                    $("#rdoIsAutoBad" + n + "1").focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtAutoBadDate" + n).val()) == "") {
	                    alert("第" + n + "行的自动坏账时间必须填写。");
	                    $("#txtAutoBadDate" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtDealDate" + n).val()) == "") {
	                    alert("第" + n + "行的成交日期必须填写。");
	                    $("#txtDealDate" + n).focus();
	                    flag = false;
	                }
	                else if ($.trim($("#txtBadDate" + n).val()) == "") {
	                    alert("第" + n + "行的坏账日期必须填写。");
	                    $("#txtBadDate" + n).focus();
	                    flag = false;
	                }
	                else if($.trim($("#ddlArea" + n).find("option:selected").text()) == "请选择"){
	                    alert("请选择第" + n + "行的所属区域"); 
	                    $("#ddlArea" + n).focus();
	                    flag = false;
	                }
	                else
	                    data += $.trim($("#txtReportID" + n).val()) 
                            + "&&" + $.trim($("#txtAddress" + n).val()) 
                            + "&&" + $.trim($("#txtOwner" + n).val()) 
                            + "&&" + $.trim($("#txtClient" + n).val()) 
                            + "&&" + $.trim($("#txtOwnerBadMoney" + n).val()) 
                            + "&&" + $.trim($("#txtClientBadMoney" + n).val()) 
                            + "&&" + $.trim($("#txtBadReason" + n).val()) 
                            + "&&" + ($("#rdoIsSpecialAdjust" + n + "1").prop('checked')?"1":"0")
                            + "&&" + ($("#rdoIsAutoBad" + n + "1").prop('checked')?"1":"0")
                            + "&&" + $.trim($("#txtAutoBadDate" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_pNo" + n).html())
                            + "&&" + $.trim($("#txtDealDate" + n).val())
                            + "&&" + $.trim($("#txtBadDate" + n).val())
                            + "&&" + $.trim($("#ddlArea" + n).find("option:selected").text())
                            + "||";
	            }
	        });
	        //}
			  
	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdDetail.ClientID %>").val(data);
	            if(data!="")
	            {
	                if ($.trim($("#<%=txtMoneyCount.ClientID %>").val()) == "")  {
	                    alert("合计坏账金额不可为空！");
	                    $("#<%=txtMoneyCount.ClientID %>").focus();
	                    return false;
	                }
	                else
	                    return true;
	            }
	            else 
	                return true;
	        }
	        else
	            return false;
	    }

        function tempsavecheck(){
            var data="";
            $("#tbDetail tr").each(function(n) {
                if (n != 0 && n != $("#tbDetail tr").size()-1) {
                        data += $.trim($("#txtReportID" + n).val()) 
                            + "&&" + $.trim($("#txtAddress" + n).val()) 
                            + "&&" + $.trim($("#txtOwner" + n).val()) 
                            + "&&" + $.trim($("#txtClient" + n).val()) 
                            + "&&" + $.trim($("#txtOwnerBadMoney" + n).val()) 
                            + "&&" + $.trim($("#txtClientBadMoney" + n).val()) 
                            + "&&" + $.trim($("#txtBadReason" + n).val()) 
                            + "&&" + ($("#rdoIsSpecialAdjust" + n + "1").prop('checked')?"1":"0")
                            + "&&" + ($("#rdoIsAutoBad" + n + "1").prop('checked')?"1":"0")
                            + "&&" + $.trim($("#txtAutoBadDate" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_pNo" + n).html())
                            + "&&" + $.trim($("#txtDealDate" + n).val())
                            + "&&" + $.trim($("#txtBadDate" + n).val())
                            + "&&" + $.trim($("#ddlArea" + n).find("option:selected").text())
                            + "||";
                }
            });
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
				window.location='Apply_BadDebts_Detail.aspx?MainID=<%=MainID %>';
		}
	    
	    function uploadBadDebts() {
	        var sReturnValue = window.showModalDialog("Apply_BadDebts_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
	        if (sReturnValue == "undefined") {
	            sReturnValue = window.returnValue;
	        }
	        $("#<%=hdFilePath.ClientID%>").val(sReturnValue);
	        return true;
	    }

		function editflow(){
			var win=window.showModalDialog("Apply_BadDebts_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
					if(win=='success')
						window.location="Apply_BadDebts_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(idx=='1'||idx=='2'||idx=='3'||idx=='9'){//789
	        ////if(idx!='4'&&idx!='5'&&idx!='6'&&idx!='7'&&idx!='8'){
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
			    if($("#rdbYesIDx"+idx).prop("checked")){
			        $("#<%=hdIsAgree.ClientID %>").val("1");
                    ////2014-05-08 取消手动备注，改为自动。苏秉星
			        //if(idx==4)
			        //    if(confirm("是否法律部处理?"))
			        //        signLegalDeal();
			    }
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
			var html = '<tr id="trDetail' + i + '">'
			    //+ '     <td><input type="text" id="txtReportID' + i + '" style="width:90%"/></td>'
				//+ '     <td><input type="text" id="txtAddress' + i + '" style="width:90%"/></td>'
			    //+ '     <td><input type="text" id="txtBadReason' + i + '" style="width:90%"/></td>'
				//+ '     <td><input type="text" id="txtOwnerBadMoney' + i + '" style="width:90%" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');"/></td>'
				//+ '     <td><input type="text" id="txtClientBadMoney' + i + '" style="width:90%" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');"/></td>'
                + '     <td><span id="txtDetail_pNo' + i + '">'+i+'</span></td>'
                + '     <td><textarea id="txtReportID' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
			    + '     <td><textarea id="txtAddress' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
                + '     <td><textarea id="txtOwner' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
                + '     <td><textarea id="txtClient' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
			    + '     <td><textarea id="txtOwnerBadMoney' + i + '" style="width: 90%; overflow: hidden;" rows="2" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');"></textarea></td>'
			    + '     <td><textarea id="txtClientBadMoney' + i + '" style="width: 90%; overflow: hidden;" rows="2" onkeyup="this.value=this.value.replace(/[^\\d|//.]/g,\'\');"></textarea></td>'
			    + '     <td><textarea id="txtBadReason' + i + '" style="width: 90%; overflow: hidden;" rows="2"></textarea></td>'
				+ '    <td>'
				+ '        <input type="radio" id="rdoIsSpecialAdjust' + i + '1" name="IsSpecialAdjust' + i + '" /><label for="rdoIsSpecialAdjust' + i + '1">是</label><input type="radio" id="rdoIsSpecialAdjust' + i + '0" name="IsSpecialAdjust' + i + '" /><label for="rdoIsSpecialAdjust' + i + '0">否</label>'
				+ '    </td>'
                + '    <td>'
				+ '        <input type="radio" id="rdoIsAutoBad' + i + '1" name="IsAutoBad' + i + '" /><label for="rdoIsAutoBad' + i + '1">是</label><input type="radio" id="rdoIsAutoBad' + i + '0" name="IsAutoBad' + i + '" /><label for="rdoIsAutoBad' + i + '0">否</label>'
				+ '    </td>'
                + '     <td><input type="text" id="txtAutoBadDate' + i + '" style="width:75px"/></td>'
                + '     <td><input type="text" id="txtDealDate' + i + '" style="width:75px"/></td>'
                + '     <td><input type="text" id="txtBadDate' + i + '" style="width:75px"/></td>'
                + '     <td><select id="ddlArea' + i + '" style="width:85px"><option>请选择</option><option>天河区</option><option>海珠区</option><option>白云区</option><option>越秀区</option><option>花都区</option><option>番禺区</option><option>工商铺(罗思源)</option><option>工商铺(谢伟中)</option><option>项目部</option><option>芳村南海区</option></select></td>'
				+ '</tr>';

			$("#trMoneyCount").before(html);
			$("#txtAutoBadDate"+ i).datepicker();
			$("#txtDepartment"+ i).autocomplete({source: jJSON});
			$("#txtDealDate"+ i).datepicker();
			$("#txtBadDate"+ i).datepicker();
			i++;
		}

		function deleteRow() {
			if (i > 2) {
			    i--;
			    $("#tbDetail tr:eq(" + i + ")").remove();
			} else
				alert("不可删除第一行。");
		}
			
		function signLegalDeal() {
		    $.ajax({
		        url: "/Ajax/Apply_Handler.ashx",
		        type: "post",
		        dataType: "text",
		        data: "action=signLegalDeal&id=<%=ID %>&remark=法律部处理",
                 success: function(info) {
                     if(info=='success')
                         alert('标记成功');
                     else
                         alert('标记失败');
                 }
             })
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
            width: 420px;
        }
        .auto-style2 {
            width: 15%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 1200px; margin: 0 auto;'>
        <div class="noprint">
		<%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>坏账申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:1040px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='1040px'>
				<tr>
					<td class="auto-style2">收文部门</td>
					<%--<td class="tl PL10">法律部</td>--%>
                    <td class="tl PL10"><asp:Label ID="lblReviceDept" runat="server" Text="法律部"></asp:Label></td>
					<td class="auto-style2">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server" Width="90%"></asp:textbox></td>
				</tr>
				<tr>
					<td class="auto-style2">发文部门</td>
					<td class="tl PL10"><asp:textbox id="txtDepartment" runat="server" Width="80%"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td class="auto-style2">发文人员</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td class="auto-style2">抄送部门</td>
					<%--<td class="tl PL10">财务部</td>--%>
                    <td class="tl PL10"><asp:Label ID="lblCarbonCopy" runat="server" Text="财务部"></asp:Label></td>
					<td class="auto-style2">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td class="auto-style2">文件主题（楼盘名）</td>
					<td style="text-align: left">
                        关于<asp:textbox id="txtBuilding" runat="server" Width="75%"></asp:textbox>的坏账申请<br />
                    　　<asp:RadioButton ID="rdbOneOrTwo1" runat="server" GroupName="OneOrTwo" Text="一手项目" />
                        <asp:RadioButton ID="rdbOneOrTwo2" runat="server" GroupName="OneOrTwo" Text="纯二手单位" />
					</td>
					<td class="auto-style2">回复电话</td>
					<td class="tl PL10">020-<asp:TextBox ID="txtReplyPhone" runat="server" Width="83%"></asp:TextBox></td>
				</tr>
				<tr>
					<td class="tl PL10" colspan="4">
                        <br />
						第一部分：坏账的原因详述（包括事件的始末、坏账的金额等等）<br/>
						<asp:textbox id="txtReason" runat="server" TextMode="MultiLine" Width="98%" Rows="10" style="overflow: auto;"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td class="tl PL10 PR10" colspan="4">
						第二部分：坏账明细（经审部门核查表内成交数据及实际坏账情况）<br/>
						<table id="tbDetail" class='sample tc' width='100%'>
							<thead>
								<tr>
                                    <td style="width: 30px">序号</td>
									<td style="width: 90px;">成交报告编号</td>
									<td style="width: 90px;">成交地址</td>
                                    <td style="width: 75px;">应收业佣</td>
                                    <td style="width: 75px;">应收客佣</td>
									<td style="width: 50px;">业主坏<br />账金额</td>
									<td style="width: 50px;">客户坏<br />账金额</td>
									<td style="width: 75px;">坏账原因</td>
									<td style="width: 75px;">是否特殊调整</td>
                                    <td style="width: 75px;">是否已自动坏账</td>
                                    <td style="width: 75px;">自动坏账时间</td>
                                    <td style="width: 75px;">成交日期</td>
                                    <td style="width: 75px;">坏账日期</td>
                                    <td style="width: 75px;">所属区域</td>
								</tr>
							</thead>
							<%=SbHtml.ToString()%>
							<tr id="trMoneyCount">
								<td colspan="5">业、客佣坏账金额合计：</td>
								<td colspan="2"><asp:textbox id="txtMoneyCount" runat="server" Width="90%" onkeyup="this.value=this.value.replace(/[^\d|//.]/g,'');"></asp:textbox></td>
								<td colspan="7"><asp:Label ID="lbSumBDMoney" runat="server"></asp:Label></td>                                                                           
							</tr>
						</table>
                        <div id="divUploadBadDebts" style="display:none;">若涉及坏账的宗数超过3宗，请按此格式（<a href="../../资料/坏账格式.xls">EXCEL版空白坏账明细</a>)下载，编辑后<asp:button id="btnUploadBadDebts" runat="server" text="上传" onclick="btnUploadBadDebts_Click" onclientclick="return uploadBadDebts();" style="margin-left: 5px;"/>为附件，将自动导入<input type="hidden" id="hdFilePath" runat="server" /> </div>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
                        <div style="clear:both;">
						备注：特殊调整范围：1、一手成交客户换单位，更换后单位比之前成交单位楼价低<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        2、实际购买价格低于认购书价格<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        3、重复报数成交<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        4、在签署正式合同之前退房<br />
                        表格中的业主佣金、客户佣金是指：所要坏账的业佣金额、客佣金额。
                        </div>
					</td>
				</tr>
				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style2">部门主管</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx1">_________</span></span>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style2">隶属主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx2">_________</span></span>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style2">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx3">_________</span></span>
					</td>
				</tr>
				<tr id="trShowFlow4" class="noborder" style="height: 85px;display:none;">
					<td rowspan="2" class="auto-style2" >法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx4">_________</span></span>
					</td>
				</tr>
				<tr id="trShowFlow5" class="noborder" style="height: 85px;display:none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx5">_________</span></span>
					</td>
				</tr>
				<tr id="trShowFlow6" class="noborder" style="height: 85px;">
					<td rowspan="3" class="auto-style2" >财务部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><asp:CheckBox ID="ckbAddIDx7" runat="server" Text="增加审批环节" Visible="false" /><br />
						<textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="check();sign('6');" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx6">_________</span></span>
					</td>
				</tr>
				<tr id="trShowFlow7" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx7">_________</span></span>
					</td>
				</tr>
                <tr id="trShowFlow8" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
						<textarea id="txtIDx8" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx8">_________</span></span>
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
<%--                <tr id="trLogistics1" class="noborder" style="height: 85px;display: none;">
					<td rowspan="4" >后勤事务部意见<br />
    <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
    <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">确认</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">退回申请</label><br />
						<textarea id="txtIDx9" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
					</td>
				</tr>
				<tr id="trLogistics2" class="noborder" style="height: 85px;display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
					  　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx10" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
					</td>
				</tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>--%>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style2" >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label>
                        <input id="rdbOtherIDx11" type="radio" name="agree11" /><label for="rdbOtherIDx11">其他意见</label><br />
						<textarea id="txtIDx11" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" /><span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx11">_________</span></span>
					</td>
				</tr>
                
<%--                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
					</td>
				</tr>--%>
                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style2" >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx200">_________</span></span>
					</td>
				</tr>

                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style2" >董事总经理复审</td>
					<td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#008162" />
						<textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx220">_________</span></span>
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
		<asp:button runat="server" id="btnSignBad" text="标注已坏账" onclick="btnSignBad_Click" visible="false" />
		<asp:button runat="server" id="btnSignSave" text="标注已留档" onclick="btnSignSave_Click" visible="false" />
		<input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
		<asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
		<asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
		<asp:hiddenfield id="hdIsAgree" runat="server" />
            <asp:hiddenfield id="hdBDM" runat="server" />
		<asp:hiddenfield id="hdSuggestion" runat="server" />
		<input type="hidden" id="hdDetail" runat="server" />
            <input type="hidden" id="hdLogisticsFlow" runat="server" />
            <asp:hiddenfield id="hdCancelSign" runat="server" />
            <asp:hiddenfield id="hfKey1" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
	<%=SbJs.ToString() %>
    <script type="text/javascript">
        //$.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
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

