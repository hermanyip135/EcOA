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
using DataEntity.PageModel;

public partial class Apply_ReduceComm_Apply_ReduceComm_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public string ApplyN;
    public int DetailCount = 1;
    public StringBuilder SbFYQ = new StringBuilder();

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

        MainID = GetQueryString("MainID");
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
                if (Session["FLG_ReWrite20"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite20"] = null;
                }
            }
            catch
            {
            }

            this.hidPageType.Value = GetQueryString("t");
            if (!string.IsNullOrEmpty(this.hidPageType.Value) && this.hidPageType.Value == "2")
            {
                this.h1DocumentTitle.InnerText = "减让佣/现金奖申请表(房友圈电商类)";
            }


            if (MainID != "") LoadPage();
            else InitPage();

            StructureFYQHTML(this.hidPageType.Value);

        }
        else GetAllDepartment();
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

        SbJs.Append("<script type=\"text/javascript\">$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
        DrawDetailTable(1);
        SbJs.Append("</script>");

        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        DataSet ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(13);

        DropDownListBind(ddlDepartmentType, ds.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", "0", "--请选择区域--");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        bool IsTempSave = false;        //是否暂存
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit da_OfficeAutomation_Document_ReduceComm_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit();

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

        SbJs.Append("<script type=\"text/javascript\">$(\"#spanApplyFor\").show();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据
        DataSet ds = new DataSet();
        DataSet ReduceComm = new DataSet();
        DataSet ReduceComm_Detail = new DataSet();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var obj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_ReduceComm_Detail>("ReduceCommDetail", "", Mainobj.OfficeAutomation_SerialNumber);
            ReduceComm = Common.GetPageDetailDS<T_OfficeAutomation_Document_ReduceComm>(obj.ReduceComm, Mainobj);
            ReduceComm_Detail = Common.GetDataSet<T_OfficeAutomation_Document_ReduceComm_Detail>(obj.ReduceComm_Detail);
            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            ReduceComm = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID);
            ID = ReduceComm.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_ID"].ToString();
            ReduceComm_Detail = da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.SelectByApplyID(ID);
        }

        //ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID);
        ds = ReduceComm;
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ReduceComm_ID"].ToString();

        string applicant = dr["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
        ApplyN = applicant;
        lblApply.Text = applicant;
        txtDepartment.Value = dr["OfficeAutomation_Document_ReduceComm_Department"].ToString();
        txtApplyForID.Text = dr["OfficeAutomation_Document_ReduceComm_ApplyForCode"].ToString();
        txtApplyFor.Value = dr["OfficeAutomation_Document_ReduceComm_ApplyForName"].ToString();
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ReduceComm_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtSubject.Text = dr["OfficeAutomation_Document_ReduceComm_Subject"].ToString();
        txtDepartment.Value = dr["OfficeAutomation_Document_ReduceComm_Department"].ToString();
        hdDepartmentID.Value = dr["OfficeAutomation_Document_ReduceComm_DepartmentID"].ToString();
        txtReplyPhone.Text = dr["OfficeAutomation_Document_ReduceComm_ReplyPhone"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_ReduceComm_Reason"].ToString();
        txtDealDepartment.Text = dr["OfficeAutomation_Document_ReduceComm_DealDepartment"].ToString();
        txtOriginalDealPrice.Text = dr["OfficeAutomation_Document_ReduceComm_OriginalDealPrice"].ToString();
        txtFinalDealPrice.Text = dr["OfficeAutomation_Document_ReduceComm_FinalDealPrice"].ToString();
        txtCommPoint.Text = dr["OfficeAutomation_Document_ReduceComm_CommPoint"].ToString();
        txtOriginalComm.Text = dr["OfficeAutomation_Document_ReduceComm_OriginalComm"].ToString();
        txtReduceCashBonus.Text = dr["OfficeAutomation_Document_ReduceComm_ReduceCashBonus"].ToString();
        txtReduceComm.Text = dr["OfficeAutomation_Document_ReduceComm_ReduceComm"].ToString();

        txtEBCommPoint.Text = dr["OfficeAutomation_Document_ReduceComm_EBCommPoint"].ToString();
        txtCaCommPoint.Text = dr["OfficeAutomation_Document_ReduceComm_CaCommPoint"].ToString();
        txtEBOriginalComm.Text = dr["OfficeAutomation_Document_ReduceComm_EBOriginalComm"].ToString();
        txtCaOriginalComm.Text = dr["OfficeAutomation_Document_ReduceComm_CaOriginalComm"].ToString();
        txtEBReduceCashBonus.Text = dr["OfficeAutomation_Document_ReduceComm_EBReduceCashBonus"].ToString();
        txtCaReduceCashBonus.Text = dr["OfficeAutomation_Document_ReduceComm_CaReduceCashBonus"].ToString();
        txtEBReduceComm.Text = dr["OfficeAutomation_Document_ReduceComm_EBReduceComm"].ToString();
        txtCaReduceComm.Text = dr["OfficeAutomation_Document_ReduceComm_CaReduceComm"].ToString();

        txtTotalReduce.Text = dr["OfficeAutomation_Document_ReduceComm_TotalReduce"].ToString();
        txtKSa.Text = dr["OfficeAutomation_Document_ReduceComm_KSa"].ToString();
        txtKSb.Text = dr["OfficeAutomation_Document_ReduceComm_KSb"].ToString();
        txtKSc.Text = dr["OfficeAutomation_Document_ReduceComm_KSc"].ToString();
        txtKSd.Text = dr["OfficeAutomation_Document_ReduceComm_KSd"].ToString();
        txtActualReportMoney.Text = dr["OfficeAutomation_Document_ReduceComm_ActualReportMoney"].ToString();

        string way = dr["OfficeAutomation_Document_ReduceComm_ReduceWay"].ToString();
        if (way.Contains("1"))
            rdbReduceWay1.Checked = true;
        if (way.Contains("2"))
            rdbReduceWay2.Checked = true;
        if (way.Contains("3"))
            rdbReduceWay3.Checked = true;
        if (way.Contains("4"))
            rdbReduceWay4.Checked = true;
        ReduceCommType.Value = dr["OfficeAutomation_Document_ReduceComm_Type"].ToString();//减让佣/现金奖类型
        //if (dr["OfficeAutomation_Document_ReduceComm_ReduceWay"].ToString() == "1")
        //    rdbReduceWay1.Checked = true;
        //else if (dr["OfficeAutomation_Document_ReduceComm_ReduceWay"].ToString() == "2")
        //    rdbReduceWay2.Checked = true;
        //else if (dr["OfficeAutomation_Document_ReduceComm_ReduceWay"].ToString() == "3")
        //    rdbReduceWay3.Checked = true;

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(13);
        DropDownListBind(ddlDepartmentType, ds.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", "0", "--请选择区域--");
        ddlDepartmentType.SelectedValue = dr["OfficeAutomation_Document_ReduceComm_DepartmentTypeID"].ToString();

        //ds = da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.SelectByApplyID(ID);
        ds = ReduceComm_Detail;
        if (ds != null)
        {
            int detailCount = ds.Tables[0].Rows.Count;
            if (detailCount == 0)
                DrawDetailTable(1);
            else
            {
                DrawDetailTable(detailCount);

                //if (DateTime.Parse(lblApplyDate.Text) < DateTime.Parse(CommonConst.REDUCECOMM_OLD_TIME))
                //    for (int n = 0; n < detailCount; n++)
                //    {
                //        dr = ds.Tables[0].Rows[n];

                //        int i = n + 1;

                //        SbJs.Append("$('#txtDealDate" + i + "').val('" + DateTime.Parse(dr["OfficeAutomation_Document_ReduceComm_Detail_DealDate"].ToString()).ToString("yyyy-MM-dd") + "');");
                //        SbJs.Append("$('#txtDealAddress" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_DealDepartment"] + "');");
                //        SbJs.Append("$('#txtOriginalDealPrice" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice"] + "');");
                //        SbJs.Append("$('#txtFinalDealPrice" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice"] + "');");
                //        SbJs.Append("$('#txtCommPoint" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_CommPoint"] + "');");
                //        SbJs.Append("$('#txtOriginalComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalComm"] + "');");
                //        SbJs.Append("$('#txtReduceCashBonus" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus"] + "');");
                //        SbJs.Append("$('#txtReduceComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceComm"] + "');");
                //        SbJs.Append("$('#txtTotalReduce" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_TotalReduce"] + "');");
                //        SbJs.Append("$('#txtActualReportMoney" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney"] + "');");
                //    }
                //else
                for (int n = 0; n < detailCount; n++)
                {
                    dr = ds.Tables[0].Rows[n];

                    int i = n + 1;
                    if (DateTime.Parse(dr["OfficeAutomation_Document_ReduceComm_Detail_DealDate"].ToString()).ToString("yyyy-MM-dd") != "1956-01-10")
                    {
                        SbJs.Append("$('#txtDealDate" + i + "').val('" + DateTime.Parse(dr["OfficeAutomation_Document_ReduceComm_Detail_DealDate"].ToString()).ToString("yyyy-MM-dd") + "');");
                    }
                    string d = dr["OfficeAutomation_Document_ReduceComm_Detail_DealDepartment"].ToString();
                    d = Regex.Replace(d, @"[\r\n]", "");

                    SbJs.Append("$('#txtDealAddress" + i + "').val('" + d + "');");
                    SbJs.Append("$('#txtOriginalDealPrice" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice"] + "');");
                    SbJs.Append("$('#txtFinalDealPrice" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice"] + "');");
                    SbJs.Append("$('#txtCommPoint" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_CommPoint"] + "');");
                    SbJs.Append("$('#txtKSa" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSa"] + "');");
                    SbJs.Append("$('#txtKSb" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSb"] + "');");
                    SbJs.Append("$('#txtKSc" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSc"] + "');");
                    SbJs.Append("$('#txtKSd" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSd"] + "');");
                    SbJs.Append("$('#txtOriginalComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalComm"] + "');");
                    SbJs.Append("$('#txtReduceCashBonus" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus"] + "');");
                    SbJs.Append("$('#txtReduceComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceComm"] + "');");

                    SbJs.Append("$('#txtEBCommPoint" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint"] + "');");
                    SbJs.Append("$('#txtCaCommPoint" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint"] + "');");
                    SbJs.Append("$('#txtEBOriginalComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm"] + "');");
                    SbJs.Append("$('#txtCaOriginalComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm"] + "');");
                    SbJs.Append("$('#txtEBReduceCashBonus" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus"] + "');");
                    SbJs.Append("$('#txtCaReduceCashBonus" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus"] + "');");
                    SbJs.Append("$('#txtEBReduceComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm"] + "');");
                    SbJs.Append("$('#txtCaReduceComm" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm"] + "');");
                    string b = dr["OfficeAutomation_Document_ReduceComm_Detail_BudingName"].ToString();
                    b = Regex.Replace(b, @"[\r\n]", "");
                    SbJs.Append("$('#txtBudingName" + i + "').val('" + b + "');");
                    SbJs.Append("$('#txtTotalReduce" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_TotalReduce"] + "');");
                    //SbJs.Append("$('#txtKSa" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSa"] + "');");
                    //SbJs.Append("$('#txtKSb" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSb"] + "');");
                    //SbJs.Append("$('#txtKSc" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSc"] + "');");
                    //SbJs.Append("$('#txtKSd" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSd"] + "');");
                    SbJs.Append("$('#txtActualReportMoney" + i + "').val('" + dr["OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney"] + "');");
                }
            }
        }
        else
        {
            DrawDetailTable(1);
        }


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
            T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 3);
            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 200);
            flowst = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndEID(MainID, "0001");
            var flowsm = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 220);       //总经理复审流程
            /*
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF1\").show();");
            if (((drcz[0]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID) && drcz[0]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName)) && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || (EmployeeName == applicant && flowst.OfficeAutomation_Flow_IsAgree == 2) 
                || (fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowst.OfficeAutomation_Flow_IsAgree == 2) 
               )
            {
                SbJs.Append("$(\"#trAddAnoF1\").show();");
                btnsSignIDx200.Visible = true;
                if ((!fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName)) && flowsa != null)
                    btnsSignIDx200.Visible = false; //M_AlAno：20160217 ++
            }
            */

            #region 复审相关
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
                SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("</script>");
                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                flowState = "1";
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
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        bool showf = true; //JohnMingle
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            //if (idx == 200)
            //{
            //    var string1 = "";
            //}
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (EmployeeName == "黄轩明" && showf) //M_HideFlows：20150330
            {
                showf = false;
                SbJs.Append("$(\"#trShowFlow4\").hide();$(\"#trShowFlow5\").prepend('<td>法律部意见</td>');");
                SbJs.Append("$(\"#trShowFlow6\").hide();$(\"#trShowFlow7\").hide();$(\"#trShowFlow8\").prepend('<td>财务部意见</td>');");
            }
            //if (curidx == "8")
            //    flag3 = true;

            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                SbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                if (curemp.Contains(EmployeeName)) //M_Add：黄志超 20150202
                {
                    //switch (curidx)
                    //{
                    //    case "6":
                    //        //ckbAddIDx.Visible = true;
                    //        this.hidAddIDxVisible.Value = "true";
                    //        break;
                    //    default:
                    //        break;
                    //}

                    if (this.hidPageType.Value == "2")
                    {
                        switch (curidx)
                        {
                            case "8":
                                //ckbAddIDx.Visible = true;
                                this.hidAddIDxVisible.Value = "true";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (curidx)
                        {
                            case "6":
                                //ckbAddIDx.Visible = true;
                                this.hidAddIDxVisible.Value = "true";
                                break;
                            default:
                                break;
                        }
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
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').show();");

                flag = false;
            }
            if (drc[i]["OfficeAutomation_Flow_Suggestion"].ToString() != "") //M_Suggestion：20150205
                SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

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

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
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

    public void DrawDetailTable(int n)
    {
        //if (DateTime.Parse(lblApplyDate.Text) < DateTime.Parse(CommonConst.REDUCECOMM_OLD_TIME))
        //    for (int i = 1; i <= n; i++)
        //    {
        //        SbHtml.Append("<tr id='trDetail" + i + "'>");
        //        SbHtml.Append("    <td><input type=\"text\" id=\"txtDealDate" + i + "\" style=\"width:90%\"/></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtDealAddress" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtOriginalDealPrice" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtFinalDealPrice" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtCommPoint" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtOriginalComm" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtReduceCashBonus" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtReduceComm" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtTotalReduce" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("    <td><textarea id=\"txtActualReportMoney" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
        //        SbHtml.Append("</tr>");
        //    }
        //else
        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id='trDetail" + i + "'>");
            SbHtml.Append("    <td><input type=\"text\" id=\"txtDealDate" + i + "\" style=\"width:90%\"/></td>");
            SbHtml.Append("    <td><textarea id=\"txtBudingName" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtDealAddress" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtOriginalDealPrice" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtFinalDealPrice" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");

            SbHtml.Append("    <td><textarea id=\"txtCaCommPoint" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtKSa" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtEBCommPoint" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtCommPoint" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");

            SbHtml.Append("    <td><textarea id=\"txtCaOriginalComm" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtKSb" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtEBOriginalComm" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtOriginalComm" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");

            SbHtml.Append("    <td><textarea id=\"txtCaReduceCashBonus" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtKSc" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtEBReduceCashBonus" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtReduceCashBonus" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");

            SbHtml.Append("    <td><textarea id=\"txtCaReduceComm" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtKSd" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtEBReduceComm" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtReduceComm" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");

            SbHtml.Append("    <td><textarea id=\"txtTotalReduce" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("    <td><textarea id=\"txtActualReportMoney" + i + "\" style=\"width: 90%; overflow: hidden;\" rows=\"2\"></textarea></td>");
            SbHtml.Append("</tr>");
        }

        DetailCount = n;
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
        T_OfficeAutomation_Document_ReduceComm t_OfficeAutomation_Document_ReduceComm = new T_OfficeAutomation_Document_ReduceComm();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
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
                string[] sHRTree;
                try
                {
                    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                }
                catch
                {
                    Alert("请正确选择发文部门！");
                    return;
                }

                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();

                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ReduceComm" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 13;

                if (this.hidPageType.Value == "2")
                {
                    //用于区分 减让佣/现金奖申请表 是否电商类
                    t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ReduceCommEcommerce" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                    t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 102;
                }


                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Apply = EmployeeName;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForName = txtApplyFor.Value;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForCode = txtApplyForID.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentTypeID = int.Parse(ddlDepartmentType.SelectedValue);
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Subject = txtSubject.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Department = txtDepartment.Value;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentID = new Guid(hdDepartmentID.Value);
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReplyPhone = txtReplyPhone.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Reason = txtReason.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DealDepartment = txtDealDepartment.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_OriginalDealPrice = txtOriginalDealPrice.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_FinalDealPrice = txtFinalDealPrice.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CommPoint = txtCommPoint.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_OriginalComm = txtOriginalComm.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceCashBonus = txtReduceCashBonus.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceComm = txtReduceComm.Text;

                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBCommPoint = txtEBCommPoint.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaCommPoint = txtCaCommPoint.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBOriginalComm = txtEBOriginalComm.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaOriginalComm = txtCaOriginalComm.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBReduceCashBonus = txtEBReduceCashBonus.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaReduceCashBonus = txtCaReduceCashBonus.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBReduceComm = txtEBReduceComm.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaReduceComm = txtCaReduceComm.Text;

                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_TotalReduce = txtTotalReduce.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSa = txtKSa.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSb = txtKSb.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSc = txtKSc.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSd = txtKSd.Text;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ActualReportMoney = txtActualReportMoney.Text;
                //t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceWay = rdbReduceWay1.Checked ? 1 : rdbReduceWay2.Checked ? 2 : rdbReduceWay3.Checked ? 3 : 0;

                string way = "";
                if (rdbReduceWay1.Checked)
                    way += "1|";
                if (rdbReduceWay2.Checked)
                    way += "2|";
                if (rdbReduceWay3.Checked)
                    way += "3|";
                if (rdbReduceWay4.Checked)
                    way += "4|";
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceWay = way;
                t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Type = ReduceCommType.Value;//减让佣/现金奖类型
                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Value;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtSubject.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = txtApplyFor.Value;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_ReduceComm_Inherit.Add(t_OfficeAutomation_Document_ReduceComm);//插入申请表

                InsertReduceCommDetail(t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ID);

                //SYSREQ201802131214149765622
                //审批流程修改：只折让现金奖：天河区及海珠区：审批至区域负责人,其他跟之前一样
                if ("只折让现金奖" == ReduceCommType.Value && ("7" == ddlDepartmentType.SelectedValue || "8" == ddlDepartmentType.SelectedValue))
                {

                }
                else
                {
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

                    #region 添加前线总监

                    //int count = sHRTree[0].Split(',').Length;

                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sHRTree[0].Split(',')[0];
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sHRTree[1].Split(',')[0];
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;

                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                    #endregion

                    #region 根据所属区域增加法律部一级审批（2014-01-18 取消）

                    //string employeeID, employee;
                    //switch (ddlDepartmentType.SelectedItem.Text)
                    //{
                    //    case "天河区":
                    //        employee = CommonConst.EMP_LAW_TIANHE_NAME;
                    //        employeeID = CommonConst.EMP_LAW_TIANHE_ID;
                    //        break;
                    //    case "海珠区":
                    //        employee = CommonConst.EMP_LAW_HAIZHU_NAME;
                    //        employeeID = CommonConst.EMP_LAW_HAIZHU_ID;
                    //        break;
                    //    case "工商铺":
                    //        employee = CommonConst.EMP_LAW_GONGSHANGPU_NAME;
                    //        employeeID = CommonConst.EMP_LAW_GONGSHANGPU_ID;
                    //        break;
                    //    case "其他区":
                    //        employee = CommonConst.EMP_LAW_QITA_NAME;
                    //        employeeID = CommonConst.EMP_LAW_QITA_ID;
                    //        break;
                    //    default:
                    //        employee = CommonConst.EMP_LAW_QITA_NAME;
                    //        employeeID = CommonConst.EMP_LAW_QITA_ID;
                    //        break;
                    //}

                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = employeeID;
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = employee;
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 2;

                    //da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                    #endregion

                    #endregion
                }
                Common.AddLog(EmployeeID, EmployeeName, 17, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ReduceComm_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
                        sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                    }
                    catch
                    {
                        Alert("请正确选择发文部门！");
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

                        #region 添加前线总监

                        //int count = sHRTree[0].Split(',').Length;

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sHRTree[0].Split(',')[0];
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sHRTree[1].Split(',')[0];
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        #endregion

                        #region 根据所属区域增加法律部一级审批（2014-01-18 取消）

                        //string employeeID, employee;
                        //switch (ddlDepartmentType.SelectedItem.Text)
                        //{
                        //    case "天河区":
                        //        employee = CommonConst.EMP_LAW_TIANHE_NAME;
                        //        employeeID = CommonConst.EMP_LAW_TIANHE_ID;
                        //        break;
                        //    case "海珠区":
                        //        employee = CommonConst.EMP_LAW_HAIZHU_NAME;
                        //        employeeID = CommonConst.EMP_LAW_HAIZHU_ID;
                        //        break;
                        //    case "工商铺":
                        //        employee = CommonConst.EMP_LAW_GONGSHANGPU_NAME;
                        //        employeeID = CommonConst.EMP_LAW_GONGSHANGPU_ID;
                        //        break;
                        //    case "其他区":
                        //        employee = CommonConst.EMP_LAW_QITA_NAME;
                        //        employeeID = CommonConst.EMP_LAW_QITA_ID;
                        //        break;
                        //    default:
                        //        employee = CommonConst.EMP_LAW_QITA_NAME;
                        //        employeeID = CommonConst.EMP_LAW_QITA_ID;
                        //        break;
                        //}

                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = employeeID;
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = employee;
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 2;

                        //da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        #endregion

                        #endregion
                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ReduceComm_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                    }

                    else
                    {
                        DA_OfficeAutomation_Flow_Inherit dA_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                        DataTable dt = dA_OfficeAutomation_Flow_Inherit.SelectByMainIDAfterIdx(MainID, 3).Tables[0];
                        //审批流程修改：只折让现金奖：天河区及海珠区：审批至区域负责人
                        if ("只折让现金奖" == ReduceCommType.Value && ("7" == ddlDepartmentType.SelectedValue || "8" == ddlDepartmentType.SelectedValue))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                dA_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdx(MainID, 3);
                                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                            }
                        }
                        else
                        {
                            if (dt.Rows.Count == 0)
                            {
                                #region 保存默认流程
                                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                #region 根据默认流程表中的固定环节添加流程

                                DataSet ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(MainID);
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
                                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                            }
                        }
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
        var SerialNumber = "ReduceComm" + DateTime.Now.ToString("yyyyMMddHHmmssfffff");
        var DocumentID = 13;

        if (this.hidPageType.Value == "2")
        {
            SerialNumber = "ReduceCommEcommerce" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
            DocumentID = 102;
        }

        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
        if (MainID == "")
        {
            MainID = Guid.NewGuid().ToString();
        }
        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName, txtDepartment.Value);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }

        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        var ReduceComm = new T_OfficeAutomation_Document_ReduceComm();
        ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ReduceComm = GetModelFromPage(Guid.NewGuid());
        }
        else
        {
            var ReduceComm_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_ID"].ToString();
            ReduceComm = GetModelFromPage(new Guid(ReduceComm_ID));
        }
        var obj = new Apply_ReduceComm_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;

        //var PullafewTwo = GetModelFromPage(Guid.NewGuid());
        da_OfficeAutomation_Document_ReduceComm_Inherit.HandleBase(ReduceComm);                      //只插入关键必填字段；
        var ReduceComm_Detail = ReduceCommDetail(ReduceComm.OfficeAutomation_Document_ReduceComm_ID);


        obj.ReduceComm = ReduceComm;
        obj.ReduceComm_Detail = ReduceComm_Detail;

        //暂存数据保存到xml文件中
        var result = new Common().SaveTempSaveFile<Apply_ReduceComm_Detail>(obj, "ReduceCommDetail", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
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
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit da_OfficeAutomation_Document_ReduceComm_Detail_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ReduceComm_ID"].ToString();

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

                    //if (ckbAddIDx.Checked)//增加审批环节是否勾选，如果是则添加黄志超审批
                    if (this.hidAddIDxIsChecked.Value == "true")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 7;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                bool isSignSuccess = flowIDx == "4" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ReduceComm_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_ReduceComm_ApplyForName"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_ReduceComm_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ReduceComm_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>文件主题：关于" + drRow["OfficeAutomation_Document_ReduceComm_Subject"].ToString() + "的减佣让佣申请");
                    sbMailBody.Append("<br/>回复电话：" + drRow["OfficeAutomation_Document_ReduceComm_ReplyPhone"]);
                    sbMailBody.Append("<br/>让佣原因说明：" + drRow["OfficeAutomation_Document_ReduceComm_Reason"]);
                    sbMailBody.Append("<br/>减佣让佣交易涉及具体情况：");
                    ds = da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.SelectByApplyID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>成交日期：" + dr["OfficeAutomation_Document_ReduceComm_Detail_DealDate"]);
                        sbMailBody.Append("<br/>成交单位：" + dr["OfficeAutomation_Document_ReduceComm_Detail_DealDepartment"]);
                        sbMailBody.Append("<br/>原成交价：" + dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice"]);
                        sbMailBody.Append("<br/>客户最终成交价：" + dr["OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice"]);
                        sbMailBody.Append("<br/>现金奖点数：" + (dr["OfficeAutomation_Document_ReduceComm_Detail_CommPoint"]));
                        sbMailBody.Append("<br/>现金奖金额：" + (dr["OfficeAutomation_Document_ReduceComm_Detail_OriginalComm"]));
                        sbMailBody.Append("<br/>让现金奖金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus"]);
                        sbMailBody.Append("<br/>折让后现金奖金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_ReduceComm"]);

                        sbMailBody.Append("<br/>电商代理费点数：" + dr["OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint"]);
                        sbMailBody.Append("<br/>发展商代理费点数：" + dr["OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint"]);
                        sbMailBody.Append("<br/>合同约定客佣：" + dr["OfficeAutomation_Document_ReduceComm_Detail_Ksa"]);
                        sbMailBody.Append("<br/>电商佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm"]);
                        sbMailBody.Append("<br/>发展商佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm"]);
                        sbMailBody.Append("<br/>折让前客佣：" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSb"]);
                        sbMailBody.Append("<br/>让电商佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus"]);
                        sbMailBody.Append("<br/>让发展商佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus"]);
                        sbMailBody.Append("<br/>申请折让客佣：" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSc"]);
                        sbMailBody.Append("<br/>折让后电商佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm"]);
                        sbMailBody.Append("<br/>折让后发展商佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm"]);
                        sbMailBody.Append("<br/>折让后客佣：" + dr["OfficeAutomation_Document_ReduceComm_Detail_KSd"]);

                        sbMailBody.Append("<br/>楼盘名：" + dr["OfficeAutomation_Document_ReduceComm_Detail_BudingName"]);
                        sbMailBody.Append("<br/>总让佣金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_TotalReduce"]);
                        sbMailBody.Append("<br/>实际上数金额：" + dr["OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney"]);
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
                            employname = CommonConst.EMP_GMO_COPYTO_NAME;
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
        T_OfficeAutomation_Document_ReduceComm t_OfficeAutomation_Document_ReduceComm = new T_OfficeAutomation_Document_ReduceComm();
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_ID"].ToString();

        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ID = new Guid(ID);
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForName = txtApplyFor.Value;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForCode = txtApplyForID.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentTypeID = int.Parse(ddlDepartmentType.SelectedValue);
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Subject = txtSubject.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Department = txtDepartment.Value;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentID = new Guid(hdDepartmentID.Value);
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Reason = txtReason.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DealDepartment = txtDealDepartment.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_OriginalDealPrice = txtOriginalDealPrice.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_FinalDealPrice = txtFinalDealPrice.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CommPoint = txtCommPoint.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_OriginalComm = txtOriginalComm.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceCashBonus = txtReduceCashBonus.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceComm = txtReduceComm.Text;

        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBCommPoint = txtEBCommPoint.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaCommPoint = txtCaCommPoint.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBOriginalComm = txtEBOriginalComm.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaOriginalComm = txtCaOriginalComm.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBReduceCashBonus = txtEBReduceCashBonus.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaReduceCashBonus = txtCaReduceCashBonus.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBReduceComm = txtEBReduceComm.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaReduceComm = txtCaReduceComm.Text;

        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_TotalReduce = txtTotalReduce.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSa = txtKSa.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSb = txtKSb.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSc = txtKSc.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSd = txtKSd.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ActualReportMoney = txtActualReportMoney.Text;
        //t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceWay = rdbReduceWay1.Checked ? 1 : rdbReduceWay2.Checked ? 2 : rdbReduceWay3.Checked ? 3 : 0;
        string way = "";
        if (rdbReduceWay1.Checked)
            way += "1|";
        if (rdbReduceWay2.Checked)
            way += "2|";
        if (rdbReduceWay3.Checked)
            way += "3|";
        if (rdbReduceWay4.Checked)
            way += "4|";
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceWay = way;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Type = this.ReduceCommType.Value;//减让佣/现金奖类型
        string apply = "";
        string depname = this.txtDepartment.Value;
        string summary = this.txtSubject.Text;
        string applydate = "";
        string mainid = MainID;

        new DA_OfficeAutomation_Main_Inherit().UpdateMain(mainid, depname, apply, applydate, summary);

        da_OfficeAutomation_Document_ReduceComm_Inherit.Update(t_OfficeAutomation_Document_ReduceComm);//修改申请表

        DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit da_OfficeAutomation_Document_ReduceComm_Detail_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit();
        da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.Delete(new Guid(ID));
        InsertReduceCommDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 17, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增退佣申请明细

    /// <summary>
    /// 新增退佣申请明细
    /// </summary>
    /// <param name="gReduceCommID"></param>
    private void InsertReduceCommDetail(Guid gReduceCommID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_ReduceComm_Detail t_OfficeAutomation_Document_ReduceComm_Detail;
        DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit da_OfficeAutomation_Document_ReduceComm_Detail_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_ReduceComm_Detail = new T_OfficeAutomation_Document_ReduceComm_Detail();
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_MainID = gReduceCommID;
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_DealDate = DateTime.Parse(detail[0]);
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_DealDepartment = detail[1];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice = detail[2];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice = detail[3];



            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint = detail[4];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint = detail[5];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CommPoint = detail[6];

            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm = detail[7];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm = detail[8];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_OriginalComm = detail[9];

            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus = detail[10];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus = detail[11];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus = detail[12];

            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm = detail[13];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm = detail[14];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ReduceComm = detail[15];


            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_BudingName = detail[16];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_TotalReduce = detail[17];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_KSa = detail[18];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_KSb = detail[19];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_KSc = detail[20];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_KSd = detail[21];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney = detail[22];
            da_OfficeAutomation_Document_ReduceComm_Detail_Inherit.Add(t_OfficeAutomation_Document_ReduceComm_Detail);
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

    #region 从页面获取model数据
    public T_OfficeAutomation_Document_ReduceComm GetModelFromPage(Guid gReduceCommID)
    {
        T_OfficeAutomation_Document_ReduceComm t_OfficeAutomation_Document_ReduceComm = new T_OfficeAutomation_Document_ReduceComm();
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ID = gReduceCommID;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Apply = EmployeeName;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForName = txtApplyFor.Value;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyForCode = txtApplyForID.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentTypeID = int.Parse(ddlDepartmentType.SelectedValue == "" ? "0" : ddlDepartmentType.SelectedValue);
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Subject = txtSubject.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Department = txtDepartment.Value;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DepartmentID = hdDepartmentID.Value != "" ? new Guid(hdDepartmentID.Value) : Guid.NewGuid();
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Reason = txtReason.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_DealDepartment = txtDealDepartment.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_OriginalDealPrice = txtOriginalDealPrice.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_FinalDealPrice = txtFinalDealPrice.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CommPoint = txtCommPoint.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_OriginalComm = txtOriginalComm.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceCashBonus = txtReduceCashBonus.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceComm = txtReduceComm.Text;

        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBCommPoint = txtEBCommPoint.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaCommPoint = txtCaCommPoint.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBOriginalComm = txtEBOriginalComm.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaOriginalComm = txtCaOriginalComm.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBReduceCashBonus = txtEBReduceCashBonus.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaReduceCashBonus = txtCaReduceCashBonus.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_EBReduceComm = txtEBReduceComm.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_CaReduceComm = txtCaReduceComm.Text;

        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_TotalReduce = txtTotalReduce.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSa = txtKSa.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSb = txtKSb.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSc = txtKSc.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_KSd = txtKSd.Text;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ActualReportMoney = txtActualReportMoney.Text;

        string way = "";
        if (rdbReduceWay1.Checked)
            way += "1|";
        if (rdbReduceWay2.Checked)
            way += "2|";
        if (rdbReduceWay3.Checked)
            way += "3|";
        if (rdbReduceWay4.Checked)
            way += "4|";
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_ReduceWay = way;
        t_OfficeAutomation_Document_ReduceComm.OfficeAutomation_Document_ReduceComm_Type = ReduceCommType.Value;//减让佣/现金奖类型
        return t_OfficeAutomation_Document_ReduceComm;
    }

    public List<T_OfficeAutomation_Document_ReduceComm_Detail> ReduceCommDetail(Guid gReduceCommID)
    {
        if (hdDetail.Value == "")
            return null;

        var list = new List<T_OfficeAutomation_Document_ReduceComm_Detail>();
        T_OfficeAutomation_Document_ReduceComm_Detail t_OfficeAutomation_Document_ReduceComm_Detail;

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_ReduceComm_Detail = new T_OfficeAutomation_Document_ReduceComm_Detail();
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_MainID = gReduceCommID;
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_DealDate = DateTime.Parse(detail[0] == "" ? "1956-01-10" : detail[0]);
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_DealDepartment = detail[1];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice = detail[2];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice = detail[3];



            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint = detail[4];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint = detail[5];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CommPoint = detail[6];

            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm = detail[7];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm = detail[8];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_OriginalComm = detail[9];

            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus = detail[10];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus = detail[11];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus = detail[12];

            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm = detail[13];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm = detail[14];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ReduceComm = detail[15];


            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_BudingName = detail[16];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_TotalReduce = detail[17];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_KSa = detail[18];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_KSb = detail[19];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_KSc = detail[20];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_KSd = detail[21];
            t_OfficeAutomation_Document_ReduceComm_Detail.OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney = detail[22];
            list.Add(t_OfficeAutomation_Document_ReduceComm_Detail);
        }
        return list;
    }
    #endregion
    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite20"] = "1";
        Response.Write("<script>window.open('Apply_NewReduceComm_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("减让佣/现金奖申请表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ReduceComm_Department"].ToString();
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
            DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ReduceComm_Department"].ToString();
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
            DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ReduceComm_Department"].ToString();
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
            RunJS("var win=window.showModalDialog(\"Apply_ReduceComm_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    protected void btnSignIDx200_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        string[] employnames;
        string email;
        string msnBody;
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
        DataSet ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ReduceComm_Department"].ToString();
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

        //Review(200, txtIDx200.Value);
        //Review_New(txtIDx200.Value, flowManager);

        #region 复审
        var flowManager = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);  //管理流程
        //同意1，不同意0，其他意见2
        string sisa = "2";
        if (rdb220a1.Checked)
            sisa = "1";
        else if (rdb220a2.Checked)
            sisa = "0";
        var result = new FlowCommonMethod().Review(txtIDx200.Value, flowManager, MainID, EmployeeName, EmployeeID, sisa, 200);
        RunJS("alert('" + result.Split('|')[1] + "');window.location='" + Page.Request.Url + "'");
        #endregion
    }
    protected void btnSignIDx220_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ReduceComm_Department"].ToString();
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

        //Review(220, txtIDx220.Value);
        //Review_Manager(txtIDx220.Value);
        #region 总经理复审
        //同意1，不同意0，其他意见2
        string sisa = "2";
        if (rdb220a1.Checked)
            sisa = "1";
        else if (rdb220a2.Checked)
            sisa = "0";
        var result = new FlowCommonMethod().Review_Manager(txtIDx220.Value, MainID, EmployeeName, EmployeeID, sisa, 220);
        if (result.Split('|')[0] == "0")
        {
            RunJS("alert('" + result.Split('|')[1] + "');window.location='" + Page.Request.Url + "'");
        }
        else
        {
            RunJS("alert('" + result.Split('|')[1] + "');");
        }
        #endregion
    }

    #region 旧复审
    /*
    protected void Review(int index, string sug) //M_AddAnother：20150716 黄生其它意见，增加审批人
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3); //M_AlAno：20160217 ++
        flowsa = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, index);
        if (flowsa == null)
        {
            //流程不存在(新增流程)
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
    */
    #endregion

    protected void StructureFYQHTML(string pagetype)
    {

        //SbFYQ.Append("[FYQ]");

        //#region [法律部意见]
        //SbFYQ.Append(" <tr id=\"trShowFlow4\" class=\"noborder\" style=\"height: 85px;\"> <td rowspan=\"2\">法律部意见</td> ");
        //SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
        //SbFYQ.Append("      <input id=\"rdbYesIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbYesIDx4\">同意</label><input id=\"rdbNoIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbNoIDx4\">不同意</label><input id=\"rdbOtherIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbOtherIDx4\">其他意见</label><br /> ");
        //SbFYQ.Append("      <textarea id=\"txtIDx4\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx4\" value=\"签署意见\" onclick=\"sign('4')\" style=\"display: none;\" /> <br /> ");
        //SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx4\">_________</span> </span> </td> </tr> ");

        //SbFYQ.Append(" <tr id=\"trShowFlow5\" class=\"noborder\" style=\"height: 85px;\"> ");
        //SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
        //SbFYQ.Append("      <input id=\"rdbYesIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbYesIDx5\">同意</label><input id=\"rdbNoIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbNoIDx5\">不同意</label><input id=\"rdbOtherIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbOtherIDx5\">其他意见</label><br /> ");
        //SbFYQ.Append("      <textarea id=\"txtIDx5\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx5\" value=\"签署意见\" onclick=\"sign('5')\" style=\"display: none;\" /> <br /> ");
        //SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx5\">_________</span> </span> </td> </tr> ");
        //#endregion

        //#region [财务部意见]
        //SbFYQ.Append(" <tr id=\"trShowFlow6\" class=\"noborder\" style=\"height: 85px;\"> <td rowspan=\"3\">财务部意见</td> ");
        //SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
        //SbFYQ.Append("      <input id=\"rdbYesIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbYesIDx6\">同意</label><input id=\"rdbNoIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbNoIDx6\">不同意</label><input id=\"rdbOtherIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbOtherIDx6\">其他意见</label>");

        //string isHidden = this.hidAddIDxVisible.Value == "true" ? "visible" : "hidden";
        //SbFYQ.Append("      <input id=\"ckbAddIDx\" type=\"checkbox\" style=\"vertical-align:middle;visibility:" + isHidden + ";\" title=\"增加审批环节\" runat=\"server\" clientidmod=\"Static\" /> <label for=\"ckbAddIDx\" style=\"vertical-align:middle;visibility:" + isHidden + ";\">增加审批环节</label> </div><br /> ");

        //SbFYQ.Append("      <textarea id=\"txtIDx6\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx6\" value=\"签署意见\" onclick=\"sign('6')\" style=\"display: none;\" /> <br /> ");
        //SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx6\">_________</span> </span> </td> </tr> ");

        //SbFYQ.Append(" <tr id=\"trShowFlow7\" class=\"noborder\" style=\"height: 85px;\"> ");
        //SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
        //SbFYQ.Append("      <input id=\"rdbYesIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbYesIDx7\">同意</label><input id=\"rdbNoIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbNoIDx7\">不同意</label><input id=\"rdbOtherIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbOtherIDx7\">其他意见</label><br /> ");
        //SbFYQ.Append("      <textarea id=\"txtIDx7\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx7\" value=\"签署意见\" onclick=\"sign('7')\" style=\"display: none;\" /> <br /> ");
        //SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx7\">_________</span> </span> </td> </tr> ");

        //SbFYQ.Append(" <tr id=\"trShowFlow8\" class=\"noborder\" style=\"height: 85px;\"> ");
        //SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
        //SbFYQ.Append("      <input id=\"rdbYesIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbYesIDx8\">同意</label><input id=\"rdbNoIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbNoIDx8\">不同意</label><input id=\"rdbOtherIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbOtherIDx8\">其他意见</label><br /> ");
        //SbFYQ.Append("      <textarea id=\"txtIDx8\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx8\" value=\"签署意见\" onclick=\"sign('8')\" style=\"display: none;\" /> <br /> ");
        //SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx8\">_________</span> </span> </td> </tr> ");
        //#endregion

        //SbFYQ.Append("[FYQ1]");


        if (pagetype == "2")
        {
            #region [房友圈意见]
            SbFYQ.Append(" <tr id=\"trShowFlow4\" class=\"noborder\" style=\"height: 85px;\"> <td rowspan=\"2\">房友圈意见</td> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbYesIDx4\">同意</label><input id=\"rdbNoIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbNoIDx4\">不同意</label><input id=\"rdbOtherIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbOtherIDx4\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx4\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx4\" value=\"签署意见\" onclick=\"sign('4')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx4\">_________</span> </span> </td> </tr> ");

            SbFYQ.Append(" <tr id=\"trShowFlow5\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbYesIDx5\">同意</label><input id=\"rdbNoIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbNoIDx5\">不同意</label><input id=\"rdbOtherIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbOtherIDx5\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx5\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx5\" value=\"签署意见\" onclick=\"sign('5')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx5\">_________</span> </span> </td> </tr> ");
            #endregion

            #region [法律部意见]
            SbFYQ.Append(" <tr id=\"trShowFlow6\" class=\"noborder\" style=\"height: 85px;\"> <td rowspan=\"2\">法律部意见</td> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbYesIDx6\">同意</label><input id=\"rdbNoIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbNoIDx6\">不同意</label><input id=\"rdbOtherIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbOtherIDx6\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx6\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx6\" value=\"签署意见\" onclick=\"sign('6')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx6\">_________</span> </span> </td> </tr> ");

            SbFYQ.Append(" <tr id=\"trShowFlow7\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbYesIDx7\">同意</label><input id=\"rdbNoIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbNoIDx7\">不同意</label><input id=\"rdbOtherIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbOtherIDx7\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx7\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx7\" value=\"签署意见\" onclick=\"sign('7')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx7\">_________</span> </span> </td> </tr> ");
            #endregion

            #region [财务部意见]
            SbFYQ.Append(" <tr id=\"trShowFlow8\" class=\"noborder\" style=\"height: 85px;\"> <td rowspan=\"3\">财务部意见</td> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbYesIDx8\">同意</label><input id=\"rdbNoIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbNoIDx8\">不同意</label><input id=\"rdbOtherIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbOtherIDx8\">其他意见</label>");

            string isHidden = this.hidAddIDxVisible.Value == "true" ? "visible" : "hidden";
            SbFYQ.Append("      <input id=\"ckbAddIDx\" type=\"checkbox\" style=\"vertical-align:middle;visibility:" + isHidden + ";\" title=\"增加审批环节\" runat=\"server\" clientidmod=\"Static\" /> <label for=\"ckbAddIDx\" style=\"vertical-align:middle;visibility:" + isHidden + ";\">增加审批环节</label> </div><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx8\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx8\" value=\"签署意见\" onclick=\"sign('8')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx8\">_________</span> </span> </td> </tr> ");

            SbFYQ.Append(" <tr id=\"trShowFlow9\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx9\" type=\"radio\" name=\"agree9\" /><label for=\"rdbYesIDx9\">同意</label><input id=\"rdbNoIDx9\" type=\"radio\" name=\"agree9\" /><label for=\"rdbNoIDx9\">不同意</label><input id=\"rdbOtherIDx9\" type=\"radio\" name=\"agree9\" /><label for=\"rdbOtherIDx9\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx9\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx9\" value=\"签署意见\" onclick=\"sign('9')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx9\">_________</span> </span> </td> </tr> ");

            SbFYQ.Append(" <tr id=\"trShowFlow10\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx10\" type=\"radio\" name=\"agree10\" /><label for=\"rdbYesIDx10\">同意</label><input id=\"rdbNoIDx10\" type=\"radio\" name=\"agree10\" /><label for=\"rdbNoIDx10\">不同意</label><input id=\"rdbOtherIDx10\" type=\"radio\" name=\"agree10\" /><label for=\"rdbOtherIDx10\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx10\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx10\" value=\"签署意见\" onclick=\"sign('10')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx10\">_________</span> </span> </td> </tr> ");
            #endregion

            #region 董事总经理意见]
            SbFYQ.Append(" <tr id=\"trGeneralManager\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td >董事总经理<br />审批</td> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx13\" type=\"radio\" name=\"agree13\" /><label for=\"rdbYesIDx13\">同意</label><input id=\"rdbNoIDx13\" type=\"radio\" name=\"agree13\" /><label for=\"rdbNoIDx13\">不同意</label><input id=\"rdbOtherIDx13\" type=\"radio\" name=\"agree13\" /><label for=\"rdbOtherIDx13\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx13\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx13\" value=\"签署意见\" onclick=\"sign('13')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx13\">_________</span> </span> </td> </tr> ");
            #endregion
        }
        else
        {
            //SbFYQ.Replace("[FYQ]", "");
            //SbFYQ.Replace("[FYQ1]", sb.ToString());
            #region [法律部意见]
            SbFYQ.Append(" <tr id=\"trShowFlow4\" class=\"noborder\" style=\"height: 85px;\"> <td rowspan=\"2\">法律部意见</td> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbYesIDx4\">同意</label><input id=\"rdbNoIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbNoIDx4\">不同意</label><input id=\"rdbOtherIDx4\" type=\"radio\" name=\"agree4\" /><label for=\"rdbOtherIDx4\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx4\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx4\" value=\"签署意见\" onclick=\"sign('4')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx4\">_________</span> </span> </td> </tr> ");

            SbFYQ.Append(" <tr id=\"trShowFlow5\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbYesIDx5\">同意</label><input id=\"rdbNoIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbNoIDx5\">不同意</label><input id=\"rdbOtherIDx5\" type=\"radio\" name=\"agree5\" /><label for=\"rdbOtherIDx5\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx5\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx5\" value=\"签署意见\" onclick=\"sign('5')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx5\">_________</span> </span> </td> </tr> ");
            #endregion

            #region [财务部意见]
            SbFYQ.Append(" <tr id=\"trShowFlow6\" class=\"noborder\" style=\"height: 85px;\"> <td rowspan=\"3\">财务部意见</td> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbYesIDx6\">同意</label><input id=\"rdbNoIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbNoIDx6\">不同意</label><input id=\"rdbOtherIDx6\" type=\"radio\" name=\"agree6\" /><label for=\"rdbOtherIDx6\">其他意见</label>");

            string isHidden = this.hidAddIDxVisible.Value == "true" ? "visible" : "hidden";
            SbFYQ.Append("      <input id=\"ckbAddIDx\" type=\"checkbox\" style=\"vertical-align:middle;visibility:" + isHidden + ";\" title=\"增加审批环节\" runat=\"server\" clientidmod=\"Static\" /> <label for=\"ckbAddIDx\" style=\"vertical-align:middle;visibility:" + isHidden + ";\">增加审批环节</label> </div><br /> ");

            SbFYQ.Append("      <textarea id=\"txtIDx6\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx6\" value=\"签署意见\" onclick=\"sign('6')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx6\">_________</span> </span> </td> </tr> ");

            SbFYQ.Append(" <tr id=\"trShowFlow7\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbYesIDx7\">同意</label><input id=\"rdbNoIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbNoIDx7\">不同意</label><input id=\"rdbOtherIDx7\" type=\"radio\" name=\"agree7\" /><label for=\"rdbOtherIDx7\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx7\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx7\" value=\"签署意见\" onclick=\"sign('7')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx7\">_________</span> </span> </td> </tr> ");

            SbFYQ.Append(" <tr id=\"trShowFlow8\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbYesIDx8\">同意</label><input id=\"rdbNoIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbNoIDx8\">不同意</label><input id=\"rdbOtherIDx8\" type=\"radio\" name=\"agree8\" /><label for=\"rdbOtherIDx8\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx8\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx8\" value=\"签署意见\" onclick=\"sign('8')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx8\">_________</span> </span> </td> </tr> ");
            #endregion

            #region 董事总经理意见]
            SbFYQ.Append(" <tr id=\"trGeneralManager\" class=\"noborder\" style=\"height: 85px;\"> ");
            SbFYQ.Append("   <td >董事总经理<br />审批</td> ");
            SbFYQ.Append("   <td colspan=\"3\" class=\"tl PL10\" style=\"\"> ");
            SbFYQ.Append("      <input id=\"rdbYesIDx9\" type=\"radio\" name=\"agree9\" /><label for=\"rdbYesIDx9\">同意</label><input id=\"rdbNoIDx9\" type=\"radio\" name=\"agree9\" /><label for=\"rdbNoIDx9\">不同意</label><input id=\"rdbOtherIDx9\" type=\"radio\" name=\"agree9\" /><label for=\"rdbOtherIDx9\">其他意见</label><br /> ");
            SbFYQ.Append("      <textarea id=\"txtIDx9\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea><input type=\"button\" id=\"btnSignIDx9\" value=\"签署意见\" onclick=\"sign('9')\" style=\"display: none;\" /> <br /> ");
            SbFYQ.Append("      <span style=\"padding-right: 30px; padding-bottom: 10px; text-align: right; float: right;\">日期：<span id=\"spanDateIDx9\">_________</span> </span> </td> </tr> ");
            #endregion
        }
    }
}