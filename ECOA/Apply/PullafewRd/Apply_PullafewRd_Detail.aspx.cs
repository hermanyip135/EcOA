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
//using System.Collections;//789

using System.Diagnostics; //M_PDF
using System.Web;

using Excel = Microsoft.Office.Interop.Excel;
using DataEntity.PageModel;//2016/8/25 52100

public partial class Apply_PullafewRd_Apply_PullafewRd_Detail : BasePage
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

    //public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();

    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();";

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
        //GetManagers();//789
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
                if (Session["FLG_ReWrite65"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite65"] = null;
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
        DrawDetailTable(1);
        DrawDetailTable2(1);
        DrawDetailTable3(1);
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
        bool IsTempSave = false;        //是否暂存
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
        DA_OfficeAutomation_Document_PullafewRd_Detail_Inherit da_OfficeAutomation_Document_PullafewRd_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_PullafewRd_Detail_Inherit();
        DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit();
        DA_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit da_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit();

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
        DataSet pullafewRd = new DataSet();
        DataSet pullafewRd_Detail = new DataSet();
        DataSet pullafewRd_LeaseTerm = new DataSet();
        DataSet pullafewRd_Statistical = new DataSet();

        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var obj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_PullafewRd_Detail>("PullafewRdDetail", "", Mainobj.OfficeAutomation_SerialNumber);
            pullafewRd = Common.GetPageDetailDS<T_OfficeAutomation_Document_PullafewRd>(obj.PullafewRd, Mainobj);
            pullafewRd_Detail = Common.GetDataSet<T_OfficeAutomation_Document_PullafewRd_Detail>(obj.PullafewRd_Detail);
            pullafewRd_LeaseTerm = Common.GetDataSet<T_OfficeAutomation_Document_PullafewRd_LeaseTerm>(obj.PullafewRd_LeaseTerm);
            pullafewRd_Statistical = Common.GetDataSet<T_OfficeAutomation_Document_PullafewRd_Statistical>(obj.PullafewRd_Statistical);
            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            pullafewRd = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID);
            ID = pullafewRd.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_ID"].ToString();
            pullafewRd_Detail = ds = da_OfficeAutomation_Document_PullafewRd_Detail_Inherit.SelectByID(ID);
            pullafewRd_LeaseTerm = da_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit.SelectByID(ID);
            pullafewRd_Statistical = da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit.SelectByID(ID);
        }
        #region 获取当前申请主表数据
        //获取当前申请主表数据填充ds
        //ds = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID);
        ds = pullafewRd;
        DataRow dr = ds.Tables[0].Rows[0];
        //ID = dr["OfficeAutomation_Document_PullafewRd_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_PullafewRd_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_PullafewRd_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_PullafewRd_Department"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_PullafewRd_ApplyDate"].ToString()).ToString("yyyy-MM-dd");

        txt1a.Text = dr["OfficeAutomation_Document_PullafewRd_1a"].ToString();
        txt1b.Text = dr["OfficeAutomation_Document_PullafewRd_1b"].ToString();
        //txt1c.Text = dr["OfficeAutomation_Document_PullafewRd_1c"].ToString();
        //txt1d.Text = dr["OfficeAutomation_Document_PullafewRd_1d"].ToString();
        //txt1e.Text = dr["OfficeAutomation_Document_PullafewRd_1e"].ToString();
        //txt1f.Text = dr["OfficeAutomation_Document_PullafewRd_1f"].ToString();
        txt1g.Text = dr["OfficeAutomation_Document_PullafewRd_1g"].ToString();
        txt1h.Text = dr["OfficeAutomation_Document_PullafewRd_1h"].ToString();
        txt1i.Text = dr["OfficeAutomation_Document_PullafewRd_1i"].ToString();
        txt1j.Text = dr["OfficeAutomation_Document_PullafewRd_1j"].ToString();
        txt1k.Text = dr["OfficeAutomation_Document_PullafewRd_1k"].ToString();
        txt1l.Text = dr["OfficeAutomation_Document_PullafewRd_1l"].ToString();
        txt1m.Text = dr["OfficeAutomation_Document_PullafewRd_1m"].ToString();
        txt1n.Text = dr["OfficeAutomation_Document_PullafewRd_1n"].ToString();
        txt1o.Text = dr["OfficeAutomation_Document_PullafewRd_1o"].ToString();
        txt1p.Text = dr["OfficeAutomation_Document_PullafewRd_1p"].ToString();
        txt1q.Text = dr["OfficeAutomation_Document_PullafewRd_1q"].ToString();
        txt1r.Text = dr["OfficeAutomation_Document_PullafewRd_1r"].ToString();
        txt1s.Text = dr["OfficeAutomation_Document_PullafewRd_1s"].ToString();
        txt1t.Text = dr["OfficeAutomation_Document_PullafewRd_1t"].ToString();
        txt1ut.Text = dr["OfficeAutomation_Document_PullafewRd_1ut"].ToString();
        txt1u.Text = dr["OfficeAutomation_Document_PullafewRd_1u"].ToString();
        txt1pa.Text = dr["OfficeAutomation_Document_PullafewRd_1pa"].ToString();
        txt1fc.Text = dr["OfficeAutomation_Document_PullafewRd_1fc"].ToString();
        txt1v.Text = dr["OfficeAutomation_Document_PullafewRd_1v"].ToString();

        txt2a.Text = dr["OfficeAutomation_Document_PullafewRd_2a"].ToString();
        txt2b.Text = dr["OfficeAutomation_Document_PullafewRd_2b"].ToString();
        //txt2c.Text = dr["OfficeAutomation_Document_PullafewRd_2c"].ToString();
        //txt2d.Text = dr["OfficeAutomation_Document_PullafewRd_2d"].ToString();
        txt2e.Text = dr["OfficeAutomation_Document_PullafewRd_2e"].ToString();
        txt2f.Text = dr["OfficeAutomation_Document_PullafewRd_2f"].ToString();

        txt4a.Text = dr["OfficeAutomation_Document_PullafewRd_4a"].ToString();
        txt4b.Text = dr["OfficeAutomation_Document_PullafewRd_4b"].ToString();
        txt4c.Text = dr["OfficeAutomation_Document_PullafewRd_4c"].ToString();
        txt4cc.Text = dr["OfficeAutomation_Document_PullafewRd_4cc"].ToString();
        txt4d.Text = dr["OfficeAutomation_Document_PullafewRd_4d"].ToString();
        txt4dd.Text = dr["OfficeAutomation_Document_PullafewRd_4dd"].ToString();
        txt4e.Text = dr["OfficeAutomation_Document_PullafewRd_4e"].ToString();
        txt4f.Text = dr["OfficeAutomation_Document_PullafewRd_4f"].ToString();
        txt4g.Text = dr["OfficeAutomation_Document_PullafewRd_4g"].ToString();
        txt4h.Text = dr["OfficeAutomation_Document_PullafewRd_4h"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        #endregion
        #region 欠客户确认函拉数统计
        //欠客户确认函拉数统计填充ds
        //ds = da_OfficeAutomation_Document_PullafewRd_Detail_Inherit.SelectByID(ID);
        ds = pullafewRd_Detail;
        if (ds != null)
        {
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

                    SbJs.Append("$('#txtDetail_1a" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1a"] + "');");
                    SbJs.Append("$('#txtDetail_1b" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1b"] + "');");
                    SbJs.Append("$('#txtDetail_1i" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1i"] + "');");
                    SbJs.Append("$('#txtDetail_1j" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1j"] + "');");
                    //SbJs.Append("$('#txtDetail_1c" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1c"] + "');");
                    SbJs.Append("$('#txtDetail_1d" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1d"] + "');");
                    SbJs.Append("$('#txtDetail_1e" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1e"] + "');");
                    SbJs.Append("$('#txtDetail_1f" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1f"] + "');");
                    SbJs.Append("$('#txtDetail_1g" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1g"] + "');");
                    SbJs.Append("$('#txtDetail_1h" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Detail_1h"] + "');");
                }
            }
        }
        else {
            DrawDetailTable(1);
        }
        
        #endregion
        #region 欠合同拉数统计
        //欠合同拉数统计填充ds
        //ds = da_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit.SelectByID(ID);
        ds = pullafewRd_LeaseTerm;
        if (ds != null)
        {
            int detailCount3 = ds.Tables[0].Rows.Count;
            if (detailCount3 == 0)
                DrawDetailTable3(1);
            else
            {
                DrawDetailTable3(detailCount3);

                for (int n = 0; n < detailCount3; n++)
                {
                    dr = ds.Tables[0].Rows[n];
                    int i = n + 1;

                    SbJs.Append("$('#txtLeaseTerm_1a" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1a"] + "');");
                    SbJs.Append("$('#txtLeaseTerm_1b" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1b"] + "');");
                    SbJs.Append("$('#txtLeaseTerm_1h" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1h"] + "');");
                    SbJs.Append("$('#txtLeaseTerm_1i" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1i"] + "');");
                    SbJs.Append("$('#txtLeaseTerm_1c" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1c"] + "');");
                    SbJs.Append("$('#txtLeaseTerm_1d" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1d"] + "');");
                    SbJs.Append("$('#txtLeaseTerm_1e" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1e"] + "');");
                    SbJs.Append("$('#txtLeaseTerm_1f" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1f"] + "');");
                    SbJs.Append("$('#txtLeaseTerm_1g" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_LeaseTerm_1g"] + "');");
                }
            }
        }
        else {
            DrawDetailTable3(1);
        }
        #endregion
        #region 实际拉数业绩
        //ds = da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit.SelectByID(ID);
        ds = pullafewRd_Statistical;
        if (ds != null) 
        {
            int detailCount2 = ds.Tables[0].Rows.Count;
            if (detailCount2 == 0)
                DrawDetailTable2(1);
            else
            {
                DrawDetailTable2(detailCount2);

                for (int n = 0; n < detailCount2; n++)
                {
                    dr = ds.Tables[0].Rows[n];
                    int i = n + 1;

                    SbJs.Append("$('#txtStatistical_1a" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1a"] + "');");
                    SbJs.Append("$('#txtStatistical_1b" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1b"] + "');");
                    SbJs.Append("$('#txtStatistical_1c" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1c"] + "');");
                    SbJs.Append("$('#txtStatistical_1d" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1d"] + "');");
                    SbJs.Append("$('#txtStatistical_1e" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1e"] + "');");
                    SbJs.Append("$('#txtStatistical_1f" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1f"] + "');");
                    SbJs.Append("$('#txtStatistical_1g" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1g"] + "');");
                    SbJs.Append("$('#txtStatistical_1h" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1h"] + "');");
                    SbJs.Append("$('#txtStatistical_1i" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1i"] + "');");
                    SbJs.Append("$('#txtStatistical_1j" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1j"] + "');");
                    SbJs.Append("$('#txtStatistical_1jk" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1jk"] + "');");
                    SbJs.Append("$('#txtStatistical_1l" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1l"] + "');");
                    SbJs.Append("$('#txtStatistical_1m" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1m"] + "');");
                    SbJs.Append("$('#txtStatistical_1k" + i + "').val('" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1k"] + "');");
                }
            }
        } else {
            DrawDetailTable2(1);
        }
        
        #endregion
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;

        //try
        //{
        //    if (drc[4]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
        //        SbJs.Append("$(\"#btnUpload\").hide();");
        //    else
        //        SbJs.Append("$(\"#btnUpload\").show();");
        //}
        //catch
        //{
        //SbJs.Append("$(\"#btnUpload\").show();");
        //}
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
        //if (EmployeeID == "19173" || EmployeeID == "16947" || EmployeeID == "39591")
        //{
        //    btnSave.Visible = true;
        //}

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

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
            btnSignSave.Visible = true;

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
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
        }
        catch
        {
            if (isApplicant && !IsTempSave)
                btnReWrite.Visible = true; //*-+
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        //DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        //if (Purview.Contains("OA_Search_002"))//789
        //    GetAllDepartment();
        //if (EmployeeID == "10054")
        //    SbJs.Append("$(\"#afa\").show();$(\"#dfd\").show();");
        ////foreach (DataRow drs in drc)
        ////{
        ////    string idx = drs["OfficeAutomation_Flow_Idx"].ToString();
        ////    if (!Regex.IsMatch(((float.Parse(idx) - 1) / 3.0).ToString(), "^[0-9]*[1-9][0-9]*$"))
        ////        SbJs.Append("$('#divIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();$('#divTxtIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();");
        ////    SbJs.Append("$('#txtIDxa" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_Employee"] + ",');");
        ////    //SbJs.Append("$('#hdIDx" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_EmployeeID"] + "');");
        ////}
        //DataSet ds2 = new DataSet();
        //bool x2 = false, x3 = false;
        //ds2 = da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SelectByID(ID);
        //int LogisticsFlowCount = ds2.Tables[0].Rows.Count;
        //ViewState["FSIN"] = "";
        //if (LogisticsFlowCount == 0)
        //{
        //    //if (isApplicant)
        //    //    DrawDetailTable(1);
        //}
        //else
        //{
        //    //if (isApplicant)
        //    //    DrawDetailTable(LogisticsFlowCount / 3);
        //    for (int n = 0, i = 1; n < LogisticsFlowCount; n++, i++)
        //    {
        //        dr = ds2.Tables[0].Rows[n];
        //        SbJs.Append("$('#txtDpm" + i + "').val('" + dr["OfficeAutomation_Document_GeneralApply_Detail_Department"] + "');");
        //        SbJs.Append("$('#rdoIsCmodel" + i + "1" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
        //        if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
        //            ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
        //        n++;
        //        dr = ds2.Tables[0].Rows[n];
        //        x2 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
        //        SbJs.Append("$('#rdoIsCmodel" + i + "2" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
        //        if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
        //            ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
        //        n++;
        //        dr = ds2.Tables[0].Rows[n];
        //        x3 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
        //        SbJs.Append("$('#rdoIsCmodel" + i + "3" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
        //        if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
        //            ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
        //        DrawAFTable(i, x2, x3, dr["OfficeAutomation_Document_GeneralApply_Detail_Department"].ToString());
        //    }
        //}//987

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
                SbJs.Append("$(\"#trShowFlow4\").hide();$(\"#trShowFlow5\").prepend('<td>法律部意见</td>');");
                SbJs.Append("$(\"#trShowFlow6\").hide();$(\"#trShowFlow7\").hide();$(\"#trShowFlow8\").prepend('<td>财务部意见</td>');");
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
                        case "6":
                            ckbAddIDx7.Visible = true;
                            break;
                        //case "7":
                        //    if (EmployeeID == "13545") //M_AddNWX：20150511
                        //        lbtnAddN.Visible = true;
                        //    break;
                        //default:
                        //    break;
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
        //    SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();$('#trGeneralManager').show();");

        //T_OfficeAutomation_Flow flows;//789
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        //if (flows != null)
        //    SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && applicant == EmployeeName && !tpdf)// && showf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

        //if (!showf) //M_HideFlows：20150330
        //    SbFlow.Length = 0;

        //if (EmployeeID == "10054" || EmployeeID == "34498") //M_WinnEnd：20150204
        //    btnWillEnd.Visible = true;
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(MainID, "0001");
        //if (flows == null)
        //    SbJs.Append("$('#trGeneralManager').hide();$('#tlsc2').hide();");

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

            SbHtml.Append("<td><textarea id=\"txtDetail_1a" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDetail_1b" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDetail_1i" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDetail_1j" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            //SbHtml.Append("<td><textarea id=\"txtDetail_1c" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDetail_1d" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDetail_1e" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDetail_1f" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDetail_1g" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml.Append("<td><textarea id=\"txtDetail_1h" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");

            SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable3(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml3.Append("<tr id=\"trDetail3" + i + "\">");

            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1a" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1b" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1h" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1i" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1c" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1d" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1e" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1f" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml3.Append("<td><textarea id=\"txtLeaseTerm_1g" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");

            SbHtml3.Append("</tr>");
        }
        SbJs.Append("i3=" + n + ";");
    }

    public void DrawDetailTable2(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml2.Append("<tr id=\"trDetail2" + i + "\">");

            SbHtml2.Append("<td><textarea id=\"txtStatistical_1a" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1b" + i + "\" style=\"width: 80px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1c" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1d" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1e" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1f" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1g" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1h" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1i" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1j" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1jk" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1l" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1m" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");
            SbHtml2.Append("<td><textarea id=\"txtStatistical_1k" + i + "\" style=\"width: 50px; overflow: hidden;\" rows=\"1\"></textarea></td>");

            SbHtml2.Append("</tr>");
        }
        SbJs.Append("i2=" + n + ";");
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
        T_OfficeAutomation_Document_PullafewRd t_OfficeAutomation_Document_PullafewRd = new T_OfficeAutomation_Document_PullafewRd();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
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

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "PullafewRd" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 60; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_PullafewRd = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtApplyID.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_PullafewRd_Inherit.Insert(t_OfficeAutomation_Document_PullafewRd);//插入申请表

                InsertPullafewRdDetail(t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_ID);
                InsertPullafewRdDetail2(t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_ID);
                InsertPullafewRdDetail3(t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_ID);

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

                Common.AddLog(EmployeeID, EmployeeName, 64, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_PullafewRd_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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

                        #endregion
                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_PullafewRd_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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

    //暂时保存
    protected void btnTempSave_Click(object sender, EventArgs e)
    {
        var SerialNumber = "PullafewRd" + DateTime.Now.ToString("yyyyMMddHHmmssfffff");
        var DocumentID = 60;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        var PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();

        //插入公共主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName,txtDepartment.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }
       
        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        T_OfficeAutomation_Document_PullafewRd PullafewRd = new T_OfficeAutomation_Document_PullafewRd();
        ds = PullafewRd_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            PullafewRd = GetModelFromPage(Guid.NewGuid());
        }
        else
        {
            var PullafewRd_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_ID"].ToString();
            PullafewRd = GetModelFromPage(new Guid(PullafewRd_ID));
        }
        var obj = new Apply_PullafewRd_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;
        //var PullafewRd = GetModelFromPage(Guid.NewGuid());
        PullafewRd_Inherit.HandleBase(PullafewRd);//当前申请主表
        obj.PullafewRd = PullafewRd;
        obj.PullafewRd_Detail = GetPullafewRdDetail(PullafewRd.OfficeAutomation_Document_PullafewRd_ID);
        obj.PullafewRd_LeaseTerm = GetPullafewRdDetail3(PullafewRd.OfficeAutomation_Document_PullafewRd_ID);
        obj.PullafewRd_Statistical = GetPullafewRdDetail2(PullafewRd.OfficeAutomation_Document_PullafewRd_ID);
        //暂存数据保存到xml文件中
        var result = new Common().SaveTempSaveFile<Apply_PullafewRd_Detail>(obj, "PullafewRdDetail", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
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
            Common.AddLog(EmployeeID, EmployeeName, 64, new Guid(MainID), 8);
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
        DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
        DA_OfficeAutomation_Document_PullafewRd_Detail_Inherit da_OfficeAutomation_Document_PullafewRd_Detail_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Detail_Inherit();
        DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit();

        DataSet ds = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_PullafewRd_ID"].ToString();

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

                if (flowIDx == "6") //M_Add：黄志超 20150202
                {
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                    if (ckbAddIDx7.Checked)//增加审批环节是否勾选，如果是则添加第7步黄志超审批
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 7;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                //如果为第0步流程则为其一审核即可通过，其他为同时审核。
                //string[] flowN;
                //flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = flowIDx == "4" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                //bool isSignSuccess = flowIDx == "5" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_PullafewRd_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_PullafewRd_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_PullafewRd_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_PullafewRd_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>发文编号: " + drRow["OfficeAutomation_Document_PullafewRd_ApplyID"].ToString());
                    sbMailBody.Append("<br/><br/>");

                    sbMailBody.Append("<br/>三级市场一手项目欠必要性文件拉数申请：");
                    ds = da_OfficeAutomation_Document_PullafewRd_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>统筹区域：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1a"]);
                        sbMailBody.Append("<br/>楼盘名称：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1b"]);
                        sbMailBody.Append("<br/>统筹人：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1i"]);
                        sbMailBody.Append("<br/>项目所在地：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1j"]);
                        sbMailBody.Append("<br/>代理期：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1c"]);
                        sbMailBody.Append("<br/>成交总宗数：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1d"]);
                        sbMailBody.Append("<br/>成交总业绩：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1e"]);
                        sbMailBody.Append("<br/>宗数：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1f"]);
                        sbMailBody.Append("<br/>欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1g"]);
                        sbMailBody.Append("<br/>拉数原因：" + dr["OfficeAutomation_Document_PullafewRd_Detail_1h"]);
                        sbMailBody.Append("<br/>");
                    }
                    sbMailBody.Append("<br/>");

                    sbMailBody.Append("<br/>三级市场自接项目各成交区域实际拉数业绩：");
                    ds = da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>统筹区域：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1a"]);
                        sbMailBody.Append("<br/>楼盘名称：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1b"]);
                        sbMailBody.Append("<br/>海珠区欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1c"]);
                        sbMailBody.Append("<br/>天河区欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1d"]);
                        sbMailBody.Append("<br/>白云区欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1e"]);
                        sbMailBody.Append("<br/>越秀区欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1f"]);
                        sbMailBody.Append("<br/>花都欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1g"]);
                        sbMailBody.Append("<br/>番禺欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1h"]);
                        sbMailBody.Append("<br/>工商铺（罗思源)欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1i"]);
                        sbMailBody.Append("<br/>工商铺（谢伟中）欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1j"]);
                        sbMailBody.Append("<br/>项目部欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1jk"]);
                        sbMailBody.Append("<br/>合计欠收业绩：" + dr["OfficeAutomation_Document_PullafewRd_Statistical_1k"]);
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

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）梁晶晶（工号：32188）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            employname = CommonConst.EMP_GMO_NAME;
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
        //    DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_PullafewRd_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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

    #region 从页面中获得model

    private T_OfficeAutomation_Document_PullafewRd GetModelFromPage(Guid PullafewRdID)
    {
        T_OfficeAutomation_Document_PullafewRd t_OfficeAutomation_Document_PullafewRd = new T_OfficeAutomation_Document_PullafewRd();
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_ID = PullafewRdID;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_Apply = EmployeeName;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_ApplyDate = DateTime.Now;

        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1a = txt1a.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1b = txt1b.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1c = "";
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1d = "";
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1e = "";
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1f = "";
        //t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1c = txt1c.Text;
        //t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1d = txt1d.Text;
        //t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1e = txt1e.Text;
        //t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1f = txt1f.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1g = txt1g.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1h = txt1h.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1i = txt1i.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1j = txt1j.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1k = txt1k.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1l = txt1l.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1m = txt1m.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1n = txt1n.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1o = txt1o.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1p = txt1p.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1q = txt1q.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1r = txt1r.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1s = txt1s.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1t = txt1t.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1ut = txt1ut.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1u = txt1u.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1v = txt1v.Text;

        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_2a = txt2a.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_2b = txt2b.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_2c = "";
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_2d = "";
        //t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_2c = txt2c.Text;
        //t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_2d = txt2d.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_2e = txt2e.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_2f = txt2f.Text;

        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4a = txt4a.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4b = txt4b.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4c = txt4c.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4cc = txt4cc.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4d = txt4d.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4dd = txt4dd.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4e = txt4e.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4f = txt4f.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4g = txt4g.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_4h = txt4h.Text;

        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1pa = txt1pa.Text;
        t_OfficeAutomation_Document_PullafewRd.OfficeAutomation_Document_PullafewRd_1fc = txt1fc.Text;
        return t_OfficeAutomation_Document_PullafewRd;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_PullafewRd t_OfficeAutomation_Document_PullafewRd = new T_OfficeAutomation_Document_PullafewRd();
        DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_ID"].ToString();

        t_OfficeAutomation_Document_PullafewRd = GetModelFromPage(new Guid(ID));

        string apply = EmployeeName;
        string depname = this.txtDepartment.Text;
        string summary = this.txtApplyID.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_PullafewRd_Inherit.Update(t_OfficeAutomation_Document_PullafewRd);//修改申请表

        DA_OfficeAutomation_Document_PullafewRd_Detail_Inherit da_OfficeAutomation_Document_PullafewRd_Detail_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Detail_Inherit();
        da_OfficeAutomation_Document_PullafewRd_Detail_Inherit.Delete(ID);
        InsertPullafewRdDetail(new Guid(ID));

        DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit();
        da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit.Delete(ID);
        InsertPullafewRdDetail2(new Guid(ID));

        DA_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit da_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit = new DA_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit();
        da_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit.Delete(ID);
        InsertPullafewRdDetail3(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 64, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增明细

    /// <summary>
    /// 新增广告宣传需求申请摊分情况表
    /// </summary>
    /// <param name="gPullafewRdID"></param>
    private void InsertPullafewRdDetail(Guid gPullafewRdID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_PullafewRd_Detail t_OfficeAutomation_Document_PullafewRd_Detail;
        DA_OfficeAutomation_Document_PullafewRd_Detail_Inherit da_OfficeAutomation_Document_PullafewRd_Detail_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                //if (detail[0] == "")
                //    continue;
                t_OfficeAutomation_Document_PullafewRd_Detail = new T_OfficeAutomation_Document_PullafewRd_Detail();
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_MainID = gPullafewRdID;

                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1a = detail[0];
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1b = detail[1];
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1c = "";
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1d = detail[2];
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1e = detail[3];
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1f = detail[4];
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1g = detail[5];
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1h = detail[6];
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1i = detail[7];
                t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1j = detail[8];

                da_OfficeAutomation_Document_PullafewRd_Detail_Inherit.Insert(t_OfficeAutomation_Document_PullafewRd_Detail);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }
    /// <summary>
    /// 新增三级市场一手项目欠必要性文件拉数申请欠合同拉数统计表
    /// </summary>
    /// <param name="gPullafewRdID"></param>
    private void InsertPullafewRdDetail3(Guid gPullafewRdID)
    {
        if (hdDetail3.Value == "")
            return;

        T_OfficeAutomation_Document_PullafewRd_LeaseTerm t_OfficeAutomation_Document_PullafewRd_LeaseTerm;
        DA_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit da_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit = new DA_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit();

        string[] details = Regex.Split(hdDetail3.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                //if (detail[0] == "")
                //    continue;
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm = new T_OfficeAutomation_Document_PullafewRd_LeaseTerm();
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_MainID = gPullafewRdID;

                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1a = detail[0];
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1b = detail[1];
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1c = detail[2];
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1d = detail[3];
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1e = detail[4];
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1f = detail[5];
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1g = detail[6];
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1h = detail[7];
                t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1i = detail[8];

                da_OfficeAutomation_Document_PullafewRd_LeaseTerm_Inherit.Insert(t_OfficeAutomation_Document_PullafewRd_LeaseTerm);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }
    /// <summary>
    /// 新增广告宣传需求申请送货清单表
    /// </summary>
    /// <param name="gPullafewRdID"></param>
    private void InsertPullafewRdDetail2(Guid gPullafewRdID)
    {
        if (hdDetail2.Value == "")
            return;

        T_OfficeAutomation_Document_PullafewRd_Statistical t_OfficeAutomation_Document_PullafewRd_Statistical;
        DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit();

        string[] details = Regex.Split(hdDetail2.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                //if (detail[0] == "")
                //    continue;
                t_OfficeAutomation_Document_PullafewRd_Statistical = new T_OfficeAutomation_Document_PullafewRd_Statistical();
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_MainID = gPullafewRdID;

                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1a = detail[0];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1b = detail[1];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1c = detail[2];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1d = detail[3];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1e = detail[4];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1f = detail[5];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1g = detail[6];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1h = detail[7];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1i = detail[8];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1j = detail[9];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1jk = detail[10];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1k = detail[11];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1l = detail[12];
                t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1m = detail[13];
                da_OfficeAutomation_Document_PullafewRd_Statistical_Inherit.Insert(t_OfficeAutomation_Document_PullafewRd_Statistical);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    //临时保存数据

    //欠客户确认函拉数统计
    private List<T_OfficeAutomation_Document_PullafewRd_Detail> GetPullafewRdDetail(Guid gPullafewRdID)
    {
        var list = new List<T_OfficeAutomation_Document_PullafewRd_Detail>();
        if (hdDetail.Value == "")
            return null;

        T_OfficeAutomation_Document_PullafewRd_Detail t_OfficeAutomation_Document_PullafewRd_Detail;
        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_PullafewRd_Detail = new T_OfficeAutomation_Document_PullafewRd_Detail();
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_MainID = gPullafewRdID;

            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1a = detail[0];
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1b = detail[1];
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1c = "";
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1d = detail[2];
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1e = detail[3];
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1f = detail[4];
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1g = detail[5];
            t_OfficeAutomation_Document_PullafewRd_Detail.OfficeAutomation_Document_PullafewRd_Detail_1h = detail[6];

            list.Add(t_OfficeAutomation_Document_PullafewRd_Detail);
        }
        return list;
    }
    //欠合同拉数统计
    private List<T_OfficeAutomation_Document_PullafewRd_LeaseTerm> GetPullafewRdDetail3(Guid gPullafewRdID)
    {
        var list = new List<T_OfficeAutomation_Document_PullafewRd_LeaseTerm>();
        if (hdDetail3.Value == "")
            return null;

        T_OfficeAutomation_Document_PullafewRd_LeaseTerm t_OfficeAutomation_Document_PullafewRd_LeaseTerm;
        string[] details = Regex.Split(hdDetail3.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm = new T_OfficeAutomation_Document_PullafewRd_LeaseTerm();
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_MainID = gPullafewRdID;

            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1a = detail[0];
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1b = detail[1];
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1c = detail[2];
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1d = detail[3];
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1e = detail[4];
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1f = detail[5];
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1g = detail[6];
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1h = detail[7];
            t_OfficeAutomation_Document_PullafewRd_LeaseTerm.OfficeAutomation_Document_PullafewRd_LeaseTerm_1i = detail[8];
            list.Add(t_OfficeAutomation_Document_PullafewRd_LeaseTerm);
        }
        return list;
    }
    //实际拉数业绩
    private List<T_OfficeAutomation_Document_PullafewRd_Statistical> GetPullafewRdDetail2(Guid gPullafewRdID)
    {
        var list = new List<T_OfficeAutomation_Document_PullafewRd_Statistical>();
        if (hdDetail2.Value == "")
            return null;

        T_OfficeAutomation_Document_PullafewRd_Statistical t_OfficeAutomation_Document_PullafewRd_Statistical;
        string[] details = Regex.Split(hdDetail2.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_PullafewRd_Statistical = new T_OfficeAutomation_Document_PullafewRd_Statistical();
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_MainID = gPullafewRdID;

            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1a = detail[0];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1b = detail[1];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1c = detail[2];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1d = detail[3];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1e = detail[4];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1f = detail[5];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1g = detail[6];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1h = detail[7];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1i = detail[8];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1j = detail[9];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1jk = detail[10];
            t_OfficeAutomation_Document_PullafewRd_Statistical.OfficeAutomation_Document_PullafewRd_Statistical_1k = detail[11];

            list.Add(t_OfficeAutomation_Document_PullafewRd_Statistical);
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
        Session["FLG_ReWrite65"] = "1";
        Response.Write("<script>window.open('Apply_PullafewRd_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("三级市场一手项目欠必要性文件拉数申请.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }
    ///// <summary>
    ///// 获取所有四级以上前线经理//789
    ///// </summary>
    //private void GetManagers()
    //{
    //    wsFinance.Service service = new wsFinance.Service();
    //    DataSet dsManagers = service.GetManages();
    //    SbJsonf.Append("[");
    //    foreach (DataRow dr in dsManagers.Tables[0].Rows)
    //    {
    //        SbJsonf.Append("\"" + dr["EmployeeName"] + "\",");
    //    }
    //    SbJsonf.Remove(SbJsonf.Length - 1, 1);
    //    SbJsonf.Append("]");
    //}
    //protected void btnSaveLogisticsFlow_Click(object sender, EventArgs e)
    //{
    //    if (hdLogisticsFlow.Value == "")
    //        return;
    //    T_OfficeAutomation_Document_GeneralApply_Detail t_OfficeAutomation_Document_GeneralApply_Detail;
    //    DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
    //    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
    //    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
    //    T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

    //    DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
    //    DataSet ds = new DataSet();
    //    ds = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID);
    //    ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_ID"].ToString(); //在不同的表要注意修改

    //    da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Delete(ID);
    //    string[] details = Regex.Split(hdLogisticsFlow.Value, "\\|\\|");
    //    for (int i = 0; i < details.Length; i++)
    //    {
    //        string[] detail = Regex.Split(details[i], "\\&\\&");
    //        t_OfficeAutomation_Document_GeneralApply_Detail = new T_OfficeAutomation_Document_GeneralApply_Detail();
    //        t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_ID = Guid.NewGuid();
    //        t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_MainID = new Guid(ID);
    //        t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Department = detail[0];
    //        t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Num = int.Parse(detail[1]);
    //        t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Branch = detail[2];
    //        t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Cmodel = detail[3] == "1";
    //        t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_IsOpen = detail[4] == "1";
    //if (detail[0].ToString() != "董事总经理" && detail[0].ToString() != "总经办")
    //        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Insert(t_OfficeAutomation_Document_GeneralApply_Detail);
    //    }
    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 130;
    //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID; //在不同的表要注意删除
    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 131;
    //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

    //    RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    //}
    //protected void btnWillEnd_Click(object sender, EventArgs e) //M_WinnEnd：20150204
    //{
    //    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
    //    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
    //    da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "0001");
    //    DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
    //    da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "总经办");
    //    da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "董事总经理");
    //    da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "董事总经理审批");
    //    da_OfficeAutomation_Main_Inherit.UpdateFlowStateForAudit(MainID);
    //    Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
    //    RunJS("alert('已删除总经办的审批环节！');window.location='" + Page.Request.Url + "'");
    //}
    //public void DrawAFTable(int n, bool x2, bool x3, string department)
    //{
    //    for (int i = 1; i <= 1; i++)
    //    {
    //        int j = 0, k = 3 * n;
    //        if (x2 && x3)
    //            j = 3;
    //        else if ((!x2 && x3) || (x2 && !x3))
    //            j = 2;
    //        else if (!x2 && !x3)
    //            j = 1;
    //        SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
    //        SbHtmlLogisticsFlow.Append("<td rowspan=\"" + j + "\"  class=\"auto-style1\">" + department + "</td>");
    //        SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
    //        SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
    //        SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20 - 2) + "\">同意</label>");
    //        SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
    //        SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20 - 2) + "\">不同意</label>");
    //        SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
    //        SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20 - 2) + "\">其他意见</label>");
    //        SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20 - 2) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
    //        SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20 - 2) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20 - 2) + "\')\" style=\"display: none;\" />");
    //        SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20 - 2) + "\">_________</span></div>");
    //        SbHtmlLogisticsFlow.Append("</td>");
    //        SbHtmlLogisticsFlow.Append("</tr>");
    //        if (x2)
    //        {
    //            SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
    //            SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
    //            SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
    //            SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20 - 1) + "\">同意</label>");
    //            SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
    //            SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20 - 1) + "\">不同意</label>");
    //            SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
    //            SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20 - 1) + "\">其他意见</label>");
    //            SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20 - 1) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
    //            SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20 - 1) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20 - 1) + "\')\" style=\"display: none;\" />");
    //            SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20 - 1) + "\">_________</span></div>");
    //            SbHtmlLogisticsFlow.Append("</td>");
    //            SbHtmlLogisticsFlow.Append("</tr>");
    //        }
    //        if (x3)
    //        {
    //            SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
    //            SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
    //            SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
    //            SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20) + "\">同意</label>");
    //            SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
    //            SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20) + "\">不同意</label>");
    //            SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
    //            SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20) + "\">其他意见</label>");
    //            SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
    //            SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20) + "\')\" style=\"display: none;\" />");
    //            SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20) + "\">_________</span></div>");
    //            SbHtmlLogisticsFlow.Append("</td>");
    //            SbHtmlLogisticsFlow.Append("</tr>");
    //        }
    //    }
    //    SbJs.Append("i=" + n + ";");
    //}//987
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
            DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
            DataSet ds = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_PullafewRd_Department"].ToString();
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
                //if (i <= 7 && EmployeeID == "13545") //M_AddNWX：20150511
                //{
                //    da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "黄志超", "13545");
                //    da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                //}
                if (i < 7)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
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
            DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
            DataSet ds = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_PullafewRd_Department"].ToString();
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
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
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
            DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
            DataSet ds = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_PullafewRd_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_PullafewRd_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    //protected void lbtnAddN_Click(object sender, EventArgs e) //M_AddNWX：20150511
    //{
    //    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
    //    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
    //    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

    //    da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "宁伟雄,黄志超", "5585,13545");
    //    Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1); //添加日志，添加流程
    //    RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    //}

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
            if (!se.Contains("1900-01-01 0:00:00")) sug = se;
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
        DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_PullafewRd_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
        DataSet ds = da_OfficeAutomation_Document_PullafewRd_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_PullafewRd_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_PullafewRd_Department"].ToString();
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
        DA_OfficeAutomation_Document_PullafewRd_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_PullafewRd_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_PullafewRd_Department"].ToString();
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
    protected void btnImport_Click(object sender, EventArgs e)
    {
        SbJs.Append("<script type=\"text/javascript\">$(\"#btnUpload\").show();" + ApplyDisplayPart);
        string path = hdFilePath.Value;

        Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new Excel.ApplicationClass();
        //Excel.Workbooks workBooks = excelApp.Workbooks;
        excelApp.Application.Workbooks.Add(true);
        Excel.Workbook wb = excelApp.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
        int rowCount = ws.UsedRange.Rows.Count;

        //Excel.Range ran = ws.get_Range("D2", "F2");
        Excel.Range ran = ws.get_Range("G2", "H2");
        object[,] value = (object[,])ran.Value2;
        Excel.Range range = ws.get_Range("A4", "I" + rowCount);
        object[,] values = (object[,])range.Value2;

        int i, success1 = 0, success2 = 0, success3 = 0;
        float tg = 0, th = 0, ti = 0, tii = 0, tj = 0;

      //  string st1 = value[1, 1].ToString().Trim(), st2 = value[1, 2].ToString().Trim(), st3 = value[1, 3].ToString().Trim();
        string st1 = value[1, 1].ToString().Trim();
        try
        {
            txt1a.Text = st1.Substring(0, st1.IndexOf("年"));
            txt1b.Text = st1.Substring(st1.IndexOf("年") + 1, st1.IndexOf("月") - st1.IndexOf("年") - 1);
            //txt1c.Text = st2.Substring(0, st2.IndexOf("年"));
            //txt1d.Text = st2.Substring(st2.IndexOf("年") + 1, st2.IndexOf("月") - st2.IndexOf("年") - 1);
            //txt1e.Text = st3.Substring(0, st3.IndexOf("年"));
            //txt1f.Text = st3.Substring(st3.IndexOf("年") + 1, st3.IndexOf("月") - st3.IndexOf("年") - 1);

            for (i = 1; i <= range.Rows.Count; i++)
            {
                try
                {
                    if (values[i, 2] !=null &&!string.IsNullOrEmpty(values[i, 2].ToString()))
                    {
                        success1++;
                        SbJs.Append("$('#txtDetail_1a" + i + "').val('" + values[i, 1].ToString().Trim() + "');");
                        SbJs.Append("$('#txtDetail_1b" + i + "').val('" + values[i, 2].ToString().Trim() + "');");
                        SbJs.Append("$('#txtDetail_1i" + i + "').val('" + values[i, 3].ToString().Trim() + "');");
                        SbJs.Append("$('#txtDetail_1j" + i + "').val('" + values[i, 4].ToString().Trim() + "');");
                        SbJs.Append("$('#txtDetail_1d" + i + "').val('" + values[i, 5].ToString().Trim() + "');");
                        SbJs.Append("$('#txtDetail_1e" + i + "').val('" + values[i, 6].ToString().Trim() + "');");
                        SbJs.Append("$('#txtDetail_1f" + i + "').val('" + values[i, 7].ToString().Trim() + "');");
                        SbJs.Append("$('#txtDetail_1g" + i + "').val('" + values[i, 8].ToString().Trim() + "');");
                        SbJs.Append("$('#txtDetail_1h" + i + "').val('" + values[i, 9].ToString().Trim() + "');");
                        //SbJs.Append("$('#txtDetail_1c" + i + "').val('" + values[i, 5].ToString().Trim() + "');");
                        //SbJs.Append("$('#txtDetail_1d" + i + "').val('" + values[i, 6].ToString().Trim() + "');");
                        //SbJs.Append("$('#txtDetail_1e" + i + "').val('" + values[i, 7].ToString().Trim() + "');");
                        //SbJs.Append("$('#txtDetail_1f" + i + "').val('" + values[i, 8].ToString().Trim() + "');");
                        //SbJs.Append("$('#txtDetail_1g" + i + "').val('" + values[i, 9].ToString().Trim() + "');");
                    //    SbJs.Append("$('#txtDetail_1h" + i + "').val('" + values[i, 10].ToString().Trim() + "');");

                        tg += float.Parse(values[i, 5].ToString().Trim());
                        th += float.Parse(values[i, 6].ToString().Trim());
                        ti += float.Parse(values[i, 7].ToString().Trim());
                        tii += float.Parse(values[i, 8].ToString().Trim());
                    }
                }
                catch
                {
                }
            }
            txt1g.Text = tg.ToString();
            txt1h.Text = th.ToString();
            txt1i.Text = ti.ToString();
            txt1j.Text = tii.ToString();
            DrawDetailTable(success1);






            ws = (Excel.Worksheet)wb.Worksheets[2];
            rowCount = ws.UsedRange.Rows.Count;
            ran = ws.get_Range("F2", "G2");
            value = (object[,])ran.Value2;
            range = ws.get_Range("A3", "H" + rowCount);
            values = (object[,])range.Value2;
            tg = 0; th = 0; ti = 0; tii = 0; tj = 0;

            st1 = value[1, 1].ToString().Trim();
          //  st2 = value[1, 2].ToString().Trim();
            txt2a.Text = st1.Substring(0, st1.IndexOf("年"));
            txt2b.Text = st1.Substring(st1.IndexOf("年") + 1, st1.IndexOf("月") - st1.IndexOf("年") - 1);
            //txt2c.Text = st2.Substring(0, st2.IndexOf("年"));
            //txt2d.Text = st2.Substring(st2.IndexOf("年") + 1, st2.IndexOf("月") - st2.IndexOf("年") - 1);

            for (i = 1; i <= range.Rows.Count; i++)
            {
                try
                {
                    if (values[i, 2] != null && !string.IsNullOrEmpty(values[i, 2].ToString()))
                    {
                        success3++;
                        SbJs.Append("$('#txtLeaseTerm_1a" + i + "').val('" + values[i, 1].ToString().Trim() + "');");
                        SbJs.Append("$('#txtLeaseTerm_1b" + i + "').val('" + values[i, 2].ToString().Trim() + "');");
                        SbJs.Append("$('#txtLeaseTerm_1h" + i + "').val('" + values[i, 3].ToString().Trim() + "');");
                        SbJs.Append("$('#txtLeaseTerm_1i" + i + "').val('" + values[i, 4].ToString().Trim() + "');");
                        SbJs.Append("$('#txtLeaseTerm_1c" + i + "').val('" + values[i, 5].ToString().Trim() + "');");
                        SbJs.Append("$('#txtLeaseTerm_1d" + i + "').val('" + values[i, 6].ToString().Trim() + "');");
                        SbJs.Append("$('#txtLeaseTerm_1e" + i + "').val('" + values[i, 7].ToString().Trim() + "');");
                        SbJs.Append("$('#txtLeaseTerm_1f" + i + "').val('" + values[i, 8].ToString().Trim() + "');");

                        tg += float.Parse(values[i, 6].ToString().Trim());
                        th += float.Parse(values[i, 7].ToString().Trim());
                    }
                }
                catch
                {
                }
            }
            txt2e.Text = tg.ToString();
            txt2f.Text = th.ToString();
            DrawDetailTable3(success3);











            ws = (Excel.Worksheet)wb.Worksheets[3];
            rowCount = ws.UsedRange.Rows.Count;
            ran = ws.get_Range("C2", "C2");
            //value = (object[,])ran.Value2;
            range = ws.get_Range("A4", "N" + rowCount);
            values = (object[,])range.Value2;
            tg = 0; th = 0; ti = 0; tii = 0; tj = 0;
            float tr = 0, ts = 0, tt = 0, tv = 0, tu = 0,pa =0,fc =0, kk;

            st1 = ran.Value2.ToString();
            txt1k.Text = st1.Substring(0, st1.IndexOf("年"));
            txt1l.Text = st1.Substring(st1.IndexOf("年") + 1, st1.IndexOf("月") - st1.IndexOf("年") - 1);

            for (i = 1; i <= range.Rows.Count; i++)
            {
                try
                {
                    if (values[i, 2] != null && !string.IsNullOrEmpty(values[i, 2].ToString()))
                    {
                        success2++;
                        kk = float.Parse(values[i, 3].ToString().Trim())
                            + float.Parse(values[i, 4].ToString().Trim())
                            + float.Parse(values[i, 5].ToString().Trim())
                            + float.Parse(values[i, 6].ToString().Trim())
                            + float.Parse(values[i, 7].ToString().Trim())
                            + float.Parse(values[i, 8].ToString().Trim())
                            + float.Parse(values[i, 9].ToString().Trim())
                            + float.Parse(values[i, 10].ToString().Trim())
                            + float.Parse(values[i, 11].ToString().Trim());
                        SbJs.Append("$('#txtStatistical_1a" + i + "').val('" + values[i, 1].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1b" + i + "').val('" + values[i, 2].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1c" + i + "').val('" + values[i, 3].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1d" + i + "').val('" + values[i, 4].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1e" + i + "').val('" + values[i, 5].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1f" + i + "').val('" + values[i, 6].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1g" + i + "').val('" + values[i, 7].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1h" + i + "').val('" + values[i, 8].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1i" + i + "').val('" + values[i, 9].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1j" + i + "').val('" + values[i, 10].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1jk" + i + "').val('" + values[i, 11].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1l" + i + "').val('" + values[i, 12].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1m" + i + "').val('" + values[i, 13].ToString().Trim() + "');");
                        SbJs.Append("$('#txtStatistical_1k" + i + "').val('" + kk + "');");

                        tg += float.Parse(values[i, 3].ToString().Trim());
                        th += float.Parse(values[i, 4].ToString().Trim());
                        ti += float.Parse(values[i, 5].ToString().Trim());
                        tii += float.Parse(values[i, 6].ToString().Trim());
                        tj += float.Parse(values[i, 7].ToString().Trim());
                        tr += float.Parse(values[i, 8].ToString().Trim());
                        ts += float.Parse(values[i, 9].ToString().Trim());
                        tt += float.Parse(values[i, 10].ToString().Trim());
                        tv += float.Parse(values[i, 11].ToString().Trim());
                        pa += float.Parse(values[i, 12].ToString().Trim());
                        fc += float.Parse(values[i, 13].ToString().Trim());
                        tu += kk;
                    }
                }
                catch
                {
                }
            }
            txt1m.Text = tg.ToString();
            txt1n.Text = th.ToString();
            txt1o.Text = ti.ToString();
            txt1p.Text = tii.ToString();
            txt1q.Text = tj.ToString();
            txt1r.Text = tr.ToString();
            txt1s.Text = ts.ToString();
            txt1t.Text = tt.ToString();
            txt1ut.Text = tv.ToString();
            txt1u.Text = tu.ToString();
            txt1pa.Text = pa.ToString();
            txt1fc.Text = fc.ToString();
            DrawDetailTable2(success2);
        }
        catch (Exception ee)
        {
            RunJS("alert('导入失败，错误原因：" + ee.Message + "');window.location.href='" + Page.Request.Url + "';");
        }
        finally
        {
            GetAllDepartment();
            btnSave.Visible = true;
            SbJs.Append("</script>");

            #region 关闭、回收
            if (ws != null)
            {
                while (System.Runtime.InteropServices.Marshal.ReleaseComObject(ws) > 1) ;
                ws = null;
            }
            if (wb != null)
            {
                wb.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                while (System.Runtime.InteropServices.Marshal.ReleaseComObject(wb) > 1) ;
                wb = null;
            }
            if (excelApp != null)
            {
                excelApp.Application.Quit(); //M_20150922：解决进程驻留问题
                excelApp.Quit();
                excelApp = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            #endregion
        }
    }
}