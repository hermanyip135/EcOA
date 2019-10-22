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

public partial class Apply_ReduceComm_Apply_ReduceComm_Detail : BasePage
{
    #region 变量声明及定义

    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();

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

        MainID = GetQueryString("MainID");
        SerialNumber = "";

        if (!IsPostBack)
        {
            try
            {
                if (Session["FLG_ReWrite12"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite12"] = null;
                }
            }
            catch
            {
            }
            if (MainID != "")
                LoadPage();
            else
                InitPage();
            
        }       
        else
            GetAllDepartment();
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        GetAllDepartment();

        btnSave.Visible = true;
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
        DrawDetailTable(1);
        SbJs.Append("</script>");

        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        DataSet ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(13);

        DropDownListBind(ddlDepartmentType, ds.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", "0", "--请选择区域--");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit da_OfficeAutomation_Document_ReduceComm_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit();

        string flowState;
        try
        {
             flowState= da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
        }
        catch
        {
            Alert(CommonConst.MSG_URL_DISABLE);
            RunJS("window.location='/Apply/Apply_Search.aspx'");
            return;
        }

        SbJs.Append("<script type=\"text/javascript\">$(\"#spanApplyFor\").show();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ReduceComm_ID"].ToString();

        string applicant = dr["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
        lblApply.Text = applicant;
        txtDepartment.Value = dr["OfficeAutomation_Document_ReduceComm_Department"].ToString();
        txtApplyForID.Text = dr["OfficeAutomation_Document_ReduceComm_ApplyForCode"].ToString();
        txtApplyFor.Value = dr["OfficeAutomation_Document_ReduceComm_ApplyForName"].ToString();
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ReduceComm_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtSubject.Text = dr["OfficeAutomation_Document_ReduceComm_Subject"].ToString();
        txtDepartment.Value = dr["OfficeAutomation_Document_ReduceComm_Department"].ToString();
        hdDepartmentID.Value = dr["OfficeAutomation_Document_ReduceComm_DepartmentID"].ToString();
        txtReplyPhone.Text = dr["OfficeAutomation_Document_ReduceComm_ReplyPhone"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_ReduceComm_Reason"].ToString();
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(13);
        DropDownListBind(ddlDepartmentType, ds.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", "0", "--请选择区域--");
        ddlDepartmentType.SelectedValue = dr["OfficeAutomation_Document_ReduceComm_DepartmentTypeID"].ToString();

        ds = da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.SelectByApplyID(ID);
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

                SbJs.Append("$('#txtDealDate" + i + "').val('" + DateTime.Parse(dr["OfficeAutomation_Document_ReduceComm_Detail_DealDate"].ToString()).ToString("yyyy-MM-dd") + "');");
                SbJs.Append("$('#txtDealAddress" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_DealDepartment"] + "');");
                SbJs.Append("$('#txtOriginalDealPrice" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice"] + "');");
                SbJs.Append("$('#txtFinalDealPrice" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice"] + "');");
                SbJs.Append("$('#txtCommPoint" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_CommPoint"] + "');");
                SbJs.Append("$('#txtOriginalComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalComm"] + "');");
                SbJs.Append("$('#txtReduceCashBonus" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus"] + "');");
                SbJs.Append("$('#txtReduceComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceComm"] + "');");
                SbJs.Append("$('#txtTotalReduce" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_TotalReduce"] + "');");
                SbJs.Append("$('#txtActualReportMoney" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney"] + "');");
            }
        }

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;

            try
            {
                //2016-12-19修改 注释掉法律部人审批之后不能上传附件功能

                //if (drc[1]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
                //    SbJs.Append("$(\"#btnUpload\").hide();");
                //else
                    SbJs.Append("$(\"#btnUpload\").show();");
            }
            catch
            {
                SbJs.Append("$(\"#btnUpload\").show();");
            }
            if (isApplicant)
            {
                if (flowState == "1")
                {
                    GetAllDepartment();
                    btnSave.Visible = true;
                    SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
                }
                //btnReWrite.Visible = true; 
            }

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
            btnSignSave.Visible = true;

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("</script>");
                InitPage();
                flowState = "1";
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
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节
        
        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            //if (curidx == "8")
            //    flag3 = true;

            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                SbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                if (curemp.Contains(EmployeeName))
                {
                    switch (curidx)
                    {
                        //case "6":
                        //    //ckbAddIDx7.Visible = true;
                        //    break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                    SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Auditor"] + "已完成审理");
                else
                    SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Employee"]);
            }
            SbFlow.Append("</span>");

            //箭头图片
            if (i != (drc.Count - 1))//如果不是最后一项
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                    SbFlow.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
                else
                    SbFlow.Append("<img src=\"/Images/forward_skip.png\" class=\"forward\"/>");
            }
            #endregion

            #region 显示签名人姓名，签名图片，或签名按钮

            string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:0px; float:left;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                foreach (string s in auditorIDs)
                {
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

                DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
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
        //    SbJs.Append("$('#trLogistics').show();$('#trGeneralManager').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");

        SbFlow.Append("</div>");

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
        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id='trDetail" + i + "'>");
            SbHtml.Append("     <td><input type=\"text\" id=\"txtDealDate" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("     <td><input type=\"text\" id=\"txtDealAddress" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("     <td><input type=\"text\" id=\"txtOriginalDealPrice" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("     <td><input type=\"text\" id=\"txtFinalDealPrice" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("    <td><input type=\"text\" id=\"txtCommPoint" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("    <td><input type=\"text\" id=\"txtOriginalComm" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("    <td><input type=\"text\" id=\"txtReduceCashBonus" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("    <td><input type=\"text\" id=\"txtReduceComm" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("    <td><input type=\"text\" id=\"txtTotalReduce" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("    <td><input type=\"text\" id=\"txtActualReportMoney" + i + "\" style=\"width:90%\"/></td>");
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
        T_OfficeAutomation_Document_ReduceComm t_OfficeAutomation_Document_ReduceComm = new T_OfficeAutomation_Document_ReduceComm();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                MainID = "";
                 
            }
        }
        catch
        {
        }

        try
        {
            if (MainID == "")
            {
                #region 新建
                string[] sHRTree;
                try
                {
                    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                }
                catch
                {
                    Alert("请正确选择发文部门！");
                    return;
                }

                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ReduceComm" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 13;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Apply = EmployeeName;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForName = txtApplyFor.Value;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForCode = txtApplyForID.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentTypeID = int.Parse(ddlDepartmentType.SelectedValue);
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Subject = txtSubject.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Department = txtDepartment.Value;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentID = new Guid(hdDepartmentID.Value);
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReplyPhone = txtReplyPhone.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Reason = txtReason.Text;

                da_OfficeAutomation_Document_ReduceComm_Inherit.Add(t_OfficeAutomation_Document_ReduceComm);//插入申请表

                InsertReduceCommDetail(t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ID);

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

                #region 添加前线总监 

                //int count = sHRTree[0].Split(',').Length;

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sHRTree[0].Split(',')[0];
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sHRTree[1].Split(',')[0];
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                #endregion

                #region 根据所属区域增加法律部一级审批

                string employeeID, employee;
                switch (ddlDepartmentType.SelectedItem.Text)
                {
                    case "天河区":
                        employee = CommonConst.EMP_LAW_TIANHE_NAME;
                        employeeID = CommonConst.EMP_LAW_TIANHE_ID;
                        break;
                    case "海珠区":
                        employee = CommonConst.EMP_LAW_HAIZHU_NAME;
                        employeeID = CommonConst.EMP_LAW_HAIZHU_ID;
                        break;
                    case "工商铺":
                        employee = CommonConst.EMP_LAW_GONGSHANGPU_NAME;
                        employeeID = CommonConst.EMP_LAW_GONGSHANGPU_ID;
                        break;
                    case "其他区":
                        employee = CommonConst.EMP_LAW_QITA_NAME;
                        employeeID = CommonConst.EMP_LAW_QITA_ID;
                        break;
                    default:
                        employee = CommonConst.EMP_LAW_QITA_NAME;
                        employeeID = CommonConst.EMP_LAW_QITA_ID;
                        break;
                }

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = employeeID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = employee;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 2;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 17, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ReduceComm_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
            Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(MainID), 8);
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
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit da_OfficeAutomation_Document_ReduceComm_Detail_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ReduceComm_ID"].ToString();
        
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

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                bool isSignSuccess = da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ReduceComm_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_ReduceComm_ApplyForName"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_ReduceComm_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ReduceComm_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>文件主题：关于" + drRow["OfficeAutomation_Document_ReduceComm_Subject"].ToString() + "的减佣让佣申请");
                    sbMailBody.Append("<br/>回复电话：" + drRow["OfficeAutomation_Document_ReduceComm_ReplyPhone"]);
                    sbMailBody.Append("<br/>让佣原因说明：" + drRow["OfficeAutomation_Document_ReduceComm_Reason"]);
                    sbMailBody.Append("<br/>减佣让佣交易涉及具体情况：");
                    ds = da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.SelectByApplyID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>成交日期：" + dr["OfficeAutomation_Document_ReduceComm_Detail_DealDate"]);
                        sbMailBody.Append("<br/>成交单位：" + dr["OfficeAutomation_Document_ReduceComm_Detail_DealDepartment"]);
                        sbMailBody.Append("<br/>原成交价：" + dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice"]);
                        sbMailBody.Append("<br/>客户最终成交价：" + dr["OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice"]);
                        sbMailBody.Append("<br/>代理费点数：" + (dr["OfficeAutomation_Document_ReduceComm_Detail_CommPoint"]));
                        sbMailBody.Append("<br/>原佣金：" + (dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalComm"]));
                        sbMailBody.Append("<br/>让现金奖金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus"]);
                        sbMailBody.Append("<br/>让佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceComm"]);
                        sbMailBody.Append("<br/>总让佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_TotalReduce"]);
                        sbMailBody.Append("<br/>实际上数金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney"]);
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
                            Common.SendMessageEX(false, email, "申请已通过", msnBody, msnBody);

                            string employeeList = "";//该字段用于防止重复发送
                            foreach (DataRow dr in dsFlow.Tables[0].Rows)
                            {
                                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    if (!employeeList.Contains(employnames[i]))
                                    {
                                        msnBody = "您好，" + employnames[i] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        email = employnames[i];
                                        Common.SendMessageEX(false, email, "申请已通过", msnBody + mailBody, msnBody);

                                        employeeList += employnames[i] + "||";
                                    }
                                }
                            }

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //总办4张表(减佣让佣，物业部承接一手项目报备，项目费用，合作费)完成后需抄送给的人:黄筑筠,谢芃,李红梅,张绍欣,黄瑛
                            employname = CommonConst.EMP_GMO_COPYTO_NAME;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    email = employnames[i];
                                    Common.SendMessageEX(false, email, "申请已通过", msnBody + mailBody, msnBody);

                                    employeeList += employnames[i] + "||";
                                }
                            }
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
                                    msnBody = "您好，" + employnames[i] + "：您有" + department + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(false, email, "请审理", msnBody + mailBody, msnBody);
                                }
                            }

                            //当审批到总经理的时候，发份邮件通知总办2位同事
                            if (employname.Contains(CommonConst.EMP_GENERALMANAGER_NAME))
                            {
                                employname = CommonConst.EMP_GMO_NAME;
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "，编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody + mailBody, msnBody);
                                }
                            }
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
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(ID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                msnBody = "您好，" + employnames[i] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
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
        //try
        //{
        //    DA_OfficeAutomation_Document_BackComm_Inherit da_OfficeAutomation_Document_BackComm_Inherit = new DA_OfficeAutomation_Document_BackComm_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_BackComm_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
        //    Alert("标记成功。");
        //}
        //catch
        //{
        //    Alert("标记失败。");
        //}
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
                if (drc[1]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
                {
                    RunJS("alert('因为法律部人员已经审批完毕，所以附件不能删除！');history.go(-1);");
                    break;
                }
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
        T_OfficeAutomation_Document_ReduceComm t_OfficeAutomation_Document_ReduceComm = new T_OfficeAutomation_Document_ReduceComm();
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_ID"].ToString();

        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ID = new Guid(ID);
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForName = txtApplyFor.Value;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForCode = txtApplyForID.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentTypeID = int.Parse(ddlDepartmentType.SelectedValue);
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Subject = txtSubject.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Department = txtDepartment.Value;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentID = new Guid(hdDepartmentID.Value);
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Reason = txtReason.Text;

        da_OfficeAutomation_Document_ReduceComm_Inherit.Update(t_OfficeAutomation_Document_ReduceComm);//修改申请表

        DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit da_OfficeAutomation_Document_ReduceComm_Detail_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit();
        da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.Delete(new Guid(ID));
        InsertReduceCommDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 17, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增退佣申请明细

    /// <summary>
    /// 新增退佣申请明细
    /// </summary>
    /// <param name="gReduceCommID"></param>
    private void InsertReduceCommDetail(Guid gReduceCommID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_ReduceComm_Detail t_OfficeAutomation_Document_ReduceComm_Detail;
        DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit da_OfficeAutomation_Document_ReduceComm_Detail_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_ReduceComm_Detail = new T_OfficeAutomation_Document_ReduceComm_Detail();
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_MainID = gReduceCommID;
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_DealDate = DateTime.Parse(detail[0]);
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_DealDepartment = detail[1];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice = detail[2];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice = detail[3];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CommPoint = detail[4];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_OriginalComm = detail[5];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus = detail[6];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ReduceComm = detail[7];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_TotalReduce = detail[8];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney = detail[9];
            da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.Add(t_OfficeAutomation_Document_ReduceComm_Detail);
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
                SbJson.Append("{\"id\":\"" + dr["id"].ToString() +  "\",\"value\":\"" + dr["name"].ToString() + "\"},");
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
        Session["FLG_ReWrite12"] = "1";
        Response.Write("<script>window.open('Apply_LaunchCost_Detail.aspx?MainID=" + MainID + "');</script>");
    }
}