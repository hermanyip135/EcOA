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
using System.Collections;//789

public partial class Apply_SpecialCase_Apply_SpecialCase_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbJsonf = new StringBuilder();//789
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();
    public string ApplyN;
    public string flowsadd = "", flowsl = "0";

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
        GetManagers();//789
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
                if (Session["FLG_ReWrite53"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite53"] = null;
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
        txtApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        //lbData.Text = lblApplyDate.Text;
        SbJs.Append("<script type=\"text/javascript\">");
        //DrawDetailTable(0);
        //SbJs.Append("$(\"#btnUpload\").show();");
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
        DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();

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
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_SpecialCase_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_SpecialCase_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_SpecialCase_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_SpecialCase_Department"].ToString();
        txtApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_SpecialCase_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtBranchNo.Text = dr["OfficeAutomation_Document_SpecialCase_BranchNo"].ToString();
        txtPhone.Text = dr["OfficeAutomation_Document_SpecialCase_Phone"].ToString();
        ddlFollowDepartment.SelectedValue = dr["OfficeAutomation_Document_SpecialCase_FollowDepartment"].ToString();
        txtLocation.Text = dr["OfficeAutomation_Document_SpecialCase_Location"].ToString();
        txtMaster.Text = dr["OfficeAutomation_Document_SpecialCase_Master"].ToString();
        txtBuyer.Text = dr["OfficeAutomation_Document_SpecialCase_Buyer"].ToString();
        txtLoan.Text = dr["OfficeAutomation_Document_SpecialCase_Loan"].ToString();
        if (dr["OfficeAutomation_Document_SpecialCase_QuickPut"].ToString() == "1")
            rdbQuickPut1.Checked = true;
        else if (dr["OfficeAutomation_Document_SpecialCase_QuickPut"].ToString() == "2")
            rdbQuickPut2.Checked = true;
        txtGuaranteeCompany.Text = dr["OfficeAutomation_Document_SpecialCase_GuaranteeCompany"].ToString();
        FollowSomebodyAdd(dr["OfficeAutomation_Document_SpecialCase_FollowSomebody"].ToString());
        if (dr["OfficeAutomation_Document_SpecialCase_PayWay"].ToString() == "1")
            rdbPayWay1.Checked = true;
        else if (dr["OfficeAutomation_Document_SpecialCase_PayWay"].ToString() == "2")
        {
            rdbPayWay2.Checked = true;
            Lb1.Visible = true;
            //Lb2.Visible = true;
            Lb3.Visible = true;
        }
        else if (dr["OfficeAutomation_Document_SpecialCase_PayWay"].ToString() == "3")
            rdbPayWay3.Checked = true;

        string cbt = dr["OfficeAutomation_Document_SpecialCase_ApplyNo"].ToString();
        string cbi = null;
        if (cbt.Contains("1a"))
        {
            cbApplyNo1.Checked = true;
            cbi = dr["OfficeAutomation_Document_SpecialCase_TimeoutApply"].ToString();
            if (cbi.Contains("1"))
                cbTimeoutApply1.Checked = true;
            if (cbi.Contains("2"))
                cbTimeoutApply2.Checked = true;
            if (cbi.Contains("3"))
                cbTimeoutApply3.Checked = true;
            ddlForPeople.SelectedValue = dr["OfficeAutomation_Document_SpecialCase_ForPeople"].ToString();
        }
        if (cbt.Contains("2a"))
        {
            cbApplyNo2.Checked = true;
            txtAutoHandle.Text = dr["OfficeAutomation_Document_SpecialCase_AutoHandle"].ToString();
            cbi = dr["OfficeAutomation_Document_SpecialCase_CaseRemark"].ToString();
            if (cbi.Contains("1"))
                cbCaseRemark1.Checked = true;
            if (cbi.Contains("2"))
                cbCaseRemark2.Checked = true;
            if (cbi.Contains("3"))
                cbCaseRemark3.Checked = true;
            if (cbi.Contains("4"))
                cbCaseRemark4.Checked = true;
        }
        if (cbt.Contains("3a"))
        {
            cbApplyNo3.Checked = true;
            cbi = dr["OfficeAutomation_Document_SpecialCase_HousingTransactions"].ToString();
            if (cbi.Contains("1"))
                cbHousingTransactions1.Checked = true;
            if (cbi.Contains("2"))
                cbHousingTransactions2.Checked = true;
            txtDealWithProgress.Text = dr["OfficeAutomation_Document_SpecialCase_DealWithProgress"].ToString();
        }
        if (cbt.Contains("4a"))
        {
            cbApplyNo4.Checked = true;
            cbi = dr["OfficeAutomation_Document_SpecialCase_Midway"].ToString();
            if (cbi.Contains("1"))
                cbMidway1.Checked = true;
            if (cbi.Contains("2"))
                cbMidway2.Checked = true;
            if (cbi.Contains("3"))
                cbMidway3.Checked = true;
            cbi = dr["OfficeAutomation_Document_SpecialCase_PutUp"].ToString();
            if (cbi.Contains("1"))
                cbPutUp1.Checked = true;
            if (cbi.Contains("2"))
                cbPutUp2.Checked = true;
            if (cbi.Contains("3"))
                cbPutUp3.Checked = true;
            if (cbi.Contains("4"))
            {
                cbPutUp4.Checked = true;
                txtAnotherPutUp.Text = dr["OfficeAutomation_Document_SpecialCase_AnotherPutUp"].ToString();
            }
            txt4PointGuaranteeCompany.Text = dr["OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany"].ToString();
            cbi = dr["OfficeAutomation_Document_SpecialCase_CompanyEarnings"].ToString();
            if (cbi.Contains("1"))
                rdbCompanyEarnings1.Checked = true;
            if (cbi.Contains("0"))
            {
                rdbCompanyEarnings2.Checked = true;
                txtEarningsAmount.Text = dr["OfficeAutomation_Document_SpecialCase_EarningsAmount"].ToString();
            }
        }
        if (cbt.Contains("5a"))
        {
            cbApplyNo5.Checked = true;
            cbi = dr["OfficeAutomation_Document_SpecialCase_TheKindOfFormalities"].ToString();
            if (cbi.Contains("1"))
                cbTheKindOfFormalities1.Checked = true;
            if (cbi.Contains("2"))
                cbTheKindOfFormalities2.Checked = true;
        }
        if (cbt.Contains("6a"))
        {
            cbApplyNo6.Checked = true;
            cbi = dr["OfficeAutomation_Document_SpecialCase_Certificate"].ToString();
            if (cbi.Contains("1"))
                cbCertificate1.Checked = true;
            if (cbi.Contains("2"))
                cbCertificate2.Checked = true;
            if (cbi.Contains("3"))
                cbCertificate3.Checked = true;
            if (cbi.Contains("4"))
                cbCertificate4.Checked = true;
            if (cbi.Contains("5"))
                cbCertificate5.Checked = true;
        }
        if (cbt.Contains("7a"))
        {
            cbApplyNo7.Checked = true;
            cbi = dr["OfficeAutomation_Document_SpecialCase_NotarialDeed"].ToString();
            //if (cbi.Contains("1"))
            //    cbNotarialDeed1.Checked = true;
            if (cbi.Contains("2"))
                cbNotarialDeed2.Checked = true;
            //if (cbi.Contains("3"))
            //    cbNotarialDeed3.Checked = true;
            //if (cbi.Contains("4"))
            //{
            //    cbNotarialDeed4.Checked = true;
            //    txtCommissionedPersonnel.Text = dr["OfficeAutomation_Document_SpecialCase_CommissionedPersonnel"].ToString();
            //}
            //if (cbi.Contains("5"))
            //{
            //    cbNotarialDeed5.Checked = true;
            //    txtClause.Text = dr["OfficeAutomation_Document_SpecialCase_Clause"].ToString();
            //}
        }
        if (cbt.Contains("8a"))
        {
            cbApplyNo8.Checked = true;
            cbi = dr["OfficeAutomation_Document_SpecialCase_NotNeat"].ToString();
            if (cbi.Contains("1"))
                cbNotNeat1.Checked = true;
            if (cbi.Contains("2"))
                cbNotNeat2.Checked = true;
            txtJieFeeDate.Text = dr["OfficeAutomation_Document_SpecialCase_JieFeeDate"].ToString();
        }
        if (cbt.Contains("9a"))
        {
            cbApplyNo9.Checked = true;
            txtcredit.Text = dr["OfficeAutomation_Document_SpecialCase_credit"].ToString();
        }
        //if (cbt.Contains("10"))
        //{
        //    cbApplyNo10.Checked = true;
        //    txtAnother.Text = dr["OfficeAutomation_Document_SpecialCase_Another"].ToString();
        //}
        if (cbt.Contains("11"))
            cbApplyNo11.Checked = true;
        if (cbt.Contains("12"))
            cbApplyNo12.Checked = true;
        if (cbt.Contains("13"))
            cbApplyNo13.Checked = true;
        if (cbt.Contains("14"))
            cbApplyNo14.Checked = true;
        if (cbt.Contains("15"))
            cbApplyNo15.Checked = true;
        if (cbt.Contains("16"))
            cbApplyNo16.Checked = true;
        if (cbt.Contains("17"))
            cbApplyNo17.Checked = true;
        if (cbt.Contains("18"))
            cbApplyNo18.Checked = true;
        if (cbt.Contains("19"))
            cbApplyNo19.Checked = true;
        if (cbt.Contains("20"))
            cbApplyNo20.Checked = true;
        if (cbt.Contains("21"))
            cbApplyNo21.Checked = true;
        if (cbt.Contains("22"))
            cbApplyNo22.Checked = true;
        if (cbt.Contains("23"))
            cbApplyNo23.Checked = true;
        if (cbt.Contains("24"))
            cbApplyNo24.Checked = true;
        if (cbt.Contains("25"))
            cbApplyNo25.Checked = true;
        if (cbt.Contains("26"))
            cbApplyNo26.Checked = true;
        //if (cbt.Contains("27"))
        //    cbApplyNo27.Checked = true;

        txtSituation.Text = dr["OfficeAutomation_Document_SpecialCase_Situation"].ToString();
        txtBorrowDate.Text = dr["OfficeAutomation_Document_SpecialCase_BorrowDate"].ToString();
        txtBorrowS.Text = dr["OfficeAutomation_Document_SpecialCase_BorrowS"].ToString();
        txtReturnDate.Text = dr["OfficeAutomation_Document_SpecialCase_ReturnDate"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        if (isApplicant)
        {
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                //SbJs.Append(ApplyDisplayPart);
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
            }
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
                //SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnPrint\").hide();$(\"#btnUpload\").hide();");
                SbJs.Append("</script>");
                GetAllDepartment();
                //txtDepartment.Text = "";
                btnSPDF.Visible = false; //M_PDF
                txtApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //lbData.Text = lblApplyDate.Text;
                flowState = "1";
                btnSAlterC.Visible = false;
                btnSave.Visible = true;
                IsNewApply = true;
                rdbQuickPut1.Checked = false;
                rdbQuickPut2.Checked = false;
                //if (cbNotarialDeed5.Checked)
                //{
                //    RunJS("alert('若要选择增减条款，则需上传《客户签名确认书》！');");
                //    cbNotarialDeed5.Checked = false;
                //}
                MainID = Guid.NewGuid().ToString();
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

        T_OfficeAutomation_Flow flows, flows2, flows3, flows4;
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        if (Purview.Contains("OA_Search_002"))//789
            GetAllDepartment();
        if (cbt.Contains("10"))
        {
            if (EmployeeID == "573" || EmployeeID == "3734" || EmployeeID == "34498")
                SbJs.Append("$(\"#TSD1\").show();");
        }
        //foreach (DataRow drs in drc)
        //{
        //    string idx = drs["OfficeAutomation_Flow_Idx"].ToString();
        //    if (!Regex.IsMatch(((float.Parse(idx) - 1) / 3.0).ToString(), "^[0-9]*[1-9][0-9]*$"))
        //        SbJs.Append("$('#divIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();$('#divTxtIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();");
        //    SbJs.Append("$('#txtIDxa" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_Employee"] + ",');");
        //    //SbJs.Append("$('#hdIDx" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_EmployeeID"] + "');");
        //}
        DataSet ds2 = new DataSet();
        bool x2 = false, x3 = false;
        ds2 = da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SelectByID(ID);
        int LogisticsFlowCount = ds2.Tables[0].Rows.Count;
        ViewState["FSIN"] = "";
        if (LogisticsFlowCount == 0)
        {
            //if (isApplicant)
            //    DrawDetailTable(1);
        }
        else
        {
            //if (isApplicant)
            //    DrawDetailTable(LogisticsFlowCount / 3);
            for (int n = 0, i = 1; n < LogisticsFlowCount; n++, i++)
            {
                dr = ds2.Tables[0].Rows[n];
                SbJs.Append("$('#txtDpm" + i + "').val('" + dr["OfficeAutomation_Document_GeneralApply_Detail_Department"] + "');");
                SbJs.Append("$('#rdoIsCmodel" + i + "1" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                n++;
                dr = ds2.Tables[0].Rows[n];
                x2 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + i + "2" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                n++;
                dr = ds2.Tables[0].Rows[n];
                x3 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + i + "3" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                DrawAFTable(i, x2, x3, dr["OfficeAutomation_Document_GeneralApply_Detail_Department"].ToString());
            }
        }//987
        
        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

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
                        case "8":
                            SbJs.Append("$(\"#IsMasterE\").show();");
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
            //string[] auditor = drc[i]["OfficeAutomation_Flow_Employee"].ToString().Split(',');
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:0px;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                foreach (string s in auditorIDs)
                {
                    if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                    {
                        SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                    }
                    SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" style=\"margin-left:10px;margin-top:20px;\" />");
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
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:20px;\">"
                                        + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" style=\"margin-left:10px;margin-top:20px;\" />");
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

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
        if (flows != null)
        {
            flowsl += "1";
            SbJs.Append("$('#trM1').show();");
        }
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2);
        if (flows != null)
        {
            flowsl += "2";
            SbJs.Append("$('#trM2').show();");
        }
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        if (flows != null)
        {
            flowsl += "3";
            SbJs.Append("$('#trM3').show();");
        }
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        if (flows != null)
        {
            flowsl += "4";
            SbJs.Append("$('#trM4').show();");
        }
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 5);
        if (flows != null)
            SbJs.Append("$('#trM5').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 6);
        if (flows != null)
            SbJs.Append("$('#trM6').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 7);
        if (flows != null)
            SbJs.Append("$('#trM7').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
        if (flows != null)
            SbJs.Append("$('#trM8').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 9);
        if (flows != null)
            SbJs.Append("$('#trM9').show();");

        ////如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        //if (flag3)
        //SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();$('#trGeneralManager').show();");

        ////T_OfficeAutomation_Flow flows;//789
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        //if (flows != null)
        //    SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 61);
        //if (flows == null)
        //{
        //    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
        //    flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2);
        //    flows3 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        //    flows4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        //    if (flows != null || flows2 != null || flows3 != null || flows4 != null)
        //    {
                if (flowState == "1" && applicant == EmployeeName)
                    SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
                if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
                    btnEditFlow2.Visible = true;
        //    }
        //}
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

        //if (DateTime.Parse(lblApplyDate.Text) > DateTime.Parse("2015-03-20 11:35:00.000"))
        //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5"); //M_Del21392：20150320

        ChangeCb();
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
        T_OfficeAutomation_Document_SpecialCase t_OfficeAutomation_Document_SpecialCase = new T_OfficeAutomation_Document_SpecialCase();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion

        //try
        //{
        //    if (ViewState["FLG_ReWrite"].ToString() == "1") 
        //    {
        //        //MainID = "";
        //        IsNewApply = true;
        //    }
        //}
        //catch
        //{
        //}

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

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "SpecialCase" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 48; //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                t_OfficeAutomation_Document_SpecialCase = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtLocation.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_SpecialCase_Inherit.Insert(t_OfficeAutomation_Document_SpecialCase);//插入申请表

                //InsertSpecialCaseDetail(t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_ID);

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                #region 根据默认流程表中的固定环节添加流程

                //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString());
                //if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        if (string.IsNullOrEmpty(dr["OfficeAutomation_Document_Flow_Position"].ToString()))
                //        {
                //            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = dr["OfficeAutomation_Document_Flow_AuditCode"].ToString();
                //            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = dr["OfficeAutomation_Document_Flow_AuditName"].ToString();
                //        }

                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(dr["OfficeAutomation_Document_Flow_Idx"].ToString());

                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //AddFlows();
                specialFlows();
                #endregion

                #endregion

                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5"); //M_Del21392：20150320

                Common.AddLog(EmployeeID, EmployeeName, 52, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                string sd5 = "window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");";
                //if (cbNotarialDeed5.Checked)
                //    sd5 = "";
                if (!flowsadd.Contains("1") && !flowsadd.Contains("2") && !flowsadd.Contains("3") && !flowsadd.Contains("4") && flowsadd != "A")
                    RunJS("alert('申请表保存成功。');" + sd5 + "window.location='/Apply/Apply_Search.aspx';");
                else if (flowsadd != "A")
                    RunJS(sd5 + "var win=window.showModalDialog(\"Apply_SpecialCase_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + flowsadd + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                else
                    RunJS("alert('申请表保存成功，稍后会由汇瀚客服中心主管来编辑审批流程！');" + sd5 + "window.location='/Apply/Apply_Search.aspx';");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    Update();
                    if (!flowsadd.Contains("1") && !flowsadd.Contains("2") && !flowsadd.Contains("3") && !flowsadd.Contains("4") && flowsadd != "A")
                        RunJS("alert('保存成功。');window.location='/Apply/Apply_Search.aspx';");
                    else if (flowsadd != "A")
                        RunJS("alert('保存成功！');var win=window.showModalDialog(\"Apply_SpecialCase_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + flowsadd + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                    else
                        RunJS("alert('申请表保存成功，稍后会由汇瀚客服中心主管来编辑审批流程！');window.location='/Apply/Apply_Search.aspx';");
                    //RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
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
        DataSet dsg = new DataSet(); //20150105：M_DeleteC
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
        dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
        if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
            return;
        }
        DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();

        DataSet ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_SpecialCase_ID"].ToString(); 
        
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

                if (flowIDx == "8")
                {
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    T_OfficeAutomation_Flow flows;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                    if (rdbMasterE1.Checked)//增加审批环节
                    {
                        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 9);
                        if (flows == null)
                        {
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13161";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "曹颖思";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;

                            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        }
                    }
                    else if (rdbMasterE2.Checked)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9");
                    }
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                //如果为第0步流程则为其一审核即可通过，其他为同时审核。
                //bool isSignSuccess = flowIDx == "0" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "0" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody = "";

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_SpecialCase_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_SpecialCase_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_SpecialCase_Department"]);
                    sbMailBody.Append("<br/>发文日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_SpecialCase_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>汇瀚内部编号：" + drRow["OfficeAutomation_Document_SpecialCase_ApplyID"]);
                    sbMailBody.Append("<br/>运作中心/业务分部号：" + drRow["OfficeAutomation_Document_SpecialCase_BranchNo"]);
                    sbMailBody.Append("<br/>联系电话：" + drRow["OfficeAutomation_Document_SpecialCase_Phone"]);

                    sbMailBody.Append("<br/>汇瀚跟进部门：" + drRow["OfficeAutomation_Document_SpecialCase_FollowDepartment"]);
                    sbMailBody.Append("<br/>汇瀚跟进人：" + drRow["OfficeAutomation_Document_SpecialCase_FollowSomebody"]);
                    sbMailBody.Append("<br/>物业地址：" + drRow["OfficeAutomation_Document_SpecialCase_Location"]);
                    sbMailBody.Append("<br/>业主：" + drRow["OfficeAutomation_Document_SpecialCase_Master"]);
                    sbMailBody.Append("<br/>买家：" + drRow["OfficeAutomation_Document_SpecialCase_Buyer"]);
                    sbMailBody.Append("<br/>贷款银行：" + drRow["OfficeAutomation_Document_SpecialCase_Loan"]);
                    sbMailBody.Append("<br/>是否快放：" + (drRow["OfficeAutomation_Document_SpecialCase_QuickPut"].ToString() == "1" ? "是" : drRow["OfficeAutomation_Document_SpecialCase_QuickPut"].ToString() == "2" ? "否" : "未选择"));
                    sbMailBody.Append("<br/>担保公司：" + drRow["OfficeAutomation_Document_SpecialCase_GuaranteeCompany"]);
                    if (drRow["OfficeAutomation_Document_SpecialCase_PayWay"].ToString() == "1")
                        sbMailBody.Append("<br/>付款方式：一次性");
                    else if (drRow["OfficeAutomation_Document_SpecialCase_PayWay"].ToString() == "0")
                        sbMailBody.Append("<br/>付款方式：按揭");

                    sbMailBody.Append("<br/><br/>");

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

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）梁晶晶（工号：32188）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            //employname = "宁伟雄,黄洁珍";
                            //employnames = employname.Split(',');
                            //for (int i = 0; i < employnames.Length; i++)
                            //{
                            //    if (!employeeList.Contains(employnames[i]))
                            //    {
                            //        msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //        email = employnames[i];
                                    //if (hdIsAgree.Value == "2")
                            //    Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                    //else
                                    //    Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

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
        //try
        //{
        //    DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_SpecialCase_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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

    private T_OfficeAutomation_Document_SpecialCase GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_SpecialCase t_OfficeAutomation_Document_SpecialCase = new T_OfficeAutomation_Document_SpecialCase();
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_ID = UndertakeProjID;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Apply = EmployeeName;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_BranchNo = txtBranchNo.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Phone = txtPhone.Text;

        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_FollowDepartment = ddlFollowDepartment.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_FollowSomebody = ddlFollowSomebody.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Location = txtLocation.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Master = txtMaster.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Buyer = txtBuyer.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Loan = txtLoan.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_QuickPut = rdbQuickPut1.Checked ? "1" : rdbQuickPut2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_GuaranteeCompany = txtGuaranteeCompany.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_PayWay = rdbPayWay1.Checked ? "1" : rdbPayWay2.Checked ? "2" : rdbPayWay3.Checked ? "3" : "0";

        string cbt = null, cbi = "";
        if (cbApplyNo1.Checked == true)
            cbt += "|1a";
        if (cbApplyNo2.Checked == true)
            cbt += "|2a";
        if (cbApplyNo3.Checked == true)
            cbt += "|3a";
        if (cbApplyNo4.Checked == true)
            cbt += "|4a";
        if (cbApplyNo5.Checked == true)
            cbt += "|5a";
        if (cbApplyNo6.Checked == true)
            cbt += "|6a";
        if (cbApplyNo7.Checked == true)
            cbt += "|7a";
        if (cbApplyNo8.Checked == true)
            cbt += "|8a";
        if (cbApplyNo9.Checked == true)
            cbt += "|9a";
        //if (cbApplyNo10.Checked == true)
        //    cbt += "|10";
        if (cbApplyNo11.Checked == true)
            cbt += "|11";
        if (cbApplyNo12.Checked == true)
            cbt += "|12";
        if (cbApplyNo13.Checked == true)
            cbt += "|13";
        if (cbApplyNo14.Checked == true)
            cbt += "|14";
        if (cbApplyNo15.Checked == true)
            cbt += "|15";
        if (cbApplyNo16.Checked == true)
            cbt += "|16";
        if (cbApplyNo17.Checked == true)
            cbt += "|17";
        if (cbApplyNo18.Checked == true)
            cbt += "|18";
        if (cbApplyNo19.Checked == true)
            cbt += "|19";
        if (cbApplyNo20.Checked == true)
            cbt += "|20";
        if (cbApplyNo21.Checked == true)
            cbt += "|21";
        if (cbApplyNo22.Checked == true)
            cbt += "|22";
        if (cbApplyNo23.Checked == true)
            cbt += "|23";
        if (cbApplyNo24.Checked == true)
            cbt += "|24";
        if (cbApplyNo25.Checked == true)
            cbt += "|25";
        if (cbApplyNo26.Checked == true)
            cbt += "|26";
        //if (cbApplyNo27.Checked == true)
        //    cbt += "|27";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_ApplyNo = cbt;

        if (cbTimeoutApply1.Checked == true)
            cbi += "|1";
        if (cbTimeoutApply2.Checked == true)
            cbi += "|2";
        if (cbTimeoutApply3.Checked == true)
            cbi += "|3";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_TimeoutApply = cbi;
        cbi = "";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_ForPeople = ddlForPeople.Text;

        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_AutoHandle = txtAutoHandle.Text;
        if (cbCaseRemark1.Checked == true)
            cbi += "|1";
        if (cbCaseRemark2.Checked == true)
            cbi += "|2";
        if (cbCaseRemark3.Checked == true)
            cbi += "|3";
        if (cbCaseRemark4.Checked == true)
            cbi += "|4";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_CaseRemark = cbi;
        cbi = "";

        if (cbHousingTransactions1.Checked == true)
            cbi += "|1";
        if (cbHousingTransactions2.Checked == true)
            cbi += "|2";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_HousingTransactions = cbi;
        cbi = "";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_DealWithProgress = txtDealWithProgress.Text;

        if (cbMidway1.Checked == true)
            cbi += "|1";
        if (cbMidway2.Checked == true)
            cbi += "|2";
        if (cbMidway3.Checked == true)
            cbi += "|3";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Midway = cbi;
        cbi = "";
        if (cbPutUp1.Checked == true)
            cbi += "|1";
        if (cbPutUp2.Checked == true)
            cbi += "|2";
        if (cbPutUp3.Checked == true)
            cbi += "|3";
        if (cbPutUp4.Checked == true)
            cbi += "|4";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_PutUp = cbi;
        cbi = "";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_AnotherPutUp = txtAnotherPutUp.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany = txt4PointGuaranteeCompany.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_CompanyEarnings = rdbCompanyEarnings1.Checked ? "1" : "0";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_EarningsAmount = txtEarningsAmount.Text;

        if (cbTheKindOfFormalities1.Checked == true)
            cbi += "|1";
        if (cbTheKindOfFormalities2.Checked == true)
            cbi += "|2";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_TheKindOfFormalities = cbi;
        cbi = "";

        if (cbCertificate1.Checked == true)
            cbi += "|1";
        if (cbCertificate2.Checked == true)
            cbi += "|2";
        if (cbCertificate3.Checked == true)
            cbi += "|3";
        if (cbCertificate4.Checked == true)
            cbi += "|4";
        if (cbCertificate5.Checked == true)
            cbi += "|5";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Certificate = cbi;
        cbi = "";

        //if (cbNotarialDeed1.Checked == true)
        //    cbi += "|1";
        if (cbNotarialDeed2.Checked == true)
        //    cbi += "|2";
        //if (cbNotarialDeed3.Checked == true)
        //    cbi += "|3";
        //if (cbNotarialDeed4.Checked == true)
        //    cbi += "|4";
        //if (cbNotarialDeed5.Checked == true)
        //    cbi += "|5";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_NotarialDeed = cbi;
        cbi = "";
        //t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_CommissionedPersonnel = txtCommissionedPersonnel.Text;
        //t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Clause = txtClause.Text;

        if (cbNotNeat1.Checked == true)
            cbi += "|1";
        if (cbNotNeat2.Checked == true)
            cbi += "|2";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_NotNeat = cbi;
        cbi = "";
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_JieFeeDate = txtJieFeeDate.Text;

        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_credit = txtcredit.Text;
       // t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Another = txtAnother.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_Situation = txtSituation.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_BorrowDate = txtBorrowDate.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_BorrowS = txtBorrowS.Text;
        t_OfficeAutomation_Document_SpecialCase.OfficeAutomation_Document_SpecialCase_ReturnDate = txtReturnDate.Text;

        return t_OfficeAutomation_Document_SpecialCase;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_SpecialCase t_OfficeAutomation_Document_SpecialCase = new T_OfficeAutomation_Document_SpecialCase();
        DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_ID"].ToString();

        t_OfficeAutomation_Document_SpecialCase = GetModelFromPage(new Guid(ID));

        string apply = EmployeeName;
        string depname = txtDepartment.Text;
        string summary = txtLocation.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_SpecialCase_Inherit.Update(t_OfficeAutomation_Document_SpecialCase);//修改申请表

        //DA_OfficeAutomation_Document_SpecialCase_Detail_Inherit da_OfficeAutomation_Document_SpecialCase_Detail_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Detail_Inherit();
        //da_OfficeAutomation_Document_SpecialCase_Detail_Inherit.Delete(ID);
        //InsertSpecialCaseDetail(new Guid(ID));
       // AddFlows();
        specialFlows();
        Common.AddLog(EmployeeID, EmployeeName, 52, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增明细表

    /// <summary>
    /// 新增明细表
    /// </summary>
    /// <param name="gSpecialCaseID"></param>
    //private void InsertSpecialCaseDetail(Guid gSpecialCaseID)
    //{
    //    if (hdDetail.Value == "")
    //        return;

    //    T_OfficeAutomation_Document_SpecialCase_Detail t_OfficeAutomation_Document_SpecialCase_Detail;
    //    DA_OfficeAutomation_Document_SpecialCase_Detail_Inherit da_OfficeAutomation_Document_SpecialCase_Detail_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Detail_Inherit();

    //    string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
    //    try
    //    {
    //        for (int i = 0; i < details.Length; i++)
    //        {
    //            string[] detail = Regex.Split(details[i], "\\&\\&");
    //            if (detail[0] == "")
    //                continue;
    //            t_OfficeAutomation_Document_SpecialCase_Detail = new T_OfficeAutomation_Document_SpecialCase_Detail();
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_ID = Guid.NewGuid();
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_MainID = gSpecialCaseID;
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_Property = detail[0];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_Controler = detail[1];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_PropertyID = detail[2];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_PropertyDate = detail[3];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_OldDeal = detail[4];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_NewDeal = detail[5];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_AjustDeal = detail[6];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_ShouldComm = detail[7];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_ActualComm = detail[8];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_AjustComm = detail[9];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_LeadReason = int.Parse(detail[10]);
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_Commitment = detail[11];
    //            t_OfficeAutomation_Document_SpecialCase_Detail.OfficeAutomation_Document_SpecialCase_Detail_Reason = detail[12];

    //            da_OfficeAutomation_Document_SpecialCase_Detail_Inherit.Insert(t_OfficeAutomation_Document_SpecialCase_Detail);
    //        }
    //    }
    //    catch (Exception ee)
    //    {
    //        Alert(ee.Message);
    //        return;
    //    }
    //}

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
        Session["FLG_ReWrite53"] = "1";
        Response.Write("<script>window.open('Apply_SpecialCase_Detail.aspx?MainID=" + MainID + "');</script>");
    }

    /// <summary>
    /// 获取所有四级以上前线经理//789
    /// </summary>
    private void GetManagers()
    {
        wsFinance.Service service = new wsFinance.Service();
        DataSet dsManagers = service.GetManages();
        SbJsonf.Append("[");
        foreach (DataRow dr in dsManagers.Tables[0].Rows)
        {
            SbJsonf.Append("\"" + dr["EmployeeName"] + "\",");
        }
        SbJsonf.Remove(SbJsonf.Length - 1, 1);
        SbJsonf.Append("]");
    }
    protected void btnSaveLogisticsFlow_Click(object sender, EventArgs e)
    {
        if (hdLogisticsFlow.Value == "")
            return;
        T_OfficeAutomation_Document_GeneralApply_Detail t_OfficeAutomation_Document_GeneralApply_Detail;
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

        DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_ID"].ToString(); //在不同的表要注意修改

        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Delete(ID);
        string[] details = Regex.Split(hdLogisticsFlow.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_GeneralApply_Detail = new T_OfficeAutomation_Document_GeneralApply_Detail();
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_MainID = new Guid(ID);
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Department = detail[0];
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Num = int.Parse(detail[1]);
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Branch = detail[2];
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Cmodel = detail[3] == "1";
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_IsOpen = detail[4] == "1";
            if (detail[0].ToString() != "董事总经理" && detail[0].ToString() != "总经办")
            da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Insert(t_OfficeAutomation_Document_GeneralApply_Detail);
        }
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 130;
        //da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID; //在不同的表要注意删除
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 131;
        //da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    }
    protected void btnWillEnd_Click(object sender, EventArgs e) //M_WinnEnd：20150204
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "0001");
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "总经办");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "董事总经理");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "董事总经理审批");
        da_OfficeAutomation_Main_Inherit.UpdateFlowStateForAudit(MainID);
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
        RunJS("alert('已删除总经办的审批环节！');window.location='" + Page.Request.Url + "'");
    }
    protected void btnJumpEmma_Click(object sender, EventArgs e) //M_EmmaJump：20160118
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "23514");

        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

        string msnBody;
        msnBody = "您好黄瑛，由于张绍欣跳过了她的审批环节，所以现有一份《" + documentName + "》需要您来审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        Common.SendMessageEX(true, documentName, "黄瑛", "请审理", msnBody, msnBody, MainID);

        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
        RunJS("alert('已跳过您所在的审批环节！');window.location='" + Page.Request.Url + "'");
    }
    public void DrawAFTable(int n, bool x2, bool x3, string department)
    {
        for (int i = 1; i <= 1; i++)
        {
            int j = 0, k = 3 * n;
            if (x2 && x3)
                j = 3;
            else if ((!x2 && x3) || (x2 && !x3))
                j = 2;
            else if (!x2 && !x3)
                j = 1;
            SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
            SbHtmlLogisticsFlow.Append("<td rowspan=\"" + j + "\"  class=\"auto-style1\">" + department + "</td>");
            SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
            SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20 - 2) + "\">同意</label>");
            SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20 - 2) + "\">不同意</label>");
            SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20 - 2) + "\">其他意见</label>");
            SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20 - 2) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
            SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20 - 2) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20 - 2) + "\')\" style=\"display: none;\" />");
            SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20 - 2) + "\">_________</span></div>");
            SbHtmlLogisticsFlow.Append("</td>");
            SbHtmlLogisticsFlow.Append("</tr>");
            if (x2)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20 - 1) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20 - 1) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20 - 1) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20 - 1) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20 - 1) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20 - 1) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20 - 1) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
            if (x3)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
        }
        SbJs.Append("i=" + n + ";");
    }//987

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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("特殊个案申请表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SpecialCase_Department"].ToString();
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
                //if (i == 1) //删除添加的流程
                //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "2,10,12");
                //if (i < 9)
                //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,11");
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
            DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SpecialCase_Department"].ToString();
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
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11"); //删除可能添加的流程
                da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                //RunJS("alert('所作的修改已保存！');window.location='" + Page.Request.Url + "'");
                if (!flowsadd.Contains("1") && !flowsadd.Contains("2") && !flowsadd.Contains("3") && !flowsadd.Contains("4") && flowsadd != "A")
                    RunJS("alert('所作的修改已保存。');window.location='/Apply/Apply_Search.aspx';");
                else if (flowsadd != "A")
                    RunJS("alert('所作的修改已保存！');var win=window.showModalDialog(\"Apply_SpecialCase_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + flowsadd + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='" + Page.Request.Url + "'; }");
                else
                    RunJS("alert('所作的修改已保存，稍后会由汇瀚客户服务中心主管来编辑审批流程！');window.location='/Apply/Apply_Search.aspx';");
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
            DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SpecialCase_Department"].ToString();
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
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 9); //在不同的表中要修改，开发新表时要注意
            //在不同的表中要修改
            //RunJS("var win=window.showModalDialog(\"Apply_SpecialCase_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");
            string fls = "";
            T_OfficeAutomation_Flow flows;
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
            if (flows != null)
            {
                fls += "1";
            }
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2);
            if (flows != null)
            {
                fls += "2";
            }
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
            if (flows != null)
            {
                fls += "3";
            }
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
            if (flows != null)
            {
                fls += "4";
            }
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_SpecialCase_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + fls + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");
        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    protected void ddlFollowDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        FollowSomebodyAdd("");
    }

    protected void FollowSomebodyAdd(string s)
    {
        DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
        DataSet ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectBusinessDpm(ddlFollowDepartment.Text);
        DropDownListBind(ddlFollowSomebody, ds.Tables[0], "Code", "EmployeeName", s, "请选择");
    }
  
    // 根据条件增加流程
    protected void specialFlows()
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        T_OfficeAutomation_Flow flows;
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 5);//删除idx >= 5以上的审核人
        DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_ID"].ToString(); //在不同的表要注意修改
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Delete(ID);//删除通用申请后勤审批流程表

        #region 1 超时申请办理
       
        if(cbApplyNo1.Checked && cbTimeoutApply1.Checked && ddlForPeople.SelectedValue == "分行同事")
        {
            flowsadd += "123";
         
            AddFlows6();//主管
            AddFlows7();//业务高经
            AddFlowsN(8, "7353", "林晓璇");//汇瀚运作中心权证部副经理
        }
        else if (cbApplyNo1.Checked)
        {
          flowsadd += "0";
           // AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
            AddFlows6();//主管
            AddFlowsN(8, "7353", "林晓璇");//汇瀚运作中心权证部副经理
        
        }
        #endregion 

        #region 2 房管交易
        if (cbApplyNo3.Checked)
        {
            AddFlows6();//主管
            AddFlowsN(9, "13161", "曹颖思");//总监
        }
        #endregion

        #region 3 中途
        if (cbApplyNo4.Checked)
        {
            AddFlows6();//主管
        }
        #endregion

        #region 4 领取
        if (cbApplyNo6.Checked || cbApplyNo11.Checked)
        {
            flowsadd += "23";
            AddFlows6();//主管
            AddFlows7();//业务高经
            AddFlowsN(9, "13161", "曹颖思");//总监
        }
        #endregion

        #region 5 增加《委托公证书》受委托人员名单
        if (cbApplyNo7.Checked && cbNotarialDeed2.Checked)
        {
            flowsadd += "24";
            AddFlows6();//主管
            AddFlowsN(9, "13161", "曹颖思");//总监
        }
        #endregion

        #region 6 未齐费用
        if (cbApplyNo8.Checked)
        {
            flowsadd += "24";
            AddFlows6();//主管
            AddFlows7();//业务高经
            AddFlowsN(9, "13161", "曹颖思");//总监
        }
        #endregion

        #region 7 未出同贷办理
        if (cbApplyNo9.Checked)
        {
            flowsadd += "23";
            AddFlows6();//主管
            AddFlows7();//业务高经
        }
        #endregion

        #region 8
        //异常结算评估费 \ 不发送短信
        if (cbApplyNo19.Checked || cbApplyNo20.Checked)
        {
            AddFlows6();//主管
            AddFlowsN(9, "13161", "曹颖思");//总监
        }
        //业主复印买家贷款合同
        if (cbApplyNo22.Checked)
        {
            AddFlows6();//主管
        }
        //业主快放/担保案不做委托书 /街单不查册/街单不提供双方约 /交案所须资料不提交
        if (cbApplyNo23.Checked || cbApplyNo25.Checked || cbApplyNo26.Checked)
        {
            AddFlows6();//主管
            AddFlows7();//业务高经
            AddFlowsN(9, "13161", "曹颖思");//总监
        }
        //交案没有签齐资料需现场签署
        if (cbApplyNo24.Checked)
        {
            AddFlows6();//主管
            AddFlowsN(8, "7353", "林晓璇");//汇瀚运作中心权证部副经理
        }
        #endregion
    }

    #region 根据条件增加流程
    protected void AddFlows()
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        T_OfficeAutomation_Flow flows;

        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
        //if (flows == null)
        //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 1);
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2);
        //if (flows == null)
        //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 2);
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        //if (flows == null)
        //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 3);
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        //if (flows == null)
        //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 4);
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 5);

      //  if (!cbApplyNo10.Checked)
       // {
            DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
            DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID);
            ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_ID"].ToString(); //在不同的表要注意修改
            da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Delete(ID);
            //运作中心权证部副经理  林晓璇 （7353）
            /*XXXXXXXXXXXXXXA、当同时选择：【（1）超时申请办理____（包含）递件______（房管）业务；资料领取人：分行同事】时，
            审批流程为：分行申请人—分行部门主管—汇瀚申请人—汇瀚业务部主管—汇瀚高级经理—汇瀚客户服务中心主管/汇瀚营运总经理XXXXXXXXXXXX*/

            /*第一项：超时申请办理“递件”  领取人为分行同事时，审批流程参考《授权》第三条，其中分行流程应为“分行申请人—分行主管-分行区经”*/
            if (cbApplyNo1.Checked && cbTimeoutApply1.Checked && ddlForPeople.SelectedValue == "分行同事")
            {
                //flowsadd += "12";
                //AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                //AddFlows6();
                //AddFlows7();
                //AddFlowsN(8, "5733", "梁敏冰");
                //AddFlowsN(9, "13161", "曹颖思");
                flowsadd += "123";
                AddFlows7();
                AddFlowsN(8, "5733", "梁敏冰");
                AddFlowsN(9, "13161", "曹颖思");
            }
            /*领取人为汇瀚同事时，审批流程参考《授权》第二条*/
            else if (cbApplyNo1.Checked && ddlForPeople.SelectedValue == "汇瀚同事")
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(8, "5733", "梁敏冰");
            }
            /*B、该点其他选择则（即非分行同事或非包含递件业务）时，
            审批流程为：汇瀚申请人—汇瀚业务部主管—汇瀚高级经理—汇瀚客户服务中心主管/汇瀚营运总经理*/
            else if (cbApplyNo1.Checked && ddlForPeople.SelectedValue == "请选择")
            {
                
                //flowsadd += "0";
                //AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                //AddFlows6();
                //AddFlows7();
                //AddFlowsN(8, "5733", "梁敏冰");
                //AddFlowsN(9, "13161", "曹颖思");
               // Dictionary<string, string> Director = RetrueDirector();
              
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(8, "5733", "梁敏冰");
            }

            #region 第8项审批流程
            //*********************************************************************************************************************

            if (cbApplyNo6.Checked || cbApplyNo11.Checked) //1
            {
                flowsadd += "23";
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlows7();
                AddFlowsN(8, "5733", "梁敏冰");
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo12.Checked && rdbPayWay1.Checked) //2.1
            {
                flowsadd += "2";
                AddFlowsN(8, "5733", "梁敏冰");
            }
            if (cbApplyNo12.Checked && rdbPayWay2.Checked) //2.2
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(8, "5733", "梁敏冰");
            }
            if (cbApplyNo13.Checked && rdbPayWay1.Checked) //3.1
            {
                flowsadd += "23";
                AddFlows7();
                AddFlowsN(8, "5733", "梁敏冰");
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo13.Checked && rdbPayWay2.Checked) //3.2
            {
                flowsadd += "23";
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlows7();
                AddFlowsN(8, "5733", "梁敏冰");
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo7.Checked || cbApplyNo14.Checked) //4
            {
                flowsadd += "24";
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo4.Checked || cbApplyNo15.Checked) //5
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(8, "3734", "熊敏洁");
            }
            if (cbApplyNo16.Checked) //6
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(8, "3734", "熊敏洁");
            }
            if (cbApplyNo9.Checked || cbApplyNo17.Checked) //7
            {
                flowsadd += "23";
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo8.Checked || cbApplyNo18.Checked) //8
            {
                flowsadd += "24";
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlows7();
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo19.Checked) //9
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo20.Checked) //10
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo3.Checked || cbApplyNo21.Checked) //11
            {
                flowsadd += "24";
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo22.Checked) //12
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
            }
            if (cbApplyNo23.Checked) //13
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlows7();
            }
            if (cbApplyNo24.Checked) //14
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlows7();
            }
            if (cbApplyNo25.Checked) //15
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlows7();
                AddFlowsN(9, "13161", "曹颖思");
            }
            if (cbApplyNo26.Checked) //16
            {
                AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
                AddFlows6();
                AddFlows7();
            }
            //if (cbApplyNo27.Checked) //17
            //{
            //    AddFlowsN(5, ddlFollowSomebody.Text, ddlFollowSomebody.SelectedItem.Text);
            //    AddFlows6();
            //    AddFlowsN(9, "13161", "曹颖思");
            //}

            //*********************************************************************************************************************
            #endregion
       // }
        //else
        //{
        //    flowsadd = "A";
        //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "1,2,3,4,5,6,7,8,9");
        //    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        //    string[] employnames;
        //    string email;
        //    string msnBody;
        //    string signEmployeeName = EmployeeName;
        //    DA_OfficeAutomation_Document_SpecialCase_Inherit da_OfficeAutomation_Document_SpecialCase_Inherit = new DA_OfficeAutomation_Document_SpecialCase_Inherit();
        //    DataSet ds = da_OfficeAutomation_Document_SpecialCase_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        //    DataRow drRow = ds.Tables[0].Rows[0];
        //    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialCase_Apply"].ToString();
        //    string employname;
        //    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        //    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        //    string department = drRow["OfficeAutomation_Document_SpecialCase_Department"].ToString();
        //    string applyUrl = Page.Request.Url.ToString();
        //    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        //    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //                //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
        //    //通知编辑流程
        //    employname = "梁敏冰";
        //    employnames = employname.Split(',');
        //    for (int i = 0; i < employnames.Length; i++)
        //    {
        //        msnBody = "您好，" + employnames[i] + "：有一份编号为" + serialNumber + "的" + documentName + "需要您编辑审批流程，若流程无误则无需重新编辑。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>" + "<br /><br />操作方法：打开申请表后，点击表最下面的“增加审批环节”链接即可编辑相关的审批流程。";
        //        email = employnames[i];
        //        Common.SendMessageEX(false, email, "请编辑审批流程", msnBody + msnBody, msnBody);
        //    }
        //}

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
        if (flows != null && !flowsadd.Contains("1"))
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "1");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2);
        if (flows != null && !flowsadd.Contains("2"))
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "2");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        if (flows != null && !flowsadd.Contains("3"))
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "3");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        if (flows != null && !flowsadd.Contains("4"))
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "4");
    }
    /// <summary>
    /// 汇瀚主管
    /// </summary>
    protected void AddFlows6()
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        T_OfficeAutomation_Flow flows;

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 6);
        if (flows == null)
        {
            if (ddlFollowDepartment.Text == "业务一部")
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1928";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "叶英健";
            }
            else if (ddlFollowDepartment.Text == "业务三部")
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "8749";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄瑞雯";
            }
            else if (ddlFollowDepartment.Text == "业务四部")
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0504";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴紫霞";
            }
            else if (ddlFollowDepartment.Text == "业务二部")
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "6787";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "麦淑姗";
            }
            else if (ddlFollowDepartment.Text == "业务五部")
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "4909";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴远斌";
            }
            else if (ddlFollowDepartment.Text == "业务六部")
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "10477";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李军";
            }
            else
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "9070";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "刘婉敏";
            }
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 6;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }
    }

    /// <summary>
    /// 业务高经
    /// </summary>
    protected void AddFlows7()
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        T_OfficeAutomation_Flow flows;

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 7);
        if (flows == null)
        {
            if (ddlFollowDepartment.Text == "业务一部" || ddlFollowDepartment.Text == "业务三部" || ddlFollowDepartment.Text == "业务四部")
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0224";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "莫静";
            }
            else
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "4837";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何志雄";
            }
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 7;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }
    }

    protected void AddFlowsN(int n, string id, string nam)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        T_OfficeAutomation_Flow flows;

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, n);
        if (flows == null)
        {
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = id;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = nam;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = n;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }
        else if (n == 8 && flows.OfficeAutomation_Flow_EmployeeID.Contains("7353") && id != "7353")
        {
            da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndIdxs(MainID, n, flows.OfficeAutomation_Flow_Employee + "," + nam, flows.OfficeAutomation_Flow_EmployeeID + "," + id);
        }
        else if (n == 8 && flows.OfficeAutomation_Flow_EmployeeID.Contains("3734") && id != "3734")
        {
            da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndIdxs(MainID, n, flows.OfficeAutomation_Flow_Employee + "," + nam, flows.OfficeAutomation_Flow_EmployeeID + "," + id);
        }
    }
    #endregion

    protected void rdbPayWay1_CheckedChanged(object sender, EventArgs e)
    {
        ChangeCb();
    }
    protected void ChangeCb()
    {
        if (rdbPayWay1.Checked)
        {
            cbApplyNo11.Visible = true;
            cbApplyNo12.Visible = true;
            cbApplyNo13.Visible = true;
            cbApplyNo14.Visible = true;
            cbApplyNo15.Visible = false;
            cbApplyNo16.Visible = false;
            cbApplyNo17.Visible = false;
            cbApplyNo18.Visible = false;
            cbApplyNo19.Visible = false;
            cbApplyNo20.Visible = false;
            cbApplyNo21.Visible = true;
            cbApplyNo22.Visible = false;
            cbApplyNo23.Visible = false;
            cbApplyNo24.Visible = false;
            cbApplyNo25.Visible = false;
            cbApplyNo26.Visible = false;
           // cbApplyNo27.Visible = true;

            cbApplyNo15.Checked = false;
            cbApplyNo16.Checked = false;
            cbApplyNo17.Checked = false;
            cbApplyNo18.Checked = false;
            cbApplyNo19.Checked = false;
            cbApplyNo20.Checked = false;
            cbApplyNo22.Checked = false;
            cbApplyNo23.Checked = false;
            cbApplyNo24.Checked = false;
            cbApplyNo25.Checked = false;
            cbApplyNo26.Checked = false;

            cbApplyNo21.CssClass = "PDL";
          //  cbApplyNo27.CssClass = null;

            Lb1.Visible = false;
            Lb2.Visible = false;
            Lb3.Visible = false;
        }
        else if (rdbPayWay2.Checked)
        {
            cbApplyNo11.Visible = true;
            cbApplyNo12.Visible = true;
            cbApplyNo13.Visible = true;
            cbApplyNo14.Visible = true;
            cbApplyNo15.Visible = true;
            cbApplyNo16.Visible = true;
            cbApplyNo17.Visible = true;
            cbApplyNo18.Visible = true;
            cbApplyNo19.Visible = true;
            cbApplyNo20.Visible = true;
            cbApplyNo21.Visible = true;
            cbApplyNo22.Visible = true;
            cbApplyNo23.Visible = true;
            cbApplyNo24.Visible = true;
            cbApplyNo25.Visible = false;
            cbApplyNo26.Visible = true;
            //cbApplyNo27.Visible = true;

            cbApplyNo25.Checked = false;

            //cbApplyNo26.CssClass = "PDL";
           // cbApplyNo27.CssClass = "PDL";
            cbApplyNo21.CssClass = null;

            Lb1.Visible = true;
            //Lb2.Visible = true;
            Lb3.Visible = true;
        }
        else
        {
            cbApplyNo11.Visible = false;
            cbApplyNo12.Visible = false;
            cbApplyNo13.Visible = false;
            cbApplyNo14.Visible = false;
            cbApplyNo15.Visible = false;
            cbApplyNo16.Visible = false;
            cbApplyNo17.Visible = false;
            cbApplyNo18.Visible = false;
            cbApplyNo19.Visible = false;
            cbApplyNo20.Visible = false;
            cbApplyNo21.Visible = false;
            cbApplyNo22.Visible = false;
            cbApplyNo23.Visible = false;
            cbApplyNo24.Visible = false;
            cbApplyNo25.Visible = true;
            cbApplyNo26.Visible = true;
           // cbApplyNo27.Visible = false;

            cbApplyNo11.Checked = false;
            cbApplyNo12.Checked = false;
            cbApplyNo13.Checked = false;
            cbApplyNo14.Checked = false;
            cbApplyNo15.Checked = false;
            cbApplyNo16.Checked = false;
            cbApplyNo17.Checked = false;
            cbApplyNo18.Checked = false;
            cbApplyNo19.Checked = false;
            cbApplyNo20.Checked = false;
            cbApplyNo21.Checked = false;
            cbApplyNo22.Checked = false;
            cbApplyNo23.Checked = false;
            cbApplyNo24.Checked = false;
           // cbApplyNo27.Checked = false;

            cbApplyNo25.CssClass = null;

            Lb1.Visible = false;
            Lb2.Visible = false;
            Lb3.Visible = false;
        }
    }
}