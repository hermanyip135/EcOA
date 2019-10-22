<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_WYRecruit_Flow.aspx.cs" Inherits="Apply_WYRecruit_Apply_WYRecruit_Flow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="/Script/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Script/jquery-ui-1.10.1.custom.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui.datepicker-zh-CN.js"></script>
    <link rel="Stylesheet" href="/Style/DotLuv/jquery-ui-1.10.1.custom.css" />
    <link rel="Stylesheet" href="/Style/flow.css" />
    <script type="text/javascript">
        var jJSON = <%=SbJson.ToString() %>;
        function PageInit()
        {
            var type=<%=type%>;
            if(type==1)
            {
                $(".row").css("display","none");
            }else
            {
                $(".manager").css("display","none");
            }

            //初始化autocomplete
            function split( val ) {
                return val.split( /,\s*/ );
            }
            function extractLast( term ) {
                return split( term ).pop();
            }
            $(".item input[name='Auditor']").each(function(){
                $(this).bind( "keydown", function( event ) {
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
            });

            //初始化列表内容
            var content = $("#<%=this.hidFlowJson.ClientID%>").val();
            if(content != "")
            {
                var data = $.parseJSON(content);
                for(var i=0;i< data.length;i++)
                {
                    var $input = $("input[name='Auditor'][Idx='" + data[i].Idx + "']");
                    $input.val(data[i].Auditor);
                    $input.next().val(data[i].AuditorID);

                    $tr = $input.parent();
                    if(!$tr.hasClass("REQUIRED") && !$tr.hasClass("ON"))
                    {
                        $tr.addClass("ON");
                    }
                }
            }

            //初始化直属主管、总助 52100
            var reslut1="<%=zongjian%>";
            var reslut2="<%=zongzhu%>";
            if(reslut1!="")
            {
                $("#zongjian").val(reslut1);
            }
            if(reslut2!="")
            {
                $("#zongzhu").val(reslut2);
            }
        }

        function flowon(e)
        {
            $item = $(e).parent();
            if (!$item.hasClass("REQUIRED"))
            {
                $item.addClass("ON");
            }
        }
        function delon(e)
        {
            $item = $(e).parent();
            if (!$item.hasClass("REQUIRED")) {
                $item.removeClass("ON");
            }
        }
        function check()
        {
            var content = "";
            var deleteidxs = "";
            var flag = true;
            var idx;
            $(".auditor").each(function(){
                idx = $(this).attr("Idx");
                if($(this).parent().parent().css("display") != "none" && $(this).css("display") != "none")
                {
                    if(this.value == "")
                    {
                       // if(idx !=3){
                            flag = false;
                            var t = $(this).prev().html();
                            $(this).focus();
                            alert("请填写" + t);
                            return false;
                      //  }
                    }
                    else
                    {
                        content += idx + ":" + this.value + ";";
                    }
                }
                deleteidxs += idx + "|";
            });
            return {flag:flag,content:content,deleteidxs:deleteidxs};
        }
        function save(e)
        {
            e.disabled = true;
            var d = check();
            if(!d.flag)
            {
                e.disabled = false;
                return false;
            }
            d.content = d.content.length > 1 ? d.content.substr(0,d.content.length-1) : "" ;         //去掉末尾的|
            d.deleteidxs = d.deleteidxs.length > 1 ? d.deleteidxs.substr(0,d.deleteidxs.length-1) : "";    //去掉末尾的|

            $.ajax({
                url: "/Ajax/Flow_Handler.ashx",
                type: "post",
                dataType: "text",
                data: 'action=saveCommonFlow&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + d.content+'&deleteidxs='+d.deleteidxs,
                success: function(info) {
                    if (info == "success") {
                        alert('<%=CommonConst.MSG_FLOW_SUCCESSSAVE%>');
                        window.returnValue='success';
                        window.close();
                    }
                    else if (info == "NoPower")
                    {
                        alert("<%=CommonConst.MSG_EDITPOWER_NOOPEN%>");
                    }
                    else if (info == "Conpleted"){
                        alert("该表已审批完毕，不能再修改了！");
                        window.returnValue='success';
                        window.close();
                    }
                    else
                    {
                        alert("<%=CommonConst.MSG_FLOW_SAVEFAIL%>\n错误代码："+ info);
                    }
                    e.disabled = false;
                }
            })
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="flow">
        <asp:HiddenField ID="hidFlowJson" runat="server" />
        <h5>申请部门内部审批流程(多人同时审批模式):</h5>
        <%--REQUIRED:必填--%>
        <div class="row clearfix">
            <%--<div class="item REQUIRED">
                <input class="addbtn" type="image" onclick="flowon(this); return false;" src="/Images/add.png" />
                <span>申请人</span>&nbsp;<input class="auditor" name="Auditor" type="text" Idx="1" />
                <input name="AuditorID" type="hidden" />
                <a class="cancelbtn" href="javascript:;" onclick="delon(this);return false;">取消</a>
            </div>--%>
            <%--<img class="forward" src="/Images/forward.png" />--%>
            <div class="item REQUIRED">
                <input class="addbtn" type="image" onclick="flowon(this); return false;" src="/Images/add.png" />
                <span>直属主管</span>&nbsp;<input id="zongjian" class="auditor" name="Auditor" type="text" Idx="1" />
                <input name="AuditorID" type="hidden" />
                <a class="cancelbtn" href="javascript:;" onclick="delon(this);return false;">取消</a>
            </div>
            <img class="forward" src="/Images/forward.png" />
            <div class="item ">
                <input class="addbtn" type="image" onclick="flowon(this); return false;" src="/Images/add.png" />
                <span>总助</span>&nbsp;<input id="zongzhu" class="auditor" name="Auditor" type="text" Idx="3" />
                <input name="AuditorID" type="hidden" />
                <a class="cancelbtn" href="javascript:;" onclick="delon(this);return false;">取消</a>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="row clearfix">
            <%--<div class="item">
                <input class="addbtn" type="image" onclick="flowon(this); return false;" src="/Images/add.png" />
                <span>总助</span>&nbsp;<input class="auditor" name="Auditor" type="text" Idx="3" />
                <input name="AuditorID" type="hidden" />
                <a class="cancelbtn" href="javascript:;" onclick="delon(this);return false;">取消</a>
            </div>--%>
            <img class="forward" src="/Images/forward.png" />
            <div class="item REQUIRED">
                <input class="addbtn" type="image" onclick="flowon(this); return false;" src="/Images/add.png" />
                <span>区域负责人</span>&nbsp;<input class="auditor" name="Auditor" type="text" Idx="4" />
                <input name="AuditorID" type="hidden" />
                <a class="cancelbtn" href="javascript:;" onclick="delon(this);return false;">取消</a>
            </div>
            <div class="clearfix"></div>
        </div>

        
        <div class="manager">
             <div class="item REQUIRED">
                <input class="addbtn" type="image" onclick="flowon(this); return false;" src="/Images/add.png" />
                <span>直属主管</span>&nbsp;<input id="Text1" class="auditor" name="Auditor" type="text" Idx="1" />
                <input name="AuditorID" type="hidden" />
                <a class="cancelbtn" href="javascript:;" onclick="delon(this);return false;">取消</a>
            </div>
            <img class="forward" src="/Images/forward.png" />
            <div class="item REQUIRED">
                <input class="addbtn" type="image" onclick="flowon(this); return false;" src="/Images/add.png" />
                <span>部门负责人</span>&nbsp;<input class="auditor" name="Auditor" type="text" Idx="4" />
                <input name="AuditorID" type="hidden" />
                <a class="cancelbtn" href="javascript:;" onclick="delon(this);return false;">取消</a>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <div class="flow">
        <input type="button" id="btnSave2" value="保存并通知审批"  onclick="save(this);return false;" class="btn button"/>
    </div>
    </form>
    <script type="text/javascript">
        PageInit();
    </script>
</body>
</html>