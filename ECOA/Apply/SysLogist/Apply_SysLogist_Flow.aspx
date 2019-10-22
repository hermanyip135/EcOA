<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_SysLogist_Flow.aspx.cs" Inherits="Apply_SysLogist_Apply_SysLogist_Flow" Title="流程编辑 - 广州中原电子审批系统" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/Script/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Script/jquery-ui-1.10.1.custom.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui.datepicker-zh-CN.js"></script>
    <link rel="Stylesheet" href="/Style/DotLuv/jquery-ui-1.10.1.custom.css" />
    <link rel="Stylesheet" href="/Style/style.css" />
    <script src="/Script/jquery.backgroundpos.js" type="text/javascript"></script>
    <script src="/Script/menu.js" type="text/javascript"></script>
    <style type="text/css">   
        .flow
        {
            margin:30px auto; 
            width:700px;
            font-size:18px;
        }
        
        .flow .item
        {
            display:inline; 
            width:110px; 
            height:25px; 
            padding:7px 2px 7px 5px; 
            /*background-color:#E3E1BF;*/
        }   

        .flow .forward
        {
             vertical-align: -2px;
        }
        
        .flow input[type="text"]
        {
             width:100px; 
             font-size:18px;
        }
        
        .ui-autocomplete {
            max-height: 350px;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
          }
          
          label
          {
              cursor:pointer;
          }
    </style>
    <script type="text/javascript">
        var jJSON = <%=sbJSON.ToString() %>;
        var jDepartmentJSON = <%=SbDepartmentJson.ToString() %>;

        $(function() {

            function split( val ) {
              return val.split( /,\s*/ );
            }
            function extractLast( term ) {
              return split( term ).pop();
            }
            for(var i =1;i<=2;i++) {
                $("#txtIDx" + i)
                    // don't navigate away from the field on tab when selecting an item
                    .bind( "keydown", function( event ) {
                        if ( event.keyCode === $.ui.keyCode.TAB && $( this ).data( "ui-autocomplete" ).menu.active ) {
                            event.preventDefault();
                        }
                    })
                    .autocomplete({
                        minLength: 0,
                        source: function( request, response ) {
                            // delegate back to autocomplete, but extract the last term
                            response( $.ui.autocomplete.filter(jJSON, extractLast( request.term ) ) );
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
        });

        function showOrHideIDx(x) {
            $("#btnSave2").removeAttr("disabled");
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }

        //function hideAll() {
        //    for(var x=1;x<=2;x++){
        //        $("#divIDx" + x).show();
        //        $("#divTxtIDx" + x).hide();
        //    }
        //}
        
        function save() {        
            var content="";
            var x = 0;
            if($("#txtIDx1").parent().css("display")!="none") {
                if($.trim($("#txtIDx1").val())=="") {
                    alert("环节不可为空！");
                    $("#txtIDx1").focus();
                    return false;
                }
                else
                    content="1:"+$.trim($("#txtIDx1").val());
                x ++;
            }
            
            if($("#txtIDx2").parent().css("display")!="none") {
                if($.trim($("#txtIDx2").val())=="") {
                    alert("部门负责人不可为空！");
                    $("#txtIDx2").focus();
                    return false;
                }
                else {
                    if(content!="")
                        content+=";";
                
                    content+="2:"+$.trim($("#txtIDx2").val());  
                }
                x ++;
            }
            if(x < 1) {
                
                alert("部门主管和部门负责人这两个环节必须有一个要开启。");
                return false;
            }

            $.ajax({
                url: "/Ajax/Flow_Handler.ashx",
                type: "post",
                dataType: "text",
                //data: 'action=saveSysReqFlow&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content,
                data: 'action=saveCommonFlow2&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs=1|2',
                success: function(info) {
                    if (info == "success") {
                        alert('流程编辑成功!');
                        window.returnValue='success';
                        window.close();
                    }
                    else if (info == "NoPower")
                        alert("未开通编辑修改权限。");
                    else if (info == "Conpleted"){
                        alert("该表已审批完毕，不能再修改了！");
                        window.returnValue='success';
                        window.close();
                    }
                    else
                        alert("保存失败，部分人名不存在或不具备审批资格，\n请修改，如依然失败，请联系资讯科技部！\n错误代码："+ info);
                }
            })
        }
    </script>
    <style type="text/css">
        .button {
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="flow">
            审批流程:
            <div id="divIDx1" class='item'>
                <input id="btnIDx1" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(1);" />
                <label id="lblIDx1" for='btnIDx1'>环节</label>
            </div>
            <div id="divTxtIDx1" class='item' style="display:none;">
                <input type="text" id="txtIDx1" style="width:230px;" /><input id="hdIDx1" type="hidden" />
                <a href="javascript:;" onclick="showOrHideIDx(1)">取消</a>
            </div>
            <img src="/Images/forward.png" class="forward"/>

            <div id="divIDx2" class='item'>部门负责人
            <div id="divTxtIDx2" class='item'>
                <input type="text" id="txtIDx2" style="width:100px; background-color:Silver;"/>
                <input id="hdIDx2" type="hidden" />
            </div>
            </div>
<%--            <div id="divIDx2" class='item'>
                <input id="btnIDx2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(2);" />
                <label id="lblIDx2" for='btnIDx2'>环节</label>
            </div>
            <div id="divTxtIDx2" class='item' style="display:none;">
                <input type="text" id="txtIDx2" style="width:230px;"/><input id="hdIDx2" type="hidden" />
                <a href="javascript:;" onclick="showOrHideIDx(2)">取消</a>
            </div>--%>
            <img src="/Images/forward.png" class="forward"/>

            <input type="text" id="txtIDx3" style="background-color:Gray; color:#eeeeee; width:230px;" readonly="readonly" value="资讯科技部" />
            <br /><br /><input type="button" id="btnSave2" value="保存并通知审批" onclick="save();this.disabled ='disabled'" class="btn button"/>
        </div>
    </div>
    </form>
    <%=sbJS.ToString() %>
</body>
</html>
