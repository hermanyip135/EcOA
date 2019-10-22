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

using AppCommon.Model;
using JsonOutEstateList = DataEntity.Json.CCES.JsonOutEstateList;

using System.Diagnostics; //M_PDF
using System.Web;

public partial class Apply_BadDebts_Apply_BadDebts_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    /// <summary>
    /// 申请人编辑阶段需显示的部分
    /// </summary>
    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#divUploadBadDebts\").show();";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbCcesp = new StringBuilder();

    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();

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
        GetCCESP(txtBuilding.Text);
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
                if (Session["FLG_ReWrite3"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite3"] = null;
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

        //LoadAttach();   
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
        bool IsTempSave = false;        //是否暂存
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        DA_OfficeAutomation_Document_BadDebts_Detail_Inherit da_OfficeAutomation_Document_BadDebts_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_BadDebts_Detail_Inherit();

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
        {
            SbJs.Append("$(\"#btnPrint\").show();");
            //如果拥有权限则显示标注已坏账按钮
            //if (Purview.Contains("OA_Special_002") || EmployeeID == "16945" || EmployeeID == "61275")
            //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
            if (Purview.Contains("OA_Special_002") || EmployeeID == "43781" || EmployeeID == "61275")
                btnSignBad.Visible = true;
        }
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        DataSet badDebts = new DataSet();
        DataSet badDebts_Detail = new DataSet();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var obj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_BadDebts_Detail>("BadDebtsData", "", Mainobj.OfficeAutomation_SerialNumber);
            badDebts = Common.GetPageDetailDS<T_OfficeAutomation_Document_BadDebts>(obj.BadDebts, Mainobj);
            badDebts_Detail = Common.GetDataSet<T_OfficeAutomation_Document_BadDebts_Detail>(obj.BadDebts_Detail);
            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            badDebts = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);
            ID = badDebts.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_ID"].ToString();
            badDebts_Detail = da_OfficeAutomation_Document_BadDebts_Detail_Inherit.SelectByID(ID);

        }
        //ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);
        ds = badDebts;
        #region FormInit
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_BadDebts_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_BadDebts_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_BadDebts_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_BadDebts_Department"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_BadDebts_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtBuilding.Text = dr["OfficeAutomation_Document_BadDebts_Building"].ToString();
        txtReplyPhone.Text = dr["OfficeAutomation_Document_BadDebts_ReplyPhone"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_BadDebts_Reason"].ToString();
        txtMoneyCount.Text = dr["OfficeAutomation_Document_BadDebts_MoneyCount"].ToString() != "0" ? dr["OfficeAutomation_Document_BadDebts_MoneyCount"].ToString() : "";

        if (dr["OfficeAutomation_Document_BadDebts_OneOrTwo"].ToString() == "1")
            rdbOneOrTwo1.Checked = true;
        else if (dr["OfficeAutomation_Document_BadDebts_OneOrTwo"].ToString() == "2")
            rdbOneOrTwo2.Checked = true;
        if (!string.IsNullOrEmpty(dr["OfficeAutomation_Document_BadDebts_SumBDMoney"].ToString()))
            lbSumBDMoney.Text = dr["OfficeAutomation_Document_BadDebts_SumBDMoney"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        //ds = da_OfficeAutomation_Document_BadDebts_Detail_Inherit.SelectByID(ID);
        ds = badDebts_Detail;
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

                    if (string.IsNullOrEmpty(dr["OfficeAutomation_Document_BadDebts_Detail_No"].ToString()))
                        SbJs.Append("$('#txtDetail_pNo" + i + "').html('" + i + "');");
                    else
                        SbJs.Append("$('#txtDetail_pNo" + i + "').html('" + dr["OfficeAutomation_Document_BadDebts_Detail_No"] + "');");
                    SbJs.Append("$('#txtReportID" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_ReportID"] + "');");
                    SbJs.Append("$('#txtAddress" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_Address"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");
                    SbJs.Append("$('#txtOwner" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_Owner"] + "');");
                    SbJs.Append("$('#txtClient" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_Client"] + "');");
                    SbJs.Append("$('#txtOwnerBadMoney" + i + "').val('" + (dr["OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney"].ToString() != "0" ? dr["OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney"] : "") + "');");
                    SbJs.Append("$('#txtClientBadMoney" + i + "').val('" + (dr["OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney"].ToString() != "0" ? dr["OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney"] : "") + "');");
                    SbJs.Append("$('#txtBadReason" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_BadReason"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");
                    SbJs.Append("$('#rdoIsSpecialAdjust" + i + (dr["OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                    SbJs.Append("$('#rdoIsAutoBad" + i + (dr["OfficeAutomation_Document_BadDebts_Detail_IsAutoBad"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                    SbJs.Append("$('#txtAutoBadDate" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_AutoBadDate"] + "');");
                    SbJs.Append("$('#txtDealDate" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_DealDate"] + "');");
                    SbJs.Append("$('#txtBadDate" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_BadDate"] + "');");
                    SbJs.Append("$('#ddlArea" + i + "').val('" + dr["OfficeAutomation_Document_BadDebts_Detail_Area"] + "');");
                }
            }
        }
        else
        {
            DrawDetailTable(1);
        }

        #endregion
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        //SbJs.Append("$(\"#btnUpload\").show();");
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
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;
        if (isApplicant)
        {
            //SbJs.Append("$(\"#Warn\").show();");
            try
            {
                //2016-11-25修改，原来是注释掉的，现在去掉注释

                //2016-12-19修改 注释掉法律部人审批之后不能上传附件功能
                //if (drc[3]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
                //    SbJs.Append("$(\"#btnUpload\").hide();");
                //else
                SbJs.Append("$(\"#btnUpload\").show();");
            }
            catch
            {
                SbJs.Append("$(\"#btnUpload\").show();");
            }
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

        //if (EmployeeID == "5585") //保存功能对宁传雄开放
        //{
        //    GetAllDepartment();
        //    btnSave.Visible = true;
        //    SbJs.Append(ApplyDisplayPart);
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



        T_OfficeAutomation_Flow flowsc, flowsd;
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        if (DateTime.Parse(lblApplyDate.Text) > DateTime.Parse("2015-08-12 11:35:00.000"))
        {
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            flowsc = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);

            var depl = GetdicDepList();
            var d = depl.Find(m => m.name == this.txtDepartment.Text);
            if (flowsc != null)
            {
                if (d != null)
                {
                    wsFinance.Service wsf = new wsFinance.Service();
                    var ds1 = Common.GetHRTreeByDepartmentID(d.id).Split('|');
                    //if (ds1 == null || ds1[0] == "fail")
                    //{
                    //    Alert("部门不存在");
                    //    return;
                    //}
                    if (ds1 != null && ds1[0] != "fail")
                    {
                        if ((flowsc.OfficeAutomation_Flow_EmployeeID.Contains("0006") || flowsc.OfficeAutomation_Flow_EmployeeID.Contains("0638")) && ((ds1[0] + ",").IndexOf("0006,") > -1 || (ds1[0] + ",").IndexOf("0638,") > -1))
                        {
                            flowsd = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                            if (flowsd == null)
                            {
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                            }
                        }
                    }
                }
            }
        }



        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        //if ((EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "16945" || EmployeeID == "20208" || EmployeeID == "43781") && flowState == "3")
        //if ((EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "16945" || EmployeeID == "20208" || EmployeeID == "43781" || EmployeeID == "61275") && flowState == "3")
        //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
        if ((EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "43781" || EmployeeID == "20208" || EmployeeID == "43781" || EmployeeID == "61275") && flowState == "3")
            btnSignSave.Visible = true;

        #endregion
        //T_OfficeAutomation_Flow flowsd;
        flowsd = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        if (flowsd != null)
        {
            SbJs.Append("$('#trShowFlow4').show();$('#trShowFlow5').show();");
        }
        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
                SbJs.Append("</script>");
                txtDepartment.Text = "";
                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                IsNewApply = true;
                MainID = Guid.NewGuid().ToString();
                flowState = "1";
                btnSAlterC.Visible = false;
                return;
            }
        }
        catch
        {
            if (isApplicant && !IsTempSave)
                btnReWrite.Visible = true; //*+
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        bool flag3 = false;//是否有后勤事务部，董事总经理环节
        bool flag4 = false;//是否有董事总经理环节

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
            if ((curidx == "1" || curidx == "2" || curidx == "3" || EmployeeName == "黄轩明") && curemp2.Contains(EmployeeID) && showf) //M_HideFlows：20150330
            {
                showf = false;
                SbJs.Append("$(\"#trShowFlow4\").hide();$(\"#trShowFlow5\").prepend('<td>法律部意见</td>');");
                SbJs.Append("$(\"#trShowFlow6\").hide();$(\"#trShowFlow7\").hide();$(\"#trShowFlow8\").prepend('<td>财务部意见</td>');");
                SbJs.Append("$(\"#trLogistics1\").hide();$(\"#trLogistics2\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
                SbJs.Append("$(\"#tlsc1\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            }

            if (curidx == "9")
                flag3 = true;
            else if (txtDepartment.Text == "工商铺部" && flag3 == false)
                flag4 = true;

            T_OfficeAutomation_Flow flows2;//789
            flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
            if (flows2 != null)
                flag4 = true;

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
            if (drc[i]["OfficeAutomation_Flow_Suggestion"].ToString() != "") //M_Suggestion：20150205
                SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

            if (i >= 2 && drc[i]["OfficeAutomation_Flow_Auditor"].ToString() != "") //M_AddAnother：20150716 黄生其它意见，增加审批人
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

        //如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        if (flag3)
            SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();$('#trGeneralManager').show();");
        if (flag4)
            SbJs.Append("$('#trGeneralManager').show();");

        T_OfficeAutomation_Flow flows;//789
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        if (flows != null)
            SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC  //20170106修改  把&& showf去掉
            btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

        //20170106 注释掉
        //if (!showf) //M_HideFlows：20150330
        //{
        //    SbFlow.Length = 0;
        //    SbJs.Append("$('#trLogistics1').hide();");
        //}

        //if (EmployeeID == "10054" || EmployeeID == "34498") //M_WinnEnd：20150204
        //    btnWillEnd.Visible = true;
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



        //SbJs.Append("$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });");
        SbJs.Append("</script>");

        if (Mainobj.OfficeAutomation_Main_Department.ToString().Contains("法律部"))
        {
            this.lblCarbonCopy.Text = "";
            this.lblReviceDept.Text = "财务部";
        }

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
        DataSet dsApplyDetail = new DataSet();
        DataSet dsApplyType = new DataSet();

        DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
        dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(1);
        DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
        dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();

        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id='trDetail" + i + "'>");
            //SbHtml.Append("     <td><input type=\"text\" id=\"txtReportID" + i + "\" style=\"width:90%\"/></td>");
            //SbHtml.Append("     <td><input type=\"text\" id=\"txtAddress" + i + "\" style=\"width:90%\"/></td>");
            //SbHtml.Append("     <td><input type=\"text\" id=\"txtOwnerBadMoney" + i + "\" style=\"width:90%\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\"/></td>");
            //SbHtml.Append("     <td><input type=\"text\" id=\"txtClientBadMoney" + i + "\" style=\"width:90%\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\"/></td>");
            //SbHtml.Append("    <td><input type=\"text\" id=\"txtBadReason" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("     <td><span id=\"txtDetail_pNo" + i + "\">" + i + "</span></td>");
            SbHtml.Append("     <td><textarea id=\"txtReportID" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("     <td><textarea id=\"txtAddress" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("     <td><textarea id=\"txtOwner" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("     <td><textarea id=\"txtClient" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("     <td><textarea id=\"txtOwnerBadMoney" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\"></textarea></td>");
            SbHtml.Append("     <td><textarea id=\"txtClientBadMoney" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\"></textarea></td>");
            SbHtml.Append("     <td><textarea id=\"txtBadReason" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("     <td>");
            SbHtml.Append("         <input type=\"radio\" id='rdoIsSpecialAdjust" + i + "1' name='IsSpecialAdjust" + i + "' /><label for='rdoIsSpecialAdjust" + i + "1'>是</label><input type=\"radio\" id='rdoIsSpecialAdjust" + i + "0' name='IsSpecialAdjust" + i + "' /><label for='rdoIsSpecialAdjust" + i + "0'>否</label>");
            SbHtml.Append("     </td>");
            SbHtml.Append("     <td>");
            SbHtml.Append("         <input type=\"radio\" id='rdoIsAutoBad" + i + "1' name='IsAutoBad" + i + "' /><label for='rdoIsAutoBad" + i + "1'>是</label><input type=\"radio\" id='rdoIsAutoBad" + i + "0' name='IsAutoBad" + i + "' /><label for='rdoIsAutoBad" + i + "0'>否</label>");
            SbHtml.Append("     </td>");
            SbHtml.Append("     <td><input type=\"text\" id=\"txtAutoBadDate" + i + "\" style=\"width:75px\"/></td>");
            SbHtml.Append("     <td><input type=\"text\" id=\"txtDealDate" + i + "\" style=\"width:75px\"/></td>");
            SbHtml.Append("     <td><input type=\"text\" id=\"txtBadDate" + i + "\" style=\"width:75px\"/></td>");
            SbHtml.Append("     <td><select id=\"ddlArea" + i + "\" style=\"width:85px\"><option>请选择</option><option>天河区</option><option>海珠区</option><option>白云区</option><option>越秀区</option><option>花都区</option><option>番禺区</option><option>工商铺(罗思源)</option><option>工商铺(谢伟中)</option><option>工商铺(朱少娟)</option><option>项目部</option><option>芳村南海区</option></select></td>");
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
        T_OfficeAutomation_Document_BadDebts t_OfficeAutomation_Document_BadDebts = new T_OfficeAutomation_Document_BadDebts();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
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
            {
                #region 新建

                string[] sHRTree;
                try
                {
                    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                    //if (sHRTree == null || sHRTree[0] == "fail")
                    //{
                    //    Response.Write("<script type=\"text/javascript\">alert('部门不存在,请正确选择发文部门！');window.history.go(-1);</script>");
                    //    return;
                    //}
                }
                catch
                {
                    Response.Write("<script type=\"text/javascript\">alert('部门不存在,请正确选择发文部门！');window.history.go(-1);</script>");
                    return;
                }




                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "BadDebts" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 12;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;



                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                Guid g = Guid.NewGuid();
                int lh = InsertBadDebtsDetail(g);

                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ID = g;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Apply = EmployeeName;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ApplyID = txtApplyID.Text;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Department = txtDepartment.Text;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Building = txtBuilding.Text;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ReplyPhone = txtReplyPhone.Text;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Reason = txtReason.Text;
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_OneOrTwo = rdbOneOrTwo1.Checked ? "1" : rdbOneOrTwo2.Checked ? "2" : "0";
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_SumBDMoney = "自动坏账总额：" + hdBDM.Value + "元";
                t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MoneyCount = Decimal.Parse(txtMoneyCount.Text);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = "";

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_BadDebts_Inherit.Insert(t_OfficeAutomation_Document_BadDebts);//插入申请表

                //string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
                //DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
                da_OfficeAutomation_Document_BadDebts_Inherit.ReplaceRemarkByID(g.ToString(), (lh > 3 ? "财务部处理" : "法律部处理"));
                //sHRTree的格式为：26242,3189,3808|张榕,何旭晖,何智峰
                InsertFlow(sHRTree);

                Common.AddLog(EmployeeID, EmployeeName, 16, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_BadDebts_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    string[] sHRTree;
                    try
                    {
                        var depl = GetdicDepList();
                        var d = depl.Find(m => m.name == this.txtDepartment.Text);

                        if (d != null)
                        {
                            hdDepartmentID.Value = d.id;
                        }

                        sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                        //if (sHRTree == null || sHRTree[0] == "fail")
                        //{
                        //    Response.Write("<script type=\"text/javascript\">alert('部门不存在,请正确选择发文部门！');window.history.go(-1);</script>");
                        //    return;s
                        //}
                    }
                    catch
                    {
                        Response.Write("<script type=\"text/javascript\">alert('部门不存在,请正确选择发文部门！');window.history.go(-1);</script>");
                        return;
                    }
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
                        InsertFlow(sHRTree);
                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_BadDebts_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                    }
                    else
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "3");
                        #region 添加前线总监 2014-3-26

                        //int count = sHRTree[0].Split(',').Length;

                        //坏账申请审批流程部门负责人增加审批人（根据成交报告编号查询的部门负责人）
                        wsFinance.Service wsf = new wsFinance.Service();

                        string reportid = "", employeeid = sHRTree[0].Split(',')[0], employeename = sHRTree[1].Split(',')[0];

                        //if (hdDetail.Value != "")
                        //{
                        //    string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
                        //    for (int i = 0; i < details.Length; i++)
                        //    {
                        //        string[] detail = Regex.Split(details[i], "\\&\\&");
                        //        reportid += detail[0] + ",";
                        //    }

                        //    reportid = reportid.Substring(0, reportid.Length - 1);
                        //}

                        //DataSet dsmanager = wsf.fnGetAreaManageByReportNOs(reportid);

                        //if (dsmanager.Tables[0].Rows.Count > 0)
                        //{
                        //    for (var i = 0; i < dsmanager.Tables[0].Rows.Count; i++)
                        //    {
                        //        if (dsmanager.Tables[0].Rows[i]["Scale_Employee"].ToString() != "黄轩明")
                        //        {
                        //            if (dsmanager.Tables[0].Rows[i]["Scale_Employee"].ToString() != sHRTree[1].Split(',')[0])
                        //            {
                        //                employeeid += "," + dsmanager.Tables[0].Rows[i]["Scale_EmployeeCode"];
                        //                employeename += "," + dsmanager.Tables[0].Rows[i]["Scale_Employee"];
                        //            }
                        //        }
                        //    }
                        //}

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = employeeid;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = employeename;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        #endregion
                        RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
                    }
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

    protected void btnTempSave_Click(object sender, EventArgs e)
    {
        var SerialNumber = "BadDebts" + DateTime.Now.ToString("yyyyMMddHHmmssfffff");
        var DocumentID = 12;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        if (MainID == "")
        {
            MainID = Guid.NewGuid().ToString();
        }

        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName, txtDepartment.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }

        T_OfficeAutomation_Document_BadDebts t_OfficeAutomation_Document_BadDebts = new T_OfficeAutomation_Document_BadDebts();
        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        Guid g;
        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            g = Guid.NewGuid();
        }
        else
        {
            var BadDebts_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_ID"].ToString();
            g = new Guid(BadDebts_ID);
        }
        var DebtsDetail = GetBadDebtsDetail(g);//获取子表数据

        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ID = g;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Apply = EmployeeName;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ApplyID = txtApplyID.Text != "" && txtApplyID.Text != null ? txtApplyID.Text : "";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Department = txtDepartment.Text != "" && txtDepartment.Text != null ? txtDepartment.Text : "";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Building = txtBuilding.Text != "" && txtBuilding.Text != null ? txtBuilding.Text : "";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ReplyPhone = txtReplyPhone.Text != "" && txtReplyPhone.Text != null ? txtReplyPhone.Text : "";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Reason = txtReason.Text != "" && txtReason.Text != null ? txtReason.Text : "";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_OneOrTwo = rdbOneOrTwo1.Checked ? "1" : rdbOneOrTwo2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_SumBDMoney = (hdBDM.Value != null && hdBDM.Value != "" && hdBDM.Value != "0") ? "自动坏账总额：" + hdBDM.Value + "元" : "";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MoneyCount = Decimal.Parse(txtMoneyCount.Text != "" && txtMoneyCount.Text != null ? txtMoneyCount.Text : "0");

        da_OfficeAutomation_Document_BadDebts_Inherit.HandleBase(t_OfficeAutomation_Document_BadDebts);//插入申请表

        var obj = new DataEntity.PageModel.Apply_BadDebts_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;
        obj.BadDebts = t_OfficeAutomation_Document_BadDebts;
        obj.BadDebts_Detail = DebtsDetail;

        //写入xml
        var result = new Common().SaveTempSaveFile<DataEntity.PageModel.Apply_BadDebts_Detail>(obj, "BadDebtsData", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
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
        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        DA_OfficeAutomation_Document_BadDebts_Detail_Inherit da_OfficeAutomation_Document_BadDebts_Detail_Inherit = new DA_OfficeAutomation_Document_BadDebts_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_BadDebts_ID"].ToString();

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

                if (flowIDx == "6")
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

                if (flowIDx == "6")
                {
                    Update();
                    //da_OfficeAutomation_Document_BadDebts_Detail_Inherit.Delete(ID);
                    //int lh = InsertBadDebtsDetail(new Guid(ID));

                    ////string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
                    ////DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
                    //da_OfficeAutomation_Document_BadDebts_Inherit.ReplaceRemarkByID(ID, (lh > 3 ? "财务部处理" : "法律部处理"));
                }

                //如果为第四步流程则为其一审核即可通过，其他为同时审核。
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "4" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_BadDebts_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_BadDebts_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_BadDebts_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>文件主题：关于" + drRow["OfficeAutomation_Document_BadDebts_Building"].ToString() + "的坏账申请");
                    sbMailBody.Append("<br/>回复电话：020-" + drRow["OfficeAutomation_Document_BadDebts_ReplyPhone"]);
                    sbMailBody.Append("<br/>坏账原因：" + drRow["OfficeAutomation_Document_BadDebts_Reason"]);
                    sbMailBody.Append("<br/>");
                    ds = da_OfficeAutomation_Document_BadDebts_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>成交报告编号：" + dr["OfficeAutomation_Document_BadDebts_Detail_ReportID"]);
                        sbMailBody.Append("<br/>成交地址：" + dr["OfficeAutomation_Document_BadDebts_Detail_Address"]);
                        sbMailBody.Append("<br/>应收业佣：" + dr["OfficeAutomation_Document_BadDebts_Detail_Owner"]);
                        sbMailBody.Append("<br/>应收客佣：" + dr["OfficeAutomation_Document_BadDebts_Detail_Client"]);
                        sbMailBody.Append("<br/>业主坏账金额：" + dr["OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney"]);
                        sbMailBody.Append("<br/>客户坏账金额：" + dr["OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney"]);
                        sbMailBody.Append("<br/>坏账原因：" + dr["OfficeAutomation_Document_BadDebts_Detail_BadReason"]);
                        sbMailBody.Append("<br/>是否特殊调整：" + (dr["OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust"].ToString() == "True" ? "是" : "否"));
                        sbMailBody.Append("<br/>是否已自动坏账：" + (dr["OfficeAutomation_Document_BadDebts_Detail_IsAutoBad"].ToString() == "True" ? "是" : "否"));
                        sbMailBody.Append("<br/>自动坏账时间：" + dr["OfficeAutomation_Document_BadDebts_Detail_AutoBadDate"]);
                        sbMailBody.Append("<br/>成交日期：" + dr["OfficeAutomation_Document_BadDebts_Detail_DealDate"]);
                        sbMailBody.Append("<br/>坏账日期：" + dr["OfficeAutomation_Document_BadDebts_Detail_BadDate"]);
                        sbMailBody.Append("<br/>所属区域：" + dr["OfficeAutomation_Document_BadDebts_Detail_Area"]);
                        sbMailBody.Append("<br/>");
                    }

                    sbMailBody.Append("<br/>合计坏账金额：" + drRow["OfficeAutomation_Document_BadDebts_MoneyCount"]);

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

                            if (EmployeeID == "0001")
                                employeeList += "黄轩明" + "||";

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            if (employeeList.Contains("黄轩明"))
                                employname = CommonConst.EMP_GMO_NAME + ",潘焕心";
                            else
                                employname = "潘焕心";
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
        try
        {
            DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
            //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "16945" || EmployeeID == "20208" || EmployeeID == "43781") 
            //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "16945" || EmployeeID == "20208" || EmployeeID == "43781" || EmployeeID == "61275")

            //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
            if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "64185" || EmployeeID == "43781" || EmployeeID == "20208" || EmployeeID == "43781" || EmployeeID == "61275")
                da_OfficeAutomation_Document_BadDebts_Inherit.AddRemarkByID_II(MainID, CommonConst.SIGN_FINANCE);
            Alert("标记成功。");
        }
        catch
        {
            Alert("标记失败。");
        }
    }

    /// <summary>
    /// 点击标记已坏账按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSignBad_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
            //if (Purview.Contains("OA_Special_002"))
            if (Purview.Contains("OA_Special_002") || EmployeeID == "61275")
            {
                da_OfficeAutomation_Document_BadDebts_Inherit.AddRemarkByID_II(MainID, "已坏账");
                Alert("标记成功。");
            }
        }
        catch
        {
            Alert("标记失败。");
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

    #region 下载附件按钮单击事件
    /// <summary>
    /// 下载附件按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUploadBadDebts_Click(object sender, EventArgs e)
    {

        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);

        string path = hdFilePath.Value;
        if (path != "")
        {
            System.Data.OleDb.OleDbConnection ImportConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source=" + path + "; " + "Extended Properties='Excel 12.0;HDR=1; IMEX=1;'");
            System.Data.OleDb.OleDbDataAdapter ImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [格式$]", ImportConnection);
            DataSet ds = new DataSet();
            int i = 0;
            //try
            //{
            ImportCommand.Fill(ds);
            //}
            //catch
            //{
            //    Alert("格式错误");
            //    DrawDetailTable(1);
            //    txtMoneyCount.Text = "";
            //    SbJs.Append("</script>");
            //    return;
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string sReportID, sAddress, sOwnerBadMoney, sClientBadMoney, sBadReason, AutoBadDate, Owner, Client, d1, d2, d3;
                    bool bIsSpecialAdjust, IsAutoBad;
                    int success = 0;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        sReportID = ds.Tables[0].Rows[i]["成交报告编号"].ToString().Trim();
                        sAddress = ds.Tables[0].Rows[i]["成交地址"].ToString().Trim();
                        Owner = ds.Tables[0].Rows[i]["应收业佣"].ToString().Trim();
                        Client = ds.Tables[0].Rows[i]["应收客佣"].ToString().Trim();
                        sOwnerBadMoney = ds.Tables[0].Rows[i]["业主坏账金额佣金"].ToString().Trim();
                        sClientBadMoney = ds.Tables[0].Rows[i]["客户坏账金额佣金"].ToString().Trim();
                        sBadReason = ds.Tables[0].Rows[i]["坏账原因"].ToString().Trim();
                        bIsSpecialAdjust = ds.Tables[0].Rows[i]["是否特殊调整"].ToString().Trim() == "是" ? true : false;
                        IsAutoBad = ds.Tables[0].Rows[i]["是否已自动坏账"].ToString().Trim() == "是" ? true : false;
                        AutoBadDate = ds.Tables[0].Rows[i]["自动坏账时间"].ToString().Trim();
                        d1 = ds.Tables[0].Rows[i]["成交日期"].ToString().Trim();
                        d2 = ds.Tables[0].Rows[i]["坏账日期"].ToString().Trim();
                        d3 = ds.Tables[0].Rows[i]["所属区域"].ToString().Trim();

                        if (string.IsNullOrEmpty(sReportID))
                        {
                            continue;
                        }
                        if (string.IsNullOrEmpty(AutoBadDate))
                        {
                            RunJS("alert('上传失败，自动坏账时间不能为空。');history.go(-1);");
                            DrawDetailTable(1);
                            txtMoneyCount.Text = "";
                            SbJs.Append("</script>");
                            return;
                        }
                        if (string.IsNullOrEmpty(d1) || string.IsNullOrEmpty(d2))
                        {
                            RunJS("alert('上传失败，成交日期、坏账日期不能为空。');history.go(-1);");
                            DrawDetailTable(1);
                            txtMoneyCount.Text = "";
                            SbJs.Append("</script>");
                            return;
                        }

                        if (!string.IsNullOrEmpty(sReportID) && !string.IsNullOrEmpty(sAddress))
                        {
                            success++;
                            SbJs.Append("$('#txtDetail_pNo" + success + "').html('" + success + "');");
                            SbJs.Append("$('#txtReportID" + success + "').val('" + sReportID + "');");
                            SbJs.Append("$('#txtAddress" + success + "').val('" + sAddress + "');");
                            SbJs.Append("$('#txtOwner" + success + "').val('" + Owner + "');");
                            SbJs.Append("$('#txtClient" + success + "').val('" + Client + "');");
                            SbJs.Append("$('#txtOwnerBadMoney" + success + "').val('" + sOwnerBadMoney + "');");
                            SbJs.Append("$('#txtClientBadMoney" + success + "').val('" + sClientBadMoney + "');");
                            SbJs.Append("$('#txtBadReason" + success + "').val('" + sBadReason + "');");
                            SbJs.Append("$('#rdoIsSpecialAdjust" + success + (bIsSpecialAdjust ? "1" : "0") + "').attr('checked','checked');");
                            SbJs.Append("$('#rdoIsAutoBad" + success + (IsAutoBad ? "1" : "0") + "').attr('checked','checked');");
                            SbJs.Append("$('#txtAutoBadDate" + success + "').val('" + DateTime.Parse(AutoBadDate).ToString("yyyy-MM-dd") + "');");
                            SbJs.Append("$('#txtDealDate" + success + "').val('" + DateTime.Parse(d1).ToString("yyyy-MM-dd") + "');");
                            SbJs.Append("$('#txtBadDate" + success + "').val('" + DateTime.Parse(d2).ToString("yyyy-MM-dd") + "');");
                            SbJs.Append("$('#ddlArea" + success + "').val('" + d3 + "');");
                        }
                        if (sReportID == "业、客坏账金额合计：")
                            txtMoneyCount.Text = sOwnerBadMoney;
                    }

                    DrawDetailTable(success);
                }
                catch (System.Exception ex)
                {
                    RunJS("alert('上传失败！" + ex.Message + "');history.go(-1);");
                    return;
                }
            }
        }
        else
        {
            //Alert(hdFilePath.Value);
            DrawDetailTable(1);
        }

        SbJs.Append("</script>");

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
                //if (drc[3]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
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
        T_OfficeAutomation_Document_BadDebts t_OfficeAutomation_Document_BadDebts = new T_OfficeAutomation_Document_BadDebts();
        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_BadDebts_Detail_Inherit da_OfficeAutomation_Document_BadDebts_Detail_Inherit = new DA_OfficeAutomation_Document_BadDebts_Detail_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_ID"].ToString();
        da_OfficeAutomation_Document_BadDebts_Detail_Inherit.Delete(ID);



        int lh = InsertBadDebtsDetail(new Guid(ID));

        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ID = new Guid(ID);
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Apply = EmployeeName;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Building = txtBuilding.Text;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_Reason = txtReason.Text;
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_OneOrTwo = rdbOneOrTwo1.Checked ? "1" : rdbOneOrTwo2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_SumBDMoney = "自动坏账总额：" + hdBDM.Value + "元";
        t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MoneyCount = Decimal.Parse(txtMoneyCount.Text);

        string apply = "";
        string depname = txtDepartment.Text;
        string summary = "";
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_BadDebts_Inherit.Update(t_OfficeAutomation_Document_BadDebts);//修改申请表

        //string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        //DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        da_OfficeAutomation_Document_BadDebts_Inherit.ReplaceRemarkByID(ID, (lh > 3 ? "财务部处理" : "法律部处理"));

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        //if (t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MoneyCount > 50000)
        //{
        //    T_OfficeAutomation_Flow flows;
        //    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        //    if (flows == null)
        //    {
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792";
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心";
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 4;

        //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "2377";
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈洁丽";
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;

        //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //    }
        //    //    T_OfficeAutomation_Flow flows2a;
        //    //    flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
        //    //    if (flows2a == null)
        //    //    {
        //    //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
        //    //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
        //    //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //    //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        //    //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        //    //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
        //    //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //    //    }
        //}
        //else
        //{
        //    T_OfficeAutomation_Flow flows2a;
        //    flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        //    if (flows2a != null)
        //        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "4,5");
        //}

        T_OfficeAutomation_Flow flowsd;//*-
        wsFinance.Service wsf = new wsFinance.Service();
        string sjg = wsf.fnGetExchangeCharNameByBuildingName(txtBuilding.Text);
        if (rdbOneOrTwo1.Checked && decimal.Parse(txtMoneyCount.Text) >= 100000)
        {
            flowsd = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
            if (flowsd == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
        }
        else
        {
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,10");
            T_OfficeAutomation_Flow flows2a;
            flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
            if (flows2a != null)
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
        }

        //20170522张绍欣要求选择纯二手单位并且金额大于5万加上黄生审批
        if (rdbOneOrTwo2.Checked)
        {
            if (decimal.Parse(txtMoneyCount.Text) >= 50000)
            {
                flowsd = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                if (flowsd == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }
            else
            {
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,10");
                T_OfficeAutomation_Flow flows2a;
                flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
                if (flows2a != null)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
            }
        }

        Common.AddLog(EmployeeID, EmployeeName, 16, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增坏账申请明细

    /// <summary>
    /// 新增坏账申请明细
    /// </summary>
    /// <param name="gBadDebtsID"></param>
    private int InsertBadDebtsDetail(Guid gBadDebtsID)
    {
        if (hdDetail.Value == "")
            return 0;
        float om = 0, cm = 0;
        T_OfficeAutomation_Document_BadDebts_Detail t_OfficeAutomation_Document_BadDebts_Detail;
        DA_OfficeAutomation_Document_BadDebts_Detail_Inherit da_OfficeAutomation_Document_BadDebts_Detail_Inherit = new DA_OfficeAutomation_Document_BadDebts_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_BadDebts_Detail = new T_OfficeAutomation_Document_BadDebts_Detail();
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_MainID = gBadDebtsID;
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_ReportID = detail[0];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_Address = detail[1];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_Owner = detail[2];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_Client = detail[3];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney = Decimal.Parse(detail[4]);
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney = Decimal.Parse(detail[5]);
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_BadReason = detail[6];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust = detail[7] == "1";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_IsAutoBad = detail[8] == "1";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_AutoBadDate = detail[9];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_No = detail[10];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_DealDate = detail[11];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_BadDate = detail[12];
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_Area = detail[13];

            da_OfficeAutomation_Document_BadDebts_Detail_Inherit.Insert(t_OfficeAutomation_Document_BadDebts_Detail);

            if (detail[8] == "1")
            {
                om += float.Parse(detail[4]);
                cm += float.Parse(detail[5]);
            }
        }
        hdBDM.Value = (om + cm).ToString();
        return details.Length;
    }

    private List<DataEntity.T_OfficeAutomation_Document_BadDebts_Detail> GetBadDebtsDetail(Guid gBadDebtsID)
    {
        if (hdDetail.Value == "")
            return null;
        float om = 0, cm = 0;
        T_OfficeAutomation_Document_BadDebts_Detail t_OfficeAutomation_Document_BadDebts_Detail;
        List<T_OfficeAutomation_Document_BadDebts_Detail> list = new List<T_OfficeAutomation_Document_BadDebts_Detail>();
        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_BadDebts_Detail = new T_OfficeAutomation_Document_BadDebts_Detail();
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_MainID = gBadDebtsID;
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_ReportID = detail[0] != "" ? detail[0] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_Address = detail[1] != "" ? detail[1] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_Owner = detail[2] != "" ? detail[2] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_Client = detail[3] != "" ? detail[3] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney = Decimal.Parse(detail[4] != "" ? detail[4] : "0");
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney = Decimal.Parse(detail[5] != "" ? detail[5] : "0");
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_BadReason = detail[6] != "" ? detail[6] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust = detail[7] == "1";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_IsAutoBad = detail[8] == "1";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_AutoBadDate = detail[9] != "" ? detail[9] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_No = detail[10] != "" ? detail[10] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_DealDate = detail[11] != "" ? detail[11] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_BadDate = detail[12] != "" ? detail[12] : "";
            t_OfficeAutomation_Document_BadDebts_Detail.OfficeAutomation_Document_BadDebts_Detail_Area = detail[13] != "" ? detail[13] : "";

            list.Add(t_OfficeAutomation_Document_BadDebts_Detail);
            if (detail[8] == "1")
            {
                om += float.Parse(detail[4] != "" ? detail[4] : "0");
                cm += float.Parse(detail[5] != "" ? detail[5] : "0");
            }
        }
        hdBDM.Value = (om + cm).ToString();
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
        Session["FLG_ReWrite3"] = "1";
        Response.Write("<script>window.open('Apply_BadDebts_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("坏账申请表.pdf"));//强制下载 
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

        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_ID"].ToString(); //在不同的表要注意修改

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
            DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
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
                if (i < 7)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
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
            DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
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
            DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改 M_Suggestion：20150205
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_BadDebts_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

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
        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
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

        var remark = drRow["OfficeAutomation_Document_BadDebts_Remark"].ToString().Replace(CommonConst.SIGN_FINANCE, "");
        da_OfficeAutomation_Document_BadDebts_Inherit.ReplaceRemarkByID(drRow["OfficeAutomation_Document_BadDebts_ID"].ToString(), remark);
        Review(200, txtIDx200.Value);
    }
    protected void btnSignIDx220_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
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

    #region 获取物业部和项目部楼盘的信息
    /// <summary>
    /// 获取物业部和项目部楼盘的信息 M_20150924
    /// </summary>
    public void GetCCESP(string txt)
    {
        try
        {
            DA_CCES_Inherit cces = new DA_CCES_Inherit();
            List<DbTable> list = new List<DbTable>();
            List<DbTable> listNotLike = new List<DbTable>();
            list.Clear();
            list.Add(new DbTable("EstateName", txt));
            string sJsonIn = cces.fnGetJsonIn(list);
            string s = cces.fnGetEstateListString(sJsonIn);
            if (string.IsNullOrEmpty(s))
                s = "[]";
            s = s.Remove(s.Length - 1, 1);

            DA_SecondOR_Inherit da_SecondOR_Inherit = new DA_SecondOR_Inherit();
            DataSet sor = da_SecondOR_Inherit.SelectSecondOR();
            foreach (DataRow dr in sor.Tables[0].Rows)
            {
                s += ",{\"id\":\"" + dr["projectid"].ToString().Replace("\r", string.Empty).Replace("\n", string.Empty) + "\",\"value\":\"" + dr["projectname"].ToString().Replace("\r", string.Empty).Replace("\n", string.Empty) + "\"}";
            }
            s += "]";
            SbCcesp.Append(s);
        }
        catch
        {
            SbCcesp.Append("[]");
        }
    }
    #endregion

    public List<dicDep> GetdicDepList()
    {
        wsKDHR.Service service = new wsKDHR.Service();
        DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
        List<dicDep> list = new List<dicDep>();
        foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        {
            list.Add(new dicDep
            {
                id = dr["id"].ToString(),
                name = dr["name"].ToString()
            });
        }
        return list;
    }

    //保存流程
    public void InsertFlow(string[] sHRTree)
    {
        #region 保存默认流程
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

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

        #region 添加前线总监 2014-3-26

        //int count = sHRTree[0].Split(',').Length;

        //坏账申请审批流程部门负责人增加审批人（根据成交报告编号查询的部门负责人）
        wsFinance.Service wsf = new wsFinance.Service();

        string reportid = "", employeename = "", empidbyreportid = "", empnamebyreportid = "";
        if (sHRTree != null && sHRTree[0] != "fail")
        {
            employeename = sHRTree[1].Split(',')[0];
            empidbyreportid = sHRTree[0].Split(',')[0];
            empnamebyreportid = sHRTree[1].Split(',')[0];
        }

        //  SYSREQ201902251041115241532   现留申请人上头负责人，去掉列表所属区域负责人
        //if (hdDetail.Value != "")
        //{
        //    string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        //    for (int i = 0; i < details.Length; i++)
        //    {
        //        string[] detail = Regex.Split(details[i], "\\&\\&");
        //        reportid += detail[0] + ",";
        //    }

        //    reportid = reportid.Substring(0, reportid.Length - 1);
        //}

        //DataSet dsmanager = wsf.fnGetAreaManageByReportNOs(reportid);

        //if (dsmanager.Tables[0].Rows.Count > 0)
        //{
        //    for (var i = 0; i < dsmanager.Tables[0].Rows.Count; i++)
        //    {
        //        if (dsmanager.Tables[0].Rows[i]["Scale_Employee"].ToString() != "黄轩明")
        //        {
        //            if (dsmanager.Tables[0].Rows[i]["Scale_Employee"].ToString() != employeename)
        //            {
        //                if (employeename == "")
        //                {
        //                    empidbyreportid += dsmanager.Tables[0].Rows[i]["Scale_EmployeeCode"] + ",";
        //                    empnamebyreportid += dsmanager.Tables[0].Rows[i]["Scale_Employee"] + ",";
        //                }
        //                else
        //                {
        //                    empidbyreportid += "," + dsmanager.Tables[0].Rows[i]["Scale_EmployeeCode"];
        //                    empnamebyreportid += "," + dsmanager.Tables[0].Rows[i]["Scale_Employee"];
        //                }
        //            }
        //        }
        //    }
        //}

        if (!string.IsNullOrEmpty(empidbyreportid) && employeename == "")
        {
            empidbyreportid = empidbyreportid.Substring(0, empidbyreportid.Length - 1);
        }
        if (!string.IsNullOrEmpty(empnamebyreportid) && employeename == "")
        {
            empnamebyreportid = empnamebyreportid.Substring(0, empnamebyreportid.Length - 1);
        }

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = empidbyreportid;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = empnamebyreportid;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;

        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        #endregion

        #region 如果金额大于5万，则增加法律环节 20151020

        //if (t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MoneyCount > 50000)
        //{


        bool isLawDepartment = IsApplyDeptBelongLawDepartment(this.hdDepartmentID.Value);

        //如果不是法律部上的申请，则增加法律部的审批流
        if (!isLawDepartment)
        {


            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 4;

            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "2377";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈洁丽";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;

            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }

        ////加上申请人的审批流
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName;
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;

        //da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);


        //T_OfficeAutomation_Flow flows2a;
        //flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
        //if (flows2a == null)
        //{
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
        //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //}
        //}

        //if (txtDepartment.Text == "工商铺部" && t_OfficeAutomation_Document_BadDebts.OfficeAutomation_Document_BadDebts_MoneyCount <= 20000)
        //{
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

        //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //}

        //20170522张绍欣要求选择纯二手单位并且金额大于5万加上黄生审批
        T_OfficeAutomation_Flow flows2a;
        if (rdbOneOrTwo2.Checked && decimal.Parse(txtMoneyCount.Text) >= 50000)
        {
            flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
            if (flows2a == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
        }

        T_OfficeAutomation_Flow flowsd;//*-

        string sjg = wsf.fnGetExchangeCharNameByBuildingName(txtBuilding.Text);
        if (rdbOneOrTwo1.Checked && decimal.Parse(txtMoneyCount.Text) >= 100000)
        {
            flowsd = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
            if (flowsd == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
        }

        #endregion

        #endregion


    }

    //判断申请部门是否法律部
    protected bool IsApplyDeptBelongLawDepartment(string deptID)
    {
        //5A15E78C-8039-434D-80CB-CFDB18E2A312	法律及客服部
        //F89E8278-0631-40B8-8DCF-7D18D93A1965	法律部
        //E6AF85AE-2684-433A-9227-FDAC4C5F0200	客户服务中心
        bool rValue = false;
        //string[] lawDeptIDs = new string[] { "5A15E78C-8039-434D-80CB-CFDB18E2A312", "F89E8278-0631-40B8-8DCF-7D18D93A1965", "E6AF85AE-2684-433A-9227-FDAC4C5F0200" };

        //for (int i = 0; i < lawDeptIDs.Length; i++)
        //{
        //    if (deptID.ToUpper() == lawDeptIDs[i].ToUpper())
        //    {
        //        rValue = true;
        //    }
        //}

        string lawDeptID = "F89E8278-0631-40B8-8DCF-7D18D93A1965";

        if (deptID.ToUpper() == lawDeptID.ToUpper())
        {
            rValue = true;
        }

        return rValue;
    }

    public class dicDep
    {
        public string id { get; set; }
        public string name { get; set; }
    }


}