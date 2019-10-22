using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using System.IO;

using DataAccess.Operate;
using DataEntity;
using DataEntity.PageModel;
using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;
using System.Collections;//789

using System.Diagnostics; //M_PDF
using System.Web;


public partial class Apply_SpecialAdd_Apply_SpecialAdd_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();

    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();

    public string ApplyDisplayPart = "$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();";

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
                    SbJs.Append("<script type=\"text/javascript\">$(\"div .flow\").hide();$(\"#PageBottom\").hide();$('#trtpdf').append('<div class=\"signdate\"></div>');</script>");
                    tpdf = true;
                }
            }
            catch
            { }
            try
            {
                if (Session["FLG_ReWrite74"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite74"] = null;
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
        //DrawDetailTable2(1);
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
    
    private void InitForm(DataSet SpecialAdd, DataSet Statisticals)
    {
        //SpecialAdd
        DataRow dr = SpecialAdd.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_SpecialAdd_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_SpecialAdd_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_SpecialAdd_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_SpecialAdd_Department"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_SpecialAdd_ApplyDate"].ToString()).ToString("yyyy-MM-dd");

        txtReceiveD.Text = dr["OfficeAutomation_Document_SpecialAdd_ReceiveD"].ToString();
        txtCCDpm.Text = dr["OfficeAutomation_Document_SpecialAdd_CCDpm"].ToString();
        txtSubject.Text = dr["OfficeAutomation_Document_SpecialAdd_Subject"].ToString();
        txtPhone.Text = dr["OfficeAutomation_Document_SpecialAdd_Phone"].ToString();
        txtFax.Text = dr["OfficeAutomation_Document_SpecialAdd_Fax"].ToString();
        txtGroup.Text = dr["OfficeAutomation_Document_SpecialAdd_Group"].ToString();
        txtYear1.Text = dr["OfficeAutomation_Document_SpecialAdd_Year1"].ToString();
        txtYear2.Text = dr["OfficeAutomation_Document_SpecialAdd_Year2"].ToString();
        txtYear3.Text = dr["OfficeAutomation_Document_SpecialAdd_Year3"].ToString();
        txtYear4.Text = dr["OfficeAutomation_Document_SpecialAdd_Year4"].ToString();
        txtYear5.Text = dr["OfficeAutomation_Document_SpecialAdd_Year5"].ToString();
        txtMonth1.Text = dr["OfficeAutomation_Document_SpecialAdd_Month1"].ToString();
        txtMonth2.Text = dr["OfficeAutomation_Document_SpecialAdd_Month2"].ToString();
        txtMonth3.Text = dr["OfficeAutomation_Document_SpecialAdd_Month3"].ToString();
        txtMonth4.Text = dr["OfficeAutomation_Document_SpecialAdd_Month4"].ToString();
        txtMonth5.Text = dr["OfficeAutomation_Document_SpecialAdd_Month5"].ToString();
        txtResults1.Text = dr["OfficeAutomation_Document_SpecialAdd_Results1"].ToString();
        txtResults2.Text = dr["OfficeAutomation_Document_SpecialAdd_Results2"].ToString();
        txtResults3.Text = dr["OfficeAutomation_Document_SpecialAdd_Results3"].ToString();
        txtResults4.Text = dr["OfficeAutomation_Document_SpecialAdd_Results4"].ToString();
        txtResults5.Text = dr["OfficeAutomation_Document_SpecialAdd_Results5"].ToString();
        txtProfits1.Text = dr["OfficeAutomation_Document_SpecialAdd_Profits1"].ToString();
        txtProfits2.Text = dr["OfficeAutomation_Document_SpecialAdd_Profits2"].ToString();
        txtProfits3.Text = dr["OfficeAutomation_Document_SpecialAdd_Profits3"].ToString();
        txtProfits4.Text = dr["OfficeAutomation_Document_SpecialAdd_Profits4"].ToString();
        txtProfits5.Text = dr["OfficeAutomation_Document_SpecialAdd_Profits5"].ToString();
        txtSumFear1.Text = dr["OfficeAutomation_Document_SpecialAdd_SumFear1"].ToString();
        txtSumFear2.Text = dr["OfficeAutomation_Document_SpecialAdd_SumFear2"].ToString();
        txtSumFear3.Text = dr["OfficeAutomation_Document_SpecialAdd_SumFear3"].ToString();
        txtSumFear4.Text = dr["OfficeAutomation_Document_SpecialAdd_SumFear4"].ToString();
        txtSumFear5.Text = dr["OfficeAutomation_Document_SpecialAdd_SumFear5"].ToString();
        txtBDLost1.Text = dr["OfficeAutomation_Document_SpecialAdd_BDLost1"].ToString();
        txtBDLost2.Text = dr["OfficeAutomation_Document_SpecialAdd_BDLost2"].ToString();
        txtBDLost3.Text = dr["OfficeAutomation_Document_SpecialAdd_BDLost3"].ToString();
        txtBDLost4.Text = dr["OfficeAutomation_Document_SpecialAdd_BDLost4"].ToString();
        txtBDLost5.Text = dr["OfficeAutomation_Document_SpecialAdd_BDLost5"].ToString();
        txtHoldRat.Text = dr["OfficeAutomation_Document_SpecialAdd_HoldRat"].ToString();
        txtGPlace.Text = dr["OfficeAutomation_Document_SpecialAdd_GPlace"].ToString();
        txtSumBuild.Text = dr["OfficeAutomation_Document_SpecialAdd_SumBuild"].ToString();
        txtCountComplete.Text = dr["OfficeAutomation_Document_SpecialAdd_CountComplete"].ToString();
        txtCompleteRat.Text = dr["OfficeAutomation_Document_SpecialAdd_CompleteRat"].ToString();
        txtRentYearStart.Text = dr["OfficeAutomation_Document_SpecialAdd_RentYearStart"].ToString();
        txtRentMonthStart.Text = dr["OfficeAutomation_Document_SpecialAdd_RentMonthStart"].ToString();
        txtRentYearEnd.Text = dr["OfficeAutomation_Document_SpecialAdd_RentYearEnd"].ToString();
        txtRentMonthEnd.Text = dr["OfficeAutomation_Document_SpecialAdd_RentMonthEnd"].ToString();
        txtUseRat.Text = dr["OfficeAutomation_Document_SpecialAdd_UseRat"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_SpecialAdd_Reason"].ToString();

        txtSumCount.Text = dr["OfficeAutomation_Document_SpecialAdd_SumCount"].ToString();
        txtSumGzspsNum.Text = dr["OfficeAutomation_Document_SpecialAdd_SumGzspsNum"].ToString();
        txtSumGzspsRate.Text = dr["OfficeAutomation_Document_SpecialAdd_SumGzspsRate"].ToString();
        txtSumEveryNum.Text = dr["OfficeAutomation_Document_SpecialAdd_SumEveryNum"].ToString();
        txtSumEveryRate.Text = dr["OfficeAutomation_Document_SpecialAdd_SumEveryRate"].ToString();
        txtSumRichNum.Text = dr["OfficeAutomation_Document_SpecialAdd_SumRichNum"].ToString();
        txtSumRichRate.Text = dr["OfficeAutomation_Document_SpecialAdd_SumRichRate"].ToString();
        txtSumYuFengNum.Text = dr["OfficeAutomation_Document_SpecialAdd_SumYuFengNum"].ToString();
        txtSumYuFengRate.Text = dr["OfficeAutomation_Document_SpecialAdd_SumYuFengRate"].ToString();
        txtSumFreeNum.Text = dr["OfficeAutomation_Document_SpecialAdd_SumFreeNum"].ToString();
        txtSumFreeRate.Text = dr["OfficeAutomation_Document_SpecialAdd_SumFreeRate"].ToString();
        txtSumOtherNum.Text = dr["OfficeAutomation_Document_SpecialAdd_SumOtherNum"].ToString();
        txtSumOtherRate.Text = dr["OfficeAutomation_Document_SpecialAdd_SumOtherRate"].ToString();
        txtSumQFangNum.Text = dr["OfficeAutomation_Document_SpecialAdd_SumQFangNum"].ToString();
        txtSumQFangRate.Text = dr["OfficeAutomation_Document_SpecialAdd_SumQFangRate"].ToString();
        ddlAddOne.SelectedValue = dr["OfficeAutomation_Document_SpecialAdd_AddOne"].ToString();

        this.txtKeyCount.Text = dr["OfficeAutomation_Document_SpecialAdd_KeyCount"].ToString();
        
        this.txtSecHand1.Text = dr["OfficeAutomation_Document_SpecialAdd_SecHand1"].ToString();
        this.txtSecHand2.Text = dr["OfficeAutomation_Document_SpecialAdd_SecHand2"].ToString();
        this.txtSecHand3.Text = dr["OfficeAutomation_Document_SpecialAdd_SecHand3"].ToString();
        this.txtSecHand4.Text = dr["OfficeAutomation_Document_SpecialAdd_SecHand4"].ToString();
        this.txtSecHand5.Text = dr["OfficeAutomation_Document_SpecialAdd_SecHand5"].ToString();

        this.ddlIsTG1.SelectedValue = dr["OfficeAutomation_Document_SpecialAdd_IsTG1"].ToString();
        this.ddlIsTG2.SelectedValue = dr["OfficeAutomation_Document_SpecialAdd_IsTG2"].ToString();
        this.ddlIsTG3.SelectedValue = dr["OfficeAutomation_Document_SpecialAdd_IsTG3"].ToString();
        this.ddlIsTG4.SelectedValue = dr["OfficeAutomation_Document_SpecialAdd_IsTG4"].ToString();
        this.ddlIsTG5.SelectedValue = dr["OfficeAutomation_Document_SpecialAdd_IsTG5"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        //Statisticals
        int detailCount2 = Statisticals == null ? 0 : Statisticals.Tables[0].Rows.Count;
        if (detailCount2 == 0)
        { 
            //DrawDetailTable2(1); 
        }    
        else
        {
            //DrawDetailTable2(detailCount2);
            string detailtext = "";
            for (int n = 0; n < detailCount2; n++)
            {
                dr = Statisticals.Tables[0].Rows[n];
                /*
                int i = n + 1;

                SbJs.Append("$('#txtBname" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_Bname"] + "');");
                SbJs.Append("$('#txtSum" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_Sum"] + "');");
                SbJs.Append("$('#txtGzspsNum" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_GzspsNum"] + "');");
                SbJs.Append("$('#txtGzspsRate" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_GzspsRate"] + "');");
                SbJs.Append("$('#txtEveryNum" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_EveryNum"] + "');");
                SbJs.Append("$('#txtEveryRate" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_EveryRate"] + "');");
                SbJs.Append("$('#txtRichNum" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_RichNum"] + "');");
                SbJs.Append("$('#txtRichRate" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_RichRate"] + "');");
                SbJs.Append("$('#txtQFangNum" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_QFangNum"] + "');");
                SbJs.Append("$('#txtQFangrRate" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_QFangrRate"] + "');");
                SbJs.Append("$('#txtYuFengNum" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_YuFengNum"] + "');");
                SbJs.Append("$('#txtYuFengRate" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_YuFengRate"] + "');");
                SbJs.Append("$('#txtFreeNum" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_FreeNum"] + "');");
                SbJs.Append("$('#txtFreeRate" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_FreeRate"] + "');");
                SbJs.Append("$('#txtOtherNum" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_OtherNum"] + "');");
                SbJs.Append("$('#txtOtherRate" + i + "').val('" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_OtherRate"] + "');");
                */
                detailtext += dr["OfficeAutomation_Document_SpecialAdd_Statistical_Bname"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_Sum"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_GzspsNum"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_GzspsRate"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_EveryNum"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_EveryRate"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_RichNum"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_RichRate"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_QFangNum"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_QFangrRate"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_YuFengNum"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_YuFengRate"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_FreeNum"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_FreeRate"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_OtherNum"].ToString() + "&&"
                    + dr["OfficeAutomation_Document_SpecialAdd_Statistical_OtherRate"].ToString() + "&&"
                    + "||"
                    ;
            }
            if (!string.IsNullOrEmpty(detailtext))
            {
                this.hdDetail2.Value = detailtext.Substring(0, detailtext.Length - 2);
            }
            //detailtext = detailtext.TrimEnd(new char[]{'||'});
        }
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        bool IsTempSave = false;        //是否暂存
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
        DA_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit da_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit();

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

        DataSet SpecialAdd = new DataSet();
        DataSet Statisticals = new DataSet();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var obj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_SpecialAdd_Detail>("SpecialAddDetail", "", Mainobj.OfficeAutomation_SerialNumber);
            SpecialAdd = Common.GetPageDetailDS<T_OfficeAutomation_Document_SpecialAdd>(obj.SpecialAdd, Mainobj);
            Statisticals = Common.GetDataSet<T_OfficeAutomation_Document_SpecialAdd_Statistical>(obj.Statisticals);
            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            SpecialAdd = da_OfficeAutomation_Document_SpecialAdd_Inherit.SelectByMainID(MainID);
            string specialAddID = SpecialAdd.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_ID"].ToString();
            Statisticals = da_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit.SelectByID(specialAddID);
        }

        string applicant = SpecialAdd.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_Apply"].ToString();       //申请人
        InitForm(SpecialAdd, Statisticals);
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

        if (!IsTempSave)
        {   
            //非暂存才显示上传附件按钮
            SbJs.Append("$(\"#btnUpload\").show();");
        }
        if (IsTempSave)
        {
            btnSPDF.Visible = false;
        }

        if (isApplicant)
        {
            SbJs.Append("$(\"#lbh1\").show();$(\"#lbh2\").show();$(\"#lbh3\").show();");
            if (flowState == "1" || flowState == "7")
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
        try //M_AddAnother：20150716 黄生其它意见，增加审批人
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
            DataSet dsFlow2 = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
            DataRowCollection drcz = dsFlow2.Tables[0].Rows;
            T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 4);
            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 200);
            flowst = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndEID(MainID, "0001");

            #region 复审相关
            var flowsm = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 220);       //总经理复审流程
            //是否允许复审
            if (flowst != null && flowst.OfficeAutomation_Flow_IsAgree == 2 && flowst.OfficeAutomation_Flow_Audit == true)
            {
                SbJs.Append("$(\"#trAddAnoF1\").show();");
                //黄生回复过并且回复其他意见并且流程已结束
                if (EmployeeName == applicant || (fst3.OfficeAutomation_Flow_Auditor.Contains(EmployeeName) && fst3.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)))
                {

                    //登录人是申请人或者是区域的负责人
                    if (flowsa == null)
                    {
                        //复审流程是否存在
                        btnsSignIDx200.Visible = true;
                    }
                    else if (flowsa != null && flowsa.OfficeAutomation_Flow_Audit)
                    {
                        //复审流程存在并已经审核完
                        if (flowsm == null || (flowsm.OfficeAutomation_Flow_Audit && flowsm.OfficeAutomation_Flow_IsAgree != 1 && flowsm.OfficeAutomation_Flow_IsAgree != 0))
                        {
                            //220流程不存在或者220流程未结束
                            btnsSignIDx200.Visible = true;
                        }
                    }
                    else if (flowsa != null && !flowsa.OfficeAutomation_Flow_Audit)
                    {
                        //复审流程存在并未审核完
                        if (!(flowsa.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID) && flowsa.OfficeAutomation_Flow_Auditor.Contains(EmployeeName)))
                        {
                            //未审核过的人登录
                            btnsSignIDx200.Visible = true;
                        }
                    }

                }
            }
            //总经理复审回复
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF3\").show();");
            if (flowst.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)
                && flowst.OfficeAutomation_Flow_Auditor.Contains(EmployeeName)
                && flowst.OfficeAutomation_Flow_IsAgree == 2
                && flowsa.OfficeAutomation_Flow_Audit == true && flowsm != null && !flowsm.OfficeAutomation_Flow_Audit
                )
            {
                btnsSignIDx220.Visible = true;
                SbJs.Append("$(\"#txtIDx220\").hide();");
            }
            #endregion

            /*
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF1\").show();");
            if (((drcz[0]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID)
                && drcz[0]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || (EmployeeName == applicant && flowst.OfficeAutomation_Flow_IsAgree == 2) 
                || (fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowst.OfficeAutomation_Flow_IsAgree == 2) 
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
            */
        }
        catch
        {
        }

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
        //    btnSignSave.Visible = true;
         
        #endregion


        if (ViewState["FLG_ReWrite"] != null && ViewState["FLG_ReWrite"].ToString() == "1")
        {
            SbJs.Append(ApplyDisplayPart);
            SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
            SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
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
        if (isApplicant && !IsTempSave)
            btnReWrite.Visible = true; //*-+


        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet ds = new DataSet();
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
            DataRow dr;
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

        #region 显示流程示意图
        //自定义控件赋值
        var flowshowlist = da_OfficeAutomation_Flow_Inherit.GetFlowShowList(ds);
        this.FlowShow1.FlowShowList = flowshowlist;
        bool showf = true; //M_HideFlows：20150330
        for (int i = 0; i < drc.Count; i++)
        {
            
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();
            //string curemp2 = drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString();
            if (EmployeeName == "黄轩明" && showf) //M_HideFlows：20150330
            {
                showf = false;
                SbJs.Append("$(\"#trShowFlow7\").hide();$(\"#trShowFlow8\").prepend('<td>人力资源部</td>');");
                SbJs.Append("$(\"#trLogistics1\").hide();$(\"#trLogistics2\").prepend('<td>后勤事务部意见</td>');");
             }

            //if (curidx == "9")
            //    flag3 = true;

            //SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                //SbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                if (curemp.Contains(EmployeeName))
                {
                    //switch (curidx)
                    //{
                    //    //case "10":
                    //    //    ckbAddIDx10.Visible = true;
                    //    //    break;
                    //    case "7":
                    //        if (EmployeeID == "13545") //M_AddNWX：20150511
                    //            lbtnAddN.Visible = true;
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }

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
        #endregion

        ////如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        //if (flag3)
        //    SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();$('#trGeneralManager').show();");

        T_OfficeAutomation_Flow flows;//789
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        if (flows != null)
            SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            this.FlowShow1.ShowEditBtn = true;
        if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;

        //if (!showf) //M_HideFlows：20150330
        //    SbFlow.Length = 0;

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
            FlowShow1.Visible = false;
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

    //public void DrawDetailTable(int n)
    //{
    //    //DataSet dsApplyDetail = new DataSet();
    //    //DataSet dsApplyType = new DataSet();

    //    //DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
    //    //dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(1);
    //    //DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
    //    //dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();

    //    for (int i = 2; i <= n; i++)
    //    {
    //        SbHtml.Append("<tr id=\"trDetail" + i + "\">");

    //        SbHtml.Append("<td><input type=\"text\" id=\"txtBeginData" + i + "\" style=\"width:100px\"/></td>");
    //        SbHtml.Append("<td><input type=\"text\" id=\"txtEndData" + i + "\" style=\"width:100px\"/></td>");
    //        SbHtml.Append("<td><input type=\"text\" id=\"txtTaxRent" + i + "\" style=\"width:100px\"/></td>");
    //        SbHtml.Append("<td><input type=\"text\" id=\"txtRent" + i + "\" style=\"width:100px\"/></td>");

    //        SbHtml.Append("</tr>");
    //    }
    //    SbJs.Append("i=" + n + ";");
    //}

    public void DrawDetailTable2(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml2.Append("<tr id=\"trDetail2" + i + "\">");

            SbHtml2.Append("<td><input type=\"text\" id=\"txtBname" + i + "\" style=\"width:100px\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtSum" + i + "\" style=\"width:50px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree();\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtGzspsNum" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtGzspsRate" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/>%</td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtEveryNum" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtEveryRate" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/>%</td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtRichNum" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtRichRate" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/>%</td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtQFangNum" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtQFangrRate" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/>%</td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtYuFengNum" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtYuFengRate" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/>%</td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtFreeNum" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtFreeRate" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/>%</td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtOtherNum" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtOtherRate" + i + "\" style=\"width:40px\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,\'\');CaculateMThree()\"/>%</td>");

            SbHtml2.Append("</tr>");
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
        SaveOrEdit();
    }

    protected void btnTempSave_Click(object sender, EventArgs e)
    {
        var SerialNumber = "SpecialAdd" + DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        var DocumentID = 69;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        var SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();

        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName,txtDepartment.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }
        
        //插入0Idx的流程
        //var da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        //da_OfficeAutomation_Flow_Inherit.Insert0Idx(MainID, EmployeeName, EmployeeID);

        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        var SpecialAdd = new T_OfficeAutomation_Document_SpecialAdd();
        ds = SpecialAdd_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0 )
        {
            SpecialAdd = GetModelFromPage(Guid.NewGuid());
        }
        else
        {
            var SpecialAdd_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_ID"].ToString();
            SpecialAdd = GetModelFromPage(new Guid(SpecialAdd_ID));
        }
        var obj = new Apply_SpecialAdd_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;

        //var SpecialAdd = GetModelFromPage(Guid.NewGuid());
        SpecialAdd_Inherit.HandleBase(SpecialAdd);                      //只插入关键必填字段；
        var Statisticals = GetListStatistical(hdDetail2.Value, SpecialAdd.OfficeAutomation_Document_SpecialAdd_ID);

        obj.SpecialAdd = SpecialAdd;
        obj.Statisticals = Statisticals;

        var result = new Common().SaveTempSaveFile<Apply_SpecialAdd_Detail>(obj, "SpecialAddDetail", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
        if (result)
        {
            //2016/8/18 52100
            RunJS("alert('保存成功！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
        else
        {
            //2016/8/18 52100
            RunJS("alert('保存失败！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
    }

    private void SaveOrEdit()
    {
        #region 创建对象

        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_SpecialAdd t_OfficeAutomation_Document_SpecialAdd = new T_OfficeAutomation_Document_SpecialAdd();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                IsNewApply = true;
            }
        }
        catch
        {
        }

        try
        {
            if (IsNewApply)
            {
                #region 新建
                IsNewApply = false;
                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "SpecialAdd" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 69; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                


                t_OfficeAutomation_Document_SpecialAdd = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = this.txtSubject.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_SpecialAdd_Inherit.Insert(t_OfficeAutomation_Document_SpecialAdd);//插入申请表
                InsertSpecialAddDetail2(t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_ID);

                //非临时保存需要添加默认流程
                #region 保存默认流程
                da_OfficeAutomation_Flow_Inherit.InsertDefaultFlow(t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString());
                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 73, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_SpecialAdd_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID +"'");
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
                        da_OfficeAutomation_Flow_Inherit.InsertDefaultFlow(MainObj.OfficeAutomation_Main_ID.ToString());
                        #endregion
                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_SpecialAdd_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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

    #endregion

    #region 从页面中获得model

    private T_OfficeAutomation_Document_SpecialAdd GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_SpecialAdd t_OfficeAutomation_Document_SpecialAdd = new T_OfficeAutomation_Document_SpecialAdd();
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_ID = UndertakeProjID;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Apply = EmployeeName;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Department = txtDepartment.Text;

        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_ReceiveD = txtReceiveD.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_CCDpm = txtCCDpm.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Subject = txtSubject.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Phone = txtPhone.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Fax = txtFax.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Group = txtGroup.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Year1 = txtYear1.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Year2 = txtYear2.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Year3 = txtYear3.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Year4 = txtYear4.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Year5 = txtYear5.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Month1 = txtMonth1.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Month2 = txtMonth2.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Month3 = txtMonth3.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Month4 = txtMonth4.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Month5 = txtMonth5.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Results1 = txtResults1.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Results2 = txtResults2.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Results3 = txtResults3.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Results4 = txtResults4.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Results5 = txtResults5.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Profits1 = txtProfits1.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Profits2 = txtProfits2.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Profits3 = txtProfits3.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Profits4 = txtProfits4.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Profits5 = txtProfits5.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFear1 = txtSumFear1.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFear2 = txtSumFear2.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFear3 = txtSumFear3.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFear4 = txtSumFear4.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFear5 = txtSumFear5.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_BDLost1 = txtBDLost1.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_BDLost2 = txtBDLost2.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_BDLost3 = txtBDLost3.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_BDLost4 = txtBDLost4.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_BDLost5 = txtBDLost5.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_HoldRat = txtHoldRat.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_GPlace = txtGPlace.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumBuild = txtSumBuild.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_CountComplete = txtCountComplete.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_CompleteRat = txtCompleteRat.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_RentYearStart = txtRentYearStart.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_RentMonthStart = txtRentMonthStart.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_RentYearEnd = txtRentYearEnd.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_RentMonthEnd = txtRentMonthEnd.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_UseRat = txtUseRat.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_Reason = txtReason.Text;

        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumCount = txtSumCount.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumGzspsNum = txtSumGzspsNum.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumGzspsRate = txtSumGzspsRate.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumEveryNum = txtSumEveryNum.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumEveryRate = txtSumEveryRate.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumRichNum = txtSumRichNum.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumRichRate = txtSumRichRate.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumYuFengNum = txtSumYuFengNum.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumYuFengRate = txtSumYuFengRate.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFreeNum = txtSumFreeNum.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFreeRate = txtSumFreeRate.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumOtherNum = txtSumOtherNum.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumOtherRate = txtSumOtherRate.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumQFangNum = txtSumQFangNum.Text;
        //t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumQFangRate = txtSumQFangRate.Text;

        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumCount = Hiddenfielda1.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumGzspsNum = Hiddenfielda2.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumGzspsRate = Hiddenfielda3.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumEveryNum = Hiddenfielda4.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumEveryRate = Hiddenfielda5.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumRichNum = Hiddenfielda6.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumRichRate = Hiddenfielda7.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumYuFengNum = Hiddenfielda8.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumYuFengRate = Hiddenfielda9.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFreeNum = Hiddenfielda10.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumFreeRate = Hiddenfielda11.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumOtherNum = Hiddenfielda12.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumOtherRate = Hiddenfielda13.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumQFangNum = Hiddenfielda14.Value;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SumQFangRate = Hiddenfielda15.Value;

        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_AddOne = ddlAddOne.SelectedValue;

        //20160422 SYSREQ201604141157324101000
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SecHand1 = this.txtSecHand1.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SecHand2 = this.txtSecHand2.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SecHand3 = this.txtSecHand3.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SecHand4 = this.txtSecHand4.Text;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_SecHand5 = this.txtSecHand5.Text;

        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_IsTG1 = this.ddlIsTG1.SelectedValue;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_IsTG2 = this.ddlIsTG2.SelectedValue;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_IsTG3 = this.ddlIsTG3.SelectedValue;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_IsTG4 = this.ddlIsTG4.SelectedValue;
        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_IsTG5 = this.ddlIsTG5.SelectedValue;

        t_OfficeAutomation_Document_SpecialAdd.OfficeAutomation_Document_SpecialAdd_KeyCount = this.txtKeyCount.Text;

        return t_OfficeAutomation_Document_SpecialAdd;
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
            Common.AddLog(EmployeeID, EmployeeName, 73, new Guid(MainID), 8);
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
        DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
        DA_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit da_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit();
        
        DataSet ds = da_OfficeAutomation_Document_SpecialAdd_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_SpecialAdd_ID"].ToString(); 
        
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
                bool isSignSuccess = (flowIDx == "7" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                //bool isSignSuccess = flowIDx == "5" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_SpecialAdd_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_SpecialAdd_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_SpecialAdd_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_SpecialAdd_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>文件主题：" + drRow["OfficeAutomation_Document_SpecialAdd_Subject"].ToString());
                    sbMailBody.Append("<br/>分行电话：" + drRow["OfficeAutomation_Document_SpecialAdd_Phone"]);
                    sbMailBody.Append("<br/><br/>");

                    sbMailBody.Append("<br/>主打盘市占率：");
                    ds = da_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>楼盘名：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_Bname"]);
                        sbMailBody.Append("<br/>合计：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_Sum"]);
                        sbMailBody.Append("<br/>中原宗数：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_GzspsNum"]);
                        sbMailBody.Append("<br/>中原市占率：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_GzspsRate"]);
                        sbMailBody.Append("<br/>满堂红宗数：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_EveryNum"]);
                        sbMailBody.Append("<br/>满堂红市占率：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_EveryRate"]);
                        sbMailBody.Append("<br/>合富宗数：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_RichNum"]);
                        sbMailBody.Append("<br/>合富市占率：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_RichRate"]);
                        sbMailBody.Append("<br/>搜房交易宗数：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_QFangNum"]);
                        sbMailBody.Append("<br/>搜房交易市占率：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_QFangrRate"]);
                        sbMailBody.Append("<br/>裕丰宗数：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_YuFengNum"]);
                        sbMailBody.Append("<br/>裕丰市占率：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_YuFengRate"]);
                        sbMailBody.Append("<br/>自行交易宗数：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_FreeNum"]);
                        sbMailBody.Append("<br/>自行交易市占率：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_FreeRate"]);
                        sbMailBody.Append("<br/>其它交易宗数：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_OtherNum"]);
                        sbMailBody.Append("<br/>其它交易市占率：" + dr["OfficeAutomation_Document_SpecialAdd_Statistical_OtherRate"]);
                        sbMailBody.Append("<br/>");
                    }

                    mailBody = sbMailBody.ToString();

                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        string allSuggestion = "";
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意

                        //判断审批流程是否完成,通知相应人员
                        if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID))
                        {
                            #region 流程全部结束
                            //审批流程完成，通知申请人
                            msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";

                            //获取所有已通过审核的审核结果，并返回相应string
                            allSuggestion = da_OfficeAutomation_Flow_Inherit.GetAllSuggestion(MainID);
                            
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
                                        msnBody += allSuggestion;
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

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）梁晶晶（工号：32188）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            employname = CommonConst.EMP_GMO_NAME;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    msnBody += allSuggestion;
                                    email = employnames[i];
                                    if (hdIsAgree.Value == "2")
                                        Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                    else
                                        Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                    employeeList += employnames[i] + "||";
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region 流程未完成
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

                            //当审批到总经理的时候，发份邮件通知总办2位同事
                            if (employname.Contains(CommonConst.EMP_GENERALMANAGER_NAME))
                            {
                                employname = CommonConst.EMP_GMO_NAME;
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody + mailBody, msnBody);
                                }
                            }
                            #endregion
                        }

                        RunJS("alert('审批成功！');window.location='" + Page.Request.Url + "'");
                    }
                    else //不同意
                    {
                        #region 不同意
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
                        #endregion
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
        //    DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_SpecialAdd_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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
                //if (drc[4]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
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
        T_OfficeAutomation_Document_SpecialAdd t_OfficeAutomation_Document_SpecialAdd = new T_OfficeAutomation_Document_SpecialAdd();
        DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SpecialAdd_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_ID"].ToString();

        t_OfficeAutomation_Document_SpecialAdd = GetModelFromPage(new Guid(ID));

        string apply = EmployeeName;
        string depname = this.txtDepartment.Text;
        string summary = this.txtSubject.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_SpecialAdd_Inherit.Update(t_OfficeAutomation_Document_SpecialAdd);//修改申请表

        DA_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit da_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit();
        da_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit.Delete(ID);
        InsertSpecialAddDetail2(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 73, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增明细

    /// <summary>
    /// 新增分行续约租赁期及租金详情表
    /// </summary>
    /// <param name="gSpecialAddID"></param>
    //private void InsertSpecialAddDetail(Guid gSpecialAddID)
    //{
    //    if (hdDetail.Value == "")
    //        return;

    //    T_OfficeAutomation_Document_SpecialAdd_LeaseTerm t_OfficeAutomation_Document_SpecialAdd_LeaseTerm;
    //    DA_OfficeAutomation_Document_SpecialAdd_LeaseTerm_Inherit da_OfficeAutomation_Document_SpecialAdd_LeaseTerm_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_LeaseTerm_Inherit();

    //    string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
    //    try
    //    {
    //        for (int i = 0; i < details.Length; i++)
    //        {
    //            string[] detail = Regex.Split(details[i], "\\&\\&");
    //            if (detail[0] == "")
    //                continue;
    //            t_OfficeAutomation_Document_SpecialAdd_LeaseTerm = new T_OfficeAutomation_Document_SpecialAdd_LeaseTerm();
    //            t_OfficeAutomation_Document_SpecialAdd_LeaseTerm.OfficeAutomation_Document_SpecialAdd_LeaseTerm_ID = Guid.NewGuid();
    //            t_OfficeAutomation_Document_SpecialAdd_LeaseTerm.OfficeAutomation_Document_SpecialAdd_LeaseTerm_MainID = gSpecialAddID;

    //            t_OfficeAutomation_Document_SpecialAdd_LeaseTerm.OfficeAutomation_Document_SpecialAdd_LeaseTerm_BeginData = detail[0];
    //            t_OfficeAutomation_Document_SpecialAdd_LeaseTerm.OfficeAutomation_Document_SpecialAdd_LeaseTerm_EndData = detail[1];
    //            t_OfficeAutomation_Document_SpecialAdd_LeaseTerm.OfficeAutomation_Document_SpecialAdd_LeaseTerm_TaxRent = detail[2];
    //            t_OfficeAutomation_Document_SpecialAdd_LeaseTerm.OfficeAutomation_Document_SpecialAdd_LeaseTerm_Rent = detail[3];

    //            da_OfficeAutomation_Document_SpecialAdd_LeaseTerm_Inherit.Insert(t_OfficeAutomation_Document_SpecialAdd_LeaseTerm);
    //        }
    //    }
    //    catch(Exception ee)
    //    {
    //        Alert(ee.Message);
    //        return;
    //    }
    //}

    /// <summary>
    /// 新增分行主打盘市占率统计表
    /// </summary>
    /// <param name="gSpecialAddID"></param>
    private void InsertSpecialAddDetail2(Guid gSpecialAddID)
    {
        if (hdDetail2.Value == "")
            return;

        T_OfficeAutomation_Document_SpecialAdd_Statistical t_OfficeAutomation_Document_SpecialAdd_Statistical;
        DA_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit da_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit();

        string[] details = Regex.Split(hdDetail2.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_SpecialAdd_Statistical = new T_OfficeAutomation_Document_SpecialAdd_Statistical();
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_MainID = gSpecialAddID;

                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_Bname = detail[0];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_Sum = detail[1];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_GzspsNum = detail[2];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_GzspsRate = detail[3];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_EveryNum = detail[4];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_EveryRate = detail[5];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_RichNum = detail[6];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_RichRate = detail[7];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_YuFengNum = detail[8];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_YuFengRate = detail[9];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_FreeNum = detail[10];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_FreeRate = detail[11];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_OtherNum = detail[12];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_OtherRate = detail[13];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_QFangNum = detail[14];
                t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_QFangrRate = detail[15];

                da_OfficeAutomation_Document_SpecialAdd_Statistical_Inherit.Insert(t_OfficeAutomation_Document_SpecialAdd_Statistical);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    private List<T_OfficeAutomation_Document_SpecialAdd_Statistical> GetListStatistical(string str,Guid gSpecialAddID)
    {
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }
        string[] details = Regex.Split(str, "\\|\\|");
        var list = new List<T_OfficeAutomation_Document_SpecialAdd_Statistical>();
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            if (detail[0] == "")
                continue;
            var t_OfficeAutomation_Document_SpecialAdd_Statistical = new T_OfficeAutomation_Document_SpecialAdd_Statistical();
            t_OfficeAutomation_Document_SpecialAdd_Statistical = new T_OfficeAutomation_Document_SpecialAdd_Statistical();
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_MainID = gSpecialAddID;

            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_Bname = detail[0];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_Sum = detail[1];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_GzspsNum = detail[2];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_GzspsRate = detail[3];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_EveryNum = detail[4];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_EveryRate = detail[5];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_RichNum = detail[6];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_RichRate = detail[7];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_YuFengNum = detail[8];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_YuFengRate = detail[9];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_FreeNum = detail[10];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_FreeRate = detail[11];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_OtherNum = detail[12];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_OtherRate = detail[13];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_QFangNum = detail[14];
            t_OfficeAutomation_Document_SpecialAdd_Statistical.OfficeAutomation_Document_SpecialAdd_Statistical_QFangrRate = detail[15];

            list.Add(t_OfficeAutomation_Document_SpecialAdd_Statistical);
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
        Session["FLG_ReWrite74"] = "1";
        Response.Write("<script>window.open('Apply_SpecialAdd_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("特殊增编申请表.pdf"));//强制下载 
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

        DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SpecialAdd_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_ID"].ToString(); //在不同的表要注意修改

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
            DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SpecialAdd_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SpecialAdd_Department"].ToString();
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
                //if (i <= 7 && EmployeeID == "13545") //M_AddNWX：20150511
                //{
                //    da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "黄志超", "13545");
                //    da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                //}
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
            DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SpecialAdd_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SpecialAdd_Department"].ToString();
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
            DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SpecialAdd_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SpecialAdd_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 4); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_SpecialAdd_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

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
        T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4); //M_AlAno：20160217 ++
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
        DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_SpecialAdd_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
        DataSet ds = da_OfficeAutomation_Document_SpecialAdd_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SpecialAdd_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_SpecialAdd_Department"].ToString();
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

        #region 复审
        var flowManager = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);  //管理流程
        //同意1，不同意0，其他意见2
        string sisa = "2";
        if (rdb220a1.Checked)
            sisa = "1";
        else if (rdb220a2.Checked)
            sisa = "0";
        var result = new FlowCommonMethod().Review(txtIDx200.Value, flowManager, MainID, EmployeeName, EmployeeID, sisa, 200);
        RunJS("alert('" + result.Split('|')[1] + "');window.location='" + Page.Request.Url + "'");
        #endregion

        //Review(200, txtIDx200.Value);
    }
    protected void btnSignIDx220_Click(object sender, EventArgs e)
    {
        string result = "";
        #region 总经理复审
        //同意1，不同意0，其他意见2
        string sisa = "2";
        if (rdb220a1.Checked)
            sisa = "1";
        else if (rdb220a2.Checked)
            sisa = "0";
        result = new FlowCommonMethod().Review_Manager(txtIDx220.Value, MainID, EmployeeName, EmployeeID, sisa, 220);
        #endregion

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_SpecialAdd_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_SpecialAdd_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_SpecialAdd_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

        string employname = CommonConst.EMP_GMO_NAME;
        string[] employnames = employname.Split(',');
        string email, msnBody;
        string allsuggestion = da_OfficeAutomation_Flow_Inherit.GetAllSuggestion(MainID);
        for (int i = 0; i < employnames.Length; i++)
        {
            email = employnames[i];
            msnBody = "您好" + employnames[i] + "黄生已复审了" + department + "，编号为" + serialNumber + "的" + documentName + "。<br />黄生的意见：" + txtIDx220.Value + "<br/>申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
            msnBody = msnBody + allsuggestion;
            Common.SendMessageEX(false, email, "请注意，总经理发表了复审意见", msnBody, msnBody);
        }

        //Review(220, txtIDx220.Value);

        if (result.Split('|')[0] == "0")
        {
            RunJS("alert('" + result.Split('|')[1] + "');window.location='" + Page.Request.Url + "'");
        }
        else
        {
            RunJS("alert('" + result.Split('|')[1] + "');");
        }
    }
}