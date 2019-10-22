using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using System.IO;

using DataAccess.Operate;
using DataEntity;

using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;

using System.Diagnostics; //M_PDF
using System.Web;

public partial class Apply_ChangeData_Apply_ChangeData_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public string ApplyN;
    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#divUploadDetailed\").show();";

    //public string[] sHRTree = null;

    #endregion

    #region 页面加载及初始化

    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        SbJson.Append("[]");

        //MainID = GetQueryString("MainID");
        string UrlMainID = GetQueryString("MainID");

        SerialNumber = "";

        InitPage();

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["htmltopdf"] == "Yes")  //M_PDF
                {
                    SbJs.Append("<script type=\"text/javascript\">$(\"div .flow\").hide();$(\"#PageBottom\").hide();</script>");
                    tpdf = true;
                }
            }
            catch
            { }
            try
            {
                if (Session["FLG_ReWrite32"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite32"] = null;
                }
            }
            catch
            {
            }
            if (UrlMainID != "")
            {
                MainID = UrlMainID;
                LoadPage();
            }
            else
                NewPage();

        }
        else
            GetAllDepartment();
    }

    /// <summary>
    /// 新页面
    /// </summary>
    public void NewPage()
    {
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        DrawDetailTable(1);
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {

    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
        DA_OfficeAutomation_Document_ChangeData_Detail_Inherit da_OfficeAutomation_Document_ChangeData_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_ChangeData_Detail_Inherit();

        string flowState;
        try
        {
            flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
        }
        catch
        {
            Alert(CommonConst.MSG_URL_DISABLE);
            RunJS("window.location='/Apply/Apply_Search.aspx'");
            return;
        }

        SbJs.Append("<script type=\"text/javascript\">");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
        {
            SbJs.Append("$(\"#btnPrint\").show();");
            //如果拥有权限则显示标注已坏账按钮
            //if (Purview.Contains("OA_Special_002") || EmployeeID == "16945")
            //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
            if (Purview.Contains("OA_Special_002") || EmployeeID == "43781")
                btnSign1Bad.Visible = true;
        }
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ChangeData_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ChangeData_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_ChangeData_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_ChangeData_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_ChangeData_Department"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ChangeData_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtBuilding.Text = dr["OfficeAutomation_Document_ChangeData_Building"].ToString();
        txtReplyPhone.Text = dr["OfficeAutomation_Document_ChangeData_ReplyPhone"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_ChangeData_Reason"].ToString();

        try
        {
            txtReasonDay.Text = DateTime.Parse(dr["OfficeAutomation_Document_ChangeData_ReasonDay"].ToString()).ToString("yyyy-MM-dd");
        }
        catch
        {
            txtReasonDay.Text = dr["OfficeAutomation_Document_ChangeData_ReasonDay"].ToString();
        }
        txtReportNo.Text = dr["OfficeAutomation_Document_ChangeData_ReportNo"].ToString();
        txtDataAddress.Text = dr["OfficeAutomation_Document_ChangeData_DataAddress"].ToString();
        txtNewDataAddress.Text = dr["OfficeAutomation_Document_ChangeData_NewDataAddress"].ToString();
        txtOldCustomerName.Text = dr["OfficeAutomation_Document_ChangeData_OldCustomerName"].ToString();
        txtNewCustomerName.Text = dr["OfficeAutomation_Document_ChangeData_NewCustomerName"].ToString();
        txtOldBranch.Text = dr["OfficeAutomation_Document_ChangeData_OldBranch"].ToString();
        txtNewBranch.Text = dr["OfficeAutomation_Document_ChangeData_NewBranch"].ToString();
        txtOthers.Text = dr["OfficeAutomation_Document_ChangeData_Others"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        ds = da_OfficeAutomation_Document_ChangeData_Detail_Inherit.SelectByID(ID);
        int detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable(1);
        else
        {
            DrawDetailTable(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;

                try
                {
                    SbJs.Append("$('#txtCountOffTime" + i + "').val('" + DateTime.Parse(dr["OfficeAutomation_Document_ChangeData_Detail_CountOffTime"].ToString()).ToString("yyyy-MM-dd") + "');");
                }
                catch
                {
                    SbJs.Append("$('#txtCountOffTime" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_CountOffTime"] + "');");
                }
                SbJs.Append("$('#txtDetail_pNo" + i + "').html('" + dr["OfficeAutomation_Document_ChangeData_Detail_pNo"] + "');");
                SbJs.Append("$('#txtProjectName" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_ProjectName"] + "');");
                SbJs.Append("$('#txtCname" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_Cname"] + "');");
                SbJs.Append("$('#txtDealNo" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_DealNo"] + "');");
                SbJs.Append("$('#txtOtherDataAddress" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress"] + "');");
                SbJs.Append("$('#txtChangeSituation" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_ChangeSituation"] + "');");
                SbJs.Append("$('#txtChangeCname" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_ChangeCname"] + "');");
                SbJs.Append("$('#txtType" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_Type"] + "');");
                SbJs.Append("$('#txtChangeReason" + i + "').val('" + dr["OfficeAutomation_Document_ChangeData_Detail_ChangeReason"] + "');");
            }
        }

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;
        if (isApplicant)
        {
            //try
            //{
            //    if (drc[7]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
            //        SbJs.Append("$(\"#btnUpload\").hide();");
            //    else
            //        SbJs.Append("$(\"#btnUpload\").show();");
            //}
            //catch
            //{
            //SbJs.Append("$(\"#btnUpload\").show();");
            //}
            if (flowState == "1")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }
        }
        //else
        //{
        //    string names = "acc08,13545,34046,27997,24962,16945,16945,24517,3575,20208,6601,5585,1909"; //20141127++++：指定的人可导出PDF
        //    string[] employnames;
        //    employnames = names.Split(',');
        //    for (int i = 0; i < employnames.Length; i++)
        //    {
        //        if (EmployeeID.Contains(employnames[i]))
        //        {
        //            btnSPDF.Visible = true;
        //        }
        //    }
        //}

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        if ((EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "34498" || EmployeeID == "20208" || EmployeeID == "43781") && flowState == "3")
            btnSignSave.Visible = true;

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("</script>");
                GetAllDepartment();
                //txtDepartment.Text = "";
                btnSPDF.Visible = false; //M_PDF
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                flowState = "1";
                btnSAlterC.Visible = false;
                btnSave.Visible = true;
                IsNewApply = true;
                MainID = Guid.NewGuid().ToString();
                return;
            }
        }
        catch
        {
            if (isApplicant)
                btnReWrite.Visible = true; //*-+
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        //自定义控件赋值
        var flowshowlist = da_OfficeAutomation_Flow_Inherit.GetFlowShowList(ds);
        this.FlowShow1.FlowShowList = flowshowlist;

        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                flag2 = false;
                if (curemp.Contains(EmployeeName))
                {
                    switch (curidx)
                    {
                        case "10":
                            ckbAddIDx10.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region 显示签名人姓名，签名图片，或签名按钮

            string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:0px; float:left;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                foreach (string s in auditorIDs)
                {
                    if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                    {
                        SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                    }
                    SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" />");
                }
                SbJs.Append("');");

                //如果是否同意为0则不同意按钮选中，为2则其他意见按钮选中，为真或空，则同意按钮选中。
                if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                    SbJs.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");
                else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                    SbJs.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");
                else
                    SbJs.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");

                if (string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').hide();");
                else
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
            }
            else
            {
                if (auditorIDs.Length > 0 && auditorIDs[0] != "")
                {
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:20px; float:left;\">"
                                       + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" />");
                    }
                    SbJs.Append("');");

                    //如果是否同意为1，则同意按钮选中，为0则不同意按钮选中，为2则其他意见按钮选中。
                    if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "1")
                        SbJs.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                        SbJs.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                        SbJs.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");

                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");
                    SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
                }

                if (!string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                if (flag && da_OfficeAutomation_Agent_Inherit.IsHaveSignPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(),
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID))
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').show();");

                flag = false;
            }

            #endregion
        }

        ////如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        //if (flag3)
        //    SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();$('#trGeneralManager').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            this.FlowShow1.ShowEditBtn = true;
        if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;

        ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID); //20141231：M_DeleteC
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByMID(MainID);
            SbJs.Append("$('#btnADelete').before('<div id=\"SummaryOfDelete_Red\" style=\"color: red; font-size: large; font-weight: bold\">（该表即将被删除）</div>');$('h1').css('color','red');");
            string[] employnames;
            string employname;
            foreach (DataRow dr2 in ds.Tables[0].Rows)
            {
                employname = dr2["OfficeAutomation_DeletedFlow_AuditorID"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    if (employnames[i2] == EmployeeID)
                        SbJs.Append("$('#btnADelete').show();$('#SummaryOfDelete_Red').hide();");
                }
            }
            #region 显示删除流程示意图
            FlowShow1.Visible = false;
            SbFlow.Length = 0;//清空审批流程
            FlowCommonMethod flowCom = new FlowCommonMethod();
            SbFlow.Append(flowCom.ShowDelFlow(MainID));
            btnEditFlow2.Visible = false;
            #endregion
        }
        else //20150225：M_DeleteC 不同意时显示最后确认时间
        {
            DA_OfficeAutomation_Document_LastSure_Inherit da_OfficeAutomation_Document_LastSure_Inherit = new DA_OfficeAutomation_Document_LastSure_Inherit();
            ds = da_OfficeAutomation_Document_LastSure_Inherit.SelectByMid(MainID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SbJs.Append("$('#snum').prepend('<span id=\"SummaryOfDelete_Green\" style=\"color: green; float:left; font-weight: bold\">区域最后确认时间：" + ds.Tables[0].Rows[0]["OfficeAutomation_Document_LastSure_Time"].ToString() + "</span>');");
            }
        }

        #endregion

        SbJs.Append("$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });");
        SbJs.Append("</script>");

        LoadAttach();
    }

    /// <summary>
    /// 加载附件列表
    /// </summary>
    private void LoadAttach()
    {
        //获取该单附件列表
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

        gvAttach.DataSource = dsAttach;
        gvAttach.DataBind();

        //如果该单有附件，则下载按钮显示
        btnDownload.Visible = (dsAttach != null && dsAttach.Tables[0] != null && dsAttach.Tables[0].Rows.Count > 0);
    }

    public void DrawDetailTable(int n)
    {
        DataSet dsApplyDetail = new DataSet();
        DataSet dsApplyType = new DataSet();

        DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
        dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(1);
        DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
        dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();

        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id=\"trDetail" + i + "\">");
            //SbHtml.Append("<td class=\"tl PL10\" style=\"line-height: 30px\">");
            //SbHtml.Append("报数时间<input type=\"text\" id=\"txtCountOffTime" + i + "\" style=\"width:200px\"/>");
            //SbHtml.Append("成交编号<input type=\"text\" id=\"txtDealNo" + i + "\" style=\"width:245px\"/><br />");
            //SbHtml.Append("物业地址<input type=\"text\" id=\"txtOtherDataAddress" + i + "\" style=\"width:500px;\"/><br />");
            //SbHtml.Append("<span style=\"vertical-align: top;margin-top: 10px;\">变更情况</span><textarea id=\"txtChangeSituation" + i + "\" rows=\"3\" style=\"width: 500px; overflow: auto;\"></textarea><br />");
            //SbHtml.Append("<span style=\"vertical-align: top;margin-top: 10px;\">变更事由</span><textarea id=\"txtChangeReason" + i + "\" rows=\"3\" style=\"width: 500px;margin-top: 8px; overflow: auto;\"></textarea><br /><br />");
            //SbHtml.Append("</td>");
            SbHtml.Append("<td><span id=\"txtDetail_pNo" + i + "\">" + i + "</span></td>");
            SbHtml.Append("<td><textarea id=\"txtProjectName" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtCname" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><input type=\"text\" id=\"txtCountOffTime" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("<td><textarea id=\"txtDealNo" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtOtherDataAddress" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtChangeSituation" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtChangeCname" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtType" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtChangeReason" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");

            SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    #endregion

    #region 事件

    #region 按钮点击事件

    #region 保存按钮点击事件
    /// <summary>
    /// 保存按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region 创建对象

        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_ChangeData t_OfficeAutomation_Document_ChangeData = new T_OfficeAutomation_Document_ChangeData();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                //MainID = "";//*+
                IsNewApply = true;
            }
        }
        catch
        {
        }

        try
        {
            //if (MainID == "")
            //{
            if (IsNewApply)
            {
                #region 新建
                IsNewApply = false;
                DataSet ds = new DataSet();

                //string[] sHRTree = null;
                //try
                //{
                //    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                //}
                //catch
                //{
                //    Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                //    return;
                //}

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ChangeData" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 26; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;



                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Apply = EmployeeName;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ApplyID = txtApplyID.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Department = txtDepartment.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Building = txtBuilding.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ReplyPhone = txtReplyPhone.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Reason = txtReason.Text;

                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ReasonDay = txtReasonDay.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ReportNo = txtReportNo.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_DataAddress = txtDataAddress.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_NewDataAddress = txtNewDataAddress.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_OldCustomerName = txtOldCustomerName.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_NewCustomerName = txtNewCustomerName.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_OldBranch = txtOldBranch.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_NewBranch = txtNewBranch.Text;
                t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Others = txtOthers.Text;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtReason.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_ChangeData_Inherit.Insert(t_OfficeAutomation_Document_ChangeData);//插入申请表

                InsertChangeDataDetail(t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ID);

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                #region 根据默认流程表中的固定环节添加流程

                ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString());
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (string.IsNullOrEmpty(dr["OfficeAutomation_Document_Flow_Position"].ToString()))
                        {
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = dr["OfficeAutomation_Document_Flow_AuditCode"].ToString();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = dr["OfficeAutomation_Document_Flow_AuditName"].ToString();
                        }

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(dr["OfficeAutomation_Document_Flow_Idx"].ToString());

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }

                #endregion

                //#region 添加前线总监 2014-3-26

                ////int count = sHRTree[0].Split(',').Length;

                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sHRTree[0].Split(',')[0];
                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sHRTree[1].Split(',')[0];
                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;

                //da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                //#endregion

                //#region 如果金额大于两万，则增加后勤事务部，及董事总经理环节 2014-3-31

                //if (t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_MoneyCount > 20000)
                //{
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_OPERATOR_ID;
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_OPERATOR_NAME;
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;

                //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

                //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //}

                //#endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 30, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ChangeData_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    Update();
                    RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
                }
                else
                    Alert("未开通编辑修改权限。");
                #endregion
            }
        }
        catch (Exception ex)
        {
            Alert("保存失败！" + ex.Message);
        }
    }
    #endregion

    #region 下载附件按钮单击事件
    /// <summary>
    /// 下载附件按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        //根据复选框的选中状态，将多个文件打包下载
        List<string> files = new List<string>();
        foreach (GridViewRow item in gvAttach.Rows)
        {
            CheckBox chk = item.FindControl("chk") as CheckBox;
            if (chk != null && chk.Checked)
            {
                HiddenField hf = item.FindControl("hfPath") as HiddenField;
                if (hf != null) files.Add(hf.Value);
            }
        }

        if (files.Count > 0)
        {
            Download(files, "Attachment-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
            Common.AddLog(EmployeeID, EmployeeName, 30, new Guid(MainID), 8);
        }
        else
            Alert("请勾选文件再下载！");
    }
    #endregion

    #region 签名按钮点击事件
    /// <summary>
    /// 签名按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSign_Click(object sender, EventArgs e)
    {
        DataSet dsg = new DataSet(); //20150105：M_DeleteC
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
        dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
        if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
            return;
        }
        DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
        DA_OfficeAutomation_Document_ChangeData_Detail_Inherit da_OfficeAutomation_Document_ChangeData_Detail_Inherit = new DA_OfficeAutomation_Document_ChangeData_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_ChangeData_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ChangeData_ID"].ToString();

        string flowIDx = "0";
        string signEmployeeName = EmployeeName;
        string signEmployeeId = EmployeeID;

        if (Purview.Contains("OA_ITPower_002"))
        {
            try
            {
                if (!CheckGIFIsExist(EmployeeID))
                {
                    RunJS("alert('" + CommonConst.MSG_NO_SIGNIMAGE + "');window.location.href='" + Request.RawUrl + "';");
                    return;
                }

                DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                DataRowCollection drc = dsFlow.Tables[0].Rows;
                for (int i = 0; i < drc.Count; i++)
                {
                    if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False")
                    {
                        if (i > 0 && drc[i - 1]["OfficeAutomation_Flow_Audit"].ToString() == "False")
                        {
                            RunJS("alert('您之前的审批环节已被撤销，请稍后再审。');window.location='" + Page.Request.Url + "'");
                            return;
                        }
                        DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                        //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                        string haveSignPowerEmployee = da_OfficeAutomation_Agent_Inherit.HaveSignPowerEmployee(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(), EmployeeName, EmployeeID);
                        if (haveSignPowerEmployee != null)
                        {
                            flowIDx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
                            signEmployeeName = haveSignPowerEmployee.Split('|')[0];
                            signEmployeeId = haveSignPowerEmployee.Split('|')[1];
                            break;
                        }
                    }
                }

                if (flowIDx == "10")
                {
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                    if (ckbAddIDx10.Checked)//增加审批环节是否勾选，如果是则添加第11步黄志超审批
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                //如果为第8步流程则为其一审核即可通过，其他为同时审核。
                bool isSignSuccess = (flowIDx == "8" || flowIDx == "13") ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeData_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ChangeData_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_ChangeData_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_ChangeData_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ChangeData_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>文件主题：关于" + drRow["OfficeAutomation_Document_ChangeData_Building"].ToString() + "的变更资料申请");
                    sbMailBody.Append("<br/>回复电话：020-" + drRow["OfficeAutomation_Document_ChangeData_ReplyPhone"]);
                    sbMailBody.Append("<br/>变更资料原因：" + drRow["OfficeAutomation_Document_ChangeData_Reason"]);


                    sbMailBody.Append("<br/>报数时间：" + drRow["OfficeAutomation_Document_ChangeData_ReasonDay"]);
                    sbMailBody.Append("<br/>成交编号：" + drRow["OfficeAutomation_Document_ChangeData_ReportNo"]);
                    sbMailBody.Append("<br/>物业地址：" + drRow["OfficeAutomation_Document_ChangeData_DataAddress"] + "，改为：" + drRow["OfficeAutomation_Document_ChangeData_NewDataAddress"]);
                    sbMailBody.Append("<br/>原客户姓名：" + drRow["OfficeAutomation_Document_ChangeData_OldCustomerName"] + "，改为：" + drRow["OfficeAutomation_Document_ChangeData_NewCustomerName"]);
                    sbMailBody.Append("<br/>原成交分行：" + drRow["OfficeAutomation_Document_ChangeData_OldBranch"] + "，改为：" + drRow["OfficeAutomation_Document_ChangeData_NewBranch"]);
                    sbMailBody.Append("<br/>另外说明：" + drRow["OfficeAutomation_Document_ChangeData_Others"]);
                    sbMailBody.Append("<br/><br/>");

                    sbMailBody.Append("<br/>其它变更资料详细情况：");

                    ds = da_OfficeAutomation_Document_ChangeData_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>报数时间：" + dr["OfficeAutomation_Document_ChangeData_Detail_CountOffTime"]);
                        sbMailBody.Append("<br/>成交编号：" + dr["OfficeAutomation_Document_ChangeData_Detail_DealNo"]);
                        sbMailBody.Append("<br/>物业地址：" + dr["OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress"]);
                        sbMailBody.Append("<br/>变更情况：" + dr["OfficeAutomation_Document_ChangeData_Detail_ChangeSituation"]);
                        sbMailBody.Append("<br/>变更事由：" + dr["OfficeAutomation_Document_ChangeData_Detail_ChangeReason"]);
                        sbMailBody.Append("<br/>");
                    }

                    mailBody = sbMailBody.ToString();

                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意

                        //判断审批流程是否完成,通知相应人员
                        if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID))
                        {
                            //审批流程完成，通知申请人
                            msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            email = apply;
                            if (hdIsAgree.Value == "2")
                                Common.SendMessageEX(false, email, "其他意见", msnBody, msnBody);
                            else
                                Common.SendMessageEX(false, email, "申请已同意", msnBody, msnBody);

                            string employeeList = "";//该字段用于防止重复发送
                            foreach (DataRow dr in dsFlow.Tables[0].Rows)
                            {
                                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    if (!employeeList.Contains(employnames[i]))
                                    {
                                        msnBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        email = employnames[i];
                                        if (hdIsAgree.Value == "2")
                                            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                        else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                        employeeList += employnames[i] + "||";
                                    }
                                }
                            }

                            ////完成后抄送
                            //employname = "吴惠卿,招健辉,叶凯蔓,陈婉娜";
                            //employnames = employname.Split(',');
                            //for (int i = 0; i < employnames.Length; i++)
                            //{
                            //    if (!employeeList.Contains(employnames[i]))
                            //    {
                            //        msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //        email = employnames[i];
                            //        if (hdIsAgree.Value == "2")
                            //            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                            //        else
                            //            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                            //        employeeList += employnames[i] + "||";
                            //    }
                            //}
                        }
                        else
                        {
                            //通知申请人
                            msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            email = apply;
                            Common.SendMessageEX(false, email, "申请已通过" + EmployeeName + "的审理", msnBody, msnBody);

                            //通知下一步需要审批的人员
                            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                            if (!employname.Contains(EmployeeName))
                            {
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    msnBody = "您好，" + employnames[i] + "：您有" + department
                                        + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody, MainID);
                                }
                            }

                            ////当审批到总经理的时候，发份邮件通知总办2位同事
                            //if (employname.Contains(CommonConst.EMP_GENERALMANAGER_NAME))
                            //{
                            //    employname = CommonConst.EMP_GMO_NAME;
                            //    employnames = employname.Split(',');
                            //    for (int i = 0; i < employnames.Length; i++)
                            //    {
                            //        email = employnames[i];
                            //        msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //        Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody + mailBody, msnBody);
                            //    }
                            //}
                        }

                        RunJS("alert('审批成功！');window.location='" + Page.Request.Url + "'");
                    }
                    else //不同意
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 5);//添加日志，签名不同意

                        //通知申请人
                        msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        email = apply;
                        Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", msnBody, msnBody);

                        //通知已审批的人员
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                msnBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                email = employnames[i];
                                Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", msnBody + mailBody, msnBody);
                            }
                        }

                        if (EmployeeID == "0001") //抄送到总办
                        {
                            string sagree = "";
                            if (hdSuggestion.Value != "")
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            employname = CommonConst.EMP_GMO_NAME;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                email = employnames[i];
                                Common.SendMessageEX(false, email, "申请不同意", msnBody + mailBody, msnBody);
                            }
                        } //总办

                        RunJS("alert('审理成功！');window.location='" + Page.Request.Url + "'");
                    }
                }
            }
            catch
            {
                Alert("审理失败！");
            }
        }
        else
        {
            Alert("未开通审核权限！");
        }
    }
    #endregion

    #region 标记按钮点击事件

    /// <summary>
    /// 点击标记按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSignSave_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_ChangeData_Inherit.SelectByMainID(MainID);
            string id = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeData_ID"].ToString();

            if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "34498" || EmployeeID == "20208" || EmployeeID == "43781")
                da_OfficeAutomation_Document_ChangeData_Inherit.AddRemarkByID_II(id, CommonConst.SIGN_FINANCE);
            RunJS("alert('标记成功。');window.location.href='" + Page.Request.Url + "';");
        }
        catch
        {
            RunJS("alert('标记失败。');window.location.href='" + Page.Request.Url + "';");
        }
    }

    #endregion

    #region 返回按钮点击事件
    protected void btnBack_Click(object sender, EventArgs e)
    {

        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
    }
    #endregion

    #endregion

    #region datagrid事件

    /// <summary>
    /// gvAttachment的行命令操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;
        string commType = e.CommandName;
        switch (commType)
        {
            case "Del":
                //if (drc[7]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
                //{
                //    RunJS("alert('因为法律部人员已经审批完毕，所以附件不能删除！');history.go(-1);");
                //    break;
                //}
                Alert("删除附件" + (da_OfficeAutomation_Attach_Inherit.Delete(e.CommandArgument.ToString()) ? "成功!" : "失败!"));
                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(MainID), 3);
                break;
        }

        LoadPage();
    }

    #endregion

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_ChangeData t_OfficeAutomation_Document_ChangeData = new T_OfficeAutomation_Document_ChangeData();
        DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ChangeData_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeData_ID"].ToString();

        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ID = new Guid(ID);
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Apply = EmployeeName;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Building = txtBuilding.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Reason = txtReason.Text;

        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ReasonDay = txtReasonDay.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_ReportNo = txtReportNo.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_DataAddress = txtDataAddress.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_NewDataAddress = txtNewDataAddress.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_OldCustomerName = txtOldCustomerName.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_NewCustomerName = txtNewCustomerName.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_OldBranch = txtOldBranch.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_NewBranch = txtNewBranch.Text;
        t_OfficeAutomation_Document_ChangeData.OfficeAutomation_Document_ChangeData_Others = txtOthers.Text;

        string apply = "";
        string depname = txtDepartment.Text;
        string summary = txtReason.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_ChangeData_Inherit.Update(t_OfficeAutomation_Document_ChangeData);//修改申请表

        DA_OfficeAutomation_Document_ChangeData_Detail_Inherit da_OfficeAutomation_Document_ChangeData_Detail_Inherit = new DA_OfficeAutomation_Document_ChangeData_Detail_Inherit();
        da_OfficeAutomation_Document_ChangeData_Detail_Inherit.Delete(ID);
        InsertChangeDataDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 30, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增变更资料申请明细

    /// <summary>
    /// 新增变更资料申请明细
    /// </summary>
    /// <param name="gChangeDataID"></param>
    private void InsertChangeDataDetail(Guid gChangeDataID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_ChangeData_Detail t_OfficeAutomation_Document_ChangeData_Detail;
        DA_OfficeAutomation_Document_ChangeData_Detail_Inherit da_OfficeAutomation_Document_ChangeData_Detail_Inherit = new DA_OfficeAutomation_Document_ChangeData_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_ChangeData_Detail = new T_OfficeAutomation_Document_ChangeData_Detail();
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_MainID = gChangeDataID;
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_pNo = detail[0];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_CountOffTime = detail[1];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_DealNo = detail[2];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress = detail[3];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_ChangeSituation = detail[4];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_ChangeReason = detail[5];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_ProjectName = detail[6];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_Cname = detail[7];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_Type = detail[8];
                t_OfficeAutomation_Document_ChangeData_Detail.OfficeAutomation_Document_ChangeData_Detail_ChangeCname = detail[9];

                da_OfficeAutomation_Document_ChangeData_Detail_Inherit.Insert(t_OfficeAutomation_Document_ChangeData_Detail);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    #endregion

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        if (Cache["AllDepartment"] == null)
        {
            SbJson.Remove(0, SbJson.Length);
            wsKDHR.Service service = new wsKDHR.Service();
            DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
            SbJson.Append("[");

            foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
            {
                SbJson.Append("{\"id\":\"" + dr["id"].ToString() + "\",\"value\":\"" + dr["name"].ToString() + "\"},");
            }

            SbJson.Remove(SbJson.Length - 1, 1);
            SbJson.Append("]");
            Cache["AllDepartment"] = SbJson;
        }
        else
            SbJson = (StringBuilder)Cache["AllDepartment"];

        //SbJson.Remove(0, SbJson.Length);
        //wsKDHR.Service service = new wsKDHR.Service();
        //DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
        //SbJson.Append("[");

        //////简单去除分行下面的组别，变分行，简单过滤重复。
        ////string name;
        ////foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        ////{
        ////    name = dr["name"].ToString();
        ////    Match m = Regex.Match(name, "[A-Z]{1}组");
        ////    if (m.Success)//去除组别
        ////        name = name.Substring(0, m.Index);

        ////    m = Regex.Match(name, "(\\(|（)+\\w+(\\)|）)+");
        ////    if (m.Success)//去除括号
        ////        name = name.Substring(0, m.Index);

        ////    m = Regex.Match(name, "[A-D]$");
        ////    if (m.Success)//去除名称尾部的ABCD
        ////        name = name.Substring(0, m.Index);

        ////    if (!sbJSON.ToString().Contains(name))
        ////        sbJSON.Append("{\"value\":\"" + name + "\"},");
        ////}

        //foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        //{
        //    SbJson.Append("{\"value\":\"" + dr["name"] + "\"},");
        //}

        //SbJson.Remove(SbJson.Length - 1, 1);
        //SbJson.Append("]");
    }
    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite32"] = "1";
        Response.Write("<script>window.open('Apply_ChangeData_Detail.aspx?MainID=" + MainID + "');</script>");
    }
    protected void btnSPDF_Click(object sender, EventArgs e) //M_PDF
    {
        try
        {
            //因为Web 是多线程环境，避免甲产生的文件被乙下载去，所以档名都用唯一 
            string fileNameWithOutExtention = Guid.NewGuid().ToString();
            string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri + "&htmltopdf=Yes&EPID=" + EmployeeID + " ";
            //执行wkhtmltopdf.exe 
            Process p = System.Diagnostics.Process.Start(System.Web.HttpContext.Current.Server.MapPath("/Exe\\wkhtmltopdf.exe"), baseUrl + System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + fileNameWithOutExtention + ".pdf"));
            //若不加这一行，程序就会马上执行下一句而抓不到文件发生意外：System.IO.FileNotFoundException: 找不到文件 ''。 
            p.WaitForExit();

            //把文件读进文件流 
            //FileStream fs = new FileStream(@"D:\" + fileNameWithOutExtention + ".pdf", FileMode.Open);
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + fileNameWithOutExtention + ".pdf"), FileMode.Open);
            byte[] file = new byte[fs.Length];
            fs.Read(file, 0, file.Length);
            fs.Close();
            File.Delete(System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + fileNameWithOutExtention + ".pdf"));

            //Response给客户端下载 
            Response.Clear();
            Response.AddHeader("Content-Type", "application/pdf");
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("变更资料申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }
    protected void btnUploadDetailed_Click(object sender, EventArgs e)
    {
        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);

        string path = hdFilePath.Value;
        if (path != "")
        {
            System.Data.OleDb.OleDbConnection ImportConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source=" + path + "; " + "Extended Properties='Excel 12.0;HDR=1; IMEX=1;'");
            System.Data.OleDb.OleDbDataAdapter ImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [格式$]", ImportConnection);
            DataSet ds = new DataSet();
            int i = 0;
            try
            {
                ImportCommand.Fill(ds);
            }
            catch
            {
                Alert("格式错误");
                DrawDetailTable(1);
                //txtMoneyCount.Text = "";
                SbJs.Append("</script>");
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string sReportID, sAddress, sOwnerBadMoney, sClientBadMoney, sBadReason, sProjectName, sCname, sChangeCname, sType;
                    //bool bIsSpecialAdjust;
                    int success = 0;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        sReportID = ds.Tables[0].Rows[i]["报数时间"].ToString();
                        sProjectName = ds.Tables[0].Rows[i]["项目名称"].ToString();
                        sCname = ds.Tables[0].Rows[i]["客户姓名"].ToString();
                        sAddress = ds.Tables[0].Rows[i]["成交编号"].ToString();
                        sOwnerBadMoney = ds.Tables[0].Rows[i]["物业地址"].ToString();
                        sClientBadMoney = ds.Tables[0].Rows[i]["变更后物业地址"].ToString();
                        sChangeCname = ds.Tables[0].Rows[i]["变更后客户姓名"].ToString();
                        sBadReason = ds.Tables[0].Rows[i]["变更事由"].ToString();
                        sType = ds.Tables[0].Rows[i]["成交类型"].ToString();
                        //bIsSpecialAdjust = ds.Tables[0].Rows[i]["是否特殊调整"].ToString() == "是" ? true : false;

                        if (!string.IsNullOrEmpty(sReportID) && !string.IsNullOrEmpty(sAddress))
                        {
                            success++;
                            SbJs.Append("$('#txtDetail_pNo" + success + "').html('" + success + "');");
                            SbJs.Append("$('#txtProjectName" + success + "').val('" + sProjectName + "');");
                            SbJs.Append("$('#txtCname" + success + "').val('" + sCname + "');");
                            SbJs.Append("$('#txtCountOffTime" + success + "').val('" + sReportID + "');");
                            SbJs.Append("$('#txtDealNo" + success + "').val('" + sAddress + "');");
                            SbJs.Append("$('#txtOtherDataAddress" + success + "').val('" + sOwnerBadMoney + "');");
                            SbJs.Append("$('#txtChangeSituation" + success + "').val('" + sClientBadMoney + "');");
                            SbJs.Append("$('#txtChangeCname" + success + "').val('" + sChangeCname + "');");
                            SbJs.Append("$('#txtType" + success + "').val('" + sType + "');");
                            SbJs.Append("$('#txtChangeReason" + success + "').val('" + sBadReason + "');");
                            //SbJs.Append("$('#rdoIsSpecialAdjust" + success + (bIsSpecialAdjust ? "1" : "0") + "').attr('checked','checked');");
                        }

                        //if (sReportID == "业、客坏账金额合计：")
                        //    txtMoneyCount.Text = sOwnerBadMoney;
                    }

                    DrawDetailTable(success);
                }
                catch (System.Exception ex)
                {
                    Alert(ex.Message);
                }
            }
        }
        else
            DrawDetailTable(1);
        SbJs.Append("</script>");
    }
    protected void btnCancelSign_Click(object sender, EventArgs e) //20141202：CancelSign
    {
        try
        {
            DataSet dsg = new DataSet(); //20150105：M_DeleteC
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
            dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
            {
                RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
            {
                RunJS("alert('该表已审批完毕，不能再撤回审核了');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

            int i = 0;
            int.TryParse(hdCancelSign.Value, out i);
            T_OfficeAutomation_Flow flows;
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, i);

            string namesA = flows.OfficeAutomation_Flow_Auditor, idsA = flows.OfficeAutomation_Flow_AuditorID;
            string[] employnames;
            string email;
            string msnBody;
            string signEmployeeName = EmployeeName;
            DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ChangeData_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeData_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ChangeData_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
            if (flows != null)
            {
                //通知申请人
                msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已被" + signEmployeeName + "撤销审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                email = apply;
                Common.SendMessageEX(false, email, "您的申请已被" + signEmployeeName + "撤销审理", msnBody, msnBody);

                //通知已审批的人员
                ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAfterIdx(MainID, i);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                    employnames = employname.Split(',');
                    for (int i2 = 0; i2 < employnames.Length; i2++)
                    {
                        msnBody = "您好，" + employnames[i2] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已被" + signEmployeeName + "撤销审理，待会需要您重审。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        email = employnames[i2]; if (email != "")
                            Common.SendMessageEX(false, email, "申请已被" + signEmployeeName + "撤销审理", msnBody, msnBody);
                    }
                }

                ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDDesc(MainID);
                if (ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString() != "0")
                {
                    if (idsA.IndexOf(',') != -1)
                    {
                        if (idsA.IndexOf(EmployeeID + ',') != -1)
                        {
                            idsA = idsA.Replace((EmployeeID + ','), string.Empty);
                            namesA = namesA.Replace((EmployeeName + ','), string.Empty);
                        }
                        else
                        {
                            idsA = idsA.Replace((',' + EmployeeID), string.Empty);
                            namesA = namesA.Replace((',' + EmployeeName), string.Empty);
                        }
                        da_OfficeAutomation_Flow_Inherit.UpdateByMainIDAndIdxs(MainID, i, namesA, idsA);
                        da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, i);
                    }
                    else
                        da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                }
                else
                {
                    da_OfficeAutomation_Flow_Inherit.InsertDeleteFlows(MainID);
                    if (idsA.IndexOf(',') != -1)
                    {
                        if (idsA.IndexOf(EmployeeID + ',') != -1)
                        {
                            idsA = idsA.Replace((EmployeeID + ','), string.Empty);
                            namesA = namesA.Replace((EmployeeName + ','), string.Empty);
                        }
                        else
                        {
                            idsA = idsA.Replace((',' + EmployeeID), string.Empty);
                            namesA = namesA.Replace((',' + EmployeeName), string.Empty);
                        }
                        da_OfficeAutomation_Flow_Inherit.UpdateByMainIDAndIdxs(MainID, i, namesA, idsA);
                        da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, i);
                    }
                    else
                        da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                    da_OfficeAutomation_Flow_Inherit.DDeleteFlows(MainID);
                }
                da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
                if (i < 11)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
                Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 3); //添加日志，撤销签名
                RunJS("alert('撤销审理成功！');window.location='" + Page.Request.Url + "'");
            }
            else
                RunJS("alert('该审批表或流程已被删除！');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception ex)
        {
            Alert("撤销失败！" + ex.Message);
        }
    }
    protected void btnSAlterC_Click(object sender, EventArgs e) //20141216：M_AlterC
    {
        try
        {
            DataSet dsg = new DataSet(); //20150105：M_DeleteC
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
            dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
            {
                RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
            {
                RunJS("alert('该表已审批完毕，不能再修改了');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

            string[] employnames;
            string email;
            string msnBody;
            DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ChangeData_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeData_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ChangeData_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
            //通知已审批的全部人员
            ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    msnBody = "您好，" + employnames[i2] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已被" + EmployeeName + "修改了部分内容，待会需要您重审。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    email = employnames[i2]; if (email != "")
                        Common.SendMessageEX(false, email, "该份申请已经申请人修改，请重新审批！谢谢", msnBody, msnBody);
                }
            }

            #region 修改编辑
            if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
            {
                Update();
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
                da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                RunJS("alert('所作的修改已保存！');window.location='" + Page.Request.Url + "'");
            }
            else
                Alert("未开通编辑修改权限。");
            #endregion
        }
        catch (Exception ex)
        {
            Alert("保存失败，错误原因：" + ex.Message);
        }
    }
    protected void btnEditFlow_DoClick(object sender, EventArgs e)
    {
        try
        {
            DataSet dsg = new DataSet(); //20150105：M_DeleteC
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
            dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
            {
                RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

            string[] employnames;
            string email;
            string msnBody;
            DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ChangeData_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeData_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ChangeData_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
            //通知已审批的全部人员
            ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    msnBody = "您好，" + employnames[i2] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已被" + EmployeeName + "修改了审批流程。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    email = employnames[i2]; if (email != "")
                        Common.SendMessageEX(false, email, "申请表已被" + EmployeeName + "修改了审批流程", msnBody, msnBody);
                }
            }
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 7); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_ChangeData_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    protected void btnSignBad_Click(object sender, EventArgs e)
    {
        try
        {

            DA_OfficeAutomation_Document_ChangeData_Inherit da_OfficeAutomation_Document_ChangeData_Inherit = new DA_OfficeAutomation_Document_ChangeData_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_ChangeData_Inherit.SelectByMainID(MainID);
            string id = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeData_ID"].ToString();
            if (Purview.Contains("OA_Special_002"))
            {
                da_OfficeAutomation_Document_ChangeData_Inherit.AddRemarkByID_II(id, "（已更改）");
                RunJS("alert('标记成功。');window.location.href='" + Page.Request.Url + "';");
            }
        }
        catch
        {
            RunJS("alert('标记失败。');window.location.href='" + Page.Request.Url + "';");
        }
    }
}