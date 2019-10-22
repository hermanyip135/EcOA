<%@ Page ValidateRequest="false" Title="通用申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_GeneralApply_Detail.aspx.cs" Inherits="Apply_GeneralApply_Apply_GeneralApply_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <link href="../../Style/AddGroups.css" rel="stylesheet" />
    <script type="text/javascript">
        //debugger;
        var i = 1;
        var jaf = 200;
        var content = "";
        var deleteidxs = "";
        var flga = 2;
        var jJSONF = <%=SbJsonf.ToString() %>;
        var jJSON = <%=SbJson.ToString() %>;
        var SkyPlay = <%=SkyPlay.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }
        ///增加集团审批
        function AddGroups()
        {
            if(confirm("确定要集团审核？"))
            {
                
                $.ajax({
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=SaveGeneralApplyGroups&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>',
                    success: function(info) {
                        if (info == "success") {
                            alert('已增加集团审批');
                            location=location ;
                        }
                        else if (info == "NoPower")
                            alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                        
                        }
                        else if("Existed" == info)
                        {
                            alert("已增加集团审批");
                        }
                        else
                            alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
                })
              
}
           
}
//取消集团审批
function CancelGroups()
{
    if(confirm("确定要取消集团审核？"))
    {
        $.ajax({
            url: "/Ajax/Flow_Handler.ashx",
            type: "post",
            dataType: "text",
            data: 'action=CancelGroups&mainid=<%=MainID %>',
                    success: function(info) {
                        if (info == "success") {
                            alert('已取消集团审批');
                            location=location ;
                        }
                        else if (info == "NoPower")
                            alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                        
                        }
                        else if("Existed" == info)
                        {
                            alert("已取消集团审批");
                        }
                        else
                            alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
                })
}
}
$(function() {    
            
    //$("#<%=txtDescribe.ClientID %>").css("overflow-x","scroll");
            $("[id*=btnsSignIDx]").css({
                "background-image": "url(/Images/btnSureS1.png)",
                "height": "25px", 
                "width": "43px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnsSignIDx]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); });

            $("[id*=btnAddFlow]").css({
                "background-image": "url(/Images/btn_AddFlows1.png)",
                "height": "20px", 
                "width": "90px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnAddFlow]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_AddFlows2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_AddFlows1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_AddFlows1.png)"); });

            $("[id*=btnDeleteFlow]").css({
                "background-image": "url(/Images/btn_DeleteFlows1.png)",
                "height": "20px", 
                "width": "114px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnDeleteFlow]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows1.png)"); });

            i = $("#tbDetail tr").length;
            if($.trim($("#txtIDxa1").val())!="")
                $("#<%=hdFlowApply.ClientID %>").val($("#txtIDxa1").val());
            else if($.trim($("#txtIDxa2").val())!="")
                $("#<%=hdFlowApply.ClientID %>").val($("#txtIDxa2").val());
            else if($.trim($("#txtIDxa3").val())!="")
                $("#<%=hdFlowApply.ClientID %>").val($("#txtIDxa3").val());
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select:function(event,ui){
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                    $.ajax({
                        url: "/Ajax/HR_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=getHRTreeByDepartmentID&departmentid=' + ui.item.id,
                        success: function(info) {
                            if (info == "fail") 
                            {}
                                // alert("保存失败，部分人名不存在或不具备审批资格，\n请修改，如依然失败，请联系资讯科技部！");
                            else
                            {
                                var unitids=info.split("|")[0].split(",");
                                var units=info.split("|")[1].split(",");

                                if(units.length>0)
                                {
                                    $("#txtIDxa3").val(units[0]);
                                }
                            }
                        }
                    })
                }
            });

            $("#<%=txtReceiveDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });
            $("#<%=txtCCDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function(event,ui) {
                    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                }
            });

            $("#<%=txtCanSeeEmp.ClientID %>").autocomplete({ 
                minLength: 0,
                source: function( request, response ) {
                    $.ajax({
                        url: "/Ajax/AutoCompLete.ashx",
                        dataType: "json",
                        data: {
                            EmpName:$("#<%=txtCanSeeEmp.ClientID %>").val()
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
            
            for (var x = 1; x < i; x++) {
                $("#txtDpm"+ x).autocomplete({source: jJSON});
                //if($.trim($("#txtDpm"+ x).val()) == "人力资源部" && $("#txtIDxa" + (3*x+1*1)).val().indexOf("杨梅宝") != -1) //M_Maybobo：20140415
                //    $("#txtIDxa" + (3*x+1*1)).css("background-color","Silver").attr("readonly","readonly");
                //$("#txtDpm"+ x).blur(function(){
                //    if($.trim($("#"+this.id).val()) == "人力资源部"){
                //        showIDx(3*$.trim(this.id).replace("txtDpm","")+2*1);
                //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).val("杨梅宝");
                //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).css("background-color","Silver").attr("readonly","readonly");
                //    }
                //    else{
                //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).val("");
                //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).css("background-color","").removeAttr("readonly");
                //    }
                //});

                //$("#txtDpm"+ x).blur(function(){ //M_GW：20150604
                //    if($("#"+this.id).val().indexOf("董事总经理") != -1
                //        && $("#txtIDxa" + (3*($.trim(this.id).replace("txtDpm","") - 1)+1*1)).val().indexOf("黄瑛") == -1
                //        && $("#txtIDxa" + (3*($.trim(this.id).replace("txtDpm","") - 1)+2*1)).val().indexOf("黄瑛") == -1
                //        && $("#txtIDxa" + (3*($.trim(this.id).replace("txtDpm","") - 1)+3*1)).val().indexOf("黄瑛") == -1
                //        ){
                //        $("#"+this.id).val("后勤事务部");
                //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).val("黄瑛");
                //        addRow();
                //        $("#txtDpm"+ (i - 1)).val("董事总经理");
                //        $("#txtIDxa" + (3*(i - 1)+1)).val("黄轩明");
                //    }
                //});
            }
		    
            for(var il =1;il<=$("[id^=txtIDxa]").size();il++)
            {
                $("#txtIDxa" + il)
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
            //if($.trim($("#<%=txtDepartment.ClientID %>").val())=="总经办" && $.trim($("#txtIDxa3").val()) == ""){
            //    $("#txtIDxa3").val("黄轩明");
            //}
            autoTextarea(document.getElementById("txtIDx1"));
            autoTextarea(document.getElementById("txtIDx2"));
            autoTextarea(document.getElementById("txtIDx3"));
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
            
        });

        function check() {
            //try{
            //    if($("#ibta").html() == "切换普通模式"){
            //        for(var e in nicEditors.editors) {  
            //            nicEditors.editors[e].nicInstances[0].saveContent();
            //        }  
            //    }
            //}catch(ee)
            //{
            //    //alert("保存时遇到了未知错误，请重启浏览器后重试！");
            //    //return false;
            //}

            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
                alert("发文编号不可为空！");
                $("#<%=txtApplyID.ClientID %>").focus();
                return false;
            }
	        
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("部门/分行不可为空！");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
			
            if($.trim($("#<%=txtReplyPhone.ClientID %>").val())=="") {
                alert("回复电话不可为空！");
                $("#<%=txtReplyPhone.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtSubject.ClientID %>").val())=="") {
                alert("文件主题不可为空！");
                $("#<%=txtSubject.ClientID %>").focus();
                return false;
            }

            //if($.trim($("#<%=txtFax.ClientID %>").val())=="") {
            //    alert("回复传真不可为空！");
            //    $("#<%=txtFax.ClientID %>").focus();
            //    return false;
            //}

            //if($.trim($("#<%=txtDescribe.ClientID %>").val())=="") {
            //    alert("正文内容不可为空！");
            //    $("#<%=txtDescribe.ClientID %>").focus();
            //     return false;
            //}
            // else if($.trim($("#<%=txtDescribe.ClientID %>").val())=="<br>" || $.trim($("#<%=txtDescribe.ClientID %>").val())=="<BR>") {
            //     try{
            //         for(var e in nicEditors.editors) {  
            //             nicEditors.editors[e].nicInstances[0].saveContent();
            //          }  
            //      }catch(ee)
            //      {
            //      }
            //      alert("正文内容保存不成功，请刷新后重试！");
            //      $("#<%=txtDescribe.ClientID %>").focus();
            //      return false;
            //  }
            //  else {
            //      $("#<%=HiddenField1.ClientID %>").val($("#<%=txtDescribe.ClientID %>").val());
            //  }

            if($.trim($("#<%=txtReceiveDepartment.ClientID %>").val())=="") {
                alert("收文部门不可为空！");
                $("#<%=txtReceiveDepartment.ClientID %>").focus();
                return false;
            }

            var data = "";
            var flag = true, flag2 = true;
            $("#tbDetail tr").each(function(n) {
                if (n != 0 && n != $("#tbDetail tr").size()) {
                    if ($.trim($("#txtDpm" + n).val()) == "总经办") {
                        alert("第" + n + "个后勤审批流程的部门不能为总经办，请填写“董事总经理”。");
                        $("#txtDpm" + n).focus();
                        flag = false;
                    }
                    //if ($.trim($("#txtIDxa" + (3*n + 1)).val()) == "黄轩明") {
                    //    if ($("#txtIDxa" + (3*(n-1) + 1)).val().indexOf("黄瑛") == -1 && $("#txtIDxa" + (3*(n-1) + 2)).val().indexOf("黄瑛") == -1 && $("#txtIDxa" + (3*(n-1) + 3)).val().indexOf("黄瑛") == -1){
                    //        alert("必须经过后勤事务部黄瑛审批后才能到黄生审批。");
                    //        $("#txtIDxa" + (3*n + 1)).focus();
                    //        flag = false;
                    //    }
                    //}
                    if ($.trim($("#txtDpm" + n).val()) == "") {
                        alert("第" + n + "个后勤审批流程的部门名称必须填写。");
                        $("#txtDpm" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtIDxa" + (3*n + 1)).val()) == "") {
                        alert("第" + n + "个后勤审批流程的第一环节必须填写。");
                        $("#txtIDxa" + (3*n + 1)).focus();
                        flag = false;
                    }
                    else if($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none" && $.trim($("#txtIDxa" + (3*n + 2)).val()) == "") 
                    {
                        alert("第" + n + "个后勤审批流程的第二环节必须填写。");
                        $("#txtIDxa" + (3*n + 2)).focus();
                        flag = false;
                    }
                    else if($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none" && $.trim($("#txtIDxa" + (3*n + 3)).val()) == "") 
                    {
                        alert("第" + n + "个后勤审批流程的第三环节必须填写。");
                        $("#txtIDxa" + (3*n + 3)).focus();
                        flag = false;
                    }
                    else
                        data += $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+1).toString()
                            + "&&1"
                            + "&&" + ($("#rdoIsCmodel" + n + "11").prop('checked')?"1":"0")
                            + "&&1||"
                            + $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+2).toString()
                            + "&&2"
                            + "&&" + ($("#rdoIsCmodel" + n + "21").prop('checked')?"1":"0")
                            + "&&" + ($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none"?"1":"0") + "||"
                            + $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+3).toString()
                            + "&&3"
                            + "&&" + ($("#rdoIsCmodel" + n + "31").prop('checked')?"1":"0")
                            + "&&" + ($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none"?"1":"0") + "||";
                }
            });

            
            $.ajax({
                url: "/Ajax/HR_Handler.ashx",
                type: "post",
                dataType: "text",
                async: false,
                cache: false,
                data: 'action=getEmpInfoByEmpName&empname='+$("#<%=txtCanSeeEmp.ClientID %>").val()+'',
                success: function(info) {
                    if (info=="fail") {
                        alert("可见人员中有些人名不存在");
                        flag = false;
                        return false;
                    }else if(info=="success")
                    {
                        $("#<%=hdCanSeeEmpCode.ClientID %>").val("");
                    }
                    else
                    {
                        var objJson=eval("("+info+")");
                        $("#<%=hdCanSeeEmpCode.ClientID %>").val(objJson.empcode);
                    }
                },
                error:function()
                {
                    alert("出错啦！");
                }
            })

        content = "";
        for(var y = 1; y <= $("[id^=txtIDxa]").size(); y++)
        {
            if($("#txtIDxa"+y).parent().css("display")!="none") 
            {
                if(y == 3 && $.trim($("#txtIDxa"+y).val())=="" && isNewApply)
                {
                    alert("第3个审批环节不可为空！");
                    $("#txtIDxa"+y).focus();
                    flag = false;
                    return false;
                }
                else if(y == 3 && $.trim($("#txtIDxa"+y).val())=="" && !isNewApply)
                {
                    deleteidxs += y.toString() + "|";
                    continue;
                }
                    
                if(y <= 2 && $.trim($("#txtIDxa"+y).val())=="")
                {
                    deleteidxs += y.toString() + "|";
                    continue;
                }
                content+=y+":"+$("#txtIDxa"+y).val()+";";
            }
            console.log(y.toString());
            deleteidxs += y.toString() + "|";
               
        }
        content = content.substr(0,content.length-1);
            //if(content.indexOf("黄轩明") != -1 && content.indexOf("黄瑛") == -1 &&!isNewApply){
            //    alert("必须经过后勤事务部黄瑛审批后才能到黄生审批！");
            //    $("#txtIDxa"+y).focus();
            //    flag = false;
            //    return false;
            //}
        if(($.trim($("#txtIDxa1").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa1").val())
                ||($.trim($("#txtIDxa2").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa2").val())
                ||($.trim($("#txtIDxa3").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa3").val())
                )
                flga = 1;

            $("#<%=hdcontent.ClientID %>").val(content);
            $("#<%=hdflga.ClientID %>").val(flga);
            $("#<%=hddeleteidxs.ClientID %>").val(deleteidxs);

            if(flag)
            {
                //$.ajax({
                //    url: "/Ajax/Flow_Handler.ashx",
                //    type: "post",
                //    dataType: "text",
                //    async: false,
                //    cache: false,
                //    data: 'action=SaveCommonTableFlow&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&flga='+flga+'&deleteidxs='+deleteidxs,
                //success: function(info) {
                //    if (info == "success")
                //    {
                //        flag2 = true;
                //        flag = true;
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
                            return true;
                //}
                //else if (info == "NoPower")
                //{
                //    alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                //flag2 = false;
                //return false;
                //        }
                //        else if (info == "Conpleted"){
                //            alert("该表已审批完毕，不能再修改了！");
                //            flag2 = false;
                //            return false;
                //        }
                //        else
                //        {
                //            alert("保存失败，审批流程中有部分人名不存在或不具备审批资格，\\n请修改，如依然失败，请联系资讯科技部！\n错误代码："+ info);
                //            flag2 = false;
                //            return false;
                //        }
                //    }
                //})
                //if (flag2) {
                //    return true;
                //}
                //else
                //    return false;
            }
            else
                return false;
            
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
                    window.location='Apply_GeneralApply_Detail.aspx?MainID=<%=MainID %>';
                }
		
                function CancelSign(idc) {
                    if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
                    {
                        $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
                }

                function ShouldJump(dpt) {
                    if(confirm("跳过后，该部门的审批环节将会被删除，确实要跳过该部门的审批吗？"))  //20141211：ShouldJump
                    {
                        $("#<%=hdShouldJump.ClientID%>").val(dpt);
                        document.getElementById("<%=btnShouldJump.ClientID %>").click();
                    }
                }

                function WillEnd() {
                    if(confirm("该操作将会删除总经办的审批环节，确实结束审批吗？"))  //20141211：WillEnd
                    {
                        document.getElementById("<%=btnWillEndC.ClientID %>").click();
                    }
                }
                function AddNWX() {
                    document.getElementById("<%=lbtnaAddN.ClientID %>").click();
        }
        function DelNWX() {
            document.getElementById("<%=lbtnaDelN.ClientID %>").click();
        }
		
        function sign(idx) {
            //if(idx=='1' || idx=='2' || idx=='3'){
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
                $("#btnSignIDx"+idx).attr("disabled",true);

                if($("#rdbYesIDx"+idx).prop("checked"))
                    $("#<%=hdIsAgree.ClientID %>").val("1");
                        else if($("#rdbNoIDx"+idx).prop("checked"))
                            $("#<%=hdIsAgree.ClientID %>").val("0");
                        else if($("#rdbOtherIDx"+idx).prop("checked"))
                            $("#<%=hdIsAgree.ClientID %>").val("2");
					   
                getSuggestion(idx);


                document.getElementById("<%=btnSign.ClientID %>").click();
                    }else
                    {
                        $("#btnSignIDx"+idx).attr("disabled",false);
                    }


                }  

                function getSuggestion(idx)
                {
                    if(isIE()){
                        $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).text());
            }else
            {
                $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
            }
        }
        function isIE() { //ie?
            if (!!window.ActiveXObject || "ActiveXObject" in window)
                return true;
            else
                return false;
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

        function showOrHideIDx(x) {
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }

        function addRow() {
            i = $("#tbDetail tr").length;
            var html = '<tr id="trDetail' + i + '" class="noborder" style="height: 85px;">'
                +   '<td style="text-align: left; padding-left: 10px;" colspan="4">'
                +   '<div class="flow">'
                +   '部门名称：<input type="text" id="txtDpm' + i + '" style="margin-bottom: 10px;width:250px;" /><br/>'
                +   '<div id="divIDx' + (3*i+1) + '" class="item2">环节1</div>'
                +   '<div id="divTxtIDx' + (3*i+1) + '" class="item2">'
                +   '   <input type="text" id="txtIDxa' + (3*i+1) + '" style="width:190px;" /><input id="hdIDx' + (3*i+1) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '11" checked="checked" name="IsCmodel' + i + '1" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '11">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '10" name="IsCmodel' + i + '1" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '10">单人审批</label>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*i+2) + '" class="item2"><input id="btnIDx' + i + '2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*i+2) + ');" />'
                +   '   <label id="lblIDx' + i + '2" for="btnIDx' + i + '2">环节2</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*i+2) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节2&nbsp;<input type="text" id="txtIDxa' + (3*i+2) + '" style="width:190px;" /><input id="hdIDx' + (3*i+2) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '21" checked="checked" name="IsCmodel' + i + '2" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '21">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '20" name="IsCmodel' + i + '2" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '20">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*i+2) + ')">取消</a>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*i+3) + '" class="item2"><input id="btnIDx' + i + '3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*i+3) + ');" />'
                +   '   <label id="lblIDx' + i + '3" for="btnIDx' + i + '3">环节3</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*i+3) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节3&nbsp;<input type="text" id="txtIDxa' + (3*i+3) + '" style="width:190px;" /><input id="hdIDx' + (3*i+3) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '31" checked="checked" name="IsCmodel' + i + '3" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '31">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '30" name="IsCmodel' + i + '3" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '30">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*i+3) + ')">取消</a>'
                +   '</div></div>'
                +   '</td>'
                + '</tr>'
            //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
            $("#trFlag").before(html);
            $("#txtDpm"+ i).autocomplete({source: jJSON});
            //$("#txtDpm"+ i).blur(function(){ //M_Maybobo：20140415
            //    if($.trim($("#"+this.id).val()) == "人力资源部"){
            //        showIDx(3*$.trim(this.id).replace("txtDpm","")+2*1);
            //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).val("杨梅宝");
            //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).css("background-color","Silver").attr("readonly","readonly");
            //    }
            //    else{
            //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).val("");
            //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).css("background-color","").removeAttr("readonly");
            //    }
            //});

            for(var il =1;il<=3;il++)
            {
                $("#txtIDxa" + (3*i + il))
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
            i++;
            //$("#txtDpm"+ (i - 1)).blur(function(){ //M_GW：20150604
            //    if($("#"+this.id).val().indexOf("董事总经理") != -1
            //        && $("#txtIDxa" + (3*($.trim(this.id).replace("txtDpm","") - 1)+1*1)).val().indexOf("黄瑛") == -1
            //        && $("#txtIDxa" + (3*($.trim(this.id).replace("txtDpm","") - 1)+2*1)).val().indexOf("黄瑛") == -1
            //        && $("#txtIDxa" + (3*($.trim(this.id).replace("txtDpm","") - 1)+3*1)).val().indexOf("黄瑛") == -1
            //        ){
            //        $("#"+this.id).val("后勤事务部");
            //        $("#txtIDxa" + (3*$.trim(this.id).replace("txtDpm","")+1*1)).val("黄瑛");
            //        addRow();
            //        $("#txtDpm"+ (i - 1)).val("董事总经理");
            //        $("#txtIDxa" + (3*(i - 1)+1)).val("黄轩明");
            //    }
            //});
             
        }

        function deleteRow() {
            //i = $("#tbDetail tr").length;
            if (i > 1) {
                i--;
                $("#tbDetail tr:eq(" + (i - 1) + ")").remove();
                //$("#tbAround tr[id*=trDetail]").remove();
            } else
                alert("不可再删除了。");
        }
        function showIDx(x) {
            $("#divIDx" + x).hide();
            $("#divTxtIDx" + x).show();
            return false;
        }
        function showOrHideIDx(x) {//789
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }
        function addFlow() {
            var html = '<tr id="trAddFlow' + jaf + '" class="noborder" style="height: 85px;">'
                +   '<td style="text-align: left; padding-left: 10px;" colspan="4">'
                +   '<div class="flow">'
                +   '部门名称：<input type="text" id="txtDpm' + jaf + '" style="margin-bottom: 10px;width:250px;border: 1px solid #98b8b5;" /><br/>'
                +   '<div id="divIDx' + (3*jaf+1) + '" class="item2">环节1</div>'
                +   '<div id="divTxtIDx' + (3*jaf+1) + '" class="item2">'
                +   '   <input type="text" id="txtIDxa' + (3*jaf+1) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+1) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + jaf + '11" checked="checked" name="IsCmodel' + jaf + '1" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '11">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '10" name="IsCmodel' + jaf + '1" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '10">单人审批</label>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*jaf+2) + '" class="item2"><input id="btnIDx' + jaf + '2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*jaf+2) + ');" />'
                +   '   <label id="lblIDx' + jaf + '2" for="btnIDx' + jaf + '2">环节2</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*jaf+2) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节2&nbsp;<input type="text" id="txtIDxa' + (3*jaf+2) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+2) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + jaf + '21" checked="checked" name="IsCmodel' + jaf + '2" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '21">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '20" name="IsCmodel' + jaf + '2" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '20">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*jaf+2) + ')">取消</a>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*jaf+3) + '" class="item2"><input id="btnIDx' + jaf + '3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*jaf+3) + ');" />'
                +   '   <label id="lblIDx' + jaf + '3" for="btnIDx' + jaf + '3">环节3</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*jaf+3) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节3&nbsp;<input type="text" id="txtIDxa' + (3*jaf+3) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+3) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + jaf + '31" checked="checked" name="IsCmodel' + jaf + '3" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '31">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '30" name="IsCmodel' + jaf + '3" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '30">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*jaf+3) + ')">取消</a>'
                +   '</div></div>'
                +   '</td>'
                + '</tr>'
            //var html = '<tr id="trAddFlow' + jaf + '"><table><tr><td>这是'+ jaf +'个</td></tr></table></tr>'
            $("#trAddFlowBefore").before(html);
            $("#txtDpm"+ jaf).autocomplete({source: jJSON});
            for(var il =1;il<=3;il++)
            {
                $("#txtIDxa" + (3*jaf + il))
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
        }
        function deleteFlow() {
            if (jaf > 200) {
                jaf--;
                $("#tbAddFlows tr:eq(" + (jaf - 200) + ")").remove();
                //$("#tbAround tr[id*=trDetail]").remove();
                if (jaf == 200) {
                    $('#trAddFlowBefore').hide();
                }
            } else{
                $('#trAddFlowBefore').hide();
                alert("不可再删除了。");
            }
        }
        function SaveFlow() {
            $("#<%=btnSaveLogisticsFlow.ClientID%>").hide();
            //$("#<%=btnSaveLogisticsFlow.ClientID%>").attr("disabled","disabled");
            var data = "";
            var flag = true, flag2 = false;
            var content = "";
            for(var k = 200; k < $("#tbAddFlows tr").length + 200-2; k++)
            {
                if ($.trim($("#txtDpm" + k).val()) == "") {
                    alert("您所添加的部门名称不可为空。");
                    $("#txtDpm" + k).focus();
                    return false;
                }
                if ($.trim($("#txtDpm" + k).val()) == "总经办") {
                    alert("总经办无审批权限，请填写“董事总经理”。");
                    $("#txtDpm" + k).focus();
                    return false;
                }
            }
            for(var y = 3*200+1; y <= $("[id^=txtIDxa]").size() + 3*200-3; y++)
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
            }
            $("#tbAddFlows tr").each(function(n) {
                if (n != 0 && n != $("#tbAddFlows tr").size() - 1) {
                    data += $.trim($("#txtDpm" + (n+200-1)).val()) 
                        + "&&" + (3*200+(3*n-2)).toString()
                        + "&&1"
                        + "&&" + ($("#rdoIsCmodel" + (n+200-1) + "11").prop('checked')?"1":"0")
                        + "&&1||"
                        + $.trim($("#txtDpm" + (n+200-1)).val()) 
                        + "&&" + (3*200+(3*n-2)+1).toString()
                        + "&&2"
                        + "&&" + ($("#rdoIsCmodel" + (n+200-1) + "21").prop('checked')?"1":"0")
                        + "&&" + ($("#txtIDxa" + (3*200+(3*n-2) + 1)).parent().css("display")!="none"?"1":"0") + "||"
                        + $.trim($("#txtDpm" + (n+200-1)).val()) 
                        + "&&" + (3*200+(3*n-2)+2).toString()
                        + "&&3"
                        + "&&" + ($("#rdoIsCmodel" + (n+200-1) + "31").prop('checked')?"1":"0")
                        + "&&" + ($("#txtIDxa" + (3*200+(3*n-2) + 2)).parent().css("display")!="none"?"1":"0") + "||";
                }
            });
            if(flag)
            {
                content = content.substr(0,content.length-1);
                $.ajax({
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    async: false,
                    cache: false,
                    data: 'action=SaveCommonFlowLogistics2&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs=<%=SkyPlay %>',
                    success: function(info) {
                        if (info == "success") {
                            flag2 = true;
                            flag = true;
                            data = data.substr(0, data.length - 2);
                            $("#<%=hdLogisticsFlow.ClientID %>").val(data);
                            return true;
                        }
                        else if (info == "NoPower"){
                            flag2 = false;
                            return false;
                        }
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                            flag2 = false;
                            return false;
                        }
                        else
                        {
                            alert("保存失败，审批流程中有部分人名不存在或不具备审批资格，\\n请修改，如依然失败，请联系资讯科技部！\n错误代码："+ info);
                            flag2 = false;
                            return false;
                        }
                    }
                })
                if (flag2) {
                    return true;
                }
                else{
                    //$("#<%=btnSaveLogisticsFlow.ClientID%>").removeAttr("disabled");
                    $("#<%=btnSaveLogisticsFlow.ClientID%>").show();
                    return false;
                }
            }
            //if (flag && flag2) {
            //data = data.substr(0, data.length - 2);
            //$("#<%=hdLogisticsFlow.ClientID %>").val(data);
            //    return true;
            //}
            //else
            //    return false;
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
    </script>
    <script type="text/javascript">

        //var area1 = null;
        //function toggleArea1() {
        //    if(!area1) {
        //        try{
        //            area1 = new nicEditor({
        //                buttonList : ['fontSize','bold','italic','underline','strikeThrough','left','center','right','justify','forecolor','bgcolor']
        //            }).panelInstance('<%=txtDescribe.ClientID %>',{hasPanel : true});
        //        $("#ibta").html("切换普通模式");
        //    }
        //    catch(ee){
        //    }
        //} else {
        //    try{
        //            area1.removeInstance('<%=txtDescribe.ClientID %>');
        //            area1 = null;
        //            $("#ibta").html("切换高级模式");
        //        }
        //        catch(ee){
        //        }
        //    }
        //}
        //bkLib.onDomLoaded(function() {
        //    toggleArea1();
        //    //$("#ctl00_ContentPlaceHolder1_txtDescribe").css({"overflow":"hidden","overflow-x":"auto"});
        //});
    </script>

    <script type="text/javascript" charset="utf-8" src="/editor/kindeditor.js"></script>
    <script type="text/javascript" charset="utf-8" src="/editor/lang/zh_CN.js"></script>
    <script type="text/javascript">
        KindEditor.ready(function(K) {
            editor = K.create('#<%=txtDescribe.ClientID %>', {
            items : [
            'fullscreen', '|',
            'formatblock', 'fontname','fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
            'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', 'table','|', 'undo', 'redo', '|', 'cut', 'copy', 'paste',
            'plainpaste', 'wordpaste', '|', 'source'
            ]
            //    cssPath : '/editor/plugins/code/prettify.css',
            //    uploadJson : '/editor/asp.net/upload_json.ashx',
            //    fileManagerJson : '/editor/asp.net/file_manager_json.ashx',
            //    allowFileManager : true,
            //    afterCreate : function() {
            //        var self = this;
            //        K.ctrl(document, 13, function() {
            //            self.sync();
            //            K('form[name=example]')[0].submit();
            //        });
            //        K.ctrl(self.edit.doc, 13, function() {
            //            self.sync();
            //            K('form[name=example]')[0].submit();
            //        });
            //    }
        });

        //window.editor = K.create('#<%=txtDescribe.ClientID %>');
        KindEditor.options.filterMode = false;

    });
    </script>
    <script type="text/javascript">
        function ChangeConfirm(){
            editor.sync();
            var nowContent=$("#<%=txtApplyID.ClientID %>").val()+
                 $("#<%=txtDepartment.ClientID %>").val()+
                 $("#<%=txtReplyPhone.ClientID %>").val()+
                 $("#<%=txtSubject.ClientID %>").val()+
                 $("#<%=txtFax.ClientID %>").val()+
                 $("#<%=txtDescribe.ClientID %>").val()+
                 $("#<%=txtReceiveDepartment.ClientID %>").val()+
                 $("#<%=txtCCDepartment.ClientID %>").val();
             nowContent=nowContent.replace(/[\r\n]/g,"").replace(/[ ]/g,""); 
             var originalContent=$("#<%=hdChangeChecking.ClientID%>").val().replace(/[\r\n]/g,"").replace(/[ ]/g,""); 
             var notChange =(originalContent==nowContent);
             if(!notChange){
                 if(confirm('请注意，你修改了审批表的内容，所有已审批的环节都必须重审；\r\n确定要修改吗？'))
                 {
                     if($('h1').attr('name') != 'DeleteD')return check();
                     else return alert('该表即将被删除，暂停修改操作');
                 }
                 else return false;
             }
             else
             {
                 if(confirm('请注意，如果你修改审批流程，该流程的后续环节都需要重审；\r\n确定要修改吗？'))
                 {
                     if($('h1').attr('name') != 'DeleteD')return check();
                     else return alert('该表即将被删除，暂停修改操作');
                 }
                 else return false;
             }
             return false;
         }
    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_rdbIsLawE td {
            border: 0;
        }

        .auto-style4 {
            width: 100px;
        }

        .auto-style5 {
            width: 91px;
        }

        .auto-style6 {
            width: 300px;
        }

        .pdl2 {
            margin-left: 5px;
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
            <h1>通用申请表</h1>
            <span style="font-size: 20px; font-weight: bold">通用申请表</span><label id="laIsGroups" runat="server" style="color: red; font-size: 15px;"></label>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
            <table id="tbAround" width='640px'>
                <tr>
                    <td class="auto-style4">收文部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtReceiveDepartment" runat="server" Width="180px"></asp:TextBox></td>
                    <td class="auto-style5">发文编号</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtApplyID" runat="server" Width="170px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">发文部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="180px"></asp:TextBox>&nbsp;-&nbsp;<input type="hidden" id="hdDepartmentID" runat="server" /><asp:Label ID="lblApply" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style5">发文日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style4">抄送部门</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtCCDepartment" runat="server" Width="180px"></asp:TextBox></td>
                    <td class="auto-style5">回复电话</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtReplyPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">文件主题</td>
                    <td class="auto-style6" style="vertical-align: middle">关于<asp:TextBox ID="txtSubject" runat="server" Width="210px" TextMode="MultiLine"></asp:TextBox>的申请</td>
                    <td class="auto-style5">回复传真</td>
                    <td class="tl PL10">
                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox></td>
                </tr>

                <tr id="trcansee">
                    <td class="auto-style4">查阅人</td>
                    <td class="tl PL10" colspan="3">
                        <asp:TextBox ID="txtCanSeeEmp" runat="server" Width="300"></asp:TextBox></td>
                    <asp:HiddenField ID="hdCanSeeEmpCode" runat="server" />
                    <asp:HiddenField ID="hdGroupName" runat="server" />
                </tr>

                <tr>
                    <td colspan="4">
                        <span style="vertical-align: top; text-align: left; margin-top: 10px; font-weight: bold; font-size: 15px;">申请正文</span><br />
                        <br />
                        <div id="GeneralTable" style="padding-left: 0px; text-align: center;">
                            <div style="text-align: left; width: 643px">
                                <%--<a id="ibta" href="javascript:void(0)" onclick="toggleArea1();" style="margin-bottom: 5px; margin-left: 5px;">切换高级模式</a><br />--%>
                                <%-- <asp:TextBox ID="txtDescribe" runat="server" Style="height: 0px;width: 640px;" TextMode="MultiLine" Visible="False"></asp:TextBox>--%>
                                <asp:Panel ID="pnDescribe" runat="server" Style="width: 635px;" ScrollBars="Horizontal" Visible="False" CssClass="pdl2">
                                    <asp:Label ID="lbDescribe" runat="server" CssClass="pdl2" Style="width: 640px;"></asp:Label>
                                </asp:Panel>
                            </div>
                            <asp:TextBox ID="txtDescribe" runat="server" Style="width: 640px; height: 500px;" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <br />
                        <%--<CKEditor:CKEditorControl ID="ckeDescribe" runat="server" Height="500px" Visible="False"></CKEditor:CKEditorControl>--%>
                    </td>
                </tr>

                <tr>
                    <th colspan="4" style="font-size: 15px">申请部门审批流程</th>
                </tr>
                <tr id="trM0" style="display: none;">
                    <td colspan="4" style="height: 80px; text-align: left; padding-left: 10px; line-height: 25px;">
                        <div class="flow">
                            申请人：<input type="text" id="txtIDxa1" style="width: 539px;" /><br />
                            申请部门主管：<input type="text" id="txtIDxa2" style="width: 485px;" /><br />
                            申请部门负责人：<input type="text" id="txtIDxa3" style="width: 467px;" />
                            <asp:HiddenField ID="hdFlowApply" runat="server" />
                        </div>
                    </td>
                </tr>
                <tr id="trManager1" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">申请人</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
                        <textarea id="txtIDx1" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trManager2" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">申请部门主管</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label>
                        <textarea id="txtIDx2" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trManager3" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style4">申请部门负责人</td>
                    <td colspan="3" class="tl PL10">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label>
                        <input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label>
                        <textarea id="txtIDx3" rows="6" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="tho">
                    <th colspan="4" style="font-size: 15px">其它部门审批流程</th>
                </tr>
                <tr id="add1F" style="display: none">
                    <td colspan="4">
                        <table id="tbAddFlows" class='sample tc' width='100%'>

                            <tr id="trAddFlowBefore" style="display: none;">
                                <td>
                                    <asp:Button ID="btnSaveLogisticsFlow" runat="server" Text="" OnClientClick="return SaveFlow();" OnClick="btnSaveLogisticsFlow_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#trAddFlowBefore').show();$('#trM1').remove();addFlow();">增加审批环节</a>
                                    <a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trM1" style="display: none;">
                    <td class="tl PL10 PR10" colspan="4">
                        <table id="tbDetail" class='sample tc' width='100%'>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag">
                                <td></td>
                            </tr>
                        </table>
                        <input type="button" id="btnAddFlow" value="添加新行" onclick="addRow();" style="float: left; display: none" />
                        <input type="button" id="btnDeleteFlow" value="删除一行" onclick="deleteRow();" style="float: left; display: none; margin-left: 10px;" />
                    </td>
                </tr>
                <%=SbHtml2.ToString()%>

                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style3">申请人回复审批意见<br />
                        （可选项）</td>
                    <td colspan="3" class="tl PL10" style="">
                        <textarea id="txtIDx20000" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx20000" runat="server" OnClick="btnSignIDx20000_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx20000">_________</span></div>
                    </td>
                </tr>

                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
                    <td class="auto-style3">董事总经理复审</td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb22000a1" runat="server" Text="同意" GroupName="22000a" />
                        <asp:RadioButton ID="rdb22000a2" runat="server" Text="不同意" GroupName="22000a" />
                        <asp:RadioButton ID="rdb22000a3" runat="server" Text="其它意见" GroupName="22000a" ForeColor="#008162" />
                        <textarea id="txtIDx22000" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx22000" runat="server" OnClick="btnSignIDx22000_Click" Text="确认" Visible="False" />
                        <br />
                        <div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx22000">_________</span></div>
                    </td>
                </tr>

            </table>
            <!--打印正文结束-->
        </div>

        <div class="noprint">
            <asp:GridView ID="gvAttach" CssClass="gvAttach" runat="server" BackColor="White" Style="clear: both; margin-top: 3px;"
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

                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnTemp" Text="暂时保存" OnClick="btnTempSave_Click" CssClass="commonbtn" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" OnClientClick="return ChangeConfirm();" OnClick="btnSAlterC_Click" Visible="False" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />

                <%--<asp:HiddenField ID="hdidx" runat="server" />--%>

                <input type="hidden" id="hdDetail" runat="server" />
                <input type="hidden" id="hdLogisticsFlow" runat="server" />
                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:HiddenField ID="hdChangeChecking" runat="server" />
                <asp:HiddenField ID="HiddenField1" runat="server" />

                <asp:HiddenField ID="hdcontent" runat="server" />
                <asp:HiddenField ID="hdflga" runat="server" />
                <asp:HiddenField ID="hddeleteidxs" runat="server" />

                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdShouldJump" runat="server" />
                <asp:Button ID="btnShouldJump" runat="server" OnClick="btnShouldJump_Click" Style="display: none;" />
                <asp:Button ID="btnWillEndC" runat="server" OnClick="btnWillEndC_Click" Style="display: none;" />
                <asp:LinkButton ID="lbtnaAddN" runat="server" OnClick="lbtnAddN_Click" Style="display: none;">添加审批</asp:LinkButton>
                <asp:LinkButton ID="lbtnaDelN" runat="server" OnClick="lbtnDelN_Click" Style="display: none;">删除审批</asp:LinkButton>
            </div>
        </div>
    </div>

    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        autoTextarea(document.getElementById("txtIDx1"));
        autoTextarea(document.getElementById("txtIDx2"));
        autoTextarea(document.getElementById("txtIDx3"));
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        window.onload= function(){
            // $(".ke-zeroborder").css("width","720pt");
            $("input[id*=btnSignID]").each(function () {
                var IsSigndisplay = $(this).css("display");
                if(IsSigndisplay != "undefined" && IsSigndisplay !='none')
                {
                    var content =''
                    if($(this).parent().prev().text() == "集团意见")
                    {
                        content =' <input name="btnCancelGroups" type="button" class="cssCancelGroups"    onclick="CancelGroups()" />';
                    }
                    else
                    {
                        content =' <input name="btnAddGroups" type="button" class="cssAddGroups"    onclick="AddGroups()" />';
                    }
                    if($(this).parent().prev().text() == "申请人")
                    {
                        $(this).prev().prev().prev().append(content);
                    }
                   
                    $(this).prev().prev().append(content);
                }
            })
            $("input[id*=btnSignID]").each(function () {
                if($(this).parent().prev().text() == "集团意见")
                {
                    var GroupName = $("#<%=hdGroupName.ClientID%>").val();
                    content =' <label style="color:black">'+GroupName+'</label>';
                    $(this).prev().prev().append(content);
                }
            })
        }
    </script>
</asp:Content>

