<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Script/jquery-1.9.1.js"></script>
    <title></title>
    <script type="text/javascript">
        var rowCount = 0;
        var colCount = 0;

        $(function () {

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

        })

        function addRow() {
            rowCount++;
            var rowTemplate = '<tr class="tr_' + rowCount + '"><td>' + rowCount + '</td><td class="cl1">内容' + rowCount + '</td><td class="cl1"><a href="#" onclick=delRow(' + rowCount + ')>删除</a></td></tr>';
            var tableHtml = $("#testTable tbody").html();
            tableHtml += rowTemplate;
            $("#testTable tbody").html(tableHtml);
        }

        function delRow(_id) {
            $("#testTable .tr_" + _id).hide();
            rowCount--;
        }

        function addCol(titleid) {
            colCount++;
            //debugger;
            var title = "";
            var td = "";
            var temp = "";
            //若是已勾选了一列，则再次勾选其他选项后，要先获取上一次勾选的内容
            var oldChoice = $("#Text1").val();
            //然后再把新的勾选内容替换旧的勾选内容。
            $("#Text1").val(titleid);
            var newChoice = titleid;

            var newArr = newChoice.split("|");
            for (var i = 0; i < newArr.length; i++) {
                if (oldChoice.indexOf(newArr[i]) < 0) {
                    //不存在
                    title = "|" + newArr[i];
                }
            }

            titleid = title;

            if (titleid.indexOf("|") > -1) {
                temp = titleid.split("|");
                for (var i = 0; i < temp.length; i++) {
                    if (temp[i] == "1") {
                        td += "<td id=\"tdTitle1\">成交日期</td>";
                        addContrl(1, "dealDate");
                    }

                    if (temp[i] == "2") {
                        td += "<td id=\"tdTitle2\">物业类型</td>";
                    }

                    if (temp[i] == "3") {
                        td += "<td id=\"tdTitle3\">成交套数</td>";
                    }

                    if (temp[i] == "4") {
                        td += "<td id=\"tdTitle4\">成交面积</td>";
                    }

                    if (temp[i] == "5") {
                        td += "<td id=\"tdTitle5\">成交价</td>";
                    }
                }
            }
            else {
                if (titleid == "1") {
                    td += "<td id=\"tdTitle1\">成交日期</td>";
                    addContrl(1, "dealDate");
                }

                if (titleid == "2") {
                    td += "<td id=\"tdTitle2\">物业类型</td>";
                }

                if (titleid == "3") {
                    td += "<td id=\"tdTitle3\">成交套数</td>";
                }

                if (titleid == "4") {
                    td += "<td id=\"tdTitle4\">成交面积</td>";
                }

                if (titleid == "5") {
                    td += "<td id=\"tdTitle5\">成交价</td>";
                }
            }

            //$("#testTable tr").each(function () {
            //    var trHtml = $(this).html();
            //    trHtml += td;
            //    $(this).html(trHtml);
            //});
            //$("#testTable thead tr").html("");
            var trHtml = $("#testTable thead tr").html();
            trHtml += td;
            $("#testTable thead tr").html(trHtml);


        }

        function delCol(_id) {
            //debugger;

            var colCount = $("td[id*=tdTitle" + _id + "]").length;

            $("#testTable thead tr").each(function () {

                if (colCount == 1) {
                    $("#tdTitle" + _id + "").hide();
                }
                else {
                    $("#tdTitle" + _id + "").each(function () {
                        //debugger;
                        $("#tdTitle" + _id + "").hide();
                    });
                }

            });

            colCount--;
        }

        function addContrl(ctrlID, ctrlType) {
            var dealDate = "<input id=\"txtDealDateBegin" + ctrlID + "\" name=\"txtDealDateBegin" + ctrlID + "\" type=\"text\" style=\"width: 80px; margin-right: 10px;\" />≤ 成交日期 ＜<input id=\"txtDealDateEnd" + ctrlID + "\" name=\"txtDealDateEnd" + ctrlID + "\" type=\"text\" style=\"width: 80px; margin-left: 10px;\" />";
            var td = "";
            if (ctrlType == "dealDate") {
                td = "<td id=\"tdContent" + ctrlID + "\">" + dealDate + "</td>";
            }

            var trHtml = $("#testTable tbody tr").html();
            trHtml += td;
            $("#testTable tbody tr").html(trHtml);
        }

        function delContrl(ctrlID) {
            $("#testTable tbody tr").each(function () {
                $("#tdContent" + ctrlID + "").hide();
            });
        }

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

            var div = $("#dvTest").html();
            if (div != "") {
                $("#dvTest").html("");
            }
            $("#dvTest").html(table);
        }
        var i4 = 1;
        //按列生成现金奖 增加一行
        addRow4 = function () {
            debugger;
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
    <style>
        .cl1 {
            background-color: #FFFFFF;
        }

        .cl2 {
            background-color: #FFFF99;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>
            <asp:TextBox ID="txtMainID" runat="server"></asp:TextBox><br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0" Text="测试1"></asp:ListItem>
                <asp:ListItem Value="1" Text="测试2"></asp:ListItem>
                <asp:ListItem Value="2" Text="测试3"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="600px" Width="500px"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>--%>
        <%--<table>
            <tbody id="test">
            </tbody>
        </table>--%>
        <input id="hidCashPrizeType" type="hidden" runat="server" clientidmode="Static" />
        <input id="hidCashPrizeConditions" type="hidden" runat="server" clientidmode="Static" />
        <input id="hidCashPrizeChoiceConditions" type="hidden" runat="server" clientidmode="Static" />

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
            <div id="dvTest">
            </div>



        </div>
        <%-- 按条件划分现金奖 end --%>
        <%-- 其余情况 start --%>
        <div id="dvOtherPrize" style="width: 100%;">
            <textarea id="txtaOtherPrizePerSet" cols="20" rows="3" style="width: 90%; height: 55px;" runat="server" clientidmode="Static"></textarea>
        </div>
        <%-- 其余情况 end --%>
    </form>
</body>
</html>

