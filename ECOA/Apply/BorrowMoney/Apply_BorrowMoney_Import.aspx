<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master" CodeFile="Apply_BorrowMoney_Import.aspx.cs" Inherits="Apply_BorrowMoney_Apply_BorrowMoney_Import" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .btn {
         width:30px;
         height:20px;
        
        }
    </style>
    <script type="text/javascript">
        var empcode=<%=EmployeeID%>;
        $(function(){
            //if( empcode=="3816" || empcode =="50203")
            //{
            //    $("#trBorrowMoney").show();
            //}else
            //{
            //    $("#trBorrowMoney").hide();
            //}
        })
        function fnCheckFileExcel() {
            //var file = document.all("FileUpload1").value;
            var file = $("#<%=FileUpload1.ClientID%>").val();
       var type = file.substring(file.lastIndexOf('.'), file.length).toLowerCase();

       if (file == "") {
           alert("请先选择文件！");
           $("#<%=FileUpload1.ClientID%>").focus();
                return false;
            }

            if (type != ".xls" && type != ".xlsx") {
                alert("上传文件必须是Excel格式（xls和xlsx）！");
                $("#<%=FileUpload1.ClientID%>").focus();

                return false;
            }

            return true;
        }
        function OnClientBtnClick() {
            var ddlType = $("#<%=ddlType.ClientID%>").val();
            if (ddlType == '请选择类型') {
                alert('请选择导入类型')
                $("#<%=ddlType.ClientID%>").focus();
               // document.getElementById("ddlType").focus();
                return false;
            }
          
            alert("系统正在处理数据中!请不要重复操作,也不要关闭当前页面!请稍后...");
            return true;
        }
        function ImportRemind() {

            var ddlType = $("#<%=ddlType.ClientID%>").val();
            if (ddlType == '请选择类型') {
                alert('请选择导入类型')
                document.getElementById("ddlType").focus();
                return false;
            }
            if (confirm("是否导入" + ddlType + "？")) {
                return true;
            }
            return false;
        }
    </script>
    <style type="text/css">
        tr td {
        border:0
        
        }
    </style>
   </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="text-align:center">
         <h1>广东中原地产代理有限公司</h1>
        <h1>临时借用资金导入</h1>
    </div>
    <table style="width:100%">
       
        <tr id="trBorrowMoney" >
                        <td align="left" class="td" nowrap="nowrap" colspan="4">
                            &nbsp;选择文件(excel)：
                            <asp:FileUpload ID="FileUpload1" runat="server" />
         
                      <asp:Button CssClass="btn" ID="Button1" Text="上传"  runat="server"  OnClick="lbtnUpload_Click" Width="40px" OnClientClick="return fnCheckFileExcel();" />
                     选择表：<asp:DropDownList ID="ddlSheetName" runat="server"></asp:DropDownList>           
              
                        <asp:DropDownList ID="ddlType" runat="server">
                                <asp:ListItem>请选择类型</asp:ListItem>
                                <asp:ListItem>冲借支</asp:ListItem>
                                <asp:ListItem>入账确认</asp:ListItem>
                            </asp:DropDownList>
                 
                     <asp:Button ID="lbtnTestingExcel" runat="server" OnClick="lbtnTestingExcel_Click" OnClientClick="return OnClientBtnClick();"  Text="检测" />
                      <asp:HyperLink ID="LinkErrorAn" runat="server">导出提示信息</asp:HyperLink>
                             <asp:Button ID="ImportRemind" runat="server" OnClick="lbtImportBorrowMoney_Click"  OnClientClick="return ImportRemind();"  Text="导入" />
                   </td>  
                    </tr>
         
        </table>
      <div style="text-align: left;">
                <asp:Label ID="lbMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
  </asp:Content>