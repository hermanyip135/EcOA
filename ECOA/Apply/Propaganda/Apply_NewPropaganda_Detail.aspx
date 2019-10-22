<%@ Page  ValidateRequest="false" Title="广告宣传需求申请表 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_NewPropaganda_Detail.aspx.cs" Inherits="Apply_Propaganda_Apply_NewPropaganda_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <style type="text/css">
        #tr2 label  {
            font-size:17px;
            font-weight:bold;
        }
        .quegao {
       background:url(../../images/btnquegao1.png) no-repeat;text-indent:99px;cursor:pointer;
       width:50px; height:26px
             }
        .btnSaveCityScore {
          background:url(../../images/btnprosave1.png) no-repeat;text-indent:99px;cursor:pointer;
       width:50px; height:26px
        }
        .btnReturnJumpIDx {
         background:url(../../images/btnAddDesign1.png) no-repeat;text-indent:99px;cursor:pointer;
         color:#ffffff; height:25px;width:95px;font-size:0px;border:0;
        }
         /*#tr1 label  {
            font-size:17px;
            font-weight:bold;
        }*/
    </style>
    <script type="text/javascript">
        debugger;
        var i = 1, i2 = 1;
        var jJSON = "<%=SbJson.ToString() %>";
		var isNewApply=('<%=IsNewApply%>'=='True');
       
        //var jaf = 20;//789
        //var deleteidxs = "";
        //var jJSONF = <%//=SbJsonf.ToString() %>;
        //function split( val ) {
        //    return val.split( /,\s*/ );
        //}
        //function extractLast( term ) {
        //    return split( term ).pop();
        //}

        $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

        $(function() { 
           
            if('<%=EmployeeName%>' == "王萍" || '<%=EmployeeName%>' == "周燕妮" || '<%=EmployeeName%>' == "招琛彤"  || '<%=EmployeeName%>' == "王珏萍"
                || '<%=EmployeeName%>' == "冯碧斯" || '<%=EmployeeName%>' == "冼颖诗"
                )
            {
               
                $("#<%=txtTNo.ClientID %>").removeAttr("readonly");
                    $('#<%=btnSaveNo.ClientID%>').show();
                   
                }
                else
                {
                  
                    $("#<%=txtTNo.ClientID %>").attr("readonly","readonly");  
                $('#<%=btnSaveNo.ClientID%>').hide();
            }
            if($("#btnSignIDx20").is(":visible"))
            {
              
                $("#btTongZhu").show();
            }
            else
            {
                $("#btTongZhu").hide();
            }
            $("#<%=txtDepartment.ClientID %>").autocomplete({ 
		        source: jJSON,
		        select: function(event,ui) {
		            $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
            });
            var hfDesign1 =  $('#<%=hfDesign1.ClientID%>').val();
         
            var hfCityService1 = $('#<%=hfCityService1.ClientID%>').val()
            var hfCityService2 = $('#<%=hfCityService2.ClientID%>').val()
            var hfCityService3 = $('#<%=hfCityService3.ClientID%>').val()
            
            if(hfDesign1 !=0)
                $("#tr1 input[name=grade1][value=" + hfDesign1 + "]").get(0).checked = true;
            //if(hfDesign2 !=0)
            //    $("#tr1 input[name=grade2][value=" + hfDesign2 + "]").get(0).checked = true;   
            //if(hfDesign3 !=0)
            //    $("#tr1 input[name=grade3][value=" + hfDesign3 + "]").get(0).checked = true;
            if(hfCityService1 !=0)
                $("#tr2 input[name=grade4][value=" + hfCityService1 + "]").get(0).checked = true;
            if(hfCityService2 !=0)
                $("#tr2 input[name=grade5][value=" + hfCityService2 + "]").get(0).checked = true;
            if(hfCityService3 !=0)
                $("#tr2 input[name=grade6][value=" + hfCityService3 + "]").get(0).checked = true;
		    //$("#<%//=txtAccepter.ClientID %>").autocomplete({ 
		    //    source: eval('([{"id":"1","value":"文玉仪"},{"id":"2","value":"周燕妮"},{"id":"3","value":"招琛彤"}])'),
		    //});
        
		    i = $("#tbDetail tr").length - 2;
		    i2 = $("#tbDetail2 tr").length - 2;

		    for (var x = 1; x <= i; x++) {
		        $("#txtDetail_Department"+ x).autocomplete({source: jJSON});
		    }
		    for (var x = 1; x <= i2; x++) {
		        $("#txtStatistical_SDepartment"+ x).autocomplete({source: jJSON});
		    }
		    //$("#txtStatistical_SDepartment1").autocomplete({source: jJSON});

		    $("#<%=txtApplyDate.ClientID%>").datepicker();
		    $("#<%=txtAcceptDate.ClientID%>").datepicker();
		    $("#<%=txtVerifyDate.ClientID%>").datepicker();

            for(var n=1;n<$("#tbDetail2 tr").length;n++)
            {
                $("#txtDemandDate" + n).datepicker();
            }

		    for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		        $("#ros1").attr("rowspan", i);
		        $("#ros2").attr("rowspan", i);
		        $("#txtBeginData" + x).datepicker();
		        $("#txtEndData" + x).datepicker();
		    }

		    $("#<%=rdbSumPrice1.ClientID %>").click(function(){
		        //if(isNewApply)
		        if($('#ctl00_ContentPlaceHolder1_txtApply').val() == '<%=EmployeeName%>')
		            CaculateTno('SJ');
		    });
		    $("#<%=rdbSumPrice2.ClientID %>").click(function(){
		        if($('#ctl00_ContentPlaceHolder1_txtApply').val() == '<%=EmployeeName%>')
		            CaculateTno('YS');
		    });
		    $("#<%=rdbSumPrice3.ClientID %>").click(function(){
		        if($('#ctl00_ContentPlaceHolder1_txtApply').val() == '<%=EmployeeName%>')
		            CaculateTno('WL');
		    });
		    $("#<%=rdbSumPrice4.ClientID %>").click(function(){
		        if($('#ctl00_ContentPlaceHolder1_txtApply').val() == '<%=EmployeeName%>')
		            CaculateTno('HD');
		    });
		    $("#<%=rdbSumPrice5.ClientID %>").click(function(){
		        if($('#ctl00_ContentPlaceHolder1_txtApply').val() == '<%=EmployeeName%>')
		            CaculateTno('DT');
		    });
		    $("#<%=rdbSumPrice6.ClientID %>").click(function(){
		        if($('#ctl00_ContentPlaceHolder1_txtApply').val() == '<%=EmployeeName%>')
		            CaculateTno('LP');
		    });
		    $("#<%=rdbSumPrice7.ClientID %>").click(function(){
		        if($('#ctl00_ContentPlaceHolder1_txtApply').val() == '<%=EmployeeName%>')
		            CaculateTno('PS');
		    });
		    $("#<%=rdbSumPrice8.ClientID %>").click(function(){
		        if($('#ctl00_ContentPlaceHolder1_txtApply').val() == '<%=EmployeeName%>')
		            CaculateTno('QT');
		    });

            $(".propagandatype input:checkbox").click(function(){
                var rdb=$(this).siblings("input:radio");

                var sichecked=rdb.is(":checked");
                var id=$(this).attr("id");
                var num=id.substring(id.length-1);

                var rdbid=rdb.attr("id");
                var rdbnum=rdbid.substring(rdbid.length-1);

                if(sichecked==false)
                {
                    $(this).attr("checked",false);
                    alert("请先选择类型！");
                }else
                {
                    if($(this).is(":checked")==true){
                        var count=$(this).parent().children('input:checkbox:checked').length;
                        if(count>3)
                        {
                            $(this).attr("checked",false);
                            alert("每种宣传类型只能选择3项！");
                        }else
                        {
                            addProductRow(num,$(this).next('label').text(),rdbnum);
                        }
                    }else
                    {
                        $("tr [id=trDetail3"+num+"]").remove();
                    }
                }

                
            });

            $(".propagandatype input:radio").click(function(){
                $("#tbDetail3 tr").remove();
                $(".propagandatype input:checkbox").attr("checked",false);
                $(".propagandatype input:text").val("");
            });

		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

        // 对Date的扩展，将 Date 转化为指定格式的String 
        // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
        // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
        // 例子： 
        // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
        // (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
        Date.prototype.Format = function(fmt) 
        { //author: meizz 
            var o = { 
                "M+" : this.getMonth()+1,                 //月份 
                "d+" : this.getDate(),                    //日 
                "h+" : this.getHours(),                   //小时 
                "m+" : this.getMinutes(),                 //分 
                "s+" : this.getSeconds(),                 //秒 
                "q+" : Math.floor((this.getMonth()+3)/3), //季度 
                "S"  : this.getMilliseconds()             //毫秒 
            }; 
            if(/(y+)/.test(fmt)) 
                fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length)); 
            for(var k in o) 
                if(new RegExp("("+ k +")").test(fmt)) 
                    fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length))); 
            return fmt; 
        }

        function CaculateTno(s){
            //$("#<%=txtTNo.ClientID%>").val(s + new Date().Format("yyyyMMddhhmmssS"));
        }

        function check() {
            if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
                alert("内M不可为空！");
                $("#<%=txtApplyID.ClientID %>").focus();
                return false;
            }
	        
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("申请部门/分行/组别不可为空！");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
			
            if($.trim($("#<%=txtApplyDate.ClientID %>").val())=="") {
                alert("申请日期不可为空！");
                $("#<%=txtApplyDate.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtApply.ClientID %>").val())=="") {
                alert("申请人不可为空！");
                $("#<%=txtApply.ClientID %>").focus();
                return false;
            }

            if($.trim($("#<%=txtConneter.ClientID %>").val())=="") {
                alert("联系人/电话(手机)不可为空！");
                $("#<%=txtConneter.ClientID %>").focus();
                return false;
            }else
            {
                var reg=/^1[3|4|5|8][0-9]\d{8}$|^\d{8}$/;
                if(!reg.test($.trim($("#<%=txtConneter.ClientID %>").val())))
                {
                    alert("请输入正确的11位手机号码或8位数字的号码！");
                    $("#<%=txtConneter.ClientID %>").focus();
                    return false;
                }
                
            }

            if($.trim($("#<%=txtBranchAddress.ClientID %>").val())=="") {
                alert("分行地址不可为空！");
                $("#<%=txtBranchAddress.ClientID %>").focus();
	            return false;
            }

            if (!$("#<%=rdbPaySituation1.ClientID %>").prop("checked") 
                && !$("#<%=rdbPaySituation2.ClientID %>").prop("checked")
                && !$("#<%=rdbPaySituation3.ClientID %>").prop("checked")
                && !$("#<%=rdbAnother.ClientID %>").prop("checked"))
            {
                alert("请选择支付情况！");
                $("#<%=rdbPaySituation1.ClientID%>").focus();
                 return false;
             }

             if($("#<%=rdbPaySituation2.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtPayProjectName.ClientID %>").val())=="")
                {
                    alert("请输入项目名称！");
                    $("#<%=txtPayProjectName.ClientID%>").focus();
                    return false;
                }
            }

            if($("#<%=rdbPaySituation3.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtFearNo.ClientID %>").val())=="")
                {
                    alert("请输入费用申请编号！");
                    $("#<%=txtFearNo.ClientID%>").focus();
                    return false;
                }
            }

            if($("#<%=rdbAnother.ClientID %>").prop("checked"))
            {
                if($.trim($("#<%=txtOtherDescript.ClientID %>").val())=="")
                {
                    alert("请输入其他描述！");
                    $("#<%=txtOtherDescript.ClientID%>").focus();
                     return false;
                 }
             }

             if (!$("#<%=rdbSumPrice1.ClientID %>").prop("checked") 
                && !$("#<%=rdbSumPrice2.ClientID %>").prop("checked")
                && !$("#<%=rdbSumPrice3.ClientID %>").prop("checked")
                && !$("#<%=rdbSumPrice4.ClientID %>").prop("checked")
                && !$("#<%=rdbSumPrice5.ClientID %>").prop("checked")
                && !$("#<%=rdbSumPrice6.ClientID %>").prop("checked")
                && !$("#<%=rdbSumPrice7.ClientID %>").prop("checked")
                && !$("#<%=rdbSumPrice8.ClientID %>").prop("checked")
                ) {
	            alert("请选择宣传类型");
	            $("#<%=rdbSumPrice1.ClientID%>").focus();
	            return false;
            }

            if ($("#<%=rdbSumPrice1.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfAdvertising1.ClientID %>").prop("checked") 
                    && !$("#<%=cbKindOfAdvertising2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfAdvertising3.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfAdvertising4.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfAdvertising5.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfAdvertising6.ClientID %>").prop("checked")
                    ) {
	                alert("请选择广告类");
	                $("#<%=cbKindOfAdvertising1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfAdvertising6.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtAnotherAdvertising.ClientID%>").val()) == "") { alert("请填写其它广告类！"); $("#<%=txtAnotherAdvertising.ClientID%>").focus(); return false; }
	            }
            }

            if ($("#<%=rdbSumPrice2.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfPrinting1.ClientID %>").prop("checked") 
                    && !$("#<%=cbKindOfPrinting2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfPrinting3.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfPrinting4.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfPrinting5.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfPrinting6.ClientID %>").prop("checked")
                    ) {
	                alert("请选择印刷类");
	                $("#<%=cbKindOfPrinting1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfPrinting6.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtAnotherPrinting.ClientID%>").val()) == "") { alert("请填写其它印刷类！"); $("#<%=txtAnotherPrinting.ClientID%>").focus(); return false; }
                }
            }

            if ($("#<%=rdbSumPrice3.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfMaterial1.ClientID %>").prop("checked") 
                    && !$("#<%=cbKindOfMaterial2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfMaterial3.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfMaterial4.ClientID %>").prop("checked")
                    ) {
	                alert("请选择物料类");
	                $("#<%=cbKindOfMaterial1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfMaterial4.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtAnotherMaterial.ClientID%>").val()) == "") { alert("请填写其它物料类！"); $("#<%=txtAnotherMaterial.ClientID%>").focus(); return false; }
                }
            }

            if ($("#<%=rdbSumPrice4.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfActivity1.ClientID %>").prop("checked") 
                    && !$("#<%=cbKindOfActivity2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfActivity3.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfActivity4.ClientID %>").prop("checked")
                    ) {
	                alert("请选择活动类");
	                $("#<%=cbKindOfActivity1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfActivity4.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtAnotherActivity.ClientID%>").val()) == "") { alert("请填写其它活动类！"); $("#<%=txtAnotherActivity.ClientID%>").focus(); return false; }
                }
            }

            if ($("#<%=rdbSumPrice5.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfMap1.ClientID %>").prop("checked") 
                    && !$("#<%=cbKindOfMap2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfMap3.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfMap4.ClientID %>").prop("checked")
                    ) {
	                alert("请选择地图类");
	                $("#<%=cbKindOfMap1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfMap4.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtAnotherMap.ClientID%>").val()) == "") { alert("请填写其它地图类！"); $("#<%=txtAnotherMap.ClientID%>").focus(); return false; }
                }
            }

            if ($("#<%=rdbSumPrice6.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfGift1.ClientID %>").prop("checked")) {
	                alert("请选择礼品类");
	                $("#<%=cbKindOfGift1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfGift1.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtAnotherGift.ClientID%>").val()) == "") { alert("请填写其它礼品类！"); $("#<%=txtAnotherGift.ClientID%>").focus(); return false; }
                }
            }

            if ($("#<%=rdbSumPrice7.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfSend1.ClientID %>").prop("checked") 
                    && !$("#<%=cbKindOfSend2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfSend3.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfSend4.ClientID %>").prop("checked")
                    ) {
	                alert("请选择派送类");
	                $("#<%=cbKindOfSend1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfSend4.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtAnotherSend.ClientID%>").val()) == "") { alert("请填写其它派送类！"); $("#<%=txtAnotherSend.ClientID%>").focus(); return false; }
                }
            }

            if ($("#<%=rdbSumPrice8.ClientID %>").prop("checked")){
                if (!$("#<%=cbKindOfAnother1.ClientID %>").prop("checked") 
                    && !$("#<%=cbKindOfAnother2.ClientID %>").prop("checked")
                    && !$("#<%=cbKindOfAnother3.ClientID %>").prop("checked")
                     && !$("#<%=cbKindOfAnother4.ClientID %>").prop("checked")
                     && !$("#<%=cbKindOfAnother5.ClientID %>").prop("checked")
                    ) {
	                alert("请选择其它类");
	                $("#<%=cbKindOfAnother1.ClientID%>").focus();
	                return false;
                }
                if ($("#<%=cbKindOfAnother3.ClientID%>").prop("checked")) {
	                if ($.trim($("#<%=txtAnotherAnother.ClientID%>").val()) == "") { alert("请填写其它其它类！"); $("#<%=txtAnotherAnother.ClientID%>").focus(); return false; }
                }
            }

            

            var data = "", data2 = "",data3 = "";
            var flag = true,flag2 = true,flag3=true;

            $("#tbDetail3 tr").each(function() {
                var id=$(this).attr("id");
                var n=id.substring(id.length-1);
               
                    if ($.trim($("#txtWidth" + n).val()) == "") {
                        alert("第" + n + "个项目的宽必须填写。");
                        $("#txtWidth" + n).focus();
                        flag3 = false;
                        return;
                    }
                    else if ($.trim($("#txtHeight" + n).val()) == "") {
                        alert("第" + n + "个项目的高必须填写。");
                        $("#txtHeight" + n).focus();
                        flag3 = false;
                        return;
                    }
                    else if (!($("#rdbAcross" + n).prop("checked")) && !($("#rdbUpright" + n).prop("checked"))) {
                        alert("第" + n + "个项目的横版竖版必须选择。");
                        $("#rdbAcross" + n).focus();
                        flag3 = false;
                        return;
                    }

                    else if ($.trim($("#txtCount" + n).val()) == "") {
                        alert("第" + n + "个项目的数量/页数必须填写。");
                        $("#txtCount" + n).focus();
                        flag3 = false;
                        return;
                    } else if ($.trim($("#txtDemandDate" + n).val()) == "") {
                        alert("第" + n + "个项目的成品需求日期必须填写。");
                        $("#txtDemandDate" + n).focus();
                        flag3 = false;
                        return;
                    }
                    else
                        data3 += $("#hdprojtype" + n).val()
                            + "&&" + n
                            + "&&" + $.trim($("#txtSummary" + n).val()) 
                            + "&&" + $.trim($("#txtWidth" + n).val()) 
                            + "&&" + $.trim($("#txtHeight" + n).val()) 
                            + "&&" + ($("#rdbAcross"+n).prop('checked')?"1":"2")
                            + "&&" + $.trim($("#txtCount" + n).val()) 
                            + "&&" + $.trim($("#txtPackage" + n).val()) 
                            + "&&" + $.trim($("#txtDemandDate" + n).val()) 
                            + "||";
                
            });


            $("#tbDetail tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail tr").size() - 1) {
                    if ($.trim($("#txtDetail_Department" + n).val()) == "") {
                        alert("第" + n + "行的分摊部门/分行/组别必须填写。");
                        $("#txtDetail_Department" + n).focus();
                        flag = false;
                        return;
                    }
                    else if ($.trim($("#txtDetail_Count" + n).val()) == "") {
                        alert("第" + n + "行的租分摊数量必须填写。");
                        $("#txtDetail_Count" + n).focus();
                        flag = false;
                        return;
                    }
                    else
                        data += $.trim($("#txtDetail_No" + n).html()) 
                            + "&&" + $.trim($("#txtDetail_Department" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_Count" + n).val()) 
                            + "||";
                }
            });

            
            $("#tbDetail2 tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail2 tr").size() - 1) {
                    if ($.trim($("#txtStatistical_SDepartment" + n).val()) == "") {
                        alert("第" + n + "行的送货部门/分行/组必须填写。");
                        $("#txtStatistical_SDepartment" + n).focus();
                        flag = false;
                        return;
                    }
                    else if ($.trim($("#txtStatistical_Address" + n).val()) == "") {
                        alert("第" + n + "行的送货地址必须填写。");
                        $("#txtStatistical_Address" + n).focus();
                        flag = false;
                        return;
                    }
                    else if ($.trim($("#txtStatistical_SCount" + n).val()) == "") {
                        alert("第" + n + "行的送货数量必须填写。");
                        $("#txtStatistical_SCount" + n).focus();
                        flag = false;
                        return;
                    }
                    else
                        data2 += $.trim($("#txtStatistical_SNo" + n).html()) 
                            + "&&" + $.trim($("#txtStatistical_SDepartment" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_Address" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_SCount" + n).val()) 
                            + "||";
                }
            });

            if (flag3) {
                data3 = data3.substr(0, data3.length - 2);
                $("#<%=hdDetail3.ClientID %>").val(data3);
            }
            else
                return false;

            if (flag) {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
            }
            else
                return false;

            if (flag2) {
                data2 = data2.substr(0, data2.length - 2);
                $("#<%=hdDetail2.ClientID %>").val(data2);
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
		        window.location='Apply_Propaganda_Detail.aspx?MainID=<%=MainID %>';
        }

        function editflow(){
            var win=window.showModalDialog("Apply_Propaganda_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
		    if(win=='success')
		        window.location="Apply_NewPropaganda_Detail.aspx?MainID=<%=MainID %>";
                }
		
                function CancelSign(idc) {
                    if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
                    {
                        $("#<%=hdCancelSign.ClientID%>").val(idc);
                document.getElementById("<%=btnCancelSign.ClientID %>").click();
            }
        }
		
        function sign(idx) {
            //if(idx!='7'&&idx!='8'10||idx=='130'){
            //if(idx=='1'||idx=='2'||idx=='3'||idx=='4'||idx=='5'||idx=='6'||idx=='9'||idx=='11'||idx=='131'){//789
            if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
                alert("请确定是否同意！");
                return;
            }
            //}
            //else{
            //    if(!$("#rdbYesIDx"+idx).prop("checked")&&!$("#rdbNoIDx"+idx).prop("checked")&&!$("#rdbOtherIDx"+idx).prop("checked")) {
            //        alert("请确定是否同意！");
            //        return;
            //    }
            //}
			
            if($("#rdbNoIDx"+idx).prop("checked")&&$.trim($("#txtIDx"+idx).val())=="") {   
                alert("由于您不同意该申请，请填写具体原因。");
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
		    //    var temp = window.document.body.innerHTML;        
		    //    var printhtml = temp.substring(temp.indexOf(start) + start.length, temp.indexOf(end));        
		    //    window.document.body.innerHTML = printhtml;        
		    //    window.print();        
		    //    window.document.body.innerHTML = temp;    
		    //}    
		    //else { window.print(); }
		    cMyPrint();
		}

		function addProductRow(i3,name,rdbnum)
		{
		    
		    var html='<tr id="trDetail3'+i3+'">'
                +'<td colspan="4" class="tl PL10" style="line-height: 25px">'
                +'<span style="font-weight: bold">◤'+name+'项目概念详述：</span><br />'
                +'<input type="hidden" id="hdprojtype'+i3+'" value="'+rdbnum+'" />'
		        +'（请写明使用目的，设计要求[如颜色、排版等]，制作要求、数量等）如属费用支付事项，则需注明支付金额）：<br />'
				+'<textarea id="txtSummary'+i3+'" style="width:98%;height:60px; overflow: hidden;"/></textarea><br />'
                +'★规格大小：<input type="text" id="txtWidth'+i3+'" Width="100px"/>(宽)X  '
                +'<input type="text" id="txtHeight'+i3+'" Width="100px"/>(高)　'
                +'<input type=radio id="rdbAcross'+i3+'" name="modelType'+i3+'"/>横版 <input type=radio id="rdbUpright'+i3+'" name="modelType'+i3+'"/>竖版<br/> '
                +'★数量/页数：<input type="text" id="txtCount'+i3+'" Width="100px"/><br />'
                +'包/安装要求：<input type="text" id="txtPackage'+i3+'" Width="250px"/>　'
                +'★成品需求日期：<input type="text" id="txtDemandDate'+i3+'" Width="105px"/>'      
                +'</td>'
                +'</tr>';

		    $("#tbDetail3").append(html);
		    $("#txtDemandDate"+ i3).datepicker();
		}

		function addRow() {
		    i ++;
		    var html = '<tr id="trDetail' + i + '">'
                + '         <td><span id="txtDetail_No' + i + '">'+i+'</span></td>'
				+ '         <td><input type="text" id="txtDetail_Department' + i + '" style="width:200px"/></td>'
                + '         <td><input type="text" id="txtDetail_Count' + i + '" style="width:200px"/></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
		    $("#trFlag").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
		    $("#txtDetail_Department"+ i).autocomplete({source: jJSON});
		}

		function addRow2() {
		    i2++;
		    var html = '<tr id="trDetail2' + i2 + '">'
                + '         <td><span id="txtStatistical_SNo' + i2 + '">'+i2+'</span></td>'
				+ '         <td><input type="text" id="txtStatistical_SDepartment' + i2 + '" style="width:150px"/></td>'
                + '         <td><input type="text" id="txtStatistical_Address' + i2 + '" style="width:150px"/></td>'
                + '         <td><input type="text" id="txtStatistical_SCount' + i2 + '" style="width:150px"/></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i2 + '"><table><tr><td>这是'+ i2 +'个</td></tr></table></tr>'
		    $("#trFlag2").before(html);
		    //$("#trFlag").before("<tr><td>这是"+ i2 +"个</td></tr>");
		    $("#txtStatistical_SDepartment"+ i2).autocomplete({source: jJSON});
		}

		function deleteRow() {
		    if (i > 1) {
		        i --;
		        $("#tbDetail tr:eq(" + (i + 1) + ")").remove();
		    } else
		        alert("不可删除第一行。");
		    $("#ros1").attr("rowspan", i);
		    $("#ros2").attr("rowspan", i);
		}

		function deleteRow2() {
		    if (i2 > 1) {
		        i2--;
		        $("#tbDetail2 tr:eq(" + (i2 + 1) + ")").remove();
		    } else
		        alert("不可删除第一行。");
		    //$("#tbDetail tr:eq(0)").remove();
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
        function checkSaveNo()
        {
            var no = $("#<%=txtTNo.ClientID %>").val();
            if(no == "")
            {
                alert('请填写申请编号');
                $("#<%=txtTNo.ClientID %>").focus();
                return false;
            }
            return true;
        }
	</script>
    <style type="text/css">
        .auto-style1 {
            width: 15%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
    <div class="tips">
        <p><b>一、申请部门填写：</b>“★”号为必须填写内容；</p>
        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;申请编号：由品牌营销部填写</p>
        <p><b>二、宣传类型包括（只可选单类）：</b>如项目内没有所需求内容，请选择“其他”并填上相关内容； </p>
        <p><b>三、制作项目名称/概念详述：</b>请写明使用目的，设计要求[如颜色、排版等]，制作要求、数量等；</p>
        <p><b>四、支付情况：</b>根据区域/部门实际支付情况进行选择：</p>
        <p>1、区域有预算，可选择“由申请项目之预算费用中支付”；</p>
        <p>2、区域预算其中一类别使用完毕，需进行调用，可选择“由预算中他项费用中调用，”并填写《广告宣传预算使用异常申请表》； </p> 
        <p>3、如区域没有任何预算，或临时接到新项目，需制作或购买宣传物料，可选择“另行《费用申请》中支付”，前提先另行申请费用（市场推广费用申请）。</p>
        <p><b>五、摊分情况：</b>如以片区进行申请，请提供摊分部门/分行/级别；</p>
        <p><b>六、送货清单（必填）：</b>市内分行可送货；如以片区申请，物料制作供应商只能送至其中两间分行；外区：送总部后自取或快递寄至分行；</p>
        <p><b>七、审批流程：</b></p>
        <p>申请人：部门/分行组别主管签署——总监/区域负责人</p>
        <p>设计组：冯碧斯/冼颖诗</p>
        <%--<p>市场部经理 刘秀霞</p>--%>
        <p>高级经理：李翔宇</p>
        <p>审批人：活动策划组：刘秀霞/周燕妮</p>
        
        <p><b>下单分类</b></p>
        <p><b>一、接单顺序：A-B-C-D</b></p>
        <p><b>二、排单时间：</b></p>
        <p><b>A类目：（3-14天）</b></p>
        <p>集团/公司/部门紧急事件、中原日、校园推广、营销之王、发布会、年会</p>
        <p><b>B类目：</b><span style="color:red">（红色：1-2天）</span><span style="color:orange">（橙色：3-5天）</span><b>（7-14天）</b></p>
        <p><span style="color:red">物业部颁奖、SPS广告、喜讯、英雄榜 </span></p>
        <p><span style="color:orange">中原地带、原仔宣传、官微宣传</span></p>
        <p>精英会、季会、庆功宴、离岸活动、店铺开业、社区活动、专题活动、品牌营销宣传活动、节日推广、媒体（广日）、易企秀、有奖活动、后勤活动、招聘活动</p>
        <p><b>C类目：（3-5天）</b></p>
        <p>龙虎榜、区域招聘、地图、跑马仔</p>
        <p><b>D类目：（不定期）</b></p>
        <p>分行员工天地、邮件签名、拍照</p>
         <p><b>八、申请表要求</b></p>
        <p>每份申请表不能超过三个项目内容，超出数量需另外下单。</p>
    </div>
    <script type="text/javascript">
        function tipswidth()
        {
            var tipswidth = (document.body.clientWidth - 700)/2
            $(".tips").width(tipswidth);
        }
        tipswidth();
        window.onresize = function(){
            tipswidth();
        }
        function onClickrdbSum()
        {
        
        }
    </script>
	<div style='text-align: center; width: 640px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>广告宣传需求申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <%--<div id="Div1" style="width:640px;margin:0 auto;">--%>
                <span style="float: right;" class="file_number">申请编号：
                    <asp:TextBox ID="txtTNo" runat="server" Width="160px"></asp:TextBox>
                     <asp:button runat="server" id="btnSaveNo" text="保存" OnClientClick="return checkSaveNo()" OnClick="btnSaveNo_Click"/>
                </span>
            <%--</div>--%>
			<table id="tbAround"  width='640px'>
                <tr>
                    <td colspan="4" class="tl PL10" bgcolor="Black"><span style="color: #FFFFFF; font-weight: bold;">申请部门填写 （ “★”号为必须填写内容）</span></td>
                </tr>
				<tr>
					<td colspan="4" class="tl PL10" style="line-height: 25px">
                        <div id="snum" style="width:640px;margin:0 auto;"><span class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
                        ★申请部门/分行/组别：<asp:textbox id="txtDepartment" runat="server" Width="215px"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" />
					  　★申请日期：<asp:textbox id="txtApplyDate" runat="server"></asp:textbox><br />
                        ★申请人：<asp:textbox id="txtApply" runat="server" Width="80px"></asp:textbox>　
                        ★内M：<asp:textbox id="txtApplyID" runat="server" Width="80px"></asp:textbox>　
                        ★联系人/电话(手机)：<asp:textbox id="txtConneter" runat="server"></asp:textbox><br />
                        ★分行地址：<asp:textbox id="txtBranchAddress" runat="server" Width="507px"></asp:textbox>
                    </td>
				</tr>
				<tr>
					<td colspan="4" class="tl PL10" style="line-height: 25px">
                        
                        <span style="font-weight: bold">◤宣传类型包括：</span>(只可选单类)<br />
                        <div class="propagandatype">
                        <asp:RadioButton ID="rdbSumPrice1" runat="server" GroupName="SumPrice" Text="广告类" />
                        （<asp:CheckBox ID="cbKindOfAdvertising1"   runat="server" Text="报纸广告栏" />
                        <asp:CheckBox ID="cbKindOfAdvertising2" runat="server" Text="分类广告" />
                        <asp:CheckBox ID="cbKindOfAdvertising3" runat="server" Text="杂志广告" />
                        <asp:CheckBox ID="cbKindOfAdvertising4" runat="server" Text="户外广告" />
                        <asp:CheckBox ID="cbKindOfAdvertising5" runat="server" Text="网络广告" /><br />　　　　　
                        <asp:CheckBox ID="cbKindOfAdvertising6" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherAdvertising" runat="server" Width="470px"></asp:textbox>）<br />
                        </div>

                        <div class="propagandatype">
                        <asp:RadioButton ID="rdbSumPrice2" runat="server" GroupName="SumPrice" Text="印刷类" />
                        （<asp:CheckBox ID="cbKindOfPrinting1" runat="server" Text="卡仔" />
                        <asp:CheckBox ID="cbKindOfPrinting2" runat="server" Text="单张" />
                        <asp:CheckBox ID="cbKindOfPrinting3" runat="server" Text="楼盘纸" />
                        <asp:CheckBox ID="cbKindOfPrinting4" runat="server" Text="小册子" />
                        <asp:CheckBox ID="cbKindOfPrinting5" runat="server" Text="书刊" /><br />　　　　　
                        <asp:CheckBox ID="cbKindOfPrinting6" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherPrinting" runat="server" Width="470px"></asp:textbox>）<br />
                        </div>

                        <div class="propagandatype">
                        <asp:RadioButton ID="rdbSumPrice3" runat="server" GroupName="SumPrice" Text="物料类" />
                        （<asp:CheckBox ID="cbKindOfMaterial1" runat="server" Text="海报" />
                        <asp:CheckBox ID="cbKindOfMaterial2" runat="server" Text="横幅" />
                        <asp:CheckBox ID="cbKindOfMaterial3" runat="server" Text="展示用品（太阳伞/帐篷/折叠式桌椅）" /><br />　　　　　
                        <asp:CheckBox ID="cbKindOfMaterial4" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherMaterial" runat="server" Width="470px"></asp:textbox>）<br />
                         </div>

                        <div class="propagandatype">
                        <asp:RadioButton ID="rdbSumPrice4" runat="server" GroupName="SumPrice" Text="活动类" />
                        （<asp:CheckBox ID="cbKindOfActivity1" runat="server" Text="联展活动" />
                        <asp:CheckBox ID="cbKindOfActivity2" runat="server" Text="专题讲座" />
                        <asp:CheckBox ID="cbKindOfActivity3" runat="server" Text="公司活动（季会/主管会）" /><br />　　　　　
                        <asp:CheckBox ID="cbKindOfActivity4" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherActivity" runat="server" Width="470px"></asp:textbox>）<br />
                        </div>

                        <div class="propagandatype">
                        <asp:RadioButton ID="rdbSumPrice5" runat="server" GroupName="SumPrice" Text="地图类" />
                        （<asp:CheckBox ID="cbKindOfMap1" runat="server" Text="A图" />
                        <asp:CheckBox ID="cbKindOfMap2" runat="server" Text="B图" />
                        <asp:CheckBox ID="cbKindOfMap3" runat="server" Text="C图" /><br />　　　　　
                        <asp:CheckBox ID="cbKindOfMap4" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherMap" runat="server" Width="470px"></asp:textbox>）<br />
                        </div>

                        <div class="propagandatype">
                        <asp:RadioButton ID="rdbSumPrice6" runat="server" GroupName="SumPrice" Text="礼品类" />
                        （<asp:CheckBox ID="cbKindOfGift1" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherGift" runat="server" Width="470px"></asp:textbox>）<br />
                        </div>

                         <div class="propagandatype">
                        <asp:RadioButton ID="rdbSumPrice7" runat="server" GroupName="SumPrice" Text="派送类" />
                        （<asp:CheckBox ID="cbKindOfSend1" runat="server" Text="正常派送" />
                        <asp:CheckBox ID="cbKindOfSend2" runat="server" Text="加急派送" />
                        <asp:CheckBox ID="cbKindOfSend3" runat="server" Text="分装配送" /><br />　　　　　
                        <asp:CheckBox ID="cbKindOfSend4" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherSend" runat="server" Width="470px"></asp:textbox>）<br />
                         </div>

                        <div class="propagandatype">
                        <asp:RadioButton ID="rdbSumPrice8" runat="server" GroupName="SumPrice" Text="其它类" />
                        （<asp:CheckBox ID="cbKindOfAnother1" runat="server" Text="邮局直投" />
                        <asp:CheckBox ID="cbKindOfAnother2" runat="server" Text="打印" />
                        <asp:CheckBox ID="cbKindOfAnother4" runat="server" Text="卡秀" />
                        <asp:CheckBox ID="cbKindOfAnother5" runat="server" Text="协助拍照" /><br />　　　
                        <asp:CheckBox ID="cbKindOfAnother3" runat="server" Text="其它" />
                        <asp:textbox id="txtAnotherAnother" runat="server" Width="470px"></asp:textbox>）<br />
                        </div>
					</td>
				</tr>
				
                <tr>
                   <td colspan="4" class="tl PL10" style="line-height: 25px">
                       <table id="tbDetail3" width='100%' class='sample tc' align="center">
                           <%=SbHtml3 %>
                       </table>
                   </td>
                </tr>

				<tr">
					<td colspan="4" class="tl PL10" style="line-height: 25px">
                        <span style="font-weight: bold">★支付情况：</span><br />
                        <asp:RadioButton ID="rdbPaySituation1" runat="server" GroupName="PaySituation" Text="由申请项目之预算费用中支付" /><br />
                        <asp:RadioButton ID="rdbPaySituation2" runat="server" GroupName="PaySituation" Text="由预算中他项费用中调用，项目名称为：" />
                        <asp:textbox id="txtPayProjectName" runat="server" Width="350px"></asp:textbox><br />
                        <asp:RadioButton ID="rdbPaySituation3" runat="server" GroupName="PaySituation" Text="另行《费用申请》中支付，《费用申请》编号：" />
                        <asp:textbox id="txtFearNo" runat="server" Width="313px"></asp:textbox><br />
                        <asp:RadioButton ID="rdbAnother" runat="server" GroupName="PaySituation" Text="其他" />
                        <asp:textbox id="txtOtherDescript" runat="server" Width="313px"></asp:textbox><br />
                        <span style="font-weight: bold">◤摊分情况：</span>（表格不尽之处可按以下格式另行附表）<br />
                        <table id="tbDetail" width='95%' class='sample tc' align="center">
                            <thead>
                                <tr>
                                    <td>序</td>
                                    <td>分摊部门/分行/组别</td>
                                    <td>送货数量</td>
                                </tr>
                            </thead>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag"><td colspan="4"></td></tr>
                        </table>
                        <input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none;"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
                        <br />
					</td>
				</tr>
				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 25px">
                        <span style="font-weight: bold">◤送货清单：</span>（表格不尽之处可按以下格式另行附表[如有更多的派送点则需另行派送申请]）<br />
                        <table id="tbDetail2" class='sample tc' width='95%' align="center">
                            <thead>
                                <tr>
                                    <td>序</td>
                                    <td>送货部门/分行/组</td>
                                    <td>送货地址</td>
                                    <td>送货数量</td>
                                </tr>
                            </thead>
                            <%=SbHtml2.ToString()%>
                            <tr id="trFlag2"><td colspan="4"></td></tr>
                        </table>
						<input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style=" float:left; display:none"/>
                        <br />
                    </td>
				</tr>
                <tr id="trManager" class="noborder" style="height: 80px;">
					<td class="auto-style1">申请人</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx19" type="radio" name="agree19" /><label for="rdbYesIDx19">同意</label><input id="rdbNoIDx19" type="radio" name="agree19" /><label for="rdbNoIDx19">不同意</label><br />
						<textarea id="txtIDx19" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx19" value="签名" onclick="sign('19')" style="display: none;" />
                        <%--<div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>--%>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="span19">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style1">部门/分行/组别主管签署</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <%--<div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>--%>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style1">总监/区域负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <%--<div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>--%>
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                        
					</td>
				</tr>

                <tr>
                    <td colspan="4" class="tl PL10" bgcolor="Black"><span style="color: #FFFFFF; font-weight: bold">安排/完成情况</span></td>
                </tr>

                 <tr id="trManager21" class="noborder" style="height: 85px;">
					<td class="auto-style1">设计组</td>
					<td colspan="3" class="tl PL10">
                        <input id="rdbGrade1" type="radio" name="grade" value="1" runat="server"/><label>A</label><input id="rdbGrade2" type="radio" name="grade" value="2" runat="server"/><label>B</label>
                        <input id="rdbGrade3" type="radio" name="grade" value="3" runat="server"/><label>C</label><input id="rdbGrade4" type="radio" name="grade" value="4" runat="server"/><label>D</label><br/><br/>

						<input id="rdbYesIDx21" type="radio" name="agree21" /><label for="rdbYesIDx21">同意</label><input id="rdbNoIDx21" type="radio" name="agree21" /><label for="rdbNoIDx21">不同意</label><br />
						<textarea id="txtIDx21" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx21" value="签名" onclick="sign('21')" style="display: none;" />
                       
                        <%--<div class="signdate">日期：<span id="spanDateIDx20">_________</span></div>--%>
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx21">_________</span>
                        </span><br/>
                      
					</td>
				</tr>
                 <tr id="trManager22" class="noborder" style="height: 85px;display: none;">
                        <td class="auto-style1">市场部经理</td>
                        <td colspan="3" class="tl PL10">
	                        <input id="rdbYesIDx22" type="radio" name="agree22" /><label for="rdbYesIDx22">同意</label>
	                        <input id="rdbNoIDx22" type="radio" name="agree22" /><label for="rdbNoIDx22">不同意</label><br />
	                        <textarea id="txtIDx22" rows="5" style="width: 98%; overflow: auto;"></textarea> <br />
	                        <input type="button" id="btnSignIDx22" value="签名" onclick="sign('22')" style="display: none;" />  
                                <br/>
                            <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                                日期：<span id="spanDateIDx22">_________</span>
                            </span><br/>
                     
                        </td>
                    </tr>
                 <tr id="trManager23" class="noborder" style="height: 85px;">
					<td class="auto-style1">高级经理</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx23" type="radio" name="agree23" /><label for="rdbYesIDx23">同意</label><input id="rdbNoIDx23" type="radio" name="agree23" /><label for="rdbNoIDx23">不同意</label><br />
						<textarea id="txtIDx23" rows="5" style="width: 98%; overflow: auto;"></textarea> <br /><input type="button" id="btnSignIDx23" value="签名" onclick="sign('23')" style="display: none;" />  
                         <br/>
                      
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx23">_________</span>
                        </span><br/>
                     
					</td>
				</tr>
                   <tr id="trManager25" class="noborder" style="height: 85px;">
					<td class="auto-style1">活动策划组</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx25" type="radio" name="agree25" /><label for="rdbYesIDx25">同意</label><input id="rdbNoIDx25" type="radio" name="agree25" /><label for="rdbNoIDx25">不同意</label><br />
						<textarea id="txtIDx25" rows="5" style="width: 98%; overflow: auto;"></textarea> <br /><input type="button" id="btnSignIDx25" value="签名" onclick="sign('25')" style="display: none;" />
                        <%--<div class="signdate">日期：<span id="spanDateIDx20">_________</span></div>--%>
                       <%--  <asp:Button ID="btnShouldJumpIDx" runat="server" Style="display:none" OnClientClick=" return confirm('跳过后，设计组的审批环节将会被删除，确实要跳过设计组审批吗？')"  OnClick="btnShouldJumpIDx_Click"/>
                        <asp:Button ID="btnReturnJumpIDx" CssClass="btnReturnJumpIDx" runat="server"  Style="display:none" OnClientClick=" return confirm('增加，增加设计组审批，确实要设计组的审批吗？')"  OnClick="btnReturnJumpIDx_Click"/>--%>
                       <input id="btTongZhu" type="button" class="songShenbtn" style="display: none" value="送审" onclick="tongzhu(this,25)" />
                         <br/>
                      
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx25">_________</span>
                        </span><br/>
                     
					</td>
				</tr>


           <%--     <tr id="tr1" class="noborder" style="height: 85px;">
					<td class="auto-style1">本次设计评分</td>
					<td colspan="3" class="tl PL10">
                      
                       
                        <input type="radio" id="Radio1" name ="grade1" value="1" /><label>一般</label> 请说明原因<input type="text" id="txtDesignermarkes1" runat="server"/><br/>
                         <input type="radio" id="Radio2" name ="grade1" value="2" /><label>良好</label><br/>
                        <input type="radio" id="Radio3" name ="grade1" value="3" /><label>满意</label><br/><br/>
                    --   （2）设计效果满意度：
                          <input type="radio" id="Radio4" name ="grade2" value="1" /><label>一般</label> 请说明原因<input type="text" id="txtDesignermarkes2" runat="server"/>
                         <input type="radio" id="Radio5" name ="grade2" value="2" /><label>良好</label>
                        <input type="radio" id="Radio6" name ="grade2" value="3" /><label>满意</label><br/><br/>
                          （3）按时完成度：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                          <input type="radio" id="Radio7" name ="grade3" value="1" /><label>一般</label> 请说明原因<input type="text" id="txtDesignermarkes3" runat="server"/>
                         <input type="radio" id="Radio8" name ="grade3" value="2" /><label>良好</label>
                        <input type="radio" id="Radio9"  name ="grade3" value="3" /><label>满意</label><br/>--
                           <div style="text-align:right">
                         <asp:button runat="server" id="btnquegao" CssClass="quegao" text="确稿"  OnClientClick=" return checkSaveDesignScore()"  OnClick="btnSaveDesignScore_Click"/>
                       </div>
                       </td>
				</tr>--%>

              <%--   <tr id="tr2" class="noborder" style="height: 85px;">
					<td class="auto-style1">评分市务组</td>
					<td colspan="3" class="tl PL10">
                    （1）沟通及时性：&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Radio16" type="radio" name="grade4" value="1" /><label>1</label><input id="Radio17" type="radio" name="grade4" value="2" /><label>2</label>
                        <input id="Radio18" type="radio" name="grade4" value="3" /><label>3</label><input id="Radio19" type="radio" name="grade4" value="4" /><label>4</label>
                        <input id="Radio20" type="radio" name="grade4" value="5" /><label>5</label><br/><br/>
                      （2）成品到达时效：
                        <input id="Radio21" type="radio" name="grade5" value="1" /><label>1</label><input id="Radio22" type="radio" name="grade5" value="2" /><label>2</label>
                        <input id="Radio23" type="radio" name="grade5" value="3" /><label>3</label><input id="Radio24" type="radio" name="grade5" value="4" /><label>4</label>
                        <input id="Radio25" type="radio" name="grade5" value="5" /><label>5</label><br/><br/>
                       （3）成品质量：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Radio26" type="radio" name="grade6" value="1" /><label>1</label><input id="Radio27" type="radio" name="grade6" value="2" /><label>2</label>
                        <input id="Radio28" type="radio" name="grade6" value="3" /><label>3</label><input id="Radio29" type="radio" name="grade6" value="4" /><label>4</label>
                        <input id="Radio30" type="radio" name="grade6" value="5" /><label>5</label><br/><br/>
                       <span style="color:red">备注：1分最低,5分最高 </span>
					
                         <div style="text-align:right">
                         <asp:button  id="btnCityScore" CssClass="btnSaveCityScore" text="保存" runat="server"  OnClientClick="return checkSaveCityScore()" OnClick="btnSaveCityScore_Click"/>
                         </div>
                        
                    </td>
				</tr>--%>
              
				<tr>
					<td colspan="4" class="tl PL10" style="line-height: 30px">
                        接单日期：<asp:textbox id="txtAcceptDate" runat="server" Width="135px"></asp:textbox>
					  　<%--接单人：<asp:textbox id="txtAccepter" runat="server" Width="140px"></asp:textbox>
                        　设计员：<asp:textbox id="txtDesigner" runat="server" Width="135px"></asp:textbox><br />--%>
                         　设计员：<asp:DropDownList ID="ddlDesigner" runat="server" Width="120px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <%--<asp:ListItem>陈国辉</asp:ListItem>--%>
                            <asp:ListItem>冯碧斯</asp:ListItem>
                            <asp:ListItem>冼颖诗</asp:ListItem>
                           <%-- <asp:ListItem>黄莎莉</asp:ListItem>--%>
                            <%--<asp:ListItem>陈唯杰</asp:ListItem>--%>
                        </asp:DropDownList>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;物料输出人：<asp:DropDownList ID="ddlAccepter" runat="server" Width="120px">
                            <asp:ListItem>请选择</asp:ListItem>
                            <%--<asp:ListItem>王萍</asp:ListItem>--%>
                            <asp:ListItem>周燕妮</asp:ListItem>
                            <%--<asp:ListItem>招琛彤</asp:ListItem>--%>
                            <asp:ListItem>王珏萍</asp:ListItem>
                        </asp:DropDownList>
                      <br />
                        <div>
                            <span style="vertical-align: top">完成情况/取消原因：</span>
                            <asp:textbox id="txtReason" runat="server" TextMode="MultiLine" Width="79%" Height="100px"></asp:textbox>
                        </div>
                        核实人：<asp:textbox id="txtVerifyer" runat="server"></asp:textbox>
                        　　日期：<asp:textbox id="txtVerifyDate" runat="server"></asp:textbox>
                    </td>
				</tr>
			</table>
            <div class="tl PL10" style="padding-top: 10px; padding-left: 5px; padding-bottom: 10px">
                  
                注意：1.	详细的制作流程请参阅市场部操作指引。2.	申请部门确定必须设计制作物料后再提交申请设计单。
            </div>
			<!--打印正文结束-->
		</div>

        <div class="noprint">
		<asp:gridview id="gvAttach"  CssClass="gvAttach" runat="server" backcolor="White" style="clear: both; margin-top: 3px;"
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

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
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
        <input type="hidden" id="hdDetail2" runat="server" />
        <input type="hidden" id="hdDetail3" runat="server" />
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:hiddenfield id="hfEmployeeName" runat="server" />
        <asp:hiddenfield id="hfDesign1" runat="server" />
      <%--  <asp:hiddenfield id="hfDesign2" runat="server" />
        <asp:hiddenfield id="hfDesign3" runat="server" />--%>
         <asp:hiddenfield id="hfCityService1" runat="server" />
        <asp:hiddenfield id="hfCityService2" runat="server" />
        <asp:hiddenfield id="hfCityService3" runat="server" />

        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    
    <script type="text/javascript">
        function tongzhu(e, idx) {

            //alert($(e).val());
            var textarea = $("#txtIDx25").val();
            //var $textarea = $(e).parent().parent().find(".fieldtext").children().first()
            if (textarea!= "") {
               
                       // var textarea = $textarea.val();
                        //   alert($textarea.val());
                        $.ajax({
                            url: "Mail_Handler.ashx",
                            type: "post",
                            dataType: "text",
                            data: "action=sendMail&MainId=<%=MainID %>&textarea=" + textarea + "&EmployeeName=" + "<%=EmployeeName%>" + "&EmployeeID=" + "<%=EmployeeID%>" + "&idx=" + idx,
                             success: function (info) {
                                 if (info != "fail") {
                                     alert('成功通知申请人');
                                     history.go(0);
                                 }
                                 else {
                                     history.go(0);
                                     alert('通知失败');

                                 }
                             }
                         })
                     }
                     else {
                         alert('请输入意见');
                     }
                 }
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
        //function checkSaveDesignScore()
        //{
        //    $('input[name = "grade1"]').each(function(){
        //        if (this.checked) {
        //            $('#hfDesign1.ClientID%>').val(this.value);
        //        }
        //    });
         
        //    if($('#hfDesign1.ClientID%>').val() == "")
        //    {
        //        alert('请选择（1）设计作品相符度')
        //        $("#Radio1").focus();
        //        return false;
        //    }
        //    if($('#hfDesign1.ClientID%>').val() == "1")
        //    {
        //        if($('#txtDesignermarkes1.ClientID%>').val()=="")
        //        {
        //            alert('请填写说明原因')
        //            $('#txtDesignermarkes1.ClientID%>').focus();
        //            return false;
        //        }                            
        //    }
        
        //    return true;
        //}
        function checkSaveCityScore()
        {
            $('input[name = "grade4"]').each(function(){
                if (this.checked) {
                    $('#<%=hfCityService1.ClientID%>').val(this.value);
                }
        });
            $('input[name = "grade5"]').each(function(){
                if (this.checked) {
                    $('#<%=hfCityService2.ClientID%>').val(this.value);
                   
                }
            });
            $('input[name = "grade6"]').each(function(){
                if (this.checked) {
                    $('#<%=hfCityService3.ClientID%>').val(this.value);
                   
                }
            });
            if($('#<%=hfCityService1.ClientID%>').val() == "")
            {
                alert('请选择（1）沟通及时性分数')
                $("#Radio16").focus();
                return false;
            }
            if($('#<%=hfCityService2.ClientID%>').val() == "")
            {
                alert('请选择（2）成品到达时效分数')
                $("#Radio21").focus();
                return false;
            }
            if($('#<%=hfCityService3.ClientID%>').val() == "")
            {
                alert('请选择（3）成品质量分数')
                $("#Radio26").focus();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
