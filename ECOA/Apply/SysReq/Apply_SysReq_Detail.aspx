<%@ Page Title="软件系统开发需求申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_SysReq_Detail.aspx.cs" Inherits="Apply_SysReq_Apply_SysReq_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var jJSON = <%=sbJSON.ToString() %>;
        var jManagerJSON = <%=sbManagerJSON.ToString() %>;
        var jFollower = <%=sbFollowerJSON.ToString() %>;

        $(function() {
//            $("#li3").attr("class", "current");
            //            $("#li3_dd2").attr("class", "current");
            $("[id*=btnSavePlanTime]").css({
                "background-image": "url(/Images/bsm_save1.png)",
                "height": "20px", 
                "width": "30px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnSavePlanTime]").mousedown(function () { $(this).css("background-image", "url(/Images/bsm_save2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/bsm_save1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/bsm_save1.png)"); });
            
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
                
            $("#<%=txtDispatchDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {
                            $("#<%=hdDispatchDepartmentID.ClientID %>").val(ui.item.id);
                        }
            });
            
            $("#<%=txtHeaderIDx3.ClientID %>").autocomplete({ 
                //source: jManagerJSON,
                //select: function( event, ui ) {}
                minLength: 0,
                source: function( request, response ) {
                    $.ajax({
                        url: "/Ajax/AutoCompLete.ashx",
                        dataType: "json",
                        data: {
                            EmpName:$("#<%=txtHeaderIDx3.ClientID %>").val()
                        },
                        success: function(data) {
                            response(data);
                        }
                    });

                },
                focus: function() {
                    // prevent value inserted on focus
                    return false;
                },
                select: function( event, ui ) {
                    var terms = split( this.value );
                    // remove the current input
                    terms.pop();
                    // add the selected item
                    terms.push( ui.item.value );
                    // add placeholder to get the comma-and-space at the end
                    terms.push( "" );
                    this.value = terms.join( "," );
                    return false;
                }
            });

            $("#<%=txtApplyDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
            
            $("#<%=txtHopeDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });

            $("#<%=txtPlanTime.ClientID %>").datepicker();
            
            function split( val ) {
              return val.split( /,\s*/ );
            }
            function extractLast( term ) {
              return split( term ).pop();
            }
 
            $( "#<%=txtFollower.ClientID %>")
                .bind( "keydown", function( event ) {
                    if ( event.keyCode === $.ui.keyCode.TAB && $( this ).data( "ui-autocomplete" ).menu.active ) {
                        event.preventDefault();
                    }
                })
                .autocomplete({
                    minLength: 0,
                    source: function( request, response ) {
                        response( $.ui.autocomplete.filter(jFollower, extractLast( request.term ) ) );
                    },
                    focus: function() {
                        return false;
                    },
                    select: function( event, ui ) {
                        var terms = split( this.value );
                        terms.pop();
                        terms.push( ui.item.value );
                        terms.push( "" );
                        this.value = terms.join( "," );
                        return false;
                    }
                });
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
        
        function check() {
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {
                alert("发文部门不可为空。请输入关键字，点选申请部门。");
                $("#<%=txtDispatchDepartment.ClientID %>").focus();
                return false;
            }
            
            if(!checkdate($("#<%=txtApplyDate.ClientID %>").val())){
                alert("申请日期格式错误，请按以下格式输入日期:\n2013-07-22");
                $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }
            
            if(!checkdate($("#<%=txtHopeDate.ClientID %>").val())){
                alert("期望完成日期格式错误，请按以下格式输入日期:\n2013-07-22");
                $("#<%=txtHopeDate.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtReqContent.ClientID %>").val())=="") {
                alert("需求内容不可为空。");
                $("#<%=txtReqContent.ClientID %>").focus();
                return false;
            }
            
            if($.trim($("#<%=txtApplicant.ClientID %>").val())=="") {
                alert("申请人不可为空。");
                $("#<%=txtApplicant.ClientID %>").focus();
                return false;
            }
              
            return true;
        }
                
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
        function sign(idx) {
            //if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {
            //    alert("请确定是否同意！");
            //    return;
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

                var follower=$('#<%=txtFollower.ClientID %>').val();
                if(idx=='4' && $.trim(follower)!=''){
                    $.ajax({
                        url: "/Ajax/Apply_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: "action=savesysreqfollower&sysreqid=<%=ID %>&follower=" + follower+"&apply=" + $.trim($("#<%=txtApplicant.ClientID %>").val()),
                        success: function() {}
                    })
                }

                document.getElementById("<%=btnSign.ClientID %>").click();
            }
        }
        
        function getSuggestion(idx) {
            $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
        }

        function checkdate(val) { 
             var datetype=/^[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}$/; 
            return datetype.exec(val);
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
        
        function editflow(){
            var win=window.showModalDialog("Apply_SysReq_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=250px");
            if(win=='success')
                window.location="Apply_SysReq_Detail.aspx?MainID=<%=MainID %>";
        }
        
        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_SysReq_Detail.aspx?MainID=<%=MainID %>';
        }
        
        function checkAll(n) {
            var gv = document.getElementById('<%=gvAttach.ClientID%>'); //获取GridView的客户端ID
            var input = gv.getElementsByTagName("input"); //获取GridView的Inputhtml

            if (n.checked) {
                for (var i = 0; i < input.length; i++) {
                    if (input[i].type == 'checkbox' && input[i].disabled != true)
                        input[i].checked = true;
                }
            }
            else {
                for (var i = 0; i < input.length; i++) {
                    if (input[i].type == 'checkbox' && input[i].disabled != true)
                        input[i].checked = false;
                }
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
        
        function checkTransmit() {
            if($.trim($("#<%=txtHeaderIDx3.ClientID %>").val())=="") {
                alert("请先填选需要转发的负责人的姓名！");
                $("#<%=txtHeaderIDx3.ClientID %>").focus();
                return false;
            }
              
            return true;
        }
        
        function savePlanTime() {
          var plantime=$('#<%=txtPlanTime.ClientID %>').val();
            if($.trim(plantime)=="") {
                alert("请先填写预计完成时间！");
                $("#<%=txtPlanTime.ClientID %>").focus();
            }
            else
            { 
                $.ajax({
                    url: "/Ajax/Apply_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: "action=savesysreqplantime&sysreqid=<%=ID %>&plantime=" + plantime + "&follower=<%=EmployeeName %>&apply=" + $.trim($("#<%=txtApplicant.ClientID %>").val()),
                    success: function(info) {
                        if(info=='success')
                            alert('保存成功');
                        else
                            alert('保存失败');
                    }
                })
            }
            
            return false;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style='text-align:center; width:640px; margin:0px auto;'>
        <div class="noprint">
        <%=sbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align:center'>            
            <h1>广东中原地产代理有限公司</h1>
            <h1>软件系统开发需求申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"></div>
            <table id="tbAround"  width='640px'>
                <tr>
                    <td style="width:25%;">收文部门</td>
                    <td colspan="3">资讯科技部</td>
                </tr>
                <tr>
                    <td>发文部门</td>
                    <td style="width:25%;" class="tl PL5 PR5"><asp:TextBox ID="txtDispatchDepartment" runat="server" Width="184px"></asp:TextBox><asp:HiddenField ID="hdDispatchDepartmentID" runat="server" /></td>
                    <td style="width:30%;*width:12%;">申请时间</td>
                    <td style="width:25%;*width:18%;" class="tl PL5 PR5"><asp:TextBox ID="txtApplyDate" runat="server" Width="150px"></asp:TextBox></td>
                </tr>	
                <tr>
                    <td>系统名称</td>
                    <td class="tl PL5">
                        <asp:DropDownList ID="ddlSystemName" runat="server" Width="190px"></asp:DropDownList>
                    </td>
                    <td>期望完成日期</td>
                    <td class="tl PL5 PR5"><asp:TextBox ID="txtHopeDate" runat="server" Width="150px"></asp:TextBox></td>
                </tr>		
                <tr style="height:200px; ">
                    <td colspan="4"><div style="float:left; margin-left:11px;">需求内容：</div><asp:TextBox ID="txtReqContent" runat="server" Width="98%" Height="98%" Rows="15" TextMode="MultiLine" style="overflow:auto;"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>申请人</td>
                    <td><asp:TextBox ID="txtApplicant" runat="server" Width="96%"></asp:TextBox></td>
                    <td>申请部门主管</td>
                    <td><asp:TextBox ID="txtApplyDepHeader" runat="server" Width="96%" Visible="false"></asp:TextBox></td>
                </tr>
                <tr style="height:30px; ">
                    <td>部门主管意见</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label>
                        <textarea id="txtIDx1" rows="4" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx1" value="签署意见" onclick="sign('1')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div></td>
                </tr>
                <tr style="height:30px; ">
                    <td>部门负责人意见</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label>
                        <textarea id="txtIDx2" rows="4" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx2" value="签署意见" onclick="sign('2')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div></td>
                </tr>
                <tr style="height:50px; vertical-align: bottom;">
                    <td colspan="4">以下是资讯科技部内部使用</td>
                </tr>	
                <tr>
                    <td>文档编码(自动生成)</td>
                    <td colspan="3"><%=SerialNumber %></td>
                </tr>	
                <tr style="height:30px; ">
                    <td>软件组主管意见</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label>
                        <textarea id="txtIDx4" rows="3" style="width:98%; overflow:auto; "></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
                        <div style="text-align:left;">
                            <br />转<asp:TextBox ID="txtHeaderIDx3" runat="server" Width="200px"></asp:TextBox>审批<asp:Button runat="server" ID="btnTransmit" Text="转发" OnClick="btnTransmit_Click" OnClientClick="return checkTransmit();" Visible="false" /> 以下为说明：
                            <br /><asp:TextBox ID="txtTransferRemark" runat="server" TextMode="MultiLine" Rows="3" Columns="58" style="margin-left:1px; overflow:auto;"></asp:TextBox>
                        </div>
                    </td>       
                 </tr>	
                <tr style="height:30px; ">
                    <td>部门经理意见</td>
                    <td colspan="3" class="tl PL10">
                        <div style="display:none;"><input id="rdbYesIDx5" type="radio" name="agree5" /><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label>
                        <textarea id="txtIDx5" rows="2" style="width:98%; overflow:auto; display:none;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx5">_________</span></div></div></td>
                </tr>	
                <tr style="height:30px; ">
                    <td>部门负责人意见</td>
                    <td colspan="3" class="tl PL10">
                        <div style="display:none;"><input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label>
                        <textarea id="txtIDx6" rows="3" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx6" value="签署处理情况" onclick="sign('6')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx6">_________</span></div></div></td>
                </tr>	
                <tr>
                    <td>转其他部门负责人审批</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                        <textarea id="txtIDx3" rows="4" style="width:98%; overflow:auto;"></textarea><input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display:none;"/><div class="signdate">日期：<span id="spanDateIDx3">_________</span></div></td>
                </tr>	
                <tr>
                    <td>跟进人</td>
                    <td>
                        <asp:TextBox ID="txtFollower" runat="server" Width="96%"></asp:TextBox>
                    </td>
                    <td>资讯科技部预计完成时间</td>
                    <td><asp:TextBox ID="txtPlanTime" runat="server" Width="96%"></asp:TextBox><asp:Button runat="server" ID="btnSavePlanTime" Text="保存" OnClientClick="return savePlanTime();" Visible="false" /></td>
                </tr>
            </table>
            <!--打印正文结束-->
        </div>

        <div class="noprint">
        <asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" BackColor="White" style="clear:both; margin-top:3px;"
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
                <asp:TemplateField HeaderText="删除" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:ImageButton ID="iBtnDelete" runat="server"  ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID") %>' OnClientClick="return confirm('确认删除？');" />
                        <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
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
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left:5px; display:none;" />
        <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" onclick="btnDownload_Click" OnClientClick="return checkChecked();" style="margin-left:5px;" Visible="false" />
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display:none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <%--<input type="button" id="btnGoBack" value="返回" onclick="window.history.go(-1);" />--%>
        <%--<input type="button" id="btnGoBack" value="返回" onclick="window.location='/Apply/Apply_Search.aspx';" />--%>
        <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click"/>
        <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" style="display:none;" />
        <asp:HiddenField ID="hdIsAgree" runat="server" />
        <asp:HiddenField ID="hdSuggestion" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=sbJS.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

