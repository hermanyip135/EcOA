<%@ Page ValidateRequest="false" Title="房友圈网签变更、特殊申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ChangeFyq_Detail.aspx.cs" Inherits="Apply_ChangeFyq_Apply_ChangeFyq_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

    </style>
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var deleteidxs = "";
        var jaf = 20;//789
        var deleteidxs = "";
        var jJSONF = <%=SbJsonf.ToString() %>;
        var jsontype={};

        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }

        var jJSON = <%=SbJson.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        var flowsl = '<%=flowsl %>';

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        

        $(function() {      
            $("#tabuploadfile").attr("style","");
            $("#tabuploadfile").css("border","solid rgb(141, 188, 227)").css("border-width","1px 0px 0px 1px");

            $("#tabuploadfile th").attr("border","");
            $("#tabuploadfile th").css("border","solid rgb(141, 188, 227)").css("border-width","0px 1px 1px 0px");
 
            $("#tabuploadfile td").attr("border","");
            $("#tabuploadfile td").css("border","solid rgb(141, 188, 227)").css("border-width","0px 1px 1px 0px");

            $("#tabuploadfile").find("tr:odd").css("background-color", "rgb(212, 237, 255)");

            i = $("#tbAddFlows tr").length;

            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });
            //for (var x = 1; x < i; x++) {
            //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
            //}

            //检查上传附件时，有没有选择必选资料类型
            $("#hideupload").click(function(){
                if($("#<%=ddlDataType.ClientID%>").val()=="-1")
                {
                    alert("请选择资料类型");
                }
            });

            $("#biangeng").click(function(){
                $("#uploadify").hide();
                $("#hideupload").show();
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
                        'uploader': '../../Ajax/UploadHandler.ashx?MainID=<%=MainID%>&ApplyType=huihan&DatumType='+$("#<%=ddlDataType.ClientID%>").val()+'',
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
            });



            

            //上传相关
            
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

                //var filename="";
                //var filepath="";
                //var datumtype="";
                //filename=filename+obj.name+",";
                //filepath=filepath+obj.path+",";
                //datumtype=datumtype+obj.datumtype+",";

                //$("#hidfilename").val(filename);
                //$("#hidfilepath").val(filepath);
                //$("#hiddatumtype").val(datumtype);
                
                $("#<%=ddlDataType.ClientID%> option").remove();
                $("#<%=ddlDataType.ClientID%>").append($('<option value="-1">---请选择---</option>'));

                delete jsontype[""+obj.datumtype+""]
                $("#spd"+obj.datumtype+"").hide();

                $.each(jsontype, function(val, text) {  
                    $("#<%=ddlDataType.ClientID%>").append($('<option></option>').val(val).html(text));  
                }); 
                // $("#<%=ddlDataType.ClientID%> option[value='"+obj.datumtype+"']").remove();

                
                var html = '<tr id="' + obj.datumtype + '" class="addsty">' 
                    + '         <td style="width:300px; border:solid rgb(141, 188, 227); border-width:0px 1px 1px 0px;">'+ obj.datumtypename +'</td>'
                    + '         <td style="text-align:center; border:solid rgb(141, 188, 227); border-width:0px 1px 1px 0px;"><image src="/Images/delete.gif" onclick=DeleteRow(this)/></td>'
                    + '         <td style="display:none; border:solid rgb(141, 188, 227); border-width:0px 1px 1px 0px;">'+obj.name+'</td>'
                    + '         <td style="display:none; border:solid rgb(141, 188, 227); border-width:0px 1px 1px 0px;">'+obj.path+'</td>'
                    + '     </tr>';

                $("#tabuploadfile").append(html);

                $("#uploadify").hide();
                $("#hideupload").show();
            }


            $("[id*=tbAround]").find("tr:not(.noborder)").find("label[for*=rdbSpecialApply]").css("color", "#022241");
            //i = $("#tbDetail tr").length - 1;
            $("#<%=txtCDate.ClientID%>").datepicker();
            $("#<%=txtHandleDate.ClientID%>").datepicker();
 
            //2016-11-29
    
                Adaptation();
        
 



            $("#<%=cbCNS1.ClientID%>").click(function(){
                Adaptation();
                ClearRdbs();
            });
            $("#<%=cbCNS2.ClientID%>").click(function(){
                Adaptation();
                ClearRdbs();

            });
            $("#<%=cbCNS3.ClientID%>").click(function(){
                Adaptation();
                ClearRdbs();
            });
            $("#<%=cbCNS4.ClientID%>").click(function(){
                Adaptation();
                ClearRdbs();
            });
    
            $("#<%=cbCNS6.ClientID%>").click(function(){
                Adaptation();
                ClearRdbs();
            });
       
            $("#<%=cbCNS8.ClientID%>").click(function(){
                Adaptation();
                ClearRdbs();
            });

            $("#<%=rdbSpecialApply1.ClientID%>").click(function(){
                ClearCtb();
            });
            $("#<%=rdbSpecialApply2.ClientID%>").click(function(){
                ClearCtb();
            });
            $("#<%=rdbSpecialApply3.ClientID%>").click(function(){
                ClearCtb();
            });
            $("#<%=rdbSpecialApply4.ClientID%>").click(function(){
                ClearCtb();
            });
            $("#<%=rdbSpecialApply5.ClientID%>").click(function(){
                ClearCtb();
            });
            $("#<%=rdbSpecialApply6.ClientID%>").click(function(){
                ClearCtb();
            });
            $("#<%=rdbSpecialApply7.ClientID%>").click(function(){
                ClearCtb();
            });
            $("#<%=rdbSpecialApply8.ClientID%>").click(function(){
                ClearCtb();
            });
            $("#<%=rdbSpecialApply9.ClientID%>").click(function(){
              //  alert("此项申请由房友圈设置审批流程！");
                ClearCtb();
            });
            

            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        });

        function ClearCtb(){
            $("#<%=cbCNS1.ClientID%>").removeAttr("checked");
            $("#<%=cbCNS2.ClientID%>").removeAttr("checked");
            $("#<%=cbCNS3.ClientID%>").removeAttr("checked");
            $("#<%=cbCNS4.ClientID%>").removeAttr("checked");
           
            $("#<%=cbCNS6.ClientID%>").removeAttr("checked");
 
            $("#<%=cbCNS8.ClientID%>").removeAttr("checked");
            $("#spd0").hide();
            $("#spd1").hide();
            $("#spd2").hide();
            $("#spd3").hide();
            
            $("#spd6").hide();
            $("#spd7").hide();
          
            $("#spd9").hide();
            $("#spd10").hide
            $("#spd11").hide();
            $("#divsum").hide();
        }
       
        function ClearRdbs(){
            $("#<%=rdbSpecialApply1.ClientID%>").removeAttr("checked");
            $("#<%=rdbSpecialApply2.ClientID%>").removeAttr("checked");
            $("#<%=rdbSpecialApply3.ClientID%>").removeAttr("checked");
            $("#<%=rdbSpecialApply4.ClientID%>").removeAttr("checked");
            $("#<%=rdbSpecialApply5.ClientID%>").removeAttr("checked");
            $("#<%=rdbSpecialApply6.ClientID%>").removeAttr("checked");
            $("#<%=rdbSpecialApply7.ClientID%>").removeAttr("checked");
            $("#<%=rdbSpecialApply8.ClientID%>").removeAttr("checked");
            $("#<%=rdbSpecialApply9.ClientID%>").removeAttr("checked");
        }

        function SearchId(id)
        {
            for(var i=0;i<$("#tabuploadfile tr").length;i++)
            {
                var aa=$("#tabuploadfile tr").eq(i).attr("id");
                if(aa==id)
                {          
                    return true;
                }
            }
            return false;
        }

        function DeleteRow(t)
        {
            var id=$(t).parent().parent().attr("id");
            $(t).parent().parent().remove();

            if(id=="0" &&($("#<%=cbCNS1.ClientID%>").prop('checked') || $("#<%=cbCNS2.ClientID%>").prop('checked') || $("#<%=cbCNS3.ClientID%>").prop('checked')
               || $("#<%=cbCNS4.ClientID%>").prop('checked')  || $("#<%=cbCNS6.ClientID%>").prop('checked')
           ||  $("#<%=cbCNS8.ClientID%>").prop('checked'))
                )
            {
                if(!jsontype.hasOwnProperty("0") && !SearchId("0"))
                {
                    jsontype[""+id+""]="存量房买卖合同变更协议";
                    $("#spd0").show();
                }
            }
            if(id=="1"&& ($("#<%=cbCNS1.ClientID%>").prop('checked') || $("#<%=cbCNS2.ClientID%>").prop('checked') 
                ||$("#<%=cbCNS4.ClientID%>").prop('checked') )||( $("#<%=cbCNS6.ClientID%>").prop('checked')&&$.trim($("#<%=ddlPriceChange.ClientID %>").val())=="低→高" )
                )
        {
            if(!jsontype.hasOwnProperty("1") && !SearchId("1"))
            {
                jsontype[""+id+""]="网签委托确认书";
                $("#spd1").show();
            }
        }


            if(id=="2"( $("#<%=cbCNS1.ClientID%>").prop('checked') || $("#<%=cbCNS2.ClientID%>").prop('checked') ) )
            {
                if(!jsontype.hasOwnProperty("2") && !SearchId("2"))
                {
                    jsontype[""+id+""]="新买家身份证";
                    $("#spd2").show();
                }
            }

            if(id=="3"&&( $("#<%=cbCNS1.ClientID%>").prop('checked') || $("#<%=cbCNS2.ClientID%>").prop('checked') ) )
            {
                if(!jsontype.hasOwnProperty("3") && !SearchId("3"))
                {
                    jsontype[""+id+""]="购房资格调查确认表";
                    $("#spd3").show();
                }
            }


            if(id=="6"&&( $("#<%=cbCNS4.ClientID%>").prop('checked'))   )
            {
                if(!jsontype.hasOwnProperty("6") && !SearchId("6"))
                {
                    jsontype[""+id+""]="委托公证书";
                    $("#spd6").show();
                }
               
            }
            if(id=="7"&&( $("#<%=cbCNS4.ClientID%>").prop('checked'))   )
            {
            
                if(!jsontype.hasOwnProperty("7") && !SearchId("7"))
                {
                    jsontype[""+id+""]="代理人身份证";
                    $("#spd7").show();
                }
            }

  
     
            if(id=="11"&&( $("#<%=cbCNS6.ClientID%>").prop('checked')&&$.trim($("#<%=ddlPriceChange.ClientID %>").val())=="高→低") )
            {
                
                if(!jsontype.hasOwnProperty("11") && !SearchId("11"))
                {
                    jsontype[""+id+""]="网签委托确认书（房友圈版）";
                    $("#spd11").show();
                }
            }


            
            //jsontype[""+id+""]=id==0?"存量房买卖合同变更协议":id==1?"网签委托确认书":id==2?"新买家身份证":id==3?"购房资格调查确认表":id==4?"关系证明/法律部签批的变更申请":id==5?"委托公证书":id==6?"代理人身份证资料":"";

    $("#<%=ddlDataType.ClientID%> option").remove();
            $("#<%=ddlDataType.ClientID%>").append($('<option value="-1">---请选择---</option>'));

            $.each(jsontype, function(val, text) {  
                $("#<%=ddlDataType.ClientID%>").append($('<option></option>').val(val).html(text));  
            }); 

            }

            function check() {
                //var filename="";
                //var filepath="";
                var strval="";

                //$("#tabuploadfile tr").each(function(){
                //    strval=strval+$(this).children().eq(2).text()+","+$(this).children().eq(3).text()+":";
                //    //filepath=$(this).children().eq(3).text()+",";
                //});

                for(var i=1;i<$("#tabuploadfile tr").length;i++)
                {
                    var chdr=$("#tabuploadfile tr").eq(i).children();
                    //name=chdr.eq(2).text()+",";
                    //path=chdr.eq(3).text()+",";
                    strval=strval+chdr.eq(2).text()+","+chdr.eq(3).text()+":";
                }
                //filename=name.substring(0,name.length-1);
                //filepath=path.substring(0,path.length-1);
                strval=strval.substring(0,strval.length-1);

                $("#<%=hidnamepath.ClientID %>").val(strval);


            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
                alert("成交编号不可为空！");
                $("#<%=txtApplyID.ClientID %>").focus();
		        return false;
            }
	        
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("申请分行不可为空！");
                $("#<%=txtDepartment.ClientID %>").focus();
		        return false;
            }
			
            if($.trim($("#<%=txtApply.ClientID %>").val())=="") {
                alert("申请人不可为空！");
                $("#<%=txtApply.ClientID %>").focus();
		        return false;
            }

            if($.trim($("#<%=txtPhone.ClientID %>").val())=="") {
                alert("联系电话不可为空！");
                $("#<%=txtPhone.ClientID %>").focus();
		        return false;
            }

            if($.trim($("#<%=ddlArea.ClientID%>").val())=="请选择") {
                alert("请选择区域名！");
                $("#<%=ddlArea.ClientID %>").focus();
		        return false;
            }

            if($.trim($("#<%=txtLocation.ClientID %>").val())=="") {
                alert("物业地址不可为空！");
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

            if(!$("#<%=rdbIsContract1.ClientID %>").prop("checked") && !$("#<%=rdbIsContract2.ClientID %>").prop("checked")) {
                alert("请选择是否已完成网签版合同！");
                $("#<%=rdbIsContract1.ClientID %>").focus();
		        return false;
            }
            if(!$("#<%=rdbIsCommission1.ClientID %>").prop("checked") && !$("#<%=rdbIsCommission2.ClientID %>").prop("checked")) {
                alert("请选择是否已收佣！");
                $("#<%=rdbIsCommission1.ClientID %>").focus();
		        return false;
            }

            if($("#<%=rdbIsCommission1.ClientID %>").prop("checked")){
                if($.trim($("#<%=txtCDate.ClientID %>").val())=="") {
                    alert("收佣日期不可为空！");
                    $("#<%=txtCDate.ClientID %>").focus();
                    return false;
                }
            }

            if (
                    !$("#<%=rdbSpecialApply1.ClientID %>").prop("checked") 
                    && !$("#<%=rdbSpecialApply2.ClientID %>").prop("checked") 
                    && !$("#<%=rdbSpecialApply3.ClientID %>").prop("checked")
                    && !$("#<%=rdbSpecialApply4.ClientID %>").prop("checked")
                    && !$("#<%=rdbSpecialApply5.ClientID %>").prop("checked")
                    && !$("#<%=rdbSpecialApply6.ClientID %>").prop("checked")
                    && !$("#<%=rdbSpecialApply7.ClientID %>").prop("checked")
                    && !$("#<%=rdbSpecialApply8.ClientID %>").prop("checked")
                    && !$("#<%=rdbSpecialApply9.ClientID %>").prop("checked")
                    && !$("#<%=cbCNS1.ClientID %>").prop("checked")
                    && !$("#<%=cbCNS2.ClientID %>").prop("checked")
                    && !$("#<%=cbCNS3.ClientID %>").prop("checked")
                    && !$("#<%=cbCNS4.ClientID %>").prop("checked")
 
                   && !$("#<%=cbCNS6.ClientID %>").prop("checked")
                   
                   && !$("#<%=cbCNS8.ClientID %>").prop("checked")
               ) 
            {
                alert("请选择特殊申请方式或网签变更");
                $("#<%=rdbSpecialApply1.ClientID%>").focus();
                return false;
            }
           <%-- if($("#<%=cbCNS1.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=ddlRelationship.ClientID %>").val())=="请选择") {
                    alert("请选择是否有关系证明！");
                    $("#<%=ddlRelationship.ClientID %>").focus();
                    return false;
                }
            }
            --%>
            if($("#<%=cbCNS6.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=ddlPriceChange.ClientID %>").val())=="请选择") {
                                alert("请选择报价变更！");
                                $("#<%=ddlPriceChange.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=ddlCompareOfChange.ClientID %>").val())=="请选择") {
                                alert("请选择变更后报价与成交价对比！");
                                $("#<%=ddlCompareOfChange.ClientID %>").focus();
                    return false;
                }
            }


            if($("#<%=rdbSpecialApply1.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=ddlPayWay.ClientID %>").val())=="请选择") {
                    alert("请选择付款方式！");
                    $("#<%=ddlPayWay.ClientID %>").focus();
                    return false;
                }
            }
            if($("#<%=rdbSpecialApply3.ClientID %>").prop("checked"))
            {
                if(!$("#<%=rdbWhoKeep1.ClientID %>").prop("checked") && !$("#<%=rdbWhoKeep2.ClientID %>").prop("checked") ) {
                    alert("请选择网签合同原件留底人！");
                    $("#<%=rdbWhoKeep1.ClientID %>").focus();
                    return false;
                }
            }
            if($("#<%=rdbSpecialApply4.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtSurePrice.ClientID %>").val())=="") {
                    alert("买卖双方确认网签成交价不能为空！");
                    $("#<%=txtSurePrice.ClientID %>").focus();
                    return false;
                }
                if($.trim($("#<%=ddlCompareP.ClientID %>").val())=="请选择") {
                    alert("请选择与成交价对比！");
                    $("#<%=ddlCompareP.ClientID %>").focus();
                    return false;
                }
            }
            if($("#<%=rdbSpecialApply6.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtHandleDate.ClientID %>").val())=="") {
                    alert("要求办理日期不能为空！");
                    $("#<%=txtHandleDate.ClientID %>").focus();
                    return false;
                }
            }

            if($("#<%=rdbSpecialApply8.ClientID %>").prop("checked") && $.trim($("#<%=txtDetailed.ClientID %>").val())=="")
            {
                alert("选择自行网签时请填写详细情况说明！");
                $("#<%=txtDetailed.ClientID %>").focus();
                return false;
            }
            

            if($("#<%=rdbSpecialApply9.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtOthers.ClientID %>").val())=="") {
                    alert("其他的特殊申请不能为空！");
                    $("#<%=txtOthers.ClientID %>").focus();
                    return false;
                }
            }

                if($("#<%=ddlDataType.ClientID%>").children().length>1 && ($("#<%=cbCNS1.ClientID %>").prop("checked") || $("#<%=cbCNS2.ClientID %>").prop("checked") || $("#<%=cbCNS3.ClientID %>").prop("checked") || $("#<%=cbCNS4.ClientID %>").prop("checked") || $("#<%=cbCNS6.ClientID %>").prop("checked")|| $("#<%=cbCNS8.ClientID %>").prop("checked")))
            {
                alert("请上传必须资料！");
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

        function checkAddFlow()
        {
            var contentaddflow="";
            for(var i=1;i<=10;i++)
            {
                if(i==1 || i==3 || i==4 || i==5 || i==6 || i==10)
                {
                    if($.trim($("#txtidx"+i).val())=="")
                    {
                        continue;
                    }
                    contentaddflow+=i+":"+$("#txtidx"+i).val()+";";
                }
                
            }
            contentaddflow = contentaddflow.substr(0,contentaddflow.length-1);

            $("#<%=hdcontentaddflow.ClientID %>").val(contentaddflow);

            if(confirm('请注意，如果你修改审批流程，该流程的后续环节都需要重审；\r\n确定要修改吗？'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        function getInfo(n) {
            $.ajax({
                url: "/Ajax/Apply_Handler.ashx",
                type: "post",
                dataType: "text",
                data: "action=getchangesNsInfoByApplyID&applyid=" + n.value,
                success: function(info) {
                    if (info != "fail") {
                        var infos = info.split("|");
                        $("#<%=txtLocation.ClientID%>").val(infos[0]);
                        $("#<%=txtMaster.ClientID%>").val(infos[1]);
                        $("#<%=txtBuyers.ClientID%>").val(infos[2]);
                    }
                    else{
                        $("#<%=txtLocation.ClientID%>").val("");
                        $("#<%=txtMaster.ClientID%>").val("");
                        $("#<%=txtBuyers.ClientID%>").val("");
                    }
                }
            })
        }

        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_ChangeFyq_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){ //&dpm="+$("#<%//=txtDepartment.ClientID %>").val()+"
            var win=window.showModalDialog("Apply_ChangeFyq_Flow.aspx?MainID=<%=MainID %>&flowsadd="+flowsl+"","","dialogWidth=800px;dialogHeight=320px");
            if(win=='success')
                window.location="Apply_ChangeFyq_Detail.aspx?MainID=<%=MainID %>";
        }
		
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
        function sign(idx) {
            if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='6'||idx=='7'||idx=='8'||idx=='9'||idx=='10'){ //789
                if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked") &&!$("#rdbOtherIDx"+idx).prop("checked")) {
                    alert("请确定是否同意！");
                    return;
                }
            }
            else{
                if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                    alert("请确定是否同意！");
                    return;
                }
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

function showOrHideIDx(x) {//789
    $("#divIDx" + x).toggle();
    $("#divTxtIDx" + x).toggle();
    return false;
}
function addFlow() {
    var count=$("#tbAddFlows tr").length;
    jaf=count+19;
    var html = '<tr id="trAddFlow' + jaf + '" class="noborder" style="height: 85px;">'
        +   '<td style="text-align: left; padding-left: 10px;" colspan="4">'
        +   '<div class="flow">'
        +   '部门名称：<input type="text" id="txtDpm' + jaf + '" style="margin-bottom: 10px;width:250px;border: 1px solid #98b8b5;" /><br/>'
        +   '<div id="divIDx' + (8*jaf+1) + '" class="item2">环节1</div>'
        +   '<div id="divTxtIDx' + (8*jaf+1) + '" class="item2">'
        +   '   <input type="text" id="txtIDxa' + (8*jaf+1) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (8*jaf+1) + '" type="hidden" />'
        +   '   <input type="radio" id="rdoIsCmodel' + jaf + '11" checked="checked" name="IsCmodel' + jaf + '1" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '11">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '10" name="IsCmodel' + jaf + '1" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '10">单人审批</label>'
        +   '</div>'
        +   '<img src="/Images/forward.png" class="forward"/>'
        +   '<div id="divIDx' + (8*jaf+2) + '" class="item2"><input id="btnIDx' + jaf + '2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (8*jaf+2) + ');" />'
        +   '   <label id="lblIDx' + jaf + '2" for="btnIDx' + jaf + '2">环节2</label>'
        +   '</div>'
        +   '<div id="divTxtIDx' + (8*jaf+2) + '" class="item2" style="display:none;">'
        +   '   <br/>&nbsp;环节2&nbsp;<input type="text" id="txtIDxa' + (8*jaf+2) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (8*jaf+2) + '" type="hidden" />'
        +   '   <input type="radio" id="rdoIsCmodel' + jaf + '21" checked="checked" name="IsCmodel' + jaf + '2" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '21">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '20" name="IsCmodel' + jaf + '2" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '20">单人审批</label>'
        +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (8*jaf+2) + ')">取消</a>'
        +   '</div>'				
        +   '<img src="/Images/forward.png" class="forward"/>'
        +   '<div id="divIDx' + (8*jaf+3) + '" class="item2"><input id="btnIDx' + jaf + '3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (8*jaf+3) + ');" />'
        +   '   <label id="lblIDx' + jaf + '3" for="btnIDx' + jaf + '3">环节3</label>'
        +   '</div>'
        +   '<div id="divTxtIDx' + (8*jaf+3) + '" class="item2" style="display:none;">'
        +   '   <br/>&nbsp;环节3&nbsp;<input type="text" id="txtIDxa' + (8*jaf+3) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (8*jaf+3) + '" type="hidden" />'
        +   '   <input type="radio" id="rdoIsCmodel' + jaf + '31" checked="checked" name="IsCmodel' + jaf + '3" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '31">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '30" name="IsCmodel' + jaf + '3" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '30">单人审批</label>'
        +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (8*jaf+3) + ')">取消</a>'
        +   '</div>'
        +   '<img src="/Images/forward.png" class="forward"/>'
        +   '<div id="divIDx' + (8*jaf+4) + '" class="item2"><input id="btnIDx' + jaf + '4" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (8*jaf+4) + ');" />'
        +   '   <label id="lblIDx' + jaf + '4" for="btnIDx' + jaf + '4">环节4</label>'
        +   '</div>'
        +   '<div id="divTxtIDx' + (8*jaf+4) + '" class="item2" style="display:none;">'
        +   '   <br/>&nbsp;环节4&nbsp;<input type="text" id="txtIDxa' + (8*jaf+4) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (8*jaf+4) + '" type="hidden" />'
        +   '   <input type="radio" id="rdoIsCmodel' + jaf + '41" checked="checked" name="IsCmodel' + jaf + '4" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '41">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '40" name="IsCmodel' + jaf + '4" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '40">单人审批</label>'
        +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (8*jaf+4) + ')">取消</a>'
        +   '</div>'
        +   '<img src="/Images/forward.png" class="forward"/>'
        +   '<div id="divIDx' + (8*jaf+5) + '" class="item2"><input id="btnIDx' + jaf + '5" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (8*jaf+5) + ');" />'
        +   '   <label id="lblIDx' + jaf + '5" for="btnIDx' + jaf + '5">环节5</label>'
        +   '</div>'
        +   '<div id="divTxtIDx' + (8*jaf+5) + '" class="item2" style="display:none;">'
        +   '   <br/>&nbsp;环节5&nbsp;<input type="text" id="txtIDxa' + (8*jaf+5) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (8*jaf+5) + '" type="hidden" />'
        +   '   <input type="radio" id="rdoIsCmodel' + jaf + '51" checked="checked" name="IsCmodel' + jaf + '5" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '51">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '50" name="IsCmodel' + jaf + '5" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '50">单人审批</label>'
        +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (8*jaf+5) + ')">取消</a>'
        +   '</div>'



        +   '<img src="/Images/forward.png" class="forward"/>'
        +   '<div id="divIDx' + (8*jaf+6) + '" class="item2"><input id="btnIDx' + jaf + '6" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (8*jaf+6) + ');" />'
        +   '   <label id="lblIDx' + jaf + '6" for="btnIDx' + jaf + '6">环节6</label>'
        +   '</div>'
        +   '<div id="divTxtIDx' + (8*jaf+6) + '" class="item2" style="display:none;">'
        +   '   <br/>&nbsp;环节6&nbsp;<input type="text" id="txtIDxa' + (8*jaf+6) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (8*jaf+6) + '" type="hidden" />'
        +   '   <input type="radio" id="rdoIsCmodel' + jaf + '61" checked="checked" name="IsCmodel' + jaf + '6" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '61">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '60" name="IsCmodel' + jaf + '6" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '60">单人审批</label>'
        +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (8*jaf+6) + ')">取消</a>'
        +   '</div>'
        +   '<img src="/Images/forward.png" class="forward"/>'
        +   '<div id="divIDx' + (8*jaf+7) + '" class="item2"><input id="btnIDx' + jaf + '7" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (8*jaf+7) + ');" />'
        +   '   <label id="lblIDx' + jaf + '7" for="btnIDx' + jaf + '7">环节7</label>'
        +   '</div>'
        +   '<div id="divTxtIDx' + (8*jaf+7) + '" class="item2" style="display:none;">'
        +   '   <br/>&nbsp;环节7&nbsp;<input type="text" id="txtIDxa' + (8*jaf+7) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (8*jaf+7) + '" type="hidden" />'
        +   '   <input type="radio" id="rdoIsCmodel' + jaf + '71" checked="checked" name="IsCmodel' + jaf + '7" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '71">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '70" name="IsCmodel' + jaf + '7" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '70">单人审批</label>'
        +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (8*jaf+7) + ')">取消</a>'
        +   '</div>'
        +   '<img src="/Images/forward.png" class="forward"/>'
        +   '<div id="divIDx' + (8*jaf+8) + '" class="item2"><input id="btnIDx' + jaf + '8" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (8*jaf+8) + ');" />'
        +   '   <label id="lblIDx' + jaf + '8" for="btnIDx' + jaf + '8">环节8</label>'
        +   '</div>'
        +   '<div id="divTxtIDx' + (8*jaf+8) + '" class="item2" style="display:none;">'
        +   '   <br/>&nbsp;环节8&nbsp;<input type="text" id="txtIDxa' + (8*jaf+8) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (8*jaf+8) + '" type="hidden" />'
        +   '   <input type="radio" id="rdoIsCmodel' + jaf + '81" checked="checked" name="IsCmodel' + jaf + '8" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '81">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '80" name="IsCmodel' + jaf + '8" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '80">单人审批</label>'
        +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (8*jaf+8) + ')">取消</a>'
        +   '</div></div>'
        +   '</td>'
        + '</tr>'
    //var html = '<tr id="trAddFlow' + jaf + '"><table><tr><td>这是'+ jaf +'个</td></tr></table></tr>'
    $("#trAddFlowBefore").before(html);
    $("#txtDpm"+ jaf).autocomplete({source: jJSON});
    for(var il =1;il<=8;il++)
    {
        $("#txtIDxa" + (8*jaf + il))
            .bind( "keydown", function( event ) {
                if ( event.keyCode === $.ui.keyCode.TAB && $( this ).data( "ui-autocomplete" ).menu.active ) {
                    event.preventDefault();
                }
            })
            .autocomplete({
                minLength: 0,
                source: function( request, response ) {
                    // delegate back to autocomplete, but extract the last term
                    response( $.ui.autocomplete.filter(jJSONF, extractLast( request.term ) ) );
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
    }
    jaf++; 
    i++
}
function deleteFlow() {
    if (i > 1) {
        i--;
        $("#tbAddFlows tr:eq(" + (i-1) + ")").remove();
        //$("#tbAround tr[id*=trDetail]").remove();
    } 
}
function SaveFlow() {
    var data = "";
    var flag = true, flag2 = true;
    var content = "";
    for(var k = 20; k < $("#tbAddFlows tr").length + 20 - 1; k++)
    {
        if ($.trim($("#txtDpm" + k).val()) == "") {
            alert("您所添加的部门名称不可为空。");
            $("#txtDpm" + k).focus();
            return false;
        }
    }
    for(var y = 8*20 + 1; y <= $("[id^=txtIDxa]").size() + 8*20; y++)
    {
        if($("#txtIDxa" + y).parent().css("display")!="none") 
        {
            if($.trim($("#txtIDxa" + y).val())=="")
            {
                alert("您所添加的审批环节不可为空！");
                $("#txtIDxa" + y).focus();
                return false;
            }
            content+=y+":"+$("#txtIDxa" + y).val()+";";
        }
        deleteidxs += y.toString() + "|";
    }

    content = content.substr(0,content.length-1);

    $("#tbAddFlows tr").each(function(n) {
        if (n != 0 && n != $("#tbAddFlows tr").size()) {
            data += $.trim($("#txtDpm" + (n+20-1)).val()) 
                + "&&" + (8*20+(8*n-7)).toString()
                + "&&1"
                + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "11").prop('checked')?"1":"0")
                + "&&1||"
                + $.trim($("#txtDpm" + (n+20-1)).val()) 
                + "&&" + (8*20+(8*n-7)+1).toString()
                + "&&2"
                + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "21").prop('checked')?"1":"0")
                + "&&" + ($("#txtIDxa" + (8*20+(8*n-7) + 1)).parent().css("display")!="none"?"1":"0") + "||"
                + $.trim($("#txtDpm" + (n+20-1)).val()) 
                + "&&" + (8*20+(8*n-7)+2).toString()
                + "&&3"
                + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "31").prop('checked')?"1":"0")
                + "&&" + ($("#txtIDxa" + (8*20+(8*n-7) + 2)).parent().css("display")!="none"?"1":"0") + "||"
                + $.trim($("#txtDpm" + (n+20-1)).val()) 
                + "&&" + (8*20+(8*n-7)+3).toString()
                + "&&4"
                + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "41").prop('checked')?"1":"0")
                + "&&" + ($("#txtIDxa" + (8*20+(8*n-7) + 3)).parent().css("display")!="none"?"1":"0") + "||"
                + $.trim($("#txtDpm" + (n+20-1)).val()) 
                + "&&" + (8*20+(8*n-7)+4).toString()
                + "&&5"
                + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "51").prop('checked')?"1":"0")
                + "&&" + ($("#txtIDxa" + (8*20+(8*n-7) + 4)).parent().css("display")!="none"?"1":"0") + "||"
            
                + $.trim($("#txtDpm" + (n+20-1)).val()) 
                + "&&" + (8*20+(8*n-7)+5).toString()
                + "&&6"
                + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "61").prop('checked')?"1":"0")
                + "&&" + ($("#txtIDxa" + (8*20+(8*n-7) + 5)).parent().css("display")!="none"?"1":"0") + "||"
                + $.trim($("#txtDpm" + (n+20-1)).val()) 
                + "&&" + (8*20+(8*n-7)+6).toString()
                + "&&7"
                + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "71").prop('checked')?"1":"0")
                + "&&" + ($("#txtIDxa" + (8*20+(8*n-7) + 6)).parent().css("display")!="none"?"1":"0") + "||"
                + $.trim($("#txtDpm" + (n+20-1)).val()) 
                + "&&" + (8*20+(8*n-7)+7).toString()
                + "&&8"
                + "&&" + ($("#rdoIsCmodel" + (n+20-1) + "81").prop('checked')?"1":"0")
                + "&&" + ($("#txtIDxa" + (8*20+(8*n-7) + 7)).parent().css("display")!="none"?"1":"0") + "||"
            ;
        }
    });
    if(flag)
    {
        data = data.substr(0, data.length - 2);
        $("#<%=hdLogisticsFlow.ClientID %>").val(data);
        $("#<%=hdcontent.ClientID %>").val(content);
        $("#<%=hddeleteidxs.ClientID %>").val(deleteidxs);
        var flowstate='<%=flowState%>';
        if(flowstate=="2")
        {
            if(confirm('请注意，如果你修改审批流程，该流程的后续环节都需要重审；\r\n确定要修改吗？'))
            {
                return true;
            }else
            {
                return false;
            }
        }else
        {
            return true;
        }


        
    }
   
}//987

