<%@ Page ValidateRequest="false" Title="房友圈按揭不承办知会函" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_FyqNotUnProject_Detail.aspx.cs" Inherits="Apply_FyqNotUnProject_Apply_FyqNotUnProject_Detail" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>;  
        var flowsl = '<%=flowsl %>';
        $(function() {
            $("#<%=txtDepartment.ClientID %>").autocomplete({
                source: jJSON,
                select: function (event, ui) {
                    $("#<%=hdDepartmentID.ClientID %>").val(ui.item.id);
            }
            });


            $("#<%=txtFyqDepartment.ClientID %>").autocomplete({
                source: jJSON,
                select: function (event, ui) {
                    $("#<%=hdFyqDepartment.ClientID %>").val(ui.item.id);
                }
                });

        });


        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>", "<%=ApplyN %>");
        }
        
        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_FyqNotUnProject_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){ //&dpm="+$("#<%//=txtDepartment.ClientID %>").val()+"
            var win=window.showModalDialog("Apply_FyqNotUnProject_Flow.aspx?MainID=<%=MainID %>&flowsadd="+flowsl+"","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_FyqNotUnProject_Detail.aspx?MainID=<%=MainID %>";
        }
		

        function sign(idx) {
            //if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
            //    alert("请确定是否同意！");
            //    return;
            //}
            
            //if(idx!='3'&&idx!='4'){
            //    if(($("#rdbNoIDx"+idx).prop("checked")||$("#rdbOtherIDx"+idx).prop("checked"))&&$.trim($("#txtIDx"+idx).val())=="") {   
            //        alert("由于您不同意该申请，必须填写不同意的原因。")
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

        function getSuggestion(idx) {
            $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
        }
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
        function check()
        {
            
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("分行不可为空！");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtCharge.ClientID %>").val())=="") {
                alert("主管\区经\总监\负责人不可为空！");
                $("#<%=txtCharge.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtSale.ClientID %>").val())=="") {
                alert("营业员不可为空！");
                $("#<%=txtSale.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtFyqDepartment.ClientID %>").val())=="") {
                alert("房友圈部门不可为空！");
                $("#<%=txtFyqDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtFyqSale.ClientID %>").val())=="") {
                alert("经办不可为空！");
                $("#<%=txtFyqSale.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtFyqCharge.ClientID %>").val())=="") {
                alert("部门主管不可为空！");
                $("#<%=txtFyqCharge.ClientID %>").focus();
                return false;
            }


            if($.trim($("#<%=txtLocation.ClientID %>").val())=="") {
                alert("地址不可为空！");
                $("#<%=txtLocation.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtMaster.ClientID %>").val())=="") {
                alert("业主不可为空！");
                $("#<%=txtMaster.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtBuyers.ClientID %>").val())=="") {
                alert("买家不可为空！");
                $("#<%=txtBuyers.ClientID %>").focus();
                return false;
            }
            return true;      
        }

        function CheckBoxCheck(chk)
        {
       
            
            var chkObj = document.getElementById("<%=chkMaster.ClientID %>");
            var chkObj2 = document.getElementById("<%=chkBuyers.ClientID %>");
            if(chkObj!=chk)
            {
                chkObj.checked =false;
                chkObj2.checked=true;
            }else{
            
                chkObj.checked =true;
                chkObj2.checked=false;
            }
           
        }

        function MasterOnblur(master){
            $("#<%=txtMaster1.ClientID %>").val(master.value);

            $("#<%=txtMaster2.ClientID %>").val(master.value);
        }

        function BuyersOnblur(buyers){
        
            $("#<%=txtBuyer1.ClientID %>").val(buyers.value);

            $("#<%=txtBuyer2.ClientID %>").val(buyers.value);
        }

