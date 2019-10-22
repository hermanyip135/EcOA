<%@ Page ValidateRequest="false" Title="项目部差旅申请 - 广州中原电子审批系统"  Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="Apply_BusinessTravel_Detail.aspx.cs" Inherits="Apply_BusinessTravel_Apply_BusinessTravel_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        p{margin:10px 0}
        .tbflows {
        width:700px;
        }
        .isCssFlow {
        display:none;
        }
    </style>
    <script type="text/javascript" src="../../Script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../Script/common_new.js"></script>
      <script type="text/javascript">
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
            
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.txtApply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
          }

          //同意删除
          function DeleteT() { //20141231：M_DeleteC
              cDeleteT("<%=MainID %>", "<%=ApplyN %>");
        }
    </script>
    <script type="text/javascript">
        var i = 1;

        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }
        function isjson(obj){
            var isjson = typeof(obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length; 
            return isjson;
        }
        function PageInit()
        {
            
            //初始化detail
            if(!rundetail)
            {
                if($("#<%=txtDispatchDepartment.ClientID%>").val() != "")
                 {
                   
                     LoadDetail("<%=this.hidDetail.ClientID%>","jzqk");
                     LoadDetail("<%=this.hidDetail1.ClientID%>","jzqk1");
                     LoadDetail("<%=this.hidDetail2.ClientID%>","jzqk2");
                     LoadDetail("<%=this.hidDetail3.ClientID%>","jzqk3");
                     LoadLiveHidden();//住宿下拉框加载
                     LoadModeHidden();//差旅下拉框加载
                     CurrencyChange();
                     FlowSignInit();
                     rundetail = true;
                     if ($("#isAddFlow").is(":visible")) {
                         console.log('ss')
                         $("#divIsFlow").removeClass();
                     }
                 }
             }

            
            //初始化时间控件
             $("[dateplugin='datepicker']").each(function(){
                 $(this).datepicker();
             });
         }
         //加载出差人员明细
         function DetailInit(idname)
         {
             var detail = $("#" + idname).val();
             var list = detail == "" ? [] : $.parseJSON(detail);
             for(var i = 0 ; i < list.length;i++)
             {
                 if(i == 0)
                 {
                     var copytr = $("#jzqk tr").first();
                     if(list[i] != null && list[i] != undefined && isjson(list[i]))
                     {
                         var obj = list[i];
                         for(var k in obj) {
                             $(copytr).find("input[name=" + k + "]").val(obj[k]);
                             //遍历对象，k即为key，obj[k]为当前k对应的值
                             //console.log(k);
                         }
                     }
                     else
                     {
                         $(copytr).find("input[type=text]").val("");
                     }
                 }
                 else
                 {
                     addrow(null,"jzqk",list[i]);
                 }
             }
         }
         //加载住宿明细
         function DetailInit1(idname)
         {
             var detail = $("#" + idname).val();
             var list = detail == "" ? [] : $.parseJSON(detail);
             for(var i = 0 ; i < list.length;i++)
             {
                 if(i == 0)
                 {
                     var copytr = $("#jzqk1 tr").first();
                     if(list[i] != null && list[i] != undefined && isjson(list[i]))
                     {
                         var obj = list[i];
                         for(var k in obj) {
                             $(copytr).find("input[name=" + k + "]").val(obj[k]);
                             //遍历对象，k即为key，obj[k]为当前k对应的值
                             //console.log(k);
                         }
                     }
                     else
                     {
                         $(copytr).find("input[type=text]").val("");
                     }
                 }
                 else
                 {
                     addrow(null,"jzqk1",list[i]);
                 }
             }
         }

         //加载明细 idname =hidDetail(隐藏的json) Idtbody=绑在那个id
         function LoadDetail(idname,Idtbody)
         {
             var detail = $("#" + idname).val();
             var list = detail == "" ? [] : $.parseJSON(detail);
             for(var i = 0 ; i < list.length;i++)
             {
                 if(i == 0)
                 {
                     var copytr = $("#"+Idtbody+" tr").first();
                     if(list[i] != null && list[i] != undefined && isjson(list[i]))
                     {
                         var obj = list[i];
                         for(var k in obj) {
                             $(copytr).find("input[name=" + k + "]").val(obj[k]);
                             //遍历对象，k即为key，obj[k]为当前k对应的值
                             //console.log(k);
                         }
                     }
                     else
                     {
                         $(copytr).find("input[type=text]").val("");
                     }
                 }
                 else
                 {
                     addrow(null,Idtbody,list[i]);
                 }
             }
         }
        
         //增加一行
         function addrow(e,idname,obj)
         {
             var copytr = $("#" + idname + " tr").first().clone();
             if(obj != null && obj != undefined && isjson(obj))
             {
                 for(var k in obj) {
                     $(copytr).find("input[name=" + k + "]").val(obj[k]);
                     //遍历对象，k即为key，obj[k]为当前k对应的值
                     //   console.log(k);
                 }
                 
             }
             else
             {
               //  console.log( $(copytr).find("input[type=text]").val(""));
                 $(copytr).find("input[type=text]").val("");
                 $(copytr).find("input[type=hidden]").val("请选择");
             }
             $(copytr).find("[dateplugin='datepicker']").each(function(){
                 $(this).removeAttr("id").removeAttr("class");
                 $(this).datepicker();
             });
             $("#" + idname).append(copytr);
             return;
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
         }
         var jJSON = <%=SbJson.ToString() %>;
        $(function () {
            i = $("#tbPropDepPre tr").length;
            $("#<%=txtDispatchDepartment.ClientID %>").autocomplete({ source: jJSON });
            $("#<%=this.txtReceiveDepartment.ClientID%>").autocomplete({ source: jJSON });

             
            $("#<%=txtBeginDate.ClientID%>").datepicker();
            $("#<%=txtEndDate.ClientID%>").datepicker();
        });
        //住宿明细计算
        function LiveChange()
        {
            var  Livetype='';//住宿类型
            var TextBoxNo = 0;//从0开始 内第几个input，1：单价，2：数量，3：单位，4：金额
            var day=0,people=0,salary=0;
            var CostSum=0;
            $("#jzqk1 tr").find("input").each(function () {
              
                if (TextBoxNo == 5) {//换行
                    TextBoxNo = 1;
                    day=0;people=0;salary=0;
                    Modetype = $(this).val();
                    if("请选择" == Modetype )
                    {
                        alert("请选择住宿类型");
                        return false;
                    }
                }
                else {
                    if(TextBoxNo == 0)
                    {
                        Modetype = $(this).val()
                        if("请选择" == Modetype )
                        {
                            alert("请选择住宿类型");
                            return false;
                        }
                    
                    }
                    if(TextBoxNo == 1){
                        if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) day=parseFloat($(this).val());
                    }
                    else if(TextBoxNo == 2){
                        if(/^\d+$/.test($(this).val())) people=parseInt($(this).val());
                    }
                    else if(TextBoxNo == 3){
                        if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) salary=parseFloat($(this).val());
                    }
                    else if(TextBoxNo == 4){
                        $(this).val(day*people*salary);
                        CostSum+=(day*people*salary);
                    }
                    TextBoxNo++;
                }
            });
            $("#txtliveTotal").val(CostSum);
            $("<%=hiLiveInfoSum.ClientID%>").val(CostSum); 
            totalSum();
        }
      
        //差旅计算
        function ModeChange()
        {
            //车金额、高铁金额、飞机金额
            var ModeCarSum=0,ModeHighSpeedSum=0,ModeAircraftSum=0
            var TextBoxNo = 0;//从0开始 内第几个input，3：单价，4：数量，5：金额
            var input1=0,input2=0
            var CostSum=0;
            var Modetype='';//差旅类型
            $("#jzqk2 tr").find("input").each(function () {
                var money=0;
              
                if (TextBoxNo == 6) {//换行
                    TextBoxNo = 1;
                    input1=0;input2=0;
                    Modetype = $(this).val();
                    if("请选择" == Modetype )
                    {
                        alert("请选择差旅方式");
                        return false;
                    }
                }
                else {
                    if(TextBoxNo == 0)
                    {
                        Modetype = $(this).val()
                        if("请选择" == Modetype )
                        {
                            alert("请选择差旅方式");
                            return false;
                        }
                    
                    }
                    if(TextBoxNo == 3){
                        if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) input1=parseFloat($(this).val());
                    }
                    else if(TextBoxNo == 4){
                        if(/^\d+$/.test($(this).val())) input2=parseInt($(this).val());
                    }
                   
                    else if(TextBoxNo == 5){
                        $(this).val(input1*input2);
                        CostSum+=(input1*input2);
                        money =input1*input2
                        if(Modetype == "长途汽车")
                        {
                            ModeCarSum+=money;
                        }
                        else if(Modetype =="高铁")
                        {
                            ModeHighSpeedSum+=money;
                        }
                        else if(Modetype == "飞机")
                        {
                            ModeAircraftSum+=money;
                        }
                    }
                  
                    TextBoxNo++;
                }
              
            });
            //   var ModeCar =parseFloat($("#hiModeCarSum").val())
            //  $("#hiModeCarSum").val(ModeCarSum)
            //  $("#hiModeHighSpeedSum").val(ModeHighSpeedSum)
            // $("#hiModeAircraftSum").val(ModeAircraftSum)
            $("#<%=hiModeCarSum.ClientID%>").val(ModeCarSum);
            $("#<%=hiModeHighSpeedSum.ClientID%>").val(ModeHighSpeedSum);
            $("#<%=hiModeAircraftSum.ClientID%>").val(ModeAircraftSum);
            $("#txtModeTotal").val(CostSum);
            totalSum();
        }
        //租车
        function CarChange()
        {
            var TextBoxNo = 0;//从0开始 内第几个input，3：单价，4：数量，5：金额
            var input1=0,input2=0
            var CostSum=0;
            $("#Tbody1 tr").find("input").each(function () {
               
                if (TextBoxNo == 8) {//换行
                    TextBoxNo = 1;
                    day=0;people=0;salary=0;
                }
                else {
                    if(TextBoxNo == 3){
                        if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) input1=parseFloat($(this).val());
                    }
                    else if(TextBoxNo == 6){
                        if(/^\d+$/.test($(this).val())) input2=parseInt($(this).val());
                    }
                   
                    else if(TextBoxNo == 7){
                        $(this).val(input1*input2);
                        CostSum+=(input1*input2);
                    }
                    TextBoxNo++;
                }
            });
            totalSum();
        }
        //通用费用
        function CurrencyChange()
        {
            var TextBoxNo = 0;//从0开始 内第几个input，1：单价，2：数量，3：单位，4：金额
            var input1=0,input2=0,input3=0;
            var CostSum=0;
            $("#jzqk3 tr").find("input").each(function () {
             
                if (TextBoxNo == 6) {//换行
                    TextBoxNo = 1;
                    day=0;people=0;salary=0;
                }
                else {
                    if(TextBoxNo == 1){
                        if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) input1=parseFloat($(this).val());
                    }
                    else if(TextBoxNo == 2){
                        if(/^\d+$/.test($(this).val())) input2=parseInt($(this).val());
                    }
                    else if(TextBoxNo == 3){
                        if(/^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($(this).val())) input3=parseFloat($(this).val());
                    }
                    else if(TextBoxNo == 4){
                        $(this).val(input1*input2*input3);
                        CostSum+=(input1*input2*input3);
                    }
                    TextBoxNo++;
                }
             
            });
            $("#txtCurrencyTotal").val(CostSum);
            totalSum();
        }
        //合计费用
        function totalSum()
        { 
            var liveInfoSum =parseFloat($("#txtliveTotal").val());//住宿
            var lModeCarSum = parseFloat($("#<%=hiModeCarSum.ClientID%>").val());//长途汽车
            //  var lModeCarSum = parseFloat($("#hiModeCarSum").val());//长途汽车
            // var lModeHighSpeedSum = parseFloat($("#hiModeHighSpeedSum").val());//高铁
            var lModeHighSpeedSum =   parseFloat($("#<%=hiModeHighSpeedSum.ClientID%>").val());//高铁
            // var lModeAircraftSum =parseFloat($("#hiModeAircraftSum").val());//飞机
            var lModeAircraftSum =  parseFloat($("#<%=hiModeAircraftSum.ClientID%>").val());//飞机
            var lCarMoney =parseFloat($("#<%=txtCarMoney.ClientID%>").val());//租车
            var lCurrencyTotal =parseFloat($("#txtCurrencyTotal").val());
            $("#<%=hiCurrencySum.ClientID%>").val(lCurrencyTotal);//通用
            
            $("#lliveInfoSum").html(liveInfoSum)
            $("#lModeCarSum").html(lModeCarSum)
            $("#lModeHighSpeedSum").html(lModeHighSpeedSum)
            $("#lModeAircraftSum").html(lModeAircraftSum)
            $("#lCarSum").html(lCarMoney)
            $("#lCurrencySum").html(lCurrencyTotal)
            $("#lTotal").html((liveInfoSum+lModeCarSum+lModeHighSpeedSum+lModeAircraftSum+lCarMoney+lCurrencyTotal)+'元')
            $("#<%=hiTotal.ClientID%>").val(liveInfoSum+lModeCarSum+lModeHighSpeedSum+lModeAircraftSum+lCarMoney+lCurrencyTotal);
        }
        //下拉框赋值
        function show_Hidden(v){    
            var value =  $(v).val();
            var hidden = $(v).next();//下拉框下个兄弟节点
            hidden.val(value);

        }
        //提交
        function check()
        {
            if($.trim($("#<%=txtReceiveDepartment.ClientID %>").val())=="") {alert("收文部门不可为空！");$("#<%=txtReceiveDepartment.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtDispatchDepartment.ClientID %>").val())=="") {alert("发文部门不可为空！");$("#<%=txtDispatchDepartment.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {alert("申请编号不可为空！");$("#<%=txtApplyID.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtFollowPhone.ClientID %>").val())=="") {alert("跟进人电话不可为空！");$("#<%=txtFollowPhone.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtTheme.ClientID %>").val())=="") {alert("主题不可为空！");$("#<%=txtTheme.ClientID %>").focus();return false;}
           
            if($.trim($("#<%=txtAddress.ClientID %>").val())=="") {alert("出差地点不可为空！");$("#<%=txtAddress.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtBeginDate.ClientID %>").val())=="") {alert("出差时间不可为空！");$("#<%=txtBeginDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtEndDate.ClientID %>").val())=="") {alert("出差时间不可为空！");$("#<%=txtEndDate.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtDays.ClientID %>").val())=="") {alert("共计天数不可为空！");$("#<%=txtDays.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtNight.ClientID %>").val())=="") {alert("共计夜数不可为空！");$("#<%=txtNight.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtReason.ClientID %>").val())=="") {alert("出差申请原因不可为空！");$("#<%=txtReason.ClientID %>").focus();return false;}
            if($.trim($("#<%=txtInspectionProject.ClientID %>").val())=="") {alert("考察项目不可为空！");$("#<%=txtInspectionProject.ClientID %>").focus();return false;}

           
            var flag =true;
            var array = new Array();
            $("#jzqk tr").each(function(){
                $text = $(this).find("input[type='text']");
                var c = true;
                var json ={};
                $text.each(function(){
                    if($.trim(this.value) == ""){
                        alert($(this).attr("emptymes"));
                        $(this).focus();
                        flag = false;
                        c = false;
                        return false;
                    }
                    json[$(this).attr("name")] = this.value;
                });
                if(!c){return false}
                array.push(json)
            })
            if(!flag)
            {
                $("#<%=this.hidDetail.ClientID%>").val("");
                return false; 
            }
            $("#<%=this.hidDetail.ClientID%>").val(Obj2str(array));
            //住宿
            var array1 = new Array();
            $("#jzqk1 tr").each(function(){
                $text = $(this).find("input");
                var c = true;
                var json ={};
                $text.each(function(){
                    if($.trim(this.value) == ""){
                        alert($(this).attr("emptymes"));
                        $(this).focus();
                        flag = false;
                        c = false;
                        return false;
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
          
            var array2 = new Array();
            $("#jzqk2 tr").each(function(){
                $text = $(this).find("input");
                var c = true;
                var json ={};
                $text.each(function(){
                    if($.trim(this.value) == ""){
                        alert($(this).attr("emptymes"));
                        $(this).focus();
                        flag = false;
                        c = false;
                        return false;
                    }
                    json[$(this).attr("name")] = this.value;
                });
                if(!c){return false}
                array2.push(json)
            })
            if(!flag)
            {
                $("#<%=this.hidDetail2.ClientID%>").val("");
                return false; 
            }
            $("#<%=this.hidDetail2.ClientID%>").val(Obj2str(array2));
           
            var array3 = new Array();
            $("#jzqk3 tr").each(function(){
                $text = $(this).find("input[type='text']");
                var c = true;
                var json ={};
                $text.each(function(){
                    if($.trim(this.value) == "" && typeof($(this).attr("emptymes"))!="undefined"){
                        alert($(this).attr("emptymes"));
                        $(this).focus();
                        flag = false;
                        c = false;
                        return false;
                    }
                   
                    json[$(this).attr("name")] = this.value;
                });
                if(!c){return false}
                array3.push(json)
            })
            if(!flag)
            {
                $("#<%=this.hidDetail3.ClientID%>").val("");
                return false; 
            }
            $("#<%=this.hidDetail3.ClientID%>").val(Obj2str(array3));
            return true;
        }
        //住宿下拉框
        function LoadLiveHidden()
        {
            $("#jzqk1 tr").find("input[type=hidden]").each(function () {
                var  liveHidden= $(this).val();
                $(this).prev().val(liveHidden) ;
            })
            LiveChange();
        }
        //差旅下拉框
        function LoadModeHidden()
        {
            $("#jzqk2 tr").find("input[type=hidden]").each(function () {
                var  liveHidden= $(this).val();
                $(this).prev().val(liveHidden) ;
            })
            ModeChange();
        }
        function getEmployee(n) {
            console.log(n.value);
            $.ajax({
                url: "../../Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        var  Modetype ="";
                        var TextBoxNo = 0;//从0开始 内第几个inpu
                        $("#jzqk tr").find("input").each(function () {
                            if (TextBoxNo == 6) {
                                TextBoxNo =0;
                                Modetype="";
                            }
                            if(TextBoxNo==0)
                            {
                                  Modetype = $(this).val();
                            }
                          
                            if(Modetype==n.value){
                                if(TextBoxNo ==1){
                                    console.log(infos[1]);
                                    $(this).val(infos[1]);
                                 
                                }
                                //if(TextBoxNo ==2){
                                //    $(this).val(infos[2]);
                                //}
                                if(TextBoxNo ==5){
                                    console.log(infos[9]);
                                    $(this).val(infos[9]);
                                }
                            }
                            TextBoxNo++
                        })
                        }
                
                    else{
                        console.log(infos)
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
        <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
            <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>项目部差旅申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 700px; margin: 0 auto;"></div>
            <div style="width:700px;margin:0 auto;"><span style="float:right;">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='700px'>
                <tr>
                    <td colspan="4" class="tl PL10">
                        <div style="padding-top: 10px;">
                            <p>
                                <label>收文部门：</label><asp:textbox id="txtReceiveDepartment" runat="server"></asp:textbox>  
                                <label style="display:inline-block;width:300px;text-align:right">发文日期：</label><asp:label id="lDispatchDate" runat="server" text="Label" Width="150px"></asp:label>
                               <%-- <asp:TextBox ID="TextBox1" runat="server" dateplugin="true"></asp:TextBox>--%>
                            </p>
                            <p>
                                <label>发文部门：</label><asp:textbox id="txtDispatchDepartment" runat="server"></asp:textbox> - <asp:Label ID="txtApply" runat="server" Text="Label"></asp:Label>
                                <%--<asp:textbox id="txtApply" runat="server"></asp:textbox>--%>
                                <label style="display:inline-block;width:221px;text-align:right">跟进人电话：</label><asp:textbox id="txtFollowPhone" runat="server"></asp:textbox>
                            </p>
                            <p>
                                <label>主　题　：关于 <asp:textbox id="txtTheme" runat="server"></asp:textbox> 差旅费用申请</label>
                                <label style="display:inline-block;width:167px;text-align:right">申请编号：</label><asp:textbox id="txtApplyID" runat="server"></asp:textbox>
                            </p>
                        </div><br />
                        <div style="width: 98%; border-bottom-style: groove; border-top-style: inset; border-top-width: 1px; border-bottom-width: 2px; height: 2px;"></div><br />

                        <div style="font-weight: bold; margin-bottom: 10px;">一、差旅申请原因及费用详情</div>
                        <%--一、差旅申请原因及费用详情--%>
                        <table style="width: 97%; border-collapse: collapse">
                            <tr>
                                <td style="text-align: center">出差地点</td>
                                <td class="tl PL10" colspan="3"><asp:textbox id="txtAddress" runat="server" Width="98%"></asp:textbox></td>
                            </tr>
                            <tr>
                                 <td style="text-align: center">出差时间</td>
                                <td class="tl PL10">
                                    <asp:textbox id="txtBeginDate" runat="server" Width="75px"></asp:textbox>～
                                    <asp:textbox id="txtEndDate" runat="server" Width="75px"></asp:textbox>      共计
                             <%--   </td>
                                 <td style="text-align: center">共计</td>
                                <td class="tl PL10">--%>
                                    <asp:textbox id="txtDays" runat="server" Width="14%"></asp:textbox>天
                                    <asp:textbox id="txtNight" runat="server" Width="14%"></asp:textbox>夜
                                    <%--住宅<asp:textbox id="txt8taC" runat="server" Width="50px"></asp:textbox>%，
                                    商业车位<asp:textbox id="txt9taC" runat="server" Width="50px"></asp:textbox>%--%>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">出差申请原因</td>
                                 <td class="tl PL10" colspan="3"><asp:textbox id="txtReason" runat="server" Width="98%" TextMode="MultiLine" Height="70px"></asp:textbox></td>
                            </tr>
                             <tr>
                                <td style="text-align: center">考察项目</td>
                                <td class="tl PL10" colspan="3"><asp:textbox id="txtInspectionProject" runat="server" Width="98%"></asp:textbox></td>
                            </tr>
                        </table>
                        <br />
                        <%--二、出差人员明细--%>
                        <div style="font-weight: bold; margin-bottom: 10px;">二、出差人员明细</div>
                        <table style="width: 97%; border-collapse: collapse; text-align: center;">
                             <tr>
                                <td colspan="4">
                                    <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                            <%--<td rowspan="2" style="width:108px">兼职人员职责</td>
                                            <td rowspan="2">兼职时间</td>--%>
                                              <td style="width:70px">工号</td>
                                            <td style="width:70px">姓名</td>
                                            <td style="width:70px">部门</td>
                                            <td style="width:100px">开始出差时间</td>
                                            <td style="width:100px">结束出差时间</td>
                                            <td style="width:100px">性别</td>
                                        </tr>
                                        <tbody id="jzqk">
                                            <tr>
                                                
                                                <%-- <td><input name="xuhao" value="1" style="width:40px" disabled="disabled"/></td>--%>
                                                <td><input type="text" style="width:80px" name="EmployeeID" emptymes="请填写工号" onblur="getEmployee(this)"/></td>
                                                <td><input type="text" style="width:100px" name="EmployeeName" emptymes="请填姓名"/></td>
                                                <td><input type="text" style="width:80px" name="UnitName" emptymes="请填写部门"/></td>
                                                <td><input type="text" style="width:100px" name="startdate" emptymes="请填写开始出差时间" dateplugin="datepicker" /></td>
                                                <td><input type="text" style="width:100px" name="enddate" emptymes="请填写结束出差时间" dateplugin="datepicker" /></td>
                                                <td><input type="text" style="width:90px" name="Sex" emptymes="请填写性别"/></td>

                                            </tr>
                                        </tbody>
                                       
                                        <tr>
                                            <td style="text-align:left" colspan="7"><input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk', null)" /><input class="btnaddRowN" type="button" onclick="    delrow(this, 'jzqk')" value="删除一行" /></td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidDetail" runat="server" />
                                </td>
                            </tr>
                         </table>
                        <br/>
                        <%--三住宿明细--%>
                        <div style="font-weight: bold; margin-bottom: 10px;">三、住宿明细</div>
                             <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                            <td rowspan="2" style="width:108px">住宿</td>
                                            <td >单价</td>
                                            <td >数量</td>
                                            <td >单位</td>
                                             <td >金额(元)</td>
                                        </tr>
                                        <tr>
                                            <td>元</td>
                                            <td>人/间</td>
                                            <td>晚</td>
                                            <td>(单价*数量*单位<br /></td>
                                        </tr>
                                        <tbody id="jzqk1">
                                            <tr>
                                                <td><select name="liveProject" onchange="show_Hidden(this)">
                                                    <option value="请选择">请选择</option>
                                                    <option value="省、国内">省、国内</option>
                                                     <option value="港澳台、国外">港澳台、国外</option>
                                                     <option value="其他">其他</option>
                                                    </select>
                                                    <input type="hidden" name="hiLiveProject" value="请选择" />
                                                </td>
                                               <%-- <td><input type="text" style="width:100px" name="duty" emptymes="请填写住宿" /></td>--%>
                                                 <td><input type="text" style="width:100px" name="liveUnitPrice" emptymes="请填写单价" onchange="LiveChange();" /></td>
                                                <td><input type="text" style="width:40px" name="liveNumber" emptymes="请填写数量" onchange="LiveChange();" /></td>
                                                <td><input type="text" style="width:40px" name="liveCompany" emptymes="请填写单位" onchange="LiveChange();" /></td>
                                                <td><input type="text" style="width:90px" name="liveMoney"  /></td>
                                            </tr>
                                        </tbody>
                                        <tr>
                                                <td>合计：</td>
                                                <td colspan="3"></td>
                                               
                                                <td><input type="text" id="txtliveTotal"  style="width:90px" value="0"/>
                                                  <%--  <asp:textbox runat="server" style="width:90px" id="txtliveTotal"/>--%>

                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:left" colspan="6"><input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk1', null)" /><input class="btnaddRowN" type="button" onclick="    delrow(this, 'jzqk1')" value="删除一行" /></td>
                                        </tr>
                                    </table>
                             <asp:HiddenField ID="hidDetail1" runat="server" />
                        <br />
                        <%--四、差旅方式--%>
                        <div style="font-weight: bold; margin-bottom: 10px;">四、差旅方式</div>
                         <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                            <td >差旅方式</td>
                                          <%--  <td >往返</td>--%>
                                            <td >所在城市</td>
                                            <td >去往城市</td>
                                             <td >单价(元)</td>
                                             <td >数量(人数)</td>
                                            <td >金额(元)
                                                <br />单价*数量
                                            </td>
                                        </tr>
                                       
                                        <tbody id="jzqk2">
                                            <tr>

                                              <td style="width:108px"><select name="Mode" onchange="show_Hidden(this)">
                                                  <option value="请选择">请选择</option>
                                                    <option value="长途汽车">长途汽车</option>
                                                     <option value="高铁">高铁</option>
                                                     <option value="飞机">飞机</option>
                                                    </select>
                                                  <input type="hidden" name="hiMode" id="hiMode" value="请选择"/>
                                              </td>
                                               <%-- <td><input type="text" style="width:100px" name="duty" emptymes="请填写住宿" /></td>--%>
                                              <%--  <td><label>去程</label></td>--%>
                                                  <td><input type="text" style="width:100px" name="txtModewhereCity" emptymes="请填写所在城市" /></td>
                                                 <td><input type="text" style="width:100px" name="txtModeGoCity" emptymes="请填写去往城市" /></td>
                                                 <td><input type="text" style="width:100px" name="txtModeUnitPrice" emptymes="请填写单价" onchange="ModeChange();"  /></td>
                                                 <td><input type="text" style="width:100px" name="txtModeNumber" emptymes="请填写数量" onchange="ModeChange();"  /></td>
                                                <td><input type="text" style="width:100px" name="txtModeMoeny" emptymes="请填写金额" onchange="ModeChange();" /></td>
                                              </tr>
                                        </tbody>
                                        <tr>
                                                <td style="width:108px">合计：</td>
                                                <td colspan="4"></td>
                                                <td>
                                                    <input type="text" style="width:90px" id="txtModeTotal" />
                                                   <%-- <asp:textbox runat="server" style="width:90px" id="txtModeTotal"/>--%>

                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:left" colspan="7"><input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk2', null)" /><input class="btnaddRowN" type="button" onclick="    delrow(this, 'jzqk2')" value="删除一行" /></td>
                                        </tr>
                                    </table>
                         <asp:HiddenField ID="hidDetail2" runat="server" />
                        <br />
                        <%--五、租车类型--%>
                        <div style="font-weight: bold; margin-bottom: 10px;">五、租车类型</div>
                         <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                            <td>费用类型</td>
                                            <td>租车公司名称</td>
                                            <td>预计租赁车型品牌</td>
                                             <td>预计租赁车型<br/>(三厢/7座/12座)</td>
                                             <td>每日租金</td>
                                        </tr>
                                        <tbody id="Tbody1">
                                            <tr>

                                              <td style="width:108px" rowspan="3">租车</td>
                                                  <td><input type="text" style="width:100px" name="txtCarCompanyName" runat="server" id="txtCarCompanyName" emptymes="请填写租车公司名称"/></td>
                                                 <td><input type="text" style="width:100px" name="txtCarBrand" runat="server" id="txtCarBrand" emptymes="请填写预计租赁车型品牌" /></td>
                                                 <td><input type="text" style="width:100px" name="txtCarModels" runat="server" id="txtCarModels" emptymes="请填预计租赁车型" /></td>
                                                 <td><input type="text" style="width:100px" name="txtCarRent" runat="server" id="txtCarRent" emptymes="请填写每日租金" onchange="CarChange();"/></td>
                                             
                                              </tr>
                                            <tr>
                                                <td>开始租赁时间</td>
                                                <td>结束租赁时间</td>
                                                <td>租赁天数</td>
                                                <td>金额<br/>(每日租金*租赁天数)</td>
                                            </tr>
                                            <tr>
                                                 <td><input type="text" style="width:100px" name="txtCarLeaseBeginDate" runat="server" id="txtCarLeaseBeginDate"  emptymes="请填写开始租赁时间" dateplugin="datepicker" /></td>
                                                 <td><input type="text" style="width:100px" name="txtCarLeaseEndDate" runat="server" id="txtCarLeaseEndDate"   emptymes="请填写结束租赁时间" dateplugin="datepicker"  /></td>
                                                 <td><input type="text" style="width:100px" name="txtCarLeaseDays" runat="server" id="txtCarLeaseDays"  emptymes="请填写租赁天数" onchange="CarChange();" /></td>
                                                 <td><input type="text" style="width:100px" name="txtCarMoney" runat="server"  id="txtCarMoney" emptymes="请填写金额"  value="0"/></td>
                                             
                                            </tr>
                                        </tbody>
                                     
                                    </table>
                        <br />
                         <%--六、通用项目--%>
                        <div style="font-weight: bold; margin-bottom: 10px;">六、通用项目</div>
                         <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                            <td >费用项目</td>
                                            <td >单价(元)</td>
                                            <td >数量(人数)</td>
                                             <td >单位(天数)</td>
                                            <td >金额(元)</td>
                                            <td>备注</td>
                                        </tr>
                                       
                                        <tbody id="jzqk3">
                                            <tr>
                                                <td><input type="text" style="width:100px" name="txtCurrencyProject" emptymes="请填写费用项目" /></td>
                                                  <td><input type="text" style="width:100px" name="txtCurrencyUnitPrice" emptymes="请填写单价" onchange="CurrencyChange();"/></td>
                                                 <td><input type="text" style="width:100px" name="txtCurrencyNumberDays" emptymes="请填写数量" onchange="CurrencyChange();"/></td>
                                                 <td><input type="text" style="width:100px" name="txtCurrencyCompany" emptymes="请填写单位" onchange="CurrencyChange();"/></td>
                                                 <td><input type="text" style="width:100px" name="txtCurrencyMoney" emptymes="请填写金额" /></td>
                                                <td><input type="text" style="width:100px" name="txtCurrencyMarks"  /></td>
                                              </tr>
                                        </tbody>
                                        <tr>
                                                <td style="width:108px">合计：</td>
                                                <td colspan="3"></td>
                                                <td><input type="text"style="width:90px" id="txtCurrencyTotal" value="0"/></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:left" colspan="7"><input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk3', null)" /><input class="btnaddRowN" type="button" onclick="    delrow(this, 'jzqk3')" value="删除一行" /></td>
                                        </tr>
                                    </table>
                         <asp:HiddenField ID="hidDetail3" runat="server" />
                        <br />
                        <%--7、差旅费用合计--%>
                        <div style="font-weight: bold; margin-bottom: 10px;">7、差旅费用合计</div>
                         <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                             <tr>
                                 <td >住宿费用</td>
                                 <td >长途汽车费用</td>
                                 <td >高铁费用</td>
                                 <td >飞机费用</td>
                                 <td >租车费用</td>
                                 <td >通用费用</td>
                                 <td>费用合计</td>
                             </tr>
                                        <tbody id="Tbody2">
                                            <tr>
                                                <td><label id="lliveInfoSum"></label><input type="hidden" runat="server" id="hiLiveInfoSum" value="0"/></td>
                                                  <td><label id="lModeCarSum"></label><input type="hidden"  runat="server" id="hiModeCarSum"  value="0"/></td>
                                                 <td><label id="lModeHighSpeedSum" ></label><input type="hidden"  runat="server" id="hiModeHighSpeedSum"  value="0"/></td>
                                                 <td><label id="lModeAircraftSum"></label><input type="hidden"  runat="server" id="hiModeAircraftSum"  value="0"/></td>
                                                 <td><label id="lCarSum"></label><input type="hidden" id="hiCarSum"  runat="server"  value="0"/></td>
                                                <td><label id="lCurrencySum" ></label><input type="hidden"  runat="server" id="hiCurrencySum"  value="0"/></td>
                                                 <td><label id="lTotal" ></label><input type="hidden" id="hiTotal" runat="server"  value="0"/></td>
                                              </tr>
                                        </tbody>
                                    </table>
                        <br />
                          <div style="font-weight: bold; margin-bottom: 10px;">8、其他说明</div>
                        <asp:textbox id="txtOtherExplain" runat="server" Width="98%" TextMode="MultiLine" Height="70px"></asp:textbox>
                        <div>注意：相关费用实报实销，提供正规发票报销，超出部分自行负责。</div>
                        <div style="float: right; font-weight: bold; margin-right: 50px;">全卷完。</div><br /><br />
                    </td>
                </tr>
                </table>
                   <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0">
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
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                  <tr class="noborder" style="height: 85px;" idx="2">
                    <td class="auto-style2">项目部秘书组审批人：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1"  name="agree2"/><label class="2 signyes">同意</label>
                            <input type="radio" value="0"  name="agree2"/><label class="2 signno">不同意</label>
                            <input type="radio" value="2"  name="agree2"/><label class="2 signyes">其他意见</label>
                        </div>
                        <div class="isCssFlow" id="divIsFlow">
                         <asp:Button ID="btnSaveLogisticsFlow"  runat="server" Text="增加审批环节"  OnClick="btnSaveLogisticsFlow_Click" />
                    </div>
                             <%--   <a id="afa"  onclick="btnSaveLogisticsFlow_Click">增加审批环节</a>--%>
                        <div class="fieldtext">
                            <textarea rows="3"></textarea>
                        </div>
                        <div class="fieldsign"></div>
                        <div class="fieldbtn">
                            <input type="button" class="signbtn" value="签名" onclick="sign(this)" id="isAddFlow" />
                        </div>
                        <div class="fielddate">日期：<span class="signdate">_________</span></div>
                    </td>
                </tr>
                  <tr class="noborder" style="height: 85px;" idx="3">
                    <td class="auto-style2">部门营销总监：</td>
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
                  <tr class="noborder" style="height: 85px;" idx="4">
                    <td class="auto-style2">项目一部总经理：</td>
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
                 <tr class="noborder" style="height: 85px;" idx="5">
                    <td class="auto-style2" rowspan="2">二级市场负责人</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                               <%--<label>法律部备注1：</label><asp:TextBox ID="txtLawRemarks" runat="server" Width="70%"></asp:TextBox><br/>--%>
                           <input type="radio" value="1" name="agree4" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree4" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio4" value="2" class="cOther" name="agree4" /><label for="radio8" class="l signyes">其他意见</label>                        
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
               <tr class="noborder" style="height: 85px;" idx="6">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree5" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree5" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio5" value="2" class="cOther" name="agree5" /><label for="radio8" class="l signyes">其他意见</label>
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
                 <tr class="noborder" style="height: 85px;" idx="7">
                    <td class="auto-style2" rowspan="2">行政部负责人</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                           <input type="radio" value="1" name="agree4" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree4" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio1" value="2" class="cOther" name="agree4" /><label for="radio8" class="l signyes">其他意见</label>                        
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
               <tr class="noborder" style="height: 85px;" idx="8">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree5" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree5" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio2" value="2" class="cOther" name="agree5" /><label for="radio8" class="l signyes">其他意见</label>
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

                 <tr class="noborder" style="height: 85px;" idx="10">
                    <td class="auto-style2" rowspan="2">人力资源部负责人</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                           <input type="radio" value="1" name="agree4" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree4" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio3" value="2" class="cOther" name="agree4" /><label for="radio8" class="l signyes">其他意见</label>                        
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
               <tr class="noborder" style="height: 85px;" idx="11">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree5" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree5" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio6" value="2" class="cOther" name="agree5" /><label for="radio8" class="l signyes">其他意见</label>
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

                 <tr class="noborder" style="height: 85px;" idx="12">
                    <td class="auto-style2" rowspan="2">财务部负责人</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                           <input type="radio" value="1" name="agree4" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree4" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio7" value="2" class="cOther" name="agree4" /><label for="radio8" class="l signyes">其他意见</label>                        
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
               <tr class="noborder" style="height: 85px;" idx="13">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree5" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree5" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio9" value="2" class="cOther" name="agree5" /><label for="radio8" class="l signyes">其他意见</label>
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

                  <tr class="noborder" style="height: 85px;" idx="14">
                    <td class="auto-style2" rowspan="2">后勤事务部</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                           <input type="radio" value="1" name="agree4" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree4" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio10" value="2" class="cOther" name="agree4" /><label for="radio8" class="l signyes">其他意见</label>                        
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
               <tr class="noborder" style="height: 85px;" idx="15">
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree5" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree5" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio11" value="2" class="cOther" name="agree5" /><label for="radio8" class="l signyes">其他意见</label>
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

                  <tr class="noborder" style="height: 85px;" idx="16">
                    <td class="auto-style2">董事总经理：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree3" /><label class="l signyes">同意</label>
                            <input type="radio" value="0" name="agree3" /><label class="l signno">不同意</label>
                            <input type="radio" id="radio8" value="2" class="cOther" name="agree3" /><label for="radio8" class="l signyes">其他意见</label>
                            <input type="button" class="songShenbtn" style="display: none" value="通知" onclick="tongzhu(this,6)" />
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
              


            </table>
              <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
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
        <asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="False" />
            <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
        <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
        <asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
       <%-- <asp:button runat="server" id="btnSignSave" text="标注已留档" onclick="btnSignSave_Click" visible="false" />--%>
        <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
        <asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
        <asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
        <asp:hiddenfield id="hdIsAgree" runat="server" />
        <asp:hiddenfield id="hdSuggestion" runat="server" />
        <input type="hidden" id="hdDetail" runat="server" />
            <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    
    <script type="text/javascript">
        var rundetail = false;
        PageInit();
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        //其他意见
        //$("#tbflows .cOther").click(function () {
        //    if (this.checked) {
        //        var $button = $(this).parent().parent().find(".fieldbtn input[type=button]");
        //        if ($button.is(":visible")) {
        //            $button.parent().siblings().find(".songShenbtn").show();
        //        }
        //    }
        //})
    </script>
    <%=SbJs.ToString() %>
</asp:Content>

