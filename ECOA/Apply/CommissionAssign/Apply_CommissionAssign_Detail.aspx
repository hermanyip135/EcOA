<%@ Page Title="项目部佣金分配指引 - 广东中原地产代理有限公司" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_CommissionAssign_Detail.aspx.cs" Inherits="Apply_CommissionAssign_Apply_CommissionAssign_Detail" %>

<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../../Script/uploadify/uploadify.css" type="text/css" />
    <script type="text/javascript" src="../../Script/uploadify/jquery.uploadify.min.js"></script>
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
        .uploadify{text-indent:0}

        #ExcelTB td{text-align:center;padding:5px}
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
            cDeleteT("<%=MainID %>","<%=ApplyN %>");
        }
    </script>
    <style type="text/css">
        input.readonly {
            background: rgb(227, 227, 227);
        }
    </style>
    <script type="text/javascript">
        //初始化
        function PageInit() {
            //签名方法事件初始化 common_new.js
            SignFunBind();

            //签名数据绑定
            FlowSignInit();

            //时间控件
            $("#<%=this.StartDate.ClientID%>").datepicker();

            //部门绑定
            var jJSON = <%=SbJson.ToString() %>;
            $("#<%=this.Department.ClientID %>").autocomplete({ source: jJSON });

            //产品类型绑定
            ProTypeBind();

            //代理类型数据绑定
            AgentTypeBind()

            //增加、修改
            ApplyTypeBind();

            //上传控件
            $("#uploadify").uploadify({
                'swf': '../../Script/uploadify/uploadify.swf',
                'uploader': '../../Ajax/UploadHandler.ashx?MainID=<%=MainID%>',
                //'cancelImg': '../../Script/uploadify/cancel.png',
                'buttonText': '上传解hold明细',
                'queueID': 'fileQueue',
                'fileTypeExts':'*.xls',
                'fileTypeDesc':'请选择xls文件',
                'auto': true,
                'multi': false,
                'width':100,
                onDialogClose: onDialogClose,
                onCancel: onDialogClose,
                onUploadSuccess: onUploadSuccess
            });

            //Excel表格显示
            var info = $("#<%=this.hidDetail.ClientID%>").val();
            //alert(info);
            WriteDetailTB(info);
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
            //obj.name
            readExcel(obj.name);
        }

        function readExcel(excelurl)
        {
            $.ajax({
                url: "ReadExcel_Handler.ashx?MainID=<%=MainID%>",
                type: "post",
                dataType: "text",
                data: { 'path' : excelurl },
                success: function(info) {
                    try{
                        $("#<%=this.hidDetail.ClientID%>").val(info);
                        //alert(info);
                        WriteDetailTB(info);
                    }
                    catch(e)
                    {
                        alert(e);
                    }
                }
                
            });
            return false;
        }

        function WriteDetailTB(data)
        {
            if(data == null || data == "" || data == undefined)
            {
                return;
            }
            var obj = eval("(" + data + ")");       //转json
            var html = "";
            html = "<table id='ExcelTB' class='tbflows' style='width:100%' cellspacing='0' cellpadding='0'>";
            html += "<tr><th>类别</th><th>职位</th><th>工号</th><th>姓名</th><th>销售代理项目</th><th>策划/顾问项目</th><th>其他</th></tr>";
            for(var i = 0; i < obj.length; i++)
            {
                html += "<tr>";
                html += "<td>" + obj[i].OfficeAutomation_Document_CommissionAssign_Detail_Class + "</td>";
                html += "<td>" + obj[i].OfficeAutomation_Document_CommissionAssign_Detail_Position + "</td>";
                html += "<td>" + obj[i].OfficeAutomation_Document_CommissionAssign_Detail_EmpoyeeID + "</td>";
                html += "<td>" + obj[i].OfficeAutomation_Document_CommissionAssign_Detail_Empoyee + "</td>";
                html += "<td>" + obj[i].OfficeAutomation_Document_CommissionAssign_Detail_AgentProject + "</td>";
                html += "<td>" + obj[i].OfficeAutomation_Document_CommissionAssign_Detail_AdviserProject + "</td>";
                html += "<td>" + obj[i].OfficeAutomation_Document_CommissionAssign_Detail_OtherProject + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            $("#TB").html(html);
            autoRowSpan($("#ExcelTB").get(0),0,0);  //合并单元格
            autoRowSpan($("#ExcelTB").get(0),1,0);  //合并单元格
        }
        function autoRowSpan(tb,row,col)
        {
            var lastValue="";
            var value="";
            var pos=1;
            for(var i=row;i<tb.rows.length;i++){
                value = tb.rows[i].cells[col].innerText;
                if(lastValue == value){
                    tb.rows[i].deleteCell(col);
                    tb.rows[i-pos].cells[col].rowSpan = tb.rows[i-pos].cells[col].rowSpan+1;
                    pos++;
                }else{
                    lastValue = value;
                    pos=1;
                }
            }
        } 

        function check() {
            var flag = false;
            //alert($("#<%=this.hidDetail.ClientID%>").val());
            //return false;
            //在必填项后增加input class="REQUIRED" 项用以控制是否必填
            flag = REQUIRED_Check();    //common_new.js
            if (!flag) {
                return false;
            }

            //增加、更改
            flag = false;
            var val = "";
            $("input[name='r']").each(function(){
                if(this.checked)
                {
                    flag = true;
                    val = this.value;
                }
            });
            if(!flag)
            {
                alert("请选择增加、更改");
                $("#r1").focus();
                return false;
            }
            $("#<%=this.AssignType.ClientID%>").val(val);


            if($("#c10").get(0).checked)
            {
                if($.trim($("#<%=this.AgentTypeAmount.ClientID%>").val()) == "")
                {
                    alert("请填写策划/顾问代理(金额)");
                    $("#<%=this.AgentTypeAmount.ClientID%>").focus();
                    return false;
                }
            }

            if($("#c7").get(0).checked)
            {
                if($.trim($("#<%=this.ProTypeOther.ClientID%>").val()) == "")
                {
                    alert("请填写其他");
                    $("#<%=this.ProTypeOther.ClientID%>").focus();
                    return false;
                }
            }

            if($("#c11").get(0).checked)
            {
                if($.trim($("#<%=this.AgentTypeOther.ClientID%>").val()) == "")
                {
                    alert("请填写其他");
                    $("#<%=this.AgentTypeOther.ClientID%>").focus();
                    return false;
                }
            }

            //产品类型
            flag = false;
            val = "";
            $("input[name='ProType']").each(function(){
                if(this.checked)
                {
                    flag = true;
                    val += this.value + "|";
                }
            });
            if(!flag)
            {
                alert("请选择产品类型");
                $("#c1").focus();
                return false;
            }
            if(val!="")
            {
                $("#<%=this.ProType.ClientID%>").val(val.substring(0,val.length-1));
            }

            //代理类型
            flag = false;
            val = "";
            $("input[name='AgentType']").each(function(){
                if(this.checked)
                {
                    flag = true;
                    val += this.value + "|";
                }
            });
            if(!flag)
            {
                alert("请选择代理类型");
                $("#c8").focus();
                return false;
            }
            if(val!="")
            {
                $("#<%=this.AgentType.ClientID%>").val(val.substring(0,val.length-1));
            }

            if($("#<%=this.hidDetail.ClientID%>").val() == "")
            {
                alert("请上传明细");
                return false;
            }
            return true;
        }
        function ProTypeOtherClick(e)
        {
            if(e.checked)
            {
                $("#<%=this.ProTypeOther.ClientID%>").removeClass("readonly").removeAttr("readonly");
            }
            else
            {
                $("#<%=this.ProTypeOther.ClientID%>").addClass("readonly").attr("readonly","readonly").val("");
            }
        }

        //产品类型绑定
        function ProTypeBind()
        {
            var ProType = $("#<%=this.ProType.ClientID%>").val();
            if(ProType == "" || ProType == "null" || ProType== undefined)
            {
                $("input[name='ProType']").each(function(){
                    this.checked = false;
                });
                ProTypeOtherClick($("#c7").get(0));
                return;
            }
            var array = ProType.split("|");
            for(var i = 0; i < array.length; i++)
            {
                $r = $("input[name='ProType'][value=" + array[i] + "]");
                if($r != undefined)
                {
                    $r.get(0).checked = true;
                }
            }
            ProTypeOtherClick($("#c7").get(0));
        }

        //顾问代理(金额)点中
        function AgentTypeAmountClick(e)
        {
            if(e.checked)
            {
                $("#<%=this.AgentTypeAmount.ClientID%>").removeClass("readonly").removeAttr("readonly");
            }
            else
            {
                $("#<%=this.AgentTypeAmount.ClientID%>").addClass("readonly").attr("readonly","readonly").val("");
            }
        }

        //代理类型（其他）点中
        function AgentTypeOtherClick(e)
        {
            if(e.checked)
            {
                $("#<%=this.AgentTypeOther.ClientID%>").removeClass("readonly").removeAttr("readonly");
            }
            else
            {
                $("#<%=this.AgentTypeOther.ClientID%>").addClass("readonly").attr("readonly","readonly").val("");
            }
        }

        //代理类型数据绑定
        function AgentTypeBind()
        {
            var AgentType = $("#<%=this.AgentType.ClientID%>").val();
            if(AgentType == "" || AgentType == "null" || AgentType== undefined)
            {
                $("input[name='AgentType']").each(function(){
                    this.checked = false;
                });
                AgentTypeAmountClick($("#c10").get(0));
                AgentTypeOtherClick($("#c11").get(0));
                return;
            }
            var array = AgentType.split("|");
            for(var i = 0 ; i < array.length ; i++)
            {
                $r = $("input[name='AgentType'][value=" + array[i] + "]");
                if($r != undefined)
                {
                    $r.get(0).checked = true;
                }
            }
            AgentTypeAmountClick($("#c10").get(0));
            AgentTypeOtherClick($("#c11").get(0));
        }

        //增加、修改
        function ApplyTypeBind()
        {
            var ApplyType = $("#<%=this.AssignType.ClientID%>").val();
            if(ApplyType == "")
            {
                $("input[name='r']").each(function(){
                    this.checked = false;
                });
                return;
            }
            else{
                $r = $("#r" + ApplyType);
                if($r != undefined)
                {
                    $r.get(0).checked = true;
                }
            }
        }

        //暂时保存时获取单选按钮，产品类型、代理类型的值
        function getvalue()
        {
            var val = "";
            var valprotype="";
            var valagenttype="";
            $("input[name='r']").each(function(){
                if(this.checked)
                {
                    val = this.value;
                }
            });
            $("#<%=this.AssignType.ClientID%>").val(val);

            $("input[name='ProType']").each(function(){
                if(this.checked)
                {
                    valprotype += this.value + "|";
                }
            });
            $("#<%=this.ProType.ClientID%>").val(valprotype.substring(0,valprotype.length-1));

            $("input[name='AgentType']").each(function(){
                if(this.checked)
                {
                    valagenttype += this.value + "|";
                }
            });
            $("#<%=this.AgentType.ClientID%>").val(valagenttype.substring(0,valagenttype.length-1));
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
            <h1>项目部佣金分配指引</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td class="auto-style4">收文部门</td>
                    <td class="tl PL10">
                        <asp:Label ID="ReceiveDepartment" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">发文编号</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="ApplyID" runat="server" requiredmes="请填写发文编号"></asp:TextBox>
                        <%--<input type="hidden" class="REQUIRED" value="请填写发文编号" />--%>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">发文部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="Department" runat="server" requiredmes="请选择发文部门"></asp:TextBox>
                        
                    </td>
                    <td class="auto-style4">填写人员</td>
                    <td class="tl PL10">
                        <asp:Label ID="Apply" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">申请人</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="Applicant" runat="server" requiredmes="请填写申请人"></asp:TextBox>
                        <%--<input type="hidden" class="REQUIRED" value="请填写申请人" />--%>
                    </td>
                    <td class="auto-style4">填写日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="ApplyDate" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">文件主题</td>
                    <td class="tl PL10">关于<asp:TextBox ID="Subject" runat="server" requiredmes="请填写文件主题"></asp:TextBox><%--<input type="hidden" class="REQUIRED" value="请填写文件主题" />--%>佣金分配指引

                    </td>
                    <td class="auto-style4">电话</td>
                    <td class="tl PL10">020-<asp:TextBox ID="Phone" runat="server" requiredmes="请填写电话"></asp:TextBox><%--<input type="hidden" class="REQUIRED" value="请填写电话" />--%>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">项目名称</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="ProName" runat="server" style="width: 200px" requiredmes="请填写项目名称"></asp:TextBox><%--<input type="hidden" class="REQUIRED" value="请填写项目名称" />--%>
                    </td>
                    <td class="auto-style4">佣金分配<br />
                        指引编号</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="AssignNo" runat="server" style="width: 200px" requiredmes="请填写佣金分配指引编号" ></asp:TextBox><%--<input type="hidden" class="REQUIRED" value="请填写佣金分配指引编号" />--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; text-indent: 15px">
                        <p>
                            <input type="radio" id="r1" name="r" value="1" /><label for="r1">新增</label><input type="radio" id="r2" name="r" value="2" /><label for="r2">更改</label>
                            <asp:HiddenField ID="AssignType" runat="server" />
                        </p>
                        <p>
                            产品类型:
                            <input type="checkbox" id="c1" value="1" name="ProType" /><label for="c1">住宅</label>
                            <input type="checkbox" id="c2" value="2" name="ProType" /><label for="c2">公寓</label>
                            <input type="checkbox" id="c3" value="3" name="ProType" /><label for="c3">写字楼</label>
                            <input type="checkbox" id="c4" value="4" name="ProType" /><label for="c4">商铺</label>
                            <input type="checkbox" id="c5" value="5" name="ProType" /><label for="c5">车位</label>
                            <input type="checkbox" id="c6" value="6" name="ProType" /><label for="c6">别墅</label>
                            <input type="checkbox" id="c7" value="7" name="ProType" onclick="ProTypeOtherClick(this)" /><label for="c7">其他</label>
                            <asp:TextBox ID="ProTypeOther" runat="server" CssClass="readonly" ></asp:TextBox>
                            <asp:HiddenField ID="ProType" runat="server" />
                        </p>
                        <p>
                            代理类型:
                            <input type="checkbox" id="c8" name="AgentType" value="1" /><label for="c8">销售代理</label>
                            <input type="checkbox" id="c9" name="AgentType" value="2" /><label for="c9">招商代理</label>
                            <input type="checkbox" id="c10" name="AgentType" onclick="AgentTypeAmountClick(this)" value="3" /><label for="c10">策划/顾问代理(金额)<asp:TextBox ID="AgentTypeAmount" runat="server" CssClass="readonly" style="width:100px" ></asp:TextBox></label>
                            <input type="checkbox" id="c11" name="AgentType" onclick="AgentTypeOtherClick(this);" value="4" /><label for="c11">其他<asp:TextBox ID="AgentTypeOther" runat="server" CssClass="readonly" style="width:90px" ></asp:TextBox></label>
                            <asp:HiddenField ID="AgentType" runat="server" />
                        </p>
                        <p>
                            本方案由<asp:TextBox ID="StartDate" runat="server" style="width: 200px" requiredmes="请填写开始执行时间" ></asp:TextBox><%--<input type="hidden" class="REQUIRED" value="请填写开始执行时间" />--%>起开始执行
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; text-indent: 15px">
                        <div id="TB"></div>
                        <asp:HiddenField ID="hidDetail" runat="server" />
                        <p>请按此格式（<a style="color: blue" href="temp/导入模版-20160620095555.xls">EXCEL版空白详细表</a>)下载，编辑后 为附件，将自动导入 </p>
                        <p style="padding-left:15px"><span id="uploadify"></span></p>
                        <p>备注：财务部须对以上数据进行复核。</p>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left">
                        <p style="color: #F00; padding: 0 15px">
                            备注：<br />
                            1、各当事人签署后视为接受该层级的佣金分配比例，公司原则上不允许任何层级在各职位佣金中额外抽取。<br />
                            2、如遇各职位发生比例变动，则增减方都需重新申请。
                        </p>
                    </td>
                </tr>
            </table>
            <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0">
                <%--<tr class="noborder" style="height: 85px;" idx="1">
                    <td class="auto-style2">申请人</td>
                    <td colspan="3" class="tl PL10" style="">
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
                </tr>--%>
                <tr class="noborder" style="height: 85px;" idx="2">
                    <td class="auto-style2">行政组</td>
                    <td colspan="3" class="tl PL10">
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
                    <td class="auto-style2">部门主管</td>
                    <td colspan="3" class="tl PL10">
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
                <tr class="noborder" style="height: 85px;" idx="4">
                    <td class="auto-style2">二级市场总经理</td>
                    <td colspan="3" class="tl PL10">
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
            </table>
            <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
            <!--打印正文结束-->
        </div>

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
                <asp:button runat="server" id="btnTemp" text="暂时保存" onclick="btnTemp_Click" OnClientClick="return getvalue();" CssClass="commonbtn" />
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
    <%=SbJs.ToString() %>
</asp:Content>
