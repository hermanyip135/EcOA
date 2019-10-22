<%@ Page validateRequest="false" Title="员工个人利益申报表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_PersInterests_Detail.aspx.cs" Inherits="Apply_PersInterests_Apply_PersInterests_Detail" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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

        var jJSON = <%=sbJSON.ToString() %>;
        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        $(function() {      
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {}
            });

            $("#<%=txtFollowerDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {}
            });

            $("#<%=txtRelativeDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {}
            });

            $("#<%=txtApplyForDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
        });

        function check() {
            if($("#<%=ddlDepartmentType.ClientID%>").val() == "") {
                alert("部门性质必须选择。");
                $("#<%=ddlDepartmentType.ClientID%>").focus();
                return false;
            }
            else
                $("#<%=hdDepartmentType.ClientID%>").val($("#<%=ddlDepartmentType.ClientID%>").val());
            
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("部门名称（分行/组别）不可为空。");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApplyFor.ClientID %>").val())=="") {
                alert("申请人不可为空。");
                $("#<%=txtApplyForID.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtApplyForDate.ClientID %>").val())=="") {
                alert("申请日期不可为空。");
                $("#<%=txtApplyForDate.ClientID %>").focus();
                return false;
            }

            if($("#<%=ddlInterestsType.ClientID%>").val() == "") {
                alert("利益申报类别必须选择。");
                $("#<%=ddlInterestsType.ClientID%>").focus();
                return false;
            }
            else
                $("#<%=hdInterestsType.ClientID%>").val($("#<%=ddlInterestsType.ClientID%>").val());

            if($("#<%=ddlInterestsType.ClientID%>").val() == "1") {
                if($.trim($("#<%=txtFollower.ClientID %>").val())=="") {
                    alert("跟进人不可为空。");
                    $("#<%=txtFollowerID.ClientID %>").focus();
                    return false;
                }
            
                if($.trim($("#<%=txtFollowerDepartment.ClientID %>").val())=="") {
                        alert("跟进分行不可为空。");
                        $("#<%=txtFollowerDepartment.ClientID %>").focus();
                    return false;
                }

                if($.trim($("#<%=txtAddress.ClientID %>").val())=="") {
                        alert("房产地址不可为空。");
                        $("#<%=txtAddress.ClientID %>").focus();
                    return false;
                }

                var type="";
                $.each($(':radio'),function(i,m) {
                    if(m.checked) {
                        type = $(m).val();
                    }
                });

                if(type==''){
                    alert("请选择房屋性质。");
                    return false;
                }
            }
            else if($("#<%=ddlInterestsType.ClientID%>").val() == "4") {
                if($.trim($("#<%=txtRelative.ClientID %>").val())=="") {
                    alert("亲属姓名不可为空。");
                    $("#<%=txtRelative.ClientID %>").focus();
                    return false;
                }
    
                if($.trim($("#<%=txtRelativeDepartment.ClientID %>").val())=="") {
                    alert("所在部门不可为空。");
                    $("#<%=txtRelativeDepartment.ClientID %>").focus();
                        return false;
                }

                if($.trim($("#<%=txtRelativePosition.ClientID %>").val())=="") {
                    alert("担任职位不可为空。");
                    $("#<%=txtRelativePosition.ClientID %>").focus();
                        return false;
                }

                if($.trim($("#<%=txtRelativeRelation.ClientID %>").val())=="") {
                    alert("亲属关系不可为空。");
                    $("#<%=txtRelativeRelation.ClientID %>").focus();
                    return false;
                }
            }
           else {
                if($.trim($("#<%=txtApplyDetail.ClientID %>").val())=="") {
                    alert("申报内容不可为空。");
                    $("#<%=txtApplyDetail.ClientID %>").focus();
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
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?mainid=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
                    if(sReturnValue=='success')
                        window.location='Apply_PersInterests_Detail.aspx?mainid=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_PersInterests_Flow.aspx?mainid=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_PersInterests_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            if(idx=='1'||idx=='2'||idx=='3'||idx=='7'||idx=='8'||idx=='130'||idx=='131'){//789
            //if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
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
                alert("由于您不同意该申请，必须填写不同意的原因。")
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
            //    var temp = window.document.body.innerHTML;        
            //    var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
            //    window.document.body.innerHTML = printhtml;        
            //    window.print();        
            //    window.document.body.innerHTML = temp;    
            //}    
             //else { window.print(); }
             cMyPrint();
         }

         function saveRemark() {
            $.ajax({
                url: "/Ajax/Apply_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=savepersinterestsremark&id=<%=ID %>",
                success: function(info) {
                    if(info=='success')
                        alert('标记成功');
                    else
                        alert('标记失败');
                }
            })
         }

        function getEmployee(n) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtApplyForID.ClientID%>").val(infos[0]);
                        $("#<%=txtApplyFor.ClientID%>").val(infos[1]);
                        $("#<%=txtDepartment.ClientID%>").val(infos[2]);
                        $("#spanApplyFor").show();
                    }
                    else{
                        $("#<%=txtApplyFor.ClientID%>").val("");
                        $("#<%=txtDepartment.ClientID%>").val("");
                        $("#spanApplyFor").hide();
                    }
                }
            })
        }

        function getEmployee2(n) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtFollowerID.ClientID%>").val(infos[0]);
                        $("#<%=txtFollower.ClientID%>").val(infos[1]);
                        $("#<%=txtFollowerDepartment.ClientID%>").val(infos[2]);
                        $("#spanFollower").show();
                    }
                    else{
                        $("#<%=txtFollower.ClientID%>").val("");
                        $("#<%=txtFollowerDepartment.ClientID%>").val("");
                        $("#spanFollower").hide();
                    }
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
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+7,
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align:center; width:840px; margin:0px auto;'>
        <div class="noprint">
        <%=sbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align:center'>            
            <h1>广东中原地产代理有限公司</h1>
            <h1>员工个人利益申报表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td class="tl PL10" style="width:17%;">﹡部门性质</td>
                    <td class="tl PL10"><asp:DropDownList ID="ddlDepartmentType" runat="server" Width="194px"></asp:DropDownList><asp:HiddenField ID="hdDepartmentType" runat="server" /></td>
                    <td class="tl PL10" style="width:26%;">﹡部门名称（分行/组别）</td>
                    <td class="tl PL10"><input id="txtDepartment" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/></td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡申请人</td>
                    <td class="tl PL10">工号：<asp:TextBox ID="txtApplyForID" runat="server" Width="40px" onblur="getEmployee(this);"></asp:TextBox><span id="spanApplyFor" style="display:none;">&nbsp;&nbsp;&nbsp;&nbsp;姓名：<input id="txtApplyFor" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span></td>
                    <td class="tl PL10">﹡申请日期</td>
                    <td class="tl PL10"><asp:TextBox ID="txtApplyForDate" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡利益申报类别</td>
                    <td class="tl PL10"><asp:DropDownList ID="ddlInterestsType" runat="server" Width="194px"></asp:DropDownList><asp:HiddenField ID="hdInterestsType" runat="server" /></td>
                    <td class="tl PL10" style="background-color:#e3e3e3;">文档编码(自动生成)</td>
                    <td class="tl PL10" style="background-color:#e3e3e3;"><%=SerialNumber %></td>
                </tr>
                <tr>
                    <td class="tl PL10" rowspan="4">﹡申报内容：</td>
                </tr>
                <tr>
                    <td colspan="3" class="tl PL10">
                        买卖公司代理房产 请填写<br />
                        跟&nbsp;&nbsp;进&nbsp;&nbsp;人：工号：<asp:TextBox ID="txtFollowerID" runat="server" Width="40px" onblur="getEmployee2(this);"></asp:TextBox><span id="spanFollower" style="display:none;">&nbsp;&nbsp;&nbsp;&nbsp;姓名：<input id="txtFollower" type="text" runat="server" readonly="readonly" style="background-color:Silver; width:50px;"/></span>（促成房产交易的同事姓名）<br />
                        跟进分行：<input id="txtFollowerDepartment" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/>（促成房产交易的同事所在分行）<br />
                        房产地址：<asp:TextBox ID="txtAddress" runat="server" Width="350px"></asp:TextBox><asp:RadioButton ID="rdbType1" runat="server" GroupName="type" Text="买卖" value="1" /><asp:RadioButton ID="rdbType2" runat="server" GroupName="type" Text="租赁" value="2"  /><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="tl PL10">
                        亲属关系 请填写<br />
                        亲属姓名：<asp:TextBox ID="txtRelative" runat="server"></asp:TextBox>&nbsp;&nbsp;所在部门：<asp:TextBox ID="txtRelativeDepartment" runat="server"></asp:TextBox><br />
                        担任职位：<asp:TextBox ID="txtRelativePosition" runat="server"></asp:TextBox>&nbsp;&nbsp;亲属关系：<asp:TextBox ID="txtRelativeRelation" runat="server"></asp:TextBox><br />
                        注：根据公司规定直系亲属不能入职同一部门/分行，如部门确需申请有直系关系的两名人员入职同一分行，请部门主管及负责人于签批栏列明详细原因。
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="tl PL10">
                        非上述两种情况请在下列横线上注明申报内容<br />
                        <asp:TextBox ID="txtApplyDetail" runat="server" TextMode="MultiLine" Rows="3" Width="98%" style="overflow-y:auto;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">填写人</td>
                    <td class="tl PL10"><asp:Label ID="lblApplicant" runat="server"></asp:Label></td>
                    <td class="tl PL10">填写日期</td>
                    <td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr  id="trManager1" class="noborder" style="height:30px;">
                    <td>部门主管</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div></td>
                </tr>
                <tr  id="trManager2" class="noborder" style="height:30px;">
                    <td>隶属主管</td>
                    <td colspan="3" class="tl PL10" >
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div></td>
                </tr>
                <tr  id="trManager3" class="noborder" style="height:30px;">
                    <td>部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height:30px;">
                    <td rowspan="3" >人力资源部意见</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
                        <textarea id="txtIDx4" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
                    </td>                            
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>       
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="3" style="width:98%; overflow:auto;" cols="20" name="S1"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
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
                <tr id="trLogistics" class="noborder" style="height:30px; display:none; ">
                    <td >后勤事务部意见<br /><asp:Button ID="btnWillEnd2" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx7" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
                    </td>       
                </tr>	
                <tr id="trGeneralManager" class="noborder" style="height:30px; display:none; ">
                    <td >董事总经理审批</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><br />
                        <textarea id="txtIDx8" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
                    </td>       
                </tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                    <td >后勤事务部意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><br />
						<textarea id="txtIDx130" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><br />
						<textarea id="txtIDx131" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
					</td>
				</tr>
            </table>
            <!--打印正文结束-->
        </div>

        <div class="noprint">
        <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" BackColor="White" style="clear:both; margin-top:3px;"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="false"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="gvAttach_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:ImageButton ID="iBtnDelete" runat="server"  ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID") %>' OnClientClick="return confirm('确认删除？');" />
                        <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
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
        </asp:GridView>
        <div id="PageBottom">
        <hr />
        <asp:Button ID="btnReWrite" runat="server" OnClick="btnReWrite_Click" text="重新导入" Visible="False" />
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left:5px; display:none;" />
        <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" onclick="btnDownload_Click" OnClientClick="return checkChecked();" style="margin-left:5px;" Visible="false" />
        <input type="button" id="btnSignSave" value="标注已留档" onclick="saveRemark();" style="display:none;" />
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display:none;" />
        <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click"/>
        <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" style="display:none;" />
        <asp:HiddenField ID="hdIsAgree" runat="server" />
        <asp:HiddenField ID="hdSuggestion" runat="server" />
        <input type="hidden" id="hdDetail" runat="server" />
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
    </div>
    <%=sbJS.ToString() %>
</asp:Content>

