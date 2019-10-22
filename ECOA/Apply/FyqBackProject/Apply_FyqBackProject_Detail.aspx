<%@ Page ValidateRequest="false" Title="房友圈退案申请表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_FyqBackProject_Detail.aspx.cs" Inherits="Apply_FyqBackProject_Apply_FyqBackProject_Detail" %>


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
            $("#<%=SellDate.ClientID%>").datepicker();

        });

        function selectFollwDept(e)
        {
            var selvalue = $(e).val();
            var followName ="";
            var followNameCode ="";
            switch(selvalue)
            {
                case '业务一部':
                    followName = "梁洪斌";
                    followNameCode="57738";
                    break;
                case '业务二部':
                    followName = "徐楚君";
                    followNameCode="57732";
                    break;
                case '业务三部':
                    followName = "邓嘉荣";
                    followNameCode="20665";
                    break;
                case '业务四部':
                    followName = "吴宏斌";
                    followNameCode="58703";
                    break;
                case '业务五部':
                    followName = "陈伟雄C";
                    followNameCode="32935";
                    break;
            }
            $('#<%=txtFollwStaff.ClientID%>').val(followName);
            $('#<%=HiFollwStaff.ClientID%>').val(followName);
            $('#<%=hiFollwStaffCode.ClientID%>').val(followNameCode);
        }

        
            function upload() {
                var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_FyqBackProject_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){ //&dpm="+$("#<%//=txtDepartment.ClientID %>").val()+"
            var win=window.showModalDialog("Apply_FyqBackProject_Flow.aspx?MainID=<%=MainID %>&flowsadd="+flowsl+"","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_FyqBackProject_Detail.aspx?MainID=<%=MainID %>";
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
            if(idx == 8)   
            {
                
                if($.trim($("#<%=BuySumM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuySumM.ClientID %>").focus();
                return false;
                }
                if($.trim($("#<%=SellSumM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=SellSumM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyPropertyM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuyPropertyM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyFamilyProofM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuyFamilyProofM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyAssessmentM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuyAssessmentM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyMortgageAgentM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuyMortgageAgentM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuySecurityFeeM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuySecurityFeeM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyTaxM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuyTaxM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyUpSumM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuyUpSumM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyRetreatM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=BuyRetreatM.ClientID %>").focus();
                    return false;
                }
                //卖家
                if($.trim($("#<%=SellSecurityFeeM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=SellSecurityFeeM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=SellTaxM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=SellTaxM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=SellUpSumM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=SellUpSumM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=SellRetreatM.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=SellRetreatM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=SellDate.ClientID %>").val())=="") {
                    alert("请填写致：财务部内容");
                    $("#<%=SellDate.ClientID %>").focus();
                    return false;
                }
                
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
                alert("申请部门不可为空！");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApply.ClientID %>").val())=="") {
                alert("申请人不可为空！");
                $("#<%=txtApply.ClientID %>").focus();
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
            if($.trim($("#<%=ddlFollwDept.ClientID %>").val())=="") {
                alert("请选择跟进部门！");
                $("#<%=ddlFollwDept.ClientID %>").focus();
                return false;
            }
            if($("#<%=chkNoProjectType1.ClientID %>")[0].checked&&$("#<%=ddlNoProjectCause1.ClientID %>").val()==0){
                alert("请选择取消物业买卖交易原因！");
                $("#<%=ddlNoProjectCause1.ClientID %>").focus();
                return false;
            }
            
            if($("#<%=chkNoProjectType2.ClientID %>")[0].checked&&$("#<%=ddlNoProjectCause2.ClientID %>").val()==0){
                alert("请选择取消办理按揭原因！");
                $("#<%=ddlNoProjectCause2.ClientID %>").focus();
                return false;
            }
            if($("#<%=chkNoProjectType3.ClientID %>")[0].checked&&$("#<%=ddlNoProjectCause3.ClientID %>").val()==0){
                alert("请选择更改为一次性付款原因！");
                $("#<%=ddlNoProjectCause3.ClientID %>").focus();
                return false;
            }

            if($("#<%=chkNoProjectType4.ClientID %>")[0].checked&&$.trim($("#<%=txtDepartment.ClientID %>").val())=="")
            {
                alert("原因详情不可为空！");
                $("#<%=txtOthers.ClientID %>").focus();
                return false;
            }

         
            return true;      
        }
        function check1()
        {
            if($.trim($("#<%=SellSumM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=SellSumM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyPropertyM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=BuyPropertyM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyFamilyProofM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=BuyFamilyProofM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyAssessmentM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=BuyAssessmentM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyMortgageAgentM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=BuyMortgageAgentM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuySecurityFeeM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=BuySecurityFeeM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyTaxM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=BuyTaxM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyUpSumM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=BuyUpSumM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=BuyRetreatM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=BuyRetreatM.ClientID %>").focus();
                    return false;
                }
            //卖家
                if($.trim($("#<%=SellSecurityFeeM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=SellSecurityFeeM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=SellTaxM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=SellTaxM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=SellUpSumM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=SellUpSumM.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=SellRetreatM.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=SellRetreatM.ClientID %>").focus();
                    return false;
                }
            if($.trim($("#<%=SellDate.ClientID %>").val())=="") {
                alert("请填写致：财务部内容");
                $("#<%=SellDate.ClientID %>").focus();
                return false;
            }
              
            return true;
        }


        function chkProgressOnclik(pp){
            var chkObj = document.getElementById("<%= chkProgress1.ClientID %>");
            var chkObj2 = document.getElementById("<%=chkProgress2.ClientID %>");
            var chkObj3 = document.getElementById("<%=chkProgress3.ClientID %>");
            var chkObj4 = document.getElementById("<%=chkProgress4.ClientID %>");
            var chkObj5 = document.getElementById("<%=chkProgress5.ClientID %>");
            chkObj.checked =false;
            chkObj2.checked=false;
            chkObj3.checked=false;
            chkObj4.checked=false;
            chkObj5.checked=false;
            pp.checked=true;
        }

        function chkNoProjectTypeOnclick(dd){
            var chkObj = document.getElementById("<%= chkNoProjectType1.ClientID %>");
            var chkObj2 = document.getElementById("<%=chkNoProjectType2.ClientID %>");
            var chkObj3 = document.getElementById("<%=chkNoProjectType3.ClientID %>");
            var chkObj4 = document.getElementById("<%=chkNoProjectType4.ClientID %>");
            var ddl1= document.getElementById("<%=ddlNoProjectCause1.ClientID %>");
            var ddl2= document.getElementById("<%=ddlNoProjectCause2.ClientID %>");
            var ddl3= document.getElementById("<%=ddlNoProjectCause3.ClientID %>");
            if(chkObj==dd){
                chkObj2.checked=false;
                chkObj3.checked=false;
                chkObj4.checked=false;
                ddl2.value="0";
                ddl3.value="0";
                $("#<%=txtOthers.ClientID %>").val("");
            }else if(chkObj2==dd){
                chkObj.checked=false;
                chkObj3.checked=false;
                chkObj4.checked=false;
                ddl1.value="0";
                ddl3.value="0";
                $("#<%=txtOthers.ClientID %>").val("");
            }else if(chkObj3==dd)
            {
                chkObj.checked=false;
                chkObj2.checked=false;
                chkObj4.checked=false;
                ddl1.value="0";
                ddl2.value="0";
                $("#<%=txtOthers.ClientID %>").val("");
            }else{
                chkObj.checked=false;
                chkObj2.checked=false;
                chkObj3.checked=false;
                ddl1.value="0";
                ddl2.value="0";
                ddl3.value="0";
            }
        
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
            .txtmoney {
            width:50px;
            }
    .btnFYQSave1{background:url("../../Images/btn_save1.png") no-repeat; width:64px;height:38px; cursor:pointer}
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
            <h1>广东中原地产代理有限公司</h1>
            <h1>房友圈退案申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td class="tl PL10" colspan="4">致：房友圈运作部/网签部   
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">申请部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="200px"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
                    <td class="auto-style5">申请人</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApply" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">联系电话</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                    <td class="auto-style5"></td>
                    <td class="tl PL10">
                     
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">物业地址</td>
                    <td colspan="3" class="tl PL10">
                        <asp:TextBox ID="txtLocation" runat="server" Width="490px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">业主</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtMaster" runat="server" Width="200px"></asp:TextBox></td>
                    <td class="auto-style5">买家</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtBuyers" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">原贷款银行</td>
                    <td class="tl PL10">
                          <asp:TextBox ID="txtOldLoanBank" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style5">贷款金额</td>
                    <td class="tl PL10">
                       <asp:TextBox ID="txtLoandMoney" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">*请选择进度</td>
                    <td  colspan="3" class="tl PL10">
                           <asp:CheckBox ID="chkProgress1" runat="server"   GroupName="Progress" onclick="chkProgressOnclik(this)"   Text="未送审" />
                        <asp:CheckBox ID="chkProgress2" runat="server" GroupName="Progress" onclick="chkProgressOnclik(this)"  Text="已送审" />
                        <asp:CheckBox ID="chkProgress3" runat="server" GroupName="Progress" onclick="chkProgressOnclik(this)"  Text="已递件" />
                        <asp:CheckBox ID="chkProgress4" runat="server" GroupName="Progress" onclick="chkProgressOnclik(this)"  Text="已出具新房产证" />
                        <asp:CheckBox ID="chkProgress5" runat="server" GroupName="Progress" onclick="chkProgressOnclik(this)" Text="已入抵押" />
                      

                    </td>
                    
                </tr>
                <tr>
                    <td>跟进业务部门</td>
                    <td> <asp:DropDownList ID="ddlFollwDept" runat="server" Width="200px" onchange="selectFollwDept(this)">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="业务一部">业务一部</asp:ListItem>
                            <asp:ListItem Value="业务二部">业务二部</asp:ListItem>
                            <asp:ListItem Value="业务三部">业务三部</asp:ListItem>
                            <asp:ListItem Value="业务四部">业务四部</asp:ListItem>
                            <asp:ListItem Value="业务五部">业务五部</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>跟进业务人</td>
                     <td>
                         <asp:TextBox ID="txtFollwStaff" runat="server" Enabled="false"></asp:TextBox>
                         <asp:HiddenField  runat="server" ID="HiFollwStaff"/>
                         <asp:HiddenField  runat="server" ID="hiFollwStaffCode"/>
                     </td>
                </tr> 
                <tr>
                    <td colspan="4" style="padding: 10px; text-align: left; line-height: 25px;"> 
                        <span style="color:red;font-family:宋体;font-weight:bold;font-size:14px;">请选择退案类型（并选择具体原因）:  </span><br />

                       
                        <asp:CheckBox ID="chkNoProjectType1" runat="server" GroupName="NoProjectType" onclick="chkNoProjectTypeOnclick(this)" Text="取消物业买卖交易：" />
                        <asp:DropDownList ID="ddlNoProjectCause1" runat="server" Width="200px"  >
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">买卖双方自愿取消</asp:ListItem>
                            <asp:ListItem Value="2">买方违约取消</asp:ListItem>
                              <asp:ListItem Value="3">卖方违约取消</asp:ListItem>
                        </asp:DropDownList><br />

                            
                        <asp:CheckBox ID="chkNoProjectType2" runat="server" GroupName="SpecialApply" onclick="chkNoProjectTypeOnclick(this)"  Text="取消办理按揭：" />
                        <asp:DropDownList ID="ddlNoProjectCause2" runat="server" Width="200px"  >
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">因银行政策变动，取消按揭</asp:ListItem>
                            <asp:ListItem Value="2">因客户资质，取消按揭</asp:ListItem>
                              <asp:ListItem Value="3">转换按揭公司</asp:ListItem>
                        </asp:DropDownList><br />
                      <asp:CheckBox ID="chkNoProjectType3" runat="server" GroupName="SpecialApply" onclick="chkNoProjectTypeOnclick(this)"  Text="更改为一次性付款：" />
                        <asp:DropDownList ID="ddlNoProjectCause3" runat="server" Width="200px"   >
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">转介客服办理房管业务</asp:ListItem>
                            <asp:ListItem Value="2">客户自行办理房管业务</asp:ListItem>
                         
                        </asp:DropDownList><br />

                        <asp:CheckBox ID="chkNoProjectType4" runat="server" GroupName="SpecialApply" onclick="chkNoProjectTypeOnclick(this)"  Text="其它原因需详细说明：" />

                   <asp:TextBox ID="txtOthers" runat="server" Width="525px"></asp:TextBox><br />

                        <span style="font-weight: bold">退客资料（多选）：
                    
                        </span>
                        <br />

                        <asp:CheckBox ID="chkBackData1" runat="server" GroupName="SpecialApply" Text="房产证" /> 
                        <asp:CheckBox ID="chkBackData2" runat="server" GroupName="SpecialApply" Text="公证书 " />
                        <asp:CheckBox ID="chkBackData3" runat="server" GroupName="SpecialApply" Text="买方/业主基本资料"/>
                       <br />
                        <asp:CheckBox ID="chkBackData4" runat="server" GroupName="SpecialApply" Text="其他资料"/>
               
                              <asp:TextBox ID="txtOtherData" runat="server" Width="525px"></asp:TextBox><br />
                      

                      <hr style="height:1px;border:none;border-top:1px dashed #0066CC;" />
                      <span style="font-weight: bold;float:left">致：财务部
                        </span>
                        <span style="float:right">案号： <asp:Label runat="server" ID="lbProjectNo" Text=""></asp:Label>
                        </span>
                         <br />
                        <span>

                         &nbsp;&nbsp;   买家合计共缴交按揭费及税费人民币<asp:TextBox runat="server" ID="BuySumM" CssClass="txtmoney"></asp:TextBox>元；卖家合计共缴交按揭费及税费人民币<asp:TextBox runat="server" ID="SellSumM" CssClass="txtmoney"></asp:TextBox>元；。上述原因导致需要退款。其委托办理，已产生成本费用如下：
   <br />买家：1．产权查册：<asp:TextBox runat="server" ID="BuyPropertyM" CssClass="txtmoney"></asp:TextBox>元_ 、2．家庭证明费：       <asp:TextBox runat="server" ID="BuyFamilyProofM" CssClass="txtmoney"></asp:TextBox>元_、3．评估费：<asp:TextBox runat="server" ID="BuyAssessmentM" CssClass="txtmoney"></asp:TextBox>元 4．按揭代理费：<asp:TextBox runat="server" ID="BuyMortgageAgentM" CssClass="txtmoney"></asp:TextBox>元、5.担保费：<asp:TextBox runat="server" ID="BuySecurityFeeM" CssClass="txtmoney"></asp:TextBox>元、6.税费：<asp:TextBox runat="server" ID="BuyTaxM" CssClass="txtmoney"></asp:TextBox>元7．其它 ：                                         
   上述费用合共人民币<asp:TextBox runat="server" ID="BuyUpSumM" CssClass="txtmoney"></asp:TextBox>元，则退买家费用为人民币<asp:TextBox runat="server" ID="BuyRetreatM" CssClass="txtmoney"></asp:TextBox>元。
 
                        <br />
                        卖家 ：
                        1.担保费：<asp:TextBox runat="server" ID="SellSecurityFeeM" CssClass="txtmoney"></asp:TextBox>、2.税费：<asp:TextBox runat="server" ID="SellTaxM" CssClass="txtmoney"></asp:TextBox>3.其它：                                                                             
上述费用合共人民币<asp:TextBox runat="server" ID="SellUpSumM" CssClass="txtmoney"></asp:TextBox>元，则退卖家费用为人民币<asp:TextBox runat="server" ID="SellRetreatM" CssClass="txtmoney"></asp:TextBox>元。
请财务部审核并办理退款手续为盼。该客户拟定于<asp:TextBox runat="server" ID="SellDate" CssClass="txtmoney"></asp:TextBox>前来办理退款手续。 </span>
                

               <br />
                      <asp:Button runat="server" ID="btnFYQSave1" CssClass="btnFYQSave1" Visible="false" OnClick="btnSave1_Click" OnClientClick="return check1();"/> 
                    </td>
                </tr>
                
                <tr style="display: none;">
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 390px;">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>



                <tr id="trManager1" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">申请人</td>
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

                <tr id="trM8" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">房友圈总监助理</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx8" type="radio" name="agree8" />
                        <label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8"  />
                        <label for="rdbNoIDx8">不同意</label><br /><br />

                       

                        <textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S4"></textarea>
                        <input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>
                        <asp:TextBox runat="server" ID="txtProjectNo" Visible="false"></asp:TextBox> &nbsp   <asp:Button runat="server" ID="btnEditProjectNo" OnClick="btnEditProjectNo_Click" Visible="false" Text="录入案号"/>
                    </td>
                </tr>
                <tr id="trM9" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">房友圈主管</td>
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
            ForeColor="Black" GridLines="Vertical" OnRowCommand="gvAttach_RowCommand">
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
            <hr />
  <%--          <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />--%>

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
