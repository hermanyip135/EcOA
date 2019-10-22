<%@ Page Title="放款申请表 - 广东中原地产代理有限公司" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Loan_Detail.aspx.cs"  ValidateRequest="false"  Inherits="Apply_Loan_Apply_Loan_Detail" %>

<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../../Script/uploadify/uploadify.css" type="text/css" />
    <%--<script type="text/javascript" src="../../Script/jquery-1.7.min.js"></script>--%>
     <%--<script type="text/javascript" src="../../Script/jquery-ui-1.10.1.custom.js"></script>--%>
    <script type="text/javascript" src="../../Script/uploadify/jquery.uploadify.min.js"></script>
    <script  type="text/javascript" src="../../Script/json2.js"></script>
    <style type="text/css">
        tr input {
            border: 1px solid #98b8b5;
        }
        .LoanReason {
            color: red;
            padding-left: 50px;
        }
        .btnImport 
        {
         background:url(../../images/biaoji.png) no-repeat;text-indent:99px;cursor:pointer;height: 36px;
          width: 104px;
         font-size: 0px;
        }
        .uploadify-button {
            background: #000 url("../../images/btn_save1_03.png") repeat-x scroll 0 0;
            border: 1px solid #4c68d5;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-family: 微软雅黑;
            font-weight: 700;
            height: 34px;
            overflow: hidden;
        }

        .uploadify:hover .uploadify-button {
            background: #000 url("../../images/btn_save1_03.png") repeat-x scroll 0 0;
            border: 1px solid #4c68d5;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-family: 微软雅黑;
            font-weight: 700;
            height: 34px;
            overflow: hidden;
        }

        .uploadify {
            text-indent: 0;
        }

        #ExcelTB td {
            text-align: center;
            padding: 5px;
        }
    </style>
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        //通用方法
        //打印
        function myPrint(start, end, extend) {
            //window.print();
            cMyPrint();
        }
        //上传
        function upload() {
            cUpload("<%=MainID %>", "<%=ApplyN %>"); //common_new.js
        }

        //选中下载的附件
        function checkChecked() {
            cCheckChecked("<%=gvAttach.ClientID%>"); //common_new.js
        }
        //返回
        function BackToSearch() {
            cBackToSearch("<%=Request.QueryString %>");  //common_new.js
        }

        //编辑流程
        function editflow() {
            cEditflow("<%=MainID %>");   //common_new.js
        }
        //取消签名
        function CancelSign(idc) {
            cCancelSign(idc, "<%=this.hdCancelSign.ClientID%>", "<%=this.btnCancelSign.ClientID%>");   //common_new.js
        }
        //签名事件
        function sign(e) {
            cSign(e, "<%=hdIsAgree.ClientID %>", "<%=hdSuggestion.ClientID %>", "<%=this.btnSign.ClientID %>");   //common_new.js
        }

        //签名内容绑定
        function FlowSignInit() {
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.Apply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
        }

        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>", "<%=ApplyN %>");
        }
    </script>
    <style type="text/css">
        input.readonly {
            background: rgb(227, 227, 227);
        }
    </style>
   
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>;
        //初始化
        function PageInit() {
            $("#<%=Department.ClientID %>").autocomplete({
                source: jJSON,
                select: function (event, ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
         });
            //红单去向
            IsSingleRedBind();
            //签名方法事件初始化 common_new.js
            SignFunBind();
            //分行退款方式
            IsBranchRefundBind();
            //签名数据绑定
            FlowSignInit();
           


            //产品类型绑定
            ProTypeBind();

            //代理类型数据绑定
            //  AgentTypeBind()

            //增加、修改
            //  ApplyTypeBind();

            //上传控件
            $("#uploadify").uploadify({
                'swf': '../../Script/uploadify/uploadify.swf',
                'uploader': '../../Ajax/UploadHandler.ashx?MainID=<%=MainID%>',
                //'cancelImg': '../../Script/uploadify/cancel.png',
                'buttonText': '上传放款EXCEL表',
                'queueID': 'fileQueue',
                'fileTypeExts': '*.xls; *.xlsx',
                'fileTypeDesc': '请选择xls文件',
                'auto': true,
                'multi': false,
                'width': 100,
                onDialogClose: onDialogClose,
                onCancel: onDialogClose,
                onUploadSuccess: onUploadSuccess
            });

            //Excel表格显示
            var info = $("#<%=this.hidDetail.ClientID%>").val();

            //alert(info);
            WriteDetailTB(info);
            //是否已上成交报告
            IsUpReportBind()
            //是否已签合同
            IsContractBind()

            //收款用途绑定
            RecePurposeBind();
            var IsUpReport = $("#<%=this.IsUpReport.ClientID%>").val();
            if (IsUpReport != null && IsUpReport != "")
            {
            IsReport(IsUpReport);//成交报告
            }
           
            
        }
        function RecePurposeBind()
        {
            var IsRecePurpose = $("#<%=this.IsRecePurpose.ClientID%>").val()//1售2租
            var IsRecePurposeMoney = $("#<%=this.IsRecePurposeMoney.ClientID%>").val();//选择金
            var RecePurposeMoney = $("#<%=this.RecePurposeMoney .ClientID%>").val()//元
            var RecePurposeMonth = $("#<%=this.RecePurposeMonth .ClientID%>").val()//月
            if (IsRecePurpose != null && IsRecePurpose != "") {
                if (IsRecePurpose == '1') {
                    $("#Radio10").get(0).checked = true;
                    $("#shouID input[type=radio][value=" + IsRecePurposeMoney + "]").get(0).checked = true;
                    $("#shouID input[type=radio][value=" + IsRecePurposeMoney + "]").next().next().val(RecePurposeMoney);
                }
                else if (IsRecePurpose == '2') {
                    $("#Radio21").get(0).checked = true;
                    $("#zuID .c input[type=radio][value=" + IsRecePurposeMoney + "]").get(0).checked = true;
                    $("#zuID .c input[type=radio][value=" + IsRecePurposeMoney + "]").next().val(RecePurposeMonth);
                    $("#zuID .c input[type=radio][value=" + IsRecePurposeMoney + "]").next().next().val(RecePurposeMoney);
                    $("#zuID .c input[type=radio][value=" + IsRecePurposeMoney + "]").next().next().next().val(RecePurposeMoney);
                }
            }
        }
        //上传相关
        var onDialogClose = function (queueData) { }
        var onUploadSuccess = function (file, data, response) {

            if (data == "0") {
                alert("请先登录");
                return;
            }
            var obj = eval("(" + data + ")");       //转json

            //obj.name
            readExcel(obj.name);
        }

        function readExcel(excelurl) {
            $.ajax({
                url: "ReadExcel_Handler.ashx?MainID=<%=MainID%>",
                type: "post",
                dataType: "text",
                data: { 'path': excelurl },
                success: function (info) {
                    try {

                        //alert(info);
                        WriteDetailTB(info);
                    }
                    catch (e) {
                        alert(e);
                    }
                }

            });
            return false;
        }
        function DX(Num) {
            for (i = Num.length - 1; i >= 0; i--) {
                Num = Num.replace(",", "")//替换Num中的“,”
                Num = Num.replace(" ", "")//替换Num中的空格
            }    
            if (isNaN(Num)) { //验证输入的字符是否为数字
                //alert("请检查小写金额是否正确");
                return;
            }
            //字符处理完毕后开始转换，采用前后两部分分别转换
            part = String(Num).split(".");
            newchar = "";
            //小数点前进行转化
            for (i = part[0].length - 1; i >= 0; i--) {
                if (part[0].length > 10) {
                    //alert("位数过大，无法计算");
                    return "";
                }//若数量超过拾亿单位，提示
                tmpnewchar = ""
                perchar = part[0].charAt(i);
                switch (perchar) {
                    case "0":  tmpnewchar = "零" + tmpnewchar;break;
                    case "1": tmpnewchar = "一" + tmpnewchar; break;
                    case "2": tmpnewchar = "二" + tmpnewchar; break;
                    case "3": tmpnewchar = "三" + tmpnewchar; break;
                    case "4": tmpnewchar = "四" + tmpnewchar; break;
                    case "5": tmpnewchar = "五" + tmpnewchar; break;
                    case "6": tmpnewchar = "六" + tmpnewchar; break;
                    case "7": tmpnewchar = "七" + tmpnewchar; break;
                    case "8": tmpnewchar = "八" + tmpnewchar; break;
                    case "9": tmpnewchar = "九" + tmpnewchar; break;
                }
                switch (part[0].length - i - 1) {
                    case 0: tmpnewchar = tmpnewchar; break;
                    case 1: if (perchar != 0) tmpnewchar = tmpnewchar + "十"; break;
                    case 2: if (perchar != 0) tmpnewchar = tmpnewchar + "百"; break;
                    case 3: if (perchar != 0) tmpnewchar = tmpnewchar + "千"; break;
                    case 4: tmpnewchar = tmpnewchar + "万"; break;
                    case 5: if (perchar != 0) tmpnewchar = tmpnewchar + "十"; break;
                    case 6: if (perchar != 0) tmpnewchar = tmpnewchar + "百"; break;
                    case 7: if (perchar != 0) tmpnewchar = tmpnewchar + "千"; break;
                    case 8: tmpnewchar = tmpnewchar + "亿"; break;
                    case 9: tmpnewchar = tmpnewchar + "十"; break;
                }
                newchar = tmpnewchar + newchar;
            }   
            //替换所有无用汉字，直到没有此类无用的数字为止
            while (newchar.search("零零") != -1 || newchar.search("零亿") != -1 || newchar.search("亿万") != -1 || newchar.search("零万") != -1) {
                newchar = newchar.replace("零亿", "亿");
                newchar = newchar.replace("亿万", "亿");
                newchar = newchar.replace("零万", "万");
                newchar = newchar.replace("零零", "零");      
            }
            //替换以“一十”开头的，为“十”
            if (newchar.indexOf("一十") == 0) {
                newchar = newchar.substr(1);
            }
            //替换以“零”结尾的，为“”
            if (newchar.lastIndexOf("零") == newchar.length - 1) {
                newchar = newchar.substr(0, newchar.length - 1);
            }
            return newchar;
        }
        
        //列表
        function WriteDetailTB(data) {

            if (data == null || data == "" || data == undefined) {
                return;
            }
            var obj = eval("(" + data + ")");       //转json
         
            var html = "";
            html = "<table id='ExcelTB' class='tbflows' style='width:100%' cellspacing='0' cellpadding='0'>";
            html += "<tr><th>收据编号</th><th>成交单位地址</th><th>交款人姓名</th><th>交易编号</th><th>(借)金额(元)</th><th>(贷)金额(元)</th><th>财务确认</th></tr>";
            //for(var i = 0; i < obj.length; i++)
            var money = 0;
            try {
              
                for (var i = 0; i < obj.T_OfficeAutomation_Document_Loan_Detail.length; i++) {
                  
                    html += "<tr>";
                    html += "<td>" + obj.T_OfficeAutomation_Document_Loan_Detail[i].OfficeAutomation_Document_Loan_Detail_ReceiptNum + "</td>";
                    html += "<td>" + obj.T_OfficeAutomation_Document_Loan_Detail[i].OfficeAutomation_Document_Loan_Detail_Address + "</td>";
                    html += "<td>" + obj.T_OfficeAutomation_Document_Loan_Detail[i].OfficeAutomation_Document_Loan_Detail_PaymentName + "</td>";
                    html += "<td>" + obj.T_OfficeAutomation_Document_Loan_Detail[i].OfficeAutomation_Document_Loan_Detail_TransactionNum + "</td>";
                    html += "<td>" + obj.T_OfficeAutomation_Document_Loan_Detail[i].OfficeAutomation_Document_Loan_Detail_BorrowMoney + "</td>";
                    html += "<td>" + obj.T_OfficeAutomation_Document_Loan_Detail[i].OfficeAutomation_Document_Loan_Detail_LoanMoney + "</td>";
                    html += "<td>" + obj.T_OfficeAutomation_Document_Loan_Detail[i].OfficeAutomation_Document_Loan_Detail_FinanceConf + "</td>";
                    html += "</tr>";
                    money += obj.T_OfficeAutomation_Document_Loan_Detail[i].OfficeAutomation_Document_Loan_Detail_LoanMoney;
                }
              
                html += "<tr>";
                html += "<td>合计</td>";
               html += "<td colspan='3'>"+DX(money)+" (大写)</td>";
                html += "<td colspan='3'>"+money+" 元(小写)</td>";
                html += "</tr>";
                $("#ctl00_ContentPlaceHolder1_PayeeName").val(obj.T_OfficeAutomation_Document_LoanReadExcel_PayeeName);
                $("#ctl00_ContentPlaceHolder1_PayeeBankName").val(obj.T_OfficeAutomation_Document_LoanReadExcel_PayeeBankName);
                $("#ctl00_ContentPlaceHolder1_PayeeNum").val(obj.T_OfficeAutomation_Document_LoanReadExcel_PayeeNum);
                $("#<%=this.hidDetail.ClientID%>").val(JSON.stringify(obj.T_OfficeAutomation_Document_Loan_Detail));
             
               

              
            } catch (e) {
                for (var i = 0; i < obj.length; i++) {
                    html += "<tr>";
                    html += "<td>" + obj[i].OfficeAutomation_Document_Loan_Detail_ReceiptNum + "</td>";
                    html += "<td>" + obj[i].OfficeAutomation_Document_Loan_Detail_Address + "</td>";
                    html += "<td>" + obj[i].OfficeAutomation_Document_Loan_Detail_PaymentName + "</td>";
                    html += "<td>" + obj[i].OfficeAutomation_Document_Loan_Detail_TransactionNum + "</td>";
                    html += "<td>" + obj[i].OfficeAutomation_Document_Loan_Detail_BorrowMoney + "</td>";
                    html += "<td>" + obj[i].OfficeAutomation_Document_Loan_Detail_LoanMoney + "</td>";
                    html += "<td>" + obj[i].OfficeAutomation_Document_Loan_Detail_FinanceConf + "</td>";
                    html += "</tr>";
                    money += obj[i].OfficeAutomation_Document_Loan_Detail_LoanMoney;
                  
                    }
                html += "<tr>";
                html += "<td>合计</td>";
                html += "<td colspan='3'>" + DX(money) + " (大写)</td>";
                html += "<td colspan='3'>" + money + " 元(小写)</td>";
                html += "</tr>";
                if (obj.length != undefined)
                {
                    $("#<%=this.hidDetail.ClientID%>").val(JSON.stringify(obj));
                }
              
              
            }
           
            html += "</table>";
            $("#TB").html(html);
            //autoRowSpan($("#ExcelTB").get(0), 0, 0);  //合并单元格
            //autoRowSpan($("#ExcelTB").get(0), 1, 6);  //合并单元格
            if ($("#ctl00_ContentPlaceHolder1_PayeeName").val() == "")
            {
                alert('请到excel表填写收款人名称');
            }
            if ($("#ctl00_ContentPlaceHolder1_PayeeBankName").val() == "") {
                alert('请到excel表填写收款银行及开户支行名称');
            }
            if ($("#ctl00_ContentPlaceHolder1_PayeeNum").val() == "") {
                alert('请到excel表填写收款帐号');
            }
        }
        //function autoRowSpan(tb, row, col) {
        //    var lastValue = "";
        //    var value = "";
        //    var pos = 1;
        //    for (var i = row; i < tb.rows.length; i++) {
        //        value += tb.rows[i].cells[col].innerText;
        //        if (lastValue == value) {
        //            tb.rows[i].deleteCell(col);
        //            tb.rows[i - pos].cells[col].rowSpan = tb.rows[i - pos].cells[col].rowSpan + 1;
        //            pos++;
        //        } else {
        //            lastValue = value;
        //            pos = 1;
        //        }
        //    }
        //}

        function check() {
            var flag = false;
            //return false;
            //在必填项后增加input class="REQUIRED" 项用以控制是否必填
            flag = REQUIRED_Check();    //common_new.js
            if($.trim($("#<%=Department.ClientID %>").val())=="") {
                alert("申请分行不可为空！");
                $("#<%=Department.ClientID %>").focus();
                return false;
            }
            if ($("#c7").is(':checked') == true) {
                if ($("#<%=this.txtLoReMarkes.ClientID%>").val() == "") {
                    alert("请填写放款其他原因");
                    $("#<%=this.txtLoReMarkes.ClientID%>").focus();
                    return false;
                }
            }
            if ($("#Radio13").is(':checked') == true) {
                if ($("#<%=this.SingleRedReason.ClientID%>").val() == "") {
                    alert("请填写未收回红单原因");
                    $("#<%=this.SingleRedReason.ClientID%>").focus();
                    return false;
                }
            }
            if (!flag) {
                return false;
            }
            if ($("#<%=this.Phone.ClientID%>").val().length != 11) {
                $("#<%=this.Phone.ClientID%>").focus();
                alert('只能填写11位联系电话');

                return false;
            }
            //是否已签合同
            flag = false;
            var val = "";
            $("input[name='r']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择是否已签合同");
                $("#r1").focus();
                return false;
            }
            $("#<%=this.IsContract.ClientID%>").val(val);

            //是否上成交报告
            flag1 = false;
            var val1 = "";
            $("input[name='r1']").each(function () {
                if (this.checked) {
                    flag1 = true;
                    val1 = this.value;
                }
            });
            if (!flag1) {
                alert("请选择是否已签合同");
                $("#r3").focus();
                return false;
            }
            $("#<%=this.IsUpReport.ClientID%>").val(val1);

            //放款原因
            flag = false;
            val = "";
            $("input[name='LoanReason']").each(function () {
                if (this.checked) {
                    flag = true;
                    val += this.value + "|";
                }
            });
            if (!flag) {
                alert("请选择放款原因");
                $("#c1").focus();
                return false;
            }
            if (val != "") {
                $("#<%=this.LoanReason.ClientID%>").val(val.substring(0, val.length - 1));
            }
            if ($("#<%=this.LoanReason.ClientID%>").val().indexOf('3') != -1)
            {
                if ($("#<%=this.LoanReason.ClientID%>").val().indexOf('2') == -1)
                {
                    alert("选择了补足备用金就要选退回客户");
                    $("#c1").focus();
                    return false;
                }
            }

            if ($("#r5").checked == false && $("#r6").checked == false) {
                alert("请选择收款用途");
                $("#r5").focus();
                return false;
            }
            //红单去向
            flag = false;
            var val = "";
            $("input[name='r5']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择红单去向");
                $("#Radio12").focus();
                return false;
            }
            $("#<%=this.IsSingleRed.ClientID%>").val(val);

            //分行退款方式
            flag = false;
            var val = "";
            $("input[name='r6']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择分行退款方式");
                $("#Radio14").focus();
                return false;
            }
            $("#<%=this.IsBranchRefund.ClientID%>").val(val);

            if ($("#<%=this.hidDetail.ClientID%>").val() == "") {
                alert("请上传明细");
                return false;
            }
            if ($("#<%=this.PayeeName.ClientID%>").val() == "")
            {
                alert("请填写收款人名称");
                return false;
            }
            if ($("#<%=this.PayeeBankName.ClientID%>").val() == "") {
                alert("请填写收款银行及开户支行名称");
                return false;
            }
            if ($("#<%=this.PayeeNum.ClientID%>").val() == "") {
                alert("请填写收款帐号");
                return false;
            }
            $("input[name = 'RecePurpose'] ").each(function () {
                if (this.checked) {
                    var $radio = $(this).parent().find(".c input[type=radio]:checked");
                    $("#<%=this.IsRecePurpose.ClientID%>").val($(this).val());
                    $("#<%=this.IsRecePurposeMoney.ClientID%>").val($radio.val());
                    if ($(this).next().html() == "售") {
                        // alert($(this).val());
                        //  alert($radio.val());
                        $("#<%=this.RecePurposeMoney .ClientID%>").val($radio.next().next().val());
                            // alert($radio.next().next().val());
                        }
                        else if ($(this).next().html() == "租") {
                            //  alert($(this).val());
                            //  alert($radio.val());
                            // alert($radio.next().val());
                            //alert($radio.next().next().val());
                            if ($radio.next().val() != "") {
                                $("#<%=this.RecePurposeMonth.ClientID%>").val($radio.next().val());
                                            }
                                            if ($radio.next().next().val() != "") {
                                                $("#<%=this.RecePurposeMoney .ClientID%>").val($radio.next().next().val());
                                            }
                                            if ($radio.next().next().next().val() != "") {
                                                $("#<%=this.RecePurposeMoney .ClientID%>").val($radio.next().next().next().val());
                                            }
                                        }
                                        else {
                                            return false;
                                        }

                                }

            })
            if ($("#<%=this.IsRecePurpose.ClientID%>").val() == "") {
                alert("请选择售或者租");
                return false;
            }
            if ($("#<%=this.IsRecePurposeMoney.ClientID%>").val() == "") {
                alert("请选择收款用途");
                return false;
            }
                            return true;
                        }

       //是否已上成交报告”选了“是”，则“成交报告编号”为必填项，若“是否已上成交报告”选了“否”，则“成交报告编号”、“成交总价”、“成交地址”、“客户名称也变灰（不能填写）
        function IsReport(vaule) {
            if (vaule == 0) {
             
                $("#<%=this.ReportNo.ClientID%>").attr("disabled", true)
                $("#<%=this.TotalPrice.ClientID%>").val("");
                $("#<%=this.CustomerName.ClientID%>").val("");
                $("#<%=this.Address.ClientID%>").val("");
                $("#<%=this.ReportNo.ClientID%>").val("");
            }
            else if (vaule == 1)
            {
                $("#<%=this.ReportNo.ClientID%>").attr("disabled", false)
               
            }
                
    }
    //收款原因绑定
    function ProTypeBind() {

        var LoanReason = $("#<%=this.LoanReason.ClientID%>").val();
            if (LoanReason == "" || LoanReason == "null" || LoanReason == undefined) {
                $("input[name='LoanReason']").each(function () {
                    this.checked = false;
                    $(".LoanReason" + $(this).val()).hide()
                });

                return;
            }

            var array = LoanReason.split("|");
            for (var i = 0; i < array.length; i++) {
                $r = $("input[name='LoanReason'][value=" + array[i] + "]");
                if ($r != undefined) {

                    $(".LoanReason" + array[i]).show();
                    $r.get(0).checked = true;
                }
            }
            $("input[name='LoanReason']").each(function () {
                if (this.checked == false) {
                    $(".LoanReason" + $(this).val()).hide()
                }
            });

        }




        //是否已签合同
        function IsContractBind() {
            var IsContract = $("#<%=this.IsContract.ClientID%>").val();
            if (IsContract == "") {
                $("input[name='r']").each(function () {
                    this.checked = false;
                    $("#<%=this.ReportNo.ClientID%>").attr("disabled", true)
                });
                return;
            }
            else {
                $(".IsContractClass input[type=radio][value=" + IsContract + "]").get(0).checked = true;
                if (IsContract == 1) {
                    $("#<%=this.ReportNo.ClientID%>").attr("disabled", false)
                } else {
                    $("#<%=this.ReportNo.ClientID%>").attr("disabled", true)
                }
            }

        }
        //是否已上成交报告
        function IsUpReportBind() {
            var IsUpReport = $("#<%=this.IsUpReport.ClientID%>").val();
            if (IsUpReport == "") {
                $("input[name='r1']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $(".IsUpReportClass input[type=radio][value=" + IsUpReport + "]").get(0).checked = true;
               
            }
        }
        //是否红单去向
        function IsSingleRedBind() {
            var IsSingleRed = $("#<%=this.IsSingleRed.ClientID%>").val();

            if (IsSingleRed == "") {
                $("input[name='r5']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $(".IsSingleRedClass input[type=radio][value=" + IsSingleRed + "]").get(0).checked = true;

            }
        }
        //分行退款方式
        function IsBranchRefundBind() {
            var IsBranchRefund = $("#<%=this.IsBranchRefund.ClientID%>").val();

            if (IsBranchRefund == "") {
                $("input[name='r6']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $(".IsBranchRefundClass input[type=radio][value=" + IsBranchRefund + "]").get(0).checked = true;

            }
        }

        //收款用途 租 售
        function IsRecePurposeBind() {
            var IsRecePurpose = $("#<%=this.IsRecePurpose.ClientID%>").val();
            if (IsRecePurpose == "") {
                $("input[name='r2']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $r1 = $("#r5" + IsRecePurpose);
                if ($r1 != undefined) {
                    $r1.get(0).checked = true;
                }
            }
        }


        //暂时保存时获取单选按钮，产品类型、代理类型的值
        function getvalue() {
            var val = "";
            var val1 = "";
            var valprotype = "";
            var valagenttype = "";
            //已签合同
            $("input[name='r']").each(function () {
                if (this.checked) {
                    val = this.value;
                }
            });
            $("#<%=this.IsContract.ClientID%>").val(val);
            //已上成交报告
            $("input[name='r1']").each(function () {
                if (this.checked) {
                    val1 = this.value;
                }
            });
            $("#<%=this.IsUpReport.ClientID%>").val(val1);

            //放款原因
            $("input[name='LoanReason']").each(function () {
                if (this.checked) {
                    valprotype += this.value + "|";
                }
            });
            $("#<%=this.LoanReason.ClientID%>").val(valprotype.substring(0, valprotype.length - 1));

            //收款用途 租售
            $("input[name='r2']").each(function () {
                if (this.checked) {
                    val = this.value;
                }
            });
            $("#<%=this.IsRecePurpose.ClientID%>").val(val);

            //收款用途 1 诚意金 2 订金 3 佣金 4 保证金 5 租金 6 缴税费杂费 7 其他
            $("input[name='r3']").each(function () {
                if (this.checked) {
                    val = this.value;
                }
            });
            $("#<%=this.IsRecePurposeMoney.ClientID%>").val(val);



        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>放款申请表</h1>
            
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">交易编号(excel生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td class="auto-style4" >申请分行：</td>
                    <td class="tl PL10" style="width: 30%">
                        <%--<asp:Label ID="ReceiveDepartment" runat="server" Text="Label"></asp:Label>--%>
                       <asp:TextBox ID="Department" runat="server" Width="190px"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                        <%--<asp:Label ID="Department" runat="server" Text="Label"></asp:Label>--%>
                    </td>
                    <td class="auto-style4">填写日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="ApplyDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">申请人</td>
                    <td class="tl PL10">
                        <asp:Label ID="Apply" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4"><span style="color: red">*</span>联系电话</td>
                    <td class="tl PL10">
                        <%--<asp:Label ID="Apply1" runat="server" ></asp:Label>--%>
                        <asp:TextBox ID="Phone" runat="server" requiredmes="请填写联系电话" onblur="checkPhone(this)"></asp:TextBox>
                        <span style="color: red; display:none" id="checkPho">联系电话必须11位</span>
                    </td>
                    <script type="text/javascript">
                        function checkPhone(e)
                        {
                            if (e.value.length != 11) {
                                $("#checkPho").show();
                            }
                            else {
                                $("#checkPho").hide();
                            }
                            
                        }
                    </script>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; text-indent: 15px">
                        <div id="TB"></div>

                       <%-- <p>请按此格式（<a style="color: blue" href="temp/Apply-Loan.xls">EXCEL版空白详细表</a>)下载，编辑后 为附件，将自动导入 </p>--%>
                        <p>请从代收款系统中导出放款申请EXCEL表，并将该表上传</p>
                        <%--                        <p>备注：财务部须对以上数据进行复核。</p>--%>
                        <p style="padding-left: 15px"><span id="uploadify"></span></p>
                        <asp:HiddenField ID="hidDetail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; text-indent: 15px">
                        <p>
                            <span class="IsContractClass">
                                <label for="r1"><span style="color: red">*</span>是否已签合同：</label><input type="radio" id="r2" name="r" value="1" /><label for="r2">是</label><input type="radio" id="r1" name="r" value="0" /><label for="r1">否</label></span>
                            <asp:HiddenField ID="IsContract" runat="server" />
                            <span class="IsUpReportClass">
                                <label for="r1"><span style="color: red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*</span>是否已上成交报告：</label><input type="radio" id="r4" name="r1" value="1" onclick="IsReport($(this).val())" /><label for="r4">是</label><input type="radio" id="r3" onclick="    IsReport($(this).val())" name="r1" value="0" /><label for="r3">否</label></span>
                            <asp:HiddenField ID="IsUpReport" runat="server" />

                        </p>
                        <p>
                            <label for="1">成交编号：</label><asp:TextBox runat="server" ID="ReportNo" Width="120px" onblur="getReport(this)"></asp:TextBox>
                            <label for="1">成交总价:</label><asp:TextBox runat="server" ID="TotalPrice" Width="90px" CssClass="readonly"></asp:TextBox>
                            <label for="1">客户名称：</label>
                            <asp:TextBox runat="server" ID="CustomerName" Width="140px" CssClass="readonly"></asp:TextBox>

                        </p>
                        <p>
                            <label for="1">成交地址：</label><asp:TextBox runat="server" ID="Address" CssClass="readonly" Width="230px"></asp:TextBox>
                        </p>
                     
                        <p>
                           <span style="color: red">*</span>放款原因:
                            <input type="checkbox" id="c1" value="1" name="LoanReason" /><label for="c1">转交业主</label>
                            <input type="checkbox" id="c2" value="2" name="LoanReason" /><label for="c2">退回客户</label>
                            <input type="checkbox" id="c3" value="3" name="LoanReason" /><label for="c3">补足备用金</label>
                            <input type="checkbox" id="c4" value="4" name="LoanReason" /><label for="c4">借支</label><br/>
                            <input type="checkbox" style=" margin-left:80px;"  id="c5" value="5" name="LoanReason" /><label for="c5">财务部代转佣</label>
                            <input type="checkbox" id="c6" value="6" name="LoanReason" /><label for="c6">挞订转佣</label>
                            <input type="checkbox" id="c8" value="8" name="LoanReason" /><label for="c8">转开收据</label>
                            <input type="checkbox" id="c7" value="7" name="LoanReason" /><label for="c7">其他</label> <asp:TextBox ID="txtLoReMarkes" runat="server" name="LoanReasonRemarkes" Width="80px"></asp:TextBox>
                            <asp:HiddenField ID="LoanReason" runat="server" />
                        </p>
                        <p class="LoanReason">
                            <span class="LoanReason0"></span>
                            <br />
                            <span class="LoanReason1">a. 转交业主：需上传收据、业主直接收客款时签署的收款收据</span><br />
                            <span class="LoanReason2">b. 退回客户：需上传收据、交款人签署的划委、交款人身份证复印件、交款人银行卡复印件</span><br />
                            <span class="LoanReason3">c. 退回客户+补足备用金：需上传收据</span><br />
                            <span class="LoanReason4">d. 借支：需上传上传代收款收据第一联</span><br />
                            <span class="LoanReason5">e. 财务部代转佣：需上传收据、发票、合同</span><br />
                            <span class="LoanReason6">f. 挞订转佣: 需上传收据、发票</span><br />
                        </p>
                        <p>
                            <span style="color: red">*</span>收款用途:
                            <input type="radio" id="Radio10" name="RecePurpose" value="1" /><label for="Radio10">售</label>
                            <span class="c" id="shouID">
                                <input type="radio" id="Radio11" name="r3" value="1" /><label for="Radio11">诚意金</label>
                                <asp:TextBox ID="TextBox11" runat="server" name="RecePurposeMoney" Width="50px"></asp:TextBox>元
                            <input type="radio" id="Radio16" name="r3" value="2" /><label for="Radio16">订金</label>
                                <asp:TextBox ID="TextBox13" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元
                            <input type="radio" id="Radio20" name="r3" value="3" /><label for="Radio20">佣金</label>
                                <asp:TextBox ID="TextBox15" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元                      
                            </span>
                        </p>
                        <p style="margin-left: 60px" id="zuID">
                            <input type="radio" id="Radio21" name="RecePurpose" value="2" /><label for="r6">租</label>

                            <span class="c">
                                <input type="radio" id="Radio22" name="r4" value="1" /><label for="r10">诚意金</label>
                                <asp:TextBox ID="TextBox16" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元<span></span>
                                <input type="radio" id="Radio23" name="r4" value="2" /><label for="r11">订金</label>
                                <asp:TextBox ID="TextBox17" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元<span></span>
                                <input type="radio" id="Radio24" name="r4" value="3" /><label for="r12">佣金</label>
                                <asp:TextBox ID="TextBox18" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元<span></span>
                                <br />
                            </span>
                            <span style="margin-left: 50px" class="c">
                                <input type="radio" id="Radio25" name="r4" value="4" /><asp:TextBox ID="TextBox19" name="RecePurposeMonth" runat="server" Width="30px"></asp:TextBox><label for="r13">个月保证金</label>
                                <asp:TextBox ID="TextBox20" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元
                                   <input type="radio" id="Radio26" name="r4" value="5" /><asp:TextBox ID="TextBox21" name="RecePurposeMonth" runat="server" Width="30px"></asp:TextBox><label for="r14">个月租金</label>
                                <asp:TextBox ID="TextBox22" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元 
                                    <br />
                            </span>
                            <span style="margin-left: 50px" class="c">
                                <input type="radio" id="Radio27" name="r4" value="6" /><label for="r15">代缴税费杂费</label>
                                <asp:TextBox ID="TextBox23" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元
                                    <input type="radio" id="Radio28" name="r4" value="7" /><label for="r16">其他</label>
                                <asp:TextBox ID="TextBox24" name="RecePurposeMoney" runat="server" Width="50px"></asp:TextBox>元           
                            </span>


                        </p>

                        <script type="text/javascript">
                   
                        </script>
                        <asp:HiddenField ID="IsRecePurposeMoney" runat="server" />
                        <asp:HiddenField ID="IsRecePurpose" runat="server" />
                        <asp:HiddenField ID="RecePurposeMoney" runat="server" />
                        <asp:HiddenField ID="RecePurposeMonth" runat="server" />
                        <p>
                            <span class="IsSingleRedClass"><span style="color: red">*</span>红单去向: 
                           <input type="radio" id="Radio12" name="r5" value="1" /><label for="Radio12">已收回红单</label>
                                <input type="radio" id="Radio13" name="r5" value="2" /><label for="Radio13">未收回红单，原因:</label>
                                <asp:TextBox ID="SingleRedReason" runat="server" Width="50px"></asp:TextBox>
                                <asp:HiddenField ID="IsSingleRed" runat="server" />
                            </span>
                        </p>
                        <p>
                            <span class="IsBranchRefundClass"><span style="color: red">*</span>分行退款方式: 
                           <input type="radio" id="Radio14" name="r6" value="1" /><label for="Radio14">转账</label>
                                <input type="radio" id="Radio15" name="r6" value="2" /><label for="Radio15">现金</label>
                                <asp:HiddenField ID="IsBranchRefund" runat="server" />
                            </span>
                        </p>
                        <p>
                            收款人名称:<asp:TextBox Width="250px" ID="PayeeName" runat="server" CssClass="readonly"></asp:TextBox>
                        </p>
                        <p>
                            收款银行及开户支行名称:<asp:TextBox ID="PayeeBankName" Width="250px" runat="server" CssClass="readonly"></asp:TextBox>
                        </p>
                        <p>
                            收款帐号:<asp:TextBox ID="PayeeNum" runat="server" Width="250px" CssClass="readonly"></asp:TextBox>
                        </p>
                    </td>
                </tr>

            </table>
            <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0">
                <tr class="noborder" style="height: 85px;" idx="2">
                    <td class="auto-style2">申请人(分行行政助理)：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" /><label class="l signyes">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="3">
                    <td class="auto-style2">分行主管意见</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" /><label class="l signyes">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="5">
                    <td class="auto-style2">区域负责人意见：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" /><label class="l signyes">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="6">
                    <td class="auto-style2">财务部意见：收款确认人意见：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree3" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree3" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio8" value="2" class="cOther" name="agree3" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="通知" onclick="tongzhu(this,6)" />
                        </div>
                       <%-- <div class="fieldtext1">
                            <label>财务部备注1：</label><asp:TextBox runat="server" ID="txtFinanceRemarks" Width="70%"></asp:TextBox>
                        </div>--%>
                        <div class="fieldtext">
                            <textarea rows="2"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
            <%--   <tr class="noborder" style="height: 85px;" idx="7">
                    <td class="auto-style2" rowspan="3">法律部</td>
                    <td class="tl PL10" style="display:none">
                        <div class="fieldradio">
                            <label>法律部一审：</label> <input type="radio" value="1" name="agree4" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree4" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio4" value="2" class="cOther" name="agree4" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="送审" onclick="tongzhu(this,7)" />
                        </div>
                        <div class="fieldtext1">
                         
                        </div>
                        <div class="fieldtext">
                            <textarea rows="2"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>--%>
               <tr class="noborder" style="height: 85px;" idx="8">
                   <td class="auto-style2" rowspan="2">法律部</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                             <label>法律部一审：</label>
                            <input type="radio" value="1" name="agree5" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree5" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio5" value="2" class="cOther" name="agree5" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="送审" onclick="tongzhu(this,8)" />
                        </div>
                        <div class="fieldtext1">
                         
                        </div>
                        <div class="fieldtext">
                            <textarea rows="2"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                 <tr class="noborder" style="height: 85px;" idx="9">
                    <td class="tl PL10">
                        <div class="fieldradio">
                             <label>法律部负责人：</label>
                            <input type="radio" value="1" name="agree6" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree6" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio6" value="2" class="cOther" name="agree6" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="送审" onclick="tongzhu(this,9)" />
                        </div>
                        <div class="fieldtext1">
                         
                        </div>
                        <div class="fieldtext">
                            <textarea rows="2"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
            
                <asp:HiddenField runat="server" ID="hfOpinion" />
                <asp:HiddenField runat="server" ID="hfMainID" />
                <asp:HiddenField runat="server" ID="hfIdx" />
               
            <tr class="noborder" style="height: 85px;" idx="10">
                    <td class="auto-style2" rowspan="4">财务部</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                               <%--<label>财务部备注2：</label><asp:TextBox ID="txtFinanceRemarks2" runat="server" Width="70%"></asp:TextBox><br/>--%>
                            <label>财务部一审：</label> <input type="radio" value="1" name="agree7" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree7" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio1" value="2" class="cOther" name="agree7" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="送审" onclick="tongzhu(this,10)" />
                        </div>
                        <div class="fieldtext1">
                         
                        </div>
                        <div class="fieldtext">
                            <textarea rows="2"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
               <tr class="noborder" style="height: 85px;" idx="11">
                    <td class="tl PL10">
                        <div class="fieldradio">
                             <label>财务部二审：</label>
                            <input type="radio" value="1" name="agree8" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree8" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio2" value="2" class="cOther" name="agree8" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="送审" onclick="tongzhu(this,11)" />
                        </div>
                        <div class="fieldtext1">
                         
                        </div>
                        <div class="fieldtext">
                            <textarea rows="2"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                 <tr class="noborder" style="height: 85px;" idx="12">
                    <td class="tl PL10">
                        <div class="fieldradio">
                             <label>财务部三审：</label>
                            <input type="radio" value="1" name="agree9" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree9" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio3" value="2" class="cOther" name="agree9" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="送审" onclick="tongzhu(this,12)" />
                        </div>
                        <div class="fieldtext1">
                         
                        </div>
                        <div class="fieldtext">
                            <textarea rows="2"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                     <tr class="noborder" style="height: 85px;" idx="13">
                    <td class="tl PL10">
                        <div class="fieldradio">
                             <label>财务负责人：</label>
                            <input type="radio" value="1" name="agree10" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree10" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio7" value="2" class="cOther" name="agree10" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="送审" onclick="tongzhu(this,13)" />
                        </div>
                        <div class="fieldtext1">
                         
                        </div>
                        <div class="fieldtext">
                            <textarea rows="2"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
            <!--打印正文结束-->
        </div>
            <script type="text/javascript">
                //其他意见
                $("#tbflows .cOther").click(function () {
                    if (this.checked) {
                        var $button = $(this).parent().parent().find(".fieldbtn input[type=button]");
                        if ($button.is(":visible")) {
                            $button.parent().siblings().find(".songShenbtn").show();
                        }
                    }
                })

                function tongzhu(e, idx) {

                    //alert($(e).val());
                    var $textarea = $(e).parent().parent().find(".fieldtext").children().first()
                    if ($textarea.val() != "") {
                        var MainID = $("#<%=hfMainID.ClientID%>").val();
                         var textarea = $textarea.val();
                         //   alert($textarea.val());
                         $.ajax({
                             url: "Mail_Handler.ashx",
                             type: "post",
                             dataType: "text",
                             data: "action=sendMail&MainId=" + MainID + "&textarea=" + textarea + "&EmployeeName=" + "<%=EmployeeName%>" + "&EmployeeID=" + "<%=EmployeeID%>" + "&idx=" + idx,
                                success: function (info) {
                                    if (info != "fail") {
                                        alert('成功通知申请人');

                                    }
                                    else {
                                        alert('通知失败');

                                    }
                                }
                            })
                        }
                        else {
                            alert('请输入意见');
                        }
                     }

                </script>
        <div class="noprint">
            <asp:GridView ID="gvAttach" CssClass="gvAttach" runat="server" BackColor="White" Style="clear: both; margin-top: 3px;" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="false" ForeColor="Black" GridLines="Vertical" OnRowCommand="gvAttach_RowCommand">
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
                <p></p>
            <%--    <asp:Button runat="server" CssClass="btnImport" ID="btnImport" Text="标记导出" OnClick="btnImport_Click"/>--%>
                <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClientClick="return check();" OnClick="btnSave_Click" Visible="False" />
<%--                <asp:Button runat="server" ID="btnTemp" Text="暂时保存" OnClick="btnTemp_Click" OnClientClick="return getvalue();" CssClass="commonbtn" />--%>
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClientClick="BackToSearch();return false;" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />
                <input type="hidden" id="hdDetail2" runat="server" />
                <input type="hidden" id="hdLogisticsFlow" runat="server" />
                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
            </div>
            <p></p>
            <p></p>
        </div>
    </div>
    <script type="text/javascript">
        PageInit();
    </script>
    <script type="text/javascript">

     

            ////禁止输入
            $("input[name='RecePurpose']").click(function () {
                var IsRecePurpose = $(this).val()
                if (IsRecePurpose == 1) {
                    $("#zuID .c input[type=radio]").each(function (i) {
                        $(this).get(0).checked = false;
                        $(this).get(0).disabled = true;
                    })
                    $("#shouID  input[type=radio]").each(function (i) {
                        $(this).get(0).checked = false;
                        $(this).get(0).disabled = false;
                    })
                    $("#zuID .c input[type=text]").val("");
                    $("#zuID .c input[type=text]").attr("disabled", true)
                    $("#shouID input[type=text]").attr("disabled", false)
                }
                else if (IsRecePurpose == 2) {
                    $("#shouID input[type=radio]").each(function (i) {
                        $(this).get(0).checked = false;
                        $(this).get(0).disabled = true;
                    })
                    $("#zuID .c input[type=radio]").each(function (i) {
                        $(this).get(0).checked = false;
                        $(this).get(0).disabled = false;
                    })
                    $("#shouID input[type=text]").val("");
                    $("#shouID input[type=text]").attr("disabled", true)
                    $("#zuID .c input[type=text]").attr("disabled", false)
                }
            })
            $("input[name='LoanReason']").click(function () {
                var LoanReason = $(this).val()
                if ($(this).get(0).checked) {
                    $(".LoanReason" + LoanReason).show();
                } else {
                    if (LoanReason == 5 || LoanReason == 6) {
                        $("#<%=this.PayeeName.ClientID%>").val('')
                        $("#<%=this.PayeeBankName.ClientID%>").val('')
                        $("#<%=this.PayeeNum.ClientID%>").val('')
                    }
                    $(".LoanReason" + LoanReason).hide();
                }
                $("input[name='LoanReason']").each(function () {
                    var LoanReasonCheck = $(this).val()
                    if ($(this).get(0).checked) {
                        if (LoanReasonCheck == 5 || LoanReasonCheck == 6) {
                            $("#<%=this.PayeeName.ClientID%>").val('广东中原地产代理有限公司')
                            $("#<%=this.PayeeBankName.ClientID%>").val('中国建设银行广东省广州市仓边路支行')
                            $("#<%=this.PayeeNum.ClientID%>").val('44001420303051684025')
                        }
                    }
                })

            })
            function getReport(n) {
                $.ajax({
                    url: "/Ajax/CCAI_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: "action=getReport&code=" + n.value,
                    success: function (info) {
                        if (info != "fail") {
                            var infos = info.split("|");
                            $("#<%=TotalPrice.ClientID%>").val(infos[0]);
                            $("#<%=CustomerName.ClientID%>").val(infos[1]);
                            $("#<%=Address.ClientID%>").val(infos[2]);

                        }
                        else {
                            $("#<%=TotalPrice.ClientID%>").val("");
                            $("#<%=CustomerName.ClientID%>").val("");
                            $("#<%=Address.ClientID%>").val("");

                        }
                    }
                })
            }
       
    </script>

    <%=SbJs.ToString() %>
</asp:Content>
