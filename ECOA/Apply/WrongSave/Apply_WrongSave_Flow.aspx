<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_WrongSave_Flow.aspx.cs" Inherits="Apply_WrongSave_Apply_WrongSave_Flow" Title="流程编辑 - 广州中原电子审批系统" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<!DOCTYPE html>

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
        
        .flow .item
        {
            display:inline; 
            width:110px; 
            height:25px; 
            padding:7px 2px 7px 5px; 
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
            max-height: 130px;
            overflow-y: auto;
            overflow-x: hidden;
          }
          
          label
          {
              cursor:pointer;
          }
          
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
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>;
        
        $(function() {
            function split( val ) {
                return val.split( /,\s*/ );
            }
            function extractLast( term ) {
                return split( term ).pop();
            }

            for(var i =1;i<=4;i++)
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

        function showOrHideIDx(x) {
            $("#btnSave2").removeAttr("disabled");
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }

        function save() {
            var content = "";
            var x = 0;
            
            for(var y = 1; y <= 4; y++)
            {
                if($("#txtIDx"+y).parent().css("display")!="none") 
                {
                    if($.trim($("#txtIDx"+y).val())=="")
                    {
                        alert("环节不可为空！");
                        $("#btnSave2").removeAttr("disabled");
                        $("#txtIDx"+y).focus();
                        return false;
                    }
                    x ++;
                    content+=y+":"+$("#txtIDx"+y).val()+";";
                }
            }
            
            if(x < 1) {
                alert("请确保流程中三个环节至少有一个环节启用，\\n否则该申请将无效！");
                return false;
            }
            
            content = content.substr(0,content.length-1);
        
            $.ajax({
                url: "/Ajax/Flow_Handler.ashx",
                type: "post",
                dataType: "text",
                data: 'action=saveCommonFlow2&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs=1|2|3|4',
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
                    {
                        alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                        
                    }
                    $("#btnSave2").removeAttr("disabled");
                }
            })
        }

    window.onbeforeunload =  function (){
        if($.trim($("#txtIDx1").val())=="" && $.trim($("#txtIDx2").val())=="" && $.trim($("#txtIDx3").val())=="" && $.trim($("#txtIDx4").val())=="")
            return '请确保流程中三个环节至少有一个环节启用，\\n否则该申请将无效！';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="flow">
            申请部门内部审批流程(多人同时审批模式):<br /><br />
            <div id="divIDx1" class='item'><input id="Image3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(1);" />
                <label id="lblIDx1" for='btnIDx0'>填表人(行政助理)</label>
            </div>
            <div id="divTxtIDx1" class='item' style="display:none;">
                    <input type="text" id="txtIDx1" style="width:200px;" /><input id="hdIDx1" type="hidden" />
                    <a href="javascript:;" onclick="showOrHideIDx(1)">取消</a>
            </div>
            <img src="/Images/forward.png" class="forward"/>

            <div id="divIDx2" class='item'><input id="Image2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(2);" />
                <label id="lblIDx2" for='btnIDx0'>主管</label>
            </div>
            <div id="divTxtIDx2" class='item' style="display:none;">
                    <input type="text" id="txtIDx2" style="width:200px;" /><input id="hdIDx2" type="hidden" />
                    <a href="javascript:;" onclick="showOrHideIDx(2)">取消</a>
            </div>
            <img src="/Images/forward.png" class="forward"/>
            <br /><br /><br />

            <div id="divIDx3" class='item'><input id="Image1" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(3);" />
                <label id="lblIDx3" for='btnIDx0'>总监</label>
            </div>
            <div id="divTxtIDx3" class='item' style="display:none;">
                    <input type="text" id="txtIDx3" style="width:200px;" /><input id="hdIDx3" type="hidden" />
                    <a href="javascript:;" onclick="showOrHideIDx(3)">取消</a>
            </div>

            <img src="/Images/forward.png" class="forward"/>
            <div id="divIDx4" class='item'><input id="btnIDx0" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(4);" />
                <label id="lblIDx4" for='btnIDx0'>行政主任</label>
            </div>
            <div id="divTxtIDx4" class='item' style="display:none;">
                    <input type="text" id="txtIDx4" style="width:200px;" /><input id="hdIDx4" type="hidden" />
                    <a href="javascript:;" onclick="showOrHideIDx(4)">取消</a>
            </div>
            <br /><br />

<%--            <div id="divIDx5" class='item'>总监</div>
            <div id="divTxtIDx5" class='item'>
                <input type="text" id="txtIDx5" style="width:200px;" /><input id="hdIDx5" type="hidden" />
            </div>
            <br /><br />--%>

            <input type="button" id="btnSave2" value="保存并通知审批" onclick="save();this.disabled ='disabled'" class="btn button"/>
        </div>
    </div>
    </form>
    <%=SbJs.ToString() %>
</body>
</html>

