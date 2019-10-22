<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Apply_BorrowMoney_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    







        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>临时借用资金申请表</h1>
            <table id="tbAround2" width='640px'>
                <tr>
                    <td colspan="4" style="text-align:right;padding-right:5px;">
                        No：<asp:TextBox ID="txtApplyID" runat="server" Width="250px"></asp:TextBox>
                    </td>
                    <td rowspan="20" style="font-size: 20px;">第二联<br />：冲帐联</td>
                </tr>
                <tr>
                    <td style="font-weight: bold" class="auto-style4">部门</td>
                    <td class="auto-style3"><asp:TextBox ID="txtDepartment2" runat="server"></asp:TextBox></td>
                    <td style="font-weight: bold">申请日期</td>
                    <td class="tl PL10"><asp:Label ID="lbApplyDate2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="font-weight: bold" class="auto-style4">需要日期</td>
                    <td class="auto-style3"><asp:TextBox ID="txtNeedDate2" runat="server"></asp:TextBox></td>
                    <td style="font-weight: bold">电话/传真</td>
                    <td class="tl PL10"><asp:TextBox ID="txtReplyPhone2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-weight: bold">申 请 事 项</td>
                    <td colspan="2" style="font-weight: bold">支 付 方 式</td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="3">
                        <asp:TextBox ID="txtReason2" runat="server" Height="100px" TextMode="MultiLine" Width="95%"></asp:TextBox>
                    </td>
                    <td rowspan="3">
                        <asp:CheckBox ID="cbPayK21" runat="server" Text="汇款" /><br />
                        <asp:CheckBox ID="cbPayK22" runat="server" Text="现金" /><br />
                        <asp:CheckBox ID="cbPayK23" runat="server" Text="支票" />
                    </td>
                    <td class="tl PL10">账户名称<asp:TextBox ID="txtAcount2" runat="server" Width="95%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10">账　　号<asp:TextBox ID="txtAname2" runat="server" Width="95%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td rowspan="1" class="tl PL10">开户银行<asp:TextBox ID="txtBank2" runat="server" Width="95%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10" colspan="4">
                        金额：￥<asp:TextBox ID="txtMoney2" runat="server" Width="200px"></asp:TextBox>　
                        （大写）：人民币<asp:TextBox ID="txtBWMoney2" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10" colspan="2">
                        申请报告编号<asp:TextBox ID="txtApplyNo2" runat="server" Width="73%"></asp:TextBox>　
                    </td>
                    <td class="tl PL10" colspan="2">
                        借支冲帐记录<asp:TextBox ID="txtDialog2" runat="server" Width="74%"></asp:TextBox>　
                    </td>
                </tr>

                <tr style="display:none;">
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 340px;">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td rowspan="4" colspan="1" class="auto-style4">申请人：<br /><br />
                        <input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><br />
                        <textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx7" value="签名" onclick="sign('7')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx7">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td colspan="1" rowspan="3">部门主管：</td>
                    <td colspan="1" class="tl PL10">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label><br />
                        <textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx8" value="签名" onclick="sign('8')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx8">_________</span></div>
                    </td>
                    <td rowspan="3" colspan="1" class="tl PL10" style="">部门负责人：<br /><br />
                        <input id="rdbYesIDx11" type="radio" name="agree11" /><label for="rdbYesIDx11">同意</label> <input id="rdbNoIDx11" type="radio" name="agree11" /><label for="rdbNoIDx11">不同意</label><br />
                        <textarea id="txtIDx11" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea>
                        <input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" />
                        <div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx11">_________</span></div>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td colspan="1" class="tl PL10">
                        <input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label><br />
                        <textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea><input type="button" id="btnSignIDx9" value="签名" onclick="sign('9')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx9">_________</span></div>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td colspan="1" class="tl PL10" style="">
                        <input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><br />
                        <textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto; display: none;"></textarea>
                        <input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx10">_________</span></div>
                    </td>
                </tr>

                <tr style="display: none">
					<td style="line-height: 15px; text-align: center;" class="auto-style4">财务部审批</td>
					<td colspan="3" class="tl PL10" style="  line-height: 40px;">
                        <label>【 】同意</label>　<label>【 】不同意</label>
                        <div>___________________________________________________________________________________</div>
                        <div>___________________________________________________________________________________</div>
                        <div>__________________________________________________　　_________年_______月_______日</div>
					</td>
				</tr>
                <tr style="display: none">
					<td style="line-height: 15px; text-align: center;" class="auto-style4">董事总经理审批</td>
					<td colspan="3" class="tl PL10" style="  line-height: 40px;">
                        <label>【 】同意</label>　<label>【 】不同意</label>
                        <div>___________________________________________________________________________________</div>
                        <div>___________________________________________________________________________________</div>
                        <div>__________________________________________________　　_________年_______月_______日</div>
					</td>
				</tr>
                <tr>
                    <td colspan="4" style="text-align: left; padding-left: 10px; font-weight: bold;">
                        收款金额：￥　　　　　　　　　　　　收 款 人：　　　　　　　　　签收日期：
                    </td>
                </tr>
                
            </table>
            <!--打印正文结束-->







    </div>
    </form>
</body>
</html>
