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
using System.Collections;//789

using System.Data.SqlTypes;

public partial class Apply_ChangeNS_Apply_ChangeNS_Detail : BasePage
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

    #region 页面加载及初始化

    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();//789
        GetAllDepartment();


        //MainID = GetQueryString("MainID");
        string UrlMainID = GetQueryString("MainID");
        SerialNumber = "";

        InitPage(UrlMainID);

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

        //SbDataTypeHtml.Append("<div id='divtype'>必须上传资料：<select id='ddlDataType' style='width:200px;'></select> </div>");
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
        txtApply.Text = EmployeeName;
        //lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        lbData.Text = DateTime.Now.ToString("yyyy-MM-dd");
        SbJs.Append("<script type=\"text/javascript\">");
        //DrawDetailTable(0);
        //SbJs.Append("$(\"#btnUpload\").show();");
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage(string UrlMainID)
    {
        //if (UrlMainID != "")
        //{
        //    MainID = UrlMainID;
        //    DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
        //    DataSet ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID);
        //    DataRow dr = ds.Tables[0].Rows[0];
        //    string rdbs = dr["OfficeAutomation_Document_ChangeNS_SpecialApply"].ToString();
        //    if (rdbs.Contains("3"))
        //        flowsl += "3";
        //    if (rdbs.Contains("4"))
        //        flowsl += "4";
        //    if (rdbs.Contains("5"))
        //        flowsl += "5";
        //}
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();

        
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
        ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ChangeNS_ID"].ToString();
        string applicant = dr["OfficeAutomation_Main_Creater"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_ChangeNS_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_ChangeNS_Department"].ToString();
        lblApply.Text = applicant;
        txtApply.Text =dr["OfficeAutomation_Document_ChangeNS_Apply"].ToString();
        lbData.Text = DateTime.Parse(dr["OfficeAutomation_Document_ChangeNS_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtPhone.Text = dr["OfficeAutomation_Document_ChangeNS_Phone"].ToString();
        ddlArea.Text = dr["OfficeAutomation_Document_ChangeNS_Area"].ToString();
        txtLocation.Text = dr["OfficeAutomation_Document_ChangeNS_Location"].ToString();
        txtMaster.Text = dr["OfficeAutomation_Document_ChangeNS_Master"].ToString();
        txtBuyers.Text = dr["OfficeAutomation_Document_ChangeNS_Buyers"].ToString();
        txtCDate.Text = dr["OfficeAutomation_Document_ChangeNS_CDate"].ToString();
        if (dr["OfficeAutomation_Document_ChangeNS_IsContract"].ToString() == "1")
            rdbIsContract1.Checked = true;
        else if (dr["OfficeAutomation_Document_ChangeNS_IsContract"].ToString() == "0")
            rdbIsContract2.Checked = true;
        if (dr["OfficeAutomation_Document_ChangeNS_IsCommission"].ToString() == "1")
            rdbIsCommission1.Checked = true;
        else if (dr["OfficeAutomation_Document_ChangeNS_IsCommission"].ToString() == "0")
            rdbIsCommission2.Checked = true;

        string rdbs = dr["OfficeAutomation_Document_ChangeNS_SpecialApply"].ToString();
        if (rdbs.Contains("1"))
        {
            rdbSpecialApply1.Checked = true;
            ddlPayWay.Text = dr["OfficeAutomation_Document_ChangeNS_PayWay"].ToString();
        }
        if (rdbs.Contains("2"))
            rdbSpecialApply2.Checked = true;
        if (rdbs.Contains("3"))
        {
            rdbSpecialApply3.Checked = true;
            if (dr["OfficeAutomation_Document_ChangeNS_WhoKeep"].ToString().Contains("1"))
                rdbWhoKeep1.Checked = true;
            if (dr["OfficeAutomation_Document_ChangeNS_WhoKeep"].ToString().Contains("2"))
                rdbWhoKeep2.Checked = true;
        }
        if (rdbs.Contains("4"))
        {
            rdbSpecialApply4.Checked = true;
            txtSurePrice.Text = dr["OfficeAutomation_Document_ChangeNS_SurePrice"].ToString();
      //      ddlCompareP.Text = dr["OfficeAutomation_Document_ChangeNS_CompareP"].ToString();
        }
        if (rdbs.Contains("5"))
        {
            rdbSpecialApply5.Checked = true;
        }
        if (rdbs.Contains("6"))
        {
            rdbSpecialApply6.Checked = true;
            txtHandleDate.Text = dr["OfficeAutomation_Document_ChangeNS_HandleDate"].ToString();
        }
        if (rdbs.Contains("7"))
            rdbSpecialApply7.Checked = true;
        if (rdbs.Contains("8"))
            rdbSpecialApply8.Checked = true;
        if (rdbs.Contains("9"))
        {
            rdbSpecialApply9.Checked = true;
            txtOthers.Text = dr["OfficeAutomation_Document_ChangeNS_Others"].ToString();
        }
        txtDetailed.Text = dr["OfficeAutomation_Document_ChangeNS_Detailed"].ToString();
        string cbt = dr["OfficeAutomation_Document_ChangeNS_CNS"].ToString();
        if (cbt.Contains("1"))
        {
            cbCNS1.Checked = true;
            //20170221注释
           // ddlRelationship.Text = dr["OfficeAutomation_Document_ChangeNS_Relationship"].ToString();
        }
        if (cbt.Contains("2"))
            cbCNS2.Checked = true;
        if (cbt.Contains("3"))
            cbCNS3.Checked = true;
        if (cbt.Contains("4"))
        {
            cbCNS4.Checked = true;
            ddlPriceChange.Text = dr["OfficeAutomation_Document_ChangeNS_PriceChange"].ToString();
            ddlCompareOfChange.Text = dr["OfficeAutomation_Document_ChangeNS_CompareOfChange"].ToString();
        }
        if (cbt.Contains("5"))
            cbCNS5.Checked = true;

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        
        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;
        if (isApplicant)
        {
           // SbJs.Append("$(\"#btnUpload\").show();");
            //try
            //{
            //    if (drc[5]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
            //        SbJs.Append("$(\"#btnUpload\").hide();");
            //    else
            //        SbJs.Append("$(\"#btnUpload\").show();");
            //}
            //catch
            //{
            //SbJs.Append("$(\"#btnUpload\").show();");
            //}
            if (flowState == "1")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                //SbJs.Append(ApplyDisplayPart);
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
            btnSignSave.Visible = true;

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
                txtApply.Text = EmployeeName;
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
            if (isApplicant)
                btnReWrite.Visible = true;
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
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
        if (flows != null)
            SbJs.Append("$('#trCOO').show();");

        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        if (Purview.Contains("OA_Search_002"))//789
            GetAllDepartment();
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
        flows3 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        flows4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        if (flows == null && flows3 == null && flows4 == null)
        {
            if (EmployeeID == "15277" || EmployeeID == "4836" || EmployeeID == "34498" || EmployeeID == "42900")
                SbJs.Append("$(\"#TSD1\").show();$(\"#add1F\").show();");
        }

        if ((EmployeeID == "15277" || EmployeeID == "4836" || EmployeeID == "42900"))
            SbJs.Append("$('#addflow').show();");

        if (flows == null && flows3 == null && flows4 == null)
        {
            foreach (DataRow drs in drc)
            {
                string idx = drs["OfficeAutomation_Flow_Idx"].ToString();
                if (!Regex.IsMatch(((float.Parse(idx) - 1) / 8.0).ToString(), "^[0-9]*[1-9][0-9]*$"))
                    SbJs.Append("$('#divIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();$('#divTxtIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();");
                SbJs.Append("$('#txtIDxa" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_Employee"] + ",');");
            }
        }
        else 
        {
            foreach (DataRow drs in drc)
            {
                SbJs.Append("$('#txtidx" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_Employee"] + ",');");
            }
            
        }
        DataSet ds2 = new DataSet();
        bool x2 = false, x3 = false, x4 = false, x5 = false, x6 = false,x7=false,x8=false ;
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
            if (EmployeeID == "42900" || EmployeeID == "15277")
                DrawDetailTable(LogisticsFlowCount / 8);
            for (int n = 0, i = 1; n < LogisticsFlowCount; n++, i++)
            {
                int k = i + 19;
                dr = ds2.Tables[0].Rows[n];
                SbJs.Append("$('#txtDpm" + k + "').val('" + dr["OfficeAutomation_Document_GeneralApply_Detail_Department"] + "');");
                SbJs.Append("$('#rdoIsCmodel" + k + "1" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                n++;
                dr = ds2.Tables[0].Rows[n];
                x2 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + k + "2" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                n++;
                dr = ds2.Tables[0].Rows[n];
                x3 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + k + "3" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";

                n++;
                dr = ds2.Tables[0].Rows[n];
                x4 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + k + "4" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";

                n++;
                dr = ds2.Tables[0].Rows[n];
                x5 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + k + "5" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";

                n++;
                dr = ds2.Tables[0].Rows[n];
                x6 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + k + "6" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                n++;
                dr = ds2.Tables[0].Rows[n];
                x7 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + k + "7" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                n++;
                dr = ds2.Tables[0].Rows[n];
                x8 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + k + "8" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";

                DrawAFTable(i, x2, x3, x4, x5, x6,x7,x8,dr["OfficeAutomation_Document_GeneralApply_Detail_Department"].ToString());
            }
        }//987

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

        ////如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        ////if (flag3)
        //SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();$('#trGeneralManager').show();");

        ////T_OfficeAutomation_Flow flows;//789
        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        //if (flows != null)
        //    SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 61);
        if (flows == null)
        {
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
            if (!rdbSpecialApply9.Checked)
            {
                if (flowState == "1" && applicant == EmployeeName)
                    SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
                if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
                    btnEditFlow2.Visible = true;
            }
        }
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


        //获取该单附件列表
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

        if (dsAttach != null && dsAttach.Tables[0] != null && dsAttach.Tables[0].Rows.Count > 0)
        {
            Sbjstb.Append("<script type=\"text/javascript\">");

            string datumtype = "", datumtypename="";

            for (var i = 0; i < dsAttach.Tables[0].Rows.Count; i++)
            {
                string attachname = dsAttach.Tables[0].Rows[i]["OfficeAutomation_Attach_Name"].ToString();
                string attachpath = dsAttach.Tables[0].Rows[i]["OfficeAutomation_Attach_Path"].ToString();

                if (attachname.Substring(0, 2).IndexOf('_') != -1)
                {
                    datumtype = attachname.Substring(0, attachname.IndexOf('_'));
                    datumtypename = datumtype == "0" ? "存量房买卖合同变更协议" : datumtype == "1" ? "网签委托确认书" : datumtype == "2" ? "新买家身份证" : datumtype == "3" ? "购房资格调查确认表" : datumtype == "4" ? "关系证明/法律部签批的变更申请" : datumtype == "5" ? "委托公证书" : datumtype == "6" ? "代理人身份证资料" : "";

                    Sbjstb.Append("var html='<tr id=" + datumtype + " class=\"addTb\">'+");
                    Sbjstb.Append("'<td style=\"width:300px;\">" + datumtypename + "</td>'+");
                    Sbjstb.Append("'<td style=\"text-align:center;\"><image src=\"/Images/delete.gif\" onclick=DeleteRow(this)/></td>'+");
                    Sbjstb.Append("'<td style=\"display:none;\">" + attachname + "</td>'+");
                    Sbjstb.Append("'<td style=\"display:none;\">" + attachpath + "</td>'+");
                    Sbjstb.Append("'</tr>';");

                    Sbjstb.Append("$('#tabuploadfile').append(html);");
                }
            }
            
            Sbjstb.Append("</script>");
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

        DataColumn dc = new DataColumn("OfficeAutomation_Attach_NameNew", typeof(string));
        DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

        dsAttach.Tables[0].Columns.Add(dc);

        string datumtypename="", lastattachname="";
        for (var i = 0; i < dsAttach.Tables[0].Rows.Count; i++) 
        {
            string attachname = dsAttach.Tables[0].Rows[i]["OfficeAutomation_Attach_Name"].ToString();

            if (attachname.Substring(0,2).IndexOf('_') != -1)
            {
                string datumtype = attachname.Substring(0, attachname.IndexOf('_'));
                datumtypename = datumtype == "0" ? "存量房买卖合同变更协议" : datumtype == "1" ? "网签委托确认书" : datumtype == "2" ? "新买家身份证" : datumtype == "3" ? "购房资格调查确认表" : datumtype == "4" ? "关系证明/法律部签批的变更申请" : datumtype == "5" ? "委托公证书" : datumtype == "6" ? "代理人身份证资料" : "";
                lastattachname = attachname.Substring(attachname.IndexOf('_'));
                dsAttach.Tables[0].Rows[i]["OfficeAutomation_Attach_NameNew"] = datumtypename + lastattachname;
            }
            else 
            {
                dsAttach.Tables[0].Rows[i]["OfficeAutomation_Attach_NameNew"] = attachname;
            }
            
        }

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
        T_OfficeAutomation_Document_ChangeNS t_OfficeAutomation_Document_ChangeNS = new T_OfficeAutomation_Document_ChangeNS();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        T_OfficeAutomation_Attach t_OfficeAutomation_Attach = new T_OfficeAutomation_Attach();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit =new DA_OfficeAutomation_Attach_Inherit();

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
            //if (MainID == "")
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

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ChangeNS" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 47; //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                t_OfficeAutomation_Document_ChangeNS = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = txtApply.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtLocation.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_ChangeNS_Inherit.Insert(t_OfficeAutomation_Document_ChangeNS);//插入申请表

                //InsertChangeNSDetail(t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_ID);

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                #region 根据默认流程表中的固定环节添加流程

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
                AddFlows();
                #endregion

                #region 上传附件  2016-12-06
                
                UploadFiles(MainID);
                #endregion

                #endregion

                    Common.AddLog(EmployeeID, EmployeeName, 51, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                if (flowsadd != "A")
                    RunJS("alert('保存成功！');window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ChangeNS_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + flowsadd + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                else
                    RunJS("alert('申请表保存成功，稍后会由汇瀚网签组来编辑审批流程！');var returnVaulue=window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    Update();
                    UploadFiles(MainID);
                    if (flowsadd != "A")
                        RunJS("alert('保存成功！');var win=window.showModalDialog(\"Apply_ChangeNS_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + flowsadd + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                    else
                        RunJS("alert('申请表保存成功，稍后会由汇瀚网签组来编辑审批流程！');window.location='/Apply/Apply_Search.aspx';");
                }
                else
                    Alert("未开通编辑修改权限。");
                #endregion
            }
        }
        catch (Exception ex)
        {
            Alert("保存失败！" + ex.Message.Replace("\r\n",""));
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
        DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();

        DataSet ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ChangeNS_ID"].ToString();

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
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "8" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody = "";

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeNS_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ChangeNS_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.ToLowerInvariant().IndexOf("/apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl + "?MainID=" + MainID;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_ChangeNS_Apply"]);
                    sbMailBody.Append("<br/>申请分行：" + drRow["OfficeAutomation_Document_ChangeNS_Department"]);
                    sbMailBody.Append("<br/>发文日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ChangeNS_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>成交编号：" + drRow["OfficeAutomation_Document_ChangeNS_ApplyID"]);
                    sbMailBody.Append("<br/>联系电话：" + drRow["OfficeAutomation_Document_ChangeNS_Phone"]);
                    sbMailBody.Append("<br/>区域：" + drRow["OfficeAutomation_Document_ChangeNS_Location"]);

                    sbMailBody.Append("<br/>物业地址：" + drRow["OfficeAutomation_Document_ChangeNS_Location"]);
                    sbMailBody.Append("<br/>业主：" + drRow["OfficeAutomation_Document_ChangeNS_Master"]);
                    sbMailBody.Append("<br/>买家：" + drRow["OfficeAutomation_Document_ChangeNS_Buyers"]);
                    if (drRow["OfficeAutomation_Document_ChangeNS_IsContract"].ToString() == "1")
                        sbMailBody.Append("<br/>已完成网签版合同");
                    else if (drRow["OfficeAutomation_Document_ChangeNS_IsContract"].ToString() == "0")
                        sbMailBody.Append("<br/>未完成网签版合同");
                    if (drRow["OfficeAutomation_Document_ChangeNS_IsCommission"].ToString() == "1")
                        sbMailBody.Append("<br/>已收佣");
                    else if (drRow["OfficeAutomation_Document_ChangeNS_IsCommission"].ToString() == "0")
                        sbMailBody.Append("<br/>未收佣");
                    sbMailBody.Append("<br/>收佣日期：" + drRow["OfficeAutomation_Document_ChangeNS_CDate"]);

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

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            /*添加需求：通知非审批流出现人员——当选择【（8）客户要求自行网签】时，需要在申请走完整个流程后，以邮件方式通知法律部*/
                            if (rdbSpecialApply8.Checked)
                            {
                                employname = "李蓬桂,陈宇平,何恺鹏,苏秉星";
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
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody,MainID);
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
        //    DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_ChangeNS_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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
                //if (drc[5]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
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

    private T_OfficeAutomation_Document_ChangeNS GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_ChangeNS t_OfficeAutomation_Document_ChangeNS = new T_OfficeAutomation_Document_ChangeNS();
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_ID = UndertakeProjID;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Apply = txtApply.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Phone = txtPhone.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Area = ddlArea.SelectedValue;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Location = txtLocation.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Master = txtMaster.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Buyers = txtBuyers.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_IsContract = rdbIsContract1.Checked ? "1" : "0";
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_IsCommission = rdbIsCommission1.Checked ? "1" : "0";
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_CDate = txtCDate.Text;

        string rdbs = "";
        if (rdbSpecialApply1.Checked == true)
            rdbs += "|1";
        if (rdbSpecialApply2.Checked == true)
            rdbs += "|2";
        if (rdbSpecialApply3.Checked == true)
            rdbs += "|3";
        if (rdbSpecialApply4.Checked == true)
            rdbs += "|4";
        if (rdbSpecialApply5.Checked == true)
            rdbs += "|5";
        if (rdbSpecialApply6.Checked == true)
            rdbs += "|6";
        if (rdbSpecialApply7.Checked == true)
            rdbs += "|7";
        if (rdbSpecialApply8.Checked == true)
            rdbs += "|8";
        if (rdbSpecialApply9.Checked == true)
            rdbs += "|9";
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_SpecialApply = rdbs;

        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_PayWay = ddlPayWay.SelectedValue;
        string WhoKeep = "";
        if (rdbWhoKeep1.Checked == true)
            WhoKeep += "|1";
        if (rdbWhoKeep2.Checked == true)
            WhoKeep += "|2";
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_WhoKeep = WhoKeep;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_SurePrice = txtSurePrice.Text;
        //t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_CompareP = ddlCompareP.SelectedValue;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_CompareP = "";
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_HandleDate = txtHandleDate.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Others = txtOthers.Text;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Detailed = txtDetailed.Text;

        string cbt = "";
        if (cbCNS1.Checked == true)
            cbt += "|1";
        if (cbCNS2.Checked == true)
            cbt += "|2";
        if (cbCNS3.Checked == true)
            cbt += "|3";
        if (cbCNS4.Checked == true)
            cbt += "|4";
        if (cbCNS5.Checked == true)
            cbt += "|5";
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_CNS = cbt;

        //20170221修改，取消关系证明
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_Relationship = "";
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_PriceChange = ddlPriceChange.SelectedValue;
        t_OfficeAutomation_Document_ChangeNS.OfficeAutomation_Document_ChangeNS_CompareOfChange = ddlCompareOfChange.SelectedValue;

        return t_OfficeAutomation_Document_ChangeNS;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()//*-
    {
        T_OfficeAutomation_Document_ChangeNS t_OfficeAutomation_Document_ChangeNS = new T_OfficeAutomation_Document_ChangeNS();
        DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeNS_ID"].ToString();

        t_OfficeAutomation_Document_ChangeNS = GetModelFromPage(new Guid(ID));

        string apply = "";
        string depname = txtDepartment.Text;
        string summary = txtLocation.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);

        da_OfficeAutomation_Document_ChangeNS_Inherit.Update(t_OfficeAutomation_Document_ChangeNS);//修改申请表

        //DA_OfficeAutomation_Document_ChangeNS_Detail_Inherit da_OfficeAutomation_Document_ChangeNS_Detail_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Detail_Inherit();
        //da_OfficeAutomation_Document_ChangeNS_Detail_Inherit.Delete(ID);
        //InsertChangeNSDetail(new Guid(ID));
        AddFlows();
        Common.AddLog(EmployeeID, EmployeeName, 51, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

     #region 上传附件  2016-12-06
    public void UploadFiles(string mainId)
    {

        T_OfficeAutomation_Attach t_OfficeAutomation_Attach = new T_OfficeAutomation_Attach();
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();

        da_OfficeAutomation_Attach_Inherit.DeleteAttachByMain(mainId);

        if (this.hidnamepath.Value != "")
        {
            string[] arr = this.hidnamepath.Value.Split(':');
            for (var i = 0; i < arr.Length; i++)
            {
                t_OfficeAutomation_Attach.OfficeAutomation_Attach_MainID = new Guid(MainID);
                t_OfficeAutomation_Attach.OfficeAutomation_Attach_Name = arr[i].Split(',')[0];
                t_OfficeAutomation_Attach.OfficeAutomation_Attach_Path = arr[i].Split(',')[1];

                da_OfficeAutomation_Attach_Inherit.Insert(t_OfficeAutomation_Attach);
            }
        }

    }    
     #endregion



    #region 其他

    #region 新增明细表

    /// <summary>
    /// 新增明细表
    /// </summary>
    /// <param name="gChangeNSID"></param>
    //private void InsertChangeNSDetail(Guid gChangeNSID)
    //{
    //    if (hdDetail.Value == "")
    //        return;

    //    T_OfficeAutomation_Document_ChangeNS_Detail t_OfficeAutomation_Document_ChangeNS_Detail;
    //    DA_OfficeAutomation_Document_ChangeNS_Detail_Inherit da_OfficeAutomation_Document_ChangeNS_Detail_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Detail_Inherit();

    //    string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
    //    try
    //    {
    //        for (int i = 0; i < details.Length; i++)
    //        {
    //            string[] detail = Regex.Split(details[i], "\\&\\&");
    //            if (detail[0] == "")
    //                continue;
    //            t_OfficeAutomation_Document_ChangeNS_Detail = new T_OfficeAutomation_Document_ChangeNS_Detail();
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_ID = Guid.NewGuid();
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_MainID = gChangeNSID;
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_Property = detail[0];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_Controler = detail[1];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_PropertyID = detail[2];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_PropertyDate = detail[3];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_OldDeal = detail[4];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_NewDeal = detail[5];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_AjustDeal = detail[6];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_ShouldComm = detail[7];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_ActualComm = detail[8];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_AjustComm = detail[9];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_LeadReason = int.Parse(detail[10]);
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_Commitment = detail[11];
    //            t_OfficeAutomation_Document_ChangeNS_Detail.OfficeAutomation_Document_ChangeNS_Detail_Reason = detail[12];

    //            da_OfficeAutomation_Document_ChangeNS_Detail_Inherit.Insert(t_OfficeAutomation_Document_ChangeNS_Detail);
    //        }
    //    }
    //    catch (Exception ee)
    //    {
    //        Alert(ee.Message);
    //        return;
    //    }
    //}

    #endregion

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

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite52"] = "1";
        Response.Write("<script>window.open('Apply_ChangeNS_Detail.aspx?MainID=" + MainID + "');</script>");
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

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);

        DA_OfficeAutomation_Document_ChangeNS_Inherit changens_Inherits = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
        DataSet ds = changens_Inherits.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = EmployeeID;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ChangeNS_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;

        if (flowState == "1")
        {
            RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonFlowLogistics&id=" + EmployeeID + "&tablename=网签变更、特殊申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&deleteidxs=0',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
            insertGeneralApplyDetail();
            RunJS("alert('审批流程已保存');window.location='" + Page.Request.Url + "';");
        }
        else if (flowState == "2")
        {
            RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=网签变更、特殊申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=1&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
            insertGeneralApplyDetail();
            RunJS("alert('审批流程已保存。');window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "';");
        }
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
            int k = i + 19;
            SbHtml.Append("<tr id=\"trAddFlow" + k + "\" class=\"noborder\" style=\"height: 85px;\">");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px;\" colspan=\"4\">");
            SbHtml.Append("<div class=\"flow\">");
            SbHtml.Append("部门名称：<input type=\"text\" id=\"txtDpm" + k + "\" style=\"margin-bottom: 10px;width:250px;\" /><br/>");
            SbHtml.Append("<div id=\"divIDx" + (8 * k + 1) + "\" class=\"item2\">环节1</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (8 * k + 1) + "\" class=\"item2\">");
            SbHtml.Append("   <input type=\"text\" id=\"txtIDxa" + (8 * k + 1) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (8 * k+ 1) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + k + "11\" checked=\"checked\" name=\"IsCmodel" + k + "1\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + k + "11\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + k + "10\" name=\"IsCmodel" + k + "1\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + k + "10\">单人审批</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (8 * k + 2) + "\" class=\"item2\"><input id=\"btnIDx" + k + "2\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (8 * k + 2) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + k + "2\" for=\"btnIDx" + k + "2\">环节2</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (8 * k + 2) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节2&nbsp;<input type=\"text\" id=\"txtIDxa" + (8 * k + 2) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (8 * k + 2) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + k + "21\" checked=\"checked\" name=\"IsCmodel" + k + "2\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + k + "21\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + k + "20\" name=\"IsCmodel" + k + "2\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + k + "20\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (8 * k + 2) + ")\">取消</a>");
            SbHtml.Append("</div>");
            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (8 * k + 3) + "\" class=\"item2\"><input id=\"btnIDx" + k + "3\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (8 * k + 3) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + k + "3\" for=\"btnIDx" + k + "3\">环节3</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (8 * k + 3) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节3&nbsp;<input type=\"text\" id=\"txtIDxa" + (8 * k + 3) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (8 * k + 3) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + k + "31\" checked=\"checked\" name=\"IsCmodel" + k + "3\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + k + "31\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + k + "30\" name=\"IsCmodel" + k + "3\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" +k+ "30\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (8 * k + 3) + ")\">取消</a>");
            SbHtml.Append("</div>");

            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (8 * k + 4) + "\" class=\"item2\"><input id=\"btnIDx" +k + "4\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (8 * k + 4) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + k + "4\" for=\"btnIDx" + k + "4\">环节4</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (8 * k + 4) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节4&nbsp;<input type=\"text\" id=\"txtIDxa" + (8 * k + 4) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (8 * k + 4) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + k+ "41\" checked=\"checked\" name=\"IsCmodel" + k + "4\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + k + "41\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + k + "40\" name=\"IsCmodel" + k + "4\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + k + "40\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (8 * k + 4) + ")\">取消</a>");
            SbHtml.Append("</div>");

            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (8 * k + 5) + "\" class=\"item2\"><input id=\"btnIDx" + k + "5\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (8 * k + 5) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + k + "5\" for=\"btnIDx" + k + "5\">环节5</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (8 * k + 5) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节5&nbsp;<input type=\"text\" id=\"txtIDxa" + (8 * k + 5) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (8 * k + 5) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + k + "51\" checked=\"checked\" name=\"IsCmodel" + k + "5\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + k + "51\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + k + "50\" name=\"IsCmodel" + k + "5\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" +k + "50\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (8 * k + 5) + ")\">取消</a>");
            SbHtml.Append("</div>");

            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (8 * k + 6) + "\" class=\"item2\"><input id=\"btnIDx" + k + "6\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (8 * k + 6) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + k + "6\" for=\"btnIDx" + k + "6\">环节6</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (8 * k + 6) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节6&nbsp;<input type=\"text\" id=\"txtIDxa" + (8 * k + 6) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (8 * k + 6) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + k + "61\" checked=\"checked\" name=\"IsCmodel" + k + "6\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + k + "61\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + k + "60\" name=\"IsCmodel" + k + "6\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + k + "60\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (8 * k + 6) + ")\">取消</a>");
            SbHtml.Append("</div>");

            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (8 * k + 7) + "\" class=\"item2\"><input id=\"btnIDx" + k + "7\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (8 * k + 7) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + k + "7\" for=\"btnIDx" + k + "7\">环节7</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (8 * k + 7) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节7&nbsp;<input type=\"text\" id=\"txtIDxa" + (8 * k + 7) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (8 * k + 7) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + k + "71\" checked=\"checked\" name=\"IsCmodel" + k + "7\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + k + "71\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + k + "70\" name=\"IsCmodel" + k + "7\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + k + "70\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (8 * k + 7) + ")\">取消</a>");
            SbHtml.Append("</div>");

            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (8 * k + 8) + "\" class=\"item2\"><input id=\"btnIDx" + k + "8\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (8 * k + 8) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + k + "8\" for=\"btnIDx" + k + "8\">环节8</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (8 * k + 8) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节8&nbsp;<input type=\"text\" id=\"txtIDxa" + (8 * k + 8) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (8 * k + 8) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + k + "81\" checked=\"checked\" name=\"IsCmodel" + k + "8\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + k + "81\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + k + "80\" name=\"IsCmodel" + k + "8\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + k + "80\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (8 * k + 8) + ")\">取消</a>");
            SbHtml.Append("</div></div>");

            SbHtml.Append("</td>");
            SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    public void DrawAFTable(int n, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, string department)
    {
        for (int i = 1; i <= 1; i++)
        {
            int j = 1, k = 8 * n;
            if (x2) j++;
            if (x3) j++;
            if (x4) j++;
            if (x5) j++;
            if (x6) j++;
            if (x7) j++;
            if (x8) j++;

            //else if (x2 && x3)
            //    j = 3;
            //else if ((!x2 && x3) || (x2 && !x3))
            //    j = 2;
            //else if (!x2 && !x3)
            //    j = 1;
            SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
            SbHtmlLogisticsFlow.Append("<td rowspan=\"" + j + "\"  class=\"auto-style1\">" + department + "</td>");
            SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
            SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 8 * 20 - 7) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 7) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 8 * 20 - 7) + "\">同意</label>");
            SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 8 * 20 -7) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 7) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 8 * 20 - 7) + "\">不同意</label>");
            SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 8 * 20 - 7) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 7) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 8 * 20 - 7) + "\">其他意见</label>");
            SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 8 * 20 -7) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
            SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 8 * 20 - 7) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 8 * 20 - 7) + "\')\" style=\"display: none;\" />");
            SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 8 * 20 - 7) + "\">_________</span></div>");
            SbHtmlLogisticsFlow.Append("</td>");
            SbHtmlLogisticsFlow.Append("</tr>");
            if (x2)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 8 * 20 - 6) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 6) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 8 * 20 - 6) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 8 * 20 - 6) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 6) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 8 * 20 - 6) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 8 * 20 - 6) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 6) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 8 * 20 - 6) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 8 * 20 - 6) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 8 * 20 - 6) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 8 * 20 - 6) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 8 * 20 - 6) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
            if (x3)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 8 * 20 - 5) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 5) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 8 * 20 - 5) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 8 * 20 - 5) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 5) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 8 * 20 - 5) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 8 * 20 - 5) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 5) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 8 * 20 - 5) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 8 * 20 - 5) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 8 * 20 - 5) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 8 * 20 - 5) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 8 * 20 - 5) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
            if (x4)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 8 * 20 - 4) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 4) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 8 * 20 - 4) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 8 * 20 - 4) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 4) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 8 * 20 - 4) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 8 * 20 - 4) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 4) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 8 * 20 - 4) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 8 * 20 - 4) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 8 * 20 - 4) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 8 * 20 - 4) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 8 * 20 - 4) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }

            if (x5)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 8 * 20 - 3) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 3) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 8 * 20 - 3) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 8 * 20 - 3) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 3) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 8 * 20 - 3) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 8* 20 - 3) + "\" type=\"radio\" name=\"agree" + (k +8 * 20 - 3) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k +8 * 20 - 3) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 8 * 20 - 3) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 8 * 20 - 3) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 8 * 20 - 3) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 8 * 20 - 3) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
            if (x6)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 8 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k +8 * 20 - 2) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 8 * 20 - 2) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 8 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 2) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 8 * 20 - 2) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 8 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 2) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 8 * 20 - 2) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 8 * 20 - 2) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 8 * 20 - 2) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 8 * 20 - 2) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 8 * 20 - 2) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
            if (x7)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 8 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 8 * 20 - 1) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 8 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 8 * 20 - 1) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k +8 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 8 * 20 - 1) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 8 * 20 - 1) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 8 * 20 - 1) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 8 * 20 - 1) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 8 * 20 - 1) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
            if (x8)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 8 * 20) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 8 * 20) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 8 * 20) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 8 * 20) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 8 * 20) + "\" type=\"radio\" name=\"agree" + (k + 8 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 8 * 20) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 8 * 20 - 2) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 8 * 20) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 8 * 20) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 8 * 20) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
        }
        SbJs.Append("i=" + n + ";");
    }//987

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
            DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeNS_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ChangeNS_Department"].ToString();
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
            DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeNS_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ChangeNS_Department"].ToString();
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
                    msnBody = "您好，" + employnames[i2] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已被" + EmployeeName + "修改了部分内容，待会需要您重审。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    email = employnames[i2]; if (email != "")
                        Common.SendMessageEX(false, email, "该份申请已经申请人修改，请重新审批！谢谢", msnBody, msnBody);
                }
            }

            #region 修改编辑
            if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
            {
                Update();
                UploadFiles(MainID);
                da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                if (flowsadd != "A")
                    RunJS("alert('所作的修改已保存！');var win=window.showModalDialog(\"Apply_ChangeNS_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + flowsadd + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='" + Page.Request.Url + "'; }");
                else
                    RunJS("alert('所作的修改已保存，稍后会由汇瀚网签组来编辑审批流程！');window.location='/Apply/Apply_Search.aspx';");
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
            DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeNS_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ChangeNS_Department"].ToString();
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
            RunJS("var win=window.showModalDialog(\"Apply_ChangeNS_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "&flowsadd=" + fls + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    protected void rdbSpecialApply1_CheckedChanged(object sender, EventArgs e)
    {
        //cbCNS1.Checked = false;
        //cbCNS2.Checked = false;
        //cbCNS3.Checked = false;
        //cbCNS4.Checked = false;
        //cbCNS5.Checked = false;
        //ddlRelationship.SelectedValue = "请选择";
        //ddlPriceChange.SelectedValue = "请选择";
        //ddlCompareOfChange.SelectedValue = "请选择";
    }
    protected void cbCNS1_CheckedChanged(object sender, EventArgs e)
    {
        //rdbSpecialApply1.Checked = false;
        //rdbSpecialApply2.Checked = false;
        //rdbSpecialApply3.Checked = false;
        //rdbSpecialApply4.Checked = false;
        //rdbSpecialApply5.Checked = false;
        //rdbSpecialApply6.Checked = false;
        //rdbSpecialApply7.Checked = false;
        //rdbSpecialApply8.Checked = false;
        //rdbSpecialApply9.Checked = false;
        //ddlPayWay.SelectedValue = "请选择";
        //ddlCompareP.SelectedValue = "请选择";
        //rdbWhoKeep1.Checked = false;
        //rdbWhoKeep2.Checked = false;

        //ddlDataType.Items.Add(new ListItem("请选择", "-1"));

        //if (cbCNS1.Checked == true)
        //{
        //    dictype.Add(0, "存量房买卖合同变更协议");
        //    dictype.Add(1, "网签委托确认书");
        //    dictype.Add(2, "新买家身份证");
        //    dictype.Add(3, "购房资格调查确认表");
        //    dictype.Add(4, "关系证明/法律部签批的变更申请");
        //}

        //ddlDataType.DataSource = dictype;
        //ddlDataType.DataTextField = "Value";
        //ddlDataType.DataValueField = "Key";
        //ddlDataType.DataBind();

    }

    #region 根据条件增加流程
    protected void AddFlows()
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        T_OfficeAutomation_Flow flows;

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        if (flows == null)
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 3);
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        if (flows == null)
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 4);
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 5);
        if (flows == null)
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 5);
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 6);

        if (!rdbSpecialApply9.Checked)
        {
            DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
            DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID);
            ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeNS_ID"].ToString(); //在不同的表要注意修改
            da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Delete(ID);

            /*A、当同时选择【（1）自行取网签合同原件办理房管局递件手续；付款方式：一次性】时，
            审批流程为：分行申请人—分行主管—区域经理—汇瀚网签组（网签组可视乎合同所在而进行审批流程设置）*/
            if (rdbSpecialApply1.Checked && ddlPayWay.SelectedValue == "一次性")
            {
                flowsadd += "3";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*2、当选择【（6）超时申请办理递件业务，要求办理日期：___________】时，
            审批流程为：分行申请人—分行主管—汇瀚服务中心主管*/
            if (rdbSpecialApply6.Checked)
            {
                //flowsadd += "3";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 9);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "2851";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "钟思慧";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*1、当选择【（5）房管局的退案申请盖网签专用章】时，
            审批流程为：分行申请人—分行主管—区域经理—汇瀚网签组*/
            if (rdbSpecialApply5.Checked)
            {
                flowsadd += "3";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*A、当同时选择【（4）买卖双方确认网签成交价________元
            】、【与成交价对比：低于成交价5成】时，
            审批流程为：分行申请人—分行部门主管—区域经理—区域总监—区域负责人—汇瀚网签组*/
            //if (rdbSpecialApply4.Checked && ddlCompareP.SelectedValue == "低于成交价5成")
            if (rdbSpecialApply4.Checked)
            {
                flowsadd += "345";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*B、当同时选择【（4）买卖双方确认网签成交价________元
            】、【与成交价对比：低于成交价7成】时，
            审批流程为：分行申请人—分行部门主管—区域经理—区域总监—汇瀚网签组*/
            //if (rdbSpecialApply4.Checked && ddlCompareP.SelectedValue == "低于成交价7成")
            //{
            //    flowsadd += "34";
            //    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
            //    if (flows == null)
            //    {
            //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
            //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
            //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
            //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            //    }
            //}

            /*C、当同时选择【（4）买卖双方确认网签成交价___元】、【与成交价对比：低于成交价5成/低于成交价7成/其他情况】、
             【（3）取回网签合同原件留底（□业主   □买家）】时，
            审批流程为：分行申请人—分行部门主管—区域经理—区域总监—区域负责人—法律部—汇瀚网签组—汇瀚营运总经理*/
            //if (rdbSpecialApply4.Checked && ddlCompareP.SelectedValue != "与成交价一致" && rdbSpecialApply3.Checked)
            if (rdbSpecialApply4.Checked && rdbSpecialApply3.Checked)
            {
                flowsadd += "345";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 6);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    if (ddlArea.SelectedValue == "天河区" || ddlArea.SelectedValue == "荔湾区(含芳村、南海)")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂";
                    }
                    else if (ddlArea.SelectedValue == "海珠区" || ddlArea.SelectedValue == "番禺区")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "6189";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈宇平";
                    }
                    else if (ddlArea.SelectedValue == "花都区" || ddlArea.SelectedValue == "白云区" || ddlArea.SelectedValue == "越秀区")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13398";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何恺鹏";
                    }
                    else if (ddlArea.SelectedValue == "项目部" || ddlArea.SelectedValue == "工商铺")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13776";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "苏秉星";
                    }
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 6;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 10);
                //if (flows == null)
                //{
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13161";
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "曹颖思";
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;
                //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //}
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0111";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄蕙晶";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 20;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*D、当同时选择【（4）买卖双方确认网签成交价____元】、【与成交价对比：与成交价一致】、
             【（3）取回网签合同原件留底（□业主   □买家）】时，
            审批流程为：分行申请人—分行部门主管—区域经理—汇瀚网签组*/
            //if (rdbSpecialApply4.Checked && ddlCompareP.SelectedValue == "与成交价一致" && rdbSpecialApply3.Checked)
            if (rdbSpecialApply4.Checked  && rdbSpecialApply3.Checked)
            {
                flowsadd += "3";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*3、当选择【（7）未上成交，要求提前网签及递件】或者选择【（8）客户要求自行网签】时，
            审批流程为：分行申请人—分行主管—区域经理—区域总监—区域负责人—汇瀚网签组—汇瀚营运总经理*/
            if (rdbSpecialApply7.Checked || rdbSpecialApply8.Checked)
            {
                flowsadd += "345";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 10);
                //if (flows == null)
                //{
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13161";
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "曹颖思";
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;
                //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //}
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0111";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄蕙晶";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 20;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*4、当选择【（2）买卖双方取消交易，需要撤销网签合同】时，
            审批流程为：分行申请人—分行主管—区域经理—区域总监—区域负责人—法律部—汇瀚网签组*/
            if (rdbSpecialApply2.Checked)
            {
                flowsadd += "345";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 6);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    if (ddlArea.SelectedValue == "天河区" || ddlArea.SelectedValue == "荔湾区(含芳村、南海)")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂";
                    }
                    else if (ddlArea.SelectedValue == "海珠区" || ddlArea.SelectedValue == "番禺区")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "6189";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈宇平";
                    }
                    else if (ddlArea.SelectedValue == "花都区" || ddlArea.SelectedValue == "白云区" || ddlArea.SelectedValue == "越秀区")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13398";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何恺鹏";
                    }
                    else if (ddlArea.SelectedValue == "项目部" || ddlArea.SelectedValue == "工商铺")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13776";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "苏秉星";
                    }
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 6;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /**********************************************************************************************************/
            /*1、当同时选择【（4）报价变更：高→低】、【与成交价对比：低于成交价5成（含5成）】时，
            审批流程为：分行申请人—分行主管—区域经理—区域总监—区域负责人—汇瀚网签组*/
            if (cbCNS4.Checked && ddlPriceChange.SelectedValue == "高→低" && ddlCompareOfChange.SelectedValue == "低于成交价5成（含5成）")
            {
                flowsadd += "345";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*2、当同时选择【（4）报价变更：高→低】、【与成交价对比：低于成交价7成/其他情况】时，
            审批流程为：分行申请人—分行主管—区域经理—区域总监—汇瀚网签组*/
            if (cbCNS4.Checked && ddlPriceChange.SelectedValue == "高→低" && ddlCompareOfChange.SelectedValue != "低于成交价5成（含5成）")
            {
                flowsadd += "34";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }

            /*3、当同时选择【（1）更改落名人】、【是否有关系证明：否】时，
            审批流程为：分行申请人—分行主管—区域经理—法律部—汇瀚网签组*/
            if (cbCNS1.Checked)
            {
                flowsadd += "3";

                //20170221注释，没有关系证明取消法律部审批
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 6);
                //if (flows == null)
                //{
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //    if (ddlArea.SelectedValue == "天河区" || ddlArea.SelectedValue == "荔湾区(含芳村、南海)")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂";
                //    }
                //    else if (ddlArea.SelectedValue == "海珠区" || ddlArea.SelectedValue == "番禺区")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "6189";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈宇平";
                //    }
                //    else if (ddlArea.SelectedValue == "花都区" || ddlArea.SelectedValue == "白云区" || ddlArea.SelectedValue == "越秀区")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13398";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何恺鹏";
                //    }
                //    else if (ddlArea.SelectedValue == "项目部" || ddlArea.SelectedValue == "工商铺")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13776";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "苏秉星";
                //    }
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 6;
                //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //}
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }//*-
            /*除以上三点外，其他网签变更均按照以下基本审批流程：
            分行申请人—分行主管—区域经理—汇瀚网签组*/
            if (cbCNS2.Checked || cbCNS3.Checked || cbCNS5.Checked)
            {
                flowsadd += "3";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }
            if (flowsadd == "" && !rdbSpecialApply6.Checked)
            {
                flowsadd += "3";
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
                if (flows == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15277,4836";
                    //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴嘉瑜,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30555,4836";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈楚珊,梁婉华";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }
        }
        else
        {
            flowsadd = "A";
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "1,2,3,4,5,6,7,8,9,10");
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

            string[] employnames;
            string email;
            string msnBody;
            string signEmployeeName = EmployeeName;
            DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeNS_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ChangeNS_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.ToLowerInvariant().IndexOf("/apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl + "?MainID="+MainID;
            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
            //通知网签组
            //employname = "吴嘉瑜,梁婉华";
            employname = "陈楚珊,梁婉华";
            employnames = employname.Split(',');
            for (int i = 0; i < employnames.Length; i++)
            {
                msnBody = "您好，" + employnames[i] + "：有一份编号为" + serialNumber + "的" + documentName + "需要您编辑审批流程，若流程无误则无需重新编辑。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>" + "<br /><br />操作方法：打开申请表后，点击表最下面的“增加审批环节”链接即可编辑相关的审批流程。";
                email = employnames[i];
                Common.SendMessageEX(false, email, "请编辑审批流程", msnBody + msnBody, msnBody);
            }
        }
    }
    #endregion

    protected void ddlPayWay_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*B、当同时选择【（1）自行取网签合同原件办理房管局递件手续；付款方式：按揭】时，
        系统弹出提醒框：“请使用《特殊个案申请表》进行申请或联系汇瀚经办人进行申请！（已不能再做下一步操作）”*/
        if (ddlPayWay.SelectedValue == "按揭")
        {
            ddlPayWay.SelectedValue = "请选择";
            RunJS("alert('请使用《特殊个案申请表》进行申请或联系汇瀚经办人进行申请！');");
        }
    }

    #region 汇瀚网签组的人添加区域总监和区域负责人
    //protected void addflow_Click(object sender, EventArgs e)
    //{
    //    T_OfficeAutomation_Flow flows;
    //    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
    //    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
    //    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

    //    string departmentid = "";
    //    DataSet dsgetempid = da_Employee_Inherit.GetEmployeeInfoByUnitName(txtDepartment.Text);
    //    try
    //    {
    //        departmentid = dsgetempid.Tables[0].Rows[0]["UnitID"].ToString();
    //    }
    //    catch
    //    {
    //        departmentid= "";
    //    }

    //    //string units = "", unitids = "", dpm = "";
    //    wsFinance.Service wsf = new wsFinance.Service();
    //    System.Data.DataSet ds = null;
    //    if (!string.IsNullOrEmpty(departmentid))
    //    {
    //        ds = wsf.GetHRStructure(departmentid, DateTime.Now.ToString("yyyy-MM-dd"));
    //    }

    //    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
    //    {
    //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
    //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

    //        var units = ds.Tables[0].Rows[0]["HRStructure_Unit"].ToString().Split('/');
    //        var unitids = ds.Tables[0].Rows[0]["HRStructure_UnitID"].ToString().Split('/');
    //        var dpm = ds.Tables[0].Rows[0]["Role_DescInECOA"].ToString().Split('/');

    //        if (Array.IndexOf(dpm, "区域负责人") != -1)
    //        {
    //            if (Array.IndexOf(dpm, "区域总监") != -1)
    //            {
    //                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
    //                if (flows == null)
    //                {
    //                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
    //                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = unitids[1];
    //                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = units[1];
    //                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 4;
    //                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
    //                }
    //            }

    //            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 5);
    //            if (flows == null)
    //            {
    //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
    //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = unitids[0];
    //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = units[0];
    //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;
    //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
    //            }

    //        }
    //        else
    //        {
    //            if (Array.IndexOf(dpm, "区域总监") != -1)
    //            {
    //                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
    //                if (flows == null)
    //                {
    //                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
    //                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = unitids[0];
    //                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = units[0];
    //                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 4;
    //                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
    //                }
    //            }
    //        }

    //        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");

    //    }
    //    else 
    //    {
    //        RunJS("window.location='" + Page.Request.Url + "'");
    //    }

    //}
    #endregion

    protected void btnsaveflow_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);

        DA_OfficeAutomation_Document_ChangeNS_Inherit changens_Inherits = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
        DataSet ds = changens_Inherits.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        //string apply = "吴嘉瑜";
        string apply = "陈楚珊";
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ChangeNS_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;

        if (flowState=="1") 
        {
            RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=网签变更、特殊申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontentaddflow.Value + "&flga=1" + "&deleteidxs=1|2|3|4|5|6|10" + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
            RunJS("alert('所有的修改已保存。');window.location='" + Page.Request.Url + "';");
        }
        else if (flowState == "2")
        {
            RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=网签变更、特殊申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontentaddflow.Value + "&flga=1" + "&deleteidxs=1|2|3|4|5|6|10" + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
            RunJS("alert('所有的修改已保存。');window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "';");
        }
    }

    public void insertGeneralApplyDetail()
    {
        if (hdLogisticsFlow.Value == "")
            return;
        T_OfficeAutomation_Document_GeneralApply_Detail t_OfficeAutomation_Document_GeneralApply_Detail;
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        DA_OfficeAutomation_Document_ChangeNS_Inherit da_OfficeAutomation_Document_ChangeNS_Inherit = new DA_OfficeAutomation_Document_ChangeNS_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ChangeNS_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ChangeNS_ID"].ToString(); //在不同的表要注意修改

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
            {
                da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Insert(t_OfficeAutomation_Document_GeneralApply_Detail);
            }

        }
    }
}