</script>
        <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td {
            border: 0;
        }

        .auto-style4 {
            width: 115px;
        }

        .auto-style5 {
            width: 135px;
        }
        .auto-style6 {
            width: 115px;
            height: 28px;
        }
        .auto-style7 {
            height: 28px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>&nbsp;</h1>
            <h1>房友圈按揭不承办知会函</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td class="tl PL10" colspan="4">致： <asp:TextBox ID="txtDepartment" runat="server" Width="250px"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />  分行  
                            
                    </td>
                </tr>
              <tr>
                    <td class="auto-style4"> 主管</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtCharge" runat="server" Width="200px"> </asp:TextBox>
                    </td>
                    <td class="auto-style5">营业员</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtSale" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    
                    <td class="tl PL10" colspan="4" >
                       由：    <asp:TextBox ID="txtFyqDepartment" Width="250px" runat="server"></asp:TextBox>  <input type="hidden" id="hdFyqDepartment" runat="server" />    部 （房友圈业务部）
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style4">经办</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtFyqSale" runat="server"   Width="200px"></asp:TextBox></td>
                    <td class="auto-style5">部门主管</td>
                    <td class="tl PL10">
                     <asp:TextBox ID="txtFyqCharge" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">物业地址</td>
                    <td colspan="3"  class="auto-style7">
                        <asp:TextBox ID="txtLocation" runat="server" Width="490px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">业主</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtMaster" runat="server" Width="200px" onblur="MasterOnblur(this)"></asp:TextBox></td>
                    <td class="auto-style5">买家</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtBuyers" runat="server" onblur="BuyersOnblur(this)"></asp:TextBox></td>
                </tr>
                
           
                <tr>
                    <td colspan="4" style="padding: 10px; text-align: left; line-height: 25px;"> 
                        <span style="font-family:宋体;font-size:14px;">

                            现因：
                            <asp:CheckBox ID="chkMaster" runat="server" Checked="true" onclick="CheckBoxCheck(this)"   GroupName="Person" Text="买方" />
                            <asp:CheckBox ID="chkBuyers" runat="server"  onclick="CheckBoxCheck(this)"  GroupName="Person" Text="卖方" />
                            要求自行在 <asp:TextBox ID="txtMortgage" runat="server"></asp:TextBox>              按揭公司或<asp:TextBox ID="txtBank" runat="server"></asp:TextBox>        银行 
                            <asp:TextBox ID="txtBankBranch" runat="server"></asp:TextBox>      支行办理按揭贷款手续，广州房友圈网络科技有限公司不介入跟进（买卖双方需签署《按揭不承办知会函》、并提供办理按揭公司、银行经办人卡片、银行同意贷款书、过户\入押回执等资料给广州房友圈网络科技有限公司作留档之用）。
详细情况说明：基于一切公平，公开，公证原则，我司须明确知会原业主<asp:TextBox ID="txtMaster1" ReadOnly="true" runat="server"></asp:TextBox>，本宗按揭贷款如果任由买方<asp:TextBox ID="txtBuyer1"  ReadOnly="true" runat="server"></asp:TextBox>自己找银
                            行办理会导致延迟收款或无法收款，如若发生上述情况，原业主<asp:TextBox ID="txtMaster2"  ReadOnly="true" runat="server"></asp:TextBox>表示认同与中原地产代理有限公司无关。买方<asp:TextBox ID="txtBuyer2"  ReadOnly="true" runat="server"></asp:TextBox>表示会独立承担此风险带来的责任，与中原地产代理有限公司无关，现特此知会该案情况

                        </span><br />
                     
                   
                        <span style="font-weight: bold">
                            买卖双方知悉并确认以上物业的按揭手续无须中原地产代理有限公司公司跟进，经纪方对上述物业在按揭过程中产生的一切情况均不负任何责任。

                        </span><br />
                    
                    <span style="font-family:宋体;font-size:14px;">

                     买方签署:<span style="text-decoration:underline">&nbsp  &nbsp   &nbsp  &nbsp</span>          签署日期：<span style="text-decoration:underline">&nbsp    &nbsp    &nbsp  &nbsp</span>    
                    卖方签署：<span style="text-decoration:underline">&nbsp    &nbsp   &nbsp  &nbsp</span>          签署日期：<span style="text-decoration:underline">&nbsp    &nbsp    &nbsp  &nbsp</span>           
                     <br />上述情况不承办，《存量房网签合同》需求如下：<br />
                        □成交价与网签合同价格一致的《存量房网签合同》： □买方壹份 □卖方壹份<br />
                    领取人：□分行营业员  工号：  &nbsp    &nbsp    &nbsp  &nbsp       &nbsp    &nbsp    &nbsp               
                        □买方本人     □卖方本人  

                     
                        <br />
                        领取人签署：   <span style="text-decoration:underline">&nbsp   &nbsp &nbsp  &nbsp  &nbsp   &nbsp  &nbsp</span>                 ， &nbsp    &nbsp            领取人签署：       <span style="text-decoration:underline">&nbsp   &nbsp &nbsp  &nbsp  &nbsp   &nbsp  &nbsp</span>                ，

                     
                        <br /> 
                        其他情况：                                                                     

                         <span style="text-decoration:underline">&nbsp   &nbsp &nbsp  &nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp 
                              &nbsp &nbsp  &nbsp  &nbsp   &nbsp  &nbsp</span>   
                        </span>


                    </td>
                </tr>

                <tr style="display: none;">
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 390px;">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>

       

                <%--<tr id="TSD1" style="display: none;">
                    <td colspan="4">
                        <a id="afa" href="javascript:void(0)" onclick="addFlow();">增加审批环节</a>
                        <a id="dfd" href="javascript:void(0)" onclick="deleteFlow()">删除添加的审批环节</a><br />
                    </td>
                </tr>--%>

            
                

                <tr id="trManager1" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">分行申请人    </td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">分行主管</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
                    </td>
                </tr>
                <tr id="trM3" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">区域经理</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
                    </td>
                </tr>

                <tr id="trM4" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">区域总监</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label><br />
                        <textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
                    </td>
                </tr>
                <tr id="trM5" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">区域负责人</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx5" type="radio" name="agree5" />
                        <label for="rdbYesIDx5">同意</label>
                        <input id="rdbNoIDx5" type="radio" name="agree5" />
                        <label for="rdbNoIDx5">不同意</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>

   
                <%--				<tr id="trM7" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style2">法律部</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" value="1" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" value="2" />
                        <label for="rdbNoIDx7">不同意</label><br />
						<textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>
					</td>
				</tr>--%>

<%--                <tr id="traddflow" style="display:none">
                    <td style="text-align: left; padding-left: 10px;" colspan="4">
                        <div class="flow">分行主管：<input type="text" id="Text1" style="width:190px;border: 1px solid #98b8b5; margin-right:20px" />区域经理：<input type="text" id="Text2" style="width:190px;border: 1px solid #98b8b5;" /></div>
                        <div class="flow">区域总监：<input type="text" id="Text3" style="width:190px;border: 1px solid #98b8b5; margin-right:20px" />区域负责人：<input type="text" id="Text4" style="width:190px;border: 1px solid #98b8b5;" /></div>
                        <div class="flow"> 法律部：<input type="text" id="Text5" style="width:190px;border: 1px solid #98b8b5; margin-right:20px" />汇瀚营运总经理：<input type="text" id="txtidx10" style="width:190px;border: 1px solid #98b8b5;" /></div>
                        <div style="text-align:center;"><asp:Button ID="btnsaveflow" runat="server" OnClientClick="return checkAddFlow()" Text="保存" OnClick="btnsaveflow_Click"/></div>
                    </td>
                </tr>--%>

   <%--             <tr id="trM8" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">房友圈主管</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx8" type="radio" name="agree8" />
                        <label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8"  />
                        <label for="rdbNoIDx8">不同意</label><br /><br />

                         <a id="addflow" href="javascript:void(0)" onclick="$('#traddflow').show();" style="display:none;">增加审批环节</a>

                        <textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S4"></textarea>
                        <input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
                    </td>
                </tr>--%>
                <tr id="trM9" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">网签组主管</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx9" type="radio" name="agree9"  />
                        <label for="rdbYesIDx9">同意</label>
                        <input id="rdbNoIDx9" type="radio" name="agree9" />
                        <label for="rdbNoIDx9">不同意</label><br />
                        <textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea>
                        <input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
                    </td>
                </tr>
                <tr id="trM10" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">房友圈总监</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx10" type="radio" name="agree10" />
                        <label for="rdbYesIDx10">同意</label>
                        <input id="rdbNoIDx10" type="radio" name="agree10" />
                        <label for="rdbNoIDx10">不同意</label><br />
                        <textarea id="Textarea1" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S30"></textarea>
                        <input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
                    </td>
                </tr>


            </table>

            <!--打印正文结束-->
        </div>
        <div class="noprint">
        <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" BackColor="White" Style="clear: both; margin-top: 3px;"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="false"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="gvAttach_RowCommand" >
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
              <%--  <asp:TemplateField HeaderText="删除" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" Visible="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID") %>' OnClientClick="return confirm('确认删除？');" />
                        <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="附件" HeaderStyle-Width="500px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
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
            <hr />
          <%--  <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />--%>

            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display:none;"/>
            <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
 
            <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
            <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
            <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
            <asp:HiddenField ID="hdIsAgree" runat="server" />
            <asp:HiddenField ID="hdSuggestion" runat="server" />
            <input type="hidden" id="hdDetail" runat="server" />
            <asp:HiddenField ID="hdCancelSign" runat="server" />
            <asp:HiddenField ID="hdcontentaddflow" runat="server" />
            <asp:HiddenField ID="hdcontent" runat="server" />
            <asp:HiddenField ID="hddeleteidxs" runat="server" />
            <input type="hidden" id="hdLogisticsFlow" runat="server" />
            <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
        </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <%=Sbjstb.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>
