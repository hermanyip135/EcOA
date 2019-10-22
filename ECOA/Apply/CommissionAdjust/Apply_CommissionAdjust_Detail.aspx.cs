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

public partial class Apply_CommissionAdjust_Apply_CommissionAdjust_Detail : BasePage
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
                if (Session["FLG_ReWrite33"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite33"] = null;
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
        DrawDetailTable(0);
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
        DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();
        DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit da_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit();

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

        SbJs.Append("<script type=\"text/javascript\">");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
        {
            SbJs.Append("$(\"#btnPrint\").show();");
            //如果拥有权限则显示标注已坏账按钮
            //if (Purview.Contains("OA_Special_002") || EmployeeID == "16945")
            //if (Purview.Contains("OA_Special_002") || EmployeeID == "16945" || EmployeeID == "61275") btnSignBad.Visible = true;
            //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
            if (Purview.Contains("OA_Special_002") || EmployeeID == "43781" || EmployeeID == "61275") btnSignBad.Visible = true;
        }
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_CommissionAdjust_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ddlSign.SelectedValue = dr["OfficeAutomation_Document_CommissionAdjust_Sign"].ToString();
        ID = dr["OfficeAutomation_Document_CommissionAdjust_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_CommissionAdjust_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_CommissionAdjust_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_CommissionAdjust_Department"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_CommissionAdjust_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtBuilding.Text = dr["OfficeAutomation_Document_CommissionAdjust_Building"].ToString();
        txtReplyPhone.Text = dr["OfficeAutomation_Document_CommissionAdjust_ReplyPhone"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_CommissionAdjust_Reason"].ToString();
        if (dr["OfficeAutomation_Document_CommissionAdjust_IsLawE"].ToString() == "True")
            rdbIsLawE1.Checked = true;
        else
            rdbIsLawE2.Checked = true;

        txtBadCommDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_CommissionAdjust_BadCommDate"].ToString()).ToString("yyyy-MM-dd");
        txtProperty.Text = dr["OfficeAutomation_Document_CommissionAdjust_Property"].ToString();
        txtControler.Text = dr["OfficeAutomation_Document_CommissionAdjust_Controler"].ToString();
        txtPropertyID.Text = dr["OfficeAutomation_Document_CommissionAdjust_PropertyID"].ToString();
        try
        {
            txtPropertyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_CommissionAdjust_PropertyDate"].ToString()).ToString("yyyy-MM-dd");
        }
        catch
        {
            txtPropertyDate.Text = dr["OfficeAutomation_Document_CommissionAdjust_PropertyDate"].ToString();
        }
        
        txtOldDeal.Text = dr["OfficeAutomation_Document_CommissionAdjust_OldDeal"].ToString();
        txtNewDeal.Text = dr["OfficeAutomation_Document_CommissionAdjust_NewDeal"].ToString();
        txtAjustDeal.Text = dr["OfficeAutomation_Document_CommissionAdjust_AjustDeal"].ToString();
        txtShouldComm.Text = dr["OfficeAutomation_Document_CommissionAdjust_ShouldComm"].ToString();
        txtActualComm.Text = dr["OfficeAutomation_Document_CommissionAdjust_ActualComm"].ToString();
        txtAjustComm.Text = dr["OfficeAutomation_Document_CommissionAdjust_AjustComm"].ToString();
        if (dr["OfficeAutomation_Document_CommissionAdjust_LeadReason"].ToString() == "True")
            rdbLeadReason1.Checked = true;
        else
            rdbLeadReason2.Checked = true;

        if (dr["OfficeAutomation_Document_CommissionAdjust_Commitment"].ToString() == "0")
            rdbCommitment1.Checked = true;
        else if (dr["OfficeAutomation_Document_CommissionAdjust_Commitment"].ToString() == "1")
            rdbCommitment2.Checked = true;
        else
            rdbCommitment3.Checked = true;
        txtSumShouldComm.Text = dr["OfficeAutomation_Document_CommissionAdjust_SumShouldComm"].ToString();
        txtSumAjustComm.Text = dr["OfficeAutomation_Document_CommissionAdjust_SumAjustComm"].ToString();

        txtSumOldDeal.Text = dr["OfficeAutomation_Document_CommissionAdjust_SumOldDeal"].ToString();
        txtSumNewDeal.Text = dr["OfficeAutomation_Document_CommissionAdjust_SumNewDeal"].ToString();
        txtSumAjustDeal.Text = dr["OfficeAutomation_Document_CommissionAdjust_SumAjustDeal"].ToString();
        txtSumActualComm.Text = dr["OfficeAutomation_Document_CommissionAdjust_SumActualComm"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        ds = da_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit.SelectByID(ID);
        int detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable(0);
        else
        {
            DrawDetailTable(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];

                int i = n + 1;

                SbJs.Append("$('#txtDetail_pNo" + i + "').html('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_pNo"] + "');");
                SbJs.Append("$('#txtProperty" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Property"] + "');");
                SbJs.Append("$('#txtControler" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Controler"] + "');");
                SbJs.Append("$('#txtPropertyID" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID"] + "');");
                try
                {
                    SbJs.Append("$('#txtPropertyDate" + i + "').val('" + DateTime.Parse(dr["OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate"].ToString()).ToString("yyyy-MM-dd") + "');");
                }
                catch
                {
                    SbJs.Append("$('#txtPropertyDate" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate"] + "');");
                }
                SbJs.Append("$('#txtOldDeal" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal"] + "');");
                SbJs.Append("$('#txtNewDeal" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal"] + "');");
                SbJs.Append("$('#txtAjustDeal" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal"] + "');");
                SbJs.Append("$('#txtShouldComm" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm"] + "');");
                SbJs.Append("$('#txtActualComm" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm"] + "');");
                SbJs.Append("$('#txtAjustComm" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm"] + "');");
                //SbJs.Append("$('#rdoApplyType" + i + (dr["OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                //SbJs.Append("$('#rdoApplyType" + i + dr["OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason"].ToString() + "').attr('checked','true');");
                SbJs.Append("$('#txtCname" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Cname"] + "');");
                SbJs.Append("$('#txtCommitment" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Commitment"] + "');");
                SbJs.Append("$('#txtChangeReason" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Reason"] + "');");
                SbJs.Append("$('#txtDealType" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_DealType"] + "');");
                SbJs.Append("$('#txtChangeType" + i + "').val('" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType"] + "');");
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

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        //if ((EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "34498" || EmployeeID == "20208" || EmployeeID == "43781") && flowState == "3")
        if ((EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "34498" || EmployeeID == "20208" || EmployeeID == "43781" || EmployeeID == "61275") && flowState == "3") btnSignSave.Visible = true;
         
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
        
        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        bool idx5 = false;//如果idx5 true 童倩仪 标题就显示 销售中心负责人 如果false就交易管理部负责人
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();
            if ("5".Equals(curidx))
            {
                if ("黄鸣秀".Equals(curemp))
            {
                laIdx5.InnerText = "销售中心负责人";
            }
            }
            //if (curidx == "9")
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
                        case "10":
                            ckbAddIDx10.Visible = true;
                            break;
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
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

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

        T_OfficeAutomation_Flow flows;
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 7);
        if (flows != null)
            SbJs.Append("$('#trManager7').show();");

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
            //SbHtml.Append("<td class=\"tl PL10\" style=\"line-height: 30px\" colspan=\"3\">");
            //SbHtml.Append("物业：<input type=\"text\" id=\"txtProperty" + i + "\" style=\"width:250px\">　经办人：<input type=\"text\" id=\"txtControler" + i + "\" style=\"width:250px\"><br />");
            //SbHtml.Append("物业成交编号：<input type=\"text\" id=\"txtPropertyID" + i + "\" style=\"width:201px\">　物业成交日期：<input type=\"text\" id=\"txtPropertyDate" + i + "\" style=\"width:215px\"><br />");
            //SbHtml.Append("①原成交价：人民币<input type=\"text\" id=\"txtOldDeal" + i + "\" style=\"width:177px\">②现成交价：人民币<input type=\"text\" id=\"txtNewDeal" + i + "\" style=\"width:202px\"><br />");
            //SbHtml.Append("③成交价调整：人民币<input type=\"text\" id=\"txtAjustDeal" + i + "\" style=\"width:164px\">　客户名称：<input type=\"text\" id=\"txtCname" + i + "\" style=\"width:240px\"/><br />客户联系电话：<input type=\"text\" id=\"txtCommitment" + i + "\" style=\"width:200px\"/><br />");
            //SbHtml.Append("④应收佣金：人民币<input type=\"text\" id=\"txtShouldComm" + i + "\" style=\"width:176px\">⑤实收佣金：人民币<input type=\"text\" id=\"txtActualComm" + i + "\" style=\"width:202px\"><br />");
            //SbHtml.Append("⑥调整佣金：港币/人民币<input type=\"text\" id=\"txtAjustComm" + i + "\" style=\"width:148px\">");
            //SbHtml.Append("是否特殊调整：<input type=\"radio\" id='rdoApplyType" + i + "1' name='rdoApplyType" + i + "' /><label for='rdoApplyType" + i + "1'>是</label><input type=\"radio\" id='rdoApplyType" + i + "0' name='rdoApplyType" + i + "' /><label for='rdoApplyType" + i + "0'>否</label>");
            //SbHtml.Append("<br />");
            //SbHtml.Append("<span style=\"vertical-align: top;margin-top: 10px;\">坏帐原因</span><textarea id=\"txtChangeReason" + i + "\" rows=\"9\" style=\"width: 540px;margin-top: 8px; overflow: auto;\"></textarea><br /><br />");
            //SbHtml.Append("</td>");

            SbHtml.Append("<td><span id=\"txtDetail_pNo" + i + "\">" + i + "</span></td>");
            SbHtml.Append("<td><input type=\"text\"  id=\"txtPropertyDate" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("<td><textarea id=\"txtPropertyID" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDealType" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtProperty" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtOldDeal" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtNewDeal" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtAjustDeal" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtShouldComm" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtActualComm" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtAjustComm" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtControler" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtChangeReason" + i + "\" style=\"width:90%; overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtChangeType" + i + "\" style=\"width:90%; overflow: auto;\" rows=\"2\"></textarea></td>");
            //SbHtml.Append("<td><input type=\"radio\" id=\"rdoApplyType" + i + "1\" name=\"rdoApplyType" + i + "\" /><label for=\"rdoApplyType" + i + "1\">是</label><input type=\"radio\" id=\"rdoApplyType" + i + "0\" name=\"rdoApplyType" + i + "\" /><label for=\"rdoApplyType" + i + "0\">否</label></td>");
            SbHtml.Append("<td><textarea id=\"txtCname" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtCommitment" + i + "\" style=\"width:90%;overflow: auto;\" rows=\"2\"></textarea></td>");

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
        T_OfficeAutomation_Document_CommissionAdjust t_OfficeAutomation_Document_CommissionAdjust = new T_OfficeAutomation_Document_CommissionAdjust();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                //MainID = "";
                IsNewApply = true;
            }
        }
        catch
        {
        }

        try
        {
            //if (MainID == "")
           
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
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "CommissionAdjust" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 27; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtBuilding.Text + " 坏账：" + txtAjustComm.Text;
                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Apply = EmployeeName;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ApplyID = txtApplyID.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Department = txtDepartment.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Building = txtBuilding.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ReplyPhone = txtReplyPhone.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_IsLawE = rdbIsLawE1.Checked ? 1 : 0;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Reason = txtReason.Text;

                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_BadCommDate = DateTime.Parse(txtBadCommDate.Text);
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Property = txtProperty.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Controler = txtControler.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_PropertyID = txtPropertyID.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_PropertyDate = txtPropertyDate.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_OldDeal = txtOldDeal.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_NewDeal = txtNewDeal.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_AjustDeal = txtAjustDeal.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ShouldComm = txtShouldComm.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ActualComm = txtActualComm.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_AjustComm = txtAjustComm.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_LeadReason = rdbLeadReason1.Checked ? 1 : 0;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Commitment = rdbCommitment1.Checked ? 0 : rdbCommitment2.Checked ? 1 : 2;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumShouldComm = txtSumShouldComm.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumAjustComm = txtSumAjustComm.Text;

                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumOldDeal = txtSumOldDeal.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumNewDeal = txtSumNewDeal.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumAjustDeal = txtSumAjustDeal.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumActualComm = txtSumActualComm.Text;
                t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Sign = ddlSign.SelectedValue;
                da_OfficeAutomation_Document_CommissionAdjust_Inherit.Insert(t_OfficeAutomation_Document_CommissionAdjust);//插入申请表

                InsertCommissionAdjustDetail(t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ID);

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

                //if (t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_MoneyCount > 20000)
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

                if (rdbIsLawE1.Checked)
                {
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow2 = new T_OfficeAutomation_Flow();
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Suggestion = "";

                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_EmployeeID = "13776,30792";
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Employee = "苏秉星,潘焕心";
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow2);
                    if (!string.IsNullOrEmpty(txtSumAjustComm.Text))
                  {
                      if (float.Parse(txtSumAjustComm.Text) >= 50000)
                      {
                          t_OfficeAutomation_Flow2.OfficeAutomation_Flow_ID = Guid.NewGuid();
                          t_OfficeAutomation_Flow2.OfficeAutomation_Flow_EmployeeID = "2377";
                          t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Employee = "陈洁丽";
                          t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Idx = 9;
                          da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow2);
                      }
                  }
                   
                }
                else
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 8);
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 9);
                }

                Common.AddLog(EmployeeID, EmployeeName, 31, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_CommissionAdjust_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
            Common.AddLog(EmployeeID, EmployeeName, 31, new Guid(MainID), 8);
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
        DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();
        DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit da_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_CommissionAdjust_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_CommissionAdjust_ID"].ToString(); 
        
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

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionAdjust_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_CommissionAdjust_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_CommissionAdjust_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_CommissionAdjust_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_CommissionAdjust_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>文件主题：关于" + drRow["OfficeAutomation_Document_CommissionAdjust_Building"].ToString() + "的应收佣金调整报告");
                    sbMailBody.Append("<br/>回复电话：020-" + drRow["OfficeAutomation_Document_CommissionAdjust_ReplyPhone"]);
                    sbMailBody.Append("<br/>坏账原因：" + drRow["OfficeAutomation_Document_CommissionAdjust_Reason"]);


                    sbMailBody.Append("<br/>变更日期：" + drRow["OfficeAutomation_Document_CommissionAdjust_BadCommDate"]);
                    sbMailBody.Append("<br/>物业成交编号：" + drRow["OfficeAutomation_Document_CommissionAdjust_PropertyID"]);
                    sbMailBody.Append("<br/>物业：" + drRow["OfficeAutomation_Document_CommissionAdjust_Property"]);
                    sbMailBody.Append("<br/>原成交价：" + drRow["OfficeAutomation_Document_CommissionAdjust_OldDeal"] + "，现成交价：" + drRow["OfficeAutomation_Document_CommissionAdjust_NewDeal"] + "，成交价调整：" + drRow["OfficeAutomation_Document_CommissionAdjust_AjustDeal"]);
                    sbMailBody.Append("<br/>应收佣金：" + drRow["OfficeAutomation_Document_CommissionAdjust_ShouldComm"] + "，实收佣金：" + drRow["OfficeAutomation_Document_CommissionAdjust_ActualComm"] + "，调整佣金：" + drRow["OfficeAutomation_Document_CommissionAdjust_AjustComm"]);

                    sbMailBody.Append("<br/>原成交价总额：" + drRow["OfficeAutomation_Document_CommissionAdjust_SumOldDeal"]);
                    sbMailBody.Append("<br/>现成交价总额：" + drRow["OfficeAutomation_Document_CommissionAdjust_SumNewDeal"]);
                    sbMailBody.Append("<br/>调整成交价总额：" + drRow["OfficeAutomation_Document_CommissionAdjust_SumAjustDeal"]);
                    sbMailBody.Append("<br/>应收佣金总额：" + drRow["OfficeAutomation_Document_CommissionAdjust_SumShouldComm"]);
                    sbMailBody.Append("<br/>实收佣金总额：" + drRow["OfficeAutomation_Document_CommissionAdjust_SumActualComm"]);
                    sbMailBody.Append("<br/>调整佣金总额：" + drRow["OfficeAutomation_Document_CommissionAdjust_SumAjustComm"]);
                    sbMailBody.Append("<br/>原因：" + drRow["OfficeAutomation_Document_CommissionAdjust_Reason"]);
                    sbMailBody.Append("<br/><br/>");

                    sbMailBody.Append("<br/>其它坏账详细情况：");

                    ds = da_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>经办人：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Controler"]);
                        sbMailBody.Append("<br/>物业成交编号：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID"]);
                        sbMailBody.Append("<br/>物业成交日期：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate"]);
                        sbMailBody.Append("<br/>原成交价：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal"]);
                        sbMailBody.Append("<br/>现成交价：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal"]);
                        sbMailBody.Append("<br/>成交价调整：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal"]);
                        sbMailBody.Append("<br/>应收佣金：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm"]);
                        sbMailBody.Append("<br/>实收佣金：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm"]);
                        sbMailBody.Append("<br/>调整佣金：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm"]);
                        sbMailBody.Append("<br/>客户名称：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Cname"]);
                        sbMailBody.Append("<br/>客户联系电话：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Commitment"]);
                        sbMailBody.Append("<br/>坏帐原因：" + dr["OfficeAutomation_Document_CommissionAdjust_Detail_Reason"]);
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
                            //employname = "吴惠卿,招健辉,叶凯蔓,陈婉娜"; //陈洁丽,
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
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody,MainID);
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
            DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();
            //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "34498" || EmployeeID == "20208" || EmployeeID == "43781")
            if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "34498" || EmployeeID == "20208" || EmployeeID == "43781" || EmployeeID == "61275")
                da_OfficeAutomation_Document_CommissionAdjust_Inherit.AddRemarkByID_II(MainID, CommonConst.SIGN_FINANCE);
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
        T_OfficeAutomation_Document_CommissionAdjust t_OfficeAutomation_Document_CommissionAdjust = new T_OfficeAutomation_Document_CommissionAdjust();
        DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_CommissionAdjust_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionAdjust_ID"].ToString();

        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ID = new Guid(ID);
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Apply = EmployeeName;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Building = txtBuilding.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_IsLawE = rdbIsLawE1.Checked ? 1 : 0;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Reason = txtReason.Text;

        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_BadCommDate = DateTime.Parse(txtBadCommDate.Text);
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Property = txtProperty.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Controler = txtControler.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_PropertyID = txtPropertyID.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_PropertyDate = txtPropertyDate.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_OldDeal = txtOldDeal.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_NewDeal = txtNewDeal.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_AjustDeal = txtAjustDeal.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ShouldComm = txtShouldComm.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_ActualComm = txtActualComm.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_AjustComm = txtAjustComm.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_LeadReason = rdbLeadReason1.Checked ? 1 : 0;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Commitment = rdbCommitment1.Checked ? 0 : rdbCommitment2.Checked ? 1 : 2;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumShouldComm = txtSumShouldComm.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumAjustComm = txtSumAjustComm.Text;

        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumOldDeal = txtSumOldDeal.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumNewDeal = txtSumNewDeal.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumAjustDeal = txtSumAjustDeal.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_SumActualComm = txtSumActualComm.Text;
        t_OfficeAutomation_Document_CommissionAdjust.OfficeAutomation_Document_CommissionAdjust_Sign = ddlSign.SelectedValue;
        da_OfficeAutomation_Document_CommissionAdjust_Inherit.Update(t_OfficeAutomation_Document_CommissionAdjust);//修改申请表

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        if (rdbIsLawE1.Checked)
        {
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 8);
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 9);

            T_OfficeAutomation_Flow t_OfficeAutomation_Flow2 = new T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Suggestion = "";

            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_EmployeeID = "13776,30792";
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Employee = "苏秉星,潘焕心";
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Idx = 8;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow2);

            if (!string.IsNullOrEmpty(txtSumAjustComm.Text))
            {
                if (float.Parse(txtSumAjustComm.Text) >= 50000)
                {
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_EmployeeID = "2377";
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Employee = "陈洁丽";
                    t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Idx = 9;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow2);
                }
            }
            
        }
        else
        {
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 8);
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 9);
        }

        string apply = "";
        string depname = txtDepartment.Text;
        string summary = txtBuilding.Text + " 坏账：" + txtAjustComm.Text;
        string applydate = "";
        string mainid = MainID;

        new DA_OfficeAutomation_Main_Inherit().UpdateMain(mainid, depname, apply, applydate, summary);

        DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit da_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit();
        da_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit.Delete(ID);
        InsertCommissionAdjustDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 31, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增应收佣金调整报告坏帐明细表

    /// <summary>
    /// 新增应收佣金调整报告坏帐明细表
    /// </summary>
    /// <param name="gCommissionAdjustID"></param>
    private void InsertCommissionAdjustDetail(Guid gCommissionAdjustID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_CommissionAdjust_Detail t_OfficeAutomation_Document_CommissionAdjust_Detail;
        DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit da_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_CommissionAdjust_Detail = new T_OfficeAutomation_Document_CommissionAdjust_Detail();
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_MainID = gCommissionAdjustID;
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_pNo = detail[0];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_Property = detail[1];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_Controler = detail[2];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID = detail[3];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate = detail[4];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal = detail[5];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal = detail[6];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal = detail[7];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm = detail[8];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm = detail[9];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm = detail[10];
                //t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason =null;
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_Cname = detail[11];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_Commitment = detail[12];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_Reason = detail[13];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_DealType = detail[14];
                t_OfficeAutomation_Document_CommissionAdjust_Detail.OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType = detail[15];

                da_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit.Insert(t_OfficeAutomation_Document_CommissionAdjust_Detail);
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
        Session["FLG_ReWrite33"] = "1";
        Response.Write("<script>window.open('Apply_CommissionAdjust_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("应收佣金调整报告.pdf"));//强制下载 
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
            //System.Data.OleDb.OleDbConnection ImportConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source=" + path + "; " + "Extended Properties='Excel 12.0;HDR=1; IMEX=1;'");
            //System.Data.OleDb.OleDbDataAdapter ImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [格式$]", ImportConnection);
            var dt = NPOIExcel.NPOIImportExcel(path);//读取数据
            DataSet ds = new DataSet();
            int i = 0;
            //try
            //{
                //ImportCommand.Fill(ds);
            ds.Tables.Add(dt);
            //}
            //catch
            //{
            //    Alert("格式错误");
            //    DrawDetailTable(1);
            //    //txtMoneyCount.Text = "";
            //    SbJs.Append("</script>");
            //    return;
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                //try
                //{
                string s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15;
                    bool b1;
                    int success = 0;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        s12 = ds.Tables[0].Rows[i]["认购日期"].ToString();
                        s1 = ds.Tables[0].Rows[i]["成交编号"].ToString();
                        s14 = ds.Tables[0].Rows[i]["成交类型"].ToString();
                        s2 = ds.Tables[0].Rows[i]["楼房单元"].ToString();
                        s3 = ds.Tables[0].Rows[i]["原成交价"].ToString();
                        s4 = ds.Tables[0].Rows[i]["现成交价"].ToString();
                        s5 = ds.Tables[0].Rows[i]["调整成交价"].ToString();
                        s6 = ds.Tables[0].Rows[i]["报数佣金"].ToString();
                        s7 = ds.Tables[0].Rows[i]["应收佣金"].ToString();
                        s8 = ds.Tables[0].Rows[i]["调整金额(元)"].ToString();
                        s9 = ds.Tables[0].Rows[i]["经办人"].ToString();
                        s10 = ds.Tables[0].Rows[i]["坏帐原因"].ToString();
                        //b1 = ds.Tables[0].Rows[i]["是否特殊调整"].ToString().Contains("是") ? true : false;
                        s15 = ds.Tables[0].Rows[i]["财务坏账类型"].ToString();
                        s13 = ds.Tables[0].Rows[i]["客户名称"].ToString();
                        s11 = ds.Tables[0].Rows[i]["客户电话"].ToString();

                        if (!string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s2))
                        {
                            success++;
                            SbJs.Append("$('#txtDetail_pNo" + success + "').html('" + success + "');");
                            SbJs.Append("$('#txtPropertyDate" + success + "').val('" + s12 + "');");
                            SbJs.Append("$('#txtPropertyID" + success + "').val('" + s1 + "');");
                            SbJs.Append("$('#txtDealType" + success + "').val('" + s14 + "');");
                            SbJs.Append("$('#txtProperty" + success + "').val('" + s2 + "');");
                            SbJs.Append("$('#txtOldDeal" + success + "').val('" + s3 + "');");
                            SbJs.Append("$('#txtNewDeal" + success + "').val('" + s4 + "');");
                            SbJs.Append("$('#txtAjustDeal" + success + "').val('" + s5 + "');");
                            SbJs.Append("$('#txtShouldComm" + success + "').val('" + s6 + "');");
                            SbJs.Append("$('#txtActualComm" + success + "').val('" + s7 + "');");
                            SbJs.Append("$('#txtAjustComm" + success + "').val('" + s8 + "');");
                            SbJs.Append("$('#txtControler" + success + "').val('" + s9 + "');");
                            SbJs.Append("$('#txtChangeReason" + success + "').val('" + s10 + "');");
                            SbJs.Append("$('#txtChangeType" + success + "').val('" + s15 + "');");
                            //SbJs.Append("$('#rdoApplyType" + success + (b1 ? "1" : "0") + "').attr('checked','checked');");
                            SbJs.Append("$('#txtCname" + success + "').val('" + s13 + "');");
                            SbJs.Append("$('#txtCommitment" + success + "').val('" + s11 + "');");
                        }

                        //if (sReportID == "业、客坏账金额合计：")
                        //    txtMoneyCount.Text = sOwnerBadMoney;
                    }

                    DrawDetailTable(success);
                //}
                //catch (System.Exception ex)
                //{
                //    Alert(ex.Message);
                //}
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
            //SYSREQ201805111537455255767 最后审批人可撤回申请结果，并可修改审批意见
            //if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
            //{
            //    RunJS("alert('该表已审批完毕，不能再撤回审核了');window.location.href='" + Page.Request.Url + "';");
            //    return;
            //}
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
            DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();
            DataSet ds = da_OfficeAutomation_Document_CommissionAdjust_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionAdjust_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_CommissionAdjust_Department"].ToString();
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
                        email = employnames[i2];if(email != "")
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
            DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();
            DataSet ds = da_OfficeAutomation_Document_CommissionAdjust_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionAdjust_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_CommissionAdjust_Department"].ToString();
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
                    email = employnames[i2];if(email != "")
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
            DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();
            DataSet ds = da_OfficeAutomation_Document_CommissionAdjust_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionAdjust_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_CommissionAdjust_Department"].ToString();
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
                    email = employnames[i2];if(email != "")
                    Common.SendMessageEX(false, email, "申请表已被" + EmployeeName + "修改了审批流程", msnBody, msnBody);
                }
            }
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 7); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_CommissionAdjust_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

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
            DA_OfficeAutomation_Document_CommissionAdjust_Inherit da_OfficeAutomation_Document_CommissionAdjust_Inherit = new DA_OfficeAutomation_Document_CommissionAdjust_Inherit();
            //if (Purview.Contains("OA_Special_002"))
            if (Purview.Contains("OA_Special_002") || EmployeeID == "61275")
            {
                da_OfficeAutomation_Document_CommissionAdjust_Inherit.AddRemarkByID_II(MainID, "（已标记）");
                RunJS("alert('标记成功。');window.location.href='" + Page.Request.Url + "';");
            }
        }
        catch
        {
            RunJS("alert('标记失败。');window.location.href='" + Page.Request.Url + "';");
        }
    }
}