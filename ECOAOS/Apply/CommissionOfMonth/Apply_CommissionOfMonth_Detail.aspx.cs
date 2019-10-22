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

public partial class Apply_CommissionOfMonth_Apply_CommissionOfMonth_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public string ApplyN,vs = "0";
    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();";

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
        //try
        //{
        //    vs = GetQueryString("vs");
        //}
        //catch
        //{
        //}
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
                if (Session["FLG_ReWrite47"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite47"] = null;
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
        //DrawDetailTable(0);
        SbJs.Append("$(\"#UploatPath\").show();");
        SbJs.Append("$(\"#trCcess\").hide();");
        SbJs.Append("</script>");
        IsNewApply = true;
        DrawDetailTable(0);
        RunJS("alert('请各位在人力资源部规定的截止时间前提交申请，提交申请时间以最终成功送审到人力资源部的时间为准。谢谢！ ');");
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
        DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
        DA_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit();
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();//*-

        DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);
        if (dsAttach.Tables[0].Rows.Count == 0)
            vs = "0";
        else
            vs = "1";

        string flowState;
        try
        {
             flowState= da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
        }
        catch
        {
            Alert(CommonConst.MSG_URL_DISABLE);
            RunJS("window.location='/Apply/Apply.aspx'");
            return;
        }

        SbJs.Append("<script type=\"text/javascript\">");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_CommissionOfMonth_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_CommissionOfMonth_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_CommissionOfMonth_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_CommissionOfMonth_Department"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_CommissionOfMonth_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtCode.Text = dr["OfficeAutomation_Document_CommissionOfMonth_Code"].ToString();
        txtEnterDate.Text = dr["OfficeAutomation_Document_CommissionOfMonth_EnterDate"].ToString();
        txtName.Text = dr["OfficeAutomation_Document_CommissionOfMonth_Name"].ToString();
        txtRank.Text = dr["OfficeAutomation_Document_CommissionOfMonth_Rank"].ToString();
        txtPosition.Text = dr["OfficeAutomation_Document_CommissionOfMonth_Position"].ToString();
        txtResults.Text = dr["OfficeAutomation_Document_CommissionOfMonth_Results"].ToString();
        txtDescribe.Text = dr["OfficeAutomation_Document_CommissionOfMonth_Describe"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        ds = da_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit.SelectByID(ID);
        int detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable(0);
        else
        {
            DrawDetailTable(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];
                int i = n + 1;

                SbJs.Append("$('#txtDetail_Department" + i + "').val('" + dr["OfficeAutomation_Document_CommissionOfMonth_Detail_Department"] + "');");
                SbJs.Append("$('#txtDetail_Name" + i + "').val('" + dr["OfficeAutomation_Document_CommissionOfMonth_Detail_Name"] + "');");
                SbJs.Append("$('#txtDetail_Code" + i + "').val('" + dr["OfficeAutomation_Document_CommissionOfMonth_Detail_Code"] + "');");
                SbJs.Append("$('#txtDetail_EnterDate" + i + "').val('" + dr["OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate"] + "');");
                SbJs.Append("$('#txtDetail_Position" + i + "').val('" + dr["OfficeAutomation_Document_CommissionOfMonth_Detail_Position"] + "');");
                SbJs.Append("$('#txtDetail_Rank" + i + "').val('" + dr["OfficeAutomation_Document_CommissionOfMonth_Detail_Rank"] + "');");
                SbJs.Append("$('#txtDetail_Results" + i + "').val('" + dr["OfficeAutomation_Document_CommissionOfMonth_Detail_Results"] + "');");
            }
        }
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#UploatPath\").show();");
        bool isApplicant = EmployeeName == applicant;
        if (isApplicant)
        {
            //SbJs.Append("$(\"#UploatPath\").show();");
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
        }
        else
            SbJs.Append("$(\"#UploatPath\").hide();");

        if (EmployeeID == "16945" || EmployeeID == "3575" || EmployeeID == "34498")
            SbJs.Append("$(\"#trFinancial\").show();");

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
                SbJs.Append("$(\"#btnPrint\").hide();$(\"#trCcess\").hide();");
                SbJs.Append("</script>");
                GetAllDepartment();
                //txtDepartment.Text = "";
                btnSPDF.Visible = false; //M_PDF
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                flowState = "1";
                vs = "0";
                btnSAlterC.Visible = false;
                btnSave.Visible = true;
                IsNewApply = true;
                RunJS("alert('请各位在人力资源部规定的截止时间前提交申请，提交申请时间以最终成功送审到人力资源部的时间为准。谢谢！ ');");
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

        ////如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        //if (flag3)
        //SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();$('#trGeneralManager').show();");

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

        T_OfficeAutomation_Flow flows;
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 7);
        if (flows != null)
        {
            lbUse.Visible = false;
            lbSee.Visible = true;
            btnCantUse.Visible = false;
        }
        else
        {
            lbUse.Visible = true;
            lbSee.Visible = false;
            btnCantUse.Visible = true;
        }

        #endregion

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
        if (flows == null)
            SbJs.Append("$('#trmq').hide();");

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
        DataSet dsApplyDetail = new DataSet();
        DataSet dsApplyType = new DataSet();

        //DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
        //dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(1);
        //DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
        //dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();

        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id=\"trDetail" + i + "\">");
            SbHtml.Append("<td style=\"line-height: 15px;\">");

            SbHtml.Append("<table style=\"border-collapse: collapse;\" width=\"100%\"><tr><td>* 姓名</td>");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px\"><input type=\"text\" id=\"txtDetail_Name" + i + "\" ></td><td class=\"astyle2\">* 工号</td>");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px\"><input type=\"text\" id=\"txtDetail_Code" + i + "\" onblur=\"getEmployee(" + i + ", this);\"></td></tr><tr><td>* 入职日期</td>");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px\"><input type=\"text\" id=\"txtDetail_EnterDate" + i + "\"></td><td>* 现任职部门</td>");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px\"><input type=\"text\" id=\"txtDetail_Department" + i + "\"></td></tr><tr><td>* 现职位</td>");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px\"><input type=\"text\" id=\"txtDetail_Position" + i + "\"></td><td>* 现职级</td>");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px\"><input type=\"text\" id=\"txtDetail_Rank" + i + "\"></td></tr><tr><td class=\"astyle2\">* 预估本月实收业绩及解HOLD佣实收业绩</td>");
            SbHtml.Append("<td colspan=\"3\" style=\"text-align: left; padding-left: 10px\"><input type=\"text\" id=\"txtDetail_Results" + i + "\">元</td>");
            SbHtml.Append("</tr></table>");

            SbHtml.Append("</td>");
            SbHtml.Append("</tr>");
        }
        //SbJs.Append("i=" + n + ";");
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
        T_OfficeAutomation_Document_CommissionOfMonth t_OfficeAutomation_Document_CommissionOfMonth = new T_OfficeAutomation_Document_CommissionOfMonth();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
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

        //try
        //{
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
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "CommissionOfMonth" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 42; //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                t_OfficeAutomation_Document_CommissionOfMonth = GetModelFromPage(Guid.NewGuid());


                string detail = InsertCommissionOfMonthDetail(t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_ID);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtName.Text + '，' + detail;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_CommissionOfMonth_Inherit.Insert(t_OfficeAutomation_Document_CommissionOfMonth);//插入申请表

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

                Common.AddLog(EmployeeID, EmployeeName, 46, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                //RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_CommissionOfMonth_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply.aspx'; }");
                RunJS("alert('申请表现已保存成功！');var win=window.showModalDialog(\"Apply_CommissionOfMonth_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='../Apply.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    Update();

                    RunJS("alert('保存成功！');window.location='../Apply.aspx';");
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
        DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();

        DataSet ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_CommissionOfMonth_ID"].ToString(); 
        
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
                bool isSignSuccess = flowIDx == "0" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody = "";

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionOfMonth_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_CommissionOfMonth_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>填写人：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Apply"]);
                    sbMailBody.Append("<br/>填写日期：" + drRow["OfficeAutomation_Document_CommissionOfMonth_ApplyDate"]);
                    sbMailBody.Append("<br/>现任职部门：" + DateTime.Parse(drRow["OfficeAutomation_Document_CommissionOfMonth_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>发文编号：" + drRow["OfficeAutomation_Document_CommissionOfMonth_ApplyID"]);
                    sbMailBody.Append("<br/>姓名：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Name"]);
                    sbMailBody.Append("<br/>工号：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Code"]);

                    sbMailBody.Append("<br/>入职日期：" + drRow["OfficeAutomation_Document_CommissionOfMonth_EnterDate"]);
                    sbMailBody.Append("<br/>现职位：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Position"]);
                    sbMailBody.Append("<br/>现职级：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Rank"]);
                    sbMailBody.Append("<br/>预估本月实收业绩及解HOLD佣实收业绩：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Results"]);
                    sbMailBody.Append("<br/>备注：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Describe"]);

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

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）梁晶晶（工号：32188）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            //employname = "宁伟雄,黄洁珍";
                            //employnames = employname.Split(',');
                            //for (int i = 0; i < employnames.Length; i++)
                            //{
                            //    if (!employeeList.Contains(employnames[i]))
                            //    {
                            //        msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //        email = employnames[i];
                                    //if (hdIsAgree.Value == "2")
                            //    Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                    //else
                                    //    Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                            //        employeeList += employnames[i] + "||";
                            //    }
                            //}
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
                                    if (email == "张晓莹" || email == "郑纯宁")
                                        Common.SendMessageEX(true, email, "请审理", msnBody + mailBody, msnBody);
                                    else
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
        //    DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_CommissionOfMonth_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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
          
        string sUrl = "../Apply.aspx?" + Request.QueryString;
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
    protected void gvAttach_RowCommand(object sender, GridViewCommandEventArgs e)//*-
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
        DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);
        if (dsAttach.Tables[0].Rows.Count == 0)
        {
            vs = "0";
        }
        LoadPage();
    }

    #endregion

    #endregion

    #region 从页面中获得model

    private T_OfficeAutomation_Document_CommissionOfMonth GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_CommissionOfMonth t_OfficeAutomation_Document_CommissionOfMonth = new T_OfficeAutomation_Document_CommissionOfMonth();
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_ID = UndertakeProjID;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_Apply = EmployeeName;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_Code = txtCode.Text;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_EnterDate = txtEnterDate.Text;

        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_Name = txtName.Text;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_Rank = txtRank.Text;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_Position = txtPosition.Text;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_Results = txtResults.Text;
        t_OfficeAutomation_Document_CommissionOfMonth.OfficeAutomation_Document_CommissionOfMonth_Describe = txtDescribe.Text;

        return t_OfficeAutomation_Document_CommissionOfMonth;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_CommissionOfMonth t_OfficeAutomation_Document_CommissionOfMonth = new T_OfficeAutomation_Document_CommissionOfMonth();
        DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionOfMonth_ID"].ToString();

        t_OfficeAutomation_Document_CommissionOfMonth = GetModelFromPage(new Guid(ID));

        DA_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit();
        da_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit.Delete(ID);
        string detail = InsertCommissionOfMonthDetail(new Guid(ID));

        string apply = EmployeeName;
        string depname = txtDepartment.Text;
        string summary = txtName.Text + '，' + detail; ;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_CommissionOfMonth_Inherit.Update(t_OfficeAutomation_Document_CommissionOfMonth);//修改申请表

        Common.AddLog(EmployeeID, EmployeeName, 46, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增详情表

    /// <summary>
    /// 新增详情表
    /// </summary>
    /// <param name="gCommissionOfMonthID"></param>
    private string InsertCommissionOfMonthDetail(Guid gCommissionOfMonthID)
    {
        if (hdDetail.Value == "")
            return "";

        T_OfficeAutomation_Document_CommissionOfMonth_Detail t_OfficeAutomation_Document_CommissionOfMonth_Detail;
        DA_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit();
        string result = "";
        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        //try
        //{
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_CommissionOfMonth_Detail = new T_OfficeAutomation_Document_CommissionOfMonth_Detail();
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_MainID = gCommissionOfMonthID;
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_Department = detail[0];
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_Name = detail[1];
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_Code = detail[2];
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate = detail[3];
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_Position = detail[4];
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_Rank = detail[5];
                t_OfficeAutomation_Document_CommissionOfMonth_Detail.OfficeAutomation_Document_CommissionOfMonth_Detail_Results = detail[6];

                result += detail[1] + ",";

                da_OfficeAutomation_Document_CommissionOfMonth_Detail_Inherit.Insert(t_OfficeAutomation_Document_CommissionOfMonth_Detail);
            }

            return result;
        //}
        //catch (Exception ee)
        //{
        //    Alert(ee.Message);
        //    return;
        //}
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
        Session["FLG_ReWrite47"] = "1";
        Response.Write("<script>window.open('Apply_CommissionOfMonth_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("关于享受本月佣金按全年一次性奖金发放申请表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
            DataSet ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionOfMonth_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_CommissionOfMonth_Department"].ToString();
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
            DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
            DataSet ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionOfMonth_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_CommissionOfMonth_Department"].ToString();
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
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
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
            DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
            DataSet ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionOfMonth_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_CommissionOfMonth_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 3); //在不同的表中要修改，开发新表时要注意
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_CommissionOfMonth_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    protected void btnLoadPath_Click(object sender, EventArgs e)
    {
        DataAccess.Operate.DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Attach_Inherit();
        DataEntity.T_OfficeAutomation_Attach t_OfficeAutomation_Attach = new DataEntity.T_OfficeAutomation_Attach();

        string sFilePath = "";
        string sFileName = "";
        string mainid = MainID;

        //string uploadPath = Page.Request.PhysicalApplicationPath + "Maintain\\UploadFile\\";
        string uploadPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"].Replace("\\", "\\\\");

        if (!Directory.Exists(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + mainid))
        {
            Directory.CreateDirectory(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + mainid);
        }

        string tempName = Path.GetFileNameWithoutExtension(txtFilePath.PostedFile.FileName);
        string bk = tempName.Substring(tempName.IndexOf('.'));
        //tempName = tempName.Substring(0, tempName.IndexOf('.'));
        tempName = DateTime.Now.Year.ToString() + "/" + mainid + "/" + tempName + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/pdf")
        { sFileName = tempName + ".pdf"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "image/pjpeg")
        { sFileName = tempName + ".jpg"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "image/gif")
        { sFileName = tempName + ".gif"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "image/bmp")
        { sFileName = tempName + ".bmp"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "image/png")
        { sFileName = tempName + ".png"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/msword")
        { sFileName = tempName + ".doc"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
        { sFileName = tempName + ".docx"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.ms-excel")
        { sFileName = tempName + ".xls"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        { sFileName = tempName + ".xlsx"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.ms-powerpoint")
        { sFileName = tempName + ".ppt"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.openxmlformats-officedocument.presentationml.presentation")
        { sFileName = tempName + ".pptx"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "text/plain")
        { sFileName = tempName + ".txt"; }
        else if (bk == ".pdf" || bk == ".jpg" || bk == ".gif" || bk == ".bmp" || bk == ".png" || bk == ".doc" || bk == ".docx" || bk == ".xls" || bk == ".xlsx" || bk == ".ppt" || bk == ".pptx" || bk == ".tif" || bk == ".txt")
        { sFileName = tempName + bk; }

        if (sFileName == "")
        {
            RunJS("alert('上传的文件格式错误，应为pdf、jpg、gif、bmp、png、doc、docx、xls、xlsx、ppt、pptx或txt格式，请重新选择！');");
            return;
        }

        if (this.txtFilePath.PostedFile.ContentLength > 5242880)
        {
            RunJS("alert('上传的文件大小超过5M,请重新上传！');");
            return;
        }
        sFileName = sFileName.Replace("+", "_和_");
        sFilePath = uploadPath + sFileName;

        try
        {
            this.txtFilePath.PostedFile.SaveAs(sFilePath);

            t_OfficeAutomation_Attach.OfficeAutomation_Attach_MainID = new Guid(mainid);
            t_OfficeAutomation_Attach.OfficeAutomation_Attach_Name = Path.GetFileName(txtFilePath.PostedFile.FileName);
            t_OfficeAutomation_Attach.OfficeAutomation_Attach_Path = sFileName;
            if (da_OfficeAutomation_Attach_Inherit.Insert(t_OfficeAutomation_Attach))
            {
                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(mainid), 7);
                if (IsNewApply)
                    RunJS("alert('文件上传成功，保存后方可查看！');");
                else
                    RunJS("alert('文件上传成功！');window.location.href='" + Page.Request.Url + "';");
                vs = "1";
            }
        }
        catch (Exception ee)
        {
            //Alert("文件上传失败！");
            RunJS("alert('" + ee.Message + "');");
        }

        //hFilePath.Value = sFileName;
    }
    protected void btnCantUse_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        da_OfficeAutomation_Flow_Inherit.InsertFlowsHaventReview(MainID);
        DataSet ds = new DataSet();
        string[] employnames;
        string email;
        string msnBody;
        ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID);
        string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
        string employname;
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
        ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionOfMonth_Apply"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));

        //string apply = Request.QueryString["apply"];
        //apply = apply.Remove(apply.Length - 1);
        //string applyUrl = Request.QueryString["href"];
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

        //通知申请人
        msnBody = "您好" + apply + "，" + EmployeeName + "确认不使用您申请的编号为" + serialNumber + "的" + documentName + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        Common.SendMessageEX(false, apply, EmployeeName + "确认不使用" + documentName, msnBody, msnBody);

        //通知已同意的全部人员
        ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlows(MainID);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            employname = dr["OfficeAutomation_DeletedFlow_Employee"].ToString();
            employnames = employname.Split(',');
            for (int i2 = 0; i2 < employnames.Length; i2++)
            {
                msnBody = "您好" + employnames[i2] + "，" + EmployeeName + "确认不使用您审理过的编号为" + serialNumber + "的" + documentName + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                email = employnames[i2]; if (email != "")
                Common.SendMessageEX(false, email, EmployeeName + "确认不使用" + documentName, msnBody, msnBody);
            }
        }
        da_OfficeAutomation_Flow_Inherit.DeleteHaventA(MainID);

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "财务部";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 7;

        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, EmployeeID, "财务部", EmployeeName + "确认不使用", "7", "2");
        da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        RunJS("alert('操作成功，稍后系统会把您的意见发送给相关人员。');window.location.href='" + Page.Request.Url + "';");
    }
    protected void btnSureUse_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 7);
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
            //string apply = Request.QueryString["apply"];
            //apply = apply.Remove(apply.Length - 1);
            //string applyUrl = Request.QueryString["href"];
            //applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
            ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionOfMonth_Apply"].ToString();
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
                    if (email == "张晓莹" || email == "郑纯宁")
                        Common.SendMessageEX(true, email, documentName + "需要您继续审理", msnBody, msnBody);
                    else
                        Common.SendMessageEX(true, documentName, email, documentName + "需要您继续审理", msnBody, msnBody,mainid);
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
}