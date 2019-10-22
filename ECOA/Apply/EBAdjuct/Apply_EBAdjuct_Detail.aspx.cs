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
using System.Collections;//789

using System.Diagnostics; //M_PDF
using System.Web;
using AppCommon.Model;
using JsonOutEstateList = DataEntity.Json.CCES.JsonOutEstateList;

public partial class Apply_EBAdjuct_Apply_EBAdjuct_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbHtml3 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();

    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();
    public StringBuilder SbCcesp = new StringBuilder();

    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();";

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

        GetCCESP();

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
                    SbJs.Append("<script type=\"text/javascript\">$(\"div .flow\").hide();$(\"#PageBottom\").hide();$('#trtpdf').append('<div class=\"signdate\"></div>');</script>");
                    tpdf = true;
                }
            }
            catch
            { }
            try
            {
                if (Session["FLG_ReWrite62"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite62"] = null;
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

        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        SbJs.Append("</script>");
        IsNewApply = true;
        DrawDetailTable1(1);
        DrawDetailTable2(1);
        DrawDetailTable(1);
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
        DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
        DA_OfficeAutomation_Document_EBAdjuct_Detail_Inherit da_OfficeAutomation_Document_EBAdjuct_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_EBAdjuct_Detail_Inherit();
        DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit da_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit();
        DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit da_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit();

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
        ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_EBAdjuct_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_EBAdjuct_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_EBAdjuct_ApplyID"].ToString();
        hfKey.Value = dr["OfficeAutomation_Document_EBAdjuct_ApplyName"].ToString();



        //DA_CCES_Inherit _CCES_Inherit = new DA_CCES_Inherit();//*-
        //List<DbTable> list = new List<DbTable>();
        //string sJsonIn = "";
        //uacEstateCCES.Key = dr["OfficeAutomation_Document_EBAdjuct_ApplyName"].ToString();
        //if (!string.IsNullOrEmpty(uacEstateCCES.Key))
        //{
        //    list.Clear();
        //    list.Add(new DbTable("EstateID", uacEstateCCES.Key));
        //    sJsonIn = _CCES_Inherit.fnGetJsonIn(list);
        //    List<DataEntity.Json.CCES.JsonOutEstateList.rows> rows = _CCES_Inherit.fnGetEstateList(sJsonIn);
        //    if (rows.Count > 0)
        //        uacEstateCCES.Data = rows[0].EstateName;
        //}

        

        txtDepartment.Text = dr["OfficeAutomation_Document_EBAdjuct_Department"].ToString();
        txtApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_EBAdjuct_ApplyDate"].ToString()).ToString("yyyy-MM-dd");

        if (dr["OfficeAutomation_Document_EBAdjuct_BonusC1"].ToString() == "1")
            rdbBonusC11.Checked = true;
        else if (dr["OfficeAutomation_Document_EBAdjuct_BonusC1"].ToString() == "2")
            rdbBonusC12.Checked = true;
        txtProjectPCMomey.Text = dr["OfficeAutomation_Document_EBAdjuct_ProjectPCMomey"].ToString();
        txtProjectEBMomey.Text = dr["OfficeAutomation_Document_EBAdjuct_ProjectEBMomey"].ToString();
        if (dr["OfficeAutomation_Document_EBAdjuct_Bonus4"].ToString() == "1")
            rdbBonus41.Checked = true;
        else if (dr["OfficeAutomation_Document_EBAdjuct_Bonus4"].ToString() == "2")
            rdbBonus42.Checked = true;
        txtValidityBeginDate.Text = dr["OfficeAutomation_Document_EBAdjuct_ValidityBeginDate"].ToString();
        txtValidityEndDate.Text = dr["OfficeAutomation_Document_EBAdjuct_ValidityEndDate"].ToString();
        if (dr["OfficeAutomation_Document_EBAdjuct_Bonus5"].ToString() == "1")
            rdbBonus51.Checked = true;
        else if (dr["OfficeAutomation_Document_EBAdjuct_Bonus5"].ToString() == "2")
            rdbBonus52.Checked = true;
        if (dr["OfficeAutomation_Document_EBAdjuct_BonusSituation"].ToString() == "1")
            rdbBonusSituation1.Checked = true;
        else if (dr["OfficeAutomation_Document_EBAdjuct_BonusSituation"].ToString() == "2")
            rdbBonusSituation2.Checked = true;
        else if (dr["OfficeAutomation_Document_EBAdjuct_BonusSituation"].ToString() == "3")
            rdbBonusSituation3.Checked = true;
        txtWholeName.Text = dr["OfficeAutomation_Document_EBAdjuct_WholeName"].ToString();
        txtPosition.Text = dr["OfficeAutomation_Document_EBAdjuct_Position"].ToString();
        txtPhone.Text = dr["OfficeAutomation_Document_EBAdjuct_Phone"].ToString();
        txtAccountName.Text = dr["OfficeAutomation_Document_EBAdjuct_AccountName"].ToString();
        txtNo.Text = dr["OfficeAutomation_Document_EBAdjuct_No"].ToString();
        //添加
        txtBonusSituationValue.Text = dr["OfficeAutomation_Document_EBAdjuct_BonusSituationValue"].ToString();
        txtDiscountValue.Text = dr["OfficeAutomation_Document_EBAdjuct_DiscountValue"].ToString();
        txtCashPrize.Text = dr["OfficeAutomation_Document_EBAdjuct_CashPrize"].ToString();
        txtCalculationMethod.Text = dr["OfficeAutomation_Document_EBAdjuct_CashPrize"].ToString();
        tatBonusSituationRemarks.Value = dr["OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks"].ToString();
        //
        if (dr["OfficeAutomation_Document_EBAdjuct_IsTax"].ToString() == "1")
            rdbIsTax1.Checked = true;
        else if (dr["OfficeAutomation_Document_EBAdjuct_IsTax"].ToString() == "2")
            rdbIsTax2.Checked = true;
        txtBonusMoney.Text = dr["OfficeAutomation_Document_EBAdjuct_BonusMoney"].ToString();
        if (dr["OfficeAutomation_Document_EBAdjuct_IsConfirm"].ToString() == "1")
            rdbIsConfirm1.Checked = true;
        else if (dr["OfficeAutomation_Document_EBAdjuct_IsConfirm"].ToString() == "2")
            rdbIsConfirm2.Checked = true;
        txtSubmitDate.Text = dr["OfficeAutomation_Document_EBAdjuct_SubmitDate"].ToString();
        
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        ds = da_OfficeAutomation_Document_EBAdjuct_Detail_Inherit.SelectByID(ID);
        int detailCount0 = ds.Tables[0].Rows.Count;
        if (detailCount0 == 0)
            DrawDetailTable(0);
        else
        {
            DrawDetailTable(detailCount0);

            for (int n = 0; n < detailCount0; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;

                SbJs.Append("$('#txtDetail_Money" + i + "').val('" + dr["OfficeAutomation_Document_EBAdjuct_Detail_Money"] + "');");
                SbJs.Append("$('#txtDetail_Condition" + i + "').val('" + dr["OfficeAutomation_Document_EBAdjuct_Detail_Condition"] + "');");
            }
        }

        ds = da_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit.SelectByID(ID);
        int detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable1(0);
        else
        {
            DrawDetailTable1(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;

                SbJs.Append("$('#txtLeaseTerm_Money" + i + "').val('" + dr["OfficeAutomation_Document_EBAdjuct_LeaseTerm_Money"] + "');");
                SbJs.Append("$('#txtLeaseTerm_Reason" + i + "').val('" + dr["OfficeAutomation_Document_EBAdjuct_LeaseTerm_Reason"] + "');");
                SbJs.Append("$('#txtLeaseTerm_Condition" + i + "').val('" + dr["OfficeAutomation_Document_EBAdjuct_LeaseTerm_Condition"] + "');");
            }
        }

        ds = da_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit.SelectByID(ID);
        int detailCount2 = ds.Tables[0].Rows.Count;
        if (detailCount2 == 0)
            DrawDetailTable2(0);
        else
        {
            DrawDetailTable2(detailCount2);

            for (int n = 0; n < detailCount2; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;

                SbJs.Append("$('#rdoStatistical_Adjuct" + i + (dr["OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct"].ToString() == "1" ? "1" : "0") + "').attr('checked','checked');");
                SbJs.Append("$('#txtStatistical_Money" + i + "').val('" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_Money"] + "');");
                SbJs.Append("$('#txtStatistical_Reason" + i + "').val('" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_Reason"] + "');");
                SbJs.Append("$('#txtStatistical_Condition" + i + "').val('" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_Condition"] + "');");
            }
        }

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;

            try
            {
                //2016-12-19修改 注释掉法律部人审批之后不能上传附件功能

                //if (drc[2]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
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

        if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
            btnSignSave.Visible = true;
         
        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                txtApplyID.Text = "";
                SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("</script>");
                GetAllDepartment();
                //txtDepartment.Text = "";
                btnSPDF.Visible = false; //M_PDF
                txtApply.Text = EmployeeName;
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
                btnReWrite.Visible = true; //*+
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        if (Purview.Contains("OA_Search_002"))//789
            GetAllDepartment();
        if (EmployeeID == "10054")
            SbJs.Append("$(\"#afa\").show();$(\"#dfd\").show();");
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
        //bool showf = true; //M_HideFlows：20150330
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();
            string curemp2 = drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString();
            //if ((curidx == "1" || curidx == "2" || EmployeeName == "黄轩明") && curemp2.Contains(EmployeeID) && showf) //M_HideFlows：20150330
            //{
            //    showf = false;
            //    SbJs.Append("$(\"#trShowFlow3\").hide();$(\"#trShowFlow4\").prepend('<td>外联部意见</td>');");
            //    SbJs.Append("$(\"#trShowFlow5\").hide();$(\"#trShowFlow6\").prepend('<td>法律部意见</td>');");
            //    SbJs.Append("$(\"#trShowFlow7\").hide();$(\"#trShowFlow8\").prepend('<td>财务部意见</td>');");
            //    SbJs.Append("$(\"#trLogistics1\").hide();$(\"#trLogistics2\").prepend('<td>后勤事务部意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            //    SbJs.Append("$(\"#tlsc1\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            //}

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
                        //case "10":
                        //    ckbAddIDx10.Visible = true;
                        //    break;
                        case "6":
                            if (EmployeeID == "13545") //M_AddNWX：20150511
                                lbtnAddN.Visible = true;
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
                    SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\"/>");
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
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\"/>");
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

        T_OfficeAutomation_Flow flows;//789
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        if (flows != null)
            SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && applicant == EmployeeName && !tpdf)// && showf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

        //if (!showf) //M_HideFlows：20150330
        //    SbFlow.Length = 0;

        if (EmployeeID == "10054" || EmployeeID == "34498") //M_WinnEnd：20150204
            btnWillEnd.Visible = true;

        if (EmployeeName == "张绍欣") //M_EmmaJump：20160118
            btnShouldJumpIDxEmma.Visible = true;

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(MainID, "0001");
        if (flows == null)
            SbJs.Append("$('#trGeneralManager').hide();$('#tlsc2').hide();");

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
            SbHtml.Append("<tr id=\"trDetail" + i + "\">");

            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px\"><input type=\"text\" id=\"txtDetail_Money" + i + "\" style=\"width:80px\"/>元/套，发放条件是");
            SbHtml.Append("<input type=\"text\" id=\"txtDetail_Condition" + i + "\" style=\"width:400px\"/></td>");

            SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable1(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml2.Append("<tr id=\"trDetail" + i + "\">");

            SbHtml2.Append("<td style=\"text-align: left; padding-left: 10px\">新增<input type=\"text\" id=\"txtLeaseTerm_Money" + i + "\" style=\"width:80px\"/>元/套，原因：");
            SbHtml2.Append("<input type=\"text\" id=\"txtLeaseTerm_Reason" + i + "\" style=\"width:165px\"/>发放条件是");
            SbHtml2.Append("<input type=\"text\" id=\"txtLeaseTerm_Condition" + i + "\" style=\"width:165px\"/></td>");

			SbHtml2.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable2(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml3.Append("<tr id=\"trDetail2" + i + "\">");

            SbHtml3.Append("<td style=\"text-align: left; padding-left: 10px\"><input type=\"radio\" id='rdoStatistical_Adjuct" + i + "1' name='Statistical_Adjuct" + i + "' /><label for='rdoStatistical_Adjuct" + i + "1'>增加</label><input type=\"radio\" id='rdoStatistical_Adjuct" + i + "0' name='Statistical_Adjuct" + i + "' /><label for='rdoStatistical_Adjuct" + i + "0'>减少</label>");
            SbHtml3.Append("<input type=\"text\" id=\"txtStatistical_Money" + i + "\" style=\"width:80px\"/>元/套，原因：");
            SbHtml3.Append("<input type=\"text\" id=\"txtStatistical_Reason" + i + "\" style=\"width:130px\"/>发放条件是");
            SbHtml3.Append("<input type=\"text\" id=\"txtStatistical_Condition" + i + "\" style=\"width:130px\"/></td>");

            SbHtml3.Append("</tr>");
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
        T_OfficeAutomation_Document_EBAdjuct t_OfficeAutomation_Document_EBAdjuct = new T_OfficeAutomation_Document_EBAdjuct();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
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
        if (string.IsNullOrEmpty(hfKey.Value))
        {
            RunJS("alert('该项目名称不存在，请选择正确的项目名称！');history.go(-1);");
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

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "EBAdjuct" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 57; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                t_OfficeAutomation_Document_EBAdjuct = GetModelFromPage(Guid.NewGuid());

                //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtApplyID.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_EBAdjuct_Inherit.Insert(t_OfficeAutomation_Document_EBAdjuct);//插入申请表

                InsertEBAdjuctDetail(t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ID);
                InsertEBAdjuctDetail1(t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ID);
                InsertEBAdjuctDetail2(t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ID);

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

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 61, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_EBAdjuct_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
            Common.AddLog(EmployeeID, EmployeeName, 61, new Guid(MainID), 8);
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
        DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
        DA_OfficeAutomation_Document_EBAdjuct_Detail_Inherit da_OfficeAutomation_Document_EBAdjuct_Detail_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Detail_Inherit();
        DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit da_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit();
        DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit da_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit();
        
        DataSet ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_EBAdjuct_ID"].ToString(); 
        
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

                //如果为第5步流程则为其一审核即可通过，其他为同时审核。
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "4" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                //bool isSignSuccess = flowIDx == "5" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_EBAdjuct_Department"].ToString();
                    string s1 = drRow["OfficeAutomation_Document_EBAdjuct_ValidityBeginDate"].ToString();
                    string s2 = drRow["OfficeAutomation_Document_EBAdjuct_ValidityEndDate"].ToString();
                    string s3 = drRow["OfficeAutomation_Document_EBAdjuct_BonusMoney"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_EBAdjuct_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_EBAdjuct_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_EBAdjuct_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>项目名称" + drRow["OfficeAutomation_Document_EBAdjuct_ApplyID"].ToString());
                    sbMailBody.Append("<br/><br/>");

                    sbMailBody.Append("<br/>现金奖的金额及发放条件：");
                    ds = da_OfficeAutomation_Document_EBAdjuct_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>金额：" + dr["OfficeAutomation_Document_EBAdjuct_Detail_Money"]);
                        sbMailBody.Append("<br/>发放条件：" + dr["OfficeAutomation_Document_EBAdjuct_Detail_Condition"]);
                        sbMailBody.Append("<br/>");
                    }
                    sbMailBody.Append("<br/>");

                    //sbMailBody.Append("<br/>新增现金奖：");
                    //ds = da_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit.SelectByMainID(MainID);
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    sbMailBody.Append("<br/>金额：" + dr["OfficeAutomation_Document_EBAdjuct_LeaseTerm_Money"]);
                    //    sbMailBody.Append("<br/>原因：" + dr["OfficeAutomation_Document_EBAdjuct_LeaseTerm_Reason"]);
                    //    sbMailBody.Append("<br/>发放条件：" + dr["OfficeAutomation_Document_EBAdjuct_LeaseTerm_Condition"]);
                    //    sbMailBody.Append("<br/>");
                    //}
                    //sbMailBody.Append("<br/>");

                    //sbMailBody.Append("<br/>调整现金奖：");
                    //ds = da_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit.SelectByMainID(MainID);
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    sbMailBody.Append("<br/>楼盘名：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_Bname"]);
                    //    sbMailBody.Append("<br/>合计：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_Sum"]);
                    //    sbMailBody.Append("<br/>中原宗数：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_GzspsNum"]);
                    //    sbMailBody.Append("<br/>中原市占率：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_GzspsRate"]);
                    //    sbMailBody.Append("<br/>满堂红宗数：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_EveryNum"]);
                    //    sbMailBody.Append("<br/>满堂红市占率：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_EveryRate"]);
                    //    sbMailBody.Append("<br/>合富宗数：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_RichNum"]);
                    //    sbMailBody.Append("<br/>合富市占率：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_RichRate"]);
                    //    sbMailBody.Append("<br/>裕丰宗数：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_YuFengNum"]);
                    //    sbMailBody.Append("<br/>裕丰市占率：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_YuFengRate"]);
                    //    sbMailBody.Append("<br/>自行交易宗数：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_FreeNum"]);
                    //    sbMailBody.Append("<br/>自行交易市占率：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_FreeRate"]);
                    //    sbMailBody.Append("<br/>其它交易宗数：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_OtherNum"]);
                    //    sbMailBody.Append("<br/>其它交易市占率：" + dr["OfficeAutomation_Document_EBAdjuct_Statistical_OtherRate"]);
                    //    sbMailBody.Append("<br/>");
                    //}

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

                            #region 审批完成后发送到佣金系统 20150721

                            WS_ECS.WS_ECS service = new WS_ECS.WS_ECS();
                            service.fnAutoInsertCashPrizeSupplement(hfKey.Value, serialNumber, DateTime.Parse(s1), DateTime.Parse(s2), s3);

                            #endregion

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //完成后抄送
                            employname = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳,黄志超,黄洁珍,张绍欣,黄瑛,官东升,叶凯蔓,钟惠贤,冯琰,钟惠贤,刘韵";
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

                        //#region 审批完成后发送到佣金系统 20150721

                        //WS_ECS.WS_ECS service = new WS_ECS.WS_ECS();
                        //service.fnAutoInsertCashPrizeSupplement(hfKey.Value, serialNumber, DateTime.Parse(s1), DateTime.Parse(s2), s3);

                        //#endregion

                        //if (EmployeeID == "0001") //抄送到总办
                        //{
                        //    string sagree = "";
                        //    if (hdSuggestion.Value != "")
                        //        sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                        //    employname = CommonConst.EMP_GMO_NAME;
                        //    employnames = employname.Split(',');
                        //    for (int i = 0; i < employnames.Length; i++)
                        //    {
                        //        msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        //        email = employnames[i];
                        //        Common.SendMessageEX(false, email, "申请不同意", msnBody + mailBody, msnBody);
                        //    }
                        //} //总办

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
        //    DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_EBAdjuct_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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
                if (drc[2]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
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

    #region 从页面中获得model

    private T_OfficeAutomation_Document_EBAdjuct GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_EBAdjuct t_OfficeAutomation_Document_EBAdjuct = new T_OfficeAutomation_Document_EBAdjuct();
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ID = UndertakeProjID;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_Apply = EmployeeName;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ApplyDate = DateTime.Now;
        //t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ApplyID = uacEstateCCES.Data;
        //t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ApplyName = uacEstateCCES.Key; //*-
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ApplyName = hfKey.Value;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_Department = txtDepartment.Text;

        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusC1 = rdbBonusC11.Checked ? "1" : rdbBonusC12.Checked ? "2" : "0";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ProjectPCMomey = txtProjectPCMomey.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ProjectEBMomey = txtProjectEBMomey.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_Bonus4 = rdbBonus41.Checked ? "1" : rdbBonus42.Checked ? "2" : "0";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ValidityBeginDate = txtValidityBeginDate.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_ValidityEndDate = txtValidityEndDate.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_Bonus5 = rdbBonus51.Checked ? "1" : rdbBonus52.Checked ? "2" : "0";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituationValue = "";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_DiscountValue = "";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_CashPrize = "";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_CalculationMethod = "";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks = "";
        //t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituation = rdbBonusSituation1.Checked ? "1" : rdbBonusSituation2.Checked ? "2" : "0";
        if (rdbBonusSituation1.Checked)
        {
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituation ="1";
        }
        else if (rdbBonusSituation2.Checked)
        {
            t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituation = "2";
        }
         
        else if (rdbBonusSituation3.Checked)
        {
            t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituation = "3";
            t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituationValue = txtBonusSituationValue.Text;
            t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_DiscountValue = txtDiscountValue.Text;
            t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_CashPrize =txtCashPrize.Text;
            t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_CalculationMethod = txtCalculationMethod.Text;
            t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks = tatBonusSituationRemarks.Value;
        }
        else
        {
            t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusSituation = "0";
        }
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_WholeName = txtWholeName.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_Position = txtPosition.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_Phone = txtPhone.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_AccountName = txtAccountName.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_No = txtNo.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_IsTax = rdbIsTax1.Checked ? "1" : rdbIsTax2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_BonusMoney = txtBonusMoney.Text;
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_IsConfirm = rdbIsConfirm1.Checked ? "1" : rdbIsConfirm2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_EBAdjuct.OfficeAutomation_Document_EBAdjuct_SubmitDate = txtSubmitDate.Text;

        return t_OfficeAutomation_Document_EBAdjuct;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_EBAdjuct t_OfficeAutomation_Document_EBAdjuct = new T_OfficeAutomation_Document_EBAdjuct();
        DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_ID"].ToString();

        t_OfficeAutomation_Document_EBAdjuct = GetModelFromPage(new Guid(ID));

        string apply = EmployeeName;
        string depname = this.txtDepartment.Text;
        string summary = this.txtApplyID.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_EBAdjuct_Inherit.Update(t_OfficeAutomation_Document_EBAdjuct);//修改申请表

        DA_OfficeAutomation_Document_EBAdjuct_Detail_Inherit da_OfficeAutomation_Document_EBAdjuct_Detail_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Detail_Inherit();
        da_OfficeAutomation_Document_EBAdjuct_Detail_Inherit.Delete(ID);
        InsertEBAdjuctDetail(new Guid(ID));

        DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit da_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit();
        da_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit.Delete(ID);
        InsertEBAdjuctDetail1(new Guid(ID));

        DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit da_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit();
        da_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit.Delete(ID);
        InsertEBAdjuctDetail2(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 61, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增明细

    /// <summary>
    /// 新增详情表1
    /// </summary>
    /// <param name="gEBAdjuctID"></param>
    private void InsertEBAdjuctDetail(Guid gEBAdjuctID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_EBAdjuct_Detail t_OfficeAutomation_Document_EBAdjuct_Detail;
        DA_OfficeAutomation_Document_EBAdjuct_Detail_Inherit da_OfficeAutomation_Document_EBAdjuct_Detail_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_EBAdjuct_Detail = new T_OfficeAutomation_Document_EBAdjuct_Detail();
                t_OfficeAutomation_Document_EBAdjuct_Detail.OfficeAutomation_Document_EBAdjuct_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_EBAdjuct_Detail.OfficeAutomation_Document_EBAdjuct_Detail_MainID = gEBAdjuctID;

                t_OfficeAutomation_Document_EBAdjuct_Detail.OfficeAutomation_Document_EBAdjuct_Detail_Money = detail[0];
                t_OfficeAutomation_Document_EBAdjuct_Detail.OfficeAutomation_Document_EBAdjuct_Detail_Condition = detail[1];

                da_OfficeAutomation_Document_EBAdjuct_Detail_Inherit.Insert(t_OfficeAutomation_Document_EBAdjuct_Detail);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 新增详情表2
    /// </summary>
    /// <param name="gEBAdjuctID"></param>
    private void InsertEBAdjuctDetail1(Guid gEBAdjuctID)
    {
        if (hdDetail1.Value == "")
            return;

        T_OfficeAutomation_Document_EBAdjuct_LeaseTerm t_OfficeAutomation_Document_EBAdjuct_LeaseTerm;
        DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit da_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit();

        string[] details = Regex.Split(hdDetail1.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_EBAdjuct_LeaseTerm = new T_OfficeAutomation_Document_EBAdjuct_LeaseTerm();
                t_OfficeAutomation_Document_EBAdjuct_LeaseTerm.OfficeAutomation_Document_EBAdjuct_LeaseTerm_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_EBAdjuct_LeaseTerm.OfficeAutomation_Document_EBAdjuct_LeaseTerm_MainID = gEBAdjuctID;

                t_OfficeAutomation_Document_EBAdjuct_LeaseTerm.OfficeAutomation_Document_EBAdjuct_LeaseTerm_Money = detail[0];
                t_OfficeAutomation_Document_EBAdjuct_LeaseTerm.OfficeAutomation_Document_EBAdjuct_LeaseTerm_Reason = detail[1];
                t_OfficeAutomation_Document_EBAdjuct_LeaseTerm.OfficeAutomation_Document_EBAdjuct_LeaseTerm_Condition = detail[2];

                da_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit.Insert(t_OfficeAutomation_Document_EBAdjuct_LeaseTerm);
            }
        }
        catch(Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 新增详情表3
    /// </summary>
    /// <param name="gEBAdjuctID"></param>
    private void InsertEBAdjuctDetail2(Guid gEBAdjuctID)
    {
        if (hdDetail2.Value == "")
            return;

        T_OfficeAutomation_Document_EBAdjuct_Statistical t_OfficeAutomation_Document_EBAdjuct_Statistical;
        DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit da_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit();

        string[] details = Regex.Split(hdDetail2.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_EBAdjuct_Statistical = new T_OfficeAutomation_Document_EBAdjuct_Statistical();
                t_OfficeAutomation_Document_EBAdjuct_Statistical.OfficeAutomation_Document_EBAdjuct_Statistical_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_EBAdjuct_Statistical.OfficeAutomation_Document_EBAdjuct_Statistical_MainID = gEBAdjuctID;

                t_OfficeAutomation_Document_EBAdjuct_Statistical.OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct = detail[0];
                t_OfficeAutomation_Document_EBAdjuct_Statistical.OfficeAutomation_Document_EBAdjuct_Statistical_Money = detail[1];
                t_OfficeAutomation_Document_EBAdjuct_Statistical.OfficeAutomation_Document_EBAdjuct_Statistical_Reason = detail[2];
                t_OfficeAutomation_Document_EBAdjuct_Statistical.OfficeAutomation_Document_EBAdjuct_Statistical_Condition = detail[3];

                da_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit.Insert(t_OfficeAutomation_Document_EBAdjuct_Statistical);
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
        Session["FLG_ReWrite62"] = "1";
        Response.Write("<script>window.open('Apply_EBAdjuct_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("发展商额外奖金新增申请及调整申请.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
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

        DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_ID"].ToString(); //在不同的表要注意修改

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
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 130;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID; //在不同的表要注意删除
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 131;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

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
        Common.SendMessageEX(true, documentName, "黄瑛", "请审理", msnBody, msnBody,MainID);

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
            DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
            DataSet ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_EBAdjuct_Department"].ToString();
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
                if (i <= 6 && EmployeeID == "13545") //M_AddNWX：20150511
                {
                    da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "黄志超", "13545");
                    da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                }
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
            DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
            DataSet ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_EBAdjuct_Department"].ToString();
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
                da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "黄志超", "13545"); //M_AddNWX：20150511
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
            DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
            DataSet ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_EBAdjuct_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_EBAdjuct_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    protected void lbtnAddN_Click(object sender, EventArgs e) //M_AddNWX：20150511
    {
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "宁伟雄,黄志超", "5585,13545");
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1); //添加日志，添加流程
        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    }
    public void GetCCESP()
    {
        try
        {
            //wsAsset.GetAssetDic service = new wsAsset.GetAssetDic();
            //string s = service.GetKeyValue("place", "").Replace("Dic_Assets_Id", "id").Replace("Dic_Assets_Text", "value");
            //DA_CCES_Inherit cces = new DA_CCES_Inherit();
            //List<DbTable> list = new List<DbTable>();
            //List<DbTable> listNotLike = new List<DbTable>();
            //list.Clear();
            //list.Add(new DbTable("EstateName", txtApplyID.Text));
            //string sJsonIn = cces.fnGetJsonIn(list);
            //string s = cces.fnGetEstateListString(sJsonIn);
            DA_PMS_Project_Main_Inherit da_PMS_Project_Main_Inherit = new DA_PMS_Project_Main_Inherit();
            string s = da_PMS_Project_Main_Inherit.fnGetALLProjectListString();
            if (string.IsNullOrEmpty(s))
                s = "[]";
            SbCcesp.Append(s);
        }
        catch
        {
            SbCcesp.Append("[]");
        }
    }
}