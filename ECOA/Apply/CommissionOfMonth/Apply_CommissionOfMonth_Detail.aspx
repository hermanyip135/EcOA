<%@ Page ValidateRequest="false" Title="关于享受本月佣金按全年一次性奖金发放申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_CommissionOfMonth_Detail.aspx.cs" Inherits="Apply_CommissionOfMonth_Apply_CommissionOfMonth_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        var vs = '<%=vs%>';

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
		
		$(function() {      
		    $("[id*=btn2Upload]").css({
		        "background-image": "url(/Images/btn_upload_s1.png)",
		        "height": "25px", 
		        "width": "72px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btn2LoadPath]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_upload_s2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_upload_s1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_upload_s1.png)"); });



		    $("[id*=btnLoadPath]").css({
		        "background-image": "url(/Images/btnLoadPath1.png)",
		        "height": "25px", 
		        "width": "43px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnLoadPath]").mousedown(function () { $(this).css("background-image", "url(/Images/btnLoadPath2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnLoadPath1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnLoadPath1.png)"); });

		    $("[id*=btnDownSPath]").css({
		        "background-image": "url(/Images/btnDownSPath1.png)",
		        "height": "25px", 
		        "width": "113px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnDownSPath]").mousedown(function () { $(this).css("background-image", "url(/Images/btnDownSPath2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnDownSPath1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnDownSPath1.png)"); });
            
		    $("[id*=btnSureUse]").css({
		        "background-image": "url(/Images/btnSureUse1.png)",
		        "height": "25px", 
		        "width": "77px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnSureUse]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureUse2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureUse1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureUse1.png)"); });
            
		    $("[id*=btnCantUse]").css({
		        "background-image": "url(/Images/btnCantUse1.png)",
		        "height": "25px", 
		        "width": "92px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnCantUse]").mousedown(function () { $(this).css("background-image", "url(/Images/btnCantUse2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnCantUse1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnCantUse1.png)"); });

			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});
		    $("#<%=txtEnterDate.ClientID%>").datepicker();
		    i = $("#tbDetail").find("tr[id*=trDetail]").size();
		    for (var x = 1; x < i; x++) {
		        $("#txtDetail_Department"+ x).autocomplete({source: jJSON});
		    }
		    for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		        $("#txtDetail_EnterDate" + x).datepicker();
		    }
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});
       

        function check() {
            if(vs != "1"){
                alert("请先上传附件！");
                $("#<%=txtFilePath.ClientID %>").focus();
                return false;
            }
	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("发文编号不可为空！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("部门/分行不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }
			
	        if($.trim($("#<%=txtName.ClientID %>").val())=="") {
	            alert("姓名不可为空！");
	            $("#<%=txtName.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtCode.ClientID %>").val())=="") {
	            alert("工号不可为空！");
	            $("#<%=txtCode.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtEnterDate.ClientID %>").val())=="") {
	            alert("入职日期不可为空！");
	            $("#<%=txtEnterDate.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtPosition.ClientID %>").val())=="") {
	            alert("现职位不可为空！");
	            $("#<%=txtPosition.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("现任职部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtRank.ClientID %>").val())=="") {
                alert("现职级不可为空！");
                $("#<%=txtRank.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtResults.ClientID %>").val())=="") {
                alert("预估本月实收业绩及解HOLD佣实收业绩不可为空！");
                $("#<%=txtResults.ClientID %>").focus();
                return false;
            }

            var data = "";
            var flag = true;
            //$("#tbDetail tr").each(function(n) {
            for(var n = 1;n <= $("#tbDetail").find("tr[id*=trDetail]").size();n ++){
                //if (n != 0 && n <= $("#tbDetail").find("tr[id*=trDetail]").size()) {
                    if ($.trim($("#txtDetail_Department" + n).val()) == "") {
                        alert("第" + n + "行的现任职部门必须填写。");
                        $("#txtDetail_Department" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtDetail_Name" + n).val()) == "") {
                        alert("第" + n + "行的姓名必须填写。");
                        $("#txtDetail_Name" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtDetail_Code" + n).val()) == "") {
                        alert("第" + n + "行的工号必须填写。");
                        $("#txtDetail_Code" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtDetail_EnterDate" + n).val()) == "") {
                        alert("第" + n + "行的入职日期必须填写。");
                        $("#txtDetail_EnterDate" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtDetail_Position" + n).val()) == "") {
                        alert("第" + n + "行的现职位必须填写。");
                        $("#txtDetail_Position" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtDetail_Rank" + n).val()) == "") {
                        alert("第" + n + "行的现职级必须填写。");
                        $("#txtDetail_Rank" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtDetail_Results" + n).val()) == "") {
                        alert("第" + n + "行的预估本月实收业绩及解HOLD佣实收业绩必须填写。");
                        $("#txtDetail_Results" + n).focus();
                        flag = false;
                    }
                    else
                        data += $.trim($("#txtDetail_Department" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Name" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Code" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_EnterDate" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Position" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Rank" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Results" + n).val()) 
                            + "||";
                //}
            }
            if (flag) {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
                if(data!="" || $("#tbDetail tr").size() == 2)
	                return true;
	            else 
	                return false;
            }
            else
                return false;
        }

        function addRow() {//*-
            i++;
            var html = '<tr id="trDetail' + i + '">'
                + '         <td style=\"line-height: 15px;\">'
                + '             <table style="border-collapse: collapse;" width="100%"><tr><td>* 姓名</td>'
                + '               <td style="text-align: left; padding-left: 10px"><input type="text" id="txtDetail_Name' + i + '" ></td><td class="astyle2">* 工号</td>'
                + '               <td style="text-align: left; padding-left: 10px"><input type="text" id="txtDetail_Code' + i + '" onblur="getEmployeeN(' + i + ', this);"></td></tr><tr><td>* 入职日期</td>'
                + '               <td style="text-align: left; padding-left: 10px"><input type="text" id="txtDetail_EnterDate' + i + '"></td><td>* 现任职部门</td>'
                + '               <td style="text-align: left; padding-left: 10px"><input type="text" id="txtDetail_Department' + i + '"></td></tr><tr><td>* 现职位</td>'
                + '               <td style="text-align: left; padding-left: 10px"><input type="text" id="txtDetail_Position' + i + '"></td><td>* 现职级</td>'
                + '               <td style="text-align: left; padding-left: 10px"><input type="text" id="txtDetail_Rank' + i + '"></td></tr><tr><td class="astyle2">* 预估本月实收业绩及解HOLD佣实收业绩</td>'
                + '               <td colspan="3" style="text-align: left; padding-left: 10px"><input type="text" id="txtDetail_Results' + i + '">元</td>'
                + '             </tr></table>'
                + '         </td>'
				+ '     </tr>';
            //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
            $("#trFlag").before(html);
            //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");

            $("#txtDetail_Department"+ i).autocomplete({source: jJSON});
            $("#txtDetail_EnterDate"+ i).datepicker();
        }

        function deleteRow() {
            if (i > 0) {
                i--;
                $("#tbDetail tr[id*=trDetail]:eq(" + i + ")").remove();
            } else
                alert("不可再删除了。");
            //$("#tbDetail tr:eq(0)").remove();
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
		    var sReturnValue = window.showModalDialog("Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue!=null)
		    {
		        //if(isNewApply){
		            vs = "1";
		            $("#spm").html("您已上传了：" + sReturnValue);
		        //}
		        //else
		        //    window.location='Apply_CommissionOfMonth_Detail.aspx?MainID=<%=MainID %>&vs=1';
		    }
		}

		function editflow(){
			var win=window.showModalDialog("Apply_CommissionOfMonth_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_CommissionOfMonth_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
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
		function DeleteT() { //20141231：M_DeleteC
		    $("#btnADelete").hide();
		    var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
		    if(sReturnValue=='deleted')
		        window.location='/Apply/Apply_Search.aspx';
		    else
		        window.location.href=window.location.href;
		}
        function checkLoad() {
            if ($.trim($("#txtFilePath").val()) == '') {
                alert("请选择附件!");
                $("#txtFilePath").focus();
                return false;
            }
            return true;
        }
        function getEmployeeN(n,s) {//*-
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + s.value,
                success: function (info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#txtDetail_Name" + n).val(infos[1]);
                        $("#txtDetail_Department" + n).val(infos[2]);
                        //$("#<%=hdDepartmentID.ClientID%>").val(infos[3]);

                        $("#txtDetail_EnterDate" + n).val(infos[6]);
                        $("#txtDetail_Position" + n).val(infos[4]);
                        $("#txtDetail_Rank" + n).val(infos[5]);
                    }
                    else {
                        $("#txtDetail_Department" + n).val("");
                        //$("#<%=hdDepartmentID.ClientID%>").val("");

                        $("#txtDetail_Name" + n).val("");
                        $("#txtDetail_EnterDate" + n).val("");
                        $("#txtDetail_Position" + n).val("");
                        $("#txtDetail_Rank" + n).val("");
                    }
                }
            })
        }
        function getEmployee(n) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function (info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtName.ClientID%>").val(infos[1]);
		                $("#<%=txtDepartment.ClientID%>").val(infos[2]);
		                $("#<%=hdDepartmentID.ClientID%>").val(infos[3]);

		                $("#<%=txtEnterDate.ClientID%>").val(infos[6]);
		                $("#<%=txtPosition.ClientID%>").val(infos[4]);
		                $("#<%=txtRank.ClientID%>").val(infos[5]);
		            }
		            else {
		                $("#<%=txtDepartment.ClientID%>").val("");
		                $("#<%=hdDepartmentID.ClientID%>").val("");

		                $("#<%=txtName.ClientID%>").val("");
		                $("#<%=txtEnterDate.ClientID%>").val("");
		                $("#<%=txtPosition.ClientID%>").val("");
		                $("#<%=txtRank.ClientID%>").val("");
		            }
		        }
		    })
        }
	</script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
        .auto-style4 {
            width: 90px;
        }
        .astyle2 {
            width: 85px;
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
			<h1>关于享受本月佣金按全年一次性奖金发放申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <%--<div style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>--%>
			<table id="tbAround"  width='640px'>
                <tr>
                    <td class="auto-style4">* 姓名</td>
                    <td class="tl PL10"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
					<td class="auto-style4">* 工号</td>
					<td class="tl PL10"><asp:textbox id="txtCode" runat="server" onblur="getEmployee(this);"></asp:textbox></td>
				</tr>
                <tr>
                    <td class="auto-style4">* 入职日期</td>
					<td class="tl PL10"><asp:textbox id="txtEnterDate" runat="server"></asp:textbox></td>
                    <td class="auto-style4">* 现任职部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
				</tr>
				<tr>
                    <td class="auto-style4">* 现职位</td>
                    <td class="tl PL10"><asp:TextBox ID="txtPosition" runat="server"></asp:TextBox></td>
					<td class="auto-style4">* 现职级</td>
					<td class="tl PL10"><asp:textbox id="txtRank" runat="server"></asp:textbox></td>
				</tr>
				<tr>
                    <td class="auto-style4">* 发文编号</td>
                    <td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
                    <td class="auto-style4">文档编码</td>
                    <td class="tl PL10"><span class="file_number"><%=SerialNumber %></span></td>
				</tr>
                <tr>
                    <td class="auto-style4">* 预估本月实收业绩及解HOLD佣实收业绩</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:textbox id="txtResults" runat="server"></asp:textbox>元
                    </td>
                </tr>
                <tr>
					<td colspan="4" style="width: 100%">
						<table id="tbDetail" class='sample tc' width='100%'>

                            <thead><tr><td></td></tr></thead>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag"><td></td></tr>

						</table>
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
					</td>
				</tr>
                <tr id="UploatPath">
                    <td class="auto-style4">* 上传附件</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        申请人手写申请情况说明并签名确认。<br />
                        <div style="margin-top: 10px; margin-bottom: 5px">
                            <input type="button" id="btn2Upload" value="上传附件..." onclick="upload();" style="margin-left: 5px;" />
                            <asp:FileUpload ID="txtFilePath" runat="server" Width="275px" Visible="False" />　
                            <asp:Button ID="btnLoadPath" runat="server" Text="上 传" class="btn button" OnClick="btnLoadPath_Click" Visible="False" />
                            <input type="button" id="btnDownSPath" value="下载申请样本" onclick="window.open('../../资料/手写申请模板.xlsx');" style="margin-left: 10px"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 10px; line-height: 20px;">
                        　　由于本月的实收业绩及HOLD佣实收业绩较高，导致本月需缴交高额的税费，现向公司申
                        请本月佣金按全年一次性奖金发放。望得到公司批准。谢谢！
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; vertical-align: top" class="auto-style4" >备注</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:textbox id="txtDescribe" runat="server" TextMode="MultiLine" Width="98%" Height="100px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">填写人：</td>
                    <td><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td class="auto-style4">填写日期：</td>
                    <td><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style4">直属主管</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style4">隶属主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>
				<tr id="trmq">
					<td class="auto-style4">区域办公室</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style4">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>

				<tr class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style4">人力资源部</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6"/>
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
						<textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>
                <tr id="trCcess" class="noborder" style="height: 30px;">
					<td class="auto-style4">反馈确认</td>
					<td colspan="3" class="tl PL10">
                        <span id="trFinancial"style="display: none;">
                            <asp:Button ID="btnSureUse" runat="server" Text="确认使用" OnClick="btnSureUse_Click" />　
                            <asp:Button ID="btnCantUse" runat="server" Text="确认不使用" OnClick="btnCantUse_Click" />
                        </span>　
                        <asp:Label ID="lbSee" runat="server" Text="申请人取消申请" Visible="False" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lbUse" runat="server" Text="确认使用" Visible="False" Font-Bold="True" Font-Size="Larger" ForeColor="#009933"></asp:Label>
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
            <span id ="spm"></span><br />
		<hr />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		
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

