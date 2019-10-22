<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlowShow.ascx.cs" Inherits="Common_FlowShow" %>
<script type="text/javascript" src="/Script/common.js"></script>
<script type="text/javascript">
    function FlowInit()
    {
        var flowjson = $("#<%=this.hidFlowjson.ClientID%>").val() == "" ? [] : $("#<%=this.hidFlowjson.ClientID%>").val().evalJSON();//string.evalJSON(); common.js 方法
        var flag = true;            //flag=false;时显示未审核
        var html = '审批流程:';
        var icon = '<img src="/Images/forward.png" class="forward"/>';  //箭头icon
        if (flowjson == null)
        {
            return;
        }
        for (var i = 0; i < flowjson.length; i++)
        {
            //第一个未审核的显示“待审理”
            if (flag && !flowjson[i].Audit)
            {
                //集团审批改成总经办
                if (flowjson[i].Employee == "梁健菁" && flowjson[i].Idx == "1000") 
                {
                    html += '<span class="auditing">待总经办审理</span>';
                    flag = false;
                }
                else
                {
                    html += '<span class="auditing">待' + flowjson[i].Employee + '审理</span>'; 
                    flag = false;
                } 
            }
            else {
                if (flowjson[i].Audit) {
                    //集团审批改成总经办
                    if (flowjson[i].Employee == "梁健菁" && flowjson[i].Idx == "1000") {
                        html += '<span class="other">总经办已完成审理</span>';
                    }
                    else {
                        html += '<span class="other">' + flowjson[i].Auditor + '已完成审理</span>';
                    }
                }
                else {
                    //集团审批改成总经办
                    if (flowjson[i].Employee == "梁健菁" && flowjson[i].Idx == "1000") {
                        html += '<span class="other">总经办</span>';
                    }
                    else {
                        html += '<span class="other">' + flowjson[i].Employee + '</span>';
                    }
                   
                }
            }
            //最后不用加箭头
            if (i != flowjson.length - 1)
            {
                html += icon;
            }
        }
        $("#flowshow").html(html);
    }
</script>
<div id="flowshow" class="flow"></div><asp:Panel ID="plEidtBtn" runat="server"><input type="button" id="btnEditFlow" onclick="editflow();" style="margin-left:10px;" value="编辑流程"></asp:Panel>
<asp:HiddenField ID="hidFlowjson" runat="server" />
<script type="text/javascript">
    FlowInit();
</script>