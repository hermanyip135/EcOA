<%@ Page Title="(物业部/工商铺)IT权限申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ITPower_Detail.aspx.cs" Inherits="Apply_ITPower_Apply_ITPower_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        td
        {
            border:0px;
            padding:0;
        }
        
    </style>
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=sbJSON.ToString() %>;
    
        $(function() {
        
            if($("#chkSys13").is(":checked"))
            {
                $(".cphone1").show();
            }
            else
            {
                $(".cphone1").hide();
            }
            $("#tbAround").find("td").find("label:contains('删除')").css("color", "#fe0200");
            $("#tbAround").find("td").find("label:contains('调动')").css("color", "#186ebe");
//            $("#li3").attr("class", "current");
//            $("#li3_dd1").attr("class", "current");
            
            i = $("#tbDetail tr").length - 1;
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
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
                
                $("#txtOutDepartment"+ x).autocomplete({ 
                    source: jJSON,
                    select: function( event, ui ) {
                                //alert(x);
                                //alert(ui.item.id);
                                $("#hdOutDepartmentID"+x).val(ui.item.id);
                                //alert($("#hdOutDepartmentID"+x).val());
                            }
                }); 
                $("#txtInDepartment"+ x).autocomplete({ 
                    source: jJSON,
                    select: function( event, ui ) {
                                //alert(x);
                                //alert(ui.item.id);
                                $("#hdInDepartmentID"+x).val(ui.item.id);
                                //alert($("#hdInDepartmentID"+x).val());
                            }
                });
            }

            $("#<%=txtApplicationDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });

            $("#<%=txtApplicationDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {
                            $("#<%=hdApplicationDepartmentID.ClientID %>").val(ui.item.id);
                        }
            }); 
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
        
        function addRow() {
            i++;
            if(i>10)
            {
                alert('只能添加十行');
                return false;
            }
            var html = "<tr>"
                        + "     <td class=\"tl\">"
                        + "            工&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：<input type=\"text\" class='itinput' id=\"txtCode" + i + "\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"getEmployee(this," + i + ");\"/><br />"
                        + "            姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：<input type=\"text\" class='itinput' id=\"txtName" + i + "\"/><br />"
                        + "            部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门：<input type=\"text\" class='itinput' id=\"txtDepartment" + i + "\"/><input type=\"hidden\" id=\"hdDepartmentID" + i + "\" /><br />"
                        + "            职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位：<input type=\"text\" class='itinput' id=\"txtPosition" + i + "\"/><br />"
                        + "            生效日期：<input type=\"text\" class='itinput' id=\"txtEffectiveDate" + i + "\"/><br/>"
                        + "            <span class=\"cphone" + i + "\">A  +  主 号：<input type=\"text\" class='itinput' id= \"txtANumber" +i +"\"/></span>"
                        + "        </td>"
                        //+ "        <td class=\"tl\">"
                        ////+ "            <input id='chkSys" + i + "1' type=\"checkbox\" value=\"1\"/><label for='chkSys" + i + "1'>中原邮箱</label>"
                        //+ "            <input id='chkSys" + i + "2' type=\"checkbox\" value=\"2\"/><label for='chkSys" + i + "2'>内部网</label><br />"
                        //+ "            <input id='chkSys" + i + "3' type=\"checkbox\" value=\"3\"/><label for='chkSys" + i + "3'>三级市场系统</label><br />"
                        //+ "            <input id='chkSys" + i + "4' type=\"checkbox\" value=\"4\"/><label for='chkSys" + i + "4'>电子传真系统</label><br />"
                        //+ "            <input id='chkSys" + i + "5' type=\"checkbox\" value=\"5\"/><label for='chkSys" + i + "5'>佣金系统(二手)</label><br />"
                        //+ "            <input id='chkSys" + i + "6' type=\"checkbox\" value=\"6\"/><label for='chkSys" + i + "6'>内部MSN</label><br />"
                        //+ "            <input id='chkSys" + i + "7' type=\"checkbox\" value=\"7\"/><label for='chkSys" + i + "7'>资产管理系统</label>"
                        //+ "        </td>"
                        //+ "        <td>"
                        //+ "            <input type=\"radio\" id='rdoApplyType" + i + "1' name='ApplyType" + i + "' checked=\"true\" value=\"1\" /><label for='rdoApplyType" + i + "1'>新增</label><br />"
                        //+ "            <input type=\"radio\" id='rdoApplyType" + i + "2' name='ApplyType" + i + "' value=\"2\" /><label for='rdoApplyType" + i + "2'>删除</label><br />"
                        //+ "            <input type=\"radio\" id='rdoApplyType" + i + "3' name='ApplyType" + i + "' value=\"3\" /><label for='rdoApplyType" + i + "3'>调动</label>"
                        //+ "        </td>"
                        <%=sbJSHtml.ToString() %>
                        + "        <td class=\"tl\">"
                        + "            (离职或调职时必须填写)<br />"
                        + "            客源转移至：<input type=\"text\" id=\"txtCustomerTo" + i + "\"/><br />"
                        + "            房源转移至：<input type=\"text\" id=\"txtPropertyTo" + i + "\"/><br />"
                        + "            调 出 部 门 ：<input type=\"text\" id=\"txtOutDepartment" + i + "\"/><input type=\"hidden\" id=\"hdOutDepartmentID" + i + "\" /><br />"
                        + "            调 入 部 门 ：<input type=\"text\" id=\"txtInDepartment" + i + "\"/><input type=\"hidden\" id=\"hdInDepartmentID" + i + "\" />"
                        + "        </td>"
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
            
            $("#txtOutDepartment"+ i).autocomplete({ 
                    source: jJSON,
                    select: function( event, ui ) {
                                //alert(i);
                                //alert(ui.item.id);
                                $("#hdOutDepartmentID"+i).val(ui.item.id);
                                //alert($("#hdOutDepartmentID"+i).val());
                            }
            }); 
            
            $("#txtInDepartment"+ i).autocomplete({ 
                source: jJSON,
                change: function( event, ui ) {
                            //alert(i);
                            //alert(ui.item.id);
                            $("#hdInDepartmentID"+i).val(ui.item.id);
                            //alert($("#hdInDepartmentID"+i).val());
                        }
            });
            $('.cphone' + i).hide();
        }
              
        function deleteRow()
        {
            if(i>1)
            {
                $("#tbDetail tr:eq(" + i + ")").remove();
                i--;
            }
            else
                alert("不可删除第一行。")
        }
                    
        function check() {
            if($.trim($("#<%=txtApplicationDepartment.ClientID %>").val())=="") {
                alert("申请部门不可为空。请输入关键字，点选申请部门。");
                $("#<%=txtApplicationDepartment.ClientID %>").focus();
                return false;
            }
            
            if(!checkdate($("#<%=txtApplicationDate.ClientID %>").val())){
                alert("申请日期格式错误，请按以下格式输入日期:\n2013-08-08");
                $("#<%=txtApplicationDate.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApplicant.ClientID %>").val())=="") {
                alert("申请人不可为空。");
                $("#<%=txtApplicant.ClientID %>").focus();
                return false;
            }
            if($("#chkSys13").is(":checked"))
            {
                if($.trim($("#txtANumber1").val()) == "")
                {
                    alert("请填写A+主号");
                    $("#txtANumber1").focus();
                    return false;
                }
            }
            var data = "";
            var flag = true;
        
            //如果详细只有一行，且该行个人资料为空
            if($("#tbDetail tr").size() == 2 && $.trim($("#txtName1").val()) == "" && $.trim($("#txtCode1").val()) == "" && $.trim($("#txtDepartment1").val()) == "" && $.trim($("#txtPosition1").val()) == "" && $.trim($("#txtEffectiveDate1").val()) == "")
                data="||";
            else{
                $("#tbDetail tr").each(function(n) {
                    if (n != 0) {
                        if($("#chkSys"+n+"3").is(":checked"))
                        {
                            if($.trim($("#txtANumber"+n).val()) == "")
                            {
                                alert("第" + n + "行的个人资料中的A+主号必须填写。");
                                flag = false;
                                return false;
                            }
                        }
                        if ($.trim($("#txtName" + n).val()) == "" || $.trim($("#txtCode" + n).val()) == "" || $.trim($("#txtDepartment" + n).val()) == "" || $.trim($("#txtPosition" + n).val()) == "" || $.trim($("#txtEffectiveDate" + n).val()) == "") {
                            if($.trim($("#txtEffectiveDate" + n).val()) != "")
                                alert("第" + n + "行的个人资料中的基本资料必须填写完整。");
                            else
                                alert("第" + n + "行的个人资料中的生效日期必须填写完整。");
                            
                            flag = false;
                            return false;
                        }
                        else {
                            if(!checkdate($("#txtEffectiveDate" + n).val())){
                                alert("第"+n+"行生效日期格式错误，请按以下格式输入日期:\n2013-08-08");
                                $("#txtEffectiveDate" + n).focus();
                                return false;
                            }
            
                            var sys = "";
                            var ischecked = false;

                            for (var m = 1; m <= <%=typeCount.ToString()%>; m++) {
                                if (document.getElementById("chkSys" + n + m).checked) {
                                    sys += $("#chkSys" + n + m).val() + ";";
                                    ischecked = true;
                                }
                            }

                            if (ischecked) {
                                sys = sys.substr(0, sys.length - 1);

                                var type = document.getElementById("rdoApplyType" + n + "1").checked ? $("#rdoApplyType" + n + "1").val() : (document.getElementById("rdoApplyType" + n + "2").checked ? $("#rdoApplyType" + n + "2").val() : $("#rdoApplyType" + n + "3").val());
                                data += $.trim($("#txtCode" + n).val()) + "&&" + $.trim($("#txtName" + n).val()) + "&&" + $.trim($("#txtDepartment" + n).val()) +"&&" + $.trim($("#hdDepartmentID" + n).val())
                                      + "&&" + $.trim($("#txtPosition" + n).val()) + "&&" + $.trim($("#txtEffectiveDate" + n).val()) + "&&" + sys + "&&" + type + "&&" + $.trim($("#txtCustomerTo" + n).val()) 
                                      + "&&" + $.trim($("#txtPropertyTo" + n).val()) + "&&" + $.trim($("#txtOutDepartment" + n).val()) +"&&" + $.trim($("#hdOutDepartmentID" + n).val()) 
                                      + "&&" + $.trim($("#txtInDepartment" + n).val()) +"&&" + $.trim($("#hdInDepartmentID" + n).val())  +"&&" + $.trim($("#txtANumber" + n).val())+ "||";
                            }
                            else {
                                alert("请勾选第" + n + "行的申请内容。");
                                flag = false;
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
                    if ($.trim($("#<%=txtApplyReason.ClientID %>").val()) == "") {
                        alert("请填写申请原因！");
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
            
            //if(idx!='3'&&idx!='4'){
            //    if(($("#rdbNoIDx"+idx).prop("checked")||$("#rdbOtherIDx"+idx).prop("checked"))&&$.trim($("#txtIDx"+idx).val())=="") {   
            //        alert("由于您不同意该申请，必须填写不同意的原因。")
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

        function editflow(){
            var win=window.showModalDialog("Apply_ITPower_Flow.aspx?mainid=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_ITPower_Detail.aspx?MainID=<%=MainID %>";
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
        
        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?mainid=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_ITPower_Detail.aspx?mainid=<%=MainID %>';
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
        
        function savedeal(index) {
            var deal = $("#<%=txtHandlingInformation.ClientID %>").val();
            if (typeof(index) == 'undefined' && $.trim(deal) == "") 
                alert("请填写处理情况！");
            else{
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: "action=saveitpowerdeal&itpowerid=<%=ID %>&deal=" + deal,
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
                    //if(sReturnValue=='success')
                    //    window.location.href=window.location.href;
                    //else if(sReturnValue=='deleted')
                    //    window.location='/Apply/Apply_Search.aspx';
                    if(sReturnValue=='deleted')
                        window.location='/Apply/Apply_Search.aspx';
                    else
                        window.location.href=window.location.href;
                }
    </script>
    <style type="text/css">
        .itinput{width:95px}
    </style>
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
            <h1>(物业部/工商铺)IT权限申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td>申请部门：</td>
                    <td><asp:TextBox ID="txtApplicationDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdApplicationDepartmentID" runat="server" /></td>
                    <td width="100px">申请日期：</td>
                    <td><asp:TextBox ID="txtApplicationDate" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>申请人：</td>
                    <td><asp:TextBox ID="txtApplicant" runat="server"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan='4' style="text-align:left;">注：此表格适用于三级市场系统、佣金系统、内部网（SPS）、电子传真等权限申请，</td>
                </tr>
                <tr>
                    <td colspan='4' style="text-align:left;">请根据申请内容将此表发送到资讯科技部相关负责同事。</td>
                </tr>
                <tr>
                    <td colspan='4' >
                        <table id="tbDetail" class='sample' width='100%'>
                            <thead>
                                <tr>
                                    <th>个人资料</th>
                                    <th>申请内容</th>
                                    <th width="60px">申请性质</th>
                                    <th>备注</th>
                                </tr>
                            </thead>
                            <%--<tr>
                                <td class="tl">
                                    工&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：<input type="text" id="txtCode1" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" onblur="getEmployee(this,1);"/><br />
                                    姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：<input type="text" id="txtName1"/><br />
                                    部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门：<input type="text" id="txtDepartment1"/><input type="text" id="txtDepartmentID1" style="display:none;"/><input type="hidden" id="hdDepartmentID1" /><br />
                                    职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位：<input type="text" id="txtPosition1"/><br />
                                    生效日期：<input type="text" id="txtEffectiveDate1"/>
                                </td>
                                <td class="tl">
                                    <input id='chkSys12' type="checkbox" value="2"/><label for='chkSys12'>内部网</label><br />
                                    <input id='chkSys13' type="checkbox" value="3"/><label for='chkSys13'>三级市场系统</label><br />
                                    <input id='chkSys14' type="checkbox" value="4"/><label for='chkSys14'>电子传真系统</label><br />
                                    <input id='chkSys15' type="checkbox" value="5"/><label for='chkSys15'>佣金系统(二手)</label><br />
                                    <input id='chkSys16' type="checkbox" value="6"/><label for='chkSys16'>内部MSN</label><br />
                                    <input id='chkSys17' type="checkbox" value="7"/><label for='chkSys17'>资产管理系统</label>
                                </td>
                                <td>
                                    <input type="radio" id='rdoApplyType11' name='ApplyType1' checked="checked" value="1" /><label for='rdoApplyType11'>新增</label><br />
                                    <input type="radio" id='rdoApplyType12' name='ApplyType1' value="2" /><label for='rdoApplyType12'>删除</label><br />
                                    <input type="radio" id='rdoApplyType13' name='ApplyType1' value="3" /><label for='rdoApplyType13'>调动</label>
                                </td>
                                <td class="tl">
                                    (离职或调职时必须填写)<br />
                                    客源转移至：<input type="text" id="txtCustomerTo1"/><br />
                                    房源转移至：<input type="text" id="txtPropertyTo1"/><br />
                                    调 出 部 门 ：<input type="text" id="txtOutDepartment1"/><input type="hidden" id="hdOutDepartmentID1" /><br />
                                    调 入 部 门 ：<input type="text" id="txtInDepartment1"/><input type="hidden" id="hdInDepartmentID1" />
                                </td>                            
                            </tr>--%>
                            <%=sbHtml.ToString()%>
                        </table>
                        <input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
                        <input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
                    </td>
                </tr>
                <tr>
                    <td colspan='4' class="tl tdu">如项目部需申请佣金系统请向财务申请</td>
                </tr>
                <tr>
                    <td colspan='4' class="tl">*开通经理以上级别权限的，必须要隶属经理签名审批。</td>
                </tr>
                <tr>
                    <td colspan='4'><hr /></td>      
                </tr>
                <tr>
                    <td colspan='4' class="tl">申请原因：</td>      
                </tr>
                <tr>
                    <td colspan='4'>
                        <asp:TextBox ID="txtApplyReason" runat="server" TextMode="MultiLine" Rows="4" Columns="75" style="overflow:auto;"></asp:TextBox>
                    </td>      
                </tr>
                <tr class="noborder" style="height:85px;">
                    <td>部 门 主 管 ：</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label>
                        <textarea id="txtIDx1" rows="2" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div></td>
                </tr>
                <tr class="noborder" style="height:85px;">
                    <td>部门主管 / 负责人：</td>  
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label>
                        <textarea id="txtIDx2" rows="2" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div></td>
                </tr>
                <tr>
                    <td colspan='4'><hr /></td>      
                </tr>
                <tr>
                    <td colspan='3' class="tl">此栏由资讯科技部填写</td>  
                    <td>工号：<asp:Label ID="lblCode" runat="server" Text="_________________"></asp:Label></td>    
                </tr>
                <tr>
                    <td colspan='4' class="tl">处理情况：</td>      
                </tr>
                <tr>
                    <td colspan='4'>
                        <asp:TextBox ID="txtHandlingInformation" runat="server" TextMode="MultiLine" Rows="4" Columns="75" style="overflow:auto;"></asp:TextBox>
                    </td>      
                </tr>
                <tr>
                    <td colspan='4'><input type="button" id="btnSaveDeal" value="保存处理情况" style="display:none;" onclick="savedeal();" /></td>
                </tr>
                <tr class="noborder" style="height:30px;">
                    <td>跟&nbsp;&nbsp;&nbsp;进&nbsp;&nbsp;&nbsp;人&nbsp;&nbsp;：</td>
                    <td colspan='3' class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label>
                        <textarea id="txtIDx3" rows="2" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="savedeal('3')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height:30px;">
                    <td>部门负责人：</td>
                    <td colspan='3' class="tl PL10">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label>
                        <textarea id="txtIDx4" rows="2" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
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
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display:none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <%--<input type="button" id="btnGoBack" value="返回" onclick="window.history.go(-1);" />--%>
        <%--<input type="button" id="btnGoBack" value="返回" onclick="window.location='/Apply/Apply_Search.aspx';" />--%>
        <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click"/>
        <asp:HiddenField ID="hdIsAgree" runat="server" />
        <asp:HiddenField ID="hdSuggestion" runat="server" />
        <input type="hidden" id="hdDetail" runat="server" />
        <input type="hidden" id="hdFlow" runat="server" />
        <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" style="display:none;" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
    </div>
    
    <script type="text/javascript">AddOtherAgree();</script>
    <%=sbJS.ToString() %>
    <script type="text/javascript">
        function IsShowPhone(e)
        {
            if($("#chkSys"+e+"3").is(":checked"))
                    {
                        $(".cphone"+e).show();
                    }
                    else
                    {
                        $(".cphone"+e).hide();
                    }
        }
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        //$("#chkSys13").click(function()
        //{
        //    if($("#chkSys13").is(":checked"))
        //    {
        //        $(".cphone").show();
        //    }
        //    else
        //    {
        //        $(".cphone").hide();
        //    }
        //    alert( $(".cphone").is(":hidden"))
        //})
    </script>
</asp:Content>
