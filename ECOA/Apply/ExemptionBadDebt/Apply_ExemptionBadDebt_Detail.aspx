<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_ExemptionBadDebt_Detail.aspx.cs"  MasterPageFile="~/MasterPage.master" Inherits="Apply_ExemptionBadDebt_Apply_ExemptionBadDebt_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <style type="text/css">
        .auto-style2 {
            width: 140px;
        }
        .auto-style3 {
            width: 170px;
        }
            .text {
            width:92%
            }
        </style>
     <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1, i2 = 1, i3 = 1;
        var isNewApply=('<%=IsNewApply%>'=='True');

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
        $(function () {
            $("[id*=btnImport]").css({
                "background-image": "url(/Images/btnImport1.png)",
                "height": "36px",
                "width": "92px",
                "font-size": "0px",
                "cursor": "pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnImport]").mousedown(function () { $(this).css("background-image", "url(/Images/btnImport2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnImport1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnImport1.png)"); });

            $("#<%=txtHopeDate.ClientID %>").datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
       
            LoadDetail("<%=this.hidDetail1.ClientID%>", "jzqk1");
            LoadDetail("<%=this.hidDetail2.ClientID%>", "jzqk2");
            FlowSignInit();
        })
      
        function check()
        {
            if ($.trim($("#<%=txtApplyID.ClientID %>").val()) == "") { alert("申发文编号不可为空！"); $("#<%=txtApplyID.ClientID %>").focus(); return false; }
            if ($.trim($("#<%=txtTerm.ClientID %>").val()) == "") { alert("豁免期限不可为空！"); $("#<%=txtTerm.ClientID %>").focus(); return false; }
            if ($.trim($("#<%=txtHopeDate.ClientID %>").val()) == "") { alert("网络核查日期不可为空！"); $("#<%=txtHopeDate.ClientID %>").focus(); return false; }
       
            if ($.trim($("#<%=txt1Y.ClientID %>").val()) == "") { alert("成交宗佣年不可为空！"); $("#<%=txt1Y.ClientID %>").focus(); return false; }
            if ($.trim($("#<%=txt1M.ClientID %>").val()) == "") { alert("成交宗佣月不可为空！"); $("#<%=txt1M.ClientID %>").focus(); return false; }
            if ($.trim($("#<%=txt2Y.ClientID %>").val()) == "") { alert("申请总额年不可为空！"); $("#<%=txt2Y.ClientID %>").focus(); return false; }
            if ($.trim($("#<%=txt2M.ClientID %>").val()) == "") { alert("申请总额月不可为空！"); $("#<%=txt2M.ClientID %>").focus(); return false; }
            //豁免自动坏项目统计：
            var flag = true;
            var array1 = new Array();
            $("#jzqk1 tr").each(function () {
                $text = $(this).find("textarea");
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
                if (!c) { return false }
                array1.push(json)
            })
            if (!flag) {
                $("#<%=this.hidDetail1.ClientID%>").val("");
                return false;
            }
            $("#<%=this.hidDetail1.ClientID%>").val(Obj2str(array1));
            var array2 = new Array();
            $("#jzqk2 tr").each(function () {
                $text = $(this).find("textarea");
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
                if (!c) { return false }
                array2.push(json)
            })
            if (!flag) {
                $("#<%=this.hidDetail2.ClientID%>").val("");
                return false;
            }
            $("#<%=this.hidDetail2.ClientID%>").val(Obj2str(array2));
        
            return true;
        }
        //加载明细 idname =hidDetail(隐藏的json) Idtbody=绑在那个id
        function LoadDetail(idname, Idtbody) {
            var detail = $("#" + idname).val();
          
            var list = detail == "" ? [] : $.parseJSON(detail);
            for (var i = 0 ; i < list.length; i++) {
                if (i == 0) {
                    var copytr = $("#" + Idtbody + " tr").first();
                    if (list[i] != null && list[i] != undefined && isjson(list[i])) {
                        var obj = list[i];
                        for (var k in obj) {
                            //$(copytr).find("input[name=" + k + "]").val(obj[k]);
                            $(copytr).find("textarea[name=" + k + "]").val(obj[k]);
                            //遍历对象，k即为key，obj[k]为当前k对应的值
                            //console.log(k);
                        }
                    }
                    else {
                        //$(copytr).find("input[type=text]").val("");
                        $(copytr).find("textarea").val("");
                    }
                }
                else {
                    addrow(null, Idtbody, list[i]);
                }
            }
        }
        //豁免自动坏项目统计：
        function ExemptionBadChange(e)
        {
            var TextBoxNo = 0;//从0开始 内第几个input，e 当前txt触发数
            var input1 = 0;
            var CostSum = 0;
            $("#jzqk1 tr").find("input").each(function () {
                var money = 0;
                if (TextBoxNo == 8) {
                    TextBoxNo = 0;
                    
                }
                else {
                    if (TextBoxNo == e) {
                        if (/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val()))
                        {
                            input1 += parseFloat($(this).val());
                        }    ;
                    }
                    TextBoxNo++;
                }
            })
            if(e ==3)//成交宗数
            {
                $("#<%=txtUnitSum.ClientID%>").val(input1.toFixed(2));
            }
            else if(e =4)//成交总佣
            {
                $("#<%=txtCommSum.ClientID%>").val(input1.toFixed(2));
            }
           
        }
        //三级市场自接项目各成交区域实际豁免业绩见下表
        function TotalChange(e)
        {
            var TextBoxNo = 0;//从0开始 内第几个input，3：单价，4：数量，5：金额
            var input1 = 0; //input1当前申请总额
            var input2 = 0;//其他金额
            var CostSum = 0;//
            var totalSum = 0;//总合计
            $("#jzqk2 tr").find("input").each(function () {
                var money = 0;
                if (TextBoxNo == 12) {
                    TextBoxNo =1;

                }
                else {
                    if (TextBoxNo == e) {
                        if (/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) {
                            input1 = parseFloat($(this).val());
                            CostSum += parseFloat($(this).val());
                        };
                    }
                    else if (TextBoxNo != 0 && TextBoxNo != 11) {
                        if (/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) {
                            input2 += parseFloat($(this).val());  
                        };
                    }
                    else if (TextBoxNo ==11)
                    {
                        totalSum +=input2 + input1
                       $(this).val((input2 + input1).toFixed(2))
                        input2 = 0;
                        input1 = 0;
                    }
                    TextBoxNo++;
                }
            })
            if(e == 1)//申请总额
            {
                $("#<%=txtApplyTotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            if (e == 2)//大海珠区
            {
                $("#<%=txtHZTotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            if (e == 3)//大天河区
            {
                $("#<%=txtTHTotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            if (e == 4)//大白云区
            {
                $("#<%=txtBYTotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            if (e == 5)//大越秀区
            {
                $("#<%=txtYXTotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            if (e == 6)//花都区
            {
                $("#<%=txtHDTotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            if (e == 7)//番禺一部
            {
                $("#<%=txtPYTotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            if (e == 8)// 工商铺一部 
            {
                $("#<%=txtGS1TotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            if (e == 9)// 工商铺二部 
            {
                $("#<%=txtGS2TotalSum.ClientID%>").val(CostSum.toFixed(2));
            }
            
        }
        //增加一行
        function addrow(e, idname, obj) {

            var copytr = $("#" + idname + " tr").first().clone();
            if (obj != null && obj != undefined && isjson(obj)) {
                for (var k in obj) {
                  //    $(copytr).find("textarea[name=" + k + "]").val(obj[k]);
                    if ("jzqk1" == idname)
                    {
                        if ("txtDetail_a" == k)
                        {
                            copytr = '<tr>'
                                   + '<td><textarea style="width: 60px; overflow: hidden;" rows="1" name="txtDetail_a" cols="4" emptymes="请填写统筹区域">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail_b" == k)
                        {
                            copytr += '<td><textarea style="width: 70px; overflow: hidden;" rows="1" name="txtDetail_b" cols="6" emptymes="请填写项目名称">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail_c" == k) {
                            copytr += '<td><textarea style="width: 70px; overflow: hidden;" rows="1" name="txtDetail_c" cols="6" emptymes="请填写项目所在地">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail_j" == k) {
                            copytr += '<td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_j" cols="3" emptymes="请填写项目统筹人">' + obj[k] + '</textarea></td>'
                             
                        }
                        else if ("txtDetail_d" == k) {
                            copytr += '<td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_d" cols="3" emptymes="请填写成交宗数">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail_e" == k) {
                            copytr += '<td><textarea style="width: 75px; overflow: hidden;" rows="1" name="txtDetail_e" cols="6" emptymes="请填写成交总佣">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail_f" == k) {
                            copytr += '<td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_f" cols="3" emptymes="请填写申请宗数">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail_g" == k) {
                            copytr += '<td><textarea style="width: 75px; overflow: hidden;" rows="1" name="txtDetail_g" cols="6" emptymes="请填写申请总额">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail_h" == k) {
                            copytr += '<td><textarea style="width: 85px; overflow: hidden;" rows="1" name="txtDetail_h" cols="7" >' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail_i" == k) {
                            copytr += '<td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_i" cols="3" >' + obj[k] + '</textarea></td>'
                               + '</tr>';
                        }
                    }
                    else if ("jzqk2" == idname)
                    {
                        if ("txtDetail2_a" == k) {
                         
                            copytr = '<tr>'
                                      + '<td><textarea name="txtDetail2_a" style="width: 85px; overflow: hidden;" rows="1"  cols="7" emptymes="请填写项目名称">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_b" == k)
                        {
                            copytr += '<td><textarea name="txtDetail2_b" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写申请总额">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_c" == k) {
                            copytr += '<td><textarea name="txtDetail2_c" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大海珠区">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_d" == k) {
                            copytr += '<td><textarea name="txtDetail2_d" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大天河区">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_e" == k) {
                            copytr += '<td><textarea name="txtDetail2_e" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大白云区">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_f" == k) {
                            copytr += '<td><textarea name="txtDetail2_f" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大越秀区">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_g" == k) {
                            copytr += '<td><textarea name="txtDetail2_g" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写花都区">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_h" == k) {
                            copytr += '<td><textarea name="txtDetail2_h" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写番禺一部">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_k" == k) {
                            copytr += '<td><textarea name="txtDetail2_k" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写番禺二部">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_i" == k) {
                            copytr += '<td><textarea name="txtDetail2_i" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写工商铺一部">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_j" == k) {
                            copytr += '<td><textarea name="txtDetail2_j" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写工商铺二部">' + obj[k] + '</textarea></td>'
                        }
                        else if ("txtDetail2_l" == k) {
                            copytr += '<td><textarea name="txtDetail2_l" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写芳村南海">' + obj[k] + '</textarea></td>'
                             + '</tr>';
                        }
                        
                    }
                 
                }
            }
            else {
                if ("jzqk1" == idname)
                {
                  copytr = '<tr>'
                    + '<td><textarea style="width: 60px; overflow: hidden;" rows="1" name="txtDetail_a" cols="4" emptymes="请填写统筹区域"></textarea></td>'
                    + '<td><textarea style="width: 70px; overflow: hidden;" rows="1" name="txtDetail_b" cols="6" emptymes="请填写项目名称"></textarea></td>'
                    + '<td><textarea style="width: 70px; overflow: hidden;" rows="1" name="txtDetail_c" cols="6" emptymes="请填写项目所在地"></textarea></td>'
                    + '<td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_j" cols="3" emptymes="请填写项目统筹人"></textarea></td>'
                    + '<td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_d" cols="3" emptymes="请填写成交宗数"></textarea></td>'
                    + '<td><textarea style="width: 75px; overflow: hidden;" rows="1" name="txtDetail_e" cols="6" emptymes="请填写成交总佣"></textarea></td>'
                    + '<td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_f" cols="3" emptymes="请填写申请宗数"></textarea></td>'
                    + '<td><textarea style="width: 75px; overflow: hidden;" rows="1" name="txtDetail_g" cols="6" emptymes="请填写申请总额"></textarea></td>'
                    + '<td><textarea style="width: 85px; overflow: hidden;" rows="1" name="txtDetail_h" cols="7" ></textarea></td>'
                    + '<td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_i" cols="3" ></textarea></td>'
                    + '</tr>';
                } else if ("jzqk2" == idname)
                {
                   copytr = '<tr>'
                    + '<td><textarea name="txtDetail2_a" style="width: 85px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写项目名称"></textarea></td>'
                    + '<td><textarea name="txtDetail2_b" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写申请总额"></textarea></td>'
                    + '<td><textarea name="txtDetail2_c" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大海珠区"></textarea></td>'
                    + '<td><textarea name="txtDetail2_d" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大天河区"></textarea></td>'
                    + '<td><textarea name="txtDetail2_e" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大白云区"></textarea></td>'
                    + '<td><textarea name="txtDetail2_f" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大越秀区"></textarea></td>'
                    + '<td><textarea name="txtDetail2_g" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写花都区"></textarea></td>'
                    + '<td><textarea name="txtDetail2_h" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写番禺一部"></textarea></td>'
                    + '<td><textarea name="txtDetail2_k" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写番禺二部"></textarea></td>'
                    + '<td><textarea name="txtDetail2_i" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写工商铺一部"></textarea></td>'
                    + '<td><textarea name="txtDetail2_j" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写工商铺二部"></textarea></td>'
                    + '<td><textarea name="txtDetail2_l" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写芳村南海"></textarea></td>'
                    + '</tr>';
                }
              
            }
          //  if ("jzqk2" == idname)
            //console.log(copytr);
                $("#" + idname).append(copytr);
                $.each($("textarea"), function (idx, item) { autoTextarea(this); });
                return;
          
        }
        //删除行
        function delrow(e, idname) {
            var l = $("#" + idname + " tr").length;
            if (l == 1) {
                alert("最后一行不能再删");
                return;
            }
            $("#" + idname + " tr").last().remove();
        }
        function isjson(obj) {
            var isjson = typeof (obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length;
            return isjson;
        }
        function Obj2str(o) {
            if (o == undefined) {
                return "";
            }
            var r = [];
            if (typeof o == "string") return "\"" + o.replace(/([\"\\])/g, "\\$1").replace(/(\n)/g, "\\n").replace(/(\r)/g, "\\r").replace(/(\t)/g, "\\t") + "\"";
            if (typeof o == "object") {
                if (!o.sort) {
                    for (var i in o)
                        r.push("\"" + i + "\":" + Obj2str(o[i]));
                    if (!!document.all && !/^\n?function\s*toString\(\)\s*\{\n?\s*\[native code\]\n?\s*\}\n?\s*$/.test(o.toString)) {
                        r.push("toString:" + o.toString.toString());
                    }
                    r = "{" + r.join() + "}"
                } else {
                    for (var i = 0; i < o.length; i++)
                        r.push(Obj2str(o[i]))
                    r = "[" + r.join() + "]";
                }
                return r;
            }
            return o.toString().replace(/\"\:/g, '":""');
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
        function Imports() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_zNull_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
                 if (sReturnValue == "undefined") {
                     sReturnValue = window.returnValue;
                 }
                 //alert(sReturnValue);
                 $("#<%=hdFilePath.ClientID%>").val(sReturnValue);
            return true;
        }
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    		<div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
               <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>三级市场一手项目豁免自动坏申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:840px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  style="width:840px">
				<tr>
					<td class="auto-style3">申请部门</td>
					<td class="tl PL10" style="width:250px"><asp:Label ID="lblDeparment" runat="server"></asp:Label></td>
					<td class="auto-style2">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server" ></asp:textbox></td>
				</tr>
				<tr>
					<td class="auto-style3">申请人</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
					<td class="auto-style2">申请日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>

             <tr>
					<td colspan="4" class="tl PL10" style="line-height: 25px">
                        <span style="font-weight: bold">豁免自动坏项目统计：</span><br />
                        <table id="tbDetail1" style="width:890px" class='sample tc' align="center">
                            <thead>
                                <tr>
                                    <td>统筹区域</td>
                                    <td>项目名称 </td>
                                    <td>项目所在地 </td>
                                    <td>项目统筹人 </td>
                                    <td style="width:50px">
                                       
                                        成交宗数
                                    </td>
                                    <td style="width:100px">
                                        <asp:TextBox ID="txt1Y" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt1M" runat="server" Width="30px"></asp:TextBox>月<br />
                                        成交总佣
                                    </td>
                                    <td style="width:50px">
                                        
                                        申请宗数
                                    </td>

                                    <td  style="width:100px">
                                         <asp:TextBox ID="txt2Y" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt2M" runat="server" Width="30px"></asp:TextBox>月<br />
                                        申请总额

                                    </td>
                                    <td>未签约原因</td>
                                    <td style="width:50px">应收款管理组网络核查结果</td>
                                </tr>
                            </thead>
                            
                       <tbody id="jzqk1">
                                            <tr>
                                                <td><textarea style="width: 60px; overflow: hidden;" rows="1" name="txtDetail_a" cols="4" emptymes="请填写统筹区域"></textarea></td>
                                                 <td><textarea style="width: 70px; overflow: hidden;" rows="1" name="txtDetail_b" cols="6" emptymes="请填写项目名称"></textarea></td>
                                                <td><textarea style="width: 70px; overflow: hidden;" rows="1" name="txtDetail_c" cols="6" emptymes="请填写项目所在地"></textarea></td>
                                                <td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_j" cols="3" emptymes="请填写项目统筹人"></textarea></td>
                                                <td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_d" cols="3" emptymes="请填写成交宗数"></textarea></td>
                                                <td><textarea style="width: 75px; overflow: hidden;" rows="1" name="txtDetail_e" cols="6" emptymes="请填写成交总佣"></textarea></td>
                                                <td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_f" cols="3" emptymes="请填写申请宗数"></textarea></td>
                                                <td><textarea style="width: 75px; overflow: hidden;" rows="1" name="txtDetail_g" cols="6" emptymes="请填写申请总额"></textarea></td>
                                                <td><textarea style="width: 85px; overflow: hidden;" rows="1" name="txtDetail_h" cols="7" ></textarea></td>
                                                 <td><textarea style="width: 50px; overflow: hidden;" rows="1" name="txtDetail_i" cols="3" ></textarea></td>
                                                <%--<td><input type="text" name="txtDetail_a" emptymes="请填写统筹区域" class="text" /></td>--%>
                                                 <%-- <td><input type="text" name="txtDetail_b" emptymes="请填写项目名称"class="text" style="width:80px"/></td>
                                                 <td><input type="text" name="txtDetail_c" emptymes="请填写项目所在地"class="text"style="width:80px"/></td>
                                                 <td><input type="text" name="txtDetail_j" emptymes="请填写项目统筹人"class="text"style="width:80px"/></td>

                                                 <td><input type="text" name="txtDetail_d" emptymes="请填写成交宗数"style="width:80px" /></td>
                                                 <td><input type="text" name="txtDetail_e" emptymes="请填写成交总佣"style="width:80px" /></td>
                                                 <td><input type="text" name="txtDetail_f"  emptymes="请填写申请宗数" class="text"style="width:80px" /></td>
                                                 <td><input type="text" name="txtDetail_g" emptymes="请填写申请总额" class="text"style="width:80px" /></td>
                                                 <td><input type="text" name="txtDetail_h" class="text" style="width:80px"/></td>
                                                 <td><input type="text" name="txtDetail_i" class="text" style="width:80px"/></td>--%>
                                              </tr>
                                        </tbody>
                            <tr id="trFlag1">
                                <td colspan="4">合计</td>
                                <td><asp:TextBox ID="txtUnitSum" runat="server" TextMode="MultiLine" Rows="1" style="width:80%" ></asp:TextBox></td>
                                <td><asp:TextBox ID="txtCommSum" runat="server" TextMode="MultiLine" Rows="1" style="width:80%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtApplyUnitSum" runat="server" TextMode="MultiLine" Rows="1" style="width:80%"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtApplyCommSum" runat="server" TextMode="MultiLine" Rows="1" style="width:80%"></asp:TextBox></td>
                                 <td  colspan="2"></td>
                            </tr>
                        </table>
                          <input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk1', null)" />
                          <input class="btnaddRowN" type="button" onclick="delrow(this, 'jzqk1')" value="删除一行" />
                      <asp:HiddenField ID="hidDetail1" runat="server" />
                        <br />
					</td>
				</tr>
                <tr>
                    <td colspan ="2">
                        豁免期限：<asp:textbox id="txtTerm" runat="server" />
                    </td>
                    <td colspan ="2">
                        网络核查日期：<asp:TextBox ID="txtHopeDate" runat="server" Width="150px"/>
                    </td>
                </tr>
				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 25px">
                        <span style="font-weight: bold">三级市场自接项目各成交区域实际豁免业绩见下表：</span><br />
                        <table id="tbDetail2" class='sample tc' style="width:890px" align="center">
                            <thead>
                                <tr>
                                    <td>项目名称</td>
                                    <td>申请总额</td>
                                    <td>大海珠区</td>
                                    <td>大天河区</td>
                                    <td>大白云区</td>
                                    <td>大越秀区</td>
                                    <td>花都区</td>
                                    <td>番禺一部</td>
                                    <td>番禺二部</td>
                                    <td>工商铺一部</td>
                                    <td>工商铺二部</td>
                                    <td>芳村南海</td>
                                </tr>
                            </thead>
                              <tbody id="jzqk2">
                                            <tr style="border:0px">
                                                <td><textarea name="txtDetail2_a" style="width: 85px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写项目名称"></textarea></td>
                                                <td><textarea name="txtDetail2_b" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写申请总额"></textarea></td>
                                                <td><textarea name="txtDetail2_c" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大海珠区"></textarea></td>
                                                <td><textarea name="txtDetail2_d" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大天河区"></textarea></td>
                                                <td><textarea name="txtDetail2_e" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大白云区"></textarea></td>
                                                <td><textarea name="txtDetail2_f" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写大越秀区"></textarea></td>
                                                <td><textarea name="txtDetail2_g" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写花都区"></textarea></td>
                                                <td><textarea name="txtDetail2_h" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写番禺一部"></textarea></td>
                                                <td><textarea name="txtDetail2_k" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写番禺二部"></textarea></td>
                                                <td><textarea name="txtDetail2_i" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写工商铺一部"></textarea></td>
                                                <td><textarea name="txtDetail2_j" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写工商铺二部"></textarea></td>
                                                <td><textarea name="txtDetail2_l" style="width: 60px; overflow: hidden;" rows="1"  cols="4" emptymes="请填写芳村南海"></textarea></td>
                                                 <%-- <td><input type="text" name="txtDetail2_a"  emptymes="请填写项目名称"  class="text"/></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_b"  emptymes="请填写申请总额"  class="text" /></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_c"  emptymes="请填写大海珠区"   class="text" /></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_d"  emptymes="请填写大天河区"   class="text" /></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_e"  emptymes="请填写大白云区"  class="text" /></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_f"  emptymes="请填写大越秀区"  class="text"/></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_g"  emptymes="请填写花都区" class="text" /></td>--%>
                                                <%-- <td><input type="text" name="txtDetail2_h"  emptymes="请填写番禺一部" class="text" /></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_k"  emptymes="请填写番禺二部" class="text" /></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_i"  emptymes="请填写工商铺一部" class="text"/></td>--%>
                                                 <%--<td><input type="text" name="txtDetail2_j"  emptymes="请填写工商铺二部" class="text"/></td>--%>
                                               
                                                 <%--<td><input type="text" name="txtDetail2_l"  emptymes="请填写芳村南海"  class="text"/></td>--%>
                                              </tr>
                                        </tbody>
                            <tr id="trFlag2">
                                <td>合计</td>
                                <td><asp:TextBox ID="txtApplyTotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtHZTotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTHTotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtBYTotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtYXTotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtHDTotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtPYTotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtPY2TotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtGS1TotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtGS2TotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                              
                                <td><asp:TextBox ID="txtFCTotalSum" runat="server"  TextMode="MultiLine" Rows="1"  class="text"></asp:TextBox></td>
                                <td></td>
                            </tr>
                        </table>
					 <input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk2', null)" />
                          <input class="btnaddRowN" type="button" onclick="delrow(this, 'jzqk2')" value="删除一行" />
                       <asp:HiddenField ID="hidDetail2" runat="server" />
                         <br />
                    </td>
				</tr>


                <tr>
                    <td colspan="4" class="tl PL10">
                        <div style="padding-top: 5px">
                            <span style="vertical-align: top">补充说明：</span>
                            <asp:textbox id="txtContent" runat="server" TextMode="MultiLine" Width="90%" Height="100px"></asp:textbox>
                        </div>
                    </td>
                </tr>
                 <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
                <tr>
                    <td colspan="4">
                   <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0" style="width:100%">
                  <tr class="noborder" style="height: 85px;" idx="10">
                    <td style="width:130px">部门主管</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree10" id="agreeID10"/><label class="l signyes" for="agreeID10">同意</label>
                            <input type="radio" value="0" name="agree10"id="agreeID11"/><label class="l signno" for="agreeID11">不同意</label>
                            <input type="radio" value="2" name="agree10" id="agreeID12"/><label class="l signyes" for="agreeID12">其他意见</label>
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
                    <td class="auto-style2" rowspan="2">法律部意见</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                           <input type="radio" value="1" name="agree20" id="agreeID20"/><label class="l signyes" for="agreeID20">同意</label>
                            <input type="radio" value="0" name="agree20" id="agreeID21"/><label class="l signno" for="agreeID21">不同意</label>
                            <input type="radio" value="2" name="agree20" id="agreeID22"/><label for="agreeID22" class="l signyes">其他意见</label>                        
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
                            <input type="radio" value="1" name="agree22" id="agreeID23"/><label for="agreeID23"class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree22" id="agreeID24" /><label for="agreeID24"class="l signno">不同意</label>
                            <input type="radio" value="2"  name="agree22"id="agreeID25" /><label for="agreeID25" class="l signyes">其他意见</label>
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
                    <td class="auto-style2" rowspan="2">财务部意见</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                           <input type="radio" value="1" name="agree30" id="agreeID30" /><label class="l signyes" for="agreeID30">同意</label>
                            <input type="radio" value="0" name="agree30" id="agreeID31" /><label class="l signno" for="agreeID31">不同意</label>
                            <input type="radio" value="2" name="agree30" id="agreeID32"/><label for="agreeID32" class="l signyes">其他意见</label>                        
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
               <tr class="noborder" style="height: 85px;" idx="32">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree32" id="agreeID33" /><label class="l signyes" for="agreeID33">同意</label>
                            <input type="radio" value="0" name="agree32" id="agreeID34"/><label class="l signno" for="agreeID34">不同意</label>
                            <input type="radio" value="2"  name="agree32" id="agreeID35"/><label class="l signyes" for="agreeID35">其他意见</label>
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
                         <tr class="noborder" style="height: 85px;" idx="40">
                    <td style="width:130px">董事总经理</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree40" id="agreeID40"/><label class="l signyes"  for="agreeID40">同意</label>
                            <input type="radio" value="0" name="agree40" id="agreeID41"/><label class="l signno" for="agreeID41">不同意</label>
                            <input type="radio" value="2" name="agree40" id="agreeID42"/><label class="l signyes" for="agreeID42">其他意见</label>
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
			<AlternatingRowStyle BackColor="White" />
		</asp:gridview>
        <div id="PageBottom">
		<hr />
        <span style="font-size: large; padding-top: 10px; padding-bottom: 10px"><a href="豁免自动坏申请模板.xlsx">下载导入模板</a></span>
        <br />
            <asp:button runat="server" id="btnImport" text="导入数据" OnClick="btnImport_Click" onclientclick="return Imports();" />
		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnTemp" text="暂时保存" onclick="btnTempSave_Click" CssClass="commonbtn" onclientclick="return tempsavecheck();" />
        <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
		<asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
		<input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
		<asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
		<asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
		<asp:hiddenfield id="hdIsAgree" runat="server" />
		<asp:hiddenfield id="hdSuggestion" runat="server" />
         <asp:hiddenfield id="hdCancelSign" runat="server" />
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
            <input type="hidden" id="hdFilePath" runat="server" />
             <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
         <%=SbJs.ToString() %>

  </asp:Content>