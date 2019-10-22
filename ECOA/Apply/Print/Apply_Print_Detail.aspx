<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Print_Detail.aspx.cs" Inherits="Apply_Print_Apply_Print_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="../../Script/uploadify/uploadify.css" type="text/css" />
    <style type="text/css">
        .uploadify-button {
            background: #000 url("../../images/btn_save1_03.png") repeat-x scroll 0 0;
            border: 1px solid #4c68d5;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-family: 微软雅黑;
            font-weight: 700;
            height: 34px;
            overflow: hidden;
        }

        .uploadify:hover .uploadify-button {
            background: #000 url("../../images/btn_save1_03.png") repeat-x scroll 0 0;
            border: 1px solid #4c68d5;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-family: 微软雅黑;
            font-weight: 700;
            height: 34px;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript" src="../../Script/uploadify/jquery.uploadify.min.js"></script>
    <script type="text/javascript" src="../../Script/jquery.dynamic3.ycomp.js"></script>
    <script type="text/javascript">
        //通用方法
        //打印
        function myPrint(start, end, extend) {
            //window.print();
            cMyPrint();
        }
        //返回
        function BackToSearch() {
            cBackToSearch("<%=Request.QueryString %>");  //common_new.js
        }

        //编辑流程
        function editflow() {
            cEditflow("<%=MainID %>");   //common_new.js
        }
        //取消签名
        function CancelSign(idc) {
            cCancelSign(idc, "<%=this.hdCancelSign.ClientID%>", "<%=this.btnCancelSign.ClientID%>");   //common_new.js
        }
        
        //同意删除
        function DeleteT() { //20141231：M_DeleteC
            cDeleteT("<%=MainID %>", "<%=ApplyN %>");
        }
    </script>

    <script type="text/javascript">
        function check()
        {
            if ($(".picfilds img").length == 0)
            {
                alert("请上传图片");
                return false;
            }

            return true;
        }

        function PageInit()
        {
            //上传控件
            $("#uploadify").uploadify({
                'swf': '../../Script/uploadify/uploadify.swf',
                'uploader': '../../Ajax/UploadHandler.ashx?MainID=<%=MainID%>',
                //'cancelImg': '../../Script/uploadify/cancel.png',
                'buttonText': '上传pdf',
                'queueID': 'fileQueue',
                'fileTypeExts': '*.jpg',
                'fileTypeDesc': '请选择jpg、png文件',
                'auto': true,
                'multi': true,
                'width': 100,
                onDialogClose: onDialogClose,
                onCancel: onDialogClose,
                onUploadSuccess: onUploadSuccess
            });
        }

        //上传相关
        var onDialogClose = function (queueData) { }
        var onUploadSuccess = function (file, data, response) {
            if (data == "0") {
                alert("请先登录");
                return;
            }
            var obj = eval("(" + data + ")");       //转json
            var html = "";
            html += "<img src='" + obj.url + "' class='pic' style='width:100%' /><br/>";
            //$("#imgOrganizationStructure").attr("src", obj.url).show();
            $("#picfilds").append(html);

            var $d = $("#<%=this.hidPrint_Detail.ClientID%>");
            var dval = $d.val();
            if (dval != "")
            {

            }

            if (dval == "" || dval == null) {
                dval = data;
            }
            else {
                dval += "," + data;
            }

            dval = 

            $d.val(dval);
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
            <uc1:FlowShow ID="FlowShow1" ShowEditBtn="false" runat="server" />
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>XXXXXXX申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<asp:Literal ID="litSerialNumber" runat="server"></asp:Literal></span></div>
            <table class="tbflows" style="width: 640px; margin: 0 auto" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="auto-style4" style="width: 100px">姓名</td>
                    <td class="tl PL10">
                        <asp:Label ID="Apply" runat="server" ></asp:Label>
                        <asp:HiddenField ID="Department" runat="server" />
                    </td>
                    <td class="auto-style4">申请日期</td>
                    <td class="tl PL10">
                        <asp:Label ID="ApplyDate" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>
            <div style="width:640px;margin:auto">
                <div id="picfilds"></div>

                <div class="uploadbtn">
                    <span id="uploadify"></span>
                </div>
                <div class="hidfild">
                    <asp:HiddenField ID="hidPrint_Detail" runat="server" />
                </div>
            </div>
            
        </div>
        <!--打印正文结束-->

        <div class="noprint">
            <div id="PageBottom">
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />

                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClientClick="BackToSearch();return false;" />

                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />
                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        PageInit()
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
