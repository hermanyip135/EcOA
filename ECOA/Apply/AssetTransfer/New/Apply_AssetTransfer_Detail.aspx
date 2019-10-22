<%@ Page Title="资产调动表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_AssetTransfer_Detail.aspx.cs" Inherits="Apply_AssetTransfer_Apply_AssetTransfer_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=sbJSON.ToString() %>;
        var ImportjJSON = <%=SbDepartmentJson.ToString() %>;
        var jATJSON = <%=sbATJSON.ToString() %>;
        
        $(function() {      
            i = $("#tbDetail tr").length;
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
            $("#<%=txtApplyDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });

            $("[id*=btnLoadPath]").css({ //M_AssetAlter：20150827
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

            $("[id*=btnSelect]").css({
                "background-image": "url(/Images/btnSel1.png)",
                "height": "25px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "80px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });

            $("[id*=btnSelect]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSel2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSel1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSel1.png)"); });

            $("[id*=btndeleterow2]").css({
                "background-image": "url(/Images/btndeleterow2.png)",
                "height": "25px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "80px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });

            for (var x = 1; x <= i; x++) {
                var ddlAsset=document.getElementById("ddlAsset"+ x);
                ddlAsset.options[0]=new Option("请选择",0);
                for(var y=0;y<jATJSON.length;y++) {
                    ddlAsset.options[y+1]=new Option(jATJSON[y].value,jATJSON[y].id);
                }
                
                $("#txtBuyTime"+x).datepicker({
                    showButtonPanel: true,
                    showOtherMonths: true,
                    selectOtherMonths: true,
                    changeMonth: true,
                    changeYear: true
                });
            }
            
            <%=ddlselect %>

            $("#<%=txtExportDepartment.ClientID%>").blur(function(){
                SetOldF();
            });

            $("#<%=txtDepartment.ClientID%>").autocomplete({ 
                source: jJSON
            }); 

            $("#<%=txtExportDepartment.ClientID%>").autocomplete({
                source: jJSON,
                select: function( event, ui ) {
                    SetOldF();
                }
            });

            $("#<%=txtExportPlace.ClientID%>").autocomplete({ 
                source: ImportjJSON
            });

            $("#<%=txtImportDepartment.ClientID%>").autocomplete({ 
                source: jJSON
            }); 

            $("#<%=txtImportPlace.ClientID%>").autocomplete({ 
                source: ImportjJSON
            });

            
            SetOldF();
            autoTextarea(document.getElementById("txtIDx1"));
            autoTextarea(document.getElementById("txtIDx8"));
            autoTextarea(document.getElementById("txtIDx9"));
            autoTextarea(document.getElementById("txtIDx10"));
            autoTextarea(document.getElementById("txtIDx12"));
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function SetOldF(){
            if($("#<%=txtExportDepartment.ClientID%>").val() == "总部仓库" || $("#<%=txtExportDepartment.ClientID%>").val() == "芳村仓库"){
                $("#btnAddRow").show();
                $("#btnDeleteRow").show();
                $("#btnSelect").hide();
                $("#btndeleterow2").hide();
                $("#<%=txtExportPlace.ClientID%>").css("background-color","").removeAttr("readonly");

                $("[id^=txtAsset]").css("background-color","").removeAttr("readonly");
                $("[id^=txtNumber]").css("background-color","").removeAttr("readonly");
                $("[id^=txtATag]").css("background-color","").removeAttr("readonly");
                $("[id^=txtModel]").css("background-color","").removeAttr("readonly");

                //$("#tbDetail tr[id*=trDetail]").remove();
                //i = 1
                //addRow();
            }
        }
        
        function addRow() {
            if (i >= 5) {
                alert("页面上不可新增超过5项资产，请以附件形式上传。");
                return;
            }   
            
            i++;
            var html; //M_Asset：20150506
            if(new Date($("#<%=txtApplyDate.ClientID%>").val().replace(/\-/g, "\/")) <= new Date('<%=CommonConst.ASSET_OLD_TIME%>'.replace(/\-/g, "\/")))
            {
                html = "<tr id='trDetail" + i + "' class=\"noborder\">"
                + "     <td class=\"tl PL10\" style=\"width:200px\">"
                + "                      <input type='hidden' id='hidAssetID" + i + "' />"
                + "            *资产名称 <select id=\"ddlAsset" + i + "\" style=\"width:120px;\" onchange=\"checkasset(this," + i + ");\"></select><br />"
                + "            *数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;量 <input type=\"text\" id=\"txtNumber" + i + "\" style=\"width:120px;\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"checknum(this," + i + ");\"/><br />"
                + "    </td>"
                + "     <td class=\"tl PL10\">"
                + "            *财务编号 <input type=\"text\" id=\"txtATag" + i + "\" style=\"width:200px;\"/><br />"
                + "            *规格型号 <input type=\"text\" id=\"txtModel" + i + "\" style=\"width:200px;\"/><br />"
                + "    </td>" 
                + "</tr>";
            }
            else
            {
                html = "<tr id='trDetail" + i + "' class=\"noborder\">"
                + "     <td class=\"tl PL10\" style=\"width:200px\">"
                + "                      <input type='hidden' id='hidAssetID" + i + "' />"
                + "            *资产名称 <input type=\"text\" id=\"txtAsset" + i + "\" style=\"width:120px;\"/><select id=\"ddlAsset" + i + "\" style=\"width:120px; display:none;\" onchange=\"checkasset(this," + i + ");\"></select><br />"
                + "            *数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;量 <input type=\"text\" id=\"txtNumber" + i + "\" style=\"width:120px;\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"checknum(this," + i + ");\"/><br />"
                + "    </td>"
                + "     <td class=\"tl PL10\">"
                + "            *财务编号 <input type=\"text\" id=\"txtATag" + i + "\" style=\"width:200px;\"/><br />"
                + "            *规格型号 <input type=\"text\" id=\"txtModel" + i + "\" style=\"width:200px;\"/><br />"
                + "    </td>" 
                + "</tr>";
            }
            //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
            $("#tbDetail").append(html);
            
            var ddlAsset=document.getElementById("ddlAsset"+ i);
            ddlAsset.options[0]=new Option("请选择",0);
            for(var y=0;y<jATJSON.length;y++) {
                ddlAsset.options[y+1]=new Option(jATJSON[y].value,jATJSON[y].id);
            }
            
            $("#txtBuyTime"+i).datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
        }
              
        function deleteRow() {
            if (i > 1) {
                $("#tbDetail tr:eq(" + (i - 1) + ")").remove();
                i--;
            }
            else
                alert("不可删除第一行。");
            
        }
        
        function deleteRow2() {
            if (i > 0) {
                $("#tbDetail tr:eq(" + (i - 1) + ")").remove();
                i--;
            }
            else
                alert("不可再删除。");
            
        }
        
        function check() {
         
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("发文部门不可为空。");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtExportDepartment.ClientID %>").val())=="") {
                alert("调出 部门/分行 不可为空。");
                $("#<%=txtExportDepartment.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtImportDepartment.ClientID %>").val())=="") {
                alert("接收 部门/分行 不可为空。");
                $("#<%=txtImportDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtExportContacts.ClientID %>").val())=="") {
                alert("调出 联系人 不可为空。");
                $("#<%=txtExportContacts.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtImportContacts.ClientID %>").val())=="") {
                alert("接收 联系人 不可为空。");
                $("#<%=txtImportContacts.ClientID %>").focus();
                return false;
            }

            if(!checkdate($("#<%=txtApplyDate.ClientID %>").val())){
                alert("申请日期格式错误，请按以下格式输入日期:\n2013-07-22");
                $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtExportPlace.ClientID %>").val())=="") {
                alert("调出 摆放地点 不可为空。");
                $("#<%=txtExportPlace.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtImportPlace.ClientID %>").val())=="") {
                alert("接收 摆放地点 不可为空。");
                $("#<%=txtImportPlace.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtTransferReason.ClientID %>").val())=="") {
                alert("调动原因不可为空。");
                $("#<%=txtTransferReason.ClientID %>").focus();
                return false;
            }
              
            var data = "";
            var flag=true;
            
            //如果详细只有一行，且该行为空
            //if($("#tbDetail tr").size() == 1 && $("#ddlAsset1").val() == "0" && $.trim($("#txtATag1").val()) == "" && $.trim($("#txtNumber1").val()) == "" && $.trim($("#txtModel1").val()) == "")
            //    data="||";
            //else{
                $("#tbDetail tr").each(function(i) {
                    var n=i+1;
                    if(new Date($("#<%=txtApplyDate.ClientID%>").val().replace(/\-/g, "\/")) <= new Date('<%=CommonConst.ASSET_OLD_TIME%>'.replace(/\-/g, "\/"))){
                        if ($("#ddlAsset" + n).val() == "0") {
                            alert("第" + n + "个资产中的资产名称必须选择。");
                            $("#ddlAsset" + n).focus();
                            flag= false;
                            return;
                        }
                    }

                    if ($.trim($("#txtATag" + n).val()) == "" && $("#<%=txtExportDepartment.ClientID%>").val().indexOf("仓库")<0){
                        alert("第" + n + "个资产中的财务编号必须填写。");
                        $("#txtATag" + n).focus();
                        flag= false;
                        return;
                    }

                    if($.trim($("#txtNumber" + n).val()) == "" ){
                        alert("第" + n + "个资产中的数量必须填写。");
                        $("#txtNumber" + n).focus();
                        flag= false;
                        return;
                    }
                    //if($.trim($("#txtModel" + n).val()) == "") {
                    //    alert("第" + n + "个资产中的规格型号必须填写。");
                    //    $("#txtModel" + n).focus();
                    //    flag= false;
                    //    return;
                    //}
                    if(new Date($("#<%=txtApplyDate.ClientID%>").val().replace(/\-/g, "\/")) <= new Date('<%=CommonConst.ASSET_OLD_TIME%>'.replace(/\-/g, "\/")))
                        data += $("#ddlAsset" + n).val();
                    else
                        data += $.trim($("#txtAsset" + n).val());
                    data += "&&" + $.trim($("#txtATag" + n).val()) 
                    + "&&" + $.trim($("#txtNumber" + n).val()) 
                    +"&&" + $.trim($("#txtModel" + n).val()) 
                    +"&&" + $.trim($("#hidAssetID" + n).val())
                    + "||";
                });
            //}

            if(flag) {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
                return true;
            }
            else
                return false;
        }
        
        function check2() {
            var detail = "";
            var flag=true;
            
            //如果详细只有一行，且该行为空
            if($("#tbDetail tr").size() == 1 && $("#ddlAsset1").val() == "0" && $.trim($("#txtATag1").val()) == "" && $.trim($("#txtNumber1").val()) == "" && $.trim($("#txtModel1").val()) == "")
                detail="||";
            else{
                $("#tbDetail tr").each(function(i) {
                    var n=i+1;
                    if(new Date($("#<%=txtApplyDate.ClientID%>").val().replace(/\-/g, "\/")) <= new Date('<%=CommonConst.ASSET_OLD_TIME%>'.replace(/\-/g, "\/"))){
                        if ($("#ddlAsset" + n).val() == "0") {
                            alert("第" + n + "个资产中的资产名称必须选择。");
                            $("#ddlAsset" + n).focus();
                            flag= false;
                            return;
                        }
                    }

                    if ($.trim($("#txtATag" + n).val()) == "" && $("#<%=txtExportDepartment.ClientID%>").val().indexOf("仓库")<0){
                        alert("第" + n + "个资产中的财务编号必须填写。");
                        $("#txtATag" + n).focus();
                        flag= false;
                        return;
                    }

                    if($.trim($("#txtNumber" + n).val()) == "" ){
                        alert("第" + n + "个资产中的数量必须填写。");
                        $("#txtNumber" + n).focus();
                        flag= false;
                        return;
                    }
                    //if($.trim($("#txtModel" + n).val()) == "") {
                    //    alert("第" + n + "个资产中的规格型号必须填写。");
                    //    $("#txtModel" + n).focus();
                    //    flag= false;
                    //    return;
                    //}
                    if(new Date($("#<%=txtApplyDate.ClientID%>").val().replace(/\-/g, "\/")) <= new Date('<%=CommonConst.ASSET_OLD_TIME%>'.replace(/\-/g, "\/")))
                        detail += $("#ddlAsset" + n).val();
                    else
                        data += $.trim($("#txtAsset" + n).val());
                    data += "@@" + $.trim($("#txtATag" + n).val()) 
                        + "@@" + $.trim($("#txtNumber" + n).val()) 
                        + "@@" + $.trim($("#txtModel" + n).val()) 
                        + "||";
                });
            }

            if(flag) {
                detail = detail.substr(0, detail.length - 2);

                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: "action=saveassettransferdetail&id=<%=ID%>&detail=" + detail,
                    success: function(info) {
                        if (info != "fail") 
                            sign(12);
                        else
                            alert("保存失败！");
                    }
                })
            }
        }

        function check3() {
            if(check()){
                sign('13');
            }
            //document.getElementById("<%=btnSave.ClientID %>").click();
        }

        function checkdate(val) { 
            var datetype=/^[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}$/; 
            return datetype.exec(val);
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

        function checknum(n, num) {
            if(n.value>5)
            {
                $("#txtATag" + num).val('详见附件');
                $("#txtModel" + num).val('详见附件');
            }
            else if(n.value<=5 && $("#txtATag" + num).val()=='详见附件' && $("#txtModel" + num).val()=='详见附件')
            {
                $("#txtATag" + num).val('');
                $("#txtModel" + num).val('');
            }
        }

        function checkasset(n,num) {
            if(n.children[n.selectedIndex].text=='详见附件')
            {
                $("#txtATag" + num).val('详见附件');
                $("#txtModel" + num).val('详见附件');
            }
        }

        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_AssetTransfer_Detail.aspx?MainID=<%=MainID %>';
        }

        function uploadDetails() { //M_AssetAlter：20150827
            if($.trim($("#<%=txtExportDepartment.ClientID %>").val())=="") {
                alert("请先填写调出部门/分行。");
                $("#<%=txtExportDepartment.ClientID %>").focus();
                return false;
            }
            var sReturnValue = window.showModalDialog("/Apply/Apply_SpecialUpload.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
            if (sReturnValue == "undefined") {
                sReturnValue = window.returnValue;
            }
            //else{
            //    $("#lkSpUl").show();
            //}
       
	        return true;
        }

        function editflow(){
            var win=window.showModalDialog("Apply_AssetTransfer_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_AssetTransfer_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
        function sign(idx) {
            //if(idx=='9'||idx=='10'){
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
                       
                $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
                document.getElementById("<%=btnSign.ClientID %>").click();
            }
        }
        
        function myPrint(start, end, extend) {    
            start = "<!--" + start + "-->";    
            end = "<!--" + end + "-->";    
            if (typeof (extend) == 'undefined') {        
                var temp = window.document.body.innerHTML;        
                var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
                window.document.body.innerHTML = printhtml;        
                window.print();        
                window.document.body.innerHTML = temp;    
            }    
            else { window.print(); }
        }

        function saveRemark() {
            $.ajax({
                url: "/Ajax/Apply_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=saveassettransferremark&id=<%=ID %>&remark=√",
                success: function(info) {
                    if(info=='success')
                        alert('标记成功');
                    else
                        alert('标记失败');
                }
            })
        }
        
        function saveRemarkForFinance() {
            $.ajax({
                url: "/Ajax/Apply_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=saveassettransferremark&id=<%=ID %>&remark=★",
                success: function(info) {
                    if(info=='success')
                        alert('标记成功');
                    else
                        alert('标记失败');
                }
            })
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
         function SelectAsset() { //20150519：M_AssetSelt
             if($.trim($("#<%=txtExportDepartment.ClientID %>").val())=="") {
                alert("请先填写调出部门。");
                $("#<%=txtExportDepartment.ClientID %>").focus();
                return false;
            }
            var url = "/Apply/Apply_Asset.aspx?mainID=<%=MainID %>&Asset_Dpm=" + escape($.trim($("#<%=txtExportDepartment.ClientID %>").val()));
            var sReturnValue = window.showModalDialog(url, "", "dialogHeight="+screen.height+"px;dialogWidth="+screen.width+"px;");
            if(sReturnValue){
                //20170505注释掉，为了选择资产可以添加在后面
                //$("#tbDetail tr[id*=trDetail]").remove();
                //i = 0;
                var flg = 0;
                var dataObj=eval("("+sReturnValue+")");//转换为json对象
                if(dataObj.Assets[0].txtPlace == "")
                    $("#<%=txtExportPlace.ClientID %>").val($("#<%=txtExportDepartment.ClientID %>").val());
                else
                    $("#<%=txtExportPlace.ClientID %>").val(dataObj.Assets[0].txtPlace);//.css("background-color","#e3e3e3").attr("readonly","readonly");
                //20170505注释掉，为了选择资产可以添加在后面
               // if(dataObj.Assets[0].txtClasses != "详见附件" && dataObj.Assets[0].txtClasses != "")
                    //$("#tbDetail tr[id*=trDetail]").remove();
                $.each(dataObj.Assets,function(idx,item){
                    idx=$("#tbDetail tr").length;
                    addRow();
                    if(item.txtClasses == "详见附件" || item.txtClasses == ""){
                        $("#txtAsset" + (idx + 1)).val(item.txtClasses);
                        $("#txtNumber" + (idx + 1)).val(1);
                    }
                    else{
                        $("#txtAsset" + (idx + 1)).val(item.txtClasses).css("background-color","#e3e3e3").attr("readonly","readonly");
                        $("#txtNumber" + (idx + 1)).val(1).css("background-color","#e3e3e3").attr("readonly","readonly");
                    }
                    if(item.Asset_AssetNo == "")
                        $("#txtATag" + (idx + 1)).val(item.Asset_AssetNo);
                    else
                        $("#txtATag" + (idx + 1)).val(item.Asset_AssetNo).css("background-color","#e3e3e3").attr("readonly","readonly");
                    if(item.txtTS == "")
                        $("#txtModel" + (idx + 1)).val(item.txtTS);
                    else
                        $("#txtModel" + (idx + 1)).val(item.txtTS).css("background-color","#e3e3e3").attr("readonly","readonly");
                    //if(item.txtClasses == "详见附件" || item.txtClasses == "")
                    //    $("#txtNumber" + (idx + 1)).val(item.txtClasses);
                    //else
                    //    $("#txtNumber" + (idx + 1)).val(1).css("background-color","#e3e3e3").attr("readonly","readonly");
                    if(item.txtTS == "")
                        $("#txtModel" + (idx + 1)).val('-');
                    if(item.cv.indexOf("1") != -1){
                        $("#<%=hdIsIT.ClientID %>").val("1");
                        flg = 1;
                    }
                    if(!flg)
                        $("#<%=hdIsIT.ClientID %>").val("0");

                    $("#hidAssetID" + (idx + 1)).val(item.Asset_Id);
                });
                $(":input:not(:submit):not(:button)").css("border", "1px solid #98b8b5");
            }
         }
        function SelectAsset(){
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("发文部门不可为空。");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtExportDepartment.ClientID %>").val())=="") {
                alert("调出 部门/分行 不可为空。");
                $("#<%=txtExportDepartment.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtImportDepartment.ClientID %>").val())=="") {
                alert("接收 部门/分行 不可为空。");
                $("#<%=txtImportDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtExportContacts.ClientID %>").val())=="") {
                alert("调出 联系人 不可为空。");
                $("#<%=txtExportContacts.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtImportContacts.ClientID %>").val())=="") {
                alert("接收 联系人 不可为空。");
                $("#<%=txtImportContacts.ClientID %>").focus();
                return false;
            }

            if(!checkdate($("#<%=txtApplyDate.ClientID %>").val())){
                alert("申请日期格式错误，请按以下格式输入日期:\n2013-07-22");
                $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }

           if($.trim($("#<%=txtExportPlace.ClientID %>").val())=="") {
                alert("调出 摆放地点 不可为空。");
                $("#<%=txtExportPlace.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtImportPlace.ClientID %>").val())=="") {
                alert("接收 摆放地点 不可为空。");
                $("#<%=txtImportPlace.ClientID %>").focus();
                return false;
            }
      
        }

        function LookAsset(){

     
                var url = "/Apply/AssetTransfer/New/AssetTransfer_Apply_Asset.aspx?mainID=<%=MainID %>";
                window.showModalDialog(url, "", "dialogHeight="+screen.height+"px;dialogWidth="+screen.width+"px;"); 
             
        }
    </script>
    <style type="text/css">

        .sp:link {
         color: blue;
        }
        .sp:visited {
         color: blue;
        }
        .sp:hover {
         color: blue;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 640px; margin: 0px auto;'>
        <%=sbFlow.ToString() %>
        <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>资产调动表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td style="width: 120px;">*申请部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="230px"></asp:TextBox></td>
                    <td class="tl PL10" style="background-color: #e3e3e3;">文档编码：<%=SerialNumber %></td>
                </tr>
                <tr>
                    <td></td>
                    <td>调出</td>
                    <td>接收</td>
                </tr>
                <tr>
                    <td>*部门/分行</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtExportDepartment" runat="server" Width="230px"></asp:TextBox></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtImportDepartment" runat="server" Width="230px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>*联系人</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtExportContacts" runat="server"></asp:TextBox></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtImportContacts" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>*申请日期</td>
                    <td colspan="2" class="tl PL10">
                        <asp:TextBox ID="txtApplyDate" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="noborder">
                    <td rowspan="2">调动详细情况</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table id="tbDetail" width='100%'>
                            <%=sbHtml.ToString()%>
                        </table>
       <%--                 <input type="button" id="btnAddRow" value="新增一行" onclick="addRow();" style="float: left; display: none" />
                        <input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style="float: left; display: none" />--%>
                        <asp:Button  Text="选择" runat="server" ID="btnSelect" OnClientClick="javascript:return SelectAsset()" OnClick="btnSelect_Click"/>
                        <asp:Button  Text="查看资产详情" runat="server" ID="btnLook"  OnClick="btnLook_Click"  Height="27px" />

                            <asp:Button ID="btnAssetToPDF" runat="server" Text="资产详情另存为PDF" Visible="false"  OnClick="btnAssetToPDF_Click" Height="27px" />
                                                      <asp:HiddenField runat="server"  ID="FlowStateID"/>
                         <input type="button" id="btnSaveAndEnd" value="保存并结束流程" onclick="check3();" style="float: left; display: none" />
                    <%--    <input type="button" id="btnSelect" value="选择" onclick="SelectAsset();" style="float: left; display: none; margin-left: 10px; margin-bottom: 5px;" />--%>
           <%--             <input type="button" id="btnSaveAndEnd" value="保存并结束流程" onclick="check3();" style="float: left; display: none" />
                        <input type="button" id="btndeleterow2" value="删除一行" onclick="deleteRow2();" style="float: left; display: none" />--%>

<%--                        <div id="divUploadDetails" style="text-align: left; margin-left: 10px;">
                            <div id="lkSpUl" style="font-size: 20px; margin-top: 5px; display: none;">
                                详见：<a href='<%=ConfigurationManager.AppSettings["EcoaFileURL"]%><%=SpAttachPath.ToString() %>' target="_blank" style="font-size: 20px" class="sp">调动资产明细表</a>
                            </div>
                            <div id="SuSpUl" style="display: none; margin-top: 30px;">
                                如需调动资产超过5件以上，请按此格式（<a href="/资料/资产明细表.xls">EXCEL版空白明细表</a>)下载，编辑后
                                <asp:button id="btnLoadPath" runat="server" text="上传" onclientclick="return uploadDetails();" style="margin-left: 5px;" OnClick="btnUploadDetails_Click"/>
                                ，将自动导入，无需再选择资产。
                                <input type="hidden" id="hdFilePath" runat="server" /><br />
                            </div>
                        </div>--%>

                        <div style="display: none;">
                            <input id="rdbYesIDx13" type="radio" name="agree13" checked="checked" /><input id="rdbNoIDx13" type="radio" name="agree13" />
                            <textarea id="txtIDx13" rows="1"></textarea><span id="spanDateIDx13">_________</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>*摆放地点</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtExportPlace" runat="server" Width="230px"></asp:TextBox></td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtImportPlace" runat="server" Width="230px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>*调动原因</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransferReason" runat="server" Width="98%" Height="98%" Rows="6" TextMode="MultiLine" Style="overflow: auto;"></asp:TextBox></td>
                </tr>
                <tr style="height: 30px;">
                    <td>部门主管</td>
                    <td class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label>
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><br />
                        日期：<span id="spanDateIDx2">_________</span>
                    </td>
                    <td class="tl PL10">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label>
                        <textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" /><br />
                        日期：<span id="spanDateIDx4">_________</span>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>隶属主管</td>
                    <td class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><br />
                        日期：<span id="spanDateIDx3">_________</span>
                    </td>
                    <td class="tl PL10">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx5" value="签名" onclick="sign('5')" style="display: none;" /><br />
                        日期：<span id="spanDateIDx5">_________</span>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>部门负责人</td>
                    <td class="tl PL10">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                        <textarea id="txtIDx6" rows="6" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx6" value="签名" onclick="sign('6')" style="display: none;" /><br />
                        日期：<span id="spanDateIDx6">_________</span>
                    </td>

                    <td class="tl PL10">
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label>
                        <textarea id="txtIDx7" rows="6" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx7" value="签名" onclick="sign('7')" style="display: none;" /><br />
                        日期：<span id="spanDateIDx7">_________</span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td rowspan="4">行政部审批意见</td>
                    <td colspan="2" class="tl PL10">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label>
                        <input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">其他意见</label>
                        <asp:CheckBox ID="cbkToIT" runat="server" Text="转资讯科技部审核" Style="margin-right: 10px;" Visible="false" />
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td colspan="2">
                        <textarea id="txtIDx1" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="if(check()){sign('1');}" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td colspan="2" class="tl PL10" style="">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label>
                        <input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td colspan="2">
                        <textarea id="txtIDx8" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签名" onclick="sign('8')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
                    </td>
                </tr>
                <tr id="trIT1" class="noborder" style="height: 30px;">
                    <td rowspan="4">资讯科技部审批意见</td>
                    <td colspan="2" class="tl PL10" style="">
                        <input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label>
                    </td>
                </tr>
                <tr id="trIT2" class="noborder" style="height: 30px;">
                    <td colspan="2">
                        <textarea id="txtIDx9" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
                    </td>
                </tr>
                <tr id="trIT3" class="noborder" style="height: 30px;">
                    <td colspan="2" class="tl PL10" style="">
                        <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label>
                    </td>
                </tr>
                <tr id="trIT4" class="noborder" style="height: 30px;">
                    <td colspan="2">
                        <textarea id="txtIDx10" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td rowspan="4">财务部审批意见</td>
                    <td colspan="2" class="tl PL10" style="height: 0px;">
                        <div style="display: none">
                            <input id="rdbYesIDx11" type="radio" name="agree11" checked="checked" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label><input id="rdbOtherIDx11" type="radio" name="agree11" /><label for="rdbOtherIDx11">其他意见</label>
                        </div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td colspan="2">
                        <textarea id="txtIDx11" rows="6" style="width: 98%; overflow: auto; display: none"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx11">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td colspan="2" class="tl PL10" style="">
                        <input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label><input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label><input id="rdbOtherIDx12" type="radio" name="agree12" /><label for="rdbOtherIDx12">其他意见</label>
                        <asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td colspan="2">
                        <textarea id="txtIDx12" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx12">_________</span></div>
                    </td>
                </tr>
            </table>
            <!--打印正文结束-->
        </div>
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
            <%--        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
            <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
            <%--            </ContentTemplate>
        </asp:UpdatePanel>--%>

            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" Height="17px" />
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
            <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
            <input type="button" id="btnSignSave" value="标注已留档" onclick="saveRemark();" style="display: none;" />
            <input type="button" id="btnSignSaveForFinance" value="标注已留档" onclick="saveRemarkForFinance();" style="display: none;" />
            <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
            <%--<input type="button" id="btnGoBack" value="返回" onclick="window.history.go(-1);" />--%>
            <%--<input type="button" id="btnGoBack" value="返回" onclick="window.location='/Apply/Apply_Search.aspx';" />--%>
            <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
            <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
            <asp:HiddenField ID="hdIsAgree" runat="server" />
            <asp:HiddenField ID="hdSuggestion" runat="server" />
            <input type="hidden" id="hdDetail" runat="server" />

            <asp:HiddenField ID="hdIsIT" runat="server" />

            <asp:HiddenField ID="hdCancelSign" runat="server" />
            <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
        </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=sbJS.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

