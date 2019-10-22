<%@ Page ValidateRequest="false" Title="三级市场一手项目欠必要性文件拉数申请 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_PullafewRd_Detail.aspx.cs" Inherits="Apply_PullafewRd_Apply_PullafewRd_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Script/common_new.js"></script>
    <script type="text/javascript">
        var i = 1, i2 = 1, i3 = 1;
		var jJSON = <%=SbJson.ToString() %>;
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
		    $("[id*=btnImport]").css({
		        "background-image": "url(/Images/btnImport1.png)",
		        "height": "36px", 
		        "width": "92px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnImport]").mousedown(function () { $(this).css("background-image", "url(/Images/btnImport2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnImport1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnImport1.png)"); });

		    $("[id*=btnsSignIDx]").css({
		        "background-image": "url(/Images/btnSureS1.png)",
		        "height": "25px", 
		        "width": "43px",
		        "font-size": "0px",
		        "cursor":"pointer",
		        "color": "#FFFFFF"
		    });
		    $("[id*=btnsSignIDx]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); });

			$("#<%=txtDepartment.ClientID %>").autocomplete({ 
				source: jJSON,
				select: function(event,ui) {
				    $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
				}
			});

		    i = $("#tbDetail tr").length - 3;
		    i2 = $("#tbDetail2 tr").length - 3;
		    i3 = $("#tbDetail3 tr").length - 3;
		    //for (var x = 1; x <= i; x++) {
		    //    $("#txtDetail_Department"+ x).autocomplete({source: jJSON});
		    //}
		    //for (var x = 1; x <= i2; x++) {
		    //    $("#txtStatistical_SDepartment"+ x).autocomplete({source: jJSON});
		    //}
		    //$("#txtStatistical_SDepartment1").autocomplete({source: jJSON});

		    //for (var x = 1; x <= i; x++) {  //使详情表的日期变得可选
		    //    $("#ros1").attr("rowspan", i);
		    //    $("#ros2").attr("rowspan", i);
		    //    $("#txtBeginData" + x).datepicker();
		    //    $("#txtEndData" + x).datepicker();
		    //}

		    $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
		});

        // 对Date的扩展，将 Date 转化为指定格式的String 
        // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
        // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
        // 例子： 
        // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
        // (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
        //Date.prototype.Format = function(fmt) 
        //{ //author: meizz 
        //    var o = { 
        //        "M+" : this.getMonth()+1,                 //月份 
        //        "d+" : this.getDate(),                    //日 
        //        "h+" : this.getHours(),                   //小时 
        //        "m+" : this.getMinutes(),                 //分 
        //        "s+" : this.getSeconds(),                 //秒 
        //        "q+" : Math.floor((this.getMonth()+3)/3), //季度 
        //        "S"  : this.getMilliseconds()             //毫秒 
        //    }; 
        //    if(/(y+)/.test(fmt)) 
        //        fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length)); 
        //    for(var k in o) 
        //        if(new RegExp("("+ k +")").test(fmt)) 
        //            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length))); 
        //    return fmt; 
        //}

	    function check() {
	        if($.trim($("#<%=txtApplyID.ClientID %>").val())=="") {
	            alert("发文编号不可为空！");
	            $("#<%=txtApplyID.ClientID %>").focus();
	            return false;
	        }
	        
	        if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
	            alert("申请部门不可为空！");
	            $("#<%=txtDepartment.ClientID %>").focus();
	            return false;
	        }
			
	        if($.trim($("#<%=txt1a.ClientID %>").val())=="") {
	            //alert("成交总宗数（年）不可为空！");
	            alert("（年）不可为空！");
	            $("#<%=txt1a.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txt1b.ClientID %>").val())=="") {
	           // alert("成交总宗数（月）不可为空！");
	            alert("（月）不可为空！");
	            $("#<%=txt1b.ClientID %>").focus();
	            return false;
	        }

	   

	        if($.trim($("#<%=txt1g.ClientID %>").val())=="") {
	            alert("成交总宗数合计不可为空！");
	            $("#<%=txt1g.ClientID %>").focus();
	            return false;
	        }

	        if($.trim($("#<%=txt1h.ClientID %>").val())=="") {
	            alert("成交总业绩合计不可为空！");
	            $("#<%=txt1h.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1i.ClientID %>").val())=="") {
	            alert("拉数宗数合计不可为空！");
	            $("#<%=txt1i.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1j.ClientID %>").val())=="") {
	            alert("拉数欠收业绩合计不可为空！");
	            $("#<%=txt1j.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1k.ClientID %>").val())=="") {
	            alert("拉数欠收业绩（年）不可为空！");
	            $("#<%=txt1k.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1l.ClientID %>").val())=="") {
	            alert("拉数欠收业绩（月）不可为空！");
	            $("#<%=txt1l.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1m.ClientID %>").val())=="") {
	            alert("海珠区合计不可为空！");
	            $("#<%=txt1m.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1n.ClientID %>").val())=="") {
	            alert("天河区合计不可为空！");
	            $("#<%=txt1n.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1o.ClientID %>").val())=="") {
	            alert("白云区合计不可为空！");
	            $("#<%=txt1o.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1p.ClientID %>").val())=="") {
	            alert("越秀区合计不可为空！");
	            $("#<%=txt1p.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1q.ClientID %>").val())=="") {
	            alert("花都合计不可为空！");
	            $("#<%=txt1q.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1r.ClientID %>").val())=="") {
	            alert("番禺合计不可为空！");
	            $("#<%=txt1r.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1s.ClientID %>").val())=="") {
	            alert("工商铺（罗思源)合计不可为空！");
	            $("#<%=txt1s.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1t.ClientID %>").val())=="") {
	            alert("项目部合计不可为空！");
	            $("#<%=txt1t.ClientID %>").focus();
	            return false;
	        }
	        if($.trim($("#<%=txt1ut.ClientID %>").val())=="") {
	            alert("工商铺（谢伟中）合计不可为空！");
	            $("#<%=txt1ut.ClientID %>").focus();
	            return false;
            }
	        if($.trim($("#<%=txt1u.ClientID %>").val())=="") {
	            alert("拉数合计不可为空！");
	            $("#<%=txt1u.ClientID %>").focus();
	            return false;
	        }
	        //if($.trim($("#<%=txt1v.ClientID %>").val())=="") {
	        //    alert("补充说明不可为空！");
	        //    $("#<%=txt1v.ClientID %>").focus();
	        //    return false;
            //}

	        var data = "", data2 = "", data3 = "";
	        var flag = true,flag2 = true,flag3 = true;
	        $("#tbDetail tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail tr").size() - 2) {
	                if ($.trim($("#txtDetail_1a" + n).val()) == "") {
	                    alert("第" + n + "行的统筹区域必须填写1！");
	                    $("#txtDetail_1a" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtDetail_1b" + n).val()) == "") {
	                    alert("第" + n + "行的楼盘名称必须填写。");
	                    $("#txtDetail_1b" + n).focus();
	                    flag = false;
	                    return;
	                }
	                
	                else if ($.trim($("#txtDetail_1i" + n).val()) == "") {
	                    alert("第" + n + "行的统筹人称必须填写。");
	                    $("#txtDetail_1i" + n).focus();
	                    flag = false;
	                    return;
	                }

	                else if ($.trim($("#txtDetail_1j" + n).val()) == "") {
	                    alert("第" + n + "行的项目所在地称必须填写。");
	                    $("#txtDetail_1j" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtDetail_1d" + n).val()) == "") {
	                    alert("第" + n + "行的成交总宗数必须填写。");
	                    $("#txtDetail_1d" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtDetail_1e" + n).val()) == "") {
	                    alert("第" + n + "行的成交总业绩必须填写。");
	                    $("#txtDetail_1e" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtDetail_1f" + n).val()) == "") {
	                    alert("第" + n + "行的宗数必须填写。");
	                    $("#txtDetail_1f" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtDetail_1g" + n).val()) == "") {
	                    alert("第" + n + "行的欠收业绩必须填写。");
	                    $("#txtDetail_1g" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtDetail_1h" + n).val()) == "") {
	                    alert("第" + n + "行的拉数原因必须填写。");
	                    $("#txtDetail_1h" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data += $.trim($("#txtDetail_1a" + n).html()) 
                            + "&&" + $.trim($("#txtDetail_1b" + n).val()) 
                            //+ "&&" + $.trim($("#txtDetail_1c" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_1d" + n).val())
                            + "&&" + $.trim($("#txtDetail_1e" + n).val())
                            + "&&" + $.trim($("#txtDetail_1f" + n).val())
                            + "&&" + $.trim($("#txtDetail_1g" + n).val())
                            + "&&" + $.trim($("#txtDetail_1h" + n).val())
                            + "&&" + $.trim($("#txtDetail_1i" + n).val())
                            + "&&" + $.trim($("#txtDetail_1j" + n).val())
                            + "||";
	            }
	        });

	        $("#tbDetail3 tr").each(function(n) {
	           
	            if (n != 0 && n < ($("#tbDetail3 tr").size() - 2)) {
	                if ($.trim($("#txtLeaseTerm_1a" + n).val()) == "") {
	                  
	                    alert("第" + n + "行的统筹区域必须填写3！");
	                    $("#txtLeaseTerm_1a" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtLeaseTerm_1h" + n).val()) == "") {
	                    alert("第" + n + "行的楼盘名称必须填写。");
	                    $("#txtLeaseTerm_1h" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtLeaseTerm_1i" + n).val()) == "") {
	                    alert("第" + n + "行的统筹人称必须填写。");
	                    $("#txtLeaseTerm_1i" + n).focus();
	                    flag = false;
	                    return;
	                }

	                else if ($.trim($("#txtLeaseTerm_1b" + n).val()) == "") {
	                    alert("第" + n + "行的项目所在地称必须填写。");
	                    $("#txtDetail_1j" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtLeaseTerm_1c" + n).val()) == "") {
	                    alert("第" + n + "行的代理期必须填写。");
	                    $("#txtLeaseTerm_1c" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtLeaseTerm_1d" + n).val()) == "") {
	                    alert("第" + n + "行的成交总业绩必须填写。");
	                    $("#txtLeaseTerm_1d" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtLeaseTerm_1e" + n).val()) == "") {
	                    alert("第" + n + "行的拉数业绩必须填写。");
	                    $("#txtLeaseTerm_1e" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtLeaseTerm_1f" + n).val()) == "") {
	                    alert("第" + n + "行的欠交文件必须填写。");
	                    $("#txtLeaseTerm_1f" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data3 += $.trim($("#txtLeaseTerm_1a" + n).html()) 
                            + "&&" + $.trim($("#txtLeaseTerm_1b" + n).val()) 
                            + "&&" + $.trim($("#txtLeaseTerm_1c" + n).val()) 
                            + "&&" + $.trim($("#txtLeaseTerm_1d" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1e" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1f" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1g" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1h" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1i" + n).val())
                            + "||";
	            }
	        });

	        $("#tbDetail2 tr").each(function(n) {
	            if (n != 0 && n < $("#tbDetail2 tr").size() - 2) {
	                if ($.trim($("#txtStatistical_1a" + n).val()) == "") {
	                    alert("第" + n + "行的统筹区域必须填写2。");
	                    $("#txtStatistical_1a" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1b" + n).val()) == "") {
	                    alert("第" + n + "行的楼盘名称必须填写。");
	                    $("#txtStatistical_1b" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1c" + n).val()) == "") {
	                    alert("第" + n + "行的海珠区欠收业绩必须填写。");
	                    $("#txtStatistical_1c" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1d" + n).val()) == "") {
	                    alert("第" + n + "行的天河区欠收业绩必须填写。");
	                    $("#txtStatistical_1d" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1e" + n).val()) == "") {
	                    alert("第" + n + "行的白云区欠收业绩必须填写。");
	                    $("#txtStatistical_1e" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1f" + n).val()) == "") {
	                    alert("第" + n + "行的越秀区欠收业绩必须填写。");
	                    $("#txtStatistical_1f" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1g" + n).val()) == "") {
	                    alert("第" + n + "行的花都欠收业绩必须填写。");
	                    $("#txtStatistical_1g" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1h" + n).val()) == "") {
	                    alert("第" + n + "行的番禺欠收业绩必须填写。");
	                    $("#txtStatistical_1h" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1i" + n).val()) == "") {
	                    alert("第" + n + "行的工商铺（罗思源)欠收业绩必须填写。");
	                    $("#txtStatistical_1i" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1j" + n).val()) == "") {
	                    alert("第" + n + "行的工商铺（谢伟中）欠收业绩必须填写。");
	                    $("#txtStatistical_1j" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1jk" + n).val()) == "") {
	                    alert("第" + n + "行的项目部欠收业绩必须填写。");
	                    $("#txtStatistical_1jk" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1l" + n).val()) == "") {
	                    alert("第" + n + "行的番禺二部欠收业绩必须填写。");
	                    $("#txtStatistical_1l" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1m" + n).val()) == "") {
	                    alert("第" + n + "行的芳村南海欠收业绩必须填写。");
	                    $("#txtStatistical_1m" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else if ($.trim($("#txtStatistical_1k" + n).val()) == "") {
	                    alert("第" + n + "行的合计欠收业绩必须填写。");
	                    $("#txtStatistical_1k" + n).focus();
	                    flag = false;
	                    return;
	                }
	                else
	                    data2 += $.trim($("#txtStatistical_1a" + n).html()) 
                            + "&&" + $.trim($("#txtStatistical_1b" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_1c" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_1d" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_1e" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1f" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1g" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1h" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1i" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1j" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1jk" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1k" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1l" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1m" + n).val())
                            + "||";
	            }
	        });

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

	        if (flag3) {
	            data3 = data3.substr(0, data3.length - 2);
	            $("#<%=hdDetail3.ClientID %>").val(data3);
            }
            else
                return false;

	    }

        //2016/8/18 52100
        function tempsavecheck()
        {
            var data = "", data2 = "", data3 = "";
            $("#tbDetail tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail tr").size() - 2) {	                
                    data += $.trim($("#txtDetail_1a" + n).html()) 
                            + "&&" + $.trim($("#txtDetail_1b" + n).val()) 
                            //+ "&&" + $.trim($("#txtDetail_1c" + n).val()) 
                            + "&&" + $.trim($("#txtDetail_1d" + n).val())
                            + "&&" + $.trim($("#txtDetail_1e" + n).val())
                            + "&&" + $.trim($("#txtDetail_1f" + n).val())
                            + "&&" + $.trim($("#txtDetail_1g" + n).val())
                            + "&&" + $.trim($("#txtDetail_1h" + n).val())
                            + "&&" + $.trim($("#txtDetail_1i" + n).val())
                            + "&&" + $.trim($("#txtDetail_1j" + n).val())
                            + "||";
                }
            });
            $("#tbDetail3 tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail3 tr").size() - 1) {
                        data3 += $.trim($("#txtLeaseTerm_1a" + n).html()) 
                            + "&&" + $.trim($("#txtLeaseTerm_1b" + n).val()) 
                            + "&&" + $.trim($("#txtLeaseTerm_1c" + n).val()) 
                            + "&&" + $.trim($("#txtLeaseTerm_1d" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1e" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1f" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1g" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1h" + n).val())
                            + "&&" + $.trim($("#txtLeaseTerm_1i" + n).val())
                            + "||";
                }
            });
            $("#tbDetail2 tr").each(function(n) {
                if (n != 0 && n < $("#tbDetail2 tr").size() - 2) {	               
                    data2 += $.trim($("#txtStatistical_1a" + n).html()) 
                            + "&&" + $.trim($("#txtStatistical_1b" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_1c" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_1d" + n).val()) 
                            + "&&" + $.trim($("#txtStatistical_1e" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1f" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1g" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1h" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1i" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1j" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1jk" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1k" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1l" + n).val())
                            + "&&" + $.trim($("#txtStatistical_1m" + n).val())
                            + "||";
                }
            });
            data = data.substr(0, data.length - 2);
            $("#<%=hdDetail.ClientID %>").val(data);
            data2 = data2.substr(0, data2.length - 2);
            $("#<%=hdDetail2.ClientID %>").val(data2);
            data3 = data3.substr(0, data3.length - 2);
            $("#<%=hdDetail3.ClientID %>").val(data3);
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
				window.location='Apply_PullafewRd_Detail.aspx?MainID=<%=MainID %>';
		}

		function editflow(){
			var win=window.showModalDialog("Apply_PullafewRd_Flow.aspx?MainID=<%=MainID %>","","dialogWidth=800px;dialogHeight=320px");
					if(win=='success')
						window.location="Apply_PullafewRd_Detail.aspx?MainID=<%=MainID %>";
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
	        //if(idx=='1'||idx=='2'||idx=='3'){//789
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
		    i ++;
		    var html = '<tr id="trDetail' + i + '">'
                + '         <td><textarea id="txtDetail_1a' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtDetail_1b' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                  + '         <td><textarea id="txtDetail_1i' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtDetail_1j' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                //+ '         <td><textarea id="txtDetail_1c' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtDetail_1d' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtDetail_1e' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtDetail_1f' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtDetail_1g' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtDetail_1h' + i + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail' + i + '"><table><tr><td>这是'+ i +'个</td></tr></table></tr>'
		    $("#trFlag").before(html);
		    $.each($("textarea"), function (idx, item) { autoTextarea(this); });
		    //$("#trFlag").before("<tr><td>这是"+ i +"个</td></tr>");
		    //$("#txtDetail_Department"+ i).autocomplete({source: jJSON});
		}

		function addRow3() {
		    i3 ++;
		    var html = '<tr id="trDetail3' + i3 + '">'
                + '         <td><textarea id="txtLeaseTerm_1a' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtLeaseTerm_1b' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtLeaseTerm_1h' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtLeaseTerm_1i' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtLeaseTerm_1c' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtLeaseTerm_1d' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtLeaseTerm_1e' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtLeaseTerm_1f' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtLeaseTerm_1g' + i3 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
				+ '     </tr>';
		    //var html = '<tr id="trDetail3' + i3 + '"><table><tr><td>这是'+ i3 +'个</td></tr></table></tr>'
		    $("#trFlag3").before(html);
		    $.each($("textarea"), function (idx, item) { autoTextarea(this); });
		    //$("#trFlag3").before("<tr><td>这是"+ i +"个</td></tr>");
		    //$("#txtDetail_Department"+ i).autocomplete({source: jJSON});
		}

		function addRow2() {
		    i2++;
		    var html = '<tr id="trDetail2' + i2 + '">'
                + '         <td><textarea id="txtStatistical_1a' + i2 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1b' + i2 + '" style="width: 80px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1c' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1d' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1e' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1f' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1g' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1h' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1i' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1j' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1jk' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1l' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1m' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
                + '         <td><textarea id="txtStatistical_1k' + i2 + '" style="width: 50px; overflow: hidden;" rows="1"></textarea></td>'
				+ '     </tr>';
		    //var html = '<tr id="trStatistical' + i2 + '"><table><tr><td>这是'+ i2 +'个</td></tr></table></tr>'
		    $("#trFlag2").before(html);
		    $.each($("textarea"), function (idx, item) { autoTextarea(this); });
		    //$("#trFlag").before("<tr><td>这是"+ i2 +"个</td></tr>");
		    //$("#txtStatistical_SDepartment"+ i2).autocomplete({source: jJSON});
		}

		function deleteRow() {
		    if (i > 1) {
		        i --;
		        $("#tbDetail tr:eq(" + (i+2) + ")").remove();
			} else
		        alert("不可删除第一行。");
		}

		function deleteRow2() {
		    if (i2 > 1) {
		        i2--;
		        $("#tbDetail2 tr:eq(" + (i2+2) + ")").remove();
		    } else
		        alert("不可删除第一行。");
		    //$("#tbDetail tr:eq(0)").remove();
		}

		function deleteRow3() {
		    if (i3 > 1) {
		        i3--;
		        $("#tbDetail3 tr:eq(" + (i3+1) + ")").remove();
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
        function Imports() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_zNull_UploadFile.aspx?MainID=<%=MainID %>", '<%=MainID %>', "dialogHeight=165px");
            if (sReturnValue == "undefined") {
                sReturnValue = window.returnValue;
            }
            //alert(sReturnValue);
            $("#<%=hdFilePath.ClientID%>").val(sReturnValue);
            return true;
        }
	</script>
    <style type="text/css">
        .auto-style2 {
            width: 140px;
        }
        .auto-style3 {
            width: 170px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdEmail" runat="server" />
	<div style='text-align: center; width: 840px; margin: 0 auto;'>
        <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:button runat="server" id="btnEditFlow2" text="编辑流程" onclientclick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
		</div>
            <!--打印正文开始-->
		<div style='text-align: center'>
			<h1>广东中原地产代理有限公司</h1>
			<h1>三级市场一手项目欠必要性文件拉数申请</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width:840px;margin:0 auto;"><span style="float:right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
			<table id="tbAround"  width='840px'>
				<tr>
					<td class="auto-style3">申请部门</td>
					<td class="tl PL10"><asp:textbox id="txtDepartment" runat="server" Width="200px"></asp:textbox><input type="hidden" id="hdDepartmentID" runat="server" /></td>
					<td class="auto-style2">发文编号</td>
					<td class="tl PL10"><asp:textbox id="txtApplyID" runat="server" Width="200px"></asp:textbox></td>
				</tr>
				<tr>
					<td class="auto-style3">申请人</td>
					<td class="tl PL10"><asp:Label ID="lblApply" runat="server"></asp:Label></td>
					<td class="auto-style2">申请日期</td>
					<td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td colspan="4" class="tl PL10" style="line-height: 25px">
                        <span style="font-weight: bold">欠客户确认函拉数统计：</span><br />
                        <table id="tbDetail" width='95%' class='sample tc' align="center">
                            <thead>
                                <tr>
                                    <td rowspan="2">统筹区域</td>
                                    <td rowspan="2">楼盘名称</td>
                                    <td rowspan="2">统筹人</td>
                                    <td rowspan="2">项目所在地</td>
                                   <%-- <td rowspan="2">代理期</td>--%>
                                    <td rowspan="1" colspan="4">
                                        <asp:TextBox ID="txt1a" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt1b" runat="server" Width="30px"></asp:TextBox>月<br />
                                       </td>
                                 <%--   <td rowspan="2">
                                        <asp:TextBox ID="txt1a" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt1b" runat="server" Width="30px"></asp:TextBox>月<br />成交总宗数
                                    </td>
                                    <td rowspan="2">
                                        <asp:TextBox ID="txt1c" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt1d" runat="server" Width="30px"></asp:TextBox>月<br />成交总业绩
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txt1e" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt1f" runat="server" Width="30px"></asp:TextBox>月拉数
                                    </td>--%>
                                    <td rowspan="2">区域答复欠交原因</td>
                                </tr>
                                <tr>
                                    <td>成交总宗数</td>
                                    <td>成交总业绩</td>
                                    <td>宗数</td>
                                    <td>拉数业绩</td>
                                </tr>
                            </thead>
                            <%=SbHtml.ToString()%>
                            <tr id="trFlag">
                                <td colspan="4">合计</td>
                                <td><asp:TextBox ID="txt1g" runat="server" Width="80px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1h" runat="server" Width="80px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1i" runat="server" Width="80px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1j" runat="server" Width="80px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td></td>
                            </tr>
                        </table>
                        <input type="button" id="btnAddRow" value="添加新行" onclick="addRow();" style=" float:left; display:none;"/>
						<input type="button" id="btnDeleteRow" value="删除一行" onclick="deleteRow();" style=" float:left; display:none"/>
                        <br />
					</td>
				</tr>

                <tr>
					<td colspan="4" class="tl PL10" style="line-height: 25px">
                        <span style="font-weight: bold">欠合同拉数统计：</span><br />
                        <table id="tbDetail3" width='95%' class='sample tc' align="center">
                            <thead>
                                <tr>
                                    <td rowspan="2">统筹区域</td>
                                    <td rowspan="2">楼盘名称</td>
                                     <td rowspan="2">统筹人</td>
                                    <td rowspan="2">项目所在地</td>
                                    <td rowspan="2">代理期</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txt2a" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt2b" runat="server" Width="30px"></asp:TextBox>月<br />
                                    </td>
                                  <%--  <td>
                                        <asp:TextBox ID="txt2c" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt2d" runat="server" Width="30px"></asp:TextBox>月<br />拉数业绩
                                    </td>--%>
                                    <td rowspan="2">欠交文件</td>
                                    <td rowspan="2">区域答复欠交原因</td>
                                </tr>
                                  <tr>
                                    <td>成交总业绩</td>
                                    <td>拉数业绩</td>
                                </tr>
                            </thead>
                            <%=SbHtml3.ToString()%>
                            <tr id="trFlag3">
                                <td colspan="5">合计</td>
                                <td><asp:TextBox ID="txt2e" runat="server" Width="80px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt2f" runat="server" Width="80px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td></td>
                            </tr>
                        </table>
                        <input type="button" id="btnAddRow3" value="添加新行" onclick="addRow3();" style=" float:left; display:none;"/>
						<input type="button" id="btnDeleteRow3" value="删除一行" onclick="deleteRow3();" style=" float:left; display:none"/>
                        <br /><div>备注：明细见附表</div>
                        <br />
					</td>
				</tr>

				<tr>
					<td class="tl PL10" colspan="4" style="line-height: 25px">
                        <span style="font-weight: bold">三级市场自接项目各成交区域实际拉数业绩见下表：</span><br />
                        <table id="tbDetail2" class='sample tc' width='95%' align="center">
                            <thead>
                                <tr>
                                    <td rowspan="2">统筹区域</td>
                                    <td rowspan="2">楼盘名称</td>
                                    <td colspan="12">
                                        <asp:TextBox ID="txt1k" runat="server" Width="30px"></asp:TextBox>年
                                        <asp:TextBox ID="txt1l" runat="server" Width="30px"></asp:TextBox>月拉数欠收业绩
                                    </td>
                                </tr>
                                <tr>
                                    <td>大海珠区</td>
                                    <td>大天河区</td>
                                    <td>大白云区</td>
                                    <td>大越秀区</td>
                                    <td>花都区</td>
                                    <td>番禺一部</td>
                                    <td>工商铺一部</td>
                                    <td>工商铺二部</td>
                                    <td>二级市场</td>
                                    <td>番禺二部</td>
                                    <td>芳村南海</td>
                                    <td>合计</td>
                                </tr>
                            </thead>
                            <%=SbHtml2.ToString()%>
                            <tr id="trFlag2">
                                <td colspan="2">合计</td>
                                <td><asp:TextBox ID="txt1m" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1n" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1o" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1p" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1q" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1r" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                
                                <td><asp:TextBox ID="txt1s" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1t" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1ut" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                              
                                <td><asp:TextBox ID="txt1pa" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1fc" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                                <td><asp:TextBox ID="txt1u" runat="server" Width="50px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
                            </tr>
                        </table>
						<input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style=" float:left; display:none"/>
						<input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style=" float:left; display:none"/>
                        <br />
                    </td>
				</tr>

                <tr>
                    <td class="tl PL10" colspan="4" style="line-height: 25px">
                        <table id="tbDetail4" class='sample tc' width='95%' align="center">
                            <tr>
                                <td colspan="2">
                                    截至<asp:TextBox ID="txt4a" runat="server" Width="30px"></asp:TextBox>年<asp:TextBox ID="txt4b" runat="server" Width="30px"></asp:TextBox>月三级市场自接项目拉数及坏账冲回情况统计
                                </td>
                            </tr>
                            <tr>
                                <td>对应成交月份</td>
                                <td><asp:TextBox ID="txt4c" runat="server" Width="30px"></asp:TextBox>年<asp:TextBox ID="txt4cc" runat="server" Width="30px"></asp:TextBox>月至<asp:TextBox ID="txt4d" runat="server" Width="30px"></asp:TextBox>年<asp:TextBox ID="txt4dd" runat="server" Width="30px"></asp:TextBox>月</td>
                            </tr>
                            <tr>
                                <td>拉数业绩</td>
                                <td><asp:TextBox ID="txt4e" runat="server" Width="80px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>坏账冲回业绩（文件交回或实收）</td>
                                <td><asp:TextBox ID="txt4f" runat="server" Width="80px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>已手工坏账业绩</td>
                                <td><asp:TextBox ID="txt4h" runat="server" Width="80px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>拉数坏账余额</td>
                                <td><asp:TextBox ID="txt4g" runat="server" Width="80px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>


                <tr>
                    <td colspan="4" class="tl PL10">
                        <div style="padding-top: 5px">
                            <span style="vertical-align: top">补充说明：</span>
                            <asp:textbox id="txt1v" runat="server" TextMode="MultiLine" Width="90%" Height="100px"></asp:textbox>
                        </div>
                    </td>
                </tr>

				<tr id="trManager1" class="noborder" style="height: 85px;">
					<td class="auto-style3">部门主管</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbNoIDx1" type="radio" name="agree1" /><label for="rdbNoIDx1">不同意</label><br />
						<textarea id="txtIDx1" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx1">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx1">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trManager2" class="noborder" style="height: 85px;">
					<td class="auto-style3">隶属主管</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbNoIDx2" type="radio" name="agree2" /><label for="rdbNoIDx2">不同意</label><br />
						<textarea id="txtIDx2" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx2">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx2">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trManager3" class="noborder" style="height: 85px;">
					<td class="auto-style3">部门负责人</td>
					<td colspan="3" class="tl PL10">
						<input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbNoIDx3" type="radio" name="agree3" /><label for="rdbNoIDx3">不同意</label><br />
						<textarea id="txtIDx3" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx3">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx3">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trShowFlow4" class="noborder" style="height: 85px;">
					<td rowspan="2" >法律部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx4" type="radio" name="agree4" /><label for="rdbYesIDx4">同意</label><input id="rdbNoIDx4" type="radio" name="agree4" /><label for="rdbNoIDx4">不同意</label><input id="rdbOtherIDx4" type="radio" name="agree4" /><label for="rdbOtherIDx4">其他意见</label><br />
						<textarea id="txtIDx4" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx4" value="签署意见" onclick="sign('4')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx4">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx4">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trShowFlow5" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx5" type="radio" name="agree5"/><label for="rdbYesIDx5">同意</label><input id="rdbNoIDx5" type="radio" name="agree5" /><label for="rdbNoIDx5">不同意</label><input id="rdbOtherIDx5" type="radio" name="agree5" /><label for="rdbOtherIDx5">其他意见</label><br />
						<textarea id="txtIDx5" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx5" value="签署意见" onclick="sign('5')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx5">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx5">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trShowFlow6" class="noborder" style="height: 85px;">
					<td rowspan="3" class="auto-style3" >财务部意见</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx6" type="radio" name="agree6" /><label for="rdbYesIDx6">同意</label><input id="rdbNoIDx6" type="radio" name="agree6" /><label for="rdbNoIDx6">不同意</label><input id="rdbOtherIDx6" type="radio" name="agree6" /><label for="rdbOtherIDx6">其他意见</label>
                        <asp:CheckBox ID="ckbAddIDx7" runat="server" Text="增加审批环节"  Visible="false"/><br />
						<textarea id="txtIDx6" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx6" value="签署意见" onclick="sign('6')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx6">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx6">_________</span></div>--%>
					</td>
				</tr>
				<tr id="trShowFlow7" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx7" type="radio" name="agree7" /><label for="rdbYesIDx7">同意</label><input id="rdbNoIDx7" type="radio" name="agree7" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx7" type="radio" name="agree7" /><label for="rdbOtherIDx7">其他意见</label><br />
						<textarea id="txtIDx7" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx7" value="签署意见" onclick="sign('7')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx7">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx7">_________</span></div>--%>
					</td>
				</tr>
                <tr id="trShowFlow8" class="noborder" style="height: 85px;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label><input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx7">不同意</label><input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
						<textarea id="txtIDx8" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签署意见" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx8">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx8">_________</span></div>--%>
					</td>
				</tr>
<%--                <tr id="add1F" style="display: none">
                    <td colspan="4">
                        <table id="tbAddFlows" class='sample tc' width='100%'>
                            <tr id="trAddFlowBefore">
                                
                                <td>
                                    <asp:Button ID="btnSaveLogisticsFlow" runat="server" Text="" OnClientClick="return SaveFlow();" OnClick="btnSaveLogisticsFlow_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>--%>
                <%=SbHtmlLogisticsFlow.ToString()%>
<%--                <tr id="trLogistics1" class="noborder" style="height: 85px;display: none;">
					<td rowspan="4" >后勤事务部意见<br />
    <asp:Button ID="btnShouldJumpIDxEmma" runat="server" OnClick="btnJumpEmma_Click" Visible="False" />
    <asp:Button ID="btnWillEnd" runat="server" Text="结束" OnClick="btnWillEnd_Click" Visible="False" /></td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">确认</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">退回申请</label><br />
						<textarea id="txtIDx9" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>
					</td>
				</tr>
				<tr id="trLogistics2" class="noborder" style="height: 85px;display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx10" type="radio" name="agree10" /><label for="rdbYesIDx10">同意</label><input id="rdbNoIDx10" type="radio" name="agree10" /><label for="rdbNoIDx10">不同意</label><input id="rdbOtherIDx10" type="radio" name="agree10" /><label for="rdbOtherIDx10">其他意见</label><br />
                      　<a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#add1F').show();addFlow();">增加审批环节</a>
                      　<a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
						<textarea id="txtIDx10" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx10" value="签署意见" onclick="sign('10')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx10">_________</span></div>
					</td>
				</tr>
                <tr id="tlsc1" class="noborder" style="height: 85px; display: none;">
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx130" type="radio" name="agree130" value="1" /><label for="rdbYesIDx130">同意</label><input id="rdbNoIDx130" type="radio" name="agree130" value="2" /><label for="rdbNoIDx130">不同意</label><input id="rdbOtherIDx130" type="radio" name="agree130" /><label for="rdbOtherIDx130">其他意见</label><br />
						<textarea id="txtIDx130" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S2"></textarea><input type="button" id="btnSignIDx130" value="签署意见" onclick="sign('130')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx130">_________</span></div>
					</td>
				</tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" style="line-height: 0px"></td></tr>
                <tr><td style="line-height: 0px"></td><td colspan="3" id="trtpdf" style="line-height: 0px"></td></tr>--%>
				<tr id="trGeneralManager" class="noborder" style="height: 85px;">
					<td class="auto-style3" >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx9" type="radio" name="agree9" /><label for="rdbYesIDx9">同意</label><input id="rdbNoIDx9" type="radio" name="agree9" /><label for="rdbNoIDx9">不同意</label>
                        <input id="rdbOtherIDx9" type="radio" name="agree9" /><label for="rdbOtherIDx9">其他意见</label><br />
						<textarea id="txtIDx9" rows="5" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx9" value="签署意见" onclick="sign('9')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx9">_________</span>
                        </span>
                        <%--<div class="signdate">日期：<span id="spanDateIDx9">_________</span></div>--%>
					</td>
				</tr>
                
<%--                <tr id="tlsc2" class="noborder" style="height: 85px; display: none;">
					<td >董事总经理<br />审批</td>
					<td colspan="3" class="tl PL10" style=" ">
						<input id="rdbYesIDx131" type="radio" name="agree131" value="1" /><label for="rdbYesIDx131">同意</label><input id="rdbNoIDx131" type="radio" name="agree131" value="2" /><label for="rdbNoIDx131">不同意</label><input id="rdbOtherIDx131" type="radio" name="agree131" /><label for="rdbOtherIDx131">其他意见</label><br />
						<textarea id="txtIDx131" rows="5" style="width: 98%; overflow: auto;" cols="20" name="S3"></textarea><input type="button" id="btnSignIDx131" value="签署意见" onclick="sign('131')" style="display: none;" /><div class="signdate">日期：<span id="spanDateIDx131">_________</span></div>
					</td>
				</tr>--%>
                
                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3" >申请人回复审批意见<br />（可选项）</td>
					<td colspan="3" class="tl PL10" style=" ">
						<textarea id="txtIDx200" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx200">_________</span>
                        </span>
                        <%--<div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx200">_________</span></div>--%>
					</td>
				</tr>

                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
					<td class="auto-style3" >董事总经理复审</td>
					<td colspan="3" class="tl PL10" style=" ">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#008162" />
						<textarea id="txtIDx220" runat="server" rows="6" style="width: 98%; overflow: auto;"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">
                            日期：<span id="spanDateIDx220">_________</span>
                        </span>
                        <%--<div class="signdate" style="padding-top: 25px">日期：<span id="spanDateIDx220">_________</span></div>--%>
					</td>
				</tr>
                
			</table>
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
        <span style="font-size: large; padding-top: 10px; padding-bottom: 10px"><a href="../../资料/三级市场一手项目欠必要性文件拉数申请_导入 模板.xlsx">下载导入模板</a></span>
        <br />
        <asp:button runat="server" id="btnImport" text="导入数据" OnClick="btnImport_Click" onclientclick="return Imports();" />
        <asp:button runat="server" id="btnReWrite" text="重新导入" OnClick="btnReWrite_Click" Visible="False"/>

		<asp:button runat="server" id="btnSave" text="保存" onclick="btnSave_Click" onclientclick="return check();" visible="false" />
        <asp:button runat="server" id="btnTemp" text="暂时保存" onclick="btnTempSave_Click" CssClass="commonbtn" onclientclick="return tempsavecheck();" />
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
            <input type="hidden" id="hdFilePath" runat="server" />
        <asp:hiddenfield id="hdCancelSign" runat="server" />
        <asp:button id="btnCancelSign" runat="server" onclick="btnCancelSign_Click" style="display: none;" />
            </div>
            </div>
	</div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
    <script type="text/javascript">
        $.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应
    </script>
    <%-- 黄生审批的申请：同部门审批栏只显示最高级别的审批(2016/10/8--52100) --%>
    <script type="text/javascript" src="../../../Script/ApprovalBar.js"></script>
</asp:Content>