function DeleteT() { //20141231：M_DeleteC
    $("#btnADelete").hide();
    var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
            if(sReturnValue=='deleted')
                window.location='/Apply/Apply_Search.aspx';
            else
                window.location.href=window.location.href;
}
        function Adaptation(){

            delete jsontype["0"]
            delete jsontype["1"]
            delete jsontype["2"]
            delete jsontype["3"]
            delete jsontype["4"]
            delete jsontype["5"]
            delete jsontype["6"]
            delete jsontype["7"]
            delete jsontype["8"]
            delete jsontype["9"]
            delete jsontype["10"]
            delete jsontype["11"]
            $("#spd0").hide();
            $("#spd1").hide();
            $("#spd2").hide();
            $("#spd3").hide();
            $("#spd4").hide();
            $("#spd5").hide();
            $("#spd6").hide();
            $("#spd7").hide();
            $("#spd8").hide();
            $("#spd9").hide();
            $("#spd10").hide();
            $("#spd11").hide();

            if($("#<%=cbCNS1.ClientID%>").prop('checked') || $("#<%=cbCNS2.ClientID%>").prop('checked') || $("#<%=cbCNS3.ClientID%>").prop('checked')
               || $("#<%=cbCNS4.ClientID%>").prop('checked')  || $("#<%=cbCNS6.ClientID%>").prop('checked')
            || $("#<%=cbCNS8.ClientID%>").prop('checked')
                )
            {
                   if(!jsontype.hasOwnProperty("0") && !SearchId("0"))
                    {
                        jsontype["0"]="存量房买卖合同变更协议";
                        $("#spd0").show();
                    }
            }
        if($("#<%=cbCNS1.ClientID%>").prop('checked') || $("#<%=cbCNS2.ClientID%>").prop('checked') 
            ||$("#<%=cbCNS4.ClientID%>").prop('checked') ||( $("#<%=cbCNS6.ClientID%>").prop('checked')&&$.trim($("#<%=ddlPriceChange.ClientID %>").val())=="低→高" )
                )
        {
                   if(!jsontype.hasOwnProperty("1") && !SearchId("1"))
                    {
                        jsontype["1"]="网签委托确认书";
                        $("#spd1").show();
                    }
        }


      if($("#<%=cbCNS1.ClientID%>").prop('checked') || $("#<%=cbCNS2.ClientID%>").prop('checked')  )
                {
                   if(!jsontype.hasOwnProperty("2") && !SearchId("2"))
                    {
                       jsontype["2"]="新买家身份证";
                        $("#spd2").show();
                    }
                }

        if($("#<%=cbCNS1.ClientID%>").prop('checked') || $("#<%=cbCNS2.ClientID%>").prop('checked')  )
        {
            if(!jsontype.hasOwnProperty("3") && !SearchId("3"))
            {
                jsontype["3"]="购房资格调查确认表";
                $("#spd3").show();
            }
        }


        if($("#<%=cbCNS4.ClientID%>").prop('checked')   )
        {
            if(!jsontype.hasOwnProperty("6") && !SearchId("6"))
            {
                jsontype["6"]="委托公证书";
                $("#spd6").show();
            }
            if(!jsontype.hasOwnProperty("7") && !SearchId("7"))
            {
                jsontype["7"]="代理人身份证";
                $("#spd7").show();
            }
        }

 
        if( $("#<%=cbCNS6.ClientID%>").prop('checked')&&$.trim($("#<%=ddlPriceChange.ClientID %>").val())=="高→低" )
            {
                if(!jsontype.hasOwnProperty("11") && !SearchId("11"))
                {
                    jsontype["11"]="网签委托确认书（房友圈版）";
                    $("#spd11").show();
                }
            }
                $("#<%=ddlDataType.ClientID%> option").remove();
        $("#<%=ddlDataType.ClientID%>").append($('<option value="-1">---请选择---</option>'));
        
        $.each(jsontype, function(val, text) {  
            $("#<%=ddlDataType.ClientID%>").append($('<option></option>').val(val).html(text));  
            }); 
        }

        //function ceshi()
        //{
        //    var Array1[]={"存量房买卖合同变更协议","网签委托确认书","新买家身份证"};

        //    Adaptation(Array1,Array2)
        //}

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
            <h1>广东中原地产代理有限公司</h1>
            <h1>网签变更、特殊申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td class="tl PL10" colspan="4">致：房友圈运作部/网签部   
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">申请分行</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="200px"></asp:TextBox><input type="hidden" id="hdDepartmentID" runat="server" />
                    </td>
                    <td class="auto-style5">申请人</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApply" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">成交编号</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApplyID" onblur="getInfo(this)" runat="server" Width="200px"></asp:TextBox></td>
                    <td class="auto-style5">区域</td>
                    <td class="tl PL10">
                        <asp:DropDownList ID="ddlArea" runat="server" Width="150px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>天河区</asp:ListItem>
                            <asp:ListItem>荔湾区(含芳村、南海)</asp:ListItem>
                            <asp:ListItem>海珠区</asp:ListItem>
                            <asp:ListItem>番禺区</asp:ListItem>
                            <asp:ListItem>花都区</asp:ListItem>
                            <asp:ListItem>越秀区</asp:ListItem>
                            <asp:ListItem>白云区</asp:ListItem>
                            <asp:ListItem>项目部</asp:ListItem>
                            <asp:ListItem>工商铺</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">物业地址</td>
                    <td colspan="3" class="auto-style7">
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
                    <td class="auto-style4">是否已收佣</td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbIsCommission1" runat="server" Text="是" GroupName="IsCommission" />
                        <asp:RadioButton ID="rdbIsCommission2" runat="server" Text="否" GroupName="IsCommission" />
                    </td>
                    <td class="auto-style5">是否已完成网签版合同</td>
                    <td class="tl PL10">
                        <asp:RadioButton ID="rdbIsContract1" runat="server" Text="是" GroupName="IsContract" />
                        <asp:RadioButton ID="rdbIsContract2" runat="server" Text="否" GroupName="IsContract" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">收佣日期</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtCDate" runat="server" Width="200px"></asp:TextBox></td>
                    <td class="auto-style5">联系电话</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" style="padding: 10px; text-align: left; line-height: 25px;">申请事项：（必填，不填不接受申请，特殊申请和网签变更只能选择其一）<br />
                        <span style="color:red;font-family:宋体;font-weight:bold;font-size:14px;">一、特殊申请：</span><br />
                        <asp:CheckBox ID="rdbSpecialApply1" runat="server" GroupName="SpecialApply" Text="（1）自行取网签合同原件办理房管局递件手续；付款方式：" OnCheckedChanged="rdbSpecialApply1_CheckedChanged" />
                        <asp:DropDownList ID="ddlPayWay" runat="server" Width="100px" AutoPostBack="True" >
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>一次性</asp:ListItem>
                            <asp:ListItem>按揭</asp:ListItem>
                        </asp:DropDownList><br />
                        <span style="font-weight: bold">★必须保证一定会在三天内归还有买卖双方签名的网签版《中介服务合同》和《存量房买卖合同》、递件受理回执各壹份到房友圈网签组，否则愿意接受HOLD佣处理。如取走合同两个月内未归还，一律视为遗失合同，愿意接受公司违规通告的处罚。
                        </span>
                        <br />
                        <asp:CheckBox ID="rdbSpecialApply2" runat="server" GroupName="SpecialApply" Text="（2）买卖双方取消交易，需要撤销网签合同" OnCheckedChanged="rdbSpecialApply1_CheckedChanged" /><br />
                        <asp:CheckBox ID="rdbSpecialApply3" runat="server" GroupName="SpecialApply" Text="（3）取回网签合同原件留底" OnCheckedChanged="rdbSpecialApply1_CheckedChanged" />
                        （<asp:CheckBox ID="rdbWhoKeep1" runat="server" GroupName="WhoKeep" Text="业主" />
                        <asp:CheckBox ID="rdbWhoKeep2" runat="server" GroupName="WhoKeep" Text="买家" />）
                        <span style="font-weight: bold">★注：业客双方只可各取一份原件留底
                        </span>
                        <br />
                        <asp:CheckBox ID="rdbSpecialApply4" runat="server" GroupName="SpecialApply" Text="（4）买卖双方确认网签成交价" OnCheckedChanged="rdbSpecialApply1_CheckedChanged" />
                        <asp:TextBox ID="txtSurePrice" runat="server"></asp:TextBox>元　与成交价对比：
                        <asp:DropDownList ID="ddlCompareP" runat="server" Width="150px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>低于成交价5成</asp:ListItem>
                            <asp:ListItem>低于成交价7成</asp:ListItem>
                            <asp:ListItem>与成交价一致</asp:ListItem>
                             <asp:ListItem>报高价</asp:ListItem>
                           <%-- <asp:ListItem>其它情况</asp:ListItem>--%>
                        </asp:DropDownList><br />
                        <asp:CheckBox ID="rdbSpecialApply5" runat="server" GroupName="SpecialApply" Text="（5）房管局的退案申请盖网签专用章" OnCheckedChanged="rdbSpecialApply1_CheckedChanged" /><br />
                        <asp:CheckBox ID="rdbSpecialApply6" runat="server" GroupName="SpecialApply" Text="（6）超时申请办理递件业务" OnCheckedChanged="rdbSpecialApply1_CheckedChanged" />
                        ，要求办理日期：<asp:TextBox ID="txtHandleDate" runat="server"></asp:TextBox><br />
                        <asp:CheckBox ID="rdbSpecialApply7" runat="server" GroupName="SpecialApply" Text="（7）未上成交，要求提前网签及递件" OnCheckedChanged="rdbSpecialApply1_CheckedChanged" /><br />
                        <asp:CheckBox ID="rdbSpecialApply8" runat="server" GroupName="SpecialApply" Text="（8）客户要求自行网签" OnCheckedChanged="rdbSpecialApply1_CheckedChanged" /><br />
                        <asp:CheckBox ID="rdbSpecialApply9" runat="server" GroupName="SpecialApply" Text="（9）其他" />
                        <asp:TextBox ID="txtOthers" runat="server" Width="525px"></asp:TextBox><br />
                        <div style="padding-top: 5px; margin-bottom: 10px;"><span style="vertical-align: top; margin-top: 10px">详细情况说明</span><asp:TextBox ID="txtDetailed" runat="server" Width="525px" Height="100px" TextMode="MultiLine"></asp:TextBox></div>

                        <span style="color:red;font-family:宋体;font-weight:bold;font-size:14px;">二、网签变更：</span>（需上传变更协议及相关变更资料）<br />
                        <div id="biangeng">
                        <asp:CheckBox ID="cbCNS1" runat="server" Text="（1）更改落名人" OnCheckedChanged="cbCNS1_CheckedChanged" />
                        <%--关系证明：
                        <asp:DropDownList ID="ddlRelationship" runat="server" Width="100px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>是</asp:ListItem>
                            <asp:ListItem>否</asp:ListItem>
                        </asp:DropDownList>--%>
                            <br />
                        <asp:CheckBox ID="cbCNS2" runat="server" Text="（2）加人名" /><br />
                        <asp:CheckBox ID="cbCNS3" runat="server" Text="（3）减人名" /><br />
                        <asp:CheckBox ID="cbCNS4" runat="server" Text="（4）代理人变更" /><br />
                      <%--  <asp:CheckBox ID="cbCNS5" runat="server" Text="（5）买方代理人变更" /><br />--%>
                        <asp:CheckBox ID="cbCNS6" runat="server" Text="（5）报价变更" />：
                        <asp:DropDownList ID="ddlPriceChange" runat="server" Width="100px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>高→低</asp:ListItem>
                            <asp:ListItem>低→高</asp:ListItem>
                        </asp:DropDownList>
                        变更后报价与成交价对比：
                        <asp:DropDownList ID="ddlCompareOfChange" runat="server" Width="200px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>低于成交价5成（含5成）</asp:ListItem>
                            <asp:ListItem>低于成交价7成</asp:ListItem>
                            <asp:ListItem>其他情况</asp:ListItem>
                        </asp:DropDownList><br />
                      <%--  <asp:CheckBox ID="cbCNS7" runat="server" Text="（6）变更卖方个人信息" /><br />--%>
                        <asp:CheckBox ID="cbCNS8" runat="server" Text="（7）其他变更" /><br />
                            </div>

                        <div id="divtype" style="height:90px;">
                            必须上传资料：
                            <asp:DropDownList ID="ddlDataType" runat="server" Width="200px">
                                <asp:ListItem Value="-1" Text="请选择"></asp:ListItem>
                            </asp:DropDownList>
                            

                            <p><span id="uploadify" style="display:none;"></span></p>
                            <%--<p style="padding-left: 15px"><input id="hideupload" value="上传附件" readonly="readonly"/></p>--%>
                            <div id="hideupload"><span>上传附件</span></div>

                            <input type="hidden" id="hidnamepath" runat="server"/>
                        </div>

                        <div>
                            <table id="tabuploadfile" cellspacing="0"; cellpadding="2">
                                <tr>
                                  <th>上传资料名称</th>
                                  <th>删除</th>
                               </tr>
                            </table>
                        </div>


                        <div id="divsum" style="margin-top:15px;">
                            必须上传资料：<br />
                        </div>
                        <span id="spd0" style="display: none">存量房买卖合同变更协议，
                        </span>
                         <span id="spd1" style="display: none">网签委托确认书，
                        </span>
                         <span id="spd2" style="display: none">新买家身份证，
                        </span>
                         <span id="spd3" style="display: none">购房资格调查确认表，
                        </span>
                  <%--      <span id="spd4" style="display: none">存量房买卖合同撤下申请表，
                        </span>     --%>          
                    <%--     <span id="spd5" style="display: none">中介服务合同变更申请表，
                        </span>--%>
                         <span id="spd6" style="display: none">委托公证书，
                        </span>
                        <span id="spd7" style="display: none">代理人身份证，
                        </span>

      <%--                  <span id="spd8" style="display: none">存量房买卖合同变更申请表，
                                    </span>--%>
               <%--         <span id="spd9" style="display: none">网签价格确认书（报高价），
                        </span>
                       <span id="spd10" style="display: none">网签价格确认书（报低价）
                       </span>--%>
                       <span id="spd11" style="display: none">网签委托确认书（房友圈版）
                      </span>

                        <div style="margin-top: 10px">
                            <hr />
                            特向公司申请以上情况备案，希望公司批准。同时确保此份成交没有问题，如发生任何问题，负责此宗交易的所有人员（即营业员、主管、隶属区经/总监、区域负责人）均愿意承担此份成交所带来的风险，并同意公司直接从本人的佣金中扣回此宗交易已发放的全部佣金。
                        </div>
                    </td>
                </tr>

                <tr style="display: none;">
                    <td colspan="4" style="text-align: left">
                        <span style="margin-left: 20px; text-align: left;">填写人：<asp:Label ID="lblApply" runat="server"></asp:Label></span>
                        <span style="text-align: right; margin-left: 390px;">填写日期：<asp:Label ID="lbData" runat="server"></asp:Label></span>
                    </td>
                </tr>

                <tr id="add1F" style="display:none;">
                    <td colspan="4">
                        <table id="tbAddFlows" class='sample tc' width='100%'>
                            <%=SbHtml %>
                            <tr id="trAddFlowBefore">

                                <td>
                                    <asp:Button ID="btnSaveLogisticsFlow" runat="server" Text="" OnClientClick="return SaveFlow();" OnClick="btnSaveLogisticsFlow_Click" />
                                    <div id="TSD1" style="display: none; margin-top:10px;">
                                        <a id="a1" href="javascript:void(0)" onclick="addFlow();">增加审批环节</a>
                                        <a id="A2" href="javascript:void(0)" onclick="deleteFlow()">删除添加的审批环节</a><br />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <%--<tr id="TSD1" style="display: none;">
                    <td colspan="4">
                        <a id="afa" href="javascript:void(0)" onclick="addFlow();">增加审批环节</a>
                        <a id="dfd" href="javascript:void(0)" onclick="deleteFlow()">删除添加的审批环节</a><br />
                    </td>
                </tr>--%>

                <%=SbHtmlLogisticsFlow.ToString()%>
                

                <tr id="trManager1" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">分行主管</td>
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

   
                				<tr id="trM7" class="noborder" style="height: 85px; display: none;">
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
				</tr>

<%--                <tr id="traddflow" style="display:none">
                    <td style="text-align: left; padding-left: 10px;" colspan="4">
                        <div class="flow">分行主管：<input type="text" id="Text1" style="width:190px;border: 1px solid #98b8b5; margin-right:20px" />区域经理：<input type="text" id="Text2" style="width:190px;border: 1px solid #98b8b5;" /></div>
                        <div class="flow">区域总监：<input type="text" id="Text3" style="width:190px;border: 1px solid #98b8b5; margin-right:20px" />区域负责人：<input type="text" id="Text4" style="width:190px;border: 1px solid #98b8b5;" /></div>
                        <div class="flow"> 法律部：<input type="text" id="Text5" style="width:190px;border: 1px solid #98b8b5; margin-right:20px" />房友圈营运总经理：<input type="text" id="txtidx10" style="width:190px;border: 1px solid #98b8b5;" /></div>
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
                        <textarea id="txtIDx10" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S30"></textarea>
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
                        <a id="link" href='<%=ConfigurationManager.AppSettings["EcoaFileURL"]%><%#Eval("OfficeAutomation_Attach_Path")%>' target="_blank"><%#Eval("OfficeAutomation_Attach_NameNew")%></a>
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
            <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
            <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display:none;"/>
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

