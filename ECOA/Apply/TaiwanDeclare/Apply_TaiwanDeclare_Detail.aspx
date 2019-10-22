<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_TaiwanDeclare_Detail.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Apply_TaiwanDeclare_Apply_TaiwanDeclare_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <style type="text/css">
        .textleft {
        text-align:left;
        }
        .fontbold {
        font-weight: bold;
        }
        /*.EmpDataDis{
            background:Silver
        }
        .GroupDataDis{
         background:Silver
        }*/
    </style>
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        $(function() {      
          
          
          
           
            //初始化时间控件
            $("[dateplugin='datepicker']").each(function(){
                $(this).datepicker();
            });
            $("#<%=this.DeptName.ClientID%>").autocomplete({ source: jJSON });
            $("#<%=this.DeptName1.ClientID%>").autocomplete({ source: jJSON });

             
            $("#<%=EffectDate.ClientID%>").datepicker();
            $("#<%=EffectDate1.ClientID%>").datepicker();
            IsDisable($("#<%=this.IsScope.ClientID%>"));
            ISSetUpType($("#<%=this.SetUpType.ClientID%>"))
            FlowSignInit();
            IsScopeBind();
            SetUpTypeBind();
            logisticsTypeBind();
            BusinessTypeBind();
            ContentBind();
            chlicklogisticsType($("#<%=this.logisticsType.ClientID%>"));
             chlickBusinessType($("#<%=this.BusinessType.ClientID%>"));
        })
            //通用方法
            //打印
            function myPrint(start, end, extend) {
                //window.print();
                cMyPrint();
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
            
                cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.lblApply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
            }
    
            function getSuggestion(idx)
            {
                $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
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
                window.location='Apply_FinAffairsTransfer_Detail.aspx?MainID=<%=MainID %>';
         }
        //申请豁免范围
        function IsScopeBind() {
            var vIsScope = $("#<%=this.IsScope.ClientID%>").val();

            if (vIsScope == "") {
                $("input[name='r']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $("input[name=r][value=" + vIsScope + "]").get(0).checked = true;

            }
        }
        //中台人员设置类型 
        function SetUpTypeBind() {
            var vSetUpType = $("#<%=this.SetUpType.ClientID%>").val();

            if (vSetUpType == "") {
                $("input[name='r1']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $("input[name=r1][value=" + vSetUpType + "]").get(0).checked = true;

            }
        }
        //中台后勤服务人员 
        function logisticsTypeBind() {
            var vlogisticsType = $("#<%=this.logisticsType.ClientID%>").val();

            if (vlogisticsType == "") {
                $("input[name='r2']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $("input[name=r2][value=" + vlogisticsType + "]").get(0).checked = true;

            }
        }
        //中台后勤服务人员 
        function BusinessTypeBind() {
            var vBusinessType = $("#<%=this.BusinessType.ClientID%>").val();

            if (vBusinessType == "") {
                $("input[name='r3']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $("input[name=r3][value=" + vBusinessType + "]").get(0).checked = true;

            }
        }
        //申请豁免内容
        function ContentBind()
        {
            var vContent = $("#<%=this.Content.ClientID%>").val();
            var array = vContent.split("|");
            if(array!='')
            {
                for (var i = 0; i < array.length; i++) {
                    $r = $("input[name='c'][value=" + array[i] + "]");
                    if ($r != undefined) {
                        $r.get(0).checked = true;
                    }
                }
            }
          

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
                        $("#<%=Name.ClientID%>").val(infos[1]);
                        $("#<%=DeptName.ClientID%>").val(infos[2]);
                        $("#<%=Position.ClientID%>").val(infos[4]);
                        $("#<%=EntryDate.ClientID%>").val(infos[6]);
                    }
                    else{
                        $("#<%=Name.ClientID%>").val("");
                        $("#<%=DeptName.ClientID%>").val("");
                        $("#<%=Position.ClientID%>").val("");
                        $("#<%=EntryDate.ClientID%>").val("");
                    }
                }
            })
        }
        function IsDisable(n)
        {
            //1申请人资料 2 组别资料
            var IsScope = $(n).val()
            if("1" == IsScope)
            {
                $(".EmpDataDis td").css("background","");
                $(".GroupDataDis td").css("background","Silver");
                $(".EmpDataDis td input").attr("disabled",false);
                $(".GroupDataDis td input").attr("disabled","disabled");
                $("#<%=this.Region1.ClientID%>").val("");
                $("#<%=this.DeptName1.ClientID%>").val("");
                $("#<%=this.EffectDate1.ClientID%>").val("");
            }else if("2" == IsScope)
            {
                $(".EmpDataDis td").css("background","Silver");
                $(".GroupDataDis td").css("background","");
                $(".GroupDataDis td input").attr("disabled",false);
                $(".EmpDataDis td input").attr("disabled","disabled");
                $("#<%=this.Code.ClientID%>").val("");
                $("#<%=this.Name.ClientID%>").val("");
                $("#<%=this.Position.ClientID%>").val("");
                $("#<%=this.Phone.ClientID%>").val("");
                $("#<%=this.Region.ClientID%>").val("");
                $("#<%=this.DeptName.ClientID%>").val("");
                $("#<%=this.EffectDate.ClientID%>").val("");
                $("#<%=this.EntryDate.ClientID%>").val("");
            }
        }
        function ISSetUpType(n)
        {
            //1 中台后勤服务人员 2中台业务支持人员 
            var ISlogisticsType = $(n).val()
            if("1" == ISlogisticsType){
                $("#tdlogisticsType").css("background","");
                $("#tdlogisticsType1").css("background","");
                $("#tdBusinessType").css("background","Silver");
                $("#tdBusinessType1").css("background","Silver");
                $("#tdBusinessType1 input").prop("checked","");
                $("#<%=this.BusinessTypeRemarks.ClientID%>").val("");
                $("#tdlogisticsType1 input").attr("disabled",false);
                $("#tdBusinessType1 input").attr("disabled","disabled");
              
            }else if("2" == ISlogisticsType){
                $("#tdlogisticsType").css("background","Silver");
                $("#tdlogisticsType1").css("background","Silver");
                $("#tdBusinessType").css("background","");
                $("#tdBusinessType1").css("background","");
                $("#tdlogisticsType1 input").prop("checked","");
                $("#<%=this.logisticsTypeRemarks.ClientID%>").val("");
                $("#tdlogisticsType1 input").attr("disabled","disabled");
                $("#tdBusinessType1 input").attr("disabled",false);
               
            }
        }
        function chlicklogisticsType(n)
        {
            var vlogisticsTypeVal = $(n).val()
            if("3" == vlogisticsTypeVal)
            {  
                $("#<%=this.logisticsTypeRemarks.ClientID%>").attr("disabled",false);

            }
            else{
                $("#<%=this.logisticsTypeRemarks.ClientID%>").attr("disabled","disabled");
                $("#<%=this.logisticsTypeRemarks.ClientID%>").val("")
            }
        }
        function chlickBusinessType(n)
        {
            var vBusinessTypeVal = $(n).val()
            if("2" == vBusinessTypeVal)
            {  
                $("#<%=this.BusinessTypeRemarks.ClientID%>").attr("disabled",false);

            }
            else{
                $("#<%=this.BusinessTypeRemarks.ClientID%>").attr("disabled","disabled");
                $("#<%=this.BusinessTypeRemarks.ClientID%>").val("")
            }
        }
        function check() {
            //申请豁免范围
            flag = false;
            var val = "";
            $("input[name='r']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择申请豁免范围");
                $("#Radio1").focus();
                return false;
            }
            $("#<%=this.IsScope.ClientID%>").val(val);
            //仅以申请人个人为单位申请 
            if($("#<%=this.IsScope.ClientID%>").val()=="1")
            {
                if($.trim($("#<%=Code.ClientID %>").val())=="") {
                    alert("申请人工号不可为空！");
                    $("#<%=Code.ClientID %>").focus();
                return false;
                }
                if($.trim($("#<%=Name.ClientID %>").val())=="") {
                    alert("申请人姓名不可为空！");
                    $("#<%=Name.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=DeptName.ClientID %>").val())=="") {
                    alert("申请人组别名称不可为空！");
                    $("#<%=DeptName.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=Position.ClientID %>").val())=="") {
                    alert("申请人职位不可为空！");
                    $("#<%=Position.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=EntryDate.ClientID %>").val())=="") {
                    alert("申请人入职日期不可为空！");
                    $("#<%=EntryDate.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=Region.ClientID %>").val())=="请选择") {
                    alert("请选择申请人区域！");
                    $("#<%=Region.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=Phone.ClientID %>").val())=="") {
                    alert("申请人联系电话不可为空！");
                    $("#<%=Phone.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=EffectDate.ClientID %>").val())=="") {
                    alert("申请人生效日期不可为空！");
                    $("#<%=EffectDate.ClientID %>").focus();
                    return false;
                }
            }
            else if($("#<%=this.IsScope.ClientID%>").val()=="2")
            {
                if($.trim($("#<%=Region1.ClientID %>").val())=="请选择") {
                    alert("请选择申请组别区域！");
                    $("#<%=Region1.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=DeptName1.ClientID %>").val())=="") {
                    alert("申请组别名称不可为空！");
                    $("#<%=DeptName1.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=EffectDate1.ClientID %>").val())=="") {
                    alert("申请组别生效日期不可为空！");
                    $("#<%=EffectDate1.ClientID %>").focus();
                    return false;
                }
            }
           

            //中台人员设置类型
            flag = false;
            val = "";
            $("input[name='r1']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择中台人员设置类型");
                $("#Radio3").focus();
                return false;
            }
            $("#<%=this.SetUpType.ClientID%>").val(val);
            //1中台后勤服务人员 2中台业务支持人员
            if($("#<%=this.SetUpType.ClientID%>").val() == "1")
            {
                //中台后勤服务人员类型
                flag = false;
                val = "";
                $("input[name='r2']").each(function () {
                    if (this.checked) {
                        flag = true;
                        val = this.value;
                        if("3" == val)
                        {
                            if($.trim($("#<%=logisticsTypeRemarks.ClientID %>").val())=="") {
                                alert("请填写中台后勤服务人员其他备注！");
                                $("#<%=logisticsTypeRemarks.ClientID %>").focus();
                           return false;
                       }
                        }
                    }
                });
                if (!flag) {
                    alert("请选择中台后勤服务人员类型");
                    $("#Radio4").focus();
                    return false;
                }
                $("#<%=this.logisticsType.ClientID%>").val(val);
            }
            else if($("#<%=this.SetUpType.ClientID%>").val() == "2")
            {
                //中台业务支持人员 类型
                flag = false;
                val = "";
                $("input[name='r3']").each(function () {
                    if (this.checked) {
                        flag = true;
                        val = this.value;
                        if("2" == val)
                        {
                            if($.trim($("#<%=logisticsTypeRemarks.ClientID %>").val())=="") {
                                alert("请填写中台业务支持人员其他备注！");
                                $("#<%=logisticsTypeRemarks.ClientID %>").focus();
                                return false;
                            }
                        }
                    }});
                if (!flag) {
                    alert("请选择中台业务支持人员类型");
                    $("#Radio8").focus();
                    return false;
                }
                $("#<%=this.BusinessType.ClientID%>").val(val);
            }
          
        
            //申请豁免内容
            flag = false;
            val = "";
            $("input[type='checkbox']").each(function () {
                if (this.checked) {
                    flag = true;
                    val += this.value + "|";
                }
            });
            if (!flag) {
                alert("请选择申请豁免内容");
                $("#checkbox1").focus();
                return false;
            }
            if (val != "") {
                $("#<%=this.Content.ClientID%>").val(val.substring(0, val.length - 1));
             }
        };
    </script>
  <style type="text/css">
    
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width:640px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>三级市场中台人员申报表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 700px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>

            <table id ="tbAround" width="700" >
                <tr>
                    <td rowspan="2" class="fontbold" style="width:22%" >
                        <span style="color: red">*</span> 申请豁免范围
                    </td>
                    <td class="textleft" colspan="4">
                        <input type="radio" id="Radio1" name="r" value="1" onclick="IsDisable(this)"/><label for="Radio1">仅以申请人个人为单位申请</label>
                    </td>
                </tr>
                <tr>
                    <td class="textleft"  colspan="4">
                        <input type="radio" id="Radio2" name="r" value="2" onclick="IsDisable(this)"/><label for="Radio2">以组别为单位申请</label>
                        <asp:HiddenField ID="IsScope" runat="server" />
                    </td>
                </tr>
                <tr class="EmpDataDis">
                    <td rowspan="4" class="fontbold"> 申请人基本资料</td>
                    <td style="width:13%">工号</td>
                    <td ><asp:TextBox ID="Code" runat="server" onblur="getEmployee(this);"></asp:TextBox></td>
                    <td style="width:13%">姓名</td>
                    <td> <asp:TextBox ID="Name" runat="server" ></asp:TextBox></td>
                </tr>
                <tr  class="EmpDataDis">
                    <td>组别名称</td>
                    <td><asp:TextBox ID="DeptName" runat="server" ></asp:TextBox></td>
                    <td>职位</td>
                    <td> <asp:TextBox ID="Position" runat="server" ></asp:TextBox></td>
                </tr>
                 <tr  class="EmpDataDis">
                    <td>入职日期</td>
                    <td><asp:TextBox ID="EntryDate" runat="server" ></asp:TextBox></td>
                    <td>区域</td>
                    <td> 
                       <%-- <asp:TextBox ID="Region" runat="server" ></asp:TextBox>--%>
                         <asp:DropDownList runat="server" ID="Region"> 
                            <asp:ListItem>请选择 </asp:ListItem>
                            <asp:ListItem>大白云区 </asp:ListItem>
                             <asp:ListItem>大越秀区 </asp:ListItem>
                             <asp:ListItem>大天河区 </asp:ListItem>
                             <asp:ListItem>大海珠区 </asp:ListItem>
                            <asp:ListItem>番禺一部 </asp:ListItem>
                            <asp:ListItem>花都区 </asp:ListItem>
                            <asp:ListItem>工商铺一部 </asp:ListItem>
                            <asp:ListItem>工商铺二部 </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr  class="EmpDataDis">
                    <td>联系电话</td>
                    <td><asp:TextBox ID="Phone" runat="server" ></asp:TextBox></td>
                    <td>生效日期</td>
                    <td> <asp:TextBox ID="EffectDate" runat="server" ></asp:TextBox></td>
                </tr>
                <tr  class="GroupDataDis">
                    <td rowspan="2" class="fontbold">申请组别基本资料</td>
                    <td>区域</td>
                    <td>
                        <%--<asp:TextBox ID="Region1" runat="server" ></asp:TextBox>--%>
                        <asp:DropDownList runat="server" ID="Region1"> 
                            <asp:ListItem>请选择 </asp:ListItem>
                            <asp:ListItem>大白云区 </asp:ListItem>
                             <asp:ListItem>大越秀区 </asp:ListItem>
                             <asp:ListItem>大天河区 </asp:ListItem>
                             <asp:ListItem>大海珠区 </asp:ListItem>
                            <asp:ListItem>番禺一部 </asp:ListItem>
                            <asp:ListItem>花都区 </asp:ListItem>
                            <asp:ListItem>工商铺一部 </asp:ListItem>
                            <asp:ListItem>工商铺二部 </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>组别名称</td>
                    <td> <asp:TextBox ID="DeptName1" runat="server" ></asp:TextBox></td>
                </tr>
               <tr  class="GroupDataDis">
                    <td>生效日期</td>
                    <td> <asp:TextBox ID="EffectDate1" runat="server" ></asp:TextBox></td>
                   <td colspan="2"></td>
               </tr>
                <tr>
                    <td rowspan="2" class="fontbold">
                        中台人员设置类型
                    </td>
                    <td class="textleft" colspan="2" id="tdlogisticsType"> <input type="radio" id="Radio3" name="r1" value="1"onclick="ISSetUpType(this)" /><label for="Radio3">中台后勤服务人员</label></td>
                     <td class="textleft" colspan="2" id="tdlogisticsType1">
                          <input type="radio" id="Radio4" name="r2" value="1" onclick="chlicklogisticsType(this)"/><label for="Radio4">招聘</label>
                          <input type="radio" id="Radio5" name="r2" value="2" onclick="chlicklogisticsType(this)"/><label for="Radio5">拍摄</label>
                         <input type="radio" id="Radio6" name="r2" value="3" onclick="chlicklogisticsType(this)"/><label for="Radio6">其他</label>
                         <asp:TextBox ID="logisticsTypeRemarks" runat="server" ></asp:TextBox>
                          <asp:HiddenField ID="logisticsType" runat="server" />
                     </td>
                </tr>
              
                <tr>
                      <td class="textleft" colspan="2" id="tdBusinessType"> <input type="radio" id="Radio7" name="r1" value="2" onclick="ISSetUpType(this)"/><label for="Radio7">中台业务支持人员</label>       
                      </td>
                    <asp:HiddenField ID="SetUpType" runat="server" />
                     <td class="textleft" colspan="2" id="tdBusinessType1">
                          <input type="radio" id="Radio8" name="r3" value="1" onclick="chlickBusinessType(this)"/><label for="Radio8">联动项目营运支持</label>
                         <input type="radio" id="Radio10" name="r3" value="2" onclick="chlickBusinessType(this)"/><label for="Radio10">其他</label>
                          <asp:TextBox ID="BusinessTypeRemarks" runat="server" ></asp:TextBox>
                         <asp:HiddenField ID="BusinessType" runat="server" />
                     </td>
                </tr>
                  <tr>
                    <td class="fontbold">备注</td>
                    <td colspan="4">
                        <textarea id="Remarks" runat="server" style="width:500px"></textarea>
                    </td>
                </tr>
                <tr>
                    <td rowspan="6" class="fontbold">申请豁免内容</td>
                    <td colspan="4" class="textleft">  <input type="checkbox" id="checkbox1" value="1" name="c" /><label for="checkbox1">豁免经纪证持证入职</label></td>
                </tr>
                <tr>
                     <td colspan="4"  class="textleft"> <input type="checkbox" id="checkbox2" value="2" name="c" /><label for="checkbox2">不参与业绩排名评比，业绩奖项评比（奖项包括：地方公司及中原集团，针对性当前岗位评比的奖项除外）</label></td>
                </tr>
                 <tr>
                     <td colspan="4"  class="textleft"> <input type="checkbox" id="checkbox3" value="3" name="c" /><label for="checkbox3">不参与精英会评选</label></td>
                </tr>
                 <tr>
                     <td colspan="4"  class="textleft"> <input type="checkbox" id="checkbox4" value="4" name="c" /><label for="checkbox4">不参与绩效考核（包括：季度绩效考核，通过试用期考核，月度淘换考核）</label></td>
                </tr>
                   <tr>
                     <td colspan="4"  class="textleft"> <input type="checkbox" id="checkbox5" value="5" name="c" /><label for="checkbox5">不参与营业员绩效工资考核及计提</label></td>
                </tr>
                 <tr>
                     <td colspan="4"  class="textleft"> <input type="checkbox" id="checkbox6" value="6" name="c" /><label for="checkbox6">不参与特殊津贴考核（包括：非市中心阶段性津贴及其他津贴等）</label></td>
                      <asp:HiddenField ID="Content" runat="server" />
                </tr>
                <tr>
                    <td class="fontbold">
                        说明
                    </td>
                    <td  colspan="4">
                        本申请一经公司审批同意，则参照申请内容及生效日期执行；如需撤销申请内容，需另行向公司提交相关的撤销申请。
                    </td>
                </tr>
                  <tr style="display:none;">
                    <td colspan="4" style="text-align: left" class="auto-style5">
                        <span style="margin-left: 20px; text-align: left;font-size:12px">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 340px;font-size:12px">填写日期：<asp:Label ID="lbApplyDate" runat="server"></asp:Label></span>
                    </td>
                </tr>
                </table>
                   <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0" style="width:700px">
                  <tr class="noborder" style="height: 85px;" idx="1">
                    <td style="width:130px">申请人</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree1"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree1"/><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree1"/><label class="l signyes">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                 <tr class="noborder" style="height: 85px;" idx="2">
                    <td class="auto-style2">部门主管：</td>
                    <td class="tl PL10">
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
                    <td class="auto-style2">区域负责人：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree3"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree3" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree3" /><label class="l signyes">其他意见</label>
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
                       <tr class="noborder" style="height: 85px;" idx="6">
                    <td class="auto-style2" rowspan="2">人力资源部意见：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree6"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree6" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree6" /><label class="l signyes">其他意见</label>
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
                    <tr class="noborder" style="height: 85px;" idx="7">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree7"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree7" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree7" /><label class="l signyes">其他意见</label>
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
                   <tr class="noborder" style="height: 85px;" idx="8">
                    <td class="auto-style2" rowspan="2">财务部：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree8"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree8" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree8" /><label class="l signyes">其他意见</label>
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
                   <tr class="noborder" style="height: 85px;" idx="9">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree9"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree9" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree9" /><label class="l signyes">其他意见</label>
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
                         <tr class="noborder" style="height: 85px;" idx="10">
                    <td class="auto-style2" rowspan="2">培训部：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree10"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree10" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree10" /><label class="l signyes">其他意见</label>
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
                   <tr class="noborder" style="height: 85px;" idx="11">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree11"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree11" /><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree11" /><label class="l signyes">其他意见</label>
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
               <%-- <tr style="display:none;">
                    <td colspan="4" style="text-align: left" class="auto-style5">
                        <span style="margin-left: 20px; text-align: left;font-size:12px">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 340px;font-size:12px">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>--%>

               
                
            </table>
               <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
            <br />
             <%--   </td></tr>
                </table>--%>
            <!--打印正文结束-->
                <script>
                    $("#tbAround2 input").css({ "border": "1px solid #98b8b5" });
                </script>
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
           
            <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
         
            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
    <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
            <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
          
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
            <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
            <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
            <asp:HiddenField ID="hdIsAgree" runat="server" />
            <asp:HiddenField ID="hdSuggestion" runat="server" />
            <input type="hidden" id="hdDetail" runat="server" />
            <input type="hidden" id="hdDepartmentID" runat="server" />
            <input type="hidden" id="hdDepartmentID2" runat="server" />
            <asp:HiddenField ID="hdCancelSign" runat="server" />
            <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
        </div>
        </div>
    </div>
        <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=Describe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>