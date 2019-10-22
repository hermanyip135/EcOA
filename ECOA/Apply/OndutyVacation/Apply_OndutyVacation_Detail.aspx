<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_OndutyVacation_Detail.aspx.cs" validateRequest="false"  MasterPageFile="~/MasterPage.master"  Inherits="Apply_OndutyVacation_Apply_OndutyVacation_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <style type="text/css">
        .oneRowText {
            width:75px;
        }
        .threeRowText {
            width:37px;
        }
        .ddlWidth {
        width:65px;
        }
        tr {
        height:30px
        }
    </style>
    <script type="text/javascript">
        
        var i = 1;
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

            //初始化时间控件
            $("[dateplugin='datepicker']").each(function () {
                $(this).datepicker();
            });
            $("#<%=txtBeDDDate.ClientID%>").datepicker();
            $("#<%=txtEndDDDate.ClientID%>").datepicker();
            //签名数据绑定
            FlowSignInit();
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function check() {
            if($.trim($("#<%=txtApplyForName.ClientID %>").val())=="") {
                alert("姓名不可为空。");
                $("#<%=txtApplyForName.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApplyForCode.ClientID %>").val())=="") {
                alert("工号不可为空。");
                $("#<%=txtApplyForCode.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtApplyForDept.ClientID %>").val())=="") {
                alert("现任职部门不可为空。");
                $("#<%=txtApplyForDept.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=txtPosition.ClientID %>").val()) == "") {
                alert("现职位不可为空。");
                $("#<%=txtPosition.ClientID %>").focus();
                return false;
            }
            if (!$("#<%=rbtType1.ClientID %>").prop("checked") && !$("#<%=rbtType2.ClientID %>").prop("checked")
                && !$("#<%=rbtType3.ClientID %>").prop("checked") && !$("#<%=rbtType4.ClientID %>").prop("checked")
                && !$("#<%=rbtType5.ClientID %>").prop("checked") && !$("#<%=rbtType6.ClientID %>").prop("checked")
                && !$("#<%=rbtType7.ClientID %>").prop("checked") && !$("#<%=rbtType8.ClientID %>").prop("checked")
                && !$("#<%=rbtType9.ClientID %>").prop("checked") && !$("#<%=rbtType10.ClientID %>").prop("checked")
                ) {
                alert("请选择请假类型！");
                $("#<%=rbtType1.ClientID %>").focus();
               return false;
            }
            if ($("#<%=rbtType9.ClientID %>").prop("checked"))
            {
                if ($.trim($("#<%=txtOtherType.ClientID %>").val()) == "")
                {
                  alert("请填写其它类型说明！");
                $("#<%=txtOtherType.ClientID%>").focus();
                return false;
                
                }
                
            }
            var $eDate = $("#<%=txtBeDDDate.ClientID %>");
            if ($.trim($eDate.val()) == "") {
                alert("请假时限开始日不可为空！");
                $eDate.focus();
                return false;
            }
            if ($.trim($("#<%=ddlBeSSDate.ClientID %>").val()) == "请选择") {
                alert("请选择请假时限开始时！");
                $("#<%=ddlBeSSDate.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=ddlBeMMDate.ClientID %>").val()) == "请选择") {
                alert("请选择请假时限开始分！");
                $("#<%=ddlBeMMDate.ClientID %>").focus();
                return false;
            }
            var $eDate = $("#<%=txtEndDDDate.ClientID %>");
            if ($.trim($eDate.val()) == "") {
                alert("请假时限结束日不可为空！");
                $eDate.focus();
                return false;
            }
            if ($.trim($("#<%=ddlEndSSDate.ClientID %>").val()) == "请选择") {
                alert("请选择请假时限结束时！");
                $("#<%=ddlEndSSDate.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=ddlEndMMDate.ClientID %>").val()) == "请选择") {
                alert("请选择请假时限结束分！");
                $("#<%=ddlEndMMDate.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=tearExplain.ClientID %>").val()) == "") {
                alert("请假事由不可为空！");
                $("#<%=tearExplain.ClientID %>").focus();
                return false;
            }
            return true;
        }
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
            var $tr = $(e).parent().parent().parent();
            var idx = $tr.attr("Idx");
            var agree = "";
            //$tr.find("input[type=radio]").each(function () {
            //    if (this.checked) {
            //        agree = this.value;
            //    }
            //});
            //if (agree == "") {
            //    alert("请确定是否同意！");
            //    return false;
            //}
            if (idx == 20 || idx == 22)
            {
                if ($.trim($("#<%=txtSumSS.ClientID %>").val()) == "") {
                    alert("请填写合共小时！");
                    $("#<%=txtSumSS.ClientID %>").focus();
                     return false;
                }
                if ($.trim($("#<%=txtSumDD.ClientID %>").val()) == "") {
                    alert("请填写合共天数！");
                    $("#<%=txtSumDD.ClientID %>").focus();
                    return false;
                }
                if (!$("#<%=rbtSalary1.ClientID %>").prop("checked") && !$("#<%=rbtSalary2.ClientID %>").prop("checked"))
                {
                    alert("请选择有薪或者扣薪！");
                    $("#<%=rbtSalary1.ClientID %>").focus();
                     return false;
                }
                if (!$("#<%=rbtFullDate1.ClientID %>").prop("checked") && !$("#<%=rbtFullDate2.ClientID %>").prop("checked")) {
                    alert("请选择全勤或者非全勤！");
                    $("#<%=rbtFullDate1.ClientID %>").focus();
                    return false;
                }
            }
           
            cSign(e, "<%=hdIsAgree.ClientID %>", "<%=hdSuggestion.ClientID %>", "<%=this.btnSign.ClientID %>");   //common_new.js
        }

        //签名内容绑定
        function FlowSignInit() {

            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.lblApply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
        }

        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>", "<%=ApplyN %>");
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
                        $("#<%=txtApplyForCode.ClientID%>").val(infos[0]);
                        $("#<%=txtApplyForName.ClientID%>").val(infos[1]);
                        $("#<%=txtApplyForDept.ClientID%>").val(infos[2]);
                        $("#<%=txtPosition.ClientID%>").val(infos[4]);
                    }
                    else{
                        $("#<%=txtApplyForName.ClientID%>").val("");
                        $("#<%=txtApplyForDept.ClientID%>").val("");
                        $("#<%=txtPosition.ClientID%>").val("");
                    }
                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
             <div class="noprint">
        <%=SbFlow.ToString() %>
               <uc1:flowshow ID="FlowShow1" ShowEditBtn="false" runat="server" />
        <%--<asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />--%>
		</div>
            <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>假期申请表</h1>
            
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:700px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround"  width='700px'>
                <tr>
                    <td colspan="9" style="font-weight:bold">(直属董事总经理人员适用)</td>
                </tr>
                <tr>
                    <td class="tl PL10">﹡姓名</td>
                    <td class="tl PL10">
                        <input id="txtApplyForName" type="text" runat="server" readonly="readonly" style=" background-color:Silver;" class="oneRowText" />
                    </td>
                    <td class="tl PL10">工号</td>
                    <td class="tl PL10">
                        <asp:textbox id="txtApplyForCode" runat="server" onblur="getEmployee(this);" class="oneRowText"></asp:textbox>
                    </td>
                    <td class="tl PL10">部门</td>
                    <td class="tl PL10">
                        <input id="txtApplyForDept" type="text" runat="server" readonly="readonly" style=" background-color:Silver;" class="oneRowText"/>
                    </td>
                    <td class="tl PL10">职位</td>
                    <td class="tl PL10">
                       <input id="txtPosition" type="text" runat="server" readonly="readonly" style=" background-color:Silver; width:90px"  />
                    </td>
                   <%-- <td class="tl PL10">申请日期</td>
                    <td class="tl PL10">
                        <asp:textbox id="txtApplyForDate" runat="server" class="oneRowText"></asp:textbox>
                    </td>--%>
                </tr>
                <tr>
                    <td>﹡请假类型</td>
                    <td colspan="7">
                         <asp:radiobutton id="rbtType1" runat="server" groupname="rbtType" text="大假" value="1" />
                         <asp:radiobutton id="rbtType2" runat="server" groupname="rbtType" text="病假" value="2" />
                         <asp:radiobutton id="rbtType3" runat="server" groupname="rbtType" text="事假" value="3" />
                         <asp:radiobutton id="rbtType4" runat="server" groupname="rbtType" text="婚假" value="4" />
                         <asp:radiobutton id="rbtType5" runat="server" groupname="rbtType" text="产假" value="5" />
                         <asp:radiobutton id="rbtType6" runat="server" groupname="rbtType" text="丧假" value="6" />
                         <asp:radiobutton id="rbtType7" runat="server" groupname="rbtType" text="流产假" value="7" />
                         <asp:radiobutton id="rbtType8" runat="server" groupname="rbtType" text="陪产假" value="8" />
                         <asp:radiobutton id="rbtType10" runat="server" groupname="rbtType" text="生日假" value="10" />
                         <asp:radiobutton id="rbtType9" runat="server" groupname="rbtType" text="其它" value="9" />
                         <input id="txtOtherType" type="text" runat="server" style="width:85px" />
                    </td>
                </tr>
               
                <tr>
                    <td class="tl PL10">﹡请假时限</td>
                    <td class="tl PL10" colspan="7">
                        <asp:textbox id="txtBeDDDate" runat="server" class="oneRowText"></asp:textbox>日
                        <asp:DropDownList ID="ddlBeSSDate" runat="server" class="ddlWidth">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                             <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>时
                           <asp:DropDownList ID="ddlBeMMDate" runat="server" class="ddlWidth">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>00</asp:ListItem>
                             <asp:ListItem>30</asp:ListItem>
                             </asp:DropDownList>分至
                          <asp:textbox id="txtEndDDDate" runat="server" class="oneRowText"></asp:textbox>日
                         <asp:DropDownList ID="ddlEndSSDate" runat="server" class="ddlWidth">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                             <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>时
                           <asp:DropDownList ID="ddlEndMMDate" runat="server" class="ddlWidth">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>00</asp:ListItem>
                             <asp:ListItem>30</asp:ListItem>
                             </asp:DropDownList>分
                         <%--<input id="txtBeSSDate" type="text" runat="server" class="threeRowText" />时
                         <input id="txtBeMMDate" type="text" runat="server" class="threeRowText" />分至
                        <asp:textbox id="txtEndDDDate" runat="server" class="oneRowText"></asp:textbox>日
                          <input id="txtEndSSDate" type="text" runat="server" class="threeRowText" />时
                      <input id="txtEndMMDate" type="text" runat="server" class="threeRowText" />分--%>

                    </td>
                </tr>
                <tr>
                     <td class="tl PL10">﹡请假事由</td>
                    <td colspan="7">
                        <textarea id="tearExplain" runat="server" style="width:550px">

                        </textarea>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">申请人</td>
                    <td class="tl PL10" colspan="3">
                        <asp:Label ID="lblApply" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="tl PL10">填写日期</td>
                    <td class="tl PL10"  colspan="3">
                        <asp:Label ID="lblApplyDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10">备注</td>
                    <td colspan="7"><div style="margin: 0px auto; font-size:13px" class="tl">
                        <span>1、假期最小单位为“1小时”，不足1小时的按1小时计算，超出1小时以半小时为单位统计。</span><br />
                        <span>2、原则上所有假期均需提前一周申请，如因特殊情况需紧急请假的，经董事总经理同意后必须于假期结束<br />之日起两个工作日内完成申请资料的补充（包括假期申请表及特殊假期所需的证明资料），并送审至人力<br />资源部。</span><br/>
                        <span>3、本申请表适用于直属董事总经理管理的全体人员。</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <%--审核流程--%>
                    <td colspan="8">
                        <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0" style="width: 100%">
                          <tr class="noborder" style="height: 85px;" idx="10">
                                <td style="width: 130px">申请人</td>
                                <td class="tl PL10">
                                    <div class="fieldradio">
                                        <input type="radio" value="1" name="agree10" id="agreeID10" /><label class="l signyes" for="agreeID10">同意</label>
                                        <input type="radio" value="0" name="agree10" id="agreeID11" /><label class="l signno" for="agreeID11">不同意</label>
                                        <input type="radio" value="2" name="agree10" id="agreeID12" /><label class="l signyes" for="agreeID12">其他意见</label>
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
                            <tr class="noborder" style="height: 85px;" idx="20">
                                <td class="auto-style2" rowspan="2">人力资源部</td>
                                <td class="tl PL10">
                                       <span>
                                        合共<input id="txtSumSS" type="text"   runat="server" class="threeRowText"/>小时<input id="txtSumDD" type="text"   runat="server" class="threeRowText"/>天
                                        <asp:radiobutton id="rbtSalary1" runat="server" groupname="rbtSalary" text="有薪" value="10" />
                                        <asp:radiobutton id="rbtSalary2" runat="server" groupname="rbtSalary" text="扣薪" value="20" />
                                         <asp:radiobutton id="rbtFullDate1" runat="server" groupname="rbtFullDate" text="全勤" value="10" />
                                        <asp:radiobutton id="rbtFullDate2" runat="server" groupname="rbtFullDate" text="非全勤" value="20" />
                                    </span>
                                    <div class="fieldradio">
                                        <input type="radio" value="1" name="agree20" id="agreeID20" /><label class="l signyes" for="agreeID20">同意</label>
                                        <input type="radio" value="0" name="agree20" id="agreeID21" /><label class="l signno" for="agreeID21">不同意</label>
                                        <input type="radio" value="2" name="agree20" id="agreeID22" /><label for="agreeID22" class="l signyes">其他意见</label>
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
                            <tr class="noborder" style="height: 85px;" idx="22">
                                <td class="tl PL10">
                                    <div class="fieldradio">
                                        <input type="radio" value="1" name="agree22" id="agreeID23" /><label for="agreeID23" class="l signyes">同意</label>
                                        <input type="radio" value="0" name="agree22" id="agreeID24" /><label for="agreeID24" class="l signno">不同意</label>
                                        <input type="radio" value="2" name="agree22" id="agreeID25" /><label for="agreeID25" class="l signyes">其他意见</label>
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
                                  <tr class="noborder" style="height: 85px;" idx="30">
                                <td style="width: 130px">营运支持</td>
                                <td class="tl PL30">
                                    <div class="fieldradio">
                                        <input type="radio" value="1" name="agree30" id="agreeID30" /><label class="l signyes" for="agreeID30">同意</label>
                                        <input type="radio" value="0" name="agree30" id="agreeID31" /><label class="l signno" for="agreeID31">不同意</label>
                                        <input type="radio" value="2" name="agree30" id="agreeID32" /><label class="l signyes" for="agreeID32">其他意见</label>
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
                            <tr class="noborder" style="height: 85px;" idx="40">
                                <td style="width: 130px">董事总经理</td>
                                <td class="tl PL10">
                                    <div class="fieldradio">
                                        <input type="radio" value="1" name="agree40" id="agreeID40" /><label class="l signyes" for="agreeID40">同意</label>
                                        <input type="radio" value="0" name="agree40" id="agreeID41" /><label class="l signno" for="agreeID41">不同意</label>
                                        <input type="radio" value="2" name="agree40" id="agreeID42" /><label class="l signyes" for="agreeID42">其他意见</label>
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
        <asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
        <asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
 
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
        <asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
        <asp:hiddenfield id="hdIsAgree" runat="server" />
        <asp:hiddenfield id="hdSuggestion" runat="server" />
        <input type="hidden" id="hdDetail" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
            <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>
