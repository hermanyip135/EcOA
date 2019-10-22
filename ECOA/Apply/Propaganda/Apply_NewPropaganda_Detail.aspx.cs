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
//using System.Collections;//789

using System.Diagnostics; //M_PDF

public partial class Apply_Propaganda_Apply_NewPropaganda_Detail : BasePage
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

    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();";

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
       // this.btnquegao.Visible = false;
      //  this.btnCityScore.Visible = false;
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
                if (Session["FLG_ReWrite60"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite60"] = null;
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
        txtApply.Text = EmployeeName;
        txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        DrawDetailTable(1);
        DrawDetailTable2(1);
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
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Detail_Inherit da_OfficeAutomation_Document_Propaganda_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Propaganda_Detail_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit da_OfficeAutomation_Document_Propaganda_Statistical_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Score_Inherit dA_OfficeAutomation_Document_Propaganda_Score_Inherit = new DA_OfficeAutomation_Document_Propaganda_Score_Inherit();
        var bll = new DA_OfficeAutomation_Document_Propaganda_Project_Operate();

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
       // this.btnquegao.Visible = false;
        //this.btnCityScore.Visible = false;
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_Propaganda_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_Propaganda_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_Propaganda_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_Propaganda_Department"].ToString();
        txtApply.Text = applicant;
        txtApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_Propaganda_ApplyDate"].ToString()).ToString("yyyy-MM-dd");

        txtConneter.Text = dr["OfficeAutomation_Document_Propaganda_Conneter"].ToString();
        txtBranchAddress.Text = dr["OfficeAutomation_Document_Propaganda_BranchAddress"].ToString();

        string SumPrice = dr["OfficeAutomation_Document_Propaganda_SumPrice"].ToString();
        if (SumPrice.Contains("1"))
            rdbSumPrice1.Checked = true;
        else if (SumPrice.Contains("2"))
            rdbSumPrice2.Checked = true;
        else if (SumPrice.Contains("3"))
            rdbSumPrice3.Checked = true;
        else if (SumPrice.Contains("4"))
            rdbSumPrice4.Checked = true;
        else if (SumPrice.Contains("5"))
            rdbSumPrice5.Checked = true;
        else if (SumPrice.Contains("6"))
            rdbSumPrice6.Checked = true;
        else if (SumPrice.Contains("7"))
            rdbSumPrice7.Checked = true;
        else if (SumPrice.Contains("8"))
            rdbSumPrice8.Checked = true;
        if (rdbSumPrice1.Checked == true)
        {
            string KindOfAdvertising = dr["OfficeAutomation_Document_Propaganda_KindOfAdvertising"].ToString();
            if (KindOfAdvertising.Contains("1"))
                cbKindOfAdvertising1.Checked = true;
            if (KindOfAdvertising.Contains("2"))
                cbKindOfAdvertising2.Checked = true;
            if (KindOfAdvertising.Contains("3"))
                cbKindOfAdvertising3.Checked = true;
            if (KindOfAdvertising.Contains("4"))
                cbKindOfAdvertising4.Checked = true;
            if (KindOfAdvertising.Contains("5"))
                cbKindOfAdvertising5.Checked = true;
            if (KindOfAdvertising.Contains("6"))
            {
                cbKindOfAdvertising6.Checked = true;
                txtAnotherAdvertising.Text = dr["OfficeAutomation_Document_Propaganda_AnotherAdvertising"].ToString();
            }
        }
        if (rdbSumPrice2.Checked == true)
        {
            string KindOfPrinting = dr["OfficeAutomation_Document_Propaganda_KindOfPrinting"].ToString();
            if (KindOfPrinting.Contains("1"))
                cbKindOfPrinting1.Checked = true;
            if (KindOfPrinting.Contains("2"))
                cbKindOfPrinting2.Checked = true;
            if (KindOfPrinting.Contains("3"))
                cbKindOfPrinting3.Checked = true;
            if (KindOfPrinting.Contains("4"))
                cbKindOfPrinting4.Checked = true;
            if (KindOfPrinting.Contains("5"))
                cbKindOfPrinting5.Checked = true;
            if (KindOfPrinting.Contains("6"))
            {
                cbKindOfPrinting6.Checked = true;
                txtAnotherPrinting.Text = dr["OfficeAutomation_Document_Propaganda_AnotherPrinting"].ToString();
            }
        }
        if (rdbSumPrice3.Checked == true)
        {
            string KindOfMaterial = dr["OfficeAutomation_Document_Propaganda_KindOfMaterial"].ToString();
            if (KindOfMaterial.Contains("1"))
                cbKindOfMaterial1.Checked = true;
            if (KindOfMaterial.Contains("2"))
                cbKindOfMaterial2.Checked = true;
            if (KindOfMaterial.Contains("3"))
                cbKindOfMaterial3.Checked = true;
            if (KindOfMaterial.Contains("4"))
            {
                cbKindOfMaterial4.Checked = true;
                txtAnotherMaterial.Text = dr["OfficeAutomation_Document_Propaganda_AnotherMaterial"].ToString();
            }
        }
        if (rdbSumPrice4.Checked == true)
        {
            string KindOfActivity = dr["OfficeAutomation_Document_Propaganda_KindOfActivity"].ToString();
            if (KindOfActivity.Contains("1"))
                cbKindOfActivity1.Checked = true;
            if (KindOfActivity.Contains("2"))
                cbKindOfActivity2.Checked = true;
            if (KindOfActivity.Contains("3"))
                cbKindOfActivity3.Checked = true;
            if (KindOfActivity.Contains("4"))
            {
                cbKindOfActivity4.Checked = true;
                txtAnotherActivity.Text = dr["OfficeAutomation_Document_Propaganda_AnotherActivity"].ToString();
            }
        }
        if (rdbSumPrice5.Checked == true)
        {
            string KindOfMap = dr["OfficeAutomation_Document_Propaganda_KindOfMap"].ToString();
            if (KindOfMap.Contains("1"))
                cbKindOfMap1.Checked = true;
            if (KindOfMap.Contains("2"))
                cbKindOfMap2.Checked = true;
            if (KindOfMap.Contains("3"))
                cbKindOfMap3.Checked = true;
            if (KindOfMap.Contains("4"))
            {
                cbKindOfMap4.Checked = true;
                txtAnotherMap.Text = dr["OfficeAutomation_Document_Propaganda_AnotherMap"].ToString();
            }
        }
        if (rdbSumPrice6.Checked == true)
        {
            string KindOfGift = dr["OfficeAutomation_Document_Propaganda_KindOfGift"].ToString();
            if (KindOfGift.Contains("1"))
            {
                cbKindOfGift1.Checked = true;
                txtAnotherGift.Text = dr["OfficeAutomation_Document_Propaganda_AnotherGift"].ToString();
            }
        }
        if (rdbSumPrice7.Checked == true)
        {
            string KindOfSend = dr["OfficeAutomation_Document_Propaganda_KindOfSend"].ToString();
            if (KindOfSend.Contains("1"))
                cbKindOfSend1.Checked = true;
            if (KindOfSend.Contains("2"))
                cbKindOfSend2.Checked = true;
            if (KindOfSend.Contains("3"))
                cbKindOfSend3.Checked = true;
            if (KindOfSend.Contains("4"))
            {
                cbKindOfSend4.Checked = true;
                txtAnotherSend.Text = dr["OfficeAutomation_Document_Propaganda_AnotherSend"].ToString();
            }
        }
        if (rdbSumPrice8.Checked == true)
        {
            string KindOfAnother = dr["OfficeAutomation_Document_Propaganda_KindOfAnother"].ToString();
            if (KindOfAnother.Contains("1"))
                cbKindOfAnother1.Checked = true;
            if (KindOfAnother.Contains("2"))
                cbKindOfAnother2.Checked = true;
            if (KindOfAnother.Contains("3"))
            {
                cbKindOfAnother3.Checked = true;
                txtAnotherAnother.Text = dr["OfficeAutomation_Document_Propaganda_AnotherAnother"].ToString();
            }
            if (KindOfAnother.Contains("4"))
            {
                cbKindOfAnother4.Checked = true;
            }
            if (KindOfAnother.Contains("5"))
            {
                cbKindOfAnother5.Checked = true;
            }
        }

        //txtSummary.Text = dr["OfficeAutomation_Document_Propaganda_Summary"].ToString();
        //txtWidth.Text = dr["OfficeAutomation_Document_Propaganda_Width"].ToString();
        //txtHeight.Text = dr["OfficeAutomation_Document_Propaganda_Height"].ToString();
        //txtCount.Text = dr["OfficeAutomation_Document_Propaganda_Count"].ToString();
        //txtPackage.Text = dr["OfficeAutomation_Document_Propaganda_Package"].ToString();
        //txtDemandDate.Text = dr["OfficeAutomation_Document_Propaganda_DemandDate"].ToString();
        string PaySituation = dr["OfficeAutomation_Document_Propaganda_PaySituation"].ToString();
        if (PaySituation.Contains("1"))
            rdbPaySituation1.Checked = true;
        else if (PaySituation.Contains("2"))
        {
            txtPayProjectName.Text = dr["OfficeAutomation_Document_Propaganda_PayProjectName"].ToString();
            rdbPaySituation2.Checked = true;
        }
        else if (PaySituation.Contains("3"))
        {
            rdbPaySituation3.Checked = true;
            txtFearNo.Text = dr["OfficeAutomation_Document_Propaganda_FearNo"].ToString();
        }
        else if (PaySituation.Contains("4"))
        {
            rdbAnother.Checked = true;
            txtOtherDescript.Text = dr["OfficeAutomation_Document_Propaganda_PayAnother"].ToString();
        }

        txtAcceptDate.Text = dr["OfficeAutomation_Document_Propaganda_AcceptDate"].ToString();
        ddlAccepter.Text = dr["OfficeAutomation_Document_Propaganda_Accepter"].ToString();
     //   this.hfEmployeeName.Value = dr["OfficeAutomation_Document_Propaganda_Accepter"].ToString();
        ddlDesigner.Text = dr["OfficeAutomation_Document_Propaganda_Designer"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_Propaganda_Reason"].ToString();
        txtVerifyer.Text = dr["OfficeAutomation_Document_Propaganda_Verifyer"].ToString();
        txtTNo.Text = dr["OfficeAutomation_Document_Propaganda_TNo"].ToString();
        txtVerifyDate.Text = dr["OfficeAutomation_Document_Propaganda_VerifyDate"].ToString();

        string grade = dr["OfficeAutomation_Document_Propaganda_Grade"].ToString();
        if (grade == "1")
            rdbGrade1.Checked = true;
        else if (grade=="2")
        {
            rdbGrade2.Checked = true;
        }
        else if (grade == "3")
        {
            rdbGrade3.Checked = true;
        }
        else if (grade == "4")
        {
            rdbGrade4.Checked = true;
        }

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        ds = da_OfficeAutomation_Document_Propaganda_Detail_Inherit.SelectByID(ID);
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

                SbJs.Append("$('#txtDetail_No" + i + "').val('" + dr["OfficeAutomation_Document_Propaganda_Detail_No"] + "');");
                SbJs.Append("$('#txtDetail_Department" + i + "').val('" + dr["OfficeAutomation_Document_Propaganda_Detail_Department"] + "');");
                SbJs.Append("$('#txtDetail_Count" + i + "').val('" + dr["OfficeAutomation_Document_Propaganda_Detail_Count"] + "');");
            }
        }

        ds = da_OfficeAutomation_Document_Propaganda_Statistical_Inherit.SelectByID(ID);
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

                SbJs.Append("$('#txtStatistical_SNo" + i + "').val('" + dr["OfficeAutomation_Document_Propaganda_Statistical_SNo"] + "');");
                SbJs.Append("$('#txtStatistical_SDepartment" + i + "').val('" + dr["OfficeAutomation_Document_Propaganda_Statistical_SDepartment"] + "');");
                SbJs.Append("$('#txtStatistical_Address" + i + "').val('" + dr["OfficeAutomation_Document_Propaganda_Statistical_Address"] + "');");
                SbJs.Append("$('#txtStatistical_SCount" + i + "').val('" + dr["OfficeAutomation_Document_Propaganda_Statistical_SCount"] + "');");
            }
        }

        ds = bll.SelectByID(ID);
        int detailCount3 = ds.Tables[0].Rows.Count;
        if (detailCount3 != 0) 
        {
            DrawDetailTable3(detailCount3, ID);

            for (int n = 0; n < detailCount3; n++)
            {
                
                dr = ds.Tables[0].Rows[n];
                int projectid = Convert.ToInt32(ds.Tables[0].Rows[n]["OfficeAutomation_Document_Propaganda_Project_ProjectID"].ToString());
                string summary = dr["OfficeAutomation_Document_Propaganda_Project_Summary"].ToString().Replace("\n", "\\n").Replace("\r", "\\r");

                SbJs.Append("$('#txtSummary" + projectid + "').val('" + summary + "');");
                SbJs.Append("$('#txtWidth" + projectid + "').val('" + dr["OfficeAutomation_Document_Propaganda_Project_Width"] + "');");
                SbJs.Append("$('#txtHeight" + projectid + "').val('" + dr["OfficeAutomation_Document_Propaganda_Project_Height"] + "');");
                SbJs.Append("$('#rdbAcross" + projectid + "').attr('checked'," +( dr["OfficeAutomation_Document_Propaganda_Project_ModelType"].ToString() == "1" ? "true" : "false" )+ ");");
                SbJs.Append("$('#rdbUpright" + projectid + "').attr('checked'," + (dr["OfficeAutomation_Document_Propaganda_Project_ModelType"].ToString() == "2" ? "true" : "false") + ");");
                SbJs.Append("$('#txtCount" + projectid + "').val('" + dr["OfficeAutomation_Document_Propaganda_Project_Count"] + "');");
                SbJs.Append("$('#txtPackage" + projectid + "').val('" + dr["OfficeAutomation_Document_Propaganda_Project_Package"] + "');");
                SbJs.Append("$('#txtDemandDate" + projectid + "').val('" + Convert.ToDateTime(dr["OfficeAutomation_Document_Propaganda_Project_DemandDate"].ToString()).ToString("yyyy-MM-dd") + "');");

            }
        }

        //加载评分
        T_OfficeAutomation_Document_Propaganda_Score t = dA_OfficeAutomation_Document_Propaganda_Score_Inherit.GetModel(ID);
        if (t != null)
        {
            this.hfDesign1.Value = t.OfficeAutomation_Document_Propaganda_Score_DesignScore1.ToString();
          //  if (!string.IsNullOrEmpty(t.OfficeAutomation_Document_Propaganda_Score_DesignScore1Remarks))
              //  this.txtDesignermarkes1.Value = t.OfficeAutomation_Document_Propaganda_Score_DesignScore1Remarks.ToString();
           // this.hfDesign2.Value = t.OfficeAutomation_Document_Propaganda_Score_DesignScore2.ToString();
            //if (!string.IsNullOrEmpty(t.OfficeAutomation_Document_Propaganda_Score_DesignScore2Remarks))
            //this.txtDesignermarkes2.Value = t.OfficeAutomation_Document_Propaganda_Score_DesignScore2Remarks.ToString();
            //this.hfDesign3.Value = t.OfficeAutomation_Document_Propaganda_Score_DesignScore3.ToString();
            //if (!string.IsNullOrEmpty(t.OfficeAutomation_Document_Propaganda_Score_DesignScore3Remarks))
            //this.txtDesignermarkes3.Value = t.OfficeAutomation_Document_Propaganda_Score_DesignScore3Remarks.ToString();
            this.hfCityService1.Value = t.OfficeAutomation_Document_Propaganda_Score_AccepterScore1.ToString() == "0" ? "" : t.OfficeAutomation_Document_Propaganda_Score_AccepterScore1.ToString();
            this.hfCityService2.Value = t.OfficeAutomation_Document_Propaganda_Score_AccepterScore2.ToString() == "0" ? "" : t.OfficeAutomation_Document_Propaganda_Score_AccepterScore2.ToString();
            this.hfCityService3.Value = t.OfficeAutomation_Document_Propaganda_Score_AccepterScore3.ToString() == "0" ? "" : t.OfficeAutomation_Document_Propaganda_Score_AccepterScore3.ToString();
        }
        else
        {
            this.hfDesign1.Value = "";
       
            this.hfCityService1.Value = "";
            this.hfCityService2.Value = "";
            this.hfCityService3.Value = "";
          //  this.txtDesignermarkes1.Value = "";
         
        }
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
        SbJs.Append("$(\"#btnUpload\").show();");
        //}
        if (isApplicant)
        {
            if (flowState == "1")
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
           // if (flowState == "3")
           // {
                //登录人是否是申请人
               // if (applicant == EmployeeName)
               // {
                   // this.btnquegao.Visible = true;

                   // this.btnCityScore.Visible = true;
                
              //  }
               
           // }
        }
        if (EmployeeID == "19173" || EmployeeID == "52699" || EmployeeID == "39591" || EmployeeID =="15486" || EmployeeID =="2255" || EmployeeID =="33509")
        {
            btnSave.Visible = true;
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
                SbJs.Append("</script>");
                GetAllDepartment();
                //txtDepartment.Text = "";
                btnSPDF.Visible = false; //M_PDF
                txtApply.Text = EmployeeName;
                txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            //if (isApplicant)
            //    btnReWrite.Visible = true; //*-+
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

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
        //bool showf = true; //M_HideFlows：20150330
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();
            string curemp2 = drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString();
            if (idx == 22)//市场部经理
            { SbJs.Append("$(\"#trManager22\").show();"); }
            //if ((curidx == "1" || curidx == "2" || EmployeeName == "黄轩明") && curemp2.Contains(EmployeeID) && showf) //M_HideFlows：20150330
            //{
            //    showf = false;
            //    SbJs.Append("$(\"#trShowFlow3\").hide();$(\"#trShowFlow4\").prepend('<td>外联部意见</td>');");
            //    SbJs.Append("$(\"#trShowFlow5\").hide();$(\"#trShowFlow6\").prepend('<td>法律部意见</td>');");
            //    SbJs.Append("$(\"#trShowFlow7\").hide();$(\"#trShowFlow8\").prepend('<td>财务部意见</td>');");
            //    SbJs.Append("$(\"#trLogistics1\").hide();$(\"#trLogistics2\").prepend('<td>后勤事务部意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            //    SbJs.Append("$(\"#tlsc1\").prepend('<td>后勤事务部<br />意见<br /><asp:Button ID=\"btnWillEnd\" runat=\"server\" Text=\"结束\" OnClick=\"btnWillEnd_Click\" Visible=\"False\" /></td>');");
            //}

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
                    //    //case "10":
                    //    //    ckbAddIDx10.Visible = true;
                    //    //    break;
                    //    //case "7":
                    //    //    if (EmployeeID == "13545") //M_AddNWX：20150511
                    //    //        lbtnAddN.Visible = true;
                    //    //    break;
                    //    //default:
                    //    //    break;
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

            SbHtml.Append("<td><span id=\"txtDetail_No" + i + "\">" + i + "</span></td>");
            SbHtml.Append("<td><input type=\"text\" id=\"txtDetail_Department" + i + "\" style=\"width:200px\"/></td>");
            SbHtml.Append("<td><input type=\"text\" id=\"txtDetail_Count" + i + "\" style=\"width:200px\"/></td>");

            SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable2(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml2.Append("<tr id=\"trDetail2" + i + "\">");

            SbHtml2.Append("<td><span id=\"txtStatistical_SNo" + i + "\">" + i + "</span></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtStatistical_SDepartment" + i + "\" style=\"width:150px\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtStatistical_Address" + i + "\" style=\"width:150px\"/></td>");
            SbHtml2.Append("<td><input type=\"text\" id=\"txtStatistical_SCount" + i + "\" style=\"width:150px\"/></td>");

            SbHtml2.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawDetailTable3(int n,string id)
    {
        var bll = new DA_OfficeAutomation_Document_Propaganda_Project_Operate();
        DataSet ds = bll.SelectByID(id);
        int detailCount3 = ds.Tables[0].Rows.Count;
        string projectname="";

        for (int i = 0; i < detailCount3; i++)
        {
            int typeid = Convert.ToInt32(ds.Tables[0].Rows[i]["OfficeAutomation_Document_Propaganda_Project_ProjectType"].ToString());
            int projectid = Convert.ToInt32(ds.Tables[0].Rows[i]["OfficeAutomation_Document_Propaganda_Project_ProjectID"].ToString());
            if (typeid == 1)
            {
                projectname = projectid == 1 ? "报纸广告栏" : projectid == 2 ? "分类广告" : projectid == 3 ? "杂志广告" : projectid == 4 ? "户外广告" : projectid == 5 ? "网络广告" : projectid == 6 ? "其它" : "";
            }
            else if (typeid == 2)
            {
                projectname = projectid == 1 ? "卡仔" : projectid == 2 ? "单张" : projectid == 3 ? "楼盘纸" : projectid == 4 ? "小册子" : projectid == 5 ? "书刊" : projectid == 6 ? "其它" : "";
            }

            else if (typeid == 3)
            {
                projectname = projectid == 1 ? "海报" : projectid == 2 ? "横幅" : projectid == 3 ? "展示用品（太阳伞/帐篷/折叠式桌椅）" : projectid == 4 ? "其它" : "";
            }
            else if (typeid == 4)
            {
                projectname = projectid == 1 ? "联展活动" : projectid == 2 ? "专题讲座" : projectid == 3 ? "公司活动（季会/主管会）" : projectid == 4 ? "其它" : "";
            }
            else if (typeid == 5)
            {
                projectname = projectid == 1 ? "A图" : projectid == 2 ? "B图" : projectid == 3 ? "C图" : projectid == 4 ? "其它" : "";
            }
            else if (typeid == 6)
            {
                projectname = projectid == 1 ? "其它" : "";
            }
            else if (typeid == 7)
            {
                projectname = projectid == 1 ? "正常派送" : projectid == 2 ? "加急派送" : projectid == 3 ? "分装配送" : projectid == 4 ? "其它" : "";
            }
            else if (typeid == 8)
            {
                projectname = projectid == 1 ? "邮局直投" : projectid == 2 ? "打印" : projectid == 3 ? "其它" : projectid == 4 ? "卡秀" : projectid == 5 ? "协助拍照" : "";
            }

            SbHtml3.Append("<tr id=\"trDetail3" + projectid + "\">");
            SbHtml3.Append("<td colspan=\"4\" class=\"tl PL10\" style=\"line-height: 25px\">");
            SbHtml3.Append("<span style=\"font-weight: bold\">◤" + projectname + "项目概念详述：</span><br />");
            SbHtml3.Append("<input type=\"hidden\" id=\"hdprojtype" + projectid + "\" value=" + typeid + " />");
            SbHtml3.Append("（请写明使用目的，设计要求[如颜色、排版等]，制作要求、数量等）如属费用支付事项，则需注明支付金额）：<br />");
            SbHtml3.Append("<textarea id=\"txtSummary" + projectid + "\" style=\"width:98%;height:60px; overflow: hidden;\"/></textarea><br />");
            SbHtml3.Append("★规格大小：<input type=\"text\" id=\"txtWidth" + projectid + "\" Width=\"100px\"/>(宽)X  ");
            SbHtml3.Append("<input type=\"text\" id=\"txtHeight" + projectid + "\" Width=\"100px\"/>(高) ");
            SbHtml3.Append("<input type=radio id=\"rdbAcross" + projectid + "\" name=\"modelType" + projectid + "\"/>横版 <input type=radio id=\"rdbUpright" + projectid + "\" name=\"modelType" + projectid + "\"/>竖版<br/>");
            SbHtml3.Append("★数量/页数：<input type=\"text\" id=\"txtCount" + projectid + "\" Width=\"100px\"/><br />");
            SbHtml3.Append("包/安装要求：<input type=\"text\" id=\"txtPackage" + projectid + "\" Width=\"250px\"/>　");
            SbHtml3.Append("★成品需求日期：<input type=\"text\" id=\"txtDemandDate" + projectid + "\" Width=\"105px\"/>");
            SbHtml3.Append("</td>");
            SbHtml3.Append("</tr>");
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
        T_OfficeAutomation_Document_Propaganda t_OfficeAutomation_Document_Propaganda = new T_OfficeAutomation_Document_Propaganda();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Score_Inherit dA_OfficeAutomation_Document_Propaganda_Score_Inherit = new DA_OfficeAutomation_Document_Propaganda_Score_Inherit();
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
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "Propaganda" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 55; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                Guid PropagandaID = Guid.NewGuid();
                t_OfficeAutomation_Document_Propaganda = GetModelFromPage(PropagandaID);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = "";
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_Propaganda_Inherit.Insert(t_OfficeAutomation_Document_Propaganda);//插入申请表

                InsertPropagandaDetail(t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_ID);
                InsertPropagandaDetail2(t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_ID);
                InsertPropagandaDetail3(t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_ID);
                T_OfficeAutomation_Document_Propaganda_Score t = new T_OfficeAutomation_Document_Propaganda_Score();

                t.OfficeAutomation_Document_Propaganda_Score_ID = Guid.NewGuid();
                t.OfficeAutomation_Document_Propaganda_Score_MainID = PropagandaID;
                dA_OfficeAutomation_Document_Propaganda_Score_Inherit.Add(t);

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

                Common.AddLog(EmployeeID, EmployeeName, 59, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_Propaganda_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
            Common.AddLog(EmployeeID, EmployeeName, 59, new Guid(MainID), 8);
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
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Detail_Inherit da_OfficeAutomation_Document_Propaganda_Detail_Inherit = new DA_OfficeAutomation_Document_Propaganda_Detail_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit da_OfficeAutomation_Document_Propaganda_Statistical_Inherit = new DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit();

        DataSet ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_Propaganda_ID"].ToString();

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

                //如果为第0步流程则为其一审核即可通过，其他为同时审核。
                //string[] flowN;
                //flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "25" || flowIDx=="21") ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                //bool isSignSuccess = flowIDx == "5" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_Propaganda_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl; ;
                    ////+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_Propaganda_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_Propaganda_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_Propaganda_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>内M：" + drRow["OfficeAutomation_Document_Propaganda_ApplyID"].ToString());
                    sbMailBody.Append("<br/>联系人：" + drRow["OfficeAutomation_Document_Propaganda_Conneter"]);
                    sbMailBody.Append("<br/>分行地址：" + drRow["OfficeAutomation_Document_Propaganda_BranchAddress"]);
                    sbMailBody.Append("<br/><br/>");

                    sbMailBody.Append("<br/>广告宣传需求申请摊分情况：");
                    ds = da_OfficeAutomation_Document_Propaganda_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>分摊部门/分行/组别：" + dr["OfficeAutomation_Document_Propaganda_Detail_Department"]);
                        sbMailBody.Append("<br/>分摊数量：" + dr["OfficeAutomation_Document_Propaganda_Detail_Count"]);
                        sbMailBody.Append("<br/>");
                    }
                    sbMailBody.Append("<br/>");

                    sbMailBody.Append("<br/>广告宣传需求申请送货清单表：");
                    ds = da_OfficeAutomation_Document_Propaganda_Statistical_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>送货部门/分行/组：" + dr["OfficeAutomation_Document_Propaganda_Statistical_SDepartment"]);
                        sbMailBody.Append("<br/>送货地址：" + dr["OfficeAutomation_Document_Propaganda_Statistical_Address"]);
                        sbMailBody.Append("<br/>送货数量：" + dr["OfficeAutomation_Document_Propaganda_Statistical_SCount"]);
                        sbMailBody.Append("<br/>");
                    }

                    mailBody = sbMailBody.ToString();

                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意

                        if (flowIDx == "25" || flowIDx == "21")
                        {
                            UpdateForSign();
                        }


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

                            //完成后抄送
                            employname = "王萍,周燕妮,王珏萍," + ddlDesigner.Text;
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

                            string sumprice=drRow["OfficeAutomation_Document_Propaganda_SumPrice"].ToString();
                            int propagandatype=Convert.ToInt32(sumprice.Substring(sumprice.Length-1,1));
                            int typecount = da_OfficeAutomation_Document_Propaganda_Inherit.GetPropagandaTypeCountToday(propagandatype);
                            string typename = propagandatype == 1 ? "SJ" : propagandatype == 2 ? "YS" : propagandatype == 3 ? "WL" : propagandatype == 4 ? "HD" : propagandatype == 5 ? "DT" : propagandatype == 6 ? "LP" : propagandatype == 7 ? "PS" : propagandatype == 8 ? "OT" : "";

                      //      string tno = typename + DateTime.Now.ToString("yyyyMMdd") + "00" + typecount;
                            string grade = rdbGrade1.Checked == true ? "1" : rdbGrade2.Checked == true ? "2" : rdbGrade3.Checked == true ? "3" : rdbGrade4.Checked == true ? "4" : "";
                            string designer = ddlDesigner.Text;

                            da_OfficeAutomation_Document_Propaganda_Inherit.updateTNoAndGradeByID(grade,designer,ID);
                            
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
        //    DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_Propaganda_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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

    private T_OfficeAutomation_Document_Propaganda GetModelFromPage(Guid PropagandaID)
    {
        T_OfficeAutomation_Document_Propaganda t_OfficeAutomation_Document_Propaganda = new T_OfficeAutomation_Document_Propaganda();
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_ID = PropagandaID;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Apply = EmployeeName;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_ApplyID = txtApplyID.Text;

        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_ApplyDate = DateTime.Now;

        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Conneter = txtConneter.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_BranchAddress = txtBranchAddress.Text;

        string SumPrice = null;
        if (rdbSumPrice1.Checked == true)
            SumPrice += "|1";
        if (rdbSumPrice2.Checked == true)
            SumPrice += "|2";
        if (rdbSumPrice3.Checked == true)
            SumPrice += "|3";
        if (rdbSumPrice4.Checked == true)
            SumPrice += "|4";
        if (rdbSumPrice5.Checked == true)
            SumPrice += "|5";
        if (rdbSumPrice6.Checked == true)
            SumPrice += "|6";
        if (rdbSumPrice7.Checked == true)
            SumPrice += "|7";
        if (rdbSumPrice8.Checked == true)
            SumPrice += "|8";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_SumPrice = SumPrice;
        string KindOfAdvertising = "";
        if (cbKindOfAdvertising1.Checked == true)
            KindOfAdvertising += "|1";
        if (cbKindOfAdvertising2.Checked == true)
            KindOfAdvertising += "|2";
        if (cbKindOfAdvertising3.Checked == true)
            KindOfAdvertising += "|3";
        if (cbKindOfAdvertising4.Checked == true)
            KindOfAdvertising += "|4";
        if (cbKindOfAdvertising5.Checked == true)
            KindOfAdvertising += "|5";
        if (cbKindOfAdvertising6.Checked == true)
            KindOfAdvertising += "|6";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_KindOfAdvertising = KindOfAdvertising;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AnotherAdvertising = txtAnotherAdvertising.Text;
        string KindOfPrinting = "";
        if (cbKindOfPrinting1.Checked == true)
            KindOfPrinting += "|1";
        if (cbKindOfPrinting2.Checked == true)
            KindOfPrinting += "|2";
        if (cbKindOfPrinting3.Checked == true)
            KindOfPrinting += "|3";
        if (cbKindOfPrinting4.Checked == true)
            KindOfPrinting += "|4";
        if (cbKindOfPrinting5.Checked == true)
            KindOfPrinting += "|5";
        if (cbKindOfPrinting6.Checked == true)
            KindOfPrinting += "|6";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_KindOfPrinting = KindOfPrinting;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AnotherPrinting = txtAnotherPrinting.Text;
        string KindOfMaterial = "";
        if (cbKindOfMaterial1.Checked == true)
            KindOfMaterial += "|1";
        if (cbKindOfMaterial2.Checked == true)
            KindOfMaterial += "|2";
        if (cbKindOfMaterial3.Checked == true)
            KindOfMaterial += "|3";
        if (cbKindOfMaterial4.Checked == true)
            KindOfMaterial += "|4";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_KindOfMaterial = KindOfMaterial;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AnotherMaterial = txtAnotherMaterial.Text;
        string KindOfActivity = "";
        if (cbKindOfActivity1.Checked == true)
            KindOfActivity += "|1";
        if (cbKindOfActivity2.Checked == true)
            KindOfActivity += "|2";
        if (cbKindOfActivity3.Checked == true)
            KindOfActivity += "|3";
        if (cbKindOfActivity4.Checked == true)
            KindOfActivity += "|4";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_KindOfActivity = KindOfActivity;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AnotherActivity = txtAnotherActivity.Text;
        string KindOfMap = "";
        if (cbKindOfMap1.Checked == true)
            KindOfMap += "|1";
        if (cbKindOfMap2.Checked == true)
            KindOfMap += "|2";
        if (cbKindOfMap3.Checked == true)
            KindOfMap += "|3";
        if (cbKindOfMap4.Checked == true)
            KindOfMap += "|4";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_KindOfMap = KindOfMap;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AnotherMap = txtAnotherMap.Text;
        string KindOfGift = "";
        if (cbKindOfGift1.Checked == true)
            KindOfGift += "|1";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_KindOfGift = KindOfGift;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AnotherGift = txtAnotherGift.Text;
        string KindOfSend = "";
        if (cbKindOfSend1.Checked == true)
            KindOfSend += "|1";
        if (cbKindOfSend2.Checked == true)
            KindOfSend += "|2";
        if (cbKindOfSend3.Checked == true)
            KindOfSend += "|3";
        if (cbKindOfSend4.Checked == true)
            KindOfSend += "|4";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_KindOfSend = KindOfSend;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AnotherSend = txtAnotherSend.Text;
        string KindOfAnother = "";
        if (cbKindOfAnother1.Checked == true)
            KindOfAnother += "|1";
        if (cbKindOfAnother2.Checked == true)
            KindOfAnother += "|2";
        if (cbKindOfAnother3.Checked == true)
            KindOfAnother += "|3";
        if (cbKindOfAnother4.Checked == true)
            KindOfAnother += "|4";
        if (cbKindOfAnother5.Checked == true)
            KindOfAnother += "|5";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_KindOfAnother = KindOfAnother;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AnotherAnother = txtAnotherAnother.Text;

        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Summary = "";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Width = "";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Height = "";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Count = "";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Package = "";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_DemandDate = "";

        string PaySituation = "";
        if (rdbPaySituation1.Checked == true)
            PaySituation += "|1";
        if (rdbPaySituation2.Checked == true)
            PaySituation += "|2";
        if (rdbPaySituation3.Checked == true)
            PaySituation += "|3";
        if (rdbAnother.Checked == true)
            PaySituation += "|4";
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_PaySituation = PaySituation;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_PayProjectName = txtPayProjectName.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_FearNo = txtFearNo.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_PayAnother = txtOtherDescript.Text;
        //t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_TNo = txtTNo.Text;

        if (EmployeeID == "19173" || EmployeeID == "52699" || EmployeeID == "39591" || EmployeeID == "15486" || EmployeeID == "42900" || EmployeeID == "2255" || EmployeeID == "33509" || EmployeeID == "50203")
        {
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AcceptDate = txtAcceptDate.Text;
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Accepter = ddlAccepter.Text;
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Designer = ddlDesigner.Text;
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Reason = txtReason.Text;
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Verifyer = txtVerifyer.Text;
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_VerifyDate = txtVerifyDate.Text;
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Grade = rdbGrade1.Checked == true ? "1" : rdbGrade2.Checked == true ? "2" : rdbGrade3.Checked == true ? "3" : rdbGrade4.Checked == true ? "4" : "";
        }
        else
        {
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AcceptDate = "";
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Accepter = "";
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Designer = "";
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Reason = "";
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Verifyer = "";
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_VerifyDate = "";
            t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Grade = "";
        }

        return t_OfficeAutomation_Document_Propaganda;
    }

    #endregion

    #region 从页面中获得model，签名时修改

    private T_OfficeAutomation_Document_Propaganda GetModelFromPageForSign(Guid PropagandaID)
    {
        T_OfficeAutomation_Document_Propaganda t_OfficeAutomation_Document_Propaganda = new T_OfficeAutomation_Document_Propaganda();
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_ID = PropagandaID;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_MainID = new Guid(MainID);

      
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_AcceptDate = txtAcceptDate.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Accepter = ddlAccepter.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Designer = ddlDesigner.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Reason = txtReason.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Verifyer = txtVerifyer.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_VerifyDate = txtVerifyDate.Text;
        t_OfficeAutomation_Document_Propaganda.OfficeAutomation_Document_Propaganda_Grade = rdbGrade1.Checked == true ? "1" : rdbGrade2.Checked == true ? "2" : rdbGrade3.Checked == true ? "3" : rdbGrade4.Checked == true ? "4" : "";
      

        return t_OfficeAutomation_Document_Propaganda;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_Propaganda t_OfficeAutomation_Document_Propaganda = new T_OfficeAutomation_Document_Propaganda();
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_ID"].ToString();

        t_OfficeAutomation_Document_Propaganda = GetModelFromPage(new Guid(ID));
        string apply = "";
        string depname = txtDepartment.Text;
        string summary = "";
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_Propaganda_Inherit.Update(t_OfficeAutomation_Document_Propaganda);//修改申请表

        DA_OfficeAutomation_Document_Propaganda_Detail_Inherit da_OfficeAutomation_Document_Propaganda_Detail_Inherit = new DA_OfficeAutomation_Document_Propaganda_Detail_Inherit();
        da_OfficeAutomation_Document_Propaganda_Detail_Inherit.Delete(ID);
        InsertPropagandaDetail(new Guid(ID));

        DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit da_OfficeAutomation_Document_Propaganda_Statistical_Inherit = new DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit();
        da_OfficeAutomation_Document_Propaganda_Statistical_Inherit.Delete(ID);
        InsertPropagandaDetail2(new Guid(ID));

        var bll = new DA_OfficeAutomation_Document_Propaganda_Project_Operate();
        bll.DelByMainID(ID);
        InsertPropagandaDetail3(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 59, new Guid(MainID), 2);//日志，修改申请表
    }

    private void UpdateForSign()
    {
        T_OfficeAutomation_Document_Propaganda t_OfficeAutomation_Document_Propaganda = new T_OfficeAutomation_Document_Propaganda();
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_ID"].ToString();

        t_OfficeAutomation_Document_Propaganda = GetModelFromPageForSign(new Guid(ID));

        da_OfficeAutomation_Document_Propaganda_Inherit.UpdateForSign(t_OfficeAutomation_Document_Propaganda);//修改申请表

        Common.AddLog(EmployeeID, EmployeeName, 59, new Guid(MainID), 2);//日志，修改申请表
    }
    #endregion

    #region 其他

    #region 新增明细

    /// <summary>
    /// 新增广告宣传需求申请摊分情况表
    /// </summary>
    /// <param name="gPropagandaID"></param>
    private void InsertPropagandaDetail(Guid gPropagandaID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_Propaganda_Detail t_OfficeAutomation_Document_Propaganda_Detail;
        DA_OfficeAutomation_Document_Propaganda_Detail_Inherit da_OfficeAutomation_Document_Propaganda_Detail_Inherit = new DA_OfficeAutomation_Document_Propaganda_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                //if (detail[0] == "")
                //    continue;
                t_OfficeAutomation_Document_Propaganda_Detail = new T_OfficeAutomation_Document_Propaganda_Detail();
                t_OfficeAutomation_Document_Propaganda_Detail.OfficeAutomation_Document_Propaganda_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Propaganda_Detail.OfficeAutomation_Document_Propaganda_Detail_MainID = gPropagandaID;

                t_OfficeAutomation_Document_Propaganda_Detail.OfficeAutomation_Document_Propaganda_Detail_No = detail[0];
                t_OfficeAutomation_Document_Propaganda_Detail.OfficeAutomation_Document_Propaganda_Detail_Department = detail[1];
                t_OfficeAutomation_Document_Propaganda_Detail.OfficeAutomation_Document_Propaganda_Detail_Count = detail[2];

                da_OfficeAutomation_Document_Propaganda_Detail_Inherit.Insert(t_OfficeAutomation_Document_Propaganda_Detail);
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
    /// <param name="gPropagandaID"></param>
    private void InsertPropagandaDetail2(Guid gPropagandaID)
    {
        if (hdDetail2.Value == "")
            return;

        T_OfficeAutomation_Document_Propaganda_Statistical t_OfficeAutomation_Document_Propaganda_Statistical;
        DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit da_OfficeAutomation_Document_Propaganda_Statistical_Inherit = new DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit();

        string[] details = Regex.Split(hdDetail2.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                //if (detail[0] == "")
                //    continue;
                t_OfficeAutomation_Document_Propaganda_Statistical = new T_OfficeAutomation_Document_Propaganda_Statistical();
                t_OfficeAutomation_Document_Propaganda_Statistical.OfficeAutomation_Document_Propaganda_Statistical_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Propaganda_Statistical.OfficeAutomation_Document_Propaganda_Statistical_MainID = gPropagandaID;

                t_OfficeAutomation_Document_Propaganda_Statistical.OfficeAutomation_Document_Propaganda_Statistical_SNo = detail[0];
                t_OfficeAutomation_Document_Propaganda_Statistical.OfficeAutomation_Document_Propaganda_Statistical_SDepartment = detail[1];
                t_OfficeAutomation_Document_Propaganda_Statistical.OfficeAutomation_Document_Propaganda_Statistical_Address = detail[2];
                t_OfficeAutomation_Document_Propaganda_Statistical.OfficeAutomation_Document_Propaganda_Statistical_SCount = detail[3];

                da_OfficeAutomation_Document_Propaganda_Statistical_Inherit.Insert(t_OfficeAutomation_Document_Propaganda_Statistical);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    /// <summary>
    /// 新增广告宣传需求申请项目描述
    /// </summary>
    /// <param name="gPropagandaID"></param>
    private void InsertPropagandaDetail3(Guid gPropagandaID)
    {
        if (hdDetail3.Value == "")
            return;

        T_OfficeAutomation_Document_Propaganda_Project t_OfficeAutomation_Document_Propaganda_Project;
        var bll = new DA_OfficeAutomation_Document_Propaganda_Project_Operate();

        string[] details = Regex.Split(hdDetail3.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");

                t_OfficeAutomation_Document_Propaganda_Project = new T_OfficeAutomation_Document_Propaganda_Project();
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_MainID = gPropagandaID;
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_ProjectType = detail[0];
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_ProjectID = detail[1];
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_Summary = detail[2];
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_Width = detail[3];
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_Height = detail[4];
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_ModelType = detail[5];
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_Count = detail[6];
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_Package = detail[7];
                t_OfficeAutomation_Document_Propaganda_Project.OfficeAutomation_Document_Propaganda_Project_DemandDate =Convert.ToDateTime(detail[8]);

                bll.Add(t_OfficeAutomation_Document_Propaganda_Project);
            }
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return;
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

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite60"] = "1";
        Response.Write("<script>window.open('Apply_NewPropaganda_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("广告宣传需求申请表.pdf"));//强制下载 
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

    //    DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
    //    DataSet ds = new DataSet();
    //    ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID);
    //    ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_ID"].ToString(); //在不同的表要注意修改

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
            //if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
            //{
            //    RunJS("alert('该表已审批完毕，不能再撤回审核了');window.location.href='" + Page.Request.Url + "';");
            //    return;
            //}
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
            DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Propaganda_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl; ;
            ////+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
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
            DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Propaganda_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl; ;
            ////+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
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
            DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Propaganda_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_Propaganda_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    /// <summary>
    /// 跳过设计组
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShouldJumpIDx_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();


        string idx = "21";
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, idx);//删除流程
        string[] employnames;
        string email;
        string msnBody;
        string signEmployeeName = EmployeeName;
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Propaganda_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;



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
        //if (employname.Contains(CommonConst.EMP_GENERALMANAGER_NAME))
        //{
        //    employname = CommonConst.EMP_GMO_NAME;
        //    employnames = employname.Split(',');
        //    for (int i = 0; i < employnames.Length; i++)
        //    {
        //        email = employnames[i];
        //        msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        //        Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody, msnBody);
        //    }
        //}
      //  Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，跳过流程
        
        RunJS("alert('已跳过设计组的审批！');window.location='" + Page.Request.Url + "'");
    }

    /// <summary>
    /// 增加设计组
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturnJumpIDx_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
       
        string idx = "21";
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, idx);//删除流程
   //   DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
      DataSet dsFlow = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(MainID);
      T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
      t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
      t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
      if (dsFlow != null && dsFlow.Tables[0] != null && dsFlow.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dsFlow.Tables[0].Rows)
            {
                if(int.Parse(dr["OfficeAutomation_Document_Flow_Idx"].ToString()) == 21)
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
        }
        string[] employnames;
        string email;
        string msnBody;
        string signEmployeeName = EmployeeName;
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Propaganda_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;



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
        //if (employname.Contains(CommonConst.EMP_GENERALMANAGER_NAME))
        //{
        //    employname = CommonConst.EMP_GMO_NAME;
        //    employnames = employname.Split(',');
        //    for (int i = 0; i < employnames.Length; i++)
        //    {
        //        email = employnames[i];
        //        msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        //        Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody, msnBody);
        //    }
        //}
        //  Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，跳过流程

        RunJS("alert('已增加设计组的审批！');window.location='" + Page.Request.Url + "'");
    }
    /// <summary>
    /// 保存申请编号
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void btnSaveNo_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID);
         string ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_ID"].ToString();
        if (da_OfficeAutomation_Document_Propaganda_Inherit.saveToNO(this.txtTNo.Text.Trim(), ID))
           {
               RunJS("alert('保存成功！');window.location='" + Page.Request.Url + "'");
           }
          
    }
    /// <summary>
    /// 保存设计组评分
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="s"></param>
    public void btnSaveDesignScore_Click(object sender,EventArgs s)
    {
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Score_Inherit dA_OfficeAutomation_Document_Propaganda_Score_Inherit = new DA_OfficeAutomation_Document_Propaganda_Score_Inherit(); 
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID);
        string ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_ID"].ToString();
       T_OfficeAutomation_Document_Propaganda_Score t =  dA_OfficeAutomation_Document_Propaganda_Score_Inherit.GetModel(ID);
       string designer = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Designer"].ToString();//设计人   
       if (designer != "请选择")
       {
           if (t == null)
           {
               t = new T_OfficeAutomation_Document_Propaganda_Score();
               t.OfficeAutomation_Document_Propaganda_Score_ID = Guid.NewGuid();
               t.OfficeAutomation_Document_Propaganda_Score_MainID = new Guid(ID);
               t.OfficeAutomation_Document_Propaganda_Score_DesignScore1 = Convert.ToInt32(this.hfDesign1.Value);
              // t.OfficeAutomation_Document_Propaganda_Score_DesignScore1Remarks = this.hfDesign1.Value == "1" ? txtDesignermarkes1.Value : null;
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore2 = Convert.ToInt32(this.hfDesign2.Value);
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore2Remarks = this.hfDesign1.Value == "1" ? txtDesignermarkes2.Value : null;
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore3 = Convert.ToInt32(this.hfDesign3.Value);
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore3Remarks = this.hfDesign3.Value == "1" ? txtDesignermarkes3.Value : null;
               t.OfficeAutomation_Document_Propaganda_Score_DesignScoreTime = DateTime.Now.ToString();
               dA_OfficeAutomation_Document_Propaganda_Score_Inherit.Add(t);
           }
           else
           {
               //修改
               t.OfficeAutomation_Document_Propaganda_Score_DesignScore1 = Convert.ToInt32(this.hfDesign1.Value);
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore1Remarks = this.hfDesign1.Value == "1" ? txtDesignermarkes1.Value : null;
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore2 = Convert.ToInt32(this.hfDesign2.Value);
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore2Remarks = this.hfDesign1.Value == "1" ? txtDesignermarkes2.Value : null;
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore3 = Convert.ToInt32(this.hfDesign3.Value);
               //t.OfficeAutomation_Document_Propaganda_Score_DesignScore3Remarks = this.hfDesign3.Value == "1" ? txtDesignermarkes3.Value : null;
               t.OfficeAutomation_Document_Propaganda_Score_DesignScoreTime = DateTime.Now.ToString();
               dA_OfficeAutomation_Document_Propaganda_Score_Inherit.Edit(t);
           }
           string email;
           string msnBody;
           DataRow drRow = ds.Tables[0].Rows[0];
           string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
           ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
           string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
           string applyUrl = Page.Request.Url.ToString();
           applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
           applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
           email = designer;
           msnBody = "您好，" + email + "：您设计广告宣传 编号为" + serialNumber + "下单人：" + apply + "已评分" + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
           Common.SendMessageEX(false, email, "广告宣传" + "下单人：" + apply + "已评分", msnBody, msnBody);
           RunJS("alert('评分成功！');window.location='" + Page.Request.Url + "'");
       }
       else
       {
           RunJS("alert('请选择设计人！');window.location='" + Page.Request.Url + "'");
       }
     
    }
    /// <summary>
    /// 保存市务组评分
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="s"></param>
    public void btnSaveCityScore_Click(object sender, EventArgs s)
    {
        DA_OfficeAutomation_Document_Propaganda_Inherit da_OfficeAutomation_Document_Propaganda_Inherit = new DA_OfficeAutomation_Document_Propaganda_Inherit();
        DA_OfficeAutomation_Document_Propaganda_Score_Inherit dA_OfficeAutomation_Document_Propaganda_Score_Inherit = new DA_OfficeAutomation_Document_Propaganda_Score_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Propaganda_Inherit.SelectByMainID(MainID);
        string ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_ID"].ToString();
        T_OfficeAutomation_Document_Propaganda_Score t = dA_OfficeAutomation_Document_Propaganda_Score_Inherit.GetModel(ID);
        string Accepter = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Accepter"].ToString();//接单人
        if (Accepter!="请选择")
        {
        
       
        if (t == null)
        {
            t = new T_OfficeAutomation_Document_Propaganda_Score();
            t.OfficeAutomation_Document_Propaganda_Score_ID = Guid.NewGuid();
            t.OfficeAutomation_Document_Propaganda_Score_MainID = new Guid(ID);
            t.OfficeAutomation_Document_Propaganda_Score_AccepterScore1 = Convert.ToInt32(this.hfCityService1.Value);
            t.OfficeAutomation_Document_Propaganda_Score_AccepterScore2 = Convert.ToInt32(this.hfCityService2.Value);
            t.OfficeAutomation_Document_Propaganda_Score_AccepterScore3 = Convert.ToInt32(this.hfCityService3.Value);
            t.OfficeAutomation_Document_Propaganda_Score_AccepterScoreTime = DateTime.Now.ToString();
            dA_OfficeAutomation_Document_Propaganda_Score_Inherit.Add(t);
        }
        else
        {
            //修改
            t.OfficeAutomation_Document_Propaganda_Score_AccepterScore1 = Convert.ToInt32(this.hfCityService1.Value);
            t.OfficeAutomation_Document_Propaganda_Score_AccepterScore2 = Convert.ToInt32(this.hfCityService2.Value);
            t.OfficeAutomation_Document_Propaganda_Score_AccepterScore3 = Convert.ToInt32(this.hfCityService3.Value);
            t.OfficeAutomation_Document_Propaganda_Score_AccepterScoreTime = DateTime.Now.ToString();
            dA_OfficeAutomation_Document_Propaganda_Score_Inherit.Edit(t);
        }
        string email;
        string msnBody;
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Propaganda_Apply"].ToString();
      
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        email = Accepter;
        msnBody = "您好，" + Accepter + "：您接单广告宣传 编号为" + serialNumber + "下单人：" + apply + "已评分" + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        Common.SendMessageEX(false, email, "广告宣传" + "下单人：" + apply + "已评分", msnBody, msnBody);
        RunJS("alert('评分成功！');window.location='" + Page.Request.Url + "'");
        }
        else
        {
            RunJS("alert('请选择接单人！');window.location='" + Page.Request.Url + "'");
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
}