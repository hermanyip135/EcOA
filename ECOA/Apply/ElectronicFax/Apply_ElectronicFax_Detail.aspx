<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_ElectronicFax_Detail.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Apply_ElectronicFax_Apply_ElectronicFax_Detail" %>
<%@ Register Src="../../Common/FlowShow.ascx" TagName="FlowShow" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="/Script/common_new.js"></script>
    <style type="text/css">
        #div1 {
            width: 400px;
            height: 120px;
        }

        .move_img {
            position: absolute;
            cursor: pointer;
            left:0px;
        }
    </style>
    <script type="text/javascript">
   
        
        var i = 1;
        var jaf = 200;
        var content = "";
        var deleteidxs = "";
        var flga = 2;
        var jJSONF = <%=SbJsonf.ToString() %>;
        var jJSON = <%=SbJson.ToString() %>;
        var SkyPlay = <%=SkyPlay.ToString() %>;
        var isNewApply=('<%=IsNewApply%>'=='True');
        function split( val ) {
            return val.split( /,\s*/ );
        }
        function extractLast( term ) {
            return split( term ).pop();
        }
   


        $(function() {    
          
            $("[id*=btn2Upload]").css({
                "background-image": "url(/Images/btn_upload_s1.png)",
                "height": "25px", 
                "width": "72px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF",
                "border":"0"
            });
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

            $("[id*=btnAddFlow]").css({
                "background-image": "url(/Images/btn_AddFlows1.png)",
                "height": "20px", 
                "width": "90px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnAddFlow]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_AddFlows2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_AddFlows1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_AddFlows1.png)"); });

            $("[id*=btnDeleteFlow]").css({
                "background-image": "url(/Images/btn_DeleteFlows1.png)",
                "height": "20px", 
                "width": "114px",
                "font-size": "0px",
                "cursor":"pointer",
                "color": "#FFFFFF"
            });
            $("[id*=btnDeleteFlow]").mousedown(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows2.png)"); })
                .mouseup(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows1.png)"); })
                .mouseleave(function () { $(this).css("background-image", "url(/Images/btn_DeleteFlows1.png)"); });

            i = $("#tbDetail tr").length;
            if($.trim($("#txtIDxa1").val())!="")
                $("#<%=hdFlowApply.ClientID %>").val($("#txtIDxa1").val());
            else if($.trim($("#txtIDxa2").val())!="")
                $("#<%=hdFlowApply.ClientID %>").val($("#txtIDxa2").val());
            else if($.trim($("#txtIDxa3").val())!="")
                $("#<%=hdFlowApply.ClientID %>").val($("#txtIDxa3").val());
               $("#<%=txtDepartment.ClientID %>").autocomplete({ 
                   source: jJSON,
                   select:function(event,ui){
                       $("#<% =hdDepartmentID.ClientID%>").val(ui.item.id);
                    $.ajax({
                        url: "/Ajax/HR_Handler.ashx",
                        type: "post",
                        dataType: "text",
                        data: 'action=getHRTreeByDepartmentID&departmentid=' + ui.item.id,
                        success: function(info) {
                            if (info == "fail") 
                            {}
                                // alert("保存失败，部分人名不存在或不具备审批资格，\n请修改，如依然失败，请联系资讯科技部！");
                            else
                            {
                            }
                        }
                    })
                }
               });
       
            
               for (var x = 1; x < i; x++) {
                   $("#txtDpm"+ x).autocomplete({source: jJSON});
              
               }
		    
               for(var il =1;il<=$("[id^=txtIDxa]").size();il++)
               {
                   $("#txtIDxa" + il)
                       .bind( "keydown", function( event ) {
                           if ( event.keyCode === $.ui.keyCode.TAB && $( this ).data( "ui-autocomplete" ).menu.active ) {
                               event.preventDefault();
                           }
                       })
                       .autocomplete({
                           minLength: 0,
                           source: function( request, response ) {
                               // delegate back to autocomplete, but extract the last term
                               response( $.ui.autocomplete.filter(jJSONF, extractLast( request.term ) ) );
                           },
                           focus: function() {
                               // prevent value inserted on focus
                               return false;
                           },
                           select: function( event, ui ) {
                               var terms = split( this.value );
                               // remove the current input
                               terms.pop();
                               // add the selected item
                               terms.push( ui.item.value );
                               // add placeholder to get the comma-and-space at the end
                               terms.push( "" );
                               this.value = terms.join( "," );
                               return false;
                           }
                       });
               }
               autoTextarea(document.getElementById("txtIDx1"));
               autoTextarea(document.getElementById("txtIDx2"));
               autoTextarea(document.getElementById("txtIDx3"));
              $('.move_containner').attr("src","<%=BigPicture%>");
               cSignLeftTopListJson("<%=this.hiSignLeftTopListJson.ClientID%>");
               AuditJpg("<%=this.hiAuditJpg.ClientID%>");
           
            //if($('.move_containner').attr("src")=="")
            //{
            //    $('.move_containner').css("height","400px");
            //}
            //else{
                
            //    $('.move_containner').css("height","auto");
            //}
        });
        function myPrint(start, end, extend) {    
            //  cMyPrint();
            preview();
        }
        function preview()
        {
            bdhtml=window.document.body.innerHTML;
            sprnstr="<!--startprint-->";
            eprnstr="<!--endprint-->";
            prnhtml=bdhtml.substr(bdhtml.indexOf(sprnstr)+17);
            prnhtml=prnhtml.substring(0,prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML=prnhtml;
            window.print();
        }
        //加载已审核签名图
        function cSignLeftTopListJson(SignFlowsJsonID)
        {

            var signhtml ="";
            var flowsign = $("#" + SignFlowsJsonID).val();
           
            if(flowsign!=""){
                var data = $.parseJSON(flowsign);
               
                for (var i = 0 ; i < data.length ; i++) {
                    var d = data[i];
                    signhtml += '<p><img src="' + d.Auditors + '"  style ="left:'+d.Auditorx+'px;top:'+d.Auditory+'px;position:absolute;"/></p>';    //签名图
           
                }
            }
            $("#FaxBody").append(signhtml);
        }
        //准备签名图
        function AuditJpg(hiAuditJpg)
        {
            
            var flowsign = $("#" + hiAuditJpg).val();
          
            if (flowsign == undefined || flowsign == "")
            { return; }
            var data = $.parseJSON(flowsign);
          
            var signhtml = "";
            for (var i = 0 ; i < data.length ; i++) {
                var d = data[i];
            
                if (d.Auditors != null && d.Auditors.length > 0) {
                    for (var j = 0; j < d.Auditors.length ; j++) {
                      
                        if(d.Auditors[j].Code == '<%=EmpID%>' && (d.SignbtnShow == true))
                        {
                          
                          signhtml+='<div class="move_img" style="position:absolute; width:100px;height:80px" ><p><img src="' + d.Auditors[j].SignPic + '"   alt="' + d.Auditors[j].Name + '签名"/></p></div>';
                        }
                      
                    }
                }
               
            }
            $("#SignPic").html(signhtml);
            jQuery.fn.extend({
                beDrag: function () {
                    var movestart = false;//判断鼠标是否在移动图片
                    var x1, y1;
                    this.mousedown(function () {
                        movestart = true;
                        x1 = event.offsetX;
                        y1 = event.offsetY;
                    });
                    this.mouseup(function (e) {
                        var lastX = event.x - x1;
                        var lastY = event.y - y1;
                        if (lastX>0 && lastY>0 && (lastY <= (imgHeight-80)) && lastX<=651) {
                            if(confirm('确定要签名吗?'))
                            {
                                var relativeLastX=lastX-move_containner_left;
                                var relativeLastY=lastY-move_containner_top;
                                  
                                var img = new Image();
                                var divTop = $(".containner_div").scrollTop()
                                $("#<%=this.hiLastX.ClientID%>").val(lastX);
                                    $("#<%=this.hiLastY.ClientID%>").val(lastY+divTop);
                                    document.getElementById("<%=btnSign.ClientID %>").click();
                                }
                                else
                                {
                                    $(".move_img").css("left", move_img_left + "px");
                                    $(".move_img").css("top", move_img_top + "px");
                                }
                                //弹出确认框
                            } else {
                                alert("不在区域内");
                                $(".move_img").css("left", move_img_left + "px");
                                $(".move_img").css("top", move_img_top + "px");

                            }
                            movestart = false;
                        });

                        this.mousemove(function () {
                            if (movestart) {
                                $(".move_img").css("left", event.x - x1 + "px");
                                $(".move_img").css("top", event.y - y1 + "px");
                                return false
                            }
                        })
                    }
                })
                var AuditJpg=133;
                var move_containner_left = $(".move_containner").offset().left;
                var move_containner_top = $(".move_containner").offset().top;
                var imgHeight = $(".move_containner").height()
                var imgWidth = $(".move_containner").width()
                var move_img_left = 0;
                var move_img_top = imgHeight;

                var maxY = move_containner_top + imgHeight;
                var maxX = move_containner_left + imgWidth;
                $(".move_img").beDrag();
        }
        function draw(sourseImgPath,sourseWidth,sourseHeight,sighSrc,sighX,sighY,sighWidth,sighHeight) {
         
            var c = document.createElement('canvas'),
                ctx = c.getContext('2d');
          
            c.width = sourseWidth;
            c.height = sourseHeight;
            ctx.rect(0, 0, c.width, c.height);
            ctx.fillStyle = 'transparent';//画布填充颜色
            ctx.fill();
       
          
            drawing(c,ctx,sourseWidth,sourseHeight,sourseImgPath,sighX,sighY,sighWidth,sighHeight,sighSrc);
           
        }
        function drawing(c,ctx,sourseWidth,sourseHeight,sourseImgPath,sighX,sighY,sighWidth,sighHeight,sighSrc) {
           
            var bigimg = new Image;
            bigimg.src = sourseImgPath;
            bigimg.onload = function ()
            {
                ctx.drawImage(bigimg, 0, 0, sourseWidth, sourseHeight);
                var img = new Image;
                //img.crossOrigin = 'Anonymous'; //解决跨域
                img.src = sighSrc;
                img.onload = function () {
                    ctx.drawImage(img, sighX, sighY, sighWidth, sighHeight);
                      
                    var src = c.toDataURL("image/png");
                 
                    $('.move_containner').attr("src",src);
                   
                }
               
            }
        }
        function uploadPicture()
        {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&UpType=UploadPicture&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
            if(sReturnValue=='success')
                window.location='Apply_ElectronicFax_Detail.aspx?MainID=<%=MainID %>';
        }
        function upload() {
            var sReturnValue = window.showModalDialog("/Apply/Apply_UploadFile.aspx?MainID=<%=MainID %>&AUpload=" + escape("<%=ApplyN %>") + "&href=" + window.location.href, '<%=MainID %>', "dialogHeight=165px");
              if(sReturnValue=='success')
                  window.location='Apply_ElectronicFax_Detail.aspx?MainID=<%=MainID %>';
        }
        function CancelSign(idc) {
            if(confirm("撤销后，在您之后的所有审批环节都必须重审，确定要撤销审核吗？"))  //20141202：CancelSign
            {
                $("#<%=hdCancelSign.ClientID%>").val(idc);
                        document.getElementById("<%=btnCancelSign.ClientID %>").click();
                    }
        }
 
        function sign(idx) {
                    

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
                $("#btnSignIDx"+idx).attr("disabled",true);

                if($("#rdbYesIDx"+idx).prop("checked"))
                    $("#<%=hdIsAgree.ClientID %>").val("1");
                else if($("#rdbNoIDx"+idx).prop("checked"))
                    $("#<%=hdIsAgree.ClientID %>").val("0");
                else if($("#rdbOtherIDx"+idx).prop("checked"))
                    $("#<%=hdIsAgree.ClientID %>").val("2");
					   
                getSuggestion(idx);
                document.getElementById("<%=btnSign.ClientID %>").click();
            }else
            {
                $("#btnSignIDx"+idx).attr("disabled",false);
            }
        }  
        function getSuggestion(idx)
        {
            if(isIE()){
                $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).text());
            }else
            {
                $("#<%=hdSuggestion.ClientID %>").val($("#txtIDx"+idx).val());
            }
        }
        function isIE() { //ie?
            if (!!window.ActiveXObject || "ActiveXObject" in window)
                return true;
            else
                return false;
        }
        function showOrHideIDx(x) {
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }
        function addRow() {
            i = $("#tbDetail tr").length;
            var html = '<tr id="trDetail' + i + '" class="noborder" style="height: 85px;">'
                +   '<td style="text-align: left; padding-left: 10px;" colspan="4">'
                +   '<div class="flow">'
                +   '部门名称：<input type="text" id="txtDpm' + i + '" style="margin-bottom: 10px;width:250px;" /><br/>'
                +   '<div id="divIDx' + (3*i+1) + '" class="item2">环节1</div>'
                +   '<div id="divTxtIDx' + (3*i+1) + '" class="item2">'
                +   '   <input type="text" id="txtIDxa' + (3*i+1) + '" style="width:190px;" /><input id="hdIDx' + (3*i+1) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '11" checked="checked" name="IsCmodel' + i + '1" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '11">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '10" name="IsCmodel' + i + '1" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '10">单人审批</label>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*i+2) + '" class="item2"><input id="btnIDx' + i + '2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*i+2) + ');" />'
                +   '   <label id="lblIDx' + i + '2" for="btnIDx' + i + '2">环节2</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*i+2) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节2&nbsp;<input type="text" id="txtIDxa' + (3*i+2) + '" style="width:190px;" /><input id="hdIDx' + (3*i+2) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '21" checked="checked" name="IsCmodel' + i + '2" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '21">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '20" name="IsCmodel' + i + '2" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '20">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*i+2) + ')">取消</a>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*i+3) + '" class="item2"><input id="btnIDx' + i + '3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*i+3) + ');" />'
                +   '   <label id="lblIDx' + i + '3" for="btnIDx' + i + '3">环节3</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*i+3) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节3&nbsp;<input type="text" id="txtIDxa' + (3*i+3) + '" style="width:190px;" /><input id="hdIDx' + (3*i+3) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + i + '31" checked="checked" name="IsCmodel' + i + '3" /><label style="color: #0d9405" for="rdoIsCmodel' + i + '31">多人审批</label><input type="radio" id="rdoIsCmodel' + i + '30" name="IsCmodel' + i + '3" /><label style="color: #186ebe" for="rdoIsCmodel' + i + '30">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*i+3) + ')">取消</a>'
                +   '</div></div>'
                +   '</td>'
                + '</tr>'
            $("#trFlag").before(html);
            $("#txtDpm"+ i).autocomplete({source: jJSON});

            for(var il =1;il<=3;il++)
            {
                $("#txtIDxa" + (3*i + il))
                    .bind( "keydown", function( event ) {
                        if ( event.keyCode === $.ui.keyCode.TAB && $( this ).data( "ui-autocomplete" ).menu.active ) {
                            event.preventDefault();
                        }
                    })
                    .autocomplete({
                        minLength: 0,
                        source: function( request, response ) {
                            // delegate back to autocomplete, but extract the last term
                            response( $.ui.autocomplete.filter(jJSONF, extractLast( request.term ) ) );
                        },
                        focus: function() {
                            // prevent value inserted on focus
                            return false;
                        },
                        select: function( event, ui ) {
                            var terms = split( this.value );
                            // remove the current input
                            terms.pop();
                            // add the selected item
                            terms.push( ui.item.value );
                            // add placeholder to get the comma-and-space at the end
                            terms.push( "" );
                            this.value = terms.join( "," );
                            return false;
                        }
                    });
            }
            i++;
             
        }

        function deleteRow() {
            if (i > 1) {
                i--;
                $("#tbDetail tr:eq(" + (i - 1) + ")").remove();
            } else
                alert("不可再删除了。");
        }
        function showIDx(x) {
            $("#divIDx" + x).hide();
            $("#divTxtIDx" + x).show();
            return false;
        }
        function showOrHideIDx(x) {//789
            $("#divIDx" + x).toggle();
            $("#divTxtIDx" + x).toggle();
            return false;
        }
        function addFlow() {
            var html = '<tr id="trAddFlow' + jaf + '" class="noborder" style="height: 85px;">'
                +   '<td style="text-align: left; padding-left: 10px;" colspan="4">'
                +   '<div class="flow">'
                +   '部门名称：<input type="text" id="txtDpm' + jaf + '" style="margin-bottom: 10px;width:250px;border: 1px solid #98b8b5;" /><br/>'
                +   '<div id="divIDx' + (3*jaf+1) + '" class="item2">环节1</div>'
                +   '<div id="divTxtIDx' + (3*jaf+1) + '" class="item2">'
                +   '   <input type="text" id="txtIDxa' + (3*jaf+1) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+1) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + jaf + '11" checked="checked" name="IsCmodel' + jaf + '1" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '11">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '10" name="IsCmodel' + jaf + '1" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '10">单人审批</label>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*jaf+2) + '" class="item2"><input id="btnIDx' + jaf + '2" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*jaf+2) + ');" />'
                +   '   <label id="lblIDx' + jaf + '2" for="btnIDx' + jaf + '2">环节2</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*jaf+2) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节2&nbsp;<input type="text" id="txtIDxa' + (3*jaf+2) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+2) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + jaf + '21" checked="checked" name="IsCmodel' + jaf + '2" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '21">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '20" name="IsCmodel' + jaf + '2" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '20">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*jaf+2) + ')">取消</a>'
                +   '</div>'
                +   '<img src="/Images/forward.png" class="forward"/>'
                +   '<div id="divIDx' + (3*jaf+3) + '" class="item2"><input id="btnIDx' + jaf + '3" class="forward" type="image" src="/Images/add.png" onclick="return showOrHideIDx(' + (3*jaf+3) + ');" />'
                +   '   <label id="lblIDx' + jaf + '3" for="btnIDx' + jaf + '3">环节3</label>'
                +   '</div>'
                +   '<div id="divTxtIDx' + (3*jaf+3) + '" class="item2" style="display:none;">'
                +   '   <br/>&nbsp;环节3&nbsp;<input type="text" id="txtIDxa' + (3*jaf+3) + '" style="width:190px;border: 1px solid #98b8b5;" /><input id="hdIDx' + (3*jaf+3) + '" type="hidden" />'
                +   '   <input type="radio" id="rdoIsCmodel' + jaf + '31" checked="checked" name="IsCmodel' + jaf + '3" /><label style="color: #0d9405" for="rdoIsCmodel' + jaf + '31">多人审批</label><input type="radio" id="rdoIsCmodel' + jaf + '30" name="IsCmodel' + jaf + '3" /><label style="color: #186ebe" for="rdoIsCmodel' + jaf + '30">单人审批</label>'
                +   '       <a style="color: #FF0000" href="javascript:;" onclick="showOrHideIDx(' + (3*jaf+3) + ')">取消</a>'
                +   '</div></div>'
                +   '</td>'
                + '</tr>'
            $("#trAddFlowBefore").before(html);
            $("#txtDpm"+ jaf).autocomplete({source: jJSON});
            for(var il =1;il<=3;il++)
            {
                $("#txtIDxa" + (3*jaf + il))
                    .bind( "keydown", function( event ) {
                        if ( event.keyCode === $.ui.keyCode.TAB && $( this ).data( "ui-autocomplete" ).menu.active ) {
                            event.preventDefault();
                        }
                    })
                    .autocomplete({
                        minLength: 0,
                        source: function( request, response ) {
                            // delegate back to autocomplete, but extract the last term
                            response( $.ui.autocomplete.filter(jJSONF, extractLast( request.term ) ) );
                        },
                        focus: function() {
                            // prevent value inserted on focus
                            return false;
                        },
                        select: function( event, ui ) {
                            var terms = split( this.value );
                            // remove the current input
                            terms.pop();
                            // add the selected item
                            terms.push( ui.item.value );
                            // add placeholder to get the comma-and-space at the end
                            terms.push( "" );
                            this.value = terms.join( "," );
                            return false;
                        }
                    });
            }
            jaf++; 
        }
        function SaveFlow() {
            $("#<%=btnSaveLogisticsFlow.ClientID%>").hide();
              var data = "";
              var flag = true, flag2 = false;
              var content = "";
              for(var k = 200; k < $("#tbAddFlows tr").length + 200-2; k++)
              {
                  if ($.trim($("#txtDpm" + k).val()) == "") {
                      alert("您所添加的部门名称不可为空。");
                      $("#txtDpm" + k).focus();
                      return false;
                  }
                  if ($.trim($("#txtDpm" + k).val()) == "总经办") {
                      alert("总经办无审批权限，请填写“董事总经理”。");
                      $("#txtDpm" + k).focus();
                      return false;
                  }
              }
              for(var y = 3*200+1; y <= $("[id^=txtIDxa]").size() + 3*200-3; y++)
              {
                  if($("#txtIDxa" + y).parent().css("display")!="none") 
                  {
                      if($.trim($("#txtIDxa" + y).val())=="")
                      {
                          alert("您所添加的审批环节不可为空！");
                          $("#txtIDxa" + y).focus();
                          return false;
                      }
                      content+=y+":"+$("#txtIDxa" + y).val()+";";
                  }
              }
              $("#tbAddFlows tr").each(function(n) {
                  if (n != 0 && n != $("#tbAddFlows tr").size() - 1) {
                      data += $.trim($("#txtDpm" + (n+200-1)).val()) 
                          + "&&" + (3*200+(3*n-2)).toString()
                          + "&&1"
                          + "&&" + ($("#rdoIsCmodel" + (n+200-1) + "11").prop('checked')?"1":"0")
                          + "&&1||"
                          + $.trim($("#txtDpm" + (n+200-1)).val()) 
                          + "&&" + (3*200+(3*n-2)+1).toString()
                          + "&&2"
                          + "&&" + ($("#rdoIsCmodel" + (n+200-1) + "21").prop('checked')?"1":"0")
                          + "&&" + ($("#txtIDxa" + (3*200+(3*n-2) + 1)).parent().css("display")!="none"?"1":"0") + "||"
                          + $.trim($("#txtDpm" + (n+200-1)).val()) 
                          + "&&" + (3*200+(3*n-2)+2).toString()
                          + "&&3"
                          + "&&" + ($("#rdoIsCmodel" + (n+200-1) + "31").prop('checked')?"1":"0")
                          + "&&" + ($("#txtIDxa" + (3*200+(3*n-2) + 2)).parent().css("display")!="none"?"1":"0") + "||";
                  }
              });
              if(flag)
              {
                  content = content.substr(0,content.length-1);
                  $.ajax({
                      url: "/Ajax/Flow_Handler.ashx",
                      type: "post",
                      dataType: "text",
                      async: false,
                      cache: false,
                      data: 'action=SaveCommonFlowLogistics2&id=<%=EmployeeID %>&name=<%=EmployeeName %>&purview=<%=Purview %>&mainid=<%=MainID %>&content=' + content+'&deleteidxs=<%=SkyPlay %>',
                    success: function(info) {
                        if (info == "success") {
                            flag2 = true;
                            flag = true;
                            data = data.substr(0, data.length - 2);
                            $("#<%=hdLogisticsFlow.ClientID %>").val(data);
                            return true;
                        }
                        else if (info == "NoPower"){
                            flag2 = false;
                            return false;
                        }
                        else if (info == "Conpleted"){
                            alert("该表已审批完毕，不能再修改了！");
                            flag2 = false;
                            return false;
                        }
                        else
                        {
                            alert("保存失败，审批流程中有部分人名不存在或不具备审批资格，\\n请修改，如依然失败，请联系资讯科技部！\n错误代码："+ info);
                            flag2 = false;
                            return false;
                        }
                    }
                })
                if (flag2) {
                    return true;
                }
                else{
                    //$("#<%=btnSaveLogisticsFlow.ClientID%>").removeAttr("disabled");
                    $("#<%=btnSaveLogisticsFlow.ClientID%>").show();
                    return false;
                }
            }
        }//987		
        function DeleteT() { //20141231：M_DeleteC
            $("#btnADelete").hide();
            var url = "/Apply/Apply_DeleteDialog.aspx?mainID=<%=MainID %>&url=Nothing&apply=" + escape("<%=ApplyN %>") +"&href="+window.location.href;
            var sReturnValue = window.showModalDialog(url, '<%=MainID %>', "dialogHeight=260px;dialogWidth=665px;");
            if(sReturnValue=='deleted')
                window.location='/Apply/Apply_Search.aspx';
            else
                window.location.href=window.location.href;
        }
        function deleteFlow() {
            if (jaf > 200) {
                jaf--;
                $("#tbAddFlows tr:eq(" + (jaf - 200) + ")").remove();
                //$("#tbAround tr[id*=trDetail]").remove();
                if (jaf == 200) {
                    $('#trAddFlowBefore').hide();
                }
            } else{
                $('#trAddFlowBefore').hide();
                alert("不可再删除了。");
            }
        }
        function check() {
            //var bigImage= $('.move_containner').attr("src")
            //$.ajax({
            //    type: 'POST',
            //    url: 'Apply_ElectronicFax_Detail.aspx',
            //    data:{"BigImage":bigImage},
            //    dataType:"Text",
            //    success: function (msg) {
                   
            //    }
            //});
            if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                alert("部门/分行不可为空！");
                $("#<%=txtDepartment.ClientID %>").focus();
                return false;
            }
            var data = "";
            var flag = true, flag2 = true;
            $("#tbDetail tr").each(function(n) {
                if (n != 0 && n != $("#tbDetail tr").size()) {
                    if ($.trim($("#txtDpm" + n).val()) == "总经办") {
                        alert("第" + n + "个后勤审批流程的部门不能为总经办，请填写“董事总经理”。");
                        $("#txtDpm" + n).focus();
                        flag = false;
                    }
                  
                    if ($.trim($("#txtDpm" + n).val()) == "") {
                        alert("第" + n + "个后勤审批流程的部门名称必须填写。");
                        $("#txtDpm" + n).focus();
                        flag = false;
                    }
                    else if ($.trim($("#txtIDxa" + (3*n + 1)).val()) == "") {
                        alert("第" + n + "个后勤审批流程的第一环节必须填写。");
                        $("#txtIDxa" + (3*n + 1)).focus();
                        flag = false;
                    }
                    else if($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none" && $.trim($("#txtIDxa" + (3*n + 2)).val()) == "") 
                    {
                        alert("第" + n + "个后勤审批流程的第二环节必须填写。");
                        $("#txtIDxa" + (3*n + 2)).focus();
                        flag = false;
                    }
                    else if($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none" && $.trim($("#txtIDxa" + (3*n + 3)).val()) == "") 
                    {
                        alert("第" + n + "个后勤审批流程的第三环节必须填写。");
                        $("#txtIDxa" + (3*n + 3)).focus();
                        flag = false;
                    }
                    else
                        data += $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+1).toString()
                            + "&&1"
                            + "&&" + ($("#rdoIsCmodel" + n + "11").prop('checked')?"1":"0")
                            + "&&1||"
                            + $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+2).toString()
                            + "&&2"
                            + "&&" + ($("#rdoIsCmodel" + n + "21").prop('checked')?"1":"0")
                            + "&&" + ($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none"?"1":"0") + "||"
                            + $.trim($("#txtDpm" + n).val()) 
                            + "&&" + (3*n+3).toString()
                            + "&&3"
                            + "&&" + ($("#rdoIsCmodel" + n + "31").prop('checked')?"1":"0")
                            + "&&" + ($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none"?"1":"0") + "||";
                }
            });
            content = "";
            for(var y = 1; y <= $("[id^=txtIDxa]").size(); y++)
            {
                if($("#txtIDxa"+y).parent().css("display")!="none") 
                {
                    if(y == 3 && $.trim($("#txtIDxa"+y).val())=="" && isNewApply)
                    {
                        alert("第3个审批环节不可为空！");
                        $("#txtIDxa"+y).focus();
                        flag = false;
                        return false;
                    }
                    else if(y == 3 && $.trim($("#txtIDxa"+y).val())=="" && !isNewApply)
                    {
                        deleteidxs += y.toString() + "|";
                        continue;
                    }
                    
                    if(y <= 2 && $.trim($("#txtIDxa"+y).val())=="")
                    {
                        deleteidxs += y.toString() + "|";
                        continue;
                    }
                    content+=y+":"+$("#txtIDxa"+y).val()+";";
                }
                deleteidxs += y.toString() + "|";
            }
            content = content.substr(0,content.length-1);
            if(($.trim($("#txtIDxa1").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa1").val())
                     ||($.trim($("#txtIDxa2").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa2").val())
                ||($.trim($("#txtIDxa3").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa3").val())
                )
            flga = 1;

        $("#<%=hdcontent.ClientID %>").val(content);
            $("#<%=hdflga.ClientID %>").val(flga);
            $("#<%=hddeleteidxs.ClientID %>").val(deleteidxs);

            if(flag)
            {
                data = data.substr(0, data.length - 2);
                $("#<%=hdDetail.ClientID %>").val(data);
                return true;
               
            }
            else
                return false;
        }
        //签名内容绑定
        function FlowSignInit() {
            cFlowSignInit("<%=this.hidSignFlowsJson.ClientID%>", $("#<%=this.lblApply.ClientID%>").val(), "<%=EmployeeName%>", "<%=EmployeeID%>");   //common_new.js
        }
        function IsFileVaule()
        { 
            if( $("#<%=txtFilePath.ClientID%>").val()  == null || $("#<%=txtFilePath.ClientID%>").val() ==""){
                alert("请选择浏览图片");
                return false;
            }else{  
                var fileName=document.getElementById("ctl00_ContentPlaceHolder1_txtFilePath").value;  
                var suffixIndex=fileName.lastIndexOf(".");  
                var suffix=fileName.substring(suffixIndex+1).toUpperCase();  
                if(suffix!="JPG"&&suffix!="JPEG"){  
                    alert("请上传图片（格式JPG、JPEG）!");  
                    return false;
                }  
            }  

        }
    </script>
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="text-align: center; width: 840px; margin: 0 auto;" id="FaxBody1">
        <input type="hidden" id="hdEmail" runat="server" />
         <div class="noprint">
        <%=SbFlow.ToString() %>
        <asp:Button runat="server" ID="btnEditFlow2" Text="编辑流程" OnClientClick="if(confirm('修改后，所修改环节的后续流程都必须重审，确定要修改吗？'))return true;else return false;" OnClick="btnEditFlow_DoClick" Visible="False" />
        </div>
        <div style='text-align: center'>
            <h1>广东中原地产代理有限公司</h1>
            <h1>电子传真申请表</h1>
            <input type="button" id="btnADelete" value="是否同意删除？" onclick="DeleteT();" style="display: none;" />
            <div id="snum" style="width: 640px; margin: 0 auto;"><span style="float: right;" class="file_number">文档编码(自动生成)：<%=SerialNumber %></span></div>
             <table id="tbAround" width="100%">
                 <tr>
                      <td class="auto-style4">发文部门</td>
                      <td class="tl PL10">
                        <asp:TextBox ID="txtDepartment" runat="server" Width="180px"></asp:TextBox>&nbsp;-&nbsp;<input type="hidden" id="hdDepartmentID" runat="server" /><asp:Label ID="lblApply" runat="server"></asp:Label>
                       <%--<input type="button" id="btnuploadPicture" value="上传图片" onclick="uploadPicture();" style="margin-left: 5px;" />--%>
                     <span id="spanUpload" style="display: none";>
                           <input type="file" id="txtFilePath"  runat="server" accept="image/gif,image/jpeg,image/jpg,image/png,image/svg,image/bmp"/>
                          <%--<asp:LinkButton ID="sd" runat="server" CssClass="linkbutton" OnClick="lbtnUpload_Click">上传</asp:LinkButton>--%>
                             <%--<input type="button" id="btn2Upload" value="上传附件" style="margin-left: 5px;" runat="server" OnClick="lbtnUpload_Click"/>--%>
                          <asp:Button runat="server" ID="btn2Upload" Text="上传附件" OnClick="lbtnUpload_Click" style="margin-left: 5px;"  OnClientClick="return IsFileVaule()" /></span>
                            </td>
                       <td class="auto-style5">发文日期</td>
                     <td class="tl PL10"><asp:Label ID="lblApplyDate" runat="server"></asp:Label></td>
                 </tr>
                 <!--打印正文开始-->
                 <tr>
                       <!--startprint-->
                     <td colspan="4">
                         <div id="FaxBody"  style="padding-left: 0px; text-align: center;width:751px; position:relative;">
                          <div style=" overflow-y:hidden;overflow-x:hidden;" class="containner_div">
                              <img class="move_containner" style="height:auto; width:100%" />  
                           </div>
                             <div id="SignPic"></div>
                         </div>
                      </td> <!--endprint-->
                 </tr>
                 <!--打印正文结束-->
                
                  <tr>
                      <td colspan="4">
                         <%--<div id="div1">将图片拖拽到此区域</div>--%>
                          <div id="div1"></div>
                         <input type="hidden" runat="server" id="hiBigPicture"/>
                         <input type="hidden" runat="server" id="hiLastX"/>
                         <input type="hidden" runat="server" id="hiLastY"/>
                      </td>
                  </tr>
                 <tr>
                     <th colspan="4" style="font-size: 15px">申请部门审批流程</th>
                 </tr>
                 <tr id="trM0" style="display: none;">
                       <td colspan="4" style="height: 80px; text-align: left; padding-left: 10px; line-height: 25px;">
                        <div class="flow">
                            申请人：<input type="text" id="txtIDxa1" style="width: 539px;" /><br />
                            申请部门主管：<input type="text" id="txtIDxa2" style="width: 485px;" /><br />
                            申请部门负责人：<input type="text" id="txtIDxa3" style="width: 467px;" />
                             <asp:HiddenField ID="hdFlowApply" runat="server" />
                             <asp:HiddenField ID="hidSignFlowsJson" runat="server" />
                             <asp:HiddenField ID="hiAuditJpg" runat="server" />
                             <asp:HiddenField ID="hiSignLeftTopListJson" runat="server" />
                        </div>
                    </td>
                </tr>
                 <tr>
                     <td colspan="4">
                         <table id="tbflows" class="tbflows" cellpadding="0" cellspacing="0" style="width: 100%">
                             <tr id="trManager1" class="noborder" style="height: 85px;display: none;" idx="1">
                                 <td style="width: 130px">申请人</td>
                                 <td class="tl PL10">
                                     <div class="fieldradio">
                                         <input type="radio" value="1" name="agree1" /><label class="l signyes">同意</label>
                                         <input type="radio" value="0" name="agree1" /><label class="l signno">不同意</label>
                                         <input type="radio" value="2" name="agree1" /><label class="l signyes">其他意见</label>
                                     </div>
                                     <div class="fieldtext">
                                         <textarea rows="3"></textarea>
                                     </div>
                                     <div class="fieldsign"></div>
                                     <div class="fieldbtn">
                                         <input type="button" class="signbtn" value="确认" onclick="sign(this)" />
                                     </div>
                                     <div class="fielddate">日期：<span class="signdate">_________</span></div>
                                 </td>
                             </tr>
                             <tr id="trManager2" class="noborder" style="height: 85px;display: none;" idx="2">
                                 <td class="auto-style2">部门主管：</td>
                                 <td class="tl PL10">
                                     <div class="fieldradio">
                                         <input type="radio" value="1" name="agree2" /><label class="l signyes">同意</label>
                                         <input type="radio" value="0" name="agree2" /><label class="l signno">不同意</label>
                                         <input type="radio" value="2" name="agree2" /><label class="l signyes">其他意见</label>
                                     </div>
                                     <div class="fieldtext">
                                         <textarea rows="3"></textarea>
                                     </div>
                                     <div class="fieldsign"></div>
                                     <div class="fieldbtn">
                                         <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                                     </div>
                                     <div class="fielddate">日期：<span class="signdate">_________</span></div>
                                 </td>
                             </tr>
                             <tr id="trManager3" class="noborder" style="height: 85px;display: none;" idx="3">
                                 <td class="auto-style2">部门负责人：</td>
                                 <td class="tl PL10">
                                     <div class="fieldradio">
                                         <input type="radio" value="1" name="agree3" /><label class="l signyes">同意</label>
                                         <input type="radio" value="0" name="agree3" /><label class="l signno">不同意</label>
                                         <input type="radio" value="2" name="agree3" /><label class="l signyes">其他意见</label>
                                     </div>
                                     <div class="fieldtext">
                                         <textarea rows="3"></textarea>
                                     </div>
                                     <div class="fieldsign"></div>
                                     <div class="fieldbtn">
                                         <input type="button" class="signbtn" value="签名" onclick="sign(this)" />
                                     </div>
                                     <div class="fielddate">日期：<span class="signdate">_________</span></div>
                                 </td>
                             </tr>
                             <tr id="tho">
                                 <th colspan="4" style="font-size: 15px">其它部门审批流程</th>
                             </tr>
                             <tr id="add1F" style="display: none">
                                 <td colspan="4">
                                     <table id="tbAddFlows" class='sample tc' width='100%'>

                                         <tr id="trAddFlowBefore" style="display: none;">
                                             <td>
                                                 <asp:Button ID="btnSaveLogisticsFlow" runat="server" Text="" OnClientClick="return deleteFlow();" OnClick="btnSaveLogisticsFlow_Click" />
                                             </td>
                                         </tr>
                                         <tr>
                                             <td>
                                                 <a id="afa" href="javascript:void(0)" style="display: none;" onclick="$('#trAddFlowBefore').show();$('#trM1').remove();addFlow();">增加审批环节</a>
                                                 <a id="dfd" href="javascript:void(0)" style="display: none;" onclick="deleteFlow()">删除添加的审批环节</a><br />
                                             </td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr id="trM1" style="display: none;">
                                 <td class="tl PL10 PR10" colspan="4">
                                     <table id="tbDetail" class='sample tc' width='100%'>
                                         <%=SbHtml.ToString()%>
                                         <tr id="trFlag">
                                             <td></td>
                                         </tr>
                                     </table>
                                     <input type="button" id="btnAddFlow" value="添加新行" onclick="addRow();" style="float: left; display: none" />
                                     <input type="button" id="btnDeleteFlow" value="删除一行" onclick="deleteRow();" style="float: left; display: none; margin-left: 10px;" />
                                 </td>
                             </tr>
                             <%=SbHtml2.ToString()%>
                         </table>
                     </td>
                 </tr>
             </table>
        </div>
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
            </asp:GridView>
            <div id="PageBottom">
                <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" OnClientClick="return check();" Visible="False" />
                <asp:Button runat="server" ID="btnSAlterC" Text="修改" OnClientClick="return ChangeConfirm();" OnClick="btnSAlterC_Click" Visible="False" />
                <input type="button" id="btnUpload" value="上传附件..." onclick="upload();" style="margin-left: 5px; display: none;" />
                <asp:Button ID="btnDownload" runat="server" Text="下载选中附件" OnClick="btnDownload_Click" OnClientClick="return checkChecked();" Style="margin-left: 5px;" Visible="false" />
                <asp:Button runat="server" ID="btnSignSave" Text="标注已留档" OnClick="btnSignSave_Click" Visible="false" />
                <input type="button" id="btnPrint" value="打印" onclick="myPrint('打印正文开始', '打印正文结束');" style="display: none;" />
                <asp:Button ID="btnSPDF" runat="server" Text="另存为PDF" OnClick="btnSPDF_Click" />
                <asp:Button runat="server" ID="btnBack" Text="返回" OnClick="btnBack_Click" />
                <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click" Style="display: none;" />
                <asp:HiddenField ID="hdIsAgree" runat="server" />
                <asp:HiddenField ID="hdSuggestion" runat="server" />

                 <input type="hidden" id="hdDetail" runat="server" />
        <input type="hidden" id="hdLogisticsFlow" runat="server" />
        <asp:HiddenField ID="hdCancelSign" runat="server" />
        <asp:HiddenField ID="hdChangeChecking" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />

            <asp:HiddenField ID="hdcontent" runat="server" />
            <asp:HiddenField ID="hdflga" runat="server" />
            <asp:HiddenField ID="hddeleteidxs" runat="server" />

        <asp:Button ID="btnCancelSign" runat="server" OnClick="btnCancelSign_Click"  />
        <asp:HiddenField ID="hdShouldJump" runat="server" />
       <%-- <asp:Button ID="btnShouldJump" runat="server" OnClick="btnShouldJump_Click"  />
        <asp:Button ID="btnWillEndC" runat="server" OnClick="btnWillEndC_Click" />
        <asp:LinkButton ID="lbtnaAddN" runat="server" OnClick="lbtnAddN_Click" >添加审批</asp:LinkButton>
        <asp:LinkButton ID="lbtnaDelN" runat="server" OnClick="lbtnDelN_Click">删除审批</asp:LinkButton>--%>
             </div>
        </div>
    </div>
    <script type="text/javascript">AddOtherAgree();</script>
    <%=SbJs.ToString() %>
     <script type="text/javascript">
      autoTextarea(document.getElementById("txtIDx1"));
        autoTextarea(document.getElementById("txtIDx2"));
        autoTextarea(document.getElementById("txtIDx3"));
        FlowSignInit();
        //window.onload = function () {
        //    var div1 = document.getElementById("div1");
        //    div1.ondragenter = function () {
        //        this.innerHTML = "可以释放了";

        //    }
        //    div1.ondragover = function (ev) {
        //        ev.preventDefault();
        //    }
        //    div1.ondragleave = function () {
        //        this.innerHTML = "将文件拖拽到此区域";
        //    }
        //    div1.ondrop = function (ev) {
        //        ev.preventDefault();
        //        var files = ev.dataTransfer.files;
        //        var fd = new FileReader();
        //        if (files[0].type.indexOf('image') != -1) {
        //            fd.readAsDataURL(files[0]);
        //            var ul1 = document.getElementById("ul1");
        //            fd.onload = function () {
        //                var li1 = document.createElement("li");
        //                var img1 = document.createElement("img");
        //                img1.src = this.result;
        //                $('.move_containner').attr("src", img1.src);
                
        //            }
        //        } else { alert("请选择图片上传"); }
        //    }

        //}
        function ChangeConfirm(){
           
            if(confirm('请注意，如果你修改审批流程，该流程的后续环节都需要重审；\r\n确定要修改吗？'))
            {
                if($('h1').attr('name') != 'DeleteD')
                {
                   
                    if($.trim($("#<%=txtDepartment.ClientID %>").val())=="") {
                        alert("部门/分行不可为空！");
                        $("#<%=txtDepartment.ClientID %>").focus();
                        return false;
                    }
                    var data = "";
                    var flag = true, flag2 = true;
                    $("#tbDetail tr").each(function(n) {
                        if (n != 0 && n != $("#tbDetail tr").size()) {
                            if ($.trim($("#txtDpm" + n).val()) == "总经办") {
                                alert("第" + n + "个后勤审批流程的部门不能为总经办，请填写“董事总经理”。");
                                $("#txtDpm" + n).focus();
                                flag = false;
                            }
                  
                            if ($.trim($("#txtDpm" + n).val()) == "") {
                                alert("第" + n + "个后勤审批流程的部门名称必须填写。");
                                $("#txtDpm" + n).focus();
                                flag = false;
                            }
                            else if ($.trim($("#txtIDxa" + (3*n + 1)).val()) == "") {
                                alert("第" + n + "个后勤审批流程的第一环节必须填写。");
                                $("#txtIDxa" + (3*n + 1)).focus();
                                flag = false;
                            }
                            else if($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none" && $.trim($("#txtIDxa" + (3*n + 2)).val()) == "") 
                            {
                                alert("第" + n + "个后勤审批流程的第二环节必须填写。");
                                $("#txtIDxa" + (3*n + 2)).focus();
                                flag = false;
                            }
                            else if($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none" && $.trim($("#txtIDxa" + (3*n + 3)).val()) == "") 
                            {
                                alert("第" + n + "个后勤审批流程的第三环节必须填写。");
                                $("#txtIDxa" + (3*n + 3)).focus();
                                flag = false;
                            }
                            else
                                data += $.trim($("#txtDpm" + n).val()) 
                                    + "&&" + (3*n+1).toString()
                                    + "&&1"
                                    + "&&" + ($("#rdoIsCmodel" + n + "11").prop('checked')?"1":"0")
                                    + "&&1||"
                                    + $.trim($("#txtDpm" + n).val()) 
                                    + "&&" + (3*n+2).toString()
                                    + "&&2"
                                    + "&&" + ($("#rdoIsCmodel" + n + "21").prop('checked')?"1":"0")
                                    + "&&" + ($("#txtIDxa" + (3*n + 2)).parent().css("display")!="none"?"1":"0") + "||"
                                    + $.trim($("#txtDpm" + n).val()) 
                                    + "&&" + (3*n+3).toString()
                                    + "&&3"
                                    + "&&" + ($("#rdoIsCmodel" + n + "31").prop('checked')?"1":"0")
                                    + "&&" + ($("#txtIDxa" + (3*n + 3)).parent().css("display")!="none"?"1":"0") + "||";
                        }
                    });
                    content = "";
                    for(var y = 1; y <= $("[id^=txtIDxa]").size(); y++)
                    {
                        if($("#txtIDxa"+y).parent().css("display")!="none") 
                        {
                            if(y == 3 && $.trim($("#txtIDxa"+y).val())=="" && isNewApply)
                            {
                                alert("第3个审批环节不可为空！");
                                $("#txtIDxa"+y).focus();
                                flag = false;
                                return false;
                            }
                            else if(y == 3 && $.trim($("#txtIDxa"+y).val())=="" && !isNewApply)
                            {
                                deleteidxs += y.toString() + "|";
                                continue;
                            }
                    
                            if(y <= 2 && $.trim($("#txtIDxa"+y).val())=="")
                            {
                                deleteidxs += y.toString() + "|";
                                continue;
                            }
                            content+=y+":"+$("#txtIDxa"+y).val()+";";
                        }
                        deleteidxs += y.toString() + "|";
                    }
                    content = content.substr(0,content.length-1);
                    if(($.trim($("#txtIDxa1").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa1").val())
                     ||($.trim($("#txtIDxa2").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa2").val())
                ||($.trim($("#txtIDxa3").val())!="" && $("#<%=hdFlowApply.ClientID %>").val() != $("#txtIDxa3").val())
                )
                flga = 1;

            $("#<%=hdcontent.ClientID %>").val(content);
                    $("#<%=hdflga.ClientID %>").val(flga);
                    $("#<%=hddeleteidxs.ClientID %>").val(deleteidxs);

                    if(flag)
                    {
                        data = data.substr(0, data.length - 2);
                        $("#<%=hdDetail.ClientID %>").val(data);
                        return true;
               
                    }
                    else
                        return false;
                }
                else return alert('该表即将被删除，暂停修改操作');
            }
            else {
                return false;
            }
           
        }

     </script>
 </asp:Content>
