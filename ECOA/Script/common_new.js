//通用方法
//打印
function cMyPrint(start, end, extend) {
    window.print();
}
//上传
function cUpload(MainID, ApplyN) {
    var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "&AUpload=" + escape(ApplyN) + "&href=" + window.location.href, MainID, "dialogHeight=165px");
    if (sReturnValue == 'success')
        window.location = window.location.pathname + '?MainID=' + MainID;
}

//选中下载的附件
function cCheckChecked(domid) {
    var gv = document.getElementById(domid);
    var input = gv.getElementsByTagName("input");
    var flagCheck = false;

    for (var i = 0; i < input.length; i++) {
        if (input[i].type == 'checkbox' && !input[i].disabled && input[i].checked) {
            flagCheck = true;
            break;
        }
    }

    if (!flagCheck)
        alert("请勾选文件再下载！");

    return flagCheck;
}
//返回
function cBackToSearch(QueryString) {
    location.href = '/Apply/Apply_Search.aspx?' + QueryString;
    return false;
}

//编辑流程
function cEditflow(MainID) {
    //默认情况下 当前页面的Detail改成Flow就是当前页面对应的编辑流程页面。
    var url = window.location.pathname.replace("Detail", "Flow");
    var win = window.showModalDialog(url + "?MainID=" + MainID, "", "dialogWidth=800px;dialogHeight=320px");
    if (win == 'success')
        window.location = window.location.pathname + "?MainID=" + MainID;
}

