<%@ Page Title="(后勤/汇瀚/二级市场)IT权限申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_SysPower_Detail.aspx.cs" Inherits="Apply_SysPower_Apply_SysPower_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        input[type="text"]
        {
            width:140px;
        }
    </style>
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=sbJSON.ToString() %>;
        var jManagerJSON = <%=sbManagerJSON.ToString() %>;

        $(function() {
            $("#tbAround").find("td").find("label:contains('删除')").css("color", "#fe0200");
            $("#tbAround").find("td").find("label:contains('调动')").css("color", "#186ebe");
//            $("#li3").attr("class", "current");
            //            $("#li3_dd3").attr("class", "current");

            $("[id*=btnAssign]").css({
                "background-image": "url(/Images/btnAssign1.png)",
                "height": "25px", 
                "width": "46px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnAssign]").mousedown(function () { $(this).css("background-image", "url(/Images/btnAssign2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnAssign1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnAssign1.png)"); });

            $("[id*=btnSaveDeal]").css({
                "background-image": "url(/Images/btnSaveComd1.png)",
                "height": "25px", 
                "width": "110px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnSaveDeal]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSaveComd2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSaveComd1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSaveComd1.png)"); });
            
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
                
            $("#<%=txtDispatchDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {
                            $("#<%=hdDispatchDepartmentID.ClientID %>").val(ui.item.id);
                        }
            });

            $("#<%=txtApplyDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
            
            for (var x = 1; x <= i; x++) {
                $("#txtEffectiveDate" + x).datepicker({
                    showButtonPanel: true,
                    showOtherMonths: true,
                    selectOtherMonths: true,
                    changeMonth: true,
                    changeYear: true
                });

                $("#txtDepartment"+ x).autocomplete({ 
                    source: jJSON,
                    select: function( event, ui ) {
                                //alert(x);
                                //alert(ui.item.id);
                                $("#hdDepartmentID"+x).val(ui.item.id);
                                //alert($("#hdDepartmentID"+x).val());
                            }
                }); 
            }
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
        
        function addRow() {
            i++;
            var html = "<tr id='trDetail" + i +"'>"
                        + "     <td class=\"tl\">"
                        + "            工号：<input type=\"text\" id=\"txtCode" + i + "\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"getEmployee(this," + i + ");\"/>"
                        + "            姓名：<input type=\"text\" id=\"txtName" + i + "\"/><br />"
                        + "            部门：<input type=\"text\" id=\"txtDepartment" + i + "\"/><input type=\"hidden\" id=\"hdDepartmentID" + i + "\" />"
                        + "            职位：<input type=\"text\" id=\"txtPosition" + i + "\"/><br />"
                        + "            生效日期：<input type=\"text\" id=\"txtEffectiveDate" + i + "\"/>"
                        + "        </td>"
                        <%=sbJSHtml.ToString() %>
                        + "    </tr>";
            $("#tbDetail").append(html);

            $("#txtEffectiveDate"+i).datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
            
            $("#txtDepartment"+ i).autocomplete({ 
                    source: jJSON,
                    select: function( event, ui ) {
                        //alert(i);
                        //alert(ui.item.id);
                        $("#hdDepartmentID"+i).val(ui.item.id);
                        //alert($("#hdDepartmentID"+i).val());
                    }
            }); 
        }
              
        function deleteRow() {
            if(i>1) {
                $("#tbDetail tr:eq(" + i + ")").remove();
                i--;
            }
            else
                alert("不可删除第一行。")
        }
        
        function check() {
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("发文部门不可为空。请输入关键字，点选申请部门。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
                return false;
            }
            
            if(!checkdate($("#<%=txtApplyDate.ClientID %>").val())){
                alert("申请日期格式错误，请按以下格式输入日期:\n2013-07-22");
                $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApplicant.ClientID %>").val())=="") {
                alert("申请人不可为空。");
                $("#<%=txtApplicant.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
                alert("联系电话不可为空。");
                $("#<%=txtPhone.ClientID %>").focus();
                return false;
            }
              
            var data = "";
            var flag = true;
        
            //如果详细只有一行，且该行个人资料为空
            if($("#tbDetail tr").size() == 2 && $.trim($("#txtName1").val()) == "" && $.trim($("#txtCode1").val()) == "" && $.trim($("#txtDepartment1").val()) == "" && $.trim($("#txtPosition1").val()) == "" && $.trim($("#txtEffectiveDate1").val()) == "")
                data="||";
            else{
                $("#tbDetail tr").each(function(n) {
                    if (n != 0) {
                        if ($.trim($("#txtName" + n).val()) == "" || $.trim($("#txtCode" + n).val()) == "" || $.trim($("#txtDepartment" + n).val()) == "" || $.trim($("#txtPosition" + n).val()) == "" || $.trim($("#txtEffectiveDate" + n).val()) == "") {
                            if($.trim($("#txtEffectiveDate" + n).val()) != "")
                                alert("第" + n + "行的个人资料中的基本资料必须填写完整。");
                            else
                                alert("第" + n + "行的个人资料中的生效日期必须填写完整。");
                            
                            flag = false;
                        }
                        else {
                            if(!checkdate($("#txtEffectiveDate" + n).val())){
                                alert("第"+n+"行生效日期格式错误，请按以下格式输入日期:\n2013-08-08");
                                $("#txtEffectiveDate" + n).focus();
                                return false;
                            }
            
                            var sys = "";
                            var applytype="";
                            var ischecked = false;
                            
                            $("#trDetail"+n+" :checkbox").each(function(m) {
                                if(this.checked) {
                                    sys += $(this).val() + ";";
                                    ischecked = true;
                                }
                            });
                            
                            $("#trDetail"+n+" :radio").each(function(m) {
                                if(this.checked) {
                                    applytype = $(this).val();
                                }
                            });

                            if (ischecked) {
                                sys = sys.substr(0, sys.length - 1);

                                if(applytype==''){
                                    alert("请选择第" + n + "行的申请性质。");
                                    flag = false;
                                    return false;
                                }
                                    
                                data += $.trim($("#txtCode" + n).val()) + "&&" + $.trim($("#txtName" + n).val()) + "&&" + $.trim($("#txtDepartment" + n).val()) +"&&" + $.trim($("#hdDepartmentID" + n).val())
                                      + "&&" + $.trim($("#txtPosition" + n).val()) + "&&" + $.trim($("#txtEffectiveDate" + n).val()) + "&&" + sys + "&&" + applytype + "||";
                            }
                            else {
                                alert("请勾选第" + n + "行的申请内容。");
                                flag = false;
                                return false;
                            }
                        }
                    }
                });
            }

            if (flag) {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
                if(data=="")//如果个人资料为空，则判断申请原因是否为空，同时为空时不可保存。
                {
                    if ($.trim($("#<%=txtReqContent.ClientID %>").val()) == "") {
                        alert("请填写申请内容！");
                    }
                    else
                        return true;
                }
                else 
                    return true;
            }
            return false;
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
            //    alert("请确定是否同意！");
            //    return;
            //}
            
            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                alert("请确定是否同意！");
                return;
            }
			
            //if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
            //    alert("由于您不同意该申请，必须填写不同意的原因。");
            //    return;
            //}
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
        
        function getSuggestion(idx) {
            $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
        }

        function getEmployee(n, num) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#txtCode" + num).val(infos[0]);
                        $("#txtName" + num).val(infos[1]);
                        $("#txtDepartment" + num).val(infos[2]);
                        $("#hdDepartmentID" + num).val(infos[3]);
                        $("#txtPosition" + num).val(infos[4]);
                    }
                    else{
                        $("#txtName" + num).val("");
                        $("#txtDepartment" + num).val("");
                        $("#hdDepartmentID" + num).val("");
                        $("#txtPosition" + num).val("");
                    }
                }
            })
        }
        
        function checkdate(val) { 
             var datetype=/^[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}$/; 
            return datetype.exec(val);
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
        
        function editflow(){
            var win=window.showModalDialog("Apply_SysPower_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_SysPower_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_SysPower_Detail.aspx?MainID=<%=MainID %>';
        }
        
        function checkAll(n) {
            var gv = document.getElementById('<%=gvAttach.ClientID%>'); //获取GridView的客户端ID
            var input = gv.getElementsByTagName("input"); //获取GridView的Inputhtml

            if (n.checked) {
                for (var i = 0; i < input.length; i++) {
                    if (input[i].type == 'checkbox' && input[i].disabled != true)
                        input[i].checked = true;
                }
            }
            else {
                for (var i = 0; i < input.length; i++) {
                    if (input[i].type == 'checkbox' && input[i].disabled != true)
                        input[i].checked = false;
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
        
        function checkAssign() {
            if($.trim($("#<%=ddlFollower.ClientID %>").val())=="") {
                alert("请先选择下派的跟进人！");
                return false;
            }
              
            return true;
        }
        
        function savedeal(index) {
            var deal = $("#<%=txtDeal.ClientID %>").val();
            if (typeof(index) == 'undefined' && $.trim(deal) == "") 
                alert("请填写处理情况！");
            else{
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: "action=savesyspowerdeal&syspowerid=<%=ID %>&deal=" + deal,
                    success: function(info) {
                        if (typeof(index) == 'undefined') {
                            if (info == "success") 
                                alert("保存成功！");
                            else 
                                alert("保存失败");
                        }
                        else
                            sign(index);
                    }
                })
            }
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style='text-align:center; width:640px; margin:0px auto;'>
        <div class="noprint">
        <%=sbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align:center'>            
            <h1>广东中原地产代理有限公司</h1>
            <h1>(后勤/汇瀚/二级市场)IT权限申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td width="20%">收文部门</td>
                    <td colspan="6">资讯科技部</td>
                </tr>
                <tr>
                    <td width="20%">发文部门</td>
                    <td width="30%" colspan="2"><asp:TextBox ID="txtDispatchDepartment" runat="server" Width="96%"></asp:TextBox><asp:HiddenField ID="hdDispatchDepartmentID" runat="server" /></td>
                    <td width="20%">申请时间</td>
                    <td width="30%" colspan="3"><asp:TextBox ID="txtApplyDate" runat="server" Width="96%"></asp:TextBox></td>
                </tr>	
                <tr>
                    <td>申请人</td>
                    <td colspan="2"><asp:TextBox ID="txtApplicant" runat="server" Width="96%"></asp:TextBox></td>
                    <td>联系电话</td>
                    <td colspan="3"><asp:TextBox ID="txtPhone" runat="server" Width="96%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan='7' >
                        <table id="tbDetail" class='inside' width='100%'>
                            <thead>
                                <tr>
                                    <th width='60%'>个人资料</th>
                                    <th width='30%'>申请内容</th>
                                    <th width='10%'>申请性质</th>
                                </tr>
                            </thead>
                            <%=sbHtml.ToString()%>
                        </table>
                        <input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
                        <input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
                    </td>
                </tr>		
                <tr style="height:200px; ">
                    <td colspan="7"><div style="float:left; margin-left:11px;">申请内容：</div><asp:TextBox ID="txtReqContent" runat="server" Width="98%" Height="98%" Rows="10" TextMode="MultiLine" style="overflow:auto;"></asp:TextBox></td>
                </tr>                
                <tr class="noborder" style="height:30px; ">
                    <td colspan="1">主管</td>
                    <td colspan="6" class="tl PL10">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label>
                        <input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">其他意见</label><br />
                        <textarea id="txtIDx1" rows="2" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div></td>
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td colspan="1">区经/总监</td>
                    <td colspan="6" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label>
                        <input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
                        <textarea id="txtIDx2" rows="2" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div></td>
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td colspan="1">负责人</td>
                    <td colspan="6" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                        <input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label><br />
                        <textarea id="txtIDx3" rows="2" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div></td>
                </tr>
                <tr style="height:50px; vertical-align: bottom;">
                    <td colspan="7">以下是资讯科技部内部使用</td>
                </tr>	
                <tr>
                    <td colspan="1">文档编码(自动生成)</td>
                    <td colspan="6"><%=SerialNumber %></td>
                </tr>	
                <tr style="height:30px; ">
                    <td rowspan="3">资讯科技部处理情况</td>
                    <td colspan="6" class="tl PL10">
                        <div id="divTransmit" style="text-align:left;display:none;">
                            <asp:CheckBox ID="cbkSetComputer" runat="server" Text="Set电脑、装软件" style="margin-right:10px;" />
                            <asp:CheckBox ID="cbkEFax" runat="server" Text="电子传真" style="margin-right:10px;" />
                            <asp:CheckBox ID="cbkInerWeb" runat="server" Text="内部网" style="margin-right:10px;" />
                            <asp:CheckBox ID="cbkAssetManageSystem" runat="server" Text="资产管理系统" style="margin-right:10px;" />
                        </div>
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">完成</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
                        <textarea id="txtIDx4" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx4" value="签署处理情况" onclick="sign('4')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
                    </td>       
                 </tr>	
                <tr>
                <td colspan="6" class="tl PL10">
                        <div id="divAssign" style="text-align:left;display:none;">
                            转<asp:DropDownList ID="ddlFollower" runat="server"></asp:DropDownList>跟进<asp:Button runat="server" ID="btnAssign" Text="下派" OnClick="btnAssign_Click" OnClientClick="return checkAssign();" Visible="false" />                    
                        </div>
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">完成</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <asp:TextBox ID="txtDeal" runat="server" TextMode="MultiLine" Rows="3" style="overflow:auto; width:98%; "></asp:TextBox><br />
                        <input type="button" id="btnSaveDeal" value="保存处理情况" style="display:none;" onclick="savedeal();" />
                        <textarea id="txtIDx5" rows="2" style="width:98%; overflow:auto; display:none;"></textarea><input type="button" id="btnSignIDx5" value="签署处理情况" onclick="savedeal('5')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>	
                <tr>
                    <td colspan="6" class="tl PL10">
                        <div style="display:none;"><input id="rdbYesIDx6" type="radio" name="agree6" checked="checked" /><label for="rdbYesIDx6">完成</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                            <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        </div>
                        <textarea id="txtIDx6" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx6" value="签署处理情况" onclick="sign('6')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
                    </td>
                </tr>

                <tr id="trLogistics1" class="noborder" style="height: 85px; display: none;"> 
					<td rowspan="2" >后勤事务部<br /></td>                                                                                                           
					<td colspan="6" class="tl PL10" style=" ">
						<input id="rdbYesIDx53" type="radio" name="agree53" /><label for="rdbYesIDx53">确认</label><input id="rdbNoIDx53" type="radio" name="agree53" /><label for="rdbNoIDx53">退回申请</label><br />
						<textarea id="txtIDx53" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx53" value="签署意见" onclick="sign('53')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx53">_________</span></div>
					</td>
				 </tr>
				<tr id="trLogistics2" class="noborder" style="height: 85px; display: none;">
					<td colspan="6" class="tl PL10" style=" ">
						<input id="rdbYesIDx54" type="radio" name="agree54" /><label for="rdbYesIDx54">同意</label><input id="rdbNoIDx54" type="radio" name="agree54" /><label for="rdbNoIDx54">不同意</label><input id="rdbOtherIDx54" type="radio" name="agree54" value="1" /><label for="rdbOtherIDx54">其他意见</label><br />
						<textarea id="txtIDx54" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx54" value="签署意见" onclick="sign('54')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx54">_________</span></div>
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
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left:5px; display:none;" />
        <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" onclick="btnDownload_Click" OnClientClick="return checkChecked();" style="margin-left:5px;" Visible="false" />
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display:none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <%--<input type="button" id="btnGoBack" value="返回" onclick="window.history.go(-1);" />--%>
        <%--<input type="button" id="btnGoBack" value="返回" onclick="window.location='/Apply/Apply_Search.aspx';" />--%>
        <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click"/>
        <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" style="display:none;" />
        <asp:HiddenField ID="hdIsAgree" runat="server" />
        <asp:HiddenField ID="hdSuggestion" runat="server" />
        <input type="hidden" id="hdDetail" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=sbJS.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

