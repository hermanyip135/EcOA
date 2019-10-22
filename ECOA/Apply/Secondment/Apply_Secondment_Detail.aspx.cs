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

public partial class Apply_Secondment_Apply_Secondment_Detail : BasePage
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
                if (Session["FLG_ReWrite49"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite49"] = null;
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
        SbJs.Append("<script type=\"text/javascript\">");
        SbJs.Append("$(\"#HeadA\").show();");
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
        txtInDptmContact.Text = EmployeeName;
        InitListControler("");
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        
    }

    private void InitListControler(string projectPropertySelectedValue)
    {
        DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Assets_Inherit.SelectA();
        DropDownListBind(ddlAssetsName, ds.Tables[0], "OfficeAutomation_Document_Assets_NAME", "OfficeAutomation_Document_Assets_NAME", projectPropertySelectedValue, "-请选择-");
        if (projectPropertySelectedValue != "")
        {
            try
            {
                ds = da_OfficeAutomation_Document_Assets_Inherit.SelectInventory(projectPropertySelectedValue);
                lbAssetsName.Text = "库存量：" + ds.Tables[0].Rows[0]["Count"].ToString() + "个";
                lbSummary.Text = "规格：" + ds.Tables[0].Rows[0]["Summary"].ToString();
            }
            catch
            {
                lbAssetsName.Text = "没有库存";
                lbSummary.Text = "";
            }
        }
    }

    private void InitListControlerAll(string projectPropertySelectedValue)
    {
        DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Assets_Inherit.SelectAt();
        DropDownListBind(ddlAssetsName, ds.Tables[0], "OfficeAutomation_Document_Assets_NAME", "OfficeAutomation_Document_Assets_NAME", projectPropertySelectedValue, "-请选择-");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
        
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
        ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_Secondment_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_Secondment_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_Secondment_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_Secondment_Department"].ToString();
        txtBorrowDepartment.Text = dr["OfficeAutomation_Document_Secondment_BorrowDepartment"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_Secondment_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtInDptm.Text = dr["OfficeAutomation_Document_Secondment_InDptm"].ToString();
        txtInDptmContact.Text = dr["OfficeAutomation_Document_Secondment_InDptmContact"].ToString();
        InitListControlerAll(dr["OfficeAutomation_Document_Secondment_AssetsName"].ToString());
        txtTheMessage.Text = dr["OfficeAutomation_Document_Secondment_TheMessage"].ToString();
        txtNumber.Text = dr["OfficeAutomation_Document_Secondment_Number"].ToString();
        txtBorrowDate.Text = dr["OfficeAutomation_Document_Secondment_BorrowDate"].ToString();
        txtExpectReturnDate.Text = dr["OfficeAutomation_Document_Secondment_ExpectReturnDate"].ToString();
        txtSalesDate.Text = dr["OfficeAutomation_Document_Secondment_SalesDate"].ToString();
        txtSales.Text = dr["OfficeAutomation_Document_Secondment_Sales"].ToString();
        txtReturnDate.Text = dr["OfficeAutomation_Document_Secondment_ReturnDate"].ToString();
        txtReturner.Text = dr["OfficeAutomation_Document_Secondment_Returner"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_Secondment_Reason"].ToString();

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
        ds = da_OfficeAutomation_Document_Assets_Inherit.SelectByName(dr["OfficeAutomation_Document_Secondment_AssetsName"].ToString());
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Document_Assets_IsIT"].ToString() == "True")
            SbJs.Append("$(\"#trManager2\").show();$(\"#trManager22\").show();");
        else
            SbJs.Append("$(\"#trManager2\").hide();$(\"#trManager22\").hide();");

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        if (isApplicant)
        {
            if (flowState == "1")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                //SbJs.Append(ApplyDisplayPart);
            }
            //if (flowState == "2") //20141215：M_AlterC
            //{
            //    GetAllDepartment();
            //    btnSAlterC.Visible = true;
            //}
        }

        #endregion

        if (EmployeeID == "18331" || EmployeeID == "14470")
        {
            GetAllDepartment();
            btnSave.Visible = true;
            //SbJs.Append(ApplyDisplayPart);
        }

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
            btnSignSave.Visible = true;
         
        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                //SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnPrint\").hide();$(\"#HeadA\").show();$(\"#btnUpload\").hide();");
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
                txtInDptmContact.Text = EmployeeName;
                InitListControler("");
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
        if (flowState == "1" && (applicant == EmployeeName || EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME))
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && /*applicant == EmployeeName*/ EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME && !tpdf) //20141215：M_AlterC
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

        try
        {
            ds = da_OfficeAutomation_Document_Assets_Inherit.SelectInventory(ddlAssetsName.SelectedItem.Text);
            //lbAssetsName.Text = "库存量：" + ds.Tables[0].Rows[0]["Count"].ToString() + "个";
            lbSummary.Text = "规格：" + ds.Tables[0].Rows[0]["Summary"].ToString();
        }
        catch
        {
            //lbAssetsName.Text = "没有库存";
            lbSummary.Text = "";
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
        T_OfficeAutomation_Document_Secondment t_OfficeAutomation_Document_Secondment = new T_OfficeAutomation_Document_Secondment();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
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
            if (EmployeeID == "18331" || EmployeeID == "14470")
            {
                try
                {
                    DataSet dss = new DataSet();
                    dss = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID);
                    DataSet dsg = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID); //在不同的表中要修改
                    string apply = dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_Apply"].ToString();
                    dss = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);

                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                                //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
                    if (txtSalesDate.Text != "" && txtReturnDate.Text == "")
                    {
                        string msnBody = "您好" + apply + "，编号为" + txtApplyID.Text + "的资产已出仓。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>"
                            + "<br />资产编号：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_ApplyID"].ToString()
                            + "<br />借调资产名称：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_AssetsName"].ToString()
                            + "<br />借调资产规格、型号：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_TheMessage"].ToString()
                            + "<br />数量：1"
                            + "<br />出仓日期：" + txtSalesDate.Text
                            + "<br />出仓人：" + txtSales.Text
                            ;
                        Common.SendMessageEX(false, apply, "您所需的" + dss.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_AssetsName"].ToString() + "已出仓", msnBody, msnBody);
                    }
                    
                    string id = dss.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_ID"].ToString();
                    t_OfficeAutomation_Document_Secondment = GetModelFromPage(new Guid(id));
                    da_OfficeAutomation_Document_Secondment_Inherit.Update2(t_OfficeAutomation_Document_Secondment);//修改申请表最后4空格
                    if (txtReturnDate.Text != "")
                    {
                        dss = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
                        DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
                        DataRow dri = dss.Tables[0].Rows[0];
                        da_OfficeAutomation_Document_Assets_Inherit.UpdateToggleZero(dri["OfficeAutomation_Document_Secondment_ApplyID"].ToString(), 1);
                        string msnBody = "您好" + apply + "，编号为" + txtApplyID.Text + "的资产已归还仓库。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>"
                            + "<br />资产编号：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_ApplyID"].ToString()
                            + "<br />借调资产名称：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_AssetsName"].ToString()
                            + "<br />借调资产规格、型号：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_TheMessage"].ToString()
                            + "<br />数量：1"
                            + "<br />归还日期：" + txtReturnDate.Text
                            + "<br />归还人：" + txtReturner.Text
                            ;
                        Common.SendMessageEX(false, apply, "行政部已收到了您所归还的" + dss.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_AssetsName"].ToString(), msnBody, msnBody);

                        DataSet ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
                        DataRow dr2 = ds.Tables[0].Rows[0];
                        ds = da_OfficeAutomation_Document_Assets_Inherit.SelectByName(dr2["OfficeAutomation_Document_Secondment_AssetsName"].ToString());
                        if (ds.Tables[0].Rows[0]["OfficeAutomation_Document_Assets_IsIT"].ToString() == "True")
                            apply = "陈秀球";
                        else
                            apply = "黄凤珊";
                        msnBody = "您好" + apply + "，编号为" + txtApplyID.Text + "的资产已归还仓库。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>"
                            + "<br />资产编号：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_ApplyID"].ToString()
                            + "<br />借调资产名称：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_AssetsName"].ToString()
                            + "<br />借调资产规格、型号：" + dsg.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_TheMessage"].ToString()
                            + "<br />数量：1"
                            + "<br />归还日期：" + txtReturnDate.Text
                            + "<br />归还人：" + txtReturner.Text
                            ;
                        Common.SendMessageEX(false, apply, dss.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_AssetsName"].ToString() + "已入库", msnBody, msnBody);
                    }
                }
                catch
                {
                }
            }
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

                //ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
                DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
                //DataRow dr0 = ds.Tables[0].Rows[0];
                ds = da_OfficeAutomation_Document_Assets_Inherit.SelectInventory(ddlAssetsName.SelectedValue);
                int kj = 0;
                try
                {
                    kj = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString()) - int.Parse(txtNumber.Text);
                    if (kj < 0)
                    {
                        RunJS("alert('库存里没有足够的" + ddlAssetsName.SelectedValue + "');history.go(-1);");
                        return;
                    }
                }
                catch
                {
                    RunJS("alert('库存里没有足够的" + ddlAssetsName.SelectedValue + "');history.go(-1);");
                    return;
                }

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "Secondment" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 44; //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                t_OfficeAutomation_Document_Secondment = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = ddlAssetsName.SelectedValue;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_Secondment_Inherit.Insert(t_OfficeAutomation_Document_Secondment);//插入申请表

                //InsertSecondmentDetail(t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_ID);

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

                ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
                DataRow dr2 = ds.Tables[0].Rows[0];
                ds = da_OfficeAutomation_Document_Assets_Inherit.SelectByName(dr2["OfficeAutomation_Document_Secondment_AssetsName"].ToString());
                if (ds.Tables[0].Rows[0]["OfficeAutomation_Document_Assets_IsIT"].ToString() == "True")
                {
                    T_OfficeAutomation_Flow flows;
                    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 5);
                    if (flows == null)
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1236";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "梁锐华";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 6;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                else
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5,6");

                if (ddlAssetsName.SelectedValue != "卡钟")
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "18331";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "陈秀球";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;

                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
                else
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "14470";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄凤珊";
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;

                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }

                Common.AddLog(EmployeeID, EmployeeName, 48, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_Secondment_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                //RunJS("alert('申请表已保存成功！');var returnVaulue=window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';");
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
        DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();

        DataSet ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_Secondment_ID"].ToString(); 
        
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

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_Secondment_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_Secondment_Apply"]);
                    sbMailBody.Append("<br/>发文部门：" + drRow["OfficeAutomation_Document_Secondment_Department"]);
                    sbMailBody.Append("<br/>发文日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_Secondment_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>资产编号：" + drRow["OfficeAutomation_Document_Secondment_ApplyID"]);

                    sbMailBody.Append("<br/>借出部门：" + drRow["OfficeAutomation_Document_Secondment_BorrowDepartment"]);
                    sbMailBody.Append("<br/>借入部门：" + drRow["OfficeAutomation_Document_Secondment_InDptm"]);
                    sbMailBody.Append("<br/>借入部门联系人：" + drRow["OfficeAutomation_Document_Secondment_InDptmContact"]);
                    sbMailBody.Append("<br/>借调资产名称：" + drRow["OfficeAutomation_Document_Secondment_AssetsName"]);
                    sbMailBody.Append("<br/>借调资产规格、型号：" + drRow["OfficeAutomation_Document_Secondment_TheMessage"]);
                    sbMailBody.Append("<br/>数量：" + drRow["OfficeAutomation_Document_Secondment_Number"]);
                    sbMailBody.Append("<br/>借调日期：" + drRow["OfficeAutomation_Document_Secondment_BorrowDate"]);
                    sbMailBody.Append("<br/>归还日期（预计）：" + drRow["OfficeAutomation_Document_Secondment_ExpectReturnDate"]);
                    sbMailBody.Append("<br/>出仓日期：" + drRow["OfficeAutomation_Document_Secondment_SalesDate"]);
                    sbMailBody.Append("<br/>出仓人：" + drRow["OfficeAutomation_Document_Secondment_Sales"]);
                    sbMailBody.Append("<br/>归还日期：" + drRow["OfficeAutomation_Document_Secondment_ReturnDate"]);
                    sbMailBody.Append("<br/>归还人：" + drRow["OfficeAutomation_Document_Secondment_Returner"]);
                    sbMailBody.Append("<br/>借调原因：" + drRow["OfficeAutomation_Document_Secondment_Reason"]);

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

                            //完成后抄送
                            DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
                            ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
                            DataRow dr2 = ds.Tables[0].Rows[0];
                            ds = da_OfficeAutomation_Document_Assets_Inherit.SelectByName(dr2["OfficeAutomation_Document_Secondment_AssetsName"].ToString());
                            if (ds.Tables[0].Rows[0]["OfficeAutomation_Document_Assets_IsIT"].ToString() == "True")
                            {
                                employname = "倪秀珊";
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

                        if ((EmployeeID == "18331" || EmployeeID == "14470") && flowIDx == "1")
                        {
                            ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
                            DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
                            DataRow dr = ds.Tables[0].Rows[0];

                            da_OfficeAutomation_Document_Assets_Inherit.UpdateToggleZero(dr["OfficeAutomation_Document_Secondment_ApplyID"].ToString(), 0);
                        }

                        RunJS("alert('审批成功！');window.location='" + Page.Request.Url + "'");
                    }
                    else //不同意
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 5);//添加日志，签名不同意
                        DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
                        da_OfficeAutomation_Document_Assets_Inherit.UpdateToggleZero(txtApplyID.Text, 1);
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
        //    DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_Secondment_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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

    private T_OfficeAutomation_Document_Secondment GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_Secondment t_OfficeAutomation_Document_Secondment = new T_OfficeAutomation_Document_Secondment();
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_ID = UndertakeProjID;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_Apply = EmployeeName;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_BorrowDepartment = "总部仓库"; // txtBorrowDepartment.Text;

        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_InDptm = txtInDptm.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_InDptmContact = txtInDptmContact.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_AssetsName = ddlAssetsName.SelectedValue;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_TheMessage = txtTheMessage.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_Number = txtNumber.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_BorrowDate = txtBorrowDate.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_ExpectReturnDate = txtExpectReturnDate.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_SalesDate = txtSalesDate.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_Sales = txtSales.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_ReturnDate = txtReturnDate.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_Returner = txtReturner.Text;
        t_OfficeAutomation_Document_Secondment.OfficeAutomation_Document_Secondment_Reason = txtReason.Text;

        return t_OfficeAutomation_Document_Secondment;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_Secondment t_OfficeAutomation_Document_Secondment = new T_OfficeAutomation_Document_Secondment();
        DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_ID"].ToString();

        t_OfficeAutomation_Document_Secondment = GetModelFromPage(new Guid(ID));

        //ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
        DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
        //DataRow dr0 = ds.Tables[0].Rows[0];
        ds = da_OfficeAutomation_Document_Assets_Inherit.SelectInventory(ddlAssetsName.SelectedValue);
        int kj = 0;
        try
        {
            kj = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString()) - int.Parse(txtNumber.Text);
            if (kj < 0)
            {
                RunJS("alert('库存里没有足够的" + ddlAssetsName.SelectedValue + "');history.go(-1);");
                return;
            }
        }
        catch
        {
            RunJS("alert('库存里没有足够的" + ddlAssetsName.SelectedValue + "');history.go(-1);");
            return;
        }

        string apply = EmployeeName;
        string depname = txtDepartment.Text;
        string summary = ddlAssetsName.SelectedValue;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_Secondment_Inherit.Update(t_OfficeAutomation_Document_Secondment);//修改申请表

        ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        ds = da_OfficeAutomation_Document_Assets_Inherit.SelectByName(dr["OfficeAutomation_Document_Secondment_AssetsName"].ToString());
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Document_Assets_IsIT"].ToString() == "True")
        {
            T_OfficeAutomation_Flow flows;
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 5);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1236";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "梁锐华";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 6;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
        }
        else
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5,6");

        //DA_OfficeAutomation_Document_Secondment_Detail_Inherit da_OfficeAutomation_Document_Secondment_Detail_Inherit = new DA_OfficeAutomation_Document_Secondment_Detail_Inherit();
        //da_OfficeAutomation_Document_Secondment_Detail_Inherit.Delete(ID);
        //InsertSecondmentDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 48, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        if (Cache["AllDepartment"] == null)
        {
            SbJson.Remove(0, SbJson.Length);
            //wsKDHR.Service service = new wsKDHR.Service();
            //DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
            //SbJson.Append("[");

            //foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
            //{
            //    SbJson.Append("{\"id\":\"" + dr["id"].ToString() +  "\",\"value\":\"" + dr["name"].ToString() + "\"},");
            //}

            //SbJson.Remove(SbJson.Length - 1, 1);
            //SbJson.Append("]");

            wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
            string s = ws.GetDeptAll();
            s = s.Replace("Assets_Dept_", string.Empty).Replace("Id", "id").Replace("Name", "value");

            SbJson.Append(s);
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
        Session["FLG_ReWrite49"] = "1";
        Response.Write("<script>window.open('Apply_Secondment_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("资产借调申请表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Secondment_Department"].ToString();
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
                if (i == 1)//*-
                {
                    DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
                    da_OfficeAutomation_Document_Assets_Inherit.UpdateToggleZero(txtApplyID.Text, 1);
                }
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

            DataSet ds = new DataSet();
            DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
            //DataRow dr0 = ds.Tables[0].Rows[0];
            ds = da_OfficeAutomation_Document_Assets_Inherit.SelectInventory(ddlAssetsName.SelectedValue);
            int kj = 0;
            try
            {
                kj = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString()) - int.Parse(txtNumber.Text);
                if (kj < 0)
                {
                    RunJS("alert('库存里没有足够的" + ddlAssetsName.SelectedValue + "');history.go(-1);");
                    return;
                }
            }
            catch
            {
                RunJS("alert('库存里没有足够的" + ddlAssetsName.SelectedValue + "');history.go(-1);");
                return;
            }

            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

            string[] employnames;
            string email;
            string msnBody;
            DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
            ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Secondment_Department"].ToString();
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
            DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Secondment_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 2); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_Secondment_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    protected void ddlAssetsName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
        DataSet ds = new DataSet();
        try
        {
            ds = da_OfficeAutomation_Document_Assets_Inherit.SelectInventory(ddlAssetsName.SelectedValue);
            lbAssetsName.Text = "库存量：" + ds.Tables[0].Rows[0]["Count"].ToString() + "个";
            lbSummary.Text = "规格：" + ds.Tables[0].Rows[0]["Summary"].ToString();
        }
        catch
        {
            lbAssetsName.Text = "没有库存";
            lbSummary.Text = "";
        }
        try
        {
            ds = da_OfficeAutomation_Document_Assets_Inherit.SelectInventory(ddlAssetsName.SelectedValue);
            txtApplyID.Text = ds.Tables[0].Rows[0]["Financial"].ToString();
        }
        catch
        {
            txtApplyID.Text = "";
        }
    }
}