<%@ Page ValidateRequest="false" Title="临时借用资金申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_BorrowMoney_Detail.aspx.cs" Inherits="Apply_BorrowMoney_Apply_BorrowMoney_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <style type="text/css">
        .finSignBtn{background:url(../../images/btnSureS1.png) no-repeat; text-indent:39px; width:43px;height:25px;overflow:hidden;cursor:pointer}
    </style>
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
            LoadDetail("<%=this.hidDetail1.ClientID%>","jzqk1");
            FlowSignInit();
            //初始化时间控件
            $("[dateplugin='datepicker']").each(function(){
                $(this).datepicker();
            });
            $("#<%=txtNeedDate.ClientID%>").datepicker();
            //for (var x = 1; x < i; x++) {
            //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
            //}
		     
            //i = $("#tbDetail tr").length - 1;
          
            if($("#<%=cbPayK1.ClientID%>").prop('checked') || $("#<%=cbPayK3.ClientID%>").prop('checked'))
            {
                $("#<%=txtAcount.ClientID%>").removeAttr("disabled");
                $("#<%=txtAname.ClientID%>").removeAttr("disabled");
                $("#<%=txtBank.ClientID%>").removeAttr("disabled");
            }
            else if($("#<%=cbPayK2.ClientID%>").prop('checked'))
            {
                $("#<%=txtAcount.ClientID%>").attr("disabled","disabled");
                $("#<%=txtAname.ClientID%>").attr("disabled","disabled");
                $("#<%=txtBank.ClientID%>").attr("disabled","disabled");
            }
            $("#<%=cbPayK1.ClientID%>").click(function(){
               
                $("#<%=cbPayK2.ClientID%>").removeAttr("checked");
                $("#<%=cbPayK3.ClientID%>").removeAttr("checked");
                $("#<%=txtAcount.ClientID%>").removeAttr("disabled");
                $("#<%=txtAname.ClientID%>").removeAttr("disabled");
                $("#<%=txtBank.ClientID%>").removeAttr("disabled");
            })
            $("#<%=cbPayK2.ClientID%>").click(function(){
               
                $("#<%=cbPayK1.ClientID%>").removeAttr("checked");
                $("#<%=cbPayK3.ClientID%>").removeAttr("checked");
                $("#<%=txtAcount.ClientID%>").attr("disabled","disabled");
                $("#<%=txtAname.ClientID%>").attr("disabled","disabled");
                $("#<%=txtBank.ClientID%>").attr("disabled","disabled");
            })
            $("#<%=cbPayK3.ClientID%>").click(function(){
               
                $("#<%=cbPayK1.ClientID%>").removeAttr("checked");
                $("#<%=cbPayK2.ClientID%>").removeAttr("checked");
                $("#<%=txtAcount.ClientID%>").removeAttr("disabled");
                $("#<%=txtAname.ClientID%>").removeAttr("disabled");
                $("#<%=txtBank.ClientID%>").removeAttr("disabled");
              })
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });
        //加载明细 idname =hidDetail(隐藏的json) Idtbody=绑在那个id
        function LoadDetail(idname,Idtbody)
        {
            var detail = $("#" + idname).val();
            //console.log(detail);
            //console.log(Idtbody);
            var list = detail == "" ? [] : $.parseJSON(detail);
            //console.log(list.length);
            for(var i = 0 ; i < list.length;i++)
            {
                if(i == 0)
                {
                    var copytr = $("#"+Idtbody+" tr").first();
                    //if(list[i] != null && list[i] != undefined && isjson(list[i]))
                    //{
                    //    var obj = list[i];
                    //    console.log(obj)
                    //    for(var k in obj) {
                    //        console.log(k)
                    //        //$(copytr).find("select[name=" + k + "]").val(obj[k]);
                    //        //console.log(obj[k])
                    //        //if(k == 'CostProject' && obj[k] == '其他')
                    //        //{
                    //        //    console.log('ss')
                    //        //    var select =  $(copytr).find("select[name=" + k + "]")
                    //        //    var txtOther = $(select).next().next();
                    //        //    var date = $(select).next().next().next().next();
                    //        //    txtOther.show();//文本域
                    //        //    date.hide();//时间
                    //        //}
                    //        //if(k=='txtOther')
                    //        //{
                    //        //    var select =  $(copytr).find("select[name=CostProject]")
                    //        //    var txtOther = $(select).next().next();
                    //        //    txtOther.val(obj[k]);
                    //        //}
                    //       // $(copytr).find("input[name=" + k + "]").val(obj[k]);
                    //        $(copytr).find("select[name=" + k + "]").val(obj[k]);
                    //        $(copytr).find("input[name=" + k + "]").val(obj[k]);
                    //        $(copytr).find("textarea [name=" + k + "]").val(obj[k]);
                    //        //遍历对象，k即为key，obj[k]为当前k对应的值
                    //        //console.log(k);
                    //    }
                    //}
                    //else
                    //{
                    //    $(copytr).find("input[type=text]").val("");
                    //}
                    if(list[i] != null && list[i] != undefined && isjson(list[i]))
                    {
                        var obj = list[i];
                        for(var k in obj) {
                            $(copytr).find("select[name=" + k + "]").val(obj[k]);
                           // console.log(k);
                            if($(copytr).find("select[name=" + k + "]").val() == '其他' && k=='CostProject'){
                                var select =  $(copytr).find("select[name=" + k + "]")
                                var txtOther = $(select).next().next();
                                var date = $(select).next().next().next().next();
                       
                      
                                txtOther.show();//文本域
                                date.hide();//时间
                            }
                            if(k=='txtOther')
                            {
                                var select =  $(copytr).find("select[name=CostProject]")
                                var txtOther = $(select).next().next();
                                txtOther.val(obj[k]);
                            }
                            $(copytr).find("input[name=" + k + "]").val(obj[k]);
                            //遍历对象，k即为key，obj[k]为当前k对应的值
                            //   console.log(k);
                        }
                 
                    }
                    else
                    {
           
                        $(copytr).find("input[type=text]").val("");
                        //$(copytr).find("input[type=hidden]").val("请选择");
                        $(copytr).find("input[name=hiCostProject]").val("请选择");
                        $(copytr).find("input[name=hiOther]").val("");
                        $(copytr).find("textarea").val("");
                    }
                }
                else
                {
                    addrow(null,Idtbody,list[i]);
                }
            }
        }

        function check() {
           
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {alert("部门不可为空！");$("#<%=txtDepartment.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtNeedDate.ClientID %>").val())=="") {alert("需要日期不可为空！");$("#<%=txtNeedDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {alert("电话不可为空！");$("#<%=txtReplyPhone.ClientID %>").focus();return false;}
            if($.trim($("#<%=ddlArea.ClientID%>").val())=="请选择") {
                alert("请选择区域名！");
                $("#<%=ddlArea.ClientID %>").focus();
                return false;
            }
            if(!$("#<%=cbPayK2.ClientID%>").prop('checked'))
            {
                if($.trim($("#<%=txtAcount.ClientID %>").val())=="") {alert("账户名称不可为空！");$("#<%=txtAcount.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtAname.ClientID %>").val())=="") {alert("账号不可为空！");$("#<%=txtAname.ClientID %>").focus();return false;}
                if($.trim($("#<%=txtBank.ClientID %>").val())=="") {alert("开户银行不可为空！");$("#<%=txtBank.ClientID %>").focus();return false;}
            }
                var flag = true;
            var array1 = new Array();
            $("#jzqk1 tr").each(function(){
                $text = $(this).find("input");
                var c = true;
                var json ={};
                $text.each(function(){
                    if($.trim(this.value) == ""){
                        if($(this).attr("emptymes") == '请填写其他费用'|| $(this).attr("emptymes") == '请填写起初日期'|| $(this).attr("emptymes") == '请填写结束日期'){
                            if($(this).is(':visible')){ 
                                alert($(this).attr("emptymes"));
                                $(this).focus();
                                flag = false;
                                c = false;
                                return false;
                            }
                        }
                        else{
                            alert($(this).attr("emptymes"));
                            $(this).focus();
                            flag = false;
                            c = false;
                            return false;
                        }
                    }
                    json[$(this).attr("name")] = this.value;
                });
                if(!c){return false}
                array1.push(json)
            })
          
            if(!flag)
            {
                $("#<%=this.hidDetail1.ClientID%>").val("");
               return false; 
            }
            $("#<%=this.hidDetail1.ClientID%>").val(Obj2str(array1));
           
            if (
               !$("#<%=cbPayK1.ClientID %>").prop("checked") 
                    && !$("#<%=cbPayK2.ClientID %>").prop("checked") 
                    && !$("#<%=cbPayK3.ClientID %>").prop("checked")
               ) 
                {
                    alert("必须勾选一种支付方式！");
                    $("#<%=cbPayK1.ClientID%>").focus();
                 return false;
             }
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
		        window.location='Apply_BorrowMoney_Detail.aspx?MainID=<%=MainID %>';
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
        //文本域赋值hidden
        function OtherChange(e)
        {
            $(e).next().val($(e).val())
        }
        //下拉框赋值
        function show_Hidden(v){    
            var value =  $(v).val();
            var hidden = $(v).next();//下拉框下个兄弟节点
            hidden.val(value);
            var txtOther =  $(v).next().next();
            var date =  $(v).next().next().next().next()//时间
          //  var edcDate =  $(v).next().next().next().next();
            if(value =="其他"){
                txtOther.show();
                date.hide();
            }
            else
            {
                txtOther.hide();
                txtOther.val('');
                date.show();
            }
        }
        //var numrow =1;//默认行数
        //增加一行
        function addrow(e,idname,obj)
        {
           
            var numrow = $("#jzqk1").find("tr").length;
          //  console.log(numrow);
            var TextBoxNo = 0;//从0开始 内第几个input，
            $("#jzqk1 tr").find("input").each(function () {
               
                Modetype = $(this).val();
                
                    if("请选择" == Modetype )
                    {
                        alert("请选择费用");
                        return false;
                    }
                     if("其他" == Modetype)
                    {
                         numrow++;
                        // console.log(numrow+'其他');
                    }
                })
            if(numrow>=6)
            {
                alert("限制申请事项行数");
                return;
            }
            numrow++;
            var copytr = $("#" + idname + " tr").first().clone();
            if(obj != null && obj != undefined && isjson(obj))
            {
                for(var k in obj) {
                    $(copytr).find("select[name=" + k + "]").val(obj[k]);
                  //  console.log(k);
                    if($(copytr).find("select[name=" + k + "]").val() == '其他' && k=='CostProject'){
                        var select =  $(copytr).find("select[name=" + k + "]")
                        var txtOther = $(select).next().next();
                        var date = $(select).next().next().next().next();
                        txtOther.show();//文本域
                         date.hide();//时间
                    }
                    else if(k=='txtOther')
                    {
                        var select =  $(copytr).find("select[name=CostProject]")
                        var txtOther = $(select).next().next();
                        txtOther.val(obj[k]);
                    }
                    else{ 
                        var select =  $(copytr).find("select[name=" + k + "]")
                        var txtOther = $(select).next().next();
                        var date = $(select).next().next().next().next();
                        txtOther.hide();//文本域
                        date.show();//时间
                        $(copytr).find("input[name=" + k + "]").val(obj[k])};
                    //遍历对象，k即为key，obj[k]为当前k对应的值
                    //   console.log(k);
                }
                 
            }
            else
            {
           
                $(copytr).find("input[type=text]").val("");
                //$(copytr).find("input[type=hidden]").val("请选择");
                $(copytr).find("input[name=hiCostProject]").val("请选择");
                $(copytr).find("input[name=hiOther]").val("");
                $(copytr).find("textarea").val("");
            }
            $(copytr).find("[dateplugin='datepicker']").each(function(){
                $(this).removeAttr("id").removeAttr("class");
                $(this).datepicker();
            });
            $("#" + idname).append(copytr);
        
            return;
        }
        function isjson(obj){
            var isjson = typeof(obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length; 
            return isjson;
        }
        //删除行
        function delrow(e,idname)
        {
            var l = $("#" + idname + " tr").length;
            if(l == 1)
            {
                alert("最后一行不能再删");
                return;
            }
            $("#" + idname + " tr").last().remove();
            CalculationSumMoney();
        }
        function CalculationSumMoney()
        {
            var TextBoxNo =0;//从0开始 第几个input
            var price =0,priceSum =0;
            
            $("#jzqk1 tr").find("input").each(function () {
                if (TextBoxNo == 5) {//换行
                    TextBoxNo = 1;
                    price = 0;
                }
                else
                {
                    if (TextBoxNo == 4){
                        //  console.log($(this).val())
                        // if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val()))
                   
                        //price=parseFloat($(this).val());
                        price=parseFloat($(this).val());
                        priceSum+=price;
                        //  console.log(price);
                    }
                    TextBoxNo++;
                }
            });
            priceSum = Number(priceSum).toFixed(2);
            $("#<%=lMoney.ClientID%>").text(priceSum);
            $("#<%=hilMoney.ClientID%>").val(priceSum);
            $("#<%=lBWMoney.ClientID%>").text(DX(priceSum))
            $("#<%=hilBWMoney.ClientID%>").val(DX(priceSum));
        }
        function PriceChange(e)
        {
           
            // if(!/\d{1,}\.\d{2}$/.test($(e).val())){
            if(!/^[0-9]+([.]{1}[0-9]{1,2})?$/.test($(e).val())){
                $(e).val('');
                $(e).focus();
                alert('请输入正确金额');
                return;
            }
            var TextBoxNo =0;//从0开始 第几个input
            var price =0,priceSum =0;
            
            $("#jzqk1 tr").find("input").each(function () {
                if (TextBoxNo == 5) {//换行
                    TextBoxNo = 1;
                    price = 0;
                }
                else
                {
                    if (TextBoxNo == 4){
                      //  console.log($(this).val())
                        // if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val()))
                   
                        //price=parseFloat($(this).val());
                        price=parseFloat($(this).val());
                        priceSum+=price;
                      //  console.log(price);
                    }
                    TextBoxNo++;
                }
            });
            priceSum = Number(priceSum).toFixed(2);
            $("#<%=lMoney.ClientID%>").text(priceSum);
            $("#<%=hilMoney.ClientID%>").val(priceSum);
            $("#<%=lBWMoney.ClientID%>").text(DX(priceSum))
            $("#<%=hilBWMoney.ClientID%>").val(DX(priceSum));
        }
        function checkAduit()
        {
             var radFin1 =$("#<%=radFin1.ClientID%>");//确认收单
            var radFin2 =$("#<%=radFin2.ClientID%>");//退单
            var radFin3 =$("#<%=radFin3.ClientID%>");//其他意见
            if(radFin2.prop("checked") && $("#<%=txtSuggestion.ClientID%>").val()==""){
                alert("请填写退单意见！");$("#<%=txtSuggestion.ClientID %>").focus();return false;
            }
            if(radFin3.prop("checked") && $("#<%=txtSuggestion.ClientID%>").val()==""){
                alert("请填写其他意见！");$("#<%=txtSuggestion.ClientID %>").focus();return false;
            }
            if(!radFin1.prop("checked") && !radFin2.prop("checked")  && !radFin3.prop("checked"))
            {alert("请确定是否确认收单");  return false;}
            if (confirm("是否确认审核？"))
            {
                return true;
            }
            return false;
           
        }
        function DX(n) {
            if (!/^(0|[1-9]\d*)(\.\d+)?$/.test(n)) return "数据非法";
            var unit = "京亿万仟佰拾兆万仟佰拾亿仟佰拾万仟佰拾元角分", str = "";
            n += "00";
            var p = n.indexOf('.');
            if (p >= 0)
                n = n.substring(0, p) + n.substr(p+1, 2);
            unit = unit.substr(unit.length - n.length);	
            for (var i=0; i < n.length; i++) str += '零壹贰叁肆伍陆柒捌玖'.charAt(n.charAt(i)) + unit.charAt(i);	
            return str.replace(/零(仟|佰|拾|角)/g, "零").replace(/(零)+/g, "零").replace(/零(兆|万|亿|元)/g, "$1").replace(/(兆|亿)万/g, "$1").replace(/(京|兆)亿/g, "$1").replace(/(京)兆/g, "$1").replace(/(京|兆|亿|仟|佰|拾)(万?)(.)仟/g, "$1$2零$3仟").replace(/^元零?|零分/g, "").replace(/(元|角)$/g, "$1整");
        }
        function CheckArea(e)
        {
            var selValue = $(e).val();
            if(selValue == "大海珠区")
            {
                alert("目前海珠区已划分海珠东区、海珠西区，如该借支属于东西区负责人审批请重新选择区域");
            }
        }
    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td {
            border: 0;
        }

        .auto-style3 {
            width: 180px;
        }
        .auto-style4 {
            width: 110px;
        }
        .auto-style5 {
            height: 23px;
        }
        p{margin:0}
        
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
            <h1>临时借用资金申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 712px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>

            <table id ="tbAround" width="712" >
                <tr>
                    <td colspan="4" style="text-align:right;padding-right:5px;">
                        No：<asp:Label ID="txtApplyID" runat="server"></asp:Label>
                        <%--<asp:TextBox ID="txtApplyID" runat="server" Width="160px"></asp:TextBox>--%>
                    </td>
                   <%-- <td rowspan="15" style="font-size: 20px; width: 20px;">第一联<br />：财务联</td>--%>
                </tr>
                <tr>
                    <td colspan="4" style="font-weight: bold;text-align:left;width:100%;font-size:12px" class="auto-style4">
                           <%--<asp:TextBox ID="Department" runat="server" Width="190px"></asp:TextBox>--%><input type="hidden" id="Hidden1" runat="server" />
                        部门：<asp:TextBox ID="txtDepartment" runat="server" Width="100" ></asp:TextBox>&nbsp;&nbsp;申请日期：<asp:Label ID="lbApplyDate" runat="server"  style="font-weight:500"></asp:Label>&nbsp;&nbsp;
                        需要日期：<asp:TextBox ID="txtNeedDate" runat="server" Width="70"></asp:TextBox>&nbsp;&nbsp;电话：<asp:TextBox ID="txtReplyPhone" runat="server" Width="90px" ></asp:TextBox>
                        所属区域 <asp:DropDownList ID="ddlArea" runat="server" Width="90" onchange="CheckArea(this)">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>大越秀区</asp:ListItem>
                            <asp:ListItem>白云区</asp:ListItem>
                            <asp:ListItem>大海珠区</asp:ListItem>
                            <asp:ListItem>海珠东区</asp:ListItem>
                            <asp:ListItem>海珠西区</asp:ListItem>
                            <asp:ListItem>大天河区</asp:ListItem>
                            <asp:ListItem>番禺一部</asp:ListItem>
                            <asp:ListItem>番禺二部</asp:ListItem>
                            <asp:ListItem>花都区</asp:ListItem>
                            <asp:ListItem>芳村南海区</asp:ListItem>
                            <asp:ListItem>工商铺一部</asp:ListItem>
                            <asp:ListItem>工商铺二部</asp:ListItem>
                             <asp:ListItem>项目部</asp:ListItem>
                            <asp:ListItem>汇瀚</asp:ListItem>
                            <asp:ListItem>后勤</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table style="width:100%" border-collapse: collapse; text-align: center;margin:0 auto">
                               <tr>
                    <td colspan="2" style="font-weight: bold;font-size:12px">申 请 事 项</td>
                    <td colspan="2" style="font-weight: bold;font-size:12px; width:40%">支 付 方 式</td>
                </tr>
                <tr >
                    <td colspan="2" rowspan="3" >
                        <%--<asp:TextBox ID="txtReason" runat="server" Height="100px" TextMode="MultiLine" Width="95%"></asp:TextBox>--%>
                        <table style="width:99%" border-collapse: collapse; text-align: center;margin:0 auto">
                              <tbody id="jzqk1">
                                            <tr>
                                                 <td colspan="3" style="font-weight: bold;width:72%;font-size:12px" class="auto-style4">
                                                    <%-- <input type="text" placeholder="1月电费" runat="server" id="txtReason" emptymes="请填费用内容"/>--%>
                                                   
                                                      <select name="CostProject" onchange="show_Hidden(this)">
                                                        <option value="请选择">请选择</option>
                                                         <option value="电费">电费</option>
                                                         <option value="水费">水费</option>
                                                         <option value="管理费">管理费</option>
                                                          <option value="租金">租金</option>
                                                          <option value="租金税费">租金税费</option>
                                                         <option value="其他">其他</option>
                                                    </select>
                                                     
                                                     <input type="hidden" name="hiCostProject" id="hiCostProject" emptymes="请选择费用"/>
                                                     <textarea  name="txtOther" emptymes="请填写其他费用" style="display:none;width:205px;max-width:205px; height:44px; max-height:44px; overflow:hidden" maxlength="45" onchange="OtherChange(this)" ></textarea>
                                                     <input type="hidden" name="hiOther" id="hiOther" emptymes="请填写其他费用"/>
                                                     <span id="date"> 
                                                     <input  type="text" name="startDate" style="width:20%" emptymes="请填写起初日期" dateplugin="datepicker"/>至
                                                     <input  type="text" name="endDate" style="width:20%" emptymes="请填写结束日期" dateplugin="datepicker"/>
                                                     </span>
                                                </td>
                                                 <td>￥<input type="text" style="width:50px" name="UnitPrice" emptymes="请填写单价" onchange="PriceChange(this);" /></td>
                                               
                                            </tr>
                                   
                                        </tbody>
                        
                        </table>
                         <asp:HiddenField ID="hidDetail1" runat="server" />
                    </td>
                    <td rowspan="3" style="width:10%">
                        <asp:CheckBox ID="cbPayK1" runat="server" Text="汇款"/><br /><br />
                        <asp:CheckBox ID="cbPayK2" runat="server" Text="现金" /><br /><br />
                        <asp:CheckBox ID="cbPayK3" runat="server" Text="支票" />
                    </td>
                    <td class="tl PL10" style="font-size:12px">账户名称<asp:TextBox ID="txtAcount" runat="server" Width="95%" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="tl PL10" style="font-size:12px">账　　号<asp:TextBox ID="txtAname" runat="server" Width="95%" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td  class="tl PL10" style="font-size:12px">开户银行<asp:TextBox ID="txtBank" runat="server" Width="95%" ></asp:TextBox></td>
                </tr>
             </table>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align:left" colspan="6"><input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk1', null)" /><input class="btnaddRowN" type="button" onclick="    delrow(this, 'jzqk1')" value="删除一行" /></td>
                 </tr>
                <tr>
                    <td class="tl PL10" style="font-size:12px;text-align:left; border:0">
                        金额：￥<asp:Label id="lMoney" runat="server"/><input type="hidden" runat="server" id="hilMoney"/>
                        </td>
                      <td class="tl PL10" style="font-size:12px;text-align:left">
                        <%--<asp:TextBox ID="txtMoney" runat="server" Width="180px"></asp:TextBox>　--%>
                        人民币:<asp:Label id="lBWMoney" runat="server"/> <input type="hidden" runat="server" id="hilBWMoney"/>
                        <%--<asp:TextBox ID="txtBWMoney" runat="server" Width="225px"></asp:TextBox>--%>
                    </td>
                    <td class="tl PL10" style="font-size:12px;text-align:left">
                        财务实际支出合计: ￥<asp:Label id="lExpenditure" runat="server"/> 
                    </td>
                    <td>
                          财务冲借支合计: ￥<asp:Label id="lRushedBy" runat="server"/> 
                    </td>
                </tr>
               
                <tr>
                    <td class="tl PL10" colspan="4" style="font-size:12px">
                        申请报告编号<asp:TextBox ID="txtApplyNo" runat="server" Width="35%"></asp:TextBox>　
                    </td>
                   <%-- <td class="tl PL10" colspan="2" style="font-size:12px">
                        借支冲帐记录<asp:TextBox ID="txtDialog" runat="server" Width="65%"></asp:TextBox>　
                    </td>--%>
                </tr>
                </table>
             <%--   <tr><td colspan="4">--%>

                    
                   <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0" style="width:712px">
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
                            <input type="radio" value="1" name="agree2"/><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree2"/><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree2"/><label class="l signyes">其他意见</label>
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
                    <td class="auto-style2">部门负责人：</td>
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
                         <tr class="noborder" style="height: 85px;">
                    <td class="auto-style2">财务部：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree4" runat="server" id="radFin1"/><label class="l signyes">确认收单</label>
                            <input type="radio" value="0" name="agree4" runat="server" id="radFin2"/><label class="l signno">退单</label>
                            <input type="radio" value="2" name="agree4" runat="server" id="radFin3"/><label class="l signyes">其他意见</label>
                        </div>
                        <div class="fieldtext">
                            <textarea rows="3" runat="server" id="txtSuggestion"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                              <%--<asp:Button runat="server" ID="bFinSige" Text="签名" OnClick="btnFinSige" Visible="false" OnClientClick="checkAduit"/>--%>
                            <asp:Button runat="server" CssClass="finSignBtn" ID="bFinSige" OnClick="btnFinSige" Text="确认" OnClientClick="return checkAduit()" Visible="false"/>
                            <%--<input type="button" class="signbtn" value="签名" runat="server"  onclick="btnFinSige" />--%>
                        </div>
                        <div class="fielddate">审核人：<asp:Label runat ="server" id="lAuditMame"></asp:Label> 日期：<%--<span class="signdate">_________</span>--%><asp:Label runat ="server" ID="lAuditDate"></asp:Label></div>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td colspan="4" style="text-align: left" class="auto-style5">
                        <span style="margin-left: 20px; text-align: left;font-size:12px">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 340px;font-size:12px">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>

               
                
            </table>
               <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
            <br />
             <%--   </td></tr>
                </table>--%>
            <!--打印正文结束-->
                <script>
                    $("#tbAround2 input").css({"border":"1px solid #98b8b5"});
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
            <asp:Button runat="server" ID="btnPrintPreview" Text="打印预览" OnClick="btnprint_Click" Visible="false"/>
         
            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="false" />
   
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
            <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
            <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
            <%--<input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />--%>
           <%--   <input type="button" id="Button2" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />--%>
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
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
</asp:Content>

