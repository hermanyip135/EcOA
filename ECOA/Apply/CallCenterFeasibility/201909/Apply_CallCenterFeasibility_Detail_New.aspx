<%@ Page Title="新建呼叫中心可行性报告 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_CallCenterFeasibility_Detail_New.aspx.cs" Inherits="Apply_CallCenterFeasibility_Apply_CallCenterFeasibility_Detail_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Style/AddGroups.css" rel="stylesheet" />
    <script type="text/javascript">
        var i1a = 1,i2a = 1,i3a = 1,i4a = 1,i5a = 1,i2 = 1,i3 = 1,i4 = 1,i5 = 1,i6 = 1;

        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }
        ///增加集团审批
        function AddGroups(idx)
        {
            if(confirm("确定要集团审核？"))
            {
                
                $.ajax({
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=SaveGroups&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&idx=' + idx,
		            success: function(info) {
		                if (info == "success") {
		                    alert('已增加集团审批');
		                    location=location ;
		                }
		                else if (info == "NoPower")
		                    alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                        
                        }
                        else if("Existed" == info)
                        {
                            alert("已增加集团审批");
                        }
                        else
                            alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
		        })
              
}
           
}
function CancelGroups()
{
    if(confirm("确定要取消集团审核？"))
    {
        $.ajax({
            url: "/Ajax/Flow_Handler.ashx",
            type: "post",
            dataType: "text",
            data: 'action=CancelGroups&mainid=<%=MainID %>',
                    success: function(info) {
                        if (info == "success") {
                            alert('已取消集团审批');
                            location=location ;
                        }
                        else if (info == "NoPower")
                            alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                        
                        }
                        else if("Existed" == info)
                        {
                            alert("已取消集团审批");
                        }
                        else
                            alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
                })
}
}
        var jJSON = <%=SbJson.ToString() %>;

        $(function() {      
            //$( "#tabs" ).tabs();
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

            $("#Feasibility_m").mousedown(function () { 
                $(this).css("background-image", "url(/Images/feasibility_m2.png)"); 
                $("#Feasibility_j").css("background-image", "url(/Images/feasibility_j1.png)"); 
                $("#Feasibility_b").css("background-image", "url(/Images/feasibility_b1.png)"); 
                $("#Feasibility_c").css("background-image", "url(/Images/feasibility_c1.png)"); 
                $("#Feasibility_d").css("background-image", "url(/Images/feasibility_d1.png)"); 
            });
            $("#Feasibility_b").mousedown(function () { 
                $(this).css("background-image", "url(/Images/feasibility_b2.png)"); 
                $("#Feasibility_m").css("background-image", "url(/Images/feasibility_m1.png)"); 
                $("#Feasibility_j").css("background-image", "url(/Images/feasibility_j1.png)"); 
                $("#Feasibility_c").css("background-image", "url(/Images/feasibility_c1.png)"); 
                $("#Feasibility_d").css("background-image", "url(/Images/feasibility_d1.png)");
            });
            $("#Feasibility_c").mousedown(function () { 
                $(this).css("background-image", "url(/Images/feasibility_c2.png)"); 
                $("#Feasibility_m").css("background-image", "url(/Images/feasibility_m1.png)"); 
                $("#Feasibility_b").css("background-image", "url(/Images/feasibility_b1.png)"); 
                $("#Feasibility_j").css("background-image", "url(/Images/feasibility_j1.png)"); 
                $("#Feasibility_d").css("background-image", "url(/Images/feasibility_d1.png)");
            });
            $("#Feasibility_j").mousedown(function () { 
                $(this).css("background-image", "url(/Images/feasibility_j2.png)"); 
                $("#Feasibility_m").css("background-image", "url(/Images/feasibility_m1.png)"); 
                $("#Feasibility_c").css("background-image", "url(/Images/feasibility_c1.png)"); 
                $("#Feasibility_b").css("background-image", "url(/Images/feasibility_b1.png)"); 
                $("#Feasibility_d").css("background-image", "url(/Images/feasibility_d1.png)");
            });
            $("#Feasibility_d").mousedown(function () { 
                $(this).css("background-image", "url(/Images/feasibility_d2.png)"); 
                $("#Feasibility_m").css("background-image", "url(/Images/feasibility_m1.png)"); 
                $("#Feasibility_a").css("background-image", "url(/Images/feasibility_a1.png)"); 
                $("#Feasibility_b").css("background-image", "url(/Images/feasibility_b1.png)"); 
                $("#Feasibility_j").css("background-image", "url(/Images/feasibility_j1.png)");
            });

            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
		        }
            });

            i1a = $("#tbDetail1a tr").length - 4;
            i2a = $("#tbDetail2a tr").length - 3;
            i3a = $("#tbDetail3a tr").length - 3;
            i4a = $("#tbDetail4a tr").length - 3;
            i5a = $("#tbDetail5a tr").length - 3;
            i2 = $("#tbDetail2 tr").length - 2;
            i3 = $("#tbDetail3 tr").length - 2;
            i4 = $("#tbDetail4 tr").length - 2;
            i5 = $("#tbDetail5 tr").length - 3;
            i6 = $("#tbDetail6 tr").length - 2;

            $("#<%=txtReachDate.ClientID%>").datepicker();
            $("#<%=txtMonthProfitRDate.ClientID%>").datepicker();
            $("#<%=txtRentFreeStart.ClientID%>").datepicker();
            $("#<%=txtRentFreeEnd.ClientID%>").datepicker();
            $("#<%=txtCompleteDate.ClientID%>").datepicker();
            $("#<%=txtLeaseStartDate.ClientID%>").datepicker();
            $("#<%=txtLeaseEndDate.ClientID%>").datepicker();

            for (var x = 1; x <= i1a; x++) {
                $("#ros1a").attr("rowspan", i1a+1);
            }
            for (var x = 1; x <= i2a; x++) {
                $("#ros2a").attr("rowspan", i2a+1);
            }
            for (var x = 1; x <= i3a; x++) {
                $("#ros3a").attr("rowspan", i3a+1);
            }
            for (var x = 1; x <= i4a; x++) {
                $("#ros4a").attr("rowspan", i4a+1);
            }
            for (var x = 1; x <= i5a; x++) {
                $("#ros5a").attr("rowspan", i5a+1);
            }
            for (var x = 1; x <= i3; x++) {  //使详情表的日期变得可选
                $("#txtSetUpTime" + x).datepicker();
            }
            for (var x = 1; x <= i4; x++) {  //使详情表的日期变得可选
                $("#txtDealBeginDate" + x).datepicker();
                $("#txtDealEndDate" + x).datepicker();
            }

            for (var x = 1; x <= i1a; x++) {
                $("#txtSeniorDirector1a"+x).blur(function(){
                    //alert(this.id + "*" + $("#"+this.id).val());
                    var k = this.id;
                    $.ajax({
                        url: "/Ajax/Apply_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=FeasibilityMenberAuto&aid='+$("#"+k).val(),
                        success: function(info) {
                            var v = info.split("|");
                            $("#txtbusinessManager1a"+$.trim(k).replace("txtSeniorDirector1a","")).val(v[2]);
                            $("#txtName1a"+$.trim(k).replace("txtSeniorDirector1a","")).val(v[1]);
                            $("#txtNum1a"+$.trim(k).replace("txtSeniorDirector1a","")).val(v[3]);
                        }
                    })
                });
            }
            for (var x = 1; x <= i2a; x++) {
                $("#txtSeniorDirector2a"+x).blur(function(){
                    //alert(this.id + "*" + $("#"+this.id).val());
                    var k = this.id;
                    $.ajax({
                        url: "/Ajax/Apply_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=FeasibilityMenberAuto&aid='+$("#"+k).val(),
                        success: function(info) {
                            var v = info.split("|");
                            $("#txtbusinessManager2a"+$.trim(k).replace("txtSeniorDirector2a","")).val(v[2]);
                            $("#txtName2a"+$.trim(k).replace("txtSeniorDirector2a","")).val(v[1]);
                            $("#txtNum2a"+$.trim(k).replace("txtSeniorDirector2a","")).val(v[3]);
                        }
                    })
                });
            }
            for (var x = 1; x <= i3a; x++) {
                $("#txtSeniorDirector3a"+x).blur(function(){
                    //alert(this.id + "*" + $("#"+this.id).val());
                    var k = this.id;
                    $.ajax({
                        url: "/Ajax/Apply_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=FeasibilityMenberAuto&aid='+$("#"+k).val(),
                        success: function(info) {
                            var v = info.split("|");
                            $("#txtbusinessManager3a"+$.trim(k).replace("txtSeniorDirector3a","")).val(v[2]);
                            $("#txtName3a"+$.trim(k).replace("txtSeniorDirector3a","")).val(v[1]);
                            $("#txtNum3a"+$.trim(k).replace("txtSeniorDirector3a","")).val(v[3]);
                        }
                    })
                });
            }
            for (var x = 1; x <= i4a; x++) {
                $("#txtSeniorDirector4a"+x).blur(function(){
                    //alert(this.id + "*" + $("#"+this.id).val());
                    var k = this.id;
                    $.ajax({
                        url: "/Ajax/Apply_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=FeasibilityMenberAuto&aid='+$("#"+k).val(),
                        success: function(info) {
                            var v = info.split("|");
                            $("#txtbusinessManager4a"+$.trim(k).replace("txtSeniorDirector4a","")).val(v[2]);
                            $("#txtName4a"+$.trim(k).replace("txtSeniorDirector4a","")).val(v[1]);
                            $("#txtNum4a"+$.trim(k).replace("txtSeniorDirector4a","")).val(v[3]);
                        }
                    })
                });
            }
            for (var x = 1; x <= i5a; x++) {
                $("#txtSeniorDirector5a"+x).blur(function(){
                    //alert(this.id + "*" + $("#"+this.id).val());
                    var k = this.id;
                    $.ajax({
                        url: "/Ajax/Apply_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=FeasibilityMenberAuto&aid='+$("#"+k).val(),
                        success: function(info) {
                            var v = info.split("|");
                            $("#txtbusinessManager5a"+$.trim(k).replace("txtSeniorDirector5a","")).val(v[2]);
                            $("#txtName5a"+$.trim(k).replace("txtSeniorDirector5a","")).val(v[1]);
                            $("#txtNum5a"+$.trim(k).replace("txtSeniorDirector5a","")).val(v[3]);
                        }
                    })
                });
            }
            //autoTextarea(document.getElementById("txtIDx11"));
            //$.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
        
        function SetHidInput(names,startindex,endindex)
        {
            for(var i = 0 ; i < names.length ; i++)
            {
                //input序号从4开始9结束
                var val = "";
                for(var j = startindex ; j <= endindex;j++)
                {
                    val = "";
                    var inputs = $("input[name=" + names[i] + j + "]");
                    inputs.each(function(){
                        val += $(this).val() + "|";
                    });
                    val = val.substr(0, val.length - 1);       //去最后的,号
                    var hidinputid = "ctl00_ContentPlaceHolder1_" + names[i].replace("txt","hid") + j;
                    $("#" + hidinputid).val(val);
                }
            }
        }

        function check() {
            var data1a = "", data2a = "", data3a = "", data4a = "", data5a = "", data2 = "", data3 = "", data4 = "", data5 = "", data6 = "";
            var flag1a = true,flag2a = true,flag3a = true,flag4a = true,flag5a = true,flag2 = true,flag3 = true,flag4 = true,flag5 = true,flag6 = true;

            $("#tbDetail1a tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail1a tr").size() - 3) {
                    data1a += $.trim($("#txtAreaManager1a" + n).html())
                            + "&&" + $.trim($("#txtSeniorDirector1a" + n).val())
                            + "&&" + 1
                            + "&&" + $.trim($("#txtbusinessManager1a" + n).val())
                            + "&&" + $.trim($("#txtName1a" + n).val())
                            + "&&" + $.trim($("#txtNum1a" + n).val())
                            + "&&" + $.trim($("#txtUpperManager1a" + n).val())
                            + "||";
                }
            });

            if (flag1a) {
                data1a = data1a.substr(0, data1a.length - 2);
                $("#<%=HiddenField1a.ClientID %>").val(data1a);
            }
            else
                return false;

            $("#tbDetail2a tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail2a tr").size() - 2) {
                    data2a += $.trim($("#txtAreaManager2a" + n).html())
                            + "&&" + $.trim($("#txtSeniorDirector2a" + n).val())
                            + "&&" + 2
                            + "&&" + $.trim($("#txtbusinessManager2a" + n).val())
                            + "&&" + $.trim($("#txtName2a" + n).val())
                            + "&&" + $.trim($("#txtNum2a" + n).val())
                            + "&&" + $.trim($("#txtUpperManager2a" + n).val())
                            + "||";
                }
            });
            if (flag2a) {
                data2a = data2a.substr(0, data2a.length - 2);
                $("#<%=HiddenField2a.ClientID %>").val(data2a);
            }
            else
                return false;




            $("#tbDetail3a tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail3a tr").size() - 2) {
                    data3a += $.trim($("#txtAreaManager3a" + n).html())
                            + "&&" + $.trim($("#txtSeniorDirector3a" + n).val())
                            + "&&" + 3
                            + "&&" + $.trim($("#txtbusinessManager3a" + n).val())
                            + "&&" + $.trim($("#txtName3a" + n).val())
                            + "&&" + $.trim($("#txtNum3a" + n).val())
                            + "&&" + $.trim($("#txtUpperManager3a" + n).val())
                            + "||";
                }
            });
            if (flag3a) {
                data3a = data3a.substr(0, data3a.length - 2);
                $("#<%=HiddenField3a.ClientID %>").val(data3a);
            }
            else
                return false;

            $("#tbDetail4a tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail4a tr").size() - 2) {
                    data4a += $.trim($("#txtAreaManager4a" + n).html())
                            + "&&" + $.trim($("#txtSeniorDirector4a" + n).val())
                            + "&&" + 4
                            + "&&" + $.trim($("#txtbusinessManager4a" + n).val())
                            + "&&" + $.trim($("#txtName4a" + n).val())
                            + "&&" + $.trim($("#txtNum4a" + n).val())
                            + "&&" + $.trim($("#txtUpperManager4a" + n).val())
                            + "||";
                }
            });
            if (flag4a) {
                data4a = data4a.substr(0, data4a.length - 2);
                $("#<%=HiddenField4a.ClientID %>").val(data4a);
            }
            else
                return false;

            $("#tbDetail5a tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail5a tr").size() - 2) {
                    data5a += $.trim($("#txtAreaManager5a" + n).html())
                            + "&&" + $.trim($("#txtSeniorDirector5a" + n).val())
                            + "&&" + 5
                            + "&&" + $.trim($("#txtbusinessManager5a" + n).val())
                            + "&&" + $.trim($("#txtName5a" + n).val())
                            + "&&" + $.trim($("#txtNum5a" + n).val())
                            + "&&" + $.trim($("#txtUpperManager5a" + n).val())
                            + "||";
                }
            });
            if (flag5a) {
                data5a = data5a.substr(0, data5a.length - 2);
                $("#<%=HiddenField5a.ClientID %>").val(data5a);
            }
            else
                return false;


            //为id=t,id=Table2,id=Table3,id=Table4中的input[type=hidden]赋值
            var inputnames = ["txtLastYearSituation","txtThisYearSituation"];
            //starindex=4,endindex=9
            SetHidInput(inputnames,4,9);
	        
            inputnames = ["txtBusinessSituation","txtProfitSituation"];
            //starindex=7,endindex=18
            SetHidInput(inputnames,7,18);

            inputnames = ["txtAccumulationSituation","txtStandardSituation"];
            //starindex=6,endindex=15
            SetHidInput(inputnames,6,15);
            //return false;



            $("#tbDetail6 tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail6 tr").size() - 1) {
                    data6 += $.trim($("#txtYearNo" + n).val()) 
                            + "&&" + $.trim($("#txtNoTaxRent" + n).val()) 
                            + "&&" + $.trim($("#txtHasTaxRent" + n).val())
                            + "&&" + $.trim($("#txtRentCoast" + n).val())
                            + "&&" + $.trim($("#txtRateOfAdd" + n).val()) 
                            + "&&" + $.trim($("#txtRentOfAdd" + n).val())
                            + "||";
                }
            });

            if (flag6) {
                data6 = data6.substr(0, data6.length - 2);
                $("#<%=HiddenField6.ClientID %>").val(data6);
            }
            else
                return false;
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
		        window.location='Apply_CallCenterFeasibility_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_CallCenterFeasibility_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=830px;dialogHeight=280px");
            if(win=='success')
                window.location="Apply_CallCenterFeasibility_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }
		
                function sign(idx) {
                    //if(idx!='4'&&idx!='5'&&idx=='6'&&idx!='8'&&idx!='9'&&idx=='10'){
                    //if(idx=='1'||idx=='2'||idx=='3'||idx=='8'||idx=='9'||idx=='10'||idx=='13'){//789
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

        function addRow1a(e) {
            $td = $(e).parent()
            rowspan = $td.attr("rowspan");
           
            $td.attr("rowspan", parseInt(rowspan) + 1);
            i1a++;
            var html = '<tr id="trDetail1a' + i1a + '">'
				//+ '         <td><input type="hidden" id="txtAreaManager' + i1a + '" value="'+i1a+'" /><textarea id="txtbusinessManager' + i1a + '" style="width:140px"/></textarea></td>'
                + '         <td><span id="txtAreaManager1a' + i1a + '" style="display:none;">'+i1a+'</span><textarea id="txtSeniorDirector1a' + i1a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtbusinessManager1a' + i1a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtName1a' + i1a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtNum1a' + i1a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtUpperManager1a' + i1a + '" style="width:140px"/></textarea></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail1a' + i1a + '"><table><tr><td>这是'+ i1a +'个</td></tr></table></tr>'
            $("#trFlag1a").before(html);
            $("#ros1a").attr("rowspan", i1a+1);
            $("#txtSeniorDirector1a" + i1a).blur(function(){
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=FeasibilityMenberAuto&aid=' + $(this).val(),
                    success: function(info) {
                        var v = info.split("|");
                        $("#txtbusinessManager1a" + i1a).val(v[2]);
                        $("#txtName1a" + i1a).val(v[1]);
                        $("#txtNum1a" + i1a).val(v[3]);
                    }
                })
            });
            //$.each($("textarea"), function (idx, item) { autoTextarea(this); });
        }
        function deleteRow1a() {
            if (i1a > 1) {
                i1a--;
                $("#tbDetail1a tr:eq(" + (i1a+3) + ")").remove();
            } else
                alert("不可删除第一行。");
        }


        function addRow2a() {
            i2a++;
            var html = '<tr id="trDetail2a' + i2a + '">'
                + '         <td><span id="txtAreaManager2a' + i2a + '" style="display:none;">'+i2a+'</span><textarea id="txtSeniorDirector2a' + i2a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtbusinessManager2a' + i2a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtName2a' + i2a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtNum2a' + i2a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtUpperManager2a' + i2a + '" style="width:140px"/></textarea></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail' + i2a + '"><table><tr><td>这是'+ i2a +'个</td></tr></table></tr>'
            $("#trFlag2a").before(html);
            $("#ros2a").attr("rowspan", i2a+1);
            $("#txtSeniorDirector2a" + i1a).blur(function(){
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=FeasibilityMenberAuto&aid=' + $(this).val(),
                    success: function(info) {
                        var v = info.split("|");
                        $("#txtbusinessManager2a" + i1a).val(v[2]);
                        $("#txtName2a" + i1a).val(v[1]);
                        $("#txtNum2a" + i1a).val(v[3]);
                    }
                })
            });
            //$.each($("textarea"), function (idx, item) { autoTextarea(this); });
        }
        function deleteRow2a() {
            if (i2a > 1) {
                i2a--;
                $("#tbDetail2a tr:eq(" + (i2a+2) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow3a() {
            i3a++;
            var html = '<tr id="trDetail4a' + i3a + '">'
                + '         <td><span id="txtAreaManager3a' + i3a + '" style="display:none;">'+i3a+'</span><textarea id="txtSeniorDirector3a' + i3a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtbusinessManager3a' + i3a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtName3a' + i3a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtNum3a' + i3a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtUpperManager3a' + i3a + '" style="width:140px"/></textarea></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail' + i2a + '"><table><tr><td>这是'+ i2a +'个</td></tr></table></tr>'
            $("#trFlag3a").before(html);
            $("#ros3a").attr("rowspan", i3a+1);
            $("#txtSeniorDirector3a" + i1a).blur(function(){
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=FeasibilityMenberAuto&aid=' + $(this).val(),
                    success: function(info) {
                        var v = info.split("|");
                        $("#txtbusinessManager3a" + i1a).val(v[2]);
                        $("#txtName3a" + i1a).val(v[1]);
                        $("#txtNum3a" + i1a).val(v[3]);
                    }
                })
            });
            //$.each($("textarea"), function (idx, item) { autoTextarea(this); });
        }
        function deleteRow3a() {
            if (i3a > 1) {
                i3a--;
                $("#tbDetail3a tr:eq(" + (i3a+2) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow4a() {
            i4a++;
            var html = '<tr id="trDetail4a' + i4a + '">'
                + '         <td><span id="txtAreaManager4a' + i4a + '" style="display:none;">'+i4a+'</span><textarea id="txtSeniorDirector4a' + i4a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtbusinessManager4a' + i4a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtName4a' + i4a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtNum4a' + i4a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtUpperManager4a' + i4a + '" style="width:140px"/></textarea></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail' + i4a + '"><table><tr><td>这是'+ i4a +'个</td></tr></table></tr>'
            $("#trFlag4a").before(html);
            $("#ros4a").attr("rowspan", i4a+1);
            $("#txtSeniorDirector4a" + i1a).blur(function(){
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=FeasibilityMenberAuto&aid=' + $(this).val(),
                    success: function(info) {
                        var v = info.split("|");
                        $("#txtbusinessManager4a" + i1a).val(v[2]);
                        $("#txtName4a" + i1a).val(v[1]);
                        $("#txtNum4a" + i1a).val(v[3]);
                    }
                })
            });
            //$.each($("textarea"), function (idx, item) { autoTextarea(this); });
        }
        function deleteRow4a() {
            if (i4a > 1) {
                i4a--;
                $("#tbDetail4a tr:eq(" + (i4a+2) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow5a() {
            i5a++;
            var html = '<tr id="trDetail5a' + i5a + '">'
                + '         <td><span id="txtAreaManager5a' + i5a + '" style="display:none;">'+i5a+'</span><textarea id="txtSeniorDirector5a' + i5a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtbusinessManager5a' + i5a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtName5a' + i5a + '" style="width:70px"/></textarea></td>'
                + '         <td><textarea id="txtNum5a' + i5a + '" style="width:140px"/></textarea></td>'
                + '         <td><textarea id="txtUpperManager5a' + i5a + '" style="width:140px"/></textarea></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail' + i5a + '"><table><tr><td>这是'+ i5a +'个</td></tr></table></tr>'
            $("#trFlag5a").before(html);
            $("#ros5a").attr("rowspan", i5a+1);
            $("#txtSeniorDirector5a" + i1a).blur(function(){
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=FeasibilityMenberAuto&aid=' + $(this).val(),
                    success: function(info) {
                        var v = info.split("|");
                        $("#txtbusinessManager5a" + i1a).val(v[2]);
                        $("#txtName5a" + i1a).val(v[1]);
                        $("#txtNum5a" + i1a).val(v[3]);
                    }
                })
            });
            //$.each($("textarea"), function (idx, item) { autoTextarea(this); });
        }
        function deleteRow5a() {
            if (i5a > 1) {
                i5a--;
                $("#tbDetail5a tr:eq(" + (i5a+2) + ")").remove();
            } else
                alert("不可删除第一行。");
        }















        function addRow2() {
            i2++;
            var html = '<tr id="trDetail2' + i2 + '">'
				+ '     <td><input type="text" id="txtBuildingName' + i2 + '" style="width:100px"/></td>'
				+ '     <td><input type="text" id="txtCsell' + i2 + '" style="width:100px"/></td>'
                + '     <td><input type="text" id="txtMainSquare' + i2 + '" style="width:100px"/></td>'
				+ '     <td><input type="text" id="txtAvarageCoast' + i2 + '" style="width:100px"/></td>'
                + '     <td><input type="radio" id="rdbIsMain' + i2 + '1" name="IsMain' + i2 + '" /><label for="rdbIsMain' + i2 + '1">是</label><input type="radio" id="rdbIsMain' + i2 + '0" name="IsMain' + i2 + '" /><label for="rdbIsMain' + i2 + '0">否</label></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail2' + i2 + '"><table><tr><td>这是'+ i2 +'个</td></tr></table></tr>'
            $("#trFlag2").before(html);
        }
        function deleteRow2() {
            if (i2 > 1) {
                i2--;
                $("#tbDetail2 tr:eq(" + (i2 + 1) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow3() {
            i3++;
            var html = '<tr id="trDetail3' + i3 + '">'
				+ '     <td><input type="text" id="txtBusinessName' + i3 + '" style="width:150px"/></td>'
				+ '     <td><input type="text" id="txtWitchBranch' + i3 + '" style="width:150px"/></td>'
                + '     <td><input type="text" id="txtSetUpTime' + i3 + '" style="width:80px"/></td>'
				+ '     <td><input type="text" id="txtResults' + i3 + '" style="width:100px"/></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail3' + i3 + '"><table><tr><td>这是'+ i3 +'个</td></tr></table></tr>'
            $("#trFlag3").before(html);
            $("#txtSetUpTime" + i3).datepicker();
        }
        function deleteRow3() {
            if (i3 > 1) {
                i3--;
                $("#tbDetail3 tr:eq(" + (i3 + 1) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow4() {
            i4++;
            var html = '<tr id="trDetail4' + i4 + '">'
				+ '     <td><input type="text" id="txtWhatBuding' + i4 + '" style="width:150px"/></td>'
				+ '     <td><input type="text" id="txtDealBeginDate' + i4 + '" style="width:80px"/>～<input type="text" id="txtDealEndDate' + i4 + '" style="width:80px"/></td>'
				+ '     <td><input type="text" id="txtSumGet' + i4 + '" style="width:100px"/></td>'
                + '     <td><input type="text" id="txtSumRent' + i4 + '" style="width:100px"/></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail4' + i4 + '"><table><tr><td>这是'+ i4 +'个</td></tr></table></tr>'
            $("#trFlag4").before(html);
            $("#txtDealBeginDate" + i4).datepicker();
            $("#txtDealEndDate" + i4).datepicker();
        }
        function deleteRow4() {
            if (i4 > 1) {
                i4--;
                $("#tbDetail4 tr:eq(" + (i4 + 1) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow5() {
            i5++;
            var html = '<tr id="trDetail5' + i5 + '" class="tb5tr">'
                + '     <td><input type="text" id="txtBname' + i5 + '" style="width:100px"/></td>'
				+ '     <td><input type="text" id="txtGzspsNum' + i5 + '" style="width:30px" onblur="Sum()"/></td>'
				+ '     <td><input type="text" id="txtGzspsRate' + i5 + '" style="width:35px"/>%</td>'
				+ '     <td><input type="text" id="txtRichNum' + i5 + '" style="width:30px" onblur="Sum()"/></td>'
                + '     <td><input type="text" id="txtRichRate' + i5 + '" style="width:35px"/>%</td>'
                + '     <td><input type="text" id="txtEveryNum' + i5 + '" style="width:30px" onblur="Sum()"/></td>'
				+ '     <td><input type="text" id="txtEveryRate' + i5 + '" style="width:35px"/>%</td>'
				+ '     <td><input type="text" id="txtYuFengNum' + i5 + '" style="width:30px" onblur="Sum()"/></td>'
                + '     <td><input type="text" id="txtYuFengRate' + i5 + '" style="width:35px"/>%</td>'
                + '     <td><input type="text" id="txtOtherNum' + i5 + '" style="width:30px" onblur="Sum()"/></td>'
				+ '     <td><input type="text" id="txtOtherRate' + i5 + '" style="width:35px"/>%</td>'
				+ '     <td><input type="text" id="txtFreeNum' + i5 + '" style="width:30px" onblur="Sum()"/></td>'
                + '     <td><input type="text" id="txtFreeRate' + i5 + '" style="width:35px"/>%</td>'
                + '     <td><input type="text" id="txtAllSum' + i5 + '" style="width:35px"/></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail5' + i5 + '"><table><tr><td>这是'+ i5 +'个</td></tr></table></tr>'
            $("#sumtr").before(html);
        }
        function deleteRow5() {
            if (i5 > 2) {
                i5--;
                $("#tbDetail5 tr:eq(" + (i5 + 1) + ")").remove();
            } else
                alert("不可删除第一行。");
        }

        function addRow6() {
            i6++;
            var html = '<tr id="trDetail6' + i6 + '">'
				+ '     <td>第<input type="text" id="txtYearNo' + i6 + '" style="width:40px"/>年</td>'
				+ '     <td><input type="text" id="txtNoTaxRent' + i6 + '" style="width:50px"/></td>'
                + '     <td><input type="text" id="txtHasTaxRent' + i6 + '" style="width:50px"/></td>'
				+ '     <td><input type="text" id="txtRentCoast' + i6 + '" style="width:50px"/></td>'
                + '     <td><input type="text" id="txtRateOfAdd' + i6 + '" style="width:50px"/></td>'
				+ '     <td><input type="text" id="txtRentOfAdd' + i6 + '" style="width:50px"/></td>'
				+ '</tr>';
            //var html = '<tr id="trDetail6' + i6 + '"><table><tr><td>这是'+ i6 +'个</td></tr></table></tr>'
            $("#trFlag6").before(html);
        }
        function deleteRow6() {
            if (i6 > 1) {
                i6--;
                $("#tbDetail6 tr:eq(" + (i6 + 1) + ")").remove();
            } else
                alert("不可删除第一行。");
        }
		
        function getEmployee(n) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
		            
                        $("#<%=txtDepartment.ClientID%>").val(infos[2]);
		                $("#spanApplyFor").show();
                    }
                    else{
                        $("#<%=txtDepartment.ClientID%>").val("");
		                $("#spanApplyFor").hide();
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
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    async: false,
                    cache: false,
                    data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+14,
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

        //区域及片区的业绩、利润情况（请用管理帐数据）
        //添加行
        function AddRow(obj,inputname,type)
        {
            var html = "";
            if(type=="szj")
            {
                html = "<tr class='szj'>"
                       
                       +"<td><input type='text' name='" +  inputname + "4' style='width:100px' /></td>"
                       +"<td><input type='text' name='" +  inputname + "5' style='width:100px' /></td>"
                       +"<td><input type='text' name='" +  inputname + "6' style='width:100px' /></td>"
                       +"</tr>";
            }
            else if(type=="sqj")
            {
                html = "<tr class='sqj'>"
                       +"<td><input type='text' name='" +  inputname + "7' style='width:100px' /></td>"
                       +"<td><input type='text' name='" +  inputname + "8' style='width:100px' /></td>"
                       +"<td><input type='text' name='" +  inputname + "9' style='width:100px' /></td>"
                       +"</tr>";
            }
            var $tb = $(obj).parent().parent().parent();
            var rowspan = $tb.find("." + type).length;
            var $td = $(obj).parent();
            $td.attr("rowspan",rowspan+1);
            //$td.parent().after(html);
            $tb.find("." + type).last().after(html);
                                    
        }
        //删除行
        function DelRow(obj,type)
        {
            var $tb = $(obj).parent().parent().parent();
            var rowspan = $tb.find("." + type).length;
            if(rowspan <= 1)
            {
                alert("不能再删了");
                return;
            }
            rowspan--;
            $tb.find("." + type).last().remove();
            $(obj).parent().attr("rowspan",rowspan);

            //var $tb = $(obj).parent().parent().parent();
            //$(obj).parent().parent().prev().remove();
        }

        //
        //添加行
        function AddRow2(obj,inputname,type)
        {
            var html = "";
            if(type == "szj")
            {
                html = "<tr class='szj'>"
                          +"<td><input type='text' name='" + inputname + "7' style='width:60px' /></td>"
                          +"<td><input type='text' name='" + inputname + "8' style='width:60px' /></td>"
                          +"<td><input type='text' name='" + inputname + "9' style='width:60px' /></td>"
                          +"<td><input type='text' name='" + inputname + "10' style='width:60px' /></td>"
                          +"<td><input type='text' name='" + inputname + "11' style='width:60px' /></td>"
                          +"<td><input type='text' name='" + inputname + "12' style='width:60px' /></td>"
                          +"</tr>";
            }
            else if(type == "sqj")
            {
                html = "<tr class='sqj'>"
                       +"<td><input type='text' name='" + inputname + "13' style='width:60px' /></td>"
                       +"<td><input type='text' name='" + inputname + "14' style='width:60px' /></td>"
                       +"<td><input type='text' name='" + inputname + "15' style='width:60px' /></td>"
                       +"<td><input type='text' name='" + inputname + "16' style='width:60px' /></td>"
                       +"<td><input type='text' name='" + inputname + "17' style='width:60px' /></td>"
                       +"<td><input type='text' name='" + inputname + "18' style='width:60px' /></td>"
                       +"</tr>";
            }
            var $tb = $(obj).parent().parent().parent();
            var rowspan = $tb.find("." + type).length;
            var $td = $(obj).parent();
            $td.attr("rowspan",rowspan+1);
            $tb.find("." + type).last().after(html);
        }

        //添加行
        function AddtbAgentRuleRow(obj,inputname,type)
        {
            var html = "";
            if(type == "szj")
            {
                html = "<tr class='szj'>"
                         + "<td><input name='" + inputname + "6' style='width:60px' /></td>"
                         + "<td><input name='" + inputname + "7' style='width:60px' /></td>"
                         + "<td><input name='" + inputname + "8' style='width:60px' /></td>"
                         + "<td><input name='" + inputname + "9' style='width:60px' /></td>"
                         + "<td><input name='" + inputname + "10' style='width:60px' /></td>"
                         + "</tr>";
            }
            else if(type=="sqj")
            {
                html = "<tr class='sqj'>"
                         + "<td><input name='" + inputname + "11' style='width:60px' /></td>"
                         + "<td><input name='" + inputname + "12' style='width:60px' /></td>"
                         + "<td><input name='" + inputname + "13' style='width:60px' /></td>"
                         + "<td><input name='" + inputname + "14' style='width:60px' /></td>"
                         + "<td><input name='" + inputname + "15' style='width:60px' /></td>"
                         +"</tr>";
            }
            var $tb = $(obj).parent().parent().parent();
            var rowspan = $tb.find("." + type).length;
            var $td = $(obj).parent();
            $td.attr("rowspan",rowspan+1);
            $tb.find("." + type).last().after(html);
        }

        //添加行
        function AddTable5Row(obj,inputname,type)
        {
            var html = "";
            if(type == "szj")
            {
                html = "<tr class='szj'>"
                             + "<td><input name='" + inputname + "6' style='width:60px' /></td>"
                             + "<td><input name='" + inputname + "7' style='width:60px' /></td>"
                             + "<td><input name='" + inputname + "8' style='width:60px' />%</td>"
                             + "<td><input name='" + inputname + "9' style='width:60px' /></td>"
                             + "<td><input name='" + inputname + "10' style='width:60px' />%</td>"
                             + "</tr>";
            }
            else if(type == "sqj")
            {
                html = "<tr class='sqj'>"
                             + "<td><input name='" + inputname + "11' style='width:60px' /></td>"
                             + "<td><input name='" + inputname + "12' style='width:60px' /></td>"
                             + "<td><input name='" + inputname + "13' style='width:60px' />%</td>"
                             + "<td><input name='" + inputname + "14' style='width:60px' /></td>"
                             + "<td><input name='" + inputname + "15' style='width:60px' />%</td>"
                             +"</tr>";
            }
            var $tb = $(obj).parent().parent().parent();
            var rowspan = $tb.find("." + type).length;
            var $td = $(obj).parent();
            $td.attr("rowspan",rowspan+1);
            $tb.find("." + type).last().after(html);
        }

        //分行主打盘截至申请月近一年度市占率分析
        //合计
        function Sum()
        {
            var txtGzspsNum="",txtRichNum="",txtEveryNum="",txtYuFengNum="",txtOtherNum="",txtFreeNum="";
            var GzspsNumSum=0,RichNumSum=0,EveryNumSum=0,YuFengNumSum=0,OtherNumSum=0,FreeNumSum=0;
            var total = 0;              //横向合计
            $(".tb5tr").each(function(){
                //alert("进来");
                //横向合计
                total = 0;
                var txtid = $(this).attr("id");
                rowno = txtid.replace("trDetail5","");      //获取行号
                txtGzspsNum = $(this).find("#txtGzspsNum" + rowno).val().replace("%","");    //中原宗数
                txtRichNum = $(this).find("#txtRichNum" + rowno).val().replace("%","");      //合富宗数
                txtEveryNum = $(this).find("#txtEveryNum" + rowno).val().replace("%","");    //满堂红宗数
                txtYuFengNum = $(this).find("#txtYuFengNum" + rowno).val().replace("%","");  //裕丰宗数
                txtOtherNum = $(this).find("#txtOtherNum" + rowno).val().replace("%","");    //小中介宗数
                txtFreeNum = $(this).find("#txtFreeNum" + rowno).val().replace("%","");      //自行交易宗数

                txtGzspsNum = $.trim(txtGzspsNum)==""?"0":txtGzspsNum;
                txtRichNum = $.trim(txtRichNum) == "" ? "0":txtRichNum;
                txtEveryNum = $.trim(txtEveryNum)=="" ? "0" : txtEveryNum;
                txtYuFengNum = $.trim(txtYuFengNum)==""?"0":txtYuFengNum;
                txtOtherNum = $.trim(txtOtherNum) == "" ? "0" :txtOtherNum;
                txtFreeNum = $.trim(txtFreeNum) == "" ? "0" : txtFreeNum;

                total = parseInt(txtGzspsNum) + parseInt(txtRichNum) + parseInt(txtEveryNum) + parseInt(txtYuFengNum) + parseInt(txtOtherNum) + parseInt(txtFreeNum);
                

                if(total > 0)
                {
                    $(this).find("#txtAllSum" + rowno).val(total);
                    //横向占比计算
                    var Rate = parseFloat(txtGzspsNum) / total * 100;
                    $(this).find("#txtGzspsRate" + rowno).val(Rate.toFixed(1));

                    Rate = parseFloat(txtRichNum) / total * 100;
                    $(this).find("#txtRichRate" + rowno).val(Rate.toFixed(1));

                    Rate = parseFloat(txtEveryNum) / total * 100;
                    $(this).find("#txtEveryRate" + rowno).val(Rate.toFixed(1));

                    Rate = parseFloat(txtYuFengNum) / total * 100;
                    $(this).find("#txtYuFengRate" + rowno).val(Rate.toFixed(1));

                    Rate = parseFloat(txtOtherNum) / total * 100;
                    $(this).find("#txtOtherRate" + rowno).val(Rate.toFixed(1));

                    Rate = parseFloat(txtFreeNum) / total * 100;
                    $(this).find("#txtFreeRate" + rowno).val(Rate.toFixed(1));
                }
                else
                {
                    $(this).find("#txtAllSum" + rowno).val("");
                    $(this).find("#txtGzspsRate" + rowno).val("");
                    $(this).find("#txtRichRate" + rowno).val("");
                    $(this).find("#txtEveryRate" + rowno).val("");
                    $(this).find("#txtYuFengRate" + rowno).val("");
                    $(this).find("#txtOtherRate" + rowno).val("");
                    $(this).find("#txtFreeRate" + rowno).val("");
                }
                //合计行总和 
                GzspsNumSum += parseInt(txtGzspsNum);
                RichNumSum += parseInt(txtRichNum);
                EveryNumSum += parseInt(txtEveryNum);
                YuFengNumSum += parseInt(txtYuFengNum);
                OtherNumSum += parseInt(txtOtherNum);
                FreeNumSum += parseInt(txtFreeNum);
            });
            total = 0;
            total = GzspsNumSum + RichNumSum + EveryNumSum + YuFengNumSum + OtherNumSum + FreeNumSum;
            if(total>0)
            {
                $("#txtGzspsNumSum").val(GzspsNumSum);
                var TRate = parseFloat(GzspsNumSum) / total * 100;
                $("#txtGzspsRateSum").val(TRate.toFixed(1));

                $("#txtRichNumSum").val(RichNumSum);
                TRate = parseFloat(RichNumSum) / total * 100;
                $("#txtRichRateSum").val(TRate.toFixed(1));

                $("#txtEveryNumSum").val(EveryNumSum);
                TRate = parseFloat(EveryNumSum) / total * 100;
                $("#txtEveryRateSum").val(TRate.toFixed(1));

                $("#txtYuFengNumSum").val(YuFengNumSum);
                TRate = parseFloat(YuFengNumSum) / total * 100;
                $("#txtYuFengRateSum").val(TRate.toFixed(1));

                $("#txtOtherNumSum").val(OtherNumSum);
                TRate = parseFloat(OtherNumSum) / total * 100;
                $("#txtOtherRateSum").val(TRate.toFixed(1));

                $("#txtFreeNumSum").val(FreeNumSum);
                TRate = parseFloat(FreeNumSum) / total * 100;
                $("#txtFreeRateSum").val(TRate.toFixed(1));

                $("#txtAllSumSum").val(total);
            }
            else
            {
                $("#txtGzspsNumSum").val("");
                $("#txtRichNumSum").val("");
                $("#txtEveryNumSum").val("");
                $("#txtYuFengNumSum").val("");
                $("#txtOtherNumSum").val("");
                $("#txtOtherNumSum").val("");
                $("#txtFreeNumSum").val("");

                $("#txtGzspsRateSum").val("");
                $("#txtRichRateSum").val("");
                $("#txtEveryRateSum").val("");
                $("#txtYuFengRateSum").val("");
                $("#txtOtherRateSum").val("");
                $("#txtFreeRateSum").val("");
                $("#txtAllSumSum").val("");
            }
        }

        //id=t,id=table2的table初始化
        function InitTB1(tbid, inputname, val4, val5, val6, val7, val8, val9)
        {
            var array4 = val4.split('|');
            var array5 = val5.split('|');
            var array6 = val6.split('|');
            var array7 = val7.split('|');
            var array8 = val8.split('|');
            var array9 = val9.split('|');

            var html = "";
            for(var i = 0 ; i < array4.length && i < array5.length && i < array6.length; i++ )
            {
                var tt = "<td rowspan='" + (array4.length) + "'>大战区负责人<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddRow(this,\"" + inputname + "\",\"szj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"szj\")' /></td>";
                html = html + "<tr class='szj'>"+ 
                                (i == 0 ? tt : "")
                               +"<td><input type='text' name='" +  inputname + "4' style='width:100px' value='" + array4[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "5' style='width:100px' value='" + array5[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "6' style='width:100px' value='" + array6[i] + "' /></td>"
                               +"</tr>";
                
            }
            $("#" + tbid).find(".szj").last().after(html);

            html = "";
            for(var i = 0 ; i < array7.length && i < array8.length && i < array9.length; i++ )
            {
                //var tt = "<td rowspan='" + (array7.length) + "'>区经<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddRow(this,\"" + inputname + "\",\"sqj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"sqj\")' /></td>";
                var tt = "<td rowspan='" + (array7.length) + "'>小战区负责人<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddRow(this,\"" + inputname + "\",\"sqj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"sqj\")' /></td>";
                html = html +"<tr class='sqj'>"+
                                (i == 0 ? tt : "")
                               +"<td><input type='text' name='" +  inputname + "7' style='width:100px' value='" + array7[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "8' style='width:100px' value='" + array8[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "9' style='width:100px' value='" + array9[i] + "' /></td>"
                               +"</tr>";
            }
            $("#" + tbid).find(".sqj").last().after(html);

            //所有数组数量都不等于0
            if(array4.length > 0 && array5.length > 0 && array6.length > 0)
            {
                //清除默认第一组空行
                $("#" + tbid).find(".szj").first().remove();
            }

            if(array7.length > 0 && array8.length > 0 && array9.length > 0)
            {
                //清除默认第一组空行
                $("#" + tbid).find(".sqj").first().remove();
            }
        }
        //id=table3,id=table4的table初始化
        function InitTB2(tbid, inputname, val7, val8, val9, val10, val11, val12, val13, val14, val15, val16, val17, val18)
        {
            var array7 = val7.split('|');
            var array8 = val8.split('|');
            var array9 = val9.split('|');
            var array10 = val10.split('|');
            var array11 = val11.split('|');
            var array12 = val12.split('|');
            var array13 = val13.split('|');
            var array14 = val14.split('|');
            var array15 = val15.split('|');
            var array16 = val16.split('|');
            var array17 = val17.split('|');
            var array18 = val18.split('|');

            var html = "";
            for(var i = 0 ; i <array7.length && i<array8.length && i < array9.length && i < array10.length && i < array11.length && i < array12.length; i++ )
            {
                var tt = "<td rowspan='" + (array7.length) + "'>大战区负责人<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddRow2(this,\"" + inputname + "\",\"szj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"szj\")' /></td>";
                html = html + "<tr class='szj'>"+
                               (i == 0 ? tt : "")
                               +"<td><input name='" + inputname + "7' style='width:60px' value='" + array7[i] + "' /></td>"
                               +"<td><input name='" + inputname + "8' style='width:60px' value='" + array8[i] + "' /></td>"
                               +"<td><input name='" + inputname + "9' style='width:60px' value='" + array9[i] + "' /></td>"
                               +"<td><input name='" + inputname + "10' style='width:60px' value='" + array10[i] + "' /></td>"
                               +"<td><input name='" + inputname + "11' style='width:60px' value='" + array11[i] + "' /></td>"
                               +"<td><input name='" + inputname + "12' style='width:60px' value='" + array12[i] + "' /></td>"
                               +"</tr>";
            }
            $("#" + tbid).find(".szj").last().after(html);

            html = "";
            for(var i = 0 ; i < array13.length && i < array14.length && i < array15.length && i < array16.length && i < array17.length && i < array18.length; i++)
            {
                //var tt = "<td rowspan='" + (array13.length) + "'>区经<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddRow2(this,\"" + inputname + "\",\"sqj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"sqj\")' /></td>";
                var tt = "<td rowspan='" + (array13.length) + "'>小战区负责人<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddRow2(this,\"" + inputname + "\",\"sqj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"sqj\")' /></td>";
                html = html +"<tr class='sqj'>"+
                               (i == 0 ? tt : "")
                               +"<td><input name='" + inputname + "13' style='width:60px' value='" + array13[i] + "' /></td>"
                               +"<td><input name='" + inputname + "14' style='width:60px' value='" + array14[i] + "' /></td>"
                               +"<td><input name='" + inputname + "15' style='width:60px' value='" + array15[i] + "' /></td>"
                               +"<td><input name='" + inputname + "16' style='width:60px' value='" + array16[i] + "' /></td>"
                               +"<td><input name='" + inputname + "17' style='width:60px' value='" + array17[i] + "' /></td>"
                               +"<td><input name='" + inputname + "18' style='width:60px' value='" + array18[i] + "' /></td>"
                               +"</tr>";
            }
            $("#" + tbid).find(".sqj").last().after(html);

            //所有数组数量都不等于0
            if(array7.length > 0 && array8.length > 0 && array9.length > 0 && array10.length > 0 && array11.length > 0 && array12.length > 0)
            {
                //清除默认第一组空行
                $("#" + tbid).find(".szj").first().remove();
            }
            if(array13.length > 0 && array14.length > 0 && array15.length > 0 && array16.length > 0 && array17.length > 0 && array18.length > 0)
            {
                //清除默认第一组空行
                $("#" + tbid).find(".sqj").first().remove();
            }


            //$("#" + tbid).find(".btntr").before(html1);
        }
        //id=tbAgentRule初始化
        function InitTB3(tbid, inputname, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15)
        {
            var array6 = val6.split('|');
            var array7 = val7.split('|');
            var array8 = val8.split('|');
            var array9 = val9.split('|');
            var array10 = val10.split('|');
            var array11 = val11.split('|');
            var array12 = val12.split('|');
            var array13 = val13.split('|');
            var array14 = val14.split('|');
            var array15 = val15.split('|');

            var html = "";
            for(var i = 0 ; i <array6.length && i<array7.length && i < array8.length && i < array9.length && i < array10.length; i++ )
            {
                var tt = "<td rowspan='" + (array6.length) + "'>大战区负责人<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddtbAgentRuleRow(this,\"" + inputname + "\",\"szj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"szj\")' /></td>";
                html = html + "<tr class='szj'>"+
                               (i == 0 ? tt : "")
                               +"<td><input type='text' name='" +  inputname + "6' style='width:60px' value='" + array6[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "7' style='width:60px' value='" + array7[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "8' style='width:60px' value='" + array8[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "9' style='width:60px' value='" + array9[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "10' style='width:60px' value='" + array10[i] + "' /></td>"
                               +"</tr>";
            }
            $("#" + tbid).find(".szj").last().after(html);

            html = "";
            for(var i = 0 ;i < array11.length && i < array12.length && i < array13.length && i < array14.length && i < array15.length; i++ )
            {
                //var tt = "<td rowspan='" + (array11.length) + "'>区经<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddtbAgentRuleRow(this,\"" + inputname + "\",\"sqj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"sqj\")' /></td>";
                var tt = "<td rowspan='" + (array11.length) + "'>小战区负责人<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddtbAgentRuleRow(this,\"" + inputname + "\",\"sqj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"sqj\")' /></td>";
                html = html +"<tr class='sqj'>"+
                               (i == 0 ? tt : "")
                               +"<td><input type='text' name='" +  inputname + "11' style='width:60px' value='" + array11[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "12' style='width:60px' value='" + array12[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "13' style='width:60px' value='" + array13[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "14' style='width:60px' value='" + array14[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "15' style='width:60px' value='" + array15[i] + "' /></td>"
                               +"</tr>";
            }
            $("#" + tbid).find(".sqj").last().after(html);

            //所有数组数量都不等于0
            if(array6.length > 0 && array7.length > 0 && array8.length > 0 && array9.length > 0 && array10.length > 0)
            {
                //清除默认第一组空行
                $("#" + tbid).find(".szj").first().remove();
            }
            if(array11.length > 0 && array12.length > 0 && array13.length > 0 && array14.length > 0 && array15.length > 0)
            {
                //清除默认第一组空行
                $("#" + tbid).find(".sqj").first().remove();
            }
        }

        //id=Table5初始化
        function InitTB4(tbid, inputname, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15)
        {
            var array6 = val6.split('|');
            var array7 = val7.split('|');
            var array8 = val8.split('|');
            var array9 = val9.split('|');
            var array10 = val10.split('|');
            var array11 = val11.split('|');
            var array12 = val12.split('|');
            var array13 = val13.split('|');
            var array14 = val14.split('|');
            var array15 = val15.split('|');

            var html = "";
            for(var i = 0 ; i <array6.length && i<array7.length && i < array8.length && i < array9.length && i < array10.length; i++ )
            {
                var tt = "<td rowspan='" + (array6.length) + "'>大战区负责人<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddTable5Row(this,\"" + inputname + "\",\"szj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"szj\")' /></td>";
                html = html + "<tr class='szj'>"+
                               (i == 0 ? tt : "")
                               +"<td><input type='text' name='" +  inputname + "6' style='width:60px' value='" + array6[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "7' style='width:60px' value='" + array7[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "8' style='width:60px' value='" + array8[i] + "' />%</td>"
                               +"<td><input type='text' name='" +  inputname + "9' style='width:60px' value='" + array9[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "10' style='width:60px' value='" + array10[i] + "' />%</td>"
                               +"</tr>";
                
            }
            $("#" + tbid).find(".szj").last().after(html);

            html = "";
            for(var i = 0 ; i < array11.length && i < array12.length && i < array13.length && i < array14.length && i < array15.length; i++)
            {
                //var tt = "<td rowspan='" + (array11.length) + "'>区经<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddTable5Row(this,\"" + inputname + "\",\"sqj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"sqj\")' /></td>";
                var tt = "<td rowspan='" + (array11.length) + "'>小战区负责人<br/><input type='button' class='btnaddRow' value='添加新行' onclick='AddTable5Row(this,\"" + inputname + "\",\"sqj\")' /><br /><input type='button' class='btnaddRow' value='删除一行' onclick='DelRow(this,\"sqj\")' /></td>";
                html = html +"<tr class='sqj'>"+
                               (i == 0 ? tt : "")
                               +"<td><input type='text' name='" +  inputname + "11' style='width:60px' value='" + array11[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "12' style='width:60px' value='" + array12[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "13' style='width:60px' value='" + array13[i] + "' />%</td>"
                               +"<td><input type='text' name='" +  inputname + "14' style='width:60px' value='" + array14[i] + "' /></td>"
                               +"<td><input type='text' name='" +  inputname + "15' style='width:60px' value='" + array15[i] + "' />%</td>"
                               +"</tr>";
            }
            $("#" + tbid).find(".sqj").last().after(html);

            //所有数组数量都不等于0
            if(array6.length > 0 && array7.length > 0 && array8.length > 0 && array9.length > 0 && array10.length > 0)
            {
                //清除默认第一组空行
                $("#" + tbid).find(".szj").first().remove();
            }
            if(array11.length > 0 && array12.length > 0 && array13.length > 0 && array14.length > 0 && array15.length > 0)
            {
                $("#" + tbid).find(".sqj").first().remove();
            }
        }

        //初始化页面
        function PageInit()
        {
            //t初始化
            var val4,val5,val6,val7,val8,val9;
            val4 = $("#<%=this.hidLastYearSituation4.ClientID%>").val();
            val5 = $("#<%=this.hidLastYearSituation5.ClientID%>").val();
            val6 = $("#<%=this.hidLastYearSituation6.ClientID%>").val();
            val7 = $("#<%=this.hidLastYearSituation7.ClientID%>").val();
            val8 = $("#<%=this.hidLastYearSituation8.ClientID%>").val();
            val9 = $("#<%=this.hidLastYearSituation9.ClientID%>").val();
            InitTB1("t", "txtLastYearSituation", val4, val5, val6, val7, val8, val9);

            //table2初始化
            val4 = $("#<%=this.hidThisYearSituation4.ClientID%>").val();
            val5 = $("#<%=this.hidThisYearSituation5.ClientID%>").val();
            val6 = $("#<%=this.hidThisYearSituation6.ClientID%>").val();
            val7 = $("#<%=this.hidThisYearSituation7.ClientID%>").val();
            val8 = $("#<%=this.hidThisYearSituation8.ClientID%>").val();
            val9 = $("#<%=this.hidThisYearSituation9.ClientID%>").val();
            InitTB1("Table2", "txtThisYearSituation", val4, val5, val6, val7, val8, val9);

            //table3初始化
            var val10, val11, val12, val13, val14, val15, val16, val17, val18;
            val7 = $("#<%=this.hidBusinessSituation7.ClientID%>").val();
            val8 = $("#<%=this.hidBusinessSituation8.ClientID%>").val();
            val9 = $("#<%=this.hidBusinessSituation9.ClientID%>").val();
            val10 = $("#<%=this.hidBusinessSituation10.ClientID%>").val();
            val11 = $("#<%=this.hidBusinessSituation11.ClientID%>").val();
            val12 = $("#<%=this.hidBusinessSituation12.ClientID%>").val();
            val13 = $("#<%=this.hidBusinessSituation13.ClientID%>").val();
            val14 = $("#<%=this.hidBusinessSituation14.ClientID%>").val();
            val15 = $("#<%=this.hidBusinessSituation15.ClientID%>").val();
            val16 = $("#<%=this.hidBusinessSituation16.ClientID%>").val();
            val17 = $("#<%=this.hidBusinessSituation17.ClientID%>").val();
            val18 = $("#<%=this.hidBusinessSituation18.ClientID%>").val();
            InitTB2("Table3","txtBusinessSituation",val7,val8,val9,val10,val11,val12,val13,val14,val15,val16,val17,val18);

            //table4初始化
            val7 = $("#<%=this.hidProfitSituation7.ClientID%>").val();
            val8 = $("#<%=this.hidProfitSituation8.ClientID%>").val();
            val9 = $("#<%=this.hidProfitSituation9.ClientID%>").val();
            val10 = $("#<%=this.hidProfitSituation10.ClientID%>").val();
            val11 = $("#<%=this.hidProfitSituation11.ClientID%>").val();
            val12 = $("#<%=this.hidProfitSituation12.ClientID%>").val();
            val13 = $("#<%=this.hidProfitSituation13.ClientID%>").val();
            val14 = $("#<%=this.hidProfitSituation14.ClientID%>").val();
            val15 = $("#<%=this.hidProfitSituation15.ClientID%>").val();
            val16 = $("#<%=this.hidProfitSituation16.ClientID%>").val();
            val17 = $("#<%=this.hidProfitSituation17.ClientID%>").val();
            val18 = $("#<%=this.hidProfitSituation18.ClientID%>").val();
            InitTB2("Table4","txtProfitSituation",val7,val8,val9,val10,val11,val12,val13,val14,val15,val16,val17,val18);

            //tbAgentRule初始化
            val6 = $("#<%=this.hidAccumulationSituation6.ClientID%>").val();
            val7 = $("#<%=this.hidAccumulationSituation7.ClientID%>").val();
            val8 = $("#<%=this.hidAccumulationSituation8.ClientID%>").val();
            val9 = $("#<%=this.hidAccumulationSituation9.ClientID%>").val();
            val10 = $("#<%=this.hidAccumulationSituation10.ClientID%>").val();
            val11 = $("#<%=this.hidAccumulationSituation11.ClientID%>").val();
            val12 = $("#<%=this.hidAccumulationSituation12.ClientID%>").val();
            val13 = $("#<%=this.hidAccumulationSituation13.ClientID%>").val();
            val14 = $("#<%=this.hidAccumulationSituation14.ClientID%>").val();
            val15 = $("#<%=this.hidAccumulationSituation15.ClientID%>").val();
            InitTB3("tbAgentRule","txtAccumulationSituation",val6,val7,val8,val9,val10,val11,val12,val13,val14,val15);

            
        }
    </script>
    <style type="text/css">
        .auto-style1{width:25px;}
        .auto-style2{width:110px;}
        .auto-style4{width:250px;}
        .auto-style5{width:80px;}
        .auto-style6{width:190px;}
        .auto-style7{width:105px;}
        .auto-style8{width:85px;}
        .auto-style9{width:70px;}
        .btnaddRow{display:none;}
        .pinput{width:70px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <%=SbFlow.ToString() %>
        <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        <div id="tabs" style="text-align: center; width: 840px">
            <ul id="ulTabs" style="margin-left: 60px">
                <li id="liTabs1" style="border: none;">
                    <a id="Feasibility_m" href="#tabs-1" style="background-image: url('/Images/feasibility_m2.png'); border: none; width: 202px; height: 17px;"></a>
                </li>
                <li id="liTabs2" style="border: none;">
                    <a id="Feasibility_b" href="#tabs-2" style="background-image: url('/Images/feasibility_b1.png'); border: none; width: 154px; height: 17px;"></a>
                </li>
                <li id="liTabs3" style="border: none;">
                    <a id="Feasibility_c" href="#tabs-3" style="background-image: url('/Images/feasibility_c1.png'); border: none; width: 110px; height: 17px;"></a>
                </li>
                <li id="liTabs4" style="border: none;">
                    <a id="Feasibility_j" href="#tabs-4" style="background-image: url('/Images/feasibility_j1.png'); border: none; width: 59px; height: 17px;"></a>
                </li>
                <li id="liTabs5" style="border: none;">
                    <a id="Feasibility_d" href="#tabs-5" style="background-image: url('/Images/feasibility_d1.png'); border: none; width: 59px; height: 17px;"></a>
                </li>
            </ul>

            <div id="tabs-1">
                <!--打印正文开始-->
                <div style='text-align: center'>
                    <h1>广东中原地产代理有限公司</h1>
                    <%--<h1>新建呼叫中心可行性报告</h1>--%>
                    <span style="font-size:20px; font-weight:bold">新建呼叫中心可行性报告</span><label id="laIsGroups" runat="server" style="color:red; font-size:15px;"></label>
                    <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
                    <div id="snum" style="width: 700px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
                    <table id="tbAround" width='700px'>
                        <tr>
                            <td class="auto-style4">分行名称</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtBranch" runat="server"></asp:TextBox></td>
                            <td class="auto-style7">开铺性质</td>
                            <td class="tl PL10">
                                <asp:RadioButton ID="rdbOpenType1" runat="server" GroupName="OpenType" Text="新开铺" /><asp:RadioButton ID="rdbOpenType2" runat="server" GroupName="OpenType" Text="转铺" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">所属区域</td>
                            <td class="tl PL10">
                                <asp:DropDownList ID="ddlDepartmentType" runat="server">
                                    <asp:ListItem Value="请选择区域">请选择区域</asp:ListItem>
                                    <asp:ListItem Value="海珠区及番禺区">海珠区及番禺区</asp:ListItem>
                                    <asp:ListItem Value="天河区">天河区</asp:ListItem>
                                    <asp:ListItem Value="白云区">白云区</asp:ListItem>
                                    <asp:ListItem Value="越秀区">越秀区</asp:ListItem>
                                    <asp:ListItem Value="芳村南海战区">芳村南海战区</asp:ListItem>
                                    <asp:ListItem Value="老荔湾战区">老荔湾战区</asp:ListItem>
                                    <asp:ListItem Value="番禺区">番禺区</asp:ListItem>
                                    <asp:ListItem Value="花都区">花都区</asp:ListItem>
                                    <asp:ListItem Value="工商铺">工商铺</asp:ListItem>
                                    <asp:ListItem Value="其他区">其他区</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="auto-style7">所属负责人</td>
                            <td class="tl PL10">
                                <asp:DropDownList ID="ddlMajordomo" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">所属大战区负责人</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtApplyID" runat="server"></asp:TextBox></td>
                            <td class="auto-style7">隶属小战区负责人</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtAreaManager" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">新分行联络人</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtContacter" runat="server"></asp:TextBox></td>
                            <td class="auto-style7">联系电话</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtContactPhone" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">发文部门</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
                            <td class="auto-style7">转铺分行</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtTurnBranch" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">填写人</td>
                            <td class="tl PL10">
                                <asp:Label ID="lblApply" runat="server"></asp:Label></td>
                            <td class="auto-style7">发文日期</td>
                            <td class="tl PL10">
                                <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left; padding-left: 10px; line-height: 20px;">
                                <div style="font-weight: bold; line-height: 46px; background-image: url('../../Images/th_there.png');">一、区域和片区经营状况：</div>
                                <span style="font-weight: normal">（一）区域发展规模<br />
                                    截止申请月区域分行数量，包括：运作中分行<asp:TextBox ID="txtWorkingDepartmentNum" runat="server" Width="35px"></asp:TextBox>间；筹建中分行(已批可行的)<asp:TextBox ID="txtPrebuildDepartmentNum" runat="server" Width="35px"></asp:TextBox>间。</span>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4" class="tl PL10">
                                <div class="tc" style="text-align: left; padding-top: 5px; padding-bottom: 5px;">（二）区域及片区的业绩、利润情况（请用<span style="font-weight: bold; text-decoration: underline;">管理帐</span>数据）</div>
                                <span>1．上年度（<asp:Label ID="lblLastYear" runat="server" Text=""></asp:Label>
                                    年）的区域负责人、大战区负责人、小战区负责人的累计业绩、利润数据</span>
                                <table id="t" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td></td>
                                        <td><span style="font-weight: bold;">业绩</span></td>
                                        <td><span style="font-weight: bold;">税前利润</span></td>
                                        <td><span style="font-weight: bold;">税前利润率</span></td>
                                    </tr>
                                    <tr>
                                        <td>区域负责人</td>
                                        <td>
                                            <asp:TextBox ID="txtLastYearSituation1" runat="server" Width="100"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtLastYearSituation2" runat="server" Width="100"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtLastYearSituation3" runat="server" Width="100"></asp:TextBox></td>
                                    </tr>
                                    <tr class="szj">
                                        <td>大战区负责人<br />
                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddRow(this,'txtLastYearSituation','szj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'szj')" />
                                        </td>
                                        <td>
                                            <input type="text" name="txtLastYearSituation4" style="width: 100px" /></td>
                                        <td>
                                            <input type="text" name="txtLastYearSituation5" style="width: 100px" /></td>
                                        <td>
                                            <input type="text" name="txtLastYearSituation6" style="width: 100px" /></td>
                                    </tr>

                                    <tr class="sqj">
                                        <td>区经<br />
                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddRow(this,'txtLastYearSituation','sqj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'sqj')" />
                                        </td>
                                        <td>
                                            <input type="text" name="txtLastYearSituation7" style="width: 100px" /></td>
                                        <td>
                                            <input type="text" name="txtLastYearSituation8" style="width: 100px" /></td>
                                        <td>
                                            <input type="text" name="txtLastYearSituation9" style="width: 100px" /></td>
                                    </tr>

                                </table>
                                <asp:HiddenField ID="hidLastYearSituation4" runat="server" />
                                <asp:HiddenField ID="hidLastYearSituation5" runat="server" />
                                <asp:HiddenField ID="hidLastYearSituation6" runat="server" />
                                <asp:HiddenField ID="hidLastYearSituation7" runat="server" />
                                <asp:HiddenField ID="hidLastYearSituation8" runat="server" />
                                <asp:HiddenField ID="hidLastYearSituation9" runat="server" />

                                <span>2．申请年度（<asp:Label ID="lblThisYear" runat="server" Text=""></asp:Label>年）截止到<asp:TextBox ID="txtThisYearMonth" runat="server" Width="30"></asp:TextBox>
                                    月的区域负责人、大战区负责人、小战区负责人的累计业绩、利润数据</span>
                                <table id="Table2" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td></td>
                                        <td><span style="font-weight: bold;">业绩</span></td>
                                        <td><span style="font-weight: bold;">税前利润</span></td>
                                        <td><span style="font-weight: bold;">税前利润率</span></td>
                                    </tr>
                                    <tr>
                                        <td>区域负责人</td>
                                        <td>
                                            <asp:TextBox ID="txtThisYearSituation1" runat="server" Width="100"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtThisYearSituation2" runat="server" Width="100"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtThisYearSituation3" runat="server" Width="100"></asp:TextBox></td>
                                    </tr>
                                    <tr class="szj">
                                        <td>大战区负责人<br />
                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddRow(this,'txtThisYearSituation','szj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'szj')" />
                                        </td>
                                        <td>
                                            <input type="text" name="txtThisYearSituation4" style="width: 100px" /></td>
                                        <td>
                                            <input type="text" name="txtThisYearSituation5" style="width: 100px" /></td>
                                        <td>
                                            <input type="text" name="txtThisYearSituation6" style="width: 100px" /></td>
                                    </tr>
                                    <tr class="sqj">
                                        <td>小战区负责人<br />
                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddRow(this,'txtThisYearSituation','sqj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'sqj')" />
                                        </td>
                                        <td>
                                            <input type="text" name="txtThisYearSituation7" style="width: 100px" /></td>
                                        <td>
                                            <input type="text" name="txtThisYearSituation8" style="width: 100px" /></td>
                                        <td>
                                            <input type="text" name="txtThisYearSituation9" style="width: 100px" /></td>
                                    </tr>

                                </table>
                                <asp:HiddenField ID="hidThisYearSituation4" runat="server" />
                                <asp:HiddenField ID="hidThisYearSituation5" runat="server" />
                                <asp:HiddenField ID="hidThisYearSituation6" runat="server" />
                                <asp:HiddenField ID="hidThisYearSituation7" runat="server" />
                                <asp:HiddenField ID="hidThisYearSituation8" runat="server" />
                                <asp:HiddenField ID="hidThisYearSituation9" runat="server" />
                                <br />
                                <div class="tc" style="text-align: left; padding-left: 10px; padding-bottom: 5px;"><span>（三）管辖下分行经营情况</span></div>
                                <table id="Table3" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td rowspan="2"></td>
                                        <td colspan="3">营运半年或以上</td>
                                        <td colspan="3">营运不足半年</td>
                                    </tr>
                                    <tr>
                                        <td>分行数量</td>
                                        <td>盈利分行数量</td>
                                        <td>亏损分行数量</td>
                                        <td>分行数量</td>
                                        <td>盈利分行数量</td>
                                        <td>亏损分行数量</td>
                                    </tr>
                                    <tr>
                                        <td>区域负责人</td>
                                        <td>
                                            <asp:TextBox ID="txtBusinessSituation1" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBusinessSituation2" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBusinessSituation3" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBusinessSituation4" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBusinessSituation5" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBusinessSituation6" runat="server" Width="60px"></asp:TextBox></td>
                                    </tr>
                                    <tr class="szj">
                                        <td>大战区负责人<br />

                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddRow2(this,'txtBusinessSituation','szj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'szj')" />
                                        </td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation7" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation8" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation9" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation10" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation11" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation12" /></td>
                                    </tr>
                                    <tr class="sqj">
                                        <td>小战区负责人<br />
                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddRow2(this,'txtBusinessSituation','sqj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'sqj')" />
                                        </td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation13" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation14" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation15" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation16" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation17" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtBusinessSituation18" /></td>
                                    </tr>

                                </table>
                                <asp:HiddenField ID="hidBusinessSituation7" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation8" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation9" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation10" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation11" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation12" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation13" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation14" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation15" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation16" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation17" runat="server" />
                                <asp:HiddenField ID="hidBusinessSituation18" runat="server" />
                                <br />
                                <div class="tc" style="text-align: left; padding-left: 10px; padding-bottom: 5px;"><span>（四）管辖下组别盈利情况</span></div>
                                <table id="Table4" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td rowspan="2"></td>
                                        <td colspan="3">营运半年或以上</td>
                                        <td colspan="3">营运不足半年</td>
                                    </tr>
                                    <tr>
                                        <td>组别数量</td>
                                        <td>盈利组别数量</td>
                                        <td>亏损组别数量</td>
                                        <td>组别数量</td>
                                        <td>盈利组别数量</td>
                                        <td>亏损组别数量</td>
                                    </tr>
                                    <tr>
                                        <td>区域负责人</td>
                                        <td>
                                            <asp:TextBox ID="txtProfitSituation1" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtProfitSituation2" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtProfitSituation3" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtProfitSituation4" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtProfitSituation5" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtProfitSituation6" runat="server" Width="60px"></asp:TextBox></td>
                                    </tr>
                                    <tr class="szj">
                                        <td>大战区负责人<br />

                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddRow2(this,'txtProfitSituation','szj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'szj')" />
                                        </td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation7" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation8" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation9" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation10" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation11" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation12" /></td>
                                    </tr>
                                    <tr class="sqj">
                                        <td>小战区负责人<br />

                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddRow2(this,'txtProfitSituation','sqj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'sqj')" />
                                        </td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation13" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation14" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation15" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation16" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation17" /></td>
                                        <td>
                                            <input type="text" style="width: 60px" name="txtProfitSituation18" /></td>
                                    </tr>

                                </table>
                                <asp:HiddenField ID="hidProfitSituation7" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation8" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation9" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation10" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation11" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation12" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation13" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation14" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation15" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation16" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation17" runat="server" />
                                <asp:HiddenField ID="hidProfitSituation18" runat="server" />
                            </td>
                        </tr>

                    </table>
                </div>
            </div>



            <div id="tabs-2">
                <div style='text-align: center'>
                    <table id="tbAround3" width='700px'>
                        <tr>
                            <th colspan="4" style="line-height: 25px; text-align: left; padding-left: 10px;">二、区域和片区人力资源状况</th>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div class="tc" style="text-align: left; padding-left: 10px; padding-bottom: 5px;">（一）区域及片区人员积累情况</div>
                                <table id="tbAgentRule" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td></td>
                                        <td>辖下总组数</td>
                                        <td>辖下总人数</td>
                                        <td>销售量辖下高经人数</td>
                                        <td>辖下4-5级主管人数</td>
                                        <td>辖下1-3级营业员人数</td>
                                    </tr>
                                    <tr>
                                        <td>区域负责人</td>
                                        <td>
                                            <asp:TextBox ID="txtAccumulationSituation1" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtAccumulationSituation2" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtAccumulationSituation3" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtAccumulationSituation4" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtAccumulationSituation5" runat="server" Width="60px"></asp:TextBox></td>
                                    </tr>
                                    <tr class="szj">
                                        <td>大战区负责人<br />

                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddtbAgentRuleRow(this,'txtAccumulationSituation','szj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'szj')" />
                                        </td>
                                        <td>
                                            <input name="txtAccumulationSituation6" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtAccumulationSituation7" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtAccumulationSituation8" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtAccumulationSituation9" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtAccumulationSituation10" style="width: 60px" /></td>
                                    </tr>
                                    <tr class="sqj">
                                        <td>小战区负责人<br />

                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddtbAgentRuleRow(this,'txtAccumulationSituation','sqj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'sqj')" />
                                        </td>
                                        <td>
                                            <input name="txtAccumulationSituation11" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtAccumulationSituation12" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtAccumulationSituation13" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtAccumulationSituation14" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtAccumulationSituation15" style="width: 60px" /></td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hidAccumulationSituation6" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation7" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation8" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation9" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation10" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation11" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation12" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation13" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation14" runat="server" />
                                <asp:HiddenField ID="hidAccumulationSituation15" runat="server" />
                                <br />
                                <%--<div class="tc" style="text-align: left; padding-left: 10px; padding-bottom: 5px;">（二）最近一季（<asp:TextBox ID="txtRecentlyYear" runat="server" Width="30"></asp:TextBox>年第<asp:TextBox ID="txtRecentlySeason" runat="server" Width="30"></asp:TextBox>季）区域及片区人员达标情况</div>
                                <table id="Table5" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td rowspan="2"></td>
                                        <td rowspan="2">人均业绩</td>
                                        <td colspan="2">辖下4-5级主管达标情况</td>
                                        <td colspan="2">辖下1-3级营业员达标情况</td>
                                    </tr>
                                    <tr>
                                        <td>达标人数</td>
                                        <td>占比</td>
                                        <td>达标人数</td>
                                        <td>占比</td>
                                    </tr>
                                    <tr>
                                        <td>区域负责人</td>
                                        <td>
                                            <asp:TextBox ID="txtStandardSituation1" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtStandardSituation2" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtStandardSituation3" runat="server" Width="60px"></asp:TextBox>%</td>
                                        <td>
                                            <asp:TextBox ID="txtStandardSituation4" runat="server" Width="60px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtStandardSituation5" runat="server" Width="60px"></asp:TextBox>%</td>
                                    </tr>
                                    <tr class="szj">
                                        <td>总监<br />

                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddTable5Row(this,'txtStandardSituation','szj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'szj')" />
                                        </td>
                                        <td>
                                            <input name="txtStandardSituation6" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtStandardSituation7" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtStandardSituation8" style="width: 60px" />%</td>
                                        <td>
                                            <input name="txtStandardSituation9" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtStandardSituation10" style="width: 60px" />%</td>
                                    </tr>
                                    <tr class="sqj">
                                        <td>区经<br />
                                            <input type="button" class="btnaddRow" value="添加新行" onclick="AddTable5Row(this,'txtStandardSituation','sqj')" /><br />
                                            <input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this,'sqj')" />
                                        </td>
                                        <td>
                                            <input name="txtStandardSituation11" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtStandardSituation12" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtStandardSituation13" style="width: 60px" />%</td>
                                        <td>
                                            <input name="txtStandardSituation14" style="width: 60px" /></td>
                                        <td>
                                            <input name="txtStandardSituation15" style="width: 60px" />%</td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hidStandardSituation6" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation7" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation8" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation9" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation10" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation11" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation12" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation13" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation14" runat="server" />
                                <asp:HiddenField ID="hidStandardSituation15" runat="server" />
                                <br />
                                <div class="tc" style="text-align: left; padding-left: 10px; padding-bottom: 5px;">（三）新分行的人员安排</div>--%>
                                <div class="tc" style="text-align: left; padding-left: 10px; padding-bottom: 5px;">（二）新分行的人员安排</div>
                                <table id="tbDetail1a" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr style="display: none">
                                        <td style="width:150px;">人员架构图</td>
                                        <td colspan="2" class="tl PL10" style="padding-top: 5px">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                            <asp:Image ID="imgDiagram" runat="server" AlternateText="请选择相关的人员架构图" /><br />
                                            <asp:Button ID="btDiagram" runat="server" Text=" 删　除 " Visible="False" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:FileUpload ID="fuDiagram" runat="server" Visible="False" Width="450px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>工号</td>
                                        <td>职称</td>
                                        <td>姓名</td>
                                        <td>执业证号</td>
                                        <td>隶属上级</td>
                                    </tr>
                                    <tr>
                                        <td id="ros1a">区域负责人
                                            <input type="button" id="btnAddRow1a" value="添加新行" onclick="addRow1a(this);" style="display: none;" />
                                            <input type="button" id="btnDeleteRow1a" value="删除一行" onclick="deleteRow1a(this);" style="display: none;" />
                                        </td>
                                    </tr>
                                    <%=SbHtml1a.ToString()%>
                                    <tr id="trFlag1a"><td colspan="6"></td></tr>
                                </table>
                                <asp:HiddenField ID="HiddenField1a" runat="server" />

                                <table id="tbDetail2a" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td colspan="6"></td>
                                    </tr>
                                    <tr>
                                        <td id="ros2a">大战区负责人层级　
                                            <input type="button" id="btnAddRow2a" value="添加新行" onclick="addRow2a();" style="display: none;" />
                                            <input type="button" id="btnDeleteRow2a" value="删除一行" onclick="deleteRow2a();" style="display: none;" />
                                        </td>
                                    </tr>
                                    <%=SbHtml2a.ToString()%>
                                    <tr id="trFlag2a">
                                        <td colspan="6"></td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="HiddenField2a" runat="server" />

                                <table id="tbDetail3a" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td colspan="6"></td>
                                    </tr>
                                    <tr>
                                        <%--<td id="ros3a">区经层级--%>
                                        <td id="ros3a">小战区负责人层级　
                                            <input type="button" id="btnAddRow3a" value="添加新行" onclick="addRow3a();" style="display: none;" />
                                            <input type="button" id="btnDeleteRow3a" value="删除一行" onclick="deleteRow3a();" style="display: none;" />
                                        </td>
                                    </tr>
                                    <%=SbHtml3a.ToString()%>
                                    <tr id="trFlag3a">
                                        <td colspan="6"></td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="HiddenField3a" runat="server" />

                                <table id="tbDetail4a" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td colspan="6"></td>
                                    </tr>
                                    <tr>
                                        <%--<td id="ros4a">经理层级--%>
                                        <td id="ros4a">店董层级　
                                            <input type="button" id="btnAddRow4a" value="添加新行" onclick="addRow4a();" style="display: none;" />
                                            <input type="button" id="btnDeleteRow4a" value="删除一行" onclick="deleteRow4a();" style="display: none;" />
                                        </td>
                                    </tr>
                                    <%=SbHtml4a.ToString()%>
                                    <tr id="trFlag4a">
                                        <td colspan="6"></td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="HiddenField4a" runat="server" />

                                <table id="tbDetail5a" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td colspan="6"></td>
                                    </tr>
                                    <tr>
                                        <%--<td id="ros5a">营业员--%>
                                        <td id="ros5a">经纪人　　
                                            <input type="button" id="btnAddRow5a" value="添加新行" onclick="addRow5a();" style="display: none;" />
                                            <input type="button" id="btnDeleteRow5a" value="删除一行" onclick="deleteRow5a();" style="display: none;" />
                                        </td>
                                    </tr>
                                    <%=SbHtml5a.ToString()%>
                                    <tr id="trFlag5a">
                                        <td colspan="6">备注：在（三）新分行的人员安排栏目中，公司的在职员工可直接输入工号，系统将自动识别“职称”“姓名”“执业证号”，隶属上司需手动填写
                                        ，若为未入职员工，所有员工信息需手动输入
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="HiddenField5a" runat="server" />

                            </td>
                        </tr>
                    </table>

                </div>
            </div>




            <div id="tabs-3">
                <div style='text-align: center'>
                    <table id="tbAround4" width='700px'>
                        <tr>
                            <th colspan="2" style="line-height: 25px; line-height: 25px; text-align: left; padding-left: 10px;">三、新分行的选址情况</th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="tc" style="text-align: left; padding-left: 10px; padding-bottom: 5px;">（一）新分行的选址及铺位的相关情况</div>
                                <table id="Table11" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td class="auto-style1">1</td>
                                        <td class="auto-style2">具体地址</td>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtAddress" runat="server" Width="510px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">2</td>
                                        <td class="auto-style2">面积</td>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtSquare" runat="server" Width="510px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">3</td>
                                        <td class="auto-style2">租金情况</td>
                                        <td>
                                            <asp:TextBox ID="txtRentSituation" runat="server" Width="114px"></asp:TextBox></td>
                                        <td>按金</td>
                                        <td>
                                            <asp:TextBox ID="txtDeposit" runat="server" Width="90px"></asp:TextBox></td>
                                        <td class="auto-style8">顶手费</td>
                                        <td>
                                            <asp:TextBox ID="txtSendCoast" runat="server" Width="65px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">4</td>
                                        <td class="auto-style2">产权情况</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtPropertySituation" runat="server" Width="255px"></asp:TextBox></td>
                                        <td>分租或转租权</td>
                                        <td colspan="2">
                                            <asp:RadioButton ID="rdbRentAndTurn1" runat="server" Text="有　" />
                                            <asp:RadioButton ID="rdbRentAndTurn2" runat="server" Text="无　" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">5</td>
                                        <td class="auto-style2">电力增容情况</td>
                                        <td colspan="5">（如有）<asp:TextBox ID="txtPowerAddS" runat="server" Width="460px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">6</td>
                                        <td class="auto-style2">通讯安装情况</td>
                                        <td>电话</td>
                                        <td>
                                            <asp:TextBox ID="txtMTelephone" runat="server" Width="120px"></asp:TextBox></td>
                                        <td>光纤</td>
                                        <td colspan="2">（如有）<asp:TextBox ID="txtMOptical" runat="server" Width="95px"></asp:TextBox></td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                <div class="tc" style="text-align: left; padding-left: 10px; padding-bottom: 5px;">（二）新分行预计的业绩、成本、盈利情况</div>
                                <table id="Table1" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td class="auto-style1">1</td>
                                        <td class="auto-style6">预估每月的业绩</td>
                                        <td>
                                            <asp:TextBox ID="txtMonthlyPerformance" runat="server" Width="170px"></asp:TextBox></td>
                                        <td class="auto-style5">达到的时间</td>
                                        <td>
                                            <asp:TextBox ID="txtReachDate" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">2</td>
                                        <td class="auto-style6">预估总启投入成本</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtTotalCost" runat="server" Width="425px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">3</td>
                                        <td class="auto-style6">预估每月日常运作的成本</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtNormalCost" runat="server" Width="425px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">4</td>
                                        <td class="auto-style6">预估每月的盈利</td>
                                        <td>
                                            <asp:TextBox ID="txtMonthProfit" runat="server" Width="170px"></asp:TextBox></td>
                                        <td class="auto-style5">达到的时间</td>
                                        <td>
                                            <asp:TextBox ID="txtMonthProfitRDate" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">5</td>
                                        <td class="auto-style6">预估投资回报期限</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtReturnPeriod" runat="server" Width="425px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">6</td>
                                        <td class="auto-style6">预估分行的盈利率</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtBankOnForecast" runat="server" Width="425px"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">备注</td>
                            <td style="text-align: left; padding-left: 10px;">
                                <asp:TextBox ID="txtSummary" runat="server" Width="580px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <asp:HiddenField id="hdGroupName" runat="server"/>
                        </tr>
                    </table>
                </div>
            </div>



            <div id="tabs-5">
                <div style='text-align: center'>
                    <table id="tbAround5" width='700px'>
                        <tr>
                            <th colspan="4" style="line-height: 25px;">申请意见</th>
                        </tr>
                        <tr id="trManager1" class="noborder" style="height: 85px;">
                            <%--<td>区经</td>--%>
                            <td>小战区负责人</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                                <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx1">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trManager2" class="noborder" style="height: 85px;">
                            <td>大战区负责人</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                                <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx2">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trManager3" class="noborder" style="height: 85px;">
                            <td>区域负责人</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                                <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx3">_________</span>
                                </span>
                            </td>
                        </tr>

                        <%--<tr id="trShowFlow4" class="noborder" style="height: 85px;">
                            <td rowspan="2">财务部</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">确认</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">退回申请</label>
                                <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
                                <asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton><br />
                                <textarea id="txtIDx4" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx4">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trShowFlow5" class="noborder" style="height: 85px;">
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                                <input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
                                <textarea id="txtIDx5" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx5">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trShowFlow6" class="noborder" style="height: 85px;">
                            <td rowspan="2">人力资源部</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                                <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                                <textarea id="txtIDx6" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx6">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trShowFlow7" class="noborder" style="height: 85px;">
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label>
                                <input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
                                <textarea id="txtIDx7" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx7">_________</span>
                                </span>
                            </td>
                        </tr>--%>
                        <tr id="trShowFlow8" class="noborder" style="height: 85px;">
                            <td rowspan="2">法律部</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><br />
                                <textarea id="txtIDx8" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx8">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trShowFlow9" class="noborder" style="height: 85px;">
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label><br />
                                <textarea id="txtIDx9" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx9">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trShowFlow10" class="noborder" style="height: 85px;">
                            <td rowspan="2">外联部</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><br />
                                <textarea id="txtIDx10" style="width: 98%; overflow: auto;" rows="6"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx10">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trShowFlow11" class="noborder" style="height: 85px;">
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label><input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label><br />
                                <textarea id="txtIDx11" style="width: 98%; overflow: auto;" rows="9"></textarea><input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx11">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trShowFlow12" class="noborder" style="height: 85px;">
                            <td rowspan="2">行政部</td>
                            <td colspan="3" class="tl PL12" style="">
                                <input id="rdbYesIDx12" type="radio" name="agree12" /><label for="rdbYesIDx12">同意</label><input id="rdbNoIDx12" type="radio" name="agree12" /><label for="rdbNoIDx12">不同意</label><br />
                                <textarea id="txtIDx12" style="width: 98%; overflow: auto;" rows="6"></textarea><input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx12">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="trShowFlow13" class="noborder" style="height: 85px;">
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx13" type="radio" name="agree13" /><label for="rdbYesIDx13">同意</label><input id="rdbNoIDx13" type="radio" name="agree13" /><label for="rdbNoIDx13">不同意</label><br />
                                <textarea id="txtIDx13" style="width: 98%; overflow: auto;" rows="6"></textarea><input type="button" id="btnSignIDx13" value="签署意见" onclick="sign('13')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx13">_________</span>
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
                             <tr id="trCoo" class="noborder" style="height: 85px;">
                            <td>首席运营官</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx15" type="radio" name="agree15" /><label for="rdbYesIDx15">同意</label>
                                <input id="rdbNoIDx15" type="radio" name="agree15" /><label for="rdbNoIDx15">不同意</label>
                                <input id="rdbOtherIDx15" type="radio" name="agree15" /><label for="rdbOtherIDx15">其他意见</label><br />
                                <textarea id="txtIDx15" rows="6" style="width: 98%; overflow: auto;"></textarea>
                                <input type="button" id="btnSignIDx15" value="签署意见" onclick="sign('15')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx15">_________</span>
                                </span>
                            </td>
                        </tr>
                        <%=SbHtmlLogisticsFlow.ToString()%>
                        <%--<tr id="trShowFlow24" class="noborder" style="height: 85px;">
                            <td rowspan="4">后勤事务部<br />
                                <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                                <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx24" type="radio" name="agree24" /><label for="rdbYesIDx24">确认</label>
                                <input id="rdbNoIDx24" type="radio" name="agree24" /><label for="rdbNoIDx24">退回申请</label><br />
                                <textarea id="txtIDx24" rows="6" style="width: 98%; overflow: auto;"></textarea>
                                <input type="button" id="btnSignIDx24" value="签署意见" onclick="sign('24')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx24">_________</span>
                                </span>
                            </td>
                        </tr>--%>
                        <tr id="trLogistics2" class="noborder" style="height: 85px;">
                            <td rowspan="4">后勤事务部意见<br />
                                <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>

                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx25" type="radio" name="agree25" /><label for="rdbYesIDx25">同意</label>
                                <input id="rdbNoIDx25" type="radio" name="agree25" /><label for="rdbNoIDx25">不同意</label>
                                <input id="rdbOtherIDx25" type="radio" name="agree25" value="1" /><label for="rdbOtherIDx25">其他意见</label>
                                <a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                                <a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                                <textarea id="txtIDx25" rows="10" style="width: 98%; overflow: auto;"></textarea>
                                <input type="button" id="btnSignIDx25" value="签署意见" onclick="sign('25')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx25">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" value="1" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
                                <textarea id="txtIDx130" rows="6" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx130">_________</span>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="line-height: 0px"></td>
                            <td colspan="3" style="line-height: 0px"></td>
                        </tr>
                        <tr>
                            <td style="line-height: 0px"></td>
                            <td colspan="3" id="trtpdf" style="line-height: 0px"></td>
                        </tr>
                      
                        <tr id="trGeneralManager" class="noborder" style="height: 85px;">
                            <td>董事总经理</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx26" type="radio" name="agree26" /><label for="rdbYesIDx26">同意</label>
                                <input id="rdbNoIDx26" type="radio" name="agree26" /><label for="rdbNoIDx26">不同意</label>
                                <input id="rdbOtherIDx26" type="radio" name="agree26" /><label for="rdbOtherIDx26">其他意见</label><br />
                                <textarea id="txtIDx26" rows="6" style="width: 98%; overflow: auto;"></textarea>
                                <input type="button" id="btnSignIDx26" value="签署意见" onclick="sign('26')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx26">_________</span>
                                </span>
                            </td>
                        </tr>
                         <tr id="trGeneralGroups" class="noborder" style="height: 85px; display:none">
					        <td >集团意见</td>
					        <td colspan="3" class="tl PL10" style=" ">
						        <input id="rdbYesIDx1000" type="radio" name="agree1000" /><label for="rdbYesIDx1000">同意</label><input id="rdbNoIDx1000"  type="radio" name="agree1000" /><label for="rdbNoIDx1000">不同意</label>
                                <input id="rdbOtherIDx1000" type="radio" name="agree1000" /><label for="rdbOtherIDx1000">其他意见</label><br />
						        <textarea id="txtIDx1000" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1000" value="签署意见" onclick="sign('1000')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                                    日期：<span id="spanDateIDx1000">_________</span>
                                </span>
					        </td>
				        </tr>
                        <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
                            <td>董事总经理<br />
                                审批</td>
                            <td colspan="3" class="tl PL10" style="">
                                <input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label>
                                <input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
                                <textarea id="txtIDx131" rows="6" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx131">_________</span>
                                </span>
                            </td>
                        </tr>

                        <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
                            <td class="auto-style3">申请人回复审批意见<br />
                                （可选项）</td>
                            <td colspan="3" class="tl PL10" style="">
                                <textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                                <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx200">_________</span>
                                </span>
                            </td>
                        </tr>

                        <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
                            <td class="auto-style3">董事总经理复审</td>
                            <td colspan="3" class="tl PL10" style="">
                                <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                                <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                                <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#008162" />
                                <textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                                <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                                <br />
                                <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx220">_________</span>
                                </span>
                            </td>
                        </tr>

                        <tr style="display: none">
                            <td style="line-height: 15px; text-align: center;">中原地产华南区总裁审批意见</td>
                            <td colspan="3" class="tl PL10" style="line-height: 40px;">
                                <label>【 】同意</label>
                                <label>【 】不同意</label>
                                <div>___________________________________________________________________________________</div>
                                <div>___________________________________________________________________________________</div>
                                <div>__________________________________________________　　_________年_______月_______日</div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>


            <div id="tabs-4">
                <!--打印租赁明细表开始-->
                <div style='text-align: center'>
                    <h1>新分行租赁明细表</h1>
                    <div style="text-align: left; padding-left: 100px;">
                        新分行选址：<asp:Label ID="LbAddress" runat="server"></asp:Label><br />
                        新分行命名为：<asp:Label ID="LbName" runat="server"></asp:Label>
                    </div>
                    <table id="tbAround2" width='640px'>
                        <tr>
                            <td style="width: 80px;" rowspan="17">租赁</td>
                            <td class="auto-style2">面积</td>
                            <td class="tl PL10">建筑面积<asp:TextBox ID="txtBuildArea" runat="server" Width="40"></asp:TextBox>m²&nbsp;&nbsp;&nbsp;&nbsp;实用面积<asp:TextBox ID="txtUsableArea" runat="server" Width="40"></asp:TextBox>m²</td>
                        </tr>
                        <tr>
                            <td>月租金</td>
                            <td class="tl PL10">不含税￥<asp:TextBox ID="txtMonthlyRentNoTax" runat="server" CssClass="pinput"></asp:TextBox>元/月&nbsp;&nbsp;含税￥<asp:TextBox ID="txtMonthlyRentIncludeTax" runat="server" CssClass="pinput"></asp:TextBox>元/月&nbsp;&nbsp;税费￥<asp:TextBox ID="txtMothlyTax" runat="server" CssClass="pinput"></asp:TextBox>元
                                <br />
                                业主是否包发票<asp:RadioButton ID="rdbHasTax1" runat="server" GroupName="UndertakeInvoice" Text="包" /><asp:RadioButton ID="rdbHasTax2" runat="server" GroupName="UndertakeInvoice" Text="不包" />
                                税率<asp:TextBox ID="txtMonthlyTaxRate" runat="server" Width="60px"></asp:TextBox>%
                            </td>
                        </tr>
                        <tr>
                            <td>租赁期</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtLeaseStartDate" runat="server" Width="80"></asp:TextBox>至<asp:TextBox ID="txtLeaseEndDate" runat="server" Width="80"></asp:TextBox>（共<asp:TextBox ID="txtLeaseYears" runat="server" Width="30"></asp:TextBox>年<asp:TextBox ID="txtLeaseMonths" runat="server" Width="30"></asp:TextBox>月）</td>
                        </tr>
                        <tr>
                            <td>免租装修期</td>
                            <td class="tl PL10">
                                <asp:RadioButton ID="rdbIsRentFree1" runat="server" GroupName="RentFree" Text="无" /><asp:RadioButton ID="rdbIsRentFree2" runat="server" GroupName="RentFree" Text="有" /><asp:TextBox ID="txtRentFreeStart" runat="server" Width="80"></asp:TextBox>至<asp:TextBox ID="txtRentFreeEnd" runat="server" Width="80"></asp:TextBox>（共<asp:TextBox ID="txtRentFreeCount" runat="server" Width="40px"></asp:TextBox>天）</td>
                        </tr>

                        <tr>
                            <td>年租金递增</td>
                            <td>
                                <table id="tbDetail6" class='sample tc' width='98%' style="margin: 0 auto;">
                                    <tr>
                                        <td>第几年</td>
                                        <td>不含税￥元/月</td>
                                        <td>含税￥元/月</td>
                                        <td>税费￥元</td>
                                        <td>递增%</td>
                                        <td>税率%</td>
                                    </tr>
                                    <%=SbHtml6.ToString()%>
                                    <tr id="trFlag6">
                                        <td colspan="6"></td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="HiddenField6" runat="server" />
                                <input type="button" id="btnAddRow6" value="添加新行" onclick="addRow6();" style="float: left; margin-left: 5px; display: none;" />
                                <input type="button" id="btnDeleteRow6" value="删除一行" onclick="deleteRow6();" style="float: left; display: none;" />
                            </td>
                        </tr>
                        <tr>
                            <td>管理费</td>
                            <td class="tl PL10">￥<asp:TextBox ID="txtManageCoast" runat="server" CssClass="pinput"></asp:TextBox>元/月（含发票），即￥<asp:TextBox ID="txtManageCoast2" runat="server" CssClass="pinput"></asp:TextBox>元/m²</td>
                        </tr>
                        <tr>
                            <td rowspan="2">水、电费</td>
                            <td class="tl PL10">水费：￥<asp:TextBox ID="txtWCoast" runat="server" CssClass="pinput"></asp:TextBox>元/吨&nbsp;&nbsp;电费：￥<asp:TextBox ID="txtECoast" runat="server" CssClass="pinput"></asp:TextBox>元/度（每月按实际用量计算）</td>
                        </tr>
                        <tr>
                            <td class="tl PL10">
                                <asp:RadioButton ID="rdbInvoice1" runat="server" GroupName="Invoice" Text="发票业主提供" /><asp:RadioButton ID="rdbInvoice2" runat="server" GroupName="Invoice" Text="发票管理处提供" /></td>
                        </tr>
                        <tr>
                            <td>各项按金</td>
                            <td class="tl PL10">租赁按金：￥<asp:TextBox ID="txtRentDeposit" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;&nbsp;水、电按金：￥<asp:TextBox ID="txtWEDeposit" runat="server" CssClass="pinput"></asp:TextBox>元<br />
                                管理费按金：￥<asp:TextBox ID="txtManageDeposit" runat="server" CssClass="pinput"></asp:TextBox>元</td>
                        </tr>
                        <tr>
                            <td rowspan="6">顶手费</td>
                            <td class="tl PL10">包发票￥<asp:TextBox ID="txtPackageInvoice" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;&nbsp;&nbsp;&nbsp;不包发票￥<asp:TextBox ID="txtNPackageInvoice" runat="server" CssClass="pinput"></asp:TextBox>元</td>
                        </tr>
                        <tr>
                            <td class="tl PL10">支付原因：<br />
                                <asp:TextBox ID="txtPayReason" runat="server" TextMode="MultiLine" Rows="2" Width="98%" Style="overflow: auto;"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tl PL10">支付方式：<asp:RadioButton ID="rdbPayWay1" runat="server" GroupName="PayWay" Text="现金支付" /><asp:RadioButton ID="rdbPayWay2" runat="server" GroupName="PayWay" Text="支票支付" /><asp:RadioButton ID="rdbPayWay3" runat="server" GroupName="PayWay" Text="转账支付" /></td>
                        </tr>
                        <tr>
                            <td class="tl PL10">支付对象（附名片）：<asp:TextBox ID="txtPayObiect" runat="server" Width="80"></asp:TextBox>&nbsp;&nbsp;&nbsp;联系电话：<asp:TextBox ID="txtPOPhone" runat="server" Width="100"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tl PL10">收款人：<asp:TextBox ID="txtCollection" runat="server" Width="80"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;联系电话：<asp:TextBox ID="txtCollectionPhone" runat="server" Width="100"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tl PL10">支付对象和收款人原则上需一致，<br />
                                如不一致必须能合理解释收款人与业主/转租客的关系：<br />
                                <asp:TextBox ID="txtRelationship" runat="server" TextMode="MultiLine" Rows="2" Width="98%" Style="overflow: auto;"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>租赁印花税</td>
                            <td class="tl PL10">
                                <asp:RadioButton ID="rdbStampDuty1" runat="server" GroupName="StampDuty" Text="租赁双方各付各税" />￥<asp:TextBox ID="txtStampDuty1" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbStampDuty2" runat="server" GroupName="StampDuty" Text="我司全包" />￥<asp:TextBox ID="txtStampDuty2" runat="server" CssClass="pinput"></asp:TextBox>元</td>
                        </tr>
                        <tr>
                            <td>铺面交吉日期</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtCompleteDate" runat="server" Width="80"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td rowspan="6">费用申请</td>
                            <td>首月租金</td>
                            <td class="tl PL10">￥<asp:TextBox ID="txtFirstRent" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;<asp:RadioButton ID="rdbFirstRentC1" runat="server" GroupName="FirstRentC" Text="现金支付" /><asp:RadioButton ID="rdbFirstRentC2" runat="server" GroupName="FirstRentC" Text="转账支付" /><br />
                                支票抬头<asp:TextBox ID="txtFirstRentT" runat="server" Width="365px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>租赁按金</td>
                            <td class="tl PL10">￥<asp:TextBox ID="txtLeaseDeposit" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;<asp:RadioButton ID="rdbLeaseDepositC1" runat="server" GroupName="LeaseDepositC" Text="现金支付" /><asp:RadioButton ID="rdbLeaseDepositC2" runat="server" GroupName="LeaseDepositC" Text="转账支付" /><br />
                                支票抬头<asp:TextBox ID="txtLeaseDepositT" runat="server" Width="365px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>顶手费</td>
                            <td class="tl PL10">￥<asp:TextBox ID="txtFSendCoast" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;<asp:RadioButton ID="rdbFSendCoastC1" runat="server" GroupName="FSendCoastC" Text="现金支付" /><asp:RadioButton ID="rdbFSendCoastC2" runat="server" GroupName="FSendCoastC" Text="转账支付" /><br />
                                支票抬头<asp:TextBox ID="txtFSendCoastT" runat="server" Width="365px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>水电按金</td>
                            <td class="tl PL10">￥<asp:TextBox ID="txtFWEDeposit" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;<asp:RadioButton ID="rdbFWEDepositC1" runat="server" GroupName="FWEDepositC" Text="现金支付" /><asp:RadioButton ID="rdbFWEDepositC2" runat="server" GroupName="FWEDepositC" Text="转账支付" /><br />
                                支票抬头<asp:TextBox ID="txtFWEDepositT" runat="server" Width="365px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>管理费按金</td>
                            <td class="tl PL10">￥<asp:TextBox ID="txtFManageDeposit" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;<asp:RadioButton ID="rdbFManageDepositC1" runat="server" GroupName="FManageDepositC" Text="现金支付" /><asp:RadioButton ID="rdbFManageDepositC2" runat="server" GroupName="FManageDepositC" Text="转账支付" /><br />
                                支票抬头<asp:TextBox ID="txtFManageDepositT" runat="server" Width="365px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>首月印花税</td>
                            <td class="tl PL10">￥<asp:TextBox ID="txtFFMCoaet" runat="server" CssClass="pinput"></asp:TextBox>元&nbsp;<asp:RadioButton ID="rdbFFMCoaetC1" runat="server" GroupName="FFMCoaetC" Text="现金支付" /><asp:RadioButton ID="rdbFFMCoaetC2" runat="server" GroupName="FFMCoaetC" Text="转账支付" /><br />
                                支票抬头<asp:TextBox ID="txtFFMCoaetT" runat="server" Width="365px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="5">业权</td>
                            <td>出租人全称</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtRentName" runat="server" Width="96%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td rowspan="2">出租人身份</td>
                            <td class="tl PL10">
                                <asp:RadioButton ID="rdbRentReal1" runat="server" GroupName="RentIdentity" Text="是真正业主" />
                                业主联系资料<asp:TextBox ID="txtRentIdentity" runat="server" Width="235px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tl PL10">
                                <asp:RadioButton ID="rdbRentReal2" runat="server" GroupName="RentIdentity" Text="不是真正业主" />
                                二手转租客联系资料<asp:TextBox ID="txtRentMessage" runat="server" Width="200"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>房产性质</td>
                            <td class="tl PL10">
                                <asp:RadioButton ID="rdbEstateProperties1" runat="server" GroupName="EstateProperties" Text="商铺" /><asp:RadioButton ID="rdbEstateProperties2" runat="server" GroupName="EstateProperties" Text="住宅" /><asp:RadioButton ID="rdbEstateProperties3" runat="server" GroupName="EstateProperties" Text="写字楼" /><asp:RadioButton ID="rdbEstateProperties4" runat="server" GroupName="EstateProperties" Text="其他" /></td>
                        </tr>
                        <tr>
                            <td class="tl PL10" colspan="2">
                                <asp:CheckBox ID="cbNatureTitle1" runat="server" Text="房产证/商品放买卖合同" /><asp:CheckBox ID="cbNatureTitle2" runat="server" Text="购房发票" /><asp:CheckBox ID="cbNatureTitle3" runat="server" Text="规划验收合格证" />
                                <br />
                                <asp:CheckBox ID="cbNatureTitle4" runat="server" Text="企业法人身份证/营业执照（业主属公司）或身份证（业主属个人）/授权委托书" />
                                <br />
                                <asp:CheckBox ID="cbNatureTitle5" runat="server" Text="其他" />
                                <br />
                                <asp:TextBox ID="txtNatureTitleO" runat="server" TextMode="MultiLine" Rows="2" Width="98%" Style="overflow: auto;"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: left" colspan="3">
                                <span style="padding-left: 80px">新分行联络人：<asp:Label ID="lbContacter" runat="server"></asp:Label></span>
                                <span style="text-align: right; margin-left: 200px;">联系电话：<asp:Label ID="ContactPhone" runat="server"></asp:Label></span>
                            </td>
                        </tr>
                    </table>

                </div>
                <!--打印租赁明细表结束-->
            </div>
            <!--打印正文结束-->
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
            <!--打印附件列表结束-->
            <div id="PageBottom">
                <hr />
                <asp:Button ID="btnReWrite" runat="server" OnClick="btnReWrite_Click" Text="重新导入" Visible="false" />
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
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
                <input type="hidden" id="hdDetail1" runat="server" />
                <input type="hidden" id="hdLogisticsFlow" runat="server" />
                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        AddOtherAgree();
        PageInit();
        //autoTextarea(document.getElementById("txtIDx11"));
        //$.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        Sum();
        //$("#tbAround5 tr textarea").each(function(){
        //    if($(this).val() != "")
        //    {
        //        $(this).css({"height":"auto","overflow-x":"visible" });
        //    }
        //});
        //$.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        $("#tbAround5 tr").each(function(){
            var flag = false;
            $(this).find("input[type=radio]").each(function(){
                if(this.checked == true)
                {
                    flag = true;
                    return;
                }
            });
            //没有选择过的
            //alert(flag)
            if(flag)
            {
                $textarea = $(this).find("textarea");
                if($textarea.val() != "")
                {
                    //alert($textarea.val());
                    $textarea.before("<div style='text-align:left'>" + $textarea.val().replace("\r\n","<br/>").replace("\n","<br/>") + "</div>");
                    $textarea.hide();
                }
            }
        });
        window.onload= function(){
            //$("input[id*=btnSignID]").each(function () {
            //    var IsSigndisplay = $(this).css("display");
            //    if(IsSigndisplay != "undefined" && IsSigndisplay !='none')
            //    {
            //        var content =''
            //        if($(this).parent().prev().text() == "集团意见")
            //        {
            //            content =' <input name="btnCancelGroups" type="button" class="cssCancelGroups"    onclick="CancelGroups()" />';
            //        }
            //        else
            //        {
            //            content =' <input name="btnAddGroups" type="button" class="cssAddGroups"    onclick="AddGroups(26)" />';
            //        }
                   
            //        $(this).prev().prev().prev().append(content);
            //    }
            //})
            $("input[id*=btnSignID]").each(function () {
                if($(this).parent().prev().text() == "集团意见")
                {
                    var GroupName = $("#<%=hdGroupName.ClientID%>").val();
                    content =' <label style="color:black">'+GroupName+'</label>';
                    $(this).prev().prev().append(content);
                }
              })
        }
    </script>

    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/10--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
</asp:Content>
