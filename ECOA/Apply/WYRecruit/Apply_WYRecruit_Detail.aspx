<%@ Page Title="营业部自主招聘申请 - 广东中原地产代理有限公司" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_WYRecruit_Detail.aspx.cs" Inherits="Apply_WYRecruit_Apply_WYRecruit_Detail" %>
<%@ Register src="../../Common/FlowShow.ascx" tagname="FlowShow" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            cEditflowNew("<%=MainID %>",<%=type%>);   //common_new.js
        }
        //取消签名
        function CancelSign(idc) {
            cCancelSign(idc, "<%=this.hdCancelSign.ClientID%>","<%=this.btnCancelSign.ClientID%>");   //common_new.js
        }
        //签名事件
        function sign(e) {
            cSign(e, "<%=hdIsAgree.ClientID %>", "<%=hdSuggestion.ClientID %>", "<%=this.btnSign.ClientID %>","<%=this.hdIdx.ClientID%>");   //common_new.js
        }

        //签名内容绑定
        function FlowSignInit() {
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.txtApply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
        }

        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>", "<%=ApplyN %>");
        }
    </script>
    <style type="text/css">
        input.readonly{background:rgb(227, 227, 227)}
        /*52100*/
        [id*=btnHRSave][value="保存"]{ 
            background-image: url(/Images/bsm_save1.png); 
            height: 20px; 
            width: 30px; 
            font-size: 0px;
            cursor:pointer;
            color: #FFFFFF;
         }
        div#actualReimbursement {
            margin-top:10px;
            width:500px;
            height:25px;
            border:1px solid #98b8b5;
        }
        [id*=txtReimbursementAmount],[id*=txtReimbursementDate] {
            margin-top:2px;
        }
        /*52100*/
    </style>
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>
        $(function () {
            //初始化分行智能匹配
            $("#<%=txtUseBranch.ClientID %>").autocomplete({
                source: jJSON,
                select: function (event, ui) {
                    $("#<% =txtUseBranch.ClientID%>").val(ui.item.id);
                }
            });

            $('#<%=ddlRegion.ClientID %>').change(function(){
                if($('#<%=ddlRegion.ClientID %>').val()=="项目部")
                {
                    $("#manager").show();
                    $("#areamanager").hide();
                }else
                {
                    $("#manager").hide();
                    $("#areamanager").show();
                }
            });
        });
        //52100
        function saveReimbursement() {
            var amount = $('#<%=txtReimbursementAmount.ClientID %>').val();
            var time = $("#<%=txtReimbursementDate.ClientID%>").val();
            if ($.trim(amount) == "") {
                alert("请先填写实际报销金额！");
                $("#<%=txtReimbursementAmount.ClientID %>").focus();
            } else if ($.trim(time) == "")
            {
                alert("请先填写报销日期！");
                $("#<%=txtReimbursementAmount.ClientID %>").focus();
            }
            else {
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: "action=reimbursementsituation&id=<%=wyRecruit_ID %>&amount=" + amount + "&date=" + time,
                    success: function (info) {
                        if (info == 'success')
                            alert('保存成功');
                        else
                            alert('保存失败');
                    }
                })
            }
            return false;
        }
        function RecruitTypeOtherChange(e)
        {
            var $RecruitTypeOther = $("#RecruitTypeOther");
            if (e.checked) {
                $RecruitTypeOther.removeAttr("readonly").removeClass("readonly");
            }
            else {
                $RecruitTypeOther.attr("readonly", "readonly").addClass("readonly");
                $RecruitTypeOther.val("");
            }
        }

        function OrganizationNameChange(e)
        {
            if (e.value == "其他机构") {
                $("#OtherOrganizationName").removeAttr("readonly").removeClass("readonly");
            }
            else {
                $("#OtherOrganizationName").attr("readonly", "readonly").addClass("readonly");
                $("#OtherOrganizationName").val("");
            }
        }

        function getEmployee(n,flag) {
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function (info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        if (flag == "1")
                        {
                            $("#<%=this.txtApply.ClientID%>").val(infos[1]);
                            $("#<%=this.txtPosition.ClientID%>").val(infos[4]);
                            $("#<%=this.hidDepartment.ClientID%>").val(infos[2]);
                        }
                        else if (flag == "2")
                        {
                            $("#<%=this.txtSecretary.ClientID%>").val(infos[1]);
                            $("#<%=this.txtSecretaryDepartment.ClientID%>").val(infos[2]);
                        }
                    }
                    else {
                        if (flag == "1") {
                            $("#<%=this.txtApply.ClientID%>").val("");
                            $("#<%=this.txtPosition.ClientID%>").val("");
                            $("#<%=this.hidDepartment.ClientID%>").val("");
                        }
                        else if (flag == "2") {
                            $("#<%=this.txtSecretary.ClientID%>").val("");
                            $("#<%=this.txtSecretaryDepartment.ClientID%>").val("");
                        }
                    }
                }
            })
        }

        //初始化
        function PageInit()
        {
            //签名方法事件初始化 common_new.js
            SignFunBind();

            //签名数据绑定
            FlowSignInit();

            //时间控件
            $("#<%=this.txtStartDate.ClientID%>").datepicker();
            $("#<%=this.txtEndDate.ClientID%>").datepicker();
            $("#<%=txtReimbursementDate.ClientID%>").datepicker();

            //招聘形式 初始化
            var RecruitType = $("#<%=this.hidRecruitType.ClientID%>").val(); //"网络招聘||其他形式|dfdfd";
            if (RecruitType != undefined && RecruitType != "")
            {
                var RecruitTypes = RecruitType.split("|");
                if (RecruitTypes.length >= 4) {
                    for (var i = 0 ; i < RecruitTypes.length ; i++) {
                        if (i == 3) {
                            $("#RecruitTypeOther").val(RecruitTypes[i]);
                        }
                        else {
                            $("input[name='RecruitType'][value='" + RecruitTypes[i] + "']").prop("checked", "checked");
                            //其他形式被选中
                            if (i == 2 && RecruitTypes[i] == "其他形式")
                            {
                                $("#RecruitTypeOther").removeAttr("readonly").removeClass("readonly");  //可以填
                            }
                        }
                    }
                }
            }

            //举办机构名称
            var OrganizationName = $("#<%=this.hidOrganizationName.ClientID%>").val();
            if (OrganizationName != undefined && OrganizationName != "")
            {
                var array = OrganizationName.split("|");
                $("#<%=this.ddlOrganizationName.ClientID%>").val(array[0]);
                $("#OtherOrganizationName").val(array[1]);
                if (array[0] == "其他机构") {
                    $("#OtherOrganizationName").removeAttr("readonly").removeClass("readonly");
                }
                else {
                    $("#OtherOrganizationName").attr("readonly", "readonly").addClass("readonly");;
                }
            }
        }

        function check()
        {
            //使用分行
            if ($.trim($("#<%=txtUseBranch.ClientID%>").val()) == "")
            {
                alert("使用分行不可为空！");
                $("#<%=txtUseBranch.ClientID %>").focus();
                 return false;
            }
            //招聘形式
            if ($("#RecruitType3").get(0).checked && $.trim($("#RecruitTypeOther").val()) == "")
            {
                alert("请填写招聘形式其他形式内容");
                $("#RecruitTypeOther").focus();
                return false;
            }

            var flag = false;
            var html = "";
            $("input[name='RecruitType']").each(function () {
                if (this.checked) {
                    flag = true;
                    html += this.value + "|";
                }
                else {
                    html += "|";
                }
            });
            if (!flag) {
                alert("请选择招聘形式");
                $("#RecruitType1").focus();
                return false;
            }
            else {
                html += $("#RecruitTypeOther").val();   //其他形式
                $("#<%=this.hidRecruitType.ClientID%>").val(html);
            }

            //在必填项后增加input class="REQUIRED" 项用以控制是否必填
            flag = REQUIRED_Check();    //common_new.js
            if (!flag) {
                return false;
            }

            if ($("#<%=this.ddlOrganizationName.ClientID%>").val() == "其他机构" && $("#OtherOrganizationName").val() == "")
            {
                alert("请填写其他机构");
                $("#OtherOrganizationName").focus();
                return false;
            }
            var v = $("#<%=this.ddlOrganizationName.ClientID%>").val() + "|" + $("#OtherOrganizationName").val();
            $("#<%=this.hidOrganizationName.ClientID%>").val(v);

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="remindRight" style="float: right; width: 10%; padding-top: 75px; display:none; padding-left: 5px;  padding-right: 10px;">
        <span style="font-size: large; font-weight: bold;">申请流程：</span><br /><br />  
         <span>
        　　《1》<span>流程：区域经理（申请人 ）—区域总监—总助—区域负责人—人力资源部</span>；<br /><br />        
        　　《2》<span>流程：区域总监（申请人 ）—区域负责人—总助—区域负责人—人力资源部</span>；<br /><br />          
        　　《3》<span>流程：区域负责人（申请人 ）—区域负责人—总助—区域负责人—人力资源部</span>；<br /><br />   
        </span>
    </div>
            <div style='text-align: center; width: 840px; margin: 0 auto;'>
            <div class="noprint">
                <%=SbFlow.ToString() %>
                <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
                <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
            </div>
                <!--打印正文开始-->
                <div style='text-align: center'>
                    <h1>广东中原地产代理有限公司</h1>
                    <h1>营业部自主招聘申请</h1>
                    <asp:HiddenField ID="hidApplyDate" runat="server" />
                    <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
                    <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span></div>
                    <table id="tbAround" width='640px'>
                        <tr>
                            <td class="auto-style4">* 申请人工号</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtApplyID" runat="server" onblur="getEmployee(this,'1');" requiredmes="请填写申请人工号">
                                </asp:TextBox></td>
                            <td class="auto-style4">* 申请人姓名</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtApply" runat="server" CssClass="readonly" requiredmes="请填写申请人姓名（检查申请人工号是否正确）" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">* 职位名称</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtPosition" runat="server" CssClass="readonly" requiredmes="请填写职位名称（检查申请人工号是否正确）"></asp:TextBox>
                                <asp:HiddenField ID="hidDepartment" runat="server" />
                                
                            </td>
                            <td class="auto-style4">* 所属区域</td>
                            <td class="tl PL10">
                                <asp:DropDownList ID="ddlRegion" runat="server" requiredmes="选择所属区域">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem Value="大天河区">大天河区</asp:ListItem>
                                    <asp:ListItem Value="大海珠区">大海珠区</asp:ListItem>
                                    <asp:ListItem Value="大白云区">大白云区</asp:ListItem>
                                    <asp:ListItem Value="大越秀区">大越秀区</asp:ListItem>
                                    <asp:ListItem Value="番禺一部">番禺一部</asp:ListItem>
                                    <asp:ListItem Value="番禺二部">番禺二部</asp:ListItem>
                                    <asp:ListItem Value="花都区">花都区</asp:ListItem>
                                    <asp:ListItem Value="芳村南海区">芳村南海区</asp:ListItem>
                                    <asp:ListItem Value="工商铺一部">工商铺一部</asp:ListItem>
                                    <asp:ListItem Value="工商铺二部">工商铺二部</asp:ListItem>
                                    <asp:ListItem Value="项目部">项目部</asp:ListItem>
                                    <asp:ListItem Value="大番禺区">大番禺区</asp:ListItem>
                                    <asp:ListItem Value="海珠东区">海珠东区</asp:ListItem>
                                    <asp:ListItem Value="海珠西区">海珠西区</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td class="auto-style4">*使用分行/部门</td>
                            <td colspan="3" class="tl PL10">
                               <asp:TextBox ID="txtUseBranch" runat="server" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:left;text-indent:15px"><b style="color:red">物业部申请人必须为区域营业经理层级以上</b></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">*招聘形式</td>
                            <td class="tl PL10" colspan="3">
                                <input id="RecruitType1" name="RecruitType" type="checkbox" value="网络招聘" /><label for="RecruitType1">网络招聘</label>
                                <input id="RecruitType2" name="RecruitType" type="checkbox" value="现场招聘" /><label for="RecruitType2">现场招聘</label>
                                <input id="RecruitType4" name="RecruitType" type="checkbox" value="校园招聘" /><label for="RecruitType4">校园招聘</label>
                                <input id="RecruitType3" name="RecruitType" type="checkbox" value="其他形式" onchange="RecruitTypeOtherChange(this)" /><label for="RecruitType3">其他形式</label>
                                <input id="RecruitTypeOther" name="RecruitTypeOther" type="text" readonly="readonly" class="readonly" />
                                <asp:HiddenField ID="hidRecruitType" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style4">* 申请金额</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtApplyAmount" runat="server" requiredmes="请填写申请金额"></asp:TextBox>
                            </td>
                            <td class="auto-style4">* 使用时间</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtStartDate" runat="server" Width="100" requiredmes="请填写使用时间"></asp:TextBox>
                                至
                                <asp:TextBox ID="txtEndDate" runat="server" Width="100" requiredmes="请填写使用时间"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">* 举办机构名称</td>
                            <td class="tl PL10" colspan="3">
                                <asp:DropDownList ID="ddlOrganizationName" runat="server" onchange="OrganizationNameChange(this);" requiredmes="请选择举办机构名称">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem Value="前程无忧51job">前程无忧51job</asp:ListItem>
                                    <asp:ListItem Value="智联招聘">智联招聘</asp:ListItem>
                                    <asp:ListItem Value="南方人才网">南方人才网</asp:ListItem>
                                    <asp:ListItem Value="南方人才市场">南方人才市场</asp:ListItem>
                                    <asp:ListItem Value="赶集网">赶集网</asp:ListItem>
                                    <asp:ListItem Value="58同城">58同城</asp:ListItem>
                                    <asp:ListItem Value="中华英才网">中华英才网</asp:ListItem>
                                    <asp:ListItem Value="俊才网">俊才网</asp:ListItem>
                                    <asp:ListItem Value="番禺人才市场">番禺人才市场</asp:ListItem>
                                    <asp:ListItem Value="市桥人才市场">市桥人才市场</asp:ListItem>
                                    <asp:ListItem Value="其他机构">其他机构</asp:ListItem>
                                </asp:DropDownList>
                                <input id="OtherOrganizationName" type="text" readonly="readonly" class="readonly" />
                                <asp:HiddenField ID="hidOrganizationName" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">* 举办机构客服人员姓名</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtCustomService" runat="server" requiredmes="请填写举办机构客服人员姓名"></asp:TextBox>
                            </td>
                            <td class="auto-style4">* 联系方式</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtContact" runat="server" requiredmes="请填写联系方式"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tl PL10" colspan="4"><b style="color:red">如有相关合同/协议或者报价表，请以附件形式上传</b></td>
                            
                        </tr>
                        <tr>
                            <td class="auto-style4">* 跟进人工号</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtSecretaryCode" runat="server" onblur="getEmployee(this,'2');" requiredmes="请填写跟进秘书工号"></asp:TextBox>
                            </td>
                            <td class="auto-style4">* 跟进人</td>
                            <td class="tl PL10">
                                <asp:TextBox ID="txtSecretary" runat="server" CssClass="readonly" requiredmes="请填写跟进秘书(检查秘书工号是否填写正确)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">* 跟进人部门</td>
                            <td class="tl PL10" colspan="3">
                                <asp:TextBox ID="txtSecretaryDepartment" runat="server" CssClass="readonly" requiredmes="请填写跟进秘书部门(检查秘书工号是否填写正确)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0">
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
                        <tr class="noborder" style="height: 85px;" Idx="1">
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
                        <tr class="noborder" style="height:85px;" Idx="3">
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
                        <tr class="noborder" style="height: 85px;" Idx="4">
                            <td class="auto-style2" id="areamanager">区域负责人</td>
                            <td class="auto-style2" id="manager" style="display:none;">部门负责人</td>
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

                        <tr class="noborder" style="height: 85px;" Idx="5">
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
                                <div id="actualReimbursement" style="text-align:left; border-color:#98b8b5;" >
                                   <span>实际报销金额：<asp:TextBox ID="txtReimbursementAmount" runat="server" Width="100" BorderStyle="Solid" BorderColor="#98b8b5" BorderWidth="1"></asp:TextBox></span>
                                   <span style="margin-left:20px;">报销日期：<asp:TextBox ID="txtReimbursementDate" runat="server" Width="100" BorderStyle="Solid" BorderColor="#98b8b5" BorderWidth="1"></asp:TextBox></span>
                                   <asp:button runat="server" id="btnHRSave" text="保存" OnClientClick="return saveReimbursement();"  Visible="false" />
                                </div>
                                <div class="fielddate">日期：<span class="signdate">_________</span></div>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
                </div>
                <!--打印正文结束-->
                <div class="noprint">
                <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" backcolor="White" style="clear: both; margin-top: 3px;" bordercolor="#DEDFDE" borderstyle="None" borderwidth="1px" cellpadding="4" autogeneratecolumns="false" forecolor="Black" gridlines="Vertical" onrowcommand="gvAttach_RowCommand">
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
                    <p></p>
                    <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>
		            <asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" Visible="False" />
                    <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display:none;" />
		            <asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
		            <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
                    <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
		            <asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" OnClientClick="BackToSearch();return false;" />
		            <asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
                    <asp:hiddenfield id="hdIdx" runat="server" />
                    <asp:hiddenfield id="hdIsAgree" runat="server" />
		            <asp:hiddenfield id="hdSuggestion" runat="server" />
                    <input type="hidden" id="hdDetail2" runat="server" />
                    <input type="hidden" id="hdLogisticsFlow" runat="server" />
                    <asp:hiddenfield id="hdCancelSign" runat="server" />
                    <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
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
