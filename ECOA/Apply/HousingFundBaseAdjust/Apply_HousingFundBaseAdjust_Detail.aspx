<%@ Page Title="公积金缴存基数年度调整申请表(营业部) - 广州中原电子审批系统" Language="C#" AutoEventWireup="true" CodeFile="Apply_HousingFundBaseAdjust_Detail.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Apply_HousingFundBaseAdjust_Apply_HousingFundBaseAdjust_Detail" %>

<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.Apply.ClientID%>").html(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
        }

        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>", "<%=ApplyN %>");
        }
    </script>
    <style type="text/css">
        select.readonly, input.readonly {
            background: rgb(227, 227, 227);
        }

        .tbflows .input {
            border: 1px solid #98b8b5;
        }
    </style>
    <script type="text/javascript">
        //添加行
        function addrowsp(e, idname, obj) {
            var copytr = $("#" + idname + " .tbflows").first().clone();
            var index = $("#" + idname + " .tbflows").length;       //总table数

            //初始化input
            $r = copytr.find("input[type=radio]");
            $r.each(function () {
                $(this).get(0).checked =false;
                $(this).attr("name", "raBase" + index)
            })
            $t = copytr.find("input[type=text]");
            $t.each(function () {
                $(this).val("");
                if ($(this).attr("name") != "Code" && $(this).attr("name") != "Reason") {
                    $(this).addClass("readyonly").attr("readonly", "readonly");
                }
            });

            if (obj != null) {
                trinit(copytr, obj);
            }

            $("#" + idname).append(copytr);
            //return;
        }

        function trinit(e, obj) {

            e.find("span[name='PayMonth']").text(obj.PayMonth);
            // e.find("select[name='PayRate']").val(obj.PayRate);
            e.find("input[name='BaseText']").val(obj.BaseText);
            e.find("input[name='Reason']").val(obj.Reason);
            e.find("input[name^='raBase'][value=" + obj.ChoiceBase + "]").get(0).checked = true;
            //给其他text赋值
            e.find("input[name='Name']").val(obj.Name);
            e.find("input[name='Code']").val(obj.Code);
            e.find("input[name='InDate']").val(obj.InDate);
            e.find("input[name='Dep']").val(obj.Dep);
            e.find("input[name='Pos']").val(obj.Pos);
            e.find("input[name='Grade']").val(obj.Grade);
        }

        //删除行
        function delrowsp(name) {
            $tables = $("#" + name).find("table");
            if ($tables.length == 1) {
                alert("不能再删了");
                return;
            }
            $tables.last().remove();
        }

        //初始化
        function PageInitHouse() {
            //签名方法事件初始化 common_new.js
            SignFunBind();

            //签名数据绑定
            FlowSignInit();

            //明细
            var detail = $("#<%=this.hidHousingFundChange_Detail.ClientID%>").val();
            if (detail == undefined || detail == null || detail == "") {
                return;
            }
            var data = $.parseJSON(detail);
            //
            for (var i = 0 ; i < data.length ; i++) {
                var d = data[i];
                if (i == 0) {
                    trinit($("#rowtd .tbflows").first(), d);
                }
                else {
                    addrowsp(null, "rowtd", d);  //增加行
                }
            }
            //$("#rowtd .tbflows").first().remove();
        }

        function check() {
            var array = new Array();
            var flag = true;
            $("#rowtd .tbflows").each(function () {
                $text = $(this).find("input[name='Name'],input[name='Code'],input[name='InDate'],input[name='Dep'],input[name='Pos'],input[name='Grade']");

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

                if (!c) {
                    return false;
                }

                var temp = $(this).find("span[name='PayMonth']");
                json["PayMonth"] = temp.text();
                var val = "";
              $(this).find("input[name^='raBase']").each(function () {
                  if(this.checked)
                  {
                      val = this.value;
                  }
              })
              if (val == "")
              {
                  alert("请选择申请调整基数");
                  flag = false;
                  return false;
              }
              json["ChoiceBase"] = val;
                temp = $(this).find("input[name='BaseText']");
                if (temp.val() == "") {
                    alert("请确定等级");
                    temp.focus();
                    flag = false;
                    return false;
                }
                json["BaseText"] = temp.val();


                temp = $(this).find("input[name='Reason']");
                if (temp.val() == "") {
                    alert("请填写原因");
                    temp.focus();
                    flag = false;
                    return false;
                }
                json["Reason"] = temp.val();

                array.push(json);
            });

            if (!flag) {
                $("#<%=this.hidHousingFundChange_Detail.ClientID%>").val("");
                return false;
            }
            $("#<%=this.hidHousingFundChange_Detail.ClientID%>").val(Obj2str(array));
            return true;
        }

        //工号查询员工资料
        function getEmployee(e) {
            $tb = $(e).parent().parent().parent();
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + e.value,
                success: function (info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $tb.find("input[name='Name']").val(infos[1]);
                        $tb.find("input[name='InDate']").val(infos[6]);
                        $tb.find("input[name='Dep']").val(infos[2]);
                        $tb.find("input[name='Pos']").val(infos[4]);
                        $tb.find("input[name='Grade']").val(infos[5]);
                        if ("第 5 级职等" == infos[5])
                        {
                            $tb.find("input[name='BaseText']").val('以本市去年在岗职工月平均工资即8218元为缴存基数');
                        }
                        else if ("第 6 级职等" == infos[5] || "第 7 级职等" == infos[5])
                        {
                          
                            $tb.find("input[name='BaseText']").val('以本市去年在岗职工月平均工资的2倍即16436元为缴存基数')
                        }
                        else if ("第 8 级职等" == infos[5] || "第 9 级职等" == infos[5]) {
                            $tb.find("input[name='BaseText']").val('以本市去年在岗职工月平均工资的3倍即24654元为缴存基数')
                        }
                        else {
                            $tb.find("input[name='BaseText']").val("");
                        }
                       
                    }
                    else {
                        $tb.find("input[name='Name']").val("");
                        $tb.find("input[name='InDate']").val("");
                        $tb.find("input[name='Dep']").val("");
                        $tb.find("input[name='Pos']").val("");
                        $tb.find("input[name='Grade']").val("");
                        $tb.find("input[name='BaseText']").val("");
                    }
                }
            })
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
            <h1>公积金缴存基数年度调整申请表<(营业部)</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span></div>
            <table class="tbflows" style="width: 640px; margin: 0 auto" cellpadding="0" cellspacing="0">
                <tr>
                    <td id="rowtd" colspan="4" style="padding-top: 0">
                        <table class="tbflows" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="auto-style4" style="width: 100px">姓名</td>
                                <td class="tl PL10">
                                    <input type="text" name="Name" class="readonly input" readonly="readonly" emptymes="请填写姓名" /></td>
                                <td class="auto-style4">申请人工号</td>
                                <td class="tl PL10">
                                    <input type="text" name="Code" class="input" onblur="getEmployee(this);" emptymes="请填写工号" /></td>
                            </tr>
                            <tr>
                                <td class="auto-style4">入职日期</td>
                                <td class="tl PL10">
                                    <input type="text" name="InDate" class="readonly input" readonly="readonly" emptymes="请填写入职日期" /></td>
                                <td class="auto-style4">现任职部门</td>
                                <td class="tl PL10">
                                    <input type="text" name="Dep" class="readonly input" readonly="readonly" emptymes="请填写现任职部门" /></td>
                            </tr>
                            <tr>
                                <td class="auto-style4">现职位</td>
                                <td class="tl PL10">
                                    <input type="text" name="Pos" class="readonly input" readonly="readonly" emptymes="请填写现职位" /></td>
                                <td class="auto-style4">现职级</td>
                                <td class="tl PL10">
                                    <input type="text" name="Grade" class="readonly input" readonly="readonly" emptymes="请填写现职级" /></td>
                            </tr>
                            <tr>
                                <td class="auto-style4" rowspan="2">申请调整基数</td>
                                <td class="tl PL10" colspan="3" style="line-height: 220%">
                                    <div>
                                       <input type="radio" name="raBase" value="1" /><label>以基本工资为缴存基数 </label><br />
                                         <input type="radio" name="raBase" value="2" /><%--<label id="laBaseText"> </label>--%>
                                        <input type="text" name="BaseText" readonly="readonly" style="border:none;width:350px"/>
                                       <%-- <label>*申请时年份为 <asp:Label ID="PayMonth" name="PayMonth" runat="server"></asp:Label>年</label>
                                        <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*个人缴存比例</label>
                                        <select class="input" name="PayRate" ></select><label>%</label>--%>
                                    </div>
                                    <div>
                                        调整原因
                                        <input type="text" name="Reason" class="input" style="width: 400px" />
                                    </div>
                                    <div>
                                        本人已知悉，<asp:Label ID="PayMonth" name="PayMonth" runat="server"></asp:Label>年年度的公积金缴存基数将按本次的申请进行调整。
                                    </div>
                                </td>
                            </tr>
                            
                        </table>
                      <%--  <script type="text/javascript">

                            var s2 = $("select[name='PayRate']");
                            s2.append("<option value=''>请选择</option>");
                            for (var i = 8 ; i < 13 ; i++) {
                                s2.append("<option value='" + i + "'>" + i + "</option>");
                            }
                        </script>--%>
                    </td>
                    <asp:HiddenField ID="hidHousingFundChange_Detail" runat="server" />

                </tr>
                <tr>
                    <td colspan="4" style="text-align: left">
                        <input class="btnaddRow" type="button" value="添加新行" onclick="addrowsp(this, 'rowtd', null); return false;" />
                        <input class="btnaddRow" type="button" value="删除一行" onclick="delrowsp('rowtd'); return false;" />
                    </td>
                </tr>

                <tr>
                    <td colspan="4" style="text-align: left; text-indent: 15px">
                        <p>备注：</p>
                        <p>1、每年7月进行公积金年度调整工作，其他月份不调整；；</p>
                        <p>2、本申请表适用于营业部门5级及以上使用；</p>
                        <p>3、若员工在规定时间内没提交该申请表，将默认为以其基本工资为调整基数。</p>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="width: 80px">填写人</td>
                    <td class="tl PL10" style="width: 25%">
                        <asp:Label ID="Apply" runat="server"></asp:Label>
                        <asp:HiddenField ID="ApplyID" runat="server" />
                        <%--工号--%>
                        <asp:HiddenField ID="Department" runat="server" />
                        <%--部门--%>
                    </td>
                    <td class="auto-style4" style="width: 80px">填写日期</td>
                    <td class="tl PL10" style="width: 25%">
                        <asp:Label ID="ApplyDate" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <p></p>
            <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0">
               
                <tr class="noborder" style="height: 85px;" idx="4">
                    <td class="auto-style2">人力资源部</td>
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
    <script type="text/javascript">PageInitHouse();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>

</asp:Content>