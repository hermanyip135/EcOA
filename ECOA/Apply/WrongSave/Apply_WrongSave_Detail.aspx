<%@ Page ValidateRequest="false" Title="错存帐户调整申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_WrongSave_Detail.aspx.cs" Inherits="Apply_WrongSave_Apply_WrongSave_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        $(function() {      
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
		        }
            });
            //   $(".hidePay").hide();
            account();
            var Gbox=document.querySelectorAll("#Kind [type=radio]");
            for(var i=0;i<Gbox.length;i++){
                Gbox[i].setAttribute("onclick", 'account()')
            }
          
            //for (var x = 1; x < i; x++) {
            //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
            //}
		     
            //i = $("#tbDetail tr").length - 1;
            $("#<%=txtWSDate.ClientID%>").datepicker();
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
        function account(){
           // alert('s');
            //var Gbox=document.querySelectorAll("#Kind [type=radio]");
            //for(var i=0;i<Gbox.length;i++){
            //    if(Gbox[i].checked = true && 
            //    }
       
            //佣金对公账户
            // alert($("#ctl00_ContentPlaceHolder1_rdbKindOfWS1").prop("checked"))
           
            if( $("#<%=rdbKindOfWS1.ClientID %>").prop("checked") == true && ($("#<%=rdbKindOfWSA1.ClientID %>").prop("checked") == true ||  $("#<%=rdbKindOfWSA2.ClientID %>").prop("checked") == true ))
            {
              
                if( $("#<%=rdbKShouldS2.ClientID %>").prop("checked") == true && ( $("#<%=rdbKShouldSB1.ClientID %>").prop("checked") == true ||  $("#<%=rdbKShouldSB2.ClientID %>").prop("checked") == true))
                {
                   
                    $(".hidePay").show();
                    $("#ctl00_ContentPlaceHolder1_LPayee").html('广东中原地产代理有限公司');
                    $("#ctl00_ContentPlaceHolder1_LPayNum").html('44001420303051684025');
                    $("#ctl00_ContentPlaceHolder1_lPayBank").html('中国建设银行广东省广州市仓边路支行');
                    $('#<%=hfPayee.ClientID%>').val('广东中原地产代理有限公司');
                    $('#<%=hfPayNum.ClientID%>').val('44001420303051684025');
                    $('#<%=hfPayBank.ClientID%>').val('中国建设银行广东省广州市仓边路支行');
                   
                }
            
                    //汇瀚代收款对公账户 
                else if($("#ctl00_ContentPlaceHolder1_rdbKShouldS3").prop("checked") ==true && ($("#ctl00_ContentPlaceHolder1_rdbKShouldSC2").prop("checked") == true || $("#ctl00_ContentPlaceHolder1_rdbKShouldSC1").prop("checked") == true))
                {
                    $(".hidePay").show();
                    $("#ctl00_ContentPlaceHolder1_LPayee").html('广州市汇瀚顾问有限公司');
                    $("#ctl00_ContentPlaceHolder1_LPayNum").html('44001420303053000010');
                    $("#ctl00_ContentPlaceHolder1_lPayBank").html('中国建设银行广东省广州市仓边路支行');
                    $('#<%=hfPayee.ClientID%>').val('广州市汇瀚顾问有限公司');
                    $('#<%=hfPayNum.ClientID%>').val('44001420303053000010');
                    $('#<%=hfPayBank.ClientID%>').val('中国建设银行广东省广州市仓边路支行');
                 
                }
                else if( $("#<%=rdbKShouldS4.ClientID %>").prop("checked") == true && ( $("#<%=rdbKShouldSD1.ClientID %>").prop("checked") == true ||  $("#<%=rdbKShouldSD2.ClientID %>").prop("checked") == true))
                {
                   
                    $(".hidePay").show();
                    $("#ctl00_ContentPlaceHolder1_LPayee").html('广州市汇瀚顾问有限公司');
                    $("#ctl00_ContentPlaceHolder1_LPayNum").html('120902263910201');
                    $("#ctl00_ContentPlaceHolder1_lPayBank").html('招商银行东风支行');
                    $('#<%=hfPayee.ClientID%>').val('广州市汇瀚顾问有限公司');
                    $('#<%=hfPayNum.ClientID%>').val('120902263910201');
                    $('#<%=hfPayBank.ClientID%>').val('招商银行东风支行');
                   
                }
                else
                {
                    $(".hidePay").hide();
                    $("#ctl00_ContentPlaceHolder1_LPayee").html('')
                    $("#ctl00_ContentPlaceHolder1_LPayNum").html('')
                    $("#ctl00_ContentPlaceHolder1_lPayBank").html('')
                    $('#<%=hfPayee.ClientID%>').val('');
                    $('#<%=hfPayNum.ClientID%>').val('');
                    $('#<%=hfPayBank.ClientID%>').val('');
                }
            }else
            {
                $(".hidePay").hide();
                $("#ctl00_ContentPlaceHolder1_LPayee").html('')
                $("#ctl00_ContentPlaceHolder1_LPayNum").html('')
                $("#ctl00_ContentPlaceHolder1_lPayBank").html('')
                $('#<%=hfPayee.ClientID%>').val('');
                $('#<%=hfPayNum.ClientID%>').val('');
                $('#<%=hfPayBank.ClientID%>').val('');
            }
        }
        function check() {
            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
                alert("收发票号不可为空！");
		        $("#<%=txtApplyID.ClientID %>").focus();
                return false;
            }
	        
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("分行名不可为空！");
		        $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
			
            if($.trim($("#<%=txtAddress.ClientID %>").val())=="") {
                alert("物业单位地址不可为空！");
		        $("#<%=txtAddress.ClientID %>").focus();
                return false;
            }

            if (!$("#<%=rdbADNo1.ClientID %>").prop("checked") && !$("#<%=rdbADNo2.ClientID %>").prop("checked")){
                alert("请选择收据或发票方式");
                $("#<%=rdbADNo1.ClientID%>").focus();
                return false;
            }
            if($.trim($("#<%=txtWSDate.ClientID %>").val())=="") {
                alert("错存日期不可为空！");
                $("#<%=txtWSDate.ClientID %>").focus();
                return false;
            }
            if (!$("#<%=rdbKindOfM1.ClientID %>").prop("checked") && !$("#<%=rdbKindOfM2.ClientID %>").prop("checked")){
                alert("请选择款项实际性质");
                $("#<%=rdbKindOfM1.ClientID%>").focus();
                return false;
            }
            if($.trim($("#<%=txtBigSMoney.ClientID %>").val())=="") {
                alert("金额（大写）不可为空！");
                $("#<%=txtBigSMoney.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtSmallSMoney.ClientID %>").val())=="") {
                alert("金额（小写）不可为空！");
                $("#<%=txtSmallSMoney.ClientID %>").focus();
                return false;
            }
            if (!$("#<%=rdbKindOfWS1.ClientID %>").prop("checked") && !$("#<%=rdbKindOfWS2.ClientID %>").prop("checked") && !$("#<%=rdbKindOfWS3.ClientID %>").prop("checked")&& !$("#<%=rdbKindOfWS4.ClientID %>").prop("checked")){
                alert("请选择错存帐户类型");
                $("#<%=rdbKindOfWS1.ClientID%>").focus();
                return false;
            }
            if ($("#<%=rdbKindOfWS1.ClientID %>").prop("checked")){
                if (!$("#<%=rdbKindOfWSA1.ClientID %>").prop("checked") && !$("#<%=rdbKindOfWSA2.ClientID %>").prop("checked")){
                    alert("请选择中原代收款错存账户");
                    $("#<%=rdbKindOfWSA1.ClientID%>").focus();
                    return false;
                }
            }
            if ($("#<%=rdbKindOfWS2.ClientID %>").prop("checked")){
                if (!$("#<%=rdbKindOfWSB1.ClientID %>").prop("checked") && !$("#<%=rdbKindOfWSB2.ClientID %>").prop("checked")){
                    alert("请选择中原佣金错存账户");
                    $("#<%=rdbKindOfWSB1.ClientID%>").focus();
                    return false;
                }
            }
            if ($("#<%=rdbKindOfWS3.ClientID %>").prop("checked")){
                if (!$("#<%=rdbKindOfWSC1.ClientID %>").prop("checked") && !$("#<%=rdbKindOfWSC2.ClientID %>").prop("checked")){
                    alert("请选择汇瀚代收款错存账户");
                    $("#<%=rdbKindOfWSC1.ClientID%>").focus();
                    return false;
                }
            }
            if ($("#<%=rdbKindOfWS4.ClientID %>").prop("checked")){
                if (!$("#<%=rdbKindOfWSD1.ClientID %>").prop("checked") && !$("#<%=rdbKindOfWSD2.ClientID %>").prop("checked")){
                      alert("请选择汇瀚佣金款错存账户");
                      $("#<%=rdbKindOfWSD1.ClientID%>").focus();
                    return false;
                }
            }

            if (!$("#<%=rdbKShouldS1.ClientID %>").prop("checked") && !$("#<%=rdbKShouldS2.ClientID %>").prop("checked") && !$("#<%=rdbKShouldS3.ClientID %>").prop("checked")&& !$("#<%=rdbKShouldS4.ClientID %>").prop("checked")){
                alert("请选择应存帐户");
                $("#<%=rdbKShouldS1.ClientID%>").focus();
                return false;
            }
            if ($("#<%=rdbKShouldS1.ClientID %>").prop("checked")){
                if (!$("#<%=rdbKShouldSA1.ClientID %>").prop("checked") && !$("#<%=rdbKShouldSA2.ClientID %>").prop("checked")){
                    alert("请选择中原代收款应存账户");
                    $("#<%=rdbKShouldSA1.ClientID%>").focus();
                    return false;
                }
            }
            if ($("#<%=rdbKShouldS2.ClientID %>").prop("checked")){
                if (!$("#<%=rdbKShouldSB1.ClientID %>").prop("checked") && !$("#<%=rdbKShouldSB2.ClientID %>").prop("checked")){
                    alert("请选择中原佣金应存账户");
                    $("#<%=rdbKShouldSB1.ClientID%>").focus();
                    return false;
                }
            }
            if ($("#<%=rdbKShouldS3.ClientID %>").prop("checked")){
                if (!$("#<%=rdbKShouldSC1.ClientID %>").prop("checked") && !$("#<%=rdbKShouldSC2.ClientID %>").prop("checked")){
                    alert("请选择汇瀚代收款应存账户");
                    $("#<%=rdbKShouldSC1.ClientID%>").focus();
                    return false;
                }
            }
            if ($("#<%=rdbKShouldS4.ClientID %>").prop("checked")){
                if (!$("#<%=rdbKShouldSD1.ClientID %>").prop("checked") && !$("#<%=rdbKShouldSD2.ClientID %>").prop("checked")){
                        alert("请选择汇瀚佣金应存账户");
                        $("#<%=rdbKShouldSC1.ClientID%>").focus();
                    return false;
                }
            }
            if($.trim($("#<%=txtWname.ClientID %>").val())=="") {
                alert("错存责任人不可为空！");
                $("#<%=txtWname.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtWposition.ClientID %>").val())=="") {
                alert("错存人职位不可为空！");
                $("#<%=txtWposition.ClientID %>").focus();
                return false;
            }
            if($.trim($("#<%=txtOpinion.ClientID %>").val())=="") {
                alert("错存责任人（姓名、职位）及错存原因不可为空！");
                $("#<%=txtOpinion.ClientID %>").focus();
                return false;
            }
        }

        function checkChecked() {
            var gv = document.getElementById('<%=gvAttach.ClientID%>'); 
            var input = gv.getElementsByTagName("input"); 
            var flagCheck = false;

            for (var i = 0; i < input.length; i++) {
                if (input[i].type == 'checkbox' && !input[i].disabled && input[i].checked){
                    flagCheck = true;
                    break;
                }
            }
			
            if(!flagCheck)
                alert("请勾选文件再下载！");
				
            return flagCheck;
        }

        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue=='success')
		        window.location='Apply_WrongSave_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_WrongSave_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_WrongSave_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }
		
                function sign(idx) {
                    //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'){
                    //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
                    //        alert("请确定是否同意！");
                    //        return;
                    //    }
                    //}
                    //else{
                    //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                    //        alert("请确定是否同意！");
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

function getSuggestion(idx)
{
    $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
        }
		
        function myPrint(start, end, extend) {    
            //start = "<!--" + start + "-->";    
            //end = "<!--" + end + "-->";    
            //if (typeof (extend) == 'undefined') {        
            //    var temp = window.document.body.innerHTML;        
            //    var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
            //    window.document.body.innerHTML = printhtml;        
            //    window.print();        
            //    window.document.body.innerHTML = temp;    
            //}    
            //else { window.print(); }
            cMyPrint();
        }
        function DeleteT() { //20141231：M_DeleteC
            $("#btnADelete").hide();
            var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
		    var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
            if(sReturnValue=='deleted')
                window.location='/Apply/Apply_Search.aspx';
            else
                window.location.href=window.location.href;
		}
    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td {
            border: 0;
        }
         .btnImport 
        {
            background:url(../../images/biaoji.png) no-repeat;text-indent:99px;cursor:pointer;height: 36px;
    width: 104px;
    font-size: 0px;
        }
        .styleKindOfWSA {
            padding-left:80px;
        }
        .KindOfWS {
            padding-left:60px;
        }
        .auto-style2 {
            width: 20%;
            text-align: center;
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
            <h1>广东中原地产代理有限公司</h1>
            <h1>错存帐户调整申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='640px'>
                <tr style="display:none;">
                    <td class="auto-style2"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="4" style="padding: 20px; text-align: left; line-height: 30px;">
                        致：财务部<br />
                        由：<asp:TextBox ID="txtDepartment" runat="server" Width="250px"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />分行<br />
                        物业单位地址：<asp:TextBox ID="txtAddress" runat="server" Width="85%"></asp:TextBox><br />
                        <asp:RadioButton ID="rdbADNo1" runat="server" GroupName="ADNo" Text="收据号" />
                        <asp:RadioButton ID="rdbADNo2" runat="server" GroupName="ADNo" Text="发票号" />：
                        <asp:TextBox ID="txtApplyID" runat="server" Width="77%"></asp:TextBox><br />
                        错存日期：<asp:TextBox ID="txtWSDate" runat="server" Width="75px"></asp:TextBox>日；款项实际性质：
                        <asp:RadioButton ID="rdbKindOfM1" runat="server" GroupName="KindOfM" Text="代收款" />
                        <asp:RadioButton ID="rdbKindOfM2" runat="server" GroupName="KindOfM" Text="佣金" />；<br />
                        金额（大写）：<asp:TextBox ID="txtBigSMoney" runat="server" ></asp:TextBox>
                        金额（小写）：<asp:TextBox ID="txtSmallSMoney" runat="server" ></asp:TextBox><br />
                       
                        错存帐户：<asp:RadioButton ID="rdbKindOfWS1" runat="server" GroupName="KindOfWS" Text="中原代收款"  />
                        <asp:RadioButton ID="rdbKindOfWSA1" runat="server" GroupName="KindOfWSA" Text="对公户" CssClass="styleKindOfWSA" />　/
                        <asp:RadioButton ID="rdbKindOfWSA2" runat="server" GroupName="KindOfWSA" Text="对私户" /><br />

                        <asp:RadioButton ID="rdbKindOfWS2" runat="server" GroupName="KindOfWS" Text="中原佣金" CssClass="KindOfWS" />　
                        <asp:RadioButton ID="rdbKindOfWSB1" runat="server" GroupName="KindOfWSA" Text="对公户" CssClass="styleKindOfWSA" />　/
                        <asp:RadioButton ID="rdbKindOfWSB2" runat="server" GroupName="KindOfWSA" Text="对私户" /><br />

                        <asp:RadioButton ID="rdbKindOfWS3" runat="server" GroupName="KindOfWS" Text="汇瀚代收款" CssClass="KindOfWS" />
                        <asp:RadioButton ID="rdbKindOfWSC1" runat="server" GroupName="KindOfWSA" Text="对公户" CssClass="styleKindOfWSA" />　/
                        <asp:RadioButton ID="rdbKindOfWSC2" runat="server" GroupName="KindOfWSA" Text="对私户" /><br />
                      
                         <asp:RadioButton ID="rdbKindOfWS4" runat="server" GroupName="KindOfWS" Text="汇瀚佣金" CssClass="KindOfWS" />
                        <asp:RadioButton ID="rdbKindOfWSD1" runat="server" GroupName="KindOfWSA" Text="对公户" CssClass="styleKindOfWSA" />　/
                        <asp:RadioButton ID="rdbKindOfWSD2" runat="server" GroupName="KindOfWSA" Text="对私户" /><br />

                         <span id="Kind">
                        应存帐户：<asp:RadioButton ID="rdbKShouldS1" runat="server" GroupName="KShouldS" Text="中原代收款" />
                        <asp:RadioButton ID="rdbKShouldSA1" runat="server" GroupName="KShouldSA" Text="对公户" CssClass="styleKindOfWSA" />　/
                        <asp:RadioButton ID="rdbKShouldSA2" runat="server" GroupName="KShouldSA" Text="对私户" /><br />

                        <asp:RadioButton ID="rdbKShouldS2" runat="server" GroupName="KShouldS" Text="中原佣金" CssClass="KindOfWS" />　
                        <asp:RadioButton ID="rdbKShouldSB1" runat="server" GroupName="KShouldSA" Text="对公户" CssClass="styleKindOfWSA" />　/
                        <asp:RadioButton ID="rdbKShouldSB2" runat="server" GroupName="KShouldSA" Text="对私户" /><br />

                        <asp:RadioButton ID="rdbKShouldS3" runat="server" GroupName="KShouldS" Text="汇瀚代收款" CssClass="KindOfWS" />
                        <asp:RadioButton ID="rdbKShouldSC1" runat="server" GroupName="KShouldSA" Text="对公户" CssClass="styleKindOfWSA" />　/
                        <asp:RadioButton ID="rdbKShouldSC2" runat="server" GroupName="KShouldSA" Text="对私户" /><br />

                             
                        <asp:RadioButton ID="rdbKShouldS4" runat="server" GroupName="KShouldS" Text="汇瀚佣金" CssClass="KindOfWS" />
                        <asp:RadioButton ID="rdbKShouldSD1" runat="server" GroupName="KShouldSA" Text="对公户" CssClass="styleKindOfWSA" />　/
                        <asp:RadioButton ID="rdbKShouldSD2" runat="server" GroupName="KShouldSA" Text="对私户" /><br />
                            </span>
                        <span class ="hidePay">
                         收款人名称:  <asp:Label ID="LPayee" runat="server" Width="200px"></asp:Label>
                         收款账号:  <asp:Label runat="server" id="LPayNum"></asp:Label><br/>
                         收款银行及开户支行名称:   <asp:Label runat="server" id="lPayBank"></asp:Label> <br/>
                              <asp:HiddenField  ID="hfPayee" runat="server"/>
                              <asp:HiddenField  ID="hfPayNum" runat="server"/>
                              <asp:HiddenField  ID="hfPayBank" runat="server"/>
                        </span>

                        错存责任人：<asp:TextBox ID="txtWname" runat="server" Width="150px"></asp:TextBox>
                        职位：<asp:TextBox ID="txtWposition" runat="server" Width="190px"></asp:TextBox><br />
                        错存原因：<asp:TextBox ID="txtOpinion" runat="server" Height="100px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                    </td>
                </tr>

                <tr style="display:none;">
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 390px;">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>

                <tr id="trManager1" class="noborder" style="height: 85px;">
                    <td class="auto-style2" >填表人（行政助理）</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                        <%--<div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx1">_________</span></div>--%>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 85px;">
                    <td class="auto-style2" >主管意见</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                        <%--<div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx2">_________</span></div>--%>
                    </td>
                </tr>
                <tr id="trManager3" class="noborder" style="height: 85px;">
                    <td class="auto-style2" >总监签名</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
                        <textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
                        <%--<div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx3">_________</span></div>--%>
                    </td>
                </tr>
                <tr id="trManager4" class="noborder" style="height: 85px;">
                    <td class="auto-style2" >行政主任签名</td>
                    <td colspan="4" class="tl PL10">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><br />
                        <textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
                        <%--<div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx4">_________</span></div>--%>
                    </td>
                </tr>
<%--                <tr id="trManager5" class="noborder" style="height: 85px;">
                    <td class="auto-style2" >总监签名</td>
                    <td colspan="5" class="tl PL10">
                        <input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><br />
                        <textarea id="txtIDx5" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签名" onclick="sign('5')" style="display: none;" /><div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx5">_________</span></div>
                    </td>
                </tr>--%>

                <tr class="noborder" style="height: 85px;">
                    <td rowspan="4" class="auto-style2">财务部</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx6" type="radio" name="agree6" />
                        <label for="rdbYesIDx6">同意</label>
                        <input id="rdbNoIDx6" type="radio" name="agree6" />
                        <label for="rdbNoIDx6">不同意</label>
                        <input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label><br />
                        <textarea id="txtIDx6" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S1"></textarea>
                        <input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
                        <%--<div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx6">_________</span></div>--%>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx7" type="radio" name="agree7" />
                        <label for="rdbYesIDx7">同意</label>
                        <input id="rdbNoIDx7" type="radio" name="agree7" />
                        <label for="rdbNoIDx7">不同意</label>
                        <input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
                        <textarea id="txtIDx7" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
                        <%--<div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx7">_________</span></div>--%>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx8" type="radio" name="agree8" />
                        <label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" />
                        <label for="rdbNoIDx8">不同意</label>
                        <input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        <textarea id="txtIDx8" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
                        <%--<div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx8">_________</span></div>--%>
                    </td>
                </tr>

                <tr class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx9" type="radio" name="agree9" />
                        <label for="rdbYesIDx9">同意</label>
                        <input id="rdbNoIDx9" type="radio" name="agree9" />
                        <label for="rdbNoIDx9">不同意</label>
                        <input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label><br />
                        <textarea id="txtIDx9" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
                        </span>
                        <%--<div style="text-align: right; padding-right: 30px; padding-bottom: 10px;">日期：<span id="spanDateIDx9">_________</span></div>--%>
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
              <%--<asp:Button runat="server"  CssClass="btnImport" ID="btnImport" Text="标记导出" OnClick="btnImport_Click"/>--%>
            <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />

            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
            <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
            <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
            <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
            <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
            <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
            <asp:HiddenField ID="hdIsAgree" runat="server" />
            <asp:HiddenField ID="hdSuggestion" runat="server" />
            <input type="hidden" id="hdDetail" runat="server" />
            <asp:HiddenField ID="hdCancelSign" runat="server" />
            <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
        </div>
    </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
          
       
    </script>
</asp:Content>

