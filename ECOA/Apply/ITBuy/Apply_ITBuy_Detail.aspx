<%@ Page validateRequest="false" Title="计算机及相关设备购买申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ITBuy_Detail.aspx.cs" Inherits="Apply_ITBuy_Apply_ITBuy_Detail" %>

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

            var text = document.getElementById("<%=txtReason.ClientID %>");
            autoTextarea(text); //使对话框自适应
            $("[id*=btnAddLogistics]").css({
                "background-image": "url(/Images/btn_ITbuyB1.png)",
                "height": "20px", 
                "width": "275px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnAddLogistics]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_ITbuyB2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_ITbuyB1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_ITbuyB1.png)"); });

            $("#<%=txtDispatchDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {}
            });

            $( "#divEmail" ).dialog({
                autoOpen: false,
                show: {
                    effect: "drop",
                    duration: 1000
                },
                hide: {
                    effect: "drop",
                    duration: 1000
                },
                resizable: false,
                height:270,
                width:300,
                modal: true,
                buttons: {
                    "发送": function() {
                        sendEmail();
                    },
                    "取消": function() {
                        $( this ).dialog( "close" );
                    }
                }
            });

            $( "#btnEmailDiv" ).click(function() {
                $( "#divEmail" ).dialog( "open" );
            });
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function check() {
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("部门/分行名称不可为空。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
                alert("申请编号不可为空。");
                $("#<%=txtApplyID.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtApplyPhone.ClientID %>").val())=="") {
                alert("联系电话不可为空。");
                $("#<%=txtApplyPhone.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtUnit1.ClientID %>").val())!="" && $.trim($("#<%=txtBuy1.ClientID %>").val())=="") {
                alert("申购项目1不可为空。");
                $("#<%=txtBuy1.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtUnit2.ClientID %>").val())!="" && $.trim($("#<%=txtBuy2.ClientID %>").val())=="") {
                alert("申购项目2不可为空。");
                $("#<%=txtBuy2.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtUnit3.ClientID %>").val())!="" && $.trim($("#<%=txtBuy3.ClientID %>").val())=="") {
                alert("申购项目3不可为空。");
                $("#<%=txtBuy3.ClientID %>").focus();
                return false;
            }

            if($("#<%=rdbReplace.ClientID%>").prop("checked")==true && $.trim($("#<%=txtScrapURL.ClientID %>").val())=="") {
                alert("由于申请原因为替换，所以必须附上报废申请表地址。");
                $("#<%=txtScrapURL.ClientID%>").focus();
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
                        window.location='Apply_ITBuy_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_ITBuy_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_ITBuy_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(idx!='11'&&idx!='12'){
            //if(idx=='1'||idx=='2'||idx=='3'||idx=='7'||idx=='8'||idx=='13'||idx=='130'||idx=='131'){//789
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
            
            if(($("#rdbNoIDx"+idx).prop("checked")||$("#rdbOtherIDx"+idx).prop("checked"))&&$.trim($("#txtIDx"+idx).val())=="") {   
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

         var flagScrap=false;

         function saveScrapURL(){
             var url=$.trim($("#<%=txtScrapURL.ClientID%>").val());
             if(url!=''){
                 var index=url.indexOf('MainID');
                 if(index>-1)
                 {
                     var mainid=url.substr(index,43);
                     url="http://"+window.location.host+"/Apply/Scrap/Apply_Scrap_Detail.aspx?"+mainid;
                     $("#aScrap").attr("href",url);
                     $("#aScrap").show();
                     flagScrap=true;
                 }
                 else
                 {
                     alert("请粘贴正确的报废申请表地址！");
                     $("#<%=txtScrapURL.ClientID%>").val('');
                     $("#<%=txtScrapURL.ClientID%>").focus();
                     flagScrap=false;
                 }
             }
         }

        function sendEmail() {
            var remark=$.trim($('#txtEmail').val());
            if(remark=="")
                alert("请填写邮件内容中的设备资料");
            else
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: "action=sendITBuyEmail&id=<%=ID %>&mainid=<%=MainID %>&remark="+$('#txtEmail').val(),
                    success: function(info) {
                        if(info=='success')
                        {
                            alert('邮件发送成功');
                            $("#divEmail").dialog( "close" );
                        }
                        else
                            alert('邮件发送失败');
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
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+13,
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
            //    $("#<%=hdLogisticsFlow.ClientID %>").val(data);
		    //    return true;
            //}
            //else
            //    return false;
        }//987
        //var autoTextarea = function (elem, extra, maxHeight) { //对话框自适应
        //    extra = extra || 0;
        //    var isFirefox = !!document.getBoxObjectFor || 'mozInnerScreenX' in window,
        //    isOpera = !!window.opera && !!window.opera.toString().indexOf('Opera'),
        //            addEvent = function (type, callback) {
        //                elem.addEventListener ?
        //                        elem.addEventListener(type, callback, false) :
        //                        elem.attachEvent('on' + type, callback);
        //            },
        //            getStyle = elem.currentStyle ? function (name) {
        //                var val = elem.currentStyle[name];
 
        //                if (name === 'height' && val.search(/px/i) !== 1) {
        //                    var rect = elem.getBoundingClientRect();
        //                    return rect.bottom - rect.top -
        //                            parseFloat(getStyle('paddingTop')) -
        //                            parseFloat(getStyle('paddingBottom')) + 'px';        
        //                };
 
        //                return val;
        //            } : function (name) {
        //                return getComputedStyle(elem, null)[name];
        //            },
        //            minHeight = parseFloat(getStyle('height'));
 
        //    elem.style.resize = 'none';
 
        //    var change = function () {
        //        var scrollTop, height,
        //                padding = 0,
        //                style = elem.style;
 
        //        if (elem._length === elem.value.length) return;
        //        elem._length = elem.value.length;
 
        //        if (!isFirefox && !isOpera) {
        //            padding = parseInt(getStyle('paddingTop')) + parseInt(getStyle('paddingBottom'));
        //        };
        //        scrollTop = document.body.scrollTop || document.documentElement.scrollTop;
 
        //        elem.style.height = minHeight + 'px';
        //        if (elem.scrollHeight > minHeight) {
        //            if (maxHeight && elem.scrollHeight > maxHeight) {
        //                height = maxHeight - padding;
        //                style.overflowY = 'auto';
        //            } else {
        //                height = elem.scrollHeight - padding;
        //                style.overflowY = 'hidden';
        //            };
        //            style.height = height + extra + 'px';
        //            scrollTop += parseInt(style.height) - elem.currHeight;
        //            document.body.scrollTop = scrollTop;
        //            document.documentElement.scrollTop = scrollTop;
        //            elem.currHeight = parseInt(style.height);
        //        };
        //    };
 
        //    addEvent('propertychange', change);
        //    addEvent('input', change);
        //    addEvent('focus', change);
        //    change();
        //};
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
            <h1>计算机及相关设备购买申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td style="width:110px;">部门/分行名称</td>
                    <td class="tl PL10"><asp:TextBox ID="txtDispatchDepartment" runat="server"></asp:TextBox></td>
                    <td style="width:110px;">申请编号</td>
                    <td class="tl PL10"><asp:TextBox ID="txtApplyID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>联系人</td>
                    <td class="tl PL10"><asp:Label ID="lblApplicant" runat="server" Text="Label"></asp:Label></td>
                    <td>联系电话</td>
                    <td class="tl PL10"><asp:TextBox ID="txtApplyPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>申购内容</td>
                    <td colspan="3">
                        <table>
                            <tr class="noborder">
                                <td class="tl PL10" style="font-weight:bolder;">申购要求</td>
                                <td></td>
                            </tr>
                            <tr class="noborder">
                                <td rowspan="3" class="tl PL10" style="vertical-align:top;padding-top:10px;" >申购项目及数量：</td>
                                <td>1、<asp:TextBox ID="txtBuy1" runat="server" style="width:280px;"></asp:TextBox> （<asp:TextBox ID="txtUnit1" runat="server" style="width:15px;"></asp:TextBox>）套/件</td>
                            </tr>
                            <tr class="noborder">
                                <td>2、<asp:TextBox ID="txtBuy2" runat="server" style="width:280px;"></asp:TextBox> （<asp:TextBox ID="txtUnit2" runat="server" style="width:15px;"></asp:TextBox>）套/件</td>
                            </tr>
                            <tr class="noborder">
                                <td>3、<asp:TextBox ID="txtBuy3" runat="server" style="width:280px;"></asp:TextBox> （<asp:TextBox ID="txtUnit3" runat="server" style="width:15px;"></asp:TextBox>）套/件</td>
                            </tr>
                            <tr class="noborder">
                                <td style=" text-align:left; padding-left:10px;font-weight:bolder;">申购原因</td>
                                <td></td>
                            </tr>
                            <tr class="noborder">
                                <td colspan="2" class="tl PL10">
                                    <%--<span id="add" style="display: none">--%>
                                    <asp:RadioButton ID="rdbAdd" runat="server" GroupName="type" onclick="$('#divScrap').hide();$('#aScrap').hide();"/><label for="<%=rdbAdd.ClientID %>">新增(只限电脑配件不含主机显示器)</label>
                                    <%--</span>--%>
                                    <asp:RadioButton ID="rdbAddPerson" runat="server"  GroupName="type" CssClass="PL10" onclick="$('#divScrap').hide();$('#aScrap').hide();"/><label for="<%=rdbAddPerson.ClientID %>">新增(入职)</label><asp:RadioButton ID="rdbReplace" runat="server" GroupName="type" CssClass="PL10" onclick="$('#divScrap').show();$('#aScrap').show();" /><label for="<%=rdbReplace.ClientID %>">替换</label>
                                    <div id="divScrap" style="display:none;">粘贴申请表地址<asp:TextBox ID="txtScrapURL" runat="server" style="width:300px;" onblur="saveScrapURL();"></asp:TextBox></div><a id="aScrap" target="_blank" style="display:none;" onclick="if(this.href=='') alert('请先粘贴申请表的地址。');">申请表</a>
                                    <asp:TextBox ID="txtReason" TextMode="MultiLine" runat="server" style="width:99%; overflow:auto;" Rows="3"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trManager1" class="noborder" style="height:30px;">
                    <td>部门主管</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx1">_________</span></div></td>
                </tr>
                <tr id="trManager2" class="noborder" style="height:30px;">
                    <td>隶属主管</td>
                    <td colspan="3" class="tl PL10" >
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx2">_________</span></div></td>
                </tr>
                <tr id="trManager3" class="noborder" style="height:30px;">
                    <td>部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>
                <tr id="trHR1" class="noborder" style="height:30px; display:none; ">
                    <td rowspan="2" >人力资源部意见</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
                        <textarea id="txtIDx4" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx4">_________</span></div>
                    </td>                            
                </tr>
                <tr id="trHR2" class="noborder" style="height:30px; display:none; ">
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>       
                </tr>
                <tr id="trX3" class="noborder" style="height:30px; display:none; ">
                    <td>行政部经办人意见</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="3" style="width:98%; overflow:auto;" cols="20" name="S1"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx6">_________</span></div>
                    </td>       
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td rowspan="2" >资讯科技部意见</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
                        <textarea id="txtIDx7" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx7">_________</span></div>
                    </td>       
                </tr>	
                <tr class="noborder" style="height:30px; ">
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        <textarea id="txtIDx8" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx8">_________</span></div>
                    </td>       
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td rowspan="2" >行政部意见</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label>
                        <input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label>
                        <asp:Button ID="btnAddLogistics" runat="server" Text="大于2万，增加后勤事务部及董事总经理审批" OnClick="btnAddLogistics_Click" OnClientClick="return confirm('是否确定大于2万，增加后勤事务部及董事总经理审批？');" Visible="false" Width="300px" /><br />
                        <textarea id="txtIDx9" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx9">_________</span></div>
                    </td>                            
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label>
                        <input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
                        <textarea id="txtIDx10" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx10">_________</span></div>
                    </td>       
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td rowspan="2" >财务部意见</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label><input id="rdbOtherIDx11" type="radio" name="agree11" /><label for="rdbOtherIDx11">其他意见</label>
                        　<asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton>
                        <br />
                        <textarea id="txtIDx11" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display:none;"/>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx11">_________</span>
                        </span>
                    </td>       
                </tr>
                <tr class="noborder" style="height:30px; ">
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label><input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label><input id="rdbOtherIDx12" type="radio" name="agree12" /><label for="rdbOtherIDx12">其他意见</label><br />
                        <textarea id="txtIDx12" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display:none;"/>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx12">_________</span>
                        </span>
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
                        <input id="rdbYesIDx13" type="radio" name="agree13" /><label for="rdbYesIDx13">同意</label><input id="rdbNoIDx13" type="radio" name="agree13" /><label for="rdbNoIDx13">不同意</label><input id="rdbOtherIDx13" type="radio" name="agree130" /><label for="rdbOtherIDx13">其他意见</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx13" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx13" value="签署意见" onclick="sign('13')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx13">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager" class="noborder" style="height:30px; display:none; ">
                    <td >董事总经理批示</td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx14" type="radio" name="agree14" /><label for="rdbYesIDx14">同意</label><input id="rdbNoIDx14" type="radio" name="agree14" /><label for="rdbNoIDx14">不同意</label>
                        <input id="rdbOtherIDx14" type="radio" name="agree14" /><label for="rdbOtherIDx14">其他意见</label><br />
                        <textarea id="txtIDx14" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx14" value="签署意见" onclick="sign('14')" style="display:none;"/><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx14">_________</span></div>
                    </td>
                </tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                    <td >后勤事务部意见<br />
                        <%--<asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />--%>
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" value="3" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><br />
						<textarea id="txtIDx131" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx131">_________</span></div>
					</td>
				</tr>
                                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3" >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <div style="text-align: right; padding-right: 30px; padding-bottom: 10px;padding-top: 25px">日期：<span id="spanDateIDx200">_________</span></div>
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
                        <div style="text-align: right; padding-right: 30px; padding-bottom: 10px;padding-top: 25px">日期：<span id="spanDateIDx220">_________</span></div>
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
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left:5px; display:none;" />
        <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" onclick="btnDownload_Click" OnClientClick="return checkChecked();" style="margin-left:5px;" Visible="false" />
        
            <input type="button" id="btnEmailDiv" value="填写邮件内容并发送" style="display:none;" />
        
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
    <div id="divEmail" title="填写邮件内容">
        <textarea id="txtEmail" cols="20" rows="2" style="width:260px;height:125px; overflow-y:auto;"></textarea>
    </div>
    <%=sbJS.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

