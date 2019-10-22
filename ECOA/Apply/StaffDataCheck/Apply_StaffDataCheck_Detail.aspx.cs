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
using Newtonsoft.Json;

public partial class Apply_StaffDataCheck_Apply_StaffDataCheck_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();//控制是否显示4级以上的业绩
    public StringBuilder SbDetailHtml = new StringBuilder();//子表详细数据
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();

    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();

    public string sOfficeType = "";

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

        MainID = GetQueryString("MainID");
        SerialNumber = "";

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
                if (Session["FLG_ReWrite85"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite85"] = null;
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
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        DrawDetailTable(1);//初始化子表详细数据
        SbHtml.Append("<script type=\"text/javascript\">$(\".Achievement\").hide();$(\".zyhistory\").hide();</script>");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_StaffDataCheck_Operate StaffDataCheck_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Operate();

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
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = StaffDataCheck_Operate.SelectByMainID(MainID);

        #region FormInit
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_StaffDataCheck_ID"].ToString();

        string applicant = dr["OfficeAutomation_Document_StaffDataCheck_Apply"].ToString();
        ApplyN = applicant;
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        txtApplyName.Text = dr["OfficeAutomation_Document_StaffDataCheck_ApplyName"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_StaffDataCheck_Department"].ToString();
        txtPosition.Text = dr["OfficeAutomation_Document_StaffDataCheck_Position"].ToString();
        txtEntryDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_StaffDataCheck_EntryDate"].ToString()).ToString("yyyy-MM-dd");
        txtDataTurnDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_StaffDataCheck_DataTurnDate"].ToString()).ToString("yyyy-MM-dd");
        txtPay.Text = dr["OfficeAutomation_Document_StaffDataCheck_Pay"].ToString();
        switch (dr["OfficeAutomation_Document_StaffDataCheck_AgainEntry"].ToString())
        {
            case "1":
                rdbAgain1.Checked = true;
                SbHtml.Append("<script type=\"text/javascript\">$(\".zyhistory\").show();</script>");
                break;
            case "2":
                rdbAgain2.Checked = true;
                SbHtml.Append("<script type=\"text/javascript\">$(\".zyhistory\").hide();</script>");
                break;
            default:
                break;
        }
        txtDirectors.Text = dr["OfficeAutomation_Document_StaffDataCheck_Directors"].ToString();
        txtInfoSource.Text = dr["OfficeAutomation_Document_StaffDataCheck_InfoSource"].ToString();

        txtTeam.Text = dr["OfficeAutomation_Document_StaffDataCheck_Team"].ToString();
        txtTeamNum.Text = dr["OfficeAutomation_Document_StaffDataCheck_TeamNum"].ToString();
        txtExpertNum.Text = dr["OfficeAutomation_Document_StaffDataCheck_ExpertNum"].ToString();
        txtExpertFourNum.Text = dr["OfficeAutomation_Document_StaffDataCheck_ExpertFourNum"].ToString();
        txtInfoProvider.Text = dr["OfficeAutomation_Document_StaffDataCheck_InfoProvider"].ToString();
        txtOtherRemark.Text = dr["OfficeAutomation_Document_StaffDataCheck_OtherRemark"].ToString();
        txtBrokerCertificate.Text = dr["OfficeAutomation_Document_StaffDataCheck_BrokerCertificate"].ToString();
        txtEmployer.Text = dr["OfficeAutomation_Document_StaffDataCheck_Employer"].ToString();
        txtPhone.Text = dr["OfficeAutomation_Document_StaffDataCheck_Phone"].ToString();
        txtUrgentPhone.Text = dr["OfficeAutomation_Document_StaffDataCheck_UrgentPhone"].ToString();      

        txtOldDepartment.Text = dr["OfficeAutomation_Document_StaffDataCheck_OldDepartment"].ToString();
        txtOldPosition.Text = dr["OfficeAutomation_Document_StaffDataCheck_OldPosition"].ToString();
        txtOldDirectors.Text = dr["OfficeAutomation_Document_StaffDataCheck_OldDirectors"].ToString();
        if (!string.IsNullOrEmpty(dr["OfficeAutomation_Document_StaffDataCheck_OldEntryDate"].ToString()))
        {
            txtOldEntryDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_StaffDataCheck_OldEntryDate"].ToString()).ToString("yyyy-MM-dd");
        }
        if (!string.IsNullOrEmpty(dr["OfficeAutomation_Document_StaffDataCheck_OldLeaveDate"].ToString()))
        {
            txtOldLeaveDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_StaffDataCheck_OldLeaveDate"].ToString()).ToString("yyyy-MM-dd");
        }
        txtLeaveType.Text = dr["OfficeAutomation_Document_StaffDataCheck_OldLeaveDate"].ToString();
        txtEntryInfo.Text = dr["OfficeAutomation_Document_StaffDataCheck_EntryInfo"].ToString();
        txtEliteSituation.Text = dr["OfficeAutomation_Document_StaffDataCheck_EliteSituation"].ToString();
        txtRulesSituation.Text = dr["OfficeAutomation_Document_StaffDataCheck_RulesSituation"].ToString();
        txtAcountProfit.Text = dr["OfficeAutomation_Document_StaffDataCheck_AcountProfit"].ToString();

        if (!string.IsNullOrEmpty(dr["OfficeAutomation_Document_StaffDataCheck_Month1"].ToString())) 
        {
            SbHtml.Append("<script type=\"text/javascript\">$(\".Achievement\").show();");
            SbHtml.Append("$(\"#rdbFour1\").attr('checked','checked');");
            SbHtml.Append("</script>");
        }
        else if (string.IsNullOrEmpty(dr["OfficeAutomation_Document_StaffDataCheck_Month1"].ToString()))
        {
            SbHtml.Append("<script type=\"text/javascript\">$(\".Achievement\").hide();");
            SbHtml.Append("$(\"#rdbFour2\").attr('checked','checked');");
            SbHtml.Append("</script>");
        }
        txtMonth1.Text = dr["OfficeAutomation_Document_StaffDataCheck_Month1"].ToString();
        txtAchievement1.Text = dr["OfficeAutomation_Document_StaffDataCheck_Achievement1"].ToString();
        txtResultAchievement1.Text = dr["OfficeAutomation_Document_StaffDataCheck_ResultAchievement1"].ToString();
        txtMonth2.Text = dr["OfficeAutomation_Document_StaffDataCheck_Month2"].ToString();
        txtAchievement2.Text = dr["OfficeAutomation_Document_StaffDataCheck_Achievement2"].ToString();
        txtResultAchievement2.Text = dr["OfficeAutomation_Document_StaffDataCheck_ResultAchievement2"].ToString();
        txtMonth3.Text = dr["OfficeAutomation_Document_StaffDataCheck_Month3"].ToString();
        txtAchievement3.Text = dr["OfficeAutomation_Document_StaffDataCheck_Achievement3"].ToString();
        txtResultAchievement3.Text = dr["OfficeAutomation_Document_StaffDataCheck_ResultAchievement3"].ToString();
        txtMonth4.Text = dr["OfficeAutomation_Document_StaffDataCheck_Month4"].ToString();
        txtAchievement4.Text = dr["OfficeAutomation_Document_StaffDataCheck_Achievement4"].ToString();
        txtResultAchievement4.Text = dr["OfficeAutomation_Document_StaffDataCheck_ResultAchievement4"].ToString();
        txtMonth5.Text = dr["OfficeAutomation_Document_StaffDataCheck_Month5"].ToString();
        txtAchievement5.Text = dr["OfficeAutomation_Document_StaffDataCheck_Achievement5"].ToString();
        txtResultAchievement5.Text = dr["OfficeAutomation_Document_StaffDataCheck_ResultAchievement5"].ToString();
        txtMonth6.Text = dr["OfficeAutomation_Document_StaffDataCheck_Month6"].ToString();
        txtAchievement6.Text = dr["OfficeAutomation_Document_StaffDataCheck_Achievement6"].ToString();
        txtResultAchievement6.Text = dr["OfficeAutomation_Document_StaffDataCheck_ResultAchievement6"].ToString();
        txtAchievementSum.Text = dr["OfficeAutomation_Document_StaffDataCheck_AchievementSum"].ToString();
        txtResultAchievementSum.Text = dr["OfficeAutomation_Document_StaffDataCheck_ResultAchievementSum"].ToString();
        txtDifferenceSituation.Text = dr["OfficeAutomation_Document_StaffDataCheck_DifferenceSituation"].ToString();

        //子表数据
        DA_OfficeAutomation_Document_StaffDataCheck_Detail_Operate StaffDataCheck_Detail_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Detail_Operate();
        ds = StaffDataCheck_Detail_Operate.SelectByID(ID);
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

                SbJs.Append("$('#txtCompany" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Company"] + "');");
                SbJs.Append("$('#txtProviderPosition" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_ProviderPosition"] + "');");
                SbJs.Append("$('#txtProvider1" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Provider"] + "');");
                SbJs.Append("$('#txtDetailPhone" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Phone"] + "');");

                SbJs.Append("$('#txtDetailDepartment1" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Department"] + "');");
                switch (dr["OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentResult"].ToString())
                {
                    case "1":
                        SbJs.Append("$('#rdbDepartment1" + i + "').attr('checked','checked');");
                        break;
                    case "2":
                        SbJs.Append("$('#rdbDepartment2" + i + "').attr('checked','checked');");
                        SbJs.Append("$('#txtDepartmentRemark" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentRemark"] + "');");
                        break;
                    //case "3":
                    //    SbJs.Append("$('#rdbDepartment3" + i + "').attr('checked','checked');");
                    //    break;
                    default:
                        break;
                }
                SbJs.Append("$('#txtDetailPosition" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Position"] + "');");
                switch (dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionResult"].ToString())
                {
                    case "1":
                        SbJs.Append("$('#rdbPosition1" + i + "').attr('checked','checked');");
                        break;
                    case "2":
                        SbJs.Append("$('#rdbPosition2" + i + "').attr('checked','checked');");
                        SbJs.Append("$('#txtPositionRemark" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionRemark"] + "');");
                        break;
                    //case "3":
                    //    SbJs.Append("$('#rdbPosition3" + i + "').attr('checked','checked');");
                    //    break;
                    default:
                        break;
                }
                SbJs.Append("$('#txtPositionDate1" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionDate"] + "');");
                switch (dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateResult"].ToString())
                {
                    case "1":
                        SbJs.Append("$('#rdbPositionDate1" + i + "').attr('checked','checked');");
                        break;
                    case "2":
                        SbJs.Append("$('#rdbPositionDate2" + i + "').attr('checked','checked');");
                        SbJs.Append("$('#txtPositionDateRemark" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateRemark"] + "');");
                        break;
                    //case "3":
                    //    SbJs.Append("$('#rdbPositionDate3" + i + "').attr('checked','checked');");
                    //    break;
                    default:
                        break;
                }
                SbJs.Append("$('#txtLeaveReason1" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReason"] + "');");
                switch (dr["OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonResult"].ToString())
                {
                    case "1":
                        SbJs.Append("$('#rdbLeaveReason1" + i + "').attr('checked','checked');");
                        break;
                    case "2":
                        SbJs.Append("$('#rdbLeaveReason2" + i + "').attr('checked','checked');");
                        SbJs.Append("$('#txtLeaveReasonRemark" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonRemark"] + "');");
                        break;
                    //case "3":
                    //    SbJs.Append("$('#rdbLeaveReason3" + i + "').attr('checked','checked');");
                    //    break;
                    default:
                        break;
                }
                switch (dr["OfficeAutomation_Document_StaffDataCheck_Detail_Misdeeds"].ToString())
                {
                    case "1":
                        SbJs.Append("$('#rdbMisdeeds1" + i + "').attr('checked','checked');");
                        break;
                    case "2":
                        SbJs.Append("$('#rdbMisdeeds2" + i + "').attr('checked','checked');");
                        break;
                    default:
                        break;
                }
                SbJs.Append("$('#txtMisdeedsRemark" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_MisdeedsRemark"] + "');");
                SbJs.Append("$('#txtPerformance" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Performance"] + "');");
                SbJs.Append("$('#txtPerformanceRemark" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_PerformanceRemark"] + "');");
                SbJs.Append("$('#txtTeamNumAndDate1" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDate"] + "');");
                SbJs.Append("$('#txtTeamNumAndDateRemark" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDateRemark"] + "');");
                SbJs.Append("$('#txtAbility" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Ability"] + "');");
                //switch (dr["OfficeAutomation_Document_StaffDataCheck_Detail_Ability"].ToString())
                //{
                //    case "1":
                //        SbJs.Append("$('#rdbAbility1" + i + "').attr('checked','checked');");
                //        break;
                //    case "2":
                //        SbJs.Append("$('#rdbAbility2" + i + "').attr('checked','checked');");
                //        break;
                //    case "3":
                //        SbJs.Append("$('#rdbAbility3" + i + "').attr('checked','checked');");
                //        break;
                //    case "4":
                //        SbJs.Append("$('#rdbAbility4" + i + "').attr('checked','checked');");
                //        break;
                //    case "5":
                //        SbJs.Append("$('#rdbAbility5" + i + "').attr('checked','checked');");
                //        break;
                //    default:
                //        break;
                //}
                SbJs.Append("$('#txtAbilityRemark" + i + "').val('" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_AbilityRemark"] + "');");
            }
        }
        #endregion

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;

        try
        {
            //2016-12-19修改 注释掉法律部人审批之后不能上传附件功能

            //if (drc[4]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
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
            }
            if (flowState == "2") //20141215：M_AlterC 20170307修改  去掉 && drc[4]["OfficeAutomation_Flow_AuditorID"].ToString() == ""
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
            }
        }

        //try //M_AddAnother：20150716 黄生其它意见，增加审批人
        //{
        //    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
        //    DataSet dsFlow2 = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
        //    DataRowCollection drcz = dsFlow2.Tables[0].Rows;
        //    T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 2);
        //    flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 200);
        //    flowst = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndEID(MainID, "0001");

        //    if (flowsa != null)
        //        SbJs.Append("$(\"#trAddAnoF1\").show();");
        //    if (((drcz[0]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID)
        //        && drcz[0]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName))
        //        && flowst.OfficeAutomation_Flow_IsAgree == 2)
        //        || (EmployeeName == applicant && flowst.OfficeAutomation_Flow_IsAgree == 2) || (fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowst.OfficeAutomation_Flow_IsAgree == 2)
        //        )
        //    {
        //        SbJs.Append("$(\"#trAddAnoF1\").show();");
        //        //btnsSignIDx200.Visible = true;
        //        //if ((!fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName)) && flowsa != null)
        //        //    btnsSignIDx200.Visible = false; //M_AlAno：20160217 ++
        //    }

        //    flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 220);
        //    if (flowsa != null)
        //        SbJs.Append("$(\"#trAddAnoF3\").show();");
        //    //if (flowst.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)
        //    //    && flowst.OfficeAutomation_Flow_Auditor.Contains(EmployeeName)
        //    //    && flowst.OfficeAutomation_Flow_IsAgree == 2
        //    //    && flowsa != null
        //    //    )
        //    //    btnsSignIDx220.Visible = true;
        //}
        //catch
        //{
        //}

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                //SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
                SbJs.Append("</script>");
                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                flowState = "1";
                btnSAlterC.Visible = false;
                return;
            }
        }
        catch
        {
            if (isApplicant)
                btnReWrite.Visible = true; //*-+
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        if (Purview.Contains("OA_Search_002"))//789
            GetAllDepartment();
        if (EmployeeID == "10054")
            SbJs.Append("$(\"#afa\").show();$(\"#dfd\").show();");
       
        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        bool showf = true; //M_HideFlows：20150330
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
            //    SbJs.Append("$(\"#trShowFlow10\").hide();$(\"#trLogistics2\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            //    SbJs.Append("$(\"#tlsc1\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            //}

            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                SbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                //if (curemp.Contains(EmployeeName)) //M_Add：黄志超 20150202
                //{
                //    switch (curidx)
                //    {
                //        case "7":
                //           // ckbAddIDx.Visible = true;
                //            break;
                //        default:
                //            break;
                //    }
                //}
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

            //if (i >= 2 && int.Parse(drc[i]["OfficeAutomation_Flow_Idx"].ToString()) >= 200) //M_AddAnother：20150716 黄生其它意见，增加审批人
            //{
            //    SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_AuditDate"].ToString() + "');");
            //    SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

            //    if (drc[i]["OfficeAutomation_Flow_AuditDate"].ToString() != "" && drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString().Contains(EmployeeID) && drc[i]["OfficeAutomation_Flow_Employee"].ToString().Contains(EmployeeName))
            //    { //M_RA：20151120
            //        SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 98%; \">"
            //                   + "<br/>上一次复审意见：<br/><br/>" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "").Replace("\n", "<br/>") + "<br/><br/></div>').val('');");
            //    }

            //    if (auditorIDs.Length > 0 && auditorIDs[0] != "")
            //    {
            //        SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').after('<div style=\"width: 200px; line-height: 55px; height: 2px; margin-left:20px; float:left;\">"
            //                           + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
            //        foreach (string s in auditorIDs)
            //        {
            //            SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" />");
            //        }
            //        SbJs.Append("');");

            //        if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "1") //M_AlterM：20150820
            //            SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a1').attr('checked','checked');");
            //        else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
            //            SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a2').attr('checked','checked');");
            //        else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
            //            SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a3').attr('checked','checked');");
            //    }
            //}

            #endregion
        }

        ////如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        //if (flag3)
        //    SbJs.Append("$('#trLogistics').show();$('#trGeneralManager').show();");

        T_OfficeAutomation_Flow flows;//789
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        if (flows != null)
            SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && applicant == EmployeeName && !tpdf && showf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

        if (!showf) //M_HideFlows：20150330
            SbFlow.Length = 0;

        if (EmployeeID == "10054" || EmployeeID == "34498") //M_WinnEnd：20150204
            btnWillEnd.Visible = true;

        //20170206注释
        //if (EmployeeName == "张绍欣") //M_EmmaJump：20160118
        //    btnShouldJumpIDxEmma.Visible = true;

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
        T_OfficeAutomation_Document_StaffDataCheck StaffDataCheck = new T_OfficeAutomation_Document_StaffDataCheck();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_StaffDataCheck_Operate StaffDataCheck_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Operate();
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
                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "StaffDataCheck" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 81;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                var DID = Guid.NewGuid();
                StaffDataCheck = GetModelFromPage(DID);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = this.txtDifferenceSituation.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                StaffDataCheck_Operate.Add(StaffDataCheck);//插入申请表

                InsertDetail(GetDetailEntityList(this.hidDetail.Value), DID);//详细表

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

                Common.AddLog(EmployeeID, EmployeeName, 85, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_StaffDataCheck_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
        DataSet dsg = new DataSet(); //20150105：M_DeleteC
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
        dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
        if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
            return;
        }
        DA_OfficeAutomation_Document_StaffDataCheck_Operate StaffDataCheck_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Operate();
        DA_OfficeAutomation_Document_StaffDataCheck_Detail_Operate StaffDataCheck_Detail_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Detail_Operate();

        DataSet ds = StaffDataCheck_Operate.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_StaffDataCheck_ID"].ToString();

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

                //bool isSignSuccess = flowIDx == "5" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                //string[] flowN;
                //flowN = ViewState["FSIN"].ToString().Split(',');//789
                //bool isSignSuccess = (flowIDx == "5" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                bool isSignSuccess = flowIDx != "1" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_StaffDataCheck_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_StaffDataCheck_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();

                    sbMailBody.Append("<br/><br/>申请人姓名：" + drRow["OfficeAutomation_Document_StaffDataCheck_ApplyName"]);
                    sbMailBody.Append("<br/>拟入职部门：" + drRow["OfficeAutomation_Document_StaffDataCheck_Department"]);
                    sbMailBody.Append("<br/>拟申请职位：" + drRow["OfficeAutomation_Document_StaffDataCheck_Position"].ToString());
                    sbMailBody.Append("<br/>拟入职日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_StaffDataCheck_EntryDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>资料递交日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_StaffDataCheck_DataTurnDate"].ToString()).ToString("yyyy-MM-dd")); ;
                    sbMailBody.Append("<br/>薪酬：" + drRow["OfficeAutomation_Document_StaffDataCheck_Pay"]);
                    sbMailBody.Append("<br/>是否再次入职：" + drRow["OfficeAutomation_Document_StaffDataCheck_AgainEntry"].ToString()=="1"?"是":"否");
                    sbMailBody.Append("<br/>上级主管：" + drRow["OfficeAutomation_Document_StaffDataCheck_Directors"]);
                    sbMailBody.Append("<br/>招聘来源：" + drRow["OfficeAutomation_Document_StaffDataCheck_InfoSource"].ToString());

                    sbMailBody.Append("<br/>入职后带领团队：" + drRow["OfficeAutomation_Document_StaffDataCheck_Team"].ToString());
                    sbMailBody.Append("<br/>团队人数：" + drRow["OfficeAutomation_Document_StaffDataCheck_TeamNum"]);
                    sbMailBody.Append("<br/>行家过档人数：" + drRow["OfficeAutomation_Document_StaffDataCheck_ExpertNum"]);
                    sbMailBody.Append("<br/>过档人员中4级及以上人数：" + drRow["OfficeAutomation_Document_StaffDataCheck_ExpertFourNum"]);
                    sbMailBody.Append("<br/>信息提供人：" + drRow["OfficeAutomation_Document_StaffDataCheck_InfoProvider"].ToString());
                    sbMailBody.Append("<br/>其他情况备注：" + drRow["OfficeAutomation_Document_StaffDataCheck_OtherRemark"].ToString());

                    sbMailBody.Append("<br/>经纪证号码：" + drRow["OfficeAutomation_Document_StaffDataCheck_BrokerCertificate"]);
                    sbMailBody.Append("<br/>经纪证挂靠单位：" + drRow["OfficeAutomation_Document_StaffDataCheck_Employer"]);
                    sbMailBody.Append("<br/>联系电话：" + drRow["OfficeAutomation_Document_StaffDataCheck_Phone"]);
                    sbMailBody.Append("<br/>紧急联系人/电话：" + drRow["OfficeAutomation_Document_StaffDataCheck_UrgentPhone"]);

                    #region 明细
                    ds = StaffDataCheck_Detail_Operate.SelectByID(ID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>公司名称：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Company"]);
                        sbMailBody.Append("<br/>信息提供人职位：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_ProviderPosition"]);
                        sbMailBody.Append("<br/>信息提供人：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Provider"]);
                        sbMailBody.Append("<br/>联系电话：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Phone"]);
                        sbMailBody.Append("<br/>就职部门：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Department"]);
                        if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentResult"].ToString() == "1")
                        {
                            sbMailBody.Append("<br/>核查结果：是");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentResult"].ToString() == "2")
                        {
                            sbMailBody.Append("<br/>核查结果：否");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentResult"].ToString() == "3")
                        {
                            sbMailBody.Append("<br/>核查结果：其它 " + dr["OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentRemark"].ToString());
                        }
                        sbMailBody.Append("<br/>职位：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Position"]);
                        if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionResult"].ToString() == "1")
                        {
                            sbMailBody.Append("<br/>核查结果：是");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionResult"].ToString() == "2")
                        {
                            sbMailBody.Append("<br/>核查结果：否");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionResult"].ToString() == "3")
                        {
                            sbMailBody.Append("<br/>核查结果：其它 " + dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionRemark"].ToString());
                        }
                        sbMailBody.Append("<br/>任职时间：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionDate"].ToString());
                        if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateResult"].ToString() == "1")
                        {
                            sbMailBody.Append("<br/>核查结果：是");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateResult"].ToString() == "2")
                        {
                            sbMailBody.Append("<br/>核查结果：否");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateResult"].ToString() == "3")
                        {
                            sbMailBody.Append("<br/>核查结果：其它 " + dr["OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateRemark"].ToString());
                        }
                        sbMailBody.Append("<br/>离职原因：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReason"]);
                        if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonResult"].ToString() == "1")
                        {
                            sbMailBody.Append("<br/>核查结果：是");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonResult"].ToString() == "2")
                        {
                            sbMailBody.Append("<br/>核查结果：否");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonResult"].ToString() == "3")
                        {
                            sbMailBody.Append("<br/>核查结果：其它 " + dr["OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonRemark"].ToString());
                        }
                        sbMailBody.Append("<br/>是否有违规违纪行为：" + (dr["OfficeAutomation_Document_StaffDataCheck_Detail_Misdeeds"].ToString() == "1" ? "有" : "无"));
                        sbMailBody.Append("<br/>备注：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_MisdeedsRemark"].ToString());
                        sbMailBody.Append("<br/>业绩情况：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_Performance"].ToString());
                        sbMailBody.Append("<br/>备注：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_PerformanceRemark"].ToString());
                        sbMailBody.Append("<br/>带团队规模及时间：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDate"]);
                        sbMailBody.Append("<br/>备注：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDateRemark"].ToString());
                        if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_Ability"].ToString() == "1")
                        {
                            sbMailBody.Append("<br/>团队管理能力：卓越");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_Ability"].ToString() == "2")
                        {
                            sbMailBody.Append("<br/>团队管理能力：优秀");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_Ability"].ToString() == "3")
                        {
                            sbMailBody.Append("<br/>团队管理能力：合格");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_Ability"].ToString() == "4")
                        {
                            sbMailBody.Append("<br/>团队管理能力：需要改进");
                        }
                        else if (dr["OfficeAutomation_Document_StaffDataCheck_Detail_Ability"].ToString() == "5")
                        {
                            sbMailBody.Append("<br/>团队管理能力：不可接受");
                        }
                        sbMailBody.Append("<br/>备注：" + dr["OfficeAutomation_Document_StaffDataCheck_Detail_AbilityRemark"].ToString());
                    }
                    #endregion



                    sbMailBody.Append("<br/>原任职部门：" + drRow["OfficeAutomation_Document_StaffDataCheck_OldDepartment"].ToString());
                    sbMailBody.Append("<br/>原任职职位：" + drRow["OfficeAutomation_Document_StaffDataCheck_OldPosition"]);
                    sbMailBody.Append("<br/>原直属主管：" + drRow["OfficeAutomation_Document_StaffDataCheck_OldDirectors"]);
                    sbMailBody.Append("<br/>原入职日期：" +  drRow["OfficeAutomation_Document_StaffDataCheck_OldEntryDate"].ToString());
                    sbMailBody.Append("<br/>原离职日期：" +  drRow["OfficeAutomation_Document_StaffDataCheck_OldLeaveDate"].ToString());
                    sbMailBody.Append("<br/>离职性质：" + drRow["OfficeAutomation_Document_StaffDataCheck_LeaveType"].ToString());
                    sbMailBody.Append("<br/>任职历史：" + drRow["OfficeAutomation_Document_StaffDataCheck_EntryInfo"].ToString());
                    sbMailBody.Append("<br/>精英会情况：" + drRow["OfficeAutomation_Document_StaffDataCheck_EliteSituation"]);
                    sbMailBody.Append("<br/>违规情况：" + drRow["OfficeAutomation_Document_StaffDataCheck_RulesSituation"]);
                    sbMailBody.Append("<br/>管理帐利润：" + drRow["OfficeAutomation_Document_StaffDataCheck_AcountProfit"]);
                    sbMailBody.Append("<br/>月份1：" + drRow["OfficeAutomation_Document_StaffDataCheck_Month1"]);
                    sbMailBody.Append("<br/>应收业绩1：" + drRow["OfficeAutomation_Document_StaffDataCheck_Achievement1"]);
                    sbMailBody.Append("<br/>实收业绩1：" + drRow["OfficeAutomation_Document_StaffDataCheck_ResultAchievement1"]);
                    sbMailBody.Append("<br/>月份2：" + drRow["OfficeAutomation_Document_StaffDataCheck_Month2"]);
                    sbMailBody.Append("<br/>应收业绩2：" + drRow["OfficeAutomation_Document_StaffDataCheck_Achievement2"]);
                    sbMailBody.Append("<br/>实收业绩2：" + drRow["OfficeAutomation_Document_StaffDataCheck_ResultAchievement2"]);
                    sbMailBody.Append("<br/>月份3：" + drRow["OfficeAutomation_Document_StaffDataCheck_Month3"]);
                    sbMailBody.Append("<br/>应收业绩3：" + drRow["OfficeAutomation_Document_StaffDataCheck_Achievement3"]);
                    sbMailBody.Append("<br/>实收业绩3：" + drRow["OfficeAutomation_Document_StaffDataCheck_ResultAchievement3"]);
                    sbMailBody.Append("<br/>月份4：" + drRow["OfficeAutomation_Document_StaffDataCheck_Month4"]);
                    sbMailBody.Append("<br/>应收业绩4：" + drRow["OfficeAutomation_Document_StaffDataCheck_Achievement4"]);
                    sbMailBody.Append("<br/>实收业绩4：" + drRow["OfficeAutomation_Document_StaffDataCheck_ResultAchievement4"]);
                    sbMailBody.Append("<br/>月份5：" + drRow["OfficeAutomation_Document_StaffDataCheck_Month5"]);
                    sbMailBody.Append("<br/>应收业绩5：" + drRow["OfficeAutomation_Document_StaffDataCheck_Achievement5"]);
                    sbMailBody.Append("<br/>实收业绩5：" + drRow["OfficeAutomation_Document_StaffDataCheck_ResultAchievement5"]);
                    sbMailBody.Append("<br/>月份6：" + drRow["OfficeAutomation_Document_StaffDataCheck_Month6"]);
                    sbMailBody.Append("<br/>应收业绩6：" + drRow["OfficeAutomation_Document_StaffDataCheck_Achievement6"]);
                    sbMailBody.Append("<br/>实收业绩6：" + drRow["OfficeAutomation_Document_StaffDataCheck_ResultAchievement6"]);

                    sbMailBody.Append("<br/>应收业绩合计：" + drRow["OfficeAutomation_Document_StaffDataCheck_AchievementSum"]);
                    sbMailBody.Append("<br/>实收业绩合计：" + drRow["OfficeAutomation_Document_StaffDataCheck_ResultAchievementSum"].ToString());
                    sbMailBody.Append("<br/>备注：" + drRow["OfficeAutomation_Document_StaffDataCheck_DifferenceSituation"].ToString());
                    sbMailBody.Append("<br/>");                   

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
                            string sagree = "";
                            foreach (DataRow dr in dsFlow.Tables[0].Rows)
                            {
                                if (hdSuggestion.Value != "")
                                {
                                    sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;
                                }
                                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    if (!employeeList.Contains(employnames[i]))
                                    {
                                        msnBody = "您好，" + employnames[i] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        email = employnames[i];
                                        if (hdIsAgree.Value == "2")
                                            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                        else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                        employeeList += employnames[i] + "||";
                                    }
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
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody, MainID);
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
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
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
        //    DA_OfficeAutomation_Document_ProjRepoData_Inherit da_OfficeAutomation_Document_ProjRepoData_Inherit = new DA_OfficeAutomation_Document_ProjRepoData_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "24962")
        //        da_OfficeAutomation_Document_ProjRepoData_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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
                if (drc[4]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
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
        T_OfficeAutomation_Document_StaffDataCheck StaffDataCheck = new T_OfficeAutomation_Document_StaffDataCheck();
        DA_OfficeAutomation_Document_StaffDataCheck_Operate StaffDataCheck_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Operate();

        DataSet ds = new DataSet();
        ds = StaffDataCheck_Operate.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_StaffDataCheck_ID"].ToString();

        StaffDataCheck = GetModelFromPage(new Guid(ID));

        string apply = "";
        string depname = this.txtDepartment.Text;
        string summary = this.txtDifferenceSituation.Text;
        string applydate = "";
        string mainid = MainID;

        new DA_OfficeAutomation_Main_Inherit().UpdateMain(mainid, depname, apply, applydate, summary);
        StaffDataCheck_Operate.Edit(StaffDataCheck);//修改申请表

        //修改子表数据
        InsertDetail(GetDetailEntityList(this.hidDetail.Value), new Guid(ID));
        
        Common.AddLog(EmployeeID, EmployeeName, 85, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 从页面中获得model

    private T_OfficeAutomation_Document_StaffDataCheck GetModelFromPage(Guid StaffDataCheckID)
    {
        DataEntity.T_OfficeAutomation_Document_StaffDataCheck model = new DataEntity.T_OfficeAutomation_Document_StaffDataCheck();
        model.OfficeAutomation_Document_StaffDataCheck_ID = StaffDataCheckID;
        model.OfficeAutomation_Document_StaffDataCheck_MainID = new Guid(MainID);
        model.OfficeAutomation_Document_StaffDataCheck_ApplyDate = DateTime.Now;
        model.OfficeAutomation_Document_StaffDataCheck_Apply = EmployeeName;
        model.OfficeAutomation_Document_StaffDataCheck_ApplyID = EmployeeID;

        model.OfficeAutomation_Document_StaffDataCheck_ApplyName = txtApplyName.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Department = txtDepartment.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Position = txtPosition.Text;
        model.OfficeAutomation_Document_StaffDataCheck_EntryDate = txtEntryDate.Text;
        model.OfficeAutomation_Document_StaffDataCheck_DataTurnDate = txtDataTurnDate.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Pay = txtPay.Text;
        model.OfficeAutomation_Document_StaffDataCheck_AgainEntry = rdbAgain1.Checked ? "1" : "2";
        model.OfficeAutomation_Document_StaffDataCheck_Directors = txtDirectors.Text;
        model.OfficeAutomation_Document_StaffDataCheck_InfoSource = txtInfoSource.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Team = txtTeam.Text;
        model.OfficeAutomation_Document_StaffDataCheck_TeamNum = txtTeamNum.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ExpertNum = txtExpertNum.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ExpertFourNum = txtExpertFourNum.Text;
        model.OfficeAutomation_Document_StaffDataCheck_InfoProvider = txtInfoProvider.Text;
        model.OfficeAutomation_Document_StaffDataCheck_OtherRemark = txtOtherRemark.Text;
        model.OfficeAutomation_Document_StaffDataCheck_BrokerCertificate = txtBrokerCertificate.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Employer = txtEmployer.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Phone = txtPhone.Text;
        model.OfficeAutomation_Document_StaffDataCheck_UrgentPhone = txtUrgentPhone.Text;
       
        model.OfficeAutomation_Document_StaffDataCheck_OldDepartment = txtOldDepartment.Text;
        model.OfficeAutomation_Document_StaffDataCheck_OldPosition = txtOldPosition.Text;
        model.OfficeAutomation_Document_StaffDataCheck_OldDirectors = txtOldDirectors.Text;
        model.OfficeAutomation_Document_StaffDataCheck_OldEntryDate = txtOldEntryDate.Text;
        model.OfficeAutomation_Document_StaffDataCheck_OldLeaveDate = txtOldLeaveDate.Text;
        model.OfficeAutomation_Document_StaffDataCheck_LeaveType = txtLeaveType.Text;
        model.OfficeAutomation_Document_StaffDataCheck_EntryInfo = txtEntryInfo.Text;
        model.OfficeAutomation_Document_StaffDataCheck_RulesSituation = txtRulesSituation.Text;
        model.OfficeAutomation_Document_StaffDataCheck_RulesSituation = txtRulesSituation.Text;

        model.OfficeAutomation_Document_StaffDataCheck_AcountProfit = txtAcountProfit.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Month1 = txtMonth1.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Achievement1 = txtAchievement1.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ResultAchievement1 = txtResultAchievement1.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Month2 = txtMonth2.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Achievement2 = txtAchievement2.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ResultAchievement2 = txtResultAchievement2.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Month3 = txtMonth3.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Achievement3 = txtAchievement3.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ResultAchievement3 = txtResultAchievement3.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Month4 = txtMonth4.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Achievement4 = txtAchievement4.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ResultAchievement4 = txtResultAchievement4.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Month5 = txtMonth5.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Achievement5 = txtAchievement5.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ResultAchievement5 = txtResultAchievement5.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Month6 = txtMonth6.Text;
        model.OfficeAutomation_Document_StaffDataCheck_Achievement6 = txtAchievement6.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ResultAchievement6 = txtResultAchievement6.Text;
        model.OfficeAutomation_Document_StaffDataCheck_AchievementSum = txtAchievementSum.Text;
        model.OfficeAutomation_Document_StaffDataCheck_ResultAchievementSum = txtResultAchievementSum.Text;
        model.OfficeAutomation_Document_StaffDataCheck_DifferenceSituation = txtDifferenceSituation.Text;

        return model;
    }
   
    #endregion

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        if (Cache["AllDepartmentSimple"] == null)
        {
            SbJson.Remove(0, SbJson.Length);
            wsKDHR.Service service = new wsKDHR.Service();
            DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
            SbJson.Append("[");

            //简单去除分行下面的组别，变分行，简单过滤重复。
            string name;
            foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
            {
                name = dr["name"].ToString();
                Match m = Regex.Match(name, "[A-Z]{1}组");
                if (m.Success)//去除组别
                    name = name.Substring(0, m.Index);

                m = Regex.Match(name, "(\\(|（)+\\w+(\\)|）)+");
                if (m.Success)//去除括号
                    name = name.Substring(0, m.Index);

                m = Regex.Match(name, "[A-Z]$");
                if (m.Success)//去除名称尾部的ABCD
                    name = name.Substring(0, m.Index);

                if (!SbJson.ToString().Contains(name))
                    SbJson.Append("{\"value\":\"" + name + "\"},");
            }

            SbJson.Remove(SbJson.Length - 1, 1);
            SbJson.Append("]");
            Cache["AllDepartmentSimple"] = SbJson;
        }
        else
            SbJson = (StringBuilder)Cache["AllDepartmentSimple"];
    }
    #endregion

    #region 解析json获取子表数据
    private List<T_OfficeAutomation_Document_StaffDataCheck_Detail> GetDetailEntityList(string DetailJson)
    {
        if (string.IsNullOrEmpty(DetailJson))
        {
            return null;
        }
        return JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_StaffDataCheck_Detail>>(DetailJson);

    }
    #endregion
    #region 新增子表数据
    private void InsertDetail(List<T_OfficeAutomation_Document_StaffDataCheck_Detail> list, Guid mID)
    {
        var StaffDataCheckDetailBLL = new DA_OfficeAutomation_Document_StaffDataCheck_Detail_Operate();
        StaffDataCheckDetailBLL.DelByMainID(mID.ToString());//清空主表相关明细
        if (list != null && list.Count > 0)
        {
            foreach (var i in list)
            {
                i.OfficeAutomation_Document_StaffDataCheck_Detail_ID = Guid.NewGuid();
                i.OfficeAutomation_Document_StaffDataCheck_Detail_MainID = mID;
                if(i.OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentResult!="2")
                {
                    i.OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentRemark = "";
                }
                if (i.OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonResult != "2")
                {
                    i.OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonRemark = "";
                }
                if (i.OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateResult != "2")
                {
                    i.OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateRemark = "";
                }
                if (i.OfficeAutomation_Document_StaffDataCheck_Detail_PositionResult != "2")
                {
                    i.OfficeAutomation_Document_StaffDataCheck_Detail_PositionRemark = "";
                }
                StaffDataCheckDetailBLL.Add(i);
            }
        }
    }
    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite85"] = "1";
        Response.Write("<script>window.open('Apply_StaffDataCheck_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("六级及以上营业人员入职资料核查表.pdf"));//强制下载 
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

        DA_OfficeAutomation_Document_StaffDataCheck_Operate staffDataCheck_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Operate();
        DataSet ds = new DataSet();
        ds = staffDataCheck_Operate.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_StaffDataCheck_ID"].ToString(); //在不同的表要注意修改

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
        Common.AddLog(EmployeeID, EmployeeName, 85, new Guid(MainID), 3); //添加日志，删除流程
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
            DA_OfficeAutomation_Document_StaffDataCheck_Operate staffDataCheck_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Operate();
            DataSet ds = staffDataCheck_Operate.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_StaffDataCheck_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_StaffDataCheck_Department"].ToString();
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
                //if (i < 8)
                //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "8");
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
                Common.AddLog(EmployeeID, EmployeeName, 85, new Guid(MainID), 3); //添加日志，撤销签名
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
            DA_OfficeAutomation_Document_StaffDataCheck_Operate staffDataCheck_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Operate();
            DataSet ds = staffDataCheck_Operate.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_StaffDataCheck_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_StaffDataCheck_Department"].ToString();
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
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "8");
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
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
            DA_OfficeAutomation_Document_StaffDataCheck_Operate staffDataCheck_Operate = new DA_OfficeAutomation_Document_StaffDataCheck_Operate();
            DataSet ds = staffDataCheck_Operate.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_StaffDataCheck_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_StaffDataCheck_Department"].ToString();
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
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "8");
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_StaffDataCheck_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    //子表数据显示
    public void DrawDetailTable(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbDetailHtml.Append("<tbody id='company"+ i +"'>");                       
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\">公司名称"+i+"</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"5\"><input id=\"txtCompany"+i+"\" type=\"text\" style=\"width:200px\" /></td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");

            SbDetailHtml.Append("<td class=\"auto-style4\">信息提供人</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\"><input id=\"txtProvider1" + i + "\" type=\"text\" style=\"width:100px\" /></td>");
            SbDetailHtml.Append("<td class=\"auto-style4\" style=\"width:88px;\">信息提供人职位</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" ><input id=\"txtProviderPosition"+i+"\" type=\"text\" style=\"width:100px\" /></td>");
            
            SbDetailHtml.Append("<td class=\"auto-style4\">联系电话</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\"><input id=\"txtDetailPhone"+i+"\" type=\"text\" style=\"width:100px\" /></td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\" colspan=\"6\">调查内容</td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\"  colspan=\"4\">候选人提供信息</td>");
            SbDetailHtml.Append("<td class=\"auto-style4\"  colspan=\"2\">核查结果</td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\">就职部门</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"3\"><input id=\"txtDetailDepartment1"+i+"\" type=\"text\" style=\"width:200px\" /></td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"2\">");
            SbDetailHtml.Append("<label><input id=\"rdbDepartment1" + i + "\" name=\"rdbDepartment" + i + "\" type=\"radio\" value=\"1\" />无差异 </label>");
            SbDetailHtml.Append("<label><input id=\"rdbDepartment2" + i + "\" name=\"rdbDepartment" + i + "\" type=\"radio\" value=\"2\" />有差异 </label>");
            SbDetailHtml.Append("<label style=\"display:none;\"><input id=\"rdbDepartment3" + i + "\" name=\"rdbDepartment" + i + "\" type=\"radio\" value=\"3\" />其它 </label>"); 
            SbDetailHtml.Append("<input id=\"txtDepartmentRemark"+i+"\" type=\"text\" style=\"width:130px\" />");
            SbDetailHtml.Append("</td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\">职位</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"3\"><input id=\"txtDetailPosition"+i+"\" type=\"text\" style=\"width:200px\" /></td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"2\">");
            SbDetailHtml.Append("<label><input id=\"rdbPosition1" + i + "\" name=\"rdbPosition" + i + "\" type=\"radio\" value=\"1\" />无差异 </label>");
            SbDetailHtml.Append("<label><input id=\"rdbPosition2" + i + "\" name=\"rdbPosition" + i + "\" type=\"radio\" value=\"2\" />有差异  </label>");
            SbDetailHtml.Append("<label style=\"display:none;\"><input id=\"rdbPosition3" + i + "\" name=\"rdbPosition" + i + "\" type=\"radio\" value=\"3\"  />其它 </label>"); 
            SbDetailHtml.Append("<input id=\"txtPositionRemark"+i+"\" type=\"text\" style=\"width:130px\" />");
            SbDetailHtml.Append("</td>");
            SbDetailHtml.Append("</tr>");       
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\">任职时间</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"3\"><input id=\"txtPositionDate1"+i+"\" type=\"text\" style=\"width:200px\" /></td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"2\">");
            SbDetailHtml.Append("<label><input id=\"rdbPositionDate1" + i + "\" name=\"rdbPositionDate" + i + "\" type=\"radio\" value=\"1\" />无差异 </label>");
            SbDetailHtml.Append("<label><input id=\"rdbPositionDate2" + i + "\" name=\"rdbPositionDate" + i + "\" type=\"radio\" value=\"2\" />有差异 </label>");
            SbDetailHtml.Append("<label style=\"display:none;\"><input id=\"rdbPositionDate3" + i + "\" name=\"rdbPositionDate" + i + "\" type=\"radio\" value=\"3\" style=\"display:none;\" />其它 </label>"); 
            SbDetailHtml.Append("<input id=\"txtPositionDateRemark"+i+"\" type=\"text\" style=\"width:130px\" />");
            SbDetailHtml.Append("</td>");
            SbDetailHtml.Append("</tr>");   
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\">离职原因</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"3\"><input id=\"txtLeaveReason1"+i+"\" type=\"text\" style=\"width:200px\" /></td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"2\">");
            SbDetailHtml.Append("<label><input id=\"rdbLeaveReason1" + i + "\" name=\"rdbLeaveReason" + i + "\" type=\"radio\" value=\"1\" />无差异 </label>");
            SbDetailHtml.Append("<label><input id=\"rdbLeaveReason2" + i + "\" name=\"rdbLeaveReason" + i + "\" type=\"radio\" value=\"2\" />有差异 </label>");
            SbDetailHtml.Append("<label style=\"display:none;\"><input id=\"rdbLeaveReason3" + i + "\" name=\"rdbLeaveReason" + i + "\" type=\"radio\" value=\"3\"  />其它 </label>"); 
            SbDetailHtml.Append("<input id=\"txtLeaveReasonRemark"+i+"\" type=\"text\" style=\"width:130px\" />");
            SbDetailHtml.Append("</td>");
            SbDetailHtml.Append("</tr>");

            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\" colspan=\"4\"><b>信息提供人对候选人评价</b></td>");
            SbDetailHtml.Append("<td class=\"auto-style4\" colspan=\"2\"><b>人力资源部补充意见</b></td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\">是否有违规行为</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"3\">");
            SbDetailHtml.Append("<label><input id=\"rdbMisdeeds1"+i+"\" name=\"rdbMisdeeds"+i+"\" type=\"radio\" value=\"1\" />是 </label>");
            SbDetailHtml.Append("<label><input id=\"rdbMisdeeds2"+i+"\" name=\"rdbMisdeeds"+i+"\" type=\"radio\" value=\"2\" />否 </label>");
            SbDetailHtml.Append("</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"2\"><input id=\"txtMisdeedsRemark" + i + "\" type=\"text\" style=\"width:260px\" /></td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\">业绩情况</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"3\">");
            SbDetailHtml.Append("<input id=\"txtPerformance" + i + "\" type=\"text\" style=\"width:260px\" />");
            SbDetailHtml.Append("</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"2\"><input id=\"txtPerformanceRemark" + i + "\" type=\"text\" style=\"width:260px\" /></td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\" style=\"width:100px;\">带团队规模及时间</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"3\">");
            SbDetailHtml.Append("<input id=\"txtTeamNumAndDate1"+i+"\" type=\"text\" style=\"width:260px\" />");
            SbDetailHtml.Append("</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"2\"><input id=\"txtTeamNumAndDateRemark" + i + "\" type=\"text\" style=\"width:260px\" /></td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("<tr>");
            SbDetailHtml.Append("<td class=\"auto-style4\">团队管理能力</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"3\">");
            SbDetailHtml.Append("<input id=\"txtAbility" + i + "\" type=\"text\" style=\"width:260px\" />");
            SbDetailHtml.Append("</td>");
            SbDetailHtml.Append("<td class=\"tl PL10\" colspan=\"2\"><input id=\"txtAbilityRemark" + i + "\" type=\"text\" style=\"width:260px\" /></td>");
            SbDetailHtml.Append("</tr>");
            SbDetailHtml.Append("</tbody>");
        }
    }
}