<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_SpecialCase_Flow.aspx.cs" Inherits="Apply_SpecialCase_Apply_SpecialCase_Flow" Title="流程编辑 - 广州中原电子审批系统" %>

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
        var jDepartmentJSON = <%=SbDepartmentJson.ToString() %>;
        var did = '<%=did.ToString() %>';
        var flod = '<%=flod.ToString() %>';
        
        $(function() {
            if(did != ""){
                $.ajax({
                    url: "/Ajax/HR_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=getHRTreeByDepartmentID&departmentid=' + did,
                    success: function(info) {
                        if (info == "fail") 
                            alert("保存失败，部分人名不存在或不具备审批资格，\n请修改，如依然失败，请联系资讯科技部！");
                        else
                        {
                            var unitids=info.split("|")[0].split(",");
                            var units=info.split("|")[1].split(",");
                            var dpm=info.split("|")[2];

                            if(units.length>0) // && dpm.indexOf("0000") == -1
                            {
                                $("#txtIDx1").val('<%=EmployeeName %>');
                                $("#ddl2").hide();
                                $("#ddl3").hide();
                                $("#ddl4").hide();
                                if(dpm.indexOf("分行主管") != -1){
                                    $("#txtIDx2").val(units[1]);
                                    $("#ddl2").show();
                                }
                                if(dpm.indexOf("区域总监") != -1  && flod.indexOf("4") != -1){
                                    if(dpm.indexOf("区域负责人") != -1){
                                        $("#txtIDx4").val(units[1]);
                                        $("#txtIDx2").val(units[2]);
                                    }
                                    else{
                                        $("#txtIDx4").val(units[0]);
                                        $("#txtIDx2").val(units[1]);
                                    }
                                    $("#ddl4").show();
                                }
                                if(dpm.indexOf("区域经理") != -1 && flod.indexOf("3") != -1){
                                    if(units.length==4){
                                        $("#txtIDx4").val(units[1]);
                                        $("#txtIDx3").val(units[2]);
                                        $("#txtIDx2").val(units[3]);
                                    }
                                    else if(units.length==3){
                                        if(dpm.indexOf("分行主管") != -1){
                                            $("#txtIDx3").val(units[1]);
                                            $("#txtIDx2").val(units[2]);
                                        }
                                        else{
                                            $("#txtIDx4").val(units[1]);
                                            $("#txtIDx3").val(units[2]);
                                        }
                                    }
                                    else{
                                        $("#txtIDx3").val(units[1]);
                                    }
                                    $("#ddl3").show();
                                }
                            }
                        }
                    }
                })
            }
            $("#txtDepartment").autocomplete({ 
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
                                var dpm=info.split("|")[2];

                                if(units.length>0) // && dpm.indexOf("0000") == -1
                                {
                                    $("#txtIDx1").val('<%=EmployeeName %>');
                                    $("#ddl2").hide();
                                    $("#ddl3").hide();
                                    $("#ddl4").hide();
                                    if(dpm.indexOf("分行主管") != -1){
                                        $("#txtIDx2").val(units[1]);
                                        $("#ddl2").show();
                                    }
                                    if(dpm.indexOf("区域总监") != -1){
                                        if(dpm.indexOf("区域负责人") != -1){
                                            $("#txtIDx4").val(units[1]);
                                            $("#ddl4").show();
                                            $("#txtIDx2").val(units[2]);
                                        }
                                        else{
                                            $("#txtIDx4").val(units[0]);
                                            $("#ddl4").show();
                                            $("#txtIDx2").val(units[1]);
                                        }
                                    }
                                    if(dpm.indexOf("区域经理") != -1){
                                        if(units.length==4){
                                            $("#txtIDx4").val(units[1]);
                                            $("#txtIDx3").val(units[2]);
                                            $("#txtIDx2").val(units[3]);
                                        }
                                        else if(units.length==3){
                                            if(dpm.indexOf("分行主管") != -1){
                                                $("#txtIDx3").val(units[1]);
                                                $("#txtIDx2").val(units[2]);
                                            }
                                            else{
                                                $("#txtIDx4").val(units[1]);
                                                $("#txtIDx3").val(units[2]);
                                            }
                                        }
                                        else{
                                            $("#txtIDx3").val(units[1]);
                                        }
                                        $("#ddl3").show();
                                    }
                                }
                            }
                        }
                    })
                }
            });
        
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
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }

        function save() {
            var content = "";
            var x = 0;
            
            for(var y = 1; y <= 4; y++)
            {
                if($("#txtIDx"+y).closest('[id*=ddl]').css("display")!="none") 
                {
                    if($.trim($("#txtIDx"+y).val())=="")
                    {
                        alert("环节不可为空！");
                        $("#txtIDx"+y).focus();
                        return false;
                    }
                    x ++;
                    content+=y+":"+$("#txtIDx"+y).val()+";";
                }
            }
            
            //if(x < 6) {
            //    alert("事业部负责人和部门负责人这两个环节必须有一个要开启。");
            //    return false;
            //}
            
            content = content.substr(0,content.length-1);
            if(content != ""){
                $.ajax({
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=saveCommonFlow&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs=1|2|3|4',
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
            else{
                $.ajax({
                    url: "/Ajax/Flow_Handler.ashx",
                    type: "post",
                    dataType: "text",
                    data: 'action=DeleteFlow&id=&purview=<%=Purview %>&mainid=<%=MainID %>&deleteidxs=1|2|3|4|5',
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
        }

    //window.onbeforeunload =  function (){
        //if($.trim($("#txtIDx1").val())=="" && $.trim($("#txtIDx2").val())=="")
            //return '<%=CommonConst.MSG_FLOW_ISCLOSING %>';
        //}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="flow">
            申请部门内部审批流程(多人同时审批模式):<br />
            参照部门或组别：<input type="text" id="txtDepartment" runat="server" style="width:200px;" /><br />
            <div id ="ddl1" style="float: left; margin-top: 20px; display: none">
                <div id="divIDx1" class='item'>分行申请人</div>
                <div id="divTxtIDx1" class='item'>
                    <input type="text" id="txtIDx1" style="width:200px;" /><input id="hdIDx1" type="hidden" />
                </div>
                <img src="/Images/forward.png" class="forward"/>
            </div>

            <div id ="ddl2" style="float: left; margin-top: 20px; display: none">
                <div id="divIDx2" class='item'>分行主管</div>
                <div id="divTxtIDx2" class='item'>
                    <input type="text" id="txtIDx2" style="width:200px;" /><input id="hdIDx2" type="hidden" />
                </div>
            </div>

            <div id ="ddl3" style="float: left; margin-top: 20px; display: none">
                <img src="/Images/forward.png" class="forward"/>
                <div id="divIDx3" class='item'>所属区经</div>
                <div id="divTxtIDx3" class='item'>
                    <input type="text" id="txtIDx3" style="width:200px;" /><input id="hdIDx3" type="hidden" />
                </div>
            </div>

            <div id ="ddl4" style="float: left; margin-top: 20px; display: none">
                <img src="/Images/forward.png" class="forward"/>
                <div id="divIDx4" class='item'>所属总监</div>
                <div id="divTxtIDx4" class='item'>
                    <input type="text" id="txtIDx4" style="width:200px;" /><input id="hdIDx4" type="hidden" />
                </div>
            </div>
            

            <br /><br /><br />
            <input type="button" id="btnSave2" value="保存并通知审批" onclick="save();this.disabled ='disabled'" class="btn button" style="float: left"/>
        </div>
    </div>
    </form>
    <%=SbJs.ToString() %>
</body>
</html>

