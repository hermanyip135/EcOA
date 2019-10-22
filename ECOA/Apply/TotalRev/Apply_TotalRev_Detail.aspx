<%@ Page ValidateRequest="false" Title="新分行总启费用申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_TotalRev_Detail.aspx.cs" Inherits="Apply_TotalRev_Apply_TotalRev_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
     <link href="../../Style/AddGroups.css" rel="stylesheet" />
    <script type="text/javascript">
        var i = 1;
        var flga = 2;
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

		    $("[id*=btnImport]").css({
		        "background-image": "url(/Images/btnImport1.png)",
		        "height": "36px", 
		        "width": "92px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnImport]").mousedown(function () { $(this).css("background-image", "url(/Images/btnImport2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnImport1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnImport1.png)"); });

			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}

		    $("[id*=btnAddFlow]").css({
		        "background-image": "url(/Images/btn_AddFlows1.png)",
		        "height": "20px", 
		        "width": "90px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnAddFlow]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_AddFlows2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_AddFlows1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_AddFlows1.png)"); });

		    $("[id*=btnDeleteFlow]").css({
		        "background-image": "url(/Images/btn_DeleteFlows1.png)",
		        "height": "20px", 
		        "width": "114px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnDeleteFlow]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows1.png)"); });
		     
		    i = $("#tbDetail tr").length;
		    $("#<%=txtRentBeginDate.ClientID%>").datepicker();
		    $("#<%=txtRentEndDate.ClientID%>").datepicker();
		    $("#<%=txtOBeginDate.ClientID%>").datepicker();
		    $("#<%=txtOEndDate.ClientID%>").datepicker();
		    $("#<%=hdFlowApply.ClientID %>").val($("#txtIDxa4").val());
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应

		    $("#<%=txtFirstRentBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
		    $("#<%=txtRentTaxBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
		    $("#<%=txtFirstMonthBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
		    $("#<%=txtDepositBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
		    $("#<%=txtWEDBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
		    $("#<%=txtManageBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
		    $("#<%=txtSendBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});
		    $("#<%=txtOtherBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate1();});

		    $("#<%=txtPhotoBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtDecorateProjectBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtPhoneAndMonitoringBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtFurnitureBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtStationeryBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtAirConditioningBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtConputerBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtSignatureBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtCertificateBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtOpticalFiberBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtForestBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtMonthCleanBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtYearInsuranceBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});
		    $("#<%=txtRegistrationBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate2();});

		    $("#<%=txtBasisBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate3();});
		    $("#<%=txtAddElectricBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate3();});
		    $("#<%=txtFireBudget.ClientID %>").blur(function () {if (isNaN($(this).val())) {alert("请输入纯数字！");$(this).val('');$(this).focus();}else Caculate3();});

		});

        function Caculate3(){
            var a;
            a = $("#<%=txtBasisBudget.ClientID%>").val()*1 
                + $("#<%=txtAddElectricBudget.ClientID%>").val()*1 
                + $("#<%=txtFireBudget.ClientID%>").val()*1
            $("#tbTable1 input[name='Part3OtherBudget']").each(function(){
                if(this.value != "")
                {
                    a += this.value*1;
                }
            });

            $("#<%=txt3SumBudget.ClientID%>").val(a.toFixed(2));
            $("#<%=txt3BC.ClientID%>").val(a.toFixed(2));

            var BC1 = $("#<%=txt1BC.ClientID%>").val() == "" ? 0 : parseFloat($("#<%=txt1BC.ClientID%>").val());
            var BC2 = $("#<%=txt2BC.ClientID%>").val() == "" ? 0 : parseFloat($("#<%=txt2BC.ClientID%>").val());

            $("#<%=this.txtTcoast.ClientID%>").val((a + BC1 + BC2).toFixed(2));
        }

        function Caculate2(){
            var a = 0;
            var PhotoBudget = $.trim($("#<%=txtPhotoBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtPhotoBudget.ClientID%>").val());
            var DecorateProjectBudget = $.trim($("#<%=txtDecorateProjectBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtDecorateProjectBudget.ClientID%>").val());
            var PhoneAndMonitoringBudget = $.trim($("#<%=txtPhoneAndMonitoringBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtPhoneAndMonitoringBudget.ClientID%>").val());
            var FurnitureBudget = $.trim($("#<%=txtFurnitureBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtFurnitureBudget.ClientID%>").val());
            var StationeryBudget = $.trim($("#<%=txtStationeryBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtStationeryBudget.ClientID%>").val());
            var AirConditioningBudget = $.trim($("#<%=txtAirConditioningBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtAirConditioningBudget.ClientID%>").val());
            var ConputerBudget = $.trim($("#<%=txtConputerBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtConputerBudget.ClientID%>").val());
            var SignatureBudget = $.trim($("#<%=txtSignatureBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtSignatureBudget.ClientID%>").val());
            var CertificateBudget = $.trim($("#<%=txtCertificateBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtCertificateBudget.ClientID%>").val());
            var OpticalFiberBudget = $.trim($("#<%=txtOpticalFiberBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtOpticalFiberBudget.ClientID%>").val());
            var ForestBudget = $.trim($("#<%=txtForestBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtForestBudget.ClientID%>").val());
            var MonthCleanBudget = $.trim($("#<%=txtMonthCleanBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtMonthCleanBudget.ClientID%>").val());
            var YearInsuranceBudget = $.trim($("#<%=txtYearInsuranceBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtYearInsuranceBudget.ClientID%>").val());
            var RegistrationBudget = $.trim($("#<%=txtRegistrationBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtRegistrationBudget.ClientID%>").val());

            a = parseFloat(PhotoBudget)
                + parseFloat(DecorateProjectBudget)
                + parseFloat(PhoneAndMonitoringBudget)
                + parseFloat(FurnitureBudget)
                + parseFloat(StationeryBudget)
                + parseFloat(AirConditioningBudget)
                + parseFloat(ConputerBudget)
                + parseFloat(SignatureBudget)
                + parseFloat(CertificateBudget)
            + parseFloat(OpticalFiberBudget)
            + parseFloat(ForestBudget)
            + parseFloat(MonthCleanBudget)
            + parseFloat(YearInsuranceBudget)
            + parseFloat(RegistrationBudget)
            $("#<%=txt2SumBudget.ClientID%>").val(a.toFixed(2));
            $("#<%=txt2BC.ClientID%>").val(a.toFixed(2));

            var BC1 = $("#<%=txt1BC.ClientID%>").val() == "" ? 0 : parseFloat($("#<%=txt1BC.ClientID%>").val());
            var BC3 = $("#<%=txt3BC.ClientID%>").val() == "" ? 0 : parseFloat($("#<%=txt3BC.ClientID%>").val());

            $("#<%=this.txtTcoast.ClientID%>").val((a + BC1 + BC3).toFixed(2));
        }
       
        function Caculate1(){
            var a;
            var FirstRentBudget = $.trim($("#<%=txtFirstRentBudget.ClientID%>").val())==""?"0":$.trim($("#<%=txtFirstRentBudget.ClientID%>").val());
            var RentTaxBudget = $.trim($("#<%=txtRentTaxBudget.ClientID%>").val())==""?"0":$.trim($("#<%=txtRentTaxBudget.ClientID%>").val());
            var FirstMonthBudget = $.trim($("#<%=txtFirstMonthBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtFirstMonthBudget.ClientID%>").val());
            var DepositBudget = $.trim($("#<%=txtDepositBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtDepositBudget.ClientID%>").val());
            var WEDBudget = $.trim($("#<%=txtWEDBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtWEDBudget.ClientID%>").val());
            var ManageBudget = $.trim($("#<%=txtManageBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtManageBudget.ClientID%>").val());
            var SendBudget = $.trim($("#<%=txtSendBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtSendBudget.ClientID%>").val());
            var OtherBudget = $.trim($("#<%=txtOtherBudget.ClientID%>").val()) == "" ? "0" : $.trim($("#<%=txtOtherBudget.ClientID%>").val());

            a = parseFloat(FirstRentBudget) 
                + parseFloat(RentTaxBudget) 
                + parseFloat(FirstMonthBudget)
                + parseFloat(DepositBudget)
                + parseFloat(WEDBudget)
                + parseFloat(ManageBudget)
                + parseFloat(SendBudget)
                + parseFloat(OtherBudget)
            $("#<%=txt1SumBudget.ClientID%>").val(a.toFixed(2));
            $("#<%=txt1BC.ClientID%>").val(a.toFixed(2));

            var BC2 = $("#<%=txt2BC.ClientID%>").val() == "" ? 0 : parseFloat($("#<%=txt2BC.ClientID%>").val());
            var BC3 = $("#<%=txt3BC.ClientID%>").val() == "" ? 0 : parseFloat($("#<%=txt3BC.ClientID%>").val());
            

            $("#<%=this.txtTcoast.ClientID%>").val((a + BC2 + BC3).toFixed(2))
        }
        

        function check() {
	        
            //第三部分其他费用、其他费用备注
            var html = "";
            $("#tbTable1 input[name='Part3OtherBudget']").each(function(){
                html += $.trim($(this).val()) + "||";
            });
            if(html != "")
            {
                html = html.substr(0,html.length-2);
            }
            $("#<%=this.hidPart3OtherBudget.ClientID%>").val(html);

            html = "";
            $("#tbTable1 textarea[name='Part3OtherRemark']").each(function(){
                html += $.trim($(this).val()) + "||";
            });
            if(html != "")
            {
                html = html.substr(0,html.length-2);
            }
            $("#<%=this.hidPart3OtherRemark.ClientID%>").val(html);
            //第三部分其他费用、其他费用备注 end
                
            var data = "";
            var flag = true, flag2 = true;
            $("#tbDetail tr").each(function(n) {
                if (n != 0 && n != $("#tbDetail tr").size()) {
                    if ($.trim($("#txtDpm" + n).val()) == "总经办") {
                        alert("第" + n + "个后勤审批流程的部门不能为总经办，请填写“董事总经理”。");
                        $("#txtDpm" + n).focus();
                        flag = false;
                    }
                    if ($.trim($("#txtDpm" + n).val()) == "") {
                        alert("第" + n + "个后勤审批流程的部门名称必须填写。");
                        $("#txtDpm" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtIDxa" + (3*n + 1)).val()) == "") {
                        alert("第" + n + "个后勤审批流程的第一环节必须填写。");
                        $("#txtIDxa" + (3*n + 1)).focus();
                        flag = false;
                    }
                    else if($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none" && $.trim($("#txtIDxa" + (3*n + 2)).val()) == "") 
                    {
                        alert("第" + n + "个后勤审批流程的第二环节必须填写。");
                        $("#txtIDxa" + (3*n + 2)).focus();
                        flag = false;
                    }
                    else if($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none" && $.trim($("#txtIDxa" + (3*n + 3)).val()) == "") 
                    {
                        alert("第" + n + "个后勤审批流程的第三环节必须填写。");
                        $("#txtIDxa" + (3*n + 3)).focus();
                        flag = false;
                    }
                    else
                        data += $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+1).toString()
                            + "&&1"
                            + "&&" + ($("#rdoIsCmodel" + n + "11").prop('checked')?"1":"0")
                            + "&&1||"
                            + $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+2).toString()
                            + "&&2"
                            + "&&" + ($("#rdoIsCmodel" + n + "21").prop('checked')?"1":"0")
                            + "&&" + ($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none"?"1":"0") + "||"
                            + $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+3).toString()
                            + "&&3"
                            + "&&" + ($("#rdoIsCmodel" + n + "31").prop('checked')?"1":"0")
                            + "&&" + ($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none"?"1":"0") + "||";
                }
            });

            content = "";
            for(var y = 4; y <= $("[id^=txtIDxa]").size()+3; y++)
            {
                if($("#txtIDxa"+y).parent().css("display")!="none") 
                {
                //    if(y == 3 && $.trim($("#txtIDxa"+y).val())=="")
                //    {
                //        alert("第3个审批环节不可为空！");
                //        $("#txtIDxa"+y).focus();
                //        flag = false;
                //        return false;
                //    }
                //    if(y <= 2 && $.trim($("#txtIDxa"+y).val())=="")
                //    {
                //        deleteidxs += y.toString() + "|";
                //        continue;
                //    }
                    content+=y+":"+$("#txtIDxa"+y).val()+";";
                }
                deleteidxs += y.toString() + "|";
            }
            content = content.substr(0,content.length-1);
            if($("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa4").val())
                flga = 1;

            $("#<%=hdcontent.ClientID %>").val(content);
            $("#<%=hdflga.ClientID %>").val(flga);
            $("#<%=hddeleteidxs.ClientID %>").val(deleteidxs);

            if(flag)
            {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
                            return true;
            }
            else
                return false;
	    }

        function tempsavecheck() {
            //第三部分其他费用、其他费用备注
            var html = "";
            $("#tbTable1 input[name='Part3OtherBudget']").each(function(){
                html += $.trim($(this).val()) + "||";
            });
            if(html != "")
            {
                html = html.substr(0,html.length-2);
            }
            $("#<%=this.hidPart3OtherBudget.ClientID%>").val(html);

            html = "";
            $("#tbTable1 textarea[name='Part3OtherRemark']").each(function(){
                html += $.trim($(this).val()) + "||";
            });
            if(html != "")
            {
                html = html.substr(0,html.length-2);
            }
            $("#<%=this.hidPart3OtherRemark.ClientID%>").val(html);

            //前线部门审批流程
            var data = "";
            $("#tbDetail tr").each(function(n) {
                if (n != 0 && n != $("#tbDetail tr").size()) {
                    data += $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+1).toString()
                            + "&&1"
                            + "&&" + ($("#rdoIsCmodel" + n + "11").prop('checked')?"1":"0")
                            + "&&1||"
                            + $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+2).toString()
                            + "&&2"
                            + "&&" + ($("#rdoIsCmodel" + n + "21").prop('checked')?"1":"0")
                            + "&&" + ($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none"?"1":"0") + "||"
                            + $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+3).toString()
                            + "&&3"
                            + "&&" + ($("#rdoIsCmodel" + n + "31").prop('checked')?"1":"0")
                            + "&&" + ($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none"?"1":"0") + "||";
                }
            });

            content = "";
            for(var y = 4; y <= $("[id^=txtIDxa]").size()+3; y++)
            {
                if($("#txtIDxa"+y).parent().css("display")!="none") 
                {
                    content+=y+":"+$("#txtIDxa"+y).val()+";";
                }
                deleteidxs += y.toString() + "|";
            }
            content = content.substr(0,content.length-1);
            if($("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa4").val())
                flga = 1;
            $("#<%=hdcontent.ClientID %>").val(content);
            $("#<%=hdflga.ClientID %>").val(flga);
            $("#<%=hddeleteidxs.ClientID %>").val(deleteidxs);

            if(data!="")
            {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
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
		            window.location='Apply_TotalRev_Detail.aspx?MainID=<%=MainID %>';
		}

        function Imports() {
            var sReturnValue = window.showModalDialog("Apply_zNull_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
            if (sReturnValue == "undefined") {
                sReturnValue = window.returnValue;
            }
            //alert(sReturnValue);
            $("#<%=hdFilePath.ClientID%>").val(sReturnValue);
	        return true;
        }

		function editflow(){
			var win=window.showModalDialog("Apply_TotalRev_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_TotalRev_Detail.aspx?MainID=<%=MainID %>";
		}
		        
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
	    function sign(idx) {
	        //if(idx=='46'||idx=='47'||idx=='48'||idx=='49'||idx=='50'||idx=='53'){//789
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

			if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
				alert("由于您不同意该申请，必须填写不同意的原因。");
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
			//	var temp = window.document.body.innerHTML;        
			//	var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
			//	window.document.body.innerHTML = printhtml;        
			//	window.print();        
			//	window.document.body.innerHTML = temp;    
			//}    
		    //else { window.print(); }
		    cMyPrint();
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
		            data: 'action=SaveCommonFlowLogistics&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+54,
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
        function addRow() {
            i = $("#tbDetail tr").length;
            var html = '<tr id="trDetail' + i + '" class="noborder" style="height: 85px;">'
                +   '<td style="text-align: left; padding-left: 10px;" colspan="4">'
                +   '<div class="flow">'
                +   '部门名称：<input type="text" id="txtDpm' + i + '" style="margin-bottom: 10px;width:250px;" /><br/>'
                +   '<div id="divIDx' + (3*i+1) + '" class="item2">环节1</div>'
                +   '<div id="divTxtIDx' + (3*i+1) + '" class="item2">'
                +   '   <input type="text" id="txtIDxa' + (3*i+1) + '" style="width:190px;" /><input id="hdIDx' + (3*i+1) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '11" checked="checked" name="IsCmodel' + i + '1" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '11">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '10" name="IsCmodel' + i + '1" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '10">单人审批</label>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*i+2) + '" class="item2"><input id="btnIDx' + i + '2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*i+2) + ');" />'
                +   '   <label id="lblIDx' + i + '2" for="btnIDx' + i + '2">环节2</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*i+2) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节2&nbsp;<input type="text" id="txtIDxa' + (3*i+2) + '" style="width:190px;" /><input id="hdIDx' + (3*i+2) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '21" checked="checked" name="IsCmodel' + i + '2" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '21">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '20" name="IsCmodel' + i + '2" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '20">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*i+2) + ')">取消</a>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*i+3) + '" class="item2"><input id="btnIDx' + i + '3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*i+3) + ');" />'
                +   '   <label id="lblIDx' + i + '3" for="btnIDx' + i + '3">环节3</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*i+3) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节3&nbsp;<input type="text" id="txtIDxa' + (3*i+3) + '" style="width:190px;" /><input id="hdIDx' + (3*i+3) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '31" checked="checked" name="IsCmodel' + i + '3" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '31">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '30" name="IsCmodel' + i + '3" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '30">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*i+3) + ')">取消</a>'
                +   '</div></div>'
                +   '</td>'
                + '</tr>'
            //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
            //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
            $("#trFlag").before(html);
            $("#txtDpm"+ i).autocomplete({source: jJSON});
            for(var il =1;il<=3;il++)
            {
                $("#txtIDxa" + (3*i + il))
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
            i++; 
        }

        function deleteRow() {
            if (i > 1) {
                i--;
                $("#tbDetail tr:eq(" + (i - 1) + ")").remove();
                //$("#tbAround tr[id*=trDetail]").remove();
            } else
                alert("不可再删除了。");
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
        /*
        function Sum(obj)
        {
            alert("执行了");
            var tb = $(obj).parent().parent().parent();
            var sum = 0;
            var suminput;
            tb.find("input[type='text']").each(function(){
                if(!$(this).hasClass("suminput"))
                {
                    if($.trim(this.value)!=="")
                    {
                        sum += parseInt(this.value);
                    }
                }
                else
                {
                    suminput = $(this);
                }
            });

            suminput.val(sum);
        }
        */

        //第三部分费用
        //添加行
        function AddtbTable1Row(obj,inputname)
        {
            var thistr = $(obj).parent().parent();
            var prevtr = thistr.prev();
            var no = prevtr.find(".tdno").html().replace(".","");
            //alert(no);
            var html = '<tr>'
                       +'<td class ="tbtd tdno">' + (parseInt(no)+1) + '.</td><td class ="tbtd">其他费用</td>'
                       +'<td class ="tbtd"><input type="text" name="Part3OtherBudget" onblur="Caculate3();" /></td>'
                       +'<td class ="tbtd"><textarea name="Part3OtherRemark" style="height:44px;width:320px;overflow:hidden" cols="20" rows="2"></textarea></td>'
                       +'</tr>';
            thistr.before(html);
        }
        //删除行
        function DelRow(obj)
        {
            var thistr = $(obj).parent().parent();
            var tb = thistr.parent();
            if(tb.find("tr").length <= 6)
            {
                alert("不能再删了");
                return;
            }
            thistr.prev().remove();
        }
        function PageInitTable()
        {
            //第三部分其他费用初始化
            var Part3OtherBudget = $("#<%=this.hidPart3OtherBudget.ClientID%>").val();
            var Part3OtherRemark = $("#<%=this.hidPart3OtherRemark.ClientID%>").val();
            var html = "";
            if(Part3OtherBudget == "" || Part3OtherRemark == "")
            {
                html += '<tr>'
                       +'<td class ="tbtd tdno">' + 4 + '.</td><td class ="tbtd">其他费用</td>'
                       +'<td class ="tbtd"><input type="text" name="Part3OtherBudget" onblur="Caculate3();" /></td>'
                       +'<td class ="tbtd"><textarea name="Part3OtherRemark" style="height:44px;width:320px;overflow:hidden" cols="20" rows="2"></textarea></td>'
                       +'</tr>';
                $("#tbTable1").find(".btntr").before(html);
                return;
            }
                //return;

            var Budgets = Part3OtherBudget.split("||");
            var Remarks = Part3OtherRemark.split("||");
            
            for(var i = 0; i < Budgets.length && i < Remarks.length; i++)
            {
                //序列从4开始
                html += '<tr>'
                       +'<td class ="tbtd tdno">' + (4+i) + '.</td><td class ="tbtd">其他费用</td>'
                       +'<td class ="tbtd"><input type="text" name="Part3OtherBudget" value="' + Budgets[i] + '" onblur="Caculate3();" /></td>'
                       +'<td class ="tbtd"><textarea name="Part3OtherRemark" style="height:44px;width:320px;overflow:hidden" cols="20" rows="2">' + Remarks[i] + '</textarea></td>'
                       +'</tr>';
            }
            $("#tbTable1").find(".btntr").before(html);
        }
	</script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
        .auto-style2 {
            width: 85px;
        }
        .tbtd {
            font-weight: bold; 
            padding-right: 5px; 
            padding-left: 5px;
            vertical-align: top;
            text-align:left;
            line-height: 15px;
        }
        .btnaddRow{display:none}
    </style>
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
			<%--<h1>新分行总启费用申请表</h1>--%>
                <span style="font-size:20px; font-weight:bold">新分行总启费用申请表</span><label id="laIsGroups" runat="server" style="color:red; font-size:15px;"></label>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:720px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='720px'>
                <tr>
                    <td>收文部门</td>
                    <td class="tl PL10">行政部</td>
					<td class="auto-style2">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server"></asp:textbox></td>
				</tr>
				<tr>
                    <td>发文部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                        &nbsp;- <asp:Label ID="lblApply" runat="server"></asp:Label>
                    </td>
                    <td>发文日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
				<tr>
                    <td>抄送部门</td>
                    <td class="tl PL10">行政部；财务部；后勤事务部；总经办</td>
                    <td>回复电话</td>
					<td class="tl PL10"><asp:textbox id="txtReplyPhone" runat="server"></asp:textbox></td>
				</tr>
                <tr>
                    <td>文件主题</td>
                    <td class="tl PL10">关于<asp:textbox id="txtSubject" runat="server" Width="160px"></asp:textbox>的总启费用申请</td>
                    <td>回复传真</td>
                    <td class="tl PL10"><asp:textbox id="txtReplyFax" runat="server"></asp:textbox></td>
				</tr>
				<tr>
                    <td colspan="4" style="padding: 5px; text-align: left; line-height: 30px;">
                        <span>　　为配合物业部业务拓展工作开展，现选定
                            <asp:textbox id="txtAddress" runat="server" Width="360px"></asp:textbox>
                            作为新分行之营运地点，该分行命名
                            <asp:textbox id="txtBranchName" runat="server" Width="300px"></asp:textbox>
                            。租赁条件基本商定如下：</span><br />
                        　　1.	建筑面积：<asp:textbox id="txtBSquare" runat="server"></asp:textbox>平方米，
                                实用面积<asp:textbox id="txtCSquare" runat="server"></asp:textbox>平方米。<br />
                        　　2.	租　　金：租金<asp:textbox id="txtRent" runat="server"></asp:textbox>元/月
                               （租金连发票，每年递增<asp:textbox id="txtPercent" runat="server" Width="60px"></asp:textbox>%，<br />　　　　　　　　
                                即第1年<asp:textbox id="txt1hYear" runat="server"></asp:textbox>元/月,
                                第2年<asp:textbox id="txt2hYear" runat="server"></asp:textbox>元/月,<br />　　　　　　　　
                                第3年<asp:textbox id="txt3hYear" runat="server"></asp:textbox>元/月, 
                                第4年<asp:textbox id="txt4hYear" runat="server"></asp:textbox>元/月,<br />　　　　　　　　
                                第5年<asp:textbox id="txt5hYear" runat="server"></asp:textbox>元/月）。<br />
                        　　3.	租 赁 期：<asp:textbox id="txtRentYear" runat="server" Width="75px"></asp:textbox>年<asp:textbox id="txtRentMonth" runat="server" Width="75px"></asp:textbox>月，
                                由<asp:textbox id="txtRentBeginDate" runat="server" Width="75px"></asp:textbox>起至<asp:textbox id="txtRentEndDate" runat="server" Width="75px"></asp:textbox>止<br />　　　　　　　　
                        (免租期：<asp:textbox id="txtOBeginDate" runat="server" Width="75px"></asp:textbox>起至<asp:textbox id="txtOEndDate" runat="server" Width="75px"></asp:textbox>止，
                                共<asp:textbox id="txtOCount" runat="server" Width="75px"></asp:textbox>日) 。<br />
                        　　4.	管 理 费：约<asp:textbox id="txtMcoastMonth" runat="server"></asp:textbox>元/月(含发票),
                                即<asp:textbox id="txtMcoast" runat="server"></asp:textbox>元/m2，<br />　　　　　　　　
                                发票由<asp:textbox id="txtMProvide" runat="server"></asp:textbox>提供。<br />
                        　　5.	水、电费：水费: <asp:textbox id="txtWaterCost" runat="server"></asp:textbox>元/吨(含发票)、
                                电费：<asp:textbox id="txtElectCost" runat="server"></asp:textbox>元/度<br />　　　　　　　　（每月按实际用量计算），
                                由<asp:textbox id="txtWEProvide" runat="server"></asp:textbox>提供相关的发票。<br />
                    </td>
				</tr>
                <tr>
                    <td colspan="4" style="padding: 5px; text-align: center; line-height: 30px;">
                        <span style="font-weight: bold">
                            这次<asp:textbox id="txtTbranch" runat="server"></asp:textbox>
                            的总启费用为<asp:textbox id="txtTcoast" runat="server"></asp:textbox>元，具体由以下三部分组成：
                        </span><br />
                        <span>
                            ◆第一部分：关于租赁方面的相关费用预算<asp:textbox id="txt1BC" runat="server"></asp:textbox>元，具体如下：
                        </span><br />
                        <table style="border-collapse: collapse; line-height: normal; margin:0 auto;">
                            <thead style="font-weight: bold">
                                <tr>
                                    <td>序</td>
                                    <td>内容</td>
                                    <td>预算费用(元)</td>
                                    <td>备注</td>
                                </tr>
                            </thead>
                            <tr>
                                <td class ="tbtd">1.</td><td class ="tbtd">首月租金</td>
                                <td class ="tbtd"><asp:textbox id="txtFirstRentBudget" runat="server" ></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtFirstRentRemark" runat="server" Height="40px" TextMode="MultiLine" Width="340px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">2.</td><td class ="tbtd">租赁印花税</td>
                                <td class ="tbtd"><asp:textbox id="txtRentTaxBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtRentTaxRemark" runat="server" Height="40px" TextMode="MultiLine" Width="340px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">3.</td><td class ="tbtd">首月管理费</td>
                                <td class ="tbtd"><asp:textbox id="txtFirstMonthBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtFirstMonthRemark" runat="server" Height="40px" TextMode="MultiLine" Width="340px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">4.</td><td class ="tbtd">租赁按金</td>
                                <td class ="tbtd"><asp:textbox id="txtDepositBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtDepositRemark" runat="server" Height="40px" TextMode="MultiLine" Width="340px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">5.</td><td class ="tbtd">水电按金</td>
                                <td class ="tbtd"><asp:textbox id="txtWEDBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtWEDRemark" runat="server" Height="40px" TextMode="MultiLine" Width="340px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">6.</td><td class ="tbtd">管理费按金</td>
                                <td class ="tbtd"><asp:textbox id="txtManageBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtManageRemark" runat="server" Height="40px" TextMode="MultiLine" Width="340px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">7.</td><td class ="tbtd">顶手费</td>
                                <td class ="tbtd"><asp:textbox id="txtSendBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtSendRemark" runat="server" Height="40px" TextMode="MultiLine" Width="340px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">8.</td><td class ="tbtd">其它按金</td>
                                <td class ="tbtd"><asp:textbox id="txtOtherBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtOtherRemark" runat="server" Height="40px" TextMode="MultiLine" Width="340px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd"></td><td class ="tbtd">合　计</td>
                                <td class ="tbtd"><asp:textbox id="txt1SumBudget" runat="server" CssClass="suminput"></asp:textbox></td>
                                <td class ="tbtd"></td>
                            </tr>
                        </table>
                        <span>
                            ◆第二部份费用：筹建各项的相关预算为<asp:textbox id="txt2BC" runat="server"></asp:textbox>元，具体如下：
                        </span><br />
                        <table style="border-collapse: collapse; line-height: normal; margin:0 auto;">
                            <thead style="font-weight: bold">
                                <tr>
                                    <td>序</td>
                                    <td>内容</td>
                                    <td>预算费用(元)</td>
                                    <td>备注</td>
                                </tr>
                            </thead>
                            <tr>
                                <td class ="tbtd">1.</td><td class ="tbtd">装修平面图及天花平面图</td>
                                <td class ="tbtd"><asp:textbox id="txtPhotoBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtPhotoRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">2.</td><td class ="tbtd">装修工程</td>
                                <td class ="tbtd"><asp:textbox id="txtDecorateProjectBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtDecorateProjectRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">3.</td><td class ="tbtd">电话、网络及监控工程</td>
                                <td class ="tbtd"><asp:textbox id="txtPhoneAndMonitoringBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtPhoneAndMonitoringRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">4.</td><td class ="tbtd">办公家具</td>
                                <td class ="tbtd"><asp:textbox id="txtFurnitureBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtFurnitureRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">5.</td><td class ="tbtd">办公文具、办公设备</td>
                                <td class ="tbtd"><asp:textbox id="txtStationeryBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtStationeryRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">6.</td><td class ="tbtd">空调设备</td>
                                <td class ="tbtd"><asp:textbox id="txtAirConditioningBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtAirConditioningRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">7.</td><td class ="tbtd">电脑设备</td>
                                <td class ="tbtd"><asp:textbox id="txtConputerBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtConputerRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">8.</td><td class ="tbtd">招牌灯箱</td>
                                <td class ="tbtd"><asp:textbox id="txtSignatureBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtSignatureRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">9.</td><td class ="tbtd">证照、海报架、不锈钢字</td>
                                <td class ="tbtd"><asp:textbox id="txtCertificateBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtCertificateRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">10.</td><td class ="tbtd">光纤工程</td>
                                <td class ="tbtd"><asp:textbox id="txtOpticalFiberBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtOpticalFiberRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">11.</td><td class ="tbtd">开荒清洁费</td>
                                <td class ="tbtd"><asp:textbox id="txtForestBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtForestRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">12.</td><td class ="tbtd">月清洁费</td>
                                <td class ="tbtd"><asp:textbox id="txtMonthCleanBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtMonthCleanRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">13.</td><td class ="tbtd">年保险费</td>
                                <td class ="tbtd"><asp:textbox id="txtYearInsuranceBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtYearInsuranceRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd">14.</td><td class ="tbtd">办证费</td>
                                <td class ="tbtd"><asp:textbox id="txtRegistrationBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtRegistrationRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd"></td><td class ="tbtd">合　计</td>
                                <td class ="tbtd"><asp:textbox id="txt2SumBudget" runat="server" CssClass="suminput"></asp:textbox></td>
                                <td class ="tbtd"></td>
                            </tr>
                        </table>
                        <span>
                            ◆第三部分费用：无基础水电/电力不足/消防由特定公司进行报建，费用为<asp:textbox id="txt3BC" runat="server"></asp:textbox>元：
                        </span><br />
                        <table id="tbTable1" style="border-collapse: collapse; line-height: normal; margin:0 auto;">
                            <thead style="font-weight: bold;">
                                <tr>
                                    <td>序</td>
                                    <td>内容</td>
                                    <td>预算费用(元)</td>
                                    <td>备注</td>
                                </tr>
                            </thead>
                            <tr>
                                <td class ="tbtd tdno">1.</td><td class ="tbtd">基础水电拉设费用</td>
                                <td class ="tbtd"><asp:textbox id="txtBasisBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtBasisRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd tdno">2.</td><td class ="tbtd">电力增容费用</td>
                                <td class ="tbtd"><asp:textbox id="txtAddElectricBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtAddElectricRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td class ="tbtd tdno">3.</td><td class ="tbtd">消防报建</td>
                                <td class ="tbtd"><asp:textbox id="txtFireBudget" runat="server"></asp:textbox></td>
                                <td class ="tbtd"><asp:textbox id="txtFireRemark" runat="server" Height="40px" TextMode="MultiLine" Width="320px"></asp:textbox></td>
                            </tr>
                            <%--<tr>
                                <td class ="tbtd tdno">4.</td><td class ="tbtd">其他费用</td>
                                <td class ="tbtd"><input type="text" name="Part3OtherBudget" onblur="Caculate3();" /></td>
                                <td class ="tbtd"><textarea name="Part3OtherRemark" style="height:44px;width:320px;overflow:hidden" cols="20" rows="2"></textarea></td>
                            </tr>--%>
                            <tr class="btntr">
                                <td colspan="3">
                                    <asp:HiddenField ID="hidPart3OtherBudget" runat="server" />
                                    <asp:HiddenField ID="hidPart3OtherRemark" runat="server" />
                                    <asp:HiddenField id="hdGroupName" runat="server"/>
                                    <input type="button" class="btnaddRow" value="添加新行" onclick="AddtbTable1Row(this,'txtStandardSituation')" /><input type="button" class="btnaddRow" value="删除一行" onclick="DelRow(this)" />
                                </td>
                            </tr>
                            <tr>
                                <td class ="tbtd"></td><td class ="tbtd">合　计</td>
                                <td class ="tbtd"><asp:textbox id="txt3SumBudget" runat="server" CssClass="suminput"></asp:textbox></td>
                                <td class ="tbtd"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; line-height: 20px;">
                    　　　以上事宜，特此申请。<br />
                    　　　盼回复！
                    </td>
                </tr>
                <tr>
                    <th colspan="4" style="font-size: 15px">前线部门审批流程</th>
                </tr>
                <tr id="trM1" style="display: none;">
                    <td class="tl PL10 PR10" colspan="4">
                        <table id="tbDetail" class='sample tc' width='100%'>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag">
                                <td></td>
                            </tr>
                        </table>
                        <input type="button" id="btnAddFlow" value="添加新行" onclick="addRow();" style="float: left; display: none" />
                        <input type="button" id="btnDeleteFlow" value="删除一行" onclick="deleteRow();" style="float: left; display: none; margin-left: 10px;" />
                    </td>
                </tr>
                <%=SbHtml2.ToString()%>
                <tr>
                    <th colspan="4" style="font-size: 15px">后勤部门审批流程</th>
                </tr>
                <tr id="trShowFlow44" class="noborder" style="height: 85px;"> 
					<td rowspan="2" >行政部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx44" type="radio" name="agree44" /><label for="rdbYesIDx44">确认</label><input id="rdbNoIDx44" type="radio" name="agree44" /><label for="rdbNoIDx44">退回申请</label>
                        <input id="rdbOtherIDx44" type="radio" name="agree44" /><label for="rdbOtherIDx44">其他意见</label><br />
						<textarea id="txtIDx44" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx44" value="签署意见" onclick="sign('44')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx44">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow45" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx45" type="radio" name="agree45" /><label for="rdbYesIDx45">同意</label><input id="rdbNoIDx45" type="radio" name="agree45" /><label for="rdbNoIDx45">不同意</label>
                        <input id="rdbOtherIDx45" type="radio" name="agree45" /><label for="rdbOtherIDx45">其他意见</label><br />
						<textarea id="txtIDx45" style="width: 98%; overflow: auto; height: 85px;"></textarea><input type="button" id="btnSignIDx45" value="签署意见" onclick="sign('45')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx45">_________</span></div>
					</td>
				</tr>
                    <tr id="trCoo" class="noborder" style="height: 85px;">
					        <td >首席运营官</td>
					        <td colspan="3" class="tl PL10" style=" ">
						        <input id="rdbYesIDx50" type="radio" name="agree50" /><label for="rdbYesIDx50">同意</label><input id="rdbNoIDx50" type="radio" name="agree50" /><label for="rdbNoIDx50">不同意</label>
                                <input id="rdbOtherIDx50" type="radio" name="agree50" /><label for="rdbOtherIDx50">其他意见</label><br />
						        <textarea id="txtIDx50" rows="3" style="width: 98%; overflow: auto;"></textarea>
                                <input type="button" id="btnSignIDx50" value="签署意见" onclick="sign('50')" style="display: none;" />
                                <div class="signdate">日期：<span id="spanDateIDx50">_________</span></div>
					        </td>
				       </tr>
<%--				<tr class="noborder" style="height: 85px;"> 
					<td rowspan="2" >外联部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx56" type="radio" name="agree56" /><label for="rdbYesIDx56">确认</label>
                        <input id="rdbNoIDx56" type="radio" name="agree56" /><label for="rdbNoIDx56">退回申请</label><br />
						<textarea id="txtIDx56" style="width: 98%; overflow: auto; height: 85px;">
                        </textarea><input type="button" id="btnSignIDx56" value="签署意见" onclick="sign('56')" style="display: none;" />
                       <div class="signdate">日期：<span id="spanDateIDx56">_________</span></div>
					</td>
				</tr>
				<tr class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx57" type="radio" name="agree57" /><label for="rdbYesIDx57">同意</label>
                        <input id="rdbNoIDx57" type="radio" name="agree57" /><label for="rdbNoIDx57">不同意</label><br />
						<textarea id="txtIDx57" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx57" value="签署意见" onclick="sign('57')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx57">_________</span></div>
					</td>
				</tr>--%>
                <tr id="trShowFlow48" class="noborder" style="height: 85px; display:none;"> 
					<td rowspan="2" >法律部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx58" type="radio" name="agree58" /><label for="rdbYesIDx58">同意</label>
                        <input id="rdbNoIDx58" type="radio" name="agree58" /><label for="rdbNoIDx58">不同意</label><br />
						<textarea id="txtIDx58" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx58" value="签署意见" onclick="sign('58')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx58">_________</span></div>
					</td>
				</tr>
				<tr id="trShowFlow49" class="noborder" style="height: 85px; display:none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx59" type="radio" name="agree49" /><label for="rdbYesIDx59">同意</label>
                        <input id="rdbNoIDx59" type="radio" name="agree59" /><label for="rdbNoIDx59">不同意</label><br />
						<textarea id="txtIDx59" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx59" value="签署意见" onclick="sign('59')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx59">_________</span></div>
					</td>
				</tr>
<%--				<tr class="noborder" style="height: 85px;"> 
					<td rowspan="1" >财务部意见</td>                                                                                                           
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx60" type="radio" name="agree60" /><label for="rdbYesIDx60">确认</label>
                        <input id="rdbNoIDx60" type="radio" name="agree60" /><label for="rdbNoIDx60">退回申请</label><br />
						<textarea id="txtIDx60" style="width: 98%; overflow: auto; height: 85px;"></textarea>
                        <input type="button" id="btnSignIDx60" value="签署意见" onclick="sign('60')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx60">_________</span></div>
					</td>
				</tr>--%>
				<tr id="trShowFlow51" class="noborder" style="height: 85px;">
                    <td rowspan="2" >财务部意见</td> 
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx61" type="radio" name="agree61" /><label for="rdbYesIDx61">同意</label>
                        <input id="rdbNoIDx61" type="radio" name="agree61" /><label for="rdbNoIDx61">不同意</label>
                        <input id="rdbOtherIDx61" type="radio" name="agree61" /><label for="rdbOtherIDx61">其他意见</label>
                        　<asp:LinkButton ID="lbtnAddN" runat="server" OnClick="lbtnAddN_Click" Visible="False">添加宁伟雄审批</asp:LinkButton><br />
						<textarea id="txtIDx61" style="width: 98%; overflow: auto; height: 86px;"></textarea>
                        <input type="button" id="btnSignIDx61" value="签署意见" onclick="sign('61')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx61">_________</span></div>
					</td>
				</tr>
                <tr id="trShowFlow52" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx62" type="radio" name="agree62" /><label for="rdbYesIDx62">同意</label>
                        <input id="rdbNoIDx62" type="radio" name="agree62" /><label for="rdbNoIDx62">不同意</label>
                        <input id="rdbOtherIDx62" type="radio" name="agree62" /><label for="rdbOtherIDx62">其他意见</label><br />
						<textarea id="txtIDx62" style="width: 98%; overflow: auto; height: 84px;"></textarea>
                        <input type="button" id="btnSignIDx62" value="签署意见" onclick="sign('62')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx62">_________</span></div>
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
                        <%--<tr id="trShowFlow53" class="noborder" style="height: 85px;"> 
					        <td rowspan="4" >后勤事务部<br />
                                <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
                                <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>                                                                                                           
					        <td colspan="3" class="tl PL10" style=" ">
						        <input id="rdbYesIDx63" type="radio" name="agree63" /><label for="rdbYesIDx53">确认</label>
                               <input id="rdbNoIDx63" type="radio" name="agree63" /><label for="rdbNoIDx63">退回申请</label><br />
						        <textarea id="txtIDx63" rows="3" style="width: 98%; overflow: auto;"></textarea>
                            <input type="button" id="btnSignIDx63" value="签署意见" onclick="sign('63')" style="display: none;" />
                            <div class="signdate">日期：<span id="spanDateIDx63">_________</span></div>
					        </td>
				        </tr>--%>
				    <%--    <tr id="trLogistics2" class="noborder" style="height: 85px;">
                            <td rowspan="4" >后勤事务部<br />
                                <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td> 

					        <td colspan="3" class="tl PL10" style=" ">
						        <input id="rdbYesIDx64" type="radio" name="agree64" /><label for="rdbYesIDx64">同意</label>
                                <input id="rdbNoIDx64" type="radio" name="agree64" /><label for="rdbNoIDx64">不同意</label>
                                <input id="rdbOtherIDx64" type="radio" name="agree64" value="1" /><label for="rdbOtherIDx64">其他意见</label>
                                　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　         <a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
						        <textarea id="txtIDx64" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx64" value="签署意见" onclick="sign('64')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx64">_________</span></div>
					        </td>
				        </tr>--%>
                        <tr id="tlsc1" class="noborder" style="height: 85px; display:none;">
					<td colspan="3" class="tl PL10" style="">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130"  value="1" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                        <tr><td style="line-height: 0px;"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>
               
				        <tr id="trGeneralManager" class="noborder" style="height: 85px;">
					        <td >董事总经理</td>
					        <td colspan="3" class="tl PL10" style=" ">
						        <input id="rdbYesIDx65" type="radio" name="agree65" /><label for="rdbYesIDx65">同意</label>
                                <input id="rdbNoIDx65" type="radio" name="agree65" /><label for="rdbNoIDx65">不同意</label>
                                <input id="rdbOtherIDx65" type="radio" name="agree65" /><label for="rdbOtherIDx65">其他意见</label><br />
						        <textarea id="txtIDx65" rows="3" style="width: 98%; overflow: auto;"></textarea>
                                <input type="button" id="btnSignIDx65" value="签署意见" onclick="sign('65')" style="display: none;" />
                                <div class="signdate">日期：<span id="spanDateIDx65">_________</span></div>
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
                
                <tr style=" display:none;">
					<td style="line-height: 15px;" class="auto-style2">中原地产华南区总裁审批意见</td>
					<td colspan="3" class="tl PL10" style="  line-height: 40px;">
                        <label>【 】同意</label>　<label>【 】不同意</label>
                        <div>______________________________________________________________________________________________________</div>
                        <div>______________________________________________________________________________________________________</div>
                        <div>_____<span style="text-decoration: underline">李耀智</span>_____　　_________________________________________________　　_________年_______月_______日</div>
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
        <span style="font-size: large; padding-top: 10px; padding-bottom: 10px"><a href="../../资料/新分行总启导入模板.xlsx">下载导入模板</a></span>
        <br />
        <asp:button runat="server" id="btnImport" text="导入数据" OnClick="btnImport_Click" onclientclick="return Imports();" /><%--onclientclick="return Imports();"--%>
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="False" />
        <asp:button runat="server" id="btnTemp" text="暂时保存" onclick="btnTempSave_Click" CssClass="commonbtn" onclientclick="return tempsavecheck();" />
        <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('请注意，若修改了审批表的内容，则所有已审批的环节都必须重审；\r\n若只修改审批流程，则该流程的后续环节需重审；\r\n确定要修改吗？')){if($('h1').attr('name') != 'DeleteD')return check();else return alert('该表即将被删除，暂停修改操作');}else return false;" OnClick="btnSAlterC_Click" />
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
		<input type="hidden" id="hdDetail1" runat="server" />
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />

            <asp:HiddenField ID="hdFlowApply" runat="server" />
            <asp:HiddenField ID="hdcontent" runat="server" />
            <asp:HiddenField ID="hdflga" runat="server" />
            <asp:HiddenField ID="hddeleteidxs" runat="server" />
            <input type="hidden" id="hdFilePath" runat="server" />

        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        PageInitTable();
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        window.onload= function(){
       
            //$("input[id*=btnSignID]").each(function () {
            //    var IsSigndisplay = $(this).css("display");
            //    if(IsSigndisplay != "undefined" && IsSigndisplay !='none')
            //    {
            //        //var content =' <input name="btnAddGroups" type="button" class="cssAddGroups"    onclick="AddGroups(65)" />';
            //        //$(this).prev().prev().prev().append(content);
            //        var content =''
            //        if($(this).parent().prev().text() == "集团意见")
            //        {
            //            content =' <input name="btnCancelGroups" type="button" class="cssCancelGroups"    onclick="CancelGroups()" />';
            //        }
            //        else
            //        {
            //            content =' <input name="btnAddGroups" type="button" class="cssAddGroups"    onclick="AddGroups(65)" />';
            //        }
                   
            //        $(this).prev().prev().prev().append(content);
            //    }
            //})
            $("input[id*=btnSignID]").each(function () {
                if($(this).parent().prev().text() == "集团意见")
                {
                    var GroupName = $("#<%=hdGroupName.ClientID%>").val();
                    content =' <label style="color:black">'+GroupName+'</label>';
                    $(this).prev().prev().prev().append(content);
                }
             })
        }
    </script>
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/10--52100) --%>
    <%--<script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>--%>
</asp:Content>

