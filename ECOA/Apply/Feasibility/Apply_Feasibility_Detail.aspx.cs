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

public partial class Apply_Feasibility_Apply_Feasibility_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml1a = new StringBuilder();
    public StringBuilder SbHtml2a = new StringBuilder();
    public StringBuilder SbHtml3a = new StringBuilder();
    public StringBuilder SbHtml4a = new StringBuilder();
    public StringBuilder SbHtml5a = new StringBuilder();
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbHtml3 = new StringBuilder();
    public StringBuilder SbHtml4 = new StringBuilder();
    public StringBuilder SbHtml5 = new StringBuilder();
    public StringBuilder SbHtml6 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();

    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();

    public string ApplyDisplayPart = "$(\"#btnAddRow1a\").show();$(\"#btnDeleteRow1a\").show();$(\"#btnAddRow2a\").show();$(\"#btnDeleteRow2a\").show();$(\"#btnAddRow3a\").show();$(\"#btnDeleteRow3a\").show();$(\"#btnAddRow4a\").show();$(\"#btnDeleteRow4a\").show();$(\"#btnAddRow5a\").show();$(\"#btnDeleteRow5a\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();$(\"#btnAddRow4\").show();$(\"#btnDeleteRow4\").show();$(\"#btnAddRow5\").show();$(\"#btnDeleteRow5\").show();$(\"#btnAddRow6\").show();$(\"#btnDeleteRow6\").show();$(\".btnaddRow\").show();";
    
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

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["htmltopdf"] == "Yes")  //M_PDF
                {
                    SbJs.Append("<script type=\"text/javascript\">$(\"div .flow\").hide();$(\"#PageBottom\").hide();$('#trtpdf').append('<div class=\"signdate\"></div>');$(\"#ulTabs\").hide();</script>");
                    tpdf = true;
                }
                else
                    SbJs.Append("<script type=\"text/javascript\">$(\"#tabs\").tabs();</script>");
            }
            catch
            {
                SbJs.Append("<script type=\"text/javascript\">$(\"#tabs\").tabs();</script>");
            }
            try
            {
                if (Session["FLG_ReWrite9"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite9"] = null;
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
                InitPage();
           imgDiagram.ImageUrl = "~/Ajax/Feasibility_Diagram.ashx?MainID=" + new Guid(MainID);
        }       
        else
            GetAllDepartment();

        DateTime thisYear = DateTime.Parse(lblApplyDate.Text);
        lblLastYear.Text = thisYear.AddYears(-1).Year.ToString();
        lblThisYear.Text = thisYear.Year.ToString();
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        //btDiagram.Visible = true;
        fuDiagram.Visible = true;
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">$(\"#tabs\").tabs(); " + ApplyDisplayPart);
        DrawDetailTable1a(1);
        DrawDetailTable2a(1);
        DrawDetailTable3a(1);
        DrawDetailTable4a(1);
        DrawDetailTable5a(1);
        DrawDetailTable2(1);
        DrawDetailTable3(1);
        DrawDetailTable4(1);
        DrawDetailTable5(1);
        DrawDetailTable6(1);
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();

        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        DataSet ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(18);
        //DropDownListBind(ddlDepartmentType, ds.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", "0", "--请选择区域--");

        DA_Dic_OfficeAutomation_Majordomo_Operate da_Dic_OfficeAutomation_Majordomo_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_Majordomo_Operate();
        ds = da_Dic_OfficeAutomation_Majordomo_Operate.SelectByDocumentID(18);
        DropDownListBind(ddlMajordomo, ds.Tables[0], "OfficeAutomation_Majordomo_ID", "OfficeAutomation_Majordomo_Name", "0", "-请选择负责人-");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        bool IsTempSave = false;        //是否暂存
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
        DA_OfficeAutomation_Document_Feasibility_Menber_Inherit da_OfficeAutomation_Document_Feasibility_Menber_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Feasibility_Menber_Inherit();
        IsNewApply = false;
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
        DataSet BuildingSituation = new DataSet();
        DataSet DealOfRecord = new DataSet();
        DataSet Competitors = new DataSet();
        DataSet Menber = new DataSet();
        DataSet Statistical = new DataSet();
        DataSet YearRent = new DataSet();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var obj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_Feasibility_Detail>("FeasibilityDetail", "", Mainobj.OfficeAutomation_SerialNumber);
            ds = Common.GetPageDetailDS<T_OfficeAutomation_Document_Feasibility>(obj.Feasibility, Mainobj);
            Menber = Common.GetDataSet<T_OfficeAutomation_Document_Feasibility_Menber>(obj.Menber);
            BuildingSituation = Common.GetDataSet<T_OfficeAutomation_Document_Feasibility_BuildingSituation>(obj.BuildingSituation);
            DealOfRecord = Common.GetDataSet<T_OfficeAutomation_Document_Feasibility_DealOfRecord>(obj.DealOfRecord);
            Competitors = Common.GetDataSet<T_OfficeAutomation_Document_Feasibility_Competitors>(obj.Competitors);
            Statistical = Common.GetDataSet<T_OfficeAutomation_Document_Feasibility_Statistical>(obj.Statistical);
            YearRent = Common.GetDataSet<T_OfficeAutomation_Document_Feasibility_YearRent>(obj.YearRent);
            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID);
        }
        if ("1".Equals(Mainobj.OfficeAutomation_Main_IsGroups))
        {
            this.laIsGroups.InnerText = "(此申请已添加集团审批)";
            DA_OfficeAutomation_Log_Inherit da_OfficeAutomation_Log_Inherit = new DA_OfficeAutomation_Log_Inherit();
            string GroupName = da_OfficeAutomation_Log_Inherit.getGroupOperate(MainID);
            if (!string.IsNullOrEmpty(GroupName))
            {
                hdGroupName.Value = "【" + GroupName + "添加集团审批】";
            }
        }
        //ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_Feasibility_ID"].ToString();
        #region 主表数据
        string applicant = dr["OfficeAutomation_Document_Feasibility_Apply"].ToString();
        ApplyN = applicant;
        lblApply.Text = applicant;
        txtDepartment.Text = dr["OfficeAutomation_Document_Feasibility_Department"].ToString();
        txtApplyID.Text = dr["OfficeAutomation_Document_Feasibility_ApplyID"].ToString();
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_Feasibility_ApplyDate"].ToString()).ToString("yyyy-MM-dd");

        txtBranch.Text = dr["OfficeAutomation_Document_Feasibility_Branch"].ToString();
        txtTurnBranch.Text = dr["OfficeAutomation_Document_Feasibility_TurnBranch"].ToString();
        txtAreaManager.Text = dr["OfficeAutomation_Document_Feasibility_AreaManager"].ToString();
        txtWorkingDepartmentNum.Text = dr["OfficeAutomation_Document_Feasibility_WorkingDepartmentNum"].ToString();
        txtPrebuildDepartmentNum.Text = dr["OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum"].ToString();
        txtContacter.Text = dr["OfficeAutomation_Document_Feasibility_Contacter"].ToString();
        txtContactPhone.Text = dr["OfficeAutomation_Document_Feasibility_ContactPhone"].ToString();
        txtLastYearSituation1.Text = dr["OfficeAutomation_Document_Feasibility_LastYearSituation1"].ToString();
        txtLastYearSituation2.Text = dr["OfficeAutomation_Document_Feasibility_LastYearSituation2"].ToString();
        txtLastYearSituation3.Text = dr["OfficeAutomation_Document_Feasibility_LastYearSituation3"].ToString();
        this.hidLastYearSituation4.Value = dr["OfficeAutomation_Document_Feasibility_LastYearSituation4"].ToString();
        this.hidLastYearSituation5.Value = dr["OfficeAutomation_Document_Feasibility_LastYearSituation5"].ToString();
        this.hidLastYearSituation6.Value = dr["OfficeAutomation_Document_Feasibility_LastYearSituation6"].ToString();
        this.hidLastYearSituation7.Value = dr["OfficeAutomation_Document_Feasibility_LastYearSituation7"].ToString();
        this.hidLastYearSituation8.Value = dr["OfficeAutomation_Document_Feasibility_LastYearSituation8"].ToString();
        this.hidLastYearSituation9.Value = dr["OfficeAutomation_Document_Feasibility_LastYearSituation9"].ToString();
        txtThisYearMonth.Text = dr["OfficeAutomation_Document_Feasibility_ThisYearMonth"].ToString();
        txtThisYearSituation1.Text = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation1"].ToString();
        txtThisYearSituation2.Text = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation2"].ToString();
        txtThisYearSituation3.Text = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation3"].ToString();

        this.hidThisYearSituation4.Value = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation4"].ToString();
        this.hidThisYearSituation5.Value = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation5"].ToString();
        this.hidThisYearSituation6.Value = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation6"].ToString();
        this.hidThisYearSituation7.Value = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation7"].ToString();
        this.hidThisYearSituation8.Value = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation8"].ToString();
        this.hidThisYearSituation9.Value = dr["OfficeAutomation_Document_Feasibility_ThisYearSituation9"].ToString();
        
        txtBusinessSituation1.Text = dr["OfficeAutomation_Document_Feasibility_BusinessSituation1"].ToString();
        txtBusinessSituation2.Text = dr["OfficeAutomation_Document_Feasibility_BusinessSituation2"].ToString();
        txtBusinessSituation3.Text = dr["OfficeAutomation_Document_Feasibility_BusinessSituation3"].ToString();
        txtBusinessSituation4.Text = dr["OfficeAutomation_Document_Feasibility_BusinessSituation4"].ToString();
        txtBusinessSituation5.Text = dr["OfficeAutomation_Document_Feasibility_BusinessSituation5"].ToString();
        txtBusinessSituation6.Text = dr["OfficeAutomation_Document_Feasibility_BusinessSituation6"].ToString();
        this.hidBusinessSituation7.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation7"].ToString();
        this.hidBusinessSituation8.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation8"].ToString();
        this.hidBusinessSituation9.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation9"].ToString();
        this.hidBusinessSituation10.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation10"].ToString();
        this.hidBusinessSituation11.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation11"].ToString();
        this.hidBusinessSituation12.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation12"].ToString();
        this.hidBusinessSituation13.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation13"].ToString();
        this.hidBusinessSituation14.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation14"].ToString();
        this.hidBusinessSituation15.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation15"].ToString();
        this.hidBusinessSituation16.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation16"].ToString();
        this.hidBusinessSituation17.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation17"].ToString();
        this.hidBusinessSituation18.Value = dr["OfficeAutomation_Document_Feasibility_BusinessSituation18"].ToString();
        txtProfitSituation1.Text = dr["OfficeAutomation_Document_Feasibility_ProfitSituation1"].ToString();
        txtProfitSituation2.Text = dr["OfficeAutomation_Document_Feasibility_ProfitSituation2"].ToString();
        txtProfitSituation3.Text = dr["OfficeAutomation_Document_Feasibility_ProfitSituation3"].ToString();
        txtProfitSituation4.Text = dr["OfficeAutomation_Document_Feasibility_ProfitSituation4"].ToString();
        txtProfitSituation5.Text = dr["OfficeAutomation_Document_Feasibility_ProfitSituation5"].ToString();
        txtProfitSituation6.Text = dr["OfficeAutomation_Document_Feasibility_ProfitSituation6"].ToString();
        this.hidProfitSituation7.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation7"].ToString();
        this.hidProfitSituation8.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation8"].ToString();
        this.hidProfitSituation9.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation9"].ToString();
        this.hidProfitSituation10.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation10"].ToString();
        this.hidProfitSituation11.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation11"].ToString();
        this.hidProfitSituation12.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation12"].ToString();
        this.hidProfitSituation13.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation13"].ToString();
        this.hidProfitSituation14.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation14"].ToString();
        this.hidProfitSituation15.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation15"].ToString();
        this.hidProfitSituation16.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation16"].ToString();
        this.hidProfitSituation17.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation17"].ToString();
        this.hidProfitSituation18.Value = dr["OfficeAutomation_Document_Feasibility_ProfitSituation18"].ToString();
        txtAccumulationSituation1.Text = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation1"].ToString();
        txtAccumulationSituation2.Text = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation2"].ToString();
        txtAccumulationSituation3.Text = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation3"].ToString();
        txtAccumulationSituation4.Text = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation4"].ToString();
        txtAccumulationSituation5.Text = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation5"].ToString();
        this.hidAccumulationSituation6.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation6"].ToString();
        this.hidAccumulationSituation7.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation7"].ToString();
        this.hidAccumulationSituation8.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation8"].ToString();
        this.hidAccumulationSituation9.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation9"].ToString();
        this.hidAccumulationSituation10.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation10"].ToString();
        this.hidAccumulationSituation11.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation11"].ToString();
        this.hidAccumulationSituation12.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation12"].ToString();
        this.hidAccumulationSituation13.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation13"].ToString();
        this.hidAccumulationSituation14.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation14"].ToString();
        this.hidAccumulationSituation15.Value = dr["OfficeAutomation_Document_Feasibility_AccumulationSituation15"].ToString();
        txtRecentlyYear.Text = dr["OfficeAutomation_Document_Feasibility_RecentlyYear"].ToString();
        txtRecentlySeason.Text = dr["OfficeAutomation_Document_Feasibility_RecentlySeason"].ToString();
        txtStandardSituation1.Text = dr["OfficeAutomation_Document_Feasibility_StandardSituation1"].ToString();
        txtStandardSituation2.Text = dr["OfficeAutomation_Document_Feasibility_StandardSituation2"].ToString();
        txtStandardSituation3.Text = dr["OfficeAutomation_Document_Feasibility_StandardSituation3"].ToString();
        txtStandardSituation4.Text = dr["OfficeAutomation_Document_Feasibility_StandardSituation4"].ToString();
        txtStandardSituation5.Text = dr["OfficeAutomation_Document_Feasibility_StandardSituation5"].ToString();
        this.hidStandardSituation6.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation6"].ToString();
        this.hidStandardSituation7.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation7"].ToString();
        this.hidStandardSituation8.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation8"].ToString();
        this.hidStandardSituation9.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation9"].ToString();
        this.hidStandardSituation10.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation10"].ToString();
        this.hidStandardSituation11.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation11"].ToString();
        this.hidStandardSituation12.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation12"].ToString();
        this.hidStandardSituation13.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation13"].ToString();
        this.hidStandardSituation14.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation14"].ToString();
        this.hidStandardSituation15.Value = dr["OfficeAutomation_Document_Feasibility_StandardSituation15"].ToString();
        txtRateBeginDate.Text = dr["OfficeAutomation_Document_Feasibility_RateBeginDate"].ToString();
        txtRateEndDate.Text = dr["OfficeAutomation_Document_Feasibility_RateEndDate"].ToString();
        txtAddress.Text = dr["OfficeAutomation_Document_Feasibility_Address"].ToString();
        txtSquare.Text = dr["OfficeAutomation_Document_Feasibility_Square"].ToString();
        txtRentSituation.Text = dr["OfficeAutomation_Document_Feasibility_RentSituation"].ToString();
        txtDeposit.Text = dr["OfficeAutomation_Document_Feasibility_Deposit"].ToString();
        txtSendCoast.Text = dr["OfficeAutomation_Document_Feasibility_SendCoast"].ToString();
        txtPropertySituation.Text = dr["OfficeAutomation_Document_Feasibility_PropertySituation"].ToString();
        txtPowerAddS.Text = dr["OfficeAutomation_Document_Feasibility_PowerAddS"].ToString();
        txtMTelephone.Text = dr["OfficeAutomation_Document_Feasibility_MTelephone"].ToString();
        txtMOptical.Text = dr["OfficeAutomation_Document_Feasibility_MOptical"].ToString();
        txtMonthlyPerformance.Text = dr["OfficeAutomation_Document_Feasibility_MonthlyPerformance"].ToString();
        txtReachDate.Text = dr["OfficeAutomation_Document_Feasibility_ReachDate"].ToString();
        txtTotalCost.Text = dr["OfficeAutomation_Document_Feasibility_TotalCost"].ToString();
        txtNormalCost.Text = dr["OfficeAutomation_Document_Feasibility_NormalCost"].ToString();
        txtMonthProfit.Text = dr["OfficeAutomation_Document_Feasibility_MonthProfit"].ToString();
        txtMonthProfitRDate.Text = dr["OfficeAutomation_Document_Feasibility_MonthProfitRDate"].ToString();
        txtReturnPeriod.Text = dr["OfficeAutomation_Document_Feasibility_ReturnPeriod"].ToString();
        txtBankOnForecast.Text = dr["OfficeAutomation_Document_Feasibility_BankOnForecast"].ToString();
        txtBuildArea.Text = dr["OfficeAutomation_Document_Feasibility_BuildArea"].ToString();
        txtUsableArea.Text = dr["OfficeAutomation_Document_Feasibility_UsableArea"].ToString();
        txtLeaseStartDate.Text = dr["OfficeAutomation_Document_Feasibility_LeaseStartDate"].ToString();
        txtLeaseEndDate.Text = dr["OfficeAutomation_Document_Feasibility_LeaseEndDate"].ToString();
        txtLeaseYears.Text = dr["OfficeAutomation_Document_Feasibility_LeaseYears"].ToString();
        txtLeaseMonths.Text = dr["OfficeAutomation_Document_Feasibility_LeaseMonths"].ToString();
        txtRentFreeStart.Text = dr["OfficeAutomation_Document_Feasibility_RentFreeStart"].ToString();
        txtRentFreeEnd.Text = dr["OfficeAutomation_Document_Feasibility_txtRentFreeEnd"].ToString();
        txtRentFreeCount.Text = dr["OfficeAutomation_Document_Feasibility_RentFreeCount"].ToString();
        txtMonthlyRentNoTax.Text = dr["OfficeAutomation_Document_Feasibility_MonthlyRentNoTax"].ToString();
        txtMonthlyRentIncludeTax.Text = dr["OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax"].ToString();
        txtMothlyTax.Text = dr["OfficeAutomation_Document_Feasibility_MothlyTax"].ToString();
        txtMonthlyTaxRate.Text = dr["OfficeAutomation_Document_Feasibility_MonthlyTaxRate"].ToString();
        txtManageCoast.Text = dr["OfficeAutomation_Document_Feasibility_ManageCoast"].ToString();
        txtManageCoast2.Text = dr["OfficeAutomation_Document_Feasibility_ManageCoast2"].ToString();
        txtWCoast.Text = dr["OfficeAutomation_Document_Feasibility_WCoast"].ToString();
        txtECoast.Text = dr["OfficeAutomation_Document_Feasibility_ECoast"].ToString();
        txtRentDeposit.Text = dr["OfficeAutomation_Document_Feasibility_RentDeposit"].ToString();
        txtWEDeposit.Text = dr["OfficeAutomation_Document_Feasibility_WEDeposit"].ToString();
        txtManageDeposit.Text = dr["OfficeAutomation_Document_Feasibility_ManageDeposit"].ToString();
        txtPackageInvoice.Text = dr["OfficeAutomation_Document_Feasibility_PackageInvoice"].ToString();
        txtNPackageInvoice.Text = dr["OfficeAutomation_Document_Feasibility_NPackageInvoice"].ToString();
        txtPayReason.Text = dr["OfficeAutomation_Document_Feasibility_PayReason"].ToString();
        txtPayObiect.Text = dr["OfficeAutomation_Document_Feasibility_PayObiect"].ToString();
        txtPOPhone.Text = dr["OfficeAutomation_Document_Feasibility_POPhone"].ToString();
        txtCollection.Text = dr["OfficeAutomation_Document_Feasibility_Collection"].ToString();
        txtCollectionPhone.Text = dr["OfficeAutomation_Document_Feasibility_CollectionPhone"].ToString();
        txtRelationship.Text = dr["OfficeAutomation_Document_Feasibility_Relationship"].ToString();
        txtCompleteDate.Text = dr["OfficeAutomation_Document_Feasibility_CompleteDate"].ToString();
        txtFirstRent.Text = dr["OfficeAutomation_Document_Feasibility_FirstRent"].ToString();
        txtLeaseDeposit.Text = dr["OfficeAutomation_Document_Feasibility_LeaseDeposit"].ToString();
        txtFSendCoast.Text = dr["OfficeAutomation_Document_Feasibility_FSendCoast"].ToString();
        txtFWEDeposit.Text = dr["OfficeAutomation_Document_Feasibility_FWEDeposit"].ToString();
        txtFManageDeposit.Text = dr["OfficeAutomation_Document_Feasibility_FManageDeposit"].ToString();
        txtFFMCoaet.Text = dr["OfficeAutomation_Document_Feasibility_FFMCoaet"].ToString();
        txtFirstRentT.Text = dr["OfficeAutomation_Document_Feasibility_FirstRentT"].ToString();
        txtLeaseDepositT.Text = dr["OfficeAutomation_Document_Feasibility_LeaseDepositT"].ToString();
        txtFSendCoastT.Text = dr["OfficeAutomation_Document_Feasibility_FSendCoastT"].ToString();
        txtFWEDepositT.Text = dr["OfficeAutomation_Document_Feasibility_FWEDepositT"].ToString();
        txtFManageDepositT.Text = dr["OfficeAutomation_Document_Feasibility_FManageDepositT"].ToString();
        txtFFMCoaetT.Text = dr["OfficeAutomation_Document_Feasibility_FFMCoaetT"].ToString();
        txtRentName.Text = dr["OfficeAutomation_Document_Feasibility_RentName"].ToString();
        txtNatureTitleO.Text = dr["OfficeAutomation_Document_Feasibility_NatureTitleO"].ToString();
        txtSummary.Text = dr["OfficeAutomation_Document_Feasibility_Summary"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        if (dr["OfficeAutomation_Document_Feasibility_OpenType"].ToString() == "True") //开铺性质
            rdbOpenType1.Checked = true;
        else
            rdbOpenType2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_RentAndTurn"].ToString() == "True") //分租或转租权
            rdbRentAndTurn1.Checked = true;
        else
            rdbRentAndTurn2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_IsRentFree"].ToString() == "1") //免租装修期
            rdbIsRentFree1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_IsRentFree"].ToString() == "2")
            rdbIsRentFree2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_HasTax"].ToString() == "1") //业主是否包发票
            rdbHasTax1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_HasTax"].ToString() == "2")
            rdbHasTax2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_Invoice"].ToString() == "1") //发票提供方
            rdbInvoice1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_Invoice"].ToString() == "2")
            rdbInvoice2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_PayWay"].ToString() == "1") //支付方式
            rdbPayWay1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_PayWay"].ToString() == "2")
            rdbPayWay2.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_PayWay"].ToString() == "3")
            rdbPayWay3.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_StampDuty"].ToString() == "1") //租赁印花税
        {
            rdbStampDuty1.Checked = true;
            txtStampDuty1.Text = dr["OfficeAutomation_Document_Feasibility_StampDuty0"].ToString();
        }
        else if (dr["OfficeAutomation_Document_Feasibility_StampDuty"].ToString() == "2")
        {
            rdbStampDuty2.Checked = true;
            txtStampDuty2.Text = dr["OfficeAutomation_Document_Feasibility_StampDuty0"].ToString();
        }
        if (dr["OfficeAutomation_Document_Feasibility_FirstRentC"].ToString() == "1") //首月租金支付方式
            rdbFirstRentC1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_FirstRentC"].ToString() == "2")
            rdbFirstRentC2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_LeaseDepositC"].ToString() == "1") //租赁按金支付方式
            rdbLeaseDepositC1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_LeaseDepositC"].ToString() == "2")
            rdbLeaseDepositC2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_FSendCoastC"].ToString() == "1") //顶手费支付方式
            rdbFSendCoastC1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_FSendCoastC"].ToString() == "2")
            rdbFSendCoastC2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_FWEDepositC"].ToString() == "1") //水电按金支付方式
            rdbFWEDepositC1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_FWEDepositC"].ToString() == "2")
            rdbFWEDepositC2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_FManageDepositC"].ToString() == "1") //管理费按金支付方式
            rdbFManageDepositC1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_FManageDepositC"].ToString() == "2")
            rdbFManageDepositC2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_FFMCoaetC"].ToString() == "1") //首月印花税支付方式
            rdbFFMCoaetC1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_FFMCoaetC"].ToString() == "2")
            rdbFFMCoaetC2.Checked = true;
        if (dr["OfficeAutomation_Document_Feasibility_RentReal"].ToString() == "1") //出租人是否是业主
        {
            rdbRentReal1.Checked = true;
            txtRentIdentity.Text = dr["OfficeAutomation_Document_Feasibility_RentIdentity"].ToString();
        }
        else if (dr["OfficeAutomation_Document_Feasibility_RentReal"].ToString() == "2")
        {
            rdbRentReal2.Checked = true;
            txtRentMessage.Text = dr["OfficeAutomation_Document_Feasibility_RentMessage"].ToString();
        }
        if (dr["OfficeAutomation_Document_Feasibility_EstateProperties"].ToString() == "1") //房产性质
            rdbEstateProperties1.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_EstateProperties"].ToString() == "2")
            rdbEstateProperties2.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_EstateProperties"].ToString() == "3")
            rdbEstateProperties3.Checked = true;
        else if (dr["OfficeAutomation_Document_Feasibility_EstateProperties"].ToString() == "4")
            rdbEstateProperties4.Checked = true;
        string cbt = dr["OfficeAutomation_Document_Feasibility_NatureTitle"].ToString(); //业权性质
        if (cbt.Contains("1"))
            cbNatureTitle1.Checked = true;
        if (cbt.Contains("2"))
            cbNatureTitle2.Checked = true;
        if (cbt.Contains("3"))
            cbNatureTitle3.Checked = true;
        if (cbt.Contains("4"))
            cbNatureTitle4.Checked = true;
        if (cbt.Contains("5"))
            cbNatureTitle5.Checked = true;

        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(18);
        //DropDownListBind(ddlDepartmentType, ds.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", "0", "--请选择区域--");
        ddlDepartmentType.SelectedValue = dr["OfficeAutomation_Document_Feasibility_lDepartmentType"].ToString();

        DA_Dic_OfficeAutomation_Majordomo_Operate da_Dic_OfficeAutomation_Majordomo_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_Majordomo_Operate();
        ds = da_Dic_OfficeAutomation_Majordomo_Operate.SelectByDocumentID(18);
        DropDownListBind(ddlMajordomo, ds.Tables[0], "OfficeAutomation_Majordomo_ID", "OfficeAutomation_Majordomo_Name", "0", "-请选择负责人-");
        ddlMajordomo.SelectedValue = dr["OfficeAutomation_Document_Feasibility_lMajordomo"].ToString();
        #endregion

        #region 子表
        //清空dataset
        ds.Clear();
        int detailCount = 0;
        if(!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }else{
            DataTable dtnew = Menber.Tables[0].Select("[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '1'", "OfficeAutomation_Document_Feasibility_Menber_AreaManager,OfficeAutomation_Document_Feasibility_Menber_SeniorManager ASC").CopyToDataTable();
            ds.Tables.Clear();
            ds.Tables.Add(dtnew);
            int ab = ds.Tables.Count;
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        
        if (detailCount == 0)
            DrawDetailTable1a(1);
        else
        {
            DrawDetailTable1a(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtSeniorDirector1a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorDirector"] + "');");
                //SbJs.Append("$('#txtRegionalDirector" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_RegionalDirector"] + "');");
                //SbJs.Append("$('#txtRegionalDeputyDirector" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector"] + "');");
                SbJs.Append("$('#txtAreaManager1a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_AreaManager"] + "');");
                SbJs.Append("$('#txtSeniorManager1a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorManager"] + "');");
                SbJs.Append("$('#txtUpperManager1a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_UpperManager"] + "');");
                SbJs.Append("$('#txtbusinessManager1a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_businessManager"] + "');");
                SbJs.Append("$('#txtName1a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Name"] + "');");
                SbJs.Append("$('#txtNum1a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Num"] + "');");
            }
        }

        //清空dataset
        ds.Clear();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID2(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds.Tables.Clear();
            ds.Tables.Add(Menber.Tables[0].Select("[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '2'", "OfficeAutomation_Document_Feasibility_Menber_AreaManager,OfficeAutomation_Document_Feasibility_Menber_SeniorManager ASC").CopyToDataTable());
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID2(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable2a(1);
        else
        {
            DrawDetailTable2a(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtAreaManager2a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_AreaManager"] + "');");
                SbJs.Append("$('#txtSeniorDirector2a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorDirector"] + "');");
                SbJs.Append("$('#txtSeniorManager2a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorManager"] + "');");
                SbJs.Append("$('#txtUpperManager2a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_UpperManager"] + "');");
                SbJs.Append("$('#txtbusinessManager2a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_businessManager"] + "');");
                SbJs.Append("$('#txtName2a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Name"] + "');");
                SbJs.Append("$('#txtNum2a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Num"] + "');");
            }
        }

        //清空dataset
        ds.Clear();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID3(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds.Tables.Clear();
            ds.Tables.Add(Menber.Tables[0].Select("[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '3'", "OfficeAutomation_Document_Feasibility_Menber_AreaManager,OfficeAutomation_Document_Feasibility_Menber_SeniorManager ASC").CopyToDataTable());
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID3(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable3a(1);
        else
        {
            DrawDetailTable3a(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtAreaManager3a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_AreaManager"] + "');");
                SbJs.Append("$('#txtSeniorDirector3a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorDirector"] + "');");
                SbJs.Append("$('#txtSeniorManager3a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorManager"] + "');");
                SbJs.Append("$('#txtUpperManager3a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_UpperManager"] + "');");
                SbJs.Append("$('#txtbusinessManager3a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_businessManager"] + "');");
                SbJs.Append("$('#txtName3a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Name"] + "');");
                SbJs.Append("$('#txtNum3a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Num"] + "');");
            }
        }
        //清空dataset
        ds.Clear();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID4(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds.Tables.Clear();
            ds.Tables.Add(Menber.Tables[0].Select("[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '4'", "OfficeAutomation_Document_Feasibility_Menber_AreaManager,OfficeAutomation_Document_Feasibility_Menber_SeniorManager ASC").CopyToDataTable());
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID4(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable4a(1);
        else
        {
            DrawDetailTable4a(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtAreaManager4a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_AreaManager"] + "');");
                SbJs.Append("$('#txtSeniorDirector4a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorDirector"] + "');");
                SbJs.Append("$('#txtSeniorManager4a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorManager"] + "');");
                SbJs.Append("$('#txtUpperManager4a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_UpperManager"] + "');");
                SbJs.Append("$('#txtbusinessManager4a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_businessManager"] + "');");
                SbJs.Append("$('#txtName4a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Name"] + "');");
                SbJs.Append("$('#txtNum4a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Num"] + "');");
            }
        }
        //清空dataset
        ds.Clear();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID5(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds.Tables.Clear();
            ds.Tables.Add(Menber.Tables[0].Select("[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '5'", "OfficeAutomation_Document_Feasibility_Menber_AreaManager,OfficeAutomation_Document_Feasibility_Menber_SeniorManager ASC").CopyToDataTable());
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.SelectByID5(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable5a(1);
        else
        {
            DrawDetailTable5a(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtAreaManager5a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_AreaManager"] + "');");
                SbJs.Append("$('#txtSeniorDirector5a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorDirector"] + "');");
                SbJs.Append("$('#txtSeniorManager5a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_SeniorManager"] + "');");
                SbJs.Append("$('#txtUpperManager5a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_UpperManager"] + "');");
                SbJs.Append("$('#txtbusinessManager5a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_businessManager"] + "');");
                SbJs.Append("$('#txtName5a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Name"] + "');");
                SbJs.Append("$('#txtNum5a" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Menber_Num"] + "');");
            }
        }
















        DA_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit da_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit.SelectByID(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds = BuildingSituation;
            if ( ds!=null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit.SelectByID(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable2(1);
        else
        {
            DrawDetailTable2(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtBuildingName" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName"] + "');");
                SbJs.Append("$('#txtCsell" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_BuildingSituation_Csell"] + "');");
                SbJs.Append("$('#txtMainSquare" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare"] + "');");
                SbJs.Append("$('#txtAvarageCoast" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast"] + "');");
                SbJs.Append("$('#rdbIsMain" + i + (dr["OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
            }
        }

        DA_OfficeAutomation_Document_Feasibility_Competitors_Inherit da_OfficeAutomation_Document_Feasibility_Competitors_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Feasibility_Competitors_Inherit();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_Competitors_Inherit.SelectByID(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds = Competitors;
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_Competitors_Inherit.SelectByID(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable3(1);
        else
        {
            DrawDetailTable3(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtBusinessName" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Competitors_BusinessName"] + "');");
                SbJs.Append("$('#txtWitchBranch" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Competitors_WitchBranch"] + "');");
                SbJs.Append("$('#txtSetUpTime" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Competitors_SetUpTime"] + "');");
                SbJs.Append("$('#txtResults" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Competitors_Results"] + "');");
            }
        }

        DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit da_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit.SelectByID(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds = DealOfRecord;
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit.SelectByID(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable4(1);
        else
        {
            DrawDetailTable4(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtWhatBuding" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding"] + "');");
                SbJs.Append("$('#txtDealBeginDate" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate"] + "');");
                SbJs.Append("$('#txtDealEndDate" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate"] + "');");
                SbJs.Append("$('#txtSumGet" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet"] + "');");
                SbJs.Append("$('#txtSumRent" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent"] + "');");
            }
        }

        DA_OfficeAutomation_Document_Feasibility_Statistical_Inherit da_OfficeAutomation_Document_Feasibility_Statistical_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Feasibility_Statistical_Inherit();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_Statistical_Inherit.SelectByID(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds = Statistical;
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_Statistical_Inherit.SelectByID(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable5(1);
        else
        {
            DrawDetailTable5(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtBname" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_Bname"] + "');");
                SbJs.Append("$('#txtGzspsNum" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_GzspsNum"] + "');");
                SbJs.Append("$('#txtGzspsRate" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_GzspsRate"] + "');");
                SbJs.Append("$('#txtRichNum" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_RichNum"] + "');");
                SbJs.Append("$('#txtRichRate" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_RichRate"] + "');");
                SbJs.Append("$('#txtEveryNum" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_EveryNum"] + "');");
                SbJs.Append("$('#txtEveryRate" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_EveryRate"] + "');");
                SbJs.Append("$('#txtYuFengNum" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_YuFengNum"] + "');");
                SbJs.Append("$('#txtYuFengRate" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_YuFengRate"] + "');");
                SbJs.Append("$('#txtOtherNum" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_OtherNum"] + "');");
                SbJs.Append("$('#txtOtherRate" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_OtherRate"] + "');");
                SbJs.Append("$('#txtFreeNum" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_FreeNum"] + "');");
                SbJs.Append("$('#txtFreeRate" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_FreeRate"] + "');");
                SbJs.Append("$('#txtAllSum" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_Statistical_AllSum"] + "');");
            }
        }

        DA_OfficeAutomation_Document_Feasibility_YearRent_Inherit da_OfficeAutomation_Document_Feasibility_YearRent_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Feasibility_YearRent_Inherit();
        detailCount = 0;
        if (!IsTempSave)
        {
            ds = da_OfficeAutomation_Document_Feasibility_YearRent_Inherit.SelectByID(ID);
            detailCount = ds.Tables[0].Rows.Count;
        }
        else
        {
            ds = YearRent;
            if (ds != null && ds.Tables[0].Rows.Count > 0) detailCount = ds.Tables[0].Rows.Count;
        }
        //ds = da_OfficeAutomation_Document_Feasibility_YearRent_Inherit.SelectByID(ID);
        //detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable6(1);
        else
        {
            DrawDetailTable6(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;
                SbJs.Append("$('#txtYearNo" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_YearRent_YearNo"] + "');");
                SbJs.Append("$('#txtNoTaxRent" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent"] + "');");
                SbJs.Append("$('#txtHasTaxRent" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent"] + "');");
                SbJs.Append("$('#txtRentCoast" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_YearRent_RentCoast"] + "');");
                SbJs.Append("$('#txtRateOfAdd" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd"] + "');");
                SbJs.Append("$('#txtRentOfAdd" + i + "').val('" + dr["OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd"] + "');");
            }
        }
        #endregion
        LbAddress.Text = txtAddress.Text;
        LbName.Text = txtBranch.Text;
        lbContacter.Text = txtContacter.Text;
        ContactPhone.Text = txtContactPhone.Text;
        

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

            try
            {
                //2016-12-19修改 注释掉法律部人审批之后不能上传附件功能

                //if (drc[7]["OfficeAutomation_Flow_AuditorID"].ToString() != "")// && EmployeeID != "23514" && EmployeeID != "10054") //法律部的人开始审批
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
                if (flowState == "1" || flowState=="7")
                {
                    GetAllDepartment();
                    btnSave.Visible = true;
                    btDiagram.Visible = true;
                    fuDiagram.Visible = true;
                    SbJs.Append(ApplyDisplayPart);
                }
                if (flowState == "2") //20141215：M_AlterC
                {
                    GetAllDepartment();
                    btnSAlterC.Visible = true;
                    btDiagram.Visible = true;
                    fuDiagram.Visible = true;
                    SbJs.Append(ApplyDisplayPart);
                }
            }
            try //M_AddAnother：20150716 黄生其它意见，增加审批人
            {
                DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
                DataSet dsFlow2 = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
                DataRowCollection drcz = dsFlow2.Tables[0].Rows;
                T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 3);
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
            if (EmployeeName == "叶凤霞" || EmployeeName == "黄洁莹")
        {
            SbJs.Append("$(\"#btnUpload\").show();");
        }

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();$(\"#tabs\").tabs();");
                SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
                SbJs.Append("</script>");
                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                btDiagram.Visible = false;
                fuDiagram.Visible = true;
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                flowState = "1";
                btnSAlterC.Visible = false;
                IsNewApply = true;
                MainID = Guid.NewGuid().ToString();
                return;
            }
        }
        catch
        {
            if (isApplicant && !IsTempSave)
                btnReWrite.Visible = true; //*-+
        }

        #region 登录人为特定的帐号，且流程为完成状态时，标识留档按钮开启。

        if ((EmployeeID == "8258" || EmployeeID == "34498" || EmployeeID == "18788") && flowState == "3") //M_Remark：Win 20151109
            btnSignSave.Visible = true;

        #endregion

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
        bool showf = true; //M_HideFlows：20150330
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (EmployeeName == "黄轩明" && showf) //M_HideFlows：20150330
            {
                showf = false;
                SbJs.Append("$(\"#trShowFlow4\").hide();$(\"#trShowFlow5\").prepend('<td>财务部</td>');");
                SbJs.Append("$(\"#trShowFlow6\").hide();$(\"#trShowFlow7\").prepend('<td>人力资源部</td>');");
                SbJs.Append("$(\"#trShowFlow8\").hide();$(\"#trShowFlow9\").prepend('<td>法律部</td>');");
                SbJs.Append("$(\"#trShowFlow10\").hide();$(\"#trShowFlow11\").prepend('<td>外联部</td>');");
                SbJs.Append("$(\"#trShowFlow12\").hide();$(\"#trShowFlow13\").prepend('<td>行政部</td>');");
                SbJs.Append("$(\"#trShowFlow14\").hide();$(\"#trLogistics2\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
                SbJs.Append("$(\"#tlsc1\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            }

            //if (curidx == "8")
            //    flag3 = true;
            if ("1000".Equals(curidx))//显示集团审核总经办
            {
                SbJs.Append("$(\"#trGeneralGroups\").show();");
            }
            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                if ("1000".Equals(curidx))
                {
                    SbFlow.Append("auditing\">待集团审理");
                }
                else{
                    SbFlow.Append("auditing\">待" + curemp + "审理");
                }
               

                flag2 = false;

                if (curemp.Contains(EmployeeName))
                {
                    switch (curidx)
                    {
                        //case "6":
                        //    //ckbAddIDx7.Visible = true;
                        //    break;
                        case "11":
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
                {
                    if ("1000".Equals(curidx))
                    {
                        SbFlow.Append("other\">" + "集团已完成审理");
                    }
                    else
                    {
                        SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Auditor"] + "已完成审理");
                    }
                }
                    
                else
                {
                    if ("1000".Equals(curidx))
                    {
                        SbFlow.Append("other\">" + "集团");
                    }
                    else
                    {
                        SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Employee"]);
                    }
                   
                }
                   
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

            if (i >= 2 && int.Parse(drc[i]["OfficeAutomation_Flow_Idx"].ToString()) >= 200) //M_AddAnother：20150716 黄生其它意见，增加审批人
            {
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

        T_OfficeAutomation_Flow flows;//789
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        if (flows != null)
            SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

        //if (EmployeeID == "10054" || EmployeeID == "34498") //M_WinnEnd：20150204
        //    btnWillEnd.Visible = true;

        //20170206修改  注释Emma的审批
        //if (EmployeeName == "张绍欣") //M_EmmaJump：20160118
        //    btnShouldJumpIDxEmma.Visible = true;

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(MainID, "0001");
        if (flows == null)
            SbJs.Append("$('#trGeneralManager').hide();$('#tlsc2').hide();"); //trManager1 trGeneralManager

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

    public void DrawDetailTable1a(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml1a.Append("<tr id='trDetail1a" + i + "'>");
            //SbHtml1a.Append("     <td><input type=\"hidden\" id=\"txtAreaManager" + i + "\"  value=\""+i+"\" /><textarea id=\"txtbusinessManager" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml1a.Append("     <td><span id=\"txtAreaManager1a" + i + "\" style=\"display:none;\">" + i + "</span><textarea id=\"txtSeniorDirector1a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml1a.Append("     <td><textarea id=\"txtbusinessManager1a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml1a.Append("     <td><textarea id=\"txtName1a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml1a.Append("     <td><textarea id=\"txtNum1a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml1a.Append("     <td><textarea id=\"txtUpperManager1a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml1a.Append("</tr>");
        }
        SbJs.Append("$(\"#ros1a\").attr(\"rowspan\","+ n+1+"); i1a=" + n + ";");
    }

    public void DrawDetailTable2a(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml2a.Append("<tr id='trDetail2a" + i + "'>");
            SbHtml2a.Append("     <td><span id=\"txtAreaManager2a" + i + "\" style=\"display:none;\">" + i + "</span><textarea id=\"txtSeniorDirector2a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml2a.Append("     <td><textarea id=\"txtbusinessManager2a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml2a.Append("     <td><textarea id=\"txtName2a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml2a.Append("     <td><textarea id=\"txtNum2a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml2a.Append("     <td><textarea id=\"txtUpperManager2a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml2a.Append("</tr>");
        }
        SbJs.Append("$(\"#ros2a\").attr(\"rowspan\"," + n + 1 + "); i2a=" + n + ";");
    }

    public void DrawDetailTable3a(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml3a.Append("<tr id='trDetail3a" + i + "'>");
            SbHtml3a.Append("     <td><span id=\"txtAreaManager3a" + i + "\" style=\"display:none;\">" + i + "</span><textarea id=\"txtSeniorDirector3a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml3a.Append("     <td><textarea id=\"txtbusinessManager3a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml3a.Append("     <td><textarea id=\"txtName3a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml3a.Append("     <td><textarea id=\"txtNum3a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml3a.Append("     <td><textarea id=\"txtUpperManager3a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml3a.Append("</tr>");
        }
        SbJs.Append("$(\"#ros3a\").attr(\"rowspan\"," + n + 1 + "); i3a=" + n + ";");
    }
    public void DrawDetailTable4a(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml4a.Append("<tr id='trDetail4a" + i + "'>");
            SbHtml4a.Append("     <td><span id=\"txtAreaManager4a" + i + "\" style=\"display:none;\">" + i + "</span><textarea id=\"txtSeniorDirector4a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml4a.Append("     <td><textarea id=\"txtbusinessManager4a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml4a.Append("     <td><textarea id=\"txtName4a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml4a.Append("     <td><textarea id=\"txtNum4a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml4a.Append("     <td><textarea id=\"txtUpperManager4a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml4a.Append("</tr>");
        }
        SbJs.Append("$(\"#ros4a\").attr(\"rowspan\"," + n + 1 + "); i4a=" + n + ";");
    }
    public void DrawDetailTable5a(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml5a.Append("<tr id='trDetail5a" + i + "'>");
            SbHtml5a.Append("     <td><span id=\"txtAreaManager5a" + i + "\" style=\"display:none;\">" + i + "</span><textarea id=\"txtSeniorDirector5a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml5a.Append("     <td><textarea id=\"txtbusinessManager5a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml5a.Append("     <td><textarea id=\"txtName5a" + i + "\" style=\"width:70px\"/></textarea></td>");
            SbHtml5a.Append("     <td><textarea id=\"txtNum5a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml5a.Append("     <td><textarea id=\"txtUpperManager5a" + i + "\" style=\"width:140px\"/></textarea></td>");
            SbHtml5a.Append("</tr>");
        }
        SbJs.Append("$(\"#ros5a\").attr(\"rowspan\"," + n + 1 + "); i5a=" + n + ";");
    }

    public void DrawDetailTable2(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml2.Append("<tr id='trDetail2" + i + "'>");
            SbHtml2.Append("     <td><input type=\"text\" id=\"txtBuildingName" + i + "\" style=\"width:100px\"/></td>");
            SbHtml2.Append("     <td><input type=\"text\" id=\"txtCsell" + i + "\" style=\"width:100px\"/></td>");
            SbHtml2.Append("     <td><input type=\"text\" id=\"txtMainSquare" + i + "\" style=\"width:100px\"/></td>");
            SbHtml2.Append("     <td><input type=\"text\" id=\"txtAvarageCoast" + i + "\" style=\"width:100px\"/></td>");
            SbHtml2.Append("     <td><input type=\"radio\" id='rdbIsMain" + i + "1' name='IsMain" + i + "' /><label for='rdbIsMain" + i + "1'>是</label><input type=\"radio\" id='rdbIsMain" + i + "0' name='IsMain" + i + "' /><label for='rdbIsMain" + i + "0'>否</label></td>");
            SbHtml2.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable3(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml3.Append("<tr id='trDetail3" + i + "'>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtBusinessName" + i + "\" style=\"width:150px\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtWitchBranch" + i + "\" style=\"width:150px\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtSetUpTime" + i + "\" style=\"width:80px\"/></td>");
            SbHtml3.Append("     <td><input type=\"text\" id=\"txtResults" + i + "\" style=\"width:100px\"/></td>");
            SbHtml3.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable4(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml4.Append("<tr id='trDetail4" + i + "'>");
            SbHtml4.Append("     <td><input type=\"text\" id=\"txtWhatBuding" + i + "\" style=\"width:150px\"/></td>");
            SbHtml4.Append("     <td><input type=\"text\" id=\"txtDealBeginDate" + i + "\" style=\"width:80px\"/>～<input type=\"text\" id=\"txtDealEndDate" + i + "\" style=\"width:80px\"/></td>");
            SbHtml4.Append("     <td><input type=\"text\" id=\"txtSumGet" + i + "\" style=\"width:100px\"/></td>");
            SbHtml4.Append("     <td><input type=\"text\" id=\"txtSumRent" + i + "\" style=\"width:100px\"/></td>");
            SbHtml4.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable5(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml5.Append("<tr id='trDetail5" + i + "' class='tb5tr'>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtBname" + i + "\" style=\"width:100px\"/></td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtGzspsNum" + i + "\" style=\"width:30px\" onblur='Sum()'/></td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtGzspsRate" + i + "\" style=\"width:35px\"/>%</td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtRichNum" + i + "\" style=\"width:30px\" onblur='Sum()'/></td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtRichRate" + i + "\" style=\"width:35px\"/>%</td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtEveryNum" + i + "\" style=\"width:30px\" onblur='Sum()'/></td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtEveryRate" + i + "\" style=\"width:35px\"/>%</td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtYuFengNum" + i + "\" style=\"width:30px\" onblur='Sum()'/></td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtYuFengRate" + i + "\" style=\"width:35px\"/>%</td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtOtherNum" + i + "\" style=\"width:30px\" onblur='Sum()'/></td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtOtherRate" + i + "\" style=\"width:35px\"/>%</td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtFreeNum" + i + "\" style=\"width:30px\" onblur='Sum()'/></td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtFreeRate" + i + "\" style=\"width:35px\"/>%</td>");
            SbHtml5.Append("     <td><input type=\"text\" id=\"txtAllSum" + i + "\" style=\"width:35px\"/></td>");
            SbHtml5.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable6(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml6.Append("<tr id='trDetail6" + i + "'>");
            SbHtml6.Append("     <td>第<input type=\"text\" id=\"txtYearNo" + i + "\" style='width:40px'/>年</td>");
            SbHtml6.Append("     <td><input type=\"text\" id=\"txtNoTaxRent" + i + "\" class=\"pinput\"/></td>");
            SbHtml6.Append("     <td><input type=\"text\" id=\"txtHasTaxRent" + i + "\" class=\"pinput\"/></td>");
            SbHtml6.Append("     <td><input type=\"text\" id=\"txtRentCoast" + i + "\" class=\"pinput\"/></td>");
            SbHtml6.Append("     <td><input type=\"text\" id=\"txtRateOfAdd" + i + "\" style='width:35px'/></td>");
            SbHtml6.Append("     <td><input type=\"text\" id=\"txtRentOfAdd" + i + "\" style='width:35px'/></td>");
            SbHtml6.Append("</tr>");
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
        T_OfficeAutomation_Document_Feasibility t_OfficeAutomation_Document_Feasibility = new T_OfficeAutomation_Document_Feasibility();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
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
            if (IsNewApply)
            //if (MainID == "")
            {
                #region 新建
                IsNewApply = false;
                string[] sHRTree=new string[5];
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
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "Feasibility" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 36;
                t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MainID = new Guid(MainID);
                try
                {
                    string type = fuDiagram.FileName.Substring(fuDiagram.FileName.LastIndexOf(".") + 1).ToLower(); //获取图片格式
                    string strPath = fuDiagram.PostedFile.FileName;
                    FileStream fs = new System.IO.FileStream(strPath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Photo = br.ReadBytes((int)fs.Length);
                    if (type == "jpg" || type == "png" || type == "bmp" || type == "gif" || type == "jpeg" || type == "psd" || type == "pcx" || type == "ico")
                    {
                        try
                        {
                            da_OfficeAutomation_Document_Feasibility_Inherit.InsertPhoto(t_OfficeAutomation_Document_Feasibility);
                        }
                        catch
                        {
                            try
                            {
                                da_OfficeAutomation_Document_Feasibility_Inherit.UpdatePhoto(t_OfficeAutomation_Document_Feasibility);
                            }
                            catch (Exception ee)
                            {
                                RunJS("alert('上传失败，" + ee + "！');");
                                return;
                            }
                        }
                        imgDiagram.ImageUrl = "~/Ajax/Feasibility_Diagram.ashx?MainID=" + new Guid(MainID);
                        br.Close();
                        fs.Close();
                    }
                    else
                    {
                        RunJS("alert('该文件的格式不对，请选择图片文件。');");
                        return;
                    }
                    if (fuDiagram.FileBytes.Length > 1048576)
                    {
                        RunJS("alert('图片太大，请上传小于1M的图片');");
                        return;
                    }
                }
                catch
                {
                }

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                t_OfficeAutomation_Document_Feasibility = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtBranch.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_Feasibility_Inherit.Insert(t_OfficeAutomation_Document_Feasibility);//插入申请表

                InsertFeasibilityDetail1(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField1a.Value);
                InsertFeasibilityDetail1(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField2a.Value);
                InsertFeasibilityDetail1(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField3a.Value);
                InsertFeasibilityDetail1(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField4a.Value);
                InsertFeasibilityDetail1(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField5a.Value);
                InsertFeasibilityDetail2(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID);
                InsertFeasibilityDetail3(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID);
                InsertFeasibilityDetail4(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID);
                InsertFeasibilityDetail5(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID);
                InsertFeasibilityDetail6(t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID);

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

                Common.AddLog(EmployeeID, EmployeeName, 40, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程//*-











                //string[] employnames;
                //string email;
                string msnBody;
                //DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
                ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                DataRow drRow = ds.Tables[0].Rows[0];
                string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_Apply"].ToString();
                //string employname;
                string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                string department = drRow["OfficeAutomation_Document_Feasibility_Department"].ToString();
                string applyUrl = Page.Request.Url.ToString();
                applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
                //通知已审批的全部人员
                //ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDBeforeIdx(MainID, 200);
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                //    employnames = employname.Split(',');
                //    for (int i2 = 0; i2 < employnames.Length; i2++)
                //    {
                msnBody = "您好，" + department + "的" + EmployeeName + "申请了一份《" + documentName + "》，编号为" + serialNumber + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                Common.SendMessageEX(false, "叶凤霞", EmployeeName + "发表了复审意见", msnBody, msnBody);
                //    }
                //}








                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_Feasibility_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=330px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
                        #region 新开分行可行性报告人员关系图
                        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MainID = new Guid(MainID);
                        try
                        {
                            string type = fuDiagram.FileName.Substring(fuDiagram.FileName.LastIndexOf(".") + 1).ToLower(); //获取图片格式
                            string strPath = fuDiagram.PostedFile.FileName;
                            FileStream fs = new System.IO.FileStream(strPath, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Photo = br.ReadBytes((int)fs.Length);
                            if (type == "jpg" || type == "png" || type == "bmp" || type == "gif" || type == "jpeg" || type == "psd" || type == "pcx" || type == "ico")
                            {
                                try
                                {
                                    da_OfficeAutomation_Document_Feasibility_Inherit.InsertPhoto(t_OfficeAutomation_Document_Feasibility);
                                }
                                catch
                                {
                                    try
                                    {
                                        da_OfficeAutomation_Document_Feasibility_Inherit.UpdatePhoto(t_OfficeAutomation_Document_Feasibility);
                                    }
                                    catch (Exception ee)
                                    {
                                        RunJS("alert('上传失败，" + ee + "！');");
                                        return;
                                    }
                                }
                                imgDiagram.ImageUrl = "~/Ajax/Feasibility_Diagram.ashx?MainID=" + new Guid(MainID);
                                br.Close();
                                fs.Close();
                            }
                            else
                            {
                                RunJS("alert('该文件的格式不对，请选择图片文件。');");
                                return;
                            }
                            if (fuDiagram.FileBytes.Length > 1048576)
                            {
                                RunJS("alert('图片太大，请上传小于1M的图片');");
                                return;
                            }
                        }
                        catch
                        {
                        }
                        #endregion
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
                        DataSet ds = new DataSet();
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

                        #endregion

                        #region 发送邮件通知审批人
                        string msnBody;
                        ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                        DataRow drRow = ds.Tables[0].Rows[0];
                        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_Apply"].ToString();
                        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                        string department = drRow["OfficeAutomation_Document_Feasibility_Department"].ToString();
                        string applyUrl = Page.Request.Url.ToString();
                        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                       
                        msnBody = "您好，" + department + "的" + EmployeeName + "申请了一份《" + documentName + "》，编号为" + serialNumber + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        Common.SendMessageEX(false, "叶凤霞", EmployeeName + "发表了复审意见", msnBody, msnBody);
                        #endregion

                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_Feasibility_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=330px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
        var SerialNumber = "Feasibility" + DateTime.Now.ToString("yyyyMMddHHmmssffff");
        var DocumentID = 36;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Feasibility_Inherit feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName,txtDepartment.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }

        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        var Feasibility = new T_OfficeAutomation_Document_Feasibility();
        var BuildingSituation = new List<T_OfficeAutomation_Document_Feasibility_BuildingSituation>();
        var DealOfRecord = new List<T_OfficeAutomation_Document_Feasibility_DealOfRecord>();
        var Competitors = new List<T_OfficeAutomation_Document_Feasibility_Competitors>();
        var Menber = new List<T_OfficeAutomation_Document_Feasibility_Menber>();
        var Statistical = new List<T_OfficeAutomation_Document_Feasibility_Statistical>();
        var YearRent = new List<T_OfficeAutomation_Document_Feasibility_YearRent>();
        ds = feasibility_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            Feasibility = GetModelFromPage(Guid.NewGuid());
        }
        else
        {
            var Feasibility_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_ID"].ToString();
            Feasibility = GetModelFromPage(new Guid(Feasibility_ID));
        }
        feasibility_Inherit.HandleBase(Feasibility);//插入申请表
        Menber.AddRange(GetFeasibilityDetail1(Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField1a.Value));
        Menber.AddRange(GetFeasibilityDetail1(Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField2a.Value));
        Menber.AddRange(GetFeasibilityDetail1(Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField3a.Value));
        Menber.AddRange(GetFeasibilityDetail1(Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField4a.Value));
        Menber.AddRange(GetFeasibilityDetail1(Feasibility.OfficeAutomation_Document_Feasibility_ID, HiddenField5a.Value));

        BuildingSituation = GetFeasibilityDetail2(Feasibility.OfficeAutomation_Document_Feasibility_ID);
        Competitors = GetFeasibilityDetail3(Feasibility.OfficeAutomation_Document_Feasibility_ID);
        DealOfRecord = GetFeasibilityDetail4(Feasibility.OfficeAutomation_Document_Feasibility_ID);
        Statistical = GetFeasibilityDetail5(Feasibility.OfficeAutomation_Document_Feasibility_ID);
        YearRent = GetFeasibilityDetail6(Feasibility.OfficeAutomation_Document_Feasibility_ID);

        var obj = new DataEntity.PageModel.Apply_Feasibility_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;
        obj.Feasibility = Feasibility;
        obj.Menber = Menber;
        obj.BuildingSituation = BuildingSituation;
        obj.Competitors = Competitors;
        obj.DealOfRecord = DealOfRecord;
        obj.Statistical = Statistical;
        obj.YearRent = YearRent;

        //暂存数据保存到xml文件中
        var result = new Common().SaveTempSaveFile<DataEntity.PageModel.Apply_Feasibility_Detail>(obj, "FeasibilityDetail", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
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
        DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
        //DA_OfficeAutomation_Document_Feasibility_Detail_Inherit da_OfficeAutomation_Document_Feasibility_Detail_Inherit = new DA_OfficeAutomation_Document_Feasibility_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_Feasibility_ID"].ToString();
        
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

                //bool isSignSuccess = da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                //如果为第8步流程则为其一审核即可通过，其他为同时审核。
                //bool isSignSuccess = flowIDx == "9" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "8" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_Feasibility_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>发文人员：" + drRow["OfficeAutomation_Document_Feasibility_Apply"]);
                    sbMailBody.Append("<br/>发文部门：" + drRow["OfficeAutomation_Document_Feasibility_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_Feasibility_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>所属总监：" + drRow["OfficeAutomation_Document_Feasibility_ApplyID"]);
                    sbMailBody.Append("<br/>分行名称：" + drRow["OfficeAutomation_Document_Feasibility_Branch"]);
                    sbMailBody.Append("<br/>转铺分行名称：" + drRow["OfficeAutomation_Document_Feasibility_TurnBranch"]);
                    sbMailBody.Append("<br/>隶属区经：" + drRow["OfficeAutomation_Document_Feasibility_AreaManager"]);
                    sbMailBody.Append("<br/>筹建中分行间数：" + drRow["OfficeAutomation_Document_Feasibility_WorkingDepartmentNum"]);
                    sbMailBody.Append("<br/>已批的分行间数：" + drRow["OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum"]);
                    sbMailBody.Append("<br/>所属区域：" + drRow["OfficeAutomation_Document_Feasibility_lDepartmentType"]);
                    sbMailBody.Append("<br/>所属负责人：" + drRow["OfficeAutomation_Document_Feasibility_lMajordomo"]);
                    sbMailBody.Append("<br/>新分行联络人：" + drRow["OfficeAutomation_Document_Feasibility_Contacter"]);
                    sbMailBody.Append("<br/>联系电话：" + drRow["OfficeAutomation_Document_Feasibility_ContactPhone"]);
                    sbMailBody.Append("<br/>具体地址：" + drRow["OfficeAutomation_Document_Feasibility_Address"]);
                    sbMailBody.Append("<br/>面积：" + drRow["OfficeAutomation_Document_Feasibility_Square"]);
                    sbMailBody.Append("<br/>租金情况：" + drRow["OfficeAutomation_Document_Feasibility_RentSituation"]);
                    sbMailBody.Append("<br/>按金：" + drRow["OfficeAutomation_Document_Feasibility_Deposit"]);
                    sbMailBody.Append("<br/>顶手费：" + drRow["OfficeAutomation_Document_Feasibility_SendCoast"]);
                    sbMailBody.Append("<br/>产权情况：" + drRow["OfficeAutomation_Document_Feasibility_PropertySituation"]);
                    sbMailBody.Append("<br/>电力增容情况：" + drRow["OfficeAutomation_Document_Feasibility_PowerAddS"]);
                    sbMailBody.Append("<br/>电话通讯安装情况：" + drRow["OfficeAutomation_Document_Feasibility_MTelephone"]);
                    sbMailBody.Append("<br/>光纤通讯安装情况：" + drRow["OfficeAutomation_Document_Feasibility_MOptical"]);
                    sbMailBody.Append("<br/>预估每月的业绩：" + drRow["OfficeAutomation_Document_Feasibility_MonthlyPerformance"]);
                    sbMailBody.Append("<br/>业绩达到的时间：" + drRow["OfficeAutomation_Document_Feasibility_ReachDate"]);
                    sbMailBody.Append("<br/>预估总启投入成本：" + drRow["OfficeAutomation_Document_Feasibility_TotalCost"]);
                    sbMailBody.Append("<br/>预估每月日常运作的成本：" + drRow["OfficeAutomation_Document_Feasibility_NormalCost"]);
                    sbMailBody.Append("<br/>预估每月的盈利：" + drRow["OfficeAutomation_Document_Feasibility_MonthProfit"]);
                    sbMailBody.Append("<br/>每月盈利的到达时间：" + drRow["OfficeAutomation_Document_Feasibility_MonthProfitRDate"]);
                    sbMailBody.Append("<br/>预估投资回报期限：" + drRow["OfficeAutomation_Document_Feasibility_ReturnPeriod"]);
                    sbMailBody.Append("<br/>预估分行的盈利率：" + drRow["OfficeAutomation_Document_Feasibility_BankOnForecast"]);
                    
                    //sbMailBody.Append("<br/>减佣让佣交易涉及具体情况：");
                    //ds = da_OfficeAutomation_Document_Feasibility_Detail_Inherit.SelectByApplyID(MainID);
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    sbMailBody.Append("<br/>成交日期：" + dr["OfficeAutomation_Document_Feasibility_Detail_DealDate"]);
                    //    sbMailBody.Append("<br/>成交单位：" + dr["OfficeAutomation_Document_Feasibility_Detail_DealDepartment"]);
                    //    sbMailBody.Append("<br/>原成交价：" + dr["OfficeAutomation_Document_Feasibility_Detail_OriginalDealPrice"]);
                    //    sbMailBody.Append("<br/>客户最终成交价：" + dr["OfficeAutomation_Document_Feasibility_Detail_FinalDealPrice"]);
                    //    sbMailBody.Append("<br/>代理费点数：" + (dr["OfficeAutomation_Document_Feasibility_Detail_CommPoint"]));
                    //    sbMailBody.Append("<br/>原佣金：" + (dr["OfficeAutomation_Document_Feasibility_Detail_OriginalComm"]));
                    //    sbMailBody.Append("<br/>让现金奖金额：" + dr["OfficeAutomation_Document_Feasibility_Detail_ReduceCashBonus"]);
                    //    sbMailBody.Append("<br/>让佣金额：" + dr["OfficeAutomation_Document_Feasibility_Detail_Feasibility"]);
                    //    sbMailBody.Append("<br/>总让佣金额：" + dr["OfficeAutomation_Document_Feasibility_Detail_TotalReduce"]);
                    //    sbMailBody.Append("<br/>实际上数金额：" + dr["OfficeAutomation_Document_Feasibility_Detail_ActualReportMoney"]);
                    //    sbMailBody.Append("<br/>");
                    //}

                    mailBody = sbMailBody.ToString();

                    //20160422 SYSREQ201604141706069814205
                    //经第一步审核以后需要给张绍欣(23514)、沈凯飞(3397)、叶凤霞(8258)/18788 黄洁莹  工号：42467 罗勒斯
                    if (flowIDx == "1")
                    {
                        string[] names = { "张绍欣", "沈凯飞", "叶凤霞", "黄洁莹", "罗勒斯" };
                        FristCheckMessage(names, mailBody, apply, serialNumber, applyUrl);
                    }

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

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //总办4张表(减佣让佣，物业部承接一手项目报备，项目费用，合作费)完成后需抄送给的人:黄筑筠,谢芃,李红梅,张绍欣,黄瑛
                            employname = CommonConst.EMP_GMO_COPYTO_NAME + ",张绍欣,叶凤霞,黄洁莹";
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
                                string IsGroups = dsg.Tables[0].Rows[0]["OfficeAutomation_Main_IsGroups"].ToString();
                                if ("1".Equals(IsGroups) && "梁健菁".Equals(employname))
                                {
                                    string sAgree = hdIsAgree.Value == "1" ? "同意" : "其他意见";
                                    msnBody = "您好，梁健菁：现有一份发文部门：" + department + "的" + documentName + ",文档编号为" + serialNumber + "需报请集团审批。<br />黄生的意见是：" + sAgree + "<br />" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    string Groupsemail = "梁健菁";
                                    if (hdIsAgree.Value == "2")
                                        Common.SendMessageEX(false, Groupsemail, "其他意见", msnBody, msnBody);
                                    else
                                        Common.SendMessageEX(false, Groupsemail, "申请已同意", msnBody, msnBody);
                                }
                                else
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
    protected void btnSignSave_Click(object sender, EventArgs e) //M_Remark：Win 20151109
    {
        try
        {
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            da_OfficeAutomation_Main_Inherit.AddSremarkByID(MainID, CommonConst.SIGN_FINANCE);
            RunJS("alert('标记成功！');window.location='" + Page.Request.Url + "'");
        }
        catch
        {
            RunJS("alert('标记失败。');window.location='" + Page.Request.Url + "'");
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

    #region 从页面中获得model

    private T_OfficeAutomation_Document_Feasibility GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_Feasibility t_OfficeAutomation_Document_Feasibility = new T_OfficeAutomation_Document_Feasibility();
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ID = UndertakeProjID;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Apply = EmployeeName;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Department = txtDepartment.Text;

        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Branch = txtBranch.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_TurnBranch = txtTurnBranch.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AreaManager = txtAreaManager.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_WorkingDepartmentNum = txtWorkingDepartmentNum.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum = txtPrebuildDepartmentNum.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Contacter = txtContacter.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ContactPhone = txtContactPhone.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation1 = txtLastYearSituation1.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation2 = txtLastYearSituation2.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation3 = txtLastYearSituation3.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation4 = this.hidLastYearSituation4.Value; //txtLastYearSituation4.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation5 = this.hidLastYearSituation5.Value;//txtLastYearSituation5.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation6 = this.hidLastYearSituation6.Value;//txtLastYearSituation6.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation7 = this.hidLastYearSituation7.Value;//txtLastYearSituation7.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation8 = this.hidLastYearSituation8.Value;//txtLastYearSituation8.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LastYearSituation9 = this.hidLastYearSituation9.Value;//txtLastYearSituation9.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearMonth = txtThisYearMonth.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation1 = txtThisYearSituation1.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation2 = txtThisYearSituation2.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation3 = txtThisYearSituation3.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation4 = this.hidThisYearSituation4.Value;//txtThisYearSituation4.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation5 = this.hidThisYearSituation5.Value;//txtThisYearSituation5.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation6 = this.hidThisYearSituation6.Value;//txtThisYearSituation6.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation7 = this.hidThisYearSituation7.Value;//txtThisYearSituation7.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation8 = this.hidThisYearSituation8.Value;//txtThisYearSituation8.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ThisYearSituation9 = this.hidThisYearSituation9.Value;//txtThisYearSituation9.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation1 = txtBusinessSituation1.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation2 = txtBusinessSituation2.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation3 = txtBusinessSituation3.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation4 = txtBusinessSituation4.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation5 = txtBusinessSituation5.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation6 = txtBusinessSituation6.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation7 = this.hidBusinessSituation7.Value;//txtBusinessSituation7.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation8 = this.hidBusinessSituation8.Value;//txtBusinessSituation8.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation9 = this.hidBusinessSituation9.Value;//txtBusinessSituation9.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation10 = this.hidBusinessSituation10.Value;//txtBusinessSituation10.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation11 = this.hidBusinessSituation11.Value;//txtBusinessSituation11.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation12 = this.hidBusinessSituation12.Value;//txtBusinessSituation12.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation13 = this.hidBusinessSituation13.Value; //txtBusinessSituation13.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation14 = this.hidBusinessSituation14.Value;//txtBusinessSituation14.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation15 = this.hidBusinessSituation15.Value;//txtBusinessSituation15.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation16 = this.hidBusinessSituation16.Value;//txtBusinessSituation16.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation17 = this.hidBusinessSituation17.Value;//txtBusinessSituation17.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BusinessSituation18 = this.hidBusinessSituation18.Value;//txtBusinessSituation18.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation1 = txtProfitSituation1.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation2 = txtProfitSituation2.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation3 = txtProfitSituation3.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation4 = txtProfitSituation4.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation5 = txtProfitSituation5.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation6 = txtProfitSituation6.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation7 = this.hidProfitSituation7.Value;//txtProfitSituation7.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation8 = this.hidProfitSituation8.Value;//txtProfitSituation8.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation9 = this.hidProfitSituation9.Value;//txtProfitSituation9.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation10 = this.hidProfitSituation10.Value;//txtProfitSituation10.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation11 = this.hidProfitSituation11.Value;//txtProfitSituation11.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation12 = this.hidProfitSituation12.Value;//txtProfitSituation12.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation13 = this.hidProfitSituation13.Value;//txtProfitSituation13.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation14 = this.hidProfitSituation14.Value;//txtProfitSituation14.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation15 = this.hidProfitSituation15.Value;//txtProfitSituation15.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation16 = this.hidProfitSituation16.Value;//txtProfitSituation16.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation17 = this.hidProfitSituation17.Value;//txtProfitSituation17.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ProfitSituation18 = this.hidProfitSituation18.Value;//txtProfitSituation18.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation1 = txtAccumulationSituation1.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation2 = txtAccumulationSituation2.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation3 = txtAccumulationSituation3.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation4 = txtAccumulationSituation4.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation5 = txtAccumulationSituation5.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation6 = this.hidAccumulationSituation6.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation7 = this.hidAccumulationSituation7.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation8 = this.hidAccumulationSituation8.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation9 = this.hidAccumulationSituation9.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation10 = this.hidAccumulationSituation10.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation11 = this.hidAccumulationSituation11.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation12 = this.hidAccumulationSituation12.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation13 = this.hidAccumulationSituation13.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation14 = this.hidAccumulationSituation14.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_AccumulationSituation15 = this.hidAccumulationSituation15.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RecentlyYear = txtRecentlyYear.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RecentlySeason = txtRecentlySeason.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation1 = txtStandardSituation1.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation2 = txtStandardSituation2.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation3 = txtStandardSituation3.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation4 = txtStandardSituation4.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation5 = txtStandardSituation5.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation6 = this.hidStandardSituation6.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation7 = this.hidStandardSituation7.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation8 = this.hidStandardSituation8.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation9 = this.hidStandardSituation9.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation10 = this.hidStandardSituation10.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation11 = this.hidStandardSituation11.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation12 = this.hidStandardSituation12.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation13 = this.hidStandardSituation13.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation14 = this.hidStandardSituation14.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StandardSituation15 = this.hidStandardSituation15.Value;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RateBeginDate = txtRateBeginDate.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RateEndDate = txtRateEndDate.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Address = txtAddress.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Square = txtSquare.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentSituation = txtRentSituation.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Deposit = txtDeposit.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_SendCoast = txtSendCoast.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_PropertySituation = txtPropertySituation.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_PowerAddS = txtPowerAddS.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MTelephone = txtMTelephone.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MOptical = txtMOptical.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MonthlyPerformance = txtMonthlyPerformance.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ReachDate = txtReachDate.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_TotalCost = txtTotalCost.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_NormalCost = txtNormalCost.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MonthProfit = txtMonthProfit.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MonthProfitRDate = txtMonthProfitRDate.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ReturnPeriod = txtReturnPeriod.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BankOnForecast = txtBankOnForecast.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_BuildArea = txtBuildArea.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_UsableArea = txtUsableArea.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LeaseStartDate = txtLeaseStartDate.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LeaseEndDate = txtLeaseEndDate.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LeaseYears = txtLeaseYears.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LeaseMonths = txtLeaseMonths.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentFreeStart = txtRentFreeStart.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_txtRentFreeEnd = txtRentFreeEnd.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentFreeCount = txtRentFreeCount.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MonthlyRentNoTax = txtMonthlyRentNoTax.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax = txtMonthlyRentIncludeTax.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MothlyTax = txtMothlyTax.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MonthlyTaxRate = txtMonthlyTaxRate.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ManageCoast = txtManageCoast.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ManageCoast2 = txtManageCoast2.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_WCoast = txtWCoast.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ECoast = txtECoast.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentDeposit = txtRentDeposit.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_WEDeposit = txtWEDeposit.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_ManageDeposit = txtManageDeposit.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_PackageInvoice = txtPackageInvoice.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_NPackageInvoice = txtNPackageInvoice.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_PayReason = txtPayReason.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_PayObiect = txtPayObiect.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_POPhone = txtPOPhone.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Collection = txtCollection.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_CollectionPhone = txtCollectionPhone.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Relationship = txtRelationship.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_CompleteDate = txtCompleteDate.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FirstRent = txtFirstRent.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LeaseDeposit = txtLeaseDeposit.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FSendCoast = txtFSendCoast.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FWEDeposit = txtFWEDeposit.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FManageDeposit = txtFManageDeposit.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FFMCoaet = txtFFMCoaet.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FirstRentT = txtFirstRentT.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LeaseDepositT = txtLeaseDepositT.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FSendCoastT = txtFSendCoastT.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FWEDepositT = txtFWEDepositT.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FManageDepositT = txtFManageDepositT.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FFMCoaetT = txtFFMCoaetT.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentName = txtRentName.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_NatureTitleO = txtNatureTitleO.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Summary = txtSummary.Text;

        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_OpenType = rdbOpenType1.Checked ? true : false; //开铺性质
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentAndTurn = rdbRentAndTurn1.Checked ? true : false; //分租或转租权
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_IsRentFree = rdbIsRentFree1.Checked ? 1 : rdbIsRentFree2.Checked ? 2 : 0; //免租装修期
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_HasTax = rdbHasTax1.Checked ? 1 : rdbHasTax2.Checked ? 2 : 0; //业主是否包发票
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Invoice = rdbInvoice1.Checked ? 1 : rdbInvoice2.Checked ? 2 : 0; //发票提供方
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_PayWay = rdbPayWay1.Checked ? 1 : rdbPayWay2.Checked ? 2 : rdbPayWay3.Checked ? 3 : 0; //支付方式
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StampDuty = rdbStampDuty1.Checked ? 1 : rdbStampDuty2.Checked ? 2 : 0; //租赁印花税
        if(rdbStampDuty1.Checked)
            t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StampDuty0=txtStampDuty1.Text;
        else if (rdbStampDuty2.Checked)
            t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StampDuty0=txtStampDuty2.Text;
        else
            t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_StampDuty0 = "";
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FirstRentC = rdbFirstRentC1.Checked ? 1 : rdbFirstRentC2.Checked ? 2 : 0; //首月租金支付方式
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_LeaseDepositC = rdbLeaseDepositC1.Checked ? 1 : rdbLeaseDepositC2.Checked ? 2 : 0; //租赁按金支付方式
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FSendCoastC = rdbFSendCoastC1.Checked ? 1 : rdbFSendCoastC2.Checked ? 2 : 0; //顶手费支付方式
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FWEDepositC = rdbFWEDepositC1.Checked ? 1 : rdbFWEDepositC2.Checked ? 2 : 0; //水电按金支付方式
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FManageDepositC = rdbFManageDepositC1.Checked ? 1 : rdbFManageDepositC2.Checked ? 2 : 0; //管理费按金支付方式
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_FFMCoaetC = rdbFFMCoaetC1.Checked ? 1 : rdbFFMCoaetC2.Checked ? 2 : 0; //首月印花税支付方式
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentReal = rdbRentReal1.Checked ? 1 : rdbRentReal2.Checked ? 2 : 0; //出租人是否是业主
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentIdentity=txtRentIdentity.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_RentMessage=txtRentMessage.Text;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_EstateProperties = rdbEstateProperties1.Checked ? 1 : rdbEstateProperties2.Checked ? 2 : rdbEstateProperties3.Checked ? 3 : rdbEstateProperties4.Checked ? 4 : 0;//房产性质

        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_lDepartmentType = ddlDepartmentType.SelectedValue;
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_lMajordomo = ddlMajordomo.SelectedValue;

        string cbt = "";
        if (cbNatureTitle1.Checked == true)
            cbt = "|1";
        if (cbNatureTitle2.Checked == true)
            cbt += "|2";
        if (cbNatureTitle3.Checked == true)
            cbt += "|3";
        if (cbNatureTitle4.Checked == true)
            cbt += "|4";
        if (cbNatureTitle5.Checked == true)
            cbt += "|5";
        t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_NatureTitle = cbt;

        return t_OfficeAutomation_Document_Feasibility;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_Feasibility t_OfficeAutomation_Document_Feasibility = new T_OfficeAutomation_Document_Feasibility();
        DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_ID"].ToString();
        t_OfficeAutomation_Document_Feasibility = GetModelFromPage(new Guid(ID));
        try
        {
            string type = fuDiagram.FileName.Substring(fuDiagram.FileName.LastIndexOf(".") + 1).ToLower(); //获取图片格式
            string strPath = fuDiagram.PostedFile.FileName;
            FileStream fs = new System.IO.FileStream(strPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_Photo = br.ReadBytes((int)fs.Length);
            if (type == "jpg" || type == "png" || type == "bmp" || type == "gif" || type == "jpeg" || type == "psd" || type == "pcx" || type == "ico")
            {
                try
                {
                    da_OfficeAutomation_Document_Feasibility_Inherit.InsertPhoto(t_OfficeAutomation_Document_Feasibility);
                }
                catch
                {
                    try
                    {
                        da_OfficeAutomation_Document_Feasibility_Inherit.UpdatePhoto(t_OfficeAutomation_Document_Feasibility);
                    }
                    catch (Exception ee)
                    {
                        RunJS("alert('上传失败，" + ee + "！');");
                        return;
                    }
                }
                imgDiagram.ImageUrl = "~/Ajax/Feasibility_Diagram.ashx?MainID=" + new Guid(MainID);
                br.Close();
                fs.Close();
            }
            else
            {
                RunJS("alert('该文件的格式不对，请选择图片文件。');");
                return;
            }
            if (fuDiagram.FileBytes.Length > 1048576)
            {
                RunJS("alert('图片太大，请上传小于1M的图片');");
                return;
            }
        }
        catch
        {
        }
        string apply = EmployeeName;
        string depname = this.txtDepartment.Text;
        string summary = this.txtBranch.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_Feasibility_Inherit.Update(t_OfficeAutomation_Document_Feasibility); //修改申请表

        DA_OfficeAutomation_Document_Feasibility_Menber_Inherit da_OfficeAutomation_Document__Feasibility_Menber_Inherit = new DA_OfficeAutomation_Document_Feasibility_Menber_Inherit();
        da_OfficeAutomation_Document__Feasibility_Menber_Inherit.Delete(ID);
        InsertFeasibilityDetail1(new Guid(ID), HiddenField1a.Value);
        InsertFeasibilityDetail1(new Guid(ID), HiddenField2a.Value);
        InsertFeasibilityDetail1(new Guid(ID), HiddenField3a.Value);
        InsertFeasibilityDetail1(new Guid(ID), HiddenField4a.Value);
        InsertFeasibilityDetail1(new Guid(ID), HiddenField5a.Value);

        DA_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit da_OfficeAutomation_Document__Feasibility_BuildingSituation_Inherit = new DA_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit();
        da_OfficeAutomation_Document__Feasibility_BuildingSituation_Inherit.Delete(ID);
        InsertFeasibilityDetail2(new Guid(ID));

        DA_OfficeAutomation_Document_Feasibility_Competitors_Inherit da_OfficeAutomation_Document__Feasibility_Competitors_Inherit = new DA_OfficeAutomation_Document_Feasibility_Competitors_Inherit();
        da_OfficeAutomation_Document__Feasibility_Competitors_Inherit.Delete(ID);
        InsertFeasibilityDetail3(new Guid(ID));

        DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit da_OfficeAutomation_Document__Feasibility_DealOfRecord_Inherit = new DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit();
        da_OfficeAutomation_Document__Feasibility_DealOfRecord_Inherit.Delete(ID);
        InsertFeasibilityDetail4(new Guid(ID));

        DA_OfficeAutomation_Document_Feasibility_Statistical_Inherit da_OfficeAutomation_Document__Feasibility_Statistical_Inherit = new DA_OfficeAutomation_Document_Feasibility_Statistical_Inherit();
        da_OfficeAutomation_Document__Feasibility_Statistical_Inherit.Delete(ID);
        InsertFeasibilityDetail5(new Guid(ID));

        DA_OfficeAutomation_Document_Feasibility_YearRent_Inherit da_OfficeAutomation_Document__Feasibility_YearRent_Inherit = new DA_OfficeAutomation_Document_Feasibility_YearRent_Inherit();
        da_OfficeAutomation_Document__Feasibility_YearRent_Inherit.Delete(ID);
        InsertFeasibilityDetail6(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 40, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增明细

    /// <summary>
    /// 新开分行可行性报告人员编排表
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private void InsertFeasibilityDetail1(Guid gBranchContractID, string sv)
    {
        if (sv == "")
            return;

        T_OfficeAutomation_Document_Feasibility_Menber t_OfficeAutomation_Document_Feasibility_Menber;
        DA_OfficeAutomation_Document_Feasibility_Menber_Inherit da_OfficeAutomation_Document_Feasibility_Menber_Inherit = new DA_OfficeAutomation_Document_Feasibility_Menber_Inherit();

        string[] details = Regex.Split(sv, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                //if (detail[0] == "")
                //    continue;
                t_OfficeAutomation_Document_Feasibility_Menber = new T_OfficeAutomation_Document_Feasibility_Menber();
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_MainID = gBranchContractID;
                
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_AreaManager = detail[0];
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_SeniorDirector = detail[1];
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_SeniorManager = detail[2];
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_businessManager = detail[3];
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_Name = detail[4];
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_Num = detail[5];
                t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_UpperManager = detail[6];

                da_OfficeAutomation_Document_Feasibility_Menber_Inherit.Insert(t_OfficeAutomation_Document_Feasibility_Menber);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 新分行周边的主要楼盘情况表
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private void InsertFeasibilityDetail2(Guid gBranchContractID)
    {
        if (HiddenField2.Value == "")
            return;

        T_OfficeAutomation_Document_Feasibility_BuildingSituation t_OfficeAutomation_Document_Feasibility_BuildingSituation;
        DA_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit da_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit = new DA_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit();

        string[] details = Regex.Split(HiddenField2.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_Feasibility_BuildingSituation = new T_OfficeAutomation_Document_Feasibility_BuildingSituation();
                t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_MainID = gBranchContractID;
                t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName = detail[0];
                t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_Csell = detail[1];
                t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare = detail[2];
                t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast = detail[3];
                t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain = detail[4] == "1";

                da_OfficeAutomation_Document_Feasibility_BuildingSituation_Inherit.Insert(t_OfficeAutomation_Document_Feasibility_BuildingSituation);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 主要的竞争对手布点及业绩情况表
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private void InsertFeasibilityDetail3(Guid gBranchContractID)
    {
        if (HiddenField3.Value == "")
            return;

        T_OfficeAutomation_Document_Feasibility_Competitors t_OfficeAutomation_Document_Feasibility_Competitors;
        DA_OfficeAutomation_Document_Feasibility_Competitors_Inherit da_OfficeAutomation_Document_Feasibility_Competitors_Inherit = new DA_OfficeAutomation_Document_Feasibility_Competitors_Inherit();

        string[] details = Regex.Split(HiddenField3.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_Feasibility_Competitors = new T_OfficeAutomation_Document_Feasibility_Competitors();
                t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_MainID = gBranchContractID;
                t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_BusinessName = detail[0];
                t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_WitchBranch = detail[1];
                t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_SetUpTime = detail[2];
                t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_Results = detail[3];

                da_OfficeAutomation_Document_Feasibility_Competitors_Inherit.Insert(t_OfficeAutomation_Document_Feasibility_Competitors);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 区域过往在周边楼盘的成交记录表
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private void InsertFeasibilityDetail4(Guid gBranchContractID)
    {
        if (HiddenField4.Value == "")
            return;

        T_OfficeAutomation_Document_Feasibility_DealOfRecord t_OfficeAutomation_Document_Feasibility_DealOfRecord;
        DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit da_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit = new DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit();

        string[] details = Regex.Split(HiddenField4.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_Feasibility_DealOfRecord = new T_OfficeAutomation_Document_Feasibility_DealOfRecord();
                t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_MainID = gBranchContractID;
                t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding = detail[0];
                t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate = detail[1];
                t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate = detail[2];
                t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet = detail[3];
                t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent = detail[4];

                da_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit.Insert(t_OfficeAutomation_Document_Feasibility_DealOfRecord);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 新开分行主打盘市占率统计表
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private void InsertFeasibilityDetail5(Guid gBranchContractID)
    {
        if (HiddenField5.Value == "")
            return;

        T_OfficeAutomation_Document_Feasibility_Statistical t_OfficeAutomation_Document_Feasibility_Statistical;
        DA_OfficeAutomation_Document_Feasibility_Statistical_Inherit da_OfficeAutomation_Document_Feasibility_Statistical_Inherit = new DA_OfficeAutomation_Document_Feasibility_Statistical_Inherit();

        string[] details = Regex.Split(HiddenField5.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_Feasibility_Statistical = new T_OfficeAutomation_Document_Feasibility_Statistical();
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_MainID = gBranchContractID;
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_Bname = detail[0];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_GzspsNum = detail[1];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_GzspsRate = detail[2];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_RichNum = detail[3];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_RichRate = detail[4];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_EveryNum = detail[5];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_EveryRate = detail[6];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_YuFengNum = detail[7];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_YuFengRate = detail[8];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_OtherNum = detail[9];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_OtherRate = detail[10];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_FreeNum = detail[11];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_FreeRate = detail[12];
                t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_AllSum = detail[13];

                da_OfficeAutomation_Document_Feasibility_Statistical_Inherit.Insert(t_OfficeAutomation_Document_Feasibility_Statistical);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 新开分行年租金递增表
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private void InsertFeasibilityDetail6(Guid gBranchContractID)
    {
        if (HiddenField6.Value == "")
            return;

        T_OfficeAutomation_Document_Feasibility_YearRent t_OfficeAutomation_Document_Feasibility_YearRent;
        DA_OfficeAutomation_Document_Feasibility_YearRent_Inherit da_OfficeAutomation_Document_Feasibility_YearRent_Inherit = new DA_OfficeAutomation_Document_Feasibility_YearRent_Inherit();

        string[] details = Regex.Split(HiddenField6.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_Feasibility_YearRent = new T_OfficeAutomation_Document_Feasibility_YearRent();
                t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_MainID = gBranchContractID;
                t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_YearNo = detail[0];
                t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent = detail[1];
                t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent = detail[2];
                t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_RentCoast = detail[3];
                t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd = detail[4];
                t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd = detail[5];

                da_OfficeAutomation_Document_Feasibility_YearRent_Inherit.Insert(t_OfficeAutomation_Document_Feasibility_YearRent);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 从页面获取新开分行可行性报告人员编排表数据
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private List<T_OfficeAutomation_Document_Feasibility_Menber> GetFeasibilityDetail1(Guid gBranchContractID, string sv)
    {
        if (sv == "")
            return null;

        var list = new List<T_OfficeAutomation_Document_Feasibility_Menber>();
        T_OfficeAutomation_Document_Feasibility_Menber t_OfficeAutomation_Document_Feasibility_Menber;

        string[] details = Regex.Split(sv, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_Feasibility_Menber = new T_OfficeAutomation_Document_Feasibility_Menber();
            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_MainID = gBranchContractID;

            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_AreaManager = detail[0];
            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_SeniorDirector = detail[1];
            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_SeniorManager = detail[2];
            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_businessManager = detail[3];
            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_Name = detail[4];
            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_Num = detail[5];
            t_OfficeAutomation_Document_Feasibility_Menber.OfficeAutomation_Document_Feasibility_Menber_UpperManager = detail[6];

            list.Add(t_OfficeAutomation_Document_Feasibility_Menber);
        }
        return list;
    }

    /// <summary>
    /// 从页面获取新分行周边的主要楼盘情况表数据
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private List<T_OfficeAutomation_Document_Feasibility_BuildingSituation> GetFeasibilityDetail2(Guid gBranchContractID)
    {
        if (HiddenField2.Value == "")
            return null;
        var list = new List<T_OfficeAutomation_Document_Feasibility_BuildingSituation>();
        T_OfficeAutomation_Document_Feasibility_BuildingSituation t_OfficeAutomation_Document_Feasibility_BuildingSituation;

        string[] details = Regex.Split(HiddenField2.Value, "\\|\\|");

        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            if (detail[0] == "")
                continue;
            t_OfficeAutomation_Document_Feasibility_BuildingSituation = new T_OfficeAutomation_Document_Feasibility_BuildingSituation();
            t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_MainID = gBranchContractID;
            t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName = detail[0];
            t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_Csell = detail[1];
            t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare = detail[2];
            t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast = detail[3];
            t_OfficeAutomation_Document_Feasibility_BuildingSituation.OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain = detail[4] == "1";

            list.Add(t_OfficeAutomation_Document_Feasibility_BuildingSituation);
        }
        return list;
    }

    /// <summary>
    /// 从页面获取主要的竞争对手布点及业绩情况表数据
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private List<T_OfficeAutomation_Document_Feasibility_Competitors> GetFeasibilityDetail3(Guid gBranchContractID)
    {
        if (HiddenField3.Value == "")
            return null;

        T_OfficeAutomation_Document_Feasibility_Competitors t_OfficeAutomation_Document_Feasibility_Competitors;
        var list = new List<T_OfficeAutomation_Document_Feasibility_Competitors>();
        string[] details = Regex.Split(HiddenField3.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            if (detail[0] == "")
                continue;
            t_OfficeAutomation_Document_Feasibility_Competitors = new T_OfficeAutomation_Document_Feasibility_Competitors();
            t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_MainID = gBranchContractID;
            t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_BusinessName = detail[0];
            t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_WitchBranch = detail[1];
            t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_SetUpTime = detail[2];
            t_OfficeAutomation_Document_Feasibility_Competitors.OfficeAutomation_Document_Feasibility_Competitors_Results = detail[3];

            list.Add(t_OfficeAutomation_Document_Feasibility_Competitors);
        }
        return list;
    }

    /// <summary>
    /// 从页面获取区域过往在周边楼盘的成交记录表数据
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private List<T_OfficeAutomation_Document_Feasibility_DealOfRecord> GetFeasibilityDetail4(Guid gBranchContractID)
    {
        if (HiddenField4.Value == "")
            return null;

        T_OfficeAutomation_Document_Feasibility_DealOfRecord t_OfficeAutomation_Document_Feasibility_DealOfRecord;
        var list = new List<T_OfficeAutomation_Document_Feasibility_DealOfRecord>();
        string[] details = Regex.Split(HiddenField4.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            if (detail[0] == "")
                continue;
            t_OfficeAutomation_Document_Feasibility_DealOfRecord = new T_OfficeAutomation_Document_Feasibility_DealOfRecord();
            t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_MainID = gBranchContractID;
            t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding = detail[0];
            t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate = detail[1];
            t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate = detail[2];
            t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet = detail[3];
            t_OfficeAutomation_Document_Feasibility_DealOfRecord.OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent = detail[4];

            list.Add(t_OfficeAutomation_Document_Feasibility_DealOfRecord);
        }
        return list;
    }

    /// <summary>
    /// 从页面获取新开分行主打盘市占率统计表数据
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private List<T_OfficeAutomation_Document_Feasibility_Statistical> GetFeasibilityDetail5(Guid gBranchContractID)
    {
        if (HiddenField5.Value == "")
            return null;

        T_OfficeAutomation_Document_Feasibility_Statistical t_OfficeAutomation_Document_Feasibility_Statistical;
        var list = new List<T_OfficeAutomation_Document_Feasibility_Statistical>();
        string[] details = Regex.Split(HiddenField5.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            if (detail[0] == "")
                continue;
            t_OfficeAutomation_Document_Feasibility_Statistical = new T_OfficeAutomation_Document_Feasibility_Statistical();
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_MainID = gBranchContractID;
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_Bname = detail[0];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_GzspsNum = detail[1];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_GzspsRate = detail[2];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_RichNum = detail[3];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_RichRate = detail[4];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_EveryNum = detail[5];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_EveryRate = detail[6];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_YuFengNum = detail[7];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_YuFengRate = detail[8];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_OtherNum = detail[9];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_OtherRate = detail[10];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_FreeNum = detail[11];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_FreeRate = detail[12];
            t_OfficeAutomation_Document_Feasibility_Statistical.OfficeAutomation_Document_Feasibility_Statistical_AllSum = detail[13];

            list.Add(t_OfficeAutomation_Document_Feasibility_Statistical);
        }
        return list;
    }

    /// <summary>
    /// 从页面获取新开分行年租金递增表数据
    /// </summary>
    /// <param name="gBranchContractID"></param>
    private List<T_OfficeAutomation_Document_Feasibility_YearRent> GetFeasibilityDetail6(Guid gBranchContractID)
    {
        if (HiddenField6.Value == "")
            return null;

        T_OfficeAutomation_Document_Feasibility_YearRent t_OfficeAutomation_Document_Feasibility_YearRent;
        var list = new List<T_OfficeAutomation_Document_Feasibility_YearRent>();
        string[] details = Regex.Split(HiddenField6.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            if (detail[0] == "")
                continue;
            t_OfficeAutomation_Document_Feasibility_YearRent = new T_OfficeAutomation_Document_Feasibility_YearRent();
            t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_MainID = gBranchContractID;
            t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_YearNo = detail[0];
            t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent = detail[1];
            t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent = detail[2];
            t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_RentCoast = detail[3];
            t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd = detail[4];
            t_OfficeAutomation_Document_Feasibility_YearRent.OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd = detail[5];

            list.Add(t_OfficeAutomation_Document_Feasibility_YearRent);
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
        Session["FLG_ReWrite9"] = "1";
        Response.Write("<script>window.open('Apply_Feasibility_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("新分行可行性报告.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }
    protected void btDiagram_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
        da_OfficeAutomation_Document_Feasibility_Inherit.DeletePhoto(MainID);
        imgDiagram.ImageUrl = "";
        btDiagram.Visible = false;
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

        DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_ID"].ToString(); //在不同的表要注意修改

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
            DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Feasibility_Department"].ToString();
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
                if (i <= 11 && EmployeeID == "13545") //M_AddNWX：20150511
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
            DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Feasibility_Department"].ToString();
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
            DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Feasibility_Department"].ToString();
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
            RunJS("var win=window.showModalDialog(\"Apply_Feasibility_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=330px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

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

    protected void Review(int index, string sug) //M_AddAnother：20150716 黄生其它意见，增加审批人
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3); //M_AlAno：20160217 ++
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
        if (flowsb != null
    && flowsb.OfficeAutomation_Flow_Employee.Contains(fst4.OfficeAutomation_Flow_Employee) && flowsb.OfficeAutomation_Flow_EmployeeID.Contains(fst4.OfficeAutomation_Flow_EmployeeID)
    && fst4.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && fst4.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID)
    && flowsb.OfficeAutomation_Flow_EmployeeID != flowsb.OfficeAutomation_Flow_AuditorID)
            sug = !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_Suggestion) ? flowsb.OfficeAutomation_Flow_Suggestion + "\r\n\r\n" + sug : sug; //M_AlAno：20160217 ++
        
        if (flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID) && flowsb.OfficeAutomation_Flow_EmployeeID == flowsb.OfficeAutomation_Flow_AuditorID) //M_AlAno：20160217 --u++m //M_RA：20151120
            da_OfficeAutomation_Flow_Inherit.UpdateFlowsSuggestionA(MainID, index.ToString(), sug, sisa); //M_AlterM：20150820
        else
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
        DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Feasibility_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Feasibility_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Feasibility_Department"].ToString();
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
        DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Feasibility_Department"].ToString();
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

    /// <summary>
    /// 第一次审核以后发邮件通知(20160422新增)
    /// </summary>
    /// <param name="names"></param>
    /// <param name="msnBody"></param>
    /// <param name="apply"></param>
    /// <param name="serialNumber"></param>
    private void FristCheckMessage(string[] names, string msnBody, string apply, string serialNumber,string url)
    {
        string messagetitle = "有份《新建分行可行性报告》提交到系统";
        string messagebody = ""; 
        foreach (string name in names)
        {
            messagebody = "您好，" + name + "：" + apply + "上了一份《新建分行可行性报告》，文档编号：" + serialNumber + "。内容概要：";
            messagebody += msnBody;
            messagebody += "<br/>申请表" + url + "<br/><br/><b style='font-weight:700'>注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</b>";

            Common.SendMessageEX(false, name, messagetitle, messagebody, messagebody);
        }
    }
}