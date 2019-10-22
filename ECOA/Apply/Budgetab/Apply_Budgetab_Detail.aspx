<%@ Page ValidateRequest="false" Title="广告宣传预算使用异常申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Budgetab_Detail.aspx.cs" Inherits="Apply_Budgetab_Apply_Budgetab_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var i0 = 1,i1 = 1,i2 = 1,i3 = 1,i4 = 1,i5 = 1;
        var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

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
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
		        }
            });
            //for (var x = 4; x <= 6; x++) {
            //    $("#rdbNoIDx"+ x).on("click",function(){
            //        $("#rdbYesIDx"+ x).removeAttr("checked");
            //        $("#rdbOtherIDx"+ x).removeAttr("checked");
            //    });
            //}
            $("#rdbNoIDx4").click(function(){
                $("#rdbYesIDx4").removeAttr("checked");
                $("#rdbOtherIDx4").removeAttr("checked");
            });
            $("#rdbNoIDx5").click(function(){
                $("#rdbYesIDx5").removeAttr("checked");
                $("#rdbOtherIDx5").removeAttr("checked");
            });
            $("#rdbNoIDx6").click(function(){
                $("#rdbYesIDx6").removeAttr("checked");
                $("#rdbOtherIDx6").removeAttr("checked");
            });
            $("#rdbOtherIDx4").click(function(){
                $("#rdbNoIDx4").removeAttr("checked");
            });
            $("#rdbOtherIDx5").click(function(){
                $("#rdbNoIDx5").removeAttr("checked");
            });
            $("#rdbOtherIDx6").click(function(){
                $("#rdbNoIDx6").removeAttr("checked");
            });
		     
            i0 = $("#tbDetail0 tr").length;
            i1 = $("#tbDetail1 tr").length;
            i2 = $("#tbDetail2 tr").length;
            i3 = $("#tbDetail3 tr").length;
            i4 = $("#tbDetail4 tr").length;
            i5 = $("#tbDetail5 tr").length;
            //i = $("#tbDetail tr").length - 1;
            $("#<%=txtApplyDate.ClientID%>").datepicker();
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
            clearDetalBoder();
            //$("#tbDetail0").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
            //$("[id=tbDetail0] tr").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
            //$("[id=tbDetail0] td").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
            //$("#tbDetail1").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
            //$("[id=tbDetail1] tr").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
            //$("[id=tbDetail1] td").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
        });
       
        function clearDetalBoder(){
            $("[id^=tbDetail]").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
            $("[id^=tbDetail] tr").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
            $("[id^=tbDetail] td").css({"border-style":"none","border-width": "0px","border-collapse":"collapse","border":"none"});
        }

        function check() {
            //if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
		    //    alert("发文编号不可为空！");
		    //    $("#<%=txtApplyID.ClientID %>").focus();
            //    return false;
            //}
	        
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("申请部门不可为空！");
		        $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
			
            if($.trim($("#<%=txtApply.ClientID %>").val())=="") {
                alert("申请人不可为空！");
		        $("#<%=txtApply.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtApplyDate.ClientID %>").val())=="") {
                alert("申请日期不可为空！");
		        $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
                alert("联系电话/传真不可为空！");
		        $("#<%=txtPhone.ClientID %>").focus();
                return false;
            }

            if (
                    !$("#<%=cbAProject1.ClientID %>").prop("checked") 
                    && !$("#<%=cbAProject2.ClientID %>").prop("checked") 
                    && !$("#<%=cbAProject3.ClientID %>").prop("checked")
                    && !$("#<%=cbAProject4.ClientID %>").prop("checked")
                    && !$("#<%=cbAProject5.ClientID %>").prop("checked")
                    && !$("#<%=cbAProject6.ClientID %>").prop("checked")
                    && !$("#<%=cbAProject7.ClientID %>").prop("checked")
               ) 
            {
                alert("请选择申请项目");
                $("#<%=cbAProject1.ClientID%>").focus();
                return false;
            }

            if($("#<%=cbAProject1.ClientID %>").prop("checked")){
                
            }
            if($("#<%=cbAProject3.ClientID %>").prop("checked")){

            }
            if($("#<%=cbAProject4.ClientID %>").prop("checked")){

            }
            if($("#<%=cbAProject5.ClientID %>").prop("checked")){

            }
            if($("#<%=cbAProject6.ClientID %>").prop("checked")){

            }
            if($("#<%=cbAProject7.ClientID %>").prop("checked")){

            }
            if($.trim($("#<%=txtReason.ClientID %>").val())=="") {
                alert("申请原由不可为空！");
                $("#<%=txtReason.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=rdbStatement1.ClientID %>").prop("checked") && !$("#<%=rdbStatement2.ClientID %>").prop("checked")){
                alert("请选择向公司申请上述的内容！");
                $("#<%=rdbStatement1.ClientID %>").focus();
                return false;
            }



            var data0 = "",data1 = "",data2 = "",data3 = "",data4 = "",data5 = "";
            var flag = true;
	        
            $("#tbDetail0 tr").each(function (i) {
                if($("#<%=cbAProject1.ClientID %>").prop("checked")){
                    var n = i + 1;
                    if ($.trim($("#txtAkind" + n).val()) == "") {
                        alert("第" + n + "行的申请类型必须填写。" + n);
                        $("#txtAkind" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtAitem" + n).val()) == "") {
                        alert("第" + n + "行的申请项必须填写。" + n);
                        $("#txtAitem" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtAdjustableKind" + n).val()) == "") {
                        alert("第" + n + "行的调至类型必须填写。" + n);
                        $("#txtAdjustableKind" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtAdjustableItem" + n).val()) == "") {
                        alert("第" + n + "行的调至项必须填写。" + n);
                        $("#txtAdjustableItem" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtPrice" + n).val()) == "") {
                        alert("第" + n + "行的金额必须填写。" + n);
                        $("#txtPrice" + n).focus();
                        flag = false;
                    }
                    else
                        data0 += $.trim($("#txtAkind" + n).val()) 
                            + "&&" + $.trim($("#txtAitem" + n).val()) 
                            + "&&" + $.trim($("#txtAdjustableKind" + n).val()) 
                            + "&&" + $.trim($("#txtAdjustableItem" + n).val()) 
                            + "&&" + $.trim($("#txtPrice" + n).val()) 
                            + "||";
                }
            });

            $("#tbDetail1 tr").each(function (i) {
                if($("#<%=cbAProject3.ClientID %>").prop("checked")){
                    var n = i + 1;
                    if ($.trim($("#txtAdvertisingItem" + n).val()) == "") {
                        alert("第" + n + "行的广告宣传类项必须填写。" + n);
                        $("#txtAdvertisingItem" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtAdvertisingPrice" + n).val()) == "") {
                        alert("第" + n + "行的广告宣传类金额必须填写。" + n);
                        $("#txtAdvertisingPrice" + n).focus();
                        flag = false;
                    }
                    else
                        data1 += $.trim($("#txtAdvertisingItem" + n).val()) 
                            + "&&" + $.trim($("#txtAdvertisingPrice" + n).val()) 
                            + "||";
                }
            });
            $("#tbDetail2 tr").each(function (i) {
                if($("#<%=cbAProject4.ClientID %>").prop("checked")){
                    var n = i + 1;
                    if ($.trim($("#txtPrintingItem" + n).val()) == "") {
                        alert("第" + n + "行的宣传印刷类项必须填写。" + n);
                        $("#txtPrintingItem" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtPrintingPrice" + n).val()) == "") {
                        alert("第" + n + "行的宣传印刷类金额必须填写。" + n);
                        $("#txtPrintingPrice" + n).focus();
                        flag = false;
                    }
                    else
                        data2 += $.trim($("#txtPrintingItem" + n).val()) 
                            + "&&" + $.trim($("#txtPrintingPrice" + n).val()) 
                            + "||";
                }
            });
            $("#tbDetail3 tr").each(function (i) {
                if($("#<%=cbAProject5.ClientID %>").prop("checked")){
                    var n = i + 1;
                    if ($.trim($("#txtMaterialItem" + n).val()) == "") {
                        alert("第" + n + "行的宣传物料类项必须填写。" + n);
                        $("#txtMaterialItem" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtMaterialPrice" + n).val()) == "") {
                        alert("第" + n + "行的宣传物料类金额必须填写。" + n);
                        $("#txtMaterialPrice" + n).focus();
                        flag = false;
                    }
                    else
                        data3 += $.trim($("#txtMaterialItem" + n).val()) 
                            + "&&" + $.trim($("#txtMaterialPrice" + n).val()) 
                            + "||";
                }
            });
            $("#tbDetail4 tr").each(function (i) {
                if($("#<%=cbAProject6.ClientID %>").prop("checked")){
                    var n = i + 1;
                    if ($.trim($("#txtActivityItem" + n).val()) == "") {
                        alert("第" + n + "行的宣传活动类项必须填写。" + n);
                        $("#txtActivityItem" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtActivityPrice" + n).val()) == "") {
                        alert("第" + n + "行的宣传活动类金额必须填写。" + n);
                        $("#txtActivityPrice" + n).focus();
                        flag = false;
                    }
                    else
                        data4 += $.trim($("#txtActivityItem" + n).val()) 
                            + "&&" + $.trim($("#txtActivityPrice" + n).val()) 
                            + "||";
                }
            });
            $("#tbDetail5 tr").each(function (i) {
                if($("#<%=cbAProject7.ClientID %>").prop("checked")){
                    var n = i + 1;
                    if ($.trim($("#txtAnotherItem" + n).val()) == "") {
                        alert("第" + n + "行的其它类项必须填写。" + n);
                        $("#txtAnotherItem" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtAnotherPrice" + n).val()) == "") {
                        alert("第" + n + "行的其它类金额必须填写。" + n);
                        $("#txtAnotherPrice" + n).focus();
                        flag = false;
                    }
                    else
                        data5 += $.trim($("#txtAnotherItem" + n).val()) 
                            + "&&" + $.trim($("#txtAnotherPrice" + n).val()) 
                            + "||";
                }
            });

            if (flag) {
                data0 = data0.substr(0, data0.length - 2);
                $("#<%=hdDetail0.ClientID %>").val(data0);

                data1 = data1.substr(0, data1.length - 2);
                $("#<%=hdDetail1.ClientID %>").val(data1);
                data2 = data2.substr(0, data2.length - 2);
                $("#<%=hdDetail2.ClientID %>").val(data2);
                data3 = data3.substr(0, data3.length - 2);
                $("#<%=hdDetail3.ClientID %>").val(data3);
                data4 = data4.substr(0, data4.length - 2);
                $("#<%=hdDetail4.ClientID %>").val(data4);
                data5 = data5.substr(0, data5.length - 2);
                $("#<%=hdDetail5.ClientID %>").val(data5);
            }
            else 
                return false;

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
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue=='success')
		        window.location='Apply_Budgetab_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_Budgetab_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_Budgetab_Detail.aspx?MainID=<%=MainID %>";
        }

        function addRow0() {
            i0++;
            var html = '<tr id="trDetail0' + i0 + '" class="addTb">'
				+ '         <td class=\"addTb\">由：<input type="text" id="txtAkind' + i0 + '" style="width:95px"/>类'
                + '         <input type="text" id="txtAitem' + i0 + '" style="width:95px"/>项预算调至：'
                + '         <input type="text" id="txtAdjustableKind' + i0 + '" style="width:95px"/>类'
                + '         <input type="text" id="txtAdjustableItem' + i0 + '" style="width:95px"/>项，金额为'
				+ '         <input type="text" id="txtPrice' + i0 + '" style="width:95px"/></td>'
				+ '     </tr>';
            //var html = '<tr id="trDetail0' + i0 + '"><table><tr><td>这是第'+ i0 +'个</td></tr></table></tr>'
            $("#tbDetail0").append(html);
        }
        function deleteRow0() {
            if (i0 > 1) {
                i0--;
                $("#tbDetail0 tr:eq(" + (i0) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow1() {
            i1++;
            var html = '<tr id="trDetail1' + i1 + '" class="addTb">'
				+ '         <td class="addTb"><input type="text" id="txtAdvertisingItem' + i1 + '" />项；金额为￥ '
				+ '         <input type="text" id="txtAdvertisingPrice' + i1 + '" />元。</td>'
				+ '     </tr>';
            //var html = '<tr id="trDetail1' + i1 + '"><table><tr><td>这是第'+ i1 +'个</td></tr></table></tr>'
            $("#tbDetail1").append(html);
        }
        function deleteRow1() {
            if (i1 > 1) {
                i1--;
                $("#tbDetail1 tr:eq(" + (i1) + ")").remove();
            } else
                alert("不可删除第一行。");
        }
        function addRow2() {
            i2++;
            var html = '<tr id="trDetail2' + i2 + '" class="addTb">'
				+ '         <td class="addTb"><input type="text" id="txtPrintingItem' + i2 + '" />项；金额为￥ '
				+ '         <input type="text" id="txtPrintingPrice' + i2 + '" />元。</td>'
				+ '     </tr>';
            //var html = '<tr id="trDetail2' + i2 + '"><table><tr><td>这是第'+ i2 +'个</td></tr></table></tr>'
            $("#tbDetail2").append(html);
        }
        function deleteRow2() {
            if (i2 > 1) {
                i2--;
                $("#tbDetail2 tr:eq(" + (i2) + ")").remove();
            } else
                alert("不可删除第一行。");
        }
        function addRow3() {
            i3++;
            var html = '<tr id="trDetail3' + i3 + '" class="addTb">'
				+ '         <td class="addTb"><input type="text" id="txtMaterialItem' + i3 + '" />项；金额为￥ '
				+ '         <input type="text" id="txtMaterialPrice' + i3 + '" />元。</td>'
				+ '     </tr>';
            //var html = '<tr id="trDetail3' + i3 + '"><table><tr><td>这是第'+ i3 +'个</td></tr></table></tr>'
            $("#tbDetail3").append(html);
        }
        function deleteRow3() {
            if (i3 > 1) {
                i3--;
                $("#tbDetail3 tr:eq(" + (i3) + ")").remove();
            } else
                alert("不可删除第一行。");
        }
        function addRow4() {
            i4++;
            var html = '<tr id="trDetail4' + i4 + '" class="addTb">'
				+ '         <td class="addTb"><input type="text" id="txtActivityItem' + i4 + '" />项；金额为￥ '
				+ '         <input type="text" id="txtActivityPrice' + i4 + '" />元。</td>'
				+ '     </tr>';
            //var html = '<tr id="trDetail4' + i4 + '"><table><tr><td>这是第'+ i4 +'个</td></tr></table></tr>'
            $("#tbDetail4").append(html);
        }
        function deleteRow4() {
            if (i4 > 1) {
                i4--;
                $("#tbDetail4 tr:eq(" + (i4) + ")").remove();
            } else
                alert("不可删除第一行。");
        }
        function addRow5() {
            i5++;
            var html = '<tr id="trDetail5' + i5 + '" class="addTb">'
				+ '         <td class="addTb"><input type="text" id="txtAnotherItem' + i5 + '" />项；金额为￥ '
				+ '         <input type="text" id="txtAnotherPrice' + i5 + '" />元。</td>'
				+ '     </tr>';
            //var html = '<tr id="trDetail5' + i5 + '"><table><tr><td>这是第'+ i5 +'个</td></tr></table></tr>'
            $("#tbDetail5").append(html);
        }
        function deleteRow5() {
            if (i5 > 1) {
                i5--;
                $("#tbDetail5 tr:eq(" + (i5) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }
		
                function sign(idx) {
                    //if(idx=='1'||idx=='2'||idx=='3'){
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
                        if($("#rdbYesIDx"+idx).prop("checked") && $("#rdbOtherIDx"+idx).prop("checked"))
                            $("#<%=hdIsAgree.ClientID %>").val("12");
					   
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
        #ctl00_ContentPlaceHolder1_rdbIsLawE td {
            border: 0;
        }

        .auto-style2 {
            width: 85px;
        }
        .auto-flow {
            margin-top: 5px;
            float:left;
        }
        .addTb {
            border-style:none;
            border-width: 0px;
            border-collapse:collapse;
            border:none;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div class="tips">
        <p><b>一、预算内调用和预算冻结（跨年度）：</b>申请前可先与市场部（周燕妮）联系后，再填写； </p>
    </div>
    <script type="text/javascript">
        function tipswidth()
        {
            var tipswidth = (document.body.clientWidth - 800)/2
            $(".tips").width(tipswidth);
        }
        tipswidth();
        window.onresize = function(){
            tipswidth();
        }
    </script>
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>广告宣传预算使用异常申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 740px; margin: 0 auto;">
                <span style="float: right; display: none;" class="file_number">
                    《广告宣传需求申请表》编号：
                    <asp:TextBox ID="txtApplyID" runat="server" Width="200px"></asp:TextBox>
                </span>
            </div>
            <table id="tbAround" width='740px'>
                <tr>
                    <td>申请部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
                    <td class="auto-style2">申请日期</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApplyDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>申 请 人</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApply" runat="server"></asp:TextBox>
                    </td>
                    <td>联系电话/传真</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td>文档编码</td>
                    <td colspan="3" class="tl PL10">
                        <%=SerialNumber %>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding: 5px 5px 5px 10px; text-align: left; line-height: 30px;">
                        <span style="background-color: #CCCCCC; font-weight: bold; font-size: large;">申请项目：</span>　（请在“□”中打“√”表示选取之申请项目）<br />
                        <asp:CheckBox ID="cbAProject1" runat="server" Font-Bold="True" Text="预算内调用，具体申请如下：" />（根据区域各类别项目的预算使用情况调用）<br />
                        
                        <table id="tbDetail0" width='100%' style="margin: 0 auto;" class="addTb">
                            <%=SbHtml0.ToString()%>
						</table>
                        <input type="button" id="btnAddRow0" value="添加新行" onclick="addRow0();" style=" float:left; margin-left:5px; display:none;"/>
						<input type="button" id="btnDeleteRow0" value="删除一行" onclick="deleteRow0();" style=" float:left; display:none;"/>

                        例：由<span style="color: #FF0000; text-decoration: underline;">　宣传物料　</span>类<span style="color: #FF0000; text-decoration: underline;">　海报　</span>项预算调至<span style="color: #FF0000; text-decoration: underline;">　宣传印刷品　</span>类<span style="color: #FF0000; text-decoration: underline;">　宣传卡　</span>项，金额为<span style="color: #FF0000; text-decoration: underline;">　￥1000元正　</span><br />
                        <asp:CheckBox ID="cbAProject2" runat="server" Font-Bold="True" Text="预算冻结（跨年度），具体申请如下：" /><br />

                        <div style="width: 100%; float: left; background-color: #e9e9e9;">
                        <asp:CheckBox ID="cbAProject3" runat="server" Text="广告宣传类" CssClass="auto-flow" />
                        <table id="tbDetail1" width='62%' style="float: left;" class="addTb">
                            <%=SbHtml1.ToString()%>
						</table>
                        <input type="button" id="btnAddRow1" value="添加新行" onclick="addRow1();" style=" float:left; margin-left:5px; display:none; margin-top: 10px;"/>
						<input type="button" id="btnDeleteRow1" value="删除一行" onclick="deleteRow1();" style=" float:left; display:none; margin-top: 10px;"/><br />
                        </div>
                        
                        <div style="width: 100%; float: left;">
                        <asp:CheckBox ID="cbAProject4" runat="server" Text="宣传印刷类" CssClass="auto-flow" />
                        <table id="tbDetail2" width='62%' style="float: left;" class="addTb">
                            <%=SbHtml2.ToString()%>
						</table>
                        <input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style=" float:left; margin-left:5px; display:none; margin-top: 10px;"/>
						<input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style=" float:left; display:none; margin-top: 10px;"/><br />
                        </div>
                        
                        <div style="width: 100%; float: left; background-color: #e9e9e9;">
                        <asp:CheckBox ID="cbAProject5" runat="server" Text="宣传物料类" CssClass="auto-flow" />
                        <table id="tbDetail3" width='62%' style="float: left;" class="addTb">
                            <%=SbHtml3.ToString()%>
						</table>
                        <input type="button" id="btnAddRow3" value="添加新行" onclick="addRow3();" style=" float:left; margin-left:5px; display:none; margin-top: 10px;"/>
						<input type="button" id="btnDeleteRow3" value="删除一行" onclick="deleteRow3();" style=" float:left; display:none; margin-top: 10px;"/><br />
                        </div>
                        
                        <div style="width: 100%; float: left;">
                        <asp:CheckBox ID="cbAProject6" runat="server" Text="宣传活动类" CssClass="auto-flow" />
                        <table id="tbDetail4" width='62%' style="float: left;" class="addTb">
                            <%=SbHtml4.ToString()%>
						</table>
                        <input type="button" id="btnAddRow4" value="添加新行" onclick="addRow4();" style=" float:left; margin-left:5px; display:none; margin-top: 10px;"/>
						<input type="button" id="btnDeleteRow4" value="删除一行" onclick="deleteRow4();" style=" float:left; display:none; margin-top: 10px;"/><br />
                        </div>
                        
                        <div style="width: 100%; float: left; background-color: #e9e9e9;">
                        <asp:CheckBox ID="cbAProject7" runat="server" Text="其　他　类" CssClass="auto-flow" />
                        <table id="tbDetail5" width='62%' style="float: left;" class="addTb">
                            <%=SbHtml5.ToString()%>
						</table>
                        <input type="button" id="btnAddRow5" value="添加新行" onclick="addRow5();" style=" float:left; margin-left:5px; display:none; margin-top: 10px;"/>
						<input type="button" id="btnDeleteRow5" value="删除一行" onclick="deleteRow5();" style=" float:left; display:none; margin-top: 10px;"/><br />
                        </div>
                        
                        <div style="width: 100%; float: left;">
                        <span style="background-color: #CCCCCC; font-weight: bold; font-size: large;">申请原由：</span>　（具体原由必须包括下列内容）<br />
                        <asp:TextBox ID="txtReason" runat="server" Height="100px" TextMode="MultiLine" Width="98%"></asp:TextBox><br />
                        特此，向公司申请上述：<asp:CheckBox ID="rdbStatement1" runat="server" Text="调用" />
                        <asp:CheckBox ID="rdbStatement2" runat="server" Text="冻结" />。<br />
                        以上述申请妥否，请公司审核批复，谢谢！
                        </div>

                    </td>
                </tr>

                <tr id="trManager1" class="noborder" style="height: 85px;">
                    <td class="auto-style2">申请人/主管签署</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td class="auto-style2">区经签署</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager3" class="noborder" style="height: 85px;">
                    <td class="auto-style2">总监/区域负责人签署</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>

              <%--  <tr class="noborder" style="height: 85px;">
                    <td rowspan="3" class="auto-style2">市场部</td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:LinkButton ID="lbtAddMaster4" runat="server" OnClick="lbtAddMaster_Click" Style="float:right;margin-right:20px;display:none">添加首席运营官</asp:LinkButton>
                        <input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="" /><label for="rdbOtherIDx4">其他意见</label><br />
                        <textarea id="txtIDx4" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style="">
                        <asp:LinkButton ID="lbtAddMaster5" runat="server" OnClick="lbtAddMaster_Click" Style="float:right;margin-right:20px;display:none">添加首席运营官</asp:LinkButton>
                        <input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>--%>

                <tr class="noborder" style="height: 85px;">
                      <td rowspan="1" class="auto-style2">品牌营销部</td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:LinkButton ID="lbtAddMaster6" runat="server" OnClick="lbtAddMaster_Click" Style="float:right;margin-right:20px;display:none">添加首席运营官</asp:LinkButton>
                        <input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="6" style="width: 98%; overflow: auto;" cols="20" name="S1"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
                    </td>
                </tr>

                <tr id="trManager7" class="noborder" style="height: 85px;display:none">
                    <td class="auto-style2">首席运营官</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="" /><label for="rdbOtherIDx7">其他意见</label><br />
                        <textarea id="txtIDx7" rows="6" style="width: 98%; overflow:auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display:none;" />
                        <div class="signdate">日期：<span id="span1">_________</span></div>
                    </td>
                </tr>
                <tr id="trGeneralManager" style="height: 85px; display: none;">
                    <td >董事总经理<br />审批</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        <textarea id="txtIDx8" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
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
                
                <tr>
                    <td colspan="4" style="padding-left: 10px; text-align: left; line-height: 25px">
                        注意：<br />
                        1.	在年度预算使用日期截止前未能正常使用，而拟于期后使用的，必须在预算截日前15个工作日内申请预算冻结；<br />
                        2.	费用调用或冻结申请批复后，使用的期限不得超过公司截止日起30个工作日。否则公司不予正常程序批复报销；<br />
                        3.	发生的费用在不超过上述申请总额的情况下实报实销；<br />
                        4.	预算使用截止日起不得申请使用、调用及冻结预算。<br />
                    </td>
                </tr>
            </table>
            <!--打印正文结束-->
        </div>
        <div class="noprint">
        <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" BackColor="White" Style="clear: both; margin-top: 3px;"
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
        </asp:GridView>
        <div id="PageBottom">
            <hr />
            <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />

            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
            <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
            <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
            <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
            <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
            <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
            <asp:HiddenField ID="hdIsAgree" runat="server" />
            <asp:HiddenField ID="hdSuggestion" runat="server" />

            <input type="hidden" id="hdDetail0" runat="server" />
            <input type="hidden" id="hdDetail1" runat="server" />
            <input type="hidden" id="hdDetail2" runat="server" />
            <input type="hidden" id="hdDetail3" runat="server" />
            <input type="hidden" id="hdDetail4" runat="server" />
            <input type="hidden" id="hdDetail5" runat="server" />

            <asp:HiddenField ID="hdCancelSign" runat="server" />
            <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
        </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        clearDetalBoder();
    </script>
</asp:Content>

