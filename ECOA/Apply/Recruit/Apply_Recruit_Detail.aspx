<%@ Page Title="招聘需求申请 - 广州中原电子审批系统" ValidateRequest="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Recruit_Detail.aspx.cs" Inherits="Apply_Recruit_Apply_Recruit_Detail" %>

<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../../Script/uploadify/uploadify.css" type="text/css" />
    <style type="text/css">
        tr input {
            border: 1px solid #98b8b5;
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
    </style>

    <%--<script type="text/javascript" src="../../Script/common.js"></script>--%>
    <script type="text/javascript" src="../../Script/uploadify/jquery.uploadify.min.js"></script>
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
            cCancelSign(idc, "<%=this.hdCancelSign.ClientID%>","<%=this.btnCancelSign.ClientID%>");   //common_new.js
        }
        //签名事件
        function sign(e) {
            cSign(e, "<%=hdIsAgree.ClientID %>", "<%=hdSuggestion.ClientID %>", "<%=this.btnSign.ClientID %>");   //common_new.js
        }

        //复审签名
        function signfs(e)
        {
            cSignfs(e,"<%=hdIsAgree.ClientID %>", "<%=hdSuggestion.ClientID %>")
        }

        //签名内容绑定
        function FlowSignInit()
        {
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>",$("#<%=this.Apply.ClientID%>").val(),"<%=EmployeeName%>","<%=EmployeeID%>");   //common_new.js
        }

        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>","<%=ApplyN %>");
        }
    </script>
    <script type="text/javascript">
        function REQUIRED_Check_Old()
        {
            flag = true;
            $("input.REQUIRED").each(function () {
                var message = this.value;
                var forname = $(this).attr("for");
                var $target;
                if (forname != undefined && forname != "") {
                    $target = $("#" + forname);
                }
                else {
                    $target = $(this).prev();
                }
                if ($.trim($target.val()) == "") {
                    alert(message);
                    flag = false;
                    $target.focus();
                    return false; //break;
                }
            });
            if (!flag) {
                return false;
            }
            return true;
        }

        //新增类别onchange事件
        function AddTypeOnChange(e) {
            if (e.value == "1" || e.value == "2") {
                $("#<%=this.ApplyType.ClientID%>").val("3");
                ApplyTypeChange($("#<%=this.ApplyType.ClientID%>").get(0));
            }
            else {
                $("#<%=this.ApplyType.ClientID%>").val("1");
                ApplyTypeChange($("#<%=this.ApplyType.ClientID%>").get(0));
            }
            $("#<%=this.AddType.ClientID%>").val(e.value);
        }

        //招聘需求申请onchange事件
        function ApplyTypeChange(e) {
            if (e.value == "1") {
                $("#Demand").show();
                $("#DMOS").hide();
            }
            else if (e.value == "2") {
                $("#Demand").hide();
                $("#DMOS").show();
                $("input[name='rdAddType']").each(function () {
                    this.checked = false;
                });
                $("#<%=this.AddType.ClientID%>").val("");
            }
            else if (e.value == "3") {
                $("#Demand").show();
                $("#DMOS").show();
            }
            else {
                $(e).foucs();
                alert("请选择招聘需求申请");
                $("#Demand").hide();
                $("#DMOS").hide();
            }
    }

    //是否危险
    function IsDangerClick(e)
    {
        $("#<%=this.gwIsDanger.ClientID%>").val(e.value);
    }

   

        //页面初始化
        function PageInit() {
            //签名方法事件初始化 common_new.js
            SignFunBind();
            //签名数据绑定
            FlowSignInit();

            //时间控件
            $("#<%=this.TakeOfficeDate.ClientID%>").datepicker();
            $("#<%=this.gwApplyDate.ClientID%>").datepicker();

            //部门绑定
            var jJSON = <%=SbJson.ToString() %>;
            $("#<%=this.Department.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });
            $("#<%=this.gwDepartment.ClientID%>").autocomplete({ 
                source: jJSON,
                select:function(event,ui){
                    $("#<% =hdgwdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });
            $("#<%=this.gwApplyDepartment.ClientID%>").autocomplete({ source: jJSON });

            ApplyTypeChange($("#<%=this.ApplyType.ClientID%>").get(0));
            TipsBind();

            //HR最后填写内容事件绑定
            HRDetailInit();
            //HRrowEvenBind();

            //新增类别
            var AddType = $("#<%=this.AddType.ClientID%>").val();
            if (AddType != undefined && AddType != "")
            {
                $("#AddType" + AddType).prop("checked","true");
            }

            //性别
            var Sex = $("#<%=this.Sex.ClientID%>").val();
            if (Sex != undefined && Sex != "")
            {
                $("#Sex" + Sex).prop("checked","true");
            }

            //是否危险
            var IsDanger =  $("#<%=this.gwIsDanger.ClientID%>").val();
            if (IsDanger != undefined && IsDanger != "")
            {
                $("#gwIsDanger" + IsDanger).prop("checked","true");
            }

            //工作职责
            var detail = $("#<%=this.hidDetail1.ClientID%>").val();
            var list = detail == "" ? [] : detail.evalJSON();   //string.evalJSON(); common.js 方法
            if(list.length > 0)
            {
                $("#gwzzdetail").html("");  //初始化
            }
            for(var i = 0 ; i < list.length ; i++)
            {
                addrow("gwzzdetail",list[i]);
            }

            //其他工作职责
            detail = $("#<%=this.hidDetail2.ClientID%>").val();
            list = detail == "" ? [] : detail.evalJSON();   //string.evalJSON(); common.js 方法
            if(list.length > 0)
            {
                $("#gwotherzzdetail").html("");  //初始化
            }
            for(var i = 0 ; i < list.length ; i++)
            {
                addrow("gwotherzzdetail",list[i]);
            }

            //上传控件
            $("#uploadify").uploadify({
                'swf': '../../Script/uploadify/uploadify.swf',
                'uploader': '../../Ajax/UploadHandler.ashx?MainID=<%=MainID%>',
                //'cancelImg': '../../Script/uploadify/cancel.png',
                'buttonText': '上传组织架构图',
                'queueID': 'fileQueue',
                'fileTypeExts':'*.jpg;*.png;*.jpeg',
                'fileTypeDesc':'请选择jpg、png文件',
                'auto': true,
                'multi': false,
                'width':100,
                onDialogClose: onDialogClose,
                onCancel: onDialogClose,
                onUploadSuccess: onUploadSuccess
            });

            //架构图
            var jgt = $("#<%=this.gwOrganizationStructure.ClientID%>").val();
            var path = "<%=System.Configuration.ConfigurationManager.AppSettings["EcoaFileURL"]%>";
            if(jgt != undefined && jgt != "")
            {
                $("#imgOrganizationStructure").attr("src",path + jgt).show();
            }
            else{
                $("#imgOrganizationStructure").hide();
            }

           
        }

        //上传相关
        var onDialogClose = function (queueData) { }
        var onUploadSuccess = function (file, data, response) {
            if(data == "0")
            {
                alert("请先登录");
                return;
            }
            var obj = eval("(" + data + ")");       //转json
            $("#imgOrganizationStructure").attr("src",obj.url).show();
            $("#<%=this.gwOrganizationStructure.ClientID%>").val(obj.name);
        }

        //增加行
        function addrow(tbodyid,obj) {
            var tips1 = "根据岗位对此项工作的参与程度，可分为：全权、负责、协助、参与四个等级";
            var tips2 = "根据此项工作的开展周期，可分为日、周、月度、季度、年度、偶尔和随时";
            var tips3 = "请尽可能以数据做说明";

            var Desc = Responsibility = Cycle = Performance = WorkRate = "";
            if(obj != null && obj != undefined)
            {
                Desc = obj.OfficeAutomation_Document_Recruit_Detail_Desc;
                Responsibility = obj.OfficeAutomation_Document_Recruit_Detail_Responsibility;
                Cycle = obj.OfficeAutomation_Document_Recruit_Detail_Cycle;
                Performance = obj.OfficeAutomation_Document_Recruit_Detail_Performance;
                WorkRate = obj.OfficeAutomation_Document_Recruit_Detail_WorkRate;
            }
            var html = '<tr>';
            html += '      <td><input type="text" style="width:200px" name="Desc" value="' + Desc + '" /></td>';
            html += '      <td><input type="text" style="width:44px" name="Responsibility" value="' + Responsibility + '" title="' + tips1 + '" /></td>';
            html += '      <td><input type="text" style="width:32px" name="Cycle" value="' + Cycle + '" title="' + tips2 + '" /></td>';
            html += '      <td><input type="text" style="width:96%" name="Performance" value="' + Performance + '" title="' + tips3 + '" /></td>';
            html += '      <td><input type="text" style="width:82px" name="WorkRate" value="' + WorkRate + '" /></td>';
            html += '   </tr>';
            $("#" + tbodyid).append(html);
            TipsBind();
        }
        //删除行
        function delrow(tbodyid) {
            $tr = $("#" + tbodyid + " tr");
            if ($tr.length == 1) {
                alert("已经最后一行,不能再删了");
                return;
            }
            $tr.last().remove();
        }
        function ddelrow(tbodyid) {
            $tr = $("#" + tbodyid + " tr");
            $tr.last().remove();
        }

        //性别选择
        function SexClick(e)
        {
            $("#<%=this.Sex.ClientID%>").val(e.value);
        }

        function check()
        {
            if ($("#Demand").css("display") == "none") {
                //无需填《人才需求表》
                $("#Demand input.REQUIRED").each(function () {
                    $(this).removeClass("REQUIRED").addClass("NOREQUIRED");
                });
            }
            else {
                //需要填
                $("#Demand input.NOREQUIRED").each(function () {
                    $(this).removeClass("NOREQUIRED").addClass("REQUIRED");
                });
            }

            if ($("#DMOS").css("display") == "none") {
                //无需填《岗位说明书》
                $("#DMOS input.REQUIRED").each(function () {
                    $(this).removeClass("REQUIRED").addClass("NOREQUIRED");
                });
            }
            else {
                //需要填
                $("#DMOS input.NOREQUIRED").each(function () {
                    $(this).removeClass("NOREQUIRED").addClass("REQUIRED");
                });
            }

            //在必填项后增加input class="REQUIRED" 项用以控制是否必填
            flag = REQUIRED_Check_Old();
            if (!flag) {
                return false;
            }

            flag = false;
            if ($("#Demand").css("display") == "block")
            { flag = true; }

            //需要填《人才需求》
            if (flag) {
                //新增类别
                if ($("#<%=this.AddType.ClientID%>").val() == "") {
                    alert("请选择新增类别");
                    $("#AddType1").focus();
                    return false;
                }

                //性别
                if ($("#<%=this.Sex.ClientID%>").val() == "") {
                    alert("请选择性别");
                    $("#Sex1").focus();
                    return false;
                }
            }

            flag = false;
            //需要填岗位说明说
            if($("#DMOS").css("display") == "block")
            { flag = true; }
            if(flag)
            {
                //工作职责
                var f = true;
                var array = new Array();
                var data;
                $("#gwzzdetail tr").each(function(){
                    var $Desc = $(this).find("input[name='Desc']");
                    if($.trim($Desc.val()) == "")
                    {
                        alert("请填写描述");
                        $Desc.focus();
                        f = false;
                        return false;
                    }
                    var $Responsibility = $(this).find("input[name='Responsibility']");
                    if($.trim($Responsibility.val()) == "")
                    {
                        alert("请填写负责程度");
                        $Responsibility.focus();
                        f = false;
                        return false;
                    }
                    var $Cycle = $(this).find("input[name='Cycle']");
                    if($.trim($Cycle.val()) == "")
                    {
                        alert("请填写周期");
                        $Cycle.focus();
                        f = false;
                        return false;
                    }
                    var $Performance = $(this).find("input[name='Performance']");
                    if($.trim($Performance.val()) == "")
                    {
                        alert("请填写绩效标准");
                        $Performance.focus();
                        f = false;
                        return false;
                    }
                    var $WorkRate = $(this).find("input[name='WorkRate']");
                    if($.trim($WorkRate.val()) == "")
                    {
                        alert("请填写工作比重");
                        $WorkRate.focus();
                        f = false;
                        return false;
                    }
                    data = {OfficeAutomation_Document_Recruit_Detail_Desc:$Desc.val(),
                        OfficeAutomation_Document_Recruit_Detail_Responsibility:$Responsibility.val(),
                        OfficeAutomation_Document_Recruit_Detail_Cycle:$Cycle.val(),
                        OfficeAutomation_Document_Recruit_Detail_Performance:$Performance.val(),
                        OfficeAutomation_Document_Recruit_Detail_WorkRate:$WorkRate.val(),
                        OfficeAutomation_Document_Recruit_Detail_Type:1};
                    array.push(data)
                });

                if(!f)
                {
                    return false;
                }
                $("#<%=this.hidDetail1.ClientID%>").val(Obj2str(array));     //common.js 方法

                //其他工作职责
                f = true;
                array = new Array();
                $("#gwotherzzdetail tr").each(function(){
                    var $Desc = $(this).find("input[name='Desc']");
                    if($.trim($Desc.val()) == "")
                    {
                        alert("请填写描述");
                        $Desc.focus();
                        f = false;
                        return false;
                    }
                    var $Responsibility = $(this).find("input[name='Responsibility']");
                    if($.trim($Responsibility.val()) == "")
                    {
                        alert("请填写负责程度");
                        $Responsibility.focus();
                        f = false;
                        return false;
                    }
                    var $Cycle = $(this).find("input[name='Cycle']");
                    if($.trim($Cycle.val()) == "")
                    {
                        alert("请填写周期");
                        $Cycle.focus();
                        f = false;
                        return false;
                    }
                    var $Performance = $(this).find("input[name='Performance']");
                    if($.trim($Performance.val()) == "")
                    {
                        alert("请填写绩效标准");
                        $Performance.focus();
                        f = false;
                        return false;
                    }
                    var $WorkRate = $(this).find("input[name='WorkRate']");
                    if($.trim($WorkRate.val()) == "")
                    {
                        alert("请填写工作比重");
                        $WorkRate.focus();
                        f = false;
                        return false;
                    }
                    data = {OfficeAutomation_Document_Recruit_Detail_Desc:$Desc.val(),
                        OfficeAutomation_Document_Recruit_Detail_Responsibility:$Responsibility.val(),
                        OfficeAutomation_Document_Recruit_Detail_Cycle:$Cycle.val(),
                        OfficeAutomation_Document_Recruit_Detail_Performance:$Performance.val(),
                        OfficeAutomation_Document_Recruit_Detail_WorkRate:$WorkRate.val(),
                        OfficeAutomation_Document_Recruit_Detail_Type:2};
                    array.push(data)
                });

                if(!f)
                {
                    return false;
                }
                $("#<%=this.hidDetail2.ClientID%>").val(Obj2str(array));     //common.js 方法
            }

            return true;
        }

        ///暂时保存52100-2016/10/18
        function tempsavecheck()
        {
            //工作职责
            var array = new Array();
            var data;
            $("#gwzzdetail tr").each(function(){
                var $Desc = $(this).find("input[name='Desc']");
                var $Responsibility = $(this).find("input[name='Responsibility']");
                var $Cycle = $(this).find("input[name='Cycle']");
                var $Performance = $(this).find("input[name='Performance']");
                var $WorkRate = $(this).find("input[name='WorkRate']");
                data = {OfficeAutomation_Document_Recruit_Detail_Desc:$Desc.val(),
                    OfficeAutomation_Document_Recruit_Detail_Responsibility:$Responsibility.val(),
                    OfficeAutomation_Document_Recruit_Detail_Cycle:$Cycle.val(),
                    OfficeAutomation_Document_Recruit_Detail_Performance:$Performance.val(),
                    OfficeAutomation_Document_Recruit_Detail_WorkRate:$WorkRate.val(),
                    OfficeAutomation_Document_Recruit_Detail_Type:1};
                array.push(data)
            });
            $("#<%=this.hidDetail1.ClientID%>").val(Obj2str(array));     //common.js 方法
            //其他工作职责
            array = new Array();
            $("#gwotherzzdetail tr").each(function(){
                var $Desc = $(this).find("input[name='Desc']");
                var $Responsibility = $(this).find("input[name='Responsibility']");
                var $Cycle = $(this).find("input[name='Cycle']");
                var $Performance = $(this).find("input[name='Performance']");
                var $WorkRate = $(this).find("input[name='WorkRate']");
                data = {OfficeAutomation_Document_Recruit_Detail_Desc:$Desc.val(),
                    OfficeAutomation_Document_Recruit_Detail_Responsibility:$Responsibility.val(),
                    OfficeAutomation_Document_Recruit_Detail_Cycle:$Cycle.val(),
                    OfficeAutomation_Document_Recruit_Detail_Performance:$Performance.val(),
                    OfficeAutomation_Document_Recruit_Detail_WorkRate:$WorkRate.val(),
                    OfficeAutomation_Document_Recruit_Detail_Type:2};
                array.push(data)
            });
            $("#<%=this.hidDetail2.ClientID%>").val(Obj2str(array));     //common.js 方法

            return true;
        }
        ///end

        function TipsBind()
        {
            var tooltips = $("[title]").tooltip({
                position: {
                    my: "left top",
                    at: "right+5 top-5"
                }
            });
        }

        //HR结果事件绑定
        function HRrowEvenBind()
        {
            var jJSON = <%=SbJson.ToString() %>;
            $("#HRHandlebody tr").each(function(){
                $(this).find("input.txtdate").datepicker();
                $(this).find("input.txtdep").autocomplete({ source: jJSON });
            });
        }
        //添加行
        function addrowHR(e,o)
        {
            var dep = pos = name = date = payment = grade = "";
            if(o != null && o != undefined)
            {
                dep = o.OfficeAutomation_Document_RecruitHRResult_Dep;
                pos = o.OfficeAutomation_Document_RecruitHRResult_Pos;
                name = o.OfficeAutomation_Document_RecruitHRResult_Name;
                date = o.OfficeAutomation_Document_RecruitHRResult_Date;
                payment = o.OfficeAutomation_Document_RecruitHRResult_Payment;
                grade = o.OfficeAutomation_Document_RecruitHRResult_Grade;
            }
            html = '<tr>' +
                      '<td><input class="txtdep" style="width:130px" name="dep" value="' + dep + '" /></td>' +
                      '<td><input class="txtpos" style="width:100px" name="pos" value="' + pos + '" /></td>' +
                      '<td><input class="txtname" style="width:70px" name="name" value="' + name + '" /></td>' +
                      '<td><input class="txtdate" style="width:100px" name="date" value="' + date + '" /></td>' + 
                      '<td><input class="txtpayment" style="width:80px" name="payment" value="' + payment + '" /></td>' +
                      '<td><input class="txtgrade" style="width:50px" name="grade" value="' + grade + '" /></td>' +
                   '</tr>';
            $("#HRHandlebody").append(html);
            HRrowEvenBind();
            return;
        }

        //
        function HRSave()
        {
            var  flag = true;
            var array = new Array();
            var data;
            $("#HRHandlebody tr").each(function(){
                var $inputdep = $(this).find("input[name='dep']");
                if($.trim($inputdep.val()) == "" )
                {
                    $inputdep.focus();
                    flag = false;
                    alert("请输入入职部门");
                    return false;
                }

                var $inputpos = $(this).find("input[name='pos']");
                if($.trim($inputpos.val()) == "" )
                {
                    $inputpos.focus();
                    flag = false;
                    alert("请输入入职岗位");
                    return false;
                }

                var $inputname = $(this).find("input[name='name']");
                if($.trim($inputname.val()) == "" )
                {
                    $inputname.focus();
                    flag = false;
                    alert("请输入入职者姓名");
                    return false;
                }

                var $inputdate = $(this).find("input[name='date']");
                if($.trim($inputdate.val()) == "" )
                {
                    $inputdate.focus();
                    flag = false;
                    alert("请输入入职日期");
                    return false;
                }

                var $inputpayment = $(this).find("input[name='payment']");
                if($.trim($inputpayment.val()) == "" )
                {
                    $inputpayment.focus();
                    flag = false;
                    alert("请输入薪金");
                    return false;
                }

                var $inputgrade = $(this).find("input[name='grade']");
                if($.trim($inputgrade.val()) == "" )
                {
                    $inputgrade.focus();
                    flag = false;
                    alert("请输入职级");
                    return false;
                }

                data = {OfficeAutomation_Document_RecruitHRResult_Dep:$inputdep.val(),
                    OfficeAutomation_Document_RecruitHRResult_Pos:$inputpos.val(),
                    OfficeAutomation_Document_RecruitHRResult_Name:$inputname.val(),
                    OfficeAutomation_Document_RecruitHRResult_Date:$inputdate.val(),
                    OfficeAutomation_Document_RecruitHRResult_Payment:$inputpayment.val(),
                    OfficeAutomation_Document_RecruitHRResult_Grade:$inputgrade.val(),
                    OfficeAutomation_Document_RecruitHRResult_Grade:$inputgrade.val()
                };
                array.push(data)
            });

            if(!flag)
            {
                return false;
            }
            $("#<%=this.hidHRDetail.ClientID%>").val(Obj2str(array));     //common.js 方法
            return true;
        }

        function HRDetailInit()
        {
            var detail = $("#<%=this.hidHRDetail.ClientID%>").val();
            if(detail == undefined || detail == "null")
            {
                HRrowEvenBind();
                return;
            }
            var list = detail == "" ? [] : detail.evalJSON();   //string.evalJSON(); common.js 方法
            if(list.length > 0)
            {
                $("#HRHandlebody").html("");  //初始化
            }
            for(var i = 0 ; i < list.length ; i++)
            {
                addrowHR(this,list[i]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>招聘需求申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <asp:HiddenField ID="ApplyDate" runat="server" />
            <asp:HiddenField ID="Apply" runat="server" />
            <div id="snum" style="width: 640px; margin: 0 auto; text-align: left">
                <span style="float: right;" class="file_number">文档编码(自动生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span>
                <label>招聘需求申请:</label>
                <asp:DropDownList ID="ApplyType" runat="server" onchange="ApplyTypeChange(this);">
                    <asp:ListItem Value="1">人才需求表</asp:ListItem>
                    <asp:ListItem Value="2">岗位说明书</asp:ListItem>
                    <asp:ListItem Value="3">人才需求表+岗位说明书</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="width: 640px; margin: 0 auto; text-align: left">
                <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;部门类型:</label>
                <asp:DropDownList ID="DepartmentType" runat="server">
                    <asp:ListItem Value="">请选择</asp:ListItem>
                    <asp:ListItem Value="1">物业部+工商铺部</asp:ListItem>
                    <asp:ListItem Value="2">项目部营业岗位</asp:ListItem>
                    <asp:ListItem Value="3">非营岗位+汇瀚</asp:ListItem>
                    <asp:ListItem Value="4">中台部门</asp:ListItem>
                </asp:DropDownList>
                <input type="hidden" class="REQUIRED" value="请选择部门类型" />
            </div>

            <!--人才需求表-->
            <div id="Demand" style="width: 640px; margin: 0px auto; margin-bottom: 30px">
                <table id="tbAround" width='640px'>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 16px"><b>人才需求表</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">申请部门</td>
                        <td class="tl PL10">
                            <asp:TextBox ID="Department" runat="server" Width="100"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                            <input type="hidden" class="REQUIRED" for="ctl00_ContentPlaceHolder1_Department" value="请填写申请部门" />
                        </td>
                        <td class="auto-style4">申请职位</td>
                        <td class="tl PL10">
                            <asp:TextBox ID="Position" runat="server" Width="100"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写申请职位" /></td>
                        <td class="auto-style4">职&nbsp;&nbsp;&nbsp;&nbsp;级</td>
                        <td class="tl PL10">
                            <asp:DropDownList ID="Grade" runat="server" >
                                <asp:ListItem Value="">请选择</asp:ListItem>
                                <asp:ListItem Value="1">1级</asp:ListItem>
                                <asp:ListItem Value="2">2级</asp:ListItem>
                                <asp:ListItem Value="3">3级</asp:ListItem>
                                <asp:ListItem Value="4">4级</asp:ListItem>
                                <asp:ListItem Value="5">5级</asp:ListItem>
                                <asp:ListItem Value="6">6级</asp:ListItem>
                                <asp:ListItem Value="7">7级</asp:ListItem>
                                <asp:ListItem Value="8">8级</asp:ListItem>
                                <asp:ListItem Value="9">9级</asp:ListItem>
                                <asp:ListItem Value="10">10级</asp:ListItem>
                            </asp:DropDownList>
                            <input type="hidden" class="REQUIRED" value="请填写职级" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">薪金幅度</td>
                        <td class="tl PL10">
                            <asp:TextBox ID="Remuneration" runat="server" Width="100"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写薪金幅度" /></td>
                        <td class="auto-style4">需求人数</td>
                        <td class="tl PL10">
                            <asp:TextBox ID="Number" runat="server" Width="100"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写需求人数" /></td>
                        <td class="auto-style4">期望到职日期</td>
                        <td class="tl PL10">
                            <asp:TextBox ID="TakeOfficeDate" runat="server" Width="100"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写期望到职日期" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="text-align: left; text-indent: 10px; font-size: 14px"><b>招聘原因</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">招聘类别</td>
                        <td class="tl PL10" colspan="5">
                            <input type="radio" id="AddType1" name="rdAddType" value="1" onclick="AddTypeOnChange(this)" /><label for="AddType1">新增岗位</label>&nbsp;
                            <input type="radio" id="AddType2" name="rdAddType" value="2" onclick="AddTypeOnChange(this)" /><label for="AddType2">新增编制</label>&nbsp;
                            <input type="radio" id="AddType3" name="rdAddType" value="3" onclick="AddTypeOnChange(this)" /><label for="AddType3">补充原有编制空缺</label>&nbsp;
                            <input type="radio" id="AddType4" name="rdAddType" value="4" onclick="AddTypeOnChange(this)" /><label for="AddType4">重组原有编制</label>&nbsp;
                            <input type="radio" id="AddType5" name="rdAddType" value="5" onclick="AddTypeOnChange(this)" /><label for="AddType5">替换人员</label><br />
                            <asp:HiddenField ID="AddType" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" style="vertical-align: top">
                            <p style="margin: 5px">详细说明</p>
                        </td>
                        <td class="tl PL10" colspan="5">
                            <asp:TextBox ID="Remark" runat="server" Style="width: 98%; height: 100px; overflow: auto" TextMode="MultiLine"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写详细说明" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>岗位职责</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6">
                            <asp:TextBox ID="Duty" runat="server" Style="width: 98%; height: 100px; overflow: auto" TextMode="MultiLine"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写岗位职责" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>资格要求</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">性&nbsp;&nbsp;&nbsp;&nbsp;别</td>
                        <td class="tl PL10">
                            <input type="radio" name="rbSex" id="Sex0" onclick="SexClick(this);" value="0" /><label for="Sex0">男</label>
                            <input type="radio" name="rbSex" id="Sex1" onclick="SexClick(this);" value="1" /><label for="Sex1">女</label>
                            <input type="radio" name="rbSex" id="Sex2" onclick="SexClick(this);" value="2" /><label for="Sex2">不限</label>
                            <asp:HiddenField ID="Sex" runat="server" />
                        </td>
                        <td class="auto-style4">年&nbsp;&nbsp;&nbsp;&nbsp;龄</td>
                        <td class="tl PL10">
                            <asp:TextBox ID="Age" runat="server" Width="100"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写年龄" />
                        </td>
                        <td class="auto-style4">性&nbsp;&nbsp;&nbsp;&nbsp;格</td>
                        <td class="tl PL10">
                            <asp:TextBox ID="Character" runat="server" Width="100"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写性格" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">专&nbsp;&nbsp;&nbsp;&nbsp;业</td>
                        <td class="tl PL10" colspan="3">
                            <asp:TextBox ID="Major" runat="server" Style="width: 92%"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写专业" />
                        </td>
                        <td class="auto-style4">学&nbsp;&nbsp;&nbsp;&nbsp;历</td>
                        <td class="tl PL10">
                            <asp:TextBox ID="Education" runat="server" Style="width: 92%"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写学历" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">要&nbsp;&nbsp;&nbsp;&nbsp;求</td>
                        <td class="tl PL10" colspan="5">
                            <asp:TextBox ID="Requirement" runat="server" Style="width: 98%; height: 100px; overflow: auto" TextMode="MultiLine"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写要求" />
                        </td>
                    </tr>

                </table>
                <p style="text-align: left">
                    备注说明：<br />
                    申请非全日制用工、实习生：实习生、兼职、暑期工等均属于非正式员工，凡申请聘请非正式员工，<br />
                    请注明需聘请之具体原因、工作职责、用工起止时间、付款方式（现金或过账）等
                </p>
            </div>
            <!--人才需求表end-->

            <!--工作岗位说明书-->
            <div id="DMOS" style="width: 640px; margin: 0px auto;">
                <table id="tbAround2" width='640px' style="table-layout: fixed">
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 16px"><b>工作岗位说明书</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>基本信息</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">岗位名称</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwName" runat="server" Width="90"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写岗位名称" />
                        </td>
                        <td class="auto-style4">所属部门</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwDepartment" runat="server" Width="90"></asp:TextBox><input type="hidden" id="hdgwdDepartmentID" runat="server" />
                            <input type="hidden" class="REQUIRED" for="ctl00_ContentPlaceHolder1_gwDepartment" value="请填写所属部门" />
                        </td>
                        <td class="auto-style4">本岗编制人数</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwNumber" runat="server" Width="90"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写本岗编制人数" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">职级</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <%--<asp:TextBox ID="gwGrade" runat="server" Width="100"></asp:TextBox>--%>
                            <asp:DropDownList ID="gwGrade" runat="server">
                                <asp:ListItem Value="">请选择</asp:ListItem>
                                <asp:ListItem Value="1">1级</asp:ListItem>
                                <asp:ListItem Value="2">2级</asp:ListItem>
                                <asp:ListItem Value="3">3级</asp:ListItem>
                                <asp:ListItem Value="4">4级</asp:ListItem>
                                <asp:ListItem Value="5">5级</asp:ListItem>
                                <asp:ListItem Value="6">6级</asp:ListItem>
                                <asp:ListItem Value="7">7级</asp:ListItem>
                                <asp:ListItem Value="8">8级</asp:ListItem>
                                <asp:ListItem Value="9">9级</asp:ListItem>
                                <asp:ListItem Value="10">10级</asp:ListItem>
                            </asp:DropDownList>
                            <input type="hidden" class="REQUIRED" value="请填写职级" />
                        </td>
                        <td class="auto-style4">本岗位性质</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwNature" runat="server" Width="90"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写本岗位性质" />
                        </td>
                        <td class="auto-style4">下属岗位数</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwPostNumber" runat="server" Width="90"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写下属岗位数" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">薪酬标准</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwRemuneration" runat="server" Width="90"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写薪酬标准" />
                        </td>
                        <td class="auto-style4">编写日期</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwApplyDate" runat="server" Width="90"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写编写日期" />
                        </td>
                        <td class="auto-style4">编写部门</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwApplyDepartment" runat="server" Width="90"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" for="ctl00_ContentPlaceHolder1_gwApplyDepartment" value="请填写编写部门" />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>工作关系</b></td>
                    </tr>
                    <tr>
                        <td class="tl PL10" colspan="6">
                            <p>1、组织架构：</p>
                            <img id="imgOrganizationStructure" alt="" style="display: none; width: 90%" />
                            <span id="uploadify"></span>
                            <asp:HiddenField ID="gwOrganizationStructure" runat="server" />
                            <p><b>内部接触、协调部门：</b><asp:TextBox ID="gwCoordinateDepartment" runat="server" Style="width: 78%"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写内部接触、协调部门" /></p>
                            <p><b>外部接触、协调机构：</b><asp:TextBox ID="gwCoordinateOrganization" runat="server" Style="width: 78%"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写外部接触、协调机构" /></p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tl PL10" colspan="6">2、所受监督：<asp:TextBox ID="gwSuperintended" runat="server" Style="width: 85%"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写所受监督" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tl PL10" colspan="6">3、所施监督：<asp:TextBox ID="gwSuperintend" runat="server" Style="width: 85%"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写所施监督" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>岗位目的</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6">
                            <asp:TextBox ID="gwPurpose" runat="server" Style="width: 98%; height: 100px; overflow: auto" TextMode="MultiLine"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写岗位目的" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>工作职责</b></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="padding: 0">
                            <table id="tbAround4" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th style="width: 208px">描述</th>
                                        <th style="width: 52px">负责程度</th>
                                        <th style="width: 40px">周期</th>
                                        <th>绩效标准</th>
                                        <th style="width: 90px">工作比重（%）</th>
                                    </tr>
                                </thead>
                                <tbody id="gwzzdetail">
                                    <tr>
                                        <td>
                                            <input type="text" style="width: 200px" name="Desc" /></td>
                                        <td>
                                            <input type="text" style="width: 44px" name="Responsibility" title="根据岗位对此项工作的参与程度，可分为：全权、负责、协助、参与四个等级" /></td>
                                        <td>
                                            <input type="text" style="width: 32px" name="Cycle" title="根据此项工作的开展周期，可分为日、周、月度、季度、年度、偶尔和随时" /></td>
                                        <td>
                                            <input type="text" style="width: 96%" name="Performance" title="请尽可能以数据做说明" /></td>
                                        <td>
                                            <input type="text" style="width: 82px" name="WorkRate" /></td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="5" style="text-align: left">
                                            <input class="btnaddRow" type="button" value="添加新行" onclick="addrow('gwzzdetail'); return false;" />
                                            <input class="btnaddRow" type="button" value="删除一行" onclick="delrow('gwzzdetail'); return false;" />
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                            <asp:HiddenField ID="hidDetail1" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>其他职责</b></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="padding: 0">
                            <table id="tbAround5" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th style="width: 208px">描述</th>
                                        <th style="width: 52px">负责程度</th>
                                        <th style="width: 40px">周期</th>
                                        <th>绩效标准</th>
                                        <th style="width: 90px">工作比重（%）</th>
                                    </tr>
                                </thead>
                                <tbody id="gwotherzzdetail">
                                    <tr>
                                        <td>
                                            <input type="text" style="width: 200px" name="Desc" /></td>
                                        <td>
                                            <input type="text" style="width: 44px" name="Responsibility" title="根据岗位对此项工作的参与程度，可分为：全权、负责、协助、参与四个等级" /></td>
                                        <td>
                                            <input type="text" style="width: 32px" name="Cycle" title="根据此项工作的开展周期，可分为日、周、月度、季度、年度、偶尔和随时" /></td>
                                        <td>
                                            <input type="text" style="width: 96%" name="Performance" title="请尽可能以数据做说明" /></td>
                                        <td>
                                            <input type="text" style="width: 82px" name="WorkRate" /></td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="5" style="text-align: left">
                                            <input class="btnaddRow" type="button" value="添加新行" onclick="addrow('gwotherzzdetail'); return false;" />
                                            <input class="btnaddRow" type="button" value="删除一行" onclick="delrow('gwotherzzdetail'); return false;" />
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                            <asp:HiddenField ID="hidDetail2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>岗位权限</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6">
                            <%--<textarea style="width: 98%; height: 100px; overflow: auto"></textarea>--%>
                            <asp:TextBox ID="gwPower" runat="server" Style="width: 98%; height: 100px; overflow: auto" TextMode="MultiLine"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写岗位权限" />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>任职资格</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">最佳学历</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwBestEducation" runat="server" Width="100"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写最佳学历" />
                        </td>
                        <td class="auto-style4">最低学历</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwLowestEducation" runat="server" Width="100"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写最低学历" />
                        </td>
                        <td class="auto-style4">性别要求</td>
                        <td class="tl PL10">
                            <%--<input type="text" style="width: 100px" />--%>
                            <asp:TextBox ID="gwCharacterRequire" runat="server" Width="100"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写性别要求" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">专业要求</td>
                        <td class="tl PL10" colspan="5">
                            <%--<input type="text" style="width: 98%" />--%>
                            <asp:TextBox ID="gwMajorRequire" runat="server" Style="width: 98%"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写专业要求" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">资格证书</td>
                        <td class="tl PL10" colspan="5">
                            <%--<input type="text" style="width: 98%" />--%>
                            <asp:TextBox ID="gwQualificationCertificate" runat="server" Style="width: 98%"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写资格证书" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">相关工作经验</td>
                        <td class="tl PL10" colspan="5">
                            <%--<textarea style="width: 98%; height: 100px; overflow: hidden"></textarea>--%>
                            <asp:TextBox ID="gwWorkExp" runat="server" Style="width: 98%; overflow: auto" TextMode="MultiLine"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写相关工作经验" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">计算机要求</td>
                        <td class="tl PL10" colspan="5">
                            <%--<input type="text" style="width: 98%" />--%>
                            <asp:TextBox ID="gwComputerRequire" runat="server" Style="width: 98%"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写计算机要求" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">年龄要求</td>
                        <td class="tl PL10" colspan="5">
                            <%--<input type="text" style="width: 98%" />--%>
                            <asp:TextBox ID="gwAgeRequire" runat="server" Style="width: 98%"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写年龄要求" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">其他要求</td>
                        <td class="tl PL10" colspan="5">
                            <%--<input type="text" style="width: 98%" />--%>
                            <asp:TextBox ID="gwOtherRequire" runat="server" Style="width: 98%"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写其他要求" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>工作设备</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6">
                            <%--<textarea style="width: 98%; height: 80px; overflow: auto"></textarea>--%>
                            <asp:TextBox ID="gwWorkEquipment" runat="server" Style="width: 98%; height: 80px; overflow: auto" TextMode="MultiLine"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写工作设备" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>工作环境</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="text-align: left; text-indent: 8px">
                            <p>
                                1、工作场所：<%--<input type="text" style="width: 80%" />--%>
                                <asp:TextBox ID="gwWorkSpace" runat="server" Style="width: 80%"></asp:TextBox>
                                <input type="hidden" class="REQUIRED" value="请填写工作场所" />
                            </p>
                            <p>
                                2、工作环境：<%--<input type="text" style="width: 80%" />--%>
                                <asp:TextBox ID="gwWorkEnvironment" runat="server" Style="width: 80%"></asp:TextBox>
                                <input type="hidden" class="REQUIRED" value="请填写工作环境" />
                            </p>
                            <p>
                                3、危 险 性：有无职业病危险&nbsp;<input type="radio" id="gwIsDanger1" value="1" name="gwIsDanger" onclick="IsDangerClick(this)" />有&nbsp;<input type="radio" id="gwIsDanger0" value="0" name="gwIsDanger" onclick="    IsDangerClick(this)" />否
                                <asp:HiddenField ID="gwIsDanger" runat="server" />
                                <input type="hidden" class="REQUIRED" value="请选择有无职业病危险" />
                            </p>
                            <p>4、工作时间：<%--<input type="text" />--%><asp:TextBox ID="gwWorkTime" runat="server"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写工作时间" /></p>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>劳动强度</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6">
                            <%--<textarea style="width: 98%; height: 80px; overflow: auto"></textarea>--%>
                            <asp:TextBox ID="gwWorkStrength" runat="server" Style="width: 98%; height: 80px; overflow: auto" TextMode="MultiLine"></asp:TextBox>
                            <input type="hidden" class="REQUIRED" value="请填写劳动强度" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="font-size: 14px; text-align: left; text-indent: 10px"><b>职位关系</b></td>
                    </tr>
                    <tr>
                        <td class="auto-style4" colspan="6" style="text-align: left; text-indent: 8px">
                            <p>可直接晋升的职位：<asp:TextBox ID="gwUpgradeTo" runat="server" Style="width: 80%"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写可直接晋升的职位" /></p>
                            <p>可相互轮换的职位：<asp:TextBox ID="gwChangeTo" runat="server" Style="width: 80%"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写可相互轮换的职位" /></p>
                            <p>可晋升至此的职位：<asp:TextBox ID="gwUpgradeForm" runat="server" Style="width: 80%"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写可晋升至此的职位" /></p>
                            <p>&nbsp;&nbsp;可&nbsp;降&nbsp;级&nbsp;的&nbsp;职&nbsp;位：<asp:TextBox ID="gwDegradeTo" runat="server" Style="width: 80%"></asp:TextBox><input type="hidden" class="REQUIRED" value="请填写可降级的职位" /></p>
                        </td>
                    </tr>
                </table>
                <div style="width: 640px; margin: 0px auto; text-align: left; line-height: 22px">
                    <p>
                        备注说明：<br />
                        1.	本表可用于任用标准之制定、新入职人员培训、绩效考核及制定薪酬之检讨。<br />
                        2.	本表是针对完成该项工作所必须的知识、技能，而非任职者本身的状况。<br />
                        3.	本表经用人部门编写，由部门负责人确认后，高层管理级核准方可生效。
                     
                    </p>
                </div>
            </div>
            <!--工作岗位说明书end-->

            <asp:Panel ID="plHRHandle" runat="server" Style="padding-bottom: 15px" Visible="false">
                <table class="tbflows" cellspacing="0" cellpadding="0" width='640px'>
                    <thead>
                        <tr>
                            <td colspan="6"><b>入职处理：</b></td>
                        </tr>
                        <tr>
                            <td>入职部门</td>
                            <td>入职岗位</td>
                            <td>入职者姓名</td>
                            <td>入职日期</td>
                            <td>薪金</td>
                            <td>职级</td>
                        </tr>
                    </thead>
                    <tbody id="HRHandlebody">
                        <tr>
                            <td>
                                <input class="txtdep" style="width: 130px" name="dep" /></td>
                            <td>
                                <input class="txtpos" style="width: 100px" name="pos" /></td>
                            <td>
                                <input class="txtname" style="width: 70px" name="name" /></td>
                            <td>
                                <input class="txtdate" style="width: 100px" name="date" /></td>
                            <td>
                                <input class="txtpayment" style="width: 80px" name="payment" /></td>
                            <td>
                                <input class="txtgrade" style="width: 50px" name="grade" /></td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="6" style="text-align: left">
                                <input class="btnaddRowN" type="button" value="添加新行" onclick="addrowHR(this,null)" /><input class="btnaddRowN" type="button" onclick="    ddelrow('HRHandlebody')" value="删除一行" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: left">
                                <asp:Button ID="btnHRSave" runat="server" OnClick="HRSave_Click" OnClientClick="return HRSave();" Text="保存结果" CssClass="btnaddRowN" />
                            </td>
                        </tr>
                    </tfoot>
                </table>
                <asp:HiddenField ID="hidHRDetail" runat="server" />
            </asp:Panel>
            <!--审核-->
            <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0">
                <tr class="noborder" style="height: 85px;" idx="1">
                    <td class="auto-style2">申请人</td>
                    <td colspan="3" class="tl PL10" style="">
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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="2">
                    <td class="auto-style2">直属主管</td>
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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="3">
                    <td class="auto-style2">隶属主管</td>
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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;" idx="4" manager="true">
                    <td class="auto-style2">区域负责人</td>
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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px; display: none" idx="6">
                    <td class="auto-style2">首席运营官</td>
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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;" idx="7">
                    <td class="auto-style2" rowspan="2">人力资源部</td>
                    <td colspan="3" class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" /><label class="l signother">其他意见</label>
                         <%--   <asp:LinkButton ID="lbtnAddHQ" runat="server" Visible="False" OnClick="lbtnAddHQ_Click">添加后勤事务部审批</asp:LinkButton>
                            <asp:LinkButton ID="lbtnDelHQ" runat="server" Visible="False" OnClick="lbtnDelHQ_Click">去除后勤事务部审批</asp:LinkButton>--%>
                               <asp:LinkButton ID="lbtnAddHQ" runat="server" Visible="False" OnClick="lbtnAddHQ_Click">添加苏玲审批</asp:LinkButton>
                            <asp:LinkButton ID="lbtnDelHQ" runat="server" Visible="False" OnClick="lbtnDelHQ_Click">去除苏玲审批</asp:LinkButton>
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
                <tr class="noborder" style="height: 85px;" idx="8">

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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                   <tr class="noborder" style="height: 85px; display: none" idx="9">
                    <td class="auto-style2">营运支持总监</td>
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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px; display: none" idx="10">
                    <td class="auto-style2">后勤事务部</td>
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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                
                <tr class="noborder" style="height: 85px; display: none" idx="20">
                    <td class="auto-style2">董事总经理<br />
                        审批</td>
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
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>

                <%--复审 选填--%>
                <tr class="noborder" style="height: 85px; display: none" idx="200">
                    <td class="auto-style2">申请人回复审批意见<br />
                        （可选项）</td>
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
                            <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" OnClientClick="return signfs(this);" Text="确认" CssClass="signbtn" />
                        </div>
                    </td>
                </tr>
                <%--黄生复审--%>
                <tr class="noborder" style="height: 85px; display: none" idx="220">
                    <td class="auto-style2">董事总经理复审</td>
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
                            <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" OnClientClick="return signfs(this);" Text="确认" CssClass="signbtn" />
                        </div>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
            <!--审核-->
        </div>
        <!--打印正文结束-->

        <div class="noprint">
            <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" BackColor="White" Style="clear: both; margin-top: 3px;" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="false" ForeColor="Black" GridLines="Vertical" OnRowCommand="gvAttach_RowCommand">
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
                <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnTemp" Text="暂时保存" OnClick="btnTempSave_Click" CssClass="commonbtn" OnClientClick="return tempsavecheck();" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" OnClientClick="BackToSearch();return false;" />
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
        if("<%=EmployeeName%>" == "黄轩明"&&"<%=EmployeeID%>" == "0001")
        {
            $("#tbflows tr[Idx=5]").hide();
            $("#tbflows tr[Idx=6]").prepend('<td>人力资源部</td>');
        }
    </script>
    <%=SbJs.ToString() %>
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <%--<script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>--%>
</asp:Content>
