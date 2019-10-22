<%@ Page ValidateRequest="false" Title="项目宿舍及津贴费用申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ProjDormSubsiby_Detail.aspx.cs" Inherits="Apply_ProjDormSubsiby_Apply_ProjDormSubsiby_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i1 = 1,i2=1;

        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }

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

            i1 = $("#tbEnjoyPerson tr").length - 1;
            i2 = $("#tbPerformanceProfit tr").length - 1;

            $("#<%=txtDepartment.ClientID %>").autocomplete({ source: jJSON});
               
            $("#<%=txtAgentStartDate.ClientID%>").datepicker();
            $("#<%=txtAgentEndDate.ClientID%>").datepicker();
            $("#<%=txtSaleDate.ClientID%>").datepicker();
            $("#<%=txtRentStartDate.ClientID%>").datepicker();
            $("#<%=txtRentEndDate.ClientID%>").datepicker();
            $("#<%=txtSubsibyValidityStartDate.ClientID%>").datepicker();
            $("#<%=txtSubsibyValidityEndDate.ClientID%>").datepicker();

            $("#<%=rdbRentType1.ClientID%>").click(function(){
                $("#LastTime").show();
            });
            $("#<%=rdbRentType2.ClientID%>").click(function(){
                $("#LastTime").hide();
            });
            if($("#<%=rdbRentType1.ClientID%>").prop("checked")){
                $("#LastTime").show();
            }

            $("#<%=txtDormitoryStartDate.ClientID%>").datepicker();
            $("#<%=txtDormitoryEndDate.ClientID%>").datepicker();
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function check() {
            if (isNaN($("#<%=txtLastRent.ClientID%>").val())) {
                alert("上一期的月租金必须输入纯数字");
                $("#<%=txtLastRent.ClientID%>").focus();
                return false;
            }
            if (isNaN($("#<%=txtMonthlyRent.ClientID%>").val())) {
                alert("月租金必须输入纯数字");
                $("#<%=txtMonthlyRent.ClientID%>").focus();
                return false;
            }
            if (isNaN($("#<%=txtLastYear.ClientID%>").val())) {
                alert("时间长必须输入纯数字");
                $("#<%=txtLastYear.ClientID%>").focus();
                return false;
            }
            if (isNaN($("#<%=txtLastMonth.ClientID%>").val())) {
                alert("月数必须输入纯数字");
                $("#<%=txtLastMonth.ClientID%>").focus();
                return false;
            }
            
            if($("#<%=rdbRentType1.ClientID%>").prop("checked")){
                if($("#<%=txtLastYear.ClientID %>").val()*1 < 0 || $("#<%=txtLastYear.ClientID %>").val()*1 > 1000){
                    alert("请输入正确的时间长！");
                    $("#<%=txtLastYear.ClientID %>").focus();
                    return false;
                }
                if($("#<%=txtLastMonth.ClientID %>").val()*1 < 0 || $("#<%=txtLastMonth.ClientID %>").val()*1 > 12){
                    alert("请输入正确的月数！");
                    $("#<%=txtLastMonth.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtLastMonth.ClientID %>").val())=="") {
                    alert("请填写上一期租赁期长！");
                    $("#<%=txtLastMonth.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=txtLastRent.ClientID %>").val())=="") {
                    alert("上一期的租金不可为空！");
                    $("#<%=txtLastRent.ClientID %>").focus();
                    return false;
                }
            }
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {alert("发文部门不可为空！");$("#<%=txtDepartment.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {alert("回复电话不可为空！");$("#<%=txtReplyPhone.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {alert("发文编号不可为空！");$("#<%=txtApplyID.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtProjName.ClientID %>").val())=="") {alert("项目名称不可为空！");$("#<%=txtProjName.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtDeveloperName.ClientID %>").val())=="") {alert("发展商名称不可为空！");$("#<%=txtDeveloperName.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtProjAddress.ClientID %>").val())=="") {alert("项目地址不可为空！");$("#<%=txtProjAddress.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtAgentStartDate.ClientID %>").val())=="") {alert("项目代理起始日期不可为空！");$("#<%=txtAgentStartDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtAgentEndDate.ClientID %>").val())=="") {alert("项目代理结束日期不可为空！");$("#<%=txtAgentEndDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtSaleDate.ClientID %>").val())=="") {alert("开售日不可为空！");$("#<%=txtSaleDate.ClientID %>").focus();return false;}

            var cblItemLength = $("#<%=cblDealOfficeType.ClientID %> input").length;
            var flag = false;
            var typeValues = "";
            for (var i = 0; i < cblItemLength; i++) {
                if ($("#<%=cblDealOfficeType.ClientID %> input")[i].checked) {
                    flag = true;
                    typeValues += $("#<%=cblDealOfficeType.ClientID%> span")[i].tag + "|";
                }
            }

            if (!flag) {
                alert("请选择物业性质！");
                return false;
            }
            else
                $("#<%=hdDealOfficeType.ClientID%>").val(typeValues.substr(0, typeValues.length - 1));

            if($.trim($("#<%=txtGoodsQuantity.ClientID %>").val())=="") {alert("货量不可为空！");$("#<%=txtGoodsQuantity.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtGoodsValue.ClientID %>").val())=="") {alert("货值不可为空！");$("#<%=txtGoodsValue.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtPreComm.ClientID %>").val())=="") {alert("预计创佣不可为空！");$("#<%=txtPreComm.ClientID %>").focus();return false;}
            
            if (!$("#<%=rdbAgentModel1.ClientID %>").prop("checked") && !$("#<%=rdbAgentModel2.ClientID %>").prop("checked")) {
                alert("请选择项代理模式");
                return false;
            }
            
            if($.trim($("#<%=txtCommPoint.ClientID %>").val())=="") {alert("佣金点数不可为空！");$("#<%=txtCommPoint.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtProjGoodsQuantity.ClientID %>").val())=="") {alert("预计项目货量不可为空！");$("#<%=txtProjGoodsQuantity.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtProjGoodsValue.ClientID %>").val())=="") {alert("预计项目货值不可为空！");$("#<%=txtProjGoodsValue.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtProjCommission.ClientID %>").val())=="") {alert("预计项目佣金不可为空！");$("#<%=txtProjCommission.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtProjCommPoint.ClientID %>").val())=="") {alert("预计项目佣金点数不可为空！");$("#<%=txtProjCommPoint.ClientID %>").focus();return false;}

            var data = "";
            var flag = true;

            $("#tbEnjoyPerson tr").each(function(n) {
                if (n > 0) {
                    data += $.trim($("#txtEnjoyPersonName" + n).val()) + "&&" + $.trim($("#txtEnjoyPersonPosition" + n).val()) + "&&" + $.trim($("#txtEnjoyPersonID" + n).val()) +"&&" + $.trim($("#txtEnjoyPersonLiveAddress" + n).val()) + "||";
                }
            });

            data = data.substr(0, data.length - 2);
            $("#<%=hdEnjoyPerson.ClientID %>").val(data);

            data = "";
            $("#tbPerformanceProfit tr").each(function(n) {
                if (n> 0) {
                    data += $.trim($("#txtStartYear" + n).val()) + "&&" + $.trim($("#txtEndYear" + n).val()) + "&&" + $.trim($("#txtPerformance" + n).val()) +"&&" + $.trim($("#txtProfit" + n).val()) + "||";
                }
            });

            data = data.substr(0, data.length - 2);
            $("#<%=hdPerformanceProfit.ClientID %>").val(data);
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
                window.location='Apply_ProjDormSubsiby_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_ProjDormSubsiby_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
                    if(win=='success')
                        window.location="Apply_ProjDormSubsiby_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(idx!='3'&&idx!='8'&&idx!='9'&&idx!='11'&&idx!='12'&&idx!='130'&&idx!='131'){
            //if(idx=='1'||idx=='2'||idx=='4'||idx=='5'||idx=='6'||idx=='7'||idx=='10'){//789
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

        function addRow1() {
            i1++;
            var html = '<tr id="trEnjoyPerson' + i1 + '">'
                + '     <td><input type="text" id="txtEnjoyPersonName' + i1 + '" style="width:80px"/></td>'
                + '     <td><input type="text" id="txtEnjoyPersonPosition' + i1 + '" style="width:80px"/></td>'
                + '     <td><input type="text" id="txtEnjoyPersonID' + i1 + '" style="width:95%"/></td>'
                + '     <td><input type="text" id="txtEnjoyPersonLiveAddress' + i1 + '" style="width:95%"/></td>'
                + '</tr>';

            $("#tbEnjoyPerson").append(html);
        }

        function deleteRow1() {
            if (i1 > 1) {
                $("#tbEnjoyPerson tr:eq(" + i1 + ")").remove();
                i1--;
            } else
                alert("不可删除第一行。");
        }
        
        function addRow2() {
            i2++;
            var html = '<tr id="trPerformanceProfit' + i2 + '">'
                + '     <td><input type="text" id="txtStartYear' + i2 + '" style="width:90px"/>至<input type="text" id="txtEndYear' + i2 + '" style="width:90px"/></td>'
                + '     <td><input type="text" id="txtPerformance' + i2 + '"/></td>'
                + '     <td><input type="text" id="txtProfit' + i2 + '"/></td>'
                + '</tr>';

            $("#tbPerformanceProfit").append(html);
        }

        function deleteRow2() {
            if (i2 > 1) {
                $("#tbPerformanceProfit tr:eq(" + i2 + ")").remove();
                i2--;
            } else
                alert("不可删除第一行。");
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
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+11,
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>项目宿舍及津贴费用申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <%--<div style="width:640px;margin:0 auto;"><span style="float:right;">文档编码(自动生成)：<a%=SerialNumber %></span></div>--%>
            <table id="tbAround"  width='640px'>
                 <tr>
                    <td style="width: 20%; ">发文部门</td>
                    <td class="tl PL10"><asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
                    <td style="width: 20%; ">发文日期</td>
                    <td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>跟进人</td>
                    <td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
                    <td>跟进人电话</td>
                    <td class="tl PL10"><asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>发文编号</td>
                    <td class="tl PL10"><asp:TextBox ID="txtApplyID" runat="server"></asp:TextBox></td>
                    <td>文档编码</td>
                    <td class="tl PL10"><%=SerialNumber %></td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">项目信息</th></tr>
                <tr>
                    <td style="width: 20%; ">项目名称</td>
                    <td class="tl PL10"><asp:TextBox ID="txtProjName" runat="server"></asp:TextBox></td>
                    <td style="width: 20%; ">开发商名称</td>
                    <td class="tl PL10"><asp:TextBox ID="txtDeveloperName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>项目地址</td>
                    <td class="tl PL10" colspan="3"><asp:TextBox ID="txtProjAddress" runat="server" Width="95%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>项目代理期</td>
                    <td class="tl PL10"><asp:TextBox ID="txtAgentStartDate" runat="server" Width="80"></asp:TextBox>至<asp:TextBox ID="txtAgentEndDate" runat="server" Width="80"></asp:TextBox></td>
                    <td>开售日</td>
                    <td class="tl PL10"><asp:TextBox ID="txtSaleDate" runat="server" Width="80"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>物业性质</td>
                    <td class="tl PL10" colspan="3"><asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList><asp:TextBox ID="txtDealOfficeOther" runat="server"></asp:TextBox><asp:HiddenField ID="hdDealOfficeType" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 20%; ">货量</td>
                    <td class="tl PL10"><asp:TextBox ID="txtGoodsQuantity" runat="server"></asp:TextBox></td>
                    <td style="width: 20%; ">货值</td>
                    <td class="tl PL10"><asp:TextBox ID="txtGoodsValue" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>预计创佣</td>
                    <td class="tl PL10"><asp:TextBox ID="txtPreComm" runat="server"></asp:TextBox></td>
                    <td>代理模式</td>
                    <td class="tl PL10"><asp:RadioButton ID="rdbAgentModel1" runat="server" Text="联合代理" GroupName="AgentModel" /><asp:RadioButton ID="rdbAgentModel2" runat="server" Text="独家代理" GroupName="AgentModel" /></td>
                </tr>
                <tr>
                    <td>佣金点数</td>
                    <td class="tl PL10"><asp:TextBox ID="txtCommPoint" runat="server"></asp:TextBox></td>
                    <td> </td>
                    <td class="tl PL10"></td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">宿舍费用（如有）</th></tr>
                <tr>
                    <td colspan="4">
                        <table class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>
                                <td colspan="2">租赁合同期</td>
                                <td colspan="2"><asp:TextBox ID="txtRentStartDate" runat="server" Width="75px"></asp:TextBox>至<asp:TextBox ID="txtRentEndDate" runat="server" Width="75px"></asp:TextBox></td>
                                <td colspan="2">租赁类型</td>
                                <td colspan="2"><asp:RadioButton ID="rdbRentType1" runat="server" Text="续租" GroupName="RentType" /><asp:RadioButton ID="rdbRentType2" runat="server" Text="新增" GroupName="RentType" /></td>
                                <td colspan="2">居住人数</td>
                                <td colspan="2"><asp:TextBox ID="txtLiveNumber" runat="server"  Width="90"></asp:TextBox></td>
                            </tr>
                            
                            <tr id="LastTime" style="display: none">
                                <td colspan="2">上一期租赁期长</td>
                                <td colspan="4">
                                    共<asp:TextBox ID="txtLastYear" runat="server"  Width="70"></asp:TextBox>年
                                    <asp:TextBox ID="txtLastMonth" runat="server"  Width="70"></asp:TextBox>个月
                                </td>
                                <td colspan="4">上一期的月租金</td>
                                <td colspan="2"><asp:TextBox ID="txtLastRent" runat="server"  Width="90px"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td colspan="2">宿舍地址</td>
                                <td colspan="2"><asp:TextBox ID="txtDormAddress" runat="server" Width="160px" Height="30px" TextMode="MultiLine"></asp:TextBox></td>
                                <td colspan="2">租住面积</td>
                                <td colspan="2"><asp:TextBox ID="txtDormArea" runat="server" Width="90"></asp:TextBox></td>
                                <td colspan="2">户型</td>
                                <td colspan="2"><asp:TextBox ID="txtDormType" runat="server"  Width="90"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">月租金</td>
                                <td colspan="2"><asp:TextBox ID="txtMonthlyRent" runat="server" Width="140"></asp:TextBox></td>
                                <td colspan="2">按金</td>
                                <td colspan="2"><asp:TextBox ID="txtDeposit" runat="server" Width="90"></asp:TextBox></td>
                                <td colspan="2">中介费</td>
                                <td colspan="2"><asp:TextBox ID="txtAgencyFee" runat="server" Width="90"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">每月预计支出费用</td>
                                <td colspan="10"><asp:TextBox ID="txtMonthlyEstimatedCost" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="3">管理费</td>
                                <td colspan="3"><asp:TextBox ID="txtManagermentCost" runat="server" Width="150px" Height="60px" TextMode="MultiLine"></asp:TextBox></td>
                                <td colspan="3">电费</td>
                                <td colspan="3"><asp:TextBox ID="txtElectricCharge" runat="server" Width="150px" Height="59px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="3">水费</td>
                                <td colspan="3"><asp:TextBox ID="txtWaterCharge" runat="server" Width="150px" Height="61px" TextMode="MultiLine"></asp:TextBox></td>
                                <td colspan="3">煤气</td>
                                <td colspan="3"><asp:TextBox ID="txtGasCharge" runat="server" Width="150px" Height="59px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">每月支出合计</td>
                                <td colspan="10"><asp:TextBox ID="txtMonthlyCost" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">备注</td>
                                <td colspan="10"><asp:textbox id="txtDormRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;" Height="150px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <th colspan="12" style="line-height:25px;">宿舍津贴（如有）</th>
                            </tr>
                            <tr>
                                <td colspan="2">人均宿舍津贴</td>
                                <td colspan="10">
                                    <asp:TextBox ID="txtDormitoryMonth" runat="server" Width="120px"></asp:TextBox>元/月 ÷ 
                                    <asp:TextBox ID="txtDormitoryMan" runat="server" Width="120px"></asp:TextBox>人 = 
                                    <asp:TextBox ID="txtDormitoryMdm" runat="server" Width="120px"></asp:TextBox>元/人/月
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">申请发放金额</td>
                                <td colspan="10">
                                    <asp:TextBox ID="txtApplyMoney" runat="server" Width="200px"></asp:TextBox>元/人/月
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">津贴有效期</td>
                                <td colspan="10">
                                    <asp:TextBox ID="txtDormitoryStartDate" runat="server"></asp:TextBox>至
                                    <asp:TextBox ID="txtDormitoryEndDate" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">津贴费用说明</td>
                                <td colspan="10">
                                    <asp:textbox id="txtDormitoryRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;" Height="150px"></asp:textbox>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">交通津贴（如有）</th></tr>
                <tr>
                    <td colspan="4">
                        <table class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>
                                <td>出发地</td>
                                <td>目的地</td>
                                <td>金额（双程）</td>
                                <td>次数</td>
                                <td>总金额</td>
                                <td>申请发放金额</td>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="txtStartPlace" runat="server" Width="120px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtEndPlace" runat="server" Width="120px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtRoundTripMoney" runat="server" Width="70px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtNumberOfTimes" runat="server" Width="70px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtSumOfMoney" runat="server" Width="70px"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTrafficApplyMoney" runat="server" Width="70px"></asp:TextBox><br />元/人/月</td>
                            </tr>
                            <tr>
                                <td>津贴有效期</td>
                                <td colspan="5"><asp:TextBox ID="txtSubsibyValidityStartDate" runat="server"></asp:TextBox>至<asp:TextBox ID="txtSubsibyValidityEndDate" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>津贴费用说明</td>
                                <td colspan="5">交通津贴仅限于3级（含）及以下人员享有。<br /><asp:textbox id="txtSubsibyRemark" runat="server" TextMode="MultiLine" Width="98%" Rows="3" style="overflow: auto;" Height="150px"></asp:textbox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">享受人员</th></tr>
                <tr>
                    <td colspan="4">
                        <table id="tbEnjoyPerson" class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>
                                <td>姓名</td>
                                <td>职位</td>
                                <td>身份证号</td>
                                <td>居住地址</td>
                            </tr>
                            <%=SbHtml1.ToString()%>
                        </table>
                        <asp:HiddenField ID="hdEnjoyPerson" runat="server" />
                        <div class="PL10 tl">该项目津贴人员名单，请以月末《项目部人员变动情况汇总表》为准。</div>
                        <input type="button" id="btnAddRow1" value="添加新行" onclick="addRow1();" style=" float:left; display:none;"/>
						<input type="button" id="btnDeleteRow1" value="删除一行" onclick="deleteRow1();" style=" float:left; display:none;"/>
                    </td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">管理帐累计业绩与利润</th></tr>
                <tr>
                    <td colspan="4">
                        <table id="tbPerformanceProfit" class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>
                                <td width="50%">年份</td>
                                <td width="25%">累计业绩</td>
                                <td width="25%">累计利润</td>
                            </tr>
                            <%=SbHtml2.ToString()%>
                        </table>
                        <table class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>
                                <td width="50%">合计</td>
                                <td width="25%"><asp:TextBox ID="txtSumPerformance" runat="server"></asp:TextBox></td>
                                <td width="25%"><asp:TextBox ID="txtSumProfit" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdPerformanceProfit" runat="server" />
                        <input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style=" float:left; display:none;"/>
						<input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style=" float:left; display:none;"/>
                    </td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">预计项目收益</th></tr>
                <tr>
                    <td colspan="4">
                        <table class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>
                                <td>货量（套）</td>
                                <td><asp:TextBox ID="txtProjGoodsQuantity" runat="server"></asp:TextBox></td>
                                <td>货值（元）</td>
                                <td><asp:TextBox ID="txtProjGoodsValue" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>点数</td>
                                <td><asp:TextBox ID="txtProjCommPoint" runat="server"></asp:TextBox></td>
                                <td>佣金</td>
                                <td><asp:TextBox ID="txtProjCommission" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>宿舍费用总额</td>
                                <td><asp:TextBox ID="txtDormSumCost" runat="server"></asp:TextBox></td>
                                <td>津贴费用总额</td>
                                <td><asp:TextBox ID="txtSubsibySumCost" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>宿舍费用占比</td>
                                <td><asp:TextBox ID="txtDormSumCostScale" runat="server"></asp:TextBox></td>
                                <td>津贴费用占比</td>
                                <td><asp:TextBox ID="txtSubsibySumCostScale" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">生效日期</th></tr>
                <tr>
                    <td colspan="4">
                        <table class='sample tc' width='98%' style="margin:0 auto;">
                            <tr>
                                <td style="width:150px;">宿舍费用生效日期</td>
                                <td><asp:Label ID="lblDormValidityStartDate" runat="server"></asp:Label>至<asp:Label ID="lblDormValidityEndDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width:150px;">宿舍津贴申请生效日期</td>
                                <td><asp:Label ID="lbDormitoryStartDate" runat="server"></asp:Label>至<asp:Label ID="lbDormitoryEndDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>交通津贴申请生效日期</td>
                                <td><asp:Label ID="lblSubsibyValidityStartDate" runat="server"></asp:Label>至<asp:Label ID="lblSubsibyValidityEndDate" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr><th colspan="4" style="line-height:25px;">审批流程</th></tr>
                <tr id="trManager1" class="noborder" style="height: 85px;">
                    <td >申请人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td >申请部门<br />负责人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow3" class="noborder" style="height: 85px;">
                    <td rowspan="2"  >二级市场<br />负责人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx3" type="radio" name="agree3"/><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                        <input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label><br />
                        <textarea id="txtIDx3" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow4" class="noborder" style="height: 85px;"> 
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
                        <textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td >外联部意见</td>                                                                                                           
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><br />
                        <textarea id="txtIDx5" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow6" class="noborder" style="height: 85px;"> 
                    <td rowspan="2" >人力资源部<br />意见</td>                                                                                                           
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><br />
                        <textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow7" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><br />
                        <textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow8" class="noborder" style="height: 85px;"> 
                    <td rowspan="2" >财务部意见</td>                                                                                                           
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label>
                        　<asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton>
                        <br />
                        <textarea id="txtIDx8" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow9" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label><input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label><br />
                        <textarea id="txtIDx9" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
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
                <%--<tr id="trShowFlow10" class="noborder" style="height: 85px;"> 
                        <td rowspan="4" >后勤事务部<br />意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>                                                                                                          
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">确认</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">退回申请</label><br />
                        <textarea id="txtIDx10" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx10">_________</span>
                        </span>
                    </td>
                </tr>--%>
                <tr id="trLogistics2" class="noborder" style="height: 85px;">
                    <td rowspan="4" >后勤事务部<br />意见<br />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>   
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label><input id="rdbOtherIDx11" type="radio" name="agree11" value="1" /><label for="rdbOtherIDx11">其他意见</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx11" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx11">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="tlsc1" class="noborder" style="height: 85px;display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" value="1" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx130">_________</span>
                        </span>
					</td>
				</tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>
                <tr id="trGeneralManager" class="noborder" style="height: 85px; ">
                    <td >董事总经理<br />审批</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label><input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label><input id="rdbOtherIDx12" type="radio" name="agree12" /><label for="rdbOtherIDx12">其他意见</label><br />
                        <textarea id="txtIDx12" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx12">_________</span>
                        </span>
                    </td>
                </tr>
                 
                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx131">_________</span>
                        </span>
					</td>
				</tr>
                                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3" >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx200">_________</span>
                        </span>
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
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx220">_________</span>
                        </span>
					</td>
				</tr>
                
            </table>
            <!--打印正文结束-->
        </div>

        <div class="noprint">
        <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" backcolor="White" style="clear: both; margin-top: 3px;"
            bordercolor="#DEDFDE" borderstyle="None" borderwidth="1px" cellpadding="4" autogeneratecolumns="false"
            forecolor="Black" gridlines="Vertical" onrowcommand="gvAttach_RowCommand">
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
        </asp:gridview>
        <div id="PageBottom">
        <hr />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>
        <asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
            <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
        <asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
        <asp:button runat="server" id="btnSignSave" text="标注已留档" onclick="btnSignSave_Click" visible="false" />
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
        <asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
        <asp:hiddenfield id="hdIsAgree" runat="server" />
        <asp:hiddenfield id="hdSuggestion" runat="server" />
        <input type="hidden" id="hdDetail" runat="server" />
            <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
        </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
</asp:Content>

