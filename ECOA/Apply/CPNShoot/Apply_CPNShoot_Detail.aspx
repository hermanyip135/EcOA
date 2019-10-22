<%@ Page ValidateRequest="false" Title="拍摄需求申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_CPNShoot_Detail.aspx.cs" Inherits="Apply_CPNShoot_Apply_CPNShoot_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1, i2 = 1;
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

            $("#<%=txtApplyDate.ClientID%>").datepicker();
		    $("#<%=txtAcceptDate.ClientID%>").datepicker();
            $("#<%=txtShootDate.ClientID%>").datepicker();
            $("#<%=txtExpectDate.ClientID%>").datepicker();
            $("#<%=txtExpectOnlineDate.ClientID%>").datepicker();
            
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        // 对Date的扩展，将 Date 转化为指定格式的String 
        // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
        // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
        // 例子： 
        // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
        // (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
        Date.prototype.Format = function(fmt) 
        { //author: meizz 
            var o = { 
                "M+" : this.getMonth()+1,                 //月份 
                "d+" : this.getDate(),                    //日 
                "h+" : this.getHours(),                   //小时 
                "m+" : this.getMinutes(),                 //分 
                "s+" : this.getSeconds(),                 //秒 
                "q+" : Math.floor((this.getMonth()+3)/3), //季度 
                "S"  : this.getMilliseconds()             //毫秒 
            }; 
            if(/(y+)/.test(fmt)) 
                fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length)); 
            for(var k in o) 
                if(new RegExp("("+ k +")").test(fmt)) 
                    fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length))); 
            return fmt; 
        }

        function check() {
	        
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("申请部门/分行/组别不可为空！");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
			
            if($.trim($("#<%=txtApplyDate.ClientID %>").val())=="") {
                alert("申请日期不可为空！");
                $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtApply.ClientID %>").val())=="") {
                alert("申请人不可为空！");
                $("#<%=txtApply.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtConneter.ClientID %>").val())=="") {
                alert("联系人/电话(手机)不可为空！");
                $("#<%=txtConneter.ClientID %>").focus();
                return false;
            }else
            {
                var reg=/^1[3|4|5|8][0-9]\d{8}$|^\d{8}$/;
                if(!reg.test($.trim($("#<%=txtConneter.ClientID %>").val())))
                {
                    alert("请输入正确的11位手机号码或8位数字的号码！");
                    $("#<%=txtConneter.ClientID %>").focus();
                    return false;
                }
                
            }

            if($.trim($("#<%=txtShootDate.ClientID %>").val())=="") {
                alert("拍摄日期不可为空！");
                $("#<%=txtShootDate.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtShootAddress.ClientID %>").val())=="") {
                alert("拍摄地址不可为空！");
                $("#<%=txtShootAddress.ClientID %>").focus();
                return false;
            }

            if (!$("#<%=rdbShootContent1.ClientID %>").prop("checked") 
                && !$("#<%=rdbShootContent2.ClientID %>").prop("checked")
                && !$("#<%=rdbShootContent3.ClientID %>").prop("checked")
                ) {
                alert("请选择申请拍摄内容");
                $("#<%=rdbShootContent1.ClientID%>").focus();
	            return false;
            }

            if ($("#<%=rdbShootContent1.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfOneHouse1.ClientID %>").prop("checked") 
                     && !$("#<%=cbKindOfOneHouse2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfOneHouse3.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfOneHouse4.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfOneHouse5.ClientID %>").prop("checked")
                    ) 
                {
                    alert("请选择一手楼");
                    $("#<%=cbKindOfOneHouse1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfOneHouse5.ClientID%>").prop("checked")) {
                     if ($.trim($("#<%=txtAnotherOneHouse.ClientID%>").val()) == "") { alert("请填写其它一手楼！"); $("#<%=txtAnotherOneHouse.ClientID%>").focus(); return false; }
                }
            }

            if ($("#<%=rdbShootContent2.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfSecondHouse1.ClientID %>").prop("checked") 
                     && !$("#<%=cbKindOfSecondHouse2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfSecondHouse3.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfSecondHouse4.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfSecondHouse5.ClientID %>").prop("checked")
                    ) 
                {
                    alert("请选择二手楼");
                    $("#<%=cbKindOfSecondHouse1.ClientID%>").focus();
                    return false;
                }
                if ($("#<%=cbKindOfSecondHouse5.ClientID%>").prop("checked")) {
                    if ($.trim($("#<%=txtAnotherSecondHouse.ClientID%>").val()) == "") { alert("请填写其它二手楼！"); $("#<%=txtAnotherSecondHouse.ClientID%>").focus(); return false; }
                }
            }

            if ($("#<%=rdbShootContent3.ClientID %>").prop("checked")){

                if ($.trim($("#<%=txtAnotherAnimation.ClientID%>").val()) == "") 
                { 
                    //alert("请填写动画设计！");
                    alert("请填写其他！");
                    $("#<%=txtAnotherAnimation.ClientID%>").focus();
                    return false; 
                }
            }

            if (!$("#<%=rdbPropertyNum.ClientID %>").prop("checked") 
               && !$("#<%=rdbAnotherNum.ClientID %>").prop("checked")
                ) {
                 alert("请选择拍摄数量！");
                 $("#<%=rdbPropertyNum.ClientID%>").focus();
                return false;
            }

            if ($("#<%=rdbPropertyNum.ClientID %>").prop("checked")){

                if ($.trim($("#<%=txtPropertyNum.ClientID%>").val()) == "") 
                 { 
                     alert("请填写盘源数量！"); 
                     $("#<%=txtPropertyNum.ClientID%>").focus();
                    return false; 
                } else if(($.trim($("#<%=txtPropertyNum.ClientID%>").val())*1>3))
                {
                    alert("拍摄数量为3个以内！"); 
                    $("#<%=txtPropertyNum.ClientID%>").focus();
                return false; 
               }
            }

            if ($("#<%=rdbAnotherNum.ClientID %>").prop("checked")){

                if ($.trim($("#<%=txtAnotherDesc.ClientID%>").val()) == "") 
                { 
                    alert("请填写其他拍摄项目！"); 
                    $("#<%=txtAnotherDesc.ClientID%>").focus();
                    return false; 
                }else if ($.trim($("#<%=txtAnotherNum.ClientID%>").val()) == "") 
                { 
                    alert("请填写其他拍摄项目的数量！"); 
                    $("#<%=txtAnotherNum.ClientID%>").focus();
                     return false; 
                }else if(($.trim($("#<%=txtAnotherNum.ClientID%>").val())*1>3))
                {
                    alert("拍摄数量为3个以内！"); 
                    $("#<%=txtAnotherNum.ClientID%>").focus();
                return false; 
               }
            }

           
             if($.trim($("#<%=txtSummary.ClientID %>").val())=="")
             {
                   alert("请输入拍摄要求详述！");
                   $("#<%=txtSummary.ClientID%>").focus();
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
		        window.location='Apply_Propaganda_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_Propaganda_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_NewPropaganda_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }
		
                function sign(idx) {
                    //if(idx!='7'&&idx!='8'10||idx=='130'){
                    //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='6'||idx=='9'||idx=='11'||idx=='131'){//789
                    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                        alert("请确定是否同意！");
                        return;
                    }
                    //}
                    //else{
                    //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                    //        alert("请确定是否同意！");
                    //        return;
                    //    }
                    //}
			
                    if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
                        alert("由于您不同意该申请，请填写具体原因。");
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
        .auto-style1 {
            width: 15%;
        }
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
<%--    <div class="tips">
        <p><b>一、申请部门填写：</b>“★”号为必须填写内容；</p>
        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;申请编号：由市场部填写</p>
        <p><b>二、宣传类型包括（只可选单类）：</b>如项目内没有所需求内容，请选择“其他”并填上相关内容； </p>
        <p><b>三、制作项目名称/概念详述：</b>请写明使用目的，设计要求[如颜色、排版等]，制作要求、数量等；</p>
        <p><b>四、支付情况：</b>根据区域/部门实际支付情况进行选择：</p>
        <p>1、区域有预算，可选择“由申请项目之预算费用中支付”；</p>
        <p>2、区域预算其中一类别使用完毕，需进行调用，可选择“由预算中他项费用中调用，”并填写《广告宣传预算使用异常申请表》； </p> 
        <p>3、如区域没有任何预算，或临时接到新项目，需制作或购买宣传物料，可选择“另行《费用申请》中支付”，前提先另行申请费用（市场推广费用申请）。</p>
        <p><b>五、摊分情况：</b>如以片区进行申请，请提供摊分部门/分行/级别；</p>
        <p><b>六、送货清单（必填）：</b>市内分行可送货；如以片区申请，物料制作供应商只能送至其中两间分行；外区：送总部后自取或快递寄至分行；</p>
        <p><b>七、审批流程：</b></p>
        <p>申请人：部门/分行组别主管签署——总监/区域负责人</p>
        <p>审批人（市场部）：王萍/周燕妮/招琛彤/王珏萍</p>
    </div>--%>
    <script type="text/javascript">
        function tipswidth()
        {
            var tipswidth = (document.body.clientWidth - 700)/2
            $(".tips").width(tipswidth);
        }
        tipswidth();
        window.onresize = function(){
            tipswidth();
        }
    </script>
	<div style='text-align: center; width: 640px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>拍摄需求申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <%--<div id="Div1" style="width:640px;margin:0 auto;">--%>
                <span style="float: right;" class="file_number">申请编号：
                    <asp:TextBox ID="txtTNo" runat="server" Width="160px"></asp:TextBox>
                </span>
            <%--</div>--%>
			<table id="tbAround"  width='640px'>
                <tr>
                    <td colspan="4" class="tl PL10" bgcolor="Black"><span style="color: #FFFFFF; font-weight: bold;">申请部门填写 （ “★”号为必须填写内容）</span></td>
                </tr>
				<tr>
					<td colspan="4" class="tl PL10" style="line-height: 25px">
                        <div id="snum" style="width:640px;margin:0 auto;"><span class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
                        ★申请部门/分行/组别：<asp:textbox id="txtDepartment" runat="server" Width="215px"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" />
					  　★申请日期：<asp:textbox id="txtApplyDate" runat="server"></asp:textbox><br />
                        ★申请人：<asp:textbox id="txtApply" runat="server" Width="80px"></asp:textbox>
                        <span style="margin-left:100px;">★联系人/电话(手机)：<asp:textbox id="txtConneter" runat="server"></asp:textbox></span><br />
                        ★拍摄日期：<asp:textbox id="txtShootDate" runat="server"></asp:textbox>
                        ★拍摄地点：<asp:textbox id="txtShootAddress" runat="server"></asp:textbox>
                    </td>
				</tr>
				<tr>
					<td colspan="4" class="tl PL10" style="line-height: 25px">
                        
                        <span style="font-weight: bold">◤申请拍摄内容：</span><br />
                        <div class="shootcontent">
                        <asp:RadioButton ID="rdbShootContent1" runat="server" GroupName="ShootContent" Text="一手楼" />
                        （<asp:CheckBox ID="cbKindOfOneHouse1" runat="server" Text="楼房" />
                        <asp:CheckBox ID="cbKindOfOneHouse2" runat="server" Text="开售" />
                        <asp:CheckBox ID="cbKindOfOneHouse3" runat="server" Text="培训" />
                        <asp:CheckBox ID="cbKindOfOneHouse4" runat="server" Text="誓师会" /><br />　　　　
                        <asp:CheckBox ID="cbKindOfOneHouse5" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherOneHouse" runat="server" Width="470px"></asp:textbox>）<br />
                        </div>

                
                        <div class="shootcontent">
                        <asp:RadioButton ID="rdbShootContent2" runat="server" GroupName="ShootContent" Text="二手楼" />
                        （<asp:CheckBox ID="cbKindOfSecondHouse1" runat="server" Text="现房" />
                        <asp:CheckBox ID="cbKindOfSecondHouse2" runat="server" Text="小区环境" />
                        <asp:CheckBox ID="cbKindOfSecondHouse3" runat="server" Text="小区配套" />
                        <asp:CheckBox ID="cbKindOfSecondHouse4" runat="server" Text="周边环境" /><br />　　　　　
                        <asp:CheckBox ID="cbKindOfSecondHouse5" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherSecondHouse" runat="server" Width="470px"></asp:textbox>）<br />
                        </div>

                        <div class="shootcontent">
                        <%--<asp:RadioButton ID="rdbShootContent3" runat="server" GroupName="ShootContent" Text="动画设计" />--%>
                            <asp:RadioButton ID="rdbShootContent3" runat="server" GroupName="ShootContent" Text="其他" />
                        （
                        <asp:textbox id="txtAnotherAnimation" runat="server" Width="470px"></asp:textbox>）<br />
                         </div>
                         </td>
                   </tr>
                        
                 <tr>
                    <td colspan="4" class="tl PL10" style="line-height: 25px">
                        <span style="font-weight: bold">◤拍摄数量：</span><br />
                        <div class="shoottype">
                        <asp:RadioButton ID="rdbPropertyNum" runat="server" GroupName="shootnum" Text="盘源" />
                        （
                        <asp:textbox id="txtPropertyNum" runat="server" Width="50"></asp:textbox>）个<br />
                        <asp:RadioButton ID="rdbAnotherNum" runat="server" GroupName="shootnum" Text="其他" />
                        <asp:textbox id="txtAnotherDesc" runat="server" Width="470px"></asp:textbox>(<asp:textbox id="txtAnotherNum" runat="server" Width="50px"></asp:textbox>)个
                        </div>
                        <span>（注：一张申请表限拍摄数量为三个以内）</span><br />
                         </td>
                    </tr>
                  <tr>
                    <td colspan="4" class="tl PL10" style="line-height: 25px">
                        <span style="font-weight: bold">◤拍摄要求详述：</span><br />
                        （请详述拍摄内容需展示的卖点）：<br />
                        <asp:textbox id="txtSummary" runat="server" Width="98%" Height="100px" TextMode="MultiLine"></asp:textbox><br />
                        <span>注：如有需要，申请部门可派专人联络接单人并安排全程跟进协助拍摄。</span>
                        <br /><br />
                        <span style="font-size:12px;font-weight:bold;">为配合拍摄制作顺利进行，请按不同的拍摄内容提供以下资料（请根据需求在附件中填写）：</span><br />
                        <span>一手楼盘——宣传单张、户型图、楼盘书、楼盘相片（如有其他资料，请补充）</span><br />
                        <span>二手楼盘——户型图、楼盘简介、小区配套、周边环境（如有其他资料，请补充）</span><br />
                        <span>其他内容——拍摄大纲或剧本内容（如有其他资料，请补充）</span><br />
					</td>
				</tr>


				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style1">摄影组</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx20" type="radio" name="agree1" /><label for="rdbYesIDx20">同意</label><input id="rdbNoIDx20" type="radio" name="agree1" /><label for="rdbNoIDx20">不同意</label><br />
						<textarea id="txtIDx20" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx20" value="签名" onclick="sign('20')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style1" rowspan="2">内容运营部</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx21" type="radio" name="agree2" /><label for="rdbYesIDx21">同意</label><input id="rdbNoIDx21" type="radio" name="agree2" /><label for="rdbNoIDx21">不同意</label><br />
						<textarea id="txtIDx21" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx21" value="签名" onclick="sign('21')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                        
					</td>
                    </tr>
                      <tr>
                    	<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx25" type="radio" name="agree3" /><label for="rdbYesIDx25">同意</label><input id="rdbNoIDx25" type="radio" name="agree3" /><label for="rdbNoIDx25">不同意</label><br />
						<textarea id="txtIDx25" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx25" value="签名" onclick="sign('25')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx25">_________</span>
                        </span>
                        
					</td>
				</tr>
               

                <tr>
                    <td colspan="4" class="tl PL10" bgcolor="Black"><span style="color: #FFFFFF; font-weight: bold">跟进情况（以下由市场部填写）</span></td>
                </tr>

				<tr>
					<td colspan="4" class="tl PL10" style="line-height: 30px">
                        市场部意见：<asp:textbox id="txtMarketDepSuggestion" runat="server" Width="470px"></asp:textbox><br />
                        接单日期：<asp:textbox id="txtAcceptDate" runat="server" Width="135px"></asp:textbox>
                        接单人：<asp:textbox id="txtAccepter" runat="server" Width="135px"></asp:textbox>
                        制作人：<asp:CheckBox ID="chkProducer1" runat="server" Text="陈启兴" />
                        <asp:CheckBox ID="chkProducer2" runat="server" Text="温德圣" />
                        <%--<asp:CheckBox ID="chkProducer3" runat="server" Text="黄莎莉" />--%>
                        <br />
                        预计拍摄时间：<asp:textbox id="txtExpectDate" runat="server" Width="135px"></asp:textbox>
                        预计上线时间：<asp:textbox id="txtExpectOnlineDate" runat="server" Width="135px"></asp:textbox><br />
                        完成情况：<asp:RadioButton ID="rdbComplete" runat="server" GroupName="CompleteResult" Text="已完成" />
                        <asp:RadioButton ID="rdbNoComplete" runat="server" GroupName="CompleteResult" Text="未完成（修改或重拍需注明情况）：" />
                        <asp:textbox id="txtNoCompelteDescript" runat="server" TextMode="MultiLine" Width="79%" Height="100px"></asp:textbox>
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
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <asp:button runat="server" id="btnSaveCompleteResult" text="保存完成情况" onclick="btnSaveCompleteResult_Click" visible="false" />
		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
		<asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
		<input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
        <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
		<asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
		<asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
		<asp:hiddenfield id="hdIsAgree" runat="server" />
		<asp:hiddenfield id="hdSuggestion" runat="server" />
		<input type="hidden" id="hdDetail" runat="server" />
        <input type="hidden" id="hdDetail2" runat="server" />
        <input type="hidden" id="hdDetail3" runat="server" />
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
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
