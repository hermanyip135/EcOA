<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_FinAffairsTransfer_Detail.aspx.cs" MasterPageFile="~/MasterPage.master"  Inherits="Apply_FinAffairsTransfer_Apply_FinAffairsTransfer_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
      <link rel="stylesheet" href="../../Script/uploadify/uploadify.css" type="text/css" />
    <script type="text/javascript" src="../../Script/uploadify/jquery.uploadify.min.js" charset="GB2312"></script>
      <style type="text/css">
        /*tr input {
            border: 1px solid #98b8b5;
        }*/

        .uploadify-button {
            background: #000 url("../../images/btn_save1_03.png") repeat-x scroll 0 0;
            border: 1px solid #4c68d5;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-family: 微软雅黑;
            font-weight: 700;
            height: 34px;
            overflow: hidden;
        }

        .uploadify:hover .uploadify-button {
            background: #000 url("../../images/btn_save1_03.png") repeat-x scroll 0 0;
            border: 1px solid #4c68d5;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-family: 微软雅黑;
            font-weight: 700;
            height: 34px;
            overflow: hidden;
        }

        .uploadify {
            text-indent: 0;
        }

        #hideupload {
            background: #000 url("../../images/btn_save1_03.png") repeat-x scroll 0 0;
            border: 1px solid #4c68d5;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-family: 微软雅黑;
            font-weight: 700;
            height: 30px;
            overflow: hidden;
            width:100px;
            line-height:30px;
            text-align:center;
            text-shadow: 0 -1px 0 rgba(0,0,0,0.25);
            font-size:12px;
            margin-bottom:0.8em;
        }
          .readonlyCss {
          
          font-weight:500;
          background-color:#B8B8B8
          }
    </style>
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        function getEmployee(n,position) {
            position = typeof position !== 'undefined' ? position : 0;
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getEmployee&code=" + n.value,
                success: function (info) {
                    if(position == 1)
                    {
                        if (info != "fail") {
                            var infos = info.split("|");
                            $("#<%=Sendee.ClientID%>").val(infos[1]);
                            $("#<%=SendeeEmail.ClientID%>").val(infos[10]);
                     }
                     else {
                         $("#<%=Sendee.ClientID%>").val("");
                         $("#<%=SendeeEmail.ClientID%>").val("");
		            
                     }
                    }
                    else
                    {
                        if (info != "fail") {
                            var infos = info.split("|");
                            $("#<%=Apply.ClientID%>").val(infos[1]);
                            $("#<%=HandoverEmail.ClientID%>").val(infos[10]);
                        }
                        else {
                            $("#<%=Apply.ClientID%>").val("");
                            $("#<%=HandoverEmail.ClientID%>").val("");
		            
                        }
                    }
                }
            })
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
                            $(copytr).find("select[name=" + k + "]").val(obj[k]);
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
        function isjson(obj){
            var isjson = typeof(obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length; 
            return isjson;
        }
        $(function() {   
            //$("#tabuploadfile").attr("style","");
            //$("#tabuploadfile").css("border","solid rgb(141, 188, 227)").css("border-width","1px 0px 0px 1px");

            //$("#tabuploadfile th").attr("border","");
            //$("#tabuploadfile th").css("border","solid rgb(141, 188, 227)").css("border-width","0px 1px 1px 0px");
 
            //$("#tabuploadfile td").attr("border","");
            //$("#tabuploadfile td").css("border","solid rgb(141, 188, 227)").css("border-width","0px 1px 1px 0px");

            //$("#tabuploadfile").find("tr:odd").css("background-color", "rgb(212, 237, 255)");
            $("#<%=Department.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });
            $("#<%=SendeeDept.ClientID%>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });

            FlowSignInit();
            ISSpareGoldInputBind();
            ISReceivablesInputBind();
            ISSpareGoldCustodianBind();
            ISFillDetailBind();
            ActionBind();
            LoadDetail("<%=this.hidDetail1.ClientID%>","jzqk1");
            LoadDetail("<%=this.hiHandleDetail.ClientID%>","jzqk");
            //上传
            $("#hideupload").click(function(){
                if($("#<%=ddlDataType.ClientID%>").val()=="-1")
                 {
                     alert("请选择资料类型");
                 }
            });
            $("#<%=ddlDataType.ClientID%>").change(function(){
                if($("#<%=ddlDataType.ClientID%>").val()=="-1")
                 {
                     $("#uploadify").hide();
                     $("#hideupload").show();
                    
                 }else
                 {
                     $("#hideupload").hide();
                     $("#uploadify").show();

                     $("#uploadify").uploadify({
                         'swf': '../../Script/uploadify/uploadify.swf',
                         'uploader': '../../Ajax/UploadHandler.ashx?MainID=<%=MainID%>&ApplyType=FinAffairs&DatumType='+$("#<%=ddlDataType.ClientID%>").val()+'',
                        //'cancelImg': '../../Script/uploadify/cancel.png',
                        'buttonText': '上传附件',
                        'queueID': 'fileQueue',
                        'fileTypeExts':'*.jpg;*.png;*.jpeg;*.pdf',
                        'fileTypeDesc':'请选择图片或pdf',
                        'auto': true,
                        'multi': false,
                        'width':100,
                        onDialogClose: onDialogClose,
                        onCancel: onDialogClose,
                        onUploadSuccess: onUploadSuccess
                    });
                }
            })
        })
            var onDialogClose = function (queueData) { }
            var onUploadSuccess = function (file, data, response) {
                if(data == "0")
                {
                    alert("请先登录");
                    return;
                }
                //进行解码
                var datanew=decodeURI(data);
                var obj = eval("(" + datanew + ")");       //转json
                  
                //var html = '<tr id="' + obj.datumtype + '" class="addsty">' 
                //    + '         <td style="width:300px; border:solid rgb(141, 188, 227); border-width:0px 1px 1px 0px;">'+ obj.datumtypename +'</td>'
                //    + '         <td style="text-align:center; border:solid rgb(141, 188, 227); border-width:0px 1px 1px 0px;"><image src="/Images/delete.gif" onclick=DeleteRow(this)/></td>'
                //    + '         <td style="display:none; border:solid rgb(141, 188, 227); border-width:0px 1px 1px 0px;">'+obj.name+'</td>'
                //    + '         <td style="display:none; border:solid rgb(141, 188, 227); border-width:0px 1px 1px 0px;">'+obj.path+'</td>'
                //    + '     </tr>';

                //$("#tabuploadfile").append(html);

                $("#uploadify").hide();
                $("#hideupload").show();
                $("#<%=UploadName.ClientID%>").val(obj.datumtypename);
              
                $.post("Apply_FinAffairsTransfer_Detail.aspx?type=enclosure&Endatumtypename="+escape(obj.datumtypename)+"&Enname=" + obj.name + "&Enpath=" + obj.path, function (data) {
                    //alert(data);
                    // $("#ddlFollowDepartment").html(data);
                  
                    
                })
                window.location='Apply_FinAffairsTransfer_Detail.aspx?MainID=<%=MainID %>';
            }
            function DeleteRow(t)
            {
                var id=$(t).parent().parent().attr("id");
                $(t).parent().parent().remove();

            

            }
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
            
                cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.Apply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
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
        //是否变更代收款备用金台账录入人
        function ISSpareGoldInputBind() {
            var ISSpareGoldInput = $("#<%=this.hiISSpareGoldInput.ClientID%>").val();

            if (ISSpareGoldInput == "") {
                   $("input[name='r']").each(function () {
                       this.checked = false;
                   });
                   return;
               }
               else {
                $(".ISSpareGoldInput input[type=radio][value=" + ISSpareGoldInput + "]").get(0).checked = true;

               }
        }
        //是否变更代收款系统录入人
        function ISReceivablesInputBind() {
            var ISReceivablesInput = $("#<%=this.hiISReceivablesInput.ClientID%>").val();

            if (ISReceivablesInput == "") {
                $("input[name='r1']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $(".ISReceivablesInput input[type=radio][value=" + ISReceivablesInput + "]").get(0).checked = true;

            }
        }
        //是否变更备用金保管人
        function ISSpareGoldCustodianBind() {
            var ISSpareGoldCustodian = $("#<%=this.hiISSpareGoldCustodian.ClientID%>").val();

            if (ISSpareGoldCustodian == "") {
                $("input[name='r2']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $(".ISSpareGoldCustodian input[type=radio][value=" + ISSpareGoldCustodian + "]").get(0).checked = true;

            }
        }

        //是否需填写《代收款收据及发票待处理的明细》
        function ISFillDetailBind() {
            var ISFillDetail = $("#<%=this.hiISFillDetail.ClientID%>").val();

            if (ISFillDetail == "") {
                $("input[name='r3']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $(".ISFillDetail input[type=radio][value=" + ISFillDetail + "]").get(0).checked = true;

            }
        }
        //是否需填写《代收款收据及发票待处理的明细》
        function ActionBind() {
            var Action = $("#<%=this.hiAction.ClientID%>").val();

            if (Action == "") {
                $("input[name='r4']").each(function () {
                    this.checked = false;
                });
                return;
            }
            else {
                $(".Action input[type=radio][value=" + Action + "]").get(0).checked = true;

            }
        }
        function check() {

            if($.trim($("#<%=HandoverCode.ClientID %>").val())=="") {alert("移交人工号不可为空！");$("#<%=HandoverCode.ClientID %>").focus();return false;}
            if($.trim($("#<%=Apply.ClientID %>").val())=="") {alert("移交人姓名不可为空！");$("#<%=HandoverCode.ClientID %>").focus();return false;}
            if($.trim($("#<%=Department.ClientID %>").val())=="") {alert("负责部门不可为空！");$("#<%=Department.ClientID %>").focus();return false;}
            if($.trim($("#<%=HandoverEmail.ClientID %>").val())=="") {alert("电子邮箱不可为空！");$("#<%=HandoverEmail.ClientID %>").focus();return false;}

            if($.trim($("#<%=SendeeCode.ClientID %>").val())=="") {alert("接收人工号不可为空！");$("#<%=SendeeCode.ClientID %>").focus();return false;}
            if($.trim($("#<%=Sendee.ClientID %>").val())=="") {alert("接收人姓名不可为空！");$("#<%=Sendee.ClientID %>").focus();return false;}
            if($.trim($("#<%=SendeeDept.ClientID %>").val())=="") {alert("负责部门不可为空！");$("#<%=SendeeDept.ClientID %>").focus();return false;}
            if($.trim($("#<%=SendeeEmail.ClientID %>").val())=="") {alert("电子邮箱不可为空！");$("#<%=SendeeEmail.ClientID %>").focus();return false;}
            if($.trim($("#<%=ttHandoverDepts.ClientID %>").val())=="") {alert("交接分行不可为空！");$("#<%=ttHandoverDepts.ClientID %>").focus();return false;}
            if($.trim($("#<%=ReceivablesBook.ClientID %>").val())=="") {alert("代收款数据不可为空！");$("#<%=ReceivablesBook.ClientID %>").focus();return false;}
            var  flag =true;
            var array1 = new Array();
            $("#jzqk1 tr").each(function(){
                $text = $(this).find("input");
                var c = true;
                var json ={};
                $text.each(function(){
                    if($.trim(this.value) == ""){
                       
                        alert($(this).attr("emptymes"));
                        if($(this).attr("emptymes") =='请选择收据')
                        {
                            $(this).prev().focus();
                        }else
                        {
                            $(this).focus();
                        }
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
         
            if($.trim($("#<%=ReceivablesSpareGoldMoeny.ClientID %>").val())=="") {alert("代收款备用金余额不能为空！");$("#<%=ReceivablesSpareGoldMoeny.ClientID %>").focus();return false;}
            if($.trim($("#<%=ReceivablesSpareGoldSumMoeny.ClientID %>").val())=="") {alert("代收款备用金总额不能为空！");$("#<%=ReceivablesSpareGoldSumMoeny.ClientID %>").focus();return false;}
            if($.trim($("#<%=SupplementNum.ClientID %>").val())=="") {alert("待补款收据号码不能为空！");$("#<%=SupplementNum.ClientID %>").focus();return false;}
            if($.trim($("#<%=SupplementMoeny.ClientID %>").val())=="") {alert("待补款收据金额不能为空！");$("#<%=SupplementMoeny.ClientID %>").focus();return false;}
           
            //是否变更代收款备用金台账录入人
           flag = false;
           var val = "";
           $("input[name='r']").each(function () {
               if (this.checked) {
                   flag = true;
                   val = this.value;
               }
           });
           if (!flag) {
               alert("请选择是否变更代收款备用金台账录入人");
               $("#r2").focus();
               return false;
           }
           $("#<%=this.hiISSpareGoldInput.ClientID%>").val(val);

            //是否变更代收款系统录入人
            flag = false;
             val = "";
            $("input[name='r1']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择是否变更代收款系统录入人");
                $("#Radio1").focus();
                return false;
            }
            $("#<%=this.hiISReceivablesInput.ClientID%>").val(val);

            if($.trim($("#<%=Platform.ClientID %>").val())=="") {alert("发票打印机不能为空！");$("#<%=Platform.ClientID %>").focus();return false;}
            if($.trim($("#<%=PlatformNum.ClientID %>").val())=="") {alert("编号不能为空！");$("#<%=PlatformNum.ClientID %>").focus();return false;}
            if($.trim($("#<%=CommissionInvoiceNum.ClientID %>").val())=="") {alert("佣金发票不能为空！");$("#<%=CommissionInvoiceNum.ClientID %>").focus();return false;}
            if($.trim($("#<%=CommissionOpenInvoiceNum.ClientID %>").val())=="") {alert("已开发票起止号不能为空！");$("#<%=CommissionOpenInvoiceNum.ClientID %>").focus();return false;}
            if($.trim($("#<%=CommissionCancelInvoiceNum.ClientID %>").val())=="") {alert("作废发票起止号不能为空！");$("#<%=CommissionCancelInvoiceNum.ClientID %>").focus();return false;}
            if($.trim($("#<%=CommissionBlankInvoiceNum.ClientID %>").val())=="") {alert("空白发票起止号不能为空！");$("#<%=CommissionBlankInvoiceNum.ClientID %>").focus();return false;}
            if($.trim($("#<%=SpareGoldUseMoney.ClientID %>").val())=="") {alert("已用金额不能为空！");$("#<%=SpareGoldUseMoney.ClientID %>").focus();return false;}
            if($.trim($("#<%=SpareGoldCashMoney.ClientID %>").val())=="") {alert("现金余额不能为空！");$("#<%=SpareGoldCashMoney.ClientID %>").focus();return false;}
            if($.trim($("#<%=SpareGoldPassbookMoney.ClientID %>").val())=="") {alert("备用金存折余款不能为空！");$("#<%=SpareGoldPassbookMoney.ClientID %>").focus();return false;}
            if($.trim($("#<%=SpareGoldSumMoney.ClientID %>").val())=="") {alert("往来帐备用金合计不能为空！");$("#<%=SpareGoldSumMoney.ClientID %>").focus();return false;}
            //是否变更备用金保管人
            flag = false;
             val = "";
            $("input[name='r2']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择是否变更备用金保管人");
                $("#Radio3").focus();
                return false;
            }
            $("#<%=this.hiISSpareGoldCustodian.ClientID%>").val(val);

            //是否需填写《代收款收据及发票待处理的明细》
            flag = false;
            val = "";
            $("input[name='r3']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择是否需填写《代收款收据及发票待处理的明细》");
                $("#Radio5").focus();
                return false;
            }
            $("#<%=this.hiISFillDetail.ClientID%>").val(val);

            //离职或者调铺
            flag = false;
            val = "";
            $("input[name='r4']").each(function () {
                if (this.checked) {
                    flag = true;
                    val = this.value;
                }
            });
            if (!flag) {
                alert("请选择离职或者调铺");
                $("#Radio8").focus();
                return false;
            }
            $("#<%=this.hiAction.ClientID%>").val(val);
            //收款或处理明细
            flag =true;
            var array2 = new Array();
            $("#jzqk tr").each(function(){
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
                $("#<%=this.hiHandleDetail.ClientID%>").val("");
                return false; 
            }
            ///  console.log(Obj2str(array1));
            $("#<%=this.hiHandleDetail.ClientID%>").val(Obj2str(array2));
        };
        //增加一行
        function addrow(e,idname,obj)
        {
            //if(obj == null)
            //{
            //    $("#jzqk1 tr").find("input").each(function () {
               
            //        Modetype = $(this).val();
            //        console.log(Modetype);
            //        if("请选择收据" == Modetype )
            //        {
            //            alert("请选择收据");
            //            return false;
            //        }
            //    })
            //}
           

            var copytr = $("#" + idname + " tr").first().clone();
            var index = $("#" + idname + " tr").length;       //总table数
            if($(copytr).find("span[id =HandleDetailOrder]"))
            {
                $(copytr).find("span[id =HandleDetailOrder]").html(index+1);
            }
            if(obj != null && obj != undefined && isjson(obj))
            {
                for(var k in obj) {
                    $(copytr).find("input[name=" + k + "]").val(obj[k]);
                    $(copytr).find("select[name=" + k + "]").val(obj[k]);
                    //遍历对象，k即为key，obj[k]为当前k对应的值
                    //   console.log(k);
                }
                 
            }
            else
            {
                //  console.log( $(copytr).find("input[type=text]").val(""));
                $(copytr).find("input[type=text]").val("");
                $(copytr).find("input[type=hidden]").val("");
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
        function show_Hidden(v){
            var value =  $(v).val();
            var hidden = $(v).next();//下拉框下个兄弟节点
            hidden.val(value);
        //    console.log(value);
        }
        </script>
  <style type="text/css">
    
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width:808px; margin: 0 auto;'>
        <div class="noprint">
            <%=SbFlow.ToString() %>
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>行政助理(财务事项)交接表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:808px; margin: 0 auto;"><span style="float: left;" class="file_number">申请日期:<asp:Label ID="lbApplyDate" runat="server"  style="font-weight:500;"></asp:Label></span><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>

            <table id ="tbAround" width="800" >
                <tr>
                   <td  style="font-weight: bold;">
                       移交人信息
                   </td>
                     <td>
                       <span style="color: red">*</span>  移交人工号：<asp:textbox id="HandoverCode" runat="server" onblur="getEmployee(this);"></asp:textbox><asp:TextBox ID="Apply"   runat="server" CssClass="readonlyCss" ></asp:TextBox> 
                        </td>
                     <td>
                         <span style="color: red">*</span>负责分行：<br/><asp:TextBox ID="Department" runat="server"  style="font-weight:500;"></asp:TextBox> 
                       </td>
                     <td>
                       <span style="color: red">*</span> 电子邮箱：<br/><asp:TextBox ID="HandoverEmail" runat="server"  CssClass="readonlyCss" ></asp:TextBox> 
                    </td>
                </tr>
                  <tr>
                   <td  style="font-weight: bold;">
                       接收人信息
                   </td>
                     <td>
                        <span style="color: red">*</span> 接收人工号：<asp:textbox id="SendeeCode" runat="server" onblur="getEmployee(this,1);"></asp:textbox><asp:TextBox ID="Sendee" runat="server"    CssClass="readonlyCss" ></asp:TextBox> 
                        </td>
                     <td>
                       <span style="color: red">*</span> 负责分行：<br/><asp:TextBox ID="SendeeDept" runat="server"   style="font-weight:500;"></asp:TextBox> 
                       </td>
                     <td>
                       <span style="color: red">*</span> 电子邮箱：<br/><asp:TextBox ID="SendeeEmail" runat="server"  CssClass="readonlyCss"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                    <td>交接分行 <span style="color: red">*</span></td>
                    <td colspan="3">
                        <textarea id="ttHandoverDepts" runat="server" style="width:90%"></textarea>
                    </td>
                </tr>
             <tr>
               <td rowspan="1">
                   <span style="color: red">*</span>代收款收据
               </td>
                  <td rowspan="1">
                    <asp:TextBox ID="ReceivablesBook" runat="server"  style="font-weight:500;"  Width="30px"></asp:TextBox> 本
                  </td>
                 <td colspan="2">
                      <table width="100%">
                            <tbody id="jzqk1">
                         <tr>
                             <td >
                                   <select name="selectReceipt" onchange="show_Hidden(this)">
                                                        <option value="请选择收据">请选择收据</option>
                                                         <option value="已开收据">已开收据</option>
                                                         <option value="空白收据">空白收据</option>
                                            
                                                    </select>
                                 <input type="hidden" name="hiReceipt" emptymes="请选择收据"/>

                             </td>
                  <td><span style="color: red">*</span>起止号为:<br/><input type="text" style="width:100px" name="ReceivablesOpenNum" emptymes="请输入起止号为"/>
               <%--  <asp:TextBox ID="ReceivablesOpenNum" runat="server"  style="font-weight:500;" emptymes="请输入起止号为"></asp:TextBox> --%>

                  </td>
                         </tr>
                                 </tbody>
                     </table>
                      <asp:HiddenField ID="hidDetail1" runat="server" />
                 </td>
                 </tr>
                 <tr>
                    <td style="text-align:right" colspan="6"><input class="btnaddRowN" type="button" value="添加新行" onclick="return addrow(this, 'jzqk1', null)" /><input class="btnaddRowN" type="button" onclick="    delrow(this, 'jzqk1')" value="删除一行" /></td>
                 </tr>
                <tr>
                    <td ><span style="color: red">*</span>代收款备用金余额</td>
                    <td>
                          <asp:TextBox ID="ReceivablesSpareGoldMoeny" runat="server"  style="font-weight:500;"></asp:TextBox> 
                    </td>
                    <td rowspan="3" colspan="2">
                        <span style="color: red">*</span>代收款备用金总额：￥ <asp:TextBox ID="ReceivablesSpareGoldSumMoeny" runat="server"  Width="80px"  style="font-weight:500;"></asp:TextBox>  元
                    </td>
                </tr>
                <tr>
                     <td><span style="color: red">*</span>待补款收据号码</td>
                    <td>
                          <asp:TextBox ID="SupplementNum" runat="server"  style="font-weight:500;"></asp:TextBox> 
                    </td>
                </tr>
                   <tr>
                     <td><span style="color: red">*</span>待补款收据金额</td>
                    <td>
                          <asp:TextBox ID="SupplementMoeny" runat="server"  style="font-weight:500;"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                         <span class="ISSpareGoldInput">
                                <label for="r1"><span style="color: red">*</span>是否变更代收款备用金台账录入人：</label><input type="radio" id="r2" name="r" value="1" /><label for="r2">是</label><input type="radio" id="r1" name="r" value="0" /><label for="r1">否</label>
                             <asp:HiddenField  runat="server" ID="hiISSpareGoldInput"/>
                         </span>
                    </td>
                      <td colspan="2">
                         <span class="ISReceivablesInput">
                                <label for="r1"><span style="color: red">*</span>是否变更代收款系统录入人：</label><input type="radio" id="Radio1" name="r1" value="1" /><label for="r2">是</label><input type="radio" id="Radio2" name="r1" value="0" /><label for="r1">否</label>
                              <asp:HiddenField  runat="server" ID="hiISReceivablesInput"/>
                         </span>
                    </td>

                </tr>
                <tr>
                    <td colspan="4">
                        <span style="color: red">*</span>发票打印机：<asp:TextBox ID="Platform" runat="server"  Width="50"  style="font-weight:500;"></asp:TextBox> 台
                        <span style="color: red">*</span>编号：<asp:TextBox ID="PlatformNum" runat="server"   style="font-weight:500;"></asp:TextBox> 
                    </td>
                   
                </tr>
                <tr>
                    <td rowspan="3"><span style="color: red">*</span>佣金发票</td>
                    <td rowspan="3"><asp:TextBox ID="CommissionInvoiceNum" runat="server"  Width="20"  style="font-weight:500;"></asp:TextBox>份</td>
                    <td>已开发票</td>
                    <td>
                        <span style="color: red">*</span>起止号为:<br/><asp:TextBox ID="CommissionOpenInvoiceNum" runat="server"    style="font-weight:500;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>作废发票</td>
                    <td>
                        <span style="color: red">*</span>起止号为:<br/><asp:TextBox ID="CommissionCancelInvoiceNum" runat="server"    style="font-weight:500;"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>空白发票</td>
                    <td>
                        <span style="color: red">*</span>起止号为:<br/><asp:TextBox ID="CommissionBlankInvoiceNum" runat="server"    style="font-weight:500;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">
                        分行备用金（往来帐）
                    </td>
                    <td colspan="2">
                        <span style="color: red">*</span>已用金额<asp:TextBox ID="SpareGoldUseMoney" runat="server"  Width="32"  style="font-weight:500;"></asp:TextBox> 元；<span style="color: red">*</span>现金余额<asp:TextBox ID="SpareGoldCashMoney" runat="server"  Width="32"  style="font-weight:500;"></asp:TextBox> 元；<span style="color: red">*</span>备用金存折余款<asp:TextBox ID="SpareGoldPassbookMoney" runat="server"  Width="32"  style="font-weight:500;"></asp:TextBox>元
                    </td>
                    <td rowspan="2">
                        <span style="color: red">*</span>往来帐备用金合计<asp:TextBox ID="SpareGoldSumMoney" runat="server"  Width="43px"  style="font-weight:500;"></asp:TextBox>元
                    </td>
                </tr>
                <tr>
                    <td>
                       <span style="color: red">*</span> 是否变更备用金保管人
                    </td>
                    <td>
                        <span class="ISSpareGoldCustodian">
                             <input type="radio" id="Radio3" name="r2" value="1" /><label for="r2">是</label><input type="radio" id="Radio4" name="r2" value="0" /><label for="r1">否</label>
                            <asp:HiddenField id="hiISSpareGoldCustodian"  runat="server"/>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="auto-style1">
                        银行存折(共2本)
                    </td>
                </tr>
                <tr>
                    <td>开户名</td>
                    <td>开户行</td>
                    <td>帐户</td>
                     <td>帐户余额</td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox ID="AccountName" runat="server"   style="font-weight:500;"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="AccountBank" runat="server"   style="font-weight:500;"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="Account" runat="server"   style="font-weight:500;"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="AccountBalance" runat="server"   style="font-weight:500;"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                       <asp:TextBox ID="AccountName1" runat="server"   style="font-weight:500;"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="AccountBank1" runat="server"   style="font-weight:500;"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="Account1" runat="server"   style="font-weight:500;"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="AccountBalance1" runat="server"   style="font-weight:500;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>POS机事项</td>
                    <td colspan="2">POS机帐号:<asp:TextBox ID="PostMachineAccounts" runat="server"   style="font-weight:500;"></asp:TextBox></td>
                    <td>
                        POS机密码接收人(签名):<asp:TextBox ID="PostMachineRecipient" runat="server"  Width="80px"   style="font-weight:500;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                       <span style="color: red">*</span> 是否需填写《代收款收据及发票待处理的明细》
                   
                         <span class="ISFillDetail">
                             <input type="radio" id="Radio5" name="r3" value="1" /><label for="r2">是</label><input type="radio" id="Radio6" name="r3" value="0" /><label for="r1">否</label>

                         </span>
                        <asp:HiddenField ID="hiISFillDetail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="color: red">*</span>
                         <span class="Action">
                             <input type="radio" id="Radio7" name="r4" value="1" /><label for="r2">离职</label><input type="radio" id="Radio8" name="r4" value="0" /><label for="r1">调铺</label></span>
                     <asp:HiddenField ID="hiAction" runat="server" />
                    </td>
                    <td colspan="3">
                       <span style=" font-size:15px; text-align:center">备注 </span> <textarea id="ActionRemark" runat="server" style="width:420px"></textarea>
                    </td>
                </tr>
                <tr>
                  <%--  <td colspan="4">
                            <div style="font-weight: bold; margin-bottom: 10px;">代收款收据及发票待处理的明细</div>
                        <table style="width: 97%; border-collapse: collapse; text-align: center;">
                             <tr>--%>
                                <td colspan="4">
                                     <div style="font-weight: bold; margin-bottom: 10px;">代收款收据及发票待处理的明细</div>
                                    <table style="width: 99%; border-collapse: collapse; text-align: center;margin:0 auto">
                                        <tr>
                                              <td>序号</td>
                                            <td><span style="color: red">*</span>收据或发票编号</td>
                                            <td><span style="color: red">*</span>欠缺内容事项</td>
                                           <td><span style="color: red">*</span>无法处理的原因</td>
                                        </tr>
                                        <tbody id="jzqk">
                                            <tr>
                                                <td><span id ="HandleDetailOrder">1</span></td>
                                                <td><input type="text"  name="HandleDetailNumber" emptymes="收据或发票编号不可为空"/></td>
                                                <td><input type="text"  name="HandleDetailMatter" emptymes="欠缺内容事项不可为空"/></td>
                                                 <td><input type="text"  name="HandleDetailReason" emptymes="无法处理的原因不可为空"/></td>
                                            </tr>
                                        </tbody>
                                       
                                        <tr>
                                            <td style="text-align:left" colspan="7"><input class="btnaddRowN" type="button" value="添加新行" onclick="addrow(this, 'jzqk', null)" /><input class="btnaddRowN" type="button" onclick="    delrow(this, 'jzqk')" value="删除一行" /></td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hiHandleDetail" runat="server" />
                                </td>
                       <%--     </tr>
                         </table>
                    </td>--%>
                </tr>
                <tr>
                    <td colspan="4">
                            <div id="divtype" style="height:90px; float:left">
                            上传资料名称：
                            <asp:DropDownList ID="ddlDataType" runat="server" >
                                <asp:ListItem Value="-1" Text="请选择"></asp:ListItem>
                                 <asp:ListItem Value="1" Text="分行行政助理交接清单"></asp:ListItem>
                                 <asp:ListItem Value="2" Text="代收款收据及发票待处理的明细"></asp:ListItem>
                                 <asp:ListItem Value="3" Text="秘书交接表(分行匙柜部分)"></asp:ListItem>
                                 <asp:ListItem Value="4" Text="营业员应收佣金表"></asp:ListItem>
                                 <asp:ListItem Value="5" Text="分行固定资产明细表"></asp:ListItem>
                            </asp:DropDownList>
                           
                   
                            <span id="uploadify" style="display:none;"></span>
                            <%--<p style="padding-left: 15px"><input id="hideupload" value="上传附件" readonly="readonly"/></p>--%>
                          <%--  <div id="hideupload"><span>上传附件</span></div>--%>
                                  <div id="hideupload"><span>上传附件</span></div>

                            <input type="hidden" id="hidnamepath" runat="server"/>
                        </div>

                       <%-- <div>
                            <table id="tabuploadfile" cellspacing="0"; cellpadding="2">
                                <tr>
                                  <th>上传资料名称</th>
                                  <th>删除</th>
                               </tr>
                            </table>
                        </div>--%>
                        <asp:HiddenField  runat="server" ID="UploadName"/>
                    </td>
                </tr>
                </table>
                   <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0" style="width:793px">
                  <tr class="noborder" style="height: 85px;" idx="1">
                    <td class="auto-style2">移交人</td>
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
                    <td class="auto-style2">接收人：</td>
                    <td class="tl PL10">
                        <div class="fieldradio">
                            <input type="radio" value="1" name="agree2" /><label class="l signyes" >同意</label>
                            <input type="radio" value="0" name="agree2"/><label class="l signno">不同意</label>
                            <input type="radio" value="2" name="agree2"/><label class="l signyes" >其他意见</label>
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
                    <td class="auto-style2">分行主管：</td>
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
                       <tr class="noborder" style="height: 85px;" idx="4">
                    <td class="auto-style2">秘书主管：</td>
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
                        <tr class="noborder" style="height: 85px;" idx="5">
                    <td class="auto-style2">行政主任：</td>
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