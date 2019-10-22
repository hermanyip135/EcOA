<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssetTransfer_Apply_Asset.aspx.cs" Inherits="Apply_AssetTransfer_AssetTransfer_Apply_Asset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查找资产</title>
    <link rel="Stylesheet" href="/Style/style.css" />
    <script type="text/javascript" src="/Script/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Script/jquery-ui-1.10.1.custom.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui.datepicker-zh-CN.js"></script>
    <link rel="Stylesheet" href="/Style/DotLuv/jquery-ui-1.10.1.custom.css" />
    <link id="Link1" rel="Stylesheet" href="/Style/style.css" media="screen" type="text/css" runat="server" />
    <link href="/Style/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/Style/dropdown/themes/lwis.celebrity/default.advanced.css" media="screen" rel="stylesheet" type="text/css" />
    <base target="_self" />
    <script type="text/javascript">
        var jJSON = <%=sbJSON.ToString() %>;
        var placeJSON = <%=placeJSON.ToString() %>;
        var AssetJSON = <%=AssetJSON.ToString() %>;
        $(function() {
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
            $.datepicker.setDefaults({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
                
            });
            $("#<%=txtBeginTime.ClientID %>").datepicker();
            $("#<%=txtEndTime.ClientID %>").datepicker();

            $('[id*=DpmRe]').autocomplete({ 
                source: jJSON
            }); 
            $('[id*=PlaceRec]').autocomplete({ 
                source: placeJSON
            });
            $('[id*=txtDept]').autocomplete({ 
                source: jJSON
            });
      

            
            $("#<%=txtAssetName.ClientID%>").autocomplete({ 
                source: AssetJSON
            }); 
            $(":button").css("border", "none");
            $(":submit").css("border", "none");

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(check);
            check();
            function check() {
                $("[id*=btnsSearch]").mousedown(function () { $(this).css("background-image", "url(/Images/small_search2.png)"); })
                    .mouseup(function () { $(this).css("background-image", "url(/Images/small_search1.png)"); })
                    .mouseleave(function () { $(this).css("background-image", "url(/Images/small_search1.png)"); });
            }

            $('[id*=btnsSearch]').change(check); 

            $("[id*=btnSure]").css({
                "background-image": "url(/Images/btnSureS1.png)",
                "height": "25px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "43px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnSure]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); });

            $("[id*=btnBack]").css({
                "background-image": "url(/Images/btn25back1.png)",
                "height": "25px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "43px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnBack]").mousedown(function () { $(this).css("background-image", "url(/Images/btn25back2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn25back1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn25back1.png)"); });
        });

        function closeAdd(){
            
            $("#<%=txtAssetName.ClientID%>").val("");
            $("#<%=txtModel.ClientID%>").val("");
            $("#<%=Number.ClientID%>").val("");
            document.getElementById('sample').style.display='none'
        }

        function checkSaveAsset()
        {
            var  assetName=   $("#<%=txtAssetName.ClientID%>").val();
            var model= $("#<%=txtModel.ClientID%>").val();
            var number=$("#<%=Number.ClientID%>").val();
            if(assetName==""){
                alert("请输入资产名称！");
                return false;
            }
            if(model==""){
                alert("请输入资产型号！");
                return false;
            }
            if(!/^\d+$/.test(number))  
            {
                alert("数量输入有误！");
                return false;
            }
        }
        function SelectAll(aControl) {
            var tempControl = aControl;
            var isChecked = tempControl.checked;
            elem = tempControl.form.elements;
            for (i = 0; i < elem.length; i++)
                if (elem[i].type == "checkbox" && elem[i].id != tempControl.id) {
                    if (elem[i].checked != isChecked)
                        elem[i].click();
                }
        }
    </script>
    <style type="text/css">
        .astyle {
            width: 85px;
            background-image: url(/Images/small_search1.png);
            height: 24px;
            border-style: none;
            border-color: inherit;
            width: 43px;
            font-size: 0px;
            cursor:pointer;
            color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

         <div runat="server" id="selectdiv" style="z-index:-1"> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       
        <ContentTemplate >

    <table style="width:90%;margin:0 auto">
        <tr class="noborder">
            <td>
                <span runat="server" id="selectDept">部门名称:
                    <asp:TextBox runat="server" ID="txtDept"></asp:TextBox>
                </span>
                资产名称：<asp:TextBox ID="txtClassesId" runat="server"></asp:TextBox>　
                财务编号：<asp:TextBox ID="txtAssetNo" runat="server"></asp:TextBox>　
                入账时间：<asp:TextBox ID="txtBeginTime" runat="server"></asp:TextBox>～<asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>　
                <asp:Button ID="btnsSearch" runat="server" OnClick="btnSearch_Click" style="margin-left:10px;margin-bottom: 10px;" Text="查询" CssClass="astyle" />
            </td>
        </tr>
    </table>

        <asp:GridView ID="gvData" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="false" 
    OnPageIndexChanging="gvData_PageIndexChanging" GridLines="None" Width="90%" AllowPaging="true" PageSize="20" DataKeyNames="Asset_id" BorderWidth="0px" BorderStyle="None" HorizontalAlign="Center" OnRowDataBound="gvData_RowDataBound">
            <Columns>
                <%--<asp:BoundField DataField="Asset_id" HeaderText="ID" Visible="False" ></asp:BoundField>--%>
                <asp:TemplateField HeaderText="选择" ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
              
                    <HeaderTemplate>
                <asp:CheckBox runat="server" ID="cbHead"   onclick="javascript:SelectAll(this)" >
                </asp:CheckBox>
           </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelected"  runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:BoundField HeaderText="使用部门" DataField="Assets_Dept_Name" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                  <asp:BoundField HeaderText="存放地点" DataField="txtPlace" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                <asp:BoundField HeaderText="资产名称" DataField="txtClasses" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                <asp:BoundField HeaderText="归属" DataField="txtType" ItemStyle-Width="8%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                 <asp:BoundField HeaderText="财务编号" DataField="Asset_AssetNo" ItemStyle-Width="20%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                <asp:BoundField HeaderText="规格型号" DataField="txtTS" ItemStyle-Width="20%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                <asp:BoundField HeaderText="入账时间" DataField="Asset_RecordedTime" ItemStyle-Width="15%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                
                <asp:BoundField HeaderText="资产类型" DataField="Asset_RecordedTime" Visible="false" ItemStyle-Width="0%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <%--<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />--%>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
            <PagerStyle HorizontalAlign="Center"/>
            <PagerTemplate>
                当前第:
                <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                页/共:
                <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                页
                <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page" Font-Bold="true" 
                    Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" Font-Bold="true"
                    CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true"
                    Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                    Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                转到第
                <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="$('#hdPagerNum').val($('#gvData_ctl23_txtNewPageIndex').val())"
                    CommandName="Page" Text="GO" />
            </PagerTemplate>
        </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
        <div style="width:90%;margin:0 auto; text-align: center; padding-top: 15px;">
            <asp:Button ID="btnSure" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="确认" OnClick="btnSure_Click" />
            <asp:Button ID="btnBack" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="返回"  OnClick="btnBack_Click"  Height="21px" />
 
        </div>
    <br /><br />
    <input type="hidden" id="hdPagerNum" runat="server" value="1" />
        </div>

        <div runat="server" id="resultdiv" style="margin-top:10px;display:none">
                    
       <asp:GridView ID="EditData" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="false"  OnRowDataBound="EditData_RowDataBound"
    OnPageIndexChanging="EditData_PageIndexChanging" GridLines="None" Width="90%" AllowPaging="true" PageSize="20"  DataKeyNames="OfficeAutomation_Document_AssetTransfer_Detail_ID" BorderWidth="0px" BorderStyle="None" HorizontalAlign="Center">
            <Columns>
                <%--<asp:BoundField DataField="Asset_id" HeaderText="ID" Visible="False" ></asp:BoundField>--%>
                <asp:TemplateField HeaderText="序号"  ItemStyle-Width="2%"  InsertVisible="False"> 
                <ItemStyle HorizontalAlign="Center" /> 
                <HeaderStyle HorizontalAlign="Center"/> 
                <ItemTemplate> 
                <asp:Label ID="Label2" runat="server" Text='<%# this.EditData.PageIndex * this.EditData.PageSize + this.EditData.Rows.Count + 1%>' /> 
                </ItemTemplate> 
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="选择" ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelected"  runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
      

                <asp:BoundField HeaderText="调出部门" DataField="OfficeAutomation_Document_AssetTransfer_Detail_DpmExp" ItemStyle-Width="8%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                <asp:BoundField HeaderText="调出地点" DataField="OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp" ItemStyle-Width="8%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                <asp:TemplateField HeaderText="接收部门" ItemStyle-Width="10%"    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                            <asp:TextBox ID="DpmRe" runat="server" Style="width:80%" Text='<%# Bind("OfficeAutomation_Document_AssetTransfer_Detail_DpmRec") %>'> </asp:TextBox>
              
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="接收地点" ItemStyle-Width="10%"    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                            <asp:TextBox ID="PlaceRec" runat="server" Style="width:80%" Text='<%# Bind("OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec") %>'> </asp:TextBox>
              
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField HeaderText="资产名称" DataField="OfficeAutomation_Document_AssetTransfer_Detail_AssetName" ItemStyle-Width="8%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>--%>
                   <asp:TemplateField HeaderText="资产名称" ItemStyle-Width="10%"    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                            <asp:TextBox ID="AssetName" runat="server" Style="width:80%" Text='<%# Bind("OfficeAutomation_Document_AssetTransfer_Detail_AssetName") %>'> </asp:TextBox>
              
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="归属" ItemStyle-Width="10%"    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                            <asp:TextBox ID="TxtType" runat="server" Style="width:80%" Text='<%# Bind("OfficeAutomation_Document_AssetTransfer_Detail_TxtType") %>'> </asp:TextBox>
              
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="财务编号" ItemStyle-Width="13%"    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                           
                        <asp:Button runat="server"  Text="选择"  ID="CopySelect"  OnClick="Unnamed_Click"  /> 


                       
                            <asp:Label runat="server" ID="lable1" Text='<%# Bind("OfficeAutomation_Document_AssetTransfer_Detail_AssetTag") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
 
               
                 <%--<asp:BoundField HeaderText="规格型号" DataField="OfficeAutomation_Document_AssetTransfer_Detail_Model" ItemStyle-Width="10%" ItemStyle-VerticalAlign="Middle"></asp:BoundField>--%>
                  <asp:TemplateField HeaderText="规格型号" ItemStyle-Width="10%"    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                            <asp:TextBox ID="DetailModel" runat="server" Style="width:80%" Text='<%# Bind("OfficeAutomation_Document_AssetTransfer_Detail_Model") %>'> </asp:TextBox>
              
                    </ItemTemplate>
                </asp:TemplateField>
             
            </Columns>
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <%--<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />--%>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
            <PagerStyle HorizontalAlign="Center"/>
                       <PagerTemplate>
                当前第:
                <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                页/共:
                <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                页
                <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page" Font-Bold="true" 
                    Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" Font-Bold="true"
                    CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true"
                    Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                    Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                转到第
                <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="$('#hdPagerNum').val($('#gvData_ctl23_txtNewPageIndex').val())"
                    CommandName="Page" Text="GO" />
            </PagerTemplate>
        </asp:GridView>
            <br />
             <div style="width:90%;margin:0 auto; text-align: center; padding-top: 15px;">
            <asp:Button ID="btnSava_" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="保存" OnClick="btnSava_Click" />

              <%--    <asp:Button ID="btnSavaDpt" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="保存接收部门" OnClick="btnSavaDpt_Click" Visible="false" />--%>
            <asp:Button ID="btnAgain" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="重选" OnClick="btnAgain_Click" />
          <asp:Button ID="btnDel" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="删除" OnClick="btnDel_Click" />
               <asp:Button ID="Button1" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="返回"   OnClick="btnBack_Click"/>
                    <asp:Button ID="btnExport" runat="server" style="margin-left:10px;margin-bottom: 10px;" Text="导出" OnClick="btnExport_Click" Visible="false" />
               <input  type="button" id="btnaddview"   runat="server"  value="新增调动资产" onclick="document.getElementById('sample').style.display='block'"  style="margin-left:800px"  />    

        </div>

          
            </div>

<div  runat="server" id="sample" style=" height:30px; border:#CCC 1px solid; background:#FFFFFF; padding:0 0 0 5px; font-size:12px; color:#5c5c5c;z-index:2;display:none ">
   

    <div style="  height:36px; line-height:18px; float:left; margin:0;padding:0 5px 0 0;font-size:15px;margin-top:3px">
             <span  style="margin-left:10px"> 资产名称：</span> <asp:TextBox runat="server" ID="txtAssetName"></asp:TextBox>
            <span  style="margin-left:10px"> 规格型号：</span> <asp:TextBox runat="server" ID="txtModel"></asp:TextBox>
      <span  style="margin-left:10px"> 数  &nbsp 量：</span> <asp:TextBox runat="server" ID="Number"></asp:TextBox>
     <span >   <asp:Button  Text="保存"  runat="server"   OnClientClick="javascript:return checkSaveAsset();"  ID="btnSavaAsset" Style="margin-left:50px"  OnClick="btnSavaAsset_Click"  />  &nbsp
            <input  type="button" value="取消"  onclick="closeAdd()"/>
  <%--  <a href="javascript:void(0)" onclick="document.getElementById('sample').style.display='none'"><img src="/images/icon-02.gif" border="0" alt="点击关闭" style="height:20px;width:20px" /></a>--%>
         </span>
         </div>
      
</div>

<div  runat="server" id="copydiv" style=" position:absolute; width:400px;height:100px; border:#CCC 1px solid; background:#f2f2f2; left:300px;top:200px; padding:0 0 0 5px; font-size:12px; color:#5c5c5c;z-index:5;display:none ">
         
    <div style=" margin-left:5px;margin-top:5px;width:380px; height:90px; line-height:18px; padding:0 5px 0 0;font-size:15px;background:#FFFFFF">
           <br />        <span style="margin-top:20px;margin-left:10px"> 
               财务编号： <asp:TextBox runat="server" ID="CopyAssetNo"> </asp:TextBox> 
                           <asp:HiddenField  runat="server" ID="CopyAssetName"/>
                 <asp:HiddenField  runat="server" ID="CopyId"/>
                         </span>
        <br />    <br />  <asp:Button runat="server" ID="btnCopySava" OnClick="btnCopySava_Click"  Text="确定" Style="margin-left:100px" />
            &nbsp    &nbsp  <input  type="button" value="取消"  onclick="document.getElementById('copydiv').style.display='none'"/>
        </div>

</div>


</form>
</body>
</html>