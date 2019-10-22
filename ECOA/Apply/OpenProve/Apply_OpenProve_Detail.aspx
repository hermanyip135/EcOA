<%@ Page ValidateRequest="false" Title="薪酬福利类证明开具申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_OpenProve_Detail.aspx.cs" Inherits="Apply_OpenProve_Apply_OpenProve_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
		var i = 1;
		var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        var vs = '<%=vs%>';
        var SumLoad = '';

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
		    //$("#<%=txtEnterDate.ClientID%>").datepicker();
		    i = $("#tbDetail").find("tr[id*=trDetail]").size();
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDetail_Department"+ x).autocomplete({source: jJSON});
		    //}
		    for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		        $("#txtDetail_Sdate" + x).datepicker();
		        $("#txtDetail_Edate" + x).datepicker();
		    }
		    IsSignModeBind();
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});
       

        function check() {
            //if(vs != "1"){
            //    alert("请先上传附件！");
            //    $("#<%=txtFilePath.ClientID %>").focus();
            //    return false;
            //}
	        
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

            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
                alert("联系电话不可为空！");
                $("#<%=txtPhone.ClientID %>").focus();
                return false;
            }
            flag = false;
            var val = "";
            $("input[name='r5']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择签收方式");
                $("#Radio12").focus();
                return false;
            }
            $("#<%=this.hiSignMode.ClientID%>").val(val);
            if($("#Radio12").prop('checked'))
            {
                if($.trim($("#<%=txtSignAddress.ClientID %>").val())=="")
                {  alert("请填写快递地址");
                $("#<%=txtSignAddress.ClientID %>").focus();
                  return false;
                }
               else if($.trim($("#<%=txtSignPhone.ClientID %>").val())=="")
               {  alert("请填写联系电话");
               $("#<%=txtSignPhone.ClientID %>").focus();
                    return false;
               }
               else if($.trim($("#<%=txtRecipient.ClientID %>").val())=="")
               {  alert("请填写签收人");
               $("#<%=txtRecipient.ClientID %>").focus();
                   return false;
               }
            }
            var data = "";
            var flag = true;
            //$("#tbDetail tr").each(function(n) {
            for(var n = 1;n <= $("#tbDetail").find("tr[id*=trDetail]").size();n ++){
                //if (n != 0 && n <= $("#tbDetail").find("tr[id*=trDetail]").size()) {
                if($.trim($("#ddlProve" + n).find("option:selected").text()) == "请选择"){
                    alert("请选择第" + n + "行的申请证明类别"); 
                    $("#ddlProve" + n).focus();
                    flag = false;
                    break;
                }
                else if ($.trim($("#txtDetail_No" + n).val()) == "") {
                    alert("第" + n + "行的份数必须填写。");
                    $("#txtDetail_No" + n).focus();
                    flag = false;
                    break;
                }

                if (!$("#rdoReasondb" + n + "1").prop('checked') && !$("#rdoReasondb" + n + "0").prop('checked')  && !$("#rdoReasondb" + n + "2").prop('checked')  && !$("#rdoReasondb" + n + "3").prop('checked')) {
                    alert("请选择第" + n + "行的开具原因。");
                    $("#rdoReasondb" + n + "1").focus();
                    flag = false;
                    break;
                }
                else if ($("#rdoReasondb" + n + "1").prop('checked')){
                    if ($.trim($("#txtDetail_Address" + n).val()) == "") {
                        alert("第" + n + "行的出游地点必须填写。");
                        $("#txtDetail_Address" + n).focus();
                        flag = false;
                        break;
                    }
                    else if ($.trim($("#txtDetail_Sdate" + n).val()) == "") {
                        alert("第" + n + "行的出游时间必须填写。");
                        $("#txtDetail_Sdate" + n).focus();
                        flag = false;
                        break;
                    }
                    else if ($.trim($("#txtDetail_Edate" + n).val()) == "") {
                        alert("第" + n + "行的出游时间必须填写。");
                        $("#txtDetail_Edate" + n).focus();
                        flag = false;
                        break;
                    }
                }
                else if ($("#rdoReasondb" + n + "0").prop('checked')){
                    if ($.trim($("#txtDetail_AnotherR" + n).val()) == "") {
                        alert("第" + n + "行的其他原因必须填写。");
                        $("#txtDetail_AnotherR" + n).focus();
                        flag = false;
                        break;
                    }
                }
                if (!$("#rdoKind" + n + "1").prop('checked') && !$("#rdoKind" + n + "2").prop('checked') && !$("#rdoKind" + n + "3").prop('checked') && !$("#rdoKind" + n + "4").prop('checked')){
                    alert("请选择第" + n + "行的收入证明金额类型。");
                    $("#rdoKind" + n + "1").focus();
                    flag = false;
                    break;
                }
                else if ($("#rdoKind" + n + "3").prop('checked')){
                    if ($.trim($("#txtDetail_AnotherKind" + n).val()) == "") {
                        alert("第" + n + "行的其他要求必须填写。");
                        $("#txtDetail_AnotherKind" + n).focus();
                        flag = false;
                        break;
                    }
                }
                if (flag) 
                    data += $.trim($("#ddlProve" + n).find("option:selected").text())+"&&"+$.trim($("#txtDetail_No" + n).val())+
                        "&&"+$.trim(($("#rdoReasondb" + n + "1").prop('checked')?"1":$("#rdoReasondb" + n + "2").prop('checked')?"2":$("#rdoReasondb" + n + "3").prop('checked')?"3":"0"))+
                        "&&"+$.trim($("#txtDetail_Address" + n).val())+"&&"+$.trim($("#txtDetail_Sdate" + n).val())+"&&"+$.trim($("#txtDetail_Edate" + n).val())+"&&"+$.trim($("#txtDetail_AnotherR" + n).val())+"&&"+$.trim(($("#rdoKind" + n + "1").prop('checked')?"1":$("#rdoKind" + n + "2").prop('checked')?"2":$("#rdoKind" + n + "3").prop('checked')?"3":$("#rdoKind" + n + "4").prop('checked')?"4":"0"))+"&&"+$.trim($("#txtDetail_AnotherKind" + n).val())+"||";
                //}
            }
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

        function addRow() {//*-
            i++;
            //var html = '<tr class="noborder" id="trDetail' + i + '">'
            //    + '         <td style="line-height: 15px;">'
            //    + '               <table style="line-height: 25px; border-collapse: collapse;" width="100%">'
            //    + '                   <tr class="noborder"><td style="width:120px">* 申请证明类别</td><td style="text-align: left; padding-left: 7px"><select id="ddlProve' + i + '" style="width:150px"><option>请选择</option><option>在职证明</option><option>收入证明</option><option>在职收入证明</option><option>社保证明</option><option>公积金证明</option><option>社保公积金证明</option></select></td><td style="width:70px">* 份数</td><td style="text-align: left; padding-left: 7px"><input type="text" id="txtDetail_No' + i + '"/></td></tr>'
            //    + '                   <tr class="noborder"><td rowspan="2">﹡开具原因</td><td colspan="3" class="tl PL10"><input type="radio" id="rdoReasondb' + i + '1" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '1">办理签证：</label>出游地点<input type="text" id="txtDetail_Address' + i + '" style="width: 43%"/><br/>&nbsp;&nbsp;出游时间<input type="text" id="txtDetail_Sdate' + i + '" style="width: 80px"/>至<input type="text" id="txtDetail_Edate' + i + '" style="width: 80px"/></td></tr>'
            //    + '                   <tr class="noborder"><td colspan="3" class="tl PL10"><input type="radio" id="rdoReasondb' + i + '0" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '0">其他原因</label><input type="text" id="txtDetail_AnotherR' + i + '" style="width: 83.5%"/></td></tr>'
            //    + '                   <tr class="noborder"><td>* 收入证明金额类型</td><td colspan="3" class="tl PL10"><input type="radio" id="rdoKind' + i + '1" name="Kind' + i + '" /><label for="rdoKind' + i + '1">月均税前收入</label><input type="radio" id="rdoKind' + i + '2" name="Kind' + i + '" /><label for="rdoKind' + i + '2">月均税后收入</label><input type="radio" id="rdoKind' + i + '3" name="Kind' + i + '" /><label for="rdoKind' + i + '3">其他要求</label><input type="text" id="txtDetail_AnotherKind' + i + '" style="width: 47%"/></td></tr>'
            //    + '               </table></td></tr>';
            var html = '<tr class="noborder" id="trDetail' + i + '">'
                + '         <td style="line-height: 15px;">'
                + '               <table style="line-height: 25px; border-collapse: collapse;" width="100%">'
                + '                   <tr class="noborder"><td style="width:120px">* 申请证明类别</td><td style="text-align: left; padding-left: 7px"><select id="ddlProve' + i + '" style="width:150px"><option>请选择</option><option>在职证明</option><option>在职收入证明</option><option>社保证明</option><option>公积金证明</option></select></td><td style="width:70px">* 份数</td><td style="text-align: left; padding-left: 7px"><input type="text" id="txtDetail_No' + i + '"/></td></tr>'
                //+ '                   <tr class="noborder"><td rowspan="2">﹡开具原因</td><td colspan="3" class="tl PL10"><input type="radio" id="rdoReasondb' + i + '1" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '1">办理签证：</label>出游地点<input type="text" id="txtDetail_Address' + i + '" style="width: 43%"/><br/>&nbsp;&nbsp;出游时间<input type="text" id="txtDetail_Sdate' + i + '" style="width: 80px"/>至<input type="text" id="txtDetail_Edate' + i + '" style="width: 80px"/></td></tr>'
                //+ '                   <tr class="noborder"><td colspan="3" class="tl PL10"><input type="radio" id="rdoReasondb' + i + '0" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '0">其他原因</label><input type="text" id="txtDetail_AnotherR' + i + '" style="width: 83.5%"/>'
                //+'                                 <input type="radio" id="rdoReasondb' + i + '1" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '1">购车</label></td></tr>'
                + '<tr class="noborder">'
                + '<td rowspan="4">﹡开具原因</td>'
                + '<td colspan="3" class="tl PL10">'
                + '<input type="radio" id="rdoReasondb' + i + '1" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '1">办理签证：</label>'
                + '出游地点<input type="text" id="txtDetail_Address' + i + '" style="width: 43%"/>'
                + '<br/>&nbsp;&nbsp;出游时间<input type="text" id="txtDetail_Sdate' + i + '" style="width: 80px"/>至<input type="text" id="txtDetail_Edate' + i + '" style="width: 80px"/></td></tr>'
                   + '<tr class="noborder"><td colspan="3" class="tl PL10">'
                + '<input type="radio" id="rdoReasondb' + i + '2" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '2">购车</label>'
                +' </td></tr>'
                + '</td></tr>'
                + '<tr class="noborder"><td colspan="3" class="tl PL10">'
                + '<input type="radio" id="rdoReasondb' + i + '3" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '3">购房</label>'
                +' </td></tr>'
               + '<tr class="noborder"><td colspan="3" class="tl PL10">'
                + '<input type="radio" id="rdoReasondb' + i + '0" name="Reasondb' + i + '" /><label for="rdoReasondb' + i + '0">其他原因</label><input type="text" id="txtDetail_AnotherR' + i + '" style="width: 83.5%"/>'
                + '</td></tr>'
            
                + '                   <tr class="noborder"><td>* 收入证明金额类型</td><td colspan="3" class="tl PL10"><input type="radio" id="rdoKind' + i + '1" name="Kind' + i + '" /><label for="rdoKind' + i + '1">月均税前收入</label><input type=\"radio\" id=\"rdoKind" + i + "4\" name=\"Kind" + i + "\" /><label for=\"rdoKind" + i + "4\">无</label><input type="radio" id="rdoKind' + i + '2" name="Kind' + i + '" /><label for="rdoKind' + i + '2">月均税后收入</label><input type="radio" id="rdoKind' + i + '3" name="Kind' + i + '" /><label for="rdoKind' + i + '3">其他要求</label><input type="text" id="txtDetail_AnotherKind' + i + '" style="width: 40%"/></td></tr>'
                + '               </table></td></tr>';
            //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
            $("#trFlag").before(html);
            //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
            //$("label").css("color","#0d9405");
            //$("[for*=rdoKind]").css("color","#0d9405");
            //$("[for*=rdoKind]").css("color","#0d9405");
            $("#txtDetail_Sdate"+ i).datepicker();
            $("#txtDetail_Edate"+ i).datepicker();
        }

        function deleteRow() {
            if (i > 0) {
                i--;
                $("#tbDetail tr[id*=trDetail]:eq(" + i + ")").remove();
            } else
                alert("不可再删除了。");
            //$("#tbDetail tr:eq(0)").remove();
        }
        function IsSignModeBind()
        {
            var IsSignMode = $("#<%=this.hiSignMode.ClientID%>").val();

            if (IsSignMode == "") {
                $("input[name='r5']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $("input[name='r5'][value=" + IsSignMode + "]").get(0).checked = true;

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
		    var sReturnValue = window.showModalDialog("/Apply/Apply_Uploads.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px").toString();
		    if(sReturnValue!=null)
		    {
		        SumLoad += sReturnValue.substr(sReturnValue.indexOf('上传）')+3,sReturnValue.length) + "<br />";
		        //if(isNewApply){
		        vs = "1";
		        $("#spm").html("<br />您已上传了：<br />" + SumLoad);
		        //}
		        //else
		        //    window.location='Apply_OpenProve_Detail.aspx?MainID=<%=MainID %>&vs=1';
		    }
		}

		function editflow(){
			var win=window.showModalDialog("Apply_OpenProve_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_OpenProve_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
        function onSignMode()
        {
            $("#<%=txtSignAddress.ClientID%>").val('');
            $("#<%=txtSignPhone.ClientID%>").val('');
            $("#<%=txtRecipient.ClientID%>").val('');
        }
	    function sign(idx) {
	        //if(idx=='1'||idx=='2'||idx=='3'){//789
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
			
	        if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbYes1IDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
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
				else if($("#rdbYes1IDx"+idx).prop("checked"))
				    $("#<%=hdIsAgree.ClientID %>").val("100");
					   
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
		              
		            }
		            else {
		                $("#<%=txtDepartment.ClientID%>").val("");
		                $("#<%=hdDepartmentID.ClientID%>").val("");

		                $("#<%=txtName.ClientID%>").val("");
		                $("#<%=txtEnterDate.ClientID%>").val("");
		                $("#<%=txtPosition.ClientID%>").val("");
		            
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
        input[readonly='readonly']{background:#cecece}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="summaryLeft" style="float: left; width: 25%; padding-top: 75px; padding-left: 5px; display:none; padding-right: 10px;">

    </div>
    <div id="summaryRight" style="float: right; width: 21%; padding-top: 75px; padding-left: 5px; display:none; padding-left: 10px;">
        <span style="font-size: large; font-weight: bold">薪酬福利类证明申请审批流：</span><br /><br />
        <span style="font-size: large">1、非签证原因的证明申请流程：申请人填写完成后，保存—人力资源部（朱晓晴）</span><br /><br />
        <span style="font-size: large">2、签证原因的证明申请流程：申请人填写完成后，保存—部门主管—隶属主管—部门负责人—人力资源部（朱晓晴）</span><br /><br />
        <%--<span style="font-size: large">3、如申请盖中原公章的签证证明，请直接上公章使用申请表，并在用途写明出游地点及时间。</span><br />--%>
    </div>

    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 640px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
        <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>薪酬福利类证明开具申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <div style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
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
                    <td class="tl PL10"><asp:TextBox ID="txtPosition" runat="server" ></asp:TextBox></td>
					<%--		<td class="auto-style4">* 现职级</td>
					<td class="tl PL10"><asp:textbox id="txtRank" runat="server" ></asp:textbox></td>--%>
                    <td class="auto-style4">* 联系电话</td>
					<td class="tl PL10"><asp:textbox id="txtPhone" runat="server" ></asp:textbox></td>
				</tr>

                <tr>
                    <td class="tl PL10" colspan="4" style="font-weight: bold">证明申请明细表</td>
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
                  <tr>
                    <td class="auto-style4" rowspan="2">*签收方式</td>
                    <td  colspan="3" style="text-align:left">
                        
                           <input type="radio" id="Radio12" name="r5" value="1" /><label for="Radio12">快递到付</label> <label>快递地址</label>  <asp:TextBox ID="txtSignAddress" runat="server" Width="50px"></asp:TextBox>
                             <label>联系电话</label><asp:TextBox ID="txtSignPhone" runat="server" Width="50px"></asp:TextBox>
                             <label>签收人</label><asp:TextBox ID="txtRecipient" runat="server" Width="50px"></asp:TextBox>
                                <asp:HiddenField ID="hiSignMode" runat="server" />
                       
                    </td>
                   
                </tr>
                <tr>
                     <td  colspan="3" style="text-align:left">
                          <input type="radio" id="Radio1" name="r5" value="2" onclick="onSignMode()" /><label for="Radio1">到公司总部进行签收</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        特殊情况说明
                    </td>
                    <td colspan="3">
                        <textarea runat="server" id="ExceptionalCase" style="width:500px">

                        </textarea>
                    </td>
                </tr>
                <tr id="UploatPath">
                    <td class="auto-style4">* 上传附件</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                      <%--  1、	如非本人填写此份申请，请申请人按照证明申请版本手写签名确认后上传作为附件。<br /><br />
                        2、	如办理签证的证明有其他规定版本，请上传版本作为附件。<br /><br />--%>
                           1、	如非本人填写此份申请，请申请人按照证明申请版本手写签名确认后上传作为附件。<br />
                        <a href="附件3：证明申请版本-20180226180834.doc"> 证明申请版本的链接</a>
                     
                        <br /><br />
                        2、如申请开具的证明有其他规定版本，请上传版本作为附件。如无法上传，请将附件发<br />送至如下邮箱：zhuxq.gz@centaline.com.cn或致电83926681。
                        <div style="margin-top: 10px; margin-bottom: 5px">
                            <input type="button" id="btn2Upload" value="上传附件..." onclick="upload();" style="margin-left: 5px;" />
                            <asp:FileUpload ID="txtFilePath" runat="server" Width="275px" Visible="False" />　
                            <asp:Button ID="btnLoadPath" runat="server" Text="上 传" class="btn button" OnClick="btnLoadPath_Click" Visible="False" />
                            <input type="button" id="btnDownSPath" value="下载申请样本" onclick="window.open('../../资料/手写申请模板.xlsx');" style="margin-left: 10px; display: none;"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 10px; line-height: 20px;">
                        　<%--备注：1、各类证明截收时间为周二、周四早上11点。具体签收时间请以申请回复为准。--%>
                        备注： 1、各类证明截收时间为周一、周三、周五早上11点，并将于对应时间下午统一处理申请。
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">填写人：</td>
                    <td><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td class="auto-style4">填写日期：</td>
                    <td><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style4">部门主管</td>
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
				<tr id="trManager3">
					<td class="auto-style4">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>
<%--				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style4">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>--%>

				<tr class="noborder" style="height: 85px;">
					<td class="auto-style4">人力资源部</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5" style="color:#008162">已开具,请到总部找姚楚芳进行签收</label><br />
                        <input id="rdbYes1IDx5" type="radio" name="agree5" />
                        <label for="rdbYes1IDx5" style="color:#008162">已开具,请到总部找杨金桃进行签收</label><br />
                           <input id="rdbOtherIDx5" type="radio" name="agree5"  /><label for="rdbOtherIDx5">其他意见</label><br />
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">退回申请</label>
                     
						<textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
					</td>
				</tr>
<%--				<tr class="noborder" style="height: 85px;">
                    <td class="auto-style4">人力资源部</td>
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
				</tr>--%>
                <tr id="trCcess" class="noborder" style="height: 30px; display: none;">
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

