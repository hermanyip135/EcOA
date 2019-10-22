<%@ Page ValidateRequest="false" Title="新增、维修项目报价（结算）明细表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Repair_Detail.aspx.cs" Inherits="Apply_Repair_Apply_Repair_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

		$(function() {      
			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});

		    i = $("#tbDetail tr").length - 5;
		    //for (var x = 1; x < i; x++) { //使详情表的部门可自动填充
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}

		    $("#<%=txtApplyDate.ClientID%>").datepicker();
		    $("#<%=txtCtime.ClientID%>").datepicker();

		    $("[id^=txtDetail_Price]").blur(function () {
		        if (isNaN($(this).val())) {
		            alert("第"+$.trim(this.id).replace("txtDetail_Price","")+"个单价必须输入纯数字！");
		            $(this).val('');
		            $(this).focus();
		            return false;
		        }
		        else{
		            $("#txtDetail_Money"+$.trim(this.id).replace("txtDetail_Price","")).val($("#txtDetail_Price"+$.trim(this.id).replace("txtDetail_Price","")).val() * $("#txtDetail_Num"+$.trim(this.id).replace("txtDetail_Price","")).val());
		            CaculateMThree();
		        }
		    });
		    $("[id^=txtDetail_Num]").blur(function () {
		        if (isNaN($(this).val())) {
		            alert("第"+$.trim(this.id).replace("txtDetail_Num","")+"个数量必须输入纯数字！");
		            $(this).val('');
		            $(this).focus();
		            return false;
		        }
		        else{
		            $("#txtDetail_Money"+$.trim(this.id).replace("txtDetail_Num","")).val($("#txtDetail_Price"+$.trim(this.id).replace("txtDetail_Num","")).val() * $("#txtDetail_Num"+$.trim(this.id).replace("txtDetail_Num","")).val());
		            CaculateMThree();
		        }
		    });
		    CaculateMThree();
		    $("[id^=txtDetail_Money]").blur(function () {
		        if (isNaN($(this).val())) {
		            alert("第"+$.trim(this.id).replace("txtDetail_Money","")+"个金额必须输入纯数字！");
		            $(this).val('');
		            $(this).focus();
		            return false;
		        }
		        else{
		            CaculateMThree();
                }
		    });
		    //if($("#<%=rdbCouNum1.ClientID%>").prop("checked")){
		    //    $("#<%=ddlRealBrand.ClientID%>").show();
		    //    $("#<%=txtRealBrand.ClientID%>").hide();
		    //}
		    //else{
		    //    $("#<%=ddlRealBrand.ClientID%>").hide();
		    //    $("#<%=txtRealBrand.ClientID%>").show();
		    //}
		    //$("#<%=rdbCouNum1.ClientID%>").click(function(){
		    //    $("#<%=ddlRealBrand.ClientID%>").show();
		    //    $("#<%=txtRealBrand.ClientID%>").hide();
		    //});
		    //$("#<%=rdbCouNum2.ClientID%>").click(function(){
		    //    $("#<%=ddlRealBrand.ClientID%>").hide();
		    //    $("#<%=txtRealBrand.ClientID%>").show();
            //});

		    $("#<%=txtTax.ClientID%>").blur(function () {
		        if (isNaN($("#<%=txtTax.ClientID%>").val())) {
		            alert("税率必须输入纯数字");
		            $("#<%=txtTax.ClientID%>").val('');
		            $("#<%=txtTax.ClientID%>").focus();
		            return false;
		        }
		        else{
		            CaculateMThree();
		        }
		    });

		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

        function CaculateMThree(){
            var c = 0;
            for(var x = 1;x <= i; x ++){
                c += $("#txtDetail_Money"+ x).val()*1;
            }
            $("#<%=txtSumMoney.ClientID %>").val(c);

		    t = (c * $("#<%=txtTax.ClientID %>").val() / 100).toFixed(2);
            $("#<%=txtTaxMoney.ClientID %>").val(t);
            $("#<%=txtCouMoney.ClientID %>").val(c*1 + t*1);
        }

	    function check() {
	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("流水号不可为空！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("发文分行不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtApplyDate.ClientID %>").val())=="") {
	            alert("维修日期不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtTax.ClientID %>").val())=="") {
	            alert("税率不可为空！");
	            $("#<%=txtTax.ClientID %>").focus();
	            return false;
	        }

	        //if($.trim($("#<%=txtRealMoney.ClientID %>").val())=="") {
	        //    alert("工程实际结算不可为空！");
	        //    $("#<%=txtRealMoney.ClientID %>").focus();
	        //    return false;
	        //}

	        //if ($.trim($("#<%=ddlRealBrand.ClientID%>").val()) == "") {
	        //    alert("请选择供应商！");
	        //    $("#<%=ddlRealBrand.ClientID%>").focus();
	        //    return false;
	        //}
	        if($.trim($("#<%=txtRealUnit.ClientID %>").val())=="") {
	            alert("联系人不可为空！");
	            $("#<%=txtRealUnit.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txtRealPrice.ClientID %>").val())=="") {
	            alert("联系电话不可为空！");
	            $("#<%=txtRealPrice.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txtRealNum.ClientID %>").val())=="") {
	            alert("联系邮箱不可为空！");
	            $("#<%=txtRealNum.ClientID %>").focus();
	            return false;
	        }

	        if(!$("#<%=rdbCouNum1.ClientID%>").prop("checked")&&!$("#<%=rdbCouNum2.ClientID%>").prop("checked")){
	            alert("请选择供应商！");
	            $("#<%=rdbCouNum1.ClientID %>").focus();
                return false;
	        }
	        if($("#<%=rdbCouNum1.ClientID%>").prop("checked")){
	            if ($.trim($("#<%=ddlRealBrand.ClientID%>").val()) == "") {
	                alert("请选择供应商名称！");
	                $("#<%=ddlRealBrand.ClientID%>").focus();
	                return false;
	            }
	        }
	        if($("#<%=rdbCouNum2.ClientID%>").prop("checked")){
	            if ($.trim($("#<%=txtRealBrand.ClientID%>").val()) == "") {
                    alert("请填写供应商名称！");
                    $("#<%=txtRealBrand.ClientID%>").focus();
	                return false;
                }
            }

	        var data = "";
	        var flag = true;
	        $("#tbDetail tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail tr").size()-4) {
	                //if ($.trim($("#txtDetail_No" + n).val()) == "") {
	                //    alert("第" + n + "行的条数号必须填写。");
	                //    $("#txtDetail_No" + n).focus();
	                //    flag = false;
	                //}
	                //else if ($.trim($("#txtDetail_Point" + n).val()) == "") {
	                //    alert("第" + n + "行的点数必须填写。");
	                //    $("#txtDetail_Point" + n).focus();
	                //    flag = false;
	                //}
	                //else if ($.trim($("#txtDetail_Terms" + n).val()) == "") {
	                //    alert("第" + n + "行的条款名必须填写。");
	                //    $("#txtDetail_Terms" + n).focus();
	                //    flag = false;
	                //}
	                //else
	                    data += $.trim($("#txtDetail_No" + n).html()) 
                            + "&&" + $.trim($("#txtDetail_Pname" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Brand" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Unit" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Price" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Num" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Money" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Summary" + n).val()) 
                            + "||";
	            }
	        });
	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdDetail.ClientID %>").val(data);
	            if(data!="")
                        return true;
                else 
	                return false;
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
				window.location='Apply_Repair_Detail.aspx?MainID=<%=MainID %>';
		}

        //function uploadDetailed() {
        //    var sReturnValue = window.showModalDialog("/Apply/Apply_zDetailed_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
        //    $("#<%//=hdFilePath.ClientID%>").val(sReturnValue);
        //    return true;
        //}

		function editflow(){
			var win=window.showModalDialog("Apply_Repair_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_Repair_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx!='10'&&idx!='11'&&idx!='12'){
	            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
	                alert("请确定是否同意！");
	                return;
	            }
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
				document.getElementById("<%=btnSign.ClientID %>").disabled='disabled';
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
		    var html = '<tr id="trDetail' + i + '">'
                + '         <td><span id="txtDetail_No' + i + '">'+i+'</span></td>'
                + '         <td><textarea id="txtDetail_Pname' + i + '" style="width:200px"/></textarea></td>'
                + '         <td><textarea id="txtDetail_Brand' + i + '" style="width:50px"/></textarea></td>'
                + '         <td><input type="text" id="txtDetail_Unit' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtDetail_Price' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtDetail_Num' + i + '" style="width:50px"/></td>'
                + '         <td><input type="text" id="txtDetail_Money' + i + '" style="width:70px"/></td>'
                + '         <td><textarea id="txtDetail_Summary' + i + '" style="width:90px"/></textarea></td>'
		    	+ '     </tr>';

		    //var html = '<tr id="trDetail' + i + '">'
            //        + '     <td colspan="3" style="line-height: 30px; padding-left: 10px; text-align: left;">'
            //        + '         项目序号：<span id="txtDetail_No' + i + '">'+i+'</span><br/>'
            //        + '         <div><span style="vertical-align: top">项　目：</span><textarea id="txtDetail_Pname' + i + '" style="width:505px"/></textarea></div>'
            //        + '         品　牌：<input type="text" id="txtDetail_Brand' + i + '" style="width:505px"/><br/>'
            //        + '         单　位：<input type="text" id="txtDetail_Unit' + i + '" style="width:200px"/>　　'
            //        + '         单价（元）：<input type="text" id="txtDetail_Price' + i + '" style="width:200px"/><br/>'
            //        + '         数　量：<input type="text" id="txtDetail_Num' + i + '" style="width:200px"/>　　'
            //        + '         金额（元）：<input type="text" id="txtDetail_Money' + i + '" style="width:200px"/><br/>'
            //        + '         <div style="margin-bottom: 5px;"><span style="vertical-align: top">备　注：</span><textarea id="txtDetail_Summary' + i + '" rows="6" style="width:505px"/></textarea></div>'
            //        + '     </td>'
            //        + ' </tr>';

		    //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
		    $("#trFlag").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");

		    //$("#txtDetail_Department"+ i).autocomplete({source: jJSON});
		    //$("#txtCountOffTime"+ i).datepicker();

		    $("[id^=txtDetail_Price]").blur(function () {
		        if (isNaN($(this).val())) {
		            alert("第"+$.trim(this.id).replace("txtDetail_Price","")+"个单价必须输入纯数字！");
		            $(this).val('');
		            $(this).focus();
		            return false;
		        }
		        else{
		            $("#txtDetail_Money"+$.trim(this.id).replace("txtDetail_Price","")).val($("#txtDetail_Price"+$.trim(this.id).replace("txtDetail_Price","")).val() * $("#txtDetail_Num"+$.trim(this.id).replace("txtDetail_Price","")).val());
		            CaculateMThree();
		        }
		    });
		    $("[id^=txtDetail_Num]").blur(function () {
		        if (isNaN($(this).val())) {
		            alert("第"+$.trim(this.id).replace("txtDetail_Num","")+"个数量必须输入纯数字！");
		            $(this).val('');
		            $(this).focus();
		            return false;
		        }
		        else{
		            $("#txtDetail_Money"+$.trim(this.id).replace("txtDetail_Num","")).val($("#txtDetail_Price"+$.trim(this.id).replace("txtDetail_Num","")).val() * $("#txtDetail_Num"+$.trim(this.id).replace("txtDetail_Num","")).val());
		            CaculateMThree();
		        }
		    });
		    $("[id^=txtDetail_Money]").blur(function () {
		        if (isNaN($(this).val())) {
		            alert("第"+$.trim(this.id).replace("txtDetail_Money","")+"个金额必须输入纯数字！");
		            $(this).val('');
		            $(this).focus();
		            return false;
		        }
		        else{
		            CaculateMThree();
		        }
		    });

		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); });
		}//*-

		function deleteRow() {
		    if (i > 1) {
		        $("#tbDetail tr:eq(" + i + ")").remove();
		        i--;

		        CaculateMThree();
			} else
		    	alert("不可删除第一行。");
		    //$("#tbDetail tr:eq(0)").remove();
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
            width: 20%;
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
			<h1>新增、维修项目报价（结算）明细表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td class="auto-style1">分行</td>
					<td class="tl PL10"><asp:textbox id="txtDepartment" runat="server"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
				    <td class="auto-style1">维修日期</td>
					<td class="tl PL10">
                        <asp:TextBox ID="txtApplyDate" runat="server"></asp:TextBox>
					</td>
                </tr>
                <tr>
                    <td class="auto-style1">发文人员</td>
					<td><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td class="auto-style1">流水号</td>
					<td class="tl PL10"><asp:TextBox ID="txtApplyID" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td class="tl PL10 PR10" colspan="4">
						<table id="tbDetail" class='sample tc' width='100%'>

                            <thead>
                                <tr>
                                    <td>序</td>
                                    <td>项  目</td>
                                    <td>品　牌</td>
                                    <td>单位</td>
                                    <td>单价（元）</td>
                                    <td>数量</td>
                                    <td>金额（元）</td>
                                    <td>备　　注</td>
                                </tr>
                            </thead>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag">
                                <td></td>
                                <td>合　计</td>
                                <td colspan="4"></td>
<%--                                <td><asp:TextBox ID="txtSumBrand" runat="server" Width="80px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumUnit" runat="server" Width="50px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumPrice" runat="server" Width="50px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumNum" runat="server" Width="50px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>--%>
                                <td><asp:TextBox ID="txtSumMoney" runat="server" Width="70px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSummarySum" runat="server" Width="90px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>税率<asp:TextBox ID="txtTax" runat="server" Width="40px"></asp:TextBox>%</td>
                                <td colspan="4"></td>
<%--                                <td><asp:TextBox ID="txtTaxBrand" runat="server" Width="80px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTaxUnit" runat="server" Width="50px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTaxPrice" runat="server" Width="50px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTaxNum" runat="server" Width="50px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>--%>
                                <td><asp:TextBox ID="txtTaxMoney" runat="server" Width="70px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSummaryTax" runat="server" Width="90px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>总　计</td>
                                <td colspan="4"></td>
<%--                                <td><asp:TextBox ID="txtCouBrand" runat="server" Width="80px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtCouUnit" runat="server" Width="50px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtCouPrice" runat="server" Width="50px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtCouNum" runat="server" Width="50px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>--%>
                                <td><asp:TextBox ID="txtCouMoney" runat="server" Width="70px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSummaryCou" runat="server" Width="90px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>工程实际结算</td>
                                <td colspan="4"></td>
<%--                                <td><asp:TextBox ID="txtRealBrand" runat="server" Width="80px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtRealUnit" runat="server" Width="50px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtRealPrice" runat="server" Width="50px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtRealNum" runat="server" Width="50px"></asp:TextBox></td>--%>
                                <td><asp:TextBox ID="txtRealMoney" runat="server" Width="70px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSummaryReal" runat="server" Width="90px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
						</table>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
						<div style="clear:both;">
                            委托方：广东中原地产代理有限公司
						</div>
					</td>
				</tr>

                <tr>
                    <td colspan="4" style="line-height: 25px; padding-left: 10px; text-align: left">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        供应商：<asp:RadioButton ID="rdbCouNum1" runat="server" GroupName="CouNum" Text="公司供应商" AutoPostBack="True" OnCheckedChanged="rdbCouNum1_CheckedChanged" />
                        <asp:RadioButton ID="rdbCouNum2" runat="server" GroupName="CouNum" Text="分行自行联系供应商" AutoPostBack="True" OnCheckedChanged="rdbCouNum1_CheckedChanged" /><br />
                        供应商名称：<asp:DropDownList ID="ddlRealBrand" runat="server" Width="265px" AutoPostBack="True" OnSelectedIndexChanged="ddlRealBrand_SelectedIndexChanged"></asp:DropDownList>
                        <asp:TextBox ID="txtRealBrand" runat="server" Width="260px" Visible="False"></asp:TextBox><br />
                        联系人：<asp:TextBox ID="txtRealUnit" runat="server" Width="150px"></asp:TextBox>
                        联系电话：<asp:TextBox ID="txtRealPrice" runat="server" Width="150px"></asp:TextBox>
                        邮箱：<asp:TextBox ID="txtRealNum" runat="server" Width="150px"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style1">分行行政助理</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style1">区域行政主任确认</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style1">分行主管/隶属主管确认</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
					</td>
				</tr>
                <tr id="trManager4" class="noborder" style="height: 85px;">
					<td class="auto-style1">区域负责人确认</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
					</td>
				</tr>

                <tr style="display: none">
                    <td>维 修 商</td>
                    <td><asp:TextBox ID="txtMerchant" runat="server"></asp:TextBox></td>
                    <td>联 系 人</td>
                    <td><asp:TextBox ID="txtConneter" runat="server"></asp:TextBox></td>
                </tr>
                <tr style="display: none">
                    <td>联系电话</td>
                    <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                    <td>邮箱地址</td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>完成维修的时间</td>
                    <td><asp:TextBox ID="txtCtime" runat="server"></asp:TextBox></td>
                    <td>完成维修确认人</td>
                    <td><asp:TextBox ID="txtCname" runat="server"></asp:TextBox></td>
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