//编辑流程（为营业部自主招聘需求申请使用）
function cEditflowNew(MainID, type) {
    //默认情况下 当前页面的Detail改成Flow就是当前页面对应的编辑流程页面。
    var url = window.location.pathname.replace("Detail", "Flow");
    var win = window.showModalDialog(url + "?MainID=" + MainID+"&type="+type, "", "dialogWidth=800px;dialogHeight=320px");
    if (win == 'success')
        window.location = window.location.pathname + "?MainID=" + MainID;
}
//取消签名
function cCancelSign(idc,CancelSignID,CancelSignBtnID) {
    if (confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
    {
        $("#" + CancelSignID).val(idc);
        document.getElementById(CancelSignBtnID).click();
    }
}
//签名事件
function cSign(e, IsAgreeID, SuggestionID, btnSignID, IdxID) {
    var $tr = $(e).parent().parent().parent();
    var idx = $tr.attr("Idx");
    var agree = "";
    $tr.find("input[type=radio]").each(function () {
        if (this.checked) {
            agree = this.value;
        }
    });
    if (agree == "") {
        alert("请确定是否同意！");
        return false;
    }
    var $textarea = $tr.find("textarea");
    if (agree == "0") {
        if ($.trim($textarea.val()) == "") {
            alert("由于您不同意该申请，必须填写不同意的原因。");
            return false;
        }
    }
    if (agree == "2") {
        if ($.trim($textarea.val()) == "") {
            alert("由于您选了其他意见，必须填写其他意见内容。");
            return false;
        }
    }
    if (confirm("是否确认审核？")) {
        $(e).attr("disabled", "disabled");
        $("#" + IsAgreeID).val(agree);
        $("#" + SuggestionID).val($.trim($textarea.val()));
        $("#" + IdxID).val(idx);
        document.getElementById(btnSignID).click();
    }
}

//复审签名
function cSignfs(e, IsAgreeID, SuggestionID)
{
    var $tr = $(e).parent().parent().parent();
    var idx = $tr.attr("Idx");
    var agree = "";
    $tr.find("input[type=radio]").each(function () {
        if (this.checked) {
            agree = this.value;
        }
    });
    if (agree == "") {
        alert("请确定是否同意！");
        return false;
    }
    var $textarea = $tr.find("textarea");
    if (agree == "0") {
        if ($.trim($textarea.val()) == "") {
            alert("由于您不同意该申请，必须填写不同意的原因。");
            return false;
        }
    }
    if (agree == "2") {
        if ($.trim($textarea.val()) == "") {
            alert("由于您选了其他意见，必须填写其他意见内容。");
            return false;
        }
    }
    if (confirm("是否确认审核？")) {
        $(e).attr("disabled", "disabled");
        $("#" + IsAgreeID).val(agree);
        $("#" + SuggestionID).val($.trim($textarea.val()));
        return true;
    }
    else {
        return false;
    }
}

//签名列表初始化及事件绑定
function SignFunBind() {
    //遍历radio 赋值name
    $("#tbflows .noborder").each(function () {
        var idx = $(this).attr("Idx");
        if (idx != undefined) {
            $(this).find("input[type=radio]").attr("name", "agree" + idx);
        }
    });
    //遍历.l 添加点击事件
    $("label.l").each(function () {
        $(this).on("click", function () {
            var radio = $(this).prev().get(0);
            if (!radio.disabled) {
                radio.checked = !radio.checked;
            }
        });
    });
}

//签名内容绑定
//SignFlowsJsonID:存放SignFlow数据的input id
//Apply申请人姓名
//Empoyee当前登录人姓名
//EmpoyeeID当前登录人工号
function cFlowSignInit(SignFlowsJsonID, Apply, Empoyee, EmpoyeeID) {
  //  var ShowSignNameType =0;
  //  //add by 2018-6-2   start
  //  ShowSignNameType = typeof ShowSignNameType !== 'undefined' ? ShowSignNameType : 0;
  ////  alert(ShowSignNameType)
  //  //end
  
    var flowsign = $("#" + SignFlowsJsonID).val();
    
    if (flowsign == undefined || flowsign == "")
    { return; }
    var data = $.parseJSON(flowsign);
   // console.log(data);
    var $tr200 = $("#tbflows tr[Idx='" + 200 + "']");
    var $tr220 = $("#tbflows tr[Idx='" + 220 + "']");

    var $tr200textarea = $tr200.find(".fieldtext textarea");
    var $tr220textarea = $tr220.find(".fieldtext textarea");

    var ManagerIdx = 0; //区域负责人流程
    var ManagerID = ""; //区域负责人工号
    var Manager = "";   //区域负责人姓名

    for (var i = 0 ; i < data.length ; i++) {
        var d = data[i];
        //寻找idx流程对应的tr
        var $tr = $("#tbflows tr[Idx='" + d.Idx + "']");
        $tr.show(); //显示（有部分tr一开始需要隐藏，需要它流程时才显示）

        if ($tr.attr("Manager") == "true")
        {
            //记录区域负责人流程信息（用于复审）
            ManagerIdx = d.Idx; 
            ManagerID = d.EmployeeID;
            Manager = d.Employee;
        }

        $texteara = $tr.find(".fieldtext textarea");
        var $radio = $tr.find("input[type=radio][value=" + d.IsAgree + "]"); //radio赋值
        if ($radio != undefined && $radio.length > 0) {
            $radio.get(0).checked = true;
        }
        //流程已经审核通过
        if (d.Audit) {
            if ($texteara.css("display") != "none") {
                $texteara.before(d.Suggestion);   //插入意见内容
            }

            $texteara.hide();  //隐藏意见框
            //$texteara.before(d.Suggestion);   //插入意见内容
            
        }
        else {
            $texteara.show().val(d.Suggestion);   //意见写入textarea

            //复审
            if (d.Idx >= 200)
            {
                $texteara.before(d.Suggestion);   //插入意见内容
                $texteara.val("");
            }
        }

        //显示签名按钮
        if (d.SignbtnShow) {
            $tr.find(".signbtn").css("display", "block");
        }
        //add by 2018-6-2   start
       // if (ShowSignNameType == 0) {
           
          //  if (!d.Audit) {


                var signhtml = "";
                if (d.Auditors != null && d.Auditors.length > 0) {
                    for (var j = 0; j < d.Auditors.length ; j++) {
                       // console.log("Name" +':'+d.Auditors[j].Name +":CancelSignbtnShow"+d.Auditors[j].CancelSignbtnShow);
                        var showbtn = d.Auditors[j].CancelSignbtnShow;
                        signhtml += '<div class="signdiv">';
                        signhtml += '<p>' + d.Auditors[j].Name + '</p>';  //姓名
                        signhtml += '<p><img src="' + d.Auditors[j].SignPic + '" alt="' + d.Auditors[j].Name + '签名" /></p>';    //签名图
                        signhtml += showbtn ? '<p><input type="button" value="撤消" onclick="CancelSign(\'' + d.Idx + '\')" class="cancelbtn" /></p>' : '';   //是否显示取消签名按钮
                        signhtml += '</div>';
                       // console.log(signhtml);
                    }
                }
             
                $tr.find(".fieldsign").html(signhtml);
           // }
        //}

        //else {
           
        //        var signhtml = "";
        //        if (d.Auditors != null && d.Auditors.length > 0) {
        //            for (var j = 0; j < d.Auditors.length ; j++) {
        //                console.log(d.Auditors[j].SignPic);
        //                var showbtn = d.Auditors[j].CancelSignbtnShow;
        //              // signhtml += '<div class="signdiv">';
        //                signhtml += '<div>';
        //                if (d.Audit)
        //                signhtml += '<p>' + d.Auditors[j].Name + '</p>';  //姓名
        //                signhtml += '<p><img src="' + d.Auditors[j].SignPic + '" class="move_img"  alt="' + d.Auditors[j].Name + '签名"/></p>';    //签名图
        //                if (d.Audit)
        //                signhtml += showbtn ? '<p><input type="button" value="撤消" onclick="CancelSign(\'' + d.Idx + '\')" class="cancelbtn" /></p>' : '';   //是否显示取消签名按钮
        //                signhtml += '</div>';
        //            }
        //        }
         //       $tr.find(".fieldsign").html(signhtml);
          
          
      //  }
     
        //end


        //插入签名
        //var signhtml = "";
        //if (d.Auditors != null && d.Auditors.length > 0) {
        //    for (var j = 0; j < d.Auditors.length ; j++) {
        //        var showbtn = d.Auditors[j].CancelSignbtnShow;
        //        signhtml += '<div class="signdiv">';
        //        signhtml += '<p>' + d.Auditors[j].Name + '</p>';  //姓名
        //        signhtml += '<p><img src="' + d.Auditors[j].SignPic + '" alt="' + d.Auditors[j].Name + '签名" /></p>';    //签名图
        //        signhtml += showbtn ? '<p><input type="button" value="撤消" onclick="CancelSign(\'' + d.Idx + '\')" class="cancelbtn" /></p>' : '';   //是否显示取消签名按钮
        //        signhtml += '</div>';
        //    }
        //}
        //$tr.find(".fieldsign").html(signhtml);

        //显示签名时间
        if (d.AuditDate != "") {
            $tr.find(".signdate").html(d.AuditDate);
        }
    }

    //////////////////////////////////////////////////////////////////////////////
    ///复审相关///////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////
    var l = data.length;
    //通常地黄生的审核是最后一环，并且idx小于200（idx=200默认为复审流程，idx=220默认为黄生复审流程）
    //审核的最后一步 && 审核已完成 && 其他意见 && 最后一步的审核人是黄生&& Idx < 200
    var lastflow = data[l - 1];
    if (lastflow.Idx < 220 && lastflow.Audit && lastflow.IsAgree == "2" && lastflow.EmployeeID == "0001")
    {
        if ((Apply == Empoyee || (Manager + ",").indexOf(Empoyee + ",") > -1) && lastflow.Audit) {

            //黄生正规流程审核是其他意见
            if (d.Idx < 200) {
                $tr200.show();
                $tr200.find(".signbtn").css("display", "block");   //显示复审确定提交按钮
            }
        }
    }

    //黄生复审仍然选其他意见
    if (lastflow.Idx == 220 && lastflow.IsAgree == "2" && lastflow.Audit) {
        //申请人、区域负责人允许复审
        //登录人=申请人，区域负责人姓名含有登录人姓名
        if ((Apply == Empoyee || (Manager + ",").indexOf(Empoyee + ",") > -1) && lastflow.Audit) {
            $tr200textarea.show();
            $tr200.find(".signbtn").css("display", "block");   //显示复审确定提交按钮
        }
    }

    //复审栏的textarea跟黄生复审栏textarea不能同时显示
    if ($tr200textarea.css("display") == "none") {
        if (!lastflow.Audit) {
            $tr220textarea.show();
        }
        else {
            $tr220textarea.hide();
        }
    }
    else {
        $tr220textarea.hide();
    }


   
        
}

//验证带requiredmes标签的，非.readonly的控件
function REQUIRED_Check() {
    var flag = true;
    $("input[requiredmes],select[requiredmes],textarea[requiredmes]").each(function () {
        if ($.trim(this.value) == "" && !$(this).hasClass("readonly")) {
            var mes = $(this).attr("requiredmes");
            $(this).focus();
            alert(mes);
            flag = false;
            return false;
        }
    });
    return flag;
}

//对idname下所有带errormes属性的input验证非空，并弹出errormes消息
function DetailContent_Check(idname)
{
    var flag = true;
    $("#" + idname).find("input[type=text]").each(function () {
        var errormes = $(this).attr("errormes");
        if (errormes != undefined && errormes != "") {
            if ($.trim(this.value) == "") {
                $(this).focus();
                alert(errormes);
                flag = false;
                return false;
            }
        }
        if (!flag) {
            return false;
        }
    });
}

function cDeleteT(MainID, ApplyN) { //20141231：M_DeleteC
    $("#btnADelete").hide();
    var url = "/Apply/Apply_DeleteDialog.aspx?mainID=" + MainID + "&url=Nothing&apply=" + escape(ApplyN) + "&href=" + window.location.href;
    var sReturnValue = window.showModalDialog(url, MainID, "dialogHeight=260px;dialogWidth=665px;");
    if (sReturnValue == 'deleted')
        window.location = '/Apply/Apply_Search.aspx';
    else
        window.location.href = window.location.href;
}

//绑定时间控件
function DatePluginBind()
{
    $("[dateplugin='datepicker']").each(function () {
        $(this).datepicker();
    });
}

//页面初始化
function CommonPageInit()
{
    //签名方法事件初始化
    SignFunBind();

    //时间控件
    DatePluginBind();

    $(".readonly").each(function () {
        $(this).attr("readonly","readonly");
    });
}