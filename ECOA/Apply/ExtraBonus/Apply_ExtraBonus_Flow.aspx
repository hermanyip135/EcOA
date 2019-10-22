<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_ExtraBonus_Flow.aspx.cs" Inherits="Apply_ExtraBonus_Apply_ExtraBonus_Flow" Title="流程编辑 - 广州中原电子审批系统" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"> 
    <title></title>
    <script type="text/javascript" src="/Script/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Script/jquery-ui-1.10.1.custom.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui.datepicker-zh-CN.js"></script>
    <link rel="Stylesheet" href="/Style/DotLuv/jquery-ui-1.10.1.custom.css" />
    <link rel="Stylesheet" href="/Style/style.css" />
    <style type="text/css">   
        .flow
        {
            margin:30px auto; 
            width:700px;
            font-size:18px;
        }

        .flow input[type="text"]
        {
             width:100px; 
             font-size:18px;
        }
        
        label
        {
            cursor:pointer;
        }
          
        .button 
        {
	        display: block;
	        width: 175px;
	        min-width: 175px;
	        height: 41px;
	        line-height: 38px;
	        font-family: BryantRegular;
	        font-size: 18px;
	        -webkit-border-radius: 0px;
	        -moz-border-radius: 0px;
	        margin: 0 auto;
	        -moz-box-shadow: none;
	        -webkit-box-shadow: none;
	        cursor:pointer;
        }
        .btn 
        {
            min-width:150px;
	        width:auto;
	        padding: 0px 10px 0px 10px;
	        float:left;
	        margin-left:5px;
        }
    </style>
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>;
        var jDepartmentJSON = <%=SbDepartmentJson.ToString() %>;

        function save() {
            if(!confirm('该流程保存后不能再编辑，确定要保存吗？'))
                return;
            var content = "";
            var flag = false;
    
            for(var y = 1; y <= 3; y++)
            {
                if(y!=2){
                    if($.trim($("#txtIDx"+y).val())=="")
                    {
                        alert("环节不可为空！");
                        $("#txtIDx"+y).focus();
                        return false;
                    }

                    content+=y+":"+$("#txtIDx"+y).val()+";";
                }

                if(y==2&&$.trim($("#txtIDx"+y).val())!="")
                    content+=y+":"+$("#txtIDx"+y).val()+";";

                flag = true;
            }





            //for(var y = 1; y <= 3; y++)
            //{
            //    if($("#txtIDx"+y).parent().css("display")!="none") {
            //        if($.trim($("#txtIDx"+y).val())=="")
            //        {
            //            alert("环节不可为空！");
            //            $("#txtIDx"+y).focus();
            //            return false;
            //        }
                    
            //        content+=y+":"+$("#txtIDx"+y).val()+";";
            //        flag = true;
            //    }
            //}



            
            
            if(!flag) {
                alert("此流程必须填写不能为空");
                return false;
            }
            
            content = content.substr(0,content.length-1);
        
            $.ajax({
                url: "/Ajax/Flow_Handler.ashx",
                type: "post",
                dataType: "text",
                data: 'action=saveCommonFlow&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs=1|2|3',
                success: function(info) {
                    if (info == "success") {
                        alert('<%=CommonConst.MSG_FLOW_SUCCESSSAVE%>');
                        window.returnValue='success';
                        window.close();
                    }
                    else if (info == "NoPower")
                        alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                    else if (info == "Conpleted"){
                        alert("该表已审批完毕，不能再修改了！");
                        window.returnValue='success';
                        window.close();
                    }
                    else
                        alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                }
            })
    }

    window.onbeforeunload =  function (){
        if($.trim($("#txtIDx1").val())=="" || $.trim($("#txtIDx3").val())=="")
            return '此流程第1同第3环节必须填写不能为空，否则申请将作废！';   
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="flow">
            申请部门内部审批流程(多人同时审批模式):<br />
            <%--参照部门或组别：<input type="text" id="txtDepartment" style="width:200px;" /><br /><br />--%>
            <%--<div id="divIDx1" class='item'><input id="btnIDx1" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(1);" /><label id="lblIDx1" for='btnIDx1'>部门负责人</label></div><div id="divTxtIDx1" class='item' style="display:none;"><input type="text" id="txtIDx1" style="width:200px;" /><input id="hdIDx1" type="hidden" /></div>--%>
            <div id="divIDx1" class='item'>申请人</div><div id="divTxtIDx1" class='item'><input type="text" id="txtIDx1" style="width:200px;" /><input id="hdIDx1" type="hidden" /></div><img src="/Images/forward.png" class="forward"/>
            <div id="divIDx2" class='item'>部门负责人</div><div id="divTxtIDx2" class='item'><input type="text" id="txtIDx2" style="width:200px;" /><input id="hdIDx2" type="hidden" /></div>
            <br /><img src="/Images/forward.png" class="forward"/><div id="divIDx3" class='item'>二级市场负责人（项目部）或三级市场负责人（物业部）</div><div id="divTxtIDx3" class='item'><input type="text" id="txtIDx3" style="width:200px;" /><input id="hdIDx3" type="hidden" /></div>
            <br /><br />
            <input type="button" id="btnSave2" value="保存并通知审批" onclick="save();this.disabled ='disabled'" class="btn button"/>
        </div>
    </div>
    </form>
    <%=SbJs.ToString() %>
</body>
</html>