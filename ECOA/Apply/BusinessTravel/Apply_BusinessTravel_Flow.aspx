<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_BusinessTravel_Flow.aspx.cs" Inherits="Apply_BusinessTravel_Apply_BusinessTravel_Flow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        
        $(function() {
            function split( val ) {
                return val.split( /,\s*/ );
            }
            function extractLast( term ) {
                return split( term ).pop();
            }
            for(var i =3;i<=4;i++) {
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
        
        function save() {        
            var content="";
            var deleteidxs=3+"|"+4+"|";
            var x = 0;
            
            if($("#txtIDx3").parent().css("display")!="none") {
                if($.trim($("#txtIDx3").val())=="") {
                    alert("项目一部总经理不可为空！");
                    $("#txtIDx3").focus();
                    return false;
                }
                else
                    content="3:"+$.trim($("#txtIDx3").val());
             
                x ++;
            }
            if($("#txtIDx4").parent().css("display")!="none") {
                if($.trim($("#txtIDx4").val())=="") {
                    alert("营销总监不可为空！");
                    $("#txtIDx2").focus();
                    return false;
                }
                else {
                    if(content!="")
                        content+=";";
                 
                    content+="4:"+$.trim($("#txtIDx4").val());  
                }
                x ++;
            }
            if(x < 1) {
                
                alert("总监和部门负责人这两个环节必须有一个要开启。");
                return false;
            }

            $.ajax({
                url: "/Ajax/Flow_Handler.ashx",
                type: "post",
                dataType: "text",
                data: 'action=saveCommonFlow&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs='+deleteidxs,
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
            <%--<div id="divIDx1" class='item'>
                <input id="btnIDx1" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(1);" />
                <label id="lblIDx1" for='btnIDx1'>环节</label>
            </div>
            <div id="divTxtIDx1" class='item' style="display:none;">
                <input type="text" id="txtIDx1" style="width:230px;" /><input id="hdIDx1" type="hidden" />
                <a href="javascript:;" onclick="showOrHideIDx(1)">取消</a>
            </div>
            <img src="/Images/forward.png" class="forward"/>--%>

           

                <div id="divIDx3" class='item'>营销总监
                <input id="btnIDx3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(3);" />
                <label id="lblIDx3" for='btnIDx3'>环节</label>
            </div>
            <div id="divTxtIDx3" class='item' style="display:none;">
                <input type="text" id="txtIDx3" style="width:230px;" /><input id="hdIDx3" type="hidden" />
                <a href="javascript:;" onclick="showOrHideIDx(3)">取消</a>
            </div>
            <img src="/Images/forward.png" class="forward"/>
             <div id="divIDx4" class='item'>项目一部总经理
                <input id="btnIDx4" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(4);" />
                <label id="lblIDx4" for='btnIDx4'>环节</label>
            </div>
            <div id="divTxtIDx4" class='item' style="display:none;">
                <input type="text" id="txtIDx4" style="width:230px;"/><input id="hdIDx4" type="hidden" />
                <a href="javascript:;" onclick="showOrHideIDx(4)">取消</a>
            </div>
            <img src="/Images/forward.png" class="forward"/>
            <br /><input type="button" id="btnSave2" value="保存并通知审批" onclick="save();this.disabled ='disabled'" class="btn button"/>
        </div>
    </div>
    </form>
    <%=sbJS.ToString() %>
</body>
</html>

