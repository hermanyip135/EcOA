<%@ Page Title="查询 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Search.aspx.cs" Inherits="Apply_Apply_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">
        var jJSON = <%=sbJSON.ToString() %>;
        var empcode=<%=EmployeeID%>;
        $(function() {
          
           
            //$("[id*=txtApplicationDepartment]").css("border", "1px solid #8e9190"); 
            //$("[id*=txtApplicant]").css("border", "1px solid #8e9190"); 
            //$("[id*=txtApplyDate]").css("border", "1px solid #8e9190"); 
            $("[id*=ddlApplyType]").css("border", "1px solid #8e9190"); 
            $("[id*=selTypes]").css("border", "1px solid #8e9190"); 
            $("[id*=ddlState]").css("border", "1px solid #8e9190"); 
           
            //$("[id*=txtEndDate]").css("border", "1px solid #8e9190"); 
            //$("[id*=txtSerialNumber]").css("border", "1px solid #8e9190"); 
            //$("[id*=txtKeyWord]").css("border", "1px solid #8e9190"); 

            //            $("#li2").attr("class", "current");

            $("[id*=btnSelectChecked]").css({
                "background-image": "url(/Images/btnSelectChecked1.png)",
                "height": "36px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "110px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnSelectChecked]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSelectChecked2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSelectChecked1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSelectChecked1.png)"); });

            $("[id*=btnInterestsExcel]").css({
                "background-image": "url(/Images/btExcel1.png)",
                "height": "36px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "88px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnLoanWrongSaveExcel]").css({
                "background-image": "url(/Images/btExcel1.png)",
                "height": "36px",
                "border-style": "none",
                "border-color": "inherit",
                "width": "88px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);
            $.datepicker.setDefaults({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
                
            });

            $("#<%=txtApplyDate.ClientID %>").datepicker();
            $("#<%=txtEndDate.ClientID %>").datepicker();
            $("#<%=txtAppTime.ClientID %>").datepicker();
            $("#<%=this.txtAppToTime.ClientID %>").datepicker();
            $("#<%=txtApplicationDepartment.ClientID %>").autocomplete({ 
                source: jJSON,
                select: function( event, ui ) {
                    $("#<%=hdApplicationDepartmentID.ClientID %>").val(ui.item.id);
                }
            }); 

            $.each($('#selTypes option'),function(i,n){
                if($(n).val()==$('#<%=hdTypeID.ClientID%>').val())
                    document.getElementById('selTypes').selectedIndex=i;
            });

            if( $('#<%=hdTypeID.ClientID%>').val()==8 && (empcode=="31317" || empcode=="37651" || empcode=="42900"|| empcode=="39151" || empcode =="50203" || empcode =="71880"))
            {
                $("#intereststype").css("display","");
            }else
            {
                $("#intereststype").css("display","none");
            }
        
            showceshi();
            if(($("#selTypes").val() == 85 || $("#selTypes").val() == 65) && (empcode=="11322" || empcode=="51244" || empcode=="42666" || empcode=="5940" || empcode=="5585" || empcode=="50203"|| empcode=="39151"))
            {
                $('#<%=btnLoanWrongSaveExcel.ClientID%>').show();
            }
            else
            {
                $('#<%=btnLoanWrongSaveExcel.ClientID%>').hide();
            }
           
        });
     
        function check() {
            $('#<%=hdMainID.ClientID%>').val('')
                if ($.trim($("#<%=txtApplicationDepartment.ClientID %>").val()) == '' 
                    && $.trim($("#<%=txtApplicant.ClientID %>").val()) == '' 
                    && $.trim($("#<%=txtApplyDate.ClientID %>").val()) == '' 
                    && $.trim($("#<%=txtEndDate.ClientID %>").val()) == '' 
                    && $.trim($("#<%=hdTypeID.ClientID %>").val()) == '' 
                    && $("#<%=ddlState.ClientID %> :selected").val() == '' 
                    && $.trim($("#<%=txtSerialNumber.ClientID %>").val()) == ''
                    && $.trim($("#<%=txtKeyWord.ClientID %>").val()) == ''
                    && $.trim($("#<%=txtApprover.ClientID %>").val()) == ''
                    && $.trim($("#<%=txtAppTime.ClientID %>").val()) == ''
                    && $.trim($("#<%=txtAppToTime.ClientID %>").val()) == ''
                    
                    ) {
                alert("至少需要一个查询条件!");
                return false;
                }
                else if($.trim($("#<%=txtAppTime.ClientID %>").val()) != ''&& $.trim($("#<%=txtApprover.ClientID %>").val()) == ''){
                    alert("请填写审批人!");
                    $("#<%=txtApprover.ClientID%>").focus();
                    return false;
                }
                <%if (!KeyWordAllTB) {%>
                else if($.trim($("#<%=hdTypeID.ClientID %>").val()) == '' && $.trim($("#<%=txtKeyWord.ClientID %>").val()) != '')
                {
                    alert("若要进行关键字查询，必须选择申请类型。");
                    $("#<%=hdTypeID.ClientID %>").focus();
                   return false;
                }
                <%} %>
                else if($("#<%=this.txtApplyDate.ClientID%>").val() != "" && $("#<%=this.txtEndDate.ClientID%>").val() == "")
                {
                    alert("请选择申请日期结束的时间。");
                    $("#<%=this.txtEndDate.ClientID%>").focus();
                    return false;
                }
                else if($("#<%=this.txtApplyDate.ClientID%>").val() == "" && $("#<%=this.txtEndDate.ClientID%>").val() != "")
                {
                    alert("请选择申请日期开始的时间。");
                    $("#<%=this.txtApplyDate.ClientID%>").focus();
                    return false;
                }

                else if($("#<%=this.txtAppTime.ClientID%>").val() != "" && $("#<%=this.txtAppToTime.ClientID%>").val() == "")
                {
                    alert("请选择审批时间结束的时间。");
                    $("#<%=this.txtAppToTime.ClientID%>").focus();
                    return false;
                }
                else if($("#<%=this.txtAppTime.ClientID%>").val() == "" && $("#<%=this.txtAppToTime.ClientID%>").val() != "")
                {
                    alert("请选择审批时间开始的时间。");
                    $("#<%=this.txtAppTime.ClientID%>").focus();
                    return false;
                }
            return true;
        }

        function setTypeID(n)
        {
            $('#<%=hdTypeID.ClientID%>').val(n.options[n.selectedIndex].value);
            if( n.options[n.selectedIndex].value==8 && (empcode=="31317" ||empcode=="37651" || empcode=="42900"||empcode=="39151"||empcode=="50203"))
            {
                $("#intereststype").css("display","");
                $('#<%=btnInterestsExcel.ClientID%>').show();
            }else
            {
                $("#intereststype").css("display","none");
                $('#<%=btnInterestsExcel.ClientID%>').hide();
            }
            if( (n.options[n.selectedIndex].value==85 || n.options[n.selectedIndex].value==65) && (empcode=="11322" || empcode=="51244" || empcode=="42666" || empcode=="5940" || empcode=="5585" || empcode=="50203"))
            {
               
                $('#<%=btnLoanWrongSaveExcel.ClientID%>').show();
            }else
            {
                $('#<%=btnLoanWrongSaveExcel.ClientID%>').hide();
            }
           
        }
    </script>
	<style type="text/css">
        tr, td
        {
            border-width:0px;
        }
	    .yinzhang {
	    display:none ;
        
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%">
        <tr class="noborder">
            <td style="width:30%"><label class="">申请部门:</label><input class="txt_of_search" id="txtApplicationDepartment" type="text" runat="server" /><input type="hidden" id="hdApplicationDepartmentID" runat="server" /></td>
            <td style="width:20%"><label class="">申请人:</label><input class="txt_of_search" id="txtApplicant" type="text" runat="server" /></td>
            <td style="width:30%"><label class="">申请日期:</label><input class="txt_of_search" id="txtApplyDate" type="text" runat="server" style="width:100px;"  />至<input class="txt_of_search" id="txtEndDate" type="text" runat="server" style="width:100px;padding-left:2px;" /></td>
            <td>查询条件:<asp:DropDownList ID="ddlApplyType" runat="server" Width="153px">
                <asp:ListItem Value="1">按最后申请日期排序</asp:ListItem>
                <asp:ListItem Value="2">按最后审批时间排序</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr class="noborder">
            <td>
                <label class="" style="float:left;">申请类型:</label>
                <select id="selTypes" onchange="setTypeID(this);" style="width:230px;">
                    <option value="">--所有申请类型--</option>
                    <%=sbJS.ToString() %>
                </select>
                <input id="hdTypeID" type="hidden" runat="server" value="" />
            </td>
            <td><label class="">状&nbsp;&nbsp;&nbsp;&nbsp;态:</label><asp:DropDownList class="txt_of_search" ID="ddlState" runat="server"></asp:DropDownList></td>
            <td><label class="">文档编码:</label><input class="txt_of_search" id="txtSerialNumber" type="text" runat="server" style="width:217px;" /></td>
            <td><label class="">关&nbsp;&nbsp;键&nbsp;&nbsp;字:</label><input class="txt_of_search" id="txtKeyWord" type="text" runat="server" style="width:150px;" /></td>
        </tr>
        <tr class="noborder">
            <td style="vertical-align: top">
                <span style="float: left"><label class="">审批人:　</label><input class="txt_of_search" id="txtApprover" type="text" runat="server" style="width:150px;" /></span>
            </td>
            <td colspan="3">
                <span style="float: left"><label class="">审批时间:　</label><input class="txt_of_search" id="txtAppTime" type="text" runat="server" style="width:100px;" />至<input class="txt_of_search" id="txtAppToTime" type="text" runat="server" style="width:100px;" /></span>
                 <span style="float: left" id="spIsGroups" runat="server" visible="false"> <asp:CheckBox runat="server" ID="cbIsGroups"/><label class="">是否经集团审批</label></span>
                 <span id="intereststype" style="float: left;display:none;margin-left:10px;"><label class="">申报类别：</label><asp:DropDownList ID="ddlInterestsType" runat="server" Width="200px" OnSelectedIndexChanged="ddlInterestsType_SelectedIndexChanged"></asp:DropDownList></span>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" OnClientClick="return check();" style="margin-left:10px;margin-bottom: 10px;" Text="查询" />
                <asp:Button ID="btExcel" runat="server" Text="导出数据" OnClick="btExcel_Click"  Visible="False" style="margin-left:10px;margin-bottom: 10px;" />
                <asp:Button ID="btnSelectChecked" runat="server" Text="批量审批" style="margin-left:10px;margin-bottom: 10px;" OnClick="btnSelectChecked_Click" Visible="False" />

                <asp:Button ID="btnInterestsExcel" runat="server" Text="导出数据" style="margin-left:10px;margin-bottom: 10px; cursor:pointer;" OnClick="btnInterestsExcel_Click" Visible="False" />
                <asp:Button ID="btnLoanWrongSaveExcel" runat="server" Text="导出错存放款数据" OnClick="btnLoanWrongSaveExcel_Click" OnClientClick="return ceshi(1)" style="margin-left:10px;margin-bottom: 10px;" />
            </td>
            <td></td>
        </tr>
    </table>
    <asp:Panel ID="ChkSelect" runat="server" Visible="False">
        <asp:CheckBox ID="chkSelectAll" runat="server" Text="全部选中" AutoPostBack="True" nCheckedChanged="chkSelectAll_CheckedChanged" OnCheckedChanged="chkSelectAll_CheckedChanged" />
        <asp:CheckBox ID="chkCancelAll" runat="server" Text="全部取消" AutoPostBack="True" nCheckedChanged="chkCancelAll_CheckedChanged" OnCheckedChanged="chkCancelAll_CheckedChanged" />　
    </asp:Panel>

    <asp:GridView ID="gvData" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="false" OnRowDataBound="gvData_RowDataBound" OnRowCommand="gvData_RowCommand" 
        OnPageIndexChanging="gvData_PageIndexChanging" GridLines="None" Width="100%" AllowPaging="true" PageSize="20" DataKeyNames="MainID" BorderWidth="0px" BorderStyle="None">
        <Columns>

            <%--<asp:BoundField DataField="MainID" HeaderText="ID" Visible="False" />--%>
            <%--<asp:TemplateField HeaderText="选择" ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >--%>
            <asp:TemplateField ItemStyle-Width="1%">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkSelected"  runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:BoundField HeaderText="文档编码" DataField="OfficeAutomation_SerialNumber" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="申请部门" DataField="Department" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="申请人" DataField="Apply" ItemStyle-Width="9%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="申请表" DataField="OfficeAutomation_Document_Name" ItemStyle-Width="18%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="申请日期" DataField="ApplyDate" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="9%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="状态" DataField="waitfor" ItemStyle-Width="10%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:BoundField HeaderText="备注" DataField="Remark" ItemStyle-Width="14%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
             <asp:BoundField  HeaderText="guid" HeaderStyle-CssClass="yinzhang" ItemStyle-CssClass="yinzhang" DataField="MainID" ItemStyle-Width="5%"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
            <asp:TemplateField HeaderText="删除" ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:ImageButton ID="iBtnDelete" runat="server"  ImageUrl="../Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("MainID") %>' Visible="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="详情" ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:ImageButton ID="iBtnDetail" runat="server"  ImageUrl="../Images/next.png" CommandName="Detail" CommandArgument='<%#Eval("MainID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#EFF3FB" />
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
                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' OnClientClick="ceshi(0)">上一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Font-Bold="true" OnClientClick="ceshi(0)"
                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Font-Bold="true"
                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
            转到第
            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" OnClientClick="$('#ctl00_ContentPlaceHolder1_hdPagerNum').val($('#ctl00_ContentPlaceHolder1_gvData_ctl05_txtNewPageIndex').val())"
                CommandName="Pageindex" Text="GO" />
            <%--<asp:LinkButton ID="lbGO" runat="server" CausesValidation="False" CommandArgument="-2" CommandName="Pageindex" Text="GO"> </asp:LinkButton>--%>
        </PagerTemplate>
    </asp:GridView>
    <input type="hidden" id="hdMainID" runat="server"/>
    <input type="hidden" id="hdEmployeeID" runat="server" value="1" />
    <input type="hidden" id="hdPagerNum" runat="server" value="1" />
    <%=SbJszz.ToString() %>
    <script type="text/javascript">
      var  checkedIDs=$('#<%=hdMainID.ClientID%>').val();
        function ceshi(r)
        {
            var mainID="";
            var grid= document.getElementById('<%=gvData.ClientID %>') 
            if(grid!=null)
            {
                for (i=1;i< grid.rows.length;i++) {
                    try {
                        var cb=grid.rows(i).cells(0).children(0);
                        if(cb.checked)
                        {
                            if(checkedIDs.indexOf(grid.rows(i).cells(8).innerText) == -1)
                            {
                                checkedIDs+=grid.rows(i).cells(8).innerText+",";
                            }
                        }
                        if(!cb.checked)
                        {
                            if(checkedIDs.indexOf(grid.rows(i).cells(8).innerText) != -1)
                            {
                                checkedIDs = checkedIDs.replace((grid.rows(i).cells(8).innerText+","),"");
                            }
                        }
                    } catch (e) {
    
                    }
               
                }
            }
          
            $('#<%=hdMainID.ClientID%>').val(checkedIDs)
            if(r==1)
            {
                return (confirm('是否确认导出? 导出后数据将不可再导!'))
            }
           
          
        }
    
        function showceshi()
        {
            var mainiD = $('#<%=hdMainID.ClientID%>').val()//隐藏控件装起来的号码
            if(mainiD !=null && mainiD != "")
            {
             var grid= document.getElementById('<%=gvData.ClientID %>') //列表框
                for (i=1;i< grid.rows.length;i++) {
                    try {
                        var a=grid.rows(i).cells(8).innerText;
                        if(mainiD.indexOf(a)!=-1)//判断
                        {
                            //alert(grid.rows(i).cells(1).innerText);
                            grid.rows(i).cells(0).children(0).checked= "checked";
                        }
                    } catch (e) {
    
                    }
                   
                }
            }
           
        }
    </script>
</asp:Content>