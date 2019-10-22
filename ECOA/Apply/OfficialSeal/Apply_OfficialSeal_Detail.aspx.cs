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

using System.Collections;

using System.Diagnostics; //M_PDF
using System.Web;

public partial class Apply_OfficialSeal_Apply_OfficialSeal_Detail : BasePage
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
    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();";
    public string flowsl = "0";

    public DA_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit da_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit();
    public DataSet dst = new DataSet();
	//ds = da_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit.SelectFileSpecies();
    public DataRow drt;
    //public bool flgM = false;

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
                if (Session["FLG_ReWrite37"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite37"] = null;
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
        SbJs.Append("$(\"#trCcess\").hide();");
        SbJs.Append("$(\"#summaryLeft\").show();$(\"#summaryRight\").show();");
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
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
        DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit();

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
        ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_OfficialSeal_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_OfficialSeal_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
        flowsl = Server.UrlEncode(dr["OfficeAutomation_Document_OfficialSeal_Department"].ToString());
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_OfficialSeal_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        if (dr["OfficeAutomation_Document_OfficialSeal_Species"].ToString() == "True")
            rdbSpecies1.Checked = true;
        else
        {
            rdbSpecies2.Checked = true;
            txtAnotherSeal.Text = dr["OfficeAutomation_Document_OfficialSeal_AnotherSeal"].ToString();
        }
        txtAnotherFile.Text = dr["OfficeAutomation_Document_OfficialSeal_AnotherFile"].ToString();
        if (dr["OfficeAutomation_Document_OfficialSeal_FileSpecies"].ToString() == "1")
        {
            rdbFileSpecies2.Checked = true;
            
        }
        else if (dr["OfficeAutomation_Document_OfficialSeal_FileSpecies"].ToString() == "2")
        {
            rdbFileSpecies3.Checked = true;
        }
        //else if (dr["OfficeAutomation_Document_OfficialSeal_FileSpecies"].ToString() == "3")
        //{
        //    rdbFileSpecies4.Checked = true;
        //    txtAnotherFile.Text = dr["OfficeAutomation_Document_OfficialSeal_AnotherFile"].ToString();
        //}
        else
            rdbFileSpecies1.Checked = true;
        txtFileCount.Text = dr["OfficeAutomation_Document_OfficialSeal_FileCount"].ToString();
        try
        {
            txtRecyclingData.Text = DateTime.Parse(dr["OfficeAutomation_Document_OfficialSeal_RecyclingData"].ToString()).ToString("yyyy-MM-dd");
        }
        catch
        {
            txtRecyclingData.Text = dr["OfficeAutomation_Document_OfficialSeal_RecyclingData"].ToString();
        }
        txtSureDepartment.Text = dr["OfficeAutomation_Document_OfficialSeal_SureDepartment"].ToString();
        txtSureMenber.Text = dr["OfficeAutomation_Document_OfficialSeal_SureMenber"].ToString();
        try
        {
            txtSureData.Text = DateTime.Parse(dr["OfficeAutomation_Document_OfficialSeal_SureData"].ToString()).ToString("yyyy-MM-dd");
        }
        catch
        {
            txtSureData.Text = dr["OfficeAutomation_Document_OfficialSeal_SureData"].ToString();
        }
        txtBranchPhone.Text = dr["OfficeAutomation_Document_OfficialSeal_BranchPhone"].ToString();
        txtSurePhone.Text = dr["OfficeAutomation_Document_OfficialSeal_SurePhone"].ToString();
        txtSureCommissioner.Text = dr["OfficeAutomation_Document_OfficialSeal_SureCommissioner"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        ds = da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit.SelectByID(ID);
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

                SbJs.Append("$('#selTransFile" + i + "').val('" + dr["OfficeAutomation_Document_OfficialSeal_Detail_TransFile"] + "');");
                SbJs.Append("$('#selTransFile" + i + "').find(\"option:selected\").text('" + dr["OfficeAutomation_Document_OfficialSeal_Detail_TransFile"] + "');");
                SbJs.Append("$('#txtFileName" + i + "').val('" + dr["OfficeAutomation_Document_OfficialSeal_Detail_FileName"] + "');");
                try
                {
                    SbJs.Append("$('#txtAgentBeginData" + i + "').val('" + DateTime.Parse(dr["OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData"].ToString()).ToString("yyyy-MM-dd") + "');");
                }
                catch
                {
                    SbJs.Append("$('#txtAgentBeginData" + i + "').val('" + dr["OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData"] + "');");
                }
                try
                {
                    SbJs.Append("$('#txtAgentEndData" + i + "').val('" + DateTime.Parse(dr["OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData"].ToString()).ToString("yyyy-MM-dd") + "');");
                }
                catch
                {
                    SbJs.Append("$('#txtAgentEndData" + i + "').val('" + dr["OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData"] + "');");
                }
                SbJs.Append("$('#txtBN" + i + "').val('" + dr["OfficeAutomation_Document_OfficialSeal_Detail_BN"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");
                SbJs.Append("$('#txtCompany" + i + "').val('" + dr["OfficeAutomation_Document_OfficialSeal_Detail_Company"] + "');");
                SbJs.Append("$('#txtUse" + i + "').val('" + dr["OfficeAutomation_Document_OfficialSeal_Detail_Use"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");
            }
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
        T_OfficeAutomation_Flow flows;
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
        if (isApplicant)
        {
            try
            {
                //if (flowState == "3" || flows.OfficeAutomation_Flow_Audit == true) //法律部的人开始审批
                //    SbJs.Append("$(\"#btnUpload\").hide();");

                //2016-12-19修改 注释掉法律部人审批之后不能上传附件功能
                if (flowState == "3") //法律部的人开始审批
                    SbJs.Append("$(\"#btnUpload\").hide();");

                //else
                //    //SbJs.Append("$(\"#btnUpload\").show();");
            }
            catch
            {
                //SbJs.Append("$(\"#btnUpload\").show();");
            }
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                SbJs.Append(ApplyDisplayPart);
                try
                {
                    if (Request.QueryString["htmltopdf"] != "Yes")
                        SbJs.Append("$(\"#summaryLeft\").show();$(\"#summaryRight\").show();");
                }
                catch
                {
                    SbJs.Append("$(\"#summaryLeft\").show();$(\"#summaryRight\").show();");
                }
            }
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 106);
            if (flowState == "2" && flows == null) //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }
        }

        #endregion

        #region 登录人为特定的人时，相应的编辑按钮开启。

        if (EmployeeName == "李小清" || EmployeeName == "顾思娜")
        {
            GetAllDepartment();
            btnSave.Visible = true;
            SbJs.Append(ApplyDisplayPart);
        }
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeID(EmployeeID);
      //  string ss = ds.Tables[0].Rows[0]["UnitName"].ToString();
        if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
        {
            if (EmployeeName == "朱晓晴"
               || EmployeeName == "倪秀珊"
               || EmployeeName == "彭嘉敏A"
               || EmployeeName == "李蓬桂"
               || EmployeeName == "陈宇平"
               || EmployeeName == "何恺鹏"
               || EmployeeName == "苏秉星"
               || EmployeeName == "潘焕心"
               || EmployeeName == "欧凤霞"
               || ds.Tables[0].Rows[0]["UnitName"].ToString() == "项目部秘书组" || txtDepartment.Text.Contains("项目") 
               || txtDepartment.Text.Contains("事业") || txtDepartment.Text.Contains("拓展") 
               || txtDepartment.Text.Contains("顾问") || txtDepartment.Text.Contains("销售")
               || txtDepartment.Text.Contains("商业"))
            {
                SbJs.Append("$(\"#btnUpload\").show();");
            }
        }
       

        //try
        //{
        //    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
        //    if (EmployeeName == "潘海燕" && flows.OfficeAutomation_Flow_Audit == false)
        //    {
        //        SbJs.Append("$(\"#addDepartment\").show();");
        //    }
        //}
        //catch
        //{
        //}

        if (EmployeeID == "17642" || EmployeeID == "34498")
            SbJs.Append("$(\"#trCcess\").show();");

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
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();$(\"#trCcess\").hide();");
                SbJs.Append("$(\"#summaryLeft\").show();$(\"#summaryRight\").show();");
                SbJs.Append("$(\"[id*=selTransFile]\").val('');");
                SbJs.Append("$(\"[id*=selTransFile]\").find(\"option:selected\").text('请选择');");
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
            if (isApplicant)
                btnReWrite.Visible = true;
        }
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);
        if (dsAttach.Tables[0].Rows.Count != 0)
        {
            Scr1.Visible = true;
        }
        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        //ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        //DataRowCollection drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有法律部的审批环节

        //T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
        if (flows != null)
            SbJs.Append("$('#trM30').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        if (flows != null)
            SbJs.Append("$('#trM3').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
        if (flows != null)
            SbJs.Append("$('#trM4').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 13);
        if (flows != null)
            SbJs.Append("$('#trM13').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 14);
        if (flows != null)
            SbJs.Append("$('#trM14').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
        if (flows != null)
            SbJs.Append("$('#trM15').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
        if (flows != null)
            SbJs.Append("$('#trM16').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
        if (flows != null)
            SbJs.Append("$('#trM17').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 18);
        if (flows != null)
            SbJs.Append("$('#trM18').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
        if (flows != null)
            SbJs.Append("$('#trM11').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 12);
        if (flows != null)
            SbJs.Append("$('#trM12').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 19);
        if (flows != null)
            SbJs.Append("$('#trM19').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
        if (flows != null)
            SbJs.Append("$('#trM20').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
        if (flows != null)
            SbJs.Append("$('#trM25').show();");
        
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 29);
        if (flows != null)
            SbJs.Append("$('#trM29_1').show();$('#trM29').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 26);
        if (flows != null)
            SbJs.Append("$('#trM29_1').hide();$('#trM26').show();$('#trM29').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 27);
        if (flows != null)
            SbJs.Append("$('#trM29_1').hide();$('#trM27').show();$('#trM28').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 28);
        if (flows != null)
            SbJs.Append("$('#trM29_1').hide();$('#trM28').show();$('#trM27').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
        if (flows != null)
            SbJs.Append("$('#trM100').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 106);
        if (flows != null)
            SbJs.Append("$('#trM102').show();$('#trM106').show();");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 105);
        if (flows != null)
            SbJs.Append("$('#trM105').show();");
        
        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                SbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                if (curemp.Contains(EmployeeName))
                {
                    switch (curidx)
                    {
                        case "100":
                            SbJs.Append("$(\"#sp100\").show();");
                            ckbAddIDx100.Visible = true;
                            break;
                        case "20":
                            SbJs.Append("$(\"#sp20\").show();");
                            break;
                        case "30":
                            SbJs.Append("$(\"#addDepartment\").show();");
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

            //20160620
            if (EmployeeID == "1185" && EmployeeName == "梁文英")
            {
                if (curidx == "30")
                {
                    SbJs.Append("$(\"#addDepartment\").show();");
                }
            }

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

            #endregion
        }

        ////如果有法律部的审批环节，增加部门负责人的签名
        //if (flag3)
        //    SbJs.Append("$('#trManager102').show();$('#trManager106').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 106);
        if (flowState == "2" && applicant == EmployeeName && !tpdf && flows == null) //20141215：M_AlterC
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
            btnEditFlow2.Visible = false;
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



        //T_OfficeAutomation_Flow flows;
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 200);
        ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID);
        if (flows != null || ds.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "8")
        {
            lbSee.Visible = true;
            SbJs.Append("$(\"#trCcess\").show();");
            if (EmployeeID == "17642" || EmployeeID == "34498")
            {
                btnCantUse.Visible = false;
                btnSureUse.Visible = true;
            }
        }
        else
        {
            lbSee.Visible = false;
            if (EmployeeID == "17642" || EmployeeID == "34498")
            {
                btnCantUse.Visible = true;
                btnSureUse.Visible = false;
            }
        }


        #endregion

        string kwg = "微信认证、区域广告位合同、广日报纸广告合同、网络端口合同、参加中介协会会议等提交资料";
        bool flge = false;
        ds = da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit.SelectByID(ID); //A_Marking 20150909
        for (int n = 0; n < detailCount; n++)
        {
            dr = ds.Tables[0].Rows[n];
            if (kwg.Contains(dr["OfficeAutomation_Document_OfficialSeal_Detail_TransFile"].ToString()))
                flge = true;
        }

        if ((txtDepartment.Text == "市场部" 
            || txtDepartment.Text == "网络营销部"
            || txtDepartment.Text == "企业传讯部"
            || txtDepartment.Text == "网站事业部"
            ) && flge
            )
        {
            //2016-11-09 市场部、网络营销部、企业传讯部、网站事业部的同事上申请的话他们的主管无法审批 故作备注
            //SbJs.Append("$('#trManager1').hide();$('#trManager2').hide();$('#btnEditFlow').hide();");
            btnEditFlow2.Visible = false;
        }

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
        //DataSet dsApplyDetail = new DataSet();
        //DataSet dsApplyType = new DataSet();

        //DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
        //dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(1);
        //DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
        //dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();


        DA_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit da_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit.SelectFileSpecies();
        DataRow dr;
        //ID = dr["OfficeAutomation_Document_OfficialSeal_ID"].ToString();
        int detailCount = ds.Tables[0].Rows.Count;
        string[] ems;


        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id=\"trDetail" + i + "\">");
            SbHtml.Append("<td class=\"tl PL10\" style=\"line-height: 30px; padding: 10px;\" colspan=\"4\">");
            SbHtml.Append("<span style=\"vertical-align: top;margin-top: 10px;\">项目（楼盘）名称/文件名称：</span><textarea id=\"txtBN" + i + "\" rows=\"3\" style=\"width:420px;\"/></textarea><br/>");
            SbHtml.Append("对方公司名称：<input type=\"text\" id=\"txtCompany" + i + "\" style=\"width:493px\"/><br/>");

            SbHtml.Append("事务文件：<select id=\"selTransFile" + i + "\" style=\"width:280px\"><option>请选择</option>");
            for (int n2 = 0; n2 < detailCount; n2++)
            {
                dr = ds.Tables[0].Rows[n2];
                SbHtml.Append("<optgroup label=\"" + dr["t_OfficeAutomation_Document_OfficialSeal_FileSpecies_Name"] + "\">");
                ems = dr["t_OfficeAutomation_Document_OfficialSeal_FileSpecies_Kind"].ToString().Split('、');
                for (int i2 = 0; i2 < ems.Length; i2++)
                    SbHtml.Append("<option>" + ems[i2] + "</option>");
                SbHtml.Append("</optgroup>");
            }
            SbHtml.Append("</select>");

            SbHtml.Append("代理期(可选)：<input type=\"text\" id=\"txtAgentBeginData" + i + "\" style=\"width:70px\">～<input type=\"text\" id=\"txtAgentEndData" + i + "\" style=\"width:70px\"/><br />");
            SbHtml.Append("物业地址(可选)：<input type=\"text\" id=\"txtFileName" + i + "\" style=\"width:485px\"/><br/>");
            SbHtml.Append("<span style=\"vertical-align: top;margin-top: 20px;\">用　途：</span><textarea id=\"txtUse" + i + "\" rows=\"3\" style=\"width: 528px;margin-top: 8px; overflow: auto;\"></textarea><br />");
            SbHtml.Append("</td>");
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
        T_OfficeAutomation_Document_OfficialSeal t_OfficeAutomation_Document_OfficialSeal = new T_OfficeAutomation_Document_OfficialSeal();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
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
            //if (MainID == "")
            if (IsNewApply)
            {
                #region 新建
                //20170608 注释掉，如果不注释掉，弹出请正确选择发文部门的提示后再点击保存会走到修改编辑
               // IsNewApply = false;
                DataSet ds = new DataSet();

                string[] sHRTree = null;
                try
                {
                    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                }
                catch
                {
                    Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                    return;
                }

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "OfficialSeal" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 31; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_Apply = EmployeeName;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_ApplyID = txtApplyID.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_Department = txtDepartment.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_Species = rdbSpecies1.Checked ? true : false;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_AnotherSeal = txtAnotherSeal.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_FileSpecies = rdbFileSpecies1.Checked ? 0 : rdbFileSpecies2.Checked ? 1 : 2;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_AnotherFile = txtAnotherFile.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_FileCount = txtFileCount.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_RecyclingData = txtRecyclingData.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureDepartment = txtSureDepartment.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureMenber = txtSureMenber.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureData = txtSureData.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_BranchPhone = txtBranchPhone.Text;
                t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SurePhone = txtSurePhone.Text;
                if (EmployeeName == "李小清" || EmployeeName == "顾思娜")
                {
                    t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureCommissioner = txtSureCommissioner.Text;
                }
                else
                {
                    t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureCommissioner = "";
                }

                string detail = InsertOfficialSealDetail(t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_ID);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = (string.IsNullOrEmpty(t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureCommissioner) ? "" : "(√★)") + detail + (string.IsNullOrEmpty(t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureCommissioner) ? "" : txtSureData.Text);
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_OfficialSeal_Inherit.Insert(t_OfficeAutomation_Document_OfficialSeal);//插入申请表

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                #region 根据默认流程表中的固定环节添加流程

                string[] DepartmentN; //M_Lo：20150211
                DepartmentN = ("财务部,资讯科技部,人力资源部,行政部,外联部,法律部").Split(',');

                OfficialSealControl.NewCreateFlow(ViewState["TransFiles"].ToString(), MainID);
                //20170531添加  当选择事务文件为营业部自主招聘类时根据申请部门插入不同的hr审批人
                if (ViewState["TransFiles"].ToString().Contains("营业部自主招聘类")) 
                {
                    InsertHrFlow(hdDepartmentID.Value, t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString());
                }
                
                if (!((IList)DepartmentN).Contains(txtDepartment.Text))
                {
                }
                else if (txtDepartment.Text == "财务部")
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11,12,18,20,25");
                }
                else if (txtDepartment.Text == "资讯科技部")
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "3");
                }
                #region 2016/10/27 52100 由于人力资源部要求最后审批都要郑纯宁,所以注释此方法
                //else if (txtDepartment.Text == "人力资源部")
                //{
                //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "15,16");
                //}
                #endregion
                else if (txtDepartment.Text == "行政部")
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "4");
                }
                else if (txtDepartment.Text == "外联部")
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "30");
                }
                //else if (txtDepartment.Text == "市场部" || txtDepartment.Text == "网络营销部")
                //{
                //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "1,2");
                //}
                else if (txtDepartment.Text == "法律部")
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "100");
                }

                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 35, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeID(EmployeeID);

                string kw = "微信认证|、区域广告位合同|、广日报纸广告合同|、网络端口合同|、参加中介协会会议等提交资料|";
                string[] ems;
                bool flgt = false;
                ems = kw.Split('、');
                for (int i = 0; i < ems.Length; i++)
                {
                    if (ViewState["TransFiles"].ToString().Contains(ems[i]))
                    {
                        flgt = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitName"].ToString() == "项目部秘书组" || txtDepartment.Text.Contains("项目") || txtDepartment.Text.Contains("事业") || txtDepartment.Text.Contains("拓展") || txtDepartment.Text.Contains("顾问"))
                    RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_OfficialSeal_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                //20161009 企业传讯部同事要求能编辑流程，跟李小清确认后确定解放这四个部门的流程编辑权限
                #region 20161009 企业传讯部同事要求能编辑流程，跟李小清确认后确定解放这四个部门的流程编辑权限
                /*else if ((txtDepartment.Text == "市场部" 
                    || txtDepartment.Text == "网络营销部"
                    || txtDepartment.Text == "企业传讯部"
                    || txtDepartment.Text == "网站事业部"
                    )&& flgt
                    ) //A_Marking 20150909
                {
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
                    string msnBody = "",ap = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                    string[] employnames = ap.Split(',');
                    for (int i = 0; i < employnames.Length; i++)
                    {
                        msnBody = "您好，" + employnames[i] + "：您有" + txtDepartment.Text + "，编号为" + t_OfficeAutomation_Main.OfficeAutomation_SerialNumber.Substring(0,30) + "的公章使用申请表需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        Common.SendMessageEX(false, "公章使用申请表", employnames[i], "请审批", msnBody, msnBody);
                    }
                    RunJS("alert('保存成功。');window.location='/Apply/Apply_Search.aspx'; ");
                }*/
                #endregion
                else
                    RunJS("var win=window.showModalDialog(\"Apply_OfficialSeal_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID);
                    string departmentid = hdDepartmentID.Value;

                    string departmentName = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
                    //页面上的部门名称
                    string deptname = txtDepartment.Text;

                    if (string.IsNullOrEmpty(departmentid))
                    {
                        if (deptname != departmentName)
                        {
                            Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                            return;
                        }

                    }

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
            RunJS("alert(\"保存失败，" + ex.Message + "\");history.go(-1);");
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
            Common.AddLog(EmployeeID, EmployeeName, 35, new Guid(MainID), 8);
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
        if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "8")
        {
            RunJS("alert('该表已过期，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
            return;
        }
        DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
        DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_OfficialSeal_ID"].ToString(); 
        
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

                T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                string sFlosEmployeeID = string.Empty;//负责人
                string sFlosEmployeeName = string.Empty;//负责人
                for (int i = 0; i < drc.Count; i++)
                {
                    if ("2".Equals(drc[i]["OfficeAutomation_Flow_IDx"].ToString()))
                    {
                        sFlosEmployeeID = drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString();//负责人
                        sFlosEmployeeName = drc[i]["OfficeAutomation_Flow_Employee"].ToString();//负责人
                    }
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

                if (flowIDx == "100")
                {
                    if (ckbAddIDx100.Checked)//增加审批环节是否勾选，如果是则添加部门负责人签名
                    {
                        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        if (txtDepartment.Text == "市场部" || txtDepartment.Text == "网络营销部")
                        {
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "4229";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李粤湘";
                        }
                        else
                        {
                            //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = drc[1]["OfficeAutomation_Flow_EmployeeID"].ToString();
                            //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = drc[1]["OfficeAutomation_Flow_Employee"].ToString();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sFlosEmployeeID;
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sFlosEmployeeName;
                        }
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 106;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        da_OfficeAutomation_Main_Inherit.SetNullAuditorWhenFlow(MainID); //清空Main表中的最终审批人记录
                    }
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                //如果为第15、11或100 13步流程则为其一审核即可通过，其他为同时审核。
                bool isSignSuccess = (flowIDx == "15" || flowIDx == "11" || flowIDx == "100" || flowIDx == "13" || flowIDx == "16") ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_OfficialSeal_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_OfficialSeal_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_OfficialSeal_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>分行电话：" + drRow["OfficeAutomation_Document_OfficialSeal_BranchPhone"]);
                    sbMailBody.Append("<br/>编号：" + drRow["OfficeAutomation_Document_OfficialSeal_ApplyID"]);
                    sbMailBody.Append("<br/>申请盖章部门：" + drRow["OfficeAutomation_Document_OfficialSeal_Department"]);

                    sbMailBody.Append("<br/>申请盖章文件的份数：" + drRow["OfficeAutomation_Document_OfficialSeal_FileCount"]);
                    sbMailBody.Append("<br/>预计回收日期：" + drRow["OfficeAutomation_Document_OfficialSeal_RecyclingData"]);
                    sbMailBody.Append("<br/>确认盖章部门：" + drRow["OfficeAutomation_Document_OfficialSeal_SureDepartment"]);
                    sbMailBody.Append("<br/>确认盖章人员：" + drRow["OfficeAutomation_Document_OfficialSeal_SureMenber"]);
                    sbMailBody.Append("<br/>确认人电话：" + drRow["OfficeAutomation_Document_OfficialSeal_SurePhone"]);
                    sbMailBody.Append("<br/>确认盖章日期：" + drRow["OfficeAutomation_Document_OfficialSeal_SureData"]);
                    sbMailBody.Append("<br/>盖章专责人员：" + drRow["OfficeAutomation_Document_OfficialSeal_SureCommissioner"]);
                    sbMailBody.Append("<br/><br/>");

                    sbMailBody.Append("<br/>其它坏账详细情况：");

                    ds = da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>事务文件：" + dr["OfficeAutomation_Document_OfficialSeal_Detail_TransFile"]);
                        sbMailBody.Append("<br/>文件名称：" + dr["OfficeAutomation_Document_OfficialSeal_Detail_FileName"]);
                        sbMailBody.Append("<br/>代理期开始时间：" + dr["OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData"]);
                        sbMailBody.Append("<br/>代理期结束时间：" + dr["OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData"]);
                        sbMailBody.Append("<br/>项目（楼盘）名称/成交编号：" + dr["OfficeAutomation_Document_OfficialSeal_Detail_BN"]);
                        sbMailBody.Append("<br/>对方公司名称：" + dr["OfficeAutomation_Document_OfficialSeal_Detail_Company"]);
                        sbMailBody.Append("<br/>用途：" + dr["OfficeAutomation_Document_OfficialSeal_Detail_Use"]);
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
                                    if (employnames[i] == "黄轩明")
                                    {
                                        continue;
                                    }
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
                            employname = "顾思娜";
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
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody,MainID);
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
                RunJS("alert('审理失败！');window.location='" + Page.Request.Url + "'");
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
        //    DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_OfficialSeal_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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
        T_OfficeAutomation_Flow flows;
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
        string commType = e.CommandName;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
        switch (commType)
        {
            case "Del":
                try
                {
                    if (flowState == "3" || flows.OfficeAutomation_Flow_Audit == true) //法律部的人开始审批
                    {
                        RunJS("alert('因为法律部人员已审批完毕或审批流程已结束，所以附件不能删除！');history.go(-1);");
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

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_OfficialSeal t_OfficeAutomation_Document_OfficialSeal = new T_OfficeAutomation_Document_OfficialSeal();
        DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_ID"].ToString();

        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_ID = new Guid(ID);
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_Apply = EmployeeName;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_Species = rdbSpecies1.Checked ? true : false;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_AnotherSeal = txtAnotherSeal.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_FileSpecies = rdbFileSpecies1.Checked ? 0 : rdbFileSpecies2.Checked ? 1 :  2;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_AnotherFile = txtAnotherFile.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_FileCount = txtFileCount.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_RecyclingData = txtRecyclingData.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureDepartment = txtSureDepartment.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureMenber = txtSureMenber.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureData = txtSureData.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_BranchPhone = txtBranchPhone.Text;
        t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SurePhone = txtSurePhone.Text;
        if (EmployeeName == "李小清" || EmployeeName == "顾思娜")
            t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureCommissioner = txtSureCommissioner.Text;
        else
            t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureCommissioner = "";

        

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);

        DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit();
        da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit.Delete(ID);
        string detail = InsertOfficialSealDetail(new Guid(ID));

        string apply = "";
        string depname = txtDepartment.Text;
        //string summary = (string.IsNullOrEmpty(txtSureCommissioner.Text) ? "" : "(√★)") + detail + txtSureCommissioner.Text;
        string summary = (string.IsNullOrEmpty(t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureCommissioner) ? "" : "(√★)") + detail + (string.IsNullOrEmpty(t_OfficeAutomation_Document_OfficialSeal.OfficeAutomation_Document_OfficialSeal_SureCommissioner) ? "" : txtSureData.Text);
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_OfficialSeal_Inherit.Update(t_OfficeAutomation_Document_OfficialSeal);//修改申请表

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        if (flowState != "3" && EmployeeName != "李小清" && EmployeeName != "顾思娜")
        {
            string[] DepartmentN; //M_Lo：20150211
            DepartmentN = ("财务部,资讯科技部,人力资源部,行政部,外联部,法律部").Split(',');

            OfficialSealControl.NewCreateFlow(ViewState["TransFiles"].ToString(), MainID);
            //20170531添加  当选择事务文件为营业部自主招聘类时根据申请部门插入不同的hr审批人
            DA_Department_Inherit department_Inherit = new DA_Department_Inherit();
            if (ViewState["TransFiles"].ToString().Contains("营业部自主招聘类"))
            {
                string departmentName = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
                string departmentid = hdDepartmentID.Value;

                if (departmentid == "")
                {
                    departmentid = department_Inherit.GetDepartmentInfoByDeptName(departmentName).Tables[0].Rows[0]["dept_id"].ToString();
                }

                if (departmentid != "")
                {
                    InsertHrFlow(departmentid, MainID);
                }
            }
            
            if (!((IList)DepartmentN).Contains(txtDepartment.Text))
            {
            }
            else if (txtDepartment.Text == "财务部")
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11,12,18,20,25");
            }
            else if (txtDepartment.Text == "资讯科技部")
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "3");
            }
            else if (txtDepartment.Text == "人力资源部")
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "15,16");
            }
            else if (txtDepartment.Text == "行政部")
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "4");
            }
            else if (txtDepartment.Text == "外联部")
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "30");
            }
            //else if (txtDepartment.Text == "市场部" || txtDepartment.Text == "网络营销部")
            //{
            //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "1,2");
            //}
            else if (txtDepartment.Text == "法律部")
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "100");
            }
        }

        if (flowState != "3" && EmployeeName != "李小清" && EmployeeName != "顾思娜")
        {
            if (txtDepartment.Text == "事业四部")
                da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndIdxs(MainID, 2, "陈锵成", "0100");
            else if (txtDepartment.Text == "事业一部" || txtDepartment.Text == "事业二部" || txtDepartment.Text == "事业三部" || txtDepartment.Text == "事业十部")
                da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndIdxs(MainID, 2, "黄韬", "0004");
            else if (txtDepartment.Text == "拓展部" || txtDepartment.Text == "项目部")
                da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndIdxs(MainID, 2, "易伟锋", "2722");
            else if (txtDepartment.Text == "事业六部")
                da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndIdxs(MainID, 2, "易伟锋", "2722");
        }

        Common.AddLog(EmployeeID, EmployeeName, 35, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增公章使用申请明细表

    /// <summary>
    /// 新增公章使用申请表坏帐明细表
    /// </summary>
    /// <param name="gOfficialSealID"></param>
    private string InsertOfficialSealDetail(Guid gOfficialSealID)
    {
        if (hdDetail.Value == "")
            return "";

        T_OfficeAutomation_Document_OfficialSeal_Detail t_OfficeAutomation_Document_OfficialSeal_Detail;
        DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        string result = "";
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_OfficialSeal_Detail = new T_OfficeAutomation_Document_OfficialSeal_Detail();
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_MainID = gOfficialSealID;
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_TransFile = detail[0];
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_FileName = detail[1];
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData = detail[2];
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData = detail[3];
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_BN = detail[4];
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_Company = detail[5];
                t_OfficeAutomation_Document_OfficialSeal_Detail.OfficeAutomation_Document_OfficialSeal_Detail_Use = detail[6];
                result += detail[4] + "，";
                ViewState["TransFiles"] += detail[0] + "|";
                da_OfficeAutomation_Document_OfficialSeal_Detail_Inherit.Insert(t_OfficeAutomation_Document_OfficialSeal_Detail);
            }
            return result;
        }
        catch (Exception ee)
        {
            Alert(ee.Message);
            return "";
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
                if (dr["name"].ToString().Contains("网签"))
                {
                    string s = dr["name"].ToString();
                }
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
        Session["FLG_ReWrite37"] = "1";
        Response.Write("<script>window.open('Apply_OfficialSeal_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("公章使用申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }
    protected void lbnAddDepartment_Click(object sender, EventArgs e)
    {
        T_OfficeAutomation_Flow flows;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        if (!ckbLaw.Checked && !ckbFinancial.Checked && !cbHR.Checked)
        {
            RunJS("alert('请选择审批环节！');history.go(-1);");
        }
        if (ckbLaw.Checked)//增加审批环节是否勾选，如果是则添加部门负责人签名
        {
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 105);
            if (flows == null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
                if (flows != null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0067";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "潘海燕";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 105;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }
        }
        if (ckbFinancial.Checked)//增加审批环节是否勾选，如果是则添加部门负责人签名
        {
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545 ";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 20;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 105);
            if (flows == null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
                if (flows != null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0067";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "潘海燕";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 105;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }
        }
        if (cbHR.Checked)//增加审批环节是否勾选，如果是则添加部门负责人签名
        {
            lbtnAddHR_Click();
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 105);
            if (flows == null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
                if (flows != null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0067";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "潘海燕";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 105;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
            }
        }
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 105);
        if (flows != null)
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 30); //外联部法律部后面
        da_OfficeAutomation_Main_Inherit.SetNullAuditorWhenFlow(MainID); //清空Main表中的最终审批人记录
        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
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
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "8")
            {
                RunJS("alert('该表已过期，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
            {
                RunJS("alert('该表已审批完毕，不能再撤回审核了');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Flow flows;
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
            try
            {
                if (flows.OfficeAutomation_Flow_AuditorID != "" && flows.OfficeAutomation_Flow_AuditorID != EmployeeID)
                {
                    RunJS("alert('该表已经法律部审批，暂停撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
                    return;
                }
            }
            catch
            {
            }
            //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

            int i = 0;
            int.TryParse(hdCancelSign.Value, out i);
            //T_OfficeAutomation_Flow flows;
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, i);

            string namesA = flows.OfficeAutomation_Flow_Auditor, idsA = flows.OfficeAutomation_Flow_AuditorID;
            string[] employnames;
            string email;
            string msnBody;
            string signEmployeeName = EmployeeName;
            DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
            DataSet ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
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
                //da_OfficeAutomation_Main_Inherit.trManager1UpdateFlowForCancel(MainID);
                da_OfficeAutomation_Flow_Inherit.DDeleteFlows(MainID);
                if (i < 101)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "106");
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
            DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
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
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "8")
            {
                RunJS("alert('该表已过期，不能再修改了');window.location.href='" + Page.Request.Url + "';");
                return;
            }

            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID);
            string departmentid = hdDepartmentID.Value;

            string departmentName = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
            //页面上的部门名称
            string deptname = txtDepartment.Text;

            if (string.IsNullOrEmpty(departmentid))
            {
                if (deptname != departmentName)
                {
                    Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                    return;
                }

            }

            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

            string[] employnames;
            string email;
            string msnBody;
            
            ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
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
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "106");
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
            DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
            DataSet ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "106");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 2); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_OfficialSeal_Flow.aspx?MainID=" + MainID + "&dpm=" + Server.UrlEncode(txtDepartment.Text) + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    protected void btnCantUse_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        da_OfficeAutomation_Flow_Inherit.DDeleteFlows(MainID);
        //da_OfficeAutomation_Flow_Inherit.UpdateTrueByMainID(MainID);
        da_OfficeAutomation_Flow_Inherit.InsertFlowsHaventReview(MainID);
        DataSet ds = new DataSet();
        string[] employnames;
        string email;
        string msnBody;
        ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID);
        string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
        string employname;
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
        ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

        //string apply = Request.QueryString["apply"];
        //apply = apply.Remove(apply.Length - 1);
        //string applyUrl = Request.QueryString["href"];
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

        //通知申请人
        msnBody = "您好" + apply + "，您有一份编号为" + serialNumber + "的" + documentName + "已超期，需重新上申请。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        Common.SendMessageEX(false, apply, documentName + "申请超期", msnBody, msnBody);

        //通知已同意的全部人员
        ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
            employnames = employname.Split(',');
            for (int i2 = 0; i2 < employnames.Length; i2++)
            {
                msnBody = "您好" + employnames[i2] + "，您审理过的编号为" + serialNumber + "的" + documentName + "已超期，该申请作废。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                email = employnames[i2]; if (email != "")
                    Common.SendMessageEX(false, email, "您审理过的" + documentName + "已超期", msnBody, msnBody);
            }
        }
        da_OfficeAutomation_Flow_Inherit.DeleteHaventA(MainID);

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "法律部";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 200;

        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, EmployeeID, "法律部", EmployeeName + "：申请超期", "200", "0");
        //da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        RunJS("alert('操作成功，稍后系统会通知相关的人员。');window.location.href='" + Page.Request.Url + "';");
    }

    protected void btnSureUse_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 200);
            da_OfficeAutomation_Flow_Inherit.InsertDeleteFlows(MainID);
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);

            string mainid = MainID;
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

            DataSet ds = new DataSet();
            string[] employnames;
            string email;
            string msnBody;
            ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string employname;
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
            DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
            ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

            //通知下一步需要审批的人员
            try
            {
                employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
                employnames = employname.Split(',');
                for (int i = 0; i < employnames.Length; i++)
                {
                    email = employnames[i];
                    msnBody = "您好" + employnames[i] + "，由于" + EmployeeName + "确认继续使用编号为：" + serialNumber + "的" + documentName + "，所以现在需要您继续审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    Common.SendMessageEX(true, documentName, email, documentName + "需要您继续审理", msnBody, msnBody,MainID);
                }
            }
            catch
            {
            }
            //通知申请人
            msnBody = "您好" + apply + "，" + EmployeeName + "确认继续使用您申请的编号为" + serialNumber + "的" + documentName + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
            Common.SendMessageEX(false, apply, EmployeeName + "确认继续使用" + documentName, msnBody, msnBody);

            //通知已同意的全部人员
            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlows(mainid);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employname = dr["OfficeAutomation_DeletedFlow_Employee"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    msnBody = "您好" + employnames[i2] + "，" + EmployeeName + "确认继续使用您审理过的编号为" + serialNumber + "的" + documentName + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    email = employnames[i2]; if (email != "")
                        Common.SendMessageEX(false, email, EmployeeName + "确认继续使用" + documentName, msnBody, msnBody);
                }
            }

            da_OfficeAutomation_Flow_Inherit.DDeleteFlows(mainid);
            t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(mainid);
            t_OfficeAutomation_Main.OfficeAutomation_Main_WillDelete = false;
            da_OfficeAutomation_Main_Inherit.UpdateWillDelete(t_OfficeAutomation_Main); //设0删除标志
            RunJS("alert('操作成功。');window.location.href='" + Page.Request.Url + "';");
        }
        catch (Exception ex)
        {
            RunJS("alert('操作失败，错误原因：" + ex.Message + "');window.location.href='" + Page.Request.Url + "';");
        }
    }
    protected void lbOCDeptm_Click(object sender, EventArgs e)
    {
        try
        {
            T_OfficeAutomation_Flow flows;
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0067";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "潘海燕";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 30;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                string mainid = MainID;
                T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

                DataSet ds = new DataSet();
                string[] employnames;
                string email;
                string msnBody;
                ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                string employname;
                string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
                ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
                string applyUrl = Page.Request.Url.ToString();
                applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

                applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                //通知下一步需要审批的人员
                try
                {
                    employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
                    employnames = employname.Split(',');
                    for (int i = 0; i < employnames.Length; i++)
                    {
                        email = employnames[i];
                        msnBody = "您好，" + employnames[i] + "：您有" + txtDepartment.Text
                            + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        Common.SendMessageEX(true, documentName, email, "请审理", msnBody, msnBody,MainID);
                    }
                }
                catch
                {
                }
                
            }
            RunJS("alert('添加审批流程成功。');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception ee)
        {
            RunJS("alert('添加失败，" + ee.Message + "');window.location='" + Page.Request.Url + "'");
        }
    }
    protected void lbCoculate_Click(object sender, EventArgs e)
    {
        try
        {
            T_OfficeAutomation_Flow flows;
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "16945,20208,61275,41960,43781,64185";
                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "胡雅丝,陈婉娜,冯琰,官东升,钟惠贤,刘韵";

                //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "20208,61275,41960,43781,64185";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈婉娜,冯琰,官东升,钟惠贤,刘韵";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                string mainid = MainID;
                T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
                DataSet ds = new DataSet();
                string[] employnames;
                string email;
                string msnBody;
                ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                string employname;
                string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
                ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
                string applyUrl = Page.Request.Url.ToString();
                applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

                applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                //通知下一步需要审批的人员
                try
                {
                    employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
                    employnames = employname.Split(',');
                    for (int i = 0; i < employnames.Length; i++)
                    {
                        email = employnames[i];
                        msnBody = "您好，" + employnames[i] + "：您有" + txtDepartment.Text
                            + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        Common.SendMessageEX(true, documentName, email, "请审理", msnBody, msnBody,MainID);
                    }
                }
                catch
                {
                }
                
            }
            RunJS("alert('添加审批流程成功。');window.location='" + Page.Request.Url + "'");
        }
        catch(Exception ee)
        {
            RunJS("alert('添加失败，" + ee.Message + "');window.location='" + Page.Request.Url + "'");
        }
    }
    protected void lbtnAddFinancial_Click(object sender, EventArgs e)
    {
        try
        {
            T_OfficeAutomation_Flow flows;
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 20;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                string mainid = MainID;
                T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

                DataSet ds = new DataSet();
                string[] employnames;
                string email;
                string msnBody;
                ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                string employname;
                string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
                ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
                string applyUrl = Page.Request.Url.ToString();
                applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

                applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                //通知下一步需要审批的人员
                try
                {
                    employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
                    employnames = employname.Split(',');
                    for (int i = 0; i < employnames.Length; i++)
                    {
                        email = employnames[i];
                        msnBody = "您好，" + employnames[i] + "：您有" + txtDepartment.Text
                            + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        Common.SendMessageEX(true, documentName, email, "请审理", msnBody, msnBody,MainID);
                    }
                }
                catch
                {
                }
            }
            RunJS("alert('添加审批流程成功。');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception ee)
        {
            RunJS("alert('添加失败，" + ee.Message + "');window.location='" + Page.Request.Url + "'");
        }
    }
    protected void lbtnAddHR_Click()
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
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                string mainid = MainID;
                T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

                DataSet ds = new DataSet();
                string[] employnames;
                string email;
                string msnBody;
                ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                string employname;
                string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
                ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
                string applyUrl = Page.Request.Url.ToString();
                applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

                applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                //通知下一步需要审批的人员
                try
                {
                    employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
                    employnames = employname.Split(',');
                    for (int i = 0; i < employnames.Length; i++)
                    {
                        email = employnames[i];
                        msnBody = "您好，" + employnames[i] + "：您有" + txtDepartment.Text
                            + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        Common.SendMessageEX(true, documentName, email, "请审理", msnBody, msnBody,MainID);
                    }
                }
                catch
                {
                }
                
            }
            RunJS("alert('添加审批流程成功。');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception ee)
        {
            RunJS("alert('添加失败，" + ee.Message + "');window.location='" + Page.Request.Url + "'");
        }
    }

    public void InsertHrFlow(string deptId, string MID)
    {
        var Flowbll = new DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit();

        DA_Department_Inherit department_Inherit = new DA_Department_Inherit();
        DataSet ds = department_Inherit.GetDepartmentInfoByDeptId(deptId);
        string deptCode = ds.Tables[0].Rows[0]["full_dept_code"].ToString();

       
        if (Common.isExitsArea(Common.AreaValue.wuye1.ToString(), deptCode)) //物业部（海珠，越秀，番禺一部，汇瀚,广州市汇瀚有限公司）
        {
           // Flowbll.InsertHrFlow(new Guid(MID), "21779", "王子君", 16);
            Flowbll.InsertHrFlow(new Guid(MID), "21779,66458,65678,67067", "王子君,谭丽仪A,朱素会,罗斌C", 16);
        }
        else if (Common.isExitsArea(Common.AreaValue.wuye2.ToString(), deptCode)) //物业部（天河区，白云区，花都区，工商铺一、二部）
        {
           // Flowbll.InsertHrFlow(new Guid(MID), "21779", "王子君", 16);
            Flowbll.InsertHrFlow(new Guid(MID), "21779,66458,65678,67067", "王子君,谭丽仪A,朱素会,罗斌C", 16);
        }
        else
        {
         //   Flowbll.InsertHrFlow(new Guid(MID), "21779", "王子君", 16);
            Flowbll.InsertHrFlow(new Guid(MID), "21779,66458,65678,67067", "王子君,谭丽仪A,朱素会,罗斌C", 16);
        }

        Flowbll.InsertHrFlow(new Guid(MID), "15300", "郑纯宁", 17);
    }
}