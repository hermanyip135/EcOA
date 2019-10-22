<%@ Page Title="物业部成交商铺/写字楼备案申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_DealOffice_Detail.aspx.cs" Inherits="Apply_DealOffice_Apply_DealOffice_Detail" %>

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

            selectedType();
            countLease();
            countDeal();
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {}
            });

            $("#<%=txtBranch.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {}
            });
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
 
        function check() {
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("发文部门不可为空！");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {
                alert("回复电话不可为空！");
                $("#<%=txtReplyPhone.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtReplyFax.ClientID %>").val())=="") {
                alert("回复传真不可为空！");
                $("#<%=txtReplyFax.ClientID %>").focus();
                return false;
            }
                
            if($.trim($("#<%=txtWorkArea.ClientID %>").val())=="") {
                alert("工作区域不可为空！");
                $("#<%=txtWorkArea.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtBranch.ClientID %>").val())=="") {
                alert("分行不可为空！");
                $("#<%=txtBranch.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtArea.ClientID %>").val())=="") {
                alert("物业所在区域不可为空！");
                $("#<%=txtArea.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtAddress.ClientID %>").val())=="") {
                alert("物业所在地址不可为空！");
                $("#<%=txtAddress.ClientID %>").focus();
                return false;
            }

            var dealPercent=$.trim($("#<%=txtDealPercent.ClientID %>").val());
            var leasePercent=$.trim($("#<%=txtLeasePercent.ClientID %>").val());

            if(dealPercent!=""||$.trim($("#<%=txtDealArea.ClientID %>").val())!=''||$.trim($("#<%=txtDealOwnerMoney.ClientID %>").val())!=''||$.trim($("#<%=txtDealClientMoney.ClientID %>").val())!=''||$.trim($("#<%=txtDealMoney.ClientID %>").val())!='') {
                if(dealPercent==""||$.trim($("#<%=txtDealArea.ClientID %>").val())==''||$.trim($("#<%=txtDealOwnerMoney.ClientID %>").val())==''||$.trim($("#<%=txtDealClientMoney.ClientID %>").val())==''||$.trim($("#<%=txtDealMoney.ClientID %>").val())=='') {
                    alert("请完整填写买卖资料！");
                   return false;
                }
            }

            if(leasePercent!=""||$.trim($("#<%=txtLeaseArea.ClientID %>").val())!=''||$.trim($("#<%=txtLeaseOwnerMoney.ClientID %>").val())!=''||$.trim($("#<%=txtLeaseClientMoney.ClientID %>").val())!=''||$.trim($("#<%=txtLeaseMoney.ClientID %>").val())!='') {
                if(leasePercent==""||$.trim($("#<%=txtLeaseArea.ClientID %>").val())==''||$.trim($("#<%=txtLeaseOwnerMoney.ClientID %>").val())==''||$.trim($("#<%=txtLeaseClientMoney.ClientID %>").val())==''||$.trim($("#<%=txtLeaseMoney.ClientID %>").val())=='') {
                    alert("请完整填写租赁资料！");
                    return false;
                }
            }

            if(((dealPercent<1&&dealPercent>0)||(leasePercent<0.5&&leasePercent>0))&&$.trim($("#<%=txtMoneyRemark.ClientID %>").val())=='') {
                alert('买卖单总佣点数小于1%，\n或租赁单总佣点数小于0.5个月租金，\n请详细说明原因！');
                $("#<%=txtMoneyRemark.ClientID %>").focus();
                return false;
            }

            return true;
        }

        function countDeal()
        {
            var dealPrice=$.trim($("#<%=txtDealPrice.ClientID %>").val());
            if(dealPrice!=''||dealPrice!='0'){
                $("#<%=txtDealOwnerPercent.ClientID %>").val(TwoDecimal($("#<%=txtDealOwnerMoney.ClientID %>").val()/dealPrice*100));
                $("#<%=hdDealOwnerPercent.ClientID %>").val($("#<%=txtDealOwnerPercent.ClientID %>").val());
                
                $("#<%=txtDealClientPercent.ClientID %>").val(TwoDecimal($("#<%=txtDealClientMoney.ClientID %>").val()/dealPrice*100));
                $("#<%=hdDealClientPercent.ClientID %>").val($("#<%=txtDealClientPercent.ClientID %>").val());

                $("#<%=txtDealPercent.ClientID %>").val(TwoDecimal($("#<%=txtDealMoney.ClientID %>").val()/dealPrice*100));
                $("#<%=hdDealPercent.ClientID %>").val($("#<%=txtDealPercent.ClientID %>").val());
            }   
        }

        function countLease()
        {
            var leasePrice=$.trim($("#<%=txtLeasePrice.ClientID %>").val());
            if(leasePrice!=''||leasePrice!='0'){
                $("#<%=txtLeaseOwnerPercent.ClientID %>").val(TwoDecimal($("#<%=txtLeaseOwnerMoney.ClientID %>").val()/leasePrice));
                $("#<%=hdLeaseOwnerPercent.ClientID %>").val($("#<%=txtLeaseOwnerPercent.ClientID %>").val());

                $("#<%=txtLeaseClientPercent.ClientID %>").val(TwoDecimal($("#<%=txtLeaseClientMoney.ClientID %>").val()/leasePrice));
                $("#<%=hdLeaseClientPercent.ClientID %>").val($("#<%=txtLeaseClientPercent.ClientID %>").val());

                $("#<%=txtLeasePercent.ClientID %>").val(TwoDecimal($("#<%=txtLeaseMoney.ClientID %>").val()/leasePrice));
                $("#<%=hdLeasePercent.ClientID %>").val($("#<%=txtLeasePercent.ClientID %>").val());
            }   
        }
        
        function TwoDecimal(x) {
            if(isNaN(x)) {
                return 0;
            }
            return Math.round(x*100)/100;
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
                window.location='Apply_DealOffice_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_DealOffice_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=300px");
            if(win=='success')
                window.location="Apply_DealOffice_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='131'){//789
            ////if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
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

        function selectedType() {
            $('#<%=lblType.ClientID %>').text($("#<%=ddlType.ClientID %> :selected").text());
            $('#<%=lblTypeHead.ClientID %>').text($("#<%=ddlType.ClientID %> :selected").text());
        }

        function editBranch() {
            $('#<%=lblBranch.ClientID %>').text($("#<%=txtBranch.ClientID %>").val());
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
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+5,
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
    <div style='text-align:center; width:640px; margin:0px auto;'>
        <div class="noprint">
        <%=sbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align:center'>            
            <h1>广东中原地产代理有限公司</h1>
            <h1>物业部成交<asp:Label ID="lblTypeHead" runat="server"></asp:Label>的备案申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td style="width:120px;">收文部门</td>
                    <td class="tl PL10" style="">后勤事务部</td>
                    <td style="background-color:#e3e3e3;width:100px;*padding-left:1px;">文档编码</td>
                    <td class="tl PL10" style="background-color:#e3e3e3;"><%=SerialNumber %></td>
                </tr>
                <tr>
                    <td>电子传真</td>
                    <td class="tl PL10">020-83486838-6335</td>
                    <td>发文人员</td>
                    <td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>发文部门</td>
                    <td class="tl PL10"><asp:textbox id="txtDepartment" runat="server"></asp:textbox></td>
                    <td>发文日期</td>
                    <td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>抄送部门</td>
                    <td class="tl PL10">财务部</td>
                    <td>回复电话</td>
                    <td class="tl PL10">020-<asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>文件主题</td>
                    <td class="tl PL10"><asp:Label ID="lblBranch" runat="server" Text=""></asp:Label>成交<asp:Label ID="lblType" runat="server" Text=""></asp:Label>备案申请</td>
                    <td>回复传真</td>
                    <td class="tl PL10">020-<asp:TextBox ID="txtReplyFax" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10" colspan="4">
                        <asp:TextBox ID="txtWorkArea" runat="server" style="width:80px;"></asp:TextBox>区域<asp:TextBox ID="txtBranch" runat="server" onblur="editBranch();"></asp:TextBox>分行现有一间
                        <asp:DropDownList ID="ddlType" runat="server" onchange="selectedType()"></asp:DropDownList>即将成交。<br />
                        物业所在区域<asp:TextBox ID="txtArea" runat="server" style="width:80px;"></asp:TextBox>区  地址<asp:TextBox ID="txtAddress" runat="server" style="width:300px;"></asp:TextBox><br />
                        [请选择（1）买卖或（2）租赁的资料填写]
                    </td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="2" style="width:320px;">（1）买卖</td>
                    <td class="tl PL10" colspan="2">（2）租赁</td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="2">面积<asp:TextBox ID="txtDealArea" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');"></asp:TextBox>平方米，成交价<asp:TextBox ID="txtDealPrice" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');" onblur="countDeal();"></asp:TextBox>元</td>
                    <td class="tl PL10" colspan="2">面积<asp:TextBox ID="txtLeaseArea" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');"></asp:TextBox>平方米，月租金<asp:TextBox ID="txtLeasePrice" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');" onblur="countLease();"></asp:TextBox>元</td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="2">业佣：金额<asp:TextBox ID="txtDealOwnerMoney" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');" onblur="countDeal();"></asp:TextBox>元，业佣比例<asp:TextBox ID="txtDealOwnerPercent" runat="server" style="width:40px;background-color:#e3e3e3" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="hdDealOwnerPercent" runat="server" Value="0" />%</td>
                    <td class="tl PL10" colspan="2">业佣：金额<asp:TextBox ID="txtLeaseOwnerMoney" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');" onblur="countLease();"></asp:TextBox>元，相当于<asp:TextBox ID="txtLeaseOwnerPercent" runat="server" style="width:40px;background-color:#e3e3e3" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="hdLeaseOwnerPercent" runat="server" Value="0" />个月租金</td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="2">客佣：金额<asp:TextBox ID="txtDealClientMoney" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');" onblur="countDeal();"></asp:TextBox>元，客佣比例<asp:TextBox ID="txtDealClientPercent" runat="server" style="width:40px;background-color:#e3e3e3" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="hdDealClientPercent" runat="server" Value="0" />%</td>
                    <td class="tl PL10" colspan="2">客佣：金额<asp:TextBox ID="txtLeaseClientMoney" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');" onblur="countLease();"></asp:TextBox>元，相当于<asp:TextBox ID="txtLeaseClientPercent" runat="server" style="width:40px;background-color:#e3e3e3" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="hdLeaseClientPercent" runat="server" Value="0" />个月租金</td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="2">合计：金额<asp:TextBox ID="txtDealMoney" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');" onblur="countDeal();"></asp:TextBox>元，总佣比例<asp:TextBox ID="txtDealPercent" runat="server" style="width:40px;background-color:#e3e3e3" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="hdDealPercent" runat="server" Value="0" />%</td>
                    <td class="tl PL10" colspan="2">合计：金额<asp:TextBox ID="txtLeaseMoney" runat="server" style="width:60px;" onkeyup="this.value=this.value.replace(/[^\d|/.]/g,'');" onblur="countLease();"></asp:TextBox>元，相当于<asp:TextBox ID="txtLeasePercent" runat="server" style="width:40px;background-color:#e3e3e3" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="hdLeasePercent" runat="server" Value="0" />个月租金</td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="4">
                        （备注：买卖佣金比例=佣金金额/成交价*100%，租赁佣金比例=佣金金额/月租金）
                    </td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="4">
                       （3）若是跨区成交，请详细说明原因：
                    </td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="4">
                        <asp:TextBox ID="txtCrossAreaRemark" runat="server" TextMode="MultiLine" Rows="3" style="width:98%; overflow:auto;"></asp:TextBox>
                    </td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="4">
                       （4）买卖单总佣点数小于1%或租赁单总佣点数小于0.5个月租金，请详细说明原因：
                    </td>
                </tr>
                <tr class="noborder">
                    <td class="tl PL10" colspan="4">
                        <asp:TextBox ID="txtMoneyRemark" runat="server" TextMode="MultiLine" Rows="3" style="width:98%; overflow:auto;"></asp:TextBox>
                        特此申请备案，请公司审核批复。
                    </td>
                </tr>
                <tr id="trManager1" class="noborder" style="height:30px;">
                    <td style=" ">部门主管</td>
                    <td colspan="3" class="noborder" style=" ">
                        <div class="tl PL10"><input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label></div>
                        <textarea id="txtIDx1" rows="3" style="width:98%; overflow:auto; display:none; "></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
                    </td>       
                </tr>
                <tr id="trManager2" class="noborder" style="height:30px;">
                    <td>隶属主管</td>
                    <td colspan="3" class="noborder">
                        <div class="tl PL10"><input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label></div>
                        <textarea id="txtIDx2" rows="3" style="width:98%; overflow:auto; display:none;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager3" class="noborder" style="height:30px;">
                    <td>部门负责人</td>
                    <td colspan="3" class="noborder">
                        <div class="tl PL10"><input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label></div>
                        <textarea id="txtIDx3" rows="3" style="width:98%; overflow:auto; display:none;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
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
                <%--<tr style="height:30px;">
                    <td>后勤事务部<br />经办人意见</td>
                    <td colspan="3">
                        <div style="display:none; "><input id="rdbYesIDx4" type="radio" name="agree4" checked="checked" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label></div>
                        <textarea id="txtIDx4" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
                    </td>
                </tr>--%>
                <tr id="trLogistics1" class="noborder" style="height:30px; ">
                    <td rowspan="2" >后勤事务部批示<br />
                        <%--<asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />--%>
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
                    <td colspan="3" class="tl PL10" style=" " >
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                    </td>       
                </tr>
                <tr id="trLogistics2" class="noborder" style="height:30px; ">
                    <td colspan="3">
                        <textarea id="txtIDx5" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display:none;"/><div class="signdate" style="margin-top: -20px;">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                    <td >后勤事务部批示<br /><asp:Button ID="btnWillEnd2" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label>
                        <input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
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
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
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
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
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

