<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_ProjAgentClause_Flow.aspx.cs" Inherits="Apply_ProjAgentClause_Apply_ProjAgentClause_Flow" Title="流程编辑 - 广州中原电子审批系统" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
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
        
        $(function() {
            function split( val ) {
                return val.split( /,\s*/ );
            }
            function extractLast( term ) {
                return split( term ).pop();
            }

            for(var i =1;i<=2;i++)
            {
                $("#txtIDx" + i)
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

        function save() {
            var content = "";
            var flag = false;
            
            for(var y = 1; y <= 2; y++)
            {
                if($("#txtIDx"+y).parent().css("display")!="none") {
                    if($.trim($("#txtIDx"+y).val())=="")
                    {
                        alert("环节不可为空！");
                        $("#txtIDx"+y).focus();
                        return false;
                    }
                    
                    content+=y+":"+$("#txtIDx"+y).val()+";";
                    flag = true;
                }
            }
            
            if(!flag) {
                alert("此流程两个环节必须有一个环节开启。");
                return false;
            }
            
            content = content.substr(0,content.length-1);
        
            $.ajax({
                url: "/Ajax/Flow_Handler.ashx",
                type: "post",
                dataType: "text",
                data: 'action=saveCommonFlow&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs=1|2',
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
            if($.trim($("#txtIDx1").val())=="" && $.trim($("#txtIDx2").val())=="")
                return '<%=CommonConst.MSG_FLOW_ISCLOSING %>';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="flow">
            申请部门内部审批流程(多人同时审批模式):<br /><br />
            <div id="divIDx1" class='item'>申请人</div><div id="divTxtIDx1" class='item'><input type="text" id="txtIDx1" style="width:200px;" /><input id="hdIDx1" type="hidden" /></div><img src="/Images/forward.png" class="forward"/>
            <div id="divIDx2" class='item'>部门负责人</div><div id="divTxtIDx2" class='item'><input type="text" id="txtIDx2" style="width:200px;" /><input id="hdIDx2" type="hidden" /></div>
            <br /><br />
            <input type="button" id="btnSave2" value="保存并通知审批" onclick="save();this.disabled ='disabled'" class="btn button"/>
        </div>
    </div>
    </form>
    <%=SbJs.ToString() %>
</body>
</html>
