using DataAccess.Operate;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_FyqBackProject_Apply_FyqBackProject_Detail : BasePage
{

    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    // public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbJsonf = new StringBuilder();//789

    //加载js
    public StringBuilder Sbjstb = new StringBuilder();

    //保存资料类型
    Dictionary<int, string> dictype = new Dictionary<int, string>();

    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();
    public string flowsadd = "", flowsl = "0";

    //public string[] sHRTree = null;

    public string flowState = "";

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        Session["MainID"] = "";
        GetManagers();//789
        GetAllDepartment();
        string UrlMainID = GetQueryString("MainID");
        SerialNumber = "";
        MainID = UrlMainID;

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
                if (Session["FLG_ReWrite52"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite52"] = null;
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
        // this.txtFyqSale.Text = EmployeeName;
        //   txtApply.Text = EmployeeName;
        //lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        lbData.Text = DateTime.Now.ToString("yyyy-MM-dd");
        SbJs.Append("<script type=\"text/javascript\">");
        //DrawDetailTable(0);
        //SbJs.Append("$(\"#btnUpload\").show();");
        SbJs.Append("</script>");
        IsNewApply = true;
        this.chkProgress1.Checked = true;
        this.chkNoProjectType1.Checked = true;
        //  MainID = Guid.NewGuid().ToString();
    }


    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {

        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_FyqBackProject_Inherit da_OfficeAutomation_Document_FyqBackProject_Inherit = new DA_OfficeAutomation_Document_FyqBackProject_Inherit();


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

        SbJs.Append("$(\"#btnUpload\").show();");

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_FyqBackProject_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_FyqBackProject_ID"].ToString();
        string applicant = dr["OfficeAutomation_Main_Creater"].ToString();
        ApplyN = applicant;



        this.txtDepartment.Text = dr["OfficeAutomation_Document_FyqBackProject_Department"].ToString();
        this.txtApply.Text = dr["OfficeAutomation_Document_FyqBackProject_Apply"].ToString();
        this.txtPhone.Text = dr["OfficeAutomation_Document_FyqBackProject_ApplyPhone"].ToString();


        this.txtLocation.Text = dr["OfficeAutomation_Document_FyqBackProject_Location"].ToString();
        this.txtMaster.Text = dr["OfficeAutomation_Document_FyqBackProject_Master"].ToString();

        this.txtBuyers.Text = dr["OfficeAutomation_Document_FyqBackProject_Buyers"].ToString();


        this.txtOldLoanBank.Text = dr["OfficeAutomation_Document_FyqBackProject_OldLoanBank"].ToString();

        this.txtLoandMoney.Text = dr["OfficeAutomation_Document_FyqBackProject_LoandMoney"].ToString();
        ddlFollwDept.SelectedValue = dr["OfficeAutomation_Document_FyqBackProject_FollwDept"].ToString();
        txtFollwStaff.Text = dr["OfficeAutomation_Document_FyqBackProject_FollwStaff"].ToString();
         HiFollwStaff.Value = dr["OfficeAutomation_Document_FyqBackProject_FollwStaff"].ToString();
        hiFollwStaffCode.Value = dr["OfficeAutomation_Document_FyqBackProject_FollwStaffCode"].ToString();
        switch (dr["OfficeAutomation_Document_FyqBackProject_Progress"].ToString()) 
        {
            case "1": this.chkProgress1.Checked = true; break;
            case "2": this.chkProgress2.Checked = true; break;
            case "3": this.chkProgress3.Checked = true; break;
            case "4": this.chkProgress4.Checked = true; break;
            default: this.chkProgress5.Checked = true; break;
        }
        switch (dr["OfficeAutomation_Document_FyqBackProject_NoProjectType"].ToString())
        {
            case "1": this.chkNoProjectType1.Checked = true; this.ddlNoProjectCause1.SelectedValue = dr["OfficeAutomation_Document_FyqBackProject_NoProjectCause"].ToString(); break;
            case "2": this.chkNoProjectType2.Checked = true; this.ddlNoProjectCause2.SelectedValue = dr["OfficeAutomation_Document_FyqBackProject_NoProjectCause"].ToString(); break;
            case "3": this.chkNoProjectType3.Checked = true; this.ddlNoProjectCause3.SelectedValue = dr["OfficeAutomation_Document_FyqBackProject_NoProjectCause"].ToString(); break;
            default: this.chkNoProjectType4.Checked = true;  break;
        }
        this.txtOthers.Text = dr["OfficeAutomation_Document_FyqBackProject_OthersTypeMemo"].ToString();
        this.chkBackData1.Checked = dr["OfficeAutomation_Document_FyqBackProject_BackData1"].ToString().ToLower() == "true" ? true : false;
        this.chkBackData2.Checked = dr["OfficeAutomation_Document_FyqBackProject_BackData2"].ToString().ToLower() == "true" ? true : false;
        this.chkBackData3.Checked = dr["OfficeAutomation_Document_FyqBackProject_BackData3"].ToString().ToLower() == "true" ? true : false;
        this.chkBackData4.Checked = dr["OfficeAutomation_Document_FyqBackProject_BackData4"].ToString().ToLower() == "true" ? true : false;
        this.txtOtherData.Text = dr["OfficeAutomation_Document_FyqBackProject_OtherData"].ToString();
        this.lbProjectNo.Text = dr["OfficeAutomation_Document_FyqBackProject_ProjectNo"].ToString();


        this.lblApply.Text = applicant;
        this.lbData.Text = DateTime.Parse(dr["OfficeAutomation_Document_FyqBackProject_ApplyDate"].ToString()).ToString("yyyy-MM-dd");

        this.txtProjectNo.Text = dr["OfficeAutomation_Document_FyqBackProject_ProjectNo"].ToString();


        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        BuySumM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuySumM"].ToString();
        SellSumM.Text = dr["OfficeAutomation_Document_FyqBackProject_SellSumM"].ToString();
        BuyPropertyM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuyPropertyM"].ToString();
        BuyFamilyProofM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuyFamilyProofM"].ToString();
        BuyAssessmentM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuyAssessmentM"].ToString();
        BuyMortgageAgentM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuyMortgageAgentM"].ToString();
        BuySecurityFeeM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuySecurityFeeM"].ToString();
        BuyTaxM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuyTaxM"].ToString();
        BuyUpSumM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuyUpSumM"].ToString();
        BuyRetreatM.Text = dr["OfficeAutomation_Document_FyqBackProject_BuyRetreatM"].ToString();
        SellSecurityFeeM.Text = dr["OfficeAutomation_Document_FyqBackProject_SellSecurityFeeM"].ToString();
        SellTaxM.Text = dr["OfficeAutomation_Document_FyqBackProject_SellTaxM"].ToString();
        SellUpSumM.Text = dr["OfficeAutomation_Document_FyqBackProject_SellUpSumM"].ToString();
        SellRetreatM.Text = dr["OfficeAutomation_Document_FyqBackProject_SellRetreatM"].ToString();
        SellDate.Text = dr["OfficeAutomation_Document_FyqBackProject_SellDate"].ToString();
        //SellMonth.Text = dr["OfficeAutomation_Document_FyqBackProject_SellMonth"].ToString();
        //Sellday.Text = dr["OfficeAutomation_Document_FyqBackProject_Sellday"].ToString(); 
      
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;
        if (isApplicant)
        {

            if (flowState == "1")
            {
                GetAllDepartment();
                btnSave.Visible = true;

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
            // btnSignSave.Visible = true;

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
                    lblApply.Text = EmployeeName;
                    //   txtApply.Text = EmployeeName;
                    //lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    lbData.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                // if (isApplicant)
                //btnReWrite.Visible = true;
            }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion



        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        T_OfficeAutomation_Flow flows, flows3, flows4;
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
        if (flows != null)
        {
            SbJs.Append("$('#trManager1').show();");
        }
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2);
        if (flows != null)
        {
            SbJs.Append("$('#trManager2').show();");
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
        {
            flowsl += "5";
            SbJs.Append("$('#trM5').show();");
        }
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 6);
        if (flows != null)
            SbJs.Append("$('#trM6').show();");
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 7);
        //if (flows != null)
        //    SbJs.Append("$('#trM7').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
        if (flows != null)
            SbJs.Append("$('#trM8').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 9);
        if (flows != null)
            SbJs.Append("$('#trM9').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 10);
        if (flows != null)
            SbJs.Append("$('#trM10').show();");





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
                    //switch (curidx)
                    //{
                    //    case "6":
                    //        ckbAddIDx6.Visible = true;
                    //        break;
                    //    default:
                    //        break;
                    //}
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
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:0px; \">"
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
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:20px; \">"
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




        //22308 陈健仪  录入案号
        if (EmployeeID == "22308")
        {
            this.txtProjectNo.Visible = true;
            this.btnEditProjectNo.Visible = true;
            this.btnFYQSave1.Visible = true;
        }


        LoadAttach();
    }






    /// <summary>
    /// 保存按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region 创建对象
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_FyqBackProject t_OfficeAutomation_Document_FyqBackProject = new T_OfficeAutomation_Document_FyqBackProject();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_FyqBackProject_Inherit da_OfficeAutomation_Document_FyqBackProject_Inherit = new DA_OfficeAutomation_Document_FyqBackProject_Inherit();
        DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        #endregion

        string salename = "";
        string saleId = "";
        string salename1 = "";
        string saleId1 = "";

        DataSet dsem = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(this.txtApply.Text);
        if (dsem.Tables[0].Rows.Count < 1)
        {

            Alert("申请人不存在！");
            return;
        }
        salename = dsem.Tables[0].Rows[0]["EmployeeName"].ToString();
        saleId = dsem.Tables[0].Rows[0]["Code"].ToString();

        DataSet dsem1 = da_Employee_Inherit.GetEmployeeInfoByEmployeeID(hiFollwStaffCode.Value);
        if (dsem1.Tables[0].Rows.Count < 1)
        {

            Alert("跟进人不存在！");
            return;
        }
        salename1 = dsem1.Tables[0].Rows[0]["EmployeeName"].ToString();
        saleId1 = dsem1.Tables[0].Rows[0]["Code"].ToString();


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

               string dispatchDepartmentID = this.hdDepartmentID.Value;
                if (dispatchDepartmentID == "")
                {
                    Alert("请填写关键字后点选申请部门！");
                    return;
                }
               

           
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "FYQBP" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 91;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;


                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_MainId = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyPhone = this.txtPhone.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Location = this.txtLocation.Text;
                

                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Master = this.txtMaster.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Buyers = this.txtBuyers.Text;

                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OldLoanBank = this.txtOldLoanBank.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_LoandMoney = this.txtLoandMoney.Text;

                if (this.chkNoProjectType1.Checked == true) {
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 1;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse( this.ddlNoProjectCause1.SelectedValue);
                }
                else if (this.chkNoProjectType2.Checked == true) 
                {
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 2;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse(this.ddlNoProjectCause2.SelectedValue);
                }
                else if (this.chkNoProjectType3.Checked == true)
                {
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 3;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse(this.ddlNoProjectCause3.SelectedValue);
                }
                else {
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 4;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = 0;
        
                
                }
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OthersTypeMemo = this.txtOthers.Text ;


                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Progress = this.chkProgress1.Checked == true ? 1 : this.chkProgress2.Checked == true ? 2 : this.chkProgress3.Checked == true ? 3 :this.chkProgress4.Checked==true? 4:5;
               
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData1=this.chkBackData1.Checked==true?true:false;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData2 = this.chkBackData2.Checked == true ? true : false;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData3 = this.chkBackData3.Checked == true ? true : false;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData4 = this.chkBackData4.Checked == true ? true : false;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OtherData = this.txtOtherData.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ProjectNo = "";


                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Apply = this.txtApply.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyDate = DateTime.Now;
              //房友圈 陈健仪上申请SYSREQ201804191820357708118 
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_FollwDept = ddlFollwDept.SelectedValue;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_FollwStaff = HiFollwStaff.Value;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_FollwStaffCode = hiFollwStaffCode.Value;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = this.lblApply.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = "";
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyDate;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);//插入公文主表
                da_OfficeAutomation_Document_FyqBackProject_Inherit.Add(t_OfficeAutomation_Document_FyqBackProject);

                #region 保存默认流程

                addflow(saleId1, salename1, t_OfficeAutomation_Main.OfficeAutomation_SerialNumber, this.txtDepartment.Text);
                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 91, new Guid(MainID), 1);//日志，

                RunJS("alert('保存成功！');window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_FyqBackProject_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + flowsadd + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_FyqBackProject_Inherit.SelectByMainID(MainID);

                    ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_FyqBackProject_ID"].ToString();


                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ID = new Guid(ID);
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_MainId = new Guid(MainID);
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Department = this.txtDepartment.Text;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyPhone = this.txtPhone.Text;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Location = this.txtLocation.Text;


                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Master = this.txtMaster.Text;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Buyers = this.txtBuyers.Text;

                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OldLoanBank = this.txtOldLoanBank.Text;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_LoandMoney = this.txtLoandMoney.Text;

                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_FollwDept = ddlFollwDept.SelectedValue;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_FollwStaff = HiFollwStaff.Value;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_FollwStaffCode = hiFollwStaffCode.Value;
                    if (this.chkNoProjectType1.Checked == true)
                    {
                        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 1;
                        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse(this.ddlNoProjectCause1.SelectedValue);
                    }
                    else if (this.chkNoProjectType2.Checked == true)
                    {
                        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 2;
                        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse(this.ddlNoProjectCause2.SelectedValue);
                    }
                    else if (this.chkNoProjectType3.Checked == true)
                    {
                        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 3;
                        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse(this.ddlNoProjectCause3.SelectedValue);
                    }
                    else
                    {
                        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 4;
                        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = 0;


                    }
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OthersTypeMemo = this.txtOthers.Text;


                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Progress = this.chkProgress1.Checked == true ? 1 : this.chkProgress2.Checked == true ? 2 : this.chkProgress3.Checked == true ? 3 : this.chkProgress4.Checked == true ? 4 : 5;

                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData1 = this.chkBackData1.Checked == true ? true : false;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData2 = this.chkBackData2.Checked == true ? true : false;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData3 = this.chkBackData3.Checked == true ? true : false;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData4 = this.chkBackData4.Checked == true ? true : false;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OtherData = this.txtOtherData.Text;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ProjectNo = this.lbProjectNo.Text;


                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Apply = this.txtApply.Text;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyDate = DateTime.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_Document_FyqBackProject_ApplyDate"].ToString());




                    string apply = this.lblApply.Text;
                    string depname = this.txtDepartment.Text;
                    string summary = "";
                    string applydate = t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyDate.ToString();
                    string mainid = MainID;

                    da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
                    da_OfficeAutomation_Document_FyqBackProject_Inherit.Edit(t_OfficeAutomation_Document_FyqBackProject);//修改软件系统开发需求申请表

                    Common.AddLog(EmployeeID, EmployeeName, 91, new Guid(MainID), 2);//日志，修改软件系统开发需求申请表
                    RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
                }
                else
                    Alert("未开通编辑修改权限。");
                #endregion
            }
        }
        catch (Exception ex)
        {
            RunJS("alert('保存失败！' "+ ex.Message);
        //    Alert("保存失败！" + ex.Message);
        }
    }

    protected void btnSave1_Click(object sender, EventArgs e)
    { 
        //保存致财务
        try
        {
            DA_OfficeAutomation_Document_FyqBackProject_Inherit da_OfficeAutomation_Document_FyqBackProject_Inherit = new DA_OfficeAutomation_Document_FyqBackProject_Inherit();
            T_OfficeAutomation_Document_FyqBackProject tclass = da_OfficeAutomation_Document_FyqBackProject_Inherit.GetModel(MainID);
            tclass.OfficeAutomation_Document_FyqBackProject_BuySumM = BuySumM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_SellSumM = SellSumM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_BuyPropertyM = BuyPropertyM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_BuyFamilyProofM = BuyFamilyProofM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_BuyAssessmentM = BuyAssessmentM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_BuyMortgageAgentM = BuyMortgageAgentM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_BuySecurityFeeM = BuySecurityFeeM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_BuyTaxM = BuyTaxM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_BuyUpSumM = BuyUpSumM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_BuyRetreatM = BuyRetreatM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_SellSecurityFeeM =SellSecurityFeeM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_SellTaxM = SellTaxM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_SellUpSumM = SellUpSumM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_SellRetreatM = SellRetreatM.Text.Trim();
            tclass.OfficeAutomation_Document_FyqBackProject_SellDate = SellDate.Text;
            da_OfficeAutomation_Document_FyqBackProject_Inherit.Edit(tclass);
            RunJS("alert('保存成功！');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception)
        {

            RunJS("alert('保存失败！');window.location='" + Page.Request.Url + "'");
        }
      
    }
    public void addflow(string saleId, string saleName, string serialNumber, string dept)
    {



        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.ToLowerInvariant().IndexOf("/apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl + "?MainID=" + MainID;

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = saleId;
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = saleName;
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;
        //da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);


        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "22308";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈健仪";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = saleId;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = saleName;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);



        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "57718";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "冯燕芬";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        //string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        //string msnBody = "您好，" + saleName + "：您有" + dept
        //                          + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        //Common.SendMessageEX(true, documentName, saleName, "请审理", msnBody, msnBody, MainID);


    }

    /// <summary>
    /// 加载附件列表
    /// </summary>
    private void LoadAttach()
    {
        //获取该单附件列表
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DataSet dsAttach = new DataSet();
        dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

        gvAttach.DataSource = dsAttach;
        gvAttach.DataBind();

        //如果该单有附件，则下载按钮显示
        this.btnDownload.Visible = (dsAttach != null && dsAttach.Tables[0] != null && dsAttach.Tables[0].Rows.Count > 0);
    }


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
            if (chk.Checked)
            {
                HiddenField hf = item.FindControl("hfPath") as HiddenField;
                files.Add(hf.Value);
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("网签变更、特殊申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }

    #region 返回按钮点击事件
    protected void btnBack_Click(object sender, EventArgs e)
    {

        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString.ToString();
        Response.Redirect(sUrl);
    }
    #endregion
    #region GridView事件

    /// <summary>
    /// gvAttachment的行命令操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        string commType = e.CommandName.ToString();
        switch (commType)
        {
            case "Del":
                Alert("删除附件" + (da_OfficeAutomation_Attach_Inherit.Delete(e.CommandArgument.ToString()) ? "成功!" : "失败!"));
                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(MainID), 3);
                break;
            default:
                break;
        }

        LoadPage();
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
        DA_OfficeAutomation_Document_FyqBackProject_Inherit da_OfficeAutomation_Document_FyqBackProject_Inherit = new DA_OfficeAutomation_Document_FyqBackProject_Inherit();

        DataSet ds = da_OfficeAutomation_Document_FyqBackProject_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_FyqBackProject_ID"].ToString();

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

                //如果为第8步流程则为其一审核即可通过，其他为同时审核。
                //bool isSignSuccess = flowIDx == "8" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                //string[] flowN;
                //flowN = ViewState["FSIN"].ToString().Split(',');//789
                //|| ((IList)flowN).Contains(flowIDx)) 
                bool isSignSuccess = flowIDx == "8" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody = "";

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_FyqBackProject_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_FyqBackProject_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.ToLowerInvariant().IndexOf("/apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl + "?MainID=" + MainID;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_FyqBackProject_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_FyqBackProject_Department"]);
                    sbMailBody.Append("<br/>发文日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_FyqBackProject_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));

                    sbMailBody.Append("<br/>物业地址：" + drRow["OfficeAutomation_Document_FyqBackProject_Location"]);
                    sbMailBody.Append("<br/>业主：" + drRow["OfficeAutomation_Document_FyqBackProject_Master"]);
                    sbMailBody.Append("<br/>买家：" + drRow["OfficeAutomation_Document_FyqBackProject_Buyers"]);

                    sbMailBody.Append("<br/>房友圈退案申请表");


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
                            /*添加需求：通知非审批流出现人员——当选择【（8）客户要求自行网签】时，需要在申请走完整个流程后，以邮件方式通知法律部*/
                            //if (rdbSpecialApply8.Checked)
                            //{
                            //    employname = "李蓬桂,陈宇平,何恺鹏,苏秉星";
                            //    employnames = employname.Split(',');
                            //    for (int i = 0; i < employnames.Length; i++)
                            //    {
                            //        if (!employeeList.Contains(employnames[i]))
                            //        {
                            //            msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //            email = employnames[i];
                            //            if (hdIsAgree.Value == "2")
                            //                Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                            //            else
                            //                Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                            //            employeeList += employnames[i] + "||";
                            //        }
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
            DA_OfficeAutomation_Document_FyqBackProject_Inherit da_OfficeAutomation_Document_FyqBackProject_Inherit = new DA_OfficeAutomation_Document_FyqBackProject_Inherit();
            DataSet ds = da_OfficeAutomation_Document_FyqBackProject_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_FyqBackProject_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_FyqBackProject_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.ToLowerInvariant().IndexOf("/apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl + "?MainID=" + MainID;
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
            DA_OfficeAutomation_Document_FyqBackProject_Inherit da_OfficeAutomation_Document_FyqBackProject_Inherit = new DA_OfficeAutomation_Document_FyqBackProject_Inherit();
            DataSet ds = da_OfficeAutomation_Document_FyqBackProject_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_FyqBackProject_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_FyqBackProject_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.ToLowerInvariant().IndexOf("/apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl + "?MainID=" + MainID;
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
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10); //在不同的表中要修改，开发新表时要注意

            string fls = "";
            T_OfficeAutomation_Flow flows;
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
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 5);
            if (flows != null)
            {
                fls += "5";
            }
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_FyqBackProject_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + fls + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    #endregion

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
            DA_OfficeAutomation_Document_FyqBackProject_Inherit da_OfficeAutomation_Document_FyqBackProject_Inherit = new DA_OfficeAutomation_Document_FyqBackProject_Inherit();
            DataSet ds = da_OfficeAutomation_Document_FyqBackProject_Inherit.SelectByMainID(MainID); //在不同的表中要修改

            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_FyqBackProject_Apply"].ToString();
            string datetime = ds.Tables[0].Rows[0]["OfficeAutomation_Document_FyqBackProject_ApplyDate"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_FyqBackProject_Department"].ToString();
            ID = drRow["OfficeAutomation_Document_FyqBackProject_ID"].ToString();
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
            if (Purview.Contains("OA_ITPower_001"))
            {
                T_OfficeAutomation_Document_FyqBackProject t_OfficeAutomation_Document_FyqBackProject = new T_OfficeAutomation_Document_FyqBackProject();

                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ID = new Guid(ID);
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_MainId = new Guid(MainID);
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyPhone = this.txtPhone.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Location = this.txtLocation.Text;


                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Master = this.txtMaster.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Buyers = this.txtBuyers.Text;

                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OldLoanBank = this.txtOldLoanBank.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_LoandMoney = this.txtLoandMoney.Text;

                if (this.chkNoProjectType1.Checked == true)
                {
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 1;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse(this.ddlNoProjectCause1.SelectedValue);
                }
                else if (this.chkNoProjectType2.Checked == true)
                {
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 2;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse(this.ddlNoProjectCause2.SelectedValue);
                }
                else if (this.chkNoProjectType3.Checked == true)
                {
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 3;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = int.Parse(this.ddlNoProjectCause3.SelectedValue);
                }
                else
                {
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectType = 4;
                    t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_NoProjectCause = 0;


                }
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OthersTypeMemo = this.txtOthers.Text;


                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Progress = this.chkProgress1.Checked == true ? 1 : this.chkProgress2.Checked == true ? 2 : this.chkProgress3.Checked == true ? 3 : this.chkProgress4.Checked == true ? 4 : 5;

                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData1 = this.chkBackData1.Checked == true ? true : false;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData2 = this.chkBackData2.Checked == true ? true : false;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData3 = this.chkBackData3.Checked == true ? true : false;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_BackData4 = this.chkBackData4.Checked == true ? true : false;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_OtherData = this.txtOtherData.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ProjectNo = this.lbProjectNo.Text;


                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_Apply = this.txtApply.Text;
                t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyDate = DateTime.Parse(datetime);


                apply = this.lblApply.Text;
                string depname = this.txtDepartment.Text;
                string summary = "";
                string applydate = t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ApplyDate.ToString();
                string mainid = MainID;

                da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
                da_OfficeAutomation_Document_FyqBackProject_Inherit.Edit(t_OfficeAutomation_Document_FyqBackProject);//修改软件系统开发需求申请表
              


                da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                Common.AddLog(EmployeeID, EmployeeName, 1, new Guid(MainID), 2);
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

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        if (Cache["AllDepartmentNew"] == null)
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
            Cache["AllDepartmentNew"] = SbJson;
        }
        else
            SbJson = (StringBuilder)Cache["AllDepartmentNew"];
    }
    #endregion

    protected void btnEditProjectNo_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Document_FyqBackProject_Inherit da_OfficeAutomation_Document_FyqBackProject_Inherit = new DA_OfficeAutomation_Document_FyqBackProject_Inherit();
       
        T_OfficeAutomation_Document_FyqBackProject t_OfficeAutomation_Document_FyqBackProject = da_OfficeAutomation_Document_FyqBackProject_Inherit.GetModel(MainID);
        
        t_OfficeAutomation_Document_FyqBackProject.OfficeAutomation_Document_FyqBackProject_ProjectNo = this.txtProjectNo.Text;
        da_OfficeAutomation_Document_FyqBackProject_Inherit.Edit(t_OfficeAutomation_Document_FyqBackProject);
        Alert("修改成功。");
    
    }
}