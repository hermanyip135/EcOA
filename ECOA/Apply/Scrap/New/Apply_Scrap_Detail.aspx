<%@ Page validateRequest="false" Title="报废申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Scrap_Detail.aspx.cs" Inherits="Apply_Scrap_Apply_Scrap_Detail" %>

<%@ Register src="../../../Common/FlowShow.ascx" tagname="FlowShow" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        var i = 1;

        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }

        //var jATJSON = <%//=SbAtJson.ToString() %>;
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

            $("[id*=btnRemindPhoto]").css({
                "background-image": "url(/Images/btnRemindPhoto1.png)",
                "height": "25px", 
                "width": "113px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnRemindPhoto]").mousedown(function () { $(this).css("background-image", "url(/Images/btnRemindPhoto2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnRemindPhoto1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnRemindPhoto1.png)"); });

            $("[id*=btnSaveSurplusValueNotify]").css({
                "background-image": "url(/Images/SaveSurplusValueNotify1.png)",
                "height": "25px", 
                "width": "122px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnSaveSurplusValueNotify]").mousedown(function () { $(this).css("background-image", "url(/Images/SaveSurplusValueNotify2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/SaveSurplusValueNotify1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/SaveSurplusValueNotify1.png)"); });

            $("[id*=btnRemindScrap]").css({
                "background-image": "url(/Images/btnRemindScrap1.png)",
                "height": "25px", 
                "width": "143px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnRemindScrap]").mousedown(function () { $(this).css("background-image", "url(/Images/btnRemindScrap2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnRemindScrap1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnRemindScrap1.png)"); });

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




            $("[id*=btnRemindUploadedPhoto]").css({
                "background-image": "url(/Images/btnBusineUploadedPhoto1.png)",
                "height": "36px", 
                "width": "249px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnRemindUploadedPhoto]").mousedown(function () { $(this).css("background-image", "url(/Images/btnBusineUploadedPhoto2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnBusineUploadedPhoto1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnBusineUploadedPhoto1.png)"); });

            $("[id*=btnRemindUploadedPhoto2]").css({
                "background-image": "url(/Images/btnScuUploadedPhoto1.png)",
                "height": "36px", 
                "width": "251px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnRemindUploadedPhoto2]").mousedown(function () { $(this).css("background-image", "url(/Images/btnScuUploadedPhoto2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnScuUploadedPhoto1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnScuUploadedPhoto1.png)"); });

            //$( "#tabs" ).tabs();

            $("#Scarp_z").mousedown(function () { 
                $(this).css("background-image", "url(/Images/scarp_z2.png)"); 
                $("#Scarp_i").css("background-image", "url(/Images/scarp_i1.png)"); 
                $("#Scarp_m").css("background-image", "url(/Images/scarp_m1.png)"); 
            });
            $("#Scarp_i").mousedown(function () { 
                $(this).css("background-image", "url(/Images/scarp_i2.png)"); 
                $("#Scarp_z").css("background-image", "url(/Images/scarp_z1.png)"); 
                $("#Scarp_m").css("background-image", "url(/Images/scarp_m1.png)"); 
            });
            $("#Scarp_m").mousedown(function () { 
                $(this).css("background-image", "url(/Images/scarp_m2.png)"); 
                $("#Scarp_i").css("background-image", "url(/Images/scarp_i1.png)"); 
                $("#Scarp_z").css("background-image", "url(/Images/scarp_z1.png)"); 
            });

            i = $("#tbDetail tr").length;
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
            $("#<%=txtApplyDate.ClientID %>").datepicker({
                    showButtonPanel: true,
                    showOtherMonths: true,
                    selectOtherMonths: true,
                    changeMonth: true,
                    changeYear: true
            });
            
            $("#<%=txtDispatchDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {
                    //SetOldF();
                }
            });

            $("#<%=txtDispatchDepartment.ClientID%>").blur(function(){
                //SetOldF();
            });

            for (var x = 1; x <= i; x++) {
                //var ddlAsset=document.getElementById("ddlAsset"+ x);
                //ddlAsset.options[0]=new Option("请选择",0);
                //for(var y=0;y<jATJSON.length;y++) {
                //    ddlAsset.options[y+1]=new Option(jATJSON[y].value,jATJSON[y].id);
                //}
                
                $("#txtBuyTime"+x).datepicker({
                    showButtonPanel: true,
                    showOtherMonths: true,
                    selectOtherMonths: true,
                    changeMonth: true,
                    changeYear: true
                });
            }
            //SetOldF();
            <%=DdlSelect %>
            <%=SbJsEX.ToString() %>
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function SetOldF(){//*-
            if($("#<%=txtDispatchDepartment.ClientID%>").val() == "总部仓库" || $("#<%=txtDispatchDepartment.ClientID%>").val() == "芳村仓库"){
                $("#btnAddRow").show();
                $("#btnDeleteRow").show();
                $("#btnSelect").hide();

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
                alert("页面上不可新增超过5项报废资产，请以附件形式上传。");
                return;
            }   
            
            i++;
            var html;
            if(new Date($("#<%=txtApplyDate.ClientID%>").val().replace(/\-/g, "\/")) <= new Date('<%=CommonConst.ASSET_OLD_TIME%>'.replace(/\-/g, "\/")))
            {
                html = "<tr id='trDetail" + i + "' class=\"noborder\">"
                + "     <td class=\"tl PL10\" style=\"width:200px\">"
                + "     <input type='hidden' id='hidAssetID" + i + "' />"
                + "            *报废物品 <select id=\"ddlAsset" + i + "\" style=\"width:120px;\" onchange=\"checkasset(this," + i + ");\"></select><br />"
                + "            *数　　量 <input type=\"text\" id=\"txtNumber" + i + "\" style=\"width:120px;\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"checknum(this," + i + ");\"/><br />"
                + "            &nbsp;&nbsp;购买时间 <input type=\"text\" id=\"txtBuyTime" + i + "\" style=\"width:120px; background-color:#e3e3e3;\" disabled=\"disabled\" onblur=\"if($('#txtBuyTime" + i + "').val()=='详见附件'){$('#txtRemainingCosts" + i + "').val('详见附件');}\"/>"
                + "    </td>"
                + "     <td class=\"tl PL10\">"
                + "            *财　务　编　号 <input type=\"text\" id=\"txtATag" + i + "\" style=\"width:190px;*width:175px;\"/><br />"
                + "            *规　格　型　号 <input type=\"text\" id=\"txtModel" + i + "\" style=\"width:190px;*width:175px;\"/><br />"
                + "            &nbsp;&nbsp;折旧摊分剩余费用 <input type=\"text\" id=\"txtRemainingCosts" + i + "\" style=\"width:178px;*width:163px; background-color:#e3e3e3;\" disabled=\"disabled\" onblur=\"if($('#txtRemainingCosts" + i + "').val()=='详见附件'){$('#txtBuyTime" + i + "').val('详见附件');}\"/>"
                + "    </td>" 
                + "</tr>";
            }
            else
            {
                html = "<tr id='trDetail" + i + "' class=\"noborder\">"
                + "     <td class=\"tl PL10\" style=\"width:200px\">"
                + "     <input type='hidden' id='hidAssetID" + i + "' />"
                + "            *报废物品 <input type=\"text\" id=\"txtAsset" + i + "\" style=\"width:120px;\"/><select id=\"ddlAsset" + i + "\" style=\"width:120px;display:none;\" onchange=\"checkasset(this," + i + ");\"></select><br />"
                + "            *数　　量 <input type=\"text\" id=\"txtNumber" + i + "\" style=\"width:120px;\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"checknum(this," + i + ");\"/><br />"
                + "            &nbsp;&nbsp;购买时间 <input type=\"text\" id=\"txtBuyTime" + i + "\" style=\"width:120px; background-color:#e3e3e3;\" disabled=\"disabled\" onblur=\"if($('#txtBuyTime" + i + "').val()=='详见附件'){$('#txtRemainingCosts" + i + "').val('详见附件');}\"/>"
                + "    </td>"
                + "     <td class=\"tl PL10\">"
                + "            *财　务　编　号 <input type=\"text\" id=\"txtATag" + i + "\" style=\"width:190px;*width:175px;\"/><br />"
                + "            *规　格　型　号 <input type=\"text\" id=\"txtModel" + i + "\" style=\"width:190px;*width:175px;\"/><br />"
                + "            &nbsp;&nbsp;折旧摊分剩余费用 <input type=\"text\" id=\"txtRemainingCosts" + i + "\" style=\"width:178px;*width:163px; background-color:#e3e3e3;\" disabled=\"disabled\" onblur=\"if($('#txtRemainingCosts" + i + "').val()=='详见附件'){$('#txtBuyTime" + i + "').val('详见附件');}\"/>"
                + "    </td>" 
                + "</tr>";
            }
            $("#tbDetail").append(html);
            
            //var ddlAsset=document.getElementById("ddlAsset"+ i);
            //ddlAsset.options[0]=new Option("请选择",0);
            //for(var y=0;y<jATJSON.length;y++) {
            //    ddlAsset.options[y+1]=new Option(jATJSON[y].value,jATJSON[y].id);
            //}
            
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
        
        function check() {
            if($("#tbDetail tr").size() == 0 && isNewApply){
                alert("请选择相关的资产。");
                $("#btnSelect").focus();
                return false;
            }

            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("部门或分行名称不可为空。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApplicant.ClientID %>").val())=="") {
                alert("填写人不可为空。");
                $("#<%=txtApplicant.ClientID %>").focus();
                return false;
            }
            
            if(!checkdate($("#<%=txtApplyDate.ClientID %>").val())){
                alert("递交日期格式错误，请按以下格式输入日期:\n2013-07-22");
                $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtScrapReason.ClientID %>").val())=="") {
                alert("申请报废原因不可为空。");
                $("#<%=txtScrapReason.ClientID %>").focus();
                return false;
            }
              
            var data = "";
            var flag=true;
            
            ////如果详细只有一行，且该行为空
            //if($("#tbDetail tr").size() == 1 && $("#ddlAsset1").val() == "0" && $.trim($("#txtATag1").val()) == "" && $.trim($("#txtNumber1").val()) == "" && $.trim($("#txtModel1").val()) == "")
            //    data="||";
            //else{
                $("#tbDetail tr").each(function(i) {
                    var n=i+1;
                    if(new Date($("#<%=txtApplyDate.ClientID%>").val().replace(/\-/g, "\/")) <= new Date('<%=CommonConst.ASSET_OLD_TIME%>'.replace(/\-/g, "\/"))){
                        if ($("#ddlAsset" + n).val() == "0") {
                            alert("第" + n + "个报废资产中的报废物品必须选择。");
                            $("#ddlAsset" + n).focus();
                            flag= false;
                            return;
                        }
                    }
                
                    if ($.trim($("#txtATag" + n).val()) == ""){
                        alert("第" + n + "个报废资产中的财务编号必须填写。");
                        $("#txtATag" + n).focus();
                        flag= false;
                        return;
                    }
                    if($.trim($("#txtNumber" + n).val()) == "" ){
                        alert("第" + n + "个报废资产中的数量必须填写。");
                        $("#txtNumber" + n).focus();
                        flag= false;
                        return;
                    }
                    //if($.trim($("#txtModel" + n).val()) == "") {
                    //    alert("第" + n + "个报废资产中的规格型号必须填写。");
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
                        + "&&" + $.trim($("#txtModel" + n).val())
                        + "&&" + $.trim($("#txtBuyTime" + n).val())
                        + "&&" + $.trim($("#txtRemainingCosts" + n).val())
                        + "&&" + $.trim($("#hidAssetID" + n).val())
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
            //else if(n.value<=5 && $("#txtATag" + num).val()=='详见附件' && $("#txtModel" + num).val()=='详见附件')
            //{
            //    $("#txtATag" + num).val('');
            //    $("#txtModel" + num).val('');
            //}
        }

        function checkasset(n,num) {
            if(n.children[n.selectedIndex].text=='详见附件')
            {
                $("#txtATag" + num).val('详见附件');
                $("#txtModel" + num).val('详见附件');
            }
        }

        function checkAssign() {
            if($.trim($("#<%=ddlFollower.ClientID %>").val())=="") {
                alert("请先选择下派的跟进人！");
                return false;
            }
              
            return true;
        }

        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
                    if(sReturnValue=='success')
                        window.location='Apply_Scrap_Detail.aspx?MainID=<%=MainID %>';
        }

        function uploadDetails() { //M_AssetAlter：20150827
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("请先填写部门或分行名。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
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
            var win=window.showModalDialog("Apply_Scrap_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_Scrap_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(idx!='14'&&idx!='15'&&idx!='17'&&idx!='18'&&idx!='130'&&idx!='131'||idx=='16'){
            //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='6'||idx=='7'||idx=='8'||idx=='9'){//789
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

        function signex(idx) {
            if(!$("#rdbYesIDxEX"+idx).prop("checked")&&!$("#rdbNoIDxEX"+idx).prop("checked")) {
                alert("请确定是否同意！");
                return;
            }
                
            if(confirm("是否确认审核？"))
            {
                if($("#rdbYesIDxEX"+idx).prop("checked"))
                    $("#<%=hdIsAgree.ClientID %>").val("1");
                else if($("#rdbNoIDxEX"+idx).prop("checked"))
                    $("#<%=hdIsAgree.ClientID %>").val("0");
                else if($("#rdbOtherIDxEX"+idx).prop("checked"))
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
                 data: "action=savescrapremark&id=<%=ID %>&remark=√",
                 success: function(info) {
                     if (info == 'success')
                         alert('标记成功');
                     else
                         alert('标记失败');
                 }
             });
         }
        
        function saveRemarkForFinance() {
            $.ajax({
                url: "/Ajax/Apply_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=savescrapremark&id=<%=ID %>&remark=★",
                success: function(info) {
                    if (info == 'success')
                        alert('标记成功');
                    else
                        alert('标记失败');
                }
            });
        }

        function saveSurplusValueNotify() {
            var notify=$.trim($('#<%=txtSurplusValueNotify.ClientID%>').val());
            if (notify == "")
                alert("请填写净值知会函内容");
            else
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: "action=saveSurplusValueNotify&id=<%=ID %>&surplusValueNotify=" + notify,
                    success: function(info) {
                        if (info == 'success')
                            alert('保存净值知会函成功');
                        else
                            alert('保存净值知会函失败');
                    }
                });

            return false;
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
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+16,
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

        function LookAsset(){
            if($("#<%=FlowStateID.ClientID %>").val()!=""){
                var url = "/Apply/Scrap/New/Scrap_Apply_Asset.aspx?mainID=<%=MainID %>";
                window.showModalDialog(url, "", "dialogHeight="+screen.height+"px;dialogWidth="+screen.width+"px;"); 
                return;
            }
        }

        function SelectAsset() { //20150519：M_AssetSelt
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("请先填写部门或分行名称。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
                return false;
            }
            
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align:center; width:840px; margin:0 auto;'>
        <%=SbFlow.ToString() %>
        <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所有的流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        <div id="tabs">
            <ul id="ulTabs" style="display:none;">
                <li id="liTabs1" style="border:none;"><a id="Scarp_m" href="#tabs-1" style="background-image: url('/Images/scarp_m1.png');  border:none;width: 61px; height: 17px;"></a></li>
                <li id="liTabs2" style="display:none; border:none;"><a id="Scarp_z" href="#tabs-2" style="background-image: url('/Images/scarp_z1.png');  border:none;width: 61px; height: 17px;"></a></li>
                <li id="liTabs3" style="display:none; border:none;"><a id="Scarp_i" href="#tabs-3" style="background-image: url('/Images/scarp_i1.png');  border:none;width: 61px; height: 17px;"></a></li>
            </ul>
            <div id="tabs-1">
                <!--打印正文开始-->
                <div style='text-align:center'>            
                    <h1>广东中原地产代理有限公司</h1>
                    <h1>报废申请表</h1>
                    <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
                    <div id="snum" style="width: 640px; margin: 0 auto;"></div>
                    <table id="tbAround"  width='640px'>
                        <tr>
                            <td style="width:120px;">*部门或分行名称</td>
                            <td class="tl PL10" style="width:200px;"><asp:TextBox ID="txtDispatchDepartment" runat="server"></asp:TextBox></td>
                            <td colspan="2" style="background-color:#e3e3e3; width: 330px;" class="tl PL10">文档编码(自动生成)：<%=SerialNumber %></td>
                        </tr>
                        <tr>
                            <td>*填写人</td>
                            <td class="tl PL10"><asp:TextBox ID="txtApplicant" runat="server"></asp:TextBox></td>
                            <td style="width:120px;">*递交时间</td>
                            <td class="tl PL10"><asp:TextBox ID="txtApplyDate" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="noborder">
                            <td rowspan="5" >报废详细情况</td>
                            <td class="tl PL10">报废物品使用人信息</td>
                            <td colspan="2"></td>
                        </tr>
                        <tr class="noborder">
                            <td colspan="3">姓名 <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox> 职称及所属级别 <asp:TextBox ID="txtUserTeam" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table id="tbDetail" class='inside' width='100%'>
                                    <%=SbHtml.ToString()%>
                                </table>
                            <%--    <input type="button" id="btnAddRow" value="新增一行" onclick="addRow();" style=" float:left; display:none"/>
                                <input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>--%>
                            <%--    <input type="button" id="btnSelect" value="选择" onclick="SelectAsset();" style="float: left; display: none; margin-left: 10px; margin-bottom: 5px;" />--%>
                                
                                 <asp:Button  Text="选择" runat="server" ID="btnSelect" OnClientClick="javascript:return SelectAsset()" OnClick="btnTempSave_Click"/>
                        <asp:Button  Text="查看资产详情" runat="server" ID="btnLook"  OnClick="btnToAsset_Click" Height="25px" />


                                <asp:Button ID="btnAssetToPDF" runat="server" Text="资产详情另存为PDF" Visible="false"  OnClick="btnAssetToPDF_Click" Height="25px" />
                                <asp:HiddenField runat="server"  ID="FlowStateID"/>
                    <%--            <div id="divUploadDetails" style="text-align: left; margin-left: 10px;">
                                    <div id="lkSpUl" style="font-size: 20px; margin-top: 5px; display: none;">
                                        详见：<a href='<%=ConfigurationManager.AppSettings["EcoaFileURL"]%><%=SpAttachPath.ToString() %>' target="_blank" style="font-size: 20px" class="sp">报废资产明细表</a>
                                    </div>
                                    <div id="SuSpUl" style="display: none; margin-top: 30px;">
                                        如需报废的资产超过5件以上，请按此格式（<a href="/资料/报废资产明细表.xls">EXCEL版空白明细表</a>)下载，编辑后
                                        <asp:button id="btnLoadPath" runat="server" text="上传" onclientclick="return uploadDetails();" style="margin-left: 5px;" OnClick="btnUploadDetails_Click"/>
                                        ，将自动导入，无需再选择资产。
                                        <input type="hidden" id="hdFilePath" runat="server" /><br />
                                    </div>
                                </div>--%>

                            </td>
                        </tr>
                        <tr class="noborder">
                            <td style=" text-align:left; padding-left:10px;">*申请报废原因</td>
                            <td colspan="2"></td>
                        </tr>
                        <tr class="noborder" style="border-bottom: 1px solid #000000;">
                            <td colspan="3"><asp:TextBox ID="txtScrapReason" runat="server" Width="98%" Height="98%" Rows="3" TextMode="MultiLine" style="overflow:auto;"></asp:TextBox></td>
                        </tr>
                        <tr class="noborder" style="height:30px;">
                            <td rowspan="2" >部门主管</td>
                            <td colspan="3" class="tl PL10" style=" ">
                                如果有净值知会函，请先审核净值知会函，再审批报废申请表。<br />
                                <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx4" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div></td>
                        </tr>
                        <tr class="noborder" style="height:30px;">
                            <td rowspan="2" >隶属主管</td>
                            <td colspan="3" class="tl PL10">
                                <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx6" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx6" value="签名" onclick="sign('6')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div></td>
                        </tr>
                        
                        <tr class="noborder" style="height:30px;">
                            <td rowspan="2" >部门负责人</td>
                            <td colspan="3" class="tl PL10">
                                <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx8" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx8" value="签名" onclick="sign('8')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx8">_________</span></div></td>
                        </tr>
                        <tr class="noborder"  style="height:30px; ">
                            <td rowspan="2"  >行政部经办人</td>
                            <td colspan="3" style=" " class="tl PL10" >
                                <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><asp:Button runat="server" ID="btnRemindPhoto" Text="通知上传照片" OnClick="btnRemindPhoto_Click" Visible="false" />　<asp:Button runat="server" ID="btnRemindScrap" Text="通知上传报废证明" OnClick="btnRemindScrap_Click" Visible="false" /><br />
                                <asp:CheckBox ID="cbkToFinance" runat="server" Text="转财务部计算净值" style="margin-right:10px;" Visible="false" /><asp:CheckBox ID="cbkToIT" runat="server" Text="转资讯科技部审核" style="margin-right:10px;" Visible="false" />
                                <asp:LinkButton ID="lbAddLg1" runat="server" Visible="False" OnClick="lbAddLg_Click">添加总经办审批</asp:LinkButton>　
                                <asp:LinkButton ID="lbDelLg1" runat="server" Visible="False" OnClick="lbDelLg_Click">删除总经办审批</asp:LinkButton>
                            </td>       
                         </tr>
                         <tr class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx1" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="check();sign('1');" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div></td>       
                        </tr>
                        <tr id="trMoney1" class="noborder" style="height:30px; ">
                            <td rowspan="2" >财务部经办人</td>
                            <td colspan="3" style=" " class="tl PL10" >
                                <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label>&nbsp;&nbsp;
                                折旧摊分总剩余费用<asp:TextBox ID="txtRemainingsCostsTotal" runat="server" Width="90px"></asp:TextBox>元 
                                <asp:TextBox ID="txtSuc" runat="server" Width="140px"></asp:TextBox><br />
                                <asp:LinkButton ID="lbAddLg3" runat="server" Visible="False" OnClick="lbAddLg_Click">添加总经办审批</asp:LinkButton>　
                                <asp:LinkButton ID="lbDelLg3" runat="server" Visible="False" OnClick="lbDelLg_Click">删除总经办审批</asp:LinkButton><br />
                            </td>       
                         </tr>
                         <tr id="trMoney2" class="noborder" style="height:30px; ">
                            <td colspan="3"><asp:Button runat="server" ID="btnRemindPhoto2" Text="通知上传照片" OnClientClick="check();getSuggestion(2);" OnClick="btnRemindPhoto2_Click" Visible="false" /><br /><textarea id="txtIDx2" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="check();sign('2');" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div></td>       
                         </tr>	
                        <tr id="trIT1" class="noborder" style="height:30px; ">
                            <td rowspan="4" >资讯科技部审批意见</td>
                            <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label>
                                <input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label>
                                <div id="divAssign" style="text-align:left; float:left; display:none;">
                                    转<asp:DropDownList ID="ddlFollower" runat="server"></asp:DropDownList>跟进<asp:Button runat="server" ID="btnAssign" Text="下派" OnClick="btnAssign_Click" OnClientClick="return checkAssign();" />                    
                                </div>
                            </td>       
                         </tr>
                         <tr id="trIT2" class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx10" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div></td>       
                         </tr>	
                         <tr id="trIT3" class="noborder" style="height:30px; ">
                            <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label><input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label>
                                <input id="rdbOtherIDx12" type="radio" name="agree12" /><label for="rdbOtherIDx12">其他意见</label><br />
                            </td>       
                         </tr>
                         <tr id="trIT4" class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx12" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx12">_________</span></div></td>       
                         </tr>
                         <tr class="noborder" style="height:30px; ">
                            <td rowspan="2" >行政部审批意见</td>
                         <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx13" type="radio" name="agree13" /><label for="rdbYesIDx13">同意</label><input id="rdbNoIDx13" type="radio" name="agree13" /><label for="rdbNoIDx13">不同意</label>
                             <input id="rdbOtherIDx13" type="radio" name="agree13" /><label for="rdbOtherIDx13">其他意见</label>　
                             <asp:LinkButton ID="lbAddLg2" runat="server" Visible="FALSE" OnClick="lbAddLg_Click">添加总经办审批</asp:LinkButton>　
                             <asp:LinkButton ID="lbDelLg2" runat="server" Visible="FALSE" OnClick="lbDelLg_Click">删除总经办审批</asp:LinkButton><br />
                             <asp:LinkButton ID="lbAddLg18" runat="server" Visible="FALSE" OnClick="lbAddLg18_Click">添加首席运营官审批</asp:LinkButton>　
                             <asp:LinkButton ID="lbDelLg18" runat="server" Visible="FALSE" OnClick="lbDelLg18_Click">删除首席运营官审批</asp:LinkButton><br />
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx13" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx13" value="签署意见" onclick="sign('13')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx13">_________</span></div></td>                            
                         </tr>
                          <tr id="trManager18" class="noborder" style="height:30px;display:none; ">
                            <td rowspan="2" >首席运营官审批意见</td>
                            <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx18" type="radio" name="agree18" /><label for="rdbYesIDx18">同意</label>
                                <input id="rdbNoIDx18" type="radio" name="agree18" /><label for="rdbNoIDx18">不同意</label>
                                <input id="rdbOtherIDx18" type="radio" name="agree18" /><label for="rdbOtherIDx18">其他意见</label>
                                
                            </td>       
                         </tr>
                         <tr id="trManager19" class="noborder" style="height:30px;display:none;">
                            <td colspan="3">
                                <textarea id="txtIDx18" rows="3" style="width:98%; overflow:auto;"></textarea>
                                <input type="button" id="btnSignIDx18" value="签署意见" onclick="sign('18')" style="display:none;"/>
                                <div class="signdate">日期：<span id="spanDateIDx18">_________</span></div>
                            </td>
                         </tr>
                         <tr class="noborder" style="height:30px; ">
                            <td rowspan="4" >财务部审批意见</td>
                            <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx24" type="radio" name="agree24" /><label for="rdbYesIDx24">同意</label>
                                <input id="rdbNoIDx24" type="radio" name="agree24" /><label for="rdbNoIDx24">不同意</label>
                                <input id="rdbOtherIDx24" type="radio" name="agree24" /><label for="rdbOtherIDx24">其他意见</label>
                                <asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx24" rows="3" style="width:98%; overflow:auto;"></textarea>
                                <input type="button" id="btnSignIDx24" value="签署意见" onclick="sign('24')" style="display:none;"/>
                                <div class="signdate">日期：<span id="spanDateIDx24">_________</span></div></td>       
                         </tr>
                         <tr class="noborder" style="height:30px; ">
                         <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx25" type="radio" name="agree25" /><label for="rdbYesIDx25">同意</label>
                             <input id="rdbNoIDx25" type="radio" name="agree25" /><label for="rdbNoIDx25">不同意</label>
                             <input id="rdbOtherIDx25" type="radio" name="agree25" /><label for="rdbOtherIDx25">其他意见</label>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx25" rows="3" style="width:98%; overflow:auto;"></textarea>
                                <input type="button" id="btnSignIDx25" value="签署意见" onclick="sign('25')" style="display:none;"/>
                                <div class="signdate">日期：<span id="spanDateIDx25">_________</span></div></td>                            
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
                         <tr id="trLogistics1" class="noborder" style="height:30px; display:none;">
                            <td rowspan="2" >后勤事务部批示<br /><asp:Button ID="btnWillEnd2" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
                            <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx26" type="radio" name="agree26" /><label for="rdbYesIDx26">同意</label>
                                <input id="rdbNoIDx26" type="radio" name="agree26" /><label for="rdbNoIDx26">不同意
                                    <input id="rdbOtherIDx26" type="radio" name="agree26" value="1" /><label for="rdbOtherIDx26">其他意见</label></label>
                                　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                            </td>       
                         </tr>
                         <tr id="trLogistics2" class="noborder" style="height:30px; display:none;">
                            <td colspan="3">
                                <textarea id="txtIDx26" rows="3" style="width:98%; overflow:auto;"></textarea>
                                <input type="button" id="btnSignIDx26" value="签署意见" onclick="sign('26')" style="display:none;"/>
                                <div class="signdate">日期：<span id="spanDateIDx26">_________</span></div>
                            </td>
                         </tr>
                        
                        <tr id="trManager1" class="noborder" style="height:30px; display:none;">
                            <td rowspan="2" >董事总经理批示</td>
                            <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx27" type="radio" name="agree27" /><label for="rdbYesIDx27">同意</label>
                                <input id="rdbNoIDx27" type="radio" name="agree27" /><label for="rdbNoIDx27">不同意</label>
                                <input id="rdbOtherIDx27" type="radio" name="agree27" /><label for="rdbOtherIDx27">其他意见</label><br />
                            </td>       
                         </tr>
                         <tr id="trManager2" class="noborder" style="height:30px; display:none;">
                            <td colspan="3">
                                <textarea id="txtIDx27" rows="3" style="width:98%; overflow:auto;"></textarea>
                                <input type="button" id="btnSignIDx27" value="签署意见" onclick="sign('27')" style="display:none;"/>
                                <div class="signdate">日期：<span id="spanDateIDx27">_________</span></div>
                            </td>
                         </tr>
                         <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                             <td >后勤事务部批示<br />
                                 <%--<asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />--%>
                                 <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					        <td colspan="3" class="tl PL10" style=" ">
						        <input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" value="1" /><label for="rdbOtherIDx130">其他意见</label><br />
						        <textarea id="txtIDx130" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					        </td>
				        </tr>
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
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
                
                    </table>
                    <div class="tl MT5 ML10">
                        ﹡如果报废电脑及打印机必须经资讯科技部加具意见。<br />
                        ﹡报废非电脑类资产需附上报废证明，报废证明由维修商开具，需要加盖公章。
                    </div>
                    <!--打印正文结束-->
                </div>
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
                <asp:Button runat="server" ID="btnRemindUploadedPhoto" Text="通知行政部已上传照片" OnClick="btnRemindUploadedPhoto_Click" Visible="false" /><asp:Button runat="server" ID="btnRemindUploadedPhoto2" Text="通知财务部已上传照片" OnClick="btnRemindUploadedPhoto2_Click" Visible="false" />
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
                <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left:5px; display:none;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" onclick="btnDownload_Click" OnClientClick="return checkChecked();" style="margin-left:5px;" Visible="false" />
                <input type="button" id="btnSignSave" value="标注已留档" onclick="saveRemark();" style="display:none;" />
                <input type="button" id="btnSignSaveForFinance" value="标注已留档" onclick="saveRemarkForFinance();" style="display:none;" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display:none;" />
                    <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <%--<input type="button" id="btnGoBack" value="返回" onclick="window.history.go(-1);" />--%>
                <%--<input type="button" id="btnGoBack" value="返回" onclick="window.location='/Apply/Apply_Search.aspx';" />--%>
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click"/>
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" style="display:none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />
                    <asp:HiddenField ID="hdIsIT" runat="server" />
                    <asp:HiddenField ID="hdIsL" runat="server" />
                <input type="hidden" id="hdDetail" runat="server" />
                <input type="hidden" id="hdLogisticsFlow" runat="server" />
                <asp:hiddenfield id="hdCancelSign" runat="server" />
                <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
                    </div>
            </div>
            <div id="tabs-2">
                <!--打印净值知会函开始-->
                <div style='text-align:center;width:640px;margin: 0 auto;'>            
                    <h1><%=txtDispatchDepartment.Text %>净值知会函</h1>
                     <table id="tbAround2" style="width:100%">
                        <tr style="height:30px; ">
                            <td colspan="4" class="tl PL20" >
                                <span style="text-decoration:underline;"><%=txtDispatchDepartment.Text %></span>所需报废的资产为财务查实，资产所剩余的净值如以下所示：<br />
                                <asp:Repeater ID="rptRemainingCosts" runat="server" Visible="false">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("OfficeAutomation_AssetType_Name") %>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("OfficeAutomation_Document_Scrap_Detail_AssetTag") %>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("OfficeAutomation_Document_Scrap_Detail_SurplusValue") %><br />
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:TextBox ID="txtSurplusValueNotify" runat="server" TextMode="MultiLine" Visible="false" style="overflow-y:auto; width:460px;height:200px;margin-left:25px;"></asp:TextBox><br />
                                <asp:Button runat="server" ID="btnSaveSurplusValueNotify" Text="保存净值知会函" OnClientClick="return saveSurplusValueNotify();" Visible="false" />
                                <br /><br />
                                <span style="font-weight:bold;">合共剩值：<asp:Label ID="lblRemainingCostsTotal" runat="server" Text="0"></asp:Label></span><br />
                                如需报废，则该批资产的净值将会在当月或者下月摊分完毕。
                            </td>       
                        </tr>
                         <tr class="noborder" style="height:30px;">
                            <td rowspan="2" >部门主管</td>
                            <td colspan="3" class="tl PL10" style=" ">
                                <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx3" rows="3" style="width:98%; overflow:auto; display:none; "></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div></td>
                        </tr>
                        <tr class="noborder" style="height:30px;">
                            <td rowspan="2" >隶属主管</td>
                            <td colspan="3" class="tl PL10">
                                <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx5" rows="3" style="width:98%; overflow:auto; display:none;"></textarea><input type="button" id="btnSignIDx5" value="签名" onclick="sign('5')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div></td>
                        </tr>
                         <tr class="noborder" style="height:30px;">
                            <td rowspan="2" >部门负责人</td>
                            <td colspan="3" class="tl PL10" >
                                <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx7" rows="3" style="width:98%; overflow:auto; display:none;"></textarea><input type="button" id="btnSignIDx7" value="签名" onclick="sign('7')" style="display:none;z-index:100;"/><div class="signdate">日期：<span id="spanDateIDx7">_________</span></div></td>
                        </tr>
                    </table>
                    <div class="tl MT5 ML10">
                    </div>
                </div>
                <!--打印净值知会函结束-->
                <asp:Button runat="server" ID="btnSave1" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
                <input type="button" id="btnPrint1" value="打印" onclick="myPrint('打印净值知会函开始','打印净值知会函结束');" />
            </div>
            <div id="tabs-3">
                <!--打印报废证明开始-->
                <div style="text-align:center;width:640px;margin: 0 auto;">            
                    <h1 style="text-align:left;">关于<%=txtDispatchDepartment.Text %>报废的建议：</h1>
                     <table id="tbAround2" style="width:100%">
                        <tr class="noborder" style="height:30px; ">
                            <td colspan="2">
                                <textarea id="txtIDx9" rows="20" style="width:98%; overflow:auto;"></textarea>
                                <div style="display:none;">
                                    <input id="rdbYesIDx9" type="radio" name="agree9" checked="checked" /><label for="rdbYesIDx9">同意</label>
                                    <input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label>
                                </div>
                                <input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display:none;"/>
                                <div style="width: 116px; float: right;">日期：<span id="spanDateIDx9">_________</span></div>
                            </td>       
                        </tr>
                        <tr class="noborder" style="height:30px; ">
                            <td rowspan="2" style="">资讯科技部审批意见</td>
                            <td class="tl PL10" style=" " >
                                <input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label>
                                <input id="rdbOtherIDx11" type="radio" name="agree11" /><label for="rdbOtherIDx11">其他意见</label><br />
                            </td>       
                         </tr>
                         <tr class="noborder" style="height:30px; ">
                            <td><textarea id="txtIDx11" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11');" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx11">_________</span></div></td>       
                         </tr>
                    </table>
                    <div class="tl MT5 ML10">
                    </div>
                </div>
                <!--打印报废证明结束-->
                <asp:Button runat="server" ID="btnSave2" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
                <input type="button" id="btnPrint2" value="打印" onclick="myPrint('打印报废证明开始','打印报废证明结束');" />
            </div>
        </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
     
        </script>
</asp:Content>

