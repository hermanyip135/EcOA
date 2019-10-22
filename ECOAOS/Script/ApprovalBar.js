//找出所有同部门多审批流的tr
var trs = new Array();

/// 旧申请表的获取方法
$("input[id*=rdbYesIDx]").parent().parent().each(function () {
    var firsttd = $(this).find("td").eq(0);
    var rowspan = firsttd.attr("rowspan");
    if (typeof (rowspan) != "undefined") {
        trs.push(this);
    }
});
$("tr[id*=trAddAnoF]").each(function () {
    var firsttd = $(this).find("td").eq(0);
    var rowspan = firsttd.attr("rowspan");
    if (typeof (rowspan) != "undefined") {
        trs.push(this);
    }
});
///end

///新申请的获取方法
$("#tbflows").find("tr").each(function () {
    var firsttd = $(this).find("td").eq(0);
    var rowspan = firsttd.attr("rowspan");
    if (typeof (rowspan) != "undefined") {
        trs.push(this);
    }
});
///end

//分别在各自的部门里找boss流程
for (var i = 0 ; i < trs.length; i++) {
    var rowspan = parseInt($(trs[i]).find("td").eq(0).attr("rowspan"));
    var bossidx = 0;
    var $nexttr = $(trs[i]);
    //找部门boss idx
    for (var j = 0; j < rowspan - 1; j++) {
        //console.log(typeof ($nexttr));
        $nexttr = $nexttr.next();
        $rdbIdx = $nexttr.find("input[id*=rdbYesIDx]");//审批
        if ($nexttr.css("display") != "none" && typeof ($rdbIdx) != "undefined" && $rdbIdx.length > 0) {
            var id = $rdbIdx.attr("id");
            bossidx = parseInt(id.substr(9, id.length - 9));
            //console.log(bossidx);
        }
    }

    var newattr = "bossidx";
    $(trs[i]).attr(newattr, bossidx);
    $nexttr = undefined;
    var rows = rowspan;//记录跨行数
    for (var j = 0; j < rowspan - 1; j++) {
        rows--;
        if (typeof ($(trs[i]).find("span[id*=spanDateIDx]")) != "undefined" && $(trs[i]).find("span[id*=spanDateIDx]").length!=0)
        {
            if ($(trs[i]).find("span[id*=spanDateIDx]").text().length > 12) {
                $hidetr = typeof ($nexttr) == "undefined" ? $(trs[i]) : $nexttr;//隐藏审批tr
                $nexttr = typeof ($nexttr) == "undefined" ? $(trs[i]).next() : $nexttr.next();
                //console.log($nexttr.attr("id").indexOf("trAddAnoF"));
                $rdbIdx = $nexttr.find("input[id*=rdbYesIDx]");//审批              
                if ($nexttr.css("display") != "none" && typeof ($rdbIdx) != "undefined" && $rdbIdx.length > 0) {
                    $nexttr.attr(newattr, bossidx);
                    if ($nexttr.find("span[id*=spanDateIDx]").text().length < 12) {
                        $nexttr.find("textarea[id*=txtIDx]").val($($hidetr).find("textarea[id*=txtIDx]").val());
                    }               
                    if ($nexttr.find("span[id*=spanDateIDx]").text().length > 12) {
                        var td = $($hidetr).find("td").eq(0);
                        if ($($hidetr).find("span[id*=spanDateIDx]").text().length < 12) {
                            td = $(trs[i]).find("td").eq(0);
                        }
                        $nexttr.prepend(td.attr("rowspan", rows));
                        $($hidetr).hide();
                        $(trs[i]).hide();
                    }
                }
                else if (typeof ($nexttr.attr("id")) != "undefined" || $nexttr.attr("id") != null) {
                    if ($nexttr.attr("id").indexOf("trAddAnoF") != -1) {
                        $rdbfIdx = $nexttr.find("span[id*=spanDateIDx]");//复审
                        if ($nexttr.css("display") != "none" && typeof ($rdbfIdx) != "undefined" && $rdbfIdx.length > 0) {
                            $nexttr.attr(newattr, bossidx);
                            if ($nexttr.find("span[id*=spanDateIDx]").text().length < 12) {
                                $nexttr.find("textarea[id*=txtIDx]").val($(trs[i]).find("textarea[id*=txtIDx]").val());
                                var td = $(trs[i]).find("td").eq(0);
                                $nexttr.prepend(td.removeAttr("rowspan"));
                                $(trs[i]).hide();
                            } else {
                                var td = $(trs[i]).find("td").eq(0);
                                $nexttr.prepend(td.removeAttr("rowspan"));
                                $(trs[i]).hide();
                            }
                        }
                    }
                }
            }
        }
        else if (typeof ($(trs[i]).find("span[class=signdate]")) != "undefined" && $(trs[i]).find("span[class=signdate]").length != 0)
        {
            if ($(trs[i]).find("span[class=signdate]").text().length > 12) {
                $hidetr = typeof ($nexttr) == "undefined" ? $(trs[i]) : $nexttr;//隐藏审批tr
                $nexttr = typeof ($nexttr) == "undefined" ? $(trs[i]).next() : $nexttr.next();
                $rdbIdx = $nexttr.find("label[class*=signyes]");//审批              
                if ($nexttr.css("display") != "none" && typeof ($rdbIdx) != "undefined" && $rdbIdx.length > 0) {
                    //$nexttr.attr(newattr, bossidx);
                    if ($nexttr.find("span[class=signdate]").text().length < 12) {
                        $nexttr.find("textarea").val($(trs[i]).find("textarea").val());
                    }
                    if ($nexttr.find("span[class=signdate]").text().length > 12) {
                        var td = $($hidetr).find("td").eq(0);
                        if ($hidetr.find("span[class=signdate]").text().length < 12) {
                            td = $(trs[i]).find("td").eq(0);
                        }
                        $nexttr.prepend(td.attr("rowspan", rows));
                        $($hidetr).hide();
                        $(trs[i]).hide();
                    }
                }
            }
        }
    }
}