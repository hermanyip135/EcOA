<%@ Page ValidateRequest="false" Title="物业部承接新项目申请表2019 - 广州中原电子审批系统" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_UtNewProj_Detail_New.aspx.cs" Inherits="Apply_UndertakeProj_201908_Apply_UtNewProj_Detail_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../../../Script/common_new.js"></script>
    <script type="text/javascript">
        var i1 = 1, i2 = 2, i3 = 1, cou = 0 * 1;
        <%-- var jJSON = <%=SbJson.ToString() %> --%>;
        var isUploaded = 0;
        var isNewApply = ('<%=IsNewApply%>' == 'True');
        var jsccesp = <%=SbCcesp.ToString() %>;
        var numberReg = new RegExp("^[0-9]*$");
        function split(val) {
            return val.split(/,\s*/);
        }
        function extractLast(term) {
            return split(term).pop();
        }
        function isjson(obj) {
            var isjson = typeof (obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length;
            return isjson;
        }

        $(function () {
            //初始化时间控件
            $("[dateplugin='datepicker']").each(function () {
                $(this).datepicker();
            });

            if ($("#btnSignIDx15").is(':visible')) {
                $("#sp005").show();
            } else {
                $("#sp005").hide();
            }

            if ($("#btnSignIDx1").is(':visible')) {
                //  console.log('1');
                $("#sp001").show();
            } else {
                $("#sp001").hide();
            }

            if (!$("[id*=cblDealOfficeType_3]").prop("checked"))
                $("#Ct4").hide();
            else
                $("#Ct4").show();

            $("[id*=cblDealOfficeType_3]").click(function () {
                if (!$("[id*=cblDealOfficeType_3]").prop("checked"))
                    $("#Ct4").hide();
                else
                    $("#Ct4").show();
            });
            //IsDirectContractBind();

            $("[for^=rdbOtherIDx]").css("color", "#186ebe");

            $("[id*=btnsSignIDx]").css({
                "background-image": "url(/Images/btnSureS1.png)",
                "height": "25px",
                "width": "43px",
                "font-size": "0px",
                "cursor": "pointer",
                "color": "#FFFFFF"
            });

            $("[id*=btnsSignIDx]").mousedown(function () { $(this).css("background-image", "url(/Images/btnSureS2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btnSureS1.png)"); });

            //$("#tbDealOfficeType").find("td").css("border", "none");
            //$("#tClient").find("td").css("border", "none");
            //$("#tEB").find("td").css("border", "none"); 

            i1 = $("#tbDealOfficeType tbody tr").length;
            i2 = $("#tbAgentCompanyInfo tbody tr").length;
            i3 = $("#dvCommFeeTypeInfo div").length;

            $("#txtAgentStartDate").datepicker();
            $("#txtAgentEndDate").datepicker();
            $("#txtClientGuardStartDate").datepicker();
            $("#txtClientGuardEndDate").datepicker();
            $("#txtReturnBackDate").datepicker();

            autoTextarea($("#txtIDx200"));
            autoTextarea($("#txtIDx210"));
            autoTextarea($("#txtIDx211"));
            autoTextarea($("#txtIDx220"));

            //$.each($("textarea:not([id*=txtDescribe])"), function (idx, item) { autoTextarea(this); }); //使对话框自适应

            $("#dvCashPrizeDetail").hide();
            $("input[name=IsHaveCashPrize]").click(function () {
                //debugger;
                var yes = $("#rbtnHaveCash").prop("checked");
                var no = $("#rbtnNotHaveCash").prop("checked");
                if (yes == true) {
                    $("#dvCashPrizeDetail").show();
                    $("#hidIsHaveCashPrize").val(1)
                }
                else {
                    $("#dvCashPrizeDetail").hide();
                    $("#hidIsHaveCashPrize").val(2)
                }
            })

            $("#txtProject").autocomplete({
                source: jsccesp,
                select: function (event, ui) {
                    //debugger;
                    $("#hfKey1").val(ui.item.id);
                    $("#hidProjectID").val(ui.item.id);
                }
            });

            $("#txtCoordinatorCode").blur(function () {
                getEmpInfoByCode($(this).val(),1);
            })

            $("#txtAreaCheckDataerCode").blur(function () {
                getEmpInfoByCode($("#txtAreaCheckDataerCode").val(),2);
            })

            
            $("input[name=IsPreSale]").click(function () {
                //debugger;
                var yes = $("#rbtIsPreSale1").prop("checked");
                var no = $("#rbtIsPreSale2").prop("checked");
                if (yes == true) {
                    $("#hidIsPreSale").val(1);
                }
                else {
                    $("#hidIsPreSale").val(2);
                }
            })

            $("input[name=IsOneOrTwo]").click(function () {
                //debugger;
                var yes = $("#rbtIsOneOrTwo1").prop("checked");
                var no = $("#rbtIsOneOrTwo2").prop("checked");
                if (yes == true) {
                    $("#hidIsOneOrTwo").val(1);
                }
                else {
                    $("#hidIsOneOrTwo").val(2);
                }
            })

            $("input[id*=BaseAgent]").click(function () {
                //debugger;
                var ba1 = $("#cbBaseAgent1");
                var ba2 = $("#cbBaseAgent2");
                var ba3 = $("#cbBaseAgent3");
                var ba4 = $("#cbBaseAgent4");

                if (ba2.prop("checked") == true || ba3.prop("checked") == true) {
                    alert("注意：公司不建议承接行家做内场刀手的项目，选了该项则无法保存！");
                    $("#<%=btnTemp.ClientID %>").hide();
                    $("#<%=btnSave.ClientID %>").hide();
                }
                else {
                    var bav1 = ba1.prop("checked") == true?ba1.val():"";
                    var bav2 = ba2.prop("checked") == true?ba2.val():"";
                    var bav3 = ba3.prop("checked") == true?ba3.val():"";
                    var bav4 = ba4.prop("checked") == true?ba4.val():"";

                    $("#hidBaseAgent").val(bav1+"|"+bav2+"|"+bav3+"|"+bav4);

                    $("#<%=btnTemp.ClientID %>").show();
                    $("#<%=btnSave.ClientID %>").show();
                }
            })

            $("input[name=CustomerExtraThings]").click(function () {
                //debugger;
                var isSwipeCard = $("#rbtnIsSwipeCard").prop("checked");
                var isRenovation = $("#rbtnIsRenovation").prop("checked");
                var isOther = $("#rbtnOther").prop("checked");

                if (isSwipeCard == true) {
                    $("#hidCustomerExtraThings").val(1);
                }
                if (isRenovation) {
                    $("#hidCustomerExtraThings").val(2);
                }
                if (isOther) {
                    $("#hidCustomerExtraThings").val(3);
                }

            })

            $("input[id*=ckbPF]").click(function () {
                //debugger;
                var zy = $("#ckbPFZY");
                var fyq = $("#ckbPFFYQ");
                var isZY = zy.prop("checked") == true?zy.val():"";
                var isFYQ = fyq.prop("checked") == true?fyq.val():"";

                $("#hidPanFangTuoDiCompany").val(isZY+"|"+isFYQ);
            })

            $("input[name=IsDeveloperAndZYHaveContract]").click(function () {
                //debugger;
                var yes = $("#rdbHaveContrac").prop("checked");
                var no = $("#rdbNotHaveContrac").prop("checked");

                if (yes == true) {
                    $("#hidIsDeveloperAndZYHaveContract").val(1);
                }
                if (no) {
                    $("#hidIsDeveloperAndZYHaveContract").val(2);
                }

            })

            $("input[name=CashPrizePayType]").click(function () {
                //debugger;
                var yes = $("#rbtnCashPrizePayType1").prop("checked");
                var no = $("#rbtnCashPrizePayType2").prop("checked");

                if (yes == true) {
                    $("#hidCashPrizePayType").val(1);
                }
                if (no) {
                    $("#hidCashPrizePayType").val(2);
                }

            })

            $("input[name=IsMyPay]").click(function () {
                //debugger;
                var yes = $("#rdbIsMyPay1").prop("checked");
                var no = $("#rdbIsMyPay2").prop("checked");

                if (yes == true) {
                    $("#hidIsMyPay").val(1);
                }
                if (no) {
                    $("#hidIsMyPay").val(2);
                }

            })

            $("input[name=IsAreaConfirm]").click(function () {
                //debugger;
                var yes = $("#rdbAreaConfirm1").prop("checked");
                var no = $("#rdbAreaConfirm2").prop("checked");

                if (yes == true) {
                    $("#hidIsAreaConfirm").val(1);
                }
                if (no) {
                    $("#hidIsAreaConfirm").val(2);
                }

            })

            $("input[id*=ckbMI]").click(function () {
                //debugger;
                var mi1 = $("#ckbMINoCashback");
                var mi2 = $("#ckbMIProbity");
                var mi3 = $("#ckbMIZoneRestrictions");

                var miv1 = mi1.prop("checked") == true?mi1.val():"";
                var miv2 = mi2.prop("checked") == true?mi2.val():"";
                var miv3 = mi3.prop("checked") == true?mi3.val():"";

                $("#hidMajorIssues").val(miv1+"|"+miv2+"|"+miv3);

            })
            
            $("input[id*=cbLack]").click(function () {
                //debugger;
                var lack1 = $("#cbLack1");
                var lack2 = $("#cbLack2");
                var lack3 = $("#cbLack3");
                var lack4 = $("#cbLack4");
                var lack5 = $("#cbLack5");
                var lack6 = $("#cbLack6");
                var lack7 = $("#cbLack7");

                var lackv1 = lack1.prop("checked") == true?lack1.val():"";
                var lackv2 = lack2.prop("checked") == true?lack2.val():"";
                var lackv3 = lack3.prop("checked") == true?lack3.val():"";
                var lackv4 = lack4.prop("checked") == true?lack4.val():"";
                var lackv5 = lack5.prop("checked") == true?lack5.val():"";
                var lackv6 = lack6.prop("checked") == true?lack6.val():"";
                var lackv7 = lack7.prop("checked") == true?lack7.val():"";

                $("#hidLack").val(lackv1+"|"+lackv2+"|"+lackv3+"|"+lackv4+"|"+lackv5+"|"+lackv6+"|"+lackv7);

            })



            $("#dvCashPrizeConditions").hide();
            $("#dvSameCashPrize").hide();
            $("#dvNotSameCashPrize").hide();
            $("#dvOtherPrize").hide();

            $("#txtMoneyPerSet").hide();
            $("#lblMoneyPerSet").hide();
            $("#lblPercentPerSet").hide();

            $("#tbNotSameCashPrize").hide();
            $("#tdMoneyPrize").hide();
            $("#tdDealDate").hide();
            $("#tdDealSet").hide();
            $("#tdDealSize").hide();
            $("#tdDealPrice").hide();
            $("#tdDealOfficeType").hide();

            //现金奖计算方式
            $("input[name=CashPrizeType]").click(function () {
                //debugger;
                var price = $("#rbtnMoneyPerSet").prop("checked");
                var percent = $("#rbtnPercentPerSet").prop("checked");
                var realThing = $("#rbtnOtherPrizePerSet").prop("checked");

                var cashPrizeConditions = $("#hidCashPrizeConditions").val();

                var type = "";
                if (price) type = "1";
                if (percent) type = "2";
                if (realThing) type = "3";
                $("#hidCashPrizeType").val(type);

                if (cashPrizeConditions != "") {
                    if (cashPrizeConditions == "1") {
                        $("#dvOtherPrize").hide();
                        $("#dvSameCashPrize").show();
                        $("#txtMoneyPerSet").show();

                        //勾选 固定金额
                        if (price) {
                            $("#lblMoneyPerSet").show();
                            $("#lblPercentPerSet").hide();
                        }

                        //勾选 成交价百分比
                        if (percent) {
                            $("#lblPercentPerSet").show();
                            $("#lblMoneyPerSet").hide();
                        }

                    }

                    if (cashPrizeConditions == "2") {
                        //StructureTable(1, $("#hidCashPrizeType").val());
                        StructureTable();
                    }

                    //勾选 实物奖励
                    if (realThing) {
                        //在隐藏域保存 固定金额的值 3；
                        $("#hidCashPrizeType").val(3);

                        $("#dvSameCashPrize").hide();
                        $("#dvNotSameCashPrize").hide();
                        $("#dvCashPrizeConditions").hide();

                        $("#dvOtherPrize").show();
                    }
                    else {
                        //清空隐藏域的值
                        $("#hidCashPrizeType").val("");
                        $("#dvCashPrizeConditions").show();
                        $("#dvOtherPrize").hide();
                    }
                }
                else {
                    if (price || percent || realThing) {
                        $("#dvCashPrizeConditions").show();
                        var type = "";
                        if (price) type = "1";
                        if (percent) type = "2";
                        if (realThing) type = "3";
                        $("#hidCashPrizeType").val(type);
                    }
                }
            });


            //现金奖计算方式 dvCashPrizeConditions
            $("input[name=CashPrizeConditions]").click(function () {
                var same = $("#rbtnSameCashPrize").prop("checked");
                var notSame = $("#rbtnNotSameCashPrize").prop("checked");
                var other = $("#rbtnOtherCashPrize").prop("checked");

                var cashPrizeType = $("#hidCashPrizeType").val();

                if (same || notSame || other) {
                    //勾选 代理期内现金奖相同
                    if (same) {
                        $("#hidCashPrizeConditions").val("1");
                        $("#dvNotSameCashPrize").hide();
                        $("#dvSameCashPrize").show();
                        $("#txtMoneyPerSet").show();
                        if (cashPrizeType == "1") {
                            $("#lblMoneyPerSet").show();
                            $("#lblPercentPerSet").hide();
                        }

                        if (cashPrizeType == "2") {
                            $("#lblPercentPerSet").show();
                            $("#lblMoneyPerSet").hide();
                        }
                    }

                    //勾选 按条件划分现金奖
                    if (notSame) {
                        //debugger;
                        $("#hidCashPrizeConditions").val("2");
                        $("#dvSameCashPrize").hide();
                        $("#dvNotSameCashPrize").show();
                        //$("#tbNotSameCashPrize").show();
                        $("#tdMoneyPrize").show();
                        $("#txtMoneyPrize1").show();

                        //if (cashPrizeType == "1") {
                        //    $("#lblMoneyPerSet1").show();
                        //    $("#lblPercentPerSet1").hide();
                        //}

                        //if (cashPrizeType == "2") {
                        //    $("#lblPercentPerSet1").show();
                        //    $("#lblMoneyPerSet1").hide();
                        //}

                        //StructureTable(1, cashPrizeType);
                        StructureTable();

                    }


                    //勾选 实物奖励
                    if (other) {
                        $("#dvSameCashPrize").hide();
                        $("#dvNotSameCashPrize").hide();
                        $("#dvOtherPrize").show();
                    }

                }

            });

            $("input[id*=ckbNSCPC]").click(function () {
                //debugger;
                var dealDateBeginEnd = $("#ckbNSCPCDealDateBeginEnd").prop("checked");
                var dealSaleSet = $("#ckbNSCPCDealSaleSet").prop("checked");
                var dealSize = $("#ckbNSCPCDealSize").prop("checked");
                var dealPrice = $("#ckbNSCPCDealPrice").prop("checked");
                var dealDealOfficeType = $("#ckbNSCPCDealDealOfficeType").prop("checked");

                var col = "";
                if (dealDealOfficeType) col += "1|";
                if (dealDateBeginEnd) col += "2|";
                if (dealSaleSet) col += "3|";
                if (dealSize) col += "4|";
                if (dealPrice) col += "5|";
                

                col = col.substr(0, col.lastIndexOf("|"));

                $("#hidCashPrizeChoiceConditions").val(col);

                StructureTable();

            })

            
            
        });

        

        //物业类型 增加一行
        addRow1 = function () {

            i1++;
            var html = '<tr id="trDealOfficeType' + i1 + '" >'
                     + '    <td style="border:none;">'
                     + '         <select id="sbDealOfficeType' + i1 + '" style="width: 80px; border: 1px solid #98b8b5">'
                     + '              <option value="-1">请选择</option><option value="3">住宅</option>'
                     + '              <option value="4">公寓</option> <option value="5">写字楼</option>'
                     + '              <option value="6">商铺</option> <option value="7">车位</option>'
                     + '              <option value="8">别墅</option><option value="9">其他</option>'
                     + '         </select>'
                     + '     </td>'
                     + '     <td>'
                     + '        <select id="sbDiskSource' + i1 + '" style="width: 80px; border: 1px solid #98b8b5">'
                     + '            <option value="-1">请选择</option><option value="1">市内A盘</option>'
                     + '            <option value="2">市外B盘</option>'
                     + '        </select>'
                     + '     </td>'
                     + '     <td><input id="txtTotalSize' + i1 + '" name="txtTotalSize' + i1 + '" type="text" /></td>'
                     + '     <td><input id="txtTotalUnitCount' + i1 + '" name="txtTotalUnitCount' + i1 + '" type="text" /></td>'
                     + '    <td><input id="txtUnitPrice' + i1 + '" name="txtUnitPrice' + i1 + '" type="text"  /></td>'
                     + '    <td><input id="txtSizeSegments' + i1 + '" name="txtSizeSegments' + i1 + '" type="text"  /></td>'
                     + '     <td><input id="txtPreCompleteCount' + i1 + '" name="txtPreCompleteCount' + i1 + '" type="text"  /></td>'
                     + '     <td><input id="txtPreComm' + i1 + '" name="txtPreComm' + i1 + '" type="text" /></td>'
                     + '</tr>';
            $("#tbDealOfficeType tbody").append(html);
        };
        //物业类型 删除一行
        deleteRow1 = function () {
            if (i1 > 1) {
                i1--;
                $("#tbDealOfficeType tbody tr:eq(" + i1 + ")").remove();
                //AutoAdd();
            }
            else alert("不可再删除。");
        };

        //行家信息 增加一行
        addRow2 = function () {

            i2++;
            var html = '<tr id="trAgentCompanyInfo1' + i2 + '" >'
                     + '    <td>'
                     + '         <input id="txtAgentCompanyName' + i2 + '" name="txtAgentCompanyName" type="text" style="width: 100px;" />'
                     + '     </td>'
                     + '     <td>'
                     + '        <select id="sbAgentCompanyType' + i2 + '" name="sbAgentCompanyType" style="width: 80px; border: 1px solid #98b8b5">'
                     + '            <option value="-1">请选择</option><option value="1">市内A盘</option>'
                     + '            <option value="1">电商</option>'
                     + '            <option value="2">代理商</option>'
                     + '            <option value="3">中介</option>'
                     + '        </select>'
                     + '     </td>'
                     + '     <td><input id="txtAgentFeeAndCashPrizeSituation' + i2 + '" name="txtAgentFeeAndCashPrizeSituation' + i2 + '" type="text" style="width: 90%; margin-left: 10px;" /></td>'
                     + '</tr>';
            $("#tbAgentCompanyInfo tbody").append(html);
        };
        //行家信息 删除一行
        deleteRow2 = function () {
            if (i2 > 2) {
                i2--;
                $("#tbAgentCompanyInfo tbody tr:eq(" + i2 + ")").remove();
                //AutoAdd();
            }
            else alert("不可再删除。");
        };

        //代理费类型 增加一行
        addRow3 = function () {
            //debugger;
            i3++;
            var html = '<div id="dvCommFeeTypeInfo' + i3 + '" style="margin-top: 10px; text-align: left; border-top:1px solid black; padding-top:10px;">'
                     + '    <select id="sbCommFeeType' + i3 + '" name="sbCommFeeType' + i3 + '" style="width: 80%; border: 1px solid #98b8b5;">'
                     + '            <option value="-1">请选择</option>'
                     + '            <option value="1">电商</option>'
                     + '            <option value="2">代理商</option>'
                     + '            <option value="3">中介</option>'
                     + '     </select>'
                     + '     <br />'
                     + '     1）签约公司名称：'
                     + '     <input id="txtContractingCompanyName' + i3 + '" name="txtContractingCompanyName' + i3 + '" type="text" style="width: 150px; margin-left: 10px;" />'
                     + '     <br />'
                     + '     2）佣金跳BAR方式：'
                     + '     <input id="rdbOwnerCommJump' + parseInt((i3 * i3 + 1), 10) + '" type="radio" name="OwnerCommJump' + i3 + '" value="' + parseInt((i3 * i3 + 1), 10) + '" style="vertical-align: middle;" />'
                     + '     <label class="rbtLabelCss">全跳BAR</label>'
                     + '     <input id="rdbOwnerCommJump' + parseInt((i3 * i3 + 2), 10) + '" type="radio" name="OwnerCommJump' + i3 + '" value="' + parseInt((i3 * i3 + 2), 10) + '" style="vertical-align: middle;" />'
                     + '     <label class="rbtLabelCss">分级跳BAR</label>'
                     + '     <input id="rdbOwnerCommJump' + parseInt((i3 * i3 + 3), 10) + '" type="radio" name="OwnerCommJump' + i3 + '" value="' + parseInt((i3 * i3 + 3), 10) + '" style="vertical-align: middle;" />'
                     + '     <label class="rbtLabelCss">无跳BAR</label>'
                     + '     <br />'
                     + '     3）代理条件'
                     + '     <textarea id="txtaAgentConditions' + i3 + '" cols="20" rows="2" style="width: 90%; height: 35px;"></textarea>'
                     + '     <br />'
                     + '     4）合同约定结佣条件'
                     + '     <textarea id="txtaCommConditions' + i3 + '" cols="20" rows="2" style="width: 90%; height: 35px;"></textarea>'
                     + '     <br />'
                     + '</div>';
            $("#dvCommFeeTypeInfo").append(html);
        };
        //代理费类型 删除一行
        deleteRow3 = function () {
            if (i3 > 1) {
                i3--;
                $("#dvCommFeeTypeInfo div:eq(" + i3 + ")").remove();
                //AutoAdd();
            }
            else alert("不可再删除。");
        };

        //按列生成现金奖 增加一行
        addRow4 = function () {
            //debugger;
            i3++;
            var html = '<div id="dvCommFeeTypeInfo' + i3 + '" style="margin-top: 10px; text-align: left; border-top:1px solid black; padding-top:10px;">'
                     + '    <select id="sbCommFeeType' + i3 + '" name="sbCommFeeType' + i3 + '" style="width: 80%; border: 1px solid #98b8b5;">'
                     + '            <option value="-1">请选择</option>'
                     + '            <option value="1">电商</option>'
                     + '            <option value="2">代理商</option>'
                     + '            <option value="3">中介</option>'
                     + '     </select>'
                     + '     <br />'
                     + '     1）签约公司名称：'
                     + '     <input id="txtContractingCompanyName' + i3 + '" name="txtContractingCompanyName' + i3 + '" type="text" style="width: 150px; margin-left: 10px;" />'
                     + '     <br />'
                     + '     2）佣金跳BAR方式：'
                     + '     <input id="rdbOwnerCommJump' + parseInt((i3 * i3 + 1), 10) + '" type="radio" name="OwnerCommJump' + i3 + '" value="' + parseInt((i3 * i3 + 1), 10) + '" style="vertical-align: middle;" />'
                     + '     <label class="rbtLabelCss">全跳BAR</label>'
                     + '     <input id="rdbOwnerCommJump' + parseInt((i3 * i3 + 2), 10) + '" type="radio" name="OwnerCommJump' + i3 + '" value="' + parseInt((i3 * i3 + 2), 10) + '" style="vertical-align: middle;" />'
                     + '     <label class="rbtLabelCss">分级跳BAR</label>'
                     + '     <input id="rdbOwnerCommJump' + parseInt((i3 * i3 + 3), 10) + '" type="radio" name="OwnerCommJump' + i3 + '" value="' + parseInt((i3 * i3 + 3), 10) + '" style="vertical-align: middle;" />'
                     + '     <label class="rbtLabelCss">无跳BAR</label>'
                     + '     <br />'
                     + '     3）代理条件'
                     + '     <textarea id="txtaAgentConditions' + i3 + '" cols="20" rows="2" style="width: 90%; height: 35px;"></textarea>'
                     + '     <br />'
                     + '     4）合同约定结佣条件'
                     + '     <textarea id="txtaCommConditions' + i3 + '" cols="20" rows="2" style="width: 90%; height: 35px;"></textarea>'
                     + '     <br />'
                     + '</div>';
            $("#dvCommFeeTypeInfo").append(html);
        };
        //按列生成现金奖 删除一行
        deleteRow4 = function () {
            if (i3 > 1) {
                i3--;
                $("#dvCommFeeTypeInfo div:eq(" + i3 + ")").remove();
                //AutoAdd();
            }
            else alert("不可再删除。");
        };

        getEmpInfoByCode = function (code,type) {
            //debugger;
            var isNum = numberReg.test(code);
            if (!isNum) {
                alert("请输入数字工号");
                $("#txtCoordinatorCode").val("").focus();
            }
            else {
                $.post("../../../Ajax/Apply_UtNewProj_Detail_New.ashx?t=1&rn="+Math.random()+"",{empcode:code},function(data){
                    //debugger;
                    if (data != null && data != "" && data.length > 0) {
                        var json = eval(data[0]);
                        if (type == "1") {
                            //项目统筹人 数据绑定
                            $("#txtCoordinatorName").val(json.EmployeeName);
                            $("#txtCoordinatorPhone").val(json.Telphone);
                            $("#txtCoordinatorDept").val(json.UnitName);
                        }
                        else {
                            //项目驻场 数据绑定
                            $("#txtAreaCheckDataer").val(json.EmployeeName);
                            $("#txtAreaCheckDataerPhone").val(json.Telphone);
                        }
                        
                    }
                },"json");
            }
        };

        check = function () {
            if ($("#txtCoordinatorCode").val() == "" || $("#txtCoordinatorCode").val() == null)
            {
                alert("请输入统筹人工号");
                $("#txtCoordinatorCode").focus();
                return false;
            }

            if ($("#txtAreaCheckDataerCode").val() == "" || $("#txtAreaCheckDataerCode").val() == null)
            {
                alert("请输入驻场工号");
                $("#txtAreaCheckDataerCode").focus();
                return false;
            }

            if ($("#txtProject").val() == "" || $("#txtProject").val() == null)
            {
                alert("请输入项目名称");
                $("#txtAreaCheckDataerCode").focus();
                return false;
            }

            if ($("#hidIsPreSale").val() == "" || $("#hidIsPreSale").val() == null)
            {
                alert("请选择是否有预售证");
                $("#rbtIsPreSale1").focus();
                return false;
            }

            if ($("#hidIsOneOrTwo").val() == "" || $("#hidIsOneOrTwo").val() == null)
            {
                alert("请选择项目性质");
                $("#rbtIsPreSale1").focus();
                return false;
            }

            if ($("#txtDeveloper").val() == "" || $("#txtDeveloper").val() == null)
            {
                alert("请填写预售证发展商");
                $("#txtDeveloper").focus();
                return false;
            }

            if ($("#sbDealType").val() == "" || $("#sbDealType").val() == null)
            {
                alert("请选择代理类型");
                $("#sbDealType").focus();
                return false;
            }

            if ($("#txtDeveloperContacter").val() == "" || $("#txtDeveloperContacter").val() == null)
            {
                alert("请填写发展商联系人姓名");
                $("#txtDeveloperContacter").focus();
                return false;
            }

            if ($("#txtDeveloperContacterPosition").val() == "" || $("#txtDeveloperContacterPosition").val() == null)
            {
                alert("请填写发展商联系人职位");
                $("#txtDeveloperContacterPosition").focus();
                return false;
            }

            if ($("#txtDeveloperContacterPhone").val() == "" || $("#txtDeveloperContacterPhone").val() == null)
            {
                alert("请填写发展商联系人联系电话");
                $("#txtDeveloperContacterPhone").focus();
                return false;
            }

            if ($("#sbProjectLocation").val() == "" || $("#sbProjectLocation").val() == null)
            {
                alert("请选择项目所在地");
                $("#sbProjectLocation").focus();
                return false;
            }

            if ($("#hidDealOfficeTypeCount").val() == "" || $("#hidDealOfficeTypeCount").val() == null)
            {
                alert("请填写物业类型");
                $("#sbDealOfficeType1").focus();
                return false;
            }
            else {
                var count = $("#hidDealOfficeTypeCount").val();
                for (var i = 1; i <= count; i ++){
                    if ($("#sbDealOfficeType"+i+"").val() == "" || $("#sbDealOfficeType"+i+"").val() == null)
                    {
                        alert("请选择物业类型");
                        $("#sbDealOfficeType"+i+"").focus();
                        return false;
                    }

                    if ($("#sbDiskSource"+i+"").val() == "" || $("#sbDiskSource"+i+"").val() == null)
                    {
                        alert("请选择AB盘类型");
                        $("#sbDiskSource"+i+"").focus();
                        return false;
                    }

                    if ($("#txtTotalSize"+i+"").val() == "" || $("#txtTotalSize"+i+"").val() == null)
                    {
                        alert("请填写承接货量-面积总计");
                        $("#txtTotalSize"+i+"").focus();
                        return false;
                    }

                    if ($("#txtTotalUnitCount"+i+"").val() == "" || $("#txtTotalUnitCount"+i+"").val() == null)
                    {
                        alert("请填写承接货量-套数总计");
                        $("#txtTotalUnitCount"+i+"").focus();
                        return false;
                    }

                    if ($("#txtUnitPrice"+i+"").val() == "" || $("#txtUnitPrice"+i+"").val() == null)
                    {
                        alert("请填写承接货量-单价");
                        $("#txtUnitPrice"+i+"").focus();
                        return false;
                    }

                    if ($("#txtSizeSegments"+i+"").val() == "" || $("#txtSizeSegments"+i+"").val() == null)
                    {
                        alert("请填写承接货量-面积段");
                        $("#txtSizeSegments"+i+"").focus();
                        return false;
                    }

                    if ($("#txtPreCompleteCount"+i+"").val() == "" || $("#txtPreCompleteCount"+i+"").val() == null)
                    {
                        alert("请填写预估目标-完成套数");
                        $("#txtPreCompleteCount"+i+"").focus();
                        return false;
                    }

                    if ($("#txtPreComm"+i+"").val() == "" || $("#txtPreComm"+i+"").val() == null)
                    {
                        alert("请填写预估目标-佣金收入");
                        $("#txtPreComm"+i+"").focus();
                        return false;
                    }
                }
            }

            if ($("#hidBaseAgent").val() == "" || $("#hidBaseAgent").val() == null)
            {
                alert("请勾选场内代理");
                $("#cbBaseAgent1").focus();
                return false;
            }
            else {
                var ba = $("#hidBaseAgent").val();
                if (ba.indexOf("4") > 0){
                    alert("请填写其他场内代理的内容");
                    $("#txtBaseAgentOther").focus();
                    return false;
                }
            }

            if ($("#hidAgentCompanyInfoCount").val() == "" || $("#hidAgentCompanyInfoCount").val() == null)
            {
                alert("请填写行家信息");
                $("#txtAgentCompanyName1").focus();
                return false;
            }
            else {
                //debugger;
                var count = $("#hidAgentCompanyInfoCount").val();
                for (var i = 1; i <= count; i ++){
                    if ($("#txtAgentCompanyName"+i+"").val() == "" || $("#txtAgentCompanyName"+i+"").val() == null)
                    {
                        alert("请填写代理公司名称");
                        $("#txtAgentCompanyName"+i+"").focus();
                        return false;
                    }

                    if ($("#sbAgentCompanyType"+i+"").val() == "" || $("#sbAgentCompanyType"+i+"").val() == null)
                    {
                        alert("请选择公司类型");
                        $("#sbAgentCompanyType"+i+"").focus();
                        return false;
                    }

                    if ($("#txtAgentFeeAndCashPrizeSituation"+i+"").val() == "" || $("#txtAgentFeeAndCashPrizeSituation"+i+"").val() == null)
                    {
                        alert("请填写代理费及现金奖情况");
                        $("#txtAgentFeeAndCashPrizeSituation"+i+"").focus();
                        return false;
                    }
                }
            }

            if ($("#hidCustomerExtraThings").val() == "" ||$("#hidCustomerExtraThings").val()== null){
                alert("请选择客户需支付的额外费用");
                $("#rbtnIsSwipeCard").focus();
                return false;
            }
            else {
                var CustomerExtraThings = $("#hidCustomerExtraThings").val();
                if (CustomerExtraThings == "1") {
                    if ($("#txtPrePayMoney").val() == "" || $("#txtDiscountMoney").val() == ""){
                        alert("请填写刷卡的金额和抵消的金额");
                        $("#txtPrePayMoney").focus();
                        return false;
                    }
                }

                if (CustomerExtraThings == "2") {
                    if ($("#txtRenovationFee").val() == "" || $("#txtRenovationFee").val() == null){
                        alert("请填写改造费用");
                        $("#txtRenovationFee").focus();
                        return false;
                    }
                }

                if (CustomerExtraThings == "3") {
                    if (($("#txtOtherFeeType").val() == "" || $("#txtOtherFeeType").val() == null) || ($("#txtOtherFee").val() == "" || $("#txtOtherFee").val() == null)){
                        alert("请填写其他花费的内容和金额");
                        $("#txtOtherFeeType").focus();
                        return false;
                    }
                }
            }

            if ($("#txtAgentStartDate").val() == "" || $("#txtAgentStartDate").val()== null){
                alert("请填写代理开始日期");
                $("#txtAgentStartDate").focus();
                return false;
            }

            if ($("#txtAgentEndDate").val() == "" || $("#txtAgentEndDate").val()== null){
                alert("请填写代理结束日期");
                $("#txtAgentEndDate").focus();
                return false;
            }

            if ($("#hidIsHaveCashPrize").val() == "" || $("#hidIsHaveCashPrize").val()== null){
                alert("请选择是否有现金奖");
                $("#rbtnHaveCash").focus();
                return false;
            }
            else {
                var IsHaveCashPrize = $("#hidIsHaveCashPrize").val();
                if (IsHaveCashPrize == "1") {
                    if ($("#txtCorporateName").val() == "" || $("#txtCorporateName").val() == null){
                        alert("请填写签约公司名称");
                        $("#txtCorporateName").focus();
                        return false;
                    }

                    if ($("#sbCorporateType").val() == "" || $("#sbCorporateType").val() == null){
                        alert("请选择公司类型");
                        $("#sbCorporateType").focus();
                        return false;
                    }

                    if ($("#txtCashPrize").val() == "" || $("#txtCashPrize").val() == null){
                        alert("请填写现金奖金额");
                        $("#txtCashPrize").focus();
                        return false;
                    }

                    if ($("#txtaPayCashPrizeConditions").val() == "" || $("#txtaPayCashPrizeConditions").val() == null){
                        alert("请填写合同约定现金奖支付条件");
                        $("#txtaPayCashPrizeConditions").focus();
                        return false;
                    }

                    if ($("#hidCashPrizePayType").val() == "" || $("#hidCashPrizePayType").val() == null){
                        alert("请选择现金奖发放方式");
                        $("#rbtnCashPrizePayType1").focus();
                        return false;
                    }

                    if ($("#hidIsMyPay").val() == "" || $("#hidIsMyPay").val() == null){
                        alert("请选择现金奖是否需开具发票并由我司支付税费");
                        $("#rdbIsMyPay1").focus();
                        return false;
                    }

                    if ($("#hidIsAreaConfirm").val() == "" || $("#hidIsAreaConfirm").val() == null){
                        alert("请选择区域是否已提交发展商奖金确认书");
                        $("#rdbAreaConfirm1").focus();
                        return false;
                    }
                    else {
                        var IsAreaConfirm = $("#hidIsAreaConfirm").val();

                        if (IsAreaConfirm == "2") {
                            if ($("#txtReturnBackDate").val() == "" || $("#txtReturnBackDate").val() == null){
                                alert("请填写区域承若交回发展商奖金确认书日期");
                                $("#txtReturnBackDate").focus();
                                return false;
                            }
                        }
                    }
                }


            }
            
            if ($("#hidPanFangTuoDiCompany").val() == "" || $("#hidPanFangTuoDiCompany").val() == null){
                alert("请选择盘方陀地公司");
                $("#ckbZY").focus();
                return false;
            }

            if ($("#txtPanFangRate").val() == "" || $("#txtPanFangRate").val() == null){
                alert("请填写盘方陀地公司拆分比例");
                $("#txtPanFangRate").focus();
                return false;
            }

            if ($("#txtNewHouseRate").val() == "" || $("#txtNewHouseRate").val() == null){
                alert("请填写新房中心拆分比例");
                $("#txtNewHouseRate").focus();
                return false;
            }

            if ($("#hidIsDeveloperAndZYHaveContract").val() == "" || $("#hidIsDeveloperAndZYHaveContract").val() == null){
                alert("请选择广州中原是否直接与发展商签代理合同/联动协议");
                $("#rdbHaveContrac").focus();
                return false;
            }

            if ($("#hidMajorIssues").val() == "" || $("#hidMajorIssues").val() == null){
                alert("请勾选重大问题的合同条款");
                $("#ckbNoCashback").focus();
                return false;
            }
            else {
                var mi = $("#hidMajorIssues").val();
                if (mi.indexOf("3")>0 && ($("#txtLimitArea").val() == ""|| $("#txtLimitArea").val() == null)) {
                    alert("若勾选接盘区域限制（排他条款），请填写接盘区域限制（排他条款");
                    $("#txtLimitArea").focus();
                    return false;
                }
            }

            if ($("#hidLack").val() == "" || $("#hidLack").val() == null){
                alert("请勾选已上传资料");
                $("#cbLack1").focus();
                return false;
            }
            else {
                var lack = $("#cbLack6").prop("checked");
                if (lack == true) {
                    alert("若勾选其他资料，请填写其他资料（排他条款");
                    $("#txtLack6").focus();
                    return false;
                }
            }

            var data = "";
            var flag = true;
            $("#tbDealOfficeType tbody tr").each(function (i) {
                var n = i + 1;
                data += $.trim($("#sbDealOfficeType" + n).val()) + "&&" + $.trim($("#sbDiskSource" + n).val()) + "&&" + $.trim($("#txtTotalSize" + n).val()) + "&&" + $.trim($("#txtTotalUnitCount" + n).val()) + "&&" + $.trim($("#txtUnitPrice" + n).val()) + "&&" + $.trim($("#txtSizeSegments" + n).val()) + "&&" + $.trim($("#txtPreCompleteCount" + n).val()) +"&&" + $.trim($("#txtPreComm" + n).val()) + "||";
            });
            if (flag) {
                data = data.substr(0, data.length - 2);
                $("#hidDealOfficeTypeContent").val(data);
            }

            data = "";

            $("#tbAgentCompanyInfo tbody tr").each(function (i) {
                var n = i + 1;
                data += $.trim($("#txtAgentCompanyName" + n).val()) + "&&" + $.trim($("#sbAgentCompanyType" + n).val()) + "&&" + $.trim($("#txtAgentFeeAndCashPrizeSituation" + n).val()) + "||";
            });
            if (flag) {
                data = data.substr(0, data.length - 2);
                $("#hidAgentCompanyInfoContent").val(data);
            }

            data = "";

            $("#dvCommFeeTypeInfo div").each(function (i) {
                //debugger;
                var n = i + 1;
                var ocj = "";
                $("input[name=OwnerCommJump"+n+"]").each(function(j) {
                    var eachRbtn = $("input[name=OwnerCommJump"+n+"]"[j]);
                    if (eachRbtn.prop("checked")) {
                        ocj += eachRbtn.val()+"|";
                    }
                })
                data += $.trim($("#sbCommFeeType" + n).val()) + "&&" + $.trim($("#txtContractingCompanyName" + n).val()) + "&&"+ocj+"&&" + $.trim($("#txtaAgentConditions" + n).val()) + "&&" + $.trim($("txtaCommConditions" + n).val()) + "||";
            });
            if (flag) {
                data = data.substr(0, data.length - 2);
                $("#hidCommFeeTypeInfoContent").val(data);
            }

            data = "";

            $("#tbNotSameCashPrize tbody tr").each(function (i) {
                //debugger;
                //var n = i + 1;
                //var ocj = "";
                //$("input[name=OwnerCommJump"+n+"]").each(function(j) {
                //    var eachRbtn = $("input[name=OwnerCommJump"+n+"]"[j]);
                //    if (eachRbtn.prop("checked")) {
                //        ocj += eachRbtn.val()+"|";
                //    }
                //})
                data += $.trim($("select[name='sbDealOfficeTypeForCashPrize']").val()) + "&&" + $.trim($("input[name='txtDealDateBegin']").val()) + "&&" + $.trim($("input[name='txtDealDateBegin']").val()) + "&&" + $.trim($("input[name='txtDealDateEnd']").val())+ "&&" + $.trim($("input[name='txtDealSetMin']").val())+ "&&" + $.trim($("input[name='txtDealSetMax']").val())+ $.trim($("input[name='txtDealSizeMin']").val())+ "&&" + $.trim($("input[name='txtDealSizeMax']").val())+ $.trim($("input[name='txtDealPrizeMin']").val())+ "&&" + $.trim($("input[name='txtDealPrizeMax']").val()) + "||";
            });
            if (flag) {
                data = data.substr(0, data.length - 2);
                $("#hidCommFeeTypeInfoContent").val(data);
            }
        };

        //StructureTable = function (col, cashPrizeType) {
        StructureTable = function () {
            var col = $("#hidCashPrizeChoiceConditions").val() ;
            var cashPrizeType = $("#hidCashPrizeType").val() ;

            var table = "<table id=\"tbNotSameCashPrize\" border=\"1\" style=\"width: 100%;\">";
            table += " <thead> <tr> <td id=\"tdMoneyPrize\">现金奖</td>";
            //col = "1|2|4";
            var colArr = col.split("|");

            for (var i = 0; i < colArr.length; i++) {

                if (colArr[i] == "1") {
                    table += " <td id=\"tdDealOfficeType\">物业类型</td> ";
                }

                if (colArr[i] == "2") {
                    table += " <td id=\"tdDealDate\">成交日期</td> ";
                }

                if (colArr[i] == "3") {
                    table += " <td id=\"tdDealSet\">成交套数</td> ";
                }

                if (colArr[i] == "4") {
                    table += " <td id=\"tdDealSize\">成交面积</td> ";
                }

                if (colArr[i] == "5") {
                    table += " <td id=\"tdDealPrice\">成交价</td> ";
                }

            }

            table += "  </tr> </thead>";
            table += " <tbody> <tr> <td><input name=\"txtMoneyPrize\" type=\"text\" style=\"width: 50px;\" ctype=\"num\" /> ";
            if (cashPrizeType == "1") {
                table += " <label  for=\"txtMoneyPrize1\">（单位：元/套）</label> ";
            }
            else {
                table += " <label  for=\"txtMoneyPrize1\">（单位：%/套）</label> ";
            }
            table += " </td> ";

            for (var i = 0; i < colArr.length; i++) {
                if (colArr[i] == "1") {
                    table += " <td><select name=\"sbDealOfficeTypeForCashPrize\" style=\"width: 75px; border: 1px solid #98b8b5\"> <option value=\"-1\">请选择</option> <option value=\"3\">住宅</option> <option value=\"4\">公寓</option> <option value=\"5\">写字楼</option> <option value=\"6\">商铺</option> <option value=\"7\">车位</option> <option value=\"8\">别墅</option> <option value=\"9\">其他</option> </select></td> ";
                }

                if (colArr[i] == "2") {
                    table += " <td><input name=\"txtDealDateBegin\" type=\"text\" style=\"width: 68px; margin-right: 3px;\" ctype=\"datetime\" />≤成交日期＜<input name=\"txtDealDateEnd\" type=\"text\" style=\"width: 68px; margin-left: 3px;\" ctype=\"datetime\" /></td> ";
                }

                if (colArr[i] == "3") {
                    table += " <td><input name=\"txtDealSetMin\" type=\"text\" style=\"width: 30px; margin-right: 3px;\" ctype=\"num\" />≤成交套数＜<input name=\"txtDealSetMax\" type=\"text\" style=\"width: 30px; margin-left: 3px;\" ctype=\"num\" /></td> ";
                }

                if (colArr[i] == "4") {
                    table += " <td><input name=\"txtDealSizeMin\" type=\"text\" style=\"width: 30px; margin-right: 3px;\" ctype=\"num\" />≤成交面积＜<input name=\"txtDealSizeMax\" type=\"text\" style=\"width: 30px; margin-left: 3px;\" ctype=\"num\" /></td> ";
                }

                if (colArr[i] == "5") {
                    table += " <td><input name=\"txtDealPrizeMin\" type=\"text\" style=\"width: 45px; margin-right: 3px;\" ctype=\"num\" />≤成交价＜<input name=\"txtDealPrizeMax\" type=\"text\" style=\"width: 45px; margin-left: 3px;\" ctype=\"num\" /></td> ";
                }
            }

            table += " </tr> </tbody> ";
            table += " </table> ";

            //var div = $("#dvTest").html();
            //if (div != "") {
            //    $("#dvTest").html("");
            //}
            //$("#dvTest").html(table);

            var div = $("#dvCashPrizeColumn").html();
            if (div != "") {
                $("#dvCashPrizeColumn").html("");
            }
            $("#dvCashPrizeColumn").html(table);

            $("input[ctype='datetime']").datepicker();

            $("input[ctype='num']").blur(function () {
                var val = $(this).val();

                if (!numberReg.test(val)) {
                    $(this).val("");
                }
            });
        }
        var i4 = 1;
        //按列生成现金奖 增加一行
        addRow4 = function () {
            //debugger;
            i4++;
            var html = $("#tbNotSameCashPrize tbody tr:eq(0)").html();
            var newRow = "<tr>"+html+"</tr>";
            $("#tbNotSameCashPrize tbody").append(newRow);
        };
        //按列生成现金奖 删除一行
        deleteRow4 = function () {
            if (i4 > 1) {
                i4--;
                $("#tbNotSameCashPrize tbody tr:eq(" + i4 + ")").remove();
                //AutoAdd();
            }
            else alert("不可再删除。");
        };

    </script>
    <style type="text/css">
        .auto-style1 {
            width: 204px;
        }

        .auto-style2 {
            height: 73px;
        }

        .finSignBtn {
            background: url(../../../images/btnSureS1.png) no-repeat;
            text-indent: 39px;
            width: 43px;
            height: 25px;
            overflow: hidden;
            cursor: pointer;
        }

        .titleCss {
            text-align: left;
            padding-left: 5px;
        }

        .rbtLabelCss {
            margin-right: 5px;
            vertical-align: middle;
        }

        #tbAround input[type="text"] {
            border: none;
            border-bottom: 1px solid black;
        }

        #tbDealOfficeType input[type="text"] {
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input id="hidSbFlow" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidDepartment" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidAreaFollowerDept" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidIsPreSale" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidIsOneOrTwo" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidDealOfficeTypeCount" type="hidden" runat="server" clientidmode="Static" value="1" />
    <input id="hidDealOfficeTypeContent" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidAgentCompanyInfoCount" type="hidden" runat="server" clientidmode="Static" value="2" />
    <input id="hidAgentCompanyInfoContent" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidCommFeeTypeInfoCount" type="hidden" runat="server" clientidmode="Static" value="1" />
    <input id="hidCommFeeTypeInfoContent" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidBaseAgent" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidCustomerExtraThings" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidIsHaveCashPrize" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidCashPrizePayType" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidIsMyPay" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidIsAreaConfirm" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidPanFangTuoDiCompany" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidIsDeveloperAndZYHaveContract" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidMajorIssues" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidLack" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidProjectID" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidCashPrizeType" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidCashPrizeConditions" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidCashPrizeChoiceConditions" type="hidden" runat="server" clientidmode="Static" />
    <input id="hidCashPrizeContent" type="hidden" runat="server" clientidmode="Static" />


    <div style="text-align: center; width: 960px; margin: 0 auto;">
        <div class="noprint">
            <%--<%=SbFlow.ToString()%>--%>
            <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <!--打印正文开始-->
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>联动统筹项目报备申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 720px; margin: 0 auto; overflow: hidden; text-align: center;">
                <span>申请人：<label id="lblApply" runat="server" style="width: 70px;"></label></span>
                <span style="float: right;" class="file_number">文档编码(自动生成)：<%--<%=SerialNumber%>--%></span>
            </div>
            <table id="tbAround" width="840px">
                <tr id="tbPartOne">
                    <td colspan="4">
                        <div class="titleCss">
                            <h3>一、项目统筹部门及统筹人</h3>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">项目统筹人</td>
                    <td colspan="3">
                        <div style="width: 100%; text-align: left;">
                            <label style="margin-left: 10px;">工号：</label>
                            <input id="txtCoordinatorCode" name="txtCoordinatorCode" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                            <label style="margin-left: 10px;">姓名：</label>
                            <input id="txtCoordinatorName" name="txtCoordinatorName" type="text" runat="server" style="width: 100px;" readonly="readonly" clientidmode="Static" />
                            <label style="margin-left: 10px;">联系电话：</label>
                            <input id="txtCoordinatorPhone" name="txtCoordinatorPhone" type="text" runat="server" style="width: 100px;" readonly="readonly" clientidmode="Static" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>项目驻场</td>
                    <td colspan="3">
                        <div style="width: 100%; text-align: left;">
                            <label style="margin-left: 10px;">工号：</label>
                            <input id="txtAreaCheckDataerCode" name="txtAreaCheckDataerCode" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                            <label style="margin-left: 10px;">姓名：</label>
                            <input id="txtAreaCheckDataer" name="txtAreaCheckDataer" type="text" runat="server" style="width: 100px;" readonly="readonly" clientidmode="Static" />
                            <label style="margin-left: 10px;">联系电话：</label>
                            <input id="txtAreaCheckDataerPhone" name="txtAreaCheckDataerPhone" type="text" runat="server" style="width: 100px;" readonly="readonly" clientidmode="Static" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="width: 100%; text-align: left;">
                            <label style="margin-left: 10px;">项目统筹区（项目统筹人归属部门）：</label>
                            <input id="txtCoordinatorDept" name="txtAreaFollowerDept" type="text" runat="server" style="width: 250px;" readonly="readonly" clientidmode="Static" />
                            <label style="margin-left: 10px;">申请日期：</label>
                            <label id="lblApplyDate" runat="server" style="width: 70px;"></label>
                        </div>
                    </td>
                </tr>
                <tr id="tbPartTwo">
                    <td colspan="4">
                        <div class="titleCss">
                            <h3>二、项目承接信息</h3>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">项目名称</td>
                    <td colspan="3" align="left">
                        <input id="txtProject" name="txtProject" type="text" style="width: 90%; margin-left: 10px;" runat="server" clientidmode="Static" />
                    </td>
                    <%--以下内容是续约申请才有--%>
                    <%--<td>项目名称</td>
					            <td class="tl PL10" colspan="3">
                                    <input id="Text1" name="txtProject" type="text" runat="server" style="width:98%;" />
					            </td>--%>
                </tr>
                <tr>
                    <td>是否已有预售证</td>
                    <td align="left">
                        <input id="rbtIsPreSale1" type="radio" name="IsPreSale" value="1" style="vertical-align: middle; margin-left: 10px;" clientidmode="Static" />
                        <label for="rbtIsPreSale1" style="margin-right: 5px; vertical-align: middle;">是</label>
                        <input id="rbtIsPreSale2" type="radio" name="IsPreSale" value="2" style="vertical-align: middle;" clientidmode="Static" />
                        <label for="rbtIsPreSale2" style="vertical-align: middle;">否</label>
                    </td>
                    <td>项目性质</td>
                    <td align="left">
                        <input id="rbtIsOneOrTwo1" type="radio" name="IsOneOrTwo" value="1" style="vertical-align: middle; margin-left: 10px;" clientidmode="Static" />
                        <label for="rbtIsOneOrTwo1" style="margin-right: 5px; vertical-align: middle;">一手项目</label>
                        <input id="rbtIsOneOrTwo2" type="radio" name="IsOneOrTwo" value="2" style="vertical-align: middle;" clientidmode="Static" />
                        <label for="rbtIsOneOrTwo2" style="vertical-align: middle;">二手批量</label>
                    </td>
                </tr>
                <tr>
                    <td>预售证发展商<br />
                        （小业主）：</td>
                    <td align="left">
                        <input id="txtDeveloper" name="txtDeveloper" type="text" runat="server" style="width: 100px; margin-left: 10px;" clientidmode="Static" />
                    </td>
                    <td>代理类型：</td>
                    <td align="left">
                        <select id="sbDealType" runat="server" style="width: 100px; border: 1px solid #98b8b5; margin-left: 10px;" clientidmode="Static">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>发展商联系人：</td>
                    <td colspan="3" align="left">
                        <div style="width: 100%; text-align: left;">
                            <label style="margin-left: 10px;">姓名：</label>
                            <input id="txtDeveloperContacter" name="txtDeveloperContacter" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                            <label style="margin-left: 10px;">职位：</label>
                            <input id="txtDeveloperContacterPosition" name="txtDeveloperContacterPosition" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                            <label style="margin-left: 10px;">联系电话：</label>
                            <input id="txtDeveloperContacterPhone" name="txtDeveloperContacterPhone" type="text" runat="server" style="width: 100px;" clientidmode="Static" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>项目所在地：</td>
                    <td colspan="3" align="left">
                        <div style="width: 100%; text-align: left; margin-left: 10px;">
                            <select id="sbProjectLocation" runat="server" clientidmode="Static" style="width: 150px; border: 1px solid #98b8b5;">
                            </select>
                            <span style="color: red">（项目所在地：按公司划分的地盘标准选择）</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>项目地址：</td>
                    <td colspan="3" align="left">
                        <input id="txtProjectAddress" name="txtProjectAddress" type="text" runat="server" clientidmode="Static" style="width: 90%; margin-left: 10px;" />
                    </td>
                </tr>
                <tr>
                    <td>物业类型</td>
                    <td colspan="3">
                        <div style="overflow: hidden; margin-bottom: 5px; padding-left: 5px;">
                            <input type="button" id="btnAddRow1" value="添加新行" onclick="addRow1();" style="float: left; display: block;" />
                            <input type="button" id="btnDeleteRow1" value="删除一行" onclick="deleteRow1();" style="float: left; display: block;" />
                        </div>
                        <table id="tbDealOfficeType" border="0" style="width: 100%; margin-top: 2px;">
                            <thead>
                                <tr>
                                    <td rowspan="2">物业类型<br />
                                        （必选）</td>
                                    <td rowspan="2">AB盘类型<br />
                                        （必选）</td>
                                    <td colspan="4">承接货量</td>
                                    <td colspan="2">预估目标</td>
                                </tr>
                                <tr>
                                    <td>面积总计</td>
                                    <td>套数总计</td>
                                    <td>单价</td>
                                    <td>面积段</td>
                                    <td>完成套数</td>
                                    <td>佣金收入</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr id="trDealOfficeType1">
                                    <td>
                                        <select id="sbDealOfficeType1" style="width: 80px; border: 1px solid #98b8b5">
                                            <option value="-1">请选择</option>
                                            <option value="3">住宅</option>
                                            <option value="4">公寓</option>
                                            <option value="5">写字楼</option>
                                            <option value="6">商铺</option>
                                            <option value="7">车位</option>
                                            <option value="8">别墅</option>
                                            <option value="9">其他</option>
                                        </select>
                                    </td>
                                    <td>
                                        <select id="sbDiskSource1" style="width: 80px; border: 1px solid #98b8b5">
                                            <option value="-1">请选择</option>
                                            <option value="1">市内A盘</option>
                                            <option value="2">市外B盘</option>
                                        </select>
                                    </td>
                                    <td>
                                        <input id="txtTotalSize1" name="txtSquare1" type="text" /></td>
                                    <td>
                                        <input id="txtTotalUnitCount1" name="txtTotalUnitCount1" type="text" /></td>
                                    <td>
                                        <input id="txtUnitPrice1" name="txtUnitPrice1" type="text" /></td>
                                    <td>
                                        <input id="txtSizeSegments1" name="txtTotalPrice1" type="text" /></td>
                                    <td>
                                        <input id="txtPreCompleteCount1" name="txtPreCompleteCount1" type="text" /></td>
                                    <td>
                                        <input id="txtPreComm1" name="txtPreComm1" type="text" /></td>
                                </tr>
                            </tbody>
                        </table>
                        <p style="text-align: left; width: 100%; padding-left: 2px;">
                            AB盘定义：<br />
                            A盘：<br />
                            A盘区域：广州中心区（越秀、荔湾、天河、海珠、白云、花都、番禺、黄埔、罗岗）<br />
                            物业性质：除商铺、公寓外的其他所有物业性质<br />
                            B盘：<br />
                            B盘区域：广州非中心区（增城、从化、南沙）+外市（佛山、江门、清远、中山、肇庆、惠州等）<br />
                            物业性质：包含所有物业性质，其中商铺、公寓不受区域限制<br />
                            若在以上定义之外的。A、B盘必须由联动中心决定，否则无法报数。
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div class="titleCss">
                            <h3>三、项目现场信息</h3>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>场内代理</td>
                    <td colspan="3" align="left">
                        <input id="cbBaseAgent1" name="BaseAgent" type="checkbox" value="1" runat="server" clientidmode="Static" style="vertical-align: middle; margin-left: 10px;" />
                        <label for="cbBaseAgent1" class="rbtLabelCss">中原项目部</label>
                        <input id="cbBaseAgent2" name="BaseAgent" type="checkbox" value="2" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                        <label for="cbBaseAgent2" class="rbtLabelCss">合富辉煌</label>
                        <input id="cbBaseAgent3" name="BaseAgent" type="checkbox" value="3" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                        <label for="cbBaseAgent3" class="rbtLabelCss">世联</label>
                        <input id="cbBaseAgent4" name="BaseAgent" type="checkbox" value="4" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                        <label for="cbBaseAgent4" class="rbtLabelCss">其它</label>
                        <input id="txtBaseAgentOther" name="txtDeveloper" type="text" runat="server" clientidmode="Static" style="width: 270px; border: none; border-bottom: 1px solid black;" />
                    </td>
                </tr>
                <tr>
                    <td>行家信息</td>
                    <td colspan="3" style="border-bottom: 1px solid">
                        <div style="overflow: hidden; margin-bottom: 5px; padding-left: 5px;">
                            <input type="button" id="btnAddRow2" value="添加新行" onclick="addRow2();" style="float: left; display: block;" />
                            <input type="button" id="btnDeleteRow2" value="删除一行" onclick="deleteRow2();" style="float: left; display: block;" />
                        </div>
                        <table id="tbAgentCompanyInfo" border="0" style="width: 100%;">
                            <thead>
                                <tr>
                                    <td style="border-left: none;">名称</td>
                                    <td>该公司类型</td>
                                    <td>代理费及现金奖情况</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr id="trAgentCompanyInfo1">
                                    <td style="border-left: none;">
                                        <input id="txtAgentCompanyName1" name="txtAgentCompanyName1" type="text" />
                                    </td>
                                    <td>
                                        <select id="sbAgentCompanyType1" name="sbAgentCompanyType1" style="width: 80px; border: 1px solid #98b8b5">
                                            <option value="-1">请选择</option>
                                            <option value="1">电商</option>
                                            <option value="2">代理商</option>
                                            <option value="3">中介</option>
                                        </select>
                                    </td>
                                    <td>
                                        <input id="txtAgentFeeAndCashPrizeSituation1" name="txtAgentFeeAndCashPrizeSituation1" type="text" style="width: 90%; margin-left: 10px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-left: none;">
                                        <input id="txtAgentCompanyName2" name="txtAgentCompanyName2" type="text" />
                                    </td>
                                    <td>
                                        <select id="sbAgentCompanyType2" name="sbAgentCompanyType2" style="width: 80px; border: 1px solid #98b8b5">
                                            <option value="-1">请选择</option>
                                            <option value="1">电商</option>
                                            <option value="2">代理商</option>
                                            <option value="3">中介</option>
                                        </select>
                                    </td>
                                    <td>
                                        <input id="txtAgentFeeAndCashPrizeSituation2" name="txtAgentFeeAndCashPrizeSituation2" type="text" style="width: 90%; margin-left: 10px;" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <p style="text-align: left; width: 100%; padding-left: 2px;">
                            若项目与渠道同场联合代理或轮流代理，以下为必填项，若因为无渠道相关信息则视为独家代理。<br />
                            （最少填写两家，公司类型包括：电商、代理商、中介）
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>客户需支付的额外费用<br />
                        （电商优惠、改造费等楼款之外的费用）</td>
                    <td colspan="3" align="left" style="padding-left: 10px;">
                        <div style="width: 100%;">
                            <input id="rbtnIsSwipeCard" type="radio" name="CustomerExtraThings" value="1" style="vertical-align: middle;" clientidmode="Static" />
                            <label for="rbtnIsSwipeCard" style="vertical-align: middle;">刷卡</label>
                            <input id="txtPrePayMoney" name="txtPrePayMoney" type="text" runat="server" clientidmode="Static" style="width: 50px; border: none; border-bottom: 1px solid black; margin-left: 5px; margin-right: 5px;" />
                            <label style="vertical-align: middle;">元抵楼价</label>
                            <input id="txtDiscountMoney" name="txtDiscountMoney" type="text" runat="server" clientidmode="Static" style="width: 50px; border: none; border-bottom: 1px solid black; margin-left: 5px; margin-right: 5px;" />
                            <label style="vertical-align: middle;">元</label>
                        </div>
                        <div style="width: 100%;">
                            <input id="rbtnIsRenovation" type="radio" name="CustomerExtraThings" value="2" style="vertical-align: middle;" />
                            <label for="rbtnIsRenovation" style="vertical-align: middle;">改造费</label>
                            <input id="txtRenovationFee" name="txtRenovationFee" type="text" runat="server" clientidmode="Static" style="width: 50px; border: none; border-bottom: 1px solid black; margin-left: 5px; margin-right: 5px;" />
                            <label style="vertical-align: middle;">元</label>
                        </div>
                        <div style="width: 100%;">
                            <input id="rbtnOther" type="radio" name="CustomerExtraThings" value="3" style="vertical-align: middle;" />
                            <label for="rbtnOther" style="vertical-align: middle;">其他</label>
                            <input id="txtOtherFeeType" name="txtOtherFeeType" type="text" runat="server" clientidmode="Static" style="width: 80px; border: none; border-bottom: 1px solid black; margin-left: 5px; margin-right: 5px;" />
                            <label style="vertical-align: middle;">，</label>
                            <input id="txtOtherFee" name="txtOtherFee" type="text" runat="server" clientidmode="Static" style="width: 50px; border: none; border-bottom: 1px solid black; margin-left: 5px; margin-right: 5px;" />
                            <label style="vertical-align: middle;">元</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div class="titleCss">
                            <h3>四、代理条件</h3>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>代理期</td>
                    <td>
                        <input id="txtAgentStartDate" name="txtAgentStartDate" type="text" runat="server" clientidmode="Static" style="width: 80px;" />~<input id="txtAgentEndDate" name="txtAgentEndDate" type="text" runat="server" clientidmode="Static" style="width: 80px;" />
                    </td>
                    <td>客户保护期（非必填项）</td>
                    <td>
                        <input id="txtClientGuardStartDate" name="txtClientGuardStartDate" type="text" runat="server" clientidmode="Static" style="width: 80px;" />~<input id="txtClientGuardEndDate" name="txtClientGuardEndDate" type="text" runat="server" clientidmode="Static" style="width: 80px;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div id="dvCommFeeType">
                            <div style="overflow: hidden; margin-bottom: 5px; padding-left: 5px;">
                                <label style="float: left; margin-left: 5px; margin-top: 2px;" class="rbtLabelCss">代理费类型</label>
                                <input type="button" id="btnAddRow3" value="添加新行" onclick="addRow3();" style="float: left; display: block;" />
                                <input type="button" id="btnDeleteRow3" value="删除一行" onclick="deleteRow3();" style="float: left; display: block;" />
                            </div>
                            <div id="dvCommFeeTypeInfo" style="padding-left: 5px; text-align: left;">
                                <div id="dvCommFeeTypeInfo1" style="margin-top: 10px; text-align: left;">
                                    <select id="sbCommFeeType1" name="sbCommFeeType1" style="width: 80%; border: 1px solid #98b8b5;">
                                        <option value="-1">请选择</option>
                                        <option value="1">电商佣</option>
                                        <option value="2">发展商佣</option>
                                        <option value="3">代理商佣</option>
                                        <option value="4">个人佣</option>
                                    </select>
                                    <br />
                                    <br />
                                    1）签约公司名称：
                                    <input id="txtContractingCompanyName1" name="txtContractingCompanyName1" type="text" style="width: 150px; margin-left: 10px;" />
                                    <br />
                                    <br />
                                    2）佣金跳BAR方式：
                                    <input id="rdbOwnerCommJump1" type="radio" name="OwnerCommJump" value="1" style="vertical-align: middle;" />
                                    <label for="rdbOwnerCommJump1" class="rbtLabelCss">全跳BAR</label>
                                    <input id="rdbOwnerCommJump2" type="radio" name="OwnerCommJump" value="2" style="vertical-align: middle;" />
                                    <label for="rdbOwnerCommJump2" class="rbtLabelCss">分级跳BAR</label>
                                    <input id="rdbOwnerCommJump3" type="radio" name="OwnerCommJump" value="3" style="vertical-align: middle;" />
                                    <label for="rdbOwnerCommJump3" class="rbtLabelCss">无跳BAR</label>
                                    <br />
                                    <br />
                                    3）代理条件<br />
                                    <textarea id="txtaAgentConditions1" cols="20" rows="2" style="width: 95%; height: 45px;"></textarea>
                                    <br />
                                    <br />
                                    4）合同约定结佣条件<br />
                                    <textarea id="txtaCommConditions1" cols="20" rows="2" style="width: 95%; height: 45px;"></textarea>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div id="dvCashPrize" style="padding-left: 5px; text-align: left;">
                            <label style="vertical-align: middle;">现金奖</label>
                            <input id="rbtnHaveCash" type="radio" name="IsHaveCashPrize" value="1" style="vertical-align: middle;" />
                            <label for="rbtnHaveCash" class="rbtLabelCss">有</label>
                            <input id="rbtnNotHaveCash" type="radio" name="IsHaveCashPrize" value="2" style="vertical-align: middle;" />
                            <label for="rbtnNotHaveCash" class="rbtLabelCss">无</label>
                            <div id="dvCashPrizeDetail">
                                <p style="text-align: left; width: 100%; padding-left: 2px;">
                                    现金奖发放说明：<br />
                                    第一：公司净佣金比例≥2%的一手项目才具备申请发展商哪行额外现金奖的资格；若净佣金比例<2%，现金奖全数上交公司，可计入员工业绩，并计算员工佣金；
                                    <br />
                                    第二：单套现金奖的可发放金额=每套净佣金*15%（以开发商奖金为上限）；若单套现金奖超过单套净佣金的15%，则按公司每套净佣金的15%计发现金奖，剩余部分上缴公司，按正常计算业绩，但并不计发佣金；
                                    <br />
                                    第三：发展商额外现金奖的可发放金额分配比例调整为：分配比例为经纪人44%、店董15%、小战区合伙人8%、大战区合伙人3%，公司留存30%，公司留存部分按正常计算业绩，但并不计发佣金。
                                    <br />
                                </p>
                                <br />
                                1）签约公司名称：
                                <input id="txtCorporateName" name="txtCorporateName" type="text" runat="server" clientidmode="Static" style="width: 100px; margin-left: 2px;" />
                                该公司类型：
                                <select id="sbCorporateType" runat="server" clientidmode="Static" style="width: 80px; border: 1px solid #98b8b5">
                                    <option value="-1">请选择</option>
                                </select>
                                <br />
                                <br />
                                2）现金奖：
                                <%--<input id="txtCashPrize" name="txtCashPrize" type="text" runat="server" clientidmode="Static" style="width: 100px; margin-left: 2px;" />
                                <label class="rbtLabelCss">元/套</label>
                                <br />--%>
                                <div style="width: 100%;">
                                    <label style="vertical-align: middle;">请选择现金奖计算方式：</label>
                                    <input id="rbtnMoneyPerSet" type="radio" name="CashPrizeType" value="1" style="vertical-align: middle;" />
                                    <label for="rbtnMoneyPerSet" style="vertical-align: middle;">固定金额</label>
                                    <input id="rbtnPercentPerSet" type="radio" name="CashPrizeType" value="2" style="vertical-align: middle;" />
                                    <label for="rbtnPercentPerSet" style="vertical-align: middle;">成交价百分比</label>
                                    <input id="rbtnOtherPrizePerSet" type="radio" name="CashPrizeType" value="3" style="vertical-align: middle;" />
                                    <label for="rbtnOtherPrizePerSet" style="vertical-align: middle;">实物奖励（填写实物内容及预估价值，收回后需上现金奖调整申请说明折现情况）</label>
                                </div>
                                <div id="dvCashPrizeConditions" style="width: 100%;">
                                    <input id="rbtnSameCashPrize" type="radio" name="CashPrizeConditions" value="1" style="vertical-align: middle;" />
                                    <label for="rbtnSameCashPrize" style="vertical-align: middle;">代理期内现金奖相同</label>
                                    <input id="rbtnNotSameCashPrize" type="radio" name="CashPrizeConditions" value="2" style="vertical-align: middle;" />
                                    <label for="rbtnNotSameCashPrize" style="vertical-align: middle;">按条件划分现金奖</label>
                                    <input id="rbtnOtherCashPrize" type="radio" name="CashPrizeConditions" value="3" style="vertical-align: middle;" />
                                    <label for="rbtnOtherCashPrize" style="vertical-align: middle;">其余情况（请使用现金奖新增调整模板进行申请）</label>
                                </div>
                                <%-- 代理期内现金奖相同 start --%>
                                <div id="dvSameCashPrize" style="width: 100%;">
                                    <input id="txtMoneyPerSet" name="txtMoneyPerSet" type="text" runat="server" clientidmode="Static" style="width: 50px; border: none; border-bottom: 1px solid black; margin-left: 5px; margin-right: 5px;" />
                                    <label id="lblMoneyPerSet" style="vertical-align: middle;">元/套</label>
                                    <label id="lblPercentPerSet" style="vertical-align: middle;">%/套</label>
                                </div>
                                <%-- 代理期内现金奖相同 end --%>
                                <%-- 按条件划分现金奖 start --%>
                                <div id="dvNotSameCashPrize" style="width: 100%;">
                                    <div style="overflow: hidden; margin-bottom: 5px; padding-left: 5px;">
                                        <input id="ckbNSCPCDealDealOfficeType" name="NotSameCashPrizeColumn" type="checkbox" value="1" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                        <label for="ckbNSCPCDealDealOfficeType" style="vertical-align: middle;">物业类型</label>
                                        <input id="ckbNSCPCDealDateBeginEnd" name="NotSameCashPrizeColumn" type="checkbox" value="2" runat="server" clientidmode="Static" style="vertical-align: middle; margin-left: 10px;" />
                                        <label for="ckbNSCPCDealDateBeginEnd" style="vertical-align: middle;">成交日期</label>
                                        <input id="ckbNSCPCDealSaleSet" name="NotSameCashPrizeColumn" type="checkbox" value="3" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                        <label for="ckbNSCPCDealSaleSet" style="vertical-align: middle;">成交套数</label>
                                        <input id="ckbNSCPCDealSize" name="NotSameCashPrizeColumn" type="checkbox" value="4" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                        <label for="ckbNSCPCDealSize" style="vertical-align: middle;">成交面积</label>
                                        <input id="ckbNSCPCDealPrice" name="NotSameCashPrizeColumn" type="checkbox" value="5" runat="server" clientidmode="Static" style="vertical-align: middle;" />
                                        <label for="ckbNSCPCDealPrice" style="vertical-align: middle;">成交价</label>
                                    </div>
                                    <div style="overflow: hidden; margin-bottom: 5px; padding-left: 5px;">
                                        <input type="button" id="btnAddRow4" value="添加新行" onclick="addRow4();" style="float: left; display: block;" />
                                        <input type="button" id="btnDeleteRow4" value="删除一行" onclick="deleteRow4();" style="float: left; display: block;" />
                                    </div>
                                    <%--<div id="dvTest">--%>
                                    <div id="dvCashPrizeColumn">
                                    </div>
                                </div>
                                <%-- 按条件划分现金奖 end --%>
                                <%-- 其余情况 start --%>
                                <div id="dvOtherPrize" style="width: 100%;">
                                    <textarea id="txtaOtherPrizePerSet" cols="20" rows="3" style="width: 90%; height: 55px;" runat="server" clientidmode="Static"></textarea>
                                </div>
                                <%-- 其余情况 end --%>
                                <br />
                                3）合同约定现金奖支付条件<br />
                                <textarea id="txtaPayCashPrizeConditions" cols="20" rows="2" style="width: 90%; height: 35px;" runat="server" clientidmode="Static"></textarea>
                                <br />
                                <br />
                                4）现金奖发放方式：<br />
                                <input id="rbtnCashPrizePayType1" type="radio" name="CashPrizePayType" value="1" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                                <label for="rbtnCashPrizePayType1" class="rbtLabelCss">现金奖由发展商划入公司账户，随薪佣发放。</label>
                                <br />
                                <input id="rbtnCashPrizePayType2" type="radio" name="CashPrizePayType" value="2" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                                <label for="rbtnCashPrizePayType2" class="rbtLabelCss">现金奖由发展商直接支付现金，接收人必须是申请部门负责人。</label>
                                <br />
                                现金奖是否需开具发票并由我司支付税费？
                                <input id="rdbIsMyPay1" type="radio" name="IsMyPay" value="1" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                                <label for="rdbIsMyPay1" class="rbtLabelCss">是</label>
                                <input id="rdbIsMyPay2" type="radio" name="IsMyPay" value="2" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                                <label for="rdbIsMyPay2" class="rbtLabelCss">否</label>
                                <br />
                                <br />
                                区域是否已提交发展商奖金确认书？
                                <input id="rdbAreaConfirm1" type="radio" name="IsAreaConfirm" value="1" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                                <label for="rdbAreaConfirm1" class="rbtLabelCss">是</label>
                                <input id="rdbAreaConfirm2" type="radio" name="IsAreaConfirm" value="2" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                                <label class="rbtLabelCss">否</label>，区域承诺在
                                <input for="rdbAreaConfirm2" id="txtReturnBackDate" name="txtReturnBackDate" type="text" runat="server" style="width: 80px;" clientidmode="Static" />前交回公司
                                <br />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="padding-left: 5px; text-align: left;">
                            <label style="vertical-align: middle;">跨地盘拆分</label>
                            <br />
                            1）盘方陀地公司：<br />
                            <input id="ckbPFZY" name="Panfang" type="checkbox" value="1" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                            <label for="ckbPFZY" style="vertical-align: middle;">中原</label>
                            <input id="ckbPFFYQ" name="Panfang" type="checkbox" value="2" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                            <label for="ckbPFFYQ" style="vertical-align: middle;">房友圈</label>
                            <br />
                            拆分比例：<input id="txtPanFangRate" name="txtPanFangRate" type="text" runat="server" clientidmode="Static" style="width: 80px;" />%
                            <br />
                            2）新房中心<br />
                            拆分比例：<input id="txtNewHouseRate" name="txtNewHouseRate" type="text" runat="server" clientidmode="Static" style="width: 80px;" />%
                            <br />
                            3）广州中原是否直接与发展商签代理合同/联动协议：
                            <input id="rdbHaveContrac" type="radio" name="IsDeveloperAndZYHaveContract" value="1" style="vertical-align: middle;" />
                            <label for="rdbHaveContrac" class="rbtLabelCss">有</label>
                            <input id="rdbNotHaveContrac" type="radio" name="IsDeveloperAndZYHaveContract" value="2" style="vertical-align: middle;" />
                            <label for="rdbNotHaveContrac" class="rbtLabelCss">无（附上传资料清单）</label>
                            <br />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="padding-left: 5px; text-align: left;">
                            <label style="vertical-align: middle;">重大问题的合同条款（如违约赔偿条款、接盘区域限制等）</label>
                            <br />
                            <input id="ckbMINoCashback" name="MajorIssues" type="checkbox" value="1" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                            <label for="ckbMINoCashback" style="vertical-align: middle;">代理合同有禁止给客户让佣条款</label>
                            <br />
                            <input id="ckbMIProbity" name="MajorIssues" type="checkbox" value="2" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                            <label for="ckbMIProbity" style="vertical-align: middle;">附加廉洁条款违约责任</label>
                            <br />
                            <input id="ckbMIZoneRestrictions" name="MajorIssues" type="checkbox" value="3" style="vertical-align: middle;" runat="server" clientidmode="Static" />
                            <label for="ckbMIZoneRestrictions" style="vertical-align: middle;">接盘区域限制（排他条款）</label>
                            <textarea id="txtLimitArea" cols="20" rows="2" style="width: 90%; height: 35px;" runat="server" clientidmode="Static"></textarea>
                            <br />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div class="titleCss">
                            <h3>五、过往成交及欠佣</h3>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table width="100%">
                            <thead>
                                <tr>
                                    <td>文档编号</td>
                                    <td>代理期</td>
                                    <td>成交宗数</td>
                                    <td>成交额</td>
                                    <td>成交业绩</td>
                                    <td>欠佣</td>
                                    <td>项目承接区域负责人</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>UtContract201904231409125312</td>
                                    <td>2019-04-20～2019-06-30</td>
                                    <td>1</td>
                                    <td>189.71</td>
                                    <td>1.90</td>
                                    <td>0.00</td>
                                    <td>潘婉霞</td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td>累计总成交</td>
                                    <td>代理期</td>
                                    <td>成交宗数</td>
                                    <td>成交额</td>
                                    <td>成交业绩</td>
                                    <td>欠佣</td>
                                    <td>项目承接区域负责人</td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: center; vertical-align: middle;">应收账龄</td>
                                    <td colspan="4" class="tl PL10" style="text-align: left; vertical-align: middle; font-size: large;">物业部的应收总佣金<asp:Label ID="lbN1" runat="server" Text="8888"></asp:Label>元，项目部的应收总佣金<asp:Label ID="lbW1" runat="server" Text="0"></asp:Label>元<br />
                                        欠佣期（含成交月）3个月内的佣金：物业部<asp:Label ID="lbN2" runat="server" Text="888"></asp:Label>元，项目部<asp:Label ID="lbW2" runat="server" Text="0"></asp:Label>元。
                        截止日期：<asp:Label ID="lbEndDate1" runat="server" Text="2019-06-30"></asp:Label><br />
                                        已自动坏账的欠佣期一年以上的佣金：物业部<asp:Label ID="lbC1" runat="server" Text="888"></asp:Label>元，项目部<asp:Label ID="lbW3" runat="server" Text="0"></asp:Label>元。
                        截止日期：<asp:Label ID="lbEndDate2" runat="server" Text="2019-06-30"></asp:Label><br />
                                        物业部欠必要性文件坏账的应收总佣金<asp:Label ID="lbD1" runat="server" Text="0"></asp:Label>元，项目部欠必要性文件坏账的应收总佣金<asp:Label ID="lbD2" runat="server" Text="0"></asp:Label>元。
                        截止日期：<asp:Label ID="lbEndDate3" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                            </tfoot>
                        </table>

                    </td>
                </tr>
                <tr>
                    <th colspan="4" style="line-height: 25px;">审批流程</th>
                </tr>
                <tr class="noborder" style="height: 85px;" runat="server" id="trYesIDx1">
                    <td>申请人</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx1" type="radio" name="agree1" /><label for="rdbYesIDx1">同意</label><input id="rdbOtherIDx1" type="radio" name="agree1" /><label for="rdbOtherIDx1">其他意见</label>
                        <span id="sp001" style="display: none;">
                            <asp:LinkButton ID="lbFYQ" runat="server" OnClick="lbFYQ_Click" OnClientClick="return confirm('确定要添加黄蕙晶审批？')">添加黄蕙晶审批</asp:LinkButton>
                            <asp:LinkButton ID="lbCancelFYQ" runat="server" OnClick="lbCancelFYQ_Click" OnClientClick="return confirm('确定要取消黄蕙晶审批？')">取消黄蕙晶审批</asp:LinkButton>
                        </span>
                        <br />
                        <textarea id="txtIDx1" rows="3" cols="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx1" value="签名" onclick="sign('1')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx1">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td>物业部区域负责人意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx2" type="radio" name="agree2" /><label for="rdbYesIDx2">同意</label><input id="rdbOtherIDx2" type="radio" name="agree2" /><label for="rdbOtherIDx2">其他意见</label><br />
                        <textarea id="txtIDx2" rows="3" cols="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx2" value="签名" onclick="sign('2')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx2">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px; display: none;">
                    <td>二级市场负责人<br />
                        （项目部）<br />
                        或<br />
                        三级市场负责人<br />
                        （物业部）</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx3" type="radio" name="agree3" /><label for="rdbYesIDx3">同意</label><input id="rdbOtherIDx3" type="radio" name="agree3" /><label for="rdbOtherIDx3">其他意见</label><br />
                        <textarea id="txtIDx3" rows="3" cols="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx3" value="签名" onclick="sign('3')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx3">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px;">
                    <td>应收款管理组意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx8" type="radio" name="agree8" /><label for="rdbYesIDx8">同意</label>
                        <input id="rdbNoIDx8" type="radio" name="agree8" /><label for="rdbNoIDx8">不同意</label>
                        <input id="rdbOtherIDx8" type="radio" name="agree8" /><label for="rdbOtherIDx8">其他意见</label><br />
                        结佣条件：<br />
                        <div style="float: right">一次性付款：前佣<input id="txtOneFront" runat="server" type="text" style="width: 217px" clientidmode="Static" />后佣<input id="txtOneAfter" type="text" runat="server" style="width: 217px" clientidmode="Static" /></div>
                        <div style="float: right">按揭：前佣<input id="txtTurnFront" runat="server" type="text" style="width: 217px" clientidmode="Static" />后佣<input id="txtTurnAfter" type="text" runat="server" style="width: 217px" clientidmode="Static" /></div>
                        <br />
                        <asp:Button runat="server" CssClass="finSignBtn" ID="bFinSige" OnClick="btnComm_Click" Text="确认" OnClientClick="return checkAduit()" Visible="false" />
                        <textarea id="txtIDx8" rows="3" cols="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx8" value="签名" onclick="sign('8')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx8">_________</span>
                        </span>
                    </td>
                </tr>
                <tr class="noborder" style="height: 85px; display: none;" id="tr14">
                    <td>房友圈意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx14" type="radio" name="agree14" /><label for="rdbYesIDx14">同意</label>
                        <input id="rdbNoIDx14" type="radio" name="agree14" /><label for="rdbNoIDx14">不同意</label>
                        <input id="rdbOtherIDx14" type="radio" name="agree14" /><label for="rdbOtherIDx14">其他意见</label><br />
                        <textarea id="txtIDx14" rows="3" cols="3" style="width: 98%; overflow: auto;"></textarea><input type="button" id="btnSignIDx14" value="签名" onclick="sign('14')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx14">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow5" class="noborder" style="height: 85px;">
                    <td rowspan="2">法律部意见</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx15" type="radio" name="agree15" /><label for="rdbYesIDx15">同意</label>
                        <input id="rdbNoIDx15" type="radio" name="agree15" /><label for="rdbNoIDx15">不同意</label>
                        <input id="rdbOtherIDx15" type="radio" name="agree15" /><label for="rdbOtherIDx15">其他意见</label>
                        <span id="sp005" style="display: none;">
                            <asp:LinkButton ID="lbFYQ1" runat="server" OnClick="lbFYQ_Click" OnClientClick="return confirm('确定要添加黄蕙晶审批？')">添加黄蕙晶审批</asp:LinkButton>
                            <asp:LinkButton ID="lbCancelFYQ1" runat="server" OnClick="lbCancelFYQ_Click" OnClientClick="return confirm('确定要取消黄蕙晶审批？')">取消黄蕙晶审批</asp:LinkButton>
                            <%--<asp:LinkButton ID="lbOCDeptm" runat="server" OnClick="lbOCDeptm_Click">添加陈洁丽审批</asp:LinkButton>--%>
                        </span>
                        <br />
                        <textarea id="txtIDx15" rows="6" cols="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx15" value="签署意见" onclick="sign('15')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx15">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trShowFlow16" class="noborder" style="height: 85px;">
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx16" type="radio" name="agree16" /><label for="rdbYesIDx16">同意</label>
                        <input id="rdbNoIDx16" type="radio" name="agree16" /><label for="rdbNoIDx16">不同意</label>
                        <input id="rdbOtherIDx16" type="radio" name="agree16" /><label for="rdbOtherIDx16">其他意见</label><br />
                        <textarea id="txtIDx16" rows="6" cols="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx16" value="签署意见" onclick="sign('16')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx16">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trGeneralManager" class="noborder" style="height: 85px;">
                    <td>董事总经理<br />
                        审批</td>
                    <td colspan="3" class="tl PL10" style="">
                        <input id="rdbYesIDx17" type="radio" name="agree17" /><label for="rdbYesIDx17">同意</label>
                        <input id="rdbNoIDx17" type="radio" name="agree17" /><label for="rdbNoIDx17">不同意</label>
                        <input id="rdbOtherIDx17" type="radio" name="agree17" /><label for="rdbOtherIDx17">其他意见</label><br />
                        <textarea id="txtIDx17" rows="3" cols="3" style="width: 98%; overflow: auto;"></textarea>
                        <input type="button" id="btnSignIDx17" value="签署意见" onclick="sign('17')" style="display: none;" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx17">_________</span>
                        </span>
                    </td>
                </tr>


                <tr id="trAddAnoF1" class="noborder" style="height: 85px; display: none;">
                    <td>区域回复审批意见<br />
                        （可选项）</td>
                    <td colspan="3" class="tl PL10" style="">
                        <textarea id="txtIDx200" rows="6" cols="3" style="width: 98%; overflow: auto;" runat="server" clientidmode="Static"></textarea>
                        <asp:Button ID="btnsSignIDx200" runat="server" OnClick="btnSignIDx200_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx200">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF2" class="noborder" style="height: 85px; display: none;">
                    <td rowspan="2">法律部复审<br />
                        <asp:Button ID="btnShouldJumpIDx" runat="server" OnClick="btnShouldJump_Click" Visible="False" />
                    </td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb210a1" runat="server" Text="同意" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a2" runat="server" Text="不同意" GroupName="210a" />
                        <asp:RadioButton ID="rdb210a3" runat="server" Text="其它意见" GroupName="210a" ForeColor="#008162" />
                        <textarea id="txtIDx210" rows="6" cols="3" style="width: 98%; overflow: auto;" runat="server" clientidmode="Static"></textarea>
                        <asp:Button ID="btnsSignIDx210" runat="server" OnClick="btnSignIDx210_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx210">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF4" class="noborder" style="height: 85px; display: none;">
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb211a1" runat="server" Text="同意" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a2" runat="server" Text="不同意" GroupName="211a" />
                        <asp:RadioButton ID="rdb211a3" runat="server" Text="其它意见" GroupName="211a" ForeColor="#008162" />
                        <textarea id="txtIDx211" rows="6" cols="3" style="width: 98%; overflow: auto;" runat="server" clientidmode="Static"></textarea>
                        <asp:Button ID="btnsSignIDx211" runat="server" OnClick="btnSignIDx211_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx211">_________</span>
                        </span>
                    </td>
                </tr>
                <tr id="trAddAnoF3" class="noborder" style="height: 85px; display: none;">
                    <td>董事总经理复审</td>
                    <td colspan="3" class="tl PL10" style="">
                        <asp:RadioButton ID="rdb220a1" runat="server" Text="同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a2" runat="server" Text="不同意" GroupName="220a" />
                        <asp:RadioButton ID="rdb220a3" runat="server" Text="其它意见" GroupName="220a" ForeColor="#186ebe" />
                        <textarea id="txtIDx220" rows="6" cols="3" style="width: 98%; overflow: auto;" runat="server" clientidmode="Static"></textarea>
                        <asp:Button ID="btnsSignIDx220" runat="server" OnClick="btnSignIDx220_Click" Text="确认" Visible="False" />
                        <br />
                        <span style="padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;">日期：<span id="spanDateIDx220">_________</span>
                        </span>
                    </td>
                </tr>
            </table>
            <div style="height: 10px; width: 840px;"></div>
            <table id="tbAround2" width="840px">
                <thead>
                    <tr>
                        <td style="font-weight: bold; text-align: left; padding-left: 10px;" colspan="2">已上传资料：</td>
                    </tr>
                </thead>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack1" runat="server" Text="代理合同/联动协议" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack2" runat="server" Text="商铺现场照片" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack3" runat="server" Text="商铺平面图" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack4" runat="server" Text="《转介表》" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack5" runat="server" Text="房友圈电商佣不足90%的原因说明" />
                    </td>
                    <td style="text-align: left; padding-left: 10px;">
                        <asp:CheckBox ID="cbLack7" runat="server" Text="房友圈《项目合同审批表》" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; padding-left: 10px;" colspan="2">
                        <asp:CheckBox ID="cbLack6" runat="server" Text="其他资料" /><br />
                        <asp:TextBox ID="txtLack6" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="width: 640px; margin: 5px auto;">
                <span class="tl" style="float: left;">备注：1物业部承接一手项目/一手货尾盘，需上此报备申请表。<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2物业部承接二手物业达20套或以上的属批量项目，需上此报备申请表。</span>
            </div>
            <!--打印正文结束-->
        </div>
        <div style="clear: both;"></div>

        <div class="noprint">
            <asp:GridView ID="gvAttach" CssClass="gvAttach" runat="server" BackColor="White" Style="clear: both; margin-top: 3px;"
                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="false"
                ForeColor="Black" GridLines="Vertical" OnRowCommand="gvAttach_RowCommand">
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
                            <asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="/Images/disable.gif" CommandName="Del" CommandArgument='<%#Eval("OfficeAutomation_Attach_ID")%>' OnClientClick="return confirm('确认删除？');" />
                            <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("OfficeAutomation_Attach_ID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="附件" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <a id="link" href='<%=ConfigurationManager.AppSettings["EcoaFileURL"]%><%#Eval("OfficeAutomation_Attach_Path")%>' target="_blank"><%#Eval("OfficeAutomation_Attach_Name")%></a>
                            <asp:HiddenField ID="hfPath" runat="server" Value='<%#Eval("OfficeAutomation_Attach_Path")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle BackColor="#F7F7DE" />
                <FooterStyle BackColor="#CCCC99" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <asp:HiddenField runat="server" ID="AppendixCount" />
            <div id="PageBottom">
                <span id="spm"></span>
                <br />
                <hr />
                <asp:Button runat="server" ID="btnReWrite" Text="重新导入" OnClick="btnReWrite_Click" Visible="False" />
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnTemp" Text="暂时保存" OnClick="btnTempSave_Click" CssClass="commonbtn" OnClientClick="return tempsavecheck();" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" Visible="false" OnClientClick="if(confirm('修改后所有已审批的环节都必须重审，确定要修改吗？'))return check();else return false;" OnClick="btnSAlterC_Click" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />
                <input type="hidden" id="hdDetail" runat="server" />
                <asp:HiddenField ID="hdCancelSign" runat="server" />
                <asp:HiddenField ID="HidAutoN" runat="server" />
                <asp:HiddenField ID="HdAutoAdd" runat="server" />
                <asp:HiddenField ID="HdP" runat="server" />
                <asp:HiddenField ID="HdE" runat="server" />
                <asp:HiddenField ID="hfKey1" runat="server" />
                <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click" Style="display: none;" />
            </div>
        </div>
    </div>
</asp:Content>

