<%@ Page ValidateRequest="false" Title="项目部兼职申请 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_PartTime_Detail.aspx.cs" Inherits="Apply_PartTime_Apply_PartTime_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        p{margin:10px 0}
    </style>
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

        var jJSON = <%=SbJson.ToString() %>;
        $(function() {      
            i = $("#tbPropDepPre tr").length;
            $("#<%=txtDepartment.ClientID %>").autocomplete({ source: jJSON});
            $("#<%=this.txt9taC.ClientID%>").autocomplete({ source: jJSON});
            
            $("#<%=txt6taC.ClientID%>").datepicker();
            $("#<%=txt7taC.ClientID%>").datepicker();
            $("#<%=txt19taC.ClientID%>").datepicker();

            autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx200"));
            autoTextarea(document.getElementById("ctl00_ContentPlaceHolder1_txtIDx220"));
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


            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function check() {

            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {alert("申请编号不可为空！");$("#<%=txtApplyID.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {alert("发文部门不可为空！");$("#<%=txtDepartment.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt1taC.ClientID %>").val())=="") {alert("跟进人电话不可为空！");$("#<%=txt1taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt2taC.ClientID %>").val())=="") {alert("主题不可为空！");$("#<%=txt2taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt3taC.ClientID %>").val())=="") {alert("项目名称不可为空！");$("#<%=txt3taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt4taC.ClientID %>").val())=="") {alert("开发商名称不可为空！");$("#<%=txt4taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt5taC.ClientID %>").val())=="") {alert("项目地址不可为空！");$("#<%=txt5taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt6taC.ClientID %>").val())=="") {alert("项目代理开始期不可为空！");$("#<%=txt6taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt7taC.ClientID %>").val())=="") {alert("项目代理结束期不可为空！");$("#<%=txt7taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt8taC.ClientID %>").val())=="") {alert("住宅佣金点数不可为空！");$("#<%=txt8taC.ClientID %>").focus();return false;}

            if($.trim($("#<%=txt11taC.ClientID %>").val())=="") {alert("货量不可为空！");$("#<%=txt11taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt15taC.ClientID %>").val())=="") {alert("货值不可为空！");$("#<%=txt11taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt19taC.ClientID %>").val())=="") {alert("开售日不可为空！");$("#<%=txt19taC.ClientID %>").focus();return false;}
            //if($.trim($("#<%=txt18taC.ClientID %>").val())=="") {alert("开售日不可为空！");$("#<%=txt18taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt20taC.ClientID %>").val())=="") {alert("请选择代理模式！");$("#<%=txt20taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt21taC.ClientID %>").val())=="") {alert("兼职统筹人不可为空！");$("#<%=txt21taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt22taC.ClientID %>").val())=="") {alert("兼职统筹人联系方式不可为空！");$("#<%=txt22taC.ClientID %>").focus();return false;}
            if(!$("#<%=rdb24taC1.ClientID%>").prop("checked") && !$("#<%=rdb24taC2.ClientID%>").prop("checked"))
            {alert("请选择兼职方式！");$("#<%=rdb24taC1.ClientID %>").focus();return false;}
            if($("#<%=rdb24taC2.ClientID%>").prop("checked"))
            {
                if($.trim($("#<%=this.txt18taC.ClientID%>").val()) == "")
                {
                    alert("请填写兼职方式_费用");
                    $("#<%=this.txt18taC.ClientID%>").focus();
                    return false;
                }
                if($("#<%=this.txt25taC.ClientID%>").val() == "")
                {
                    alert("请填写兼职方式");
                    $("#<%=this.txt25taC.ClientID%>").focus();
                    return false;
                }
            }
            else
            {
                $("#<%=this.txt18taC.ClientID%>").val("");
            }

            if($.trim($("#<%=txt13taC.ClientID %>").val())=="") {alert("项目时间段不可为空！");$("#<%=txt13taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt14taC.ClientID %>").val())=="") {alert("项目时间段不可为空！");$("#<%=txt14taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt32taC.ClientID %>").val())=="") {alert("预计销售量1不可为空！");$("#<%=txt32taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt33taC.ClientID %>").val())=="") {alert("预计业绩1不可为空！");$("#<%=txt33taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt34taC.ClientID %>").val())=="") {alert("预计创佣1不可为空！");$("#<%=txt34taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt35taC.ClientID %>").val())=="") {alert("预计销售量2不可为空！");$("#<%=txt35taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt36taC.ClientID %>").val())=="") {alert("预计业绩2不可为空！");$("#<%=txt36taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt37taC.ClientID %>").val())=="") {alert("预计创佣2不可为空！");$("#<%=txt37taC.ClientID %>").focus();return false;}
            

            if($.trim($("#<%=txt16taC.ClientID %>").val())=="") {alert("兼职时间段不可为空！");$("#<%=txt16taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt17taC.ClientID %>").val())=="") {alert("兼职时间段不可为空！");$("#<%=txt17taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt39taC.ClientID %>").val())=="") {alert("兼职总费用不可为空！");$("#<%=txt39taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt40taC.ClientID %>").val())=="") {alert("兼职时间段预计创佣不可为空！");$("#<%=txt40taC.ClientID %>").focus();return false;}
            if($.trim($("#<%=txt41taC.ClientID %>").val())=="") {alert("兼职费用占佣比例不可为空！");$("#<%=txt41taC.ClientID %>").focus();return false;}

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

            //验证detail内容
            var array = new Array();
            flag = true;
            $("#jzqk tr").each(function(){
                $text = $(this).find("input[type='text']");
                var c = true;
                var json = {};
                $text.each(function () {
                    if ($.trim(this.value) == "") {
                        alert($(this).attr("emptymes"));
                        $(this).focus();
                        flag = false;
                        c = false;
                        return false;
                    }
                    json[$(this).attr("name")] = this.value;
                });
                if (!c) { return false; }
                array.push(json);
            });
            if(!flag) {
                $("#<%=this.hidDetail.ClientID%>").val("");
                return false; 
            }
            $("#<%=this.hidDetail.ClientID%>").val(Obj2str(array));
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
                window.location='Apply_PartTime_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_PartTime_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
                    if(win=='success')
                        window.location="Apply_PartTime_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
	            document.getElementById("<%=btnCancelSign.ClientID %>").click();
	        }
        }
		
        function sign(idx) {
            //if(idx!='3'&&idx!='6'&&idx!='7'&&idx!='8'&&idx!='9'&&idx!='12'&&idx!='11'&&idx!='130'&&idx!='131'){
            //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='11'){//789
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

        //function addRow() {
        //    i++;
            
        //    var html = '<tr id="trDetail' + i + '">'
        //        + '     <td style="width:24%"><select id="ddlDepartmentType' + i + '"><%=SbOptions.ToString()%></select></td>'
        //        + '     <td style="width:38%"><input type="text" id="txtPropDepPreCount' + i + '" /></td>'
        //        + '     <td style="width:38%"><input type="text" id="txtPropDepPreComm' + i + '" /></td></td>'
        //        + '</tr>';

        //    $("#tbPropDepPre").append(html);
        //}

        //function deleteRow() {
        //    if (i > 1) {
        //        $("#tbPropDepPre tr:eq(" + --i + ")").remove();
        //    } else
        //        alert("不可删除第一行。");
        //}
        
        function addrow(e,idname,obj)
        {
            var copytr = $("#" + idname + " tr").first().clone();
            if(obj != null && obj != undefined && isjson(obj))
            {
                for(var k in obj) {
                    $(copytr).find("input[name=" + k + "]").val(obj[k]);
                    //遍历对象，k即为key，obj[k]为当前k对应的值
                    //console.log(k);
                }
            }
            else
            {
                $(copytr).find("input[type=text]").val("");
            }
            $(copytr).find("[dateplugin='datepicker']").each(function(){
                $(this).removeAttr("id").removeAttr("class");
                $(this).datepicker();
            });
            $("#" + idname).append(copytr);
            return;
        }
        function delrow(e,idname)
        {
            var l = $("#" + idname + " tr").length;
            if(l == 1)
            {
                alert("最后一行不能再删");
                return;
            }
            $("#" + idname + " tr").last().remove();
        }

        //============2016-8-25  John Mingle================
        function PartTimeConditionChange()
        {
            var TextBoxNo = 0;//行内第几个input，3：兼职天数，4：兼职人数，5：兼职工资，6：兼职总费用
            var day=0,people=0,salary=0;
            var CostSum=0;
            $("#jzqk tr").find("input").each(function () {
                if (TextBoxNo == 7) {//换行
                    TextBoxNo = 1;
                    day=0;people=0;salary=0;
                }
                else {
                    if(TextBoxNo == 3){
                        if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) day=parseFloat($(this).val());
                    }
                    else if(TextBoxNo == 4){
                        if(/^\d+$/.test($(this).val())) people=parseInt($(this).val());
                    }
                    else if(TextBoxNo == 5){
                        if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) salary=parseFloat($(this).val());
                    }
                    else if(TextBoxNo == 6){
                        $(this).val(day*people*salary);
                        CostSum+=(day*people*salary);
                    }
                    TextBoxNo++;
                }
            });
            $("#<%=PartTimeCostSum.ClientID %>").val(CostSum);
        }

        function CalProportion(){
            if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($("#<%=txt39taC.ClientID %>").val())){
                if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($("#<%=txt40taC.ClientID %>").val()))
                {
                    $("#<%=txt41taC.ClientID %>").val((100.00*parseFloat($("#<%=txt39taC.ClientID %>").val())/parseFloat($("#<%=txt40taC.ClientID %>").val())).toFixed(2));
                }
                else $("#<%=txt41taC.ClientID %>").val("");
            }
            else $("#<%=txt41taC.ClientID %>").val("");  
        }
        //==============================================

        function isjson(obj){
            var isjson = typeof(obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length; 
            return isjson;
        }

        function getEmployee(n) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {}
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

        //20160427
        function DLClick(obj)
        {
            var val = obj.value;
            $("#<%=this.txt20taC.ClientID%>").val(val);
            //alert($("#<%=this.txt20taC.ClientID%>").val());
        }
        function PageInit()
        {
            //代理模式初始化
            var val1 = $("#<%=this.txt20taC.ClientID%>").val();
            $("input[name='chk20taC'][value='" + val1 + "']").prop("checked","true");
            
            //初始化detail
            if(!rundetail)
            {
                DetailInit("<%=this.hidDetail.ClientID%>");
                rundetail = true;
            }

            
            //初始化时间控件
            $("[dateplugin='datepicker']").each(function(){
                $(this).datepicker();
            });
        }
        
        function DetailInit(idname)
        {
            var detail = $("#" + idname).val();
            var list = detail == "" ? [] : $.parseJSON(detail);
            for(var i = 0 ; i < list.length;i++)
            {
                if(i == 0)
                {
                    var copytr = $("#jzqk tr").first();
                    if(list[i] != null && list[i] != undefined && isjson(list[i]))
                    {
                        var obj = list[i];
                        for(var k in obj) {
                            $(copytr).find("input[name=" + k + "]").val(obj[k]);
                            //遍历对象，k即为key，obj[k]为当前k对应的值
                            //console.log(k);
                        }
                    }
                    else
                    {
                        $(copytr).find("input[type=text]").val("");
                    }
                }
                else
                {
                    addrow(null,"jzqk",list[i]);
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>项目部兼职申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 700px; margin: 0 auto;"></div>
            <div style="width:700px;margin:0 auto;"><span style="float:right;">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='700px'>
                <tr>
                    <td colspan="4" class="tl PL10">
                        <div style="padding-top: 10px;">
                            <p>
                                <label>收文部门：</label><asp:textbox id="txt9taC" runat="server"></asp:textbox>  
                                <label style="display:inline-block;width:300px;text-align:right">发文日期：</label><asp:label id="lbApplyDate" runat="server" text="Label" Width="150px"></asp:label>
                                <asp:TextBox runat="server" dateplugin="true"></asp:TextBox>
                            </p>
                            <p>
                                <label>发文部门：</label><asp:textbox id="txtDepartment" runat="server"></asp:textbox> - <asp:Label ID="txtApply" runat="server" Text="Label"></asp:Label>
                                <%--<asp:textbox id="txtApply" runat="server"></asp:textbox>--%>
                                <label style="display:inline-block;width:258px;text-align:right">跟进人电话：</label><asp:textbox id="txt1taC" runat="server"></asp:textbox>
                            </p>
                            <p>
                                <label>主　题　：关于 <asp:textbox id="txt2taC" runat="server"></asp:textbox> 项目的兼职费用申请</label>
                                <label style="display:inline-block;width:167px;text-align:right">申请编号：</label><asp:textbox id="txtApplyID" runat="server"></asp:textbox>
                            </p>
                        </div><br />
                        <div style="width: 98%; border-bottom-style: groove; border-top-style: inset; border-top-width: 1px; border-bottom-width: 2px; height: 2px;"></div><br />

                        <div style="font-weight: bold; margin-bottom: 10px;">一、项目信息（必填）</div>
                        <table style="width: 97%; border-collapse: collapse">
                            <tr>
                                <td style="text-align: center">项目名称</td>
                                <td class="tl PL10"><asp:textbox id="txt3taC" runat="server" Width="96%"></asp:textbox></td>
                                <td style="text-align: center">开发商名称</td>
                                <td class="tl PL10"><asp:textbox id="txt4taC" runat="server" Width="96%"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">项目地址</td>
                                <td class="tl PL10" colspan="3"><asp:textbox id="txt5taC" runat="server" Width="98%"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">项目代理期</td>
                                <td class="tl PL10">
                                    <asp:textbox id="txt6taC" runat="server" Width="75px"></asp:textbox>～
                                    <asp:textbox id="txt7taC" runat="server" Width="75px"></asp:textbox>
                                </td>
                                <td style="text-align: center">佣金点数</td>
                                <td class="tl PL10">
                                    <asp:textbox id="txt8taC" runat="server" Width="96%"></asp:textbox>
                                    <%--住宅<asp:textbox id="txt8taC" runat="server" Width="50px"></asp:textbox>%，
                                    商业车位<asp:textbox id="txt9taC" runat="server" Width="50px"></asp:textbox>%--%>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">物业性质</td>
                                <td class="tl PL10" colspan="3"><asp:CheckBoxList ID="cblDealOfficeType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList><asp:TextBox ID="txt10taC" runat="server"></asp:TextBox><asp:HiddenField ID="hdDealOfficeType" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">货量</td>
                                <td class="tl PL10">
                                    <asp:textbox id="txt11taC" runat="server" Width="96%"></asp:textbox>
                                    <%--住宅<asp:textbox id="txt11taC" runat="server" Width="50px"></asp:textbox>套，
                                    商铺<asp:textbox id="txt12taC" runat="server" Width="50px"></asp:textbox>套，<br />
                                    车位<asp:textbox id="txt13taC" runat="server" Width="50px"></asp:textbox>套，
                                    总货量<asp:textbox id="txt14taC" runat="server" Width="50px"></asp:textbox>套--%>
                                </td>
                                <td style="text-align: center">货值</td>
                                <td class="tl PL10">
                                    <asp:textbox id="txt15taC" runat="server" Width="96%"></asp:textbox>
                                    <%--住宅<asp:textbox id="txt15taC" runat="server" Width="50px"></asp:textbox>亿，
                                    商铺<asp:textbox id="txt16taC" runat="server" Width="50px"></asp:textbox>亿，<br />
                                    车位<asp:textbox id="txt17taC" runat="server" Width="50px"></asp:textbox>万，
                                    总货值约<asp:textbox id="txt18taC" runat="server" Width="50px"></asp:textbox>亿--%>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">开售日</td>
                                <td class="tl PL10"><asp:textbox id="txt19taC" runat="server" Width="96%"></asp:textbox></td>
                                <td style="text-align: center">代理模式</td>
                                <td class="tl PL10">
                                    <input type="radio" name="chk20taC" id="chk20taC1" value="联合代理" onclick="DLClick(this)" /><label for="chk20taC1" style="color:rgb(0,129,98)">联合代理</label>
                                    <input type="radio" name="chk20taC" id="chk20taC2" value="独家代理" onclick="DLClick(this)" /><label for="chk20taC2" style="color:rgb(24,110,190)">独家代理</label>
                                    <%--<asp:textbox id="txt20taC" runat="server" Width="96%"></asp:textbox>--%>
                                    <asp:HiddenField ID="txt20taC" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">兼职统筹人</td>
                                <td class="tl PL10"><asp:textbox id="txt21taC" runat="server" Width="96%"></asp:textbox></td>
                                <td style="text-align: center">兼职统筹人<br />联系方式</td>
                                <td class="tl PL10">
                                    手&nbsp;&nbsp;&nbsp;&nbsp;机：<asp:textbox id="txt22taC" runat="server" Width="50%"></asp:textbox><br />
                                    微信号：<asp:textbox id="txt12taC" runat="server" Width="50%"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">兼职申请原因</td>
                                <td class="tl PL10" colspan="3"><asp:textbox id="txt23taC" runat="server" Width="98%" TextMode="MultiLine" Height="70px"></asp:textbox></td>
                            </tr>
                        </table>

                        <br />
                        <div style="font-weight: bold; margin-bottom: 10px;">二、兼职费用</div>
                        <table style="width: 97%; border-collapse: collapse; text-align: center;">
                            <tr>
                                <td style="text-align: center; font-weight: bold" colspan="4">兼职方式</td>
                            </tr>
                            <tr>
                                <td>方式</td>
                                <td colspan="2">兼职工资</td>
                                <td>选择</td>
                            </tr>
                            <tr>
                                <td>营销团队自行招聘+管理</td>
                                <td colspan="2" width="50%"><asp:TextBox ID="txt38taC" runat="server" Width="92%"></asp:TextBox></td>
                                <td><asp:RadioButton ID="rdb24taC1" runat="server" GroupName="24taC" /></td>
                            </tr>
                            
                            <tr>
                                <td><asp:textbox id="txt25taC" runat="server" Width="92%"></asp:textbox></td>
                                <td colspan="2" width="50%"><asp:TextBox ID="txt18taC" runat="server" Width="92%"></asp:TextBox></td>
                                <td><asp:RadioButton ID="rdb24taC2" runat="server" GroupName="24taC" /></td>
                            </tr>
                            <tr>
                                <td style="text-align:center; font-weight: bold" colspan="4">兼职情况</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                            <td rowspan="2" style="width:108px">兼职人员职责</td>
                                            <td rowspan="2">兼职时间</td>
                                            <td style="width:70px">兼职天数</td>
                                            <td style="width:70px">兼职人数</td>
                                            <td style="width:70px">兼职工资</td>
                                            <td style="width:100px">兼职总费用</td>
                                        </tr>
                                        <tr>
                                            <td>天</td>
                                            <td>人</td>
                                            <td>元/人/天</td>
                                            <td>(=兼职天数*兼职人数<br />*兼职工资)元</td>
                                        </tr>
                                        <tbody id="jzqk">
                                            <tr>
                                                <td><input type="text" style="width:100px" name="duty" emptymes="请填写兼职人员职责" /></td>
                                                <td><input type="text" style="width:80px" name="startdate" emptymes="请填写兼职时间" dateplugin="datepicker"  />~<input type="text" style="width:80px" name="enddate" emptymes="请填写兼职时间" dateplugin="datepicker" /></td>
                                                <td><input type="text" style="width:40px" name="day" emptymes="请填写兼职天数" onchange="PartTimeConditionChange();" /></td>
                                                <td><input type="text" style="width:40px" name="count" emptymes="请填写兼职人数" onchange="PartTimeConditionChange();" /></td>
                                                <td><input type="text" style="width:60px" name="payment" emptymes="请填写兼职工资"onchange="PartTimeConditionChange();" /></td>
                                                <td><input type="text" style="width:90px" name="totalcost" emptymes="请填写兼职总费用" /></td>
                                            </tr>
                                        </tbody>
                                        <tr>
                                                <td>合计：</td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td><asp:textbox runat="server" style="width:90px" id="PartTimeCostSum"/></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:left" colspan="6"><input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this,'jzqk',null)" /><input class="btnaddRowN" type="button" onclick="delrow(this,'jzqk')" value="删除一行" /></td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidDetail" runat="server" />
                                </td>
                            </tr>
                        </table>

                        <br />
                        <div style="font-weight: bold; margin-bottom: 10px;">三、预计项目收益</div>
                        <table style="width: 97%; border-collapse: collapse; text-align: center;">
                            <tr>
                                <td style="width:10%"></td>
                                <td >时间</td>
                                <td style="width:20%">预计销售量</td>
                                <td style="width:20%">预计业绩</td>
                                <td style="width:20%">预计创佣</td>
                            </tr>
                            <tr>
                                <td>项目时间段</td>
                                <td style="white-space:nowrap"><asp:textbox id="txt13taC" runat="server" Width="43%" dateplugin="datepicker" ></asp:textbox>至<asp:textbox id="txt14taC" runat="server" Width="43%" dateplugin="datepicker" ></asp:textbox></td>
                                <td><asp:textbox id="txt32taC" runat="server" Width="85%" ></asp:textbox>套</td>
                                <td><asp:textbox id="txt33taC" runat="server" Width="85%" ></asp:textbox>元</td>
                                <td><asp:textbox id="txt34taC" runat="server" Width="85%" ></asp:textbox>元</td>
                            </tr>
                            <tr>
                                <td>兼职时间段</td>
                                <td style="white-space:nowrap"><asp:textbox id="txt16taC" runat="server" Width="43%" dateplugin="datepicker" ></asp:textbox>至<asp:textbox id="txt17taC" runat="server" Width="43%" dateplugin="datepicker" ></asp:textbox></td>
                                <td><asp:textbox id="txt35taC" runat="server" Width="85%" ></asp:textbox>套</td>
                                <td><asp:textbox id="txt36taC" runat="server" Width="85%" ></asp:textbox>元</td>
                                <td><asp:textbox id="txt37taC" runat="server" Width="85%" ></asp:textbox>元</td>
                            </tr>
                        </table>

                        <br />
                        <div style="font-weight: bold; margin-bottom: 10px;">四、兼职费用占佣比例（兼职总费用÷兼职时间段预计创佣）</div>
                        <table style="width: 97%; border-collapse: collapse; text-align: center;">
                            <tr>
                                <%--<td style="width: 200px">项目</td>--%>
                                <td>兼职总费用</td>
                                <td style="width: 180px">兼职时间段预计创佣</td>
                                <td style="width: 100px">兼职费用占佣比例</td>
                            </tr>
                            <tr>
                                <%--<td><asp:textbox id="txt38taC" runat="server" Width="96%"></asp:textbox></td>--%>
                                <td><asp:textbox id="txt39taC" runat="server" Width="85%" onChange="CalProportion();"></asp:textbox>元</td>
                                <td><asp:textbox id="txt40taC" runat="server" Width="85%" onChange="CalProportion();"></asp:textbox>元</td>
                                <td><asp:textbox id="txt41taC" runat="server" Width="85%"></asp:textbox>%</td>
                            </tr>
                        </table>
                        <br /><br />
                        <div>　　特此申请，请公司批复!</div><br />
                        <div style="float: right; font-weight: bold; margin-right: 50px;">全卷完。</div><br /><br />
                    </td>
                </tr>


                <tr id="trManager1" class="noborder" style="height: 85px;">
                    <td style="width: 100px" >申请人</td>
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
                    <td >隶属主管</td>
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
                    <td >申请部门负责人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx3" type="radio" name="agree3"/><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow4" class="noborder" style="height: 85px;">
                    <td rowspan="2" >二级市场<br />负责人</td>
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
                        <textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAreaManager" class="noborder" style="height: 85px;">                                                             
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
                    <td rowspan="3" >人力资源部门<br />主管意见</td>                                                                                                           
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow7" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
                        <textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow8" class="noborder" style="height: 85px;">                                                                                          
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        <textarea id="txtIDx8" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow9" class="noborder" style="height: 85px;">
                    <td rowspan="2" >财务部门<br />主管意见</td>   
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label><input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label>
                        <asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton><br />
                        <textarea id="txtIDx9" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow10">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx10" type="radio" name="agree10" value="1" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" value="2" /><label for="rdbNoIDx10">不同意</label><input id="rdbOtherIDx10" type="radio" name="agree10" value="3" /><label for="rdbOtherIDx10">其他意见</label><br />
                        <textarea id="txtIDx10" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S4"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx10">_________</span>
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
                <tr id="trShowFlow11" class="noborder" style="height: 85px;"> 
                    <td rowspan="2" >后勤事务部<br />意见<br />
                        <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                        <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>                                                                                                           
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">确认</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">退回申请</label><br />
                        <textarea id="txtIDx11" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx11">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trLogistics2" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label><input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label><input id="rdbOtherIDx12" type="radio" name="agree12" value="1" /><label for="rdbOtherIDx12">其他意见</label>
                        　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                        <textarea id="txtIDx12" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx12">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" value="1" /><label for="rdbOtherIDx130">其他意见</label><br />
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
                        <input id="rdbYesIDx13" type="radio" name="agree13" /><label for="rdbYesIDx13">同意</label><input id="rdbNoIDx13" type="radio" name="agree13" /><label for="rdbNoIDx13">不同意</label>
                        <input id="rdbOtherIDx13" type="radio" name="agree13" /><label for="rdbOtherIDx13">其他意见</label><br />
                        <textarea id="txtIDx13" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx13" value="签署意见" onclick="sign('13')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx13">_________</span>
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
					<td >申请人回复审批意见<br />（可选项）</td>
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
					<td >董事总经理复审</td>
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
        <asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="False" />
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
    
    <script type="text/javascript">
        var rundetail = false;
        PageInit();
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
    <%=SbJs.ToString() %>
</asp:Content>

