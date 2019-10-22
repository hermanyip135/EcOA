<%@ Page ValidateRequest="false" Title="员工购租楼宇申报及免佣福利申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_BuyBuilding_Detail.aspx.cs" Inherits="Apply_BuyBuilding_Apply_BuyBuilding_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../Script/common_new.js"></script>
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
            $("[id*=btnsSignIDx]").css({
                "background-image": "url(../Images/btnSureS1.png)",
                "height": "25px", 
                "width": "43px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnsSignIDx]").mousedown(function () { $(this).css("background-image", "url(../Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(../Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(../Images/btnSureS1.png)"); });

            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {}
            });

            $("#<%=ddlOwnerType.ClientID%>").on("change",function(){
                if($("#<%=ddlOwnerType.ClientID%>").val()==2||$("#<%=ddlOwnerType.ClientID%>").val()==3) {
                    alert("请填写关系及姓名。")
                    $("#<%=txtOwnerRelation.ClientID %>").focus();
                }
            });

            $("#<%=rdbMortgageAddress2.ClientID%>").on("click",function() {
                alert("请填写具体按揭办理单位。")
                $("#<%=txtMortgageAddress.ClientID %>").focus();
            });
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function check() {
            if($.trim($("#<%=txtName.ClientID %>").val())=="") {
                alert("姓名不可为空。");
                $("#<%=txtName.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtCode.ClientID %>").val())=="") {
                alert("工号不可为空。");
                $("#<%=txtCode.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtIDNumber.ClientID %>").val())=="") {
                alert("身份证号不可为空。");
                $("#<%=txtIDNumber.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
                alert("联系电话不可为空。");
                $("#<%=txtPhone.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("部门名称不可为空。");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtPosition.ClientID %>").val())=="") {
                alert("职位不可为空。");
                $("#<%=txtPosition.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtEntryDate.ClientID %>").val())=="") {
                alert("入职日期不可为空。");
                $("#<%=txtEntryDate.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtPositiveDate.ClientID %>").val())=="") {
                alert("通过试用期日期不可为空。");
                $("#<%=txtPositiveDate.ClientID %>").focus();
                return false;
            }
            
            if(!$("#<%=rdbIntention1.ClientID %>").prop("checked")&&!$("#<%=rdbIntention2.ClientID %>").prop("checked")) {
                alert("请选择意向。");
                $("#<%=rdbIntention1.ClientID %>").focus();
                return false;
            }
            
            if($("#<%=ddlOwnerType.ClientID%>").val() == "") {
                alert("业权人必须选择。");
                $("#<%=ddlOwnerType.ClientID%>").focus();
                return false;
            }
            else
                $("#<%=hdOwnerType.ClientID%>").val($("#<%=ddlOwnerType.ClientID%>").val());
            
            if($("#<%=ddlOwnerType.ClientID%>").val() == "2"||$("#<%=ddlOwnerType.ClientID%>").val() == "3") {
                if($.trim($("#<%=txtOwnerRelation.ClientID %>").val())=="") {
                    alert("与本人关系及姓名不可为空。");
                    $("#<%=txtOwnerRelation.ClientID %>").focus();
                    return false;
                }
            }

            //20160324 SYSREQ201603181558435924578
            if(!$("#<%=this.rbOwnerIsEmployee1.ClientID%>").prop("checked") && !$("#<%=this.rbOwnerIsEmployee2.ClientID%>").prop("checked"))
            {
                alert("请选择'业权联名人是否同为公司员工'");
                $("#<%=this.rbOwnerIsEmployee1.ClientID%>").focus();
                return false;
            }
            if($.trim($("#<%=this.txtOwnerFamilyRelation.ClientID%>").val()) == "")
            {
                alert("请选择'业权联名人双方关系'");
                $("#<%=this.txtOwnerFamilyRelation.ClientID%>").focus();
                return false;
            }
            //20160324 SYSREQ201603181558435924578 end

            if($.trim($("#<%=txtBuildingAddress.ClientID %>").val())=="") {
                alert("位置不可为空。");
                $("#<%=txtBuildingAddress.ClientID %>").focus();
                return false;
            }
            if($("#<%=this.rbOwnerIsEmployee1.ClientID%>").prop("checked"))
            {
                var obj = $("#<%=this.txtOwnerEmployeeCode.ClientID%>");
                if($.trim(obj.val()) == "")
                {
                    alert("请填写工号。");
                    obj.focus();
                    return false;
                }
            }
            
            if($.trim($("#<%=txtArea.ClientID %>").val())=="") {
                alert("面积不可为空。");
                $("#<%=txtArea.ClientID %>").focus();
                return false;
            }

            if(!$("#<%=rdbPayType1.ClientID %>").prop("checked")&&!$("#<%=rdbPayType2.ClientID %>").prop("checked")) {
                alert("请选择付款方式。");
                $("#<%=rdbPayType1.ClientID %>").focus();
                return false;
            }

            if(!$("#<%=rdbFollowType1.ClientID %>").prop("checked")&&!$("#<%=rdbFollowType2.ClientID %>").prop("checked")) {
                alert("请选择跟进方式。");
                $("#<%=rdbFollowType1.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtPersInterestsURL.ClientID %>").val())=="") {
                alert("请粘帖个人利益申报表地址。");
                $("#<%=txtPersInterestsURL.ClientID%>").focus();
                return false;
            }

            if($("#<%=cbkFreeType1.ClientID %>").prop("checked") || $("#<%=cbkFreeType2.ClientID %>").prop("checked")) {
                if($.trim($("#<%=txtFollowBranch.ClientID %>").val())=="") {
                    alert("跟进分行不可为空。");
                    $("#<%=txtFollowBranch.ClientID %>").focus();
                    return false;
                }

                if($.trim($("#<%=txtFollowSales.ClientID %>").val())=="") {
                    alert("跟进营业员不可为空。");
                    $("#<%=txtFollowSales.ClientID %>").focus();
                    return false;
                }

                if($("#<%=cbkFreeType2.ClientID %>").prop("checked")) {
                    if(!$("#<%=rdbMortgageAddress1.ClientID %>").prop("checked")&&!$("#<%=rdbMortgageAddress2.ClientID %>").prop("checked")) {
                        alert("请选择按揭办理地点。");
                        $("#<%=rdbMortgageAddress1.ClientID %>").focus();
                        return false;
                    }

                    if($("#<%=rdbMortgageAddress2.ClientID %>").prop("checked")) {
                        if($.trim($("#<%=txtMortgageAddress.ClientID %>").val())=="") {
                            alert("具体按揭办理单位不可为空。");
                            $("#<%=txtMortgageAddress.ClientID %>").focus();
                            return false;
                        }
                    }
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
            var sReturnValue = window.showModalDialog("../Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_BuyBuilding_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_BuyBuilding_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_BuyBuilding_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(idx=='1'||idx=='2'||idx=='3'||idx=='8'||idx=='9'||idx=='130'||idx=='131'){//789
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

        function getSuggestion(idx) {
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

        var flagPersInterests=false;

        function savePersInterestsURL(){
            var url=$.trim($("#<%=txtPersInterestsURL.ClientID%>").val());
            if(url!=''){
                var index=url.indexOf('MainID');
                if(index>-1)
                {
                    var mainid=url.substr(index,43);
                    if(new Date($("#<%=lblApplyDate.ClientID%>").val().replace(/\-/g, "\/")) < new Date('2015-04-20'.replace(/\-/g, "\/")))//*-
                        url="http://"+window.location.host+"/Apply/PersInterests/Apply_PersInterests_Detail.aspx?"+mainid;
                    else
                        url="http://"+window.location.host+"/Apply/PersInterests/Apply_NewPersInterests_Detail.aspx?"+mainid;
                    $("#aPersInterests").attr("href",url);
                    $("#aPersInterests").show();
                    flagPersInterests=true;
                }
                else
                {
                    alert("请粘贴正确的个人利益申报表地址！");
                    $("#<%=txtPersInterestsURL.ClientID%>").val('');
                    $("#<%=txtPersInterestsURL.ClientID%>").focus();
                    flagPersInterests=false;
                }
            }
        }

        function getEmployee(n) {
            $.ajax({
                url: "../../Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtCode.ClientID%>").val(infos[0]);
                        $("#<%=txtName.ClientID%>").val(infos[1]);
                        $("#<%=txtDepartment.ClientID%>").val(infos[2]);
                        $("#<%=txtEntryDate.ClientID%>").val(infos[6]);
                        $("#<%=txtPositiveDate.ClientID%>").val(infos[7]);
                        $("#<%=txtPosition.ClientID%>").val(infos[4]);
                        $("#<%=txtIDNumber.ClientID%>").val(infos[8]);
                    }
                    else{
                        $("#<%=txtName.ClientID%>").val("");
                        $("#<%=txtDepartment.ClientID%>").val("");
                        $("#<%=txtEntryDate.ClientID%>").val("");
                        $("#<%=txtPositiveDate.ClientID%>").val("");
                        $("#<%=txtPosition.ClientID%>").val("");
                        $("#<%=txtIDNumber.ClientID%>").val("");
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
                    url: "../../Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    async: false,
                    cache: false,
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+8,
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
               // $("#<%=hdLogisticsFlow.ClientID %>").val(data);
		    //    return true;
            //}
            //else
            //    return false;
        }//987
        function DeleteT() { //20141231：M_DeleteC
            $("#btnADelete").hide();
            var url = "../Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
            if(sReturnValue=='deleted')
                window.location='/Apply/Apply_Search.aspx';
            else
                window.location.href=window.location.href;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0px auto;'>
        <div class="noprint">
        <%=sbFlow.ToString()%>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>员工购租楼宇申报表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td style="font-weight: bold; font-size: large;" colspan="4">申报人资料</td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡姓名</td>
                    <td class="tl PL10">
                        <input id="txtName" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/></td>
                    <td class="tl PL10">﹡工号</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtCode" runat="server" onblur="getEmployee(this);"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡身份证号</td>
                    <td class="tl PL10">
                        <input id="txtIDNumber" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/></td>
                    <td class="tl PL10">﹡联系电话</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡部门/分行</td>
                    <td class="tl PL10">
                        <input id="txtDepartment" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/></td>
                    <td class="tl PL10">﹡职位</td>
                    <td class="tl PL10">
                        <input id="txtPosition" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/></td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡入职日期</td>
                    <td class="tl PL10">
                        <input id="txtEntryDate" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/></td>
                    <td class="tl PL10">﹡通过试用期日期</td>
                    <td class="tl PL10">
                        <input id="txtPositiveDate" type="text" runat="server" readonly="readonly" style="background-color:Silver;"/></td>
                </tr>
                <tr>
                    <td class="tl PL10">联系地址</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtContactAddress" runat="server" Width="484px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight: bold; font-size: large;" colspan="4">﹡<asp:RadioButton ID="rdbIntention1" runat="server" GroupName="intention" Text="购买" value="1" /><asp:RadioButton ID="rdbIntention2" runat="server" GroupName="intention" Text="租赁" value="2" />意向</td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡业权人</td>
                    <td class="tl PL10">
                        <asp:DropDownList ID="ddlOwnerType" runat="server"></asp:DropDownList><asp:TextBox ID="txtOwnerRelation" runat="server" Width="100px"></asp:TextBox><asp:HiddenField ID="hdOwnerType" runat="server" />
                    </td>
                    <td class="tl PL10">﹡交易物业</td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbDealBuild1" runat="server" GroupName="rdbDealBuild" Text="一手代理项目" />
                        <asp:RadioButton ID="rdbDealBuild2" runat="server" GroupName="rdbDealBuild" Text="二手物业" />
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡业权联名<br />&nbsp;&nbsp;人是否同<br />为公司员工</td>
                    <td class="tl PL10">   
                        <asp:RadioButton ID="rbOwnerIsEmployee1" runat="server" GroupName="rbOwnerIsEmployee" Text="是" onclick="OwnerIsEmployeeClick('是')" />
                        <asp:RadioButton ID="rbOwnerIsEmployee2" runat="server" GroupName="rbOwnerIsEmployee" Text="否" onclick="OwnerIsEmployeeClick('否')" />&nbsp;
                        <label for="<%=txtOwnerEmployeeCode.ClientID %>">工号：</label><asp:TextBox ID="txtOwnerEmployeeCode" runat="server" Width="80px"></asp:TextBox>
                    </td>
                    <td class="tl PL10">
                        ﹡业权联名<br />&nbsp;&nbsp;人双方关系
                    </td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtOwnerFamilyRelation" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="tl PL10">﹡位置</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtBuildingAddress" runat="server"></asp:TextBox></td>
                    <td class="tl PL10">﹡面积</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtArea" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10">价格范围</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtPriceRange" runat="server"></asp:TextBox></td>
                    <td class="tl PL10">租赁期限</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtLeaseDeadline" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡付款方式</td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbPayType1" runat="server" GroupName="PayType" Text="楼宇按揭贷款" value="1" /><asp:RadioButton ID="rdbPayType2" runat="server" GroupName="PayType" Text="一次性付款" value="2" /></td>
                    <td class="tl PL10">其它特别要求</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtSpecialRequest" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡跟进方式</td>
                    <td class="tl PL10" colspan="3">
                        <asp:RadioButton ID="rdbFollowType1" runat="server" GroupName="FollowType" Text="自行联系它行跟进" value="1" /><asp:RadioButton ID="rdbFollowType2" runat="server" GroupName="FollowType" Text="人力资源部推荐分行跟进" value="2" />
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡附件</td>
                    <td class="tl PL10" colspan="3">
                        <div id="divPersInterests">粘贴个人利益申报表地址<asp:TextBox ID="txtPersInterestsURL" runat="server" style="width:300px;" onblur="savePersInterestsURL();"></asp:TextBox></div><a id="aPersInterests" target="_blank" style="display:none;" onclick="if(this.href=='') alert('请先粘贴个人利益申报表地址。');">个人利益申报表</a>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">填写人</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApply" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="tl PL10">填写日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApplyDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div style="width: 640px; margin: 0px auto;" class="tl">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>本人已阅读并知悉<a href="../../资料/申请表相关规章制度/关于员工通过公司买卖或租赁物业的申报事宜.pdf" target="_blank">《员工购/租楼宇申报规定》</a>。现委托公司在广州物色上述物业，确认该物业在正式转名过户后方可放盘出售。</span><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight: bold; font-style: italic;">如需申请免佣福利，请填写申请表的内容，否则不用填写。</span>
            </div>
            <h1>员工购租自住楼宇免佣福利申请表</h1>
            <table id="tbAround2" width='640px'>
                <tr>
                    <td class="tl PL10">﹡申请项目</td>
                    <td class="tl PL10" colspan="3">
                        <asp:CheckBox ID="cbkFreeType1" group="FreeType" runat="server" Text="免公司佣金" /><asp:CheckBox ID="cbkFreeType2" group="FreeType" runat="server" Text="享受按揭优惠手续费" /></td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡所购租楼宇成交跟进分行</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtFollowBranch" runat="server"></asp:TextBox></td>
                    <td class="tl PL10">﹡跟进营业员</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtFollowSales" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10">按揭办理地点</td>
                    <td class="tl PL10" colspan="3">
                        <asp:RadioButton ID="rdbMortgageAddress1" runat="server" GroupName="MortgageAddress" Text="汇瀚" value="1" /><asp:RadioButton ID="rdbMortgageAddress2" runat="server" GroupName="MortgageAddress" Text="其他" value="2" /><asp:TextBox ID="txtMortgageAddress" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <div style="width: 640px; margin: 0px auto;" class="tl">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>本人知悉并遵守<a href="../../资料/申请表相关规章制度/广州中原员工购（租）自住楼宇免佣福利的管理制度.doc" target="_blank">《员工购/租自住楼宇免佣福利的管理制度》</a>的有关规定，并同意在签署正式买卖或租赁合约时先付清应付之佣金，经免佣申请批核后再退回已付佣金。</span><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>本人知悉<a href="../../资料/申请表相关规章制度/广州中原员工购（租）自住楼宇免佣福利的管理制度.doc" target="_blank">《员工购/租自住楼宇免佣福利的管理制度》</a>的规定，并同意如违反以下几点的，不予退款：</span><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>1、	申请人需提前一周以上（相对于签约时间）申报，否则不获批准；</span><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>2、	申请人为1～3级营业员的，相关交易不能由申请人自己或申请人所在营业组别的同事成交，否则不予退款；</span><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>3、	申请人为营业部4级以上管理人员的，相关交易不能由申请人管辖之营业组别的同事成交，否则不予退款。</span><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>4、	申请人在免佣福利操作全部完成前离职，有关款项不再退还</span><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>本人声明上述楼宇乃本人自住，若不是自住用途或在购买后一年内成功出售，则公司有权于本人之薪金或佣金中扣除已退回的公司佣金款项。</span><br />
            </div>
            <table id="tbAround3"  width='640px'>
                <tr id="trManager1" class="noborder" style="height: 30px;">
                    <td>部门主管</td>
                    <td class="tl PL10" >
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 30px;">
                    <td>隶属主管</td>
                    <td class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager3" class="noborder" style="height: 30px;">
                    <td>部门负责人</td>
                    <td class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td >财务部意见</td>
                    <td class="tl PL10" style=" ">
                        <%--<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意：申请人申请之免佣楼宇已上成交报告，符合申请条件。</label><br />
                        <input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意：申请人申请之免佣楼宇未提交成交报告。</label><br />--%>

                        
                        <input id="rdbYesIDx4" type="radio" name="agree4" style="display:none;" />
                        <input id="rdbIDx41" type="radio" name="agree4x" onclick="$('#rdbYesIDx4').attr('checked','checked');$('#<%=hdIDx4.ClientID%>').val(1);" />
                        <label style="color: #008162">同　意：申请人申请之免佣楼宇未提交成交报告，符合申请免佣条件。</label>
                        

                        <span id ="fn2" style="display:none;">
                        <input id="rdbIDx42" type="radio" name="agree4x" onclick="    $('#rdbYesIDx4').attr('checked','checked');$('#<%=hdIDx4.ClientID%>').val(2);" />
                        <label for="rdbIDx42">同意申报内容</label>
                        </span>
                        
                        <br />

                        <input id="rdbNoIDx4" type="radio" name="agree4" style="display:none;" />
                        <input id="rdbIDx43" type="radio" name="agree4x" onclick="$('#rdbNoIDx4').attr('checked','checked');$('#<%=hdIDx4.ClientID%>').val(3);" />
                        <label style="color: #fe0100">不同意：申请人申请之免佣楼宇已上成交报告，不符合免佣条件。</label> &nbsp;
                        <span id ="fn4" style="display:none;">
                        <input id="rdbIDx44" type="radio" name="agree4x" onclick="$('#rdbNoIDx4').attr('checked','checked');$('#<%=hdIDx4.ClientID%>').val(4);" />
                        <label for="rdbIDx44">不同意申报内容</label>
                        </span>
                        <br />
                        <input id="rdbOtherIDx4" type="radio" name="agree4" style="display:none;" />
                        <input id="rdbIDx45" type="radio" name="agree4x" onclick="$('#rdbOtherIDx4').attr('checked','checked');$('#<%=hdIDx4.ClientID%>').val(5);" />
                        <label for="rdbIDx45">其他意见</label>
                        <br />
                        <input id="hdIDx4" type="hidden" runat="server" />                                                                         
                        <textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 30px;">
                    <td rowspan="2" >人力资源部意见</td>
                    <td class="tl PL10" style=" ">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">确认</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">退回申请</label>
                        <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>
                <%--<tr class="noborder" style="height: 30px;display:none;">
                    <td class="tl PL10" style=" ">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">确认</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">退回申请</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>
                    </td>
                </tr>--%>
                <tr class="noborder" style="height: 30px;">
                    <td class="tl PL10" style=" ">
                        <%--<input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意：申请人具备免公司佣金及按揭手续费资格</label><br />
                        <input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意：申请人不具备免公司佣金及按揭手续费资格</label><br />--%>

                        <span id="fdn1" style="display:none;">
                        <input id="rdbYesIDx7" type="radio" name="agree7" style="display:none;" />
                        <label for="rdbIDx71" style="color: #008162">同　意：</label>
                        <input id="rdbIDx71" type="radio" name="agree7x" onclick="$('#rdbYesIDx7').attr('checked','checked');$('#<%=hdIDx7.ClientID%>').val(1);" />
                        <label >申请人具备免公司佣金及按揭手续费资格</label>&nbsp;<br />
                        </span>

                        <input id="rdbIDx72" type="radio" name="agree7x" onclick="$('#rdbYesIDx7').attr('checked','checked');$('#<%=hdIDx7.ClientID%>').val(2);" />
                        <label for="rdbIDx72">同意申报内容</label>

                        <span id="fdn3" style="display:none;">
                        <input id="rdbNoIDx7" type="radio" name="agree7" style="display:none;" />
                        <label for="rdbIDx73" style="color: #fe0100">不同意：</label>
                        <input id="rdbIDx73" type="radio" name="agree7x"  onclick="$('#rdbNoIDx7').attr('checked','checked');$('#<%=hdIDx7.ClientID%>').val(3);"/>
                        <label >申请人不具备免公司佣金及按揭手续费资格</label><br />
                        </span>

                        <input id="rdbIDx74" type="radio" name="agree7x" onclick="$('#rdbNoIDx7').attr('checked','checked');$('#<%=hdIDx7.ClientID%>').val(4);" />
                        <label for="rdbIDx74">不同意申报内容</label>

                        <input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
                        <input id="hdIDx7" type="hidden" runat="server" />                                                                         
                        <textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
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
                <tr id="trLogistics" class="noborder" style="height: 30px; display: none;">
                    <td >后勤事务部意见<br /><asp:Button ID="btnWillEnd2" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
                    <td class="tl PL10" style=" ">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
                    </td>
                </tr>
                <tr id="trMortgage" class="noborder" style="height: 30px; display: none;">
                    <td >汇瀚意见</td>
                    <td class="tl PL10" style=" ">
                        <input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label><br />
                        <textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
                    </td>
                </tr>
                <tr id="trGeneralManager" class="noborder" style="height: 30px; display: none;">
                    <td >董事总经理审批</td>
                    <td class="tl PL10" style=" ">
                        <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label>
                        <input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
                        <textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
                    </td>
                </tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                    <td >后勤事务部意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="2" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><br />
						<textarea id="txtIDx130" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                <tr id="tlsc3" class="noborder" style="height: 85px; display: none;">
                    <td >汇瀚意见</td>
                    <td class="tl PL10" style=" ">
                        <input id="rdbYesIDx131" type="radio" name="agree9"  value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree9" value="2" /><label for="rdbNoIDx131">不同意</label><br />
                        <textarea id="txtIDx131" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S4"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
                    </td>
                </tr>
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理审批</td>
					<td class="tl PL10" style=" ">
						<input id="rdbYesIDx132" type="radio" name="agree132" value="1" /><label for="rdbYesIDx132">同意</label><input id="rdbNoIDx132" type="radio" name="agree132" value="2" /><label for="rdbNoIDx132">不同意</label>
                        <input id="rdbOtherIDx132" type="radio" name="agree132" /><label for="rdbOtherIDx132">其他意见</label><br />
						<textarea id="txtIDx132" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx132" value="签署意见" onclick="sign('132')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx132">_________</span></div>
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
            <div style="width: 640px; margin: 0px auto;" class="tl">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight: bold;">免佣福利申请经批核后半年内有效。</span><br />
            </div>
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
                        <asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID")%>' OnClientClick="return confirm('确认删除？');" />
                        <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <a id="link" href='<%=ConfigurationManager.AppSettings["EcoaFileURL"]%><%#Eval("OfficeAutomation_Attach_Path")%>' target="_blank"><%#Eval("OfficeAutomation_Attach_Name")%></a>
                        <asp:HiddenField ID="hfPath" runat="server" Value='<%#Eval("OfficeAutomation_Attach_Path")%>' />
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
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
        <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
        <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
        <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
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
    <%=sbJS.ToString()%>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应

        function OwnerIsEmployeeClick(sel)
        {
            switch(sel)
            {
                case "是" :
                    $("#<%=this.txtOwnerEmployeeCode.ClientID%>").removeAttr("disabled");
                    break;
                case "否" : 
                    $("#<%=this.txtOwnerEmployeeCode.ClientID%>").attr("disabled","disabled");
                    break;
            }
        }
        function Init()
        {
            if($("#<%=rbOwnerIsEmployee1.ClientID%>").prop("checked"))
                OwnerIsEmployeeClick('是');
            else
                OwnerIsEmployeeClick('否');
        }
        Init();
    </script>
</asp:Content>

