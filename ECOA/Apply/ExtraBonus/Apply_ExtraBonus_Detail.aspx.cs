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

public partial class Apply_ExtraBonus_Apply_ExtraBonus_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml1 = new StringBuilder();
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbHtml3 = new StringBuilder();
    public StringBuilder SbHtml4 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public string ApplyN;

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
                if (Session["FLG_ReWrite8"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite8"] = null;
                }
            }
            catch
            {
            }
            //if (MainID != "")
            if (UrlMainID != "")
            {
                MainID = UrlMainID;
                LoadPage();
            }
            else
                InitPage();
            
        }
        //else
        //    GetAllDepartment();
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        string se = da_Employee_Inherit.GetEmployeeInfoByEmployeeID(EmployeeID).Tables[0].Rows[0]["K3UnitCode"].ToString();
        //if (!se.Contains("0001.001.002.003"))
        //    RunJS("alert('该申请表仅限于项目部使用！');window.location='/Apply/Apply_Search.aspx';");
        //GetAllDepartment();
        IsNewApply = true;

        MainID = Guid.NewGuid().ToString();
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
        DrawDetailTable(1, 1, 1);
        SbJs.Append("</script>");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ExtraBonus_Inherit da_OfficeAutomation_Document_ExtraBonus_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Inherit();
        DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit da_OfficeAutomation_Document_ExtraBonus_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit();

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

        SbJs.Append("<script type=\"text/javascript\">$(\"#spanApplyFor\").show();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ExtraBonus_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ExtraBonus_ID"].ToString();

        string applicant = dr["OfficeAutomation_Document_ExtraBonus_Apply"].ToString();
        ApplyN = applicant;
        lblApply.Text = applicant;
        txtDepartment.Value = dr["OfficeAutomation_Document_ExtraBonus_Department"].ToString();
        hdDepartmentID.Value = dr["OfficeAutomation_Document_ExtraBonus_DepartmentID"].ToString();
        txtApplyForID.Text = dr["OfficeAutomation_Document_ExtraBonus_ApplyForCode"].ToString();
        txtApplyFor.Value = dr["OfficeAutomation_Document_ExtraBonus_ApplyForName"].ToString();
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExtraBonus_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtReplyPhone.Text = dr["OfficeAutomation_Document_ExtraBonus_ReplyPhone"].ToString();
        txtProject.Text = dr["OfficeAutomation_Document_ExtraBonus_Project"].ToString();
        txtAgentStartDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExtraBonus_AgentStartDate"].ToString()).ToString("yyyy-MM-dd");
        txtAgentEndDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExtraBonus_AgentEndDate"].ToString()).ToString("yyyy-MM-dd");
        txtClientGuardStartDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate"].ToString()).ToString("yyyy-MM-dd");
        txtClientGuardEndDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate"].ToString()).ToString("yyyy-MM-dd");
        hdAgentRule.Value = dr["OfficeAutomation_Document_ExtraBonus_AgentRule"].ToString();
        txtApplyCashRewardValidityDurationStartDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate"].ToString()).ToString("yyyy-MM-dd");
        txtApplyCashRewardValidityDurationEndDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate"].ToString()).ToString("yyyy-MM-dd");
        if (dr["OfficeAutomation_Document_ExtraBonus_IsFullPay"].ToString() == "True")
            rdbFullPay.Checked = true;
        else
            rdbRatePay.Checked = true;
        hdRewardRule.Value = dr["OfficeAutomation_Document_ExtraBonus_RewardRule"].ToString();
        switch (dr["OfficeAutomation_Document_ExtraBonus_RewardPayTypeID"].ToString())
        {
            case "1":
                rdbRewardPayType1.Checked = true;
                break;
            case "2":
                rdbRewardPayType2.Checked = true;
                break;
            case "3":
                rdbRewardPayType3.Checked = true;
                break;
            default:
                break;
        }
        txtPayerName.Text = dr["OfficeAutomation_Document_ExtraBonus_PayerName"].ToString();
        txtPayerPosition.Text = dr["OfficeAutomation_Document_ExtraBonus_PayerPosition"].ToString();
        txtPayerPhone.Text = dr["OfficeAutomation_Document_ExtraBonus_PayerPhone"].ToString();
        txtRecevieCashRewardAccountName.Text = dr["OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName"].ToString();
        txtRecevieCashRewardAccounts.Text = dr["OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts"].ToString();
        if (dr["OfficeAutomation_Document_ExtraBonus_IsNeedPayFee"].ToString() == "True")
            rdbIsNeedPayFee.Checked = true;
        else
            rdbIsNotNeedPayFee.Checked = true;
        txtRewardPayTypeOtherCase.Value = dr["OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase"].ToString();
        if (dr["OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation"].ToString() == "True")
            this.rdbIsSubmitConfirmation.Checked = true;
        else
            rdbIsNotSubmitConfirmation.Checked = true;
        if(!string.IsNullOrEmpty(dr["OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate"].ToString()))
            txtAreaPromiseSubmitDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate"].ToString()).ToString("yyyy-MM-dd");

        //20141027+
        if (dr["OfficeAutomation_Document_ExtraBonus_JOrT"].ToString() == "1")
        {
            rdbJOrT1.Checked = true;
            txtSamePlaceXX1.Text = dr["OfficeAutomation_Document_ExtraBonus_SamePlaceXX1"].ToString();
            txtSamePlaceXX2.Text = dr["OfficeAutomation_Document_ExtraBonus_SamePlaceXX2"].ToString();
            txtAgencyFee1.Text = dr["OfficeAutomation_Document_ExtraBonus_AgencyFee1"].ToString();
            txtAgencyFee2.Text = dr["OfficeAutomation_Document_ExtraBonus_AgencyFee2"].ToString();
            if (dr["OfficeAutomation_Document_ExtraBonus_IsCashPrize1"].ToString() == "True")
            {
                rdbIsCashPrize11.Checked = true;
                txtCashPrize1.Text = dr["OfficeAutomation_Document_ExtraBonus_CashPrize1"].ToString();
            }
            else
                rdbIsCashPrize12.Checked = true;
            if (dr["OfficeAutomation_Document_ExtraBonus_IsCashPrize2"].ToString() == "True")
            {
                rdbIsCashPrize21.Checked = true;
                txtCashPrize2.Text = dr["OfficeAutomation_Document_ExtraBonus_CashPrize2"].ToString();
            }
            else
                rdbIsCashPrize22.Checked = true;

            if (dr["OfficeAutomation_Document_ExtraBonus_IsPFear1"].ToString() == "True")
            {
                rdbIsPFear11.Checked = true;
                txtPFear1.Text = dr["OfficeAutomation_Document_ExtraBonus_PFear1"].ToString();
            }
            else
                rdbIsPFear12.Checked = true;
            if (dr["OfficeAutomation_Document_ExtraBonus_IsPFear2"].ToString() == "True")
            {
                rdbIsPFear21.Checked = true;
                txtPFear2.Text = dr["OfficeAutomation_Document_ExtraBonus_PFear2"].ToString();
            }
            else
                rdbIsPFear22.Checked = true;
        }
        else if (dr["OfficeAutomation_Document_ExtraBonus_JOrT"].ToString() == "2")
        {
            rdbJOrT2.Checked = true;
            txtTurnsAgentXX1.Text = dr["OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1"].ToString();
            txtTurnsAgentXX2.Text = dr["OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2"].ToString();
            txtAgencyFee3.Text = dr["OfficeAutomation_Document_ExtraBonus_AgencyFee3"].ToString();
            txtAgencyFee4.Text = dr["OfficeAutomation_Document_ExtraBonus_AgencyFee4"].ToString();
            if (dr["OfficeAutomation_Document_ExtraBonus_IsCashPrize3"].ToString() == "True")
            {
                rdbIsCashPrize31.Checked = true;
                txtCashPrize3.Text = dr["OfficeAutomation_Document_ExtraBonus_CashPrize3"].ToString();
            }
            else
                rdbIsCashPrize32.Checked = true;
            if (dr["OfficeAutomation_Document_ExtraBonus_IsCashPrize4"].ToString() == "True")
            {
                rdbIsCashPrize41.Checked = true;
                txtCashPrize4.Text = dr["OfficeAutomation_Document_ExtraBonus_CashPrize4"].ToString();
            }
            else
                rdbIsCashPrize42.Checked = true;

            if (dr["OfficeAutomation_Document_ExtraBonus_IsPFear3"].ToString() == "True")
            {
                rdbIsPFear31.Checked = true;
                txtPFear3.Text = dr["OfficeAutomation_Document_ExtraBonus_PFear3"].ToString();
            }
            else
                rdbIsPFear32.Checked = true;
            if (dr["OfficeAutomation_Document_ExtraBonus_IsPFear4"].ToString() == "True")
            {
                rdbIsPFear41.Checked = true;
                txtPFear4.Text = dr["OfficeAutomation_Document_ExtraBonus_PFear4"].ToString();
            }
            else
                rdbIsPFear42.Checked = true;
            txtAgencyBeginDate1.Text = dr["OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1"].ToString();
            txtAgencyBeginDate2.Text = dr["OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2"].ToString();
            txtAgencyEndDate1.Text = dr["OfficeAutomation_Document_ExtraBonus_AgencyEndDate1"].ToString();
            txtAgencyEndDate2.Text = dr["OfficeAutomation_Document_ExtraBonus_AgencyEndDate2"].ToString();
        }
        else if (dr["OfficeAutomation_Document_ExtraBonus_JOrT"].ToString() == "3")
            rdbJOrT3.Checked = true;
        //20141027+

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        ds = da_OfficeAutomation_Document_ExtraBonus_Detail_Inherit.SelectByApplyID(ID);
        int detailCount = ds.Tables[0].Rows.Count;
        int agentRuleCount = Regex.Split(hdAgentRule.Value, "\\|\\|").Length;
        int rewardRuleCount = Regex.Split(hdRewardRule.Value, "\\|\\|").Length;

        DrawDetailTable(agentRuleCount, rewardRuleCount, detailCount);

        string[] details = Regex.Split(this.hdAgentRule.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            if (detail.Length == 3)
            {
                int n = i + 1;
                SbJs.Append("$('#txtAgentRuleSetNumber" + n + "').val('" + detail[0] + "');");
                SbJs.Append("$('#txtAgentRuleMoney" + n + "').val('" + detail[1] + "');");
                SbJs.Append("$('#txtAgentRuleAgentPoint" + n + "').val('" + detail[2] + "');");
            }
        }

        details = Regex.Split(this.hdRewardRule.Value, "\\|\\|");
        string ste = "";
        //DrawPlan(details);
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            if (detail.Length == 2)
            {
                int n = i + 1;
                SbJs.Append("$('#txtRewardRuleMoneyPerSet" + n + "').val('" + detail[0] + "');");
                SbJs.Append("$('#txtRewardRuleCondition" + n + "').val('" + detail[1] + "');");
            }
        }

        for (int n = 0; n < detailCount; n++)
        {
            dr = ds.Tables[0].Rows[n];

            int i = n + 1;

            SbJs.Append("$('#txtPayCondSetNumber" + i + "').val('" + dr["OfficeAutomation_Document_ExtraBonus_Detail_SetNumber"] + "');");
            SbJs.Append("$('#txtPayCondPriceRange" + i + "').val('" + dr["OfficeAutomation_Document_ExtraBonus_Detail_PriceRange"] + "');");
            SbJs.Append("$('#txtPayCondUnitPrice" + i + "').val('" + dr["OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice"] + "');");
            SbJs.Append("$('#txtPayCondActualComm" + i + "').val('" + dr["OfficeAutomation_Document_ExtraBonus_Detail_ActualComm"] + "');");
            SbJs.Append("$('#txtPayCondRewardScale" + i + "').val('" + dr["OfficeAutomation_Document_ExtraBonus_Detail_RewardScale"] + "');");
            SbJs.Append("$('#txtPayCondPayPerSet" + i + "').val('" + dr["OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet"] + "');");
            SbJs.Append("$('#txtPayCondPayActualScale" + i + "').val('" + dr["OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale"] + "');");

            ste += dr["OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet"].ToString() + "&,";
        }
        string[] details2 = Regex.Split(ste, ",");
        DrawPlan(details2);

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        if (isApplicant)
        {
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1")
            {
                btnSave.Visible = true;
                SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                btnSAlterC.Visible = true;
                SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
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

        #region 登录人为特定的人时，相应的编辑按钮开启。

        //if (EmployeeName == "杨小茵" || EmployeeName == "陈婉娜" || EmployeeName == "李红梅")
        //{
        //    GetAllDepartment();
        //    btnSave.Visible = true;
        //    SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
        //}

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。(暂未启用)

        //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
        //    btnSignSave.Visible = true;

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                string se = da_Employee_Inherit.GetEmployeeInfoByEmployeeID(EmployeeID).Tables[0].Rows[0]["K3UnitCode"].ToString();
                if(!se.Contains("0001.001.002.003"))
                    RunJS("alert('该申请表仅限于项目部使用！');window.location='/Apply/Apply_Search.aspx';");

                SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("</script>");

                MainID = Guid.NewGuid().ToString();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                flowState = "1";
                btnSAlterC.Visible = false;
                return;
            }
        }
        catch
        {
            if (isApplicant)
                btnReWrite.Visible = true; 
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = ds.Tables[0].Rows;
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
                    foreach (string s in auditorIDs) //20141202：CancelSign
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(),
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID))
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
        //    SbJs.Append("$('#trLogistics').show();$('#trGeneralManager').show();");

        //如果为未审核状态且登入人为申请人，开启编辑按钮
        //if (flowState == "1" && applicant == EmployeeName)
        //    SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        //if (flowState == "2" && applicant == EmployeeName) //20141215：M_AlterC
        //    btnEditFlow2.Visible = true;
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

        #endregion

        SbJs.Append("$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });");
        SbJs.Append("</script>");

        LoadAttach();
    }

    private void DrawPlan(string[] details)
    {
        SbHtml4.Append("<tr><th colspan=\"4\" style=\"line-height:25px;\" >物业部项目奖金分配方案</th></tr>");
        SbHtml4.Append("<tr><td colspan=\"4\" >");
        SbHtml4.Append("<table class=\"sample tc\" width='98%' style=\"margin:0 auto;\">");
        if (DateTime.Parse(lblApplyDate.Text) > DateTime.Parse("2014-10-31 00:00:00.999"))
            SbHtml4.Append("<tr><td>可发金额(元)</td><td>SALES(44%)</td><td>主管(15%)</td><td>区经(8%)</td><td>副总监/总监(O/R)(3%)</td><td>公司(30%)</td><td>合计(100%)</td></tr>");
        else
            SbHtml4.Append("<tr><td>可发金额(元)</td><td>SALES(50%)</td><td>主管(17%)</td><td>区经(9%)</td><td>副总监/总监(O/R)(4%)</td><td>公司(20%)</td><td>合计(100%)</td></tr>");

        for (int i = 0; i < details.Length - 1; i++)
        {
            //string[] detail = Regex.Split(details[i], "\\&\\&");
            string[] detail2 = Regex.Split(details[i], "&");
            if (detail2.Length == 2)
            {
                //double money = double.Parse(detail2[0]);//*-
                try
                {
                    double money = double.Parse(detail2[0]);
                    if (DateTime.Parse(lblApplyDate.Text) > DateTime.Parse("2014-10-31 00:00:00.999"))
                        SbHtml4.Append("<tr><td>" + money * 1 + "</td><td>" + money * 0.44 + "</td><td>" + money * 0.15 + "</td><td>" + money * 0.08 + "</td><td>" + money * 0.03 + "</td><td>" + money * 0.3 + "</td><td>" + money * 1 + "</td></tr>");
                    else
                        SbHtml4.Append("<tr><td>" + money * 1 + "</td><td>" + money * 0.5 + "</td><td>" + money * 0.17 + "</td><td>" + money * 0.09 + "</td><td>" + money * 0.04 + "</td><td>" + money * 0.2 + "</td><td>" + money * 1 + "</td></tr>");
                }
                catch
                {
                }
            }
        }
        SbHtml4.Append("</table><div class=\"tl PL10\">备注：公司所占30%按正常业绩，但不再计发佣金。</div></td></tr>");
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

    public void DrawDetailTable(int n1, int n2, int n3)
    {
        for (int i = 1; i <= n1; i++)
        {
            SbHtml1.Append("<tr id='trAgentRule" + i + "'>");
            SbHtml1.Append("     <td><input type=\"text\" id=\"txtAgentRuleSetNumber" + i + "\" style=\"width:90px\"/></td>");
            SbHtml1.Append("     <td><input type=\"text\" id=\"txtAgentRuleMoney" + i + "\" style=\"width:90px\"/></td>");
            SbHtml1.Append("     <td><input type=\"text\" id=\"txtAgentRuleAgentPoint" + i + "\" style=\"width:90%\"/></td>");
            SbHtml1.Append("</tr>");
        }
        SbJs.Append("i1=" + n1 + ";");

        for (int i = 1; i <= n2; i++)
        {
            SbHtml2.Append("<tr id='trRewardRule" + i + "'  style=\"border:none;\">");
            SbHtml2.Append("     <td style=\"border:none;\"><input type=\"text\" id=\"txtRewardRuleMoneyPerSet" + i + "\" style=\"width:90px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\"/>元/套，发放条件是<input type=\"text\" id=\"txtRewardRuleCondition" + i + "\" style=\"width:290px\"/></td>");
            SbHtml2.Append("</tr>");
        }
        SbJs.Append("i2=" + n2 + ";");

        for (int i = 1; i <= n3; i++)
        {
            SbHtml3.Append("<tr id='trPayCond" + i + "'>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtPayCondSetNumber" + i + "\" style=\"width:90%\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtPayCondPriceRange" + i + "\" style=\"width:90%\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtPayCondUnitPrice" + i + "\" style=\"width:90%\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtPayCondActualComm" + i + "\" style=\"width:90%\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtPayCondRewardScale" + i + "\" style=\"width:90%\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtPayCondPayPerSet" + i + "\" style=\"width:90%\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtPayCondPayActualScale" + i + "\" style=\"width:90%\"/></td>");
            SbHtml3.Append("</tr>");
        }
        SbJs.Append("i3=" + n3 + ";");
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
        T_OfficeAutomation_Document_ExtraBonus t_OfficeAutomation_Document_ExtraBonus = new T_OfficeAutomation_Document_ExtraBonus();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ExtraBonus_Inherit da_OfficeAutomation_Document_ExtraBonus_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Inherit();
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

                //t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ExtraBonus" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 17;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                //da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                t_OfficeAutomation_Document_ExtraBonus = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Value;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = this.txtProject.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_ExtraBonus_Inherit.Add(t_OfficeAutomation_Document_ExtraBonus);//插入申请表

                InsertExtraBonusDetail(t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ID);

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
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 21, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ExtraBonus_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
        DA_OfficeAutomation_Document_ExtraBonus_Inherit da_OfficeAutomation_Document_ExtraBonus_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Inherit();
        DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit da_OfficeAutomation_Document_ExtraBonus_Detail_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_ExtraBonus_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ExtraBonus_ID"].ToString();

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

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                bool isSignSuccess = da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExtraBonus_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ExtraBonus_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_ExtraBonus_ApplyForName"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_ExtraBonus_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ExtraBonus_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>回复电话：" + drRow["OfficeAutomation_Document_ExtraBonus_ReplyPhone"]);
                    sbMailBody.Append("<br/><br/>项目名称: " + drRow["OfficeAutomation_Document_ExtraBonus_Project"]);
                    sbMailBody.Append("<br/>项目代理期: " + drRow["OfficeAutomation_Document_ExtraBonus_AgentStartDate"] + "~" + drRow["OfficeAutomation_Document_ExtraBonus_AgentEndDate"]);
                    sbMailBody.Append("<br/>客户保护期: " + drRow["OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate"] + "~" + drRow["OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate"]);
                    sbMailBody.Append("<br/>申请现金奖有效期: " + drRow["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate"] + "~" + drRow["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate"]);
                    sbMailBody.Append("<br/>其他详细申请资料请见申请表");

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
                                        msnBody = "您好，" + employnames[i] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        email = employnames[i];
                                        if (hdIsAgree.Value == "2")
                                            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                        else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                        employeeList += employnames[i] + "||";
                                    }
                                }
                            }
                            if (EmployeeID == "0001")
                                employeeList += "黄轩明" + "||";

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //总办4张表(减佣让佣，物业部承接一手项目报备，项目费用，合作费)完成后需抄送给的人:黄筑筠,谢芃,李红梅,张绍欣,黄瑛
                            //employname = "黄筑筠,谢芃,罗蔼蕴,李红梅,张绍欣,黄瑛,宁伟雄,冯琰,黄洁珍,陈婉娜,钟惠贤"; //CommonConst.EMP_GMO_COPYTO_NAME + 
                            if (employeeList.Contains("黄轩明"))
                                employname = CommonConst.EMP_GMO_COPYTO_NAME + ",宁伟雄,冯琰,黄洁珍,陈婉娜,钟惠贤,官东升,钟惠贤,钟惠贤";
                            else
                                employname = "宁伟雄,冯琰,黄洁珍,陈婉娜,钟惠贤,官东升";
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    email = employnames[i];
                                    if (hdIsAgree.Value == "2")
                                        Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                    else
                                        Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                    employeeList += employnames[i] + "||";
                                }
                            }

                            email = CommonConst.EMP_LAW_OPERATOR_NAME;
                            msnBody = "您好，" + email + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);
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
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody,MainID);
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
        string commType = e.CommandName;
        switch (commType)
        {
            case "Del":
                Alert("删除附件" + (da_OfficeAutomation_Attach_Inherit.Delete(e.CommandArgument.ToString()) ? "成功!" : "失败!"));
                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(MainID), 3);
                break;
        }

        LoadPage();
    }

    #endregion

    #endregion

    #region 从页面中获得model

    private T_OfficeAutomation_Document_ExtraBonus GetModelFromPage(Guid ExtraBonusID)
    {
        T_OfficeAutomation_Document_ExtraBonus t_OfficeAutomation_Document_ExtraBonus = new T_OfficeAutomation_Document_ExtraBonus();
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ID = ExtraBonusID;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_Apply = EmployeeName;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ApplyForName = txtApplyFor.Value;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ApplyForCode = txtApplyForID.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_Department = txtDepartment.Value;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_DepartmentID = new Guid(hdDepartmentID.Value);
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ReplyPhone = txtReplyPhone.Text;

        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_Project = txtProject.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgentStartDate = DateTime.Parse(txtAgentStartDate.Text);
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgentEndDate = DateTime.Parse(txtAgentEndDate.Text);
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate = DateTime.Parse(txtClientGuardStartDate.Text);
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate = DateTime.Parse(txtClientGuardEndDate.Text);
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgentRule = hdAgentRule.Value;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate = DateTime.Parse(txtApplyCashRewardValidityDurationStartDate.Text);
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate = DateTime.Parse(txtApplyCashRewardValidityDurationEndDate.Text);
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsFullPay = rdbFullPay.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_RewardRule = hdRewardRule.Value;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_RewardPayTypeID = rdbRewardPayType1.Checked ? 1 : rdbRewardPayType2.Checked ? 2 : 3;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_PayerName = txtPayerName.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_PayerPosition = txtPayerPosition.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_PayerPhone = txtPayerPhone.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName = txtRecevieCashRewardAccountName.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts = txtRecevieCashRewardAccounts.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsNeedPayFee = rdbIsNeedPayFee.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase = txtRewardPayTypeOtherCase.Value;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation = rdbIsSubmitConfirmation.Checked;

        //20141027+
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_JOrT = rdbJOrT1.Checked ? 1 : rdbJOrT2.Checked ? 2 : rdbJOrT3.Checked ? 3 : 0;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_SamePlaceXX1 = txtSamePlaceXX1.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_SamePlaceXX2 = txtSamePlaceXX2.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1 = txtTurnsAgentXX1.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2 = txtTurnsAgentXX2.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgencyFee1 = txtAgencyFee1.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgencyFee2 = txtAgencyFee2.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgencyFee3 = txtAgencyFee3.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgencyFee4 = txtAgencyFee4.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsCashPrize1 = rdbIsCashPrize11.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsCashPrize2 = rdbIsCashPrize21.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsCashPrize3 = rdbIsCashPrize31.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsCashPrize4 = rdbIsCashPrize41.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_CashPrize1 = txtCashPrize1.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_CashPrize2 = txtCashPrize2.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_CashPrize3 = txtCashPrize3.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_CashPrize4 = txtCashPrize4.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1 = txtAgencyBeginDate1.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2 = txtAgencyBeginDate2.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgencyEndDate1 = txtAgencyEndDate1.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AgencyEndDate2 = txtAgencyEndDate2.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsPFear1 = rdbIsPFear11.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsPFear2 = rdbIsPFear21.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsPFear3 = rdbIsPFear31.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_IsPFear4 = rdbIsPFear41.Checked;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_PFear1 = txtPFear1.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_PFear2 = txtPFear2.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_PFear3 = txtPFear3.Text;
        t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_PFear4 = txtPFear4.Text;
        //20141027+

        if(!string.IsNullOrEmpty(txtAreaPromiseSubmitDate.Text))
            t_OfficeAutomation_Document_ExtraBonus.OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate = DateTime.Parse(txtAreaPromiseSubmitDate.Text);
        return t_OfficeAutomation_Document_ExtraBonus;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_ExtraBonus t_OfficeAutomation_Document_ExtraBonus = new T_OfficeAutomation_Document_ExtraBonus();
        DA_OfficeAutomation_Document_ExtraBonus_Inherit da_OfficeAutomation_Document_ExtraBonus_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ExtraBonus_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExtraBonus_ID"].ToString();

        t_OfficeAutomation_Document_ExtraBonus = GetModelFromPage(new Guid(ID));

        string apply = "";
        string depname = this.txtDepartment.Value;
        string summary = this.txtProject.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_ExtraBonus_Inherit.Update(t_OfficeAutomation_Document_ExtraBonus);//修改申请表

        DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit da_OfficeAutomation_Document_ExtraBonus_Detail_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit();
        da_OfficeAutomation_Document_ExtraBonus_Detail_Inherit.Delete(new Guid(ID));
        InsertExtraBonusDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 21, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增申请明细

    /// <summary>
    /// 新增申请明细
    /// </summary>
    /// <param name="gExtraBonusID"></param>
    private void InsertExtraBonusDetail(Guid gExtraBonusID)
    {
        T_OfficeAutomation_Document_ExtraBonus_Detail t_OfficeAutomation_Document_ExtraBonus_Detail;
        DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit da_OfficeAutomation_Document_ExtraBonus_Detail_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit();

        string[] details = Regex.Split(this.hdPayCond.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_ExtraBonus_Detail = new T_OfficeAutomation_Document_ExtraBonus_Detail();
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_MainID = gExtraBonusID;
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_SetNumber = detail[0];
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_PriceRange = detail[1];
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice = detail[2];
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_ActualComm = detail[3];
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_RewardScale = detail[4];
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet = detail[5];
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale = detail[6];
            t_OfficeAutomation_Document_ExtraBonus_Detail.OfficeAutomation_Document_ExtraBonus_Detail_OrderBy = i;
            da_OfficeAutomation_Document_ExtraBonus_Detail_Inherit.Add(t_OfficeAutomation_Document_ExtraBonus_Detail);
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
    }
    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite8"] = "1";
        Response.Write("<script>window.open('Apply_ExtraBonus_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("项目发展商额外奖金报备.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
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
            DA_OfficeAutomation_Document_ExtraBonus_Inherit da_OfficeAutomation_Document_ExtraBonus_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ExtraBonus_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExtraBonus_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ExtraBonus_Department"].ToString();
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
            DA_OfficeAutomation_Document_ExtraBonus_Inherit da_OfficeAutomation_Document_ExtraBonus_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ExtraBonus_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExtraBonus_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ExtraBonus_Department"].ToString();
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
            DA_OfficeAutomation_Document_ExtraBonus_Inherit da_OfficeAutomation_Document_ExtraBonus_Inherit = new DA_OfficeAutomation_Document_ExtraBonus_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ExtraBonus_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExtraBonus_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ExtraBonus_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 3); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_ExtraBonus_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
}