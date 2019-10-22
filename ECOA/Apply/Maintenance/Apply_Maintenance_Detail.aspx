<%@ Page ValidateRequest="false" Title="大额维修申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Maintenance_Detail.aspx.cs" Inherits="Apply_Maintenance_Apply_Maintenance_Detail" %>

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
                .mouseup(function () { $(this).css("display", "none"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); });

			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {}
			});
		    $("#<%=txtReceiveDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {}
		    });
		    $("#<%=txtCCDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {}
		    });

		    $("#<%=txtStartDate.ClientID%>").blur(function () {
		        //var da = new Date().getFullYear() - new Date($("#<%=txtStartDate.ClientID%>").val().replace(/\-/g, "\/")).getFullYear();
		        var da = new Date().getFullYear() - $("#<%=txtStartDate.ClientID%>").val();
		        $("#<%=txtCycle.ClientID %>").val(da);
		        $("#<%=txtStartDateMonth.ClientID%>").blur();
		        $("#<%=hdCycle.ClientID%>").val(da);
		    });
		    $("#<%=txtStartDateMonth.ClientID%>").blur(function () {
		        //var dy = new Date().getFullYear() - new Date($("#<%=txtStartDate.ClientID%>").val().replace(/\-/g, "\/")).getFullYear();
		        var dy = new Date().getFullYear() - $("#<%=txtStartDate.ClientID%>").val();
		        var da = new Date().getMonth() + 1 - $("#<%=txtStartDateMonth.ClientID %>").val();
		        if(da >= 0){
		            $("#<%=txtCycleMonth.ClientID %>").val(da);
		            $("#<%=txtCycle.ClientID %>").val(dy);
		            $("#<%=hdCycle.ClientID%>").val(dy);
		            $("#<%=hdCycleMonth.ClientID%>").val(da);
		        }
		        else{
		            $("#<%=txtCycle.ClientID %>").val(dy - 1);
		            $("#<%=txtCycleMonth.ClientID %>").val(12 - Math.abs(da));
		            $("#<%=hdCycle.ClientID%>").val(dy - 1);
		            $("#<%=hdCycleMonth.ClientID%>").val(12 - Math.abs(da));
		        }
		    });

		    $("#<%=txtDueToDate.ClientID%>").datepicker();
		    $("#<%=txtRenovationDate.ClientID%>").datepicker();
		    $("#<%=txtResultsBeginDate.ClientID%>").datepicker();
		    $("#<%=txtResultsEndDate.ClientID%>").datepicker();
		    $("#<%=txtProfitBeginDate.ClientID%>").datepicker();
		    $("#<%=txtProfitEndDate.ClientID%>").datepicker();
		    //$("#<%=txtLeaseDate.ClientID%>").datepicker();
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

        function check() {
            try{
                for(var e in nicEditors.editors) {  
                    nicEditors.editors[e].nicInstances[0].saveContent();
                }  
            }catch(ee)
            {
                //alert("保存时遇到了未知错误，请刷新后重试！");
                //return false;
            }
            if($.trim($("#<%=txtCycle.ClientID %>").val()) == "NaN"){
                alert("输入的年份格式不正确！");
                $("#<%=txtStartDate.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtCycleMonth.ClientID %>").val()) == "NaN"){
                alert("输入的月份格式不正确！");
                $("#<%=txtStartDateMonth.ClientID %>").focus();
                return false;
            }
            if($("#<%=txtStartDateMonth.ClientID %>").val()*1 < 1 || $("#<%=txtStartDateMonth.ClientID %>").val()*1 > 12){
                alert("请输入正确的月份！");
                $("#<%=txtStartDateMonth.ClientID %>").focus();
                return false;
            }
            if (isNaN($("#<%=txtStartDate.ClientID%>").val())) {
                alert("年份必须输入纯数字");
                $("#<%=txtStartDate.ClientID%>").focus();
                return false;
            }
            if (isNaN($("#<%=txtStartDateMonth.ClientID%>").val())) {
                alert("月份必须输入纯数字");
                $("#<%=txtStartDateMonth.ClientID%>").focus();
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

	        if($.trim($("#<%=txtReceiveDepartment.ClientID %>").val())=="") {
	            alert("收文部门不可为空！");
	            $("#<%=txtReceiveDepartment.ClientID %>").focus();
	            return false;
            }
            
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

            if($.trim($("#<%=txtStartDate.ClientID %>").val())=="") {
                alert("分行开业时间不可为空！");
                $("#<%=txtStartDate.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtCycle.ClientID %>").val())=="") {
                alert("分行开铺周期不可为空！");
                $("#<%=txtCycle.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtDepreciationB.ClientID %>").val())=="") {
                alert("装修折旧余额不可为空！");
                $("#<%=txtDepreciationB.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtDContent.ClientID %>").val())=="") {
                alert("装修折旧内容不可为空！");
                $("#<%=txtDContent.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtDueToDate.ClientID %>").val())=="") {
                alert("装修折旧到期日不可为空！");
                $("#<%=txtDueToDate.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtRenovationDate.ClientID %>").val())=="") {
                alert("最近翻新时间不可为空！");
                $("#<%=txtRenovationDate.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtRContent.ClientID %>").val())=="") {
                alert("最近翻新内容不可为空！");
                $("#<%=txtRContent.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtRprice.ClientID %>").val())=="") {
                alert("最近翻新金额不可为空！");
                $("#<%=txtRprice.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtResultsCoast.ClientID %>").val())=="") {
                alert("业绩数据金额不可为空！");
                $("#<%=txtResultsCoast.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtProfitCoast.ClientID %>").val())=="") {
                alert("盈利数据金额不可为空！");
                $("#<%=txtProfitCoast.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtResultsBeginDate.ClientID %>").val())=="") {
                alert("业绩数据开始时间不可为空！");
                $("#<%=txtResultsBeginDate.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtResultsEndDate.ClientID %>").val())=="") {
                alert("业绩数据结束时间不可为空！");
                $("#<%=txtResultsEndDate.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtProfitBeginDate.ClientID %>").val())=="") {
                alert("盈利数据开始时间不可为空！");
                $("#<%=txtProfitBeginDate.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtProfitEndDate.ClientID %>").val())=="") {
                alert("盈利数据结束时间不可为空！");
                $("#<%=txtProfitEndDate.ClientID %>").focus();
	            return false;
            }
            if($.trim($("#<%=txtLeaseDate.ClientID %>").val())=="") {
                alert("租约到期日不可为空！");
                $("#<%=txtLeaseDate.ClientID %>").focus();
	            return false;
            }
            if(!$("#<%=rdbIsLease1.ClientID%>").prop("checked") && !$("#<%=rdbIsLease2.ClientID%>").prop("checked")){
                alert("请选择是否续租！");
                $("#<%=rdbIsLease1.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtDescribe.ClientID %>").val())=="") {
                alert("申请正文不可为空！");
	            $("#<%=txtDescribe.ClientID %>").focus();
	            return false;
            }
            else if($.trim($("#<%=txtDescribe.ClientID %>").val())=="<br>" || $.trim($("#<%=txtDescribe.ClientID %>").val())=="<BR>") {
                try{
                    for(var e in nicEditors.editors) {  
                        nicEditors.editors[e].nicInstances[0].saveContent();
                    }  
                }catch(ee)
                {
                }
                alert("正文内容保存不成功，请刷新后重试！");
                $("#<%=txtDescribe.ClientID %>").focus();
                return false;
            }
            else {
                $("#<%=HiddenField1.ClientID %>").val($("#<%=txtDescribe.ClientID %>").val());
            }
            return true;
	    }
        
        //暂时保存
        function tempsavecheck()
        {
            $("#<%=HiddenField1.ClientID %>").val($("#<%=txtDescribe.ClientID %>").val());
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
                    window.location='Apply_Maintenance_Detail.aspx?MainID=<%=MainID %>';
            }

            function editflow(){
                var win=window.showModalDialog("Apply_Maintenance_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
                if(win=='success')
                    window.location="Apply_Maintenance_Detail.aspx?MainID=<%=MainID %>";
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
                //if(idx=='1'||idx=='2'||idx=='3'||idx=='6'||idx=='7'||idx=='8'){//789
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

    <script src="/Script/NicEdit/nicEdit.js" type="text/javascript"></script>
    <script type="text/javascript">
        bkLib.onDomLoaded(function() {
            new nicEditor({
                buttonList : ['fontSize','bold','italic','underline','strikeThrough','left','center','right','justify','forecolor','bgcolor']
            }).panelInstance('<%=txtDescribe.ClientID %>',{hasPanel : true});
        });
    </script>

    <style type="text/css">
        .auto-style5 {
            width: 200px;
        }
        .auto-style6 {
            width: 180px;
        }
        .auto-style10 {
            width: 240px;
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
			<h1>大额维修申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
				<tr>
					<td class="auto-style5">收文部门</td>
					<td class="tl PL10"><asp:TextBox ID="txtReceiveDepartment" runat="server" Width="200px"></asp:TextBox></td>
					<td class="auto-style6" >发文编号</td>
					<td class="tl PL10"><asp:TextBox ID="txtApplyID" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style5" >发文部门</td>
					<td class="tl PL10"><asp:TextBox ID="txtDepartment" runat="server" Width="200px"></asp:TextBox></td>
                    <td class="auto-style6">发文人员-日期</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label>&nbsp;- <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
                <tr>
                    <td class="auto-style5">抄送部门</td>
					<td class="tl PL10"><asp:TextBox ID="txtCCDepartment" runat="server" Width="200px"></asp:TextBox></td>
					<td class="auto-style6">回复电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtTelephone" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style5">文件主题</td>
					<td class="tl PL10"><asp:TextBox ID="txtSubject" runat="server" Width="200px"></asp:TextBox></td>
					<td class="auto-style6">回复传真</td>
					<td class="tl PL10"><asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <th colspan="4" style="line-height:25px;" >申请正文</th>
				</tr>
                <tr>
                    <td class="auto-style5">分行开业时间</td>
					<td class="tl PL10">
                        <asp:TextBox ID="txtStartDate" runat="server" Width="70px"></asp:TextBox>年
                        <asp:TextBox ID="txtStartDateMonth" runat="server" Width="70px"></asp:TextBox>月
					</td>
					<td class="auto-style6">分行开铺时长</td>
					<td class="tl PL10">
                        <asp:TextBox ID="txtCycle" runat="server" Width="70px" ReadOnly="True" BackColor="#E3E3E3"></asp:TextBox>年
                        <asp:TextBox ID="txtCycleMonth" runat="server" Width="70px" BackColor="#E3E3E3" ReadOnly="True"></asp:TextBox>月
					</td>
				</tr>
                <tr>
                    <td class="auto-style5">装修折旧余额</td>
					<td class="tl PL10"><asp:TextBox ID="txtDepreciationB" runat="server" Width="200px"></asp:TextBox></td>
					<td class="auto-style6">装修折旧内容</td>
					<td class="tl PL10"><asp:TextBox ID="txtDContent" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style5">装修折旧到期日</td>
					<td class="tl PL10"><asp:TextBox ID="txtDueToDate" runat="server" Width="200px"></asp:TextBox></td>
					<td class="auto-style6">最近翻新时间</td>
					<td class="tl PL10"><asp:TextBox ID="txtRenovationDate" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style5">最近翻新内容</td>
					<td class="tl PL10"><asp:TextBox ID="txtRContent" runat="server" Width="200px"></asp:TextBox></td>
					<td class="auto-style6">最近翻新金额</td>
					<td class="tl PL10"><asp:TextBox ID="txtRprice" runat="server" Width="200px"></asp:TextBox></td>
				</tr>
                <tr>
                    <td class="auto-style5">业绩数据<br />（近半年）</td>
					<td class="tl PL10">
                        <asp:TextBox ID="txtResultsBeginDate" runat="server" Width="90px"></asp:TextBox>～<asp:TextBox ID="txtResultsEndDate" runat="server" Width="90px"></asp:TextBox>
                        <br />金额：<asp:TextBox ID="txtResultsCoast" runat="server" Width="150px"></asp:TextBox>元
					</td>
					<td class="auto-style6">盈利数据<br />（近半年）</td>
					<td class="tl PL10">
                        <asp:TextBox ID="txtProfitBeginDate" runat="server" Width="90px"></asp:TextBox>～<asp:TextBox ID="txtProfitEndDate" runat="server" Width="90px"></asp:TextBox>
					    <br />金额：<asp:TextBox ID="txtProfitCoast" runat="server" Width="150px"></asp:TextBox>元
                    </td>
				</tr>
                <tr>
                    <td class="auto-style5">租约到期日</td>
					<td class="tl PL10"><asp:TextBox ID="txtLeaseDate" runat="server" Width="200px"></asp:TextBox></td>
					<td class="auto-style6">是否有续租计划</td>
					<td class="tl PL10">
                        <asp:RadioButton ID="rdbIsLease1" runat="server" GroupName="IsLease" Text="是" />　
                        <asp:RadioButton ID="rdbIsLease2" runat="server" GroupName="IsLease" Text="否" />
					</td>
				</tr>
                <tr>
					<td colspan="4">
                        <div style="padding: 5px 5px 5px 10px; text-align: left; font-weight: bold;">原因详述：</div>
                        <div style="text-align: left; width: 643px">
                            <asp:TextBox ID="txtDescribe" runat="server" Style="height: 300px" TextMode="MultiLine" Width="640px"></asp:TextBox>
                        </div>
					</td>
				</tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 10px;">
                        <div style="line-height: 25px;">
                            <span style="font-weight: bold">备注：</span><br />
                            1、“分行开铺时长”是分行从开业至今的累计时间，由系统自动统计，无需填写；<br />
                            2、“装修折旧余额”“装修折旧内容”“装修折旧到期日”可以从财务部同事源浩灵处查核；其中装修“装修折旧内容”是指“装修折旧余额”指向的费用项目是什么；<br />
                            3、“最近翻新时间”“最近翻新内容”“最近翻新金额”可以从行政部同事黄洁莹处查核，为了了解分行最近一次的翻新距离本次申请时隔多长，翻新项目是否有重复，翻新资费等；<br />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th colspan="4" style="line-height:25px;" >申请部门审批流程</th>
				</tr>

                <tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style5">申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" style="width: 98%; overflow: auto;" rows="3"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style5">申请部门主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" style="width: 98%; overflow: auto;" rows="3"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style5">申请部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" style="width: 98%; overflow: auto;" rows="3"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>--%>
					</td>
				</tr>
                <tr id="trMs1" class="noborder" style="height: 85px;"> 
					<td rowspan="2" class="auto-style5" >行政部</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">确认</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" style="width: 98%; overflow: auto;" rows="3"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trMs2" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" style="width: 98%; overflow: auto;" rows="3"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>--%>
					</td>
				</tr>
                	<tr id="trCoo" class="noborder" style="height: 85px;">
					<td class="auto-style5">首席运营官</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label>
                        <input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><br />
						<textarea id="txtIDx10" style="width: 98%; overflow: auto;" rows="3"></textarea>
                        <input type="button" id="btnSignIDx10" value="签名" onclick="sign('10')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx10">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>--%>
					</td>
				</tr>
				
				<tr id="trMs3" class="noborder" style="height: 85px;"> 
					<td rowspan="2" class="auto-style5" >财务部</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx16" type="radio" name="agree16" /><label for="rdbYesIDx16">确认</label>
                        <input id="rdbNoIDx16" type="radio" name="agree16" /><label for="rdbNoIDx16">不同意</label>
                        　<asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton><br />
						<textarea id="txtIDx16" style="width: 98%; overflow: auto;" rows="3"></textarea>
                        <input type="button" id="btnSignIDx16" value="签署意见" onclick="sign('16')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx16">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trMs4" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx17" type="radio" name="agree17" /><label for="rdbYesIDx17">同意</label>
                        <input id="rdbNoIDx17" type="radio" name="agree17" /><label for="rdbNoIDx17">不同意</label><br />
						<textarea id="txtIDx17" style="width: 98%; overflow: auto;" rows="3"></textarea>
                        <input type="button" id="btnSignIDx17" value="签署意见" onclick="sign('17')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx17">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>--%>
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
                <%--<tr id="trLogistics" class="noborder" style="height: 85px;"> 
					<td rowspan="4" class="auto-style5" >后勤事务部<br />意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">确认</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">退回申请</label><br />
						<textarea id="txtIDx8" style="width: 98%; overflow: auto;" rows="3"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>--%>
                        <%--<div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>--%>
					<%--</td>
				</tr>--%>
				<tr id="trLogistics2" class="noborder" style="height: 85px;" >
                    <td rowspan="4" class="auto-style5" >后勤事务部意见<br />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td> 

					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx19" type="radio" name="agree19" /><label for="rdbYesIDx19">同意</label>
                        <input id="rdbNoIDx19" type="radio" name="agree19" /><label for="rdbNoIDx19">不同意</label>
                        <input id="rdbOtherIDx19" type="radio" name="agree19" /><label for="rdbOtherIDx19">其他意见</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
						<textarea id="txtIDx19" style="width: 98%; overflow: auto;" rows="3"></textarea>
                        <input type="button" id="btnSignIDx19" value="签署意见" onclick="sign('19')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx19">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>--%>
					</td>
				</tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><br />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx130">_________</span>
                        </span><%--<div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>--%>
					</td>
				</tr>
                <tr><td style="line-height: 0px" class="auto-style10"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px" class="auto-style5"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px;">
					<td class="auto-style5" >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx20" type="radio" name="agree20" /><label for="rdbYesIDx20">同意</label>
                        <input id="rdbNoIDx20" type="radio" name="agree20" /><label for="rdbNoIDx20">不同意</label>
                        <input id="rdbOtherIDx20" type="radio" name="agree20" /><label for="rdbOtherIDx20">其他意见</label><br />
						<textarea id="txtIDx20" style="width: 98%; overflow: auto;" rows="3"></textarea>
                        <input type="button" id="btnSignIDx20" value="签署意见" onclick="sign('20')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx20">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>--%>
					</td>
				</tr>
                 
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style5" >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" />
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
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
            <asp:hiddenfield id="hdCycle" runat="server" />
            <asp:hiddenfield id="hdCycleMonth" runat="server" />
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

