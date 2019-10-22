<%@ Page ValidateRequest="false" Title="公章使用申请表(项目部) - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_ProjOfficialSeal_Detail.aspx.cs" Inherits="Apply_ProjOfficialSeal_Apply_ProjOfficialSeal_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1;
        var jJSON = <%=SbJson.ToString() %>;
		var flowsl = '<%=flowsl %>';

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        $(function() {      
            $("[id*=btnSureUse]").css({
                "background-image": "url(/Images/btnSureUse1.png)",
                "height": "25px", 
                "width": "77px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnSureUse]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureUse2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureUse1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureUse1.png)"); });

            $("[id*=btnCantUse]").css({
                "background-image": "url(/Images/btnApplyOutT1.png)",
                "height": "25px", 
                "width": "71px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnCantUse]").mousedown(function () { $(this).css("background-image", "url(/Images/btnApplyOutT2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnApplyOutT1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnApplyOutT1.png)"); });

            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {
		            $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});
		    $("#<%=txtSureDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {
		            $("#<% =hdSureDepartment.ClientID%>").val(ui.item.id);
		        }
		    });
		     

		    i = $("#tbDetail tr").length - 1;
		    //for (var x = 1; x < i; x++) {
		    //    $("#txtDepartment"+ x).autocomplete({source: jJSON});
		    //}

		    $("#<%=txtRecyclingData.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    $("#<%=txtSureData.ClientID%>").datepicker({
		        showButtonPanel: true,
		        showOtherMonths: true,
		        selectOtherMonths: true,
		        changeMonth: true,
		        changeYear: true
		    });

		    for (var x = 1; x <= i; x++) {
		        $("#txtAgentBeginData" + x).datepicker({ //使详情表的日期变得可选
		            showButtonPanel: true,
		            showOtherMonths: true,
		            selectOtherMonths: true,
		            changeMonth: true,
		            changeYear: true
		        });

		        $("#txtAgentEndData" + x).datepicker({ //使详情表的日期变得可选
		            showButtonPanel: true,
		            showOtherMonths: true,
		            selectOtherMonths: true,
		            changeMonth: true,
		            changeYear: true
		        });
		    }
		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

		function check() {

	        
		    if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("发文部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
            }
			
            if($.trim($("#<%=txtFileCount.ClientID %>").val())=="") {
	            alert("申请盖章文件的份数不可为空！");
	            $("#<%=txtFileCount.ClientID %>").focus();
	            return false;
            }



            if($.trim($("#<%=txtSureDepartment.ClientID %>").val())=="") {
	            alert("确认盖章部门不可为空！");
	            $("#<%=txtSureDepartment.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtSureMenber.ClientID %>").val())=="") {
	            alert("确认盖章人员不可为空！");
	            $("#<%=txtSureMenber.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtSurePhone.ClientID %>").val())=="") {
	            alert("确认人电话不可为空！");
	            $("#<%=txtSurePhone.ClientID %>").focus();
	            return false;
            }

            if($.trim($("#<%=txtSureData.ClientID %>").val())=="") {
	            alert("确认盖章日期不可为空！");
	            $("#<%=txtSureData.ClientID %>").focus();
	            return false;
            }



            if (!$("#<%=rdbSpecies1.ClientID %>").prop("checked") && !$("#<%=rdbSpecies2.ClientID %>").prop("checked")) {
	            alert("请选择申请盖章的种类");
	            $("#<%=rdbSpecies1.ClientID%>").focus();
	            return false;
            }

            if (!$("#<%=rdbFileSpecies1.ClientID %>").prop("checked") && !$("#<%=rdbFileSpecies2.ClientID %>").prop("checked") && !$("#<%=rdbFileSpecies3.ClientID %>").prop("checked")) {
	            alert("请选择申请盖章文件的种类");
	            $("#<%=rdbFileSpecies1.ClientID%>").focus();
	            return false;
            }

            if ($("#<%=rdbSpecies2.ClientID%>").prop("checked")) {
	            if ($.trim($("#<%=txtAnotherSeal.ClientID%>").val()) == "") { alert("由于您选了其它印章，所以必须写上印章名称！"); $("#<%=txtAnotherSeal.ClientID%>").focus(); return false; }
	        }

            if ($.trim($("#<%=txtAnotherFile.ClientID%>").val()) == "") { alert("请填写对佣/请款金额！"); $("#<%=txtAnotherFile.ClientID%>").focus(); return false; }

	        var data = "";
	        var flag = true;
	        //如果详细只有一行，且该行个人资料为空
	        //if($("#tbDetail tr").size() == 2 && $.trim($("#txtCountOffTime1").val()) == "" && $.trim($("#txtDealNo1").val()) == "" && $.trim($("#txtOtherDataAddress1").val()) == "" && $.trim($("#txtChangeSituation1").val()) == "" && $.trim($("#txtChangeReason1").val()) == "")
	        //    data="||";
	        //$("#tbDetail tr").each(function(n) {
	        //    if (n != 0 && n != $("#tbDetail tr").size()) {
	        //        data += $.trim($("#txtDivision" + n).val()) + "&&" + $.trim($("#txtName" + n).val()) + "&&" + $.trim($("#txtNumber" + n).val()) + "&&" + $.trim($("#txtTime" + n).val()) + "&&" + $.trim($("#txtEndTime" + n).val()) + "||";
	        //    }
	        //});

	        $("#tbDetail tr").each(function(n) {
	            if (n != 0 && n != $("#tbDetail tr").size()) {
	                if($.trim($("#selTransFile" + n).find("option:selected").text()) == "请选择"){
	                    alert("请选择第" + n + "行的事务文件"); 
	                    $("#selTransFile" + n).focus();
	                    flag = false;
	                    return;
	                }
	                if (
                            $.trim($("#selTransFile" + n).find("option:selected").text()) == "项目代理合同"
                            || $.trim($("#selTransFile" + n).find("option:selected").text()) == "项目合作协议（电商/发展商）"
                            || $.trim($("#selTransFile" + n).find("option:selected").text()) == "项目中介服务合同"
                            || $.trim($("#selTransFile" + n).find("option:selected").text()) == "项目续约协议"
                        ) 
	                {
	                    if ($.trim($("#txtAgentBeginData" + n).val()) == "") 
	                    { 
	                        alert("第" + n + "行的事务文件需填写代理期"); 
	                        $("#txtAgentBeginData" + n).focus();
	                        flag = false;
	                        return;
	                    }
	                    else if ($.trim($("#txtAgentEndData" + n).val()) == "") 
	                    { 
	                        alert("第" + n + "行的事务文件需填写代理期"); 
	                        $("#txtAgentEndData" + n).focus();
	                        flag = false;
	                        return;
	                    }
	                }	
	                if ($.trim($("#txtBN" + n).val()) == "") {
	                    alert("第" + n + "行的项目（楼盘）名称/文件名称必须填写。");
	                    $("#txtBN" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtCompany" + n).val()) == "") {
	                    alert("第" + n + "行的对方公司名称必须填写。");
	                    $("#txtCompany" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtUse" + n).val()) == "") {
	                    alert("第" + n + "行的用途必须填写。");
	                    $("#txtUse" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data += $.trim($("#selTransFile" + n).find("option:selected").text()) 
                            + "&&" + $.trim($("#txtFileName" + n).val()) 
                            + "&&" + $.trim($("#txtAgentBeginData" + n).val()) 
                            + "&&" + $.trim($("#txtAgentEndData" + n).val()) 
                            + "&&" + $.trim($("#txtBN" + n).val())//.replace(/\r\n/g,"，").replace(/\n/g,"，")
                            + "&&" + $.trim($("#txtCompany" + n).val()) 
                            + "&&" + $.trim($("#txtUse" + n).val()) + "||";
	            }
	        });

	        if (flag) {
	            data = data.substr(0, data.length - 2);
	            $("#<%=hdDetail.ClientID %>").val(data);
            }
            else
                return false;
			  

        }

        function checkChecked() {
            var gv = document.getElementById('<%=gvAttach.ClientID%>'); 
		    var input = gv.getElementsByTagName("input"); 
		    var flagCheck = false;

		    for (var i = 0; i < input.length; i++) {
		        if (input[i].type == 'checkbox' && !input[i].disabled && input[i].checked){
		            flagCheck = true;
		            break;
		        }
		    }
			
		    if(!flagCheck)
		        alert("请勾选文件再下载！");
				
		    return flagCheck;
		}

		function upload() {
		    var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
		    if(sReturnValue=='success')
		        window.location='Apply_OfficialSeal_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_OfficialSeal_Flow.aspx?MainID=<%=MainID %>&dpm="+flowsl+"","","dialogWidth=800px;dialogHeight=320px");
		    if(win=='success')
		        window.location="Apply_OfficialSeal_Detail.aspx?MainID=<%=MainID %>";
                }
		
                function CancelSign(idc) {
                    if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
                    {
                        $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
        function sign(idx) {
            //if(idx == '106')
            //{
            //    if(confirm("是否确认签名？"))
            //    {
            //$("#<%=hdIsAgree.ClientID %>").val("1");
            //document.getElementById("<%=btnSign.ClientID %>").click();//*-
            //        return;
            //    }
            //}
            //if(idx=='100' || idx == '106'){
            //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")) {

            //        alert("请确定是否同意！");
            //        return;
            //    }
            //}
            //else{
            //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
            //        alert("请确定是否同意！");
            //        return;
            //    }
            //}
            if(idx == '100')
            {
                if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
                    alert("由于您要退回申请，必须填写退回申请的原因。");
                    return;
                }
            }
            if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="" && idx != '106') {   
                alert("由于您不同意该申请，必须填写不同意的原因。");
                return;
            }

            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                alert("请确定是否同意！");
                return;
            }
			
            if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
                alert("由于您不同意该申请，必须填写不同意的原因。");
                return;
            }
            if($("#rdbOtherIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
                alert("由于您选其他意见，必须填写意见。");
                return;
            }

            if(confirm("是否确认审核？"))
            {
                if($("#rdbYesIDx"+idx).prop("checked"))
                    $("#<%=hdIsAgree.ClientID %>").val("1");
				else if($("#rdbNoIDx"+idx).prop("checked"))
				    $("#<%=hdIsAgree.ClientID %>").val("0");
				else if($("#rdbOtherIDx"+idx).prop("checked"))
				    $("#<%=hdIsAgree.ClientID %>").val("2");
				else
				{
				    if(idx == '100')
				        if($("#rdbNo2IDx"+idx).prop("checked"))
				            $("#<%=hdIsAgree.ClientID %>").val("0");
                }
					   
        getSuggestion(idx);
        document.getElementById("<%=btnSign.ClientID %>").click();
            }
        }  

        function getSuggestion(idx)
        {
            $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
		}
		
		function myPrint(start, end, extend) {    
		    //start = "<!--" + start + "-->";    
		    //end = "<!--" + end + "-->";    
		    //if (typeof (extend) == 'undefined') {        
		    //	var temp = window.document.body.innerHTML;        
		    //	var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
		    //	window.document.body.innerHTML = printhtml;        
		    //	window.print();        
		    //	window.document.body.innerHTML = temp;    
		    //}    
		    //else { window.print(); }
		    cMyPrint();
		}

		function addRow() {
		    i++;
            <%
                dst =  da_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit.SelectFileSpecies();
                int detailCount = dst.Tables[0].Rows.Count;
                string[] emst;
            %>
		    var html = '<tr id="trDetail' + i + '">'
                + '         <td class=\"tl PL10\" style="line-height: 30px; padding: 10px;" colspan="4">'
                //+ '             项目（楼盘）名称/文件名称：<input type="text" id="txtBN' + i + '" style="width:420px"/><br/>'
                + '             <span style="vertical-align: top;margin-top: 10px;">项目（楼盘）名称/文件名称：</span><textarea id="txtBN' + i + '" rows="3" style="width:420px;"/></textarea><br/>'
                + '             对方公司名称：<input type="text" id="txtCompany' + i + '" style="width:493px"/><br/>'

                + '             事务文件：<select id="selTransFile' + i + '" style="width:280px">'
                + '             <option>请选择</option>'
		                        <%for (int n2 = 0; n2 < detailCount; n2++)%>
		                        <%{%>
                                    <%drt = dst.Tables[0].Rows[n2];%>
                + '                   <optgroup label="<%=drt["t_OfficeAutomation_Document_OfficialSeal_FileSpecies_Name"].ToString()%>">'
		                                <%emst = drt["t_OfficeAutomation_Document_OfficialSeal_FileSpecies_Kind"].ToString().Split('、');%>
                                        <%for (int i2 = 0; i2 < emst.Length; i2++)%>
                                        <%{%>
                + '                         <option><%=emst[i2]%></option>'
                                        <%}%>
                + '                   </optgroup>'  
		                        <%}%>
                + '             </select>' 

                + '             代理期(可选)：<input type="text" id="txtAgentBeginData' + i + '" style="width:70px">～<input type="text" id="txtAgentEndData' + i + '" style="width:70px"/><br />'
                + '             物业地址(可选)：<input type="text" id="txtFileName' + i + '" style="width:485px"/><br/>'
                + '             <span style="vertical-align: top;margin-top: 20px;">用　途：</span><textarea id="txtUse' + i + '" rows="3" style="width: 528px;margin-top: 8px; overflow: auto;"></textarea><br />'

                + '         </td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
            $("#trFlag").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");

            $("#txtAgentBeginData"+ i).datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
            $("#txtAgentEndData"+ i).datepicker({
                showButtonPanel: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true
            });
        }

        function deleteRow() {
            if (i > 1) {
                i--;
                $("#tbDetail tr:eq(" + i + ")").remove();
            } 
            else
                alert("不能删除第1行。");
        }
        function DeleteT() { //20141231：M_DeleteC
            $("#btnADelete").hide();
            var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
		    var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
		    if(sReturnValue=='deleted')
		        window.location='/Apply/Apply_Search.aspx';
		    else
		        window.location.href=window.location.href;
		}
	</script>
    <style type="text/css">
        .auto-style1 {
            width: 20%;
        }
        #ctl00_ContentPlaceHolder1_rdbIsLawE td{border:0;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="summaryLeft" style="float: left; width: 25%; padding-top: 75px; padding-left: 5px; display:none; padding-right: 10px;">

    </div>
    <div id="summaryRight" style="float: right; width: 20%; padding-top: 75px; padding-right: 5px;display:none; padding-left: 10px;">
        <span style="font-weight: bold">　　
            1、请分行正确选择“事务文件”类别（如该项选择错误，文件无法按流程审批）；<br />
        　　2、录入“文件名称”时请按文件全名填写，以便系统查询；<br />
        　　3、如文件资料类型审批流程不同而用在同类性质的，可添加新行录入一份申请上。
        </span>
        <br /><br />
        <span style="font-size: large; font-weight: bold;">　　外联部—事务文件（办理租赁登记需提供街道文件：<span style="color: #FF0000">审批流程：申请部门-外联部</span>）申请盖章时录入使用目的</span>
        <br /><br />
        <span>　　《解除或变更房屋租赁合同申请表》、公司证件、租赁合同复印件（报街道或税用）、房屋的情况说明等办理租赁登记所需其他街道证明文件</span>
        <br /><br />
        <span>　　关于涉及公司租铺合同资料（<span style="color: #FF0000">审批流程：申请部门-外联部-法律部</span>）：租赁合同、开具租金发票证明、补充协议、退租协议、分行租铺调整协议、减租协议、变更业主的三方协议</span>
        <br /><br />
        <span style="font-size: large; font-weight: bold;">　　行政部—事务文件（装修、消防、水电费、话费<span style="color: #FF0000">审批流程：申请部门-行政部</span>）</span>
        <br /><br />
        <span>　　车辆险、公司责任险、分行物品财产保险变更、退保申请、投保申请、索赔文件、工程类文件 （如验收图纸、线路图确认、装修承诺书、工程（装修、消防、物品放行、印鉴表）等）、电信宽带业务（ADSL）、电信业务单（电话线开、撤、停）、话费查询申请、代扣电话、话费申请、<span style="font-weight: bold;">行政部涉及费用合同</span>（<span style="color: #FF0000">审批流程：申请部门-行政部-法律部</span>）</span>【网络IT合同（购买/租赁设备、办公设备服务、软件服务）、清洁合同、饮用水合同、工程安装合同、制作合同、发布合同、空调采购合同、消防合同、防盗系统合同、电信合同、装修合同等合同类】</span>
        <br /><br />
        <span style="font-size: large; font-weight: bold;">　　人力资源部—事务文件：（<span style="color: #FF0000">审批流程：申请部门-HR</span>）</span>
        <br /><br />
        <span>
                <span style="margin-left:22px;">核查员工在职情况<span style="color: #008000">（申请部门—增加朱晓晴或邱超琼或张晓莹签批—盖章）</span><br />
            　　在职或收入证明<span style="color: #008000">（申请部门-增加朱晓晴或张晓莹批签-郑纯宁-盖章）</span><br />
                <span style="margin-left:22px;">营执（旅游）</span><span style="color: #008000">（申请部门-朱晓晴或张晓莹批签-郑纯宁-盖章）</span><br />
            　　特殊津贴报销文件<span style="color: #008000">（申请部门-张晓莹-郑纯宁-盖章）</span><br />
            　　劳监部门检查等HR事务文件<span style="color: #008000">（申请部门-盖章）</span><br />
                <span style="margin-left:25px;">执业证复印件</span><span style="color: #008000">（申请部门-刘淑怡）</span><br />
            　　涉及招聘等合同类（费用1万以下）：<br />
                <span style="margin-left:25px;">(1)、营业部自主招聘类：大天河区/大白云区/花都区/工商铺一部/工商铺二部（<span style="color: #FF0000">审批流程：申请部门-王子君-郑纯宁</span>）；大越秀区/大海珠区/番禺一部（<span style="color: #FF0000">审批流程：申请部门-王子君-郑纯宁</span>）</span><br />
                <span style="margin-left:25px;">(2)、其他招聘类（含项目部）：（<span style="color: #FF0000">审批流程：申请部门-翁文格-郑纯宁</span>）</span>
                <span style="margin-left:25px;">(3)、涉及费用招聘合同/协议（含物业部及项目部)：（<span style="color: #FF0000">审批流程：申请部门-王子君/翁文格-郑纯宁-法律部</span>）</span>
        </span>
        <br /><br />
        <span style="font-size: large; font-weight: bold;">　　财务部—事务文件：（<span style="color: #FF0000">审批流程：申请部门-财务</span></span>
        <br /><br />
        <span>　　《1》发票证明、发票遗失<span style="color: #008000">（流程：申请部门-增加黄志超审批-黄志超-盖章）</span></span><br />
        <span>　　《2》公司账户证明、致银行（委托银行代划扣协议等）及税局的相关文件、开户/销户委托书、<span style="color: #008000">（如银行账户、网银业务办理等 ）（流程：申请部门-黄志超-盖章）</span></span><br />
        <span>　　《3》开户许可证<span style="color: #008000">（流程：申请部门-黄志超-盖章）</span></span>
        <br /><br />
        <span style="font-size: large; font-weight: bold;">　　涉及款项收付的文件：（<span style="color: #FF0000">审批流程：申请部门-财务-法律部</span>）</span>
        <br /><br />
        <span>
        　　《1》（拆街）合作协议（物业部）（<span style="color: #008000">流程：申请部门-（胡雅丝、或陈婉娜，冯琰，官东升，钟惠贤）签批-宁伟雄-法律部</span>）；<br />       
        　　《2》物业部自接项目收佣明细/成交明细表（<span style="color: #008000">流程：申请部门-（胡雅丝或陈婉娜，冯琰，官东升，钟惠贤）签批-法律部</span>）<br />        
        　　《3》授权公司人员领取物业部自接项目“佣金授权书”（<span style="color: #008000">流程：申请部门-财务（胡雅丝或陈婉娜，冯琰，官东升，钟惠贤）-HR朱晓晴-法律部</span>）<br /> 
        　　《4》项目部申请的收佣明细及一手项目委托收款证明（<span style="color: #008000">流程：申请部门-法律部审核</span>）<br /> 
            《5》支付证明（涉及拆街）（<span style="color: #008000">流程：申请部门-财务（胡雅丝或陈婉娜，冯琰，官东升，钟惠贤）-财务宁伟雄）-法律部</span>）<br /> 
            《6》支付证明（不涉及拆街）（<span style="color: #008000">流程：申请部门-黄志超签批</span>）<br /> 
        　　《7》退水电按金付款方证明（<span style="color: #008000">流程：申请部门-黄志超签批-法律部</span>）<br /> 
        　　《8》授权人员领取佣金支票证明（<span style="color: #008000">流程：申请部门-朱晓晴</span>）<br /> 
        　　《9》拆街合作协议（项目部）（<span style="color: #008000">流程：申请部门-吴惠卿-宁伟雄-法律部</span>）。
        </span>
        <br /><br />
        <span style="font-size: large; font-weight: bold;">　　法律部—涉及金钱合同/协议需经法律部协助审批的文件：（<span style="color: #FF0000">审批流程：申请部门-法律部</span>）</span>
        <br /><br />
        <span>
        　　《1》一手项目合同/协议、项目投标及封条、催款函、二手交易佣金确认书（咨询及中介服务费确认书）、中介付款通知书、二手交易的买卖/租赁合同、中介服务合同、客户确认书、客户确认及参观登记表等、其他合同（活动类等）。<br />
        　　《2》项目部一手/物业部一手/一二手联动/合同类：包括项目代理合同、项目合作协议（电商/发展商）、项目中介服务合同、项目续约协议。
        </span>
        <br /><br />
        <span style="font-size: large; font-weight: bold;">　　品牌营销—事务文件：</span>
        <br /><br />
        <span>
        　<%--　《1》微信认证（<span style="color: #008000">流程：申请部门-潘慧敏-李粤湘-法律部</span>）；<br />       --%>
        　　《1》区域广告位合同、广日报纸广告合同（<span style="color: #008000">流程：申请部门-刘秀霞-李粤湘-法律部</span>）<br />        
        　　《2》网络端口合同（<span style="color: #008000">流程：申请部门-李凤娟-李粤湘-法律部</span>）<br /> 
        　　《3》参加中介协会会议等提交资料（<span style="color: #008000">流程：申请部门-李粤湘</span>）<br />
            《4》自媒体文件（<span style="color: #008000">流程：：申请部门-授权人潘慧敏签批（或自行选择）-李粤湘签批-法律部-完成可盖章。</span>）
        </span>
        <br /><br /><br /><br />
    </div>
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 640px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
        <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>公章使用申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:640px;margin:0 auto; text-align: right;"><span style="text-align: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround" width='640px'>
				<tr>
					<td>申请盖章部门</td>
					<td class="tl PL10" ><asp:textbox id="txtDepartment" runat="server"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td style="width: 20%; ">申请盖章日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
				<tr>
                    <td rowspan="2">申请盖章的种类</td>
                    <td rowspan="2" class="tl PL10">
                        <asp:RadioButton ID="rdbSpecies1" runat="server" Text="公　　章" GroupName="3" /><br />
                        <asp:RadioButton ID="rdbSpecies2" runat="server" Text="其它印章" GroupName="3" /><br />
                        <asp:TextBox ID="txtAnotherSeal" runat="server"></asp:TextBox>
                    </td>
                    <td>申请盖章人员</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
				</tr>
                <tr>
                    <td>联系电话</td>
					<td class="tl PL10"><asp:TextBox ID="txtBranchPhone" runat="server"></asp:TextBox></td>
                </tr>
				<tr>
                    <td >申请盖章文件的种类</td>
					<td class="tl PL10" colspan="3">
                        <asp:RadioButton ID="rdbFileSpecies1" runat="server" Text="合同/协议" GroupName="4" />
                        <asp:RadioButton ID="rdbFileSpecies2" runat="server" Text="对佣/请款" GroupName="4" />
                        <asp:RadioButton ID="rdbFileSpecies3" runat="server" Text="其它文件" GroupName="4" />　
                        对佣/请款金额<asp:TextBox ID="txtAnotherFile" runat="server"></asp:TextBox>
					</td>
				</tr>

				<tr>
					<td class="tl PL10 PR10" colspan="4">
						<span style="font-weight: bolder">用途明细表</span><br /><br />
						<table id="tbDetail" class='sample tc' width='100%'>
          
                            <%=SbHtml.ToString()%>

                            <tr id="trFlag">
                                <td class="tl PL10" colspan="4">
                                    申请盖章文件的份数
                                    <asp:textbox ID="txtFileCount" runat="server" Width="55px"></asp:textbox>
                                    编号/成交编号(可选)
                                    <asp:textbox ID="txtApplyID" runat="server" Width="112px"></asp:textbox>
                                    预计回收日期(可选)
                                    <asp:textbox ID="txtRecyclingData" runat="server" Width="75px"></asp:textbox>
                                </td>
                            </tr>

						</table>
                        <br />
                        
						<input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
					</td>
				</tr>
                

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style1">授权签批人员</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style1">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
                        <textarea id="txtIDx2" rows="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>
					</td>
				</tr>

                <tr id="trM3" style="height: 85px; display:none;">
					<td class="auto-style1" style=" ">IT部意见</td>
					<td colspan="3" class="tl PL10"  style="  ">
						<input id="rdbYesIDx3" type="radio" name="agree3" />
                        <label for="rdbYesIDx3">同意</label>
                        <input id="rdbNoIDx3" type="radio" name="agree3" />
                        <label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx3" value="签署意见" onclick="sign('3')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>
					</td>
				</tr>

                <tr id="trM4" class="noborder" style="height: 85px; display:none;">
					<td class="auto-style1" style=" ">行政部意见</td>
					<td colspan="3" class="tl PL10"  style="  ">
						<input id="rdbYesIDx4" type="radio" name="agree4" />
                        <label for="rdbYesIDx4">同意</label>
                        <input id="rdbNoIDx4" type="radio" name="agree4" />
                        <label for="rdbNoIDx4">不同意</label>
                        <input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx4" value="签名" onclick="sign('4')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>
					</td>
				</tr>

                <tr id="trM11" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1">财务部</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx11" type="radio" name="agree11"/>
                        <label for="rdbYesIDx11">同意</label>
                        <input id="rdbNoIDx11" type="radio" name="agree11" />
                        <label for="rdbNoIDx11">不同意</label><br />
						<textarea id="txtIDx11" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx11" value="签署意见" onclick="sign('11')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx11">_________</span></div>
					</td>
				</tr>

                <tr id="trM13" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1">人力资源部意见</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx13" type="radio" name="agree13"/>
                        <label for="rdbYesIDx13">同意</label>
                        <input id="rdbNoIDx13" type="radio" name="agree13" />
                        <label for="rdbNoIDx13">不同意</label>
                        <input id="rdbOtherIDx13" type="radio" name="agree13" /><label for="rdbOtherIDx13">其他意见</label><br />
						<textarea id="txtIDx13" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx13" value="签署意见" onclick="sign('13')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx13">_________</span></div>
					</td>
				</tr>
                <tr id="trM14" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1">人力资源部意见</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx14" type="radio" name="agree14"/>
                        <label for="rdbYesIDx14">同意</label>
                        <input id="rdbNoIDx14" type="radio" name="agree14" />
                        <label for="rdbNoIDx14">不同意</label>
                        <input id="rdbOtherIDx14" type="radio" name="agree14" /><label for="rdbOtherIDx14">其他意见</label><br />
						<textarea id="txtIDx14" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx14" value="签署意见" onclick="sign('14')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx14">_________</span></div>
					</td>
				</tr>

                <tr id="trM15" style="height: 85px; display:none;">
					<td style=" " class="auto-style1">人力资源部意见</td>
					<td colspan="3" class="tl PL10"  style="  ">
						<input id="rdbYesIDx15" type="radio" name="agree15" />
                        <label for="rdbYesIDx15">同意</label>
                        <input id="rdbNoIDx15" type="radio" name="agree15" />
                        <label for="rdbNoIDx15">不同意</label>
                        <input id="rdbOtherIDx15" type="radio" name="agree15" /><label for="rdbOtherIDx15">其他意见</label><br />
						<textarea id="txtIDx15" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx15" value="签署意见" onclick="sign('15')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx15">_________</span></div>
					</td>
				</tr>
				<tr id="trM16" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1">人力资源部意见</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx16" type="radio" name="agree16"/>
                        <label for="rdbYesIDx16">同意</label>
                        <input id="rdbNoIDx16" type="radio" name="agree16" />
                        <label for="rdbNoIDx16">不同意</label>
                        <input id="rdbOtherIDx16" type="radio" name="agree16" /><label for="rdbOtherIDx16">其他意见</label><br />
						<textarea id="txtIDx16" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx16" value="签署意见" onclick="sign('16')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx16">_________</span></div>
					</td>
				</tr>
                <tr id="trM17" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1">人力资源部意见</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx17" type="radio" name="agree17"/>
                        <label for="rdbYesIDx17">同意</label>
                        <input id="rdbNoIDx17" type="radio" name="agree17" />
                        <label for="rdbNoIDx17">不同意</label>
                        <input id="rdbOtherIDx17" type="radio" name="agree17" /><label for="rdbOtherIDx17">其他意见</label><br />
						<textarea id="txtIDx17" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx17" value="签署意见" onclick="sign('17')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx17">_________</span></div>
					</td>
				</tr>

                <tr id="trM12" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1" style=" ">财务部</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx12" type="radio" name="agree12"/>
                        <label for="rdbYesIDx12">同意</label>
                        <input id="rdbNoIDx12" type="radio" name="agree12" />
                        <label for="rdbNoIDx12">不同意</label><br />
						<textarea id="txtIDx12" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx12" value="签署意见" onclick="sign('12')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx12">_________</span></div>
					</td>
				</tr>
                <tr id="trM18" style="height: 85px; display:none;">
					<td style=" " class="auto-style1" style=" ">财务部</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx18" type="radio" name="agree18" />
                        <label for="rdbYesIDx18">同意</label>
                        <input id="rdbNoIDx18" type="radio" name="agree18" />
                        <label for="rdbNoIDx18">不同意</label><br />
						<textarea id="txtIDx18" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx18" value="签署意见" onclick="sign('18')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx18">_________</span></div>
					</td>
				</tr>

                <tr id="trM19" style="height: 85px; display:none;">
					<td style=" " class="auto-style1" style=" ">财务部</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx19" type="radio" name="agree19" />
                        <label for="rdbYesIDx19">同意</label>
                        <input id="rdbNoIDx19" type="radio" name="agree19" />
                        <label for="rdbNoIDx19">不同意</label><br />
						<textarea id="txtIDx19" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx19" value="签署意见" onclick="sign('19')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx19">_________</span></div>
					</td>
				</tr>
				<tr id="trM20" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1" style=" ">财务部</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx20" type="radio" name="agree20" />
                        <label for="rdbYesIDx20">同意</label>
                        <input id="rdbNoIDx20" type="radio" name="agree20" />
                        <label for="rdbNoIDx20">不同意</label>
                        <span id="sp20" style="display:none;">
                            【　<asp:LinkButton ID="lbOCDeptm" runat="server" OnClick="lbOCDeptm_Click">外联部加签意见</asp:LinkButton>　
                            <asp:LinkButton ID="lbCoculate" runat="server" OnClick="lbCoculate_Click">计佣组加签意见</asp:LinkButton>　】
                        </span>
                        <br />
						<textarea id="txtIDx20" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx20" value="签署意见" onclick="sign('20')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx20">_________</span></div>
					</td>
				</tr>
                <tr id="trM25" style="height: 85px; display:none;">
					<td style=" " class="auto-style1" style=" ">财务部</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx25" type="radio" name="agree25" />
                        <label for="rdbYesIDx25">同意</label>
                        <input id="rdbNoIDx25" type="radio" name="agree25" />
                        <label for="rdbNoIDx25">不同意</label><br />
						<textarea id="txtIDx25" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx25" value="签署意见" onclick="sign('25')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx25">_________</span></div>
					</td>
				</tr>

                <tr id="trM26" style="height: 85px; display:none;">
					<td rowspan="1" style=" " class="auto-style1">资讯科技部意见</td>
					<td colspan="3" class="tl PL10"  style="  ">
						<input id="rdbYesIDx26" type="radio" name="agree26" />
                        <label for="rdbYesIDx26">同意</label>
                        <input id="rdbNoIDx26" type="radio" name="agree26" />
                        <label for="rdbNoIDx26">不同意</label><br />
						<textarea id="txtIDx26" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx26" value="签署意见" onclick="sign('26')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx26">_________</span></div>
					</td>
				</tr>
                <tr id="trM27" style="height: 85px; display:none;">
					<td rowspan="1" style=" " class="auto-style1">品牌营销意见</td>
					<td colspan="3" class="tl PL10"  style="  ">
						<input id="rdbYesIDx27" type="radio" name="agree27" />
                        <label for="rdbYesIDx27">同意</label>
                        <input id="rdbNoIDx27" type="radio" name="agree27" />
                        <label for="rdbNoIDx27">不同意</label><br />
						<textarea id="txtIDx27" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx27" value="签署意见" onclick="sign('27')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx27">_________</span></div>
					</td>
				</tr>
                <tr id="trM28" style="height: 85px; display:none;">
					<td rowspan="1" style=" " class="auto-style1">品牌营销/<br />网络营销部意见</td>
					<td colspan="3" class="tl PL10"  style="  ">
						<input id="rdbYesIDx28" type="radio" name="agree28" />
                        <label for="rdbYesIDx28">同意</label>
                        <input id="rdbNoIDx28" type="radio" name="agree28" />
                        <label for="rdbNoIDx28">不同意</label><br />
						<textarea id="txtIDx28" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx28" value="签署意见" onclick="sign('28')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx28">_________</span></div>
					</td>
				</tr>
				<tr id="trM29" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1">资讯科技部意见</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx29" type="radio" name="agree29"/>
                        <label for="rdbYesIDx29">同意</label>
                        <input id="rdbNoIDx29" type="radio" name="agree29" />
                        <label for="rdbNoIDx29">不同意</label><br />
						<textarea id="txtIDx29" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx29" value="签署意见" onclick="sign('29')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx29">_________</span></div>
					</td>
				</tr>

                <tr id="trM30" class="noborder" style="height: 85px; display:none; ">
					<td class="auto-style1" style=" ">外联部意见</td>
					<td colspan="3" class="tl PL10"  style=" ">
						<input id="rdbYesIDx30" type="radio" name="agree30" />
                        <label for="rdbYesIDx30">同意</label>
                        <input id="rdbNoIDx30" type="radio" name="agree30" />
                        <label for="rdbNoIDx30">不同意</label>
                        <span id="addDepartment" style="display:none;">
                            【<asp:CheckBox ID="ckbLaw" runat="server" Text="法律部加签意见"  />
                            <asp:CheckBox ID="ckbFinancial" runat="server" Text="财部部加签意见"  />
                            <asp:CheckBox ID="cbHR" runat="server" Text="HR加签意见"  />　
                            <asp:LinkButton ID="lbnAddDepartment" runat="server" OnClick="lbnAddDepartment_Click">增加部门签批</asp:LinkButton>】
                        </span>
                        <br />

						<textarea id="txtIDx30" rows="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx30" value="签名" onclick="sign('30')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx30">_________</span></div>
					</td>
				</tr>

				<tr id="trM100" style="height: 85px; display:none;">
                    <td style=" " class="auto-style1" style=" ">法律部意见</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx100" type="radio" name="agree100"/>
                        <label for="rdbYesIDx100">同意</label>
                        <input id="rdbNoIDx100" type="radio" name="agree100" />
                        <label for="rdbNoIDx100">退回申请</label>
                        <asp:CheckBox ID="ckbAddIDx100" runat="server" Text="补签申请部门负责人知悉法律部意见"  Visible="false"/></label>
                        <span id="sp100" style="display:none;">
                            　【<asp:LinkButton ID="lbtnAddFinancial" runat="server" OnClick="lbtnAddFinancial_Click">财务部加签意见</asp:LinkButton>】
                        </span><br />
						<textarea id="txtIDx100" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx100" value="签署意见" onclick="sign('100')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx100">_________</span></div>
					</td>
				</tr>

                <tr id="trM105" style="height: 85px; display:none;">
					<td style=" " class="auto-style1" style=" ">外联部意见<br />(已添加审批环节)</td>
					<td colspan="3" class="tl PL10" style="  ">
						<input id="rdbYesIDx105" type="radio" name="agree105"/>
                        <label for="rdbYesIDx105">同意</label>
                        <input id="rdbNoIDx105" type="radio" name="agree105" value="2" />
                        <label for="rdbNoIDx105">不同意</label><br />
						<textarea id="txtIDx105" rows="3" style="width: 98%; overflow: auto;" cols="20" name="S1"></textarea>
                        <input type="button" id="btnSignIDx105" value="签名" onclick="sign('105')" style="display: none;" />
                        <div class="signdate">日期：<span id="spanDateIDx105">_________</span></div>
					</td>
				</tr>

                <tr id="trM102" style="display:none;">
                    <td colspan="4" style="text-align: left;">
                        <span  style="text-align: left; font-weight: bold; font-size: large; padding-left: 10px;">本人已知悉上述法律部意见，本人同意承担相关责任。</span>
                    </td>
                </tr>

                <tr id="trM106" class="noborder" style="height: 85px; display:none;">
					<td class="auto-style1" style=" ">部门负责人签字</td>
					<td colspan="3" class="tl PL10" style=" ">
                        <input id="rdbYesIDx106" type="radio" name="agree106"/>
                        <label for="rdbYesIDx106">同意</label>
                        <input id="rdbNoIDx106" type="radio" name="agree106" value="2" />
                        <label for="rdbNoIDx106">不同意</label><br />
                        <%#Eval("OfficeAutomation_Attach_Name")%>
                        <input type="button" id="btnSignIDx106" value="签名" onclick="sign('106')" style="display: none;" />
                        <div style="vertical-align: bottom; text-align: right; margin-right: 10px; margin-bottom: 5px">日期：<span id="spanDateIDx106">_________</span></div>
					</td>
				</tr>

                <tr id="trCcess" class="noborder" style="height: 30px; display: none;">
					<td class="auto-style4">法律部反馈意见</td>
					<td colspan="3" class="tl PL10">
                        <asp:Button ID="btnSureUse" runat="server" Text="确认使用" OnClick="btnSureUse_Click" Visible="False" />　
                        <asp:Button ID="btnCantUse" runat="server" Text="申请超期" OnClick="btnCantUse_Click" Visible="False" />　
                        <asp:Label ID="lbSee" runat="server" Text="申请超期" Visible="False" Font-Bold="True" Font-Size="50px" ForeColor="Red" BorderColor="Red" BorderWidth="3px" Height="55px"></asp:Label>
					</td>
				</tr>

                <tr>
                    <td colspan="4" style="text-align: center; font-weight: bold; font-size: large">
                        公章使用确认表
                    </td>
                </tr>
                <tr>
                    <td>申请确认盖章部门</td>
                    <td>
                        <asp:textbox ID="txtSureDepartment" runat="server"></asp:textbox>
                        <input type="hidden" id="hdSureDepartment" runat="server" />
                    </td>
                    <td>申请确认盖章人员</td>
                    <td>
                        <asp:textbox ID="txtSureMenber" runat="server"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>申请确认人电话</td>
                    <td>
                        <asp:textbox ID="txtSurePhone" runat="server"></asp:textbox>
                    </td>
                    <td>申请确认盖章日期</td>
                    <td>
                        <asp:textbox ID="txtSureData" runat="server"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>盖章专责人员</td>
                    <td>
                        <asp:textbox ID="txtSureCommissioner" runat="server"></asp:textbox>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Scr1" runat="server" Text="【附件上传文本仅作为项目部审批时查阅，公章盖章须以最后提交至法律部的文本为准】" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                
			</table>
			<!--打印正文结束-->
		</div>

        <div class="noprint">
		<asp:gridview id="gvAttach"  CssClass="gvAttach" align="center" runat="server" backcolor="White" style="clear: both; margin-top: 3px;"
			bordercolor="#DEDFDE" borderstyle="None" borderwidth="1px" cellpadding="4" autogeneratecolumns="false"
			forecolor="Black" gridlines="Vertical" onrowcommand="gvAttach_RowCommand">
			<Columns>
				<asp:TemplateField>
					<HeaderTemplate>
						<asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
					</HeaderTemplate>
					<ItemTemplate>
						<asp:CheckBox ID="chk" runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="删除" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
					<ItemTemplate>
						<asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID") %>' OnClientClick="return confirm('确认删除？');" />
						<asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID") %>' />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
					<ItemTemplate>
						<a id="link" href='<%=ConfigurationManager.AppSettings["EcoaFileURL"]%><%#Eval("OfficeAutomation_Attach_Path")%>' target="_blank"><%#Eval("OfficeAutomation_Attach_Name")%></a>
						<asp:HiddenField ID="hfPath" runat="server" Value='<%#Eval("OfficeAutomation_Attach_Path") %>' />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<RowStyle BackColor="#F7F7DE" />
			<FooterStyle BackColor="#CCCC99" />
			<PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
			<SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
			<%--<HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />--%>
			<AlternatingRowStyle BackColor="White" />
		</asp:gridview>
        <div id="PageBottom">
		<hr />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="False" />
            <asp:button runat="server" id="btnSAlterC" text="修改" visible="false" onclientclick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
		<input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
		<asp:button id="btnDownload" runat="server" text="下载选中附件" onclick="btnDownload_Click" onclientclick="return checkChecked();" style="margin-left: 5px;" visible="false" />
		<asp:button runat="server" id="btnSignSave" text="标注已留档" onclick="btnSignSave_Click" visible="false" />
		<input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始','打印正文结束');" style="display: none;" />
            <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
		<asp:button runat="server" id="btnBack" text="返回" onclick="btnBack_Click" />
		<asp:button id="btnSign" runat="server" onclick="btnSign_Click" style="display: none;" />
		<asp:hiddenfield id="hdIsAgree" runat="server" />
		<asp:hiddenfield id="hdSuggestion" runat="server" />
		<input type="hidden" id="hdDetail" runat="server" />
            <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应

        if($("#selTransFile1").val()=="微信认证")
        {
            $("#trM26").find(".auto-style1").html("企业传讯部");
            $("#trM29").find(".auto-style1").html("企业传讯部");
        }
    </script>
    </span>
    </asp:Content>
