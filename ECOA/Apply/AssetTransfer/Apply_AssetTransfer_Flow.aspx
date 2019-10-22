<%@ Page Title="流程编辑 - 广州中原电子审批系统" Language="C#" AutoEventWireup="true" CodeFile="Apply_AssetTransfer_Flow.aspx.cs" Inherits="Apply_AssetTransfer_Apply_AssetTransfer_Flow" %>

<!DOCTYPE html>

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
        var jJSON = <%=sbJSON.ToString() %>;
        var jDepartmentJSON = <%=sbDepartmentJSON.ToString() %>;
        
        $(function() {
            function split( val ) {
                return val.split( /,\s*/ );
            }
            function extractLast( term ) {
                return split( term ).pop();
            }
            
            for(var i =2;i<=7;i++)
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
                            response( $.ui.autocomplete.filter(jJSON, extractLast( request.term ) ) );
                        },
                        focus: function() {
                            return false;
                        },
                        select: function( event, ui ) {
                            var terms = split( this.value );
                            terms.pop();
                            terms.push( ui.item.value );
                            terms.push( "" );
                            this.value = terms.join( "," );
                            return false;
                        }
                    });
            }

            $("#txtDepartment1").autocomplete({ 
                source: jDepartmentJSON,
                select:function(event,ui){
                    $.ajax({
                        url: "/Ajax/HR_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=getHRTreeByDepartmentID&departmentid=' + ui.item.id,
                        success: function(info) {
                            if (info == "fail") 
                                alert("保存失败，部分人名不存在或不具备审批资格，\n请修改，如依然失败，请联系资讯科技部！");
                            else
                            {
                                var unitids=info.split("|")[0].split(",");
                                var units=info.split("|")[1].split(",");

                                if(units.length>0)
                                {
                                    hideAll1();
                                    $("#txtIDx6").val(units[0]);

                                    switch(units.length)
                                    {
                                        case 2:
                                            $("#txtIDx2").val(units[1]);
                                            showOrHideIDx(2);
                                            break;
                                        case 3:
                                            $("#txtIDx2").val(units[2]);
                                            showOrHideIDx(2);
                                            $("#txtIDx3").val(units[1]);
                                            showOrHideIDx(3);
                                            break;
                                        case 4:
                                            $("#txtIDx2").val(units[3]);
                                            showOrHideIDx(2);
                                            $("#txtIDx3").val(units[1]+","+units[2]);
                                            showOrHideIDx(3);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    })
                }
            });

            $("#txtDepartment2").autocomplete({ 
                source: jDepartmentJSON,
                select:function(event,ui){
                    $.ajax({
                        url: "/Ajax/HR_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=getHRTreeByDepartmentID&departmentid=' + ui.item.id,
                        success: function(info) {
                            if (info == "fail") 
                                alert("保存失败，部分人名不存在或不具备审批资格，\n请修改，如依然失败，请联系资讯科技部！");
                            else
                            {
                                var unitids=info.split("|")[0].split(",");
                                var units=info.split("|")[1].split(",");

                                if(units.length>0)
                                {
                                    hideAll2();
                                    $("#txtIDx7").val(units[0]);

                                    switch(units.length)
                                    {
                                        case 2:
                                            $("#txtIDx4").val(units[1]);
                                            showOrHideIDx(4);
                                            break;
                                        case 3:
                                            $("#txtIDx4").val(units[2]);
                                            showOrHideIDx(4);
                                            $("#txtIDx5").val(units[1]);
                                            showOrHideIDx(5);
                                            break;
                                        case 4:
                                            $("#txtIDx4").val(units[3]);
                                            showOrHideIDx(4);
                                            $("#txtIDx5").val(units[1]+","+units[2]);
                                            showOrHideIDx(5);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    })
                }
            });
        });
        
        function showOrHideIDx(x) {
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }
        
        function hideAll1() {
            for(var x=2;x<=3;x++){
                $("#divIDx" + x).show();
                $("#divTxtIDx" + x).hide();
            }
        }

        function hideAll2() {
            for(var x=4;x<=5;x++){
                $("#divIDx" + x).show();
                $("#divTxtIDx" + x).hide();
            }
        }

        function save() {
            var content = "";
            var exflag = false;
            var imflag = false;
            for(var y = 2; y <= 4; y++)
            {
                y=y==4?6:y;

                if($("#txtIDx"+y).parent().css("display")!="none") {
                    if($.trim($("#txtIDx"+y).val())=="")
                    {
                        alert("环节不可为空！");
                        $("#txtIDx"+y).focus();
                        return false;
                    }
                    
                    content+=y+":"+$("#txtIDx"+y).val()+";";
                    exflag = true;
                }
            }
            
            for(var y = 4; y <= 6; y++)
            {
                y=y==6?7:y;

                if($("#txtIDx"+y).parent().css("display")!="none") {
                    if($.trim($("#txtIDx"+y).val())=="")
                    {
                        alert("环节不可为空！");
                        $("#txtIDx"+y).focus();
                        return false;
                    }
                    
                    content+=y+":"+$("#txtIDx"+y).val()+";";
                    imflag = true;
                }
            }

            if(!exflag) {
                alert("此调出流程三个环节必须有一个环节开启。");
                return false;
            }

            if(!imflag) {
                alert("此接收流程三个环节必须有一个环节开启。");
                return false;
            }
            
            content = content.substr(0,content.length-1);
        
            $.ajax({
                url: "/Ajax/Flow_Handler.ashx",
                type: "post",
                dataType: "text",
                data: 'action=saveAssetTransferFlow&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content,
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

        window.onbeforeunload =  function (){
            if($.trim($("#txtIDx2").val())==""&&$.trim($("#txtIDx3").val())==""&&$.trim($("#txtIDx6").val())=="")
                return '<%=CommonConst.MSG_FLOW_ISCLOSING %>';   

            if($.trim($("#txtIDx4").val())==""&&$.trim($("#txtIDx5").val())==""&&$.trim($("#txtIDx7").val())=="")
                return '<%=CommonConst.MSG_FLOW_ISCLOSING %>';   
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="flow">
                调出部门内部审批流程(多人同时审批模式):<br />
                参照部门或组别：<input type="text" id="txtDepartment1" style="width:200px;" /><br /><br />
                <div id="divIDx2" class='item'><input id="btnIDx2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(2);" /><label id="lblIDx2" for='btnIDx2'>部门主管</label></div><div id="divTxtIDx2" class='item' style="display:none;"><input type="text" id="txtIDx2" style="width:200px;" /><input id="hdIDx2" type="hidden" /><a href="javascript:;" onclick="showOrHideIDx(2)">取消</a></div><img src="/Images/forward.png" class="forward"/>
                <div id="divIDx3" class='item'><input id="btnIDx3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(3);" /><label id="lblIDx3" for='btnIDx3'>隶属主管</label></div><div id="divTxtIDx3" class='item' style="display:none;"><input type="text" id="txtIDx3" style="width:150px;" /><input id="hdIDx3" type="hidden" /><a href="javascript:;" onclick="showOrHideIDx(3)">取消</a></div><img src="/Images/forward.png" class="forward"/>
                <div id="divTxtIDx6" class='item'>部门负责人<input type="text" id="txtIDx6" style="width:100px;" /><input id="hdIDx6" type="hidden" /></div>
                <br /><br />
                接收部门内部审批流程(多人同时审批模式):<br />
                参照部门或组别：<input type="text" id="txtDepartment2" style="width:200px;" /><br /><br />
                <div id="divIDx4" class='item'><input id="btnIDx4" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(4);" /><label id="lblIDx4" for='btnIDx4'>部门主管</label></div><div id="divTxtIDx4" class='item' style="display:none;"><input type="text" id="txtIDx4" style="width:200px;" /><input id="hdIDx4" type="hidden" /><a href="javascript:;" onclick="showOrHideIDx(4)">取消</a></div><img src="/Images/forward.png" class="forward"/>
                <div id="divIDx5" class='item'><input id="btnIDx5" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(5);" /><label id="lblIDx5" for='btnIDx5'>隶属主管</label></div><div id="divTxtIDx5" class='item' style="display:none;"><input type="text" id="txtIDx5" style="width:150px;" /><input id="hdIDx5" type="hidden" /><a href="javascript:;" onclick="showOrHideIDx(5)">取消</a></div><img src="/Images/forward.png" class="forward"/>
                <div id="divTxtIDx7" class='item'>部门负责人<input type="text" id="txtIDx7" style="width:100px;" /><input id="hdIDx7" type="hidden" /></div>
                <br /><br />
                <input type="button" id="btnSave2" value="保存并通知审批" onclick="save();this.disabled ='disabled'" class="btn button"/>
            </div>
        </div>
    </form>
    <%=sbJS.ToString() %>
</body>
</html>

