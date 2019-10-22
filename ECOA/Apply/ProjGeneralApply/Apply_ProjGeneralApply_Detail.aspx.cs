﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using System.IO;

using DataAccess.Operate;
using DataEntity;

using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;
using System.Collections;

using System.Diagnostics; //M_PDF

public partial class Apply_ProjGeneralApply_Apply_ProjGeneralApply_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbJsonf = new StringBuilder();
    public string ApplyN;
    public string ApplyDisplayPart = "$(\"#btnAddFlow\").show();$(\"#btnDeleteFlow\").show();$(\"#divUploadDetailed\").show();";
    public string SkyPlay = "0";

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
        GetManagers();
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
                    SbJs.Append("<script type=\"text/javascript\">$(\"div .flow\").hide();$(\"#PageBottom\").hide();</script>");
                    tpdf = true;
                }
            }
            catch
            { }
            try
            {
                if (Session["FLG_ReWrite44"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite44"] = null;
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
        DrawDetailTable(0);
        SbJs.Append("$(\"#trM0\").show();");
        SbJs.Append("$(\"#trM1\").show();");
        SbJs.Append("$(\"#txtIDxa1\").val(\'" + EmployeeName + "\')");

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
        DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();

        string flowState;
        try
        {
            flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
            //2016/9/9 52100
            if (flowState == "7")
            {
                IsTempSave = true;
            }
            else
            {
                this.btnTemp.Visible = false;
            }
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

        SbJs.Append("$(\"#trManager1\").show();");
        SbJs.Append("$(\"#trManager2\").show();");
        SbJs.Append("$(\"#trManager3\").show();");
        //SbJs.Append("$(\"#ibta\").click();");
        //SbJs.Append("$(\"#ibta\").html(\"切换普通模式\");");
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
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
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ProjGeneralApply_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_ProjGeneralApply_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_ProjGeneralApply_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ProjGeneralApply_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtReplyPhone.Text = dr["OfficeAutomation_Document_ProjGeneralApply_ReplyPhone"].ToString();
        txtSubject.Text = dr["OfficeAutomation_Document_ProjGeneralApply_Subject"].ToString();
        txtFax.Text = dr["OfficeAutomation_Document_ProjGeneralApply_Fax"].ToString();

        txtCanSeeEmp.Text = dr["OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeName"].ToString();

        txtDescribe.Text = dr["OfficeAutomation_Document_ProjGeneralApply_Describe"].ToString();
        lbDescribe.Text = dr["OfficeAutomation_Document_ProjGeneralApply_Describe"].ToString();
        //ckeDescribe.Text = dr["OfficeAutomation_Document_GeneralApply_Describe"].ToString();
        //editor_id.Text = dr["OfficeAutomation_Document_GeneralApply_Describe"].ToString();

        txtReceiveDepartment.Text = dr["OfficeAutomation_Document_ProjGeneralApply_ReceiveDepartment"].ToString();
        txtCCDepartment.Text = dr["OfficeAutomation_Document_ProjGeneralApply_CCDepartment"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        //用于验证申请内容是否有变
        this.hdChangeChecking.Value = dr["OfficeAutomation_Document_ProjGeneralApply_ApplyID"].ToString()
                + dr["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString()
                + dr["OfficeAutomation_Document_ProjGeneralApply_ReplyPhone"].ToString()
                + dr["OfficeAutomation_Document_ProjGeneralApply_Subject"].ToString()
                + dr["OfficeAutomation_Document_ProjGeneralApply_Fax"].ToString()
                + dr["OfficeAutomation_Document_ProjGeneralApply_Describe"].ToString()
                + dr["OfficeAutomation_Document_ProjGeneralApply_ReceiveDepartment"].ToString()
                + dr["OfficeAutomation_Document_ProjGeneralApply_CCDepartment"].ToString();
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        if (isApplicant)
        {
            
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1" || flowState == "7")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                SbJs.Append("$(\"#trM0\").show();");
                SbJs.Append("$(\"#trM1\").show();");
                SbJs.Append("$(\"#trManager1\").show();");
                SbJs.Append(ApplyDisplayPart);
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
                SbJs.Append("$(\"#trM0\").show();");
                SbJs.Append("$(\"#trM1\").show();");
                SbJs.Append("$(\"#trManager1\").show();");
                SbJs.Append(ApplyDisplayPart);
            }
        }
        if (!isApplicant || flowState == "3") //M_New：新功能，完成或其它人打开时可显示横向滚动条 20150603 
        {
            pnDescribe.Visible = true; //M_WillAlter
            txtDescribe.Visible = false;

            //ckeDescribe.Visible = false;
            //editor_id.Visible = false;
            //SbJs.Append("$(\"#editor_id\").hide();");
            SbJs.Append("$(\"#ibta\").hide();");
        }

        if (!isApplicant && EmployeeID != "1649")
        {
            #region 只有申请人和关婉莹才可见查阅人
            SbJs.Append("$(\"#trcansee\").hide();");
            #endregion
        }

        //20170412
        if (EmployeeID == "1649" && (flowState=="1" || flowState=="2")) 
        {
            btnSaveCanSeeEmp.Visible = true;
        }

        #region 20150716 黄生其它意见，增加审批人

        try //M_AddAnother：20150716 黄生其它意见，增加审批人
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
            DataSet dsFlow2 = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
            DataRowCollection drcz = dsFlow2.Tables[0].Rows;
            T_OfficeAutomation_Flow flowsa, flowst,fst1, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 3);
           // SYSREQ201803161103592786141 修改为申请人回复意见
            fst1 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 1);
            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 20000);
            flowst = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndEID(MainID, "0001");
          //  flowst = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndEID(MainID, "50203");
            var flowsm = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 22000);       //总经理复审流程
            #region 复审相关
            //是否允许复审
            if (flowst != null && flowst.OfficeAutomation_Flow_IsAgree == 2 && flowst.OfficeAutomation_Flow_Audit == true)
            {
                SbJs.Append("$(\"#trAddAnoF1\").show();");
                //黄生回复过并且回复其他意见并且流程已结束
                //if ((fst1.OfficeAutomation_Flow_Auditor.Contains(EmployeeName) && fst1.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)) || (fst3.OfficeAutomation_Flow_Auditor.Contains(EmployeeName) && fst3.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)))
                //{
                if (EmployeeName == applicant || (fst3.OfficeAutomation_Flow_Auditor.Contains(EmployeeName) && fst3.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)))
                {

                    //登录人是申请人或者是区域的负责人
                    if (flowsa == null)
                    {
                        //复审流程是否存在
                        btnsSignIDx20000.Visible = true;
                    }
                    else if (flowsa != null && flowsa.OfficeAutomation_Flow_Audit)
                    {
                        //复审流程存在并已经审核完
                        if (flowsm == null || (flowsm.OfficeAutomation_Flow_Audit && flowsm.OfficeAutomation_Flow_IsAgree != 1 && flowsm.OfficeAutomation_Flow_IsAgree != 0))
                        {
                            //220流程不存在或者220流程未结束
                            btnsSignIDx20000.Visible = true;
                        }
                    }
                    else if (flowsa != null && !flowsa.OfficeAutomation_Flow_Audit)
                    {
                        //复审流程存在并未审核完
                        if (!(flowsa.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID) && flowsa.OfficeAutomation_Flow_Auditor.Contains(EmployeeName)))
                        {
                            //未审核过的人登录
                            btnsSignIDx20000.Visible = true;
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
                btnsSignIDx22000.Visible = true;
                SbJs.Append("$(\"#txtIDx22000\").hide();");
            }
            #endregion
            /*
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF1\").show();");
            if (((drcz[0]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID)
                && drcz[0]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || (EmployeeName == applicant && flowst.OfficeAutomation_Flow_IsAgree == 2) || (fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowst.OfficeAutomation_Flow_IsAgree == 2) 
                )
            {
                SbJs.Append("$(\"#trAddAnoF1\").show();");
                btnsSignIDx20000.Visible = true;
                if ((!fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName)) && flowsa != null)
                    btnsSignIDx20000.Visible = false; //M_AlAno：20160217 ++
            }

            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 22000);
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF3\").show();");
            if (flowst.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)
                && flowst.OfficeAutomation_Flow_Auditor.Contains(EmployeeName)
                && flowst.OfficeAutomation_Flow_IsAgree == 2
                && flowsa != null
                )
                btnsSignIDx22000.Visible = true;
             * */
        }
        catch
        {
        }

        #endregion

        #endregion

        #region 登录人为特定的帐号，且流程为完成状态时，标识留档按钮开启。

        if ((EmployeeID == "8258" || EmployeeID == "34498") && flowState == "3") //M_Remark：Win 20151109
            btnSignSave.Visible = true;

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                pnDescribe.Visible = false;
                txtDescribe.Visible = true;
                //ckeDescribe.Visible = false;
                //editor_id.Visible = false;
                //SbJs.Append("$(\"#editor_id\").hide();");
                //SbJs.Append("$(\"#ibta\").show();");

                DrawDetailTable(0);
                SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("$(\"#trM0\").show();");
                SbJs.Append("$(\"#trM1\").show();");
                SbJs.Append("$(\"#trManager1\").hide();");
                SbJs.Append("$(\"#trManager2\").hide();");
                SbJs.Append("$(\"#trManager3\").hide();");
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
                btnReWrite.Visible = true;
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

        try
        {
            T_OfficeAutomation_Flow flowsz;
            flowsz = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
            if (flowsz.OfficeAutomation_Flow_EmployeeID == "0001")
            {
                MasterEnd();
            }
        }
        catch
        {
        }

        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        if (Purview.Contains("OA_Search_002"))//789
            GetAllDepartment();
        T_OfficeAutomation_Flow flowsk;//789
        flowsk = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 601);
        if (EmployeeID == "10054" && flowState != "1" && flowsk == null)
        {
            T_OfficeAutomation_Flow flows;//789
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndID(MainID, "10054", 3);
            SbJs.Append("$(\"#add1F\").show();$(\"#afa\").show();$(\"#dfd\").show();");
            btnSaveLogisticsFlow.Visible = true;
            try
            {
                ViewState["Sky"] = flows.OfficeAutomation_Flow_Idx.ToString();
                SkyPlay = flows.OfficeAutomation_Flow_Idx.ToString();
            }
            catch
            {
                ViewState["Sky"] = "0";
                SkyPlay = "0";
            }
        }
        foreach (DataRow drs in drc)
        {
            string idx = drs["OfficeAutomation_Flow_Idx"].ToString();
            if (!Regex.IsMatch(((float.Parse(idx) - 1) / 3.0).ToString(), "^[0-9]*[1-9][0-9]*$"))
                SbJs.Append("$('#divIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();$('#divTxtIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();");
            SbJs.Append("$('#txtIDxa" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_Employee"] + ",');");
            //SbJs.Append("$('#hdIDx" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_EmployeeID"] + "');");
        }
        DataSet ds2 = new DataSet();
        bool x2 = false, x3 = false;
        ds2 = da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SelectByID(ID);
        int detailCount = ds2.Tables[0].Rows.Count;
        ViewState["FSIN"] = "";
        if (detailCount == 0)
        {
            if (isApplicant)
                DrawDetailTable(0);
            SbJs.Append("$('#tho').hide();");
        }
        else
        {
            if (isApplicant)
                DrawDetailTable(detailCount / 3);
            for (int n = 0, i = 1; n < detailCount; n++, i++)
            {
                int fon = 0, y2 = 0, y3 = 0;
                dr = ds2.Tables[0].Rows[n];
                SbJs.Append("$('#txtDpm" + i + "').val('" + dr["OfficeAutomation_Document_GeneralApply_Detail_Department"] + "');");
                SbJs.Append("$('#rdoIsCmodel" + i + "1" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                fon = int.Parse(dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString());
                n++;
                dr = ds2.Tables[0].Rows[n];
                x2 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + i + "2" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                y2 = int.Parse(dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString());
                n++;
                dr = ds2.Tables[0].Rows[n];
                x3 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + i + "3" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                y3 = int.Parse(dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString());
                DrawAFTable(fon, x2, x3, dr["OfficeAutomation_Document_GeneralApply_Detail_Department"].ToString(), y2, y3);
            }
        }

        SbFlow.Append("<div class=\"flow\">");
        //SbFlow.Append("审批流程:");
        //2016/9/9 52100
        if (!IsTempSave) { SbFlow.Append("审批流程:"); }

        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (curemp.Contains(EmployeeName))
            {
                SbJs.Append("$(\"#btnUpload\").show();");
                //switch (curidx)
                //{
                //    case "6":
                //        ckbAddIDx6.Visible = true;
                //        break;
                //    default:
                //        break;
                //}
            }
            //if (curidx == "9")
            //    flag3 = true;

            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                if (curemp == "梁健菁" && "1".Equals(Mainobj.OfficeAutomation_Main_IsGroups))
                {
                    SbFlow.Append("auditing\">待集团审理");
                }
                else
                {
                    SbFlow.Append("auditing\">待" + curemp + "审理");
                }
                flag2 = false;

                if ((curemp.Contains("宁伟雄") || curemp.Contains("黄志超")) && !drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID))
                {
                    SbJs.Append("$(\"[id*=lbtnAddN]\").show();$(\"[id*=lbtnDelN]\").show();");
                }
            }
            else
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                {
                    if (curemp == "梁健菁" && "1".Equals(Mainobj.OfficeAutomation_Main_IsGroups))
                        SbFlow.Append("other\">" + "集团已完成审理");
                    else
                        SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Auditor"] + "已完成审理");
                }
                else
                {
                    if (curemp == "梁健菁" && "1".Equals(Mainobj.OfficeAutomation_Main_IsGroups))
                        SbFlow.Append("other\">" + "集团");
                    else
                        SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Employee"]);
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
            //string[] auditor = drc[i]["OfficeAutomation_Flow_Employee"].ToString().Split(',');
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 20px; height: 2px; margin-left:0px;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                foreach (string s in auditorIDs)
                {
                    if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                    {
                        SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                    }
                    SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" style=\"margin-left:10px;margin-top:10px;\" />");
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
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 20px; height: 2px; margin-left:20px;\">"
                                        + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" style=\"margin-left:10px;margin-top:10px;\" />");
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
                {
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').show();");

                }

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
        //SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();$('#trGeneralManager').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        //if (flowState == "1" && applicant == EmployeeName)
        //    SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        //if (flowState == "2" && applicant == EmployeeName) //20141215：M_AlterC
        //    btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

        ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID); //20141231：M_DeleteC
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {

            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByMID(MainID);
            SbJs.Append("$('#btnADelete').before('<div id=\"SummaryOfDelete_Red\" style=\"color: red; font-size: large; font-weight: bold\">（该表即将被删除）</div>');$('h1').css('color','red');$('h1').attr('name','DeleteD');");
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
        //autoTextarea(document.getElementById(\"txtIDx2\"));autoTextarea(document.getElementById(\"txtIDx3\"));
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
        T_OfficeAutomation_Document_ProjGeneralApply t_OfficeAutomation_Document_ProjGeneralApply = new T_OfficeAutomation_Document_ProjGeneralApply();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ProjGeneralApply_Operate ProjGeneralApply_Operate = new DA_OfficeAutomation_Document_ProjGeneralApply_Operate();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion
        try
        {
            string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
            if (flowState == "3")
            {
                RunJS("alert('该表已审批完毕，不能再修改了！');window.location.href='" + Page.Request.Url + "';");
                return;
            }
        }
        catch
        {
        }

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
                IsNewApply = false;

                RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=通用申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ProjGeneralApply" + DateTime.Now.ToString("yyyyMMddHHmmssf");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 82; //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                t_OfficeAutomation_Document_ProjGeneralApply = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtSubject.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                ProjGeneralApply_Operate.Add(t_OfficeAutomation_Document_ProjGeneralApply);//插入申请表
                InsertGeneralApplyDetail(t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_ID);

                Common.AddLog(EmployeeID, EmployeeName, 82, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("alert('申请表保存成功！');var returnVaulue=window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';");
                //RunJS("alert('申请表保存成功！');var va=window.showModalDialog(\"/Ajax/Flow_Handler.ashx?action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=通用申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "\");if(va == 'success'){var returnVaulue=window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';}else alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，\\n请修改，如依然失败，请联系资讯科技部！错误代码：\" + va);");
                //RunJS("alert('申请表保存成功！');$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=通用申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){var returnVaulue=window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';}else if (info == \"NoPower\")alert(\"未开通修改编辑权限！\");else if (info == \"Conpleted\")alert(\"该表已审批完毕，不能再修改了！\");else alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);}})");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainID(MainID);
                    RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=通用申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");

                    Update();
                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID + "'");
                    //是否暂存
                    bool tempsave = MainObj.OfficeAutomation_Main_FlowStateID == 7;
                    if (tempsave)
                    {
                        MainObj.OfficeAutomation_Main_FlowStateID = 2;
                        da_OfficeAutomation_Main_Inherit.Edit(MainObj);
                        RunJS("alert('申请表保存成功！');var returnVaulue=window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';");
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
        var SerialNumber = "ProjGeneralApply" + DateTime.Now.ToString("yyyyMMddHHmmss");
        var DocumentID = 82;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName,txtDepartment.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }
        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        T_OfficeAutomation_Document_ProjGeneralApply t_OfficeAutomation_Document_ProjGeneralApply = new T_OfficeAutomation_Document_ProjGeneralApply();
        DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
        ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            t_OfficeAutomation_Document_ProjGeneralApply = GetModelFromPage(Guid.NewGuid());
        }
        else
        {
            var ProjGeneralApply_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_ID"].ToString();
            t_OfficeAutomation_Document_ProjGeneralApply = GetModelFromPage(new Guid(ProjGeneralApply_ID));
        }

        var result = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.HandleBase(t_OfficeAutomation_Document_ProjGeneralApply);                      //只插入关键必填字段；
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

        DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();

        DataSet ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ProjGeneralApply_ID"].ToString();

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

                        string[] auditor = drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString().Split(',');
                        string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
                        string[] auditorName = drc[i]["OfficeAutomation_Flow_Employee"].ToString().Split(',');
                        flowIDx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();

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


                //是否单人审核或同时审核。
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');

                // bool isSignSuccess = false;

                //20161227修改 本来是想在后台判断审批连续点击2下，如果签名按钮传入的是该登录人审批的步数才会审批，如果第二次点击到下一步的话就不能审批，后来改为在页面禁止签名按钮第二次点击
                //if (hdidx.Value.ToString() == flowIDx)
                //{
                bool isSignSuccess = ((IList)flowN).Contains(flowIDx) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                // }

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody = "";

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_ProjGeneralApply_Apply"]);
                    sbMailBody.Append("<br/>发文部门：" + drRow["OfficeAutomation_Document_ProjGeneralApply_Department"]);
                    sbMailBody.Append("<br/>发文日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ProjGeneralApply_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>发文编号：" + drRow["OfficeAutomation_Document_ProjGeneralApply_ApplyID"]);
                    sbMailBody.Append("<br/>收文部门：" + drRow["OfficeAutomation_Document_ProjGeneralApply_ReceiveDepartment"]);
                    sbMailBody.Append("<br/>抄送部门：" + drRow["OfficeAutomation_Document_ProjGeneralApply_CCDepartment"]);
                    sbMailBody.Append("<br/>回复电话：" + drRow["OfficeAutomation_Document_ProjGeneralApply_ReplyPhone"]);
                    sbMailBody.Append("<br/>回复传真：" + drRow["OfficeAutomation_Document_ProjGeneralApply_Fax"]);
                    sbMailBody.Append("<br/>文件主题：关于" + drRow["OfficeAutomation_Document_ProjGeneralApply_Subject"] + "的申请");
                    sbMailBody.Append("<br/>正 文：" + drRow["OfficeAutomation_Document_ProjGeneralApply_Describe"]);
                    sbMailBody.Append("<br/><br/>");

                    mailBody = sbMailBody.ToString();

                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意

                        //判断审批流程是否完成,通知相应人员
                        if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID))
                        {

                            string IsGroups = dsg.Tables[0].Rows[0]["OfficeAutomation_Main_IsGroups"].ToString();
                            if ("1".Equals(IsGroups))
                            {
                                msnBody = "您好，梁健菁：编号为" + serialNumber + "的需要集团审理请前往申请导出pdf。<br />" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                string Groupsemail = "梁健菁";
                                if (hdIsAgree.Value == "2")
                                    Common.SendMessageEX(false, Groupsemail, "其他意见", msnBody, msnBody);
                                else
                                    Common.SendMessageEX(false, Groupsemail, "申请已同意", msnBody, msnBody);
                            }
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

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）梁晶晶（工号：32188）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            employname = CommonConst.EMP_GMO_NAME;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]) && employeeList.Contains("黄轩明"))
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

                            //20160510 梁锐华签名的都给倪秀珊出提醒邮件
                            if (signEmployeeName.Contains("梁锐华"))
                            {
                                employnames = new string[] { "倪秀珊" };
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    msnBody = "您好，" + employnames[i] + "：请注意" + signEmployeeName + "有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(false, email, "请注意" + signEmployeeName + "通过了一份电子审批需要", msnBody + mailBody, msnBody);
                                }
                            }
                            //20160510

                            //通知下一步需要审批的人员
                            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                            if (!employname.Contains(EmployeeName))
                            { string IsGroups = dsg.Tables[0].Rows[0]["OfficeAutomation_Main_IsGroups"].ToString();
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
                                    msnBody = "您好，" + employnames[i] + "：您有" + department
                                        + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
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
        T_OfficeAutomation_Document_ProjGeneralApply t_OfficeAutomation_Document_ProjGeneralApply = new T_OfficeAutomation_Document_ProjGeneralApply();
        DA_OfficeAutomation_Document_ProjGeneralApply_Operate ProjGeneralApply_Operate = new DA_OfficeAutomation_Document_ProjGeneralApply_Operate();

        DataSet ds = new DataSet();
        ds = ProjGeneralApply_Operate.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_ID"].ToString();

        t_OfficeAutomation_Document_ProjGeneralApply = GetModelFromPage(new Guid(ID));

        string apply = "";
        string depname = this.txtDepartment.Text;
        string summary = this.txtSubject.Text;
        string applydate = "";
        string mainid = MainID;

        new DA_OfficeAutomation_Main_Inherit().UpdateMain(mainid, depname, apply, applydate, summary);
        ProjGeneralApply_Operate.Edit(t_OfficeAutomation_Document_ProjGeneralApply);//修改申请表

        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Delete(ID);
        InsertGeneralApplyDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 82, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    public void DrawDetailTable(int n)
    {
        //DataSet dsApplyDetail = new DataSet();
        //DataSet dsApplyType = new DataSet();

        //DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
        //dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(1);
        //DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
        //dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();

        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id=\"trDetail" + i + "\" class=\"noborder\" style=\"height: 85px;\">");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px;\" colspan=\"4\">");
            SbHtml.Append("<div class=\"flow\">");
            SbHtml.Append("部门名称：<input type=\"text\" id=\"txtDpm" + i + "\" style=\"margin-bottom: 10px;width:250px;\" /><br/>");
            SbHtml.Append("<div id=\"divIDx" + (3 * i + 1) + "\" class=\"item2\">环节1</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (3 * i + 1) + "\" class=\"item2\">");
            SbHtml.Append("   <input type=\"text\" id=\"txtIDxa" + (3 * i + 1) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (3 * i + 1) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + i + "11\" checked=\"checked\" name=\"IsCmodel" + i + "1\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + i + "11\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + i + "10\" name=\"IsCmodel" + i + "1\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + i + "10\">单人审批</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (3 * i + 2) + "\" class=\"item2\"><input id=\"btnIDx" + i + "2\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (3 * i + 2) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + i + "2\" for=\"btnIDx" + i + "2\">环节2</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (3 * i + 2) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节2&nbsp;<input type=\"text\" id=\"txtIDxa" + (3 * i + 2) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (3 * i + 2) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + i + "21\" checked=\"checked\" name=\"IsCmodel" + i + "2\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + i + "21\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + i + "20\" name=\"IsCmodel" + i + "2\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + i + "20\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (3 * i + 2) + ")\">取消</a>");
            SbHtml.Append("</div>");
            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (3 * i + 3) + "\" class=\"item2\"><input id=\"btnIDx" + i + "3\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (3 * i + 3) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + i + "3\" for=\"btnIDx" + i + "3\">环节3</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (3 * i + 3) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节3&nbsp;<input type=\"text\" id=\"txtIDxa" + (3 * i + 3) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (3 * i + 3) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + i + "31\" checked=\"checked\" name=\"IsCmodel" + i + "3\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + i + "31\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + i + "30\" name=\"IsCmodel" + i + "3\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + i + "30\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (3 * i + 3) + ")\">取消</a>");
            SbHtml.Append("</div></div>");
            SbHtml.Append("</td>");
            SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }
    public void DrawAFTable(int n, bool x2, bool x3, string department, int y2, int y3)
    {
        string apd = "";
        if (EmployeeID == "13545")
            apd = "宁伟雄";
        else if (EmployeeID == "5585")
            apd = "黄志超";
        for (int i = 1; i <= 1; i++)
        {
            int j = 0, k = n;
            if (x2 && x3)
                j = 3;
            else if ((!x2 && x3) || (x2 && !x3))
                j = 2;
            else if (!x2 && !x3)
                j = 1;
            SbHtml2.Append("<tr class=\"noborder\" style=\"height: 85px;\">");

            if (department == "后勤事务部" && EmployeeID == "10054")
                SbHtml2.Append("<td rowspan=\"" + j + "\"  class=\"auto-style2\">" + department + "<br /><input type=\"button\" value=\"跳过\" onclick=\"ShouldJump('" + department + "')\" id=\"btnShouldJumpIDx" + n + "\"/><br/><input type=\"button\" value=\"结束\" onclick=\"WillEnd()\" id=\"btnWillEnd" + n + "\"/></td>");
            else if (JumpOrNot(department))
                SbHtml2.Append("<td rowspan=\"" + j + "\"  class=\"auto-style2\">" + department + "<br /><input type=\"button\" value=\"跳过\" onclick=\"ShouldJump('" + department + "')\" id=\"btnShouldJumpIDx" + n + "\"/></td>");
            else
                SbHtml2.Append("<td rowspan=\"" + j + "\"  class=\"auto-style2\">" + department + "</td>");

            SbHtml2.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
            SbHtml2.Append("	<input id=\"rdbYesIDx" + k + "\" type=\"radio\" name=\"agree" + k + "\" />");
            SbHtml2.Append("    <label for=\"rdbYesIDx" + k + "\">同意</label>");
            SbHtml2.Append("    <input id=\"rdbNoIDx" + k + "\" type=\"radio\" name=\"agree" + k + "\" />");
            SbHtml2.Append("    <label for=\"rdbNoIDx" + k + "\">不同意</label>");
            SbHtml2.Append("    <input id=\"rdbOtherIDx" + k + "\" type=\"radio\" name=\"agree" + k + "\" />");
            SbHtml2.Append("    <label for=\"rdbOtherIDx" + k + "\">其他意见</label>");
            if (department.Contains("财务") && (EmployeeID == "5585" || EmployeeID == "13545")) //M_AddNWX：20150511 
                SbHtml2.Append("　<a id=\"lbtnAddN" + k + "\" href=\"javascript:void(0)\" style=\"display: none;\" onclick=\"AddNWX()\">添加" + apd + "审批</a>　<a id=\"lbtnDelN" + k + "\" href=\"javascript:void(0)\" style=\"display: none;\" onclick=\"DelNWX()\">取消" + apd + "审批</a>");
            SbHtml2.Append("	<textarea id=\"txtIDx" + k + "\" rows=\"5\" style=\"width: 98%; overflow: auto;\"></textarea>");
            SbHtml2.Append("    <input type=\"button\" id=\"btnSignIDx" + k + "\" value=\"签署意见\" onclick=\"sign(\'" + k + "\')\" style=\"display: none;\" />");
            SbHtml2.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + k + "\">_________</span></div>");
            SbHtml2.Append("</td>");
            SbHtml2.Append("</tr>");
            //SbHtml2.Append("<script type=\"text/javascript\">autoTextarea(document.getElementById(\"txtIDx" + k + "\"));</script>");
            if (x2)
            {
                SbHtml2.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtml2.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtml2.Append("	<input id=\"rdbYesIDx" + y2 + "\" type=\"radio\" name=\"agree" + y2 + "\" />");
                SbHtml2.Append("    <label for=\"rdbYesIDx" + y2 + "\">同意</label>");
                SbHtml2.Append("    <input id=\"rdbNoIDx" + y2 + "\" type=\"radio\" name=\"agree" + y2 + "\" />");
                SbHtml2.Append("    <label for=\"rdbNoIDx" + y2 + "\">不同意</label>");
                SbHtml2.Append("    <input id=\"rdbOtherIDx" + y2 + "\" type=\"radio\" name=\"agree" + y2 + "\" />");
                SbHtml2.Append("    <label for=\"rdbOtherIDx" + y2 + "\">其他意见</label>");
                //if (department == "财务部" && (EmployeeID == "5585" || EmployeeID == "13545")) //M_AddNWX：20150511
                //    SbHtml2.Append("　<a id=\"lbtnAddN" + y2 + "\" href=\"javascript:void(0)\" onclick=\"AddNWX()\">添加" + apd + "审批</a>　<a id=\"lbtnDelN" + y2 + "\" href=\"javascript:void(0)\" onclick=\"DelNWX()\">取消" + apd + "审批</a>");
                SbHtml2.Append("	<textarea id=\"txtIDx" + y2 + "\" rows=\"5\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtml2.Append("    <input type=\"button\" id=\"btnSignIDx" + y2 + "\" value=\"签署意见\" onclick=\"sign(\'" + y2 + "\')\" style=\"display: none;\" />");
                SbHtml2.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + y2 + "\">_________</span></div>");
                SbHtml2.Append("</td>");
                SbHtml2.Append("</tr>");
                //SbHtml2.Append("<script type=\"text/javascript\">autoTextarea(document.getElementById(\"txtIDx" + y2 + "\"));</script>");
            }
            if (x3)
            {
                SbHtml2.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtml2.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtml2.Append("	<input id=\"rdbYesIDx" + y3 + "\" type=\"radio\" name=\"agree" + y3 + "\" />");
                SbHtml2.Append("    <label for=\"rdbYesIDx" + y3 + "\">同意</label>");
                SbHtml2.Append("    <input id=\"rdbNoIDx" + y3 + "\" type=\"radio\" name=\"agree" + y3 + "\" />");
                SbHtml2.Append("    <label for=\"rdbNoIDx" + y3 + "\">不同意</label>");
                SbHtml2.Append("    <input id=\"rdbOtherIDx" + y3 + "\" type=\"radio\" name=\"agree" + y3 + "\" />");
                SbHtml2.Append("    <label for=\"rdbOtherIDx" + y3 + "\">其他意见</label>");
                //if (department == "财务部" && (EmployeeID == "5585" || EmployeeID == "13545")) //M_AddNWX：20150511
                //    SbHtml2.Append("　<a id=\"lbtnAddN" + y3 + "\" href=\"javascript:void(0)\" onclick=\"AddNWX()\">添加" + apd + "审批</a>　<a id=\"lbtnDelN" + y3 + "\" href=\"javascript:void(0)\" onclick=\"DelNWX()\">取消" + apd + "审批</a>");
                SbHtml2.Append("	<textarea id=\"txtIDx" + y3 + "\" rows=\"5\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtml2.Append("    <input type=\"button\" id=\"btnSignIDx" + y3 + "\" value=\"签署意见\" onclick=\"sign(\'" + y3 + "\')\" style=\"display: none;\" />");
                SbHtml2.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + y3 + "\">_________</span></div>");
                SbHtml2.Append("</td>");
                SbHtml2.Append("</tr>");
                //SbHtml2.Append("<script type=\"text/javascript\">autoTextarea(document.getElementById(\"txtIDx" + y3 + "\"));</script>");
            }
            //SbHtml2.Append("<script type=\"text/javascript\">$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });</script>");

        }
        SbJs.Append("i=" + n + ";"); //
    }

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

    #region 从页面中获得model

    private T_OfficeAutomation_Document_ProjGeneralApply GetModelFromPage(Guid ProjGeneralApplyID)
    {
        T_OfficeAutomation_Document_ProjGeneralApply t_OfficeAutomation_Document_ProjGeneralApply = new T_OfficeAutomation_Document_ProjGeneralApply();
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_ID = ProjGeneralApplyID;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_Apply = EmployeeName;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_Department = txtDepartment.Text;

        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_Subject = txtSubject.Text;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_Fax = txtFax.Text;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_ReceiveDepartment = txtReceiveDepartment.Text;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_CCDepartment = txtCCDepartment.Text;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_Describe = txtDescribe.Text;

        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeID = hdCanSeeEmpCode.Value;
        t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeName = txtCanSeeEmp.Text;

        return t_OfficeAutomation_Document_ProjGeneralApply;
    }

    #region 新增明细表
    /// <summary>
    /// 新增明细表
    /// </summary>
    /// <param name="gGeneralApplyID"></param>
    private void InsertGeneralApplyDetail(Guid gGeneralApplyID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_GeneralApply_Detail t_OfficeAutomation_Document_GeneralApply_Detail;
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_GeneralApply_Detail = new T_OfficeAutomation_Document_GeneralApply_Detail();
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_MainID = gGeneralApplyID;
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Department = detail[0];
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Num = int.Parse(detail[1]);
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Sign = int.Parse(detail[1]);//52100-2016/10/14新增
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Branch = detail[2];
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Cmodel = detail[3] == "1";
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_IsOpen = detail[4] == "1";
            //da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Insert(t_OfficeAutomation_Document_GeneralApply_Detail);
            da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.NewInsert(t_OfficeAutomation_Document_GeneralApply_Detail);//52100-2016/10/14新增

            ///2016/10/14之前的使用方法（52100）
            //DA_OfficeAutomation_Document_GeneralApply_Inherit da_OfficeAutomation_Document_GeneralApply_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Inherit();
            //DataSet ds = new DataSet();
            //ds = da_OfficeAutomation_Document_GeneralApply_Inherit.SelectByMainID(MainID);
            //ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_GeneralApply_ID"].ToString(); //在不同的表要注意修改
            //da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SignNum(ID, int.Parse(detail[1]));
            ///end
        }
    }
    #endregion

    /// <summary>
    /// 获取所有四级以上前线经理
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

    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite44"] = "1";
        Response.Write("<script>window.open('Apply_ProjGeneralApply_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("项目部通用申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
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

        DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_ID"].ToString(); //在不同的表要注意修改

        //T_OfficeAutomation_Flow flowsk;
        //flowsk = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(MainID, "0001");

        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.AddAnotherFlow(ID, int.Parse(ViewState["Sky"].ToString()), 800);
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.UpdateSignNum(ID, 800);
        string[] details = Regex.Split(hdLogisticsFlow.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_GeneralApply_Detail = new T_OfficeAutomation_Document_GeneralApply_Detail();
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_MainID = new Guid(ID);
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Department = detail[0];
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Branch = detail[2];
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Cmodel = detail[3] == "1";
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_IsOpen = detail[4] == "1";

            if (detail[0].ToString().Trim() == "董事总经理")
            {
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Num = int.Parse(detail[1]) + 300 + int.Parse(ViewState["Sky"].ToString());
                da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Insert(t_OfficeAutomation_Document_GeneralApply_Detail);
                da_OfficeAutomation_Flow_Inherit.AddByMainIDAndIdxs(MainID, int.Parse(detail[1]), 300 + int.Parse(ViewState["Sky"].ToString()));
                da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SignNum(ID, int.Parse(detail[1]) + 300 + int.Parse(ViewState["Sky"].ToString()));
            }
            else
            {
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Num = int.Parse(detail[1]);
                da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Insert(t_OfficeAutomation_Document_GeneralApply_Detail);
                da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SignNum(ID, int.Parse(detail[1]));
            }
        }
        //hdLogisticsFlow.Value = "";
        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    }
    protected void btnWillEnd_Click(object sender, EventArgs e) //M_WinnEnd：20150204
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "0001");
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, "总经办");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, "董事总经理");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, "董事总经理审批");
        da_OfficeAutomation_Main_Inherit.UpdateFlowStateForAudit(MainID);
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
        RunJS("alert('已删除总经办的审批环节！');window.location='" + Page.Request.Url + "'");
    }
    //********************************************************************************************************************************************************
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
            DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString();
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

    protected string Repc(string s)
    {
        string s1 = s.Trim()
            .Replace("<br />", "")
            .Replace("<br/>", "")
            .Replace(">", "gt")
            .Replace("<", "lt")
            .Replace(" ", "")
            .Replace("\'", "")
            .Replace("\n", "")
            .Replace("\r", "")
            .Replace("\"", "n")
            .Replace("&gt;", "gt")
            .Replace("&lt;", "lt")
            .Replace("&quot;", "")
            .Replace("&nbsp;", "")
            .Replace("&", "z")
            .Replace("'", "x");
        return s1;
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
                RunJS("window.location.href='" + Page.Request.Url + "';");
                return;
            }
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3") //M_WillAlter
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
            DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

            #region 修改编辑
            if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
            {
                ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID);
                DataRow dr = ds.Tables[0].Rows[0];
                da_OfficeAutomation_Flow_Inherit.DeleteHaventA(MainID);

                if ( //M_WillAlter
                txtApplyID.Text == dr["OfficeAutomation_Document_ProjGeneralApply_ApplyID"].ToString() &&
                txtDepartment.Text == dr["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString() &&
                txtReplyPhone.Text == dr["OfficeAutomation_Document_ProjGeneralApply_ReplyPhone"].ToString() &&
                txtSubject.Text == dr["OfficeAutomation_Document_ProjGeneralApply_Subject"].ToString() &&
                txtFax.Text == dr["OfficeAutomation_Document_ProjGeneralApply_Fax"].ToString() &&
                    Repc(txtDescribe.Text) == Repc(dr["OfficeAutomation_Document_ProjGeneralApply_Describe"].ToString())
                 && txtReceiveDepartment.Text == dr["OfficeAutomation_Document_ProjGeneralApply_ReceiveDepartment"].ToString() &&
                txtCCDepartment.Text == dr["OfficeAutomation_Document_ProjGeneralApply_CCDepartment"].ToString())
                {


                    RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=通用申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
                    Update();
                    RunJS("alert('所有的修改已保存。');window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "';");



                }
                else
                {



                    da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改 M_Suggestion：20150205
                    RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: true,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=通用申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
                    Update();

                    DataSet dsDelete = new DataSet();
                    dsDelete = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlows(MainID);
                    for (int i = 0; i < dsDelete.Tables[0].Rows.Count; i++)
                    {
                        da_OfficeAutomation_Flow_Inherit.UpdateFlowsSuggestion(MainID, dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Idx"].ToString(), dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Suggestion"].ToString());
                    }

                    t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                    t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                    da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                    da_OfficeAutomation_Flow_Inherit.DDeleteFlows(MainID);
                    Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                    //通知已审批的全部人员
                    ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
                    foreach (DataRow dr2 in ds.Tables[0].Rows)
                    {
                        employname = dr2["OfficeAutomation_Flow_Auditor"].ToString();
                        employnames = employname.Split(',');
                        for (int i2 = 0; i2 < employnames.Length; i2++)
                        {
                            msnBody = "您好，" + employnames[i2] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已被" + EmployeeName + "修改了部分内容，待会需要您重审。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            email = employnames[i2];
                            if (email != "")
                                Common.SendMessageEX(false, email, "该份申请已被申请人修改，请重新审批！谢谢", msnBody, msnBody);
                        }
                    }
                    RunJS("alert('所有的修改已保存！');window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&GME=Alt&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "';");



                }
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
            DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString();
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
            //da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("alert('申请表已成功保存。');window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "';");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    public bool JumpOrNot(string dp)
    {
        try
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            if (dp == "行政部" && EmployeeName == "沈凯飞" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "法律部" && EmployeeName == "陈洁丽" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "外联部" && EmployeeName == "潘海燕" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "营运支持" && EmployeeName == "陈晓青A" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if ((dp == "资讯科技部" || dp == "IT部") && EmployeeName == "何智峰" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if ((dp == "人力资源部" || dp == "HR") && EmployeeName == "郑纯宁" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if ((dp == "财务部" || dp == "财务") && EmployeeName == "黄洁珍" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "市场部" && EmployeeName == "李粤湘" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "后勤事务部" && (EmployeeName == "张绍欣" || EmployeeName == "黄瑛") && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
    }
    protected void btnShouldJump_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();

        if (EmployeeID == "23514")
            da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "23514");
        else
        {
            da_OfficeAutomation_Flow_Inherit.DeleteFlowsForJumpProj(MainID, hdShouldJump.Value);
            da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, hdShouldJump.Value);
        }

        string[] employnames;
        string email;
        string msnBody;
        string signEmployeeName = EmployeeName;
        DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
        DataSet ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString();
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
                    + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                Common.SendMessageEX(true, documentName, email, "请进行审理", msnBody, msnBody, MainID);
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
        RunJS("alert('已跳过" + hdShouldJump.Value + "的审批！');window.location='" + Page.Request.Url + "'");
    }
    protected void btnWillEndC_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        if (!da_OfficeAutomation_Flow_Inherit.DeleteFlowsForJumpProj(MainID, "总经办"))
            if (!da_OfficeAutomation_Flow_Inherit.DeleteFlowsForJumpProj(MainID, "董事总经理"))
                da_OfficeAutomation_Flow_Inherit.DeleteFlowsForJumpProj(MainID, "董事总经理审批");
        da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "0001");
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, "总经办");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, "总办");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, "董事总经理");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, "董事总经理审批");
        da_OfficeAutomation_Main_Inherit.UpdateFlowStateForAudit(MainID);
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
        RunJS("alert('已删除总经办的审批环节！');window.location='" + Page.Request.Url + "'");
    }
    protected void lbtnAddN_Click(object sender, EventArgs e) //M_AddNWX：20150511
    {
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DataSet dst = da_OfficeAutomation_Flow_Inherit.SelectByEID(MainID, "13545");
        string st, ddi = "", ddn = "";
        try
        {
            st = dst.Tables[0].Rows[0]["OfficeAutomation_Flow_EmployeeID"].ToString();
        }
        catch
        {
            dst = da_OfficeAutomation_Flow_Inherit.SelectByEID(MainID, "5585");
            st = dst.Tables[0].Rows[0]["OfficeAutomation_Flow_EmployeeID"].ToString();
        }
        if (st.Contains("0025"))
        {
            ddi = "5585,13545,0025";
            ddn = "宁伟雄,黄志超,黄洁珍";
        }
        else
        {
            ddi = "5585,13545";
            ddn = "宁伟雄,黄志超";
        }
        if (EmployeeID == "13545")
            da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", ddn, ddi);
        else
            da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "5585", ddn, ddi);

        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1); //添加日志，添加流程
        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    }
    protected void lbtnDelN_Click(object sender, EventArgs e) //M_AddNWX：20150511
    {
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DataSet dst = da_OfficeAutomation_Flow_Inherit.SelectByEID(MainID, "13545");
        string st, ddi = "", ddn = "";
        try
        {
            st = dst.Tables[0].Rows[0]["OfficeAutomation_Flow_EmployeeID"].ToString();
        }
        catch
        {
            dst = da_OfficeAutomation_Flow_Inherit.SelectByEID(MainID, "5585");
            st = dst.Tables[0].Rows[0]["OfficeAutomation_Flow_EmployeeID"].ToString();
        }
        if (st.Contains("0025"))
        {
            ddi = EmployeeID + ",0025";
            ddn = EmployeeName + ",黄洁珍";
        }
        else
        {
            ddi = EmployeeID;
            ddn = EmployeeName;
        }

        if (EmployeeID == "13545")
        {
            da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", ddn, ddi);
            da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndEName(MainID, "13545");
        }
        else
        {
            da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "5585", ddn, ddi);
            da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndEName(MainID, "5585");
        }
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
        RunJS("alert('审批环节已删除！');window.location='" + Page.Request.Url + "'");
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

        if (rdb22000a1.Checked) //M_AlterM：20150820
            sisa = "1";
        else if (rdb22000a2.Checked)
            sisa = "0";

        if (index != 22000)
        {
            flowsh = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 22000);
            if (flowsh == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 22000;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
            da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, 22000); //M_AlterM：20150826
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        }

        flowsb = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, index);
        string se = null; //M_RA：20151120
        if (index == 22000 && flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID))
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

    protected void btnSignIDx20000_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        string[] employnames;
        string email;
        string msnBody;
        DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
        DataSet ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString();
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

        //Review(20000, txtIDx20000.Value);
        #region 复审
        var flowManager = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);  //管理流程
        //同意1，不同意0，其他意见2
        string sisa = "2";
        if (rdb22000a1.Checked)
            sisa = "1";
        else if (rdb22000a2.Checked)
            sisa = "0";
        var result = new FlowCommonMethod().Review(txtIDx20000.Value, flowManager, MainID, EmployeeName, EmployeeID, sisa, 20000);
        RunJS("alert('" + result.Split('|')[1] + "');window.location='" + Page.Request.Url + "'");
        #endregion
    }
    protected void btnSignIDx22000_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
        DataSet ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ProjGeneralApply_Department"].ToString();
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
            msnBody = "您好" + employnames[i] + "黄生已复审了" + department + "，编号为" + serialNumber + "的" + documentName + "。<br />黄生的意见：" + txtIDx22000.Value + "<br/>申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
            Common.SendMessageEX(false, email, "请注意，总经理发表了复审意见", msnBody, msnBody);
        }

        //Review(22000, txtIDx22000.Value);
        #region 总经理复审
        //同意1，不同意0，其他意见2
        string sisa = "2";
        if (rdb22000a1.Checked)
            sisa = "1";
        else if (rdb22000a2.Checked)
            sisa = "0";
        var result = new FlowCommonMethod().Review_Manager(txtIDx22000.Value, MainID, EmployeeName, EmployeeID, sisa, 22000);
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

    protected void MasterEnd()
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        DataSet ds = new DataSet();

        ds = da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SelectByMIDDesc(MainID);
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() != "3")
        {
            int idx = 0;
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow2 = new T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Suggestion = "";
            idx = int.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString()) + 1;
            da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "0001");
            da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMIDForProj(MainID, "董事总经理");

            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_EmployeeID = "0001";
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Employee = "黄轩明";
            t_OfficeAutomation_Flow2.OfficeAutomation_Flow_Idx = idx;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow2);

            DA_OfficeAutomation_Document_ProjGeneralApply_Inherit da_OfficeAutomation_Document_ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();
            T_OfficeAutomation_Document_GeneralApply_Detail t_OfficeAutomation_Document_GeneralApply_Detail;
            ds = da_OfficeAutomation_Document_ProjGeneralApply_Inherit.SelectByMainID(MainID);
            ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_ID"].ToString();

            for (int i = 0; i <= 2; i++)
            {
                t_OfficeAutomation_Document_GeneralApply_Detail = new T_OfficeAutomation_Document_GeneralApply_Detail();
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_MainID = new Guid(ID);
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Department = "董事总经理";
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Branch = (i + 1).ToString();
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Cmodel = true;
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_IsOpen = i > 0 ? false : true;
                t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Num = idx + i;

                da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Insert(t_OfficeAutomation_Document_GeneralApply_Detail);
                da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SignNum(ID, idx + i);
            }
        }
    }

    //关婉莹设置查阅人(只修改查阅人)
    protected void saveCanSeeEmp_Click(object sender, EventArgs e)
    {
        T_OfficeAutomation_Document_ProjGeneralApply t_OfficeAutomation_Document_ProjGeneralApply = new T_OfficeAutomation_Document_ProjGeneralApply();
        DA_OfficeAutomation_Document_ProjGeneralApply_Inherit ProjGeneralApply_Inherit = new DA_OfficeAutomation_Document_ProjGeneralApply_Inherit();

        DataSet ds = new DataSet();
        ds = ProjGeneralApply_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjGeneralApply_ID"].ToString();

        ProjGeneralApply_Inherit.UpdateCanSeeEmp(ID, hdCanSeeEmpCode.Value, txtCanSeeEmp.Text);

        RunJS("alert('保存查阅人成功！');window.location='/Apply/Apply_Search.aspx';");
    }
}