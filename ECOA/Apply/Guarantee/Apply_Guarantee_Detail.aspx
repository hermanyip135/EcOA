<%@ Page ValidateRequest="false" Title="担保申请 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Guarantee_Detail.aspx.cs" Inherits="Apply_Guarantee_Apply_Guarantee_Detail" %>

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
				select: function(event,ui) {}
			});
		    $("#<%=txtCCDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {}
		    });
		    $("#<%=txtReceiveDP.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {}
		    });
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

        function check() {
            if (isNaN($("#<%=txtLmoney.ClientID%>").val())) {
                alert("贷款金额必须输入纯数字");
                $("#<%=txtLmoney.ClientID%>").val('');
		            $("#<%=txtLmoney.ClientID%>").focus();
                return false;
            }

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

	        //if($.trim($("#<%=txtReceiveDP.ClientID %>").val())=="") {
	        //    alert("收文部门不可为空！");
	        //    $("#<%=txtReceiveDP.ClientID %>").focus();
	        //    return false;
	        //}
            
	        if($.trim($("#<%=txtTelephone.ClientID %>").val())=="") {
	            alert("回复电话不可为空！");
	            $("#<%=txtTelephone.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtFax.ClientID %>").val())=="") {
	            alert("回复传真不可为空！");
	            $("#<%=txtFax.ClientID %>").focus();
	            return false;
            }
            
	        if($.trim($("#<%=txtSubject.ClientID %>").val())=="") {
	            alert("文件主题不可为空！");
	            $("#<%=txtSubject.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtCaseNo.ClientID %>").val())=="") {
                alert("汇瀚案号不可为空！");
	            $("#<%=txtCaseNo.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtDealer.ClientID %>").val())=="") {
                alert("经办不可为空！");
                $("#<%=txtDealer.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtAddress.ClientID %>").val())=="") {
                alert("物业地址不可为空！");
                $("#<%=txtAddress.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtOwner.ClientID %>").val())=="") {
                alert("业主不可为空！");
                $("#<%=txtOwner.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtBuyer.ClientID %>").val())=="") {
                alert("买家不可为空！");
                $("#<%=txtBuyer.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtLoanBank.ClientID %>").val())=="") {
                alert("贷款银行不可为空！");
                $("#<%=txtLoanBank.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtCmoney.ClientID %>").val())=="") {
                alert("担保金额不可为空！");
                $("#<%=txtCmoney.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtLmoney.ClientID %>").val())=="") {
                alert("贷款金额不可为空！");
                $("#<%=txtLmoney.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtDmoney.ClientID %>").val())=="") {
                alert("成交金额不可为空！");
                $("#<%=txtDmoney.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
                alert("原因不可为空！");
                $("#<%=txtReason.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtCMPaier.ClientID %>").val())=="") {
                alert("担保费支付人不可为空！");
                $("#<%=txtCMPaier.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtCcoast.ClientID %>").val())=="") {
                alert("担保费用不可为空！");
                $("#<%=txtCcoast.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtProcess.ClientID %>").val())=="") {
                alert("办理流程不可为空！");
                $("#<%=txtProcess.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtPeriod.ClientID %>").val())=="") {
                alert("工作天数不可为空！");
                $("#<%=txtPeriod.ClientID %>").focus();
                return false;
            }

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
		    var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile20M.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
			if(sReturnValue=='success')
				window.location='Apply_Guarantee_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
		    var win=window.showModalDialog("Apply_Guarantee_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
					if(win=='success')
					    window.location="Apply_Guarantee_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx!='10'&&idx!='11'&&idx!='14'&&idx!='131'||idx=='13'||idx=='130'){
	        //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='6'||idx=='7'){//789
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
		            data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+9,
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
        .auto-style5 {
            width: 190px;
        }
        .auto-style6 {
            width: 280px;
        }
        .auto-style7 {
            width: 170px;
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
			<h1>担保申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td class="auto-style7">收文部门</td>
					<td class="tl PL10">董事总经理—黄轩明<asp:TextBox ID="txtReceiveDP" runat="server" Width="200px" Visible="False"></asp:TextBox></td>
					<td class="auto-style5" >发文编号</td>
					<td class="tl PL10"><asp:TextBox ID="txtApplyID" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style7" >发文部门</td>
					<td class="auto-style6"><asp:TextBox ID="txtDepartment" runat="server" Width="185px">汇瀚-金融服务部</asp:TextBox>-<asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td class="auto-style5">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
                    <td class="auto-style7">抄送部门</td>
					<td class="tl PL10">财务部、法律部、后勤事务部<asp:TextBox ID="txtCCDepartment" runat="server" Width="200px" Visible="False"></asp:TextBox></td>
					<td class="auto-style5">回复电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style7">文件主题</td>
					<td class="tl PL10"><asp:TextBox ID="txtSubject" runat="server" Width="200px"></asp:TextBox></td>
					<td class="auto-style5">回复传真</td>
					<td class="tl PL10"><asp:TextBox ID="txtFax" runat="server"></asp:TextBox></td>
				</tr>

                <tr>
					<td colspan="4" style="text-align: center">
                        <div style="border-color: #000000; border-bottom-style: groove; border-top-style: groove; border-top-width: 1px; border-bottom-width: 2px; height: 2px; width: 620px;margin:0 auto;"></div>
                        <div style="padding-left: 20px; text-align: left; margin-bottom: 15px; margin-top: 10px; line-height: 25px;">
                            兹有以下案件：<br />
                            汇瀚案号：<asp:TextBox ID="txtCaseNo" runat="server" Width="200px"></asp:TextBox>经办：<asp:TextBox ID="txtDealer" runat="server" Width="200px"></asp:TextBox><br />
                            物业地址：<asp:TextBox ID="txtAddress" runat="server" Width="440px"></asp:TextBox><br />
                            业主：<asp:TextBox ID="txtOwner" runat="server" Width="200px"></asp:TextBox><br />
                            买家：<asp:TextBox ID="txtBuyer" runat="server" Width="200px"></asp:TextBox><br />
                            贷款银行：<asp:TextBox ID="txtLoanBank" runat="server" Width="300px"></asp:TextBox><br />
                            担保金额(业主供款余额)：<asp:TextBox ID="txtCmoney" runat="server" Width="200px"></asp:TextBox>万<br />
                            贷款金额：<asp:TextBox ID="txtLmoney" runat="server" Width="200px"></asp:TextBox>万<br />
                            成交金额：<asp:TextBox ID="txtDmoney" runat="server" Width="200px"></asp:TextBox>万<br />
                            <div style="margin-top: 10px">
                                <span style="vertical-align: top">原因：</span>
                                <asp:textbox id="txtReason" runat="server" TextMode="MultiLine" Width="85%" Height="100px"></asp:textbox>
                            </div>
                        　　担保费：由<asp:TextBox ID="txtCMPaier" runat="server" Width="200px"></asp:TextBox>支付，担保费用为￥
                            <asp:TextBox ID="txtCcoast" runat="server" Width="200px"></asp:TextBox>元。(担保费最终以业主供款余额为准)<br />
                            按照<asp:TextBox ID="txtProcess" runat="server" Width="110px"></asp:TextBox>区房管局的办理流程，我司出具《担保函》至出具《解保函》的工作时间约为
                            <asp:TextBox ID="txtPeriod" runat="server" Width="50px"></asp:TextBox><br />个工作天。<br />
                            附件清单：1、担保申请表及协议书<br />
                            　　　　　2、买卖双方身份证、户口薄、婚姻状况证明复印件<br />
                            　　　　　3、房产证复印件<br />
                            　　　　　4、网签合同复印件<br />
                            　　　　　5、查册表复印件<br />
                            　　　　　6、原贷款合同复印件<br /><br />
                        　　　以上申请妥否，盼复！<br />
                        </div> 
					</td>
				</tr>
                <tr>
                    <th colspan="4" style="line-height:25px;" >签署部门/人员</th>
				</tr>

               <tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style7">部门主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style7">部门负责人意见</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
                <tr id="trManager4" class="noborder" style="height: 84px;"> 
					<td class="auto-style7" >首席运营官</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">确认</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" style="width: 98%; overflow: auto; height: 84px;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>
				<tr id="trMs1" class="noborder" style="height: 85px;"> 
					<td rowspan="2" class="auto-style7" >法律部门<br />主管意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">确认</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><br />
						<textarea id="txtIDx5" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
				<tr id="trMs2" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><br />
						<textarea id="txtIDx6" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
					</td>
				</tr>
                <tr class="noborder" style="height: 85px;">
                    <td rowspan="2" class="auto-style7" >财务部门<br />主管意见</td>  
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree6" /><label for="rdbNoIDx7">不同意</label><br />
						<textarea id="txtIDx7" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">                                                                                                          
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">确认</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label>
                        　<asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton><br />
						<textarea id="txtIDx8" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
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
				<tr id="trLogistics2" class="noborder" style="height: 85px;">
                    <td class="auto-style7" >后勤事务部意见<br /><asp:Button ID="btnWillEnd2" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td> 
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label><input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
						<textarea id="txtIDx9" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
					</td>
				</tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style7" >后勤事务部意见<br />
                       <%-- <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />--%>
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="6" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>

				<tr id="trGeneralManager" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style7" >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
						<textarea id="txtIDx10" style="width: 98%; overflow: auto; height: 87px;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
					</td>
				</tr>
                 
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style7" >董事总经理<br />审批意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="6" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
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
                
                <tr id="tlMA1" style="display: none">
				    <td style="line-height: 15px; text-align: center;">中国华南区总裁<br />审批意见</td>
				    <td colspan="3" style="  line-height: 40px;">
                        <div style="text-align: left; padding-left: 25px;"><label>【 】同意</label>　<label>【 】不同意</label></div>
                        <div>_______________________________________________________________________________________</div>
                        <div>_______________________________________________________________________________________</div>
                        <div>______________________________________________________　　_________年_______月_______日</div>
				    </td>
			    </tr>
                <tr id="tlMA2" style="display: none">
				    <td style="line-height: 15px; text-align: center;">中原（中国）董事总经理<br />审批意见</td>
				    <td colspan="3" style="  line-height: 40px;">
                        <div style="text-align: left; padding-left: 25px;"><label>【 】同意</label>　<label>【 】不同意</label></div>
                        <div>_______________________________________________________________________________________</div>
                        <div>_______________________________________________________________________________________</div>
                        <div>______________________________________________________　　_________年_______月_______日</div>
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
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
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

