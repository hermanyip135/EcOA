﻿using System;
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

public partial class Apply_ProjLinkRepoData_Apply_ProjLinkRepoData_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbOptions = new StringBuilder();

    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();

    public string sOfficeType = "";

    public string temMainID = "";//2016/8/23 52100
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
        //string UrlMainID = GetQueryString("MainID");
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
                if (Session["FLG_ReWrite17"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite17"] = null;
                }
            }
            catch
            {
            }
            if (MainID != "")
            {
               // MainID = UrlMainID;
                LoadPage();
            }
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
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">$(\"#rdbNewProj\").click();$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
        DrawDetailTable(1);
        SbJs.Append("</script>");

        //MainID = Guid.NewGuid().ToString();//2016/8/22  52100
 
        InitListControler("");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        bool IsTempSave = false;        //是否暂存

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();

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
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var obj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_ProjLinkRepoData_Detail>("ProjLinkRepoData", "", Mainobj.OfficeAutomation_SerialNumber);
            ds = Common.GetPageDetailDS<DataEntity.PageModel.T_OfficeAutomation_Document_ProjLinkRepoData_M>(obj.ProjLinkRepoData, Mainobj);

            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            ds = da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.SelectByMainID(MainID);

        }

        #region FormInit
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ProjLinkRepoData_ID"].ToString();

        string applicant = dr["OfficeAutomation_Document_ProjLinkRepoData_Apply"].ToString();
        ApplyN = applicant;
        lblApply.Text = applicant;
        txtDepartment.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_Department"].ToString();
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ProjLinkRepoData_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtReplyPhone.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone"].ToString();
        txtApplyID.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ApplyID"].ToString();
        txtProjName.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ProjName"].ToString();
        switch (dr["OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID"].ToString())
        {
            case "True":
                rdbHavePreSaleID.Checked = true;
                break;
            case "False":
                rdbNoPreSaleID.Checked = true;
                break;
            default:
                break;
        }
        txtPreSaleID.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PreSaleID"].ToString();
        txtProjAddress.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ProjAddress"].ToString();
        txtDeveloperName.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_DeveloperName"].ToString();
        txtGroupName.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_GroupName"].ToString();
        InitListControler(dr["OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs"].ToString());
        txtDealOfficeOther.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther"].ToString();
        txtAgentStartDate.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate"].ToString();
        txtAgentEndDate.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate"].ToString();
        txtPreComm.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PreComm"].ToString();
        txtGoodsQuantity.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity"].ToString();
        txtGoodsValue.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_GoodsValue"].ToString();
        txtCommPoint.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_CommPoint"].ToString();
        switch (dr["OfficeAutomation_Document_ProjLinkRepoData_AgentModel"].ToString())
        {
            case "1":
                rdbAgentModel1.Checked = true;
                break;
            case "2":
                rdbAgentModel2.Checked = true;
                break;
            default:
                break;
        }
        switch (dr["OfficeAutomation_Document_ProjLinkRepoData_ContractType"].ToString())
        {
            case "1":
                rdbContractType1.Checked = true;
                break;
            case "2":
                rdbContractType2.Checked = true;
                break;
            case "3":
                rdbContractType3.Checked = true;
                break;
            default:
                break;
        } 
        txtContractTypeOther.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther"].ToString();
        switch (dr["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost"].ToString())
        {
            case "True":
                rdbHaveCoopCost.Checked = true;
                break;
            case "False":
                rdbNoCoopCost.Checked = true;
                break;
            default:
                break;
        }
        switch (dr["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf"].ToString())
        {
            case "True":
                rdbHaveCoopConf.Checked = true;
                break;
            case "False":
                rdbNoCoopConf.Checked = true;
                break;
            default:
                break;
        }
        switch (dr["OfficeAutomation_Document_ProjLinkRepoData_IsSignBack"].ToString())
        {
            case "True":
                rdbIsSignBack.Checked = true;
                break;
            case "False":
                rdbIsNotSignBack.Checked = true;
                break;
            default:
                break;
        }
        txtContractPreSignBackDate.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate"].ToString();
        txtRemark.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_Remark"].ToString();
        txtLinkStartDate.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate"].ToString();
        txtLinkEndDate.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate"].ToString();
        txtCommCalcGet.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet"].ToString();
        txtProjDepCount.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount"].ToString();
        txtProjDepPrice.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice"].ToString();
        txtProjDepComm.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm"].ToString();
        txtPropDepCount.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PropDepCount"].ToString();
        txtPropDepPrice.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice"].ToString();
        txtPropDepComm.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PropDepComm"].ToString();
        switch (dr["OfficeAutomation_Document_ProjLinkRepoData_CalcGetType"].ToString())
        {
            case "1":
                rdbCalcGetType1.Checked = true;
                break;
            case "2":
                rdbCalcGetType2.Checked = true;
                break;
            case "3":
                rdbCalcGetType3.Checked = true;
                break;
            case "4":
                rdbCalcGetType4.Checked = true;
                break;
            case "5":
                rdbCalcGetType5.Checked = true;
                txtCalcGetTypeOther.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther"].ToString();
                break;
            default:
                break;
        } 
        
        switch (dr["OfficeAutomation_Document_ProjLinkRepoData_AssumeType"].ToString())
        {
            case "1":
                rdbAssumeType1.Checked = true;
                break;
            case "2":
                rdbAssumeType2.Checked = true;
                break;
            case "3":
                rdbAssumeType3.Checked = true;
                break;
            case "4":
                rdbAssumeType4.Checked = true;
                break;
            case "5":
                rdbAssumeType5.Checked = true;
                txtAssumeTypeOther.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther"].ToString();
                break;
            default:
                break;
        } 
        
        txtAddRemark.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AddRemark"].ToString();
        hdProjType.Value = dr["OfficeAutomation_Document_ProjLinkRepoData_ProjType"].ToString();
        if (hdProjType.Value == "1")
            SbJs.Append("$(\"#rdbNewProj\").click();");
        else
            SbJs.Append("$(\"#rdbOldProj\").click();");
        txtProjDepPreCount.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount"].ToString();
        txtProjDepPreComm.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm"].ToString();
        if (dr["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate"].ToString() != "")
            txtDealHistoryStartDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate"].ToString()).ToString("yyyy-MM-dd");
        if (dr["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate"].ToString() != "")
            txtDealHistoryEndDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate"].ToString()).ToString("yyyy-MM-dd");
        if (dr["OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate"].ToString() != "")
            txtTotalProfitStartDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate"].ToString()).ToString("yyyy-MM-dd");
        if (dr["OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate"].ToString() != "")
            txtTotalProfitEndDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate"].ToString()).ToString("yyyy-MM-dd");
        txtHisIndepCount.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount"].ToString();
        txtHisIndepPerformance.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance"].ToString();
        txtHisLinkCount.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount"].ToString();
        txtHisLinkPerformance.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance"].ToString();
        txtHisTotalProfit.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit"].ToString();

        //20141027+
        if (dr["OfficeAutomation_Document_ProjLinkRepoData_JOrT"].ToString() == "1")
        {
            rdbJOrT1.Checked = true;
            txtSamePlaceXX1.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1"].ToString();
            txtSamePlaceXX2.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2"].ToString();
            txtAgencyFee1.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1"].ToString();
            txtAgencyFee2.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2"].ToString();
            if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1"].ToString() == "True")
            {
                rdbIsCashPrize11.Checked = true;
                txtCashPrize1.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_CashPrize1"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1"].ToString() == "False")
                rdbIsCashPrize12.Checked = true;
            if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2"].ToString() == "True")
            {
                rdbIsCashPrize21.Checked = true;
                txtCashPrize2.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_CashPrize2"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2"].ToString() == "False")
                rdbIsCashPrize22.Checked = true;

            if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsPFear1"].ToString() == "True")
            {
                rdbIsPFear11.Checked = true;
                txtPFear1.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PFear1"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsPFear1"].ToString() == "False")
                rdbIsPFear12.Checked = true;
            if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsPFear2"].ToString() == "True")
            {
                rdbIsPFear21.Checked = true;
                txtPFear2.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PFear2"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsPFear2"].ToString() == "False")
                rdbIsPFear22.Checked = true;
        }
        else if (dr["OfficeAutomation_Document_ProjLinkRepoData_JOrT"].ToString() == "2")
        {
            rdbJOrT2.Checked = true;
            txtTurnsAgentXX1.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1"].ToString();
            txtTurnsAgentXX2.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2"].ToString();
            txtAgencyFee3.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3"].ToString();
            txtAgencyFee4.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4"].ToString();
            if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3"].ToString() == "True")
            {
                rdbIsCashPrize31.Checked = true;
                txtCashPrize3.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_CashPrize3"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3"].ToString() == "False")
                rdbIsCashPrize32.Checked = true;
            if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4"].ToString() == "True")
            {
                rdbIsCashPrize41.Checked = true;
                txtCashPrize4.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_CashPrize4"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4"].ToString() == "False")
                rdbIsCashPrize42.Checked = true;

            if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsPFear3"].ToString() == "True")
            {
                rdbIsPFear31.Checked = true;
                txtPFear3.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PFear3"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsPFear3"].ToString() == "False")
                rdbIsPFear32.Checked = true;
            if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsPFear4"].ToString() == "True")
            {
                rdbIsPFear41.Checked = true;
                txtPFear4.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_PFear4"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjLinkRepoData_IsPFear4"].ToString() == "False")
                rdbIsPFear42.Checked = true;
            txtAgencyBeginDate1.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1"].ToString();
            txtAgencyBeginDate2.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2"].ToString();
            txtAgencyEndDate1.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1"].ToString();
            txtAgencyEndDate2.Text = dr["OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2"].ToString();
        }
        else if (dr["OfficeAutomation_Document_ProjLinkRepoData_JOrT"].ToString() == "3")
            rdbJOrT3.Checked = true;
        //20141027+

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        string sPropDepPreInfo = dr["OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo"].ToString();
        hdDetail.Value = sPropDepPreInfo;

        if (!string.IsNullOrEmpty(sPropDepPreInfo))
        {
            string[] details = Regex.Split(sPropDepPreInfo, "\\|\\|");
            DrawDetailTable(details.Length);
              
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail.Length == 3)
                {
                    int n = i + 1;
                    SbJs.Append("$('#ddlDepartmentType" + n + "').val('" + detail[0] + "');");
                    SbJs.Append("$('#txtPropDepPreCount" + n + "').val('" + detail[1] + "');");
                    SbJs.Append("$('#txtPropDepPreComm" + n + "').val('" + detail[2] + "');");
                }
            }
        }
        else
            DrawDetailTable(1);
        #endregion
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        if (!IsTempSave)
        {
            //非暂存才显示上传附件按钮
            SbJs.Append("$(\"#btnUpload\").show();");
        }
        if (IsTempSave)
        {
            btnSPDF.Visible = false;
        }

        bool isApplicant = EmployeeName == applicant;
        if (isApplicant)
        {
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1" || flowState == "7")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
                SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
            }
        }

        try //M_AddAnother：20150716 黄生其它意见，增加审批人
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
            DataSet dsFlow = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
            DataRowCollection drcz = dsFlow.Tables[0].Rows;
            T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 2);
            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 200);
            flowst = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndEID(MainID, "0001");

            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF1\").show();");
            if (((drcz[0]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID)
                && drcz[0]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || (EmployeeName == applicant && flowst.OfficeAutomation_Flow_IsAgree == 2) || (fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowst.OfficeAutomation_Flow_IsAgree == 2) 
                )
            {
                SbJs.Append("$(\"#trAddAnoF1\").show();");
                btnsSignIDx200.Visible = true;
                if ((!fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName)) && flowsa != null)
                    btnsSignIDx200.Visible = false; //M_AlAno：20160217 ++
            }

            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 220);
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF3\").show();");
            if (flowst.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)
                && flowst.OfficeAutomation_Flow_Auditor.Contains(EmployeeName)
                && flowst.OfficeAutomation_Flow_IsAgree == 2
                && flowsa != null
                )
                btnsSignIDx220.Visible = true;
        }
        catch
        {
        }

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
                SbJs.Append("</script>");

                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                flowState = "1";
                //InitListControler("");
                btnSAlterC.Visible = false;
                return;
            }
        }
        catch
        {
            if (isApplicant && !IsTempSave)
                btnReWrite.Visible = true; //*-+
        }

        //#region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
        //    btnSignSave.Visible = true;
         
        //#endregion

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        bool flag3 = false;//是否有区域负责人环节

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
        bool showf = true; //M_HideFlows：20150330
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();
            string curemp2 = drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString();
            if ((curidx == "1" || curidx == "2" || EmployeeName == "黄轩明") && curemp2.Contains(EmployeeID) && showf) //M_HideFlows：20150330
            {
                showf = false;
                //SbJs.Append("$(\"#trShowFlow3\").hide();$(\"#trShowFlow4\").prepend('<td>二级市场<br />负责人</td>');");
                SbJs.Append("$(\"#trShowFlow6\").hide();$(\"#trShowFlow7\").prepend('<td>法律部意见</td>');");
                SbJs.Append("$(\"#trShowFlow8\").hide();$(\"#trShowFlow9\").hide();$(\"#trShowFlow10\").prepend('<td>财务部意见</td>');");
                SbJs.Append("$(\"#trShowFlow11\").hide();$(\"#trLogistics2\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
                SbJs.Append("$(\"#tlsc1\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            }

            if (curidx == "5")
                flag3 = true;

            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                SbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                if (curemp.Contains(EmployeeName)) //M_Add：黄志超 20150202
                {
                    switch (curidx)
                    {
                        case "8":
                            ckbAddIDx.Visible = true;
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

            if (i >= 12 && drc[i]["OfficeAutomation_Flow_Auditor"].ToString() != "") //M_AddAnother：20150716 黄生其它意见，增加审批人
            {
                SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                if (drc[i]["OfficeAutomation_Flow_AuditDate"].ToString() != "" && drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString().Contains(EmployeeID) && drc[i]["OfficeAutomation_Flow_Employee"].ToString().Contains(EmployeeName))
                { //M_RA：20151120
                    SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 98%; \">"
                               + "<br/>上一次复审意见：<br/><br/>" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "").Replace("\n", "<br/>") + "<br/><br/></div>').val('');");
                }

                if (auditorIDs.Length > 0 && auditorIDs[0] != "")
                {
                    SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').after('<div style=\"width: 200px; line-height: 55px; height: 2px; margin-left:20px; float:left;\">"
                                       + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" />");
                    }
                    SbJs.Append("');");

                    if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "1") //M_AlterM：20150820
                        SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a1').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                        SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a2').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                        SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a3').attr('checked','checked');");
                }
            }

            #endregion
        }

        //如果有区域负责人流程，则显示区域负责人内容
        if (flag3)
            SbJs.Append("$('#trAreaManager').show();");

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

        //20170206修改  注释Emma的审批
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

    private void InitListControler(string selectedValue)
    {
        DA_Dic_OfficeAutomation_DealOfficeType_Operate da_Dic_OfficeAutomation_DealOfficeType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DealOfficeType_Operate();
        DataSet ds = da_Dic_OfficeAutomation_DealOfficeType_Operate.SelectByDocumentID(14);
        CheckBoxListBind(cblDealOfficeType, ds.Tables[0], "OfficeAutomation_DealOfficeType_ID", "OfficeAutomation_DealOfficeType_Name", selectedValue);
        for (int i = 0; i < cblDealOfficeType.Items.Count; i++)
        {
            cblDealOfficeType.Items[i].Attributes["tag"] = cblDealOfficeType.Items[i].Value;
        }
    }

    public void DrawDetailTable(int n)
    {
        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        DataSet ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(25);
        SbOptions.Append("<option value=\"\">--物业部--</option>");
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            SbOptions.Append("<option value=\"" + dr["OfficeAutomation_DepartmentType_ID"] + "\">" + dr["OfficeAutomation_DepartmentType_Name"] + "</option>");
        }

        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id='trDetail" + i + "'>");
            SbHtml.Append("     <td style=\"width:24%\"><select id=\"ddlDepartmentType" + i + "\">" + SbOptions.ToString() + "</select></td>");
            SbHtml.Append("     <td style=\"width:38%\"><input type=\"text\" id=\"txtPropDepPreCount" + i + "\"/></td>");
            SbHtml.Append("     <td style=\"width:38%\"><input type=\"text\" id=\"txtPropDepPreComm" + i + "\"/></td>");
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
        T_OfficeAutomation_Document_ProjLinkRepoData t_OfficeAutomation_Document_ProjLinkRepoData = new T_OfficeAutomation_Document_ProjLinkRepoData();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
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
            for (int i = 0; i <= this.cblDealOfficeType.Items.Count - 1; i++)
            {
                if (this.cblDealOfficeType.Items[i].Selected == true)
                { sOfficeType = sOfficeType + this.cblDealOfficeType.Items[i].Value + "|"; }
            }
            sOfficeType = sOfficeType.Substring(0, sOfficeType.Length - 1);

            if (MainID == "")
            {
                #region 新建

                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ProjLinkRepoData" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 25;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_ProjLinkRepoData = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtProjName.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.Add(t_OfficeAutomation_Document_ProjLinkRepoData);//插入申请表

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

                #region 添加区域负责人

                DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();

                string sPropDepPreInfo = hdDetail.Value;
                string sMajordomoCodes = "";
                string sMajordomoNames = "";

                if (!string.IsNullOrEmpty(sPropDepPreInfo))
                {
                    string[] details = Regex.Split(sPropDepPreInfo, "\\|\\|");

                    for (int i = 0; i < details.Length; i++)
                    {
                        string[] detail = Regex.Split(details[i], "\\&\\&");
                        if (detail.Length == 3)
                        {
                            ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectMajordomoByID(detail[0]);
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                sMajordomoCodes += (ds.Tables[0].Rows[0][0]).ToString().Trim() + ",";
                                sMajordomoNames += ds.Tables[0].Rows[0][1] + ",";
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(sMajordomoCodes) && !string.IsNullOrEmpty(sMajordomoNames))
                    {
                        sMajordomoCodes = sMajordomoCodes.Substring(0, sMajordomoCodes.Length - 1);
                        sMajordomoNames = sMajordomoNames.Substring(0, sMajordomoNames.Length - 1);

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sMajordomoCodes;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sMajordomoNames;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }

                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 29, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ProjLinkRepoData_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID + "'");
                    //是否暂存
                    bool tempsave = MainObj.OfficeAutomation_Main_FlowStateID == 7;
                    if (tempsave)
                    {
                        //是,更新主表状态
                        MainObj.OfficeAutomation_Main_FlowStateID = 2;
                        da_OfficeAutomation_Main_Inherit.Edit(MainObj);
                    }

                    Update();
                    //暂存第一次提交需要上传附件+编辑流程
                    if (tempsave)
                    {
                        #region 保存默认流程
                        DataSet ds = new DataSet();
                        DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                        #region 根据默认流程表中的固定环节添加流程

                        ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(MainID);
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

                        #region 添加区域负责人

                        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();

                        string sPropDepPreInfo = hdDetail.Value;
                        string sMajordomoCodes = "";
                        string sMajordomoNames = "";

                        if (!string.IsNullOrEmpty(sPropDepPreInfo))
                        {
                            string[] details = Regex.Split(sPropDepPreInfo, "\\|\\|");

                            for (int i = 0; i < details.Length; i++)
                            {
                                string[] detail = Regex.Split(details[i], "\\&\\&");
                                if (detail.Length == 3)
                                {
                                    ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectMajordomoByID(detail[0]);
                                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                                    {
                                        sMajordomoCodes += (ds.Tables[0].Rows[0][0]).ToString().Trim() + ",";
                                        sMajordomoNames += ds.Tables[0].Rows[0][1] + ",";
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(sMajordomoCodes) && !string.IsNullOrEmpty(sMajordomoNames))
                            {
                                sMajordomoCodes = sMajordomoCodes.Substring(0, sMajordomoCodes.Length - 1);
                                sMajordomoNames = sMajordomoNames.Substring(0, sMajordomoNames.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sMajordomoCodes;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sMajordomoNames;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;

                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                            }
                        }

                        #endregion

                        #endregion
                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ProjLinkRepoData_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                    }
                    else
                    {
                        RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
                    }
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

    protected void btnTempSave_Click(object sender, EventArgs e)
    {
        var SerialNumber = "ProjLink" + DateTime.Now.ToString("yyyyMMddHHmmssfffff");
        var DocumentID = 25;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
       //temMainID = Guid.NewGuid().ToString();
        if (MainID=="")
        {
            MainID = Guid.NewGuid().ToString();
        }

        for (int i = 0; i <= this.cblDealOfficeType.Items.Count - 1; i++)
        {
            if (this.cblDealOfficeType.Items[i].Selected == true)
            { sOfficeType = sOfficeType + this.cblDealOfficeType.Items[i].Value + "|"; }
        }
        if (sOfficeType!="") 
        {
            sOfficeType = sOfficeType.Substring(0, sOfficeType.Length - 1);
        }
        
        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName,txtDepartment.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }
        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        var ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
        var ProjLinkRepoData = new DataEntity.PageModel.T_OfficeAutomation_Document_ProjLinkRepoData_M();
        ds = ProjLinkRepoData_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ProjLinkRepoData = GetModelMFromPage(Guid.NewGuid());
        }
        else
        {
            var ProjLinkRepoData_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_ID"].ToString();
            ProjLinkRepoData = GetModelMFromPage(new Guid(ProjLinkRepoData_ID));
        }
        var obj = new DataEntity.PageModel.Apply_ProjLinkRepoData_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;

        //var ProjLinkRepoData = GetModelMFromPage(Guid.NewGuid());

        ProjLinkRepoData_Inherit.HandleBase(ProjLinkRepoData);                      //只插入关键必填字段；

        obj.ProjLinkRepoData = ProjLinkRepoData;
        var result = new Common().SaveTempSaveFile<DataEntity.PageModel.Apply_ProjLinkRepoData_Detail>(obj, "ProjLinkRepoData", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
        if (result)
        {
            RunJS("alert('保存成功！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
        else
        {
            RunJS("alert('保存失败！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
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
        DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();

        DataSet ds = da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ProjLinkRepoData_ID"].ToString();
        
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

                if (flowIDx == "8") //M_Add：黄志超 20150202
                {
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                    if (ckbAddIDx.Checked)//增加审批环节是否勾选，如果是则添加黄志超审批
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                //bool isSignSuccess = flowIDx == "6" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value)
                //    : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "6" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ProjLinkRepoData_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请部门：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ProjLinkRepoData_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>跟进人：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_Apply"]);
                    sbMailBody.Append("<br/>回复电话：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone"]);
                    sbMailBody.Append("<br/>发文编号：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_ApplyID"]);
                    sbMailBody.Append("<br/>项目名称：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_ProjName"]);
                    sbMailBody.Append("<br/>是否有预售证：" + (drRow["OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID"].ToString() == "True" ? "是" : "否"));
                    sbMailBody.Append("<br/>预售证号：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_PreSaleID"]);
                    sbMailBody.Append("<br/>项目地址：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_ProjAddress"]);
                    sbMailBody.Append("<br/>开发商名称：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_DeveloperName"]);
                    sbMailBody.Append("<br/>所属集体名称：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_GroupName"]);
                    sbMailBody.Append("<br/>项目代理起始日期：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate"]);
                    sbMailBody.Append("<br/>项目代理结束日期：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate"]);
                    sbMailBody.Append("<br/>预计创佣：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_PreComm"]);
                    sbMailBody.Append("<br/>代理期内可售货量：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity"]);
                    sbMailBody.Append("<br/>代理期内可售货值：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_GoodsValue"]);
                    sbMailBody.Append("<br/>申请报数点数：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_CommPoint"]);
                    sbMailBody.Append("<br/>是否有合作费：" + (drRow["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost"].ToString() == "True" ? "是" : "否"));
                    sbMailBody.Append("<br/>是否有合作确认函：" + (drRow["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf"].ToString() == "True" ? "是" : "否"));
                    sbMailBody.Append("<br/>合同是否签回：" + (drRow["OfficeAutomation_Document_ProjLinkRepoData_IsSignBack"].ToString() == "True" ? "是" : "否"));
                    if (drRow["OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate"].ToString() != "")
                        sbMailBody.Append("<br/>预计签回日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>备注：" + drRow["OfficeAutomation_Document_ProjLinkRepoData_Remark"]);
                    sbMailBody.Append("<br/><br/>其他情况请详见申请表。");


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

                            //抄送给总办，及项目部
                            employname = CommonConst.EMP_GMO_NAME + "," + CommonConst.EMP_PROJECT_COPYTO_NAME + ",叶凯蔓,官东升,杨小茵";
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
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
                                    msnBody = "您好，" + employnames[i] + "：您有" + department + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody, MainID);
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
                                    Common.SendMessageEX(false, email, "请注意总经理有" + documentName + "需要审理", msnBody + mailBody, msnBody);
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
        //    DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_ProjLinkRepoData t_OfficeAutomation_Document_ProjLinkRepoData = new T_OfficeAutomation_Document_ProjLinkRepoData();
        DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_ID"].ToString();

        t_OfficeAutomation_Document_ProjLinkRepoData=GetModelFromPage(new Guid(ID));

        string apply = "";
        string depname = this.txtDepartment.Text;
        string summary = this.txtProjName.Text;
        string applydate = "";
        string mainid = MainID;

        new DA_OfficeAutomation_Main_Inherit().UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.Update(t_OfficeAutomation_Document_ProjLinkRepoData);//修改申请表

        #region 添加区域负责人

        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 5);

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        string sPropDepPreInfo = hdDetail.Value;
        string sMajordomoCodes = "";
        string sMajordomoNames = "";

        if (!string.IsNullOrEmpty(sPropDepPreInfo))
        {
            string[] details = Regex.Split(sPropDepPreInfo, "\\|\\|");

            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail.Length == 3)
                {
                    ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectMajordomoByID(detail[0]);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        sMajordomoCodes += (ds.Tables[0].Rows[0][0]).ToString().Trim() + ",";
                        sMajordomoNames += ds.Tables[0].Rows[0][1] + ",";
                    }
                }
            }

            if (!string.IsNullOrEmpty(sMajordomoCodes) && !string.IsNullOrEmpty(sMajordomoNames))
            {
                sMajordomoCodes = sMajordomoCodes.Substring(0, sMajordomoCodes.Length - 1);
                sMajordomoNames = sMajordomoNames.Substring(0, sMajordomoNames.Length - 1);

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sMajordomoCodes;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sMajordomoNames;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
        }

        #endregion

        Common.AddLog(EmployeeID, EmployeeName, 29, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 从页面中获得model

    private T_OfficeAutomation_Document_ProjLinkRepoData GetModelFromPage(Guid ProjLinkRepoDataID)
    {
        DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData model = new DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData();

        model.OfficeAutomation_Document_ProjLinkRepoData_ID = ProjLinkRepoDataID;
        model.OfficeAutomation_Document_ProjLinkRepoData_MainID = new Guid(MainID);
        model.OfficeAutomation_Document_ProjLinkRepoData_Department = txtDepartment.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ApplyDate = DateTime.Now;
        model.OfficeAutomation_Document_ProjLinkRepoData_Apply = EmployeeName;
        model.OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone = txtReplyPhone.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ApplyID = txtApplyID.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjName = txtProjName.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID = rdbHavePreSaleID.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_PreSaleID = txtPreSaleID.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjAddress = txtProjAddress.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_DeveloperName = txtDeveloperName.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_GroupName = txtGroupName.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs = sOfficeType; // hdDealOfficeType.Value;
        model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther = txtDealOfficeOther.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate = txtAgentStartDate.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate = txtAgentEndDate.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PreComm = txtPreComm.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity = txtGoodsQuantity.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_GoodsValue = txtGoodsValue.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CommPoint = txtCommPoint.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgentModel = rdbAgentModel1.Checked ? 1 : 2;
        model.OfficeAutomation_Document_ProjLinkRepoData_ContractType = rdbContractType1.Checked ? 1 : (rdbContractType2.Checked ? 2 : 3);
        model.OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther = txtContractTypeOther.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost = rdbHaveCoopCost.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf = rdbHaveCoopConf.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsSignBack = rdbIsSignBack.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate = txtContractPreSignBackDate.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_Remark = txtRemark.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate = txtLinkStartDate.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate = txtLinkEndDate.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet = txtCommCalcGet.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount = txtProjDepCount.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice = txtProjDepPrice.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm = txtProjDepComm.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PropDepCount = txtPropDepCount.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice = txtPropDepPrice.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PropDepComm = txtPropDepComm.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetType = rdbCalcGetType1.Checked ? 1 : (rdbCalcGetType2.Checked ? 2 : (rdbCalcGetType3.Checked ? 3 : (rdbCalcGetType4.Checked ? 4 : 5)));
        model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther = txtCalcGetTypeOther.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AssumeType = rdbAssumeType1.Checked ? 1 : (rdbAssumeType2.Checked ? 2 : (rdbAssumeType3.Checked ? 3 : (rdbAssumeType4.Checked ? 4 : 5)));
        model.OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther = txtAssumeTypeOther.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AddRemark = txtAddRemark.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjType = int.Parse(hdProjType.Value);
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount = txtProjDepPreCount.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm = txtProjDepPreComm.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo = hdDetail.Value;
        if (!string.IsNullOrEmpty(txtDealHistoryStartDate.Text))
            model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate = DateTime.Parse(txtDealHistoryStartDate.Text);
        if (!string.IsNullOrEmpty(txtDealHistoryEndDate.Text))
            model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate = DateTime.Parse(txtDealHistoryEndDate.Text);
        if (!string.IsNullOrEmpty(txtTotalProfitStartDate.Text))
            model.OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate = DateTime.Parse(txtTotalProfitStartDate.Text);
        if (!string.IsNullOrEmpty(txtTotalProfitEndDate.Text))
            model.OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate = DateTime.Parse(txtTotalProfitEndDate.Text);
        model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount = txtHisIndepCount.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance = txtHisIndepPerformance.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount = txtHisLinkCount.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance = txtHisLinkPerformance.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit = txtHisTotalProfit.Text;

        //20141027+
        model.OfficeAutomation_Document_ProjLinkRepoData_JOrT = rdbJOrT1.Checked ? 1 : rdbJOrT2.Checked ? 2 : rdbJOrT3.Checked ? 3 : 0;
        model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1 = txtSamePlaceXX1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2 = txtSamePlaceXX2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1 = txtTurnsAgentXX1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2 = txtTurnsAgentXX2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1 = txtAgencyFee1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2 = txtAgencyFee2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3 = txtAgencyFee3.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4 = txtAgencyFee4.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1 = rdbIsCashPrize11.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2 = rdbIsCashPrize21.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3 = rdbIsCashPrize31.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4 = rdbIsCashPrize41.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize1 = txtCashPrize1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize2 = txtCashPrize2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize3 = txtCashPrize3.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize4 = txtCashPrize4.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1 = txtAgencyBeginDate1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2 = txtAgencyBeginDate2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1 = txtAgencyEndDate1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2 = txtAgencyEndDate2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear1 = rdbIsPFear11.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear2 = rdbIsPFear21.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear3 = rdbIsPFear31.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear4 = rdbIsPFear41.Checked;
        model.OfficeAutomation_Document_ProjLinkRepoData_PFear1 = txtPFear1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PFear2 = txtPFear2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PFear3 = txtPFear3.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PFear4 = txtPFear4.Text;
        //20141027+

        return model;
    }

    private DataEntity.PageModel.T_OfficeAutomation_Document_ProjLinkRepoData_M GetModelMFromPage(Guid ProjLinkRepoDataID)
    {
        var model = new DataEntity.PageModel.T_OfficeAutomation_Document_ProjLinkRepoData_M();

        model.OfficeAutomation_Document_ProjLinkRepoData_ID = ProjLinkRepoDataID.ToString();
        model.OfficeAutomation_Document_ProjLinkRepoData_MainID = MainID;
        model.OfficeAutomation_Document_ProjLinkRepoData_Department = txtDepartment.Text !=null ? txtDepartment.Text:"";
        model.OfficeAutomation_Document_ProjLinkRepoData_ApplyDate = DateTime.Now.ToString();
        model.OfficeAutomation_Document_ProjLinkRepoData_Apply = EmployeeName;
        model.OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone = txtReplyPhone.Text != null ? txtReplyPhone.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_ApplyID = txtApplyID.Text != null ? txtApplyID.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjName = txtProjName.Text != null ? txtProjName.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID = rdbHavePreSaleID.Checked ? "True" : "False";
        model.OfficeAutomation_Document_ProjLinkRepoData_PreSaleID = txtPreSaleID.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjAddress = txtProjAddress.Text != null ? txtProjAddress.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_DeveloperName = txtDeveloperName.Text != null ? txtDeveloperName.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_GroupName = txtGroupName.Text != null ? txtGroupName.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs = sOfficeType; // hdDealOfficeType.Value;
        model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther = txtDealOfficeOther.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate = txtAgentStartDate.Text != null ? txtAgentStartDate.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate = txtAgentEndDate.Text != null ? txtAgentEndDate.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_PreComm = txtPreComm.Text != null ? txtPreComm.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity = txtGoodsQuantity.Text != null ? txtGoodsQuantity.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_GoodsValue = txtGoodsValue.Text != null ? txtGoodsValue.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_CommPoint = txtCommPoint.Text != null ? txtCommPoint.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_AgentModel = rdbAgentModel1.Checked ? "1" :( rdbAgentModel2.Checked? "2":"3");
        model.OfficeAutomation_Document_ProjLinkRepoData_ContractType = rdbContractType1.Checked ? "1" : (rdbContractType2.Checked ? "2" : rdbContractType3.Checked?"3":"4");
        model.OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther = txtContractTypeOther.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost = rdbHaveCoopCost.Checked ? "True" : "False";
        model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf = rdbHaveCoopConf.Checked ? "True" : "False";
        model.OfficeAutomation_Document_ProjLinkRepoData_IsSignBack = rdbIsSignBack.Checked ? "True" : "False";
        model.OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate = txtContractPreSignBackDate.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_Remark = txtRemark.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate = txtLinkStartDate.Text != null ? txtLinkStartDate.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate = txtLinkEndDate.Text != null ? txtLinkEndDate.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet = txtCommCalcGet.Text != null ? txtCommCalcGet.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount = txtProjDepCount.Text != null ? txtProjDepCount.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice = txtProjDepPrice.Text != null ? txtProjDepPrice.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm = txtProjDepComm.Text != null ? txtProjDepComm.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_PropDepCount = txtPropDepCount.Text != null ? txtPropDepCount.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice = txtPropDepPrice.Text != null ? txtPropDepPrice.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_PropDepComm = txtPropDepComm.Text != null ? txtPropDepComm.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetType = rdbCalcGetType1.Checked ? "1" : (rdbCalcGetType2.Checked ? "2" : (rdbCalcGetType3.Checked ? "3" : (rdbCalcGetType4.Checked ? "4" : rdbCalcGetType5.Checked? "5":"6")));
        model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther = txtCalcGetTypeOther.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AssumeType = rdbAssumeType1.Checked ? "1" : (rdbAssumeType2.Checked ? "2" : (rdbAssumeType3.Checked ? "3" : (rdbAssumeType4.Checked ? "4" : rdbAssumeType5.Checked? "5":"6")));
        model.OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther = txtAssumeTypeOther.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AddRemark = txtAddRemark.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjType = hdProjType.Value != null ? hdProjType.Value : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount = txtProjDepPreCount.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm = txtProjDepPreComm.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo = hdDetail.Value;
        if (!string.IsNullOrEmpty(txtDealHistoryStartDate.Text))
            model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate = txtDealHistoryStartDate.Text;
        if (!string.IsNullOrEmpty(txtDealHistoryEndDate.Text))
            model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate = txtDealHistoryEndDate.Text;
        if (!string.IsNullOrEmpty(txtTotalProfitStartDate.Text))
            model.OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate = txtTotalProfitStartDate.Text;
        if (!string.IsNullOrEmpty(txtTotalProfitEndDate.Text))
            model.OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate = txtTotalProfitEndDate.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount = txtHisIndepCount.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance = txtHisIndepPerformance.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount = txtHisLinkCount.Text != null ? txtHisLinkCount.Text : "";
        model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance = txtHisLinkPerformance.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit = txtHisTotalProfit.Text;

        //20141027+
        model.OfficeAutomation_Document_ProjLinkRepoData_JOrT = rdbJOrT1.Checked ? "1" : rdbJOrT2.Checked ? "2" : rdbJOrT3.Checked ? "3" : "0";
        model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1 = txtSamePlaceXX1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2 = txtSamePlaceXX2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1 = txtTurnsAgentXX1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2 = txtTurnsAgentXX2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1 = txtAgencyFee1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2 = txtAgencyFee2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3 = txtAgencyFee3.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4 = txtAgencyFee4.Text;
        if (rdbIsCashPrize11.Checked || rdbIsCashPrize12.Checked)
        {
            model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1 = rdbIsCashPrize11.Checked.ToString();
        }
        if (rdbIsCashPrize21.Checked || rdbIsCashPrize22.Checked)
        {
            model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2 = rdbIsCashPrize21.Checked.ToString();
        }
        if (rdbIsCashPrize31.Checked || rdbIsCashPrize32.Checked)
        {
            model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3 = rdbIsCashPrize31.Checked.ToString();
        }
        if (rdbIsCashPrize41.Checked || rdbIsCashPrize42.Checked)
        {
            model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4 = rdbIsCashPrize41.Checked.ToString();
        }
        model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize1 = txtCashPrize1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize2 = txtCashPrize2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize3 = txtCashPrize3.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize4 = txtCashPrize4.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1 = txtAgencyBeginDate1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2 = txtAgencyBeginDate2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1 = txtAgencyEndDate1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2 = txtAgencyEndDate2.Text;
        if (rdbIsPFear11.Checked || rdbIsPFear12.Checked)
        {
            model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear1 = rdbIsPFear11.Checked.ToString();
        }
        if (rdbIsPFear21.Checked || rdbIsPFear22.Checked)
        {
            model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear2 = rdbIsPFear21.Checked.ToString();
        }
        if (rdbIsPFear31.Checked || rdbIsPFear32.Checked)
        {
            model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear3 = rdbIsPFear31.Checked.ToString();
        }
        if (rdbIsPFear41.Checked || rdbIsPFear41.Checked)
        {
            model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear4 = rdbIsPFear41.Checked.ToString();
        }
        model.OfficeAutomation_Document_ProjLinkRepoData_PFear1 = txtPFear1.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PFear2 = txtPFear2.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PFear3 = txtPFear3.Text;
        model.OfficeAutomation_Document_ProjLinkRepoData_PFear4 = txtPFear4.Text;
        //20141027+

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

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite17"] = "1";
        Response.Write("<script>window.open('Apply_ProjLinkRepoData_Detail.aspx?MainID=" + MainID + "');</script>");
    }
    protected void btnSPDF_Click(object sender, EventArgs e) //M_PDF
    {
        try
        {
            //因为Web 是多线程环境，避免甲产生的文件被乙下载去，所以档名都用唯一 
            string fileNameWithOutExtention = Guid.NewGuid().ToString();
            string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri + "&htmltopdf=Yes&EPID=" + EmployeeID + " ";
            //执行wkhtmltopdf.exe 
            Process p = System.Diagnostics.Process.Start(System.Web.HttpContext.Current.Server.MapPath("/Exe\\wkhtmltopdf"), baseUrl + System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + fileNameWithOutExtention + ".pdf"));
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("项目联动报数申请表.pdf"));//强制下载 
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

        DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_ID"].ToString(); //在不同的表要注意修改

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
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
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
            DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjLinkRepoData_Department"].ToString();
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
                if (i < 9)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9");
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
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
            DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjLinkRepoData_Department"].ToString();
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
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9");
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
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
            DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjLinkRepoData_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9");
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 2); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_ProjLinkRepoData_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    protected void Review(int index, string sug) //M_AddAnother：20150716 黄生其它意见，增加审批人
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        //T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4;
        T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2); //M_AlAno：20160217 ++
        flowsa = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, index);
        if (flowsa == null)
        {
            if (!fst4.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst4.OfficeAutomation_Flow_Employee.Contains(EmployeeName))
            { //M_AlAno：20160217 ++
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID + "," + fst4.OfficeAutomation_Flow_EmployeeID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName + "," + fst4.OfficeAutomation_Flow_Employee;
            }
            else
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName;
            }
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID; //M_AlAno：20160217 --
            //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = index;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }
        string sisa = "2";

        if (rdb220a1.Checked) //M_AlterM：20150820
            sisa = "1";
        else if (rdb220a2.Checked)
            sisa = "0";

        if (index != 220)
        {
            flowsh = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 220);
            if (flowsh == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 220;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
            da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, 220); //M_AlterM：20150826
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        }

        flowsb = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, index);
        string se = null; //M_RA：20151120
        if (index == 220 && flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID))
        {

            if (!flowsb.OfficeAutomation_Flow_Suggestion.Contains("---------------------------------------------------------------------"))
            {
                se = flowsb.OfficeAutomation_Flow_Suggestion
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　日期：" + flowsb.OfficeAutomation_Flow_AuditDate + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n"
                    + sug
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　日期：" + DateTime.Now.ToString() + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n";
            }
            else
            {
                se = flowsb.OfficeAutomation_Flow_Suggestion
                    + "\r\n"
                    + sug
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　日期：" + DateTime.Now.ToString() + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n";
            }
            if(!se.Contains("1900-01-01 0:00:00")) sug = se;
        }
        //if (flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID)) //M_AlAno：20160217 --u++m //M_RA：20151120
        if (flowsb != null
    && flowsb.OfficeAutomation_Flow_Employee.Contains(fst4.OfficeAutomation_Flow_Employee) && flowsb.OfficeAutomation_Flow_EmployeeID.Contains(fst4.OfficeAutomation_Flow_EmployeeID)
    && fst4.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && fst4.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID)
    && flowsb.OfficeAutomation_Flow_EmployeeID != flowsb.OfficeAutomation_Flow_AuditorID)
            sug = !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_Suggestion) ? flowsb.OfficeAutomation_Flow_Suggestion + "\r\n\r\n" + sug : sug; //M_AlAno：20160217 ++
        
        if (flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID) && flowsb.OfficeAutomation_Flow_EmployeeID == flowsb.OfficeAutomation_Flow_AuditorID) //M_AlAno：20160217 --u++m
            da_OfficeAutomation_Flow_Inherit.UpdateFlowsSuggestionA(MainID, index.ToString(), sug, sisa); //M_AlterM：20150820
        else //M_AlAno：20160217 d--dd++
            //da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, EmployeeID, EmployeeName + "（复审）", sug, index.ToString(), sisa);
            da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, EmployeeID, EmployeeName + "（复审）", sug, index.ToString(), sisa);
        if (sisa == "0")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 5); //添加日志，复审
        else if (sisa == "1")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 4); //添加日志，复审
        else
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 6); //添加日志，复审
        RunJS("alert('复审意见已保存！');window.location='" + Page.Request.Url + "'");
    }

    protected void btnSignIDx200_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        string[] employnames;
        string email;
        string msnBody;
        DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_ProjLinkRepoData_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
        DataSet ds = da_OfficeAutomation_Document_ProjLinkRepoData_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ProjLinkRepoData_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
        //通知已审批的全部人员
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDBeforeIdx(MainID, 200);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
            employnames = employname.Split(',');
            for (int i2 = 0; i2 < employnames.Length; i2++)
            {
                msnBody = "您好，" + employnames[i2] + EmployeeName + "已回复了您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                email = employnames[i2]; if (email != "")
                    Common.SendMessageEX(false, email, EmployeeName + "发表了复审意见", msnBody, msnBody);
            }
        }

        Review(200, txtIDx200.Value);
    }
    protected void btnSignIDx220_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ProjLinkRepoData_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

        string employname = CommonConst.EMP_GMO_NAME;
        string[] employnames = employname.Split(',');
        string email, msnBody;
        for (int i = 0; i < employnames.Length; i++)
        {
            email = employnames[i];
            msnBody = "您好" + employnames[i] + "黄生已复审了" + department + "，编号为" + serialNumber + "的" + documentName + "。<br />黄生的意见：" + txtIDx220.Value + "<br/>申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
            Common.SendMessageEX(false, email, "请注意，总经理发表了复审意见", msnBody, msnBody);
        }

        Review(220, txtIDx220.Value);
    }
}