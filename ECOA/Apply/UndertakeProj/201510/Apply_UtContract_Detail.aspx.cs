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
using System.Web.Script.Serialization;

using AppCommon.Model;
using JsonOutEstateList = DataEntity.Json.CCES.JsonOutEstateList;
using System.Linq;
using Newtonsoft.Json;

public partial class Apply_UtContract_Apply_UtContract_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml1 = new StringBuilder();
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbHtml3 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public string ApplyN;

    public StringBuilder SbCcesp = new StringBuilder();
    public StringBuilder SbJsonSOR = new StringBuilder();

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
        SbJson.Append("[]");
        SbJsonSOR.Append("[]");
        GetCCESP(txtName1.Text);
        GetSecondOR();

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
                if (Session["FLG_ReWrite67"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite67"] = null;
                }
            }
            catch
            { }
            if (UrlMainID != "")
            {
                MainID = UrlMainID;
                LoadPage();
            }
            else
                InitPage();
        }
        else
        {
            GetAllDepartment();
        }
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        rdbProjFear1.Checked = true;
        btnSave.Visible = true;
        txtApply.Text = EmployeeName;
        DA_User_Permission_Inherit dA_User_Permission_Inherit = new DataAccess.Operate.DA_User_Permission_Inherit();
        DataTable dt = dA_User_Permission_Inherit.getUserRegion(EmployeeID);
        txtAreaScale1.Text = dt.Rows[0]["AreaName"].ToString();
        //   txtAreaScale.Text = dt.Rows[0]["AreaName"].ToString();
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
        DrawDetailTable(2, 2, 2);
        SbJs.Append("</script>");
        IsNewApply = true;
        InitListControler("", "", "", "", "");
        MainID = Guid.NewGuid().ToString();

        //2016/8/24 52100
        ddlProjectAddressBind("");
    }

    private void InitListControler(string departmentTypeSelectedValue, string projectPropertySelectedValue, string agentPropertySelectedValue, string dealTypeSelectedValue, string dealOfficeTypeSelectedValue)
    {
        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DepartmentType_Operate();
        DataSet ds;
        ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(18);

        DA_Dic_OfficeAutomation_DealType_Operate da_Dic_OfficeAutomation_DealType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DealType_Operate();
        ds = da_Dic_OfficeAutomation_DealType_Operate.SelectAll();
        DropDownListBind(ddlDealType, ds.Tables[0], "OfficeAutomation_DealType_ID", "OfficeAutomation_DealType_Name", dealTypeSelectedValue, "-请选择-");

        DA_Dic_OfficeAutomation_DirectContractType_Operate da_Dic_OfficeAutomation_DirectContractType_Operate = new DA_Dic_OfficeAutomation_DirectContractType_Operate();
        ds = da_Dic_OfficeAutomation_DirectContractType_Operate.SelectAll();
        DropDownListBind(ddlCorporateType, ds.Tables[0], "OfficeAutomation_DirectContractType_ID", "OfficeAutomation_DirectContractType_Name", "", "-请选择-");

        DA_Dic_OfficeAutomation_DealOfficeType_Operate da_Dic_OfficeAutomation_DealOfficeType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DealOfficeType_Operate();
        ds = da_Dic_OfficeAutomation_DealOfficeType_Operate.SelectByDocumentID(14);
        CheckBoxListBind(cblDealOfficeType, ds.Tables[0], "OfficeAutomation_DealOfficeType_ID", "OfficeAutomation_DealOfficeType_Name", dealOfficeTypeSelectedValue);
        for (int i = 0; i < cblDealOfficeType.Items.Count; i++)
        {
            cblDealOfficeType.Items[i].Attributes["tag"] = cblDealOfficeType.Items[i].Value;
        }
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        bool IsTempSave = false;        //是否暂存
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        DA_OfficeAutomation_Document_UtContract_Detail_Inherit da_OfficeAutomation_Document_UtContract_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_UtContract_Detail_Inherit();
        IsNewApply = false;
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

        SbJs.Append("<script type=\"text/javascript\">$(\"#spanApplyFor\").show();$(\"#CouldFlange\").show();$(\"#EarnMoney\").show();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        DataSet UtContract_Detail = new DataSet();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var obj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_UtContract_Detail>("UtContractDetail", "", Mainobj.OfficeAutomation_SerialNumber);
            ds = Common.GetPageDetailDS<T_OfficeAutomation_Document_UtContract>(obj.UtContract, Mainobj);
            UtContract_Detail = Common.GetDataSet<T_OfficeAutomation_Document_UtContract_Detail>(obj.UtContract_Detail);
            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID);
        }

        //ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_UtContract_ID"].ToString();

        string applicant = dr["OfficeAutomation_Document_UtContract_Apply"].ToString();
        ApplyN = applicant;
        txtApply.Text = applicant;
        txtDepartment.Text = dr["OfficeAutomation_Document_UtContract_Department"].ToString();
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_UtContract_ApplyDate"].ToString()).ToString("yyyy-MM-dd");

        //应收款管理组结佣 张婉晴、蓝晴、刘莹仪、谭青华
        if (EmployeeID == "50203" || EmployeeID == "54917" || EmployeeID == "28614" || EmployeeID == "51673" || EmployeeID == "5703")
        {
            bFinSige.Visible = true;
        }
        txtOneFront.Value = dr["OfficeAutomation_Document_UtContract_OneFront"].ToString();
        txtOneAfter.Value = dr["OfficeAutomation_Document_UtContract_OneAfter"].ToString();
        txtTurnFront.Value = dr["OfficeAutomation_Document_UtContract_TurnFront"].ToString();
        txtTurnAfter.Value = dr["OfficeAutomation_Document_UtContract_TurnAfter"].ToString();












        txtName1.Text = dr["OfficeAutomation_Document_UtContract_Name1"].ToString();
        txtName2.Text = dr["OfficeAutomation_Document_UtContract_Name2"].ToString();
        txtDeveloper.Text = dr["OfficeAutomation_Document_UtContract_Developer"].ToString();
        txtGroupName.Text = dr["OfficeAutomation_Document_UtContract_GroupName"].ToString();
        string BaseAgent = dr["OfficeAutomation_Document_UtContract_BaseAgent"].ToString();
        if (BaseAgent.Contains("1"))
            cbBaseAgent1.Checked = true;
        if (BaseAgent.Contains("2"))
            cbBaseAgent2.Checked = true;
        if (BaseAgent.Contains("3"))
            cbBaseAgent3.Checked = true;
        if (BaseAgent.Contains("4"))
        {
            cbBaseAgent4.Checked = true;
            txtBaseAgentOther.Text = dr["OfficeAutomation_Document_UtContract_BaseAgentOther"].ToString();
        }
        hiDirectContract.Value = dr["OfficeAutomation_Document_UtContract_IsDirectContract"].ToString();
        txtCorporateName.Text = dr["OfficeAutomation_Document_UtContract_DirectContractName"].ToString();

        //txtDealType.Text = dr["OfficeAutomation_Document_UtContract_DealType"].ToString();
        txtProjectArea.Text = dr["OfficeAutomation_Document_UtContract_ProjectArea"].ToString();
        //统筹分佣比例
        // txtOverallScale.Text = dr["OfficeAutomation_Document_UtContract_OverallScale"].ToString();
        txtLastBeginDate.Text = dr["OfficeAutomation_Document_UtContract_LastBeginDate"].ToString();
        txtLastEndDate.Text = dr["OfficeAutomation_Document_UtContract_LastEndDate"].ToString();
        txtLastSumNum.Text = dr["OfficeAutomation_Document_UtContract_LastSumNum"].ToString();
        txtTurnover.Text = dr["OfficeAutomation_Document_UtContract_Turnover"].ToString();
        txtLastResults.Text = dr["OfficeAutomation_Document_UtContract_LastResults"].ToString();
        txtCumulativeBeginDate.Text = dr["OfficeAutomation_Document_UtContract_CumulativeBeginDate"].ToString();
        txtCumulativeEndDate.Text = dr["OfficeAutomation_Document_UtContract_CumulativeEndDate"].ToString();
        txtCumulativeNum.Text = dr["OfficeAutomation_Document_UtContract_CumulativeNum"].ToString();
        txtSumTurnover.Text = dr["OfficeAutomation_Document_UtContract_SumTurnover"].ToString();
        txtCumulativeResults.Text = dr["OfficeAutomation_Document_UtContract_CumulativeResults"].ToString();
        //txtDealOfficeTypeIDs.Text = dr["OfficeAutomation_Document_UtContract_DealOfficeTypeIDs"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_IsStree"].ToString() == "1")
            rdbIsStree1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsStree"].ToString() == "2")
            rdbIsStree2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_IsMarking"].ToString() == "1")
            rdbIsMarking1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsMarking"].ToString() == "2")
            rdbIsMarking2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_IsBusiness"].ToString() == "1")
            rdbIsBusiness1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsBusiness"].ToString() == "2")
            rdbIsBusiness2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_IsBackRent"].ToString() == "1")
            rdbIsBackRent1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsBackRent"].ToString() == "2")
            rdbIsBackRent2.Checked = true;

        txtProjectAddress.Text = dr["OfficeAutomation_Document_UtContract_txtProjectAddress"].ToString();
        txtReportAddress.Text = dr["OfficeAutomation_Document_UtContract_txtReportAddress"].ToString();
        txtDeveloperContacter.Text = dr["OfficeAutomation_Document_UtContract_DeveloperContacter"].ToString();
        txtDeveloperContacterPosition.Text = dr["OfficeAutomation_Document_UtContract_DeveloperContacterPosition"].ToString();
        txtDeveloperContacterPhone.Text = dr["OfficeAutomation_Document_UtContract_DeveloperContacterPhone"].ToString();
        txtAreaFollowerContacter.Text = dr["OfficeAutomation_Document_UtContract_AreaFollowerContacter"].ToString();
        txtAreaFollowerContacterPosition.Text = dr["OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition"].ToString();
        txtAreaFollowerContacterPhone.Text = dr["OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone"].ToString();
        txtAreaCheckDataer.Text = dr["OfficeAutomation_Document_UtContract_AreaCheckDataer"].ToString();
        txtAreaCheckDataerCode.Text = dr["OfficeAutomation_Document_UtContract_AreaCheckDataerCode"].ToString();
        txtAreaCheckDataerPhone.Text = dr["OfficeAutomation_Document_UtContract_AreaCheckDataerPhone"].ToString();
        txtSquare.Text = dr["OfficeAutomation_Document_UtContract_Square"].ToString();
        txtSetNumber.Text = dr["OfficeAutomation_Document_UtContract_SetNumber"].ToString();
        txtUnitPrice.Text = dr["OfficeAutomation_Document_UtContract_UnitPrice"].ToString();
        txtTotalPrice.Text = dr["OfficeAutomation_Document_UtContract_TotalPrice"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_IsCoopWithECommerce"].ToString() == "1")
        {
            rdbIsCoopWithECommerce1.Checked = true;
            if (dr["OfficeAutomation_Document_UtContract_FtoZ"].ToString() == "1")
                rdbFtoZ1.Checked = true;
            else if (dr["OfficeAutomation_Document_UtContract_FtoZ"].ToString() == "2")
                rdbFtoZ2.Checked = true;
            if (dr["OfficeAutomation_Document_UtContract_IsUploadF"].ToString() == "1")
                rdbIsUploadF1.Checked = true;
            else if (dr["OfficeAutomation_Document_UtContract_IsUploadF"].ToString() == "2")
                rdbIsUploadF2.Checked = true;
        }
        else if (dr["OfficeAutomation_Document_UtContract_IsCoopWithECommerce"].ToString() == "2")
        {
            rdbIsCoopWithECommerce2.Checked = true;
            //若选择了 2、是，与其他电商签约，电商公司名称，则要显示 选择此电商的理由
            this.txtECommerceReason.Text = dr["OfficeAutomation_Document_UtContract_ECommerceReason"].ToString().Trim();
        }
        else if (dr["OfficeAutomation_Document_UtContract_IsCoopWithECommerce"].ToString() == "3")
        {
            rdbIsCoopWithECommerce3.Checked = true;
            //若选择了 3、否，不需与电商签约，但客户需要在电商公司刷卡以获取买房优惠，则要显示 刷卡优惠金额
            string DiscountMoney = dr["OfficeAutomation_Document_UtContract_DiscountMoney"].ToString().Trim();
            if (!string.IsNullOrEmpty(DiscountMoney) && DiscountMoney == "-1")
            {
                this.txtDiscountMoney.Text = "";
            }
            else
            {
                this.txtDiscountMoney.Text = DiscountMoney;
            }
        }
        else if (dr["OfficeAutomation_Document_UtContract_IsCoopWithECommerce"].ToString() == "4")
            rdbIsCoopWithECommerce4.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_OneOrTwo"].ToString() == "1")
            rdbOneOrTwo1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_OneOrTwo"].ToString() == "2")
            rdbOneOrTwo2.Checked = true;

        if (dr["OfficeAutomation_Document_UtContract_IsPreSale"].ToString() == "1")
            rbtIsPreSale1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsPreSale"].ToString() == "2")
            rbtIsPreSale2.Checked = true;
        //限购
        if (dr["OfficeAutomation_Document_UtContract_IslimitBuy"].ToString() == "1")
            rbtIslimitBuy1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IslimitBuy"].ToString() == "2")
            rbtIslimitBuy2.Checked = true;
        //限签
        if (dr["OfficeAutomation_Document_UtContract_IslimitSign"].ToString() == "1")
            rbtIslimitSign1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IslimitSign"].ToString() == "2")
            rbtIslimitSign2.Checked = true;
        txtCoopWithE1.Text = dr["OfficeAutomation_Document_UtContract_CoopWithE1"].ToString();
        txtCoopWithE2.Text = dr["OfficeAutomation_Document_UtContract_CoopWithE2"].ToString();
        txtCoopWithE3.Text = dr["OfficeAutomation_Document_UtContract_CoopWithE3"].ToString();
        txtCoopWithE4.Text = dr["OfficeAutomation_Document_UtContract_CoopWithE4"].ToString();
        txtCoopWithE5.Text = dr["OfficeAutomation_Document_UtContract_CoopWithE5"].ToString();
        txtECommerceName.Text = dr["OfficeAutomation_Document_UtContract_ECommerceName"].ToString();
        txtECommerceName2.Text = dr["OfficeAutomation_Document_UtContract_ECommerceName2"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_ProjFear"].ToString() == "1" || dr["OfficeAutomation_Document_UtContract_ProjFear"].ToString() == "0")
            rdbProjFear1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_ProjFear"].ToString() == "2")
            rdbProjFear2.Checked = true;

        txtProjSum1.Text = dr["OfficeAutomation_Document_UtContract_ProjSum1"].ToString();
        txtProjSum2.Text = dr["OfficeAutomation_Document_UtContract_ProjSum2"].ToString();
        txtProjSum3.Text = dr["OfficeAutomation_Document_UtContract_ProjSum3"].ToString();
        txtOwnerCommFixScale.Text = dr["OfficeAutomation_Document_UtContract_OwnerCommFixScale"].ToString();
        txtOwnerCommAgent.Text = dr["OfficeAutomation_Document_UtContract_OwnerCommAgent"].ToString();
        txtClientCommFixScale.Text = dr["OfficeAutomation_Document_UtContract_ClientCommFixScale"].ToString();
        txtClientCommAgent.Text = dr["OfficeAutomation_Document_UtContract_ClientCommAgent"].ToString();
        txtEBComm.Text = dr["OfficeAutomation_Document_UtContract_EBComm"].ToString();
        txtEBCommAgent.Text = dr["OfficeAutomation_Document_UtContract_EBCommAgent"].ToString();
        txtRemark.Text = dr["OfficeAutomation_Document_UtContract_Remark"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_Jubar1"].ToString() == "1")
            rdbOwnerCommJump1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_Jubar1"].ToString() == "2")
            rdbOwnerCommJump2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_Jubar2"].ToString() == "1")
            rdbClientCommJump1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_Jubar2"].ToString() == "2")
            rdbClientCommJump2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_Jubar3"].ToString() == "1")
            rdbEBCommJump1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_Jubar3"].ToString() == "2")
            rdbEBCommJump2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_HaveSingleReward"].ToString() == "1")
            rdbHaveSingleReward1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_HaveSingleReward"].ToString() == "2")
            rdbHaveSingleReward2.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_HaveSingleReward"].ToString() == "3")
            rdbHaveSingleReward3.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_HaveSingleReward"].ToString() == "4")
            rdbHaveSingleReward4.Checked = true;

        txtRewardSignHave.Text = dr["OfficeAutomation_Document_UtContract_RewardSignHave"].ToString();
        txtAnotherRewardC.Text = dr["OfficeAutomation_Document_UtContract_AnotherRewardC"].ToString();
        txtDeveloperConditions.Text = dr["OfficeAutomation_Document_UtContract_DeveloperConditions"].ToString();
        txtAreaConditions.Text = dr["OfficeAutomation_Document_UtContract_AreaConditions"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_PayRewardWay"].ToString() == "1")
            rdbPayRewardWay1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_PayRewardWay"].ToString() == "2")
            rdbPayRewardWay2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_IsMyPay"].ToString() == "1")
            rdbIsMyPay1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsMyPay"].ToString() == "2")
            rdbIsMyPay2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_AreaComfirn"].ToString() == "1")
            rdbAreaComfirn1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_AreaComfirn"].ToString() == "2")
            rdbAreaComfirn2.Checked = true;

        txtReturnBackDate.Text = dr["OfficeAutomation_Document_UtContract_ReturnBackDate"].ToString();
        txtTermsOfContract.Text = dr["OfficeAutomation_Document_UtContract_TermsOfContract"].ToString();
        txtTermsOfMajorIssues.Text = dr["OfficeAutomation_Document_UtContract_TermsOfMajorIssues"].ToString();
        txtAgentStartDate.Text = dr["OfficeAutomation_Document_UtContract_AgentStartDate"].ToString();
        txtAgentEndDate.Text = dr["OfficeAutomation_Document_UtContract_AgentEndDate"].ToString();
        txtClientGuardStartDate.Text = dr["OfficeAutomation_Document_UtContract_ClientGuardStartDate"].ToString();
        txtClientGuardEndDate.Text = dr["OfficeAutomation_Document_UtContract_ClientGuardEndDate"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_IsProjEarlyCommBack"].ToString() == "1")
            rdbIsProjEarlyCommBack1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsProjEarlyCommBack"].ToString() == "2")
            rdbIsProjEarlyCommBack2.Checked = true;

        txtOweCommSum.Text = dr["OfficeAutomation_Document_UtContract_OweCommSum"].ToString();
        txtAreaReason.Text = dr["OfficeAutomation_Document_UtContract_AreaReason"].ToString();
        txtOrdMoney.Text = dr["OfficeAutomation_Document_UtContract_OrdMoney"].ToString();
        txtOrdTaker.Text = dr["OfficeAutomation_Document_UtContract_OrdTaker"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_JOrT"].ToString() == "1")
            rdbJOrT1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_JOrT"].ToString() == "2")
            rdbJOrT2.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_JOrT"].ToString() == "3")
            rdbJOrT3.Checked = true;

        txtSamePlaceXX1.Text = dr["OfficeAutomation_Document_UtContract_SamePlaceXX1"].ToString();
        txtAgencyFee1.Text = dr["OfficeAutomation_Document_UtContract_AgencyFee1"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_IsCashPrize1"].ToString() == "1")
            rdbIsCashPrize11.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsCashPrize1"].ToString() == "2")
            rdbIsCashPrize12.Checked = true;

        txtCashPrize1.Text = dr["OfficeAutomation_Document_UtContract_CashPrize1"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_IsPFear1"].ToString() == "1")
            rdbIsPFear11.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsPFear1"].ToString() == "2")
            rdbIsPFear12.Checked = true;

        txtPFear1.Text = dr["OfficeAutomation_Document_UtContract_PFear1"].ToString();
        txtSamePlaceXX2.Text = dr["OfficeAutomation_Document_UtContract_SamePlaceXX2"].ToString();
        txtAgencyFee2.Text = dr["OfficeAutomation_Document_UtContract_AgencyFee2"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_IsCashPrize2"].ToString() == "1")
            rdbIsCashPrize21.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsCashPrize2"].ToString() == "2")
            rdbIsCashPrize22.Checked = true;

        txtCashPrize2.Text = dr["OfficeAutomation_Document_UtContract_CashPrize2"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_IsPFear2"].ToString() == "1")
            rdbIsPFear21.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsPFear2"].ToString() == "2")
            rdbIsPFear22.Checked = true;

        txtPFear2.Text = dr["OfficeAutomation_Document_UtContract_PFear2"].ToString();

        if (dr["OfficeAutomation_Document_UtContract_SaleMode"].ToString() == "1")
            rdbSaleMode1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_SaleMode"].ToString() == "2")
            rdbSaleMode2.Checked = true;

        txtAreaScale1.Text = dr["OfficeAutomation_Document_UtContract_AreaScale1"].ToString();
        txtMainAreaScale.Text = dr["OfficeAutomation_Document_UtContract_MainAreaScale"].ToString();
        txtDealAreaScale.Text = dr["OfficeAutomation_Document_UtContract_DealAreaScale"].ToString();
        txtAreaScale.Text = dr["OfficeAutomation_Document_UtContract_AreaScale"].ToString();
        txtMainAreaScale2.Text = dr["OfficeAutomation_Document_UtContract_MainAreaScale2"].ToString();
        txtDealAreaScale2.Text = dr["OfficeAutomation_Document_UtContract_DealAreaScale2"].ToString();

        string Nre = dr["OfficeAutomation_Document_UtContract_Nre"].ToString();
        if (Nre.Contains("1"))
            cbNre1.Checked = true;
        if (Nre.Contains("2"))
            cbNre2.Checked = true;
        if (Nre.Contains("3"))
            cbNre3.Checked = true;

        txtAnotherCompany.Text = dr["OfficeAutomation_Document_UtContract_AnotherCompany"].ToString();

        string Rce = dr["OfficeAutomation_Document_UtContract_Rce"].ToString();
        if (Rce.Contains("1"))
            cbRce1.Checked = true;
        if (Rce.Contains("2"))
            cbRce2.Checked = true;
        if (Rce.Contains("3"))
            cbRce3.Checked = true;

        txtWillBreakUp.Text = dr["OfficeAutomation_Document_UtContract_WillBreakUp"].ToString();
        txtBreakUp.Text = dr["OfficeAutomation_Document_UtContract_BreakUp"].ToString();
        txtGuaranTime.Text = dr["OfficeAutomation_Document_UtContract_GuaranTime"].ToString();
        txtNcommissions.Text = dr["OfficeAutomation_Document_UtContract_Ncommissions"].ToString();

        txtLack6.Text = dr["OfficeAutomation_Document_UtContract_Lack6"].ToString();
        txtAS2.Text = dr["OfficeAutomation_Document_UtContract_AS2"].ToString();
        txtMS2.Text = dr["OfficeAutomation_Document_UtContract_MS2"].ToString();
        txtPreCompleteNumber.Text = dr["OfficeAutomation_Document_UtContract_PreCompleteNumber"].ToString();
        txtPreCompleteMoney.Text = dr["OfficeAutomation_Document_UtContract_PreCompleteMoney"].ToString();
        txtPreCompleteComm.Text = dr["OfficeAutomation_Document_UtContract_PreCompleteComm"].ToString();
        if (dr["OfficeAutomation_Document_UtContract_FtoZ"].ToString() == "1")
            rdbFtoZ1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_FtoZ"].ToString() == "2")
            rdbFtoZ2.Checked = true;
        if (dr["OfficeAutomation_Document_UtContract_IsUploadF"].ToString() == "1")
            rdbIsUploadF1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_IsUploadF"].ToString() == "2")
            rdbIsUploadF2.Checked = true;
        string sl = dr["OfficeAutomation_Document_UtContract_Lack"].ToString();
        if (sl.Contains("1"))
            cbLack1.Checked = true;
        if (sl.Contains("2"))
            cbLack2.Checked = true;
        if (sl.Contains("3"))
            cbLack3.Checked = true;
        if (sl.Contains("4"))
            cbLack4.Checked = true;
        if (sl.Contains("5"))
            cbLack5.Checked = true;
        if (sl.Contains("6"))
            cbLack6.Checked = true;
        if (sl.Contains("7"))
            cbLack7.Checked = true;

        if (dr["OfficeAutomation_Document_UtContract_DealS"].ToString() == "1")
            rdbDealS1.Checked = true;
        else if (dr["OfficeAutomation_Document_UtContract_DealS"].ToString() == "2")
            rdbDealS2.Checked = true;

        ddlProjectAddressBind(dr["OfficeAutomation_Document_UtContract_ddlProjectAddress"].ToString());
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        InitListControler("", "", "", dr["OfficeAutomation_Document_UtContract_DealType"].ToString(), dr["OfficeAutomation_Document_UtContract_DealOfficeTypeIDs"].ToString());

        #region 2016/10/27 52100
        txtACName.Text = dr["OfficeAutomation_Document_UtContract_ACName"].ToString();
        txtQRCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_QRCommissionRatio"].ToString();
        txtQRDeadlines.Text = dr["OfficeAutomation_Document_UtContract_QRDeadlines"].ToString();
        txtYCCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_YCCommissionRatio"].ToString();
        txtYCDeadlines.Text = dr["OfficeAutomation_Document_UtContract_YCDeadlines"].ToString();
        dllHirePurchase.SelectedValue = dr["OfficeAutomation_Document_UtContract_HirePurchase"].ToString();
        txtZFRatio.Text = dr["OfficeAutomation_Document_UtContract_ZFRatio"].ToString();
        txtFQCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_FQCommissionRatio"].ToString();
        txtFQDeadlines.Text = dr["OfficeAutomation_Document_UtContract_FQDeadlines"].ToString();
        txtHousingFund.Text = dr["OfficeAutomation_Document_UtContract_HousingFund"].ToString();
        txtHour.Text = dr["OfficeAutomation_Document_UtContract_Hour"].ToString();
        txtHousDeadlines.Text = dr["OfficeAutomation_Document_UtContract_HousDeadlines"].ToString();
        ddlDownpayment.SelectedValue = dr["OfficeAutomation_Document_UtContract_Downpayment"].ToString();
        txtSFRatio.Text = dr["OfficeAutomation_Document_UtContract_SFRatio"].ToString();
        txtSFCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_SFCommissionRatio"].ToString();
        txtSFDeadlines.Text = dr["OfficeAutomation_Document_UtContract_SFDeadlines"].ToString();
        ddlLoan.SelectedValue = dr["OfficeAutomation_Document_UtContract_Loan"].ToString();
        txtLoanRatio.Text = dr["OfficeAutomation_Document_UtContract_LoanRatio"].ToString();
        txtFKCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_FKCommissionRatio"].ToString();
        txtFKDeadlines.Text = dr["OfficeAutomation_Document_UtContract_FKDeadlines"].ToString();

        //if (dr["OfficeAutomation_Document_UtContract_AJ1CommissionRatio"] == null || dr["OfficeAutomation_Document_UtContract_AJ1CommissionRatio"].ToString()=="")
        //{
        //    SbJs.Append("$(\".AJ1\").hide();");
        //}
        //if (dr["OfficeAutomation_Document_UtContract_AJ2CommissionRatio"] == null || dr["OfficeAutomation_Document_UtContract_AJ2CommissionRatio"].ToString() == "")
        //{
        //    SbJs.Append("$(\".AJ2\").hide();");
        //}
        //if (dr["OfficeAutomation_Document_UtContract_AJ3CommissionRatio"] == null || dr["OfficeAutomation_Document_UtContract_AJ3CommissionRatio"].ToString() == "")
        //{
        //    SbJs.Append("$(\".AJ3\").hide();");
        //}
        //if (dr["OfficeAutomation_Document_UtContract_BACommissionRatio"] == null || dr["OfficeAutomation_Document_UtContract_BACommissionRatio"].ToString() == "")
        //{
        //    SbJs.Append("$(\".BA\").hide();");
        //}
        //if (dr["OfficeAutomation_Document_UtContract_YHCommissionRatio"] == null || dr["OfficeAutomation_Document_UtContract_YHCommissionRatio"].ToString() == "")
        //{
        //    SbJs.Append("$(\".YH\").hide();");
        //}
        txtAJ1CommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_AJ1CommissionRatio"].ToString();
        txtAJ1Deadlines.Text = dr["OfficeAutomation_Document_UtContract_AJ1Deadlines"].ToString();
        txtAJ2CommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_AJ2CommissionRatio"].ToString();
        txtAJ2Deadlines.Text = dr["OfficeAutomation_Document_UtContract_AJ2Deadlines"].ToString();
        txtAJ3CommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_AJ3CommissionRatio"].ToString();
        txtAJ3Deadlines.Text = dr["OfficeAutomation_Document_UtContract_AJ3Deadlines"].ToString();
        txtBACommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_BACommissionRatio"].ToString();
        txtBADeadlines.Text = dr["OfficeAutomation_Document_UtContract_BADeadlines"].ToString();
        txtYHCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_YHCommissionRatio"].ToString();
        txtYHDeadlines.Text = dr["OfficeAutomation_Document_UtContract_YHDeadlines"].ToString();

        txtRHCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_RHCommissionRatio"].ToString();
        txtRHDeadlines.Text = dr["OfficeAutomation_Document_UtContract_RHDeadlines"].ToString();
        txtSXCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_SXCommissionRatio"].ToString();
        txtSXDeadlines.Text = dr["OfficeAutomation_Document_UtContract_SXDeadlines"].ToString();
        txtDLCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_DLCommissionRatio"].ToString();
        txtDLDeadlines.Text = dr["OfficeAutomation_Document_UtContract_DLDeadlines"].ToString();
        ddlEvidence.SelectedValue = dr["OfficeAutomation_Document_UtContract_Evidence"].ToString();
        txtYJCommissionRatio.Text = dr["OfficeAutomation_Document_UtContract_YJCommissionRatio"].ToString();
        txtYJDeadlines.Text = dr["OfficeAutomation_Document_UtContract_YJDeadlines"].ToString();
        ddlReserve.SelectedValue = dr["OfficeAutomation_Document_UtContract_Reserve"].ToString();
        #endregion
        #region 统筹分佣比例加载
        //if (dr["OfficeAutomation_Document_UtContract_ID"] != null)
        //{
        //    DA_OfficeAutomation_Document_UtContract_PlanScale_Inherit da_OfficeAutomation_Document_UtContract_PlanScale_Inherit = new DA_OfficeAutomation_Document_UtContract_PlanScale_Inherit();
        //    var detaillist = da_OfficeAutomation_Document_UtContract_PlanScale_Inherit.SelectListByMainID(dr["OfficeAutomation_Document_UtContract_ID"].ToString());
        //    if (detaillist != null && detaillist.Count > 0)
        //    {
        //        var dlist = detaillist.Select(m => new
        //        {
        //            EmployeeID = m.OfficeAutomation_Document_UtContract_PlanScale_EmployeeID,
        //            EmployeeName = m.OfficeAutomation_Document_UtContract_PlanScale_EmployeeName,
        //            UnitName = m.OfficeAutomation_Document_UtContract_PlanScale_UnitName,
        //            Scale = m.OfficeAutomation_Document_UtContract_PlanScale_Scale,
        //            BeginDate = m.OfficeAutomation_Document_UtContract_PlanScale_BeginDate.Value.ToString("yyyy-MM-dd"),
        //            EndDate = m.OfficeAutomation_Document_UtContract_PlanScale_EndDate.HasValue?m.OfficeAutomation_Document_UtContract_PlanScale_EndDate.Value.ToString("yyyy-MM-dd"):""
        //        }).ToList();
        //        this.hidDetail.Value = JsonConvert.SerializeObject(dlist);
        //    }
        //}
        #endregion

        ddlCorporateType.SelectedValue = dr["OfficeAutomation_Document_UtContract_DirectContractType"].ToString();

        ddlDiskSource.SelectedValue = dr["OfficeAutomation_Document_UtContract_DiskSource"].ToString();








        wsFinance.Service sv = new wsFinance.Service();
        DataSet dsv = new DataSet();
        try
        {
            if (txtName1.Text != "")
            {
                dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name1"].ToString(), 1, 1);
                //else
                //    dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name2"].ToString(), 1, 2);
                if (dsv != null && dsv.Tables[0].Rows.Count > 0)
                {
                    lbN1.Text = dsv.Tables[0].Rows[0]["ReceAge_Comm"].ToString();
                    lbN2.Text = dsv.Tables[0].Rows[0]["ReceAge_Expire0"].ToString();
                    lbEndDate1.Text = ((DateTime)dsv.Tables[0].Rows[0]["ReceAge_EndDate"]).ToString("yyyy-MM-dd");
                    try
                    {
                        lbN1.Text = lbN1.Text.Substring(0, lbN1.Text.IndexOf('.'));
                    }
                    catch
                    {
                        lbN1.Text = "0";
                    }
                    try
                    {
                        lbN2.Text = lbN2.Text.Substring(0, lbN2.Text.IndexOf('.'));
                    }
                    catch
                    {
                        lbN2.Text = "0";
                    }
                }
                else
                {
                    lbN1.Text = "0";
                    lbN2.Text = "0";
                }
            }
            else
            {
                lbN1.Text = "0";
                lbN2.Text = "0";
            }

            if (txtName1.Text != "")
            {
                dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name1"].ToString(), 2, 1);
                //else
                //    dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name2"].ToString(), 2, 2);
                if (dsv != null && dsv.Tables[0].Rows.Count > 0)
                {
                    lbC1.Text = dsv.Tables[0].Rows[0]["ReceAge_Comm"].ToString();
                    lbEndDate2.Text = ((DateTime)dsv.Tables[0].Rows[0]["ReceAge_EndDate"]).ToString("yyyy-MM-dd");
                    try
                    {
                        lbC1.Text = lbC1.Text.Substring(0, lbC1.Text.IndexOf('.'));
                    }
                    catch
                    {
                        lbC1.Text = "0";
                    }
                }
                else
                    lbC1.Text = "0";

                dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name1"].ToString(), 3, 1);
                if (dsv != null && dsv.Tables[0].Rows.Count > 0)
                {
                    lbD1.Text = dsv.Tables[0].Rows[0]["ReceAge_Comm"].ToString();
                    lbEndDate3.Text = ((DateTime)dsv.Tables[0].Rows[0]["ReceAge_EndDate"]).ToString("yyyy-MM-dd");
                    try
                    {
                        lbD1.Text = lbD1.Text.Substring(0, lbD1.Text.IndexOf('.'));
                    }
                    catch
                    {
                        lbD1.Text = "0";
                    }
                }
                else
                    lbD1.Text = "0";
            }
            else
            {
                lbC1.Text = "0";
                lbD1.Text = "0";
            }
        }
        catch
        {
            lbN1.Text = "0";
            lbN2.Text = "0";
            lbC1.Text = "0";
            lbD1.Text = "0";
        }
        //********************************************************************************************************
        try
        {
            if (txtName2.Text != "")
            {
                dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name2"].ToString(), 1, 2);
                //else
                //    dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name2"].ToString(), 1, 2);
                if (dsv != null && dsv.Tables[0].Rows.Count > 0)
                {
                    lbW1.Text = dsv.Tables[0].Rows[0]["ReceAge_Comm"].ToString();
                    lbW2.Text = dsv.Tables[0].Rows[0]["ReceAge_Expire0"].ToString();
                    lbEndDate1.Text = ((DateTime)dsv.Tables[0].Rows[0]["ReceAge_EndDate"]).ToString("yyyy-MM-dd");
                    try
                    {
                        lbW1.Text = lbW1.Text.Substring(0, lbW1.Text.IndexOf('.'));
                    }
                    catch
                    {
                        lbW1.Text = "0";
                    }
                    try
                    {
                        lbW2.Text = lbW2.Text.Substring(0, lbW2.Text.IndexOf('.'));
                    }
                    catch
                    {
                        lbW2.Text = "0";
                    }
                }
                else
                {
                    lbW1.Text = "0";
                    lbW2.Text = "0";
                }
            }
            else
            {
                lbW1.Text = "0";
                lbW2.Text = "0";
            }

            if (txtName2.Text != "")
            {
                dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name2"].ToString(), 2, 2);
                //else
                //    dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name2"].ToString(), 2, 2);
                if (dsv != null && dsv.Tables[0].Rows.Count > 0)
                {
                    lbW3.Text = dsv.Tables[0].Rows[0]["ReceAge_Comm"].ToString();
                    lbEndDate2.Text = ((DateTime)dsv.Tables[0].Rows[0]["ReceAge_EndDate"]).ToString("yyyy-MM-dd");
                    try
                    {
                        lbW3.Text = lbW3.Text.Substring(0, lbW3.Text.IndexOf('.'));
                    }
                    catch
                    {
                        lbW3.Text = "0";
                    }
                }
                else
                    lbW3.Text = "0";

                dsv = sv.fnGetFinReceAge2(dr["OfficeAutomation_Document_UtContract_Name1"].ToString(), 3, 2);
                if (dsv != null && dsv.Tables[0].Rows.Count > 0)
                {
                    lbD2.Text = dsv.Tables[0].Rows[0]["ReceAge_Comm"].ToString();
                    lbEndDate3.Text = ((DateTime)dsv.Tables[0].Rows[0]["ReceAge_EndDate"]).ToString("yyyy-MM-dd");
                    try
                    {
                        lbD2.Text = lbD2.Text.Substring(0, lbD2.Text.IndexOf('.'));
                    }
                    catch
                    {
                        lbD2.Text = "0";
                    }
                }
                else
                    lbD2.Text = "0";
            }
            else
            {
                lbD2.Text = "0";
                lbW3.Text = "0";
            }
        }
        catch
        {
            lbW1.Text = "0";
            lbW2.Text = "0";
            lbW3.Text = "0";
            lbD2.Text = "0";
        }
        if (lbEndDate1.Text == "") lbEndDate1.Text = "-";
        if (lbEndDate2.Text == "") lbEndDate2.Text = "-";
        if (lbEndDate3.Text == "") lbEndDate3.Text = "-";
        //*******************************************************************************************************************
        lbFlange.Text = dr["OfficeAutomation_Document_UtContract_Flange"].ToString();

        DataSet owner = new DataSet();
        DataSet client = new DataSet();
        DataSet EB = new DataSet();
        if (!IsTempSave)
        {
            owner = da_OfficeAutomation_Document_UtContract_Detail_Inherit.SelectByID(ID, 1);
            client = da_OfficeAutomation_Document_UtContract_Detail_Inherit.SelectByID(ID, 2);
            EB = da_OfficeAutomation_Document_UtContract_Detail_Inherit.SelectByID(ID, 3);
        }
        else
        {
            owner.Tables.Add(UtContract_Detail.Tables[0].Select("OfficeAutomation_Document_UtContract_Detail_CommType=1", "OfficeAutomation_Document_UtContract_Detail_OrderBy ASC").CopyToDataTable());
            client.Tables.Add(UtContract_Detail.Tables[0].Select("OfficeAutomation_Document_UtContract_Detail_CommType=2", "OfficeAutomation_Document_UtContract_Detail_OrderBy ASC").CopyToDataTable());
            EB.Tables.Add(UtContract_Detail.Tables[0].Select("OfficeAutomation_Document_UtContract_Detail_CommType=3", "OfficeAutomation_Document_UtContract_Detail_OrderBy ASC").CopyToDataTable());
        }

        //DataSet dsOwner = da_OfficeAutomation_Document_UtContract_Detail_Inherit.SelectByID(ID, 1);
        DataSet dsOwner = owner;
        int ownerDetailCount = 0;
        if (dsOwner.Tables[0].Rows.Count > 0)
        {
            ownerDetailCount = dsOwner.Tables[0].Rows.Count;
        }
        DataSet dsClient = client;
        int clientDetailCount = 0;
        if (dsClient.Tables[0].Rows.Count > 0)
        {
            clientDetailCount = dsClient.Tables[0].Rows.Count;
        }
        DataSet dsEB = EB;
        int EBDetailCount = 0;
        if (dsEB.Tables[0].Rows.Count > 0)
        {
            EBDetailCount = dsEB.Tables[0].Rows.Count;
        }

        DrawDetailTable(ownerDetailCount, clientDetailCount, EBDetailCount);

        for (int n = 0; n < ownerDetailCount; n++)
        {
            dr = dsOwner.Tables[0].Rows[n];

            int i = n + 1;
            if (i == 1)
                ViewState["CC"] = dr["OfficeAutomation_Document_UtContract_Detail_Scale"].ToString();
            SbJs.Append("$('#txtOwnerCommFloatSetNumberStart" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberStart"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatSetNumberEnd" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberEnd"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatMoneyStart" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyStart"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatMoneyEnd" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyEnd"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatScale" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_Scale"] + "');");
            SbJs.Append("$('#txtOwnerCommPublishedScale" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_PublishedScale"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatKind" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind"] + "');");
        }

        //for (int n = 0; n < clientDetailCount; n++)
        //{
        //    dr = dsClient.Tables[0].Rows[n];

        //    int i = n + 1;

        //    SbJs.Append("$('#txtClientCommFloatSetNumberStart" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberStart"] + "');");
        //    SbJs.Append("$('#txtClientCommFloatSetNumberEnd" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberEnd"] + "');");
        //    SbJs.Append("$('#txtClientCommFloatMoneyStart" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyStart"] + "');");
        //    SbJs.Append("$('#txtClientCommFloatMoneyEnd" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyEnd"] + "');");
        //    SbJs.Append("$('#txtClientCommFloatScale" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_Scale"] + "');");
        //    SbJs.Append("$('#txtClientCommPublishedScale" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_PublishedScale"] + "');");
        //}

        for (int n = 0; n < EBDetailCount; n++)
        {
            dr = dsEB.Tables[0].Rows[n];

            int i = n + 1;

            SbJs.Append("$('#txtEBCommFloatSetNumberStart" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberStart"] + "');");
            SbJs.Append("$('#txtEBCommFloatSetNumberEnd" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberEnd"] + "');");
            SbJs.Append("$('#txtEBCommFloatMoneyStart" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyStart"] + "');");
            SbJs.Append("$('#txtEBCommFloatMoneyEnd" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyEnd"] + "');");
            SbJs.Append("$('#txtEBCommFloatScale" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_Scale"] + "');");
            SbJs.Append("$('#txtEBCommPublishedScale" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_PublishedScale"] + "');");
            SbJs.Append("$('#txtEBCommFloatKind" + i + "').val('" + dr["OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind"] + "');");
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

        T_OfficeAutomation_Flow flowso, flowso1;
        flowso = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        try
        {
            flowso1 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2);
            if (flowso1 != null)
            {
                //申请人审核就隐藏申请人审核
                if (flowso1.OfficeAutomation_Flow_Audit)
                {
                    //隐藏申请人
                    trYesIDx1.Visible = false;
                }
            }

        }
        catch (Exception)
        {

        }

        if (flowso != null)
            SbJs.Append("$(\"#OrdinaryC\").show();");

        try
        {
            T_OfficeAutomation_Flow flowsa, flowst, flowsf1, flowsf2, fst3, flowsc; fst3 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2); //M_AddAnother：20150716 黄生其它意见，增加审批人
            flowsa = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 200);
            flowst = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
            flowsf1 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
            flowsf2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF1\").show();");
            if (((drc[0]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID)
                && drc[0]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || ((drc[1]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID)
                && drc[1]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || (EmployeeName == applicant && flowst.OfficeAutomation_Flow_IsAgree == 2) || (fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || (EmployeeName == txtApply.Text && flowst.OfficeAutomation_Flow_IsAgree == 2)
                )
            {
                SbJs.Append("$(\"#trAddAnoF1\").show();");
                btnSignIDx200.Visible = true;
                //20170425 注释
                //if ((!fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName)) && flowsa != null)
                //    btnsSignIDx200.Visible = false; //M_AlAno：20160217 ++
            }



            flowsa = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 210);
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF5\").show();$(\"#trf5\").show();");
            if ((("1865,6189,13398,13776,30792,8536").Contains(EmployeeID)
                && ("李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳").Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2
                && flowsa != null
                )
            {
                SbJs.Append("$(\"#trAddAnoF2\").show();$(\"#trAddAnoF5\").show();$(\"#trf5\").show();");
                btnsSignIDx210.Visible = true;
                btnShouldJumpIDx.Visible = true; //M_JumpPassLawer：20151021
            }
            if ((flowsf2.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID)
                && flowsf2.OfficeAutomation_Flow_Employee.Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2
                && flowsa != null
                )
            {
                SbJs.Append("$(\"#trAddAnoF2\").show();$(\"#trAddAnoF5\").show();$(\"#trf5\").show();");
                btnsSignIDx211.Visible = true;
                btnShouldJumpIDx.Visible = true; //M_JumpPassLawer：20151021
            }

            //判断陈洁丽是否复审，如果复审，则隐藏李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳的复审意见
            flowsc = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 211);
            if (flowsc != null && flowsc.OfficeAutomation_Flow_Audit == false)
            {
                SbJs.Append("$(\"#trAddAnoF2\").show();$(\"#trAddAnoF5\").show();");
            }


            flowsa = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 220);
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

        try
        {
            T_OfficeAutomation_Flow flowsf1;

            //2016-12-19修改 注释掉法律部人审批之后不能上传附件功能

            //2016-11-25 加上了甘桂芳的员工id 85
            //flowsf1 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(MainID, "1865,6189,13398,13776,30792,85");
            //if (flowsf1.OfficeAutomation_Flow_AuditorID != "") //法律部的人开始审批
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
                SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
            }
            try
            {
                if (flowState == "2" && drc[2]["OfficeAutomation_Flow_AuditorID"].ToString() == "") //20141215：M_AlterC
                {
                    GetAllDepartment();
                    btnSAlterC.Visible = true;
                    SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
                }

            }
            catch
            {
            }
            //if (flowState == "3")
            //{
            //    this.btnSave1.Visible = true;
            //}
            if (flowState == "7")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
                IsNewApply = true;
            }
        }

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。(暂未启用)

        //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
        //    btnSignSave.Visible = true;

        #endregion

        //if (EmployeeID == "1865" || EmployeeID == "6189" || EmployeeID == "13398" || EmployeeID == "13776" || EmployeeID == "30792")
        //    SbJs.Append("$(\"#sp004\").show();");
        //if (EmployeeID == "2377")
        //    SbJs.Append("$(\"#sp005\").show();");
        T_OfficeAutomation_Flow flowy;
        flowy = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 14);
        if (flowy != null)
            SbJs.Append("$(\"#tr14\").show();");
        flowy = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
        if (flowy != null)
            SbJs.Append("$(\"#trLaw5\").show();$(\"#tdLaw4\").attr(\"rowspan\",\"2\");");//*-
        flowy = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
        if (flowy != null)
            SbJs.Append("$(\"#trGeneralManager\").show();");
        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                txtApply.Text = EmployeeName;
                SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnUpload\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();");
                SbJs.Append("$(\"#btnPrint\").hide();$(\"#EarnMoney\").hide();$(\"#CouldFlange\").hide();$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF2\").hide();$(\"#trAddAnoF3\").hide();$(\"#trAddAnoF5\").hide();");
                SbJs.Append("</script>");
                //if (DateTime.Parse(lblApplyDate.Text) <= DateTime.Parse("2015-04-16"))
                //{
                //    lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //    InitListControler("", "", "", "", "");
                //}
                //else
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtName1.Text = "";
                txtName2.Text = "";
                txtProjectArea.Text = "";
                txtProjectAddress.Text = "";
                txtReportAddress.Text = "";
                flowState = "1";
                //lbFlange.Text = dr["OfficeAutomation_Document_UtContract_Flange"].ToString();
                btnSAlterC.Visible = false;
                IsNewApply = true;
                MainID = Guid.NewGuid().ToString();
                return;
            }
        }
        catch
        {
            if (isApplicant && !IsTempSave)
                btnReWrite.Visible = true;
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        //ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        //DataRowCollection drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        bool showf = true; //JohnMingle 2016-8-16
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (EmployeeName == "黄轩明" && showf) //M_HideFlows：20150330
            {
                showf = false;
                SbJs.Append("$(\"#trAddAnoF2\").hide();$(\"#trAddAnoF5\").prepend('<td>法律部复审</td>');");
            }
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
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').show();"); //NA_20151110

                flag = false;
            }
            if (drc[i]["OfficeAutomation_Flow_Suggestion"].ToString() != "") //M_Suggestion：20150205
                SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");
            if (i >= 6 && int.Parse(drc[i]["OfficeAutomation_Flow_Idx"].ToString()) >= 8) //M_AddAnother：20150716 黄生其它意见，增加审批人
            {  //M_AlterM：20150826
                SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_AuditDate"].ToString() + "');");
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

        ////如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        //if (flag3)
        //    SbJs.Append("$('#trLogistics').show();$('#trGeneralManager').show();");

        //如果为未审核状态且登入人为申请人，开启编辑按钮
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

    public void DrawDetailTable(int n1, int n2, int n3)
    {
        for (int i = 2; i <= n1; i++)
        {
            SbHtml1.Append("<tr id='trOwner" + i + "'  style=\"border:none;\">");
            SbHtml1.Append("<td  style='border:none;'><input type=\"text\" id=\"txtOwnerCommFloatSetNumberStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtOwnerCommFloatSetNumberEnd" + i + "\" style=\"width:50px\"/>套/<input type=\"text\" id=\"txtOwnerCommFloatMoneyStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtOwnerCommFloatMoneyEnd" + i + "\" style=\"width:50px\"/>元销售额，<input type=\"text\" id=\"txtOwnerCommFloatKind" + i + "\" style=\"width:80px\"/>（填写住宅/公寓/别墅等不同类型）合同代理费<input type=\"text\" id=\"txtOwnerCommFloatScale" + i + "\" style=\"width:50px\"/>%，公布代理费<input type=\"text\" id=\"txtOwnerCommPublishedScale" + i + "\" style=\"width:50px\"/>%</td>");
            SbHtml1.Append("</tr>");
        }
        SbJs.Append("i1=" + n1 + ";");

        //for (int i = 2; i <= n2; i++)
        //{
        //    SbHtml2.Append("<tr id='trClient" + i + "'  style=\"border:none;\">");
        //    SbHtml2.Append("<td  style='border:none;'><input type=\"text\" id=\"txtClientCommFloatSetNumberStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtClientCommFloatSetNumberEnd" + i + "\" style=\"width:50px\"/>套/<input type=\"text\" id=\"txtClientCommFloatMoneyStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtClientCommFloatMoneyEnd" + i + "\" style=\"width:50px\"/>元销售额，合同代理费<input type=\"text\" id=\"txtClientCommFloatScale" + i + "\" style=\"width:50px\"/>%，公布代理费<input type=\"text\" id=\"txtClientCommPublishedScale" + i + "\" style=\"width:50px\"/>%</td>");
        //    SbHtml2.Append("</tr>");
        //}
        SbJs.Append("i2=" + n2 + ";");

        for (int i = 2; i <= n3; i++)
        {
            SbHtml3.Append("<tr id='trEB" + i + "'  style=\"border:none;\">");
            SbHtml3.Append("<td  style='border:none;'><input type=\"text\" id=\"txtEBCommFloatSetNumberStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtEBCommFloatSetNumberEnd" + i + "\" style=\"width:50px\"/>套/<input type=\"text\" id=\"txtEBCommFloatMoneyStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtEBCommFloatMoneyEnd" + i + "\" style=\"width:50px\"/>元销售额，<input type=\"text\" id=\"txtEBCommFloatKind" + i + "\" style=\"width:80px\"/>（填写住宅/公寓/别墅等不同类型）合同代理费<input type=\"text\" id=\"txtEBCommFloatScale" + i + "\" style=\"width:50px\"/>%，公布代理费<input type=\"text\" id=\"txtEBCommPublishedScale" + i + "\" style=\"width:50px\"/>%</td>");
            SbHtml3.Append("</tr>");
        }
        SbJs.Append("i3=" + n3 + ";");
    }

    #endregion

    #region 事件

    #region 按钮点击事件
    /// <summary>
    /// 应收款管理组结佣
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnComm_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        T_OfficeAutomation_Document_UtContract t = da_OfficeAutomation_Document_UtContract_Inherit.GetModel("OfficeAutomation_Document_UtContract_MainID='" + MainID + "'");
        if (t != null)
        {
            t.OfficeAutomation_Document_UtContract_OneFront = this.txtOneFront.Value.Trim();
            t.OfficeAutomation_Document_UtContract_OneAfter = this.txtOneAfter.Value.Trim();
            t.OfficeAutomation_Document_UtContract_TurnFront = this.txtTurnFront.Value.Trim();
            t.OfficeAutomation_Document_UtContract_TurnAfter = this.txtTurnAfter.Value.Trim();
            da_OfficeAutomation_Document_UtContract_Inherit.Edit(t);
            Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 2);//日志，创建流程
            RunJS("alert('保存成功！');window.location='" + Page.Request.Url + "'");
        }
        else
        {
            RunJS("alert('保存失败！请重新打开此申请');window.location='" + Page.Request.Url + "'");
        }
    }
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
        T_OfficeAutomation_Document_UtContract t_OfficeAutomation_Document_UtContract = new T_OfficeAutomation_Document_UtContract();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion


        //if (!string.IsNullOrEmpty(this.txtName1.Text) && !da_OfficeAutomation_Document_UtContract_Inherit.IsProjectNameExist(this.txtName1.Text))
        //{
        //    Alert("物业部曾接盘的项目名称有误！");
        //    return;

        //}
        //if (!string.IsNullOrEmpty(this.txtName2.Text) && !da_OfficeAutomation_Document_UtContract_Inherit.IsProjectNameExist(this.txtName2.Text))
        //{
        //    Alert("项目部曾接盘的项目名称有误！");
        //    return;

        //}
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

        //try
        //{
        for (int i = 0; i <= this.cblDealOfficeType.Items.Count - 1; i++)
        {
            if (this.cblDealOfficeType.Items[i].Selected == true)
            { sOfficeType = sOfficeType + this.cblDealOfficeType.Items[i].Value + "|"; }
        }
        sOfficeType = sOfficeType.Substring(0, sOfficeType.Length - 1);
        //if (MainID == "")
        string flowState = "";
        try
        {
            flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
        }
        catch { }
        if (IsNewApply && flowState != "7")
        {
            #region 新建
            IsNewApply = false;
            //string[] sHRTree;
            //try
            //{
            //    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
            //}
            //catch
            //{
            //    Alert("请正确选择发文部门！");
            //    return;
            //}

            DataSet ds = new DataSet();

            t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
            t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "UtContract" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
            t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 62;

            t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
            t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;



            //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
            t_OfficeAutomation_Document_UtContract = GetModelFromPage(Guid.NewGuid(), true);

            t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
            t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
            t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtName1.Text + txtName2.Text; ;
            t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;
            da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
            da_OfficeAutomation_Document_UtContract_Inherit.Insert(t_OfficeAutomation_Document_UtContract);//插入申请表

            InsertUtContractDetail(t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ID);
            //统筹分佣
            //   InsertDetail(hidDetail.Value, t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ID);
            #region 保存默认流程
            DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            #region 根据默认流程表中的固定环节添加流程
            if (hdEmpID.Value != "" && hdEmpName.Value != "")
            {
                //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                // T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "3");
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = hdEmpID.Value;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = hdEmpName.Value;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }

            MakeLawFlows();
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

            #endregion

            #endregion

            var isChoiceFYQ = this.rdbIsCoopWithECommerce1.Checked;
            #region [是否选择了 1、是，与房友圈签约，客户现场支付，则在审批流增加房友圈审批人 ]
            if (Convert.ToBoolean(isChoiceFYQ))
            {
                //new DA_OfficeAutomation_Flow_Inherit().InsertNewFlow(t_OfficeAutomation_Main.OfficeAutomation_Main_ID, "0111", "黄蕙晶", 14, false);

                //this.lbFYQ_Click(sender, e);
                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                FlowCommonMethod fcm = new FlowCommonMethod();
                string rValue = fcm.AddFlow_FYQ(MainID);
            }
            #endregion

            Common.AddLog(EmployeeID, EmployeeName, 66, new Guid(MainID), 1);//日志，创建申请表
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

            //RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_UtProj_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
            RunJS("var win=window.showModalDialog(\"Apply_UtProj_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
                //更新Detail表
                Update();

                //暂存第一次提交需要上传附件+编辑流程
                if (tempsave)
                {
                    #region 保存默认流程
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                    #region 根据默认流程表中的固定环节添加流程

                    MakeLawFlows();

                    #endregion

                    #endregion
                    RunJS("var win=window.showModalDialog(\"Apply_UtProj_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
        //}
        //catch (Exception ex)
        //{
        //    Alert("保存失败！" + ex.Message);
        //}
    }

    protected void btnTempSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= this.cblDealOfficeType.Items.Count - 1; i++)
        {
            if (this.cblDealOfficeType.Items[i].Selected == true)
            { sOfficeType = sOfficeType + this.cblDealOfficeType.Items[i].Value + "|"; }
        }
        if (sOfficeType != "") { sOfficeType = sOfficeType.Substring(0, sOfficeType.Length - 1); }
        var SerialNumber = "UtContract" + DateTime.Now.ToString("yyyyMMddHHmmssffff");
        var DocumentID = 62;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_UtContract_Inherit UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName, txtDepartment.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }



        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        var UtContract = new T_OfficeAutomation_Document_UtContract();
        var UtContract_Detail = new List<T_OfficeAutomation_Document_UtContract_Detail>();
        ds = UtContract_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            UtContract = GetModelFromPage(Guid.NewGuid(), true);
        }
        else
        {
            var UtContract_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_ID"].ToString();
            UtContract = GetModelFromPage(new Guid(UtContract_ID), true);
        }
        UtContract_Detail = GetUtContractDetail(UtContract.OfficeAutomation_Document_UtContract_ID);
        UtContract_Inherit.HandleBase(UtContract);
        var obj = new DataEntity.PageModel.Apply_UtContract_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;
        obj.UtContract = UtContract;
        obj.UtContract_Detail = UtContract_Detail;
        //暂存数据保存到xml文件中
        var result = new Common().SaveTempSaveFile<DataEntity.PageModel.Apply_UtContract_Detail>(obj, "UtContractDetail", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
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
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        DA_OfficeAutomation_Document_UtContract_Detail_Inherit da_OfficeAutomation_Document_UtContract_Detail_Inherit = new DA_OfficeAutomation_Document_UtContract_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_UtContract_ID"].ToString();

        string flowIDx = "0";
        string signEmployeeName = EmployeeName;
        string signEmployeeId = EmployeeID;

        if (Purview.Contains("OA_ITPower_002"))
        {
            //try
            //{
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
                        signEmployeeId = haveSignPowerEmployee.Split('|')[1]; //NA_20151110
                        break;
                    }
                }
            }

            if (flowIDx == "15" && hdIsAgree.Value == "2") //M_LawAddFlow 20151110
                lbOCDeptm_Click();
            if (flowIDx == "16" && hdIsAgree.Value == "2")
                lbtnAddMaster_Click();

            DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

            bool isSignSuccess = flowIDx == "15" || flowIDx == "8" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

            if (isSignSuccess)
            {
                string[] employnames;
                string email;
                string msnBody, mailBody;

                string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Apply"].ToString();
                string employname;
                string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                string department = drRow["OfficeAutomation_Document_UtContract_Department"].ToString();
                string applyUrl = Page.Request.Url.ToString();
                applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                //通知已审批的人员，邮件中附带申请资料。
                StringBuilder sbMailBody = new StringBuilder();
                sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_UtContract_Apply"]);
                sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_UtContract_Department"]);
                sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_UtContract_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                sbMailBody.Append("<br/><br/>物业部曾接盘的项目名称：" + drRow["OfficeAutomation_Document_UtContract_Name1"]);
                sbMailBody.Append("<br/>项目部曾接盘的项目名称：" + drRow["OfficeAutomation_Document_UtContract_Name2"]);
                sbMailBody.Append("<br/>项目发展商(小业主)：" + drRow["OfficeAutomation_Document_UtContract_Developer"]);
                DA_Dic_OfficeAutomation_DealOfficeType_Operate da_Dic_OfficeAutomation_DealOfficeType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DealOfficeType_Operate();
                sbMailBody.Append("<br/>物业性质：" + da_Dic_OfficeAutomation_DealOfficeType_Operate.SelectNamesByIDs(drRow["OfficeAutomation_Document_UtContract_DealOfficeTypeIDs"].ToString()));
                sbMailBody.Append("<br/>项目所在区域：" + drRow["OfficeAutomation_Document_UtContract_ProjectArea"]);
                sbMailBody.Append("<br/>项目地址：" + drRow["OfficeAutomation_Document_UtContract_txtProjectAddress"]);
                sbMailBody.Append("<br/>区域跟进联系人：" + drRow["OfficeAutomation_Document_UtContract_AreaFollowerContacter"]);
                sbMailBody.Append("<br/>联系电话：" + drRow["OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone"]);
                sbMailBody.Append("<br/>项目情况承接货量" + drRow["OfficeAutomation_Document_UtContract_Square"] + "平方米,共" + drRow["OfficeAutomation_Document_UtContract_SetNumber"] + "套;预计单价" + drRow["OfficeAutomation_Document_UtContract_UnitPrice"] + "元/平方米;货量总金额" + drRow["OfficeAutomation_Document_UtContract_TotalPrice"] + "元");
                sbMailBody.Append("<br/>代理期: " + drRow["OfficeAutomation_Document_UtContract_AgentStartDate"] + "~" + drRow["OfficeAutomation_Document_UtContract_AgentEndDate"] + " 客户保护期: " + drRow["OfficeAutomation_Document_UtContract_ClientGuardStartDate"] + "~" + drRow["OfficeAutomation_Document_UtContract_ClientGuardEndDate"]);
                //sbMailBody.Append("<br/>预估代理期内完成货量" + drRow["OfficeAutomation_Document_UtContract_PreCompleteNumber"] + "套,货量金额" + drRow["OfficeAutomation_Document_UtContract_PreCompleteMoney"] + "元,佣金收入" + drRow["OfficeAutomation_Document_UtContract_PreCompleteComm"] + "元 ");
                sbMailBody.Append("<br/><br/>代理费");
                sbMailBody.Append("<br/>(1)业佣：合同代理费" + drRow["OfficeAutomation_Document_UtContract_OwnerCommFixScale"] + "公布代理费（扣除合作费后实收）" + drRow["OfficeAutomation_Document_UtContract_OwnerCommAgent"]);
                ds = da_OfficeAutomation_Document_UtContract_Detail_Inherit.SelectByID(drRow["OfficeAutomation_Document_UtContract_ID"].ToString(), 1);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    sbMailBody.Append("<br/> 变动收佣，其中");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberStart"] + "至" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberEnd"] + "套/" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyStart"] + "至" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyEnd"] + "元销售额，类型：" + dr["OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind"] + "合同代理费" + dr["OfficeAutomation_Document_UtContract_Detail_Scale"] + "公布代理费" + dr["OfficeAutomation_Document_UtContract_Detail_PublishedScale"]);
                    }
                }
                sbMailBody.Append("<br/>(2)客佣：合同代理费" + drRow["OfficeAutomation_Document_UtContract_ClientCommFixScale"] + "公布代理费（扣除合作费后实收）" + drRow["OfficeAutomation_Document_UtContract_ClientCommAgent"]);
                ds = da_OfficeAutomation_Document_UtContract_Detail_Inherit.SelectByID(drRow["OfficeAutomation_Document_UtContract_ID"].ToString(), 2);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    sbMailBody.Append("<br/> 变动收佣，其中");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberStart"] + "至" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberEnd"] + "套/" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyStart"] + "至" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyEnd"] + "元销售额，合同代理费" + dr["OfficeAutomation_Document_UtContract_Detail_Scale"] + "公布代理费" + dr["OfficeAutomation_Document_UtContract_Detail_PublishedScale"]);
                    }
                }

                sbMailBody.Append("<br/>(3)电商佣：合同代理费" + drRow["OfficeAutomation_Document_UtContract_EBComm"] + "公布代理费（扣除电商费用及合作费后实收）" + drRow["OfficeAutomation_Document_UtContract_EBCommAgent"]);
                ds = da_OfficeAutomation_Document_UtContract_Detail_Inherit.SelectByID(drRow["OfficeAutomation_Document_UtContract_ID"].ToString(), 3);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    sbMailBody.Append("<br/> 变动收佣，其中");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberStart"] + "至" + dr["OfficeAutomation_Document_UtContract_Detail_SetNumberEnd"] + "套/" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyStart"] + "至" + dr["OfficeAutomation_Document_UtContract_Detail_MoneyEnd"] + "元销售额，类型：" + dr["OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind"] + "合同代理费" + dr["OfficeAutomation_Document_UtContract_Detail_Scale"] + "公布代理费" + dr["OfficeAutomation_Document_UtContract_Detail_PublishedScale"]);
                    }
                }

                sbMailBody.Append("<br/>其他详细申请资料请见申请表");

                mailBody = sbMailBody.ToString();

                //DataSet dsFlow2 = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                //DataRowCollection drc2 = dsFlow.Tables[0].Rows;






                #region 推送消息
                DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID);
                if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"].ToString() == "False")
                {
                    WS_ECS.WS_ECS service = new WS_ECS.WS_ECS();
                    T_Dic_Report_CashPrize t_Dic_Report_CashPrize = new T_Dic_Report_CashPrize();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string st, st2;
                    if (flowIDx == "1" || flowIDx == "15" || flowIDx == "16" || (ds.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3" && EmployeeID == "0001"))
                    { //部门主管或黄生审批完成后，把相关信息发送到佣金系统；20141217 
                        ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID);
                        DataRow dr = ds.Tables[0].Rows[0];
                        t_Dic_Report_CashPrize.CashPrize_ID = new Guid(MainID);
                        t_Dic_Report_CashPrize.CashPrize_Num = serialNumber;
                        t_Dic_Report_CashPrize.CashPrize_HaveSingleReward = int.Parse(dr["OfficeAutomation_Document_UtContract_HaveSingleReward"].ToString());
                        //if (dr["OfficeAutomation_Document_UtContract_HaveSingleReward"].ToString() == "2")
                        //    t_Dic_Report_CashPrize.CashPrize_Money = decimal.Parse(dr["OfficeAutomation_Document_UtContract_RewardSignHave"].ToString());
                        if (dr["OfficeAutomation_Document_UtContract_HaveSingleReward"].ToString() == "1")
                            t_Dic_Report_CashPrize.CashPrize_Money = decimal.Parse(dr["OfficeAutomation_Document_UtContract_RewardSignHave"].ToString());
                        else
                            t_Dic_Report_CashPrize.CashPrize_Money = 0;
                        t_Dic_Report_CashPrize.CashPrize_DateBegin = DateTime.Parse(dr["OfficeAutomation_Document_UtContract_AgentStartDate"].ToString());
                        try
                        {
                            t_Dic_Report_CashPrize.CashPrize_DateEnd = DateTime.Parse(dr["OfficeAutomation_Document_UtContract_ClientGuardEndDate"].ToString());
                        }
                        catch
                        {
                            t_Dic_Report_CashPrize.CashPrize_DateEnd = DateTime.Parse(dr["OfficeAutomation_Document_UtContract_AgentEndDate"].ToString());
                        }
                        if (EmployeeID == "0001" && flowIDx != "220")
                            t_Dic_Report_CashPrize.CashPrize_AuditID = int.Parse(hdIsAgree.Value);
                        else if (flowIDx == "220")
                            t_Dic_Report_CashPrize.CashPrize_AuditID = int.Parse(hdIsAgree.Value) + 30;
                        else if (flowIDx == "15")
                            t_Dic_Report_CashPrize.CashPrize_AuditID = int.Parse(hdIsAgree.Value) + 10;
                        else if (flowIDx == "16")
                            t_Dic_Report_CashPrize.CashPrize_AuditID = int.Parse(hdIsAgree.Value) + 10;
                        else
                            t_Dic_Report_CashPrize.CashPrize_AuditID = -1;
                        st = js.Serialize(t_Dic_Report_CashPrize);
                        st2 = service.fnDicReportCashPrize_InsertFromECOA(st);
                    }
                }
                //if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID) || hdIsAgree.Value == "0") //M_FF-Circle：20160203 发送到房友圈
                //{
                //    if (ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Lack"].ToString().Contains("7"))
                //    {
                //        string s = "项目名称：" + (string.IsNullOrEmpty(txtName1.Text) ? txtName2.Text : txtName1.Text)
                //            + "<br/>代理期： " + (string.IsNullOrEmpty(txtAgentStartDate.Text) ? txtAgentStartDate.Text + "～" + txtAgentEndDate.Text + "<br/>" : "无<br/>")
                //            + (flowIDx == "6" ? "董事总经理意见：" : "法律部意见：") + hdSuggestion.Value
                //            ;
                //        FFCircle.PushMessage(hdIsAgree.Value, s);
                //    }
                //}
                #endregion






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

                        //总办4张表(减佣让佣，物业部承接一手项目报备，项目费用，合作费)完成后需抄送给的人:黄筑筠,谢芃,李红梅,张绍欣,黄瑛
                        if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关审核的法律部同事
                        {
                            sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;
                        }
                        //else
                        employname = CommonConst.EMP_GMO_COPYTO_NAME + ",宁伟雄,冯琰,黄洁珍,李粤湘,陈妙桃,钟惠贤,官东升,刘韵";
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
                                Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody + mailBody, msnBody);
                            }
                        }
                    }
                    //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

                    T_OfficeAutomation_Flow flowsf1, flowsf2;
                    flowsf1 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                    flowsf2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                    if (hdIsAgree.Value == "2" && flowsf1.OfficeAutomation_Flow_AuditorID != "") //其它意见，通知法律部
                    {
                        try
                        {
                            string employeeList = "";
                            //employname = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,陈洁丽";
                            if (flowsf2.OfficeAutomation_Flow_AuditorID != "")
                                employname = flowsf1.OfficeAutomation_Flow_Auditor;// + ",陈洁丽";
                            else
                                employname = flowsf1.OfficeAutomation_Flow_Auditor;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "在审批过程中" + signEmployeeName + "发表了其它意见，理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    email = employnames[i];
                                    Common.SendMessageEX(false, email, "关于物业部项目续约申请表的其它意见", msnBody + mailBody, msnBody);

                                    employeeList += employnames[i] + "||";
                                }
                            }
                        }
                        catch
                        {
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

                    try
                    {
                        T_OfficeAutomation_Flow flowsf1, flowsf2;
                        flowsf1 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                        flowsf2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                        if (flowsf1.OfficeAutomation_Flow_AuditorID != "") //法律部审批完
                        {
                            string employeeList = "";
                            //employname = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,陈洁丽";
                            if (flowsf2.OfficeAutomation_Flow_AuditorID != "")
                                employname = flowsf1.OfficeAutomation_Flow_Auditor;// + ",陈洁丽";
                            else
                                employname = flowsf1.OfficeAutomation_Flow_Auditor;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    email = employnames[i];
                                    Common.SendMessageEX(false, email, "请注意，有一份物业部项目续约申请表未通过审批", msnBody + mailBody, msnBody);

                                    employeeList += employnames[i] + "||";
                                }
                            }
                        }
                    }
                    catch
                    {
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
            //}
            //catch
            //{
            //    Alert("审理失败！");
            //}
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
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        //DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        //DataRowCollection drc = dsFlow.Tables[0].Rows;
        string commType = e.CommandName;
        T_OfficeAutomation_Flow flowsf1;
        flowsf1 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
        switch (commType)
        {
            case "Del":
                try
                {
                    if (flowsf1.OfficeAutomation_Flow_AuditorID != "") //法律部的人开始审批
                    {
                        RunJS("alert('因为法律部人员已经审批完毕，所以附件不能删除！');history.go(-1);");
                        break;
                    }
                }
                catch
                {
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

    private T_OfficeAutomation_Document_UtContract GetModelFromPage(Guid UtContractID, bool isn)
    {
        T_OfficeAutomation_Document_UtContract t_OfficeAutomation_Document_UtContract = new T_OfficeAutomation_Document_UtContract();
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ID = UtContractID;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Apply = EmployeeName;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ApplyID = "";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ApplyDate = DateTime.Now;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsDirectContract = hiDirectContract.Value;//是否与该发展商直接签约
        //   t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DirectContractName = "";
        //    t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DirectContractType = "";
        // if ("2".Equals(hiDirectContract.Value))
        //  {
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DirectContractName = txtCorporateName.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DirectContractType = ddlCorporateType.SelectedValue;
        //  }
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DiskSource = ddlDiskSource.SelectedValue;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DealType = ddlDealType.SelectedValue;
        if (sOfficeType != string.Empty)
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DealOfficeTypeIDs = sOfficeType;
        else if (hdDealOfficeType.Value != string.Empty)
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DealOfficeTypeIDs = hdDealOfficeType.Value;
        else
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DealOfficeTypeIDs = "9";

        if (isn)
        {
            DA_OfficeAutomation_Document_UndertakeProj_Inherit da_OfficeAutomation_Document_UndertakeProj_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Inherit();
            DataSet dsp = new DataSet();
            string sp = null, sc = null;
            if (txtName1.Text != "")
            {
                dsp = da_OfficeAutomation_Document_UndertakeProj_Inherit.SelectFlange(txtName1.Text);
                for (int z = 0; z < dsp.Tables[0].Rows.Count; z++)
                {
                    try
                    {
                        sc = "（" + da_OfficeAutomation_Document_UndertakeProj_Inherit.SelectStByDpm(dsp.Tables[0].Rows[z]["Dpms"].ToString()).Tables[0].Rows[0]["AreaName"].ToString() + "）";
                    }
                    catch
                    {
                        sc = null;
                    }
                    if (dsp.Tables[0].Rows[z]["Dpms"].ToString() != txtDepartment.Text)
                        sp += dsp.Tables[0].Rows[z]["Dpms"].ToString() + sc + "，";
                }
                sp = "物业部：" + sp;
            }
            else if (txtName2.Text != "")
            {
                if (txtName2.Text.Contains("（"))
                {
                    txtName2.Text = txtName2.Text.Replace("（", "(");
                }
                if (txtName2.Text.Contains("）"))
                {
                    txtName2.Text = txtName2.Text.Replace("）", ")");
                }

                string sr = txtName2.Text.Remove(txtName2.Text.IndexOf('('));
                dsp = da_OfficeAutomation_Document_UndertakeProj_Inherit.SelectFlange(sr);
                for (int z = 0; z < dsp.Tables[0].Rows.Count; z++)
                {
                    try
                    {
                        sc = "（" + da_OfficeAutomation_Document_UndertakeProj_Inherit.SelectStByDpm(dsp.Tables[0].Rows[z]["Dpms"].ToString()).Tables[0].Rows[0]["AreaName"].ToString() + "）";
                    }
                    catch
                    {
                        sc = null;
                    }
                    if (dsp.Tables[0].Rows[z]["Dpms"].ToString() != txtDepartment.Text)
                        sp += dsp.Tables[0].Rows[z]["Dpms"].ToString() + sc + "，";
                }
                sp = "项目部：" + sp;
            }
            try
            {
                if (sp == "物业部：" || sp == "项目部：" || sp == null)
                    t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Flange = "无";
                else
                    t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Flange = sp.Remove(sp.Length - 1, 1);
            }
            catch
            {
                t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Flange = "无";
            }
        }
        else
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Flange = lbFlange.Text;











        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Name1 = txtName1.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Name2 = txtName2.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Developer = txtDeveloper.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_GroupName = txtGroupName.Text;

        string BaseAgent = "";
        if (cbBaseAgent1.Checked == true)
            BaseAgent += "|1";
        if (cbBaseAgent2.Checked == true)
            BaseAgent += "|2";
        if (cbBaseAgent3.Checked == true)
            BaseAgent += "|3";
        if (cbBaseAgent4.Checked == true)
            BaseAgent += "|4";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_BaseAgent = BaseAgent;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_BaseAgentOther = txtBaseAgentOther.Text;
        if (hdProjectArea.Value != "")
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ProjectArea = hdProjectArea.Value;
        else
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ProjectArea = txtProjectArea.Text;
        //统筹分佣比例
        //   t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_OverallScale = txtOverallScale.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_LastBeginDate = txtLastBeginDate.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_LastEndDate = txtLastEndDate.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_LastSumNum = txtLastSumNum.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Turnover = txtTurnover.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_LastResults = txtLastResults.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CumulativeBeginDate = txtCumulativeBeginDate.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CumulativeEndDate = txtCumulativeEndDate.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CumulativeNum = txtCumulativeNum.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SumTurnover = txtSumTurnover.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CumulativeResults = txtCumulativeResults.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsStree = rdbIsStree1.Checked ? "1" : rdbIsStree2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsMarking = rdbIsMarking1.Checked ? "1" : rdbIsMarking2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsBusiness = rdbIsBusiness1.Checked ? "1" : rdbIsBusiness2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsBackRent = rdbIsBackRent1.Checked ? "1" : rdbIsBackRent2.Checked ? "2" : "0";

        if (hdProjectAddress.Value != "")
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_txtProjectAddress = hdProjectAddress.Value;
        else
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_txtProjectAddress = txtProjectAddress.Text;
        if (hdReportAddress.Value != "")
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_txtReportAddress = hdReportAddress.Value;
        else
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_txtReportAddress = txtReportAddress.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DeveloperContacter = txtDeveloperContacter.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DeveloperContacterPosition = txtDeveloperContacterPosition.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DeveloperContacterPhone = txtDeveloperContacterPhone.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaFollowerContacter = txtAreaFollowerContacter.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition = txtAreaFollowerContacterPosition.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone = txtAreaFollowerContacterPhone.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaCheckDataer = txtAreaCheckDataer.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaCheckDataerCode = txtAreaCheckDataerCode.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaCheckDataerPhone = txtAreaCheckDataerPhone.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Square = txtSquare.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SetNumber = txtSetNumber.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_UnitPrice = txtUnitPrice.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_TotalPrice = txtTotalPrice.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsCoopWithECommerce = rdbIsCoopWithECommerce1.Checked ? "1" : rdbIsCoopWithECommerce2.Checked ? "2" : rdbIsCoopWithECommerce3.Checked ? "3" : rdbIsCoopWithECommerce4.Checked ? "4" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CoopWithE1 = txtCoopWithE1.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CoopWithE2 = txtCoopWithE2.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CoopWithE3 = txtCoopWithE3.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CoopWithE4 = txtCoopWithE4.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CoopWithE5 = txtCoopWithE5.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ECommerceName = txtECommerceName.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ECommerceName2 = txtECommerceName2.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ProjFear = rdbProjFear1.Checked ? "1" : rdbProjFear2.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ProjSum1 = txtProjSum1.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ProjSum2 = txtProjSum2.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ProjSum3 = txtProjSum3.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_OwnerCommFixScale = txtOwnerCommFixScale.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_OwnerCommAgent = txtOwnerCommAgent.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ClientCommFixScale = txtClientCommFixScale.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ClientCommAgent = txtClientCommAgent.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_EBComm = txtEBComm.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_EBCommAgent = txtEBCommAgent.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Remark = txtRemark.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Jubar1 = rdbOwnerCommJump1.Checked ? "1" : rdbOwnerCommJump2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Jubar2 = rdbClientCommJump1.Checked ? "1" : rdbClientCommJump2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Jubar3 = rdbEBCommJump1.Checked ? "1" : rdbEBCommJump2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_HaveSingleReward = rdbHaveSingleReward1.Checked ? "1" : rdbHaveSingleReward2.Checked ? "2" : rdbHaveSingleReward3.Checked ? "3" : rdbHaveSingleReward4.Checked ? "4" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_RewardSignHave = txtRewardSignHave.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AnotherRewardC = txtAnotherRewardC.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DeveloperConditions = txtDeveloperConditions.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaConditions = txtAreaConditions.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_PayRewardWay = rdbPayRewardWay1.Checked ? "1" : rdbPayRewardWay2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsMyPay = rdbIsMyPay1.Checked ? "1" : rdbIsMyPay2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaComfirn = rdbAreaComfirn1.Checked ? "1" : rdbAreaComfirn2.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ReturnBackDate = txtReturnBackDate.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_TermsOfContract = txtTermsOfContract.Text;
        if (txtTermsOfMajorIssues.Text != "")
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_TermsOfMajorIssues = txtTermsOfMajorIssues.Text;
        else
            t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_TermsOfMajorIssues = hdTermsOfMajorIssues.Value;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AgentStartDate = txtAgentStartDate.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AgentEndDate = txtAgentEndDate.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ClientGuardStartDate = txtClientGuardStartDate.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ClientGuardEndDate = txtClientGuardEndDate.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsProjEarlyCommBack = rdbIsProjEarlyCommBack1.Checked ? "1" : rdbIsProjEarlyCommBack2.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_OweCommSum = txtOweCommSum.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaReason = txtAreaReason.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_OrdMoney = txtOrdMoney.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_OrdTaker = txtOrdTaker.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_JOrT = rdbJOrT1.Checked ? "1" : rdbJOrT2.Checked ? "2" : rdbJOrT3.Checked ? "3" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SamePlaceXX1 = txtSamePlaceXX1.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AgencyFee1 = txtAgencyFee1.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsCashPrize1 = rdbIsCashPrize11.Checked ? "1" : rdbIsCashPrize12.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CashPrize1 = txtCashPrize1.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsPFear1 = rdbIsPFear11.Checked ? "1" : rdbIsPFear12.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_PFear1 = txtPFear1.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SamePlaceXX2 = txtSamePlaceXX2.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AgencyFee2 = txtAgencyFee2.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsCashPrize2 = rdbIsCashPrize21.Checked ? "1" : rdbIsCashPrize22.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_CashPrize2 = txtCashPrize2.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsPFear2 = rdbIsPFear21.Checked ? "1" : rdbIsPFear22.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_PFear2 = txtPFear2.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SaleMode = rdbSaleMode1.Checked ? "1" : rdbSaleMode2.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaScale1 = txtAreaScale1.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_MainAreaScale = txtMainAreaScale.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DealAreaScale = txtDealAreaScale.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AreaScale = txtAreaScale.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_MainAreaScale2 = txtMainAreaScale2.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DealAreaScale2 = txtDealAreaScale2.Text;

        string Nre = "";
        if (cbNre1.Checked == true)
            Nre += "|1";
        if (cbNre2.Checked == true)
            Nre += "|2";
        if (cbNre3.Checked == true)
            Nre += "|3";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Nre = Nre;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AnotherCompany = txtAnotherCompany.Text;

        string Rce = "";
        if (cbRce1.Checked == true)
            Rce += "|1";
        if (cbRce2.Checked == true)
            Rce += "|2";
        if (cbRce3.Checked == true)
            Rce += "|3";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Rce = Rce;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_WillBreakUp = txtWillBreakUp.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_BreakUp = txtBreakUp.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_GuaranTime = txtGuaranTime.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Ncommissions = txtNcommissions.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Lack6 = txtLack6.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AS2 = txtAS2.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_MS2 = txtMS2.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_PreCompleteNumber = txtPreCompleteNumber.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_PreCompleteMoney = txtPreCompleteMoney.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_PreCompleteComm = txtPreCompleteComm.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_FtoZ = rdbFtoZ1.Checked ? "1" : rdbFtoZ2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsUploadF = rdbIsUploadF1.Checked ? "1" : rdbIsUploadF2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_OneOrTwo = rdbOneOrTwo1.Checked ? "1" : rdbOneOrTwo2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IsPreSale = rbtIsPreSale1.Checked ? "1" : rbtIsPreSale2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IslimitBuy = rbtIslimitBuy1.Checked ? "1" : rbtIslimitBuy2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_IslimitSign = rbtIslimitSign1.Checked ? "1" : rbtIslimitSign2.Checked ? "2" : "0";

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DealS = rdbDealS1.Checked ? "1" : rdbDealS2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ddlProjectAddress = ddlProjectAddress.SelectedValue;

        string sl = "";
        if (cbLack1.Checked)
            sl += "1";
        if (cbLack2.Checked)
            sl += "2";
        if (cbLack3.Checked)
            sl += "3";
        if (cbLack4.Checked)
            sl += "4";
        if (cbLack5.Checked)
            sl += "5";
        if (cbLack6.Checked)
            sl += "6";
        if (cbLack7.Checked)
            sl += "7";
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Lack = sl;


        #region 2016/10/27 52100 对接CCAI《代理合同信息》表部分字段
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ACName = txtACName.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_QRCommissionRatio = txtQRCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_QRDeadlines = txtQRDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_YCCommissionRatio = txtYCCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_YCDeadlines = txtYCDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_HirePurchase = dllHirePurchase.SelectedValue;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ZFRatio = txtZFRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_FQCommissionRatio = txtFQCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_FQDeadlines = txtFQDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_HousingFund = txtHousingFund.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Hour = txtHour.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_HousDeadlines = txtHousDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Downpayment = ddlDownpayment.SelectedValue;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SFRatio = txtSFRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SFCommissionRatio = txtSFCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SFDeadlines = txtSFDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Loan = ddlLoan.SelectedValue;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_LoanRatio = txtLoanRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_FKCommissionRatio = txtFKCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_FKDeadlines = txtFKDeadlines.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AJ1CommissionRatio = txtAJ1CommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AJ1Deadlines = txtAJ1Deadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AJ2CommissionRatio = txtAJ2CommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AJ2Deadlines = txtAJ2Deadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AJ3CommissionRatio = txtAJ3CommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_AJ3Deadlines = txtAJ3Deadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_BACommissionRatio = txtBACommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_BADeadlines = txtBADeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_YHCommissionRatio = txtYHCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_YHDeadlines = txtYHDeadlines.Text;

        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_RHCommissionRatio = txtRHCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_RHDeadlines = txtRHDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SXCommissionRatio = txtSXCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_SXDeadlines = txtSXDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DLCommissionRatio = txtDLCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DLDeadlines = txtDLDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Evidence = ddlEvidence.SelectedValue;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_YJCommissionRatio = txtYJCommissionRatio.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_YJDeadlines = txtYJDeadlines.Text;
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_Reserve = ddlReserve.SelectedValue;
        #endregion

        #region [2019-08-08 增加两列]
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_ECommerceReason = this.txtECommerceReason.Text.Trim();
        string DiscountMoney = this.txtDiscountMoney.Text.Trim();
        t_OfficeAutomation_Document_UtContract.OfficeAutomation_Document_UtContract_DiscountMoney = string.IsNullOrEmpty(DiscountMoney) == true ? -1 : Convert.ToDecimal(DiscountMoney);
        #endregion

        return t_OfficeAutomation_Document_UtContract;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_UtContract t_OfficeAutomation_Document_UtContract = new T_OfficeAutomation_Document_UtContract();
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();

        //MakeLawFlows();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_ID"].ToString();

        t_OfficeAutomation_Document_UtContract = GetModelFromPage(new Guid(ID), false);
        if (hdEmpID.Value != "" && hdEmpName.Value != "")
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "3");
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = hdEmpID.Value;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = hdEmpName.Value;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }

        string apply = EmployeeName;
        string depname = this.txtDepartment.Text;
        string summary = this.txtName1.Text + this.txtName2.Text;
        string applydate = "";
        string mainid = MainID;

        new DA_OfficeAutomation_Main_Inherit().UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_UtContract_Inherit.Update(t_OfficeAutomation_Document_UtContract);//修改申请表

        DA_OfficeAutomation_Document_UtContract_Detail_Inherit da_OfficeAutomation_Document_UtContract_Detail_Inherit = new DA_OfficeAutomation_Document_UtContract_Detail_Inherit();
        da_OfficeAutomation_Document_UtContract_Detail_Inherit.Delete(ID);
        InsertUtContractDetail(new Guid(ID));
        //统筹分佣
        //   InsertDetail(hidDetail.Value, new Guid(ID));
        Common.AddLog(EmployeeID, EmployeeName, 66, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增申请明细

    /// <summary>
    /// 新增申请明细
    /// </summary>
    /// <param name="gUtContractID"></param>
    private void InsertUtContractDetail(Guid gUtContractID)
    {
        T_OfficeAutomation_Document_UtContract_Detail t_OfficeAutomation_Document_UtContract_Detail;
        DA_OfficeAutomation_Document_UtContract_Detail_Inherit da_OfficeAutomation_Document_UtContract_Detail_Inherit = new DA_OfficeAutomation_Document_UtContract_Detail_Inherit();

        string[] details = Regex.Split(this.hdOwner.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_UtContract_Detail = new T_OfficeAutomation_Document_UtContract_Detail();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MainID = gUtContractID;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_CommType = 1;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberStart = detail[0];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberEnd = detail[1];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyStart = detail[2];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyEnd = detail[3];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind = detail[4];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_Scale = detail[5];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_PublishedScale = detail[6];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OrderBy = i;
            da_OfficeAutomation_Document_UtContract_Detail_Inherit.Insert(t_OfficeAutomation_Document_UtContract_Detail);
        }

        details = Regex.Split(this.hdClient.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_UtContract_Detail = new T_OfficeAutomation_Document_UtContract_Detail();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MainID = gUtContractID;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_CommType = 2;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberStart = detail[0];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberEnd = detail[1];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyStart = detail[2];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyEnd = detail[3];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind = "";
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_Scale = detail[4];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_PublishedScale = detail[5];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OrderBy = i;
            da_OfficeAutomation_Document_UtContract_Detail_Inherit.Insert(t_OfficeAutomation_Document_UtContract_Detail);
        }

        details = Regex.Split(this.hdEB.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_UtContract_Detail = new T_OfficeAutomation_Document_UtContract_Detail();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MainID = gUtContractID;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_CommType = 3;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberStart = detail[0];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberEnd = detail[1];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyStart = detail[2];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyEnd = detail[3];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind = detail[4];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_Scale = detail[5];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_PublishedScale = detail[6];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OrderBy = i;
            da_OfficeAutomation_Document_UtContract_Detail_Inherit.Insert(t_OfficeAutomation_Document_UtContract_Detail);
        }
    }

    private List<T_OfficeAutomation_Document_UtContract_Detail> GetUtContractDetail(Guid gUtContractID)
    {
        T_OfficeAutomation_Document_UtContract_Detail t_OfficeAutomation_Document_UtContract_Detail;
        var list = new List<T_OfficeAutomation_Document_UtContract_Detail>();

        string[] details = Regex.Split(this.hdOwner.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_UtContract_Detail = new T_OfficeAutomation_Document_UtContract_Detail();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MainID = gUtContractID;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_CommType = 1;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberStart = detail[0];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberEnd = detail[1];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyStart = detail[2];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyEnd = detail[3];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind = detail[4];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_Scale = detail[5];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_PublishedScale = detail[6];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OrderBy = i;
            list.Add(t_OfficeAutomation_Document_UtContract_Detail);
        }

        details = Regex.Split(this.hdClient.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_UtContract_Detail = new T_OfficeAutomation_Document_UtContract_Detail();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MainID = gUtContractID;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_CommType = 2;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberStart = detail[0];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberEnd = detail[1];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyStart = detail[2];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyEnd = detail[3];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind = "";
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_Scale = detail[4];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_PublishedScale = detail[5];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OrderBy = i;
            list.Add(t_OfficeAutomation_Document_UtContract_Detail);
        }

        details = Regex.Split(this.hdEB.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_UtContract_Detail = new T_OfficeAutomation_Document_UtContract_Detail();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MainID = gUtContractID;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_CommType = 3;
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberStart = detail[0];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_SetNumberEnd = detail[1];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyStart = detail[2];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_MoneyEnd = detail[3];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OwnerCommFloatKind = detail[4];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_Scale = detail[5];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_PublishedScale = detail[6];
            t_OfficeAutomation_Document_UtContract_Detail.OfficeAutomation_Document_UtContract_Detail_OrderBy = i;
            list.Add(t_OfficeAutomation_Document_UtContract_Detail);
        }
        return list;
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
        Session["FLG_ReWrite67"] = "1";
        Response.Write("<script>window.open('Apply_UtContract_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("物业部项目续约申请表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
            DataSet ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_UtContract_Department"].ToString();
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
                if (i <= 16)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "17,18,19");
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
            DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();


            //if (!string.IsNullOrEmpty(this.txtName1.Text) && !da_OfficeAutomation_Document_UtContract_Inherit.IsProjectNameExist(this.txtName1.Text))
            //{
            //    Alert("物业部曾接盘的项目名称有误！");
            //    return;

            //}
            //if (!string.IsNullOrEmpty(this.txtName2.Text) && !da_OfficeAutomation_Document_UtContract_Inherit.IsProjectNameExist(this.txtName2.Text))
            //{
            //    Alert("项目部曾接盘的项目名称有误！");
            //    return;

            //}

            DataSet ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_UtContract_Department"].ToString();
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
                for (int i = 0; i <= this.cblDealOfficeType.Items.Count - 1; i++)
                {
                    if (this.cblDealOfficeType.Items[i].Selected == true)
                    { sOfficeType = sOfficeType + this.cblDealOfficeType.Items[i].Value + "|"; }
                }
                sOfficeType = sOfficeType.Substring(0, sOfficeType.Length - 1);
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
            DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
            DataSet ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_UtContract_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改 M_Suggestion：20150205
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_UtProj_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    protected void cblDealOfficeType_SelectedIndexChanged(object sender, EventArgs e) //物业性质项事件
    {
        if (!cblDealOfficeType.Items[3].Selected)
        {
            //rdbIsNotMallSplit.Checked = false;
            //rdbIsMallSplit.Checked = false;
            //rdbIsUploadPlan1.Checked = false;
            //rdbIsUploadPlan2.Checked = false;
            //rdbIsMallOpen.Checked = false;
            //rdbIsNotMallOpen.Checked = false;
        }
    }

    protected void Review(int index, string sug) //M_AddAnother：20150716 黄生其它意见，增加审批人
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 2); //M_AlAno：20160217 ++
        string sisa = "2";

        if (index == 200)
        {
            if (rdb211a1.Checked)
                sisa = "1";
            else if (rdb211a2.Checked)
                sisa = "0";
            da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, 220); //M_AlterM：20150826
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        }
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
            //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
            //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = index;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            da_OfficeAutomation_Main_Inherit.SetNullAuditorWhenFlow(MainID);
        }


        flowsh = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 210);
        flowsb = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 220);
        if (flowsh == null && flowsb == null && index != 220)
        {
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 210;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }
        if (index == 210)
        {
            if (rdb210a1.Checked) //M_AlterM：20150820
                sisa = "1";
            else if (rdb210a2.Checked)
                sisa = "0";
            //da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, 210); //M_AlterM：20150826
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        }

        flowsh = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 211);
        if (flowsh == null && flowsb == null && index != 220)
        {
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "2377";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈洁丽";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 211;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }
        if (index == 211)
        {
            if (rdb211a1.Checked)
                sisa = "1";
            else if (rdb211a2.Checked)
                sisa = "0";
            //da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, 211); //M_AlterM：20150826
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        }



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
        if (index == 220)
        {
            if (rdb220a1.Checked)
                sisa = "1";
            else if (rdb220a2.Checked)
                sisa = "0";
            //da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, 220); //M_AlterM：20150826
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        }

        flowsb = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, index);
        string se = null; //M_RA：20151120
        if (index == 220 && flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID))
        {

            if (!flowsb.OfficeAutomation_Flow_Suggestion.Contains("---------------------------------------------------------------------"))
            {
                se = flowsb.OfficeAutomation_Flow_Suggestion
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　　　日期：" + flowsb.OfficeAutomation_Flow_AuditDate + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n"
                    + sug
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　　　日期：" + DateTime.Now.ToString() + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n";
            }
            else
            {
                se = flowsb.OfficeAutomation_Flow_Suggestion
                    + "\r\n"
                    + sug
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　　　日期：" + DateTime.Now.ToString() + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n";
            }
            if (!se.Contains("1900-01-01 0:00:00")) sug = se;
        }
        if (flowsb != null
    && flowsb.OfficeAutomation_Flow_Employee.Contains(fst4.OfficeAutomation_Flow_Employee) && flowsb.OfficeAutomation_Flow_EmployeeID.Contains(fst4.OfficeAutomation_Flow_EmployeeID)
    && fst4.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && fst4.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID)
    && flowsb.OfficeAutomation_Flow_EmployeeID != flowsb.OfficeAutomation_Flow_AuditorID)
            sug = !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_Suggestion) ? flowsb.OfficeAutomation_Flow_Suggestion + "\r\n\r\n" + sug : sug; //M_AlAno：20160217 ++

        if (flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID) && flowsb.OfficeAutomation_Flow_EmployeeID == flowsb.OfficeAutomation_Flow_AuditorID) //M_AlAno：20160217 --u++m //M_RA：20151120
        {
            if (sisa != "0")
                da_OfficeAutomation_Flow_Inherit.UpdateFlowsSuggestionA(MainID, index.ToString(), sug, sisa); //M_AlterM：20150820
            else
            {
                if (index == 210)
                    da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, EmployeeID, EmployeeName + "（复审）", sug, index.ToString(), sisa);
                else
                    da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, EmployeeID, EmployeeName + "（复审）", sug, index.ToString(), sisa);
            }
        }
        else
        {
            if (index == 210)
                da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, EmployeeID, EmployeeName + "（复审）", sug, index.ToString(), sisa);
            else
                da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, EmployeeID, EmployeeName + "（复审）", sug, index.ToString(), sisa);
        }
        if (sisa == "0")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 5); //添加日志，复审
        else if (sisa == "1")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 4); //添加日志，复审
        else
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 6); //添加日志，复审
        RunJS("alert('复审意见已保存！');window.location='" + Page.Request.Url + "'");
    }

    protected void btnShouldJump_Click(object sender, EventArgs e) //M_JumpPassLawer：20151021
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "210,211");
        //DA_OfficeAutomation_Document_UtContract_Detail_Inherit da_OfficeAutomation_Document_UtContract_Detail_Inherit = new DA_OfficeAutomation_Document_UtContract_Detail_Inherit();
        //da_OfficeAutomation_Document_UtContract_Detail_Inherit.DeleteByDpmAndMID(MainID, hdShouldJump.Value);

        string[] employnames;
        string email;
        string msnBody;
        string signEmployeeName = EmployeeName;
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        DataSet ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_UtContract_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
        //通知下一步需要审批的人员
        employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
        if (!employname.Contains(EmployeeName))
        {
            employnames = employname.Split(',');
            for (int i = 0; i < employnames.Length; i++)
            {
                email = employnames[i];
                msnBody = "您好，" + employnames[i] + "：您有" + department
                    + "，编号为" + serialNumber + "的" + documentName + "需要您复审。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                Common.SendMessageEX(true, documentName, email, "请复审", msnBody, msnBody, MainID);
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
                msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody, msnBody);
            }
        }
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，跳过流程
        RunJS("alert('已跳过法律部的复审环节！');window.location='" + Page.Request.Url + "'");
    }

    protected void btnSignIDx200_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        string[] employnames;
        string email;
        string msnBody;
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        DataSet ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_UtContract_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
        //通知已审批的全部人员（黄生除外）
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDInIdx(MainID, "15,16");
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
    protected void btnSignIDx205_Click(object sender, EventArgs e)
    {
        Review(205, txtIDx205.Value);
    }
    protected void btnSignIDx210_Click(object sender, EventArgs e)
    {
        Review(210, txtIDx210.Value);
    }
    protected void btnSignIDx211_Click(object sender, EventArgs e)
    {
        Review(211, txtIDx211.Value);
    }
    protected void btnSignIDx220_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_UtContract_Department"].ToString();
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

    #region 获取物业部楼盘信息
    /// <summary>
    /// 获取物业部楼盘信息 M_20150923
    /// </summary>
    public void GetCCESP(string txt)
    {
        try
        {
            //DA_CCES_Inherit cces = new DA_CCES_Inherit();
            //List<DbTable> list = new List<DbTable>();
            //List<DbTable> listNotLike = new List<DbTable>();
            //list.Clear();
            //list.Add(new DbTable("EstateName", txt));
            //string sJsonIn = cces.fnGetJsonIn(list);
            //string s = cces.fnGetEstateListString(sJsonIn);
            DA_PMS_Project_Main_Inherit da_PMS_Project_Main_Inherit = new DA_PMS_Project_Main_Inherit();
            string s = da_PMS_Project_Main_Inherit.fnGetALLProjectListString();
            if (string.IsNullOrEmpty(s))
                s = "[]";
            //s = s.Remove(s.Length - 1, 1);

            SbCcesp.Append(s);
        }
        catch
        {
            SbCcesp.Append("[]");
        }
    }
    #endregion

    #region 获取项目部楼盘信息
    /// <summary>
    /// 获取项目部楼盘信息 M_20150923
    /// </summary>
    private void GetSecondOR()
    {
        if (Cache["SecondOR"] == null)
        {
            SbJsonSOR.Remove(0, SbJsonSOR.Length);

            DA_SecondOR_Inherit da_SecondOR_Inherit = new DA_SecondOR_Inherit();
            DataSet sor = da_SecondOR_Inherit.SelectSecondOR();

            SbJsonSOR.Append("[");

            foreach (DataRow dr in sor.Tables[0].Rows)
            {
                SbJsonSOR.Append("{\"id\":\"" + dr["projectid"].ToString().Replace("\r", string.Empty).Replace("\n", string.Empty) + "\",\"value\":\"" + dr["projectname"].ToString().Replace("\r", string.Empty).Replace("\n", string.Empty) + "\"},");
            }

            SbJsonSOR.Remove(SbJsonSOR.Length - 1, 1);
            SbJsonSOR.Append("]");
            Cache["SecondOR"] = SbJsonSOR;
        }
        else
            SbJsonSOR = (StringBuilder)Cache["SecondOR"];
    }
    #endregion
    protected void lbNewProj1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Apply_UtNewProj_Detail.aspx");
    }
    protected void rdbJOrT3_CheckedChanged(object sender, EventArgs e)
    {
        //rdbProjFear1.Checked = true;
        //rdbProjFear2.Checked = true;
    }

    protected void MakeLawFlows()
    {
        DA_OfficeAutomation_Document_UndertakeProj_Inherit da_OfficeAutomation_Document_UndertakeProj_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 8);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "51673,28614,54917,5703";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "刘莹仪,蓝晴,张婉晴,谭青华";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 15);
        try
        {
            #region SYSREQ201604251653480003119 修改
            #endregion
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
        }
        catch
        {
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
        }
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
    }
    protected void lbFYQ_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    T_OfficeAutomation_Flow flows;
        //    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        //    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        //    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        //    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 14);
        //    if (flows == null)
        //    {
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0111";
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄蕙晶";
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 14;
        //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        //        RunJS("alert('添加审批流程成功。');window.location='" + Page.Request.Url + "'");

        //    }
        //    else
        //    {
        //        RunJS("alert('已有此审批人。');window.location='" + Page.Request.Url + "'");
        //    }
        //}
        //catch (Exception ee)
        //{
        //    RunJS("alert('添加失败，" + ee.Message + "');window.location='" + Page.Request.Url + "'");
        //}


        FlowCommonMethod fcm = new FlowCommonMethod();
        string rValue = fcm.AddFlow_FYQ(MainID);

        if (rValue == "1")
        {
            RunJS("alert('添加审批流程成功。');window.location='" + Page.Request.Url + "'");
        }
        else if (rValue == "2")
        {
            RunJS("alert('已有此审批人。');window.location='" + Page.Request.Url + "'");
        }
        else
        {
            RunJS("alert('添加失败，" + rValue + "');window.location='" + Page.Request.Url + "'");
        }

    }
    protected void lbCancelFYQ_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow flows;
        try
        {
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 14);
            if (flows != null)
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 14);
                RunJS("alert('取消审批流程成功。');window.location='" + Page.Request.Url + "'");
            }
            else
            {
                RunJS("alert('已取消此审批流程。');window.location='" + Page.Request.Url + "'");
            }
        }
        catch (Exception ee)
        {

            RunJS("alert('取消失败，" + ee.Message + "');window.location='" + Page.Request.Url + "'");
        }

    }
    protected void lbOCDeptm_Click()
    {
        try
        {
            T_OfficeAutomation_Flow flows;
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "2377";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈洁丽";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
                //if (flows.OfficeAutomation_Flow_AuditorID != null)
                //{
                //    string mainid = MainID;
                //    T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

                //    DataSet ds = new DataSet();
                //    string[] employnames;
                //    string email;
                //    string msnBody;
                //    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                //    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                //    string employname;
                //    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                //    DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
                //    ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                //    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Apply"].ToString();
                //    string applyUrl = Page.Request.Url.ToString();
                //    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

                //    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                //                //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                //    //通知下一步需要审批的人员
                //    try
                //    {
                //        employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
                //        employnames = employname.Split(',');
                //        for (int i = 0; i < employnames.Length; i++)
                //        {
                //            email = employnames[i];
                //            msnBody = "您好，" + employnames[i] + "：您有" + txtDepartment.Text
                //                + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                //            Common.SendMessageEX(true, documentName, email, "请审理", msnBody, msnBody);
                //        }
                //    }
                //    catch
                //    {
                //    }
                //    da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
                //}

            }
            //RunJS("alert('添加审批流程成功。');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception ee)
        {
            //RunJS("alert('添加失败，" + ee.Message + "');window.location='" + Page.Request.Url + "'");
        }
    }
    protected void lbtnAddMaster_Click()
    {
        try
        {
            T_OfficeAutomation_Flow flows;
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0001";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄轩明";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 17;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 5);
                //if (flows.OfficeAutomation_Flow_AuditorID != null)
                //{
                //    string mainid = MainID;
                //    T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

                //    DataSet ds = new DataSet();
                //    string[] employnames;
                //    string email;
                //    string msnBody;
                //    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                //    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                //    string employname;
                //    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                //    DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
                //    ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                //    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_Apply"].ToString();
                //    string applyUrl = Page.Request.Url.ToString();
                //    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

                //    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                //                //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                //    //通知下一步需要审批的人员
                //    try
                //    {
                //        employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
                //        employnames = employname.Split(',');
                //        for (int i = 0; i < employnames.Length; i++)
                //        {
                //            email = employnames[i];
                //            msnBody = "您好，" + employnames[i] + "：您有" + txtDepartment.Text
                //                + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                //            Common.SendMessageEX(true, documentName, email, "请审理", msnBody, msnBody);
                //        }
                //    }
                //    catch
                //    {
                //    }
                //    da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
                //}

            }
            //RunJS("alert('添加审批流程成功。');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception ee)
        {
            //RunJS("alert('添加失败，" + ee.Message + "');window.location='" + Page.Request.Url + "'");
        }
    }

    //2016/8/24 52100 项目所在地下拉框数据绑定
    protected void ddlProjectAddressBind(string Selected)
    {
        //ListItem[] list = new ListItem[84];
        //#region 所在地
        //list[0] = new ListItem("从化-街口街道", "CH1"); list[1] = new ListItem("从化-江埔街道", "CH2"); list[2] = new ListItem("从化-城郊街道", "CH3"); list[3] = new ListItem("从化-太平镇", "CH4");
        //list[4] = new ListItem("从化-温泉镇", "CH5"); list[5] = new ListItem("从化-良口镇", "CH6"); list[6] = new ListItem("从化-吕田镇", "CH7"); list[7] = new ListItem("从化-鳌头镇", "CH8");
        ////
        //list[8] = new ListItem("从化-大岭山林场", "CH9"); list[9] = new ListItem("从化-黄龙带水库管理处", "CH10"); list[10] = new ListItem("从化-流溪河林场", "CH11");
        ////
        //list[11] = new ListItem("佛山-禅城区", "FS1"); list[12] = new ListItem("佛山-高明区", "FS2"); list[13] = new ListItem("佛山-南海区", "FS3"); list[14] = new ListItem("佛山-三水区", "FS4");
        //list[15] = new ListItem("佛山-顺德区", "FS5"); list[16] = new ListItem("清远-清城区", "QY1"); list[17] = new ListItem("清远-清新区", "QY2"); list[18] = new ListItem("清远-英德市", "QY3");
        //list[19] = new ListItem("清远-连州市", "QY4"); list[20] = new ListItem("清远-佛冈县", "QY5"); list[21] = new ListItem("清远-阳山县", "QY6"); list[22] = new ListItem("清远-连南瑶族自治县", "QY7");
        //list[23] = new ListItem("清远-连山壮族瑶族自治县", "QY8"); list[24] = new ListItem("肇庆-端州区", "ZQ1"); list[25] = new ListItem("肇庆-鼎湖区", "ZQ2"); list[26] = new ListItem("肇庆-高要区", "ZQ3");
        //list[27] = new ListItem("肇庆-广宁县", "ZQ4"); list[28] = new ListItem("肇庆-怀集县", "ZQ5"); list[29] = new ListItem("肇庆-封开县", "ZQ6"); list[30] = new ListItem("肇庆-肇庆高新区", "ZQ7");
        //list[31] = new ListItem("肇庆-德庆县", "ZQ8"); list[32] = new ListItem("肇庆-四会市", "ZQ9"); list[33] = new ListItem("中山-黄圃镇", "ZS1"); list[34] = new ListItem("中山-南头镇", "ZS2");
        //list[35] = new ListItem("中山-东凤镇", "ZS3"); list[36] = new ListItem("中山-阜沙镇", "ZS4"); list[37] = new ListItem("中山-小榄镇", "ZS5"); list[38] = new ListItem("中山-东升镇", "ZS6");
        //list[39] = new ListItem("中山-古镇镇", "ZS7"); list[40] = new ListItem("中山-横栏镇", "ZS8"); list[41] = new ListItem("中山-三角镇", "ZS9"); list[42] = new ListItem("中山-民众镇", "ZS10");
        //list[43] = new ListItem("中山-南朗镇", "ZS11"); list[44] = new ListItem("中山-港口镇", "ZS12"); list[45] = new ListItem("中山-大涌镇", "ZS13"); list[46] = new ListItem("中山-沙溪镇", "ZS14");
        //list[47] = new ListItem("中山-三乡镇", "ZS15"); list[48] = new ListItem("中山-板芙镇", "ZS16"); list[49] = new ListItem("中山-神湾镇", "ZS17"); list[50] = new ListItem("中山-坦洲镇", "ZS18");
        //list[51] = new ListItem("中山-石岐街道", "ZS19"); list[52] = new ListItem("中山-东区街道", "ZS20"); list[53] = new ListItem("中山-西区街道", "ZS21"); list[54] = new ListItem("中山-南区街道", "ZS22");
        //list[55] = new ListItem("中山-五桂山街道", "ZS23"); list[56] = new ListItem("中山-中山港街道", "ZS24");
        ////
        //list[57] = new ListItem("中山-火炬开发区街道", "ZS25");
        ////
        //list[58] = new ListItem("增城-荔城街道", "ZC1"); list[59] = new ListItem("增城-增江街道", "ZC2");
        //list[60] = new ListItem("增城-朱村街道", "ZC3"); list[61] = new ListItem("增城-永宁街道", "ZC4"); list[62] = new ListItem("增城-中新镇", "ZC5"); list[63] = new ListItem("增城-石滩镇", "ZC6");
        //list[64] = new ListItem("增城-新塘镇", "ZC7"); list[65] = new ListItem("增城-小楼镇", "ZC8"); list[66] = new ListItem("增城-派潭镇", "ZC9"); list[67] = new ListItem("增城-正果镇", "ZC10");
        //list[68] = new ListItem("增城-仙村镇", "ZC11"); list[69] = new ListItem("广州市-天河区", "GZ1"); list[70] = new ListItem("广州市-海珠区", "GZ2"); list[71] = new ListItem("广州市-白云区", "GZ3");
        //list[72] = new ListItem("广州市-荔湾区", "GZ4"); list[73] = new ListItem("广州市-芳村区", "GZ5"); list[74] = new ListItem("广州市-越秀区", "GZ6"); list[75] = new ListItem("广州市-花都区", "GZ7");
        //list[76] = new ListItem("广州市-番禺区", "GZ8"); list[77] = new ListItem("广州市-萝岗区", "GZ9"); list[78] = new ListItem("广州市-南沙区", "GZ10"); list[79] = new ListItem("广州市-黄埔区", "GZ11");
        //list[80] = new ListItem("江门-鹤山市", "JM1");
        ////
        //list[81] = new ListItem("江门-恩平市", "JM2"); list[82] = new ListItem("江门-江海区", "JM3"); list[83] = new ListItem("江门-开平市", "JM4"); list[84] = new ListItem("江门-蓬江区", "JM5");
        //list[85] = new ListItem("江门-台山市", "JM6"); list[86] = new ListItem("江门-新会区", "JM7"); 
        ////
        //list[87] = new ListItem("惠州-博罗县", "HZ1");
        ////
        //list[88] = new ListItem("惠州-惠城区", "HZ2"); list[89] = new ListItem("惠州-惠东县", "HZ3"); list[90] = new ListItem("惠州-惠阳区", "HZ4"); list[91] = new ListItem("惠州-龙门县", "HZ5");
        ////
        //list[92] = new ListItem("阳江-江城区", "YJ1");
        //list[93] = new ListItem("阳江-阳西县", "YJ2");
        //list[94] = new ListItem("阳江-阳东区", "YJ3");
        //list[95] = new ListItem("阳江-阳春市", "YJ4");
        //list[96] = new ListItem("东莞-中堂镇", "DG1");
        //list[97] = new ListItem("阳江市-闸坡镇", "YJ5");
        //#endregion

        DA_OfficeAutomation_AddressArea_Inherit daOfficeAutomation_AddressArea_Inherit = new DA_OfficeAutomation_AddressArea_Inherit();
        IList<T_OfficeAutomation_AddressArea> list = daOfficeAutomation_AddressArea_Inherit.SelectAllList();
        foreach (var model in list)
        {
            if ("YJ5".Equals(model.OfficeAutomation_AddressArea_Code) || "QY9".Equals(model.OfficeAutomation_AddressArea_Code))
            {
                continue;
            }
            ddlProjectAddress.Items.Add(new ListItem(model.OfficeAutomation_AddressArea_ProjectAddress, model.OfficeAutomation_AddressArea_Code));
        }
        //this.ddlProjectAddress.Items.AddRange(list);
        this.ddlProjectAddress.Items.Insert(0, new ListItem("-请选择-", "0"));
        if (Selected != "" && Selected != null)
        {
            this.ddlProjectAddress.SelectedValue = Selected;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    //protected void btnSave1_Click(object sender, EventArgs e )
    //{
    //     DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
    //    DataTable  dt = da_OfficeAutomation_Document_UtContract_Inherit.SelectByMainID(MainID).Tables[0];
    //    try
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            if (dt.Rows[0]["OfficeAutomation_Document_UtContract_ID"] != null)
    //            {
    //                InsertDetail(hidDetail.Value, new Guid(dt.Rows[0]["OfficeAutomation_Document_UtContract_ID"].ToString()));
    //            }
    //            RunJS("alert('保存统筹分佣成功。');window.location='" + Page.Request.Url + "'");
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        RunJS("alert('"+ex.Message+"。');window.location='" + Page.Request.Url + "'");
    //    }
    //}
    //统筹分佣明细表
    private void InsertDetail(string json, Guid DetailID)
    {
        if (!string.IsNullOrEmpty(json))
        {
            var t = new { EmployeeID = "", EmployeeName = "", UnitName = "", Scale = "", BeginDate = "", EndDate = "" };
            var l = Enumerable.Repeat(t, 1).ToList();
            var list = JsonConvert.DeserializeAnonymousType(json, l);

            var bll = new DataAccess.Operate.DA_OfficeAutomation_Document_UtContract_PlanScale_Inherit();
            bll.DelByMainID(DetailID.ToString());//删除
            int num = 1;
            foreach (var i in list)
            {
                DateTime? dt = null;
                if (!string.IsNullOrEmpty(i.EndDate))
                    dt = Convert.ToDateTime(i.EndDate);
                var obj = new T_OfficeAutomation_Document_UtContract_PlanScale
                {
                    OfficeAutomation_Document_UtContract_PlanScale_ID = Guid.NewGuid(),
                    OfficeAutomation_Document_UtContract_PlanScale_MainID = DetailID,
                    OfficeAutomation_Document_UtContract_PlanScale_EmployeeID = i.EmployeeID,
                    OfficeAutomation_Document_UtContract_PlanScale_EmployeeName = i.EmployeeName,
                    OfficeAutomation_Document_UtContract_PlanScale_UnitName = i.UnitName,
                    OfficeAutomation_Document_UtContract_PlanScale_Scale = Convert.ToInt32(i.Scale),
                    OfficeAutomation_Document_UtContract_PlanScale_BeginDate = Convert.ToDateTime(i.BeginDate),

                    OfficeAutomation_Document_UtContract_PlanScale_EndDate = dt,
                    OfficeAutomation_Document_UtContract_PlanScale_AddDate = DateTime.Now,
                    OfficeAutomation_Document_UtContract_PlanScale_Sort = num.ToString(),
                    OfficeAutomation_Document_UtContract_PlanScale_IsDelete = "0"

                };
                num++;
                bll.Add(obj);
            }
            Common.AddLog(EmployeeID, EmployeeName, 88, new Guid(MainID), 1);//日志，修改申请表
            return;
        }
    }
}