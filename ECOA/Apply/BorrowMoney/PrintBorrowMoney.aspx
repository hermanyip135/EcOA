<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintBorrowMoney.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Apply_BorrowMoney_PrintBorrowMoney" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script  type="text/javascript" src="../../Script/jquery.PrintArea.min.js"></script>
    <script type="text/javascript">

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        $(function() {      
         
            LoadDetail("<%=this.hidDetail1.ClientID%>","jzqk1");
         
           
            $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
          
        });
      
        //打印
        function myPrint(start, end, extend) {
            //window.print();
            // cMyPrint();
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--打印正文开始-->";
            eprnstr = "<!--打印正文结束-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
        //加载明细 idname =hidDetail(隐藏的json) Idtbody=绑在那个id
        function LoadDetail(idname,Idtbody)
        {
          
            var detail = $("#" + idname).val();
           // console.log(detail);
            var list = detail == "" ? [] : $.parseJSON(detail);
         
            for(var i = 0 ; i < list.length;i++)
            {
                var copytr = $("#"+Idtbody+" tr").first();
                if(list[i] != null && list[i] != undefined && isjson(list[i]))
                {
                    var obj = list[i];
                    var $tr = '';
                    for (var k in obj) {
                        if (k == 'month')
                        {
                            $tr += "<tr>" + "<td colspan='3'  class='auto-style4'>" + obj['month'] + "</td>"
                        }
                        else if(k == 'UnitPrice')
                        {
                            $tr+= "<td >￥" + obj['UnitPrice'] + "</td>" + "</tr>"
                        }
                       
                        
                        //$(copytr).find("span[id=" + k + "]").val(obj[k]);
                        //$(copytr).find("select[name=" + k + "]").val(obj[k]);
                        //$(copytr).find("input[name=" + k + "]").val(obj[k]);
                        //遍历对象，k即为key，obj[k]为当前k对应的值
                        //console.log(k);
                    }
                    //   }
                    //  else
                    //    {
                    //       $(copytr).find("input[type=text]").val("");
                    //    }
                    //}
                    //else
                    //{
                    //    addrow(null,Idtbody,list[i]);
                    //}
                }
                $("#jzqk1").append($tr)
            }
          
        }

        
        function Obj2str(o) {
            if (o == undefined) {
                return "";
            }
            var r = [];
            if (typeof o == "string") return "\"" + o.replace(/([\"\\])/g, "\\$1").replace(/(\n)/g, "\\n").replace(/(\r)/g, "\\r").replace(/(\t)/g, "\\t") + "\"";
            if (typeof o == "object") {
                if (!o.sort) {
                    for (var i in o)
                        r.push("\"" + i + "\":" + Obj2str(o[i]));
                    if (!!document.all && !/^\n?function\s*toString\(\)\s*\{\n?\s*\[native code\]\n?\s*\}\n?\s*$/.test(o.toString)) {
                        r.push("toString:" + o.toString.toString());
                    }
                    r = "{" + r.join() + "}"
                } else {
                    for (var i = 0; i < o.length; i++)
                        r.push(Obj2str(o[i]))
                    r = "[" + r.join() + "]";
                }
                return r;
            }
            return o.toString().replace(/\"\:/g, '":""');
        }
    
     
		
        function myPrint() {
            //start = "<!--" + start + "-->";    
            //end = "<!--" + end + "-->";    
            //if (typeof (extend) == 'undefined') {        
            //    var temp = window.document.body.innerHTML;        
            //    var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
            //    window.document.body.innerHTML = printhtml;        
            //    window.print();        
            //    window.document.body.innerHTML = temp;    
            //}    
            //else { window.print(); }
            //cMyPrint();
            //var bdhtml = document.body.innerHTML;

            var bdhtml = document.body.innerHTML;
            window.document.body.innerHTML = bdhtml
            PageSetup_Null();//设置页脚为空  
            //打印
            
            window.print()
        }
        var HKEY_Root, HKEY_Path, HKEY_Key;
        HKEY_Root = "HKEY_CURRENT_USER";
        HKEY_Path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";
        //设置网页打印的页眉页脚为空 ，仅IE浏览器可用  
        function PageSetup_Null() {
            try {
                var Wsh = new ActiveXObject("WScript.Shell");
                HKEY_Key = "header";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
                HKEY_Key = "footer";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
            }
            catch (e)
            { }
        }
        //下拉框赋值
        function show_Hidden(v){    
            var value =  $(v).val();
            var hidden = $(v).next();//下拉框下个兄弟节点
            hidden.val(value);
            var txtOther =  $(v).next().next();
            if(value =="其他"){
                txtOther.show();
            }
            else
            {
                txtOther.hide();
            }
        }
        var numrow =1;//默认行数
        //增加一行
        function addrow(e,idname,obj)
        {var TextBoxNo = 0;//从0开始 内第几个input，
            $("#jzqk1 tr").find("input").each(function () {
               
                Modetype = $(this).val();
                if("请选择" == Modetype )
                {
                    alert("请选择费用");
                    return false;
                }
            })
            if(numrow>=6)
            {
                alert("限制申请事项6行");
                return;
            }
            numrow++;
            var copytr = $("#" + idname + " tr").first().clone();
            if(obj != null && obj != undefined && isjson(obj))
            {
                for(var k in obj) {
                    $(copytr).find("select[name=" + k + "]").val(obj[k]);
                    if($(copytr).find("select[name=" + k + "]").val() == '其他'){
                        var select =  $(copytr).find("select[name=" + k + "]")
                        var txtOther = $(select).next().next();
                        txtOther.show();
                    }
                    $(copytr).find("input[name=" + k + "]").val(obj[k]);
                    //遍历对象，k即为key，obj[k]为当前k对应的值
                    //   console.log(k);
                }
                 
            }
            else
            {
           
                $(copytr).find("input[type=text]").val("");
                $(copytr).find("input[type=hidden]").val("请选择");
            }
            $(copytr).find("[dateplugin='datepicker']").each(function(){
                $(this).removeAttr("id").removeAttr("class");
                $(this).datepicker();
            });
            $("#" + idname).append(copytr);
        
            return;
        }
        function isjson(obj){
            var isjson = typeof(obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length; 
            return isjson;
        }
      
      
    </script>
    <style type="text/css">
        /*#ctl00_ContentPlaceHolder1_rdbIsLawE td {
            border: 0;
        }

        .auto-style3 {
            width: 180px;
        }
        .auto-style4 {
            width: 110px;
        }
        .auto-style5 {
            height: 23px;
        }
        p{margin:0}*/
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div style='text-align: center; width:640px; margin: 0 auto;'>
      
        <div style='text-align: center' id="body1">
           
       <style type="text/css">
       .printcss {
        font-size: 14px; color: #ff0000; 
        
        }
          </style>
       <div class="printcss">
           <!--打印正文开始-->
            <table id ="tbAround" width="700" >
                <tr>
                    <td colspan="4" style="text-align:right;padding-right:5px;">
                       <h1 style="text-align:center"> 临时借用资金申请表</h1>
                        No：<asp:Label ID="txtApplyID" runat="server" Text="2018-03-07" style="font-weight:500;"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-weight: bold;text-align:left;width:100%;font-size:15px;line-height:29px" class="auto-style4"> &nbsp;&nbsp;
                        部门: <asp:Label  ID="txtDepartment" runat="server" Text="2018-03-07" style="font-weight:500;padding-right:20px;"></asp:Label>&nbsp;&nbsp;申请日期：<asp:Label ID="lbApplyDate" runat="server" Text="2018-03-07" style="font-weight:500;padding-right:20px;"></asp:Label>&nbsp;&nbsp;
                        需要日期：<asp:Label ID="txtNeedDate" runat="server" Text="2018-03-07" style="font-weight:500;padding-right:20px;"/> &nbsp;&nbsp;电话/传真：<asp:Label ID="txtReplyPhone" runat="server" Text="2018-03-07" style="font-weight:500"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table style="width:99%" border-collapse: collapse; text-align: center;margin:0 auto">
                               <tr>
                    <td colspan="2" style="font-weight: bold;font-size:12px">申 请 事 项</td>
                    <td colspan="2" style="font-weight: bold;font-size:12px; width:40%">支 付 方 式</td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="6" >
                        <%--<asp:TextBox ID="txtReason" runat="server" Height="100px" TextMode="MultiLine" Width="95%"></asp:TextBox>--%>
                        <table style="width:99%;font-weight:500;" border-collapse: collapse; text-align: center;margin:0 auto ">
                              <tbody id="jzqk1">
                                           <%-- <tr>
                                                 <td colspan="3" style="font-weight: bold;width:70%;font-size:12px" class="auto-style4">
                                                   <input  type="text" name="month" style=" border:0"/>
                                               
                                                </td>
                                                 <td>￥
                                                     <input type="text" style="width:50px;border:0" name="UnitPrice" emptymes="请填写单价" onchange="PriceChange();" />
                                                   
                                                 </td>
                                            </tr>--%>
                                        </tbody>
                        
                        </table>
                         <asp:HiddenField ID="hidDetail1" runat="server" />
                    </td>
                    <td rowspan="6" style="width:10%">
                        <asp:CheckBox ID="cbPayK1" runat="server" Text="汇款" /><br /><br />
                        <asp:CheckBox ID="cbPayK2" runat="server" Text="现金" /><br /><br />
                        <asp:CheckBox ID="cbPayK3" runat="server" Text="支票" />
                    </td>
                    <td class="tl PL10" style="font-size:12px">账户名称:
                    </td>
                    </tr>
                            <tr>
                                <td> <asp:Label ID="txtAcount" runat="server" style="font-weight:500;"/></td>
                            </tr>
                <tr>
                    <td class="tl PL10" style="font-size:12px">账　　号:

                    </td>
                </tr>
                  <tr>
                                <td> <asp:Label ID="txtAname" runat="server" style="font-weight:500;"/></td>
                </tr>
                <tr>
                    <td  class="tl PL10" style="font-size:12px">开户银行:<br/>

                    </td>
                </tr>
                  <tr>
                   <td> <asp:Label ID="txtBank" runat="server" style="font-weight:500;"/></td>
                </tr>
             </table>
                    </td>
                </tr>
                <tr>
                    <td class="tl PL10" colspan="4" style="font-size:17px;text-align:left ;font-weight: bold">
                        金额：￥<asp:Label id="lMoney" runat="server" style="padding-right:80px;"/><%--<input type="hidden" runat="server" id="hilMoney"/>--%>                
                        人民币: <asp:Label id="lBWMoney" runat="server" style="padding-right:80px;"/> <%--<input type="hidden" runat="server" id="hilBWMoney"/>--%>
                   
                    
                       <%-- 财务支出合计: ￥<asp:Label id="Label1" runat="server" style="padding-right:80px;"/> 
                    
                          财务冲借支合计: ￥<asp:Label id="Label2" runat="server"/> --%>
                     </td>
                </tr>
               
                <tr>
                    <td class="tl PL10" colspan="4" style="font-size:12px">

                        申请报告编号: 
                        <asp:Label ID="txtApplyNo" runat="server" style="font-weight:500;"/>
                    </td>
                    <%--<td class="tl PL10" colspan="2" style="font-size:12px">
                        借支冲帐记录: 
                        <asp:Label ID="txtDialog" runat="server" style="font-weight:500;"/>
                    </td>--%>
                </tr>
                <tr>
                    <td style="font-size:15px;text-align:left;">
                        申请人： <asp:Label ID="txtApplyName" runat="server" style="font-weight:500;"/>
                          </td>
                    <td colspan="2" style="font-size:15px;text-align:left;">
                        部门主管： <asp:Label ID="txtDepartmentHead" runat="server"/>
                        </td>
                   
                     <td style="font-size:15px;text-align:left;width:20%">
                        部门负责人:<asp:Label ID="txtHeadOfTheDepartment" runat="server" style="font-weight:500;"/>
                    </td>
                </tr>
                <tr>
                    <td style="font-size:15px;text-align:left; width:20%;height:30px">财务部审批：</td>
                    <td colspan="2"></td>
                     <td style="font-size:15px;text-align:left; width:20%">出纳人：</td>
                   
                </tr>
                <tr>
                    <td style="font-size:15px;text-align:left;">
                        董事总经理审批：</td>
                        <td style="width:20%">
                           <input type="checkbox" value="同意"/> 同意  <input type="checkbox" value="不同意"/>不同意
                         </td>
                    <td colspan="2"></td>
                  
                </tr>
                <tr>
                    <td  class="tl PL10" colspan="4" style="font-size:15px;text-align:left;font-weight: bold">
                        <span style="padding-right:144px">收款金额：￥</span>  <span style="padding-right:144px">收款人：</span>  <span>签收日期：</span>
                    </td>
                </tr>
                </table>
            <br />
            <!--打印正文结束-->
                <script type="text/javascript">
                    $("#tbAround2 input").css({ "border": "1px solid #98b8b5" });
                </script>
        </div>
            </div>
   <%--<input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');"  />--%>
     
   <input type="button" id="btnPrint" value="打印"  />
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        $("#btnPrint").click(function () {
            $("#body1").printArea();
        });
    </script>
          </div>
</asp:Content>