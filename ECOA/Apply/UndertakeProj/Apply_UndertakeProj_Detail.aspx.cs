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

public partial class Apply_UndertakeProj_Apply_UndertakeProj_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml1 = new StringBuilder();
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public string ApplyN;

    public string sOfficeType = "";

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
                if (Session["FLG_ReWrite26"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite26"] = null;
                }
            }
            catch
            {
            }
            if (MainID != "")
                LoadPage();
            else
                InitPage();
            
        }
        else
            GetAllDepartment();
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

        SbJs.Append("<script type=\"text/javascript\">$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();");
        DrawDetailTable(2,2);
        SbJs.Append("</script>");

        InitListControler("", "", "", "", "");
    }

    private void InitListControler(string departmentTypeSelectedValue, string projectPropertySelectedValue, string agentPropertySelectedValue, string dealTypeSelectedValue, string dealOfficeTypeSelectedValue)
    {
        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DepartmentType_Operate();
        DataSet ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(13);
        DropDownListBind(ddlDepartmentType, ds.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", departmentTypeSelectedValue, "-请选择-");

        DA_Dic_OfficeAutomation_ProjectProperty_Operate da_Dic_OfficeAutomation_ProjectProperty_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_ProjectProperty_Operate();
        ds = da_Dic_OfficeAutomation_ProjectProperty_Operate.SelectByDocumentID(16);
        DropDownListBind(ddlProjectProperty, ds.Tables[0], "OfficeAutomation_ProjectProperty_ID", "OfficeAutomation_ProjectProperty_Name", projectPropertySelectedValue, "-请选择-");

        DA_Dic_OfficeAutomation_AgentProperty_Operate da_Dic_OfficeAutomation_AgentProperty_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_AgentProperty_Operate();
        ds = da_Dic_OfficeAutomation_AgentProperty_Operate.SelectByDocumentID(16);
        DropDownListBind(ddlAgentProperty, ds.Tables[0], "OfficeAutomation_AgentProperty_ID", "OfficeAutomation_AgentProperty_Name", agentPropertySelectedValue, "-请选择-");

        DA_Dic_OfficeAutomation_DealType_Operate da_Dic_OfficeAutomation_DealType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DealType_Operate();
        ds = da_Dic_OfficeAutomation_DealType_Operate.SelectAll();
        DropDownListBind(ddlDealType, ds.Tables[0], "OfficeAutomation_DealType_ID", "OfficeAutomation_DealType_Name", dealTypeSelectedValue, "-请选择-");

        DA_Dic_OfficeAutomation_DealOfficeType_Operate da_Dic_OfficeAutomation_DealOfficeType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DealOfficeType_Operate();
        ds = da_Dic_OfficeAutomation_DealOfficeType_Operate.SelectByDocumentID(14);
        CheckBoxListBind(cblDealOfficeType, ds.Tables[0], "OfficeAutomation_DealOfficeType_ID", "OfficeAutomation_DealOfficeType_Name", dealOfficeTypeSelectedValue);
        for (int i = 0; i < cblDealOfficeType.Items.Count; i++)
        {
            cblDealOfficeType.Items[i].Attributes["tag"] = cblDealOfficeType.Items[i].Value;
        }
    }
    
    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_UndertakeProj_Inherit da_OfficeAutomation_Document_UndertakeProj_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Inherit();
        DA_OfficeAutomation_Document_UndertakeProj_Detail_Inherit da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_UndertakeProj_Detail_Inherit();

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
        ds = da_OfficeAutomation_Document_UndertakeProj_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_UndertakeProj_ID"].ToString();

        string applicant = dr["OfficeAutomation_Document_UndertakeProj_Apply"].ToString();
        ApplyN = applicant;
        lblApply.Text = applicant;
        txtDepartment.Value = dr["OfficeAutomation_Document_UndertakeProj_Department"].ToString();
        hdDepartmentID.Value = dr["OfficeAutomation_Document_UndertakeProj_DepartmentID"].ToString();
        txtApplyForID.Text = dr["OfficeAutomation_Document_UndertakeProj_ApplyForCode"].ToString();
        txtApplyFor.Value = dr["OfficeAutomation_Document_UndertakeProj_ApplyForName"].ToString();
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_UndertakeProj_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtReplyPhone.Text = dr["OfficeAutomation_Document_UndertakeProj_ReplyPhone"].ToString();
        txtProject.Text = dr["OfficeAutomation_Document_UndertakeProj_Project"].ToString();
        txtDeveloper.Text = dr["OfficeAutomation_Document_UndertakeProj_Developer"].ToString();
        txtGroupName.Text = dr["OfficeAutomation_Document_UndertakeProj_GroupName"].ToString();
        txtProjectArea.Text = dr["OfficeAutomation_Document_UndertakeProj_ProjectArea"].ToString();
        txtProjectAddress.Text = dr["OfficeAutomation_Document_UndertakeProj_ProjectAddress"].ToString();
        txtDeveloperContacter.Text = dr["OfficeAutomation_Document_UndertakeProj_DeveloperContacter"].ToString();
        txtDeveloperContacterPosition.Text = dr["OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition"].ToString();
        txtDeveloperContacterPhone.Text = dr["OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone"].ToString();
        txtAreaFollowerContacter.Text = dr["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter"].ToString();
        txtAreaFollowerContacterPosition.Text = dr["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition"].ToString();
        txtAreaFollowerContacterPhone.Text = dr["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone"].ToString();
        txtAreaCheckDataer.Text = dr["OfficeAutomation_Document_UndertakeProj_AreaCheckDataer"].ToString();
        txtAreaCheckDataerCode.Text = dr["OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode"].ToString();
        txtAreaCheckDataerPhone.Text = dr["OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone"].ToString();
        txtSquare.Text = dr["OfficeAutomation_Document_UndertakeProj_Square"].ToString();
        txtSetNumber.Text = dr["OfficeAutomation_Document_UndertakeProj_SetNumber"].ToString();
        txtUnitPrice.Text = dr["OfficeAutomation_Document_UndertakeProj_UnitPrice"].ToString();
        txtTotalPrice.Text = dr["OfficeAutomation_Document_UndertakeProj_TotalPrice"].ToString();
        txtOwnerCommFixScale.Text = dr["OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale"].ToString();
        txtClientCommFixScale.Text = dr["OfficeAutomation_Document_UndertakeProj_ClientCommFixScale"].ToString();
        //txtPreCommTotal.Text = dr["OfficeAutomation_Document_UndertakeProj_PreCommTotal"].ToString();
        txtAgentStartDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_UndertakeProj_AgentStartDate"].ToString()).ToString("yyyy-MM-dd");
        txtAgentEndDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_UndertakeProj_AgentEndDate"].ToString()).ToString("yyyy-MM-dd");

        string s1 = DateTime.Parse(dr["OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate"].ToString()).ToString("yyyy-MM-dd");
        string s2 = DateTime.Parse(dr["OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate"].ToString()).ToString("yyyy-MM-dd");
        if (s1 == "1900-01-01")
            txtClientGuardStartDate.Text = "";
        else
            txtClientGuardStartDate.Text = s1;
        if (s2 == "1900-01-01")
            txtClientGuardEndDate.Text = "";
        else
            txtClientGuardEndDate.Text = s2;

        txtPreCompleteNumber.Text = dr["OfficeAutomation_Document_UndertakeProj_PreCompleteNumber"].ToString();
        txtPreCompleteMoney.Text = dr["OfficeAutomation_Document_UndertakeProj_PreCompleteMoney"].ToString();
        txtPreCompleteComm.Text = dr["OfficeAutomation_Document_UndertakeProj_PreCompleteComm"].ToString();
        txtRemark.Text = dr["OfficeAutomation_Document_UndertakeProj_Remark"].ToString();

        txtTermsOfContract.Text = dr["OfficeAutomation_Document_UndertakeProj_TermsOfContract"].ToString();
        txtTermsOfMajorIssues.Text = dr["OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues"].ToString();

        if (dr["OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack"].ToString() == "1")
            rdbIsProjEarlyCommBack.Checked = true;
        else if (dr["OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack"].ToString() == "2")
            rdbIsProjEarlyCommhavent.Checked = true;
        else
            rdbIsProjEarlyCommNotBack.Checked = true;
        txtOweCommSum.Text = dr["OfficeAutomation_Document_UndertakeProj_OweCommSum"].ToString();
        if (!string.IsNullOrEmpty(dr["OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate"].ToString()))
            txtAreaPromiseBackDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate"].ToString()).ToString("yyyy-MM-dd");
        if (dr["OfficeAutomation_Document_UndertakeProj_HaveSingleReward"].ToString() == "1")
            rdbHaveSingleReward.Checked = true;
        else if (dr["OfficeAutomation_Document_UndertakeProj_HaveSingleReward"].ToString() == "0")
            rdbNoSingleReward.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_IsAllJumpBar"].ToString() == "True")
            this.rdbAllJumpBar.Checked = true;
        else
            this.rdbRateJumpBar.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_IsMallSplit"].ToString() == "True")
            this.rdbIsMallSplit.Checked = true;
        else
            this.rdbIsNotMallSplit.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_IsMallOpen"].ToString() == "True")
            this.rdbIsMallOpen.Checked = true;
        else
            this.rdbIsNotMallOpen.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_IsExistMortgage"].ToString() == "True")
            this.rdbIsExistMortgage.Checked = true;
        else
            this.rdbIsNotExistMortgage.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules"].ToString() == "True")
            this.rdbIsExistLeasebackRules.Checked = true;
        else
            this.rdbIsNotExistLeasebackRules.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses"].ToString() == "True")
            this.rdbHavePreSaleLicenses.Checked = true;
        else
            this.rdbNoPreSaleLicenses.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_IsUniteAgent"].ToString() == "True")
            this.rdbIsUniteAgent.Checked = true;
        else
            this.rdbIsNotUniteAgent.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract"].ToString() == "True")
            this.rdbIsWithPropertyOwnerSignContract.Checked = true;
        else
            this.rdbIsNotWithPropertyOwnerSignContract.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_SaleModeID"].ToString() == "1")
            this.rdbSaleMode1.Checked = true;
        else
            this.rdbSaleMode2.Checked=true;
        txtMainAreaScale.Text = dr["OfficeAutomation_Document_UndertakeProj_MainAreaScale"].ToString();
        txtDealAreaScale.Text = dr["OfficeAutomation_Document_UndertakeProj_DealAreaScale"].ToString();
        if (dr["OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce"].ToString() == "1")
            this.rdbIsCoopWithECommerce.Checked = true;
        else if (dr["OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce"].ToString() == "0")
            this.rdbIsNoCoopWithECommerce.Checked = true;
        else if (dr["OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce"].ToString() == "2")
            this.rdbIsNo2CoopWithECommerce.Checked = true;
        txtECommerceName.Text = dr["OfficeAutomation_Document_UndertakeProj_ECommerceName"].ToString();
        if (dr["OfficeAutomation_Document_UndertakeProj_IsNeedExtension"].ToString() == "True")
            this.rdbIsNeedExtension.Checked = true;
        else
            this.rdbIsNotNeedExtension.Checked=true;
        if (dr["OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast"].ToString() == "True")
            this.rdbIsNeedBroadcast.Checked = true;
        else
            this.rdbIsNotNeedBroadcast.Checked=true;
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        InitListControler(dr["OfficeAutomation_Document_UndertakeProj_DepartmentTypeID"].ToString(), 
            dr["OfficeAutomation_Document_UndertakeProj_ProjectPropertyID"].ToString(), 
            dr["OfficeAutomation_Document_UndertakeProj_AgentPropertyID"].ToString(), 
            dr["OfficeAutomation_Document_UndertakeProj_DealTypeID"].ToString(), 
            dr["OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs"].ToString());

        DataSet dsOwner = da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit.SelectByApplyID(ID,1);
        int ownerDetailCount = dsOwner.Tables[0].Rows.Count;
        DataSet dsClient = da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit.SelectByApplyID(ID, 2);
        int clientDetailCount = dsClient.Tables[0].Rows.Count;

        DrawDetailTable(ownerDetailCount,clientDetailCount);

        for (int n = 0; n < ownerDetailCount; n++)
        {
            dr = dsOwner.Tables[0].Rows[n];

            int i = n + 1;

            SbJs.Append("$('#txtOwnerCommFloatSetNumberStart" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_SetNumberStart"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatSetNumberEnd" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_SetNumberEnd"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatMoneyStart" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_MoneyStart"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatMoneyEnd" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_MoneyEnd"] + "');");
            SbJs.Append("$('#txtOwnerCommFloatScale" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_Scale"] + "');");
        }

        for (int n = 0; n < clientDetailCount; n++)
        {
            dr = dsClient.Tables[0].Rows[n];

            int i = n + 1;

            SbJs.Append("$('#txtClientCommFloatSetNumberStart" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_SetNumberStart"] + "');");
            SbJs.Append("$('#txtClientCommFloatSetNumberEnd" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_SetNumberEnd"] + "');");
            SbJs.Append("$('#txtClientCommFloatMoneyStart" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_MoneyStart"] + "');");
            SbJs.Append("$('#txtClientCommFloatMoneyEnd" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_MoneyEnd"] + "');");
            SbJs.Append("$('#txtClientCommFloatScale" + i + "').val('" + dr["OfficeAutomation_Document_UndertakeProj_Detail_Scale"] + "');");
        }
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        if (isApplicant)
        {
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1")
            {
                GetAllDepartment();
                //btnSave.Visible = true; //旧表，保存按钮不开启
                SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();");
            }
            //btnReWrite.Visible = true; 
        }

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。(暂未启用)

        //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
        //    btnSignSave.Visible = true;

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                SbJs.Append("$(\"#btnAddRow1\").show();$(\"#btnDeleteRow1\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();");
                SbJs.Append("$(\"#btnUpload\").hide();");
                SbJs.Append("</script>");
                flowState = "1"; 
                return;
            }
        }
        catch
        {
            //if (isApplicant)
                //btnReWrite.Visible = true; //*-+
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
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

            //if (curidx == "8")
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
                        //case "6":
                        //    //ckbAddIDx7.Visible = true;
                        //    break;
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
        //    SbJs.Append("$('#trLogistics').show();$('#trGeneralManager').show();");

        //如果为未审核状态且登入人为申请人，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName)
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        //if (flowState == "2" && applicant == EmployeeName) //20141215：M_AlterC
        //    btnEditFlow2.Visible = true;
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

    public void DrawDetailTable(int n1,int n2)
    {
        for (int i = 2; i <= n1; i++)
        {
            SbHtml1.Append("<tr id='trOwner" + i + "'  style=\"border:none;\">");
            SbHtml1.Append("     <td  style='border:none;'><input type=\"text\" id=\"txtOwnerCommFloatSetNumberStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtOwnerCommFloatSetNumberEnd" + i + "\" style=\"width:50px\"/>套/<input type=\"text\" id=\"txtOwnerCommFloatMoneyStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtOwnerCommFloatMoneyEnd" + i + "\" style=\"width:50px\"/>元销售额，收佣比例<input type=\"text\" id=\"txtOwnerCommFloatScale" + i + "\" style=\"width:50px\"/>%</td>");
            SbHtml1.Append("</tr>");
        }
        SbJs.Append("i1=" + n1 + ";");

        for (int i = 2; i <= n2; i++)
        {
            SbHtml2.Append("<tr id='trClient" + i + "'  style=\"border:none;\">");
            SbHtml2.Append("     <td  style='border:none;'><input type=\"text\" id=\"txtClientCommFloatSetNumberStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtClientCommFloatSetNumberEnd" + i + "\" style=\"width:50px\"/>套/<input type=\"text\" id=\"txtClientCommFloatMoneyStart" + i + "\" style=\"width:50px\"/>至<input type=\"text\" id=\"txtClientCommFloatMoneyEnd" + i + "\" style=\"width:50px\"/>元销售额，收佣比例<input type=\"text\" id=\"txtClientCommFloatScale" + i + "\" style=\"width:50px\"/>%</td>");
            SbHtml2.Append("</tr>");
        }
        SbJs.Append("i2=" + n2 + ";");
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
        T_OfficeAutomation_Document_UndertakeProj t_OfficeAutomation_Document_UndertakeProj = new T_OfficeAutomation_Document_UndertakeProj();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_UndertakeProj_Inherit da_OfficeAutomation_Document_UndertakeProj_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Inherit();
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
            for (int i = 0; i <= this.cblDealOfficeType.Items.Count - 1; i++)
            {
                if (this.cblDealOfficeType.Items[i].Selected == true)
                { sOfficeType = sOfficeType + this.cblDealOfficeType.Items[i].Value + "|"; }
            }
            sOfficeType = sOfficeType.Substring(0, sOfficeType.Length - 1);
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
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "UndertakeProj" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 16;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                t_OfficeAutomation_Document_UndertakeProj = GetModelFromPage(Guid.NewGuid());

                da_OfficeAutomation_Document_UndertakeProj_Inherit.Add(t_OfficeAutomation_Document_UndertakeProj);//插入申请表

                InsertUndertakeProjDetail(t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ID);

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

                #region 根据所属区域增加法律部一级审批（2014-04-18取消）

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

                Common.AddLog(EmployeeID, EmployeeName, 20, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_UndertakeProj_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
        DA_OfficeAutomation_Document_UndertakeProj_Inherit da_OfficeAutomation_Document_UndertakeProj_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Inherit();
        DA_OfficeAutomation_Document_UndertakeProj_Detail_Inherit da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_UndertakeProj_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_UndertakeProj_ID"].ToString();

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

                bool isSignSuccess = flowIDx == "4" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_UndertakeProj_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_UndertakeProj_ApplyForName"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_UndertakeProj_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_UndertakeProj_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>回复电话：" + drRow["OfficeAutomation_Document_UndertakeProj_ReplyPhone"]);
                    sbMailBody.Append("<br/><br/>项目名称：" + drRow["OfficeAutomation_Document_UndertakeProj_Project"]);
                    sbMailBody.Append("<br/>项目发展商(小业主)：" + drRow["OfficeAutomation_Document_UndertakeProj_Developer"]);
                    DA_Dic_OfficeAutomation_DealOfficeType_Operate da_Dic_OfficeAutomation_DealOfficeType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DealOfficeType_Operate();
                    sbMailBody.Append("<br/>物业性质：" + da_Dic_OfficeAutomation_DealOfficeType_Operate.SelectNamesByIDs(drRow["OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs"].ToString()));
                    sbMailBody.Append("<br/>项目所在区域：" + drRow["OfficeAutomation_Document_UndertakeProj_ProjectArea"]);
                    sbMailBody.Append("<br/>详细地址：" + drRow["OfficeAutomation_Document_UndertakeProj_ProjectAddress"]);
                    sbMailBody.Append("<br/>区域跟进联系人：" + drRow["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter"]);
                    sbMailBody.Append("<br/>联系电话：" + drRow["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone"]);
                    sbMailBody.Append("<br/>项目情况承接货量" + drRow["OfficeAutomation_Document_UndertakeProj_Square"] + "平方米,共" + drRow["OfficeAutomation_Document_UndertakeProj_SetNumber"] + "套;预计单价" + drRow["OfficeAutomation_Document_UndertakeProj_UnitPrice"] + "元/平方米;货量总金额" + drRow["OfficeAutomation_Document_UndertakeProj_TotalPrice"] + "元");
                    sbMailBody.Append("<br/>代理期: " + drRow["OfficeAutomation_Document_UndertakeProj_AgentStartDate"] + "~" + drRow["OfficeAutomation_Document_UndertakeProj_AgentEndDate"] + " 客户保护期: " + drRow["OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate"] + "~" + drRow["OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate"]);
                    sbMailBody.Append("<br/>预估代理期内完成货量" + drRow["OfficeAutomation_Document_UndertakeProj_PreCompleteNumber"] + "套,货量金额" + drRow["OfficeAutomation_Document_UndertakeProj_PreCompleteMoney"] + "元,佣金收入" + drRow["OfficeAutomation_Document_UndertakeProj_PreCompleteComm"] + "元 ");
                    sbMailBody.Append("<br/><br/>代理费");
                    sbMailBody.Append("<br/>(1)业佣：固定收佣比例"+drRow["OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale"] +"%");
                    ds = da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit.SelectByApplyID(drRow["OfficeAutomation_Document_UndertakeProj_ID"].ToString(), 1);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0) 
                    {
                        sbMailBody.Append("<br/> 变动收佣，其中");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            sbMailBody.Append("<br/>" + dr["OfficeAutomation_Document_UndertakeProj_Detail_SetNumberStart"] + "至" + dr["OfficeAutomation_Document_UndertakeProj_Detail_SetNumberEnd"] + "套/" + dr["OfficeAutomation_Document_UndertakeProj_Detail_MoneyStart"] + "至" + dr["OfficeAutomation_Document_UndertakeProj_Detail_MoneyEnd"] + "元销售额，收佣比例" + dr["OfficeAutomation_Document_UndertakeProj_Detail_Scale"] + "%");
                        }
                    }
                    sbMailBody.Append("<br/>(2)客佣：固定收佣比例" + drRow["OfficeAutomation_Document_UndertakeProj_ClientCommFixScale"] + "%"); //，预计佣金收入总额" + drRow["OfficeAutomation_Document_UndertakeProj_PreCommTotal"] + "元
                    ds = da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit.SelectByApplyID(drRow["OfficeAutomation_Document_UndertakeProj_ID"].ToString(), 2);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        sbMailBody.Append("<br/> 变动收佣，其中");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            sbMailBody.Append("<br/>" + dr["OfficeAutomation_Document_UndertakeProj_Detail_SetNumberStart"] + "至" + dr["OfficeAutomation_Document_UndertakeProj_Detail_SetNumberEnd"] + "套/" + dr["OfficeAutomation_Document_UndertakeProj_Detail_MoneyStart"] + "至" + dr["OfficeAutomation_Document_UndertakeProj_Detail_MoneyEnd"] + "元销售额，收佣比例" + dr["OfficeAutomation_Document_UndertakeProj_Detail_Scale"] + "%");
                        }
                    }
                    sbMailBody.Append("<br/>其他详细申请资料请见申请表");

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
                            Common.SendMessageEX(false, email, "申请已通过", msnBody, msnBody);

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
                                        Common.SendMessageEX(false, email, "申请已通过", msnBody + mailBody, msnBody);

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
                                    Common.SendMessageEX(false, email, "申请已通过", msnBody + mailBody, msnBody);

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

    #region 从页面中获得model

    private T_OfficeAutomation_Document_UndertakeProj GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_UndertakeProj t_OfficeAutomation_Document_UndertakeProj = new T_OfficeAutomation_Document_UndertakeProj();
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ID = UndertakeProjID;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_Apply = EmployeeName;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ApplyForName = txtApplyFor.Value;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ApplyForCode = txtApplyForID.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_Department = txtDepartment.Value;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DepartmentID = new Guid(hdDepartmentID.Value);
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DepartmentTypeID = int.Parse(ddlDepartmentType.SelectedValue);
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_Project = txtProject.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_Developer = txtDeveloper.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_GroupName = txtGroupName.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ProjectPropertyID = int.Parse(ddlProjectProperty.SelectedValue);
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DealTypeID = int.Parse(ddlDealType.SelectedValue); 
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AgentPropertyID = int.Parse(ddlAgentProperty.SelectedValue); 
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ProjectArea = txtProjectArea.Text;
        //t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs = hdDealOfficeType.Value;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs = sOfficeType;

        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ProjectAddress = txtProjectAddress.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DeveloperContacter = txtDeveloperContacter.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition = txtDeveloperContacterPosition.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone = txtDeveloperContacterPhone.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter = txtAreaFollowerContacter.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition = txtAreaFollowerContacterPosition.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone = txtAreaFollowerContacterPhone.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AreaCheckDataer = txtAreaCheckDataer.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode = txtAreaCheckDataerCode.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone = txtAreaCheckDataerPhone.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_Square = txtSquare.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_SetNumber = txtSetNumber.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_UnitPrice = txtUnitPrice.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_TotalPrice = txtTotalPrice.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale = txtOwnerCommFixScale.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ClientCommFixScale = txtClientCommFixScale.Text;
        //t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_PreCommTotal = txtPreCommTotal.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AgentStartDate = DateTime.Parse(txtAgentStartDate.Text);
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AgentEndDate = DateTime.Parse(txtAgentEndDate.Text); 
        
        if(txtClientGuardStartDate.Text == "")
            t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate = DateTime.Parse("1900-01-01");
        else
            t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate = DateTime.Parse(txtClientGuardStartDate.Text); 
        if(txtClientGuardEndDate.Text == "")
            t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate = DateTime.Parse("1900-01-01"); 
        else
            t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate = DateTime.Parse(txtClientGuardEndDate.Text); 
        
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_PreCompleteNumber = txtPreCompleteNumber.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_PreCompleteMoney = txtPreCompleteMoney.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_PreCompleteComm = txtPreCompleteComm.Text;

        if (rdbIsProjEarlyCommhavent.Checked)
            t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack = 2;
        else if (rdbIsProjEarlyCommBack.Checked)
            t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack = 1;
        else
            t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack = 0;

        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_OweCommSum = txtOweCommSum.Text;
        if (!string.IsNullOrEmpty(txtAreaPromiseBackDate.Text))
            t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate = DateTime.Parse(txtAreaPromiseBackDate.Text);
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_HaveSingleReward = rdbHaveSingleReward.Checked ? 1 : 0;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsAllJumpBar = rdbAllJumpBar.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsMallSplit = rdbIsMallSplit.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsMallOpen = rdbIsMallOpen.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsExistMortgage = rdbIsExistMortgage.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules = rdbIsExistLeasebackRules.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses = rdbHavePreSaleLicenses.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsUniteAgent = rdbIsUniteAgent.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract = rdbIsWithPropertyOwnerSignContract.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_SaleModeID = rdbSaleMode1.Checked ? 1 : 2;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_MainAreaScale = txtMainAreaScale.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_DealAreaScale = txtDealAreaScale.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce = rdbIsCoopWithECommerce.Checked ? 1 : rdbIsNoCoopWithECommerce.Checked ? 0 : 2;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_ECommerceName = txtECommerceName.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsNeedExtension = rdbIsNeedExtension.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast = rdbIsNeedBroadcast.Checked;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_Remark = txtRemark.Text;

        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_TermsOfContract = txtTermsOfContract.Text;
        t_OfficeAutomation_Document_UndertakeProj.OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues = txtTermsOfMajorIssues.Text;

        return t_OfficeAutomation_Document_UndertakeProj;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_UndertakeProj t_OfficeAutomation_Document_UndertakeProj = new T_OfficeAutomation_Document_UndertakeProj();
        DA_OfficeAutomation_Document_UndertakeProj_Inherit da_OfficeAutomation_Document_UndertakeProj_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_UndertakeProj_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_ID"].ToString();

        t_OfficeAutomation_Document_UndertakeProj = GetModelFromPage(new Guid(ID));

        da_OfficeAutomation_Document_UndertakeProj_Inherit.Update(t_OfficeAutomation_Document_UndertakeProj);//修改申请表

        DA_OfficeAutomation_Document_UndertakeProj_Detail_Inherit da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Detail_Inherit();
        da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit.Delete(new Guid(ID));
        InsertUndertakeProjDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 20, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增申请明细

    /// <summary>
    /// 新增申请明细
    /// </summary>
    /// <param name="gUndertakeProjID"></param>
    private void InsertUndertakeProjDetail(Guid gUndertakeProjID)
    {
        T_OfficeAutomation_Document_UndertakeProj_Detail t_OfficeAutomation_Document_UndertakeProj_Detail;
        DA_OfficeAutomation_Document_UndertakeProj_Detail_Inherit da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Detail_Inherit();

        string[] details = Regex.Split(this.hdOwner.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_UndertakeProj_Detail = new T_OfficeAutomation_Document_UndertakeProj_Detail();
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_MainID = gUndertakeProjID;
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_CommType = 1;
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_SetNumberStart = detail[0];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_SetNumberEnd = detail[1];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_MoneyStart = detail[2];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_MoneyEnd = detail[3];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_Scale = detail[4];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_OrderBy = i;
            da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit.Add(t_OfficeAutomation_Document_UndertakeProj_Detail);
        }

        details = Regex.Split(this.hdClient.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_UndertakeProj_Detail = new T_OfficeAutomation_Document_UndertakeProj_Detail();
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_MainID = gUndertakeProjID;
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_CommType = 2;
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_SetNumberStart = detail[0];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_SetNumberEnd = detail[1];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_MoneyStart = detail[2];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_MoneyEnd = detail[3];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_Scale = detail[4];
            t_OfficeAutomation_Document_UndertakeProj_Detail.OfficeAutomation_Document_UndertakeProj_Detail_OrderBy = i;
            da_OfficeAutomation_Document_UndertakeProj_Detail_Inherit.Add(t_OfficeAutomation_Document_UndertakeProj_Detail);
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
    }
    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        //btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite26"] = "1";
        Response.Write("<script>window.open('Apply_UndertakeProj_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("物业部承接项目报备申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }
}