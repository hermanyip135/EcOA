<%@ Page ValidateRequest="false" Title="特殊上数申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_SpecialNumber_Detail.aspx.cs" Inherits="Apply_SpecialNumber_Apply_SpecialNumber_Detail" %>
<%@ Register src="../../Common/FlowShow.ascx" tagname="FlowShow" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <link href="../../Style/AddGroups.css" rel="stylesheet" />
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
        ///增加集团审批
        function AddGroups(idx)
        {
            if(confirm("确定要集团审核？"))
            {
                
                $.ajax({
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=SaveGroups&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&idx=' + idx,
                    success: function(info) {
                        if (info == "success") {
                            alert('已增加集团审批');
                            location=location ;
                        }
                        else if (info == "NoPower")
                            alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                        
                        }
                        else if("Existed" == info)
                        {
                            alert("已增加集团审批");
                        }
                        else
                            alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
  })
              
            }
           
        }
        function CancelGroups()
        {
            if(confirm("确定要取消集团审核？"))
            {
                $.ajax({
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=CancelGroups&mainid=<%=MainID %>',
                    success: function(info) {
                        if (info == "success") {
                            alert('已取消集团审批');
                            location=location ;
                        }
                        else if (info == "NoPower")
                            alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                        
                        }
                        else if("Existed" == info)
                        {
                            alert("已取消集团审批");
                        }
                        else
                            alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
                })
}
}
		var jJSON = <%=SbJson.ToString() %>;

		$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
	
		$(function() {      
            
		    $("#<%=txtDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {
		            $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});
		    for (var x = 1; x < i; x++) {
		        $("#txtDepartment"+ x).autocomplete({source: jJSON});
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

		     
		    $("label[for*=cbTheReason]").css("color", "black");
		    i = $("#tbDetail tr").length - 1;
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

	    function check() {
	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("资格证号码不可为空！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("部门/分行不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }
			
	        if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {
	            alert("回复电话不可为空！");
	            $("#<%=txtReplyPhone.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtSubject.ClientID %>").val())=="") {
	            alert("文件主题不可为空！");
	            $("#<%=txtSubject.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtFax.ClientID %>").val())=="") {
	            alert("回复传真不可为空！");
	            $("#<%=txtFax.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txtDescribe.ClientID %>").val())=="") {
	            alert("原因详述不可为空！");
	            $("#<%=txtDescribe.ClientID %>").focus();
	            return false;
	        }

	        if (!$("#<%=rdbDealNature1.ClientID%>").prop("checked") && !$("#<%=rdbDealNature2.ClientID%>").prop("checked") && !$("#<%=rdbDealNature3.ClientID%>").prop("checked")) {
	            alert("请选择交易性质");
	            $("#<%=rdbDealNature1.ClientID%>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txtNames.ClientID %>").val())=="") {
	            alert("项目名称/成交地址（二手散单）不可为空！");
	            $("#<%=txtNames.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txtPeriod.ClientID %>").val())=="") {
	            alert("项目代理期不可为空！");
	            $("#<%=txtPeriod.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txtApplyNo.ClientID %>").val())=="") {
	            alert("项目报备申请编号不可为空！");
	            $("#<%=txtApplyNo.ClientID %>").focus();
	            return false;
	        }
	        var cblItemLength = $("#<%=cblDealOfficeType.ClientID %> input").length;
	        var flag = false;
	        var typeValues = "";
	        for (var i = 0; i < cblItemLength; i++) {
	            if ($("#<%=cblDealOfficeType.ClientID %> input")[i].checked) {
                    flag = true;
                    typeValues += $("#<%=cblDealOfficeType.ClientID%> span")[i].tag + "|";
                }
            }

            if (!flag) {
                alert("请选择物业性质！");
                return false;
            }
            else
                $("#<%=hdDealOfficeType.ClientID%>").val(typeValues.substr(0, typeValues.length - 1));
	        if (!$("#<%=rdbAgentModel1.ClientID%>").prop("checked") && !$("#<%=rdbAgentModel2.ClientID%>").prop("checked")) {
	            alert("请选择代理模式");
	            $("#<%=rdbAgentModel1.ClientID%>").focus();
	            return false;
            }
	        if (
                    !$("#<%=cbTheReason1.ClientID %>").prop("checked") 
                    && !$("#<%=cbTheReason2.ClientID %>").prop("checked") 
                    && !$("#<%=cbTheReason3.ClientID %>").prop("checked")
                    && !$("#<%=cbTheReason4.ClientID %>").prop("checked")
                    && !$("#<%=cbTheReason5.ClientID %>").prop("checked")
                    && !$("#<%=cbTheReason6.ClientID %>").prop("checked")
                    && !$("#<%=cbTheReason7.ClientID %>").prop("checked")
                    && !$("#<%=cbTheReason8.ClientID %>").prop("checked")
                    && !$("#<%=cbTheReason9.ClientID %>").prop("checked")
               ) 
            {
	            alert("请选择欠缺的资料及申请特殊上数原因");
                $("#<%=cbTheReason1.ClientID%>").focus();
                return false;
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
				window.location='Apply_SpecialNumber_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
			var win=window.showModalDialog("Apply_SpecialNumber_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_SpecialNumber_Detail.aspx?MainID=<%=MainID %>";
		}
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
	    function sign(idx) {
	        //if(idx!='4'&&idx!='5'&&idx!='6'&&idx!='7'&&idx!='8'&&idx!='11'&&idx!='131'||idx=='10'){
	        //if(idx=='1'||idx=='2'||idx=='3'||idx=='9'){//789
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
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
        .auto-style2 {
            width: 85px;
        }
        .auto-style3 {
            width: 240px;
        }
        .auto-style4 {
            width: 105px;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<Span style="font-size:20px; font-weight:bold">特殊上数申请表</Span><label id="laIsGroups" runat="server" style="color:red; font-size:15px;"></label>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='640px'>
                <tr>
					<td class="auto-style2">收文部门</td>
					<td class="tl PL10">法律部</td>
					<td class="auto-style4">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
				</tr>
				<tr>
                    <td>发文部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="170px"></asp:TextBox>&nbsp;-&nbsp;<input type="hidden" id="hdDepartmentID" runat="server" /><asp:Label ID="lblApply" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
				<tr>
                    <td>抄送部门</td>
					<td class="tl PL10">财务部</td>
					<td class="auto-style4">回复电话</td>
					<td class="tl PL10"><asp:textbox id="txtReplyPhone" runat="server"></asp:textbox></td>
				</tr>
                <tr>
                    <td>文件主题</td>
                    <td class="auto-style3"><asp:textbox id="txtSubject" runat="server" Width="250px"></asp:textbox></td>
                    <td class="auto-style4">回复传真</td>
					<td class="tl PL10"><asp:textbox id="txtFax" runat="server"></asp:textbox></td>
                </tr>

                <tr>
                    <td>交易性质</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbDealNature1" runat="server" GroupName="DealNature" Text="物业部一手" />　
                        <asp:RadioButton ID="rdbDealNature2" runat="server" GroupName="DealNature" Text="二手批量" />　
                        <asp:RadioButton ID="rdbDealNature3" runat="server" GroupName="DealNature" Text="二手散单" />
                    </td>
                </tr>
                <tr>
                    <td>项目名称/成交地址（二手散单）</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:TextBox ID="txtNames" runat="server" Height="50px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>项目代理期</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPeriod" runat="server" Width="210px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">项目报备申请编号</td>
                    <td>
                        <asp:TextBox ID="txtApplyNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>物业性质</td>
                    <td class="tl PL10" colspan="3">
                        <asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                        <asp:TextBox ID="txtDealOfficeOther" runat="server"></asp:TextBox><asp:HiddenField ID="hdDealOfficeType" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>代理模式</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:RadioButton ID="rdbAgentModel1" runat="server" GroupName="AgentModel" Text="联合代理" />　
                        <asp:RadioButton ID="rdbAgentModel2" runat="server" GroupName="AgentModel" Text="独家代理" />
                    </td>
                </tr>
                <tr>
                    <td>欠缺的资料及申请特殊上数原因</td>
                    <td colspan="3" style="text-align: left; padding-left: 10px">
                        <asp:CheckBox ID="cbTheReason1" runat="server" Text="无合作确认函（即开工函）" /><br />
                        <asp:CheckBox ID="cbTheReason2" runat="server" Text="无代理合同" /><br />
                        <asp:CheckBox ID="cbTheReason3" runat="server" Text="无客户确认函" /><br />
                        <asp:CheckBox ID="cbTheReason4" runat="server" Text="过代理期成交" /><br />
                        <asp:CheckBox ID="cbTheReason5" runat="server" Text="大额成交无网签" /><br />
                        <asp:CheckBox ID="cbTheReason6" runat="server" Text="无产权文件" /><br />
                        <asp:CheckBox ID="cbTheReason7" runat="server" Text="与受托方签订代理合同无发展商委托原件" /><br />
                        <asp:CheckBox ID="cbTheReason9" runat="server" Text="无预售证" /><br />
                        <asp:CheckBox ID="cbTheReason8" runat="server" Text="其他" />
                    </td>
                </tr>

				<tr>
                    <td colspan="4">
                        <span style="vertical-align: top">原因详述</span>
                        <asp:textbox id="txtDescribe" runat="server" Width="550px" Height="300px" TextMode="MultiLine"></asp:textbox>
                 <asp:HiddenField id="hdGroupName" runat="server"/>
                           </td>
				</tr>
                
				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style2">申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label>
                        
                        <br />
						<textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display:none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style2">申请部门主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                     
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style2">申请部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>--%>
					</td>
				</tr>

				<tr id="trShowFlow4" class="noborder" style="height: 85px;">
					<td rowspan="2"  class="auto-style2">法律部门<br />主管意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" />
                        <label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <%--<div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>--%>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trShowFlow5" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/>
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
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
					<td rowspan="3"  class="auto-style2">财务部门<br />主管意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" />
                        <label for="rdbOtherIDx6">其他意见</label>
                        <asp:CheckBox ID="ckbAddIDx" runat="server" Text="增加审批环节"  Visible="false"/><br />
						<textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <%--<div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>--%>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
					</td>
				</tr>
                <tr id="trShowFlow7">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" value="1" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" value="2" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" value="3" />
                        <label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S4"></textarea>
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
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>--%>
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
					<td rowspan="4"  class="auto-style2">后勤事务部<br />审批<br />
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
				<%--	</td>
				</tr>--%>
			<%--	<tr id="trLogistics2" class="noborder" style="height: 85px;">
                    <td rowspan="3"  class="auto-style2">后勤事务部<br />审批<br />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>

					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label>
                        <input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
						<textarea id="txtIDx10" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx10">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
					</td>
				</tr>--%>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label>
                        <input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx130">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>--%>
					</td>
				</tr>
                <tr><td style="line-height: 0px" class="auto-style3"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>
				<tr id="trGeneralManager" class="noborder" style="height: 85px; ">
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
                   <tr id="trGeneralGroups" class="noborder" style="height: 85px; display:none">
					        <td >集团意见</td>
					        <td colspan="3" class="tl PL10" style=" ">
						        <input id="rdbYesIDx1000" type="radio" name="agree1000" /><label for="rdbYesIDx1000">同意</label><input id="rdbNoIDx1000"  type="radio" name="agree1000" /><label for="rdbNoIDx1000">不同意</label>
                                <input id="rdbOtherIDx1000" type="radio" name="agree1000" /><label for="rdbOtherIDx1000">其他意见</label><br />
						        <textarea id="txtIDx1000" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1000" value="签署意见" onclick="sign('1000')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                                    日期：<span id="spanDateIDx1000">_________</span>
                                </span>
					        </td>
				        </tr>
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label>
                        <input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<input id="rdbOtherIDx131" type="radio" name="agree131" />
                        <label for="rdbOtherIDx131">其他意见</label><br /><br />
                        <textarea id="txtIDx131" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx131">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>--%>
					</td>
				</tr>
                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx200">_________</span></div>
					</td>
				</tr>

                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理复审</td>
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
        <asp:button runat="server" id="btnTemp" text="暂时保存" onclick="btnTempSave_Click" CssClass="commonbtn" />
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
            <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        window.onload= function(){
            $("input[id*=btnSignIDx]").each(function () {
                var IsSigndisplay = $(this).css("display");
                if(IsSigndisplay != "undefined" && IsSigndisplay !='none')
                {
                    //var content =' <input name="btnAddGroups" type="button" class="cssAddGroups"    onclick="AddGroups(11)" />';
                    //$(this).prev().prev().prev().append(content);
                    var content =''
                    if($(this).parent().prev().text() == "集团意见")
                    {
                        content =' <input name="btnCancelGroups" type="button" class="cssCancelGroups"    onclick="CancelGroups()" />';
                    }
                    else
                    {
                        content =' <input name="btnAddGroups" type="button" class="cssAddGroups"    onclick="AddGroups(11)" />';
                      
                    }
                   
                    $(this).prev().prev().prev().append(content);
                }
            })
            $("input[id*=btnSignID]").each(function () {
                if($(this).parent().prev().text() == "集团意见")
                {
                    var GroupName = $("#<%=hdGroupName.ClientID%>").val();
                    content =' <label style="color:black">'+GroupName+'</label>';
                    $(this).prev().prev().prev().append(content);
                }
              })
        }
      
       
    </script>
     <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <%--<script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>--%>
</asp:Content>

