<%@ Page validateRequest="false" Title="报废申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Scrap_Detail.aspx.cs" Inherits="Apply_Scrap_Apply_Scrap_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #tbDetail input[readonly="readonly"]{background:rgb(227, 227, 227)}
    </style>
    <script type="text/javascript" src="../../Script/common.js"></script>
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

            for (var x = 1; x <= i; x++) {
                $("#txtBuyTime"+x).datepicker({
                    showButtonPanel: true,
                    showOtherMonths: true,
                    selectOtherMonths: true,
                    changeMonth: true,
                    changeYear: true
                });
            }

            <%=SbJsEX.ToString() %>
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
   
        
        function detailjson()
        {
            var array = new Array();
            $("#tbDetail tr").each(function () {
                //alert("进来了");
                var AssetID = $(this).find("input[name='AssetID']").val();
                if (AssetID == "" || AssetID == undefined)
                { return true;}
                var AssetTS = $(this).find("input[name='AssetTS']").val();                             //归属
                var AssetClasses = $(this).find("input[name='AssetClasses']").val();                       //资产名称
                var AssetAssetNo = $(this).find("input[name='AssetAssetNo']").val();                  //财务编码
                var AssetType = $(this).find("input[name='AssetType']").val();                                 //规格型号
                var AssetRecordedTime = $(this).find("input[name='AssetRecordedTime']").val();        //入账时间
                var AssetNumber = $(this).find("input[name='AssetNumber']").val();           //数量
                var AssetSurplusValue = $(this).find("input[name='AssetSurplusValue']").val();//折旧摊分剩余费用
                //生成json
                data = { "AssetID": AssetID, "AssetType": AssetType, "AssetClasses": AssetClasses, "AssetAssetNo": AssetAssetNo, "AssetTS": AssetTS, "AssetRecordedTime": AssetRecordedTime, "AssetNumber": AssetNumber, "AssetSurplusValue": AssetSurplusValue };
                array.push(data);//插入
            });

            $("#<%=this.hidDetail.ClientID %>").val(Obj2str(array)); //common.js 方法
        }
        function check() {
            if($("#<%=hidDetail.ClientID%>").val()=="" && isNewApply){
                alert("请选择相关的资产。");
                $("#btnSelect").focus();
                return false;
            }
            detailjson();

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
            if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='6'||idx=='7'||idx=='8'||idx=='9'){//789
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
            
            if(idx!='3'&&idx!='4'&&idx!='5'&&idx!='7'){
                if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {
                    alert("由于您不同意该申请，必须填写不同意的原因。");
                    return;
                }
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

        //选择资产
        function SelectAsset() {
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("请先填写部门或分行名称。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
                return false;
            }
            var url = "Apply_DetailAssetNew.aspx?mainID=<%=MainID %>&Asset_Dpm=" + escape($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())) +"&flag=CanEdit";
            var sReturnValue = window.showModalDialog(url, "", "dialogHeight="+screen.height+"px;dialogWidth="+screen.width+"px;");

            if($.trim(sReturnValue) != "")
            {
                var dataObj=eval("("+sReturnValue+")");//转换为json对象
                if(dataObj.length > 5)
                {
                    //大于5件资产
                    //显示详见附件
                    $("#tbDetail").html("");
                    $("#DetailAsset").show();
                }
                else
                {
                    //少于5件资产
                    var html = "";
                    for(var i = 0 ; i < dataObj.length ; i++)
                    {
                        html += binddetailrow(dataObj[i],"False");
                    }
                    DetailDateBind();
                    $("#tbDetail").html(html);
                    $("#DetailAsset").hide();
                }
                $("#<%=this.hidDetail.ClientID%>").val(sReturnValue);
                return;
            }
        }

        //修改资产
        function EditAsset() {
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("请先填写部门或分行名称。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
                return false;
            }
            var url = "Apply_DetailAssetEdit.aspx?mainID=<%=MainID %>&Asset_Dpm=" + escape($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())) +"&flag=CanEdit";
            var sReturnValue = window.showModalDialog(url, "", "dialogHeight="+screen.height+"px;dialogWidth="+screen.width+"px;");

            if($.trim(sReturnValue) != "")
            {
                var dataObj=eval("("+sReturnValue+")");//转换为json对象
                if(dataObj.length > 5)
                {
                    //大于5件资产
                    //显示详见附件
                    $("#tbDetail").html("");
                    $("#DetailAsset").show();
                }
                else
                {
                    //少于5件资产
                    var html = "";
                    for(var i = 0 ; i < dataObj.length ; i++)
                    {
                        html += binddetailrow(dataObj[i],"True");
                    }
                    DetailDateBind();

                    $("#tbDetail").html(html);
                    $("#divUploadDetails").hide();
                    $("#DetailAsset").hide();
                }
                $("#<%=this.hidDetail.ClientID%>").val(sReturnValue);
                return;
            }
        }

        //查看资产
        function LookAsset()
        {
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("请先填写部门或分行名称。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
                return false;
            }
            var url = "Apply_DetailAssetNew.aspx?mainID=<%=MainID %>&Asset_Dpm=" + escape($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())) +"&flag=NoEdit";
            var sReturnValue = window.showModalDialog(url, "", "dialogHeight="+screen.height+"px;dialogWidth="+screen.width+"px;");
        }

        //绑定资产
        function binddetailrow(obj,edit)
        {
            var isdisabled = "";
            if(edit == "False")
            {
                isdisabled = "readonly='readonly'";
            }

            var html = '<tr class="noborder">';
            html +=      '<td class="tl PL10" style="width:200px">';
            html +=      '*报废物品<input type="text" value="' + obj.AssetClasses + '" name="AssetClasses" style="width: 120px;border: 1px solid rgb(152, 184, 181);"  ' + isdisabled + '>';
            html +=      "<input type='hidden' name='AssetID' value='" + obj.AssetID + "' />"
            html +=      "<input type='hidden' name='AssetType' value='" + obj.AssetType + "' />"
            html +=      '<select onchange="checkasset(this,1);" style="width: 120px; display: none; border: 1px solid rgb(152, 184, 181);"></select><br>';

            html +=      '*数　　量';
            html +=     "<input name='AssetNumber' value='" + obj.AssetNumber + "' type='text' onblur='checknum(this,1);' onkeyup=\"this.value=this.value.replace(/[^\d|//.]/g,'');\" style='width:120px;border:1px solid rgb(152,184,181);' " + isdisabled + " ><br>";

            html +=      '购买时间';
            html +=      "<input value='" + obj.AssetRecordedTime + "' name='AssetRecordedTime' type='text' " + isdisabled + " style='width:120px;border:1px solid rgb(152,184,181);'>";
            html +=      "</td>";

            html +=      '<td class="tl PL10">';
            html +=      '*财　务　编　号';
            html +=      '<input value=' + obj.AssetAssetNo + ' name="AssetAssetNo" type="text" style="width: 190px; border: 1px solid rgb(152, 184, 181);" readonly="readonly" ><br>';

            html +=      '*规　格　型　号';
            html +=      '<input value=' + obj.AssetTS + ' name="AssetTS" type="text" style="width: 190px; border: 1px solid rgb(152, 184, 181);" ' + isdisabled + '><br>';

            html +=      '折旧摊分剩余费用';
            html +=      "<input name='AssetSurplusValue' value='" + obj.AssetSurplusValue + "' type='text' " + isdisabled + " style='width:178px;border:1px solid rgb(152, 184, 181);'>";
            html +=      '</td>';
            html +=      '</tr>';

            return html;
        }
        function PageInit()
        {
            var canedit = "<%=CanEdit%>";
            var l = $("#<%=this.hidDetail.ClientID%>").val() == "" ? [] : $("#<%=this.hidDetail.ClientID%>").val().evalJSON();//string.evalJSON(); common.js 方法
            var html = "";
            //alert(l.length);
            if(l.length <= 5)
            {
                var j = l.length;
                for(var i=0;i< l.length ; i++)
                {
                    html += binddetailrow(l[i],canedit);
                }
                $("#tbDetail").html(html);
                $("#DetailAsset").hide();
                
                DetailDateBind();
            }
            else
            {
                $("#tbDetail").html("");
                $("#DetailAsset").show();
            }
            if(canedit == "True")
            {
                $("#btnSelect").show();
            }
        }

        //资产时间空间绑定
        function DetailDateBind()
        {
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
            $("#tbDetail input[name='AssetRecordedTime']").each(function(){
                if($(this).attr("readonly") != "readonly")
                {
                    $(this).datepicker({
                        showButtonPanel: true,
                        showOtherMonths: true,
                        selectOtherMonths: true,
                        changeMonth: true,
                        changeYear: true
                    });
                }
            });
        }
    </script>
    <style type="text/css">
        .sp{cursor:pointer;color:blue;}
        .sp:link{color:blue;}
        .sp:visited{color:blue;}
        .sp:hover{color: blue;}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align:center; width:840px; margin:0 auto;'>
        <%=SbFlow.ToString() %>
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
                            <td colspan="3" style="text-align:left">
                                <table id="tbDetail" class='inside' width='100%'>
                                    <%=SbHtml.ToString()%>
                                </table>
                                <div id="spal" style="display: none; color: #FF0000; margin-top: 7px;">注意：系统将在点击“保存”后更新明细表<br /></div>
                                <%--<input type="button" id="btnAddRow" value="新增一行" onclick="addRow();" style=" float:left; display:none"/>
                                <input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>--%>
                                <%if(IsNewApply) {%>
                                <input type="button" id="btnSelect" value="选择" onclick="SelectAsset();" style="display: none; margin-left: 10px; margin-bottom: 5px;" />
                                <%}
                                  else if (CanEdit)
                                  { %>
                                <input type="button" id="btnSelect" value="选择" onclick="EditAsset();" style="display: none; margin-left: 10px; margin-bottom: 5px;" />
                                <%} %>
                                <div id="DetailAsset" style="text-align: left; margin-left: 10px; display: none; margin-top:30px;">详见：<a onclick="LookAsset();return false;" class="sp" target="_blank" style="font-size: 20px">报废资产明细表</a></div>

                                <%--<div id="divUploadDetails" style="text-align: left; margin-left: 10px; display: none;">
                                    <div id="lkSpUl" style="font-size: 20px; margin-top: 5px">
                                        详见：<a href='javascript:;' onclick="LookAsset();return false;" target="_blank" style="font-size: 20px" class="sp">报废资产明细表</a>
                                    </div>
                                </div>--%>
                                <asp:HiddenField ID="hidDetail" runat="server" />
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
                        <tr class="noborder" style="height:30px; ">
                            <td rowspan="2">行政部经办人</td>
                            <td colspan="3" style=" " class="tl PL10" >
                                <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><asp:Button runat="server" ID="btnRemindPhoto" Text="通知上传照片" OnClick="btnRemindPhoto_Click" Visible="false" />　<asp:Button runat="server" ID="btnRemindScrap" Text="通知上传报废证明" OnClick="btnRemindScrap_Click" Visible="false" /><br />
                                <asp:CheckBox ID="cbkToFinance" runat="server" Text="转财务部计算净值" style="margin-right:10px;" Visible="false" /><asp:CheckBox ID="cbkToIT" runat="server" Text="转资讯科技部审核" style="margin-right:10px;" Visible="false" />
                                <asp:LinkButton ID="lbAddLg1" runat="server" Visible="False" OnClick="lbAddLg_Click">添加后勤事务部审批</asp:LinkButton>　
                                <asp:LinkButton ID="lbDelLg1" runat="server" Visible="False" OnClick="lbDelLg_Click">删除后勤事务部审批</asp:LinkButton>
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
                                <asp:TextBox ID="txtSuc" runat="server" Width="140px"></asp:TextBox>
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
                             <asp:LinkButton ID="lbAddLg2" runat="server" Visible="False" OnClick="lbAddLg_Click">添加后勤事务部审批</asp:LinkButton>　
                             <asp:LinkButton ID="lbDelLg2" runat="server" Visible="False" OnClick="lbDelLg_Click">删除后勤事务部审批</asp:LinkButton><br />
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx13" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx13" value="签署意见" onclick="sign('13')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx13">_________</span></div></td>                            
                         </tr>
                         <tr class="noborder" style="height:30px; ">
                            <td rowspan="4" >财务部审批意见</td>
                            <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx14" type="radio" name="agree14" /><label for="rdbYesIDx14">同意</label><input id="rdbNoIDx14" type="radio" name="agree14" /><label for="rdbNoIDx14">不同意</label><input id="rdbOtherIDx14" type="radio" name="agree14" /><label for="rdbOtherIDx14">其他意见</label>
                                <asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx14" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx14" value="签署意见" onclick="sign('14')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx14">_________</span></div></td>       
                         </tr>
                         <tr class="noborder" style="height:30px; ">
                         <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx15" type="radio" name="agree15" /><label for="rdbYesIDx15">同意</label><input id="rdbNoIDx15" type="radio" name="agree15" /><label for="rdbNoIDx15">不同意</label><input id="rdbOtherIDx15" type="radio" name="agree15" /><label for="rdbOtherIDx15">其他意见</label>
                            </td>       
                         </tr>
                         <tr  class="noborder" style="height:30px; ">
                            <td colspan="3"><textarea id="txtIDx15" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx15" value="签署意见" onclick="sign('15')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx15">_________</span></div></td>                            
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
                                <input id="rdbYesIDx16" type="radio" name="agree16" /><label for="rdbYesIDx16">同意</label><input id="rdbNoIDx16" type="radio" name="agree16" /><label for="rdbNoIDx16">不同意<input id="rdbOtherIDx16" type="radio" name="agree16" value="1" /><label for="rdbOtherIDx16">其他意见</label></label>
                                　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                            </td>       
                         </tr>
                         <tr id="trLogistics2" class="noborder" style="height:30px; display:none;">
                            <td colspan="3">
                                <textarea id="txtIDx16" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx16" value="签署意见" onclick="sign('16')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx16">_________</span></div>
                            </td>
                         </tr>
                        
                        <tr id="trManager1" class="noborder" style="height:30px; display:none;">
                            <td rowspan="2" >董事总经理批示</td>
                            <td colspan="3" class="tl PL10" style=" " >
                                <input id="rdbYesIDx17" type="radio" name="agree17" /><label for="rdbYesIDx17">同意</label><input id="rdbNoIDx17" type="radio" name="agree17" /><label for="rdbNoIDx17">不同意</label>
                                <input id="rdbOtherIDx17" type="radio" name="agree17" /><label for="rdbOtherIDx17">其他意见</label><br />
                            </td>       
                         </tr>
                         <tr id="trManager2" class="noborder" style="height:30px; display:none;">
                            <td colspan="3">
                                <textarea id="txtIDx17" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx17" value="签署意见" onclick="sign('17')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx17">_________</span></div>
                            </td>
                         </tr>
                         <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                             <td >后勤事务部批示<br />
                                 <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
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
                <%--<input type="hidden" id="hdDetail" runat="server" />--%>
                    <input type="hidden" id="hdDetail2" runat="server" value="" />
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
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("OfficeAutomation_Document_Scrap_Detail_AssetName") %>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("OfficeAutomation_Document_Scrap_Detail_AssetTag") %>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("OfficeAutomation_Document_Scrap_Detail_SurplusValue") %><br />
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
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        PageInit();
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

