<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_LinkageCoordination_Detail.aspx.cs" Inherits="Apply_LinkageCoordination_Apply_LinkageCoordination_Detail" %>

<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>
        $(function () {

            $("#txtApplyDate").datepicker();

            var pageType = $("#hidPageType").val();
            if (pageType == "Inservice") {
                //初始化分行智能匹配
                $("#txtInserviceDeptment").autocomplete({
                    source: jJSON,
                    select: function (event, ui) {
                        //debugger;
                        $("#txtInserviceDeptment").val(ui.item.id);
                        $("#hidDeptID").val(ui.item.id);
                        GetManagerByDeptID($("#hidDeptID").val());
                    }
                });

                //时间控件
                $("#txtInserviceEnterDate").datepicker();
            }
            else if (pageType == "Dimission") {
                //时间控件
                $("#txtDimissionLastDate").datepicker();
                $("#txtDimissionApplyDate").datepicker();
                $("input[name='DimissionType']").click(function () {
                    var checked1 = $("#rbtnDimissionType1").prop("checked");
                    var checked2 = $("#rbtnDimissionType2").prop("checked");

                    if (checked1) {
                        $("#hidDimissionType").val("1");
                    }

                    if (checked2) {
                        $("#hidDimissionType").val("2");
                    }

                })

                $("input[name='DimissionReason']").click(function () {
                    var checked1 = $("#rbtDimissionReason1").prop("checked");
                    var checked2 = $("#rbtDimissionReason2").prop("checked");
                    var checked3 = $("#rbtDimissionReason3").prop("checked");
                    var checked4 = $("#rbtDimissionReason4").prop("checked");
                    var checked5 = $("#rbtDimissionReason5").prop("checked");

                    if (checked1) {
                        $("#hidDimissionReason").val("1");
                    }

                    if (checked2) {
                        $("#hidDimissionReason").val("2");
                    }

                    if (checked3) {
                        $("#hidDimissionReason").val("3");
                    }

                    if (checked3) {
                        $("#hidDimissionReason").val("4");
                    }

                    if (checked5) {
                        //$("#txtDimissionReason5").show();
                        $("#hidDimissionReason").val("5");
                        $("#txtDimissionReason5").css("visibility", "visible");
                    }
                    else {
                        //$("#txtDimissionReason5").hide();
                        $("#hidDimissionReason").val("");
                        $("#txtDimissionReason5").css("visibility", "hidden");
                    }
                })

            }
            else if (pageType == "PersonalChange") {
                //时间控件
                $("#txtPersonalChangeEffectiveDate").datepicker();

                $("input[name='PersonalChangeType']").click(function () {
                    var checked1 = $("#ckbPersonalChangeType1").prop("checked");
                    var checked2 = $("#ckbPersonalChangeType2").prop("checked");
                    var checked3 = $("#ckbPersonalChangeType3").prop("checked");
                    var checked4 = $("#ckbPersonalChangeType4").prop("checked");
                    var checked5 = $("#ckbPersonalChangeType5").prop("checked");
                    var checked6 = $("#ckbPersonalChangeType6").prop("checked");
                    var checked7 = $("#ckbPersonalChangeType7").prop("checked");
                    var checked8 = $("#ckbPersonalChangeType8").prop("checked");
                    var temp = "";
                    if (checked1) temp += "1|";
                    if (checked2) temp += "2|";
                    if (checked3) temp += "3|";
                    if (checked4) temp += "4|";
                    if (checked5) temp += "5|";
                    if (checked6) temp += "6|";
                    if (checked7) temp += "7|";

                    if (checked8) {
                        temp += "8|";
                        $("#txtPersonalChangeType8").css("visibility", "visible");
                    }
                    else {
                        //temp.replace("8|", "");
                        $("#txtPersonalChangeType8").css("visibility", "hidden");
                    }

                    temp = temp.substr(0, temp.lastIndexOf("|"));

                    $("#hidPersonalChangeType").val(temp);

                })
            }
        });

        //初始化
        //function PageInit() {
        //    //签名方法事件初始化 common_new.js
        //    SignFunBind();

        //    //签名数据绑定
        //    FlowSignInit();

        //    //时间控件
        //    //$("#txtStartDate").datepicker();
        //    //$("#txtEndDate").datepicker();
        //    //$("#txtReimbursementDate").datepicker();


        //}

        Check = function () {
            var data = "";
            var flag = true;
            var pageType = $("#hidPageType").val();

            if (pageType == "Inservice") {

                if ($.trim($("#txtInserviceDeptment").val()) == "") {
                    alert("请填写部门分行");
                    $("#txtInserviceDeptment").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtInservicePosition").val()) == "") {
                    alert("请填写职位名称");
                    $("#txtInservicePosition").focus();
                    flag = false;
                    return;
                }

                var temp = $.trim($("#sbInservicePosGrade").find("option:selected").val());
                if (temp == "--请选择") {
                    alert("请选择职等名称");
                    $("#txtInservicePosition").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtInserviceBasicSalary").val()) == "") {
                    alert("请填写基本薪酬");
                    $("#txtInserviceBasicSalary").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtInserviceEnterDate").val()) == "") {
                    alert("请填写入职日期");
                    $("#txtInserviceEnterDate").focus();
                    flag = false;
                    return;
                }
                temp = $.trim($("#sbInserviceEccRole").find("option:selected").val());
                if (temp == "--请选择") {
                    alert("请选择计佣角色");
                    $("#sbInserviceEccRole").focus();
                    flag = false;
                    return;
                }
                temp = $.trim($("#sbInserviceWorkNature").find("option:selected").val());
                if (temp == "--请选择") {
                    alert("请选择工作性质");
                    $("#sbInserviceWorkNature").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtInserviceLastDimissionComm").val()) == "") {
                    alert("请填写该人员最近一次离职前三个月业绩，若没有则填“0”");
                    $("#txtInserviceLastDimissionComm").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtInserviceRelationShip").val()) == "") {
                    alert("请填写亲属关系，若没有则填“无”");
                    $("#txtInserviceRelationShip").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtInserviceOtherComm").val()) == "") {
                    alert("请填写行家业绩，若没有则填“0”");
                    $("#txtInserviceOtherComm").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtInserviceZSSupervisor").val()) == "") {
                    alert("请填写直属主管");
                    $("#txtInserviceZSSupervisor").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtInserviceLSSupervisor").val()) == "") {
                    alert("请填写隶属主管");
                    $("#txtInserviceLSSupervisor").focus();
                    flag = false;
                    return;
                }

                else {
                    data += $.trim($("#txtInserviceDeptment").val())
                        + "&&" + $.trim($("#txtInservicePosition").val())
                        + "&&" + $.trim($("#sbInservicePosGrade").find("option:selected").val())
                        + "&&" + $.trim($("#txtInserviceBasicSalary").val())
                        + "&&" + $.trim($("#txtInserviceEnterDate").val())
                        + "&&" + $.trim($("#sbInserviceEccRole").find("option:selected").val())
                        + "&&" + $.trim($("#sbInserviceWorkNature").find("option:selected").val())
                        + "&&" + $.trim($("#txtInserviceLastDimissionComm").val())
                        + "&&" + $.trim($("#txtInserviceRelationShip").val())
                        + "&&" + $.trim($("#txtInserviceOtherComm").val())
                        + "&&" + $.trim($("#txtInserviceZSSupervisor").val())
                        + "&&" + $.trim($("#txtInserviceLSSupervisor").val())
                        + "&&" + $.trim($("#txtInserviceRemark").val()) + "||";
                }

                if (flag) {
                    data = data.substr(0, data.length - 2);
                    $("#hidDetail").val(data);

                }
                else {
                    return false;
                }
            }


            if (pageType == "Dimission") {

                if ($.trim($("#hidDimissionType").val()) == "") {
                    alert("请选择离职类别");
                    $("#rbtnDimissionType1").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#hidDimissionReason").val()) == "") {
                    alert("请选择离职原因");
                    $("#rbtnDimissionType1").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtDimissionApplyDate").val()) == "") {
                    alert("请选择提交辞职申请日期");
                    $("#txtDimissionApplyDate").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtDimissionLastDate").val()) == "") {
                    alert("请选择最后出勤日期");
                    $("#txtDimissionLastDate").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtDimissionZSSupervisor").val()) == "") {
                    alert("请填写直属主管");
                    $("#txtDimissionZSSupervisor").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtDimissionLSSupervisor").val()) == "") {
                    alert("请填写隶属主管");
                    $("#txtDimissionLSSupervisor").focus();
                    flag = false;
                    return;
                }

                else {
                    data += $.trim($("#txtDimissionDeptment").val())
                        + "&&" + $.trim($("#txtDimmissionPosition").val())
                        + "&&" + $.trim($("#txtDimmissionPosGrade").val())
                        + "&&" + $.trim($("#txtDimmissionEnterDate").val())
                        + "&&" + $.trim($("#hidDimissionType").val())
                        + "&&" + $.trim($("#hidDimissionReason").val())
                        + "&&" + $.trim($("#txtDimissionReason5").val())
                        + "&&" + $.trim($("#txtDimissionApplyDate").val())
                        + "&&" + $.trim($("#txtDimissionLastDate").val())
                        + "&&" + $.trim($("#txtDimissionZSSupervisor").val())
                        + "&&" + $.trim($("#txtDimissionLSSupervisor").val())
                        + "&&" + $.trim($("#txtDimissionRemark").val()) + "||";
                }

                if (flag) {
                    data = data.substr(0, data.length - 2);
                    $("#hidDetail").val(data);

                }
                else {
                    return false;
                }
            }

            if (pageType == "PersonalChange") {

                if ($.trim($("#txtPersonalChangePositionNew").val()) == "") {
                    alert("请填写职位名称");
                    $("#txtPersonalChangePositionNew").focus();
                    flag = false;
                    return;
                }
                var temp = $.trim($("#sbPersonalChangePosGradeNew").find("option:selected").val());
                if (temp == "--请选择") {
                    alert("请选择职等名称");
                    $("#sbPersonalChangePosGradeNew").focus();
                    flag = false;
                    return;
                }
                temp = $.trim($("#txtPersonalChangeBasicSalaryNew").val());
                if ($.trim($("#txtPersonalChangeBasicSalaryNew").val()) == "" || isNaN(temp)) {
                    alert("请填写正确格式的基本工资");
                    $("#txtPersonalChangeBasicSalaryNew").focus();
                    flag = false;
                    return;
                }

                if ($.trim($("#txtPersonalChangeZSSupervisorNew").val()) == "") {
                    alert("请填写调动后直属主管");
                    $("#txtPersonalChangeZSSupervisorNew").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtPersonalChangeLSSupervisorNew").val()) == "") {
                    alert("请填写调动后隶属主管");
                    $("#txtPersonalChangeLSSupervisorNew").focus();
                    flag = false;
                    return;
                }
                temp = $.trim($("#sbPersonalChangeEccRoleNew").find("option:selected").val());
                if (temp == "--请选择") {
                    alert("请选择调动后计佣角色");
                    $("#sbPersonalChangeEccRoleNew").focus();
                    flag = false;
                    return;
                }
                temp = $.trim($("#sbPersonalChangeWorkNatureNew").find("option:selected").val());
                if (temp == "--请选择") {
                    alert("请选择调动后工作性质");
                    $("#sbPersonalChangeWorkNatureNew").focus();
                    flag = false;
                    return;
                }
                if ($.trim($("#txtPersonalChangeEffectiveDate").val()) == "") {
                    alert("请填写调动生效日期");
                    $("#txtPersonalChangeEffectiveDate").focus();
                    flag = false;
                    return;
                }

                if ($.trim($("#hidPersonalChangeType").val()) == "") {
                    alert("请勾选变动类型");
                    $("#ckbPersonalChangeType1").focus();
                    flag = false;
                    return;
                }

                else {
                    data += $.trim($("#txtDimissionDeptment").val())
                        + "&&" + $.trim($("#txtDimmissionPosition").val())
                        + "&&" + $.trim($("#txtDimmissionPosGrade").val())
                        + "&&" + $.trim($("#txtDimmissionEnterDate").val())
                        + "&&" + $.trim($("#hidDimissionType").val())
                        + "&&" + $.trim($("#hidDimissionReason").val())
                        + "&&" + $.trim($("#txtDimissionReason5").val())
                        + "&&" + $.trim($("#txtDimissionApplyDate").val())
                        + "&&" + $.trim($("#txtDimissionLastDate").val())
                        + "&&" + $.trim($("#txtDimissionZSSupervisor").val())
                        + "&&" + $.trim($("#txtDimissionLSSupervisor").val())
                        + "&&" + $.trim($("#txtDimissionRemark").val()) + "||";
                }

                if (flag) {
                    data = data.substr(0, data.length - 2);
                    $("#hidDetail").val(data);

                }
                else {
                    return false;
                }
            }

        }

        GetManagerByDeptID = function (deptid) {
            $.post("../../Ajax/HR_Handler.ashx?rn=" + Math.random() + "", { action: "getHRTreeByDepartmentID", departmentid: deptid }, function (data) {
                //debugger;
                //2033|苏新晴|0000
                var result = data.split("|");
                var pageType = $("#hidPageType").val();
                if (pageType == "Inservice") {
                    $("#txtInserviceZSSupervisor").val(result[1]);
                    $("#txtInserviceLSSupervisor").val(result[1]);
                }
                else if (pageType == "Dimission") {
                    //时间控件
                    $("#txtDimissionLastDate").datepicker();
                    $("#txtDimissionApplyDate").datepicker();
                }
                else if (pageType == "PersonalChange") {
                    //时间控件
                    $("#txtPersonalChangeEffectiveDate").datepicker();
                }
            }, "html");
        }
    </script>
    <style type="text/css">
        input.readonly {
            background: rgb(227, 227, 227);
        }
        /*52100*/
        [id*=btnHRSave][value="保存"] {
            background-image: url(/Images/bsm_save1.png);
            height: 20px;
            width: 30px;
            font-size: 0px;
            cursor: pointer;
            color: #FFFFFF;
        }
        /*52100*/

        #tbAround input[type="text"] {
            border: none;
            border-bottom: 1px solid black;
        }

        #tbAround .tdDetailCss {
            padding-left: 5px;
            padding-right: 5px;
        }

        #tbAround .tbDetailCss {
            border-collapse: collapse;
            border-spacing: 0;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hidDeptID" runat="server" clientidmode="Static" />
    <input type="hidden" id="hidPageType" runat="server" clientidmode="Static" />
    <input type="hidden" id="hidDimissionType" runat="server" clientidmode="Static" />
    <input type="hidden" id="hidDimissionReason" runat="server" clientidmode="Static" />
    <input type="hidden" id="hidPersonalChangeType" runat="server" clientidmode="Static" />
    <input type="hidden" id="hidDetail" runat="server" clientidmode="Static" />
    <input type="hidden" id="hidAddIDxIsChecked" runat="server" clientidmode="Static" />

    <asp:HiddenField ID="hidApplyDate" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <%--<asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />--%>
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1 id="h1DocumentTitle" runat="server" clientidmode="Static">联动统筹中心入职申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 720px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span></div>
            <table id="tbAround" style="width: 720px;">
                <tr>
                    <td class="auto-style4">工号</td>
                    <td class="tl PL10">
                        <input id="txtEmpCode" type="text" style="width: 100px;" runat="server" clientidmode="Static" />
                    </td>
                    <td class="auto-style4">姓名</td>
                    <td class="tl PL10">
                        <input id="txtEmpName" type="text" style="width: 100px;" runat="server" clientidmode="Static" />
                        <%--<input id="Checkbox1" type="checkbox" checked="checked" />--%>
                    </td>
                </tr>
                <tr class="noborder">
                    <td class="tdDetailCss" colspan="4">
                        <%=SBTable.ToString() %>
                        <%--<table id="tbInservice" width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="auto-style4" rowspan="5">入职申请</td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">部门分行</td>
                                    <td class="tl PL10">
                                        <input id="txtInserviceDeptment" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">职位名称</td>
                                    <td class="tl PL10">
                                        <input id="txtInservicePosition" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">职等名称</td>
                                    <td class="tl PL10">
                                        <input id="txtInservicePosGrade" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">基本工资</td>
                                    <td class="tl PL10">
                                        <input id="txtInserviceBasicSalary" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">入职日期</td>
                                    <td class="tl PL10">
                                        <input id="txtInserviceEnterDate" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">计佣角色</td>
                                    <td class="tl PL10">
                                        <select id="sbInserviceEccRole" runat="server" clientidmode="Static" style="width: 100px; height: 24px; line-height: 22px; vertical-align: middle;">
                                            <option value="-1" selected="selected">--请选择</option>
                                            <option value="86B29D28-0545-4772-AF3C-17B9ABEC4D6F">店董</option>
                                            <option value="8EF96719-C261-4D2F-8CC2-4133776E62B5">组长</option>
                                            <option value="69462582-770A-45B0-B940-6FA48E907117">组员</option>
                                            <option value="5C368720-46E6-4679-86D1-48115E52D80C">新人</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">工作性质</td>
                                    <td class="tl PL10">
                                        <select id="sbInserviceWorkNature" runat="server" clientidmode="Static" style="width: 100px; height: 24px; line-height: 22px; vertical-align: middle;">
                                            <option value="-1" selected="selected">--请选择</option>
                                            <option value="4ECD2706-467F-49B1-9C94-80CEFEC5DFC6">主管</option>
                                            <option value="A9970ED1-64F5-4C66-BB71-C9E3463C611C">驻场</option>
                                            <option value="660AAA33-739D-43EA-9EBF-82A25AB16C32">文书对接</option>
                                        </select>
                                    </td>
                                    <td class="auto-style4">直属主管</td>
                                    <td class="tl PL10">
                                        <input id="txtInserviceZSSupervisor" type="text" style="width: 100px;" runat="server" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">隶属主管</td>
                                    <td class="tl PL10">
                                        <input id="txtInserviceLSSupervisor" type="text" style="width: 100px;" runat="server" clientidmode="Static" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">备注</td>
                                    <td class="tl PL10" colspan="5">
                                        <textarea id="txtInserviceRemark" cols="20" rows="3" style="width: 90%;" runat="server" clientidmode="Static" ></textarea>
                                    </td>
                                </tr>
                            </table>--%>

                        <%--<table id="tbDimission" width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="auto-style4" rowspan="6">离职申请</td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">部门分行</td>
                                    <td class="tl PL10">
                                        <input id="txtDimissionDeptment" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">职位名称</td>
                                    <td class="tl PL10">
                                        <input id="txtDimmissionPosition" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">职等名称</td>
                                    <td class="tl PL10">
                                        <input id="txtDimmissionPosGrade" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">离职类别</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="rbtnDimissionType1" type="radio" name="DimissionType" value="1" style="vertical-align: middle; margin-left: 2px;" clientidmode="Static" checked="checked" />
                                        <label style="vertical-align: middle;">员工辞职</label>
                                        <br />
                                        <input id="rbtnDimissionType2" type="radio" name="DimissionType" value="2" style="vertical-align: middle; margin-left: 2px;" clientidmode="Static" />
                                        <label style="vertical-align: middle;">公司辞退</label>
                                    </td>
                                    <td class="auto-style4">离职原因</td>
                                    <td colspan="2">
                                        <table id="tbDimissionReasons" width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <input id="ckbDimissionReason1" name="DimissionReason" type="radio" value="1" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbDimissionReason1">私人原因</label></td>
                                                <td>
                                                    <input id="ckbDimissionReason2" name="DimissionReason" type="radio" value="2" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbDimissionReason2">严重违反公司规章制度</label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input id="ckbDimissionReason3" name="DimissionReason" type="radio" value="3" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbDimissionReason3">劳动合同期满不再续约</label></td>
                                                <td>
                                                    <input id="ckbDimissionReason4" name="DimissionReason" type="radio" value="4" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbDimissionReason4">双方协商解除劳动合同</label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <input id="ckbDimissionReason5" name="DimissionReason" type="radio" value="5" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbDimissionReason5">其他</label>
                                                    <input id="txtDimissionReason5" type="text" runat="server" clientidmode="Static" style="width: 100px; border: none; border-bottom: 1px solid black;" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">最后出勤日期</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtDimissionLastDate" type="text" style="width: 100px;" runat="server" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">提交辞职申请日期</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtDimissionApplyDate" type="text" style="width: 100px;" runat="server" clientidmode="Static" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">直属主管</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtDimissionZSSupervisor" type="text" style="width: 100px;" runat="server" clientidmode="Static" />
                                    </td>
                                    <td class="auto-style4">隶属主管</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtDimissionLSSupervisor" type="text" style="width: 100px;" runat="server" clientidmode="Static" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">备注</td>
                                    <td class="tl PL10" colspan="5">
                                        <textarea id="txtDimissionRemark" cols="20" rows="3" style="width: 90%;" runat="server" clientidmode="Static"></textarea>
                                    </td>
                                </tr>
                            </table>--%>

                        <%--<table id="tbPersonalChange" width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="auto-style4" rowspan="11">调动申请</td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" colspan="3">现任</td>
                                    <td class="auto-style4" colspan="3">调整后</td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">部门分行</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangeDeptOld" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                    <td class="auto-style4">部门分行</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangeDeptNew" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">职位名称</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangePositionOld" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                    <td class="auto-style4">职位名称</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangePositionNew" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">职等名称</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangePosGradeOld" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                    <td class="auto-style4">职等名称</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangePosGradeNew" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">基本工资</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangeBasicSalaryOld" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                    <td class="auto-style4">基本工资</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangeBasicSalaryNew" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">直属主管</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangeZSSupervisorOld" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                    <td class="auto-style4">直属主管</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangeZSSupervisorNew" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">隶属主管</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangeLSSupervisorOld" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                    <td class="auto-style4">隶属主管</td>
                                    <td class="tl PL10" colspan="2">
                                        <input id="txtPersonalChangeLSSupervisorNew" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style4">计佣角色</td>
                                    <td class="tl PL10" colspan="2">
                                        <select id="sbPersonalChangeEccRoleOld" runat="server" clientidmode="Static" style="width: 100px; height: 24px; line-height: 22px; vertical-align: middle;">
                                            <option value="00000000-0000-0000-0000-000000000000" selected="selected">--请选择</option>
                                            <option value="86B29D28-0545-4772-AF3C-17B9ABEC4D6F">店董</option>
                                            <option value="8EF96719-C261-4D2F-8CC2-4133776E62B5">组长</option>
                                            <option value="69462582-770A-45B0-B940-6FA48E907117">组员</option>
                                            <option value="5C368720-46E6-4679-86D1-48115E52D80C">新人</option>
                                        </select>
                                    </td>
                                    <td class="auto-style4">计佣角色</td>
                                    <td class="tl PL10" colspan="2">
                                        <select id="sbPersonalChangeEccRoleNew" runat="server" clientidmode="Static" style="width: 100px; height: 24px; line-height: 22px; vertical-align: middle;">
                                            <option value="00000000-0000-0000-0000-000000000000" selected="selected">--请选择</option>
                                            <option value="86B29D28-0545-4772-AF3C-17B9ABEC4D6F">店董</option>
                                            <option value="8EF96719-C261-4D2F-8CC2-4133776E62B5">组长</option>
                                            <option value="69462582-770A-45B0-B940-6FA48E907117">组员</option>
                                            <option value="5C368720-46E6-4679-86D1-48115E52D80C">新人</option>
                                        </select>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style4">工作性质</td>
                                    <td class="tl PL10" colspan="2">
                                        <select id="sbPersonalChangeWorkNatureOld" runat="server" clientidmode="Static" style="width: 100px; height: 24px; line-height: 22px; vertical-align: middle;">
                                            <option value="00000000-0000-0000-0000-000000000000" selected="selected">--请选择</option>
                                            <option value="4ECD2706-467F-49B1-9C94-80CEFEC5DFC6">主管</option>
                                            <option value="A9970ED1-64F5-4C66-BB71-C9E3463C611C">驻场</option>
                                            <option value="660AAA33-739D-43EA-9EBF-82A25AB16C32">文书对接</option>
                                        </select>
                                    </td>
                                    <td class="auto-style4">工作性质</td>
                                    <td class="tl PL10" colspan="2">
                                        <select id="sbPersonalChangeWorkNatureNew" runat="server" clientidmode="Static" style="width: 100px; height: 24px; line-height: 22px; vertical-align: middle;">
                                            <option value="00000000-0000-0000-0000-000000000000" selected="selected">--请选择</option>
                                            <option value="4ECD2706-467F-49B1-9C94-80CEFEC5DFC6">主管</option>
                                            <option value="A9970ED1-64F5-4C66-BB71-C9E3463C611C">驻场</option>
                                            <option value="660AAA33-739D-43EA-9EBF-82A25AB16C32">文书对接</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">生效日期</td>
                                    <td class="tl PL10" colspan="5">
                                        <input id="txtPersonalChangeEffectiveDate" type="text" runat="server" clientidmode="Static" style="width: 100px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">变动类型</td>
                                    <td colspan="5">
                                        <table id="tbPersonalChangeType" width="100%" border="0" class="noborder" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <input id="ckbPersonalChangeType1" name="PersonalChangeType" type="checkbox" value="1" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbPersonalChangeType1">通过试用期</label></td>
                                                <td>
                                                    <input id="ckbPersonalChangeType2" name="PersonalChangeType" type="checkbox" value="2" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbPersonalChangeType2">升职</label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input id="ckbPersonalChangeType3" name="PersonalChangeType" type="checkbox" value="3" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbPersonalChangeType3">降职</label></td>
                                                <td>
                                                    <input id="ckbPersonalChangeType4" name="PersonalChangeType" type="checkbox" value="4" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbPersonalChangeType4">调薪</label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input id="ckbPersonalChangeType5" name="PersonalChangeType" type="checkbox" value="5" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbPersonalChangeType5">调职/变更隶属关系</label></td>
                                                <td>
                                                    <input id="ckbPersonalChangeType6" name="PersonalChangeType" type="checkbox" value="6" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbPersonalChangeType6">转会（部门负责人变更）</label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <input id="ckbPersonalChangeType7" name="PersonalChangeType" type="checkbox" value="7" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbPersonalChangeType7">实习生转试用员工</label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <input id="ckbPersonalChangeType8" name="PersonalChangeType" type="checkbox" value="8" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                                    <label class="rbtLabelCss" for="ckbPersonalChangeType8">其他</label>
                                                    <input id="txtPersonalChangeType8" type="text" runat="server" clientidmode="Static" style="width: 150px;" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">备注</td>
                                    <td class="tl PL10" colspan="5">
                                        <textarea id="txtPersonalChangeRemark" cols="20" rows="3" style="width: 90%;" runat="server" clientidmode="Static"></textarea>
                                    </td>
                                </tr>
                            </table>--%>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">建立日期</td>
                    <td class="tl PL10">
                        <input id="txtApplyDate" type="text" runat="server" clientidmode="Static" style="width: 100px;" readonly="readonly" />
                    </td>
                    <td class="auto-style4">操作人</td>
                    <td class="tl PL10">
                        <input id="txtApply" type="text" runat="server" clientidmode="Static" style="width: 100px;" readonly="readonly" />
                    </td>
                </tr>
            </table>
            <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0" style="width: 720px; margin-top: 5px;">
                <%-- <tr class="noborder" style="height:85px;" Idx="1">
                            <td class="auto-style2">申请人</td>
                            <td colspan="3" class="tl PL10" style="">
                                <div class="fieldradio">
                                    <input type="radio" value="1" /><label class="l signyes">同意</label>
                                    <input type="radio" value="0" /><label class="l signno">不同意</label>
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
                        </tr>--%>
                <tr class="noborder" style="height: 85px;" idx="1">
                    <td class="auto-style2">直属主管</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
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
                    <td class="auto-style2">总助</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
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
                <tr class="noborder" style="height: 85px;" idx="4">
                    <td class="auto-style2" id="areamanager">区域负责人</td>
                    <td class="auto-style2" id="manager" style="display: none;">部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
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
                    <td class="auto-style2">人力资源部</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" /><label class="l signother">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                        </div>
                        <div id="actualReimbursement" style="text-align: left; border-color: #98b8b5;">
                            <span>实际报销金额：<asp:TextBox ID="txtReimbursementAmount" runat="server" Width="100" BorderStyle="Solid" BorderColor="#98b8b5" BorderWidth="1"></asp:TextBox></span>
                            <span style="margin-left: 20px;">报销日期：<asp:TextBox ID="txtReimbursementDate" runat="server" Width="100" BorderStyle="Solid" BorderColor="#98b8b5" BorderWidth="1"></asp:TextBox></span>
                            <asp:Button runat="server" ID="btnHRSave" Text="保存" OnClientClick="return saveReimbursement();" Visible="false" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
        </div>
        <!--打印正文结束-->
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
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <div id="PageBottom">
                <p></p>
                <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return Check();" Visible="False" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" OnClientClick="BackToSearch();return false;" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIdx" runat="server" />
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
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        PageInit();
    </script>
</asp:Content>

